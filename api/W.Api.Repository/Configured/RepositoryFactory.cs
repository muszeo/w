//----------------------------------------------------------------------------------------------------------
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using W.Api.Logging;
using W.Api.Exceptions;
using Microsoft.Extensions.Configuration;
#endregion

namespace W.Api.Repository.Configured
{
    public class RepositoryFactory
    {
        #region Private Static Properties
        private static IConfiguration Configuration { get; set; }
        #endregion

        #region Public Static Operations
        /// <summary>
        /// Specifies that this Repository should use the given appsettings {configuration}
        /// from which to get data.
        /// </summary>
        /// <param name="configuration"></param>
        public static void UseConfiguration (IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets a Repository for the given type {T}.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static AbstractRepository<T> RepositoryFor<T> ()
        {
            AbstractRepository<T> _rtn = null;

            if (Configuration != null) {
                if (typeof (T).Equals (typeof (SettingsModel))) {
                    _rtn = new SettingsModelRepository (Configuration) as AbstractRepository<T>;
                } else {
                    throw new NoConfigurationSpecifiedException ();
                }
            }

            return _rtn;
        }
        #endregion
    }
}