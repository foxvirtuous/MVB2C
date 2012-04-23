<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TravelForm.aspx.cs" Inherits="TravelForm"
    EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/PHContactInfoControl.ascx" TagName="PHContactInfoControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/HotelOrderPassengerInfoControl.ascx" TagName="HotelOrderPassengerInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/HTLTotalPriceControl.ascx" TagName="PackageTotalPrice"
    TagPrefix="uc10" %>
<%@ Register Src="~/UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearchControl"
    TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet"
        type="text/css" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
	
	function copytext(a)
	{
	    if (a.id == "HotelOrderPassengerInfoControl1_dlAdult_ctl00_txtAdultFirst")
	    {
	        document.getElementById("PHContactInfoControl1_txtFirst_txtMustInput").value = document.getElementById("HotelOrderPassengerInfoControl1_dlAdult_ctl00_txtAdultFirst").value;
	    }
	    
	    if (a.id == "HotelOrderPassengerInfoControl1_dlAdult_ctl00_txtAdultLast")
	    {
	        document.getElementById("PHContactInfoControl1_txtLast_txtMustInput").value = document.getElementById("HotelOrderPassengerInfoControl1_dlAdult_ctl00_txtAdultLast").value;
	    }
	    
	    if (a.id == "HotelOrderPassengerInfoControl1_dlAdult_ctl00_txtAdultMiddle")
	    {
	        document.getElementById("PHContactInfoControl1_txtMiddle_txtMustInput").value = document.getElementById("HotelOrderPassengerInfoControl1_dlAdult_ctl00_txtAdultMiddle").value;
	    }
	}
	
    </script>

</head>
<body onload="SetRepeatHotel();">
    <input id="cityandairport" type="hidden" value="A" runat="server" />
    <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="hpContainer" class="TableWidth1" align="center">
            <div id="ualbody" style="float: left; width: 100%;">
                <table border="0" cellpadding="0" cellspacing="0" id="ualbodyTable" width="100%">
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
                        <td align="left" valign="top" id="bodyCol3" width="100%">
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
                                                                                            <tr class="R_stepw">
                                                                                                <td align="left">
                                                                                                    <uc10:PackageTotalPrice ID="PackageTotalPrice1" runat="server"></uc10:PackageTotalPrice>
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
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="15">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="MV_hotel_step">
                                            <div class="MV_hotel_step_T_line01 left">
                                                1</div>
                                            <span class="left">&nbsp;<asp:Label ID="lblEnterTravelers" runat="Server" meta:resourcekey="lblEnterTravelers">Enter Travelers &amp; Contact Information</asp:Label></span></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                            </table>
                            <table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                                <tr class="R_stepo">
                                    <td valign="top">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                        <tr class="R_stepw">
                                                            <td>
                                                                <uc7:HotelOrderPassengerInfoControl ID="HotelOrderPassengerInfoControl1" runat="server">
                                                                </uc7:HotelOrderPassengerInfoControl>
                                                                <uc3:PHContactInfoControl ID="PHContactInfoControl1" runat="server"></uc3:PHContactInfoControl>
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
                                        <div class="MV_hotel_step">
                                            <div class="MV_hotel_step_T_line01 left">
                                                2</div>
                                            <span class="left">&nbsp;<asp:Label ID="lblOtherRemark" runat="Server" meta:resourcekey="lblOtherRemark">Other Remark for Your Trip</asp:Label></span></div>
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
                                                    <textarea class="remark" runat="server" name="textarea" id="txtRemark"></textarea>
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
                                        &nbsp;<asp:Label ID="lblPleaseconfirm" runat="Server" meta:resourcekey="lblPleaseconfirm">Please confirm all of the information is correct, then click</asp:Label>
                                        &nbsp;
                                        <asp:Button ID="ibtnSubmit" runat="server" Text="Continue" ValidationGroup="PackageCreditForm"
                                            OnClick="ibtnSubmit_Click" CssClass="search_btn02" Style="cursor: pointer" meta:resourcekey="ibtnSubmit" />
                                    </td>
                                </tr>
                            </table>
                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                            </table>
                            <!-- mian end-->
                        </td>
                    </tr>
                    <tr>
                        <td height="1">
                        </td>
                    </tr>
                </table>
            </div>
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
