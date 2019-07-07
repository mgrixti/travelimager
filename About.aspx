<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<%--About Page Markup--%>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    
    <%--About Page Specific Data--%>
    <div class="section">
        <div class="row">
            <div class="col-md-12">
                <h2>About Us</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <p>
                    This site is a hypothetical images website and was created as a term project for COMP 3512
                    at Mount Royal University taught by Randy Connolly.
                </p>
                <h3>Group Members</h3>
                <ul>
                    <li><strong>Vikas Bhagria:</strong>&nbsp;Implemented dataccess layer (DAL), user editing, review  system, business layer (BL), cascading style sheets (CSS), ASP page + masterpage markup, user controls, session facade class, jQuery functionality, etc. Assisted in implementing login and registration.</li>
                    <li><strong>Philip Young:</strong>&nbsp;Assisted in implementing DAL, user controls, and BL and overall page design. Implemented ASP page code behind, login, registration, mapping, flickr feed services, image carousel, etc.</li>
                    <li><strong>Matt Grixti:</strong>&nbsp;Assisted in implementing DAL, and BL and overall page design. Implemented ASP page code behind, website search, website deployment, error handling, session favorites, etc. Also, assisted in debugging CSS.</li>
                    <li><strong>Hosted site link:</strong> <a href="http://www.studentwebdev.com">http://www.studentwebdev.com</a>. Note: unfortunately we were unable to get login abilities working at time of hosting due to issues configuring the remote server on our hosting solution. We are looking into this issue.</li>
                </ul>
            </div>
        </div>
    </div>

</asp:Content>

