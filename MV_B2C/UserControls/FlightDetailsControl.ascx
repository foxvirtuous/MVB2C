<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="FlightDetailsControl" Codebehind="FlightDetailsControl.ascx.cs" %>
<%--<asp:PlaceHolder ID="phFlightInfo" runat="server">--%>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr >
        <td height="10">
        </td>
    </tr>
</table>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="1" class="T_step03">
    <tr class="IBE_R_stepw">
        <td align="center">
            <table border="0" cellspacing="0" cellpadding="2" width="100%" class="IBE_T_titleFONTstyle">
                <tr align="center" class="IBE_R_step03 IBE_T_titleFONTstyle">
                    <td colspan="4">
                        <b>
                            <asp:Label ID="lblFlightInformation" runat="server" meta:resourcekey="lblFlightInformation">Flight Information</asp:Label></b></td>
                </tr>
            </table>
            
            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03 IBE_T_titleFONTstyle">
                <tr class="IBE_R_order">
                    <td width="25%" height="23">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlightInfo">Flight Info</asp:Label></td>
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
                <!-- Line 1-->
                <tr align="left">
                    <td>
                        <asp:DataList ID="dlFlights" runat="server" Width="100%" AlternatingItemStyle-BackColor="Silver"
                            BorderWidth="0" CellPadding="0" CellSpacing="0" OnItemDataBound="dlFlights_ItemDataBound">
                            <ItemTemplate>
                                <table border="0" cellspacing="1" cellpadding="3" width="100%" class="IBE_T_step03">
                                    <tr align="left" class="IBE_R_stepw">
                                        <td width="25%">
                                            <b>
                                                <asp:Label ID="lbl_AirCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'>
                                                </asp:Label>
                                                &nbsp;<asp:Label ID="lblFlightNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                </asp:Label>&nbsp;<br />
                                                <asp:Label ID="lblOperatingAirline" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td width="25%">
                                            <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                            </asp:Label>
                                            <asp:Label ID="lblDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                            </asp:Label>
                                            <br />
                                            <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                            </asp:Label>
                                            (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                            </asp:Label>)<br />
                                        </td>
                                        <td width="25%">
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
                                            </asp:Label></td>
                                        <td width="15%" align="center">
                                            <asp:Label ID="lblFlightDuration" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                            </asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label ID="lbDispMessage" ForeColor="black" runat="server" Visible="false" Style="text-align: left;
                            margin: 0 auto;"></asp:Label><br />
                        <asp:Label ID="lbDispWarnMessage" ForeColor="red" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <div style="float: left; margin-top: 3px;">
                <asp:Label ID="lblTotalDistanceMsg" meta:resourcekey="lblTotalDistanceMsg" runat="server"
                    Text="Label">Total distance: </asp:Label><asp:Label ID="lblTotalDistance" runat="server"
                        Text="Label">9,922 mi (15,968 km) </asp:Label></div>
            <div style="float: right; margin-top: 3px;">
                <asp:Label ID="lblTotalDurationMsg" meta:resourcekey="lblTotalDurationMsg" runat="server"
                    Text="Label">Total duration: </asp:Label><asp:Label ID="lblTotalDuration" runat="server"
                        Text="Label">19hr 55mn </asp:Label><asp:Label ID="lblTotalDurationMsgPostFix1" meta:resourcekey="lblTotalDurationMsgPostFix"
                            runat="server" Text="Label"> with connections)</asp:Label></div>
        </td>
    </tr>
</table>
