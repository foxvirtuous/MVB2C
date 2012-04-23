<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PromosIndex.aspx.cs" Inherits="PromosIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cheap airfare, Cheap tickets, online ticket booking : Majestic Vacations </title>
    <meta name="ROBOTS" content="NOODP" />
    <meta name="verify-v1" content="aeVxP6zTHeQzT620ipj5+ikXd/VXcdlKoYUJ/C6vVdY=" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" /><meta name="keywords" content="明星假期旅遊網, 美國國內機票, 亞洲機票, 台灣,香港,北京,上海 特廉機票, 中國國內機票優惠, 最便宜酒店, 全球酒店線上訂購, 套裝行程,機票+酒店, 旅遊, 超值旅遊,台灣旅遊,中國旅遊,美國東岸,西岸,夏威夷,奧蘭多, 亞洲旅遊, 兩人成行, 郵輪旅遊, 皇家旅遊,公主郵輪, 旅遊同業中心, 機票代理中心" /><meta name="description" content="明星假期旅遊, 最豐富,最便宜, 最便宜機票, 美國到中國機票, 酒店, 兩人成行自由行, 團體旅遊, 郵輪假期" />
    <link href="" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
</head>
<body onload="FillDiv('5');">
    <form id="form1" runat="server"><uc1:Header ID="Header1" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="CurrentTab" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="cityandairport" type="hidden" value="P" runat="server" /><input id="FlightType"
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
                </td>
                <td width="615" align="right" valign="top">
                    <iframe src="Promos/PromosIndex.htm" width="615" height="1300px" style="overflow:hidden;"
                        name="content" id="content" scrolling="no" frameborder="0"></iframe>
                </td>
            </tr>
        </table><uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>

<script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

<script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

<script src="CommJs/Mvcal.js" type="text/javascript"></script>

<script src="CommJs/Mvcal2.js" type="text/javascript"></script>

</html>
