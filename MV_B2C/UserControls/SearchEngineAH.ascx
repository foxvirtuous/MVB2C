<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="SearchEngineAH" Codebehind="SearchEngineAH.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc4" %>
<!-- Air + Hotel Search Body Begin -->
<table width="94%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr align="left">
        <td width="2%" height="25">
            <input id="radiobutton" name="radiobutton" type="radio" value="radiobutton" checked="checked" /></td>
        <td width="46%">
            <asp:Label ID="lblOne" runat="server" meta:resourcekey="lblOne">One Destination</asp:Label></td>
        <td width="2%">
            <input name="radiobutton" type="radio" value="radiobutton" onclick="javascript:location.href='<%=SaleWebSuffix%>Page/Package2/SelectRoomRates.aspx'" /></td>
        <td width="50%">
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblTwo">Two Destinations</asp:Label></td>
    </tr>
</table>
<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr align="left">
        <td>
            <asp:Label ID="Label4" runat="Server" meta:resourcekey="lblFrom">From</asp:Label>&nbsp;
            <asp:Label ID="Label5" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
            <asp:TextBox ID="txtFullFrom_AH" runat="server" autocomplete="off" style="width:130px;"></asp:TextBox>
            <asp:TextBox ID="txtFrom_AH" runat="server" Visible=false></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="Label2" runat="Server" meta:resourcekey="lblTo">To</asp:Label>&nbsp;
             <asp:Label ID="Label3" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
            <asp:TextBox ID="txtFullTo_AH" runat="server" autocomplete="off" style="width:130px;"></asp:TextBox>
            <asp:TextBox ID="txtTo_AH" runat="server" Visible=false></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
    </tr>
    <tr align="left">
        <td>
            <asp:Label ID="Label9" runat="Server" meta:resourcekey="lblDeparture">Depart</asp:Label>:<br />
            <uc1:Calendar ID="dateDeparture_AH" runat="server"/>
        </td>
        <td>
            <asp:Label ID="Label11" runat="Server" meta:resourcekey="lblReturn">Return</asp:Label>:<br />
            <uc1:Calendar ID="dateReturn_AH" runat="server" LowerLimitID="dateDeparture_AH"/>
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <asp:CheckBox ID="chbFlexible_AH" runat="server" Text="My dates are flexible +/- 1 day"  meta:resourcekey="lblFlexible"/>
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <input id="ckbHotel" type="checkbox" onclick="ShowHotelCheckDates()" />
            <asp:Label ID="lblOnly" runat="server" meta:resourcekey="lblOnlyNeed">I only need a hotel for part of my trip.</asp:Label><br />
        </td>
    </tr>
    <tr align="left" id="tdHotelMsg" style="display: none">
        <td colspan="2">
            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblWhenNeedHotelMsg">When do you need a hotel? (Check-in and check-out dates must be within dates of
            travel.)</asp:Label><br /><br />
        </td>
    </tr>
    <tr align="left" id="tdHotel" style="display: none">
        <td>
            <asp:Label ID="Label6" runat="Server" meta:resourcekey="lblCheckIn">CheckIn</asp:Label>:<br />
            <uc1:Calendar ID="CheckIn_AH" runat="server" LowerLimitID="dateDeparture_AH" UpperLimitID="dateReturn_AH" IsLowerRepeatDate="1"/>
        </td>
        <td>
            <asp:Label ID="Label7" runat="Server" meta:resourcekey="lblCheckOut">CheckOut</asp:Label>:<br />
            <uc1:Calendar ID="CheckOut_AH" runat="server" LowerLimitID="CheckIn_AH" UpperLimitID="dateReturn_AH" IsUpperRepeatDate="1"/>
        </td>
    </tr>
    <tr>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left">
            <uc4:TravelerChange ID="TravelerChange2" runat="server"></uc4:TravelerChange>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left">
            <b><asp:Label ID="Label8" runat="Server" meta:resourcekey="lblAddtional">Addtional options</asp:Label>:</b></td>
    </tr>
    <tr>
        <td align="left" colspan="2">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label17" runat="Server" meta:resourcekey="lblClass">Class</asp:Label>:
                    </td>
                    <td>
                        <asp:RadioButtonList ID="rdoLstCabin_AH" TabIndex="15" runat="server" Width="100%"
                            CssClass="menu" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="ECONOMY" meta:resourcekey="item1">Economy</asp:ListItem>
                            <asp:ListItem Value="BUSINESS" meta:resourcekey="item2">Business</asp:ListItem>
                            <asp:ListItem Value="FIRST" meta:resourcekey="item3">First</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" width="50%">
             <b><asp:Label ID="Label18" runat="Server" meta:resourcekey="lblAirlineCode">Airline Code</asp:Label>:</b>
             <asp:DropDownList ID="ddlAirline" runat="server" Font-Size="11px">
                <asp:ListItem Value="all" Selected="true"  meta:resourcekey="aircodeItem1">No Preference</asp:ListItem>
                <asp:ListItem Value="AA" meta:resourcekey="aircodeItem2">American Airlines</asp:ListItem>
                <asp:ListItem Value="DL" meta:resourcekey="aircodeItem3">Delta Airlines</asp:ListItem>
                <asp:ListItem Value="UA" meta:resourcekey="aircodeItem4">United Airlines</asp:ListItem>
             </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            &nbsp;<asp:Button ID="btnSearch_AH" CssClass="search_btn" Text="Search" runat="server"
                OnClick="btn_Search_AH_Click" ValidationGroup="Package_Search" meta:resourcekey="btnSearch"  style="cursor:hand"/></td>
    </tr>
</table>
<!-- Air + Hotel Search Body End -->
