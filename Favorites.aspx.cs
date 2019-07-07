using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Represents a favorites page
/// </summary>
public partial class Favorites : System.Web.UI.Page {

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            TravelImageCollection collectionImage = FavoritesSessionFacade.ImageCollection;
            TravelPostCollection collectionPost = FavoritesSessionFacade.PostCollection;

            if (collectionPost.Count > 0) {
                lbPostErrorMessage.Text = "";
                gvPost.DataSource = collectionPost;
                gvPost.DataBind();
            } else {
                lbPostErrorMessage.Text = "No favorited posts.";
            }

            if (collectionImage.Count > 0) {
                lbImageErrorMessage.Text = "";
                gvImage.DataSource = collectionImage;
                gvImage.DataBind();
            } else {
                lbImageErrorMessage.Text = "No favorited images.";
            }
        }
    }


    /// <summary>
    /// Event handler for the gvImage_RowCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void gvImage_RowCommand(object sender, GridViewCommandEventArgs e) {

        if (e.CommandName == "removeFavorite") {

            // Retrieve the row index
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the id of the object bound to row
            int id = Convert.ToInt32(gvImage.DataKeys[index].Values["Id"].ToString());

            // Create a temp image with same id
            TravelImage image = new TravelImage();
            image.Id = id;

            // Remove from session
            FavoritesSessionFacade.Remove(image);

            // Display message
            if (FavoritesSessionFacade.ImageCount() > 0)
                lbImageErrorMessage.Text = "";
            else
                lbImageErrorMessage.Text = "No favorited images.";

            // Rebind
            gvImage.DataSource = FavoritesSessionFacade.ImageCollection;
            gvImage.DataBind();
        }

    }

    /// <summary>
    /// Event handler for the gvPost_RowCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void gvPost_RowCommand(object sender, GridViewCommandEventArgs e) {

        if (e.CommandName == "removeFavorite") {

            // Retrieve index of row generating event
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the id of the object bound to row
            int id = Convert.ToInt32(gvPost.DataKeys[index].Values["Id"].ToString());

            // Create a temp post with same id
            TravelPost post = new TravelPost();
            post.Id = id;

            // Remove from session
            FavoritesSessionFacade.Remove(post);

            // Display message
            if (FavoritesSessionFacade.PostCount() > 0)
                lbPostErrorMessage.Text = "";
            else
                lbPostErrorMessage.Text = "No favorited posts.";

            // Rebind
            gvPost.DataSource = FavoritesSessionFacade.PostCollection;
            gvPost.DataBind();
        }
    }
}