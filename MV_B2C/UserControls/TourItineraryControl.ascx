<%@ Control Language="C#" AutoEventWireup="true" Inherits="TourItineraryControl"
    Codebehind="TourItineraryControl.ascx.cs" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<!--Tour Itinerary Datalist begin-->
<asp:DataList ID="dlTourItinerary" runat="server" Width="100%" HorizontalAlign="Center"
    OnItemDataBound="dlTourItinerary_ItemDataBound">
    <ItemTemplate>
        <table class="T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
            width="100%">
            <tr class="R_stepw">
                <td align="center">
                    <table border="0" cellpadding="2" cellspacing="0" width="100%" class="T_step03">
                        <tr align="center" class="R_order">
                            <td align="left">
                                <strong>
                                    <asp:Label ID="lblD" runat="server" meta:resourcekey="lblDi">Day </asp:Label>
                                    <asp:Label ID="lblDay" runat="server" Text='<%# ((TourItineraryProfile)((TourItinerary)DataBinder.Eval(Container,"DataItem")).Profile).Day.ToString() %>'>
                                    </asp:Label>&nbsp;<asp:Label ID="lblDisp" runat="server" meta:resourcekey="lblTian"></asp:Label></strong>
                                -&nbsp;<asp:Label ID="lblSummer" runat="server" Text='<%# ((TourItineraryProfile)((TourItinerary)DataBinder.Eval(Container,"DataItem")).Profile).Summary.ToString() %>'></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <table border="0" cellpadding="10" cellspacing="1" width="100%">
                                    <tr class="R_stepw" align="center">
                                        <td align="left">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="72%" valign="top">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# ((TourItinerary)DataBinder.Eval(Container,"DataItem")).Profile.Description.ToString() %>'>
                                                        </asp:Label></td>
                                                    <td width="20%" align="center" valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td align="center">
                                                                    <%--<img src='<%# ((TourItineraryProfile)((TourItinerary)DataBinder.Eval(Container,"DataItem")).Profile).Logo.ToString() %>' width="150"
                                                                                                                    height="100" vspace="10" runat="server" id="" />--%>
                                                                    <asp:Image ID="imgTour" runat="server" ImageUrl='<%# ImageUrlHead + ((TourItineraryProfile)((TourItinerary)DataBinder.Eval(Container,"DataItem")).Profile).Logo.ToString() %>'
                                                                        Width="150" Height="100" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <hr width="100%" size="1" color="#dddddd" />
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <asp:Label ID="lbl_MealAndHotel" runat="server"></asp:Label>
                                            </table>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <asp:Label ID="lbl_AirTour" runat="server"></asp:Label>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>
<!--Tour Itinerary Datalist end-->
