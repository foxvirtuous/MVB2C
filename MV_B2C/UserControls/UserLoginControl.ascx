<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLoginControl.ascx.cs" Inherits="UserLoginControl" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                        <span class="head06"><asp:Label ID="lblMemberIn" runat="server" meta:resourcekey="lblMemberIn">Member Log In</asp:Label></span></td>
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
            <table width="100%" border="1" cellpadding="8" cellspacing="0" class="T_step02">
                <tr class="R_stepo">
                    <td valign="top">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="7">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                        <tr class="R_stepw">
                                            <td>
                                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr valign="top">
                                                        <td width="50%">
                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                                                                <tr align="left" valign="top">
                                                                    <td>
                                                                        <font class="t06"><asp:Label ID="lblAlreadyMember" runat="server" meta:resourcekey="lblAlreadyMember">Already a member</asp:Label></font></td>
                                                                </tr>
                                                            </table>
                                                            <table width="95%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblLogIn" runat="server" meta:resourcekey="lblLogIn">Log in name ( Your Email address )</asp:Label>:<br/>
                                                                        <asp:TextBox ID="txtUserName" runat="server" Width="200"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left">
                                                                        <asp:Label ID="lblPassword" runat="server" meta:resourcekey="lblPassword">Password</asp:Label>:
                                                                        <br/>
                                                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                                        <asp:LinkButton ID="hlEmailpassword" runat="server" OnClick="hlEmailpassword_Click"><asp:Label ID="lblFoget" runat="server" meta:resourcekey="lblFoget">Foget your password?</asp:Label></asp:LinkButton>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="30" align="center" valign="bottom">
                                                                        <asp:Button ID="btnLogin" runat="server" meta:resourcekey="btn_Login" Text="Sign In" OnClick="btnLogin_Click"
                                                                            CssClass="search_btn02" Style="cursor: hand" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td bgcolor="#CCCCCC" width="1">
                                                        </td>
                                                        <td>
                                                            <table align="center" border="0" cellpadding="0" cellspacing="0" width="95%">
                                                                <tr align="left" valign="top">
                                                                    <td>
                                                                        <font class="t06"><asp:Label ID="lblNotMember" runat="server" meta:resourcekey="lblNotMember">Not yet a member?</asp:Label></font></td>
                                                                </tr>
                                                                <tr align="left" valign="top">
                                                                    <td>
                                                                        <asp:Label ID="lblIfA" runat="server" meta:resourcekey="lblIfA">If you are not yet a Majestic Vacations member, please click the button below.</asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr align="left" valign="top">
                                                                    <td height="30" align="center" valign="bottom">
                                                                        <asp:Button ID="hlregister" runat="server" CssClass="search_btn04" Style="cursor: hand"
                                                                            Text="Create a New Account" meta:resourcekey="btn_Create"  OnClick="hlregister_Click" /></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="3">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
