<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header_New.ascx.cs" Inherits="Header_New" %>
<!-- for google analytics begin -->

<script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>

<script type="text/javascript">
var pageTracker = _gat._getTracker("UA-3007278-1");
pageTracker._initData();
pageTracker._trackPageview();
</script>

<!-- for google analytics end -->
<!-- BEGIN Invitation Positioning  -->

<script language="javascript" type="text/javascript">
var lpPosY = 100;
</script>

<!-- END Invitation Positioning  -->
<!-- BEGIN Monitor Tracking Variables  -->

<script language="JavaScript1.2">
if (typeof(tagVars) == "undefined") tagVars = "";
tagVars += "&SESSIONVAR!skill=MV-General";
</script>

<!-- End Monitor Tracking Variables  -->
<!-- BEGIN HumanTag Monitor. DO NOT MOVE! MUST BE PLACED JUST BEFORE THE /BODY TAG -->

<script language='javascript' src='http://server.iad.liveperson.net/hc/52394737/x.js?cmd=file&file=chatScript3&site=52394737&&imageUrl=http://www.majestic-vacations.com/images/livechat'> </script>

<script language="javascript" type="text/javascript" src="../../CommJs/user.js"></script>

<!-- END HumanTag Monitor. DO NOT MOVE! MUST BE PLACED JUST BEFORE THE /BODY TAG -->

<script language="javascript" type="text/javascript" src="../../CommJs/user.js"></script>

<table width="920" border="0" align="center" cellpadding="0" cellspacing="0" background="<%=SecureUrlSuffix + "images/index/h_bg.gif"%>">
    <tr>
        <td height="64" align="left" valign="top">
            <a href="/">
                <img src="<%=SecureUrlSuffix + MainImagesPath + "logo.gif"%>" vspace="10" border="0" /></a></td>
        <td width="50%" align="right" valign="top">
            <table border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                    </td>
                    <td width="8" height="5">
                    </td>
                </tr>
                <tr>
                    <td>
                        <span class="t03">
                            <asp:Label ID="lblMoreInfo" runat="server" meta:resourcekey="lblMoreInfo"> For More Information</asp:Label>
                            : 1-(888)-288-7528</span>
                    </td>
                    <td width="6">
                    </td>
                    <asp:Panel ID="pButton" runat="server">
                        <td >
                            <asp:ImageButton CommandArgument="en-US" ID="ibnEnglish" runat="server" ImageUrl="../images/index/lan_en.gif" />
                        </td>
                        <td width="2">
                        </td>
                        <td>
                            <asp:ImageButton ID="ibnChinese" CommandArgument="zh-CN" runat="server" ImageUrl="../images/index/lan_cn.gif" />
                        </td>
                    </asp:Panel>
                    <td width="8">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" runat="server" id="tdSpase">
                    </td>
                    <td align="right" colspan="3" runat="server" id="tdChat">
                        <div runat="server" id="divChat" visible="true">
                            <a id="_lpChatBtn" href='http://server.iad.liveperson.net/hc/52394737/?cmd=file&file=visitorWantsToChat&site=52394737&byhref=1&SESSIONVAR!skill=MV-General&imageUrl=http://www.majestic-vacations.com/images/livechat'
                                target='chat52394737' onclick="lpButtonCTTUrl = 'http://server.iad.liveperson.net/hc/52394737/?cmd=file&file=visitorWantsToChat&site=52394737&SESSIONVAR!skill=MV-General&imageUrl=http://www.majestic-vacations.com/images/livechat&referrer='+escape(document.location); lpButtonCTTUrl = (typeof(lpAppendVisitorCookies) != 'undefined' ? lpAppendVisitorCookies(lpButtonCTTUrl) : lpButtonCTTUrl); window.open(lpButtonCTTUrl,'chat52394737','width=475,height=400,resizable=yes');return false;">
                                <img src='http://server.iad.liveperson.net/hc/52394737/?cmd=repstate&site=52394737&channel=web&&ver=1&imageUrl=http://www.majestic-vacations.com/images/livechat&skill=MV-General'
                                    name='hcIcon' border="0"></a></div>
                    </td>
                    <td width="8">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="920" border="0" cellspacing="1" cellpadding="0" class="T_header">
                <tr align="center" class="R_header">
                    <td id="tdHeaderHome" width="70" height="24" class="D_header">
                        <a id="aHeaderHome" href="<%=SaleWebSuffix + "index.aspx"%>" class="header_on" target="_top">
                            <asp:Label ID="lblHome" runat="server" meta:resourcekey="lblHome">Home</asp:Label></a></td>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <td id="tdHeaderF" width="70">
                            <a id="aHeaderF" href="<%=SaleWebSuffix + "Flightindex.aspx"%>?tab=F" class="header_off"
                                target="_top">
                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlights">Flights</asp:Label></a></td>
                        <td id="tdHeaderT" width="70">
                            <a id="aHeaderT" href="<%=SaleWebSuffix + "Tourindex.aspx"%>?tab=T" class="header_off"
                                target="_top">
                                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblTours">Tours</asp:Label></a></td>
                        <td id="tdHeaderAH" width="90">
                            <a id="aHeaderAH" href="<%=SaleWebSuffix + "PackageIndex.aspx"%>?tab=AH" class="header_off"
                                target="_top">
                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblAirHotel">Air+Hotel</asp:Label></a></td>
                        <td id="tdHeaderH" width="70">
                            <a id="aHeaderH" href="<%=SaleWebSuffix + "HotelIndex.aspx"%>?tab=H" class="header_off"
                                target="_top">
                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblHotels">Hotels</asp:Label></a></td>
                        <td id="tdHeaderC" width="70">
                            <a id="aHeaderC" href="<%=SaleWebSuffix + "CruiseIndex.aspx"%>?tab=C" class="header_off"
                                target="_top">
                                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblCruises">Cruises</asp:Label></a></td>
                        <td width="110" runat="server" id="tdSubAgent">
                            <a href="<%=SaleWebSuffix + "B2B_SUB/Index.aspx"%>" class="header_off" target="_top">
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblTravelAgents">Travel Agents</asp:Label></a></td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                        <td width="110">
                            <a href="<%=SaleWebSuffix + "B2B_SUB/Flyer_grp.aspx?Type=Tour&Region=Tour Dept. List"%>"
                                class="header_off" target="_top">Tour Dept. List</a></td>
                    </asp:PlaceHolder>
                    <td align="right">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right">
                                    <span class="t04">
                                        <asp:Label ID="lbName" runat="server"></asp:Label>
                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblWelcome">Welcome to Majestic Vacations</asp:Label></span>
                                    |
                                    <asp:HyperLink ID="lbtnJoin" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/register.aspx"
                                        meta:resourcekey="lbtnJoin">Join now |</asp:HyperLink>
                                    <asp:HyperLink ID="lbtnLogin" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/SalesLogin.aspx"
                                        meta:resourcekey="lbtnLogin">Log In</asp:HyperLink>
                                    <asp:HyperLink ID="lbtnLogout" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/Logout.aspx"
                                        meta:resourcekey="lbtnLogout">Log Out</asp:HyperLink>
                                    <asp:HyperLink ID="lbtnMyAccount" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/MemberMyAccountForm.aspx"
                                        meta:resourcekey="lbtnMyaccount">| My account</asp:HyperLink>
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
</table>
<table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr bgcolor="#B3B3B3">
        <td height="1" valign="bottom">
        </td>
    </tr>
</table>