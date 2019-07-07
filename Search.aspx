<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <asp:UpdatePanel ID="pnlSearch" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" CssClass="section" DefaultButton ="btnSearchAdvanced">
                <div class="row">
                    <div class="col-md-12">
                        <h2>Advanced Search</h2>
                        <hr />
                    </div>
                </div>
                <strong>Select Search Criteria:</strong>
                <br/>
                <p>
                    <asp:RadioButton ID="radByImage" GroupName="SearchBy" runat="server" Text=" Image" AutoPostBack="true" Checked="True" />&nbsp;&nbsp;
                    <asp:RadioButton ID="radByPost" GroupName="SearchBy" runat="server" Text=" Post" AutoPostBack="true" />&nbsp;&nbsp;
                    <asp:RadioButton ID="rabByBoth" GroupName="SearchBy" runat="server" Text=" Both" AutoPostBack="true" />
                </p>

                <asp:Panel runat="server" ID="pnlImageFilter">
                    <strong>Select Filter Criteria (For Images):</strong>
                    <br/>
                    <p>
                        <asp:RadioButton ID="radTitle" GroupName="filter" runat="server" Text=" Title" AutoPostBack="true" Checked="True" />&nbsp;&nbsp;
                        <asp:RadioButton ID="radCity" GroupName="filter" runat="server" Text=" City" AutoPostBack="true" />&nbsp;&nbsp;
                        <asp:RadioButton ID="radCountry" GroupName="filter" runat="server" Text=" Country" AutoPostBack="true" />
                    </p>
                    <span class="inline"><asp:DropDownList runat="server" ID="drpCity" AutoPostBack="true" CssClass="form-control" /></span>
                    <span class="inline"><asp:DropDownList runat="server" ID="drpCountry" CssClass="form-control" /></span>
                    <br />
                    <br />
                </asp:Panel>
                <span class="inline"><asp:TextBox runat="server" ID="txtSearch" PlaceHolder=" Search"  CssClass="form-control"/></span>
                <span class="inline"><asp:Button runat="server" ID="btnSearchAdvanced" Text="Search" OnClick="Page_Load" CssClass="btn btn-primary"/></span>
            </asp:Panel>

            <asp:Panel ID="pnlPost" runat="server" Visible="false" CssClass="section">
                <div class="row">
                    <div class="col-md-12">
                        <h2>Post Search Results</h2>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <strong>Select Order:</strong>
                        <p>
                            <asp:RadioButton ID="radPostAscend" GroupName="postOrder" runat="server" Text="&nbsp;Ascending Order" Checked="true" AutoPostBack="true" />&nbsp;&nbsp;
                            <asp:RadioButton ID="radPostDescend" GroupName="postOrder" runat="server" Text="&nbsp;Descending Order" AutoPostBack="true" />&nbsp;&nbsp;
                        </p>
                            <asp:Label runat="server" ID="lbPosts" Text="" />
                          <%--Post Grid User Control Markup--%>
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
                                    <asp:ButtonField CommandName="addFavorite" Text="Favorite" ControlStyle-CssClass="btn btn-primary btn-xs" />
                                </Columns>
                            </asp:GridView>
                        

                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="pnlImage" runat="server" Visible="false" CssClass="section">
                <div class="row">
                    <div class="col-md-12">
                        <h2>Image Search Results</h2>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <strong>Select Order:</strong>
                        <p>
                            <asp:RadioButton ID="radImageAscend" GroupName="imageOrder" runat="server" Text="&nbsp;Ascending Order" Checked="true" AutoPostBack="true" />&nbsp;&nbsp;
                            <asp:RadioButton ID="radImageDescend" GroupName="imageOrder" runat="server" Text="&nbsp;Descending Order" AutoPostBack="true" />&nbsp;&nbsp;
                        </p>
                        <asp:Label runat="server" ID="lbImages" Text="" />
                        
                        <%--Image Grid User Control Markup--%>
                        <asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="false" CssClass="grid-table" ShowHeader="false" OnRowCommand="gvImage_RowCommand"
                             DataKeyNames="Path,Id,Title">
                            <Columns>
                                <asp:ImageField DataImageUrlField="Path" DataImageUrlFormatString="~/travel-images/square-small/{0}" AlternateText="Title" />
                                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SingleImage.aspx?id={0}" DataTextField="Title"
                                    ControlStyle-CssClass="title" />
                                <asp:ButtonField CommandName="addFavorite" Text="Favorite" ControlStyle-CssClass="btn btn-primary btn-xs" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </asp:Panel>
       </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
