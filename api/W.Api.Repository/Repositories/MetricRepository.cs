//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       MetricRepository.cs
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
    /// Metric Data Layer
    /// </summary>
    public class MetricRepository : AbstractModelRepository<IJurisdiction>, IModelRepository<IJurisdiction>
    {
        #region Private Static Members
        private const string TABLE = "metric";
        private const string FIELDS = "`Id`, `TopicId`, `GroupId`, `Name`, `Description`, `Type`, `CreatedOn`";
        #endregion

        #region Private Member Variables
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="MetricRepository" /> class.</summary>
        /// <param name="conn">DB Connection.</param>
        /// <param name="manager">Model Manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public MetricRepository (IDbConnection conn, IModelManager manager, ClaimsSubject subject)
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
        /// <returns>Metric</returns>
        protected override string Modifier (IJurisdiction model, bool exists)
        {
            Logger.Debug ($"Calling MetricRepository.Modifier({model.Id})");

            string _rtn = string.Empty;

            if (exists) { // UPDATE statement
                _rtn = $"UPDATE `{TABLE}` SET "
                    + $"`TopicId` = {model.TopicId}, "
                    + $"`GroupId` = {model.GroupId}, "
                    + $"`Name` = '{model.Name.EscapeSafely ()}', "
                    + $"`Description` = '{model.Description.EscapeSafely ()}', "
                    + $"`Type` = {(int)model.Type} "
                    + $"WHERE "
                    + $"`Id` = {model.Id}"
                    + $";";
                
            } else { // INSERT statement
                _rtn = $"INSERT INTO `{TABLE}` "
                    + $"(`TopicId`, `GroupId`, `Name`, `Description`, `Type`, `CreatedOn`) "
                    + $"VALUES ("
                    + $"{model.TopicId}, "
                    + $"{model.GroupId}, "
                    + $"'{model.Name.EscapeSafely ()}', "
                    + $"'{model.Description.EscapeSafely ()}', "
                    + $"{(int)model.Type}, "
                    + $"'{model.CreatedOn.StringifyANSI ()}'"
                    + $");";
            }
            return _rtn;
        }
        #endregion

        #region Protected Operations
        /// <summary>
        /// Maps datareader into Metric model
        /// </summary>
        /// <param name="r">Datareader</param>
        /// <returns>Metric</returns>
        protected override IJurisdiction Build (IDataReader r)
        {
            return new Metric (theManager, theSubject) {
                Id = r.GetInt32 (r.GetOrdinal ("Id")),
                TopicId = r.SafeGetInt32 ("TopicId"),
                GroupId = r.SafeGetInt32 ("GroupId"),
                Name = r.SafeGetString ("Name"),
                Description = r.SafeGetString ("Description"),
                Type = (MetricType)r.SafeGetInt32 ("Type"),
                CreatedOn = r.SafeGetTimestamp ("CreatedOn")
            };
        }
        #endregion

        #region Private Operations
        #endregion
    }
}