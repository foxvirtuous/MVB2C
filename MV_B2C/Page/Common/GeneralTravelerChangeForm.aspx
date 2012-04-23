<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="GeneralTravelerChangeForm" Codebehind="GeneralTravelerChangeForm.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    function ShowHidePassengers()
        {
            if(document.getElementById("dllRooms").value == "1")
            {
                document.getElementById("div2").style.display = "none";
                document.getElementById("div3").style.display = "none";
                document.getElementById("div4").style.display = "none";
            }
            if(document.getElementById("dllRooms").value == "2")
            {
                document.getElementById("div2").style.display = "";
                document.getElementById("div3").style.display = "none";
                document.getElementById("div4").style.display = "none";
            }
            if(document.getElementById("dllRooms").value == "3")
            {
                document.getElementById("div2").style.display = "";
                document.getElementById("div3").style.display = "";
                document.getElementById("div4").style.display = "none";
            }
            if(document.getElementById("dllRooms").value == "4")
            {
                document.getElementById("div2").style.display = "";
                document.getElementById("div3").style.display = "";
                document.getElementById("div4").style.display = "";
            }
        }
    </script>

    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
        <div id="content"><uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
            <div id="subcontent_r">
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        The public choice controls
                        
                    </div>
                    <h1>
                        Change Travelers
                    </h1>
                    Change travelers and search again
                    <div>
                        <div class="getFlight">
                            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                <tr>
                                    <td>
                                        Rooms:</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        Adults: (12+)
                                    </td>
                                    <td>
                                        Children: (2-11)
                                    </td>
                                </tr>
                                <tr>
                                    <td width="19%">
                                        <asp:DropDownList ID="dllRooms" runat="server" onchange="ShowHidePassengers()" CssClass="search_sle" Width="35px">
                                            <asp:ListItem Selected="True">1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="13%">
                                        <strong>Room #1: </strong>
                                    </td>
                                    <td width="18%">
                                        <asp:DropDownList ID="ddlAdult1" runat="server" CssClass="search_sle" Width="35px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="18%">
                                        <asp:DropDownList ID="ddlChild1" runat="server" CssClass="search_sle" Width="35px">
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
                                id="div2" runat="server">
                                <tr>
                                    <td width="19%">
                                        &nbsp;</td>
                                    <td width="13%">
                                        <strong>Room #2: </strong>
                                    </td>
                                    <td width="18%">
                                        <asp:DropDownList ID="ddlAdult2" runat="server" CssClass="search_sle" Width="35px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="18%">
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
                                id="div3" runat="server">
                                <tr>
                                    <td width="19%">
                                        &nbsp;</td>
                                    <td width="13%">
                                        <strong>Room #3: </strong>
                                    </td>
                                    <td width="18%">
                                        <asp:DropDownList ID="ddlAdult3" runat="server" CssClass="search_sle" Width="35px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="18%">
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
                                id="div4" runat="server">
                                <tr>
                                    <td width="19%">
                                        &nbsp;</td>
                                    <td width="13%">
                                        <strong>Room #4: </strong>
                                    </td>
                                    <td width="18%">
                                        <asp:DropDownList ID="ddlAdult4" runat="server" CssClass="search_sle" Width="35px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2" Selected="True">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="6">6</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="18%">
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
                        </div>
                    </div>
                    <div class="btn">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/v1/btn_continue.gif"
                            Width="143" Height="33" border="0" align="absmiddle" OnClick="ImageButton1_Click" /></div>
                </div>
            </div>
            <p class="clear">
                <uc2:Footer ID="Footer1" runat="server" />
            </p>
        </div>
    </form>
</body>
</html>
