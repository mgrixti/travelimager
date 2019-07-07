using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a collection of TravelUser business objects.
    /// </summary>
    public class TravelUserCollection : AbstractBusinessCollection<TravelUser> {

        #region fields
        // Data access fields
        private TravelUserDA _da = new TravelUserDA();
        #endregion

        #region methods
        /// <summary>
        /// Fetches the TravelUser collection data
        /// </summary>
        public void FetchAll() {
            DataTable dt = _da.GetAll();
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches all TravelUser collection data in sorted order
        /// </summary>
        /// <param name="ascending">a true false value</param>
        public void FetchAllSorted(bool ascending) {
            DataTable dt = _da.GetAllSorted(ascending);
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches all the TravelUser's with a given id. This should normally create a collection
        /// with either 0 or 1 TravelUser's. This way the single TravelUser can be data binded to a data control.
        /// </summary>
        /// <param name="id">a id</param>
        public void FetchForId(int id) {
            DataTable dt = _da.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches the top X TravelUsers
        /// </summary>
        /// <param name="howMany">a number indicating howMany</param>
        /// <param name="ascending">a true false value</param>
        public void FetchTop(int howMany, bool ascending) {
            DataTable dt = _da.GetTop(howMany, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Populates a TravelUserCollection
        /// </summary>
        /// <param name="dt">a dt</param>
        private void PopulateFromDataTable(DataTable dt) {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows) {
                TravelUser userDetail = new TravelUser();
                userDetail.PopulateDataMembersFromDataRow(row);
                AddToCollection(userDetail);
            }
        }

        /// <summary>
        /// Gets collection in string format
        /// </summary>
        /// <returns>String object</returns>
        public string AsCommaList {
            get {
                string commas = "";
                foreach (TravelUser userDetail in this) {
                    if (commas.Length > 0) commas += ", ";
                    commas += userDetail.FullName;
                }
                return commas;
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns>TravelUserCollection object</returns>
        public static TravelUserCollection GetAll() {
            TravelUserCollection list = new TravelUserCollection();
            list.FetchAll();
            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        /// <returns>TravelUserCollection object</returns>
        public TravelUserCollection Clone() {
            TravelUserCollection clone = new TravelUserCollection();
            foreach (TravelUser userDetail in this) {
                clone.Add(userDetail.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}