<%@ Control Language="C#" AutoEventWireup="true" Inherits="ContactInfoControl" Codebehind="ContactInfoControl.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<table width="100%" border="0" cellpadding="2" cellspacing="0" class="T_step03">
    <tr align="left" class="R_stepw">
        <td width="20%">
            <span class="t01">*</span><asp:Label ID="lblGender" runat="server" meta:resourcekey="lblGender">Gender</asp:Label>:</td>
        <td width="34%">
            <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0">Mr</asp:ListItem>
                <asp:ListItem Value="1">Mrs</asp:ListItem>
                <asp:ListItem Value="2">Ms</asp:ListItem>
            </asp:RadioButtonList></td>
        <td width="16%">
            &nbsp;
        </td>
        <td width="31%">
            &nbsp;
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblLastName" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
        </td>
        <td>
            <uc1:MustInputTextBox ID="txtLast" runat="server" />
        </td>
        <td>
            <asp:Label ID="lblMiddleName" runat="server" meta:resourcekey="lblMiddleName">Middle Name</asp:Label>:
        </td>
        <td>
            <uc1:MustInputTextBox ID="txtMiddle" runat="server" IsValidEmpty="true" />
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblFirstName" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
        </td>
        <td>
            <uc1:MustInputTextBox ID="txtFirst" runat="server" />
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email Address</asp:Label>:</td>
        <td colspan="3">
            <uc1:MustInputTextBox ID="txtEmail" runat="server" IsEmailStyle="true" Width="415px" />
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblPhoneNumberD" runat="server" meta:resourcekey="lblPhoneNumberD">Phone Number (daytime)</asp:Label>:</td>
        <td>
            <uc1:MustInputTextBox ID="txtPhoneDay" runat="server" />
        </td>
        <td>
            <asp:Label ID="lblPhoneNumberN" runat="server" meta:resourcekey="lblPhoneNumberN">Phone Number
            <br />
            (nighttime)</asp:Label>:</td>
        <td>
            <uc1:MustInputTextBox ID="txtPhoneNight" runat="server" IsValidEmpty="true" />
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblStreet" runat="server" meta:resourcekey="lblStreet">Street Address</asp:Label>:</td>
        <td colspan="3">
            <uc1:MustInputTextBox ID="txtStreet" runat="server" Width="415px" />
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblCy" runat="server" meta:resourcekey="lblCity">City</asp:Label>:
        </td>
        <td colspan="3">
            <uc1:MustInputTextBox ID="txtCity" runat="server" />
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblState" runat="server" meta:resourcekey="lblState">Country or Area</asp:Label>:</td>
        <td colspan="3">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="180px" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCountry"
                        Display="Dynamic" ErrorMessage="Please select country or area." SetFocusOnError="True"
                        Enabled="False">
                    </asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlState" runat="server">
                    </asp:DropDownList></ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <span class="t01">*</span><asp:Label ID="lblPostal" runat="server" meta:resourcekey="lblPostal">Zip&nbsp;/&nbsp;Postal Code</asp:Label>:
        </td>
        <td colspan="3">
            <uc1:MustInputTextBox ID="txtZip" runat="server" />
        </td>
    </tr>
    <tr align="left" class="R_stepw">
        <td>
            <asp:Label ID="lblFax" runat="server" meta:resourcekey="lblFax">Fax</asp:Label>:</td>
        <td colspan="3">
            <uc1:MustInputTextBox ID="txtFax" runat="server" IsValidEmpty="true" />
        </td>
    </tr>
</table>
<div>
    <%-- <ajaxToolkit:CascadingDropDown ID="cddHotel" runat="server" TargetControlID="ddlCountry"
        Category="Country" PromptText="Please select a country" LoadingText="[Loading country...]"
        ServiceMethod="GetDropDownContents" ParentControlID="" />
    <ajaxToolkit:CascadingDropDown ID="cddCity" runat="server" TargetControlID="ddlState"
        Category="Provinces" PromptText="Please select a city" LoadingText="[Loading cities...]"
        ServiceMethod="GetDropDownContents" ParentControlID="ddlCountry" />--%>
</div>
