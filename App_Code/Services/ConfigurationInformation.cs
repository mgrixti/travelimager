using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for ConfigurationInformation
/// </summary>
public static class ConfigurationInformation
{
    public static string FlickrAuthenticationId
    {
        get { return ConfigurationManager.AppSettings["FlickrId"]; }
    }
    public static string FlickrURL
    {
        get { return ConfigurationManager.AppSettings["FlickrURL"]; }
    }
}
