using System.Xml;

namespace Content.Services
{
    /// <summary>
    /// Summary description for AbstractDomain
    /// </summary>
    public abstract class AbstractDomain
    {
        public abstract void LoadFromXmlNode(XmlNode node);
    }
}
