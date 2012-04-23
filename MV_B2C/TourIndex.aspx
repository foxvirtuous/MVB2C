<%@ Page Language="C#" AutoEventWireup="true" Inherits="TourIndex" EnableEventValidation="false"
    Codebehind="TourIndex.aspx.cs" %>

<%@ Register Src="UserControls/TourSearchEngineer.ascx" TagName="TourSearchEngineer"
    TagPrefix="uc7" %>
<%@ Register Src="UserControls/TopDestinationsControl.ascx" TagName="TopDestinationsControl"
    TagPrefix="uc6" %>
<%@ Register Src="UserControls/TourInfoControl.ascx" TagName="TourInfoControl" TagPrefix="uc13" %>
<%@ Register Src="~/UserControls/Header.ascx" TagName="Header" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Online Vacations Packages and Tours, Flights + Hotel
        Vacations : Majestic Vacations</title>
    <meta name="ROBOTS" content="NOODP" />
    <meta name="verify-v1" content="aeVxP6zTHeQzT620ipj5+ikXd/VXcdlKoYUJ/C6vVdY=" />
</head>
<body onload="FillDiv('4');">
    <form id="form1" runat="server">
        <uc3:Header ID="Header1" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="CurrentTab" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="cityandairport" type="hidden" value="T" runat="server" /><input id="FlightType"
            type="hidden" value="roundtrip" name="FlightType" runat="server" />
        <asp:ScriptManager ID="MainScriptManager" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="CommJs/Mvcalx.htm">
        </iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <a href="/">
                        <img src="images/v2/top.gif" border="0"></a></td>
            </tr>
            <tr>
                <td width="305" align="left" valign="top">
                    <table width="305" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table width="305" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: -2px;">
                                    <tr>
                                        <td height="10" background="#ff0000">
                                        </td>
                                    </tr>
                                </table>
                                <div class="TabDIV">
                                    <ul>
                                        <li><a id="lbtnA" onclick="FillDiv('1');" class="tab_a_flighthover">
                                            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblFlights">Flights</asp:Label></a>
                                        </li>
                                        <li><a id="lbtnAH" onclick="FillDiv('2');" class="tab_a_airHotel">
                                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblAirHotel">Air+Hotel</asp:Label></a>
                                        </li>
                                        <li><a id="lbtnH" onclick="FillDiv('3');" class="tab_a_hotels">
                                            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblHotels">Hotel</asp:Label></a>
                                        </li>
                                        <li><a id="lbtnT" onclick="FillDiv('4');" class="tab_a_tour">
                                            <asp:Label ID="Label7" runat="server" meta:resourcekey="lblTour">Tour</asp:Label></a>
                                        </li>
                                        <li style="margin-right: 0px;"><a id="lbtnC" onclick="FillDiv('6');" class="tab_a_car">
                                            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCar">Car</asp:Label></a>
                                        </li>
                                    </ul>
                                </div>
                                <table width="305" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: -2px;">
                                    <tr class="R_search">
                                        <td valign="top">
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="10">
                                                    </td>
                                                </tr>
                                            </table>
                                            <div id="divFile" visible="true" runat="server">
                                            </div>
                                            <div id="div1" class="index_tab_btn left">
                                                <button id="search" type="button" class="search_btn" onclick="SeachOrder();" style="cursor: hand">
                                                    Search</button>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="images/index/en_bot.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="305" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                    <iframe src="<%=SaleWebSuffix + HtmlPath + "map.htm"%>" width="305" height="620"
                        name="ifrm" id="ifrm" scrolling="no" frameborder="0"></iframe>
                </td>
                <td width="615" align="right" valign="top">
                    <uc7:TourSearchEngineer ID="TourSearchEngineer1" runat="server" />
                    <uc6:TopDestinationsControl ID="TopDestinationsControl1" runat="server"></uc6:TopDestinationsControl>
                    <table width="605" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <uc13:TourInfoControl ID="TourInfoControl1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>

<script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

<script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

<script src="CommJs/Mvcal.js" type="text/javascript"></script>

<script src="CommJs/Mvcal2.js" type="text/javascript"></script>

</html>
