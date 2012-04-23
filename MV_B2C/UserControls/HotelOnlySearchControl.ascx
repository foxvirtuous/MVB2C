<%@ Control Language="C#" AutoEventWireup="true"
    Inherits="HotelOnlySearchControl" Codebehind="HotelOnlySearchControl.ascx.cs" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="TermsCalender" TagPrefix="TermsCalender" %>
<script type="text/javascript">
    function ShowHidePassengers()
    {
        DoShowHidePassengers("HotelOnlySearchControl1"); 
    }
    
    function DoShowHidePassengers(controlName)
    {
        if(document.getElementById(controlName + "_ddlRooms"))
        {
            if(document.getElementById(controlName + "_ddlRooms").value == "1")
            {

                    document.getElementById(controlName + "_pAdult2").style.display = "none";
                    document.getElementById(controlName + "_pAdult3").style.display = "none";
                    document.getElementById(controlName + "_pAdult4").style.display = "none";
                    document.getElementById(controlName + "_pChild2").style.display = "none";
                    document.getElementById(controlName + "_pChild3").style.display = "none";
                    document.getElementById(controlName + "_pChild4").style.display = "none";
                    
            }
            if(document.getElementById(controlName + "_ddlRooms").value == 2)
            {
                    document.getElementById(controlName + "_pAdult2").style.display = "";
                    document.getElementById(controlName + "_pAdult3").style.display = "none";
                    document.getElementById(controlName + "_pAdult4").style.display = "none";
                    document.getElementById(controlName + "_pChild2").style.display = "";
                    document.getElementById(controlName + "_pChild3").style.display = "none";
                    document.getElementById(controlName + "_pChild4").style.display = "none";
            }
            if(document.getElementById("HotelOnlySearchControl1_ddlRooms").value == "3")
            {
                    document.getElementById(controlName + "_pAdult2").style.display = "";
                    document.getElementById(controlName + "_pAdult3").style.display = "";
                    document.getElementById(controlName + "_pAdult4").style.display = "none";
                    document.getElementById(controlName + "_pChild2").style.display = "";
                    document.getElementById(controlName + "_pChild3").style.display = "";
                    document.getElementById(controlName + "_pChild4").style.display = "none";
            }
            if(document.getElementById("HotelOnlySearchControl1_ddlRooms").value == "4")
            {
                    document.getElementById(controlName + "_pAdult2").style.display = "";
                    document.getElementById(controlName + "_pAdult3").style.display = "";
                    document.getElementById(controlName + "_pAdult4").style.display = "";
                    document.getElementById(controlName + "_pChild2").style.display = "";
                    document.getElementById(controlName + "_pChild3").style.display = "";
                    document.getElementById(controlName + "_pChild4").style.display = "";
            }
        }
    }
