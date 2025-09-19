//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       TopicRepository.cs
//  Desciption: 
//
//  (c) , 2025
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
    public class TopicRepository : AbstractModelRepository<IContract>, IModelRepository<IContract>
    {
        #region Private Static Members
        private const string TABLE = "topic";
        private const string FIELDS = "`Id`, `Name`, `Description`, `CreatedOn`";
        #endregion

        #region Private Member Variables
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="TopicRepository" /> class.</summary>
        /// <param name="conn">DB Connection.</param>
        /// <param name="manager">Model Manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public TopicRepository (IDbConnection conn, IModelManager manager, ClaimsSubject subject)
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
        /// <returns>Topic</returns>
        protected override string Modifier (IContract model, bool exists)
        {
            Logger.Debug ($"Calling TopicRepository.Modifier({model.Id})");

            string _rtn = string.Empty;

            if (exists) { // UPDATE statement
                _rtn = $"UPDATE {TABLE} SET "
                    + $"`Name` = '{model.Name.EscapeSafely ()}', "
                    + $"`Description` = '{model.Description.EscapeSafely ()}' "
                    + $"WHERE "
                    + $"`Id` = {model.Id}"
                    + $";";

            } else { // INSERT statement
                _rtn = $"INSERT INTO {TABLE} "
                    + $"(`Name`, `Description`, `CreatedOn`) "
                    + $"VALUES ("
                    + $"'{model.Name.EscapeSafely ()}', "
                    + $"'{model.Description.EscapeSafely ()}', "
                    + $"'{model.CreatedOn.StringifyANSI ()}'"
                    + $");";
            }
            return _rtn;
        }
        #endregion

        #region Protected Operations
        /// <summary>
        /// Maps datareader into Topic model
        /// </summary>
        /// <param name="r">Datareader</param>
        /// <returns>Topic</returns>
        protected override IContract Build (IDataReader r)
        {
            return new Topic (theManager, theSubject) {
                Id = r.GetInt32 (r.GetOrdinal ("Id")),
                Name = r.SafeGetString ("Name"),
                Description = r.SafeGetString ("Description"),
                CreatedOn = r.SafeGetTimestamp ("CreatedOn")
            };
        }
        #endregion

        #region Private Operations
        #endregion
    }
}