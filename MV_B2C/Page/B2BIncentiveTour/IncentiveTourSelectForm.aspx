<%@ Page Language="C#" MasterPageFile="~/Page/Tour/TourBookingPage.master" AutoEventWireup="true"
    EnableEventValidation="false" Codebehind="IncentiveTourSelectForm.aspx.cs" Inherits="IncentiveTourSelectForm" %>

<%@ Register Src="../../UserControls/TourTravelerChangeControl.ascx" TagName="TourTravelerChangeControl"
    TagPrefix="uc3" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ MasterType VirtualPath="~/Page/Tour/TourBookingPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ItineraryInfo -->

    <script language="javascript" type="text/javascript">
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
        clipBoardContent= "http://www.majestic-vacations.com/Tourindex.aspx?tab=T&code=" + document.getElementById("CurrentItineraryControl_lbl_TourCode").innerText;
        window.clipboardData.setData("Text",clipBoardContent);
        }
        
        
        var isShowTourItinerary = false;
         function ShowOrHideTourItinerary()
         {
            if(!isShowTourItinerary)
            {
                isShowTourItinerary =true;
                document.getElementById("ctl00_MainContent_div_isShowTourItinerary").style.display = "";
                document.getElementById("imgShowTourItinerary").src = document.getElementById("imgShowTourItinerary").src.replace("open", "close") ;
            }
            else
            { isShowTourItinerary =false;
                document.getElementById("ctl00_MainContent_div_isShowTourItinerary").style.display = "none";
                document.getElementById("imgShowTourItinerary").src = document.getElementById("imgShowTourItinerary").src.replace("close", "open") ;
                }
         }
         
         function ShowOrHideSelectRoom()
         {
            if (document.getElementById("ctl00_MainContent_checkDepDate").checked)
            {
                document.getElementById("ctl00_MainContent_divSelectRoom").style.display = "none";
                document.getElementById("ctl00_MainContent_divIncentiveTourCon").style.display = "";
            }
            else
            {
                document.getElementById("ctl00_MainContent_divSelectRoom").style.display = "";
                document.getElementById("ctl00_MainContent_divIncentiveTourCon").style.display = "none";
            }
         }
    </script>

    <div id="printArea">
        <uc5:CurrentItineraryControl ID="CurrentItineraryControl" runat="server"></uc5:CurrentItineraryControl>
        <br />
        <!-- new -->
        <table width="735" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="15">
                    <input type="button" value="Product Link" name="B3" onclick="copyToClipBoard()">
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
                                            1</td>
                                    </tr>
                                </table>
                            </td>
                            <td width="5">
                            </td>
                            <td align="left">
                                <span class="head06">
                                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblHighlights">Highlights</asp:Label></span></td>
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
                                                <tr class="R_stepw" align="left">
                                                    <td>
                                                        <%--<asp:TextBox ID="txtHightlight" runat="server" TextMode="MultiLine" Width="98%"></asp:TextBox>--%>
                                                        <asp:Label ID="lblHighlight" runat="server"></asp:Label>
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
        <table width="735" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td height="15">
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="20" style="height: 48px">
                                <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                    <tr>
                                        <td align="center">
                                            2</td>
                                    </tr>
                                </table>
                            </td>
                            <td width="5" style="height: 48px">
                            </td>
                            <td align="left" style="height: 48px">
                                <span class="head06">
                                    <asp:Label ID="Label3" runat="server" meta:resourcekey="lblTourItinerary">Tour Itinerary</asp:Label></span>
                                &nbsp;
                                <img id="imgShowTourItinerary" src="../../images/open.gif" height="14px" width="14px"
                                    border="0" onclick="ShowOrHideTourItinerary()" />
                            </td>
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
                    <div id="div_isShowTourItinerary" runat="server" visible="true" style="display: none">
                        <table width="735" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                            <tr class="R_stepo">
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="7">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <uc5:TourItineraryControl ID="TourItineraryControl1" runat="server"></uc5:TourItineraryControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="7">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <table width="735" border="0" cellspacing="0" cellpadding="0">
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
                                        3</td>
                                </tr>
                            </table>
                        </td>
                        <td width="5">
                        </td>
                        <td align="left">
                            <span class="head06">
                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblRemarks">Remarks</asp:Label></span></td>
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
                                            <tr class="R_stepw" align="left">
                                                <td>
                                                    <asp:Label ID="lblRemark" runat="server"></asp:Label>
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
    <table width="735" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="15">
            </td>
        </tr>
        <tr>
            <td style="height: 57px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="20">
                            <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="isIndex4Or5" runat="server">5</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="5">
                        </td>
                        <td align="left">
                            <span class="head06">
                                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblChooseDate">Choose Departure Date</asp:Label>&nbsp;<asp:Label
                                    ID="lblDisplay" runat="server" Text="(Land only tour starts the next day of departure date)"
                                    meta:resourcekey="lblDisplay"></asp:Label></span></td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
                    <tr class="R_stepo">
                        <td valign="top">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="TABLE1">
                                <tr>
                                    <td height="7">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 56px">
                                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                                            <tr class="R_stepw">
                                                <td>
                                                    <asp:DataList ID="dlFrices" Width="100%" CellPadding="0" CellSpacing="0" runat="server"
                                                        OnItemDataBound="dlFrices_ItemDataBound">
                                                        <ItemTemplate>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="divideLine" runat="server"
                                                                visible="false">
                                                                <tr>
                                                                    <td height="10">
                                                                        <hr width="100%" size="1" color="#cccccc" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <table width="700" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="100" height="25" align="center" valign="top">
                                                                        <font class="t02">From $<asp:Label ID="Label1" runat="server" Text='<%# ((PriceDate) DataBinder.Eval(Container,"DataItem")).LowFare.ToString("#,###") %>'>
                                                                        </asp:Label>&nbsp;USD</font></td>
                                                                    <td width="1" bgcolor="#cccccc">
                                                                    </td>
                                                                    <td width="600">
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
                                        </table>
                                    </td>
                                </tr>
                                <tr align="left" height="3">
                                    <asp:LinkButton ID="lbtnMore" runat="server" OnClick="lbtnMore_Click">More</asp:LinkButton>
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
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="10">
            </td>
        </tr>
        <tr>
            <td align="left">
                <strong>
                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblChoiceDate">You choice departure date is </asp:Label>
                    <asp:Label ID="lblDate" runat="server" ForeColor="red" Font-Size="14px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:Label></strong>
                <asp:TextBox ID="txtDate" runat="server" Style="display: none" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:CheckBox ID="checkDepDate" runat="server" onclick="ShowOrHideSelectRoom()" TextAlign="Right"
                    Text="If the list is not your preferred departure date, please fill out a starting date" />&nbsp;&nbsp;<asp:TextBox ID="txtDepDate" runat="server"></asp:TextBox>(e.g. 01/01/2011)
            </td>
        </tr>
    </table>
    <div runat="server" id="divSelectRoom">
        <table cellspacing="0" cellpadding="0" width="735" border="0">
            <tbody>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td width="20">
                                        <table class="T_line01" cellspacing="0" cellpadding="0" width="20" border="0">
                                            <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="isIndex5Or6" runat="server">6</asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td width="5">
                                    </td>
                                    <td align="left">
                                        <span class="head06">
                                            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblChoiceRoomType">Choice Room Type</asp:Label></span></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="upPriceInfo" runat="server">
                            <ContentTemplate>
                                <table class="T_step02" cellspacing="1" cellpadding="8" width="100%" border="0">
                                    <tbody>
                                        <tr class="R_stepo" width="100%">
                                            <td valign="top" width="100%">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr width="100%">
                                                            <td height="7" width="100%">
                                                            </td>
                                                        </tr>
                                                        <tr width="100%">
                                                            <td width="100%">
                                                                <input id="ctl00$MainContent$TourTravelerChangeControl1$hdControlName" type="hidden"
                                                                    value="TourTravelerChangeControl1" name="ctl00$MainContent$TourTravelerChangeControl1$hdControlName">
                                                                <table class="T_step03" cellspacing="1" cellpadding="0" width="100%" border="0">
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
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div runat="server" id="divIncentiveTourCon" style="display:none">
        <table cellspacing="0" cellpadding="0" width="735" border="0">
            <tbody>
                <tr>
                    <td style="height: 15px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td width="20">
                                        <table class="T_line01" cellspacing="0" cellpadding="0" width="20" border="0">
                                            <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Label ID="Label13" runat="server">5</asp:Label>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td width="5">
                                    </td>
                                    <td align="left">
                                        <span class="head06">
                                            <asp:Label ID="Label14" runat="server" meta:resourcekey="lblChoiceRoomType">Fill Contact information and the number of</asp:Label></span></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table class="T_step02" cellspacing="1" cellpadding="8" width="100%" border="0">
                            <tbody>
                                <tr class="R_stepo" width="100%">
                                    <td valign="top" width="100%">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr width="100%">
                                                    <td height="7" width="100%">
                                                    </td>
                                                </tr>
                                                <tr width="100%">
                                                    <td width="100%">                                                        
                                                        <table class="T_step03" cellspacing="1" cellpadding="0" width="100%" border="0">
                                                            <tbody>
                                                                <tr class="R_stepw" width="100%">
                                                                    <td width="30%">
                                                                        Pax:
                                                                    </td>
                                                                    <td align=left>
                                                                        <asp:TextBox ID="txtPax" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="R_stepw" width="100%">
                                                                    <td width="30%">
                                                                        Local Guie Language Speaking:
                                                                    </td>
                                                                    <td align=left>
                                                                        <asp:TextBox ID="txtLanguage" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr> 
                                                                <tr class="R_stepw" width="100%">
                                                                    <td width="30%">
                                                                        Contact Person:
                                                                    </td>
                                                                    <td align=left>
                                                                        <asp:TextBox ID="txtContactPerson" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>   
                                                                <tr class="R_stepw" width="100%">
                                                                    <td width="30%">
                                                                        Tel:
                                                                    </td>
                                                                    <td align=left>
                                                                        <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>     
                                                                <tr class="R_stepw" width="100%">
                                                                    <td width="30%">
                                                                        Email:
                                                                    </td>
                                                                    <td align=left>
                                                                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr class="R_stepw" width="100%">
                                                                    <td width="30%">
                                                                        Remark:
                                                                    </td>
                                                                    <td align=left>
                                                                        <textarea id="txtRemark" style="width: 98%;" rows="5" class="remark" runat="server"></textarea>
                                                                    </td>
                                                                </tr>
                                                                <tr class="R_stepw" width="100%">
                                                                    <td width="100%" colspan=2>
                                                                        <asp:Label ID="lblErrorMsg" runat="server" Text="" Visible=false></asp:Label>
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
            </tbody>
        </table>
    </div>
    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="10">
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button CssClass="search_btn02" ID="btn_button" runat="server" Text="Continue"
                    Style="cursor: hand" OnClick="btn_button_Click" meta:resourcekey="btnContinue" />&nbsp;&nbsp;
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_Click" CssClass="search_btn03"
                    Style="cursor: hand" meta:resourcekey="btnBack" />
            </td>
        </tr>
    </table>
</asp:Content>
