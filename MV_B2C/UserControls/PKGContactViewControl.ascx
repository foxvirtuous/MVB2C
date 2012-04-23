<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGContactViewControl.ascx.cs"
    Inherits="PKGContactViewControl" %>
<table border="0" cellpadding="6" cellspacing="1" width="100%" class="IBE_T_step03 IBE_T_font_11">
    <tr align="left" class="IBE_R_stepw IBE_T_font_11">
        <td width="15%">
            <asp:Label ID="lblName" runat="server" meta:resourcekey="lblName">Name</asp:Label>:</td>
        <td width="35%">
            <asp:Label ID="lbName" runat="server"></asp:Label></td>
        <td width="15%">
            <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:</td>
        <td width="35%">
            <asp:Label ID="lbEmail" runat="server"></asp:Label></td>
    </tr>
    <tr align="left" class="IBE_R_stepw IBE_T_font_11">
        <td>
            <asp:Label ID="lblStreetAddress" runat="server" meta:resourcekey="lblStreetAddress">Street Address</asp:Label>:</td>
        <td>
            <asp:Label ID="lbAddress" runat="server"></asp:Label></td>
        <td>
            <asp:Label ID="lblCity" runat="server" meta:resourcekey="lblCity">City</asp:Label>:</td>
        <td>
            <asp:Label ID="lbCity" runat="server"></asp:Label></td>
    </tr>
    <tr align="left" class="IBE_R_stepw IBE_T_font_11">
        <td>
            <asp:Label ID="lblPostal" runat="server" meta:resourcekey="lblPostal">Zip&nbsp;/&nbsp;Postal Code</asp:Label>:</td>
        <td>
            <asp:Label ID="lbZipPostCode" runat="server"></asp:Label></td>
        <td>
            <asp:Label ID="lblState" runat="server" meta:resourcekey="lblState">State</asp:Label>:</td>
        <td>
            <asp:Label ID="lbState" runat="server"></asp:Label></td>
    </tr>
    <tr align="left" class="IBE_R_stepw IBE_T_font_11">
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
    <tr align="left" class="IBE_R_stepw IBE_T_font_11">
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
