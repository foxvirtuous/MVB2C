<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PaymentForm.aspx.cs" Inherits="PaymentForm"
    ValidateRequest="False" EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/HTLEmailViewControl.ascx" TagName="SendEmailViewControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/CreditCardInformationControl.ascx" TagName="CreditCardInformation"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/HTLOrderView.ascx" TagName="OrderView" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/HotelListViewNewControl.ascx" TagName="HotelListViewNewControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/HTLTotalPriceControl.ascx" TagName="PackageTotalPrice"
    TagPrefix="uc10" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SecureUrlSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />

    <script language="javascript" type="text/javascript">
    function GetFormContent(){
				if(document.getElementById("flagSearch") != null)
				    document.getElementById("flagSearch").value = document.getElementById("MAIL_BODY").innerHTML;
				    
				    showPaymentType();
			}
			
			function DEB(b)
	{
	if(b)
	{
	    document.getElementById("emlc").style.display="none";
	    document.getElementById("emal").style.display="block";
	}
	else
	{
	    document.getElementById("emlc").style.display="block";
	    document.getElementById("emal").style.display="none";
	}
	}
	function OnSearch()
	{
		GetFormContent();
  	}
    
    </script>

    <link href="" rel="stylesheet" type="text/css" />
</head>
<body onload="GetFormContent();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div id="hpContainer" class="TableWidth1" align="center">
            <table cellpadding="0" cellspacing="0" id="ualbodyTable" align="center" width="100%">
                <tr>
                    <td id="containerCenter">
                        <div id="ualbody">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%" id="ualbodyTable">
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <uc6:NavigationControl ID="NavigationControl1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" valign="top" width="100%">
                                        <!-- main begin-->
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="T_table">
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
                                                                                                    <asp:Label ID="lblYourOrderSummary" runat="Server" meta:resourcekey="lblYourOrderSummary">Hotel Order Summary</asp:Label></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                                        <tr class="R_stepw" align="left">
                                                                                                            <td>
                                                                                                                <uc10:PackageTotalPrice ID="PackageTotalPrice1" runat="server"></uc10:PackageTotalPrice>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr class="R_stepw" align="left">
                                                                                                            <td>
                                                                                                                <uc3:OrderView ID="OrderView1" runat="server" />
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
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <div class="MV_hotel_step">
                                                        <div class="MV_hotel_step_T_line01 left">
                                                            1</div>
                                                        <span class="left">&nbsp;<asp:Label ID="lblEnterInformation" runat="Server" meta:resourcekey="lblEnterInformation">Enter Your Credit Card Information</asp:Label></span></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc2:CreditCardInformation ID="CreditCardInformation1" runat="server" />
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
                                                    <div class="MV_hotel_step">
                                                        <div class="MV_hotel_step_T_line01 left">
                                                            2</div>
                                                        <span class="left">&nbsp;<asp:Label ID="lblVerifyAddress" runat="Server" meta:resourcekey="lblVerifyAddress">Verify the Email Address</asp:Label></span></div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="border: 1px solid #ccc; padding: 10px 0px;">
                                                    <asp:Label ID="lblAllcurrent" runat="Server" meta:resourcekey="lblAllcurrent">All current and furture correspondence or information will be send to this address</asp:Label>:&nbsp;<asp:HyperLink
                                                        NavigateUrl="#" ID="lblEmail" runat="server"></asp:HyperLink><br>
                                                    <div id="emlc" style="display: block">
                                                        <a id="A280_1424" href="javascript:DEB(1)"><font class="small">
                                                            <asp:Label ID="lblChangeaddress" runat="Server" meta:resourcekey="lblChangeaddress">Change the e-mail address</asp:Label></font></a>
                                                    </div>
                                                    <div id="emal" style="display: none">
                                                        <label for="emad">
                                                            <asp:Label ID="lblChangeaddress1" runat="Server" meta:resourcekey="lblChangeaddress1">Change my e-mail address to</asp:Label>:</label>
                                                        <asp:TextBox ID="txtEmail" runat="server" class="dropDownRes" Width="200px"></asp:TextBox>&nbsp;<br>
                                                        <br>
                                                        <span class="colHead"><b>
                                                            <asp:Label ID="lblImportant" runat="Server" meta:resourcekey="lblImportant">Important</asp:Label>:</b>
                                                            <asp:Label ID="lblAnychanges" runat="Server" meta:resourcekey="lblAnychanges">
                                                        Any changes you make to this e-mail address will be permanently reflected in your account after the completion of this purchase</asp:Label>.</span><br>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr align="right">
                                                <td style="padding-top: 10px;" valign="middle">
                                                    <asp:Label ID="lblPleasemakesure" runat="Server" meta:resourcekey="lblPleasemakesure">Please make sure everything is correct, and click</asp:Label>
                                                    <asp:Button ID="ibtnSubmit" runat="server" Text="Purchase" OnClick="ibtnSubmit_Click"
                                                        CssClass="IBE_search_btn02" Style="cursor: pointer; margin: 0px;" meta:resourcekey="ibtnSubmit" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                        </table>
                                        <div id="MAIL_BODY" visible="false" style="display: none">
                                            <uc6:SendEmailViewControl ID="SendEmailViewControl1" runat="server" />
                                        </div>
                                        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
                                        <asp:TextBox ID="TextBox1" runat="server" Width="0px" Height="0px" Style="display: none"></asp:TextBox>
                                        <!-- mian end-->
                                    </td>
                                </tr>
                                <tr>
                                    <td height="1">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <!-- footer.jsp | begin -->
        <uc2:Footer ID="Footer1" runat="server" />
        <!-- footer.jsp | end -->

        <script language="javascript" type="text/javascript">
        history.go(1);
        </script>

    </form>
</body>
</html>
