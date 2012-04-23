<%@ Control Language="C#" AutoEventWireup="true" Inherits="TravelerInfoControl" Codebehind="TravelerInfoControl.ascx.cs" %>
<table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
    width="100%">
    <tr  class="R_stepw">
        <td align="center">
            <table border="0" cellspacing="0" cellpadding="2" width="100%" class="T_step03">
                <tr align="center" class="R_order03">
                    <td colspan="4">
                        <b>
                            <asp:Label ID="lblFlightInformation" runat="server" meta:resourcekey="lblFlightInformation">Traveler Information</asp:Label></b></td>
                </tr>
            </table>
            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03">
                <tr align="center" class="IBE_package_step6_TravelerInformation_title2">
                    <td width="7%" height="23">
                    </td>
                    <td width="48%">
                        <asp:Label ID="lblName" runat="server" meta:resourcekey="lblName">Name</asp:Label></td>
                    <td width="20%">
                        <asp:Label ID="lblBirth" runat="server" meta:resourcekey="lblBirth">Date of Birth</asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="lblPassportNumber" runat="server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label></td>
                </tr>
            </table>
            <asp:DataList ID="dlPassengers" runat="server" Width="100%" CellPadding="0" CellSpacing="0"
                BorderStyle="None" OnItemDataBound="dlPassengers_ItemDataBound">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="IBE_T_step03">
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
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

        </td>
    </tr>
</table>
