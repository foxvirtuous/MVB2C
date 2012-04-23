<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HTLSelectRoomTypeControl.ascx.cs"
    Inherits="HTLSelectRoomTypeControl" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>

<script type="text/javascript"> 
 function CancelSelect(obj,tempSpan,cell)
 {
    //window.alert(obj);
     elems = obj.form.elements;  
     var strTemp = tempSpan;
     var ttt = tempSpan.substr(0,39);
     
     for(i=0;i<elems.length;i++)
     {
        if (elems[i].type=="radio" && elems[i].name.substr(0,39) == ttt)
        {
          if (elems[i].type=="radio" && elems[i].id != obj.id && obj.name.substr(0,52) == strTemp)
          {
            elems[i].checked = false;
            document.getElementById(elems[i].id.substr(0,52) + "_cell").style.backgroundColor="#fff";
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
    
    fillMarkup();
 }
 
 function fillMarkup()
 {    
    var elems = document.getElementById("form1").getElementsByTagName("INPUT");
    
    var pirce = 0;
    var pirce1 = 0;
    
    var Roompriceflag = false;
    
    var night = document.getElementById("ctlHotelInfoControl_lblDayNumber").innerHTML;
    
    
    for(i=0;i<elems.length;i++)
    {
        if (elems[i].type=="radio")
        {
            if (elems[i].checked)
            {
                var pirename = elems[i].id.replace('rabRoomType', 'lblPireType');
    
                if (document.getElementById(pirename) != null)
                {
                    var pirce1 = document.getElementById(pirename).innerHTML.replace('$', '');
                    
                    if (Number(pirce1) > 100)
                    {
                        Roompriceflag = true;
                    }
                    
                    pirce = Number(pirce) + Number(pirce1);
                }
            }
        }
    }
    pirce = Number(pirce) * Number(night);
    if (document.getElementById("HTLSelectRoomTypeControl1_lblSubtotal") != null)
    {
        document.getElementById("HTLSelectRoomTypeControl1_lblSubtotal").innerHTML =changeTwoDecimal_f(pirce);   
    }    
    
    if (Roompriceflag && document.getElementById("HTLSelectRoomTypeControl1_lblpricerota") != null)
    {
        if (Roompriceflag)
        {
            document.getElementById("HTLSelectRoomTypeControl1_lblpricerota").style.display = "";
            var mark = Number(pirce) * 0.2;
            mark = changeTwoDecimal_f(mark);
            mark = "(Max $" + mark + ")"
            document.getElementById("HTLSelectRoomTypeControl1_lblpricerota").innerHTML = mark;
            document.getElementById("HTLSelectRoomTypeControl1_priceflag").value = "YES";
            
        }
        else
        {
            document.getElementById("HTLSelectRoomTypeControl1_lblpricerota").style.display = "none";
            document.getElementById("HTLSelectRoomTypeControl1_lblpricerota").innerHTML = "";
            document.getElementById("HTLSelectRoomTypeControl1_priceflag").value = "NO";
        }        
    }    
    
    if (document.getElementById("HTLSelectRoomTypeControl1_txtSubagentMarkup") != null)
    {
        if (Number(document.getElementById("HTLSelectRoomTypeControl1_txtSubagentMarkup").value) > 0)
        {
            pirce1 = Number(pirce) + Number(document.getElementById("HTLSelectRoomTypeControl1_txtSubagentMarkup").value);
        }
        else
        {
            pirce1 = Number(pirce);
        }
    }
    else
    {
        pirce1 = Number(pirce);
    }    
    if (document.getElementById("HTLSelectRoomTypeControl1_lblSum") != null)
    {
        document.getElementById("HTLSelectRoomTypeControl1_lblSum").innerHTML = changeTwoDecimal_f(pirce1);
    } 
    
    if (document.getElementById("HTLSelectRoomTypeControl1_txtSubagentMarkup") != null && document.getElementById("HTLSelectRoomTypeControl1_txtSubagentMarkup").value != "")  
    {
        if (document.getElementById("HTLSelectRoomTypeControl1_priceflag").value == "YES")
        {
            var txtmark = document.getElementById("HTLSelectRoomTypeControl1_txtSubagentMarkup").value;
            
            if (Number(txtmark) > Number(pirce) * 0.2)
            {
                alert('Max markup should be less than $' + changeTwoDecimal_f(Number(pirce) * 0.2));
                document.getElementById("HTLSelectRoomTypeControl1_txtSubagentMarkup").focus();

            }
        }
    }    
 }
 function changeTwoDecimal_f(x)
{
   var f_x = parseFloat(x);
   if (isNaN(f_x))
   {
      alert('function:changeTwoDecimal->parameter error');
      return false;
   }
   var f_x = Math.round(x*100)/100;
   var s_x = f_x.toString();
   var pos_decimal = s_x.indexOf('.');
   if (pos_decimal < 0)
   {
      pos_decimal = s_x.length;
      s_x += '.';
   }
   while (s_x.length <= pos_decimal + 2)
   {
      s_x += '0';
   }
   return s_x;
}
 
    
</script>
<input id="priceflag" type="hidden" value="NO" runat="server" />
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <div class="MV_hotel_step">
                <div class="MV_hotel_step_T_line01 left">
                    &gt;</div>
                <span class="left">&nbsp;
                    <asp:Label ID="lblSelectRoomType" runat="Server" meta:resourcekey="lblSelectRoomType">Select Room Type</asp:Label></span></div>
        </td>
    </tr>
    <tr>
        <td height="10">
        </td>
    </tr>
    <tr>
        <td>
            <table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                <tr class="R_stepo">
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left" style="height: 19px">
                                    <b class="t09">
                                        <asp:Label ID="lblHotelName" runat="Server"></asp:Label>
                                    </b>
                                </td>
                                <td align="right" style="height: 19px">
                                    <span class="D_stepg">
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="d09">
                                            <img src="<%=SaleWebSuffix%>images/v2/arrow.gif" hspace="2" border="0" align="absmiddle" /><asp:Label
                                                ID="lblChangeSelectedHotel" runat="Server" meta:resourcekey="lblChangeSelectedHotel"
                                                CssClass="d09">Change Selected Hotel</asp:Label></asp:HyperLink></span></td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                        </table>
                        <asp:DataList ID="dlHotel" runat="server" Width="100%" OnItemDataBound="dlHotel_ItemDataBound">
                            <ItemTemplate>
                                <table border="0" cellpadding="2" cellspacing="0" width="100%" class="T_step03">
                                    <tr align="center" class="R_stepw">
                                        <td height="25" align="left" class="t04">
                                            <span class="tour_day">
                                                <asp:Label ID="lblroom" runat="server" Font-Bold="True" meta:resourcekey="lblroom">Room</asp:Label>
                                                #<asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1%>'
                                                    Font-Bold="True"></asp:Label>:&nbsp;&nbsp; &nbsp;<asp:Label ID="Label2" runat="server"
                                                        Text='<%# DataBinder.Eval(Container.DataItem, "Profile.AdultNumber").ToString() %>'
                                                        Font-Bold="True">
                                                    </asp:Label><asp:Label ID="Label1" runat="server" Text=" "></asp:Label><asp:Label
                                                        ID="lblAdult" runat="server" meta:resourcekey="lblAdult">Adult(s)</asp:Label><asp:Label
                                                            ID="lblChildNumber" runat="server" Font-Bold="true" Text='<%# DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString().Trim() == "0" ? "" : ", " + DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString() %>'></asp:Label>
                                                <asp:Label ID="Label3" runat="server" Text=" "></asp:Label>
                                                <asp:Label ID="lblChild" runat="server" meta:resourcekey="lblChild" Visible='<%# DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString().Trim() == "0" ? false : true%>'>&nbsp;Child(ren)</asp:Label>
                                            </span>
                                            <br />
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="82%" valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table border="0" cellpadding="5" cellspacing="0" width="100%" class="T_step03" style="border-top: 1px solid #D8D8D8;">
                                                                        <tr class="R_stepbox">
                                                                            <td bgcolor="#eeeeee" style="border-bottom: 1px solid #D8D8D8;" width="240">
                                                                                <asp:Label ID="lblRoomtype" runat="server" meta:resourcekey="lblRoomtype">Room&nbsp;type</asp:Label>
                                                                            </td>
                                                                            <asp:Repeater ID="Repeater1" DataSource='<%# DataBinder.Eval(Container.DataItem, "Weekdays") %>'
                                                                                runat="server">
                                                                                <ItemTemplate>
                                                                                    <td align="center" bgcolor="#eeeeee" style="border-bottom: 1px solid #D8D8D8;">
                                                                                        <asp:Label ID="lblDay1" runat="server" Width="40" Text='<%# DataBinder.Eval(Container.DataItem, "Day") %>'></asp:Label>
                                                                                    </td>
                                                                                </ItemTemplate>
                                                                            </asp:Repeater>
                                                                            <td width="100" align="right" bgcolor="#eeeeee" style="border-bottom: 1px solid #D8D8D8;">
                                                                                <asp:Label ID="lblavgpernight" runat="server" meta:resourcekey="lblavgpernight">avg per room/night</asp:Label><BR /><asp:Label ID="Label6" runat="server" meta:resourcekey="lblavgpernight1">Including taxes and service fees</asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                    <asp:DataList ID="dlRoom" runat="server" Width="100%" DataSource='<%# DataBinder.Eval(Container.DataItem, "Items") %>'
                                                                        OnItemDataBound="dlRoom_ItemDataBound">
                                                                        <ItemTemplate>
                                                                            <table id="cell" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">
                                                                                <tr>
                                                                                    <td width="5%" height="33" align="center" style="border-bottom: 1px solid #D8D8D8;">
                                                                                        <asp:Label ID="lblCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Code") %>'
                                                                                            Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblRoomID" runat="server" Text="" Visible="false"></asp:Label>
                                                                                        <asp:RadioButton ID="rabRoomType" runat="server" Checked='<%#  DataBinder.Eval(Container.DataItem, "Selected") %> ' /></td>
                                                                                    <td width="26%" style="border-bottom: 1px solid #D8D8D8;">
                                                                                        <asp:Label ID="lblRoomType1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Name") %>'></asp:Label>
                                                                                        <br />
                                                                                        <asp:Label ID="lblBreakfast2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Breakfast") != "" ? "Included " + DataBinder.Eval(Container.DataItem, "Breakfast").ToString() + " Breakfast" : "Not included breakfast"%> '></asp:Label><br />
                                                                                        <asp:Label ID="lblHotelSTATUS" runat="server" Text="" Visible=true></asp:Label>
                                                                                    </td>
                                                                                    <td width="57%" align="center" style="border-bottom: 1px solid #D8D8D8;">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                            <asp:Repeater runat="server" ID="Repeater2">
                                                                                                <ItemTemplate>
                                                                                                    <tr>
                                                                                                        <td width="24" height="35" align="center" >
                                                                                                            WK<%# Container.ItemIndex + 1%></td>
                                                                                                        <asp:Repeater ID="Repeater3" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "WeekPrices") %>'>
                                                                                                            <ItemTemplate>
                                                                                                                <td align="center">
                                                                                                                    <asp:Label ID="lblPrice1" runat="server" Width="40" Text='<%# DataBinder.Eval(Container.DataItem, "WPrice") %>'></asp:Label>
                                                                                                                </td>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:Repeater>
                                                                                                    </tr>
                                                                                                </ItemTemplate>
                                                                                            </asp:Repeater>
                                                                                        </table><div runat=server id="divErrorMessage" style="text-align:left" ><font color=red>
                                                                                        <asp:Label ID="lblErrorMessage" runat="server" Text="" style="font-size:9px"></asp:Label></font></div><asp:Label ID="lblProPrices" runat="server" Text="" style="font-size:9px" Visible=false></asp:Label>
                                                                                        
                                                                                    </td>
                                                                                    <td width="100" align="center" class="t09" style="border-bottom: 1px solid #D8D8D8;">
                                                                                        <asp:Label ID="lblPireType" CssClass="orglab" runat="server" Text=""></asp:Label><asp:Label
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
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="5">
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left">
                                    <a href="javascript:void(0)" class="MV_hotel_List_dl_d09" onclick="showDetail('features');">
                                        <asp:Label ID="hlFeatures1" runat="server" meta:resourcekey="hlFeatures">View Features &amp; Amenities</asp:Label>
                                    </a>|
                                    <%--<a href="javascript:void(0)" class="MV_hotel_List_dl_d09" onclick="showDetail('map');">
                                        <asp:Label ID="hlLocations1" runat="server" meta:resourcekey="hlLocations">View Map &amp; Locations</asp:Label></a>
                                    | --%>
                                    <a href="javascript:void(0)" class="MV_hotel_List_dl_d09" onclick="showDetail('photos');">
                                        <asp:Label ID="hlphotos1" runat="server" meta:resourcekey="hlphotos">View photos</asp:Label></a>
                                </td>
                        </table>
                        <div id="HotelFeature" style="display: none">
                            <div class="MV_hotel_hotelInfor_FandA">
                                <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                    <tr>
                                        <td align="center" valign="top">
                                            <asp:Image Width="160" ID="imgHotel" runat="server" /></td>
                                        <td width="70%" valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top">
                                                        <b>
                                                            <asp:Label ID="lblOurRating" runat="Server" meta:resourcekey="lblOurRating">Our Rating</asp:Label>:</b>
                                                        <asp:Image border="0" align="absmiddle" ID="imgstar3" runat="server" /><br />
                                                        <b>
                                                            <asp:Label ID="lblAddress1" runat="Server" meta:resourcekey="lblAddress">Address</asp:Label>:</b>
                                                        <br>
                                                        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label><br>
                                                        <b>
                                                            <asp:Label ID="Label5" runat="Server" meta:resourcekey="lblAddress1">Features & Amenities</asp:Label>:</b>
                                                        <asp:Label ID="lblList" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div id="Location" style="display: none">
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
                        <div id="photo" style="display: none">
                            <div class="MV_hotel_hotelInfor_FandA">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top">
                                            <b>
                                                <asp:Label ID="lblPhotos1" runat="Server" meta:resourcekey="lblPhotos">Photos</asp:Label>:</b>
                                            <br>
                                            <center>
                                                <div class="show">
                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Repeater ID="GridView1" runat="server">
                                                                <ItemTemplate>
                                                                    <div style="float: left; text-align: center; margin: 8px;">
                                                                        <asp:Image ID="imgRoom" Width="150" Height="150" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Filename")%>' />
                                                                        <p>
                                                                            <asp:Label ID="lblRoomName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                                                                        </p>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </center>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td>
            <div class="MV_hotel_step">
                <div class="MV_hotel_step_T_line01 left">
                    &gt;</div>
                <span class="left">&nbsp;
                    <asp:Label ID="Label4" runat="Server" meta:resourcekey="lblPrice">Price</asp:Label></span></div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:PlaceHolder ID="phAgentFlightMarkup" runat="server">
                <div class="total1" style="text-align: right;">
                    <span style="font-size: 11px; font-family: Verdana;">Subtotal: $<asp:Label ID="lblSubtotal"
                        runat="server" Text="Label"></asp:Label></span></div>
                <div class="total1" style="text-align: right;" runat="server" id="divSubagent">
                    <span style="font-size: 11px; font-family: Verdana;">Markup <asp:Label style="display:none" id="lblpricerota" runat="server" />: $
                        <asp:TextBox ID="txtSubagentMarkup" runat="server" Width="50px" MaxLength="6" autocomplete="off" onkeypress="if(!this.value.match(/^[\0\1]?\d*?\.?\d*?$/))this.value=this.t_value;else this.t_value=this.value;if(this.value.match(/^(?:[\0\1]?\d+(?:\.\d+)?)?$/))this.o_value=this.value" onkeyup="if(!this.value.match(/^[\0\1]?\d*?\.?\d*?$/))this.value=this.t_value;else this.t_value=this.value;if(this.value.match(/^(?:[\0\1]?\d+(?:\.\d+)?)?$/))this.o_value=this.value" 
                            onblur="fillMarkup()">
                        </asp:TextBox>
                        <asp:Label ID="lblAgentAdultUnitMarkup" runat="server" Text="" Visible="false" />
                    </span>
                </div>
            </asp:PlaceHolder>
            <div class="total1">
                <span class="totalprice_15px">Total Cost: $<asp:Label ID="lblSum" runat="server"
                    Text="Label"></asp:Label></span></div>
        </td>
    </tr>
