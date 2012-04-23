<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchResultForm.aspx.cs"
    Inherits="SearchResultForm" EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/HTLInfoControl.ascx" TagName="HotelInfoControl"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/HTLDetailedInformationListControl.ascx" TagName="HotelDetailedInformationListControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearchControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelersControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="Navigation" TagPrefix="uc8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

</head>
<body onload="SetRepeatHotel();">
    <form id="form1" runat="server">
        <input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="" name="DefaultTab" runat="server" /><asp:Button
            Text="" Width="0" runat="server" ID="btnSelect" OnClick="btnSelect_Click" TabIndex="0"
            Style="display: none" /><input id="FocusIndex" type="hidden" value="" runat="server" />
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div id="hpContainer" class="TableWidth1" align="center">
            <div id="ualbody" style="float: left;">
                <table cellpadding="0" cellspacing="0" id="ualbodyTable" width="100%">
                    <tr>
                        <td colspan="2" height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                            <uc8:Navigation ID="Navigation1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" height="5px">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" width="20%">
                            <!-- leftcol.jsp | begin -->
                            <uc3:HotelOnlySearchControl ID="HotelOnlySearchControl1" runat="server" />
                            <!-- leftcol.jsp | end -->
                        </td>
                        <td align="left" valign="top" id="bodyCol3">
                            <!-- main begin-->
                            <uc2:HotelInfoControl ID="HotelInfoControl1" runat="server" />
                            <div id="hotel">
                                <uc7:HotelDetailedInformationListControl ID="HotelDetailedInformationListControl1"
                                    runat="server" />
                            </div>
                            <!-- mian end-->
                        </td>
                    </tr>
                    <tr>
                        <td height="1">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- footer.jsp | begin -->
        <uc2:Footer ID="Footer1" runat="server" />
        <!-- footer.jsp | end -->

        <script language="javascript" type="text/javascript">
        history.go(1);
        </script>

    </form>
</body>
</html>
