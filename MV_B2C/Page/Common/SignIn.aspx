<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="Terms.Web.Page.Common.SignIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="<%=SecureUrlSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
</head>
<body style=" text-align:center;">
    <form id="form1" runat="server">
        <div id="content" style="width:920px; margin:0 auto;">
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="45" colspan="2" align="left" valign="bottom" class="D_title">
                        &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblMembership">Membership: Log in and Register</asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <br>
                        <br>
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" align="right" valign="top">
                                    <table cellspacing="1" cellpadding="3" width="91%" border="0" class="T_table">
                                        <tr>
                                            <td colspan="2" align="left">
                                                <img src="../../images/index/arrow.gif" hspace="2" align="absmiddle" /><span class="head03"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblAlready">Already
                                                    a Member</asp:Label></span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblEnterUserAndPassword">Please enter your user name and password.</asp:Label><br>
                                                <span class="t01"><asp:Label ID="Label4" runat="server" meta:resourcekey="lblHaveEntered" Visible="false">You may have entered an unknown user name or an incorrect password.</asp:Label></span></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblUserName">User Name</asp:Label>:</td>
                                            <td width="70%" align="left"><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblPassword">Password</asp:Label>:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="right">
                                                <asp:Button ID="btnLogin" runat="server" Text="Log in" CssClass="search_btn" OnClick="btnLogin_Click" meta:resourcekey="btnLogin" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <strong>&nbsp;</strong></td>
                                        </tr>
                                    </table>
                                </td>
                               
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
