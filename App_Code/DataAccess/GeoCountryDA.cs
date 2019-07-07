using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess {

    /// <summary>
    /// Data Access Object for GeoCountry Table
    /// </summary>
    public class GeoCountryDA : AbstractDA {

        #region fields
        // Data fields
        private const string fields = "CountryName,Capital,Area,Population,CurrencyCode,CountryDescription";
        #endregion

        #region properties
        /// <summary>
        /// Getter for a select statement
        /// </summary>
        protected override string SelectStatement {
            get {
                return "SELECT " + KeyFieldName + "," + fields 
                    + " FROM GeoCountries";
            }
        }

        /// <summary>
        /// Getter for order fields
        /// </summary>
        protected override string OrderFields {
            get {
                return "CountryName";
            }
        }

        /// <summary>
        /// Getter for key field name
        /// </summary>
        protected override string KeyFieldName {
            get {
                return "ISO";
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Returns a data table containing GeoCountry table info for this exact iso.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        /// <param name="iso">a iso</param>
        /// <returns>DataTable object</returns>
        public DataTable GetById(string iso) {
            // set up parameterized query statement
            string sql = SelectStatement 
                + " WHERE (ISO = @iso)";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@iso", iso, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        ///  Returns a data table containing GeoCountry table info when a particular country has images.
        /// </summary>
        /// <returns>DataTable object</returns>
        public DataTable GetWhenImages() {
            // set up  query statement
            string sql = SelectStatement
                + " WHERE ISO IN (SELECT CountryCodeISO FROM TravelImageDetails) "
                + " ORDER BY " + OrderFields;
            // return result
            return DataHelper.GetDataTable(sql, null);
        }

        /// <summary>
        /// Returns a data table containing GeoCountry table info that is similar to this name.
        /// </summary>
        public DataTable GetLikeName(string name, bool ascending) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (GeoCountries.CountryName LIKE @name)"
                + " ORDER BY "
                + OrderFields;
            if (!ascending)
                sql += " DESC";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@name", name, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
        #endregion

    }
}