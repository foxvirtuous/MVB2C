<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HTLDetailedInformationListControl.ascx.cs"
    Inherits="HTLDetailedInformationListControl" %>
<%@ Register Src="~/Page/Flight/Module/PageNumber.ascx" TagName="PageNumberControl"
    TagPrefix="uc3" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<style>
		.link_color_red { FONT-SIZE: 11px; COLOR: #ff0000 }
		.link_color_red:visited { FONT-SIZE: 11px; COLOR: #ff0000 }
		.link_color_green { FONT-SIZE: 11px; COLOR: green }
		.link_color_green:visited { FONT-SIZE: 11px; COLOR: green }
		</style>
<div class="MV_hotel_step">
    <div class="MV_hotel_step_T_line01 left">
    </div>
    <span class="left">&nbsp;
        <asp:Label ID="lblSelectHotels" runat="Server" meta:resourcekey="lblSelectHotels">Select Your Hotels</asp:Label></span></div>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td height="10">
        </td>
    </tr>
</table>
<table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
    <tr class="R_stepo">
        <td valign="top">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="7">
                        <b class="t09">
                            <asp:Label ID="lblCityName" runat="server" meta:resourcekey="lblCityName"></asp:Label>
                            <asp:Label ID="Label2" runat="server" Text=" "></asp:Label><asp:Label ID="lblHotel"
                                runat="server" meta:resourcekey="lblHotel">Hotel</asp:Label></b>
                    </td>
                    <td align="right" width="30%">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="" Style="font-size: 13px;
                            font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; background-color: white;
                            padding: 0 0 2px 0; margin: 0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/hotelmap_mv.gif);
                            width: 173px; height: 30px; cursor: pointer" /></td>
                </tr>
                <tr>
                    <td height="10" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                            <tr>
                                <td>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                                        <tr class="R_step03" align="center">
                                            <td height="30" align="left">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="20%">
                                                           <asp:Label ID="lblHotelRating" runat="Server" meta:resourcekey="lblHotelRating">Hotel Rating</asp:Label></td>
                                                       
                                                        <td width="20%">
                                                           <asp:Label ID="lblSortby" runat="Server" meta:resourcekey="lblSortby">Sort by</asp:Label>
                                                        </td>
                                                        
                                                        <td width="28%">
                                                           <asp:Label ID="lblHotelNameContains" runat="Server" meta:resourcekey="lblHotelNameContains">Find by hotel name</asp:Label>
                                                           </td>
                                                       <td width="28%">
                                                           <asp:Label ID="lbArea" runat="Server" meta:resourcekey="lbArea">Area</asp:Label>
                                                           </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlStar" runat="server">
                                                                <asp:ListItem Value="0" meta:resourcekey="lblStar">Show all</asp:ListItem>
                                                                <asp:ListItem Value="1" meta:resourcekey="lblStar1">1 star & above</asp:ListItem>
                                                                <asp:ListItem Value="2" meta:resourcekey="lblStar2">2 stars & above</asp:ListItem>
                                                                <asp:ListItem Value="3" meta:resourcekey="lblStar3">3 stars & above</asp:ListItem>
                                                                <asp:ListItem Value="4" meta:resourcekey="lblStar4">4 stars & above</asp:ListItem>
                                                                <asp:ListItem Value="5" meta:resourcekey="lblStar5">5 stars</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlSort" runat="server">
                                                                <asp:ListItem Value="0" meta:resourcekey="lblOP">Our Picks</asp:ListItem>
                                                                <asp:ListItem Value="1" meta:resourcekey="lblPrice">Price</asp:ListItem>
                                                                <asp:ListItem Value="2" meta:resourcekey="lblHN">Hotel Name</asp:ListItem>
                                                                <asp:ListItem Value="3" meta:resourcekey="lblRating">Rating</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    
                                                        <td> <asp:TextBox ID="txtContains" runat="server" CssClass="dropDownRes" Style="border: 1px solid #7C9CBC;"
                                                                onfocus="if (document.getElementById('FocusIndex')!=null){document.getElementById('FocusIndex').value='S'}"></asp:TextBox></td>
                                                         <td>
                                                            <asp:DropDownList ID="ddlArea" runat="server">
                                                             
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" rowspan="2">
                                                            <asp:Button ID="btnShow" Width="50" runat="server" Text="Show" OnClick="btnShow_Click"
                                                                Style="cursor: pointer; background: #fdeada; height: 20px; border: 1px solid #ff9900;
                                                                color: #333333;" meta:resourcekey="btnShow" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr class="R_stepw">
                                            <td>
                                                <div class="ShowHotel">
                                                    <asp:DataList ID="dlHotelInfo" runat="server" OnItemCommand="dlHotelInfo_ItemCommand"
                                                        Width="100%">
                                                        <ItemTemplate>
                                                            <div class="singleHotel">
                                                                <table border="0" cellpadding="0" cellspacing="1" class="T_step03" width="100%">
                                                                    <tr class="R_stepw" align="center">
                                                                        <td align="left" style="border: 2px solid #fff;">
                                                                            <table id="hotelinfo_table" runat="server" width="100%" border="0" cellspacing="0" cellpadding="5" class="hotelInfo_table1" style="border: none;">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <%--ToolTip='<%# DataBinder.Eval(Container.DataItem, "Source") %>'--%>
                                                                                        <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT") == null || ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT").Filename == null ? "~/images/v1/defaulth.gif" : ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT").Filename.Trim()%>'
                                                                                            onerror="this.src='http://www.majestic-vacations.com/images/v1/defaulth.gif';" />
                                                                                        <asp:Label ID="Label1" runat="server" Text='' Visible="false"></asp:Label>
                                                                                    </td>
                                                                                    <td width="50%" valign="top">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border: none;">
                                                                                            <tr>
                                                                                                <td valign="top">
                                                                                                    <font class="MV_hotel_List_dl_t11">
                                                                                                        <asp:Label ID="lbHotelName" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Name %>'></asp:Label><asp:Label
                                                                                                            ID="lblHotelID" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).HotelCode %>'
                                                                                                            Visible="false"></asp:Label><asp:Label ID="lblGTACityCode" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).City.GTACode %>' Visible=false></asp:Label></font> &nbsp;<asp:Image ID="imgSpiOff" ImageUrl="~/images/Special Offer.gif" runat="server" /><br />
                                                                                                    <b>
                                                                                                        <asp:Label ID="lblOurRating" runat="Server" meta:resourcekey="lblOurRating">Our Rating</asp:Label>:</b>
                                                                                                    <img src="<%=SaleWebSuffix%>images/star<%#  ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Class %>.gif"
                                                                                                        border="0" align="absMiddle" /><br />
                                                                                                    <b>
                                                                                                        <asp:Label ID="lblAddress" runat="Server" meta:resourcekey="lblAddress">Address</asp:Label>:</b>
                                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Address %>'></asp:Label><br>
                                                                                                    <a href="javascript:void(0)" class="MV_hotel_List_dl_d09" onclick="showDetail(this,'features');">
                                                                                                        <asp:Label ID="hlFeatures" runat="server" meta:resourcekey="hlFeatures">View Features &amp; Amenities</asp:Label>
                                                                                                    </a>|
                                                                                                    <%--<a href="javascript:void(0)" class="MV_hotel_List_dl_d09" onclick="showDetail(this,'map');">
                                                                                                        <asp:Label ID="hlLocations" runat="server" meta:resourcekey="hlLocations">View Map &amp; Locations</asp:Label></a>
                                                                                                    | --%>
                                                                                                    <a href="javascript:void(0)" class="MV_hotel_List_dl_d09" onclick="showDetail(this,'photos');">
                                                                                                        <asp:Label ID="hlphotos" runat="server" meta:resourcekey="hlphotos">View photos</asp:Label></a></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
											                                                        <asp:Image ImageUrl="~/images/stayOffer.gif" runat="server" id="imgstayOffer"></asp:Image>
											                                                        <asp:HyperLink ID="hlStayOffer" Runat="server" Target="_blank" NavigateUrl="#" CssClass="link_color_green">Stay Offer</asp:HyperLink>
											                                                       &nbsp;&nbsp;
											                                                        <asp:Image ImageUrl="~/images/specOffers.gif" runat="server" id="imgEssentialInformation"></asp:Image>
											                                                        <asp:HyperLink ID="hlEssentialInformation" Runat="server" Target="_blank" NavigateUrl="#" CssClass="link_color_red">Essential Information</asp:HyperLink>
											                                                        
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td width="33%" valign="top">
                                                                                        <table bgcolor="#fdf1c1" border="0" cellpadding="1" cellspacing="1" width="100%"
                                                                                            style="border: none;">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td class="step" align="center" bgcolor='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Recommended == true ? "#fdf1c1" : "#ffffff" %>'>
                                                                                                        <span class="MV_hotel_List_dl_t01">
                                                                                                            <asp:Label ID="lbMajesticSpecialRate" runat="server" Visible='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Recommended == true ? true : false %>'
                                                                                                                meta:resourcekey="lbMajesticSpecialRate">Majestic Special Rate</asp:Label>
                                                                                                            <asp:Label ID="lbSpecialRate" runat="server" Visible='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Recommended == true ? false : true %>'
                                                                                                                meta:resourcekey="lbSpecialRate">Special Rate</asp:Label>
                                                                                                        </span>
                                                                                                        <br><asp:Image ImageUrl="~/images/stayOffer.gif" runat="server" id="imgstayOffer1"></asp:Image>
                                                                                                        <span  style="FONT-SIZE: 12px; COLOR: #777777; LINE-HEIGHT: 20px;"><s><asp:Label ID="lbINTotalPrice" runat="server" ></asp:Label></s></span>
                                                                                                        <span class="t01">
                                                                                                            <br>
                                                                                                            $</span><span class="MV_hotel_List_dl_call"><asp:Label ID="lbTotalPrice" runat="server"
                                                                                                                Text='<%# Convert.ToDecimal(Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "RoomPricePerNight"))/Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Items.Count"))).ToString("N2") %>'></asp:Label></span><br>
                                                                                                        <span class="MV_hotel_List_dl_t01">
                                                                                                            <asp:Label ID="Label6" runat="Server" meta:resourcekey="lblavgpernight1">Including taxes and service fees</asp:Label>
                                                                                                        </span>
                                                                                                        <br>
                                                                                                        <span class="MV_hotel_List_dl_step">
                                                                                                            <asp:Label ID="lblavgpernight" runat="Server" meta:resourcekey="lblavgpernight">avg per room/night</asp:Label>
                                                                                                        </span>
                                                                                                        <%-- <br>
                                                                                                        <span class="MV_hotel_List_dl_t01">$
                                                                                                            <asp:Label ID="Label7" runat="server" Text='<%# Convert.ToDecimal(Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "SuggestedRetailRoomPricePerNight"))/Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Items.Count"))).ToString("N2") %>'></asp:Label>
                                                                                                            Suggested Retail Price</span>--%>
                                                                                                        <br>
                                                                                                        <asp:Button ID="ibtnSelect" CommandName="SELECT" runat="server" Text="SELECT" CssClass="search_btn06"
                                                                                                            meta:resourcekey="ibtnSelect" /></td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <div title="features" id="HotelFeature" style="display: none;" runat="server">
                                                                                <div class="MV_hotel_hotelInfor_FandA">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                                                                        <tr>
                                                                                            <td align="center" valign="top">
                                                                                                <asp:Image Width="160" ID="imgHotel" runat="server" onerror="this.src='http://www.majestic-vacations.com/images/v1/defaulth.gif';" /></td>
                                                                                            <td width="70%" valign="top">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td valign="top">
                                                                                                            <b>
                                                                                                                <asp:Label ID="Label4" runat="Server" meta:resourcekey="lblOurRating">Our Rating</asp:Label>:</b>
                                                                                                            <asp:Image border="0" align="absmiddle" ID="imgstar3" runat="server" /><br />
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblAddress1" runat="Server" meta:resourcekey="lblAddress">Address</asp:Label>:</b>
                                                                                                            <br>
                                                                                                            <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label><br>
                                                                                                            <b>
                                                                                                                <asp:Label ID="Label5" runat="Server" meta:resourcekey="lblAddress1">Features & Amenities</asp:Label>:</b><br>
                                                                                                            <asp:Label ID="lblList" runat="server" Text=""></asp:Label></td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                            <div title="map" id="Location" style="display: none;" runat="server">
                                                                                <div class="MV_hotel_hotelInfor_FandA">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                                                                        <tr>
                                                                                            <td valign="top">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td valign="top">
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblLocationDescription" runat="Server" meta:resourcekey="lblLocationDescription">Location Description</asp:Label>:</b><br>
                                                                                                            <asp:Label ID="lblLocation" runat="server"></asp:Label><br>
                                                                                                            <br>
                                                                                                            <b>
                                                                                                                <asp:Label ID="lblMap" runat="Server" meta:resourcekey="lblMap">Map</asp:Label>:</b>
                                                                                                            <br>
                                                                                                            <center>
                                                                                                                <asp:Image ID="imgMapUrl" runat="server" /></center>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                            <div title="photos" id="photo" style="display: none;" runat="server">
                                                                                <div class="MV_hotel_hotelInfor_FandA">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td valign="top">
                                                                                                <b>
                                                                                                    <asp:Label ID="lblPhotos1" runat="Server" meta:resourcekey="lblPhotos">Photos</asp:Label>:</b>
                                                                                                <br>
                                                                                                <div class="show">
                                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:Repeater ID="GridView1" runat="server">
                                                                                                                <ItemTemplate>
                                                                                                                    <div style="float: left; text-align: center; margin: 8px;">
                                                                                                                        <asp:Image ID="imgRoom" Width="150" Height="150" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Filename")%>'
                                                                                                                            onerror="this.parentNode.style.display='none';" />
                                                                                                                        <p>
                                                                                                                            <asp:Label ID="lblRoomName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'>
                                                                                                                            </asp:Label>
                                                                                                                        </p>
                                                                                                                    </div>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:Repeater>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </div>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                   
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="8">
                        <uc3:PageNumberControl ID="PageNumberControl1" runat="server"></uc3:PageNumberControl>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td height="3">
        </td>
    </tr>
