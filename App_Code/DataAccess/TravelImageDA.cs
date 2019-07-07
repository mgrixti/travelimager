using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess {

    /// <summary>
    /// Data Access Object for TravelImage Table
    /// </summary>
    public class TravelImageDA : AbstractDA {

        #region fields
        // Data fields
        private const string fields = "TravelImage.Path,"
                    + "TravelUser.UID,"
                    + "TravelUserDetails.FirstName,"
                    + "TravelUserDetails.LastName,"
                    + "TravelImageDetails.Title,"
                    + "TravelImageDetails.Description,"
                    + "TravelImageDetails.Latitude,"
                    + "TravelImageDetails.Longitude,"
                    + "TravelPost.PostID,"
                    + "TravelPost.Title AS PostTitle,"
                    + "GeoCities.GeoNameID,"
                    + "GeoCities.AsciiName,"
                    + "GeoCountries.ISO,"
                    + "GeoCountries.CountryName,"
                    + "Ratings.RatingCount,"
                    + "Ratings.RatingAverage";
        // Required for multiple joins in access queries
        #endregion

        #region properties
        /// <summary>
        /// Getter for select statement
        /// </summary>
        protected override string SelectStatement {
            get {
                return "SELECT " + KeyFieldName + "," + fields
                    + " FROM (((((((((TravelImage"
                    + " LEFT OUTER JOIN"
                    + " (SELECT ImageID,COUNT(Rating) AS RatingCount,ROUND(AVG(Rating),1) AS RatingAverage FROM TravelImageRating GROUP BY ImageID) AS Ratings ON (Ratings.ImageID = TravelImage.ImageID))"
                    + " INNER JOIN TravelImageDetails ON (TravelImageDetails.ImageID = TravelImage.ImageID))"
                    + " INNER JOIN TravelPostImages ON (TravelPostImages.ImageID = TravelImage.ImageID))"
                    + " INNER JOIN TravelPost ON (TravelPostImages.PostID = TravelPost.PostID))"
                    + " INNER JOIN TravelUser ON (TravelUser.UID = TravelImage.UID))"
                    + " INNER JOIN TravelUserDetails ON (TravelUser.UID = TravelUserDetails.UID))"
                    + " LEFT OUTER JOIN GeoCities ON (GeoCities.GeoNameID = TravelImageDetails.CityCode))"
                    + " INNER JOIN GeoCountries ON (GeoCountries.ISO = TravelImageDetails.CountryCodeISO))"
                    + " INNER JOIN GeoContinents ON (GeoContinents.ContinentCode = GeoCountries.Continent))";
            }
        }

        /// <summary>
        /// Getter for order fields
        /// </summary>
        protected override string OrderFields {
            get {
                return "TravelImageDetails.Title";
            }
        }

        /// <summary>
        /// Getter for key field name
        /// </summary>
        protected override string KeyFieldName {
            get {
                return "TravelImage.ImageID";
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Returns a data table containing the top X rated records (based on the sort order).
        /// 
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetTopRated(int howMany) {
            // set up parameterized query statement
            string topSql = "SELECT TOP " + howMany + " * FROM (" + SelectStatement;
            topSql += " ORDER BY Ratings.RatingAverage";
            topSql += " DESC";
            topSql += ")";
            // return result
            return DataHelper.GetDataTable(topSql, null);
        }

        /// <summary>
        /// Returns a data table containing the top X rated records (based on the sort order).
        /// 
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public override DataTable GetTop(int howMany,bool ascending) {
            // set up parameterized query statement
            string newSql = "SELECT TOP " + howMany + " * FROM (" + SelectStatement;
            newSql += " ORDER BY " + KeyFieldName;
            
            if(!ascending)
                newSql += " DESC";
            newSql += ")";
            // return result
            return DataHelper.GetDataTable(newSql, null);
        }

        /// <summary>
        /// Returns a data table containing TravelImage and TravelImageDetails table info for Post.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForPost(int postID) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (TravelPost.PostID = @postID)"
                + " ORDER BY "
                + OrderFields;
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@postID", postID, DbType.Int32)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing TravelImage and TravelImageDetails table info for User.
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
        /// Returns a data table containing TravelImage table info for City.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForCity(int geoNameID, bool ascending) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (GeoCities.GeoNameID = @geoNameID)"
                + " ORDER BY "
                + OrderFields;
            if (!ascending)
                sql += " DESC";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@geoNameID", geoNameID, DbType.Int32)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing TravelImage table info for Country.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForCountry(string iso, bool ascending) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (GeoCountries.ISO = @iso)"
                + " ORDER BY "
                + OrderFields;
            if (!ascending)
                sql += " DESC";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@iso", iso, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing TravelImage table info for Continent.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetForContinent(string countryCode, bool ascending) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (GeoContinents.ContinentCode = @countryCode)"
                + " ORDER BY "
                + OrderFields;
            if (!ascending)
                sql += " DESC";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@countryCode", countryCode, DbType.String)
			};

            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing TravelImage table info that is similar to this title.
        /// </summary>
        public DataTable GetLikeTitle(string title, bool ascending) {
            // set up parameterized query statement
            string sql = SelectStatement
                + " WHERE (TravelImageDetails.Title LIKE @title)"
                + " ORDER BY "
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