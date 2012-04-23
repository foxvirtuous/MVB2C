<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelNewSearchTwo" Codebehind="HotelNewSearchTwo.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc3" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<table width="100%" border="0" cellspacing="0" cellpadding="2" class="showopt">
    <tr>
        <td style="height: 19px">
            Country or Area:</td>
        <td style="height: 19px">
            City</td>
        <td style="height: 19px">
            Check In:
        </td>
        <td style="height: 19px">
            Check Out:
        </td>
        <td style="height: 19px">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlCountry" runat="server" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                Width="180px" AutoPostBack="true" ValidationGroup="HotelNewSearch">
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="ddlCity" runat="server" Width="100px" ValidationGroup="HotelNewSearch">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp;<uc3:Calendar ID="txtCheckin" runat="server" />
        </td>
        <td>
            &nbsp;<uc3:Calendar ID="txtCheckout" runat="server" LowerLimitID="txtCheckin" />
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn_inbg" OnClick="btnSearch_Click"
                ValidationGroup="HotelNewSearch" /></td>
    </tr>
    <tr>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCountry"
                Display="Dynamic" ErrorMessage="Please select a country or area." SetFocusOnError="True"
                ValidationGroup="HotelNewSearch"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCity"
                Display="Dynamic" ErrorMessage="Please select a city." SetFocusOnError="True"
                ValidationGroup="HotelNewSearch"></asp:RequiredFieldValidator>
        </td>
        <td>
        </td>
        <td>
        </td>
        <td>
        </td>
    </tr>
</table>
