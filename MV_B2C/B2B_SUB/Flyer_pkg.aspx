<%@ Page Language="C#" AutoEventWireup="true" Inherits="Flyerpkg" Codebehind="Flyer_pkg.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="../css/style_new.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Header ID="Header1" runat="server" />
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="45" colspan="2" align="left" valign="bottom" class="D_title1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlyerpkg1">Air + Hotel Flyer Download</asp:Label>
                        </td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td align="center" valign="top" style="height: 551px">
                                    <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            <asp:GridView ID="gridFlyer" runat="server" AutoGenerateColumns="False" DataKeyNames="FlyerID"
                                                                Width="100%" border="0" CellPadding="3" CellSpacing="1" CssClass="T_order">
                                                                <HeaderStyle CssClass="R_order" Height="25px" />
                                                                <RowStyle CssClass="R_order01" Height="25px" />
                                                                <AlternatingRowStyle CssClass="R_order02" Height="25px" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Flyer Name" meta:resourcekey="lblFlyerpkg2">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFlyerName" runat="server" Text=''></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Airline Class" meta:resourcekey="lblFlyerpkg3">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFlyerAirClass" runat="server" Text=''></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Validity" meta:resourcekey="lblFlyerpkg4">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDate" runat="server" Text=''></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="20%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Market" meta:resourcekey="lblFlyerpkg5">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblFlyerRegion" runat="server" Text=''></asp:Label>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle Width="10%" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Download" meta:resourcekey="lblFlyerpkg6">
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="hlDownload" runat="server">Click Here</asp:HyperLink>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <%-- <table width="100%" border="0" cellpadding="3" cellspacing="1" class="T_order">
                                                                <tr align="center" class="R_order">
                                                                    <td height="25">
                                                                        Destination</td>
                                                                    <td width="10%">
                                                                        Airline Class</td>
                                                                    <td width="20%">
                                                                        Validity</td>
                                                                    <td width="10%">
                                                                        Market</td>
                                                                    <td width="10%">
                                                                        Download</td>
                                                                </tr>
                                                                <tr align="center" class="R_order01">
                                                                    <td height="25" align="left">
                                                                        2008OCT TAIPEI PKG PROMOTION-UA</td>
                                                                    <td>
                                                                        <img src="../images/airline/oz.gif" vspace="3" align="absmiddle">
                                                                        L</td>
                                                                    <td>
                                                                        10/01/2008 - 10/16/2008</td>
                                                                    <td>
                                                                        ASIA</td>
                                                                    <td>
                                                                        <a href="#" class="d07">Click Here</a></td>
                                                                </tr>
                                                                <tr class="R_order02">
                                                                    <td height="25">
                                                                        Asia</td>
                                                                    <td align="center">
                                                                        <img src="../images/airline/sq.gif" vspace="3" align="absmiddle">
                                                                        V</td>
                                                                    <td align="center">
                                                                        7/22/2008 - 12/31/2008</td>
                                                                    <td align="center">
                                                                        ASIA</td>
                                                                    <td align="center">
                                                                        <a href="#" class="d07">Click Here</a></td>
                                                                </tr>
                                                            </table>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="T_order">
                                        <tr class="R_order01">
                                            <td height="30" align="right">
                                                <a href="Index.aspx" class="d07"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblFlyerpkg7">Return to previous</asp:Label></a></td>
                                        </tr>
                                    </table>
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
