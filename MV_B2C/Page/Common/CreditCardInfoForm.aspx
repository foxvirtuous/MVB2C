<%@ Page Language="C#" AutoEventWireup="true" Inherits="CreditCardInfoForm" EnableEventValidation="false"
    ValidateRequest="false" Codebehind="CreditCardInfoForm.aspx.cs" %>

<%@ Register Src="../../UserControls/SendEmailViewControl.ascx" TagName="SendEmailViewControl"
    TagPrefix="uc12" %>
<%@ Register Src="~/UserControls/StatesControl.ascx" TagName="StatesControl" TagPrefix="uc11" %>
<%@ Register Src="~/UserControls/CreditCardInfoControl.ascx" TagName="CreditCardInfoControl"
    TagPrefix="uc10" %>
<%@ Register Src="~/UserControls/PriceInfoControl.ascx" TagName="PriceInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/ContactViewControl.ascx" TagName="ContactViewControl"
    TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/TravelerInfoControl.ascx" TagName="TravelerInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/FlightDetailsControl.ascx" TagName="FlightDetailsControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/FlightHeaderControl.ascx" TagName="FlightHeaderControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet"
        type="text/css" />
</head>
<body onload="GetFormContent();">

    <script language="javascript" type="text/javascript">
    function GetFormContent()
    {
		if(document.getElementById("flagSearch") != null)
		    document.getElementById("flagSearch").value = document.getElementById("MAIL_BODY").innerHTML;
	}
	
	function DEB(b)
	{
	    var flag = document.getElementById("hdFlag");
    	
	    if(b)
	    {
	        document.getElementById("emlc").style.display="none";
	        document.getElementById("emal").style.display="block";
	        flag.value = "YES";
	    }
	    else
	    {
	        document.getElementById("emlc").style.display="block";
	        document.getElementById("emal").style.display="none";
            flag.value = "NO";        
	    }
	}
	
				
	function OnSearch()
	{
		GetFormContent();
	}
    </script>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <asp:TextBox ID="TextBox1" runat="server" Width="199px" Height="20px" Style="display: none"></asp:TextBox>
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
                                            <uc11:StatesControl ID="StatesControl1" runat="server" />
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
                                                                                                        <uc7:TravelerInfoControl ID="TravelerInfoControl1" runat="server" />
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td height="10">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        <uc8:ContactViewControl ID="ContactViewControl1" runat="server" />
                                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                            <tr>
                                                                                                                <td height="10">
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                        <uc9:PriceInfoControl ID="PriceInfoControl1" runat="server" />
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
                                                                <td style="height: 20px">
                                                                    &nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <div id="divCCInfo" runat="server">
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
                                                                <asp:Label ID="lblEnterInformation" runat="server" meta:resourcekey="lblEnterInformation">Enter Your Credit Card Information</asp:Label></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div class="IBE_YellowDIV_Right_travelContact_step4">
                                                    <div class="IBE_YellowDIV_Right_inSide1_travelContact_step4">
                                                        <uc10:CreditCardInfoControl ID="CreditCardInfoControl1" runat="server"></uc10:CreditCardInfoControl>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div id="divDisplay" runat="server" visible="false">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="T_table">
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <font color="red">
                                                    <asp:Label ID="lblDisplay" runat="server" meta:resourcekey="lblAirlineNotCredit">Airline does not allow Credit Card Payment using airline as merchant, pls call our office for Check Payment arrangement.</asp:Label></font>
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
                                                        <span class="head06">
                                                            <asp:Label ID="lblVerifyAddress" runat="server" meta:resourcekey="lblVerifyAddress">Verify the Email Address</asp:Label></span></td>
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
                                                        <asp:Label ID="lblAlladdress" runat="server" meta:resourcekey="lblAlladdress">All current and furture correspondence or information will be send to this address</asp:Label>:&nbsp;<asp:HyperLink
                                                            NavigateUrl="#" ID="lblEmail" runat="server"></asp:HyperLink>&nbsp;&nbsp;
                                                        <div id="emlc" style="display: block">
                                                            <a id="A280_1424" href="javascript:DEB(1)" class="d07">
                                                                <asp:Label ID="lblChangeAddress" runat="server" meta:resourcekey="lblChangeAddress">Change the e-mail address</asp:Label></a>
                                                        </div>
                                                        <asp:HiddenField ID="hdFlag" Value="NO" runat="server" />
                                                        <div id="emal" style="display: none" runat="server">
                                                            <label for="emad">
                                                                <asp:Label ID="lblChangeTo" runat="server" meta:resourcekey="lblChangeTo">Change my e-mail address to</asp:Label>:&nbsp;</label>
                                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                            <asp:Label ID="lbMessage" runat="server" ForeColor="red" Visible="false"></asp:Label><br>
                                                            <span class="colHead">
                                                                <asp:Label ID="lblImportantAddress" runat="server" meta:resourcekey="lblImportantAddress"><b>Important:&nbsp;</b> Any changes you make to this e-mail address</asp:Label>
                                                                <asp:Label ID="lblWillPurchase" runat="server" meta:resourcekey="lblWillPurchase">will be permanently reflected in your account after the completion of this purchase</asp:Label>.</span><br>
                                                        </div>
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
                                            <asp:Label ID="lblPleaseClick" runat="server" meta:resourcekey="lblPleaseClick">Please confirm all of the information is correct, then click &nbsp;</asp:Label>
                                            <asp:Button ID="btnPurchase" runat="server" Text="Purchase" meta:resourcekey="btn_Purchase"
                                                CssClass="IBE_search_btn02" OnClick="btnPurchase_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <uc2:Footer ID="Footer1" runat="server" />
                </td>
            </tr>
        </table>
        <div id="MAIL_BODY" style="display: none">
            <uc12:SendEmailViewControl ID="SendEmailViewControl1" runat="server"></uc12:SendEmailViewControl>
        </div>
        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
    </form>
</body>
</html>
