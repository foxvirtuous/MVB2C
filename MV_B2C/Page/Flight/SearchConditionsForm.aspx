<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true" Inherits="SearchConditionsForm" Codebehind="SearchConditionsForm.aspx.cs" %>

<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<%@ MasterType VirtualPath="BookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

            function   ChangeDepSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("ctl00_MainContent_listBDepartureAirport")[0];
                index = str.selectedIndex;   
                document.getElementById("ctl00_MainContent_txtDepartureFrom").value = str[index].text;
                
              }
              
              function   ChangeToSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("ctl00_MainContent_listBToAirport")[0];
                index = str.selectedIndex;   
                document.getElementById("ctl00_MainContent_txtTo").value = str[index].text;
                
              }
              
               function   ChangeRtnFromSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("ctl00_MainContent_listBReturnFrom")[0];
                index = str.selectedIndex;   
                document.getElementById("ctl00_MainContent_txtReturnFrom").value = str[index].text;
                
              }
              
               function   ChangeRtnToSelect()   
              {   
                var str;
                var index;
                str = document.getElementsByName("ctl00_MainContent_listBReturnTo")[0];
                index = str.selectedIndex;   
                document.getElementById("ctl00_MainContent_txtReturnTo").value = str[index].text;
                
              }
             function UpperCase(obj)
	    {
		    obj.value = obj.value.toUpperCase();
	    }
    	
        function EngAndPoint(obj)
        {
            var keyPressed;
            if (navigator.appName == "Netscape")
            {
                keyPressed = arguments.callee.caller.arguments[0].which;
            }
        	
            else if (navigator.appName == "Microsoft Internet Explorer")
            {
                keyPressed = window.event.keyCode;
            }

            if (!(((keyPressed >= 97) && (keyPressed <= 122)) || ((keyPressed >= 65) && (keyPressed <= 90)) || (keyPressed == 44) || (keyPressed == 47)))
            {
	            var event=window.event||arguments.callee.caller.arguments[0];
	            if(navigator.appName == "Microsoft Internet Explorer")
	            {
		            event.returnValue=false;
	            }
	            else if (navigator.appName == "Netscape")
	            {
		            event.preventDefault();
	            }
            }
            UpperCase(obj);
        }
         function IntxtAirline(objTxt,code)
        {
		    var txtAirline = document.forms[0].elements['ctl00_MainContent_txtAirline'];
//		    var rdbRoundTrip = document.forms[0].elements['rdbRoundTrip'];
//		    var rdbOneway = document.forms[0].elements['rdbOneway'];
//		    var rdbOpenjaw = document.forms[0].elements['rdbOpenjaw'];
    		
            if (Trim(txtAirline.value).length - Trim(txtAirline.value.replace(/(,)/g, "")).length < 4)
            {
                if (Trim(txtAirline.value) != "")
                {
                    if (txtAirline.value.indexOf(code) < 0)
                    {
                        txtAirline.value = txtAirline.value + "," + code;
                    }
                }
                else
                {
                    txtAirline.value = code;
                }
            }
            
//            if (rdbRoundTrip.checked == true)
//            {
//                ChangeFlightType("roundtrip");
//            }
//            else if (rdbOneway.checked == true)
//            {
//                ChangeFlightType("oneway");
//            }
//            else if (rdbOpenjaw.checked == true)
//            {
//                ChangeFlightType("openjaw");
//            }
            
            Hidebullletlist();
        }
        
         function LTrim(str)
        {
            var i;
            for(i=0;i<str.length;i++)
            {
                if(str.charAt(i)!=" "&&str.charAt(i)!=" ")
                    break;
            }
            str=str.substring(i,str.length);
            return str;
        }
        
        function RTrim(str)
        {
            var i;
            for(i=str.length-1;i>=0;i--)
            {
                if(str.charAt(i)!=" "&&str.charAt(i)!=" ")
                    break;
            }
            str=str.substring(0,i+1);
            return str;
        }
        
        function Trim(str)
        {
            return LTrim(RTrim(str));
        }
        
        function Hidebullletlist()
        {
            if(navigator.appName != "Microsoft Internet Explorer")
            {
                HTMLElement.prototype.click = function()
                {
                    var evt = this.ownerDocument.createEvent('MouseEvents');
                    evt.initMouseEvent('click', true, true, this.ownerDocument.defaultView, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
                    this.dispatchEvent(evt);
                }
            }
		    document.getElementById('ctl00_MainContent_lnHelper').click();
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
        
        function InputAirline()
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
             ||  (keyPressed >= 97) && (keyPressed <= 122) || (keyPressed == 8  || keyPressed == 0 || keyPressed == 32 || keyPressed == 44) )))
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
        
         function  CheckCondition(obj)
        {

//            var patt = /[<>@#$&']/;
//            if (patt.test(obj.value))
//            {
//                 alert('Conditions contains invalid characters');
//                 obj.focus();
//                 return false;
//            }
//            else
//            {
                return true;
//            }
        }
    </script>

    <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td align="center">
                <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" class="T_table">
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
                                        <span class="head06"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblNeedInformation">We need a little more information.</asp:Label><asp:Label ID="lblDateErrorMsg" runat="server" Visible=false></asp:Label></span></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <!--<tr>
                            <td colspan="2" align="left">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span class="head09">Type Of Flight</span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="~/images/dot02.gif">
                                            <img src="images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td height="25">
                                            <input name="radiobutton" type="radio" value="radiobutton" checked="checked"></td>
                                        <td>
                                            Round Trip</td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <input value="rdbOneway" name="ctl00$MainContent$rdbType" type="radio" id="ctl00_MainContent_rdbOneway"
                                                onclick="ChangeFlightType('oneway')" /></td>
                                        <td>
                                            One Way</td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <input name="radiobutton" type="radio" value="radiobutton" onclick="javascript:location.href='search_package-2d.html'"></td>
                                        <td>
                                            Mutiple Cities</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>-->
                    <tr>
                        <td colspan="2" align="left">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <span class="head09"><asp:Label ID="Label1" runat="server" meta:resourcekey="lblDepartureFlight">Departure Flight</asp:Label>
                                            <asp:Label ID="lbl_isRoundTrip" runat="server"  meta:resourcekey="lblReturnFlight">&amp; Return Flight</asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td height="3" background="images/dot02.gif">
                                        <img src="images/space.gif" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <div id="div_From" runat="server" visible="false">
                        <tr>
                            <td width="5%" align="left">
                                <b><asp:Label ID="Label3" runat="server" meta:resourcekey="lblFrom">From</asp:Label>:</b></td>
                            <td width="95%" align="left">
                                <asp:TextBox ID="txtDepartureFrom" runat="server" Width="209px"></asp:TextBox></td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table width="80%" border="0" cellspacing="1" cellpadding="3" class="T_line02">
                                    <tr>
                                        <td align="left" bgcolor="#FFFFFF">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="18">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="T_line03">
                                                            <tr>
                                                                <td width="13" align="center">
                                                                    !</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <span class="t05"><asp:Label ID="Label4" runat="server" meta:resourcekey="lblFound">We found more than one airport that matched</asp:Label> '<asp:Label ID="lblFrom"
                                                            runat="server"></asp:Label>'. <asp:Label ID="Label5" runat="server" meta:resourcekey="lblSelectAn">Please select an airport from the list below</asp:Label>.</span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <asp:ListBox ID="listBDepartureAirport" runat="server" onchange="ChangeDepSelect()"
                                    Visible="False"></asp:ListBox>
                                
                                
                            </td>
                        </tr>
                    </div>
                    <div id="div_To" runat="server" visible="false">
                        <tr>
                            <td width="5%" align="left">
                                <b>To:</b></td>
                            <td width="95%" align="left">
                                <asp:TextBox ID="txtTo" runat="server" Width="209px"></asp:TextBox></td>
                        </tr>
                        <tr align="left">
                            <td colspan="4">
                                <table width="80%" border="0" cellspacing="1" cellpadding="3" class="T_line02">
                                    <tr>
                                        <td align="left" bgcolor="#FFFFFF">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="18">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="T_line03">
                                                            <tr>
                                                                <td width="13" align="center">
                                                                    !</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <span class="t05"><asp:Label ID="Label6" runat="server" meta:resourcekey="lblFound">We found more than one airport that matched</asp:Label> '<asp:Label ID="lblTo"
                                                            runat="server"></asp:Label>'. <asp:Label ID="Label7" runat="server" meta:resourcekey="lblSelectAn">Please select an airport from the list below</asp:Label>.</span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <asp:ListBox ID="listBToAirport" runat="server" onchange="ChangeToSelect()" Visible="False">
                                </asp:ListBox>
                               
                            </td>
                        </tr>
                    </div>
                    <div id="div_OpenJw" runat="server" visible="false">
                        <tr align="left">
                            <td colspan="2">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span class="head09"><asp:Label ID="Label8" runat="server" meta:resourcekey="lblReturn">Return Flight</asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="images/dot02.gif">
                                            <img src="images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </div>
                    <div id="div_ReturnFrom" runat="server" visible="false">
                        <tr>
                            <td width="5%" align="left">
                                <b><asp:Label ID="Label9" runat="server" meta:resourcekey="lblFrom">From</asp:Label>:</b></td>
                            <td width="95%" align="left">
                                <asp:TextBox ID="txtReturnFrom" runat="server" Width="209px"></asp:TextBox></td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table width="80%" border="0" cellspacing="1" cellpadding="3" class="T_line02">
                                    <tr>
                                        <td align="left" bgcolor="#FFFFFF">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="18">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="T_line03">
                                                            <tr>
                                                                <td width="13" align="center">
                                                                    !</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <span class="t05"><asp:Label ID="Label10" runat="server" meta:resourcekey="lblFound">We found more than one airport that matched</asp:Label> '<asp:Label ID="lblReturnFrom"
                                                            runat="server"></asp:Label>'. <asp:Label ID="Label11" runat="server" meta:resourcekey="lblSelectAn">Please select an airport from the list below</asp:Label>.</span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <asp:ListBox ID="listBReturnFrom" runat="server" onchange="ChangeRtnFromSelect()"
                                    Visible="False"></asp:ListBox>
                                
                                
                            </td>
                        </tr>
                    </div>
                    <div id="div_ReturnTo" runat="server" visible="false">
                        <tr>
                            <td width="5%" align="left">
                                <b>To:</b></td>
                            <td width="95%" align="left">
                                <asp:TextBox ID="txtReturnTo" runat="server" Width="209px"></asp:TextBox></td>
                        </tr>
                        <tr align="left">
                            <td colspan="4">
                                <table width="80%" border="0" cellspacing="1" cellpadding="3" class="T_line02">
                                    <tr>
                                        <td align="left" bgcolor="#FFFFFF">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="18">
                                                        <table border="0" cellpadding="0" cellspacing="0" class="T_line03">
                                                            <tr>
                                                                <td width="13" align="center">
                                                                    !</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                        <span class="t05"><asp:Label ID="Label13" runat="server" meta:resourcekey="lblFound">We found more than one airport that matched</asp:Label> '<asp:Label ID="lblReturnTo"
                                                            runat="server"></asp:Label>'. <asp:Label ID="Label12" runat="server" meta:resourcekey="lblSelectAn">Please select an airport from the list below</asp:Label>.</span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <asp:ListBox ID="listBReturnTo" runat="server" onchange="ChangeRtnToSelect()" Visible="False">
                                </asp:ListBox>
                                
                            </td>
                        </tr>
                    </div>
                    <tr align="left">
                        <td colspan="2">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <span class="head09"><asp:Label ID="Label14" runat="server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>
                                            <asp:Label ID="lbl_isOneWay" runat="server"  meta:resourcekey="lblReturnDate">/ Return Date</asp:Label></span></td>
                                </tr>
                                <tr>
                                    <td height="3" background="images/dot02.gif">
                                        <img src="images/space.gif" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr align="left">
                                    <td>
                                        <strong><asp:Label ID="Label15" runat="server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>:</strong>
                                    </td>
                                    <td>
                                        <uc7:Calendar ID="departureCalendar" runat="server" />
                                    </td>
                                    <td width="10">
                                    </td>
                                    <!--<td>
                                            Preferred Time:
                                            <select name="select" size="1" tabindex="8">
                                                <option value='AnyTime'>AnyTime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
                                                <option value='12A'>MidNight</option>
                                                <option value='01A' selected="selected">01:00 AM</option>
                                                <option value='02A'>02:00 AM</option>
                                                <option value='03A'>03:00 AM</option>
                                                <option value='04A'>04:00 AM</option>
                                                <option value='05A'>05:00 AM</option>
                                                <option value='06A'>06:00 AM</option>
                                                <option value='07A'>07:00 AM</option>
                                                <option value='08A'>08:00 AM</option>
                                                <option value='09A'>09:00 AM</option>
                                                <option value='10A'>10:00 AM</option>
                                                <option value='11A'>11:00 AM</option>
                                                <option value='12P'>Noon</option>
                                                <option value='01P'>01:00 PM</option>
                                                <option value='02P'>02:00 PM</option>
                                                <option value='03P'>03:00 PM</option>
                                                <option value='04P'>04:00 PM</option>
                                                <option value='05P'>05:00 PM</option>
                                                <option value='06P'>06:00 PM</option>
                                                <option value='07P'>07:00 PM</option>
                                                <option value='08P'>08:00 PM</option>
                                                <option value='09P'>09:00 PM</option>
                                                <option value='10P'>10:00 PM</option>
                                                <option value='11P'>11:00 PM</option>
                                            </select>
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            Duration:
                                            <input type='text' id='txtLengthOfStay2' name='txtLengthOfStay2' size='3' value='7'
                                                onblur='req_script3();' maxlength='3' tabindex='9' readonly="true" />
                                            days</td>-->
                                </tr>
                                <div id="div_OneWay" runat="server">
                                    <tr align="left">
                                        <td>
                                            <strong><asp:Label ID="Label16" runat="server" meta:resourcekey="lblReturnDate1">Return Date</asp:Label>:</strong>
                                        </td>
                                        <td>
                                            <uc7:Calendar ID="returnCalendar" runat="server" />
                                        </td>
                                        <td width="5">
                                        </td>
                                        <!--<td>
                                            Preferred Time:
                                            <select name="dep_time" size="1" tabindex="8">
                                                <option value='AnyTime'>AnyTime&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</option>
                                                <option value='12A' selected="selected">MidNight</option>
                                                <option value='01A'>01:00 AM</option>
                                                <option value='02A'>02:00 AM</option>
                                                <option value='03A'>03:00 AM</option>
                                                <option value='04A'>04:00 AM</option>
                                                <option value='05A'>05:00 AM</option>
                                                <option value='06A'>06:00 AM</option>
                                                <option value='07A'>07:00 AM</option>
                                                <option value='08A'>08:00 AM</option>
                                                <option value='09A'>09:00 AM</option>
                                                <option value='10A'>10:00 AM</option>
                                                <option value='11A'>11:00 AM</option>
                                                <option value='12P'>Noon</option>
                                                <option value='01P'>01:00 PM</option>
                                                <option value='02P'>02:00 PM</option>
                                                <option value='03P'>03:00 PM</option>
                                                <option value='04P'>04:00 PM</option>
                                                <option value='05P'>05:00 PM</option>
                                                <option value='06P'>06:00 PM</option>
                                                <option value='07P'>07:00 PM</option>
                                                <option value='08P'>08:00 PM</option>
                                                <option value='09P'>09:00 PM</option>
                                                <option value='10P'>10:00 PM</option>
                                                <option value='11P'>11:00 PM</option>
                                            </select>
                                        </td>
                                        <td width="5">
                                        </td>
                                        <td>
                                            &nbsp;</td>-->
                                    </tr>
                                </div>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <span class="head09"><asp:Label ID="Label17" runat="server" meta:resourcekey="lblPassengers">Passengers</asp:Label>:</span></td>
                                </tr>
                                <tr>
                                    <td height="3" background="images/dot02.gif">
                                        <img src="images/space.gif" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label18" runat="server" meta:resourcekey="lblAdults">Adults(12+)</asp:Label>:
                                        <asp:DropDownList ID="ddlAdult" runat="server" CssClass="search_sle" Width="35px">
                                            <asp:ListItem Selected="True">1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td width="10">
                                    </td>
                                    <td>
                                        <asp:Label ID="Label19" runat="server" meta:resourcekey="lblChildren">Children(2-11)</asp:Label>:
                                        <asp:DropDownList ID="ddlChild" runat="server" CssClass="search_sle" Width="35px">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <span class="head09"><asp:Label ID="Label20" runat="server" meta:resourcekey="lblPreferences">Preferences</asp:Label>:</span></td>
                                </tr>
                                <tr>
                                    <td height="3" background="images/dot02.gif">
                                        <img src="images/space.gif" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <strong><asp:Label ID="Label21" runat="server" meta:resourcekey="lblClass">Class</asp:Label>:</strong></td>
                                    <td colspan="7">
                                        <asp:RadioButtonList ID="rdoLstCabin" TabIndex="15" runat="server" Width="100%" CssClass="menu"
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="ECONOMY" Selected="True" meta:resourcekey="item1">Economy</asp:ListItem>
                                            <asp:ListItem Value="BUSINESS" meta:resourcekey="item2">Business</asp:ListItem>
                                            <asp:ListItem Value="FIRST" meta:resourcekey="item3">First</asp:ListItem>
                                        </asp:RadioButtonList></td>
                                    <td width="15">
                                    </td>
                                    <td width="5">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <strong><asp:Label ID="Label22" runat="server" meta:resourcekey="lblAirline">Airline</asp:Label>:</strong></td>
                                    <td>
                                        <asp:TextBox ID="txtAirline" runat="server" onblur="EngAndPoint(this)" Width="90"
                                            MaxLength="14" CssClass="search_inp"></asp:TextBox>
                                        (e.g. UA,AA)
                                        
                                        <script type="text/javascript">
                                                    
                                                    function setAirlinePanelHeight(){
                                                        return false;
                                                    }

                                                                    </script>
                                        <asp:LinkButton ID="lnHelper" runat="server" OnClientClick="" OnClick="lnHelper_Click" meta:resourcekey="lblChoose">choose airline</asp:LinkButton></td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td colspan="4">
                                        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                                            TargetControlID="Panel1" CollapseControlID="lnHelper" ExpandControlID="lnHelper"
                                            Collapsed="true">
                                        </ajaxToolkit:CollapsiblePanelExtender>
                                        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%">
                                            <asp:BulletedList ID="BulletedList1" runat="server" DisplayMode="HyperLink">
                                            </asp:BulletedList>
                                            <ajaxToolkit:PagingBulletedListExtender ID="PagingBulletedListExtender1" runat="server"
                                                BehaviorID="PagingBulletedListBehavior1" TargetControlID="BulletedList1" ClientSort="true"
                                                IndexSize="1" Separator=" - " SelectIndexCssClass="selectIndex" UnselectIndexCssClass="unselectIndex" />
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="left">
                        <td colspan="2">
                        </td>
                    </tr>
                </table>
                <asp:Button ID="btnSearch" runat="server" Text="Continue" BorderStyle="none" CssClass="search_btn"
                    OnClick="btnSearch_Click" Style="cursor: hand" meta:resourcekey="btnContinue" />
            </td>
        </tr>
    </table>
    <script type="text/javascript">
        
        if(document.getElementById("ctl00_MainContent_txtDepartureFrom")){
        document.getElementById("ctl00_MainContent_txtDepartureFrom").readOnly="true";
        }
        if(document.getElementById("ctl00_MainContent_txtTo")){
        document.getElementById("ctl00_MainContent_txtTo").readOnly="true";
        }
        if(document.getElementById("ctl00_MainContent_txtReturnFrom")){
        document.getElementById("ctl00_MainContent_txtReturnFrom").readOnly="true";
        }
        if(document.getElementById("ctl00_MainContent_txtReturnTo")){
        document.getElementById("ctl00_MainContent_txtReturnTo").readOnly="true";
        }
       
        
 
    </script>
</asp:Content>
