<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleCountry.aspx.cs" Inherits="SingleCountry" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
    <%--Country Data--%>
    <asp:ListView ID="lvGeoCountry" runat="server">
        <ItemTemplate>

            <div class="section">
                <div class="row">
                    <div class="col-md-12">
                        <span class="singlecountry-flag-area">
                            <img src='flags/flat/64/<%# Eval("Id") %>.png' class="img-responsive" />
                            <h2><%# Eval("CountryName") %></h2>
                        </span>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10">
                        <div class="singlecountry-image-area">
                            <p><%# Eval("CountryDescription") %></p>
                        </div>
                    </div>
                </div>
            </div>

            <div class="section">
                <div class="row">
                    <div class="col-md-12">
                        <h2>Country Details</h2>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="data-table">
                            <table>
                                <tr>
                                    <th>Capital</th>
                                    <th>Area</th>
                                    <th>Population</th>
                                    <th>Currency Code</th>
                                </tr>
                                <tr>
                                    <td><%# Eval("Capital") %></td>
                                    <td><%# Eval("Area" , "&nbsp;{0}km&sup2;") %></td>
                                    <td><%# Eval("Population") %></td>
                                    <td><%# Eval("CurrencyCode") %></td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

        </ItemTemplate>
    </asp:ListView>
    <%--Related Images--%>
    <asp:Panel ID="pnlImages" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Images From Country</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lbErrorMessage" runat="server" />
                <ucx:TravelImageBoxUC runat="server" ID="ucxRelatedImages" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
