<%@ Control Language="C#" AutoEventWireup="true" Inherits="TourOrderNumberPNRInfoControl"
    Codebehind="TourOrderNumberPNRInfoControl.ascx.cs" %>
<table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
    <tr class="R_stepo">
        <td valign="top">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="7">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                            <tr class="R_stepw">
                                <td align="left">
                                    <font class="t09">
                                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblOrderNumber">The Order Number</asp:Label>:</font>
                                    <font class="t10">
                                        <asp:Label ID="lblCaseNumber" runat="server" Text=""></asp:Label></font><br />
                                    <font class="t09"><span class="dealpri">
                                        <%--<asp:Label ID="lblRcordLocator" runat="server" Text="Airline Record Locator :" Visible="False"></asp:Label>--%>
                                    </span></font>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="3">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
