//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       IDatabaseManager.cs
//  Desciption: 
//
//  (c) , 2025
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