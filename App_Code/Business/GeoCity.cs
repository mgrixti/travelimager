using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a GeoCity business object
    /// </summary>
    public class GeoCity : AbstractBusiness {
        // Data fields
        private string _asciiName;
        private string _countryCodeISO;
        private double _latitude;
        private double _longitude;
        private int _population;
        private int _elevation;
        // Lazy loaded fields
        private TravelImageCollection _imageCollection;
        // Data access fields
        private GeoCityDA _da;

        /// <summary>
        /// Constructor for a GeoCity
        /// </summary>
        public GeoCity() {
            _da = new GeoCityDA();
            base.DataAccess = _da;
        }

        #region override methods
        /// <summary>
        /// Populates a GeoCity
        /// </summary>
        /// <param name="row">a row</param>
        public override void PopulateDataMembersFromDataRow(DataRow row) {
            // set the data members to the data retrieved from the database table/query
            if (row["GeoNameID"] == DBNull.Value)
                Id = 0;
            else
                Id = Convert.ToInt32(row["GeoNameID"]);

            if (row["AsciiName"] == DBNull.Value)
                CityName = "";
            else
                CityName = Convert.ToString(row["AsciiName"]);

            if (row["CountryCodeISO"] == DBNull.Value)
                CountryCodeISO = "";
            else
                CountryCodeISO = Convert.ToString(row["CountryCodeISO"]);

            if (row["Latitude"] == DBNull.Value)
                Latitude = 0.0;
            else
                Latitude = Convert.ToDouble(row["Latitude"]);

            if (row["Longitude"] == DBNull.Value)
                Longitude = 0.0;
            else
                Longitude = Convert.ToDouble(row["Longitude"]);

            if (row["Population"] == DBNull.Value)
                Population = 0;
            else
                Population = Convert.ToInt32(row["Population"]);

            if (row["Elevation"] == DBNull.Value)
                Elevation = 0;
            else
                Elevation = Convert.ToInt32(row["Elevation"]);


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

        #region properties
        /// <summary>
        /// Getter/setter for _asciiName field
        /// </summary>
        public string CityName {
            get { return _asciiName; }
            set { _asciiName = value; }
        }

        /// <summary>
        /// Getter/setter for _countryCodeISO field
        /// </summary>
        public string CountryCodeISO {
            get { return _countryCodeISO; }
            set { _countryCodeISO = value; }
        }

        /// <summary>
        /// Getter/setter for _latitude field
        /// </summary>
        public double Latitude {
            get { return _latitude; }
            set { _latitude = value; }
        }

        /// <summary>
        /// Getter/setter for _longitude field
        /// </summary>
        public double Longitude {
            get { return _longitude; }
            set { _longitude = value; }
        }

        /// <summary>
        /// Getter/setter for _population field
        /// </summary>
        public int Population {
            get { return _population; }
            set { _population = value; }
        }

        /// <summary>
        /// Getter/setter _elevation field
        /// </summary>
        public int Elevation {
            get { return _elevation; }
            set { _elevation = value; }
        }

        /// <summary>
        /// Getter/setter for _imageCollection field
        /// </summary>
        public TravelImageCollection ImageCollection {
            get {
                // if our collection is null, then we need to fill it
                if (_imageCollection == null) {
                    _imageCollection = new TravelImageCollection();
                    _imageCollection.FetchForCity(Id,true);
                }
                return _imageCollection;
            }
        }
        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        /// <returns>GeoCity object</returns>
        public GeoCity Clone() {
            GeoCity city = new GeoCity();
            city.Id = Id;
            city.CityName = CityName;
            city.CountryCodeISO = CountryCodeISO;
            city.Latitude = Latitude;
            city.Longitude = Longitude;
            city.Population = Population;
            city.Elevation = Elevation;

            city.IsNew = IsNew;
            city.IsModified = IsModified;

            if(_imageCollection != null)
            foreach (TravelImage image in _imageCollection) { city.AddImage(image.Clone()); }
            
            return city;
        }

        /// <summary>
        /// Adds a image to _imageCollection field
        /// </summary>
        /// <param name="image">a image</param>
        public void AddImage(TravelImage image) { ImageCollection.Add(image); }
        #endregion
    }
}