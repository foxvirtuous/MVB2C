<%@ Page Language="C#" AutoEventWireup="true" Codebehind="VehcileInfoViewForm.aspx.cs"
    Inherits="VehcileInfoViewForm" %>

<%@ Register Src="../../UserControls/VehcileAttachmentInfoControl.ascx" TagName="VehcileAttachmentInfoControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/VehcileInfoViewControl.ascx" TagName="VehcileInfoViewControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/VehcilePriceInfoControl.ascx" TagName="VehcilePriceInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new_Car.css"%>" rel="stylesheet"
        type="text/css" />        
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>    
    <script src="../../CommJs/Mvcal.js" type="text/javascript"></script>
    <script src="../../CommJs/Mvcal2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="920" align="center" border="0" cellpadding="0" cellspacing="0">
            <tbody>
                <tr>
                    <td align="center">
                        <table class="step" width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td style="width: 920px;" valign="top" align="right" height="25">
                                        <uc3:NavigationControl ID="NavigationControl1" runat="server" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr class="R_stepw">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                            <tbody>
                                                                <tr align="center">
                                                                    <td align="left" class="D_step">
                                                                        <span id="OrderPassengerInfoControl1_dlAdult_ctl00_lblAdultTraveler">Car Details</span></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table width="100%" border="0" cellpadding="8" cellspacing="1">
                                                            <tbody>
                                                                <tr class="R_stepw" align="left">
                                                                    <td>
                                                                        <uc7:VehcileInfoViewControl ID="VehcileInfoViewControl1" runat="server" />
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
                                        <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr class="R_stepw">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                            <tbody>
                                                                <tr align="center">
                                                                    <td align="left" class="D_step">
                                                                        <span id="Span1">Optional Car Equipment</span> (Optional equipment available for this rental, chose up to 5 additional items)</td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <%--<table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                            <tbody>
                                                                <tr align="left">
                                                                    <td valign="top" bgcolor="#F5F5F5" style="padding: 8px 8px 8px 8px;">
                                                                        <b>Equipments</b></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>--%>
                                                        <table width="100%" border="0" cellpadding="8" cellspacing="1">
                                                            <tbody>
                                                                <tr class="R_stepw" align="left">
                                                                    <td>
                                                                        <uc6:VehcileAttachmentInfoControl ID="VehcileAttachmentInfoControl1" runat="server" />
                                                                    </td>
                                                                </tr>
                                                                <tr class="R_stepw" align=center>
                                                                    <td bgcolor="#F5F5F5" style="color: red" align=center>
                                                                        
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
                                        <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr class="R_stepw">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                            <tbody>
                                                                <tr align="center">
                                                                    <td align="left" class="D_step">
                                                                        <span id="Span2">Rate Details</span></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <uc8:VehcilePriceInfoControl ID="VehcilePriceInfoControl1" runat="server" />
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
                                        <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                            <tbody>
                                                <tr class="R_stepw">
                                                    <td>
                                                        <table width="100%" border="0" cellpadding="8" cellspacing="1">
                                                            <tbody>
                                                                <tr class="R_stepw" align="left">
                                                                    <td bgcolor="#F5F5F5">
                                                                        Total price is based on information available at the time of booking. Charges for
                                                                        optional services, such as fuel and insurance waivers, etc. are not included. Additional
                                                                        charges may apply for optional equipment requested and confirmed. Currency conversions
                                                                        are based on today's exchange rates, and may vary at the time of rental.
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
                        <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                            <tbody>
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass="search_btn02" style="cursor: pointer" OnClick="btnContinue_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnBack" runat="server" Text="Back" CssClass="search_btn02" style="cursor: pointer" OnClick="btnBack_Click"/>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                <td height=10px>                
                </td>
                </tr>
            </tbody>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
