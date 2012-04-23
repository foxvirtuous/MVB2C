<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="SendEmailViewControl" Codebehind="SendEmailViewControl.ascx.cs" %>
<%@ Register Src="PriceInfoControl.ascx" TagName="PriceInfoControl" TagPrefix="uc9" %>
<%@ Register Src="FlightHeaderControl.ascx" TagName="FlightHeaderControl" TagPrefix="uc6" %>
<%@ Register Src="TravelerInfoControl.ascx" TagName="TravelerInfoControl" TagPrefix="uc7" %>
<%@ Register Src="ContactViewControl.ascx" TagName="ContactViewControl" TagPrefix="uc8" %>
<%@ Register Src="FlightDetailsControl.ascx" TagName="FlightDetailsControl" TagPrefix="uc3" %>
<%@ Register Src="CreditCardEmailControl.ascx" TagName="CreditCardEmailControl" TagPrefix="uc10" %>
<script language="javascript" type="text/javascript">
			function doPrint(){
				document.getElementById("btnPrint").style.visibility="hidden";
				window.print();
				document.getElementById("btnPrint").style.visibility="visible";
			}
    </script>
 <style type="text/css">
body{margin:0 auto;padding:0; text-align:center;}



.font_blackB{float:left;font-size:11px; font-family:Verdana, Arial, Helvetica, sans-serif;color:#000000; 
font-weight:bold; margin:0 6px 0 0}



.line1{position:relative; top:30%; margin:0 2px}


