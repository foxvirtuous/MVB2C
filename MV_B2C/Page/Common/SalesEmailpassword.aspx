<%@ Page Language="C#" AutoEventWireup="true" Inherits="SalesEmailpassword" Codebehind="SalesEmailpassword.aspx.cs" %>

<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" colspan="2" align="left" valign="bottom" class="D_title">
                    &nbsp;&nbsp;<asp:Label ID="lblCreateAccount" runat="server" meta:resourcekey="lblForgotPassword">Forgot Your User Name or Password?</asp:Label></td>
            </tr>
            <tr>
                <td>
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td align="center" valign="top">
                                <table width="75%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="4" height="4">
                                            <img src="../../images/index/b_top_l.gif"></td>
                                        <td height="4" background="~/images/index/b_top_m.gif">
                                            <img src="../../images/index/b_top_m.gif"></td>
                                        <td width="4">
                                            <img src="../../images/index/b_top_r.gif"></td>
                                    </tr>
                                    <tr>
                                        <td width="4" background="../../images/index/b_mid_l.gif">
                                            <img src="../../images/index/b_mid_l.gif"></td>
                                        <td>
                                            <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                                                <tr>
                                                    <td width="100%">
                                                        <img src="../../images/index/arrow.gif" hspace="2" align="absmiddle" /><span class="head03">
                                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblEnterEmail">Enter the e-mail address</asp:Label></span></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblMsg">If you forgot your user name or password, enter the e-mail address that is associated
                                                        with your account below...</asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblEmailAddress">Your E-mail address</asp:Label>:<uc3:MustInputTextBox ID="txtEmail" runat="server" IsEmailStyle="true" ValidationGroup="SalesEmailpassword" />
                                                        <center>                                                            
                                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="search_btn" OnClick="btnSubmit_Click" ValidationGroup="SalesEmailpassword" meta:resourcekey="btnSubmit" /></center>
                                                            <center>
                                                                <asp:Label ID="lblErrorMassage" runat="server" Visible="False" ForeColor="Red"></asp:Label></center>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="4" background="../../images/index/b_mid_r.gif">
                                            <img src="../../images/index/b_mid_r.gif"></td>
                                    </tr>
                                    <tr>
                                        <td width="4" height="4">
                                            <img src="../../images/index/b_bot_l.gif"></td>
                                        <td height="4" background="../../images/index/b_bot_m.gif">
                                            <img src="../../images/index/b_bot_m.gif"></td>
                                        <td width="4">
                                            <img src="../../images/index/b_bot_r.gif"></td>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
