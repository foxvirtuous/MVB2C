<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelCommonInfo" Codebehind="HotelCommonInfo.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<%@ Import Namespace="System.Collections.Generic" %>

<script language="javascript">
 function CancelSelect(obj,tempSpan)
 {
     elem=obj.form.elements;  
     var strTemp = tempSpan;
     var ttt = tempSpan.substr(0,30);
     for(i=0;i<elem.length;i++)
     {
        if (elem[i].type=="radio" && elem[i].name.substr(0,30) == ttt)
        {
          if (elem[i].type=="radio" && elem[i].id != obj.id && obj.name.substr(0,43) == strTemp)
          {
            elem[i].checked = false;
          }
        }
     }
 }   
</script>

<div class="room_item">
    <ul>
        <li id="liFeatures"><span onclick="javascrit:tabChange('Features')">Features</span></li>
        <li id="liLocation"><span onclick="javascrit:tabChange('Location')">Maps &amp; Locations</span></li>
        <li id="liPhoto"><span onclick="javascrit:tabChange('Photo')">Photos</span></li>
        <li class="chosed" id="liRoomTypes"><span onclick="javascrit:tabChange('Room Types')">
            Room Rates</span></li>
    </ul>
</div>
<div id="HotelFeature" class="HotelFeature" style="display: none">
    <p class="tag">
        <a href="#">Hotel Description</a> | <a href="#">Hotel Amenities</a> | <a href="#">Remark</a></p>
    <div class="description">
        <h4>
            Hotel Description</h4>
        <div class="smallpic">
            <asp:Image ID="imgHotel" runat="server" ImageUrl="../images/westin.jpg" /></div>
        <strong>
            <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label></strong><br />
        Add: 
        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
        <br />
        <p>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
    </div>
    <div class="description">
        <h4>
            Hotel Amenities</h4>
        <ul>
            <asp:Label ID="lblList" runat="server" Text=""></asp:Label>
        </ul>
    </div>
    <div class="Remark">
        <h4>
            Remark</h4>
    </div>
    <div align="right">
        <input id="Submit5" class="btn_inbg" name="button" style="font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;" onclick="location.href='HotelSelectForm.aspx'" type="button" 
            value="Other Hotel" />
        <input id="Submit4" class="btn_inbg" name="button" style="font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;" onclick="javascrit:tabChange('Room Types')" type="button" value="Check Rates" /></div>
</div>
<div id="Location" class="Location" style="display: none">
    <p class="tag">
        <a href="#">Location Description</a> | <a href="#">Nearby Points of Interest</a>
        | <a href="#">Map</a></p>
    <div class="description">
        <h4>
            Location Description</h4>
        <p>
            <asp:Label ID="lblLocation" runat="server" Text="Label"></asp:Label></p>
    </div>
    <div class="description">
        <h4>
            Nearby Points of Interest</h4>
    </div>
    <div class="description">
        <h4>
            Map</h4>
            <br />
        <asp:Image ID="imgMapUrl" runat="server" />
    </div>
    <div align="right">
        <input id="Submit3" class="btn_inbg" name="button" style="font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;" onclick="location.href='HotelSelectForm.aspx'" type="button"
            value="Other Hotel" />
        <input id="Submit2" class="btn_inbg" name="button" style="font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;" onclick="javascrit:tabChange('Room Types')" type="button" value="Check Rates" /></div>
</div>
<div id="photo" class="photo" style="display: none">
    <h4>
        Photos</h4>
    <div class="show">
        <asp:Image ID="imgRoom" runat="server" />
        <p>
            <asp:Label ID="lblRoomName" runat="server" Text=""></asp:Label>
        </p>
        <p visible="false">
            <asp:HyperLink ID="hlPre" runat="server">Pre</asp:HyperLink> | 
            <asp:Label ID="lblNumber" runat="server" Text=""></asp:Label>/<asp:Label ID="lblSum"
                runat="server" Text=""></asp:Label> | <asp:HyperLink ID="hlNext" runat="server">Next</asp:HyperLink></p>
    </div>
    <div align="right">
        <input id="Submit1" class="btn_inbg" name="button" style="font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;" onclick="location.href='HotelSelectForm.aspx'" type="button"
            value="Other Hotel" />
        <input id="button" class="btn_inbg" name="button" style="font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;" onclick="javascrit:tabChange('Room Types')" type="button" value="Check Rates" /></div>
