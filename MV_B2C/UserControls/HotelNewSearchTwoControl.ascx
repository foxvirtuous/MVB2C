<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelNewSearchTwoControl" Codebehind="HotelNewSearchTwoControl.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="TermsCalender" TagPrefix="TermsCalender" %>
<table width="100%" border="0" cellspacing="0" cellpadding="2" class="showopt">
    <tr>
        <td style="height: 19px">
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCountry">Country or Area</asp:Label>:</td>
        <td style="height: 19px">
            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblCity">City</asp:Label></td>
        <td style="height: 19px">
            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:
        </td>
        <td style="height: 19px">
            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:
        </td>
        <td style="height: 19px">
            &nbsp;</td>
    </tr>
    <tr>
            <td>
                <asp:DropDownList ID="ddlCountry" runat="server" Width="160px" >
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select a country or area."
                    SetFocusOnError="True" ValidationGroup="HotelNewSearch" meta:resourcekey="rfCountry"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddlCity" runat="server" Width="160px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                    ControlToValidate="ddlCity" Display="Dynamic" ErrorMessage="Please select a city."
                    SetFocusOnError="True" ValidationGroup="HotelNewSearch" meta:resourcekey="rfCity"></asp:RequiredFieldValidator>
            </td>
        <td>
            <TermsCalender:TermsCalender ID="txtCheckin" runat="server" />
        </td>
        <td>
            <TermsCalender:TermsCalender ID="txtCheckout" runat="server" LowerLimitID="txtCheckin"/>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn_inbg" 
                ValidationGroup="HotelNewSearch" OnClick="btnSearch_Click" /></td>
    </tr>
</table>
<div>
    <ajaxToolkit:CascadingDropDown ID="cddHotel" runat="server" TargetControlID="ddlCountry"
        Category="Country" PromptText="Please select a country or area" LoadingText="[Loading countries...]"
        ServiceMethod="GetDropDownContents" ParentControlID=""  meta:resourcekey="cddCountry"/>
    <ajaxToolkit:CascadingDropDown ID="cddCity" runat="server" TargetControlID="ddlCity"
        Category="City" PromptText="Please select a city" LoadingText="[Loading cities...]"
        ServiceMethod="GetDropDownContents" ParentControlID="ddlCountry"  meta:resourcekey="cddCity"/>
</div>
