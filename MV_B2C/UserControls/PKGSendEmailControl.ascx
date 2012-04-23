<%@ Control Language="C#" AutoEventWireup="true" Codebehind="PKGSendEmailControl.ascx.cs"
    Inherits="Terms.Web.UserControls.PKGSendEmailControl" %>
<%@ Register Src="CreditCardEmailControl.ascx" TagName="CreditCardEmailControl" TagPrefix="uc11" %>
<%@ Register Src="PKGSelectedFlightControl.ascx" TagName="PKGSelectedFlightControl"
    TagPrefix="uc3" %>
<%@ Register Src="PKGFlightDetailsControl.ascx" TagName="PKGFlightDetailsControl"
    TagPrefix="uc6" %>
<%@ Register Src="PKGTravelerInfoControl.ascx" TagName="PKGTravelerInfoControl" TagPrefix="uc7" %>
<%@ Register Src="PKGContactViewControl.ascx" TagName="PKGContactViewControl" TagPrefix="uc8" %>
<%@ Register Src="PriceInfoControl.ascx" TagName="PriceInfoControl" TagPrefix="uc9" %>
<%@ Register Src="PKGFlightViewControl.ascx" TagName="PKGFlightViewControl" TagPrefix="uc10" %>

<script language="javascript" type="text/javascript">
			function doPrint(){
				document.getElementById("btnPrint").style.visibility="hidden";
				window.print();
				document.getElementById("btnPrint").style.visibility="visible";
			}
</script>

<style type="text/css">
body{ font-family:Verdana, Arial, Helvetica, sans-serif;font-size:11px;}

