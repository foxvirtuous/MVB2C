<%@ Page Language="C#" AutoEventWireup="true" Inherits="AgentJoinSucceedForm" Codebehind="AgentJoinSucceedForm.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Header ID="Header1" runat="server" />
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="45" colspan="2" align="left" valign="bottom" class="D_title1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblAgentJoinSucceedForm1">Creat a New Account</asp:Label></td>
                </tr>
            </table>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <br>
                        <br>
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td height="300" align="center" valign="top">
                                    <table width="55%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="4" height="4">
                                                <img src="../images/index/b_top_l.gif" /></td>
                                            <td height="4" background="../images/index/b_top_m.gif">
                                                <img src="../images/index/b_top_m.gif" /></td>
                                            <td width="4">
                                                <img src="../images/index/b_top_r.gif" /></td>
                                        </tr>
                                        <tr>
                                            <td width="4" background="../images/index/b_mid_l.gif">
                                                <img src="../images/index/b_mid_l.gif" /></td>
                                            <td>
                                                <table border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                                                    <tr>
                                                        <td height="80" colspan="2">
                                                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblAgentJoinSucceedForm2">You have created your member account successfully.</asp:Label>
                                                            <asp:HyperLink ID="hlReturn" runat="server" CssClass="d06">
                                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblAgentJoinSucceedForm3">Return to Majestic Vacations.</asp:Label></asp:HyperLink>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="4" background="../images/index/b_mid_r.gif">
                                                <img src="../images/index/b_mid_r.gif" /></td>
                                        </tr>
                                        <tr>
                                            <td width="4" height="4">
                                                <img src="../images/index/b_bot_l.gif" /></td>
                                            <td height="4" background="../images/index/b_bot_m.gif">
                                                <img src="../images/index/b_bot_m.gif" /></td>
                                            <td width="4">
                                                <img src="../images/index/b_bot_r.gif" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <br>
            <br>
            <uc2:Footer ID="Footer1" runat="server" />
        </div>
    </form>
</body>
</html>
