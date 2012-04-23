<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchMoreCityForm.aspx.cs"
    Inherits="SearchMoreCityForm" EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
         <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SaleWebSuffix + MainCssPath + "Hotel.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet" type="text/css" />
     <link href="<%=SaleWebSuffix + MainCssPath + "Global.css"%>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="hpContainer" class="TableWidth1" align="center">
            <div id="ualbody" style="float: left;">
                <table cellpadding="0" cellspacing="0" id="ualbodyTable" width="100%">
                    <tr>
                        <td align="left" valign="top" id="bodyCol3">
                            <!-- main begin-->
                            <div class="MV_hotel_main">
                                <div class="MV_hotel_step">
                                    <div class="MV_hotel_step_T_line01 left">
                                        &gt;</div>
                                    <span class="left">&nbsp;<asp:Label ID="lblPlease" runat="server" meta:resourcekey="lblPlease">Please help us with a little more information</asp:Label></span>
                                </div>
                                <table cellpadding="0" cellspacing="4" border="0" class="MV_hotel_errorMsg">
                                    <tr>
                                        <td valign="top">
                                            <div style="width: 12px; height: 13px; background: #cc0000; color: #fff; text-align: center;">
                                                !</div>
                                        </td>
                                        <td>
                                            <asp:Panel ID="plCityName" runat="server">
                                                <asp:Label ID="lblwefound" runat="server" meta:resourcekey="lblwefound">We found more than one location matching</asp:Label>
                                                '<asp:Label ID="lblCityName" runat="server"></asp:Label>'.
                                                <asp:Label ID="lblselect" runat="server" meta:resourcekey="lblselect">Please select a location from the list</asp:Label>.
                                            </asp:Panel>
                                            <asp:Panel ID="PLCiytName1" runat="server">
                                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblwefound1">We could not find any city or airports that match your search for</asp:Label>
                                                '<asp:Label ID="lblCityName1" runat="server"></asp:Label>'.
                                                <asp:Label ID="Label3" runat="server" meta:resourcekey="lblselect1">Please enter a new city code, city name, or airport code</asp:Label>.
                                            </asp:Panel>
                                            <asp:Panel ID="PLCiytName2" runat="server">
                                                <asp:Label ID="Label2" runat="server" meta:resourcekey="lblwefound2">Please enter at least 3 characters of the location name</asp:Label>.
                                            </asp:Panel>
                                             <asp:Panel ID="PLCiytName3" runat="server">
                                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblwefound3">There are no hotel met your search criteria. Please re-seach. or call our experienced Sale Agents at</asp:Label> 1-(888)-288-7528.
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                                <asp:Panel ID="choosecity" runat="server">
                                <div class="MV_hotel_error_RBL_Title">
                                    Choose City
                                </div>
                                </asp:Panel>
                                <div class="MV_hotel_error_RBL">
                                    <asp:RadioButtonList ID="rblCityName" runat="server">
                                    </asp:RadioButtonList>
                                    &nbsp; &nbsp; &nbsp;
                                    <uc1:MustInputTextBox ID="txtCityName" runat="server" Style="margin-left: 20px; display: inline;"
                                        CssClass="dropDownRes" Width="150px"/>
                                    <div class="MV_hotel_errorMsg1">
                                        <asp:Button ID="btnSearch_h" CssClass="search_btn" Text="Search" runat="server" OnClick="btn_Search_h_Click"
                                            Style="cursor: pointer" meta:resourcekey="btnSearch_h" />
                                    </div>
                                </div>
                            </div>
                            <!-- mian end-->
                        </td>
                    </tr>
                    <tr>
                        <td height="1">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
        </div>
        <!-- footer.jsp | begin -->
        <uc2:Footer ID="Footer1" runat="server" />
        <!-- footer.jsp | end -->

        <script language="javascript" type="text/javascript">
        history.go(1);
        </script>

    </form>
</body>
</html>
