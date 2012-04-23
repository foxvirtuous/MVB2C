<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CreditCardInformation.aspx.cs"
    Inherits="Terms.Web.Page.Package2.CreditCardInformation" ValidateRequest="false" %>

<%@ Register Src="../../UserControls/PKGSendEmailControl.ascx" TagName="SendEmailViewControl"
    TagPrefix="uc12" %>
<%@ Register Src="../../UserControls/PKGTravelerInfoControl.ascx" TagName="PKGTravelerInfoControl"
    TagPrefix="uc10" %>
<%@ Register Src="../../UserControls/PKGContactViewControl.ascx" TagName="PKGContactViewControl"
    TagPrefix="uc11" %>
<%@ Register Src="../../UserControls/CreditCardInfoControl.ascx" TagName="CreditCardInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/PriceInfoControl.ascx" TagName="PriceInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/ContactViewControl.ascx" TagName="ContactViewControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/TravelerInfoControl.ascx" TagName="TravelerInfoControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/PKGSelectedHotelsControl.ascx" TagName="PKGSelectedHotelsControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/PKGSelectedFlightControl.ascx" TagName="PKGSelectedFlightControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet"
        type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../../css/global.css" />

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

    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body onload="GetFormContent();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:TextBox ID="TextBox1" runat="server" Width="199px" Height="20px" Style="display: none"></asp:TextBox>
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div class="IBE_package_main">
            <div class="IBE_package_Dstep" align="right">
                <uc8:NavigationControl ID="NavigationControl1" runat="server" />
            </div>
            <div class="IBE_package_main_content">
                <div class="IBE_GrayDIV_Right_travelContact_step4 IBE_T_font_11">
                    <div class="IBE_package_SearchCondition_D_title_step4">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblYourOrderSummary">Your Order Summary</asp:Label></div>
                    <table class="IBE_package_SearchCondition_T_step03" border="0" cellpadding="8" cellspacing="1"
                        width="100%">
                        <tbody>
                            <tr class="IBE_package_SearchCondition_R_stepw">
                                <td align="left" width="50%">
                                    <div class="IBE_T_font_11" style="margin-bottom: 10px;">
                                        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblFrom">From</asp:Label>&nbsp;<font
                                            class="IBE_package_SearchCondition_f06"><asp:Label ID="lblFrom" runat="server"></asp:Label></font>
                                        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblTo">to</asp:Label>
                                        <font class="IBE_package_SearchCondition_f06">
                                            <asp:Label ID="lblTo" runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblDepartDate">Depart Date</asp:Label>:<font
                                            class="IBE_package_SearchCondition_f06"><asp:Label ID="lblDepartDate" runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:<font
                                            class="IBE_package_SearchCondition_f06"><asp:Label ID="lblReturnDate" runat="server"></asp:Label></font><br />
                                        <asp:Label ID="lblRoomsAndPassengers" runat="server"></asp:Label></div>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label6" runat="server" meta:resourcekey="lblFlightInformation">Flight Information</asp:Label></div>
                                                    <uc3:PKGSelectedFlightControl ID="PKGSelectedFlightControl1" runat="server"></uc3:PKGSelectedFlightControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblFlightInformation">Hotel Information</asp:Label></div>
                                                    <uc6:PKGSelectedHotelsControl ID="PKGSelectedHotelsControl1" runat="server"></uc6:PKGSelectedHotelsControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label8" runat="server" meta:resourcekey="lblTravelerInformation">Traveler Information</asp:Label></div>
                                                    <uc10:PKGTravelerInfoControl ID="PKGTravelerInfoControl1" runat="server"></uc10:PKGTravelerInfoControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <%-- <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;" visible="false">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        Transportation Information</div>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="0" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_package_step6_TravelerInformation_title2" style="height: 25px; line-height: 25px;">
                                                                <td align="left" width="25%">
                                                                    Pick Up Information</td>
                                                                <td align="left">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="6" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td width="25%">
                                                                    Arriving From:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Flight Number and Airline code:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Estimated Time of Arrival:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="0" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_package_step6_TravelerInformation_title2" style="height: 25px; line-height: 25px;">
                                                                <td align="left" width="25%">
                                                                    Drop Off Information</td>
                                                                <td align="left">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="6" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td width="25%">
                                                                    Hotel Address:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    City:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Country/State:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Zip Code:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Phone Number:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>--%>
                                    <table class="IBE_T_step03 IBE_T_font_11" width="100%" align="center" border="0"
                                        cellpadding="0" cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw IBE_T_font_11">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label9" runat="server" meta:resourcekey="lblTravelerInformation">Contact Information</asp:Label></div>
                                                    <uc11:PKGContactViewControl ID="PKGContactViewControl1" runat="server"></uc11:PKGContactViewControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="IBE_package_SearchCondition_T_step04 IBE_T_font_11">
                                        <uc8:PriceInfoControl ID="PriceInfoControl1" runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div id="divCCInfo" runat="server">
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label10" runat="server" meta:resourcekey="lblCreditCardInformation">Enter Your Credit Card Information</asp:Label></span>
                    </div>
                    <div class="IBE_YellowDIV_Right_travelContact_step4">
                        <div class="IBE_YellowDIV_Right_inSide1_travelContact_step4">
                            <uc9:CreditCardInfoControl ID="CreditCardInfoControl1" runat="server" />
                        </div>
                    </div>
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
                <div class="IBE_package_step">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <span class="left">&nbsp;<asp:Label ID="Label11" runat="server" meta:resourcekey="lblVerify">Verify the Email Address</asp:Label></span>
                </div>
                <div class="IBE_package_remarks_travelContact">
                    <div style="line-height: 18px;">
                        <asp:Label ID="lblAlladdress" runat="server" meta:resourcekey="lblAlladdress" CssClass="IBE_T_font_11">All current and furture correspondence or information will be send to this address</asp:Label>:&nbsp;<asp:HyperLink
                            NavigateUrl="#" ID="lblEmail" runat="server"></asp:HyperLink>&nbsp;&nbsp;
                        <div id="emlc" style="display: block">
                            <a id="A280_1424" href="javascript:DEB(1)" class="d07">
                                <asp:Label ID="lblChangeAddress" runat="server" meta:resourcekey="lblChangeAddress"
                                    CssClass="IBE_T_font_11">Change the e-mail address</asp:Label></a>
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
                    </div>
                </div>
                <div class="IBE_DIV" style="text-align: right; margin-top: 10px;">
                    <span class="IBE_T_font_11">
                        <asp:Label ID="Label12" runat="server" meta:resourcekey="lblPlease">Please confirm all of the information is correct, then click</asp:Label></span>
                    &nbsp;<asp:Button ID="btnPurchase" runat="server" Text="Purchase" meta:resourcekey="btn_Purchase"
                        CssClass="IBE_search_btn02" OnClick="btnPurchase_Click" /></div>
            </div>
            <uc2:FooterP ID="Footer1" runat="server" />
        </div>
        <div id="MAIL_BODY" visible="false" style="display: none;">
            <uc12:SendEmailViewControl ID="SendEmailViewControl1" runat="server"></uc12:SendEmailViewControl>
        </div>
        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
