<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Favorites.aspx.cs" Inherits="Favorites" %>

<%--Favorites Page Markup--%>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <%--Favorites Page Specific Data--%>

    <%--Ajax Panel--%>
    <asp:UpdatePanel ID="updFavorites" runat="server">
        <ContentTemplate>

            <%--Related Posts--%>
            <div class="section">
                <div class="col-md-12">
                    <h2>Favorite Image</h2>
                    <hr />
                    <asp:Label ID="lbImageErrorMessage" runat="server" />

                    <%--Image Grid User Control Markup--%>
                    <asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="false" CssClass="grid-table" ShowHeader="false" 
                        OnRowCommand="gvImage_RowCommand" DataKeyNames="Path,Id,Title">
                        <Columns>
                            <asp:ImageField DataImageUrlField="Path" DataImageUrlFormatString="~/travel-images/square-small/{0}" AlternateText="Title"/>
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SingleImage.aspx?id={0}" DataTextField="Title"
                                ControlStyle-CssClass="title" />
                            <asp:ButtonField CommandName="removeFavorite" Text="Remove" ControlStyle-CssClass="btn btn-danger btn-xs" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

            <%--Related Images--%>
            <div class="section">
                <div class="col-md-12">
                    <h2>Favorite Posts</h2>
                    <hr />
                    <asp:Label ID="lbPostErrorMessage" runat="server" />

                    <%--Post Gridview User Control Markup--%>
                    <asp:GridView ID="gvPost" runat="server" AutoGenerateColumns="false" CssClass="grid-table" ShowHeader="false"
                        OnRowCommand="gvPost_RowCommand" DataKeyNames="Id,Title">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="glyphicon glyphicon-th-list"></div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SinglePost.aspx?id={0}" DataTextField="Title"
                                ControlStyle-CssClass="title" />
                            <asp:ButtonField CommandName="removeFavorite" Text="Remove" ControlStyle-CssClass="btn btn-danger btn-xs" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>