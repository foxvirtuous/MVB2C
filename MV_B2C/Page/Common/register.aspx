<%@ Page Language="C#" AutoEventWireup="true" Inherits="register" Codebehind="register.aspx.cs" %>

<%--<%@ Register Src="../UserConrols/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>--%>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/MoneyTextBox.ascx" TagName="MoneyTextBox" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare,
        Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" align="left" valign="bottom" class="D_title">
                    &nbsp;&nbsp;<asp:Label ID="lblCreateAccount" runat="server" meta:resourcekey="lblCreateAccount">Create Your Member Account</asp:Label>
                </td>
            </tr>
        </table>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <br>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td align="center" valign="top">
                                <table width="85%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="4" height="4">
                                            <img src="../../images/index/b_top_l.gif"></td>
                                        <td height="4" background="../../images/index/b_top_m.gif">
                                            <img src="../../images/index/b_top_m.gif"></td>
                                        <td width="4">
                                            <img src="../../images/index/b_top_r.gif"></td>
                                    </tr>
                                    <tr>
                                        <td width="4" background="../../images/index/b_mid_l.gif" style="height: 621px">
                                            <img src="../../images/index/b_mid_l.gif"></td>
                                        <td style="height: 621px">
                                            <table width="98%" border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                                                <tr>
                                                    <td>
                                                        <div style="margin: 0 auto; text-align: left; font-size: 12px;">
                                                            <h1>
                                                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblMemberRegistration">Member Registration</asp:Label>
                                                            </h1>
                                                            <div class="register_ab">
                                                                <font class="t01">
                                                                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblRemark">You will need to create an account to complete your request. It's fast and free.<br />
                                                                Here are just a few of the benefits you receive as a Majestic Vacations member</asp:Label>:
                                                                    <ul>
                                                                        <li>
                                                                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblLi1">Get Low Fare Alerts and other special travel offers.</asp:Label>
                                                                        </li>
                                                                        <li>
                                                                            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblLi2">Enjoy superior customer Care 24/7.</asp:Label>
                                                                        </li>
                                                                    </ul>
                                                                </font>
                                                            </div>
                                                            <span class="redlab">*</span> =
                                                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblRequiredfield">required field</asp:Label>
                                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" style="border: solid 1px #999;
                                                                font-size: 12px; font-family: Arial, Helvetica, sans-serif; padding: 4px;">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                                            <tr>
                                                                                <td colspan="2" class="head03">
                                                                                    <img src="../../images/index/arrow.gif" hspace="2" align="absmiddle" />
                                                                                    <asp:Label ID="Label6" runat="server" meta:resourcekey="lblMemberEnter">Please Enter Your Member Information</asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="30%">
                                                                                    <span class="t01">*</span><asp:Label ID="Label7" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
                                                                                <td width="70%">
                                                                                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                                                                                        <asp:ListItem Selected="True" Value="0" meta:resourcekey="item1">Mr</asp:ListItem>
                                                                                        <asp:ListItem Value="1" meta:resourcekey="item2">Mrs</asp:ListItem>
                                                                                        <asp:ListItem Value="2" meta:resourcekey="item3">Ms</asp:ListItem>
                                                                                    </asp:RadioButtonList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 49px">
                                                                                    <span class="t01">*</span><asp:Label ID="Label8" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                                                                                </td>
                                                                                <td style="height: 49px">
                                                                                    <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter First name exactly as it appears on ID card or passport."
                                                                                        ControlToValidate="txtFirst" ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblFirstErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label9" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtMiddle" runat="server"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label10" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtLast" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLast" ErrorMessage="Please enter Last name exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" meta:resourcekey="lblLastErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 29px">
                                                                                    <span class="t01">*</span><asp:Label ID="Label11" runat="server" meta:resourcekey="lblEmailAddress">Email Address (Login Name)</asp:Label>:
                                                                                </td>
                                                                                <td style="height: 29px">
                                                                                    <uc2:MustInputTextBox ID="txtEmail" runat="server" IsEmailStyle="true" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label12" runat="server" meta:resourcekey="lblPassword">Password</asp:Label>:</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                                                                    (4-11
                                                                                    <asp:Label ID="Label23" runat="server" meta:resourcekey="lblcharacters">characters</asp:Label>)<asp:RequiredFieldValidator
                                                                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword" ErrorMessage="Please enter Password exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblPasswordErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label13" runat="server" meta:resourcekey="lblVerityPassword">Verity Password</asp:Label>:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtVerity" runat="server" TextMode="Password"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtVerity"
                                                                                        ErrorMessage="Please enter verity password exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblverityPasswordErrMsg"></asp:RequiredFieldValidator>
                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                                                                                        ControlToValidate="txtVerity" ErrorMessage="Error"></asp:CompareValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label14" runat="server" meta:resourcekey="lblPhoneNumber">Phone Number (Day Time)</asp:Label>:</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtPhoneDay" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhoneDay"
                                                                                        ErrorMessage="Please enter phone(daytime) exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblPhoneNumberErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label22" runat="server" meta:resourcekey="lblNightPhoneNumber">Phone Number (Night Time)</asp:Label>:</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtPhoneNight" runat="server"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label15" runat="server" meta:resourcekey="lblDateOfBirth">Date of Birth</asp:Label>:
                                                                                </td>
                                                                                <td>
                                                                                    <%--<uc1:Calendar ID="txtBirthday" runat="server" TooltipMessage="e.g., mm/dd/year" />--%>
                                                                                    <asp:TextBox ID="txtBirthday" runat="server"></asp:TextBox>
                                                                                    eg. MM / DD / YYYY<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                                                                        ControlToValidate="txtBirthday" ErrorMessage="Please enter Birthday exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblBirthdayErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label16" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label>:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label17" runat="server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:</td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtStreet" runat="server" Width="70%"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStreet"
                                                                                        ErrorMessage="Please enter your address to receive our travel packs exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblAddressErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label18" runat="server" meta:resourcekey="lblCity">City</asp:Label>:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCity"
                                                                                        ErrorMessage="Please enter City exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblCityErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label19" runat="server" meta:resourcekey="lblStateCountry">Country or Area</asp:Label>:</td>
                                                                                <td>
                                                                                    <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                                                                        AutoPostBack="True">
                                                                                    </asp:DropDownList>&nbsp;-&nbsp;
                                                                                    <asp:DropDownList ID="ddlState" runat="server">
                                                                                    </asp:DropDownList></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="t01">*</span><asp:Label ID="Label20" runat="server" meta:resourcekey="lblZipPostalCode">Zip/Postal Code</asp:Label>:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                                                                                        ErrorMessage="Please enter Zip/Postal Code exactly as it appears on ID card or passport."
                                                                                        ValidationGroup="region" Display="Dynamic" meta:resourcekey="lblZipErrMsg"></asp:RequiredFieldValidator></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:CheckBoxList ID="cblServer" runat="server">
                                                                                        <asp:ListItem>1</asp:ListItem>
                                                                                        <asp:ListItem>2</asp:ListItem>
                                                                                        <asp:ListItem>3</asp:ListItem>
                                                                                    </asp:CheckBoxList></td>
                                                                            </tr>
                                                                        </table>
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                                            <tr>
                                                                                <td colspan="2" class="head03">
                                                                                    <img src="../../images/index/arrow.gif" hspace="2" align="absmiddle" />
                                                                                    <asp:Label ID="Label21" runat="server" meta:resourcekey="lblTravelPreferences">Your Travel Preferences</asp:Label></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <asp:DataGrid ID="dgServer" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                                                                        Width="100%" OnItemDataBound="dgServer_ItemDataBound" border="0">
                                                                                        <HeaderStyle CssClass="newtt" />
                                                                                        <Columns>
                                                                                            <asp:BoundColumn DataField="Code" HeaderText="QuestionCode" Visible="False"></asp:BoundColumn>
                                                                                            <asp:BoundColumn DataField="Name" HeaderText="QuestionName"></asp:BoundColumn>
                                                                                            <asp:BoundColumn DataField="IsRadio" HeaderText="SingleOrMultiterm" Visible="False">
                                                                                            </asp:BoundColumn>
                                                                                            <asp:TemplateColumn>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBoxList ID="cblAnswer" runat="server" RepeatDirection="Horizontal">
                                                                                                    </asp:CheckBoxList>
                                                                                                    <asp:RadioButtonList ID="rblAnswer" runat="server" RepeatDirection="Horizontal">
                                                                                                    </asp:RadioButtonList>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateColumn>
                                                                                        </Columns>
                                                                                    </asp:DataGrid></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div class="btn">
                                                                <asp:Button ID="btnCreat" runat="server" Text="Create" CssClass="search_btn" OnClick="btnCreat_Click"
                                                                    ValidationGroup="region" meta:resourcekey="lblCreate" /></div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="4" background="../../images/index/b_mid_r.gif" style="height: 621px">
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
        <br />
        <br />
        <uc2:Footer ID="Footer1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
