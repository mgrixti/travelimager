using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Classes.Helper;

/// <summary>
/// Represents a page for a single city
/// </summary>
public partial class SingleCity : System.Web.UI.Page {

    // Data fields
    private GeoCityCollection _geoCity;

    /// <summary>
    /// Event handler for page_load event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack){
            if (QueryStringVerifier.IsNumberAndIsNotNull(Request.QueryString["Id"])) {
                int cityId = Convert.ToInt32(Request.QueryString["Id"]);
                LoadCity(cityId);

                if (_geoCity.Count > 0) {

                    DisplayCity();

                    if (_geoCity[0].ImageCollection.Count > 0)
                        DisplayRelatedImages();
                    else
                        pnlImages.Visible = false;
                }
            } else {
                Response.Redirect("./Error.aspx");
            }
        }
    }

    /// <summary>
    /// Loads city data
    /// </summary>
    /// <param name="cityId"></param>
    private void LoadCity(int cityId) {
        _geoCity = new GeoCityCollection();
        _geoCity.FetchForId(cityId);
    }

    /// <summary>
    /// Displays city data
    /// </summary>
    private void DisplayCity() {
        lvCityData.DataSource = _geoCity;
        lvCityData.DataBind();
    }

    /// <summary>
    /// Displays related images 
    /// </summary>
    private void DisplayRelatedImages() { ucxRelatedImages.CollectionImage = _geoCity[0].ImageCollection; }
}