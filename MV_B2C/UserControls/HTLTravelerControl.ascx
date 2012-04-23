<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HTLTravelerControl.ascx.cs"
    Inherits="HTLTravelerControl" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
    width="100%">
    <tr class="R_stepw">
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" width="100%" class="T_step03">
                <tr align="center" class="R_order03">
                    <td height="23" colspan="7" align="center">
                        <b>
                            <asp:Label ID="lblTravelerInformation" runat="Server" meta:resourcekey="lblTravelerInformation">Traveler Information</asp:Label></b></td>
                </tr>
            </table>
            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                <tr align="center" class="R_order">
                    <td width="7%" height="23">
                    </td>
                    <td width="48%">
                        <asp:Label ID="lblName" runat="Server" meta:resourcekey="lblName">Name</asp:Label></td>
                    <td width="20%">
                        <asp:Label ID="lblDateBirth" runat="Server" meta:resourcekey="lblDateBirth">Date of Birth</asp:Label></td>
                    <td width="25%">
                        <asp:Label ID="lblPassportNumber" runat="Server" meta:resourcekey="lblPassportNumber">Passport Number</asp:Label></td>
                </tr>
            </table>
            <asp:DataList ID="dlPassengers" runat="server" Width="100%" OnItemDataBound="dlPassengers_ItemDataBound">
                <ItemTemplate>
                    <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                        <tr align="left" class="R_stepw">
                            <td width="7%">
                                <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassengerType")%>'></asp:Label>
                                <asp:Label ID="lb" runat="server" Text='<%# Container.ItemIndex + 1%>'>.</asp:Label>
                            </td>
                            <td width="48%">
                                <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Salutationn").ToString()%>'></asp:Label>&nbsp;
                                <asp:Label ID="lbFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName")%>'></asp:Label>&nbsp;
                                <asp:Label ID="lbMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName")%>'></asp:Label>&nbsp;
                                <asp:Label ID="lbLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                            </td>
                            <td width="20%">
                                <asp:Label ID="lbBirth" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "BirthDay")).ToString("MM/dd/yyyy") == "01-01-0001" ? "" : ((DateTime)DataBinder.Eval(Container.DataItem, "BirthDay")).ToString("MM/dd/yyyy")  %>'></asp:Label>
                            </td>
                            <td width="25%">
                                <asp:Label ID="lbPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber")%>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
</table>
