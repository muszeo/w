//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IdentityContextRepository.cs
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
    public class IdentityContextRepository : AbstractModelRepository<ILocation>, IModelRepository<ILocation>
    {
        #region Private Static Members
        private const string TABLE = "identity_context";
        private const string FIELDS = "`Id`, `Start`, `End`, `SubjectIdentifier`, `Provider`, `CreatedOn`";
        #endregion

        #region Private Member Variables
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="IdentityContextRepository" /> class.</summary>
        /// <param name="conn">DB Connection.</param>
        /// <param name="manager">Model Manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public IdentityContextRepository (IDbConnection conn, IModelManager manager, ClaimsSubject subject)
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
        /// <returns>SQL String</returns>
        protected override string Modifier (ILocation model, bool exists)
        {
            Logger.Debug ($"Calling IdentityContextRepository.Modifier({model.Id})");

            string _rtn = string.Empty;

            if (exists) { // UPDATE statement
                _rtn = $"UPDATE `{TABLE}` SET "
                    + $"`Start` = '{model.Start.StringifyANSI ()}', "
                    + $"`End` = '{model.End.StringifyANSI ()}', "
                    + $"`SubjectIdentifier` = '{model.SubjectIdentifier.EscapeSafely ()}', "
                    + $"`Provider` = '{model.Provider.EscapeSafely ()}', "
                    + $"`Username` = '{model.Username.EscapeSafely ()}', "
                    + $"`Email` = '{model.Email.EscapeSafely ()}' "
                    + $"WHERE "
                    + $"`Id` = {model.Id}"
                    + $";";

            } else { // INSERT statement
                _rtn = $"INSERT INTO `{TABLE}` "
                    + $"(`Start`, `End`, `SubjectIdentifier`, `Provider`, `Username`, `Email`, `CreatedOn`) "
                    + $"VALUES ("
                    + $"'{model.Start.StringifyANSI ()}', "
                    + $"'{model.End.StringifyANSI ()}', "
                    + $"'{model.SubjectIdentifier.EscapeSafely ()}', "
                    + $"'{model.Provider.EscapeSafely ()}', "
                    + $"'{model.Username.EscapeSafely ()}', "
                    + $"'{model.Email.EscapeSafely ()}', "
                    + $"'{model.CreatedOn.StringifyANSI ()}'"
                    + $");";

            }

            return _rtn;
        }
        #endregion

        #region Protected Operations
        /// <summary>
        /// Maps datareader into an Identity Context model
        /// </summary>
        /// <param name="r">Datareader</param>
        /// <returns>IdentityContext</returns>
        protected override ILocation Build (IDataReader r)
        {
            return new IdentityContext (theManager, theSubject) {
                Id = r.GetInt32 (r.GetOrdinal ("Id")),
                Start = r.SafeGetDate ("Start"),
                End = r.SafeGetDate ("End"),
                SubjectIdentifier = r.SafeGetString ("SubjectIdentifier"),
                Provider = r.SafeGetString ("Provider"),
                CreatedOn = r.SafeGetTimestamp ("CreatedOn")
            };
        }
        #endregion

        #region Private Operations
        #endregion
    }
}