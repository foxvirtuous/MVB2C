<%@ Control Language="C#" AutoEventWireup="true" Inherits="PackageLeftSelect" Codebehind="PackageLeftSelect.ascx.cs" %>
<%@ Register Src="Calendar.ascx" TagName="Calendar"
    TagPrefix="uc6" %>
<%@ Register Src="MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<div class="refine">
    <h2>
        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblRefineSearch">Change Your search</asp:Label>:
    </h2>
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblFrom">From (city or airport code)</asp:Label>:
                <%--<uc1:MustInputTextBox ID="txtFrom" runat="server" />--%>
                <%--<uc3:LocationTextBoxControl ID="txtFrom" runat="server" />--%>
                <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblTo">To (city or airport code)</asp:Label>:
               <%-- <uc1:MustInputTextBox ID="txtTo" runat="server" />--%>
               <%-- <uc3:LocationTextBoxControl ID="txtTo" runat="server" />--%>
                <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="height: 47px">
                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDepartDate">Depart date</asp:Label>:<br />
                <uc6:Calendar ID="dateDeparture" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblReturnDate">Return date</asp:Label>:<br />
                <uc6:Calendar ID="dateReturn" runat="server" LowerLimitID="dateDeparture" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblCheckInDate">CheckIn date</asp:Label>:<br />
                <uc6:Calendar ID="dateCheckIn" runat="server" LowerLimitID="dateDeparture" UpperLimitID="dateReturn"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label8" runat="server" meta:resourcekey="lblCheckOutDate">CheckOut date</asp:Label>:<br />
                <uc6:Calendar ID="dateCheckOut" runat="server" LowerLimitID="dateCheckIn" UpperLimitID="dateReturn"/>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:ImageButton ID="imgSearch" ImageUrl="~/images/v1/btn_search-refine.gif" Width="58" Height="26" runat="server" OnClick="imgSearch_Click" />
                </td>
        </tr>
    </table>
</div>
