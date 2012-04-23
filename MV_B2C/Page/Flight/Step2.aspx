<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true" Inherits="Step2" Codebehind="Step2.aspx.cs" %>

<%@ Import Namespace="TERMS.Business.Centers.SalesCenter" %>
<%@ Import Namespace="TERMS.Business.Centers.ProductCenter.Profiles" %>
<%@ Import Namespace="TERMS.Common" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Import Namespace="Terms.Sales.Business" %>
<%@ MasterType VirtualPath="BookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ItineraryInfo -->
    <uc5:ItineraryInfo ID="ItineraryInfo" runat="server"></uc5:ItineraryInfo>

    <script language="javascript" type="text/javascript">
        function DoSelect(obj){
            
            if(document.getElementById("ctl00_MainContent_runFlag").value == "1"){
                return false;
            }    
            obj.style.visibility="hidden";           
            obj.parentElement.className="loading";
            document.getElementById("ctl00_MainContent_runFlag").value = "1";
            
        }
        
//        window.onload = function RemoveNonPubFlightsOfMajorAirline()
//        {
//            var trs = document.getElementById("ctl00_MainContent_dlAirFare").getElementsByTagName("tr"); 
//            var count = 0;
//            for(var trIndex=0;trIndex<trs.length;trIndex++) 
//            {
//                var tds = trs[trIndex].getElementsByTagName("td");
//                
//                for(var tdIndex=0;tdIndex<tds.length;tdIndex++) 
//                {
//                    var spans = tds[tdIndex].getElementsByTagName("span");
//                    
//                    for(var spanIndex=0;spanIndex<spans.length;spanIndex++) 
//                    {                            
//                        if(spans[spanIndex].innerText == "Major US Airlines")
//                        {
//                            //trs[trIndex].style.display="none";
//                            var inputs = trs[trIndex].getElementsByTagName("input")
//                            
////                            if(count < 6)
////                                alert(inputs.length);
//                                
////                            inputs[0].src = "Images/btn_unavailable.gif";
////                            inputs[0].onclick = "";
//                            inputs[0].parentElement.innerHTML = "Call MV";   
//                            
////                            count++
//                        }
//                    }
//                }
//            }  
//        }
        
