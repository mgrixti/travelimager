<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleImage.aspx.cs" Inherits="SingleImage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">


    <script type="text/javascript">
        function openModal() {
            $('#mySmallModalLabel').modal('show');
        }
    </script>
    <%--Image Data--%>
    <asp:UpdatePanel ID="upRating" runat="server">
        <ContentTemplate>
            <asp:ListView ID="lvImageData" runat="server"
                OnItemCommand="lvImageData_ItemCommand" DataKeyNames="Id,Title,Path" OnItemDataBound="lvImageData_ItemDataBound">
                <ItemTemplate>

                    <div class="section">
                        <div class="row">
                            <div class="col-md-12">
                                <h2><%# Eval("Title")%></h2>
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-9">

                                <%--Large Image--%>
                                <p><strong>Posted By:</strong>&nbsp;<a href='./SingleUser.aspx?id=<%# Eval("UserID") %>'><%# Eval("FullName")%></a></p>
                                <p><strong>From Post:</strong>&nbsp;<a href='./SinglePost.aspx?id=<%# Eval("PostID") %>'><%# Eval("PostTitle")%></a></p>
                                <a data-toggle="modal" data-target="#myModal">
                                    <img class="img-responsive" src="./travel-images/medium/<%# Eval("Path")%>" alt='<%# Eval("Title") %>' title='<%# Eval("Title") %>' />
                                </a>
                                <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                                <h4 class="modal-title" id="myModalLabel"><%# Eval("Title")%> by <%# Eval("FullName")%></h4>
                                            </div>
                                            <div class="modal-body">
                                                <img class="img-responsive" src="./travel-images/large/<%# Eval("Path")%>" alt='<%# Eval("Title") %>' title='<%# Eval("Title") %>' />
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-default btn-xs" style="color:white" data-dismiss="modal">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:Panel ID="pnlRatings" runat="server" CssClass="singleimage-rating-area">
                                    <asp:Button ID="btnFavorite" runat="server" Text="Favorite" CssClass="btn btn-success btn-lg" CommandName="addFavorite" />
                                    <h3>Rating</h3>
                                    <p><%# Eval("RatingAverage")%></p>
                                    <h3>Votes</h3>
                                    <p><%# Eval("RatingCount")%></p>
                                    <asp:Button ID="btnReview" runat="server" Text="Review" CssClass="btn btn-success btn-lg" CommandName="enableReviewEntry" Visible="false" />
                                </asp:Panel>
                            </div>
                        </div>
                    </div>

                    
                    
                    <asp:Panel ID="pnlAddReview" runat="server" CssClass="section" Visible="false">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Enter Review</h2>
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="singleimage-add-review-area">
                                    <asp:Button ID="btnAddReview" runat="server" CssClass="btn btn-primary" Text="Add Review" CommandName="addReview" />
                                    <div class="rate-area">
                                       
                                        <asp:UpdatePanel ID="upRating" runat="server">
                                            <ContentTemplate>
                                                Enter a rating:&nbsp<asp:TextBox ID="tbRating" runat="server" Placeholder="1-5"></asp:TextBox>
                                                <asp:RangeValidator ID="rvRating" runat="server"
                                                    ControlToValidate="tbRating" MinimumValue="1" MaximumValue="5"
                                                    ToolTip="Enter number rating between 1 and 5"
                                                    ErrorMessage="Rating must be a number between 1 and 5"
                                                    ForeColor="Red" Display="Dynamic" Type="Integer"></asp:RangeValidator>
                                                <asp:RequiredFieldValidator ID="rfvRating" runat="server"
                                                    ControlToValidate="tbRating"
                                                    ErrorMessage="Rating is required for review."
                                                    ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <%--Display has to be set to dymanic to not make message part of page.--%>
                                                <div style="clear: both"></div>
                                                <br />
                                                <%--Required Validators require seperate update panels with textboxes embed to work inside update panels--%>
                                                <asp:TextBox ID="tbComment" runat="server" TextMode="MultiLine" Placeholder="Enter a comment"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvComment" runat="server"
                                                    ControlToValidate="tbComment"
                                                    ErrorMessage="Comment is required for review."
                                                    ForeColor="Red"></asp:RequiredFieldValidator>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>

                    <div class="section">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Image Details</h2>

                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="data-table">
                                    <table>
                                        <tr>
                                            <th>Country</th>
                                            <th>City</th>
                                        </tr>
                                        <tr>
                                            <td><a href='./SingleCountry.aspx?id=<%# Eval("CountryID") %>'><%#Eval("CountryName") %></a></td>
                                            <td><a href='./SingleCity.aspx?id=<%# Eval("CityID") %>'><%#Eval("CityName") %></a></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Panel ID="pnlMap" runat="server" CssClass="section">
                        <div class="row">
                            <div class="col-md-12">
                                <h2>Map</h2>
                                <hr />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-10">
                                <div class="panel-group" id="mapAccordion">
                                    <div class="panel panel-default">
                                        <div class="panel-heading">
                                            <h4 class="panel-title">
                                                <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Click to view on map
                                                </a>
                                            </h4>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse on">
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
                    </asp:Panel>

                </ItemTemplate>
            </asp:ListView>
                <div class="modal fade bs-example-modal-sm" id="mySmallModalLabel" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                        <div class="modal-dialog modal-sm">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title" id="H1">Message</h4>
                                </div>
                                <div class="modal-body">
                                    <asp:Label runat="server" Text="the" ID="lbError" />
                                </div>
                            </div>
                        </div>
                    </div>
        </ContentTemplate>
    </asp:UpdatePanel>



    <%--Review Area--%>
    <%--Update panel cannot be set to conditional because has to update from the postback that the add review button causes--%>
    <asp:UpdatePanel ID="upReview" runat="server">
        <ContentTemplate>

            <asp:Panel ID="pnlImagesReview" runat="server">
                <div class="section">
                    <div class="row">
                        <div class="col-md-12">
                            <h2>Image Reviews</h2>
                            <hr />
                        </div>
                    </div>

                    <asp:ListView ID="lvImagesReview" runat="server"
                        OnItemCommand="lvImagesReview_ItemCommand"
                        DataKeyNames="Id,ImageID,Rating,ReviewDate,Comment"
                        OnItemDataBound="lvImagesReview_ItemDataBound">
                        <ItemTemplate>
                            <div class="row">
                                <div class="col-md-10">
                                    <h3><%# GetUserMessage(Eval("UserName").ToString()) %></h3>
                                    <span class="bold">Date:</span>&nbsp;
                                    <span>
                                        <%# GetDateMessage(Eval("ReviewDate").ToString()) %>
                                    </span>&nbsp;&nbsp;&nbsp;&nbsp;
                                    <span class="bold">Rating:</span>&nbsp;<span><%# Eval("Rating") %></span>
                                    <asp:Button ID="btnRemoveReview" Text="Remove" runat="server" CssClass="btn btn-primary pull-right" CommandName="remove" Visible="false" />
                                    <br />
                                    <br />
                                    <p><%# GetCommentMessage(Eval("Comment").ToString()) %></p>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10">
                                    <hr />
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>

                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%--Images Area--%>
    <asp:Panel ID="pnlImagesPost" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Other Images From Post</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <ucx:TravelImageBoxUC ID="ucxRelatedImagesPost" runat="server" />
            </div>
        </div>
    </asp:Panel>

    <asp:Panel ID="pnlImagesCountry" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Other Images From Country</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <ucx:TravelImageBoxUC ID="ucxRelatedImagesCountry" runat="server" />
            </div>
        </div>
    </asp:Panel>
    
    <asp:Panel ID="pnlFlickr" runat="server" CssClass="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Flickr Images From City</h2>
                <hr />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <ucx:FlickrImageUC ID="ucxFlickrImages" runat="server" />
            </div>
        </div>
    </asp:Panel>

</asp:Content>
