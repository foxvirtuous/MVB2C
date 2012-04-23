<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="FlightHeaderControl" Codebehind="FlightHeaderControl.ascx.cs" %>
<table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
    <%--<tr align="left" valign="top">
        <td>
            <asp:PlaceHolder ID="phDate" runat="server" visible="true">
            <font class="t06">Your <asp:Label ID="lbDays" runat="server"></asp:Label> Day(s), <asp:Label ID="lbNights" runat="server"></asp:Label> Night(s) Trip</font></asp:PlaceHolder></td>
    </tr>--%>
    <tr align="left" valign="top">
        <td>
         <%--   San Francisco International Airport (SFO) to Los Angeles International Airport (LAX)<br/>--%>
            <font class="t06"><asp:Label ID="lbDeparture" runat="server"></asp:Label><asp:Label ID="Label1" runat="server" meta:resourcekey="lblTo"> to </asp:Label><asp:Label ID="lbDestination" runat="server"></asp:Label> <asp:Label ID="lbDestination2" runat="server"></asp:Label></font><br />
            <asp:Label ID="lbAdults" runat="server"></asp:Label><asp:Label ID="Label2" runat="server" meta:resourcekey="lblAdult"> Adult(s)</asp:Label>, <asp:Label ID="lbChilds" runat="server"></asp:Label><asp:Label ID="Label3" runat="server" meta:resourcekey="lblChild"> Child(ren)</asp:Label></td>
    </tr>
</table>
