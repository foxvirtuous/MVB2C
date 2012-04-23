<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ChangeFlightsInformation.aspx.cs"
    Inherits="ChangeFlightsInformation" %>

<%@ Register Src="../../UserControls/PKGConditionsControl.ascx" TagName="PKGConditionsControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/PKGChangeDefaultFlightControl.ascx" TagName="PKGChangeDefaultFlightControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/PKGShowAllFlightsControl.ascx" TagName="PKGShowAllFlightsControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/PKGLeftSelectCondtions.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../../css/global.css" />
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
</head>
<body onload="SetRepeatPackage();"><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
                <div class="IBE_package_mainLeft">
                    <uc7:PackageLeftSelect ID="PackageLeftSelect1" runat="server" />
                  <%--  <uc7:ChangeTravelers ID="ChangeTravelers1" runat="server" />--%>
                </div>
                <div class="IBE_package_mainCenter">
                </div>
                <div class="IBE_package_mainRight">
                    <div class="IBE_GrayDIV_Right">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td class="IBE_package_SearchCondition_D_stepr" align="left" valign="top" height="25">
                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblSearchCondition">Search Condition</asp:Label></td>
                                    <td align="right">
                                       <%-- <img src="../../images/v2/arrow.gif" align="absmiddle" hspace="2">
                                        <asp:LinkButton ID="lbReturn" runat="server" CssClass="IBE_package_SearchCondition_f09"
                                            OnClick="lbReturn_Click">Return to the hotel details page</asp:LinkButton>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table class="IBE_package_SearchCondition_T_step03" border="0" cellpadding="8" cellspacing="1"
                                            width="100%">
                                            <tbody>
                                                <tr class="IBE_package_SearchCondition_R_stepw">
                                                    <td align="left">
                                                        <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                                            cellspacing="1" style="margin-top: 10px;">
                                                            <tbody>
                                                                <tr width="100%">
                                                                    <uc7:PKGConditionsControl ID="PKGConditionsControl1" runat="server"></uc7:PKGConditionsControl>
                                                                </tr>
                                                                <tr class="IBE_R_stepw">
                                                                    <td align="center">
                                                                        <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                                                            cellspacing="1" style="margin-top: 10px;">
                                                                            <tbody>
                                                                                <tr class="IBE_R_stepw">
                                                                                    <td align="center">
                                                                                        <div class="IBE_package_step6_TravelerInformation_title" style="height:24px; padding-top:6px;">
                                                                                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblCurrentlySelectedFlights">Currently Selected Flights</asp:Label></div>
                                                                                        <uc6:PKGChangeDefaultFlightControl ID="PKGChangeDefaultFlightControl1" runat="server">
                                                                                        </uc6:PKGChangeDefaultFlightControl>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <div style="margin-top: 10px; float: right;" class="IBE_T_font10">
                                                                            <span class="font_s15"><asp:Label ID="Label3" runat="server" meta:resourcekey="lblFlightAndHotel">Flight and Hotel</asp:Label>: $<asp:Label ID="lblAvgPrice" runat="server">974.53</asp:Label></span>
                                                                            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblAvg">avg/person</asp:Label> (<asp:Label ID="Label7" runat="server" meta:resourcekey="lblTotalCN"></asp:Label>$<asp:Label ID="lblTotalPrice" runat="server" CssClass="IBE_T_font11"></asp:Label>
                                                                            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblTotal">total</asp:Label>) &nbsp;&nbsp;
                                                                            <asp:Button ID="btnKeep" runat="server" Text="Keep this flight" CssClass="search_btn06 IBE_T_font13"
                                                                                OnClick="btnKeep_Click" meta:resourcekey="btnKeep" /></div>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblChangeFlight">Change Your Flight</asp:Label></span>
                    </div>
                    <div class="IBE_YellowDIV_Right">
                        <div class="IBE_GrayDIV_Right_inSide1">
                            <uc3:PKGShowAllFlightsControl ID="PKGShowAllFlightsControl1" runat="server"></uc3:PKGShowAllFlightsControl>
                        </div>
                        
                    </div>
                </div>
            </div>
            <uc2:FooterP ID="Footer1" runat="server" />
        </div>
        
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
