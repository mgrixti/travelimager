using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Represent a browse page
/// </summary>
public partial class Browse : System.Web.UI.Page {

    // Data fields
    private TravelImageCollection _collectionImages;
    private TravelPostCollection _collectionPosts;
    private TravelUserCollection _collectionUsers;

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        string queryString = Request.QueryString["type"];

        if (!IsPostBack) {
            if (QueryStringVerifier.IsNotNull(queryString)) {


                if (queryString == "images") {
                    rbNormal.Checked = true;
                    pnlBrowseCriteria.Visible = true;
                    _collectionImages = new TravelImageCollection();
                    _collectionImages.FetchAllSorted(true);
                    gvImage.DataSource = _collectionImages;
                    gvImage.DataBind();
                } else if (queryString == "posts") {
                    _collectionPosts = new TravelPostCollection();
                    _collectionPosts.FetchAllSorted(true);
                    ucTravelPostGrid.CollectionPost = _collectionPosts;
                } else {
                    if (queryString == "users") {
                        _collectionUsers = new TravelUserCollection();
                        _collectionUsers.FetchAllSorted(true);
                        ucTravelUserGrid.CollectionUser = _collectionUsers;
                    }
                }
                lbHeading.Text = queryString.Substring(0, 1).ToUpper() + queryString.Substring(1);
            }
        }

    }

    /// <summary>
    /// Event handler for the rbBrowseCriteria_CheckedChanged event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void rbBrowseCriteria_CheckedChanged(object sender, EventArgs e) {

        ddlBrowseCriteria.Visible = true;
        btnBrowseCriteria.Visible = true;

        _collectionImages = new TravelImageCollection();

        if (rbContinent.Checked) {
            GeoContinentCollection col = new GeoContinentCollection();
            col.FetchAllSorted(true);
            gvImage.DataSource = _collectionImages;
            DataBindToDDLAccessMenu(col, "ContinentName", "Id");
            lbBrowseCriteria.Text = "Select a continent:";
        } else if (rbCountry.Checked) {
            GeoCountryCollection col = new GeoCountryCollection();
            col.FetchWhenImages();
            gvImage.DataSource = _collectionImages;
            DataBindToDDLAccessMenu(col, "CountryName", "Id");
            lbBrowseCriteria.Text = "Select a country:";
        } else {
            if (rbNormal.Checked) {
                _collectionImages.FetchAllSorted(true);
                gvImage.DataSource = _collectionImages;
                ddlBrowseCriteria.Visible = false;
                btnBrowseCriteria.Visible = false;
                lbBrowseCriteria.Text = "";
            }
        }
        gvImage.DataBind();
    }

    /// <summary>
    /// Helper for databinding drop down list
    /// </summary>
    /// <typeparam name="T">a type</typeparam>
    /// <param name="element">a element</param>
    /// <param name="text">a text</param>
    /// <param name="value">a value</param>
    private void DataBindToDDLAccessMenu<T>(T element, string text, string value) {
        ddlBrowseCriteria.DataTextField = text;
        ddlBrowseCriteria.DataValueField = value;
        ddlBrowseCriteria.DataSource = element;
        ddlBrowseCriteria.DataBind();
    }

    protected void btnBrowseCriteria_Click(object sender, EventArgs e) {
        TravelImageCollection col = new TravelImageCollection();

        if (rbContinent.Checked) { col.FetchForContinent(Convert.ToString(ddlBrowseCriteria.SelectedValue), true); }

        if (rbCountry.Checked) { col.FetchForCountry(Convert.ToString(ddlBrowseCriteria.SelectedValue), true); }

        gvImage.DataSource = col;
        gvImage.DataBind();
    }
}