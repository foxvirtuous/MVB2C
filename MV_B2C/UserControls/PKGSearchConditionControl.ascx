<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGSearchConditionControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGSearchConditionControl" %>
<div class="IBE_GrayDIV_Right">
    <div class="IBE_package_SearchCondition_D_stepr">
        <span class="left"><asp:Label ID="Label5" runat="server" meta:resourcekey="lblSearchCondition">Search Condition</asp:Label></span> <span class="right">
           <%-- <img src="../../images/v2/arrow.gif" align="absmiddle" hspace="2">
            <a href="#" class="IBE_package_SearchCondition_f09">Return to the hotel details page</a>--%>
        </span>
    </div>
    <div class="IBE_package_SearchCondition_R_bg1">
        <font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblDeparture" runat="server"> </asp:Label></font> 
        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblTo">to</asp:Label> <font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblDestination" runat="server"></asp:Label></font><br>
        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblDepartDate">Depart Date</asp:Label>:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblDepDate" runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblReturnDate" runat="server"></asp:Label></font><br>
        <asp:PlaceHolder ID="phHotel" runat="server" Visible="false">
            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblHotel">Hotel</asp:Label>:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblHotelName" runat="server"></asp:Label></font><br>
        </asp:PlaceHolder>
        <%--Room<span id="HotelInfoControl1_lblRooms2"> #<asp:Label ID="lblRoomNumbers" runat="server"></asp:Label> :</span> <asp:Label ID="lblAdult" runat="server">1</asp:Label> Adault(s), <asp:Label ID="lblChild" runat="server">2</asp:Label> Child(ren)&nbsp;--%>
        <asp:Label ID="lblRoomAndPassengers" runat="server"></asp:Label>
    </div>
</div>
