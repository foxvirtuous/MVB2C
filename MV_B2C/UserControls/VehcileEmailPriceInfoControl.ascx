<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="VehcileEmailPriceInfoControl.ascx.cs" Inherits="VehcileEmailPriceInfoControl" %>
<table width="100%" border="0" cellpadding="8" cellspacing="1">
    <tbody>
        <tr style="background: #FFFFFF;" align="left">
            <td>
                <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr valign="top" align="left">
                            <td width="50%" height="20" align="left" style="border-bottom: solid #cccccc 1px;">
                                <table width="95%" border="0" cellspacing="0" cellpadding="0">
                                    <tr style="font-size: 11px;">
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
                                    <tr style="font-size: 11px;">
                                        <td width="50%" height="30" align="left" style="font-size: 11px;">
                                            <b>Mileage Allowance:</b></td>
                                        <td align="right" style="font-size: 11px;">
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
                            <td width="50%" height="20" align="left" style="font-size: 11px;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%" height="30" align="left" align="left" style="font-size: 11px;">
                                            <b>Base rate:</b></td>
                                        <td align="right" style="font-size: 11px;">
                                            $<asp:Label ID="lblEstamatedTotal" runat="server" Text="Unlimited"></asp:Label></td>
                                    </tr>
                                </table>
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