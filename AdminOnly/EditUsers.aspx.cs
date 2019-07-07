using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

// <summary>
/// Represents a page for editing user information
/// </summary>
public partial class AdminOnly_EditUsers : System.Web.UI.Page {

    // Data fields
    private TravelUserCollection _collectionUser;

    /// <summary>
    /// Constructor
    /// </summary>
    public AdminOnly_EditUsers() { _collectionUser = new TravelUserCollection(); }

    /// <summary>
    /// Event handler for page_laod event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void Page_Load(object sender, EventArgs e) {

        if (!IsPostBack) {
            _collectionUser.FetchAllSorted(true);
            gvUser.DataSource = _collectionUser;
            gvUser.DataBind();
        }
    }

    /// <summary>
    /// Event handler for the gvUser_RowCommand event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e) {

        if (e.CommandName == "updateUser") {

            // Clear error message
            lbErrorMessage.Text = "";

            // Retrieve index of row generating event
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the id of the object bound to row
            hdnId.Value = gvUser.DataKeys[index].Values["Id"].ToString();

            // Fill textboxes
            tbFirstName.Text = gvUser.DataKeys[index].Values["FirstName"].ToString();
            tbLastName.Text = gvUser.DataKeys[index].Values["LastName"].ToString();
            tbAddress.Text = gvUser.DataKeys[index].Values["Address"].ToString();
            tbCity.Text = gvUser.DataKeys[index].Values["City"].ToString();
            tbRegion.Text = gvUser.DataKeys[index].Values["Region"].ToString();
            tbCountry.Text = gvUser.DataKeys[index].Values["Country"].ToString();
            tbPostal.Text = gvUser.DataKeys[index].Values["Postal"].ToString();
            tbPhone.Text = gvUser.DataKeys[index].Values["Phone"].ToString();
            tbEmail.Text = gvUser.DataKeys[index].Values["Email"].ToString();
            tbPrivacy.Text = gvUser.DataKeys[index].Values["Privacy"].ToString();

            pnlEditUser.Visible = true;
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e) {

        // If no errors regarding validation controls (property is st to true if all validation controls pass)
        if (Page.IsValid) {

            // Create a Travel User Object
            TravelUser user = new TravelUser();
            user.Id = Convert.ToInt32(hdnId.Value);
            user.FirstName = Convert.ToString(tbFirstName.Text);
            user.LastName = Convert.ToString(tbLastName.Text);
            user.Address = Convert.ToString(tbAddress.Text);
            user.City = Convert.ToString(tbCity.Text);
            user.Country = Convert.ToString(tbCountry.Text);
            user.Region = Convert.ToString(tbRegion.Text);
            user.Postal = Convert.ToString(tbPostal.Text);
            user.Phone = Convert.ToString(tbPhone.Text);
            user.Email = Convert.ToString(tbEmail.Text);
            user.Privacy = Convert.ToString(tbPrivacy.Text);

            // Update user details
            user.Update();

            // Hide edit user panel
            pnlEditUser.Visible = false;

            // Display updated list of users
            _collectionUser.FetchAllSorted(true);
            gvUser.DataSource = _collectionUser;
            gvUser.DataBind();

            lbErrorMessage.Text = "User details were successfully updated!";
        } else {
            lbErrorMessage.Text = "Fix errors before updating!";
        }


    }
}