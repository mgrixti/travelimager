using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;


namespace Content.Services
{
    /// <summary>
    /// Provides all the functionality and constructor for the FlickrRestImage class
    /// </summary>
    public class FlickrRestImage : RestImage
    {
        /// <summary>
        /// Constructor for a FlickrRestImage object
        /// </summary>
        /// <param name="node">The XMLNode</param>
        public FlickrRestImage(XmlNode node) : base(node)
        {
        }

        /// <summary>
        /// Loads the FlickrRestImage from the XML Node
        /// </summary>
        /// <param name="node">The Xml Node</param>
        public override void LoadFromXmlNode(XmlNode node)
        {
            try
            {
                string id = node.Attributes["id"].Value;
                string secret = node.Attributes["secret"].Value;
                string server = node.Attributes["server"].Value;
                string farm = node.Attributes["farm"].Value;

                Url = "http://farm" + farm + ".static.flickr.com/"
                    + server + "/" + id + "_" + secret;
                Link = Url + ".jpg";
                Url += "_s.jpg";
            }
            catch (Exception ex)
            {
                throw new Exception("YahooRestImage:LoadFromXmlNode - " +
                  ex.Message);
            }

        }
    }
}