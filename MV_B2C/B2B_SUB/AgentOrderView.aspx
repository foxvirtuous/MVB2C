<%@ Page Language="C#" AutoEventWireup="true" Inherits="AgentOrderView" Codebehind="AgentOrderView.aspx.cs" %>

<%@ Register Src="~/UserControls/AgentLeftMenu.ascx" TagName="MemberLeftMenu" TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Sales.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="content">
            <uc1:Header ID="Header1" runat="server" />
            <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
                z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
                marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
            </iframe>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="45" align="left" valign="bottom" class="D_title">
                        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblAgentOrderView1">Membership: My Orders</asp:Label></td>
                </tr>
            </table>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <br>
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td width="20%" align="center" valign="top">
                                    <uc3:MemberLeftMenu ID="MemberLeftMenu1" runat="server" />
                                </td>
                                <td width="80%" align="left" valign="top">
                                    <table cellspacing="1" cellpadding="3" width="100%" border="0" class="T_table">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="50%" style="height: 19px">
                                                            <span class="head01">
                                                                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblAgentOrderView2">Order Detail</asp:Label></span></td>
                                                        <td width="50%" align="right" style="height: 19px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" background="../images/index/dot01.gif" style="height: 14px">
                                                            <img src="../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                    <tr>
                                                        <td width="15%">
                                                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblAgentOrderView3">Case Number :</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCaseNumber" runat="server"></asp:Label>
                                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Visible="False" />
                                                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="PNR" Visible="False" />
                                                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Gta" Visible="False" />
                                                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" Visible="False" />
                                                            <asp:Label ID="lblSourseType" runat="server" Visible="false"></asp:Label></td>
                                                    </tr>
                                                    <asp:PlaceHolder runat="server" ID="phPNR" Visible="true">
                                                        <tr>
                                                            <td style="height: 25px">
                                                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblAgentOrderView4">Record Locator :</asp:Label>
                                                            </td>
                                                            <td style="height: 25px">
                                                                <asp:Label ID="lblRecordLocator" runat="server"></asp:Label>
                                                                <asp:Label ID="lblGtaRefNumber" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </asp:PlaceHolder>
                                                    <tr>
                                                        <td style="height: 25px">
                                                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblAgentOrderView5">Payment Status:</asp:Label>
                                                        </td>
                                                        <td style="height: 25px">
                                                            <asp:Label ID="lblPaymentStatus" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblAgentOrderView6">OP Status:</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOPStatus" runat="server"></asp:Label><asp:LinkButton ID="btnInvoice" runat="server" OnClick="btnInvoice_Click">View Invoice</asp:LinkButton></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="50%" style="height: 19px">
                                                            <span class="head01">
                                                                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblAgentOrderView7">Passenger Detail</asp:Label></span></td>
                                                        <td width="50%" align="right" style="height: 19px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                            <img src="../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <asp:GridView ID="gvPassengerDetail" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                    Width="100%" OnRowDataBound="gvPassengerDetail_RowDataBound">
                                                    <AlternatingRowStyle CssClass="R_order02" Height="25" />
                                                    <RowStyle CssClass="R_order01" HorizontalAlign="Center" Height="25" />
                                                    <HeaderStyle CssClass="R_order" HorizontalAlign="Center" Height="25" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Name Passenger" DataField="FullName" meta:resourcekey="Passenger1" />
                                                        <asp:BoundField HeaderText="Type" DataField="PassengerType" meta:resourcekey="Passenger2" />
                                                        <asp:BoundField HeaderText="Birthday" DataField="Birthday" DataFormatString="{0:MM/dd/yyyy}"
                                                            meta:resourcekey="Passenger3" />
                                                        <asp:BoundField HeaderText="Meal" DataField="Meal" meta:resourcekey="Passenger4" />
                                                        <asp:BoundField HeaderText="Passport Number" DataField="PassportNumber" meta:resourcekey="Passenger5" />
                                                    </Columns>
                                                </asp:GridView>
                                                <div runat="server" id="divFlight" visible="false">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="height: 19px">
                                                            </td>
                                                            <td style="height: 19px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%">
                                                                <span class="head01">
                                                                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblAgentOrderView8">Flight Info</asp:Label></span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                                <img src="../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvFlightInfo" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                        Width="100%" OnDataBinding="gvFlightInfo_DataBinding" OnRowDataBound="gvFlightInfo_RowDataBound">
                                                        <AlternatingRowStyle CssClass="R_order02" />
                                                        <RowStyle CssClass="R_order01" HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="R_order" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Flight No" DataField="FlightNo" meta:resourcekey="Flight1" />
                                                            <asp:BoundField HeaderText="Routing" DataField="Routing" meta:resourcekey="Flight2" />
                                                            <asp:BoundField HeaderText="Date" DataField="DepartureDate" DataFormatString="{0:f}"
                                                                meta:resourcekey="Flight3" />
                                                            <asp:BoundField HeaderText="Leaves / Arrives" DataField="LeavesArrives" meta:resourcekey="Flight4" />
                                                            <asp:BoundField HeaderText="Cabin / Class" DataField="BookingClass" meta:resourcekey="Flight5" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div runat="server" id="divTourItinerary" visible="false">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="height: 19px">
                                                            </td>
                                                            <td style="height: 19px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%">
                                                                <span class="head01">
                                                                    <asp:Label ID="Label9" runat="server" meta:resourcekey="lblAgentOrderView9">Tour Info</asp:Label></span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                                <img src="../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvTourInfo" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                        Width="100%" OnDataBinding="gvTourInfo_DataBinding" OnRowDataBound="gvTourInfo_RowDataBound">
                                                        <AlternatingRowStyle CssClass="R_order02" />
                                                        <RowStyle CssClass="R_order01" HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="R_order" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Tour Name" DataField="TourName" meta:resourcekey="Tour1" />
                                                            <asp:BoundField HeaderText="Description" DataField="Description" meta:resourcekey="Tour2" />
                                                            <asp:BoundField HeaderText="Guide" DataField="Guide" meta:resourcekey="Tour3" />
                                                            <asp:BoundField HeaderText="Days" DataField="Days" meta:resourcekey="Tour4" />
                                                            <asp:BoundField HeaderText="Nights" DataField="Nights" meta:resourcekey="Tour5" />
                                                            <asp:BoundField HeaderText="Begin Date" DataField="BeginDate" DataFormatString="{0:f}"
                                                                meta:resourcekey="Tour6" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="height: 19px">
                                                            </td>
                                                            <td style="height: 19px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%">
                                                                <span class="head01">
                                                                    <asp:Label ID="Label10" runat="server" meta:resourcekey="lblAgentOrderView10"></asp:Label>Tour
                                                                    Itinerary Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                                <img src="../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvItineraryInfo" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                        Width="100%" OnDataBinding="gvItineraryInfo_DataBinding" OnRowDataBound="gvItineraryInfo_RowDataBound">
                                                        <AlternatingRowStyle CssClass="R_order02" />
                                                        <RowStyle CssClass="R_order01" HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="R_order" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Day No" DataField="NumberOfDay" meta:resourcekey="TourItinerary1" />
                                                            <asp:BoundField HeaderText="Description" DataField="Description" meta:resourcekey="TourItinerary2" />
                                                            <asp:BoundField HeaderText="Meal Type" DataField="NumberOfDay" meta:resourcekey="TourItinerary3" />
                                                            <asp:BoundField HeaderText="Hotel Info" DataField="HotelDescription" meta:resourcekey="TourItinerary4" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div runat="server" id="divHotel" visible="false">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="15">
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%">
                                                                <span class="head01">
                                                                    <asp:Label ID="Label11" runat="server" meta:resourcekey="lblAgentOrderView11">Hotel Info</asp:Label></span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                                <img src="../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:DataList ID="dlHotel" runat="server" Width="100%">
                                                        <ItemTemplate>
                                                            <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                                <tr align="center" class="R_order">
                                                                    <td width="45%" style="height: 31px">
                                                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="Hotel1">Hotel Name</asp:Label>
                                                                    </td>
                                                                    <td width="15%" style="height: 31px">
                                                                        <asp:Label ID="Label12" runat="server" meta:resourcekey="Hotel2">Check In</asp:Label>
                                                                    </td>
                                                                    <td width="15%" style="height: 31px">
                                                                        <asp:Label ID="Label13" runat="server" meta:resourcekey="Hotel3">Check Out</asp:Label>
                                                                    </td>
                                                                    <td width="10%" style="height: 31px">
                                                                        <asp:Label ID="Label14" runat="server" meta:resourcekey="Hotel4">Total Nights</asp:Label>
                                                                    </td>
                                                                    <td width="15%" style="height: 31px">
                                                                        <asp:Label ID="Label15" runat="server" meta:resourcekey="Hotel5">City</asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr align="center" class="R_order01">
                                                                    <td height="25" align="left" width="45%">
                                                                        <asp:Label ID="lblHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HotelName") %>'></asp:Label></td>
                                                                    <td width="15%">
                                                                        <asp:Label ID="lblCheckin" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "BeginDate")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                                                    </td>
                                                                    <td width="15%">
                                                                        <asp:Label ID="lblCheckout" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EndDate")).ToString("MM/dd/yyyy") %>'></asp:Label></td>
                                                                    <td width="10%">
                                                                        <asp:Label ID="lblTotalNights" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TotalNights") %>'></asp:Label></td>
                                                                    <td width="15%">
                                                                        <asp:Label ID="lblCity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CityName") %>'></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr align="center" class="R_order">
                                                                    <td height="25" colspan="4">
                                                                        <asp:Label ID="Label16" runat="server" meta:resourcekey="Hotel6">Rooms Detailed Information
                                                                        </asp:Label>&nbsp;&nbsp;<asp:LinkButton ID="lkbHotelVoucher" runat="server" Text="Email Hotel Voucher"
                                                                            PostBackUrl="~/Page/Hotel2/HotelVoucherForm.aspx" Visible="false"></asp:LinkButton>
                                                                    </td>
                                                                    <td height="25">
                                                                        <asp:Label ID="Label17" runat="server" meta:resourcekey="Hotel7">Rooms Stuatus</asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr align="center" class="R_order01">
                                                                    <td height="25" colspan="4">
                                                                        <asp:Label ID="lblHotelCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "HotelCode") %>'
                                                                            Visible="false"></asp:Label>
                                                                        <asp:Label ID="lblRooms" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoomsDetailedInformation") %>'></asp:Label>
                                                                    </td>
                                                                    <td height="25">
                                                                        <asp:Label ID="lblState" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                </div>
                                                <div runat="server" id="divInsurance" visible="false">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="15">
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%">
                                                                <span class="head01">
                                                                    <asp:Label ID="Label18" runat="server" meta:resourcekey="lblAgentOrderView12">Insurance Info</asp:Label></span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                                <img src="../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                        <tr align="center" class="R_order">
                                                            <td height="25">
                                                                <asp:Label ID="Label19" runat="server" meta:resourcekey="Insurance1">Insurance Name</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label20" runat="server" meta:resourcekey="Insurance2">Insurance Status</asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="Label21" runat="server" meta:resourcekey="Insurance3">Total Price</asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="center" class="R_order01">
                                                            <td height="25">
                                                                <asp:Label ID="lblInsuranceName" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblInsuranceStatus" runat="server"></asp:Label></td>
                                                            <td>
                                                                $<asp:Label ID="lblInsuranceTotal" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="15">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%">
                                                            <span class="head01">
                                                                <asp:Label ID="Label22" runat="server" meta:resourcekey="lblAgentOrderView13">Price Info</asp:Label></span></td>
                                                        <td width="50%" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                            <img src="../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                    <tr align="center" class="R_order">
                                                        <td width="50%" style="height: 31px">
                                                            <asp:Label ID="Label23" runat="server" meta:resourcekey="lblAgentOrderView14">Adult Number</asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="Label24" runat="server" meta:resourcekey="lblAgentOrderView15">Child Number</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="center" class="R_order01">
                                                        <td height="25">
                                                            <asp:Label ID="lblAdultNumber" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblChildNumber" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr align="center" class="R_order">
                                                        <td height="25" width="50%">
                                                            <asp:Label ID="Label25" runat="server" meta:resourcekey="lblAgentOrderView20">Mark Up</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label51" runat="server" meta:resourcekey="lblAgentOrderView16">Total Price</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr align="center" class="R_order01">
                                                        <td height="25">
                                                            <asp:Label ID="lblMarkup" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblPrice" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="15">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%">
                                                            <span class="head01">
                                                                <asp:Label ID="Label26" runat="server" meta:resourcekey="lblAgentOrderView17">Contact Info</asp:Label>
                                                            </span>
                                                        </td>
                                                        <td width="50%" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                            <img src="../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                    <tr class="R_order01">
                                                        <td width="13%" height="25">
                                                            <asp:Label ID="Label27" runat="server" meta:resourcekey="Contact1">Name</asp:Label>
                                                        </td>
                                                        <td width="37%">
                                                            <asp:Label ID="lblContactName" runat="server" Text=""></asp:Label></td>
                                                        <td width="13%">
                                                            <asp:Label ID="Label28" runat="server" meta:resourcekey="Contact2">E-mail</asp:Label>
                                                        </td>
                                                        <td width="37%">
                                                            <asp:Label ID="lblContactEmail" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td style="height: 31px">
                                                            <asp:Label ID="Label29" runat="server" meta:resourcekey="Contact3">DayTime Tel.</asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactDayTel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="Label30" runat="server" meta:resourcekey="Contact4">Evening Tel.</asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactEveningTel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td style="height: 31px">
                                                            <asp:Label ID="Label31" runat="server" meta:resourcekey="Contact5">Fax</asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactFax" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="Label32" runat="server" meta:resourcekey="Contact6">Zip:</asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactZip" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            <asp:Label ID="Label33" runat="server" meta:resourcekey="Contact7">Address</asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblContactAddress" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            <asp:Label ID="Label34" runat="server" meta:resourcekey="Contact8">Comment</asp:Label>
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:Label ID="lbCompent" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="15">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%">
                                                            <span class="head01">
                                                                <asp:Label ID="Label35" runat="server" meta:resourcekey="lblAgentOrderView18">Payment Info</asp:Label></span></td>
                                                        <td width="50%" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="14" colspan="2" background="../images/index/dot01.gif">
                                                            <img src="../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                    <tr class="R_order01">
                                                        <td width="13%" height="25">
                                                            Payment Type</td>
                                                        <td width="37%" colspan="3">
                                                            <asp:Label ID="lblPaymentType" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25" width="13%">
                                                            Credit Card</td>
                                                        <td width="37%">
                                                            <asp:Label ID="lblCreditCard" runat="server"></asp:Label></td>
                                                        <td height="25" width="13%">
                                                            Card Number</td>
                                                        <td width="37%">
                                                            <asp:Label ID="lblCardNumber" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            Card Holder Name</td>
                                                        <td>
                                                            <asp:Label ID="lblCardHolderName" runat="server"></asp:Label></td>
                                                        <td height="25">
                                                            Expiration Date</td>
                                                        <td>
                                                            <asp:Label ID="lblExpirationDate" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            Credit Card Bank Name</td>
                                                        <td>
                                                            <asp:Label ID="lblBankName" runat="server"></asp:Label></td>
                                                        <td>
                                                            Credit Card 24 Hour Customer Service Phone No:</td>
                                                        <td>
                                                            <asp:Label ID="lblCustomerPhone" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            Payer Name</td>
                                                        <td>
                                                            <asp:Label ID="lblPayerName" runat="server"></asp:Label></td>
                                                        <td height="25">
                                                            Billing Address</td>
                                                        <td>
                                                            <asp:Label ID="lblBillingAddress" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td>
                                                            City</td>
                                                        <td>
                                                            <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                                                        <td height="25">
                                                            State</td>
                                                        <td>
                                                            <asp:Label ID="lblState" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td>
                                                            Zip</td>
                                                        <td>
                                                            <asp:Label ID="lblZip" runat="server"></asp:Label></td>
                                                        <td>
                                                            Tel</td>
                                                        <td>
                                                            <asp:Label ID="lblTel" runat="server"></asp:Label></td>
                                                    </tr>
                                                </table>
                                                <div visible="true" id="divHandler" runat="server">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="15">
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%">
                                                                <span class="head01">Handler Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                <img src="../../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                        <tr class="R_order01">
                                                            <td width="20%" height="25">
                                                                HandlerName :
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblHandlerName" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr class="R_order01">
                                                            <td width="20%" height="25">
                                                                Customer Service Staff :
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSalesName" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr class="R_order01">
                                                            <td height="25">
                                                                Phone :
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSalesTel" runat="server">1-(888)-288-7528</asp:Label></td>
                                                        </tr>
                                                        <tr class="R_order01">
                                                            <td height="25">
                                                                Email
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblSalesEmail" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="T_order">
                                                    <tr class="R_order01">
                                                        <td height="30" align="right">
                                                            <a href="AgentOrderSearch.aspx" class="d07">
                                                                <asp:Label ID="Label48" runat="server" meta:resourcekey="lblAgentOrderView19">Return to previous</asp:Label></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
