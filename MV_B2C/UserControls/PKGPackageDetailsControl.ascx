<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGPackageDetailsControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGPackageDetailsControl" %>
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

<script type="text/javascript"> 
       
 function CancelSelect(obj,tempSpan,cell)
 {
     elems = obj.form.elements;  
     var strTemp = tempSpan;
     var ttt = tempSpan.substr(0,60);
     
     for(i=0;i<elems.length;i++)
     {
        if (elems[i].type=="radio" && elems[i].name.substr(0,60) == ttt)
        {
          if (elems[i].type=="radio" && elems[i].id != obj.id && obj.name.substr(0,73) == strTemp)
          {
            elems[i].checked = false;
            //window.alert(document.getElementById(elems[i].id.substr(0,52) + "_cell").id);
            document.getElementById(elems[i].id.substr(0,73) + "_cell").style.backgroundColor="#fff";
            //window.alert(document.getElementById(elems[i].id.substr(0,52) + "_cell").style.backgroundColor);
          }
          if (elems[i].type=="radio" && elems[i].id == obj.id && obj.name.substr(0,73) == strTemp)
          {
            elems[i].checked = true;
            //window.alert(document.getElementById(elems[i].id.substr(0,52) + "_cell").id);
            document.getElementById(elems[i].id.substr(0,73) + "_cell").style.backgroundColor="#fdf1c1";
            //window.alert(document.getElementById(elems[i].id.substr(0,52) + "_cell").style.backgroundColor);
          }
        }
     }
    
        if(obj.checked) 
        {
            document.getElementById(cell).style.backgroundColor="#fdf1c1"; 
        }
        else 
        {
            document.getElementById(cell).style.backgroundColor=""; 
        }
     
 }   
</script>

<%--<asp:DataList ID="dlPackages" runat="server" 
    >
    <ItemTemplate>--%>
