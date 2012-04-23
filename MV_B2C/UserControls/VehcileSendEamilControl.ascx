<%@ Control Language="C#" AutoEventWireup="true" Codebehind="VehcileSendEamilControl.ascx.cs"
    Inherits="Terms.Web.UserControls.VehcileSendEamilControl" %>
<%@ Register Src="VehcileEmailPriceInfoControl.ascx" TagName="VehcileEmailPriceInfoControl"
    TagPrefix="uc3" %>
<%@ Register Src="VehcileInfoControl.ascx" TagName="VehcileInfoControl" TagPrefix="uc12" %>
<style type="text/css">
#contentX {
          width:920px;
          margin:0 auto;
		  text-align:left;
		  font-size:12px;
		  }
.clear{clear:both; }

.ctlineX{border-bottom:solid 1px #FFFFFF;}
.stepX{margin:5px 0 0 0; padding:3px; font-family:Verdana, Arial, Helvetica, sans-serif; font-size:10px; color:#777; height:16px;}
.stepX ul{margin:0;padding:0;list-style:none;float:right; }
.stepX ul li{float:left; display:block; border-top:solid 3px #ccc; padding:0 4px 0 4px; margin:0 0 0 2px;}
.stepX .stepon{border-top:solid 3px #f85000; color:#f85000;}

td.D_stepX  { background: #FF6110 ; font-size: 16px; color: #FFFFFF; font-family: Arial; font-weight: bold; padding-bottom:7px; padding-top:7px; padding-left:10px; !important} /* ------------?hange Color-------------- */
tr.R_stepwX  { background: #FFFFFF;font-size: 11px; line-height: 18px; font-family:Verdana;}

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

.head01{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.head02{ color:#000000; font-size: 12px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.head03{ color:#FF3300; font-size: 12px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.head04{ color:#CC0000; font-size: 12px; line-height: 16px; font-family: Verdana; font-weight: bold;}
.head05{ color:#CC0000; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.head06{ color:#FF3300; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.head07{ color:#FF3300; font-size: 12px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.head08{ color:#FF6600; font-size: 16px; line-height: 20px; font-family: Arial; font-weight: bold;}
.head09{ color:#FF6600; font-size: 12px; line-height: 20px; font-family: Verdana; font-weight: bold;}
.head10{ color:#FF9900; font-size: 14px; line-height: 20px; font-family: Arial; font-weight: bold;}

/* order review */
.cs{margin:4px 0px 5px 22px; line-height:1.5em;}
.cs a:link, .cs a:visited{color:#0066CC; font-weight:bold}
.cs a:hover{color:#f85000;}

table.T_step0lX   { border-top:solid #FD4C00 1px; border-bottom:solid #FD4C00 1px; border-left:solid #FD4C00 1px; border-right:solid #FD4C00 1px; border: 1; !important} /* ------------?hange Color-------------- */
table.T_step02X   { border-top:solid #999999 1px; border-bottom:solid #999999 1px; border-left:solid #999999 1px; border-right:solid #999999 1px; border: 1;}
table.T_step03X   { border-top:solid #CCCCCC 1px; border-bottom:solid #CCCCCC 1px; border-left:solid #CCCCCC 1px; border-right:solid #CCCCCC 1px; border: 1;}
</style>
<div id="contentX">
    <h1>
        <span id="lblThanksPurchase">Thank you for your purchase <span style="color: #000000;
            font-size: 12px;">( please print this page for your records )</span></span></h1>
    <div class="ctlineX">
        <h3>
            <span id="lblOrderNumber">Your car rental(s) have been reserved</span>:</h3>
        <div class="cs">
            - Order Number:
            <asp:Label ID="lblCaseNumber" runat="server" Text="$OrderNumber"></asp:Label><br />
            - Confirmation number:
            <asp:Label ID="lblCarID" runat="server" Text="$Confirmationnumber"></asp:Label>
        </div>
    </div>
    <div class="ctlineX">
        <table width="920" align="center" border="0" cellpadding="0" cellspacing="0">
            <tbody>
                <tr>
                    <td align="center">
                        <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table class="T_step0lX" align="center" border="0" cellpadding="0" cellspacing="0"
                                            width="100%">
                                            <tbody>
                                                <tr class="R_stepwX">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                            <tbody>
                                                                <tr align="center">
                                                                    <td align="left" class="D_stepX">
                                                                        <span id="OrderPassengerInfoControl1_dlAdult_ctl00_lblAdultTraveler">Car Details</span></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table width="100%" border="0" cellpadding="8" cellspacing="1">
                                                            <tbody>
                                                                <tr class="R_stepwX" align="left">
                                                                    <td>
                                                                        <uc12:VehcileInfoControl ID="VehcileInfoControl1" runat="server" />
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
                            <tbody>
                                <tr>
                                    <td height="15">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table class="T_step0lX" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr class="R_stepwX">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                            <tbody>
                                                                <tr align="center">
                                                                    <td align="left" class="D_stepX">
                                                                        <span id="Span1">Rate Details</span></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <uc3:VehcileEmailPriceInfoControl ID="VehcileEmailPriceInfoControl1" runat="server" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                            <tbody>
                                <tr>
                                    <td height="15">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table class="T_step0lX" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr class="R_stepwX">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                            <tbody>
                                                                <tr align="center">
                                                                    <td align="left" class="D_stepX">
                                                                        <span id="Span2">Driver Details</span></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tbody>
                                                                            <tr align="left">
                                                                                <td valign="top" style="padding: 8px 8px 8px 8px; border-bottom: solid #cccccc 1px;">
                                                                                    <b>Enter driver details below:</b></td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tbody>
                                                                            <tr align="left">
                                                                                <td align="center" valign="top" bgcolor="#F5F5F5" style="padding: 5px 8px 5px 8px;">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr align="left">
                                                                                            <td width="12%">
                                                                                                Title:</td>
                                                                                            <td width="20%">
                                                                                                First Name: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                Middle Name:</td>
                                                                                            <td width="34%">
                                                                                                Last Name: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tbody>
                                                                            <tr align="left">
                                                                                <td align="center" valign="top" bgcolor="#F5F5F5" style="padding: 5px 8px 5px 8px;">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr align="left">
                                                                                            <td width="12%">
                                                                                                <asp:Label ID="lblSex" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:Label ID="lblFrist" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td width="20%">
                                                                                                <asp:Label ID="lblMiddle" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td width="34%">
                                                                                                <asp:Label ID="lblLast" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </tbody>
                            <tbody>
                                <tr>
                                    <td height="15">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table class="T_step0lX" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr class="R_stepwX">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                            <tbody>
                                                                <tr align="center">
                                                                    <td align="left" class="D_stepX">
                                                                        Contact Information</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                        <tbody>
                                                                            <tr align="left">
                                                                                <td align="center" valign="top" style="padding: 15px 8px 15px 8px;">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr align="left">
                                                                                            <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                First Name: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>
                                                                                            </td>
                                                                                            <td width="25%">
                                                                                                <asp:Label ID="lbltxtContactFirst" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                            <td width="25%" align="right">
                                                                                                Middle Name:&nbsp;&nbsp;</td>
                                                                                            <td width="25%">
                                                                                                <asp:Label ID="lbltxtContactMiddle" runat="server" Text=""></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                Last Name: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>
                                                                                            </td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lbltxtContactLast" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td width="25%" align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                Address : <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>
                                                                                            </td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lbltxtAddress1" runat="server" Text=""></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                City: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>&nbsp;</td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lblCity" runat="server" Text=""></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                State: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>&nbsp;</td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lblState" runat="server" Text=""></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                Zip: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>&nbsp;</td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lblZip" runat="server" Text=""></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                Country: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>&nbsp;</td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lblCountry" runat="server" Text=""></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td width="25%" align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                Contact Phone: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>
                                                                                            </td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lblPhone" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr align="left">
                                                                                            <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                Email: <font style="color: #FF3300; font-size: 10px; line-height: 14px; font-family: Verdana;">
                                                                                                </font>&nbsp;</td>
                                                                                            <td colspan="3">
                                                                                                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
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
    <div class="ctlineX">
        <h3>
            <span id="lblServiceContact">Majestic Customer Service:</span></h3>
        <div class="cs">
            &#8226; &nbsp;<asp:Label ID="lblCustomerStaff" runat="server">Customer Service Staff</asp:Label>:
            <asp:Label runat="server" ID="lblSalesName"></asp:Label>
            <br>
            &#8226; &nbsp;<asp:Label ID="Label1" runat="server">Phone</asp:Label>: 1-(888)-288-7528<br>
            &#8226; &nbsp;<asp:Label ID="Label2" runat="server">Email</asp:Label>:
            <asp:Label runat="server" ID="lblSalesEmail"></asp:Label>
        </div>
    </div>
</div>
