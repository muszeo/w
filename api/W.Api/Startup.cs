//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Startup.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using W.Api.Settings;
using W.Api.Repository;
using W.Api.Authorisation;
using W.Api.Repository.Configured;
using Google.Protobuf.WellKnownTypes;
#endregion

namespace W.Api
{
    /// <summary>
    /// Startup for MyTrucking API
    /// </summary>
    public class Startup
    {
        #region Private Constants
        private const string ALLOW_SUBDOMAINS = "AllowSubdomains";
        #endregion

        #region Public Properties
        public IConfigurationRoot Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyTrucking.Eventing.Api.Startup"/> class.
        /// </summary>
        /// <param name="env">Env.</param>
        public Startup (IWebHostEnvironment env)
        {
            IConfigurationBuilder _b =
                new ConfigurationBuilder ()
                    .SetBasePath (env.ContentRootPath)
                    .AddJsonFile ("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile ($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                    .AddEnvironmentVariables ();
            Configuration = _b.Build ();
            Environment = env;
            RepositoryFactory.UseConfiguration (Configuration);
        }
        #endregion

        #region Configure Services
        /// <summary>Configures the services.</summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices (IServiceCollection services)
        {
            services
                .Configure<DatabaseManager> (
                    Configuration.GetSection (Constants.Config.Sections.DATABASE)
                );

            services
                .Configure<SecurityManager> (
                    Configuration.GetSection (Constants.Config.Sections.SECURITY)
                );

            services
                .AddControllers ()
                   .AddJsonOptions (_o => {
                       _o.JsonSerializerOptions.DefaultIgnoreCondition =
                              System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                   });

            services
                .AddControllers ();

            services
                .AddAuthentication (Constants.Security.JWT_BEARER)
                .AddJwtBearer (
                    Constants.Security.JWT_BEARER,
                    _o => {
                        _o.Authority = Configuration.GetSection (Constants.Config.Sections.SECURITY_AUTHORITY).Value;
                        _o.RequireHttpsMetadata = false;
                        _o.TokenValidationParameters =
                            new TokenValidationParameters {
                                ValidateAudience = false
                            };
                    }
                );

            services.AddCors (_o => {
                _o.AddPolicy (ALLOW_SUBDOMAINS, _p => { _p
                    .SetIsOriginAllowedToAllowWildcardSubdomains ()
                    .SetIsOriginAllowed (__o => {
                        if (Uri.TryCreate (__o, UriKind.Absolute, out var uri)) {
                            return
                                uri.Host.EndsWith (".mytrucking.nz", StringComparison.OrdinalIgnoreCase) ||
                                uri.Host.EndsWith (".gomytrucking.com", StringComparison.OrdinalIgnoreCase);
                        }
                        return false;
                    })
                    // .AllowAnyOrigin () // commented out = Disallow * Origins
                    .AllowAnyHeader ()
                    .AllowAnyMethod ();
                });
            });

            services
                .AddAuthorization ();

            services
                .AddSwaggerGen ();
        }
        #endregion

        #region Configure
        /// <summary>This method gets called by the runtime. Use this method to configure the HTTP request pipeline</summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
        {
            // NB. Important Note!
            // The ORDER of the Use() statements below is important for the kestral middleware.
            // If changing the order be careful!

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseExceptionHandler (Constants.Uris.Local.ERROR);
                // The default HSTS value is 30 days, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseRouting ();
            app.UseCors (ALLOW_SUBDOMAINS); // "AllowSubdomains" policy is defined in ConfigureService() method
            app.UseAuthentication ();
            app.UseAuthorization ();

            app.UseEndpoints (
                _b => {
                    _b.MapControllers ()
                        .RequireAuthorization ();
                }
            );

            app.UseSwagger ();

            app.UseSwaggerUI (_c => {
                _c.SwaggerEndpoint (
                    Constants.Uris.Local.SWAGGER,
                    Constants.Messages.MSG__TITLE
                );
            });
        }
        #endregion
    }
}