.IBE_GrayDIV_Right{ width:700px; border:1px solid #999; background:#EAEAEA; padding:8px; float:left; padding-bottom:28px; background-image:url(../../images/v2/bg_s04.gif); background-position:bottom; background-repeat:repeat-x;}
.IBE_GrayDIV_Right_title{color:#000000; font-size: 16px; font-family: Arial; font-weight: bold; margin:3px 0px;}
.IBE_GrayDIV_Right_inSide1{width:682px; border:1px solid #ccc; background:#fff; padding:8px; float:left; padding-bottom:10px; margin-bottom:6px; font-size:11px;}




.IBE_DIV{width:100%; float:left;}
.IBE_head09{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.IBE_package_RoomType_list_th_border{ border-bottom:1px solid #ccc;border-top:1px solid #ccc;}
.td_border_bot{border-bottom: 1px solid rgb(216, 216, 216);}
.step3_t06{ color:#0e6f00; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.IBE_package_tour_day{ color:#FF9600; font-size: 16px; font-family: Arial; font-weight: bold; padding-top:20px;}

.IBE_R_stepw{ background: #FFFFFF;}
.Required_t01{ color:#FF3300; font-size: 10px; font-family: Verdana;}
.IBE_t10{ font-size:10px; font-family:Verdana;}
.IBE_package_remarks{ width:700px; float:left; border:1px solid #999; padding:8px 10px;}
.IBE_package_changeLB{ margin:10px 0px; float:right; margin-right:15px;}
.IBE_package_tourDayT{height:25px; float:left; width:100%; margin-top:10px;}

	/*form style_new*/
	.IBE_T_step03   { background: #CCCCCC; border: 0; font-size:11px;}
	.IBE_R_stepw  { background: #FFFFFF;}
	.IBE_R_order03  { background:#ccc; height: 25; color: #000; font-family: Verdana; font-weight: bold;  }
	.IBE_T_step0l   { background: #FD4C00; border: 0;}
	.IBE_R_step03  { background-image: url(../../images/v2/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
	.IBE_R_order  { background-image: url(../../images/v2/bg_01.gif); height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
	.IBE_R_stepg  { background: #E9E9E9;}
	.IBE_head08{ color:#FF6600; font-weight:bold; font-size:16px; font-family:Arial;}
	.IBE_search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/btn_bg.gif)}
	.IBE_search_btn04 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/btn_bg1.gif)}
	
	
	
table.T_line01   { background: #FF3300; font-size: 16px; line-height: 20px; color: #FFFFFF;  font-family: Arial; font-weight: bold;}	

	
	


.IBE_T_titleFONTstyle{ font-size:11px; font-family:Verdana;}
.font_s15{color:#0E6F00; font-size:15px; font-weight:bold; font-family:Arial;}
.refine {
         border:solid 1px #DA521E;
		 background-color:#fffeea;
		 font-size:11px;
		 }
.refine input {
               border:solid 1px #333;
			   height:16px; 
			   vertical-align:middle; 
			   font-size:12px; 
			   font-family:Arial, Helvetica, sans-serif;
			   }
td.D_stepto  { background: #FFFFFF; font-size: 11px; color: #F85000; font-family: Verdana;}
td.D_steptf  { background: #FFFFFF; font-size: 11px; color: #777777; font-family: Verdana;}
td.D_stepon  { background: #F85000;}
td.D_stepof  { background: #CCCCCC;}
.fB{ font-weight:bold;}
body{ font-family:Verdana, Arial, Helvetica, sans-serif;font-size:11px; margin:0; padding:0;}
ol,li,ul{ margin:0; padding:0; list-style:none;}
.IBE_package_step8_main{ width:700px; margin:0 auto;}
.IBE_step8_step1{width:100%; float:left; line-height:20px; margin-bottom:10px;}
.IBE_step8_step2{width:100%; float:left; }
.IBE_step8_step2_title{ width:100%; float:left;color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold; margin:6px 0px;}
.IBE_step8_step3{ width:100%; float:left; padding:12px 0px; line-height:16px;}
.IBE_step8_t091 {color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.IBE_step8_t101 {color:#3B5998; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.IBE_package_step8_step4{ width:100%; float:left; line-height:20px; margin-top:10px;}
.IBE_package_step8_step5{width:100%; float:left; line-height:20px; text-align:right; margin-top:10px;}
.IBE_package_step8_step6{ width:100%; float:left; margin:10px 0px; text-align:center;}

table.T_step02   { background: #999999; border: 0;}
.T_step03{ background: #CCCCCC; border: 0;}
a.d071 {color: #0000EE; text-decoration: underline; font-family: Verdana;}
td.D_stepr1 {color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold;}
tr.R_order1 {background: #EEEEEE; height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
tr.R_order031 {background: #ff5203; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.R_order03 {background: #00ab18; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.R_stepo1 {background: #F1F2F2;}
tr.R_stepw1 {background: #FFFFFF;}

.step3_price_price{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t061 {color:#000000; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.IBE_step8_ServiceContact_title{ width:100%; float:left;color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold; margin:10px 0px;}


.IBE_package_step8_Service{ width:100%; float:left;}
.IBE_package_step8_Service ul{list-style:circle inside;}
.IBE_package_step8_Service li{ width:100%; float:left; line-height:20px;}
.IBE_package_step8_font_a{ font-size: 12px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}
	/*form style_new*/
	.IBE_T_step03   { background: #CCCCCC; border: 0; font-size:11px;}
	.IBE_R_stepw  { background: #FFFFFF;}
	.IBE_R_order03  { background:#ccc; height: 25; color: #000; font-family: Verdana; font-weight: bold;  }
	.IBE_T_step0l   { background: #FD4C00; border: 0;}
	.IBE_R_step03  { background-image: url(../../images/v2/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
	.IBE_R_order  { background-image: url(../../images/v2/bg_01.gif); height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
	.IBE_R_stepg  { background: #E9E9E9;}
	.IBE_head08{ color:#FF6600; font-weight:bold; font-size:16px; font-family:Arial;}
	.IBE_search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/btn_bg.gif)}
	.IBE_search_btn04 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/btn_bg1.gif)}
.IBE_package_step6_TravelerInformation_title{color: #fff; font-family: Verdana; font-weight: bold; height:25px; line-height:25px; background:#ff5203;}
.IBE_R_stepw{ background: #FFFFFF;}

/* zhangyanlei add 2009-7-22    */
span,td{ font-size:11px; font-family:Verdana;}
</style>
<div class="IBE_package_step8_main">
    <div class="IBE_step8_step1">
        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblDear">Dear</asp:Label>
        <asp:Label ID="lblMember" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblThanks">Thanks for purchasing via Majestic Vacations!</asp:Label>
        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblPlacedOn">Your order was placed on:</asp:Label>
        <asp:Label ID="lblDateNow" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblUSEasternTime">US Eastern Time.</asp:Label>
        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblConfirmation">This is the confirmation e-mail.</asp:Label>
    </div>
    <div class="IBE_step8_step2">
        <div class="IBE_step8_step2_title">
            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblOrderSummary">Your Order Summary</asp:Label></div>
        <div class="IBE_GrayDIV_Right">
            <div class="IBE_GrayDIV_Right_inSide1">
                <span class="IBE_step8_t091">
                    <asp:Label ID="Label7" runat="server" meta:resourcekey="lblOrderNumber">The Order Number</asp:Label>:</span>
                <span class="IBE_step8_t101">
                    <asp:Label ID="lblCaseNumber" runat="server"></asp:Label></span><br />
                <span class="IBE_step8_t091">
                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblRecordLocator">Airline Record Locator</asp:Label>:</span>
                <span class="IBE_step8_t101">
                    <asp:Label ID="lblRcordLocator" runat="server"></asp:Label></span>
            </div>
        </div>
        <div class="IBE_step8_step3">
            <font class="IBE_package_SearchCondition_f06">
                <asp:Label ID="lblDeparture" runat="server">Los Angeles, CA (LAX)</asp:Label></font>
            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblTo">to</asp:Label>
            <font class="IBE_package_SearchCondition_f06">
                <asp:Label ID="lblTo" runat="server">Taipei, Taiwan (TPE)</asp:Label></font><br />
            <asp:Label ID="lblRoomAndPassengers" runat="server">4 room(s), 2 Adault(s), 0 Child(ren)</asp:Label></div>
        <table class="T_step03" width="100%" align="center" border="0" cellpadding="0" cellspacing="1">
            <tbody>
                <tr class="R_stepw1">
                    <td align="center" style="height: 46px">
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr class="R_order031" align="center">
                                    <td colspan="7" align="center" height="23">
                                        <b>
                                            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblFlightInformation">Flight Information</asp:Label></b></td>
                                </tr>
                            </tbody>
                        </table>
                        <uc10:PKGFlightViewControl ID="PKGFlightViewControl1" runat="server"></uc10:PKGFlightViewControl>
                    </td>
                </tr>
            </tbody>
        </table>
        <table class="T_step03" width="100%" align="center" border="0" cellpadding="0" cellspacing="1">
            <tbody>
                <tr class="R_stepw1">
                    <td align="center" style="height: 46px">
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr align="center" class="R_order031">
                                    <td colspan="7" align="center" height="23">
                                        <b>
                                            <asp:Label ID="lblHotelInformation" runat="Server" meta:resourcekey="lblHotelInformation">Hotel Information</asp:Label></b></td>
                                </tr>
                            </tbody>
                        </table>
                        <asp:DataList ID="ddlHotel" runat="server" Width="100%">
                            <ItemTemplate>
                                <table border="0" cellpadding="2" cellspacing="1" width="100%" class="IBE_T_step03">
                                    <tr align="center" class="IBE_R_stepw">
                                        <td height="23" align="left" colspan="4">
                                            <asp:Label ID="lblHotelin" runat="Server" meta:resourcekey="lblHotelin">Hotel in</asp:Label>
                                            <asp:Label ID="lbcity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.City.Name") %>'></asp:Label>
                                            <asp:Label ID="lblHotelin1" runat="Server" meta:resourcekey="lblHotelin1"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="IBE_R_stepw">
                                        <td width="2%">
                                            #<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1%>'>
                                            </asp:Label></td>
                                        <td width="48%" align="left">
                                            <asp:Label ID="lbHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.Name") %>'></asp:Label>$GTANUMBER</td>
                                        <td width="25%" align="left">
                                            <asp:Label ID="lblCheckIn" runat="Server" meta:resourcekey="lblCheckIn">Check In</asp:Label><asp:Label
                                                ID="lbCheckInDate" runat="server" Text='<%# ": " + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy")%>'></asp:Label><br />
                                            <asp:Label ID="lblCheckOut" runat="Server" meta:resourcekey="lblCheckOut">Check Out</asp:Label><asp:Label
                                                ID="lbCheckOutDate" runat="server" Text='<%# ":" + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy")%>'></asp:Label>
                                        </td>
                                        <td width="25%" align="left">
                                            <asp:Repeater ID="rptRoom" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "RoomTypes") %>'>
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label><asp:Label
                                                                    ID="lbHotelDetails" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Room.Name")  %>'>
                                                                </asp:Label><br />
                                                                <asp:Label ID="lbNights" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOut")).Subtract((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).Days %>'></asp:Label>
                                                                <asp:Label ID="lblNights" runat="Server" meta:resourcekey="lblNights">Nights</asp:Label><br />
                                                                <asp:Label ID="lblBreakfastName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "BreakfastName") != "" ? "Included " + DataBinder.Eval(Container.DataItem, "BreakfastName").ToString() + " Breakfast" : "Not included breakfast" %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>
            </tbody>
        </table>
        <table class="T_step02" width="100%" align="center" border="0" cellpadding="0" cellspacing="1"
            style="margin-top: 10px;">
            <tbody>
                <tr class="R_stepw1">
                    <td align="center">
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr class="R_order031" align="center">
                                    <td colspan="7" align="center" height="23">
                                        <b>
                                            <asp:Label ID="Label11" runat="server" meta:resourcekey="lblTravelerInformation">Traveler Information</asp:Label></b></td>
                            </tbody>
                        </table>
                        <uc7:PKGTravelerInfoControl ID="PKGTravelerInfoControl1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
        <table class="T_step02" width="100%" align="center" border="0" cellpadding="0" cellspacing="1"
            style="margin-top: 10px;">
            <tbody>
                <tr class="R_stepw1">
                    <td align="center">
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr class="R_order031" align="center">
                                    <td colspan="7" align="center" height="23">
                                        <b>
                                            <asp:Label ID="Label12" runat="server" meta:resourcekey="lblContactInformation">Contact Information</asp:Label></b></td>
                                </tr>
                            </tbody>
                        </table>
                        <uc8:PKGContactViewControl ID="PKGContactViewControl1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0" style="margin-top: 10px;">
            <tbody>
                <tr>
                    <td align="center">
                        <uc11:CreditCardEmailControl ID="CreditCardEmailControl1" runat="server" />
                    </td>
                </tr>
            </tbody>
        </table>
        <div style="width: 700px; border: 1px solid #ccc; padding: 8px; margin-top: 10px;
            float: left;">
            <uc9:PriceInfoControl ID="PriceInfoControl1" runat="server" />
        </div>
        <div class="IBE_step8_ServiceContact_title">
            Your Order Summary</div>
        <div class="IBE_package_remarks">
            <div class="IBE_package_step8_Service">
                <ul>
                    <li>&#8226; &nbsp;<asp:Label ID="Label13" runat="server" meta:resourcekey="lblCustomer">Customer Service Staff</asp:Label>:
                        <asp:Label runat="server" ID="lblSalesName"></asp:Label>
                    </li>
                    <li>&#8226; &nbsp;<asp:Label ID="Label14" runat="server" meta:resourcekey="lblPhone">Phone</asp:Label>:
                        1-(888)-288-7528</li>
                    <li>&#8226; &nbsp;<asp:Label ID="Label15" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:<asp:Label
                        runat="server" ID="lblSalesEmail"></asp:Label>
                    </li>
                </ul>
            </div>
        </div>
        <div class="IBE_package_step8_step4">
            <asp:Label ID="Label16" runat="server" meta:resourcekey="lblMsg">Thanks again for your purchase. We're looking forward to going places with you!<br>
            Always visit</asp:Label>
            <a href="http://www.majestic-vacations.com">www.majestic-vacations.com</a>
            <asp:Label ID="Label18" runat="server" meta:resourcekey="lblTravelDeals">for the greatest travel deals!</asp:Label></div>
        <div class="IBE_package_step8_step5">
            <asp:Label ID="Label19" runat="server" meta:resourcekey="lblEnjoyTrip">Enjoy your trip</asp:Label>,
            <br />
            <asp:Label ID="Label20" runat="server" meta:resourcekey="lblTeam">The Majestic Vacations Team</asp:Label></div>
    </div>
</div>
