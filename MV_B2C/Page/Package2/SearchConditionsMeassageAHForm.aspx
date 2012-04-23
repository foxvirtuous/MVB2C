<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchConditionsMeassageAHForm.aspx.cs"
    Inherits="SearchConditionsMeassageAHForm" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_step2.css"%>" rel="stylesheet"
        type="text/css" />
    

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal.js" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal2.js" type="text/javascript"></script>

</head>
<body onload="setArraylistAH();">
    <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <input id="cityandairport" type="hidden" value="AH" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
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
                        &nbsp;<asp:Label ID="label13" runat="server" meta:resourcekey="lblThereAt">There are no package met your search criteria. Please re-seach,<br>
                                                            or call our experienced Sale Agents at </asp:Label><asp:Label ID="Label15" runat="server"
                                                                Text="Label">1-(888)-288-7528</asp:Label><asp:Label ID="label14" runat="server" meta:resourcekey="lblThankYou">. Thank You!! </asp:Label></span>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        1</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label16" runat="server"
                        meta:resourcekey="lblPackage1">What type of package do you need?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_RB">
                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                        <tr align="left">
                            <td width="2%" height="25">
                                <input id="radiobutton" name="radiobutton" type="radio" value="radiobutton" checked="checked" /></td>
                            <td width="46%">
                                <asp:Label ID="lblOne" runat="server" meta:resourcekey="lblOne">One Destination</asp:Label></td>
                            <td width="2%">
                                <input name="radiobutton" type="radio" value="radiobutton" onclick="javascript:location.href='<%=SaleWebSuffix%>Page/Package2/PackageSearchTwoDestinations.aspx'" /></td>
                            <td width="50%">
                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblTwo">Two Destinations</asp:Label></td>
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
                    <div id="div_1" runat="server" visible="false">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="lblError1" runat="Server"></asp:Label></span>
                    </div>
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label4" runat="Server" meta:resourcekey="lblFrom">From</asp:Label>&nbsp;
                        <asp:Label ID="Label5" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
                        <asp:TextBox ID="txtFullFrom_AH" runat="server" autocomplete="off" Style="width: 250px;"></asp:TextBox>
                        <asp:TextBox ID="txtFrom_AH" runat="server" Visible="false"></asp:TextBox>
                    </div>
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label2" runat="Server" meta:resourcekey="lblTo">To</asp:Label>&nbsp;
                        <asp:Label ID="Label3" runat="Server" meta:resourcekey="lblCityOrAirport">(City or Airport)</asp:Label>:<br />
                        <asp:TextBox ID="txtFullTo_AH" runat="server" autocomplete="off" Style="width: 250px;"></asp:TextBox>
                        <asp:TextBox ID="txtTo_AH" runat="server" Visible="false"></asp:TextBox>
                    </div>
                    <div id="div_2" runat="server" visible="false">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="lblError2" runat="Server"></asp:Label></span>
                    </div>
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label9" runat="Server" meta:resourcekey="lblDeparture">Depart</asp:Label>:<br />
                        <uc1:Calendar ID="dateDeparture_AH" runat="server" />
                    </div>
                    <div class="searchFormMain_Content_www">
                        <asp:Label ID="Label11" runat="Server" meta:resourcekey="lblReturn">Return</asp:Label>:<br />
                        <uc1:Calendar ID="dateReturn_AH" runat="server" LowerLimitID="dateDeparture_AH" />
                    </div>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        3</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label20" runat="server"
                        meta:resourcekey="lblPackage3">Are your travel plans flexible?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <div>
                        <asp:CheckBox ID="chbFlexible_AH" runat="server" Text="My dates are flexible +/- 1 day"
                            meta:resourcekey="lblFlexible" /></div>
                    <div>
                        <input id="ckbHotel" type="checkbox" runat="server" onclick="ShowHotelCheckDates()" />
                        <asp:Label ID="lblOnly" runat="server" meta:resourcekey="lblOnlyNeed">I only need a hotel for part of my trip.</asp:Label><br />
                    </div>
                    <div style="display: none" id="tdHotelMsg">
                        <asp:Label ID="Label10" runat="server" meta:resourcekey="lblWhenNeedHotelMsg">When do you need a hotel? (Check-in and check-out dates must be within dates of travel.)</asp:Label>
                        <br />
                        <br />
                    </div>
                    <div style="display: none" id="tdHotel">
                        <div class="searchFormMain_Content_www">
                            <asp:Label ID="Label6" runat="Server" meta:resourcekey="lblCheckIn">CheckIn</asp:Label>:<br />
                            <uc1:Calendar ID="CheckIn_AH" runat="server" LowerLimitID="dateDeparture_AH" UpperLimitID="dateReturn_AH"
                                IsLowerRepeatDate="1" />
                        </div>
                        <div class="searchFormMain_Content_www">
                            <asp:Label ID="Label7" runat="Server" meta:resourcekey="lblCheckOut">CheckOut</asp:Label>:<br />
                            <uc1:Calendar ID="CheckOut_AH" runat="server" LowerLimitID="CheckIn_AH" UpperLimitID="dateReturn_AH"
                                IsUpperRepeatDate="1" />
                        </div>
                    </div>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        4</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label21" runat="server"
                        meta:resourcekey="lblPackage4">Who is going on this trip?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <uc4:TravelerChange ID="TravelerChange1" runat="server"></uc4:TravelerChange>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        5</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="Label8" runat="Server"
                        meta:resourcekey="lblAddtional">Addtional options</asp:Label>:</span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <div style="margin-bottom: 6px;">
                        <table width="400">
                            <tr>
                                <td width="30%">
                                    <asp:Label ID="Label17" runat="Server" meta:resourcekey="lblClass">Class</asp:Label>:
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rdoLstCabin_AH" TabIndex="15" runat="server" Width="100%"
                                        CssClass="menu" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="ECONOMY" meta:resourcekey="item1">Economy</asp:ListItem>
                                        <asp:ListItem Value="BUSINESS" meta:resourcekey="item2">Business</asp:ListItem>
                                        <asp:ListItem Value="FIRST" meta:resourcekey="item3">First</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div>
                        <table width="400">
                            <tr>
                                <td width="30%">
                                    <asp:Label ID="Label18" runat="Server" meta:resourcekey="lblAirlineCode">Airline Code</asp:Label>:
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAirline" runat="server" Font-Size="11px">
                                        <asp:ListItem Value="all" Selected="true" meta:resourcekey="aircodeItem1">No Preference</asp:ListItem>
                                        <asp:ListItem Value="AA" meta:resourcekey="aircodeItem2">American Airlines</asp:ListItem>
                                        <asp:ListItem Value="DL" meta:resourcekey="aircodeItem3">Delta Airlines</asp:ListItem>
                                        <asp:ListItem Value="UA" meta:resourcekey="aircodeItem4">United Airlines</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="div_3" runat="server" visible="false">
                    <span class="searchFormMain_Content_warn">
                        <div class="searchFormMain_Content_warn_block">
                            !</div>
                        <asp:Label ID="lblError3" runat="Server"></asp:Label></span></div>
                <div>
                    <asp:Button ID="btnSearch_AH" CssClass="search_btn" Text="Search" runat="server"
                        OnClick="btn_Search_AH_Click" ValidationGroup="Package_Search" meta:resourcekey="btnSearch"
                        Style="cursor: hand" />
                </div>
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red" Visible="true"></asp:Label>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