<asp:DataList ID="dlHotelDetails" runat="server" Width="100%" OnItemDataBound="dlHotelDetails_ItemDataBound">
    <ItemTemplate>
        <div class="IBE_package_List_dl_list_selectRoom">
            <h4>
                Hotel in
                <asp:Label ID="lbHotelCity" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).City.Name %>'></asp:Label>
            </h4>
            <div class="IBE_package_List_dl_I1">
                <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).GetImage("FRONT") == null || ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).GetImage("FRONT").Filename == null ?"../images/v1/defaulth.gif":((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).GetImage("FRONT").Filename.Trim()%>' />
                <asp:Label ID="Label1" runat="server" Text='' Visible="false"></asp:Label>
            </div>
            <div class="IBE_package_List_dl_list_selectRoom_detail">
                <div class="IBE_package_List_dl_hotelInfo_Tab" style="height: 85px;">
                    <ul>
                        <li><font class="IBE_package_List_dl_t11">
                            <asp:Label ID="lbHotelName" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).Name %>'></asp:Label>
                            <asp:Label ID="lblHotelID" runat="server" Text='<%# ((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelId.ToString() %>'
                                Visible="false"></asp:Label>
                        </font></li>
                        <br />
                        <li><b>
                            <asp:Label ID="lblOurRating" runat="Server" meta:resourcekey="lblOurRating">Our Rating</asp:Label>:</b>
                            <img runat="server" id="imgClass" src='~/images/star<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).Class %>.gif'
                                border="0" align="absMiddle" /></li>
                        <br />
                        <li><b>
                            <asp:Label ID="Label2" runat="Server" meta:resourcekey="lblAddress">Address</asp:Label>:</b>
                            <asp:Label ID="lblAdd" runat="server" Text='<%# ((TERMS.Common.Hotel)((MVHotel)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0]).HotelInformation).Address %>'></asp:Label></li>
                    </ul>
                </div>
                <div class="IBE_package_List_dl_hotelInfo_Tab">
                    <ul>
                        <li><a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'features');">
                            <asp:Label ID="Label12" runat="server" meta:resourcekey="lblFeatures">Features &amp; Amenities</asp:Label></a>
                            <%--| <a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'map');">
                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblMaps">Map &amp; Locations</asp:Label></a>--%>
                            | <a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'photos');">
                                <asp:Label ID="Label13" runat="server" meta:resourcekey="lblPhotos">photos</asp:Label></a>
                            | <a href="javascript:void(0)" class="IBE_package_List_dl_d09" onclick="showDetail(this,'flights');">
                                <asp:Label ID="Label14" runat="server" meta:resourcekey="lblFlights">Flights</asp:Label></a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="HotelFeature" class="IBE_package_List_dl_list_detail" style="display: none;
            width: 100%;" title="features">
            <div class="description">
                <h4>
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
        <div id="Location" class="IBE_package_List_dl_list_map2" style="display: none;" title="map">
            <div class="description">
                <h4>
                    <asp:Label ID="Label9" runat="server" meta:resourcekey="lblLocationDescription">Location Description</asp:Label></h4>
                <p>
                    <asp:Label ID="lblLocation" runat="server"></asp:Label></p>
            </div>
            <div class="description">
                <h4>
                    <asp:Label ID="Label10" runat="server" meta:resourcekey="lblMap">Map</asp:Label></h4>
                <br />
                <asp:Image ID="imgMapUrl" runat="server" />
            </div>
        </div>
        <div id="photo" class="IBE_package_List_dl_list_photos" style="display: none" title="photos">
            <h4>
                <asp:Label ID="Label11" runat="server" meta:resourcekey="lblPhotos">Photos</asp:Label></h4>
            <div class="show">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Repeater ID="GridView1" runat="server">
                            <ItemTemplate>
                                <div style="float: left; text-align: center; margin: 8px; display: inline;">
                                    <asp:Image ID="imgRoom" Width="150" Height="150" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Filename")%>' />
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
        <asp:Panel title="flights" ID="Panel1" runat="server" CssClass="IBE_package_List_dl_list_flight"
            Style="display: none;">
            <%--<div id="Flights" class="IBE_package_List_dl_list_flights" style="display: none;
                width: 100%;" title="flights">--%>
            <div id="ctl00_MainContent_dlAvailableFlight_ctl00_Panel1" title="TripDetail" style="width: 100%;
                float: left;" align="center">
                <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 6px;
                    float: left; text-align: left;">
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
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
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
                                                            <%--<asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                </asp:Label>--%>
                                                            <asp:Label ID="lblDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                            </asp:Label>
                                                            <br />
                                                            <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                            </asp:Label>
                                                            (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                            </asp:Label>)<br />
                                                        </td>
                                                        <td width="25%">
                                                            <%--<asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                </asp:Label>--%>
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
                                        <asp:Label ID="lbDispMessage1" ForeColor="black" runat="server" Visible="false" Style="text-align: center;
                                            margin: 0 auto;"></asp:Label>
                                        <asp:Label ID="lbDispMessage" ForeColor="black" runat="server" Visible="false" Style="text-align: center;
                                            margin: 0 auto;"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <%--</div>--%>
        </asp:Panel>
        <div class="IBE_package_selRoom_checkinfo" title="btn">
            <asp:Label ID="Label17" runat="server">
                <asp:Label ID="Label18" runat="server" CssClass="fB" meta:resourcekey="lblCheckIn">Check In:</asp:Label>&nbsp;
                <asp:Label ID="lblCheckIn" runat="server" Text='<%# ((HotelProfile)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0].Profile).CheckInDate.ToString("MM/dd/yyyy") %>'></asp:Label>
                (From: 3:00 PM)</asp:Label><span>&nbsp;&nbsp;</span>
            <asp:Label ID="Label20" runat="server">
                <asp:Label ID="Label21" runat="server" CssClass="fB" meta:resourcekey="lblCheckOut">Check Out:</asp:Label>&nbsp;
                <asp:Label ID="lblCheckOut" runat="server" Text='<%# ((HotelProfile)((List<TERMS.Business.Centers.SalesCenter.Hotel>)DataBinder.Eval(Container, "DataItem"))[0].Profile).CheckOutDate.ToString("MM/dd/yyyy") %>'></asp:Label>
                (From: 3:00 PM) </asp:Label>
        </div>
        <%--    </ItemTemplate>
