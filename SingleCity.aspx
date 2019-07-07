<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleCity.aspx.cs" Inherits="SingleCity" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">
   
     <%--City Data--%>
    <asp:ListView ID="lvCityData" runat="server">
        <ItemTemplate>

            <div class="section">
                <div class="row">
                    <div class="col-md-12">
                        <h2><%#Eval("CityName")%></h2>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10">
                        <div class="panel-group" id="mapAccordion">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h4 class="panel-title">
                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Find on map
                                        </a>
                                    </h4>
                                </div>
                                <div id="collapseOne" class="panel-collapse collapse on">
                                    <%--Bing Maps Javascript--%>
                                    <script type="text/javascript">
                                        window.onload = function () {
                                            function GetMap(latitude, longitude) {
                                                var center = new Microsoft.Maps.Location(latitude, longitude);
                                                var map = new Microsoft.Maps.Map(document.getElementById("mapDiv"), {
                                                    credentials: "ArZ1TCkJtwm3u1Nuf8eJZoXUSvUqm1Fouor1IifKlazUvvTkhwbWcWjC3x_ZdQ0K",
                                                    center: new Microsoft.Maps.Location(latitude, longitude),
                                                    mapTypeId: Microsoft.Maps.MapTypeId.road,
                                                    zoom: 10
                                                });
                                                var pin = new Microsoft.Maps.Pushpin(center, { icon: "images/BluePushpin.png", height: 50, width: 50, draggable: true });
                                                map.entities.push(pin);
                                            }
                                            $("#mapAccordion").on('shown.bs.collapse', function () {
                                                    GetMap('<%#Eval("Latitude")%>', '<%#Eval("Longitude")%>');                                                
                                              });
                                        }
                                    </script>
                                    <div id='mapDiv' style="position: relative; width: 676px; height: 400px;"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="section">
                <div class="row">
                    <div class="col-md-12">
                        <h2>City Details</h2>
                        <hr />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <div class="data-table">
                            <table>
                                <tr>
                                    <th>Population</th>
                                    <th>Elevation</th>
                                    <th>Country</th>
                                </tr>
                                <tr>
                                    <td><%#Eval("Population") %></td>
                                    <td><%#Eval("Elevation","&nbsp;{0}m") %></td>
                                    <td><%#Eval("CountryCodeISO") %></td>
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
                <h2>Images From City</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <ucx:TravelImageBoxUC runat="server" ID="ucxRelatedImages" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>
