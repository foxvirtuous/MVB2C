<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CuriseMoreSearchResultFrom.aspx.cs"
    Inherits="Terms.Web.Page.Cruise.CuriseMoreSearchResultFrom" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <div align=center>
            <table width="920" border="0" cellspacing="0" cellpadding="0" class="T_table">
                <tr>
                    <td height="15">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="20">
                                    <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                        <tr>
                                            <td align="center">
                                                ></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="5">
                                </td>
                                <td align="left">
                                    <span class="head06">
                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblSelect">Select a curise</asp:Label></span></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="920" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                            <tr class="R_stepo">
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="7">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table class="T_step0l" cellspacing="1" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                                                    <tr class="R_step03" align="center">
                                                                        <td width="15%">
                                                                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblPortName">Port</asp:Label>
                                                                        </td>
                                                                        <td width="73%" height="40">
                                                                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblTourName">Curise Name</asp:Label></td>
                                                                        <td width="12%">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <asp:DataList ID="dlCruiseList" runat="server" Width="100%" HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <tr class="R_stepw" align="center">
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lblPort" runat="server"><%# (DataBinder.Eval(Container.DataItem, "FlyerAirline"))%></asp:Label>
                                                            </td>
                                                            <td width="73%" align="left">
                                                                <asp:Label ID="lblCruiseName" runat="server"><%# (DataBinder.Eval(Container.DataItem,"FlyerName")) %></asp:Label>
                                                            </td>
                                                            <td width="12%">
                                                                <a href="<%# "http://terms.majestic-vacations.com/b2b/pdf/" + (DataBinder.Eval(Container.DataItem,"FlyerUrl"))%>"
                                                                    target="_blank">
                                                                    <img src="../../images/v2/btn_01.gif" style="border: 0px;" /></a></td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <AlternatingItemTemplate>
                                                        <tr class="R_stepg" align="center">
                                                            <td width="15%" align="left">
                                                                <asp:Label ID="lblPort" runat="server"><%# (DataBinder.Eval(Container.DataItem, "FlyerAirline"))%></asp:Label>
                                                            </td>
                                                            <td width="73%" align="left">
                                                                <asp:Label ID="lblCruiseName" runat="server"><%# (DataBinder.Eval(Container.DataItem,"FlyerName")) %></asp:Label>
                                                            <td width="12%">
                                                                <a href="<%# "http://terms.majestic-vacations.com/b2b/pdf/" + (DataBinder.Eval(Container.DataItem,"FlyerUrl"))%>">
                                                                    <img src="../../images/v2/btn_01.gif" style="border: 0px;" /></a></td>
                                                        </tr>
                                                    </AlternatingItemTemplate>
                                                    <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                                                        Font-Strikeout="False" Font-Underline="False" />
                                                </asp:DataList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br />
            <table cellpadding="0" cellspacing="0" border="0" width="920">
                <tr align="right">
                    <td>
                        <asp:Button ID="btn_back" runat="server" Text="Back" CssClass="search_btn03" Style="cursor: hand"
                            OnClick="btn_back_Click" meta:resourcekey="btnBack" /></td>
                </tr>
            </table>
        </div>
        <br />
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
