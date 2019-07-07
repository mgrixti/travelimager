using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Services;

/// <summary>
/// Displays flickr feed
/// </summary>
public partial class UserControls_WebUserControl : System.Web.UI.UserControl
{
    private string _searchFor = "";

    public string SearchFor
    {
        get { return _searchFor; }
        set { _searchFor = value; }
    }

    /// <summary>
    /// Event handler for the page load event
    /// </summary>
    /// <param name="sender">sender</param>
    /// <param name="e">eventargs</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        FlickrService flickr = new FlickrService();
        List<RestImage> list = flickr.FindImages(SearchFor);
        if (list == null)
        {
            labMessage.Text = "Flickr service is unavailable";
            panError.Visible = true;
        }
        else
        {
            panError.Visible = false;
            dlstPhotos.DataSource = list;
            dlstPhotos.DataBind();
        }
    }
}