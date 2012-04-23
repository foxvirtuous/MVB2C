<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="TourFlightDetailInMailControl" Codebehind="TourFlightDetailInMailControl.ascx.cs" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<table class="T_step02" align="center" border="0" cellpadding="0" cellspacing="1"
    width="100%">
    <tr class="R_stepw">
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr align="center" class="R_order03">
                    <td height="23" colspan="7" align="center">
                        <b>Flight Information</b></td>
                </tr>
            </table>
            <asp:DataList ID="dlSubTrips" runat="server" Width="100%" AlternatingItemStyle-BackColor="Silver"
                BorderWidth="0" CellPadding="0" CellSpacing="0">
                <ItemTemplate>
                    <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step02">
                        <tr align="center" class="R_order">
                            <td height="23">
                                Departure - Jul 09,2008</td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="T_step02">
                                    <asp:DataList ID="dlFlights" runat="server" Width="100%" BorderWidth="0" CellPadding="0"
                                        CellSpacing="0" DataSource='<%#((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights %>'
                                        OnItemDataBound="dlFlights_ItemDataBound">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step02">
                                                        <tr align="left" class="R_stepw">
                                                            <td width="30%">
                                                                <b>
                                                                    <asp:Label ID="lbl_AirCode" runat="server" Text='<%# ((Airline)DataBinder.Eval((AirLeg)Container.DataItem, "AirLine")).Code %>'>
                                                                    </asp:Label>&nbsp;
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                                    </asp:Label>&nbsp;
                                                                    <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BookingClass") %>'>
                                                                    </asp:Label></b><br />
                                                            </td>
                                                            <td width="30%">
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                </asp:Label><br />
                                                                <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                                </asp:Label>
                                                                (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                                </asp:Label>)<br />
                                                            </td>
                                                            <td width="30%">
                                                                <asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                </asp:Label><br />
                                                                <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name") %>'>
                                                                </asp:Label>
                                                                (<asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") %>'>
                                                                </asp:Label>)<br />
                                                            </td>
                                                            <td align="center" width="10%">
                                                                <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                                </asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </table>
                            </td>
                        </tr>
                        <%--<tr class="R_stepg">
                              <td>
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="T_step02">
                                  <tr>
                                    <td>
                                      <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step02">
                                        <tr align="center" class="R_order">
                                          <td height="23">Return - Jul 17,2008</td>
                                        </tr>
                                      </table>
                                      <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step02">
                                        <tr align="left" class="R_stepw">
                                          <td width="30%"><b>UA&nbsp;0114&nbsp;</b><br />
                                    Aircraft:</td>
                                          <td width="30%">09:20 PM 05/30/2008<br />
                                    New york (JFK)<br /></td>
                                          <td width="30%">09:20 AM 05/31/2008<br />
                                    (LHR)<br /></td>
                                          <td align="center" width="10%">0 </td>
                                        </tr>
                                    </table></td>
                                  </tr>
                                  <tr>
                                    <td>
                                      <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                                        <tr align="left" class="R_stepw">
                                          <td width="30%"><b>UA&nbsp;0114&nbsp;</b><br />
                                    Aircraft:</td>
                                          <td width="30%">09:20 PM 05/30/2008<br />
                                    New york (JFK)<br /></td>
                                          <td width="30%">09:20 AM 05/31/2008<br />
                                    (LHR)<br /></td>
                                          <td align="center" width="10%">0 </td>
                                        </tr>
                                    </table></td>
                                  </tr>
                              </table></td>
                            </tr>--%>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
