<%@ Page Language="C#" AutoEventWireup="true" Codebehind="IndexForFlight.aspx.cs"
    Inherits="IndexForFlight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>he best value to Asia from USA. Super value Airfare, All Wordwild Airfare, Cheap
        Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="MainScriptManager" runat="server" ScriptMode="release" LoadScriptsBeforeUI="false" />
        <div style="width: 920px; margin: 0 auto; text-align: center;">
            <div class="IBE_confimMemberLogIn_Bg_index" style="float: none; margin:0 auto; margin-top: 15px;">
                <div class="IBE_confimMemberLogIn_signIn_index" style="margin-bottom: 10px; padding-bottom: 10px;
                    border-bottom: 1px dotted #ccc;">
                    <ul>
                        <li><span class="IBE_confimReviewOrder_Content_font1_index">Registered User</span> (View
                            Full Results)</li>
                        <li>User name:&nbsp;<asp:TextBox ID="txtUserName" runat="server" Style="width: 150px;
                            background-color: rgb(255, 255, 160); height: 14px;" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtUserName" ValidationGroup="login"></asp:RequiredFieldValidator>
                        </li>
                        <li>Password: &nbsp;&nbsp;<asp:TextBox ID="txtPassword" TextMode="Password" runat="server"
                            Style="width: 150px; background-color: rgb(255, 255, 160); height: 14px;" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Required"
                                ControlToValidate="txtPassword" ValidationGroup="login"></asp:RequiredFieldValidator>
                            <asp:LinkButton ID="hlEmailpassword" runat="server" OnClick="hlEmailpassword_Click1">
                                <asp:Label ID="lblFoget" runat="server" meta:resourcekey="lblFoget">Forget your password?</asp:Label></asp:LinkButton></li>
                        <li>
                            <asp:Label ForeColor="red" Font-Bold="true" ID="lblErrorMsg" runat="server" Visible="false"></asp:Label>
                        </li>
                        <li style="margin-top: 10px; text-align: center;">
                            <asp:Button ID="btnLogin" runat="server" Text="Login & Search" CssClass="search_btn"
                                Style="width: 130px; cursor: pointer" ValidationGroup="login" OnClick="btnLogin_Click1" />
                        </li>
                    </ul>
                </div>
                <div class="IBE_confimMemberLogIn_signIn_index">
                    <ul>
                        <li><span class="IBE_confimReviewOrder_Content_font1_index">Non-Registered User</span>
                            (View Limited Results)</li>
                        <li style="line-height: 16px;">If you are not yet a member, please click the button
                            below to register or continue search.</li>
                        <li style="margin-top: 10px; vertical-align: bottom;">
                            <asp:Button ID="btnRegister" runat="server" Text="Register Now"
                                CssClass="search_btn left" Style="width: 120px; cursor: pointer" OnClick="btnRegister_Click1" />
                            <asp:Button ID="btnContinue" runat="server" Text="Continue Search" Width="160px"
                                CssClass="search_btn right" Style="cursor: pointer"
                                ValidationGroup="SearchAir" OnClick="btnContinue_Click1" />
                            <asp:Button ID="btnHiddenContinue" runat="server" Style="display: none" />
                        </li>
                    </ul>
                </div>
                <div style="height:1px; overflow:hidden; clear:both;"></div>
            </div>
            <div style="height:1px; overflow:hidden; clear:both;"></div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
