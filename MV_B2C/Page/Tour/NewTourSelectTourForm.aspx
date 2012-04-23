<%@ Page Language="C#" MasterPageFile="TourBookingPage.Master" AutoEventWireup="true"
    Codebehind="NewTourSelectTourForm.aspx.cs" Inherits="NewTourSelectTourForm" EnableEventValidation="false" %>

<%@ MasterType VirtualPath="TourBookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="printArea">

        <script language="javascript" type="text/javascript">
         function DoSelectDIV(obj){
            if (obj == '1')
            {
                document.getElementById("divItinerary").style.display = "";
                document.getElementById("divHighlights").style.display = "none";                                                 
                document.getElementById("divPriceing").style.display = "none";
                document.getElementById("divCustomers").style.display = "none";
                document.getElementById("divTermsandConditions").style.display = "none";
                document.getElementById("divBooking").style.display = "none";
                
                document.getElementById("divItineraryMenu").className = "tour-bn_01_on";
                document.getElementById("divHighlightsMenu").className = "tour-bn_01_off";
                document.getElementById("divPriceingMenu").className = "tour-bn_01_off";
                document.getElementById("divCustomersMenu").className = "tour-bn_01_off";
                document.getElementById("divTermsandConditionsMenu").className = "tour-bn_02_off";
                document.getElementById("divBookingMenu").className = "tour-bn_04_off";
            }
            if (obj == '2')
            {
                document.getElementById("divItinerary").style.display = "none";
                document.getElementById("divHighlights").style.display = "";
                document.getElementById("divPriceing").style.display = "none";
                document.getElementById("divCustomers").style.display = "none";
                document.getElementById("divTermsandConditions").style.display = "  none";
                document.getElementById("divBooking").style.display = "none";
                
                document.getElementById("divItineraryMenu").className = "tour-bn_01_off";
                document.getElementById("divHighlightsMenu").className = "tour-bn_01_on";
                document.getElementById("divPriceingMenu").className = "tour-bn_01_off";
                document.getElementById("divCustomersMenu").className = "tour-bn_01_off";
                document.getElementById("divTermsandConditionsMenu").className = "tour-bn_02_off";
                document.getElementById("divBookingMenu").className = "tour-bn_04_off";
            }
            if (obj == '3')
            {
                document.getElementById("divItinerary").style.display = "none";
                document.getElementById("divHighlights").style.display = "none";
                document.getElementById("divPriceing").style.display = "";
                document.getElementById("divCustomers").style.display = "none";
                document.getElementById("divTermsandConditions").style.display = "none";
                document.getElementById("divBooking").style.display = "none";
                
                document.getElementById("divItineraryMenu").className = "tour-bn_01_off";
                document.getElementById("divHighlightsMenu").className = "tour-bn_01_off";
                document.getElementById("divPriceingMenu").className = "tour-bn_01_on";
                document.getElementById("divCustomersMenu").className = "tour-bn_01_off";
                document.getElementById("divTermsandConditionsMenu").className = "tour-bn_02_off";
                document.getElementById("divBookingMenu").className = "tour-bn_04_off";
            }
            if (obj == '4')
            {
                document.getElementById("divItinerary").style.display = "none";
                document.getElementById("divHighlights").style.display = "none";
                document.getElementById("divPriceing").style.display = "none";
                document.getElementById("divCustomers").style.display = "none";
                document.getElementById("divTermsandConditions").style.display = "";
                document.getElementById("divBooking").style.display = "none";
                
                document.getElementById("divItineraryMenu").className = "tour-bn_01_off";
                document.getElementById("divHighlightsMenu").className = "tour-bn_01_off";
                document.getElementById("divPriceingMenu").className = "tour-bn_01_off";
                document.getElementById("divCustomersMenu").className = "tour-bn_01_off";
                document.getElementById("divTermsandConditionsMenu").className = "tour-bn_02_on";
                document.getElementById("divBookingMenu").className = "tour-bn_04_off";
            }
            if (obj == '5')
            {
                document.getElementById("divItinerary").style.display = "none";
                document.getElementById("divHighlights").style.display = "none";
                document.getElementById("divPriceing").style.display = "none";
                document.getElementById("divCustomers").style.display = "";
                document.getElementById("divTermsandConditions").style.display = "none";
                document.getElementById("divBooking").style.display = "none";
                
                document.getElementById("divItineraryMenu").className = "tour-bn_01_off";
                document.getElementById("divHighlightsMenu").className = "tour-bn_01_off";
                document.getElementById("divPriceingMenu").className = "tour-bn_01_off";
                document.getElementById("divCustomersMenu").className = "tour-bn_01_on";
                document.getElementById("divTermsandConditionsMenu").className = "tour-bn_02_off";
                document.getElementById("divBookingMenu").className = "tour-bn_04_off";
            }
            if (obj == '6')
            {
                document.getElementById("divItinerary").style.display = "none";
                document.getElementById("divHighlights").style.display = "none";
                document.getElementById("divPriceing").style.display = "none";
                document.getElementById("divCustomers").style.display = "none";
                document.getElementById("divTermsandConditions").style.display = "none";
                document.getElementById("divBooking").style.display = "";
                
                document.getElementById("divItineraryMenu").className = "tour-bn_01_off";
                document.getElementById("divHighlightsMenu").className = "tour-bn_01_off";
                document.getElementById("divPriceingMenu").className = "tour-bn_01_off";
                document.getElementById("divCustomersMenu").className = "tour-bn_01_off";
                document.getElementById("divTermsandConditionsMenu").className = "tour-bn_02_off";
                document.getElementById("divBookingMenu").className = "tour-bn_04_on";
            }
         }
         function DoSelect(obj){
            
            if(document.getElementById("ctl00_MainContent_runFlag").value == "1"){
                return false;
            }    
            obj.style.visibility="hidden";           
            obj.parentElement.className="loading";
            document.getElementById("ctl00_MainContent_runFlag").value = "1";
            
        }
        function doPrint(){
				window.open("printPage.html","","height=150,width=400,resizable=no,scrollbars=no,status=no,toolbar=no,menubar=no,location=no");
		}
		function SelectDate(obj,This)
		{	  
		    //This.style.color = "#ff3300";
		    var Lbdate = document.getElementById("ctl00_MainContent_lblDate");
		    var txtDate = document.getElementById("ctl00_MainContent_txtDate");
		    Lbdate.innerHTML = obj;    
		    txtDate.value = obj;
		    var btn=document.getElementById("ctl00_MainContent_btn_PriceChanged");
            btn.click();
		}
        function copyToClipBoard(){
        var clipBoardContent="";        
        clipBoardContent= "http://www.majestic-vacations.com/Tourindex.aspx?tab=T&code=" + document.getElementById("ctl00_MainContent_CurrentItineraryControl_lbl_TourCode").innerText;
        window.clipboardData.setData("Text",clipBoardContent);
        }
        </script>

        <table width="735" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="120" bgcolor="#FD4C00">
                    <table class="T_step02" border="0" cellpadding="0" cellspacing="1" width="735">
                        <tbody>
                            <tr class="R_step02">
                                <td valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="8" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr align="left">
                                                                                <td width="75%" height="25" valign="top" class="D_stepr">
                                                                                    <span id="ctl00_MainContent_CurrentItineraryControl_Label1"><asp:Label ID="Label34" runat="server" Text="Review Current Itinerary" meta:resourcekey="lblReviewCurrentItinerary" ></asp:Label></span></td>
                                                                                <td align="right" valign="top">
                                                                                    <asp:HyperLink ID="hlItineraryPDF" runat="server" Target=_blank>View Itinerary</asp:HyperLink><asp:Label
                                                                                        ID="lblItineraryPDF" runat="server" Text=" |" Visible=false ></asp:Label>
                                                                                        <asp:HyperLink ID="hlEmailPDF" runat="server" Target="_blank">Email Itinerary</asp:HyperLink><asp:Label
                                                                                        ID="lblEmailPDF" runat="server" Text=" |" Visible=false ></asp:Label>
                                                                                    <a href="javascript:doPrint();" id="ctl00_MainContent_CurrentItineraryControl_printLink">
                                                                                        <span id="ctl00_MainContent_CurrentItineraryControl_Label6"><asp:Label ID="Label35" runat="server" Text="Print" meta:resourcekey="lblPrint" ></asp:Label></span></a>
                                                                                    |
                                                                                    <asp:LinkButton ID="lbtnBack" runat="server" OnClick="lbtnBack_Click"><asp:Label ID="Label36" runat="server" Text="Back" meta:resourcekey="lblBack" ></asp:Label></asp:LinkButton>
                                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                                        <tbody>
                                                                                            <tr valign="bottom">
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <table class="T_step03" border="0" cellpadding="8" cellspacing="1" width="100%">
                                                                                        <tbody>
                                                                                            <tr class="R_stepw">
                                                                                                <td valign="top">
                                                                                                    <!-- part one begin-->
                                                                                                    <table width="690" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                                        <tr>
                                                                                                            <td width="538" height="40" class="t10" align="left">
                                                                                                                <asp:Label ID="lblTourName" runat="server" Text=""></asp:Label></td>
                                                                                                            <td width="150" align="right">
                                                                                                                <strong><asp:Label ID="Label3" runat="server" Text="Tour Code" meta:resourcekey="lblTourCode" ></asp:Label>: </strong>
                                                                                                                <asp:Label ID="lblTourCode" runat="server" Text=""></asp:Label></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td height="5">
                                                                                                            </td>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    <table width="690" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                                        <tr>
                                                                                                            <td width="160" valign="top" align="left">
                                                                                                                <asp:Image ID="imgTour" runat="server" Width="150" Height="100" border="0" onerror="this.src='http://www.majestic-vacations.com/images/default_pic.gif';" />
                                                                                                                <asp:Image ID="imgSale" ImageUrl="http://www.majestic-vacations.com/images/icon_sale.png"
                                                                                                                    runat="server" Width="72" Height="47" vspace="5" Style="position: absolute; margin: -5px 0px 0px -159px;
                                                                                                                    *margin: -10px 0px 0px -164px;" />
                                                                                                            </td>
                                                                                                            <td width="370" valign="top">
                                                                                                                <table width="377" height="80" border="0" cellpadding="0" cellspacing="0">
                                                                                                                    <tr>
                                                                                                                        <td width="114" valign="top" align="left" >
                                                                                                                            <b><asp:Label ID="Label4" runat="server" Text="Departure Place" meta:resourcekey="lblDeparturePlace" ></asp:Label>:</b></td>
                                                                                                                        <td width="263" valign="top" align="left" >
                                                                                                                            <asp:Label ID="lblDeparturePlace" runat="server" Text=""></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td valign="top" align="left">
                                                                                                                            <b><asp:Label ID="Label7" runat="server" Text="Duration" meta:resourcekey="lblDuration" ></asp:Label>:</b></td>
                                                                                                                        <td valign="top" align="left">
                                                                                                                            <asp:Label ID="lblDurationDays" runat="server" Text="Label"></asp:Label>
                                                                                                                            Days</td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" valign="top">
                                                                                                                            <b><asp:Label ID="Label9" runat="server" Text="Operating" meta:resourcekey="lblOperating" ></asp:Label>:</b></td>
                                                                                                                        <td align="left" valign="top">
                                                                                                                            <asp:Label ID="lblOperating" runat="server" Text="Sep 17th 2011 - Oct 15th 2011: Daily"></asp:Label>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" valign="top">
                                                                                                                            <strong><asp:Label ID="Label13" runat="server" Text="Visiting" meta:resourcekey="lblVisiting" ></asp:Label>:</strong></td>
                                                                                                                        <td align="left" valign="top">
                                                                                                                            <asp:Label ID="lblVisiting" runat="server" Text=""></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                    <tr>
                                                                                                                        <td align="left" valign="top">
                                                                                                                            <b><asp:Label ID="Label14" runat="server" Text="Product Link" meta:resourcekey="lblProductLink" ></asp:Label>:</b>
                                                                                                                        </td>
                                                                                                                        <td align="left" valign="top">
                                                                                                                            <asp:Label ID="lblProductLink" runat="server" Text=""></asp:Label></td>
                                                                                                                    </tr>
                                                                                                                    <%--<tr>
                                                                                                                    <td colspan="2" align="left" valign="top">
                                                                                                                        <span id="ctl00_MainContent_lblHighlight8">
                                                                                                                            <img src="../../images/Icon_2+1_s.gif" width="59" height="28" hspace="5" vspace="5" /><img
                                                                                                                                src="../../images/Icon_2+2_s.gif" width="59" height="28" hspace="5" vspace="5" /><br />
                                                                                                                        </span>
                                                                                                                    </td>
                                                                                                                </tr>--%>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                            <td width="150" valign="top">
                                                                                                                <table align="right" border="0" cellpadding="0" cellspacing="0" width="140">
                                                                                                                    <tbody>
                                                                                                                        <tr align="center" valign="top">
                                                                                                                            <td align="center" nowrap="nowrap" width="150px" >
                                                                                                                                <font class="t11"><asp:Label ID="Label15" runat="server" Text="Starting From" meta:resourcekey="lblStartingFrom" ></asp:Label></font>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr align="center" valign="top" width="150">
                                                                                                                            <td align=center width="150" nowrap=nowrap>
                                                                                                                                <font class="t11-1">$<span class="tour-list_price"><asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></span><asp:Label ID="Label38" meta:resourcekey="lblQi" runat="server" Text=""></asp:Label></font>
                                                                                                                            </td>
                                                                                                                        </tr>
                                                                                                                        <tr align="left" valign="top">
                                                                                                                            <td align="center" width="150">
                                                                                                                                <img runat="server" id="Icon21" visible="false" src="../../images/Icon_21.gif" width="128"
                                                                                                                                    height="22" vspace="5" /></td>
                                                                                                                        </tr>
                                                                                                                        <tr align="left" valign="top">
                                                                                                                            <td align="center" width="150">
                                                                                                                                <img runat="server" id="Icon22" visible="false" src="../../images/Icon_22.gif" width="128"
                                                                                                                                    height="22" vspace="5" /></td>
                                                                                                                        </tr>
                                                                                                                    </tbody>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                    <!-- part one end-->
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr class="R_step04">
                                                <td height="20">
                                                    &nbsp;</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    </table>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
        </table>
        <div class="table735">
            <div class="tour-bn_01_on" id="divItineraryMenu">
                <a href="#" onclick="DoSelectDIV('1')"><asp:Label ID="Label16" runat="server" Text="Itinerary" meta:resourcekey="lblItinerary" ></asp:Label></a></div>
            <div class="tour-bn_01_off" id="divHighlightsMenu">
                <a href="#" onclick="DoSelectDIV('2')"><asp:Label ID="Label17" runat="server" Text="Highlights" meta:resourcekey="lblHighlights" ></asp:Label></a></div>
            <div class="tour-bn_01_off" id="divPriceingMenu">
                <a href="#" onclick="DoSelectDIV('3')"><asp:Label ID="Label18" runat="server" Text="Pricing" meta:resourcekey="lblPricing" ></asp:Label></a></div>
            <div class="tour-bn_02_off" id="divTermsandConditionsMenu">
                <a href="#" onclick="DoSelectDIV('4')"><asp:Label ID="Label19" runat="server" Text="Terms & Conditions" meta:resourcekey="lblTermsConditions" ></asp:Label></a></div>
            <div class="tour-bn_01_off" id="divCustomersMenu">
                <a href="#" onclick="DoSelectDIV('5')"><asp:Label ID="Label20" runat="server" Text="F A Q" meta:resourcekey="lblFAQ" ></asp:Label></a></div>
            <div class="tour-bn_04_off" id="divBookingMenu">
                <a href="#" onclick="DoSelectDIV('6')"><asp:Label ID="Label21" runat="server" Text="Book Now" meta:resourcekey="lblBookNow" ></asp:Label></a></div>
        </div>
        <div class="table735_color-boder" id="divItinerary" name="divItinerary">
            <div class="tour_note"><asp:Label ID="Label22" runat="server" Text="Please note that order of day-to-day itinerary is adjustable depending on tour start day." meta:resourcekey="lblNote" ></asp:Label>
                </div>
            <asp:DataList ID="dlItinerary" runat="server">
                <ItemTemplate>
                    <div class="tour_tittle">
                        <asp:Label ID="Label20" runat="server" Text="Days" meta:resourcekey="lblDays" ></asp:Label> <asp:Label ID="lblDays" runat="server" Text=""></asp:Label> <asp:Label ID="Label37" runat="server" Text="" meta:resourcekey="lblTian" ></asp:Label>,
                        <asp:Label ID="lblFrom" runat="server" Text=""></asp:Label></div>
                    <table width="100%">
                        <tr>
                            <td>
                                <div class="tour_content_intro">
                                    <asp:Image ID="imgItinerary" runat="server" Width="150" Height="100" border="0" onerror="this.src='http://www.majestic-vacations.com/images/default_pic.gif';" /><asp:Label
                                        ID="lblItinerary" runat="server" Text=""></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <div class="tour_content_point">
                        <div class="tour_content_h">
                            <img src="../../images/Icon_meal.gif" align="absmiddle">
                            <span class="head07"><asp:Label ID="Label16" runat="server" Text="Meal" meta:resourcekey="lblMeal" ></asp:Label> :</span> <asp:Label ID="Label23" runat="server" Text="Breakfast" meta:resourcekey="lblBreakfast" ></asp:Label>:
                            <asp:Label ID="lblBreakfast" runat="server" Text=""></asp:Label>&nbsp;&nbsp;,
                            <asp:Label ID="Label24" runat="server" Text="Lunch" meta:resourcekey="lblLunch" ></asp:Label>:
                            <asp:Label ID="lblLunch" runat="server" Text=""></asp:Label>&nbsp;&nbsp;,
                            <asp:Label ID="Label25" runat="server" Text="Dinner" meta:resourcekey="lblDinner" ></asp:Label>:
                            <asp:Label ID="lblDinner" runat="server" Text=""></asp:Label></div>
                        <div class="tour_content_h">
                            <img src="../../images/Icon_hotel.gif" align="absmiddle">
                            <span class="head07"><asp:Label ID="Label26" runat="server" Text="Hotel" meta:resourcekey="lblHotel" ></asp:Label> :</span>
                            <asp:Label ID="lblHotel" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="table735_color-boder" id="divHighlights" style="display: none">
            <div class="tour_tittle">
                <asp:Label ID="Label32" runat="server" Text="Highlights" meta:resourcekey="lblHighlights" ></asp:Label></div>
            <div align="left">
                <div style="padding-left: 15px;">
                    <asp:Label ID="lblHighlights" runat="server" Text=""></asp:Label></div>
            </div>
            <div class="tour_tittle">
                <asp:Label ID="Label26" runat="server" Text="Hotel Information" meta:resourcekey="lblHotelInfo" ></asp:Label></div>
            <asp:Repeater ID="rpHotelList" runat="server">
                <ItemTemplate>
                    <div class="tour_content_h" align="left">
                        <asp:Label ID="Label2" runat="server" Style="padding-left: 15px;" Text="Day" meta:resourcekey="lblDays" ></asp:Label> 
                        <asp:Label ID="lblDayss" runat="server" Text=""> </asp:Label><asp:Label ID="Label37" runat="server" Text="" meta:resourcekey="lblTian" ></asp:Label>    
                        <asp:Label ID="lblHotel" runat="server" Text=""></asp:Label></div> 
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="table735_color-boder" id="divPriceing" style="display: none">
            <div class="tour_tittle">
                <asp:Label ID="Label27" runat="server" Text="Price table" meta:resourcekey="lblPricetable" ></asp:Label></div>
            <div align="left">
                <asp:DataList ID="dlPrices" runat="server" OnItemDataBound="dlPrices_ItemDataBound"
                    border="0" CellPadding="0" CellSpacing="1">
                    <ItemTemplate>
                        <table class="T_step03" border="0" cellpadding="0" cellspacing="1" width="710">
                            <tr class="R_stepw" height="30px">
                                <td height="30px">
                                    <asp:DataList ID="dlRooms" runat="server" RepeatDirection="Horizontal">
                                        <ItemTemplate>
                                            <div class="tour_price-table-t">
                                                <asp:Label ID="lblRoomType" runat="server"></asp:Label>
                                                Room: <span class="t11">$<asp:Label ID="lblRoomPrice" runat="server"></asp:Label></span></div>
                                        </ItemTemplate>
                                        <ItemStyle Height="30px" />
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr class="R_stepw">
                                <td align="left">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                        <tr>
                                            <td align="left">
                                                <asp:DataList ID="dlPriceDates" Width="99%" runat="server" RepeatDirection="Horizontal"
                                                    RepeatLayout="Flow" OnItemDataBound="dlPriceDates_ItemDataBound" DataSource='<%# ((PriceDate) DataBinder.Eval(Container,"DataItem")).DateElementList %>'>
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbt_date" runat="server" ForeColor="blue" Style="font-size: 10px" Text='<%#  Convert.ToDateTime(DataBinder.Eval(Container,"DataItem")).ToString("MM/dd") %>'></asp:Label><asp:Label
                                                                ID="lbl_Number" runat="server" Text="" Visible="false"></asp:Label><asp:Label ID="lbl_br"
                                                                    runat="server">&#12289;</asp:Label>
                                                    </ItemTemplate>
                                                </asp:DataList></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList></div>
            <div class="tour_tittle">
                <asp:Label ID="Label28" runat="server" Text="Package Includes" meta:resourcekey="lblPackageIncludes" ></asp:Label></div>
            <div align="left">
                <div style="padding-left: 15px;">
                    <asp:Label ID="lblPackageIncludes" runat="server" Text=""></asp:Label></div>
            </div>
            <div class="tour_tittle">
                <asp:Label ID="Label29" runat="server" Text="Package Excludes" meta:resourcekey="lblPackageExcludes" ></asp:Label>
            </div>
            <div align="left">
                <div style="padding-left: 15px;">
                    <asp:Label ID="lblPackageExcludes" runat="server" Text=""></asp:Label></div>
            </div>
        </div>
        <div class="table735_color-boder" id="divCustomers" style="display: none">
            <div align="left">
                <asp:Label ID="lblFAQ" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div class="table735_color-boder" id="divTermsandConditions" style="display: none">
            <div class="tour_tittle">
                <asp:Label ID="Label33" runat="server" Text="Terms & Conditions" meta:resourcekey="lblTermsConditions" ></asp:Label></div>
            <div class="tour_content">
                <div style="padding-left: 15px;">
                    <asp:Label ID="lblTermsandConditions" runat="server" Text=""></asp:Label></div>
            </div>
        </div>
        <div class="table735_color-boder" id="divBooking" style="display: none">
            <table width="735" border="0" cellspacing="0" cellpadding="0" id="tbDeptPlace" runat="server"
                visible="false">
                <tr>
                    <td height="15">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="20">
                                    <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                        <tr>
                                            <td align="center">
                                                4</td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="5">
                                </td>
                                <td align="left">
                                    <span class="head06">
                                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblChoosePlace">Choose The Departure Place</asp:Label></span></td>
                            </tr>
                        </table>
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
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="7">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                                    <tr class="R_stepw">
                                                        <td>
                                                            <table width="700" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="30" align="left">
                                                                        <asp:Label ID="Label6" runat="server" meta:resourcekey="lblDeparturePlace">Departure place</asp:Label>
                                                                        <asp:DropDownList ID="ddlUsaCity" runat="server" CssClass="search_sle" Width="200px">
                                                                        </asp:DropDownList></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="3">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <div class="tour_tittle">
                <asp:Label ID="Label31" runat="server" meta:resourcekey="lblChoosePlace">Choose Departure Date</asp:Label><asp:Label ID="Label39" runat="server" meta:resourcekey="lblChoosePlace1">Choose The Arrival Date</asp:Label><asp:Label ID="lblDisplay" style="display:none" runat="server" Text="(Land only tour starts the next day of departure date)"
                    meta:resourcekey="lblDisplay"></asp:Label>
            </div>
            <table class="T_step03" border="0" cellpadding="8" cellspacing="1" width="710">
                <tbody>
                    <tr class="R_stepw">
                        <td>
                            <asp:DataList ID="dlFrices" Width="710" CellPadding="0" CellSpacing="0" runat="server"
                                Style="width: 100%; border-collapse: collapse;" OnItemDataBound="dlFrices_ItemDataBound">
                                <ItemTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="divideLine" runat="server"
                                        visible="false">
                                        <tr>
                                            <td height="10">
                                                <hr width="100%" size="1" color="#cccccc" />
                                                <asp:LinkButton ID="lbtnMore" runat="server" OnClick="lbtnMore_Click" Visible="false"
                                                    Style="display: none">More</asp:LinkButton>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="80" height="25" align="center" valign="top">
                                                <font class="t02"><asp:Label ID="Label29" runat="server" Text="From" meta:resourcekey="lblFrom" ></asp:Label><br />
                                                    $&nbsp;<asp:Label ID="Label1" runat="server" Text='<%# ((PriceDate) DataBinder.Eval(Container,"DataItem")).LowFare.ToString("#,###") %>'>
                                                    </asp:Label>&nbsp;USD</font></td>
                                            <td width="1" bgcolor="#cccccc">
                                            </td>
                                            <td>
                                                <table width="580" border="0" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="left">
                                                            <asp:DataList ID="dlDates" Width="100%" CellPadding="0" CellSpacing="0" runat="server"
                                                                OnItemDataBound="dlDates_ItemDataBound" DataSource='<%# ((PriceDate) DataBinder.Eval(Container,"DataItem")).DateElementList %>'
                                                                RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbt_date" runat="server" ForeColor="blue" Style="cursor: pointer;
                                                                        font-size: 10px" Text='<%#  Convert.ToDateTime(DataBinder.Eval(Container,"DataItem")).ToString("MM/dd") %>'></asp:Label><asp:Label
                                                                            ID="lbl_Number" runat="server" Text="" Visible="false"></asp:Label><asp:Label ID="lbl_br"
                                                                                runat="server">&#12289;</asp:Label>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                </tbody>
            </table>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="710">
                <tbody>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <strong>
                                <asp:Label ID="Label8" runat="server" meta:resourcekey="lblChoiceDate">You choice departure date is </asp:Label><asp:Label ID="Label40" runat="server" meta:resourcekey="lblChoiceDate1">You choice departure date is </asp:Label>
                                <asp:Label ID="lblDate" runat="server" ForeColor="red" Font-Size="14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label></strong>
                            <asp:TextBox ID="txtDate" runat="server" Style="display: none" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <div class="tour_tittle">
                <asp:Label ID="Label30" runat="server" meta:resourcekey="lblChoiceRoomType">Choice Room Type</asp:Label></div>
            <asp:UpdatePanel ID="upPriceInfo" runat="server">
                <ContentTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tbody>
                            <tr width="100%" style="display:none" >
                                <td align="right" height="15px" width="100%">
                                    <asp:RadioButtonList ID="rbtnPriceType" runat="server" RepeatDirection="Horizontal"
                                        OnSelectedIndexChanged="rbtnPriceType_SelectedIndexChanged" AutoPostBack="True">
                                        <asp:ListItem Selected="True" Value="0">Land Only</asp:ListItem>
                                        <asp:ListItem Value="1">Air + Land</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr width="100%">
                                <td width="100%">
                                    <input id="ctl00$MainContent$TourTravelerChangeControl1$hdControlName" value="TourTravelerChangeControl1"
                                        name="ctl00$MainContent$TourTravelerChangeControl1$hdControlName" type="hidden">
                                    <div id="divLandOnly" runat="server">
                                        <table class="T_step03" border="0" cellpadding="0" cellspacing="1" width="100%">
                                            <tbody>
                                                <tr class="R_stepw" width="100%">
                                                    <td width="100%">
                                                        <asp:DataList runat="server" ID="dlTourRoomTypeList" Width="100%">
                                                            <HeaderTemplate>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tbody>
                                                                        <tr width="100%">
                                                                            <td height="50" align="center" style="border-bottom: solid #cccccc 1px;">
                                                                                <font class="t06">
                                                                                    <asp:Label ID="Label10" runat="server" meta:resourcekey="lblRoomType">Room Type</asp:Label></font></td>
                                                                            <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <font class="t06">
                                                                                    <asp:Label ID="Label11" runat="server" meta:resourcekey="lblPrice">Price(Per person)</asp:Label></font></td>
                                                                            <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <font class="t06">
                                                                                    <asp:Label ID="Label12" runat="server" meta:resourcekey="lblNumberOfRooms">Number of Rooms</asp:Label></font></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" runat="server" id="tbTriple">
                                                                    <tbody>
                                                                        <tr width="100%">
                                                                            <td width="50%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <asp:Label ID="lblRoomType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoomTypeName") %>'></asp:Label></td>
                                                                            <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                USD $<asp:Label runat="server" ID="lblAdultPrice" Text='<%# DataBinder.Eval(Container.DataItem, "RoomPrice") %>'></asp:Label></td>
                                                                            <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <asp:DropDownList ID="dllRooms" runat="server" CssClass="search_sle" Width="35px">
                                                                                    <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div runat="server" id="divAirLand" visible="false">
                                        <table class="T_step03" cellspacing="1" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr class="R_stepw" width="100%">
                                                    <td width="100%">
                                                        <asp:DataList runat="server" ID="dlTourRoomTypeList1" Width="100%">
                                                            <HeaderTemplate>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tbody>
                                                                        <tr width="100%">
                                                                            <td height="50" align="center" style="border-bottom: solid #cccccc 1px;">
                                                                                <font class="t06">
                                                                                    <asp:Label ID="Label10" runat="server" meta:resourcekey="lblRoomType">Room Type</asp:Label></font></td>
                                                                            <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <font class="t06">
                                                                                    <asp:Label ID="Label11" runat="server" meta:resourcekey="lblPrice">Price(Per person)</asp:Label></font></td>
                                                                            <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <font class="t06">
                                                                                    <asp:Label ID="Label12" runat="server" meta:resourcekey="lblNumberOfRooms">Number of Rooms</asp:Label></font></td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" runat="server" id="tbTriple">
                                                                    <tbody>
                                                                        <tr width="100%">
                                                                            <td width="50%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <asp:Label ID="lblRoomType" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "RoomTypeName") %>'></asp:Label></td>
                                                                            <td width="25%" height="25" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                USD $<asp:Label runat="server" ID="lblAdultPrice" Text='<%# DataBinder.Eval(Container.DataItem, "RoomPrice") %>'></asp:Label></td>
                                                                            <td width="25%" align="center" style="border-bottom: solid #cccccc 1px">
                                                                                <asp:DropDownList ID="dllRooms" runat="server" CssClass="search_sle" Width="35px">
                                                                                    <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                                                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:DataList>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td height="3">
                                    <asp:Button ID="btn_PriceChanged" Style="display: none" runat="server" Text="Button"
                                        Visible="true" OnClick="btn_PriceChanged_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tbody>
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnContinue" runat="server" Text="Continue" meta:resourcekey="btnContinue" CssClass="search_btn02" OnClick="btnContinue_Click" />
                            &nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" meta:resourcekey="btnBack" CssClass="search_btn03" OnClick="btnBack_Click" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <br />
    </div>
</asp:Content>
