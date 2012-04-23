<%@ Page Language="C#" AutoEventWireup="true" Inherits="SalesLogin" Codebehind="SalesLogin.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare,
        Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
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
<body style="text-align: center;">
    <form id="form1" runat="server"><input id="IsLogin" type="hidden" name="IsLogin" runat="server" />
        <div id="content" style="width: 920px; margin: 0 auto;">
            <uc1:Header ID="Header1" runat="server" />
            <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
                z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
                marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
            </iframe>
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
                                                <img src="../../images/index/arrow.gif" hspace="2" align="absmiddle" /><span class="head03"><asp:Label
                                                    ID="Label2" runat="server" meta:resourcekey="lblAlready">Already
                                                    a Member</asp:Label></span></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="left">
                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblEnterUserAndPassword">Please enter your user name and password.</asp:Label><br>
                                                <span class="t01">
                                                    <asp:Label ID="Label4" runat="server" meta:resourcekey="lblHaveEntered" Visible="false">You may have entered an unknown user name or an incorrect password.</asp:Label></span></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblUserName">User Name</asp:Label>:</td>
                                            <td width="70%" align="left">
                                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblPassword">Password</asp:Label>:
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2" style="color: Red;">
                                                <asp:Label ID="lblMessage" runat="server" Text="You may have entered an unknown user name or an incorrect password."
                                                    Visible="false"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                            <td align="right">
                                                <input type="button" name="btn1" class="search_btn" value="Log in" onclick="aaa()"
                                                    runat="server" meta:resourcekey="btnLogin" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <strong>&nbsp;<asp:Label ID="Label7" runat="server" meta:resourcekey="lblForget">Forget your password?</asp:Label></strong><asp:LinkButton
                                                    ID="hlEmailpassword" runat="server" CssClass="d07" OnClick="hlEmailpassword_Click">
                                                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblHaveEmail">Have it e-mailed to you.</asp:Label></asp:LinkButton></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="50%" align="left" valign="top">
                                    <table width="85%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="4" height="4">
                                                <img src="../../images/index/b_top_l.gif"></td>
                                            <td height="4" background="../../images/index/b_top_m.gif">
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
                                                            <img src="../../images/index/arrow.gif" hspace="2" align="absmiddle" /><span class="head03"><asp:Label
                                                                ID="Label9" runat="server" meta:resourcekey="lblJoin">Join a Membership</asp:Label></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblMsg">If you are not our member , please join the membership here.</asp:Label><br>
                                                            <center>
                                                                <asp:Button ID="btnCreate" runat="server" Text="Join Now" CssClass="search_btn" OnClick="btnCreate_Click"
                                                                    meta:resourcekey="btnJoinNow" />
                                                            </center>
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
        if (document.getElementById("txtPassword") != null){
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
