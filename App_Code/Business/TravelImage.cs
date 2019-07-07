using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a TravelImage business object
    /// </summary>
    public class TravelImage : AbstractBusiness {

        #region fields
        // Data fields
        private string _path;
        private string _title;
        private string _description;
        private double _latitude;
        private double _longitude;
        private int _ratingCount;
        private double _ratingAverage;
        // Lazy loaded fields
        private TravelUser _user;
        private GeoCity _city;
        private GeoCountry _country;
        private TravelPost _post;
        // Data access fields
        private TravelImageDA _da;
        #endregion

        #region properties
        /// <summary>
        /// Getter/setter for _path field
        /// </summary>
        public string Path {
            get { return _path; }
            set { _path = value; }
        }

        /// <summary>
        /// Getter/setter for _title field
        /// </summary>
        public string Title {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Getter/setter for _description field
        /// </summary>
        public string Description {
            get { return _description; }
            set { _description = value; }
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
        /// Getter for _user field Fullname property
        /// </summary>
        public string FullName {
            get {
                if (IsExist(User)) {
                    return User.FullName;
                }
                return "";
            }
        }

        /// <summary>
        /// Getter/setter for _ratingCount field
        /// </summary>
        public int RatingCount {
            get { return _ratingCount; }
            set { _ratingCount = value; }
        }

        /// <summary>
        /// Getter/setter for _ratingAverage field
        /// </summary>
        public double RatingAverage {
            get { return _ratingAverage; }
            set { _ratingAverage = value; }
        }

        /// <summary>
        /// Getter for _city AsciiName property
        /// </summary>
        public string CityName {
            get {
                if (IsExist(City)) {
                    return City.CityName;
                }
                return "";
            }
        }

        /// <summary>
        /// Getter for _country CountryName property
        /// </summary>
        public string CountryName {
            get {
                if (IsExist(Country)) {
                    return Country.CountryName;
                }
                return "";
            }
        }

        /// <summary>
        /// Getter/Setter for _user field
        /// </summary>
        public TravelUser User {
            get { return _user; }
        }

        /// <summary>
        /// Getter for _user field Id property
        /// </summary>
        public int UserID {
            get {
                if (IsExist(User)) {
                    return User.Id;
                }
                return 0;
            }
        }

        /// <summary>
        /// Getter/Setter for _city field
        /// </summary>
        public GeoCity City {
            get { return _city; }
        }

        /// <summary>
        /// Getter for _city field Id property
        /// </summary>
        public int CityID {
            get {
                if (IsExist(City)) {
                    return City.Id;
                }
                return 0;
            }
        }

        /// <summary>
        /// Getter/Setter for _country field
        /// </summary>
        public GeoCountry Country {
            get { return _country; }
        }

        /// <summary>
        /// Getter for _country field Id property
        /// </summary>
        public string CountryID {
            get {
                if (IsExist(Country)) {
                    return Country.Id;
                }
                return "";
            }
        }

        // <summary>
        /// Getter/setter _post field
        /// </summary>
        public TravelPost Post {
            get { return _post; }
        }


        /// <summary>
        /// Getter for _post field Title property
        /// </summary>
        public string PostTitle
        {
            get
            {
                if (IsExist(Post))
                {
                    return Post.Title;
                }
                return "";
            }
        }

        /// <summary>
        /// Getter for _post field Id property
        /// </summary>
        public int PostID
        {
            get
            {
                if (IsExist(Post))
                {
                    return Post.Id;
                }
                return 0;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for a TravelImage
        /// </summary>
        public TravelImage() {
            _da = new TravelImageDA();
            base.DataAccess = _da;
        }
        #endregion

        #region override methods
        /// <summary>
        /// Populates a TravelImage
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row) {
            // set the data members to the data retrieved from the database table/query
           
            if (row["ImageID"] == DBNull.Value)
                Id = DEFAULT_ID;
            else 
                Id = Convert.ToInt32(row["ImageID"]);
           
            if (row["Path"] == DBNull.Value)
                Path = "";
            else
                Path = Convert.ToString(row["Path"]);

            if (row["UID"] != DBNull.Value) {
                _user = new TravelUser();
                _user.Id = Convert.ToInt32(row["UID"]);
                _user.FirstName = Convert.ToString(row["FirstName"]);
                _user.LastName = Convert.ToString(row["LastName"]);
            }
            
            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = Convert.ToString(row["Title"]);

            if (row["Description"] == DBNull.Value)
                Description = "";
            else
                Description = Convert.ToString(row["Description"]);

            if (row["Latitude"] == DBNull.Value)
                Latitude = 0.0;
            else
                Latitude = Convert.ToDouble(row["Latitude"]);

            if (row["Longitude"] == DBNull.Value)
                Longitude = 0.0;
            else
                Longitude = Convert.ToDouble(row["Longitude"]);

            if (row["PostID"] != DBNull.Value)
            {
                _post = new TravelPost();
                _post.Id = Convert.ToInt32(row["PostID"]);
                _post.Title = Convert.ToString(row["PostTitle"]);
            }
            

            if (row["GeoNameID"] != DBNull.Value) {
                _city = new GeoCity();
                _city.Id = Convert.ToInt32(row["GeoNameID"]);
                _city.CityName = Convert.ToString(row["AsciiName"]);
            }

            if (row["ISO"] != DBNull.Value) {
                _country = new GeoCountry();
                _country.Id = Convert.ToString(row["ISO"]);
                _country.CountryName = Convert.ToString(row["CountryName"]);
            }

            if (row["RatingCount"] == DBNull.Value)
                RatingCount = 0;
            else
                RatingCount = Convert.ToInt32(row["RatingCount"]);

            if (row["RatingAverage"] == DBNull.Value)
                RatingAverage = 0.0;
            else
                RatingAverage = Convert.ToDouble(row["RatingAverage"]);

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
        public override void Update() { }

        /// <summary>
        /// Inserts the content of the current business object
        /// </summary>
        public override void Insert() { }

        /// <summary>
        /// Deletes the content of the current business object
        /// </summary>
        public override void Delete() { }
        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        public TravelImage Clone() {
            TravelImage image = new TravelImage();
            image.Id = Id;
            image.Path = Path;
            image.Title = Title;
            image.Description = Description;
            image.Latitude = Latitude;
            image.Longitude = Longitude;
            image.RatingCount = RatingCount;
            image.RatingAverage = RatingAverage;

            image.IsNew = IsNew;
            image.IsModified = IsModified;

            if(_user != null)
            image._user = _user.Clone();

            if(_city != null)
            image._city = _city.Clone();

            if(_country != null)
            image._country = _country.Clone();
            
            if(_post != null)
            image._post = _post.Clone();

            return image;
        }

        /// <summary>
        /// Checks to see if this object is equal to this object
        /// </summary>
        /// <param name="obj">a obj</param>
        /// <returns>true/false value</returns>
        public override bool Equals(Object obj) {

            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            TravelImage image = (TravelImage)obj;
            if (this.Id != image.Id) return false;
            return true;
        }
        #endregion
    }
}