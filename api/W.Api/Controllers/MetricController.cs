//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       MetricController.cs
//  Desciption: MetricController WebAPI
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System.Xml.Linq;
using System.Windows.Input;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using W.Api.Dtos;
using W.Api.Model;
using W.Api.Logging;
using W.Api.Dtos.Lists;
using W.Api.Exceptions;
using W.Api.Repository;
using Microsoft.AspNetCore.Authorization;
using W.Api.Authorisation;
using W.Api.Dtos.Builders;
using W.Api.Model.Interfaces;
using static W.Api.Settings.Constants.Events;
#endregion

namespace W.Api.Controllers
{
    /// <summary>
    /// MetricController WebAPI
    /// </summary>
    /// <seealso cref="W.Api.Controllers.AbstractWebApiController" />
    [Authorize]
    [Produces ("application/json")]
    [Route ("api/[controller]")]
    [ApiController]
    public class MetricController : AbstractWebApiController
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="MetricController" /> class.</summary>
        /// <param name="databaseRepository">The database repository.</param>
        /// <param name="security">The security configuration.</param>
        public MetricController (IOptions<DatabaseManager> databaseRepository, IOptions<SecurityManager> security)
            : base (databaseRepository, security)
        {
        }
        #endregion

        #region GETs
        /// <summary>
        /// Gets a Metric using a specified {identifier}.
        ///
        /// verb:       GET
        /// method:     /api/metric/{id}
        ///
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// MetricDto
        /// </returns>
        [HttpGet ("{id}")]
        [Produces ("application/json")]
        public ActionResult<MetricDto> Get (int id)
        {
            Logger.Debug ($"Calling Metric -> Get - {id}");

            return ExecuteHttp (
                () => {

                    // Create default return.
                    MetricDto _rtn = new MetricDto ();

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();

                    // Get Metric Item.
                    IJurisdiction _m =
                        Manager ()
                            .RepositoryFor<IJurisdiction> (Subject)
                            .Read (id);

                    // Create return
                    if (_m != null) {
                        _rtn = _rtn.From (_m);
                    } else {
                        throw new EntityNotFoundException ("Metric", id);
                    }

                    return _rtn;
                }
            );
        }
        #endregion

        #region POSTs
        /// <summary>
        /// Posts a new Metric.
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MetricDto> Post ([FromBody] NewMetricDto dto)
        {
            Logger.Debug ($"Calling Metric -> Post New *Metric* - {dto}");
            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();
                    HasSubjectWriteScope ();

                    MetricDto _rtn = new MetricDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Metric '{dto.Name}' in Topic '{dto.TopicId}' and Group '{dto.GroupId}'"
                            );

                            // Create new Metric
                            IJurisdiction _m = new Metric (Manager (), Subject) {
                                TopicId = dto.TopicId,
                                GroupId = dto.GroupId,
                                Name = dto.Name,
                                Description = dto.Description,
                                Type = (MetricType)dto.Type,
                                CreatedOn = DateTime.Now
                            };

                            // Save new Metric
                            Manager ()
                                .RepositoryFor<IJurisdiction> (Subject)
                                .Upsert (_m, trans);

