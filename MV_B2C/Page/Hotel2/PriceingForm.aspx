<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PriceingForm.aspx.cs" Inherits="PriceingForm" %>

<%@ Register Src="~/UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearchControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/HTLInfoControl.ascx" TagName="HotelInfoControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/HTLSelectRoomTypeControl.ascx" TagName="HTLSelectRoomTypeControl"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="Navigation" TagPrefix="uc11" %>
<%@ Register Src="~/UserControls/UserLoginControl.ascx" TagName="UserLoginControl"
    TagPrefix="uc10" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

</head>
<body id="mybody" onload="SetRepeatHotel();fillMarkup();">
    <form id="form1" runat="server">
        <input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <asp:Button Text="" Width="0" runat="server" ID="btnSelect" OnClick="btnSelect_Click"
            Style="display: none" TabIndex="0" /><input id="FocusIndex" type="hidden" value=""
                runat="server" />
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div id="hpContainer" class="TableWidth1" align="center">
            <div id="ualbody" style="float: left;">
                <table border="0" cellpadding="0" cellspacing="0" id="ualbodyTable" width="100%">
                    <tr>
                        <td colspan="2" height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <uc11:Navigation ID="ctlNavigationControl" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="20%">
                            <!-- leftcol.jsp | begin -->
                            <uc6:HotelOnlySearchControl ID="HotelOnlySearchControl1" runat="server" />
                            <!-- leftcol.jsp | end -->
                        </td>
                        <td align="left" valign="top" id="bodyCol3">
                            <!-- main begin-->
                            <uc3:HotelInfoControl ID="ctlHotelInfoControl" runat="server" />
                            <uc2:HTLSelectRoomTypeControl ID="HTLSelectRoomTypeControl1" runat="server" />
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <div class="MV_hotel_step">
                                            <div class="MV_hotel_step_T_line01 left">
                                                &gt;</div>
                                            <span class="left">&nbsp;<asp:Label ID="lblTermsConditions" runat="Server" meta:resourcekey="lblTermsConditions">Terms and Conditions</asp:Label></span></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="t_c">
                                            <asp:Label ID="lbConditons" runat="server"></asp:Label>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" align="left">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" align="left">
                                        <asp:CheckBox ID="chkConditions" runat="server" Text="Yes, I agree to the Terms and Conditions above."
                                            CssClass="orglab" meta:resourcekey="chkConditions" />
                                        <a name="bottom"></a><a href="#bottom" id="clickLink"></a>
                                    </td>
                                </tr>
                            </table>
                            <div>
                                <div id="divSignIn">
                                    <div id="divLongin" runat="server">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                        </table>
                                        <div visible="true" id="divSubmit" align="right">
                                            <asp:Label ID="lblpleaseclick" runat="Server" meta:resourcekey="lblpleaseclick">If you don't want to make any more change, please click</asp:Label>
                                            <asp:Button ID="btnContinue" Text="Continue" runat="server" CssClass="search_btn02"
                                                OnClick="btnContinue_Click" Style="cursor: pointer" meta:resourcekey="btnContinue" />
                                        </div>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="10">
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divHead" runat="server">
                                        <uc10:UserLoginControl ID="UserLogin1" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <!-- mian end-->
                        </td>
                    </tr>
                    <tr>
                        <td height="1">
                        </td>
                        <td>
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

        <script type="text/javascript">

if (document.getElementById("UserLogin1_txtPassword") != null)
{
        document.getElementById("UserLogin1_txtPassword").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13)
             {
                document.body.focus();
                document.getElementById("UserLogin1_btnLogin").click();
             }
        }
       }
       if (document.getElementById("UserLogin1_txtUserName") != null)
       {
        document.getElementById("UserLogin1_txtUserName").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13)
             {
                document.body.focus();
                document.getElementById("UserLogin1_btnLogin").click();
             }
        }
 }
        </script>

    </form>
</body>
</html>