table.T_search   { background: #FE7900; border: 0;}
table.T_sale   { background: #CCCCCC; border: 0;}
table.T_rec   { background: #FFFECC; border: 0;}

table.T_sale01   { font-size: 10px; line-height: 12px; color: #000000; font-family: Verdana;}
table.T_table   { font-size: 11px; line-height: 19px; color: #000000; font-family: Verdana;}


table.T_order  { background: #8E8C88; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana; 
height: 20;}

table.T_line01   { background: #FF3300; font-size: 16px; line-height: 20px; color: #FFFFFF;  font-family: Arial; 
font-weight: bold;}
table.T_line02   { background: #CC0000; border: 0;}
table.T_line03   { background: #CC0000; font-size: 11px; line-height: 13px; color: #FFFFFF;  font-family: Arial; 
font-weight: bold;}

table.T_step0l   { background: #FD4C00; border: 0;}
table.T_step02   { background: #999999; border: 0;}
table.T_step03   { background: #CCCCCC; border: 0;}

tr.R_step01  { background-image: url(../images/v2/bg_s01.gif); font-size: 10px; line-height: 12px; color: #FFFFFF; 
font-family: Verdana; font-weight: bold;}
tr.R_step02  { background: #EAEAEA;}
tr.R_step03  { background-image: url(../images/v2/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; 
font-family: Verdana; font-weight: bold;}
tr.R_step04  { background-image: url(../images/v2/bg_s04.gif);}
tr.R_stepbox  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}
td.D_stepto  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #F85000; font-family: Verdana;}
td.D_steptf  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #777777; font-family: Verdana;}
td.D_stepon  { background: #F85000;}
td.D_stepof  { background: #CCCCCC;}
tr.R_stepw  { background: #FFFFFF;}
tr.R_stepg  { background: #E9E9E9;}
tr.R_stepo  { background: #FDF1C1;}
td.D_stepb  { color: #FF6600; font-family: Verdana; font-weight: bold;}
td.D_stepr  { color:#000000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
td.D_stepg  { color:#000000; font-size: 9px; line-height: 18px; font-family: Verdana;}
td.D_stepl  { background: #CCCCCC;}

tr.R_search  { background-image: url(../images/v2/en_mid.gif); font-size: 9px; line-height: 12px; color: #000000; 
font-family: Verdana; height: 20;}
tr.R_order  { background-image: url(../images/v2/bg_01.gif); height: 25; color: #000000; font-family: Verdana; 
font-weight: bold;}
tr.R_order03  { background:#ff5203; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.R_order01  { background-color: #FFFFFF; height: 25;}
tr.R_order02  { background-color: #E9E9E9; height: 25;}
tr.R_top  { font-size: 9px; line-height: 14px; color: #CC0000; font-family: Verdana;}
td.D_order  { background-image: url(../images/v2/bg_01.gif); height: 25; color: #000000; font-family: Verdana; 
font-weight: bold;}

td.D_search_on  { background-image: url(../images/v2/en_on_m.gif); height: 26;  font-size: 12px; line-height: 
26px; color: #FF3300; font-family: Verdana; font-weight: bold;}
td.D_search_off  { background-image: url(../images/v2/en_off_m.gif); height: 26;  font-size: 12px; line-height: 
26px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
td.D_search_top  { background-image: url(../images/v2/en_top.gif); height: 26;}
td.D_title  { background-image: url(../images/v2/title.gif); height: 45;  font-size: 18px; line-height: 36px; 
color: #FFFFFF; font-family: Verdana; font-weight: bold;}

td.D_title1  { background-image: url(../images/v2/title01.gif); height: 45;  font-size: 18px; line-height: 36px; 
color: #FFFFFF; font-family: Verdana; font-weight: bold;}

td.D_head  { background-color: #FF3600; height: 124; color:#FFFFFF; font-size: 26px; line-height: 51px; 
font-family: arial; font-weight: bold;}
td.D_head1  { height: 124; color:#FFFFFF; font-size: 26px; line-height: 51px; font-family: arial; font-weight: 
bold;}


a.search_off { color: #FFFFFF; text-decoration: none;}
a.search_off:hover { color: #FFFF00; text-decoration: none;}
.search_btn   { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; 
height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:10px 0 10px 0; border-color: 
#FD9845; background-image: url(../images/v2/btn_bg.gif)}
.search_btn01 { font-size: 11px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; 
height: 16px; width:80px; background-color: white; padding: 0 0 2px 0; margin:5px 0 5px 0; border-color: #FD9845; 
background-image: url(../images/v2/btn_bg.gif)}
.search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; 
height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; 
background-image: url(../images/v2/btn_bg.gif)}
.search_btn03 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; 
height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; 
background-image: url(../images/v2/btn_bg1.gif)}
.search_btn04 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; 
height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; 
background-image: url(../images/v2/btn_bg1.gif)}
.search_btn05 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; 
height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; 
background-image: url(../images/v2/btn_bg.gif)}

.search_inp {	font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; 
width:100px; color: #000000; margin:2px 0 0 0;}
.search_inp1 {	font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; 
width:15px; color: #000000; margin:2px 0 0 0;}
.search_inp2 {	font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; 
width:200px; color: #000000; margin:2px 0 0 0;}
.search_sle { font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; 
width:120px; color: #000000; margin:2px 0 0 0;}
.search_sle1 { font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; color: 
#000000; margin:3px 0 0 0;}
.search_sle2 { font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; 
width:80px; color: #000000; margin:3px 0 0 0;}
.search_sle3 { font-size: 10px; font-family: Verdana; width:500px; color: #000000; margin:3px 0 0 0;}

.search_b {  font-weight: bold; color: #FF3300;}
input, option, select, textarea       { font-size: 10px; font-family: Verdana; color: #000000; margin:3px 0 0 0;}
.txt01{ color:#CC0000; font-size: 10px; line-height: 14px; font-family: Verdana; font-weight: bold;}
.t01{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;}
.t02{ color:#FF3300; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t03{ color:#FFFFFF; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t04{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}
.t05{ color:#CC0000; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t06{ color:#005599; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t07{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana; font-weight: bold;}
.t08{ color:#666666; font-size: 9px; line-height: 16px; font-family: Verdana;}
.t09  { color:#000000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t10  { color:#005599; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t11  { color:#FF3300; font-size: 15px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t12{ color:#FF3300; font-size: 10px; line-height: 18px; font-family: Verdana; font-weight: bold;}

.call{ color:#FF6600; font-size: 20px; line-height: 24px; font-family: Verdana; font-weight: bold;}
a.d01 {  font-size: 10px; line-height: 14px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d01:hover {  font-size: 10px; line-height: 14px; color: #FF3300; text-decoration: none; font-family: Verdana;}
a.d02 {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: none; font-family: Verdana; 
font-weight: bold;}
a.d02:hover {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: underline; font-family: 
Verdana; font-weight: bold;}
a.d03 {  font-size: 10px; line-height: 20px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d03:hover {  font-size: 10px; line-height: 20px; color: #FF3300; text-decoration: none; font-family: Verdana;}
a.d04 {  font-size: 10px; line-height: 14px; color: #005599; text-decoration: none; font-family: Verdana; 
font-weight: bold;}
a.d04:hover {  font-size: 10px; line-height: 14px; color: #005599; text-decoration: underline; font-family: 
Verdana; font-weight: bold;}
a.d05 {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: underline; font-family: Verdana; 
font-weight: bold;}
a.d05:hover {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: none; font-family: Verdana; 
font-weight: bold;}
a.d06 {  font-size: 10px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana; 
font-weight: bold;}
a.d06:hover {  font-size: 10px; line-height: 18px; color: #FF3300; text-decoration: none; font-family: Verdana; 
font-weight: bold;}
a.d07 {  font-size: 10px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}
a.d07:hover {  font-size: 10px; line-height: 18px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d08 {  font-size: 10px; line-height: 16px; color: #FF3300; text-decoration: none; font-family: Verdana;}
a.d08:hover {  font-size: 10px; line-height: 16px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d09 {  font-size: 9px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}
a.d09:hover {  font-size: 9px; line-height: 18px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d10 {  font-size: 10px; line-height: 16px; color: #000000; text-decoration: none; font-family: Verdana;}
a.d10:hover {  font-size: 10px; line-height: 16px; color: #FF3300; text-decoration: none; font-family: Verdana;}

a.d11 {  font-size: 15px; line-height: 19px; color: #005599; text-decoration: none; font-family: Verdana; 
font-weight: bold;}
a.d11:hover {  font-size: 15px; line-height: 19px; color: #FF6600; text-decoration: none; font-family: Verdana; 
font-weight: bold;}

a.d12 {  font-size: 10px; line-height: 18px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d12:hover {  font-size: 10px; line-height: 18px; color: #FF6600; text-decoration: none; font-family: Verdana;}


tr.R_pop   { font-size: 10px; line-height: 14px; color: #CCCCCC; font-family: Verdana;}
tr.R_cost   { font-size: 10px; line-height: 14px; color: #000000; font-family: Verdana;}
.step{margin:5px 0 0 0; padding:3px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size:10px; 
color:#777; height:16px;}
.step ul{margin:0;padding:0;list-style:none;float:right; }
.step ul li{float:left; display:block; border-top:solid 3px #ccc; padding:0 4px 0 4px; margin:0 0 0 2px;}
.step .stepon{border-top:solid 3px #f85000; color:#f85000;}

/*  add  */
.loading
{
background-image:url(../Images/v2/loading.gif);
background-repeat:no-repeat;
}
.changeitem{background:#E1F0FF;}

/* ------------tour-------------- */
.tour_price  { color:#000000; font-size: 12px; line-height: 22px; font-family: Arial; font-weight: bold;}
.tour_bold  { color:#000000; font-size: 11px; line-height: 19px; font-family: Verdana; font-weight: bold;}
.tour_bolds  { font-size: 9px; line-height: 13px; font-family: Verdana; font-weight: bold;}
.tour_day  { color:#FF9600; font-size: 16px; line-height: 22px; font-family: Arial; font-weight: bold;}
.tour_red  { color:#FF3300;}

table.tour   { font-size: 11px; line-height: 19px; color: #000000; font-family: Verdana;}
table.tour_note   { font-size: 9px; line-height: 15px; color: #444444; font-family: Verdana;}
table.price   { font-size: 9px; line-height: 13px; color: #000000; font-family: Verdana;}
tr.tour_top  { background-image: url(../images/v2/tour_top_bg.gif); height: 32;}
tr.tour_mid  { background-image: url(../images/v2/tour_mid_bg.gif);}
td.tour_on  { background-image: url(../images/v2/tour_top_on.gif); height: 32; color:#FF6600; font-size: 14px; 
font-family: Arial; font-weight: bold; padding:0 20px 0 20px;}
td.tour_off  { background-image: url(../images/v2/tour_top_off.gif);  height: 32; color:#000000; font-size: 14px; 
font-family: Arial; font-weight: bold; padding:0 20px 0 20px;}
td.tour_name01  { color:#FF6600; font-size: 22px; line-height: 22px; font-family: Arial; font-weight: bold;}
td.tour_name02  { color:#767676; font-size: 14px; line-height: 18px; font-family: Arial; font-weight: bold;}
td.tour_name03  { color:#000000; font-size: 14px; line-height: 18px; font-family: Arial; font-weight: bold;}
td.tour_show01  { color:#FF6600; font-size: 25px; line-height: 25px; font-family: Arial; font-weight: bold;}
td.tour_show03  { color:#000000; font-size: 16px; line-height: 22px; font-family: Arial; font-weight: bold;}
a.tour_link01 {  font-size: 22px; line-height: 22px; color: #FF6600; text-decoration: none; font-family: Arial; 
font-weight: bold;}
a.tour_link01:hover {  font-size: 22px; line-height: 22px; color: #FF6600; text-decoration: none; font-family: 
Arial; font-weight: bold;}
a.cruise_link01 {  font-size: 20px; line-height: 20px; color: #FF6600; text-decoration: none; font-family: Arial; 
font-weight: bold;}
a.cruise_link01:hover {  font-size: 20px; line-height: 20px; color: #FF6600; text-decoration: none; font-family: 
Arial; font-weight: bold;}
a.tour_link02 {  color: #000000; text-decoration: none;}
a.tour_link02:hover {  color: #FF6600; text-decoration: none;}
a.tour_link03 {  color: #005599; text-decoration: underline;}
a.tour_link03:hover {  color: #005599; text-decoration: none;}
.tour_link0411 a, .tour_link0411 a:link{color:#fff;}

.tour_price  { color:#000000; font-size: 12px; line-height: 22px; font-family: Arial; font-weight: bold;}
.tour_bold  { color:#000000; font-size: 11px; line-height: 19px; font-family: Verdana; font-weight: bold;}
.tour_bolds  { font-size: 9px; line-height: 13px; font-family: Verdana; font-weight: bold;}
.tour_day  { color:#FF9600; font-size: 16px; line-height: 22px; font-family: Arial; font-weight: bold;}
.tour_red  { color:#FF3300;}

.modalBackground
{
	background-color: Gray;
	filter: alpha(opacity=70);
	opacity: 0.7;
}

.validatorCalloutHighlight
{
    background-color: lemonchiffon;
}

.Watermark
{ 
	background-color:Gray; 
	color:#666666; 
} 


	
	/*form style_new*/
	.IBE_T_step03   { background: #CCCCCC; border: 0; font-size:11px;}
	.IBE_R_stepw  { background: #FFFFFF;}
	.IBE_R_order03  { background:#ccc; height: 25; color: #000; font-family: Verdana; font-weight: bold;  }
	.IBE_T_step0l   { background: #FD4C00; border: 0;}
	.IBE_R_step03  { background-image: url(../../images/v2/bg_s03.gif); font-size: 11px; line-height: 13px; 
color: #FFFFFF; font-family: Verdana; font-weight: bold;}
	.IBE_R_order  { background-image: url(../../images/v2/bg_01.gif); height: 25; color: #000000; font-family: 
Verdana; font-weight: bold;}
	.IBE_R_stepg  { background: #E9E9E9;}
	.IBE_head08{ color:#FF6600; font-weight:bold; font-size:16px; font-family:Arial;}
	.IBE_search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px 
solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: 
#FD9845; background-image: url(../../images/v2/btn_bg.gif)}
	.IBE_search_btn04 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px 
solid; height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: 
#FD9845; background-image: url(../../images/v2/btn_bg1.gif)}
.IBE_package_step6_TravelerInformation_title{color: #fff; font-family: Verdana; font-weight: bold; height:25px; line-height:25px; background:#ff5203;}
.IBE_R_stepw{ background: #FFFFFF;}

span,td{ font-size:11px; font-family:Verdana;}
</style>
<table width="700" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size: 14px; line-height: 19px; color: #000000; font-family: Verdana;">
    <tr>
        <td align="right" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblDear" runat="server" meta:resourcekey="lblDear">Dear</asp:Label>&nbsp;<asp:Label ID="lbName" runat="server"></asp:Label>,<br />
                         <asp:Label ID="lblThanksVia" runat="server" meta:resourcekey="lblThanksVia">Thanks for purchasing via Majestic Vacations</asp:Label>! 
                         <asp:Label ID="lblYourOn" runat="server" meta:resourcekey="lblYourOn">Your order was placed on</asp:Label>:
                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblUSEastenTime">US Eastern Time</asp:Label>. 
                        <asp:Label ID="lblConfirmationEmail" runat="server" meta:resourcekey="lblConfirmationEmail">This is the confirmation e-mail</asp:Label>.</td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #999999; border: 0;">
                <tr style=" background: #EAEAEA;">
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr align="left">
                                                        <td height="25" valign="top" style="color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;">
                                                            <asp:Label ID="lblOrderSummary" runat="server" meta:resourcekey="lblOrderSummary">Your Order Summary</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="1" cellpadding="8" style="background-image: url(../../images/v2/bg_s03.gif); font-size: 11px; line-height: 13px; color: #000000; font-family: Verdana; font-weight: bold;">
                                                                <tr  style="background: #FFFFFF;">
                                                                    <td height="120">
                                                                        <table width="100%" border="0" cellpadding="8" cellspacing="1" style="background: #999999; border: 0;">
                                                                            <tr  style="background: #FDF1C1;">
                                                                                <td valign="top">
                                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="7">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" style="background: #CCCCCC; border: 0;">
                                                                                                    <tr style="background: #FFFFFF;">
                                                                                                        <td align="left">
                                                                                                            <font class="t09"><asp:Label ID="lblOrderNumber" runat="server" meta:resourcekey="lblOrderNumber">The Order Number</asp:Label>:</font> <font class="t10">
                                                                                                                <asp:Label ID="lblCaseNumber" runat="server" Text=""></asp:Label></font><br />
                                                                                                            <font class="t09"><asp:Label ID="lblConfirmation" runat="server" meta:resourcekey="lblConfirmation">Record Locator</asp:Label>:</font> <font class="t10">
                                                                                                                <asp:Label ID="lblRcordLocator" runat="server"></asp:Label></font></td>
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
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td height="10">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr valign="top">
                                                                                <td>
                                                                                    <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr align="left" valign="top">
                                                                                            <td>
                                                                                                &nbsp;
                                                                                                <uc6:FlightHeaderControl ID="FlightHeaderControl1" runat="server" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <uc3:FlightDetailsControl ID="FlightDetailsControl2" runat="server" />
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <uc7:TravelerInfoControl ID="TravelerInfoControl1" runat="server" />
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <uc8:ContactViewControl ID="ContactViewControl1" runat="server" />
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <uc10:CreditCardEmailControl ID="uclCreditCardEmailControl" runat="server" />
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <uc9:PriceInfoControl ID="PriceInfoControl1" runat="server" />
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="10">
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
                                                </table>
                                            </td>
                                        </tr>
                                        <tr style="background-image: url(../../images/v2/bg_s04.gif);">
                                            <td height="20">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                2</td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="5">
                                </td>
                                <td align="left">
                                    <span class="head06"><asp:Label ID="lblServiceContact" runat="server" meta:resourcekey="lblServiceContact">Service Contact</asp:Label></span></td>
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
                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step02">
                            <tr class="R_stepw">
                                <td align="left">
                                    &#8226; &nbsp;<asp:Label ID="lblStaff" runat="server" meta:resourcekey="lblStaff">Customer Service Staff</asp:Label>: 
                                    <asp:Label ID="lblSalesName" runat="server" Text=""></asp:Label><br />
                                    &#8226; &nbsp;<asp:Label ID="lblPhone" runat="server" meta:resourcekey="lblPhone">Phone</asp:Label>: 1-(888)-288-7528<br>
                                    &#8226; &nbsp;<asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>: 
                                    <asp:Label ID="lblSalesEmail" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <%--<table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnPrint" runat="server" CssClass="search_btn05" Text="Print out this page" />
                    </td>
                </tr>
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>--%>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td height="50" align="left" valign="top">
                        <asp:Label ID="lblThankVisit" runat="server" meta:resourcekey="lblThankVisit">Thanks again for your purchase. We're looking forward to going places with you!<br>Always visit</asp:Label>
                         <a href="http://www.majestic-vacations.com/" class="d07">www.majestic-vacations.com</a>
                        <asp:Label ID="lblForDeals" runat="server" meta:resourcekey="lblForDeals">for the greatest travel deals</asp:Label>!</td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblEnjoyYourTrip">Enjoy your trip</asp:Label>,
                        <br>
                        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblTeam">The Majestic Vacations Team</asp:Label></td>
                </tr>
                <tr>
                    <td align="center">
                        </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
