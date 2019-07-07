using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Business;


namespace Classes.Helper {

    /// <summary>
    /// Represents favorites that a particular user may have
    /// </summary>
    public class Favorites {

        //Data fields
        private TravelImageCollection _imageCollection;
        private TravelPostCollection _postCollection;

        #region constructors
        /// <summary>
        /// Constructor for favorites object 
        /// </summary>
        public Favorites() {
            _imageCollection = new TravelImageCollection();
            _postCollection = new TravelPostCollection();
        }
        #endregion


        #region properties
        /// <summary>
        /// Getter/setter for _imageCollection field
        /// </summary>
        public TravelImageCollection ImageCollection {
            get { return _imageCollection; }
            set { _imageCollection = value; }
        }

        /// <summary>
        /// Getter/setter for _postCollection field
        /// </summary>
        public TravelPostCollection PostCollection {
            get { return _postCollection; }
            set { _postCollection = value; }
        }
        #endregion

        #region methods
        /// <summary>
        /// Adds a travel image to internal collection
        /// </summary>
        /// <param name="image">a image</param>
        public void Add(TravelImage image) { _imageCollection.Add(image); }

        /// <summary>
        /// Adds travel post to internal collection
        /// </summary>
        /// <param name="post">a post</param>
        public void Add(TravelPost post) { _postCollection.Add(post); }

        /// <summary>
        /// Checks to see if image exists in internal collection
        /// </summary>
        /// <param name="image">a image</param>
        /// <returns>true/false value</returns>
        public bool IsExist(TravelImage image) { return _imageCollection.Contains(image); }

        /// <summary>
        /// Checks to see if post exists in internal collection
        /// </summary>
        /// <param name="post">a post</param>
        /// <returns>true/false</returns>
        public bool IsExist(TravelPost post) { return _postCollection.Contains(post); }

        /// <summary>
        /// Removes a image from internal collection
        /// </summary>
        /// <param name="image">a image</param>
        /// <returns>true/false value</returns>
        public bool Remove(TravelImage image) { return _imageCollection.Remove(image); }

        /// <summary>
        /// Removes a post from internal collection
        /// </summary>
        /// <param name="post">a post</param>
        /// <returns>true/false value</returns>
        public bool Remove(TravelPost post) { return _postCollection.Remove(post); }

        /// <summary>
        /// Provides image count
        /// </summary>
        /// <returns>int count</returns>
        public int ImageCount() { return ImageCollection.Count; }

        /// <summary>
        /// Provides post count
        /// </summary>
        /// <returns>int count</returns>
        public int PostCount() { return PostCollection.Count; }
        #endregion
    }
}