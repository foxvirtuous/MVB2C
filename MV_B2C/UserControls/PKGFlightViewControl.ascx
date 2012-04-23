<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGFlightViewControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGFlightViewControl" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%" style="float: left;
    text-align: left;">
    <tr>
        <td>
            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03">
                <tr class="IBE_R_order">
                    <td width="25%" height="23">
                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblFlightInfo">Flight Info</asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="lblDeparture" runat="server" meta:resourcekey="lblDeparture">Departure</asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="lblArrive" runat="server" meta:resourcekey="lblArrive">Arrival</asp:Label></td>
                    <td width="10%">
                        <asp:Label ID="lblStops" runat="server" meta:resourcekey="lblStops">Stops</asp:Label></td>
                    <td width="15%">
                        <asp:Label ID="lblDuration" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label></td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td colspan="2">
                        <!-- Line 1-->
                        <asp:DataList ID="dlFlight" runat="server" Width="100%" AlternatingItemStyle-BackColor="Silver"
                            BorderWidth="0" CellPadding="0" CellSpacing="0" OnItemDataBound="dlFlight_ItemDataBound">
                            <ItemTemplate>
                                <table border="0" cellspacing="1" cellpadding="3" width="100%" class="IBE_T_step03">
                                    <tr align="left" class="IBE_R_stepw">
                                        <td width="25%">
                                            <b>
                                                <asp:Label ID="lbl_AirCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'>
                                                </asp:Label>
                                                &nbsp;<asp:Label ID="lblFlightNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                </asp:Label>&nbsp; </b>
                                            <br />
                                            <asp:Label ID="lblOperatingAirline" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="25%">
                                            <asp:Label ID="lblDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                            </asp:Label>
                                            <br />
                                            <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                            </asp:Label>
                                            (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                            </asp:Label>)<br />
                                        </td>
                                        <td width="25%">
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
                                            </asp:Label></td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lblFlightDuration" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                            </asp:Label></td>
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