//         window.onload = function RemoveSR(){
//           var tbl = document.getElementById("ctl00_MainContent_dlAirFare");
//           var spans = tbl.getElementsByTagName("SPAN");
//           var spanLen = spans.length;
//           for(var i = 0; i < spanLen; i++){
//             var strAir = spans[i].innerText;
//             if(strAir == "Major US Airlines" || strAir == "Major International Airlines"){
//               //Major US Airlines
//               var currTr = spans[i].parentElement.parentElement;
//               currTr.cells[4].innerHTML = "Call MV";  
//               currTr.cells[1].innerHTML = "";  
//             }
//           }
//         }
    </script>

    <br />
    <div id="Div1">
        <!-- new -->
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
                                            ></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="5">
                            </td>
                            <td align="left">
                                <span class="head06">Select Fare</span></td>
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
                    <table width="100%" border="0" cellspacing="1" cellpadding="4" class="T_step03">
                        <tr class="R_stepw">
                            <td>
                                <table align="center" border="0" cellpadding="0" cellspacing="0" width="99%">
                                    <tr>
                                        <td align="left">
                                            <img src="Images/btn_select.gif" hspace="2" vspace="5" border="0" align="absmiddle" />
                                            : <span style="color: red">Lower fare might be available</span>, but further search
                                            required to check availability. (If click "Select" button 2 or 3 times and can not find available seats, please click "Contact Agt" to chat or call our agent immediately to save your time) </td>
                                    </tr>
                                     <tr>
                                        <td align="left">
                                            <img src="Images/btn_contactagt.GIF" hspace="2" vspace="5" border="0" align="absmiddle" />
                                            : Please call or chat with our agent.  Manual search is required since you choose foreign airlines and non-gateway departure city/airport.</td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <img src="Images/btn_available.gif" hspace="2" vspace="5" border="0" align="absmiddle" />
                                            : Seats are available now. You can book without further search.</td>
                                    </tr>
                                </table>
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
                                            <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                                            <tr class="R_step03" align="center">
                                                                <td height="40">
                                                                    Airline</td>
                                                                <%--<td width="10%">
                                                                    Class</td>--%>
                                                                <td width="13%">
                                                                    Adult<br />
                                                                    Price USD</td>
                                                                <td width="13%">
                                                                    Child<br />
                                                                    Price US</td>
                                                                <%--<td width="10%">
                                                                    Fare<br />
                                                                     Type</td>--%>
                                                                <td width="12%">
                                                                    Tax</td>
                                                                <td width="10%">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="R_stepw">
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <contenttemplate>
                                                                <asp:HiddenField ID="runFlag" runat="server" Value="0" />
                                                       
                                                           <asp:DataList ID="dlAirFare" runat="server" CellPadding="0" CellSpacing="0" Width="100%" OnItemDataBound="dlAirFare_ItemDataBound"
                                                                        OnItemCommand="dlAirFare_ItemCommand">
                                                                        <ItemTemplate>
                                                                            <table border="0" cellpadding="1" cellspacing="1" width="100%" class="T_step03">
                                                                                <asp:Label ID="Mytr" runat="server"></asp:Label>
                                                                                    <td align="left"><asp:Image height="18" id="AirImgRtn" Runat="server" alt='<%# ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Code %>' width="18" ></asp:Image>
                                                                                        <asp:Label ID="lbl_Airline" runat="server" Text='<%#  ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Name == null ? ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Code : ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).Airlines[0].Name %>'></asp:Label>&nbsp;</td>
                                                                                   <%-- <td width="10%">
                                                                                        <asp:Label ID="Label1" runat="server" Text='<%# ((AirProfile) DataBinder.Eval(Container.DataItem,"Profile")).BookingClasses[0] %>'></asp:Label>&nbsp;</td>--%>
                                                                                    
                                                                                    <td width="13%">
                                                                                        <font class="t07">
                                                                                            <asp:Label ID="lbl_AdultFare" runat="server" Text='<%#  ((AirMerchandise)DataBinder.Eval(Container,"DataItem")).AdultBaseFare.ToString().Equals("0")?"":(((AirMerchandise)DataBinder.Eval(Container,"DataItem")).AdultBaseFare+ ((AirMerchandise)DataBinder.Eval(Container,"DataItem")).AdultMarkup).ToString("$#,###") %>'></asp:Label>&nbsp;</b></font></td>
                                                                                    <td width="13%">
                                                                                        <asp:Label ID="lbl_ChildFare" runat="server" Text='<%#  ((AirMerchandise)DataBinder.Eval(Container,"DataItem")).ChildBaseFare.ToString().Equals("0")?"":(((AirMerchandise)DataBinder.Eval(Container,"DataItem")).ChildBaseFare+ ((AirMerchandise)DataBinder.Eval(Container,"DataItem")).ChildMarkup).ToString("$#,###") %>'></asp:Label>&nbsp;</td>
                                                                                  <%--  <td width="10%">
                                                                                        <asp:Label ID="lbl_FareType" runat="server" Text=""></asp:Label>&nbsp;</td>--%>
                                                                                    <td width="12%">
                                                                                        not included</td>
                                                                                    <td width="10%">
                                                                                        <asp:ImageButton ID="btnSelect" ImageUrl="Images/btn_select.gif" runat="server" OnClientClick="return  DoSelect(this)"
                                                                                            CommandName="Select" />
                                                                                        <asp:ImageButton ID="btnAvail" ImageUrl="Images/btn_available.gif" runat="server"
                                                                                            Visible="false" CommandName="Avail" />
                                                                                        <asp:ImageButton ID="lblNotAvail" ImageUrl="Images/btn_unavailable.gif" runat="server"  OnClientClick="return  false;" Visible="false" Enabled="true"></asp:ImageButton>
                                                                                        <asp:ImageButton ID="btnContactAgt" ImageUrl="Images/btn_contactagt.gif" runat="server"  OnClientClick="return  false;" Visible="false" Enabled="true"></asp:ImageButton>
                                                                                        <ajaxToolkit:HoverMenuExtender ID="HoverMenuExtender1" runat="server" TargetControlID="lblNotAvail"
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
                                                                                    </td>
                                                </tr>
                                            </table>
                                            </ItemTemplate> </asp:DataList> </ContentTemplate> </asp:UpdatePanel>
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
                            <uc4:PageNumber ID="PageNumber1" runat="server"></uc4:PageNumber>
                        </tr>
                        <tr>
                            <td height="3">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </td> </tr> </table>
    </div>
</asp:Content>