                            // Return new Metric
                            _rtn = _rtn.From (_m);
                        }
                    );

                    return _rtn;

                }
            );
        }

        /// <summary>
        /// Posts a new Metric Observation.
        ///
        /// verb:       POST
        /// method:     /api/metric/{id}/observation
        ///
        /// </summary>
        /// <param name="id">The ID of the Metric to create an Observation for.</param>
        /// <param name="dto">The new Observation.</param>
        /// <returns>
        ///   Created Observation object
        /// </returns>
        [HttpPost ("{id}/observation")]
        public ActionResult<ObservationDto> Post__Observation (int id, [FromBody] NewHomogeneousObservationDto dto)
        {
            Logger.Debug ($"Calling Metric -> Post New *Observation* - {dto}");

            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();
                    HasSubjectWriteScope ();

                    ObservationDto _rtn = new ObservationDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Metric Observation for Metric '{id}'"
                            );

                            // Get Metric
                            IJurisdiction _m = Manager ()
                                .RepositoryFor<IJurisdiction> (Subject)
                                .Read (id);

                            if (_m != null) {
                                _rtn = _rtn.From (
                                    _m.NewObservation (
                                        trans,
                                        dto.SourceId,
                                        dto.ContextId,
                                        dto.SubjectId,
                                        dto.Timestamp,
                                        dto.nI,
                                        dto.nD,
                                        dto.dT,
                                        dto.tC,
                                        dto.tX
                                    )
                                );
                            } else {
                                throw new EntityNotFoundException ("Metric", id);
                            }
                        }
                    );

                    return _rtn;

                }
            );
        }

        /// <summary>
        /// Posts a new 'Homogeneous' Metric Observations List.
        /// Homogeneous = All observations are of the same type (Metric).
        ///
        /// verb:       POST
        /// method:     /api/metric/{id}/observations
        ///
        /// </summary>
        /// <param name="id">The ID of the Metric to create an Observation for.</param>
        /// <param name="dto">The new Observations List.</param>
        /// <returns>
        ///   Created Observation objects
        /// </returns>
        [HttpPost ("{id}/observations")]
        public ActionResult<ObservationListDto> Post__HomogeneousObservations (int id, [FromBody] List<NewHomogeneousObservationDto> dto)
        {
            Logger.Debug ($"Calling Metric -> Post All New Homogeneous Metric *Observations* - {dto}");

            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();
                    HasSubjectWriteScope ();

                    ObservationListDto _rtn = new ObservationListDto ();

                    Manager ().Scoped (
                        (trans) => {

                            Logger.Info (
                                $"Creating new Homogeneous Metric Observations for Metric '{id}'"
                            );

                            // Get Metric
                            IJurisdiction _m = Manager ()
                                .RepositoryFor<IJurisdiction> (Subject)
                                .Read (id);

                            if (_m != null) {
                                // Loop given {dto} items and create Observations
                                foreach (NewHomogeneousObservationDto _dto in dto) {
                                    _rtn.Items.Add (
                                        new ObservationDto ()
                                            .From (
                                                _m.NewObservation (
                                                    trans,
                                                    _dto.SourceId,
                                                    _dto.ContextId,
                                                    _dto.SubjectId,
                                                    _dto.Timestamp,
                                                    _dto.nI,
                                                    _dto.nD,
                                                    _dto.dT,
                                                    _dto.tC,
                                                    _dto.tX
                                                )
                                            )
                                        );
                                }

                            } else {
                                throw new EntityNotFoundException ("Metric", id);
                            }
                        }
                    );

                    return _rtn;

                }
            );
        }

        /// <summary>
        /// Posts a new 'Hetrogeneous' Metric Observations List.
        /// Hetrogeneous = Observations can be of different types (Metrics).
        ///
        /// verb:       POST
        /// method:     /api/metric/observations
        ///
        /// </summary>
        /// <param name="dto">The new Observations List.</param>
        /// <returns>
        ///   Created Observation objects
        /// </returns>
        [HttpPost ("observations")]
        public ActionResult<ObservationListDto> Post__HetrogeneousObservations ([FromBody] List<NewHetrogeneousObservationDto> dto)
        {
            Logger.Debug ($"Calling Metric -> Post All New Hetrogeneous *Observations* - {dto}");

            return ExecuteHttp (
                () => {

                    // Check API Scopes Authorisation.
                    HasSubjectReadScope ();
                    HasSubjectWriteScope ();

                    ObservationListDto _rtn = new ObservationListDto ();

                    Manager ().Scoped (
                        (trans) => {

                            IDictionary<int, IJurisdiction> _metrics = new Dictionary<int, IJurisdiction> ();

                            // Loop given {dto} items and create Observations
                            foreach (NewHetrogeneousObservationDto _dto in dto) {

                                if (!_metrics.ContainsKey (_dto.MetricId)) {

                                    Logger.Info (
                                        $"Creating new Metric Hetrogeneous Observation for Metric '{_dto.MetricId}'"
                                    );

                                    // Get Metric
                                    IJurisdiction _m = Manager ()
                                        .RepositoryFor<IJurisdiction> (Subject)
                                        .Read (_dto.MetricId);

                                    // Add Metric to local buffer
                                    if (_m != null) {
                                        _metrics.Add (_dto.MetricId, _m);
                                    } else {
                                        throw new EntityNotFoundException ("Metric", _dto.MetricId);
                                    }
                            }

                            _rtn.Items.Add (
                                    new ObservationDto ()
                                        .From (
                                            _metrics [_dto.MetricId]
                                                .NewObservation (
                                                    trans,
                                                    _dto.SourceId,
                                                    _dto.ContextId,
                                                    _dto.SubjectId,
                                                    _dto.Timestamp,
                                                    _dto.nI,
                                                    _dto.nD,
                                                    _dto.dT,
                                                    _dto.tC,
                                                    _dto.tX
                                                )
                                        )
                                    );
                            }
                        }
                    );

                    return _rtn;

                }
            );
        }
        #endregion

        #region PUTs
        #endregion

        #region DELETEs
        #endregion
    }
}