</table>

<script type="text/javascript">
  function showDetail(obj,meta){
    while(obj.className != "hotelInfo_table1"){
      obj = obj.parentNode;
    }
    var obj1 = obj;
    
    
    
    while(obj.nextSibling){
      obj = obj.nextSibling;
      if(obj.nodeType == 1){
        if(obj.title == meta){
        
        if(meta == "features")
        {
            if(document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML == "View Features &amp; Amenities")
            {
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "Hide Features &amp; Amenities";
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "#FFA500";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "";
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "View Map &amp; Locations";
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "View photos";
                
            }
            else if(document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML == "Hide Features &amp; Amenities")
            {
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "View Features &amp; Amenities";
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "";
                
                
            }
            else if(document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML == "ï@Ê¾ïˆµêÔO‚ä")
            {
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "ë[²ØïˆµêÔO‚ä";
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "#FFA500";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "";
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "ÏÔÊ¾ïˆµêµØ³¶";
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "ï@Ê¾ïˆµêÕÕÆ¬"; 
            }
            else if(document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML == "ë[²ØïˆµêÔO‚ä")
            {
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "ï@Ê¾ïˆµêÔO‚ä";
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "";
            }
        }
//        if(meta == "map")
//        {
//            if(document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML == "View Map &amp; Locations")
//            {
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "Hide Map &amp; Locations";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "#FFA500";
//                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "";
//                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "";
//                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "View Features &amp; Amenities";
//                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "View photos";
//            }
//            else if(document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML == "Hide Map &amp; Locations")
//            {
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "View Map &amp; Locations";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "";
//                 
//            }
//             else if(document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML == "ÏÔÊ¾ïˆµêµØ³¶")
//               {
//                   document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "ë[²ØïˆµêµØ³¶";
//                   document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "#FFA500";
//                   document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "";
//                   document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "";
//                   document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "ÏÔÊ¾ïˆµêÔO‚ä";
//                   document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "ÏÔÊ¾ïˆµêÕÕÆ¬";
//               }
//               else if(document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML == "ë[²ØïˆµêµØ³¶")
//               {
//                   document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "ÏÔÊ¾ïˆµêµØ³¶";
//                   document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "";
//               }
//        }
        if(meta == "photos")
        {
            if(document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML == "View photos")
            {
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "Hide photos";
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "View Features &amp; Amenities";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "View Map &amp; Locations";
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "#FFA500";
//                document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "";
                document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "";
            }
            else if(document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML == "Hide photos")
            {
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "View photos";
                document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "";
                
            }
            else if(document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML == "ï@Ê¾ïˆµêÕÕÆ¬")
           {
               document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "ë[²ØïˆµêÕÕÆ¬";
               document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").innerHTML = "ï@Ê¾ïˆµêÔO‚ä";
//               document.getElementById(obj1.id.substr(0,54) + "_hlLocations").innerHTML = "ÏÔÊ¾ïˆµêµØ³¶";
               document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "#FFA500";
//               document.getElementById(obj1.id.substr(0,54) + "_hlLocations").parentNode.style.color = "";
               document.getElementById(obj1.id.substr(0,54) + "_hlFeatures").parentNode.style.color = "";
           }
           else if(document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML == "ë[²ØïˆµêÕÕÆ¬")
           {
               document.getElementById(obj1.id.substr(0,54) + "_hlphotos").innerHTML = "ï@Ê¾ïˆµêÕÕÆ¬";
               document.getElementById(obj1.id.substr(0,54) + "_hlphotos").parentNode.style.color = "";
           }
        }
        
         if(obj.style.display == "block"){
          obj.style.display = "none";
          obj1.parentNode.style.border = "2px solid #fff";
          }else{
          obj.style.display = "block";
            obj1.parentNode.style.border = "2px solid #FFA500";
          }
        }else{
          obj.style.display = "none";
          
        }
      }
    }
  }
</script>

