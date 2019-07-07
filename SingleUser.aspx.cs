using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Represents a page for a single user
/// </summary>
public partial class SingleUser : System.Web.UI.Page {

    // Data fields
    private TravelUserCollection _user;

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            if (QueryStringVerifier.IsNumberAndIsNotNull(Request.QueryString["Id"])) {
                int userId = Convert.ToInt32(Request.QueryString["Id"]);
                LoadUser(userId);

                if (_user.Count > 0) {
                    DisplayUser();

                    if (_user[0].ImageCollection.Count > 0)
                        // Display if images
                        DisplayRelatedImage();
                    else
                        // Hide if no images
                        pnlImages.Visible = false;

                    if (_user[0].ImageCollection.Count > 0)
                        // Display if posts
                        DisplayRelatedPost();
                    else
                        // Hide if no posts
                        pnlPosts.Visible = false;
                }
            } else {
                Response.Redirect("Error.aspx");
            }
        }
    }

    /// <summary>
    /// Loads user data with a particular user id
    /// </summary>
    /// <param name="userId">a userId</param>
    private void LoadUser(int userId) {
        _user = new TravelUserCollection();
        _user.FetchForId(userId);
    }

    /// <summary>
    /// Displays user data
    /// </summary>
    private void DisplayUser() {

        // Hide personal data if required
        if (_user[0].Privacy.Equals("2"))
            _user[0].ShowPersonalData = false;

        // Databinds user to listview
        lvUserData.DataSource = _user;
        lvUserData.DataBind();
    }

    /// <summary>
    /// Displays images related to user
    /// </summary>
    private void DisplayRelatedImage() { ucxRelatedImages.CollectionImage = _user[0].ImageCollection; }

    /// <summary>
    /// Displays post related to user
    /// </summary>
    private void DisplayRelatedPost() { ucxRelatedPosts.CollectionPost = _user[0].PostCollection; }
}