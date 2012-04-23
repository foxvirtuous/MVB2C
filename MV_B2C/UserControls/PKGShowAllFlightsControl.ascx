<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGShowAllFlightsControl.ascx.cs"
    Inherits="PKGShowAllFlightsControl" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:DataList ID="dlAirGroup" runat="server" OnItemCommand="dlAirGroup_ItemCommand"
    Width="100%" OnItemDataBound="dlAirGroup_ItemDataBound" CellPadding="0" CellSpacing="0">
    <ItemTemplate>
        <div class="IBE_T_step0l_listBJ10">
            <table class="IBE_T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                width="100%">
                <tr class="IBE_R_stepw">
                    <td align="center">
                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                            <tr class="IBE_R_step03 IBE_T_font11">
                                <td height="35">
                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlightOption">Flight Option</asp:Label>
                                    #
                                    <asp:Label ID="Label3" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                                    <asp:Label ID="Label11" runat="server" Text='<%# ((AirMaterial) ((List<AirMaterial>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Airs"))[0]).FareType %>'
                                        Visible="false"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:DataList ID="dlSubTrips" runat="server" Width="100%" DataSource='<%# ((AirMaterial) ((List<AirMaterial>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Airs"))[0]).AirTrip.SubTrips %>'
                            OnItemDataBound="dlSubTrips_ItemDataBound" CellPadding="0" CellSpacing="0">
                            <ItemTemplate>
                                <%-- <div class="DeptRet">
                        <asp:Label ID="lbDeptOrRtn" runat="server"></asp:Label>
                        -
                        <asp:Label ID="lbDepartureDate" runat="server"></asp:Label></div>--%>
                                <asp:PlaceHolder ID="phTable" runat="server">
                                    <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03 IBE_T_font11"
                                        runat="server" id="tbHead">
                                        <tr class="IBE_R_order">
                                            <td width="25%" height="23" align="center">
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
                                </asp:PlaceHolder>
                                <asp:DataList ID="dlFlights" runat="server" Width="100%" DataSource='<%# ((SubAirTrip)DataBinder.Eval(Container, "DataItem")).Flights %>'
                                    OnItemDataBound="dlFlights_ItemDataBound" CellPadding="0" CellSpacing="0">
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="IBE_T_step03"
                                            align="left">
                                            <tr class="IBE_R_stepw">
                                                <td width="25%" align="left">
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
                                                <td width="25%" align="left">
                                                    <asp:Label ID="lblDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                    </asp:Label>
                                                    <br />
                                                    <asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                    </asp:Label>
                                                    (<asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                    </asp:Label>)<br />
                                                </td>
                                                <td width="25%" align="left">
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
                                                <td width="15%" align="center">
                                                    <asp:Label ID="lblFlightDuration" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                    </asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                                <div class="note">
                            </ItemTemplate>
                        </asp:DataList>
                        <%--            <table width="100%" border="0" cellspacing="0" cellpadding="2">
                <tr>
                    <td width="85%" align="right" class="dealpri">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblTotal">Package Total</asp:Label>:
                        <asp:Label ID="lbTotalPrice" runat="server" Text='<%# ((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice.ToString("$#,###")%>'></asp:Label></td>
                    <td width="15%" align="right">
                        <asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ImageUrl="../images/v1/btn_select.gif"
                            Width="56" Height="25" BorderStyle="None" />
                    </td>
                </tr>
            </table>--%>
                        <div style="margin-top: 5px; margin-bottom: 5px; float: right;">
                            <span class="font_s15">
                                <asp:Label ID="lblArrive" runat="server" meta:resourcekey="lblFlightAndHotel">Flight and Hotel</asp:Label>:
                                $<asp:Label ID="lblAvgPrice" runat="server">974.53</asp:Label></span>
                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblAvg">avg/person</asp:Label>
                            (<asp:Label ID="Label4" runat="server" meta:resourcekey="lblTCN"></asp:Label>$<asp:Label
                                ID="lblTotal" runat="server" Text='<%# ((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice.ToString("#,###")%>'></asp:Label>
                            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblTotal">total</asp:Label>)
                            &nbsp;&nbsp;
                            <asp:Button ID="btnChoose" runat="server" CommandName="Select" Text="Choose this flight"
                                CssClass="search_btn06 IBE_T_font11" meta:resourcekey="btnChoose" />&nbsp;&nbsp;</div>
                    </td>
                </tr>
            </table>
        </div>
    </ItemTemplate>
</asp:DataList>
<uc4:PageNumber ID="PageNumber1" runat="server" />
