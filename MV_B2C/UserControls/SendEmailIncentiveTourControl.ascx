<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SendEmailIncentiveTourControl.ascx.cs"
    Inherits="SendEmailIncentiveTourControl" %>
<style type="text/css">
<!--
table.T_table   { font-size: 14px; line-height: 19px; color: #000000; font-family: Verdana;}
table.T_step0l   { background: #FD4C00; border: 0;}
table.T_step02   { background: #999999; border: 0;}
table.T_step03   { background: #CCCCCC; border: 0;}

tr.R_step01  { background-image: url(../images/bg_s01.gif); font-size: 10px; line-height: 12px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.R_step02  { background: #EAEAEA;}
tr.R_step03  { background-image: url(../images/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.R_step04  { background-image: url(../images/bg_s04.gif);}
tr.R_stepbox  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}
td.D_stepto  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #F85000; font-family: Verdana;}
td.D_steptf  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #777777; font-family: Verdana;}
td.D_stepon  { background: #F85000;}
td.D_stepof  { background: #CCCCCC;}
tr.R_stepw  { background: #FFFFFF;}
tr.R_stepg  { background: #E9E9E9;}
tr.R_stepo  { background: #FDF1C1;}
td.D_stepb  { color: #FF6600; font-family: Verdana; font-weight: bold;}
td.D_stepr  { color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}
td.D_stepg  { color:#000000; font-size: 9px; line-height: 18px; font-family: Verdana;}
td.D_stepl  { background: #CCCCCC;}
tr.R_order  { background: #EEEEEE; height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
tr.R_order03  { background: #FF3300; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.R_order01  { background-color: #FFFFFF; height: 25;}
tr.R_order02  { background-color: #E9E9E9; height: 25;}
.t01{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;}
.t02{ color:#FF3300; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t03{ color:#FFFFFF; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t04{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}
.t05{ color:#CC0000; font-size: 11px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t06{ color:#000000; font-size: 14px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.t07{ color:#FF3300; font-size: 10px; line-height: 14px; font-family: Verdana; font-weight: bold;}
.t08{ color:#000000; font-size: 9px; line-height: 16px; font-family: Verdana;}
.t09  { color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.t10  { color:#005599; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.head06{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}
a.d07 {   color: #0000EE; text-decoration: underline; font-family: Verdana;}
a.d07:hover {  color: #0000EE; text-decoration: none; font-family: Verdana;}
-->
</style>
<table width="700" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td align="center">
            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" class="T_table">
                <tr>
                    <td align="right" valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="left">
                                    Dear 
                                    <asp:Label ID="lblFullName" runat="server" Text=""></asp:Label>,<br>
                                    <br>
                                    Thank you for choosing Majestic Vacations! Our sales representitive will contact
                                    in 2 business days.</td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step02">
                            <tr class="R_stepw">
                                <td align="left">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr align="center" class="R_order03">
                                            <td height="30" colspan="4">
                                                <b>Your Request Information</b></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Case Number:</b></td>
                                            <td width="25%" style="border-bottom: solid #cccccc 1px" colspan="3">
                                                <asp:Label ID="lblCasenNmber" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Contact Person:</b></td>
                                            <td width="25%" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblContactPerson" runat="server" Text=""></asp:Label></td>
                                            <td width="25%" style="border-bottom: solid #cccccc 1px">
                                                <b>Company Name:</b></td>
                                            <td width="25%" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblCompanyName" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Tel #:</b></td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>&nbsp;</td>
                                            <td style="border-bottom: solid #cccccc 1px">
                                                <b>Cell #:</b></td>
                                            <td style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblCell" runat="server" Text=""></asp:Label>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>E-mail:</b></td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>&nbsp;</td>
                                            <td style="border-bottom: solid #cccccc 1px">
                                                <b>Fax:</b></td>
                                            <td style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblFax" runat="server" Text=""></asp:Label>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Contact By:</b></td>
                                            <td height="30" colspan="3" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblContactBy" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Address:</b></td>
                                            <td height="30" colspan="3" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblAddress" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>City:</b> <asp:Label ID="lblCity" runat="server" Text=""></asp:Label></td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                <b>State:</b> <asp:Label ID="lblState" runat="server" Text=""></asp:Label></td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                <b>Zip Code:</b> <asp:Label ID="lblZipCode" runat="server" Text=""></asp:Label></td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Budget Amount:</b></td>
                                            <td height="30" colspan="3" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblBudgetAmount" runat="server" Text=""></asp:Label>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="2" style="border-bottom: solid #cccccc 1px">
                                                <b>Estimate Arrival China:</b> <asp:Label ID="lblEstimateArrivalChina" runat="server" Text=""></asp:Label></td>
                                            <td colspan="2" style="border-bottom: solid #cccccc 1px">
                                                <b>Estimate Dept. China:</b> <asp:Label ID="lblEstimateDeptChina" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Trip Plan:</b></td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblTripPlan" runat="server" Text=""></asp:Label> days</td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                <b>Estimate Register:</b></td>
                                            <td height="30" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblEstimateRegister" runat="server" Text=""></asp:Label> Person(s)</td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Visit Cities:</b></td>
                                            <td height="30" colspan="3" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblVisitCities" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Hotel Choose:</b></td>
                                            <td height="30" colspan="3" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblHotelChoose" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" style="border-bottom: solid #cccccc 1px; width: 169px;">
                                                <b>Specific Hotel:</b></td>
                                            <td height="30" colspan="3" style="border-bottom: solid #cccccc 1px">
                                                <asp:Label ID="lblSpecificHotel" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="4" style="border-bottom: solid #cccccc 1px">
                                                <b>Meal Plan (Could Multiple Choose):</b> <asp:Label ID="lblMealPlan" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="4" style="border-bottom: solid #cccccc 1px">
                                                <b>Local Guide Request:</b> <asp:Label ID="lblLocalGuideRequest" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="30" colspan="4" style="border-bottom: solid #cccccc 1px" >
                                                <b>Local Guide Language Speaking:</b> <asp:Label ID="lblLocalGuideLanguageSpeaking" runat="server" Text="" ></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <b>Special Request:</b><br />
                                                <asp:Label ID="lblSpecialRequest" runat="server" Text=""></asp:Label>
                                                <center>
                                                </center>
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
                                            <td align="left" class="D_stepr">
                                                Service Contact</td>
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
                                                &#8226; &nbsp;Sales Representitive: Kathryn Potitha<br>
                                                &#8226; &nbsp;Phone: 1-(888)-288-7528 ext 6269
                                                <br>
                                                &#8226; &nbsp;Email: <a href="mailto:kpotitha@majestic-vacations.com" class="d07">kpotitha@majestic-vacations.com</a></td>
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
                                <td align="left" valign="top">
                                    Always visit <a href="http://www.majestic-vacations.com/" class="d07">www.majestic-vacations.com</a>
                                    for the greatest travel deals!</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Enjoy your trip,
                                    <br>
                                    The Majestic Vacation Team</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
