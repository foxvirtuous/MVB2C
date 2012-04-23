<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelDetailedInformationListControl" Codebehind="HotelDetailedInformationListControl.ascx.cs" %>
<%@ Register Src="PageNumberControl.ascx" TagName="PageNumberControl" TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<table width="100%" border="0" cellspacing="0" cellpadding="2" class="showopt">
    <tr>
        <td width="20%">
            Hotel Rating:
        </td>
        <td width="25%">
            Hotel Name Contains:</td>
        <td width="5%">
            &nbsp;
        </td>
        <td width="50%">
            &nbsp;</td>
    </tr>
    <tr>
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
            <asp:TextBox ID="txtContains" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnShow" runat="server" Text="Show" CssClass="btn_inbg" OnClick="btnShow_Click" />
        </td>
        <td>
        </td>
    </tr>
</table>
<div id="sort">
    <table width="100%">
        <tr>
            <td>
                Sort by:
            </td>
            <td>
                <asp:RadioButtonList ID="rbtnSort" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="rbtnSort_SelectedIndexChanged"
                    AutoPostBack="True">
                    <asp:ListItem Selected="True">Majestic Picks</asp:ListItem>
                    <asp:ListItem>Price</asp:ListItem>
                    <asp:ListItem>Hotel Name</asp:ListItem>
                    <asp:ListItem>Rating</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
</div>
<div class="ShowHotel">
    <asp:DataList ID="dlHotelInfo" runat="server" ShowFooter="False" ShowHeader="False"
        OnItemCommand="dlHotelInfo_ItemCommand" Width="100%">
        <ItemTemplate>
            <div class="singleHotel">
                <table border="0" cellspacing="0" cellpadding="3" width="100%">
                    <tr>
                        <td colspan="2" class="name">
                        <%-- + "-" + DataBinder.Eval(Container.DataItem, "Source")--%>
                            <asp:HyperLink ID="hlkHotelName" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Name%>'></asp:HyperLink><asp:Label
                                ID="lblHotelID" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).HotelCode %>'
                                Visible="false"><asp:Label ID="lblGTACityCode" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).City.GTACode %>' Visible=false></asp:Label></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="16%">
                            <div class="hotelpic">
                                <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT") == null || ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT").Filename == null ? "~/images/v1/defaulth.gif" : ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT").Filename.Trim() %>' onerror="this.src='http://www.majestic-vacations.com/images/v1/defaulth.gif';"  /></div>
                        </td>
                        <td>
                            <div class="AHprice">
                                <img src="../../images/v1/pricetab.gif" /><div>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <asp:Repeater ID="rptRooms" runat="server" DataSource='<%#DataBinder.Eval(Container.DataItem, "Items")%>'>
                                            <ItemTemplate>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="lblRoomDescription" runat="server" Text='<%# "Room #" + (Container.ItemIndex + 1).ToString() + ": " + DataBinder.Eval(Container.DataItem, "DefaultRoomType.Room.Name") + " $ " + Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "RoomPricePerNight").ToString()).ToString("N2")%>'></asp:Label>
                                                        / per night
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        <tr>
                                            <td align="left" class="M_price">
                                                $<asp:Label ID="lblLowestTotal" runat="server" Text='<%# Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "RoomPricePerNight").ToString()).ToString("N2") %>'></asp:Label><asp:Label
                                                    ID="Label2" runat="server" Text=" avg. per night"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:ImageButton ID="ibtnSelect" runat="server" Width="56" Height="25" ImageUrl="~/images/v1/btn_select.gif"
                                                    CommandName="Select" /></td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="hotel_ab">
                                <p>
                                    Add:
                                    <asp:Label ID="lblAddress" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Address %>'></asp:Label>
                                    <br />
                                </p>
                                <p>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="10%">
                                                <strong>Rating:</strong></td>
                                            <td align="left" width="90%">
                                                <ajaxToolkit:Rating ID="rtgHotel" runat="server" ReadOnly="true" Enabled="false"
                                                    Visible="true" MaxRating="5" StarCssClass="ratingStar" WaitingStarCssClass="savedRatingStar"
                                                    FilledStarCssClass="filledRatingStar" EmptyStarCssClass="emptyRatingStar" Style="float: left;"
                                                    CurrentRating='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Class == null ? 0 : Convert.ToDouble(((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Class) %>' />
                                            </td>
                                        </tr>
                                    </table>
                                </p>
                                <p>
                                    Located
                                    <asp:Label ID="lblLocated" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Description.Length > 100 ? ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Description.Substring(0,100) : ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Description %>'></asp:Label>...</p>
                                <asp:HyperLink ID="hlHotelInfo" runat="server" NavigateUrl='<%# "~/Page/Hotel/HotelDetailedInformationForm.aspx?TableName=Features&HotelID="+  ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).HotelCode %>'>View More Hotel Info</asp:HyperLink>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </ItemTemplate>
    </asp:DataList>
</div>
<div class="page">
    <uc3:PageNumberControl ID="PageNumberControl1" runat="server" />
    <%--<div class="turn">
        <asp:HyperLink ID="hlPrevious" runat="server">Previous</asp:HyperLink>
        |
        <asp:HyperLink ID="hlNext" runat="server">Next</asp:HyperLink>
    </div>
    View page:
    <asp:HyperLink ID="hlStar" runat="server">...</asp:HyperLink>
    <asp:HyperLink ID="hl1" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl2" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl3" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl4" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hl5" runat="server"></asp:HyperLink>
    <asp:HyperLink ID="hlEnd" runat="server">...</asp:HyperLink>--%>
</div>
