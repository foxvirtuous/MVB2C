<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="ContactViewControl" Codebehind="ContactViewControl.ascx.cs" %>
<table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
    width="100%">
    <tr class="R_stepw">
        <td align="center">
        <table border="0" cellspacing="0" cellpadding="2" width="100%" class="T_step03">
                <tr align="center" class="R_order03">
                    <td colspan="4">
                        <b>
                            <asp:Label ID="lblFlightInformation" runat="server" meta:resourcekey="lblFlightInformation">Contact Information</asp:Label></b></td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                            <tr align="left" class="R_stepw">
                                <td width="15%">
                                    <asp:Label ID="lblName" runat="server" meta:resourcekey="lblName">Name</asp:Label>:</td>
                                <td width="35%">
                                    <asp:Label ID="lbName" runat="server"></asp:Label></td>
                                <td width="15%">
                                    <asp:Label ID="lblAccountCodeName" runat="server" meta:resourcekey="lblAccountCode">Client Code</asp:Label>:</td>
                                <td width="35%">
                                    <asp:Label ID="lblAccountCode" runat="server"></asp:Label></td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td width="15%">
                                    <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:</td>
                                <td width="35%">
                                    <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblCity" runat="server" meta:resourcekey="lblCity">City</asp:Label>:</td>
                                <td>
                                    <asp:Label ID="lbCity" runat="server"></asp:Label></td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <asp:Label ID="lblStreetAddress" runat="server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:</td>
                                <td colspan=3>
                                     <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <asp:Label ID="lblPostal" runat="server" meta:resourcekey="lblPostal">Zip&nbsp;/&nbsp;Postal Code</asp:Label>:</td>
                                <td>
                                    <asp:Label ID="lbZipPostCode" runat="server"></asp:Label></td>
                                <td>
                                    <asp:Label ID="lblState" runat="server" meta:resourcekey="lblState">State</asp:Label>:</td>
                                <td>
                                    <asp:Label ID="lbState" runat="server"></asp:Label></td>
                            </tr>
                            <tr align="left" class="R_stepw">
                                <td>
                                    <asp:Label ID="lblDPhone" runat="server" meta:resourcekey="lblDPhone">Daytime Phone No.</asp:Label>:</td>
                                <td>
                                    <asp:Label ID="lbDayTimePhone" runat="server"></asp:Label></td>
                               <td>
                                    <asp:Label ID="lblFax" runat="server" meta:resourcekey="lblFax">Fax</asp:Label>:</td>
                                <td>
                                    <asp:Label ID="lbFax" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr align="left" class="R_stepw">
                            <td>
                                    <asp:Label ID="lblEPhone" runat="server" meta:resourcekey="lblEPhone">Evening Phone No.</asp:Label>:</td>
                                <td>
                                    <asp:Label ID="lbEveningPhone" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRemark" runat="server" meta:resourcekey="lblRemark">Remark</asp:Label>:
                                </td>
                                <td>
                                    <asp:Label ID="lbRemark" runat="server"></asp:Label>
                                </td>
                                 
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
