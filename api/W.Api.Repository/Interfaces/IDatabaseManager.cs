//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management System
//  File:       IDatabaseManager.cs
//  Desciption: 
//
//  (c) Martin James Hunter, 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System.Data;
#endregion

namespace W.Api.Repository.Interfaces
{
    public interface IDatabaseManager
    {
        #region Attributes
        string Name { get; }
        string ConnectionString { get; }
        IDbConnection Connection { set; get; }
        #endregion
    }
}