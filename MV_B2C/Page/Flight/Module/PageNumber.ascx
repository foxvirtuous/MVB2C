<%@ Control Language="C#" AutoEventWireup="true" Inherits="PageNumber" Codebehind="PageNumber.ascx.cs" %>
<asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
        <input id="currentPageNum" type="hidden" runat="server" value="1" name="currentPageNum" />
        <input id="pageFlag" type="hidden" runat="server" value="1" name="pageFlag" />
        <div style="float: right;" class="D_stepg">
            <asp:Label ID="LinkFirstPage" runat="server" Text="First Page" meta:resourcekey="lblFirstPage"
                Style="color: blue; text-decoration: underline; cursor: pointer; font-size: 11px;"></asp:Label><%--<asp:Label ID="lblFirstPage" runat="server" meta:resourcekey="lblFirstPage">First Page</asp:Label>--%>
            <asp:Label ID="LinkPrevPage" runat="server" Text="Prev" meta:resourcekey="lblPrev"
                Style="color: blue; text-decoration: underline; cursor: pointer; font-size: 11px;"> </asp:Label>|
            <strong>
                <asp:Label ID="lblPage" runat="server" meta:resourcekey="lblPage">Page</asp:Label></strong><%--<asp:Label ID="lblPrev" runat="server" meta:resourcekey="lblPrev">Prev</asp:Label>--%>
            <asp:Label ID="lbl_JumpToPage" runat="server"></asp:Label>
            <asp:DropDownList ID="ddlPageNumber" runat="server">
            </asp:DropDownList>
            /<asp:Label ID="LblTotal" runat="server"></asp:Label>
            |<asp:Label ID="LinkNextPage" runat="server" Text="Next" meta:resourcekey="lblNext"
                Style="color: #ff0000; text-decoration: underline; cursor: pointer; font-size: 11px;"></asp:Label><%--<asp:Label ID="lblNext" runat="server" meta:resourcekey="lblNext">Next</asp:Label> --%>
            |<asp:Label ID="LinkLastPage" runat="server" Text="Last Page" Style="color: #ff0000;
                text-decoration: underline; font-size: 11px; cursor: pointer;" meta:resourcekey="lblLastPage"></asp:Label><%--<asp:Label ID="lblLastPage" runat="server" meta:resourcekey="lblLastPage" >Last Page</asp:Label>--%>
            <asp:Label ID="Lblnum" runat="server"></asp:Label>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
