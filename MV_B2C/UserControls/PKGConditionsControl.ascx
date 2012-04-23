<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGConditionsControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGConditionsControl" %>
<table border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <font class="IBE_package_SearchCondition_f06">
            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblFrom">From</asp:Label>&nbsp;<asp:Label ID="lblDeparture" runat="server"> </asp:Label></font>
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblTo">to</asp:Label> <font class="IBE_package_SearchCondition_f06">
                <asp:Label ID="lblDestination" runat="server"> </asp:Label></font><br>
            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblDepartDate">Depart Date</asp:Label>:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblDepDate"
                runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblReturnDate" runat="server"></asp:Label></font><br>
            <%--Hotel:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblHotelName" runat="server"></asp:Label></font><br>--%>
            <%--Room<span id="HotelInfoControl1_lblRooms2"> #<asp:Label ID="lblRoomNumbers" runat="server"></asp:Label> :</span> <asp:Label ID="lblAdult" runat="server">1</asp:Label> Adault(s), <asp:Label ID="lblChild" runat="server">2</asp:Label> Child(ren)&nbsp;--%>
            <asp:Label ID="lblRoomAndPassengers" runat="server"></asp:Label>
        </td>
    </tr>
</table>
