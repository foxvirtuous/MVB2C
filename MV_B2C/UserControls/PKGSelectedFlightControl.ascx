<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGSelectedFlightControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGSelectedFlightControl" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<div class="getFlight" style="float: left; width: 100%;">
    <asp:DataList ID="dlAirGroup" runat="server" Width="100%" BorderWidth="0" CellPadding="0"
        CellSpacing="0">
        <ItemTemplate>
            <%-- <div class="IBE_package_step6_TravelerInformation_title" align="center">
                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlights">Currently Selected Flights</asp:Label></h2></div>--%>
            <asp:DataList ID="dlSubTrips" runat="server" Width="100%" DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'
                OnItemDataBound="dlSubTrips_ItemDataBound" BorderWidth="0" CellPadding="0" CellSpacing="0">
                <ItemTemplate>
                    <div class="IBE_package_step6_TravelerInformation_title2">
                        <asp:Label ID="lbDeptOrRtn" runat="server"></asp:Label>
                        <asp:Label ID="lbDepartureDate" runat="server"></asp:Label></div>
                    <asp:DataList ID="dlFlights" runat="server" Width="100%" DataSource='<%# ((SubAirTrip)DataBinder.Eval(Container, "DataItem")).Flights %>'
                        OnItemDataBound="dlFlights_ItemDataBound" CellPadding="0" CellSpacing="0">
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="1" cellpadding="6" class="IBE_T_step03">
                                <tr class="IBE_R_stepw" align="left">
                                    <td width="25%">
                                        <asp:Image ID="AirImgRtn" runat="server" alt='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'
                                            Width="18" Height="18"></asp:Image>
                                        <a href="#" style="text-decoration: none; font-weight: bold; color: #000;">
                                            <asp:Label ID="lbAirLine" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'></asp:Label>
                                            #
                                            <asp:Label ID="lbNumber" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'></asp:Label>
                                        </a>
                                        <br />
                                        <asp:Label ID="lblOperatingAirline" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td width="40%">
                                        <asp:Label ID="lbDepartureDate" runat="server" Text='<%# "Departure:" + Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label1" runat="server" Text='<%# "Arrive:" + Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                    </td>
                                    <td width="35%">
                                        <asp:Label ID="lbDepartureCity" runat="server" Text='<%# "From:" + DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name")%> '></asp:Label>
                                        <asp:Label ID="lbDepartureCode" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") + ")" %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label2" runat="server" Text='<%# "To:" + DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name")%> '></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") + ")" %>'></asp:Label>
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
        </ItemTemplate>
    </asp:DataList>
</div>
