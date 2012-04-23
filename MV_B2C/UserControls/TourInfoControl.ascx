<%@ Control Language="C#" AutoEventWireup="true" Inherits="TourInfoControl" Codebehind="TourInfoControl.ascx.cs" %>
<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Product.Business" %>
<style>
.TourTD {
	background:url(/images/box_bg.gif); font-weight:normal;font-style:normal;text-decoration:none
}
.TourTD1 { 
	align="left"; valign="top"
}
</style>
<table width="605" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td align="center">
            <table width="605" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="15">
                    </td>
                </tr>
            </table>
            <asp:DataList ID="dlTours" runat="server" RepeatColumns="2" OnItemDataBound="dlTours_ItemDataBound"
                OnItemCommand="dlTours_ItemCommand" Style="width: 100%; border-collapse: collapse;
                width: 100%; border-collapse: collapse;">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" width="297" border="0" background="http://www.majestic-vacations.com/images/tour_box_top.gif">
                        <tr>
                            <td width="5" height="26" valign="top">
                               <%-- <img src="../images/box_top_l.gif" />--%>
                            </td>
                            <td width="176" height="26" align=left class="grp_title">
                                <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                                <asp:Label ID="lblNameCN" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CNName") %>'></asp:Label>
                                <asp:Label ID="lblCode" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>'></asp:Label>
                                <asp:Label ID="lblTourArea" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TourArea") %>'></asp:Label>&nbsp;
                            </td>
                            <td width="116" height="26" align="right">
                                <asp:LinkButton ID="lkbMore" runat="server" Text="More" CssClass="grp_more" CommandName="More"
                                    meta:resourcekey="lkbMore"></asp:LinkButton>
                                <img src="../images/box_arrow.gif" runat="server" hspace="5" id="img" align="absmiddle" />
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="297" border="0">
                        <tr>
                            <td width="1" background="/images/box_mid.gif">
                                <img src="/images/box_mid.gif" />
                            </td>
                            <td style="border-bottom: #f6f6f6 1px solid">
                                <asp:Image ID="imgTour" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image") %>'
                                    Style="border-width: 0px;" />
                            </td>
                            <td width="1" background="/images/box_mid.gif">
                                <img src="/images/box_mid.gif" />
                            </td>
                        </tr>
                        <tr>
                            <td width="1" background="/images/box_mid.gif">
                                <img src="/images/box_mid.gif" />
                            </td>
                            <td align="center" valign="top" runat="server" id="trTour" height="85">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="5">
                                        </td>
                                    </tr>
                                </table>
                                <asp:DataList ID="dlTourDetail" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Tours") %>'
                                    OnItemDataBound="dlTourDetail_ItemDataBound" BorderWidth="0px" Width="100%" OnItemCommand="dlTourDetail_ItemCommand">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" align="center" width="95%">
                                            <tr>
                                                <td align="left">
                                                    <asp:LinkButton ID="hlLink" CssClass="grp_name" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'
                                                        CommandName="Select"></asp:LinkButton>
                                                </td>
                                                <td align="right" width="16%">
                                                    <asp:Label ID="lblPrice" runat="server" CssClass="grp_price" align="right"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Label ID="lblTourCode" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCountry" runat="server" Text='<%# ((MVTourProfile)((TourMaterial)DataBinder.Eval(Container, "DataItem")).Profile).EndCity.Country.Code.ToString() %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblCity" runat="server" Text='<%# ((MVTourProfile)((TourMaterial)DataBinder.Eval(Container, "DataItem")).Profile).EndCity.Code.ToString() %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblDepCity" runat="server" Text='<%# ((MVTourProfile)((TourMaterial)DataBinder.Eval(Container, "DataItem")).Profile).DefaultDepartureCity.Code.ToString() %>'
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="lblIndex" runat="server" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                                        Font-Underline="False" Height="25" CssClass="TourTD" />
                                </asp:DataList>
                                <asp:Label ID="lblComingSoon" runat="server" Text="Coming Soon" Visible="false" CssClass="grp_price"
                                    meta:resourcekey="lblComingSoon"></asp:Label>
                            </td>
                            <td width="1" background="/images/box_mid.gif">
                                <img src="/images/box_mid.gif" />
                            </td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="297" border="0">
                        <tr>
                            <td>
                                <img src="/images/box_bot_d.gif" width="297" height="7" /></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle CssClass="TourTD1" />
            </asp:DataList>
            <table width="605" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="25">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
