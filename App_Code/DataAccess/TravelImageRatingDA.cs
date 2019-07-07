using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess {

    /// <summary>
    /// Data Access Object for Travel Image Rating Table
    /// </summary>
    public class TravelImageRatingDA : AbstractDA {

        #region fields
        // Data fields
        private const string fields = "ImageID,Rating,ReviewDate,Comment,UserName";
        #endregion

        #region properties
        /// <summary>
        /// Getter for select statement
        /// </summary>
        protected override string SelectStatement {
            get {
                return "SELECT " + KeyFieldName + "," + fields
                    + " FROM TravelImageRating";
            }
        }

        /// <summary>
        /// Getter for order fields
        /// </summary>
        protected override string OrderFields {
            get {
                return "ReviewDate";
            }
        }

        /// <summary>
        /// Getter for key field name
        /// </summary>
        protected override string KeyFieldName {
            get {
                return "ImageRatingID";
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Returns a data table containing the top X rated records (based on the sort order).
        /// 
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public override DataTable GetTop(int howMany, bool ascending) {
            
            // set up parameterized query statement
            string newSql = "SELECT TOP " + howMany + " * FROM (" + SelectStatement;
            newSql += " ORDER BY " + KeyFieldName;

            if (!ascending)
                newSql += " DESC";
            newSql += ")";
            // return result
            return DataHelper.GetDataTable(newSql, null);
        }

        /// <summary>
        /// Returns a data table containing TravelImageRating table info for this exact imageID.
        /// If a review was inserted.
        /// </summary>
        public DataTable GetForImage(int imageID) {
            // set up parameterized query statement
            // Return Image Rating Table If Review Was Entered
            string sql = SelectStatement
                + " WHERE (ImageID = @imageID)"
                + " ORDER BY "
                + OrderFields;
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@imageID", imageID, DbType.Int32)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Inserts review data into TravelImageRating table 
        /// </summary>
        /// <param name="imageID">a imageID</param>
        /// <param name="rating">a rating</param>
        /// <param name="dateTime">a dateTime</param>
        /// <param name="comment">a comment</param>
        /// <param name="userName">a userName</param>
        /// <returns>int imageRatingID</returns>
        public int InsertImageRating(int imageID, int rating, string reviewDate, string comment, string userName) {

            // Construct parameters
            DbParameter[] parameters = new DbParameter[] {
              DataHelper.MakeParameter("@imageID", imageID, DbType.Int32),
              DataHelper.MakeParameter("@rating", rating, DbType.Int32),
              DataHelper.MakeParameter("@reviewDate", reviewDate,DbType.DateTime),
              DataHelper.MakeParameter("@comment", comment,DbType.String),
              DataHelper.MakeParameter("@userName", userName, DbType.String),  
          };

            // Construct SQL
            string sql = "INSERT INTO TravelImageRating (ImageID,Rating,ReviewDate,Comment,UserName)"
            + " VALUES (@imageID,@rating,@reviewDate,@comment,@userName)";

            // Retrieve newly added review's image rating id
            int imageRatingID = DataHelper.RunNonQuery(sql, parameters, CommandType.Text, true);
            return imageRatingID;
        }

        /// <summary>
        /// Delete a TravelImageRating by Id
        /// </summary>
        /// <param name="imageRatingID">a imageRatingID</param>
        public void DeleteById(int imageRatingID) {
            string sql = "DELETE FROM TravelImageRating WHERE ImageRatingID = @imageRatingID";

            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@imageRatingID",imageRatingID, DbType.Int32)
			};
            DataHelper.RunNonQuery(sql, parameters, CommandType.Text);
        }
        #endregion
    }
}