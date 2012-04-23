<%@ Page Language="C#" AutoEventWireup="true" Inherits="Terms.B2B_SUB.Index" EnableEventValidation="false"
    Codebehind="Index.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
    <script src="../CommJs/Mvcal.js" type="text/javascript"></script>
    <script src="../CommJs/Mvcal2.js" type="text/javascript"></script>
</head>
<body onload="FillDiv('3');">
    <form id="form1" runat="server">
        <input id="CurrentTab" type="hidden" value="F" name="DefaultTab" runat="server" /><input
            id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="cityandairport" type="hidden" value="A" runat="server" /><input id="FlightType"
            type="hidden" value="roundtrip" name="FlightType" runat="server" />
        <asp:ScriptManager ID="MainScriptManager" runat="server" ScriptMode="release" LoadScriptsBeforeUI="true" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../CommJs/Mvcalx.htm">
        </iframe>
        <uc1:Header ID="Header1" runat="server" />
        <div>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td colspan="2">
                        <a href="/">
                            <img src="../images/v2/top.gif" border="0"></a></td>
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
                                            <li style="margin-right: 0px;"><a id="lbtnT" onclick="FillDiv('4');" class="tab_a_tour">
                                                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblTour">Tour</asp:Label></a>
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
                                                <img src="../images/index/en_bot.gif" /></td>
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
                        <iframe src="<%=SaleWebSuffix + MainMapPath + "map_b2b.htm"%>" width="305" height="250" name="ifrm" id="ifrm" scrolling="no"
                            frameborder="0"></iframe>
                    </td>
                    <td width="615" align="right" valign="top">
                        <table width="605" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <table width="605" height="60" border="0" cellpadding="0" cellspacing="0" background="../images/b2b/b2b_welcome.gif">
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
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
                                        <param name="movie" value="../images/b2b/ad_b2b.swf" />
                                        <param name="quality" value="high" />
                                        <param name="menu" value="false">
                                        <param name="wmode" value="opaque">
                                        <param name="bgcolor" value="#ffffff" />
                                        <embed src="../images/b2b/ad_b2b.swf" quality="high" bgcolor="#ffffff" width="605"
                                            height="195" align="middle" allowscriptaccess="sameDomain" type="application/x-shockwave-flash"
                                            pluginspage="http://www.macromedia.com/go/getflashplayer"  wmode="Opaque" />
                                    </object>
                                </td>
                            </tr>
                        </table>
                        <table width="605" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="19">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="../images/b2b/b2b_titlebg.gif" style="display:none" >
                                        <tr>
                                            <td width="45" align="left">
                                                <img src="../images/b2b/b2b_title01.gif" /></td>
                                            <td align="left">
                                                <span class="t02"><asp:Label ID="lblTraveleNews" runat="server" meta:resourcekey="lblTraveleNews">Travel eNews</asp:Label></span></td>
                                        </tr>
                                    </table>
                                    <table width="100%" height="105" border="0" cellpadding="0" cellspacing="0" style="display:none" >
                                        <tr>
                                            <td width="230" align="center">
                                                <img src="../images/b2b/b2b_pic_enews.gif" vspace="10" /></td>
                                            <td>
                                                <span class="t14">When Autumn leaves start to fall, so do prices!</span><br />
                                                <span class="t08">Issued date: 2008/10/30</span><br />
                                                <a href="http://www.majestic-vacations.com/newsletters/081028_aa.html" target="_blank">
                                                    <img src="../images/b2b/b2b_view.gif" hspace="0" vspace="5" border="0" /></a>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="price" style="display:none" >
                                        <tr bgcolor="#CCCCCC">
                                            <td align="left" valign="top" height="1">
                                                <img src="../images/b2b/space.gif" /></td>
                                        </tr>
                                        <tr>
                                            <td height="10">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" height="28" align="left" style="border-bottom: solid #CCCCCC 1px">
                                                            &nbsp;&nbsp;&nbsp;<span class="t15">Post-Olympic Beijing From $888</span></td>
                                                        <td width="35%" align="center" style="border-bottom: solid #cccccc 1px">
                                                            Issued date: 2008/08/17</td>
                                                        <td width="15%" align="center" style="border-bottom: solid #cccccc 1px">
                                                            <a href="http://subagent.majestic-vacations.com/newsletters/080828_aa.html" target="_blank">
                                                                <img src="../images/b2b/b2b_view.gif" hspace="0" vspace="5" border="0" /></a></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="605" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="19" colspan="3">
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" align="left" valign="top">
                                    <table width="99%" border="0" cellpadding="0" cellspacing="0" background="../images/b2b/b2b_titlebg.gif">
                                        <tr>
                                            <td width="45" align="left">
                                                <img src="../images/b2b/b2b_title02.gif" /></td>
                                            <td align="left">
                                                <span class="t02"><asp:Label ID="lblPackageDownLoad" runat="server" meta:resourcekey="lblPackageDownLoad">Air + Hotel Flyer Download</asp:Label></span></td>
                                        </tr>
                                    </table>
                                    <asp:DataList ID="dlPackage" runat="server" RepeatColumns="4" Width="99%">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="10" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr class="R_top">
                                                    <td align="center" width="25%">
                                                        <asp:Label ID="lblPackage" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="4">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList></td>
                                <td width="50%" align="center" valign="top">
                                    <table width="99%" border="0" cellpadding="0" cellspacing="0" background="../images/b2b/b2b_titlebg.gif">
                                        <tr>
                                            <td width="45" align="left">
                                                <img src="../images/b2b/b2b_title03.gif" /></td>
                                            <td align="left">
                                                <span class="t02"><asp:Label ID="lblTourDownLoad" runat="server" meta:resourcekey="lblTourDownLoad">Tour Flyer Download</asp:Label></span></td>
                                        </tr>
                                    </table>
                                    <asp:DataList ID="dlTour" runat="server" RepeatColumns="4" Width="99%">
                                        <ItemTemplate>
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="10">
                                                    </td>
                                                </tr>
                                                <tr class="R_top">
                                                    <td align="center">
                                                        <asp:Label ID="lblTour" runat="server" Text=""></asp:Label>
                                                        <%--<a href="#" class="d01">
                                                            <img src="../images/b2b/top_b2b01.gif" hspace="3" border="0" align="absmiddle" /><br />
                                                            <u>Asia</u></a>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
