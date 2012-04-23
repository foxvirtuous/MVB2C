<%@ Page Language="C#" AutoEventWireup="true" Inherits="Index" EnableEventValidation="false"
    Codebehind="Index.aspx.cs" %>
<%@ Register Src="~/UserControls/Header.ascx" TagName="Header" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title"></title>
    <meta name="verify-v1" content="8XOzG5ZZdNnqdVgNrd91i9Ab4zLwamAc4Keit4SDeb0=" />
    <meta name="ROBOTS" content="NOODP" />
</head>
<body onload="FillDiv('4');">
    <form id="form1" runat="server">
        <uc3:Header ID="Header1" runat="server" /><input id="CarType" type="hidden" value="D" name="CarType" runat="server" />
        <input id="CurrentTab" type="hidden" value="F" name="DefaultTab" runat="server" /><input
            id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="cityandairport" type="hidden" value="A" runat="server" /><input id="FlightType"
            type="hidden" value="roundtrip" name="FlightType" runat="server" />
        <asp:ScriptManager ID="MainScriptManager" runat="server" ScriptMode="release" LoadScriptsBeforeUI="false" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <a href="#">
                        <img src="<%=SaleWebSuffix + MainImagesPath + "ad_top01.gif"%>" border="0"></a></td>
            </tr>
            <tr>
                <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
                    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
                    marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="CommJs/Mvcalx.htm">
                </iframe>
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
                                        <li ><a id="lbtnT" onclick="FillDiv('4');" class="tab_a_tour">
                                            <asp:Label ID="Label7" runat="server" meta:resourcekey="lblTour">Tour</asp:Label></a>
                                        </li>
                                        <li style="margin-right: 0px;"><a id="lbtnC" onclick="FillDiv('6');" class="tab_a_car">
                                            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCar">Car</asp:Label></a>
                                        </li>
                                    </ul>
                                </div>
                                <table width="305" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 0px;">
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
                    <iframe src="<%=SaleWebSuffix + HtmlPath + "map.htm"%>" width="305" height="250"
                        name="ifrm" id="ifrm" scrolling="no" frameborder="0"></iframe>
                </td>
                <td width="615" align="right" valign="top">
                    <table width="615" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="height: 30px">
                                <img src="<%=SaleWebSuffix + MainImagesPath + "ad_top02.gif"%>" border="0"></td>
                        </tr>
                    </table>
                    <table width="615" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                    <table width="605" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"
                                    width="605" height="195" align="middle">
                                    <param name="allowScriptAccess" value="sameDomain" />
                                    <param name="movie" value="<%=SaleWebSuffix + ImagesPath + "ad_home.swf"%>" />
                                    <param name="quality" value="high" />
                                    <param name="wmode" value="transparent" />
                                    <param name="bgcolor" value="#ffffff" />
                                    <embed src="<%=SaleWebSuffix + ImagesPath + "ad_home.swf"%>" quality="high" bgcolor="#ffffff"
                                        width="605" height="195" align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"
                                        pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="Opaque" />
                                </object>
                            </td>
                        </tr>
                    </table>
                    <div style="width: 605px; height: 355px;">
                        <iframe src="<%=SaleWebSuffix + HtmlPath + "indexpage.htm"%>" width="605" height="355"
                            name="ifrm" id="Iframe1" scrolling="no" frameborder="0" style="margin: 0px; padding: 0px;">
                        </iframe>
                    </div>
                </td>
            </tr>
        </table>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="10">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td width="305" align="left">
                    <table width="303" border="0" cellpadding="0" cellspacing="0" class="T_sale">
                        <tr>
                            <td align="left" bgcolor="#FFFFFF">
                                <table width="303" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="95">
                                            <a href="http://www.travelresearchonline.com/brochures/majestic2010/brochure.aspx" target="_blank"><img src="<%=SaleWebSuffix + MainImagesPath + "tour-ad_305x77.jpg"%>" border="0" /></a></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="615" align="right">
                    <table width="605" border="0" cellpadding="0" cellspacing="1" class="T_sale">
                        <tr>
                            <td align="left" bgcolor="#FFFFFF">
                                <table width="603" border="0" cellspacing="0" cellpadding="0" background="images/index/tools.gif">
                                    <tr>
                                        <td width="13" height="75" align="left">
                                        </td>
                                        <td height="50" align="left" valign="top">
                                            <table width="510" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr align="left">
                                                    <td height="20" colspan="4">
                                                        <font class="head02">
                                                            <asp:Label ID="lblTravelTools" runat="server" meta:resourcekey="lblTravelTools">Travel Tools</asp:Label></font></td>
                                                </tr>
                                                <tr>
                                                    <td height="3" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                </tr>
                                                <tr>
                                                    <td height="16" align="left">
                                                        <img src="images/index/arrow2.gif" hspace="3" align="absmiddle" /><a href="http://www.weather.com/common/welcomepage/world.html?from=globalnav"
                                                            target="_blank" class="d01"><asp:Label ID="lblWeatherForcast" runat="server" meta:resourcekey="lblWeatherForcast">Weather Forcast</asp:Label></a></td>
                                                    <td height="16" align="left">
                                                        <img src="images/index/arrow2.gif" hspace="3" align="absmiddle" /><a href="http://www.worldtimeserver.com/"
                                                            target="_blank" class="d01"><asp:Label ID="lblCalculate" runat="server" meta:resourcekey="lblCalculate">Calculate World Time</asp:Label></a></td>
                                                    <td height="16" align="left">
                                                        <img src="images/index/arrow2.gif" hspace="3" align="absmiddle" /><a href="http://www.oanda.com/convert/classic"
                                                            target="_blank" class="d01"><asp:Label ID="lblCurrency" runat="server" meta:resourcekey="lblCurrency">Currency Exchange</asp:Label>
                                                        </a>
                                                    </td>
                                                    <td width="15%" align="left">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="16" align="left">
                                                        <img src="images/index/arrow2.gif" hspace="3" align="absmiddle" /><a href="Page/Common/HeaderPage.aspx?pagename=visa.htm"
                                                            class="d01"><asp:Label ID="lblVisaInfo" runat="server" meta:resourcekey="lblVisaInfo">Visa Info</asp:Label></a></td>
                                                    <td height="16" align="left">
                                                        <img src="images/index/arrow2.gif" hspace="3" align="absmiddle" /><a href="http://www.majestic-vacations.com/Flightindex.aspx?tab=F"
                                                            class="d01"><asp:Label ID="lblTravelInfoCenter" runat="server" meta:resourcekey="lblTravelInfoCenter">Your Travel Info Center</asp:Label></a>
                                                    </td>
                                                    <td height="16" align="left">
                                                        <img src="images/index/arrow2.gif" hspace="3" align="absmiddle" /><a href="http://www.majestic-vacations.com/Flightindex.aspx?tab=F"
                                                            class="d01"><asp:Label ID="lblCheckFlightStatus" runat="server" meta:resourcekey="lblCheckFlightStatus">Check Flight Status</asp:Label></a>
                                                    </td>
                                                    <td align="left">
                                                        &nbsp;
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
        <uc2:Footer ID="footer1" runat="server" />
    </form>
</body>
<script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>    
<script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
<script src="CommJs/Mvcal.js" type="text/javascript"></script>
<script src="CommJs/Mvcal2.js" type="text/javascript"></script>
</html>
