<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="SearchEngineH" Codebehind="SearchEngineH.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc4" %>
<!-- Hotel Search Body Begin -->
<asp:UpdatePanel ID="upHotel" runat="server">
    <ContentTemplate>
        <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr align="left">
                <td colspan="2">
                     <asp:Label ID="lblCountry" runat="Server" meta:resourcekey="lblCountry">Destination: (e.g. an City Name, City Code, Airport Code)</asp:Label>
            <br />
                <asp:TextBox ID="txtFullName" runat="server" ValidationGroup="HotelOnlySearch" autocomplete="off">
                </asp:TextBox>
                <asp:TextBox ID="txtName" runat="server" Visible=false ValidationGroup="HotelOnlySearch"></asp:TextBox>
           <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtFullName" Display="Dynamic" ErrorMessage="Please Input Name."
                SetFocusOnError="True" ValidationGroup="HotelOnlySearch" meta:resourcekey="MsgCountry"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
        </table>
    </ContentTemplate>

</asp:UpdatePanel>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="2">
            &nbsp;
        </td>
    </tr>
    <tr align="left">
        <td valign="bottom">
            <asp:Label ID="lblDepartureDate" runat="server" meta:resourcekey="lblCheckin">Check-in</asp:Label>:<br />
            &nbsp;<uc7:Calendar ID="txtCheckin_h" runat="server" />
        </td>
        <td>
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCheckout">Check-out</asp:Label>:<br />
            &nbsp;<uc7:Calendar ID="txtCheckout_h" runat="server" LowerLimitID="txtCheckin_h" />
        </td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left">
            <uc4:TravelerChange ID="TravelerChange1" runat="server"></uc4:TravelerChange>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Button ID="btnSearch_h" CssClass="search_btn" Text="Search" runat="server" OnClick="btn_Search_h_Click"
                ValidationGroup="HotelOnlySearch" meta:resourcekey="btnSearch" Style="cursor: hand" />
        </td>
    </tr>
</table>
<!-- Hotel Search Body End -->
