<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true"
    EnableEventValidation="false" Inherits="NewStep2" Codebehind="NewStep2.aspx.cs" %>

<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Components" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<%@ MasterType VirtualPath="BookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ItineraryInfo -->
    <uc5:ItineraryInfo ID="ItineraryInfo" runat="server" Visible="false"></uc5:ItineraryInfo>

    <script language="javascript" type="text/javascript">
        function DoSelect(obj){
            var isIE = document.all?true:false;
//            alert(document.getElementById("ctl00_MainContent_runFlag").value);
            if(document.getElementById("ctl00_MainContent_runFlag").value == "1"){
                return false;
            }    
            //alert(obj.parentNode.nodeName);
            
            obj.style.visibility="hidden";    
//            var img = document.createElement("img");    
//            img.src="../../images/001/loading.gif";
//            obj.parentNode.appendChild(img);
            if(isIE){
              obj.parentNode.className="loading";
            }else{
            obj.parentNode.style.width = "100%";
            obj.parentNode.className="loading";
            //obj.previousSibling.style.display="block";   
            }
            
            //obj.parentNode.className="loading";
//            alert(obj.parentNode.innerHTML);
//            obj.parentNode.innerHTML = obj.parentNode.innerHTML;
//            alert(obj.parentNode.innerHTML);
            var temp = obj.parentNode.innerHTML;
            document.getElementById("ctl00_MainContent_runFlag").value = "1";
            
        }
        
         /// </summary>
        /// <param name="index">current click row index</param>
        /// <param name="number">each airline total number</param>
        /// <param name="airline">airline name</param>
        function ShowHidePart(index,number,obj)
        {
            var RowID;
            var Loop = parseInt( index + 1 );
//            while(obj.parentNode.className == "pnlWholeFlightItem"){
//            alert(obj.parentNode.nodeName);
//              obj = obj.parentNode;
//            }
            //obj.style.background = "#edf1fd";
            for( var i=Loop; i<Loop + number; i++ )
            {
                RowID = GetdlAvailableFlightControlID(i, "pnlWholeFlightItem");
                document.getElementById( RowID ).style.display = "block";
                document.getElementById( RowID ).style.background = "#edf1fd"; 
                
            }
            var Last =   Loop + number - 1;
            var btnExpansion = GetdlAvailableFlightControlID(index, "lb_showSamePrice");
//            alert(btnExpansion);
                document.getElementById( btnExpansion ).style.display = "none";
        }
        function GetdlAvailableFlightControlID(index,id)
        {
            var indexString;        
            if(index < 10)
            {
                indexString = "0" + index;
            }
            else
            {
                indexString = index;
            }
            
            return "ctl00_MainContent_dlAvailableFlight_ctl" + indexString + "_" + id;
        }
        
        /// <summary>
        /// Hide current airline INFO
        /// </summary>
        /// <param name="index">current click row index</param>
        /// <param name="number">each airline total number</param>
        /// <param name="airline">airline name</param>
        function HidePart(index,number)
        {
            var RowID;
            var Loop = parseInt( index + 1 );
            for( var i=Loop; i<Loop + number; i++ )
            {
                RowID = GetdlAvailableFlightControlID(i, "pnlWholeFlightItem");
                document.getElementById( RowID ).style.display = "none";
            }
            var Last =   Loop + number - 1;
            var btnExpansion = GetdlAvailableFlightControlID(index, "lb_showSamePrice");
                document.getElementById( btnExpansion ).style.display = "block";
//            var btnShrink = GetdlAvailableFlightControlID(Last, "lb_hideSamePrice");
//                document.getElementById( btnShrink ).style.display = "block";
        }
    </script>

    <script language="javascript" type="text/javascript" src="../../CommJs/Tl_select_x001.js"></script>

    <script type="text/javascript" src="../../CommJs/user.js"></script>

    <div id="Div1">
        <asp:HiddenField ID="hfTabFlag" runat="server" />
        <input id="OrderId" runat="server" name="OrderId" type="hidden" value="" />
        <table width="735" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td align="left">
                    <asp:UpdatePanel ID="upAirMatrix" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <div>
                                <div class="Ajax_Tab">
                                    <ul>
                                        <li class="active" style="background: url(images/ajax_Tab1.gif) no-repeat; width: 100px;">
                                            <asp:Label ID="lblAirlineMartrix" runat="server" meta:resourcekey="lblAirlineMartrix">Airline Matrix</asp:Label></li>
                                        <li>
                                            <asp:Label ID="lblDepartureCity" runat="server" Text="Label"></asp:Label>-<asp:Label
                                                ID="lblArrivalCity" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label
                                                    ID="lblDepatureDateMsg" runat="server" meta:resourcekey="lblDepatureDateMsg">Depart Date</asp:Label>:&nbsp;<asp:Label
                                                        ID="lblDepartureDate" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;<asp:Label
                                                            ID="lblReturnDateMsg" runat="server" meta:resourcekey="lblReturnDateMsg">Return Date</asp:Label>:&nbsp;<asp:Label
                                                                ID="lblReturnDate" runat="server" Text="Label"></asp:Label></li>
                                    </ul>
                                </div>
                            </div>
                            <table class="outBord" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td style="width: 99px;">
                                        <table class="table_mode row1" cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <img src="images/MatrixFindBy.gif" alt="" border="0" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 46px; text-decoration: underline; width: 99px;" align="center">
                                                    <asp:LinkButton ID="lnkZeroStopTotal" OnClientClick="link_to_achor(this);" CommandName="ZeroStop"
                                                        OnClick="lnkZeroStopTotal_OnClick" runat="server" Style="color: #FF3300;" meta:resourcekey="lblstop0">0 stop</asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 46px; text-decoration: underline; width: 99px;" align="center">
                                                    <asp:LinkButton ID="lnkOneStopTotal" OnClientClick="link_to_achor(this);" CommandName="OneStop"
                                                        OnClick="lnkOneStopTotal_OnClick" runat="server" Style="color: #FF3300" meta:resourcekey="lblstop1">1 stops</asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 46px; text-decoration: underline; width: 99px;" align="center">
                                                    <asp:LinkButton ID="lnkMoreThanTwoStopTotal" OnClientClick="link_to_achor(this);"
                                                        CommandName="MoreThanTwoStop" OnClick="lnkMoreThanTwoStopTotal_OnClick" runat="server"
                                                        Style="color: #FF3300;" meta:resourcekey="lblstop2">2+ stops</asp:LinkButton></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 46px; border-bottom: none; font-weight: bold; color: #FF3300;
                                                    text-decoration: underline; width: 99px;" align="center">
                                                    <%--<a href="#divSelectFare">--%>
                                                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblLowFareSelect">Low Fare Select</asp:Label>
                                                    <%--</a>--%>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td>
                                        <asp:DataList ID="dlAirlineMatrics" OnItemDataBound="dlAirlineMatrics_ItemDataBound"
                                            OnItemCommand="dlAirlineMatrics_ItemCommand" runat="server" RepeatDirection="Horizontal"
                                            Width="100%" CellPadding="0" CellSpacing="0">
                                            <ItemTemplate>
                                                <table class="dataList" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <%--word-wrap: normal; word-break: keep-all; white-space: nowrap;--%>
                                                        <td style="background: rgb(234, 234, 234) none repeat scroll 0%; width: 100%; height: 54px;
                                                            _height: 55px; font-size: 11px; color: rgb(51, 102, 204); -moz-background-clip: -moz-initial;
                                                            -moz-background-origin: -moz-initial; -moz-background-inline-policy: -moz-initial;"
                                                            align="center">
                                                            <asp:LinkButton ID="lnkAirLine" OnClientClick="link_to_achor(this);" CommandName="All"
                                                                runat="server" Style="color: #FF3300; text-decoration: none;">
                                                                <asp:Image Height="18" ID="imgAirline" runat="server" ToolTip='<%# ((Airline)Eval("AirLine")).Name %>'
                                                                    Width="18" Style="text-decoration: none;"></asp:Image><br />
                                                                <asp:Label ID="Label1" runat="server" Text='<%# ((Airline)Eval("AirLine")).Code %>'
                                                                    ToolTip='<%# ((Airline)Eval("AirLine")).Name %>'></asp:Label>
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 46px; padding: 0px 10px; word-wrap: break; word-break: break-all;
                                                            white-space: nowrap;" align="center">
                                                            <asp:Label ID="lblZeroStopPrice" runat="server" Text=""></asp:Label>
                                                            <asp:LinkButton ID="lnbZeroBase" OnClientClick="link_to_achor(this);" CommandName="ZeroStop"
                                                                runat="server" Style="cursor: pointer;">
                                                                <div class="priceride price1" onmouseover="this.style.textDecoration = 'none';" onmouseout="this.style.textDecoration = 'underline';">
                                                                    $<%# ((AirMatrixFlightMeta.Price)Eval("ZeroStopPrice")).BaseFare %>
                                                                </div>
                                                                <div class="priceride price2">
                                                                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblTotal">Total</asp:Label>
                                                                    $<%# ((AirMatrixFlightMeta.Price)Eval("ZeroStopPrice")).TotalPrice%>
                                                                </div>
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 46px; padding: 0px 10px; word-wrap: break; word-break: break-all;
                                                            white-space: nowrap;" align="center">
                                                            <asp:Label ID="lblSpaceOneStopPrice" runat="server" Text=""></asp:Label>
                                                            <asp:LinkButton ID="lnbOneBase" OnClientClick="link_to_achor(this);" CommandName="OneStop"
                                                                runat="server" Style="cursor: pointer;">
                                                                <div class="priceride price1" onmouseover="this.style.textDecoration = 'none';" onmouseout="this.style.textDecoration = 'underline';">
                                                                    $<%# ((AirMatrixFlightMeta.Price)Eval("OneStopPrice")).BaseFare%>
                                                                </div>
                                                                <div class="priceride price2">
                                                                    <asp:Label ID="Label14" runat="server" meta:resourcekey="lblTotal">Total</asp:Label>
                                                                    $<%# ((AirMatrixFlightMeta.Price)Eval("OneStopPrice")).TotalPrice%>
                                                                </div>
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 46px; padding: 0px 10px; word-wrap: break; word-break: break-all;
                                                            white-space: nowrap;" align="center">
                                                            <asp:Label ID="lblSpaceMoreThanTwoStopPrice" runat="server" Text=""></asp:Label>
                                                            <asp:LinkButton ID="lnbTwoMoreBase" OnClientClick="link_to_achor(this);" CommandName="MoreThanTwoStop"
                                                                runat="server" Style="cursor: pointer;">
                                                                <div class="priceride price1" onmouseover="this.style.textDecoration = 'none';" onmouseout="this.style.textDecoration = 'underline';">
                                                                    $<%# ((AirMatrixFlightMeta.Price)Eval("MoreThanTwoStopPrice")).BaseFare%>
                                                                </div>
                                                                <div class="priceride price2">
                                                                    <%--<asp:LinkButton ID="lnbTwoMoreTotal" CommandName="MoreThanTwoStop" runat="server">--%>
                                                                    <asp:Label ID="Label16" runat="server" meta:resourcekey="lblTotal">Total</asp:Label>
                                                                    $<%# ((AirMatrixFlightMeta.Price)Eval("MoreThanTwoStopPrice")).TotalPrice%><%--</asp:LinkButton> --%>
                                                                </div>
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 46px; padding: 0px 10px; word-wrap: break; word-break: break-all;
                                                            white-space: nowrap; border-bottom: none;" align="center">
                                                            <asp:Label ID="lblSpaceSelect" runat="server" Text=""></asp:Label>
                                                            <a href="#divSelectFare" id="lnbSelect" onclick="select_linktoAchor()" runat="server"
                                                                style="cursor: pointer; color: #3366CC;">
                                                                <div class="priceride price3" onmouseover="this.style.textDecoration = 'none';" onmouseout="this.style.textDecoration = 'underline';">
                                                                    <asp:Label ID="lblLowFareSelect" runat="server">$<%# ((AirMatrixFlightMeta.Price)Eval("LowFareSelectPrice")).BaseFare%> </asp:Label>
                                                                </div>
                                                                <div class="priceride price2">
                                                                    <asp:Label ID="lblLowFareSelectTooltip" runat="server">
                                                                        <asp:Label ID="Label18" runat="server" meta:resourcekey="lblBase">Base</asp:Label></asp:Label>
                                                                </div>
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>

                                        <script type="text/javascript">
                                    function lowestFlightBold(){
//                                     
//                                    
                                    }
                                    if($("ctl00_MainContent_dlAirlineMatrics")){
//                                          lowestFlightBold();
                                        }
                                        </script>

                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:UpdatePanel ID="upShowAllAirline" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <table border="0" width="100%" style="float: left;">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="Label11" runat="server" Text="* Fares are in US dollars per person"
                                            CssClass="Label11" Style="color: #ff0000; float: left; display: block;" meta:resourcekey="lblFaresUS"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:LinkButton ID="lbShowAllAirlines" OnClick="lbShowAllAirlines_Click" Visible="false"
                                            runat="server" Style="float: right; font-weight: bold; color: #005599;" meta:resourcekey="lblShowmore">Show more airlines »</asp:LinkButton>
                                        <div style="clear: both;">
                                            <asp:LinkButton ID="lbHideMoreAirlines" OnClick="lbHiddenMoreAirlines_Click" Visible="false"
                                                runat="server" Style="float: right; font-weight: bold;" meta:resourcekey="lblCollapse">« Collapse</asp:LinkButton>
                                            <div style="clear: both;">
                                            </div>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td height="10">
                </td>
            </tr>
            <tr>
                <td width="735">
                    <table width="735" border="0" cellspacing="1" cellpadding="4" class="T_step03">
                        <tr class="R_stepw">
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                                    <tr>
                                        <td align="left">
                                            <img src="Images/btn_available.gif" hspace="2" vspace="5" border="0" align="absmiddle" />
                                            <asp:Label ID="lblSeatsSearch" runat="server" meta:resourcekey="lblSeatsSearch">
                                            : Seats are available now. You can book without further search.</asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Panel ID="pnlContactMsg" runat="server">
                                                <img src="Images/btn_contactagt.gif" hspace="2" vspace="5" border="0" align="absmiddle" />
                                                <asp:Label ID="lblContactAgt" runat="server" meta:resourcekey="lblContactAgt">
                                             : Please call or chat with our agent. Manual search is required since you choose
                                            foreign airlines and non-gateway departure city/airport.</asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Panel ID="pnlSelectMsg" runat="server">
                                                <img src="Images/btn_select.gif" hspace="2" vspace="5" border="0" align="absmiddle" />
                                                <asp:Label ID="lblLowerAvailability" runat="server" meta:resourcekey="lblLowerAvailability"><span style="color:red">: Lower fare might be available</span>, but further search required to check availability.(If
                                            click "Select" button 2 or 3 times and can not find available seats, please click
                                            "Contact Agt" to chat or call our agent immediately to save your time.)</asp:Label>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                </td>
            </tr>
            <tr>
                <td align="left" height="10">
                    <div>
                        <asp:Label ID="lblReminder" runat="server" Visible="False" meta:resourcekey="lblReminder"> <span style="font-weight:bold;color: red"> REMINDER: </span>Since you have not joined our membership program, you can see publish fares only.
                                            Please join now, and you will be able to search and book SUPER DISCOUNT AIRFARES.<BR>&nbsp;</asp:Label></div>
                </td>
            </tr>
            <tr>
                <td width="735">
                    <asp:UpdatePanel ID="upFilterMessage" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hfFilteredLoad" runat="server" />
                            <asp:Panel ID="pnlBackToAllResults" class="loadPage" Visible="false" runat="server" width="731">
                                <span class="loadPage_lable" style="">
                                    <asp:Label ID="Label20" runat="server" meta:resourcekey="lblFilter">Filter is on</asp:Label>
                                    : </span>
                                <asp:LinkButton ID="lnkBackToAllResults" OnClientClick="link_to_achor(this);" OnClick="lnkBackToAllResults_OnClick"
                                    Style="color: #5C82E6;" runat="server" meta:resourcekey="lblBackToAll">Back to all results display</asp:LinkButton>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div id="TabFlight" class="TabFlight" style="width: 735px; float: left;">
                        <ul>
                            <li id="divAvailableFlight" class="AvailabledTab" onclick="tab_Select(this);">
                                <asp:Label ID="lblAvailableTab" runat="server" meta:resourcekey="lblAvailableTab">Available</asp:Label></li>
                            <li id="divSelectFare" onclick="tab_Select(this);">
                                <asp:Label ID="lblSelectTab" runat="server" meta:resourcekey="lblSelectTab">Select</asp:Label></li>
                        </ul>
                        <table id="sortDIV" cellpadding="0" cellspacing="0" border="0" class="sort_row right"
                            width="420">
                            <tr>
                                <td align="right">
                                    <%--<div>
                                                <div class="Airfare_More" onclick="dlFlight_Show()">
                                                    More</div>
                                                <div class="Airfare_Hide" onclick="dlFlight_Hide()">
                                                    (&nbsp;Hide&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;)</div>
                                            </div>--%>
                                    <asp:UpdatePanel ID="upSrotByMessage" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <div style="float: right; text-align: right; margin: 3px; margin-left: 10px;">
                                                <asp:Label ID="lblSortBy" runat="server" Text="Sort By:" meta:resourcekey="lblSortBy"
                                                    Style="float: left; color: #2B4D87; margin-right: 8px; font-weight: bold; display: block;"></asp:Label>
                                                <asp:LinkButton ID="lb_sortPrice" runat="server" CssClass="sortClass">
                                                    <asp:Label ID="lbl_sortPrice" meta:resourcekey="lb_sortPrice" runat="server" Text="Label">Price</asp:Label><asp:Image
                                                        ID="img_priceUp" ImageUrl="~/Page/Flight/images/sort-up.gif" runat="server" Visible="false">
                                                    </asp:Image><asp:Image ID="img_priceDown" ImageUrl="~/Page/Flight/images/sort-down.gif"
                                                        runat="server" Visible="false"></asp:Image></asp:LinkButton>
                                                <asp:LinkButton ID="lb_sortAirline" runat="server" CssClass="sortClass" >
                                                    <asp:Label ID="Label33" runat="server" meta:resourcekey="lb_sortAirline">Airline</asp:Label><asp:Image ID="img_airlineUp" ImageUrl="~/Page/Flight/images/sort-up.gif"
                                                        runat="server" Visible="false"></asp:Image><asp:Image ID="img_airlineDown" ImageUrl="~/Page/Flight/images/sort-down.gif"
                                                            runat="server" Visible="false"></asp:Image></asp:LinkButton>
                                                <asp:LinkButton ID="lb_sortDuration" runat="server" CssClass="sortClass" >
                                                    <asp:Label ID="Label34" runat="server" meta:resourcekey="lb_sortDuration">Duration</asp:Label><asp:Image ID="img_DurationUp" ImageUrl="~/Page/Flight/images/sort-up.gif"
                                                        runat="server" Visible="false"></asp:Image><asp:Image ID="img_DurationDown" ImageUrl="~/Page/Flight/images/sort-down.gif"
                                                            runat="server" Visible="false"></asp:Image></asp:LinkButton>
                                                <asp:LinkButton ID="lb_sortDeparture" runat="server" CssClass="sortClass" >
                                                    <asp:Label ID="Label35" runat="server" meta:resourcekey="lb_sortDeparture">Departure Time</asp:Label><asp:Image ID="img_departureUp" ImageUrl="~/Page/Flight/images/sort-up.gif"
                                                        runat="server" Visible="false"></asp:Image><asp:Image ID="img_departureDown" ImageUrl="~/Page/Flight/images/sort-down.gif"
                                                            runat="server" Visible="false"></asp:Image></asp:LinkButton>
                                                <asp:LinkButton ID="lb_sortArrival" runat="server" CssClass="sortClass" >
                                                    <asp:Label ID="Label36" runat="server" meta:resourcekey="lb_sortArrival">Arrival Time</asp:Label><asp:Image ID="img_arrivalUp" ImageUrl="~/Page/Flight/images/sort-up.gif"
                                                        runat="server" Visible="false"></asp:Image><asp:Image ID="img_arrivalDown" ImageUrl="~/Page/Flight/images/sort-down.gif"
                                                            runat="server" Visible="false"></asp:Image></asp:LinkButton>
                                                <%--<div class="arrow_Button">
                                                <div>
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="images/arrow_top.jpg"
                                                        CssClass="left" Style="border: none;" /></div>
                                                <div>
                                                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="images/arrow_bottom.jpg"
                                                        CssClass="left" Style="border: none;" /></div>
                                            </div>--%>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <asp:UpdatePanel ID="upAvailable" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <table class="gridviewBorder" cellpadding="0" cellspacing="0" border="0" width="735"
                                id="dlAvailableFlight1" style="float: left;">
                                <tr>
                                    <td>
                                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="upFilterMessage"
                                            DynamicLayout="true" EnableViewState="true">
                                            <ProgressTemplate>
                                                <div style="width: 99%; height: 45px; border: 3px solid #ffcc00; background: #ffffbd;
                                                    text-align: center; float: left;">
                                                    <div style="height: 20px; line-height: 20px; font-size: 14px; color: #336699; font-family: Verdana;">
                                                        <asp:Label ID="lblUpdate" runat="server" meta:resourcekey="lblUpdate">Update. Please wait...</asp:Label></div>
                                                    <div>
                                                        <img src="Images/24-1.gif" />&nbsp;&nbsp;<img src="Images/24-1.gif" />&nbsp;&nbsp;<img
                                                            src="Images/24-1.gif" /></div>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdateProgress ID="upProgressAvailable" runat="server" AssociatedUpdatePanelID="upAirMatrix"
                                            DynamicLayout="true" EnableViewState="true">
                                            <ProgressTemplate>
                                                <div style="width: 99%; height: 45px; border: 3px solid #ffcc00; background: #ffffbd;
                                                    text-align: center; float: left;">
                                                    <div style="height: 20px; line-height: 20px; font-size: 14px; color: #336699; font-family: Verdana;">
                                                        <asp:Label ID="label25" runat="server" meta:resourcekey="lblUpdate">Update. Please wait...</asp:Label></div>
                                                    <div>
                                                        <img src="Images/24-1.gif" />&nbsp;&nbsp;<img src="Images/24-1.gif" />&nbsp;&nbsp;<img
                                                            src="Images/24-1.gif" /></div>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdateProgress ID="upProgressShowAirlines" runat="server" AssociatedUpdatePanelID="upShowAllAirline"
                                            DynamicLayout="true" EnableViewState="true">
                                            <ProgressTemplate>
                                                <div style="width: 99%; height: 45px; border: 3px solid #ffcc00; background: #ffffbd;
                                                    text-align: center; float: left;">
                                                    <div style="height: 20px; line-height: 20px; font-size: 14px; color: #336699; font-family: Verdana;">
                                                        <asp:Label ID="label29" runat="server" meta:resourcekey="lblUpdate">Update. Please wait...</asp:Label></div>
                                                    <div>
                                                        <img src="Images/24-1.gif" />&nbsp;&nbsp;<img src="Images/24-1.gif" />&nbsp;&nbsp;<img
                                                            src="Images/24-1.gif" /></div>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdateProgress ID="upProgressSortBy" runat="server" AssociatedUpdatePanelID="upSrotByMessage"
                                            DynamicLayout="true" EnableViewState="true">
                                            <ProgressTemplate>
                                                <div style="width: 99%; height: 45px; border: 3px solid #ffcc00; background: #ffffbd;
                                                    text-align: center; float: left;">
                                                    <div style="height: 20px; line-height: 20px; font-size: 14px; color: #336699; font-family: Verdana;">
                                                        <asp:Label ID="label30" runat="server" meta:resourcekey="lblUpdate">Update. Please wait...</asp:Label></div>
                                                    <div>
                                                        <img src="Images/24-1.gif" />&nbsp;&nbsp;<img src="Images/24-1.gif" />&nbsp;&nbsp;<img
                                                            src="Images/24-1.gif" /></div>
                                                </div>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upAvailable"
                                            DynamicLayout="true" EnableViewState="true">
                                            <ProgressTemplate>
                                                <asp:Panel ID="pnlAvailableProcessing" runat="server" Style="width: 500px; height: 45px;
                                                    border: 3px solid #ffcc00; background: #ffffbd; text-align: center;">
                                                    <div style="height: 20px; line-height: 20px; font-size: 14px; color: #336699; font-family: Verdana;">
                                                        <asp:Label ID="label26" runat="server" meta:resourcekey="lblProcessing">Processing. Please wait...</asp:Label></div>
                                                    <div>
                                                        <img src="Images/24-1.gif" />&nbsp;&nbsp;<img src="Images/24-1.gif" />&nbsp;&nbsp;<img
                                                            src="Images/24-1.gif" /></div>
                                                </asp:Panel>
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                        <ajaxToolkit:AlwaysVisibleControlExtender ID="avce" runat="server" TargetControlID="pnlAvailableProcessing"
                                            VerticalSide="Middle" VerticalOffset="0" HorizontalSide="Center" HorizontalOffset="100"
                                            ScrollEffectDuration=".1" />
                                        <asp:Panel ID="pnlCannotBookMsg" runat="server" class="tips_ConfirmAvailalbeContinue"
                                            Style="display: none;">
                                            <div class="message1">
                                                <asp:Label ID="lbl_pnlCannotBookMsg" runat="server" Text="Due to airfare changes by airlines,the original quoted price is increased by <span style='color:red;'>$40</span>.<br />Do you want to continue? Yes or No."></asp:Label>&nbsp;
                                                <div class="message_btn">
                                                    <input type="button" id="Button3" onclick="$('ctl00_MainContent_pnlCannotBookMsg').style.display='none';$('maskDIV').style.display='none';"
                                                        class="search_btn" style="width: 100px;" value="OK" />
                                                </div>
                                            </div>
                                            <div>
                                                &nbsp; &nbsp;&nbsp;</div>
                                        </asp:Panel>

                                        <script type="text/javascript">
                                      $('ctl00_MainContent_pnlCannotBookMsg').style.display='none';
                                        </script>

                                        <ajaxToolkit:AlwaysVisibleControlExtender ID="avceCannotBookMsg" runat="server" TargetControlID="pnlCannotBookMsg"
                                            VerticalSide="Middle" VerticalOffset="0" HorizontalSide="Center" HorizontalOffset="100"
                                            ScrollEffectDuration=".1" />
                                        <asp:Panel ID="pnlComfirm" runat="server" class="tips_ConfirmAvailalbeContinue" Style="display: none;">
                                            <div class="message1">
                                                <asp:Label ID="lblSoldOutMsg" runat="server" Text="Due to airfare changes by airlines,the original quoted price is increased by <span style='color:red;'>$40</span>.<br />Do you want to continue? Yes or No."></asp:Label>&nbsp;
                                                <div class="message_btn">
                                                    <input type="button" id="LinkButton1" onclick="window.location.href = window.location.href.replace('NewStep2.aspx','Step3_confirm.aspx');"
                                                        class="search_btn" style="width: 70px;" value="Yes" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <input type="button" id="LinkButton2" onclick="document.getElementById('ctl00_MainContent_pnlComfirm').style.display='none';$('maskDIV').style.display='none'; return false;"
                                                        class="search_btn" style="width: 70px;" value="No" />
                                                </div>
                                            </div>
                                            <div>
                                                &nbsp; &nbsp;&nbsp;</div>
                                        </asp:Panel>

                                        <script type="text/javascript">
                                      $('ctl00_MainContent_pnlComfirm').style.display='none';
                                        </script>

                                        <ajaxToolkit:AlwaysVisibleControlExtender ID="avceComfirm" runat="server" TargetControlID="pnlComfirm"
                                            VerticalSide="Middle" VerticalOffset="0" HorizontalSide="Center" HorizontalOffset="100"
                                            ScrollEffectDuration=".1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="735">
                                        <asp:DataList ID="dlAvailableFlight" runat="server" OnItemDataBound="dlAvailable_ItemDataBound"
                                            OnItemCommand="dlAvailable_ItemCommand">
                                            <ItemTemplate>
                                                <asp:Panel ID="pnlWholeFlightItem" runat="server" class="pnlWholeFlightItem">
                                                    <div class="outside1T">
                                                        <div style="border-bottom: 2px solid #ccc; float: left; margin: 5px; display: inline;
                                                            padding-bottom: 0px; width: 711px;">
                                                            <table class="gridview" cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td width="624">
                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <asp:Label ID="lbl_Airline" runat="server" CssClass="corpname" Text='<%#  ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Name == null ? ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Code : ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Name %>'></asp:Label>&nbsp;&nbsp;<asp:Label
                                                                                        ID="lbViewDetails" meta:resourcekey="lbViewDetails" runat="server" class="Details"
                                                                                        onclick="toggle_Trip(this);">View Details</asp:Label></td>
                                                                                <td align="right">
                                                                                    <div>
                                                                                        <span class="blueColor"><asp:Label ID="Label32" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).FareType.ToString("G") %>' Visible=false ></asp:Label><asp:Label ID="lbl_XXXXX" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Airline.Code") %>' Visible=false ></asp:Label>
                                                                                            <asp:Label ID="Label31" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>:
                                                                                        </span>
                                                                                        <asp:Label ID="Label15" CssClass="PriceByRed" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultMarkup).ToString("$#,###") %>'></asp:Label>
                                                                                        <asp:Label ID="Label27" runat="server" meta:resourcekey="lblBase" Style="color: #666;">base</asp:Label>
                                                                                        <asp:Label ID="Label17" runat="server" Text='<%# " + " + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultTax.ToString("$#,###.##") %>'></asp:Label><asp:Label
                                                                                            ID="lblAdultTaxMsg" meta:resourcekey="lblTaxMsg" runat="server" Text="tax" Style="color: #666;"></asp:Label>
                                                                                        <asp:Label ID="lblTax" runat="server" Text='<%# " = " +  (((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultMarkup + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultTax).ToString("$#,###.##") + " " %>'
                                                                                            Style="color: #666;"></asp:Label><asp:Label ID="lblAdultTotalMsg" meta:resourcekey="lblTotalMsg"
                                                                                                runat="server" Text="total" Style="color: #666;"></asp:Label></div>
                                                                                    <!--Child 默认隐藏-->
                                                                                    <asp:Panel ID="divChildFareDetail" runat="server">
                                                                                        <span class="blueColor">
                                                                                            <asp:Label ID="Label22" runat="server" meta:resourcekey="lblChild">Child</asp:Label>:
                                                                                        </span>
                                                                                        <asp:Label ID="Label12" CssClass="PriceByRed" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildMarkup).ToString("$#,###") %>'></asp:Label>
                                                                                        <asp:Label ID="Label28" runat="server" meta:resourcekey="lblBase" Style="color: #666;">base</asp:Label>
                                                                                        <asp:Label ID="Label13" runat="server" Text='<%# " + " + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildTax.ToString("$#,###.##")+  " "%>'
                                                                                            Style="color: #666;"></asp:Label><asp:Label ID="lblChildTaxMsg" meta:resourcekey="lblTaxMsg"
                                                                                                runat="server" Text="tax" Style="color: #666;"></asp:Label>
                                                                                        <asp:Label ID="lblChildTotal" runat="server" Text='<%# " = " + (((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildMarkup + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildTax).ToString("$#,###.##") + " " %>'
                                                                                            Style="color: #666;"></asp:Label><asp:Label ID="lblChildTotalMsg" meta:resourcekey="lblTotalMsg"
                                                                                                runat="server" Text="total" Style="color: #666;"></asp:Label>
                                                                                    </asp:Panel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="float: left;
                                                                            margin-top: 5px;">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Image Height="18" ID="AirImgRtn1" runat="server" Width="18"></asp:Image>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:DataList ID="dlSubTrips" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                        OnItemDataBound="dlSubTrips_ItemDataBound" DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'>
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
                                                                                                    <td style="color: #2B4D87; width: 60px;" align="right">
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
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                    <td width="15%" align="center">
                                                                        <table>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label19" CssClass="blueByPrice" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultMarkup).ToString("$#,###") %>'></asp:Label>
                                                        </div>
                                                        </td> </tr>
                                                        <!--Child 默认隐藏-->
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="divChildFare" Visible="false" runat="server" class="left" Style="width: 100%;">
                                                                    <div class="blueByPrice_span" style="font-size: 11px; margin-top: 3px;">
                                                                        <asp:Label ID="Label23" runat="server" meta:resourcekey="lblChild">Child</asp:Label>:</div>
                                                                    <asp:Label ID="Label10" CssClass="blueByPrice" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildMarkup).ToString("$#,###") %>'></asp:Label></asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:ImageButton ID="ImageButton1" OnClientClick="positionUpdatePanel();" Style="cursor: hand"
                                                                    ImageUrl="Images/btn_available.gif" runat="server" CommandName="Avail" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <asp:Label ID="Label21" runat="server" Text="per person" CssClass="perPerson" meta:resourcekey="lblPerPerson"></asp:Label></span>
                                                            </td>
                                                        </tr>
                                                        </table> </td> </tr>
                                                        <tr>
                                                            <td align=right><asp:Label ID="lbDispWarnMessage" ForeColor="red" runat="server"></asp:Label></td>
            <td height="20" align="right" valign="bottom">
                                                                <a title="Overnight Flight">
                                                                    <asp:Image ID="imgOverNight" runat="server" ImageUrl="../../images/v2/ec_redeye.gif" Visible=false
                                                                        alt="Overnight Flight" /></a><a title="Flight operated by a different carrier"><asp:Image
                                                                            ID="imgCodeShared" runat="server" ImageUrl="../../images/v2/ec_codeshare.gif" Visible=false alt="Flight operated by a different carrier" /></a>
                                                                <%--<asp:Label ID="lbDispOverNightMessage" ForeColor="red" runat="server" Visible="false"></asp:Label>--%>
                                                                
                                                                </td>
                                                        </tr>
                                                        </table>
                                                        <asp:Panel title="TripDetail" ID="Panel1" runat="server" Style="border-top: 1px dotted #808080;
                                                            width: 100%; float: left; display: none;">
                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 6px;
                                                                float: left; text-align: left;">
                                                                <tr>
                                                                    <td>
                                                                        <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                                                            <tr class="R_order">
                                                                                <td width="25%" height="23">
                                                                                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlightInfo">Flight Info</asp:Label></td>
                                                                                <td width="25%">
                                                                                    <asp:Label ID="lblDeparture" runat="server" meta:resourcekey="lblDeparture">Departure</asp:Label></td>
                                                                                <td width="25%">
                                                                                    <asp:Label ID="lblArrive" runat="server" meta:resourcekey="lblArrive">Arrival</asp:Label></td>
                                                                                <td width="10%">
                                                                                    <asp:Label ID="lblStops" runat="server" meta:resourcekey="lblStops">Stops</asp:Label></td>
                                                                                <td width="15%">
                                                                                    <asp:Label ID="lblDuration" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label></td>
                                                                            </tr>
                                                                        </table>
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <!-- Line 1-->
                                                                                    <asp:DataList ID="dlFlights" runat="server" Width="100%" AlternatingItemStyle-BackColor="Silver"
                                                                                        BorderWidth="0" CellPadding="0" CellSpacing="0" OnItemDataBound="dlFlights_ItemDataBound">
                                                                                        <ItemTemplate>
                                                                                            <table border="0" cellspacing="1" cellpadding="3" width="100%" class="T_step03">
                                                                                                <tr align="left" class="R_stepw">
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
                                                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                                        </asp:Label>
                                                                                                        <asp:Label ID="lblDepDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.DepartureTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo)%>'>
                                                                                                        </asp:Label>
                                                                                                        <br />
                                                                                                        <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.City.Name") %>'>
                                                                                                        </asp:Label>
                                                                                                        (<asp:Label ID="Label5" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DepartureAirport.Code") %>'>
                                                                                                        </asp:Label>)<br />
                                                                                                    </td>
                                                                                                    <td width="25%">
                                                                                                        <asp:Label ID="Label6" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                                        </asp:Label>
                                                                                                        <asp:Label ID="lblArrDate" runat="server" Text='<%# Convert.ToDateTime(DataBinder.Eval(Container, "DataItem.ArriveTime")).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'>
                                                                                                        </asp:Label>
                                                                                                        <br />
                                                                                                        <asp:Label ID="Label7" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.City.Name") %>'>
                                                                                                        </asp:Label>
                                                                                                        (<asp:Label ID="Label8" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.DestinationAirport.Code") %>'>
                                                                                                        </asp:Label>)<br />
                                                                                                    </td>
                                                                                                    <td width="10%" align="center"><%--<%# DataBinder.Eval(Container, "DataItem.BookingClass")%>--%>
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
                                                                            <tr>
                                                                                <td align="left" height="20">
                                                                                    <asp:Label ID="lblTotalDistanceMsg" meta:resourcekey="lblTotalDistanceMsg" runat="server"
                                                                                        Text="Label" style="display:none" >Total distance: </asp:Label><asp:Label ID="lblTotalDistance" runat="server"
                                                                                            Text="Label" style="display:none" >9,922 miles (15,968 km) </asp:Label>
                                                                                            </td>
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
                                                        </asp:Panel>
                                                        <asp:Label ID="lb_showSamePrice" runat="server" Style="margin: 5px; color: red; float: right;
                                                            cursor: pointer;" meta:resourcekey="lblshowSamePrice"><span style="text-decoration:underline;">show {0} more flight(s) at this price</span> <img alt="Up" src="images/show_down.gif" /></asp:Label>
                                                        <asp:Label ID="lb_hideSamePrice" runat="server" Style="display: none; margin: 5px;
                                                            color: red; float: right; cursor: pointer;" meta:resourcekey="lblshowFirstPrice"><span style="text-decoration:underline;">show first itinerary at this price only</span> <img alt="Down" src="images/show_up.gif" /></asp:Label>
                                                    </div>
                                                    </div>
                                                    <div style="height: 1px; clear: both; width: 100%;">
                                                    </div>
                                                </asp:Panel>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc4:PageNumber ID="PageNumber1" PageSize="10" runat="server"></uc4:PageNumber>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <table class="gridviewBorder" id="dlselectFlight" cellpadding="0" cellspacing="0"
                        border="0" width="735" style="display: none; float: left;">
                        <tr>
                            <td width="735">
                                <table>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:UpdatePanel ID="upSelect" runat="server">
                                                    <ContentTemplate>
                                                        <div>
                                                            <asp:Panel ID="pnlSelectProcessing" runat="server" Style="width: 500px; height: 45px;
                                                                border: 3px solid #ffcc00; background: #ffffbd; text-align: center; position: absolute;
                                                                display: none;">
                                                                <div style="height: 20px; line-height: 20px; font-size: 14px; color: #336699; font-family: Verdana;">
                                                                    <asp:Label ID="lblProcessingWaitingMsg_Select" meta:resourcekey="lblProcessing" runat="server"
                                                                        Text="Processing. Please wait..."></asp:Label></div>
                                                                <div>
                                                                    <img src="Images/24-1.gif" />&nbsp;&nbsp;<img src="Images/24-1.gif" />&nbsp;&nbsp;<img
                                                                        src="Images/24-1.gif" /></div>
                                                            </asp:Panel>
                                                            <ajaxToolkit:AlwaysVisibleControlExtender ID="avce_SelectProcessing" runat="server"
                                                                TargetControlID="pnlSelectProcessing" VerticalSide="Middle" VerticalOffset="0"
                                                                HorizontalSide="Center" HorizontalOffset="100" ScrollEffectDuration=".1" />
                                                            <asp:Panel ID="pnlCannotBookMsg_Select" runat="server" class="tips_ConfirmAvailalbeContinue"
                                                                Style="display: none;">
                                                                <div class="message1">
                                                                    <asp:Label ID="lbl_pnlCannotBookMsg_Select" runat="server" Text="Due to airfare changes by airlines,the original quoted price is increased by <span style='color:red;'>$40</span>.<br />Do you want to continue? Yes or No."></asp:Label>&nbsp;
                                                                    <div class="message_btn">
                                                                        <input type="button" id="Button4" onclick="$('ctl00_MainContent_pnlCannotBookMsg_Select').style.display='none';$('maskDIV').style.display='none';"
                                                                            class="search_btn" style="width: 100px;" value="OK" />
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    &nbsp; &nbsp;&nbsp;</div>
                                                            </asp:Panel>

                                                            <script type="text/javascript">
                                      $('ctl00_MainContent_pnlCannotBookMsg_Select').style.display='none';
                                                            </script>

                                                            <ajaxToolkit:AlwaysVisibleControlExtender ID="avce_pnlCannotBookMsg_Select" runat="server"
                                                                TargetControlID="pnlCannotBookMsg_Select" VerticalSide="Middle" VerticalOffset="0"
                                                                HorizontalSide="Center" HorizontalOffset="100" ScrollEffectDuration=".1" />
                                                            <asp:Panel ID="pnlComfirm_Select" runat="server" class="tips_ConfirmAvailalbeContinue"
                                                                Style="display: none;">
                                                                <div class="message1">
                                                                    <asp:Label ID="lblSoldOutMsg_Select" runat="server" Text="Due to airfare changes by airlines,the original quoted price is increased by <span style='color:red;'>$40</span>.<br />Do you want to continue? Yes or No."></asp:Label>&nbsp;
                                                                    <div class="message_btn">
                                                                        <input type="button" id="Button1" onclick="window.location.href = window.location.href.replace('NewStep2.aspx','Step3_confirm.aspx');"
                                                                            class="search_btn" style="width: 60px;" value="Yes" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        <input type="button" id="Button2" onclick="document.getElementById('ctl00_MainContent_pnlComfirm_Select').style.display='none';$('maskDIV').style.display='none'; return false;"
                                                                            class="search_btn" style="width: 60px;" value="No" />
                                                                    </div>
                                                                </div>
                                                                <div>
                                                                    &nbsp; &nbsp;&nbsp;</div>
                                                            </asp:Panel>

                                                            <script type="text/javascript">
                                      $('ctl00_MainContent_pnlComfirm_Select').style.display='none';
                                                            </script>

                                                            <ajaxToolkit:AlwaysVisibleControlExtender ID="avce_pnlComfirm_Select" runat="server"
                                                                TargetControlID="pnlComfirm_Select" VerticalSide="Middle" VerticalOffset="0"
                                                                HorizontalSide="Center" HorizontalOffset="100" ScrollEffectDuration=".1" />
                                                            <asp:HiddenField ID="runFlag" runat="server" Value="0" />
                                                            <asp:DataList ID="dlSelectContact" runat="server" OnItemDataBound="dlAirFare_ItemDataBound"
                                                                OnItemCommand="dlAirFare_ItemCommand">
                                                                <ItemTemplate>
                                                                    <div class="outside1T">
                                                                        <div style="border-bottom: 2px solid #ccc; float: left; margin: 5px; display: inline;
                                                                            padding-bottom: 0px; width: 711px;">
                                                                            <table class="gridview" cellpadding="0" cellspacing="0" border="0">
                                                                                <tr>
                                                                                    <td width="624">
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:Image Height="18" ID="imgAirlineSelect" Visible="false" runat="server" title='<%# ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Code %>'
                                                                                                        Width="18"></asp:Image><asp:Label ID="lblAirlineSpace" Visible="false" runat="server"
                                                                                                            Text="&nbsp;"></asp:Label><asp:Label ID="lbl_Airline" CssClass="corpname" valign="bottom"
                                                                                                                runat="server" Text='<%#  ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Name == null ? ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Code : ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Name %>'></asp:Label></td>
                                                                                                <td align="right">
                                                                                                    <div>
                                                                                                        <span class="blueColor">
                                                                                                            <asp:Label ID="label23" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label>:
                                                                                                        </span>
                                                                                                        <asp:Label ID="lbl_AdultFare" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultMarkup).ToString("$#,###") + " "%>'
                                                                                                            CssClass="PriceByRed"></asp:Label><span style="color: #2B4D87;">base</span>
                                                                                                        <asp:Label ID="lblAdultTaxTotal" runat="server" Text='<%# " + " + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultTax.ToString("$#,###.##") +  " tax = " + (((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultMarkup + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultTax).ToString("$#,###.##") + " total" %>'
                                                                                                            Style="color: #2B4D87;"></asp:Label></div>
                                                                                                    <!--Child 默认隐藏-->
                                                                                                    <asp:Panel ID="divChildFareDetail" runat="server">
                                                                                                        <span class="blueColor">
                                                                                                            <asp:Label ID="label24" runat="server" meta:resourcekey="lblChild">Child</asp:Label>:
                                                                                                        </span>
                                                                                                        <asp:Label ID="Label12" CssClass="PriceByRed" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildMarkup).ToString("$#,###") + " "%>'></asp:Label><span
                                                                                                            style="color: #2B4D87;">base</span>
                                                                                                        <asp:Label ID="lblChildTaxTotal" runat="server" Text='<%# " + " + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildTax.ToString("$#,###.##") +  " tax = " + (((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildMarkup + ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildTax).ToString("$#,###.##") + " total" %>'
                                                                                                            Style="color: #2B4D87;"></asp:Label></asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="float: left;
                                                                                            margin-top: 5px;">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:Image Height="18" ID="AirImgRtn1" runat="server" title='<%# ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Code %>'
                                                                                                        Width="18"></asp:Image>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DataList ID="dlSubTrips" runat="server" CellPadding="0" CellSpacing="0" Width="100%"
                                                                                                        OnItemDataBound="dlSubTrips_ItemDataBound" DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'>
                                                                                                        <ItemTemplate>
                                                                                                            <table class="dlSubTrips" cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                                                                <tr>
                                                                                                                    <td rowspan="2">
                                                                                                                    </td>
                                                                                                                    <td align="center" style="font-size: 11px; width: 60px;">
                                                                                                                        <%# ((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[0].DepartureAirport.Code %>
                                                                                                                    </td>
                                                                                                                    <td align="center" style="color: #666; width: 180px;">
                                                                                                                        <asp:Label ID="lblDepDate" CssClass="lblDepDate" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[0].DepartureTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + "  " %>'>
                                                                                                                        </asp:Label>
                                                                                                                    </td>
                                                                                                                    <td align="center" style="font-size: 11px; width: 60px;">
                                                                                                                        <%# ((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].DestinationAirport.Code %>
                                                                                                                    </td>
                                                                                                                    <td align="center" style="color: #666; width: 180px;">
                                                                                                                        <asp:Label ID="lblArrDate" CssClass="lblArrDate" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].ArriveTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label>
                                                                                                                    </td>
                                                                                                                    <td style="color: #2B4D87;" align="right">
                                                                                                                        <asp:Label ID="lblStops" runat="server"><%# (((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1) %></asp:Label>
                                                                                                                        <asp:Label ID="label23" runat="server" meta:resourcekey="lblstop">stop(s)</asp:Label></td>
                                                                                                                    <td align="center" style="color: #2B4D87;">
                                                                                                                        <asp:Label ID="lblDurationMsg_SubTrips" meta:resourcekey="lblDurationMsg_SubTrips"
                                                                                                                            runat="server">
                                                                                                                            <asp:Label ID="label25" runat="server" meta:resourcekey="lb_sortDuration">Duration</asp:Label>:</asp:Label>
                                                                                                                        <asp:Label ID="lblDuration" runat="server" Style="color: #666;">35hr55mn</asp:Label></td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:DataList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td width="15%" align="center">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblDisplayMoney" CssClass="blueByPrice" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).AdultMarkup).ToString("$#,###") %>'></asp:Label>
                                                                        </div>
                                                                        </td> </tr>
                                                                        <!--Child 默认隐藏-->
                                                                        <tr>
                                                                            <td>
                                                                                <img src="images/loading.gif" style="display: none;" id="IMGloading" /><asp:ImageButton
                                                                                    ID="btnSelect" Style="cursor: hand" ImageUrl="Images/btn_select.gif" runat="server"
                                                                                    OnClientClick="return  DoSelect(this)" CommandName="Select" />
                                                                                <asp:ImageButton ID="btnAvail" OnClientClick="positionUpdatePanel();$('ctl00_MainContent_pnlSelectProcessing').style.display ='block';"
                                                                                    Style="cursor: hand" ImageUrl="Images/btn_available.gif" runat="server" Visible="false"
                                                                                    CommandName="Avail" />
                                                                                <asp:ImageButton ID="btnContactAgt" CommandName="ContactAgt" ImageUrl="Images/btn_contactagt.gif"
                                                                                    runat="server" OnClientClick="return  false;" Visible="false" Enabled="true"></asp:ImageButton>
                                                                                <asp:ImageButton ID="btnNotAvail" CommandName="NotAvail" ImageUrl="Images/btn_unavailable.gif"
                                                                                    runat="server" OnClientClick="return  false;" Visible="false" Enabled="true"></asp:ImageButton>
                                                                                <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="btnNotAvail"
                                                                                    PopupControlID="PopupMenu" HoverCssClass="popupHover" PopupPosition="Left" OffsetX="0"
                                                                                    OffsetY="0" PopDelay="50">
                                                                                </ajaxToolkit:HoverMenuExtender>
                                                                                <asp:Panel ID="PopupMenu" runat="server" Visible="false">
                                                                                    <table bgcolor="silver">
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Label ID="lbl_ErrorMessage" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="divChildFare" Visible="false" runat="server" class="left" Style="width: 100%;">
                                                                                    <div class="blueByPrice_span" style="font-size: 11px; margin-top: 3px;">
                                                                                        <asp:Label ID="label26" runat="server" meta:resourcekey="lblChild">Child</asp:Label>:</div>
                                                                                    <asp:Label ID="Label10" CssClass="blueByPrice" runat="server" Text='<%#  ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge.ToString().Equals("0")?"":(((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildBaseFareWithCCSurcharge+ ((AirMaterial)DataBinder.Eval(Container,"DataItem")).ChildMarkup).ToString("$#,###") %>'></asp:Label></asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Label ID="lblPerPerson" runat="server" Text="per person" CssClass="perPerson"></asp:Label></span>
                                                                            </td>
                                                                        </tr>
                                                                        </table> </td> </tr> </table>
                                                                        <%--<asp:Panel title="TripDetail" ID="Panel1" runat="server" Style="border-top: 1px dotted #808080;
                                                                            width: 100%; float: left; display: none;">
                                                                            <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 6px;
                                                                                float: left; text-align: left;">
                                                                                <tr>
                                                                                    <td height="13" style="background: #EDF1F4; color: #2B4D87;">
                                                                                        TripID:&nbsp;<asp:Label ID="Label23" runat="server" Text="6001"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%" style="color: #FF6601;
                                                                                            font-weight: bold; text-align: center;">
                                                                                            <tr>
                                                                                                <td width="10%">
                                                                                                    Airline</td>
                                                                                                <td width="20%">
                                                                                                    From</td>
                                                                                                <td width="20%">
                                                                                                    To</td>
                                                                                                <td width="20%">
                                                                                                    Depart</td>
                                                                                                <td width="20%">
                                                                                                    Arrive</td>
                                                                                                <td width="10%">
                                                                                                    Flight</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <asp:DataList ID="dlTrip" runat="server" DataSource='<%# ((AirMaterial) DataBinder.Eval(Container,"DataItem")).AirTrip.SubTrips %>'
                                                                                            Width="100%">
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="5" cellspacing="0" border="0" width="100%" style="background: url(images/bg_time.jpg) bottom repeat-x;
                                                                                                    color: #2B4D87;">
                                                                                                    <tr>
                                                                                                        <td align="center" width="10%">
                                                                                                            <div style="width: 100%;">
                                                                                                                <asp:Image Height="18" ID="AirImgRtn2" runat="server" ImageUrl="~/Page/Flight/images/DL.gif"
                                                                                                                    Width="18"></asp:Image>
                                                                                                            </div>
                                                                                                            Airline</td>
                                                                                                        <td width="20%">
                                                                                                            <asp:Label ID="Label24" runat="server" Text="PVG-Pu Dong Shanghai, China -Excl Hong Kong Sa"></asp:Label></td>
                                                                                                        <td width="20%">
                                                                                                            <asp:Label ID="Label25" runat="server" Text="ATL-West B Hartsfield Atlanta, Georgia, USA"></asp:Label></td>
                                                                                                        <td width="20%">
                                                                                                            <asp:Label ID="Label26" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].ArriveTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label></td>
                                                                                                        <td width="20%">
                                                                                                            <asp:Label ID="Label27" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].ArriveTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label></td>
                                                                                                        <td width="10%">
                                                                                                            <asp:Label ID="Label28" runat="server" Text="#18 0 stop(s)"></asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <div style="width: 100%;">
                                                                                                                <asp:Image Height="18" ID="AirImgRtn3" runat="server" ImageUrl="~/Page/Flight/images/DL.gif"
                                                                                                                    Width="18"></asp:Image>
                                                                                                            </div>
                                                                                                            Airline</td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label29" runat="server" Text="PVG-Pu Dong Shanghai, China -Excl Hong Kong Sa"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label30" runat="server" Text="ATL-West B Hartsfield Atlanta, Georgia, USA"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label31" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].ArriveTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label32" runat="server" Text='<%# "" + Convert.ToDateTime(((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights[((SubAirTrip) DataBinder.Eval(Container, "DataItem")).Flights.Count-1].ArriveTime).ToString("hh:mm tt MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) %>'></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="Label33" runat="server" Text="#18 0 stop(s)"></asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="6" align="right">
                                                                                                            <b>Elapsed Time</b>&nbsp;<asp:Label ID="Label34" runat="server" Text="19hr 15min"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:DataList>
                                                                                        <table cellpadding="5" cellspacing="0" border="0" width="100%">
                                                                                            <tr align="left" style="font-size: 14px; font-weight: bold; color: #2B4D87; background: #F5F8EB;">
                                                                                                <td width="50%">
                                                                                                    Payment Details</td>
                                                                                                <td width="15%">
                                                                                                    Airfare</td>
                                                                                                <td width="15%">
                                                                                                    Tax</td>
                                                                                                <td width="20%">
                                                                                                    Total Price</td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    Total trip price for all passengers:</td>
                                                                                                <td>
                                                                                                    $981.00</td>
                                                                                                <td>
                                                                                                    $247.49</td>
                                                                                                <td style="color: #CC3300; font-size: 20px;">
                                                                                                    $1228.49</td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </asp:Panel>--%>
                                                                    </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <%--<td style="border:1px solid #ccc;">--%>
                                        <td>
                                            <uc4:PageNumber ID="PageNumber2" PageSize="10" UpdateMode="Conditional" runat="server">
                                            </uc4:PageNumber>
                                        </td>
                                    </tr>
                                </table>
                                <%--<div class="loadPage" visible="false"><span class="loadPage_lable" style="">Filter is on : </span><a href="javascript:void(0)" style="color:#5C82E6;">Back to all results display</a> </div>--%>
                                <table id="Table1" border="0" runat="server" visible="false" cellpadding="2" cellspacing="1"
                                    width="100%" class="T_step03">
                                    <tr align="center" class="R_order">
                                        <td height="23" width="30%">
                                            <asp:Label ID="lblFlightInfo" runat="server" meta:resourcekey="lblFlightInfo">Flight Info</asp:Label></td>
                                        <td width="30%">
                                            <asp:Label ID="lblDeparture" runat="server" meta:resourcekey="lblDeparture">Departure</asp:Label></td>
                                        <td width="30%">
                                            <asp:Label ID="lblArrive" runat="server" meta:resourcekey="lblArrive">Arrival</asp:Label></td>
                                        <td width="10%">
                                            <asp:Label ID="lblStops" runat="server" meta:resourcekey="lblStops">Stops</asp:Label></td>
                                    </tr>
                                </table>
                                <table class="T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                                    width="100%">
                                </table>
                                <table id="tableLine" visible="false" runat="server" width="100%" border="0" cellspacing="0"
                                    cellpadding="0">
                                    <tr>
                                        <td height="8">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                    </table>
                    <asp:Panel ID="pnlSelectFare" runat="server" Style="display: none;">
                        <table width="735" border="0" cellpadding="8" cellspacing="1" class="T_step02 left"
                            style="display: none;">
                            <tr class="R_stepo">
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <table id="Airfare" width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                                                <tr class="R_step03" align="center">
                                                                    <td height="40">
                                                                        <asp:Label ID="lblAirline" runat="server" meta:resourcekey="lb_sortAirline">Airline</asp:Label></td>
                                                                    <td width="22%" id="tdDepatureDate">
                                                                        <asp:Label ID="lblDepatureDate" runat="server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label></td>
                                                                    <td width="22%" id="tdArrivalDate">
                                                                        <asp:Label ID="lblArrivalDate" runat="server" meta:resourcekey="lblArrivalDate">Arrival Date</asp:Label></td>
                                                                    <td width="10%" id="tdBookingClass" runat="server">
                                                                        <asp:Label ID="lblClass" runat="server" meta:resourcekey="lblClass">Class</asp:Label></td>
                                                                    <td width="8%">
                                                                        <asp:Label ID="lblAdult" runat="server" meta:resourcekey="lblAdult">Adult</asp:Label><br />
                                                                        <asp:Label ID="lblPriceUSD" runat="server" meta:resourcekey="lblPriceUSD">Price USD</asp:Label></td>
                                                                    <td width="8%">
                                                                        <asp:Label ID="lblChild" runat="server" meta:resourcekey="lblChild">Child</asp:Label><br />
                                                                        <asp:Label ID="lblPriceUS" runat="server" meta:resourcekey="lblPriceUSD">Price USD</asp:Label></td>
                                                                    <%-- <td width="10%">
                                                                    Markup<br />
                                                                     USD</td>--%>
                                                                    <td width="8%">
                                                                        <asp:Label ID="lblTax" runat="server" meta:resourcekey="lblTax">Fuel & Tax</asp:Label></td>
                                                                    <td width="10%">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr class="R_stepw">
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="7">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <asp:Panel ID="pnlPNSelectContact" Visible="true" runat="server">
                                            </asp:Panel>
                                        </tr>
                                        <tr>
                                            <td height="3">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <div id="maskDIV" style="width: 100%; height: 100%; position: absolute; left: 0px;
        top: 0px; display: none; border: 1px solid #ccc; z-index: 1000; background: #fff;
        filter: alpha(opacity=10); -moz-opacity: 0.1;">
    </div>

    <script type="text/javascript">
    function hideselectTab(){
        var tablist1 = document.getElementById("TabFlight").getElementsByTagName("li");

        if(!$("ctl00_MainContent_dlSelectContact")){
          tablist1[1].style.display="none";
        }
    }
    
      
    function test(){
     
        if($("ctl00_MainContent_hfTabFlag").value == "0"){
             displayAvailable();
        }else if($("ctl00_MainContent_hfTabFlag").value == "1"){
            $("sortDIV").style.display = "none";
            displaySelect();
           
        }
        
         if(!$("ctl00_MainContent_dlAvailableFlight")
         && $("ctl00_MainContent_dlSelectContact")){
          displaySelect();
          $("sortDIV").style.display = "none";
        }
    }
    test();
 
 
 function displaySelect()
 {
 var dlList = new Array();
         dlList.push($("dlAvailableFlight1"));
         dlList.push($("dlselectFlight"));
        var tablist = document.getElementById("TabFlight").getElementsByTagName("li");
        
    $("dlAvailableFlight1").style.display = "none";
             $("dlselectFlight").style.display = "block";
             tablist[0].className = "";
             tablist[1].className = "selectedTab";
             $('ctl00_MainContent_pnlComfirm').style.display='none';
             $('ctl00_MainContent_pnlCannotBookMsg_Select').style.display='none';
 }
 
 function displayAvailable()
 {
 var dlList = new Array();
         dlList.push($("dlAvailableFlight1"));
         dlList.push($("dlselectFlight"));
        var tablist = document.getElementById("TabFlight").getElementsByTagName("li");
        
    $("dlAvailableFlight1").style.display = "block";
             $("dlselectFlight").style.display = "none";
             tablist[0].className = "AvailabledTab";
             tablist[1].className = "";
             $('ctl00_MainContent_pnlComfirm').style.display='none';
             $('ctl00_MainContent_pnlCannotBookMsg_Select').style.display='none';
 }
 
 
       function tab_Select(obj){
         var dlList = new Array();
         dlList.push($("dlAvailableFlight1"));
         dlList.push($("dlselectFlight"));
        
        var tablist = document.getElementById("TabFlight").getElementsByTagName("li");
          
            for(var a=0;a<tablist.length;a++){
              tablist[a].className = "";
              dlList[a].style.display = "none";
            
            }
            for(var f=0;f<tablist.length;f++){
            if(obj == tablist[f] ){
              if(f == 0){
                tablist[f].className = "AvailabledTab";
                dlList[f].style.display = "block";
                $("ctl00_MainContent_hfTabFlag").value=f;
                $("ctl00_MainContent_upAvailable").style.display = "block";
                 $("sortDIV").style.display = "block";
              }else{
                tablist[f].className = "selectedTab";
                dlList[f].style.display = "block";
                $("ctl00_MainContent_hfTabFlag").value=f;
                $("ctl00_MainContent_upAvailable").style.display = "none";
                $("sortDIV").style.display = "none";
              }
                
              
            }
          }
        }
      
          hideselectTab();
       
        
       
     
     
       

