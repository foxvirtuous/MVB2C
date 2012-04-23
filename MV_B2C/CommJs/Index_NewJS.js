function FillDiv(id)
{
    document.getElementById("search").value = "Search";
    var sc = '';
    var e = document.getElementById("divFile");
    
    if ( id == null || id == '')
    {
        id = '4';
    }

    switch (id)
    {
        case '1':
        sc = GetSearchAirSteing();
        e.innerHTML = sc;  
        setArraylistA();
        document.getElementById("lbtnA").className = "tab_a_flighthover";
        document.getElementById("lbtnAH").className = "tab_a_airHotel";
        document.getElementById("lbtnT").className = "tab_a_tour";
        document.getElementById("lbtnH").className = "tab_a_hotels";
        if (document.getElementById("lbtnC") != null)
        {
        document.getElementById("lbtnC").className = "tab_a_car";
        }
        break;
        case '2':
        sc = GetSearchAirHotelString();
        e.innerHTML = sc;  
        setArraylistAH();
        document.getElementById("lbtnA").className = "tab_a_flight";
        document.getElementById("lbtnAH").className = "tab_a_airHotelhover";
        document.getElementById("lbtnT").className = "tab_a_tour";
        document.getElementById("lbtnH").className = "tab_a_hotels";   
        if (document.getElementById("lbtnC") != null)
        {
        document.getElementById("lbtnC").className = "tab_a_car";
        }
        break;
        case '3':
        sc = GetSearchHotelString();
        e.innerHTML = sc;  
        setArraylistH();
        document.getElementById("lbtnA").className = "tab_a_flight";
        document.getElementById("lbtnAH").className = "tab_a_airHotel";
        document.getElementById("lbtnT").className = "tab_a_tour";
        document.getElementById("lbtnH").className = "tab_a_hotelshover"; 
        if (document.getElementById("lbtnC") != null)
        {
        document.getElementById("lbtnC").className = "tab_a_car";  
        }
        break;
        case '4':
        sc = GetSearchTourString();
        e.innerHTML = sc;  
        FillArea();
        setArraylistT();
        document.getElementById("lbtnA").className = "tab_a_flight";
        document.getElementById("lbtnAH").className = "tab_a_airHotel";
        document.getElementById("lbtnT").className = "tab_a_tourhover";
        document.getElementById("lbtnH").className = "tab_a_hotels"; 
        if (document.getElementById("lbtnC") != null)
        {
        document.getElementById("lbtnC").className = "tab_a_car";
        }
        break;
        case '5':
        sc = GetSearchPromosSteing();
        e.innerHTML = sc;  
        setArraylistP();
        document.getElementById("lbtnA").className = "tab_a_flighthover";
        break;
        case '6':
        sc = GetSearchCarString();
        e.innerHTML = sc;  
        setArraylistC();
        document.getElementById("lbtnA").className = "tab_a_flight";
        document.getElementById("lbtnAH").className = "tab_a_airHotel";
        document.getElementById("lbtnT").className = "tab_a_tour";
        document.getElementById("lbtnH").className = "tab_a_hotels"; 
        if (document.getElementById("lbtnC") != null)
        {
        document.getElementById("lbtnC").className = "tab_a_carhover";
        }
        break;
        case '7':
        sc = GetSearchHotelStringB();
        e.innerHTML = sc;  
        setArraylistHB();
        document.getElementById("lbtnA").className = "tab_a_flight";
        document.getElementById("lbtnAH").className = "tab_a_airHotel";
        document.getElementById("lbtnT").className = "tab_a_tour";
        document.getElementById("lbtnH").className = "tab_a_hotelshover"; 
        if (document.getElementById("lbtnC") != null)
        {
        document.getElementById("lbtnC").className = "tab_a_car";  
        }
        break;
    }
}

//retuen tour
function GetSearchTourString()
{
    var myDate1 = new Date();
    var myDatestar1 = cc(myDate1,8) ;
    var myDateEnd1 = cc(myDate1,15) ;
    var myDatestar2 = (myDatestar1.getMonth() + 1) + '/' +  myDatestar1.getDate() + '/' + myDatestar1.getFullYear();
    var myDateEnd2 = (myDateEnd1.getMonth() + 1) + '/' +  myDateEnd1.getDate() + '/' + myDateEnd1.getFullYear();

    var sc = '';
    
    sc = sc + '<div style="width:305px;">';
    sc = sc + '<div class="tab_body" >';
    sc = sc + '<input value="1" name="radiobutton" type="radio" id="rdbLandOnly" checked="checked" />';
    sc = sc + '<span id="SearchEngineT1_lblLand">Land Only</span>';
    sc = sc + '<div style="float: left; width: 100%;">';
    sc = sc + 'Region:';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<select name="ddlArea" id="ddlAreaT" class="search_sle" style="width: 280px;"  onchange="FillCountry();"></select>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; width: 100%;">';
    sc = sc + 'Country or Area:';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<select name="ddlCountry_T" id="ddlCountry_T" class="search_sle" style="width: 280px;" onchange="FillCity();"></select>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; width: 100%;">';
    sc = sc + 'City:';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<select name="ddlCity_T" id="ddlCity_T" class="search_sle" style="width: 280px;"></select>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '</div>';
    sc = sc + '<table cellpadding="5"  width="100%" border="0" cellspacing="0" style="margin: 6px 0px; float:left;">';
    sc = sc + '<tr>';
    sc = sc + '<td width="35%">';
    sc = sc + 'Departure Date:</td>';
    sc = sc + '<td>';
    sc = sc + '<div id="SearchEngineT1_tourDeptCalendar_divCalendar"><input name="SearchEngineT1$tourDeptCalendar$calendarDate" type="text" value="' + myDatestar2 + '" maxlength="12" id="SearchEngineT1_tourDeptCalendar_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onpaste="return false" oncontextmenu="return false" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr>';
    sc = sc + '<td>';
    sc = sc + 'Duration:</td>';
    sc = sc + '<td>';
    sc = sc + '<select name="ddlTravelDate" id="ddlTravelDate" class="search_sle" style="width: 90px;">';
    sc = sc + '<option value="5">less than 10 days</option>';
    sc = sc + '<option value="11">11 - 15 days</option>';
    sc = sc + '<option value="15">over 15 days</option>';
    sc = sc + '<option selected="selected" value="16">All</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '</table>';
    sc = sc + '</div>';  
    
    return sc;
}

//return air

function GetSearchAirSteing()
{
    var myDate1 = new Date();
    var myDatestarAir = cc(myDate1,4) ;
    var myDateEndAir = cc(myDate1,11) ;
    var myDatestarAir1 = (myDatestarAir.getMonth() + 1) + '/' +  myDatestarAir.getDate() + '/' + myDatestarAir.getFullYear();
    var myDateEndAir1 = (myDateEndAir.getMonth() + 1) + '/' +  myDateEndAir.getDate() + '/' + myDateEndAir.getFullYear();
    var sc = '';

    sc = sc + '<div style="width:305px;">';
    sc = sc + '<div class="tab_body">';
    sc = sc + '<input value="rdbRoundTrip" name="SearchEngineA1$rdbType" type="radio" id="SearchEngineA1_rdbRoundTrip" onclick="ChangeFlightType(\'roundtrip\')"  runat="server" checked="checked" />';
    sc = sc + '<span id="SearchEngineA1_Label1">RoundTrip</span>';
    sc = sc + '<input value="rdbOneway" name="SearchEngineA1$rdbType" type="radio" id="SearchEngineA1_rdbOneway" onclick="ChangeFlightType(\'oneway\')" style="margin-left:20px; display:inline;" />';
    sc = sc + '<span id="SearchEngineA1_Label2">OneWay</span>';
    sc = sc + '<input value="rdbOpenjaw" name="SearchEngineA1$rdbType" type="radio" id="SearchEngineA1_rdbOpenjaw" onclick="ChangeFlightType(\'openjaw\')" style="margin-left:20px; display:inline;" />';
    sc = sc + '<span id="SearchEngineA1_Label3">Multiple Cities</span>';
    sc = sc + '<div style="float:left; margin-right:8px; margin-top:3px;">From (City or Airport):<p style="margin-top:2px;"><input name="depFullCity" type="text" id="depFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div style="float:left; margin-top:3px;">To (City or Airport):<p style="margin-top:2px;"><input name="toFullCity" type="text" id="toFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div style="float:left; margin:8px 0px;width:100%;"><span class="fB left">Departure Date:&nbsp;</span><div id="SearchEngineA1_depFlightCalendar_divCalendar" class="left"><input name="SearchEngineA1$depFlightCalendar$calendarDate" type="text" value="' + myDatestarAir1 + '" maxlength="12" id="SearchEngineA1_depFlightCalendar_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onpaste="return false" oncontextmenu="return false" onblur="SetCoercion(\'SearchEngineA1_rtnFlightCalendar_calendarDate\',\'SearchEngineA1_depFlightCalendar_calendarDate\');" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div></div>';
    sc = sc + '<div id ="oneway1"  style="float:left; margin-right:8px;">Depart (City or Airport):<p style="margin-top:2px;"><input name="rtnFromFullCity" type="text" readonly="readonly" id="rtnFromFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div id ="oneway2" style="float:left;">Return (City or Airport):<p style="margin-top:2px;"><input name="rtnToFullCity" type="text" readonly="readonly" id="rtnToFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div id ="oneway3" style="float:left; margin:8px 0px;"><span class="fB left">Return Date:&nbsp;</span><div id="SearchEngineA1_rtnFlightCalendar_divCalendar" class="left"><input name="SearchEngineA1$rtnFlightCalendar$calendarDate" type="text" value="' + myDateEndAir1 + '" maxlength="12" id="SearchEngineA1_rtnFlightCalendar_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onpaste="return false" oncontextmenu="return false" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div></div>';
    sc = sc + '<div style="width:100%;" class="left"><input type="checkbox" id="chkadd" name="chkFlexiable" value="checkbox" />&nbsp;My dates are flexible +/- 1 day</div>';
    sc = sc + '<div style="width:100%;" class="left"><span class="fB">Passengers:</span><p>Adults ( 12+ ) ';
    sc = sc + '<select name="SearchEngineA1$ddlAdult" id="SearchEngineA1_ddlAdult" class="search_sle" style="width:35px;"><option selected="selected" value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option></select>';
    sc = sc + '&nbsp;&nbsp;&nbsp;Children ( 2 - 11 )  ';
    sc = sc + '<select name="SearchEngineA1$ddlChild" id="SearchEngineA1_ddlChild" class="search_sle" style="width:35px;"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option></select>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="width:100%;" class="left"><span style="float:left; margin-top:8px; margin-right:8px; display:inline;" class="fB">Class: </span>';
    sc = sc + '<input id="SearchEngineA1_rdoLstCabin_0" type="radio" name="SearchEngineA1$rdoLstCabin" value="ECONOMY" checked="checked" tabindex="15" /><label for="SearchEngineA1_rdoLstCabin_0">Economy</label><input id="SearchEngineA1_rdoLstCabin_1" type="radio" name="SearchEngineA1$rdoLstCabin" value="BUSINESS" tabindex="15" /><label for="SearchEngineA1_rdoLstCabin_1">Business</label><input id="SearchEngineA1_rdoLstCabin_2" type="radio" name="SearchEngineA1$rdoLstCabin" value="FIRST" tabindex="15" /><label for="SearchEngineA1_rdoLstCabin_2">First</label>';
    sc = sc + '</div>';
    sc = sc + '<div style="float:left; margin:8px 0px;" class="left"><span class="fB">Airline Code:&nbsp;</span><input name="SearchEngineA1$txtAirline" type="text" maxlength="14" id="SearchEngineA1_txtAirline" class="search_inp" onKeyPress="InputAirline()" style="width:90px;" />&nbsp;(e.g. AA,NW)<p><a id="SearchEngineA1_hlChooseAirline" href="http://www.majestic-vacations.com/ChooseAirlines.aspx" target="_blank">choose airline</a></</p> </div></div>';
    sc = sc + '</div>';

    return sc;
}


//return Promos
function GetSearchPromosSteing()
{
    var myDate1 = new Date();
    var myDatestarAir = cc(myDate1,4) ;
    var myDateEndAir = cc(myDate1,11) ;
    var myDatestarAir1 = (myDatestarAir.getMonth() + 1) + '/' +  myDatestarAir.getDate() + '/' + myDatestarAir.getFullYear();
    var myDateEndAir1 = (myDateEndAir.getMonth() + 1) + '/' +  myDateEndAir.getDate() + '/' + myDateEndAir.getFullYear();
    var sc = '';

    sc = sc + '<div style="width:305px;">';
    sc = sc + '<div class="tab_body">';
    sc = sc + '<input value="rdbRoundTrip" name="SearchEngineA1$rdbType" type="radio" id="SearchEngineA1_rdbRoundTrip" onclick="ChangeFlightType(\'roundtrip\')"  runat="server" checked="checked" />';
    sc = sc + '<span id="SearchEngineA1_Label1">RoundTrip</span>';
    sc = sc + '<input value="rdbOneway" name="SearchEngineA1$rdbType" type="radio" id="SearchEngineA1_rdbOneway" onclick="ChangeFlightType(\'oneway\')" style="margin-left:20px; display:inline;" />';
    sc = sc + '<span id="SearchEngineA1_Label2">OneWay</span>';
    sc = sc + '<input value="rdbOpenjaw" name="SearchEngineA1$rdbType" type="radio" id="SearchEngineA1_rdbOpenjaw" onclick="ChangeFlightType(\'openjaw\')" style="margin-left:20px; display:inline;" />';
    sc = sc + '<span id="SearchEngineA1_Label3">Multiple Cities</span>';
    sc = sc + '<div style="float:left; margin-right:8px; margin-top:3px;">From (City or Airport):<p style="margin-top:2px;"><input name="depFullCity" type="text" id="depFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div style="float:left; margin-top:3px;">To (City or Airport):<p style="margin-top:2px;"><input name="toFullCity" type="text" id="toFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div style="float:left; margin:8px 0px;width:100%;"><span class="fB left">Departure Date:&nbsp;</span><div id="SearchEngineA1_depFlightCalendar_divCalendar" class="left"><input name="SearchEngineA1$depFlightCalendar$calendarDate" type="text" value="' + myDatestarAir1 + '" maxlength="12" id="SearchEngineA1_depFlightCalendar_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onblur="SetCoercion(\'SearchEngineA1_rtnFlightCalendar_calendarDate\',\'SearchEngineA1_depFlightCalendar_calendarDate\');" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div></div>';
    sc = sc + '<div id ="oneway1"  style="float:left; margin-right:8px;">Depart (City or Airport):<p style="margin-top:2px;"><input name="rtnFromFullCity" type="text" readonly="readonly" id="rtnFromFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div id ="oneway2" style="float:left;">Return (City or Airport):<p style="margin-top:2px;"><input name="rtnToFullCity" type="text" readonly="readonly" id="rtnToFullCity" class="search_inp" autocomplete="off" style="width:130px;" /></p></div>';
    sc = sc + '<div id ="oneway3" style="float:left; margin:8px 0px;"><span class="fB left">Return Date:&nbsp;</span><div id="SearchEngineA1_rtnFlightCalendar_divCalendar" class="left"><input name="SearchEngineA1$rtnFlightCalendar$calendarDate" type="text" value="' + myDateEndAir1 + '" maxlength="12" id="SearchEngineA1_rtnFlightCalendar_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div></div>';
    sc = sc + '<div style="width:100%;" class="left"><input type="checkbox" id="chkadd" name="chkFlexiable" value="checkbox" />&nbsp;My dates are flexible +/- 1 day</div>';
    sc = sc + '<div style="width:100%;" class="left"><span class="fB">Passengers:</span><p>Adults ( 12+ ) ';
    sc = sc + '<select name="SearchEngineA1$ddlAdult" id="SearchEngineA1_ddlAdult" class="search_sle" style="width:35px;"><option value="0">0</option><option selected="selected" value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option></select>';
    sc = sc + '&nbsp;&nbsp;&nbsp;Children ( 2 - 11 )  ';
    sc = sc + '<select name="SearchEngineA1$ddlChild" id="SearchEngineA1_ddlChild" class="search_sle" style="width:35px;"><option value="0">0</option><option value="1">1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option></select>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="width:100%;" class="left"><span style="float:left; margin-top:8px; margin-right:8px; display:inline;" class="fB">Class: </span>';
    sc = sc + '<input id="SearchEngineA1_rdoLstCabin_0" type="radio" name="SearchEngineA1$rdoLstCabin" value="ECONOMY" checked="checked" tabindex="15" /><label for="SearchEngineA1_rdoLstCabin_0">Economy</label><input id="SearchEngineA1_rdoLstCabin_1" type="radio" name="SearchEngineA1$rdoLstCabin" value="BUSINESS" tabindex="15" /><label for="SearchEngineA1_rdoLstCabin_1">Business</label><input id="SearchEngineA1_rdoLstCabin_2" type="radio" name="SearchEngineA1$rdoLstCabin" value="FIRST" tabindex="15" /><label for="SearchEngineA1_rdoLstCabin_2">First</label>';
    sc = sc + '</div>';
    sc = sc + '<div style="float:left; margin:8px 0px;" class="left"><span class="fB">Airline Code:&nbsp;</span><input name="SearchEngineA1$txtAirline" type="text" maxlength="14" id="SearchEngineA1_txtAirline" class="search_inp" onKeyPress="InputAirline()" style="width:90px;" />&nbsp;(e.g. AA,NW)<p><a id="SearchEngineA1_hlChooseAirline" href="http://www.majestic-vacations.com/ChooseAirlines.aspx" target="_blank">choose airline</a></</p> </div></div>';
    sc = sc + '</div>';

    return sc;
}


//return hotel
function GetSearchHotelString()
{
    var myDate1 = new Date();
    var myDatestar1 = cc(myDate1,8) ;
    var myDateEnd1 = cc(myDate1,15) ;
    var myDatestar2 = (myDatestar1.getMonth() + 1) + '/' +  myDatestar1.getDate() + '/' + myDatestar1.getFullYear();
    var myDateEnd2 = (myDateEnd1.getMonth() + 1) + '/' +  myDateEnd1.getDate() + '/' + myDateEnd1.getFullYear();

    var sc = '';

    sc = sc + '<div style="width: 305px;">';
    sc = sc + '<div class="tab_body" style="">';
    sc = sc + '<div style="float: left; margin-right: 8px;">';
    sc = sc + 'Destination: (e.g. an City Name, City Code, Airport Code)';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left;">';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<input name="txtFullName" type="text" id="txtFullName" autocomplete="off" style="width: 222px;" />';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; width: 100%;">';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; margin-right: 8px; width: 47%;">';
    sc = sc + 'Check-in:';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<div id="SearchEngineH1_txtCheckin_h_divCalendar"><input name="SearchEngineH1$txtCheckin_h$calendarDate" type="text" value="' + myDatestar2 + '" maxlength="12" id="SearchEngineH1_txtCheckin_h_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onpaste="return false" oncontextmenu="return false" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onblur="SetCoercion(\'SearchEngineH1_txtCheckout_h_calendarDate\',\'SearchEngineH1_txtCheckin_h_calendarDate\');" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; width: 50%;">';
    sc = sc + 'Check-out:';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<div id="SearchEngineH1_txtCheckout_h_divCalendar"><input name="SearchEngineH1$txtCheckout_h$calendarDate" type="text" value="' + myDateEnd2 + '" maxlength="12" id="SearchEngineH1_txtCheckout_h_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onpaste="return false" oncontextmenu="return false" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<table width="100%" border="0" cellspacing="0" cellpadding="3" style="margin: 6px 0px;">';
    sc = sc + '<tr>';
    sc = sc + '<td>';
    sc = sc + '<span id="lblRooms">Rooms</span>:</td>';
    sc = sc + '<td>';
    sc = sc + '&nbsp;</td>';
    sc = sc + '<td>';
    sc = sc + '<span id="Label1">Adults</span>: (12+)';
    sc = sc + '</td>';
    sc = sc + '<td>';
    sc = sc + '<span id="Label2">Children</span>: (2-11)';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr>';
    sc = sc + '<td width="16%">';
    sc = sc + '<select name="dllRooms" id="dllRooms" class="search_sle" onchange="ShowHidePassengers()" onselect="javascript:ShowHidePassengers();" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Label3">Room</span> #1: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult1" id="ddlAdult1" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren1" id="ddlChildren1" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr id="tbRoom2" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span1">Room</span> #2: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult2" id="ddlAdult2" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren2" id="ddlChildren2" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr  id="tbRoom3" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span2">Room</span> #3: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult3" id="ddlAdult3" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren3" id="ddlChildren3" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr  id="tbRoom4" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span3">Room</span> #4: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult4" id="ddlAdult4" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren4" id="ddlChildren4" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '</table>';
    sc = sc + '</div>';
    sc = sc + '</div>';
    
    return sc;
}


//return hotel
function GetSearchHotelStringB()
{
    var myDate1 = new Date();
    var myDatestar1 = cc(myDate1,4) ;
    var myDateEnd1 = cc(myDate1,11) ;
    var myDatestar2 = (myDatestar1.getMonth() + 1) + '/' +  myDatestar1.getDate() + '/' + myDatestar1.getFullYear();
    var myDateEnd2 = (myDateEnd1.getMonth() + 1) + '/' +  myDateEnd1.getDate() + '/' + myDateEnd1.getFullYear();

    var sc = '';

    sc = sc + '<div style="width: 305px;">';
    sc = sc + '<div class="tab_body" style="">';
    sc = sc + '<div style="float: left; margin-right: 8px;">';
    sc = sc + 'Destination: (e.g. an City Name, City Code, Airport Code)';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left;">';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<input name="txtFullName" type="text" id="txtFullName" autocomplete="off" style="width: 222px;" />';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; width: 100%;">';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; margin-right: 8px; width: 47%;">';
    sc = sc + 'Check-in:';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<div id="SearchEngineH1_txtCheckin_h_divCalendar"><input name="SearchEngineH1$txtCheckin_h$calendarDate" type="text" value="' + myDatestar2 + '" maxlength="12" id="SearchEngineH1_txtCheckin_h_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onpaste="return false" oncontextmenu="return false" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onblur="SetCoercion(\'SearchEngineH1_txtCheckout_h_calendarDate\',\'SearchEngineH1_txtCheckin_h_calendarDate\');" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<div style="float: left; width: 50%;">';
    sc = sc + 'Check-out:';
    sc = sc + '<p style="margin-top: 2px;">';
    sc = sc + '<div id="SearchEngineH1_txtCheckout_h_divCalendar"><input name="SearchEngineH1$txtCheckout_h$calendarDate" type="text" value="' + myDateEnd2 + '" maxlength="12" id="SearchEngineH1_txtCheckout_h_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onpaste="return false" oncontextmenu="return false" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div>';
    sc = sc + '</p>';
    sc = sc + '</div>';
    sc = sc + '<table width="100%" border="0" cellspacing="0" cellpadding="3" style="margin: 6px 0px;">';
    sc = sc + '<tr>';
    sc = sc + '<td>';
    sc = sc + '<span id="lblRooms">Rooms</span>:</td>';
    sc = sc + '<td>';
    sc = sc + '&nbsp;</td>';
    sc = sc + '<td>';
    sc = sc + '<span id="Label1">Adults</span>: (12+)';
    sc = sc + '</td>';
    sc = sc + '<td>';
    sc = sc + '<span id="Label2">Children</span>: (2-11)';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr>';
    sc = sc + '<td width="16%">';
    sc = sc + '<select name="dllRooms" id="dllRooms" class="search_sle" onchange="ShowHidePassengers()" onselect="javascript:ShowHidePassengers();" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Label3">Room</span> #1: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult1" id="ddlAdult1" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren1" id="ddlChildren1" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr id="tbRoom2" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span1">Room</span> #2: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult2" id="ddlAdult2" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren2" id="ddlChildren2" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr  id="tbRoom3" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span2">Room</span> #3: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult3" id="ddlAdult3" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren3" id="ddlChildren3" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr  id="tbRoom4" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span3">Room</span> #4: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult4" id="ddlAdult4" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="ddlChildren4" id="ddlChildren4" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '</table>';
    sc = sc + '</div>';
    sc = sc + '</div>';
    
    return sc;
}


//return air + hotel
function GetSearchAirHotelString()
{
    var myDate1 = new Date();
    var myDatestar1 = cc(myDate1,8) ;
    var myDateEnd1 = cc(myDate1,15) ;
    var myDatestar2 = (myDatestar1.getMonth() + 1) + '/' +  myDatestar1.getDate() + '/' + myDatestar1.getFullYear();
    var myDateEnd2 = (myDateEnd1.getMonth() + 1) + '/' +  myDateEnd1.getDate() + '/' + myDateEnd1.getFullYear();
    var sc = '';
    
    sc = sc + '<div style="width:305px;">';
    sc = sc + '<div class="tab_body">';
    sc = sc + '<input id="radiobutton" name="radiobutton" type="radio" value="radiobutton" checked="checked" />';
    sc = sc + '<span id="SearchEngineAH1_lblOne">One Destination</span>';
    sc = sc + '<input name="radiobutton" type="radio" value="radiobutton" style="margin-left:37px; display:inline;" onclick="javascript:location.href=\''
    sc = sc + 'http://www.majestic-vacations.com/Page/Package2/PackageSearchTwoDestinations.aspx\'" />';
    sc = sc + '<span id="SearchEngineAH1_Label1">Two Destinations</span>';
    sc = sc + '<div style="float:left; margin-right:8px; margin-top:3px;">From (City or Airport):<p style="margin-top:2px;"><input name="txtFullFrom_AH" type="text" id="txtFullFrom_AH" class="search_inp" style="width:130px;" /></p></div>';
    sc = sc + '<div style="float:left; margin-top:3px;">To (City or Airport):<p style="margin-top:2px;"><input name="txtFullTo_AH" type="text" id="txtFullTo_AH" class="search_inp" style="width:130px;" /></p></div>';
    sc = sc + '<div style="float:left; margin-right:8px; width:47%; margin-top:6px;">Depart:<p style="margin-top:2px;"><div id="SearchEngineAH1_dateDeparture_AH_divCalendar"><input name="SearchEngineAH1$dateDeparture_AH$calendarDate" type="text" value="' + myDatestar2 + '" maxlength="12" id="SearchEngineAH1_dateDeparture_AH_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onpaste="return false" oncontextmenu="return false" onblur="SetCoercion(\'SearchEngineAH1_dateReturn_AH_calendarDate\',\'SearchEngineAH1_dateDeparture_AH_calendarDate\');" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div></p></div>';
    sc = sc + '<div style="float:left; width:50%;margin-top:6px;">Return:<p style="margin-top:2px;"><div id="SearchEngineAH1_dateReturn_AH_divCalendar"><input name="SearchEngineAH1$dateReturn_AH$calendarDate" type="text" value="' + myDateEnd2 + '" maxlength="12" id="SearchEngineAH1_dateReturn_AH_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onpaste="return false" oncontextmenu="return false" style="width:80px;margin-top: -1px;margin-bottom: -1px;" onblur="SetCoercion(\'SearchEngineAH1_CheckIn_AH_calendarDate\',\'SearchEngineAH1_dateDeparture_AH_calendarDate\');" /></div></p></div>';
    sc = sc + '<div style="width:100%; margin-top:8px;" class="left"><input id="SearchEngineAH1_chbFlexible_AH" type="checkbox" name="SearchEngineAH1$chbFlexible_AH" />&nbsp;My dates are flexible +/- 1 day</div>';
    sc = sc + '<div style="width:100%; margin-top:8px;" class="left"><input id="ckbHotel" type="checkbox" onclick="ShowHotelCheckDates()" />&nbsp;I only need a hotel for part of my trip.</div>';
    sc = sc + '<div id="tdHotel" style="display: none">When do you need a hotel? (Check-in and check-out dates must be within dates of travel.)';
    sc = sc + '<div style="float:left; margin-right:8px; width:47%; margin-top:8px;">CheckIn:<p style="margin-top:2px;"><div id="SearchEngineAH1_CheckIn_AH_divCalendar"><input name="SearchEngineAH1$CheckIn_AH$calendarDate" type="text" maxlength="12" id="SearchEngineAH1_CheckIn_AH_calendarDate" value="' + myDatestar2 + '" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onpaste="return false" oncontextmenu="return false" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onpaste="return false" oncontextmenu="return false" onblur="SetCoercion(\'SearchEngineAH1_CheckOut_AH_calendarDate\',\'SearchEngineAH1_CheckIn_AH_calendarDate\');" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div></p></div>';
    sc = sc + '<div style="float:left; width:50%;margin-top:8px;">CheckOut:<p style="margin-top:2px;"><div id="SearchEngineAH1_CheckOut_AH_divCalendar"><input name="SearchEngineAH1$CheckOut_AH$calendarDate" type="text" maxlength="12" id="SearchEngineAH1_CheckOut_AH_calendarDate" value="' + myDateEnd2 + '" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onpaste="return false" oncontextmenu="return false" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onpaste="return false" oncontextmenu="return false" style="width:80px;margin-top: -1px;margin-bottom: -1px;" /></div></p></div>';
    sc = sc + '</div>';
    sc = sc + '<table width="100%" border="0" cellspacing="0" cellpadding="3" style="margin: 6px 0px;">';
    sc = sc + '<tr>';
    sc = sc + '<td>';
    sc = sc + '<span id="lblRooms">Rooms</span>:</td>';
    sc = sc + '<td>';
    sc = sc + '&nbsp;</td>';
    sc = sc + '<td>';
    sc = sc + '<span id="Label1">Adults</span>: (12+)';
    sc = sc + '</td>';
    sc = sc + '<td>';
    sc = sc + '<span id="Label2">Children</span>: (2-11)';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr>';
    sc = sc + '<td width="16%">';
    sc = sc + '<select name="dllRooms" id="dllRooms" class="search_sle" onchange="ShowHidePassengers()" onselect="javascript:ShowHidePassengers();" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Label3">Room</span> #1: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult1" id="ddlAdult1" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="Children1" id="Children1" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr id="tbRoom2" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span1">Room</span> #2: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult2" id="ddlAdult2" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="Children2" id="Children2" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr  id="tbRoom3" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span2">Room</span> #3: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult3" id="ddlAdult3" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="Children3" id="Children3" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '<tr  id="tbRoom4" style="display: none">';
    sc = sc + '<td width="16%">';
    sc = sc + '</td>';
    sc = sc + '<td width="20%">';
    sc = sc + '<strong><span id="Span3">Room</span> #4: </strong>';
    sc = sc + '</td>';
    sc = sc + '<td width="29%">';
    sc = sc + '<select name="ddlAdult4" id="ddlAdult4" class="search_sle" style="width: 35px;">';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option selected="selected" value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '<option value="6">6</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '<td width="35%">';
    sc = sc + '<select name="Children4" id="Children4" class="search_sle" style="width: 35px;">';
    sc = sc + '<option selected="selected" value="0">0</option>';
    sc = sc + '<option value="1">1</option>';
    sc = sc + '<option value="2">2</option>';
    sc = sc + '<option value="3">3</option>';
    sc = sc + '<option value="4">4</option>';
    sc = sc + '<option value="5">5</option>';
    sc = sc + '</select>';
    sc = sc + '</td>';
    sc = sc + '</tr>';
    sc = sc + '</table>';
    sc = sc + '<div style="width:100%;" class="left"><span class="fB">Addtional options:</span><BR><span style="float:left; margin-top:8px; margin-right:8px; display:inline;">Class: </span>';
    sc = sc + '<input id="SearchEngineAH1_rdoLstCabin_AH_0" type="radio" name="SearchEngineAH1$rdoLstCabin_AH" value="ECONOMY" checked="checked" tabindex="15" />';
    sc = sc + '<label for="SearchEngineAH1_rdoLstCabin_AH_0">Economy</label><input id="SearchEngineAH1_rdoLstCabin_AH_1" type="radio" name="SearchEngineAH1$rdoLstCabin_AH" value="BUSINESS" tabindex="15" /><label for="SearchEngineAH1_rdoLstCabin_AH_1">Business</label><input id="SearchEngineAH1_rdoLstCabin_AH_2" type="radio" name="SearchEngineAH1$rdoLstCabin_AH" value="FIRST" tabindex="15" /><label for="SearchEngineAH1_rdoLstCabin_AH_2">First</label>';
    sc = sc + '</div>';
    sc = sc + '<div style="float:left; margin:8px 0px;" class="left">';
    sc = sc + '<b><span id="SearchEngineAH1_Label18">Airline Code</span>:</b><select name="SearchEngineAH1$ddlAirline" id="SearchEngineAH1_ddlAirline" style="font-size:11px;"><option selected="selected" value="all">No Preference</option><option value="AA">American Airlines</option><option value="DL">Delta Airlines</option><option value="UA">United Airlines</option></select>';
    sc = sc + '</div>';
    sc = sc + '</div>';
 
    return sc;   
}


//Car
function GetSearchCarString()
{
    var myDate1 = new Date();
    var myDatestar1 = cc(myDate1,8) ;
    var myDateEnd1 = cc(myDate1,9) ;
    var myDatestar2 = (myDatestar1.getMonth() + 1) + '/' +  myDatestar1.getDate() + '/' + myDatestar1.getFullYear();
    var myDateEnd2 = (myDateEnd1.getMonth() + 1) + '/' +  myDateEnd1.getDate() + '/' + myDateEnd1.getFullYear();
    var sc = '';
    
sc = sc + '<div style="width: 305px;">';
sc = sc + '<div class="tab_body">';
sc = sc + '<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">';
sc = sc + '<tr align="left">';
sc = sc + '<td width="50">Drop Off:</td>';
sc = sc + '<td width="20">';
sc = sc + '<input name="rdDropoff" type="radio" id="rdSame" value="S" checked=checked onclick="ChangeCarType(\'S\')" /></td>';
sc = sc + '<td class="searchnew_txt">Same Location</td>';
sc = sc + '<td width="20">';
sc = sc + '<input name="rdDropoff" type="radio" id="raDifferent" value="D" onclick="ChangeCarType(\'D\')" /></td>';
sc = sc + '<td class="searchnew_txt">Different Location</td>';
sc = sc + '</tr>';
sc = sc + '</table>';
sc = sc + '<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" >';
sc = sc + '<tr align="left">';
sc = sc + '<td width="50%" height="30"> From (Airport):<br>';
sc = sc + '</td>';
sc = sc + '</tr>';
sc = sc + '<tr align="left">';
sc = sc + '<td>';
sc = sc + '<input name="txtCarFromFullName" id="txtCarFromFullName" type="text" style="font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; color: #000000; margin: 2px 0 0 0; width: 260px;" size="50" autocomplete="off" /></td>';
sc = sc + '</tr>';
sc = sc + '</table>';
sc = sc + '<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0" id="tbTo" style="display:none">';
sc = sc + '<tr align="left">';
sc = sc + '<td height="30">To (Airport):</td>';
sc = sc + '</tr>';
sc = sc + '<tr align="left">';
sc = sc + '<td>';
sc = sc + '<input name="txtCarToFullName" id="txtCarToFullName" type="text" style="font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; color: #000000; margin: 2px 0 0 0; width: 260px;" size="50" autocomplete="off" /></td>';
sc = sc + '</tr>';
sc = sc + '</table>';
sc = sc + '<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">';
sc = sc + '<tr align="left">';
sc = sc + '<td width="52" height="30">Pick Up:</td>';
sc = sc + '<td>';
sc = sc + '<div id="SearchEngineC1_txtCheckin_h_divCalendar">';
sc = sc + '<input name="SearchEngineC1$txtCheckin_h$calendarDate" type="text" value="' + myDatestar2 + '" maxlength="12" id="SearchEngineC1_txtCheckin_h_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onblur="SetCoercion(\'SearchEngineC1_txtCheckout_h_calendarDate\',\'SearchEngineC1_txtCheckin_h_calendarDate\');" onpaste="return false" oncontextmenu="return false" style="width: 80px; margin-top: 0px; margin-bottom: 0px; height: 17px;" />&nbsp;<a href="javascript:SetCal(this,\'SearchEngineC1_txtCheckin_h\')" id="SearchEngineC1_txtCheckin_h_aCal"><img src="../../images/v2/calendar.gif" align="absmiddle" style="cursor: pointer; margin-top: 0px; margin-bottom: 0px;" border="0"/></a></div>';
sc = sc + '</td>';
sc = sc + '</tr>';
sc = sc + '<tr align="left">';
sc = sc + '<td width="52" height="30" align="left">Time:&nbsp;&nbsp;</td>';
sc = sc + '<td>';
sc = sc + '<select name="in_date" id="SearchCar_in_date" tabindex="8" style="font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; color: #000000; margin: 2px 0 0 0;">';
sc = sc + '<option value="0030A">12:30 AM</option>';
sc = sc + '<option value="0100A">01:00 AM</option>';
sc = sc + '<option value="0130A">01:30 AM</option>';
sc = sc + '<option value="0200A">02:00 AM</option>';
sc = sc + '<option value="0230A">02:30 AM</option>';
sc = sc + '<option value="0300A">03:00 AM</option>';
sc = sc + '<option value="0330A">03:30 AM</option>';
sc = sc + '<option value="0400A">04:00 AM</option>';
sc = sc + '<option value="0430A">04:30 AM</option>';
sc = sc + '<option value="0500A">05:00 AM</option>';
sc = sc + '<option value="0530A">05:30 AM</option>';
sc = sc + '<option value="0600A">06:00 AM</option>';
sc = sc + '<option value="0630A">06:30 AM</option>';
sc = sc + '<option value="0700A">07:00 AM</option>';
sc = sc + '<option value="0730A">07:30 AM</option>';
sc = sc + '<option value="0800A">08:00 AM</option>';
sc = sc + '<option value="0830A">08:30 AM</option>';
sc = sc + '<option value="0900A">09:00 AM</option>';
sc = sc + '<option value="0930A">09:30 AM</option>';
sc = sc + '<option value="1000A">10:00 AM</option>';
sc = sc + '<option value="1030A">10:30 AM</option>';
sc = sc + '<option value="1100A">11:00 AM</option>';
sc = sc + '<option value="1130A">11:30 AM</option>';
sc = sc + '<option selected="selected" value="1200A">12 Noon</option>';
sc = sc + '<option value="0030P">12:30 PM</option>';
sc = sc + '<option value="0100P">01:00 PM</option>';
sc = sc + '<option value="0130P">01:30 PM</option>';
sc = sc + '<option value="0200P">02:00 PM</option>';
sc = sc + '<option value="0230P">02:30 PM</option>';
sc = sc + '<option value="0300P">03:00 PM</option>';
sc = sc + '<option value="0330P">03:30 PM</option>';
sc = sc + '<option value="0400P">04:00 PM</option>';
sc = sc + '<option value="0430P">04:30 PM</option>';
sc = sc + '<option value="0500P">05:00 PM</option>';
sc = sc + '<option value="0530P">05:30 PM</option>';
sc = sc + '<option value="0600P">06:00 PM</option>';
sc = sc + '<option value="0630P">06:30 PM</option>';
sc = sc + '<option value="0700P">07:00 PM</option>';
sc = sc + '<option value="0730P">07:30 PM</option>';
sc = sc + '<option value="0800P">08:00 PM</option>';
sc = sc + '<option value="0830P">08:30 PM</option>';
sc = sc + '<option value="0900P">09:00 PM</option>';
sc = sc + '<option value="0930P">09:30 PM</option>';
sc = sc + '<option value="1000P">10:00 PM</option>';
sc = sc + '<option value="1030P">10:30 PM</option>';
sc = sc + '<option value="1100P">11:00 PM</option>';
sc = sc + '<option value="1130P">11:30 PM</option>';
sc = sc + '<option value="1200P">12 Midnt</option></select>';
sc = sc + '</td>';
sc = sc + '</tr>';
sc = sc + '<tr align="left">';
sc = sc + '<td width="52" height="30">Drop Off: </td>';
sc = sc + '<td>';
sc = sc + '<div id="SearchEngineC1_txtCheckout_h_divCalendar">';
sc = sc + '<input name="SearchEngineC1$txtCheckin_h$calendarDate" type="text" value="' + myDateEnd2 + '" maxlength="12" id="SearchEngineC1_txtCheckout_h_calendarDate" class="search_inp" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);" onpaste="return false" oncontextmenu="return false" onkeydown="if(event.keyCode==13){search(\'btnSearch\')}else{return false}" onblur="SetCoercion(\'SearchEngineC1_txtCheckout_h_calendarDate\',\'SearchEngineC1_txtCheckin_h_calendarDate\');" style="width: 80px; margin-top: 0px; margin-bottom: 0px; height: 17px" />&nbsp;<a href="javascript:SetCal(this,\'SearchEngineC1_txtCheckout_h\')" id="SearchEngineC1_txtCheckin_h_aCal"><img src="../../images/v2/calendar.gif" align="absmiddle" style="cursor: pointer; margin-top: 0px; margin-bottom: 0px;" border="0"/></a></div>';
sc = sc + '</td>';
sc = sc + '</tr>';
sc = sc + '<tr align="left">';
sc = sc + '<td width="52" height="30" align="left">Time:&nbsp;&nbsp;</td>';
sc = sc + '<td>';
sc = sc + '<select name="out_date" id="SearchCar_out_date" size="1" tabindex="8" style="font-size: 10px; font-family: Verdana; background-color: #FFFFFF; border: 1px solid #FD9647; color: #000000; margin: 2px 0 0 0;">';
sc = sc + '<option value="0030A">12:30 AM</option>';
sc = sc + '<option value="0100A">01:00 AM</option>';
sc = sc + '<option value="0130A">01:30 AM</option>';
sc = sc + '<option value="0200A">02:00 AM</option>';
sc = sc + '<option value="0230A">02:30 AM</option>';
sc = sc + '<option value="0300A">03:00 AM</option>';
sc = sc + '<option value="0330A">03:30 AM</option>';
sc = sc + '<option value="0400A">04:00 AM</option>';
sc = sc + '<option value="0430A">04:30 AM</option>';
sc = sc + '<option value="0500A">05:00 AM</option>';
sc = sc + '<option value="0530A">05:30 AM</option>';
sc = sc + '<option value="0600A">06:00 AM</option>';
sc = sc + '<option value="0630A">06:30 AM</option>';
sc = sc + '<option value="0700A">07:00 AM</option>';
sc = sc + '<option value="0730A">07:30 AM</option>';
sc = sc + '<option value="0800A">08:00 AM</option>';
sc = sc + '<option value="0830A">08:30 AM</option>';
sc = sc + '<option value="0900A">09:00 AM</option>';
sc = sc + '<option value="0930A">09:30 AM</option>';
sc = sc + '<option value="1000A">10:00 AM</option>';
sc = sc + '<option value="1030A">10:30 AM</option>';
sc = sc + '<option value="1100A">11:00 AM</option>';
sc = sc + '<option value="1130A">11:30 AM</option>';
sc = sc + '<option selected="selected" value="1200A">12 Noon</option>';
sc = sc + '<option value="0030P">12:30 PM</option>';
sc = sc + '<option value="0100P">01:00 PM</option>';
sc = sc + '<option value="0130P">01:30 PM</option>';
sc = sc + '<option value="0200P">02:00 PM</option>';
sc = sc + '<option value="0230P">02:30 PM</option>';
sc = sc + '<option value="0300P">03:00 PM</option>';
sc = sc + '<option value="0330P">03:30 PM</option>';
sc = sc + '<option value="0400P">04:00 PM</option>';
sc = sc + '<option value="0430P">04:30 PM</option>';
sc = sc + '<option value="0500P">05:00 PM</option>';
sc = sc + '<option value="0530P">05:30 PM</option>';
sc = sc + '<option value="0600P">06:00 PM</option>';
sc = sc + '<option value="0630P">06:30 PM</option>';
sc = sc + '<option value="0700P">07:00 PM</option>';
sc = sc + '<option value="0730P">07:30 PM</option>';
sc = sc + '<option value="0800P">08:00 PM</option>';
sc = sc + '<option value="0830P">08:30 PM</option>';
sc = sc + '<option value="0900P">09:00 PM</option>';
sc = sc + '<option value="0930P">09:30 PM</option>';
sc = sc + '<option value="1000P">10:00 PM</option>';
sc = sc + '<option value="1030P">10:30 PM</option>';
sc = sc + '<option value="1100P">11:00 PM</option>';
sc = sc + '<option value="1130P">11:30 PM</option>';
sc = sc + '<option value="1200P">12 Midnt</option>';
sc = sc + '</select>';
sc = sc + '</td>';
sc = sc + '</tr>';
sc = sc + '</table>';
sc = sc + '<table width="90%" border="0" align="center" cellpadding="0" cellspacing="0">';
sc = sc + '<tr align="left">';
sc = sc + '<td width="52" height="30">';
sc = sc + 'Car Type:</td>';
sc = sc + '<td>';
sc = sc + '<select name="cartype" id="cartypeRegular" size="1" tabindex="8" class="search_sle3">';
sc = sc + '<option selected="selected"  value="0">No Preference</option>';
sc = sc + '<option value="3">Economy</option>';
sc = sc + '<option value="4">Compact</option>';
sc = sc + '<option value="5">Midsize</option>';
sc = sc + '<option value="7">Standard</option>';
sc = sc + '<option value="8">Full Size</option>';
sc = sc + '<option value="10">Premium</option>';
sc = sc + '<option value="9">Luxury</option>';
sc = sc + '<option value="97">Convertible</option>';
sc = sc + '<option value="98">Minivan</option>';
sc = sc + '<option value="99">SUV</option>';
sc = sc + '</select>';
sc = sc + '</td>';
sc = sc + '</tr>';
sc = sc + '</table>';
sc = sc + '</div>';
sc = sc + '</div>';
    return sc;   
}


//Tour
function FillArea() {
    var area = document.getElementById("ddlAreaT")
    
    var arrListStr = Index.GetRegions().value;
    arrListStr = 'Please select a area ||' + arrListStr;
    var arrList = arrListStr.split("||");
    arrList.pop(arrList[arrList.length-1]);
    
    area.length=0;
    
    for(var i=0;i<arrList.length;i++)
      { 
      area[i]=new Option(arrList[i],arrList[i]); 
      }
}
function FillCountry() {
    var area = document.getElementById("ddlAreaT")
    var country = document.getElementById("ddlCountry_T")
    var city = document.getElementById("ddlCity_T")
    
    if (area.selectedIndex == 0)
    {
        country.length=0;city.length=0;
     return;
    }
    
    var country = document.getElementById("ddlCountry_T")
    
    var arrListStr = Index.GetCountry(area.value).value;
    arrListStr = 'Please select a country ||' + arrListStr;
    var arrList = arrListStr.split("||");
    arrList.pop(arrList[arrList.length-1]);
    
    country.length=0;
    
    for(var i=0;i<arrList.length;i++)
      { 
      country[i]=new Option(arrList[i],arrList[i]); 
      }
}
function FillCity() {
    var country = document.getElementById("ddlCountry_T")
    
    if (country.selectedIndex == 0)
    {
        city.length=0;
     return;}
    
    var city = document.getElementById("ddlCity_T")
    
    var arrListStr = Index.GetCity(country.value).value;
    arrListStr = 'Please select a city ||' + arrListStr;
    var arrList = arrListStr.split("||");
    arrList.pop(arrList[arrList.length-1]);
    
    city.length=0;
    
    for(var i=0;i<arrList.length;i++)
      { 
      city[i]=new Option(arrList[i],arrList[i]); 
      }
}   


var dateRangeKey = new Array(); 
var dateRangeValue = new Array();
var dateLimitValue = new Array();

                 
function SetCoercion(a, b) 
{
    var sdt = new Date(document.getElementById(a).value);
	var edt = new Date(document.getElementById(b).value);
	
    if (sdt <= edt)
    {
        var newDate = new Date(edt.valueOf() + 1*24*60*60*1000);

        var yy = newDate.getFullYear();
        var mm = newDate.getMonth() + 1;
        var dd = newDate.getDate();
        
        yy = yy.toString().substring(0,4);
        
        if (mm < 10)
        {
            mm = "0" + mm;
        }
        
        if (dd < 10)
        {
            dd = "0" + dd; 
        }
        
        document.getElementById(a).value = mm + "/" + dd + "/" + yy;
    }

    if (document.getElementById(a).value == "__/__/____")
    {
        var newDate = new Date();

        var yy = newDate.getFullYear();
        var mm = newDate.getMonth() + 1;
        var dd = newDate.getDate();
        
        yy = yy.toString().substring(0,4);
        
        if (mm < 10)
        {
            mm = "0" + mm;
        }
        
        if (dd < 10)
        {
            dd = "0" + dd; 
        }
        
        document.getElementById(a).value = mm + "/" + dd + "/" + yy;
    }
}

function SetLengthOfStay()
{
    var rdbOneway = document.forms[0].elements['rdbOneway'];   
    if(!rdbOneway.checked)
    {
        var input1 = document.forms[0].elements['depFlightCalendar_calendarDate'];
        var input2 = document.forms[0].elements['rtnFlightCalendar_calendarDate'];
        var txtLengthOfStay = document.forms[0].elements['txtLengthOfStay'];        
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


 function ShowHidePassengers()
{
    DoShowHidePassengers();
}

function DoShowHidePassengers()
{
    if(document.getElementById("dllRooms"))
    {
        if(document.getElementById("dllRooms").value == "1")
        {
                document.getElementById("tbRoom2").style.display = "none";
                document.getElementById("tbRoom3").style.display = "none";
                document.getElementById("tbRoom4").style.display = "none";
        }
        if(document.getElementById("dllRooms").value == "2")
        {
                document.getElementById("tbRoom2").style.display = "";
                document.getElementById("tbRoom3").style.display = "none";
                document.getElementById("tbRoom4").style.display = "none";
        }
        if(document.getElementById("dllRooms").value == "3")
        {
                document.getElementById("tbRoom2").style.display = "";
                document.getElementById("tbRoom3").style.display = "";
                document.getElementById("tbRoom4").style.display = "none";
        }
        if(document.getElementById("dllRooms").value == "4")
        {
                document.getElementById("tbRoom2").style.display = "";
                document.getElementById("tbRoom3").style.display = "";
                document.getElementById("tbRoom4").style.display = "";
        }
    }
}


// Air + hotel display checkin and checkout
function ShowHotelCheckDates()
{
    if(!document.getElementById("ckbHotel").checked)
    {
        document.getElementById("tdHotel").style.display = "none";
    }
    else
    {
        document.getElementById("tdHotel").style.display = "";
    }
}






//
var arrList;
var tempDate;
var tempName;
var arrCityList;

function GetCitysList(code)
{
    var flag = document.getElementById("cityandairport");
    
    InitCityAndAirport();
    
    if( flag.value.toUpperCase() != "H")
    {
        //arrList = new Array("Tirana Rinas Airport - TIA , Tirana , AL "," Algiers Houari Boumediene Airport - ALG , Algiers , DZ "," Constantine Ain El Bey Airport - CZL , Constantine , DZ "," In Amenas Airport - IAM , Zerzaltine , DZ "," Andorra Airport - ALV , Andorra la Vella , AD "," Buenos Aires Aeroparque J. Newbery Airport - AEP , Buenos Aires , AR "," Buenos Aires Ministro Pistarini Airport - EZE , Buenos Aires , AR "," Adelaide Airport - ADL , Adelaide , AU "," Alice Springs Airport - ASP , Alice springs , AU "," Bairnsdale Airport - BSJ , Bairnsdale , AU "," Benalla Airport - BLN , Benalla , AU "," Bendigo Airport - BXG , Bendigo , AU "," Biloela Airport - ZBL , Biloela , AU "," Brisbane Int'l Airport - BNE , Brisbane , AU "," Bunbury Airport - BUY , Bunbury , AU "," Burnie Wynyard Airport - BWT , Burnie , AU "," Cairns Airport - CNS , Cairns , AU "," Caloundra Airport - CUD , Caloundra , AU "," Australian Capital Ter Airport - CBR , CANBERRA , AU "," Charters Towers Airport - CXT , Charters towers , AU "," Colac Airport - XCO , Colac , AU "," Collie Airport - CIE , Collie , AU "," Darwin Airport - DRW , Darwin , AU "," Devonport Airport - DPO , Devonport , AU "," Geelong Airport - GEX , Geelong , AU "," Gold Coast Coolangatta Airport - OOL , Gold coast , AU "," Gympie Airport - GYP , Gympie , AU "," Hervey Bay Airport - HVB , Hervey bay , AU "," Jabiru Airport - JAB , Jabiru , AU "," Karratha Airport - KTA , Karratha , AU "," Kingaroy Airport - KGY , Kingaroy , AU "," Kununurra Airport - KNX , Kununurra , AU "," Launceston Airport - LST , Launceston , AU "," Mackay Airport - MKY , Mackay , AU "," Maningrida Airport - MNG , Maningrida , AU "," Mareeba Airport - MRG , Mareeba , AU "," Avalon Airport - AVV , Melbourne , AU "," Tullamarine Airport - MEL , Melbourne , AU "," Mildura Airport - MQL , Mildura , AU "," Milingimbi Airport - MGT , Milingimbi , AU "," Moranbah Airport - MOV , Moranbah , AU "," Mt. Gambier Airport - MGB , Mount gambier , AU "," Mt. Isa Airport - ISA , Mount isa , AU "," Nambour Airport - NBR , Nambour , AU "," Ngukurr Airport - RPM , Ngukurr , AU "," Perth Airport - PER , Perth , AU "," Port Augusta Airport - PUG , Port augusta , AU "," Port Hedland Airport - PHE , Port hedland , AU "," Port Keats Airport - PKT , Port keats , AU "," Port Lincoln Airport - PLO , Port lincoln , AU "," Port Pirie Airport - PPI , Port pirie , AU "," Rockhampton Airport - ROK , Rockhampton , AU "," Roebourne Airport - RBU , Roebourne , AU "," Stawell Airport - SWC , Stawell , AU "," Swan Hill Airport - SWH , Swan hill , AU "," Tennant Creek Airport - TCA , Tennant creek , AU "," Toowoomba Airport - TWB , Toowoomba , AU "," Townsville Airport - TSV , Townsville , AU "," Traralgon Airport - TGN , Traralgon , AU "," Wangaratta Airport - WGT , Wangaratta , AU "," Warrnambool Airport - WMB , Warrnambool , AU "," Wellington Airport - WLG , Wellington , AU "," Whyalla Airport - WYA , Whyalla , AU "," Vienna Airport - VIE , Vienna , AW "," Bahrain Int'l Airport - BAH , Bahrain , BH "," Khulna Airport - KHL , Khulna , BD "," Bridgetown Grantley Adams Int'l Airport - BGI , Bridgetown , BB "," Deurne Airport - ANR , ANTWERP , BE "," Brussels National Airport - BRU , BRUSSELS , BE "," Ostend Airport - OST , Ostend , BE "," Belmopan Airport - BCV , Belmopan , BZ "," Dangriga Airport - DGA , Dangriga , BZ "," Cotonou Airport - COO , Cotonou , BJ "," Djougou Airport - DJA , Djougou , BJ "," Kandi Airport - KDC , Kandi , BJ "," Natitingou Airport - NAE , Natitingou , BJ "," Parakou Airport - PKO , Parakou , BJ "," Bermejo Airport - BJO , Bermejo , BO "," Camiri Airport - CAM , Camiri , BO "," Cobija E. Beltram Airport - CIJ , Cobija , BO "," Cochabamba J Wilsterman Airport - CBB , Cochabamba , BO "," Monteagudo Airport - MHW , Monteagudo , BO "," Oruro Airport - ORU , Oruro , BO "," Riberalta Gen Buech Airport - RIB , Riberalta , BO "," Rurrenabaque Airport - RBQ , Rurrenabaque , BO "," San Borja Capitan G Q Guardia Airport - SRJ , San borja , BO "," Santa Cruz Viru Viru Int'l Airport - VVI , Santa cruz , BO "," Villamontes Airport - VLM , Villamontes , BO "," Banja Luka Airport - BNX , Banja luka , BA "," Mostar Airport - OMO , Mostar , BA "," Sarajevo Butmir Airport - SJJ , Sarajevo , BA "," Francistown Airport - FRW , Francistown , BW "," Gaborone Sir Seretse Khama Int'l Airport - GBE , Gaborone , BW "," Hukuntsi Airport - HUK , Hukuntsi , BW "," Jwaneng Airport - JWA , Jwaneng , BW "," Lobatse Airport - LOQ , Lobatse , BW "," Maun Airport - MUB , Maun , BW "," Orapa Airport - ORP , Orapa , BW "," Shakawe Airport - SWX , Shakawe , BW "," Tsabong Airport - TBY , Tsabong , BW "," Brasilia Intl Airport - BSB , BRASILIA , BR "," SAO PAULO Airport - SAO , San Paulo , BR "," Bandar Seri Begawan Brunei Internat Airport - BWN , Bandar seri begawan , BN "," Kuala Belait Airport - KUB , Kuala belait , BN "," Jambol Airport - JAM , Jambol , BG "," Plovdiv Airport - PDV , Plovdiv , BG "," Sofia Vrazhdebna Airport - SOF , Sofia , BG "," Varna Airport - VAR , Varna , BG "," Banfora Airport - BNR , Banfora , BF "," Bobo Dioulasso Borgo Airport - BOY , Bobo dioulasso , BF "," Boulsa Airport - XBO , Boulsa , BF "," Diapaga Airport - DIP , Diapaga , BF "," Djibo Airport - XDJ , Djibo , BF "," Dori Airport - DOR , Dori , BF "," Gaoua Airport - XGA , Gaoua , BF "," Gorom-Gorom Airport - XGG , Gorom-gorom , BF "," Kaya Airport - XKY , Kaya , BF "," Nouna Airport - XNU , Nouna , BF "," Ouagadougou Airport - OUA , Ouagadougou , BF "," Ouahigouya Airport - OUG , Ouahigouya , BF "," Pama Airport - XPA , Pama , BF "," Sebba Airport - XSE , Sebba , BF "," Tenkodogo Airport - TEG , Tenkodogo , BF "," Tougan Airport - TUQ , Tougan , BF "," Bafoussam Airport - BFX , Bafoussam , CM "," Bamenda Airport - BPC , Bamenda , CM "," Batouri Airport - OUR , Batouri , CM "," Bertoua Airport - BTA , Bertoua , CM "," Douala Airport - DLA , Douala , CM "," Ebolowa Airport - EBW , Ebolowa , CM "," Foumban Airport - FOM , Foumban , CM "," Garoua Airport - GOU , Garoua , CM "," Kribi Airport - KBI , Kribi , CM "," Limbe Airport - VCC , Limbe , CM "," Mamfe Airport - MMF , Mamfe , CM "," Maroua Salam Airport - MVR , Maroua , CM "," Nkongsamba Airport - NKS , Nkongsamba , CM "," Tiko Airport - TKC , Tiko , CM "," Yagoua Airport - GXX , Yagoua , CM "," 108 Mile Ranch Airport - ZMH , 108 mile ranch , CA "," Albuquerque Int'l Airport - ABQ , 108 mile ranch , CA "," Abbotsford Airport - YXX , Abbotsford , CA "," Aklavik Airport - LAK , Aklavik , CA "," Akulivik Airport - AKV , Akulivik , CA "," Alert Airport - YLT , Alert , CA "," Alert Bay Airport - YAL , Alert bay , CA "," Alice Arm Airport - ZAA , Alice arm , CA "," Alma Airport - YTF , Alma , CA "," Alta Lake Airport - YAE , Alta lake , CA "," Amos Airport - YEY , Amos , CA "," Anahim Lake Airport - YAA , Anahim lake , CA "," Angling Lake Airport - YAX , Angling lake , CA "," Arctic Bay Airport - YAB , Arctic bay , CA "," Tsiigehtchic/Arctic Re Airport - ZRR , Arctic red river , CA "," Armstrong Airport - YYW , Armstrong , CA "," Arnes Airport - YNR , Arnes , CA "," Arviat Airport - YEK , Arviat , CA "," Asbestos Hill Airport - YAF , Asbestos hill , CA "," Ashcroft Airport - YZA , Ashcroft , CA "," Atikokan Airport - YIB , Atikokan , CA "," Attawapiskat Airport - YAT , Attawapiskat , CA "," Aupaluk Airport - YPJ , Aupaluk , CA "," Bagotville Airport - YBG , Bagotville , CA "," Baie Johan Beetz Airport - YBJ , Baie johan beetz , CA "," Baker Lake Airport - YBK , Baker lake , CA "," Bamfield Airport - YBF , Bamfield , CA "," Banff Airport - YBA , Banff , CA "," Bathurst Airport - ZBF , Bathurst , CA "," Bearskin Lake Airport - XBE , Bearskin lake , CA "," Beatton River Airport - YZC , Beatton river , CA "," Beaver Creek Airport - YXQ , Beaver creek , CA "," Bedwell Harbor Airport - YBW , Bedwell harbor , CA "," Bella Bella Airport - ZEL , Bella bella , CA "," Bella Coola Airport - QBC , Bella coola , CA "," Berens River Airport - YBV , Berens river , CA "," Big Bay Yacht Club Airport - YYA , Big bay , CA "," Big Bay Marina Airport - YIG , Big bay marina , CA "," Big Trout Airport - YTL , Big trout , CA "," Blanc Sablon Airport - YBX , Blanc sablon , CA "," Bloodvein Airport - YDV , Bloodvein , CA "," Blubber Bay Airport - XBB , Blubber bay , CA "," Bobquinn Lake Airport - YBO , Bob quinn lake , CA "," Bonaventure Airport - YVB , Bonaventure , CA "," Bonnyville Airport - YBY , Bonnyville , CA "," Borden Airport - YBN , Borden , CA "," Brandon Airport - YBR , Brandon , CA "," Broadview Airport - YDR , Broadview , CA "," Brochet Airport - YBT , Brochet , CA "," Brockville Airport - XBR , Brockville , CA "," Bromont Airport - ZBM , Bromont , CA "," Bronson Creek Airport - YBM , Bronson creek , CA "," Broughton Island Airport - YVM , Broughton island , CA "," Buffalo Narrows Airport - YVT , Buffalo narrows , CA "," Bull Harbour Airport - YBH , Bull harbour , CA "," Burns Lake Airport - YPZ , Burns lake , CA "," Burwash Landings Airport - YDB , Burwash landings , CA "," Calgary Int'l Airport - YYC , Calgary , CA "," Cambridge Bay Airport - YCB , Cambridge bay , CA "," Cape Dorset Airport - YTE , Cape dorset , CA "," Cape Dyer Airport - YVN , Cape dyer , CA "," Cape St. James Airport - YCJ , Cape saint james , CA "," Caribou Island Airport - YCI , Caribou island , CA "," Cartierville Airport - YCV , Cartierville , CA "," Castlegar Airport - YCG , Castlegar , CA "," Cat Lake Airport - YAC , Cat lake , CA "," Centralia Airport - YCE , Centralia , CA "," Chapleau Airport - YLD , Chapleau , CA "," Charlo Airport - YCL , Charlo , CA "," Charlottetown Airport - YHG , Charlottetown , CA "," Charlottetown Airport - YYG , Charlottetown , CA "," Chatham Airport - XCM , Chatham , CA "," Chatham Miramichi Airport - YCH , Chatham , CA "," Chesterfield Inlet Airport - YCS , Chesterfield inlet , CA "," Chetwynd Airport - YCQ , Chetwynd , CA "," Chevery Airport - YHR , Chevery , CA "," Chibougamau Airport - YMT , Chibougamau , CA "," Chilko Lake Airport - CJH , Chilko lake , CA "," Chilliwack Airport - YCW , Chilliwack , CA "," Chisasibi Airport - YKU , Chisasibi , CA "," Clinton Creek Airport - YLM , Clinton creek , CA "," Cluff Lake Airport - XCL , Cluff lake , CA "," Clyde River Airport - YCY , Clyde river , CA "," Cochrane Airport - YCN , Cochrane , CA "," Cold Lake Airport - YOD , Cold lake , CA "," Collins Bay Airport - YKC , Collins bay , CA "," Colville Lake Airport - YCK , Colville lake , CA "," Comox Airport - YQQ , Comox , CA "," Co-op Point Airport - YCP , Coop point , CA "," Kugluktuk/Coppermine Kugluktuk Airport - YCO , Coppermine , CA "," Coral Harbour Airport - YZS , Coral harbour , CA "," Cornwall Regional Airport - YCC , Cornwall , CA "," Coronation Airport - YCT , Coronation , CA "," Cortes Bay Airport - YCF , Cortes bay , CA "," Courtenay Airport - YCA , Courtenay , CA "," Cowley Airport - YYM , Cowley , CA "," Cranbrook Airport - YXC , Cranbrook , CA "," Fairmount Springs Airport - YCZ , Creston , CA "," Cross Lake Airport - YCR , Cross lake , CA "," Cullaton Lake Airport - YCU , Cullaton lake , CA "," Dauphin Airport - YDN , Dauphin , CA "," Dawson City Airport - YDA , Dawson , CA "," Dawson Creek Airport - YDQ , Dawson creek , CA "," Dean River Airport - YRD , Dean river , CA "," Dease Lake Airport - YDL , Dease lake , CA "," Deception Airport - YGY , Deception , CA "," Deer Lake Airport - YDF , Deer lake , CA "," Deer Lake Airport - YVZ , Deer lake , CA "," Deline Airport - YWJ , Deline , CA "," Desolation Sound Airport - YDS , Desolation sound , CA "," Digby Airport - YDG , Digby , CA "," Doc Creek Airport - YDX , Doc creek , CA "," Dolbeau St. Methode Airport - YDO , Dolbeau-saint methode , CA "," Douglas Lake Airport - DGF , Douglas lake , CA "," Drayton Valley Industrial Airport - YDC , Drayton , CA "," Dryden Municipal Airport - YHD , Dryden , CA "," Duncan/Quam Airport - DUQ , Duncan/quam , CA "," Earlton Airport - YXR , Earlton , CA "," East Main Airport - ZEM , East main , CA "," Edson Airport - YET , Edson , CA "," Elliot Lake Airport - YEL , Elliot lake , CA "," Ennadai Lake Airport - YEI , Ennadai , CA "," Esquimalt Airport - YPF , Esquimalt , CA "," Estevan Airport - YEN , Estevan , CA "," Estevan Point Airport - YEP , Estevan point , CA "," Eureka Airport - YEU , Eureka , CA "," Fairview Airport - ZFW , Fairview , CA "," Falher Airport - YOE , Falher , CA "," Faro Airport - ZFA , Faro , CA "," Flin Flon Airport - YFO , Flin flon , CA "," Fond du Lac Airport - ZFD , Fond-du-lac , CA "," Fontanges Airport - YFG , Fontanges , CA "," Forestville Airport - YFE , Forestville , CA "," Fort Albany Airport - YFA , Fort albany , CA "," Fort Chipewyan Airport - YPY , Fort chipewyan , CA "," Fort Frances Municipal Airport - YAG , Fort frances , CA "," Fort Good Hope Airport - YGH , Fort good hope , CA "," Fort Hope Airport - YFH , Fort hope , CA "," Fort Liard Airport - YJF , Fort liard , CA "," Fort Mcmurray Airport - YMM , Fort mcmurray , CA "," Fort Mcpherson Airport - ZFM , Fort mcpherson , CA "," Fort Nelson Airport - YYE , Fort nelson , CA "," Tulita/Fort Norman Tulita Airport - ZFN , Fort norman , CA "," Jasper-Hinton Airport - YJP , Fort providence , CA "," Fort Reliance Airport - YFL , Fort reliance , CA "," Fort Resolution Airport - YFR , Fort resolution , CA "," Fort Severn Airport - YER , Fort severn , CA "," Fort Simpson Airport - YFS , Fort simpson , CA "," Fort Smith Airport - YSM , Fort smith , CA "," Fredericton Airport - YFC , Fredericton , CA "," Fredericton Junction Service Airport - XFC , Fredericton junction service , CA "," Gagetown Airport - YCX , Gagetown , CA "," Gagnon Airport - YGA , Gagnon , CA "," Ganges Harbor Airport - YGG , Ganges harbor , CA "," Garrow Lake Airport - GOW , Garrow lake , CA "," Gaspe Airport - YGP , Gaspe , CA "," Gatineau Airport - YND , Gatineau , CA "," Geraldton Airport - YGQ , Geraldton , CA "," Germansen Airport - YGS , Germansen , CA "," Gethsemani Airport - ZGS , Gethsemani , CA "," Gillam Airport - YGX , Gillam , CA "," Gillies Bay Airport - YGB , Gillies bay , CA "," Gimli Airport - YGM , Gimli , CA "," Gjoa Haven Airport - YHK , Gjoa haven , CA "," Gods Narrows Airport - YGO , Gods narrows , CA "," Gods River Airport - ZGI , Gods river , CA "," Goose Bay Airport - YYR , Goose bay , CA "," Gore Bay Airport - YZE , Gore bay , CA "," Gorge Harbor Airport - YGE , Gorge harbor , CA "," Grand Forks Airport - ZGF , Grand forks , CA "," Grande Cache Airport - YGC , Grande cache , CA "," Grande Prairie Airport - YQU , Grande prairie , CA "," Granville Lake Airport - XGL , Granville lake , CA "," Great Bear Lake Airport - DAS , Great bear lake , CA "," Greenway Sound Airport - YGN , Greenway sound , CA "," Greenwood Airport - YZX , Greenwood , CA "," Grise Fiord Airport - YGZ , Grise fiord , CA "," Haines Junction Airport - YHT , Haines junction , CA "," Hakai Pass Airport - YHC , Hakai pass , CA "," Halifax Int'l Airport - YHZ , Halifax , CA "," Halifax Shearwater Airport - YAW , Halifax shearwater , CA "," Hall Beach Airport - YUX , Hall beach , CA "," Hamilton Airport - YHM , Hamilton , CA "," Hartley Bay Airport - YTB , Hartley bay , CA "," Hatchet Lake Airport - YDJ , Hatchet lake , CA "," Obre Lake Airport - YDW , Hatchet lake , CA "," Havre St. Pierre Airport - YGV , Havre saint pierre , CA "," Hay River Airport - YHY , Hay river , CA "," Hearst Airport - YHF , Hearst , CA "," High Level Footner Lake Airport - YOJ , High level , CA "," High Prairie Airport - ZHP , High prairie , CA "," Holman Airport - YHI , Holman , CA "," Hope Airport - YHE , Hope , CA "," Hornepayne Airport - YHN , Hornepayne , CA "," Hudson Bay Airport - YHB , Hudson bay , CA "," Hudson Hope Airport - YNH , Hudson hope , CA "," Igloolik Airport - YGT , Igloolik , CA "," Ignace Airport - ZUC , Ignace , CA "," Ilford Airport - ILF , Ilford , CA "," Inukjuak Airport - YPH , Inukjuak , CA "," Inuvik/Mike Zubko Airport - YEV , Inuvik , CA "," Inverlake Airport - TIL , Inverlake , CA "," Iqaluit Airport - YFB , Iqaluit , CA "," Isachsen Airport - YIC , Isachsen , CA "," Island Lk/Garden Hill Airport - YIV , Island lake/garden hill , CA "," Ivujivik Airport - YIK , Ivujivik , CA "," Jenpeg Airport - ZJG , Jenpeg , CA "," Johnny Mountain Airport - YJO , Johnny mountain , CA "," Johnson Point Airport - YUN , Johnson point , CA "," Kamloops Airport - YKA , Kamloops , CA "," Kangiqsualujjuaq Airport - XGR , Kangiqsualujjuaq , CA "," Kangirsuk Airport - YKG , Kangirsuk , CA "," Kapuskasing Airport - YYU , Kapuskasing , CA "," Kasabonika Airport - XKS , Kasabonika , CA "," Kasba Lake Airport - YDU , Kasba lake , CA "," Kaschechewan Airport - ZKE , Kaschechewan , CA "," Keewaywin Airport - KEW , Keewaywin , CA "," Kegaska Airport - ZKG , Kegaska , CA "," Kelowna Airport - YLW , Kelowna , CA "," Kelsey Airport - KES , Kelsey , CA "," Kemano Airport - XKO , Kemano , CA "," Kenora Airport - YQK , Kenora , CA "," Key Lake Airport - YKJ , Key lake , CA "," Killaloe Airport - YXI , Killaloe , CA "," Killineq Airport - XBW , Killineq , CA "," Kimberley Airport - YQE , Kimberley , CA "," Kincardine Township Airport - YKD , Kincardine township , CA "," Kindersley Airport - YKY , Kindersley , CA "," Kingfisher Lake Airport - KIF , Kingfisher lake , CA "," Kingston Airport - YGK , Kingston , CA "," Kinoosao Airport - KNY , Kinoosao , CA "," Kirkland Lake Airport - YKX , Kirkland lake , CA "," Kitchener-Waterloo Reg Airport - YKF , Kitchener lake , CA "," Kennosao Lake Airport - YKI , Kitimat , CA "," Kitkatla Airport - YKK , Kitkatla , CA "," Klemtu Airport - YKT , Klemtu , CA "," Knee Lake Airport - YKE , Knee lake , CA "," Knights Inlet Airport - KNV , Knights inlet , CA "," Koala Airport - YOA , Koala , CA "," Kuujjuaq Airport - YVP , Kuujjuaq , CA "," Kuujjuarapik Airport - YGW , Kuujjuarapik , CA "," La Forges Airport - YLF , La forges , CA "," Snare Lake Airport - YFJ , La macaza , CA "," La Ronge Airport - YVC , La ronge , CA "," La Sarre Airport - SSQ , La sarre , CA "," La Tabatiere Airport - ZLT , La tabatiere , CA "," La Tuque Airport - YLQ , La tuque , CA "," Lac Biche Airport - YLB , Lac biche , CA "," Lac Brochet Airport - XLB , Lac brochet , CA "," Wha Ti/Lac la Martre Wha Ti Airport - YLE , Lac la martre , CA "," Lady Franklin Airport - YUJ , Lady franklin , CA "," Kimmirut/Lake Harbour Airport - YLC , Lake harbour , CA "," Langara Airport - YLA , Langara , CA "," Lansdowne House Airport - YLH , Lansdowne house , CA "," Laurie River Airport - LRQ , Laurie river , CA "," Leaf Bay Airport - XLF , Leaf bay , CA "," Leaf Rapids Airport - YLR , Leaf rapids , CA "," Lebel-sur-Quevillon Airport - YLS , Lebel-sur-quevillon , CA "," Lethbridge Airport - YQL , Lethbridge , CA "," Little Grand Rapids Airport - ZGR , Little grand rapids , CA "," Kattiniq/Donaldson La Airport - YAU , Liverpool , CA "," Lloydminster Airport - YLL , Lloydminster , CA "," Long Point Airport - YLX , Long point , CA "," Lupin Airport - YWO , Lupin , CA "," Lyall Harbour Airport - YAJ , Lyall harbour , CA "," Lynn Lake Airport - YYL , Lynn lake , CA "," Macmillan Pass Airport - XMP , Macmillan pass , CA "," Main Duck Island Airport - YDK , Main duck , CA "," Manitouwadge Airport - YMG , Manitouwadge , CA "," Manitowaning East Manitoulin Airport - YEM , Manitowaning , CA "," Maniwaki Airport - YMW , Maniwaki , CA "," Maple Bay Airport - YAQ , Maple bay , CA "," Marathon Airport - YSP , Marathon , CA "," Masset Airport - ZMT , Masset , CA "," Matagami Airport - YNM , Matagami , CA "," Matane Airport - YME , Matane , CA "," Mayo Airport - YMA , Mayo , CA "," Meadow Lake Airport - YLJ , Meadow lake , CA "," Medicine Hat Airport - YXH , Medicine hat , CA "," Merritt Airport - YMB , Merritt , CA "," Merry Island Airport - YMR , Merry island , CA "," Minaki Airport - YMI , Minaki , CA "," Miners Bay Airport - YAV , Miners bay , CA "," Mingan Airport - YLP , Mingan , CA "," Moncton Airport - YQM , Moncton , CA "," Mont Joli Airport - YYY , Mont joli , CA "," Montagne Harbor Airport - YMF , Montagne harbor , CA "," All Airports - YMQ , MONTREAL , CA "," Moose Jaw Airport - YMJ , Moose jaw , CA "," Moose Lake Airport - YAD , Moose lake , CA "," Moosonee Airport - YMO , Moosonee , CA "," Mould Bay Airport - YMD , Mould bay , CA "," Murray Bay Charlevoix Airport - YML , Murray bay , CA "," Muskoka Airport - YQA , Muskoka , CA "," Muskrat Dam Airport - MSA , Muskrat dam , CA "," Nakina Airport - YQN , Nakina , CA "," Namu Airport - ZNU , Namu , CA "," Nanisivik Airport - YSR , Nanisivik , CA "," Natashquan Airport - YNA , Natashquan , CA "," Negginan Airport - ZNG , Negginan , CA "," Nemiscau Airport - YNS , Nemiscau , CA "," Nitchequon Airport - YNI , Nitchequon , CA "," Nootka Sound Airport - YNK , Nootka sound , CA "," Norman Wells Airport - YVQ , Norman wells , CA "," North Battleford Airport - YQW , North battleford , CA "," North Bay Airport - YYB , North bay , CA "," North Spirit Lake Airport - YNO , North spirit lake , CA "," Norway House Airport - YNE , Norway house , CA "," Ocean Falls Airport - ZOF , Ocean falls , CA "," Ogoki Airport - YOG , Ogoki post , CA "," Old Crow Airport - YOC , Old crow , CA "," Old Fort Bay Airport - ZFB , Old fort bay , CA "," Opapamiska Lake Musselwhite Airport - YBS , Opapamiska lake musselwhite , CA "," Oshawa Airport - YOO , Oshawa , CA "," Owen Sound Billy Bishop Regional Airport - YOS , Owen sound , CA "," Oxford House Airport - YOH , Oxford house , CA "," Pakuashipi Airport - YIF , Pakuashipi , CA "," Pangnirtung Airport - YXP , Pangnirtung , CA "," Parry Sound Airport - YPD , Parry sound , CA "," Paulatuk Airport - YPC , Paulatuk , CA "," Peace River Airport - YPE , Peace river , CA "," Peawanuck Airport - YPO , Peawanuck , CA "," Pembroke and Area Airport - YTA , Pembroke , CA "," Pender Harbor Airport - YPT , Pender harbor , CA "," Penticton Airport - YYF , Penticton , CA "," Petawawa Airport - YWA , Petawawa , CA "," Peterborough Airport - YPQ , Peterborough , CA "," Pickle Lake Airport - YPL , Pickle lake , CA "," Pikangikum Airport - YPM , Pikangikum , CA "," Pikwitonei Airport - PIW , Pikwitonei , CA "," Pincher Creek Airport - WPC , Pincher creek , CA "," Pine House Airport - ZPO , Pine house , CA "," Pine Point Airport - YPP , Pine point , CA "," Points North Landing Airport - YNL , Points north landing , CA "," Pond Inlet Airport - YIO , Pond inlet , CA "," Poplar Hill Airport - YHP , Poplar hill , CA "," Poplar River Airport - XPP , Poplar river , CA "," Port Alberni Airport - YPB , Port alberni , CA "," Port Hardy Airport - YZT , Port hardy , CA "," Ste. Therese Point Airport - YST , Port hardy , CA "," Port Hawkesbury Airport - YPS , Port hawkesbury , CA "," Port McNeil Airport - YMP , Port mcneil , CA "," Port Menier Airport - YPN , Port menier , CA "," Port Radium Airport - YIX , Port radium , CA "," Port Simpson Airport - YPI , Port simpson , CA "," Portage La Prairie Airport - YPG , Portage , CA "," Povungnituk Puvirnituq Airport - YPX , Povungnituk , CA "," Powell Lake Airport - WPL , Powell lake , CA "," Powell River Airport - YPW , Powell river , CA "," Prince Albert Airport - YPA , Prince albert , CA "," Prince George Airport - YXS , Prince george , CA "," Prince Rupert Digby Island Airport - YPR , Prince rupert digby isl , CA "," Pukatawagan Airport - XPK , Pukatawagan , CA "," Qualicum Airport - XQU , Qualicum , CA "," Quaqtaq Airport - YQC , Quaqtaq , CA "," Queen Charlotte Isl Airport - ZQS , Queen charlotte , CA "," Quesnel Airport - YQZ , Quesnel , CA "," Rae Lakes Airport - YRA , Rae lakes , CA "," Rainbow Lake Airport - YOP , Rainbow lake , CA "," Rankin Inlet Airport - YRT , Rankin inlet , CA "," Red Deer Airport - YQF , Red deer , CA "," Red Lake Airport - YRL , Red lake , CA "," Red Sucker Lake Airport - YRS , Red sucker lake , CA "," Regina Airport - YQR , Regina , CA "," Repulse Bay Airport - YUT , Repulse bay , CA "," Resolute Airport - YRB , Resolute , CA "," Resolution Island Airport - YRE , Resolution island , CA "," Revelstoke Airport - YRV , Revelstoke , CA "," Rimouski Airport - YXK , Rimouski , CA "," Rivers Airport - YYI , Rivers , CA "," Rivers Inlet Airport - YRN , Rivers inlet , CA "," Riviere Au Tonnerre Airport - YTN , Riviere au tonnerre , CA "," Riviere du Loup Airport - YRI , Riviere du loup , CA "," Roberval Airport - YRJ , Roberval , CA "," Rocky Mountain House Airport - YRM , Rocky mountain house , CA "," Ross River Airport - XRR , Ross river , CA "," Round Lake Airport - ZRJ , Round lake , CA "," Rouyn Airport - YUY , Rouyn , CA "," Sable Island Airport - YSA , Sable island , CA "," Sachigo Lake Airport - ZPB , Sachigo lake , CA "," Sachs Harbour Airport - YSY , Sachs harbour , CA "," St. Catharines Airport - YCM , Saint catharines , CA "," St. Jean Airport - YJN , Saint jean , CA "," St. John Airport - YSJ , Saint john , CA "," St. Paul Airport - ZSP , Saint paul , CA "," St. Thomas Pembroke Area Mncpl Airport - YQS , Saint thomas , CA "," Salluit Airport - YZG , Salluit , CA "," Salmon Arm Airport - YSN , Salmon arm , CA "," Sandspit Airport - YZP , Sandspit , CA "," Sandy Lake Airport - ZSJ , Sandy lake , CA "," Sanikiluaq Airport - YSK , Sanikiluaq , CA "," Sans Souci Airport - YSI , Sans souci , CA "," Sarnia Airport - YZR , Sarnia , CA "," Saskatoon Airport - YXE , Saskatoon , CA "," Schefferville Airport - YKL , Schefferville , CA "," Sechelt Airport - YHS , Sechelt , CA "," Shamattawa Airport - ZTM , Shamattawa , CA "," Shearwater Airport - YSX , Shearwater , CA "," Sherbrooke Airport - YSC , Sherbrooke , CA "," Shilo Airport - YLO , Shilo , CA "," Silva Bay Airport - SYF , Silva bay , CA "," Sioux Lookout Airport - YXL , Sioux lookout , CA "," Slate Island Airport - YSS , Slate island , CA "," Slave Lake Airport - YZH , Slave lake , CA "," Smith Falls Airport - YSH , Smith falls , CA "," Smithers Airport - YYD , Smithers , CA "," Snake River Airport - YXF , Snake river , CA "," Lutselke/Snowdrift Lutselke Airport - YSG , Snowdrift , CA "," South Indian Lake Airport - XSI , South indian lake , CA "," South Trout Lake Airport - ZFL , South trout lake , CA "," Spring Island Airport - YSQ , Spring island , CA "," Squamish Airport - YSE , Squamish , CA "," Squirrel Cove Airport - YSZ , Squirrel cove , CA "," St. John's Airport - YYT , St.johns , CA "," Stewart Airport - ZST , Stewart , CA "," Stony Rapids Airport - YSF , Stony rapids , CA "," Stuart Island Airport - YRR , Stuart island , CA "," Sturdee Airport - YTC , Sturdee , CA "," Sudbury Airport - YSB , Sudbury , CA "," Suffield Airport - YSD , Suffield , CA "," Sullivan Bay Airport - YTG , Sullivan bay , CA "," Summer Beaver Airport - SUR , Summer beaver , CA "," Summerside Airport - YSU , Summerside , CA "," Summit Lake Airport - IUM , Summit lake , CA "," Swan River Airport - ZJN , Swan river , CA "," Swift Current Airport - YYN , Swift current , CA "," Sydney Airport - YQY , Sydney , CA "," Tadoule Lake Airport - XTL , Tadoule lake , CA "," Telegraph Harbour Airport - YBQ , Tadoule lake , CA "," Tahsis Airport - ZTS , Tahsis , CA "," Taloyoak Airport - YYH , Taloyoak , CA "," Taltheilei Narrows Airport - GSL , Taltheilei narrows , CA "," Tasiujuaq Airport - YTQ , Tasiujuaq , CA "," Tasu Airport - YTU , Tasu , CA "," Telegraph Creek Airport - YTX , Telegraph creek , CA "," Terrace Airport - YXT , Terrace , CA "," Terrace Bay Airport - YTJ , Terrace bay , CA "," Teslin Airport - YZW , Teslin , CA "," Tete a la Baleine Airport - ZTB , Tete-a-la-baleine , CA "," The Pas Airport - YQD , The pas , CA "," Thicket Portage Airport - YTD , Thicket portage , CA "," Thompson Airport - YTH , Thompson , CA "," Thunder Bay Airport - YQT , Thunder bay , CA "," Timmins Airport - YTS , Timmins , CA "," Tisdale Airport - YTT , Tisdale , CA "," Tofino Airport - YAZ , Tofino , CA "," Toronto - All Airports - YTO , Toronto , CA "," Toronto Buttonville Airport - YKZ , Toronto , CA "," Toronto Island Airport - YTZ , Toronto , CA "," Toronto Pearson Int'l Airport - YYZ , Toronto , CA "," Trenton Airport - YTR , Trenton , CA "," Triple Island Airport - YTI , Triple island , CA "," Trois-Rivieres Airport - YRQ , Trois-rivieres , CA "," Tuktoyaktuk Airport - YUB , Tuktoyaktuk , CA "," Tulugak Airport - YTK , Tulugak , CA "," Tumbler Ridge Airport - TUX , Tumbler ridge , CA "," Tungsten Airport - TNS , Tungsten , CA "," Umiujaq Airport - YUD , Umiujaq , CA "," Uranium City Airport - YBE , Uranium city , CA "," Valcartier Airport - YOY , Valcartier , CA "," McDonald Cartier International Airport - YOW , VANCOUVER , CA "," Vancouver Airport - YVR , VANCOUVER , CA "," Vermilion Airport - YVG , Vermilion , CA "," Vernon Airport - YVE , Vernon , CA "," Wabush Airport - YWK , Wabush , CA "," Waskaganish Airport - YKQ , Waskaganish , CA "," Watson Lake Airport - YQH , Watson lake , CA "," Wawa Airport - YXZ , Wawa , CA "," Webequie Airport - YWP , Webequie , CA "," Wemindji Airport - YNC , Wemindji , CA "," Whale Cove Airport - YXN , Whale cove , CA "," Whistler Airport - YWS , Whistler , CA "," White River Airport - YWR , White river , CA "," Whitecourt Airport - YZU , Whitecourt , CA "," Whitehorse Airport - YXY , Whitehorse , CA "," Wiarton Airport - YVV , Wiarton , CA "," Williams Lake Airport - YWL , Williams lake , CA "," Windsor Airport - YQG , Windsor , CA "," Winisk Airport - YWN , Winisk , CA "," Winnipeg Airport - YWG , Winnipeg , CA "," Wollaston Lake Airport - ZWL , Wollaston lake , CA "," Wrigley Airport - YWY , Wrigley , CA "," Wunnummin Lake Airport - WNN , Wunnummin lake , CA "," Yarmouth Airport - YQI , Yarmouth , CA "," Yellowknife Airport - YZF , Yellowknife , CA "," York Landing Airport - ZAC , York landing , CA "," Yorkton Airport - YQV , Yorkton , CA "," Mosteiros Airport - MTI , Mosteiros , CV "," Praia Francisco Mendes Airport - RAI , Praia , CV "," Bambari Airport - BBY , Bambari , CF "," Bangassou Airport - BGU , Bangassou , CF "," Bangui Airport - BGF , Bangui , CF "," Batangafo Airport - BTG , Batangafo , CF "," Bossangoa Airport - BSN , Bossangoa , CF "," Bouar Airport - BOP , Bouar , CF "," Bouca Airport - BCF , Bouca , CF "," Bozoum Airport - BOZ , Bozoum , CF "," Bria Airport - BIV , Bria , CF "," Carnot Airport - CRF , Carnot , CF "," Ati Airport - ATV , Ati , TD "," Bokoro Airport - BKR , Bokoro , TD "," Bongor Airport - OGR , Bongor , TD "," Bousso Airport - OUT , Bousso , TD "," Faya Airport - FYT , Faya , TD "," Mongo Airport - MVO , Mongo , TD "," Moundou Airport - MQQ , Moundou , TD "," Pala Airport - PLF , Pala , TD "," Sarh Airport - SRH , Sarh , TD "," Ancud Airport - ZUD , Ancud , CL "," Antofagasta Cerro Moreno Airport - ANF , Antofagasta , CL "," Arica Chacalluta Airport - ARI , Arica , CL "," Calama El Loa Airport - CJC , Calama , CL "," Iquique Cavancha Airport - IQQ , Iquique , CL "," La Serena La Florida Airport - LSC , La serena , CL "," Los Andes Airport - LOB , Los andes , CL "," Osorno Canal Balo Airport - ZOS , Osorno , CL "," Ovalle Airport - OVL , Ovalle , CL "," Puerto Montt Tepual Airport - PMC , Puerto montt , CL "," Punta Arenas Pres Ibanez Airport - PUQ , Punta arenas , CL "," Santiago Arturo Merino Benitez Airport - SCL , Santiago , CL "," Talca Airport - TLX , Talca , CL "," Taltal Airport - TTC , Taltal , CL "," Temuco Airport - ZCO , Temuco , CL "," Tocopilla Barriles Airport - TOQ , Tocopilla , CL "," Valdivia Pichoy Airport - ZAL , Valdivia , CL "," Vallenar Airport - VLR , Vallenar , CL "," Aksu Airport - AKU , Aksu , CN "," Ankang Airport - AKA , Ankang , CN "," Anshan Airport - AOG , Anshan , CN "," Anyang Airport - AYN , Anyang , CN "," Baoshan Airport - BSD , Baoshan , CN "," Baotou Airport - BAV , Baotou , CN "," Beihai Airport - BHY , Beihai , CN "," Beijing Airport - PEK , Beijing , CN "," BEIJING INTL - BJS , Beijing , CN "," Bengbu Airport - BFU , Bengbu , CN "," Changchun Airport - CGQ , Changchun , CN "," Changde Airport - CGD , Changde , CN "," Changsha Airport - CSX , Changsha , CN "," Changzhi Airport - CIH , Changzhi , CN "," Changzhou Airport - CZX , Changzhou , CN "," Chaoyang Airport - CHG , Chaoyang , CN "," Chengdu Airport - CTU , Chengdu , CN "," Chi Mei Airport - CMJ , Chi mei , CN "," Chiayi Airport - CYI , Chiayi , CN "," Chifeng Airport - CIF , Chifeng , CN "," Chongqing Airport - CKG , Chongqing , CN "," Dali City Airport - DLU , Dali city , CN "," Dalian Airport - DLC , Dalian , CN "," Dandong Airport - DDG , Dandong , CN "," Datong Airport - DAT , Datong , CN "," Daxian Airport - DAX , Daxian , CN "," Diqing Airport - DIG , Diqing , CN "," Dongguan Airport - DGM , Dongguan , CN "," Dongsheng Airport - DSN , Dongsheng , CN "," Dunhuang Airport - DNH , Dunhuang , CN "," Enshi Airport - ENH , Enshi , CN "," Fuyang Airport - FUG , Fuyang , CN "," Fuyun Airport - FYN , Fuyun , CN "," Fuzhou Airport - FOC , Fuzhou , CN "," Ganzhou Airport - KOW , Ganzhou , CN "," Golmud Airport - GOQ , Golmud , CN "," Green Island Airport - GNI , Green island , CN "," Guangzhou Baiyun Airport - CAN , Guangzhou , CN "," Guilin Airport - KWL , Guilin , CN "," Guiyang Airport - KWE , Guiyang , CN "," Haikou Airport - HAK , Haikou , CN "," Hailar Airport - HLD , Hailar , CN "," Hami Airport - HMI , Hami , CN "," Hangzhou Airport - HGH , Hangzhou , CN "," Hanzhong Airport - HZG , Hanzhong , CN "," Harbin Airport - HRB , Harbin , CN "," Hefei Airport - HFE , Hefei , CN "," Heihe Airport - HEK , Heihe , CN "," Hengchun Airport - HCN , Hengchun , CN "," Hengyang Airport - HNY , Hengyang , CN "," Hohhot Airport - HET , Hohhot , CN "," Hong Kong Int'l Airport - HKG , Hong Kong , CN "," Hotan Airport - HTN , Hotan , CN "," Hsinchu Airport - HSZ , Hsinchu , CN "," Hualien Airport - HUN , Hualien , CN "," Huangyan Airport - HYN , Huangyan , CN "," Huizhou Airport - HUZ , Huizhou , CN "," Jiamusi Airport - JMU , Jiamusi , CN "," Jiayuguan Airport - JGN , Jiayuguan , CN "," Jilin Airport - JIL , Jilin , CN "," Jinan Airport - TNA , Jinan , CN "," Jingdezhen Airport - JDZ , Jingdezhen , CN "," Jinghong Gasa Airport - JHG , Jinghong , CN "," Jining Airport - JNG , Jining , CN "," Jinzhou Airport - JNZ , Jinzhou , CN "," Jiujiang Airport - JIU , Jiujiang , CN "," Jiuquan Airport - CHW , Jiuquan , CN "," JIUHUANG - JZH , Jiuzhaigou , CN "," KAOHSIUNG - KHH , KAOHSIUNG , CN "," Karamay Airport - KRY , Karamay , CN "," Kinmen Shang-Yi Airport - KNH , Kinmen , CN "," Korla Airport - KRL , Korla , CN "," Kunming Airport - KMG , Kunming , CN "," Kuqa Airport - KCA , Kuqa , CN "," LANZHOU - LHW , Lanzhou , CN "," Lhasa Airport - LXA , Lhasa , CN "," Lianyungang Airport - LYG , Lianyungang , CN "," Lijiang City Airport - LJG , Lijiang city , CN "," Linxi Airport - LXI , Linxi , CN "," Linyi Airport - LYI , Linyi , CN "," Lishan Airport - LHN , Lishan , CN "," Liuzhou Airport - LZH , Liuzhou , CN "," Luoyang Airport - LYA , Luoyang , CN "," Luzhou Airport - LZO , Luzhou , CN "," Macau Airport - MFM , Macau , CN "," Makung Airport - MZG , Makung , CN "," Matsu Airport - MFK , Matsu , CN "," Mudanjiang Airport - MDG , Mudanjiang , CN "," Nanchang Airport - KHN , Nanchang , CN "," Nanchong Airport - NAO , Nanchong , CN "," NANJING - NKG , NANGJIN , CN "," Nanning Airport - NNG , Nanning , CN "," Nantong Airport - NTG , Nantong , CN "," Nanyang Airport - NNY , Nanyang , CN "," Ningbo Airport - NGB , Ningbo , CN "," Orchid Island Airport - KYD , Orchid island , CN "," Pingtung Airport - PIF , Pingtung , CN "," Qingdao Airport - TAO , Qingdao , CN "," Qingyang Airport - IQN , Qingyang , CN "," Qinhuangdao Airport - SHP , Qinhuangdao , CN "," Qiqihar Airport - NDG , Qiqihar , CN "," Sanya Airport - SYX , Sanya , CN "," Shanghai Hongqiao Airport - SHA , Shanghai , CN "," Shanghai Pudongs Airport - PVG , Shanghai , CN "," Shantou Airport - SWA , Shantou , CN "," Shaoguan Airport - HSC , Shaoguan , CN "," Shashi Airport - SHS , Shashi , CN "," Shenyang Airport - SHE , Shenyang , CN "," Shenzhen Airport - SZX , Shenzhen , CN "," Shijiazhuang Daguocun Airport - SJW , Shijiazhuang , CN "," Simao Airport - SYM , Simao , CN "," Sun Moon Lake Airport - SMT , Sun moon lake , CN "," Suzhou Airport - SZV , Suzhou , CN "," Taichung Airport - TXG , Taichung , CN "," Tainan Airport - TNN , Tainan , CN "," Taitung Airport - TTT , Taitung , CN "," Taiyuan Airport - TYN , Taiyuan , CN "," Tianjin Airport - TSN , Tianjin , CN "," Tonghua Liuhe Airport - TNH , Tonghua , CN "," Tongliao Airport - TGO , Tongliao , CN "," Tongren Airport - TEN , Tongren , CN "," Ulanhot Airport - HLH , Ulanhot , CN "," Urumqi Airport - URC , Urumqi , CN "," Wanxian Airport - WXN , Wanxian , CN "," Weifang Airport - WEF , Weifang , CN "," Weihai Airport - WEH , Weihai , CN "," Wenzhou Airport - WNZ , Wenzhou , CN "," Wonan Airport - WOT , Wonan , CN "," Wuhan Airport - WUH , Wuhan , CN "," Wuhu Airport - WHU , Wuhu , CN "," Wuxi Airport - WUX , Wuxi , CN "," Wuzhou Changzhoudao Airport - WUZ , Wuzhou , CN "," Xiamen Airport - XMN , Xiamen , CN "," XIAN YANG INTL - SIA , XIAN , CN "," XIAN YANG INTL - XIY , XIAN , CN "," Xiangfan Airport - XFN , Xiangfan , CN "," Xichang Airport - XIC , Xichang , CN "," Xingcheng Airport - XEN , Xingcheng , CN "," Xingtai Airport - XNT , Xingtai , CN "," Xining Airport - XNN , Xining , CN "," Xuzhou Airport - XUZ , Xuzhou , CN "," Yan'an Airport - ENY , Yanan , CN "," Yancheng Airport - YNZ , Yancheng , CN "," Yanji Airport - YNJ , Yanji , CN "," Yantai Laishan Airport - YNT , Yantai , CN "," Yibin Airport - YBP , Yibin , CN "," Yichang Airport - YIH , Yichang , CN "," Yinchuan Airport - INC , Yinchuan , CN "," Yining Airport - YIN , Yining , CN "," Yiwu Airport - YIW , Yiwu , CN "," Yulin Airport - UYN , Yulin , CN "," DAYONG - DYG , ZHANGJIAJIE , CN "," Zhanjiang Airport - ZHA , Zhanjiang , CN "," Zhaotong Airport - ZAT , Zhaotong , CN "," Zhengzhou Airport - CGO , Zhengzhou , CN "," ZHONGSHAN - ZIS , Zhongshan , CN "," Zhoushan Airport - HSN , Zhoushan , CN "," Zhuhai Airport - ZUH , Zhuhai , CN "," Zunyi Airport - ZYI , Zunyi , CN "," Amalfi Airport - AFI , Amalfi , CO "," Arauquita Airport - ARQ , Arauquita , CO "," Barrancabermeja Variguies Airport - EJA , Barrancabermeja , CO "," Barranquilla E Cortissoz Airport - BAQ , Barranquilla , CO "," Eldorado Airport - BOG , BOGOTA , CO "," Bucaramanga Palo Negro Airport - BGA , Bucaramanga , CO "," Buenaventura Airport - BUN , Buenaventura , CO "," Cali Alfonso B. Aragon Airport - CLO , Cali , CO "," Cartagena Rafael Nunez Airport - CTG , Cartagena , CO "," Caucasia Airport - CAQ , Caucasia , CO "," Chaparral Airport - CPL , Chaparral , CO "," Chivolo Airport - IVO , Chivolo , CO "," Cimitarra Airport - CIM , Cimitarra , CO "," Condoto Mandinga Airport - COG , Condoto , CO "," Corozal Airport - CZU , Corozal , CO "," Cravo Norte Airport - RAV , Cravo norte , CO "," El Bagre Airport - EBG , El bagre , CO "," El Banco San Bernado Airport - ELB , El banco , CO "," El Charco Airport - ECR , El charco , CO "," Florencia Capitolio Airport - FLA , Florencia , CO "," Gamarra Airport - GRA , Gamarra , CO "," Girardot Airport - GIR , Girardot , CO "," Guamal Airport - GAA , Guamal , CO "," Hato Corozal Airport - HTZ , Hato corozal , CO "," Ipiales San Luis Airport - IPI , Ipiales , CO "," Jurado Airport - JUO , Jurado , CO "," Macanal Airport - NAD , Macanal , CO "," Maicao Airport - MCJ , Maicao , CO "," Manizales Santaguida Airport - MZL , Manizales , CO "," Mariquita Airport - MQU , Mariquita , CO "," Mosquera Airport - MQR , Mosquera , CO "," Neiva La Marguita Airport - NVA , Neiva , CO "," Paratebueno Airport - EUO , Paratebueno , CO "," Pasto Cano Airport - PSO , Pasto , CO "," Paz de Ariporo Casanare Airport - PZA , Paz de ariporo , CO "," Pereira Matecana Airport - PEI , Pereira , CO "," Pitalito Airport - PTX , Pitalito , CO "," Planadas Airport - PLA , Planadas , CO "," Plato Airport - PLT , Plato , CO "," Pore Airport - PRE , Pore , CO "," Sabana de Torres Airport - SNT , Sabana de torres , CO "," San Luis de Pale Airport - SQE , San luis de palenque , CO "," Santa Marta Simon Bolivar Airport - SMR , Santa marta , CO "," Saravena Airport - RVE , Saravena , CO "," Sogamoso Airport - SOX , Sogamoso , CO "," Tame Airport - TME , Tame , CO "," Tauramena Airport - TAU , Tauramena , CO "," Tumaco La Florida Airport - TCO , Tumaco , CO "," Turbo Gonzalo Airport - TRB , Turbo , CO "," Urrao Airport - URR , Urrao , CO "," Valledupar Airport - VUP , Valledupar , CO "," Villavicencio La Vanguardia Airport - VVC , Villavicencio , CO "," Yavarate Airport - VAB , Yavarate , CO "," Zapatoca Airport - AZT , Zapatoca , CO "," Boende Airport - BNB , Boende , ZR "," Boma Airport - BOA , Boma , ZR "," Bukavu Airport - BKY , Bukavu , ZR "," Bunia Airport - BUX , Bunia , ZR "," Buta Airport - BZU , Buta , ZR "," Gandajika  Airport - GDJ , Gandajika , ZR "," Gbadolite Airport - BDT , Gbadolite , ZR "," Gemena  Airport - GMA , Gemena , ZR "," Goma  Airport - GOM , Goma , ZR "," Ilebo  Airport - PFR , Ilebo , ZR "," Inongo  Airport - INO , Inongo , ZR "," Isiro  Airport - IRP , Isiro , ZR "," Kabalo Airport - KBO , Kabalo , ZR "," Kalima Airport - KLY , Kalima , ZR "," Kamina Airport - KMN , Kamina , ZR "," Kaniama Airport - KNM , Kaniama , ZR "," Kikwit Airport - KKW , Kikwit , ZR "," Kindu Airport - KND , Kindu , ZR "," Kisangani Airport - FKI , Kisangani , ZR "," Kolwezi Airport - KWZ , Kolwezi , ZR "," Kongolo Airport - KOO , Kongolo , ZR "," Lisala  Airport - LIQ , Lisala , ZR "," Lodja  Airport - LJA , Lodja , ZR "," Lubumbashi Airport - FBM , Lubumbashi , ZR "," Lusambo  Airport - LBO , Lusambo , ZR "," Manono  Airport - MNO , Manono , ZR "," Matadi  Airport - MAT , Matadi , ZR "," Mbandaka  Airport - MDK , Mbandaka , ZR "," Moba Airport - BDV , Moba , ZR "," Mweka  Airport - MEW , Mweka , ZR "," Nioki  Airport - NIO , Nioki , ZR "," Tshikapa Airport - TSH , Tshikapa , ZR "," Canas Airport - CSC , Canas , CR "," Golfito Airport - GLF , Golfito , CR "," Guapiles Airport - GPL , Guapiles , CR "," Los Chiles Airport - LSL , Los chiles , CR "," Nicoya Guanacaste Airport - NCT , Nicoya , CR "," Quepos Airport - XQP , Quepos , CR "," Upala Airport - UPL , Upala , CR "," Abengourou Airport - OGO , Abengourou , CI "," Bondoukou Airport - BDK , Bondoukou , CI "," Bouake Airport - BYK , Bouake , CI "," Bouna Airport - BQO , Bouna , CI "," Boundiali Airport - BXI , Boundiali , CI "," Daloa Airport - DJO , Daloa , CI "," Danane Airport - DNC , Danane , CI "," Divo Airport - DIV , Divo , CI "," Ferkessedougou Airport - FEK , Ferkessedougou , CI "," Gagnoa Airport - GGN , Gagnoa , CI "," Guiglo Airport - GGO , Guiglo , CI "," Katiola Airport - KTC , Katiola , CI "," Korhogo Airport - HGO , Korhogo , CI "," Lakota Airport - LKT , Lakota , CI "," Man Airport - MJC , Man , CI "," Mankono Airport - MOK , Mankono , CI "," M'Bahiakro Airport - XMB , Mbahiakro , CI "," Odienne Airport - KEO , Odienne , CI "," Sassandra Airport - ZSS , Sassandra , CI "," Seguela Airport - SEO , Seguela , CI "," Tabou Airport - TXU , Tabou , CI "," Tingrela Airport - TGX , Tingrela , CI "," Touba Airport - TOZ , Touba , CI "," Yamoussoukro Airport - ASK , Yamoussoukro , CI "," Zuenoula Airport - ZUE , Zuenoula , CI "," Dubrovnik Airport - DBV , Dubrovnik , HR "," Osijek Airport - OSI , Osijek , HR "," Pula Airport - PUY , Pula , HR "," Rijeka Airport - RJK , Rijeka , HR "," Split Sinj Airport - SPU , Split , HR "," Zagreb Pleso Airport - ZAG , Zagreb , HR "," Baracoa Airport - BCA , Baracoa , CU "," Bayamo C.M. de Cespedes Airport - BYM , Bayamo , CU "," Cienfuegos Airport - CFG , Cienfuegos , CU "," Manzanillo Sierra Maestra Airport - MZO , Manzanillo , CU "," Moa Orestes Acosta Airport - MOA , Moa , CU "," Nueva Gerona Rafael Cabrera Airport - GER , Nueva gerona , CU "," Varadero Juan Gualberto Gomez Airport - VRA , Varadero , CU "," Akrotiri Airport - AKT , Akrotiri , CY "," Larnaca Airport - LCA , Larnaca , CY "," Nicosia Airport - NIC , Nicosia , CY "," Brno Turany Airport - BRQ , Brno , CZ "," Karlovy Vary Airport - KLV , Karlovy vary , CZ "," Olomouc Airport - OLO , Olomouc , CZ "," Ostrava Mosnov Airport - OSR , Ostrava , CZ "," Pardubice Airport - PED , Pardubice , CZ "," Prague Ruzyne Airport - PRG , Prague , CZ "," Prerov Airport - PRV , Prerov , CZ "," Tirstrup Airport - AAR , AARHUS , DK "," Billund Airport - BLL , Billund , DK "," Copenhagen Airport - CPH , COPENHAGEN , DK "," Esbjerg Airport - EBJ , Esbjerg , DK "," Karup Airport - KRP , Karup , DK "," Maribo Airport - MRW , Maribo , DK "," Odense Beldringe Airport - ODE , Odense , DK "," Sindal Airport - CNL , Sindal , DK "," Skagen Airport - QJV , Skagen , DK "," Skive Airport - SQW , Skive , DK "," Thisted Airport - TED , Thisted , DK "," Vojens Airport - SKS , Vojens , DK "," Djibouti Ambouli Airport - JIB , Djibouti , DJ "," La Romana Airport - LRM , La romana , DO "," Sabana de Mar Airport - SNX , Sabana de la mar , DO "," Ambato Chachoan Airport - ATF , Ambato , EC "," Cuenca Airport - CUE , Cuenca , EC "," Guayaquil Simon Bolivar Airport - GYE , Guayaquil , EC "," Jipijapa Airport - JIP , Jipijapa , EC "," Latacunga  Airport - LTX , Latacunga , EC "," Macas Airport - XMS , Macas , EC "," Machala Airport - MCH , Machala , EC "," Manta Airport - MEC , Manta , EC "," Portoviejo Airport - PVO , Portoviejo , EC "," Quito Mariscal Sucr Airport - UIO , Quito , EC "," Cairo Int'l Airport - CAI , Cairo , EG "," Hurghada Airport - HRG , Hurghada , EG "," Luxor Airport - LXR , Luxor , EG "," Port Said Airport - PSD , Port said , EG "," Comalapa Intl. Airpot - SAL , San Salvador , SV "," Bata Airport - BSG , Bata , GQ "," Malabo Santa Isabel Airport - SSG , Malabo , GQ "," Asmara Int'l Airport - ASM , Asmara , ER "," Kuressaare Airport - URE , Kuressaare , EE "," Tallinn Ulemiste Airport - TLL , Tallinn , EE "," Tartu Airport - TAY , Tartu , EE "," Asosa Airport - ASO , Asosa , ET "," Awassa Airport - AWA , Awassa , ET "," Chagni Airport - MKD , Chagni , ET "," Dire Dawa Aba Tenna D Yilma Airport - DIR , Dire dawa , ET "," Gondar Airport - GDQ , Gondar , ET "," Jigiga Airport - JIJ , Jijiga , ET "," Jimma Airport - JIM , Jimma , ET "," Jinka Airport - BCO , Jinka , ET "," Kabri Dar Airport - ABJ , Kabri Dar , ET "," Lalibela Airport - LLI , Lalibela , ET "," Mendi Airport - NDM , Mendi , ET "," Mizan Teferi Airport - MTF , Mizan teferi , ET "," Moyale Airport - MYS , Moyale , ET "," Shakiso Airport - SKR , Shakiso , ET "," Labasa Airport - LBS , Labasa , FJ "," Nadi Int'l Airport - NAN , Nadi , FJ "," Savusavu Airport - SVU , Savusavu , FJ "," Suva Nausori Airport - SUV , Suva , FJ "," Vatukoula Airport - VAU , Vatukoula , FJ "," Helsinki Helsinki-Vantaa Airport - HEL , Helsinki , FI "," Joensuu Airport - JOE , Joensuu , FI "," Kajaani Airport - KAJ , Kajaani , FI "," Kauhajoki Airport - KHJ , Kauhajoki , FI "," Kauhava Airport - KAU , Kauhava , FI "," Kemi/Tornio Airport - KEM , Kemi , FI "," Kitee Airport - KTQ , Kitee , FI "," Kokkola/Pietarsaari Kruunupyy Airport - KOK , Kokkola , FI "," Kuopio Airport - KUO , Kuopio , FI "," Kuusamo Airport - KAO , Kuusamo , FI "," Lappeenranta Airport - LPP , Lappeenranta , FI "," Mikkeli Airport - MIK , Mikkeli , FI "," Oulu Airport - OUL , Oulu , FI "," Pori Airport - POR , Pori , FI "," Rovaniemi Airport - RVN , Rovaniemi , FI "," Savonlinna Airport - SVL , Savonlinna , FI "," Tampere-Pirkkala Airport - TMP , Tampere , FI "," Turku Airport - TKU , Turku , FI "," Vaasa Airport - VAA , Vaasa , FI "," Varkaus Airport - VRK , Varkaus , FI "," Ylivieska Airport - YLI , Ylivieska , FI "," Agen La Garenne Airport - AGF , Agen , FR "," Ajaccio Campo Dell Oro Airport - AJA , Ajaccio , FR "," Albi Le Sequestre Airport - LBI , Albi , FR "," Angers Arville Airport - ANE , Angers , FR "," Annecy Annecy-Meythe Airport - NCY , Annecy , FR "," Aubenas Vals-Lanas Airport - OBS , Aubenas , FR "," Aurillac Airport - AUR , Aurillac , FR "," Auxerre Branches Airport - AUF , Auxerre , FR "," Avignon-Caum Airport - AVN , Avignon , FR "," Barcelonnette Airport - BAE , Barcelonnette , FR "," Bastia Poretta Airport - BIA , Bastia , FR "," Paris Beauvais-Tille Airport - BVA , Beauvais , FR "," Belfort Fontaine Airport - BOR , Belfort , FR "," Bergerac Roumanieres Airport - EGC , Bergerac , FR "," Biarritz Parme Airport - BIQ , Biarritz , FR "," Bordeaux Airport - BOD , Bordeaux , FR "," Bourges Airport - BOU , Bourges , FR "," Brive-la-Gaillarde Laroche Airport - BVE , Brive-la-gaillarde , FR "," Caen Carpiquet Airport - CFR , Caen , FR "," Cahors Laberandie Airport - ZAO , Cahors , FR "," Calais Airport - CQF , Calais , FR "," Calvi Ste. Catherine Airport - CLY , Calvi , FR "," Cannes Mandelieu Airport - CEQ , Cannes , FR "," Carcassonne Salvaza Airport - CCF , Carcassonne , FR "," Castres Mazamet Airport - DCM , Castres , FR "," Cherbourg Maupertus Airport - CER , Cherbourg , FR "," Cholet Le Pontreau Airport - CET , Cholet , FR "," Clermont-Ferrand Aulnat Airport - CFE , Clermont-ferrand , FR "," Cognac Parvaud Airport - CNG , Cognac , FR "," Colmar-Houssen Airport - CMR , Colmar , FR "," Creil Airport - CSF , Creil , FR "," Dijon Airport - DIJ , Dijon , FR "," Dinard Pleurtuit Airport - DNR , Dinard , FR "," Dole Tavaux Airport - DLE , Dole , FR "," Grenoble St. Geoirs Airport - GNB , Grenoble , FR "," Hazebrouck Merville/Calonne Airport - HZB , Hazebrouck , FR "," La Rochelle Laleu Airport - LRH , La rochelle , FR "," Landivisiau Airport - LDV , Landivisiau , FR "," Lannion Servel Airport - LAI , Lannion , FR "," Laval Entrammes Airport - LVA , Laval , FR "," Le Castellet Airport - CTT , Le castellet , FR "," Le Havre Octeville Airport - LEH , Le havre , FR "," Le Mans Arnage Airport - LME , Le mans , FR "," Lille Lesquin Airport - LIL , Lille , FR "," Limoges Bellegarde Airport - LIG , Limoges , FR "," Lorient Lann Bihoue Airport - LRT , Lorient , FR "," Lyon Satolas Airport - LYS , LYON , FR "," Marseille Airport - MRS , Marseille , FR "," Mende Brenoux Airport - MEN , Mende , FR "," Metz Frescaty Airport - MZM , Metz , FR "," Montpellier Mediterranee Airport - MPL , Montpellier , FR "," Morlaix Airport - MXN , Morlaix , FR "," Euroairport Mulhouse Airport - MLH , Mulhouse , FR "," Nancy Essey Airport - ENC , Nancy , FR "," Nantes Atlantique Airport - NTE , Nantes , FR "," Nevers Airport - NVS , Nevers , FR "," Nice Cote d'Azur Airport - NCE , Nice , FR "," Niort Airport - NIT , Niort , FR "," All Paris Airports - PAR , Paris , FR "," Charles de Gaulle Airport - CDG , Paris , FR "," Orly Airport - ORY , Paris , FR "," Pau Uzein Airport - PUF , Pau , FR "," Perpignan Llabanere Airport - PGF , Perpignan , FR "," Poitiers Biard Airport - PIS , Poitiers , FR "," Pontoise Cormeille en Vexin Airport - POX , Pontoise , FR "," Propriano Airport - PRP , Propriano , FR "," Quimper Pluguffan Airport - UIP , Quimper , FR "," Reims Airport - RHE , Reims , FR "," Rennes St. Jacques Airport - RNS , Rennes , FR "," Roanne Renaison Airport - RNE , Roanne , FR "," Rochefort St. Agnant Airport - RCO , Rochefort , FR "," Rodez Marcillac Airport - RDZ , Rodez , FR "," Rouen Boos Airport - URO , Rouen , FR "," Royan Medis Airport - RYN , Royan , FR "," Strasbourg Entzheim Airport - SXB , Strasbourg , FR "," Tignes Airport - TGF , Tignes , FR "," Toulouse Montaudran Airport - XYT , Toulouse , FR "," Toulouse Blagnac Airport - TLS , Toulouse Blagnac , FR "," Tours St. Symphorien Airport - TUF , Tours , FR "," Toussus-le-Noble Airport - TNF , Toussus-le-noble , FR "," Valence Chabeuil Airport - VAF , Valence , FR "," Vannes Meucon Airport - VNE , Vannes , FR "," Vichy Charmeil Airport - VHY , Vichy , FR "," Vittel Airport - VTL , Vittel , FR "," Maripasoula Airport - MPY , Maripasoula , GF "," Faaa Airport - PPT , Papeete , PF "," Bitam Airport - BMM , Bitam , GA "," Fougamou Airport - FOU , Fougamou , GA "," Koulamoutou Airport - KOU , Koulamoutou , GA "," Libreville Airport - LBV , Libreville , GA "," Mbigou Airport - MBC , Mbigou , GA "," Minvoul Airport - MVX , Minvoul , GA "," Mitzic Airport - MZC , Mitzic , GA "," Moanda Airport - MFF , Moanda , GA "," Mouila Airport - MJL , Mouila , GA "," Nkan Airport - NKA , Nkan , GA "," Oyem Airport - OYE , Oyem , GA "," Tchibanga Airport - TCH , Tchibanga , GA "," Banjul Yundum Int'l Airport - BJL , Banjul , GM "," Batumi Airport - BUS , Batumi , GE "," Kutaisi Airport - KUT , Kutaisi , GE "," Sukhumi Babusheri Airport - SUI , Sukhumi , GE "," Tbilisi Novo Alexeyevka Airport - TBS , Tbilisi , GE "," Altenburg Nobitz Airport - AOC , Altenburg , DE "," Augsburg Airport - AGB , Augsburg , DE "," Baltrum Airport - BMR , Baltrum , DE "," Bayreuth Bindlacher-Berg Airport - BYU , Bayreuth , DE "," Berlin Schonefeld Airport - SXF , Berlin , DE "," Berlin Tegel Airport - TXL , Berlin , DE "," Berlin Tempelhof Airport - THF , Berlin , DE "," Bielefeld Airport - BFE , Bielefeld , DE "," Bitburg Airport - BBJ , Bitburg , DE "," Bremen Airport - BRE , Bremen , DE "," Bremerhaven Airport - BRV , Bremerhaven , DE "," Burg Feuerstein Airport - URD , Burg , DE "," Cochstedt Airport - CSO , Cochstedt , DE "," Cologne Airport - BNJ , Cologne , DE "," Cologne/Bonn Airport - CGN , Cologne/Bonn , DE "," Cottbus Airport - CBU , Cottbus , DE "," Dortmund Airport - DTM , Dortmund , DE "," Dresden Dresden Airport - DRS , Dresden , DE "," Duisburg Airport - DUI , Duisburg , DE "," Dusseldorf Airport - DUS , Dusseldorf , DE "," Egelsbach  Airport - QEF , Egelsbach , DE "," Eisenach Airport - EIB , Eisenach , DE "," Emden Airport - EME , Emden , DE "," Erfurt Airport - ERF , Erfurt , DE "," Essen Airport - ESS , Essen , DE "," Flensburg Schaferhaus Airport - FLF , Flensburg , DE "," Frankfurt Int'l Airport - FRA , Frankfurt , DE "," Friedrichshafen Airport - FDH , Friedrichshafen , DE "," Geilenkirchen Airport - GKE , Geilenkirchen , DE "," Giebelstadt Airport - GHF , Giebelstadt , DE "," Hamburg Fuhlsbuettel Airport - HAM , Hamburg , DE "," Hanover Airport - HAJ , Hanover , DE "," Heide/Buesum Airport - HEI , Heide , DE "," Heidelberg Airport - HDB , Heidelberg , DE "," Helgoland Airport - HGL , Helgoland , DE "," Heringsdorf Airport - HDF , Heringsdorf , DE "," Hof Airport - HOQ , Hof , DE "," Juist Airport - JUI , Juist , DE "," Kassel-Calden Airport - KSF , Kassel , DE "," Kiel Holtenau Airport - KEL , Kiel , DE "," Kitzingen Airport - KZG , Kitzingen , DE "," Lahr Airport - LHA , Lahr , DE "," Langeoog Airport - LGO , Langeoog , DE "," Leipzig Airport - LEJ , Leipzig , DE "," Lemwerder Airport - XLW , Lemwerder , DE "," Mannheim Airport - MHG , Mannheim , DE "," Muenster Airport - FMO , Muenster , DE "," Munich Franz Josef Strauss Airport - MUC , Munich , DE "," Neubrandenburg Airport - FNB , Neubrandenburg , DE "," Norddeich Airport - NOE , Norddeich , DE "," Norden Airport - NOD , Norden , DE "," Norderney Airport - NRD , Norderney , DE "," Nordholz-Spieka Cuxhaven Airport - NDZ , Nordholz , DE "," Nuremberg Airport - NUE , Nuremberg , DE "," Oberpfaffenhofen Airport - OBF , Oberpfaffenhofen , DE "," Paderborn Airport - PAD , Paderborn , DE "," Rechlin Airport - REB , Rechlin , DE "," Riesa Airport - IES , Riesa , DE "," Ensheim Airport - SCN , Saarbrucken , DE "," Schleswig-Jagel Airport - WBG , Schleswig , DE "," Schwerin Parchim Airport - SZW , Schwerin , DE "," Sembach Airport - SEX , Sembach , DE "," Siegen Siegerland Airport - SGE , Siegen , DE "," Spangdahlem Airport - SPM , Spangdahlem , DE "," Straubing Wallmuhle Airport - RBM , Straubing , DE "," Strausberg Airport - QPK , Strausberg , DE "," Stuttgart Echterdingen Airport - STR , Stuttgart , DE "," Trier Airport - ZQF , Trier , DE "," Wangerooge Flugplatz Airport - AGE , Wangerooge , DE "," Westerland Airport - GWT , Westerland , DE "," Wilhelmshaven Airport - WVN , Wilhelmshaven , DE "," Accra Kotoka Airport - ACC , Accra , GH "," Kumasi Airport - KMS , Kumasi , GH "," Sunyani Airport - NYI , Sunyani , GH "," Tamale Airport - TML , Tamale , GH "," Alexandroupolis Demokritos Airport - AXD , Alexandroupolis , GR "," Eleftherios Venizelos Airport - ATH , Athens , GR "," Chania Souda Airport - CHQ , Chania , GR "," Heraklion N. Kazantzakis Airport - HER , Heraklion , GR "," Ioannina Airport - IOA , Ioannina , GR "," Kavala Megas Alexandros Airport - KVA , Kavala , GR "," Kerkyra I. Kapodistrias Airport - CFU , Kerkyra , GR "," Kos Airport - KGS , Kos , GR "," Mytilene Airport - MJT , Mytilene , GR "," Rhodes Diagoras Airport - RHO , Rhodes , GR "," Thessaloniki Makedonia Airport - SKG , Thessaloniki , GR "," Thira Airport - JTR , Thira , GR "," Aappilattoq Airport - QUV , Aappilattoq , GL "," Arsuk Airport - JRK , Arsuk , GL "," Ilimanaq Airport - XIQ , Ilimanaq , GL "," Kangaamiut Airport - QKT , Kangaamiut , GL "," Kangerlussuaq Airport - SFJ , Kangerlussuaq , GL "," Kulusuk Airport - KUS , Kulusuk , GL "," Nanortalik Airport - JNN , Nanortalik , GL "," Narsaq Kujalleq  Airport - QFN , Narsaq kujalleq , GL "," Narsarsuaq Airport - UAK , Narsarsuaq , GL "," Nuuk Airport - GOH , Nuuk , GL "," Pituffik Airport - THU , Pituffik , GL "," Qaanaaq Airport - NAQ , Qaanaaq , GL "," Qassimiut Airport - QJH , Qassimiut , GL "," Qeqertarsuatsiaat  Airport - QEY , Qeqertarsuatsiaat , GL "," Qullissat Airport - QUE , Qullissat , GL "," Saarloq Airport - QOQ , Saarloq , GL "," Tasiilaq Airport - AGM , Tasiilaq , GL "," Uummannaq Airport - UMD , Uummannaq , GL "," Coatepeque Airport - CTF , Coatepeque , GT "," Puerto Barrios Airport - PBR , Puerto barrios , GT "," Conakry Airport - CKY , Conakry , GN "," Kankan Airport - KNN , Kankan , GN "," Bissau Osvaldo Vieira Airport - OXB , Bissau , GW "," Bubaque Airport - BQE , Bubaque , GW "," Bartica Airport - GFO , Bartica , GY "," Lethem Airport - LTM , Lethem , GY "," Mabaruma Airport - USI , Mabaruma , GY "," Skeldon Airport - SKM , Skeldon , GY "," Brus Laguna Airport - BHG , Brus laguna , HN "," Catacamas Airport - CAA , Catacamas , HN "," Coyoles Airport - CYL , Coyoles , HN "," Erandique Airport - EDQ , Erandique , HN "," Gualaco Airport - GUO , Gualaco , HN "," Guanaja Airport - GJA , Guanaja , HN "," Juticalpa Airport - JUT , Juticalpa , HN "," La Ceiba Goloson Int'l Airport - LCE , La ceiba , HN "," Marcala Airport - MRJ , Marcala , HN "," Olanchito Airport - OAN , Olanchito , HN "," Puerto Lempira Airport - PEU , Puerto lempira , HN "," San Pedro Sula Ramon Villeda Morale Airport - SAP , San pedro sula , HN "," Sulaco Airport - SCD , Sulaco , HN "," Tegucigalpa Toncontin Airport - TGU , Tegucigalpa , HN "," Tela Airport - TEA , Tela , HN "," Tocoa Airport - TCF , Tocoa , HN "," Utila Airport - UII , Utila , HN "," Budapest Ferihegy Airport - BUD , Budapest , HU "," Debrecen Airport - DEB , Debrecen , HU "," Miskolc Airport - MCQ , Miskolc , HU "," Akureyri Airport - AEY , Akureyri , IS "," Egilsstadir Airport - EGS , Egilsstadir , IS "," Flateyri Airport - FLI , Flateyri , IS "," Hvammstangi Airport - HVM , Hvammstangi , IS "," Sudureyri Airport - SUY , Sudureyri , IS "," Agartala Singerbhil Airport - IXA , Agartala , IN "," Agra Kheria Airport - AGR , Agra , IN "," Ahmedabad Airport - AMD , Ahmedabad , IN "," Aizawl Airport - AJL , Aizawl , IN "," Akola Airport - AKD , Akola , IN "," Allahabad Bamrauli Airport - IXD , Allahabad , IN "," Along Airport - IXV , Along , IN "," Amritsar Raja Sansi Airport - ATQ , Amritsar , IN "," Aurangabad Chikkalthana Airport - IXU , Aurangabad , IN "," Balurghat Airport - RGH , Balurghat , IN "," Bangalore Hindustan Airport - BLR , Bangalore , IN "," Bareli Airport - BEK , Bareli , IN "," Belgaum Sambre Airport - IXG , Belgaum , IN "," Bellary Airport - BEP , Bellary , IN "," Bhavnagar Airport - BHU , Bhavnagar , IN "," Bhopal Airport - BHO , Bhopal , IN "," Bhubaneswar Airport - BBI , Bhubaneswar , IN "," Bhuj Rudra Mata Airport - BHJ , Bhuj , IN "," Bikaner Airport - BKB , Bikaner , IN "," Bilaspur Airport - PAB , Bilaspur , IN "," Bombay Mumbai Airport - BOM , Bombay , IN "," Calcutta Netaji Subhas Chandra Airport - CCU , Calcutta , IN "," Calicut Airport - CCJ , Calicut , IN "," Chandigarh Airport - IXC , Chandigarh , IN "," Cochin Airport - COK , Cochin , IN "," Cuddapah Airport - CDP , Cuddapah , IN "," Daman Airport - NMB , Daman , IN "," Dehra Dun Airport - DED , Dehra dun , IN "," Delhi Indira Gandhi Int'l Airport - DEL , Delhi , IN "," Dhanbad Airport - DBD , Dhanbad , IN "," Dibrugarh Chabua Airport - DIB , Dibrugarh , IN "," Dimapur Airport - DMU , Dimapur , IN "," Diu Airport - DIU , Diu , IN "," Gauhati Borjhar Airport - GAU , Gauhati , IN "," Gaya Airport - GAY , Gaya , IN "," Goa Dabolim Airport - GOI , Goa , IN "," Gorakhpur Airport - GOP , Gorakhpur , IN "," Guna Airport - GUX , Guna , IN "," Gwalior Airport - GWL , Gwalior , IN "," Hubli Airport - HBX , Hubli , IN "," Hyderabad Begumpet Airport - HYD , Hyderabad , IN "," Imphal Municipal Airport - IMF , Imphal , IN "," Indore Airport - IDR , Indore , IN "," Jabalpur Airport - JLR , Jabalpur , IN "," Jaipur Sanganeer Airport - JAI , Jaipur , IN "," Jaisalmer Airport - JSA , Jaisalmer , IN "," Jammu Satwari Airport - IXJ , Jammu , IN "," Jamnagar Govardhanpur Airport - JGA , Jamnagar , IN "," Jamshedpur Sonari Airport - IXW , Jamshedpur , IN "," Jodhpur Airport - JDH , Jodhpur , IN "," Jorhat Rowriah Airport - JRH , Jorhat , IN "," Kamalpur Airport - IXQ , Kamalpur , IN "," Kandla Airport - IXY , Kandla , IN "," Kanpur Airport - KNU , Kanpur , IN "," Keshod Airport - IXK , Keshod , IN "," Khajuraho Airport - HJR , Khajuraho , IN "," Khowai Airport - IXN , Khowai , IN "," Kolhapur Airport - KLH , Kolhapur , IN "," Kota Airport - KTU , Kota , IN "," Leh Airport - IXL , Leh , IN "," Lucknow Amausi Airport - LKO , Lucknow , IN "," Ludhiana Airport - LUH , Ludhiana , IN "," Madurai Airport - IXM , Madurai , IN "," Muzaffarnagar Airport - MZA , Muzaffarnagar , IN "," Muzaffarpur Airport - MZU , Muzaffarpur , IN "," Nagpur Sonegaon Airport - NAG , Nagpur , IN "," Nanded Airport - NDC , Nanded , IN "," Neyveli Airport - NVY , Neyveli , IN "," Osmanabad Airport - OMN , Osmanabad , IN "," Pasighat Airport - IXT , Pasighat , IN "," Pathankot Airport - IXP , Pathankot , IN "," Patna Airport - PAT , Patna , IN "," Poona Lohegaon Airport - PNQ , Poona , IN "," Porbandar Airport - PBD , Porbandar , IN "," Port Blair Airport - IXZ , Port blair , IN "," Raipur Airport - RPR , Raipur , IN "," Rajkot Civil Airport - RAJ , Rajkot , IN "," Ramagundam Airport - RMD , Ramagundam , IN "," Ranchi Airport - IXR , Ranchi , IN "," Ratnagiri Airport - RTC , Ratnagiri , IN "," Rewa Airport - REW , Rewa , IN "," Satna Airport - TNI , Satna , IN "," Shillong Airport - SHL , Shillong , IN "," Sholapur Airport - SSE , Sholapur , IN "," Silchar Kumbhirgram Airport - IXS , Silchar , IN "," Srinagar Airport - SXR , Srinagar , IN "," Surat Airport - STV , Surat , IN "," Tezpur Salonibari Airport - TEZ , Tezpur , IN "," Tezu Airport - TEI , Tezu , IN "," Thanjavur Airport - TJV , Thanjavur , IN "," Tirupati Airport - TIR , Tirupati , IN "," Trivandrum Int'l Airport - TRV , Trivandrum , IN "," Udaipur Dabok Airport - UDR , Udaipur , IN "," Vadodara Airport - BDQ , Vadodara , IN "," Varanasi Airport - VNS , Varanasi , IN "," Vijayawada Airport - VGA , Vijayawada , IN "," Amahai Airport - AHI , Amahai , ID "," Ambon Pattimura Airport - AMQ , Ambon , ID "," Balikpapan Sepingan Airport - BPN , Balikpapan , ID "," Bandar Lampung Branti Airport - TKG , Bandar lampung , ID "," Bandung Husein Sastranegara Airport - BDO , Bandung , ID "," Banjarmasin Sjamsudin Noor Airport - BDJ , Banjarmasin , ID "," Batam Hang Nadim Airport - BTH , Batam , ID "," Biak Mokmer Airport - BIK , Biak , ID "," Bima Airport - BMU , Bima , ID "," Bontang Airport - BXT , Bontang , ID "," Cepu Airport - CPF , Cepu , ID "," Cilacap Tunggul Wulung Airport - CXP , Cilacap , ID "," Cirebon Penggung Airport - CBN , Cirebon , ID "," Dumai Pinang Kampai Airport - DUM , Dumai , ID "," Ende Airport - ENE , Ende , ID "," Gunungsitoli Airport - GNS , Gunung stoli , ID "," Jayapura Sentani Airport - DJJ , Jaya pura , ID "," Kendari Wolter Monginsidi Airport - KDI , Kendari , ID "," Kupang Eltari Airport - KOE , Kupang , ID "," Luwuk Airport - LUW , Luwuk , ID "," Malang Airport - MLG , Malang , ID "," Manado Samratulangi Airport - MDC , Manado , ID "," Manokwari Rendani Airport - MKW , Manokwari , ID "," Mataram Selaparang Airport - AMI , Mataram , ID "," Maumere Waioti Airport - MOF , Maumere , ID "," Medan Polania Airport - MES , Medan , ID "," Nabire Airport - NBX , Nabire , ID "," Padang Tabing Airport - PDG , Padang , ID "," Palembang Mahmud Badaruddin Ii Airport - PLM , Palembang , ID "," Palu Mutiara Airport - PLW , Palu , ID "," Pangkalpinang Airport - PGK , Pangkal pinang , ID "," Pangkalanbuun Airport - PKN , Pangkalanbuun , ID "," Pontianak Supadio Airport - PNK , Pontianak , ID "," Poso Airport - PSJ , Poso , ID "," Purwokerto Airport - PWL , Purwokerto , ID "," Ruteng Airport - RTG , Ruteng , ID "," Samarinda Airport - SRI , Samarinda , ID "," Sampit Airport - SMQ , Sampit , ID "," Semarang Achmad Uani Airport - SRG , Semarang , ID "," Sorong Jefman Airport - SOQ , Sorong , ID "," Sumbawa Brang Bidji Airport - SWQ , Sumbawa , ID "," Sumenep Trunojoyo Airport - SUP , Sumenep , ID "," Surabaya Juanda Airport - SUB , Surabaya , ID "," Tanjung Balai Airport - TJB , Tanjung balai , ID "," Tanjung Pandan Bulutumbang Airport - TJQ , Tanjung pandan , ID "," Tanjung Pinang Kidjang Airport - TNJ , Tanjung pinang , ID "," Tarakan Airport - TRK , Tarakan , ID "," Tasikmalaya Airport - TSY , Tasikmalaya , ID "," Ternate Babullah Airport - TTE , Ternate , ID "," Waingapu Airport - WGP , Waingapu , ID "," Birjand Airport - XBJ , Birjand , IR "," Khorramabad Airport - KHD , Khorramabad , IR "," Rafsanjan Airport - RJN , Rafsanjan , IR "," Ramsar Airport - RZR , Ramsar , IR "," Rasht Airport - RAS , Rasht , IR "," Sanandaj Airport - SDG , Sanandaj , IR "," Sarakhs Airport - CKT , Sarakhs , IR "," Shiraz Airport - SYZ , Shiraz , IR "," Sirjan Airport - SYJ , Sirjan , IR "," Tabas Airport - TCX , Tabas , IR "," Tabriz Airport - TBZ , Tabriz , IR "," Tehran Mehrabad Airport - THR , Tehran , IR "," Yazd Airport - AZD , Yazd , IR "," Zahedan Airport - ZAH , Zahedan , IR "," Kirkuk Airport - KIK , Kirkuk , IQ "," Bantry Airport - BYT , Bantry , IE "," Castlebar Airport - CLB , Castlebar , IE "," Cork International Airport - ORK , CORK , IE "," Dublin Airport - DUB , Dublin , IE "," Letterkenny Airport - LTR , Letterkenny , IE "," Shannon Airport - SNN , SHANNON , IE "," Ebadon Airport - EBN , Ebadon , MH "," Jeh Airport - JEJ , Jeh , MH "," Tabal Airport - TBV , Tabal , MH "," Tinak Island Airport - TIC , Tinak , MH "," Woja Airport - WJA , Woja , MH "," Wotho Island Airport - WTO , Wotho , MH "," Wotje Island Airport - WTE , Wotje , MH "," Elat Airport - ETH , Elat , IL "," Jerusalem Airport - JRS , Jerusalem , IL "," Tel Aviv Yafo Ben Gurion Int'l Airport - TLV , Tel Aviv , IL "," Albenga Airport - ALL , Albenga , IT "," Alghero Fertilia Airport - AHO , Alghero , IT "," Ancona Falconara Airport - AOI , Ancona , IT "," Aviano Airport - AVB , Aviano , IT "," Bari Palese Airport - BRI , Bari , IT "," Belluno Airport - BLX , Belluno , IT "," Bologna Guglielmo Marconi Airport - BLQ , Bologna , IT "," Bolzano Airport - BZO , Bolzano , IT "," Brindisi Papola Casale Airport - BDS , Brindisi , IT "," Cagliari Elmas Airport - CAG , Cagliari , IT "," Capri Airport - PRJ , Capri , IT "," Catania Fontanarossa Airport - CTA , Catania , IT "," Comiso Airport - CIY , Comiso , IT "," Crotone Airport - CRV , Crotone , IT "," Cuneo Levaldigi Airport - CUF , Cuneo , IT "," Decimomannu Rafsu Decimomannu Airport - DCI , Decimomannu , IT "," Florence Amerigo Vespucci - FLR , Florence , IT "," Foggia Gino Lisa Airport - FOG , Foggia , IT "," Genoa Cristoforo Colombo Airport - GOA , Genoa , IT "," Grosseto Baccarini Airport - GRS , Grosseto , IT "," Ischia Airport - ISH , Ischia , IT "," Lecce Galatina Airport - LCC , Lecce , IT "," Lucca Airport - LCV , Lucca , IT "," Milan Linate Airport - LIN , Milan , IT "," Milan Malpensa Airport - MXP , Milan , IT "," Milan Orio al Serio Airport - BGY , Milan , IT "," Naples Airport - NAP , Naples , IT "," Palermo Punta Raisi Airport - PMO , Palermo , IT "," Pantelleria Airport - PNL , Pantelleria , IT "," Milan Parma Airport - PMF , Parma , IT "," Perugia Sant Egidio Airport - PEG , Perugia , IT "," Pescara Liberi Airport - PSR , Pescara , IT "," Pisa Gal Galilei Airport - PSA , Pisa , IT "," Rimini Miramare Airport - RMI , Rimini , IT "," Ciampino Airport - CIA , Rome , IT "," Fiumicino Airport - FCO , Rome , IT "," Siena Airport - SAY , Siena , IT "," Taranto M. A. Grottag Airport - TAR , Taranto , IT "," Trapani Birgi Airport - TPS , Trapani , IT "," Venice Treviso Airport - TSF , Treviso , IT "," Trieste Dei Legionari Airport - TRS , Trieste , IT "," Turin Citta di Torino Airport - TRN , Turin , IT "," Udine Airfield Airport - UDN , Udine , IT "," Marco Polo Airport - VCE , Venice , IT "," Vicenza Airport - VIC , Vicenza , IT "," Vieste Airport - VIF , Vieste , IT "," Montego Bay Sangster Int'l Airport - MBJ , Montego bay , JM "," Negril Airport - NEG , Negril , JM "," Ocho Rios Boscobel Airport - OCJ , Ocho rios , JM "," Port Antonio Ken Jones Airport - POT , Port antonio , JM "," Akita Airport - AXT , Akita , JP "," Aomori Airport - AOJ , Aomori , JP "," Asahikawa Airport - AKJ , Asahikawa , JP "," Atsugi  Airport - NJA , Atsugi , JP "," Beppu Airport - BPU , Beppu , JP "," Fukue Airport - FUJ , Fukue , JP "," Fukuoka Airport - FUK , Fukuoka , JP "," Fukuyama  Airport - QFY , Fukuyama , JP "," Hachinohe Airport - HHE , Hachinohe , JP "," Hakodate Airport - HKD , Hakodate , JP "," Hiroshima Airport - HIJ , Hiroshima , JP "," Ishigaki Airport - ISG , Ishigaki , JP "," Izumo Airport - IZO , Izumo , JP "," Kita Kyushu Kokura Airport - KKJ , Kitakyushu , JP "," Kobe Airport - UKB , Kobe , JP "," Komatsu Airport - KMQ , Komatsu , JP "," Kushiro Airport - KUH , Kushiro , JP "," Kyoto Airport - UKY , Kyoto , JP "," Matsumoto Airport - MMJ , Matsumoto , JP "," Matsuyama Airport - MYJ , Matsuyama , JP "," Misawa Airport - MSJ , Misawa , JP "," Miyazaki Airport - KMI , Miyazaki , JP "," Morioka Hanamaki Airport - HNA , Morioka , JP "," Nagasaki Airport - NGS , Nagasaki , JP "," Nagoya Airport - NGO , Nagoya , JP "," Nakashibetsu Airport - SHB , Nakashibetsu , JP "," Niihama Airport - IHA , Niihama , JP "," Nishinoomote Airport - IIN , Nishinoomote , JP "," Obihiro Airport - OBO , Obihiro , JP "," Oita Airport - OIT , Oita , JP "," Naha Airport - OKA , Okinawa , JP "," Omura Airport - OMJ , Omura , JP "," Osaka Itami Airport - ITM , Osaka , JP "," Osaka Kansai International Airport - KIX , Osaka , JP "," Chitose Airport - CTS , Sapporo , JP "," Okadama Airport - OKD , Sapporo , JP "," Sapporo Airport - SPK , Sapporo , JP "," Sendai Airport - SDJ , Sendai , JP "," Takamatsu Airport - TAK , Takamatsu , JP "," Tokushima Airport - TKS , Tokushima , JP "," Haneda Airport - HND , Tokyo , JP "," Narita International Airport - NRT , Tokyo , JP "," TOKYO - TYO , Tokyo , JP "," Toyama Airport - TOY , Toyama , JP "," Toyooka Tajima Airport - TJH , Toyooka , JP "," Tsushima Airport - TSJ , Tsushima , JP "," Ube Airport - UBJ , Ube , JP "," Wakkanai Hokkaido Airport - WKJ , Wakkanai , JP "," Junmachi Airport - GAJ , Yamagata , JP "," Yokohama Airport - YOK , Yokohama , JP "," Yonago Miho Airport - YGJ , Yonago , JP "," Queen Alia International Airport - AMM , Amman , JO "," Aktau Airport - SCO , Aktau , KZ "," Almaty Airport - ALA , Almaty , KZ "," Atbasar Airport - ATX , Atbasar , KZ "," Semipalatinsk Airport - PLX , Semey , KZ "," Eldoret Airport - EDL , Eldoret , KE "," Garissa Airport - GAS , Garissa , KE "," Kericho Airport - KEY , Kericho , KE "," Kisumu Airport - KIS , Kisumu , KE "," Kitale Airport - KTL , Kitale , KE "," Lamu Airport - LAU , Lamu , KE "," Lodwar Airport - LOK , Lodwar , KE "," Malindi Airport - MYD , Malindi , KE "," Mandera Airport - NDE , Mandera , KE "," Marsabit Airport - RBT , Marsabit , KE "," Mombasa Moi Int'l Airport - MBA , Mombasa Moi , KE "," Nairobi Jomo Kenyatta Int'l Airport - NBO , NAIROBI , KE "," Nakuru Airport - NUU , Nakuru , KE "," Nanyuki Airport - NYK , Nanyuki , KE "," Nyeri Airport - NYE , Nyeri , KE "," Wajir Airport - WJR , Wajir , KE "," Butaritari Airport - BBG , Butaritari , KI "," CHRISTMAS ISLAND - CXI , CHRISTMAS ISLAND , KI "," Pyongyang Sunan Airport - FNJ , Pyongyang , KP "," Cheju Airport - CJU , Cheju , KR "," Chinhae Airport - CHF , Chinhae , KR "," Chinju Sacheon Airport - HIN , Chinju , KR "," Chonju Airport - CHN , Chonju , KR "," Kangnung Airport - KAG , Kangnung , KR "," Kunsan Airport - KUV , Kunsan , KR "," Kwangju Airport - KWJ , Kwangju , KR "," Mokpo Airport - MPK , Mokpo , KR "," Pohang Airport - KPO , Pohang , KR "," Pusan Kimhae Airport - PUS , Pusan , KR "," Samchok Airport - SUK , Samchok , KR "," Depart Seoul - GMP , SEOUL , KR "," SEOUL Airport - ICN , SEOUL , KR "," Sokcho Solak Airport - SHO , Sokcho , KR "," Sunchon Yosu Airport - SYS , Sunchon , KR "," Su Won City Airport - SWU , Suwon , KR "," Taegu Airport - TAE , Taegu , KR "," Ulsan Airport - USN , Ulsan , KR "," WonJu Airport - WJU , Wonju , KR "," Yechon Airport - YEC , Yechon , KR "," Yosu Airport - RSU , Yosu , KR "," Vientiane Wattay Airport - VTE , Vientiane , LA "," Daugavpils Airport - DGP , Daugavpils , LV "," Riga Airport - RIX , Riga , LV "," Tripoli Int'l Airport - TIP , Tripoli , LY "," Tripoli Kleyate Airport - KYE , Tripoli , LB "," Kaunas Airport - KUN , Kaunas , LT "," Klaipeda Airport - KLJ , Klaipeda , LT "," Palanga Airport - PLQ , Palanga , LT "," Panevezys Airport - PNV , Panevezys , LT "," Siauliai Airport - SQQ , Siauliai , LT "," Vilnius Airport - VNO , Vilnius , LT "," Luxembourg Findel Airport - LUX , Luxembourg , LU "," Ohrid Airport - OHD , Ohrid , MK "," Skopje Airport - SKP , Skopje , MK "," Ambanja Airport - IVA , Ambanja , MG "," Ambatondrazaka Airport - WAM , Ambatondrazaka , MG "," Ambilobe Airport - AMB , Ambilobe , MG "," Ampanihy Airport - AMP , Ampanihy , MG "," Andapa Airport - ZWA , Andapa , MG "," Ankazoabo Airport - WAK , Ankazoabo , MG "," Antalaha Antsirabato Airport - ANM , Antalaha , MG "," Antsohihy Airport - WAI , Antsohihy , MG "," Bealanana Airport - WBE , Bealanana , MG "," Beroroha Airport - WBO , Beroroha , MG "," Betioky Airport - BKU , Betioky , MG "," Farafangana Airport - RVA , Farafangana , MG "," Ihosy Airport - IHO , Ihosy , MG "," Mahanoro Airport - VVB , Mahanoro , MG "," Manakara Airport - WVK , Manakara , MG "," Mananara Airport - WMR , Mananara , MG "," Mananjary Airport - MNJ , Mananjary , MG "," Maroantsetra Airport - WMN , Maroantsetra , MG "," Miandrivazo Airport - ZVA , Miandrivazo , MG "," Morondava Airport - MOQ , Morondava , MG "," Sambava Airport - SVB , Sambava , MG "," Tsaratanana Airport - TTS , Tsaratanana , MG "," Tsiroanomandidy Airport - WTS , Tsiroanomandidy , MG "," Vangaindrano Airport - VND , Vangaindrano , MG "," Blantyre Chileka Airport - BLZ , Blantyre , MW "," Lilongwe Int'l Airport - LLW , Lilongwe , MW "," Monkey Bay Airport - MYZ , Monkey bay , MW "," Mzuzu Airport - ZZU , Mzuzu , MW "," Alor Setar Airport - AOR , Alor setar , MY "," Bintulu Airport - BTU , Bintulu , MY "," Butterworth Airport - BWH , Butterworth , MY "," Ipoh Airport - IPH , Ipoh , MY "," Johor Bahru Sultan Ismail Int'l Airport - JHB , Johor bahru , MY "," Kapit Airport - KPI , Kapit , MY "," Keningau Airport - KGU , Keningau , MY "," Kerteh Airport - KTE , Kerteh , MY "," Kota Kinabalu Airport - BKI , Kota kinabalu , MY "," Kuala Lumpur International Airport - KUL , Kuala lumpur , MY "," Kuala Terengganu Sultan Mahmood Airport - TGG , Kuala terengganu , MY "," Kuantan Airport - KUA , Kuantan , MY "," Kuching Airport - KCH , Kuching , MY "," Kudat Airport - KUD , Kudat , MY "," Labuan Airport - LBU , Labuan , MY "," Lahad Datu Airport - LDU , Lahad datu , MY "," Limbang Airport - LMN , Limbang , MY "," Mersing Airport - MEP , Mersing , MY "," Miri Airport - MYY , Miri , MY "," Ranau Airport - RNU , Ranau , MY "," Sandakan Airport - SDK , Sandakan , MY "," Semporna Airport - SMM , Semporna , MY "," Sibu Airport - SBW , Sibu , MY "," Taiping Airport - TPG , Taiping , MY "," Tawau Airport - TWU , Tawau , MY "," Hanimaadhoo Airport - HAQ , Hanimaadhoo , MV "," Male Int'l Airport - MLE , Male , MV "," Nouadhibou Airport - NDB , Nouadhibou , MR "," Nouakchott Airport - NKC , Nouakchott , MR "," Dzaoudzi Airport - DZA , Dzaoudzi , YT "," Acapulco Alvarez Int'l Airport - ACA , Acapulco , MX "," Aguascalientes Airport - AGU , Aguascalientes , MX "," Cananea Airport - CNA , Cananea , MX "," Cancun International Airport  - CUN , Cancun , MX "," Chetumal Airport - CTM , Chetumal , MX "," Comitan Airport - CJT , Comitan , MX "," Cozumel Airport - CZM , Cozumel , MX "," Cuernavaca Airport - CVJ , Cuernavaca , MX "," Ensenada Airport - ESE , Ensenada , MX "," Guadalajara Miguel Hidal Airport - GDL , Guadalajara , MX "," Guaymas Gen Jose M Yanez Airport - GYM , Guaymas , MX "," Guerrero Negro Airport - GUB , Guerrero negro , MX "," Hermosillo Gen Pesqueira Garcia Airport - HMO , Hermosillo , MX "," Huatulco Airport - HUX , Huatulco , MX "," Ixtepec Airport - IZT , Ixtepec , MX "," Lagos de Moreno Francisco P. V. y R Airport - LOM , Lagos de moreno , MX "," Los Mochis Federal Airport - LMM , Los mochis , MX "," Matamoros Airport - MAM , Matamoros , MX "," Mexicali Airport - MXL , Mexicali , MX "," MEXICO CITY AIRPORT - MEX , MEXICO , MX "," Monclova Airport - LOV , Monclova , MX "," Morelia Airport - MLM , Morelia , MX "," Nuevo Laredo Int'l Quetzalcoatl Airport - NLD , Nuevo laredo , MX "," Palenque Airport - PQM , Palenque , MX "," Piedras Negras Airport - PDS , Piedras negras , MX "," Playa del Carmen Airport - PCM , Playa del carmen , MX "," Pochutla Airport - PUH , Pochutla , MX "," Poza Rica Tajin Airport - PAZ , Poza rica , MX "," Puerto Escondido Airport - PXM , Puerto escondido , MX "," Puerto Vallarta Ordaz Airport - PVR , Puerto vallarta , MX "," Reynosa Gen Lucio Blanco Airport - REX , Reynosa , MX "," Salina Cruz Airport - SCX , Salina cruz , MX "," Saltillo Airport - SLW , Saltillo , MX "," Tampico Gen F Javier Mina Airport - TAM , Tampico , MX "," Tapachula Int'l Airport - TAP , Tapachula , MX "," Tijuana Rodriguez Airport - TIJ , Tijuana , MX "," Toluca Airport - TLC , Toluca , MX "," Tulum Airport - TUY , Tulum , MX "," Uruapan Airport - UPN , Uruapan , MX "," Villahermosa Capitan Carlos Perez Airport - VSA , Villahermosa , MX "," Zamora Airport - ZMM , Zamora , MX "," MONACO Airport - XMM , MONACO , MC "," Monte Carlo - MCM , Monte carlo , MC "," Baruun-Urt Airport - UUN , Baruun-urt , MN "," Dalanzadgad Airport - DLZ , Dalanzadgad , MN "," Ulaangom Airport - ULO , Ulaangom , MN "," Buyant Uhaa Airport - ULN , ULAN BATOR , MN "," Agadir Almassira Airport - AGA , Agadir , MA "," Al Hoceima Charif Al Idrissi Airport - AHU , Al hoceima , MA "," Errachidia Airport - ERH , Errachidia , MA "," Essaouira Airport - ESU , Essaouira , MA "," Fez Sais Airport - FEZ , Fez , MA "," Kenitra  Airport - NNA , Kenitra , MA "," Meknes Airport - MEK , Meknes , MA "," Nador Airport - NDR , Nador , MA "," Ouarzazate Airport - OZZ , Ouarzazate , MA "," Oujda Les Angades Airport - OUD , Oujda , MA "," Rabat Sale Airport - RBA , Rabat , MA "," Safi Airport - SFI , Safi , MA "," Tan Tan Airport - TTA , Tan tan , MA "," Angoche Airport - ANO , Angoche , MZ "," Beira Airport - BEW , Beira , MZ "," Chimoio Airport - VPY , Chimoio , MZ "," Cuamba Airport - FXO , Cuamba , MZ "," Lichinga Airport - VXC , Lichinga , MZ "," Maputo Int'l Airport - MPM , Maputo , MZ "," Montepuez Airport - MTU , Montepuez , MZ "," Nacala Airport - MNC , Nacala , MZ "," Pemba Airport - POL , Pemba , MZ "," Quelimane Airport - UEL , Quelimane , MZ "," Arandis Airport - ADI , Arandis , NA "," Gobabis Airport - GOG , Gobabis , NA "," Grootfontein Airport - GFY , Grootfontein , NA "," Karasburg Airport - KAS , Karasburg , NA "," Keetmanshoop J.G.H. Van Der Wath Airport - KMP , Keetmanshoop , NA "," Ondangwa Airport - OND , Ondangwa , NA "," Oranjemund Airport - OMD , Oranjemund , NA "," Oshakati Airport - OHI , Oshakati , NA "," Otjiwarongo Airport - OTJ , Otjiwarongo , NA "," Rundu Airport - NDU , Rundu , NA "," Swakopmund Airport - SWP , Swakopmund , NA "," Tsumeb Airport - TSB , Tsumeb , NA "," Walvis Bay Rooikop Airport - WVB , Walvis bay , NA "," Hosea Kutako Int L Airport - WDH , WINDHOEK , NA "," Tribhuvan Airport - KTM , Kathmandu , NP "," Amsterdam-Schiphol Airport - AMS , Amsterdam , NL "," Bergen Op Zoom Woensdrecht Airport - BZM , Bergen op zoom , NL "," Breda Gilze-Rijen Airport - GLZ , Breda , NL "," Den Helder De Kooy Airport - DHR , Den helder , NL "," Eindhoven Airport - EIN , Eindhoven , NL "," Enschede Twente Airport - ENS , Enschede , NL "," Leeuwarden Airport - LWR , Leeuwarden , NL "," Leiden Valkenburg Airport - LID , Leiden , NL "," Lelystad Airport - LEY , Lelystad , NL "," Maastricht/Aachen Airport - MST , Maastricht , NL "," Rotterdam Airport - RTM , Rotterdam , NL "," Uden Volkel Airport - UDE , Uden , NL "," Woensdrecht AB Airport - WOE , Woensdrecht , NL "," Ashburton Airport - ASG , Ashburton , NZ "," Auckland International Airport - AKL , Auckland , NZ "," Christchurch Int'l Airport - CHC , Christchurch , NZ "," Dargaville Airport - DGR , Dargaville , NZ "," Fox Glacier Airport - FGL , Fox glacier , NZ "," Franz Josef Airport - WHO , Franz josef , NZ "," Gisborne Airport - GIS , Gisborne , NZ "," Greymouth Airport - GMN , Greymouth , NZ "," Hokitika Airport - HKK , Hokitika , NZ "," Invercargill Airport - IVC , Invercargill , NZ "," Kaikohe Airport - KKO , Kaikohe , NZ "," Kaitaia Airport - KAT , Kaitaia , NZ "," Kerikeri Airport - KKE , Kerikeri , NZ "," Masterton Airport - MRO , Masterton , NZ "," Matamata Airport - MTA , Matamata , NZ "," Motueka Airport - MZP , Motueka , NZ "," New Plymouth Airport - NPL , New plymouth , NZ "," Oamaru Airport - OAM , Oamaru , NZ "," Palmerston North Airport - PMR , Palmerston north , NZ "," Rotorua Airport - ROT , Rotorua , NZ "," Taupo Airport - TUO , Taupo , NZ "," Tauranga Airport - TRG , Tauranga , NZ "," Te Anau Manapouri Airport - TEU , Te anau , NZ "," Timaru Airport - TIU , Timaru , NZ "," Tokoroa Airport - TKZ , Tokoroa , NZ "," Wairoa Airport - WIR , Wairoa , NZ "," Wanaka Airport - WKA , Wanaka , NZ "," Wanganui Airport - WAG , Wanganui , NZ "," Whakatane Airport - WHK , Whakatane , NZ "," Whangarei Airport - WRE , Whangarei , NZ "," Whitianga Airport - WTZ , Whitianga , NZ "," Bluefields Airport - BEF , Bluefields , NI "," Corn Island Airport - RNI , Corn island , NI "," Managua Augusto C Sandino Airport - MGA , Managua , NI "," Nueva Guinea Airport - NVG , Nueva guinea , NI "," Puerto Cabezas Airport - PUZ , Puerto cabezas , NI "," Siuna Airport - SIU , Siuna , NI "," Arlit Airport - RLT , Arlit , NE "," Niamey Airport - NIM , Niamey , NE "," Akure Airport - AKR , Akure , NG "," Calabar Airport - CBQ , Calabar , NG "," Ibadan Airport - IBA , Ibadan , NG "," Ilorin Airport - ILR , Ilorin , NG "," Jos Airport - JOS , Jos , NG "," Lagos Murtala Muhammed Airport - LOS , Lagos , NG "," Maiduguri Airport - MIU , Maiduguri , NG "," Makurdi Airport - MDI , Makurdi , NG "," Minna Airport - MXJ , Minna , NG "," Port Harcourt Airport - PHC , Port harcourt , NG "," Yola Airport - YOL , Yola , NG "," Zaria Airport - ZAR , Zaria , NG "," Andenes Airport - ANX , Andenes , NO "," Bergen Flesland Airport - BGO , Bergen , NO "," Fagernes Valdres Airport - VDB , Fagernes , NO "," Farsund Lista Airport - FAN , Farsund , NO "," Geilo Dagali Airport - DLD , Geilo , NO "," Gol Klanten Airport - GLL , Gol , NO "," Hammerfest Airport - HFT , Hammerfest , NO "," Hasvik Airport - HAA , Hasvik , NO "," Haugesund Airport - HAU , Haugesund , NO "," Kirkenes Hoeybuktmoen Airport - KKN , Kirkenes , NO "," Kristiansand Kjevik Airport - KRS , Kristiansand , NO "," Kristiansund Kvernberget Airport - KSU , Kristiansund , NO "," Lakselv Banak Airport - LKL , Lakselv , NO "," Leknes Airport - LKN , Leknes , NO "," Mehamn Airport - MEH , Mehamn , NO "," Mo I Rana Airport - MQN , Mo i rana , NO "," Namsos Airport - OSY , Namsos , NO "," Narvik Framnes Airport - NVK , Narvik , NO "," Notodden Airport - NTB , Notodden , NO "," Norway Oslo Airport - OSL , OSLO , NO "," Sandane Airport - SDN , Sandane , NO "," Sandefjord Torp Airport - TRF , Sandefjord , NO "," Stavanger Sola Airport - SVG , Stavanger , NO "," Stokmarknes Skagen Airport - SKN , Stokmarknes , NO "," Trondheim Vaernes Airport - TRD , Trondheim , NO "," Muscat Seeb Airport - MCT , Muscat , OM "," Salalah Airport - SLL , Salalah , OM "," Bannu Airport - BNP , Bannu , PK "," Chitral Airport - CJL , Chitral , PK "," Dadu Airport - DDU , Dadu , PK "," Dalbandin Airport - DBA , Dalbandin , PK "," Dera Ismail Khan Airport - DSK , Dera ismail khan , PK "," Gilgit Airport - GIL , Gilgit , PK "," Gwadar Airport - GWD , Gwadar , PK "," Jacobabad Airport - JAG , Jacobabad , PK "," Jiwani Airport - JIW , Jiwani , PK "," Karachi Quaid-E-Azam Int'l Airport - KHI , Karachi , PK "," Khuzdar Airport - KDD , Khuzdar , PK "," Kohat Airport - OHT , Kohat , PK "," Mansehra Airport - HRA , Mansehra , PK "," Mirpur Khas Airport - MPD , Mirpur khas , PK "," Muzaffarabad Airport - MFG , Muzaffarabad , PK "," Nawabshah Airport - WNS , Nawabshah , PK "," Nushki Airport - NHS , Nushki , PK "," Ormara Airport - ORW , Ormara , PK "," Pasni Airport - PSI , Pasni , PK "," Peshawar Airport - PEW , Peshawar , PK "," Quetta Airport - UET , Quetta , PK "," Shikarpur Airport - SWV , Shikarpur , PK "," Sibi Airport - SBQ , Sibi , PK "," Sukkur Airport - SKZ , Sukkur , PK "," Turbat Airport - TUK , Turbat , PK "," Zhob Airport - PZH , Zhob , PK "," Koror Airai Airport - ROR , Koror , PW "," Achutupo Airport - ACU , Achutupo , PA "," Changuinola Airport - CHX , Changuinola , PA "," David Enrique Malek Airport - DAV , David , PA "," Mulatupo Airport - MPP , Mulatupo , PA "," Ustupo Airport - UTU , Ustupo , PA "," Yaviza Airport - PYV , Yaviza , PA "," Aitape Airstrip Airport - ATP , Aitape , PG "," Ambunti Airport - AUJ , Ambunti , PG "," Angoram Airport - AGG , Angoram , PG "," Arawa Airport - RAW , Arawa , PG "," Balimo Airport - OPU , Balimo , PG "," Bulolo Airport - BUL , Bulolo , PG "," Finschhafen Airport - FIN , Finschhafen , PG "," Goroka Airport - GKA , Goroka , PG "," Kandrian Airport - KDR , Kandrian , PG "," Kavieng Airport - KVG , Kavieng , PG "," Kerema Airport - KMA , Kerema , PG "," Kieta Aropa Airport - KIE , Kieta , PG "," Kiunga Airport - UNG , Kiunga , PG "," Kokoro Airport - KOR , Kokoro , PG "," Mt. Hagen Kagamuga Airport - HGU , Mount hagen , PG "," Namatanai Airport - ATN , Namatanai , PG "," Porgera Airport - RGE , Porgera , PG "," Port Moresby Jackson Field Airport - POM , Port moresby , PG "," Rabaul Lakunai Airport - RAB , Rabaul , PG "," Vanimo Airport - VAI , Vanimo , PG "," Wabag Airport - WAB , Wabag , PG "," Wewak Boram Airport - WWK , Wewak , PG "," Ciudad del Este Alejo Garcia Airport - AGT , Ciudad del este , PY "," Filadelfia Airport - FLM , Filadelfia , PY "," Fuerte Olimpo  Airport - OLK , Fuerte olimpo , PY "," Pedro Juan Caballero Airport - PJC , Pedro juan caballero , PY "," Andahuaylas Airport - ANS , Andahuaylas , PE "," Arequipa Rodriguez Ballon Airport - AQP , Arequipa , PE "," Bellavista Airport - BLP , Bellavista , PE "," Chiclayo Cornel Ruiz Airport - CIX , Chiclayo , PE "," Chimbote Airport - CHM , Chimbote , PE "," Ilo Airport - ILQ , Ilo , PE "," Iquitos C.F. Secada Airport - IQT , Iquitos , PE "," Jauja Airport - JAU , Jauja , PE "," Juliaca Airport - JUL , Juliaca , PE "," Lima Airport - LIM , Lima , PE "," Moyobamba Airport - MBP , Moyobamba , PE "," Pisco Airport - PIO , Pisco , PE "," Pucallpa Capitan Rolden Airport - PCL , Pucallpa , PE "," Puerto Maldonado Airport - PEM , Puerto maldonado , PE "," Rioja Airport - RIJ , Rioja , PE "," Saposoa Airport - SQU , Saposoa , PE "," Tacna Airport - TCQ , Tacna , PE "," Talara Airport - TYL , Talara , PE "," Tarapoto Airport - TPP , Tarapoto , PE "," Trujillo Airport - TRU , Trujillo , PE "," Tumbes Airport - TBP , Tumbes , PE "," Yurimaguas Airport - YMS , Yurimaguas , PE "," Bacolod Airport - BCD , Bacolod , PH "," Baganga Airport - BNQ , Baganga , PH "," Baguio Loakan Airport - BAG , Baguio , PH "," Bislig Airport - BPH , Bislig , PH "," Butuan Airport - BXU , Butuan , PH "," Casiguran Airport - CGG , Casiguran , PH "," Catarman National Airport - CRM , Catarman , PH "," Cuyo Airport - CYU , Cuyo , PH "," Daet Camarines Norte Airport - DTE , Daet , PH "," Davao Mati Airport - DVO , Davao , PH "," Dipolog Airport - DPL , Dipolog , PH "," Dumaguete Airport - DGT , Dumaguete , PH "," Iligan Maria Cristina Airport - IGN , Iligan , PH "," Ipil Airport - IPE , Ipil , PH "," Jolo Airport - JOL , Jolo , PH "," Kalibo Airport - KLO , Kalibo , PH "," Laoag Airport - LAO , Laoag , PH "," Lubang Airport - LBX , Lubang , PH "," Malabang Airport - MLP , Malabang , PH "," Mamburao Airport - MBO , Mamburao , PH "," Manila Ninoy Aquino Int'l Airport - MNL , Manila , PH "," Maramag Airport - XMA , Maramag , PH "," Masbate Airport - MBT , Masbate , PH "," Mati Airport - MXI , Mati , PH "," Naga Airport - WNP , Naga , PH "," Ormoc Airport - OMC , Ormoc , PH "," Ozamis City Labo Airport - OZC , Ozamiz , PH "," Pagadian Airport - PAG , Pagadian , PH "," ILOILO - ILO , PHILIPPINE ISLANDS , PH "," LUZON ISLAND CLARK FIELD - CRK , PHILIPPINE ISLANDS , PH "," Puerto Princesa Airport - PPS , Puerto princesa , PH "," San Fernando Airport - SFE , San fernando , PH "," Sanga Sanga Airport - SGS , Sanga-sanga , PH "," Siasi Airport - SSV , Siasi , PH "," Siocon Airport - XSO , Siocon , PH "," Tablas Airport - TBH , Tablas , PH "," Tacloban D.Z. Romualdez Airport - TAC , Tacloban , PH "," Tagbilaran Airport - TAG , Tagbilaran , PH "," Tuguegarao Airport - TUG , Tuguegarao , PH "," Virac Airport - VRC , Virac , PH "," Zamboanga Airport - ZAM , Zamboanga , PH "," Bydgoszcz Airport - BZG , Bydgoszcz , PL "," Czestochowa Airport - CZW , Czestochowa , PL "," Elblag Airport - ZBG , Elblag , PL "," Katowice Pyrzowice Airport - KTW , Katowice , PL "," Koszalin Airport - OSZ , Koszalin , PL "," Olsztyn Airport - QYO , Olsztyn , PL "," Poznan Lawica Airport - POZ , Poznan , PL "," Slupsk Redzikowo Airport - OSP , Slupsk , PL "," Suwalki Airport - ZWK , Suwalki , PL "," Szczecin Goleniow Airport - SZZ , Szczecin , PL "," Warsaw Okecie Airport - WAW , Warsaw , PL "," Wroclaw Strachowice Airport - WRO , Wroclaw , PL "," Braga Airport - BGZ , Braga , PT "," Chaves Airport - CHV , Chaves , PT "," Coimbra Airport - CBP , Coimbra , PT "," Faro Airport - FAO , Faro , PT "," Funchal Airport - FNC , Funchal , PT "," Horta Airport - HOR , Horta , PT "," Lisbon Lisboa Airport - LIS , Lisbon , PT "," Ponta Delgada Nordela Airport - PDL , Ponta delgada , PT "," Porto Airport - OPO , Porto , PT "," Porto Santo Airport - PXO , Porto santo , PT "," Ribeira Grande  Airport - QEG , Ribeira grande , PT "," Sines Airport - SIE , Sines , PT "," Viseu Airport - VSE , Viseu , PT "," Luis Munoz Marin Airport - SJU , SAN JUAN , PR "," Doha Airport - DOH , Doha , QA "," Gillot Airport - RUN , Saint Denis Reunion , RE "," Bucharest - All Airports - BUH , Bucharest , RO "," Bucharest Baneasa Airport - BBU , Bucharest , RO "," Bucharest Otopeni Int'l Airport - OTP , Bucharest , RO "," Caransebes Airport - CSB , Caransebes , RO "," Constanta Kogalniceanu Airport - CND , Constanta , RO "," Craiova Airport - CRA , Craiova , RO "," Deva Airport - DVA , Deva , RO "," Oradea Airport - OMR , Oradea , RO "," Timisoara Airport - TSR , Timisoara , RO "," Aldan Airport - ADH , Aldan , RU "," Amderma Airport - AMV , Amderma , RU "," Anadyr Airport - DYR , Anadyr , RU "," Balakovo Airport - BWO , Balakovo , RU "," Barnaul Airport - BAX , Barnaul , RU "," Blagoveschensk Airport - BQS , Blagoveschensk , RU "," Bratsk Airport - BTK , Bratsk , RU "," Cheboksary Airport - CSY , Cheboksary , RU "," Cherepovets Airport - CEE , Cherepovets , RU "," Cherskiy Airport - CYX , Cherskiy , RU "," Chokurdah Airport - CKH , Chokurdah , RU "," Chulman Airport - CNN , Chulman , RU "," Elista Airport - ESL , Elista , RU "," Gelendzik Airport - GDZ , Gelendzik , RU "," Igarka Airport - IAA , Igarka , RU "," Inta Airport - INA , Inta , RU "," Izhevsk Airport - IJK , Izhevsk , RU "," Kaliningrad Airport - KGD , Kaliningrad , RU "," Kazan Airport - KZN , Kazan , RU "," Khabarovsk Novyy Airport - KHV , Khabarovsk , RU "," Kogalym Airport - KGP , Kogalym , RU "," Komsomolsk Na Amure Airport - KXK , Komsomolsk na amure , RU "," Kotlas Airport - KSZ , Kotlas , RU "," Magadan Airport - GDX , Magadan , RU "," Magdagachi Airport - GDG , Magdagachi , RU "," Magnitogorsk Airport - MQF , Magnitogorsk , RU "," Makhachkala Airport - MCX , Makhachkala , RU "," Mineralnye Vody Airport - MRV , Mineralnyye vody , RU "," All Moscow Airports - MOW , Moscow , RU "," Moscow Domodedovo Airport - DME , Moscow , RU "," Moscow Sheremetyevo Airport - SVO , Moscow , RU "," Moscow Vnukovo Airport - VKO , Moscow , RU "," Nadym Airport - NYM , Nadym , RU "," Nalchik Airport - NAL , Nalchik , RU "," Naryan-Mar Airport - NNM , Naryan-mar , RU "," Neftekamsk Airport - NEF , Neftekamsk , RU "," Nefteyugansk Airport - NFG , Nefteyugansk , RU "," Neryungri Airport - NER , Neryungri , RU "," Nizhnevartovsk Airport - NJC , Nizhnevartovsk , RU "," Noril'sk Airport - NSK , Norilsk , RU "," Novokuznetsk Airport - NOZ , Novokuznetsk , RU "," Novorossijsk Airport - NOI , Novorossijsk , RU "," Novosibirsk Tolmachevo Airport - OVB , Novosibirsk , RU "," Ohotsk Airport - OHO , Ohotsk , RU "," Omsk Airport - OMS , Omsk , RU "," Orsk Airport - OSW , Orsk , RU "," Pechora Airport - PEX , Pechora , RU "," Petropavlovsk-Kamchat Airport - PKC , Petropavlovsk kamchatskiy , RU "," Petrozavodsk Airport - PES , Petrozavodsk , RU "," Pevek Airport - PWE , Pevek , RU "," Provideniya Airport - PVS , Provideniya , RU "," Rybinsk Airport - RYB , Rybinsk , RU "," St. Petersburg Pulkovo Airport - LED , Saint Petersburg , RU "," Salehard Airport - SLY , Salehard , RU "," Saransk Airport - SKX , Saransk , RU "," Surgut Airport - SGC , Surgut , RU "," Syktyvkar Airport - SCW , Syktyvkar , RU "," Tiksi Airport - IKS , Tiksi , RU "," Tobolsk Airport - TOX , Tobolsk , RU "," Tomsk Airport - TOF , Tomsk , RU "," Tynda Airport - TYD , Tynda , RU "," Ufa Airport - UFA , Ufa , RU "," Ukhta Airport - UCT , Ukhta , RU "," Ulan-Ude Airport - UUD , Ulan ude , RU "," Ulyanovsk Airport - ULY , Ulyanovsk , RU "," Usinsk Airport - USK , Usinsk , RU "," Ust-Ilimsk Airport - UIK , Ust ilimsk , RU "," Ust-Kut Airport - UKX , Ust-kut  , RU "," Velikij Ustyug Airport - VUS , Velikij ustyug , RU "," Vladikavkaz Airport - OGZ , Vladikavkaz , RU "," Vladivostok Airport - VVO , Vladivostok , RU "," Volgodonsk Airport - VLK , Volgodonsk , RU "," Vorkuta Airport - VKT , Vorkuta , RU "," Yakutsk Airport - YKS , Yakutsk , RU "," Yaroslavl Airport - IAR , Yaroslavl  , RU "," Joshkar-Ola Airport - JOK , Yoshkar ola , RU "," Yuzhno-Sakhalinsk Airport - UUS , Yuzhno sakhalinsk , RU "," Kigali Gregoire Kayibanda Airport - KGL , Kigali , RW "," Abha Airport - AHB , Abha , SA "," Jeddah King Abdulaziz Int'l Airport - JED , Jeddah , SA "," Riyadh King Khaled Int'l Airport - RUH , Riyadh , SA "," Tabuk Airport - TUU , Tabuk , SA "," Yanbu Airport - YNB , Yanbu , SA "," Bakel Airport - BXE , Bakel , SN "," Dakar Yoff Airport - DKR , Dakar , SN "," Podor Airport - POD , Podor , SN "," Richard Toll Airport - RDT , Richard toll , SN "," Nis Airport - INI , Nis , YU "," Podgorica Golubovci Airport - TGD , Podgorica , YU "," Pristina Airport - PRN , Pristina , YU "," Uzice Ponikve Airport - UZC , Uzice , YU "," Mahe Island Seychelles Int'l Airport - SEZ , Mahe Island , SC "," Kenema Airport - KEN , Kenema , SL "," Yengema Airport - WYE , Yengema , SL "," Changi Airport - SIN , Singapore , SG "," Bratislava Ivanka Airport - BTS , Bratislava , SK "," Kosice Barca Airport - KSC , Kosice , SK "," Lucenec Airport - LUE , Lucenec , SK "," Presov Airport - POV , Presov , SK "," Sliac Airport - SLD , Sliac , SK "," Zilina Airport - ILZ , Zilina , SK "," Ljubljana Brnik Airport - LJU , Ljubljana , SI "," Maribor Airport - MBX , Maribor , SI "," Portoroz Airport - POW , Portoroz , SI "," Auki Gwaunaru'u Airport - AKS , Auki , SB "," Honiara Henderson Int'l Airport - HIR , Honiara , SB "," Kirakira Airport - IRA , Kirakira , SB "," Alula Airport - ALU , Alula , SO "," Bardera Airport - BSY , Bardera , SO "," Berbera Airport - BBO , Berbera , SO "," Borama Airport - BXX , Borama , SO "," Bossaso Airport - BSA , Bosaso , SO "," Burao Airport - BUO , Bur'o , SO "," Garbaharey Airport - GBM , Garbaharey , SO "," Hargeisa Airport - HGA , Hargeysa , SO "," Kismayu Airport - KMU , Kismayo , SO "," Mogadishu Int'l Airport - MGQ , Mogadishu , SO "," Bisho Airport - BIY , Bisho , ZA "," Bloemfontein Bloemfontein Int'l Airport - BFN , Bloemfontein , ZA "," Cape Town Int'l Airport - CPT , Cape town , ZA "," Cradock Airport - CDO , Cradock , ZA "," East London Airport - ELS , East london , ZA "," Ellisras Airport - ELL , Ellisras , ZA "," Empangeni Airport - EMG , Empangeni , ZA "," George Airport - GRJ , George , ZA "," Giyani Airport - GIY , Giyani , ZA "," Harrismith Harrismith Airport - HRS , Harrismith , ZA "," Johannesburg Int'l Airport - JNB , JOHANNESBURG , ZA "," Klerksdorp Airport - KXE , Klerksdorp , ZA "," Komatipoort Airport - KOF , Komatipoort , ZA "," Kuruman Airport - KMH , Kuruman , ZA "," Louis Trichardt Airport - LCD , Louis trichardt , ZA "," Mmabatho Int'l Airport - MBD , Mmabatho , ZA "," Nelspruit Airport - NLP , Nelspruit , ZA "," Oudtshoorn Airport - OUH , Oudtshoorn , ZA "," Phalaborwa Airport - PHW , Phalaborwa , ZA "," Pietermaritzburg Airport - PZB , Pietermaritzburg , ZA "," South Africa Polokwane Airport - PTG , Pietersburg , ZA "," Plettenberg Bay Airport - PBZ , Plettenberg bay , ZA "," Port Alfred Airport - AFD , Port alfred , ZA "," Port Elizabeth Airport - PLZ , Port elizabeth , ZA "," Prieska Airport - PRK , Prieska , ZA "," Queenstown Airport - UTW , Queenstown , ZA "," Richards Bay Airport - RCB , Richards bay , ZA "," Robertson Airport - ROD , Robertson , ZA "," Secunda Airport - ZEC , Secunda , ZA "," Thaba Nchu Airport - TCU , Thaba nchu , ZA "," Thohoyandou Airport - THY , Thohoyandou , ZA "," Tzaneen Letaba Airport - LTA , Tzaneen , ZA "," Ulundi Airport - ULD , Ulundi , ZA "," Umtata Airport - UTT , Umtata , ZA "," Upington Airport - UTN , Upington , ZA "," Vredendal Airport - VRE , Vredendal , ZA "," Vryburg Airport - VRU , Vryburg , ZA "," Vryheid Airport - VYD , Vryheid , ZA "," Welkom Airport - WEL , Welkom , ZA "," Alicante Airport - ALC , ALICANTE , ES "," Barcelona Airport - BCN , Barcelona , ES "," Gerona Airport - GRO , Barcelona , ES "," Reus Airport - REU , Barcelona , ES "," La Palma Del Condada  Airport - NDO , La palma del condada , ES "," Las Palmas de Gran Canaria Airport - LPA , Las Palmas , ES "," Madrid Barajas Airport - MAD , Madrid , ES "," Malaga Airport - AGP , Malaga , ES "," Palma Mallorca Airport - PMI , Palma de Mallorca , ES "," Sevilla Airport - SVQ , Sevilla , ES "," Valencia Airport - VLC , Valencia , ES "," Valladolid Airport - VLL , Valladolid , ES "," Juba Airport - JUB , Juba , SD "," Khartoum Civil Airport - KRT , Khartoum , SD "," Malakal Airport - MAK , Malakal , SD "," Wadi Halfa Airport - WHF , Wadi halfa , SD "," Moengo Airport - MOJ , Moengo , SR "," Nieuw Nickerie Airport - ICK , Nieuw nickerie , SR "," Eskilstuna Airport - EKT , Eskilstuna , SE "," Gothenburg Landvetter Airport - GOT , Gothenburg , SE "," Halmstad Airport - HAD , Halmstad , SE "," Helsingborg Angelholm Airport - AGH , Helsingborg , SE "," Hudiksvall Airport - HUV , Hudiksvall , SE "," Karlskoga Airport - KSK , Karlskoga , SE "," Karlstad Airport - KSD , Karlstad , SE "," Kiruna Airport - KRN , Kiruna , SE "," Kristianstad Airport - KID , Kristianstad , SE "," Oskarshamn Airport - OSK , Oskarshamn , SE "," Stockholm - All Airports - STO , STOCKHOLM , SE "," Sundsvall/Harnosand Airport - SDL , Sundsvall , SE "," Visby Airport - VBY , Visby , SE "," Ascona Airport - ACO , Ascona , CH "," Basel/Mulhouse Airport - BSL , Basel , CH "," Berne Belp Airport - BRN , Bern , CH "," Geneva Geneve-Cointrin Airport - GVA , Geneva , CH "," Lugano Airport - LUG , Lugano , CH "," Sion Airport - SIR , Sion , CH "," Zurich Airport - ZRH , Zurich , CH "," Aleppo Nejrab Airport - ALP , Aleppo , SY "," Damascus Int'l Airport - DAM , Damascus , SY "," Taipei Songshan Airport - TSA , Taipei , TW "," Taoyuan International Airport - TPE , Taipei , TW "," Dushanbe Airport - DYU , Dushanbe , TJ "," Dar Es Salaam Int'l Airport - DAR , Dar Es Salaam , TZ "," Kilimanjaro Airport - JRO , Kilimanjaro , TZ "," Lushoto Airport - LUY , Lushoto , TZ "," Masasi Airport - XMI , Masasi , TZ "," Musoma Airport - MUZ , Musoma , TZ "," Mwadui Airport - MWN , Mwadui , TZ "," Nachingwea Airport - NCH , Nachingwea , TZ "," Njombe Airport - JOM , Njombe , TZ "," Songea Airport - SGX , Songea , TZ "," Sumbawanga Airport - SUT , Sumbawanga , TZ "," Zanzibar Kisauni Airport - ZNZ , Zanzibar , TZ "," BANGKOK - NBK , Bangkok , TH "," Bangkok Int'l Airport - BKK , Bangkok , TH "," Hat Yai Airport - HDY , Hat yai , TH "," Hua Hin Airport - HHQ , Hua hin , TH "," Mae Sot Airport - MAQ , Mae sot , TH "," Takhli Airport - TKH , Takhli , TH "," Udon Thani Airport - UTH , Udon thani , TH "," Tunis Carthage Airport - TUN , Tunis , TN "," Adana Airport - ADA , Adana , TR "," Etimesgut Airport - ANK , ANKARA , TR "," Antalya Airport - AYT , Antalya , TR "," Bandirma Airport - BDM , Bandirma , TR "," Batman Airport - BAL , Batman , TR "," Bursa Airport - BTZ , Bursa , TR "," Dalaman Airport - DLM , Dalaman , TR "," Elazig Airport - EZS , Elazig , TR "," Eskisehir Airport - ESK , Eskisehir , TR "," Gaziantep Airport - GZT , Gaziantep , TR "," Istanbul Ataturk Airport - IST , Istanbul , TR "," Kayseri Airport - ASR , Kayseri , TR "," Malatya Airport - MLX , Malatya , TR "," Merzifon Airport - MZH , Merzifon , TR "," Mus Airport - MSR , Mus , TR "," Sivas Airport - VAS , Sivas , TR "," Usak Airport - USQ , Usak , TR "," Entebbe Airport - EBB , ENTEBBE , UG "," Kerch Airport - KHC , Kerch , UA "," Kiev Zhulhany Airport - IEV , KIEV , UA "," Mariupol Airport - MPW , Mariupol , UA "," Simferopol Airport - SIP , Simferopol , UA "," Abu Dhabi Int'l Airport - AUH , Abu dhabi , AE "," Dubai Airport - DXB , Dubai , AE "," Aberdeen Dyce Airport - ABZ , Aberdeen , GB "," Bally Kelly Airport - BOL , Bally kelly , GB "," Barrow-in-Furness Walney Island Airport - BWF , Barrow-in-furness , GB "," Belfast Intl Airport - BFS , BELFAST , GB "," Bembridge Airport - BBP , Bembridge , GB "," Benbecula Airport - BEB , Benbecula , GB "," Birmingham Intl Airport - BHX , BIRMINGHAM , GB "," Blackpool Airport - BLK , Blackpool , GB "," Bournemouth Int'l Airport - BOH , Bournemouth , GB "," Bristol Airport - BRS , BRISTOL , GB "," Burtonwood Airport - BUT , Burtonwood , GB "," Bury St. Edmunds Honington Airport - BEQ , Bury saint edmunds , GB "," Campbeltown Machrihanish Airport - CAL , Campbeltown , GB "," Cardiff-Wales Airport - CWL , Cardiff , GB "," Coventry Baginton Airport - CVT , Coventry , GB "," Croydon Airport - CDQ , CROYDON , GB "," Doncaster Finningley Airport - DCS , Doncaster , GB "," East Midlands Airport - EMA , East midlands , GB "," Edinburgh Turnhouse Airport - EDI , Edinburgh , GB "," Exeter Airport - EXT , Exeter , GB "," Fakenham Airport - FKH , Fakenham , GB "," Glasgow Int'l Airport - GLA , Glasgow , GB "," Harrogate Linton-on-Ouse Airport - HRT , Harrogate , GB "," Haverfordwest Airport - HAW , Haverfordwest , GB "," High Wycombe Airport - HYC , High wycombe , GB "," Holyhead Airport - HLY , Holyhead , GB "," Humberside Airport - HUY , Humberside , GB "," Ipswich Airport - IPW , Ipswich , GB "," Isles Of Scilly  Airport - ISC , Isles of scilly , GB "," Kings Lynn Airport - KNF , King's lynn , GB "," Leeds Bradford Airport - LBA , Leeds , GB "," Liverpool John Lennon Airport - LPL , Liverpool , GB "," Gatwick Airport - LGW , London , GB "," Heathrow Airport - LHR , London , GB "," London Airport - LON , London , GB "," London City Airport - LCY , London , GB "," Luton Airport - LTN , London , GB "," Stansted Airport - STN , London , GB "," Lossiemouth  Airport - LMO , Lossiemouth , GB "," Lydd Int'l Airport - LYX , Lydd , GB "," Lyneham  Airport - LYE , Lyneham , GB "," Machrihanish  Airport - GQJ , Machrihanish , GB "," Manchester Int'l Airport - MAN , Manchester , GB "," Mildenhall Airport - MHZ , Mildenhall , GB "," Milton Keynes Airport - KYN , Milton keynes , GB "," Newcastle Airport - NCL , Newcastle , GB "," Newcastle Under Lyme Airport - VLF , Newcastle under lyme , GB "," Newquay St. Mawgan Airport - NQY , Newquay , GB "," Northolt Airport - NHT , Northolt , GB "," Norwich Airport - NWI , Norwich , GB "," Nottingham Airport  Airport - NQT , Nottingham , GB "," Odiham  Airport - ODH , Odiham , GB "," Penzance Airport - PZE , Penzance , GB "," Plymouth Airport - PLH , Plymouth , GB "," Portsmouth Airport - PME , Portsmouth , GB "," Glasgow Prestwick Airport - PIK , Prestwick , GB "," Sheffield City Airport - SZD , Sheffield , GB "," Eastleigh Airport - SOU , Southampton , GB "," Swansea Fairwood Comm Airport - SWS , Swansea , GB "," Swindon Airport - SWI , Swindon , GB "," Teesside Int'l Airport - MME , Teesside , GB "," West Malling Airport - WEM , West malling , GB "," Yeovilton Airport - YEO , Yeovilton , GB "," Aberdeen Airport - APG , Aberdeen , US "," ABILENE - ABI , ABILENE , US "," Abingdon Virginia Highlands Airport - VJI , Abingdon , US "," New Iberia Acadiana Regional Airport - ARA , Acadiana , US "," Ada Airport - ADT , Ada , US "," Anderson Municipal Airport - AID , Aderson , US "," Afton Municipal Airport - AFO , Afton , US "," Aiken Municipal Airport - AIK , Aiken , US "," Ainsworth Airport - ANW , Ainsworth , US "," Akhiok Airport - AKK , Akhiok , US "," Akiachak Airport - KKI , Akiachak , US "," Akiak Airport - AKI , Akiak , US "," Akron/Washington Co Airport - AKO , Akron , US "," Akron/Canton Regional Airport - CAK , Akron/canton , US "," Akutan Airport - KQA , Akutan , US "," Alakanuk Airport - AUK , Alakanuk , US "," Alameda  Airport - NGZ , Alameda , US "," Alamogordo Municipal Airport - ALM , Alamogordo-white sands , US "," Alamosa Municipal Airport - ALS , Alamosa , US "," Albany Intl Airport - ALB , Albany , US "," Albert Lea Airport - AEL , Albert lea , US "," Aleknagik Airport - WKK , Aleknagik , US "," Aleneva Airport - AED , Aleneva , US "," Alexander City Thomas C Russell Fie Airport - ALX , Alexander city , US "," ALEXANDRIA - AEX , ALEXANDRIA , US "," Alexandria Airport - AXN , Alexandria bay , US "," Alexandria Bay Airport - AXB , Alexandria bay , US "," Algona Airport - AXG , Algona , US "," Alice Int'l Airport - ALI , Alice , US "," Aliceville George Downer Airport - AIV , Aliceville , US "," Alitak Airport - ALZ , Alitak , US "," Allakaket Airport - AET , Allakaket , US "," ALLENTOWN - ABE , ALLENTOWN , US "," Alliance Airport - AIA , Alliance , US "," Alma Gratiot Community Airport - AMN , Alma , US "," Alpena County Regional Airport - APN , Alpena , US "," Alpine Airport - ALE , Alpine , US "," Alton Airport - ALN , Alton , US "," Altoona Airport - AOO , Altoona , US "," Altus Municipal Airport - AXS , Altus , US "," Alyeska Airport - AQY , Alyeska , US "," AMARILLO - AMA , AMARILLO , US "," Amchitka Airport - AHT , Amchitka , US "," Amery Municipal Airport - AHH , Amery , US "," Ames Airport - AMW , Ames , US "," Amityville Zahns Airport - AYZ , Amityville , US "," Amook Airport - AOS , Amook , US "," Anacortes Airport - OTS , Anacortes , US "," Anaheim Airport - ANA , Anaheim , US "," Anaktuvuk Airport - AKP , Anaktuvuk , US "," Anderson Airport - AND , Anderson , US "," Andrews Airport - ADR , Andrews , US "," Angel Fire Airport - AXX , Angel fire , US "," Angola Tri-State Steuben Cty Airport - ANQ , Angola , US "," Angoon Airport - AGN , Angoon , US "," Anguilla Rollang Field Airport - RFK , Anguilla , US "," Aniak Airport - ANI , Aniak , US "," Anita Bay Airport - AIB , Anita bay , US "," Ann Arbor Municipal Airport - ARB , Ann arbor , US "," Annapolis Lee Airport - ANP , Annapolis , US "," Annette Island Airport - ANN , Annette island , US "," Anniston County Airport - ANB , Anniston , US "," Anthony Airport - ANY , Anthony , US "," Antlers Airport - ATE , Antlers , US "," Anvik Airport - ANV , Anvik , US "," Apple Valley Airport - APV , Apple valley , US "," Appleton Outagamie County Airport - ATW , Appleton , US "," Arapahoe Municipal Airport - AHF , Arapahoe , US "," Arctic Village Airport - ARC , Arctic village , US "," Ardmore Municipal Airport - ADM , Ardmore , US "," Municipal Drake Field - FYV , Arkansas , US "," Arlington Heights Airport - JLH , Arlington heights , US "," Ardmore Downtown Airport - AHD , Armore , US "," Artesia Airport - ATS , Artesia , US "," Asbury Park Airport - ARX , Asbury park , US "," Asheville Airport - AVL , Asheville , US "," Ashland Airport - ASX , Ashland , US "," Ashley Airport - ASY , Ashley , US "," Aspen Airport - ASE , Aspen , US "," Astoria Airport - AST , Astoria , US "," Athens Airport - AHN , Athens , US "," Athens McMinn County Airport - MMI , Athens , US "," Athens Ohio University Airport - ATO , Athens , US "," Atka Airport - AKB , Atka , US "," ATLANTA - ATL , ATLANTA , US "," Atlantic Municipal Airport - AIO , Atlantic , US "," Atmautluak Airport - ATT , Atmautluak , US "," Atqasuk Airport - ATK , Atqasuk , US "," Attu Island Casco Cove Airport - ATU , Attu island , US "," Auburn Airport - AUN , Auburn , US "," Auburn-Opelika Airport - AUO , Auburn-opelika , US "," Augusta Airport - AUG , Augusta , US "," Aurora Municipal Airport - AUZ , Aurora , US "," Austin Airport - ASQ , Austin , US "," Austin Airport - AUM , Austin , US "," Austin Bergstrom International Airport - AUS , Austin , US "," Catalina Island Avalo Vor/WP Airport - SXC , Avalon , US "," Avon Park Municipal Airport - AVO , Avon park , US "," Baca Grande Airport - BCJ , Baca grande , US "," Bagdad Airport - BGT , Bagdad , US "," Bainbridge Decatur County Airport - BGE , Bainbridge , US "," Baker Airport - BKE , Baker , US "," Baker Island Airport - BAR , Baker island , US "," Bakersfield Meadows Field Airport - BFL , Bakersfield , US "," BALTIMORE - BWI , BALTIMORE , US "," Bandon State Airport - BDY , Bandon , US "," Bangor Int'l Airport - BGR , Bangor , US "," Banning Airport - BNG , Banning , US "," Barbers Point Airport - NAX , Barbers point , US "," Bardstown Samuels Field Airport - BRY , Bardstown , US "," Barnwell County Airport - BNL , Barnwell , US "," Barrow Airport - BRW , Barrow , US "," Barter Island Airport - BTI , Barter island , US "," Bartlesville Airport - BVO , Bartlesville , US "," Bartow Airport - BOW , Bartow , US "," Batesville Hillenbrand Airport - HLB , Batesville , US "," Batesville Municipal Airport - BVX , Batesville , US "," BATON ROUGE - BTR , BATON ROUGE , US "," Battle Creek WK Kellogg Regional Airport - BTL , Battle creek , US "," Battle Mountain Lander County Airport - BAM , Battle mountain , US "," Baudette Airport - BDE , Baudette , US "," Bay City Airport - BBC , Bay city , US "," Baytown Airport - HPY , Baytown , US "," Bear Creek Airport - BCC , Bear creek , US "," Beatrice Airport - BIE , Beatrice , US "," Beatty Airport - BTY , Beatty , US "," Beaufort County Airport - BFT , Beaufort , US "," Beaver Falls Airport - BFP , Beaver falls , US "," Beckley Airport - BKW , Beckley , US "," Bedford Hanscom Field Airport - BED , Bedford , US "," Bedford Virgil I Grissom Muni Airport - BFR , Bedford , US "," Beeville  Airport - NIR , Beeville , US "," Bell Island Airport - KBE , Bell island , US "," Bellaire Antrim County Airport - ACB , Bellaire , US "," Belle Chasse Southern Seaplane Airport - BCS , Belle chasse , US "," Belleville Airport - BLV , Belleville , US "," Bellingham Airport - BLI , Bellingham , US "," Belmar Monmouth County Airport - BLM , Belmar , US "," Beluga Airport - BVU , Beluga , US "," Bemidji Airport - BJI , Bemidji , US "," Bennettsville Airport - BTN , Bennettsville , US "," Benson Municipal Airport - BBB , Benson , US "," Benton Harbor Ross Field Airport - BEH , Benton harbor , US "," Berkeley Airport - JBK , Berkeley , US "," Berlin Airport - BML , Berlin , US "," Bethel Airport - BET , Bethel , US "," Bethel City Landing Airport - JBT , Bethel city , US "," Bethpage Grumman Airport - BPA , Bethpage , US "," Bettles Airport - BTT , Bettles , US "," Beverly Airport - BVY , Beverly , US "," Big Bear City Airport - RBF , Big bear , US "," Big Creek Airport - BIC , Big creek , US "," Big Delta Intermediate Field Airport - BIG , Big delta , US "," Big Lake Airport - BGQ , Big lake , US "," Big Mountain Airport - BMX , Big mountain , US "," Big Piney-Marbleton Airport - BPI , Big piney-marbleton , US "," Big Rapids Airport - WBR , Big rapids , US "," Big Spring Howard County Airport - HCA , Big spring , US "," Billings Airport - BIL , Billings , US "," Biloxi Airport - BIX , Biloxi , US "," Binghamton Airport - BGM , Binghamton , US "," Birch Creek Airport - KBC , Birch creek , US "," Birmingham Airport - BHM , Birmingham , US "," Bisbee Municipal Airport - BSQ , Bisbee , US "," Bishop Airport - BIH , Bishop , US "," Bismarck Airport - BIS , Bismarck , US "," Blacksburg Virginia Tech Airport - BCB , Blacksburg , US "," Blackwell Airport - BWL , Blackwell , US "," Blaine Airport - BWS , Blaine , US "," Blairsville Airport - BSI , Blairsville , US "," Blakely Island Airport - BYW , Blakely island , US "," Blanding Airport - BDG , Blanding , US "," Block Island Airport - BID , Block island , US "," Bloomington Airport - BMG , Bloomington , US "," Bloomington-Normal Airport - BMI , Bloomington , US "," Blue Bell Wings Field Airport - BBX , Blue bell , US "," Blue Canyon Airport - BLU , Blue canyon , US "," Blue Fox Bay Airport - BFB , Blue fox bay , US "," Bluefield Princeton Airport - BLF , Bluefield , US "," Blythe Airport - BLH , Blythe , US "," Blytheville Municipal Airport - HKA , Blytheville , US "," Boca Raton Public Airport - BCT , Boca raton , US "," Bogalusa George R Carr Airport - BXA , Bogalusa , US "," Boise Air Term. (Gowen Field) Airport - BOI , Boise , US "," Boone Airport - BNW , Boone , US "," Borger Airport - BGD , Borger , US "," Bornite Upper Airport - RLU , Bornite , US "," Borrego Springs Airport - BXS , Borrego springs , US "," Boston Logan Int'l Airport - BOS , Boston , US "," Boswell Bay Airport - BSW , Boswell bay , US "," Boulder City Airport - BLD , Boulder city , US "," Boundary Airport - BYA , Boundary , US "," Bountiful Salt Lake Skypark Airport - BTF , Bountiful , US "," Bowling Green Camp A P Hill Airport - APH , Bowling green , US "," Bowling Green Warren County Airport - BWG , Bowling green , US "," Bowman Airport - BWM , Bowman , US "," Boxborough Airport - BXC , Boxborough , US "," Bozeman Gallatin Field Airport - BZN , Bozeman , US "," Bradford Airport - BFD , Bradford , US "," Bradford Rinkenberger Airport - BDF , Bradford , US "," Brady Curtis Field Airport - BBD , Brady , US "," Brainerd Crow Wing County Airport - BRD , Brainerd , US "," Brawley Airport - BWC , Brawley , US "," Brazoria Hinkles Ferry Airport - BZT , Brazoria , US "," Breckenridge Stephens County Airport - BKD , Breckenridge , US "," Bremerton Airport - PWT , Bremerton , US "," Bridgeport Igor I. Sikorsky Mem. Airport - BDR , Bridgeport , US "," Brigham City Airport - BMC , Brigham city , US "," BRISTOL - TRI , BRISTOL , US "," Britton Municipal Airport - TTO , Britton , US "," Broadus Airport - BDX , Broadus , US "," Broken Bow Airport - BBW , Broken bow , US "," Brookings Airport - BKX , Brookings , US "," Brookings State Airport - BOK , Brookings , US "," Brooks Lake Airport - BKF , Brooks lake , US "," Brooks Lodge Airport - RBH , Brooks lodge , US "," Broomfield Jeffco Airport - BJC , Broomfield , US "," Brownsville South Padre Is. Int'l Airport - BRO , Brownsville , US "," Brownwood Airport - BWD , Brownwood , US "," Brunswick  Airport - NHZ , Brunswick , US "," Bryan Coulter Field Airport - CFD , Bryan , US "," Bryce Airport - BCE , Bryce , US "," Buckeye Airport - BXK , Buckeye , US "," Buckland Airport - BKC , Buckland , US "," Buffalo Greater Buffalo Int'l Airport - BUF , Buffalo , US "," Buffalo Municipal Airport - BYG , Buffalo municipal , US "," Bullfrog Basin Airport - BFG , Bullfrog basin , US "," Burbank Airport - BUR , Burbank , US "," Burley Airport - BYI , Burley , US "," Burlington Airport - BBF , Burlington , US "," Burlington Airport - BRL , Burlington , US "," Burlington Int'l Airport - BTV , Burlington , US "," Burns Airport - BNO , Burns , US "," Burwell Municipal Airport - BUB , Burwell , US "," Butler Airport - BUM , Butler , US "," Butler Graham Field Airport - BTP , Butler airport , US "," Bartletts Airport - BSZ , Butte , US "," BUTTE - BTM , BUTTE , US "," Cabin Creek Airport - CBZ , Cabin creek , US "," Cadillac Airport - CAD , Cadillac , US "," Cairo Airport - CIR , Cairo , US "," Caldwell Wright Airport - CDW , Caldwell , US "," Calexico Int'l Airport - CXL , Calexico , US "," Calipatria Airport - CLR , Calipatria , US "," Callaway Gardens Airport - CWG , Callaway gardens , US "," Calverton Peconic River Airport - CTO , Calverton , US "," Cambridge Airport - CGE , Cambridge , US "," Camden Harrell Field Airport - CDH , Camden , US "," Camden Woodward Field Airport - CDN , Camden , US "," Camp Douglas Volk Field Airport - VOK , Camp douglas , US "," Campo Airport - CZZ , Campo , US "," Candle Airport - CDL , Candle , US "," Canon City Airport - CNE , Canon city , US "," Canton Airport - CTK , Canton , US "," Cape Girardeau Airport - CGI , Cape girardea , US "," Cape Lisburne Airport - LUR , Cape lisburne , US "," Wildwood Cape May County Airport - WWD , Cape may (wildwood) , US "," Cape Newenham Airport - EHM , Cape newenham , US "," Cape Pole Airport - CZP , Cape pole , US "," Cape Romanzof Airport - CZF , Cape romanzof , US "," Cape Spencer Airport - CSP , Cape spencer , US "," Carbondale Southern Illinois Airport - MDH , Carbondale , US "," Caribou Municipal Airport - CAR , Caribou , US "," Carlsbad Airport - CLD , Carlsbad , US "," Carlsbad Airport - CNM , Carlsbad , US "," Carrizo Springs Airport - CZT , Carrizo springs , US "," Carroll Airport - CIN , Carroll , US "," Carson City Airport - CSN , Carson city , US "," Casa Grande Municipal Airport - CGZ , Casa grande , US "," Cascade Locks/Stevens Airport - CZK , Cascade locks , US "," Casper Airport - CPR , Casper , US "," Cedar City Airport - CDC , Cedar city , US "," Cedar Key Lewis Airport - CDK , Cedar key , US "," Cedar Rapids Airport - CID , Cedar rapids , US "," Center Island Airport - CWS , Center island , US "," Centerville Municipal Airport - GHM , Centerville , US "," Central Airport - CEM , Central , US "," Centralia Municipal Airport - ENL , Centralia , US "," Chadron Airport - CDR , Chadron , US "," Chalkyitsik Airport - CIK , Chalkyitsik , US "," Challis Airport - CHL , Challis , US "," CHAMPAIGN URBANA - CMI , CHAMPAIGN URBANA , US "," Chandalar Airport - WCR , Chandalar , US "," Chandler Stellar Air Park Airport - SLJ , Chandler , US "," Chanute Martin Johnson Airport - CNU , Chanute , US "," Charles City Municipal Airport - CCY , Charles city , US "," Charleston Airport - CHS , Charleston , US "," Charleston Yeager Airport - CRW , Charleston , US "," Charlotte Douglas Airport - CLT , Charlotte , US "," Charlottesville Albemarle Airport - CHO , Charlottesville , US "," Chatham Airport - CYM , Chatham , US "," Chattanooga Lovell Field Airport - CHA , Chattanooga , US "," Chefornak Airport - CYF , Chefornak , US "," Chehalis Centralia Airport - CLS , Chehalis , US "," Chena Hot Springs Airport - CEX , Chena hot springs , US "," Cheraw Airport - HCW , Cheraw , US "," Cherokee Airport - CKA , Cherokee , US "," Cherokee Airport - CKK , Cherokee , US "," Chesapeake Huntington County Airport - HTW , Chesapeake , US "," Chevak Airport - VAK , Chevak , US "," Cheyenne Airport - CYS , Cheyenne , US "," CHICAGO - CHI , CHICAGO , US "," CHICAGO MIDWAY - MDW , CHICAGO , US "," OHARE INTERNATIONAL APT - ORD , CHICAGO , US "," Chickasha Municipal Airport - CHK , Chickasha , US "," Chicken Airport - CKX , Chicken , US "," Chico Airport - CIC , Chico , US "," Chignik Airport - KCQ , Chignik , US "," Chignik Bay Airport - KBW , Chignik bay , US "," Chignik Fisheries Airport - KCG , Chignik fisheries , US "," Chignik Lagoon Airport - KCL , Chignik lagoon , US "," Childress Airport - CDS , Childress , US "," Chiloquin State Airport - CHZ , Chiloquin , US "," Chincoteague Wallops Flight Center Airport - WAL , Chincoteague , US "," Chino Airport - CNO , Chino , US "," Chisana Field Airport - CZN , Chisana , US "," Chistochina Airport - CZO , Chistochina , US "," Chitina Airport - CXC , Chitina , US "," Chomley Airport - CIV , Chomley , US "," Chuathbaluk Airport - CHU , Chuathbaluk , US "," CINCINNATI NORTH KY INTL - CVG , CINCINNATI , US "," Circle City Airport - IRC , Circle city , US "," Circle Hot Springs Airport - CHP , Circle hot springs , US "," Claremont Municipal Airport - CNH , Claremont , US "," Clarinda Municipal Airport - ICL , Clarinda , US "," Clarks Point Airport - CLP , Clarks point , US "," Clarksburg Benedum Airport - CKB , Clarksburg , US "," Clarksdale Fletcher Field Airport - CKM , Clarksdale , US "," Clarksville Outlaw Field Airport - CKV , Clarksville , US "," Clayton Airport - CAO , Clayton , US "," Clear Lake Airport - CKE , Clear lake , US "," Clearlake Metroport Airport - CLC , Clearlake , US "," Executive Airport Clearwater - CLW , Clearwater , US "," Clemson Oconee County Airport - CEU , Clemson , US "," CLEVELAND HOPKINS INT APT - CLE , CLEVELAND , US "," Clifton Morenci Airport - CFT , Clifton , US "," Clinton Airport - CWI , Clinton , US "," Clinton Sampson County Airport - CTZ , Clinton , US "," Clintonville Airport - CLI , Clintonville , US "," Clovis Municipal Airport - CVN , Clovis , US "," Coalinga Airport - CLG , Coalinga , US "," Coatesville Chestercounty Carlson Airport - CTH , Coatesville , US "," Cocoa Merritt Island Airport - COI , Cocoa , US "," Cody/Yellowstone Regional Airport - COD , Cody , US "," Coeur D'Alene Airport - COE , Coeur dalene , US "," Coffee Point Airport - CFA , Coffee point , US "," Coffeyville Municipal Airport - CFV , Coffeyville , US "," Colby Municipal Airport - CBK , Colby , US "," Cold Bay Airport - CDB , Cold bay , US "," Coldfoot Airport - CXF , Coldfoot , US "," Coleman Airport - COM , Coleman , US "," College Park Airport - CGS , College park , US "," College Station Easterwood Field Airport - CLL , College station , US "," Colorado Creek Airport - KCR , Colorado creek , US "," Colorado Springs Peterson Field Airport - COS , Colorado springs , US "," COLUMBIA - CAE , COLUMBIA , US "," Columbia Airport - COA , Columbia , US "," Columbia Maury County Airport - MRC , Columbia , US "," Columbia Regional Airport - COU , Columbia , US "," Columbus Airport - CSG , Columbus , US "," Columbus Airport - OLU , Columbus , US "," Columbus Municipal Airport - CLU , Columbus , US "," Columbus Municipal Airport - CUS , Columbus , US "," PORT COLUMBUS INTL - CMH , COLUMBUS , US "," Compton Airport - CPM , Compton , US "," Concord Airport - CON , Concord , US "," Concord Buchanan Field Airport - CCR , Concord , US "," Concordia Blosser Municipal Airport - CNK , Concordia , US "," Connersville Mettle Field Airport - CEV , Connersville , US "," Conroe Montgomery Co Airport - CXO , Conroe , US "," Cooper Lodge Quartz Creek Airport - JLA , Cooper landing , US "," Cooperstown Airport - COP , Cooperstown , US "," Copper Centre Airport - CZC , Copper centre , US "," Corcoran Airport - CRO , Corcoran , US "," Cordova Mile 13 Field Airport - CDV , Cordova , US "," Cordova City Airport - CKU , Cordova city , US "," Corinth Roscoe Turner Airport - CRX , Corinth , US "," Corner Bay Airport - CBA , Corner bay , US "," CORPUS CHRISTI - CRP , CORPUS CHRISTI , US "," Corsicana Airport - CRS , Corsicana , US "," Cortez Montezuma County Airport - CEZ , Cortez-montezuma , US "," Cortland Airport - CTX , Cortland , US "," Corvallis Airport - CVO , Corvallis , US "," Cottonwood Airport - CTW , Cottonwood , US "," Cotulla Airport - COT , Cotulla , US "," Council Bluffs Municipal Airport - CBF , Council bluffs , US "," Council Melsing Creek Airport - CIL , Council melsing creek , US "," Craig-Moffat Airport - CIG , Craig-moffat , US "," Crane Crane County Airport - CCG , Crane , US "," Crane Island Airport - CKR , Crane island , US "," Crescent City Mc Namara Field Airport - CEC , Crescent city , US "," Crested Butte Airport - CSE , Crested butte , US "," Creston Municipal Airport - CSQ , Creston , US "," Crestview Bob Sikes Airport - CEW , Crestview , US "," Crooked Creek Airport - CKD , Crooked creek , US "," Crookston Municipal Airport - CKN , Crookston , US "," Cross City Airport - CTY , Cross city , US "," Crossett Municipal Airport - CRT , Crossett , US "," Crossville Memorial Airport - CSV , Crossville , US "," Crows Landing Aux Field Airport - NRC , Crows landing , US "," Crystal Lake Airport - CYE , Crystal lake , US "," Cube Cove Airport - CUW , Cube cove , US "," Culver City Hughes Airport - CVR , Culver city , US "," Cumberland Wiley Ford Airport - CBE , Cumberland , US "," Cushing Municipal Airport - CUH , Cushing , US "," Cut Bank Airport - CTB , Cut bank , US "," Daggett Barstow-Daggett Airport - DAG , Daggett , US "," Dahl Creek Airport - DCK , Dahl creek , US "," Dahlgren Airport - DGN , Dahlgren , US "," Dalhart Airport - DHT , Dalhart , US "," Dallas Fort Worth Int'l Airport - DFW , Dallas , US "," Dallas Love Field Airport - DAL , Dallas , US "," Dallas North Airport - DNE , Dallas , US "," Dallas Redbird Airport - RBD , Dallas , US "," Dallas Addison Airport - ADS , Dallas addison , US "," Dalton Municipal Airport - DNN , Dalton , US "," Sparta Community Airport - SAR , Dammam , US "," Danbury Airport - DXR , Danbury , US "," Danger Bay Airport - DGB , Danger bay , US "," Dansville Airport - DSV , Dansville , US "," Danville Municipal Airport - DAN , Danville , US "," Danville Vermilion County Airport - DNV , Danville , US "," Davenport Airport - DVN , Davenport , US "," Dayton James Cox Dayton Int'l Airport - DAY , Dayton , US "," Daytona Beach Regional Airport - DAB , Daytona beach , US "," De Ridder Beauregard Parish Airport - DRI , De ridder , US "," Dearborn Airport - DEO , Dearborn , US "," Death Valley Airport - DTH , Death valley , US "," Decatur Decatur Airport - DEC , Decatur , US "," Decatur Decatur Hi-Way Airport - DCR , Decatur , US "," Decatur Pyor Airport - DCU , Decatur , US "," Decatur Island Airport - DTR , Decatur island , US "," Decorah Municipal Airport - DEH , Decorah , US "," Deep Bay Airport - WDB , Deep bay , US "," Deer Park Airport - DPK , Deer park , US "," Deering Airport - DRG , Deering , US "," Defiance Memorial Airport - DFI , Defiance , US "," Del Rio Int'l Airport - DRT , Del rio , US "," Delta Airport - DTA , Delta , US "," Delta Junction Airport - DJN , Delta , US "," Deming Airport - DMN , Deming , US "," Denison Municipal Airport - DNS , Denison , US "," Denver Int'l Airport - DEN , Denver , US "," Denver Arapahoe Co Airport - APA , Denver arapahoe , US "," Des Moines Airport - DSM , Des moines , US "," Destin Airport - DSI , Destin , US "," Detroit City Airport - DET , Detroit , US "," Detroit Metropolitan Area - DTT , Detroit , US "," Detroit Wayne County Airport - DTW , Detroit , US "," Detroit Lakes Municipal Airport - DTL , Detroit lakes , US "," Devils Lake Airport - DVL , Devils lake , US "," Dickinson Airport - DIK , Dickinson , US "," Dillingham Municipal Airport - DLG , Dillingham , US "," Dillon Airport - DLL , Dillon , US "," Dillon Airport - DLN , Dillon , US "," Diomede Island Airport - DIO , Diomede island , US "," Dodge City Municipal Airport - DDC , Dodge city , US "," Dolomi Airport - DLO , Dolomi , US "," Dora Bay Airport - DOF , Dora bay , US "," Dothan Airport - DHN , Dothan , US "," Douglas Converse County Airport - DGW , Douglas , US "," Dover Airport - DVX , Dover , US "," Doylestown Airport - DYL , Doylestown , US "," Drift River Airport - DRF , Drift river , US "," Drummond Airport - DRU , Drummond , US "," Drummond Island Airport - DRE , Drummond island , US "," Dublin Municipal Airport - DBN , Dublin , US "," Dublin New River Valley Airport - PSK , Dublin , US "," Dubois Airport - DBS , Dubois , US "," Dubois Jefferson County Airport - DUJ , Dubois , US "," Dubuque Municipal Airport - DBQ , Dubuque , US "," Duck Pine Island Airport - DUF , Duck pine island , US "," Dugway Airport - DPG , Dugway , US "," Duluth Int'l Airport - DLH , Duluth , US "," Duncan Halliburton Airport - DUC , Duncan , US "," Dunkirk Airport - DKK , Dunkirk , US "," Durant Eaker Airport - DUA , Durant , US "," Eagle Airport - EAA , Eagle , US "," Eagle Lake Airport - ELA , Eagle lake , US "," Eagle Pass Maverick Co Airport - EGP , Eagle pass , US "," Eagle River Airport - EGV , Eagle river , US "," East Fork Airport - EFO , East fork , US "," East Hampton Airport - HTO , East hampton , US "," East Hartford Rentschler Airport - EHT , East hartford , US "," East Stroudsburg Birchwood-Pocono Airport - ESP , East stroudsburg , US "," East Tawas Emmet County Airport - ECA , East tawas , US "," Eastland Municipal Airport - ETN , Eastland , US "," Easton Airport - ESN , Easton , US "," Easton State Airport - ESW , Easton , US "," Eastsound Orcas Island Airport - ESD , Eastsound , US "," Eau Claire Airport - EAU , Eau claire , US "," Edenton Municipal Airport - EDE , Edenton , US "," Edgewood Airport - EDG , Edgewood , US "," Edna Bay Airport - EDA , Edna bay , US "," Edwards AFB Airport - EDW , Edwards afb , US "," Eek Airport - EEK , Eek , US "," Egegik Airport - EGX , Egegik , US "," Ekuk Airport - KKU , Ekuk , US "," Ekwok Airport - KEK , Ekwok , US "," El Cajon Airport - CJN , El cajon , US "," El Calafate  Airport - FTE , El calafate , US "," El Dorado Airport - EDK , El dorado , US "," El Dorado Goodwin Field Airport - ELD , El dorado , US "," El Monte Airport - EMT , El monte , US "," El Paso Int'l Airport - ELP , El paso , US "," Eldred Rock Airport - ERO , Eldred rock , US "," Elim Airport - ELI , Elim , US "," Elizabeth City Airport - ECG , Elizabeth city , US "," Elizabethtown Airport - EKX , Elizabethtown , US "," Elk City Municipal Airport - ELK , Elk city , US "," Elkhart Municipal Airport - EKI , Elkhart , US "," Elkins Airport - EKN , Elkins , US "," Elko Airport - EKO , Elko , US "," Ellamar Airport - ELW , Ellamar , US "," Ellensburg Bowers Field Airport - ELN , Ellensburg , US "," Elmira Corning Airport - ELM , Elmira , US "," Ely Airport - LYU , Ely , US "," Ely Yelland Airport - ELY , Ely , US "," Emmonak Airport - EMK , Emmonak , US "," Emporia Airport - EMP , Emporia , US "," English Bay Airport - KEB , English bay , US "," Enid Woodring Mun. Airport - WDG , Enid woodring , US "," Enterprise Municipal Airport - ETS , Enterprise , US "," Ephrata Airport - EPH , Ephrata , US "," Erie Int'l Airport - ERI , Erie , US "," Errol Airport - ERR , Errol , US "," Escanaba Delta County Airport - ESC , Escanaba , US "," Espanola Airport - ESO , Espanola , US "," Estherville Municipal Airport - EST , Estherville , US "," Eufaula Weedon Field Airport - EUF , Eufaula , US "," Eugene Airport - EUG , Eugene , US "," Eunice Airport - UCE , Eunice , US "," ARCATA EUREKA APT - ACV , EUREKA , US "," Eureka Airport - EUE , Eureka , US "," Evadale Landing Strip Airport - EVA , Evadale , US "," Evanston Airport - EVW , Evanston , US "," Evansville Dress Regional Airport - EVV , Evansville , US "," Eveleth Airport - EVM , Eveleth , US "," Everett Snohomish County Airport - PAE , Everett , US "," Excursion Inlet Airport - EXI , Excursion inlet , US "," FAIRBANKS - FAI , FAIRBANKS , US "," Fairbury Municipal Airport - FBY , Fairbury , US "," Fairfield Airport - SUU , Fairfield , US "," Fairfield Municipal Airport - FFL , Fairfield , US "," Fairmont Airport - FRM , Fairmont , US "," Fallon Municipal Airport - FLX , Fallon , US "," Falls Bay Airport - FLJ , Falls bay , US "," False Island Airport - FAK , False island , US "," False Pass Airport - KFP , False pass , US "," Farewell Airport - FWL , Farewell , US "," Fargo Hector Field Airport - FAR , Fargo , US "," Faribault Municipal Airport - FBL , Faribault , US "," Farmingdale Republic Field Airport - FRG , Farmingdale , US "," Farmington Municipal Airport - FMN , Farmington , US "," Farmington Regional Airport - FAM , Farmington , US "," Fayetteville Airport - XNA , Fayetteville , US "," Fayetteville Municipal Airport - FAY , Fayetteville , US "," Fayetteville Municipal Airport - FYM , Fayetteville , US "," Fergus Falls Airport - FFM , Fergus falls , US "," Fillmore Municipal Airport - FIL , Fillmore , US "," Fin Creek Airport - FNK , Fin creek , US "," Findlay Airport - FDY , Findlay , US "," Friday Harbor Airport - FRD , Firday harbor , US "," Fire Cove Airport - FIC , Fire cove , US "," Fishers Island Elizabeth Field Airport - FID , Fishers island , US "," Five Finger Airport - FIV , Five finger , US "," Five Mile Airport - FMC , Five mile , US "," Flagstaff Pulliam Field Airport - FLG , Flagstaff , US "," Flat Airport - FLT , Flat , US "," Flaxman Island Airport - FXM , Flaxman island , US "," Flint Bishop Airport - FNT , Flint , US "," Flippin Airport - FLP , Flippin , US "," Florence Airport - FLO , Florence , US "," Foley Barin Olf Osn Airport - NHX , Foley , US "," Fond du Lac Airport - FLD , Fond du lac , US "," Forest City Municipal Airport - FXY , Forest city , US "," Forest Park Airport - FOP , Forest park   , US "," Forrest City Municipal Airport - FCY , Forrest city , US "," Fort Belvoir Airport - DAA , Fort belvoir , US "," Fort Bragg Airport - FBG , Fort bragg , US "," Fort Bragg Airport - FOB , Fort bragg , US "," Fort Bridger Airport - FBR , Fort bridger , US "," Fort Chaffee Airport - CCA , Fort chaffee , US "," Fort Collins/Loveland Municipal Air Airport - FNL , Fort collins , US "," Fort Dix Airport - WRI , Fort dix , US "," Fort Eustis Airport - FAF , Fort eustis , US "," Fort Indiantown  Airport - MUI , Fort indiantown , US "," Fort Irwin Airport - BYS , Fort irwin , US "," Fort Jefferson Airport - RBN , Fort jefferson , US "," Fort Leavenworth Airport - FLV , Fort leavenworth , US "," Fort Leonard Wood Airport - TBN , Fort leonard , US "," Fort Madison Municipal Airport - FMS , Fort madison , US "," Fort Meade Airport - FME , Fort meade , US "," Fort Pierce St. Lucie County Airport - FPR , Fort pierce , US "," Fort Polk  Airport - POE , Fort polk , US "," Fort Richardson Airport - FRN , Fort richardson , US "," Fort Riley Airport - FRI , Fort riley , US "," Fort Scott Municipal Airport - FSK , Fort scott , US "," Fort Sheridan Airport - FSN , Fort sheridan , US "," Fort Sill Airport - FSI , Fort sill , US "," Fort Smith Municipal Airport - FSM , Fort smith , US "," Fort Stockton Pecos County Airport - FST , Fort stockton , US "," Fort Sumner Airport - FSU , Fort sumner , US "," Valparaiso Fort Walton Beach Airport - VPS , Fort walton beach , US "," Fort Yukon Airport - FYU , Fort yukon , US "," Fortuna Ledge Airport - FTL , Fortuna ledge , US "," Fox Airport - FOX , Fox , US "," Frankfort Capital City Airport - FFT , Frankfort , US "," Franklin Chess-Lambertin Airport - FKL , Franklin , US "," Franklin Municipal Airport - FKN , Franklin , US "," Frederick Municipal Airport - FDK , Frederick , US "," Frederick Municipal Airport - FDR , Frederick , US "," Freeport Albertus Airport - FEP , Freeport , US "," Fremont Municipal Airport - FET , Fremont , US "," French Lick Municipal Airport - FRH , French lick , US "," Frenchville Airport - WFK , Frenchville , US "," Fresh Water Bay Airport - FRP , Fresh water bay , US "," Friday Harbor SPB Airport - FBS , Friday harbor spb , US "," Front Royal Warren County Airport - FRR , Front royal , US "," Fryeburg Airport - FRY , Fryeburg , US "," FT. LAUDERDALE INTL - FLL , Ft. lauderdale , US "," FT.MYERS - FMY , Ft.myers , US "," FT.WAYNE - FWA , Ft.wayne , US "," Fullerton Municipal Airport - FUL , Fullerton , US "," Funter Bay Airport - FNR , Funter bay , US "," Gabbs Airport - GAB , Gabbs , US "," Gadsden Municipal Airport - GAD , Gadsden , US "," Gage Airport - GAG , Gage , US "," Gainesville J R Alison Municipal Airport - GNV , Gainesville , US "," Gainesville Lee Gilmer Memorial Airport - GVL , Gainesville , US "," Gainesville Municipal Airport - GLE , Gainesville , US "," Gaithersburg Montgomery County Airport - GAI , Gaithersburg , US "," Gakona Airport - GAK , Gakona , US "," Galbraith Lake Airport - GBH , Galbraith lake , US "," Galena Airport - GAL , Galena , US "," Galesburg Airport - GBG , Galesburg , US "," Galion Airport - GQQ , Galion , US "," Gallup Senator Clark Airport - GUP , Gallup , US "," Galveston Scholes Field Airport - GLS , Galveston , US "," Gambell Airport - GAM , Gambell , US "," Ganes Creek Airport - GEK , Ganes creek , US "," Garden City Municipal Airport - GCK , Garden city , US "," Gardner Municipal Airport - GDM , Gardner , US "," Gary Regional Airport - GYY , Gary , US "," Gatlinburg Airport - GKT , Gatlinburg , US "," Gaylord Otsego County Airport - GLR , Gaylord , US "," Georgetown Airport - GGE , Georgetown , US "," Georgetown Sussex County Airport - GED , Georgetown , US "," Gettysburg Airport - GTY , Gettysburg , US "," Gillette Campbell County Airport - GCC , Gillette , US "," Glacier Creek Airport - KGZ , Glacier creek , US "," Gladwin Airport - GDW , Gladwin , US "," Glasgow Int'l Airport - GGW , Glasgow , US "," Glasgow Municipal Airport - GLW , Glasgow , US "," Glendale Airport - GWV , Glendale , US "," Glendive Dawson Community Airport - GDV , Glendive , US "," Glennallen Airport - GLQ , Glennallen , US "," Glens Falls Warren County Airport - GFL , Glens falls , US "," Glenview  Airport - NBU , Glenview , US "," Glenwood Springs Airport - GWS , Glenwood springs , US "," Gold Beach State Airport - GOL , Gold beach , US "," Golden Horn  Airport - GDH , Golden horn , US "," Goldsboro  Airport - GSB , Goldsboro , US "," Golovin Airport - GLV , Golovin , US "," Gooding Airport - GNG , Gooding , US "," Goodland Renner Field Airport - GLD , Goodland , US "," Goodnews Bay Airport - GNU , Goodnews bay , US "," Goodyear Litchfield Airport - GYR , Goodyear , US "," Gordon Airport - GRN , Gordon , US "," Gordonsville Municipal Airport - GVE , Gordonsville , US "," Goshen Airport - GSH , Goshen , US "," Grand Forks Airport - GFK , Grand forks , US "," Grand Island Airport - GRI , Grand island , US "," Grand Junction Walker Field Airport - GJT , Grand junction , US "," Grand Marais Devils Track Airport - GRM , Grand marais , US "," Grand Rapids (Gerald R Ford Intl Airport) - GRR , Grand rapids , US "," Grand Rapids Airport - GPZ , Grand rapids , US "," Grandview Richards-Gebaur Airport - GVW , Grandview , US "," Granite Mountain Airport - GMT , Granite , US "," Grants Milan Airport - GNT , Grants , US "," Grantsburg Municipal Airport - GTG , Grantsburg , US "," Grayling Airport - KGX , Grayling , US "," Great Barrington Airport - GBR , Great barrington , US "," Great Bend Airport - GBD , Great bend , US "," Great Falls Int'l Airport - GTF , Great falls , US "," Greeley Weld County Airport - GXY , Greeley , US "," Green Bay Austin-Straubel Field Airport - GRB , Green bay , US "," Green River Airport - RVR , Green river , US "," Greenfield Pope Field Airport - GFD , Greenfield , US "," GREENSBORO HIGH POINT - GSO , GREENSBORO HIGH POINT , US "," Greenville Airport - GLH , Greenville , US "," Greenville Downtown Airport - GMU , Greenville , US "," Greenville Majors Field Airport - GVT , Greenville , US "," Greenville Municipal Airport - GCY , Greenville , US "," Greenville Municipal Airport - GRE , Greenville , US "," Greenville Pitt-Greenville Airport - PGV , Greenville , US "," Greenwood Airport - GRD , Greenwood , US "," Greenwood Leflore Airport - GWO , Greenwood , US "," GREER - GSP , GREER , US "," Greybull South Big Horn County Airport - GEY , Greybull , US "," Guam Agana Field Airport - GUM , Guam , US "," Gulf Shores Edwards Airport - GUF , Gulf shores , US "," Gulkana Airport - GKN , Gulkana , US "," Gunnison Airport - GUC , Gunnison , US "," Gustavus Airport - GST , Gustavus , US "," Guthrie Airport - GOK , Guthrie , US "," Guymon Airport - GUY , Guymon , US "," Hagerstown MD Washington Cnty Regio Airport - HGR , Hagerstown , US "," Haines Municipal Airport - HNS , Haines , US "," Half Moon Airport - HAF , Half moon , US "," Hamilton Airport - HAO , Hamilton , US "," Hamilton Marion County Airport - HAB , Hamilton , US "," Hampton Municipal Airport - HPT , Hampton , US "," Hana Airport - HNM , Hana , US "," Kauai Island Princeville Airport - HPV , Hanalei , US "," Hanapepe Port Allen Airport - PAK , Hanapepe , US "," Hancock Houghton County Airport - CMX , Hancock , US "," Hanksville Intermediate Airport - HVE , Hanksville , US "," Hanna Airport - HNX , Hanna , US "," Hanus Bay Airport - HBC , Hanus bay , US "," Harlingen Valley Int'l Airport - HRL , Harlingen , US "," Harrisburg Raleigh Airport - HSB , Harrisburg , US "," Harrison Boone County Airport - HRO , Harrison , US "," BRADLEY INTL APT - BDL , HARTFORD , US "," HARTFORD - HFD , HARTFORD , US "," Hartford Barnes Airport - BNH , Hartford barnes , US "," Hartsville Municipal Airport - HVS , Hartsville , US "," Hastings Airport - HSI , Hastings , US "," Hatteras Airport - HNC , Hatteras , US "," Hattiesburg Bobby L. Chain Mun. Airport - HBG , Hattiesburg , US "," Havasupai Airport - HAE , Havasupai , US "," Havre City County Airport - HVR , Havre city , US "," Hawk Inlet  Airport - HWI , Hawk inlet , US "," Hawthorne Airport - HHR , Hawthorne , US "," Hawthorne Airport - HTH , Hawthorne , US "," Haycock Airport - HAY , Haycock , US "," Hayden Yampa Valley Airport - HDN , Hayden , US "," Hays Municipal Airport - HYS , Hays , US "," Hayward Air Terminal Airport - HWD , Hayward , US "," Hayward Municipal Airport - HYR , Hayward , US "," Hazleton Airport - HZL , Hazleton , US "," Healy Lake Airport - HKB , Healy lake , US "," Helena Airport - HLN , Helena , US "," Helena Thompson-Robbins Airport - HEE , Helena , US "," Hemet Ryan Field Airport - HMT , Hemet , US "," Herendeen Airport - HED , Herendeen , US "," Herlong Airport - AHC , Herlong , US "," Hermiston State Airport - HES , Hermiston , US "," Hickory Airport - HKY , Hickory , US "," Hidden Falls Airport - HDA , Hidden falls , US "," Hill City Airport - HLC , Hill city , US "," Hillsboro Portland Airport - HIO , Hillsboro , US "," Hilo Int'l Airport - ITO , Hilo , US "," Hilton Head Airport - HHH , Hilton head , US "," Hinesville  Airport - LIY , Hinesville , US "," Hobart Airport - HBR , Hobart , US "," Hobart Bay Airport - HBH , Hobart bay , US "," Hoffman  Airport - HFF , Hoffman , US "," Hogatza Airport - HGZ , Hogatza , US "," Holdrege Brewster Field Airport - HDE , Holdrege , US "," Holikachu Airport - HOL , Holikachu , US "," Holland Park Township Airport - HLM , Holland , US "," Hollis  Airport - HYL , Hollis , US "," Hollister Airport - HLI , Hollister , US "," Hollywood North Perry Airport - HWO , Hollywood , US "," Holy Cross Airport - HCR , Holy cross , US "," Homer Airport - HOM , Homer , US "," Homeshore Airport - HMS , Homeshore , US "," Homestead  Airport - HST , Homestead , US "," Honolulu Int'l Airport - HNL , Honolulu , US "," Hoonah Airport - HNH , Hoonah , US "," Hooper Bay Airport - HPB , Hooper bay , US "," Hopkinsville  Airport - HOP , Hopkinsville , US "," Hot Springs Ingalls Field Airport - HSP , Hot springs , US "," Hot Springs Memorial Field Airport - HOT , Hot springs , US "," Houghton Roscommon County Airport - HTL , Houghton , US "," Houlton Int'l Airport - HUL , Houlton , US "," Houma Terrebonne Airport - HUM , Houma , US "," Ellington Field Airport - EFD , Houston , US "," George Bush Intercontinental Airport - IAH , Houston , US "," Houston Airports - HOU , Houston , US "," Hudson Columbia County Airport - HCC , Hudson , US "," Hughes Municipal Airport - HUS , Hughes , US "," Hugo Airport - HUJ , Hugo , US "," Humboldt Airport - HUD , Humboldt , US "," Humboldt Municipal Airport - HBO , Humboldt , US "," Huntingburg Municipal Airport - HNB , Huntingburg , US "," Huntington Airport - HTS , Huntington , US "," Huntsville Airport - HTV , Huntsville , US "," Huntsville International Airport - HSV , Huntsville , US "," Huron Howes Airport - HON , Huron , US "," Huslia Airport - HSL , Huslia , US "," Hutchison Airport - HUT , Hutchison , US "," Hyannis Barnstable Airport - HYA , Hyannis , US "," Hydaburg  Airport - HYG , Hydaburg , US "," Icy Bay Airport - ICY , Icy bay , US "," Ida Grove Municipal Airport - IDG , Ida grove , US "," Igiugig Airport - IGG , Igiugig , US "," Iliamna Airport - ILI , Iliamna , US "," Immokalee Airport - IMM , Immokalee , US "," Imperial Airport - IML , Imperial , US "," Imperial Beach  Airport - NRS , Imperial beach , US "," Independence Airport - IDP , Independence , US "," Indian Springs Af Aux Airport - INS , Indian springs , US "," Indiana Airport - IDI , Indiana , US "," Indianapolis Int'l Airport - IND , Indianapolis , US "," International Falls Int'l Airport - INL , International falls , US "," Iowa City Airport - IOW , Iowa city , US "," Iowa Falls Airport - IFA , Iowa falls , US "," Iraan Municipal Airport - IRB , Iraan , US "," Iron Mountain Ford Airport - IMT , Iron mountain , US "," Ironwood Gogebic County Airport - IWD , Ironwood , US "," Isabel Pass Airport - ISL , Isabel pass , US "," Islip Long Island Macarthur Airport - ISP , Islip , US "," Ithaca Tompkins County Airport - ITH , Ithaca , US "," Ivanof Bay Airport - KIB , Ivanof bay , US "," Ivishak Airport - IVH , Ivishak , US "," Jackpot Airport - KPT , Jackpot , US "," JACKSON - JAN , JACKSON , US "," Jackson Airport - MJQ , Jackson , US "," Jackson McKellar Airport - MKL , Jackson , US "," Jackson Reynolds Municipal Airport - JXN , Jackson , US "," JACKSONVILLE - JAX , JACKSONVILLE , US "," Jacksonville  Airport - LRF , Jacksonville , US "," Jacksonville Airport - JKV , Jacksonville , US "," Jacksonville Albert J Ellis Airport - OAJ , Jacksonville , US "," Jacksonville Municipal Airport - IJX , Jacksonville , US "," Jaffrey Municipal Airport - AFN , Jaffrey , US "," Jamestown Airport - JHW , Jamestown , US "," Jamestown Airport - JMS , Jamestown , US "," Janesville Rock County Airport - JVL , Janesville , US "," Jasper County Airport - JAS , Jasper , US "," Jasper Marion County Airport - APT , Jasper , US "," Jefferson Ashtabula Airport - JFN , Jefferson , US "," Jefferson Municipal Airport - EFW , Jefferson , US "," Jefferson City Memorial Airport - JEF , Jefferson city , US "," John Day Airport - JDA , John day , US "," Johnson Airport - JCY , Johnson , US "," Johnstown Cambria County Airport - JST , Johnstown , US "," Joliet Municipal Airport - JOT , Joliet , US "," Jolon  Airport - HGT , Jolon , US "," Jonesboro Airport - JBR , Jonesboro , US "," Joplin Airport - JLN , Joplin , US "," Jordan Airport - JDN , Jordan , US "," Junction Kimble County Airport - JCT , Junction , US "," Juneau Dodge County Airport - UNU , Juneau , US "," Juneau Int'l Airport - JNU , Juneau , US "," Kagvik Creek Airport - KKF , Kagvik creek , US "," Kahului Airport - OGG , Kahului , US "," Kaiser/Lake Ozark Lee C Fine Memori Airport - AIZ , Kaiser/lake ozark , US "," Kake Airport - KAE , Kake , US "," Kakhonak Airport - KNK , Kakhonak , US "," Kalakaket Airport - KKK , Kalakaket , US "," Kalamazoo Battle Creek Int'l Airport - AZO , Kalamazoo , US "," Kalaupapa Airport - LUP , Kalaupapa , US "," KALISPELL - GPI , Kalispell , US "," Kalispell Glacier National Park Airport - FCA , Kalispell , US "," Kalskag Municipal Airport - KLG , Kalskag , US "," Kaltag Airport - KAL , Kaltag , US "," Kamuela Airport - MUE , Kamuela , US "," Kanab Airport - KNB , Kanab , US "," Kankakee Greater Kankakee Airport - IKK , Kankakee , US "," KANSAS CITY - MCI , KANSAS CITY , US "," KANSAS CITY - MKC , KANSAS CITY , US "," Kansas City Fairfax Municipal Airport - KCK , Kansas city , US "," Karluk Airport - KYK , Karluk , US "," Karluk Lake Airport - KKL , Karluk lake , US "," Kasaan  Airport - KXA , Kasaan , US "," Kasigluk Airport - KUK , Kasigluk , US "," Kavik Airstrip Airport - VIK , Kavik , US "," Kayenta Monument Valley Airport - MVM , Kayenta , US "," Kearney Airport - EAR , Kearney , US "," Keene Airport - EEN , Keene , US "," Kekaha Barking Sands Airport - BKH , Kekaha , US "," Kelly Bar Airport - KEU , Kelly bar , US "," Kelp Bay Airport - KLP , Kelp bay , US "," Kelso Longview Airport - KLS , Kelso , US "," Kemerer Airport - EMM , Kemerer , US "," Kenai Airport - ENA , Kenai , US "," Kenmore Air Harbor Airport - KEH , Kenmore , US "," Kennett Municipal Airport - KNT , Kennett , US "," Kenosha Municipal Airport - ENW , Kenosha , US "," Kentland Airport - KKT , Kentland , US "," Keokuk Airport - EOK , Keokuk , US "," Kerrville Airport - ERV , Kerrville , US "," Ketchikan Int'l Airport - KTN , Ketchikan , US "," Key Largo Port Largo Airport - KYL , Key largo , US "," Key West Int'l Airport - EYW , Key west , US "," Kiana Bob Barker Memorial Airport - IAN , Kiana , US "," Kilimanjaro Airport - JAR , Kilimanjaro , US "," Kill Devil Hills First Flight Airport - FFA , Kill devil hills , US "," KILLEEN - GRK , KILLEEN , US "," KILLEEN - ILE , KILLEEN , US "," King City Mesa Del Rey Airport - KIC , King city , US "," King Cove Airport - KVC , King cove , US "," King Of Prussia Airport - KPD , King of prussia , US "," King Salmon Airport - AKN , King salmon , US "," Kingman Airport - IGM , Kingman , US "," Kingsville  Airport - NQI , Kingsville , US "," Kinston Stallings Field Airport - ISO , Kinston , US "," Kipnuk Airport - KPN , Kipnuk , US "," Kirksville Municipal Airport - IRK , Kirksville , US "," Kissimmee Municipal Airport - ISM , Kissimmee , US "," Kitoi Bay Airport - KKB , Kitoi bay , US "," Kivalina Airport - KVL , Kivalina , US "," Kizhuyak Airport - KZH , Kizhuyak , US "," Klag Bay Airport - KBK , Klag bay , US "," Klamath Falls Kingsley Field Airport - LMT , Klamath falls , US "," Klawock Airport - KLW , Klawock , US "," Knoxville Mc Ghee Tyson Airport - TYS , Knoxville , US "," Kobuk/Wien Airport - OBU , Kobuk , US "," Kokomo Airport - OKK , Kokomo , US "," Kongiganak Airport - KKH , Kongiganak , US "," Kosciusko Attala County Airport - OSX , Kosciusko , US "," Kotlik Airport - KOT , Kotlik , US "," Kotzebue Airport - OTZ , Kotzebue , US "," Koyuk Airport - KKA , Koyuk , US "," Koyukuk Airport - KYU , Koyukuk , US "," Kugururok River Airport - KUW , Kugururok river , US "," Kulik Lake Airport - LKK , Kulik , US "," Kuparuk Airport - UUK , Kuparuk , US "," Kwethluk Airport - KWT , Kwethluk , US "," Kwigillingok Airport - KWK , Kwigillingok , US "," La Crosse Municipal Airport - LSE , La crosse , US "," La Grande Airport - LGD , La grande , US "," La Grange Calloway Airport - LGC , La grange , US "," La Verne Brackett Field Airport - POC , La verne , US "," Labouchere Bay Airport - WLB , Labouchere bay , US "," Laconia Municipal Airport - LCI , Laconia , US "," Lafayette Airport - LFT , Lafayette , US "," Lafayette Purdue University Airport - LAF , Lafayette , US "," Lake Charles Municipal Airport - LCH , Lake charles , US "," Lake Geneva Municipal Airport - XES , Lake geneva , US "," Lake Jackson Brazoria County Airport - LJN , Lake jackson , US "," Lake Minchumina Airport - LMA , Lake minchumina , US "," Lake Placid Airport - LKP , Lake placid , US "," Lakehurst Naec Airport - NEL , Lakehurst , US "," Lakeland Municipal Airport - LAL , Lakeland , US "," Lakeside Airport - LKS , Lakeside , US "," Lakeview Lake County Airport - LKV , Lakeview , US "," Lamar Field Airport - LAA , Lamar , US "," Lanai City Airport - LNY , Lanai city , US "," Lancaster Airport - LNS , Lancaster , US "," Lancaster Quartz Hill Airport - RZH , Lancaster , US "," Lancaster William J Fox Airport - WJF , Lancaster/palmdale , US "," Lander Hunt Field Airport - LND , Lander , US "," Lansing Capital City Airport - LAN , Lansing , US "," Laporte Municipal Airport - LPO , Laporte , US "," Laramie General Brees Field Airport - LAR , Laramie , US "," Laredo Int'l Airport - LRD , Laredo , US "," Larsen Bay Airport - KLN , Larsen bay , US "," Las Cruces Municipal Airport - LRU , Las cruces , US "," Las Vegas Airport - LVS , Las vegas , US "," MCCARRAN INTL - LAS , LAS VEGAS , US "," Lathrop  Airport - LRO , Lathrop , US "," Lathrop Wells Airport - LTH , Lathrop , US "," Latrobe Westmoreland County Airport - LBE , Latrobe , US "," Laurel Hesler-Noble Field Airport - LUL , Laurel , US "," Lawrence Airport - LWC , Lawrence , US "," Lawrence Airport - LWM , Lawrence , US "," Lawrenceville Airport - LVL , Lawrenceville , US "," Lawrenceville Municipal Airport - LWV , Lawrenceville , US "," Lawton Municipal Airport - LAW , Lawton , US "," Leadville Airport - LXV , Leadville , US "," Lebanon Airport - LEB , Lebanon , US "," Leesburg Airport - LEE , Leesburg , US "," Lemars Municipal Airport - LRJ , Lemars , US "," Lemmon Airport - LEM , Lemmon , US "," Lemoore  Airport - NLC , Lemoore , US "," Leonardtown St. Mary's County Airport - LTW , Leonardtown , US "," Levelock Airport - KLL , Levelock , US "," Lewisburg Greenbrier Valley Airport - LWB , Lewisburg , US "," Lewiston Nez Perce County Rgnl Airport - LWS , Lewiston , US "," Lewistown Municipal Airport - LWT , Lewistown , US "," Lexington Airport - LXN , Lexington , US "," Lexington Blue Grass Airport - LEX , Lexington , US "," Liberal Municipal Airport - LBL , Liberal , US "," Kauai Island Lihue Airport - LIH , Lihue , US "," Lima Allen County Airport - AOH , Lima allen county , US "," Lime Village Airport - LVD , Lime village , US "," Limestone  Airport - LIZ , Limestone , US "," Limon Municipal Airport - LIC , Limon , US "," Lincoln Municipal Airport - LNK , Lincoln , US "," Lincoln Rock  Airport - LRK , Lincoln rock , US "," Linden Airport - LDJ , Linden , US "," Little Naukati Airport - WLN , Little naukati , US "," Little Port Walter Airport - LPW , Little port walter , US "," Little Rock Regional Airport - LIT , Little rock , US "," Livengood Airport - LIV , Livengood , US "," Livermore Airport - LVK , Livermore , US "," Livingston Mission Field Airport - LVM , Livingston , US "," Lock Haven W. T. Piper Memorial Airport - LHV , Lock haven , US "," Lockport Lewis Lockport Airport - LOT , Lockport , US "," Logan Cache Airport - LGU , Logan , US "," Lompoc Airport - LPC , Lompoc , US "," London Corbin-London Airport - LOZ , London , US "," Lone Rock Tri County Airport - LNR , Lone rock , US "," Lonely Dew Station Airport - LNI , Lonely , US "," Long Beach Municipal Airport - LGB , Long beach , US "," Long Island Airport - LIJ , Long island , US "," Longview Airport - GGG , Longview , US "," Longview Airport - LOG , Longview , US "," Lopez Island Airport - LPS , Lopez , US "," Lordsburg Airport - LSB , Lordsburg , US "," Loring Airport - WLR , Loring , US "," Los Alamos Airport - LAM , Los alamos , US "," Los Angeles International Airport - LAX , Los Angeles , US "," Los Angeles Metropolitan Area - QLA , Los Angeles , US "," Los Banos Airport - LSN , Los banos , US "," Lost Harbor Sea Port Airport - LHB , Lost harbor , US "," Lost River Airport - LSR , Lost river , US "," Louisa Airport - LOW , Louisa , US "," Louisburg Franklin Airport - LFN , Louisburg , US "," LOUISVILLE INTERNATIONAL - SDF , LOUISVILLE , US "," Louisville Winston County Airport - LMS , Louisville , US "," Lovelock Derby Field Airport - LOL , Lovelock , US "," Lubbock Int'l Airport - LBB , Lubbock , US "," Ludington Mason County Airport - LDM , Ludington , US "," Lumberton Airport - LBT , Lumberton , US "," Lusk Airport - LSK , Lusk , US "," Lynchburg Preston-Glenn Field Airport - LYH , Lynchburg , US "," Lyndonville Airport - LLX , Lyndonville , US "," Lyons Rice County Municipal Airport - LYO , Lyons , US "," Mackinac Island Airport - MCD , Mackinac island , US "," Macomb Municipal Airport - MQB , Macomb , US "," Madera Airport - MAE , Madera , US "," Madison Airport - XMD , Madison , US "," Madison Dane County Regional Airport - MSN , Madison , US "," Madison Griswold Airport - MPE , Madison , US "," Madison Jefferson Proving Grd Airport - MDN , Madison , US "," Madras City-County Airport - MDJ , Madras city , US "," Magnolia Municipal Airport - AGO , Magnolia , US "," Malad City Airport - MLD , Malad city , US "," Malden Airport - MAW , Malden , US "," Malta Airport - MLK , Malta , US "," Mammoth Lakes Airport - MMH , Mammoth lakes , US "," Manassas Airport - MNZ , Manassas , US "," Manchester Municipal Airport - MHT , Manchester , US "," Manhattan Municipal Airport - MHK , Manhattan , US "," Manila Municipal Airport - MXA , Manila , US "," Manistee Blacker Airport - MBL , Manistee , US "," Manistique Schoolcraft County Airport - ISQ , Manistique , US "," Manitowoc Municipal Airport - MTW , Manitowoc , US "," Mankato Municipal Airport - MKT , Mankato , US "," Manley Hot Springs Airport - MLY , Manley , US "," Manokotak Airport - KMO , Manokotak , US "," Mansfield Lahm Municipal Airport - MFD , Mansfield , US "," Manteo Dare County Regional Airport - MEO , Manteo , US "," Manti Manti-Ephraim Airport - NTJ , Manti , US "," Manville Kupper Airport - JVI , Manville , US "," Marana Airport - MZJ , Marana , US "," Marathon Flight Strip Airport - MTH , Marathon , US "," Marble Canyon Airport - MYH , Marble canyon , US "," Marco Island Airport - MRK , Marco island , US "," Marfa Municipal Airport - MRF , Marfa , US "," Marguerite Bay Airport - RTE , Marguerite bay , US "," Marion Airport - MZZ , Marion , US "," Marion Municipal Airport - MNN , Marion , US "," Marion Williamson County Airport - MWA , Marion , US "," Marks Selfs Airport - MMS , Marks , US "," Marlborough Airport - MXG , Marlborough , US "," Marquette County Airport - MQT , Marquette , US "," Marshall Airport - MLL , Marshall , US "," Marshall Harrison County Airport - ASL , Marshall , US "," Marshall Memorial Municipal Airport - MHL , Marshall , US "," Marshall Municipal-Ryan Field Airport - MML , Marshall , US "," Marshalltown Municipal Airport - MIW , Marshalltown , US "," Marshfield Municipal Airport - MFI , Marshfield , US "," Martinsburg Airport - MRB , Martinsburg , US "," Marysville Yuba County Airport - MYV , Marysville , US "," Mason City Airport - MCW , Mason city , US "," Massena Richards Field Airport - MSS , Massena , US "," Matagorda Island  Airport - MGI , Matagorda island , US "," Mattoon Coles County Memorial Airport - MTO , Mattoon , US "," Maxton Airport - MXE , Maxton , US "," May Creek Airport - MYK , May creek , US "," Mayport  Airport - NRB , Mayport , US "," Mc Alester Airport - MLC , Mc alester , US "," Mc Rae Telfair-Wheeler Airport - MQW , Mc rae , US "," McAllen Airport - MFE , Mcallen , US "," McCall Airport - MYL , Mccall , US "," McCarthy Airport - MXY , Mccarthy , US "," McComb Pike County Airport - MCB , Mccomb , US "," McCook Airport - MCK , Mccook , US "," McGrath Airport - MCG , Mcgrath , US "," McMinnville Warren County Airport - RNC , Mcminnville , US "," McPherson Airport - MPR , Mcpherson , US "," Meadville Airport - MEJ , Meadville , US "," MEDFORD - MFR , MEDFORD , US "," Medford Airport - MDF , Medford , US "," Medfra Airport - MDR , Medfra , US "," Mekoryuk Ellis Field Airport - MYU , Mekoryuk , US "," Melbourne Int'l Airport - MLB , Melbourne , US "," Melfa Accomack County Airport - MFV , Melfa , US "," Memphis Int'l Airport - MEM , Memphis , US "," Menominee Airport - MNM , Menominee , US "," Merced Municipal Airport - MCE , Merced , US "," Mercury Desert Rock Airport - DRA , Mercury , US "," Meridian Key Field Airport - MEI , Meridian , US "," Merrill Municipal Airport - RRL , Merrill , US "," Mesa Falcon Field Airport - MSC , Mesa , US "," Mesquite Airport - MFH , Mesquite , US "," Meyers Chuck Airport - WMK , Meyers chuck , US "," MIAMI - MIA , MIAMI , US "," Miami Airport - MIO , Miami , US "," Michigan City Airport - MGC , Michigan city , US "," Middleton Island Intermediate Airport - MDO , Middleton island , US "," Middletown Hook Field Airport - MWO , Middletown , US "," MIDLAND - MAF , MIDLAND , US "," Miles City Municipal Airport - MLS , Miles city , US "," Milledgeville Baldwin County Airport - MLJ , Milledgeville , US "," Millinocket Airport - MLT , Millinocket , US "," Millville Airport - MIV , Millville , US "," Milton  Airport - NSE , Milton , US "," MILWAUKEE - MKE , MILWAUKEE , US "," Minchumina Intermediate Airport - MHM , Minchumina , US "," Minden Douglas County Airport - MEV , Minden , US "," Mineral Wells Mineral Wells Airport - MWL , Mineral wells , US "," MINNEAPOLIS - MSP , MINNEAPOLIS ST PAUL , US "," Minocqua Noble F. Lee Airport - ARV , Minocqua , US "," Minot Int'l Airport - MOT , Minot , US "," Minto Airport - MNT , Minto , US "," Missoula Johnson-Bell Field Airport - MSO , Missoula , US "," Mitchell Municipal Airport - MHE , Mitchell , US "," Moab Canyonlands Field Airport - CNY , Moab , US "," Moberly Airport - MBY , Moberly , US "," Mobile Municipal Airport - MOB , Mobile , US "," Mobridge Airport - MBG , Mobridge , US "," Modesto Municipal Airport - MOD , Modesto , US "," Mojave Kern County Airport - MHV , Mojave , US "," Oahu Dillingham Airfield Airport - HDH , Mokuleia , US "," Monahans Roy Hurd Memorial Airport - MIF , Monahans , US "," Monroe Municipal Airport - MLU , Monroe , US "," Monroeville Monroe County Airport - MVC , Monroeville , US "," Montague Siskiyou County Airport - SIY , Montague , US "," Montauk Sky Portal Airport - MTP , Montauk , US "," Monterey Airport - MRY , Monterey , US "," Montevideo Municipal Airport - MVE , Montevideo , US "," Montgomery Dannelly Field Airport - MGM , Montgomery , US "," Montgomery Orange County Airport - MGJ , Montgomery , US "," Monticello Municipal Airport - MXO , Monticello , US "," Monticello San Juan County Airport - MXC , Monticello , US "," Monticello Sullivan County Int'l Airport - MSV , Monticello , US "," Montpelier  Airport - MPV , Montpelier , US "," Montrose County Airport - MTJ , Montrose , US "," Montvale Airport - QMV , Montvale , US "," Monument Valley Gldng Airport - GMV , Monument valley , US "," Morganton Lenoir Airport - MRN , Morganton , US "," Morgantown Airport - MGW , Morgantown , US "," Morrilton Petit Jean Park Airport - MPJ , Morrilton , US "," Morris Municipal Airport - MOX , Morris , US "," Morristown Moore-Murrell Airport - MOR , Morristown , US "," Morristown Municipal Airport - MMU , Morristown , US "," Moser Bay Airport - KMY , Moser bay , US "," MOSES LAKE - MWH , MOSES LAKE , US "," Moses Point Intermediate Airport - MOS , Moses point , US "," Mt. Holly Burlington County Airport - LLY , Mount holly , US "," Mt. Mckinley Airport - MCL , Mount mckinley , US "," Mt. Pleasant Airport - MPS , Mount pleasant , US "," Mt. Pleasant Airport - MSD , Mount pleasant , US "," Mt. Pleasant Municipal Airport - MOP , Mount pleasant , US "," Mt. Pleasant Municipal Airport - MPZ , Mount pleasant , US "," Mt. Pocono Airport - MPO , Mount pocono , US "," Mt. Shasta Rep Airport - MHS , Mount shasta , US "," Mt. Union Airport - MUU , Mount union , US "," Mt. Vernon Skagit Regional Airport - MVW , Mount vernon , US "," Mt. Vernon-Outland Airport - MVN , Mount vernon , US "," Mt. Wilson Airport - MWS , Mount wilson , US "," Mountain Home Airport - WMH , Mountain home , US "," Mountain View Moffett Field Airport - NUQ , Mountain view , US "," Mountain Village Airport - MOU , Mountain village , US "," Mullen Airport - MHN , Mullen , US "," Muncie Delaware County Airport - MIE , Muncie , US "," Murray Calloway County Airport - CEY , Murray , US "," Muscatine Airport - MUT , Muscatine , US "," Muscle Shoals Airport - MSL , Muscle shoals , US "," Muskegon Airport - MKG , Muskegon , US "," MRYTLE BEACH - MYR , MYRTLE BEACH , US "," Nacogdoches Lufkin Angelina County Airport - LFK , Nacogdoches , US "," Naknek Airport - NNK , Naknek , US "," Nakolik River Airport - NOL , Nakolik , US "," Nantucket Memorial Airport - ACK , Nantucket , US "," Napa County Airport - APC , Napa county , US "," Napakiak Airport - WNA , Napakiak , US "," Napaskiak  Airport - PKA , Napaskiak , US "," Naples Airport - APF , Naples , US "," Nashua Boire Field Airport - ASH , Nashua , US "," NASHVILLE INTL - BNA , NASHVILLE , US "," Natchez Hardy-Anders Airport - HEZ , Natchez , US "," Naukiti Airport - NKI , Naukiti , US "," Needles Airport - EED , Needles , US "," Nelson Lagoon Airport - NLG , Nelson lagoon , US "," Nenana Municipal Airport - ENN , Nenana , US "," Neosho Airport - EOS , Neosho , US "," Nephi Airport - NPH , Nephi , US "," Nevada Airport - NVD , Nevada , US "," New Bedford Airport - EWB , New bedford , US "," New Bern Simmons Nott Airport - EWN , New bern , US "," New Chenega Airport - NCN , New chenega , US "," New Haven Airport - HVN , New haven , US "," New Koliganek Airport - KGK , New koliganek , US "," New London Airport - GON , New london , US "," NEW ORLEANS - MSY , NEW ORLEANS , US "," New Philadelphia Harry Clever Airport - PHD , New philadelphia , US "," New Richmond Municipal Airport - RNH , New richmond , US "," New Stuyahok Airport - KNW , New stuyahok , US "," New Ulm Airport - ULM , New ulm , US "," Downtown Manhattan/Wall Street Heliport - JRA , New york , US "," Downtown Manhattan/Wall Street Heliport - JRB , New york , US "," Downtown Manhattan/Wall Street Heliport - JWS , New york , US "," East 34th Street Heliport - TSS , New york , US "," John F. Kennedy International Airport - JFK , New york , US "," La Guardia Airport - LGA , New york , US "," New York Metropolitan Area - NYC , New york , US "," Newark Int'l Airport - EWR , Newark , US "," Newburgh Stewart Airport - SWF , Newburgh , US "," Newcastle Mondell Airport - ECS , Newcastle , US "," Newport Airport - EFK , Newport , US "," Newport Airport - ONP , Newport , US "," Newport Parlin Field Airport - NWH , Newport , US "," Newport State Airport - NPT , Newport , US "," Newport News Airport - PHF , Newport news , US "," Newtok Airport - WWT , Newtok , US "," Newton Municipal Airport - TNU , Newton , US "," Newton City-County Airport - EWK , Newton city , US "," Niagara Falls Int'l Airport - IAG , Niagara falls , US "," Niblack Airport - NIE , Niblack , US "," Nichen Cove Airport - NKV , Nichen cove , US "," Nightmute Airport - NME , Nightmute , US "," Nikolai Airport - NIB , Nikolai , US "," Nikolski  Airport - IKO , Nikolski , US "," Niles Jerry Tyler Memorial Airport - NLE , Niles , US "," Ninilchik Airport - NIN , Ninilchik , US "," Noatak Airport - WTK , Noatak , US "," Nogales Int'l Airport - OLS , Nogales , US "," Nome Airport - OME , Nome , US "," Nondalton Airport - NNL , Nondalton , US "," Noorvik Curtis Memorial Airport - ORV , Noorvik , US "," Norfolk Int'l Airport - ORF , Norfolk , US "," Norfolk Stefan Field Airport - OFK , Norfolk , US "," Norman Max Westheimer Airport - OUN , Norman , US "," Norridgewock Central Maine Airport - OWK , Norridgewock , US "," North Bend Airport - OTH , North bend , US "," North Platte Lee Bird Field Airport - LBF , North platte , US "," Northbrook Sky Harbor Airport - OBK , Northbrook , US "," Northeast Cape  Airport - OHC , Northeast cape , US "," Northway Airport - ORT , Northway , US "," Norwich Eaton Airport - OIC , Norwich , US "," Norwood Memorial Airport - OWD , Norwood , US "," Novato Airport - NOT , Novato , US "," Nuiqsut Airport - NUI , Nuiqsut , US "," Nulato Airport - NUL , Nulato , US "," Eight Fathom Bight Airport - EFB , Null , US "," Nunapitchuk Airport - NUP , Nunapitchuk , US "," Nyac Airport - ZNC , Nyac , US "," Oak Harbor Airport - ODW , Oak harbor , US "," Oakland Int'l Airport - OAK , Oakland , US "," Oaktown Green Airport - OTN , Oaktown , US "," Ocala Taylor Field Airport - OCF , Ocala , US "," Ocean City Municipal Airport - OCE , Ocean city , US "," Ocean Reef Airport - OCA , Ocean reef , US "," Oceana  Airport - NTU , Oceana , US "," Oceanic Airport - OCI , Oceanic , US "," Oceanside Municipal Airport - OCN , Oceanside , US "," Ogallala Searle Field Airport - OGA , Ogallala , US "," Ogden Municipal Airport - OGD , Ogden , US "," Ogdensburg Airport - OGS , Ogdensburg , US "," Oil City Splane Memorial Airport - OIL , Oil city , US "," Okeechobee County Airport - OBE , Okeechobee , US "," Oklahoma City Will Rogers World Airport - OKC , Oklahoma city , US "," Okmulgee Airport - OKM , Okmulgee , US "," Old Harbor  Airport - OLH , Old harbor , US "," Old Town Airport - OLD , Old town , US "," Olean Municipal Airport - OLE , Olean , US "," Olga Bay Airport - KOY , Olga bay , US "," Olive Branch Airport - OLV , Olive branch , US "," Olney Airport - ONY , Olney , US "," Olney-Noble Airport - OLY , Olney , US "," Olympia Airport - OLM , Olympia , US "," OMAHA - OMA , OMAHA , US "," Omak Municipal Airport - OMK , Omak , US "," Oneill Municipal Airport - ONL , Oneill , US "," Oneonta Municipal Airport - ONH , Oneonta , US "," Onion Bay Airport - ONN , Onion bay , US "," Ontario Airport - ONO , Ontario , US "," Ontario Int'l Airport - ONT , Ontario , US "," Opelousas St. Landry Parish Airport - OPL , Opelousas , US "," Orangeburg Municipal Airport - OGB , Orangeburg , US "," Orlando Intl. - MCO , Orlando , US "," Oroville Airport - OVE , Oroville , US "," Osage Beach Airport - OSB , Osage beach , US "," Osceola Municipal Airport - OEO , Osceola , US "," Oscoda  Airport - OSC , Oscoda , US "," Oshkosh Airport - OKS , Oshkosh , US "," Oshkosh Wittman Field Airport - OSH , Oshkosh , US "," Oskaloosa Municipal Airport - OOA , Oskaloosa , US "," Otto Vor Airport - OTO , Otto , US "," Ottumwa Industrial Airport - OTM , Ottumwa , US "," Ouzinkie Airport - KOZ , Ouzinkie , US "," Owatonna Airport - OWA , Owatonna , US "," Owensboro Daviess County Airport - OWB , Owensboro , US "," Oxford Miami University Airport - OXD , Oxford , US "," Oxford University-Oxford Airport - UOX , Oxford , US "," Oxford Waterbury-Oxford Airport - OXC , Oxford /waterbury , US "," Oxnard Airport - OXR , Oxnard , US "," Ozark  Airport - OZR , Ozark , US "," Ozona Airport - OZA , Ozona , US "," Pacific City State Airport - PFC , Pacific city , US "," Pack Creek Airport - PBK , Pack creek , US "," Paducah Barkley Regional Airport - PAH , Paducah , US "," Paf Warren Airport - PFA , Paf warren , US "," Page Airport - PGA , Page , US "," Pagosa SpringsStevens Field Airport - PGO , Pagosa springs , US "," Pahokee Palm Beach Co Glades Airport - PHK , Pahokee , US "," Paimiut  Airport - PMU , Paimiut , US "," Painesville Casement Airport - PVZ , Painesville , US "," Painter Creek Airport - PCE , Painter creek , US "," Palacios Airport - PSX , Palacios , US "," Palestine Airport - PSN , Palestine , US "," PALM SPRINGS - PSP , PALM SPRINGS , US "," Palmer Metropolitan Airport - PMX , Palmer , US "," Palmer Municipal Airport - PAQ , Palmer , US "," Palo Alto Airport - PAO , Palo alto , US "," Pampa Perry Lefors Field Airport - PPA , Pampa , US "," Panama City Bay County Airport - PFN , Panama city , US "," Panguitch Airport - PNU , Panguitch , US "," Paonia North Fork Valley Airport - WPO , Paonia , US "," Paragould Municipal Airport - PGR , Paragould , US "," Paris Cox Field Airport - PRX , Paris , US "," Paris Henry County Airport - PHT , Paris , US "," Park Falls Airport - PKF , Park falls , US "," Park Rapids Airport - PKD , Park rapids , US "," Parks Airport - KPK , Parks , US "," Parsons Tri-City Airport - PPF , Parsons , US "," Pascagoula Jackson County Airport - PGL , Pascagoula , US "," Pasco Tri-Cities Airport - PSC , Pasco , US "," Paso Robles Airport - PRB , Paso robles , US "," Patterson Williams Memorial Airport - PTN , Patterson , US "," Patuxent River  Airport - NHK , Patuxent river , US "," Pauloff Harbor Airport - KPH , Pauloff harbor , US "," Payson Airport - PJB , Payson , US "," Peach Springs Airport - PGS , Peach springs , US "," Pecos City Airport - PEQ , Pecos , US "," Pedro Bay Airport - PDB , Pedro bay , US "," Pelican  Airport - PEC , Pelican , US "," Pell City St. Clair County Airport - PLR , Pell city , US "," Pellston Emmet County Airport - PLN , Pellston , US "," Pembina Intermediate Airport - PMB , Pembina , US "," Pendleton Airport - PDT , Pendleton , US "," Pensacola Regional Airport - PNS , Pensacola , US "," Peoria Greater Peoria Airport - PIA , Peoria , US "," Perry Municipal Airport - PRO , Perry , US "," Perry-Foley Airport - FPY , Perry , US "," Perry Island  Airport - PYL , Perry island , US "," Perryville Airport - KPV , Perryville , US "," Peru  Airport - GUS , Peru , US "," Peru Illinois Valley Regnl Airport - VYS , Peru , US "," Petersburg Grant County Airport - PGC , Petersburg , US "," Petersburg Municipal Airport - PSG , Petersburg , US "," Petersburg Municipal Airport - PTB , Petersburg , US "," Peterson's Point Airport - PNF , Petersons point , US "," PHILADELPHIA - PHL , PHILADELPHIA , US "," Philip Airport - PHP , Philip , US "," Philipsburg  Airport - PSB , Philipsburg , US "," Phoenix Scottsdale Municipal Airport - SCF , Phoenix scottsdale , US "," Picayune Pearl River County Airport - PCU , Picayune , US "," Pickens Airport - LQK , Pickens , US "," Pierre Airport - PIR , Pierre , US "," Pilot Station Airport - PQS , Pilot station , US "," Pine Bluff Grider Field Airport - PBF , Pine bluff , US "," Pine Mountain Garden Harris County Airport - PIM , Pine mountain , US "," Pine Ridge Airport - XPR , Pine ridge , US "," Pittsburg Municipal Airport - PTS , Pittsburg , US "," PITTSBURGH - PIT , PITTSBURGH , US "," Pittsfield Airport - PSF , Pittsfield , US "," Placerville Airport - PVF , Placerville , US "," Plainview Hale County Airport - PVW , Plainview , US "," Platinum Airport - PTU , Platinum , US "," Plattsburgh Clinton County Airport - PLB , Plattsburgh , US "," Pleasant Harbour Airport - PTR , Pleasant harbour , US "," Plentywood Sherwood Airport - PWD , Plentywood , US "," Plymouth Airport - PLY , Plymouth , US "," Plymouth Airport - PYM , Plymouth , US "," Pocahontas Municipal Airport - POH , Pocahontas , US "," Pocatello Airport - PIH , Pocatello , US "," Pohakuloa Airport - BSF , Pohakuloa , US "," Point Baker Airport - KPB , Point baker , US "," Wily Post Point Barrow Airport - PBA , Point barrow , US "," Point Hope Airport - PHO , Point hope , US "," Point Lay Dew Station Airport - PIZ , Point lay , US "," Point Lookout M Graham Clark Airport - PLK , Point lookout , US "," Polacca Airport - PXL , Polacca , US "," Polk Inlet Airport - POQ , Polk inlet , US "," Pompano Beach Airport - PPM , Pompano beach , US "," Ponca City Airport - PNC , Ponca , US "," Pontiac Airport - PTK , Pontiac , US "," Pope Vanoy Airport - PVY , Pope vanoy , US "," Poplar Bluff Earl Fields Memorial Airport - POF , Poplar bluff , US "," Porcupine Creek Airport - PCK , Porcupine creek , US "," Port Alexander Airport - PTD , Port alexander , US "," Port Alice Airport - PTC , Port alice , US "," Port Alsworth Airport - PTA , Port alsworth , US "," Port Angeles Fairchild Int'l Airport - CLM , Port angeles , US "," Port Armstrong Airport - PTL , Port armstrong , US "," Port Bailey Airport - KPY , Port bailey , US "," Port Clarence Airport - KPC , Port clarence , US "," Port Frederick Airport - PFD , Port frederick , US "," Port Graham Airport - PGM , Port graham , US "," Port Heiden Airport - PTH , Port heiden , US "," Port Hueneme  Airport - NTD , Port hueneme , US "," Port Huron St. Clair County Int'l Airport - PHN , Port huron , US "," Port Johnson Airport - PRF , Port johnson , US "," Port Moller  Airport - PML , Port moller , US "," Port Oceanic Airport - PRL , Port oceanic , US "," Port Protection Airport - PPV , Port protection , US "," Port San Juan Airport - PJS , Port san juan , US "," Port Townsend Airport - TWD , Port townsend , US "," Port Walter Airport - PWR , Port walter , US "," Port Williams Airport - KPR , Port williams , US "," Portage Creek Airport - PCA , Portage creek , US "," Porterville Airport - PTV , Porterville , US "," Portland Int'l Airport - PDX , Portland , US "," Portsmouth Regional Airport - PMH , Portsmouth , US "," Poteau Robert S Kerr Airport - RKR , Poteau , US "," Pottstown/Limerick Airport - PTW , Pottstown , US "," Poulsbo Airport - PUL , Poulsbo , US "," Powell  Airport - POY , Powell , US "," Prairie du Chien Municipal Airport - PCD , Prairie du chien , US "," Pratt Airport - PTT , Pratt , US "," Prentice Airport - PRW , Prentice , US "," Prescott Airport - PRC , Prescott , US "," Price Carbon County Airport - PUC , Price , US "," Princeton Airport - PCT , Princeton , US "," Princeton Airport - PNN , Princeton , US "," Prineville Airport - PRZ , Prineville , US "," Prospect Creek Airport - PPC , Prospect creek , US "," Providence Theodore Francis Airport - PVD , Providence , US "," Provincetown Airport - PVC , Provincetown , US "," Provo Airport - PVU , Provo , US "," Pueblo Memorial Airport - PUB , Pueblo , US "," Pullman Moscow Regional Airport - PUW , Pullman , US "," Punta Gorda Charlotte County Airport - PGD , Punta gorda , US "," Quakertown Upper Bucks Airport - UKT , Quakertown , US "," Quantico  Airport - NYG , Quantico , US "," Queen Airport - UQE , Queens airport , US "," Quillayute State Airport - UIL , Quillayute , US "," Quincy Airport - MQI , Quincy , US "," Quincy Municipal Airport - UIN , Quincy , US "," Quinhagak Kwinhagak Airport - KWN , Quinhagak , US "," Racine Horlick Airport - RAC , Racine , US "," RALEIGH DURHAM INTL - RDU , RALEIGH , US "," Rampart Airport - RMP , Rampart , US "," Rancho French Valley Airport - RBK , Rancho , US "," Rangely Airport - RNG , Rangely , US "," Ranger Municipal Airport - RGR , Ranger , US "," Rapid City Regional Airport - RAP , Rapid city , US "," Raspberry Strait Airport - RSP , Raspberry strait , US "," Raton Crews Field Airport - RTN , Raton , US "," Rawlins Airport - RWL , Rawlins , US "," Reading Municipal/Spaatz Field Airport - RDG , Reading , US "," Red Bluff Airport - RBL , Red bluff , US "," Red Devil Airport - RDV , Red devil , US "," Red Dog Airport - RDB , Red dog , US "," Red River Airport - RDR , Red river , US "," Redding Airport - RDD , Redding , US "," Redmond Airport - RDM , Redmond , US "," Redwood Falls Municipal Airport - RWF , Redwood falls , US "," Reed City Miller Field Airport - RCT , Reed city , US "," Reedsville Airport - RED , Reedsville , US "," Rehoboth Beach Airport - REH , Rehoboth beach , US "," Reno/Tahoe Int'l Airport - RNO , Reno , US "," Rensselaer Airport - RNZ , Rensselaer , US "," Renton Airport - RNT , Renton , US "," Rhinelander Oneida County Airport - RHI , Rhinelander , US "," Rice Lake Airport - RIE , Rice lake , US "," Richfield Reynolds Airport - RIF , Richfield , US "," Richland Airport - RLD , Richland , US "," Richmond Airport - RID , Richmond , US "," Richmond Int'l (Byrd Field) Airport - RIC , Richmond , US "," Rifle Garfield County Airport - RIL , Rifle , US "," Riverside Municipal Airport - RAL , Riverside , US "," Riverton Airport - RIW , Riverton , US "," Roanoke Municipal Airport - ROA , Roanoke , US "," Roanoke Rapids Halifax County Airport - RZZ , Roanoke , US "," Roche Harbor Airport - RCE , Roche harbor , US "," Rochester Fulton County Airport - RCR , Rochester , US "," Rochester Monroe County Airport - ROC , Rochester , US "," Rochester Municipal Airport - RST , Rochester , US "," Rock Hill Airport - RKH , Rock hill , US "," Rock Springs Sweetwater County Airport - RKS , Rock springs , US "," Rockdale Coffield Airport - RCK , Rockdale , US "," Rockland Knox County Regional Airport - RKD , Rockland , US "," Rockport Aransas County Airport - RKP , Rockport , US "," Rockwood Municipal Airport - RKW , Rockwood , US "," Rocky Mount-Wilson Airport - RWI , Rocky mount , US "," Rogers Airport - ROG , Rogers , US "," Rolla National Airport - RLA , Rolla , US "," Roma Falcon State Airport - FAL , Roma , US "," Rome Airport - RME , Rome , US "," Rome Richard B Russell Airport - RMG , Rome , US "," Rome State Airport - REO , Rome , US "," Roosevelt Airport - ROL , Roosevelt , US "," Rosario Airport - RSJ , Rosario , US "," Roseau Municipal Airport - ROX , Roseau , US "," Roseburg Municipal Airport - RBG , Roseburg , US "," Roswell Industrial Airport - ROW , Roswell , US "," Rotunda Airport - RTD , Rotunda , US "," Roundup Airport - RPX , Roundup , US "," Rouses Point Airport - RSX , Rouses point , US "," Rowan Bay Airport - RWB , Rowan bay , US "," Ruby Airport - RBY , Ruby , US "," Ruidoso Municipal Airport - RUI , Ruidoso , US "," Russell Airport - RSL , Russell , US "," Russian Mission Airport - RSH , Russian mission , US "," Ruston Airport - RSN , Ruston , US "," Rutland Airport - RUT , Rutland , US "," SACRAMENTO - SAC , SACRAMENTO , US "," SACRAMENTO - SMF , SACRAMENTO , US "," Safford Airport - SAD , Safford , US "," Saginaw Airport - MBS , Saginaw , US "," Saginaw Bay Airport - SGW , Saginaw bay , US "," Sagwon Airport - SAG , Sagwon , US "," St. Augustine Airport - UST , Saint augustine , US "," St. George Island Airport - STG , Saint george island , US "," St. John's Municipal Airport - SJN , Saint johns , US "," St. Joseph Rosecrans Memorial Airport - STJ , Saint joseph , US "," St. Marys Airport - STQ , Saint marys , US "," St. Marys Airport - XSM , Saint marys , US "," St. Mary's Airport - KSM , Saint marys , US "," St. Michael Airport - SMK , Saint michael , US "," St. Paul Downtown Airport - STP , Saint paul , US "," St. Paul Island Airport - SNP , Saint paul island , US "," Salem McNary Field Airport - SLE , Salem , US "," Salem Leckrone Airport - SLO , Salem-leckrone , US "," Salida Airport - SLT , Salida , US "," Salina Airport - SBO , Salina , US "," Salina Airport - SLN , Salina , US "," Salinas Airport - SNS , Salinas , US "," Salisbury Rowan County Airport - SRW , Salisbury , US "," Salisbury Wicomico County Airport - SBY , Salisbury , US "," Salmon Airport - SMN , Salmon , US "," Salt Lake City Int'l Airport - SLC , Salt lake city , US "," Salton City Airport - SAS , Salton city , US "," San Angelo Mathis Field Airport - SJT , San angelo , US "," SAN ANTONIO - SAT , SAN ANTONIO , US "," San Bernardino Tri-City Airport - SBT , San bernardino , US "," San Carlos Airport - SQL , San carlos , US "," SAN DIEGO - SAN , SAN DIEGO , US "," San Fernando Airport - SFR , San fernando , US "," San Francisco International Airport - SFO , San Francisco , US "," San Francisco Metropolitan Area - QSF , San Francisco , US "," SAN JOSE - SJC , SAN JOSE , US "," San Juan Airport - WSJ , San juan , US "," San Luis Obispo County Airport - SBP , San luis obispo , US "," San Rafael Hamilton Field Airport - SRF , San rafael , US "," Sand Point Municipal Airport - SDP , Sand point , US "," Sandusky Griffing Sandusky Airport - SKY , Sandusky , US "," Sandy River Airport - KSR , Sandy river , US "," Sanford Airport - SFM , Sanford , US "," Santa Ana John Wayne Airport - SNA , Santa ana , US "," SANTA BARBARA - SBA , SANTA BARBARA , US "," Santa Cruz Skypark Airport - SRU , Santa cruz , US "," Santa Fe Airport - SAF , Santa fe , US "," Santa Maria Public Airport - SMX , Santa maria , US "," Santa Monica Airport - SMO , Santa monica , US "," Santa Paula Airport - SZP , Santa paula , US "," Santa Rosa Sonoma County Airport - STS , Santa rosa , US "," Santa Ynez Airport - SQA , Santa ynez , US "," Saranac Lake Adirondacks Airport - SLK , Saranac , US "," SARASOTA BRADENTON - SRQ , SARASOTA , US "," Saratoga Shively Airport - SAA , Saratoga , US "," Sarichef Airport - WSF , Sarichef , US "," Sausalito Marin County Airport - JMC , Sausalito , US "," Savannah Hilton Head Intl Airport - SAV , Savannah , US "," Savoonga Airport - SVA , Savoonga , US "," Schenectady County Airport - SCH , Schenectady , US "," Scottsbluff County Airport - BFF , Scottsbluff , US "," Scranton/Wilkes-Barre Airport - AVP , Scranton/wilkes-barre , US "," Scribner State Airport - SCB , Scribner , US "," Seal Bay Airport - SYB , Seal bay , US "," Searcy Airport - SRC , Searcy , US "," Seattle/Tacoma Int'l Airport - SEA , Seattle/tacoma , US "," Sebring Air Terminal Airport - SEF , Sebring , US "," Sedalia Airport - DMO , Sedalia , US "," Sedona Airport - SDX , Sedona , US "," Selawik Airport - WLK , Selawik , US "," Seldovia Airport - SOV , Seldovia , US "," Selinsgrove Penn Valley Airport - SEG , Selinsgrove , US "," Selma Selfield Airport - SES , Selma , US "," Sequim Valley Airport - SQV , Sequim valley , US "," Sewanee Franklin County Airport - UOS , Sewanee , US "," Seward Airport - SWD , Seward , US "," Seymour Freeman Municipal Airport - SER , Seymour , US "," Shafter Kern County Airport - MIT , Shafter , US "," Shageluk Airport - SHX , Shageluk , US "," Shaktoolik Airport - SKK , Shaktoolik , US "," Shangri-la Airport - NRI , Shangri-la , US "," Shawnee Municipal Airport - SNL , Shawnee , US "," Sheboygan Memorial Airport - SBM , Sheboygan , US "," Sheep Mountain Airport - SMU , Sheep mountain , US "," Shelby Airport - SBX , Shelby , US "," Shelbyville Bomar Field Airport - SYI , Shelbyville , US "," Sheldon Point Airport - SXP , Sheldon point , US "," Shelton Sanderson Field Airport - SHN , Shelton , US "," Shemya Airport - SYA , Shemya , US "," Sheridan Airport - SHR , Sheridan , US "," Sherman/Denison Grayson County Airport - PNX , Sherman/denison , US "," Shirley Brookhaven Airport - WSH , Shirley , US "," Shishmaref Airport - SHH , Shishmaref , US "," Shoal Cove Airport - HCB , Shoal , US "," Show Low Airport - SOW , Show low , US "," SHREVEPORT - SHV , SHREVEPORT , US "," Shungnak Airport - SHG , Shungnak , US "," Sidney Airport - SNY , Sidney , US "," Sidney Airport - SXY , Sidney , US "," Sidney Richland Municipal Airport - SDY , Sidney , US "," Sierra Vista Municipal Airport - FHU , Sierra vista , US "," Sikeston Memorial Airport - SIK , Sikeston , US "," Siloam Springs Smith Field Airport - SLG , Siloam springs , US "," Silver City Grant County Airport - SVC , Silver city , US "," Sioux City Sioux Gateway Airport - SUX , Sioux city , US "," Sioux Falls Regional (Jo Foss Field Airport - FSD , Sioux falls , US "," Sitka Airport - SIT , Sitka , US "," Sitkinak Island Cgs Airport - SKJ , Sitkinak island , US "," Skagway Municipal Airport - SGY , Skagway , US "," Skwentna Intermediate Airport - SKW , Skwentna , US "," Sleetmute Airport - SLQ , Sleetmute , US "," Smith Cove Airport - SCJ , Smith cove , US "," Smithfield North Central Airport - SFZ , Smithfield , US "," Smyrna Airport - MQY , Smyrna , US "," Snyder Winston Field Airport - SNK , Snyder , US "," Socorro Airport - ONM , Socorro , US "," Soldotna Airport - SXQ , Soldotna , US "," Solomon Airport - SOL , Solomon , US "," Somerset Pulaski County Airport - SME , Somerset , US "," South Bend St. Joseph Co Airport - SBN , South bend , US "," South Naknek Airport - WSN , South naknek , US "," South Weymouth Airport - NZW , South weymouth , US "," Southern Pines Pinehurst Airport - SOP , Southern pines , US "," Sparrevohn Airport - SVW , Sparrevohn , US "," Sparta Airport - CMY , Sparta , US "," Spartanburg Downtown Memorial Airport - SPA , Spartanburg , US "," Spearfish Black Hills Airport - SPF , Spearfish , US "," Spencer Municipal Airport - SPW , Spencer , US "," Spirit Lake Airport - RTL , Spirit lake , US "," SPOKANE INTL - GEG , SPOKANE , US "," Springdale Muni Airport - SPZ , Springdale , US "," Springfield Airport - SGH , Springfield , US "," Springfield Capital Airport - SPI , Springfield , US "," Springfield State Airport - VSF , Springfield , US "," Stanton Carleton Airport - SYN , Stanton , US "," Statesboro Municipal Airport - TBR , Statesboro , US "," Statesville Municipal Airport - SVH , Statesville , US "," Staunton Shenandoah Valley Airport - SHD , Staunton shenandoah , US "," Steamboat Bay Airport - WSB , Steamboat bay , US "," Steamboat Springs Airport - SBS , Steamboat springs , US "," Stebbins Airport - WBB , Stebbins , US "," Stephenville Clark Field Airport - SEP , Stephenville , US "," Sterling Crosson Field Airport - STK , Sterling , US "," Sterling Rockfalls Whiteside County Airport - SQI , Sterling rockfalls , US "," Stevens Point Airport - STE , Stevens point , US "," Stevens Village Airport - SVS , Stevens village , US "," Stillwater Searcy Field Airport - SWO , Stillwater , US "," Stockton Airport - SCK , Stockton , US "," Stony River Airport - SRV , Stony river , US "," Storm Lake Municipal Airport - SLB , Storm lake , US "," Stow Minute Man Airfield Airport - MMN , Stow , US "," Stowe Morrisville-Stowe Airport - MVL , Stowe , US "," Stroud Airport - SUD , Stroud , US "," Stuart Witham Field Airport - SUA , Stuart , US "," Stuart Island Airport - SSW , Stuart island , US "," Sturgeon Bay Door County Airport - SUE , Sturgeon bay , US "," Sturgis Kirsch Municipal Airport - IRS , Sturgis , US "," Stuttgart Airport - SGT , Stuttgart , US "," Sullivan County Airport - SIV , Sullivan , US "," Sulphur Springs Airport - SLR , Sulphur springs , US "," Summit Airport - UMM , Summit , US "," Sumter Municipal Airport - SUM , Sumter , US "," Sun River Airport - SUO , Sun river , US "," Sundance Schloredt Airport - SUC , Sundance , US "," Superior Richard I Bong Airport - SUW , Superior , US "," Susanville Airport - SVE , Susanville , US "," Sweetwater Airport - SWW , Sweetwater , US "," Sylvester Airport - SYV , Sylvester , US "," Syracuse Hancock Int'l Airport - SYR , Syracuse , US "," Tacoma Industrial Airport - TIW , Tacoma , US "," Tahneta Pass Lodge Airport - HNE , Tahneta pass lodge , US "," Takotna Airport - TCT , Takotna , US "," Taku Lodge Airport - TKL , Taku lodge , US "," Talkeetna Airport - TKA , Talkeetna , US "," Talladega Airport - ASN , Talladega , US "," Tallahassee Municipal Airport - TLH , Tallahassee , US "," TAMPA - TPA , TAMPA , US "," Tanacross Intermediate Airport - TSG , Tanacross , US "," Tanalian Point Airport - TPO , Tanalian , US "," Tanana Ralph Calhoun Airport - TAL , Tanana , US "," Taos Airport - TSM , Taos , US "," Tatalina Airport - TLJ , Tatalina , US "," Tatitlek Airport - TEK , Tatitlek , US "," Taylor Airport - TWE , Taylor , US "," Taylor Airport - TYZ , Taylor , US "," Tehachapi Kern County Airport - TSP , Tehachapi , US "," Telida Airport - TLF , Telida , US "," Teller Airport - TLA , Teller , US "," Teller Mission Brevig Mission Airport - KTS , Teller mission , US "," Telluride Airport - TEX , Telluride , US "," Temple Draughon-Miller Airport - TPL , Temple , US "," Tenakee Springs Airport - TKE , Tenakee springs , US "," Terre Haute Hulman Field Airport - HUF , Terre haute , US "," Terrell Field Airport - TRL , Terrell , US "," Teterboro Airport - TEB , Teterboro , US "," Tetlin Airport - TEH , Tetlin , US "," Texarkana Municipal Airport - TXK , Texarkana , US "," The Dalles Airport - DLS , The dalles , US "," Thermal Airport - TRM , Thermal , US "," Thermopolis Hot Springs Airport - THP , Thermopolis , US "," Thief River Falls Regional Airport - TVF , Thief river falls , US "," Thomasville Municipal Airport - TVI , Thomasville , US "," Thompsonfield Airport - THM , Thompsonfield , US "," Thorne Bay Airport - KTB , Thorne bay , US "," Three Rivers Dr Haines Airport - HAI , Three rivers , US "," Tifton Henry Tift Myers Airport - TMA , Tifton , US "," Tikchik Airport - KTH , Tikchik , US "," Tioga Municipal Airport - VEX , Tioga , US "," Toccoa Airport - TOC , Toccoa , US "," Togiak Village Airport - TOG , Togiak , US "," Togiak Fish Airport - GFB , Togiak fish , US "," Tok Airport - TKJ , Tok , US "," Tokeen Airport - TKI , Tokeen , US "," Toksook Bay Airport - OOK , Toksook bay , US "," TOLEDO - TOL , TOLEDO , US "," Toledo Winlock Airport - TDO , Toledo , US "," Toms River Robert J. Miller Airport - MJX , Toms river , US "," Tonopah Airport - TPH , Tonopah , US "," Torrance Airport - TOA , Torrance , US "," Torrington Municipal Airport - TOR , Torrington , US "," Traverse City Airport - TVC , Traverse city , US "," Tremonton Airport - TRT , Tremonton , US "," Trenton Memorial Airport - TRX , Trenton , US "," Trenton Mercer County Airport - TTN , Trenton , US "," Trinidad Las Animas Airport - TAD , Trinidad , US "," Trona Airport - TRH , Trona , US "," Troutdale Airport - TTD , Troutdale , US "," Troy Municipal Airport - TOI , Troy , US "," Truckee Airport - TKF , Truckee , US "," Truth or Consequences Municipal Airport - TCS , Truth or consequences , US "," Tuba City Airport - TBC , Tuba , US "," Tucumcari Airport - TCC , Tucumcari , US "," Tulare Airport - TLR , Tulare , US "," Tullahoma Northern Airport - THA , Tullahoma , US "," TULSA - TUL , TULSA , US "," Tuluksak Airport - TLT , Tuluksak , US "," Tuntutuliak Airport - WTL , Tuntutuliak , US "," Tununak Airport - TNK , Tununak , US "," Tupelo Lemons Municipal Airport - TUP , Tupelo , US "," Tuscaloosa Van de Graaf Airport - TCL , Tuscaloosa , US "," Tuskegee Sharpe Field Airport - TGE , Tuskegee , US "," Tuxekan Island Airport - WNC , Tuxekan island , US "," Twentynine Palms Airport - TNP , Twentynine palms , US "," Twin Falls City County Airport - TWF , Twin falls , US "," Twin Hills Airport - TWA , Twin hills , US "," TYLER - TYR , TYLER , US "," Tyonek Airport - TYE , Tyonek , US "," Uganik Airport - UGI , Uganik , US "," Ugashik Airport - UGS , Ugashik , US "," Ukiah Airport - UKI , Ukiah , US "," Umiat Airport - UMT , Umiat , US "," Unalakleet Airport - UNK , Unalakleet , US "," Union City Everett-Stewart Airport - UCY , Union city , US "," Upland Cable Airport - CCB , Upland , US "," Upolu Point Airport - UPP , Upolu point , US "," Utica Berz-Macomb Airport - UIZ , Utica , US "," Utica Oneida County Airport - UCA , Utica , US "," Uvalde Garner Field Airport - UVA , Uvalde , US "," Valdez Municipal Airport - VDZ , Valdez , US "," Valdosta Regional Airport - VLD , Valdosta , US "," Valentine Miller Field Airport - VTN , Valentine , US "," Valle J T Robidoux Airport - VLE , Valle , US "," Vallejo Stolport Airport - VLO , Vallejo , US "," Valparaiso Porter County Airport - VPZ , Valparaiso , US "," Van Horn Culberson County Airport - VHN , Van horn , US "," Vandalia Airport - VLA , Vandalia , US "," Venetie Airport - VEE , Venetie , US "," Venice Airport - VNC , Venice , US "," Vernal Airport - VEL , Vernal , US "," Vero Beach Municipal Airport - VRB , Vero beach , US "," Versailles Airport - VRS , Versailles , US "," Vichy Rolla National Airport - VIH , Vichy/rolla , US "," Vicksburg Airport - VKS , Vicksburg , US "," Vidalia Municipal Airport - VDI , Vidalia , US "," View Cove Airport - VCB , View cove , US "," Vincennes Oneal Airport - OEA , Vincennes , US "," Visalia Airport - VIS , Visalia , US "," WACO - ACT , WACO , US "," Wahiawa  Airport - HHI , Wahiawa , US "," Wahpeton Airport - WAH , Wahpeton , US "," Waikoloa Airport - WKL , Waikoloa , US "," Waimanalo Bellows Field Airport - BLW , Waimanalo , US "," Wainwright Airport - AIN , Wainwright , US "," Waldron Island Airport - WDN , Waldron , US "," Wales Airport - WAA , Wales , US "," Walla Walla Airport - ALW , Walla walla , US "," Walnut Ridge Airport - ARG , Walnut ridge , US "," Walterboro Municipal Airport - RBW , Walterboro , US "," Waltham Airport - WLM , Waltham , US "," Wapakoneta Neil Armstrong Airport - AXV , Wapakoneta , US "," Ware Airport - UWA , Ware , US "," Warroad Airport - RRT , Warroad , US "," Washington County Airport - WSG , Washington , US "," Washington Warren Field Airport - OCW , Washington , US "," DISTRICT OF COLUMBIA - WAS , WASHINGTON DC , US "," DULLES INTL APT - IAD , WASHINGTON DC , US "," Wasilla Airport - WWA , Wasilla , US "," Waterfall Airport - KWF , Waterfall , US "," Waterloo Airport - ALO , Waterloo , US "," Watertown Airport - ART , Watertown , US "," Watertown Airport - ATY , Watertown , US "," Waterville Robert Lafleur Airport - WVL , Waterville , US "," Watsonville Airport - WVI , Watsonville , US "," Waukegan Memorial Airport - UGN , Waukegan , US "," Waukesha Airport - UES , Waukesha , US "," Waukon Municipal Airport - UKN , Waukon , US "," WAUSAU - AUW , WAUSAU , US "," Waycross Ware County Airport - AYS , Waycross , US "," Waynesburg Green County Airport - WAY , Waynesburg , US "," Weatherford Parker County Airport - WEA , Weatherford , US "," Webster City Municipal Airport - EBS , Webster city , US "," Weeping Water Browns Airport - EPG , Weeping water , US "," Wells Harriet Field Airport - LWL , Wells , US "," Wellsville Municipal Airport - ELZ , Wellsville , US "," Wenatchee Pangborn Field Airport - EAT , Wenatchee , US "," Wendover Airport - ENV , Wendover , US "," West Bend Airport - ETB , West bend , US "," West Kavik Airport - VKW , West kavik , US "," West Kuparuk Airport - XPU , West kuparuk , US "," West Memphis Municipal Airport - AWM , West memphis , US "," WEST PALM BEACH - PBI , WEST PALM BEACH , US "," West Point Airport - KWP , West point , US "," West Yellowstone Airport - WYS , West yellowstone , US "," Westerly State Airport - WST , Westerly , US "," Westfield Barnes Airport - BAF , Westfield , US "," Westhampton Suffolk County Airport - FOK , Westhampton , US "," Westsound Airport - WSX , Westsound , US "," Whale Pass Airport - WWP , Whale pass , US "," Wharton Airport - WHT , Wharton , US "," Wheatland Phifer Field Airport - EAN , Wheatland , US "," Wheeling Ohio County Airport - HLG , Wheeling , US "," Whidbey Island Ault Field Airport - NUW , Whidbey island , US "," White Mountain Airport - WMO , White mountain , US "," White Plains / Westchester County Airport - HPN , White plains , US "," White River Airport - WTR , White river , US "," White Sands Airport - WSD , White sands , US "," White Sulphur Springs Greenbrier Airport - SSU , White sulphur springs , US "," Whitefield Regional Airport - HIE , Whitefield , US "," Whitesburg Municipal Airport - BRG , Whitesburg , US "," WICHITA - ICT , WICHITA , US "," WICHITA FALLS - SPS , WICHITA FALLS , US "," Wilkes-Barre Wyoming Valle Airport - WBW , Wilkes-barre , US "," Wilkesboro Wilkes County Airport - IKB , Wilkesboro , US "," Williamsport Lycoming County Airport - IPT , Williamsport , US "," Williston Sloulin Field Int'l Airport - ISN , Williston , US "," Willmar Airport - ILL , Willmar , US "," Willoughby Lost Nation Airport - LNN , Willoughby , US "," Willow Airport - WOW , Willow , US "," Willows Glenn County Airport - WLW , Willows , US "," Wilmington Clinton Field Airport - ILN , Wilmington , US "," Winchester Municipal Airport - WGO , Winchester , US "," Winder Airport - WDR , Winder , US "," Windom Municipal Airport - MWM , Windom , US "," Winfield Arkansas City Airport - WLD , Winfield /arkansas city , US "," Wink Airport - INK , Wink , US "," Winnemucca Airport - WMC , Winnemucca , US "," Winona Municipal Airport - ONA , Winona , US "," Winslow Airport - INW , Winslow , US "," Winston Salem Smith-Reynolds Airport - INT , Winston salem , US "," Winter Haven Gilbert Field Airport - GIF , Winter haven , US "," Wiscasset Airport - ISS , Wiscasset , US "," Wisconsin Rapids Alexander Field Airport - ISW , Wisconsin rapids , US "," Wise Airport - LNP , Wise , US "," Wiseman Airport - WSM , Wiseman , US "," Woburn Cummings Park Airport - WBN , Woburn , US "," Wolf Point Int'l Airport - OLF , Wolf point , US "," Wood River Airport - WOD , Wood river , US "," Woodchopper Airport - WOO , Woodchopper , US "," Woodward West Woodward Airport - WWR , Woodward , US "," Wooster Wayne County Airport - BJJ , Wooster , US "," Worcester Airport - ORH , Worcester , US "," Worland Airport - WRL , Worland , US "," Worthington Airport - OTG , Worthington , US "," Wrangell Airport - WRG , Wrangell , US "," Wrench Creek Airport - WRH , Wrench creek , US "," Yakataga Intermediate Airport - CYT , Yakataga , US "," Yakima Air Terminal Airport - YKM , Yakima , US "," Yakutat Airport - YAK , Yakutat , US "," Yankton Chan Gurney Airport - YKN , Yankton , US "," Yerington Airport - EYR , Yerington , US "," York Airport - THV , York , US "," Yosemite Ntl Park Airport - OYS , Yosemite , US "," Youngstown Airport - YNG , Youngstown , US "," Yreka Airport - RKC , Yreka , US "," Yucca Flat Airport - UCC , Yucca flats , US "," Yuma \International Airport - YUM , Yuma , US "," Zanesville Airport - ZZV , Zanesville , US "," Zephyr Hills Airport - ZPH , Zephyrhills , US "," Artigas Airport - ATI , Artigas , UY "," Durazno Airport - DZO , Durazno , UY "," Melo Airport - MLZ , Melo , UY "," Montevideo Carrasco Airport - MVD , Montevideo , UY "," Punta del Este Airport - PDP , Punta del este , UY "," Rivera Airport - RVY , Rivera , UY "," Vichadero Airport - VCH , Vichadero , UY "," Termez Airport - TMJ , Termiz , UZ "," Urgench Airport - UGC , Urganch , UZ "," Barquisimeto Airport - BRM , Barquisimeto , VE "," Cabimas Oro Negro Airport - CBS , Cabimas , VE "," Calabozo Airport - CLZ , Calabozo , VE "," Caracas Simon Bolivar Airport - CCS , Caracas , VE "," Carora Airport - VCR , Carora , VE "," Coro Airport - CZE , Coro , VE "," El Tigre Airport - ELX , El tigre , VE "," Guanare Airport - GUQ , Guanare , VE "," Guasdualito Vare Maria Airport - GDO , Guasdualito , VE "," La Guaira Airport - LAG , La guaira , VE "," Lagunillas Airport - LGY , Lagunillas , VE "," Maracaibo La Chinita Airport - MAR , Maracaibo , VE "," Maracay Airport - MYC , Maracay , VE "," Puerto Ayacucho Airport - PYH , Puerto ayacucho , VE "," Puerto Cabello Airport - PBL , Puerto cabello , VE "," Tucupita Airport - TUV , Tucupita , VE "," Valencia Airport - VLN , Valencia , VE "," Valera Carvajal Airport - VLV , Valera , VE "," Banmethuot - BWV , Banmethuot , VN "," Ca Mau Airport - CAH , Ca Mau , VN "," Cantho Airport - VCA , Can Tho , VN "," Da Nang Airport - DAD , Da Nang , VN "," Lienkhang Airport - DLI , Dalat , VN "," Dien Bien Phu Airport - DIN , Dien Bien Phu , VN "," Haiphong Airport - HPH , Hai Phong , VN "," Noibai Airport - HAN , Hanoi , VN "," Hue Airport - HUI , Hue , VN "," Kontum Airport - KON , Kontum , VN "," Long Xuyen Airport - XLO , Long Xuyen , VN "," Nha-Trang Airport - NHA , Nha-Trang , VN "," Phanrang Airport - PHA , Phan Rang , VN "," Phanthiet Airport - PHH , Phan Thiet , VN "," Phuquoc Airport - PQC , Phu Quoc , VN "," Phuvinh Airport - PHU , Phu Vinh , VN "," Phu-Bon Airport - HBN , Phu-Bon , VN "," Phuoc Long Airport - VSO , Phuoclong , VN "," Pleiku Airport - PXU , Pleiku , VN "," Quanduc Airport - HOO , Quanduc , VN "," Quang Ngai Airport - XNG , Quang Ngai , VN "," Quinhon Airport - UIH , Quinhon , VN "," Rachgia Airport - VKG , Rach Gia , VN "," Tan Son Nhut International Airport - SGN , Saigon , VN "," Soc Trang Airport - SOA , Soc Trang , VN "," Na-San Airport - SQH , Son-La , VN "," Tam Ky Airport - TMK , Tamky , VN "," Tuyhoa Airport - TBB , Tuy Hoa , VN "," Vinh Long Airport - XVL , Vinh Long , VN "," Vung Tau Airport - VTG , Vung Tau , VN "," Aden Int'l Airport - ADE , Aden , YE "," Sanaa Int'l Airport - SAH , Sanaa , YE "," Chingola Airport - CGJ , Chingola , ZM "," Kitwe Southdowns Airport - KIW , Kitwe , ZM "," Livingstone Airport - LVI , Livingstone , ZM "," Lusaka Airport - LUN , Lusaka , ZM "," Ndola Airport - NLA , Ndola , ZM "," Solwezi Airport - SLI , Solwezi , ZM "," Bulawayo Airport - BUQ , Bulawayo , ZW "," Chipinge Airport - CHJ , Chipinge , ZW "," Gweru Airport - GWE , Gweru , ZW "," Harare Airport - HRE , Harare , ZW "," Hwange Airport - WKI , Hwange , ZW "," Kariba Airport - KAB , Kariba , ZW "," Mutare Airport - UTA , Mutare , ZW "," Victoria Falls Airport - VFA , Victoria falls , ZW");
        arrList = arrAutoAirportList;
    }
    else
    {
        //arrCityList = new Array("mile ranch - ZMH, CA","Aalborg - AAL, DK","Aappilattoq - QUV, GL","AARHUS - AAR, DK","Abadan - ABD, IR","Abbotsford - YXX, CA","Abengourou - OGO, CI","Aberdeen - ABR, US","Aberdeen - ABZ, GB","Aberdeen - APG, US","Abha - AHB, SA","ABILENE - ABI, US","Abingdon - VJI, US","Abu dhabi - AUH, AE","Acadiana - ARA, US","Acapulco - ACA, MX","Accra - ACC, GH","Achutupo - ACU, PA","Ada - ADT, US","Adana - ADA, TR","Adelaide - ADL, AU","Aden - ADE, YE","Aderson - AID, US","Afton - AFO, US","Agadir - AGA, MA","Agartala - IXA, IN","Agen - AGF, FR","Agra - AGR, IN","Aguascalientes - AGU, MX","Ahmedabad - AMD, IN","Aiken - AIK, US","Ainsworth - ANW, US","Aitape - ATP, PG","Aizawl - AJL, IN","Ajaccio - AJA, FR","Akhiok - AKK, US","Akiachak - KKI, US","Akiak - AKI, US","Akita - AXT, JP","Aklavik - LAK, CA","Akola - AKD, IN","Akron - AKO, US","Akron/canton - CAK, US","Akrotiri - AKT, CY","Aksu - AKU, CN","Aktau - SCO, KZ","Akulivik - AKV, CA","Akure - AKR, NG","Akureyri - AEY, IS","Akutan - KQA, US","Al hoceima - AHU, MA","Alakanuk - AUK, US","Alameda - NGZ, US","Alamogordo-white sands - ALM, US","Alamosa - ALS, US","Albany - ALB, US","Albenga - ALL, IT","Albert lea - AEL, US","Albi - LBI, FR","Albuquerque - ABQ, US","Aldan - ADH, RU","Aleknagik - WKK, US","Aleneva - AED, US","Aleppo - ALP, SY","Alert - YLT, CA","Alert bay - YAL, CA","Alexander city - ALX, US","ALEXANDRIA - AEX, US","Alexandria bay - AXB, US","Alexandria bay - AXN, US","Alexandroupolis - AXD, GR","Alghero - AHO, IT","Algiers - ALG, DZ","Algona - AXG, US","ALICANTE - ALC, ES","Alice - ALI, US","Alice arm - ZAA, CA","Alice springs - ASP, AU","Aliceville - AIV, US","Alitak - ALZ, US","Allahabad - IXD, IN","Allakaket - AET, US","ALLENTOWN - ABE, US","Alliance - AIA, US","Alma - AMN, US","Alma - YTF, CA","Almaty - ALA, KZ","Along - IXV, IN","Alor setar - AOR, MY","Alpena - APN, US","Alpine - ALE, US","Alta lake - YAE, CA","Altenburg - AOC, DE","Alton - ALN, US","Altoona - AOO, US","Altus - AXS, US","Alula - ALU, SO","Alyeska - AQY, US","Amahai - AHI, ID","Amalfi - AFI, CO","AMARILLO - AMA, US","Ambanja - IVA, MG","Ambato - ATF, EC","Ambatondrazaka - WAM, MG","Ambilobe - AMB, MG","Ambler - ABL, US","Ambon - AMQ, ID","Ambunti - AUJ, PG","Amchitka - AHT, US","Amderma - AMV, RU","Amery - AHH, US","Ames - AMW, US","Amityville - AYZ, US","Amman - AMM, JO","Amook - AOS, US","Amos - YEY, CA","Ampanihy - AMP, MG","Amritsar - ATQ, IN","Amsterdam - AMS, NL","Anacortes - OTS, US","Anadyr - DYR, RU","Anaheim - ANA, US","Anahim lake - YAA, CA","Anaktuvuk - AKP, US","Anchorgae - ANC, US","Ancona - AOI, IT","Ancud - ZUD, CL","Andahuaylas - ANS, PE","Andapa - ZWA, MG","Andenes - ANX, NO","Anderson - AND, US","Andorra la Vella - ALV, AD","Andrews - ADR, US","Angel fire - AXX, US","Angers - ANE, FR","Angling lake - YAX, CA","Angoche - ANO, MZ","Angola - ANQ, US","Angoon - AGN, US","Angoram - AGG, PG","Anguilla - RFK, US","Aniak - ANI, US","Anita bay - AIB, US","Ankang - AKA, CN","ANKARA - ANK, TR","Ankazoabo - WAK, MG","Ann arbor - ARB, US","Annapolis - ANP, US","Annecy - NCY, FR","Annette island - ANN, US","Anniston - ANB, US","Anshan - AOG, CN","Antalaha - ANM, MG","Antalya - AYT, TR","Anthony - ANY, US","Antlers - ATE, US","Antofagasta - ANF, CL","Antsohihy - WAI, MG","ANTWERP - ANR, BE","Anvik - ANV, US","Anyang - AYN, CN","Aomen - Aom, CN","Aomori - AOJ, JP","Apple valley - APV, US","Appleton - ATW, US","Arandis - ADI, NA","Arapahoe - AHF, US","Arauquita - ARQ, CO","Arawa - RAW, PG","Arctic bay - YAB, CA","Arctic red river - ZRR, CA","Arctic village - ARC, US","Ardmore - ADM, US","Arequipa - AQP, PE","Arica - ARI, CL","Arkansas - FYV, US","Arlington heights - JLH, US","Arlit - RLT, NE","Armore - AHD, US","Armstrong - YYW, CA","Arnes - YNR, CA","Arsuk - JRK, GL","Artesia - ATS, US","Artigas - ATI, UY","Arviat - YEK, CA","Asahikawa - AKJ, JP","Asbestos hill - YAF, CA","Asbury park - ARX, US","Ascona - ACO, CH","Ashburton - ASG, NZ","Ashcroft - YZA, CA","Asheville - AVL, US","Ashland - ASX, US","Ashley - ASY, US","Asmara - ASM, ER","Asosa - ASO, ET","Aspen - ASE, US","Astoria - AST, US","Atambua - ABU, ID","Atbasar - ATX, KZ","Athens - ATH, GR","Athens - ATO, US","Athens - AHN, US","Athens - MMI, US","Ati - ATV, TD","Atikokan - YIB, CA","Atka - AKB, US","ATLANTA - ATL, US","Atlantic - AIO, US","Atmautluak - ATT, US","Atqasuk - ATK, US","Atsugi - NJA, JP","Attawapiskat - YAT, CA","Attu island - ATU, US","Aubenas - OBS, FR","Auburn - AUN, US","Auburn-opelika - AUO, US","Auckland - AKL, NZ","Augsburg - AGB, DE","Augusta - AUG, US","Auki - AKS, SB","Aupaluk - YPJ, CA","Aurangabad - IXU, IN","Aurillac - AUR, FR","Aurora - AUZ, US","Austin - AUS, US","Austin - AUM, US","Austin - ASQ, US","Auxerre - AUF, FR","Avalon - SXC, US","Aviano - AVB, IT","Avignon - AVN, FR","Avon park - AVO, US","Awassa - AWA, ET","Babu - Bab, CN","Baca grande - BCJ, US","Bacolod - BCD, PH","Bafoussam - BFX, CM","Baganga - BNQ, PH","Bagdad - BGT, US","Bagotville - YBG, CA","Baguio - BAG, PH","Bahrain - BAH, BH","Baie johan beetz - YBJ, CA","Bainbridge - BGE, US","Bairnsdale - BSJ, AU","Bakel - BXE, SN","Baker - BKE, US","Baker island - BAR, US","Baker lake - YBK, CA","Bakersfield - BFL, US","Balakovo - BWO, RU","Balikpapan - BPN, ID","Balimo - OPU, PG","Bally kelly - BOL, GB","BALTIMORE - BWI, US","Baltrum - BMR, DE","Balurghat - RGH, IN","Bambari - BBY, CF","Bamenda - BPC, CM","Bamfield - YBF, CA","Bandar lampung - TKG, ID","Bandar seri begawan - BWN, BN","Bandirma - BDM, TR","Bandon - BDY, US","Bandung - BDO, ID","Banff - YBA, CA","Banfora - BNR, BF","Bangalore - BLR, IN","Bangassou - BGU, CF","Bangkok - BKK, TH","Bangor - BGR, US","Bangui - BGF, CF","Banja luka - BNX, BA","Banjarmasin - BDJ, ID","Banjul - BJL, GM","Banmethuot - BWV, VN","Banning - BNG, US","Bannu - BNP, PK","Bantry - BYT, IE","Baoshan - BSD, CN","Baotou - BAV, CN","Baracoa - BCA, CU","Barbers point - NAX, US","Barcelona - BCN, ES","Barcelonnette - BAE, FR","Bardera - BSY, SO","Bardstown - BRY, US","Bareli - BEK, IN","Bari - BRI, IT","Barnaul - BAX, RU","Barnwell - BNL, US","Barquisimeto - BRM, VE","Barrancabermeja - EJA, CO","Barranquilla - BAQ, CO","Barrow - BRW, US","Barrow-in-furness - BWF, GB","Barter island - BTI, US","Bartica - GFO, GY","Bartlesville - BVO, US","Bartow - BOW, US","Baruun-urt - UUN, MN","Basel - BSL, CH","Bastia - BIA, FR","Bata - BSG, GQ","Batam - BTH, ID","Batangafo - BTG, CF","Batesville - BVX, US","Batesville - HLB, US","Bathurst - ZBF, CA","Batman - BAL, TR","BATON ROUGE - BTR, US","Batouri - OUR, CM","Battle creek - BTL, US","Battle mountain - BAM, US","Batumi - BUS, GE","Baudette - BDE, US","Bay city - BBC, US","Bayamo - BYM, CU","Bayreuth - BYU, DE","Baytown - HPY, US","Bealanana - WBE, MG","Bear creek - BCC, US","Bearskin lake - XBE, CA","Beatrice - BIE, US","Beatton river - YZC, CA","Beatty - BTY, US","Beaufort - BFT, US","BEAUMONT PT ARTHUR - BPT, US","Beauvais - BVA, FR","Beaver creek - YXQ, CA","Beaver falls - BFP, US","Beckley - BKW, US","Bedford - BFR, US","Bedford - BED, US","Bedwell harbor - YBW, CA","Beeville - NIR, US","Beihai - BHY, CN","Beijing - PEK, CN","Beira - BEW, MZ","BELFAST - BFS, GB","Belfort - BOR, FR","Belgaum - IXG, IN","Bell island - KBE, US","Bella bella - ZEL, CA","Bella coola - QBC, CA","Bellaire - ACB, US","Bellary - BEP, IN","Bellavista - BLP, PE","Belle chasse - BCS, US","Belleville - BLV, US","Bellingham - BLI, US","Belluno - BLX, IT","Belmar - BLM, US","Belmopan - BCV, BZ","Beluga - BVU, US","Bembridge - BBP, GB","Bemidji - BJI, US","Benalla - BLN, AU","Benbecula - BEB, GB","Bendigo - BXG, AU","Bengbu - BFU, CN","Bennettsville - BTN, US","Benson - BBB, US","Benton harbor - BEH, US","Beppu - BPU, JP","Berbera - BBO, SO","Berens river - YBV, CA","Bergen - BGO, NO","Bergen op zoom - BZM, NL","Bergerac - EGC, FR","Berkeley - JBK, US","Berlin - BER, DE","Berlin - BML, US","Bermejo - BJO, BO","Bern - BRN, CH","Beroroha - WBO, MG","Bertoua - BTA, CM","Bethel - BET, US","Bethel city - JBT, US","Bethpage - BPA, US","Betioky - BKU, MG","Bettles - BTT, US","Beverly - BVY, US","Bhavnagar - BHU, IN","Bhopal - BHO, IN","Bhubaneswar - BBI, IN","Bhuj - BHJ, IN","Biak - BIK, ID","Biarritz - BIQ, FR","Bielefeld - BFE, DE","Big bay - YYA, CA","Big bay marina - YIG, CA","Big bear - RBF, US","Big creek - BIC, US","Big delta - BIG, US","Big lake - BGQ, US","Big mountain - BMX, US","Big piney-marbleton - BPI, US","Big rapids - WBR, US","Big spring - HCA, US","Big trout - YTL, CA","Bikaner - BKB, IN","Bilaspur - PAB, IN","Billings - BIL, US","Billund - BLL, DK","Biloela - ZBL, AU","Biloxi - BIX, US","Bima - BMU, ID","Binghamton - BGM, US","Bintulu - BTU, MY","Birch creek - KBC, US","Birjand - XBJ, IR","Birmingham - BHM, US","BIRMINGHAM - BHX, GB","Bisbee - BSQ, US","Bisho - BIY, ZA","Bishop - BIH, US","Bislig - BPH, PH","Bismarck - BIS, US","Bissau - OXB, GW","Bitam - BMM, GA","Bitburg - BBJ, DE","Blackpool - BLK, GB","Blacksburg - BCB, US","Blackwell - BWL, US","Blagoveschensk - BQS, RU","Blaine - BWS, US","Blairsville - BSI, US","Blakely island - BYW, US","Blanc sablon - YBX, CA","Blanding - BDG, US","Blantyre - BLZ, MW","Block island - BID, US","Bloemfontein - BFN, ZA","Bloodvein - YDV, CA","Bloomington - BMG, US","Bloomington - BMI, US","Blubber bay - XBB, CA","Blue bell - BBX, US","Blue canyon - BLU, US","Blue fox bay - BFB, US","Bluefield - BLF, US","Bluefields - BEF, NI","Blythe - BLH, US","Blytheville - HKA, US","Bob quinn lake - YBO, CA","Bobo dioulasso - BOY, BF","Boca raton - BCT, US","Boende - BNB, ZR","Bogalusa - BXA, US","BOGOTA - BOG, CO","Boise - BOI, US","Bokoro - BKR, TD","Bologna - BLQ, IT","Bolzano - BZO, IT","Boma - BOA, ZR","Bombay - BOM, IN","Bonaventure - YVB, CA","Bondoukou - BDK, CI","Bongor - OGR, TD","Bonnyville - YBY, CA","Bontang - BXT, ID","Boone - BNW, US","Borama - BXX, SO","Bordeaux - BOD, FR","Borden - YBN, CA","Borger - BGD, US","Bornite - RLU, US","Borrego springs - BXS, US","Bosaso - BSA, SO","Bossangoa - BSN, CF","Boston - BOS, US","Boswell bay - BSW, US","Bouake - BYK, CI","Bouar - BOP, CF","Bouca - BCF, CF","Boulder city - BLD, US","Boulsa - XBO, BF","Bouna - BQO, CI","Boundary - BYA, US","Boundiali - BXI, CI","Bountiful - BTF, US","Bourges - BOU, FR","Bournemouth - BOH, GB","Bousso - OUT, TD","Bowling green - BWG, US","Bowling green - APH, US","Bowman - BWM, US","Boxborough - BXC, US","Bozeman - BZN, US","Bozoum - BOZ, CF","Bradford - BFD, US","Bradford - BDF, US","Brady - BBD, US","Braga - BGZ, PT","Brainerd - BRD, US","Brandon - YBR, CA","BRASILIA - BSB, BR","Bratislava - BTS, SK","Bratsk - BTK, RU","Brawley - BWC, US","Brazoria - BZT, US","Breckenridge - BKD, US","Breda - GLZ, NL","Bremen - BRE, DE","Bremerhaven - BRV, DE","Bremerton - PWT, US","Bria - BIV, CF","Bridgeport - BDR, US","Bridgetown - BGI, BB","Brigham city - BMC, US","Brindisi - BDS, IT","Brisbane - BNE, AU","BRISTOL - BRS, GB","BRISTOL - TRI, US","Britton - TTO, US","Brive-la-gaillarde - BVE, FR","Brno - BRQ, CZ","Broadus - BDX, US","Broadview - YDR, CA","Brochet - YBT, CA","Brockville - XBR, CA","Broken bow - BBW, US","Bromont - ZBM, CA","Bronson creek - YBM, CA","Brookings - BOK, US","Brookings - BKX, US","Brooks lake - BKF, US","Brooks lodge - RBH, US","Broomfield - BJC, US","Broughton island - YVM, CA","Brownsville - BRO, US","Brownwood - BWD, US","Brunswick - NHZ, US","Brus laguna - BHG, HN","BRUSSELS - BRU, BE","Bryan - CFD, US","Bryce - BCE, US","Bubaque - BQE, GW","Bucaramanga - BGA, CO","Bucharest - BUH, RO","Buckeye - BXK, US","Buckland - BKC, US","Budapest - BUD, HU","Buenaventura - BUN, CO","Buenos Aires - BUE, AR","Buffalo - BUF, US","Buffalo municipal - BYG, US","Buffalo narrows - YVT, CA","Bukavu - BKY, ZR","Bulawayo - BUQ, ZW","Bull harbour - YBH, CA","Bullfrog basin - BFG, US","Bullhead - IFP, US","Bulolo - BUL, PG","Bunbury - BUY, AU","Bunia - BUX, ZR","Burbank - BUR, US","Burg - URD, DE","Burley - BYI, US","Burlington - BTV, US","Burlington - BRL, US","Burlington - BBF, US","Burnie - BWT, AU","Burns - BNO, US","Burns lake - YPZ, CA","Bur'o - BUO, SO","Bursa - BTZ, TR","Burtonwood - BUT, GB","Burwash landings - YDB, CA","Burwell - BUB, US","Bury saint edmunds - BEQ, GB","Buta - BZU, ZR","Butaritari - BBG, KI","Butler - BUM, US","Butler airport - BTP, US","BUTTE - BTM, US","Butte - BSZ, US","Butterworth - BWH, MY","Butuan - BXU, PH","B��zios - BZC, BR","Bydgoszcz - BZG, PL","Ca Mau - CAH, VN","Cabimas - CBS, VE","Cabin creek - CBZ, US","Cadillac - CAD, US","Caen - CFR, FR","Cagliari - CAG, IT","Cahors - ZAO, FR","Cairns - CNS, AU","Cairo - CIR, US","Cairo - CAI, EG","Calabar - CBQ, NG","Calabozo - CLZ, VE","Calais - CQF, FR","Calama - CJC, CL","Calcutta - CCU, IN","Caldwell - CDW, US","Calexico - CXL, US","Calgary - YYC, CA","Cali - CLO, CO","Calicut - CCJ, IN","Calipatria - CLR, US","Callaway gardens - CWG, US","Caloundra - CUD, AU","Calverton - CTO, US","Calvi - CLY, FR","Cambridge - CGE, US","Cambridge bay - YCB, CA","Camden - CDH, US","Camden - CDN, US","Camiri - CAM, BO","Camp douglas - VOK, US","Campbeltown - CAL, GB","Campo - CZZ, US","Can Tho - VCA, VN","Cananea - CNA, MX","Canas - CSC, CR","CANBERRA - CBR, AU","Cancun - CUN, MX","Candle - CDL, US","Cannes - CEQ, FR","Canon city - CNE, US","Canton - CTK, US","Cape dorset - YTE, CA","Cape dyer - YVN, CA","Cape girardea - CGI, US","Cape lisburne - LUR, US","Cape may (wildwood) - WWD, US","Cape newenham - EHM, US","Cape pole - CZP, US","Cape romanzof - CZF, US","Cape saint james - YCJ, CA","Cape spencer - CSP, US","Cape town - CPT, ZA","Capri - PRJ, IT","Caracas - CCS, VE","Caransebes - CSB, RO","Carbondale - MDH, US","Carcassonne - CCF, FR","Cardiff - CWL, GB","Caribou - CAR, US","Caribou island - YCI, CA","Carlsbad - CNM, US","Carlsbad - CLD, US","Carnot - CRF, CF","Carora - VCR, VE","Carrizo springs - CZT, US","Carroll - CIN, US","Carson city - CSN, US","Cartagena - CTG, CO","Cartierville - YCV, CA","Casa grande - CGZ, US","Cascade locks - CZK, US","Casiguran - CGG, PH","Casper - CPR, US","Castlebar - CLB, IE","Castlegar - YCG, CA","Castres - DCM, FR","Cat lake - YAC, CA","Catacamas - CAA, HN","Catania - CTA, IT","Catarman - CRM, PH","Caucasia - CAQ, CO","CEBU - CEB, PH","Cedar city - CDC, US","Cedar key - CDK, US","Cedar rapids - CID, US","Center island - CWS, US","Centerville - GHM, US","Central - CEM, US","Centralia - ENL, US","Centralia - YCE, CA","Cepu - CPF, ID","Chadron - CDR, US","Chagni - MKD, ET","Chalkyitsik - CIK, US","Challis - CHL, US","CHAMPAIGN URBANA - CMI, US","Chandalar - WCR, US","Chandigarh - IXC, IN","Chandler - SLJ, US","Changchun - CGQ, CN","Changde - CGD, CN","Changsha - CSX, CN","Changuinola - CHX, PA","Changzhi - CIH, CN","Changzhou - CZX, CN","Chania - CHQ, GR","Chanute - CNU, US","Chaoyang - CHG, CN","Chaparral - CPL, CO","Chapleau - YLD, CA","Charles city - CCY, US","Charleston - CHS, US","Charleston - CRW, US","Charlevoix - CVX, US","Charlo - YCL, CA","Charlotte - CLT, US","Charlottesville - CHO, US","Charlottetown - YHG, CA","Charlottetown - YYG, CA","Charters towers - CXT, AU","Chatham - CYM, US","Chatham - YCH, CA","Chatham - XCM, CA","Chattanooga - CHA, US","Chaves - CHV, PT","Cheboksary - CSY, RU","Chefornak - CYF, US","Chehalis - CLS, US","Cheju - CJU, KR","Chena hot springs - CEX, US","Chengdu - CTU, CN","Cheraw - HCW, US","Cherbourg - CER, FR","Cherepovets - CEE, RU","Cherokee - CKA, US","Cherokee - CKK, US","Cherskiy - CYX, RU","Chesapeake - HTW, US","Chesterfield inlet - YCS, CA","Chetumal - CTM, MX","Chetwynd - YCQ, CA","Chevak - VAK, US","Chevery - YHR, CA","Cheyenne - CYS, US","Chi mei - CMJ, CN","CHIANG MAI - CNX, TH","Chiayi - CYI, CN","Chibougamau - YMT, CA","CHICAGO - CHI, US","Chickasha - CHK, US","Chicken - CKX, US","Chiclayo - CIX, PE","Chico - CIC, US","Chifeng - CIF, CN","Chignik - KCQ, US","Chignik bay - KBW, US","Chignik fisheries - KCG, US","Chignik lagoon - KCL, US","Childress - CDS, US","Chilko lake - CJH, CA","Chilliwack - YCW, CA","Chiloquin - CHZ, US","Chimbote - CHM, PE","Chimoio - VPY, MZ","Chincoteague - WAL, US","Chingola - CGJ, ZM","Chinhae - CHF, KR","Chinju - HIN, KR","Chino - CNO, US","Chipinge - CHJ, ZW","Chisana - CZN, US","Chisasibi - YKU, CA","Chistochina - CZO, US","Chitina - CXC, US","Chitral - CJL, PK","CHITTAGON - CGP, BD","Chivolo - IVO, CO","Chokurdah - CKH, RU","Cholet - CET, FR","Chomley - CIV, US","Chongqing - CKG, CN","Chonju - CHN, KR","Christchurch - CHC, NZ","CHRISTMAS ISLAND - CXI, KI","Chuathbaluk - CHU, US","Chulman - CNN, RU","Cienfuegos - CFG, CU","Cilacap - CXP, ID","Cimitarra - CIM, CO","CINCINNATI - CVG, US","Circle city - IRC, US","Circle hot springs - CHP, US","Cirebon - CBN, ID","Ciudad del este - AGT, PY","Claremont - CNH, US","Clarinda - ICL, US","Clarks point - CLP, US","Clarksburg - CKB, US","Clarksdale - CKM, US","Clarksville - CKV, US","Clayton - CAO, US","Clear lake - CKE, US","Clearlake - CLC, US","Clearwater - CLW, US","Clemson - CEU, US","Clermont-ferrand - CFE, FR","CLEVELAND - CLE, US","Clifton - CFT, US","Clinton - CTZ, US","Clinton - CWI, US","Clinton creek - YLM, CA","Clintonville - CLI, US","Clovis - CVN, US","Cluff lake - XCL, CA","Clyde river - YCY, CA","Coalinga - CLG, US","Coatepeque - CTF, GT","Coatesville - CTH, US","Cobija - CIJ, BO","Cochabamba - CBB, BO","Cochin - COK, IN","Cochrane - YCN, CA","Cochstedt - CSO, DE","Cocoa - COI, US","Cody - COD, US","Coeur dalene - COE, US","Coffee point - CFA, US","Coffeyville - CFV, US","Cognac - CNG, FR","Coimbra - CBP, PT","Colac - XCO, AU","Colby - CBK, US","Cold bay - CDB, US","Cold lake - YOD, CA","Coldfoot - CXF, US","Coleman - COM, US","College park - CGS, US","College station - CLL, US","Collie - CIE, AU","Collins bay - YKC, CA","Colmar - CMR, FR","Cologne - BNJ, DE","Cologne/Bonn - CGN, DE","Colorado creek - KCR, US","Colorado springs - COS, US","Columbia - COA, US","Columbia - COU, US","COLUMBIA - CAE, US","Columbia - MRC, US","COLUMBUS - CMH, US","Columbus - CLU, US","Columbus - CUS, US","Columbus - CSG, US","Columbus - OLU, US","Colville lake - YCK, CA","Comiso - CIY, IT","Comitan - CJT, MX","Comox - YQQ, CA","Compton - CPM, US","Conakry - CKY, GN","Concord - CON, US","Concord - CCR, US","Concordia - CNK, US","Condoto - COG, CO","Connersville - CEV, US","Conroe - CXO, US","Constanta - CND, RO","Constantine - CZL, DZ","Coop point - YCP, CA","Cooper landing - JLA, US","Cooperstown - COP, US","COPENHAGEN - CPH, DK","Copper centre - CZC, US","Coppermine - YCO, CA","Coral harbour - YZS, CA","Corcoran - CRO, US","Cordova - CDV, US","Cordova city - CKU, US","Corinth - CRX, US","CORK - ORK, IE","Corn island - RNI, NI","Corner bay - CBA, US","Cornwall - YCC, CA","Coro - CZE, VE","Coronation - YCT, CA","Corozal - CZU, CO","CORPUS CHRISTI - CRP, US","Corsicana - CRS, US","Cortes bay - YCF, CA","Cortez-montezuma - CEZ, US","Cortland - CTX, US","Corvallis - CVO, US","Cotonou - COO, BJ","Cottbus - CBU, DE","Cottonwood - CTW, US","Cotulla - COT, US","Council bluffs - CBF, US","Council melsing creek - CIL, US","Courtenay - YCA, CA","Coventry - CVT, GB","Cowley - YYM, CA","Coyoles - CYL, HN","Cozumel - CZM, MX","Cradock - CDO, ZA","Craig-moffat - CIG, US","Craiova - CRA, RO","Cranbrook - YXC, CA","Crane - CCG, US","Crane island - CKR, US","Cravo norte - RAV, CO","Creil - CSF, FR","Crescent city - CEC, US","Crested butte - CSE, US","Creston - CSQ, US","Creston - YCZ, CA","Crestview - CEW, US","Crooked creek - CKD, US","Crookston - CKN, US","Cross city - CTY, US","Cross lake - YCR, CA","Crossett - CRT, US","Crossville - CSV, US","Crotone - CRV, IT","Crows landing - NRC, US","CROYDON - CDQ, GB","Crystal lake - CYE, US","Cuamba - FXO, MZ","Cube cove - CUW, US","Cuddapah - CDP, IN","Cuenca - CUE, EC","Cuernavaca - CVJ, MX","Cullaton lake - YCU, CA","Culver city - CVR, US","Cumberland - CBE, US","Cuneo - CUF, IT","Cushing - CUH, US","Cut bank - CTB, US","Cuyo - CYU, PH","Czestochowa - CZW, PL","Da Nang - DAD, VN","DACCA - DAC, BD","Dadu - DDU, PK","Daet - DTE, PH","Daggett - DAG, US","Dahl creek - DCK, US","Dahlgren - DGN, US","Dakar - DKR, SN","Dalaman - DLM, TR","Dalanzadgad - DLZ, MN","Dalat - DLI, VN","Dalbandin - DBA, PK","Dalhart - DHT, US","Dali city - DLU, CN","Dalian - DLC, CN","Dallas - DFW, US","Dallas addison - ADS, US","Daloa - DJO, CI","Dalton - DNN, US","Daman - NMB, IN","Damascus - DAM, SY","Dammam - SAR, US","Danane - DNC, CI","Danbury - DXR, US","Dandong - DDG, CN","Danger bay - DGB, US","Dangriga - DGA, BZ","Dansville - DSV, US","Danville - DNV, US","Danville - DAN, US","Dar Es Salaam - DAR, TZ","Dargaville - DGR, NZ","Darwin - DRW, AU","Datong - DAT, CN","Daugavpils - DGP, LV","Dauphin - YDN, CA","Davao - DVO, PH","Davenport - DVN, US","David - DAV, PA","Dawson - YDA, CA","Dawson creek - YDQ, CA","Daxian - DAX, CN","Dayton - DAY, US","Daytona beach - DAB, US","De ridder - DRI, US","Deadhorse - SCC, US","Dean river - YRD, CA","Dearborn - DEO, US","Dease lake - YDL, CA","Death valley - DTH, US","Debrecen - DEB, HU","Decatur - DEC, US","Decatur - DCU, US","Decatur - DCR, US","Decatur island - DTR, US","Deception - YGY, CA","Decimomannu - DCI, IT","Decorah - DEH, US","Deep bay - WDB, US","Deer lake - YDF, CA","Deer lake - YVZ, CA","Deer park - DPK, US","Deering - DRG, US","Defiance - DFI, US","Dehra dun - DED, IN","Del rio - DRT, US","Delhi - DEL, IN","Deline - YWJ, CA","Delta - DTA, US","Delta - DJN, US","Deming - DMN, US","Den helder - DHR, NL","Denison - DNS, US","DENPASAR BALI - DPS, ID","Denver - DEN, US","Denver arapahoe - APA, US","Dera ismail khan - DSK, PK","Des moines - DSM, US","Desolation sound - YDS, CA","Destin - DSI, US","Detroit - DTT, US","Detroit lakes - DTL, US","Deva - DVA, RO","Devils lake - DVL, US","Devonport - DPO, AU","Dhanbad - DBD, IN","Diapaga - DIP, BF","Dibrugarh - DIB, IN","Dickinson - DIK, US","Dien Bien Phu - DIN, VN","Digby - YDG, CA","Dijon - DIJ, FR","DILI - DIL, ID","Dillingham - DLG, US","Dillon - DLN, US","Dillon - DLL, US","Dimapur - DMU, IN","Dinard - DNR, FR","Diomede island - DIO, US","Dipolog - DPL, PH","Diqing - DIG, CN","Dire dawa - DIR, ET","Diu - DIU, IN","Divo - DIV, CI","Djibo - XDJ, BF","Djibouti - JIB, DJ","Djougou - DJA, BJ","Doc creek - YDX, CA","Dodge city - DDC, US","Doha - DOH, QA","Dolbeau-saint methode - YDO, CA","Dole - DLE, FR","Dolomi - DLO, US","Doncaster - DCS, GB","Dongguan - DGM, CN","Dongsheng - DSN, CN","Dora bay - DOF, US","Dori - DOR, BF","Dortmund - DTM, DE","Dothan - DHN, US","Douala - DLA, CM","Douglas - DGW, US","Douglas lake - DGF, CA","Dover - DVX, US","Doylestown - DYL, US","Drayton - YDC, CA","Dresden - DRS, DE","Drift river - DRF, US","Drummond - DRU, US","Drummond island - DRE, US","Dryden - YHD, CA","Dubai - DXB, AE","Dublin - DUB, IE","Dublin - DBN, US","Dublin - PSK, US","Dubois - DBS, US","Dubois - DUJ, US","Dubrovnik - DBV, HR","Dubuque - DBQ, US","Duck pine island - DUF, US","Dugway - DPG, US","Duisburg - DUI, DE","Duluth - DLH, US","Dumaguete - DGT, PH","Dumai - DUM, ID","Duncan - DUC, US","Duncan/quam - DUQ, CA","Dunhuang - DNH, CN","Dunkirk - DKK, US","Durant - DUA, US","Durazno - DZO, UY","Dushanbe - DYU, TJ","Dusseldorf - DUS, DE","Dzaoudzi - DZA, YT","Eagle - EAA, US","Eagle - EGE, US","Eagle lake - ELA, US","Eagle pass - EGP, US","Eagle river - EGV, US","Earlton - YXR, CA","East fork - EFO, US","East hampton - HTO, US","East hartford - EHT, US","East london - ELS, ZA","East main - ZEM, CA","East midlands - EMA, GB","East stroudsburg - ESP, US","East tawas - ECA, US","Eastland - ETN, US","Easton - ESW, US","Easton - ESN, US","Eastsound - ESD, US","Eau claire - EAU, US","Ebadon - EBN, MH","Ebolowa - EBW, CM","Edenton - EDE, US","Edgewood - EDG, US","Edinburgh - EDI, GB","Edna bay - EDA, US","Edson - YET, CA","Edwards afb - EDW, US","Eek - EEK, US","Egegik - EGX, US","Egelsbach - QEF, DE","Egilsstadir - EGS, IS","Eindhoven - EIN, NL","Eisenach - EIB, DE","Ekuk - KKU, US","Ekwok - KEK, US","El bagre - EBG, CO","El banco - ELB, CO","El cajon - CJN, US","El calafate - FTE, US","El charco - ECR, CO","El dorado - EDK, US","El dorado - ELD, US","El monte - EMT, US","El paso - ELP, US","El tigre - ELX, VE","Elat - ETH, IL","Elazig - EZS, TR","Elblag - ZBG, PL","Eldoret - EDL, KE","Eldred rock - ERO, US","Elim - ELI, US","Elista - ESL, RU","Elizabeth city - ECG, US","Elizabethtown - EKX, US","Elk city - ELK, US","Elkhart - EKI, US","Elkins - EKN, US","Elko - EKO, US","Ellamar - ELW, US","Ellensburg - ELN, US","Elliot lake - YEL, CA","Ellisras - ELL, ZA","Elmira - ELM, US","Ely - ELY, US","Ely - LYU, US","Emden - EME, DE","Emmonak - EMK, US","Empangeni - EMG, ZA","Emporia - EMP, US","Ende - ENE, ID","English bay - KEB, US","Enid woodring - WDG, US","Ennadai - YEI, CA","Enschede - ENS, NL","Ensenada - ESE, MX","Enshi - ENH, CN","ENTEBBE - EBB, UG","Enterprise - ETS, US","Ephrata - EPH, US","Erandique - EDQ, HN","Erfurt - ERF, DE","Erie - ERI, US","Errachidia - ERH, MA","Errol - ERR, US","Esbjerg - EBJ, DK","Escanaba - ESC, US","Eskilstuna - EKT, SE","Eskisehir - ESK, TR","Esler field - ESF, US","Espanola - ESO, US","Esquimalt - YPF, CA","Essaouira - ESU, MA","Essen - ESS, DE","Estevan - YEN, CA","Estevan point - YEP, CA","Estherville - EST, US","Eufaula - EUF, US","Eugene - EUG, US","Eunice - UCE, US","Eureka - YEU, CA","Eureka - EUE, US","EUREKA - ACV, US","Evadale - EVA, US","Evanston - EVW, US","Evansville - EVV, US","Eveleth - EVM, US","Everett - PAE, US","Excursion inlet - EXI, US","Exeter - EXT, GB","Fagernes - VDB, NO","FAIRBANKS - FAI, US","Fairbury - FBY, US","Fairfield - FFL, US","Fairfield - SUU, US","Fairmont - FRM, US","Fairview - ZFW, CA","Fakenham - FKH, GB","Falher - YOE, CA","Fallon - FLX, US","Falls bay - FLJ, US","False island - FAK, US","False pass - KFP, US","Farafangana - RVA, MG","Farewell - FWL, US","Fargo - FAR, US","Faribault - FBL, US","Farmingdale - FRG, US","Farmington - FMN, US","Farmington - FAM, US","Faro - FAO, PT","Faro - ZFA, CA","Farsund - FAN, NO","Faya - FYT, TD","Fayetteville - FYM, US","Fayetteville - FAY, US","Fayetteville - XNA, US","Fergus falls - FFM, US","Ferkessedougou - FEK, CI","Fez - FEZ, MA","Filadelfia - FLM, PY","Fillmore - FIL, US","Fin creek - FNK, US","Findlay - FDY, US","Finschhafen - FIN, PG","Firday harbor - FRD, US","Fire cove - FIC, US","Fishers island - FID, US","Five finger - FIV, US","Five mile - FMC, US","Flagstaff - FLG, US","Flat - FLT, US","Flateyri - FLI, IS","Flaxman island - FXM, US","Flensburg - FLF, DE","Flin flon - YFO, CA","Flint - FNT, US","Flippin - FLP, US","Florence - FLR, IT","Florence - FLO, US","Florencia - FLA, CO","Foggia - FOG, IT","Foley - NHX, US","Fond du lac - FLD, US","Fond-du-lac - ZFD, CA","Fontanges - YFG, CA","Forest city - FXY, US","Forest park   - FOP, US","Forestville - YFE, CA","Forrest city - FCY, US","Fort albany - YFA, CA","Fort belvoir - DAA, US","Fort bragg - FBG, US","Fort bragg - FOB, US","Fort bridger - FBR, US","Fort chaffee - CCA, US","Fort chipewyan - YPY, CA","Fort collins - FNL, US","Fort dix - WRI, US","Fort eustis - FAF, US","Fort frances - YAG, CA","Fort good hope - YGH, CA","Fort hope - YFH, CA","Fort indiantown - MUI, US","Fort irwin - BYS, US","Fort jefferson - RBN, US","Fort leavenworth - FLV, US","Fort leonard - TBN, US","Fort liard - YJF, CA","Fort madison - FMS, US","Fort mcmurray - YMM, CA","Fort mcpherson - ZFM, CA","Fort meade - FME, US","Fort nelson - YYE, CA","Fort norman - ZFN, CA","Fort pierce - FPR, US","Fort polk - POE, US","Fort providence - YJP, CA","Fort reliance - YFL, CA","Fort resolution - YFR, CA","Fort richardson - FRN, US","Fort riley - FRI, US","Fort scott - FSK, US","Fort severn - YER, CA","Fort sheridan - FSN, US","Fort sill - FSI, US","Fort simpson - YFS, CA","Fort smith - YSM, CA","Fort smith - FSM, US","Fort stockton - FST, US","Fort sumner - FSU, US","Fort walton beach - VPS, US","Fort yukon - FYU, US","Fortuna ledge - FTL, US","Fougamou - FOU, GA","Foumban - FOM, CM","Fox - FOX, US","Fox glacier - FGL, NZ","Francistown - FRW, BW","Frankfort - FFT, US","Frankfurt - FRA, DE","Franklin - FKL, US","Franklin - FKN, US","Franz josef - WHO, NZ","Frederick - FDK, US","Frederick - FDR, US","Fredericton - YFC, CA","Fredericton junction service - XFC, CA","Freeport - FEP, US","Fremont - FET, US","French lick - FRH, US","Frenchville - WFK, US","Fresh water bay - FRP, US","Friday harbor - FHR, US","Friday harbor spb - FBS, US","Friedrichshafen - FDH, DE","Front royal - FRR, US","Fryeburg - FRY, US","Ft. lauderdale - FLL, US","Ft.myers - FMY, US","Ft.wayne - FWA, US","Fuerte olimpo - OLK, PY","Fukue - FUJ, JP","Fukuoka - FUK, JP","Fukuyama - QFY, JP","Fullerton - FUL, US","Funchal - FNC, PT","Funter bay - FNR, US","Fushun - Fus, CN","Fuyang - FUG, CN","Fuyun - FYN, CN","Fuzhou - FOC, CN","Gabbs - GAB, US","Gaborone - GBE, BW","Gadsden - GAD, US","Gage - GAG, US","Gagetown - YCX, CA","Gagnoa - GGN, CI","Gagnon - YGA, CA","Gainesville - GNV, US","Gainesville - GLE, US","Gainesville - GVL, US","Gaithersburg - GAI, US","Gakona - GAK, US","Galbraith lake - GBH, US","Galena - GAL, US","Galesburg - GBG, US","Galion - GQQ, US","Gallup - GUP, US","Galveston - GLS, US","Gamarra - GRA, CO","Gambell - GAM, US","Gandajika - GDJ, ZR","Ganes creek - GEK, US","Ganges harbor - YGG, CA","Ganzhou - KOW, CN","Gaoua - XGA, BF","Garbaharey - GBM, SO","Garden city - GCK, US","Gardner - GDM, US","Garissa - GAS, KE","Garoua - GOU, CM","Garrow lake - GOW, CA","Gary - GYY, US","Gaspe - YGP, CA","Gatineau - YND, CA","Gatlinburg - GKT, US","Gauhati - GAU, IN","Gaya - GAY, IN","Gaylord - GLR, US","Gaziantep - GZT, TR","Gbadolite - BDT, ZR","Geelong - GEX, AU","Geilenkirchen - GKE, DE","Geilo - DLD, NO","Gelendzik - GDZ, RU","Gemena - GMA, ZR","Geneva - GVA, CH","Genoa - GOA, IT","George - GRJ, ZA","Georgetown - GED, US","Georgetown - GGE, US","Geraldton - YGQ, CA","Germansen - YGS, CA","Gethsemani - ZGS, CA","Gettysburg - GTY, US","Giebelstadt - GHF, DE","Gilgit - GIL, PK","Gillam - YGX, CA","Gillette - GCC, US","Gillies bay - YGB, CA","Gimli - YGM, CA","Girardot - GIR, CO","Gisborne - GIS, NZ","Giyani - GIY, ZA","Gjoa haven - YHK, CA","Glacier creek - KGZ, US","Gladwin - GDW, US","Glasgow - GGW, US","Glasgow - GLA, GB","Glasgow - GLW, US","Glendale - GWV, US","Glendive - GDV, US","Glennallen - GLQ, US","Glens falls - GFL, US","Glenview - NBU, US","Glenwood springs - GWS, US","Goa - GOI, IN","Gobabis - GOG, NA","Gods narrows - YGO, CA","Gods river - ZGI, CA","Gol - GLL, NO","Gold beach - GOL, US","Gold coast - OOL, AU","Golden horn - GDH, US","Goldsboro - GSB, US","Golfito - GLF, CR","Golmud - GOQ, CN","Golovin - GLV, US","Goma - GOM, ZR","Gondar - GDQ, ET","Gooding - GNG, US","Goodland - GLD, US","Goodnews bay - GNU, US","Goodyear - GYR, US","Goose bay - YYR, CA","Gorakhpur - GOP, IN","Gordon - GRN, US","Gordonsville - GVE, US","Gore bay - YZE, CA","Gorge harbor - YGE, CA","Goroka - GKA, PG","Gorom-gorom - XGG, BF","Goshen - GSH, US","Gothenburg - GOT, SE","Grand forks - GFK, US","Grand forks - ZGF, CA","Grand island - GRI, US","Grand junction - GJT, US","Grand marais - GRM, US","Grand rapids - GRR, US","Grand rapids - GPZ, US","Grande cache - YGC, CA","Grande prairie - YQU, CA","Grandview - GVW, US","Granite - GMT, US","Grants - GNT, US","Grantsburg - GTG, US","Granville lake - XGL, CA","Grayling - KGX, US","Great barrington - GBR, US","Great bear lake - DAS, CA","Great bend - GBD, US","Great falls - GTF, US","Greeley - GXY, US","Green bay - GRB, US","Green island - GNI, CN","Green river - RVR, US","Greenfield - GFD, US","GREENSBORO HIGH POINT - GSO, US","Greenville - GRE, US","Greenville - GMU, US","Greenville - GLH, US","Greenville - GCY, US","Greenville - GVT, US","Greenville - PGV, US","Greenway sound - YGN, CA","Greenwood - YZX, CA","Greenwood - GWO, US","Greenwood - GRD, US","GREER - GSP, US","Grenoble - GNB, FR","Greybull - GEY, US","Greymouth - GMN, NZ","Grise fiord - YGZ, CA","Grootfontein - GFY, NA","Grosseto - GRS, IT","Guadalajara - GDL, MX","Gualaco - GUO, HN","Guam - GUM, US","Guamal - GAA, CO","Guanaja - GJA, HN","Guanare - GUQ, VE","Guangyuan - Gua, CN","Guangzhou - CAN, CN","Guapiles - GPL, CR","Guasdualito - GDO, VE","Guayaquil - GYE, EC","Guaymas - GYM, MX","Guerrero negro - GUB, MX","Guiglo - GGO, CI","Guilin - KWL, CN","Guiyang - KWE, CN","Gulf shores - GUF, US","Gulkana - GKN, US","Guna - GUX, IN","Gunnison - GUC, US","Gunung stoli - GNS, ID","Gustavus - GST, US","Guthrie - GOK, US","Guymon - GUY, US","Gwadar - GWD, PK","Gwalior - GWL, IN","Gweru - GWE, ZW","Gympie - GYP, AU","Hachinohe - HHE, JP","Hagerstown - HGR, US","Hai Phong - HPH, VN","Haikou - HAK, CN","Hailar - HLD, CN","Haines - HNS, US","Haines junction - YHT, CA","Hakai pass - YHC, CA","Hakodate - HKD, JP","Half moon - HAF, US","Halifax - YHZ, CA","Halifax shearwater - YAW, CA","Hall beach - YUX, CA","Halmstad - HAD, SE","Hamburg - HAM, DE","Hami - HMI, CN","Hamilton - HAB, US","Hamilton - HAO, US","Hamilton - YHM, CA","Hammerfest - HFT, NO","Hampton - HPT, US","Hana - HNM, US","Hanalei - HPV, US","Hanapepe - PAK, US","Hancock - CMX, US","Hangzhou - HGH, CN","Hanimaadhoo - HAQ, MV","Hanksville - HVE, US","Hanna - HNX, US","Hanoi - HAN, VN","Hanover - HAJ, DE","Hanus bay - HBC, US","Hanzhong - HZG, CN","Harare - HRE, ZW","Harbin - HRB, CN","Hargeysa - HGA, SO","Harlingen - HRL, US","Harrisburg - HSB, US","Harrisburg middletown - MDT, US","Harrismith - HRS, ZA","Harrison - HRO, US","Harrogate - HRT, GB","HARTFORD - BDL, US","Hartford barnes - BNH, US","Hartley bay - YTB, CA","Hartsville - HVS, US","Hastings - HSI, US","Hasvik - HAA, NO","Hat yai - HDY, TH","Hatchet lake - YDW, CA","Hatchet lake - YDJ, CA","Hato corozal - HTZ, CO","Hatteras - HNC, US","Hattiesburg - HBG, US","Haugesund - HAU, NO","Havasupai - HAE, US","Haverfordwest - HAW, GB","Havre city - HVR, US","Havre saint pierre - YGV, CA","Hawk inlet - HWI, US","Hawthorne - HTH, US","Hawthorne - HHR, US","Hay river - YHY, CA","Haycock - HAY, US","Hayden - HDN, US","Hays - HYS, US","Hayward - HWD, US","Hayward - HYR, US","Hazebrouck - HZB, FR","Hazleton - HZL, US","Healy lake - HKB, US","Hearst - YHF, CA","Hefei - HFE, CN","Heide - HEI, DE","Heidelberg - HDB, DE","Heihe - HEK, CN","Helena - HEE, US","Helena - HLN, US","Helgoland - HGL, DE","Helsingborg - AGH, SE","Helsinki - HEL, FI","Hemet - HMT, US","Hengchun - HCN, CN","Hengyang - HNY, CN","Hepo - Hep, CN","Heraklion - HER, GR","Herendeen - HED, US","Heringsdorf - HDF, DE","Herlong - AHC, US","Hermiston - HES, US","Hermosillo - HMO, MX","Hervey bay - HVB, AU","Hickory - HKY, US","Hidden falls - HDA, US","High level - YOJ, CA","High prairie - ZHP, CA","High wycombe - HYC, GB","Hill city - HLC, US","Hillsboro - HIO, US","Hilo - ITO, US","Hilton head - HHH, US","Hilton head island - HXD, US","Hinesville - LIY, US","Hiroshima - HIJ, JP","Hobart - HBR, US","Hobart bay - HBH, US","Hof - HOQ, DE","Hoffman - HFF, US","Hogatza - HGZ, US","Hohhot - HET, CN","Hokitika - HKK, NZ","Holdrege - HDE, US","Holikachu - HOL, US","Holland - HLM, US","Hollis - HYL, US","Hollister - HLI, US","Hollywood - HWO, US","Holman - YHI, CA","Holy cross - HCR, US","Holyhead - HLY, GB","Homer - HOM, US","Homeshore - HMS, US","Homestead - HST, US","Hong Kong - HKG, CN","Honiara - HIR, SB","Honolulu - HNL, US","Hoonah - HNH, US","Hooper bay - HPB, US","Hope - YHE, CA","Hopkinsville - HOP, US","Hornepayne - YHN, CA","Horta - HOR, PT","Hot springs - HOT, US","Hot springs - HSP, US","Hotan - HTN, CN","Houghton - HTL, US","Houlton - HUL, US","Houma - HUM, US","Houston - HOU, US","Houston ellington - EFD, US","Hsinchu - HSZ, CN","Hua hin - HHQ, TH","Hualien - HUN, CN","Huangyan - HYN, CN","Huatulco - HUX, MX","Hubli - HBX, IN","Hudiksvall - HUV, SE","Hudson - HCC, US","Hudson bay - YHB, CA","Hudson hope - YNH, CA","Hue - HUI, VN","Hughes - HUS, US","Hugo - HUJ, US","Huizhou - HUZ, CN","Hukuntsi - HUK, BW","Humberside - HUY, GB","Humboldt - HUD, US","Humboldt - HBO, US","Huntingburg - HNB, US","Huntington - HTS, US","Huntsville - HTV, US","Huntsville - HSV, US","Hurghada - HRG, EG","Huron - HON, US","Huslia - HSL, US","Hutchison - HUT, US","Hvammstangi - HVM, IS","Hwange - WKI, ZW","Hyannis - HYA, US","Hydaburg - HYG, US","Hyderabad - HYD, IN","Ibadan - IBA, NG","Icy bay - ICY, US","Ida grove - IDG, US","IDAHO FALLS - IDA, US","Igarka - IAA, RU","Igiugig - IGG, US","Igloolik - YGT, CA","Ignace - ZUC, CA","Ihosy - IHO, MG","Ilebo - PFR, ZR","Ilford - ILF, CA","Iliamna - ILI, US","Iligan - IGN, PH","Ilimanaq - XIQ, GL","Ilo - ILQ, PE","Ilorin - ILR, NG","Immokalee - IMM, US","Imperial - IML, US","Imperial beach - NRS, US","Imphal - IMF, IN","Independence - IDP, US","Indian springs - INS, US","Indiana - IDI, US","Indianapolis - IND, US","Indore - IDR, IN","Inongo - INO, ZR","Inta - INA, RU","International falls - INL, US","Inukjuak - YPH, CA","Inuvik - YEV, CA","Invercargill - IVC, NZ","Inverlake - TIL, CA","Ioannina - IOA, GR","Iowa city - IOW, US","Iowa falls - IFA, US","Ipiales - IPI, CO","Ipil - IPE, PH","Ipoh - IPH, MY","Ipswich - IPW, GB","Iqaluit - YFB, CA","Iquique - IQQ, CL","Iquitos - IQT, PE","Iraan - IRB, US","Iron mountain - IMT, US","Ironwood - IWD, US","Isabel pass - ISL, US","Isachsen - YIC, CA","Ischia - ISH, IT","Ishigaki - ISG, JP","Isiro - IRP, ZR","Island lake/garden hill - YIV, CA","Isles of scilly - ISC, GB","Islip - ISP, US","Istanbul - IST, TR","Ithaca - ITH, US","Ivanof bay - KIB, US","Ivishak - IVH, US","Ivujivik - YIK, CA","Ixtepec - IZT, MX","Izhevsk - IJK, RU","Izumo - IZO, JP","Jabalpur - JLR, IN","Jabiru - JAB, AU","Jackpot - KPT, US","Jackson - MKL, US","Jackson - MJQ, US","JACKSON - JAN, US","Jackson - JXN, US","Jacksonville - JKV, US","JACKSONVILLE - JAX, US","Jacksonville - IJX, US","Jacksonville - LRF, US","Jacksonville - OAJ, US","Jacobabad - JAG, PK","Jaffrey - AFN, US","Jaipur - JAI, IN","Jaisalmer - JSA, IN","JAKARTA BANTEN - CGK, ID","Jambol - JAM, BG","Jamestown - JHW, US","Jamestown - JMS, US","Jammu - IXJ, IN","Jamnagar - JGA, IN","Jamshedpur - IXW, IN","Janesville - JVL, US","Jasper - JAS, US","Jasper - APT, US","Jauja - JAU, PE","Jaya pura - DJJ, ID","Jeddah - JED, SA","Jefferson - JFN, US","Jefferson - EFW, US","Jefferson city - JEF, US","Jeh - JEJ, MH","Jenpeg - ZJG, CA","Jerusalem - JRS, IL","Jiamusi - JMU, CN","Jiayuguan - JGN, CN","Jijiga - JIJ, ET","Jilin - JIL, CN","Jimma - JIM, ET","Jinan - TNA, CN","Jingdezhen - JDZ, CN","Jinghong - JHG, CN","Jinhua - Jin, CN","Jining - JNG, CN","Jinka - BCO, ET","Jinzhou - JNZ, CN","Jipijapa - JIP, EC","Jiujiang - JIU, CN","Jiuquan - CHW, CN","Jiuzhaigou - JZH, CN","Jiwani - JIW, PK","Jixi - Jix, CN","Jodhpur - JDH, IN","Joensuu - JOE, FI","JOHANNESBURG - JNB, ZA","John day - JDA, US","John f kennedy intl - JFK, US","Johnny mountain - YJO, CA","Johnson - JCY, US","Johnson point - YUN, CA","Johnstown - JST, US","Johor bahru - JHB, MY","Joliet - JOT, US","Jolo - JOL, PH","Jolon - HGT, US","Jonesboro - JBR, US","Joplin - JLN, US","Jordan - JDN, US","Jorhat - JRH, IN","Jos - JOS, NG","Juba - JUB, SD","Juist - JUI, DE","Juliaca - JUL, PE","Junction - JCT, US","Juneau - JNU, US","Juneau - UNU, US","Jurado - JUO, CO","Juticalpa - JUT, HN","Jwaneng - JWA, BW","Kabalo - KBO, ZR","Kabri Dar - ABK, ET","Kagvik creek - KKF, US","Kahului - OGG, US","Kaikohe - KKO, NZ","Kaiser/lake ozark - AIZ, US","Kaitaia - KAT, NZ","Kajaani - KAJ, FI","Kake - KAE, US","Kakhonak - KNK, US","Kalakaket - KKK, US","Kalamazoo - AZO, US","Kalaupapa - LUP, US","Kalibo - KLO, PH","Kalima - KLY, ZR","Kaliningrad - KGD, RU","Kalispell - FCA, US","Kalskag - KLG, US","Kaltag - KAL, US","Kamalpur - IXQ, IN","Kamina - KMN, ZR","Kamloops - YKA, CA","Kamuela - MUE, US","Kanab - KNB, US","Kandi - KDC, BJ","Kandla - IXY, IN","Kandrian - KDR, PG","Kangaamiut - QKT, GL","Kangerlussuaq - SFJ, GL","Kangiqsualujjuaq - XGR, CA","Kangirsuk - YKG, CA","Kangnung - KAG, KR","Kaniama - KNM, ZR","Kankakee - IKK, US","Kankan - KNN, GN","Kanpur - KNU, IN","KANSAS CITY - MKC, US","Kansas city - KCK, US","Kansas city intl apt - MCI, US","KAOHSIUNG - KHH, CN","Kapit - KPI, MY","Kapuskasing - YYU, CA","Karachi - KHI, PK","Karamay - KRY, CN","Karasburg - KAS, NA","Kariba - KAB, ZW","Karlovy vary - KLV, CZ","Karlskoga - KSK, SE","Karlstad - KSD, SE","Karluk - KYK, US","Karluk lake - KKL, US","Karratha - KTA, AU","Karup - KRP, DK","Kasaan - KXA, US","Kasabonika - XKS, CA","Kasba lake - YDU, CA","Kaschechewan - ZKE, CA","Kasigluk - KUK, US","Kassel - KSF, DE","Kathmandu - KTM, NP","Katiola - KTC, CI","Katowice - KTW, PL","Kauhajoki - KHJ, FI","Kauhava - KAU, FI","Kaunas - KUN, LT","Kavala - KVA, GR","Kavieng - KVG, PG","Kavik - VIK, US","Kaya - XKY, BF","Kayenta - MVM, US","Kayseri - ASR, TR","Kazan - KZN, RU","Kearney - EAR, US","Keene - EEN, US","Keetmanshoop - KMP, NA","Keewaywin - KEW, CA","Kegaska - ZKG, CA","Kekaha - BKH, US","Kelly bar - KEU, US","Kelowna - YLW, CA","Kelp bay - KLP, US","Kelsey - KES, CA","Kelso - KLS, US","Kemano - XKO, CA","Kemerer - EMM, US","Kemi - KEM, FI","Kenai - ENA, US","Kendari - KDI, ID","Kenema - KEN, SL","Keningau - KGU, MY","Kenitra - NNA, MA","Kenmore - KEH, US","Kennett - KNT, US","Kenora - YQK, CA","Kenosha - ENW, US","Kentland - KKT, US","Keokuk - EOK, US","Kerch - KHC, UA","Kerema - KMA, PG","Kericho - KEY, KE","Kerikeri - KKE, NZ","Kerkyra - CFU, GR","Kerrville - ERV, US","Kerteh - KTE, MY","Keshod - IXK, IN","Ketchikan - KTN, US","Key lake - YKJ, CA","Key largo - KYL, US","Key west - EYW, US","Khabarovsk - KHV, RU","Khajuraho - HJR, IN","Khartoum - KRT, SD","Khorramabad - KHD, IR","Khowai - IXN, IN","Khulna - KHL, BD","Khuzdar - KDD, PK","Kiana - IAN, US","Kiel - KEL, DE","Kieta - KIE, PG","KIEV - IEV, UA","Kigali - KGL, RW","Kikwit - KKW, ZR","Kilimanjaro - JRO, TZ","Kilimanjaro - JAR, US","Kill devil hills - FFA, US","Killaloe - YXI, CA","KILLEEN - ILE, US","Killineq - XBW, CA","Kimberley - YQE, CA","Kincardine township - YKD, CA","Kindersley - YKY, CA","Kindu - KND, ZR","King city - KIC, US","King cove - KVC, US","King of prussia - KPD, US","King salmon - AKN, US","Kingaroy - KGY, AU","Kingfisher lake - KIF, CA","Kingman - IGM, US","King's lynn - KNF, GB","Kingston - YGK, CA","Kingsville - NQI, US","Kinmen - KNH, CN","Kinoosao - KNY, CA","Kinston - ISO, US","Kipnuk - KPN, US","Kirakira - IRA, SB","Kirkenes - KKN, NO","Kirkland lake - YKX, CA","Kirksville - IRK, US","Kirkuk - KIK, IQ","Kiruna - KRN, SE","Kisangani - FKI, ZR","Kismayo - KMU, SO","Kissimmee - ISM, US","Kisumu - KIS, KE","Kitakyushu - KKJ, JP","Kitale - KTL, KE","Kitchener lake - YKF, CA","Kitee - KTQ, FI","Kitimat - YKI, CA","Kitkatla - YKK, CA","Kitoi bay - KKB, US","Kitwe - KIW, ZM","Kitzingen - KZG, DE","Kiunga - UNG, PG","Kivalina - KVL, US","Kizhuyak - KZH, US","Klag bay - KBK, US","Klaipeda - KLJ, LT","Klamath falls - LMT, US","Klawock - KLW, US","Klemtu - YKT, CA","Klerksdorp - KXE, ZA","Knee lake - YKE, CA","Knights inlet - KNV, CA","Knoxville - TYS, US","Koala - YOA, CA","Kobe - UKB, JP","Kobuk - OBU, US","Kogalym - KGP, RU","Kohat - OHT, PK","Kokkola - KOK, FI","Kokomo - OKK, US","Kokoro - KOR, PG","Kolhapur - KLH, IN","Kolwezi - KWZ, ZR","Komatipoort - KOF, ZA","Komatsu - KMQ, JP","Komsomolsk na amure - KXK, RU","KONA - KOA, US","Kongiganak - KKH, US","Kongolo - KOO, ZR","Kontum - KON, VN","Korhogo - HGO, CI","Korla - KRL, CN","Koror - ROR, PW","Kos - KGS, GR","Kosciusko - OSX, US","Kosice - KSC, SK","Koszalin - OSZ, PL","Kota - KTU, IN","Kota kinabalu - BKI, MY","Kotlas - KSZ, RU","Kotlik - KOT, US","Kotzebue - OTZ, US","Koulamoutou - KOU, GA","Koyuk - KKA, US","Koyukuk - KYU, US","Kribi - KBI, CM","Kristiansand - KRS, NO","Kristianstad - KID, SE","Kristiansund - KSU, NO","Kuala belait - KUB, BN","Kuala lumpur - KUL, MY","Kuala terengganu - TGG, MY","Kuantan - KUA, MY","Kuching - KCH, MY","Kudat - KUD, MY","Kugururok river - KUW, US","Kulik - LKK, US","Kulusuk - KUS, GL","Kumasi - KMS, GH","Kunming - KMG, CN","Kunsan - KUV, KR","Kununurra - KNX, AU","Kuopio - KUO, FI","Kupang - KOE, ID","Kuparuk - UUK, US","Kuqa - KCA, CN","Kuressaare - URE, EE","Kuruman - KMH, ZA","Kushiro - KUH, JP","Kutaisi - KUT, GE","Kuujjuaq - YVP, CA","Kuujjuarapik - YGW, CA","Kuusamo - KAO, FI","Kwangju - KWJ, KR","Kwethluk - KWT, US","Kwigillingok - KWK, US","Kyoto - UKY, JP","La ceiba - LCE, HN","La crosse - LSE, US","La forges - YLF, CA","La grande - LGD, US","La grange - LGC, US","La guaira - LAG, VE","La macaza - YFJ, CA","La palma del condada - NDO, ES","La rochelle - LRH, FR","La romana - LRM, DO","La ronge - YVC, CA","La sarre - SSQ, CA","La serena - LSC, CL","La tabatiere - ZLT, CA","La tuque - YLQ, CA","La verne - POC, US","Labasa - LBS, FJ","Labouchere bay - WLB, US","Labuan - LBU, MY","Lac biche - YLB, CA","Lac brochet - XLB, CA","Lac la martre - YLE, CA","Laconia - LCI, US","Lady franklin - YUJ, CA","Lafayette - LFT, US","Lafayette - LAF, US","Lagos - LOS, NG","Lagos de moreno - LOM, MX","Laguardia apt - LGA, US","Lagunillas - LGY, VE","Lahad datu - LDU, MY","Lahr - LHA, DE","Lake charles - LCH, US","Lake geneva - XES, US","Lake harbour - YLC, CA","Lake jackson - LJN, US","Lake minchumina - LMA, US","Lake placid - LKP, US","Lakehurst - NEL, US","Lakeland - LAL, US","Lakeside - LKS, US","Lakeview - LKV, US","Lakota - LKT, CI","Lakselv - LKL, NO","Lalibela - LLI, ET","Lamar - LAA, US","Lamu - LAU, KE","Lanai city - LNY, US","Lancaster - LNS, US","Lancaster - RZH, US","Lancaster/palmdale - WJF, US","Lander - LND, US","Landivisiau - LDV, FR","Langara - YLA, CA","Langeoog - LGO, DE","LANGKAWI - LGK, MY","Lannion - LAI, FR","Lansdowne house - YLH, CA","Lansing - LAN, US","Lanzhou - LHW, CN","Laoag - LAO, PH","Laporte - LPO, US","Lappeenranta - LPP, FI","Laramie - LAR, US","Laredo - LRD, US","Larnaca - LCA, CY","Larsen bay - KLN, US","Las cruces - LRU, US","Las Palmas - LPA, ES","LAS VEGAS - LAS, US","Las vegas - LVS, US","Las vegas north - VGT, US","Latacunga - LTX, EC","Lathrop - LTH, US","Lathrop - LRO, US","Latrobe - LBE, US","Launceston - LST, AU","Laurel - LUL, US","Laurie river - LRQ, CA","Laval - LVA, FR","Lawrence - LWC, US","Lawrence - LWM, US","Lawrenceville - LWV, US","Lawrenceville - LVL, US","Lawton - LAW, US","Le castellet - CTT, FR","Le havre - LEH, FR","Le mans - LME, FR","Leadville - LXV, US","Leaf bay - XLF, CA","Leaf rapids - YLR, CA","Lebanon - LEB, US","Lebel-sur-quevillon - YLS, CA","Lecce - LCC, IT","Leeds - LBA, GB","Leesburg - LEE, US","Leeuwarden - LWR, NL","Leh - IXL, IN","Leiden - LID, NL","Leipzig - LEJ, DE","Leknes - LKN, NO","Lelystad - LEY, NL","Lemars - LRJ, US","Lemmon - LEM, US","Lemoore - NLC, US","Lemwerder - XLW, DE","Leonardtown - LTW, US","Lethbridge - YQL, CA","Lethem - LTM, GY","Letterkenny - LTR, IE","Levelock - KLL, US","Lewisburg - LWB, US","Lewiston - LWS, US","Lewistown - LWT, US","Lexington - LXN, US","Lexington - LEX, US","Lhasa - LXA, CN","Lianyungang - LYG, CN","Liberal - LBL, US","Libreville - LBV, GA","Lichinga - VXC, MZ","Lihue - LIH, US","Lijiang city - LJG, CN","Lille - LIL, FR","Lilongwe - LLW, MW","Lima - LIM, PE","Lima allen county - AOH, US","Limbang - LMN, MY","Limbe - VCC, CM","Lime village - LVD, US","Limestone - LIZ, US","Limoges - LIG, FR","Limon - LIC, US","Lincoln - LNK, US","Lincoln rock - LRK, US","Linden - LDJ, US","Linxi - LXI, CN","Linyi - LYI, CN","Lisala - LIQ, ZR","Lisbon - LIS, PT","Lishan - LHN, CN","Little grand rapids - ZGR, CA","Little naukati - WLN, US","Little port walter - LPW, US","Little rock - LIT, US","Liuzhou - LZH, CN","Livengood - LIV, US","Livermore - LVK, US","Liverpool - LPL, GB","Liverpool - YAU, CA","Livingston - LVM, US","Livingstone - LVI, ZM","Ljubljana - LJU, SI","Lloydminster - YLL, CA","Lobatse - LOQ, BW","Lock haven - LHV, US","Lockport - LOT, US","Lodja - LJA, ZR","Lodwar - LOK, KE","Logan - LGU, US","Lompoc - LPC, US","London - LOZ, US","London - YXU, GB","Lone rock - LNR, US","Lonely - LNI, US","Long beach - LGB, US","Long island - LIJ, US","Long point - YLX, CA","Long Xuyen - XLO, VN","Longview - LOG, US","Longview - GGG, US","Lopez - LPS, US","Lordsburg - LSB, US","Lorient - LRT, FR","Loring - WLR, US","Los alamos - LAM, US","Los andes - LOB, CL","LOS ANGELES - LAX, US","Los Angeles - QLA, US","Los banos - LSN, US","Los chiles - LSL, CR","Los mochis - LMM, MX","Lossiemouth - LMO, GB","Lost harbor - LHB, US","Lost river - LSR, US","Louis trichardt - LCD, ZA","Louisa - LOW, US","Louisburg - LFN, US","Louisville - LMS, US","LOUISVILLE - SDF, US","Lovelock - LOL, US","Lubang - LBX, PH","Lubbock - LBB, US","Lubumbashi - FBM, ZR","Lucca - LCV, IT","Lucenec - LUE, SK","Lucknow - LKO, IN","Ludhiana - LUH, IN","Ludington - LDM, US","Lugano - LUG, CH","Lumberton - LBT, US","Luoyang - LYA, CN","Lupin - YWO, CA","Lusaka - LUN, ZM","Lusambo - LBO, ZR","Lushoto - LUY, TZ","Lusk - LSK, US","Luwuk - LUW, ID","Luxembourg - LUX, LU","Luxor - LXR, EG","Luzhou - LZO, CN","LUZON ISLAND CLARK FIELD - CRK, PH","Lyall harbour - YAJ, CA","Lydd - LYX, GB","Lynchburg - LYH, US","Lyndonville - LLX, US","Lyneham - LYE, GB","Lynn lake - YYL, CA","LYON - LYS, FR","Lyons - LYO, US","Maastricht - MST, NL","Mabai - Mab, CN","Mabaruma - USI, GY","Macanal - NAD, CO","Macas - XMS, EC","Macau - MFM, CN","Machala - MCH, EC","Machrihanish - GQJ, GB","Mackay - MKY, AU","Mackinac island - MCD, US","Macmillan pass - XMP, CA","Macomb - MQB, US","Madera - MAE, US","Madison - MDN, US","Madison - MPE, US","Madison - MSN, US","Madison - XMD, US","MADRAS - MAA, IN","Madras city - MDJ, US","Madrid - MAD, ES","Madurai - IXM, IN","Mae sot - MAQ, TH","Magadan - GDX, RU","Magdagachi - GDG, RU","Magnitogorsk - MQF, RU","Magnolia - AGO, US","Mahanoro - VVB, MG","Mahe Island - SEZ, SC","Maicao - MCJ, CO","Maiduguri - MIU, NG","Main duck - YDK, CA","Makhachkala - MCX, RU","Makung - MZG, CN","Makurdi - MDI, NG","Malabang - MLP, PH","Malabo - SSG, GQ","Malad city - MLD, US","Malaga - AGP, ES","Malakal - MAK, SD","Malang - MLG, ID","Malatya - MLX, TR","Malden - MAW, US","Male - MLE, MV","Malindi - MYD, KE","Malta - MLK, US","Mamburao - MBO, PH","Mamfe - MMF, CM","Mammoth lakes - MMH, US","Man - MJC, CI","Manado - MDC, ID","Managua - MGA, NI","Manakara - WVK, MG","Mananara - WMR, MG","Mananjary - MNJ, MG","Manassas - MNZ, US","Manaus - MAO, BR","Manchester - MAN, GB","Manchester - MHT, US","Mandera - NDE, KE","Manhattan - MHK, US","Manila - MNL, PH","Manila - MXA, US","Maningrida - MNG, AU","Manistee - MBL, US","Manistique - ISQ, US","Manitouwadge - YMG, CA","Manitowaning - YEM, CA","Manitowoc - MTW, US","Maniwaki - YMW, CA","Manizales - MZL, CO","Mankato - MKT, US","Mankono - MOK, CI","Manley - MLY, US","Mannheim - MHG, DE","Manokotak - KMO, US","Manokwari - MKW, ID","Manono - MNO, ZR","Mansehra - HRA, PK","Mansfield - MFD, US","Manta - MEC, EC","Manteo - MEO, US","Manti - NTJ, US","Manville - JVI, US","Manzanillo - MZO, CU","Maple bay - YAQ, CA","Maputo - MPM, MZ","Maracaibo - MAR, VE","Maracay - MYC, VE","Maramag - XMA, PH","Marana - MZJ, US","Marathon - YSP, CA","Marathon - MTH, US","Marble canyon - MYH, US","Marcala - MRJ, HN","Marco island - MRK, US","Mareeba - MRG, AU","Marfa - MRF, US","Marguerite bay - RTE, US","Maribo - MRW, DK","Maribor - MBX, SI","Marion - MNN, US","Marion - MWA, US","Marion - MZZ, US","Maripasoula - MPY, GF","Mariquita - MQU, CO","Mariupol - MPW, UA","Marks - MMS, US","Marlborough - MXG, US","Maroantsetra - WMN, MG","Maroua - MVR, CM","Marquette - MQT, US","Marsabit - RBT, KE","Marseille - MRS, FR","Marshall - MML, US","Marshall - MLL, US","Marshall - MHL, US","Marshall - ASL, US","Marshalltown - MIW, US","Marshfield - MFI, US","Martinsburg - MRB, US","Marysville - MYV, US","Masasi - XMI, TZ","Masbate - MBT, PH","Mason city - MCW, US","Massena - MSS, US","Masset - ZMT, CA","Masterton - MRO, NZ","Matadi - MAT, ZR","Matagami - YNM, CA","Matagorda island - MGI, US","Matamata - MTA, NZ","Matamoros - MAM, MX","Matane - YME, CA","Mataram - AMI, ID","Mati - MXI, PH","Matsu - MFK, CN","Matsumoto - MMJ, JP","Matsuyama - MYJ, JP","Mattoon - MTO, US","Maumere - MOF, ID","Maun - MUB, BW","Maxton - MXE, US","May creek - MYK, US","Mayo - YMA, CA","Mayport - NRB, US","Mbahiakro - XMB, CI","Mbandaka - MDK, ZR","Mbigou - MBC, GA","Mc alester - MLC, US","Mc rae - MQW, US","Mcallen - MFE, US","Mccall - MYL, US","Mccarthy - MXY, US","Mccomb - MCB, US","Mccook - MCK, US","Mcgrath - MCG, US","Mcminnville - RNC, US","Mcpherson - MPR, US","Meadow lake - YLJ, CA","Meadville - MEJ, US","Medan - MES, ID","MEDFORD - MFR, US","Medford - MDF, US","Medfra - MDR, US","Medicine hat - YXH, CA","Mehamn - MEH, NO","Meknes - MEK, MA","Mekoryuk - MYU, US","Melbourne - MEL, AU","Melbourne - MLB, US","Melfa - MFV, US","Melo - MLZ, UY","Memphis - MEM, US","Mende - MEN, FR","Mendi - NDM, ET","Menominee - MNM, US","Merced - MCE, US","Mercury - DRA, US","Meridian - MEI, US","Merrill - RRL, US","Merritt - YMB, CA","Merry island - YMR, CA","Mersing - MEP, MY","Merzifon - MZH, TR","Mesa - MSC, US","Mesquite - MFH, US","Metro wayne co apt - DTW, US","Metz - MZM, FR","Mexicali - MXL, MX","MEXICO - MEX, MX","Meyers chuck - WMK, US","MIAMI - MIA, US","Miami - MIO, US","Miandrivazo - ZVA, MG","Michigan city - MGC, US","Middleton island - MDO, US","Middletown - MWO, US","MIDLAND - MAF, US","Mikkeli - MIK, FI","Milan - MIL, IT","Mildenhall - MHZ, GB","Mildura - MQL, AU","Miles city - MLS, US","Milingimbi - MGT, AU","Milledgeville - MLJ, US","Millinocket - MLT, US","Millville - MIV, US","Milton - NSE, US","Milton keynes - KYN, GB","MILWAUKEE - MKE, US","Minaki - YMI, CA","Minchumina - MHM, US","Minden - MEV, US","Mineral wells - MWL, US","Mineralnyye vody - MRV, RU","Miners bay - YAV, CA","Mingan - YLP, CA","Minna - MXJ, NG","MINNEAPOLIS ST PAUL - MSP, US","Minocqua - ARV, US","Minot - MOT, US","Minto - MNT, US","Minvoul - MVX, GA","Miri - MYY, MY","Mirpur khas - MPD, PK","Misawa - MSJ, JP","Miskolc - MCQ, HU","Missoula - MSO, US","Mitchell - MHE, US","Mitzic - MZC, GA","Miyazaki - KMI, JP","Mizan teferi - MTF, ET","Mmabatho - MBD, ZA","Mo i rana - MQN, NO","Moa - MOA, CU","Moab - CNY, US","Moanda - MFF, GA","Moba - BDV, ZR","Moberly - MBY, US","Mobile - MOB, US","Mobridge - MBG, US","Modesto - MOD, US","Moengo - MOJ, SR","Mogadishu - MGQ, SO","Mojave - MHV, US","Mokpo - MPK, KR","Mokuleia - HDH, US","Mombasa Moi - MBA, KE","MONACO - XMM, MC","Monahans - MIF, US","Monclova - LOV, MX","Moncton - YQM, CA","Mongo - MVO, TD","Monkey bay - MYZ, MW","Monroe - MLU, US","Monroeville - MVC, US","Mont joli - YYY, CA","Montagne harbor - YMF, CA","Montague - SIY, US","Montauk - MTP, US","Monte carlo - MCM, MC","Monteagudo - MHW, BO","Montego bay - MBJ, JM","Montepuez - MTU, MZ","Monterey - MRY, US","Montevideo - MVD, UY","Montevideo - MVE, US","Montgomery - MGJ, US","Montgomery - MGM, US","Monticello - MSV, US","Monticello - MXO, US","Monticello - MXC, US","Montpelier - MPV, US","Montpellier - MPL, FR","MONTREAL - YMQ, CA","Montrose - MTJ, US","Montvale - QMV, US","Monument valley - GMV, US","Moose jaw - YMJ, CA","Moose lake - YAD, CA","Moosonee - YMO, CA","Moranbah - MOV, AU","Morelia - MLM, MX","Morganton - MRN, US","Morgantown - MGW, US","Morioka - HNA, JP","Morlaix - MXN, FR","Morondava - MOQ, MG","Morrilton - MPJ, US","Morris - MOX, US","Morristown - MOR, US","Morristown - MMU, US","Moscow - MOW, RU","Moser bay - KMY, US","MOSES LAKE - MWH, US","Moses point - MOS, US","Mosinee - CWA, US","Mosquera - MQR, CO","Mostar - OMO, BA","Mosteiros - MTI, CV","Motueka - MZP, NZ","Mouila - MJL, GA","Mould bay - YMD, CA","Moundou - MQQ, TD","Mount gambier - MGB, AU","Mount hagen - HGU, PG","Mount holly - LLY, US","Mount isa - ISA, AU","Mount mckinley - MCL, US","Mount pleasant - MPZ, US","Mount pleasant - MPS, US","Mount pleasant - MSD, US","Mount pleasant - MOP, US","Mount pocono - MPO, US","Mount shasta - MHS, US","Mount union - MUU, US","Mount vernon - MVW, US","Mount vernon - MVN, US","Mount wilson - MWS, US","Mountain home - WMH, US","Mountain view - NUQ, US","Mountain village - MOU, US","Moyale - MYS, ET","Moyobamba - MBP, PE","Mudanjiang - MDG, CN","Muenster - FMO, DE","Mulatupo - MPP, PA","Mulhouse - EAP, FR","Mullen - MHN, US","Muncie - MIE, US","Munich - MUC, DE","Municipal - YBL, CA","Murray - CEY, US","Murray bay - YML, CA","Mus - MSR, TR","Muscat - MCT, OM","Muscatine - MUT, US","Muscle shoals - MSL, US","Muskegon - MKG, US","Muskoka - YQA, CA","Muskrat dam - MSA, CA","Musoma - MUZ, TZ","Mutare - UTA, ZW","Muzaffarabad - MFG, PK","Muzaffarnagar - MZA, IN","Muzaffarpur - MZU, IN","Mwadui - MWN, TZ","Mweka - MEW, ZR","MYRTLE BEACH - MYR, US","Mytilene - MJT, GR","Mzuzu - ZZU, MW","Nabire - NBX, ID","Nacala - MNC, MZ","Nachingwea - NCH, TZ","Nacogdoches - LFK, US","Nadi - NAN, FJ","Nador - NDR, MA","Nadym - NYM, RU","Naga - WNP, PH","Nagasaki - NGS, JP","Nagoya - NGO, JP","Nagpur - NAG, IN","NAIROBI - NBO, KE","Nakashibetsu - SHB, JP","Nakina - YQN, CA","Naknek - NNK, US","Nakolik - NOL, US","Nakuru - NUU, KE","Nalchik - NAL, RU","Namatanai - ATN, PG","Nambour - NBR, AU","Namsos - OSY, NO","Namu - ZNU, CA","Nanchang - KHN, CN","Nanchong - NAO, CN","Nancy - ENC, FR","Nanded - NDC, IN","NANGJIN - NKG, CN","Nanisivik - YSR, CA","Nanning - NNG, CN","Nanortalik - JNN, GL","Nantes - NTE, FR","Nantong - NTG, CN","Nantucket - ACK, US","Nanyang - NNY, CN","Nanyuki - NYK, KE","Napa county - APC, US","Napakiak - WNA, US","Napaskiak - PKA, US","Naples - NAP, IT","Naples - APF, US","Narsaq kujalleq - QFN, GL","Narsarsuaq - UAK, GL","Narvik - NVK, NO","Naryan-mar - NNM, RU","Nashua - ASH, US","NASHVILLE - BNA, US","Natashquan - YNA, CA","Natchez - HEZ, US","Natitingou - NAE, BJ","Naukiti - NKI, US","Nawabshah - WNS, PK","Ndola - NLA, ZM","Needles - EED, US","Neftekamsk - NEF, RU","Nefteyugansk - NFG, RU","Negginan - ZNG, CA","Negril - NEG, JM","Nehe - Neh, CN","Neiva - NVA, CO","Nelson lagoon - NLG, US","Nelspruit - NLP, ZA","Nemiscau - YNS, CA","Nenana - ENN, US","Neosho - EOS, US","Nephi - NPH, US","Neryungri - NER, RU","Neubrandenburg - FNB, DE","Nevada - NVD, US","Nevers - NVS, FR","New bedford - EWB, US","New bern - EWN, US","New chenega - NCN, US","New haven - HVN, US","New koliganek - KGK, US","New london - GON, US","NEW ORLEANS - MSY, US","New philadelphia - PHD, US","New plymouth - NPL, NZ","New richmond - RNH, US","New stuyahok - KNW, US","New ulm - ULM, US","New york - YOR, US","NEW YORK CITY - NYC, US","Newark - EWR, US","Newburgh - SWF, US","Newcastle - NCL, GB","Newcastle - ECS, US","Newcastle under lyme - VLF, GB","Newport - NPT, US","Newport - NWH, US","Newport - ONP, US","Newport - EFK, US","Newport news - PHF, US","Newquay - NQY, GB","Newtok - WWT, US","Newton - TNU, US","Newton city - EWK, US","Neyveli - NVY, IN","Ngukurr - RPM, AU","Nha-Trang - NHA, VN","Niagara falls - IAG, US","Niamey - NIM, NE","Niblack - NIE, US","Nice - NCE, FR","Nichen cove - NKV, US","Nicosia - NIC, CY","Nicoya - NCT, CR","Nieuw nickerie - ICK, SR","Nightmute - NME, US","Niihama - IHA, JP","Nikolai - NIB, US","Nikolski - IKO, US","Niles - NLE, US","Ningbo - NGB, CN","Ninilchik - NIN, US","Nioki - NIO, ZR","Niort - NIT, FR","Nis - INI, YU","Nishinoomote - IIN, JP","Nitchequon - YNI, CA","Nizhnevartovsk - NJC, RU","Njombe - JOM, TZ","Nkan - NKA, GA","Nkongsamba - NKS, CM","Noatak - WTK, US","Nogales - OLS, US","Nome - OME, US","Nondalton - NNL, US","Nongan - Non, CN","Noorvik - ORV, US","Nootka sound - YNK, CA","Norddeich - NOE, DE","Norden - NOD, DE","Norderney - NRD, DE","Nordholz - NDZ, DE","Norfolk - ORF, US","Norfolk - OFK, US","Norilsk - NSK, RU","Norman - OUN, US","Norman wells - YVQ, CA","Norridgewock - OWK, US","North battleford - YQW, CA","North bay - YYB, CA","North bend - OTH, US","North platte - LBF, US","North spirit lake - YNO, CA","Northbrook - OBK, US","Northeast cape - OHC, US","Northolt - NHT, GB","Northway - ORT, US","Norway house - YNE, CA","Norwich - OIC, US","Norwich - NWI, GB","Norwood - OWD, US","Notodden - NTB, NO","Nottingham - NQT, GB","Nouadhibou - NDB, MR","Nouakchott - NKC, MR","Nouna - XNU, BF","Novato - NOT, US","Novokuznetsk - NOZ, RU","Novorossijsk - NOI, RU","Novosibirsk - OVB, RU","Nueva gerona - GER, CU","Nueva guinea - NVG, NI","Nuevo laredo - NLD, MX","Nuiqsut - NUI, US","Nulato - NUL, US","Null - EFB, US","Nunapitchuk - NUP, US","Nuremberg - NUE, DE","Nushki - NHS, PK","Nuuk - GOH, GL","Nyac - ZNC, US","Nyeri - NYE, KE","Oak harbor - ODW, US","Oakland - OAK, US","Oaktown - OTN, US","Oamaru - OAM, NZ","Oberpfaffenhofen - OBF, DE","Obihiro - OBO, JP","Ocala - OCF, US","Ocean city - OCE, US","Ocean falls - ZOF, CA","Ocean reef - OCA, US","Oceana - NTU, US","Oceanic - OCI, US","Oceanside - OCN, US","Ocho rios - OCJ, JM","Odense - ODE, DK","Odienne - KEO, CI","Odiham - ODH, GB","Ogallala - OGA, US","Ogden - OGD, US","Ogdensburg - OGS, US","Ogoki post - YOG, CA","Ohare international apt - ORD, US","Ohotsk - OHO, RU","Ohrid - OHD, MK","Oil city - OIL, US","Oita - OIT, JP","Okeechobee - OBE, US","Okinawa - OKA, JP","Oklahoma city - OKC, US","Okmulgee - OKM, US","Olanchito - OAN, HN","Old crow - YOC, CA","Old fort bay - ZFB, CA","Old harbor - OLH, US","Old town - OLD, US","Olean - OLE, US","Olga bay - KOY, US","Olive branch - OLV, US","Olney - OLY, US","Olney - ONY, US","Olomouc - OLO, CZ","Olsztyn - QYO, PL","Olympia - OLM, US","OMAHA - OMA, US","Omak - OMK, US","Omsk - OMS, RU","Omura - OMJ, JP","Ondangwa - OND, NA","Oneill - ONL, US","Oneonta - ONH, US","Onion bay - ONN, US","Ontario - ONO, US","Ontario - ONT, US","Opapamiska lake musselwhite - YBS, CA","Opelousas - OPL, US","Oradea - OMR, RO","Orangeburg - OGB, US","Oranjemund - OMD, NA","Orapa - ORP, BW","Orchid island - KYD, CN","Orlando - ORL, US","Ormara - ORW, PK","Ormoc - OMC, PH","Oroville - OVE, US","Orsk - OSW, RU","Oruro - ORU, BO","Osage beach - OSB, US","Osaka - OSA, JP","Osceola - OEO, US","Oscoda - OSC, US","Oshakati - OHI, NA","Oshawa - YOO, CA","Oshkosh - OKS, US","Oshkosh - OSH, US","Osijek - OSI, HR","Oskaloosa - OOA, US","Oskarshamn - OSK, SE","OSLO - OSL, NO","Osmanabad - OMN, IN","Osorno - ZOS, CL","Ostend - OST, BE","Ostrava - OSR, CZ","Otjiwarongo - OTJ, NA","Otto - OTO, US","Ottumwa - OTM, US","Ouagadougou - OUA, BF","Ouahigouya - OUG, BF","Ouarzazate - OZZ, MA","Oudtshoorn - OUH, ZA","Oujda - OUD, MA","Oulu - OUL, FI","Ouzinkie - KOZ, US","Ovalle - OVL, CL","Owatonna - OWA, US","Owen sound - YOS, CA","Owensboro - OWB, US","Oxford - OXD, US","Oxford - UOX, US","Oxford /waterbury - OXC, US","Oxford house - YOH, CA","Oxnard - OXR, US","Oyem - OYE, GA","Ozamiz - OZC, PH","Ozark - OZR, US","Ozona - OZA, US","Pacific city - PFC, US","Pack creek - PBK, US","Padang - PDG, ID","Paderborn - PAD, DE","Paducah - PAH, US","Paf warren - PFA, US","Pagadian - PAG, PH","Page - PGA, US","Pagosa springs - PGO, US","Pahokee - PHK, US","Paimiut - PMU, US","Painesville - PVZ, US","Painter creek - PCE, US","Pakuashipi - YIF, CA","Pala - PLF, TD","Palacios - PSX, US","Palanga - PLQ, LT","Palembang - PLM, ID","Palenque - PQM, MX","Palermo - PMO, IT","Palestine - PSN, US","PALM SPRINGS - PSP, US","Palma de Mallorca - PMI, ES","Palmdale - PMD, US","Palmer - PMX, US","Palmer - PAQ, US","Palmerston north - PMR, NZ","Palo alto - PAO, US","Palu - PLW, ID","Pama - XPA, BF","Pampa - PPA, US","Panama city - PFN, US","Panevezys - PNV, LT","Pangkal pinang - PGK, ID","Pangkalanbuun - PKN, ID","Pangnirtung - YXP, CA","Panguitch - PNU, US","Pantelleria - PNL, IT","Paonia - WPO, US","Papeete - PPT, PF","Paragould - PGR, US","Parakou - PKO, BJ","Paratebueno - EUO, CO","Pardubice - PED, CZ","Paris - PAR, FR","Paris - PHT, US","Paris - PRX, US","Park falls - PKF, US","Park rapids - PKD, US","Parks - KPK, US","Parma - PMF, IT","Parry sound - YPD, CA","Parsons - PPF, US","Pascagoula - PGL, US","Pasco - PSC, US","Pasighat - IXT, IN","Pasni - PSI, PK","Paso robles - PRB, US","Pasto - PSO, CO","Pathankot - IXP, IN","Patna - PAT, IN","Pattaya - PYX, TH","Patterson - PTN, US","Patuxent river - NHK, US","Pau - PUF, FR","Paulatuk - YPC, CA","Pauloff harbor - KPH, US","Payson - PJB, US","Paz de ariporo - PZA, CO","Peace river - YPE, CA","Peach springs - PGS, US","Peawanuck - YPO, CA","Pechora - PEX, RU","Pecos - PEQ, US","Pedro bay - PDB, US","Pedro juan caballero - PJC, PY","PEKANBARU - PKU, ID","Pelican - PEC, US","Pell city - PLR, US","Pellston - PLN, US","Pemba - POL, MZ","Pembina - PMB, US","Pembroke - YTA, CA","PENANG - PEN, MY","Pender harbor - YPT, CA","Pendleton - PDT, US","Pensacola - PNS, US","Penticton - YYF, CA","Penzance - PZE, GB","Peoria - PIA, US","Pereira - PEI, CO","Perpignan - PGF, FR","Perry - PRO, US","Perry - FPY, US","Perry island - PYL, US","Perryville - KPV, US","Perth - PER, AU","Peru - VYS, US","Peru - GUS, US","Perugia - PEG, IT","Pescara - PSR, IT","Peshawar - PEW, PK","Petawawa - YWA, CA","Peterborough - YPQ, CA","Petersburg - PGC, US","Petersburg - PTB, US","Petersburg - PSG, US","Petersons point - PNF, US","Petropavlovsk kamchatskiy - PKC, RU","Petrozavodsk - PES, RU","Pevek - PWE, RU","Phalaborwa - PHW, ZA","Phan Rang - PHA, VN","Phan Thiet - PHH, VN","PHILADELPHIA - PHL, US","Philip - PHP, US","PHILIPPINE ISLANDS - ILO, PH","Philipsburg - PSB, US","PHNOM PENH - PNH, KH","Phoenix scottsdale - SCF, US","Phu Quoc - PQC, VN","Phu Vinh - PHU, VN","Phu-Bon - HBN, VN","PHUKET - HKT, TH","Phuoclong - VSO, VN","Picayune - PCU, US","Pickens - LQK, US","Pickle lake - YPL, CA","Piedras negras - PDS, MX","Pierre - PIR, US","Pietermaritzburg - PZB, ZA","Pietersburg - PTG, ZA","Pikangikum - YPM, CA","Pikwitonei - PIW, CA","Pilot station - PQS, US","Pincher creek - WPC, CA","Pine bluff - PBF, US","Pine house - ZPO, CA","Pine mountain - PIM, US","Pine point - YPP, CA","Pine ridge - XPR, US","Pingtung - PIF, CN","Pisa - PSA, IT","Pisco - PIO, PE","Pitalito - PTX, CO","Pittsburg - PTS, US","PITTSBURGH - PIT, US","Pittsfield - PSF, US","Pituffik - THU, GL","Placerville - PVF, US","Plainview - PVW, US","Planadas - PLA, CO","Platinum - PTU, US","Plato - PLT, CO","Plattsburgh - PLB, US","Playa del carmen - PCM, MX","Pleasant harbour - PTR, US","Pleiku - PXU, VN","Plentywood - PWD, US","Plettenberg bay - PBZ, ZA","Plovdiv - PDV, BG","Plymouth - PLH, GB","Plymouth - PLY, US","Plymouth - PYM, US","Pocahontas - POH, US","Pocatello - PIH, US","Pochutla - PUH, MX","Podgorica - TGD, YU","Podor - POD, SN","Pohakuloa - BSF, US","Pohang - KPO, KR","Point baker - KPB, US","Point barrow - PBA, US","Point hope - PHO, US","Point lay - PIZ, US","Point lookout - PLK, US","Points north landing - YNL, CA","Poitiers - PIS, FR","Polacca - PXL, US","Polk inlet - POQ, US","Pompano beach - PPM, US","Ponca - PNC, US","Pond inlet - YIO, CA","Ponta delgada - PDL, PT","Pontiac - PTK, US","Pontianak - PNK, ID","Pontoise - POX, FR","Poona - PNQ, IN","Pope vanoy - PVY, US","Poplar bluff - POF, US","Poplar hill - YHP, CA","Poplar river - XPP, CA","Porbandar - PBD, IN","Porcupine creek - PCK, US","Pore - PRE, CO","Porgera - RGE, PG","Pori - POR, FI","Port alberni - YPB, CA","Port alexander - PTD, US","Port alfred - AFD, ZA","Port alice - PTC, US","Port alsworth - PTA, US","Port angeles - CLM, US","Port antonio - POT, JM","Port armstrong - PTL, US","Port augusta - PUG, AU","Port bailey - KPY, US","Port blair - IXZ, IN","Port clarence - KPC, US","Port clinton - PCW, US","Port elizabeth - PLZ, ZA","Port frederick - PFD, US","Port graham - PGM, US","Port harcourt - PHC, NG","Port hardy - YST, CA","Port hardy - YZT, CA","Port hawkesbury - YPS, CA","Port hedland - PHE, AU","Port heiden - PTH, US","Port hueneme - NTD, US","Port huron - PHN, US","Port johnson - PRF, US","Port keats - PKT, AU","Port lincoln - PLO, AU","Port mcneil - YMP, CA","Port menier - YPN, CA","Port moller - PML, US","Port moresby - POM, PG","Port oceanic - PRL, US","Port pirie - PPI, AU","Port protection - PPV, US","Port radium - YIX, CA","Port said - PSD, EG","Port san juan - PJS, US","Port simpson - YPI, CA","Port townsend - TWD, US","Port walter - PWR, US","Port williams - KPR, US","Portage - YPG, CA","Portage creek - PCA, US","Porterville - PTV, US","Portland - PDX, US","PORTLAND,ME - PWM, US","Porto - OPO, PT","Porto santo - PXO, PT","Portoroz - POW, SI","Portoviejo - PVO, EC","Portsmouth - PMH, US","Portsmouth - PME, GB","Poso - PSJ, ID","Poteau - RKR, US","Pottstown - PTW, US","Poulsbo - PUL, US","Povungnituk - YPX, CA","Powell - POY, US","Powell lake - WPL, CA","Powell river - YPW, CA","Poza rica - PAZ, MX","Poznan - POZ, PL","Prague - PRG, CZ","Praia - RAI, CV","Prairie du chien - PCD, US","Pratt - PTT, US","Prentice - PRW, US","Prerov - PRV, CZ","Prescott - PRC, US","Presov - POV, SK","Prestwick - PIK, GB","Price - PUC, US","Prieska - PRK, ZA","Prince albert - YPA, CA","Prince george - YXS, CA","Prince rupert digby isl - YPR, CA","Princeton - PNN, US","Princeton - PCT, US","Prineville - PRZ, US","Pristina - PRN, YU","Propriano - PRP, FR","Prospect creek - PPC, US","Providence - PVD, US","Provideniya - PVS, RU","Provincetown - PVC, US","Provo - PVU, US","Pucallpa - PCL, PE","Pueblo - PUB, US","Puerto ayacucho - PYH, VE","Puerto barrios - PBR, GT","Puerto cabello - PBL, VE","Puerto cabezas - PUZ, NI","Puerto escondido - PXM, MX","Puerto lempira - PEU, HN","Puerto maldonado - PEM, PE","Puerto montt - PMC, CL","Puerto princesa - PPS, PH","Puerto vallarta - PVR, MX","Pukatawagan - XPK, CA","Pula - PUY, HR","Pullman - PUW, US","Punta arenas - PUQ, CL","Punta del este - PDP, UY","Punta gorda - PGD, US","Purwokerto - PWL, ID","Pusan - PUS, KR","Pyongyang - FNJ, KP","Qaanaaq - NAQ, GL","Qassimiut - QJH, GL","Qeqertarsuatsiaat - QEY, GL","Qingdao - TAO, CN","Qingyang - IQN, CN","Qinhuangdao - SHP, CN","Qiqihar - NDG, CN","QUAD CITY APT - MLI, US","Quakertown - UKT, US","Qualicum - XQU, CA","Quanduc - HOO, VN","Quang Ngai - XNG, VN","Quantico - NYG, US","Quanzhou - JJN, CN","Quaqtaq - YQC, CA","Queen charlotte - ZQS, CA","Queens airport - UQE, US","Queenstown - UTW, ZA","Quelimane - UEL, MZ","Quepos - XQP, CR","Quesnel - YQZ, CA","Quetta - UET, PK","Quillayute - UIL, US","Quimper - UIP, FR","Quincy - UIN, US","Quincy - MQI, US","Quinhagak - KWN, US","Quinhon - UIH, VN","Quito - UIO, EC","Qullissat - QUE, GL","Rabat - RBA, MA","Rabaul - RAB, PG","Rach Gia - VKG, VN","Racine - RAC, US","Rae lakes - YRA, CA","Rafsanjan - RJN, IR","Rainbow lake - YOP, CA","Raipur - RPR, IN","Rajkot - RAJ, IN","RALEIGH - RDU, US","Ramagundam - RMD, IN","Rampart - RMP, US","Ramsar - RZR, IR","Ranau - RNU, MY","Ranchi - IXR, IN","Rancho - RBK, US","Rangely - RNG, US","Ranger - RGR, US","Rankin inlet - YRT, CA","Rapid city - RAP, US","Rasht - RAS, IR","Raspberry strait - RSP, US","Ratnagiri - RTC, IN","Raton - RTN, US","Rawlins - RWL, US","Reading - RDG, US","Rechlin - REB, DE","Red bluff - RBL, US","Red deer - YQF, CA","Red devil - RDV, US","Red dog - RDB, US","Red lake - YRL, CA","Red river - RDR, US","Red sucker lake - YRS, CA","Redding - RDD, US","Redmond - RDM, US","Redwood falls - RWF, US","Reed city - RCT, US","Reedsville - RED, US","Regina - YQR, CA","Rehoboth beach - REH, US","Reims - RHE, FR","Rennes - RNS, FR","Reno - RNO, US","Rensselaer - RNZ, US","Renton - RNT, US","Repulse bay - YUT, CA","Resolute - YRB, CA","Resolution island - YRE, CA","Revelstoke - YRV, CA","Rewa - REW, IN","Reynosa - REX, MX","Rhinelander - RHI, US","Rhodes - RHO, GR","Ribeira grande - QEG, PT","Riberalta - RIB, BO","Rice lake - RIE, US","Richard toll - RDT, SN","Richards bay - RCB, ZA","Richfield - RIF, US","Richland - RLD, US","Richmond - RIC, US","Richmond - RID, US","Riesa - IES, DE","Rifle - RIL, US","Riga - RIX, LV","Rijeka - RJK, HR","Rimini - RMI, IT","Rimouski - YXK, CA","Rio de Janeiro - RIO, BR","Rioja - RIJ, PE","Rivera - RVY, UY","Rivers - YYI, CA","Rivers inlet - YRN, CA","Riverside - RAL, US","Riverton - RIW, US","Riviere au tonnerre - YTN, CA","Riviere du loup - YRI, CA","Riyadh - RUH, SA","Roanne - RNE, FR","Roanoke - ROA, US","Roanoke - RZZ, US","Robertson - ROD, ZA","Roberval - YRJ, CA","Roche harbor - RCE, US","Rochefort - RCO, FR","Rochester - RCR, US","Rochester - ROC, US","Rochester - RST, US","Rock hill - RKH, US","Rock springs - RKS, US","Rockdale - RCK, US","Rockhampton - ROK, AU","Rockland - RKD, US","Rockport - RKP, US","Rockwood - RKW, US","Rocky mount - RWI, US","Rocky mountain house - YRM, CA","Rodez - RDZ, FR","Roebourne - RBU, AU","Rogers - ROG, US","Rolla - RLA, US","Roma - FAL, US","Rome - RME, US","Rome - RMG, US","Rome - REO, US","Rome - ROM, IT","Ronald reagan natl apt - DCA, US","Roosevelt - ROL, US","Rosario - RSJ, US","Roseau - ROX, US","Roseburg - RBG, US","Ross river - XRR, CA","Roswell - ROW, US","Rotorua - ROT, NZ","Rotterdam - RTM, NL","Rotunda - RTD, US","Rouen - URO, FR","Round lake - ZRJ, CA","Roundup - RPX, US","Rouses point - RSX, US","Rouyn - YUY, CA","Rovaniemi - RVN, FI","Rowan bay - RWB, US","Royan - RYN, FR","Ruby - RBY, US","Rucheng - Ruc, CN","Ruidoso - RUI, US","Rundu - NDU, NA","Rurrenabaque - RBQ, BO","Russell - RSL, US","Russian mission - RSH, US","Ruston - RSN, US","Ruteng - RTG, ID","Rutland - RUT, US","Rybinsk - RYB, RU","Saarbrucken - SCN, DE","Saarloq - QOQ, GL","Sabana de la mar - SNX, DO","Sabana de torres - SNT, CO","Sable island - YSA, CA","Sachigo lake - ZPB, CA","Sachs harbour - YSY, CA","SACRAMENTO - SMF, US","Safford - SAD, US","Safi - SFI, MA","Saginaw - MBS, US","Saginaw bay - SGW, US","Sagwon - SAG, US","Saigon - SGN, VN","Saint augustine - UST, US","Saint catharines - YCM, CA","Saint Denis Reunion - RUN, RE","Saint george island - STG, US","Saint jean - YJN, CA","Saint john - YSJ, CA","Saint johns - SJN, US","Saint joseph - STJ, US","Saint marys - STQ, US","Saint marys - XSM, US","Saint marys - KSM, US","Saint michael - SMK, US","Saint paul - STP, US","Saint paul - ZSP, CA","Saint paul island - SNP, US","Saint Petersburg - LED, RU","Saint thomas - YQS, CA","Salalah - SLL, OM","Salehard - SLY, RU","Salem - SLE, US","Salem-leckrone - SLO, US","Salida - SLT, US","Salina - SLN, US","Salina - SBO, US","Salina cruz - SCX, MX","Salinas - SNS, US","Salisbury - SRW, US","Salisbury - SBY, US","Salluit - YZG, CA","Salmon - SMN, US","Salmon arm - YSN, CA","Salt lake city - SLC, US","Saltillo - SLW, MX","Salton city - SAS, US","Salvador - SSA, BR","Samarinda - SRI, ID","Sambava - SVB, MG","Samchok - SUK, KR","Sampit - SMQ, ID","San angelo - SJT, US","SAN ANTONIO - SAT, US","San bernardino - SBT, US","San borja - SRJ, BO","San carlos - SQL, US","SAN DIEGO - SAN, US","San fernando - SFR, US","San fernando - SFE, PH","San Francisco - SFO, US","SAN JOSE - SJC, US","SAN JUAN - SJU, PR","San juan - WSJ, US","San luis de palenque - SQE, CO","San luis obispo - SBP, US","San Paulo - SAO, BR","San pedro sula - SAP, HN","San rafael - SRF, US","San Salvador - SAL, SV","Sanaa - SAH, YE","Sanandaj - SDG, IR","Sand point - SDP, US","Sandakan - SDK, MY","Sandane - SDN, NO","Sandefjord - TRF, NO","Sandspit - YZP, CA","Sandusky - SKY, US","Sandy lake - ZSJ, CA","Sandy river - KSR, US","Sanford - SFM, US","Sanga-sanga - SGS, PH","Sanikiluaq - YSK, CA","Sans souci - YSI, CA","Santa ana - SNA, US","SANTA BARBARA - SBA, US","Santa cruz - SRU, US","Santa cruz - VVI, BO","Santa fe - SAF, US","Santa maria - SMX, US","Santa marta - SMR, CO","Santa monica - SMO, US","Santa paula - SZP, US","Santa rosa - STS, US","Santa ynez - SQA, US","Santiago - SCL, CL","Sanya - SYX, CN","Saposoa - SQU, PE","Sapporo - SPK, JP","Sarajevo - SJJ, BA","Sarakhs - CKT, IR","Saranac - SLK, US","Saransk - SKX, RU","SARASOTA - SRQ, US","Saratoga - SAA, US","Saravena - RVE, CO","Sarh - SRH, TD","Sarichef - WSF, US","Sarnia - YZR, CA","Saskatoon - YXE, CA","Sassandra - ZSS, CI","Satna - TNI, IN","Sault sainte marie - SSM, US","Sausalito - JMC, US","Savannah - SAV, US","Savonlinna - SVL, FI","Savoonga - SVA, US","Savusavu - SVU, FJ","Schefferville - YKL, CA","Schenectady - SCH, US","Schleswig - WBG, DE","Schwerin - SZW, DE","Scottsbluff - BFF, US","Scranton/wilkes-barre - AVP, US","Scribner - SCB, US","Seal bay - SYB, US","Searcy - SRC, US","Seattle king county - BFI, US","Seattle/tacoma - SEA, US","Sebba - XSE, BF","Sebring - SEF, US","Sechelt - YHS, CA","Secunda - ZEC, ZA","Sedalia - DMO, US","Sedona - SDX, US","Seguela - SEO, CI","Selawik - WLK, US","Seldovia - SOV, US","Selinsgrove - SEG, US","Selma - SES, US","Semarang - SRG, ID","Sembach - SEX, DE","Semey - PLX, KZ","Semporna - SMM, MY","Sendai - SDJ, JP","SEOUL - SEL, KR","Sequim valley - SQV, US","Sevilla - SVQ, ES","Sewanee - UOS, US","Seward - SWD, US","Seymour - SER, US","Shafter - MIT, US","Shageluk - SHX, US","Shakawe - SWX, BW","Shakiso - SKR, ET","Shaktoolik - SKK, US","Shamattawa - ZTM, CA","Shanghai - SHA, CN","Shangri-la - NRI, US","SHANNON - SNN, IE","Shantou - SWA, CN","Shaoguan - HSC, CN","Shashi - SHS, CN","Shawnee - SNL, US","Shearwater - YSX, CA","Sheboygan - SBM, US","Sheep mountain - SMU, US","Sheffield - SZD, GB","Shelby - SBX, US","Shelbyville - SYI, US","Sheldon point - SXP, US","Shelton - SHN, US","Shemya - SYA, US","Shenyang - SHE, CN","Shenzhen - SZX, CN","Sherbrooke - YSC, CA","Sheridan - SHR, US","Sherman/denison - PNX, US","Shijiazhuang - SJW, CN","Shikarpur - SWV, PK","Shillong - SHL, IN","Shilo - YLO, CA","Shima - Shi, CN","Shiraz - SYZ, IR","Shirley - WSH, US","Shishmaref - SHH, US","Shoal - HCB, US","Sholapur - SSE, IN","Show low - SOW, US","SHREVEPORT - SHV, US","Shungnak - SHG, US","Siasi - SSV, PH","Siauliai - SQQ, LT","Sibi - SBQ, PK","Sibu - SBW, MY","Sidney - SDY, US","Sidney - SNY, US","Sidney - SXY, US","Siegen - SGE, DE","SIEM REAP - REP, KH","Siena - SAY, IT","Sierra vista - FHU, US","Sikeston - SIK, US","Silchar - IXS, IN","Siloam springs - SLG, US","Silva bay - SYF, CA","Silver city - SVC, US","Simao - SYM, CN","Simferopol - SIP, UA","Sindal - CNL, DK","Sines - SIE, PT","Singapore - SIN, SG","Siocon - XSO, PH","Sion - SIR, CH","Sioux city - SUX, US","Sioux falls - FSD, US","Sioux lookout - YXL, CA","Sirjan - SYJ, IR","Sitka - SIT, US","Sitkinak island - SKJ, US","Siuna - SIU, NI","Sivas - VAS, TR","Skagen - QJV, DK","Skagway - SGY, US","Skeldon - SKM, GY","Skive - SQW, DK","Skopje - SKP, MK","Skwentna - SKW, US","Slate island - YSS, CA","Slave lake - YZH, CA","Sleetmute - SLQ, US","Sliac - SLD, SK","Slupsk - OSP, PL","Smith cove - SCJ, US","Smith falls - YSH, CA","Smithers - YYD, CA","Smithfield - SFZ, US","Smyrna - MQY, US","Snake river - YXF, CA","Snowdrift - YSG, CA","Snyder - SNK, US","Soc Trang - SOA, VN","Socorro - ONM, US","Sofia - SOF, BG","Sogamoso - SOX, CO","Sokcho - SHO, KR","Soldotna - SXQ, US","SOLO CITY - SOC, ID","Solomon - SOL, US","Solwezi - SLI, ZM","Somerset - SME, US","Songea - SGX, TZ","Son-La - SQH, VN","Sorong - SOQ, ID","South bend - SBN, US","South indian lake - XSI, CA","South naknek - WSN, US","South trout lake - ZFL, CA","South weymouth - NZW, US","Southampton - SOU, GB","Southern pines - SOP, US","Spangdahlem - SPM, DE","Sparrevohn - SVW, US","Sparta - CMY, US","Spartanburg - SPA, US","Spearfish - SPF, US","Spencer - SPW, US","Spirit lake - RTL, US","Split - SPU, HR","SPOKANE - GEG, US","Spring island - YSQ, CA","Springdale - SPZ, US","Springfield - SPI, US","Springfield - SGH, US","Springfield - VSF, US","SPRINGFIELD REG APT - SGF, US","Squamish - YSE, CA","Squirrel cove - YSZ, CA","Srinagar - SXR, IN","ST LOUIS - STL, US","St.johns - YYT, CA","St.petersburg - PIE, US","Stanton - SYN, US","State college univer - SCE, US","Statesboro - TBR, US","Statesville - SVH, US","Staunton shenandoah - SHD, US","Stavanger - SVG, NO","Stawell - SWC, AU","Steamboat bay - WSB, US","Steamboat springs - SBS, US","Stebbins - WBB, US","Stephenville - SEP, US","Sterling - STK, US","Sterling rockfalls - SQI, US","Stevens point - STE, US","Stevens village - SVS, US","Stewart - ZST, CA","Stillwater - SWO, US","STOCKHOLM - STO, SE","Stockton - SCK, US","Stokmarknes - SKN, NO","Stony rapids - YSF, CA","Stony river - SRV, US","Storm lake - SLB, US","Stow - MMN, US","Stowe - MVL, US","Strasbourg - SXB, FR","Straubing - RBM, DE","Strausberg - QPK, DE","Stroud - SUD, US","Stuart - SUA, US","Stuart island - SSW, US","Stuart island - YRR, CA","Sturdee - YTC, CA","Sturgeon bay - SUE, US","Sturgis - IRS, US","Stuttgart - STR, DE","Stuttgart - SGT, US","Sudbury - YSB, CA","Sudureyri - SUY, IS","Suffield - YSD, CA","Sukhumi - SUI, GE","Sukkur - SKZ, PK","Sulaco - SCD, HN","Sullivan - SIV, US","Sullivan bay - YTG, CA","Sulphur springs - SLR, US","Sumbawa - SWQ, ID","Sumbawanga - SUT, TZ","Sumenep - SUP, ID","Summer beaver - SUR, CA","Summerside - YSU, CA","Summit - UMM, US","Summit lake - IUM, CA","Sumter - SUM, US","Sun moon lake - SMT, CN","Sun river - SUO, US","SUN VALLEY - SUN, US","Sunchon - SYS, KR","Sundance - SUC, US","Sundsvall - SDL, SE","Sunyani - NYI, GH","Superior - SUW, US","Surabaya - SUB, ID","Surat - STV, IN","Surgut - SGC, RU","Susanville - SVE, US","Suva - SUV, FJ","Suwalki - ZWK, PL","Suwon - SWU, KR","Suzhou - SZV, CN","Swakopmund - SWP, NA","Swan hill - SWH, AU","Swan river - ZJN, CA","Swansea - SWS, GB","Sweetwater - SWW, US","Swift current - YYN, CA","Swindon - SWI, GB","Sydney - SYD, AU","Sydney - YQY, CA","Syktyvkar - SCW, RU","Sylvester - SYV, US","Syracuse - SYR, US","Szczecin - SZZ, PL","Tabal - TBV, MH","Tabas - TCX, IR","Tablas - TBH, PH","Tabou - TXU, CI","Tabriz - TBZ, IR","Tabuk - TUU, SA","Tacloban - TAC, PH","Tacna - TCQ, PE","Tacoma - TIW, US","Tadoule lake - XTL, CA","Tadoule lake - YBQ, CA","Taegu - TAE, KR","Tagbilaran - TAG, PH","Tahneta pass lodge - HNE, US","Tahsis - ZTS, CA","Taian - Tai, CN","Taichung - TXG, CN","Tainan - TNN, CN","Taipei - TPE, TW","Taiping - TPG, MY","Taitung - TTT, CN","Taiyuan - TYN, CN","Takamatsu - TAK, JP","Takhli - TKH, TH","Takotna - TCT, US","Taku lodge - TKL, US","Talara - TYL, PE","Talca - TLX, CL","Talkeetna - TKA, US","Talladega - ASN, US","Tallahassee - TLH, US","Tallinn - TLL, EE","Taloyoak - YYH, CA","Taltal - TTC, CL","Taltheilei narrows - GSL, CA","Tamale - TML, GH","Tame - TME, CO","Tamky - VCL, VN","TAMPA - TPA, US","Tampere - TMP, FI","Tampico - TAM, MX","Tan tan - TTA, MA","Tanacross - TSG, US","Tanalian - TPO, US","Tanana - TAL, US","Tanjung balai - TJB, ID","Tanjung pandan - TJQ, ID","Tanjung pinang - TNJ, ID","Taos - TSM, US","Tapachula - TAP, MX","Tarakan - TRK, ID","Taranto - TAR, IT","Tarapoto - TPP, PE","Tartu - TAY, EE","Tasiilaq - AGM, GL","Tasikmalaya - TSY, ID","Tasiujuaq - YTQ, CA","Tasu - YTU, CA","Tatalina - TLJ, US","Tatitlek - TEK, US","Taupo - TUO, NZ","Tauramena - TAU, CO","Tauranga - TRG, NZ","Tawa - Taw, CN","Tawau - TWU, MY","Taylor - TWE, US","Taylor - TYZ, US","Tbilisi - TBS, GE","Tchibanga - TCH, GA","Te anau - TEU, NZ","Teesside - MME, GB","Tegucigalpa - TGU, HN","Tehachapi - TSP, US","Tehran - THR, IR","Tel Aviv - TLV, IL","Tela - TEA, HN","Telegraph creek - YTX, CA","Telida - TLF, US","Teller - TLA, US","Teller mission - KTS, US","Telluride - TEX, US","Temple - TPL, US","Temuco - ZCO, CL","Tenakee springs - TKE, US","Tenkodogo - TEG, BF","Tennant creek - TCA, AU","Termiz - TMJ, UZ","Ternate - TTE, ID","Terrace - YXT, CA","Terrace bay - YTJ, CA","Terre haute - HUF, US","Terrell - TRL, US","Teslin - YZW, CA","Tete-a-la-baleine - ZTB, CA","Teterboro - TEB, US","Tetlin - TEH, US","Texarkana - TXK, US","Tezpur - TEZ, IN","Tezu - TEI, IN","Thaba nchu - TCU, ZA","Thanjavur - TJV, IN","The dalles - DLS, US","The pas - YQD, CA","Thermal - TRM, US","Thermopolis - THP, US","Thessaloniki - SKG, GR","Thicket portage - YTD, CA","Thief river falls - TVF, US","Thira - JTR, GR","Thisted - TED, DK","Thohoyandou - THY, ZA","Thomasville - TVI, US","Thompson - YTH, CA","Thompsonfield - THM, US","Thorne bay - KTB, US","Three rivers - HAI, US","Thunder bay - YQT, CA","Tianjin - TSN, CN","Tifton - TMA, US","Tignes - TGF, FR","Tijuana - TIJ, MX","Tikchik - KTH, US","Tiko - TKC, CM","Tiksi - IKS, RU","Timaru - TIU, NZ","Timisoara - TSR, RO","Timmins - YTS, CA","Tinak - TIC, MH","Tingrela - TGX, CI","Tioga - VEX, US","Tirana - TIA, AL","Tirupati - TIR, IN","Tisdale - YTT, CA","Tobolsk - TOX, RU","Toccoa - TOC, US","Tocoa - TCF, HN","Tocopilla - TOQ, CL","Tofino - YAZ, CA","Togiak - TOG, US","Togiak fish - GFB, US","Tok - TKJ, US","Tokeen - TKI, US","Tokoroa - TKZ, NZ","Toksook bay - OOK, US","Tokushima - TKS, JP","Tokyo - TYO, JP","Toledo - TDO, US","TOLEDO - TOL, US","Toluca - TLC, MX","Toms river - MJX, US","Tomsk - TOF, RU","Tonghua - TNH, CN","Tongliao - TGO, CN","Tongren - TEN, CN","Tonopah - TPH, US","Toowoomba - TWB, AU","Toronto - YTO, CA","Torrance - TOA, US","Torrington - TOR, US","Touba - TOZ, CI","Tougan - TUQ, BF","Toulouse - XYT, FR","Toulouse Blagnac - TLS, FR","Tours - TUF, FR","Toussus-le-noble - TNF, FR","Townsville - TSV, AU","Toyama - TOY, JP","Toyooka - TJH, JP","Trapani - TPS, IT","Traralgon - TGN, AU","Traverse city - TVC, US","Tremonton - TRT, US","Trenton - TTN, US","Trenton - TRX, US","Trenton - YTR, CA","Treviso - TSF, IT","Trier - ZQF, DE","Trieste - TRS, IT","Trinidad - TAD, US","Triple island - YTI, CA","Tripoli - TIP, LY","Tripoli - KYE, LB","Trivandrum - TRV, IN","Trois-rivieres - YRQ, CA","Trona - TRH, US","Trondheim - TRD, NO","Troutdale - TTD, US","Troy - TOI, US","Truckee - TKF, US","Trudeau - YUL, CA","Trujillo - TRU, PE","Truth or consequences - TCS, US","Tsabong - TBY, BW","Tsaratanana - TTS, MG","Tshikapa - TSH, ZR","Tsiroanomandidy - WTS, MG","Tsumeb - TSB, NA","Tsushima - TSJ, JP","Tuba - TBC, US","Tucumcari - TCC, US","Tucupita - TUV, VE","Tuguegarao - TUG, PH","Tuktoyaktuk - YUB, CA","Tulare - TLR, US","Tullahoma - THA, US","TULSA - TUL, US","Tulugak - YTK, CA","Tuluksak - TLT, US","Tulum - TUY, MX","Tumaco - TCO, CO","Tumbes - TBP, PE","Tumbler ridge - TUX, CA","Tungsten - TNS, CA","Tunis - TUN, TN","Tuntutuliak - WTL, US","Tununak - TNK, US","Tupelo - TUP, US","Turbat - TUK, PK","Turbo - TRB, CO","Turin - TRN, IT","Turku - TKU, FI","Tuscaloosa - TCL, US","Tuskegee - TGE, US","Tuxekan island - WNC, US","Tuy Hoa - TBB, VN","Twentynine palms - TNP, US","Twin falls - TWF, US","Twin hills - TWA, US","TYLER - TYR, US","Tynda - TYD, RU","Tyonek - TYE, US","Tzaneen - LTA, ZA","Ube - UBJ, JP","Udaipur - UDR, IN","Uden - UDE, NL","Udine - UDN, IT","Udon thani - UTH, TH","Ufa - UFA, RU","Uganik - UGI, US","Ugashik - UGS, US","Ukhta - UCT, RU","Ukiah - UKI, US","Ulaangom - ULO, MN","ULAN BATOR - ULN, MN","Ulan ude - UUD, RU","Ulanhot - HLH, CN","Ulsan - USN, KR","Ulundi - ULD, ZA","Ulyanovsk - ULY, RU","Umiat - UMT, US","Umiujaq - YUD, CA","Umtata - UTT, ZA","Unalakleet - UNK, US","Union city - UCY, US","Upala - UPL, CR","Upington - UTN, ZA","Upland - CCB, US","Upolu point - UPP, US","Uranium city - YBE, CA","Urganch - UGC, UZ","Urrao - URR, CO","Uruapan - UPN, MX","Urumqi - URC, CN","Usak - USQ, TR","Usinsk - USK, RU","Ust ilimsk - UIK, RU","Ust-kut  - UKX, RU","Ustupo - UTU, PA","Utica - UIZ, US","Utica - UCA, US","Utila - UII, HN","Uummannaq - UMD, GL","Uvalde - UVA, US","Uzice - UZC, YU","Vaasa - VAA, FI","Vadodara - BDQ, IN","Valcartier - YOY, CA","Valdez - VDZ, US","Valdivia - ZAL, CL","Valdosta - VLD, US","Valence - VAF, FR","Valencia - VLC, ES","Valencia - VLN, VE","Valentine - VTN, US","Valera - VLV, VE","Valladolid - VLL, ES","Valle - VLE, US","Valledupar - VUP, CO","Vallejo - VLO, US","Vallenar - VLR, CL","Valparaiso - VPZ, US","Van horn - VHN, US","VANCOUVER - YVR, CA","Vandalia - VLA, US","Vangaindrano - VND, MG","Vanimo - VAI, PG","Vannes - VNE, FR","Varadero - VRA, CU","Varanasi - VNS, IN","Varkaus - VRK, FI","Varna - VAR, BG","Vatukoula - VAU, FJ","Velikij ustyug - VUS, RU","Venetie - VEE, US","Venice - VCE, IT","Venice - VNC, US","Vermilion - YVG, CA","Vernal - VEL, US","Vernon - YVE, CA","Vero beach - VRB, US","Versailles - VRS, US","Vicenza - VIC, IT","Vichadero - VCH, UY","Vichy - VHY, FR","Vichy/rolla - VIH, US","Vicksburg - VKS, US","Victoria falls - VFA, ZW","Victorville - VCV, US","Vidalia - VDI, US","Vienna - VIE, AW","Vientiane - VTE, LA","Vieste - VIF, IT","View cove - VCB, US","Vijayawada - VGA, IN","Villahermosa - VSA, MX","Villamontes - VLM, BO","Villavicencio - VVC, CO","Vilnius - VNO, LT","Vincennes - OEA, US","Vinh Long - XVL, VN","Virac - VRC, PH","Visalia - VIS, US","Visby - VBY, SE","Viseu - VSE, PT","Vittel - VTL, FR","Vladikavkaz - OGZ, RU","Vladivostok - VVO, RU","Vojens - SKS, DK","Volgodonsk - VLK, RU","Vorkuta - VKT, RU","Vredendal - VRE, ZA","Vryburg - VRU, ZA","Vryheid - VYD, ZA","Vung Tau - VTG, VN","Wabag - WAB, PG","Wabush - YWK, CA","WACO - ACT, US","Wadi halfa - WHF, SD","Wahiawa - HHI, US","Wahpeton - WAH, US","Waikoloa - WKL, US","Waimanalo - BLW, US","Waingapu - WGP, ID","Wainwright - AIN, US","Wairoa - WIR, NZ","Wajir - WJR, KE","Wakkanai - WKJ, JP","Waldron - WDN, US","Wales - WAA, US","Walla walla - ALW, US","Walnut ridge - ARG, US","Walterboro - RBW, US","Waltham - WLM, US","Walvis bay - WVB, NA","Wanaka - WKA, NZ","Wanganui - WAG, NZ","Wangaratta - WGT, AU","Wangerooge - AGE, DE","Wanxian - WXN, CN","Wapakoneta - AXV, US","Ware - UWA, US","Warrnambool - WMB, AU","Warroad - RRT, US","Warsaw - WAW, PL","Washington - WSG, US","Washington - OCW, US","WASHINGTON DC - WAS, US","Wasilla - WWA, US","Waskaganish - YKQ, CA","Waterfall - KWF, US","Waterloo - ALO, US","Watertown - ART, US","Watertown - ATY, US","Waterville - WVL, US","Watson lake - YQH, CA","Watsonville - WVI, US","Waukegan - UGN, US","Waukesha - UES, US","Waukon - UKN, US","WAUSAU - AUW, US","Wawa - YXZ, CA","Waycross - AYS, US","Waynesburg - WAY, US","Weatherford - WEA, US","Webequie - YWP, CA","Webster city - EBS, US","Weeping water - EPG, US","Weifang - WEF, CN","Weihai - WEH, CN","Welkom - WEL, ZA","Wellington - WLG, AU","Wells - LWL, US","Wellsville - ELZ, US","Wemindji - YNC, CA","Wenatchee - EAT, US","Wendover - ENV, US","Wenzhou - WNZ, CN","West bend - ETB, US","West kavik - VKW, US","West kuparuk - XPU, US","West malling - WEM, GB","West memphis - AWM, US","WEST PALM BEACH - PBI, US","West point - KWP, US","West yellowstone - WYS, US","Westerland - GWT, DE","Westerly - WST, US","Westfield - BAF, US","Westhampton - FOK, US","Westsound - WSX, US","Wewak - WWK, PG","Whakatane - WHK, NZ","Whale cove - YXN, CA","Whale pass - WWP, US","Whangarei - WRE, NZ","Wharton - WHT, US","Wheatland - EAN, US","Wheeling - HLG, US","Whidbey island - NUW, US","Whistler - YWS, CA","White mountain - WMO, US","White plains - HPN, US","White river - WTR, US","White river - YWR, CA","White sands - WSD, US","White sulphur springs - SSU, US","Whitecourt - YZU, CA","Whitefield - HIE, US","Whitehorse - YXY, CA","Whitesburg - BRG, US","Whitianga - WTZ, NZ","Whyalla - WYA, AU","Wiarton - YVV, CA","WICHITA - ICT, US","WICHITA FALLS - SPS, US","Wilhelmshaven - WVN, DE","Wilkes-barre - WBW, US","Wilkesboro - IKB, US","Williams lake - YWL, CA","Williamsport - IPT, US","Williston - ISN, US","Willmar - ILL, US","Willoughby - LNN, US","Willow - WOW, US","Willows - WLW, US","Wilmington - ILN, US","Winchester - WGO, US","Winder - WDR, US","WINDHOEK - WDH, NA","Windom - MWM, US","Windsor - YQG, CA","Winfield /arkansas city - WLD, US","Winisk - YWN, CA","Wink - INK, US","Winnemucca - WMC, US","Winnipeg - YWG, CA","Winona - ONA, US","Winslow - INW, US","Winston salem - INT, US","Winter haven - GIF, US","Wiscasset - ISS, US","Wisconsin rapids - ISW, US","Wise - LNP, US","Wiseman - WSM, US","Woburn - WBN, US","Woensdrecht - WOE, NL","Woja - WJA, MH","Wolf point - OLF, US","Wollaston lake - ZWL, CA","Wonan - WOT, CN","Wonju - WJU, KR","Wood river - WOD, US","Woodchopper - WOO, US","Woodward - WWR, US","Wooster - BJJ, US","Worcester - ORH, US","Worland - WRL, US","Worthington - OTG, US","Wotho - WTO, MH","Wotje - WTE, MH","Wrangell - WRG, US","Wrench creek - WRH, US","Wrigley - YWY, CA","Wroclaw - WRO, PL","Wuhan - WUH, CN","Wuhu - WHU, CN","Wunnummin lake - WNN, CA","Wuxi - WUX, CN","Wuyishan nanping - WUS, CN","Wuzhou - WUZ, CN","Xiamen - XMN, CN","XIAN - XIY, CN","Xiangfan - XFN, CN","Xichang - XIC, CN","Xilinhaote - Xil, CN","Xingcheng - XEN, CN","Xingtai - XNT, CN","Xining - XNN, CN","Xinyang - Xin, CN","Xuzhou - XUZ, CN","Yagoua - GXX, CM","Yakataga - CYT, US","Yakima - YKM, US","Yakutat - YAK, US","Yakutsk - YKS, RU","Yamagata - GAJ, JP","Yamoussoukro - ASK, CI","Yanan - ENY, CN","Yanbu - YNB, SA","Yancheng - YNZ, CN","Yanji - YNJ, CN","Yankton - YKN, US","Yantai - YNT, CN","Yarmouth - YQI, CA","Yaroslavl  - IAR, RU","Yavarate - VAB, CO","Yaviza - PYV, PA","Yazd - AZD, IR","Yechon - YEC, KR","Yellowknife - YZF, CA","Yengema - WYE, SL","Yeovilton - YEO, GB","Yerington - EYR, US","Yibin - YBP, CN","Yichang - YIH, CN","Yinchuan - INC, CN","Yining - YIN, CN","Yiwu - YIW, CN","Ylivieska - YLI, FI","Yokohama - YOK, JP","Yola - YOL, NG","Yonago - YGJ, JP","York - THV, US","York landing - ZAC, CA","Yorkton - YQV, CA","Yosemite - OYS, US","Yoshkar ola - JOK, RU","Yosu - RSU, KR","Youngstown - YNG, US","Yreka - RKC, US","Yuancheng - Yua, CN","Yucca flats - UCC, US","Yulin - UYN, CN","Yuma - YUM, US","Yurimaguas - YMS, PE","Yuzhno sakhalinsk - UUS, RU","Zagreb - ZAG, HR","Zahedan - ZAH, IR","Zamboanga - ZAM, PH","Zamora - ZMM, MX","Zanesville - ZZV, US","Zanzibar - ZNZ, TZ","Zapatoca - AZT, CO","Zaria - ZAR, NG","Zephyrhills - ZPH, US","Zerzaltine - IAM, DZ","ZHANGJIAJIE - DYG, CN","Zhanjiang - ZHA, CN","Zhaotong - ZAT, CN","Zhengzhou - CGO, CN","Zhob - PZH, PK","Zhongshan - ZIS, CN","Zhongshu - Zho, CN","Zhoushan - HSN, CN","Zhuhai - ZUH, CN","Zilina - ILZ, SK","Zuenoula - ZUE, CI","Zunyi - ZYI, CN","Zurich - ZRH, CH");
        arrCityList = arrAutoCityList;
    }
    var temp = new Array();
    
    if (flag.value != "H")
    {
        for (intTmp = 0; intTmp < arrList.length; intTmp ++) 
        {
            var index = arrList[intTmp].indexOf(",");
            var temp1 = arrList[intTmp].substring(0, index + 1);
            var temp2 = arrList[intTmp].substring(index + 1);
            index = temp2.indexOf(",");
            var temp3 = temp2.substring(0, index + 1);
            var temp4 = temp1 + temp3;
            
            if (temp4.toUpperCase().indexOf(code.trim().toUpperCase()) >= 0)
                temp.push(arrList[intTmp]);
            
             if (temp.length == 20)
            {
                temp.sort();
                arrList = null;
                return temp;
            }
        }
    }
    else
    {
            for (intTmp = 0; intTmp < arrCityList.length; intTmp ++) 
        {
            
            var index = arrCityList[intTmp].indexOf(",");
            var temp1 = arrCityList[intTmp].substring(0, index + 1);
            var temp2 = arrCityList[intTmp].substring(index + 1);
            index = temp2.indexOf(",");
            var temp3 = temp2.substring(0, index + 1);
            var temp4 = temp1 + temp3;
            
            if (temp4.toUpperCase().indexOf(code.toUpperCase()) >= 0)
                temp.push(arrCityList[intTmp]);
            if (temp.length == 20)
            {
                temp.sort();
                arrCityList = null;
                return temp;
            }
        }
    }
    
    temp.sort();
    return temp;
}

document.write("<div id='__smanDisp' style='position:absolute;display:none; background:#fff; font-family:Verdana; border: 1px solid #CCCCCC;font-size:10px;cursor: default;' onbulr></div>");
document.write("<style>.sman_selectedStyle{background-Color:#b2ccfa;color:#000;}</style>");

function smanPromptList(arrList, objInputId)
{
    if (arrList.constructor != Array)
    {
        alert('smanPromptList');
        return;
    }
    var objouter = document.getElementById("__smanDisp") 
    var objInput = document.getElementById(objInputId); 
    var selectedIndex = -1;
    var intTmp; 
    if (objInput == null)
    {
        alert('smanPromptList is not find "' + objInputId + '"textbox');
        return;
    }
    objInput.onblur = function()
    {
        if (txtDepCity = document.forms[0].elements['depFullCity'] != null && document.forms[0].elements['toFullCity'] != null)
        {
            var flightType = document.forms[0].elements['FlightType'];
            var txtDepCity = document.forms[0].elements['depFullCity'];
            var txtDesCity = document.forms[0].elements['toFullCity'];
            if (flightType != null)
            {
                if (flightType.value != "openjaw")
                {
                    var txtRtnFrom = document.forms[0].elements['rtnFromFullCity'];
                    var txtRtnTo = document.forms[0].elements['rtnToFullCity'];
                    txtRtnFrom.value = txtDesCity.value;
                    txtRtnTo.value = txtDepCity.value;
                }
            }
        }
        
        if (txtDepCity = document.forms[0].elements['ctl00_ltxFrom'] != null && document.forms[0].elements['ctl00_ltxTo'] != null)
        {
            var flightType = document.forms[0].elements['ctl00_FlightType'];
            var txtDepCity = document.forms[0].elements['ctl00_ltxFrom'];
            var txtDesCity = document.forms[0].elements['ctl00_ltxTo'];
            if (flightType != null)
            {
                if (flightType.value != "openjaw")
                {
                    var txtRtnFrom = document.forms[0].elements['ltxRtnFrom'];
                    var txtRtnTo = document.forms[0].elements['ltxRtnTo'];
                    txtRtnFrom.value = txtDesCity.value;
                    txtRtnTo.value = txtDepCity.value;
                }
            }
        }
        
        objouter.style.display = 'none';
    }
    objInput.onkeydown = checkKeyCode;
    
    function checkKeyCode(e)
    {
        tempName = this.id;
        var ev = e || window.event;
        var value = this.value;
        var ie = !!document.all;
        var keyCode = ev.keyCode;
        if (keyCode == 40 || keyCode == 38) 
        { 
            chageSelection(keyCode == 40)
        } 
        else if (keyCode == 13)
        { 
            outSelection(selectedIndex);
            return false;
        }
        
        if(keyCode == 8){
          tempDate = setTimeout(function(){if(value.length == document.forms[0].elements[tempName].value.length + 1){runlist(value);}},200);
        }else{

        tempDate = setTimeout(function(){if(value.length == document.forms[0].elements[tempName].value.length - 1){runlist(value);}},200);
        }
    }
    function chageSelection(isUp)
    {
        if (objouter.style.display == 'none')
        {
            objouter.style.display = '';
        }
        else
        {
            if (isUp){
                selectedIndex++;
                document.getElementById("mouseindex").value = selectedIndex;}
            else{
                selectedIndex--;
                document.getElementById("mouseindex").value = selectedIndex;}
        }
        var maxIndex;        
        if (navigator.appName == "Netscape")
        {maxIndex = objouter.childNodes.length - 1;}
        else
        {maxIndex = objouter.children.length - 1;}


        if (selectedIndex < 0){
            selectedIndex = 0;document.getElementById("mouseindex").value = selectedIndex;}
        if (selectedIndex > maxIndex){
            selectedIndex = maxIndex;document.getElementById("mouseindex").value = selectedIndex;}
        for (intTmp = 0; intTmp <= maxIndex; intTmp++)
        {
        if (navigator.appName == "Netscape")
        {
            if (intTmp == selectedIndex)
                objouter.childNodes[intTmp].className = "sman_selectedStyle";
            else
                objouter.childNodes[intTmp].className = "";

        }
        else
        {
            if (intTmp == selectedIndex)
                objouter.children[intTmp].className = "sman_selectedStyle";
            else
                objouter.children[intTmp].className = "";
                }
        }
    }
    function outSelection(Index)
    {
        if (document.getElementById("mouseindex").value != ""){
            Index = Number(document.getElementById("mouseindex").value);

            if (navigator.appName == "Netscape")
        {
            objInput.value = objouter.childNodes[Index].textContent;
            objouter.style.display = 'none';
            }
            else
            {
                objInput.value = objouter.children[Index].innerText;
            objouter.style.display = 'none';

            }}
    }
    
    function divPosition()
    {
        if (navigator.appName == "Netscape")

        {
            objouter.style.top = getAbsoluteHeight(objInput) + getAbsoluteTop(objInput) + "px";
            objouter.style.left = getAbsoluteLeft(objInput) + "px";
            //objouter.style.width = getAbsoluteWidth(objInput) + "px";
        }
        else
        {
            objouter.style.top = getAbsoluteHeight(objInput) + getAbsoluteTop(objInput) + "px";
            objouter.style.left = getAbsoluteLeft(objInput) + "px";
            //objouter.style.width = getAbsoluteWidth(objInput) + "px";
        }
    }
    function runlist(value)
    {
        checkAndShow();
        divPosition();
        var clientHeight = objouter.clientHeight;
        if (clientHeight != 0)
            objouter.innerHTML += "<iframe style='position:absolute;top:0px;left:0px; z-index:-1; width:"+ objouter.style.width + "; height:"+ objouter.clientHeight +  "' frameborder='0' scrolling='no'></iframe>";
    }

    function checkAndShow()
    {
        var strInput = objInput.value;
        if (strInput != ""&& strInput.length >= 3)
        {
            divPosition();
            var arrList = GetCitysList(strInput);
            selectedIndex = -1;
            objouter.innerHTML = "";
            if  (arrList.length > 0)
            {
            for (intTmp = 0; intTmp < arrList.length; intTmp ++)
            {
                if (intTmp <= 20)
                    addOption(arrList[intTmp], strInput, intTmp);
            }
            objouter.style.display = '';
            }
            else
            {
                objouter.style.display = 'none';
            }
        }
        else
            objouter.style.display = 'none';
        
        function addOption(value, keyw, intTmp)
        {   
            var v = value.replace("'", "");
            value = value.replace("'", "");
            var startStr = v.toUpperCase().indexOf(keyw.trim().toUpperCase());
            var endStr = startStr + keyw.trim().length;
            var changeStr = v.substring(startStr,endStr);
            v = v.substring(0, startStr)  +  "<span style='color:#ff6600; font-size:11px; font-weight:bold;'>"+ changeStr + "</span>"+ v.substring(endStr);
            var newDiv = "<div style=\"padding:5px; text-decoration:underline;\"onmouseover=\"document.getElementById('mouseindex').value=" + intTmp + ";var maxIndex;if(navigator.appName=='Netscape'){maxIndex = this.parentNode.childNodes.length - 1;}else{maxIndex = this.parentElement.childNodes.length - 1;}for(intTmp = 0;intTmp<=maxIndex;intTmp++){if(navigator.appName=='Netscape'){if(intTmp==" + intTmp + "){this.parentNode.childNodes[intTmp].className='sman_selectedStyle';}else{this.parentNode.childNodes[intTmp].className='';}}else{if(intTmp==" + intTmp + "){this.parentElement.children[intTmp].className='sman_selectedStyle';}else{this.parentElement.children[intTmp].className='';}}}\" onmouseout=\"this.className=''\"onmousedown=\"document.getElementById('"+ objInputId + "').value='"+ value.trim() + "'\">"+ v.trim() + "</div>";
            objouter.innerHTML += newDiv;
        }
    }
}
function getAbsoluteHeight(ob){
        return ob.offsetHeight;
}

function getAbsoluteWidth(ob){
    return ob.clientWidth + 200
}

function getAbsoluteLeft(ob){
    var s_el = 0;
    el = ob;
    while (el) {
        s_el = s_el + el.offsetLeft;
        el = el.offsetParent;
    }
    return s_el;
}

function getAbsoluteTop(ob) {
    var s_el = 0;
    el = ob;
    while (el) {
        s_el = s_el + el.offsetTop;
        el = el.offsetParent;
    }
    return s_el; 
}



function setArraylistAH()
{
    var myDate = new Date();
    var myDatestar = cc(myDate,7); 
    
    var myDateEnd = new Date(myDatestar.getFullYear() + 1 ,myDatestar.getMonth() , myDatestar.getDate() ) 


    document.getElementById("cityandairport").value = "AH";
    var arrList = GetCitysList("NYC");
    source = '1';
    if (document.getElementsByTagName('*').txtFullFrom_AH != null)
    {
        smanPromptList(arrList, "txtFullFrom_AH");
    }
    if (document.getElementsByTagName('*').txtFullTo_AH != null)
    {
        smanPromptList(arrList, "txtFullTo_AH");
    } 
    if (document.getElementsByTagName('*').txtDepartureFrom != null)
    {
        smanPromptList(arrList, "txtDepartureFrom");
    }
    
    if (document.getElementsByTagName('*').txtDestinationOne != null)
    {
        smanPromptList(arrList, "txtDestinationOne");
    }
    
    if (document.getElementsByTagName('*').txtDestinationTwo != null)
    {
        smanPromptList(arrList, "txtDestinationTwo");
    }
    
    
    if (document.getElementById("SearchEngineAH1_dateDeparture_AH_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineAH1_dateDeparture_AH_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('||0|0')
    }
    
    if (document.getElementById("SearchEngineAH1_dateReturn_AH_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineAH1_dateReturn_AH_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('SearchEngineAH1_dateDeparture_AH_calendarDate||0|0')
    }
    
    if (document.getElementById("SearchEngineAH1_CheckIn_AH_calendarDate") != null)
    {
       dateRangeKey.push('SearchEngineAH1_CheckIn_AH_calendarDate');
       dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
       dateLimitValue.push('SearchEngineAH1_dateDeparture_AH_calendarDate|SearchEngineAH1_dateReturn_AH_calendarDate|1|0')
    }
    
    if (document.getElementById("SearchEngineAH1_CheckOut_AH_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineAH1_CheckOut_AH_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('SearchEngineAH1_CheckIn_AH_calendarDate|SearchEngineAH1_dateReturn_AH_calendarDate|0|1')
    }
}
function setArraylistA()
{
    var myDate = new Date();
    var myDatestar = cc(myDate,3);  
    
    var myDateEnd = new Date(myDatestar.getFullYear() + 1 ,myDatestar.getMonth() , myDatestar.getDate() ) ;


    document.getElementById("cityandairport").value = "A";
    var arrList = GetCitysList("NYC");
    source = '1';
    if (document.getElementsByTagName('*').depFullCity != null)
        smanPromptList(arrList, "depFullCity");
    if (document.getElementsByTagName('*').toFullCity != null)
        smanPromptList(arrList, "toFullCity");
    if (document.getElementsByTagName('*').rtnFromFullCity != null)
        smanPromptList(arrList, "rtnFromFullCity");
    if (document.getElementsByTagName('*').rtnToFullCity != null)
        smanPromptList(arrList, "rtnToFullCity");
        
    if (document.getElementById("SearchEngineA1_depFlightCalendar_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineA1_depFlightCalendar_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('||0|0');
    }
    
    if (document.getElementById("SearchEngineA1_rtnFlightCalendar_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineA1_rtnFlightCalendar_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('SearchEngineA1_depFlightCalendar_calendarDate||0|0');
    }
}
function setArraylistP()
{
    var myDate = new Date();
    var myDatestar = cc(myDate,3);  
    
    var myDateEnd = new Date(myDatestar.getFullYear() + 1 ,myDatestar.getMonth() , myDatestar.getDate() ) ;


    document.getElementById("cityandairport").value = "P";
    var arrList = GetCitysList("NYC");
    source = '1';
    if (document.getElementsByTagName('*').depFullCity != null)
        smanPromptList(arrList, "depFullCity");
    if (document.getElementsByTagName('*').toFullCity != null)
        smanPromptList(arrList, "toFullCity");
    if (document.getElementsByTagName('*').rtnFromFullCity != null)
        smanPromptList(arrList, "rtnFromFullCity");
    if (document.getElementsByTagName('*').rtnToFullCity != null)
        smanPromptList(arrList, "rtnToFullCity");
        
    if (document.getElementById("SearchEngineA1_depFlightCalendar_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineA1_depFlightCalendar_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('||0|0');
    }
    
    if (document.getElementById("SearchEngineA1_rtnFlightCalendar_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineA1_rtnFlightCalendar_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('SearchEngineA1_depFlightCalendar_calendarDate||0|0');
    }
}

function setArraylistH()
{
    var myDate = new Date();
    var myDatestar = cc(myDate,7); 
    
    var myDateEnd = new Date(myDatestar.getFullYear() + 1 ,myDatestar.getMonth() , myDatestar.getDate() ) ;


    document.getElementById("cityandairport").value = "H";
    var arrList = GetCitysList("NYC");
    source = '2';
    if (document.getElementsByTagName('*').txtFullName != null)
    {smanPromptList(arrList, "txtFullName");}
    
    
    if (document.getElementById("SearchEngineH1_txtCheckin_h_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineH1_txtCheckin_h_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('||0|0')
    }
    
    if (document.getElementById("SearchEngineH1_txtCheckout_h_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineH1_txtCheckout_h_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('SearchEngineH1_txtCheckin_h_calendarDate||0|0')
    }
}
function setArraylistHB()
{
    var myDate = new Date();
    var myDatestar = cc(myDate,3); 
    
    var myDateEnd = new Date(myDatestar.getFullYear() + 1 ,myDatestar.getMonth() , myDatestar.getDate() ) ;


    document.getElementById("cityandairport").value = "H";
    var arrList = GetCitysList("NYC");
    source = '2';
    if (document.getElementsByTagName('*').txtFullName != null)
    {smanPromptList(arrList, "txtFullName");}
    
    
    if (document.getElementById("SearchEngineH1_txtCheckin_h_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineH1_txtCheckin_h_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('||0|0')
    }
    
    if (document.getElementById("SearchEngineH1_txtCheckout_h_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineH1_txtCheckout_h_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('SearchEngineH1_txtCheckin_h_calendarDate||0|0')
    }
}

function setArraylistT()
{
    var myDate = new Date();
    var myDatestar = cc(myDate,7);     
    var myDateEnd = new Date(myDatestar.getFullYear() + 1 ,myDatestar.getMonth() , myDatestar.getDate() ) ;    
    document.getElementById("cityandairport").value = "T";
    if (document.getElementById("SearchEngineT1_tourDeptCalendar_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineT1_tourDeptCalendar_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('||0|0');
    }
}
//car
function setArraylistC()
{
    var myDate = new Date();
    var myDatestar = cc(myDate,7);     
    var myDateEnd = new Date(myDatestar.getFullYear() + 1 ,myDatestar.getMonth() , myDatestar.getDate() ) ;
    document.getElementById("cityandairport").value = "C";
    var arrList = GetCitysList("NYC");
    source = '2';
    if (document.getElementsByTagName('*').txtCarFromFullName != null)
    {smanPromptList(arrList, "txtCarFromFullName");} 
    
    if (document.getElementsByTagName('*').txtCarToFullName != null)
    {smanPromptList(arrList, "txtCarToFullName");} 
    
    if (document.getElementById("SearchEngineC1_txtCheckin_h_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineC1_txtCheckin_h_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('||0|0')
    }    
    if (document.getElementById("SearchEngineC1_txtCheckout_h_calendarDate") != null)
    {
        dateRangeKey.push('SearchEngineC1_txtCheckout_h_calendarDate');
        dateRangeValue.push(Array( myDatestar + '|' + myDateEnd ));
        dateLimitValue.push('SearchEngineC1_txtCheckin_h_calendarDate||0|0')
    }    
}


//air
function ChangeFlightType(type)
{
    var flightType = document.forms[0].elements['FlightType'];	
    if( type == "roundtrip")
    {
	    flightType.value = "roundtrip";
	    document.getElementsByTagName("*").oneway1.style.display  = "";
	    document.getElementsByTagName("*").oneway2.style.display  = "";
	    document.getElementsByTagName("*").oneway3.style.display  = "";
	    document.getElementsByTagName("*").rtnFromFullCity.readOnly    = true;
	    document.getElementsByTagName("*").rtnToFullCity.readOnly      = true;
		
	    var txtDepCity = document.forms[0].elements['depFullCity'];
        var txtDesCity = document.forms[0].elements['toFullCity'];
  
	    document.getElementsByTagName("*").rtnFromFullCity.value       = txtDesCity.value;
	    document.getElementsByTagName("*").rtnToFullCity.value         = txtDepCity.value;
		
    }
    else if(type == "oneway")
    {
	    flightType.value = "oneway";
	    document.getElementsByTagName("*").oneway1.style.display  = "none";
	    document.getElementsByTagName("*").oneway2.style.display  = "none";
	    document.getElementsByTagName("*").oneway3.style.display  = "none";
	    document.getElementsByTagName("*").rtnFromFullCity.readOnly    = false;
	    document.getElementsByTagName("*").rtnToFullCity.readOnly      = false;
    }
    else if(type == "openjaw")
    {
	    flightType.value = "openjaw";
	    document.getElementsByTagName("*").oneway1.style.display  = "";
	    document.getElementsByTagName("*").oneway2.style.display  = "";
	    document.getElementsByTagName("*").oneway3.style.display  = "";
	    document.getElementsByTagName("*").rtnFromFullCity.readOnly    = false;
	    document.getElementsByTagName("*").rtnToFullCity.readOnly      = false;
    }
}

//Car
function ChangeCarType(type)
{
    var flightType = document.forms[0].elements['CarType'];	
    if( type == "S")
    {
	    flightType.value = "S";
	    document.getElementsByTagName("*").tbTo.style.display  = "none";
	    
	     var txtCarFromFullName = document.forms[0].elements['txtCarFromFullName'];
	    document.getElementsByTagName("*").txtCarToFullName.value = txtCarFromFullName.value;	
    }
    else if(type == "D")
    {
	    flightType.value = "D";
	    document.getElementsByTagName("*").tbTo.style.display  = "";
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

function SeachOrder(id)
{
    var e = document.getElementById("cityandairport");
    var searchtype = e.value.trim();    
    switch (searchtype)
    {
        case 'A':
        var airtype;
        if (document.getElementById("SearchEngineA1_rdbRoundTrip").checked)
            airtype = 'roundtrip';
        if (document.getElementById("SearchEngineA1_rdbOneway").checked)
            airtype = 'oneway';
        if (document.getElementById("SearchEngineA1_rdbOpenjaw").checked)
            airtype = 'openjaw';
        var fromah = document.getElementById("depFullCity").value;
        
        if (fromah == '')
        {
            alert('Invaluable search condition.');
            return;
        }
        
        var toah = document.getElementById("toFullCity").value;
        
        if (toah == '')
        {
            alert('Invaluable search condition.');
            return;
        }
        
        var drpdate = document.getElementById("SearchEngineA1_depFlightCalendar_calendarDate").value;
        var todate = document.getElementById("SearchEngineA1_rtnFlightCalendar_calendarDate").value;
        var rtnfromah = document.getElementById("rtnFromFullCity").value;
        var rtntoah = document.getElementById("rtnToFullCity").value;
        var isadd = document.getElementById("chkadd").checked;
        var Adults1 = document.getElementById("SearchEngineA1_ddlAdult").value;
        var Children1 = document.getElementById("SearchEngineA1_ddlChild").value;
        var airclass;
        if (document.getElementById("SearchEngineA1_rdoLstCabin_0").checked)
            airclass = 'ECONOMY';
        if (document.getElementById("SearchEngineA1_rdoLstCabin_1").checked)
            airclass = 'BUSINESS';
        if (document.getElementById("SearchEngineA1_rdoLstCabin_2").checked)
            airclass = 'FIRST';
        var aircode = document.getElementById("SearchEngineA1_txtAirline").value;
        
        var condition = "searchtype=" + searchtype + "&airtype=" + airtype + "&fromcity=" + fromah + "&tocity=" + toah + "&fromdate=" + drpdate + "&todate=" + todate + "&rtnfromah=" + rtnfromah;
        condition = condition + "&rtntoah=" + rtntoah + "&isadd=" + isadd + "&adults=" + Adults1 + "&children=" + Children1 + "&airclass=" + airclass + "&aircode=" + aircode;
        
        window.location.href="/page/Common/Searching1.aspx?" + condition;
        break;
        case 'AH':
        var fromah = document.getElementById("txtFullFrom_AH").value;
        if (fromah == '')
        {
            alert('Invaluable search condition.');
            return;
        }        
        var toah = document.getElementById("txtFullTo_AH").value;
        if (toah == '')
        {
            alert('Invaluable search condition.');
            return;
        }
        var drpdate = document.getElementById("SearchEngineAH1_dateDeparture_AH_calendarDate").value;
        var retdate = document.getElementById("SearchEngineAH1_dateReturn_AH_calendarDate").value;
        var isadd = document.getElementById("SearchEngineAH1_chbFlexible_AH").checked;
        var ishotel = document.getElementById("ckbHotel").checked;
        var checkin = document.getElementById("SearchEngineAH1_CheckIn_AH_calendarDate").value;
        var checkout = document.getElementById("SearchEngineAH1_CheckOut_AH_calendarDate").value;
        var roomnumber = document.getElementById("dllRooms").value;
        var Adults1 = document.getElementById("ddlAdult1").value;
        var Children1 = document.getElementById("Children1").value;
        var Adult2 = document.getElementById("ddlAdult2").value;
        var Children2 = document.getElementById("Children2").value;
        var Adult3 = document.getElementById("ddlAdult3").value;
        var Children3 = document.getElementById("Children3").value;
        var Adult4 = document.getElementById("ddlAdult4").value;
        var Children4 = document.getElementById("Children4").value;
        var airclass;
        if (document.getElementById("SearchEngineAH1_rdoLstCabin_AH_0").checked)
            airclass = 'ECONOMY';
        if (document.getElementById("SearchEngineAH1_rdoLstCabin_AH_1").checked)
            airclass = 'BUSINESS';
        if (document.getElementById("SearchEngineAH1_rdoLstCabin_AH_2").checked)
            airclass = 'FIRST';
        var aircode = document.getElementById("SearchEngineAH1_ddlAirline").value;
        var condition = "searchtype=" + searchtype + "&fromcity=" + fromah + "&tocity=" + toah + "&fromdate=" + drpdate + "&todate=" + retdate + "&checkin=" + checkin;
        condition = condition + "&checkout=" + checkout + "&isadd=" + isadd + "&airclass=" + airclass + "&aircode=" + aircode + "&roomnumber=" + roomnumber + "&ishotel=" + ishotel;
        condition = condition + "&a1=" + Adults1 + "&c1=" + Children1 + "&a2=" + Adult2 + "&c2=" + Children2 + "&a3=" + Adult3 + "&c3=" + Children3 + "&a4=" + Adult4 + "&c4=" + Children4;
        
        window.location.href="/page/Common/Searching1.aspx?" + condition;
        break;
        case 'H':
        var cityname = document.getElementById("txtFullName").value;
        if (cityname == '')
        {
            alert('Invaluable search condition.');
            return;
        }
        var checkin = document.getElementById("SearchEngineH1_txtCheckin_h_calendarDate").value;
        var checkout = document.getElementById("SearchEngineH1_txtCheckout_h_calendarDate").value;
        var roomnumber = document.getElementById("dllRooms").value;
        var Adults1 = document.getElementById("ddlAdult1").value;
        var Children1 = document.getElementById("ddlChildren1").value;
        var Adult2 = document.getElementById("ddlAdult2").value;
        var Children2 = document.getElementById("ddlChildren2").value;
        var Adult3 = document.getElementById("ddlAdult3").value;
        var Children3 = document.getElementById("ddlChildren3").value;
        var Adult4 = document.getElementById("ddlAdult4").value;
        var Children4 = document.getElementById("ddlChildren4").value;
        var condition = "searchtype=" + searchtype + "&city=" + cityname + "&checkin=" + checkin + "&checkout=" + checkout + "&roomnumber=" + roomnumber;
        condition = condition + "&a1=" + Adults1 + "&c1=" + Children1 + "&a2=" + Adult2 + "&c2=" + Children2 + "&a3=" + Adult3 + "&c3=" + Children3 + "&a4=" + Adult4 + "&c4=" + Children4;
        window.location.href="/page/Common/Searching1.aspx?" + condition;
        break;
        case 'T':
        var landonly = document.getElementById("rdbLandOnly").checked;
        var area = document.getElementById("ddlAreaT").value;
        var country = document.getElementById("ddlCountry_T").value;
        var region = document.getElementById("ddlAreaT").value;
        var counrty = document.getElementById("ddlCountry_T").value;
        var city = document.getElementById("ddlCity_T").value;
        var tourdate = document.getElementById("SearchEngineT1_tourDeptCalendar_calendarDate").value;
        var traveldate = document.getElementById("ddlTravelDate").value;
        var condition = "searchtype=" + searchtype + "&landonly=" + landonly + "&city=" + city + "&tourdate=" + tourdate + "&traveldate=" + traveldate;
        condition = condition + "&region=" + region + "&counrty=" + counrty;
        window.location.href="/page/Common/Searching1.aspx?" + condition;
        break;
        case 'P':
        var airtype;
        if (document.getElementById("SearchEngineA1_rdbRoundTrip").checked)
            airtype = 'roundtrip';
        if (document.getElementById("SearchEngineA1_rdbOneway").checked)
            airtype = 'oneway';
        if (document.getElementById("SearchEngineA1_rdbOpenjaw").checked)
            airtype = 'openjaw';
        var fromah = document.getElementById("depFullCity").value;
        var toah = document.getElementById("toFullCity").value;
        var drpdate = document.getElementById("SearchEngineA1_depFlightCalendar_calendarDate").value;
        var todate = document.getElementById("SearchEngineA1_rtnFlightCalendar_calendarDate").value;
        var rtnfromah = document.getElementById("rtnFromFullCity").value;
        var rtntoah = document.getElementById("rtnToFullCity").value;
        var isadd = document.getElementById("chkadd").checked;
        var Adults1 = document.getElementById("SearchEngineA1_ddlAdult").value;
        var Children1 = document.getElementById("SearchEngineA1_ddlChild").value;
        var airclass;
        if (document.getElementById("SearchEngineA1_rdoLstCabin_0").checked)
            airclass = 'ECONOMY';
        if (document.getElementById("SearchEngineA1_rdoLstCabin_1").checked)
            airclass = 'BUSINESS';
        if (document.getElementById("SearchEngineA1_rdoLstCabin_2").checked)
            airclass = 'FIRST';
        var aircode = document.getElementById("SearchEngineA1_txtAirline").value;
        
        var condition = "searchtype=" + searchtype + "&airtype=" + airtype + "&fromcity=" + fromah + "&tocity=" + toah + "&fromdate=" + drpdate + "&todate=" + todate + "&rtnfromah=" + rtnfromah;
        condition = condition + "&rtntoah=" + rtntoah + "&isadd=" + isadd + "&adults=" + Adults1 + "&children=" + Children1 + "&airclass=" + airclass + "&aircode=" + aircode;
        
        window.location.href="/page/Common/Searching1.aspx?" + condition;
        break;
        case 'C':
        var fromcity = document.getElementById("txtCarFromFullName").value;
        var tocity = document.getElementById("txtCarToFullName").value;
        var checkindate = document.getElementById("SearchEngineC1_txtCheckin_h_calendarDate").value;
        var checkoutdate = document.getElementById("SearchEngineC1_txtCheckout_h_calendarDate").value;
        var cartype = document.getElementById("cartypeRegular").value;
        var carCodeType;
              
        if (document.getElementById("rdSame").checked)
            carCodeType = 'S';
        if (document.getElementById("raDifferent").checked)
            carCodeType = 'D';
            
        if (carCodeType == 'S')
        {
            if (fromcity == '')
            {
                alert('please select From \(airport\)');
                return;
            }
        }
        else
        {
            if (fromcity == '')
            {
                alert('please input Trom \(airport\)');
                return;
            }
            
            if (tocity == '')
            {
                alert('please input to');
                return;
            }
        }
            
        var checkintime = document.getElementById("SearchCar_in_date").value;
        var checkouttime = document.getElementById("SearchCar_out_date").value;
        
        var condition = "searchtype=" + searchtype + "&cartype=" + cartype + "&carcodetype=" + carCodeType + "&fromcity=" + fromcity + "&tocity=" + tocity + "&checkindate=" + checkindate + "&checkoutdate=" + checkoutdate + "&checkintime=" + checkintime + "&checkouttime=" + checkouttime;
        
        window.location.href="/page/Common/Searching1.aspx?" + condition;
        break;
    }
    
}


String.prototype.trim=function(){return this.replace(/^\s+|\s+$/g,"")} 


function SetRepeatHotel()
{
    document.getElementById("cityandairport").value = "H";
    var arrList = GetCitysList("NYC");
    if (document.getElementsByTagName('*').HotelOnlySearchControl1_txtFullName != null)
    {smanPromptList(arrList, "HotelOnlySearchControl1_txtFullName");}
}

function SetRepeatCar()
{
    document.getElementById("cityandairport").value = "H";
    var arrList = GetCitysList("NYC");
    if (document.getElementsByTagName('*').VehcileOnlySearchControl1_txtCarFromFullName != null)
    {smanPromptList(arrList, "VehcileOnlySearchControl1_txtCarFromFullName");}
    if (document.getElementsByTagName('*').VehcileOnlySearchControl1_txtCarToFullName != null)
    {smanPromptList(arrList, "VehcileOnlySearchControl1_txtCarToFullName");}
}



function SetRepeatPackage()
{
    document.getElementById("cityandairport").value = "AH";
    var arrList = GetCitysList("NYC");
    if (document.getElementsByTagName('*').PackageLeftSelect1_txtFrom != null)
    {smanPromptList(arrList, "PackageLeftSelect1_txtFrom");}
    if (document.getElementsByTagName('*').PackageLeftSelect1_txtTo != null)
    {smanPromptList(arrList, "PackageLeftSelect1_txtTo");}
}

function cc(dd,dadd){
var a = new Date(dd)
a = a.valueOf()
a = a + dadd * 24 * 60 * 60 * 1000
a = new Date(a)
return a;
}

function ReleaseEvents()
{
    var events = ["focus", "blur", "change", "click", "mousedown",
                  "mouseup", "mouseover", "keypress", "keydown",
                  "keyup", "keypress"];

    var helper = function(obj)
    {
        var i;
        if (events != null)
            {
        for (i = 0; i < events.length; i++)
            obj["on" + events[i]] = null;
            }
            if (parent.childNodes != null)
            {
        for (i = 0; i < parent.childNodes.length; i++)
            helper(parent.childNodes[i]);
            }
    }

    helper(document);
}
window.onunload = ReleaseEvents;

 function SetCal(obj,txt)
{
    var cal='calendarDate';
    if(txt.length>0)
    {
        cal = txt+'_'+ cal;
    }
    SC(document.getElementById(cal));
}
 function fillMarkup(a)
 {    
    var elems = document.getElementById("form1").getElementsByTagName("INPUT");
    
    var pirce = 0;
    var pirce1 = 0;
    
    var Roompriceflag = false;
    
    var DailyRate = document.getElementById("VehcilePriceInfoControl1_lblDailyRate").innerHTML; 
    var Days = document.getElementById("VehcilePriceInfoControl1_lblDays").innerHTML;  
    
    var priceHtem = ''; 
    
    var AllEquipmentsPrice = 0;
    
    var count = 0;
    
    var error = null
    
    for(i=0;i<elems.length;i++)
    {
        if (elems[i].type=="checkbox")
        {
            if (elems[i].checked)
            {
                if (elems[i].id != a.id)
                {
                    var EquipmentsName = document.getElementById(elems[i].id.substr(0,48) + "_lblEquipmentsName").innerHTML;
                    var EquipmentsPrice = document.getElementById(elems[i].id.substr(0,48) + "_lblEquipmentsPrice").innerHTML;
                    
                    priceHtem = priceHtem + "<table width='100%' align='center' border='0' cellpadding='0' cellspacing='0'>";
                    priceHtem = priceHtem + "<tbody><tr valign='top' align='left'><td width='50%' height='20' align='left' style='border-bottom: solid #cccccc 1px;'>";
                    priceHtem = priceHtem + "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td width='50%' height='30' align='left'>";
                    priceHtem = priceHtem + EquipmentsName + "</td><td align='right'>" + EquipmentsPrice + "</td></tr></table></td></tr></tbody></table>";
       
                    if (EquipmentsPrice != 'free')
                    {
                        AllEquipmentsPrice = Number(AllEquipmentsPrice) + Number(EquipmentsPrice.replace('$', ''));
                    }
                }
                count = count + 1;
            }
        }
    }

    if (count > 5)
    {
        a.checked = false;
        error = 'Optional equipment available for this rental, chose up to 5 additional items';
    }
    else
    {
        if (a.checked)
        {
            var EquipmentsNameNew = document.getElementById(a.id.substr(0,48) + "_lblEquipmentsName").innerHTML;
            var EquipmentsPriceNew = document.getElementById(a.id.substr(0,48) + "_lblEquipmentsPrice").innerHTML;
            
            priceHtem = priceHtem + "<table width='100%' align='center' border='0' cellpadding='0' cellspacing='0'>";
            priceHtem = priceHtem + "<tbody><tr valign='top' align='left'><td width='50%' height='20' align='left' style='border-bottom: solid #cccccc 1px; '>";
            priceHtem = priceHtem + "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tr><td width='50%' height='30' align='left'>";
            priceHtem = priceHtem + EquipmentsNameNew + "</td><td align='right'>" + EquipmentsPriceNew + "</td></tr></table></td></tr></tbody></table>";
             
            if (EquipmentsPriceNew != 'free')
            {
               AllEquipmentsPrice = Number(AllEquipmentsPrice) + Number(EquipmentsPriceNew.replace('$', ''));
            }
        }
    }
    document.getElementById("VehcilePriceInfoControl1_lblTotalPrice").innerHTML = changeTwoDecimal_f((Number(DailyRate) * Number(Days)) + Number(AllEquipmentsPrice));    
    document.getElementById("VehcilePriceInfoControl1_lblEquipments").innerHTML = priceHtem;    
    if (error != null)
    {
        alert(error);
    }
 }
 function changeTwoDecimal_f(x)
{
   var f_x = parseFloat(x);
   if (isNaN(f_x))
   {
      alert('function:changeTwoDecimal->parameter error');
      return false;
   }
   var f_x = Math.round(x*100)/100;
   var s_x = f_x.toString();
   var pos_decimal = s_x.indexOf('.');
   if (pos_decimal < 0)
   {
      pos_decimal = s_x.length;
      s_x += '.';
   }
   while (s_x.length <= pos_decimal + 2)
   {
      s_x += '0';
   }
   return s_x;
}

