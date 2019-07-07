using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

/// <summary>
/// Masterpage for website
/// </summary>
public partial class MasterPage : System.Web.UI.MasterPage {
    /// <summary>
    /// Event handler for page_load event 
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack) {
            GeoCityCollection col = new GeoCityCollection();
            col.FetchWhenImages();
            DataBindToDDLAccessMenu(col, "CityName", "Id");
            lbAccessMenu.Text = "Select a city";
        }
    }

    /// <summary>
    /// Eventhandler for the btnSearch_Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e) { Response.Redirect("Search.aspx?search=" + tbSearch.Text); }

    /// <summary>
    /// Event handler for the rbAccess_CheckedChanged event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void rbAccess_CheckedChanged(object sender, EventArgs e) {

        if (rbCity.Checked) {
            GeoCityCollection col = new GeoCityCollection();
            col.FetchWhenImages();
            DataBindToDDLAccessMenu(col, "CityName", "Id");
            lbAccessMenu.Text = "Select a city";
        } else if (rbCountry.Checked) {
            lbAccessMenu.Text = "Select a country";
            GeoCountryCollection col = new GeoCountryCollection();
            col.FetchWhenImages();
            DataBindToDDLAccessMenu(col, "CountryName", "Id");
        } else {

            if (rbContinent.Checked) {
                lbAccessMenu.Text = "Select a continent";
                GeoContinentCollection col = new GeoContinentCollection();
                col.FetchAll();
                DataBindToDDLAccessMenu(col, "ContinentName", "Id");
            }
        }
    }

    /// <summary>
    /// Helper for databinding drop down list
    /// </summary>
    /// <typeparam name="T">a type</typeparam>
    /// <param name="element">a element</param>
    /// <param name="text">a text</param>
    /// <param name="value">a value</param>
    private void DataBindToDDLAccessMenu<T>(T element, string text, string value) {
        ddlAccessMenu.DataTextField = text;
        ddlAccessMenu.DataValueField = value;
        ddlAccessMenu.DataSource = element;
        ddlAccessMenu.DataBind();
    }

    /// <summary>
    /// Event handler for btnImageMenu_Click event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void btnAccessMenu_Click(object sender, EventArgs e) {
        string url = "";

        if (rbCity.Checked) {
            url = "./SingleCity.aspx?Id=";
        } else if (rbCountry.Checked) {
            url = "./SingleCountry.aspx?Id=";
        } else {
            url = "./Search.aspx?Cont=";
        }

        Response.Redirect(url + ddlAccessMenu.SelectedValue);
    }
}
