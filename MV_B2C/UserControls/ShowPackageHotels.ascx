<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="ShowPackageHotels" Codebehind="ShowPackageHotels.ascx.cs" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="ShowHotel">
   
        <asp:DataList ID="dlHotelDetails" runat="server" Width="100%" OnItemDataBound="dlHotelDetails_ItemDataBound">
        <ItemTemplate>
            <div class="singleHotel">
                <h2>
                    Hotel in
                    <asp:Label ID="lbHotelCity" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).City.Name %>'></asp:Label>
                </h2>
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td class="name" colspan="2">
                            <asp:Label ID="lbHotelName" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).Name %>'></asp:Label>
                            <asp:Label ID="lblHotelID" runat="server" Text='<%# ((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelId.ToString() %>'
                                Visible="false"></asp:Label>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).City.Name %>'
                                Visible="False"></asp:Label>
                            <asp:Label ID="lblCityCode" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).City.Code %>'
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%">
                            <div class="hotelpic">
                                <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).GetImage("FRONT") == null || ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).GetImage("FRONT").Filename == null ?"../images/v1/defaulth.gif":((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).GetImage("FRONT").Filename.Trim()%>' /></div>
                        </td>
                        <td>
                            <div class="AHprice">
                                <img src="../../images/v1/pricetab.gif" /><div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <%--<tr>
                                            <td align="center">
                                                Base on standard double room</td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <strong>Price: $<asp:Label ID="lbLowPrice" runat="server" Text='<%# ((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).RoomPrice %>'></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                /per room per & night
                                            </td>
                                        </tr>--%>
                                         <asp:Repeater ID="rptRooms" runat="server" DataSource='<%#((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).Items%>'>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblRoom">Room #</asp:Label><asp:Label ID="lblRoomDescription" runat="server" Text='<%# (Container.ItemIndex + 1).ToString() + ": " + DataBinder.Eval(Container.DataItem, "DefaultRoomType.Room.Description")  +"  "+( DataBinder.Eval(Container.DataItem, "DefaultRoomType.Breakfast")!= "" ? "Included " + DataBinder.Eval(Container.DataItem, "DefaultRoomType.Breakfast").ToString() : "Not included breakfast")%>'></asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td align="center">
                                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:
                                                <asp:Label ID="lbCheckIn" runat="server" Text='<%# ((HotelProfile)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0].Profile).CheckInDate.ToString("MM/dd/yyyy") %>'></asp:Label>
                                                <asp:Label ID="lbOneCheckIn" runat="server"></asp:Label>
                                                <br />
                                                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:
                                                <asp:Label ID="lbOneCheckOut" runat="server"></asp:Label>
                                                <asp:Label ID="lbCheckOut" runat="server" Text='<%# ((HotelProfile)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0].Profile).CheckOutDate.ToString("MM/dd/yyyy") %>'></asp:Label>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div>
                                <p>
                                    <asp:Label ID="Label3" runat="server" meta:resourcekey="lblAddress">Add</asp:Label>:
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).Address %>'></asp:Label>
                                    <br />
                                </p>
                                <p>
                                    <strong><asp:Label ID="Label4" runat="server" meta:resourcekey="lblMajesticRating">Majestic Rating</asp:Label>:</strong>
                                    <ajaxToolkit:Rating ID="rtgHotel" runat="server" ReadOnly="true" Enabled="false"
                                        Visible="true" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;"
                                        CurrentRating='<%# Convert.ToDouble(((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).Class) %>' />
                                </p>
                                <p>
                                    <asp:Label ID="lbText" runat="server"></asp:Label>...</p>
                                 <asp:HyperLink ID="hlHotelInfo" runat="server" NavigateUrl='<%# "~/Page/Package/PackageSelectRoomsForm.aspx?TableName=Features&ReturnUrl=PackageSearchResult2dFrom.aspx&Condition=A&HotelID="+  ((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelId.ToString() %>' meta:resourcekey="hlViewHotel">View More Hotel Info</asp:HyperLink> <%--| 
                                <asp:HyperLink ID="hlRoomPptions" runat="server" NavigateUrl='<%# "~/Page/Package/PackageSelectRoomsForm.aspx?TableName=Room Types&ReturnUrl=PackageSearchResult2dFrom.aspx&Condition=A&HotelID="+  ((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelId.ToString() %>'>All room options</asp:HyperLink>--%>
                            </div>
                        </td>
                    </tr>
                    <%--<tr>
                        <td>
                            <strong>Package Includes: </strong>
                        </td>
                        <td>
                            <span class="orglab">
                                <asp:Label ID="lbNights" runat="server"></asp:Label>
                                Nights</span> Stay in Standard Double Room<br />
                            2 Round-TripTickets&nbsp;</td>
                    </tr>--%>
                    <tr>
                        <td align="right" colspan="2">
                            <%--<div class="vacant">
                                Breakfast Included</div>--%>
                           <!-- <img src="../../images/v1/arrow_right.gif" align="absMiddle" />
                            <asp:HyperLink ID="hlCheck" runat="server" NavigateUrl="~/Page/Hotel/HotelDetailedInformationForm.aspx">Change Check In/Out</asp:HyperLink>--><img
                                src="../../images/v1/arrow_right.gif" align="absMiddle" /><asp:HyperLink
                                    ID="hlRoomType" NavigateUrl="~/Page/Hotel/HotelDetailedInformationForm.aspx"
                                    runat="server" meta:resourcekey="hlSelectRoomType">Select Room Type</asp:HyperLink>
                            <img src="../../images/v1/arrow_right.gif" align="absMiddle" />
                            <asp:HyperLink ID="hotelSelect" NavigateUrl="~~/Page/Hotel/HotelSelectForm.aspx"
                                runat="server" meta:resourcekey="hlChooseOtherHotel">Choose other hotel in Beijing </asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
    
    <%--<asp:DataList ID="dlHotelDetailsTwo" runat="server" Width="100%" OnItemDataBound="dlHotelDetailsTwo_ItemDataBound">
        <ItemTemplate>
            <div class="singleHotel">
                <h2>
                    Hotel in
                    <asp:Label ID="lbHotelCity" runat="server" Text='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).CityCode.Name %>'></asp:Label>
                </h2>
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td class="name" colspan="2">
                            <asp:Label ID="lbHotelName" runat="server" Text='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Name %>'></asp:Label>
                            <asp:Label ID="lblHotelID" runat="server" Text='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Id %>'
                                Visible="false"></asp:Label>
                            <asp:Label ID="lblCountry" runat="server" Text='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).CityCode.CountryCode.Code %>'
                                Visible="False"></asp:Label>
                            <asp:Label ID="lblCityCode" runat="server" Text='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).CityCode.Code %>'
                                Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%">
                            <div class="hotelpic">
                                <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Url %>' /></div>
                        </td>
                        <td>
                            <div class="AHprice">
                                <img src="../../images/v1/pricetab.gif" /><div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td align="center">
                                                Base on standard double room</td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <strong>Lowest Price: $<asp:Label ID="lbLowPrice" runat="server" Text='<%# ((IDictionary<SaleRoomType, Price>) DataBinder.Eval(Container.DataItem, "RoomRates"))[((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Rooms[0].RoomTypes[0]].Total %>'></asp:Label></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                per room per night
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                Check In:<asp:Label ID="lbTwoCheckIn" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CheckIn") %>'></asp:Label>
                                                <br />
                                                Check Out:<asp:Label ID="lbTwoCheckOut" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CheckOut") %>'></asp:Label>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div>
                                <p>
                                    Add:
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Address %>'></asp:Label>
                                    <br />
                                </p>
                                <p>
                                    <strong>Majestic Rating:</strong>
                                    <ajaxToolkit:Rating ID="rtgHotel" runat="server" ReadOnly="true" Enabled="false"
                                        Visible="true" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                        FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;"
                                        CurrentRating='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Class %>' />
                                </p>
                                <p>
                                    <asp:Label ID="lbText" runat="server" Text='<%# ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Location.Substring(0,100) %>'></asp:Label>...</p>
                                 <asp:HyperLink ID="hlHotelInfo" runat="server" NavigateUrl='<%# "~/Terms.Sales.Web/PackageSelectRoomsForm.aspx?TableName=Features&HotelID="+  ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Id %>'>View More Hotel Info</asp:HyperLink> | 
                                <asp:HyperLink ID="hlRoomPptions" runat="server" NavigateUrl='<%# "~/Terms.Sales.Web/PackageSelectRoomsForm.aspx?TableName=Room Types&HotelID="+  ((SaleHotel) DataBinder.Eval(Container.DataItem, "Hotel")).Id %>'>All room options</asp:HyperLink>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <strong>Package Includes: </strong>
                        </td>
                        <td>
                            <span class="orglab">
                                <asp:Label ID="lbNights" runat="server"></asp:Label>
                                Nights</span> Stay in Standard Double Room<br />
                            2 Round-TripTickets&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <div class="vacant">
                                Breakfast Included</div>
                            <img src="../../images/v1/arrow_right.gif" align="absMiddle" />
                            <asp:HyperLink ID="hlCheck" runat="server" NavigateUrl="~/Terms.Sales.Web/HotelDetailedInformationForm.aspx">Change Check In/Out</asp:HyperLink><img
                                src="../../images/v1/arrow_right.gif" align="absMiddle" /><asp:HyperLink
                                    ID="hlRoomType" NavigateUrl="~/Terms.Sales.Web/HotelDetailedInformationForm.aspx"
                                    runat="server">Select Room Type</asp:HyperLink>
                            <img src="../../images/v1/arrow_right.gif" align="absMiddle" />
                            <asp:HyperLink ID="hotelSelect" NavigateUrl="~/Terms.Sales.Web/HotelSelectForm.aspx"
                                runat="server">Choose other hotel in Beijing </asp:HyperLink>
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>--%>
</div>