</table>

<script type="text/javascript">
  function showDetail(meta){
   if(meta == "features")
   {
        if(document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML == "View Features &amp; Amenities")
        {
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML = "Hide Features &amp; Amenities";
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").parentNode.style.color = "#FFA500";
            document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").parentNode.style.color = "";
            document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML = "View photos"; 
        }
        else if(document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML == "Hide Features &amp; Amenities")
        {
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML = "View Features &amp; Amenities";
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").parentNode.style.color = "";
        }
        else if(document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML == "ï@Ê¾ïˆµêÔO‚ä")
        {
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML = "ë[²ØïˆµêÔO‚ä";
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").parentNode.style.color = "#FFA500";
            document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").parentNode.style.color = "";
            document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML = "ï@Ê¾ïˆµêÕÕÆ¬"; 
        }
        else if(document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML == "ë[²ØïˆµêÔO‚ä")
        {
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML = "ï@Ê¾ïˆµêÔO‚ä";
            document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").parentNode.style.color = "";
        }
        
        
        if(document.getElementById("HotelFeature").style.display == "")
        {
            document.getElementById("HotelFeature").style.display = "none";
        }
        else
        {
            document.getElementById("HotelFeature").style.display = "";
        }
         
        document.getElementById("Location").style.display = "none";
        document.getElementById("photo").style.display = "none";
   }
   if(meta == "photos")
   {
       if(document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML == "View photos")
       {
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML = "Hide photos";
           document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML = "View Features &amp; Amenities";
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").parentNode.style.color = "#FFA500";
           document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").parentNode.style.color = "";
       }
       else if(document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML == "Hide photos")
       {
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML = "View photos";
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").parentNode.style.color = "";
           
       }
       else if(document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML == "ï@Ê¾ïˆµêÕÕÆ¬")
       {
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML = "ë[²ØïˆµêÕÕÆ¬";
           document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").innerHTML = "ï@Ê¾ïˆµêÔO‚ä";
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").parentNode.style.color = "#FFA500";
           document.getElementById("HTLSelectRoomTypeControl1_hlFeatures1").parentNode.style.color = "";
       }
       else if(document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML == "ë[²ØïˆµêÕÕÆ¬")
       {
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").innerHTML = "ï@Ê¾ïˆµêÕÕÆ¬";
           document.getElementById("HTLSelectRoomTypeControl1_hlphotos1").parentNode.style.color = "";
       }
       
       if(document.getElementById("photo").style.display == "")
       {
            document.getElementById("photo").style.display = "none";
       }
       else
       {  
            document.getElementById("photo").style.display = "";
       }
       document.getElementById("HotelFeature").style.display = "none";
       document.getElementById("Location").style.display = "none";
       
    }
  }
</script>



