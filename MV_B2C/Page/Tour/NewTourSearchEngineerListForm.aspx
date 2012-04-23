<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NewTourSearchEngineerListForm.aspx.cs"
    Inherits="NewTourSearchEngineerListForm" %>

<%@ Register Src="../../UserControls/TourSearchEngineer.ascx" TagName="TourSearchEngineer"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/TopDestinationsControl.ascx" TagName="TopDestinationsControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/Header.ascx" TagName="Header" TagPrefix="uc3" %>
<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ MasterType VirtualPath="TourBookingPage.Master" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA,
        Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new1.css"%>" rel="stylesheet"
        type="text/css" />
</head>
<body>
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
                        <img src="../../images/v2/top.gif" border="0"></a></td>
            </tr>
            <tr>
                <td width="305" align="left" valign="top">
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
                    <uc6:TourSearchEngineer ID="TourSearchEngineer1" runat="server" />
                    <uc7:TopDestinationsControl ID="TopDestinationsControl1" runat="server" />
                    </ br>
                    <table width="615" border="0" cellpadding="8" cellspacing="1" bgcolor="#B3B3B3">
                        <tr>
                            <td height="238" align="left" valign="top" bgcolor="#F4F4F4" style="width: 614px">
                                <div id="pagebar1" style="border-bottom-style: solid; border-bottom-color: #B3B3B3;
                                    border-bottom-width: 1px;">
                                    <div id="pagetittle">
                                    </div>
                                    <div id="page_sale">
                                    </div>
                                </div>
                                <asp:DataList ID="dlTourList" runat="server" OnItemCommand="dlTourList_ItemCommand"
                                    OnItemDataBound="dlTourList_ItemDataBound" width="615">
                                    <ItemTemplate>
                                        <table width="615" border="0" cellspacing="0" cellpadding="8" style="border-bottom-style: solid;
                                            border-bottom-color: #B3B3B3; border-bottom-width: 1px;">
                                            <tr>
                                                <td bgcolor="#FFFEE6">
                                                    <table width="590" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="438" height="40" align="left">
                                                                <asp:LinkButton ID="hlTourName" runat="server" CssClass="d13_tour-name" CommandName="Select">
                                                                    <asp:Label ID="lblTourName" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'></asp:Label></asp:LinkButton></td>
                                                            <td width="162" align="right">
                                                                <strong>
                                                                    <asp:Label ID="keyTourCode" runat="server" Text="Tour Code: " meta:resourcekey="keyTourCode"></asp:Label></strong>
                                                                <asp:LinkButton ID="hlTourCode" runat="server" CssClass="t13" CommandName="Select">
                                                                    <asp:Label ID="lblTourCode" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() %>'></asp:Label></asp:LinkButton></td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5">
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table width="590" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="160" align="left" valign="top">
                                                                <asp:Image ID="imgTour" runat="server" Width="150" Height="100" border="0" onerror="this.src='http://www.majestic-vacations.com/images/default_pic.gif';" />
                                                                <asp:Image ID="imgSale" ImageUrl="http://www.majestic-vacations.com/images/icon_sale.png"
                                                                    runat="server" Width="72" Height="47" vspace="5" Style="position: absolute; margin: -5px 0px 0px -159px;
                                                                    *margin: -10px 0px 0px -164px;" />
                                                            </td>
                                                            <td width="270" valign="top">
                                                                <table width="277" height="80" border="0" cellpadding="0" cellspacing="0" class="t15">
                                                                    <tr>
                                                                        <td width="126" align="left" valign="top">
                                                                            <b>
                                                                                <asp:Label ID="Label1" meta:resourcekey="lblDeparturePlace" runat="server" Text="Departure Place"></asp:Label>:</b></td>
                                                                        <td width="252" align="left" valign="top">
                                                                            <asp:Label ID="lblDeparturePlace" runat="server" Text="New York"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" align="left">
                                                                            <b>
                                                                                <asp:Label ID="Label2" meta:resourcekey="lblDuration" runat="server" Text="Duration"></asp:Label>:</b></td>
                                                                        <td valign="top" align="left">
                                                                            <asp:Label ID="lblDuration" runat="server" Text='<%# ((TourProfile)((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile).Days.ToString() %>'></asp:Label>
                                                                            Days</td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <b>
                                                                                <asp:Label ID="Label3" meta:resourcekey="lblOperating" runat="server" Text="Operating"></asp:Label>:</b></td>
                                                                        <td align="left" valign="top">
                                                                            <asp:Label ID="lblOperating" runat="server" Text="Sep 17th 2011 - Oct 15th 2011: Daily"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="left" valign="top">
                                                                            <strong>
                                                                                <asp:Label ID="Label4" meta:resourcekey="lblVisiting" runat="server" Text="Visiting"></asp:Label>:</strong></td>
                                                                        <td align="left" valign="top">
                                                                            <asp:Label ID="lblVisiting" runat="server" Text=""></asp:Label></td>
                                                                    </tr>
                                                                    <tr style="display: none">
                                                                        <td colspan="2" align="left" valign="top">
                                                                            <span id="ctl00_MainContent_Label"><b>
                                                                                <asp:Label ID="Label5" meta:resourcekey="lblHighlights" runat="server" Text="Highlights"></asp:Label>:</b></span><span
                                                                                    id="ctl00_MainContent_lblHighlight"><strong><br />
                                                                                    </strong><span id="ctl00_MainContent_lblHighlight4">
                                                                                        <asp:Label ID="lblHighlight" runat="server" Text=""></asp:Label></span><br />
                                                                                </span>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td width="150" valign="top">
                                                                <table align="right" border="0" cellpadding="0" cellspacing="0" width="95">
                                                                    <tbody>
                                                                        <tr align="right" valign="top">
                                                                            <td align="center" width="150" nowrap="nowrap">
                                                                                <font class="t11">
                                                                                    <asp:Label ID="Label6" meta:resourcekey="lblStartingFrom" runat="server" Text="Starting From"></asp:Label></font><font
                                                                                        class="t11">
                                                                                        <br />
                                                                                        $<span class="tour-list_price"><asp:Label ID="lbl_PriceValue" runat="server" Text='000.00' /></span><asp:Label
                                                                                            ID="Label7" meta:resourcekey="lblQi" runat="server" Text=""></asp:Label>
                                                                                        <br />
                                                                                    </font>
                                                                            </td>
                                                                        </tr>
                                                                        <tr align="left" valign="top">
                                                                            <td align="center">
                                                                                <img runat="server" id="Icon21" src="../../images/Icon_21.gif" visible="false" width="128"
                                                                                    height="22" vspace="5" /></td>
                                                                        </tr>
                                                                        <tr align="left" valign="top">
                                                                            <td align="center">
                                                                                <img runat="server" id="Icon22" src="../../images/Icon_22.gif" visible="false" width="128"
                                                                                    height="22" vspace="5" /></td>
                                                                        </tr>
                                                                        <tr align="left" valign="top">
                                                                            <td align="center">
                                                                                <asp:ImageButton ID="imgbtnTour" ImageUrl="http://www.majestic-vacations.com/images/Icon_check-detail.gif"
                                                                                    meta:resourcekey="imgTour" runat="server" Width="118" Height="32" vspace="5"
                                                                                    border="0" CommandName="Select" /></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td height="7" bgcolor="#FFFFFF">
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="#FFFFFF">
                                <uc4:PageNumber ID="PageNumber1" runat="server"></uc4:PageNumber>
                            </td>
                        </tr>
                        <tr>
                            <td height="3" bgcolor="#FFFFFF">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
