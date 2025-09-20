//----------------------------------------------------------------------------------------------------------
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
#endregion

namespace W.Api.Repository.Configured
{
    public abstract class AbstractRepository<T>
    {
        #region Protected Static Properties
        protected static IConfiguration Configuration { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:MyTrucking.Eventing.Api.Repository.Configured.AbstractRepository"/> class.
        /// </summary>
        public AbstractRepository (IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Public Abstract Operations
        public abstract IEnumerable<T> Get ();
        #endregion

        #region Protected Operations
        /// <summary>
        /// Builds a list of objects of type <typeparamref name="T"/> using the given configuration {section} and the
        /// given {create} factory method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="section"></param>
        /// <param name="create"></param>
        /// <returns></returns>
        protected IList<T> BuildFromSection<T> (IConfigurationSection section, Func<IConfigurationSection, T> create)
        {
            IList<T> _rtn = new List<T> ();
            foreach (IConfigurationSection _s in section.GetChildren ()) {
                _rtn.Add (
                    create (_s)
                );
            }
            return _rtn;
        }
        #endregion
    }
}