using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a GeoCountry business object
    /// </summary>
    public class GeoCountry : AbstractBusiness {

        #region fields
        // Data fields
        private string _iso;
        private string _countryName;
        private string _capital;
        private string _area;
        private int _population;
        private string _currencyCode;
        private string _countryDescription;
        // Lazy load collection
        private TravelImageCollection _imageCollection;
        // Data access object
        private GeoCountryDA _geoCountryDA;
        #endregion

        #region properties
        /// <summary>
        /// Getter/setter for _iso field
        /// </summary>
        public new string Id {
            get { return _iso; }
            set { _iso = value; }
        }

        /// <summary>
        /// Getter/setter for _countryName field
        /// </summary>
        public string CountryName {
            get { return _countryName; }
            set { _countryName = value; }
        }

        /// <summary>
        /// Getter/setter for _capital field
        /// </summary>
        public string Capital {
            get { return _capital; }
            set { _capital = value; }
        }

        /// <summary>
        /// Getter/setter for _area field
        /// </summary>
        public string Area {
            get { return _area; }
            set { _area = value; }
        }

        /// <summary>
        /// Getter/setter for _population field
        /// </summary>
        public int Population {
            get { return _population; }
            set { _population = value; }
        }

        /// <summary>
        /// Getter/setter for _currencyCode field
        /// </summary>
        public string CurrencyCode {
            get { return _currencyCode; }
            set { _currencyCode = value; }
        }

        /// <summary>
        /// Getter/setter for _countryDescription field
        /// </summary>
        public string CountryDescription {
            get { return _countryDescription; }
            set { _countryDescription = value; }
        }

        /// <summary>
        /// Getter for _imageCollection field
        /// </summary>
        public TravelImageCollection ImageCollection {
            get {
                // if our collection is null, then we need to fill it
                if (_imageCollection == null) {
                    _imageCollection = new TravelImageCollection();
                    _imageCollection.FetchForCountry(Id, true);
                }
                return _imageCollection;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for a GeoCountry
        /// </summary>
        public GeoCountry() {
            _geoCountryDA = new GeoCountryDA();
            base.DataAccess = _geoCountryDA;
        }
        #endregion

        #region override methods
        /// <summary>
        /// Populates a GeoCountry
        /// </summary>
        /// <param name="row">a row</param>
        public override void PopulateDataMembersFromDataRow(DataRow row) {
            // set the data members to the data retrieved from the database table/query
            if (row["ISO"] == DBNull.Value)
                Id = "";
            else
                Id = Convert.ToString(row["ISO"]);

            if (row["CountryName"] == DBNull.Value)
                CountryName = "";
            else
                CountryName = Convert.ToString(row["CountryName"]);

            if (row["Capital"] == DBNull.Value)
                Capital = "";
            else
                Capital = Convert.ToString(row["Capital"]);

            if (row["Area"] == DBNull.Value)
                Area = "";
            else
                Area = Convert.ToString(row["Area"]);

            if (row["Population"] == DBNull.Value)
                Population = 0;
            else
                Population = Convert.ToInt32(row["Population"]);

            if (row["CurrencyCode"] == DBNull.Value)
                CurrencyCode = "";
            else
                CurrencyCode = Convert.ToString(row["CurrencyCode"]);

            if (row["CountryDescription"] == DBNull.Value)
                CountryDescription = "";
            else
                CountryDescription = Convert.ToString(row["CountryDescription"]);

            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        /// <summary>
        /// Each subclass will be responsible for checking if its
        /// own state (data members) has any broken business rules
        /// </summary>
        protected override void CheckIfSubClassStateIsValid() { }

        /// <summary>
        /// Update the content of the current business object
        /// </summary>
        public override void Delete() { }

        /// <summary>
        /// Inserts the content of the current business object
        /// </summary>
        public override void Insert() { }

        /// <summary>
        /// Deletes the content of the current business object
        /// </summary>
        public override void Update() { }
        #endregion

        #region methods
        /// <summary>
        /// Fetches a business object's data
        /// </summary>
        /// <param name="iso">a iso</param>
        public void FetchById(string iso) {
            DataTable dt = _geoCountryDA.GetById(iso);
            PopulateDataMembersFromDataRow(dt.Rows[0]);
        }

        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        /// <returns>GeoCountry object</returns>
        public GeoCountry Clone() {
            GeoCountry country = new GeoCountry();
            country.Id = Id;
            country.CountryName = CountryName;
            country.Capital = Capital;
            country.Area = Area;
            country.Population = Population;
            country.CurrencyCode = CurrencyCode;
            country.CountryDescription = CountryDescription;

            country.IsNew = IsNew;
            country.IsModified = IsModified;

            if(_imageCollection != null)
            foreach (TravelImage image in _imageCollection) { country.AddImage(image.Clone()); }
            
            return country;
        }

        /// <summary>
        /// Adds a image to _imageCollection field
        /// </summary>
        /// <param name="image">a image</param>
        public void AddImage(TravelImage image) { ImageCollection.Add(image); }
        #endregion
    }
}