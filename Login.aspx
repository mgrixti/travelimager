<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<%--Login Page Markup--%>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="Server">
    <asp:Panel ID="Panel1" runat="server" DefaultButton="siteLogin$LoginButton" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Log In</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:UpdatePanel ID="upLogin" runat="server">
                    <ContentTemplate>

                        <%--Login Area--%>
                        <asp:Login ID="siteLogin" runat="server" OnLoggedIn="siteLogin_LoggedIn" OnLoginError="siteLogin_LoginError">
                            <LayoutTemplate>
                                <table class="input-table">
                                    <tr>
                                        <td>User name:
                                        </td>
                                        <td>

                                            <asp:TextBox ID="UserName" runat="server" />
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" ErrorMessage="* User Name is required."
                                                runat="server" ControlToValidate="UserName" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Password:</td>
                                        <td>

                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" />
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ErrorMessage="* Password is required."
                                                ControlToValidate="Password" ForeColor="Red" />

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="RememberMe" runat="server" />
                                        </td>
                                        <td>Remember my login
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Button ID="LoginButton" CommandName="Login" runat="server" Text="Login" CssClass="btn btn-primary btn-xs" />
                                        </td>
                                        <td>
                                            <a href="Register.aspx">Create a new account</a></li>
                                        </td>
                                    </tr>
                                   
                                </table>
                                <br />
                                 <asp:Label ID="FailureText" runat="server" CssClass="failure" Visible="false" Text="* Login failed. Credentials are incorrect."/>
                            </LayoutTemplate>
                        </asp:Login>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </asp:Panel>
</asp:Content>

