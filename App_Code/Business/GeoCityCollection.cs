using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a collection of GeoCity objects.
    /// </summary>
    public class GeoCityCollection : AbstractBusinessCollection<GeoCity> {

        #region fields
        // Data access fields
        private GeoCityDA _da = new GeoCityDA();
        #endregion

        #region methods
        /// <summary>
        /// Fetches the GeoCity collection data
        /// </summary>
        public void FetchAll() {
            DataTable dt = _da.GetAll();
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches the GeoCity collection data sorted
        /// </summary>
        /// <param name="ascending">a true false value</param>
        public void FetchAllSorted(bool ascending) {
            DataTable dt = _da.GetAllSorted(ascending);
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the GeoCity's with a given id. This should normally create a collection
        /// with either 0 or 1 GeoCity's. This way the single GeoCity can be data binded to a data control.
        /// </summary>
        public void FetchForId(int id) {
            DataTable dt = _da.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches the top X GeoCities 
        /// </summary>
        public void FetchTop(int number) {
            DataTable dt = _da.GetTop(number, true);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches when a GeoCity has images
        /// </summary>
        public void FetchWhenImages() {
            DataTable dt = _da.GetWhenImages();
            PopulateFromDataTable(dt);
        }

        // <summary>
        /// Fetches GeoCities like name
        /// <param name="title">a name</param>
        /// <param name="ascending">a true false value</param>
        public void FetchLikeName(string title, bool ascending) {
            DataTable dt = _da.GetLikeName(title, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Populates a GeoCityCollection
        /// </summary>
        /// <param name="dt">a dt</param>
        private void PopulateFromDataTable(DataTable dt) {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows) {
                GeoCity city = new GeoCity();
                city.PopulateDataMembersFromDataRow(row);
                AddToCollection(city);
            }
        }

        /// <summary>
        /// Gets collection in string format
        /// </summary>
        /// <returns>string object</returns>
        public string AsCommaList {
            get {
                string commas = "";
                foreach (GeoCity city in this) {
                    if (commas.Length > 0) commas += ", ";
                    commas += city.CityName;
                }
                return commas;
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns>GeoCityCollection object</returns>
        public static GeoCityCollection GetAll() {
            GeoCityCollection list = new GeoCityCollection();
            list.FetchAll();
            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        /// <returns>GeoCityCollection object</returns>
        public GeoCityCollection Clone() {
            GeoCityCollection clone = new GeoCityCollection();
            foreach (GeoCity city in this) {
                clone.Add(city.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}