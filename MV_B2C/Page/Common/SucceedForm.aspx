<%@ Page Language="C#" AutoEventWireup="true" Inherits="SucceedForm" EnableEventValidation="false"
    Codebehind="SucceedForm.aspx.cs" %>

<%@ Register Src="~/UserControls/StatesControl.ascx" TagName="StatesControl" TagPrefix="uc12" %>
<%@ Register Src="~/UserControls/PriceInfoControl.ascx" TagName="PriceInfoControl"
    TagPrefix="uc11" %>
<%@ Register Src="~/UserControls/ContactInfoControl.ascx" TagName="ContactInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/ContactViewControl.ascx" TagName="ContactViewControl"
    TagPrefix="uc10" %>
<%@ Register Src="~/UserControls/OrderPassengerInfoControl.ascx" TagName="OrderPassengerInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/TravelerInfoControl.ascx" TagName="TravelerInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/FlightDetailsControl.ascx" TagName="FlightDetailsControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/FlightHeaderControl.ascx" TagName="FlightHeaderControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/SendEmailViewControl.ascx" TagName="SendEmailViewControl"
    TagPrefix="uc13" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Content-Language" content="en-us" />
    <meta http-equiv="Content-type" content="text/html; charset=iso-8859-1" />
    <meta name="keywords" content="Majestic Vacations, Majestic, Vacations, Travel, Cheap Airfare, Hotels, Vacations, Airfare, Airline Tickets, Hotel, Vacation, Hotel Reservations, Vacation Packages, Travel Agency, Travel Deals, Discount Airfare">
    <meta name="description" content="Purchase airline tickets, make hotel reservations, find vacation packages">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="../../css/style_new.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
			function doPrint(){
				document.getElementById("btnPrint").style.visibility="hidden";
				window.print();
				document.getElementById("btnPrint").style.visibility="visible";
			}
    </script>

    <script language="javascript" type="text/javascript">
    function GetFormContent()
    {
		if(document.getElementById("TextBox1") != null)
		    document.getElementById("TextBox1").value = document.getElementById("MAIL_BODY").innerHTML;
	}
			
	function OnSearch()
	{
	    var flag = document.getElementById("flagSearch");
	    flag.value = "searching";
		GetFormContent();
		document.getElementById("form1").submit();
	}
    </script>

    <link href="" rel="stylesheet" type="text/css" />
</head>
<body onload="GetFormContent();">
    <form id="form1" runat="server">
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
                                        <td height="25" align="right" valign="top">
                                            <uc12:StatesControl ID="StatesControl1" runat="server" />
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
                                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                                            US Eastern Time.<br />
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
                                                                            <td height="25" valign="top" class="D_stepr">
                                                                                Your Order Summary</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                    <tr class="R_stepw">
                                                                                        <td height="120">
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
                                                                                                                            <td align="left">
                                                                                                                                <font class="t09">The Order Number:</font> <font class="t10">
                                                                                                                                    <asp:Label ID="lblCaseNumber" runat="server" Text=""></asp:Label></font><br />
                                                                                                                                <font class="t09">Airline Record Locator:</font> <font class="t10">
                                                                                                                                    <asp:Label ID="lblRcordLocator" runat="server"></asp:Label></font></td>
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
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                <tr>
                                                                                                    <td height="10">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                <tr valign="top">
                                                                                                    <td>
                                                                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                                            <tr align="left" valign="top">
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
                                                                                                        <uc6:FlightDetailsControl ID="FlightDetailsControl1" runat="server" />
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td height="10">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        <uc8:TravelerInfoControl ID="TravelerInfoControl1" runat="server" />
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td height="10">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        <uc10:ContactViewControl ID="ContactViewControl1" runat="server" />
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td height="10">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        <uc11:PriceInfoControl ID="PriceInfoControl1" runat="server" />
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td height="10">
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
                                                        &#8226; &nbsp;Customer Service Staff: <asp:Label ID="lblSalesName" runat="server" Text="Label"></asp:Label><br>
                                                        &#8226; &nbsp;Phone: 1-(888)-288-7528<br>
                                                        &#8226; &nbsp;Email: <asp:Label ID="lblSalesEmail" runat="server" Text="Label"></asp:Label>
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
                                            <asp:Button ID="btnPrint" runat="server" CssClass="search_btn05" Text="Print out this page" />&nbsp;<asp:Button
                                                ID="btnBack" runat="server" CssClass="search_btn04" OnClick="btnBack_Click" Text="Homepage" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div id="MAIL_BODY" visible="false" style="display: none">
            <uc13:SendEmailViewControl ID="SendEmailViewControl1" runat="server"></uc13:SendEmailViewControl>
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Width="0px" Height="0px" Style="display: none"></asp:TextBox>
        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
        <uc2:Footer ID="Footer1" runat="server" />
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
