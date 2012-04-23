<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MapForm.aspx.cs" Inherits="MapForm" %>

<%@ Register Src="~/Page/Flight/Module/PageNumber.ascx" TagName="PageNumberControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="Navigation" TagPrefix="uc8" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="System" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>

    <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=<%=GoogleMapKey%>&amp;hl=en"
        type="text/javascript"></script>

    <script language="javascript" src="../../CommJs/labeledmarker.js"></script>

    <style>
ul,li{ list-style:none; margin:0px; padding:0px;}

</style>
    <link href="<%=SaleWebSuffix + MainCssPath + "Map.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
      var map;
      var baseIcon;
      function load()
      {
        if (GBrowserIsCompatible())
        {
          var MapName = document.getElementById("lbMapName").innerHTML;
          var MapAreaX = document.getElementById("lbMapAreaX").innerHTML;
          var MapAreaY = document.getElementById("lbMapAreaY").innerHTML;
          var location = document.getElementById("lblocation").innerHTML;
                   
          MapName = MapName.split(',');
          MapAreaX = MapAreaX.split(',');
          MapAreaY = MapAreaY.split(',');
          location = location.split('~~~~');
          
          for(var i=0;i<MapName.length;i++)
          {
            //alert(location[i]);
            MapName[i] = MapName[i].replace(/'/g,"");
            MapAreaX[i] = MapAreaX[i].replace(/'/g,"");
            MapAreaY[i] = MapAreaY[i].replace(/'/g,"");
            location[i] = location[i].replace(/'/g,"");
          }
          
          map = new GMap2(document.getElementById("map"));
          map.setCenter(new GLatLng(MapAreaX[0], MapAreaY[0]), 12);
          map.setMapType(G_NORMAL_MAP);
          map.addControl(new GLargeMapControl());
          map.addControl(new GMapTypeControl());
          
          
          baseIcon = new GIcon();
          baseIcon.shadow = "http://ditu.google.com/mapfiles/shadow50.png";
          baseIcon.iconSize = new GSize(30, 32);
          baseIcon.shadowSize = new GSize(47, 32);
          baseIcon.iconAnchor = new GPoint(9, 34);
          baseIcon.infoWindowAnchor = new GPoint(9, 2);
          baseIcon.infoShadowAnchor = new GPoint(18, 25);
          
         
          for(var i=0; i<MapName.length;i++)
          {
            var tip = MapName[i];
            var x = MapAreaX[i];
            var y = MapAreaY[i];
            var win = location[i]
                        
            setMapArea(tip,x,y,win,i+1);
          }
        }
        else
        {
            alert("你使用的浏览器不支持 Google Map!")
        }
      }
      
      function setMapArea(tip,x,y,win,index)
      {
         // 利用我们的图标类，为这个标注创建一个带数字的图标
         var icon = new GIcon(baseIcon);
         icon.image = "http://www.majestic-vacations.com/images/mv/mv_mask" + index + ".gif";
         var point = new GMarker( new GLatLng(x, y),icon);
         
         GEvent.addListener(point, 'click', function(){
            point.openInfoWindowHtml(win);
          });
          
          GEvent.addListener(point, 'mouseover', function(){
            point.openInfoWindowHtml(win);
//            point.closeInfoWindowWithMouse();
          });
//          GEvent.addListener(point, 'mouseout', function(){
//            point.closeInfoWindow(); 
//          });
//          window.setTimeout(function(){point.closeInfoWindowHtml();},500);
           
          map.addOverlay(point);
      }
      
     
                 
      //选择一个地标

      function selectMarker(tip,x,y)
      {
         var point = new GLatLng(x,y);
         map.panTo(point,5);
         GoogleMapShowTip(map,point,tip);
      }
       
      //在指定坐标上显示tip提示
      function GoogleMapShowTip(myMap,point,text)
      {
        myMap.openInfoWindowHtml(point,text);
      }

      if (!objbeforeItem)
      {
          var objbeforeItem=null;
          var objbeforeItembackgroundColor=null;
      }
      function ItemOver(obj,tip,x,y)
      {
          if(objbeforeItem)
          {
              objbeforeItem.style.backgroundColor = objbeforeItembackgroundColor;
          }
          objbeforeItembackgroundColor = obj.style.backgroundColor;
          objbeforeItem = obj;
          obj.style.backgroundColor = "#eaeaea";
          
         
          
          selectMarker( tip,x,y);
      }
    </script>

</head>
<body onload="load()" onunload="GUnload()">
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Label ID="lbMapName" runat="server" CssClass="nonestyle"></asp:Label>
        <asp:Label ID="lbMapAreaX" runat="server" CssClass="nonestyle"></asp:Label>
        <asp:Label ID="lbMapAreaY" runat="server" CssClass="nonestyle"></asp:Label>
        <asp:Label ID="lblocation" runat="server" CssClass="nonestyle"></asp:Label>
        <div id="hpContainer" class="TableWidth1" align="center">
            <div id="ualbody" style="float: left;">
                <table cellpadding="0" cellspacing="0" id="ualbodyTable" width="100%">
                    <tr>
                        <td height="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <uc8:Navigation ID="Navigation1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top" id="bodyCol3">
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
                                                <td>
                                                    <b class="t09">
                                                        <asp:Label ID="lblCityName" runat="server" meta:resourcekey="lblCityName"></asp:Label>
                                                        <asp:Label ID="Label2" runat="server" Text=" "></asp:Label><asp:Label ID="lblHotel"
                                                            runat="server" meta:resourcekey="lblHotel">Hotel</asp:Label></b>
                                                </td>
                                                <td align="right" style="padding-bottom:6px;">
                                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="" Style="font-size: 13px;
                                                        font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; background-color: white;
                                                        padding: 0 0 2px 0; margin: 0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/hotellist_mv.jpg);
                                                        width: 173px; height: 30px; cursor: pointer" /></td>
                                            </tr>
                                            <tr>
                                                <td colspan=2>
                                                    <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                                                        <tr>
                                                            <td>
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                                                                    <tr class="R_step03" align="center">
                                                                        <td align="left" style="height: 30px">
                                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td width="23%">
                                                                                        <asp:Label ID="lblHotelRating" runat="Server" meta:resourcekey="lblHotelRating">Hotel Rating</asp:Label></td>
                                                                                    <td width="23%">
                                                                                        <asp:Label ID="lblSortby" runat="Server" meta:resourcekey="lblSortby">Sort by</asp:Label>
                                                                                    </td>
                                                                                    <td width="30%">
                                                                                        <asp:Label ID="lblHotelNameContains" runat="Server" meta:resourcekey="lblHotelNameContains">Find by hotel name</asp:Label>
                                                                                    </td>
                                                                                    <td width="20%">
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
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtContains" runat="server" CssClass="dropDownRes" Style="border: 1px solid #7C9CBC;"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlArea" runat="server">
                                                                                        </asp:DropDownList></td>
                                                                                    <td align="right" rowspan="2">
                                                                                        <asp:Button ID="btnShow" runat="server" Text="Show" OnClick="btnShow_Click" Style="cursor: pointer;
                                                                                            background: #fdeada; height: 20px; border: 1px solid #ff9900; color: #333333;"
                                                                                            meta:resourcekey="btnShow" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td align="right">
                                                                            <%--<asp:Button ID="Button1" runat="server" Style="cursor: pointer; background: #fdeada;
                                                                                height: 20px; border: 1px solid #ff9900; color: #333333;" Text="List of hotels"
                                                                                OnClick="Button1_Click" meta:resourcekey="Button1" />--%>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan=2>
                                                    <table runat="server" cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td>
                                                                <div class="IBE_hotel_maplist">
                                                                    <asp:DataList ID="dlHotelInfo" runat="server" OnItemDataBound="dlHotelInfo_ItemDataBound"
                                                                        Width="100%">
                                                                        <ItemTemplate>
                                                                            <table id="temp1" runat="server" cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <div class="IBE_hotel_maplist_hotel">
                                                                                                        <div class="IBE_hotel_maplist_hotel_img">
                                                                                                            <%# Container.ItemIndex + 1 %>
                                                                                                        </div>
                                                                                                        <div class="IBE_hotel_maplist_hotel_rote">
                                                                                                            <ul>
                                                                                                                <li class="IBE_hotel_maplist_hotelName_style">
                                                                                                                    <asp:Label ID="lbHotelName" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Name %>'></asp:Label></li>
                                                                                                                <li>
                                                                                                                    <img src="../../images/star<%#  ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Class %>.gif"
                                                                                                                        border="0" align="absMiddle" /></li>
                                                                                                            </ul>
                                                                                                            <div class="clear">
                                                                                                                <asp:Label ID="lby" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Position.LongitudeNoun.DecimalCode %>'></asp:Label><asp:Label
                                                                                                                    ID="lbx" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Position.LatitudeNoun.DecimalCode %>'></asp:Label>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="IBE_hotel_maplist_hotel_price">
                                                                                                            <span class="IBE_hotel_maplist_hotel_price_style1">$</span><span class="IBE_hotel_maplist_hotel_price_style2"><asp:Label
                                                                                                                ID="lbTotalPrice" runat="server" Text='<%# Convert.ToDecimal(Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "RoomPricePerNight"))/Convert.ToDecimal(DataBinder.Eval(Container.DataItem, "Items.Count"))).ToString("N2") %>'></asp:Label></span><br />
                                                                                                            <span class="IBE_hotel_maplist_hotel_price_style3">
                                                                                                                <asp:Label ID="Label6" runat="Server" meta:resourcekey="lblavgpernight">avg per room/night</asp:Label></span></div>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <div style="display: none"><asp:Label ID="lblGTACityCode" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).City.GTACode %>' Visible=false></asp:Label>
                                                                                <asp:Image ID="imgHotelIMG" runat="server" Width="100px" Height="100px" ImageUrl='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT") == null || ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT").Filename == null ? "http://www.majestic-vacations.com/images/v1/defaulth.gif" : ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).GetImage("FRONT").Filename.Trim()%>' onerror="this.src='http://www.majestic-vacations.com/images/v1/defaulth.gif';" />
                                                                                <asp:Label ID="lblHotelID" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).HotelCode %>'></asp:Label>
                                                                                <asp:Label ID="Label3" runat="server" Text='<%# ((TERMS.Common.Hotel) DataBinder.Eval(Container.DataItem, "HotelInformation")).Address %>'></asp:Label>
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:DataList>
                                                                </div>
                                                            </td>
                                                            <td>
                                                                <div id="map" style="width: 600px; height: 450px">
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan=2>
                                                    <table id="Table2" runat="server" cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td height="2">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table runat="server" cellpadding="0" cellspacing="0" border="0" width="310">
                                                        <tr>
                                                            <td height="8" align="left">
                                                                <uc3:PageNumberControl ID="PageNumberControl1" runat="server"></uc3:PageNumberControl>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="1">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- footer.jsp | begin -->
        <uc2:Footer ID="Footer1" runat="server" />
        <!-- footer.jsp | end -->
    </form>
</body>
</html>
