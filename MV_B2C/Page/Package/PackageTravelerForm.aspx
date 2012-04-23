<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageTravelerForm" EnableEventValidation="false" Codebehind="PackageTravelerForm.aspx.cs" %>

<%@ Register Src="../../UserControls/BookingTransportationControl.ascx" TagName="BookingTransportationControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/HotelOrderPassengerInfoControl.ascx" TagName="OrderPassengerInfo"
    TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc10" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/PHContactInfoControl.ascx" TagName="ContactInfo"
    TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/PackageLeftSelect.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/PackageFlightHeaderControl.ascx" TagName="PackageFlightHeaderControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/DefaultFlightDetails.ascx" TagName="DefaultFlightDetails"
    TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/HotelListViewNewControl.ascx" TagName="HotelListViewNewControl"
    TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel
        package,Cheap Tours,Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
    <script language=javascript type="text/javascript">
        function confirmerror(y)
        {            
            if (confirm(y))
            {
                var aaa = document.getElementById("AAA")
               
                aaa.value = "001";
                
                document.getElementById("form1").submit();
            }
            else
            {
                var aaa = document.getElementById("AAA")
                
                aaa.value = "000";
            }            
        }    
    </script>
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
</head>
<body><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" /><input id="AAA" type="hidden" value="" name="AAA" runat=server/>
        <div id="content">
            <%--<div id="subcontent_r">
                <uc1:PackageLeftSelect ID="PackageLeftSelect1" runat="server" />
                <br />
                <uc2:ChangeTravelers ID="ChangeTravelers1" runat="server" />
            </div>--%>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc10:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
                        z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
                        marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
                    </iframe>
                    <h1>
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblTraveler">Enter your traveler information</asp:Label>
                    </h1>
                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblCheckInfo">Please check your Flight and Hotel, then enter your traveler information below.</asp:Label>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-1.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblReviewSelected">Review the Flight + Hotel You Selected</asp:Label></h3>
                        <div class="base">
                            <uc3:PackageFlightHeaderControl ID="FlightHeader1" runat="server" />
                            &nbsp;</div>
                        <div class="getFlight">
                            <uc4:DefaultFlightDetails ID="DefaultFlightDetails1" runat="server" />
                            &nbsp;</div>
                        <div class="getFlight">
                            <uc6:HotelListViewNewControl ID="HotelListView1" runat="server" />
                            &nbsp;</div>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-2.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label4" runat="server" meta:resourcekey="lblEnterTraveler">Enter Traveler Information</asp:Label>
                        </h3>
                        <p>
                            &nbsp;<uc9:OrderPassengerInfo ID="OrderPassengerInfo1" runat="server" />
                        </p>
                    </div><div>
                    <uc7:BookingTransportationControl ID="BookingTransportationControl1" runat="server" />
                    
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-3.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblContactInfo">Contact Information</asp:Label></h3>
                        <uc8:ContactInfo ID="ContactInfo1" runat="server" />
                    </div>
                    <div visible="false" style="display: none" runat="server" id="divInsurance">
                        <h3>
                            <img src="../../images/v1/stepnumber-4.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label6" runat="server" meta:resourcekey="lblTravelInsurance">Travel Insurance</asp:Label>
                        </h3>
                        <div class="t_c">
                            <h4>
                                <asp:Label ID="Label7" runat="server" meta:resourcekey="lblInsuranceInclude">Insurance Include</asp:Label>:</h4>
                            <br>
                            &#8226; &nbsp;<asp:Label ID="lblInsuranceName" runat="server" Text=""></asp:Label><br>
                            &#8226; &nbsp;<asp:Label ID="lblInsuranceTotal" runat="server" Text=""></asp:Label><br>
                            &#8226; &nbsp;<asp:HyperLink ID="hlInsuranceDetails" runat="server" meta:resourcekey="hlDetails">Details</asp:HyperLink><br>
                            <asp:CheckBox ID="chkInsurance" runat="server" Text="Buy insurance for this tirp "
                                CssClass="orglab" />
                        </div>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-5.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label8" runat="server" meta:resourcekey="lblOtherRemark">Other Remark for Your Trip</asp:Label></h3>
                        <textarea id="txtRemark" class="remark" runat="server"></textarea>
                    </div>
                    <div class="btn">
                        <asp:Label ID="Label9" runat="server" meta:resourcekey="lblConfirm">Please confirm all of the information is correct, then click</asp:Label>
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

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
