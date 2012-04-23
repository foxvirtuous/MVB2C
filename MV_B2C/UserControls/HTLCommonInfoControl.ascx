<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HTLCommonInfoControl.ascx.cs"
    Inherits="HTLCommonInfoControl" %>
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
                                  
                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Features";
            }
//            else if(tabName == "Location")
//            {
//                 document.getElementById("HotelFeature").style.display = "none";
//                 document.getElementById("photo").style.display = "none";
//                 document.getElementById("Location").style.display = "";
//                                  
//                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Location";
//            }
            else if(tabName == "Photo")
            {
                 document.getElementById("HotelFeature").style.display = "none";
                 document.getElementById("photo").style.display = "";
                 document.getElementById("Location").style.display = "none";
                                  
                 document.getElementById("HotelCommonInfoControl1_CurrentTab").value = "Photo";
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

<input id="CurrentTab" type="hidden" value="Room Types" name="DefaultTab" runat="server" />
<table width="100%">
    <tr>
        <td>
            <div class="MV_hotel_step">
                <div class="MV_hotel_step_T_line01 left">
                    &gt;</div>
                <span class="left">&nbsp;<asp:Label ID="lblHotelName" runat="server"></asp:Label></span>
            </div>
        </td>
        <td align="right">
            <asp:Button Text="continue to booking" ID="Button1" CssClass="search_btn05" runat="server"
                OnClick="ibtnSearch_Click" Style="cursor: pointer" meta:resourcekey="ibtnSearch" /></td>
    </tr>
</table>
<div class="MV_hotel_hotelInfor">
    <div>
        <div class="MV_hotel_hotelInfor_Tab">
            <ul>
                <li><span onclick="javascrit:tabChange('Features')" style="cursor: pointer">
                    <asp:Label ID="lblFeatures" runat="Server" meta:resourcekey="lblFeatures">Features & Amenities</asp:Label></span></li>
                <%--<li><span onclick="javascrit:tabChange('Location')" style="cursor: pointer">
                    <asp:Label ID="lblMapsLocations" runat="Server" meta:resourcekey="lblMapsLocations">Maps & Locations</asp:Label></span></li>--%>
                <li><span onclick="javascrit:tabChange('Photo')" style="cursor: pointer">
                    <asp:Label ID="lblPhotos" runat="Server" meta:resourcekey="lblPhotos">Photos</asp:Label></span></li>
            </ul>
        </div>
    </div>
    <div id="HotelFeature">
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
                                        <asp:Label ID="lblAddress1" runat="Server" meta:resourcekey="lblAddress1">Address</asp:Label>:</b>
                                    <br>
                                    <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label><br>
                                    <asp:Label ID="lblList" runat="server" Text=""></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <%--<div id="Location" style="display: none">
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
    </div>--%>
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
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                            PageSize="1" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging"
                                            ShowHeader="False" Style="border-top-style: none; border-right-style: none; border-left-style: none;
                                            border-bottom-style: none; background-color: transparent;" border="0" CellPadding="0"
                                            CellSpacing="0">
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
                        </center>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td height="7">
            </td>
        </tr>
        <tr>
            <td align="right" class="D_stepg">
                <asp:Button Text="Back" ID="imgBackFeature" CssClass="search_btn02" runat="server"
                    OnClick="imgBackFeature_Click" Style="cursor: pointer" meta:resourcekey="imgBackFeature" />&nbsp;&nbsp;
                <asp:Button Text="continue to booking" ID="ibtnSearch" CssClass="search_btn05" runat="server"
                    OnClick="ibtnSearch_Click" Style="cursor: pointer" meta:resourcekey="ibtnSearch" /></td>
        </tr>
        <tr>
            <td height="3">
            </td>
        </tr>
    </table>
</div>
