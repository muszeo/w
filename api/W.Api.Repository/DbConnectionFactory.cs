//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       DbConnectionFactory.cs
//  Desciption: Database connection factory
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using W.Api.Settings;
using Npgsql;
using System;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace W.Api.Repository
{
    public class DbConnectionFactory
    {
        #region Constructor
        /// <summary>Creates the specified RDBMS.</summary>
        /// <param name="rdbms">The RDBMS.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentException">Missing connection RDMS</exception>
        public static IDbConnection Create (string rdbms, string connectionString)
        {

            IDbConnection _rtn = null;

            switch (rdbms) {

                case Constants.Repositories.MYSSQL:
                    _rtn = new MySql.Data.MySqlClient.MySqlConnection (connectionString);
                    break;

                case Constants.Repositories.SQLSERVER:
                    _rtn = new SqlConnection (connectionString);
                    break;

                case Constants.Repositories.POSTGRES:
                    _rtn = new NpgsqlConnection (connectionString);
                    break;

                default: throw new ArgumentException ("Missing connection RDMS");
                    // TODOO - add custom exception

            }

            return _rtn;
        }
        #endregion

        #region Create
        /// <summary>Creates the specified RDBMS.</summary>
        /// <param name="rdbms">The RDBMS.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// <exception cref="System.ArgumentException">Missing connection RDMS</exception>
        public static IDbConnection Create (string rdbms)
        {
            IDbConnection _rtn = null;

            switch (rdbms) {

                case Constants.Repositories.MYSSQL:
                    _rtn = new MySql.Data.MySqlClient.MySqlConnection ();
                    break;

                case Constants.Repositories.SQLSERVER:
                    _rtn = new SqlConnection ();
                    break;

                case Constants.Repositories.POSTGRES:
                    _rtn = new NpgsqlConnection ();
                    break;

                default: throw new ArgumentException ("Missing connection RDMS");
                    // TODOO - add custom exception

            }

            return _rtn;
        }
        #endregion
    }
}