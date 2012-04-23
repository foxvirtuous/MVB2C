<%@ Control Language="C#" AutoEventWireup="true" Inherits="Header" Codebehind="Header.ascx.cs" %>
<link href='<%=SecureUrlSuffix + MainCssPath + "style_index.css"%>' rel="stylesheet"
    type="text/css" />
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
<input id="CurrentTab" type="hidden" value="home" name="DefaultTab" runat="server" />
<table width="920" border="0" align="center" cellpadding="0" cellspacing="0" background="<%=SecureUrlSuffix + "images/index/h_bg.gif"%>">
    <tr>
        <td height="64" align="left" valign="top">
            <a href="/">
                <img src="<%=SecureUrlSuffix + MainImagesPath + WebsitImageName%>" vspace="10" border="0" /></a></td>
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
                            <asp:Label ID="lblMoreInfo" runat="server" meta:resourcekey="lblMoreInfo"> For More Information</asp:Label><asp:Label
                                ID="lblPhone" runat="server">
                            : 1-(888)-288-7528</asp:Label></span>
                    </td>
                    <td width="6">
                    </td>
                    <asp:Panel ID="pButton" runat="server">
                        <td>
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
                    <td id="tdHeaderHome" width="70" height="24" class="D_header" runat="server">
                        <asp:HyperLink ID="aHeaderHome" runat="server" CssClass="header_on" target="_top">
                            <asp:Label ID="lblHome" runat="server" meta:resourcekey="lblHome">Home</asp:Label></asp:HyperLink></td>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                        <td id="tdHeaderF" width="70" runat="server"><asp:HyperLink ID="aHeaderF" runat="server" CssClass="header_off" target="_top">
                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlights">Flights</asp:Label></asp:HyperLink></td>
                        <td id="tdHeaderT" width="70" runat="server"><asp:HyperLink ID="aHeaderT" runat="server" CssClass="header_on" target="_top">
                                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblTours">Tours</asp:Label></asp:HyperLink></td>
                        <td id="tdHeaderAH" width="90" runat="server"><asp:HyperLink ID="aHeaderAH" runat="server" CssClass="header_on" target="_top">
                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblAirHotel">Air+Hotel</asp:Label></asp:HyperLink></td>
                        <td id="tdHeaderH" width="70" runat="server"><asp:HyperLink ID="aHeaderH" runat="server" CssClass="header_on" target="_top">
                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblHotels">Hotels</asp:Label></asp:HyperLink></td>
                        <td id="tdHeaderC" width="70" runat="server"><asp:HyperLink ID="aHeaderC" runat="server" CssClass="header_on" target="_top">
                                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblCruises">Cruises</asp:Label></asp:HyperLink></td>
                        <td width="110" runat="server" id="tdIncentiveTour"><asp:HyperLink ID="aHeaderI" runat="server" CssClass="header_on" target="_top">
                                <asp:Label ID="Label10" runat="server" meta:resourcekey="lblIncentiveTour">Incentive Tour</asp:Label></asp:HyperLink></td>
                        <td width="110" runat="server" id="tdSubAgent"><asp:HyperLink ID="aHeaderB" runat="server" CssClass="header_on" target="_top">                            
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblTravelAgents">Travel Agents</asp:Label></asp:HyperLink></td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phSubTour" runat="server">
                        <td width="70">
                            <a href="<%=SaleWebSuffix + "B2B_SUB/TourIndex.aspx"%>?tab=T" class="header_off"
                                target="_top">
                                <asp:Label ID="Label9" runat="server" meta:resourcekey="lblTours">Tour</asp:Label></a></td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phSubInsurance" runat="server">
                        <td width="70">
                            <a href="<%=SaleWebSuffix + "Page/Insurance/NewInsuranceSeachMainForm.aspx"%>?tab=I"
                                class="header_off" target="_top">
                                <asp:Label ID="Label11" runat="server" meta:resourcekey="Insurance">Insurance</asp:Label></a></td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="phSubIncentiveTour" runat="server">
                        <td width="70">
                            <a href="<%=SaleWebSuffix + "Page/B2BIncentiveTour/TourListView.aspx"%>?tab=I" class="header_off"
                                target="_top">
                                <asp:Label ID="Label12" runat="server" meta:resourcekey="IncentiveTour">Incentive Tour</asp:Label></a></td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                        <td width="110">
                            <a href="<%=SaleWebSuffix + "B2B_SUB/Flyer_grp.aspx?Type=Tour&Region=Tour Dept. List"%>"
                                class="header_off" target="_top">
                                <asp:Label ID="Label8" runat="server" meta:resourcekey="lblToursDeptList">Tour Dept. List</asp:Label></a></td>
                    </asp:PlaceHolder>
                    <asp:PlaceHolder ID="PlaceHolder3" runat="server">
                        <td width="140" style="display:none" >
                            <a href="<%=SaleWebSuffix + "2012 agent commission.xls"%>" class="header_off"
                                target="_top">
                                <asp:Label ID="Label13" runat="server" meta:resourcekey="IncentiveTour">2012 agent commission</asp:Label></a></td>
                    </asp:PlaceHolder>
                    <td align="right">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="right">
                                    <span class="t04">
                                        <asp:Label ID="lbName" runat="server"></asp:Label>
                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblWelcome" Style="display: none">Welcome to Majestic Vacations</asp:Label></span>
                                    <asp:HyperLink ID="lbtnJoin" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/register.aspx"
                                        meta:resourcekey="lbtnJoin">Join now |</asp:HyperLink>
                                    <asp:HyperLink ID="lbtnLogin" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/SalesLogin.aspx"
                                        meta:resourcekey="lbtnLogin">Log In</asp:HyperLink>
                                    <asp:HyperLink ID="lbtnLogout" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/Logout.aspx"
                                        meta:resourcekey="lbtnLogout">Log Out</asp:HyperLink>
                                    <asp:HyperLink ID="lbtnMyAccount" runat="server" CssClass="d08" Target="_top" NavigateUrl="~/Page/Common/MemberMyAccountForm.aspx"
                                        meta:resourcekey="lbtnMyaccount">| My account</asp:HyperLink>
                                </td>
                                <td width="95" align="right">
                                    <!-- AddThis Button BEGIN -->
                                    <a class="addthis_button" style="margin-top: 3px; margin-right: 3px;" href="http://www.addthis.com/bookmark.php?v=250&amp;pub=esoon">
                                        <img src="http://s7.addthis.com/static/btn/sm-share-en.gif" width="83" height="16"
                                            alt="Bookmark and Share" style="border: 0" /></a><script type="text/javascript" src="http://s7.addthis.com/js/250/addthis_widget.js#pub=esoon"></script>

                                    <!-- AddThis Button END -->
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
