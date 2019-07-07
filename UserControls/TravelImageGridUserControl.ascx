<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TravelImageGridUserControl.ascx.cs" Inherits="TravelImageGridUserControl" %>

<%--Image Grid User Control Markup--%>
<asp:GridView ID="gvImage" runat="server" AutoGenerateColumns="false" CssClass="grid-table" ShowHeader="false"
    DataKeyNames="Path,Id,Title">
    <Columns>
        <asp:ImageField DataImageUrlField="Path" DataImageUrlFormatString="~/travel-images/square-small/{0}" AlternateText="Title" />
        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SingleImage.aspx?id={0}" DataTextField="Title"
            ControlStyle-CssClass="title" />
    </Columns>
</asp:GridView>
