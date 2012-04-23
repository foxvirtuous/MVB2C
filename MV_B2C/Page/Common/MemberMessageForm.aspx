<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="MemberMessageForm" Codebehind="MemberMessageForm.aspx.cs" %>

<%@ Register Src="../../UserControls/MemberLeftMenu.ascx" TagName="MemberLeftMenu"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" align="left" valign="bottom" class="D_title">
                    &nbsp;&nbsp;<asp:Label ID="lblInfo" runat="server" meta:resourcekey="lblInfo" >Membership: Operation Success</asp:Label></td>
            </tr>
        </table>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" valign="top">
                                <uc3:MemberLeftMenu ID="MemberLeftMenu1" runat="server" />
                                &nbsp;</td>
                            <td width="80%" align="left" valign="top">
                               <table width="65%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="4" style="width: 4px">
                                            <img src="../../images/index/b_top_l.gif" /></td>
                                        <td height="4" background="../../images/index/b_top_m.gif">
                                            <img src="../../images/index/b_top_m.gif" /></td>
                                        <td width="4">
                                            <img src="../../images/index/b_top_r.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td background="../../images/index/b_mid_l.gif" style="width: 4px">
                                            <img src="../../images/index/b_mid_l.gif" /></td>
                                        <td>
                                            <table border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                                                <tr>
                                                    <td height="80" colspan="2">
                                                      <asp:Label ID="lblMessageInfo" runat="server"></asp:Label> <a href="../../Index.aspx" class="d06"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblReturnTo" >Return to Majestic Vacations</asp:Label>.</a></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="4" background="../../images/index/b_mid_r.gif">
                                            <img src="../../images/index/b_mid_r.gif" /></td>
                                    </tr>
                                    <tr>
                                        <td height="4" style="width: 4px">
                                            <img src="../../images/index/b_bot_l.gif" /></td>
                                        <td height="4" background="../../images/index/b_bot_m.gif">
                                            <img src="../../images/index/b_bot_m.gif" /></td>
                                        <td width="4">
                                            <img src="../../images/index/b_bot_r.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
