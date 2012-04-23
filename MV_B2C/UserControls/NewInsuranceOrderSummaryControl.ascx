<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewInsuranceOrderSummaryControl.ascx.cs"
    Inherits="NewInsuranceOrderSummaryControl" %>
<%@ Register Src="NewInsuranceOrderPriceInfo.ascx" TagName="NewInsuranceOrderPriceInfo"
    TagPrefix="uc2" %>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr align="left">
        <td height="25" valign="top" class="D_stepr">
            <asp:Label ID="lblOrderSummary" runat="server" meta:resourcekey="lblOrderSummary">Your Insurance Summary</asp:Label></td>
        <td align="right">
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                <tr class="R_stepw">
                    <td height="120">
                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tr valign="top">
                                <td>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr align="left" valign="top">
                                            <td width="15%" height="20">
                                                <strong>
                                                    <asp:Label ID="Label1" runat="server">Insurance Name</asp:Label>
                                                    :</strong></td>
                                            <td>
                                                <font class="t10">
                                                    <asp:Label ID="lblInsurance" runat="server"></asp:Label></font></td>
                                        </tr>
                                    </table>
                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr align="left" valign="top">
                                            <td height="20" width="15%">
                                                <strong>
                                                    <asp:Label ID="Label3" runat="server">Dept Date</asp:Label>
                                                    : </strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblDeptDate" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr align="left" valign="top">
                                            <td height="20">
                                                <strong>
                                                    <asp:Label ID="Label4" runat="server">Return Date</asp:Label>
                                                    : </strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblRtnDate" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr align="left" valign="top" runat="server" id="trPassengers">
                                            <td height="20">
                                                <strong>
                                                    <asp:Label ID="Label6" runat="server">No. of Passenger</asp:Label>
                                                    : </strong>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAdultNumber" runat="server" Text="Adult(s)"></asp:Label>
                                                <asp:Label ID="lblChildNumber" runat="server" Text="Child(ren)"></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="2" cellspacing="0" width="100%">
                            <tr align="center" class="R_order03">
                                <td height="23" colspan="7" align="center">
                                    <strong>
                                        <asp:Label ID="Label2" runat="server">Price</asp:Label>
                                    </strong>
                                </td>
                            </tr>
                        </table>
                        <uc2:NewInsuranceOrderPriceInfo ID="NewInsuranceOrderPriceInfo1" runat="server" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
