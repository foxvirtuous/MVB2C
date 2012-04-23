<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TourSearchEngineer.ascx.cs"
    Inherits="TourSearchEngineer" %>
<table width="605" border="0" cellpadding="0" cellspacing="0" background="http://www.majestic-vacations.com/images/tour_des_bg.gif" >
    <tr>
        <td width="605" height="30" background="http://www.majestic-vacations.com/images/tour_search_bar.gif"
            class="grp_title-w" align="left">
            <asp:TextBox ID="txtTourSearch" runat="server" Style="margin: 3px 5px 2px 120px;"
                Width="50%"></asp:TextBox>
            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="http://www.majestic-vacations.com/images/tour_des_bar_button.gif"
                Width="100" Height="22" align="absmiddle" Style="padding: 0px 0px 3px 0px" OnClick="ibtnSearch_Click" /></td>
    </tr>
    <tr>
        <td height="10" valign="top">
        </td>
    </tr>
</table>
