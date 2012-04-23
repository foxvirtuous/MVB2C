<%@ Page Language="C#" AutoEventWireup="true" Inherits="Forget" Codebehind="Forget.aspx.cs" %>

<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="../css/style_new.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <uc1:Header ID="Header1" runat="server" />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="45" colspan="2" align="left" valign="bottom" class="D_title1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblForget1">Forgot Your User Name or Password?</asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <br />
                        <br />
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td align="center" valign="top">
                                    <table width="75%" border="0" cellspacing="0" cellpadding="0">
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
                                                <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                                                    <tr>
                                                        <td width="100%">
                                                            <img src="../images/index/arrow.gif" hspace="2" align="absmiddle" /><span class="head03">
                                                                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblForget2">Enter the e-mail address</asp:Label></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblForget3">If you forgot your user name or password, enter the e-mail address that is associated with your account below...</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblForget4">Your E-mail address:</asp:Label>
                                                            <uc3:MustInputTextBox ID="txtEmail" runat="server" IsEmailStyle="true" ValidationGroup="SalesEmailpassword"
                                                                Width="150px" />
                                                            <center>
                                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="search_btn" OnClick="btnSubmit_Click"
                                                                    ValidationGroup="SalesEmailpassword" meta:resourcekey="lblForget5" /></center>
                                                            <center>
                                                                <asp:Label ID="lblErrorMassage" runat="server" Visible="False" ForeColor="Red"></asp:Label></center>
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
                                    <br />
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
