using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Content.Business;

/// <summary>
/// Represents a grid for a collection of images
/// </summary>
public partial class TravelImageGridUserControl : System.Web.UI.UserControl {

    // Data fields
    private TravelImageCollection _collectionImage;

    /// <summary>
    /// Getter/setter for the _collectionImage field
    /// </summary>
    public TravelImageCollection CollectionImage {
        get { return _collectionImage; }
        set { _collectionImage = value; }
    }

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            gvImage.DataSource = _collectionImage;
            gvImage.DataBind();
        }
    }
}