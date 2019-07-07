using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a TravelUser business object
    /// </summary>
    public class TravelUser : AbstractBusiness {

        #region fields
        // Data fields
        private string _userName;
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;
        private string _region;
        private string _country;
        private string _postal;
        private string _phone;
        private string _email;
        private string _privacy;
        // Personal data access field
        private bool _showPersonalData;
        //Lazy loaded fields
        private TravelImageCollection _imageCollection;
        private TravelPostCollection _postCollection;
        //Data access fields
        private TravelUserDA _da;
        #endregion

        #region properties
        /// <summary>
        /// Getter/setter for _username field
        /// </summary>
        public string UserName {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// Getter/setter for _firstname field
        /// </summary>
        public string FirstName {
            get { return _firstName; }
            set { _firstName = value; }
        }

        /// <summary>
        /// Getter/setter for _lastname field
        /// </summary>
        public string LastName {
            get { return _lastName; }
            set { _lastName = value; }
        }

        /// <summary>
        /// Getter for _firstname and _lastname fields
        /// </summary>
        public string FullName {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>
        /// Getter/setter for _address field
        /// </summary>
        public string Address {
            get {
                if (!_showPersonalData) return "Hidden";

                return _address;
            }
            set { _address = value; }
        }

        /// <summary>
        /// Getter/setter for _city field 
        /// </summary>
        public string City {
            get { return _city; }
            set { _city = value; }
        }

        /// <summary>
        /// Getter/setter for _region field
        /// </summary>
        public string Region {
            get { return _region; }
            set { _region = value; }
        }

        /// <summary>
        /// Getter/setter for _country field
        /// </summary>
        public string Country {
            get { return _country; }
            set { _country = value; }
        }

        /// <summary>
        /// Getter/setter _postal field
        /// </summary>
        public string Postal {
            get {
                if (!_showPersonalData) return "Hidden";

                return _postal;
            }
            set { _postal = value; }
        }

        /// <summary>
        /// Getter/setter for _phone field
        /// </summary>
        public string Phone {
            get {
                if (!_showPersonalData) return "Hidden";

                return _phone;
            }
            set { _phone = value; }
        }

        /// <summary>
        /// Getter/setter for _email field
        /// </summary>
        public string Email {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Getter/setter for _privacy field
        /// </summary>
        public string Privacy {
            get {
                if (!_showPersonalData) return "Hidden";

                return _privacy;
            }
            set { _privacy = value; }
        }

        /// <summary>
        /// Getter/setter for _showPersonalData Field
        /// </summary>
        public bool ShowPersonalData {
            get { return _showPersonalData; }
            set { _showPersonalData = value; }
        }

        /// <summary>
        /// Getter for _imageCollection field
        /// </summary>
        public TravelImageCollection ImageCollection {
            get {
                // if our collection is null, then we need to fill it
                if (_imageCollection == null) {
                    _imageCollection = new TravelImageCollection();
                    _imageCollection.FetchForUser(Id);
                }
                return _imageCollection;
            }
        }

        /// <summary>
        /// Getter for _postCollection field
        /// </summary>
        public TravelPostCollection PostCollection {
            get {
                // if our collection is null, then we need to fill it
                if (_postCollection == null) {
                    _postCollection = new TravelPostCollection();
                    _postCollection.FetchForUser(Id);
                }
                return _postCollection;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for a TravelUser
        /// </summary>
        public TravelUser() {
            ShowPersonalData = true;
            _da = new TravelUserDA();
            base.DataAccess = _da;
        }
        #endregion

        #region override methods
        /// <summary>
        /// Populates a TravelUser
        /// </summary>
        /// <param name="row">a row</param>
        public override void PopulateDataMembersFromDataRow(DataRow row) {
            // set the data members to the data retrieved from the database table/query
            if (row["UID"] == DBNull.Value)
                Id = 0;
            else
                Id = Convert.ToInt32(row["UID"]);

            if (row["UserName"] == DBNull.Value)
                UserName = "";
            else
                UserName = Convert.ToString(row["UserName"]);

            if (row["FirstName"] == DBNull.Value)
                FirstName = "";
            else
                FirstName = Convert.ToString(row["FirstName"]);

            if (row["LastName"] == DBNull.Value)
                LastName = "";
            else
                LastName = Convert.ToString(row["LastName"]);

            if (row["Address"] == DBNull.Value)
                Address = "";
            else
                Address = Convert.ToString(row["Address"]);

            if (row["City"] == DBNull.Value)
                City = "";
            else
                City = Convert.ToString(row["City"]);

            if (row["Region"] == DBNull.Value)
                Region = "";
            else
                Region = Convert.ToString(row["Region"]);

            if (row["Country"] == DBNull.Value)
                Country = "";
            else
                Country = Convert.ToString(row["Country"]);

            if (row["Postal"] == DBNull.Value)
                Postal = "";
            else
                Postal = Convert.ToString(row["Postal"]);

            if (row["Phone"] == DBNull.Value)
                Phone = "";
            else
                Phone = Convert.ToString(row["Phone"]);

            if (row["Email"] == DBNull.Value)
                Email = "";
            else
                Email = Convert.ToString(row["Email"]);

            if (row["Privacy"] == DBNull.Value)
                Privacy = "";
            else
                Privacy = Convert.ToString(row["Privacy"]);

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
        public override void Update() { _da.UpdateUserDetails(Id, FirstName, LastName, Address, City, Region, Country, Postal, Phone, Email, Privacy); }

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
        public TravelUser Clone() {
            TravelUser user = new TravelUser();
            user.Id = Id;
            user.UserName = UserName;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.Address = _address;
            user.City = City;
            user.Region = Region;
            user.Country = Country;
            user.Postal = _postal;
            user.Phone = _phone;
            user.Email = Email;
            user.Privacy = Privacy;
            user.IsNew = IsNew;
            user.IsModified = IsModified;
            user._showPersonalData = _showPersonalData;

            if (_imageCollection != null)
                foreach (TravelImage image in _imageCollection) { user.AddImage(image.Clone()); }

            if (_postCollection != null)
                foreach (TravelPost post in _postCollection) { user.AddPost(post.Clone()); }

            return user;
        }

        /// <summary>
        /// Adds a image to _imageCollection field
        /// </summary>
        /// <param name="image">a image</param>
        private void AddImage(TravelImage image) { _imageCollection.Add(image); }

        /// <summary>
        /// Adds a post to _postCollection field
        /// </summary>
        /// <param name="image">a post</param>
        private void AddPost(TravelPost post) { _postCollection.Add(post); }
        #endregion
    }
}