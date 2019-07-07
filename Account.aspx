<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Account.aspx.cs" Inherits="Account" %>

<%--Account Page Markup--%>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="Server">
    <div class="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Account Details</h2>
                <hr />
                <p>
                    <asp:Label ID="acctDetailsLabel" runat="server"></asp:Label>
                </p>
            </div>
        </div>
    </div>
</asp:Content>

