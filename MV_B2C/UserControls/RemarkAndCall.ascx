<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="RemarkAndCall" Codebehind="RemarkAndCall.ascx.cs" %>
<%--<div id="right_ad">
    <textarea id="txtRemark" cols="20" rows="2" style="overflow: auto; width:135px; height:auto" ></textarea>
</div>--%>
<div id="call">
    <strong><asp:Label ID="Label1" runat="server" meta:resourcekey="lblCustomerServices">Customer Services</asp:Label>:</strong><br />
    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblMonFri">Mon-Fri</asp:Label>: 9AM-10PM (EST)<br />
    <asp:Label ID="Label3" runat="server" meta:resourcekey="lblSat">Sat</asp:Label>: 9AM-7PM (EST)<br />
    <asp:Label ID="Label4" runat="server" meta:resourcekey="lblSun">Sun</asp:Label>: closed<br />
    <asp:Label ID="Label5" runat="server" meta:resourcekey="lblExcept">Except public holidays</asp:Label>.<br />
    <br />
    <strong><asp:Label ID="Label6" runat="server" meta:resourcekey="lblCall">Please call</asp:Label>:</strong><br />
    1-(888)-288-7528
</div>
