using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;

namespace Content.Business {

    /// <summary>
    /// Represents a TravelImageRating business object
    /// </summary>
    public class TravelImageRating : AbstractBusiness {

        #region fields
        // Data fields
        private int _rating;
        private string _reviewDate;
        private string _comment;
        private string _userName;
        // Unidirectional Links
        private TravelImage _image;
        // Data access fields
        private TravelImageRatingDA _da;
        #endregion

        #region properties
        /// <summary>
        /// Getter/setter for _rating field
        /// </summary>
        public int Rating {
            get { return _rating; }
            set { _rating = value; }
        }

        /// <summary>
        /// Getter/setter for _reviewDate field 
        /// </summary>
        public string ReviewDate {
            get { return _reviewDate; }
            set { _reviewDate = value; }
        }

        /// <summary>
        /// Getter/setter for _comment field
        /// </summary>
        public string Comment {
            get { return _comment; }
            set { _comment = value; }
        }

        /// <summary>
        /// Getter/setter for _userName field
        /// </summary>
        public string UserName {
            get { return _userName; }
            set { _userName = value; }
        }

        /// <summary>
        /// Getter for _image field
        /// </summary>
        public TravelImage Image {
            get { return _image; }
        }

        /// <summary>
        /// Getter for _image Id property
        /// </summary>
        public int ImageID {
            get {
                if (IsExist(Image)) {
                    return _image.Id;
                }
                return 0;
            }

            set {
                if (!IsExist(Image)) {
                    _image = new TravelImage();
                    _image.Id = value;
                }
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Constructor for a TravelImageRating
        /// </summary>
        public TravelImageRating() {
            _da = new TravelImageRatingDA();
            base.DataAccess = _da;
        }
        #endregion

        #region override methods
        /// <summary>
        /// Populates a TravelImageRating
        /// </summary>
        /// <param name="row">a row</param>
        public override void PopulateDataMembersFromDataRow(DataRow row) {
            // set the data members to the data retrieved from the database table/query
            if (row["ImageRatingID"] == DBNull.Value)
                Id = DEFAULT_ID;
            else
                Id = Convert.ToInt32(row["ImageRatingID"]);

            if (row["ImageID"] != DBNull.Value) {
                _image = new TravelImage();
                _image.Id = Convert.ToInt32(row["ImageID"]);
            }

            if (row["Rating"] == DBNull.Value)
                Rating = 0;
            else
                Rating = Convert.ToInt32(row["Rating"]);

            if (row["ReviewDate"] == DBNull.Value)
                ReviewDate = "";
            else
                ReviewDate = Convert.ToString(row["ReviewDate"]);

            if (row["Comment"] == DBNull.Value)
                Comment = "";
            else
                Comment = Convert.ToString(row["Comment"]);

            if (row["UserName"] == DBNull.Value)
                UserName = "";
            else
                UserName = Convert.ToString(row["UserName"]);

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
        /// Deletes the content of the current business object
        /// </summary>
        public override void Delete() { _da.DeleteById(Id); }

        /// <summary>
        /// Inserts the content of the current business object
        /// </summary>
        public override void Insert() { Id = _da.InsertImageRating(_image.Id,Rating, ReviewDate, Comment, UserName); }

        /// <summary>
        /// Updates the content of the current business object
        /// </summary>
        public override void Update() { }
        #endregion

        #region methods
        /// <summary>
        /// Makes a clone (deep copy) of this object
        /// </summary>
        /// <returns>TravelImageRating Object</returns>
        public TravelImageRating Clone() {

            TravelImageRating rating = new TravelImageRating();
            rating.Id = Id;
            rating.Rating = Rating;
            rating.ReviewDate = ReviewDate;
            rating.Comment = Comment;
            rating.UserName = UserName;

            if(_image != null)
                rating._image = _image.Clone();

            rating.IsNew = IsNew;
            rating.IsModified = IsModified;
            return rating;
        }

        /// <summary>
        /// Checks to see if an this object is equal to this object
        /// </summary>
        /// <param name="obj">a obj</param>
        /// <returns>true/false value</returns>
        public override bool Equals(Object obj) {

            if (this == obj) return true;
            if (obj == null) return false;
            if (this.GetType() != obj.GetType()) return false;

            TravelImageRating rating = (TravelImageRating)obj;
            if (this.Id != rating.Id) return false;
            return true;
        }
        #endregion
    }
}