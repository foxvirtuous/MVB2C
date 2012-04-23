<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGTravelerInfoControl.ascx.cs"
    Inherits="PKGTravelerInfoControl" %>
<table class="IBE_T_step03" width="100%" border="0" cellpadding="0" cellspacing="1">
    <tbody>
        <tr class="IBE_package_step6_TravelerInformation_title2">
            <td align="center" width="7%">
                &nbsp;</td>
            <td align="center" width="48%">
                <asp:Label ID="lblName" runat="server" meta:resourcekey="lblName">Name</asp:Label></td>
            <td align="center" width="20%">
                <asp:Label ID="lblBirth" runat="server" meta:resourcekey="lblBirth">Date of Birth</asp:Label></td>
            <td align="center" width="25%">
                <asp:Label ID="lblPassportNumber" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label></td>
        </tr>
    </tbody>
</table>
<asp:DataList ID="dlPassengers" runat="server" Width="100%" CellPadding="0" CellSpacing="0"
    BorderStyle="None" OnItemDataBound="dlPassengers_ItemDataBound">
    <ItemTemplate>
        <table border="0" cellpadding="6" cellspacing="1" width="100%" class="IBE_T_step03">
            <tr align="left" class="IBE_R_stepw">
                <td width="7%">
                    <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassengerType")%>'></asp:Label>
                    <asp:Label ID="lb" runat="server" Text='<%# Container.ItemIndex + 1%>'>.</asp:Label></td>
                <td width="48%">
                    <asp:Label ID="lbFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName")%>'></asp:Label>&nbsp;
                    <asp:Label ID="lbMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName")%>'></asp:Label>&nbsp;
                    <asp:Label ID="lbLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                </td>
                <td width="20%" align="center">
                    <asp:Label ID="lbBirthday" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Birthday")%>'></asp:Label>
                </td>
                <td width="25%" align="center">
                    <asp:Label ID="lbPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber")%>'></asp:Label>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
