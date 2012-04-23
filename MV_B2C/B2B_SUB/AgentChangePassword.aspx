<%@ Page Language="C#" AutoEventWireup="true" Inherits="AgentChangePassword" Codebehind="AgentChangePassword.aspx.cs" %>

<%@ Register Src="../UserControls/AgentLeftMenu.ascx" TagName="AgentLeftMenu" TagPrefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <style>
    .modalBackground 
    {
    background-color:Gray;
    filter:alpha(opacity=70);
    opacity:0.7;
    }
</style>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <uc1:Header ID="Header1" runat="server" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" align="left" valign="bottom" class="D_title">
                    &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblAgentChangePassword1" >Membership: Change Password</asp:Label></td>
            </tr>
        </table>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr><td  width="20%" align="center" valign="top"><uc3:AgentLeftMenu ID="AgentLeftMenu1" runat="server" />
                        </td>
                            <td width="80%" align="left" valign="top">
                                <table cellspacing="1" cellpadding="3" width="100%" border="0" class="T_table">
                                    <tr>
                                        <td><asp:Label ID="Label2" runat="server" meta:resourcekey="lblAgentChangePassword2" >The password must be between 6 and 30 characters long.</asp:Label>
                                            <br />
                                            <br />
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" class="reg">
                                                <tr>
                                                    <td width="100%" height="14" colspan="2" background="../images/index/dot01.gif">
                                                        <img src="../images/index/dot01.gif"></td>
                                                </tr>
                                            </table>
                                            <table width="100%" border="0" cellpadding="3" cellspacing="1">
                                                <tr>
                                                    <td width="23%">
                                                        <b><asp:Label ID="Label3" runat="server" meta:resourcekey="lblAgentChangePassword3" >User Name:</asp:Label></b></td>
                                                    <td>
                                                        <b>
                                                            <asp:Label ID="lblUserName" runat="server"></asp:Label></b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><asp:Label ID="Label4" runat="server" meta:resourcekey="lblAgentChangePassword4" >Old Password:</asp:Label>
                                                        </td>
                                                    <td>
                                                        <input id="txbOldPwd" name="txbOldPwd" type="password" runat="server" maxlength="30" />
                                                        <font color="red"><span id="lb_OldPwdMsg" runat="server" visible="false"></span></font>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txbOldPwd"
                                                            runat="server" ErrorMessage="Please enter Old Password"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><asp:Label ID="Label5" runat="server" meta:resourcekey="lblAgentChangePassword5" >New Password:</asp:Label>
                                                        </td>
                                                    <td>
                                                        <input id="txbNewPwd" name="txbNewPwd" type="password" runat="server" maxlength="30" />
                                                        <span class="t01"><asp:Label ID="Label7" runat="server" meta:resourcekey="lblAgentChangePassword8" >(6-30 characters)</asp:Label></span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td><asp:Label ID="Label6" runat="server" meta:resourcekey="lblAgentChangePassword6" >Type New Password Again:</asp:Label>
                                                        </td>
                                                    <td>
                                                        <input id="txbNewPwdAgain" name="txbNewPwdAgain" type="password" runat="server" maxlength="30" />
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txbNewPwdAgain"
                                                            runat="server" ErrorMessage="Please enter Type New Password again "></asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txbNewPwdAgain" ControlToCompare="txbNewPwd"
                                                            runat="server" Display="Dynamic" ErrorMessage="Please enter the same password in both the password boxes"></asp:CompareValidator></td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        &nbsp;</td>
                                                    <td align="left">
                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="search_btn" OnClick="btnUpdate_Click" meta:resourcekey="lblAgentChangePassword7" />
                                                        <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" TargetControlID="btnUpdate"
                                                            ConfirmOnFormSubmit="true" DisplayModalPopupID="TermsModel" />
                                                        <ajaxToolkit:ModalPopupExtender ID="TermsModel" runat="server" TargetControlID="btnUpdate"
                                                            PopupControlID="pnlTerms" BackgroundCssClass="modalBackground" OkControlID="ButtonOk"
                                                            CancelControlID="btnCloseTerms" DropShadow="false"  />
                                                    </td>
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
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
        <asp:Panel ID="pnlTerms" runat="server" Style="display: none; background-color: White;
            border-width: 2px; border-color: Black; border-style: solid; padding: 20px;">
            <div>
                Are you sure you want to change your Password?
            </div>
            <br />
            <div style="text-align: center">
                <asp:Button ID="ButtonOk" runat="server" Text="Yes" Width="36px" />
                <asp:Button ID="btnCloseTerms" runat="server" Text="No" Width="36px" /></div>
        </asp:Panel>
    </form>
</body>
</html>
