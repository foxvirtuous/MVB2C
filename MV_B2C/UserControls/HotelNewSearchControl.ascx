<%@ Control Language="C#" AutoEventWireup="true" Inherits="HotelNewSearchControl" Codebehind="HotelNewSearchControl.ascx.cs" %>
<table width="100%" border="0" cellspacing="0" cellpadding="2" class="showopt">
    <tr>
        <td width="37%">
            Display by City
        </td>
        <td width="25%">
            Hotel Rating:</td>
        <td width="28%">
            Hotel Name Contains:
        </td>
        <td width="10%">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:DropDownList ID="ddlCountry" runat="server">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCity" runat="server">
            </asp:DropDownList>
        </td>
        <td>
            <asp:DropDownList ID="ddlStar" runat="server">
                <asp:ListItem Value="0">Show all</asp:ListItem>
                <asp:ListItem Value="1">1 star or more</asp:ListItem>
                <asp:ListItem Value="2">2 star or more</asp:ListItem>
                <asp:ListItem Value="3">3 star or more</asp:ListItem>
                <asp:ListItem Value="4">4 star or more</asp:ListItem>
                <asp:ListItem Value="5">5 star or more</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>
            <asp:TextBox ID="txtContains" runat="server"></asp:TextBox></td>
        <td>
            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn_inbg" />    
        </td>
    </tr>
</table>
<div>
    <ajaxToolkit:CascadingDropDown ID="cddState" runat="server" TargetControlID="ddlCountry"
        Category="Country" PromptText="Please select a country" LoadingText="[Loading hotels...]"
        ServiceMethod="GetDropDownContents" ParentControlID="" />
    <ajaxToolkit:CascadingDropDown ID="cddCountry" runat="server" TargetControlID="ddlCountry"
        Category="City" PromptText="Please select a city" LoadingText="[Loading cities...]"
        ServiceMethod="GetDropDownContents" ParentControlID="ddlCountry" />
</div>