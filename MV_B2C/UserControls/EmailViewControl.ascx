<%@ Control Language="C#" AutoEventWireup="true" Inherits="EmailViewControl" Codebehind="EmailViewControl.ascx.cs" %>
<%@ Register Src="ViewTransportationControl.ascx" TagName="ViewTransportationControl"
    TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div>
</div>
<table width="100%" cellpadding="0" cellspacing="0" style="border:solid 1px #999;">
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="3" runat="server" id="tbFlight">
                <tr>
                    <td width="88%" style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlights">Flights</asp:Label> -
                        <asp:Label ID="lblTicketNumber" runat="server" Text=""></asp:Label>&nbsp; Tickets
                        <asp:Label ID="lblFlightType" runat="server"></asp:Label></td>
                    <td width="12%"  style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDeparture">Departure</asp:Label>:
                        <asp:DataList ID="dlDeparture" runat="server" Width="100%">
                            <ItemTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                    <tr>
                                        <td width="24%">
                                            <a href="#">
                                                <asp:Label ID="lbDepFilght" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AirLine.Code") %>'></asp:Label></a><asp:Label
                                                    ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'></asp:Label></td>
                                        <td width="10%">
                                            <asp:Label ID="lbDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                        </td>
                                        <td width="27%">
                                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDepart">Depart</asp:Label>:&nbsp;<asp:Label ID="lbDepTime" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label><br />
                                            <asp:Label ID="Label7" runat="server" meta:resourcekey="lblArrive">Arrive</asp:Label>:&nbsp;<asp:Label ID="lbArrTime" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label></td>
                                        <td width="39%">
                                            <asp:Label ID="Label8" runat="server" meta:resourcekey="lblFrom">From</asp:Label>:&nbsp;<asp:Label ID="lbDepartureCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name")%> '></asp:Label>
                                            <asp:Label ID="lbDepartureCode" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") + ")" %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblTo">To</asp:Label>:&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name")%> '></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") + ")" %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <!--<tr>
                            <td> Cabin Class: Economy </td>
                            <td>&nbsp;</td>
                            <td> Stop: 0 </td>
                            <td> Duration: 13hr 30min&nbsp;</td>
                          </tr>-->
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label ID="Label6" runat="server" meta:resourcekey="lblReturn">Return</asp:Label>:
                        <asp:DataList ID="dlReturn" runat="server" Width="100%">
                            <ItemTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                    <tr>
                                        <td width="24%">
                                            <a href="#">
                                                <asp:Label ID="lbDepFilght" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AirLine.Code") %>'></asp:Label></a><asp:Label
                                                    ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'></asp:Label></td>
                                        <td width="10%">
                                            <asp:Label ID="lbDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                        </td>
                                        <td width="27%">
                                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDepart">Depart</asp:Label>:&nbsp;<asp:Label ID="lbDepTime" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label><br />
                                            <asp:Label ID="Label7" runat="server" meta:resourcekey="lblArrive">Arrive</asp:Label>:&nbsp;<asp:Label ID="lbArrTime" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label></td>
                                        <td width="39%">
                                            <asp:Label ID="Label8" runat="server" meta:resourcekey="lblFrom">From</asp:Label>:&nbsp;<asp:Label ID="lbDepartureCity" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name")%> '></asp:Label>
                                            <asp:Label ID="lbDepartureCode" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") + ")" %>'></asp:Label>
                                            <br />
                                            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblTo">To</asp:Label>:&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name")%> '></asp:Label>
                                            <asp:Label ID="Label3" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") + ")" %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <!--<tr>
                            <td> Cabin Class: Economy </td>
                            <td>&nbsp;</td>
                            <td> Stop: 0 </td>
                            <td> Duration: 13hr 30min&nbsp;</td>
                          </tr>-->
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                <tr>
                    <td colspan="3">
                        <asp:DataList ID="ddlHotel" runat="server" Width="100%" OnItemDataBound="ddlHotel_ItemDataBound">
                            <ItemTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                    <tr>
                                        <td colspan="2" style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                                            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblHotel">Hotel</asp:Label> -
                                            <asp:Label ID="lbRooms" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoomTypes.Count") %>'></asp:Label>
                                            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblRoom">Room</asp:Label>,
                                            <asp:Label ID="lbNights" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOut")).Subtract((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).Days %>'></asp:Label>
                                            <asp:Label ID="Label11" runat="server" meta:resourcekey="lblNights">Nights</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="50%" style="color:#006; font-weight:bold;">
                                            <a href="#">
                                                <asp:Label ID="lbHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.Name") %>'></asp:Label></a></td>
                                        <td width="50%" style="color:#006; font-weight:bold;">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label12" runat="server" meta:resourcekey="lblAddress">Address</asp:Label>:
                                            <asp:Label ID="lbAddress" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.Address") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <%--<asp:Label ID="lbCheckDate" runat="server"></asp:Label>--%>
                                            <asp:Label ID="Label13" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:&nbsp;<asp:Label ID="lbCheckInDate" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy")%>'></asp:Label>
                                            |
                                            <asp:Label ID="Label14" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:&nbsp;<asp:Label ID="lbCheckOutDate" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy")%>'></asp:Label>
                                        </td>
                                    </tr>
                                    <asp:Repeater ID="rptRoom" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "RoomTypes") %>'>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label14" runat="server" meta:resourcekey="lblRoom">Room</asp:Label> #<asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label>: <asp:Label ID="lbHotelDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Description") %>'></asp:Label></td>
                                                    <td><asp:Label
                                                            ID="lblBreakfastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BreakfastName") != "" ? "Included " + DataBinder.Eval(Container.DataItem, "BreakfastName").ToString() + " Breakfast" : "Not included breakfast" %>'></asp:Label>
                                                    </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                <tr>
                    <td colspan="3" style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                        <asp:Label ID="Label14" runat="server" meta:resourcekey="lblTravelerInfo">Traveler Info</asp:Label></td>
                    <td width="36%" style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:DataList ID="dlPassengers" runat="server" Width="100%" OnItemDataBound="dlPassengers_ItemDataBound">
                            <ItemTemplate>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="8%">
                                            <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassengerType")%>'></asp:Label>
                                            <asp:Label ID="lb" runat="server" Text='<%# Container.ItemIndex + 1%>'>.</asp:Label>
                                        </td>
                                        <td width="28%">
                                            <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Salutationn").ToString()%>'></asp:Label>&nbsp;
                                            <asp:Label ID="lbFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName")%>'></asp:Label>&nbsp;
                                            <asp:Label ID="lbMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName")%>'></asp:Label>&nbsp;
                                            <asp:Label ID="lbLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                                        </td>
                                        <td width="20%">&nbsp;
                                           <asp:Label ID="Label14" runat="server" meta:resourcekey="lblBirth">Date of Birth</asp:Label>:
                                            <asp:Label ID="lbBirth" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "BirthDay")).ToString("MM/dd/yyyy") == "01-01-0001" ? "" : ((DateTime)DataBinder.Eval(Container.DataItem, "BirthDay")).ToString("MM/dd/yyyy")  %>'></asp:Label>
                                        </td>
                                        <td width="24%">
                                            <asp:Label ID="Label15" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label>:<asp:Label ID="lbPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber")%>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                    <uc3:ViewTransportationControl id="ViewTransportationControl1" runat="server">
                        </uc3:ViewTransportationControl>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                <tr>
                    <td colspan="3" style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                        <asp:Label ID="Label16" runat="server" meta:resourcekey="lblContactInfo">Contact Info</asp:Label>
                    </td>
                    <td width="36%" style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td width="14%">
                        <asp:Label ID="Label17" runat="server" meta:resourcekey="lblName">Name</asp:Label>:</td>
                    <td width="36%">
                        <asp:Label ID="lbName" runat="server"></asp:Label>
                    </td>
                    <td width="14%">
                        <asp:Label ID="Label18" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:</td>
                    <td>
                        <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label19" runat="server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:
                    </td>
                    <td>
                        <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label20" runat="server" meta:resourcekey="lblStateCity">State &amp; City</asp:Label>:</td>
                    <td>
                        <asp:Label ID="lbStateCity" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label21" runat="server" meta:resourcekey="lblZip">Zip&nbsp;/&nbsp;Postal Code</asp:Label>:</td>
                    <td>
                        <asp:Label ID="lbZipPostCode" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label22" runat="server" meta:resourcekey="lblFax">Fax</asp:Label>:</td>
                    <td>
                        <asp:Label ID="lbFax" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label23" runat="server" meta:resourcekey="lblDayPhone">Daytime Phone No.</asp:Label>:
                    </td>
                    <td>
                        <asp:Label ID="lbDayTimePhone" runat="server"></asp:Label></td>
                    <td>
                        <asp:Label ID="Label24" runat="server" meta:resourcekey="lblEveningPhone">Evening Phone No.</asp:Label>:
                    </td>
                    <td>
                        <asp:Label ID="lbEveningPhone" runat="server"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                <tr>
                    <td colspan="2" style="background-color:#FDF1C1; font-family:Verdana, Helvetica, sans-serif; font-size:13px; font-weight:bold; color:#f38822;">
                        <asp:Label ID="Label25" runat="server" meta:resourcekey="lblPrice">Price</asp:Label>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Label ID="Label26" runat="server" meta:resourcekey="lblTotal">Total</asp:Label>:</td>
                    <td>
                        $<asp:Label ID="lbTotalPrice" runat="server"></asp:Label>
                        / <span style="color:#EF6C2E; font-weight:bold;">$<asp:Label ID="lbAvgPrice" runat="server"></asp:Label>
                            <asp:Label ID="Label27" runat="server" meta:resourcekey="lblPerPerson">per person</asp:Label> </span>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                <tr>
                    <td colspan="2" class="name">
                        <asp:Label ID="Label28" runat="server" meta:resourcekey="lblRemark">Remark</asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lbRemark" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

