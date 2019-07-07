using Content.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Classes.Helper;

/// <summary>
/// Represents a page for a single images
/// </summary>
public partial class SingleImage : System.Web.UI.Page {

    // Data fields
    private TravelImageCollection _image;
    private TravelImageRatingCollection _collectionReview;
    private int _imageID;

    /// <summary>
    /// Event handler for the page load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (QueryStringVerifier.IsNumberAndIsNotNull(Request.QueryString["id"])) {

            // Retrieve _imageID on first page_load
            _imageID = Convert.ToInt32(Request.QueryString["id"]);

            if (!IsPostBack) {
                LoadImage();
                LoadReviews();

                if (_image.Count > 0) {

                    DisplayImage();

                    if (_collectionReview.Count > 0)
                        // Display image area if reviews
                        DisplayReviews();
                    else
                        // Hide area if no reviews
                        pnlImagesReview.Visible = false;

                    if (_image[0].Country.ImageCollection.Count > 0)
                        // Display image area if images
                        DisplayRelatedImageCountry();
                    else
                        // Hide image area if no images
                        pnlImagesCountry.Visible = false;

                    if (_image[0].Post.ImageCollection.Count > 0)
                        // Display image area if posts
                        DisplayRelatedImagePost();
                    else
                        // Hide post area if no posts
                        pnlImagesPost.Visible = false;


                    if (_image[0].City != null)
                        ucxFlickrImages.SearchFor = _image[0].CityName + " Vacation";
                    else
                        pnlFlickr.Visible = false;
                    
                }
            }

        } else {
            Response.Redirect("./Error.aspx");
        }
    }

    /// <summary>
    /// Loads image data for a particular image id
    /// </summary>
    private void LoadImage() {
        _image = new TravelImageCollection();
        _image.FetchForId(_imageID);
    }

    /// <summary>
    /// Loads reviews for a particular image id
    /// </summary>
    private void LoadReviews() {
        _collectionReview = new TravelImageRatingCollection();
        _collectionReview.FetchForImage(_imageID);
    }

    /// <summary>
    /// Displays reviews for a particular image id
    /// </summary>
    private void DisplayReviews() {
        lvImagesReview.DataSource = _collectionReview;
        lvImagesReview.DataBind();
    }

    /// <summary>
    /// Displays image
    /// </summary>
    private void DisplayImage() {
        lvImageData.DataSource = _image;
        lvImageData.DataBind();
    }

    /// <summary>
    /// Displays images related to same country
    /// </summary>
    private void DisplayRelatedImageCountry() {
        // Remove the page image from collection
        _image[0].Country.ImageCollection.Remove(_image[0]);
        ucxRelatedImagesCountry.CollectionImage = _image[0].Country.ImageCollection;
    }

    /// <summary>
    /// Displays images related to same post
    /// </summary>
    private void DisplayRelatedImagePost() {
        // Remove page image from collection
        _image[0].Post.ImageCollection.Remove(_image[0]);
        ucxRelatedImagesPost.CollectionImage = _image[0].Post.ImageCollection;
    }

    /// <summary>
    /// Event handler for lvImageData_ItemCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void lvImageData_ItemCommand(object sender, ListViewCommandEventArgs e) {

        // Retrieve item which raised item command event
        ListViewItem item = (ListViewItem)e.Item;

        if (e.CommandName.Equals("addFavorite")) {

            // Add image to session
            AddImageToFavorites(item);

            // Redirect to favorites page upon adding 
            Response.Redirect("./Favorites.aspx");

        } else if (e.CommandName.Equals("enableReviewEntry")) {

            // Enable reveiw entry panel
            EnableReviewEntry(item);

        } else {

            if (e.CommandName.Equals("addReview")) {

                AddReview(item);

                // Hide review panel
                Panel pnlAddReview = (Panel)item.FindControl("pnlAddReview");
                pnlAddReview.Visible = false;
            }
        }
    }

    /// <summary>
    /// Event handler for the lvImageData_ItemDataBound event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void lvImageData_ItemDataBound(object sender, ListViewItemEventArgs e) {

        ListViewItem item = (ListViewItem)e.Item;

        if (User.IsInRole("administrator") || User.IsInRole("visitor")) {
            ShowReviewButton(item);
        }

        if (_image[0].City == null) {
            // Hide Map
            Panel pnlMap = (Panel)item.FindControl("pnlMap");
            pnlMap.Visible = false;

        }
    }

    /// <summary>
    /// Helper shows review button
    /// </summary>
    /// <param name="item">a item</param>
    private void ShowReviewButton(ListViewItem item) {

        // Find button in listview
        Button button = (Button)item.FindControl("btnReview");

        // Make button visible
        button.Visible = true;
    }

    private void EnableReviewEntry(ListViewItem item) {

        if (!HasUserPreviouslyReviewedImage(User.Identity.Name)) {
            // Display review panel
            Panel pnlAddReview = (Panel)item.FindControl("pnlAddReview");
            pnlAddReview.Visible = true;
        } else {
            // Display error message: already Reviewed imge
            lbError.Text = "You can only review an image once.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

        }
    }

    /// <summary>
    /// Helper checks to see if user already reviewed image
    /// </summary>
    /// <param name="userName">a userName</param>
    /// <returns>bool true/false value</returns>
    private bool HasUserPreviouslyReviewedImage(string userName) {

        // Load reviews
        TravelImageRatingCollection col = new TravelImageRatingCollection();
        col.FetchForImage(_imageID);

        // Check if user already review
        foreach (TravelImageRating review in col) { if (review.UserName.Equals(userName))  return true; }
        return false;
    }

    /// <summary>
    /// Helper adds image to favorites
    /// </summary>
    /// <param name="item"></param>
    private void AddImageToFavorites(ListViewItem item) {
        // Retrieve item index
        int index = Convert.ToInt32(item.DisplayIndex);

        // Initialize object
        TravelImage image = new TravelImage();
        image.Id = Convert.ToInt32(lvImageData.DataKeys[index].Values["Id"]); ;
        image.Title = lvImageData.DataKeys[index].Values["Title"].ToString();
        image.Path = lvImageData.DataKeys[index].Values["Path"].ToString();

        // Save to session (favorites)
        FavoritesSessionFacade.Add(image);
    }

    private void AddReview(ListViewItem item) {

        if (Page.IsValid) {
            // Insert review into database
            InsertReviewIntoDatabase(item);

            // Reload collection
            LoadReviews();

            // Display collection
            DisplayReviews();

            // Update Image Rating
            LoadImage();

            // Display New Image Rating
            DisplayImage();

            // Display message
            lbError.Text = "A new review was added!";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
        }
    }

    // <summary>
    /// Helper inserts revew intoto database
    /// </summary>
    /// <param name="item"></param>
    private void InsertReviewIntoDatabase(ListViewItem item) {

        // Find text boxes within list view
        TextBox tempRating = (TextBox)item.FindControl("tbRating");
        TextBox tempComment = (TextBox)item.FindControl("tbComment");

        // Create travel image rating object
        TravelImageRating rating = new TravelImageRating();
        rating.ImageID = _imageID;
        rating.Rating = Convert.ToInt32(tempRating.Text);
        rating.ReviewDate = DateTime.Now.ToString("MMM-dd-yyyy");

        // Comments which are empty will be stored as empty strings
        rating.Comment = Convert.ToString(tempComment.Text);

        rating.UserName = User.Identity.Name;

        // Insert into database
        rating.Insert();
    }

    /// <summary>
    /// Event handler for the lvImagesReview_ItemCommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lvImagesReview_ItemCommand(object sender, ListViewCommandEventArgs e) {

        // Retrieve item which raised item command event
        ListViewItem item = (ListViewItem)e.Item;

        if (e.CommandName.Equals("remove")) RemoveReview(item);
    }

    /// <summary>
    /// Event handler for the lvImagesReview_ItemDataBound command
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void lvImagesReview_ItemDataBound(object sender, ListViewItemEventArgs e) {

        ListViewItem item = (ListViewItem)e.Item;

        if (User.IsInRole("administrator")) {
            ShowRemoveButton(item);
        }
    }

    /// <summary>s
    /// Helper shows review button
    /// </summary>
    /// <param name="item">a item</param>
    private void ShowRemoveButton(ListViewItem item) {

        // Find button in listview
        Button button = (Button)item.FindControl("btnRemoveReview");

        // Make button visible
        button.Visible = true;
    }

    /// <summary>
    /// Helper handles review removing procedure
    /// </summary>
    /// <param name="item"></param>
    private void RemoveReview(ListViewItem item) {
        // Remove review from database
        DeleteReviewFromDatabase(item);

        // Update Image Rating
        LoadImage();

        // Display New Image Rating
        DisplayImage();

        // Reload collection
        LoadReviews();

        // Display collection
        DisplayReviews();

        // Display message
        lbError.Text = "A review was removed!";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);

    }

    /// <summary>
    /// Helper deletes a review from database
    /// </summary>
    /// <param name="item">a item</param>
    private void DeleteReviewFromDatabase(ListViewItem item) {

        // Retrieve item index
        int index = Convert.ToInt32(item.DisplayIndex);

        // Initialize object
        TravelImageRating rating = new TravelImageRating();
        rating.Id = Convert.ToInt32(lvImagesReview.DataKeys[index].Values["Id"]); ;

        // Delete from database
        rating.Delete();
    }

    /// <summary>
    /// Gets properly formatted date.
    /// </summary>
    /// <param name="date">a date</param>
    /// <returns>string date</returns>
    public string GetDateMessage(string date) {

        if (!String.IsNullOrEmpty(date)) { return DateTime.Parse(date).ToString("MMM-dd-yyyy"); }
        return "No Date";
    }

    /// <summary>
    /// Gets properly formatted comment.
    /// </summary>
    /// <param name="comment">a comment</param>
    /// <returns>string comment</returns>
    public string GetCommentMessage(string comment) {
        if (!String.IsNullOrEmpty(comment)) { return comment; }
        return "No comment";
    }

    /// <summary>
    /// Gets properly formatted user.
    /// </summary>
    /// <param name="user">a user</param>
    /// <returns>string user</returns>
    public string GetUserMessage(string user) {
        if (!String.IsNullOrEmpty(user)) { return user; }
        return "No User";
    }
}