//----------------------------------------------------------------------------------------------------------
//  Product:    
//  File:       Stringifyer.cs
//  Desciption: 
//
//  (c) , 2022
//
//----------------------------------------------------------------------------------------------------------

#region Usings
using System;
using W.Api.Settings;
using W.Api.Exceptions;
using System.Globalization;
#endregion

namespace W.Api.Model
{
    public static class Stringifyer
    {
        #region Public Operations
        /// <summary>
        /// Gets the Time component of the given {dateTime} as a string.
        /// NB. Defaults to "00:00:00" if {dateTime} does not have a value.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyTime (this DateTime? dateTime)
        {
            string _rtn = Constants.Database.DEFAULT_TIME;
            if (dateTime.HasValue) {
                DateTime _d = dateTime.Value;
                _rtn = $"{__Prepend (_d.Hour)}:{__Prepend (_d.Minute)}:{__Prepend (_d.Second)}";
            }
            return _rtn;
        }

        /// <summary>
        /// Gets the Time of a given {time} as a string.
        /// NB. Defaults to "00:00:00" if {time} does not have a value.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string Stringify (this TimeOnly? time)
        {
            string _rtn = Constants.Database.DEFAULT_TIME;
            if (time.HasValue) {
                TimeOnly _t = time.Value;
                _rtn = $"{__Prepend (_t.Hour)}:{__Prepend (_t.Minute)}:{__Prepend (_t.Second)}";
            }
            return _rtn;
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in ISO8601 format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyISO8601 (this DateTime? dateTime)
        {
            DateTime _rtn = DateTime.MinValue;
            if (dateTime.HasValue) {
                _rtn = dateTime.Value;
            }
            return $"{_rtn.Year}-{__Prepend (_rtn.Month)}-{__Prepend (_rtn.Day)}"
                 + $"T{__Prepend (_rtn.Hour)}:{__Prepend (_rtn.Minute)}:{__Prepend (_rtn.Second)}";
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in ISO8601 format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyISO8601 (this DateTime dateTime)
        {
            return $"{dateTime.Year}-{__Prepend (dateTime.Month)}-{__Prepend (dateTime.Day)}"
                 + $"T{__Prepend (dateTime.Hour)}:{__Prepend (dateTime.Minute)}:{__Prepend (dateTime.Second)}";
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in MySQL format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyANSI (this DateTime? dateTime)
        {
            DateTime _rtn = DateTime.MinValue;
            if (dateTime.HasValue) {
                _rtn = dateTime.Value;
            }
            return $"{_rtn.Year}-{__Prepend (_rtn.Month)}-{__Prepend (_rtn.Day)} "
                 + $"{__Prepend (_rtn.Hour)}:{__Prepend (_rtn.Minute)}:{__Prepend (_rtn.Second)}";
        }

        /// <summary>
        /// Gets the Date component of the given {dateTime} as a string in MySQL format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyANSIDateOnly (this DateTime? dateTime)
        {
            DateTime _rtn = DateTime.MinValue;
            if (dateTime.HasValue) {
                _rtn = dateTime.Value;
            }
            return $"{_rtn.Year}-{__Prepend (_rtn.Month)}-{__Prepend (_rtn.Day)}";
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in MySQL format.
        /// NB. Defaults to DateTime.MinValue.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyANSI (this DateTime dateTime)
        {
            return $"{dateTime.Year}-{__Prepend (dateTime.Month)}-{__Prepend (dateTime.Day)} "
                 + $"{__Prepend (dateTime.Hour)}:{__Prepend (dateTime.Minute)}:{__Prepend (dateTime.Second)}";
        }

        /// <summary>
        /// Gets the Date component of the given {dateTime} as a string in MySQL format.
        /// NB. Defaults to "null" text.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyANSIAndQuoteIfNotNull (this DateTime? dateTime)
        {
            string _rtn = "null";
            if (dateTime != null && dateTime.HasValue) {
                _rtn = $"'{StringifyANSI (dateTime.Value)}'";
            }
            return _rtn;
        }

        /// <summary>
        /// Stringify Integer
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string StringifyANSI (this int? number)
        {
            string _rtn = "null";
            if (number != null && number.HasValue) {
                _rtn = number.ToString ();
            }
            return _rtn;
        }

        /// <summary>
        /// Stringify Decimal
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string StringifyANSI (this decimal? number)
        {
            string _rtn = "null";
            if (number != null && number.HasValue) {
                _rtn = number.ToString ();
            }
            return _rtn;
        }

        /// <summary>
        /// Quote a Text String if it is not null, otherwise return text "null".
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string QuoteIfNotNull (this string text)
        {
            string _rtn = "null";
            if (text != null) {
                _rtn = $"'{text}'";
            }
            return _rtn;
        }

        /// <summary>
        /// Gets the given {dateTime} as a string in a format useful for a Rolling Table Name.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string StringifyRollingName (this DateTime dateTime)
        {
            return $"{dateTime.Year}_{__Prepend (dateTime.Month)}";
        }

        /// <summary>
        /// Escapes a given {text} string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Escape (this string text)
        {
            return text.Replace ("'", "''");
        }

        /// <summary>
        /// Escapes a given {text} string so that it can be saved to a RDBMS safely.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string EscapeSafely (this string text)
        {
            return (text != null) ? Escape (text) : string.Empty;
        }
        #endregion

        #region Private Operations
        /// <summary>
        /// Converts int to string with a prepended "0" ahead of any value 0 <= {value} <= 9.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static string __Prepend (int value)
        {
            if (value < 0) {
                throw new BusinessRuleException ("Time component value cannot be less than 0");
            }
            string _v = value <= 9 ? "0" : string.Empty;
            return $"{_v}{value}";
        }
        #endregion
    }
}