<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileInfoALLControl.ascx.cs"
    Inherits="VehcileInfoALLControl" %>
<div>
    <asp:Label ID="Label1" runat="server" Text="Rental Company: "></asp:Label><font class="t06"><asp:Label
        ID="lblCarType" runat="server" Text=""></asp:Label></font><br />
    <asp:Label ID="Label2" runat="server" Text="Pick-up Location: "></asp:Label><font
        class="t06"><asp:Label ID="lblDayNumber" runat="server" Text=""></asp:Label></font><br />
    <asp:Label ID="Label3" runat="server" Text="Pick-up: "></asp:Label><font class="t06"><asp:Label
        ID="lblPackup" runat="server" Text=""></asp:Label></font>&nbsp;&nbsp;&nbsp;<asp:Label
            ID="Label4" runat="server" Text="Drop-off: "></asp:Label><font class="t06"><asp:Label
                ID="lblDropoff" runat="server" Text=""></asp:Label></font><br />
    <asp:Label ID="Label5" runat="server" Text="Total Rental Time:"></asp:Label><font
        class="t06"><asp:Label ID="lblDays" runat="server"></asp:Label></font>
    <div runat="server" id="divSpecialEquipment" visible=false>
        <asp:Label ID="Label6" runat="server" Text="Special Equipment Request: "></asp:Label><font
            class="t06"><asp:Label ID="lblSpecialEquipment" runat="server"></asp:Label></font><br />
        <asp:Label ID="Label7" runat="server" Text="Subject to availability. Please contact the rental car company to confirm availability. Additional charges for special equipment items may apply at the rental counter."></asp:Label>
    </div>
</div>
