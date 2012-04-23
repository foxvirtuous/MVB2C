<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageSearchResultForm" Codebehind="PackageSearchResultForm.aspx.cs" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc8" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/PackageLeftSelect.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/ShowPackageHotelDetails.ascx" TagName="ShowPackageHotelDetails"
    TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/PackageFlightHeaderControl.ascx" TagName="PackageFlightHeaderControl"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/DefaultFlightDetails.ascx" TagName="DefaultFlightDetails"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/RemarkAndCall.ascx" TagName="RemarkAndCall" TagPrefix="uc8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel
        package,Cheap Tours,Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
     <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
</head>
<body><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div id="content">
            <div id="subcontent_r">
                <div class="refine">
                    <uc5:PackageLeftSelect ID="PackageLeftSelect1" runat="server"></uc5:PackageLeftSelect>
                    <uc7:ChangeTravelers ID="ChangeTravelers1" runat="server" />
                </div>
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc8:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        <asp:Label ID="lblSelectHotel" runat="server" meta:resourcekey="lblSelectHotel">Select your hotel</asp:Label></h1>
                    <asp:Label ID="Label1" runat="server" meta:resourcekey="lblViewHotel">View the hotel options below. Use the Select button to make your choice.</asp:Label>
                    <div>
                        <div class="base">
                            <div>
                                &nbsp;<uc1:PackageFlightHeaderControl ID="FlightHeader2" runat="server" />
                            </div>
                        </div>
                        <uc2:DefaultFlightDetails ID="DefaultFlightDetails1" runat="server" />
                    </div>
                    <div align="right" class="base" visible="false" runat="server" id="divReturn">
                        <img src="../../images/v1/arrow_right.gif" width="11" height="11" />
                        <asp:LinkButton ID="hotelSelect" runat="server" OnClick="LinkButton1_Click" meta:resourcekey="lblReturnPage">Return to the package details page</asp:LinkButton>
                        <%--<asp:HyperLink ID="hotelSelect" NavigateUrl="~/Page/Package/PackageSearchResult2dForm.aspx?Return=y" runat="server">Return to the package details page</asp:HyperLink>--%>
                        &nbsp;
                    </div>
                    <div id="Div1">
                        <div id="hotel">
                            <uc4:ShowPackageHotelDetails ID="ShowPackageHotelDetails1" runat="server" />
                        </div>
                    </div>
                    <div id="subcontent_l_r">
                        <uc8:RemarkAndCall ID="RemarkAndCall1" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
