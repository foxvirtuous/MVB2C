<%@ Page Language="C#" AutoEventWireup="true" Inherits="FlightIndex" EnableEventValidation="false"
    Codebehind="FlightIndex.aspx.cs" %>

<%@ Register Src="~/UserControls/Header.ascx" TagName="Header" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap airfare, Cheap tickets, online ticket booking : Majestic Vacations</title>
    <meta name="ROBOTS" content="NOODP"/>
    <meta name="verify-v1" content="aeVxP6zTHeQzT620ipj5+ikXd/VXcdlKoYUJ/C6vVdY=" />
</head>
<body onload="FillDiv('1');">
    <form id="form1" runat="server">
        <uc3:Header ID="Header1" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="CurrentTab" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="cityandairport" type="hidden" value="A" runat="server" /><input id="FlightType"
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
                    <iframe src="<%=SaleWebSuffix + HtmlPath + "extra.htm"%>" width="305" height="200"
                        name="ifrm" id="ifrm" scrolling="no" frameborder="0"></iframe>
                </td>
                <td width="615" align="right" valign="top">
                    <table width="605" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"
                                    width="605" height="195" align="middle">
                                    <param name="allowScriptAccess" value="sameDomain" />
                                    <param name="movie" value="<%=SaleWebSuffix + ImagesPath + "ad_tkt.swf"%>" />
                                    <param name="wmode" value="transparent" />
                                    <param name="quality" value="high" />
                                    <param name="bgcolor" value="#ffffff" />
                                    <embed src="<%=SaleWebSuffix + ImagesPath + "ad_tkt.swf"%>" quality="high" bgcolor="#ffffff"
                                        width="605" height="195" align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"
                                        pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="Opaque" />
                                </object>
                            </td>
                        </tr>
                    </table>
                    <div style="width: 605px; height: 360px;">
                        <iframe src="<%=SaleWebSuffix + HtmlPath + "flight_indexpage.htm"%>" width="605"
                            height="360" name="ifrm" id="Iframe1" scrolling="no" frameborder="0" style="margin: 0px;
                            padding: 0px;"></iframe>
                    </div>
                    <%--<table width="605" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="605" border="0" cellpadding="0" cellspacing="1" class="T_sale">
                                    <tr>
                                        <td align="left" bgcolor="#FFFFFF">
                                            <table width="603" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="8">
                                                    </td>
                                                    <td align="left" valign="top">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="10" colspan="8">
                                                                </td>
                                                            </tr>
                                                            <tr align="left">
                                                                <td colspan="8">
                                                                    <font class="head03">Top Destinations</font></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="8" colspan="8">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                            <tr class="R_top">
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=Honolulu" class="d01">
                                                                        <img src="images/v2/top_tkt01.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>Hawaii</u></a><br>
                                                                    </td>
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=San Francisco" class="d01">
                                                                        <img src="images/v2/top_tkt02.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>San Francisco</u></a><br>
                                                                    </td>
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=Orlando" class="d01">
                                                                        <img src="images/v2/top_tkt03.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>Orlando</u></a><br>
                                                                    </td>
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=Las Vegas" class="d01">
                                                                        <img src="images/v2/top_tkt04.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>Las Vegas</u></a><br>
                                                                    </td>
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=Tokyo" class="d01">
                                                                        <img src="images/v2/top_tkt05.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>Tokyo</u></a><br>
                                                                    </td>
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=Bangkok" class="d01">
                                                                        <img src="images/v2/top_tkt06.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>Bangkok</u></a><br>
                                                                    </td>
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=Taipei" class="d01">
                                                                        <img src="images/v2/top_tkt07.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>Taipei</u></a><br>
                                                                    </td>
                                                                <td align="center" >
                                                                    <a href="Page/Flight/FightRedirect.aspx?ToCity=Hong Kong" class="d01">
                                                                        <img src="images/v2/top_tkt08.gif" hspace="3" border="0" align="absmiddle"><br>
                                                                        <u>Hong Kong</u></a><br>
                                                                    </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10" colspan="8">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="8">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                                <table width="605" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" align="center" valign="top">
                                            <table width="290" border="0" align="center" cellpadding="0" cellspacing="0" class="T_sale01">
                                                <tr align="left">
                                                    <td colspan="2">
                                                        <font class="head03">Featured Promos</font></td>
                                                </tr>
                                                <tr>
                                                    <td width="122" align="left" valign="top">
                                                        <img src="images/v2/sale_tkt01.gif" vspace="5" border="0" align="absmiddle" /></td>
                                                    <td align="left" valign="top">
                                                        <a href="Page/Flight/FightRedirect.aspx?ToCity=Cancun" class="d06">Discover Cancun this summer!</a><br>
                                                        Explore the beauty of the Mexican Caribbean and the luxurious surroundings. Book your flights today!</td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="290" border="0" align="center" cellpadding="0" cellspacing="0" class="T_sale01">

                                              <tr>
                                                <td width="122" align="left" valign="top"><img src="images/v2/sale_tkt02.gif" vspace="5" border="0" align="absmiddle" /></td>
                                                <td align="left" valign="top"><a href="Page/Flight/FightRedirect.aspx?ToCity=Rome" class="d06">Save on Flights to Rome</a><br />
                                                  Find Cheap Flights to Rome! Great selection of discounted airfares &amp; compare prices. </td>
                                              </tr>
                                            </table></td>
                                        <td width="50%" valign="top"><img src="images/v2/ad_Worldspan.gif" width="307" height="220" border="0" usemap="#Map" /></td>
                                  </tr>
                                </table>
                            </td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <map name="Map" id="Map">
        <area shape="rect" coords="15,123,173,139" href="http://mytripandmore.com/" target="_blank" />
        <area shape="rect" coords="15,170,148,186" href="https://mytripandmore.com/FlightStatus.aspx?languagebox=No&amp;language=E"
            target="_blank" />
    </map>
</body>
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
    <script src="CommJs/Mvcal.js" type="text/javascript"></script>
    <script src="CommJs/Mvcal2.js" type="text/javascript"></script>
</html>
