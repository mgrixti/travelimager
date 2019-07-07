using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();
        if (user != null)
        {
            acctDetailsLabel.Text = "User Name: " + user.UserName;
            acctDetailsLabel.Text += "<br/>Email: " + user.Email;
            acctDetailsLabel.Text += "<br/>Last login on: " + user.LastLoginDate.ToLocalTime();
        }
    }
}