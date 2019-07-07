<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Browse.aspx.cs" Inherits="Browse" %>

<%--Browse Page Markup--%>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <%--Ajax Panel--%>
    <asp:UpdatePanel runat="server" ID="upBrowse">
        <ContentTemplate>
            <%--Browse Page Specific Data--%>

            <%--Browse Travel Image Criteria--%>
            <asp:Panel ID="pnlBrowseCriteria" runat="server" CssClass="section" Visible="false">

                <div class="row">
                    <div class="col-md-12">
                        <h2>Browse Criteria</h2>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:RadioButton ID="rbNormal" runat="server" Text="&nbsp;All"
                            GroupName="rbBrowseCriteria" OnCheckedChanged="rbBrowseCriteria_CheckedChanged" AutoPostBack="true" />
                        <asp:RadioButton ID="rbContinent" runat="server" Text="&nbsp;Continent"
                            GroupName="rbBrowseCriteria" OnCheckedChanged="rbBrowseCriteria_CheckedChanged" AutoPostBack="true" />
                        <asp:RadioButton ID="rbCountry" runat="server" Text="&nbsp;Country"
                            GroupName="rbBrowseCriteria" OnCheckedChanged="rbBrowseCriteria_CheckedChanged" AutoPostBack="true" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <asp:Label ID="lbBrowseCriteria" runat="server" />
                        <br />
                        <br />
                        <span class="inline">
                            <asp:DropDownList ID="ddlBrowseCriteria" runat="server" CssClass="form-control" Visible="false" /></span>
                        <br />
                        <br />
                        <asp:Button ID="btnBrowseCriteria" runat="server" Text="Filter" OnClick="btnBrowseCriteria_Click" CssClass="btn btn-primary" Visible="false" />
                    </div>
                </div>
            </asp:Panel>

            <div class="section">
                <div class="row">
                    <div class="col-md-12">
                        <h2>Browse&nbsp;<asp:Label ID="lbHeading" runat="server"></asp:Label></h2>
                        <hr />
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-12">
                        <ucx:TravelUserGridUC ID="ucTravelUserGrid" runat="server" />
                        <ucx:TravelPostGridUC ID="ucTravelPostGrid" runat="server" />

                        <%--Image Grid User Control Markup--%>
                        <asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="false" CssClass="grid-table" ShowHeader="false">
                            <Columns>
                                <asp:ImageField DataImageUrlField="Path" DataImageUrlFormatString="~/travel-images/square-small/{0}" AlternateText="Title" />
                                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SingleImage.aspx?id={0}" DataTextField="Title"
                                    ControlStyle-CssClass="title" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

