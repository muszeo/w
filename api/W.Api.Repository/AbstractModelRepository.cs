//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       AbstractModelRepository.cs
//  Desciption: 
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
using MySqlX.XDevAPI.Relational;
using System.Collections.Generic;
using W.Api.Model;
using W.Api.Logging;
using W.Api.Settings;
using W.Api.Exceptions;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
using static W.Api.Settings.Constants.Config;
#endregion

namespace W.Api.Repository
{
    public abstract class AbstractModelRepository<T>
        where T : IModelObject
    {
        #region Protected Member Variables
        protected readonly IDbConnection theConn = null;
        protected readonly IModelManager theManager = null;
        protected readonly ClaimsSubject theSubject;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MyTrucking.Core.Api.Repository.Database.AbstractModelRepository"/> class.
        /// </summary>
        /// <param name="conn">DB Connection</param>
        /// <param name="manager">Model Manager.</param>
        /// <param name="subject">ClaimsSubject.</param>
        public AbstractModelRepository (IDbConnection conn, IModelManager manager, ClaimsSubject subject)
        {
            theConn = conn;
            theManager = manager;
            theSubject = subject;
        }
        #endregion

        #region Protected Abstract Properties
        protected abstract string Table { get; }
        protected abstract string Fields { get; }
        #endregion

        #region Protected Abstract Operations
        protected abstract T Build (IDataReader reader);
        protected abstract string Modifier (T model, bool exists);
        #endregion

        #region Public Operations
        #region Read
        /// <summary>Reads {T} with the specified identifier {id}.</summary>
        /// <param name="id">The T identifier.</param>
        /// <returns>T</returns>
        public T Read (int id)
        {
            Logger.Debug ($"Calling {Table}Repository.Read({id})");

            return Query (
                $"SELECT DISTINCT " +
                $"{Fields} " +
                $"FROM `{Table}` " +
                $"WHERE Id={id};",
                (r) => {
                    T _rtn = default (T);
                    if (r.Read ()) {
                        _rtn = Build (r);
                    }
                    return _rtn;
                }
            );
        }
        #endregion

        #region ReadWhere
        /// <summary>
        /// Reads {T} where {clause}.
        /// Note the {limit} parameter does not apply if Periods(Period.All) has
        /// previously been set.
        /// </summary>
        /// <param name="clause">The Clause.</param>
        /// <param name="limit">The Limit</param>
        /// <returns>List of T</returns>
        public IList<T> ReadWhere (string clause, int limit = 0)
        {
            Logger.Debug ($"Calling {Table}Repository.ReadWhere('{clause}')");

            return QueryAll (
                $"SELECT DISTINCT " +
                $"{Fields} " +
                $"FROM `{Table}` " +
                $"WHERE {clause} " +
                ((limit > 0) ? $"LIMIT {limit}" : string.Empty) +
                $";",
                (r) => {
                    IList<T> _rtn = new List<T> ();
                    while (r.Read ()) {
                        _rtn.Add (
                            Build (r)
                        );
                    }
                    return _rtn;
                }
            );
        }
        #endregion

        #region ReadAll
        /// <summary>
        /// Reads all {T}.
        /// Note the {limit} parameter does not apply if Periods(Period.All) has
        /// previously been set.
        /// </summary>
        /// <returns>List of T</returns>
        public IList<T> ReadAll (int limit = 0)
        {
            Logger.Debug ($"Calling {Table}Repository.ReadAll()");

            return QueryAll (
                $"SELECT DISTINCT " +
                $" {Fields} " +
                $"FROM `{Table}` " +
                $"ORDER BY Id DESC " +
                ((limit > 0) ? $"LIMIT {limit}" : string.Empty) +
                $";",
                (r) => {
                    IList<T> _rtn = new List<T> ();
                    while (r.Read ()) {
                        _rtn.Add (
                            Build (r)
                        );
                    }
                    return _rtn;
                }
            );
        }
        #endregion

        #region ReadJoin
        /// <summary>
        /// Read {T} Joined.
        /// </summary>
        /// <param name="join">The JOIN</param>
        /// <param name="clause">The WHERE</param>
        /// <param name="limit">The LIMIT</param>
        /// <returns>List of T</returns>
        public IList<T> ReadJoin (string join, string clause, int limit = 0)
        {
            Logger.Debug ($"Calling {Table}Repository.ReadJoin('{join}', '{clause}')");

            return QueryAll (
                $"SELECT DISTINCT " +
                $"{Fields} " +
                $"FROM `{Table}` " +
                $"{join} " +
                $"WHERE {clause} " +
                $"ORDER BY Id DESC " +
                ((limit > 0) ? $"LIMIT {limit}" : string.Empty) +
                $";",
                (r) => {
                    IList<T> _rtn = new List<T> ();
                    while (r.Read ()) {
                        _rtn.Add (
                            Build (r)
                        );
                    }
                    return _rtn;
                }
            );
        }
        #endregion

        #region Remove
        /// <summary>
        /// Remove the specific {T}
        /// </summary>
        /// <param name="model">T object</param>
        /// <param name="trans">DB Transaction</param>
        public void Remove (T model, IDbTransaction trans)
        {
            Logger.Debug ($"Calling {Table}Repository.Remove({model.Id})");
            Delete (
                Table,
                $"Id={model.Id}",
                trans
            );
        }
        #endregion

        #region RemoveWhere
        /// <summary>
        /// Removes all rows where the given {clause} applies.
        /// </summary>
        /// <param name="clause"></param>
        /// <param name="trans"></param>
        public void RemoveWhere (string clause, IDbTransaction trans)
        {
            Logger.Debug ($"Calling {Table}Repository.RemoveWhere('{clause}')");
            Delete (
                Table,
                clause,
                trans
            );
        }
        #endregion

        #region Upsert
        /// <summary>Upserts the specified {T} model.</summary>
        /// <param name="model">The model.</param>
        /// <param name="trans">The trans.</param>
        /// <returns>T object</returns>
        public T Upsert (T model, IDbTransaction trans)
        {
            Logger.Debug ($"Calling {Table}Repository.Upsert({model.Id})");
            ExecuteOptimistic (
                Table,
                "Id",
                model,
                (exists) => {
                    return Modifier (model, exists);
                },
                trans
            );
            return model;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete from the specified {table} with given {clause}, {conn} and {trans}.
        /// </summary>
        /// <param name="table">Table.</param>
        /// <param name="clause">Clause.</param>
        /// <param name="trans">Trans.</param>
        protected void Delete (string table, string clause, IDbTransaction trans)
        {
            ExecuteStatement (
                $"DELETE FROM `{table}` WHERE {clause};",
                trans
            );
        }
        #endregion

        #region Query
        /// <summary>
        /// Execute {sql} Query and use {fn} to create Results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        protected T Query<T> (string sql, Func<IDataReader, T> fn)
            where T : IModelObject
        {
            T _rtn = default (T);
            using (IDbCommand _c = theConn.CreateCommand ()) {
                _c.CommandText = sql;
                using (IDataReader _r = _c.ExecuteReader ()) {
                    _rtn = fn (_r);
                    _r.Close ();
                }
            }
            return _rtn;
        }
        #endregion

        #region QueryAll
        /// <summary>
        /// Execute {sql} Query and Iterate Records using {fn} to create Results.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="fn"></param>
        /// <returns></returns>
        protected IList<T> QueryAll<T> (string sql, Func<IDataReader, IList<T>> fn)
            where T : IModelObject
        {
            IList<T> _rtn = null;
            using (IDbCommand _c = theConn.CreateCommand ()) {
                _c.CommandText = sql;
                using (IDataReader _r = _c.ExecuteReader ()) {
                    _rtn = fn (_r);
                    _r.Close ();
                }
            }
            return _rtn;
        }
        #endregion

        #region ExecuteOptimistic
        /// <summary>
        /// Execute an Optimistically-locked Update or Insert for a given {obj}.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="obj"></param>
        /// <param name="fn"></param>
        /// <param name="trans"></param>
        /// <param name="audit"></param>
        protected void ExecuteOptimistic (string type, string key, IModelObject obj, Func<bool, string> fn, IDbTransaction trans, Action<bool> audit = null)
        {
            int _r = ExecuteOverwrite (
                type,
                key,
                obj,
                fn,
                trans,
                audit
            );
            if (_r <= 0) { // Count of rows impacted -- we are expecting at least one row impacted.
                throw new OptimisticLockingException ($"Stamp recorded for '{type}' with ID '{obj.Id}' does not equal the stamp provided.");
            }
        }
        #endregion

        #region ExecuteOverwrite
        /// <summary>
        /// Execute an Overwrite Update or Insert for a given {obj}.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="model"></param>
        /// <param name="fn"></param>
        /// <param name="trans"></param>
        /// <param name="audit">Audit Function.</param>
        /// <returns></returns>
        protected int ExecuteOverwrite (string type, string key, IModelObject model, Func<bool, string> fn, IDbTransaction trans, Action<bool> audit = null)
        {
            int _rtn = 0; // Default to none.

            // ----------------------
            // Check whether this Entry already exists in the DB.
            // If it does we need to UPDATE otherwise we need to INSERT.
            // ----------------------
            bool _e = __Exists (type, key, model.Id);

            // Execute fn to get SQL statement to execute.
            // Pass in the exists flag.
            string _s = fn (_e);

            if (_s != null && _s.Length > 0) {

                using (IDbCommand _c = theConn.CreateCommand ()) {
                    _c.CommandText = _s;
                    _c.Transaction = trans;
                    _rtn = _c.ExecuteNonQuery ();
                }

                // ----------------------
                // If this is a new object, get its ID from the DB and sync that into the object.
                // ----------------------
                if (!_e) {
                    model.Id = __GetId (type, key, trans);
                }

                // If audit function exists then call it.
                if (audit != null) {
                    audit (_e);
                }

            }

            return _rtn;
        }
        #endregion

        #region ExecuteStatement
        /// <summary>
        /// Executes a SQL Statement.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="trans"></param>
        protected void ExecuteStatement (string sql, IDbTransaction trans = null)
        {
            using (IDbCommand _c = theConn.CreateCommand ()) {
                _c.CommandText = sql;
                if (trans != null) {
                    _c.Transaction = trans;
                }
                _c.ExecuteNonQuery ();
            }
        }
        #endregion
        #endregion

        #region Protected Operations
        /// <summary>
        /// Checks for the Table with the name {table} in the Database and if it
        /// doesn't exist, creates it.
        ///
        /// NB. This allows us to automatically roll a new table to insert business events
        /// into on a periodic basis. The method "RollingNameFor" on AbstractModelRepository
        /// performs the logic of determining what the period is and what the periodic name
        /// should be.
        /// </summary>
        /// <param name="table">Table Name to Check / Create</param>
        /// <param name="schema">Table Schema for table.</param>
        /// <param name="create">Operation to get the SQL Create statement for a new rolling table.</param>
        protected void CheckTable (string table, string schema, Func<string, string> create)
        {
            using (IDbCommand _c = theConn.CreateCommand ()) {
                _c.CommandText = $"SELECT table_name " +
                                 $"FROM information_schema.tables " +
                                 $"WHERE table_name = '{table}' " +
                                 $"AND table_schema = '{schema}';";
                using (IDataReader _r = _c.ExecuteReader ()) {
                    bool _tableFound = _r.Read ();
                    _r.Close ();
                    if (!_tableFound) {
                        _c.CommandText = create (table);
                        _c.ExecuteNonQuery ();
                        Logger.Warning ($"AbstractModelRepository created new table: '{table}'");
                    } else {
                        Logger.Debug ($"AbstractModelRepository found table: '{table}'");
                    }
                }
            }
        }
        #endregion

        #region Private Operations
        /// <summary>
        /// Tests whether a record of {type} with {id} exists or not
        /// and returns result.
        /// </summary>
        /// <param name="table">Table Name</param>
        /// <param name="key">Column Name</param>
        /// <param name="id">Id</param>
        /// <returns></returns>
        private bool __Exists (string table, string key, int id)
        {
            bool _rtn = false;

            // ----------------------
            // Check whether this Entry already exists in the DB.
            // If it does we need to UPDATE otherwise we need to INSERT.
            // ----------------------
            using (IDbCommand _c = theConn.CreateCommand ()) {
                _c.CommandText = __GetRelevantExists (table, key, id);
                using (IDataReader _r = _c.ExecuteReader ()) {
                    _rtn = _r.Read ();
                    _r.Close ();
                }
            }

            return _rtn;
        }

        /// <summary>
        /// Gets the latest ID for the given {type}.
        /// </summary>
        /// <param name="table">Table Name</param>
        /// <param name="key">Column Name</param>
        /// <param name="trans">DbTransaction</param>
        /// <returns></returns>
        private int __GetId (string table, string key, IDbTransaction trans)
        {
            int _rtn = ModelObject.NEW_ID;

            using (IDbCommand _c = theConn.CreateCommand ()) {

                _c.CommandText = $"SELECT LAST_INSERT_ID();";
                _c.Transaction = trans;

                using (IDataReader _r = _c.ExecuteReader ()) {
                    if (_r.Read ()) {
                        _rtn = _r.GetInt32 (0);
                    }
                    _r.Close ();
                }
            }

            return _rtn;
        }

        /// <summary>
        /// Returns EXIST SQL based on Database type
        /// </summary>
        /// <param name="table"></param>
        /// <param name="key"></param>
        /// <param name="id"></param>
        /// <returns>relevant SQL</returns>
        private string __GetRelevantExists (string table, string key, int id)
        {
            return $"SELECT * FROM `{table}` WHERE {key} = {id};";
        }
        #endregion
    }
}