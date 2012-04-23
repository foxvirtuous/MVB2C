<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SucceedFrom.aspx.cs" Inherits="SucceedFrom" %>

<%@ Register Src="../../UserControls/PKGTravelerInfoControl.ascx" TagName="PKGTravelerInfoControl"
    TagPrefix="uc10" %>
<%@ Register Src="../../UserControls/PKGContactViewControl.ascx" TagName="PKGContactViewControl"
    TagPrefix="uc11" %>
<%@ Register Src="../../UserControls/CreditCardInfoControl.ascx" TagName="CreditCardInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/PriceInfoControl.ascx" TagName="PriceInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/ContactViewControl.ascx" TagName="ContactViewControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/TravelerInfoControl.ascx" TagName="TravelerInfoControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/PKGSelectedHotelsControl.ascx" TagName="PKGSelectedHotelsControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/PKGSelectedFlightControl.ascx" TagName="PKGSelectedFlightControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/CreditCardEmailControl.ascx" TagName="CreditCardEmailControl"
    TagPrefix="uc11" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link rel="Stylesheet" href="../../css/style_package.css" />
    <link rel="Stylesheet" type="text/css" href="../../css/global.css" />

    <script language="javascript" type="text/javascript">
			function doPrint(){
				document.getElementById("btnPrint").style.visibility="hidden";
				document.getElementById("btnBackHome").style.visibility="hidden";
				window.print();
				document.getElementById("btnPrint").style.visibility="visible";
				document.getElementById("btnBackHome").style.visibility="visible";
			}
    </script>

