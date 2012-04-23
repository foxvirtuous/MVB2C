<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchConditionsErrorMeassageCForm.aspx.cs"
    Inherits="SearchConditionsErrorMeassageCForm" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_step2.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal.js" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal2.js" type="text/javascript"></script>

</head>
<body onload="setArraylistC();">
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
        <input id="cityandairport" type="hidden" value="AH" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div class="searchFormMain">
            <div class="searchFormMain_Content">
                <ol class="searchFormMain_Content_title">
                    <asp:Label ID="label12" runat="server" meta:resourcekey="lblPleaseSearch">Please clarify your search.</asp:Label></ol>
                <div runat="server" id="divIserror" visible="true">
                    <span class="searchFormMain_Content_warn">
                        <div class="searchFormMain_Content_warn_block">
                            !</div>
                        &nbsp;<asp:Label ID="label13" runat="server" meta:resourcekey="lblThereAt">There are no car met your search criteria. Please re-seach,<br>
                                                            or call our experienced Sale Agents at </asp:Label><asp:Label ID="Label15" runat="server"
                                                                Text="Label">1-(888)-288-7528</asp:Label><asp:Label ID="label14" runat="server" meta:resourcekey="lblThankYou">. Thank You!! </asp:Label></span>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        1</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label16" runat="server"
                        meta:resourcekey="lblPackage1">What type of drop off location you need?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_RB">
                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                        <tr align="left">
                            <td width="2%" style="height: 25px">
                                <asp:RadioButton ID="rbtOne" runat="server" Checked="true" GroupName="Search" AutoPostBack="true"
                                    OnCheckedChanged="rbtOne_CheckedChanged" /></td>
                            <td width="46%" style="height: 25px">
                                &nbsp;<asp:Label ID="lblOne" runat="server"> Same Location</asp:Label></td>
                            <td width="2%" style="height: 25px">
                                <asp:RadioButton ID="rbtTwo" runat="server" GroupName="Search" AutoPostBack="true"
                                    OnCheckedChanged="rbtTwo_CheckedChanged" /></td>
                            <td width="50%" style="height: 25px">
                                &nbsp;<asp:Label ID="Label1" runat="server"> Different Location</asp:Label></td>
                        </tr>
                    </table>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        2</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label19" runat="server"
                        meta:resourcekey="lblPackage2">Where and when do you want to travel?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label5" runat="Server" meta:resourcekey="lblCityOrAirport">From (Airport)</asp:Label>:<br />
                        <asp:TextBox ID="txtCarFromFullName" runat="server" autocomplete="off" Style="width: 250px;"></asp:TextBox>
                    </div>
                    <div class="searchFormMain_Content_www" runat="server" id="divTo">
                        <asp:Label ID="Label3" runat="Server" meta:resourcekey="lblCityOrAirport">To (Airport)</asp:Label>:<br />
                        <asp:TextBox ID="txtCarToFullName" runat="server" autocomplete="off" Style="width: 250px;"></asp:TextBox>
                    </div>
                </div>
                <div class="searchFormMain_Content_sel">
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label6" runat="Server">Pick Up</asp:Label>:<br />
                        &nbsp;<uc1:Calendar ID="SearchEngineC1_txtCheckin_h" runat="server" />
                        <asp:DropDownList ID="ddlPickupTime" runat="server">
                            <asp:ListItem Value="0030A">12:30 AM</asp:ListItem>
                            <asp:ListItem Value="0100A">01:00 AM</asp:ListItem>
                            <asp:ListItem Value="0130A">01:30 AM</asp:ListItem>
                            <asp:ListItem Value="0200A">02:00 AM</asp:ListItem>
                            <asp:ListItem Value="0230A">02:30 AM</asp:ListItem>
                            <asp:ListItem Value="0300A">03:00 AM</asp:ListItem>
                            <asp:ListItem Value="0330A">03:30 AM</asp:ListItem>
                            <asp:ListItem Value="0400A">04:00 AM</asp:ListItem>
                            <asp:ListItem Value="0430A">04:30 AM</asp:ListItem>
                            <asp:ListItem Value="0500A">05:00 AM</asp:ListItem>
                            <asp:ListItem Value="0530A">05:30 AM</asp:ListItem>
                            <asp:ListItem Value="0600A">06:00 AM</asp:ListItem>
                            <asp:ListItem Value="0630A">06:30 AM</asp:ListItem>
                            <asp:ListItem Value="0700A">07:00 AM</asp:ListItem>
                            <asp:ListItem Value="0730A">07:30 AM</asp:ListItem>
                            <asp:ListItem Value="0800A">08:00 AM</asp:ListItem>
                            <asp:ListItem Value="0830A">08:30 AM</asp:ListItem>
                            <asp:ListItem Value="0900A">09:00 AM</asp:ListItem>
                            <asp:ListItem Value="0930A">09:30 AM</asp:ListItem>
                            <asp:ListItem Value="1000A">10:00 AM</asp:ListItem>
                            <asp:ListItem Value="1030A">10:30 AM</asp:ListItem>
                            <asp:ListItem Value="1100A">11:00 AM</asp:ListItem>
                            <asp:ListItem Value="1130A">11:30 AM</asp:ListItem>
                            <asp:ListItem Value="1200A" Selected="True">12 Noon</asp:ListItem>
                            <asp:ListItem Value="0030P">12:30 PM</asp:ListItem>
                            <asp:ListItem Value="0100P">01:00 PM</asp:ListItem>
                            <asp:ListItem Value="0130P">01:30 PM</asp:ListItem>
                            <asp:ListItem Value="0200P">02:00 PM</asp:ListItem>
                            <asp:ListItem Value="0230P">02:30 PM</asp:ListItem>
                            <asp:ListItem Value="0300P">03:00 PM</asp:ListItem>
                            <asp:ListItem Value="0330P">03:30 PM</asp:ListItem>
                            <asp:ListItem Value="0400P">04:00 PM</asp:ListItem>
                            <asp:ListItem Value="0430P">04:30 PM</asp:ListItem>
                            <asp:ListItem Value="0500P">05:00 PM</asp:ListItem>
                            <asp:ListItem Value="0530P">05:30 PM</asp:ListItem>
                            <asp:ListItem Value="0600P">06:00 PM</asp:ListItem>
                            <asp:ListItem Value="0630P">06:30 PM</asp:ListItem>
                            <asp:ListItem Value="0700P">07:00 PM</asp:ListItem>
                            <asp:ListItem Value="0730P">07:30 PM</asp:ListItem>
                            <asp:ListItem Value="0800P">08:00 PM</asp:ListItem>
                            <asp:ListItem Value="0830P">08:30 PM</asp:ListItem>
                            <asp:ListItem Value="0900P">09:00 PM</asp:ListItem>
                            <asp:ListItem Value="0930P">09:30 PM</asp:ListItem>
                            <asp:ListItem Value="1000P">10:00 PM</asp:ListItem>
                            <asp:ListItem Value="1030P">10:30 PM</asp:ListItem>
                            <asp:ListItem Value="1100P">11:00 PM</asp:ListItem>
                            <asp:ListItem Value="1130P">11:30 PM</asp:ListItem>
                            <asp:ListItem Value="1200P">12 Midnt</asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:DropDownList ID="ddlPickupTimeType" runat="server">
                            <asp:ListItem Value="A">AM</asp:ListItem>
                            <asp:ListItem Value="P" Selected="True">PM</asp:ListItem>
                        </asp:DropDownList>--%>
                    </div>
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label7" runat="Server">Drop Off</asp:Label>:<br />
                        &nbsp;<uc1:Calendar ID="SearchEngineC1_txtCheckout_h" runat="server" LowerLimitID="SearchEngineC1_txtCheckin_h" />
                        <asp:DropDownList ID="ddlDropoffTime" runat="server">
                            <asp:ListItem Value="0030A">12:30 AM</asp:ListItem>
                            <asp:ListItem Value="0100A">01:00 AM</asp:ListItem>
                            <asp:ListItem Value="0130A">01:30 AM</asp:ListItem>
                            <asp:ListItem Value="0200A">02:00 AM</asp:ListItem>
                            <asp:ListItem Value="0230A">02:30 AM</asp:ListItem>
                            <asp:ListItem Value="0300A">03:00 AM</asp:ListItem>
                            <asp:ListItem Value="0330A">03:30 AM</asp:ListItem>
                            <asp:ListItem Value="0400A">04:00 AM</asp:ListItem>
                            <asp:ListItem Value="0430A">04:30 AM</asp:ListItem>
                            <asp:ListItem Value="0500A">05:00 AM</asp:ListItem>
                            <asp:ListItem Value="0530A">05:30 AM</asp:ListItem>
                            <asp:ListItem Value="0600A">06:00 AM</asp:ListItem>
                            <asp:ListItem Value="0630A">06:30 AM</asp:ListItem>
                            <asp:ListItem Value="0700A">07:00 AM</asp:ListItem>
                            <asp:ListItem Value="0730A">07:30 AM</asp:ListItem>
                            <asp:ListItem Value="0800A">08:00 AM</asp:ListItem>
                            <asp:ListItem Value="0830A">08:30 AM</asp:ListItem>
                            <asp:ListItem Value="0900A">09:00 AM</asp:ListItem>
                            <asp:ListItem Value="0930A">09:30 AM</asp:ListItem>
                            <asp:ListItem Value="1000A">10:00 AM</asp:ListItem>
                            <asp:ListItem Value="1030A">10:30 AM</asp:ListItem>
                            <asp:ListItem Value="1100A">11:00 AM</asp:ListItem>
                            <asp:ListItem Value="1130A">11:30 AM</asp:ListItem>
                            <asp:ListItem Value="1200A" Selected="True">12 Noon</asp:ListItem>
                            <asp:ListItem Value="0030P">12:30 PM</asp:ListItem>
                            <asp:ListItem Value="0100P">01:00 PM</asp:ListItem>
                            <asp:ListItem Value="0130P">01:30 PM</asp:ListItem>
                            <asp:ListItem Value="0200P">02:00 PM</asp:ListItem>
                            <asp:ListItem Value="0230P">02:30 PM</asp:ListItem>
                            <asp:ListItem Value="0300P">03:00 PM</asp:ListItem>
                            <asp:ListItem Value="0330P">03:30 PM</asp:ListItem>
                            <asp:ListItem Value="0400P">04:00 PM</asp:ListItem>
                            <asp:ListItem Value="0430P">04:30 PM</asp:ListItem>
                            <asp:ListItem Value="0500P">05:00 PM</asp:ListItem>
                            <asp:ListItem Value="0530P">05:30 PM</asp:ListItem>
                            <asp:ListItem Value="0600P">06:00 PM</asp:ListItem>
                            <asp:ListItem Value="0630P">06:30 PM</asp:ListItem>
                            <asp:ListItem Value="0700P">07:00 PM</asp:ListItem>
                            <asp:ListItem Value="0730P">07:30 PM</asp:ListItem>
                            <asp:ListItem Value="0800P">08:00 PM</asp:ListItem>
                            <asp:ListItem Value="0830P">08:30 PM</asp:ListItem>
                            <asp:ListItem Value="0900P">09:00 PM</asp:ListItem>
                            <asp:ListItem Value="0930P">09:30 PM</asp:ListItem>
                            <asp:ListItem Value="1000P">10:00 PM</asp:ListItem>
                            <asp:ListItem Value="1030P">10:30 PM</asp:ListItem>
                            <asp:ListItem Value="1100P">11:00 PM</asp:ListItem>
                            <asp:ListItem Value="1130P">11:30 PM</asp:ListItem>
                            <asp:ListItem Value="1200P">12 Midnt</asp:ListItem>
                        </asp:DropDownList>
                        <%--<asp:DropDownList ID="ddlDropoffTimeType" runat="server">
                            <asp:ListItem Value="A">AM</asp:ListItem>
                            <asp:ListItem Value="P" Selected="True">PM</asp:ListItem>
                        </asp:DropDownList>--%>
                    </div>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        3</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label20" runat="server"
                        meta:resourcekey="lblPackage3">Do you have car type preference?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label4" runat="Server">Car Type:</asp:Label>
                        <asp:DropDownList ID="ddlCarType" runat="server">
                            <asp:ListItem Value="0" Selected="True">No Preference</asp:ListItem>
                            <asp:ListItem Value="3">Economy</asp:ListItem>
                            <asp:ListItem Value="4">Compact</asp:ListItem>
                            <asp:ListItem Value="5">Midsize</asp:ListItem>
                            <asp:ListItem Value="7">Standard</asp:ListItem>
                            <asp:ListItem Value="8">Full Size</asp:ListItem>
                            <asp:ListItem Value="10">Premium</asp:ListItem>
                            <asp:ListItem Value="9">Luxury</asp:ListItem>
                            <asp:ListItem Value="97">Convertible</asp:ListItem>
                            <asp:ListItem Value="98">Minivan</asp:ListItem>
                            <asp:ListItem Value="99">SUV</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div>
                    <asp:Button ID="btnSearch_AH" CssClass="search_btn" Text="Search" runat="server"
                        Style="cursor: hand" OnClick="btnSearch_AH_Click" />
                </div>
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Visible="False"></asp:Label>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
