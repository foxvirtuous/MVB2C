<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PKGUserLogin.ascx.cs" Inherits="Terms.Web.UserControls.PKGUserLogin" %>
<div class="IBE_package_step">
    <div class="IBE_package_step_T_line01 left">
        &gt;</div>
    <div class="left" style="width:90%">
        &nbsp;<asp:Label ID="lblMemberIn" runat="server" meta:resourcekey="lblMemberIn">Member Log In</asp:Label></div>
</div>
<div class="IBE_confimMemberLogIn">
    <div class="IBE_confimMemberLogIn_Bg">
        <div class="IBE_confimMemberLogIn_signIn">
            <ul>
                <li class="IBE_confimReviewOrder_Content_font1">
                    <asp:Label ID="lblAlreadyMember" runat="server" meta:resourcekey="lblAlreadyMember">Already a member</asp:Label></li>
                <li>
                    <asp:Label ID="lblLogIn" runat="server" meta:resourcekey="lblLogIn">Log in name ( Your Email address )</asp:Label>:</li>
                <li>
                    <asp:TextBox ID="txtUserName" runat="server" Width="200"></asp:TextBox></li>
                <li>
                    <asp:Label ID="lblPassword" runat="server" meta:resourcekey="lblPassword">Password</asp:Label>:</li>
                <li>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200"></asp:TextBox>
                    <asp:LinkButton ID="hlEmailpassword" runat="server" OnClick="hlEmailpassword_Click"
                        CssClass="IBE_package_List_dl_d09">
                        <asp:Label ID="lblFoget" runat="server" meta:resourcekey="lblFoget">Foget your password?</asp:Label></asp:LinkButton>
                </li>
                <li style="margin-top: 10px; text-align: center;">
                    <asp:Button ID="btnLogin" runat="server" meta:resourcekey="btn_Login" Text="Sign In"
                        OnClick="btnLogin_Click" CssClass="IBE_search_btn02" Style="cursor: hand" />
                </li>
            </ul>
        </div>
        <div class="IBE_confimMemberLogIn_signIn" style="border: none;">
            <ul>
                <li class="IBE_confimReviewOrder_Content_font1">
                    <asp:Label ID="lblNotMember" runat="server" meta:resourcekey="lblNotMember">Not yet a member?</asp:Label></li>
                <li>
                    <asp:Label ID="lblIfA" runat="server" meta:resourcekey="lblIfA">If you are not yet a Majestic Vacations member, please click the button below.</asp:Label></li>
                <li style="margin-top: 10px; text-align: center;">
                    <asp:Button ID="hlregister" runat="server" CssClass="IBE_search_btn04" Style="cursor: hand"
                        Text="Create a New Account" meta:resourcekey="btn_Create" OnClick="hlregister_Click" />
                </li>
            </ul>
        </div>
    </div>
</div>
