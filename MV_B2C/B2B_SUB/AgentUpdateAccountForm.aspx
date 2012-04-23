<%@ Page Language="C#" AutoEventWireup="true" Inherits="AgentUpdateAccountForm" Codebehind="AgentUpdateAccountForm.aspx.cs" %>

<%@ Register Src="../UserControls/AgentLeftMenu.ascx" TagName="AgentLeftMenu" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations - The best value to Asia from USA. Super value Airfare, All
        Wordwild Airfare, Cheap Airfare, Hotels, Air+Hotel package, Cheap Tours, Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <style>
    .modalBackground 
    {
    background-color:Gray;
    filter:alpha(opacity=70);
    opacity:0.7;
    }
</style>
</head>
<body>
    <form id="form1" runat="server">
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" colspan="2" align="left" valign="bottom" class="D_title">
                    &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblAgentMyAccountForm1">Membership: Update Account</asp:Label></td>
            </tr>
            <tr>
                <td>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td width="80%" align="left" valign="top">
                                <table cellspacing="1" cellpadding="3" width="100%" border="0" class="T_table">
                                    <tr>
                                        <td width="20%" align="center" valign="top">
                                            <uc3:AgentLeftMenu ID="AgentLeftMenu1" runat="server" />
                                        </td>
                                        <td>
                                            <table width="80%" border="0" cellpadding="3" cellspacing="0" class="info">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                            <tr>
                                                                <td colspan="2" class="name" style="height: 25px">
                                                                    <span class="head01"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblAgentMyAccountForm2">Member Information</asp:Label></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label3" runat="server" meta:resourcekey="lblAgentMyAccountForm3">First Name:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter First name exactly as it appears on ID card or passport."
                                                                        ControlToValidate="txtFirst" Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td><asp:Label ID="Label4" runat="server" meta:resourcekey="lblAgentMyAccountForm4">Middle Name:</asp:Label>
                                                                    
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMiddle" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label5" runat="server" meta:resourcekey="lblAgentMyAccountForm5">Last Name:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtLast" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLast" ErrorMessage="Please enter Last name exactly as it appears on ID card or passport."
                                                                        Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label6" runat="server" meta:resourcekey="lblAgentMyAccountForm6">Phone Number (daytime):</asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPhoneDay" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhoneDay"
                                                                        ErrorMessage="Please enter phone(daytime) exactly as it appears on ID card or passport."
                                                                        Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label7" runat="server" meta:resourcekey="lblAgentMyAccountForm7">Street Address:</asp:Label></td>
                                                                <td>
                                                                    <asp:TextBox ID="txtStreet" runat="server" Width="80%"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStreet"
                                                                        ErrorMessage="Please enter your address to receive our travel packs exactly as it appears on ID card or passport."
                                                                        Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 49px">
                                                                    <span class="redlab">*</span><asp:Label ID="Label8" runat="server" meta:resourcekey="lblAgentMyAccountForm8">City:</asp:Label>
                                                                </td>
                                                                <td style="height: 49px">
                                                                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCity"
                                                                        ErrorMessage="Please enter City exactly as it appears on ID card or passport."
                                                                        Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label9" runat="server" meta:resourcekey="lblAgentMyAccountForm9">Country or Area:</asp:Label></td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                    </asp:DropDownList>&nbsp;
                                                                    <asp:DropDownList ID="ddlState" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label10" runat="server" meta:resourcekey="lblAgentMyAccountForm10">Zip/Postal Code:</asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                                                                        ErrorMessage="Please enter Zip/Postal Code exactly as it appears on ID card or passport."
                                                                        Display="Dynamic"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="aspbtnUpdate" runat="server" Text="Update" CssClass="search_btn" meta:resourcekey="lblAgentMyAccountForm11"
                                                OnClick="aspbtnUpdate_Click" />
                                            <ajaxToolkit:ConfirmButtonExtender ID="cbe" runat="server" TargetControlID="aspbtnUpdate"
                                                ConfirmText="Are you sure you want to click this?" ConfirmOnFormSubmit="true"
                                                DisplayModalPopupID="TermsModel" />
                                            <ajaxToolkit:ModalPopupExtender ID="TermsModel" runat="server" TargetControlID="aspbtnUpdate"
                                                PopupControlID="pnlTerms" BackgroundCssClass="modalBackground" OkControlID="ButtonOk"
                                                CancelControlID="btnCloseTerms" DropShadow="false" />
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
                Are you sure you want to update your account info?
            </div>
            <br />
            <div style="text-align: center">
                <asp:Button ID="ButtonOk" runat="server" Text="Yes" Width="36px" />
                <asp:Button ID="btnCloseTerms" runat="server" Text="No" Width="36px" /></div>
        </asp:Panel>
    </form>
</body>
</html>
