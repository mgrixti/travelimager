using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business {
    
    /// <summary>
    /// Represents a collection of TravelImageRating objects.
    /// </summary>
    public class TravelImageRatingCollection : AbstractBusinessCollection<TravelImageRating> {

        #region fields
        // Data access fields
        private TravelImageRatingDA _da = new TravelImageRatingDA();
        #endregion

        #region methods
        /// <summary>
        /// Fetches the TravelImageRating collection data
        /// </summary>
        public void FetchAll() {
            DataTable dt = _da.GetAll();
            PopulateFromDataTable(dt);
            _isNew = false;
        }

         /// <summary>
        /// Fetches the TravelImageRating data sorted
        /// </summary>
        /// <param name="ascending">a true false value</param>
        public void FetchAllSorted(bool ascending) {
            DataTable dt = _da.GetAllSorted(ascending);
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches all the TravelImageRatings with a given id. This should normally create a collection
        /// with either 0 or 1 TravelImageRatings. This way the single TravelImageRating can be data binded to a data control.
        /// </summary>
        /// <param name="id">a id</param>
        public void FetchForId(int id) {
            DataTable dt = _da.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches the top X TravelImageRatings
        /// </summary>
        /// <param name="howMany">a number indicating howMany</param>
        /// <param name="ascending">a true false value</param>
        public void FetchTop(int howMany, bool ascending) {
            DataTable dt = _da.GetTop(howMany, ascending);
            PopulateFromDataTable(dt);
        }

        public void FetchForImage(int imageID) {
            DataTable dt = _da.GetForImage(imageID);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Populates a TravelImageRatingCollection
        /// </summary>
        /// <param name="dt">a dt</param>
        private void PopulateFromDataTable(DataTable dt) {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows) {
                TravelImageRating rating = new TravelImageRating();
                rating.PopulateDataMembersFromDataRow(row);
                AddToCollection(rating);
            }
        }

        /// <summary>
        /// Gets collection in string format
        /// </summary>
        /// <returns>String object</returns>
        public string AsCommaList {
            get {
                string commas = "";
                foreach (TravelImageRating rating in this) {
                    if (commas.Length > 0) commas += ", ";
                    commas += rating.Rating;
                }
                return commas;
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns>TravelImageRatingCollection object</returns>
        public static TravelImageRatingCollection GetAll() {
            TravelImageRatingCollection list = new TravelImageRatingCollection();
            list.FetchAll();
            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        /// <returns>TravelImageRatingCollection object</returns>
        public TravelImageRatingCollection Clone() {
            TravelImageRatingCollection clone = new TravelImageRatingCollection();
            foreach (TravelImageRating rating in this) {
                clone.Add(rating.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}