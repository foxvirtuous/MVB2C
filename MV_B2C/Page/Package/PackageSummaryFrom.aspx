<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageSummaryFrom"  EnableEventValidation="false" Codebehind="PackageSummaryFrom.aspx.cs" %>

<%@ Register Src="~/UserControls/UserLogin.ascx" TagName="UserLogin" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc8" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/HotelNewSearchTwoControl.ascx" TagName="HotelNewSearchTwoControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/PackageLeftSelect.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers" TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/PackageFlightHeaderControl.ascx" TagName="PackageFlightHeaderControl" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/DefaultFlightDetails.ascx" TagName="DefaultFlightDetails"
    TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/PackageHotelListViewControl.ascx" TagName="PackageHotelListViewControl" TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <link href="~/css/style2.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function ShowHideAddNewHotel()
        {
            if(document.getElementById("divAddNewHotel").style.display == "")
            {
                document.getElementById("divAddNewHotel").style.display = "none";
                document.getElementById("CurrentStateOfNewHotel").value = "none";
            }
            else
            {
                document.getElementById("divAddNewHotel").style.display = "";
                document.getElementById("CurrentStateOfNewHotel").value = "";
            }
        }
        
        function ShowHideAddNewCityModule()
        {
            if(document.getElementById("divAddNewCityModule").style.display == "")
                document.getElementById("divAddNewCityModule").style.display = "none";
            else
                document.getElementById("divAddNewCityModule").style.display = "";
        }
        
        window.onload = function ChangeToCurrentTab()
        {   
            document.getElementById("divAddNewHotel").style.display = document.getElementById("CurrentStateOfNewHotel").value;
        }
    </script>

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
    <link href="~/css/style2.css" rel="stylesheet" type="text/css" />
</head>
<body><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <input id="CurrentStateOfNewHotel" type="hidden" value="none" name="CurrentStateOfNewHotel" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <div id="content">
            <div id="subcontent_r">
                <uc1:PackageLeftSelect ID="PackageLeftSelect1" runat="server" />
                <br />
                <uc2:ChangeTravelers ID="ChangeTravelers1" runat="server" />
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc8:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        Your Flight + Hotel
                    </h1>
                    Check your Flight + Hotel.
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-1.gif" align="texttop" alt=""/>
                            Review the Flight + Hotel You Selected</h3>
                        <div class="base">
                            <uc3:PackageFlightHeaderControl ID="FlightHeader1" runat="server" />
                        </div>
                        <uc4:DefaultFlightDetails ID="DefaultFlightDetails1" runat="server" />
                        <uc5:PackageHotelListViewControl ID="HotelListView1" runat="server"/>
                    </div>
                    <div class="addmore">
                        <div align="right">
                            <img src="../../images/v1/arrow_right.gif" width="11" height="11" alt=""/>
                            <input type="button" onclick="ShowHideAddNewHotel()" value="Add more hotel for this package"
                                class="hidenbtn" />
                        </div>
                        <div class="clear" id="divAddNewHotel" style="display: none">
                            <uc6:HotelNewSearchTwoControl id="HotelNewSearchTwoControl1" runat="server"/>
                            &nbsp;</div>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-2.gif" width="20" height="20" align="texttop" alt=""/>
                            Price</h3>
                        <div class="reprice">
                            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                <tr>
                                    <td class="orglab">
                                        Total Flight + Hotel:</td>
                                    <td align="right" class="orglab">
                                        $<asp:Label ID="lbTotalPrice" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <%--<tr>
                                    <td>
                                        Fees &amp; Taxes:
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lbInculded" runat="server" Text='Inculded'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        per person:
                                    </td>
                                    <td align="right">
                                        $<asp:Label ID="lbAvgPrice" runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-3.gif" width="20" height="20" align="texttop" alt=""/>
                            Terms and Conditions
                        </h3>
                        <div class="t_c">
                            <h4>
                                Package Fare Include:</h4>
                            <ul>
                                <li>Air Transportation: A roundtrip international air ticket is included with the package
                                    price for passengers departing from the U.S.A. as per their confirmation and payment.
                                </li>
                                <li>Hotel Accommodations: Based on 2 adults sharing one room, double occupancy (please
                                    specify single or double beds in your reservation). A customer who travels alone
                                    is required to pay a single supplement rate. </li>
                                <li>Optional Travel Protection Insurance is offered at an additional expense when the
                                    reservation is made or payment is received less than 45 days prior to departure.
                                </li>
                            </ul>
                        </div>
                        <asp:CheckBox ID="chkConditions" runat="server" Text='Yes, I agree to the Terms
                        and Conditions above.' CssClass='orglab' />
                    </div>
                    <div id="divHead" runat="server">
                        <uc7:UserLogin ID="UserLogin1" runat="server" />
                    </div>
                    <div id="divLongin" runat="server">
                        <div class="btn" visible="true" id="divSubmit">
                            If you don't want to make any more change, please click
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/v1/btn_continue.gif"
                                Width="143" Height="33" border="0" align="absmiddle" Visible="true" OnClick="ImageButton1_Click" />
                        </div>
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
