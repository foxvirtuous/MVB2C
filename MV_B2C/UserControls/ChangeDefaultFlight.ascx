<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="ChangeDefaultFlight" Codebehind="ChangeDefaultFlight.ascx.cs" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<div class="getFlight">
    <asp:DataList ID="dlAirGroup" runat="server" Width="100%" >
        <ItemTemplate>
            <h2>
              <asp:Label ID="Label2" runat="server" meta:resourcekey="lblOriginalFlights">Original Flights</asp:Label></h2>
            <asp:DataList ID="dlSubTrips" runat="server" Width="100%" DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips  %>'
                OnItemDataBound="dlSubTrips_ItemDataBound">
                <ItemTemplate>
                    <div class="DeptRet">
                        <asp:Label ID="lbDeptOrRtn" runat="server"></asp:Label>
                        -
                        <asp:Label ID="lbDepartureDate" runat="server"></asp:Label></div>
                    <asp:DataList ID="dlFlights" runat="server" Width="100%" DataSource='<%# ((SubAirTrip)DataBinder.Eval(Container, "DataItem")).Flights %>'  OnItemDataBound="dlFlights_ItemDataBound" >
                        <ItemTemplate>
                            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                <tr>
                                    <td width="7%">
                                        <asp:Image  id="AirImgRtn" Runat="server" alt='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>' width="18" height="18" ></asp:Image></td>
                                    <td width="24%">
                                        <asp:Label ID="lbAirLine" runat="server" Text='<%#  DataBinder.Eval(Container, "DataItem.Airline.Code") %>'></asp:Label>
                                        #
                                        <asp:Label ID="lbNumber" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'></asp:Label>
                                    </td>
                                    <td width="31%">
                                        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblDeparture">Departure</asp:Label>:&nbsp;<asp:Label ID="lbDepartureDate" runat="server" Text='<%#  Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblArrive">Arrive</asp:Label>:&nbsp;<asp:Label ID="Label1" runat="server" Text='<%#  Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                    </td>
                                    <td width="38%">
                                        <asp:Label ID="Label6" runat="server" meta:resourcekey="lblFrom">From</asp:Label>:&nbsp;<asp:Label ID="lbDepartureCity" runat="server" Text='<%#  DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name")%>  '></asp:Label>
                                        <asp:Label ID="lbDepartureCode" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") + ")" %>'></asp:Label>
                                        <br />
                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblTo">To</asp:Label>:&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name")%> '></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") + ")" %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </ItemTemplate>
            </asp:DataList>
           
        </ItemTemplate>
    </asp:DataList>
</div>
