using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a collection of GeoContinent objects.
    /// </summary>
    public class GeoContinentCollection : AbstractBusinessCollection<GeoContinent> {

        #region fields
        private const string CACHE_KEY_ALL_SORTED = "AllGeoContinentSorted";
        // Data access fields
        private GeoContinentDA _da = new GeoContinentDA();
        #endregion

        #region methods
        /// <summary>
        /// Fetches the GeoContinent collection data
        /// </summary>
        public void FetchAll() {
            DataTable dt = _da.GetAll();
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches the GeoContinent collection data sorted
        /// </summary>
        /// <param name="ascending">a true false value</param>
        public void FetchAllSorted(bool ascending) {

            // first try to retrieve this from the cache
            DataTable dt = (DataTable)HttpContext.Current.Cache[CACHE_KEY_ALL_SORTED];
            // if not in cache then get from database
            if (dt == null) {
                dt = _da.GetAllSorted(ascending);
                // put this DataTable back in the cache
                HttpContext.Current.Cache[CACHE_KEY_ALL_SORTED] = dt;
            }
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all the GeoContinent's with a given id. This should normally create a collection
        /// with either 0 or 1 GeoContinent's. This way the single GeoContinent can be data binded to a data control.
        /// </summary>
        /// <param name="iso">a iso</param>
        public void FetchForId(string iso) {
            DataTable dt = _da.GetById(iso);
            PopulateFromDataTable(dt);
        }


        /// <summary>
        /// Fetches the top X GeoContinents 
        /// </summary>
        /// <param name="howMany">a number indicating howMany</param>
        /// <param name="ascending">a true false value</param>
        public void FetchTop(int number, bool ascending) {
            DataTable dt = _da.GetTop(number, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Populates a GeoContinentCollection
        /// </summary>
        /// <param name="dt">a dt</param>
        private void PopulateFromDataTable(DataTable dt) {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows) {
                GeoContinent continent = new GeoContinent();
                continent.PopulateDataMembersFromDataRow(row);
                AddToCollection(continent);
            }
        }

        /// <summary>
        /// Gets collection in string format
        /// </summary>
        /// <returns>String object</returns>
        public string AsCommaList {
            get {
                string commas = "";
                foreach (GeoContinent continent in this) {
                    if (commas.Length > 0) commas += ", ";
                    commas += continent.ContinentName;
                }
                return commas;
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns>a GeoContinentCollection</returns>
        public static GeoContinentCollection GetAll() {
            GeoContinentCollection list = new GeoContinentCollection();
            list.FetchAll();
            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        /// <returns>a GeoContinentCollection</returns>
        public GeoContinentCollection Clone() {
            GeoContinentCollection clone = new GeoContinentCollection();
            foreach (GeoContinent continent in this) {
                clone.Add(continent.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}