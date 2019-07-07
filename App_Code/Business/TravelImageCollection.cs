using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a collection of TravelImage objects
    /// </summary>
    public class TravelImageCollection : AbstractBusinessCollection<TravelImage> {

        #region fields
        // Data access fields
        private TravelImageDA _da = new TravelImageDA();
        #endregion

        #region methods
        /// <summary>
        /// Fetches the TravelImage collection data
        /// </summary>
        public void FetchAll() {
            DataTable dt = _da.GetAll();
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches the TravelImage collection data sorted
        /// </summary>
        /// <param name="ascending">a true false value</param>
        public void FetchAllSorted(bool ascending) {
            DataTable dt = _da.GetAllSorted(ascending);
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the TravelImages with a given id. This should normally create a collection
        /// with either 0 or 1 TravelImages. This way the single TravelImage can be data binded to a data control.
        /// </summary>
        /// <param name="id">a id</param>
        public void FetchForId(int id) {
            DataTable dt = _da.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches the top X TravelImages 
        /// </summary>
        /// <param name="howMany">a number indicating howMany</param>
        /// <param name="ascending">a true false value</param>
        public void FetchTop(int howMany,bool ascending) {
            DataTable dt = _da.GetTop(howMany, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches TravelImages for post
        /// </summary>
        /// <param name="postID">a postID</param>
        public void FetchForPost(int postID) {
            DataTable dt = _da.GetForPost(postID);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches TravelImages for user
        /// </summary>
        /// <param name="userID">a userID</param>
        public void FetchForUser(int userID) {
            DataTable dt = _da.GetForUser(userID);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches TravelImages for city
        /// </summary>
        /// <param name="geoNameID">a geoNameID</param>
        public void FetchForCity(int geoNameID, bool ascending) {
            DataTable dt = _da.GetForCity(geoNameID, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches TravelImages for country
        /// </summary>
        /// <param name="iso">a iso</param>
        public void FetchForCountry(string iso, bool ascending) {
            DataTable dt = _da.GetForCountry(iso, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches TravelImages for continent
        /// </summary>
        /// <param name="continentCode">a continentCode</param>
        public void FetchForContinent(string continentCode, bool ascending) {
            DataTable dt = _da.GetForContinent(continentCode,ascending);
            PopulateFromDataTable(dt);
        }

        // <summary>
        /// Fetches TravelImages like title
        /// <param name="title">a title</param>
        /// <param name="ascending">a true false value</param>
        public void FetchLikeTitle(string title,bool ascending) {
            DataTable dt = _da.GetLikeTitle(title, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches the top X rated TravelImages 
        /// </summary>
        /// <param name="howMany">a number indicating howMany</param>
        /// <param name="ascending">a true false value</param>
        public void FetchTopRated(int howMany) {
            DataTable dt = _da.GetTopRated(howMany);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Populates a TravelImageCollection
        /// </summary>
        /// <param name="dt">a dt</param>
        private void PopulateFromDataTable(DataTable dt) {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows) {
                TravelImage image = new TravelImage();
                image.PopulateDataMembersFromDataRow(row);
                AddToCollection(image);
            }
        }

        /// <summary>
        /// Gets collection in string format
        /// </summary>
        /// <returns>String object</returns>
        public string AsCommaList {
            get {
                string commas = "";
                foreach (TravelImage image in this) {
                    if (commas.Length > 0) commas += ", ";
                    commas += image.Id + ".jpg";
                }
                return commas;
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns>TravelImageCollection object</returns>
        public static TravelImageCollection GetAll() {
            TravelImageCollection list = new TravelImageCollection();
            list.FetchAll();
            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        public TravelImageCollection Clone() {
            TravelImageCollection clone = new TravelImageCollection();
            foreach (TravelImage image in this) {
                clone.Add(image.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}