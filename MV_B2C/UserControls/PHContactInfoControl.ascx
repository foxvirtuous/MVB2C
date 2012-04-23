<%@ Control Language="C#" AutoEventWireup="true" Inherits="ContactInfo" Codebehind="PHContactInfoControl.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<table width="100%" border="0" cellpadding="2" cellspacing="0">
    <tbody>
        <tr class="IBE_package_step5_TravelInfo_R_step03" align="center">
            <td align="left" height="25">
                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblContact">Contact Information</asp:Label></td>
        </tr>
    </tbody>
</table>
<table class="IBE_T_step03 IBE_T_font_11" width="100%" border="0" cellpadding="3"
    cellspacing="1">
    <tbody>
        <tr class="IBE_R_stepw" align="left">
            <td width="20%">
                <span class="Required_t01">*</span>
                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
            <td colspan="3">
                <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="0" meta:resourcekey="item1">Mr</asp:ListItem>
                    <asp:ListItem Value="1" meta:resourcekey="item2">Mrs</asp:ListItem>
                    <asp:ListItem Value="2" meta:resourcekey="item3">Ms</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <span class="Required_t01">*</span>
                <asp:Label ID="Label13" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
            </td>
            <td colspan="3">
                <uc1:MustInputTextBox ID="txtLast" runat="server" />
                &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
                <uc1:MustInputTextBox ID="txtMiddle" runat="server" IsValidEmpty="true" />
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <span class="Required_t01">*</span>
                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
            </td>
            <td colspan="3">
                <uc1:MustInputTextBox ID="txtFirst" runat="server" />
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <span class="t01">*</span>
                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblEmail">Email Address</asp:Label>:</td>
            <td colspan="3">
                <uc1:MustInputTextBox ID="txtEmail" runat="server" IsEmailStyle="true" Width="415px" />
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <asp:Label ID="lblRequired1" runat="server"><span class="Required_t01">*</span></asp:Label>
                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDayPhone">Phone Number<br /> (daytime)</asp:Label>:</td>
            <td>
                <uc1:MustInputTextBox ID="txtPhoneDay" runat="server" />
            </td>
            <td width="20%">
                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblNightPhone">Phone Number (nighttime)</asp:Label>:</td>
            <td>
                <uc1:MustInputTextBox ID="txtPhoneNight" runat="server" IsValidEmpty="true" />
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <asp:Label ID="lblRequired2" runat="server"><span class="Required_t01">*</span></asp:Label>
                <asp:Label ID="Label8" runat="server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:</td>
            <td colspan="3">
                <uc1:MustInputTextBox ID="txtStreet" runat="server" Width="415px" />
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <asp:Label ID="lblRequired3" runat="server"><span class="Required_t01">*</span></asp:Label>
                <asp:Label ID="Label9" runat="server" meta:resourcekey="lblCity">City</asp:Label>:
            </td>
            <td colspan="3">
                <uc1:MustInputTextBox ID="txtCity" runat="server" />
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <asp:Label ID="lblRequired4" runat="server"><span class="Required_t01">*</span></asp:Label>
                <asp:Label ID="Label10" runat="server" meta:resourcekey="lblCountryState">Country or Area</asp:Label>:</td>
            <td colspan="3">
                <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                    AutoPostBack="true" Width="180px">
                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select country or area."
                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                <%--<span id="Span11" style="color: Red; display: none;">Please
                                                select country.</span>--%>
                <asp:DropDownList ID="ddlState" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <asp:Label ID="lblRequired5" runat="server"><span class="Required_t01">*</span></asp:Label>
                <asp:Label ID="Label11" runat="server" meta:resourcekey="lblZip">Zip&nbsp;/&nbsp;Postal Code</asp:Label>:
            </td>
            <td colspan="3">
                <uc1:MustInputTextBox ID="txtZip" runat="server" />
            </td>
        </tr>
        <tr class="IBE_R_stepw" align="left">
            <td>
                <asp:Label ID="Label12" runat="server" meta:resourcekey="lblFax">Fax</asp:Label>:</td>
            <td colspan="3">
                <uc1:MustInputTextBox ID="txtFax" runat="server" IsValidEmpty="true" />
            </td>
        </tr>
    </tbody>
</table>
