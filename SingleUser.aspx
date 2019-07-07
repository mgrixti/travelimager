<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleUser.aspx.cs" Inherits="SingleUser" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <div class="section">
        <%--User Data--%>
        <asp:ListView ID="lvUserData" runat="server">
            <ItemTemplate>
                <div class="row">
                    <div class="col-md-12">
                        <h2><%# Eval("FirstName")%> <%# Eval("LastName")%></h2>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div class="singleuser-image-area">
                            <i class="glyphicon glyphicon-user"></i>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="singleuser-data-area">
                            <h3>User Details</h3>
                            <ul>
                                <li><strong>Address:</strong>&nbsp;<em> <%# Eval("Address") %></em></li>
                                <li><strong>City:</strong>&nbsp;<em> <%# Eval("City") %></em></li>
                                <li><strong>Region:</strong>&nbsp;<em> <%# Eval("Country") %></em></li>
                                <li><strong>Postal:</strong>&nbsp;<em> <%# Eval("Postal") %></em></li>
                                <li><strong>Phone:</strong>&nbsp;<em> <%# Eval("Phone") %></em></li>
                                <li><strong>Email:</strong>&nbsp;<em> <%# Eval("Email") %></em></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <%--Related Images--%>
    <asp:Panel ID="pnlImages" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>User Images</h2>
                <hr />
                <ucx:TravelImageBoxUC runat="server" ID="ucxRelatedImages" />
            </div>
        </div>
    </asp:Panel>
    
    <%--Related Posts--%>
    <asp:Panel ID="pnlPosts" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>User Posts</h2>
                <hr />
                <ucx:TravelPostGridUC runat="server" ID="ucxRelatedPosts" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>