<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewInsuranceSuccessInfoForm.aspx.cs" Inherits="NewInsuranceSuccessInfoForm" %>
<%@ Register Src="~/UserControls/NewInsuranceOrderSummaryControl.ascx" TagName="NewInsuranceOrderSummaryControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/StatesControl.ascx" TagName="StatesControl"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/TourOrderNumberPNRInfoControl.ascx" TagName="TourOrderNumberPNRInfoControl"
    TagPrefix="uc10" %>
<%@ Register Src="~/UserControls/ContactViewControl.ascx" TagName="ContactViewControl"
    TagPrefix="uc12" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
    <meta name="keywords" content="Majestic Vacations, Majestic, Vacations, Travel, Cheap Airfare, Hotels, Vacations, Airfare, Airline Tickets, Hotel, Vacation, Hotel Reservations, Vacation Packages, Travel Agency, Travel Deals, Discount Airfare" />
    <meta name="description" content="Purchase airline tickets, make hotel reservations, find vacation packages" />
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link href="../../css/style_NewHotel.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_new1.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp;
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
                                                <uc2:StatesControl ID="StatesControl1" runat="server" />
                                                &nbsp;</td>
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
                                                            <span class="head06">Thanks for Your Purchase</span></td>
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
                                                Order was placed on:
                                                <asp:Label ID="lblDateNow" runat="server" Text=""></asp:Label>
                                                US Mountain Time.<br />
                                                The confirmation e-mail will be sent out within 3 business days. If you do not hear
                                                back from us within 3 business days, please call us at 1-(888)-288-7528.</td>
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
                                                                                    Your Order Summary</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                        <tr class="R_stepw">
                                                                                            <td height="120">
                                                                                                &nbsp;<table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                            <uc10:TourOrderNumberPNRInfoControl ID="TourOrderNumberPNRInfoControl1" runat="server" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                            <uc3:NewInsuranceOrderSummaryControl ID="NewInsuranceOrderSummaryControl1" runat="server" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td height="10">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <uc12:ContactViewControl ID="ContactViewControl1" runat="server" />
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
                                                            <span class="head06">Service Contact</span></td>
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
                                                            &#8226; &nbsp;Customer Service Staff: Christine Chiang<br>
                                                            &#8226; &nbsp;Phone: 1-(888)-288-7528<br>
                                                            &#8226; &nbsp;Email: <a href="mailto:cchiang@majestic-vacations.com" class="d07">cchiang@majestic-vacations.com</a>
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
                                            <td align="center"><asp:Button ID="lbnBack"
                                                        Text="Back homepage" runat="server" class="search_btn04" OnClick="lbnBack_Click"
                                                        Style="cursor: hand" /></td>
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
