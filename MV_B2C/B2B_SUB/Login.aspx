<%@ Page Language="C#" AutoEventWireup="true" Inherits="Terms.Web.B2B_SUB.Login"
    Codebehind="Login.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />

    <script type="text/javascript" language="javascript">
    function aaa()
    {
        if (document.getElementById('txtUserName') != null && document.getElementById('txtPassword') != null)
        {
            var txtName = document.getElementById('txtUserName').value;
            var txtPWD = document.getElementById('txtPassword').value;
            
            var reg1=new RegExp("<","g"); //创建正则RegExp对象
            var reg2=new RegExp(">","g"); //创建正则RegExp对象
            var reg3=new RegExp(" ","g"); //创建正则RegExp对象
            var reg4=new RegExp("\/","g"); //创建正则RegExp对象
            
            txtName=txtName.replace(reg1,''); 
            txtName=txtName.replace(reg2,''); 
            txtName=txtName.replace(reg3,''); 
            txtName=txtName.replace(reg4,''); 
            
            txtPWD=txtPWD.replace(reg1,''); 
            txtPWD=txtPWD.replace(reg2,''); 
            txtPWD=txtPWD.replace(reg3,''); 
            txtPWD=txtPWD.replace(reg4,''); 

            document.getElementById('txtUserName').value = txtName;
            document.getElementById('txtPassword').value = txtPWD;
            
            document.getElementById("IsLogin").value ="Longin";
            
            document.getElementById("form1").submit();
        }
    }
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <input id="IsLogin" type="hidden" name="IsLogin" runat="server" />
        <div>
            <uc1:Header ID="Header1" runat="server" />
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <%--<tr>
                    <td height="45" colspan="2" align="left" valign="bottom" class="D_title1">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                            ID="lblLoginTitle" runat="server" meta:resourcekey="lblLoginTitle">Travel Agents: Log in and Register</asp:Label></td>
                </tr>--%>
                <tr>
                    <td>
                        <br />
                        <br />
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <%--<td width="50%" align="right" valign="top">
                                    <table cellspacing="1" cellpadding="3" width="95%" border="0" class="T_table">
                                        <tr>
                                            <td colspan="2">
                                                <img src="../images/index/arrow.gif" hspace="2" align="absmiddle" /><span class="head03">
                                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblLogin">Login</asp:Label></span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblLoginTitle1">Already registered with Majestic Vacations? Enter your user name and password.</asp:Label>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblLoginEmail">Email:</asp:Label>
                                            </td>
                                            <td width="70%" align="left">
                                                <asp:TextBox ID="txtUserName" runat="server" name="txtUserName" Width="180px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblLoginPassword">Password:</asp:Label>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPassword" runat="server" name="txtPassword" TextMode="Password"
                                                    Width="180px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2" style="color: Red;">
                                                <asp:Label ID="lblMessage" runat="server" Text="You may have entered an unknown user name or an incorrect password."
                                                    Visible="false"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;<input id="Button1" type="button" name="btn1" class="search_btn" value="Log in"
                                                    onclick="aaa()" runat="server" meta:resourcekey="lblLoginButton" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <strong>&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblLoginTitle3">Forget your password?</asp:Label></strong><asp:LinkButton
                                                    ID="hlEmailpassword" runat="server" CssClass="d07" OnClick="hlEmailpassword_Click"
                                                    meta:resourcekey="lblEmailpassword">
                                                    Have it e-mailed to you.</asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </td>--%>
                                <td width="50%" align="left" valign="top">
                                    <table width="85%" border="0" cellspacing="0" cellpadding="0">
                                        <%--<tr>
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
                                                            <img src="../images/index/arrow.gif" hspace="2" align="absmiddle" /><span class="head03"><asp:Label
                                                                ID="Label7" runat="server" meta:resourcekey="lblLoginCreateProfile">Create a Profile</asp:Label></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label8" runat="server" meta:resourcekey="lblLoginTitle2">If you do not currently have a profile you may create one here.</asp:Label>
                                                            <br />
                                                            <center>
                                                                <asp:Button ID="btnCreate" runat="server" Text="Join Now" class="search_btn" OnClick="btnCreate_Click"
                                                                    meta:resourcekey="lblLoginJoin" /></center>
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
                                        </tr>--%>
                                        <tr>
                                            <td height="45" colspan="3" align=left valign="bottom">
                                                <span style="color: Red; font-size: 12px">We are moving the Travel Agent login from
                                                    Majestic website to www.gttglobal.com website. Pls call (888)-288-7528 x 5026 (Frank)
                                                    or x 6268 (Christine) for assistance.</span></td>
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

        <script type="text/javascript">

    if (document.getElementById("txtPassword") != null){
        document.getElementById("txtPassword").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13)
             {
                document.body.focus();
                document.getElementById("btnLogin").click();
             }
        }}
        if (document.getElementById("txtUserName") != null){
        document.getElementById("txtUserName").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13)
             {
                document.body.focus();
                document.getElementById("btnLogin").click();
             }
        }}
 
        </script>

    </form>
</body>
</html>
