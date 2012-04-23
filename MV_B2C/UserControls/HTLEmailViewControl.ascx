<%@ Control Language="C#" AutoEventWireup="true" Codebehind="HTLEmailViewControl.ascx.cs"
    Inherits="HTLEmailViewControl" %>
<%@ Register Src="ViewTransportationControl.ascx" TagName="ViewTransportationControl"
    TagPrefix="uc3" %>
<%@ Register Src="HTLTotalPriceControl.ascx" TagName="HTLTotalPriceControl" TagPrefix="uc3" %>
<%@ Register Src="TravelerInfoControl.ascx" TagName="TravelerInfoControl" TagPrefix="uc7" %>
<%@ Register Src="ContactViewControl.ascx" TagName="ContactViewControl" TagPrefix="uc8" %>
<%@ Register Src="CreditCardEmailControl.ascx" TagName="CreditCardEmailControl" TagPrefix="uc10" %>

<script language="javascript" type="text/javascript">
			function doPrint(){
				document.getElementById("btnPrint").style.visibility="hidden";
				window.print();
				document.getElementById("btnPrint").style.visibility="visible";
			}
</script>

<style type="text/css">
/* CSS Document */
body{margin:0 auto;padding:0; text-align:center;}
span,td{ font-size:11px; font-family:Verdana;}
/* -----------Header Style-------------- */
table.T_search   { background: #FE7900; border: 0;}
table.T_sale   { background: #CCCCCC; border: 0;}
table.T_rec   { background: #FFFECC; border: 0;}

table.T_sale01   { font-size: 10px; line-height: 12px; color: #000000; font-family: Verdana;}
table.T_table   { font-size: 11px; line-height: 19px; color: #000000; font-family: Verdana;}


table.T_order  { background: #8E8C88; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana; height: 20;}

table.T_line01   { background: #FF3300; font-size: 16px; line-height: 20px; color: #FFFFFF;  font-family: Arial; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
table.T_line02   { background: #CC0000; border: 0;}
table.T_line03   { background: #CC0000; font-size: 11px; line-height: 13px; color: #FFFFFF;  font-family: Arial; font-weight: bold;}

table.T_step0l   { background: #139B00; border: 0; !important} /* ------------퀰hange Color-------------- */
table.T_step02   { background: #999999; border: 0;}
table.T_step03   { background: #CCCCCC; border: 0;}

tr.R_step01  { background-image: url(../../images/001/bg_s01.gif); font-size: 10px; line-height: 12px; color: #FFFFFF; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
tr.R_step02  { background: #EAEAEA;}
tr.R_step03  { background-image: url(../../images/001/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
tr.R_step04  { background-image: url(../../images/001/bg_s04.gif);}
tr.R_stepbox  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}
td.D_stepto  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #F85000; font-family: Verdana; !important}  /* ------------퀰hange Color-------------- */
td.D_steptf  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #777777; font-family: Verdana;}
td.D_stepon  { background: #F85000; !important} /* ------------퀰hange Color-------------- */
td.D_stepof  { background: #CCCCCC;}
tr.R_stepw  { background: #FFFFFF;}
tr.R_stepg  { background: #E9E9E9;}
tr.R_stepo  { background: #EDF6F1; !important} /* ------------퀰hange Color-------------- */
td.D_stepb  { color: #0E6F00; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
td.D_stepr  { color:#000000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
td.D_stepg  {
	color:#000000;
	font-size: 9px;
	line-height: 18px;
	font-family: Verdana;
	padding: 5px 15px 5px 0px;
}
td.D_stepl  { background: #CCCCCC;}

tr.R_search  { font-size: 10px; line-height: 12px; color: #000000; font-family: Verdana; height: 20;}
tr.R_order  { background-image: url(../../images/001/bg_01.gif); height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
tr.R_order03  { background-image: url(../../images/001/bg_02.gif); height: 25; color: #FFFFFF;  background-color:#cccccc; font-family: Verdana; font-weight: bold; background:#ff6600;}
tr.R_order01  { background-color: #FFFFFF; height: 25;}
tr.R_order02  { background-color: #E9E9E9; height: 25;}
tr.R_top  { font-size: 9px; line-height: 14px; color: #CC0000; font-family: Verdana;}
td.D_order  { background-image: url(../../images/001/bg_01.gif); height: 25; color: #000000; font-family: Verdana; font-weight: bold;}

td.D_search_on  { background-image: url(../../images/001/en_on_m.gif); height: 28;  font-size: 12px; line-height: 26px; color: #0E6F00; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
td.D_search_off  { background-image: url(../../images/001/en_off_m.gif); height: 28;  font-size: 12px; line-height: 26px; color: #FFFFFF; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
td.D_search_top  { background-image: url(../../images/001/en_top.gif); height: 28; !important}
td.D_title  { height: 45;  font-size: 18px; line-height: 36px; color: #0E6F00; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
td.D_head  { background-color: #FF3600; height: 124; color:#FFFFFF; font-size: 26px; line-height: 51px; font-family: arial; font-weight: bold;}
td.D_head1  { height: 124; color:#FFFFFF; font-size: 26px; line-height: 51px; font-family: arial; font-weight: bold;}

a.search_off { color: #FFFFFF; text-decoration: none;}
a.search_off:hover { color: #FFFF00; text-decoration: none;}
a.search_on { color: #0E6F00; text-decoration: none;}
a.search_on:hover { color: #0E6F00; text-decoration: none;}

.search_btn { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:10px 0 0px 0; border-color: #FD9845; background-image: url(../../images/001/btn_bg.gif); !important}
.search_btn01 { font-size: 11px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 16px; width:80px; background-color: white; padding: 0 0 2px 0; margin:5px 0 5px 0; border-color: #FD9845; background-image: url(../../images/001/btn_bg.gif)}
.search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/001/btn_bg.gif)}
.search_btn03 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/001/btn_bg1.gif)}
.search_btn04 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/001/btn_bg1.gif)}
.search_btn05 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/001/btn_bg.gif)}

.search_inp {	font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #999999; width:100px; color: #000000; margin:2px 0 0 0; !important} /* ------------퀰hange Color-------------- */
.search_inp1 {	font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #999999; width:15px; color: #000000; margin:2px 0 0 0;}
.search_inp2 {	font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #999999; width:200px; color: #000000; margin:2px 0 0 0;}
.search_sle { font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #999999; width:120px; color: #000000; margin:2px 0 0 0; !important} /* ------------퀰hange Color-------------- */
.search_sle1 { font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #999999; color: #000000; margin:3px 0 0 0; !important} /* ------------퀰hange Color-------------- */
.search_sle2 { font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #999999; width:80px; color: #000000; margin:3px 0 0 0;}
.search_sle3 { font-size: 10px; font-family: Verdana; width:500px; color: #000000; margin:3px 0 0 0;}

.search_b {  font-weight: bold; color: #0E6F00; !important}} /* ------------퀰hange Color-------------- */
input, option, select, textarea       { font-size: 10px; font-family: Verdana; color: #000000; margin:3px 0 0 0;}

/* ------------B2B-------------- */
tr.B2B_head_top  { background-image: url(../../images/001/bg_header.gif); !important}
tr.B2B_head_bot  { background-image: url(../../images/001/bg_header_bot.gif); line-height: 14px;}
tr.B2B_footer_top  { background-image: url(../../images/001/bg_footer.gif); line-height: 20px;}
tr.B2B_footer_bot  { font-size: 10px; color: #000000; font-family: Verdana;}
td.B2B_headtag  { background-image: url(../../images/001/header_m.gif);}
td.B2B_phone  { font-size: 12px; line-height: 14px; color: #FF5400; font-family: Verdana;}
table.B2B_deal  { font-size: 10px; line-height: 14px; color: #000000; font-family: Verdana;}
td.B2B_deal  { font-size: 16px; line-height: 16px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}

/* ------------tll-------------- */
td.B2B_dealbg  { background:images/001/deal_m.gif; font-size: 16px; line-height: 16px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
/* ------------tll-------------- */

td.B2B_deal_line  { background-color: #BEDFA1; height: 1; !important}
td.B2B_deal_bg  { background-color: #E4F1D6; height: 30; !important}
a.B2B_headtag_on {  font-size: 16px; line-height: 33px; color: #0E6F00; text-decoration: none; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
a.B2B_headtag_on:hover {  font-size: 16px; line-height: 33px; color: #0E6F00; text-decoration: underline; font-family: Verdana; font-weight: bold; !important} /* ------------퀰hange Color-------------- */
a.B2B_headtag_off {  font-size: 16px; line-height: 33px; color: #000000; text-decoration: none; font-family: Verdana; font-weight: bold;}
a.B2B_headtag_off:hover {  font-size: 16px; line-height: 33px; color: #000000; text-decoration: underline; font-family: Verdana; font-weight: bold;}

a.B2B_link01 {  color: #000000; text-decoration: none;}
a.B2B_link01:hover {  color: #FF5400; text-decoration: none;}

a.B2B_link02 {  color: #FF5400; text-decoration: underline;}
a.B2B_link02:hover {  color: #FF5400; text-decoration: none;}

a.B2B_link03 {  color: #0E6F00; text-decoration: underline;}
a.B2B_link03:hover {  color: #0E6F00; text-decoration: none;}

.txt01{ color:#CC0000; font-size: 10px; line-height: 14px; font-family: Verdana; font-weight: bold;}
.t01{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;}
.t02{ color:#FF3300; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t03{ color:#FFFFFF; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t04{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}
.t05{ color:#CC0000; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t06{ color:#0E6F00; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t07{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana; font-weight: bold;}
.t08{ color:#666666; font-size: 9px; line-height: 16px; font-family: Verdana;}
.t09  { color:#000000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t10  { color:#005599; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t11  { color:#FF3300; font-size: 15px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t12{ color:#FF3300; font-size: 10px; line-height: 18px; font-family: Verdana; font-weight: bold;}

.call{ color:#FF6600; font-size: 20px; line-height: 24px; font-family: Verdana; font-weight: bold;}
a.d01 {  font-size: 10px; line-height: 14px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d01:hover {  font-size: 10px; line-height: 14px; color: #FF3300; text-decoration: none; font-family: Verdana;}
a.d02 {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: none; font-family: Verdana; font-weight: bold;}
a.d02:hover {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: underline; font-family: Verdana; font-weight: bold;}
a.d03 {  font-size: 10px; line-height: 20px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d03:hover {  font-size: 10px; line-height: 20px; color: #FF3300; text-decoration: none; font-family: Verdana;}
a.d04 {  font-size: 10px; line-height: 14px; color: #005599; text-decoration: none; font-family: Verdana; font-weight: bold;}
a.d04:hover {  font-size: 10px; line-height: 14px; color: #005599; text-decoration: underline; font-family: Verdana; font-weight: bold;}
a.d05 {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: underline; font-family: Verdana; font-weight: bold;}
a.d05:hover {  font-size: 10px; line-height: 20px; color: #CC0000; text-decoration: none; font-family: Verdana; font-weight: bold;}
a.d06 {  font-size: 10px; line-height: 18px; color: #0E6F00; text-decoration: underline; font-family: Verdana; font-weight: bold;}
a.d06:hover {  font-size: 10px; line-height: 18px; color: #FF3300; text-decoration: none; font-family: Verdana; font-weight: bold;}
a.d07 {  font-size: 10px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}
a.d07:hover {  font-size: 10px; line-height: 18px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d08 {  font-size: 10px; line-height: 16px; color: #FF3300; text-decoration: none; font-family: Verdana;}
a.d08:hover {  font-size: 10px; line-height: 16px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d09 {  font-size: 9px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}
a.d09:hover {  font-size: 9px; line-height: 18px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d10 {  font-size: 10px; line-height: 16px; color: #000000; text-decoration: none; font-family: Verdana;}
a.d10:hover {  font-size: 10px; line-height: 16px; color: #FF3300; text-decoration: none; font-family: Verdana;}

a.d11 {  font-size: 15px; line-height: 19px; color: #005599; text-decoration: none; font-family: Verdana; font-weight: bold;}
a.d11:hover {  font-size: 15px; line-height: 19px; color: #FF6600; text-decoration: none; font-family: Verdana; font-weight: bold;}

a.d12 {  font-size: 10px; line-height: 18px; color: #005599; text-decoration: none; font-family: Verdana;}
a.d12:hover {  font-size: 10px; line-height: 18px; color: #FF6600; text-decoration: none; font-family: Verdana;}


tr.R_pop   { font-size: 10px; line-height: 14px; color: #CCCCCC; font-family: Verdana;}
tr.R_cost   { font-size: 10px; line-height: 14px; color: #000000; font-family: Verdana;}
.step{margin:5px 0 0 0; padding:3px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size:10px; color:#777; height:16px;}
.step ul{margin:0;padding:0;list-style:none;float:right; }
.step ul li{float:left; display:block; border-top:solid 3px #ccc; padding:0 4px 0 4px; margin:0 0 0 2px;}
.step .stepon{border-top:solid 3px #f85000; color:#f85000;}

/*  add  */
.loading
{
background-image:url(../../images/001/loading.gif);
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
tr.tour_top  { background-image: url(../../images/001/tour_top_bg.gif); height: 32;}
tr.tour_mid  { background-image: url(../../images/001/tour_mid_bg.gif);}
td.tour_on  { background-image: url(../../images/001/tour_top_on.gif); height: 32; color:#FF6600; font-size: 14px; font-family: Arial; font-weight: bold; padding:0 20px 0 20px;}
td.tour_off  { background-image: url(../../images/001/tour_top_off.gif);  height: 32; color:#000000; font-size: 14px; font-family: Arial; font-weight: bold; padding:0 20px 0 20px;}
td.tour_name01  { color:#FF6600; font-size: 22px; line-height: 22px; font-family: Arial; font-weight: bold;}
td.tour_name02  { color:#767676; font-size: 14px; line-height: 18px; font-family: Arial; font-weight: bold;}
td.tour_name03  { color:#000000; font-size: 14px; line-height: 18px; font-family: Arial; font-weight: bold;}
td.tour_show01  { color:#FF6600; font-size: 25px; line-height: 25px; font-family: Arial; font-weight: bold;}
td.tour_show03  { color:#000000; font-size: 16px; line-height: 22px; font-family: Arial; font-weight: bold;}
a.tour_link01 {  font-size: 22px; line-height: 22px; color: #FF6600; text-decoration: none; font-family: Arial; font-weight: bold;}
a.tour_link01:hover {  font-size: 22px; line-height: 22px; color: #FF6600; text-decoration: none; font-family: Arial; font-weight: bold;}
a.cruise_link01 {  font-size: 20px; line-height: 20px; color: #FF6600; text-decoration: none; font-family: Arial; font-weight: bold;}
a.cruise_link01:hover {  font-size: 20px; line-height: 20px; color: #FF6600; text-decoration: none; font-family: Arial; font-weight: bold;}
a.tour_link02 {  color: #000000; text-decoration: none;}
a.tour_link02:hover {  color: #FF6600; text-decoration: none;}
a.tour_link03 {  color: #005599; text-decoration: underline;}
a.tour_link03:hover {  color: #005599; text-decoration: none;}


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
	.IBE_R_step03  { background-image: url(../../images/v2/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
	.IBE_R_order  { background-image: url(../../images/v2/bg_01.gif); height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
	.IBE_R_stepg  { background: #E9E9E9;}
	.IBE_head08{ color:#FF6600; font-weight:bold; font-size:16px; font-family:Arial;}
	.IBE_search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/btn_bg.gif)}
	.IBE_search_btn04 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; width:200px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/btn_bg1.gif)}
.IBE_package_step6_TravelerInformation_title{color: #fff; font-family: Verdana; font-weight: bold; height:25px; line-height:25px; background:#ff5203;}
.IBE_R_stepw{ background: #FFFFFF;}

.modalBackground
{
	background-color: Gray;
	filter: alpha(opacity=70);
	opacity: 0.7;
}
.IBE_package_step6_TravelerInformation_title{background-image: url(../images/bg_s03.gif); color: #fff; font-family: Verdana; font-weight: bold; height:30px; line-height:30px;}
.MV_hotel_step5_hotelInfo_price{ width:100%; float:left; margin:8px 0px; text-align:right;}
.under_rules{width:700px; margin:0 auto; font-size: 12px; color: #000000; font-family:Verdana; text-align:left;}
</style>
<table width="700" border="0" align="center" cellpadding="3" cellspacing="0" style="font-size: 14px;
    line-height: 19px; color: #000000; font-family: Verdana;">
    <tr>
        <td align="right" valign="top">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="lblDear" runat="server" meta:resourcekey="lblDear">Dear</asp:Label>&nbsp;<asp:Label
                            ID="lbName" runat="server"></asp:Label>,<br />
                        <asp:Label ID="lblThanksVia" runat="server" meta:resourcekey="lblThanksVia">Thanks for purchasing via</asp:Label>
                         Majestic Vacations Asia 
                        !
                        <asp:Label ID="lblYourOn" runat="server" meta:resourcekey="lblYourOn">Your order was placed on</asp:Label>:
                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                        US Easten Time.
                        <asp:Label ID="lblConfirmationEmail" runat="server" meta:resourcekey="lblConfirmationEmail">This is the confirmation e-mail</asp:Label>.</td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="10">
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellpadding="0" cellspacing="1" style="background: #999999;
                border: 0;" class="T_table">
                <tr style="background: #EAEAEA;">
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                        <tr>
                                            <td>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr align="left">
                                                        <td height="25" valign="top" style="color: #000000; font-size: 16px; line-height: 20px;
                                                            font-family: Verdana; font-weight: bold;">
                                                            <asp:Label ID="lblOrderSummary" runat="server" meta:resourcekey="lblOrderSummary">Your Order Summary</asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table width="100%" border="0" cellspacing="1" cellpadding="8" style="background-image: url(../../images/v2/bg_s03.gif);
                                                                font-size: 11px; line-height: 13px; color: #000000; font-family: Verdana; font-weight: bold;">
                                                                <tr style="background: #FFFFFF;">
                                                                    <td height="120">
                                                                        <table width="100%" border="0" cellpadding="8" cellspacing="1" style="background: #999999;
                                                                            border: 0;">
                                                                            <tr style="background: #FDF1C1;">
                                                                                <td valign="top">
                                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="7">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <table width="100%" border="0" cellspacing="1" cellpadding="8" style="background: #CCCCCC;
                                                                                                    border: 0;">
                                                                                                    <tr style="background: #FFFFFF;">
                                                                                                        <td align="left">
                                                                                                            <font class="t09">
                                                                                                                <asp:Label ID="lblOrderNumber" runat="server" meta:resourcekey="lblOrderNumber">The Order Number</asp:Label>:</font>
                                                                                                            <font class="t10">
                                                                                                                $ORDERNUMBER</font><br />
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
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr class="R_stepw">
                                                                                <td height="10">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table align="center" border="0" cellpadding="8" cellspacing="1" width="100%" class="T_step03">
                                                                            <tr valign="top" class="R_stepw">
                                                                                <td>
                                                                                    <table width="100%" border="0" cellpadding="2" cellspacing="0" class="T_step03">
                                                                                        <tbody>
                                                                                            <tr align="center" class="R_order03">
                                                                                                <td colspan="7" align="center" height="23">
                                                                                                    <b>
                                                                                                        <asp:Label ID="lblHotelInformation" runat="Server" meta:resourcekey="lblHotelInformation">Hotel Information</asp:Label></b></td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                    <asp:DataList ID="ddlHotel" runat="server" Width="100%" OnItemDataBound="ddlHotel_ItemDataBound">
                                                                                        <ItemTemplate>
                                                                                            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                                                                                <tr align="center" class="R_order">
                                                                                                    <td height="23" align="left" colspan="4">
                                                                                                        <asp:Label ID="lblHotelin" runat="Server" meta:resourcekey="lblHotelin">Hotel in</asp:Label>
                                                                                                        <asp:Label ID="lbcity" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.City.Name") %>'></asp:Label>
                                                                                                        <asp:Label ID="lblHotelin1" runat="Server" meta:resourcekey="lblHotelin1"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr class="R_stepw">
                                                                                                    <td width="2%">
                                                                                                        #<asp:Label ID="Label1" runat="server" Text='<%# Container.ItemIndex + 1%>'>
                                                                                                        </asp:Label></td>
                                                                                                    <td width="48%" align="left">
                                                                                                        <asp:Label ID="lbHotelName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Hotel.Name") %>'></asp:Label>$GTANUMBER</td>
                                                                                                    <td width="25%" align="left">
                                                                                                        <asp:Label ID="lblCheckIn" runat="Server" meta:resourcekey="lblCheckIn">Check In</asp:Label><asp:Label
                                                                                                            ID="lbCheckInDate" runat="server" Text='<%# " : " + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckIn")).ToString("MM/dd/yyyy")%>'></asp:Label><br />
                                                                                                        <asp:Label ID="lblCheckOut" runat="Server" meta:resourcekey="lblCheckOut">Check Out</asp:Label><asp:Label
                                                                                                            ID="lbCheckOutDate" runat="server" Text='<%# " : " + ((DateTime)DataBinder.Eval(Container.DataItem, "CheckOut")).ToString("MM/dd/yyyy")%>'></asp:Label>
                                                                                                    </td>
                                                                                                    <td width="25%" align="left">
                                                                                                        <asp:Repeater ID="rptRoom" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "RoomTypes") %>'>
                                                                                                            <ItemTemplate>
                                                                                                                <table>
                                                                                                                    <tr>
                                                                                                                        <td>
                                                                                                                            <asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1 %>'></asp:Label><asp:Label
                                                                                                                                ID="lbHotelDetails" runat="server" Text='<%# " " + DataBinder.Eval(Container.DataItem, "Room.Name")  %>'>
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
                                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
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
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="10">
                                                                                                <uc3:HTLTotalPriceControl ID="HTLTotalPriceControl1" runat="server" />
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
            <table align="center" width="700" border="0" cellspacing="0" cellpadding="0">
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
                                    <span class="head06">
                                        <asp:Label ID="lblServiceContact" runat="server" meta:resourcekey="lblServiceContact">Service Contact</asp:Label></span></td>
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
                                    <asp:Label runat=server ID="lblSalesName"></asp:Label>
                                    <br />
                                    &#8226; &nbsp;<asp:Label ID="lblPhone" runat="server" meta:resourcekey="lblPhone">Phone</asp:Label>:
                                    <asp:Label runat=server ID="lblSalesTel"></asp:Label>
                                    <br>
                                    &#8226; &nbsp;<asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>:<asp:Label runat=server ID="lblSalesEmail"></asp:Label>
                                    
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table align="center" border="0" cellpadding="0" cellspacing="0" width="700">
                <tr>
                    <td height="10">
                    </td>
                </tr>
                <tr>
                    <td height="50" align="left" valign="top">
                        <asp:Label ID="lblThankVisit" runat="server" meta:resourcekey="lblThankVisit">Thank you for your business. Please always visit</asp:Label>
                        <a href="http://www.majestic-vacations.com/" class="d07">
                            www.majestic-vacations.com
                        </a>
                        <asp:Label ID="lblForDeals" runat="server" meta:resourcekey="lblForDeals">for the greatest travel deals!</asp:Label></td>
                </tr>
                <tr>
                    <td align="right">
                        Enjoy your trip,
                        <br>
                        The Majestic Vacations Asia Team</td>
                </tr>
                <tr>
                    <td align="center">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