</script>
<div id="Div1" runat="server" >
    <table cellpadding="0" cellspacing="0" width="100%" border="0">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="1" width="100%" class="T_step0l">
                    <tr align="center" class="R_step01">
                        <td height="25px">
                            <asp:Label ID="lblChangeYourSearch" runat="Server" meta:resourcekey="lblChangeYourSearch">Change Your Search</asp:Label></td>
                    </tr>
                    <tr class="R_stepbox">
                        <td>
                            <table border="0" cellpadding="3" cellspacing="5" width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblCountry" runat="Server" meta:resourcekey="lblCountry">Destination: (e.g. an City Name, City Code, Airport Code)</asp:Label></td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:TextBox ID="txtFullName" runat="server" ValidationGroup="HotelOnlySearch" autocomplete="off" onfocus="if(document.getElementById('FocusIndex')!=null){document.getElementById('FocusIndex').value='R';}">
                                        </asp:TextBox>
                                        <asp:TextBox ID="txtName" runat="server" ValidationGroup="HotelOnlySearch" Visible=false>
                                        </asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblCheckin" runat="Server" meta:resourcekey="lblCheckin">Check-in</asp:Label>:</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <TermsCalender:TermsCalender ID="txtCheckinDate" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <asp:Label ID="lblCheckout" runat="Server" meta:resourcekey="lblCheckout">Check-out</asp:Label>:</td>
                                </tr>
                                <tr>
                                    <td align="left">
                                        <TermsCalender:TermsCalender ID="txtCheckoutDate" runat="server" LowerLimitID="txtCheckinDate" />
                                    </td>
                                </tr>
                            </table>
                            <div class="MV_hotel_reSearch_CT MV_hotel_reSearch_CT_C">
                                <asp:Label ID="lblChangeTravelers" runat="server" meta:resourcekey="lblChangeTravelers">Change Travelers</asp:Label>:</div>
                            <div class="MV_hotel_reSearch_CT_main">
                                <table border="0" cellpadding="5" cellspacing="0" width="100%">
                                    <tbody>
                                        <tr>
                                            <td style="border-bottom: 1px solid rgb(216, 216, 216);" height="27">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td height="27" align="left">
                                                                <asp:Label ID="lblRooms" runat="server" meta:resourcekey="lblRooms">Room(s)</asp:Label>:
                                                            </td>
                                                            <td align="right">
                                                                <asp:DropDownList ID="ddlRooms" runat="server" onchange="ShowHidePassengers()">
                                                                    <asp:ListItem Selected="True">1</asp:ListItem>
                                                                    <asp:ListItem>2</asp:ListItem>
                                                                    <asp:ListItem>3</asp:ListItem>
                                                                    <asp:ListItem>4</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-bottom: 1px solid rgb(216, 216, 216);" height="24">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblAdult1" runat="server" meta:resourcekey="lblAdult">Adult(s): (12+)</asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlAdult1" runat="server">
                                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblChildren" runat="server" meta:resourcekey="lblChildren">Child(ren): (2-11)</asp:Label></td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlChild1" runat="server">
                                                                <asp:ListItem Selected="True">0</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="pAdult2" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                    style="display: none">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblAdult2" runat="server" meta:resourcekey="lblAdult">Adult(s): (12+)</asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlAdult2" runat="server">
                                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="pChild2" border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom: 1px solid rgb(216, 216, 216);
                                                    display: none" runat="server">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblChildren2" runat="server" meta:resourcekey="lblChildren">Child(ren): (2-11)</asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlChild2" runat="server">
                                                                <asp:ListItem Selected="True">0</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="pAdult3" border="0" cellpadding="0" cellspacing="0" width="100%" runat="server"
                                                    style="display: none">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblAdult3" runat="server" meta:resourcekey="lblAdult">Adult(s): (12+)</asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlAdult3" runat="server">
                                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="pChild3" border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom: 1px solid rgb(216, 216, 216);
                                                    display: none" runat="server">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblChildren3" runat="server" meta:resourcekey="lblChildren">Child(ren): (2-11)</asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlChild3" runat="server">
                                                                <asp:ListItem Selected="True">0</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table id="pAdult4" border="0" cellpadding="0" cellspacing="0" width="100%" style="display: none"
                                                    runat="server">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblAdult4" runat="server" meta:resourcekey="lblAdult">Adult(s): (12+)</asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlAdult4" runat="server">
                                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table id="pChild4" border="0" cellpadding="0" cellspacing="0" width="100%" style="border-bottom: 1px solid rgb(216, 216, 216);
                                                    display: none" runat="server">
                                                    <tr>
                                                        <td height="27" align="left">
                                                            <asp:Label ID="lblChildren4" runat="server" meta:resourcekey="lblChildren">Child(ren): (2-11)</asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:DropDownList ID="ddlChild4" runat="server">
                                                                <asp:ListItem Selected="True">0</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <div class="clear">
                                </div>
                            </div>
                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                <tr valign="top">
                                    <td colspan="2" align="center">
                                        <asp:Button ID="imgbSearch" runat="server" Text="Search" OnClick="imgbSearch_Click"
                                            CssClass="search_btn01" Style="cursor: pointer" meta:resourcekey="imgbSearch" ValidationGroup="HotelOnlySearch"/>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td class="TdWidth">
            </td>
        </tr>
    </table>
    </div>
