<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGPackageDetailsInfoControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGPackageDetailsInfoControl" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>

<script type="text/javascript"> 
        function tabChange(tabName)
        {
            if(tabName == "Features")
            {
                 document.getElementById("HotelFeature").style.display = "";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("Flights").style.display = "none";
                 
//                 document.getElementById("liFeatures").className = "chosed";
//                 document.getElementById("liLocation").className = "";
//                 document.getElementById("liPhoto").className = "";
//                 document.getElementById("liRoomTypes").className = "";
//                 
//                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Features";
            }
            else if(tabName == "Location")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "";
                 document.getElementById("Flights").style.display = "none";
                 
//                 document.getElementById("liFeatures").className = "";
//                 document.getElementById("liLocation").className = "chosed";
//                 document.getElementById("liPhoto").className = "";
//                 document.getElementById("liRoomTypes").className = "";
//                 
//                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Location";
            }
            else if(tabName == "Photo")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("Flights").style.display = "none";
                 
//                 document.getElementById("liFeatures").className = "";
//                 document.getElementById("liLocation").className = "";
//                 document.getElementById("liPhoto").className = "chosed";
//                 document.getElementById("liRoomTypes").className = "";
//                 
//                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Photo";
            }
            else if(tabName == "Flights")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("Flights").style.display = "";
                 
//                 document.getElementById("liFeatures").className = "";
//                 document.getElementById("liLocation").className = "";
//                 document.getElementById("liPhoto").className = "";
//                 document.getElementById("liRoomTypes").className = "chosed";
//                 
//                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Room Types";
            }
        }
        
 


 function CancelSelect(obj,tempSpan)
 {
     elems = obj.form.elements;  
     var strTemp = tempSpan;
     var ttt = tempSpan.substr(0,37);
     
     for(i=0;i<elems.length;i++)
     {
        if (elems[i].type=="radio" && elems[i].name.substr(0,37) == ttt)
        {
          if (elems[i].type=="radio" && elems[i].id != obj.id && obj.name.substr(0,50) == strTemp)
          {
            elems[i].checked = false;
          }
        }
     }
 }   
</script>

<table width="100%" border="0" cellspacing="0" cellpadding="2" class="showopt">
    <tr>
        <td width="30%">
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblHotelRating">Hotel Rating</asp:Label>:
            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                Width="150px" Visible="false">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlCity" runat="server" Visible="false">
            </asp:DropDownList>
            <asp:DropDownList ID="ddlStar" runat="server">
                <asp:ListItem Value="0" meta:resourcekey="star0">Show all</asp:ListItem>
                <asp:ListItem Value="1" meta:resourcekey="star1">1 star or more</asp:ListItem>
                <asp:ListItem Value="2" meta:resourcekey="star2">2 star or more</asp:ListItem>
                <asp:ListItem Value="3" meta:resourcekey="star3">3 star or more</asp:ListItem>
                <asp:ListItem Value="4" meta:resourcekey="star4">4 star or more</asp:ListItem>
                <asp:ListItem Value="5" meta:resourcekey="star5">5 star or more</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="45%">
            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblHotelNameContains">Hotel Name Contains</asp:Label>:
            <asp:TextBox ID="txtContains" runat="server"></asp:TextBox>
        </td>
        <td width="8%" align="left">
            <asp:Button ID="btnShow" runat="server" Text="Search" CssClass="btn_inbg" OnClick="btnShow_Click"
                meta:resourcekey="btnShow" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<div class="IBE_package_returnDetail">
    <span class="left IBE_package_listSortby">Sort by:</span><asp:RadioButtonList ID="RadioButtonList1"
        runat="server" RepeatDirection="Horizontal" CssClass="left" CellPadding="2" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
        AutoPostBack="True">
        <asp:ListItem Selected="True" meta:resourcekey="item1">Our Picks</asp:ListItem>
        <asp:ListItem meta:resourcekey="item2">Price</asp:ListItem>
        <asp:ListItem meta:resourcekey="item3">Hotel Name</asp:ListItem>
        <asp:ListItem meta:resourcekey="item4">Rating</asp:ListItem>
    </asp:RadioButtonList>
