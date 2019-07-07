using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Represents a page for a single post
/// </summary>
public partial class SinglePost : System.Web.UI.Page {

    // Data fields
    private TravelPostCollection _post;

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            if (QueryStringVerifier.IsNumberAndIsNotNull(Request.QueryString["Id"])) {
                int postId = Convert.ToInt32(Request.QueryString["Id"]);
                LoadPost(postId);

                if (_post.Count > 0) {
                    DisplayPost();

                    if (_post[0].ImageCollection.Count > 0)
                        // Display image area if images
                        DisplayRelatedImage();
                    else
                        // Hide image area if no images
                        pnlImages.Visible = false;

                    if (_post[0].User.PostCollection.Count > 0)
                        // Display post area if post
                        DisplayRelatedPost();
                    else
                        // Hide post area if no post
                        pnlImages.Visible = false;
                }
            } else {
                Response.Redirect("Error.aspx");
            }
        }
    }

    /// <summary>
    /// Loads post data
    /// </summary>
    /// <param name="postId">a post Id</param>
    private void LoadPost(int postId) {
        _post = new TravelPostCollection();
        _post.FetchForId(postId);
    }

    /// <summary>
    /// Displays post data
    /// </summary>
    private void DisplayPost() {
        lvPostData.DataSource = _post;
        lvPostData.DataBind();
    }

    /// <summary>
    /// Displays related images
    /// </summary>
    private void DisplayRelatedImage() { ucxRelatedImages.CollectionImage = _post[0].ImageCollection; }

    /// <summary>
    /// Displays related posts
    /// </summary>
    private void DisplayRelatedPost() {
        // Removes it self
        _post[0].User.PostCollection.Remove(_post[0]);
        ucxRelatedPosts.CollectionPost = _post[0].User.PostCollection; 
    }

    /// <summary>
    /// Event handler for the lvPostData_ItemCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void lvPostData_ItemCommand(object sender, ListViewCommandEventArgs e) {

        // Retrieve item which raised item command event
        ListViewItem item = (ListViewItem)e.Item;

        // Retrieve item index
        int index = Convert.ToInt32(item.DisplayIndex);

        // Initialize object
        TravelPost post = new TravelPost();
        post.Id = Convert.ToInt32(lvPostData.DataKeys[index].Values["Id"]); ;
        post.Title = lvPostData.DataKeys[index].Values["Title"].ToString(); ;

        // Save to session (favorites)
        FavoritesSessionFacade.Add(post);

        // Redirect to favorites page upon redirect
        Response.Redirect("./Favorites.aspx");

    }
}