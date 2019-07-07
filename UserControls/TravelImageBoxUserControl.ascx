<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TravelImageBoxUserControl.ascx.cs" Inherits="TravelImageBoxUserControl" %>

<%--Image Box User Control Markup--%>
<asp:ListView ID="lvImageBox" runat="server" 
    DataKeyNames="Id,Path,Title" OnItemCommand="rptImageBox_ItemCommand">
    <ItemTemplate>
        <div class="image-box">
            <a href='<%#Eval("Id","./SingleImage.aspx?id={0}") %>' title="<%# Eval("Title") %>">
                <img src='<%#Eval("Path","./travel-images/square-medium/{0}") %>' title="<%# Eval("Title") %>" alt="<%# Eval("Title") %>"/>
            </a>
            <p><%# Eval("Title") %></p>
            <a href='<%# Eval("Id","./SingleImage.aspx?Id={0}") %>' class="btn btn-xs btn-primary">View</a>
            <asp:Button ID="btnFavorite" runat="server" Text="Favorite" CssClass="btn btn-xs btn-primary"/>
        </div>
    </ItemTemplate>
</asp:ListView>

