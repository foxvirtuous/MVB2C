<%@ Page Language="C#" AutoEventWireup="true" Codebehind="VehcileSuccForm.aspx.cs"
    Inherits="VehcileSuccForm" %>

<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc10" %>
<%@ Register Src="../../UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/VehcileInfoViewControl.ascx" TagName="VehcileInfoViewControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/VehcileInfoALLControl.ascx" TagName="VehcileInfoALLControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/VehcileInfoViewControl.ascx" TagName="VehcileInfoViewControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/VehcilePriceInfoControl.ascx" TagName="VehcilePriceInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/VehcileInfoControl.ascx" TagName="VehcileInfoControl"
    TagPrefix="uc12" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new_Car.css"%>" rel="stylesheet"
        type="text/css" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="content">
            <div class="step">
                <span id="StatesControl1_lblUL">
                    <div class="step IBE_T_font_11" align="right">
                        <uc10:NavigationControl ID="NavigationControl1" runat="server" />
                    </div>
                </span>
            </div>
            <h1>
                <span id="lblThanksPurchase">Thank you for your purchase <span style="color: #000000;
                    font-size: 12px;">( please print this page for your records )</span></span></h1>
            <div class="ctline">
                <h3>
                    <span id="lblOrderNumber">Your car rental(s) have been reserved</span>:</h3>
                <div class="cs">
                    - Order Number:
                    <asp:Label ID="lblCaseNumber" runat="server" Text="Label"></asp:Label><br />
                    - Confirmation number:
                    <asp:Label ID="lblCarID" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="ctline">
                <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                    <tbody>
                        <tr>
                            <td height="15">
                            </td>
                        </tr>
                    </tbody>
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
                                <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                    <tbody>
                                        <tr class="R_stepw">
                                            <td>
                                                <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                    <tbody>
                                                        <tr align="center">
                                                            <td align="left" class="D_step">
                                                                <span id="Span1">Rate Details</span></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <uc9:VehcilePriceInfoControl ID="VehcilePriceInfoControl1" runat="server" />
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
            </div>
            <div class="ctline">
                <h3>
                    <span id="lblServiceContact">Majestic Customer Service:</span></h3>
                <div class="cs">
                    &#8226; &nbsp;<asp:Label ID="lblCustomerStaff" runat="server" >Customer Service Staff</asp:Label>:
                    <asp:Label runat="server" ID="lblSalesName"></asp:Label>
                    <br>
                    &#8226; &nbsp;<asp:Label ID="lblPhone" runat="server" >Phone</asp:Label>:
                    1-(888)-288-7528<br>
                    &#8226; &nbsp;<asp:Label ID="lblEmail" runat="server" >Email</asp:Label>:
                    <asp:Label runat="server" ID="lblSalesEmail"></asp:Label>
                </div>
            </div>
            <div class="btn">
                <asp:Button ID="ibtnSubmit" runat="server" Text="Homepage" CssClass="search_btn05"
                    Style="border-right-width: 0px; border-top-width: 0px; border-bottom-width: 0px;
                    border-left-width: 0px; cursor: pointer" OnClick="ibtnSubmit_Click" />
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
