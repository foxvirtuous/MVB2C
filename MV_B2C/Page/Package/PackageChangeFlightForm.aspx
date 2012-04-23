<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageChangeFlightForm" Codebehind="PackageChangeFlightForm.aspx.cs" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/DefaultFlightDetails.ascx" TagName="DefaultFlightDetails"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ChangeDefaultFlight.ascx" TagName="ChangeDefaultFlight"
    TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/ShowAllFlights.ascx" TagName="ShowAllFlights" TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/PackageLeftSelect.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/FlightHeaderControl.ascx" TagName="FlightHeader"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
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
                <uc1:PackageLeftSelect ID="PackageLeftSelect1" runat="server" />
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc6:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblChangeFlight">Change your flight</asp:Label></h1>
                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblChooseOther">Choose other flights for your packages</asp:Label>.
                    <div>
                        <div class="base">
                            <div>
                                <div class="newprice">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td>
                                                <strong><asp:Label ID="Label3" runat="server" meta:resourcekey="lblTotalFlight">Total Flight and Hotel</asp:Label>: </strong>
                                            </td>
                                            <td>
                                                <strong>
                                                    <asp:Label ID="lbTotalPrice" runat="server"></asp:Label></strong></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblPerPerson">per person</asp:Label>:
                                            </td>
                                            <td>
                                                <asp:Label ID="lbAvgPrice" runat="server"></asp:Label></td>
                                        </tr>
                                    </table>
                                </div>
                                <strong><asp:Label ID="Label5" runat="server" meta:resourcekey="lblBasePackage">Base package (Flight + Hotel) price</asp:Label>:</strong><br />
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblFrom">From</asp:Label> <span class="bluelab">
                                    <asp:Label ID="lbFrom" runat="server" Text="aaaaaaa"></asp:Label></span> to
                                <span class="bluelab">
                                    <asp:Label ID="lbTo" runat="server" Text="bbbbbbb"></asp:Label></span>
                            </div>
                        </div>
                        <div class="getFlight">
                            &nbsp;&nbsp;
                            <uc4:ChangeDefaultFlight ID="ChangeDefaultFlight1" runat="server" />
                        </div>
                    </div>
                    <div id="Flight">
                        <uc5:ShowAllFlights ID="ShowAllFlights1" runat="server"></uc5:ShowAllFlights>
                        &nbsp;</div>
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
