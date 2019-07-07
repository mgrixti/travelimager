<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TravelUserGridUserControl.ascx.cs" Inherits="TravelUserGridUserControl" %>
<%--<%@ OutputCache Duration="120" VaryByParam="None" %>--%>

<%--User Gridview User Control Markup--%>
<asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="false"
    CssClass="grid-table" ShowHeader="false">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <div class="glyphicon glyphicon-user"></div>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/SingleUser.aspx?id={0}" DataTextField="FullName" 
            ControlStyle-CssClass="title" />
    </Columns>
</asp:GridView>
