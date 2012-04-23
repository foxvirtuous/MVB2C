<%@ Page Language="C#" AutoEventWireup="true" Codebehind="promo090319.aspx.cs" Inherits="Terms.Web.Promos.promo090319" %>

<%@ Register Src="~/UserControls/SearchEngineT.ascx" TagName="SearchEngineT" TagPrefix="uc12" %>
<%@ Register Src="~/UserControls/SearchEngineA.ascx" TagName="SearchEngineA" TagPrefix="uc11" %>
<%@ Register Src="~/UserControls/SearchEngineAH.ascx" TagName="SearchEngineAH" TagPrefix="uc10" %>
<%@ Register Src="~/UserControls/SearchEngineH.ascx" TagName="SearchEngineH" TagPrefix="uc9" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/Header.ascx" TagName="Header" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations : We are the experts on traveling to ASIA : Tours</title>
    <meta name="description" content="airline tickets, hotel reservations, find vacation packages, find tours , cruise deals and purchase, China Tours, China Tour Packages, Beijing tour, Shanghai tour, Yangtze River Cruise tours, China Hotel, China Travel Packages.">
    <meta name="keywords" content="Majestic Vacations, Cheap Airfare,Airline Tickets, fly tickets , ticket  reservations , ticket booking , Cheap tickets , Travel, Cheap Airfare, Hotels, Vacations, Airfare, Tours , Cruises, Airline Tickets, Hotel, Vacation, Hotel Reservations, Vacation Packages, Cruise, Travel Agency, Cruise Deals, Discount Airfare, China travel,China tour,China hotel,Beijing tour,Shanghai tour,Yangtze River Cruise">
    <meta name="ROBOTS" content="NOODP">
    <meta name="verify-v1" content="aeVxP6zTHeQzT620ipj5+ikXd/VXcdlKoYUJ/C6vVdY=" />
    <link href="~/css/style_index.css" rel="stylesheet" type="text/css" />
    <script src="../CommJs/Index_New_Heard.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ChangeTab(tabName)
        {
            UnselectTab();
            SelectTab(tabName);
            HideSearchDiv();
            SelectSearchDiv(tabName);
        }
        
        function SelectSearchDiv(tabName)
        {   
            document.getElementById("divSearch" + tabName).style.display = "";
        }
        
        function HideSearchDiv()
        {
            document.getElementById("divSearchF").style.display = "none";
            document.getElementById("divSearchAH").style.display = "none";
            document.getElementById("divSearchH").style.display = "none";
            document.getElementById("divSearchT").style.display = "none";
        }
        
        function SelectTab(tabName)
        {
            if(document.getElementById("tdF") != null)
            {
                document.getElementById("td" + tabName).className = "D_search_on";
                document.getElementById("a" + tabName).className = "search_on";
                document.getElementById("img" + tabName + "l").src = "../images/index/en_on_l.gif";
                document.getElementById("img" + tabName + "r").src = "../images/index/en_on_r.gif";
            }
            
            document.getElementById("CurrentTab").value = tabName;
        }
        
        function UnselectTab()
        {
            if(document.getElementById("tdF") != null)
            {
                document.getElementById("tdF").className = "D_search_off";
                document.getElementById("tdT").className = "D_search_off";
                document.getElementById("tdAH").className = "D_search_off";
                document.getElementById("tdH").className = "D_search_off";
                //document.getElementById("tdC").className = "D_search_off";
                
                document.getElementById("aF").className = "search_off";
                document.getElementById("aT").className = "search_off";
                document.getElementById("aAH").className = "search_off";
                document.getElementById("aH").className = "search_off";
                //document.getElementById("aC").className = "search_off";
                
                document.getElementById("imgFl").src = "../images/index/en_off_l.gif";
                document.getElementById("imgFr").src = "../images/index/en_off_r.gif";
                document.getElementById("imgAHl").src = "../images/index/en_off_l.gif";
                document.getElementById("imgAHr").src = "../images/index/en_off_r.gif";
                document.getElementById("imgHl").src = "../images/index/en_off_l.gif";
                document.getElementById("imgHr").src = "../images/index/en_off_r.gif";
                document.getElementById("imgTl").src = "../images/index/en_off_l.gif";
                document.getElementById("imgTr").src = "../images/index/en_off_r.gif";
            }
        }
        
        
