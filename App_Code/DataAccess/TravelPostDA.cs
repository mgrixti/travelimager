using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess {

    /// <summary>
    /// Data Access Object for Travel Post Table
    /// </summary>
    public class TravelPostDA : AbstractDA {

        #region fields
        // Data fields
        private const string fields =
            "TravelUserDetails.FirstName,"
            + "TravelUserDetails.LastName,"
            + "TravelPost.UID,"
            + "TravelPost.Title,"
            + "TravelPost.Message,"
            + "TravelPost.PostTime";
        #endregion

        #region properties
        /// <summary>
        /// Getter for select statement
        /// </summary>
        protected override string SelectStatement {
            get {
                return "SELECT " + KeyFieldName + "," + fields
                    + " FROM ((TravelUser" 
                    + " INNER JOIN TravelPost ON (TravelUser.UID = TravelPost.UID))"
                    + " INNER JOIN TravelUserDetails ON (TravelPost.UID = TravelUserDetails.UID) AND (TravelUser.UID = TravelUserDetails.UID))";
            }
        }

        /// <summary>
        /// Getter for order fields
        /// </summary>
        protected override string OrderFields {
            get {
                return "TravelPost.Title";
            }
        }

        /// <summary>
        /// Getter for key field name
        /// </summary>
        protected override string KeyFieldName {
            get {
                return "TravelPost.PostID";
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Returns a data table containing TravelPost table info for this exact userID.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForUser(int userID) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (TravelUser.UID = @userID)" 
                + " ORDER BY "
                + OrderFields;
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@userID", userID, DbType.Int32)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing TravelPost table info that is similar to this title.
        /// </summary>
        public DataTable GetLikeTitle(string title, bool ascending) {
            // set up parametrized query statement
            string sql = SelectStatement
                + " WHERE (TravelPost.Title LIKE @title)" + 
                " ORDER BY "
                + OrderFields;
            if (!ascending)
                sql += " DESC";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@title", title + "%", DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
        #endregion

    }
}