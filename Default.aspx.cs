using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

/// <summary>
/// Represents the default page
/// </summary>
public partial class _Default : System.Web.UI.Page {

    // Data fields
    private TravelImageCollection _images;
    private TravelImageRatingCollection _collectionReview;

    /// <summary>
    /// Event handler for the page_laod event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            LoadTopRatedImages();
            if (_images.Count > 0) DisplayTopRatedImages();

            LoadNewAdditionImages();
            if (_images.Count > 0) DisplayNewAdditionImages();

            LoadNewAdditionReviews();
            if (_collectionReview.Count > 0) DisplayNewAdditionReviews();
        }
    }

    /// <summary>
    /// Loads top rated images
    /// </summary>
    private void LoadTopRatedImages() {
        _images = new TravelImageCollection();
        _images.FetchTopRated(8); 
    }

    /// <summary>
    /// Loads new addition images
    /// </summary>
    private void LoadNewAdditionImages() {
        _images = new TravelImageCollection();
        _images.FetchTop(8, false); 
    }

    /// <summary>
    /// Displays top rated images
    /// </summary>
    private void DisplayTopRatedImages() { ucxTopRatedImages.CollectionImage = _images; }

    /// <summary>
    /// Displays new addition images
    /// </summary>
    private void DisplayNewAdditionImages() { ucxNewAdditionImages.CollectionImage = _images; }

    /// <summary>
    /// Loads reviews for a particular image id
    /// </summary>
    private void LoadNewAdditionReviews() {
        _collectionReview = new TravelImageRatingCollection();
        _collectionReview.FetchTop(2, false);
    }

    /// <summary>
    /// Displays reviews for a particular image id
    /// </summary>
    private void DisplayNewAdditionReviews() {
        lvImagesReview.DataSource = _collectionReview;
        lvImagesReview.DataBind();
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

        string tempComment = "";

        if (!String.IsNullOrEmpty(comment)) {

            if (comment.Length > 100) {
                tempComment = comment.Substring(0,100);
                tempComment += " ...Click to Read More";
            } else {
                tempComment = comment;
            }

        } else {
            tempComment = "No comment";
        }

        return tempComment;
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