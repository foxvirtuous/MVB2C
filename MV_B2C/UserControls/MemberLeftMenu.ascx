<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="MemberLeftMenu" Codebehind="MemberLeftMenu.ascx.cs" %>
<table width="90%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td width="4" height="4">
            <img src="<%=SaleWebSuffix + "images/index/b_top_l.gif" %>" /></td>
        <td height="4" background="<%=SaleWebSuffix + "images/index/b_top_m.gif" %>">
            <img src="<%=SaleWebSuffix + "images/index/b_top_m.gif" %>" /></td>
        <td width="4">
            <img src="<%=SaleWebSuffix + "images/index/b_top_r.gif" %>" /></td>
    </tr>
    <tr>
        <td width="4" background="<%=SaleWebSuffix + "images/index/b_mid_l.gif" %>">
            <img src="<%=SaleWebSuffix + "images/index/b_mid_l.gif" %>" /></td>
        <td>
            <table width="95%" border="0" align="center" cellpadding="1" cellspacing="1" class="T_table">
                <tr>
                    <td height="20" valign="bottom">
                        <img src="<%=SaleWebSuffix + "images/index/arrow.gif" %>" hspace="2" align="absmiddle" /><span class="head03"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblAccountOverview">Account Overview</asp:Label></span></td>
                </tr><div runat=server visible=true id='divGttglobal'>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp; <asp:linkbutton ID="lbnMyAccount" runat="server" CssClass="d06" OnClick="lbnMyAccount_Click" CausesValidation="False" meta:resourcekey="lblMyAccountInfo">My Account Info</asp:linkbutton></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp; <asp:linkbutton ID="lbnUpdateAccount" runat="server" CssClass="d06" OnClick="lbnUpdateAccount_Click" CausesValidation="False" meta:resourcekey="lblUpdateAccount">Update Account</asp:linkbutton></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;<asp:linkbutton ID="lbnChangePassword" runat="server" CssClass="d06" OnClick="lbnChangePassword_Click" CausesValidation="False" meta:resourcekey="lblChangePassword">Change Password</asp:linkbutton></td>
                </tr></div>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;<asp:linkbutton ID="lbnMyOrder" runat="server" CssClass="d06" OnClick="lbnMyOrder_Click" CausesValidation="False" meta:resourcekey="lblMyOrders">My Orders</asp:linkbutton></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lbnLogOut" runat="server" OnClick="lbnLogOut_Click" CssClass="d06" CausesValidation="False" meta:resourcekey="lblLogOut">Log Out</asp:LinkButton></td>
                </tr>
            </table>
        </td>
        <td width="4" background="<%=SaleWebSuffix + "images/index/b_mid_r.gif" %>">
            <img src="<%=SaleWebSuffix + "images/index/b_mid_r.gif" %>" /></td>
    </tr>
    <tr>
        <td width="4" height="4">
            <img src="<%=SaleWebSuffix + "images/index/b_bot_l.gif" %>" /></td>
        <td height="4" background="<%=SaleWebSuffix + "images/index/b_bot_m.gif" %>">
            <img src="<%=SaleWebSuffix + "images/index/b_bot_m.gif" %>" /></td>
        <td width="4">
            <img src="<%=SaleWebSuffix + "images/index/b_bot_r.gif" %>" /></td>
    </tr>
</table>
