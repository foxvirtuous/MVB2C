<%@ Page Language="C#" AutoEventWireup="true" Inherits="CruiseIndex" EnableEventValidation="false"
    Codebehind="CruiseIndex.aspx.cs" %>

<%@ Register Src="~/UserControls/Header.ascx" TagName="Header" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cruise Tour : Majestic Vacations</title>
    <meta name="ROBOTS" content="NOODP" />
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
        <table cellspacing="0" cellpadding="0" width="920" align="center" border="0">
            <tr>
                <td colspan="2">
                    <a href="/">
                        <img src="images/v2/top.gif" border="0"></a></td>
            </tr>
            <tr>
                <td valign="top" align="left" width="305">
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
                <td valign="top" align="right" width="615">
                    <table width="605" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,0,0"
                                    width="605" height="195" align="middle">
                                    <param name="allowScriptAccess" value="sameDomain" />
                                    <param name="movie" value="<%=SaleWebSuffix + ImagesPath + "ad_cruise.swf"%>" />
                                    <param name="quality" value="high" />
                                    <param name="wmode" value="transparent" />
                                    <param name="bgcolor" value="#ffffff" />
                                    <embed src="<%=SaleWebSuffix + ImagesPath + "ad_cruise.swf"%>" quality="high" bgcolor="#ffffff"
                                        width="605" height="195" align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"
                                        pluginspage="http://www.macromedia.com/go/getflashplayer" wmode="Opaque" />
                                </object>
                                <table width="605" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="12">
                                        </td>
                                    </tr>
                                </table>
                                <table width="605" border="0" cellpadding="0" cellspacing="0" background="images/tour_des_bg.gif">
                                    <tr>
                                        <td width="605" height="28" background="images/cruise_des_bar.gif" class="grp_title-w" align=left >
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Top Deals</td>
                                    </tr>
                                    <tr>
                                        <td height="121" valign="top" style="border-right-style: solid; border-left-style: solid;
                                            border-right-color: #FF4713; border-left-color: #FF4713; border-right-width: 2px;
                                            border-left-width: 2px; padding: 0px;">                                            
                                            <asp:DataList ID="dlCruise" runat="server" width="601" border="0" cellspacing="0" cellpadding="0" >
                                                <ItemTemplate>
                                                    <td class="cruise_table">
                                                        <span class="cruise_line">
                                                            <asp:Label ID="lblType" runat="server" Text="lblType"></asp:Label></span></td>
                                                    <td class="cruise_table2" align=left>
                                                        <img style="margin: 4px 5px 0px 0px;" src="images/cruise_des_icon.gif" width="13"
                                                            height="13" /><asp:HyperLink ID="hlName" runat="server" CssClass="d13" Target=_blank ></asp:HyperLink></td>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5">
                                            <img src="images/tour_des_down.gif" width="605" height="5" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <div style="width: 605px; height: 440px;">
                        <iframe src="<%=SaleWebSuffix + HtmlPath + "cruise_indexpage.htm"%>" width="605"
                            height="440" name="ifrm" id="Iframe1" scrolling="no" frameborder="0" style="margin: 0px;
                            padding: 0px;"></iframe>
                    </div>
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
<link href="css/style_new1.css" rel="stylesheet" type="text/css" />
</html>
