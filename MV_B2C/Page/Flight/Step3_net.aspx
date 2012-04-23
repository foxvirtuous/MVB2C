<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true" Inherits="Step3_net" Title="Step3_net" Codebehind="Step3_net.aspx.cs" %>

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
                                                        <table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                                                            width="100%">
                                                            <tr class="R_stepw">
                                                                <td align="center">
                                                                    <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                        <tr align="center" class="R_step03">
                                                                            <td height="35">
                                                                                Outbound Itinerary</td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                                                        <tr align="center" class="R_order">
                                                                            <td width="5%">
                                                                                &nbsp;</td>
                                                                            <td width="19%" height="23">
                                                                                Flight Info</td>
                                                                            <td width="33%">
                                                                                Departure</td>
                                                                            <td width="33%">
                                                                                Arrive</td>
                                                                            <td width="10%">
                                                                                Stops</td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="T_step03">
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <asp:DataList ID="dlDeptTrip" runat="server" Width="100%" CellPadding="0" CellSpacing="0"
                                                                                    OnItemDataBound="dlDeptTrip_ItemDataBound">
                                                                                    <ItemTemplate>
                                                                                        <table border="0" cellspacing="1" cellpadding="1" width="100%" class="T_step03">
                                                                                            <tr class="R_stepw">
                                                                                                <td width="5%" align="center" valign="top">
                                                                                                    <asp:Label ID="lbl_radio" runat="server"></asp:Label></td>
                                                                                                <td>
                                                                                                    <asp:DataList ID="dlSubTrips" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                                        DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips%>'>
                                                                                                        <ItemTemplate>
                                                                                                            <asp:DataList ID="dlFlights" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                                                DataSource='<%#((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights %>'>
                                                                                                                <ItemTemplate>
                                                                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="T_step03">
                                                                                                                        <tr align="left" class="R_stepw">
                                                                                                                            <td width="19%">
                                                                                                                                <b>
                                                                                                                                    <asp:Label ID="lbl_AirCode" runat="server" Text='<%#((Airline)DataBinder.Eval((AirLeg)Container.DataItem, "AirLine")).Code%>'>
                                                                                                                                    </asp:Label>&nbsp;
                                                                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                                                                                                    </asp:Label>&nbsp;
                                                                                                                                    <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BookingClass") %>'>
                                                                                                                                    </asp:Label></b>
                                                                                                                                    <!--<br />
                                                                                                                                Aircraft:<font class="P_blue">
                                                                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AircraftCode") %>'>
                                                                                                                                    </asp:Label></font>-->
                                                                                                                            </td>
                                                                                                                            <td width="33%">
                                                                                                                                <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                                                                                </asp:Label><br />
                                                                                                                                <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                                                                                                </asp:Label>
                                                                                                                                (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                                                                                                </asp:Label>)<br />
                                                                                                                            </td>
                                                                                                                            <td width="33%">
                                                                                                                                <asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                                                                </asp:Label><br />
                                                                                                                                <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name") %>'>
                                                                                                                                </asp:Label>
                                                                                                                                (<asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") %>'>
                                                                                                                                </asp:Label>)<br />
                                                                                                                            </td>
                                                                                                                            <td width="10%" align="center">
                                                                                                                                <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                                                                                                </asp:Label></td>
                                                                                                                            <!--td width="8%" align="center">
                                                                                    <b>4</b>
                                                                                </td-->
                                                                                                                        </tr>
                                                                                                                    </table>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:DataList>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:DataList>
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
                                                        </table>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="8">
                                                                    <uc4:PageNumber ID="PageNumber1" runat="server"></uc4:PageNumber>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="8">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div id="divRtn" runat="server">
                                                            <table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                                                                width="100%">
                                                                <tr class="R_stepw">
                                                                    <td align="center">
                                                                        <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                            <tr align="center" class="R_step03">
                                                                                <td height="35">
                                                                                    Inbound Itinerary</td>
                                                                            </tr>
                                                                        </table>
                                                                        <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                                                            <tr align="center" class="R_order">
                                                                                <td width="5%">
                                                                                    &nbsp;</td>
                                                                                <td width="19%" height="23">
                                                                                    Flight Info</td>
                                                                                <td width="33%">
                                                                                    Departure</td>
                                                                                <td width="33%">
                                                                                    Arrive</td>
                                                                                <td width="10%">
                                                                                    Stops</td>
                                                                            </tr>
                                                                        </table>
                                                                        <table border="0" cellpadding="0" cellspacing="1" width="100%" class="T_step03">
                                                                            <tr align="left" class="R_stepw">
                                                                                <td>
                                                                                    <asp:DataList ID="dlRtnTrip" runat="server" Width="100%" CellPadding="0" CellSpacing="0"
                                                                                        OnItemDataBound="dlRtnTrip_ItemDataBound" HorizontalAlign="Left">
                                                                                        <ItemTemplate>
                                                                                            <table border="0" cellspacing="1" cellpadding="2" width="100%" class="T_step03">
                                                                                                <tr class="R_stepw">
                                                                                                    <td width="5%" align="center" valign="top">
                                                                                                        <asp:Label ID="lbl_radio" runat="server"></asp:Label></td>
                                                                                                    <td>
                                                                                                        <asp:DataList ID="dlSubTrips2" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                                            DataSource='<%#  ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:DataList ID="dlFlights2" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                                                    DataSource='<%# ((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights %>'>
                                                                                                                    <ItemTemplate>
                                                                                                                        <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                                                                                                                            <tr align="left" class="R_stepw">
                                                                                                                                <td width="19%">
                                                                                                                                    <b>
                                                                                                                                        <asp:Label ID="lbl_AirCode" runat="server" Text='<%# ((Airline)DataBinder.Eval((AirLeg)Container.DataItem, "AirLine")).Code %>'>
                                                                                                                                        </asp:Label>&nbsp;
                                                                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                                                                                                        </asp:Label>&nbsp;
                                                                                                                                        <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BookingClass") %>'>
                                                                                                                                        </asp:Label></b>
                                                                                                                                        <!--<br />
                                                                                                                                    Aircraft:<font class="P_blue">
                                                                                                                                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AircraftCode") %>'>
                                                                                                                                        </asp:Label></font>-->
                                                                                                                                </td>
                                                                                                                                <td width="33%">
                                                                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                                                                                    </asp:Label><br />
                                                                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                                                                                                    </asp:Label>
                                                                                                                                    (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                                                                                                    </asp:Label>)<br />
                                                                                                                                </td>
                                                                                                                                <td width="33%">
                                                                                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                                                                                    </asp:Label><br />
                                                                                                                                    <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name") %>'>
                                                                                                                                    </asp:Label>
                                                                                                                                    (<asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") %>'>
                                                                                                                                    </asp:Label>)<br />
                                                                                                                                </td>
                                                                                                                                <td width="10%" align="center">
                                                                                                                                    <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                                                                                                    </asp:Label></td>
                                                                                                                                <!--td width="8%" align="center">
                                                                                    <b>4</b>
                                                                                </td-->
                                                                                                                            </tr>
                                                                                                                        </table>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:DataList>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:DataList>
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
                                                            </table>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="8">
                                                                    <uc4:PageNumber ID="PageNumber2" runat="server"></uc4:PageNumber>
                                                                </td>
                                                            </tr>
                                                            
                                                        </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="7">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <!--new -->
    </div>
    <div id="Div1">
        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td align="right">
                    Please click on <font class="t02">"Continue"</font> to determine final price for
                    your itinerary.&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="Continue" OnClick="btn_book_Click" CssClass="search_btn02" style="cursor:hand"/>&nbsp;&nbsp;<asp:Button
                        ID="Button2" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="search_btn03" style="cursor:hand"/></td>
            </tr>
        </table>
    </div>
</asp:Content>
