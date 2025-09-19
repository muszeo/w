//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       GroupRepository.cs
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
    /// Group Data Layer
    /// </summary>
    public class GroupRepository : AbstractModelRepository<IClient>, IModelRepository<IClient>
    {
        #region Private Static Members
        private const string TABLE = "group";
        private const string FIELDS = "`Id`, `Name`, `Description`, `CreatedOn`";
        #endregion

        #region Private Member Variables
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="GroupRepository" /> class.</summary>
        /// <param name="conn">DB Connection.</param>
        /// <param name="manager">Model Manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public GroupRepository (IDbConnection conn, IModelManager manager, ClaimsSubject subject)
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
        /// <returns>Group</returns>
        protected override string Modifier (IClient model, bool exists)
        {
            Logger.Debug ($"Calling GroupRepository.Modifier({model.Id})");

            string _rtn = string.Empty;

            if (exists) { // UPDATE statement
                _rtn = $"UPDATE `{TABLE}` SET "
                    + $"`Name` = '{model.Name.EscapeSafely ()}', "
                    + $"`Description` = '{model.Description.EscapeSafely ()}' "
                    + $"WHERE "
                    + $"`Id` = {model.Id}"
                    + $";";

            } else { // INSERT statement
                _rtn = $"INSERT INTO `{TABLE}` "
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
        /// Maps datareader into Metric Group model
        /// </summary>
        /// <param name="r">Datareader</param>
        /// <returns>Group</returns>
        protected override IClient Build (IDataReader r)
        {
            return new Group (theManager, theSubject) {
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