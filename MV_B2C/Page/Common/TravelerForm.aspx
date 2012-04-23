<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"
    Inherits="TravelerForm" Codebehind="TravelerForm.aspx.cs" %>

<%@ Register Src="~/UserControls/StatesControl.ascx" TagName="StatesControl" TagPrefix="uc10" %>
<%@ Register Src="~/UserControls/ContactInfoControl.ascx" TagName="ContactInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/OrderPassengerInfoControl.ascx" TagName="OrderPassengerInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/PriceInfoControl.ascx" TagName="PriceInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/FlightDetailsControl.ascx" TagName="FlightDetailsControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/FlightHeaderControl.ascx" TagName="FlightHeaderControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat=server>
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
    <meta name="keywords" content="Majestic Vacations, Majestic, Vacations, Travel, Cheap Airfare, Hotels, Vacations, Airfare, Airline Tickets, Hotel, Vacation, Hotel Reservations, Vacation Packages, Travel Agency, Travel Deals, Discount Airfare" />
    <meta name="description" content="Purchase airline tickets, make hotel reservations, find vacation packages" />
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
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
                                        <td height="25" align="right" valign="top" style="width: 920px">
                                            <uc10:StatesControl ID="StatesControl1" runat="server" />
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
                                                                            <td valign="top" class="D_stepr" style="height: 25px">
                                                                                <asp:Label ID="lblYourSummary" runat="server" meta:resourcekey="lblYourSummary">Your Order Summary</asp:Label></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                    <tr class="R_stepw">
                                                                                        <td height="120">
                                                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr valign="top">
                                                                                                    <td>
                                                                                                        <uc3:FlightHeaderControl ID="FlightHeaderControl1" runat="server" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="10">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr valign="top">
                                                                                                    <td>
                                                                                                        <uc6:FlightDetailsControl ID="FlightDetailsControl1" runat="server" />
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td height="10">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                            <tr valign="top">
                                                                                                                <td>
                                                                                                                    <uc7:PriceInfoControl ID="PriceInfoControl1" runat="server" />
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
                                                <%--<tr class="R_step04">
                                                    <td height="20">
                                                        &nbsp;</td>
                                                </tr>--%>
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
                                                                    1</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="5">
                                                    </td>
                                                    <td align="left">
                                                        <span class="head06"><asp:Label ID="lblEnterInformation" runat="server" meta:resourcekey="lblEnterInformation">Enter Travelers &amp; Contact Information</asp:Label></span></td>
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
                                                                                            <span class="t01">*</span> = <asp:Label ID="lblRequired" runat="server" meta:resourcekey="lblRequired">Required</asp:Label></td>
                                                                                    </tr>
                                                                                </table>
                                                                                <%--<table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                                                                                    width="100%">
                                                                                    <tr class="R_stepw">
                                                                                        <td>--%>
                                                                                <uc8:OrderPassengerInfoControl ID="OrderPassengerInfoControl1" runat="server" />
                                                                                &nbsp;
                                                                                <%--     </td>
                                                                                    </tr>
                                                                                </table>--%>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td style="height: 8px">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
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
                                                                                                        <asp:Label ID="lblContactInformation" runat="server" meta:resourcekey="lblContactInformation">Contact Information</asp:Label></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <uc9:ContactInfoControl ID="ContactInfoControl1" runat="server" />
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
                                <div visible="false" style="display:none" >
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
                                                            <span class="head06"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblTravelInsurance">Travel Insurance</asp:Label></span></td>
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
                                                            <strong><asp:Label ID="Label2" runat="server" meta:resourcekey="lblInsuranceIncludes">The travel insurance includes</asp:Label>:</strong><br>
                                                            &#8226; &nbsp;<asp:Label ID="lblInsuranceName" runat="server" Text=""></asp:Label><br>
                                                            &#8226; &nbsp;<asp:Label ID="lblInsuranceTotal" runat="server" Text=""></asp:Label><br>
                                                            &#8226; &nbsp;<asp:HyperLink ID="hlInsuranceDetails" runat="server" Target=_blank  meta:resourcekey="lblInsuranceDetails">Insurance Details</asp:HyperLink>
                                                            <br>
                                                            <asp:CheckBox ID="chkInsurance" runat="server" Text="Buy insurance for this trip "
                                                                CssClass="t05"  meta:resourcekey="chkBuyInsurance"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
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
                                                                    2</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="5">
                                                    </td>
                                                    <td align="left">
                                                        <span class="head06"><asp:Label ID="lblOtherTrip" runat="server" meta:resourcekey="lblOtherTrip">Other Remark for Your Trip</asp:Label></span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step02">
                                                <tr class="R_stepw">
                                                    <td align="center">
                                                        <textarea id="txtRemark" style="width:98%"  rows="5" class="remark" runat="server"></textarea></td>
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
                                            <asp:Label ID="lblPleaseclick" runat="server" meta:resourcekey="lblPleaseclick">Please confirm all of the information is correct, then click &nbsp;</asp:Label>
                                            <asp:Button ID="ibtnSubmit" runat="server" Width="120" Height="25" CssClass="search_btn02"
                                                Text="Continue" ValidationGroup="PackageCreditForm" meta:resourcekey="btn_Continue" OnClick="ibtnSubmit_Click" />
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
    </form>
</body>
</html>
