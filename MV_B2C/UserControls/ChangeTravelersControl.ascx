<%@ Control Language="C#" AutoEventWireup="true" Inherits="ChangeTravelersControl" Codebehind="ChangeTravelersControl.ascx.cs" %>
<div class="refine">
    <h2 class="IBE_package_D_stepb">
        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblChangeTraveler">Change Travelers</asp:Label>:
    </h2>
    <table width="100%" border="0" cellspacing="0" cellpadding="3">
        <tr>
            <td>
                <asp:Label ID="lblAdultNumber" runat="server" Font-Bold="True"></asp:Label>
                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblAdult">Adult(s)</asp:Label>,<asp:Label ID="lblChildNumber" runat="server" Font-Bold="True"></asp:Label> <asp:Label ID="Label3" runat="server" meta:resourcekey="lblChild">Child(ren)</asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRooms" runat="server" Font-Bold="True"></asp:Label><asp:Label ID="Label4" runat="server" meta:resourcekey="lblRoom">Room(s)</asp:Label></td>
        </tr>
        <tr>
            <td class="changebtn">
                <asp:HyperLink ID="hlChangebtn" runat="server" NavigateUrl="~/Page/Common/GeneralTravelerChangeForm.aspx" meta:resourcekey="lblChangeTraveler" >Change Travelers</asp:HyperLink></td>
        </tr>
    </table>
</div>

