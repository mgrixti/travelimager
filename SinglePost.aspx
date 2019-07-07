<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SinglePost.aspx.cs" Inherits="SinglePost" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">

    <%--Post Data--%>
    <asp:ListView ID="lvPostData" runat="server" OnItemCommand="lvPostData_ItemCommand" DataKeyNames="Id,Title">
        <ItemTemplate>
            <div class="section">
                <div class="row">
                    <div class="col-md-9">
                        <h2><%# Eval("Title") %></h2>
                        <hr />
                        <p><strong>Date:</strong>&nbsp;<em><%# DateTime.Parse(Eval("PostTime").ToString()).ToString("MMM-dd-yyyy") %></em></p>
                        <p><strong>Posted By:</strong>&nbsp;<a href='./SingleUser.aspx?id=<%# Eval("UserID") %>'><%# Eval("FullName") %></a></p>
                        <p><%# Eval("Message").ToString().Replace("<p>", "").Replace("</p>", "") %></p>
                    </div>
                    <div class="col-md-3">
                        <span class="singlepost-favorite-button-area">
                            <asp:Button ID="btnFavorite" runat="server" CommandName="addFavorite" Text="Favorite" CssClass="btn btn-success btn-lg" />
                        </span>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <%--Related Posts--%>
    <asp:Panel ID="pnlImages" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Post Images</h2>
                <hr />
                <ucx:TravelImageBoxUC runat="server" ID="ucxRelatedImages" />
            </div>
        </div>
    </asp:Panel>

    <%--Related Posts--%>
    <asp:Panel ID="pnlPosts" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Other Posts By User</h2>
                <hr />
                <ucx:TravelPostGridUC runat="server" ID="ucxRelatedPosts" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
