<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="TourTravelerChangeControl" Codebehind="TourTravelerChangeControl.ascx.cs" %>

<script type="text/javascript">
    function ShowHidePassengers()
    {
        DoShowHidePassengers("ctl00_MainContent_TourTravelerChangeControl1");
    }
    
    function DoShowHidePassengers(controlName)
    {
        if(document.getElementById(controlName + "_dllRooms"))
        {
            if(document.getElementById(controlName + "_dllRooms").value == "1")
            {
                    document.getElementById(controlName + "_tbRoom2").style.display = "none";
                    document.getElementById(controlName + "_tbRoom3").style.display = "none";
                    document.getElementById(controlName + "_tbRoom4").style.display = "none";
            }
            if(document.getElementById(controlName + "_dllRooms").value == "2")
            {
                    document.getElementById(controlName + "_tbRoom2").style.display = "";
                    document.getElementById(controlName + "_tbRoom3").style.display = "none";
                    document.getElementById(controlName + "_tbRoom4").style.display = "none";
            }
            if(document.getElementById(controlName + "_dllRooms").value == "3")
            {
                    document.getElementById(controlName + "_tbRoom2").style.display = "";
                    document.getElementById(controlName + "_tbRoom3").style.display = "";
                    document.getElementById(controlName + "_tbRoom4").style.display = "none";
            }
            if(document.getElementById(controlName + "_dllRooms").value == "4")
            {
                    document.getElementById(controlName + "_tbRoom2").style.display = "";
                    document.getElementById(controlName + "_tbRoom3").style.display = "";
                    document.getElementById(controlName + "_tbRoom4").style.display = "";
            }
        }
    }
</script>

<input type="hidden" name="hdControlName" id="hdControlName" value="TourTravelerChangeControl1"
    runat="server" />
<table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
    <tr class="R_stepw">
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td nowrap rowspan="2">
                        Rooms:
                        <asp:DropDownList ID="dllRooms" runat="server" onchange="ShowHidePassengers()" CssClass="search_sle"
                            Width="35px">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList></td>
                    <td nowrap rowspan="2">
                        <strong>Room #1: </strong>
                    </td>
                    <td nowrap>
                        Room Type:
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        Adults(12+):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(2-11):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(Without bed):
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        <asp:DropDownList ID="ddlRoomType1" runat="server" CssClass="search_sle" Width="60px">
                            <asp:ListItem Value="1">Twin</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">Single</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlAdult1" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChild1" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChildWithOut1" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03" style="display: none"
    id="tbRoom2" runat="server">
    <tr class="R_stepw">
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td nowrap rowspan="2" width="110px">
                    </td>
                    <td nowrap rowspan="2">
                        <strong>Room #1: </strong>
                    </td>
                    <td nowrap>
                        Room Type:
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        Adults(12+):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(2-11):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(Without bed):
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        <asp:DropDownList ID="ddlRoomType2" runat="server" CssClass="search_sle" Width="60px">
                            <asp:ListItem Value="1">Twin</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">Single</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlAdult2" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChild2" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChildWithOut2" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03" style="display: none"
    id="tbRoom3" runat="server">
    <tr class="R_stepw">
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td nowrap rowspan="2" width="110px">
                    </td>
                    <td nowrap rowspan="2">
                        <strong>Room #1: </strong>
                    </td>
                    <td nowrap>
                        Room Type:
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        Adults(12+):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(2-11):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(Without bed):
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        <asp:DropDownList ID="ddlRoomType3" runat="server" CssClass="search_sle" Width="60px">
                            <asp:ListItem Value="1">Twin</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">Single</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlAdult3" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChild3" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChildWithOut3" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03" style="display: none"
    id="tbRoom4" runat="server">
    <tr class="R_stepw">
        <td>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td nowrap rowspan="2" width="110px">
                    </td>
                    <td nowrap rowspan="2">
                        <strong>Room #1: </strong>
                    </td>
                    <td nowrap>
                        Room Type:
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        Adults(12+):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(2-11):
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        Children(Without bed):
                    </td>
                </tr>
                <tr>
                    <td nowrap>
                        <asp:DropDownList ID="ddlRoomType4" runat="server" CssClass="search_sle" Width="60px">
                            <asp:ListItem Value="1">Twin</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">Single</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                        &nbsp;</td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlAdult4" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChild4" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td width="10">
                    </td>
                    <td nowrap>
                        <asp:DropDownList ID="ddlChildWithOut4" runat="server" CssClass="search_sle" Width="35px">
                            <asp:ListItem Value="0" Selected="True">0</asp:ListItem>
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
