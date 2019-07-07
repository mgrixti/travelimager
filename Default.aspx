<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%--Default Page Markup--%>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="Server">

    <%--Default Page Specific Data--%>
    <div class="section">
        <div class="row">
            <div class="col-md-12">
                <h1>Welcome to the Travel Imager Website</h1>
                <hr />
                <p>
                    Welcome to Travel Imager! Search through Travel Posts to view images and commentary about trips.
                    View images from our user's trips, along with the location where they were taken. Or even search by City, Country, or Continent (to the left) to filter posts.
                </p>
            </div>
        </div>
    </div>

    <%--Top Rated Images Area--%>
    <div class="section">
        <div class="row">
            <div class="col-md-12">
                <h2>Top Rated Images</h2>
                <hr />
                <ucx:TravelImageBoxUC runat="server" ID="ucxTopRatedImages" />
            </div>
        </div>
    </div>

    <%--New Addition Images Area--%>
    <div class="section">
        <div class="row">
            <div class="col-md-12">
                <h2>New Addition Images</h2>
                <hr />
                <ucx:TravelImageBoxUC runat="server" ID="ucxNewAdditionImages" />
            </div>
        </div>
    </div>

    <%--New Addition Images Reviews Area--%>
    <asp:Panel ID="pnlImagesReview" runat="server">
        <div class="section">
            <div class="row">
                <div class="col-md-12">
                    <h2>New Addition Reviews</h2>
                    <hr />
                </div>
            </div>


            <div class="row">
                <div class="col-md-12">
                    <table class="grid-table">
                        <asp:ListView ID="lvImagesReview" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <div class="glyphicon glyphicon-pencil"></div>
                                    </td>
                                    <td><%# GetDateMessage(Eval("ReviewDate").ToString()) %></td>
                                    <td><a class="title "href='./SingleImage.aspx?id=<%# Eval("ImageID") %>'><span class=italic><%# GetCommentMessage(Eval("Comment").ToString()) %></span></a></td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </table>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
