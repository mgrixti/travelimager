using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business {
    
    /// <summary>
    /// Represents a collection of GeoCountry objects.
    /// </summary>
    public class GeoCountryCollection : AbstractBusinessCollection<GeoCountry> {

        #region fields
        private const string CACHE_KEY_ALL_SORTED = "AllGeoCountrySorted";
        // Data access fields
        private GeoCountryDA _da = new GeoCountryDA();
        #endregion

        #region methods
        /// <summary>
        /// Fetches the GeoCountry collection data
        /// </summary>
        public void FetchAll() {
            DataTable dt = _da.GetAll();
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetches the GeoCountry collection data sorted
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
        /// Fetch all the GeoCountry's with a given id. This should normally create a collection
        /// with either 0 or 1 GeoCountry's. This way the single GeoCountry can be data binded to a data control.
        /// </summary>
        /// <param name="iso">a iso</param>
        public void FetchForId(string iso) {
            DataTable dt = _da.GetById(iso);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches the top X GeoCountries 
        /// </summary>
        /// <param name="howMany">a number indicating howMany</param>
        /// <param name="ascending">a true false value</param>
        public void FetchTop(int number, bool ascending) {
            DataTable dt = _da.GetTop(number, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetches when a GeoCountry has images
        /// </summary>
        public void FetchWhenImages() {
            DataTable dt = _da.GetWhenImages();
            PopulateFromDataTable(dt);
        }

        // <summary>
        /// Fetches GeoCountries like name
        /// <param name="title">a name</param>
        /// <param name="ascending">a true false value</param>
        public void FetchLikeName(string title, bool ascending) {
            DataTable dt = _da.GetLikeName(title, ascending);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Populates a GeoCountryCollection
        /// </summary>
        /// <param name="dt">a dt</param>
        private void PopulateFromDataTable(DataTable dt) {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows) {
                GeoCountry country = new GeoCountry();
                country.PopulateDataMembersFromDataRow(row);
                AddToCollection(country);
            }
        }

        /// <summary>
        /// Gets collection in string format
        /// </summary>
        /// <returns>String object</returns>
        public string AsCommaList {
            get {
                string commas = "";
                foreach (GeoCountry country in this) {
                    if (commas.Length > 0) commas += ", ";
                    commas += country.CountryName;
                }
                return commas;
            }
        }

        /// <summary>
        /// Adapter method for ObjectDataSource
        /// </summary>
        /// <returns>a GeoCountryCollection</returns>
        public static GeoCountryCollection GetAll() {
            GeoCountryCollection list = new GeoCountryCollection();
            list.FetchAll();
            return list;
        }

        /// <summary>
        /// Return a deep copy of this collection
        /// </summary>
        /// <returns>a GeoCountryCollection</returns>
        public GeoCountryCollection Clone() {
            GeoCountryCollection clone = new GeoCountryCollection();
            foreach (GeoCountry country in this) {
                clone.Add(country.Clone());
            }
            clone.IsModified = this.IsModified;
            return clone;
        }
        #endregion
    }
}