<%@ Control Language="C#" AutoEventWireup="true" Codebehind="TopDestinationsControl.ascx.cs"
    Inherits="TopDestinationsControl" %>
<table width="605" border="0" cellpadding="0" cellspacing="0" background="images/tour_des_bg.gif">
    <tr>
        <td width="605" height="28" background="http://www.majestic-vacations.com/images/tour_des_bar.gif" class="grp_title-w"
            align="left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblTopDestinations" runat="server" Text="Top Destinations" meta:resourcekey="lblTopDestinations" ></asp:Label></td>
    </tr>
    <tr>
        <td valign="top" style="border-right-style: solid; border-left-style: solid; border-right-color: #FF4713;
            border-left-color: #FF4713; border-right-width: 2px; border-left-width: 2px;
            padding: 10px 10px 10px 10px; height: 121px;">
            <table width="580" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="left">
                        <asp:DataList ID="dlTopDestinations" runat="server" RepeatDirection="Horizontal" border="0" cellpadding="2" cellspacing="0"  Width="100%">
                            <ItemTemplate>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" align="left" valign="top">
                                    <tr>
                                        <td height="118px" align="left" valign="top" class="d14" runat=server id="tdTop">
                                            <span class="head04">
                                                <asp:Label ID="lblContinent" runat="server" Text=""></asp:Label></span><br />
                                            <asp:DataList ID="dlTourArea" runat="server" OnItemCommand="dlTourArea_ItemCommand">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lbtnTourArea" runat="server" CssClass="d13_1" CommandName="Select"></asp:LinkButton>
                                                    <asp:Label ID="lblLine" runat="server" Text="" Visible="false"></asp:Label><asp:Label
                                                        ID="lblID" runat="server" Text="" Visible="false"></asp:Label>
                                                    <br />
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td height="5">
            <img src="http://www.majestic-vacations.com/images/tour_des_down.gif" width="605" height="5" /></td>
    </tr>
</table>
