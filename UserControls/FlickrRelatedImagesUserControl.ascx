<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlickrRelatedImagesUserControl.ascx.cs" Inherits="UserControls_WebUserControl" %>
<div>
    <asp:DataList ID="dlstPhotos" runat="server" RepeatColumns="6">
        <ItemTemplate>
            <a href="<%# Eval ("Link") %>" class="preview" target="_blank">
                <img src="<%#Eval("Url") %>" alt="Flickr image" />
            </a>
        </ItemTemplate>
    </asp:DataList>
    <asp:Panel ID="panError" runat="server" CssClass="error">
        <asp:Label ID="labMessage" runat="server" />
    </asp:Panel>
</div>
