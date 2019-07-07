using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Represents a collection of image boxes for a collection of images
/// </summary>
public partial class TravelImageBoxUserControl : System.Web.UI.UserControl {

    /// <summary>
    /// Data fields
    /// </summary>
    private TravelImageCollection _collectionImage;

    /// <summary>
    /// Getter/setter for _collectionImage field
    /// </summary>
    public TravelImageCollection CollectionImage {
        get { return _collectionImage; }
        set { _collectionImage = value; }
    }

    /// <summary>
    /// Event handler for the page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {
        
        // For button event
        if (!IsPostBack) {
            lvImageBox.DataSource = _collectionImage;
            lvImageBox.DataBind();
        }
    }

    /// <summary>
    /// Event handler for rptImageBox_ItemCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void rptImageBox_ItemCommand(object sender, ListViewCommandEventArgs e) {

        // Retrieve item which raised item command event
        ListViewItem item = (ListViewItem)e.Item;

        // Retrieve item index
        int index = Convert.ToInt32(item.DisplayIndex);

        // Initialize object
        TravelImage image = new TravelImage();
        image.Id = Convert.ToInt32(lvImageBox.DataKeys[index].Values["Id"]); ;
        image.Title = lvImageBox.DataKeys[index].Values["Title"].ToString(); ;
        image.Path = lvImageBox.DataKeys[index].Values["Path"].ToString(); ;

        // Save to session
        FavoritesSessionFacade.Add(image);

        // Redirect to favorites page upon adding 
        Response.Redirect("./Favorites.aspx");
    }
}