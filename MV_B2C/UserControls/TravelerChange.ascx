<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="TravelerChange" Codebehind="TravelerChange.ascx.cs" %>
    <script type="text/javascript">
    function ShowHidePassengers()
    {
        DoShowHidePassengers("TravelerChange1"); 
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
<input type="hidden" name="hdControlName" id = "hdControlName" value="TravelerChange1" runat="server" />
<table width="100%" border="0" cellspacing="0" cellpadding="3">
    <tr>
        <td>
            <asp:Label ID="lblRooms" runat="server" meta:resourcekey="lblRooms">Rooms</asp:Label>:</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblAdults">Adults</asp:Label>: (12+)
        </td>
        <td>
            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblChild">Children</asp:Label>: (2-11)
        </td>
    </tr>
    <tr>
        <td width="16%">
            <asp:DropDownList ID="dllRooms" runat="server" onchange="ShowHidePassengers()" CssClass="search_sle" Width="35px">
                <asp:ListItem Selected="True">1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="20%">
            <strong><asp:Label ID="Label3" runat="server" meta:resourcekey="lblRoom">Room</asp:Label> #1: </strong>
        </td>
        <td width="29%">
            <asp:DropDownList ID="ddlAdult1" runat="server" CssClass="search_sle" Width="35px">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="35%">
            <asp:DropDownList ID="ddlChild1" runat="server" CssClass="search_sle" Width="35px">
                <asp:ListItem Value="0" Selected="True">0</asp:ListItem >
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="3" style="display: none"
    id="tbRoom2" runat="server">
    <tr>
        <td width="16%">
            &nbsp;</td>
        <td width="20%">
            <strong><asp:Label ID="Label4" runat="server" meta:resourcekey="lblRoom">Room</asp:Label> #2: </strong>
        </td>
        <td width="29%">
            <asp:DropDownList ID="ddlAdult2" runat="server" CssClass="search_sle" Width="35px">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="35%">
            <asp:DropDownList ID="ddlChild2" runat="server" CssClass="search_sle" Width="35px">
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
<table width="100%" border="0" cellspacing="0" cellpadding="3" style="display: none"
    id="tbRoom3" runat="server">
    <tr>
        <td width="16%">
            &nbsp;</td>
        <td width="20%">
            <strong><asp:Label ID="Label5" runat="server" meta:resourcekey="lblRoom">Room</asp:Label> #3: </strong>
        </td>
        <td width="29%">
            <asp:DropDownList ID="ddlAdult3" runat="server" CssClass="search_sle" Width="35px">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="35%">
            <asp:DropDownList ID="ddlChild3" runat="server" CssClass="search_sle" Width="35px">
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
<table width="100%" border="0" cellspacing="0" cellpadding="3" style="display: none"
    id="tbRoom4" runat="server">
    <tr>
        <td width="16%">
            &nbsp;</td>
        <td width="20%">
            <strong><asp:Label ID="Label6" runat="server" meta:resourcekey="lblRoom">Room</asp:Label> #4: </strong>
        </td>
        <td width="29%">
            <asp:DropDownList ID="ddlAdult4" runat="server" CssClass="search_sle" Width="35px">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="6">6</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td width="35%">
            <asp:DropDownList ID="ddlChild4" runat="server" CssClass="search_sle" Width="35px">
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
