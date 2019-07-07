using System.Xml;

namespace Content.Services
{
    /// <summary>
    /// Contains the attributes of the RestImage Object
    /// </summary>
    public abstract class RestImage: AbstractDomain 
    {
        private string _size = "";
        private string _url = "";
        private string _link = "";

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public string Size
        {
            get { return _size; }
            set { _size = value; }
        }
        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        /// <summary>
        /// Default constructor for the RestImage class
        /// </summary>
        public RestImage()
        {
        }

        /// <summary>
        /// Overloaded constructor for the RestImage class
        /// accepting an XMLNode
        /// </summary>
        /// <param name="node">The XMLNode</param>
        public RestImage(XmlNode node)
        {
            LoadFromXmlNode(node);
        }
    }
}