<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false"
    Inherits="HotelSelectForm" Codebehind="HotelSelectForm.aspx.cs" %>
<%@ Register Src="../../UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearchControl"
    TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelersControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/RemarkAndCall.ascx" TagName="RemarkAndCall"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/HotelInfoControl.ascx" TagName="HotelInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/HotelDetailedInformationListControl.ascx"
    TagName="HotelDetailedInformationListControl" TagPrefix="uc10" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <div id="content">
            <div id="subcontent_r">
                <uc3:HotelOnlySearchControl ID="HotelOnlySearchControl1" runat="server" />
                <uc6:ChangeTravelersControl ID="ChangeTravelersControl1" runat="server" />
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc7:NavigationControl ID="NavigationControl1" runat="server" />
                    </div>
                    <h1>
                        Select your hotel</h1>
                    View the hotel options below. Use the Select button to make your choice.
                    <div>
                        <div class="base">
                            <uc9:HotelInfoControl ID="HotelInfoControl1" runat="server" />
                        </div>
                    </div>
                    <div align=right class="base" visible=false runat=server id=divReturn>
                        <img src="../../images/v1/arrow_right.gif" width="11" height="11" />
                                <asp:HyperLink ID="hotelSelect" NavigateUrl="~/Page/Hotel/HotelViewForm.aspx" runat="server">Return to the hotel details page</asp:HyperLink>&nbsp;
                        </div>
                    <div id="hotel">
                        <uc10:HotelDetailedInformationListControl ID="HotelDetailedInformationListControl1"
                            runat="server" />
                    </div>
                </div>
                <div id="subcontent_l_r">
                    <uc8:RemarkAndCall ID="RemarkAndCall1" runat="server" />
                </div>
            </div>
            <p class="clear">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
