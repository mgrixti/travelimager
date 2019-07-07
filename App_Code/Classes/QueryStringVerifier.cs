using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace Classes.Helper {
    /// <summary>
    /// Verifies that a query string is not empty. Takes in a string parameter of type to 
    /// verify whether the parameter is an int or a string
    /// use "int" for int, and "string" for string
    /// </summary>
    public static class QueryStringVerifier {
        public static readonly int GEOCOUNTRY_ISO_LENGTH = 2;

        public static bool IsNotNull(string queryStringVal) {
            return (!String.IsNullOrEmpty(queryStringVal));
        }

        public static bool IsNumber(string queryStringVal) {
            int val = 0;
            return Int32.TryParse(queryStringVal, out val);
        }

        public static bool IsNumberAndIsNotNull(string queryStringVal) {
            return (IsNumber(queryStringVal) && IsNotNull(queryStringVal));
        }

        public static bool IsValidISO(string queryStringVal) {
            return (queryStringVal.Length == GEOCOUNTRY_ISO_LENGTH && !IsNumber(queryStringVal));
        }

        public static bool IsValidISOAndIsNotNull(string queryStringVal) {
            return (IsNotNull(queryStringVal) && IsValidISO(queryStringVal));
        }

    }
}