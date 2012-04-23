<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SuccForm.aspx.cs" Inherits="SuccessForm" %>

<%@ Register Src="~/UserControls/HTLContactControl.ascx" TagName="HTLContactControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/HTLTravelerControl.ascx" TagName="HTLTravelerControl"
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
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
        <link href="<%=SecureUrlSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SecureUrlSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SecureUrlSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SecureUrlSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />

    <script language="javascript">
			function doPrint(){
				
				window.print();
				
			}
    </script>
<script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SecureUrlSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
</head>
<body onload="SetRepeatHotel();"><input id="cityandairport" type="hidden" value="A" runat="server" />
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
            <div id="ualbody" style="float: left;">
                <table border="0" cellpadding="0" cellspacing="0" id="ualbodyTable" width="100%">
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <uc6:NavigationControl ID="NavigationControl1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td height="5">
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="bodyCol3" width="100%">
                            <!-- main begin-->
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <div class="MV_hotel_step">
                                            <div class="MV_hotel_step_T_line01 left">
                                                1</div>
                                            <span class="left">&nbsp;<asp:Label ID="lblThanksPurchase" runat="Server" meta:resourcekey="lblThanksPurchase">Thanks for Your Purchase</asp:Label></span></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblOrderwasplaced" runat="Server" meta:resourcekey="lblOrderwasplaced">Order was placed on</asp:Label>:
                                        <asp:Label ID="lblNow" runat="server"></asp:Label><asp:Label ID="Label1" runat="server"
                                            Text=" "></asp:Label>
                                        <asp:Label ID="lblUSMountainTime" runat="Server" meta:resourcekey="lblUSMountainTime">US Easten Time</asp:Label>.<br />
                                        <asp:Label ID="Label2" runat="Server" meta:resourcekey="Label2">The confirmation e-mail will be sent out within 3 business days. If you do not hear
                                                    back from us within 3 business days, please call us at 1-(888)-288-7528</asp:Label>.</td>
                                </tr>
                                <tr>
                                    <td height="10">
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
                                                                                        <asp:Label ID="lblYourOrderSummary" runat="Server" meta:resourcekey="lblYourOrderSummary">Hotel Order Summary</asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                                                            <tr class="R_stepw">
                                                                                                <td align="left">
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
                                                                                                                                        <font class="t09">
                                                                                                                                            <asp:Label ID="lblTheOrderNumber" runat="Server" meta:resourcekey="lblTheOrderNumber">The Order Number</asp:Label>:</font>
                                                                                                                                        <font class="t10">
                                                                                                                                            <asp:Label ID="lblCaseNumber" runat="server"></asp:Label></font></td>
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
                                                                                                    <uc10:PackageTotalPrice ID="PackageTotalPrice1" runat="server"></uc10:PackageTotalPrice>
                                                                                                    <br />
                                                                                                    <uc7:HTLTravelerControl ID="HTLTravelerControl1" runat="server" />
                                                                                                    <br />
                                                                                                    <uc3:HTLContactControl ID="HTLContactControl" runat="server" />
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
                            <div class="MV_hotel_step">
                                <div class="MV_hotel_step_T_line01 left">
                                    &gt;</div>
                                <span class="left">&nbsp;<asp:Label ID="lblServiceContact" runat="Server" meta:resourcekey="lblServiceContact">Service Contact</asp:Label></span>
                            </div>
                            <div class="MV_hotel_remarks">
                                <div class="MV_hotel_step7_Service">
                                    <ul>
                                        <li>&#8226; &nbsp;
                                            <asp:Label ID="lblCustomerStaff" runat="server" meta:resourcekey="lblCustomerStaff">Customer Service Staff</asp:Label>:
                                            <span class="dealpri"><asp:Label runat=server ID="lblSalesName"></asp:Label></span>
                                            <br />
                                        </li>
                                        <li>&#8226; &nbsp;
                                            <asp:Label ID="lblPhone" runat="server" meta:resourcekey="lblPhone">Phone</asp:Label>:
                                            <span class="dealpri"><asp:Label runat=server ID="lblSalesTel"></asp:Label></span>
                                            <br />
                                        </li>
                                        <li>&#8226; &nbsp;
                                            <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:<asp:Label runat=server ID="lblSalesEmail"></asp:Label>
                                            </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="MV_hotel_step7_print"><%--
                                <asp:Button ID="Button1" runat="server" Text="Print out this page" CssClass="search_btn05"
                                    Style="cursor: pointer" meta:resourcekey="Button1" />--%>
                                <asp:Button ID="ibtnSubmit" runat="server" Text="Homepage" OnClick="ibtnSubmit_Click"
                                    CssClass="search_btn05" Style="cursor: pointer" meta:resourcekey="ibtnSubmit" />
                            </div>
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
