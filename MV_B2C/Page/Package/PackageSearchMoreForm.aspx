<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageSearchMoreForm" Codebehind="PackageSearchMoreForm.aspx.cs" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar"
    TagPrefix="uc7" %>

<%@ Register Src="~/UserControls/StatesControl.ascx" TagName="Navigation" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc3" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />

    <script type="text/javascript">

            function   ChangeDepSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("listBDepartureAirport")[0];
                index = str.selectedIndex;   
                document.getElementById("txtDepartureFrom").value = str[index].text;
                //document.getElementById("lbDepartureCode").value = str[index].value;
              }
              
              function   ChangeRtnSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("listBReturnAirport")[0];
                index = str.selectedIndex;   
                document.getElementById("txtReturn").value = str[index].text;
                //document.getElementById("lbReturnCode").value = str[index].value;
              }
              
              function JHshTextPlus()
                {
                     var keyPressed;
                     if (navigator.appName=="Netscape")
                     {
                      keyPressed = arguments.callee.caller.arguments[0].which;
                     }
                 
                     else if (navigator.appName=="Microsoft Internet Explorer")
                     {
                      keyPressed = window.event.keyCode;
                     }
                 
                     if ( !(  ( (keyPressed >= 65) && (keyPressed <= 90) 
                     ||  (keyPressed >= 97) && (keyPressed <= 122) || (keyPressed == 8  || keyPressed == 0 || keyPressed == 32) )))
                     {
                          var event=window.event||arguments.callee.caller.arguments[0];
                          if(navigator.appName=="Microsoft Internet Explorer")
                          {
                           event.returnValue=false;
                          }
                          else if (navigator.appName=="Netscape")
                          {
                           event.preventDefault();
                          }
                     }
                }
        function fncKeyStop(evt)
        {
            if(!window.event)
            {
                var keycode = evt.keyCode; 
                var key = String.fromCharCode(keycode).toLowerCase();
                if(evt.ctrlKey && key == "v")
                {
                  evt.preventDefault(); 
                  evt.stopPropagation();
                }
            }
        }
             
    </script>

    <link href="" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <div id="content">
            <div id="subcontent_r">
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc6:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <h1>
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblPackageSearch">Package Search</asp:Label>
                    </h1><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-1.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblDestinationsDate">Destinations &amp; Date</asp:Label>
                        </h3>
                        <div class="getFlight">
                            <table width="100%" border="0" cellspacing="0" cellpadding="3">
                                <tr>
                                    <td colspan="4" class="name">
                                        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblDepartureReturn">Departure / Return</asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="13%">
                                        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblDepartFrom">Depart From</asp:Label>:
                                    </td>
                                    <td width="41%">
                                        &nbsp;<asp:TextBox ID="txtDepartureFrom" runat="server" Width="209px" ValidationGroup="group"></asp:TextBox>
                                        </td>
                                    <td width="16%">
                                        <img src="../../images/v1/fly.gif" width="20" height="17" align="absmiddle" />
                                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDepartDate">Depart Date</asp:Label>:</td>
                                    <td width="30%">
                                        &nbsp;&nbsp;
                                        <uc7:Calendar ID="dateDepatrue" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <%--<asp:PlaceHolder ID="phDepatrue" runat="server" Visible="false">
                                        
                                    </asp:PlaceHolder>--%>
                                        <asp:ListBox ID="listBDepartureAirport" runat="server" onchange="ChangeDepSelect()"
                                            Visible="False"></asp:ListBox>
                                        &nbsp;<asp:Label ID="lbSelect" runat="server" Text="Please select an airport." Visible="false" ForeColor="red" meta:resourcekey="lblSelectAirport"></asp:Label>
                                        <asp:Label ID="lbDepartureCode" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td width="13%">
                                        <asp:Label ID="Label6" runat="server" meta:resourcekey="lblReturn">Return</asp:Label>:
                                    </td>
                                    <td width="41%">
                                        &nbsp;<asp:TextBox ID="txtReturn" runat="server" Width="209px" ValidationGroup="group"></asp:TextBox>
                                         
                                        </td>
                                    <td width="16%">
                                        <img src="../../images/v1/fly.gif" width="20" height="17" align="absmiddle" />
                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:</td>
                                    <td width="30%">
                                        &nbsp;&nbsp;
                                        <uc7:Calendar ID="dateReturn" runat="server" LowerLimitID="dateDepatrue"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <%--<asp:PlaceHolder ID="phReturn" runat="server" Visible="false">
                                        
                                    </asp:PlaceHolder>--%>
                                        <asp:ListBox ID="listBReturnAirport" runat="server" onchange="ChangeRtnSelect()"
                                            Visible="False"></asp:ListBox>
                                        &nbsp;<asp:Label ID="lbRTSelect" runat="server" Text="Please select an airport." Visible="false" ForeColor="red" meta:resourcekey="lblSelectAirport"></asp:Label>
                                        <asp:Label ID="lbReturnCode" runat="server" Visible="False"></asp:Label></td>
                                </tr>
                                 <tr>
                                    <td width="13%">
                                        <asp:Label ID="Label8" runat="server" meta:resourcekey="lblCheckIn">CheckIn</asp:Label>:
                                    </td>
                                    <td width="41%">
                                        &nbsp;<uc7:Calendar ID="CheckIn_AH" runat="server" LowerLimitID="dateDepatrue" UpperLimitID="dateReturn"  IsLowerRepeatDate="1" /></td>
                                    <td width="16%">
                                        
                                        <asp:Label ID="Label9" runat="server" meta:resourcekey="lblCheckOut">CheckOut</asp:Label>:</td>
                                    <td width="30%">
                                        &nbsp;&nbsp;
                                        <uc7:Calendar ID="CheckOut_AH" runat="server" LowerLimitID="CheckIn_AH" UpperLimitID="dateReturn" IsUpperRepeatDate= "1"/>
                                    </td>
                                </tr>
                                
                            </table>
                            <table width="100%" border="0" cellpadding="3" cellspacing="0" class="dotline">
                                <tr>
                                    <td colspan="4" class="name">
                                        <asp:Label ID="Label10" runat="server" meta:resourcekey="lblPreference">Flight Preference (Optional)</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:CheckBox ID="chkflexible" runat="server" Text="My dates are flexible +/- 1 day "  meta:resourcekey="lblMyDate" />
                                    </td>
                                </tr>
                                <tr>
                                    <td width="16%">
                                        <asp:Label ID="Label11" runat="server" meta:resourcekey="lblAirline">Airline Name</asp:Label>:
                                    </td>
                                    <td width="37%">
                                        <asp:DropDownList ID="ddlAirLine" runat="server">
                                            <asp:ListItem Value="all" Text="No Preference"></asp:ListItem>
                                            <asp:ListItem Value="AA">Amarican Airlines</asp:ListItem>
                                            <asp:ListItem Value="DL">Delta Airlines</asp:ListItem>
                                            <asp:ListItem Value="UA">United Airlines</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="12%">
                                        Class:</td>
                                    <td width="35%">
                                        <asp:DropDownList ID="ddlClass" runat="server">
                                            <asp:ListItem Value="0" Text="No Preference"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Economy / Coach"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Buisness"></asp:ListItem>
                                            <asp:ListItem Value="3" Text="First Class"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-2.gif" width="20" height="20" align="texttop" />
                            <asp:Label ID="Label12" runat="server" meta:resourcekey="lblTraveler">Traveler</asp:Label>
                        </h3>
                        <div class="getFlight">
                            <uc2:TravelerChange ID="TravelerChange1" runat="server" />
                            &nbsp;</div>
                    </div>
                    <div class="btn">
                        <%--<a href="search_result-2d.html">
                        <img src="images/btn_search.gif" width="58" height="26" border="0" align="absmiddle" /></a>--%>
                        <asp:ImageButton ID="btnSearch" runat="server" Width="58" Height="26" ImageUrl="~/images/v1/btn_search.gif"
                            BorderStyle="none" OnClick="btnSearch_Click" ValidationGroup="group" />
                    </div>
                </div>
            </div>
            <p class="clear">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
