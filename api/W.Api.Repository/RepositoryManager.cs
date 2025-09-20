//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       RepositoryManager.cs
//  Desciption: Repository Factory Manager
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using W.Api.Logging;
using W.Api.Exceptions;
using W.Api.Authorisation;
using W.Api.Model.Interfaces;
#endregion

namespace W.Api.Repository
{
    public class RepositoryManager : IModelManager
    {
        #region Protected Member Variables
        protected IDbConnection theConn = null;
        protected string theConnectionString = null;
        protected string theRdbms = null;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:MyTrucking.Core.Api.Repository.Database.DatabaseRepositoryManager"/> class.
        /// </summary>
        /// <param name="databaseRepo"></param>
        /// <param name="connectionString"></param>
        public RepositoryManager (string databaseRepo, string connectionString)
        {
            theConnectionString = connectionString;
            theRdbms = databaseRepo;
        }
        #endregion

        #region Open
        /// <summary>Opens repository instance.</summary>
        /// <exception cref="W.Api.Exceptions.DataSourceConnectionException">Could not connect to Respository Data Source. Is your connection string correct?</exception>
        public void Open ()
        {
            try {
                // Test that we can Open Connection.
                // If so create a new Repository instance to return.
                theConn = DbConnectionFactory.Create (theRdbms, theConnectionString);
                theConn.Open ();
            } catch (Exception __x) {
                throw new DataSourceConnectionException ("Could not connect to Respository Data Source. Is your connection string correct?", __x);
            }
        }
        #endregion

        #region Close
        public void Close ()
        {
            try {
                if ((theConn != null)
                    && !theConn.State.Equals (ConnectionState.Closed)) {
                    theConn.Close ();
                }
            } catch (Exception __x) {
                Logger.Error (__x);
            }
        }
        #endregion

        #region RepositoryFor
        /// <summary>Repositories Factory</summary>
        /// <typeparam name="T">Type to create</typeparam>
        /// <param name="subject">ClaimsSubject.</param>
        /// <returns>
        ///   Repository for given type
        /// </returns>
        public IModelRepository<T> RepositoryFor<T> (ClaimsSubject subject)
            where T : IModelObject
        {
            IModelRepository<T> _rtn = null;

            if (typeof (T).Equals (typeof (ITimeZone))) {
                _rtn = (IModelRepository<T>)new ObservationRepository (theConn, this, subject);

            } else if (typeof (T).Equals (typeof (IJurisdiction))) {
                _rtn = (IModelRepository<T>)new MetricRepository (theConn, this, subject);

            } else if (typeof (T).Equals (typeof (IContract))) {
                _rtn = (IModelRepository<T>)new TopicRepository (theConn, this, subject);

            } else if (typeof (T).Equals (typeof (IClient))) {
                _rtn = (IModelRepository<T>)new GroupRepository (theConn, this, subject);

            } else if (typeof (T).Equals (typeof (IOrganisation))) {
                _rtn = (IModelRepository<T>)new SourceRepository (theConn, this, subject);

            } else if (typeof (T).Equals (typeof (IResource))) {
                _rtn = (IModelRepository<T>)new SubjectRepository (theConn, this, subject);

            } else if (typeof (T).Equals (typeof (ILocation))) {
                _rtn = (IModelRepository<T>)new IdentityContextRepository (theConn, this, subject);

            }

            if (_rtn == null) {
                throw new MissingRepositoryException ("Failed to create repository for " + typeof (T).ToString ());
            }

            return _rtn;
        }
        #endregion

        #region Connection
        public IDbConnection Connection ()
        {
            return theConn;
        }
        #endregion

        #region Transaction Scoped Execution
        /// <summary>
        /// Executes the given Action method within a Database Transaction.
        /// </summary>
        /// <param name="fn"></param>
        public void Scoped (Action<IDbTransaction> fn)
        {
            Execute (() => {
                Exception _x = null;
                using (IDbTransaction _t = theConn.BeginTransaction ()) {
                    try {
                        fn (_t);
                        _t.Commit ();
                    } catch (Exception __x) {
                        _t.Rollback ();
                        _x = __x;
                    }
                }
                if (_x != null) {
                    // If an exception occured then the transaction will have been rolled-back.
                    // Re-throw the exception now that we are clear of the DbTransaction block.
                    throw _x;
                }
            });
        }
        #endregion

        #region Protected Operations
        /// <summary>
        /// Execute the specified fn.
        /// </summary>
        /// <returns>The execute.</returns>
        /// <param name="fn">Fn.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected T Execute<T> (Func<T> fn)
        {
            __CheckConnOpen ();
            return fn ();
        }

        /// <summary>
        /// Execute the specified Action without wrapping with a Transaction.
        /// </summary>
        /// <param name="fn">Fn.</param>
        protected void Execute (Action fn)
        {
            __CheckConnOpen ();
            fn ();
        }

        /// <summary>
        /// Combine two lists together. 
        /// </summary>
        /// <returns>The combine.</returns>
        /// <param name="target">Target.</param>
        /// <param name="source">Source.</param>
        /// <typeparam name="T0">The 1st type parameter.</typeparam>
        /// <typeparam name="T1">The 2nd type parameter.</typeparam>
        protected IList<T0> Combine<T0, T1> (IList<T0> target, IList<T1> source)
            where T1 : T0
        {
            foreach (T1 _s in source) {
                target.Add (_s);
            }
            return target;
        }
        #endregion

        #region Private Operations
        /// <summary>
        /// Checks the Databse Connection is Open.
        /// </summary>
        private void __CheckConnOpen (int wait = 100)
        {
            if (theConn.State.Equals (ConnectionState.Closed)) {
                theConn.Open ();
            } else if (theConn.State.Equals (ConnectionState.Executing)) {
                while (theConn.State.Equals (ConnectionState.Executing)) {
                    // Wait
                    Logger.Debug ($"Connection already Executing: Waiting for {wait} milliseconds...");
                    Thread.Sleep (wait);
                }
            }
        }
        #endregion
    }
}