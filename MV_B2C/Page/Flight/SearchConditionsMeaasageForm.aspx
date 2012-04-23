<%@ Page Language="C#" MasterPageFile="BookingPage.Master" AutoEventWireup="true"
    Inherits="SearchConditionsMeaasageForm" Codebehind="SearchConditionsMeaasageForm.aspx.cs"
    EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/ForbiddenAirportControl.ascx" TagName="ForbiddenAirportControl"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/LocationTextBoxControl.ascx" TagName="LocationTextBoxControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/Calendar.ascx" TagName="Calendar" TagPrefix="uc7" %>
<%@ MasterType VirtualPath="BookingPage.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="SearchConditionsMeaasageForm" defaultbutton="btnSearch">

        <script type="text/javascript">
    function ChangeFlightType(type)
	    {
		    var flightType = document.forms[0].elements['ctl00_MainContent_FlightType'];
    		
		    if( type == "roundtrip")
		    {
			    flightType.value = "roundtrip";
			    document.getElementById("ctl00_MainContent_tr_OneWay").style.display  = "";
			    document.getElementById("ctl00_MainContent_tr_ReturnFrom").style.display  = "none";
			    document.getElementById("ctl00_MainContent_tr_ReturnTo").style.display  = "none";
			    document.getElementById("ctl00_MainContent_tr_ReturnFromMessage").style.display  = "none";
			    document.getElementById("ctl00_MainContent_tr_ReturnToMessage").style.display  = "none";
		    }
		    else if(type == "oneway")
		    {
			    flightType.value = "oneway";
			    document.getElementById("ctl00_MainContent_tr_OneWay").style.display  = "none"
			    document.getElementById("ctl00_MainContent_tr_ReturnFrom").style.display  = "none";
			    document.getElementById("ctl00_MainContent_tr_ReturnTo").style.display  = "none";
			    document.getElementById("ctl00_MainContent_tr_ReturnFromMessage").style.display  = "none";
			    document.getElementById("ctl00_MainContent_tr_ReturnToMessage").style.display  = "none";
		    }
		    else if(type == "openjaw")
		    {
			    flightType.value = "openjaw";
			    document.getElementById("ctl00_MainContent_tr_OneWay").style.display  = "";
			    document.getElementById("ctl00_MainContent_tr_ReturnFrom").style.display  = "";
			    document.getElementById("ctl00_MainContent_tr_ReturnTo").style.display  = "";
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
        
        window.onload = function ChangeFlightTypeWhenPageRefresh()
        {
            var flightType = document.forms[0].elements['ctl00_MainContent_FlightType'];
            ChangeFlightType(flightType.value);
        }
        
        function ChangeFlightTypeValidate(type)
	                                    {
	                                    var today = new Date();   
                                        var day = today.getDate();   
                                        var month = today.getMonth() + 1;   
                                        var year = today.getYear();   
                                        var date = month + "/" + day + "/" + year;  
                                        var returndate = addDate(4,21);

                                    		
		                                    if( type == "roundtrip")
		                                    {
                                    			if(document.getElementById("ctl00_MainContent_txtReturnFrom_txtCity").value  == "")
                                                {
                                                
                                                
                                                   document.getElementById("ctl00_MainContent_txtReturnFrom_txtCity").value  = document.getElementById("ctl00_MainContent_txtTo_txtCity").value ; 

                                                }
                                                
                                                if(document.getElementById("ctl00_MainContent_txtReturnTo_txtCity").value  == "")
                                                {
                                                
                                                
                                                   document.getElementById("ctl00_MainContent_txtReturnTo_txtCity").value  = document.getElementById("ctl00_MainContent_txtDepartureFrom_txtCity").value ; 

                                                }
		                                    }
		                                    else if(type == "oneway")
		                                    {
		                                       
                                                if(document.getElementById("ctl00_MainContent_returnCalendar_calendarDate").value  == ""
                                                || document.getElementById("ctl00_MainContent_returnCalendar_calendarDate").value  == "__/__/____")
                                                {
                                              
                                                   document.getElementById("ctl00_MainContent_returnCalendar_calendarDate").value  = returndate; 

                                                }
                                                
                                                if(document.getElementById("ctl00_MainContent_txtReturnFrom_txtCity").value  == "")
                                                {
                                                
                                               
                                                   document.getElementById("ctl00_MainContent_txtReturnFrom_txtCity").value  = document.getElementById("ctl00_MainContent_txtTo_txtCity").value ; 

                                                }
                                                
                                                if(document.getElementById("ctl00_MainContent_txtReturnTo_txtCity").value  == "")
                                                {
                                                
                                               
                                                   document.getElementById("ctl00_MainContent_txtReturnTo_txtCity").value  = document.getElementById("ctl00_MainContent_txtDepartureFrom_txtCity").value ; 

                                                }

		                                    }
		                                    else if(type == "openjaw")
		                                    {
		                                    }
	                                    }
	                                    
	                                    function addDate(type,NumDay){
                                       var date = new Date();
                                     type = parseInt(type); //类型
                                     lIntval = parseInt(NumDay);//间隔
                                      switch(type){
                                       case 6 ://年
                                      date.setYear(date.getYear() + lIntval)
                                      break;
                                     case 7 ://季度
                                      date.setMonth(date.getMonth() + (lIntval * 3) )
                                      break;
                                     case 5 ://月
                                      date.setMonth(date.getMonth() + lIntval)
                                      break;
                                     case 4 ://天
                                      date.setDate(date.getDate() + lIntval)
                                      break
                                     case 3 ://时
                                      date.setHours(date.getHours() + lIntval)
                                      break
                                     case 2 ://分
                                      date.setMinutes(date.getMinutes() + lIntval)
                                      break
                                     case 1 ://秒
                                      date.setSeconds(date.getSeconds() + lIntval)
                                      break;
                                     default:
                                        
                                      } 
                                     return (date.getMonth()+1) +"/" + date.getDate()  + "/" +date.getFullYear();
                                      } 
        
        </script>

        <input id="FlightType" type="hidden" value="roundtrip" name="FlightType" runat="server" />
        <div class="searchFormMain">
            <div class="searchFormMain_Content">
                <ol class="searchFormMain_Content_title">
                    <asp:Label ID="label1" runat="server" meta:resourcekey="lblPleaseSearch">Please clarify your search.</asp:Label></ol>
                <div runat="server" id="divIsError" visible="true">
                    <span class="searchFormMain_Content_warn">
                        <div class="searchFormMain_Content_warn_block">
                            !</div>
                        <asp:Label ID="label2" runat="server" meta:resourcekey="lblThereAt">There are no flights met your search criteria. Please re-seach,<br>
                                                            or call our experienced Sale Agents at </asp:Label><asp:Label ID="label32" runat="server">1-(888)-288-7528 </asp:Label><asp:Label
                                                                ID="label3" runat="server" meta:resourcekey="lblThankYou">. Thank You!! </asp:Label><asp:Label
                                                                    ID="lblDateErrorMsg" runat="server" Visible="false"></asp:Label></span></div>
                <div id="div_NoFlights" runat="server" style="display: none">
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        1</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label4" runat="server"
                        meta:resourcekey="lblTypeOfFligt">Type Of Flight</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_RB">
                    <input onclick="ChangeFlightType('roundtrip')" type="radio" name="rdbType" id="rdbRoundTrip"
                        runat="server" checked />
                    <asp:Label ID="Label5" runat="Server" meta:resourcekey="lblRoundTrip">RoundTrip</asp:Label>
                    <input onclick="ChangeFlightType('oneway');ChangeFlightTypeValidate('oneway')" type="radio"
                        name="rdbType" id="rdbOneway" runat="server" />
                    <asp:Label ID="Label6" runat="Server" meta:resourcekey="lblOneWay">OneWay</asp:Label>
                    <input onclick="ChangeFlightType('openjaw')" type="radio" name="rdbType" id="rdbOpenjaw"
                        runat="server" />
                    <asp:Label ID="Label7" runat="Server" meta:resourcekey="lblMutipleCities">Mutiple Cities</asp:Label>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        2</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="label8" runat="server"
                        meta:resourcekey="lblTwo">Where and when do you want to travel?</asp:Label>
                    </span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <div runat="server" style="display: none" id="div_From">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="Label9" runat="Server" meta:resourcekey="lblWeFor">We could not find any airports that match your search for '</asp:Label><asp:Label
                                ID="lblFrom" runat="server"></asp:Label>
                            <asp:Label ID="Label10" runat="Server" meta:resourcekey="lblPleaseCode">'.<br>Please enter a new city name, airport name, or airport code.</asp:Label></span>
                    </div>
                    <div runat="server" style="display: none" id="div_From1">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="Label11" runat="Server" meta:resourcekey="lblPleaseEnterCode">Please enter a departure city or an airport code.</asp:Label>
                        </span>
                    </div>
                    <div class="searchFormMain_Content_ww">
                        <table width="400">
                            <tr>
                                <td width="30%">
                                    <asp:Label ID="Label12" runat="Server" meta:resourcekey="lblDepartureFrom">From</asp:Label>:</td>
                                <td>
                                    <uc3:LocationTextBoxControl ID="txtDepartureFrom" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div runat="server" style="display: none" id="div_To">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="Label16" runat="Server" meta:resourcekey="lblWeFor">We could not find any airports that match your search for </asp:Label>'<asp:Label
                                ID="lblTo" runat="server"></asp:Label>
                            <asp:Label ID="Label33" runat="Server" meta:resourcekey="lblPleaseCode"> '.<br>Please enter a new city name, airport name, or airport code.</asp:Label></span>
                    </div>
                    <div class="searchFormMain_Content_ww">
                        <table width="400">
                            <tr>
                                <td width="30%">
                                    <asp:Label ID="Label15" runat="Server" meta:resourcekey="lblTo">To</asp:Label>:</td>
                                <td>
                                    <uc3:LocationTextBoxControl ID="txtTo" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div runat="server" style="display: none" id="tr_ReturnFromMessage">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="Label17" runat="Server" meta:resourcekey="lblWeFor">We could not find any airports that match your search for </asp:Label>'<asp:Label
                                ID="lblReturnFrom" runat="server"></asp:Label>
                            <asp:Label ID="Label18" runat="Server" meta:resourcekey="lblPleaseCode"> '.<br>Please enter a new city name, airport name, or airport code.</asp:Label></span>
                    </div>
                    <div runat="server" id="tr_ReturnFrom" style="display: none">
                        <div class="searchFormMain_Content_ww">
                            <table width="400">
                                <tr>
                                    <td width="30%">
                                        <asp:Label ID="Label19" runat="Server" meta:resourcekey="lblReturnFrom">From</asp:Label>:</td>
                                    <td>
                                        <uc3:LocationTextBoxControl ID="txtReturnFrom" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div runat="server" style="display: none" id="tr_ReturnToMessage">
                        <span class="searchFormMain_Content_warn">
                            <div class="searchFormMain_Content_warn_block">
                                !</div>
                            <asp:Label ID="Label20" runat="Server" meta:resourcekey="lblWeFor">We could not find any airports that match your search for </asp:Label>'<asp:Label
                                ID="lblReturnTo" runat="server"></asp:Label>
                            <asp:Label ID="Label21" runat="Server" meta:resourcekey="lblPleaseCode">'.<br>Please enter a new city name, airport name, or airport code.</asp:Label></span>
                    </div>
                    <div id="tr_ReturnTo" runat="server" style="display: none">
                        <div class="searchFormMain_Content_ww">
                            <table width="400">
                                <tr>
                                    <td width="30%">
                                        <asp:Label ID="Label22" runat="Server" meta:resourcekey="lblReturnTo">To</asp:Label>:</td>
                                    <td>
                                        <uc3:LocationTextBoxControl ID="txtReturnTo" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="searchFormMain_Content_ww">
                        <table width="300">
                            <tr>
                                <td width="30%">
                                    <asp:Label ID="Label24" runat="Server" meta:resourcekey="lblDepartureDate">Departure Date</asp:Label>:</td>
                                <td>
                                    <uc7:Calendar ID="departureCalendar" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="tr_OneWay" runat="server" visible="true">
                        <div class="searchFormMain_Content_ww">
                            <table width="300">
                                <tr>
                                    <td width="30%">
                                        <asp:Label ID="Label25" runat="Server" meta:resourcekey="lblReturnDate">Return Date</asp:Label>:</td>
                                    <td>
                                        <uc7:Calendar ID="returnCalendar" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        3</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;<asp:Label ID="Label26" runat="Server"
                        meta:resourcekey="lblPassengers">Passengers</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_sel">
                    <asp:Label ID="Label27" runat="Server" meta:resourcekey="lblAdults">Adults</asp:Label>(12+):
                    <asp:DropDownList ID="ddlAdult" runat="server" Width="35px">
                        <asp:ListItem Selected="True">1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>&nbsp;&nbsp;
                    <asp:Label ID="Label28" runat="Server" meta:resourcekey="lblChildren">Children</asp:Label>(2-11):
                    <asp:DropDownList ID="ddlChild" runat="server" Width="35px">
                        <asp:ListItem>0</asp:ListItem>
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList></div>
                <div class="searchFormMain_Tine01">
                    <div class="searchFormMain_Tine01_block">
                        4</div>
                    <span class="searchFormMain_Tine01_block_title">&nbsp;
                        <asp:Label ID="Label29" runat="Server" meta:resourcekey="lblPreferences">Do you have any preferences?</asp:Label></span>
                </div>
                <div class="searchFormMain_Content_ww">
                    <div style="margin-bottom: 6px; width: 100%;">
                        <div class="left">
                            <asp:Label ID="Label30" runat="Server" meta:resourcekey="lblClass">Class</asp:Label>:</div>
                        <asp:RadioButtonList ID="rdoLstCabin" TabIndex="15" CssClass="left" Style="margin-top: -2px;"
                            runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="ECONOMY" Selected="True">Economy</asp:ListItem>
                            <asp:ListItem Value="BUSINESS">Business</asp:ListItem>
                            <asp:ListItem Value="FIRST">First</asp:ListItem>
                        </asp:RadioButtonList></div>
                </div>
                <div class="searchFormMain_Content_ww">
                    <div>
                        <asp:Label ID="Label31" runat="Server" meta:resourcekey="lblAirlineCode">Airline Code</asp:Label>:
                        <asp:TextBox ID="txtAirline" runat="server" onblur="EngAndPoint(this)" Width="90"
                            MaxLength="14" CssClass="search_inp"></asp:TextBox>
                        (e.g. UA,AA)
                        <asp:LinkButton ID="lnHelper" runat="server" meta:resourcekey="lnHelper" OnClientClick="return false;">choose airline</asp:LinkButton></div>
                </div>
                <div style="width: 100%; float: left; text-align: right;">
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
                    <asp:UpdatePanel ID="upSearch" runat="server">
                        <ContentTemplate>
                            <asp:Button ID="btnSearch" runat="server" Text="Continue" BorderStyle="none" CssClass="search_btn"
                                OnClick="btnSearch_Click1" ValidationGroup="Default" Style="cursor: hand; background: url(../../images/index/btn_bg.gif)"
                                meta:resourcekey="btn_SearchFare" CausesValidation="False" />
                            <uc2:ForbiddenAirportControl ID="ForbiddenAirportControl1" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>

        <script type="text/javascript">
    
    
    
           window.onload = function(){
           var flightType = document.forms[0].elements['ctl00_MainContent_FlightType'];
           if(flightType == "oneway"){
           document.getElementById('ctl00_MainContent_tr_OneWay').style.display = "none";
           }
           
           }
    
        </script>

    </form>
</asp:Content>
