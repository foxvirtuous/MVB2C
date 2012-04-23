<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TravelersContactInformation.aspx.cs"
    Inherits="Terms.Web.Page.Package2.TravelersContactInformation" %>

<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc10" %>
<%@ Register Src="../../UserControls/PHContactInfoControl.ascx" TagName="PHContactInfoControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/HotelOrderPassengerInfoControl.ascx" TagName="HotelOrderPassengerInfoControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/PriceInfoControl.ascx" TagName="PriceInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/PKGSelectedHotelsControl.ascx" TagName="PKGSelectedHotelsControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/PKGSelectedFlightControl.ascx" TagName="PKGSelectedFlightControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../../css/global.css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <div class="IBE_package_main">
            <div class="IBE_package_Dstep" align="right">
                <uc10:NavigationControl ID="NavigationControl1" runat="server" />
            </div>
            <div  class="IBE_package_main_content" style="width: 920px; float: left;">
                <div class="IBE_GrayDIV_Right_travelContact_step4 IBE_T_font_11">
                    <div class="IBE_package_SearchCondition_D_title_step4">
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblYourOrderSummary">Your Order Summary</asp:Label></div>
                    <table class="IBE_package_SearchCondition_T_step03" border="0" cellpadding="8" cellspacing="1"
                        width="100%">
                        <tbody>
                            <tr class="IBE_package_SearchCondition_R_stepw">
                                <td align="left" width="50%">
                                    
                                                <div style="margin-bottom:10px;"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblFrom">From</asp:Label>&nbsp;<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblFrom" runat="server"></asp:Label></font>
                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblTo">to</asp:Label> <font class="IBE_package_SearchCondition_f06">
                                                    <asp:Label ID="lblTo" runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblDepartDate">Depart Date</asp:Label>:<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblDepartDate"
                                                    runat="server"></asp:Label></font>&nbsp;&nbsp;&nbsp;&nbsp; 
                                                <asp:Label ID="Label5" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:<font class="IBE_package_SearchCondition_f06"><asp:Label ID="lblReturnDate"
                                                    runat="server"></asp:Label></font><br />
                                                  <asp:Label ID="lblRoomsAndPassengers" runat="server"></asp:Label></div>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label6" runat="server" meta:resourcekey="lblCurrentlySelectedFlights">Currently Selected Flights</asp:Label></div>
                                                    <uc3:PKGSelectedFlightControl ID="PKGSelectedFlightControl1" runat="server"></uc3:PKGSelectedFlightControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblCurrentlySelectedHotels">Currently Selected Hotels</asp:Label></div>
                                                    <uc6:PKGSelectedHotelsControl ID="PKGSelectedHotelsControl1" runat="server"></uc6:PKGSelectedHotelsControl>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="IBE_package_SearchCondition_T_step04">
                                        <uc7:PriceInfoControl ID="PriceInfoControl1" runat="server" />
                                        &nbsp;</div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <div class="IBE_package_step">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <span class="left">&nbsp;<asp:Label ID="Label8" runat="server" meta:resourcekey="lblEnterTraveler">Enter Traveler Information</asp:Label> </span>
                </div>
                <div class="IBE_YellowDIV_Right_travelContact_step4">
                    <div class="IBE_YellowDIV_Right_inSide1_travelContact_step4">
                        <div class="IBE_YellowDIV_Right_title">
                            <span class="right"><span class="Required_t01">*</span> = <asp:Label ID="Label9" runat="server" meta:resourcekey="lblRequired">Required</asp:Label></span>
                            </div>
                            <uc8:HotelOrderPassengerInfoControl ID="HotelOrderPassengerInfoControl1" runat="server" />
                        </div>
                        <%--<div class="IBE_package_step4_TravelInfo_ContactInfo_title" visible="false">
                            Transportation Information</div>
                        <table class="IBE_T_step03" width="100%" border="0" cellpadding="3" cellspacing="1" visible="false">
                            <tbody>
                                <tr class="IBE_R_stepw">
                                    <td class="IBE_package_step4_TravelInfo_ContactInfo_title_sub" colspan="2">
                                        Pick Up Information</td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td width="20%">
                                        <span class="Required_t01">*</span> Arriving From:</td>
                                    <td>
                                        <input type="text" />
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Flight Number and Airline code:
                                    </td>
                                    <td>
                                        <input type="text" />
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Estimated Time of Arrival:
                                    </td>
                                    <td>
                                        <input type="text" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="IBE_T_step03" width="100%" border="0" cellpadding="3" cellspacing="1" visible="false">
                            <tbody>
                                <tr class="IBE_R_stepw">
                                    <td class="IBE_package_step4_TravelInfo_ContactInfo_title_sub" colspan="2">
                                        Drop Off Information</td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td width="20%">
                                        <span class="Required_t01">*</span> Hotel Address:</td>
                                    <td>
                                        <input type="text" style="width: 500px;" />
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> City:
                                    </td>
                                    <td>
                                        <input type="text" />
                                        &nbsp;&nbsp;Country or Area:
                                        <input type="text" />
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Zip Code:</td>
                                    <td>
                                        <input type="text" />
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        <span class="Required_t01">*</span> Phone Number:</td>
                                    <td>
                                        <input type="text" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>--%>
                    </div>
                </div>
                <div class="IBE_package_step">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <span class="left">&nbsp;<asp:Label ID="Label10" runat="server" meta:resourcekey="lblEnterContact">Enter Contact Information</asp:Label> </span>
                </div>
                <div class="IBE_YellowDIV_Right_travelContact_step4">
                    <div class="IBE_YellowDIV_Right_inSide1_travelContact_step4">
                        <div class="IBE_package_step4_TravelInfo_ContactInfo_title">
                            <asp:Label ID="Label11" runat="server" meta:resourcekey="lblContact">Contact Information</asp:Label></div>
                        
                            <uc9:PHContactInfoControl ID="PHContactInfoControl1" runat="server" />
                       
                    </div>
                </div>
                <div runat="server" id="divInsurance" visible="false">
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label12" runat="server" meta:resourcekey="lblTravelInsurance">Travel Insurance</asp:Label></span>
                    </div>
                    <div class="IBE_package_remarks_travelContact">
                        <div class="IBE_package_Travel_Insurance">
                            The travel insurance includes:
                            <ul>
                                <li>&#8226; &nbsp;Trip Cancellation and Trip Interruption (up to total trip cost) for
                                    covered reasons including injury, illness and death</li>
                                <li>&#8226; &nbsp;Travel Delay (up to $500 per person) for covered reasons</li>
                                <li>&#8226; &nbsp;Medical expenses (up to $10,000) and evacuation (up to $25,000)</li>
                                <li>&#8226; &nbsp;Lost/stolen baggage (up to $1,500) and baggage delay (up to $500)</li>
                                <li>&#8226; &nbsp;Flight accident protection (up to $50,000)</li>
                                <li>&#8226; &nbsp;Emergency assistance (24-hour support)</li>
                            </ul>
                            &#8226; &nbsp;<asp:Label ID="lblInsuranceName" runat="server" Text=""></asp:Label><br>
                            &#8226; &nbsp;<asp:Label ID="lblInsuranceTotal" runat="server" Text=""></asp:Label><br>
                            &#8226; &nbsp;<asp:HyperLink ID="hlInsuranceDetails" runat="server" meta:resourcekey="hlDetails">Details</asp:HyperLink><br>
                            <div style="margin-top: 3px; color: #ff0000;" align="right">
                                <asp:CheckBox ID="chkInsurance" runat="server" Text="Buy insurance for this tirp " />
                            </div>
                        </div>
                    </div>
                    
                </div>
                <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label13" runat="server" meta:resourcekey="lblOther">Other Remark for Your Trip</asp:Label></span>
                    </div>
                    <div class="IBE_package_remarks_travelContact">
                        <textarea id="txtRemark" style="width: 896px; height: 70px;" runat="server"></textarea>
                    </div>
                <div class="IBE_DIV" style="text-align: right; margin-top:10px; margin-bottom:20px;">
                    <span class="IBE_t10"><asp:Label ID="Label14" runat="server" meta:resourcekey="lblPlease">Please confirm all of the information is correct, then click</asp:Label></span>
                    &nbsp;
                    <asp:Button ID="ibtnSubmit" runat="server" Width="100"  CssClass="IBE_search_btn02" ValidationGroup="PackageCreditForm" Text="Submit"
                        OnClick="ibtnSubmit_Click" meta:resourcekey="btnSubmit" />
                </div>
                <uc2:FooterP ID="Footer1" runat="server" />
            </div>
        
        
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