function select_linktoAchor(){
var tablist1 = document.getElementById("TabFlight").getElementsByTagName("li");
    $("ctl00_MainContent_hfTabFlag").value="1";
    tablist1[1].className="selectedTab";
    $("dlselectFlight").style.display ="block";
    tablist1[0].className="";
    $("dlAvailableFlight1").style.display = "none";
  }



 function link_to_achor(obj){
   var tablist1 = document.getElementById("TabFlight").getElementsByTagName("li");
   hideselectTab();
   tab_Select(tablist1[0]);
   window.location.href = window.location.pathname + "?ConditionID=" + document.getElementById("ctl00_MainContent_OrderId").value + "#divAvailableFlight";
 }
                      
function positionUpdatePanel(event){

     document.getElementById("maskDIV").style.height = document.body.clientHeight + "px";
     document.getElementById("maskDIV").style.width = document.body.clientWidth + "px";
    document.getElementById("maskDIV").style.display = "block";

}

                   
 function sortChangeColor(obj){
   var sort_labels = new Array();

   sort_labels.push(document.getElementById("ctl00_MainContent_lb_sortPrice"));
   sort_labels.push(document.getElementById("ctl00_MainContent_lb_sortAirline"));
   sort_labels.push(document.getElementById("ctl00_MainContent_lb_sortDuration"));
   sort_labels.push(document.getElementById("ctl00_MainContent_lb_sortDeparture"));
   sort_labels.push(document.getElementById("ctl00_MainContent_lb_sortArrival"));
   
     
       for(var a=0;a<sort_labels.length;a++){
         sort_labels[a].style.color = "#3366CC";
       }
       obj.style.color = "#FF3300";
     
  }
                   
    </script>

</asp:Content>