</asp:DataList>--%>
        <div style="width: 100%; float: left;" title="Room">
            <asp:DataList ID="dlHotel" runat="server" Width="100%" OnItemDataBound="dlHotel_ItemDataBound">
                <ItemTemplate>
                    <table align="center" border="0" cellpadding="0" cellspacing="1" width="100%">
                        <tr>
                            <td align="left">
                                <div class="IBE_package_tourDayT" align="left" style="border-bottom: 1px solid #ccc;">
                                    <span class="IBE_package_SearchCondition_font_MV">
                                        <asp:Label ID="lblroom" runat="server" Font-Bold="True" meta:resourcekey="lblroom">Room</asp:Label>
                                        #<asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1%>'
                                            Font-Bold="True"></asp:Label>: </span>&nbsp;&nbsp; &nbsp;<asp:Label ID="Label2" runat="server"
                                                Text='<%# DataBinder.Eval(Container.DataItem, "Profile.AdultNumber").ToString() %>'
                                                Font-Bold="True">
                                            </asp:Label><asp:Label ID="Label1" runat="server" Text=" "></asp:Label><asp:Label
                                                ID="lblAdult" runat="server" meta:resourcekey="lblAdult">Adult(s)</asp:Label><asp:Label
                                                    ID="lblChildNumber" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString().Trim() == "0" ? "" : ", " + DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString() %>'></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text=" "></asp:Label>
                                    <asp:Label ID="lblChild" runat="server" meta:resourcekey="lblChild" Visible='<%# DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString().Trim() == "0" ? false : true%>'>&nbsp;Child(ren)</asp:Label>
                                </div>
                                <br />
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="82%" valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top">
                                                        <%--                                                        <table border="0" cellpadding="5" cellspacing="0" width="100%" class="T_step03" style="border-top: 1px solid #D8D8D8;">
                                                            <tr class="R_stepbox">
                                                                <td bgcolor="#eeeeee" style="border-bottom: 1px solid #D8D8D8;" width="240">
                                                                    <asp:Label ID="lblRoomtype" runat="server" meta:resourcekey="lblRoomtype">Room&nbsp;type</asp:Label>
                                                                </td>
                                                                <td bgcolor="#eeeeee" style="border-bottom: 1px solid #D8D8D8;">
                                                                </td>
                                                                <td width="100" align="right" bgcolor="#eeeeee" style="border-bottom: 1px solid #D8D8D8;">
                                                                    <asp:Label ID="lblavgpernight" runat="server" meta:resourcekey="lblavgpernight">avg per room/night</asp:Label></td>
                                                            </tr>
                                                        </table>--%>
                                                        <asp:DataList ID="dlRoom" runat="server" Width="100%" DataSource='<%# DataBinder.Eval(Container.DataItem, "Items") %>'>
                                                            <ItemTemplate>
                                                                <table id="cell" width="100%" border="0" cellpadding="8" cellspacing="0" runat="server">
                                                                    <tr>
                                                                        <td width="5%" height="33" align="center" style="border-bottom: 1px solid #D8D8D8;">
                                                                            <asp:Label ID="lblCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Code") %>'
                                                                                Visible="false"></asp:Label><asp:Label ID="lblRoomId" runat="server" Text="" Visible="false"></asp:Label>
                                                                            <asp:RadioButton ID="rabRoomType" runat="server" Checked='<%#  DataBinder.Eval(Container.DataItem, "Selected") %> ' /></td>
                                                                        <td width="36%" style="border-bottom: 1px solid #D8D8D8;" class="IBE_T_font_11">
                                                                            <asp:Label ID="lblRoomType1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Name") %>'></asp:Label>
                                                                            <br />
                                                                            <asp:Label ID="lblBreakfast2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Breakfast") != "" ? "Included " + DataBinder.Eval(Container.DataItem, "Breakfast").ToString() + " Breakfast" : "Not included breakfast"%> '></asp:Label><br />
                                                                            <asp:Label ID="lblHotelSTATUS" runat="server" Text="" Visible="true"></asp:Label>
                                                                        </td>
                                                                        <td width="30%" align="center" style="border-bottom: 1px solid #D8D8D8;">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td width="100%">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td width="29%" align="center" class="t09" style="border-bottom: 1px solid #D8D8D8;">
                                                                            <asp:Label ID="lblPireType" CssClass="IBE_T_font_11" runat="server" Text=""></asp:Label><asp:Label
                                                                                ID="Label1" runat="server" Text=" "></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
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
        </div>
        <div style="width: 100%; float: left; text-align: right;" title="Change">
            <div class="aaa">
                <div class="IBE_package_changeLB" align="right">
                    <img src="../../images/v2/arrow.gif" align="absmiddle" hspace="2">
                    <asp:HyperLink ID="hlChange" runat="server" CssClass="IBE_package_SearchCondition_f09"
                        meta:resourcekey="lblChangeHotel">Change Selected Hotel</asp:HyperLink>
                    &nbsp;&nbsp;</div>
            </div>
        </div>
    </ItemTemplate>
</asp:DataList>
