<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="HotelSearchConditionsMeaasageForm" EnableEventValidation="false" Codebehind="HotelSearchConditionsMeaasageForm.aspx.cs" %>

<%@ Register Src="../../UserControls/TravelerChange.ascx" TagName="TravelerChange"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/SearchEngineH.ascx" TagName="SearchEngineH"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_new.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr>
                <td align="center">
                    <table width="100%" border="0" align="center" cellpadding="3" cellspacing="1" class="T_table">
                        <tr>
                            <td colspan="2" align="left">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="20">
                                            <table width="20" border="0" cellspacing="0" cellpadding="0" class="T_line01">
                                                <tr>
                                                    <td align="center">
                                                        ></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="5">
                                        </td>
                                        <td>
                                            <span class="head06">
                                                <asp:Label ID="lblPleaseclarifyyoursearch" runat="Server" meta:resourcekey="lblPleaseclarifyyoursearch">Please clarify your search</asp:Label>.</span></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <table width="80%" border="0" cellspacing="1" cellpadding="3" class="T_line02">
                                    <tr>
                                        <td align="left" bgcolor="#FFFFFF">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="18" valign="top">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="T_line03">
                                                            <tr>
                                                                <td width="13" align="center">
                                                                    !</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top">
                                                    <asp:Panel ID="plCityName" runat="server">
                                                        <span class="t05" style="color: #000000"> <asp:Label ID="lblPleasechoose" runat="Server" meta:resourcekey="lblPleasechoose">Please choose check-in and check-out date</asp:Label>.</span>
                                                    </asp:Panel>
                                                     <asp:Panel ID="PLCiytName3" runat="server">
                                                      <span class="t05" style="color: #000000"> <asp:Label ID="Label4" runat="server" meta:resourcekey="lblwefound3" ForeColor="Red" Text="There are no hotel met your search criteria. Please re-seach. or call our experienced Sale Agents at"></asp:Label><span style="color:Red"> 1-(888)-288-7528.</span></span>
                                                     </asp:Panel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" >
                                    <tr>
                                        <td  bgcolor="#FFFFFF">
                                            <span class="head09"> <asp:Label ID="lblCountry" runat="Server" meta:resourcekey="lblCountry">Destination: (e.g. an City Name, City Code, Airport Code)</asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td height="3">
                                            <asp:TextBox ID="txtName" runat="server" ValidationGroup="HotelOnlySearch" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Please Input Name."
                SetFocusOnError="True" ValidationGroup="HotelOnlySearch" meta:resourcekey="MsgCountry"></asp:RequiredFieldValidator></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" align="left">
                                <b><asp:Label ID="lblCheckIn" runat="Server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:</b></td>
                            <td width="90%" align="left">
                                <uc7:Calendar ID="txtCheckin_h" runat="server" />
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td width="10%" align="left">
                                <b><asp:Label ID="lblCheckOut" runat="Server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:</b></td>
                            <td width="90%" align="left">
                                <uc7:Calendar ID="txtCheckout_h" runat="server" LowerLimitID="txtCheckin_h"  />
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span class="head09"><asp:Label ID="lblPassengers" runat="Server" meta:resourcekey="lblPassengers">Passengers</asp:Label>:</span></td>
                                    </tr>
                                    <tr>
                                        <td height="3">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table border="0" cellspacing="0" cellpadding="0" width="40%">
                                    <tr>
                                        <td style="height: 20px">
                                        </td>
                                        <td style="height: 20px">
                                        </td>
                                        <td style="height: 20px">
                                            <uc6:TravelerChange ID="TravelerChange1" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:Button ID="btnSearch_h" runat="server" Text="Continue" BorderStyle="none" CssClass="search_btn"
                        OnClick="btnSearch_Click" Style="cursor: hand" ValidationGroup="HotelOnlySearch" meta:resourcekey="btnSearch_h"/>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
