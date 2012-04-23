<%@ Control Language="C#" AutoEventWireup="true" Inherits="SearchEngineA" Codebehind="SearchEngineA.ascx.cs" %>
<%@ Register Src="~/UserControls/ForbiddenAirportControl.ascx" TagName="ForbiddenAirportControl"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<input id="FlightType" type="hidden" value="roundtrip" name="FlightType" runat="server" />
<input id="SelectAirCode" type="hidden" name="SelectAirCode" runat="server" />
<!-- Flight Search Body Begin -->
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr align="left">
        <td width="20%" height="25">
            <input onclick="ChangeFlightType('roundtrip')" type="radio" name="rdbType" id="rdbRoundTrip"
                runat="server" checked />
            <asp:Label ID="Label1" runat="Server" meta:resourcekey="lblRoundTrip">Round Trip</asp:Label></td>
        <td width="20%">
            <input onclick="ChangeFlightType('oneway')" type="radio" name="rdbType" id="rdbOneway"
                runat="server" /><asp:Label ID="Label2" runat="Server" meta:resourcekey="lblOneWay">One Way</asp:Label></td>
        <td width="20%">
            <input onclick="ChangeFlightType('openjaw')" type="radio" name="rdbType" id="rdbOpenjaw"
                runat="server" /><asp:Label ID="Label3" runat="Server" meta:resourcekey="lblMultipleCities">Multiple Cities</asp:Label>
        </td>
    </tr>
</table>
<table width="92%" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr align="left">
        <td height="20">
            <asp:Label ID="Label4" runat="Server" meta:resourcekey="lblFrom">From</asp:Label>
            <asp:Label ID="Label5" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
            <asp:TextBox ID="depFullCity" runat="server" autocomplete="off" style="width:130px;"></asp:TextBox>
            <asp:TextBox ID="depCity" runat="server" Visible=false ></asp:TextBox>
            </td>
        <td>
            <asp:Label ID="Label6" runat="Server" meta:resourcekey="lblTo">To</asp:Label>
            <asp:Label ID="Label7" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
            <asp:TextBox ID="toFullCity" runat="server" autocomplete="off" style="width:130px;"></asp:TextBox>
            <asp:TextBox ID="toCity" runat="server" Visible=false></asp:TextBox>
            </td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="30%" style="height: 22px">
                        <b>
                            <asp:Label ID="Label8" runat="Server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>:</b>
                    </td>
                    <td align="left" style="height: 22px">
                        <uc7:Calendar ID="depFlightCalendar" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="12px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr align="left" id="oneway1" runat="server">
        <td height="20">
            <asp:Label ID="Label9" runat="Server" meta:resourcekey="lblDeparture">Depart</asp:Label>
            <asp:Label ID="Label10" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
            <asp:TextBox ID="rtnFromFullCity" runat="server" ReadOnly=true autocomplete="off" style="width:130px;"></asp:TextBox>
            <asp:TextBox ID="rtnFromCity" runat="server" Visible=false></asp:TextBox>
            <br />
        </td>
        <td>
            <asp:Label ID="Label11" runat="Server" meta:resourcekey="lblReturn">Return</asp:Label>
            <asp:Label ID="Label12" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
            <asp:TextBox ID="rtnToFullCity" runat="server" ReadOnly=true autocomplete="off" style="width:130px;"></asp:TextBox>
            <asp:TextBox ID="rtnToCity" runat="server" Visible=false></asp:TextBox>
        </td>
    </tr>
    <tr id="oneway2" runat="server">
        <td colspan="2">
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="30%">
                        <b>
                            <asp:Label ID="Label13" runat="Server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:</b>
                    </td>
                    <td align="left">
                        <uc7:Calendar ID="rtnFlightCalendar" runat="server" LowerLimitID="depFlightCalendar" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <asp:UpdatePanel ID="up1" runat="server">
                <ContentTemplate>
                    <asp:Label ID="lblMessage" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr align="left">
        <td colspan="2">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="2%">
                        <input type="checkbox" name="chkFlexiable" value="checkbox" /></td>
                    <td width="98%" height="25">
                        <asp:Label ID="Label15" runat="Server" meta:resourcekey="lblFlexible">My dates are flexible +/- 1 day</asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="left">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="30" colspan="4">
                        <b>
                            <asp:Label ID="Label14" runat="Server" meta:resourcekey="lblPassengers">Passengers</asp:Label>:</b><br />
                        <font class="P_blue">
                            <asp:Label ID="Label16" runat="Server" meta:resourcekey="lblAdults">Adult</asp:Label></font>
                        <font class="P_blueS">( 12+ )</font>
                        <asp:DropDownList ID="ddlAdult" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;&nbsp; <font class="P_blue">
                            <asp:Label ID="Label21" runat="Server" meta:resourcekey="lblChildren">Child</asp:Label></font>
                        <font class="P_blueS">( 2 - 11 )</font>
                        <asp:DropDownList ID="ddlChild" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="ddlInfant" runat="server" Visible="False" CssClass="search_sle"
                            Width="35px">
                            <asp:ListItem>0</asp:ListItem>
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
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td width="15%">
                        <b>
                            <asp:Label ID="Label17" runat="Server" meta:resourcekey="lblClass">Class</asp:Label>:</b></td>
                    <td width="85%" height="30">
                        <asp:RadioButtonList ID="rdoLstCabin" TabIndex="15" runat="server" Width="80%" CssClass="menu"
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="ECONOMY" Selected="True" meta:resourcekey="item1">Economy</asp:ListItem>
                            <asp:ListItem Value="BUSINESS" meta:resourcekey="item2">Business</asp:ListItem>
                            <asp:ListItem Value="FIRST" meta:resourcekey="item3">First</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" width="50%">
                        <b>
                            <asp:Label ID="Label18" runat="Server" meta:resourcekey="lblAirlineCode">Airline Code</asp:Label>:</b>
                        <asp:TextBox ID="txtAirline" runat="server" onblur="EngAndPoint(this)" Width="90"
                            MaxLength="14" CssClass="search_inp"></asp:TextBox>
                        (e.g. AA,NW)
                        <br />
                        <asp:HyperLink ID="hlChooseAirline" runat="server" Target="_blank" meta:resourcekey="lnHelper"
                            NavigateUrl="#">Choose Airline</asp:HyperLink></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <%--<asp:UpdatePanel ID="upSearch" runat="server">
                <ContentTemplate>--%>
                    <asp:Button ID="btn_SearchFare" CssClass="search_btn" Text="Search" runat="Server"
                        OnClick="btn_SearchFare_Click" ValidationGroup="MKEinput1" Style="cursor: hand"
                        meta:resourcekey="btn_SearchFare" />
                    <uc2:ForbiddenAirportControl ID="ForbiddenAirportControl1" runat="server" />
                <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
    </tr>
</table>