function ChangeFlightType(type)
	    {
		    var flightType = document.forms[0].elements['SearchEngineA1_FlightType'];
    		
		    if( type == "roundtrip")
		    {
			    flightType.value = "roundtrip";
			    document.getElementsByTagName("*").SearchEngineA1_oneway1.style.display  = "";
			    document.getElementsByTagName("*").SearchEngineA1_oneway2.style.display  = "";
			    //document.getElementsByTagName("*").oneway3.style.display  = "";
			    document.getElementsByTagName("*").SearchEngineA1_rtnFromCity_txtCity.readOnly    = true;
			    document.getElementsByTagName("*").SearchEngineA1_rtnToCity_txtCity.readOnly      = true;
    			
			    var txtDepCity = document.forms[0].elements['SearchEngineA1_depCity_txtCity'];
                var txtDesCity = document.forms[0].elements['SearchEngineA1_toCity_txtCity'];
          
			    document.getElementsByTagName("*").SearchEngineA1_rtnFromCity_txtCity.value       = txtDesCity.value;
			    document.getElementsByTagName("*").SearchEngineA1_rtnToCity_txtCity.value         = txtDepCity.value;
    			
		    }
		    else if(type == "oneway")
		    {
			    flightType.value = "oneway";
			    document.getElementsByTagName("*").SearchEngineA1_oneway1.style.display  = "none";
			    document.getElementsByTagName("*").SearchEngineA1_oneway2.style.display  = "none";
			    //document.getElementsByTagName("*").oneway3.style.display  = "none";
			   // document.getElementsByTagName("*").txtLengthOfStay.value    = "";
			    
			    document.getElementsByTagName("*").SearchEngineA1_rtnFromCity_txtCity.readOnly    = false;
			    document.getElementsByTagName("*").SearchEngineA1_rtnToCity_txtCity.readOnly      = false;
		    }
		    else if(type == "openjaw")
		    {
			    flightType.value = "openjaw";
			    document.getElementsByTagName("*").SearchEngineA1_oneway1.style.display  = "";
			    document.getElementsByTagName("*").SearchEngineA1_oneway2.style.display  = "";
			    //document.getElementsByTagName("*").oneway3.style.display  = "";
			    document.getElementsByTagName("*").SearchEngineA1_rtnFromCity_txtCity.readOnly    = false;
			    document.getElementsByTagName("*").SearchEngineA1_rtnToCity_txtCity.readOnly      = false;
		    }
    		
		    //SetLengthOfStay();
	    }
	function ChangeTourType(type)
		            {
			            if( type == "LandOnly")
			            {
				            document.getElementsByTagName("*").SearchEngineT1_tr_DeptCity.style.display = "none";
				          
			            }
			            else if(type == "AirLand")
			            {
				            
				            document.getElementsByTagName("*").SearchEngineT1_tr_DeptCity.style.display = "";
				           
			            }
		            }
            		
	    function SetReturnCity()
	    {
		    var flightType = document.forms[0].elements['SearchEngineA1_FlightType'];
            var txtDepCity = document.forms[0].elements['SearchEngineA1_depCity_txtCity'];
            var txtDesCity = document.forms[0].elements['SearchEngineA1_toCity_txtCity'];

            if(!CheckCondition(txtDepCity) || !CheckCondition(txtDesCity)) return;
            else
            {
	            if (flightType.value != "openjaw")
	            {
	                var txtRtnFrom = document.forms[0].elements['SearchEngineA1_rtnFromCity_txtCity'];
	                var txtRtnTo = document.forms[0].elements['SearchEngineA1_rtnToCity_txtCity'];
		            txtRtnFrom.value = txtDesCity.value;
		            txtRtnTo.value = txtDepCity.value;
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
	    
    	
	    function SetLengthOfStay()
	    {
	        var rdbOneway = document.forms[0].elements['SearchEngineA1_rdbOneway'];
    	   
	        if(!rdbOneway.checked)
	        {
                var input1 = document.forms[0].elements['SearchEngineA1_depFlightCalendar_calendarDate'];
                var input2 = document.forms[0].elements['SearchEngineA1_rtnFlightCalendar_calendarDate'];
                var txtLengthOfStay = document.forms[0].elements['SearchEngineA1_txtLengthOfStay'];
    	        
                if (isNaN(new Date(input2.value)-new Date(input1.value)) || new Date(input2.value)-new Date(input1.value) < 0)
                {
                    txtLengthOfStay.value = 0;
                }
                else
                {
                   txtLengthOfStay.value = Math.round((new Date(input2.value)-new Date(input1.value))/86400000);
                }
            }
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
        
        function setAirlinePanelHeight()
        {
            document.getElementById('SearchEngineA1_Panel1').style.height=315 +"px";
            document.getElementById('SearchEngineA1_Panel1').style.height="auto";
            return false;
        }
        
        function IntxtAirline(objTxt,code)
        {
		    var txtAirline = document.forms[0].elements['SearchEngineA1_txtAirline'];
		    var rdbRoundTrip = document.forms[0].elements['SearchEngineA1_rdbRoundTrip'];
		    var rdbOneway = document.forms[0].elements['SearchEngineA1_rdbOneway'];
		    var rdbOpenjaw = document.forms[0].elements['SearchEngineA1_rdbOpenjaw'];
    		
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
		    document.getElementById('SearchEngineA1_lnHelper').click();
        }
        
        window.onload = function ChangeToCurrentTab()
        {
            ChangeTab(document.getElementById("CurrentTab").value);
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
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <uc3:Header ID="Header1" runat="server" />
        <input id="CurrentTab" type="hidden" value="F" name="DefaultTab" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../CommJs/Mvcalx.htm">
        </iframe>
        <asp:ScriptManager ID="MainScriptManager" runat="server" ScriptMode="release" LoadScriptsBeforeUI="false" />
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td colspan="2">
                    <a href="/">
                        <img src="/images/v2/top.gif" border="0"></a></td>
            </tr>
            <tr>
                <td width="305" align="left" valign="top">
                    <table width="305" border="0" style="text-align: left" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <!-- Search Begin -->
                                <table width="305" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <!-- Search Tab Begin -->
                                    <tr>
                                        <td class="D_search_top">
                                            <div id="divSearchTab" runat="server">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr align="center">
                                                        <td width="5">
                                                            <img id="imgFl" src="../images/index/en_on_l.gif" /></td>
                                                        <td id="tdF" class="D_search_on">
                                                            <a id="aF" href="javascript:ChangeTab('F')" class="search_on">Flights</a></td>
                                                        <td width="5">
                                                            <img id="imgFr" src="../images/index/en_on_r.gif" /></td>
                                                        <td width="2">
                                                        </td>
                                                        <td width="5">
                                                            <img id="imgAHl" src="../images/index/en_off_l.gif" /></td>
                                                        <td id="tdAH" class="D_search_off">
                                                            <a id="aAH" href="javascript:ChangeTab('AH')" class="search_off">Air+Hotel</a></td>
                                                        <td width="5">
                                                            <img id="imgAHr" src="../images/index/en_off_r.gif" /></td>
                                                        <td width="2">
                                                        </td>
                                                        <td width="5">
                                                            <img id="imgHl" src="../images/index/en_off_l.gif" /></td>
                                                        <td id="tdH" class="D_search_off">
                                                            <a id="aH" href="javascript:ChangeTab('H')" class="search_off" runat="server">Hotels</a></td>
                                                        <td width="5">
                                                            <img id="imgHr" src="../images/index/en_off_r.gif" /></td>
                                                        <td width="2">
                                                        </td>
                                                        <td width="5">
                                                            <img id="imgTl" src="../images/index/en_off_l.gif" /></td>
                                                        <td id="tdT" class="D_search_off">
                                                            <a id="aT" href="javascript:ChangeTab('T')" class="search_off">Tour</a></td>
                                                        <td width="5">
                                                            <img id="imgTr" src="../images/index/en_off_r.gif" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <!-- Search Tab End -->
                                    <!-- Search Body Begin -->
                                    <tr class="R_search">
                                        <td valign="top">
                                            <table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="10">
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- Flight Search Body Begin -->
                                            <div id="divSearchF">
                                                <uc11:SearchEngineA ID="SearchEngineA1" runat="server"></uc11:SearchEngineA>
                                            </div>
                                            <!-- Flight Search Body End -->
                                            <!-- Air + Hotel Search Body Begin -->
                                            <div id="divSearchAH" style="display: none">
                                                <uc10:SearchEngineAH ID="SearchEngineAH1" runat="server"></uc10:SearchEngineAH>
                                            </div>
                                            <!-- Air + Hotel Search Body End -->
                                            <!-- Hotel Search Body Begin -->
                                            <div id="divSearchH" style="display: none">
                                                <uc9:SearchEngineH ID="SearchEngineH1" runat="server" />
                                            </div>
                                            <!-- Hotel Search Body End -->
                                            <!-- Tour Search Body Begin -->
                                            <div id="divSearchT" style="display: none">
                                                <uc12:SearchEngineT ID="SearchEngineT1" runat="server" />
                                            </div>
                                            <!-- Tour Search Body End -->
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img src="../images/index/en_bot.gif" /></td>
                                    </tr>
                                </table>
                                <!-- Search end -->
                            </td>
                        </tr>
                    </table>
                    <table width="305" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="10">
                            </td>
                        </tr>
                    </table>
                    <iframe src="../Html/map.htm" width="305" height="250" name="ifrm" id="ifrm" scrolling="no"
                        frameborder="0"></iframe>
                    <iframe src="../Html/extra.htm" width="305" height="200" name="ifrm" id="Iframe1"
                        scrolling="no" frameborder="0"></iframe>
                </td>
                <td width="615" align="right" valign="top">

                    <script type="text/javascript" src="tour/090319.js"></script>

                </td>
            </tr>
        </table>
        <uc2:Footer ID="footer1" runat="server" />
    </form>
</body>
</html>
