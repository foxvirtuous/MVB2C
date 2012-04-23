<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="ShowPackageHotelDetails" Codebehind="ShowPackageHotelDetails.ascx.cs" %>
<%@ Register Src="PageNumberControl.ascx" TagName="PageNumberControl" TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Sales.Business" %>

<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="System.Collections.Generic" %>

<table width="100%" border="0" cellspacing="0" cellpadding="2" class="showopt">
    <tr>
        <td width="20%">
             <asp:Label ID="Label1" runat="server" meta:resourcekey="lblHotelRating">Hotel Rating</asp:Label>:
        </td>
        <td width="25%">
            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblHotelNameContains">Hotel Name Contains</asp:Label>:
           </td>
        <td width="50%">
            &nbsp;
        </td>
        <td width="5%">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                Width="150px" Visible="false">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCity" runat="server" Visible="false">
            </asp:DropDownList> <asp:DropDownList ID="ddlStar" runat="server">
                <asp:ListItem Value="0" meta:resourcekey="star0">Show all</asp:ListItem>
                <asp:ListItem Value="1" meta:resourcekey="star1">1 star or more</asp:ListItem>
                <asp:ListItem Value="2" meta:resourcekey="star2">2 star or more</asp:ListItem>
                <asp:ListItem Value="3" meta:resourcekey="star3">3 star or more</asp:ListItem>
                <asp:ListItem Value="4" meta:resourcekey="star4">4 star or more</asp:ListItem>
                <asp:ListItem Value="5" meta:resourcekey="star5">5 star or more</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
           <asp:TextBox ID="txtContains" runat="server"></asp:TextBox>
        </td>
        <td><asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn_inbg" OnClick="btnShow_Click" meta:resourcekey="btnShow" />
            </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>
<div id="sort">
    <table>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblSortBy">Sort by</asp:Label>:
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal"
                    AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                    <asp:ListItem Selected="True" meta:resourcekey="item1">Magestic Picks</asp:ListItem>
                    <asp:ListItem meta:resourcekey="item2">Price</asp:ListItem>
                    <asp:ListItem meta:resourcekey="item3">Hotel Name</asp:ListItem>
                    <asp:ListItem meta:resourcekey="item4">Rating</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<div class="ShowHotel">
    <asp:DataList ID="dlHotelDetails" runat="server" Width="100%" OnItemCommand="dlHotelDetails_ItemCommand"
        OnItemDataBound="dlHotelDetails_ItemDataBound" >
        <ItemTemplate>
            <div class="singleHotel">
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td class="name" colspan="2">
                            <a href="#">
                                <asp:Label ID="lbHotelName" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Name %>'></asp:Label></a>
                            <asp:Label ID="lblHotelID" runat="server" Text=''
                                Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%">
                            <div class="hotelpic">
                                <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).GetImage("FRONT") == null || ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).GetImage("FRONT").Filename == null?"../images/v1/defaulth.gif":((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).GetImage("FRONT").Filename.Trim()%>' />
                                 </div>
                        </td>
                        <td>
                            <div class="AHprice">
                                <img src="../../images/v1/pricetab.gif"  alt=""/>
                                <div>
                                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblBookedSparately">Booked separately</asp:Label>:
                                            </td>
                                            <td align="right">
                                                <asp:Label ID="lbTempPrice" runat="server" Text='<%# (((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice + (((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice * 10/100)).ToString("$#,###") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong><asp:Label ID="Label4" runat="server" meta:resourcekey="lblMajesticDiscunt">Majestic Discount</asp:Label>:</strong></td>
                                            <td align="right">
                                                <strong>-<asp:Label ID="lbSubStrctPrice" runat="server" Text='<%# (((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice * 10/100).ToString("$#,###") %>'></asp:Label></strong></td>
                                        </tr>
                                        <tr>
                                            <td class="M_price" colspan="2">
                                                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblMajesticPrice">Majestic Price</asp:Label>: <asp:Label ID="lbTotalPrice" runat="server"  Text='<%# ((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice.ToString("$#,###") %>'></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="lbAvgPrice" runat="server" Text='<%# ((PackageMaterial)DataBinder.Eval(Container, "DataItem")).AvgPrice.ToString("$#,###")  %>'></asp:Label>
                                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblPerPerson">per person</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="2">
                                                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblIncludes">includes Flight + Hotel, Taxes &amp; Fees</asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div>
                                <p>
                                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblAdd">Add</asp:Label>:
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Address %>'></asp:Label>
                                    <br />
                                </p>
                                <p><strong><asp:Label ID="Label9" runat="server" meta:resourcekey="lblRating">Rating</asp:Label>\:</strong>
                                                <ajaxToolkit:Rating ID="rtgHotel" runat="server" ReadOnly="true" Enabled="false"
                                                    Visible="true" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                                    FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;"
                                                    CurrentRating='<%#  Convert.ToDouble(((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Class) %>' />      
                                </p>
                                <p>
                                    <asp:Label ID="lbText" runat="server" Text='<%#  ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Description.Length>100?((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Description.Substring(0,100):((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Description %>'></asp:Label>...</p>
                                
                                
                                <asp:LinkButton ID="lbtHotelInfo" runat="server" CommandName="CHOOSE" Text="View More Hotel Info" meta:resourcekey="lkMore"></asp:LinkButton>
                                
                                 <%--<asp:HyperLink ID="hlHotelInfo" runat="server" NavigateUrl='<%# "~/Page/Package/PackageSelectRoomsForm.aspx?TableName=Features&HotelIndex"  %>'>View More Hotel Info</asp:HyperLink>| 
                                
                                <asp:HyperLink ID="hlRoomPptions" runat="server" NavigateUrl='<%# "~/Page/Package/PackageSelectRoomsForm.aspx?TableName=RoomTypes&HotelID="+ ((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelId  %>'>All room options</asp:HyperLink>--%>
                            </div>
                        </td>
                    </tr>
                   <%-- <tr>
                        <td>
                            <strong>Package Includes: </strong>
                        </td>
                        <td>
                            <span class="orglab">
                                <asp:Label ID="lbNights" runat="server"></asp:Label>
                                Nights</span> Stay in Standard Double Room<br />
                            2 Round-Trip Tickets&nbsp;</td>
                    </tr>--%>
                    
                    <tr>
                        <td align="right" colspan="2">
<%--                            <div class="vacant">
                                Breakfast Included</div>--%>
                            <asp:ImageButton ImageUrl="~/images/v1/btn_select.gif" DescriptionUrl="~/Page/Package/PackageSelectRoomsForm.aspx"
                                Height="25" Width="56" runat="server" ID="btnSelect" CommandName="SELECT" />
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
   </div> <uc3:PageNumberControl id="PageNumberControl1" runat="server">
    </uc3:PageNumberControl>
<%--<div class="page">
    <div class="turn">
        <asp:HyperLink ID="hlPrevious" runat="server">Previous</asp:HyperLink>
        |
        <asp:HyperLink ID="hlNext" runat="server">Next</asp:HyperLink>
    </div>
    View page:
    <asp:HyperLink ID="hlStar" runat="server">...</asp:HyperLink>
    <asp:HyperLink ID="hl1" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl2" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl3" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl4" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl5" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hlEnd" runat="server">...</asp:HyperLink></div>--%>
