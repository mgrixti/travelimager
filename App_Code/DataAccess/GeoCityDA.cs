using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess {
    
    /// <summary>
    /// Data Access Object for GeoCity Table
    /// </summary>
    public class GeoCityDA : AbstractDA {

        #region fields
        // Data fields
        private const string fields = "AsciiName,CountryCodeISO,Latitude,Longitude,Population,Elevation";
        #endregion

        #region properties
        /// <summary>
        /// Getter for select statement
        /// </summary>
        protected override string SelectStatement {
            get {
                return "SELECT " + KeyFieldName + "," + fields 
                    + " FROM GeoCities";
            }
        }

        /// <summary>
        /// Getter for order fields
        /// </summary>
        protected override string OrderFields {
            get {
                return "AsciiName";
            }
        }

        /// <summary>
        /// Getter for key field name
        /// </summary>
        protected override string KeyFieldName {
            get {
                return "GeoNameID";
            }
        }

        /// <summary>
        ///  Returns a data table containing GeoCity table info when a particular city has images.
        /// </summary>
        /// <returns>DataTable object</returns>
        public DataTable GetWhenImages() {
            // set up  query statement
            string sql = SelectStatement
                + " WHERE " + KeyFieldName + " IN (SELECT CityCode FROM TravelImageDetails)"
                + " ORDER BY " + OrderFields;
            // return result
            return DataHelper.GetDataTable(sql, null);
        }

        /// <summary>
        /// Returns a data table containing GeoCity table info that is similar to this name.
        /// </summary>
        public DataTable GetLikeName(string name, bool ascending) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (GeoCities.AsciiName LIKE @name)"
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