using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business {
    
    /// <summary>
    /// Represents a collection of TravelPost objects.
    /// </summary>
    public class TravelPostCollection : AbstractBusinessCollection<TravelPost> {

        #region fields
        // Data access fields
        private TravelPostDA _da = new TravelPostDA();
        #endregion

        #region methods
        /// <summary>
        /// Fetches the TravelPost collection data
        /// </summary>
        public void FetchAll() {
            DataTable dt = _da.GetAll();
            PopulateFromDataTable(dt);
            _isNew = false;
        }

         /// <summary>
        /// Fetches the TravelPostcollection data sorted
        /// </summary>
        /// <param name="ascending">a true false value</param>
        public void FetchAllSorted(bool ascending) {
            DataTable dt = _da.GetAllSorted(ascending);
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches all the TravelPosts with a given id. This should normally create a collection
        /// with either 0 or 1 TravelPosts. This way the single TravelPost can be data binded to a data control.
        /// </summary>
        /// <param name="id">a id</param>
        public void FetchForId(int id) {
            DataTable dt = _da.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches the top X TravelPosts
        /// </summary>
        /// <param name="howMany">a number indicating howMany</param>
        /// <param name="ascending">a true false value</param>
        public void FetchTop(int howMany, bool ascending) {
            DataTable dt = _da.GetTop(howMany, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches  TravelPosts for user
        /// </summary>
        /// <param name="userID">a userID</param>
        public void FetchForUser(int userID) {
            DataTable dt = _da.GetForUser(userID);
            PopulateFromDataTable(dt);
        }


        // <summary>
        /// Fetches TravelPost like title
        /// </summary>
        /// <param name="title">a title</param>
        /// <param name="ascending">a true false value</param>
        public void FetchLikeTitle(string title, bool ascending) {
            DataTable dt = _da.GetLikeTitle(title, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Populates a TravelPostCollection
        /// </summary>
        /// <param name="dt">a dt</param>
        private void PopulateFromDataTable(DataTable dt) {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows) {
                TravelPost post = new TravelPost();
                post.PopulateDataMembersFromDataRow(row);
                AddToCollection(post);
            }
        }

        /// <summary>
        /// Gets collection in string format
        /// </summary>
        /// <returns>String object</returns>
        public string AsCommaList {
            get {
                string commas = "";
                foreach (TravelPost post in this) {
                    if (commas.Length > 0) commas += ", ";
                    commas += post.Title;
                }
                return commas;
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns>TravelPostCollection object</returns>
        public static TravelPostCollection GetAll() {
            TravelPostCollection list = new TravelPostCollection();
            list.FetchAll();
            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        /// <returns>TravelPostCollection object</returns>
        public TravelPostCollection Clone() {
            TravelPostCollection clone = new TravelPostCollection();
            foreach (TravelPost post in this) {
                clone.Add(post.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}