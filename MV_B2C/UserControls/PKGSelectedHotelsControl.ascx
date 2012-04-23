<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGSelectedHotelsControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGSelectedHotelsControl" %>
<%@ Register Src="~/UserControls/HotelRoomViewControl.ascx" TagName="HotelRoomView"
    TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:DataList ID="dlHotelByCity" runat="server" ShowFooter="False" ShowHeader="False"
    Width="100%" CellPadding="0" CellSpacing="0">
    <ItemTemplate>
        <div class="getFlight">
            <div class="IBE_package_step6_TravelerInformation_title2">
                Hotel in
                <asp:Label ID="lblCityName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CityName") %>'></asp:Label></div>
            <asp:DataList ID="dlHotel" runat="server" ShowFooter="False" ShowHeader="False" Width="100%"
                DataSource='<%# DataBinder.Eval(Container.DataItem,"Hotels")%>' OnItemDataBound="dlHotel_ItemDataBound" CellPadding="0" CellSpacing="0">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="1" cellpadding="6" class="IBE_T_step03">
                        <tr class="IBE_R_stepw">
                            <td width="3%">
                                <strong>#<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1%>'>
                                </asp:Label>
                            </td>
                            <td align="left" width="47%">
                                <asp:HyperLink ID="hlHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.Name") %>'>
                                </asp:HyperLink>
                                <asp:Label ID="lblHotelID" runat="server" Text='123' Visible="False"></asp:Label>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.City.Country.Code") %>'
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lblCityCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Hotel.City.Code") %>'
                                    Visible="False"></asp:Label>
                                </strong>
                            </td>
                            <td align="left" width="25%">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 35%">
                                            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:&nbsp;<asp:Label
                                                ID="lblCheckin" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="35%">
                                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:&nbsp;<asp:Label
                                                ID="lblCheckOut" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td align="left" width="25%">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <asp:Repeater ID="rptRoom" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem,"RoomTypes") %>'>
                                            <ItemTemplate>
                                                <tr>
                                                    <td width="40%" align="left">
                                                        1
                                                        <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Name") %>'>
                                                        </asp:Label>
                                                                                                           </td>
                 
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nights") %>'>
                                                        </asp:Label>
                                                        <asp:Label ID="Label8" runat="server" meta:resourcekey="lblNights">nights</asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left">
                                                        <asp:Label ID="Label2" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        
                        
                       <%-- <asp:PlaceHolder ID="phMoreLink" runat="server" Visible='<%# IsMoreLinkVisible %>'>
                            <tr>
                                <td colspan="4" align="right">
                                    <img src="../../images/v1/arrow_right.gif" align="absMiddle" /><asp:HyperLink ID="hotelSelect"
                                        NavigateUrl='<%# "~/Page/Hotel/HotelSelectForm.aspx?Country=" + DataBinder.Eval(Container.DataItem, "Hotel.City.Country.Code") + "&CityCode=" + DataBinder.Eval(Container.DataItem, "Hotel.City.Code") + "&CheckIn=" + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy") + "&CheckOut=" + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy") + "&HotelName=" + DataBinder.Eval(Container.DataItem, "Hotel.Name") + "&edit=y"%>'
                                        runat="server"><%# "Choose other hotel in " + DataBinder.Eval(Container.DataItem, "Hotel.City.Name") %></asp:HyperLink>
                                </td>
                            </tr>
                        </asp:PlaceHolder>--%>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </ItemTemplate>
</asp:DataList>
