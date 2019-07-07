using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

/// <summary>
/// Represents a grid for a collection of posts
/// </summary>
public partial class TravelPostGridUserControl : System.Web.UI.UserControl {

    // Data fields
    private TravelPostCollection _collectionPost;

    /// <summary>
    /// Getter/setter for the _collectionPost field
    /// </summary>
    public TravelPostCollection CollectionPost {
        get { return _collectionPost; }
        set { _collectionPost = value; }
    }

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        gvPost.DataSource = _collectionPost;
        gvPost.DataBind();
    }
}