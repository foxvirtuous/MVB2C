<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileInfoViewControl.ascx.cs"
    Inherits="VehcileInfoViewControl" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td width="60%" align="left" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr align="left" valign="top">
                    <td width="30%">
                        <asp:Image ID="imgVonder" runat="server" Width="100" Height="47" vspace="5" border="0" /></td>
                    <td style="padding: 5px 0px 5px 0px;">
                        <span class="t09">
                            <asp:Label ID="lblVendorCode" runat="server" Text=""></asp:Label>
                            Car Rental<%--<br />
                            Phone:
                            <asp:Label ID="lblCarPhone" runat="server" Text=""></asp:Label>--%></span></td>
                </tr>
                <tr align="left" valign="top">
                    <td style="padding: 5px 0px 5px 0px;">
                        <b>Pick-up Location:</b></td>
                    <td style="padding: 5px 0px 5px 0px;">
                        <asp:Label ID="lblPickCityName" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblPickStree" runat="server" Text=""></asp:Label><asp:Label ID="lblPickCityCode" runat="server" Text=""></asp:Label><asp:Label ID="lblPickPrCode" runat="server" Text=""></asp:Label><asp:Label ID="lblPickContronCode" runat="server" Text=""></asp:Label><asp:Label ID="lblPickZipCode" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr align="left" valign="top">
                    <td style="padding: 5px 0px 5px 0px;">
                        <b>Pick-up Date/Time:</b></td>
                    <td style="padding: 5px 0px 5px 0px;">
                        <asp:Label ID="lblPickDateTime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr align="left" valign="top">
                    <td style="padding: 5px 0px 5px 0px;">
                        <b>Drop-off Location:</b></td>
                    <td style="padding: 5px 0px 5px 0px;">
                        <asp:Label ID="lblDropCityName" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblDropStree" runat="server" Text=""></asp:Label><asp:Label ID="lblDropCityCode" runat="server" Text=""></asp:Label><asp:Label ID="lblDropPrCode" runat="server" Text=""></asp:Label><asp:Label ID="lblDropContronCode" runat="server" Text=""></asp:Label><asp:Label ID="lblDropZipCode" runat="server"></asp:Label></td>
                </tr>
                <tr align="left" valign="top">
                    <td style="padding: 5px 0px 5px 0px;">
                        <b>Drop-off Date/Time:</b></td>
                    <td style="padding: 5px 0px 5px 0px;">
                        <asp:Label ID="lblDropDateTime" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr align="left" valign="top">
                    <td style="padding: 5px 0px 5px 0px;">
                        <b>Total Rental Period:</b></td>
                    <td style="padding: 5px 0px 5px 0px;">
                        <asp:Label ID="lblDays" runat="server" Text=""></asp:Label>
                        Days
                    </td>
                </tr>
                <%--<tr align="left" valign="top">
                    <td style="padding: 5px 0px 5px 0px;">
                        <asp:LinkButton ID="lbtnBack" runat="server" CssClass="d13" OnClick="lbtnBack_Click" >Back to Car List</asp:LinkButton></td>
                    <td style="padding: 5px 0px 5px 0px;">
                        &nbsp;</td>
                </tr>--%>
            </table>
        </td>
        <td align="left" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="center" style="padding: 35px 0px 20px 0px;">
                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="d13" OnClick="lbtnBack_Click" >Change Selected Car</asp:LinkButton><br />
                        <asp:Image ID="imgCar" runat="server" Width="150" vspace="5" border="0" onerror="this.src='../../images/v2/Car_Default.jpg';" />
                        <br />
                        <b>
                            <asp:Label ID="lblCarType" runat="server" Text=""></asp:Label></b><br />
                        <asp:Label ID="lblCarName" runat="server" Text=""></asp:Label><br />
                        <asp:Label ID="lblCarC" runat="server" Text="Automatic, Air Conditioned"></asp:Label></td>
                </tr>
            </table>
        </td>
    </tr>
</table>
