<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HTLContactControl.ascx.cs"
    Inherits="HTLContactControl" %>
<table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
    width="100%">
    <tr class="R_stepw">
        <td align="center" colspan="4">
            <table border="0" cellpadding="2" cellspacing="0" width="100%" class="T_step03">
                <tr align="center" class="R_order03">
                    <td height="23" colspan="7" align="center">
                        <b>
                            <asp:Label ID="lblContactInformation" runat="Server" meta:resourcekey="lblContactInformation">Contact Information</asp:Label></b></td>
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
<table width="100%" cellpadding="0" cellspacing="0">
    <tr>
        <td height="10">
        </td>
    </tr>
</table>
