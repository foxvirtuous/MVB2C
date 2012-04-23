<%@ Page Language="C#" AutoEventWireup="true" Inherits="MemberUpdateAccountForm"
    Codebehind="MemberUpdateAccountForm.aspx.cs" %>

<%@ Register Src="../../UserControls/MemberLeftMenu.ascx" TagName="MemberLeftMenu"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel
        package,Cheap Tours,Cheap Cruises</title>
    <link href="~/css/style2.css" rel="stylesheet" type="text/css" />
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
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td height="45" colspan="2" align="left" valign="bottom" class="D_title">
                    &nbsp;&nbsp;<asp:Label ID="lblInfo" runat="server" meta:resourcekey="lblInfo">Membership: Update Account</asp:Label></td>
            </tr>
            <tr>
                <td>
                    <br>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" valign="top">
                                <uc3:MemberLeftMenu ID="MemberLeftMenu1" runat="server" />
                                &nbsp;</td>
                            <td width="80%" align="left" valign="top">
                                <table cellspacing="1" cellpadding="3" width="100%" border="0" class="T_table">
                                    <tr>
                                        <td width="70%" colspan="2">
                                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="info">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                            <tr>
                                                                <td colspan="2" class="name" style="height: 25px">
                                                                    <span class="head01">
                                                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblMemberInfo">Member Information</asp:Label></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="22%">
                                                                    <span class="redlab">*</span><asp:Label ID="Label2" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
                                                                <td width="78%">
                                                                    <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Selected="True" Value="0" meta:resourcekey="item1">Mr</asp:ListItem>
                                                                        <asp:ListItem Value="1" meta:resourcekey="item2">Mrs</asp:ListItem>
                                                                        <asp:ListItem Value="2" meta:resourcekey="item3">Ms</asp:ListItem>
                                                                    </asp:RadioButtonList></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label3" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please enter First name exactly as it appears on ID card or passport."
                                                                        ControlToValidate="txtFirst" meta:resourcekey="lblFirstErrMsg"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label4" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtMiddle" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label5" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtLast" runat="server"></asp:TextBox><asp:RequiredFieldValidator
                                                                        ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtLast" ErrorMessage="Please enter Last name exactly as it appears on ID card or passport."
                                                                        meta:resourcekey="lblLastErrMsg"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label6" runat="server" meta:resourcekey="lblPhoneDay">Phone Number (daytime)</asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPhoneDay" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhoneDay"
                                                                        ErrorMessage="Please enter phone(daytime) exactly as it appears on ID card or passport."
                                                                        meta:resourcekey="lblPhoneNumberErrMsg"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label7" runat="server" meta:resourcekey="lblPhoneNight">Phone Number (nighttime)</asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPhoneNight" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label8" runat="server" meta:resourcekey="lblBirth">Date of Birth</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="drpAdultMonth" runat="server">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem>1</asp:ListItem>
                                                                        <asp:ListItem>2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                        <asp:ListItem>5</asp:ListItem>
                                                                        <asp:ListItem>6</asp:ListItem>
                                                                        <asp:ListItem>7</asp:ListItem>
                                                                        <asp:ListItem>8</asp:ListItem>
                                                                        <asp:ListItem>9</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>11</asp:ListItem>
                                                                        <asp:ListItem>12</asp:ListItem>
                                                                    </asp:DropDownList>-<asp:DropDownList ID="drpAdultDay" runat="server">
                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                        <asp:ListItem>1</asp:ListItem>
                                                                        <asp:ListItem>2</asp:ListItem>
                                                                        <asp:ListItem>3</asp:ListItem>
                                                                        <asp:ListItem>4</asp:ListItem>
                                                                        <asp:ListItem>5</asp:ListItem>
                                                                        <asp:ListItem>6</asp:ListItem>
                                                                        <asp:ListItem>7</asp:ListItem>
                                                                        <asp:ListItem>8</asp:ListItem>
                                                                        <asp:ListItem>9</asp:ListItem>
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>11</asp:ListItem>
                                                                        <asp:ListItem>12</asp:ListItem>
                                                                        <asp:ListItem>13</asp:ListItem>
                                                                        <asp:ListItem>14</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>16</asp:ListItem>
                                                                        <asp:ListItem>17</asp:ListItem>
                                                                        <asp:ListItem>18</asp:ListItem>
                                                                        <asp:ListItem>19</asp:ListItem>
                                                                        <asp:ListItem>20</asp:ListItem>
                                                                        <asp:ListItem>21</asp:ListItem>
                                                                        <asp:ListItem>22</asp:ListItem>
                                                                        <asp:ListItem>23</asp:ListItem>
                                                                        <asp:ListItem>24</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>26</asp:ListItem>
                                                                        <asp:ListItem>27</asp:ListItem>
                                                                        <asp:ListItem>28</asp:ListItem>
                                                                        <asp:ListItem>29</asp:ListItem>
                                                                        <asp:ListItem>30</asp:ListItem>
                                                                        <asp:ListItem>31</asp:ListItem>
                                                                    </asp:DropDownList>-<asp:DropDownList ID="drpAdultyear" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="Label9" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtPassport" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label10" runat="server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtStreet" runat="server" Width="80%"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtStreet"
                                                                        ErrorMessage="Please enter your address to receive our travel packs exactly as it appears on ID card or passport."
                                                                        meta:resourcekey="lblAddressErrMsg"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label11" runat="server" meta:resourcekey="lblCity">City</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCity"
                                                                        ErrorMessage="Please enter City exactly as it appears on ID card or passport."
                                                                        meta:resourcekey="lblCityErrMsg"></asp:RequiredFieldValidator></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label12" runat="server" meta:resourcekey="lblStateCountry">Country or Area</asp:Label>:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                    </asp:DropDownList>&nbsp;
                                                                    <asp:DropDownList ID="ddlState" runat="server">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <span class="redlab">*</span><asp:Label ID="Label13" runat="server" meta:resourcekey="lblZip">Zip/Postal Code</asp:Label>:
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                                                                        ErrorMessage="Please enter Zip/Postal Code exactly as it appears on ID card or passport."
                                                                        meta:resourcekey="lblZipErrMsg"></asp:RequiredFieldValidator></td>
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
                                                                <td colspan="2" class="name">
                                                                    <span class="head01">
                                                                        <asp:Label ID="Label14" runat="server" meta:resourcekey="lblPreferences">Your Travel Preferences</asp:Label></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:DataGrid ID="dgServer" runat="server" AutoGenerateColumns="False" ShowHeader="False"
                                                                        Width="100%" OnItemDataBound="dgServer_ItemDataBound">
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
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            &nbsp;
                                        </td>
                                        <td align="left">
                                            <asp:Button ID="aspbtnUpdate" runat="server" Text="Update" CssClass="search_btn"
                                                OnClick="aspbtnUpdate_Click" meta:resourcekey="btnUpdate" />
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
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
