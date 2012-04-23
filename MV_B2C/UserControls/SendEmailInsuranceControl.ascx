<%@ Control Language="C#" AutoEventWireup="true" Codebehind="SendEmailInsuranceControl.ascx.cs"
    Inherits="SendEmailInsuranceControl" %>
<%@ Register Src="NewInsuranceOrderSummaryControl.ascx" TagName="NewInsuranceOrderSummaryControl"
    TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/ContactViewControl.ascx" TagName="ContactViewControl"
    TagPrefix="uc12" %>
<style type="text/css">
<!--
table.MailT_table   { font-size: 14px; line-height: 19px; color: #000000; font-family: Verdana;}
table.MailT_step0l   { background: #FD4C00; border: 0;}
table.MailT_step02   { background: #999999; border: 0;}
table.MailT_step03   { background: #CCCCCC; border: 0;}
tr.MailR_step01  { background-image: url(../images/bg_s01.gif); font-size: 10px; line-height: 12px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.MailR_step02  { background: #EAEAEA;}
tr.MailR_step03  { background-image: url(../images/bg_s03.gif); font-size: 11px; line-height: 13px; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.MailR_step04  { background-image: url(../images/bg_s04.gif);}
tr.MailR_stepbox  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #000000; font-family: Verdana;}
td.MailD_stepto  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #F85000; font-family: Verdana;}
td.MailD_steptf  { background: #FFFFFF; font-size: 9px; line-height: 12px; color: #777777; font-family: Verdana;}
td.MailD_stepon  { background: #F85000;}
td.MailD_stepof  { background: #CCCCCC;}
tr.MailR_stepw  { background: #FFFFFF;}
tr.MailR_stepg  { background: #E9E9E9;}
tr.MailR_stepo  { background: #FDF1C1;}
td.MailD_stepb  { color: #FF6600; font-family: Verdana; font-weight: bold;}
td.MailD_stepr  { color:#000000; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}
td.MailD_stepg  { color:#000000; font-size: 9px; line-height: 18px; font-family: Verdana;}
td.MailD_stepl  { background: #CCCCCC;}
tr.MailR_order  { background: #EEEEEE; height: 25; color: #000000; font-family: Verdana; font-weight: bold;}
tr.MailR_order03  { background: #FF3300; height: 25; color: #FFFFFF; font-family: Verdana; font-weight: bold;}
tr.MailR_order01  { background-color: #FFFFFF; height: 25;}
tr.MailR_order02  { background-color: #E9E9E9; height: 25;}
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

/* zhangyanlei add 2009-7-22    */
span,td{ font-size:11px; font-family:Verdana;}
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
                                    <asp:Label ID="lblDear" runat="server" Text=""></asp:Label>,<br>
                                    <br>
                                    Thanks for purchasing via Majestic Vacations! Your order was placed on:
                                    <asp:Label ID="lblBookingTime" runat="server"></asp:Label>
                                    US Eastern Time. Our sales representitive with contact you in 24 hours to confirm
                                    your booking.</td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td height="10">
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr align="left">
                                <td height="25" valign="top" class="MailD_stepr">
                                    Your Order Summary</td>
                            </tr>
                            <tr>
                                <td>
                                    <table width="100%" border="0" cellspacing="1" cellpadding="0">
                                        <tr>
                                            <td height="120">
                                                <table width="100%" border="0" cellpadding="8" cellspacing="1" class="MailT_step02">
                                                    <tr class="MailR_stepo">
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="7">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="MailT_step03">
                                                                            <tr class="MailR_stepw">
                                                                                <td align="left">
                                                                                    <font class="t09">The Order Number:</font> <font class="t10">$ORDERNUMBER</font>
                                                                                    <br />
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
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <uc8:NewInsuranceOrderSummaryControl ID="NewInsuranceOrderSummaryControl1" runat="server" />
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table class="MailT_step02" align="center" border="0" cellpadding="0" cellspacing="1"
                                                    width="100%">
                                                    <tr class="MailR_stepw">
                                                        <td align="center">
                                                            <table border="0" cellpadding="2" cellspacing="0" width="100%">
                                                                <tr align="center" class="MailR_order03">
                                                                    <td height="23" colspan="7" align="center">
                                                                        <b>Traveler Information</b></td>
                                                                </tr>
                                                            </table>
                                                            <table border="0" cellpadding="2" cellspacing="1" width="100%" class="T_step03">
                                                                <tr align="center" class="MailR_stepw">
                                                                    <td width="7%" height="23">
                                                                    </td>
                                                                    <td width="48%">
                                                                        Name</td>
                                                                    <td width="20%">
                                                                        Date of Birth</td>
                                                                    <td width="25%">
                                                                        Passport Number</td>
                                                                </tr>
                                                            </table>
                                                            <asp:DataList ID="dlPassengers" runat="server" Width="100%" CellPadding="0" CellSpacing="0"
                                                                BorderStyle="None" OnItemDataBound="dlPassengers_ItemDataBound">
                                                                <ItemTemplate>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                                <table border="0" cellpadding="3" cellspacing="1" width="100%" class="T_step03">
                                                                                    <tr align="left" class="MailR_stepw">
                                                                                        <td width="15%">
                                                                                            <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassengerType")%>'></asp:Label>
                                                                                            <asp:Label ID="lb" runat="server" Text='<%# Container.ItemIndex + 1%>'>.</asp:Label></td>
                                                                                        <td width="40%">
                                                                                            <asp:Label ID="lbFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName")%>'></asp:Label>&nbsp;
                                                                                            <asp:Label ID="lbMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName")%>'></asp:Label>&nbsp;
                                                                                            <asp:Label ID="lbLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName")%>'></asp:Label>
                                                                                        </td>
                                                                                        <td width="20%" align="center">
                                                                                            <asp:Label ID="lbBirthday" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Birthday")%>'></asp:Label>
                                                                                        </td>
                                                                                        <td width="25%" align="center">
                                                                                            <asp:Label ID="lbPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber")%>'></asp:Label>
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
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <uc12:ContactViewControl ID="ContactViewControl1" runat="server" />
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                            <td align="left" class="MailD_stepr">
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
                                                &#8226; &nbsp;Customer Service Staff: Christine Chiang<br>
                                                &#8226; &nbsp;Phone: 1-(888)-288-7528<br>
                                                &#8226; &nbsp;Email: <a href="#" class="d07">cchiang@majestic-vacations.com</a>
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
                                <td height="50" align="left" valign="top">
                                    Thanks again for your purchase. We're looking forward to going places with you!<br>
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
