<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="PackageHotelListViewControl" Codebehind="PackageHotelListViewControl.ascx.cs" %>
    <%@ Register Src="~/UserControls/HotelRoomViewControl.ascx" TagName="HotelRoomView"
    TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<div class="getFlight">
    <h2>
        Hotel
    </h2>
    <asp:DataList ID="dlHotelByCity" runat="server" ShowFooter="False" ShowHeader="False"
        Width="100%">
        <ItemTemplate>
            <div class="DeptRet">
                Hotel in
                <asp:Label ID="lblCityName" runat="server" Text=""></asp:Label></div>
           <asp:DataList ID="dlHotel" runat="server" ShowFooter="False" ShowHeader="False" Width="100%"
                DataSource='<%# DataBinder.Eval(Container.DataItem,"Hotels")%>'>
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="3">
                        <tr>
                            <td colspan="2">
                                #<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1%>'>
                                </asp:Label>:
                                <asp:HyperLink ID="hlHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.Name") %>'>
                                </asp:HyperLink>
                                <asp:Label ID="lblHotelID" runat="server" Text='123' Visible="False"></asp:Label>
                                <asp:Label ID="lblCountry" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.City.Country.Code") %>'
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lblCityCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Hotel.City.Code") %>'
                                    Visible="False"></asp:Label>
                            </td>
                            <td colspan="2" align="right">
                                <uc3:HotelRoomView ID="HotelRoomView1" runat="server" Visible="False" />
                            </td>
                        </tr>
                        <tr>
                           
                            <td width="35%">
                                Check In:<asp:Label ID="lblCheckin" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy") %>'></asp:Label>
                            </td>
                            <td width="35%">
                                Check Out:<asp:Label ID="lblCheckOut" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy") %>'></asp:Label>
                            </td>
                            <td width="10%">
                                Total Pire
                            </td>
                            <td width="20%">
                                <asp:Label ID="lblTotalPire" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"TotalPrice") %>'></asp:Label>
                            </td>
                        
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:DataList ID="dlRooMs" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem,"RoomTypes") %>'
                                    Width="100%">
                                    <ItemTemplate>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td align="left">
                                                    1
                                                    <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Description") %>'></asp:Label>
                                                    |
                                                    <asp:Label ID="lblDayNumber" runat="server" Text=""></asp:Label>
                                                    nights &nbsp;</td>
                                                <td align="left">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BreakfastName") != "" ? "Included " + DataBinder.Eval(Container.DataItem, "BreakfastName").ToString() : "Not included breakfast"%> '></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="4" align="right">
                                <div id="divDelete" runat="server">
                                    <img src="../../images/v1/arrow_right.gif" align="absMiddle" />
                                    <asp:HyperLink ID="hlRoomType" NavigateUrl=' <%# "~/Page/Package/PackageSelectRoomsForm.aspx?HotelIndex=" +Container.ItemIndex +"?Edit=y"%>'
                                        runat="server">Select Room Type</asp:HyperLink>
                                    <img src="../../images/v1/arrow_right.gif" align="absMiddle" />
                                    <asp:HyperLink ID="hotelSelect" NavigateUrl='<%# "~/Page/Package/PackageSearchResultForm.aspx?HotelIndex=" +Container.ItemIndex +"?Edit=y"%>'
                                        runat="server"><%# "Choose other hotel in " + DataBinder.Eval(Container.DataItem, "Hotel.City.Name") %></asp:HyperLink>
                                </div>
                            </td>
                        </tr>
                        
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </ItemTemplate>
    </asp:DataList>
</div>
