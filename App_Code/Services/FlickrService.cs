using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using Content.Services;
using System.Configuration;


namespace Content.Services
{
    /// <summary>
    /// Contains all the functionality of the Flickr Rest service
    /// </summary>
    public class FlickrService
    {
        private string _baseFlickrUrl =
          ConfigurationInformation.FlickrURL;
	    public FlickrService()
	    {
	    }

        /// <summary>
        /// Gets images from Flickr based on search term
        /// </summary>
        /// <param name="search">The Search term</param>
        /// <returns>List of rest images based on search term</returns>
        public List<RestImage> FindImages(string search)
        {
            try{
                string url = _baseFlickrUrl + "&" +
                    MakeAuthenticationIdQueryString() +
                    "&per_page=18&tags=" +
                    HttpUtility.UrlEncode(search);

                //get data from service
                XmlDocument xmlPhotos = new XmlDocument();
                xmlPhotos.Load(url);

                // use XPath to retrieve all the video nodes
                XmlNodeList photoNodes =
                    xmlPhotos.SelectNodes("/rsp/photos/photo");
                List<RestImage> photos = new List<RestImage>();

                foreach (XmlNode node in photoNodes)
                {
                    photos.Add(new FlickrRestImage(node));
                }

                return photos;
            }
            catch { return null; }
        }

        /// <summary>
        /// Makes Flickr Authentication key based on api key value
        /// </summary>
        /// <returns>Flickr authentication key</returns>
        private string MakeAuthenticationIdQueryString()
        {
            return "api_key=" +
                ConfigurationInformation.FlickrAuthenticationId;
        }
    }
}