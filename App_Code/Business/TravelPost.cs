using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a TravelPost business object
    /// </summary>
    public class TravelPost : AbstractBusiness {

        #region fields
        // Data fields
        private string _title;
        private string _message;
        private string _postTime;
        // Unidirectional links
        private TravelUser _user;
        // Lazy loaded fields
        private TravelImageCollection _imageCollection;
        // Data access fields
        private TravelPostDA _da;
        #endregion

        #region properties
        /// <summary>
        /// Getter/setter for _title field
        /// </summary>
        public string Title {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Getter/setter for _message field 
        /// </summary>
        public string Message {
            get { return _message; }
            set { _message = value; }
        }

        /// <summary>
        /// Getter/setter for _postTime field
        /// </summary>
        public string PostTime {
            get { return _postTime; }
            set { _postTime = value; }
        }

        /// <summary>
        /// Getter/setter for _user field
        /// </summary>
        public TravelUser User {
            get { return _user; }
        }


        /// <summary>
        /// Getter for _user field FullName property
        /// </summary>
        public string FullName {
            get {
                if (IsExist(User)) {
                    return _user.FullName;
                }
                return "";
            }
        }

        /// <summary>
        /// Getter for _user field UID property
        /// </summary>
        public int UserID {
            get {
                if (IsExist(User)) {
                    return _user.Id;
                }
                return 0;
            }
        }

        /// <summary>
        /// Getter/setter for _imageCollection field
        /// </summary>
        public TravelImageCollection ImageCollection {
            get {
                // if our collection is null, then we need to fill it
                if (_imageCollection == null) {
                    _imageCollection = new TravelImageCollection();
                    _imageCollection.FetchForPost(Id);
                }
                return _imageCollection;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for a TravelPost
        /// </summary>
        public TravelPost() {
            _da = new TravelPostDA();
            base.DataAccess = _da;
        }
        #endregion

        #region override methods
        /// <summary>
        /// Populates a TravelPost
        /// </summary>
        /// <param name="row">a row</param>
        public override void PopulateDataMembersFromDataRow(DataRow row) {
            // set the data members to the data retrieved from the database table/query
            if (row["PostID"] == DBNull.Value)
                Id = DEFAULT_ID;
            else
                Id = Convert.ToInt32(row["PostID"]);

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

            if (row["Message"] == DBNull.Value)
                Message = "";
            else
                Message = Convert.ToString(row["Message"]);

            if (row["PostTime"] == DBNull.Value)
                PostTime = "";
            else
                PostTime = Convert.ToString(row["PostTime"]);

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
        /// Makes a clone (deep copy) of this object
        /// </summary>
        /// <returns>TravelPost Object</returns>
        public TravelPost Clone() {
            TravelPost post = new TravelPost();
            post.Id = Id;
            post.Title = Title;
            post.Message = Message;
            post.PostTime = PostTime;

            post.IsNew = IsNew;
            post.IsModified = IsModified;

            if(_user!= null)
            post._user = _user.Clone();

            if (_imageCollection != null)
            foreach (TravelImage image in _imageCollection) { post.AddImage(image.Clone()); }

            return post;
        }

        /// <summary>
        /// Adds a image to _imageCollection field
        /// </summary>
        /// <param name="image">a image</param>
        public void AddImage(TravelImage image) { ImageCollection.Add(image); }

        /// <summary>
        /// Checks to see if an this object is equal to this object
        /// </summary>
        /// <param name="obj">a obj</param>
        /// <returns>true/false value</returns>
        public override bool Equals(Object obj) {

            if (this == obj) return true; 
            if (obj == null) return false; 
            if (this.GetType() != obj.GetType()) return false;

            TravelPost post = (TravelPost)obj;
            if (this.Id != post.Id) return false;
            return true;
        }
        #endregion
    }
}