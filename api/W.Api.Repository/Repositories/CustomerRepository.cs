//----------------------------------------------------------------------------------------------------------
//  Product:    Work Management SystemMyTruckingWebAPI
//  File:       CustomerRepository.cs
//  Desciption: Customer data layer 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

using MyTrucking.Core.Api.Model;
using MyTrucking.Core.Api.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;


// todo - think this file needs to be deleted....

namespace MyTrucking.Core.Api.Repository
{
    /// <summary>
    ///   <br />
    /// </summary>
    /// TODO Edit XML Comment Template for CustomerRepository
    public class CustomerRepository : AbstractModelRepository, IModelRepository<ICustomer>
    {

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="CustomerRepository" /> class.</summary>
        /// <param name="conn">DB Connection</param>
        /// <param name="manager">Model Manager.</param>
        /// TODO Edit XML Comment Template for #ctor
        public CustomerRepository(IDbConnection conn, IModelManager manager)
            : base(conn, manager)
        {
        }
        #endregion

        #region Read
        /// <summary>Reads the specified identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// TODO Edit XML Comment Template for Read
        public ICustomer Read(int id)
        {
            return Query(
                $"SELECT * FROM Customer WHERE CustomerID = {id};",
                (r) =>
                {
                    ICustomer _rtn = null;
                    if (r.Read())
                    {
                        _rtn = new Customer(theManager)
                        {
                            Id = r.GetInt32(0),
                      
                            Description = r.GetString(2)
                        };
                    }
                    return _rtn;
                }
            );
        }
        #endregion

        public IList<ICustomer> ReadAll()
        {
            return QueryAll(
                $"SELECT * FROM Customer;",
                (r) =>
                {
                    IList<ICustomer> _rtn = new List<ICustomer>();
                    while (r.Read())
                    {
                        _rtn.Add(
                            new Customer(theManager)
                            {
                                Id = r.GetInt32(0),
                              
                                Description = r.GetString(2)
                            }
                        );
                    }
                    return _rtn;
                }
            );
        }

        /// <summary>Reads the where.</summary>
        /// <param name="clause">The clause.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        /// TODO Edit XML Comment Template for ReadWhere
        public IList<ICustomer> ReadWhere(string clause)
        {
            return QueryAll(
                $"SELECT * FROM Customer WHERE {clause};",
                (r) =>
                {
                    IList<ICustomer> _rtn = new List<ICustomer>();
                    while (r.Read())
                    {
                        _rtn.Add(
                            new Customer(theManager)
                            {
                                Id = r.GetInt32(0),
                             
                                Description = r.GetString(2)
                            }
                        );
                    }
                    return _rtn;
                }
            );
        }

        public ICustomer Upsert(ICustomer model, IDbTransaction trans)
        {
            ExecuteOptimistic(
                "Customer",
                "CustomerId",
                model,
                (exists) =>
                {
                    //---------------------------------------------------------
                    // NB. We are not using OdbcParameters here because for
                    // some reason String values get translated as zero-length (blank) strings...
                    //---------------------------------------------------------
                    string _sql = string.Empty;
                    // Optimistic Locking:
              
                    // Create SQL Statement:
                    if (exists)
                    { // UPDATE statement
                        _sql = $"UPDATE Customer SET "
                       
                           + $"description = '{Escape(model.Description)}' "
                           + $"WHERE CustomerID = {model.Id} ;";
                    }
                    else
                    { // INSERT statement
                        _sql = $"INSERT INTO Customer "
                           + $"( description) "
                           + $"VALUES "
                           + $"( '{Escape(model.Description)}');";
                    }
                    return _sql;
                },
                trans
            );
            return model; // Customer ID will have been given in ExecuteOptimitic () if the customer is new.
        }

        public void Remove(ICustomer model, IDbTransaction trans)
        {
            Delete(
                "Customer",
                $"CustomerID = {model.Id}",
                trans
            );
        }

    }
}