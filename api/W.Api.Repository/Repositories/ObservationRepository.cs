//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       ObservationRepository.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Data;
using MySqlX.XDevAPI;
using System.Text.Json;
using System.Text.Json.Nodes; 
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using W.Api.Model;
using W.Api.Logging;
using W.Api.Exceptions;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Repository
{
    /// <summary>
    /// Observation Data Layer
    /// </summary>
    public class ObservationRepository : AbstractModelRepository<ITimeZone>, IModelRepository<ITimeZone>
    {
        #region Private Static Members
        private const string TABLE = "observation";
        private const string FIELDS = "`Id`, `MetricId`, `SourceId`, `ContextId`, `SubjectId`, `Timestamp`, `nI`, `nD`, `dT`, `t25`, `tX`, `CreatedOn`";
        #endregion

        #region Private Member Variables
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ObservationRepository" /> class.</summary>
        /// <param name="conn">DB Connection.</param>
        /// <param name="manager">Model Manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public ObservationRepository (IDbConnection conn, IModelManager manager, ClaimsSubject subject)
            : base (conn, manager, subject)
        {
        }
        #endregion

        #region Protected Override Properties
        /// <summary>
        /// Gets the Table for this Repository.
        /// </summary>
        protected override string Table
        {
            get {
                return TABLE;
            }
        }

        /// <summary>
        /// Gets the Table Fields (Columns) for this Repository.
        /// </summary>
        protected override string Fields
        {
            get {
                return FIELDS;
            }
        }
        #endregion

        #region Upsert
        /// <summary>
        /// Build a Modifier Statement for the given {model}.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="exists"></param>
        /// <returns>Observation</returns>
        protected override string Modifier (ITimeZone model, bool exists)
        {
            Logger.Debug ($"Calling ObservationRepository.Modifier({model.Id})");

            string _rtn = string.Empty;

            if (!exists) { // INSERT statement ONLY -- Metric Observations cannot be updated once recorded
                _rtn = $"INSERT INTO {TABLE} "
                    + $"(`MetricId`, `SourceId`, `ContextId`, `SubjectId`, `Timestamp`, `nI`, `nD`, `dT`, `t25`, `tX`, `CreatedOn`) "
                    + $"VALUES ("
                    + $"{model.MetricId}, "
                    + $"{model.SourceId}, "
                    + $"{model.ContextId}, "
                    + $"{model.SubjectId}, "
                    + $"'{model.Timestamp.StringifyANSI ()}', "
                    + $"{model.nI.StringifyANSI ()}, "
                    + $"{model.nD.StringifyANSI ()}, "
                    + $"{model.dT.StringifyANSIAndQuoteIfNotNull ()}, "
                    + $"{model.tC.QuoteIfNotNull ()}, "
                    + $"{model.tX.QuoteIfNotNull ()}, "
                    + $"'{model.CreatedOn.StringifyANSI ()}'"
                    + $");";
            }
            return _rtn;
        }
        #endregion

        #region Protected Operations
        /// <summary>
        /// Maps datareader into an Observation model
        /// </summary>
        /// <param name="r">Datareader</param>
        /// <returns>Observation</returns>
        protected override ITimeZone Build (IDataReader r)
        {
            return new Observation (theManager, theSubject) {
                Id = r.GetInt32 (r.GetOrdinal ("Id")),
                MetricId = r.SafeGetInt32 ("MetricId"),
                SourceId = r.SafeGetInt32 ("SourceId"),
                ContextId = r.SafeGetInt32 ("ContextId"),
                SubjectId = r.SafeGetInt32 ("SubjectId"),
                Timestamp = r.SafeGetTimestamp ("Timestamp"),
                nI = r.SafeGetInt32 ("nI"),
                nD = r.SafeGetDecimal ("nD"),
                dT = r.SafeGetDate ("dT"),
                tC = r.SafeGetString ("t25"),
                tX = r.SafeGetString ("tX"),
                CreatedOn = r.SafeGetTimestamp ("CreatedOn")
            };
        }
        #endregion

        #region Private Operations
        #endregion
    }
}