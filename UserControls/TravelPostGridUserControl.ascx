<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TravelPostGridUserControl.ascx.cs" Inherits="TravelPostGridUserControl" %>
<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>

<%--Post Gridview User Control Markup--%>
<asp:GridView ID="gvPost" runat="server" AutoGenerateColumns="false" CssClass="grid-table" ShowHeader="false" DataKeyNames="Id,Title">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <div class="glyphicon glyphicon-th-list"></div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SinglePost.aspx?id={0}" DataTextField="Title" 
            ControlStyle-CssClass="title" />
    </Columns>
</asp:GridView>
