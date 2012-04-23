<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileAttachmentInfoControl.ascx.cs"
    Inherits="VehcileAttachmentInfoControl" %>
<asp:DataList ID="dlEquipments" runat="server" Width="100%" border="0" CellSpacing="0"
    CellPadding="0">
    <ItemTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="25" height="30" align="left">
                    <asp:CheckBox ID="cbEquipments" runat="server" /></td>
                <td align="left">
                    <asp:Label ID="lblEquipmentsName" runat="server" Text=""></asp:Label><asp:Label ID="lblEquipmentsCode"
                        runat="server" Text="" Visible="false"></asp:Label></td>
                <td align="right" style="width: 100px">
                    <asp:Label ID="lblEquipmentsDayPrice" runat="server" Text="0.00" Visible="false"></asp:Label>
                    <asp:Label ID="lblEquipmentsWeekPrice" runat="server" Text="0.00" Visible="false"></asp:Label>
                    <asp:Label ID="lblEquipmentsMonthPrice" runat="server" Text="0.00" Visible="false" ></asp:Label>
                    <asp:Label ID="lblEquipmentsMaxPrice" runat="server" Text="0.00" Visible="false" ></asp:Label>
                    <asp:Label ID="lblEquipmentsPrice" runat="server" Text=""></asp:Label></td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
