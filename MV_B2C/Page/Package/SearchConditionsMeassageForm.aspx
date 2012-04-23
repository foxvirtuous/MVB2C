<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="SearchConditionsMeassageForm" Codebehind="SearchConditionsMeassageForm.aspx.cs" %>

<%@ Register Src="~/UserControls/LocationTextBoxControl.ascx" TagName="LocationTextBoxControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/TravelerChange.ascx" TagName="TravelerChange" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"  type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
    

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
                document.getElementById("txtTo").value = str[index].text;
                //document.getElementById("lbReturnCode").value = str[index].value;
              }
             

    function ChangeFlightType(type)
	    {
		    var flightType = document.forms[0].elements['ctl00_MainContent_FlightType'];
    		
		    if( type == "roundtrip")
		    {
			    flightType.value = "roundtrip";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_OneWay.style.display  = "";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_OpenJw.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnFrom.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnTo.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnFromMessage.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnToMessage.style.display  = "none";
			    
			    document.getElementsByTagName("*").ctl00_MainContent_lbl_isOneWay.style.display  = "";
			    
			    //document.getElementsByTagName("*").oneway2.style.display  = "";
			    //document.getElementsByTagName("*").oneway3.style.display  = "";
			    //document.getElementsByTagName("*").txtRtnFrom.readOnly    = true;
			    //document.getElementsByTagName("*").txtRtnTo.readOnly      = true;
    			
			    //var txtDepCity = document.forms[0].elements['ctl00_MainContent_txtDepartureFrom_txtCity'];
                //var txtDesCity = document.forms[0].elements['ctl00_MainContent_txtTo_txtCity'];
          
			    //document.getElementsByTagName("*").txtRtnFrom.value       = txtDesCity.value;
			    //document.getElementsByTagName("*").txtRtnTo.value         = txtDepCity.value;
    			
		    }
		    else if(type == "oneway")
		    {
			    flightType.value = "oneway";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_OneWay.style.display  = "none"
			    document.getElementsByTagName("*").ctl00_MainContent_tr_OpenJw.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnFrom.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnTo.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnFromMessage.style.display  = "none";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnToMessage.style.display  = "none";
			     document.getElementsByTagName("*").ctl00_MainContent_lbl_isOneWay.style.display  = "none";
			    //document.getElementsByTagName("*").oneway2.style.display  = "none";
			    //document.getElementsByTagName("*").oneway3.style.display  = "none";
			    //document.getElementsByTagName("*").txtLengthOfStay.value    = "";
			    
			    //document.getElementsByTagName("*").txtRtnFrom.readOnly    = false;
			    //document.getElementsByTagName("*").txtRtnTo.readOnly      = false;
		    }
		    else if(type == "openjaw")
		    {
			    flightType.value = "openjaw";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_OneWay.style.display  = "";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_OpenJw.style.display  = "";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnFrom.style.display  = "";
			    document.getElementsByTagName("*").ctl00_MainContent_tr_ReturnTo.style.display  = "";
			     document.getElementsByTagName("*").ctl00_MainContent_lbl_isOneWay.style.display  = "";
			    //document.getElementsByTagName("*").oneway2.style.display  = "";
			    //document.getElementsByTagName("*").oneway3.style.display  = "";
			    //document.getElementsByTagName("*").txtRtnFrom.readOnly    = false;
			    //document.getElementsByTagName("*").txtRtnTo.readOnly      = false;
		    }
    		
		    //SetLengthOfStay();
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
		    var rdbRoundTrip = document.forms[0].elements['ctl00_MainContent_rdbRoundTrip'];
		    var rdbOneway = document.forms[0].elements['ctl00_MainContent_rdbOneway'];
		    var rdbOpenjaw = document.forms[0].elements['ctl00_MainContent_rdbOpenjaw'];
    		
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
            
            if (rdbRoundTrip.checked == true)
            {
                ChangeFlightType("roundtrip");
            }
            else if (rdbOneway.checked == true)
            {
                ChangeFlightType("oneway");
            }
            else if (rdbOpenjaw.checked == true)
            {
                ChangeFlightType("openjaw");
            }
            
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
        
    </script>

    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <input id="FlightType" type="hidden" value="roundtrip" name="FlightType" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
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
                                            <span class="head06"><asp:Label ID="Label2" runat="server" meta:resourcekey="lblClarifySearch">Please clarify your search</asp:Label>.</span></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <div id="div_NoFlights" runat="server" visible="false">
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
                                                            <span class="t05"><asp:Label ID="Label3" runat="server" meta:resourcekey="lblMsg">There are no flights met your search criteria. Please re-seach,<br>
                                                                or call our experienced Sale Agents at 1-(888)-288-7528. Thank You!!</asp:Label> </span>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </div>
                        <tr align="left">
                            <td colspan="2">
                            </td>
                        </tr>
                        <%--<tr>
                            <td colspan="2" align="left">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span class="head09">Type Of Flight</span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="../../images/dot02.gif">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr valign="middle">
                                        <td height="25">
                                            <input onclick="ChangeFlightType('roundtrip')" type="radio" name="rdbType" id="rdbRoundTrip"
                                                runat="server" checked /></td>
                                        <td>
                                            Round Trip</td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <input onclick="ChangeFlightType('oneway')" type="radio" name="rdbType" id="rdbOneway"
                                                runat="server" /></td>
                                        <td>
                                            One Way</td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            <input onclick="ChangeFlightType('openjaw')" type="radio" name="rdbType" id="rdbOpenjaw"
                                                runat="server" /></td>
                                        <td>
                                            Mutiple Cities</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="2" align="left">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span class="head09"><asp:Label ID="Label4" runat="server" meta:resourcekey="lblDepartureFlight">Departure Flight</asp:Label>
                                                <asp:Label ID="lbl_isRoundTrip" runat="server" meta:resourcekey="lblReturnFlight">&amp; Return Flight</asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="../../images/dot02.gif">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                            </td>
                        </tr>
                        <div id="div_From" runat="server" visible="false">
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
                                                            <span class="t05"><asp:Label ID="Label5" runat="server" meta:resourcekey="lblNotFind">We could not find any airports that match your search for</asp:Label> '<asp:Label
                                                                ID="lblFrom" runat="server"></asp:Label>'.<br>
                                                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblEnterCity">Please enter a new city name, airport name, or airport code.</asp:Label></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </div>
                        <div id="div_From1" runat="server" visible="true">
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
                                                            <span class="t05"><asp:Label ID="Label7" runat="server" meta:resourcekey="lblEnterDepCity">Please enter a departure city</asp:Label></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </div>
                        <tr>
                            <td width="5%" align="left">
                                <b><asp:Label ID="Label8" runat="server" meta:resourcekey="lblFrom">From</asp:Label>:</b></td>
                            <td width="95%" align="left">
                                <%-- <uc3:LocationTextBoxControl ID="" runat="server" />--%>
                                <asp:TextBox ID="txtDepartureFrom" runat="server" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDepartureFrom"
                                    ErrorMessage="Please enter departure city"></asp:RequiredFieldValidator></td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <asp:ListBox ID="listBDepartureAirport" runat="server" onchange="ChangeDepSelect()"
                                    Visible="False"></asp:ListBox>
                                &nbsp;<asp:Label ID="lbSelect" runat="server" Text="Please select an airport." Visible="false"
                                    ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <div id="div_To" runat="server" visible="false">
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
                                                            <span class="t05"><asp:Label ID="Label9" runat="server" meta:resourcekey="lblNotFind">We could not find any airports that match your search for</asp:Label> '<asp:Label
                                                                ID="lblTo" runat="server"></asp:Label>'.<br>
                                                                <asp:Label ID="Label10" runat="server" meta:resourcekey="lblEnterCity">Please enter a new city name, airport name, or airport code.</asp:Label></span></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </div>
                        <tr>
                            <td width="5%" align="left">
                                <b><asp:Label ID="Label11" runat="server" meta:resourcekey="lblTo">To</asp:Label>:</b></td>
                            <td width="95%" align="left">
                                <%--<uc3:LocationTextBoxControl ID="txtTo" runat="server" />--%>
                                <asp:TextBox ID="txtTo" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <asp:ListBox ID="listBReturnAirport" runat="server" onchange="ChangeRtnSelect()"
                                    Visible="False"></asp:ListBox>
                                &nbsp;<asp:Label ID="lbRtnSelect" runat="server" Text="Please select an airport."
                                    Visible="false" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <%-- <tr id="tr_OpenJw" runat="server" style="display: none" align="left">
                            <td colspan="2">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span class="head09">Return Flight</span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="images/dot02.gif">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr id="tr_ReturnFromMessage" runat="server" style="display: none">
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
                                                        <span class="t05">We could not find any airports that match your search for '<asp:Label
                                                            ID="lblReturnFrom" runat="server"></asp:Label>'.<br>
                                                            Please enter a new city name, airport name, or airport code.</span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="tr_ReturnFrom" runat="server" style="display: none">
                            <td width="5%" align="left">
                                <b>From:</b></td>
                            <td width="95%" align="left">
                                <uc3:LocationTextBoxControl ID="txtReturnFrom" runat="server" />
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                            </td>
                        </tr>
                        <tr id="tr_ReturnToMessage" runat="server" style="display: none">
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
                                                        <span class="t05">We could not find any airports that match your search for '<asp:Label
                                                            ID="lblReturnTo" runat="server"></asp:Label>'.<br>
                                                            Please enter a new city name, airport name, or airport code.</span></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr id="tr_ReturnTo" runat="server" style="display: none">
                            <td width="5%" align="left">
                                <b>To:</b></td>
                            <td width="95%" align="left">
                                <uc3:LocationTextBoxControl ID="txtReturnTo" runat="server" />
                            </td>
                        </tr>--%>
                        <tr align="left">
                            <td colspan="2">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <span class="head09"><asp:Label ID="Label12" runat="server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>
                                                <asp:Label ID="lbl_isOneWay" runat="server" meta:resourcekey="lblReturnDate">/ Return Date</asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="../../images/dot02.gif">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr align="left">
                                        <td>
                                            <strong><asp:Label ID="Label13" runat="server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>:</strong>
                                        </td>
                                        <td>
                                            <uc7:Calendar ID="departureCalendar" runat="server" />
                                            
                                        </td>
                                        <td>
                                    
                                            <asp:Label ID="lbDepDateErr" Visible="false" runat="server" ForeColor="Red" Text="Date format error!" meta:resourcekey="lblDateFormat" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="5px">
                                        </td>
                                    </tr>
                                    <tr id="tr_OneWay" runat="server" align="left">
                                        <td>
                                            <strong><asp:Label ID="Label14" runat="server" meta:resourcekey="lblRtnDate">Return Date</asp:Label>:</strong>
                                        </td>
                                        <td>
                                            <uc7:Calendar ID="returnCalendar" runat="server" LowerLimitID="departureCalendar" />
                                            
                                        </td>
                                        <td >
                                        &nbsp;<asp:Label ID="lbRtnDateErr" Visible="false" runat="server" ForeColor="Red"
                                                Text="Date format error!" meta:resourcekey="lblDateFormat" ></asp:Label>
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
                                            <span class="head09"><asp:Label ID="Label15" runat="server" meta:resourcekey="lblCheckInDate">CheckIn Date</asp:Label>
                                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCheckOutDate">/ CheckOut Date</asp:Label></span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="../../images/dot02.gif">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr align="left">
                                        <td>
                                            <strong><asp:Label ID="Label16" runat="server" meta:resourcekey="lblCheckInDate">CheckIn Date</asp:Label>:</strong>
                                        </td>
                                        <td>
                                            <uc7:Calendar ID="dateCheckIn" runat="server" LowerLimitID="departureCalendar" UpperLimitID="returnCalendar"
                                                IsLowerRepeatDate="1" />
                                            
                                        </td>
                                        <td >
                                        &nbsp;<asp:Label ID="lbCheckInErr" Visible="false" runat="server" ForeColor="Red"
                                                Text="Date format error!" meta:resourcekey="lblDateFormat"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="5px">
                                        </td>
                                    </tr>
                                    <tr id="tr1" runat="server" align="left">
                                        <td>
                                            <strong><asp:Label ID="Label17" runat="server" meta:resourcekey="lblCheckODate">CheckOut Date</asp:Label>:</strong>
                                        </td>
                                        <td>
                                            <uc7:Calendar ID="dateCheckOut" runat="server" LowerLimitID="dateCheckIn" UpperLimitID="returnCalendar"
                                                IsUpperRepeatDate="1" />
                                            
                                        </td>
                                        <td >
                                        &nbsp;<asp:Label ID="lbCheckOutErr" Visible="false" runat="server" ForeColor="Red"
                                                Text="Date format error!" meta:resourcekey="lblDateFormat"></asp:Label>
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
                                            <span class="head09"><asp:Label ID="Label18" runat="server" meta:resourcekey="lblPassengers">Passengers</asp:Label>:</span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="../../images/dot02.gif">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <%--Adults(12+):
                                            <asp:DropDownList ID="ddlAdult" runat="server" CssClass="search_sle" Width="35px">
                                                <asp:ListItem>0</asp:ListItem>
                                                <asp:ListItem Selected="True">1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="10">
                                        </td>
                                        <td>
                                            Children(2-11):
                                            <asp:DropDownList ID="ddlChild" runat="server" CssClass="search_sle" Width="35px">
                                                <asp:ListItem>0</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                            </asp:DropDownList>--%>
                                            <uc2:TravelerChange ID="TravelerChange1" runat="server" />
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
                                            <span class="head09"><asp:Label ID="Label19" runat="server" meta:resourcekey="lblPreferences">Preferences</asp:Label>:</span></td>
                                    </tr>
                                    <tr>
                                        <td height="3" background="../../images/dot02.gif">
                                            <img src="../../images/space.gif" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="left">
                            <td colspan="2">
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <strong><asp:Label ID="Label20" runat="server" meta:resourcekey="lblClass">Class</asp:Label>:</strong></td>
                                        <td colspan="7">
                                            <asp:RadioButtonList ID="rdoLstCabin" TabIndex="15" runat="server" Width="10%" CssClass="menu"
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
                                            <strong><asp:Label ID="Label21" runat="server" meta:resourcekey="lblAirline">Airline</asp:Label>:</strong></td>
                                        <td>
                                            <asp:TextBox ID="txtAirline" runat="server" onblur="EngAndPoint(this)" Width="90"
                                                MaxLength="14" CssClass="search_inp"></asp:TextBox>
                                            (e.g. UA,AA)
                                            <asp:LinkButton ID="lnHelper" runat="server" OnClientClick="return false;" meta:resourcekey="lkChoose">choose airline</asp:LinkButton></td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0">
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
                        Style="cursor: hand" OnClick="btnSearch_Click"  meta:resourcekey="btnContinue"/>
                    <asp:Button ID="btnSearch1" runat="server" Text="Continue" BorderStyle="none" CssClass="search_btn"
                        Style="cursor: hand" OnClick="btnSearch1_Click" Visible="false"  meta:resourcekey="btnContinue"/>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
