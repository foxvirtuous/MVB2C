<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="TourItineraryInMailControl" Codebehind="TourItineraryInMailControl.ascx.cs" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<table class="MailT_step02" align="center" border="0" cellpadding="0" cellspacing="1"
    width="100%">
    <tr class="MailR_stepw">
        <td align="center">
            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                <tr align="center" class="MailR_order03">
                    <td height="23" colspan="7" align="center">
                        <b>Tour Itinerary</b></td>
                </tr>
            </table>
            <asp:DataList ID="dlTourItinerary" runat="server" Width="100%" HorizontalAlign="Center"
                OnItemDataBound="dlTourItinerary_ItemDataBound">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <table border="0" cellpadding="2" cellspacing="1" width="100%" class="MailT_step02">
                                    <tr align="center" class="MailR_order">
                                        <td height="23">
                                            Day
                                            <asp:Label ID="Label2" runat="server" Text='<%# ((TourItineraryProfile)((TourItinerary)DataBinder.Eval(Container,"DataItem")).Profile).Day.ToString() %>'>
                                            </asp:Label></td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="MailT_step02">
                                    <tr align="left" class="MailR_stepw">
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text='<%# ((TourItinerary)DataBinder.Eval(Container,"DataItem")).Profile.Description.ToString() %>'>
                                            </asp:Label>
                                            
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <asp:Label ID="lbl_MealAndHotel" runat="server"></asp:Label>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </td>
    </tr>
</table>
