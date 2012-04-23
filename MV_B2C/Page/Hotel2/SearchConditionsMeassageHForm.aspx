<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchConditionsMeassageHForm.aspx.cs"
    Inherits="SearchConditionsMeassageHForm" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
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
<body onload="setArraylistH();">
    <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <input id="cityandairport" type="hidden" value="A" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" OnLoad="Header1_Load" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div class="searchFormMain">
            <div class="searchFormMain_Content">
                <ol class="searchFormMain_Content_title">
                    <asp:Label ID="label2" runat="server" meta:resourcekey="lblPleaseSearch">Please clarify your search.</asp:Label></ol>
                <div runat="server" visible="true" id="divIserror">
                    <span class="searchFormMain_Content_warn">
                        <div class="searchFormMain_Content_warn_block">
                            !</div>
                        &nbsp;
                        <asp:Label ID="label3" runat="server" meta:resourcekey="lblThereAt">There are no hotel met your search criteria. Please re-seach,<br>
                                                            or call our experienced Sale Agents at </asp:Label><asp:Label ID="label5" runat="server">1-(888)-288-7528</asp:Label><asp:Label
                                                                ID="label4" runat="server" meta:resourcekey="lblThankYou">. Thank You!! </asp:Label></span></div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        1</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label6" runat="server"
                        meta:resourcekey="lblHotel1">Where is your destination?</asp:Label></span>
                </div>
                <div id="div_1" runat="server" visible="false">
                    <span class="searchFormMain_Content_warn">
                        <div class="searchFormMain_Content_warn_block">
                            !</div>
                        &nbsp;
                        <asp:Label ID="lblError1" runat="Server"></asp:Label></span></div>
                <div class="searchFormMain_Content_sel">
                    <asp:Label ID="lblCountry" runat="Server" meta:resourcekey="lblCountry">Destination: (e.g. an City Name, City Code, Airport Code)</asp:Label>
                    <br />
                    <asp:TextBox ID="txtFullName" runat="server" ValidationGroup="HotelOnlySearch" autocomplete="off"
                        CssClass="searchFormMain_input" Width="250px">
                    </asp:TextBox>
                    <asp:TextBox ID="txtName" runat="server" Visible="false" ValidationGroup="HotelOnlySearch"></asp:TextBox>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        2</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label7" runat="server"
                        meta:resourcekey="lblHotel2">When do you want to travel?</asp:Label></span>
                </div>
                <div id="div_2" runat="server" visible="false">
                    <span class="searchFormMain_Content_warn">
                        <div class="searchFormMain_Content_warn_block">
                            !</div>
                        &nbsp;
                        <asp:Label ID="lblError2" runat="Server"></asp:Label></span></div>
                <div class="searchFormMain_Content_ww">
                    <table width="300">
                        <tr>
                            <td width="20%">
                                <asp:Label ID="lblDepartureDate" runat="server" meta:resourcekey="lblCheckin">Check-in</asp:Label>:</td>
                            <td>
                                <uc7:Calendar ID="txtCheckin_h" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="searchFormMain_Content_ww">
                    <table width="300">
                        <tr>
                            <td width="20%">
                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCheckout">Check-out</asp:Label>:</td>
                            <td>
                                <uc7:Calendar ID="txtCheckout_h" runat="server" LowerLimitID="txtCheckin_h" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        3</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label8" runat="server"
                        meta:resourcekey="lblHotel3">Who is going on this trip?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <uc4:TravelerChange ID="TravelerChange1" runat="server"></uc4:TravelerChange>
                </div>
                <div style="width: 100%; float: left; text-align: right;">
                    <asp:Button ID="btnSearch_h" CssClass="search_btn" Text="Search" runat="server" ValidationGroup="HotelOnlySearch"
                        meta:resourcekey="btnSearch" Style="cursor: hand; background: url(../../images/index/btn_bg.gif)"
                        OnClick="btnSearch_h_Click" />
                </div>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
