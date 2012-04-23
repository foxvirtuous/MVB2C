<%@ Page Language="C#" AutoEventWireup="true" Inherits="TourTravelerInfoForm" ValidateRequest="false"
    Codebehind="TourTravelerInfoForm.aspx.cs" %>

<%@ Register Src="../../UserControls/OrderPassengerInfoControl.ascx" TagName="OrderPassengerInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/TourContactInfoControl.ascx" TagName="ContactInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/TourPriceInfoControl.ascx" TagName="TourPriceInfoControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/FlightDetailsControl.ascx" TagName="FlightDetailsControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
    <meta name="keywords" content="Majestic Vacations, Majestic, Vacations, Travel, Cheap Airfare, Hotels, Vacations, Airfare, Airline Tickets, Hotel, Vacation, Hotel Reservations, Vacation Packages, Travel Agency, Travel Deals, Discount Airfare" />
    <meta name="description" content="Purchase airline tickets, make hotel reservations, find vacation packages" />
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body onload="GetFormContent();">

    <script language="javascript" type="text/javascript">
 var isShow = false;
 function ShowOrHideItinerary()
 {
    if(!isShow)
    {
        isShow =true;
        document.getElementById("div_TourItinerary").style.display = "";
    }
    else
    { isShow =false;
        document.getElementById("div_TourItinerary").style.display = "none";}
 }
 
  function GetFormContent()
    {
		if(document.getElementById("flagSearch") != null)
		    document.getElementById("flagSearch").value = document.getElementById("MAIL_BODY").innerHTML;
	}
				
	function OnSearch()
	{
		GetFormContent();
		document.getElementById("IsFinised").value ="yes";
	    document.getElementById("form1").submit();
	}
    </script>

    <form id="form1" runat="server">
        <input id="IsFinised" type="hidden" name="IsFinised" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <table width="920" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="15">
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="step">
                                    <tr>
                                        <td height="25" align="right" valign="top">
                                            <uc5:StatesControl ID="StatesControl1" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" class="T_table">
                        <tr>
                            <td align="right" valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" class="T_step02">
                                    <tr class="R_step02">
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr align="left">
                                                                            <td height="25" valign="top" class="D_stepr">
                                                                                <asp:Label ID="lblOrderSummary" runat="server" meta:resourcekey="lblOrderSummary">Your Order Summary</asp:Label></td>
                                                                            <td align="right">
                                                                                <%--<a href="#">Print</a>--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                    <tr class="R_stepw">
                                                                                        <td height="120">
                                                                                            <uc5:TourMainInfoControl ID="TourMainInfoControl1" runat="server"></uc5:TourMainInfoControl>
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="10">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step03">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                            <tr align="center" class="R_order03">
                                                                                                                <td height="23" colspan="7" align="center">
                                                                                                                    <a href="#" class="tour_link04" onclick="ShowOrHideItinerary()" style="color: #fff">
                                                                                                                        Show/Hide Itinerary</a>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <div id="div_TourItinerary" runat="server" style="display: none">
                                                                                                <uc5:TourItineraryControl ID="TourItineraryControl1" runat="server" />
                                                                                            </div>
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="10">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                <tr align="center" class="R_order03">
                                                                                                    <td height="23" colspan="7" align="center">
                                                                                                        <strong>
                                                                                                            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblPrice">Price</asp:Label>
                                                                                                        </strong>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <uc6:TourPriceInfoControl ID="PriceInfoControl1" runat="server" />
                                                                                        </td>
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
                                                <tr class="R_step04">
                                                    <td height="20">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <div runat="server" id="divPNR">
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td height="15">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td width="20">
                                                                    <table class="T_line01" border="0" cellspacing="0" cellpadding="0" width="20">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="middle">
                                                                                    ></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                                <td width="5">
                                                                </td>
                                                                <td align="left">
                                                                    <span class="head06">PNR Infomation</span></td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="T_step02" border="0" cellspacing="1" cellpadding="8" width="100%">
                                                        <tbody>
                                                            <tr class="R_stepo">
                                                                <td valign="top">
                                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <table class="T_step03" border="0" cellspacing="1" cellpadding="8" width="100%">
                                                                                        <tbody>
                                                                                            <tr class="R_stepw">
                                                                                                <td>
                                                                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td height="20" align="left" valign="top">
                                                                                                                    <asp:TextBox ID="txtPNR" runat="server"></asp:TextBox>
                                                                                                                    <label>
                                                                                                                        <asp:Button ID="btnLoadPNR" runat="server" Text="Load PNR Info" OnClick="btnLoadPNR_Click" />
                                                                                                                    </label>
                                                                                                                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label></td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td height="8">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                    <asp:DataList ID="dlAirs" runat="server" CssClass="T_order" Width="100%" Style="border: 1px solid #bbb;
                                                                                                        background: #eee;">
                                                                                                        <ItemTemplate>
                                                                                                            <div class="pnr_line_chline_name">
                                                                                                                <span class="left">Flights Info</span><span class="left">&nbsp;&nbsp;PNR :
                                                                                                                    <asp:Label ID="lblPNR" runat="server" Text=""></asp:Label></span><span class="left">
                                                                                                                        &nbsp;&nbsp;&nbsp;Passenger:&nbsp;</span><span class="f_red left"><asp:Label ID="lblPassengers"
                                                                                                                            runat="server" Text=""></asp:Label></span>
                                                                                                            </div>
                                                                                                            <asp:GridView ID="gvFlightInfo" runat="server" AutoGenerateColumns="False" CssClass="T_step03"
                                                                                                                Width="100%" border="0" CellPadding="3" CellSpacing="1" OnRowDataBound="gvFlightInfo_RowDataBound">
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField HeaderText="Flight No" HeaderStyle-BackColor="#E9E9E9">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblAirLine" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.AirLine.Code") %>'></asp:Label>
                                                                                                                            <asp:Label ID="lblFlightNumber" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Routing" HeaderStyle-BackColor="#E9E9E9">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblDepFrom" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Name") %>'></asp:Label>
                                                                                                                            <asp:Label ID="lblDepFromCode" runat="server" Text='<%# "(" + DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") + ")" %>'></asp:Label>&nbsp;to
                                                                                                                            <asp:Label ID="lblArrTo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.Name") %>'></asp:Label>
                                                                                                                            <asp:Label ID="lblArrToCode" runat="server" Text='<%#  "(" + DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") + ")" %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:BoundField HeaderText="Date" HeaderStyle-BackColor="#E9E9E9" DataField="DepartureTime">
                                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:TemplateField HeaderText="Leaves / Arrives" HeaderStyle-BackColor="#E9E9E9">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="lblDepTime" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label>&nbsp;to
                                                                                                                            &nbsp;
                                                                                                                            <asp:Label ID="lblArrTime" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:BoundField HeaderText="Cabin / Class" HeaderStyle-BackColor="#E9E9E9" DataField="BookingClass">
                                                                                                                        <ItemStyle HorizontalAlign="Center" />
                                                                                                                    </asp:BoundField>
                                                                                                                </Columns>
                                                                                                                <HeaderStyle CssClass="R_stepw" HorizontalAlign="Center" />
                                                                                                                <RowStyle Font-Size="13px" CssClass="R_stepw" HorizontalAlign="Center" />
                                                                                                            </asp:GridView>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:DataList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="20">
                                                        <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                                            <tr>
                                                                <td align="center">
                                                                    1</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="5">
                                                    </td>
                                                    <td align="left">
                                                        <span class="head06">
                                                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblEnterTravelersAndContact">Enter Travelers &amp; Contact Information</asp:Label></span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                                                <tr class="R_stepo">
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="7">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                        <tr class="R_stepw">
                                                                            <td>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="20" align="right" valign="top">
                                                                                            <span class="t01">*</span> =
                                                                                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblRequired">Required</asp:Label></td>
                                                                                    </tr>
                                                                                </table>
                                                                                <uc8:OrderPassengerInfoControl ID="OrderPassengerInfoControl1" runat="server" />
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="8">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
                                                                                    width="100%">
                                                                                    <tr class="R_stepw">
                                                                                        <td>
                                                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                <tr align="center" class="R_order">
                                                                                                    <td height="23" align="left">
                                                                                                        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblContactInformation">Contact Information</asp:Label></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <uc7:ContactInfoControl ID="ContactInfoControl1" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="3">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="20">
                                                        <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                                            <tr>
                                                                <td align="center">
                                                                    2</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="5">
                                                    </td>
                                                    <td align="left">
                                                        <span class="head06">
                                                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblOtherRemark">Other Remark for Your Trip</asp:Label></span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step02">
                                                <tr class="R_stepw">
                                                    <td align="center">
                                                        <textarea id="txtRemark" style="width: 98%;" rows="5" class="remark" runat="server"></textarea>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td height="10">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblConfirm">Please confirm all of the information is correct, then click</asp:Label>
                                            &nbsp;
                                            <asp:Button CssClass="search_btn02" ID="btn_button" runat="server" Text="Continue"
                                                OnClick="btn_button_Click" Style="cursor: hand" meta:resourcekey="btnContinue" />&nbsp;&nbsp;
                                            <asp:Button ID="btn_back" runat="server" Text="Back" CssClass="search_btn03" Style="cursor: hand"
                                                OnClick="btn_back_Click" CausesValidation="False" meta:resourcekey="btnBack" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div id="MAIL_BODY" style="display:none" >
            <uc5:SendEmailTourControl ID="SendEmailTourControl1" runat="server"></uc5:SendEmailTourControl>
        </div>
        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
