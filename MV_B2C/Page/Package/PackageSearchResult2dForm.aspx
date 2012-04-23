<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageSearchResult2dForm" EnableEventValidation="false" Codebehind="PackageSearchResult2dForm.aspx.cs" %>

<%@ Register Src="../../UserControls/SearchTransportationControl.ascx" TagName="SearchTransportationControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/UserLogin.ascx" TagName="UserLogin" TagPrefix="uc10" %>
<%@ Register Src="~/UserControls/ShowPackageHotels.ascx" TagName="ShowPackageHotels"
    TagPrefix="uc9" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/PackageLeftSelect.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc5" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/HotelNewSearchTwoControl.ascx" TagName="HotelNewSearchTwoControl"
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
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

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
</head>
<body><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <input id="CurrentStateOfNewHotel" type="hidden" value="none" name="CurrentStateOfNewHotel"
            runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="content">
            <div id="subcontent_r">
                <uc5:PackageLeftSelect ID="PackageLeftSelect1" runat="server" />
                <br />
                <uc6:ChangeTravelers ID="ChangeTravelers1" runat="server" />
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc8:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlightHotel">Your Flight + Hotel</asp:Label>
                    </h1>
                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblViewHotel">View the hotel options below.You can change Flights, and change hotel options.</asp:Label>
                    <div class="base">
                        <div>
                            <uc1:PackageFlightHeaderControl ID="FlightHeader1" runat="server" />
                            &nbsp;</div>
                    </div>
                    <h3>
                        <img src="../../images/v1/stepnumber-1.gif" align="texttop" />
                        <asp:Label ID="Label3" runat="server" meta:resourcekey="lblFlights">Flights</asp:Label></h3>
                    <div class="getFlight">
                        <uc2:DefaultFlightDetails ID="DefaultFlightDetails1" runat="server" />
                        &nbsp;</div>
                    <div id="hotel">
                        <h3>
                            <img src="../../images/v1/stepnumber-2.gif" align="absmiddle" />
                            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblHotels">Hotels</asp:Label></h3>
                                <div class="ShowHotel">
                                    &nbsp;<uc9:ShowPackageHotels ID="ShowPackageHotels1" runat="server"></uc9:ShowPackageHotels>
                                </div>
                    </div>
                    <div class="addmore">
                        <div align="right">
                            <img src="../../images/v1/arrow_right.gif" width="11" height="11" />
                            <%--<input type="button" onclick="ShowHideAddNewHotel()" value="Add more hotel for this package"
                                class="hidenbtn" style="cursor: hand" />--%>

                             <a href="#a" name="a" onclick= "ShowHideAddNewHotel()"><asp:Label runat="server" class="hidenbtn" style="cursor: hand"  ID="lblAddMore" meta:resourcekey="lblAddMore">Add more hotel for this package</asp:Label></a>
                            
                        </div>
                        <div class="clear" id="divAddNewHotel" style="display: none">
                            <uc4:HotelNewSearchTwoControl ID="HotelNewSearchTwo1" runat="server" />
                            &nbsp;</div>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-3.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label12" runat="server" meta:resourcekey="lblPrice">Price</asp:Label></h3>
                        <%--                        <div class="total" runat="server" id="divSubagent" visible="false">
                            <span class="totalprice_15px">Add Subagent Markup Cost: $
                                <asp:TextBox ID="txtSubagentMarkup" runat="server" Width="50px"></asp:TextBox></span>
                        </div>--%>
                        <asp:UpdatePanel ID="upPriceInfo" runat="server">
                            <ContentTemplate>
                                <asp:PlaceHolder ID="phAgentFlightMarkup" runat="server">
                                    <div visible="false">
                                        <div class="reprice" runat="server" id="divSubagent" visible="false">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                <tr>
                                                    <td class="orglab">
                                                        Add Subagent Markup Cost:
                                                    </td>
                                                    <td align="right" class="orglab">
                                                        $
                                                        <asp:TextBox ID="txtSubagentMarkup" runat="server" Width="50px" AutoPostBack="True"
                                                            OnTextChanged="txtAgentAdultUnitMarkup_TextChanged"></asp:TextBox>
                                                        <asp:Label ID="lblAgentAdultUnitMarkup" runat="server" Text="" Visible="false" />
                                                        <asp:RequiredFieldValidator ID="rfvAgentMarkup" runat="server" Display="None" ErrorMessage="Agent markup should be greater than equal $0."
                                                            ControlToValidate="txtSubagentMarkup">
                                                        </asp:RequiredFieldValidator>
                                                        <asp:CompareValidator ID="cvAgentMarkup" runat="server" Display="None" ErrorMessage="Agent markup should be greater than equal $0."
                                                            ControlToValidate="txtSubagentMarkup" Type="Double" Operator="GreaterThanEqual"
                                                            ValueToCompare="0.00"></asp:CompareValidator>
                                                    </td>
                                        </div>
                                    </div>
                                    <div class="reprice">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                            <tr>
                                                <td class="orglab">
                                                    <asp:Label ID="Label5" runat="server" meta:resourcekey="lblTotal">Total Flight + Hotel</asp:Label>:</td>
                                                <td align="right" class="orglab">
                                                    $<asp:Label ID="lbTotalPrice" runat="server"></asp:Label></td>
                                            </tr>
                                            <%--<tr>
                                    <td>
                                        Fees &amp; Taxes:
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lbInclude" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        per person:
                                    </td>
                                    <td align="right">
                                        $<asp:Label ID="lbAvgPrice" runat="server"></asp:Label></td>
                                </tr>--%>
                                        </table>
                                    </div>
                                </asp:PlaceHolder>
                                <asp:ValidationSummary ID="vsPrice" runat="server" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div runat=server visible=true id='divTransportation'>
                        <h3>
                            <img src="../../images/v1/stepnumber-4.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblGround">Ground Transportation Service</asp:Label>
                        </h3>
                        <div>
                            <uc3:SearchTransportationControl ID="SearchTransportationControl1" runat="server"></uc3:SearchTransportationControl>
                        </div>
                    </div>
                    <div>
                        <h3>
                        <div runat=server id="div4" visible=false>
                        <img src="../../images/v1/stepnumber-4.gif" width="20" height="20" align="texttop" /><asp:Label ID="Label7" runat="server" meta:resourcekey="lblTermsConditions">Terms and Conditions</asp:Label></div>
                        <div runat=server id="div5" visible=true>
                            <img src="../../images/v1/stepnumber-5.gif" width="20" height="20" align="texttop" /><asp:Label ID="Label8" runat="server" meta:resourcekey="lblTermsConditions">Terms and Conditions</asp:Label></div>
                        </h3>
                        <div class="t_c">
                            <asp:Label ID="lbConditons" runat="server"></asp:Label>
                        </div>
                        <asp:CheckBox ID="chkConditions" runat="server" />
                        <span class="orglab"><asp:Label ID="Label9" runat="server" meta:resourcekey="lblAgree">Yes, I agree to the Terms and Conditions above.</asp:Label></span> &nbsp;&nbsp;<br />
                        <div id="divHead" runat="server">
                            <uc10:UserLogin ID="UserLogin1" runat="server" />
                        </div>
                    </div>
                    <div id="divMinStaysMessage" runat="server" visible="false">
                        <br />
                        <span class="orglab"><asp:Label ID="Label10" runat="server" meta:resourcekey="lblMinimunNights">Minimun 5 nights hotel stay is requested.</asp:Label></span>
                        <br />
                    </div>
                    <div id="divLongin" runat="server">
                        <div class="btn" visible="true" id="divSubmit">
                            <asp:Label ID="Label11" runat="server" meta:resourcekey="lblMakeChange">If you don't want to make any more change, please click</asp:Label>
                            <asp:ImageButton ID="btnContinue" runat="server" Width="143" Height="33" ImageUrl="../../images/v1/btn_continue.gif"
                                OnClick="btnContinue_Click2" />
                        </div>
                    </div>
                </div>
            </div>
            <p class="clear">
            </p>
        </div>
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
    <script type="text/javascript">
if (document.getElementById("UserLogin1_txtPassword") != null)
{
        document.getElementById("UserLogin1_txtPassword").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13)
             {
                document.body.focus();
                document.getElementById("UserLogin1_btnLogin").click();
             }
        }}
        if (document.getElementById("UserLogin1_txtUserName") != null)
{
        document.getElementById("UserLogin1_txtUserName").onfocus=function document.onkeydown()
        {
             if   (event.keyCode   ==   13)
             {
                document.body.focus();
                document.getElementById("UserLogin1_btnLogin").click();
             }
        }
        }
 
    </script>
</body>
</html>
