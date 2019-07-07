using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Represents a page for a single country
/// </summary>
public partial class SingleCountry : System.Web.UI.Page {

    // Data fields 
    private GeoCountryCollection _geoCountry;

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            if (QueryStringVerifier.IsValidISOAndIsNotNull(Request.QueryString["Id"])) {
                string iso = Request.QueryString["Id"];
                LoadCountry(iso);

                if (_geoCountry.Count > 0) {
                    DisplayCountry();

                    if (_geoCountry[0].ImageCollection.Count > 0) {
                        // Display images area if images
                        DisplayRelatedImage();
                    } else {
                        // Hide images area if no images
                        pnlImages.Visible = false;
                    }
                }
            } else {
                Response.Redirect("Error.aspx");
            }
        }
    }

    // <summary>
    /// Load country data
    /// </summary>
    /// <param name="iso">a iso</param>
    private void LoadCountry(string iso) {
        _geoCountry = new GeoCountryCollection();
        _geoCountry.FetchForId(iso);
    }

    // <summary>
    /// Displays country data
    /// </summary>
    private void DisplayCountry() {
        lvGeoCountry.DataSource = _geoCountry;
        lvGeoCountry.DataBind();
    }

    /// <summary>
    /// Displays related images
    /// </summary>
    private void DisplayRelatedImage() { ucxRelatedImages.CollectionImage = _geoCountry[0].ImageCollection; }
}