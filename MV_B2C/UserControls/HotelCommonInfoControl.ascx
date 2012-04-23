<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelCommonInfoControl" Codebehind="HotelCommonInfoControl.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<%@ Import Namespace="Terms.Base.Domain" %>
<%@ Import Namespace="Terms.Product.Domain" %>
<%@ Import Namespace="System.Collections.Generic" %>

<script type="text/javascript"> 
        function tabChange(tabName)
        {
            if(tabName == "Features")
            {
                 document.getElementById("HotelFeature").style.display = "";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("roomopt").style.display = "none";
                 
                 document.getElementById("liFeatures").className = "chosed";
                 document.getElementById("liLocation").className = "";
                 document.getElementById("liPhoto").className = "";
                 document.getElementById("liRoomTypes").className = "";
                 
                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Features";
            }
            else if(tabName == "Location")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "";
                 document.getElementById("roomopt").style.display = "none";
                 
                 document.getElementById("liFeatures").className = "";
                 document.getElementById("liLocation").className = "chosed";
                 document.getElementById("liPhoto").className = "";
                 document.getElementById("liRoomTypes").className = "";
                 
                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Location";
            }
            else if(tabName == "Photo")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("roomopt").style.display = "none";
                 
                 document.getElementById("liFeatures").className = "";
                 document.getElementById("liLocation").className = "";
                 document.getElementById("liPhoto").className = "chosed";
                 document.getElementById("liRoomTypes").className = "";
                 
                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Photo";
            }
            else if(tabName == "Room Types")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "none";
                 document.getElementById("Location").style.display = "none";
                 document.getElementById("roomopt").style.display = "";
                 
                 document.getElementById("liFeatures").className = "";
                 document.getElementById("liLocation").className = "";
                 document.getElementById("liPhoto").className = "";
                 document.getElementById("liRoomTypes").className = "chosed";
                 
                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Room Types";
            }
        }
        
        window.onload = function ChangeToCurrentTab()
        {
            tabChange(document.getElementById("HotelCommonInfoControl1_CurrentTab").value);
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
<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
<input id="CurrentTab" type="hidden" value="Room Types" name="DefaultTab" runat="server" />
<div class="room_item">
    <ul>
        <li id="liFeatures"><span onclick="javascrit:tabChange('Features')"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblFeatures">Features</asp:Label></span></li>
        <li id="liLocation"><span onclick="javascrit:tabChange('Location')"><asp:Label ID="Label3" runat="server" meta:resourcekey="lblMaps">Maps &amp; Locations</asp:Label></span></li>
        <li id="liPhoto"><span onclick="javascrit:tabChange('Photo')"><asp:Label ID="Label5" runat="server" meta:resourcekey="lblPhotos">Photos</asp:Label></span></li>
        <li class="chosed" id="liRoomTypes"><span onclick="javascrit:tabChange('Room Types')">
            <asp:Label ID="Label19" runat="server" meta:resourcekey="lblRoomRates">Room Rates</asp:Label></span></li>
    </ul>
</div>
<div id="HotelFeature" class="HotelFeature" style="display: none">
    <%-- <p class="tag">
        <a href="#">Hotel Description</a> | <a href="#">Hotel Amenities</a> | <a href="#">Remark</a></p>--%>
    <div class="description">
        <h4>
            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblHotelDescription">Hotel Description</asp:Label></h4>
        <div class="smallpic">
            <asp:Image ID="imgHotel" runat="server"  /></div>
        <strong>
            <asp:Label ID="lblHotelName" runat="server" Text=""></asp:Label></strong><br />
        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblAdd">Add</asp:Label>:
        <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label>
        <br />
        <p>
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label></p>
    </div>
    <div class="description">
        <h4>
            <asp:Label ID="Label8" runat="server" meta:resourcekey="lblHotelAmenities">Hotel Amenities</asp:Label></h4>
        <ul>
            <asp:Label ID="lblList" runat="server" Text=""></asp:Label>
        </ul>
    </div>
    <%--<div class="Remark">
        <h4>
            Remark</h4>
    </div>--%>
    <div align="right">
        <asp:ImageButton ID="imgBackFeature" runat="server" ImageUrl="~/images/v1/btn_back1.gif"
            OnClick="imgBackFeature_Click" />
        <img src="../../images/v1/btn_checkrates.gif" onclick="javascrit:tabChange('Room Types')"
            style="cursor: hand" />
    </div>
</div>
<div id="Location" class="Location" style="display: none">
    <%--<p class="tag">
        <a href="#">Location Description</a> | <a href="#">Nearby Points of Interest</a>
        | <a href="#">Map</a></p>--%>
    <div class="description">
        <h4>
            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblLocationDescription">Location Description</asp:Label></h4>
        <p>
            <asp:Label ID="lblLocation" runat="server"></asp:Label></p>
    </div>
<%--    <div class="description">
        <h4>
            Nearby Points of Interest</h4>
    </div>--%>
    <div class="description">
        <h4>
            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblMap">Map</asp:Label></h4>
        <br />
        <asp:Image ID="imgMapUrl" runat="server" />
    </div>
    <div align="right">
        <asp:ImageButton ID="imgBackLocation" runat="server" ImageUrl="~/images/v1/btn_back1.gif"
            OnClick="imgBackLocation_Click" />
        <img src="../../images/v1/btn_checkrates.gif" onclick="javascrit:tabChange('Room Types')"
            style="cursor: hand" />
    </div>
</div>
<div id="photo" class="photo" style="display: none">
    <h4>
        <asp:Label ID="Label11" runat="server" meta:resourcekey="lblPhotos">Photos</asp:Label></h4>
    <div class="show">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="1" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" ShowHeader="False" style="border-top-style: none; border-right-style: none; border-left-style: none; border-bottom-style: none; background-color: transparent;" border="0" cellpadding="0" cellspacing="0">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                               <asp:Image ID="imgRoom" runat="server" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Filename")%>' />
                        <p>
                            <asp:Label ID="lblRoomName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label>
                        </p>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
          </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <div align="right">
        <asp:ImageButton ID="imgBackPhoto" runat="server" ImageUrl="~/images/v1/btn_back1.gif"
            OnClick="imgBackPhoto_Click" />
        <img src="../../images/v1/btn_checkrates.gif" onclick="javascrit:tabChange('Room Types')"
            style="cursor: hand" />
    </div>
