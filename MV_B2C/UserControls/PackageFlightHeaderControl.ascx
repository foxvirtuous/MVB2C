<%@ Control Language="C#" AutoEventWireup="true" Inherits="PackageFlightHeaderControl" Codebehind="PackageFlightHeaderControl.ascx.cs" %>
<div class="newprice" runat="server" id="divPrice" visible="true">
    <table width="100%" border="0" cellspacing="0" cellpadding="2">
        <tr>
            <td>
                <strong><asp:Label ID="Label1" runat="server" meta:resourcekey="lblTotalPrice">Total Price</asp:Label>: </strong>
            </td>
            <td>
                <strong>$
                <asp:Label ID="lbTotalPrice" runat="server"></asp:Label>
                </strong></td>
        </tr>
        <%--<tr>
            <td>
                per person:
            </td>
            <td>$
                <asp:Label ID="lbAvgPrice" runat="server"></asp:Label>
            </td>
        </tr>--%>
    </table>
</div>
<%--Your <asp:Label ID="lbDays" runat="server"></asp:Label>  Day(s), <asp:Label ID="lbNights" runat="server"></asp:Label> Night(s) Trip
<br />--%>
<asp:Label ID="Label2" runat="server" meta:resourcekey="lblFrom">From</asp:Label> <span class="bluelab"><asp:Label ID="lbDepatrueCity" runat="server"></asp:Label></span> <asp:Label ID="Label3" runat="server" meta:resourcekey="lblTo">to</asp:Label> <span class="bluelab"><asp:Label ID="lbDestination" runat="server"></asp:Label>
<%--<asp:Label ID="lbDestination2" runat="server"></asp:Label>--%></span>&nbsp;&nbsp; <asp:Label ID="Label4" runat="server" meta:resourcekey="lblDeptDate">Dept Date</asp:Label>:&nbsp;<span class="bluelab"><asp:Label ID="lbl_deptDate" runat="server"></asp:Label></span> &nbsp;&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblRtnDate">Rtn Date</asp:Label>:&nbsp;<span class="bluelab"><asp:Label ID="lbl_rtnDate" runat="server"></asp:Label></span><br />
<asp:Label ID="lbRooms" runat="server"></asp:Label> <asp:Label ID="Label6" runat="server" meta:resourcekey="lblRoom">room(s)</asp:Label> | <asp:Label ID="lbAdults" runat="server"></asp:Label> <asp:Label ID="Label7" runat="server" meta:resourcekey="lblAdult">Adault(s)</asp:Label>, <asp:Label ID="lbChilds" runat="server"></asp:Label> <asp:Label ID="Label8" runat="server" meta:resourcekey="lblChild">Child(ren)</asp:Label> <%-- &nbsp;&nbsp;Check-in Date:<asp:Label ID="lbl_CheckInDate" runat="server"></asp:Label>  &nbsp;&nbsp;Check-out Date:<asp:Label ID="lbl_CheckOutDate" runat="server"></asp:Label>--%>
<br />
<div runat="server" id="divLink" >
    <a href="#"><asp:Label ID="Label9" runat="server" meta:resourcekey="lblHotelDetails">Hotel Details</asp:Label></a> | <a href="#"><asp:Label ID="Label10" runat="server" meta:resourcekey="lblBackResults">Back to Search Results</asp:Label></a>
</div>

