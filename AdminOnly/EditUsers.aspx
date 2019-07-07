<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditUsers.aspx.cs" Inherits="AdminOnly_EditUsers" %>

<%--Edit Users Markup--%>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="Server">
    <div class="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Edit Users</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:UpdatePanel ID="upEditUsers" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lbErrorMessage" CssClass="success" runat="server"></asp:Label>
                        <asp:Panel ID="pnlEditUser" runat="server" Visible="false">
                            <h3>Update User Information</h3>
                            <asp:HiddenField ID="hdnId" runat="server" />
                            <table class="input-table">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbFirstName" runat="server" Text="FirstName:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbFirstName" runat="server"></asp:TextBox>
                                    </td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbLastName" runat="server" Text="LastName:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbLastName" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="tbLastName" ErrorMessage="* Enter last name." ForeColor="Red" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbPhone" runat="server" Text="Phone:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbPhone" runat="server"></asp:TextBox></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbAddress" runat="server" Text="Address:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbAddress" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="tbAddress" ErrorMessage="* Enter address." ForeColor="Red" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbCity" runat="server" Text="City:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbCity" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="tbCity" ErrorMessage="* Enter city." ForeColor="Red" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbRegion" runat="server" Text="Region:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbRegion" runat="server"></asp:TextBox></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbCountry" runat="server" Text="Country:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbCountry" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                            ControlToValidate="tbCountry" ErrorMessage="* Enter country." ForeColor="Red" />
                                    <tr>
                                        <td>
                                            <asp:Label ID="lbPostal" runat="server" Text="Postal:&nbsp;" /></td>
                                        <td>
                                            <asp:TextBox ID="tbPostal" runat="server"></asp:TextBox></td>
                                        <td></td>
                                    </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbEmail" runat="server" Text="Email:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                            ControlToValidate="tbEmail" ErrorMessage="* Enter email address." ForeColor="Red" Display="Dynamic" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                            ControlToValidate="tbEmail" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
                                            ErrorMessage="* Incorrect email format." ForeColor="Red" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbPrivacy" runat="server" Text="Privacy:&nbsp;" /></td>
                                    <td>
                                        <asp:TextBox ID="tbPrivacy" runat="server"></asp:TextBox></td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                            ControlToValidate="tbPrivacy" ErrorMessage="* Enter privacy setting." ForeColor="Red" />
                                        <asp:CompareValidator ID="cvPrivacy" runat="server" ControlToValidate="tbPrivacy" Type="Integer" Display="Dynamic"
                                            Operator="DataTypeCheck" ForeColor="Red" ErrorMessage="Privacy must be an number!" />

                                    </td>
                                </tr>
                            </table>

                            <br />
                            <br />
                            <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" CssClass="btn btn-primary" />
                            <hr />
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="upUsers" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="false"
                            CssClass="grid-table" ShowHeader="false" DataKeyNames="Id,FirstName,LastName,Address,City,Country,Region,Postal,Phone,Email,Privacy"
                            OnRowCommand="gvUser_RowCommand">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <div class="glyphicon glyphicon-user"></div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SingleUser.aspx?id={0}" DataTextField="FullName"
                                    ControlStyle-CssClass="title" />
                                <asp:ButtonField ButtonType="Button" CommandName="updateUser" Text="Edit" ControlStyle-CssClass="btn btn-danger btn-xs" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

