<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HTLOrderView.ascx.cs" Inherits="HTLOrderView" %>
<%@ Register Src="ViewTransportationControl.ascx" TagName="ViewTransportationControl"
    TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>

<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td>
            <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
                width="100%">
                <tr class="R_stepw">
                    <td align="center">
                        <table border="0" cellpadding="2" cellspacing="0" width="100%">
                            <tr align="center" class="R_order03" style="background-image: url(../../images/v2/bg_s03.gif);">
                                <td height="23" colspan="7" align="center">
                                    <b><asp:Label ID="lblTravelerInformation" runat="Server" meta:resourcekey="lblTravelerInformation">Traveler Information</asp:Label></b></td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03">
                            <tr align="center" class="IBE_R_order">
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
                <tr>
                    <td colspan="2">
                        <uc3:ViewTransportationControl ID="ViewTransportationControl1" runat="server"></uc3:ViewTransportationControl>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
            <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
                width="100%">
                <tr class="R_stepw">
                    <td align="center" colspan="4">
                        <table border="0" cellpadding="2" cellspacing="0" width="100%">
                            <tr align="center" class="R_order03" style="background-image: url(../../images/v2/bg_s03.gif);">
                                <td height="23" colspan="7" align="center">
                                    <b><asp:Label ID="lblContactInformation" runat="Server" meta:resourcekey="lblContactInformation">Contact Information</asp:Label></b></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                                        <tr align="left" class="R_stepw">
                                            <td width="15%">
                                                <asp:Label ID="lblName1" runat="Server" meta:resourcekey="lblName">Name</asp:Label>:</td>
                                            <td width="35%">
                                                <asp:Label ID="lbName" runat="server"></asp:Label></td>
                                            <td width="15%">
                                                <asp:Label ID="lblEmail" runat="Server" meta:resourcekey="lblEmail">Email</asp:Label>:</td>
                                            <td width="35%">
                                                <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr align="left" class="R_stepw">
                                            <td>
                                                <asp:Label ID="lblStreetAddress" runat="Server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:</td>
                                            <td>
                                                <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblStateCity" runat="Server" meta:resourcekey="lblStateCity">State &amp; City</asp:Label>:</td>
                                            <td>
                                                <asp:Label ID="lbStateCity" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr align="left" class="R_stepw">
                                            <td>
                                                <asp:Label ID="lblZipCode" runat="Server" meta:resourcekey="lblZipCode">Zip&nbsp;/&nbsp;Postal Code</asp:Label>:</td>
                                            <td>
                                                <asp:Label ID="lbZipPostCode" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblFax" runat="Server" meta:resourcekey="lblFax">Fax</asp:Label>:</td>
                                            <td>
                                                <asp:Label ID="lbFax" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr align="left" class="R_stepw">
                                            <td>
                                                <asp:Label ID="lblDaytimePhoneNo" runat="Server" meta:resourcekey="lblDaytimePhoneNo">Daytime Phone No.</asp:Label>:</td>
                                            <td>
                                                <asp:Label ID="lbDayTimePhone" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblEveningPhoneNo" runat="Server" meta:resourcekey="lblEveningPhoneNo">Evening Phone No.</asp:Label>:</td>
                                            <td>
                                                <asp:Label ID="lbEveningPhone" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="10">
        </td>
    </tr>
</table>