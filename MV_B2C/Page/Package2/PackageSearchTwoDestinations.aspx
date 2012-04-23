<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PackageSearchTwoDestinations.aspx.cs"
    Inherits="PackageSearchTwoDestinations" %>

<%@ Register Src="../../UserControls/LocationTextBoxControl.ascx" TagName="LocationTextBoxControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>

    <script src="<%=SaleWebSuffix + "CommJs/Index_New_Heard.js"%>" type="text/javascript"></script>

    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
              function   ChangeDepSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("listBDepartureAirport")[0];
                index = str.selectedIndex;   
                document.getElementById("txtDepartureFrom_txtCity").value = str[index].text;
//                document.getElementById("lbDepartureCode").value = str[index].value;
              }
              
              function   ChangeDepOneSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("listBDestinationOneAirport")[0];
                index = str.selectedIndex;   
                document.getElementById("txtDestinationOne_txtCity").value = str[index].text;
//                document.getElementById("lbDestinationOneCode").value = str[index].value;
              }
              
              function   ChangeRtnSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("listBReturnAirport")[0];
                index = str.selectedIndex;   
                document.getElementById("txtDestinationTwo_txtCity").value = str[index].text;
//                document.getElementById("lbReturnCode").value = str[index].value;
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
                
                function  CheckCondition(obj)
	            {
	                 var txtOjb = obj;

                    var patt = /[<>@#$&']/;
                    if (patt.test(txtOjb.value))
                    {
                         alert('Conditions contains invalid characters');
                         txtOjb.focus();
                         return;
                    }
	            }
             
    </script>

    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet"
        type="text/css" />
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

</head>
<body onload="setArraylistAH();">
    <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <input id="cityandairport" type="hidden" value="AH" runat="server" />
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <div id="content">
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc3:Navigation ID="Navigation1" runat="server" />
                    </div>
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <asp:Label ID="Label18" runat="server" meta:resourcekey="lblPackageSearch" CssClass="left">Package Search</asp:Label>
                    </div>
                    <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
                        z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
                        marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
                    </iframe>
                    <div class="IBE_package_step_moreSearch_bt">
                        <div class="IBE_package_step_moreSearch_bt_title">
                            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblTypeOfTrip">Type of Trip</asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <input name="radiobutton" type="radio" value="radiobutton" onclick="javascript:location.href='../../PackageIndex.aspx?tab=AH'" />
                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblRoundTrip">Round Trip</asp:Label>
                            <input name="radiobutton" type="radio" value="radiobutton" checked="CHECKED" />
                            <asp:Label ID="Label3" runat="server" meta:resourcekey="lblMultiple">Multiple Cities</asp:Label></div>
                        <div class="IBE_package_step_moreSearch_bt_bottomline">
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_title" style="margin-top: 5px;">
                            <asp:Label ID="Label5" runat="server" meta:resourcekey="lblDepartureReturn">Departure / Return</asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <div class="left">
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblDepartFrom">Depart From (City or Airport)</asp:Label>:
                                &nbsp;&nbsp;&nbsp;&nbsp;<%--<uc7:LocationTextBoxControl ID="txtDepartureFrom" runat="server" />--%>
                                <asp:TextBox ID="txtDepartureFrom" runat="server"></asp:TextBox>
                            </div>
                            <div class="left">
                                <ul>
                                    <li>
                                        <asp:Label ID="Label7" runat="server" meta:resourcekey="lblDepartDate">Depart Date</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;</li>
                                    <li>
                                        <uc6:Calendar ID="dateDeparture" runat="server" />
                                        <asp:Label ID="lblDateDepMsg" runat="server" ForeColor="Red" Text="Please enter date"
                                            Visible="False" meta:resourcekey="lblEnterDate"></asp:Label></li>
                                </ul>
                            </div>
                        </div>
                        <div class="left">
                            <asp:ListBox ID="listBDepartureAirport" runat="server" onchange="ChangeDepSelect()"
                                Width="500px" Visible="False"></asp:ListBox>
                            &nbsp;&nbsp;<asp:Label ID="lbFromSelect" runat="server" Text="Please select an airport."
                                Visible="false" ForeColor="red" meta:resourcekey="lblSelectAirport"></asp:Label>
                            <asp:Label ID="lbDepartureCode" runat="server" Visible="False"></asp:Label>
                        </div>
                        <table width="100%" border="0" cellpadding="3" cellspacing="0" style="border: 1px solid #c1c0c0;
                            float: left; margin: 8px 0px;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" meta:resourcekey="lblDestination1">Destination #1 (City or Airport)</asp:Label>:
                                </td>
                                <td>
                                    <%--<uc7:LocationTextBoxControl ID="txtDestinationOne" runat="server" />--%>
                                    <asp:TextBox ID="txtDestinationOne" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:</td>
                                <td>
                                    <uc6:Calendar ID="dateCheckInOne" runat="server" LowerLimitID="dateDeparture" IsLowerRepeatDate="1" />
                                    <asp:Label ID="lblCheckInOneMsg" runat="server" ForeColor="Red" Text="Please enter date"
                                        Visible="False" meta:resourcekey="lblEnterDate"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:</td>
                                <td>
                                    <uc6:Calendar ID="dateCheckOutOne" runat="server" LowerLimitID="dateCheckInOne" />
                                    <asp:Label ID="lblCheckOutOneMsg" runat="server" ForeColor="Red" Text="Please enter date"
                                        Visible="False" meta:resourcekey="lblEnterDate"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div class="left">
                            <asp:ListBox ID="listBDestinationOneAirport" runat="server" onchange="ChangeDepOneSelect()"
                                Width="500px" Visible="False"></asp:ListBox>
                            &nbsp;<asp:Label ID="lbSelectOne" runat="server" Text="Please select an airport."
                                Visible="false" ForeColor="red" meta:resourcekey="lblSelectAirport">></asp:Label>
                            <asp:Label ID="lbDestinationOneCode" runat="server" Visible="False"></asp:Label>
                        </div>
                        <table width="100%" border="0" cellpadding="3" cellspacing="0" style="border: 1px solid #c1c0c0;
                            float: left; margin: 8px 0px;">
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" meta:resourcekey="lblDestination1">Destination #2 (City or Airport)</asp:Label>:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDestinationTwo" runat="server"></asp:TextBox>
                                    <%--<uc7:LocationTextBoxControl ID="txtDestinationTwo" runat="server" />--%>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" meta:resourcekey="lblCheckIn">Check In</asp:Label>:</td>
                                <td>
                                    <uc6:Calendar ID="dateCheckInTwo" runat="server" LowerLimitID="dateCheckOutOne" IsLowerRepeatDate="1" />
                                    <asp:Label ID="lblCheckInTwoMsg" runat="server" ForeColor="Red" Text="Please enter date"
                                        Visible="False" meta:resourcekey="lblEnterDate"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" meta:resourcekey="lblCheckOut">Check Out</asp:Label>:</td>
                                <td>
                                    <uc6:Calendar ID="dateCheckOutTwo" runat="server" LowerLimitID="dateCheckInTwo" />
                                    <asp:Label ID="lblCheckOutTwoMsg" runat="server" ForeColor="Red" Text="Please enter date"
                                        Visible="False" meta:resourcekey="lblEnterDate"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div class="left">
                            <asp:ListBox ID="listBReturnAirport" runat="server" onchange="ChangeRtnSelect()"
                                Width="500px" Visible="False"></asp:ListBox>
                            &nbsp;<asp:Label ID="lbSelectTwo" runat="server" Text="Please select an airport."
                                Visible="false" ForeColor="red" meta:resourcekey="lblSelectAirport">></asp:Label>
                            <asp:Label ID="lbReturnCode" runat="server" Visible="False"></asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <div class="left">
                                <ul>
                                    <li>
                                        <asp:Label ID="Label14" runat="server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:&nbsp;&nbsp;&nbsp;&nbsp;</li>
                                    <li>
                                        <TermsCalender:TermsCalendar ID="dateReturn" runat="server" ImageUrl="~/Terms.Sales.Web/images/cal.jpg"
                                            Width="100px" ValidationGroup="a" LowerLimitID="dateCheckOutTwo" IsLowerRepeatDate="1"
                                            IsUpperRepeatDate="1" />
                                        <asp:Label ID="lblReturnMsg" runat="server" ForeColor="Red" Text="Please enter date"
                                            Visible="False" meta:resourcekey="lblEnterDate"></asp:Label></li>
                                </ul>
                            </div>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_bottomline">
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_title">
                            <asp:Label ID="Label15" runat="server" meta:resourcekey="lblPreference">Flight Preference (Optional)</asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <asp:CheckBox ID="chbFlexible" runat="server" Text="My dates are flexible +/- 1 day"
                                meta:resourcekey="chbFlexible" />
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <asp:Label ID="Label16" runat="server" meta:resourcekey="lblAirline">Airline Name</asp:Label>:&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlAirLine" runat="server">
                                <asp:ListItem Value="0" Text="No Preference" meta:resourcekey="line0"></asp:ListItem>
                                <asp:ListItem Value="1" Text="American Airline" meta:resourcekey="line1"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Northwest" meta:resourcekey="line2"></asp:ListItem>
                                <asp:ListItem Value="3" Text="United Airline" meta:resourcekey="line3"></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label30" runat="server" CssClass="fB">Class</asp:Label>:&nbsp;&nbsp;
                            <asp:DropDownList ID="ddlClass" runat="server">
                                <asp:ListItem Value="0" Text="Economy" meta:resourcekey="class1"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Business" meta:resourcekey="class2"></asp:ListItem>
                                <asp:ListItem Value="2" Text="First Class" meta:resourcekey="class3"></asp:ListItem>
                            </asp:DropDownList>
                            <div class="IBE_package_step_moreSearch_bt_bottomline">
                            </div>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_title">
                            <asp:Label ID="Label17" runat="server" meta:resourcekey="lblTraveler">Traveler</asp:Label>
                        </div>
                        <div class="IBE_package_step_moreSearch_bt_LI">
                            <uc2:TravelerChange ID="TravelerChange1" runat="server" />
                        </div>
                    </div>
                    <div class="btn left" style="width: 100%; margin-bottom: 20px;">
                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click"
                            ValidationGroup="a" meta:resourcekey="btnSearch" />
                        <asp:Button ID="btnSearch1" runat="server" Text="Search" OnClick="btnSearch1_Click"
                            Visible="False" ValidationGroup="a" meta:resourcekey="btnSearch" />
                    </div>
                    <uc2:FooterP ID="Footer1" runat="server" />
                </div>
            </div>
        </div>
        <p class="clear">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </p>
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
