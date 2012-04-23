<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGFlightDetailsControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGFlightDetailsControl" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr class="IBE_R_stepw">
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" width="100%" class="IBE_T_titleFONTstyle">
                <tr align="center" class="IBE_R_step03 IBE_T_titleFONTstyle">
                    <td height="35" colspan="7" align="left">
                        &nbsp;&nbsp;<b><asp:Label ID="Label2" runat="server" meta:resourcekey="lblFlightInformation">Flight Information</asp:Label></b></td>
                </tr>
            </table>
            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03 IBE_T_titleFONTstyle"
                align="center">
                <tr class="IBE_R_order">
                    <td width="25%" height="25" align="center">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlightInfo">Flight Info</asp:Label></td>
                    <td width="25%" align="center">
                        <asp:Label ID="lblDeparture" runat="server" meta:resourcekey="lblDeparture">Departure</asp:Label></td>
                    <td width="25%" align="center">
                        <asp:Label ID="lblArrive" runat="server" meta:resourcekey="lblArrive">Arrival</asp:Label></td>
                    <td width="10%" align="center">
                        <asp:Label ID="lblStops" runat="server" meta:resourcekey="lblStops">Stops</asp:Label></td>
                    <td width="15%" align="center">
                        <asp:Label ID="lblDuration" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label></td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="IBE_T_font_11">
                <!-- Line 1-->
                <tr align="left">
                    <td>
                        <asp:DataList ID="dlAirGroup" runat="server" Width="100%" OnItemCommand="dlAirGroup_ItemCommand"
                            AlternatingItemStyle-BackColor="Silver" BorderWidth="0" CellPadding="0" CellSpacing="0">
                            <ItemTemplate>
                                <asp:DataList ID="dlSubTrips" runat="server" Width="100%" DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'
                                    OnItemDataBound="dlSubTrips_ItemDataBound" BorderWidth="0" CellPadding="0" CellSpacing="0">
                                    <ItemTemplate>
                                        <asp:DataList ID="dlFlights" runat="server" Width="100%" DataSource='<%# ((SubAirTrip)DataBinder.Eval(Container, "DataItem")).Flights %>'
                                            OnItemDataBound="dlFlights_ItemDataBound" CellPadding="0" CellSpacing="0">
                                            <ItemTemplate>
                                                <table width="100%" border="0" cellspacing="1" cellpadding="12" class="IBE_T_step03">
                                                    <tr align="left" class="IBE_R_stepw">
                                                        <td width="25%">
                                                            <asp:Image ID="AirImgRtn" runat="server" alt='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'
                                                                Width="18" Height="18"></asp:Image>
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
                                                            <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                            </asp:Label>
                                                            (<asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
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
                                                            </asp:Label>
                                                        </td>
                                                        <td width="15%">
                                                            <asp:Label ID="lblFlightDuration" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </ItemTemplate>
                                </asp:DataList>
                                <div class="note">
                                    <asp:Label ID="lbNotes" runat="server" ForeColor="red" Text=''></asp:Label>
                                </div>
                                <div class="IBE_package_changeLB" align="right">
                                    <asp:LinkButton ID="lkbChange" runat="server" Text="Change Flight" CommandName="Select"
                                        meta:resourcekey="lkbChangeFlight" CssClass="IBE_package_SearchCondition_f09"></asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:DataList>
                        <asp:Label ID="lbDispMessage" ForeColor="black" runat="server" Visible="false" Style="text-align: left;
                            margin: 0 auto;"></asp:Label>
                        <p>
                            <asp:Label ID="lbDispWarnMessage" ForeColor="red" runat="server" Visible="false"></asp:Label></p>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
