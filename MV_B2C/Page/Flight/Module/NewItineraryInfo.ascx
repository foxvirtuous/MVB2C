<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="NewItineraryInfo" Codebehind="NewItineraryInfo.ascx.cs" %>
<div class="P_table">



<!--new -->
<table width="735" border="0" cellpadding="0" cellspacing="1" class="T_step02">
      <tr class="R_step02">
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><table width="100%"  border="0" cellspacing="0" cellpadding="8">
              <tr>
                <td><table width="100%"  border="0" cellpadding="0" cellspacing="0">
                  <tr align="left">
                    <td height="25" valign="top" class="D_stepr">Review Current Itinerary</td>
                  </tr>
                  <tr>
                    <td><table width="100%"  border="0" cellspacing="1" cellpadding="8" class="T_step03">
                        <tr class="R_stepw">
                          <td><table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                              <tr valign="top">
                                <td><table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                                    <tr align="left" valign="top">
                                      <td colspan="2"> <font class="t06">Departure</font></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                      <td height="20"> <strong>Date:</strong></td>
                                       <td>
                                        <asp:Label ID="lbl_DepartureDate" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                      <td width="50" height="20"> <strong>From:</strong></td>
                                      <td>
                                       <asp:Label ID="lbl_DepartureCity" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                      <td height="20"> <strong>To:</strong></td>
                                        <td>
                                        <asp:Label ID="lbl_DestinationCity" runat="server"></asp:Label></td>
                                    </tr>
                                </table></td>
                                 <asp:PlaceHolder ID="phRtnInfo" Visible="true" runat="server">
                                <td bgcolor="#CCCCCC" width="1"></td>
                                <td><table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                                    <tr align="left" valign="top">
                                      <td colspan="2"> <font class="t06">Return</font></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                      <td height="20"> <strong>Date:</strong></td>
                                      <td>
                                            <asp:Label ID="lbl_ArrivalDate" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                      <td width="50" height="20"> <strong>From:</strong></td>
                                      <td>
                                            <asp:Label ID="lbl_ReturnFromCity" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                      <td height="20"> <strong>To:</strong></td>
                                       <td>
                                            <asp:Label ID="lbl_ReturnToCity" runat="server"></asp:Label></td>
                                    </tr>
                                </table></td>
                                 </asp:PlaceHolder>
                              </tr>
                          </table>
                          <asp:PlaceHolder ID="phFareDetail" runat="server">
                           <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
								  <tr align="center">
                                      <td colspan="3" height="7"></td>
                                    </tr>
                                    <tr align="center">
                                      <td colspan="3" bgcolor="#CCCCCC" height="1"></td>
                                    </tr>
                                    <tr align="center">
                                      <td><font class="t02"> <asp:Label ID="lbl_AdultFare" runat="server"></asp:Label> USD</font><br />
      Adult (<asp:Label ID="lbl_AdultNum" runat="server"></asp:Label>)</td>
                                      <td><font class="t02"><asp:Label ID="lbl_ChildFare" runat="server"></asp:Label> USD</font><br />
      Child (<asp:Label ID="lbl_ChildNum" runat="server"></asp:Label>)</td>
                                    </tr>
                                  </table>
                          </asp:PlaceHolder>
                <asp:PlaceHolder ID="phFlightInfo" runat="server">
                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                    <table width="95%" border="0" align="center" cellpadding="0" cellspacing="1" class="T_box">
                        <tr class="R_content">
                            <td align="center">
                                <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                    <tr align="center" class="R_titleD">
                                        <td colspan="4">
                                            <b>Flight Information</b></td>
                                    </tr>
                                    <tr class="R_titleL">
                                        <td width="15%" align="left">
                                            <font class="P_blue">Flight Info</font></td>
                                        <td width="35%" align="left">
                                            <font class="P_blue">Departure</font></td>
                                        <td width="35%" align="left">
                                            <font class="P_blue">Arrive</font></td>
                                        <td width="10%" align="center">
                                            <font class="P_blue">Stops</font></td>
                                    </tr>
                                </table>
                                <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                    <!-- Line 1-->
                                    <asp:DataList ID="dlFlights" runat="server" Width="100%" AlternatingItemStyle-BackColor="Silver">
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                                <tr align="left">
                                                    <td width="15%">
                                                        <b>
                                                            <asp:Label ID="lbl_AirCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'>
                                                            </asp:Label>
                                                            &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                            </asp:Label>&nbsp;
                                                            <asp:Label ID="Label10" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.BookingClass") %>'>
                                                            </asp:Label></b><br />
                                                        Aircraft:<font class="P_blue">
                                                            <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AircraftCode") %>'>
                                                            </asp:Label></font>
                                                    </td>
                                                    <td width="35%">
                                                        <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                        </asp:Label><br />
                                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                        </asp:Label>
                                                        (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                        </asp:Label>)<br />
                                                    </td>
                                                    <td width="35%">
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
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </table>
                </asp:PlaceHolder>
                          
                          </td>
                        </tr>
                    </table></td>
                  </tr>
                </table></td>
              </tr>
            </table></td>
          </tr>
          <tr class="R_step04">
            <td height="20">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
    </table>
<!-- new -->
    
</div>
