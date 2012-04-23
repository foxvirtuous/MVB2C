<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true" Inherits="Step3_bulk" Title="Step3_bulk" Codebehind="Step3_bulk.aspx.cs" %>

<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ MasterType VirtualPath="BookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ItineraryInfo -->
    <uc5:ItineraryInfo ID="ItineraryInfo" runat="server"></uc5:ItineraryInfo>
    <br />
    <div id="P_table">
        <!-- new -->
        <table width="735" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="15">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="20">
                                <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                    <tr>
                                        <td align="center">
                                            ></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="5">
                            </td>
                            <td align="left">
                                <span class="head06">Select Flights</span></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="735" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                        <tr class="R_stepo">
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="7">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                <tr class="R_stepw">
                                                    <td>
                                                        <asp:DataList ID="dlFlightTours" runat="server" Width="100%" HorizontalAlign="Center"
                                                            OnItemDataBound="dlFlightTours_ItemDataBound">
                                                            <ItemTemplate>
                                                                <table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                                                                    width="100%">
                                                                    <tr class="R_stepw">
                                                                        <td align="center">
                                                                            <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                                                                <tr align="center" class="R_step03">
                                                                                    <td height="35" colspan="7" align="left">
                                                                                        <asp:Label ID="lbl_SelectRadio" runat="server"></asp:Label>
                                                                                        <b>Flight Option #<asp:Label ID="lbl_SelectNo" runat="server"></asp:Label></b></td>
                                                                                </tr>
                                                                            </table>
                                                                            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                                                                <tr align="center" class="R_order">
                                                                                    <td height="23" width="30%">
                                                                                        Flight Info</td>
                                                                                    <td width="30%">
                                                                                        Departure</td>
                                                                                    <td width="30%">
                                                                                        Arrive</td>
                                                                                    <td width="10%">
                                                                                        Stops</td>
                                                                                </tr>
                                                                            </table>
                                                                            <!--OUTBOUND FLIGHT-->
                                                                            <asp:DataList ID="dlSubTrips" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'>
                                                                                <ItemTemplate>
                                                                                    <asp:DataList ID="dlFlights" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                        DataSource='<%#((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights %>'
                                                                                        OnItemDataBound="dlFlights_ItemDataBound">
                                                                                        <ItemTemplate>
                                                                                            <!--OUTBOUND FLIGHT-->
                                                                                            <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                                                                                                <tr align="left" class="R_stepw">
                                                                                                    <asp:Label ID="Mytr" runat="server"></asp:Label>
                                                                                                    <td>
                                                                                                        <b>
                                                                                                            <asp:Label ID="lbl_AirCode" runat="server" Text='<%# ((Airline)DataBinder.Eval((AirLeg)Container.DataItem, "AirLine")).Code %>'>
                                                                                                            </asp:Label>&nbsp;
                                                                                                            <asp:Label ID="lblFlightNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                                                                            </asp:Label>&nbsp;
                                                                                                            <asp:Label ID="lblBookClass" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BookingClass") %>'>
                                                                                                            </asp:Label>
                                                                                                        </b>
                                                                                                        <!-- <br />
                                                                                                        Aircraft: <font class="P_blue">
                                                                                                            <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AircraftCode") %>'>
                                                                                                            </asp:Label></font>-->
                                                                                                    </td>
                                                                                                    <td width="30%">
                                                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                                                        </asp:Label>
                                                                                                        <asp:Label ID="lblDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                                                        </asp:Label>
                                                                                                        <br />
                                                                                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                                                                        </asp:Label>
                                                                                                        (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                                                                        </asp:Label>)<br />
                                                                                                    </td>
                                                                                                    <td width="30%">
                                                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                                        </asp:Label>
                                                                                                        <asp:Label ID="lblArrDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                                        </asp:Label>
                                                                                                        <br />
                                                                                                        <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name") %>'>
                                                                                                        </asp:Label>
                                                                                                        (<asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") %>'>
                                                                                                        </asp:Label>)<br />
                                                                                                    </td>
                                                                                                    <td width="10%" align="center">
                                                                                                        <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                                                                        </asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:DataList>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" align="left">
                                                                            <asp:Label ID="lbDispMessage" ForeColor="White" runat="server" Visible="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table id="tableLine" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td height="8">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <uc4:PageNumber ID="PageNumber1" runat="server"></uc4:PageNumber>
                                    </tr>
                                    <tr>
                                        <td height="3">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <!-- new -->
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td align="right">
                    Please click on <font id="P_red">"Continue"</font> to determine final price for
                    your itinerary.&nbsp;
                    <asp:Button ID="btnContinue" Text="Continue" runat="server" OnClick="btnContinue_Click"
                        CssClass="search_btn02" Style="cursor: hand" />&nbsp;&nbsp;<asp:Button ID="btn_back"
                            runat="server" Text="Back" OnClick="btn_back_Click" CssClass="search_btn03" Style="cursor: hand" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
