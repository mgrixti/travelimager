using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess {

    /// <summary>
    /// Data Access Object for GeoContinent Table
    /// </summary>
    public class GeoContinentDA : AbstractDA {

        #region fields
        // Data fields
        private const string fields = "ContinentName";
        #endregion

        #region properties
        /// <summary>
        /// Getter for select statement
        /// </summary>
        protected override string SelectStatement {
            get {
                return "SELECT " + KeyFieldName + "," + fields 
                    + " FROM GeoContinents";
            }
        }

        /// <summary>
        /// Getter for order fields
        /// </summary>
        protected override string OrderFields {
            get {
                return "ContinentName";
            }
        }

        /// <summary>
        /// Getter for key field name
        /// </summary>
        protected override string KeyFieldName {
            get {
                return "ContinentCode";
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Returns a data table containing GeoContinent table info for this exact continent code.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        /// <param name="continentCode">a continentCode</param>
        /// <returns>DataTable object</returns>
        public DataTable GetById(string continentCode) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (ContinentCode = @continentCode)";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@continentCode", continentCode, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
        #endregion

    }
}