<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PackageMoreSearch.aspx.cs"
    Inherits="PackageMoreSearch" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/StatesControl.ascx" TagName="Navigation" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc3" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
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

    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <div id="content">
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc6:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblViewYourPackages">View Your Packages</asp:Label></span>
                    </div>
                    <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
                        z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
                        marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
                    </iframe>
                    <div class="IBE_package_step_moreSearch_bt">
                        <div class="IBE_package_step_moreSearch_bt_title">
                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblDepartureReturn">Departure / Return</asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <div class="left">
                                <asp:Label ID="Label4" runat="server" meta:resourcekey="lblDepartFrom" CssClass="fB">Depart From</asp:Label>:
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDepartureFrom" runat="server" Width="209px"
                                    ValidationGroup="group"></asp:TextBox>
                            </div>
                            <div class="right">
                                <ul>
                                    <li>
                                        <img src="../../images/v1/fly.gif" width="20" height="17" align="absmiddle" />&nbsp;</li>
                                    <li>
                                        <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDepartDate" CssClass="fB">Depart Date</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;</li>
                                    <li>
                                        <uc7:Calendar ID="dateDepatrue" runat="server" />
                                    </li>
                                </ul>
                            </div>
                            <div class="IBE_package_step_moreSearch_bt_LI ">
                                <asp:ListBox ID="listBDepartureAirport" runat="server" onchange="ChangeDepSelect()"
                                    Width="500px" Visible="False"></asp:ListBox>&nbsp;&nbsp;<asp:Label ID="lbSelect"
                                        runat="server" Text="Please select an airport." Visible="false" ForeColor="red"
                                        meta:resourcekey="lblSelectAirport"></asp:Label>
                            </div>
                            <div class="IBE_package_step_moreSearch_bt_bottomline">
                            </div>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <div class="left">
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblReturn" CssClass="fB">Return From</asp:Label>:
                                &nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtReturn" runat="server" Width="209px"
                                    ValidationGroup="group"></asp:TextBox>
                            </div>
                            <div class="right">
                                <ul>
                                    <li>
                                        <img src="../../images/v1/fly.gif" width="20" height="17" align="absmiddle" />&nbsp;</li>
                                    <li>
                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblReturnDate" CssClass="fB">Return Date</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;</li>
                                    <li>
                                        <uc7:Calendar ID="dateReturn" runat="server" LowerLimitID="dateDepatrue" />
                                    </li>
                                </ul>
                            </div>
                            <div class="IBE_package_step_moreSearch_bt_LI " >
                                <asp:ListBox ID="listBReturnAirport" runat="server" onchange="ChangeRtnSelect()"
                                    Width="500px" Visible="False"></asp:ListBox>&nbsp;&nbsp;<asp:Label ID="lbRTSelect"
                                        runat="server" Text="Please select an airport." Visible="false" ForeColor="red"
                                        meta:resourcekey="lblSelectAirport"></asp:Label>
                                <asp:Label ID="lbReturnCode" runat="server" Visible="False"></asp:Label>
                            </div>
                            <div class="IBE_package_step_moreSearch_bt_bottomline">
                            </div>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <div class="left">
                                <ul>
                                    <li>
                                        <asp:Label ID="Label8" runat="server" meta:resourcekey="lblCheckIn" CssClass="fB">CheckIn</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;</li>
                                    <li>
                                        <uc7:Calendar ID="CheckIn_AH" runat="server" LowerLimitID="dateDepatrue" UpperLimitID="dateReturn"
                                            IsLowerRepeatDate="1" />
                                    </li>
                                </ul>
                            </div>
                            <div class="right">
                                <ul>
                                    <li>
                                        <asp:Label ID="Label9" runat="server" meta:resourcekey="lblCheckOut" CssClass="fB">CheckOut</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;</li>
                                    <li>
                                        <uc7:Calendar ID="CheckOut_AH" runat="server" LowerLimitID="CheckIn_AH" UpperLimitID="dateReturn"
                                            IsUpperRepeatDate="1" />
                                    </li>
                                </ul>
                            </div>
                            <div class="IBE_package_step_moreSearch_bt_bottomline">
                            </div>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_title">
                            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblPreference">Flight Preference (Optional)</asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <asp:CheckBox ID="chkflexible" runat="server" Text="My dates are flexible +/- 1 day "
                                meta:resourcekey="lblMyDate" />
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <asp:Label ID="Label11" runat="server" meta:resourcekey="lblAirline" CssClass="fB">Airline Name</asp:Label>:&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlAirLine" runat="server">
                                <asp:ListItem Value="all" Text="No Preference"></asp:ListItem>
                                <asp:ListItem Value="AA">Amarican Airlines</asp:ListItem>
                                <asp:ListItem Value="DL">Delta Airlines</asp:ListItem>
                                <asp:ListItem Value="UA">United Airlines</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" runat="server" CssClass="fB">Class</asp:Label>:&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlClass" runat="server">
                               <%-- <asp:ListItem Value="0" Text="No Preference"></asp:ListItem>--%>
                                <asp:ListItem Value="1" Text="Economy / Coach"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Buisness"></asp:ListItem>
                                <asp:ListItem Value="3" Text="First Class"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="IBE_package_step_moreSearch_bt_bottomline">
                            </div>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_title">
                            <asp:Label ID="Label12" runat="server" meta:resourcekey="lblTraveler">Traveler</asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <uc2:TravelerChange ID="TravelerChange1" runat="server" />
                        </div>
                    </div>
                    <div class="btn left" style="width:100%;">
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
            <uc2:FooterP ID="Footer1" runat="server" />
        </div>
    </form>
       <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
