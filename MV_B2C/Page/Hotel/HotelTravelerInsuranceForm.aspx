<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="HotelTravelerInsuranceForm" Codebehind="HotelTravelerInsuranceForm.aspx.cs" %>

<%@ Register Src="../../UserControls/InsuranceControl.ascx" TagName="InsuranceControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearchControl"
    TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelersControl"
    TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_new.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div id="content">
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc9:NavigationControl ID="cnlNavigationControl" runat="server" />
                    </div>
                    <h1>
                        Complement the Information of Insurance
                    </h1>
                    You choosed &quot;buy insurance for this trip&quot;, and now we need more information
                    of travelers.
                    <div>
                        <h3>
                            Enter More Traveler Information
                        </h3>
                        <uc3:InsuranceControl id="InsuranceControl1" runat="server"></uc3:InsuranceControl>
                    </div>
                    <div class="btn">
                        Please confirm all of the information is correct, then click
                        <asp:ImageButton ID="ibtnSubmit" runat="server" idth="143" Height="33" border="0"
                            align="absmiddle" ImageUrl="../../images/v1/btn_submit.gif" ValidationGroup="PackageCreditForm"
                            OnClick="ibtnSubmit_Click" /></div>
                </div>
            </div>
            <p class="clear">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
