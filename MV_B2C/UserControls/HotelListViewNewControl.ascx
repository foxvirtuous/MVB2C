<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelListViewNewControl" Codebehind="HotelListViewNewControl.ascx.cs" %>
<%@ Register Src="~/UserControls/HotelRoomViewControl.ascx" TagName="HotelRoomView"
    TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<asp:DataList ID="dlHotelByCity" runat="server" ShowFooter="False" ShowHeader="False"
    Width="100%">
    <ItemTemplate>
        <div class="getFlight">
            <h2>
                Hotel in
                <asp:Label ID="lblCityName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "CityName") %>'></asp:Label></h2>
            <asp:DataList ID="dlHotel" runat="server" ShowFooter="False" ShowHeader="False" Width="100%"
                DataSource='<%# DataBinder.Eval(Container.DataItem,"Hotels")%>' OnItemDataBound="dlHotel_ItemDataBound">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td colspan="2">
                                <strong>#<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1%>'>
                                </asp:Label>:
                                    <asp:HyperLink ID="hlHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.Name") %>'>
                                    </asp:HyperLink>
                                    <asp:Label ID="lblHotelID" runat="server" Text='123' Visible="False"></asp:Label>
                                    <asp:Label ID="lblCountry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.City.Country.Code") %>'
                                        Visible="False"></asp:Label>
                                    <asp:Label ID="lblCityCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Hotel.City.Code") %>'
                                        Visible="False"></asp:Label>
                                </strong>
                            </td>
                            <td colspan="2" align="right">
                                <uc3:HotelRoomView ID="HotelRoomView1" runat="server" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 35%">
                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:&nbsp;<asp:Label ID="lblCheckin" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy") %>'></asp:Label>
                            </td>
                            <td width="35%">
                                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:&nbsp;<asp:Label ID="lblCheckOut" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy") %>'></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:PlaceHolder ID="phTotalPrice" runat="server" Visible='<%# IsShowPrice %>'><asp:Label ID="Label6" runat="server" meta:resourcekey="lblTotalPrice">Total Price</asp:Label>: &nbsp;$<asp:Label ID="lblTotalPire" runat="server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem,"TotalPrice")).ToString("N2") %>'></asp:Label>
                                </asp:PlaceHolder>
                            </td>
                        </tr>
                        <tr>
                            <asp:Repeater ID="rptRoom" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem,"RoomTypes") %>'>
                                <ItemTemplate>
                                    <tr>
                                        <td width="40%" align="left">
                                            1
                                            <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Name") %>'>
                                            </asp:Label>
                                            |
                                            <asp:Label ID="lblDayNumber" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Nights") %>'>
                                            </asp:Label>
                                            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblNights">nights</asp:Label> &nbsp;<asp:PlaceHolder ID="phChangeLink" runat="server" Visible='<%# IsMoreLinkVisible %>'>
                                                <asp:HyperLink ID="hlRoomType" NavigateUrl='<%# "~/Page/Hotel/HotelDetailedInformationForm.aspx?CheckIn=" + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy") + "&HotelName=" + DataBinder.Eval(Container.DataItem, "Room.Hotel.Name") + "&edit=y&Condition=y" %>'
                                                    runat="server" meta:resourcekey="hlChange">Change</asp:HyperLink></asp:PlaceHolder>
                                        </td>
                                        <td width="35%" align="left">
                                            <asp:Label ID="Label2" runat="server">
                                            </asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            &nbsp;<%--<asp:PlaceHolder ID="phRoomPrice" runat="server" Visible='<%# IsShowPrice %>'>Price:&nbsp;$<asp:Label
                                                ID="lblRoomPrice" runat="server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "RoomPrice")).ToString("N2") %>'></asp:Label>
                                            </asp:PlaceHolder>--%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tr>
                        <asp:PlaceHolder ID="phMoreLink" runat="server" Visible='<%# IsMoreLinkVisible %>'>
                            <tr>
                                <td colspan="4" align="right">
                                    <%--<img src="../../images/v1/arrow_right.gif" align="absMiddle" /><asp:HyperLink ID="hlRoomType"
                                        NavigateUrl='<%# "~/Page/Hotel/HotelDetailedInformationForm.aspx?CheckIn=" + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy") + "&HotelName=" + DataBinder.Eval(Container.DataItem, "Hotel.Name") + "&edit=y" %>'
                                        runat="server">Select Room Type</asp:HyperLink>--%>
                                    <img src="../../images/v1/arrow_right.gif" align="absMiddle" /><asp:HyperLink ID="hotelSelect"
                                        NavigateUrl='<%# "~/Page/Hotel/HotelSelectForm.aspx?Country=" + DataBinder.Eval(Container.DataItem, "Hotel.City.Country.Code") + "&CityCode=" + DataBinder.Eval(Container.DataItem, "Hotel.City.Code") + "&CheckIn=" + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy") + "&CheckOut=" + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy") + "&HotelName=" + DataBinder.Eval(Container.DataItem, "Hotel.Name") + "&edit=y"%>'
                                        runat="server"><%# "Choose other hotel in " + DataBinder.Eval(Container.DataItem, "Hotel.City.Name") %></asp:HyperLink>
                                </td>
                            </tr>
                        </asp:PlaceHolder>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </ItemTemplate>
</asp:DataList>