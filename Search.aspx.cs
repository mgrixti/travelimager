using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Search page
/// </summary>
public partial class Search : System.Web.UI.Page {
    private TravelImageCollection _TICollection = new TravelImageCollection();
    private TravelPostCollection _TPCollection = new TravelPostCollection();

    /// <summary>
    /// Event handler for Page_Load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e) {
        DisplayForm();
        pnlImage.Visible = false;
        pnlPost.Visible = false;
        lbImages.Text = "";
        lbPosts.Text = "";


        if (!IsPostBack) {
            loadCityLists();
            loadCountryList();

            if (QueryStringVerifier.IsValidISOAndIsNotNull(Request.QueryString["Cont"])) {
                _TICollection.FetchForContinent(Request.QueryString["Cont"], radImageAscend.Checked);
                gvImage.DataSource = _TICollection;
                gvImage.DataBind();
                pnlImage.Visible = true;
            } else if (QueryStringVerifier.IsNotNull(Request.QueryString["search"])) {
                txtSearch.Text = Request.QueryString["search"];
                FetchSearchResults();
            }
        } else if (txtSearch.Text != "" || ((radCity.Checked || radCountry.Checked) && radByImage.Checked)) {
            FetchSearchResults();
        }
    }

    #region loadDropDown
    protected void loadCityLists() {
        GeoCityCollection GCityCollection = new GeoCityCollection();
        GCityCollection.FetchWhenImages();

        drpCity.DataTextField = "CityName";
        drpCity.DataValueField = "id";
        drpCity.DataSource = GCityCollection;
        drpCity.DataBind();
    }

    protected void loadCountryList() {
        GeoCountryCollection GCountryCollection = new GeoCountryCollection();
        GCountryCollection.FetchWhenImages();

        drpCountry.DataTextField = "CountryName";
        drpCountry.DataValueField = "id";
        drpCountry.DataSource = GCountryCollection;
        drpCountry.DataBind();
    }

    #endregion

    /// <summary>
    /// Displays forms elements relevent to search type selected by user
    /// </summary>
    private void DisplayForm() {
        //Display form elements based on search user would like to do
        if (radByImage.Checked) {
            pnlImageFilter.Visible = true;

            if (radCity.Checked) {
                txtSearch.Visible = false;
                drpCity.Visible = true;
                drpCountry.Visible = false;
            } else if (radCountry.Checked) {
                txtSearch.Visible = false;
                drpCity.Visible = false;
                drpCountry.Visible = true;
            } else {
                txtSearch.Visible = true;
                drpCity.Visible = false;
                drpCountry.Visible = false;
            }
        } else {
            txtSearch.Visible = true;
            pnlImageFilter.Visible = false;
        }
    }

    /// <summary>
    /// Retrieves and binds data from search
    /// </summary>
    private void FetchSearchResults() {

        bool imgAscend = radImageAscend.Checked;
        bool postAscend = radPostAscend.Checked;

        if (radByImage.Checked) {
            _TICollection = new TravelImageCollection();
            pnlImage.Visible = true;
            if (radCity.Checked) {
                //Fetch Images for city selected
                _TICollection.FetchForCity(Convert.ToInt32(drpCity.SelectedValue), imgAscend);
            } else if (radCountry.Checked) {
                //Fetch images for country selected
                _TICollection.FetchForCountry(drpCountry.SelectedValue, imgAscend);
            } else {
                //Fetch Images for by text search

                _TICollection.FetchLikeTitle(txtSearch.Text, imgAscend);
            }
        } else if (radByPost.Checked) {
            //Fetch posts for search term
            _TPCollection = new TravelPostCollection();
            _TPCollection.FetchLikeTitle(txtSearch.Text, postAscend);
            pnlPost.Visible = true;
        } else {
            _TICollection = new TravelImageCollection();
            _TPCollection = new TravelPostCollection();

            //Fetch posts for search term
            _TPCollection.FetchLikeTitle(txtSearch.Text, postAscend);

            //Fetch images for search term
            _TICollection.FetchLikeTitle(txtSearch.Text, imgAscend);

            pnlImage.Visible = true;
            pnlPost.Visible = true;
        }

        //Make sure there is a collection
        if (_TPCollection.Count > 0) {
            gvPost.DataSource = _TPCollection;
            gvPost.DataBind();
        } else {
            lbPosts.Text = "Sorry, no search results found for posts.";
            gvPost.DataSource = _TPCollection;
            gvPost.DataBind();
        }

        if (_TICollection.Count > 0) {
            gvImage.DataSource = _TICollection;
            gvImage.DataBind();
        } else {
            lbImages.Text = "Sorry, no search results found for images.";
            gvImage.DataSource = _TICollection;
            gvImage.DataBind();
        }
    }


    /// <summary>
    /// Event handler for the gvPost_RowCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void gvPost_RowCommand(object sender, GridViewCommandEventArgs e) {

        if (e.CommandName == "addFavorite") {

            // Retrieve index of row generating event
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the id of the object bound to row
            int id = Convert.ToInt32(gvPost.DataKeys[index].Values["Id"].ToString());

            // Initialize object
            TravelPost post = new TravelPost();
            post.Id = id;
            post.Title = gvPost.DataKeys[index].Values["Title"].ToString();

            // Add to session
            FavoritesSessionFacade.Add(post);

            // Redirect to favorites page
            Response.Redirect("./Favorites.aspx");
        }
    }

    /// <summary>
    /// Event handler for the gvImage_RowCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void gvImage_RowCommand(object sender, GridViewCommandEventArgs e) {
        
        if (e.CommandName == "addFavorite") {

            // Retrieve index of row generating event
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the id of the object bound to row
            int id = Convert.ToInt32(gvImage.DataKeys[index].Values["Id"].ToString());

            // Initialize object
            TravelImage image = new TravelImage();
            image.Id = id;
            image.Title = gvImage.DataKeys[index].Values["Title"].ToString();
            image.Path = gvImage.DataKeys[index].Values["Path"].ToString();

            // Add to session
            FavoritesSessionFacade.Add(image);

            // Redirect to favorites page
            Response.Redirect("./Favorites.aspx");
        }

    }
}
