<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="TourSuccessInfoForm" Codebehind="TourSuccessInfoForm.aspx.cs" %>

<%@ Register Src="../../UserControls/ContactViewControl.ascx" TagName="ContactViewControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/TourPriceInfoControl.ascx" TagName="TourPriceInfoControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/FlightDetailsControl.ascx" TagName="FlightDetailsControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/TourOrderNumberPNRInfoControl.ascx" TagName="TourOrderNumberPNRInfoControl"
    TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
    <meta name="keywords" content="Majestic Vacations, Majestic, Vacations, Travel, Cheap Airfare, Hotels, Vacations, Airfare, Airline Tickets, Hotel, Vacation, Hotel Reservations, Vacation Packages, Travel Agency, Travel Deals, Discount Airfare" />
    <meta name="description" content="Purchase airline tickets, make hotel reservations, find vacation packages" />
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet" type="text/css" />
</head>
<body>

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
  function doPrint(){
				window.open("printPage.html","","height=150,width=400,resizable=no,scrollbars=no,status=no,toolbar=no,menubar=no,location=no");
		}
    </script>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <div id="printArea">
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
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="height: 58px">
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
                                                            <span class="head06"><asp:Label ID="lblThanksPurchase" runat="server" meta:resourcekey="lblThanksPurchase">Thanks for Your Purchase</asp:Label></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <asp:Label ID="lblOrderOn" runat="server" meta:resourcekey="lblOrderOn">Order was placed on</asp:Label>:
                                                <asp:Label ID="lblDateNow" runat="server" Text=""></asp:Label>
                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblUSEasternTime">US Eastern Time</asp:Label>.<br />
                                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblconfirmation">The confirmation e-mail will be sent out within 3 business days.</asp:Label>
                                                 <asp:Label ID="Label2" runat="server" meta:resourcekey="lblMsg">If you do not hear back from us within 3 business days, please call us at 1-(888)-288-7528.</asp:Label></td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                    </table>
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
                                                                                <td valign="top" class="D_stepr" style="height: 27px">
                                                                                    <asp:Label ID="lblOrderNumber" runat="server" meta:resourcekey="lblOrderSummary">Your Order Summary</asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                        <tr class="R_stepw">
                                                                                            <td height="120">
                                                                                                <uc5:TourOrderNumberPNRInfoControl ID="TourOrderNumberPNRInfoControl1" runat="server" />
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <uc5:TourMainInfoControl ID="TourMainInfoControl1" runat="server" />
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                    <tr align="center" class="R_order03">
                                                                                                        <td height="23" colspan="7" align="center">
                                                                                                            <a href="#" class="tour_link04" onclick="ShowOrHideItinerary()" style="color:#005599"><asp:Label ID="Label4" runat="server" meta:resourcekey="lblShowHide">Show/Hide Itinerary</asp:Label></a>
                                                                                                            </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <div id="div_TourItinerary" runat="server" visible="true" style="display: none">
                                                                                                    <uc5:TourItineraryControl ID="TourItineraryControl1" runat="server" />
                                                                                                </div>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <uc7:ContactViewControl ID="ContactViewControl1" runat="server" />
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                                                    <tr align="center" class="R_order03">
                                                                                                        <td height="23" colspan="7" align="center">
                                                                                                            <strong><asp:Label ID="Label5" runat="server" meta:resourcekey="lblPrice">Price</asp:Label></strong></td>
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
                                                            <span class="head06"><asp:Label ID="Label6" runat="server" meta:resourcekey="lblServiceContact">Service Contact</asp:Label></span></td>
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
                                                        <td align="left">
                                                            &#8226; &nbsp;<asp:Label ID="lblCustomerStaff" runat="server" meta:resourcekey="lblCustomerStaff">Customer Service Staff</asp:Label>: <asp:Label runat=server ID="lblSalesName"></asp:Label> <br>
                                                            &#8226; &nbsp;<asp:Label ID="lblPhone" runat="server" meta:resourcekey="lblPhone">Phone</asp:Label>: 1-(888)-288-7528<br>
                                                            &#8226; &nbsp;<asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>: <asp:Label runat=server ID="lblSalesEmail"></asp:Label>
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
                                            <td align="center">
                                                <%--<input name="print" value="Print out this page" id="btnPrint" type="button" class="search_btn05"
                                                    onclick="javascript:doPrint();" style="cursor: hand" runat="server"  meta:resourcekey="btnPrint" >--%>&nbsp;<asp:Button ID="lbnBack"
                                                        Text="Homepage" runat="server" class="search_btn04" OnClick="lbnBack_Click"
                                                        Style="cursor: hand" meta:resourcekey="btnBackHome" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
