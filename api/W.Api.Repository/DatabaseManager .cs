//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       DatabaseManager.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using W.Api.Repository.Interfaces;
using System.Data;
#endregion

namespace W.Api.Repository
{
    public class DatabaseManager : IDatabaseManager
    {
        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="DatabaseManager" /> class.</summary>
        public DatabaseManager ()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="DatabaseManager" /> class.</summary>
        /// <param name="connectionString">The Connection String.</param>
        /// <param name="name">The Name.</param>
        /// <param name="schema">The Table Schema.</param>
        public DatabaseManager (string connectionString, string name, string schema)
        {
            ConnectionString = connectionString;
            Name = name;
            Schema = schema;
        }
        #endregion

        #region Attributes 
        public string Name { get; set; }
        public string ConnectionString { get; set; }
        public string Schema { get; set; }
        public IDbConnection Connection { get; set; }
        #endregion
    }
}