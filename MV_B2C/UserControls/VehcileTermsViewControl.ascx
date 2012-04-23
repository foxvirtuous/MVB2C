<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileTermsViewControl.ascx.cs"
    Inherits="VehcileTermsViewControl" %>
<table width="100%" border="0" cellpadding="5" cellspacing="5">
    <tr>
        <td width="32%" align="left" valign="top" style="font-size: 11px; font-family: Verdana, Arial, Helvetica, sans-serif">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td bgcolor="#E9E9E9">
                        <table align="center" border="0" cellpadding="0" cellspacing="5" width="95%">
                            <tr align="left" valign="top">
                                <td width="65%" height="20" align="left" style="border-bottom: solid #cccccc 1px">
                                    <img src="../../../images/v2/arrow2.gif" hspace="5" align="absmiddle" /><a href="/"
                                        class="d10"><asp:Label ID="Label5" runat="server" Text="Payment"></asp:Label></a></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
        <td align="left" valign="top" style="font-size: 11px; font-family: Verdana, Arial, Helvetica, sans-serif">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <b>
                            <asp:Label ID="Label6" runat="server" Text="Payment"></asp:Label></b></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPayment" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