</div>
<div class="IBE_package_List">
    <div class="IBE_package_List_DIV">
        <asp:DataList ID="dlPackages" runat="server" OnItemDataBound="dlPackages_ItemDataBound"
            OnItemCommand="dlPackages_ItemCommand" Style="height: auto; overflow: hidden;">
            <ItemTemplate>
                <div class="IBE_package_List_dl" style="height: auto; overflow: hidden;">
                    <div class="IBE_package_List_dl_list">
                        <table id="hotelinfo_table" runat="server" width="100%" border="0" cellspacing="0"
                            cellpadding="5" style="border: none;" class="IBE_package_List_dl_f10">
                            <tr>
                                <td align="center" valign="top">
                                    <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).GetImage("FRONT") == null || ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).GetImage("FRONT").Filename == null?"../images/v1/defaulth.gif":((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).GetImage("FRONT").Filename.Trim()%>'
                                        onerror="this.src='http://www.majestic-vacations.com/images/v1/defaulth.gif';" />
                                    <asp:Label ID="Label1" runat="server" Text='' Visible="false"></asp:Label>
                                </td>
                                <td width="50%" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border: none;"
                                        class="IBE_T_font11">
                                        <tr>
                                            <td valign="top">
                                                <div class="IBE_package_List_dl_hotelInfo">
                                                    <ul>
                                                        <li><font class="IBE_package_List_dl_t11">
                                                            <asp:Label ID="lbHotelName" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Name %>'></asp:Label>&nbsp;<asp:Label
                                                                ID="lblsymbol" runat="server" Text="-"></asp:Label>
                                                            &nbsp;<asp:Label ID="lblHotelSTATUS" runat="server" Text="" Visible="true"></asp:Label><asp:Label
                                                                ID="lblGTACityCode" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).City.GTACode %>'
                                                                Visible="false"></asp:Label>
                                                            <asp:Label ID="lblHotelID" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).HotelCode %>'
                                                                Visible="false"></asp:Label></font></li>
                                                        <li><b>
                                                            <asp:Label ID="lblOurRating" runat="Server" meta:resourcekey="lblOurRating" CssClass="IBE_package_List_dl_font_ZN">Our Rating</asp:Label>:</b>
                                                            <img src="<%=SaleWebSuffix%>images/star<%#  ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Class %>.gif"
                                                                border="0" align="absMiddle" /></li>
                                                        <br />
                                                        <li><b>
                                                            <asp:Label ID="Label2" runat="Server" meta:resourcekey="lblAddress" CssClass="IBE_package_List_dl_font_ZN">Address</asp:Label>:</b>
                                                            <asp:Label ID="Label3" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).HotelInformation).Address %>'></asp:Label></li>
                                                    </ul>
                                                </div>
                                                <div class="IBE_package_List_dl_hotelInfo_Tab">
                                                    <a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'features');">
                                                        <asp:Label ID="Label12" runat="server" meta:resourcekey="lblFeatures">Features &amp; Amenities</asp:Label></a>
                                                    <%--| <a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'map');">
                                                        <asp:Label ID="Label13" runat="server" meta:resourcekey="lblMaps">Map &amp; Locations</asp:Label></a>--%>
                                                    | <a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'photos');">
                                                        <asp:Label ID="Label14" runat="server" meta:resourcekey="lblPhotos">photos</asp:Label></a>
                                                    | <a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'flights');">
                                                        <asp:Label ID="Label15" runat="server" meta:resourcekey="lblFlights">Flights</asp:Label></a>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="33%" valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="1" class="IBE_package_List_dl_hotelInfo_priceBorder IBE_package_List_dl_font_ZN">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="1" cellspacing="0">
                                                    <tr>
                                                        <td align="center" bgcolor="#ffffff" class="step">
                                                            <span class="IBE_package_List_dl_t01">
                                                                <asp:Label ID="lbMajesticSpecialRate" runat="server" Visible='<%# ((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).IsRecommended == true ? true : false %>'
                                                                    meta:resourcekey="lbMajesticSpecialRate">Majestic Special Rate</asp:Label>
                                                                <asp:Label ID="lbSpecialRate" runat="server" Visible='<%# ((MVHotel) ((List<Object>)DataBinder.Eval((PackageMaterial)Container.DataItem, "Hotels"))[HotelListIndex]).IsRecommended == true ? false : true %>'
                                                                    meta:resourcekey="lbSpecialRate">Special Rate</asp:Label>
                                                            </span>
                                                            <br />
                                                            <br />
                                                            <span class="t01">
                                                                <asp:Label ID="lblDollar" runat="server">$</asp:Label>
                                                            </span><span class="call"><font style="font-size: 32px;">
                                                                <asp:Label ID="lbAvgPrice" runat="server" Text='<%# ((PackageMaterial)DataBinder.Eval(Container, "DataItem")).AvgPrice.ToString("#,###")  %>'></asp:Label></font></span><br />
                                                            <br />
                                                            <asp:Label ID="Label16" runat="server" meta:resourcekey="lblAvg" CssClass="step">avg/person</asp:Label><br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top" bgcolor="#ffffff" height="14" style="padding-top: 6px;">
                                                            <b>
                                                                <asp:Label ID="Label17" runat="server" meta:resourcekey="lblTotal">Total</asp:Label>:
                                                                <asp:Label ID="lbTotalPrice" runat="server" Text='<%# ((PackageMaterial)DataBinder.Eval(Container, "DataItem")).TotalPrice.ToString("$#,###") %>'></asp:Label></b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <font class="Required_t01">*</font><font class="IBE_package_List_dl_font_t08"><asp:Label
                                                                ID="Label18" runat="server" meta:resourcekey="lblIncludes">Includes: Flight + Hotel, Taxes & Fees</asp:Label></font></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" align="center" valign="top" bgcolor="#ffffff">
                                                            <asp:Button runat="server" ID="btnContinue" CommandName="Select" meta:resourcekey="lblChooseAndContinue"
                                                                Text="Choose and continue" CssClass="IBE_search_btn02" Style="width: 199px; margin-bottom: 6px;" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="float: left;
                            font-size: 11px; margin-top: 5px;">
                            <tr>
                                <div class="left">
                                    <span id="ctl00_MainContent_dlAvailableFlight_ctl00_lbl_Airline" class="corpname">
                                        <asp:Label ID="lblAirLine" runat="server"></asp:Label></span>
                                </div>
                            </tr>
                            <tr>
                                <td width="50" align="center">
                                    <asp:Image Height="18" ID="AirImgRtn1" runat="server" Width="18"></asp:Image>
                                </td>
                                <td>
                                    <asp:DataList ID="dlFlights" runat="server" Width="100%" BorderWidth="0">
                                        <ItemTemplate>
                                            <asp:DataList ID="dlSubTrips" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'
                                                OnItemDataBound="dlSubTrips_ItemDataBound">
                                                <ItemTemplate>
                                                    <table class="dlSubTrips" cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td rowspan="2">
                                                            </td>
                                                            <td align="center" style="font-size: 11px; width: 40px;">
                                                                <%# ((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[0].DepartureAirport.Code %>
                                                            </td>
                                                            <td align="center" style="color: #666; width: 140px;">
                                                                <asp:Label ID="lblDepDate" CssClass="lblDepDate" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[0].DepartureTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "  " %>'>
                                                                </asp:Label>
                                                            </td>
                                                            <td align="center" style="font-size: 11px; width: 40px;">
                                                                <%# ((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].DestinationAirport.Code %>
                                                            </td>
                                                            <td align="center" style="color: #666; width: 140px;">
                                                                <asp:Label ID="lblArrDate" CssClass="lblArrDate" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].ArriveTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label>
                                                            </td>
                                                            <td style="color: #2B4D87; width: 100px;" align="center">
                                                                <asp:Label ID="lblStops" runat="server"><%# (((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1) %></asp:Label>
                                                                <asp:Label ID="Label31" runat="server" meta:resourcekey="lblstop">stop(s)</asp:Label></td>
                                                            <td align="center" style="color: #2B4D87;">
                                                                <asp:Label ID="lblDurationMsg_SubTrips" meta:resourcekey="lblDurationMsg_SubTrips"
                                                                    runat="server">Duration:</asp:Label>
                                                                <asp:Label ID="lblDuration" runat="server" Style="color: #666;">35hr55mn</asp:Label></td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lbDispWarnMessage" ForeColor="red" runat="server"></asp:Label></td>
                                <td height="20" align="right" valign="bottom">
                                    <a title="Overnight Flight">
                                        <asp:Image ID="imgOverNight" runat="server" ImageUrl="http://www.majestic-vacations.com/images/v2/ec_redeye.gif"
                                            Visible="false" alt="Overnight Flight" /></a><a title="Flight operated by a different carrier"><asp:Image
                                                ID="imgCodeShared" runat="server" ImageUrl="http://www.majestic-vacations.com/images/v2/ec_codeshare.gif"
                                                Visible="false" alt="Flight operated by a different carrier" /></a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="HotelFeature" class="IBE_package_List_dl_list_detail" style="display: none;"
                        title="features">
                        <div class="description">
                            <h4 class="IBE_T_font13">
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblHotelDescription">Hotel Description</asp:Label></h4>
                            <strong>
                                <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label></strong><br />
                            <asp:Label ID="Label7" runat="server" meta:resourcekey="lblAdd">Add</asp:Label>:
                            <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
                            <br />
                            <p>
                                <asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="IBE_package_List_dl_list_detail_img">
                            <asp:Image ID="imgHotel" runat="server" Width="200" Height="200px" /></div>
                        <div class="IBE_package_List_dl_list_detail_title">
                            <asp:Label ID="Label8" runat="server" meta:resourcekey="lblHotelAmenities">Hotel Amenities</asp:Label></div>
                        <div class="IBE_package_List_dl_list_detail_content">
                            <ul>
                                <asp:Label ID="lblList" runat="server" Text=""></asp:Label>
                            </ul>
                        </div>
                    </div>
                    <div id="Location" class="IBE_package_List_dl_list_map" style="display: none;" title="map">
                        <div class="IBE_package_List_dl_list_locations">
                            <div class="IBE_package_List_dl_list_locations_title">
                                <asp:Label ID="Label9" runat="server" meta:resourcekey="lblLocationDescription">Location Description</asp:Label></div>
                            <p>
                                <asp:Label ID="lblLocation" runat="server"></asp:Label></p>
                        </div>
                        <div class="IBE_package_List_dl_list_locations_title">
                            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblMap">Map</asp:Label>
                            <br />
                            <asp:Image ID="imgMapUrl" runat="server" />
                        </div>
                    </div>
                    <div id="photo" class="IBE_package_List_dl_list_photos" style="display: none;" title="photos">
                        <h4 class="IBE_T_font13">
                            <asp:Label ID="Label11" runat="server" meta:resourcekey="lblPhotos">Photos</asp:Label></h4>
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
                    </div>
                    <asp:Panel title="flights" ID="Panel1" runat="server" Style="border-top: 1px dotted #808080;
                        width: 100%; display: none; float: left; _float: none; margin-top: 15px; _margin-top: 0px;">
                        <%--                        <div id="Flights" class="IBE_package_List_dl_list_flights" style="display: none;"
                            title="flights">
                            <div class="outside1T">
                                <div class="outside2T">--%>
                        <div id="ctl00_MainContent_dlAvailableFlight_ctl00_Panel1" style="width: 100%;">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 6px;
                                text-align: left;">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03">
                                            <tr class="IBE_R_order03">
                                                <td width="25%" height="23" align="center">
                                                    <asp:Label ID="Label5" runat="server" meta:resourcekey="lblFlightInfo">Flight Info</asp:Label></td>
                                                <td width="25%" align="center">
                                                    <asp:Label ID="lblDeparture" runat="server" meta:resourcekey="lblDeparture">Departure</asp:Label></td>
                                                <td width="25%" align="center">
                                                    <asp:Label ID="lblArrive" runat="server" meta:resourcekey="lblArrive">Arrival</asp:Label></td>
                                                <td width="10%" align="center">
                                                    <asp:Label ID="lblStops" runat="server" meta:resourcekey="lblStops">Stops</asp:Label></td>
                                                <td width="15%" align="center">
                                                    <asp:Label ID="lblDuration" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label></td>
                                            </tr>
                                        </table>
                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" class="IBE_T_font_11">
                                            <tr>
                                                <td colspan="2">
                                                    <!-- Line 1-->
                                                    <asp:DataList ID="dlFlight" runat="server" Width="100%" AlternatingItemStyle-BackColor="Silver"
                                                        BorderWidth="0" CellPadding="0" CellSpacing="0" OnItemDataBound="dlFlight_ItemDataBound">
                                                        <ItemTemplate>
                                                            <table border="0" cellspacing="1" cellpadding="3" width="100%" class="IBE_T_step03">
                                                                <tr align="left" class="IBE_R_stepw">
                                                                    <td width="25%">
                                                                        <b>
                                                                            <asp:Label ID="lbl_AirCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>'>
                                                                            </asp:Label>
                                                                            &nbsp;<asp:Label ID="lblFlightNo" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FlightNumber") %>'>
                                                                            </asp:Label>&nbsp; </b>
                                                                        <br />
                                                                        <asp:Label ID="lblOperatingAirline" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                    <td width="25%">
                                                                        <asp:Label ID="lblDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                        </asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                                        </asp:Label>
                                                                        (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                                        </asp:Label>)<br />
                                                                    </td>
                                                                    <td width="25%">
                                                                        <asp:Label ID="lblArrDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                        </asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name") %>'>
                                                                        </asp:Label>
                                                                        (<asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") %>'>
                                                                        </asp:Label>)<br />
                                                                    </td>
                                                                    <td width="10%" align="center">
                                                                        <asp:Label ID="Label9" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                                        </asp:Label></td>
                                                                    <td width="15%" align="center">
                                                                        <asp:Label ID="lblFlightDuration" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NumberOfStops") %>'>
                                                                        </asp:Label></td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:DataList>
                                                    <%--<asp:Label ID="lblDisplayFlight" runat="server"></asp:Label>--%>
                                                    <asp:Label ID="lbDispMessage1" ForeColor="black" runat="server" Visible="false" Style="text-align: center;
                                                        margin: 0 auto;"></asp:Label>
                                                    <asp:Label ID="lbDispMessage" ForeColor="black" runat="server" Visible="false" Style="text-align: center;
                                                        margin: 0 auto;"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" height="20">
                                                    <asp:Label ID="lblTotalDistanceMsg" meta:resourcekey="lblTotalDistanceMsg" runat="server"
                                                        Text="Label">Total distance: </asp:Label><asp:Label ID="lblTotalDistance" runat="server"
                                                            Text="Label">9,922 miles (15,968 km) </asp:Label></td>
                                                <td align="right">
                                                    <asp:Label ID="lblTotalDurationMsg" meta:resourcekey="lblTotalDurationMsg" runat="server"
                                                        Text="Label">Total duration: </asp:Label><asp:Label ID="lblTotalDuration" runat="server"
                                                            Text="Label">19hr 55min </asp:Label><asp:Label ID="lblTotalDurationMsgPostFix" meta:resourcekey="lblTotalDurationMsgPostFix"
                                                                runat="server" Text="Label"> with connections)</asp:Label></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <div class="clear">
                            </div>
                        </div>
                        <%--       </div>
                            </div>
                       </div>--%>
                        <div class="clear">
                        </div>
                    </asp:Panel>
                    <div class="IBE_package_List_lb_btn" title="btn">
                        <img src="../../images/v2/arrow.gif" align="absMiddle" hspace="2"><span><asp:LinkButton
                            ID="lkChange" runat="server" CommandName="Change" CssClass="IBE_package_List_dl_d09"
                            meta:resourcekey="lblChangeFlight">Change flight</asp:LinkButton></span>&nbsp;&nbsp;&nbsp;&nbsp;
                        <%--<img src="../../images/v2/arrow.gif" align="absMiddle" hspace="2"><asp:LinkButton
                            ID="lkContinue" runat="server" CommandName="Select" CssClass="IBE_package_List_dl_d09"
                            meta:resourcekey="lblChooseAndContinue">Choose and continue</asp:LinkButton>--%>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </ItemTemplate>
        </asp:DataList><div class="IBE_package_List_stepg">
            <uc4:PageNumber ID="PageNumber1" runat="server" />
            &nbsp;</div>
    </div>
</div>
