<%@ Page Language="C#" AutoEventWireup="true" Inherits="MyOrderView" Codebehind="MyOrderView.aspx.cs" %>

<%@ Register Src="~/UserControls/MemberLeftMenu.ascx" TagName="MemberLeftMenu" TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Sales.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare,
        Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
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
                        &nbsp;&nbsp;Membership: My Orders</td>
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
                                                            <span class="head01">Order Detail</span></td>
                                                        <td width="50%" align="right" style="height: 19px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" background="../../images/index/dot01.gif" style="height: 14px">
                                                            <img src="../../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <table cellspacing="1" cellpadding="3" width="100%" border="0">
                                                    <tr>
                                                        <td width="15%">
                                                            Case Number :
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCaseNumber" runat="server"></asp:Label>
                                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" Visible="False" />
                                                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="PNR" Visible="False" />
                                                            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Gta" Visible="False" />
                                                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" Visible="False" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 25px">
                                                            Record Locator :
                                                        </td>
                                                        <td style="height: 25px">
                                                            <asp:Label ID="lblRecordLocator" runat="server"></asp:Label>
                                                            <asp:Label ID="lblGtaRefNumber" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 25px">
                                                            Payment Status:
                                                        </td>
                                                        <td style="height: 25px">
                                                            <asp:Label ID="lblPaymentStatus" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            OP Status:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblOPStatus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="50%" style="height: 19px">
                                                            <span class="head01">Passenger Detail</span></td>
                                                        <td width="50%" align="right" style="height: 19px">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                            <img src="../../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <asp:GridView ID="gvPassengerDetail" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                    Width="100%" OnRowDataBound="gvPassengerDetail_RowDataBound">
                                                    <AlternatingRowStyle CssClass="R_order02" Height="25" />
                                                    <RowStyle CssClass="R_order01" HorizontalAlign="Center" Height="25" />
                                                    <HeaderStyle CssClass="R_order" HorizontalAlign="Center" />
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Name Passenger" DataField="FullName" />
                                                        <asp:BoundField HeaderText="Type" DataField="PassengerType" />
                                                        <asp:BoundField HeaderText="Birthday" DataField="Birthday" DataFormatString="{0:MM/dd/yyyy}" />
                                                        <asp:BoundField HeaderText="Meal" DataField="Meal" />
                                                        <asp:BoundField HeaderText="Passport Number" DataField="PassportNumber" />
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
                                                                <span class="head01">Flight Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                <img src="../../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvFlightInfo" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                        Width="100%" OnDataBinding="gvFlightInfo_DataBinding" OnRowDataBound="gvFlightInfo_RowDataBound">
                                                        <AlternatingRowStyle CssClass="R_order02" />
                                                        <RowStyle CssClass="R_order01" HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="R_order" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Flight No" DataField="FlightNo" />
                                                            <asp:BoundField HeaderText="Routing" DataField="Routing" />
                                                            <asp:BoundField HeaderText="Date" DataField="DepartureDate" DataFormatString="{0:f}" />
                                                            <asp:BoundField HeaderText="Leaves / Arrives" DataField="LeavesArrives" />
                                                            <asp:BoundField HeaderText="Cabin / Class" DataField="BookingClass" />
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
                                                                <span class="head01">Tour Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                <img src="../../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvTourInfo" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                        Width="100%" OnDataBinding="gvTourInfo_DataBinding" OnRowDataBound="gvTourInfo_RowDataBound">
                                                        <AlternatingRowStyle CssClass="R_order02" />
                                                        <RowStyle CssClass="R_order01" HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="R_order" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Tour Name" DataField="TourName" />
                                                            <asp:BoundField HeaderText="Description" DataField="Description" />
                                                            <asp:BoundField HeaderText="Guide" DataField="Guide" />
                                                            <asp:BoundField HeaderText="Days" DataField="Days" />
                                                            <asp:BoundField HeaderText="Nights" DataField="Nights" />
                                                            <asp:BoundField HeaderText="Begin Date" DataField="BeginDate" DataFormatString="{0:f}" />
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
                                                                <span class="head01">Tour Itinerary Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                <img src="../../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:GridView ID="gvItineraryInfo" runat="server" AutoGenerateColumns="False" CssClass="T_order"
                                                        Width="100%" OnDataBinding="gvItineraryInfo_DataBinding" OnRowDataBound="gvItineraryInfo_RowDataBound">
                                                        <AlternatingRowStyle CssClass="R_order02" />
                                                        <RowStyle CssClass="R_order01" HorizontalAlign="Center" />
                                                        <HeaderStyle CssClass="R_order" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Day No" DataField="NumberOfDay" />
                                                            <asp:BoundField HeaderText="Description" DataField="Description" />
                                                            <asp:BoundField HeaderText="Meal Type" DataField="NumberOfDay" />
                                                            <asp:BoundField HeaderText="Hotel Info" DataField="HotelDescription" />
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
                                                                <span class="head01">Hotel Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                <img src="../../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <asp:DataList ID="dlHotel" runat="server" Width="100%" OnItemDataBound="dlHotel_ItemDataBound">
                                                        <ItemTemplate>
                                                            <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                                <tr align="center" class="R_order">
                                                                    <td width="45%" style="height: 31px">
                                                                        Hotel Name</td>
                                                                    <td width="15%" style="height: 31px">
                                                                        Check In</td>
                                                                    <td width="15%" style="height: 31px">
                                                                        Check Out</td>
                                                                    <td width="10%" style="height: 31px">
                                                                        Total Nights</td>
                                                                    <td width="15%" style="height: 31px">
                                                                        City</td>
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
                                                                        Rooms Detailed Information&nbsp;&nbsp;<asp:LinkButton ID="lkbHotelVoucher" runat="server"
                                                                            Text="Email Hotel Voucher" PostBackUrl="~/Page/Hotel2/HotelVoucherForm.aspx"
                                                                            Visible="false"></asp:LinkButton></td>
                                                                    <td height="25">
                                                                        Rooms Stuatus</td>
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
                                                                <span class="head01">Insurance Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                <img src="../../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                        <tr align="center" class="R_order">
                                                            <td height="25">
                                                                Insurance Name</td>
                                                            <td>
                                                                Insurance Status</td>
                                                            <td>
                                                                Total Price</td>
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
                                                <div runat="server" id="divTransfer" visible="false">
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td height="15">
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td width="50%">
                                                                <span class="head01">Transfer Info</span></td>
                                                            <td width="50%" align="right">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                                <img src="../../images/index/dot01.gif" /></td>
                                                        </tr>
                                                    </table>
                                                    <div visible="true" id="divThen" runat="server">
                                                        <table align="center" border="0" cellpadding="0" cellspacing="1" class="T_order"
                                                            width="100%">
                                                            <tr class="R_order01">
                                                                <td style="width: 1191px">
                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="datatable">
                                                                        <tr>
                                                                            <td align="center" colspan="5">
                                                                                Transportation Information(From Airport To Hotel)</td>
                                                                        </tr>
                                                                        <tr class="R_order01">
                                                                            <td align="center" colspan="5">
                                                                                <asp:Label ID="lblName_Then" runat="server" Text=""></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                Car Name</td>
                                                                            <td align="center">
                                                                                Maximum Passengers
                                                                            </td>
                                                                            <td align="center">
                                                                                Maximum Luggage</td>
                                                                            <td align="center">
                                                                                Transfer time</td>
                                                                            <td align="center">
                                                                                Pirce</td>
                                                                        </tr>
                                                                        <tr class="R_order01">
                                                                            <td align="center">
                                                                                <asp:Label ID="lblCar_Then" runat="server" Text=""></asp:Label></td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMaximumPassengers_Then" runat="server" Text=""></asp:Label></td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMaximumLuggage_Then" runat="server" Text=""></asp:Label></td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblTransfertime_Then" runat="server" Text=""></asp:Label></td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblPirce_Then" runat="server" Text=""></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="datatable">
                                                                        <tr align="left" class="R_order">
                                                                            <td colspan="2">
                                                                                <table border="0" cellpadding="2" cellspacing="1" width="100%" class="datatable">
                                                                                    <tr align="center" class="R_order">
                                                                                        <td height="23" align="left">
                                                                                            &nbsp;&nbsp;Pick Up Information</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td width="25%">
                                                                                <span class="t01">*</span> Arriving From:</td>
                                                                            <td>
                                                                                <asp:Label ID="lblArrivingFrom_Then" runat="server" Text=""></asp:Label></td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Flight Number and Airline code:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblAirline_Then" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Estimated Time of Arrival:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblArrival_Then" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="datatable">
                                                                        <tr align="left" class="R_order">
                                                                            <td colspan="2">
                                                                                <table border="0" cellpadding="2" cellspacing="1" width="100%" class="datatable">
                                                                                    <tr align="center" class="R_order">
                                                                                        <td align="left" style="height: 23px">
                                                                                            &nbsp;&nbsp;Drop Off Information</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td width="25%">
                                                                                <span class="t01">*</span> Hotel Address:</td>
                                                                            <td>
                                                                                <asp:Label ID="lblHotelAddress_Then" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td style="height: 30px">
                                                                                <span class="t01">*</span> City:
                                                                            </td>
                                                                            <td style="height: 30px">
                                                                                <asp:Label ID="lblCity_Then" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Country or Area:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblState_Then" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Zip Code:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblZip_Then" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Phone Number:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblTel_Then" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td colspan="2">
                                                                                <asp:HyperLink ID="hpDetailAndCancel_Then" runat="server" Target="_blank">detail</asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div visible="true" id="divSend" runat="server">
                                                        <table align="center" border="0" cellpadding="0" cellspacing="1" class="T_order"
                                                            width="100%">
                                                            <tr class="R_order01">
                                                                <td style="width: 1191px">
                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="datatable">
                                                                        <tr>
                                                                            <td align="center" colspan="5" style="height: 19px">
                                                                                Transportation Information(From Hotel To Airport)</td>
                                                                        </tr>
                                                                        <tr class="R_order01">
                                                                            <td align="center" colspan="5">
                                                                                <asp:Label ID="lblName_Send" runat="server" Text=""></asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                Car Name</td>
                                                                            <td align="center">
                                                                                Maximum Passengers
                                                                            </td>
                                                                            <td align="center">
                                                                                Maximum Luggage</td>
                                                                            <td align="center">
                                                                                Transfer time</td>
                                                                            <td align="center" style="width: 164px">
                                                                                Pirce</td>
                                                                        </tr>
                                                                        <tr class="R_order01">
                                                                            <td align="center">
                                                                                <asp:Label ID="lblCar_Send" runat="server"></asp:Label></td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMaximumPassengers_Send" runat="server"></asp:Label></td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblMaximumLuggage_Send" runat="server"></asp:Label></td>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblTransfertime_Send" runat="server"></asp:Label></td>
                                                                            <td align="center" style="width: 164px">
                                                                                <asp:Label ID="lblPirce_Send" runat="server"></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="datatable">
                                                                        <tr align="left" class="R_order">
                                                                            <td colspan="2">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="datatable">
                                                                                    <tr align="center" class="R_order">
                                                                                        <td height="23" align="left">
                                                                                            &nbsp;&nbsp;Drop Off Information</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td width="25%" style="height: 25px">
                                                                                <span class="t01">*</span> Hotel Address:</td>
                                                                            <td style="height: 25px">
                                                                                <asp:Label ID="lblHotelAddress_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td style="height: 30px">
                                                                                <span class="t01">*</span> City:
                                                                            </td>
                                                                            <td style="height: 30px">
                                                                                <asp:Label ID="lblCity_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Country or Area:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblState_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Zip Code:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblZip_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Phone Number:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblTel_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td colspan="2">
                                                                                <asp:HyperLink ID="hpDetailAndCancel_Send" runat="server" Target="_blank">detail</asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" class="datatable">
                                                                        <tr align="left" class="R_order">
                                                                            <td colspan="2">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" class="datatable">
                                                                                    <tr align="center" class="R_order">
                                                                                        <td height="23" align="left">
                                                                                            &nbsp;&nbsp;Pick Up Information</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td width="25%">
                                                                                <span class="t01">*</span> Arriving From:</td>
                                                                            <td>
                                                                                <asp:Label ID="lblArrivingFrom_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Flight Number and Airline code:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblAirline_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Estimated Time of Arrival:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblArrival_Send" runat="server" Text=""></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" class="R_stepw">
                                                                            <td>
                                                                                <span class="t01">*</span> Pickup Time:
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPickupTime" runat="server" Text="Label"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
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
                                                            <span class="head01">Price Info</span></td>
                                                        <td width="50%" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="14" colspan="2" background="../../images/index/dot01.gif">
                                                            <img src="../../images/index/dot01.gif" /></td>
                                                    </tr>
                                                </table>
                                                <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                    <tr align="center" class="R_order">
                                                        <td height="25">
                                                            Adult Number</td>
                                                        <td>
                                                            Child Number</td>
                                                        <%--<td>
                                                            Commission</td>--%>
                                                        <td>
                                                            Total Price</td>
                                                    </tr>
                                                    <tr align="center" class="R_order01">
                                                        <td height="25">
                                                            <asp:Label ID="lblAdultNumber" runat="server"></asp:Label></td>
                                                        <td>
                                                            <asp:Label ID="lblChildNumber" runat="server"></asp:Label></td>
                                                        <%--<td>
                                                            $<asp:Label ID="lblCommission" runat="server"></asp:Label></td>--%>
                                                        <td>
                                                            $<asp:Label ID="lblPrice" runat="server"></asp:Label></td>
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
                                                            <span class="head01">Contact Info </span>
                                                        </td>
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
                                                        <td width="13%" height="25">
                                                            Name</td>
                                                        <td width="37%">
                                                            <asp:Label ID="lblContactName" runat="server" Text=""></asp:Label></td>
                                                        <td width="13%">
                                                            E-mail</td>
                                                        <td width="37%">
                                                            <asp:Label ID="lblContactEmail" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td style="height: 31px">
                                                            DayTime Tel.</td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactDayTel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            Evening Tel.</td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactEveningTel" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td style="height: 31px">
                                                            Fax</td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactFax" runat="server" Text=""></asp:Label>
                                                        </td>
                                                        <td style="height: 31px">
                                                            Zip:</td>
                                                        <td style="height: 31px">
                                                            <asp:Label ID="lblContactZip" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            Address</td>
                                                        <td>
                                                            <asp:Label ID="lblContactAddress" runat="server" Text="Label"></asp:Label></td>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            Comment</td>
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
                                                            <span class="head01">Payment Info</span></td>
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
                                                            <a href="MyOrderSearch.aspx" class="d07">Return to previous</a></td>
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
