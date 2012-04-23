<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserLogin" Codebehind="UserLogin.ascx.cs" %>
<%@ Register Src="MustInputTextBox.ascx" TagName="MustInputTextBox" TagPrefix="uc1" %>
<link href="../css/style2.css" rel="stylesheet" type="text/css" />
<table class="booklogin">
    <tr>
        <td style="text-align: right" width="28%">
            <asp:Label ID="Label11" runat="server" meta:resourcekey="lblUserID">User ID</asp:Label>:</td>
        <td width="38%">
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
            <td width="34%"><asp:LinkButton ID="hlregister" runat="server" OnClick="hlregister_Click" meta:resourcekey="lkCreate" >Create a New Account</asp:LinkButton></td>
    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblPassWord">PassWord</asp:Label>:</td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            <td><asp:LinkButton ID="hlEmailpassword" runat="server" OnClick="hlEmailpassword_Click" meta:resourcekey="lkFogetPassword">Foget Password</asp:LinkButton></td>
    </tr>
    <tr>
    <td colspan="3" align="center"><asp:Button ID="btnLogin" runat="server" Text="Sign In" OnClick="btnLogin_Click" CssClass="btn_inbg" meta:resourcekey="btnSign"/></td></tr>
</table>


    