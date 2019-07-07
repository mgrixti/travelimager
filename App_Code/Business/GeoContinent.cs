using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a GeoContinent business object
    /// </summary>
    public partial class GeoContinent: AbstractBusiness {

        #region fields
        // Data fields
        private string _continentCode;
        private string _continentName;
        // Lazy load collection
        private TravelImageCollection _imageCollection;
        // Data access object
        private GeoContinentDA _geoContinentDA;
        #endregion

        #region properties
        /// <summary>
        /// Getter/setter for _countryCode field
        /// </summary>
        public new string Id {
            get { return _continentCode; }
            set { _continentCode = value; }
        }

        /// <summary>
        /// Getter/setter for _continentName field
        /// </summary>
        public string ContinentName {
            get { return _continentName; }
            set { _continentName = value; }
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
        public GeoContinent() {
            _geoContinentDA = new GeoContinentDA();
            base.DataAccess = _geoContinentDA;
        }
        #endregion

        #region override methods
        /// <summary>
        /// Populates a GeoContinent
        /// </summary>
        /// <param name="row">a row</param>
        public override void PopulateDataMembersFromDataRow(DataRow row) {
            // set the data members to the data retrieved from the database table/query
            if (row["ContinentCode"] == DBNull.Value)
                Id = "";
            else
                Id = Convert.ToString(row["ContinentCode"]);

            if (row["ContinentName"] == DBNull.Value)
                ContinentName = "";
            else
                ContinentName = Convert.ToString(row["ContinentName"]);

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
        /// <param name="continentCode">a iso</param>
        public void FetchById(string continentCode) {
            DataTable dt = _geoContinentDA.GetById(continentCode);
            PopulateDataMembersFromDataRow(dt.Rows[0]);
        }

        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        /// <returns>GeoContinent object</returns>
        public GeoContinent Clone() {
            GeoContinent continent = new GeoContinent();
            continent.Id = Id;
            continent.ContinentName = ContinentName;

            continent.IsNew = IsNew;
            continent.IsModified = IsModified;

            if(_imageCollection !=  null)
            foreach (TravelImage image in ImageCollection) { continent.AddImage(image.Clone()); }

            return continent;
        }

        /// <summary>
        /// Adds a image to _imageCollection field
        /// </summary>
        /// <param name="image">a image</param>
        public void AddImage(TravelImage image) { ImageCollection.Add(image); }
        #endregion
    }
}