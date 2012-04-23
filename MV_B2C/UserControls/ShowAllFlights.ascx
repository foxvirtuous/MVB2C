<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="ShowAllFlights" Codebehind="ShowAllFlights.ascx.cs" %>
<%@ Register Src="PageNumberControl.ascx" TagName="PageNumberControl" TagPrefix="uc3" %>
<%--<div id="Flight">
	<div id="sort">
		Sort by: <%--<input name="radiobutton" type="radio" value="radiobutton" /> <a href="#">Price</a>
		<input name="radiobutton" type="radio" value="radiobutton" /> <a href="#">Airline 
			Name</a> <input name="radiobutton" type="radio" value="radiobutton" /> <a href="#">
			Stop </a><input name="radiobutton" type="radio" value="radiobutton" /> <a href="#">
			Departure Time </a>
		<asp:RadioButton ID="rdoPrice" runat="server" GroupName="sort"  /><a href="#">Price</a>
		<asp:RadioButton ID="rdoAirline" runat="server"  GroupName="sort" /><a href="#">Airline Name</a>
		<asp:RadioButton ID="rdoStop" runat="server" GroupName="sort" /><a href="#">Stop</a>
		<asp:RadioButton ID="rdoDepartureTime" runat="server"  GroupName="sort" /><a href="#">Departure Time </a>
	</div>
	<div class="ShowFlight">
		<div class="singleFlight">
			
            <asp:DataList ID="DataList1" runat="server" Width="100%">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td>
                                <asp:GridView ID="gvDepartureFlight" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Departure Flight">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" />
                                                <asp:Label ID="lbAirLineName" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:BoundField DataField="LeavesTime" HeaderText="Leaves" />
                                        <asp:BoundField DataField="ArrivesTime" HeaderText="Arrives" />
                                        <asp:BoundField DataField="Class" HeaderText="Cabin" />
                                    </Columns>                                   
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gvReturnFlight" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Departure Flight">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" />
                                                <asp:Label ID="lbAirLineName" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Date" HeaderText="Date" />
                                        <asp:BoundField DataField="LeavesTime" HeaderText="Leaves" />
                                        <asp:BoundField DataField="ArrivesTime" HeaderText="Arrives" />
                                        <asp:BoundField DataField="Class" HeaderText="Cabin" />
                                    </Columns>                                   
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
                        
                        <tr>
					        <td width="85%" align="right" class="dealpri">Package Total: <asp:Label ID="lbTotalPrice" runat="server" Text='$000000'></asp:Label></td>
					        <td width="15%" align="right"><a href="search_result.html"><img src="images/btn_select.gif" width="56" height="25" border="0" /></a></td>
				        </tr>
				    </table>
                    
                </ItemTemplate>
            </asp:DataList>
            
		</div>
		<div class="page"><div class="turn">Previous | <a href="#">Next</a></div>
						View page: 1 <a href="#">2</a> <a href="#">3</a> <a href="#">4</a>
					</div>
	</div>
</div>--%>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Sales.Business" %>

<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="getFlight">
    <asp:DataList ID="dlAirGroup" runat="server" OnItemCommand="dlAirGroup_ItemCommand"   Width="100%">
        <ItemTemplate>
            
                   
                    <asp:DataList ID="dlSubTrips" runat="server" Width="100%" DataSource='<%# ((AirMaterial) ((List<AirMaterial>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Airs"))[0]).AirTrip.SubTrips %>'
                    OnItemDataBound="dlSubTrips_ItemDataBound">
                        <ItemTemplate>
                            <div class="DeptRet">
                                <asp:Label ID="lbDeptOrRtn" runat="server"></asp:Label>
                                -
                                <asp:Label ID="lbDepartureDate" runat="server"></asp:Label></div>
                            <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                
                                <tr class="R_titleL">
                                    <td width="35%" align="left">
                                        <font class="P_blue"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblDepartureFlight">Departure Flight</asp:Label></font></td>
                                    <td width="15%" align="left">
                                        <font class="P_blue"><asp:Label ID="Label4" runat="server" meta:resourcekey="lblDate">Date</asp:Label></font></td>
                                    <td width="15%" align="left">
                                        <font class="P_blue"><asp:Label ID="Label5" runat="server" meta:resourcekey="lblLeaves">Leaves</asp:Label></font></td>
                                    <td width="20%" align="left">
                                        <font class="P_blue"><asp:Label ID="Label6" runat="server" meta:resourcekey="lblArrives">Arrives</asp:Label></font></td>
                                    <td width="15%" align="left">
                                        <font class="P_blue"><asp:Label ID="Label7" runat="server" meta:resourcekey="lblCabin">Cabin</asp:Label></font></td>
                                </tr>
                                <!--OUTBOUND FLIGHT-->
                            </table>
                            <asp:DataList ID="dlFlights" runat="server" Width="100%" DataSource='<%# ((SubAirTrip)DataBinder.Eval(Container, "DataItem")).Flights %>' OnItemDataBound="dlFlights_ItemDataBound">
                                <ItemTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                        <tr>
                                            <td width="35%">
                                                <asp:Image  id="AirImgRtn" Runat="server" alt='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>' width="18" height="18" ></asp:Image>
                                               
                                                <asp:Label ID="lbAirLine" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'></asp:Label>
                                                #
                                                <asp:Label ID="lbNumber" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>*</asp:Label><br />
                                                <asp:Label ID="lbDepartureCity" runat="server" Text='<%# "From:" + DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name")%> '></asp:Label>
                                                <asp:Label ID="lbDepartureCode" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") + ")" %>'></asp:Label>
                                                <br />
                                                <asp:Label ID="Label2" runat="server" Text='<%# "To:" + DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name")%> '></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") + ")" %>'></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lbDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("MMM dd", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lbLeaves" runat="server" Text='<%#  Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                            </td>
                                            <td width="20%">
                                                <asp:Label ID="lbArrives" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'></asp:Label>
                                            </td>
                                            <td width="15%">
                                                <asp:Label ID="lbCabin" runat="server" Text='Economy'></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                            <div class="note">
                       
                        </ItemTemplate>
                    </asp:DataList>
                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
									<tr>
										<td width="85%" align="right" class="dealpri"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblTotal">Package Total</asp:Label>: <asp:Label ID="lbTotalPrice" runat="server" Text='<%# ((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice.ToString("$#,###")%>'></asp:Label></td>
										<td width="15%" align="right"><asp:ImageButton ID="btnSelect" runat="server" CommandName="Select" ImageUrl="../images/v1/btn_select.gif" width="56" height="25" BorderStyle="None" />  </td>
									</tr>
								</table>
                    </div>
                
            
        </ItemTemplate>
    </asp:DataList>
    
</div>

<uc3:PageNumberControl ID="PageNumberControl1" runat="server" />

<%--<div class="page">
    <div class="turn">
        <asp:HyperLink ID="hlPrevious" runat="server">Previous</asp:HyperLink>
        |
        <asp:HyperLink ID="hlNext" runat="server">Next</asp:HyperLink>
    </div>
    View page:
    <asp:HyperLink ID="hlStar" runat="server">...</asp:HyperLink>
    <asp:HyperLink ID="hl1" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl2" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl3" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl4" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl5" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hlEnd" runat="server">...</asp:HyperLink></div>--%>
