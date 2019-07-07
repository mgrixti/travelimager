using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess {

    /// <summary>
    /// Data Access Object for TravelUserDetails and TravelUser Tables
    /// </summary>
    public class TravelUserDA : AbstractDA {

        #region fields
        // Data fields
        private const string fields = "Username,FirstName,LastName,Address,City,Region,Country,Postal,Phone,Email,Privacy";
        #endregion

        #region properties
        /// <summary>
        /// Getter for select statement
        /// </summary>
        protected override string SelectStatement {
            get {
                return "SELECT " + KeyFieldName + "," + fields
                    + " FROM TravelUserDetails"
                    + " INNER JOIN TravelUser ON (TravelUserDetails.UID = TravelUser.UID)";
            }
        }

        /// <summary>
        /// Getter for order fields
        /// </summary>
        protected override string OrderFields {
            get {
                return "FirstName";
            }
        }

        /// <summary>
        /// Getter for key field name
        /// </summary>
        protected override string KeyFieldName {
            get {
                return "TravelUser.UID";
            }
        }

        /// <summary>
        /// Updates user details for a particular user id
        /// </summary>
        /// <param name="id">a id</param>
        /// <param name="firstName">a firstName</param>
        /// <param name="lastName">a lastName</param>
        /// <param name="address">a address</param>
        /// <param name="city">a city</param>
        /// <param name="region">a region</param>
        /// <param name="country">a country</param>
        /// <param name="postal">a postal code</param>
        /// <param name="email">a email</param>
        /// <param name="privacy">a privacy</param>
        public void UpdateUserDetails(
            int id, string firstName, string lastName, string address,
            string city, string region, string country, string postal, string phone, string email, string privacy) {

            DbParameter[] parameters = new DbParameter[] {
                
            // Has to be in the correct order as the sql statement
              DataHelper.MakeParameter("@firstName", firstName, DbType.String),
              DataHelper.MakeParameter("@lastName", lastName, DbType.String),
              DataHelper.MakeParameter("@address", address, DbType.String),
              DataHelper.MakeParameter("@city", city, DbType.String),
              DataHelper.MakeParameter("@region", region, DbType.String),
              DataHelper.MakeParameter("@country", country ,DbType.String),
              DataHelper.MakeParameter("@postal", postal,DbType.String),
              DataHelper.MakeParameter("@phone", phone,DbType.String),    
              DataHelper.MakeParameter("@email", email,DbType.String),    
              DataHelper.MakeParameter("@privacy", privacy,DbType.String),
              DataHelper.MakeParameter("@id",id, DbType.Int32)
          };

            // Construct SQL
            string sql =
                "UPDATE TravelUserDetails"
                + " SET FirstName=@firstName,"
                + "LastName=@lastName,"
                + "Address=@address,"
                + "City=@city,"
                + "Region=@region,"
                + "Country=@country,"
                + "Postal=@postal,"
                + "Phone=@phone,"
                + "Email=@email,"
                + "Privacy=@privacy"
                + " WHERE TravelUserDetails.UID=@id";

            DataHelper.RunNonQuery(sql, parameters, CommandType.Text);
        }
        #endregion
    }
}