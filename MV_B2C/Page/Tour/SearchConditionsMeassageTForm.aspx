<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" Codebehind="SearchConditionsMeassageTForm.aspx.cs"
    Inherits="SearchConditionsMeassageTForm" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_step2.css"%>" rel="stylesheet"
        type="text/css" />
    

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal.js" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal2.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="cityandairport" type="hidden" value="A" runat="server" />
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div class="searchFormMain">
            <div class="searchFormMain_Content">
                <ol class="searchFormMain_Content_title">
                    <asp:Label ID="label1" runat="server" meta:resourcekey="lblPleaseSearch">Please clarify your search.</asp:Label></ol>
                <span class="searchFormMain_Content_warn">
                    <div class="searchFormMain_Content_warn_block">
                        !</div>
                    &nbsp;<asp:Label ID="label2" runat="server" meta:resourcekey="lblThereAt">There are no tour met your search criteria. Please re-seach,<br>
                                                            or call our experienced Sale Agents at </asp:Label><asp:Label ID="label32" runat="server">1-(888)-288-7528 </asp:Label><asp:Label
                                                                ID="label3" runat="server" meta:resourcekey="lblThankYou">. Thank You!! </asp:Label><asp:Label
                                                                    ID="lblDateErrorMsg" runat="server" Visible="false"></asp:Label></span>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        1</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label4" runat="server"
                        meta:resourcekey="lblTypeOfFligt">Type Of Tour</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_RB">
                    <input id="rdbLandOnly" name="radiobutton" type="radio" value="1" checked runat="server" />
                    <asp:Label ID="lblLand" runat="server" meta:resourcekey="lblLandOnly">Land Only</asp:Label>
                    <input id="rdbAirLand" name="radiobutton" type="radio" value="0" runat="server" visible="false" />
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        1</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="Label5" runat="server"
                        meta:resourcekey="lblTour1">Where is your destination?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <div id="div_1" runat="server" visible="false">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="lblError1" runat="Server"></asp:Label>
                        </span>
                    </div>
                    <table width="400">
                        <tr>
                            <td width="25%">
                                <asp:Label ID="lblRegion" runat="server" meta:resourcekey="lblRegion">Region</asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlArea_T" runat="server" CssClass="search_sle" ValidationGroup="TourOnlySearch"
                                    Width="280px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlArea_T"
                                    Display="Dynamic" meta:resourcekey="lblAreaMsg" ErrorMessage="Please select area."
                                    SetFocusOnError="True" ValidationGroup="TourOnlySearch">
                                </asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    <br />
                    <div id="div_2" runat="server" visible="false">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="lblError2" runat="Server"></asp:Label></span>
                    </div>
                    <table width="400">
                        <tr>
                            <td width="25%">
                                <asp:Label ID="lblCountry" runat="server" meta:resourcekey="lblCountry">Country or Area</asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlCountry_T" runat="server" CssClass="search_sle" ValidationGroup="TourOnlySearch"
                                    Width="280px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCountry_T"
                                    Display="Dynamic" meta:resourcekey="lblCountryMsg" ErrorMessage="Please select country or area."
                                    SetFocusOnError="True" ValidationGroup="TourOnlySearch">
                                </asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                    <br />
                    <div id="div_3" runat="server" visible="false">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="lblError3" runat="Server"></asp:Label></span>
                    </div>
                    <table width="400">
                        <tr>
                            <td width="25%">
                                <asp:Label ID="lblCity" runat="server" meta:resourcekey="lblCity">City</asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlCity_T" runat="server" Width="280px" CssClass="search_sle"
                                    ValidationGroup="TourOnlySearch">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCity_T"
                                    Display="Dynamic" meta:resourcekey="lblCityMsg" ErrorMessage="Please select city."
                                    SetFocusOnError="True" ValidationGroup="TourOnlySearch">
                                </asp:RequiredFieldValidator></td>
                        </tr>
                    </table>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        2</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="Label6" runat="server"
                        meta:resourcekey="lblTour2"> When and how long do you want to travel?</asp:Label></span>
                </div>
                <div id="div_4" runat="server" visible="false">
                    <span class="searchFormMain_Content_warn">
                        <div class="searchFormMain_Content_warn_block">
                            !</div>
                        <asp:Label ID="lblError4" runat="Server"></asp:Label></span>
                </div>
                <div class="searchFormMain_Content_ww">
                    <table width="400">
                        <tr>
                            <td width="25%">
                                <asp:Label ID="lblDepartureDate" runat="server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>:</td>
                            <td>
                                <uc1:Calendar ID="tourDeptCalendar" runat="server" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Label ID="lblMsg" runat="server" ForeColor="Red" meta:resourcekey="lblDataMsg"
                                    Text="Please enter date" Visible="False"></asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="searchFormMain_Content_ww">
                    <table width="400">
                        <tr>
                            <td width="25%">
                                <asp:Label ID="lblDuration" runat="server" meta:resourcekey="lblDuration">Duration</asp:Label>:</td>
                            <td>
                                <asp:DropDownList ID="ddlTravelDate" runat="server" Width="90px" CssClass="search_sle"
                                    ValidationGroup="TourOnlySearch">
                                    <asp:ListItem Value="5" meta:resourcekey="lbl5to10">less than 10 days</asp:ListItem>
                                    <asp:ListItem Value="11" meta:resourcekey="lbl11to15">11 - 15 days</asp:ListItem>
                                    <asp:ListItem Value="15" meta:resourcekey="lbl15">over 15 days</asp:ListItem>
                                    <asp:ListItem Value="16" Selected="true" meta:resourcekey="lblAll">All</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                    </table>
                </div>
                <div>
                    <asp:Button ID="btnSearch_t" CssClass="search_btn" Text="Search" runat="server" Style="cursor: hand"
                        meta:resourcekey="btn_SearchFare" OnClick="btnSearch_t_Click" /></div>
            </div>
            <div align="left">
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
        <ajaxToolkit:CascadingDropDown ID="cddArea" runat="server" TargetControlID="ddlArea_T"
            Category="TourArea" PromptText="Please select a area" LoadingText="[Loading areas...]"
            ServiceMethod="GetDropDownContents" ParentControlID="" meta:resourcekey="CddArea" />
        <ajaxToolkit:CascadingDropDown ID="cddCountry" runat="server" TargetControlID="ddlCountry_T"
            Category="TourCountry" meta:resourcekey="CddCountry" PromptText="Please select a country or area"
            LoadingText="[Loading countries...]" ServiceMethod="GetDropDownContents" ParentControlID="ddlArea_T" />
        <ajaxToolkit:CascadingDropDown ID="cddCity" runat="server" TargetControlID="ddlCity_T"
            Category="TourCity" meta:resourcekey="CddCity" PromptText="Please select a city"
            LoadingText="[Loading cities...]" ServiceMethod="GetDropDownContents" ParentControlID="ddlCountry_T" />
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