</div>
<div id="roomopt" class="roomopt">
    <asp:Label ID="Label12" runat="server" meta:resourcekey="lblCheckInDate">Check in date</asp:Label>:
    <%--<div class="turn" visible="false">
        <img src="../Terms.Sales.Web/images/arrow_right.gif" width="11" height="11" />
        <a href="#" onclick="javascript:ShowHideChangeDate()">Change check in/out date</a>
    </div>--%>
    <asp:Label ID="lblCheckin" runat="server" Font-Bold="True"></asp:Label>| <asp:Label ID="Label13" runat="server" meta:resourcekey="lblCheckOutDate">Check out date</asp:Label>:
    <asp:Label ID="lblCheckout" runat="server" Font-Bold="True"></asp:Label><br />
    <asp:Label ID="Label14" runat="server" meta:resourcekey="lblCheckInFrom">Check in time from: 3:00 PM</asp:Label> | <asp:Label ID="Label15" runat="server" meta:resourcekey="lblCheckOutBefore">Check out time before: 12:00 PM</asp:Label>
    <div id="changeIO" class="changeIO" style="display: none">
        <div class="name">
            <asp:Label ID="Label16" runat="server" meta:resourcekey="lblChangeTime">Change Your Check In/Out Time</asp:Label></div>
        <div class="note">
            <asp:Label ID="lblStayMinAndMax" runat="server" Text="Hotel Stay Min: 4 nights / Max: 10 Nights"></asp:Label>
            <asp:DataList ID="dlCheckDate" runat="server" Width="100%">
                <ItemTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                        <tr>
                            <td width="10%" class="orglab">
                                <asp:Label ID="Label16" runat="server" meta:resourcekey="lblPeriod">Period</asp:Label>
                                <asp:Label ID="lblNumber" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>
                            </td>
                            <td width="45%">
                                <asp:Label ID="Label17" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:&nbsp;<uc1:Calendar ID="txtCheckin" runat="server" />
                            </td>
                            <td width="45%">
                                <asp:Label ID="Label18" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:&nbsp;<uc1:Calendar ID="txtCheckout" runat="server" />
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
                            <asp:Label ID="Label1" runat="server" Text="Room #" Font-Bold="True" meta:resourcekey="lblRoom"></asp:Label>
                            <asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1%>'
                                Font-Bold="True"></asp:Label>:&nbsp;<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Profile.AdultNumber").ToString() + " Adult(s)"%>'
                                    Font-Bold="True"></asp:Label> <%--<asp:Label ID="Label18" runat="server" meta:resourcekey="lblAdult" Font-Bold="True"> Adult(s)</asp:Label>--%><asp:Label ID="lblChildNumber" runat="server" Font-Bold="true"
                                        Text='<%# DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString().Trim() == "0" ? "" : ", " + DataBinder.Eval(Container.DataItem, "Profile.ChildNumber").ToString() + " Child(ren)" %>'></asp:Label><%--<asp:Label ID="Label20" runat="server" meta:resourcekey="lblChild" Font-Bold="true"> Child(ren)</asp:Label>--%>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkSmoking" runat="server" Checked="true" Text="Non-smoking" Visible="false" />
                        </td>
                    </tr>
                </table>
                <asp:DataList ID="dlRoom" runat="server" Width="100%" DataSource='<%# DataBinder.Eval(Container.DataItem, "Items") %>'>
                    <ItemTemplate>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0" class="roomoptlist">
                            <tr>
                                <td width="5%">
                                    <asp:Label ID="lblCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Code") %>'
                                        Visible="false"></asp:Label>
                                    <asp:RadioButton ID="rabRoomType" runat="server" Checked='<%#  DataBinder.Eval(Container.DataItem, "Selected") %> ' /></td>
                                <td width="45%">
                                    <asp:Label ID="lblRoomType1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Name") %>'></asp:Label>
                                    <br />
                                    <asp:CheckBox ID="IsBuy" runat="server" Visible=false />
                                    <asp:Label ID="lblBreakfast2" runat="server" Text="Not included breakfast"></asp:Label>
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
        
        <asp:ImageButton ID="imgBackRoom" runat="server" ImageUrl="~/images/v1/btn_back1.gif"
            OnClick="imgBackRoom_Click" />
        <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/images/v1/btn_continue.gif"
            OnClick="ibtnSearch_Click" /></div>
</div>
