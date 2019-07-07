using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Content.Business;


namespace Classes.Helper {
    /// <summary>
    /// Manages session favorites using the facade design pattern
    /// </summary>
    public static class FavoritesSessionFacade {

        //Data fields
        private const string SESSION_FAVORITES = "favorites";

        #region properties
        /// <summary>
        /// Getter for favorite images
        /// </summary>
        public static TravelImageCollection ImageCollection {
            get {
                Favorites temp = RetrieveFavoritesFromSession();
                return temp.ImageCollection;
            }
        }

        /// <summary>
        /// Getter for favorite posts
        /// </summary>
        public static TravelPostCollection PostCollection {
            get {
                Favorites temp = RetrieveFavoritesFromSession();
                return temp.PostCollection;
            }
        }
        #endregion
        /// <summary>
        /// Checks to see if favorites session is null
        /// </summary>
        /// <returns>true/false value indicating if session is null</returns>
        private static bool IsFavoritesExist() { return (HttpContext.Current.Session[SESSION_FAVORITES] != null); }

        /// <summary>
        /// Retrieves favorities object from session
        /// </summary>
        /// <returns></returns>
        private static Favorites RetrieveFavoritesFromSession() {

            if (!IsFavoritesExist())
                return new Favorites();
            else
                return (Favorites)HttpContext.Current.Session[SESSION_FAVORITES];
        }

        /// <summary>
        /// Sends favorites object to session
        /// </summary>
        /// <param name="favorites">a favorites object</param>
        private static void SendFavoritesToSession(Favorites favorites) { HttpContext.Current.Session[SESSION_FAVORITES] = favorites; }

        /// <summary>
        /// Adds a images to favorites
        /// </summary>
        /// <param name="image">a image</param>
        /// <returns>true/false value indicating if added</returns>
        public static bool Add(TravelImage image) {
            bool isAdded = false;
            Favorites temp = RetrieveFavoritesFromSession();
            if (!temp.IsExist(image)) {
                temp.Add(image);
                SendFavoritesToSession(temp);
                isAdded = false;
            }
            return isAdded;
        }

        /// <summary>
        /// Adds a post to favorites
        /// </summary>
        /// <param name="post">a post</param>
        /// <returns>true/false value indicating if added</returns>
        public static bool Add(TravelPost post) {
            bool isAdded = false;
            Favorites temp = RetrieveFavoritesFromSession();
            if (!temp.IsExist(post)) {
                temp.Add(post);
                SendFavoritesToSession(temp);
                isAdded = false;
            }
            return isAdded;
        }

        /// <summary>
        /// Removes a image
        /// </summary>
        /// <param name="image">a image</param>
        /// <returns>true/false value indicating if removed</returns>
        public static bool Remove(TravelImage image) {
            bool isRemoved = false;

            if (IsFavoritesExist()) {
                Favorites temp = RetrieveFavoritesFromSession();
                isRemoved = temp.Remove(image);
                SendFavoritesToSession(temp);
            }
            return isRemoved;
        }

        /// <summary>
        /// Removes a post
        /// </summary>
        /// <param name="post">a post</param>
        /// <returns></returns>
        public static bool Remove(TravelPost post) {
            bool isRemoved = false;

            if (IsFavoritesExist()) {
                Favorites temp = RetrieveFavoritesFromSession();
                isRemoved = temp.Remove(post);
                SendFavoritesToSession(temp);
            }
            return isRemoved;
        }

        /// <summary>
        /// Returns favorites image count
        /// </summary>
        /// <returns>int count</returns>
        public static int ImageCount() { return RetrieveFavoritesFromSession().ImageCount(); }

        /// <summary>
        /// Returns favorites post count
        /// </summary>
        /// <returns>int count</returns>
        public static int PostCount() { return RetrieveFavoritesFromSession().PostCount(); }
    }
}