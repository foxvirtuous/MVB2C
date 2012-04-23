<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SUBTourInfoControl.ascx.cs"
    Inherits="SUBTourInfoControl" %>
<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Product.Business" %>
<table width="605" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td width="297" valign="top">
            <asp:DataList ID="dlTours" runat="server" RepeatColumns="1" Width="100%" OnItemDataBound="dlTours_ItemDataBound"
                OnItemCommand="dlTours_ItemCommand">
                <ItemTemplate>
                    <table width="297" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table width="297" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="5">
                                            <img src="/images/box_top_l.gif" /></td>
                                        <td align="left" background="/images/box_top_m.gif" class="grp_title">
                                            &nbsp;
                                            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                                            <asp:Label ID="lblNameCN" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CNName") %>'></asp:Label>
                                            <asp:Label ID="lblCode" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>'></asp:Label>
                                            <asp:Label ID="lblTourArea" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TourArea") %>'></asp:Label></td>
                                        <td width="40">
                                            <img src="/images/box_top_r_b2b.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="195" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="1" background="/images/box_mid.gif">
                                            <img src="/images/box_mid.gif" /></td>
                                        <td width="193">
                                            <table width="193" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="border-bottom: solid #CCCCCC 1px">
                                                        <asp:Image ID="imgTour" runat="server" Width="150" Height="100" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image") %>' /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="1" background="/images/box_mid.gif">
                                            <img src="/images/box_mid.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="50" valign="top" runat="server" id="trTour">
                                <asp:DataList ID="dlTourDetail" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Tours") %>'
                                    OnItemDataBound="dlTourDetail_ItemDataBound" BorderWidth="0px" Width="99%" OnItemCommand="dlTourDetail_ItemCommand">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" align="center" width="100%">
                                            <tr>
                                                <td width="5" height="25">
                                                </td>
                                                <td align="left" background="/images/box_bg.gif">
                                                    <asp:LinkButton ID="hlLink" CssClass="grp_name" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() + " - " + ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'
                                                        CommandName="Select"></asp:LinkButton>
                                                </td>
                                                <td align="right" background="/images/box_bg.gif">
                                                    <asp:Label ID="lblPrice" runat="server" CssClass="grp_price" align="right"></asp:Label>
                                                </td>
                                                <td width="5">
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
                                        Font-Underline="False" />
                                </asp:DataList>
                                <asp:Label ID="lblComingSoon" runat="server" Text="Coming Soon" Visible="false" CssClass="grp_price" meta:resourcekey="lblComingSoon"></asp:Label>
                            
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
        <td width="297" valign="top">
            <asp:DataList ID="dlTours1" runat="server" RepeatColumns="1" Width="100%" OnItemDataBound="dlTours1_ItemDataBound"
                OnItemCommand="dlTours1_ItemCommand">
                <ItemTemplate>
                    <table width="297" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table width="297" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="5">
                                            <img src="/images/box_top_l.gif" /></td>
                                        <td align="left" background="/images/box_top_m.gif" class="grp_title">
                                            &nbsp;
                                            <asp:Label ID="lblName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name") %>'></asp:Label>
                                            <asp:Label ID="lblNameCN" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CNName") %>'></asp:Label>
                                            <asp:Label ID="lblCode" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Code") %>'></asp:Label>
                                            <asp:Label ID="lblTourArea" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "TourArea") %>'></asp:Label></td>
                                        <td width="40">
                                            <img src="/images/box_top_r_b2b.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <table width="195" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="1" background="/images/box_mid.gif">
                                            <img src="/images/box_mid.gif" /></td>
                                        <td width="193">
                                            <table width="193" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="border-bottom: solid #CCCCCC 1px">
                                                        <asp:Image ID="imgTour" runat="server" Width="150" Height="100" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Image") %>' /></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="1" background="/images/box_mid.gif">
                                            <img src="/images/box_mid.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="3">
                            </td>
                        </tr>
                        <tr>
                            <td align="center" height="50" valign="top" runat="server" id="trTour">
                                <asp:DataList ID="dlTourDetail" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Tours") %>'
                                    OnItemDataBound="dlTourDetail_ItemDataBound" BorderWidth="0px" Width="99%" OnItemCommand="dlTourDetail_ItemCommand">
                                    <ItemTemplate>
                                        <table cellpadding="0" cellspacing="0" border="0" align="center" width="100%">
                                            <tr>
                                                <td width="5" height="25">
                                                </td>
                                                <td align="left" background="/images/box_bg.gif">
                                                    <asp:LinkButton ID="hlLink" CssClass="grp_name" runat="server" Text='<%# ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Code.ToString() + " - " + ((TourMaterial)DataBinder.Eval(Container,"DataItem")).Profile.Name.ToString() %>'
                                                        CommandName="Select"></asp:LinkButton>
                                                </td>
                                                <td align="right" background="/images/box_bg.gif">
                                                    <asp:Label ID="lblPrice" runat="server" CssClass="grp_price" align="right"></asp:Label>
                                                </td>
                                                <td width="5">
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
                                        Font-Underline="False" />
                                </asp:DataList>
                                <asp:Label ID="lblComingSoon" runat="server" Text="Coming Soon" Visible="false" CssClass="grp_price" meta:resourcekey="lblComingSoon"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
