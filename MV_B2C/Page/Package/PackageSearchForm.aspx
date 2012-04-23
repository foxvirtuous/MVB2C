<%@ Page Language="C#" AutoEventWireup="true" Inherits="PackageSearchForm" Codebehind="PackageSearchForm.aspx.cs" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar"
    TagPrefix="uc6" %>

<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc4" %>

<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc3" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
    <script type="text/javascript">
        function ShowHideCheckInOutDate()
        {
            if(document.getElementById("divCheckInOutDate").style.display == "")
                document.getElementById("divCheckInOutDate").style.display = "none";
            else
                document.getElementById("divCheckInOutDate").style.display = "";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server"><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
    <div style="font-size: 12px; width: 300px; font-family: Arial, Helvetica, sans-serif">
        <table width="100%" border="0" cellspacing="0" cellpadding="3" align="left">
            <tr>
                <td colspan="2">
                    <strong>Package (Flight + Hotel) </strong>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input name="radiobutton" type="radio" value="radiobutton" checked="checked" />
                    Round Trip
                    <input name="radiobutton" type="radio" value="radiobutton" onclick="javascript:location.href='PackageSearch2dForm.aspx'" />Multiple
                    Cities&nbsp;</td>
            </tr>
            <tr>
                <td colspan="2">
                    From:<br/>
                    <uc4:MustInputTextBox id="txtFrom" runat="server" ValidationGroup="group"></uc4:MustInputTextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    To:<br/>
                    <uc4:MustInputTextBox ID="txtTo" runat="server" ValidationGroup="group" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Depart:
                    <uc6:Calendar ID="dateDeparture" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Return:
                    <uc6:Calendar ID="dateReturn" runat="server" LowerLimitID="dateDeparture" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:CheckBox ID="chbFlexible" runat="server" Text="My dates are flexible +/- 1 day" />
                    
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;<uc3:TravelerChange id="TravelerChange1" runat="server"></uc3:TravelerChange></td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong>Addtional options:</strong>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 27px">
                    Airline:
                    <asp:DropDownList ID="ddlAirline" runat="server">
                        <asp:ListItem Value="ALL" Selected="True">No Preference</asp:ListItem>
                        <asp:ListItem Value="AA">American Airline</asp:ListItem>
                        <asp:ListItem Value="NW">Northwest</asp:ListItem>
                        <asp:ListItem Value="UA">United Airline</asp:ListItem>
                    </asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    Class:
                    <asp:DropDownList ID="ddlClass" runat="server">
                        <asp:ListItem Value="ALL" Selected="True">No Preference</asp:ListItem>
                        <asp:ListItem Value="Economy">Economy / Coach</asp:ListItem>
                        <asp:ListItem Value="Buisness">Buisness</asp:ListItem>
                        <asp:ListItem Value="First Class">First Class</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <input type="checkbox" name="chkChangeCheckInOutDate" value="checkbox" onclick="ShowHideCheckInOutDate()" />
                    I only need a hotel for part of my trip
                    <div id="divCheckInOutDate" style="display: none">
                        When do you need a hotel? (Check-in and check-out dates must be within dates of
                        travel.)
                        <table width="100%" border="0" cellspacing="0" cellpadding="1">
                            <tr>
                                <td>
                                    Check In:
                                    <br />
                                    <uc1:Calendar id="ClaendarUC3" runat="server">
                                    </uc1:Calendar></td>
                                <td>
                                    Check Out:<br />
                                    <uc1:Calendar id="ClaendarUC4" runat="server">
                                    </uc1:Calendar></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="right">
                    <asp:Button ID="btnSearch" runat="server" text="Search" OnClick="btnSearch_Click" ValidationGroup="group" />
                    </td>
            </tr>
        </table>
    </div>
        &nbsp;
        <asp:ScriptManager id="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