<style type="text/css">
body{ font-family:Verdana, Arial, Helvetica, sans-serif;font-size:11px; margin:0; padding:0;}
ol,li,ul{ margin:0; padding:0; list-style:none;}
/*.IBE_package_step8样式区*/
.IBE_package_step8_main{ width:700px; margin:0 auto;}
.IBE_step8_step1{width:100%; float:left; line-height:20px; margin-bottom:10px;}
.IBE_step8_step2{width:100%; float:left; }
.IBE_step8_step2_title{ width:100%; float:left;color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold; margin:6px 0px;}
.IBE_step8_step3{ width:100%; float:left; padding:12px 0px; line-height:16px;}
.IBE_step8_t091 {color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.IBE_step8_t101 {color:#0e6f00; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.IBE_package_step8_step4{ width:100%; float:left; line-height:20px; margin-top:10px;}
.IBE_package_step8_step5{width:100%; float:left; line-height:20px; text-align:right; margin-top:10px;}
.IBE_package_step8_step6{ width:100%; float:left; margin:10px 0px; text-align:center;}

table.T_step02   { background: #999999; border: 0;}
.T_step03{ background: #CCCCCC; border: 0;}
a.d071 {color: #0000EE; text-decoration: underline; font-family: Verdana;}
td.D_stepr1 {color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold;}
tr.R_order1 {background: #EEEEEE; height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
tr.R_order031 {background: #00ab18; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.R_stepo1 {background: #F1F2F2;}
tr.R_stepw1 {background: #FFFFFF;}

.step3_price_price{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.t061 {color:#000000; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.IBE_step8_ServiceContact_title{ width:100%; float:left;color:#000000; font-size: 11px; line-height: 20px; font-family: Verdana; font-weight: bold; margin:10px 0px;}
.IBE_GrayDIV_Right{ width:674px; border:1px solid #999; background:#EAEAEA; padding:12px; float:left;}
.IBE_package_remarks{ width:678px; float:left; border:1px solid #999; padding:8px 10px;}
.IBE_package_step8_Service{ width:100%; float:left;}
.IBE_package_step8_Service ul{list-style:circle inside;}
.IBE_package_step8_Service li{ width:100%; float:left; line-height:20px;}
.IBE_package_step8_font_a{ font-size: 12px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}
.IBE_GrayDIV_Right_inSide1{width:656px; border:1px solid #ccc; background:#fff; padding:8px; float:left;}
body{ font-family:Verdana, Arial, Helvetica, sans-serif;font-size:11px;}

/*IBE_package布局样式区*/
.IBE_package_main{width: 920px; margin: 0 auto;}
.IBE_package_mainLeft{width: 170px; float: left;}
.IBE_package_mainCenter{width: 20px; float: left; height:100px;}
.IBE_package_mainRight{width:730px; float:left;}


/*IBE_package进度条样式区*/
.IBE_package_Dstep{width:100%; float:left; margin:20px 0px;}
.IBE_package_Dstepof  { background: #CCCCCC;}
.IBE_package_Dsteptf  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #777777; font-family: Verdana;}



/*IBE_package进度条更改样式区*/
.IBE_package_Dstepon  { background:#139B00;}
.IBE_package_Dstepto  { background: #FFFFFF; font-size: 9px; line-height: 12px; color:#139B00; font-family: Verdana;}



/*IBE_package_reSearch样式区*/
.IBE_package_reSearch{width: 170px;font-size: 10px;font-family: Verdana; }
.IBE_package_reSearch_title{width:170px; float:left; height:23px; line-height:23px; text-align:center; color:#fff;}

.IBE_package_reSearch_main_step1{ margin:0px 8px;}
.IBE_package_reSearch_main_step1 li{ width:100%; float:left; height:18px; line-height:18px; }
.IBE_package_reSearch_ddl{ width:145px; height:18px; margin:0px; padding:0px;}
.IBE_package_reSearch_tb{ width:80px;}
.IBE_package_reSearch_CT{margin:0px 4px; display:inline;  float:left; width:155px; height:22px; line-height:22px; margin-top:32px; font-weight:bold; font-size:9px; padding-left:5px;}
.IBE_package_reSearch_CT_main{width:152px; float:left; padding:8px; margin-bottom:35px;}


/*IBE_package_reSearch更改样式区*/
.IBE_package_reSearch_main{width:168px;  float:left; border:1px solid #FD4C00;}
.IBE_package_R_step01{ background:#FD4C00; background-image: url(../../images/v2/bg_s01.gif); font-size: 10px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
.IBE_package_D_stepb  { color: #FF6600; font-family: Verdana; font-weight: bold;font-size:9px;}
.IBE_package_reSearch_CT_C{background:#fdf1c1; color:#FF6600;}


/*IBE_package_SearchCondition更改样式区*/
.IBE_package_SearchCondition_T_step02{ background: #999999; border: 0;}
.IBE_package_SearchCondition_R_step02{ background: #EAEAEA;}
.IBE_package_SearchCondition_D_stepr{ color:#000000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold; float:left; height:25px; width:696px;}
.IBE_package_SearchCondition_T_step03{ background: #CCCCCC; border: 0; }
.IBE_package_SearchCondition_R_stepw{ background: #FFFFFF; font-size: 11px; line-height: 19px; font-family:Verdana;}
.IBE_package_SearchCondition_f06{ color:#005599; font-size: 11px; font-weight: bold; font-family:Verdana;}
.IBE_package_SearchCondition_f09 {  font-size: 9px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}
.IBE_package_SearchCondition_R_bg1{background: #FFFFFF; font-size: 11px; line-height: 19px; font-family:Verdana; border:1px solid #ccc; padding:8px; width:694px; float:left;}


/*IBE_package_step更改样式区*/
.IBE_package_step{ width:100%; float:left;color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold; margin:15px 0px 10px 0px;}
.IBE_package_step_T_line01{ background:#ff3300; font-size: 16px;width:20px; height:20px; color: #FFFFFF;  font-family: Arial; font-weight: bold; text-align:center; !important}



/*IBE_package_step样式区*/
.IBE_package_List{ width:710px; float:left;border:1px solid #999999;background: #fdf1c1; padding: 18px 8px; padding-bottom:0px;}
.IBE_package_List_changeCondition{ width:100%; float:left; font-size:11px; margin:15px 0px 15px 0px;}
.IBE_package_List_dl{ width:678px; float:left; border:1px solid #ccc; background:#fff; margin-bottom:12px; padding:15px;}
.IBE_package_List_DIV{width: 710px; float: left; font-family:Verdana; font-size:11px;}
.IBE_package_List_dl_list{width: 676px; float: left;}
.IBE_package_List_dl_I1{width: 100px; float: left;}
.IBE_package_returnDetail{width:708px; border:1px solid #999; height:27px; line-height:27px;float:left; font-size:11px; color:#fff; margin-bottom:8px; background:url(../../images/v2/bg_s03.gif) repeat-x; font-weight:bold; padding:0px 10px;}
.IBE_package_List_dl_hotelInfo{ float:left;display:inline; height:85px;}
.IBE_package_List_dl_hotelInfo li{ width:100%; float:left; line-height:17px;}
.IBE_package_List_dl_f10{ font-size:10px;}
.IBE_package_List_lb_btn{width: 100%; float: right; margin-top:10px; text-align: right;}
.IBE_package_listSortby{ margin-top:7px;}
.IBE_package_List_dl_hotelInfo_Tab{ width:100%; float:left;}
.IBE_package_List_dl_list_selRoom{width: 694px; float: left;}



/*IBE_package_step更改样式区*/
.IBE_package_List_dl_I2{width:131px; float:left; border:1px solid #FDF1C1; text-align:center; padding:5px 0px;}
.IBE_package_List_dl_t01{ color:#139B00; font-size: 10px; line-height: 14px; font-family: Verdana;}
.IBE_package_List_dl_call{ color:#139B00; font-size: 32px; line-height: 24px; font-family: Verdana; font-weight: bold;}
.IBE_package_List_dl_step{margin:5px 0 0 0; padding:3px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size:10px; color:#777; height:16px;}
.IBE_package_List_dl_t11{ color:#ff3300; font-size: 14px; line-height: 20px; font-family: Arial; font-weight: bold;}
.IBE_package_List_dl_d09{font-size: 9px;  color: #005599; text-decoration: underline; font-family: Verdana;}




/*IBE_package_step3样式区*/
.IBE_package_List_dl_list_selectRoom{ width: 692px; margin: 0px; display: inline; float: left; border-bottom:1px solid #ccc; padding-bottom:6px;}
.IBE_package_List_dl_selectRoom_hotelInfo{width:565px; float:left; margin-left:15px; display:inline;}
.IBE_package_List_dl_selectRoom_hotelInfo li{ width:100%; float:left; line-height:17px;}
.IBE_package_step_price{ width:708px; float:left; border:1px solid #ccc; padding:10px; font-size:11px;}







/*IBE_package_分页样式区*/
.IBE_package_List_stepg{ width:100%; float:left; text-align:right; font-size: 9px; line-height: 18px; font-family: Verdana;color:#000000;}



/*step3_price样式区*/
.step3_price_price{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.step3_price_price_t06{ color:#0e6f00; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}




/*IBE_package_hotelInfor样式区*/
.IBE_package_hotelInfor_Tab{width: 612px; float: left;}
.IBE_package_hotelInfor_Tab li{ float:left;	height: 32;background-color: #F3F3F3;font-size: 14px;font-family: Arial;font-weight: bold;padding:0px 20px; border:1px solid #ccc; border-bottom:none; line-height:32px; margin-left:12px; display:inline;}
.IBE_package_hotelInfor_FandA{width: 690px; border: 1px solid #ccc; float: left; background: #fff; padding: 10px;}
.IBE_package_hotelInfor_FandA_f16{ color:#000000; font-size: 16px; font-family: Arial; font-weight: bold;}



/*IBE_package_hotelInfor更改样式区*/
.IBE_package_hotelInfor{ width:712px; border:1px solid #999; float:left;background: #edf6f1; padding:8px;}
.IBE_package_search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #000; border: 0px solid; height: 22px; width:100px; background-color: white; padding: 0 0 2px 0; margin:0px 0 0px 0; border-color: #FD9845; background-image: url(../../images/v2/v2/btn_bg.gif)}





/*IBE_package_hotel_RoomType样式区*/
.IBE_package_RoomType{ width:712px; border:1px solid #999; background: #FDF1C1; padding:8px; float:left;}
.IBE_package_RoomType_title{ width:712px; float:left;}
.IBE_package_RoomType_list{ width:690px; float:left; border:1px solid #ccc; background:#fff; padding:0px 10px 10px 10px;}
.IBE_package_RoomType_list_R_stepbox{ background: #eeeeee; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}
.IBE_package_RoomType_list_T_table{ font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}
.IBE_package_RoomType_list_t09{ color:#000000; font-size: 16px;font-family: Arial; font-weight: bold;}
.IBE_package_RoomType_list_tour_day{ color:#FF9600; font-size: 16px; font-family: Arial; font-weight: bold; padding-top:20px;}




/*IBE_package_hotel_RoomType样式区*/
.IBE_package_Terms{ width:728px; border:1px solid #ccc; float:left; padding:12px 0px; text-align:center;}







/*IBE_package_MemberLogIn样式区*/
.IBE_confimMemberLogIn_signIn{ width:339px; float:left; margin-left:15px; display:inline; border-right:1px solid #ccc; font-size:12px; font-family:Arial;}
.IBE_confimMemberLogIn_signIn li{ width:100%; float:left;}



/*IBE_package_MemberLogIn更改样式区*/
.IBE_confimMemberLogIn_Bg{ width:710px; float:left; border:1px solid #ccc; background:#fff; padding:8px 0px;}
.IBE_confimMemberLogIn{width:712px; float:left; border:1px solid #999; background:#FDF1C1; padding:12px 8px;font-size: 11px; line-height: 19px; color: #000000; font-family: Verdana;}
.IBE_confimReviewOrder_Content_font1{color:#005599; font-size: 11px; font-family: Verdana; font-weight: bold;}
.IBE_meberLogin_font_a{ font-size: 9px; color: #005599; text-decoration: underline; font-family: Verdana;}





/*.IBE_package_step5_hotelInfo样式区*/
.IBE_package_step5_hotelInfo{ width:676px; float:left; border:1px solid #ccc; background:#fff; padding:8px; font-size:11px; font-family:Verdana;}
.IBE_package_step_Checkbox_conditions{ width:100%; float:left; margin-top:6px;}













/*.IBE_package_step5_hotelInfo更改样式区*/
.IBE_package_step5_hotelInfo_title{ width:100%; float:left; border-bottom:1px solid #ccc; padding-bottom:8px;}
.IBE_package_step5_hotelInfo_step1{width:100%; float:left; border-bottom:1px solid #ccc; padding:3px 0px;}
.IBE_package_step5_hotelInfo_step1 li{ width:100%; float:left; line-height:22px;}
.IBE_package_step5_hotelInfo_price{ width:100%; float:left; margin:8px 0px; text-align:right;}



/*.IBE_package_step5_TravelInfo更改样式区*/
.IBE_package_step5_TravelInfo_T_step0l{ background: #139b00; border: 0; margin-bottom:10px;}
.IBE_package_step5_TravelInfo_R_stepw{ background: #FFFFFF; font-size: 11px; line-height: 19px;}
.IBE_package_step5_TravelInfo_R_step03{ background-image: url(../../images/v2/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
.IBE_package_step5_TravelInfo_ContactInfo_title{ width:692px; height:30px; background:url(../../images/v2/bg_s03.gif) repeat-x; border:1px solid #ccc; line-height:30px; font-size: 11px; color: #fff; font-family: Verdana; font-weight: bold;}





/*.IBE_package_step6_TravelInfo样式区*/
.IBE_package_step6_TravelerInformation_title{background:#ff5203; color: #fff; font-family: Verdana; font-weight: bold; height:30px; line-height:30px;}
.IBE_package_Email{  color: #005599; text-decoration: underline; font-family: Verdana;}
.IBE_package_step6_TravelerInformation_title2{background:#eaeaea; color: #000; font-family: Verdana; font-weight: bold; height:22px; padding-top:8px; text-align:left; padding-left:10px;}



/*.IBE_package_step7_step1样式区*/
.IBE_package_step7_step1{ width:100%; float:left; line-height:20px; font-size:11px; margin-bottom:10px;}
.IBE_package_step7_YellowDIV_Right{ width:672px; border:1px solid #999; background: #FDF1C1; padding:10px; float:left;}
.IBE_package_step7_YellowDIV_Right_inside{ width:840px; border:1px solid #ccc; background:#fff; padding:10px; text-align:left;}
.IBE_package_step7_t09{ color:#000000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.IBE_package_step7_t10{ color:#0e6f00; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.IBE_package_step7_Service{ width:100%; float:left;}
.IBE_package_step7_Service ul{list-style:circle inside;}
.IBE_package_step7_Service li{ width:100%; float:left; line-height:20px;}
.IBE_package_step7_font_a{ font-size: 12px; line-height: 18px; color: #005599; text-decoration: underline; font-family: Verdana;}




/*.IBE_package_step7_step1更改样式区*/
.IBE_package_step7_print{ width:100%; float:left; text-align:center; margin:10px 0px;}



/*.IBE_package_searcherror STYLE*/
.IBE_package_errorMsg{ width:727px; float:left; border:1px solid #cc0000;  font-size:11px; color:#cc0000; font-weight:bold;}
.IBE_package_error_RBL_Title{ width:100%; float:left; border-bottom:1px solid #ffcc96; margin-top:15px; padding-bottom:5px; color:#ff6600; font-weight:bold;}
.IBE_package_error_RBL{ width:100%; float:left; margin-top:10px; font-size:12px;}
.IBE_package_errorMsg1{ width:100%; float:left; margin-top:20px;}
.IBE_package_errorMsg1 a{ text-decoration:underline; color:blue;}
.IBE_package_error_submit{ width:100%; float:left; text-align:center; margin-top:30px;}



/*IBE_package_Travelers&ContactInformation*/
.IBE_GrayDIV_Right_travelContact_step4{width:902px; border:1px solid #999; background:#EAEAEA; padding:8px; float:left; padding-bottom:28px; background-image:url(../../images/v2/bg_s04.gif); background-position:bottom; background-repeat:repeat-x;}
.IBE_package_SearchCondition_T_step04{  width:866px; padding:8px; border:1px solid #ccc; margin-top:10px;}
.IBE_package_SearchCondition_T_step04_totalPrice{height:30px; line-height:30px; float:right;}
.IBE_package_SearchCondition_D_title_step4{ color:#000000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold; float:left; height:25px;}
.IBE_YellowDIV_Right_travelContact_step4{ width:902px; border:1px solid #999; background: #FDF1C1; padding:16px 8px; float:left; font-size:11px;}
.IBE_YellowDIV_Right_inSide1_travelContact_step4{width:884px; border:1px solid #ccc; background:#fff; padding:8px; float:left;}
.IBE_package_step4_TravelInfo_ContactInfo_title{ width:882px; height:30px; background:url(../../images/v2/bg_01.gif) repeat-x; border:1px solid #ccc; line-height:30px; font-size: 11px; color: #000; font-family: Verdana; font-weight: bold; margin-top:10px;}

.IBE_package_step4_TravelInfo_ContactInfo_title_sub{ height:22px; background:url(../../images/v2/bg_01.gif) repeat-x; font-size: 11px; color: #000; font-family: Verdana; font-weight: bold; padding-left:10px;}
.IBE_package_remarks_travelContact{ width:898px; float:left; border:1px solid #999; padding:8px 10px; font-weight:bold; font-size:11px;}
.IBE_package_remarks_travelContact li{ width:100%; float:left; height:22px; font-weight:normal; line-height:22px;}
.IBE_package_SearchCondition_step06_ContactInfo{width:100%; float:left; margin-top:5px;}






/*comment style for IBE*/

.IBE_YellowDIV_Right{ width:712px; border:1px solid #999; background: #FDF1C1; padding:16px 8px; float:left; font-size:12px;}
.IBE_YellowDIV_Right_inSide1{width:694px; border:1px solid #ccc; background:#fff; padding:8px; float:left;}
.IBE_YellowDIV_Right_inSide2{width:676px; border:1px solid #ccc; background:#fff; padding:8px; float:left;}
.IBE_YellowDIV_Right_title{ width:100%; float:left; margin-top:3px;}




.IBE_GrayDIV_Right{ width:712px; border:1px solid #999; background:#EAEAEA; padding:8px; float:left; padding-bottom:28px; background-image:url(../../images/v2/bg_s04.gif); background-position:bottom; background-repeat:repeat-x;}
.IBE_GrayDIV_Right_title{color:#000000; font-size: 16px; font-family: Arial; font-weight: bold; margin:3px 0px;}
.IBE_GrayDIV_Right_inSide1{width:694px; border:1px solid #ccc; background:#fff; padding:8px; float:left; padding-bottom:10px; margin-bottom:6px; font-size:11px;}




.IBE_DIV{width:100%; float:left;}
.IBE_head09{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.IBE_package_RoomType_list_th_border{ border-bottom:1px solid #ccc;border-top:1px solid #ccc;}
.td_border_bot{border-bottom: 1px solid rgb(216, 216, 216);}
.step3_t06{ color:#0e6f00; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.IBE_package_tour_day{ color:#FF9600; font-size: 16px; font-family: Arial; font-weight: bold; padding-top:20px;}

.IBE_R_stepw{ background: #FFFFFF;}
.Required_t01{ color:#FF3300; font-size: 10px; font-family: Verdana;}
.IBE_t10{ font-size:10px; font-family:Verdana;}
.IBE_package_remarks{ width:708px; float:left; border:1px solid #999; padding:8px 10px;}
.IBE_package_changeLB{ margin:10px 0px; float:right; margin-right:15px;}
.IBE_package_tourDayT{height:25px; float:left; width:100%; margin-top:10px;}



/*newMotion ListDetail*/


.IBE_package_List_dl_list_detail{width: 680px; margin-top: 15px; margin-bottom: 15px; float: left; margin-top:0px; border-top:1px dotted #ccc; padding-top:10px; display:none;}
.IBE_package_List_dl_list_detail_img{width:300px; float:left; text-align:center;}
.IBE_package_List_dl_list_detail_title{width:380px; float:left; height:20px; line-height:20px; font-weight:bold; text-align:center;}
.IBE_package_List_dl_list_detail_content{width:380px; float:left; list-style-type:circle;}
.IBE_package_List_dl_list_detail_content li{ width:360px; padding:6px; white-space:nowrap; padding-left:0px; font-size:11px; text-align:center;}

.IBE_package_List_dl_list_map{width: 680px; margin-top: 15px; margin-bottom: 15px; margin-left:15px;_margin-left:7px; margin-right:15px;_margin-right:7px; border-top:1px dotted #ccc; padding-top:10px; display:none;}
.IBE_package_List_dl_list_map_img{ width:680px; float:left; text-align:center; margin-top:10px;}
.IBE_package_List_dl_list_locations{width:680px; float:left; margin-top:0px; margin-bottom:10px;}
.IBE_package_List_dl_list_locations li{ width:680px; float:left;font-size:11px;}
.IBE_package_List_dl_list_locations_title{width:680px; float:left;  font-weight:bold; margin-bottom:10px;}

.IBE_package_List_dl_list_photos{width: 680px; margin-top: 15px; margin-bottom: 15px; margin-left:15px;_margin-left:7px; margin-right:15px;_margin-right:7px; float: left; margin-top:0px; border-top:1px dotted #ccc; padding-top:10px; display:none;}
.IBE_package_List_dl_list_photos li{ margin:20px; float:left; display:inline; text-align:center; border:2px solid #77cbfc; padding:3px; margin-top:0px;}



.IBE_package_List_dl_list_flights{width: 680px; margin-top: 15px; float: left; margin-top:0px; border-top:1px dotted #ccc; padding-top:10px; font-family:Verdana; font-size:11px; display:none;}
.IBE_package_List_dl_list_flights_float1{ width:100%; float:left; margin:6px 0px;}









.IBE_confimMemberLogIn_Title{ width:664px; float:left;color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold; margin:25px 0px 10px 0px;}

.IBE_confimReviewOrder_Content_font1{color:#0E6F00; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.IBE_confimReviewOrder_Content_font2{color:#666666; font-size: 9px; line-height: 16px; font-family: Verdana;}

.IBE_confimReviewOrder_Content_font3{color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.IBE_T_line01{ background: #139B00; font-size: 16px;width:20px; height:20px; color: #FFFFFF;  font-family: Arial; font-weight: bold; text-align:center; !important}
.IBE_search_btn02 { font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; background-color: white; padding:0px 5px 2px 5px; border-color: #FD9845; background-image: url(btn_bg1.gif)}
.IBE_search_btn04{font-size: 13px; font-family: Verdana; font-weight: bold; color: #FFFFFF; border: 0px solid; height: 22px; background-color: white;padding:0px 5px 2px 5px; border-color: #FD9845; background-image: url(btn_bg.gif)}




/*package more Search style*/
.IBE_package_step_moreSearch_bt{  width:708px; padding:0px 6px; float:left; font-family:Verdana; font-size:11px;}
.IBE_package_step_moreSearch_bt_title{ width:100%; float:left; height:25px; background:url(../images/line01.gif) left bottom no-repeat;	   font-family:Verdana, Helvetica, sans-serif;
	   font-size:12px;
	   font-weight:bold;
	   color:#ff6600;}
.IBE_package_step_moreSearch_bt_LI{ width:100%; float:left; margin:10px 0px;}
.IBE_package_step_moreSearch_bt_LI li{ float:left;}
.IBE_package_step_moreSearch_bt_LI input{ height:12px;}
.IBE_package_step_moreSearch_bt_bottomline{ border-bottom:1px dotted #ccc; height:6px; width:100%; float:left; overflow:hidden;}
.IBE_package_step_moreSearch_veditorfontStyle{ font-size:10px; color:#ff3300;}


/*form IEB_Flight*/

.outside1T{float:left; border:2px solid #fff; width:676px;}
.outside2T{border-bottom:2px solid #ccc; float:left; margin:5px; display:inline; width:667px;}
    .gridview{ width:100%; float:left;font-size: 11px; font-family: Verdana, Arial, Helvetica, sans-serif; white-space: nowrap;padding-bottom: 10px; display:inline; margin-top:20px;}
    .corpname{color: #5C82E6;
	font-weight: bold;}
.Details{color: #3366D5; text-decoration: underline; cursor:pointer;}
.perPerson{color: #666666; font-size: 9px; float:left; width:100%; margin-top:5px;}
.PriceByRed{font-size: 12px; font-weight: bold; color: #FF3300;}
.blueByPrice{	font-size: 20px;
	color: #3366CC;
	
	font-weight: bold;}
	
	.dlSubTrips{	float: left;
	padding-top: 3px;
	background-color: #F3F3F3;
	display: block;
	height: 20px;
	width: 100%;
	border-top-width: 1px;
	border-bottom-width: 1px;
	border-top-style: solid;
	border-bottom-style: solid;
	border-top-color: #fff;
	border-bottom-color: #fff;
	}
	
	
	
	/*form style_new*/
	.IBE_T_step03   { background: #CCCCCC; border: 0; font-size:11px;}
	.IBE_R_stepw  { background: #FFFFFF;}
	.IBE_R_order03  { background-image: url(../../images/v2/bg_01.gif); height: 25; color: #000; font-family: Verdana; font-weight: bold;  }
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

.HotelFeature{font-size:11px;  padding:4px;}
.tag{margin:0 0 8px 0; padding:3px 0 3px 6px; background:#fffeea }
.tag a:link, .tag a:visited{color:#06c;}
.tag a:hover{color:#f85000;}
.description{border-bottom: solid 1px #ccc; margin-bottom:12px; padding-bottom:12px;}
.description h5{margin:0 0 5px;}
.description .smallpic{float:right; background: #FDF8EA; border:solid 1px #FFCC00; padding:5px;margin:0 5px 5px 5px;}
.description .smallpic img{width:150px; height:100px;}
.Location{font-size:11px; padding:4px;}
.photo{font-size:11px; padding:4px;}
.photo .show{text-align:center;}
.photo a:link, .photo a:visited{color:#06c;}
.photo a:hover{color:#f85000;}
.roomopt{padding:4px;}
.roomopt table{width:100%;}
.roomoptlist{border:solid 1px #999;}
.roomoptlist td{font-size:11px;background:#F4F8DA; border-bottom:solid 1px #CAD6A3;}
.fB{ font-weight:bold;}
</style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div class="IBE_package_main">
            <div class="IBE_package_Dstep" align="right">
                <uc8:NavigationControl ID="NavigationControl1" runat="server" />
            </div>
            <div style="width: 920px; float: left; margin-bottom:20px;">
                <div class="IBE_package_step" style="margin-top: 0px;">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <asp:Label ID="lblThanksPurchase" runat="server" meta:resourcekey="lblThanksPurchase">Thanks for Your Purchase</asp:Label>
                </div>
                <div class="IBE_package_step7_step1">
                    <asp:Label ID="lblOrderOn" runat="server" meta:resourcekey="lblOrderOn">Order was placed on</asp:Label>:
                    <asp:Label ID="lblDateNow" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label3" runat="server" meta:resourcekey="lblUSEastenTime">US Easten Time</asp:Label>.<br />
                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblconfirmation">The confirmation e-mail will be sent out within 3 business days.</asp:Label>
                     <asp:Label ID="Label2" runat="server" meta:resourcekey="lblMsg">If you do not hear back from us within 3 business days, please call us at 1-(888)-288-7528.</asp:Label>
                </div>
                <div class="IBE_GrayDIV_Right_travelContact_step4">
                    <div class="IBE_package_SearchCondition_D_title_step4">
                        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblUSEastenTime">Your Order Summary</asp:Label></div>
                    <table class="IBE_package_SearchCondition_T_step03" border="0" cellpadding="8" cellspacing="1"
                        width="100%">
                        <tbody>
                            <tr class="IBE_package_SearchCondition_R_stepw">
                                <td align="right" width="50%">
                                    <div class="IBE_package_step7_YellowDIV_Right" style="width: 97%;">
                                        <div class="IBE_package_step7_YellowDIV_Right_inside" style="width: 97%;">
                                            <span class="IBE_package_step7_t09">The Order Number:</span> <span class="IBE_package_step7_t10">
                                                <asp:Label ID="lblOrderNumber" runat="server"></asp:Label></span><br />
                                            <span class="IBE_package_step7_t09">Airline Record Locator:</span> <span class="IBE_package_step7_t10">
                                                <asp:Label ID="lblPNR" runat="server"></asp:Label></span>
                                        </div>
                                    </div>
                                    <div class="IBE_package_SearchCondition_step06_ContactInfo">
                                        <table id="Table1" border="0" cellpadding="0" cellspacing="0" runat="server">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" meta:resourcekey="lblFrom">From</asp:Label>&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblFrom" runat="server"></asp:Label></font>
                                                    <asp:Label ID="Label6" runat="server" meta:resourcekey="lblTo">to</asp:Label> <font class="IBE_package_SearchCondition_f06">
                                                        <asp:Label ID="lblTo" runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:Label ID="Label7" runat="server" meta:resourcekey="lblDepartDate">Depart Date</asp:Label>:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblDepartDate"
                                                        runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp; 
                                                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblReturnDate" runat="server"></asp:Label></font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblRoomsAndPassengers" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label9" runat="server" meta:resourcekey="lblFlightInformation">Flight Information</asp:Label></div>
                                                    <uc3:PKGSelectedFlightControl ID="PKGSelectedFlightControl1" runat="server"></uc3:PKGSelectedFlightControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label11" runat="server" meta:resourcekey="lblHotelInformation">Hotel Information</asp:Label></div>
                                                    <uc6:PKGSelectedHotelsControl ID="PKGSelectedHotelsControl1" runat="server"></uc6:PKGSelectedHotelsControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label12" runat="server" meta:resourcekey="lblTravelerInformation">Traveler Information</asp:Label></div>
                                                    <uc10:PKGTravelerInfoControl ID="PKGTravelerInfoControl1" runat="server"></uc10:PKGTravelerInfoControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <%-- <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;" visible="false">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        Transportation Information</div>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="0" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_package_step6_TravelerInformation_title2" style="height: 25px; line-height: 25px;">
                                                                <td align="left" width="25%">
                                                                    Pick Up Information</td>
                                                                <td align="left">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="6" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td width="25%">
                                                                    Arriving From:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Flight Number and Airline code:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Estimated Time of Arrival:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="0" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_package_step6_TravelerInformation_title2" style="height: 25px; line-height: 25px;">
                                                                <td align="left" width="25%">
                                                                    Drop Off Information</td>
                                                                <td align="left">
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <table class="IBE_T_step03" width="100%" border="0" cellpadding="6" cellspacing="1">
                                                        <tbody>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td width="25%">
                                                                    Hotel Address:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    City:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Country or Area:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Zip Code:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                            <tr class="IBE_R_stepw" align="left">
                                                                <td>
                                                                    Phone Number:</td>
                                                                <td>
                                                                    <span></span>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>--%>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label13" runat="server" meta:resourcekey="lblContactInformation">Contact Information</asp:Label></div>
                                                    <uc11:PKGContactViewControl ID="PKGContactViewControl1" runat="server"></uc11:PKGContactViewControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0"
                                        style="margin-top: 10px;">
                                        <tbody>
                                            <tr>
                                                <td align="center">
                                                    <uc11:CreditCardEmailControl ID="CreditCardEmailControl1" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="IBE_package_SearchCondition_T_step04">
                                        <uc8:PriceInfoControl ID="PriceInfoControl1" runat="server" />
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="IBE_package_step">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <span class="left"><asp:Label ID="lblServiceContact" runat="server" meta:resourcekey="lblServiceContact">Service Contact</asp:Label></span>
                </div>
                <div class="IBE_package_remarks_travelContact">
                    <div class="IBE_package_Travel_Insurance">
                        <ul>
                            <li>&#8226; &nbsp;<asp:Label ID="lblCustomerStaff" runat="server" meta:resourcekey="lblCustomerStaff">Customer Service Staff</asp:Label>: <asp:Label runat=server ID="lblSalesName"></asp:Label></li>
                            <li>&#8226; &nbsp;<asp:Label ID="lblPhone" runat="server" meta:resourcekey="lblPhone">Phone</asp:Label>: 1-(888)-288-7528</li>
                            <li>&#8226; &nbsp;<asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>: <asp:Label runat=server ID="lblSalesEmail"></asp:Label> </li>
                        </ul>
                    </div>
                </div>
                <table align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <%--<button id="btnPrint" class="search_btn05" style="font-size:11px; font-family:Verdana;" value="Print out this page" onclick="doPrint();"
                                name="Print out this page">
                                <asp:Label ID="Label10" runat="server" meta:resourcekey="btnPrint">Print out this page</asp:Label></button>--%>&nbsp;
                            <asp:Button ID="btnBackHome" runat="server" CssClass="search_btn05" Text="Homepage"  meta:resourcekey="btnBackHome"
                                OnClick="btnBackHome_Click" /></td>
                    </tr>
                </table>
            </div>
            <uc2:FooterP ID="Footer1" runat="server" />
        </div>
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
