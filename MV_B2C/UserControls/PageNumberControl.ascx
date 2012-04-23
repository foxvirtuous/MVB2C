<%@ Control Language="C#" AutoEventWireup="true" Inherits="PageNumberControl" Codebehind="PageNumberControl.ascx.cs" %>

<input id="currentPageNum" type="hidden" runat="server" value="1" name="currentPageNum" />
<input id="pageFlag" type="hidden" runat="server" value="1" name="pageFlag" />
<div class="page">
    <div class="turn">
        <asp:HyperLink ID="hlPrevious" runat="server" meta:resourcekey="hlPrevious">Previous</asp:HyperLink>
        |
        <asp:HyperLink ID="hlNext" runat="server" meta:resourcekey="hlNext">Next</asp:HyperLink>
    </div>
    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblViewPage">View page</asp:Label>:
    <asp:HyperLink ID="hlStar" runat="server">...</asp:HyperLink>
    <asp:HyperLink ID="hl1" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl2" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl3" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl4" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl5" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hlEnd" runat="server">...</asp:HyperLink></div>