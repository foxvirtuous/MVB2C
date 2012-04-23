<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcilePriceInfoControl.ascx.cs"
    Inherits="VehcilePriceInfoControl" %>
<table width="100%" border="0" cellpadding="8" cellspacing="1">
    <tbody>
        <tr class="R_stepw" align="left">
            <td>
                <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr valign="top" align="left">
                            <td width="50%" height="20" align="left" style="border-bottom: solid #cccccc 1px;">
                                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" height="30" align="left">
                                            <b>Daily Rate:</b></td>
                                        <td align="right">
                                            $<asp:Label ID="lblDailyRate" runat="server" Text="Unlimited"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="50%" align="right" style="border-bottom: solid #cccccc 1px;">
                                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" height="30" align="left">
                                            <b>Mileage Allowance:</b></td>
                                        <td align="right">
                                            <asp:Label ID="lblMileageAllowance" runat="server" Text="Unlimited"></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <asp:Label ID="lblEquipments" runat="server" Text=""></asp:Label>
                <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr valign="top" align="left">
                            <td width="50%" height="20" align="left" style="border-bottom: solid #cccccc 1px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" height="30" align="left">
                                            <b>Base rate:</b></td>
                                        <td align="right">
                                            $<asp:Label ID="lblEstamatedTotal" runat="server" Text="Unlimited"></asp:Label></td>
                                    </tr>
                                </table>
                                <%--<table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" height="30" align="left">
                                            <a href="#" class="d13">Promo Code</a></td>
                                        <td align="right">
                                            </td>
                                    </tr>
                                </table>--%>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr valign="top">
                            <td>
                                <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                    <tbody>
                                        <tr valign="top" align="left">
                                            <td valign="middle" width="90%" align="left" height="35">
                                                <font class="head08"><span id="PriceInfoControl1_lblTotal">Total estimated rental cost</span>:</font><asp:Label ID="lblDays" runat="server" Text="" style="display:none" ></asp:Label></td>
                                            <td valign="middle" width="10%" align="right">
                                                <font class="head08">$<asp:Label ID="lblTotalPrice" runat="server" Text="Unlimited"></asp:Label></font></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
<%--<table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
    <tbody>
        <tr valign="top" align="left">
            <td width="50%" height="20" align="left" style="border-bottom: solid #cccccc 1px;">
                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="30" align="left">
                            <b>Extra day rate:</b></td>
                        <td align="right">
                            $<asp:Label ID="Label1" runat="server" Text="Unlimited"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="30" align="left">
                            <b>Extra hour rate:</b></td>
                        <td align="right">
                            $<asp:Label ID="Label2" runat="server" Text="Unlimited"></asp:Label></td>
                    </tr>
                </table>
            </td>
            <td width="50%" align="right" style="border-bottom: solid #cccccc 1px;">
                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="30" align="left">
                            <b>Extra day mileage allowance:</b></td>
                        <td align="right">
                            <asp:Label ID="Label3" runat="server" Text="Unlimited"></asp:Label></td>
                    </tr>
                </table>
                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="30" align="left">
                            <b>Extra hour mileage allowance:</b></td>
                        <td align="right">
                            <asp:Label ID="Label4" runat="server" Text="Unlimited"></asp:Label></td>
                    </tr>
                </table>
            </td>
        </tr>
    </tbody>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td width="50%" height="30" align="left">
            <b>Transaction Fee:</b></td>
        <td align="right">
            $<asp:Label ID="Label6" runat="server" Text="Unlimited"></asp:Label></td>
    </tr>
</table>
<table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
    <tbody>
        <tr valign="top" align="left">
            <td width="50%" height="20" align="left" style="border-bottom: solid #cccccc 1px;">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="50%" height="30" align="left">
                            Child Seat/Infant</td>
                        <td align="right">
                            $12.95</td>
                    </tr>
                </table>
            </td>
        </tr>
    </tbody>
</table>--%>
