using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Represents a login page
/// </summary>
public partial class Login : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }

    /// <summary>
    /// Event handler for the siteLogin_LoggedIn event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void siteLogin_LoggedIn(object sender, EventArgs e) {
        Response.Redirect("./Default.aspx");
    }

    /// <summary>
    /// Event handler for the siteLogin_LoginError event
    /// </summary>
    /// <param name="sender">a sender</param>
    /// <param name="e">a e</param>
    protected void siteLogin_LoginError(object sender, EventArgs e) {
        Label lbFailure = (Label)siteLogin.FindControl("FailureText");
        lbFailure.Visible = true;
    }

}