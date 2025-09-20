//----------------------------------------------------------------------------------------------------------
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Linq;
using System.Collections.Generic;
using W.Api.Settings;
using Microsoft.Extensions.Configuration;
#endregion

namespace W.Api.Repository.Configured
{
    public class SettingsModelRepository : AbstractRepository<SettingsModel>
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="T:W.Api.Repository.Configured.SettingsModelRepository"/> class.
        /// </summary>
        public SettingsModelRepository (IConfiguration configuration)
            : base (configuration)
        {
        }
        #endregion

        #region Public Override Operations
        /// <summary>
        /// Gets all Settings configs from configuration.
        /// </summary>
        /// <returns>All SettingsModel as an IEnumerable.</returns>
        public override IEnumerable<SettingsModel> Get ()
        {
            IList<SettingsModel> _rtn = new List<SettingsModel> ();

            IConfigurationSection _settings = Configuration
                .GetSection (Constants.Config.Sections.SETTINGS);

            IEnumerable<IConfigurationSection> _observes = _settings
                .GetSection (Constants.Config.Sections.AUTO_OBSERVE)
                .GetChildren ();

            IDictionary<string, (string, string, string)> _O = new Dictionary<string, (string, string, string)> ();
            foreach (IConfigurationSection _o in _observes) {
                _O.Add (
                    _o [Constants.Config.Fields.METRIC_ID],
                    (
                        _o [Constants.Config.Fields.METRIC_ROLE],
                        _o [Constants.Config.Fields.METRIC_ARGS],
                        _o [Constants.Config.Fields.METRIC_RECUR]
                    )
                );
            }

            _rtn.Add (
                new SettingsModel () {
                    QueueFor = _settings [Constants.Config.Fields.QUEUE_FOR],
                    AutoObserve = _O
                }
            );

            return _rtn;
        }
        #endregion
    }
}