</div>
<div id="roomopt" class="roomopt">
    Check in date:
    <%--<div class="turn" visible="false">
        <img src="../Terms.Sales.Web/images/arrow_right.gif" width="11" height="11" />
        <a href="#" onclick="javascript:ShowHideChangeDate()">Change check in/out date</a>
    </div>--%>
    <asp:Label ID="lblCheckin" runat="server" Font-Bold="True"></asp:Label>| Check out
    date:
    <asp:Label ID="lblCheckout" runat="server" Font-Bold="True"></asp:Label><br />
    Check in time from: 3:00 PM | Check out time before: 12:00 PM
    <div id="changeIO" class="changeIO" style="display: none">
        <div class="name">
            Change Your Check In/Out Time</div>
        <div class="note">
            <asp:Label ID="lblStayMinAndMax" runat="server" Text="Hotel Stay Min: 4 nights / Max: 10 Nights"></asp:Label>
            <asp:DataList ID="dlCheckDate" runat="server" Width="100%">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td width="10%" class="orglab">
                                Period
                                <asp:Label ID="lblNumber" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                            </td>
                            <td width="45%">
                                Check In:
                                <uc1:Calendar ID="txtCheckin" runat="server" TooltipMessage="e.g., mm/dd/year" ImageUrl="~/Terms.Sales.Web/images/cal.jpg" />
                            </td>
                            <td width="45%">
                                Check Out:
                                <uc1:Calendar ID="txtCheckout" runat="server" TooltipMessage="e.g., mm/dd/year" ImageUrl="~/Terms.Sales.Web/images/cal.jpg" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList></div>
    </div>
    <div class="singleroom">
        <asp:DataList ID="dlHotel" runat="server" Width="100%">
            <ItemTemplate>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="roomoptlist">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="Label1" runat="server" Text="Room #" Font-Bold="True"></asp:Label>
                            <asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1%>'
                                Font-Bold="True"></asp:Label><asp:Label ID="Label2" runat="server" Text=" (2 Adults):"
                                    Font-Bold="True"></asp:Label>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkSmoking" runat="server" Checked="true" Text="Non-smoking" Visible="false" />
                        </td>
                    </tr>
                </table>
                <asp:DataList ID="dlRoom" runat="server" Width="100%" DataSource='<%# ((MVRoom)DataBinder.Eval(Container, "DataItem")).Items %>'>
                    <ItemTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="roomoptlist">
                            <tr>
                                <td width="5%">
                                    <asp:Label ID="lblCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Breakfast") %>'
                                        Visible="false"></asp:Label>
                                    <asp:RadioButton ID="rabRoomType" runat="server" Text="" /></td>
                                <td width="45%">
                                    <asp:Label ID="lblRoomType1" runat="server" Text='<%# ((Room)DataBinder.Eval(Container.DataItem, "Room")).Name %>'
                                        Visible="False"></asp:Label>
                                        <br />
                                    <asp:CheckBox ID="chkBreakfast" runat="server" Text="I need breakfast" Visible="False" />
                                    <asp:Label ID="lblRoomType2" runat="server" Text='<%# ((Room)DataBinder.Eval(Container.DataItem, "Room")).Name %>'
                                        Visible="False"></asp:Label>
                                        <br />
                                    <asp:Label ID="lblBreakfast2" runat="server" Text="Included breakfast" Visible="False"></asp:Label>
                                    <asp:Label ID="lblRoomType3" runat="server" Text='<%# ((Room)DataBinder.Eval(Container.DataItem, "Room")).Name %>'
                                        Visible="False"></asp:Label>
                                        <br />
                                    <asp:Label ID="lblBreakfast3" runat="server" Text="Not include breakfast" Visible="False"></asp:Label>
                                </td>
                                <td width="50%">
                                    <asp:Label ID="lblPireType" CssClass="orglab" runat="server" Text=""></asp:Label><asp:Label
                                        ID="lblTempAdd" runat="server" Text=" per room per night (avg.)"></asp:Label></td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div align="right">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/v1/btn_select.gif"
            OnClick="ImageButton1_Click" /></div>
</div>
