//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       DbHelper.cs
//  Desciption: Data Reader helper methods
//
//  (c) , 2025
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using System.Data;
#endregion

namespace W.Api.Repository
{
    /// <summary>
    ///  Helper class for dealing with nullables
    /// </summary>
    public static class DbHelper
    {
        #region GetDate
        /// <summary>Gets the date.</summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static DateTime? SafeGetDate (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? null : dr.GetDateTime (_x);
        }

        /// <summary>
        /// Gets the Time.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static TimeOnly? SafeGetTime (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            TimeOnly? _rtn = null;
            if (!dr.IsDBNull (_x)) {
                string _time = dr.GetString (_x);
                string [] _T = _time.Split (":");
                int _h = int.Parse (_T [0]);
                int _m = int.Parse (_T [1]);
                int _s = int.Parse (_T [2]);
                _rtn = new TimeOnly (_h, _m, _s);
            }
            return _rtn;
        }

        /// <summary>
        /// Gets the Timestamp
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static DateTime SafeGetTimestamp (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? DateTime.MinValue : dr.GetDateTime (_x);
        }
        #endregion

        #region GetBoolean
        /// <summary>Gets the boolean.</summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool SafeGetBoolean (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? false : dr.GetBoolean (_x);
        }

        /// <summary>Gets the boolean.</summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool? SafeGetNullableBoolean (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? null : dr.GetBoolean (_x);
        }
        #endregion

        #region GetInt32
        /// <summary>Gets the int32.</summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int SafeGetInt32 (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? 0 : dr.GetInt32 (_x);
        }

        /// <summary>Gets the int32.</summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static int? SafeGetNullableInt32 (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? null : dr.GetInt32 (_x);
        }
        #endregion

        #region GetString
        /// <summary>Gets the string.</summary>
        /// <param name="dr">The dr.</param>
        /// <param name="column">The column.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static string SafeGetString (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? string.Empty : dr.GetString (_x);
        }
        #endregion

        #region GetDecimal
        /// <summary>
        /// Gets the decimal.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static decimal SafeGetDecimal (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? 0.0M : dr.GetDecimal (_x);
        }

        /// <summary>
        /// Gets the decimal.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static decimal? SafeGetNullableDecimal (this IDataReader dr, string column)
        {
            int _x = dr.GetOrdinal (column);
            return dr.IsDBNull (_x) ? null : dr.GetDecimal (_x);
        }
        #endregion
    }
}