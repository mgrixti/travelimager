using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

/// <summary>
/// Represents a grid of a collection of user objects
/// </summary>
public partial class TravelUserGridUserControl : System.Web.UI.UserControl {

    // Data fields
    private TravelUserCollection _collectionUser;

    /// <summary>
    /// Getter/setter for the _collectionUser field
    /// </summary>
    public TravelUserCollection CollectionUser {
        get { return _collectionUser; }
        set { _collectionUser = value; }
    }

    /// <summary>
    /// Event handler for the page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            gvUser.DataSource = _collectionUser;
            gvUser.DataBind();
        }
    }
}