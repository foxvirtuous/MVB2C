var cF=null;cN=null;var cW=null;var g_tid=0;var g_cP,g_eD,g_eDP;
var nextFocus;var g_fNoCal=false;

function getEventObj(e){if(!e)e=window.event;return e;}

function stopBubble(e){e=getEventObj(e);e.cancelBubble=true;if(e.stopPropagation)e.stopPropagation();}

function CB(){stopBubble(event);}

function SCal(e){
 clearTimeout(g_tid);
 if(g_fNoCal){g_fNoCal=false;return;}
//	if(g_calShown)return;
	g_calShown = true;
	g_calCB = null;
 g_cP=e;
 g_eD=e;
 g_eDP=e;
 WaitCal(e.id);}
function CancelCal(){clearTimeout(g_tid); if(!cF)cF=getObj(e.id+'Frame');cF.style.visibility="hidden";g_calShown=false;}
function WaitCal(id)
{ 
    
    //cN=getObj(id+'Frame');
    cN=getObj('calendarDateFrame');
   
 if(!cW)cW=frames['calendarDateFrame'];
 else
 {
    if(cF != cN)cW=frames['calendarDateFrame'];       
 }

 if(null==cW||null==cW.g_fCL||false==cW.g_fCL){
	g_tid=setTimeout("WaitCal('"+id+"')", 200);
	}
 else{
    if(cF!=null)
    {  // cF=getObj(id+'Frame');
      
        if(cF != cN)
        {
	        cF.style.visibility="hidden"; 
	        }
	}
	cF=cN;
	DoCal(id)
	//setTimeout("DoCal('"+id+"')",1);
	}	
}
function DoCal(id){PosCal(g_cP);
if(!cW)cW=frames['calendarDateFrame'];
else
{
 if(cF != cN)cW=frames['calendarDateFrame'];     
}

cW.DoCal(g_cP,null);}

function getScrollTop()
{
	if(document.documentElement.scrollTop) return document.documentElement.scrollTop;
	if(document.body.scrollTop) return document.body.scrollTop;
	if(window.pageYOffset) return window.pageYOffset;
	return 0;
}

function getWinHeight()
{
	if(window.innerHeight) return window.innerHeight;
	if(document.documentElement.clientHeight) return document.documentElement.clientHeight;
	if(document.body.clientHeight) return document.body.clientHeight;
	return 0;
}

function PosCal(cP)
{
	var dB=document.body;var eL=0;var eT=0;
 if(!cF)cF=getObj('calendarDateFrame');
	for(var p=cP;p&&p.tagName!='BODY';p=p.offsetParent){eL+=p.offsetLeft;eT+=p.offsetTop;}
	var eH=cP.offsetHeight;var dH=parseInt(cF.style.height);var sT=getScrollTop();
	if(eT-dH>=sT&&eT+eH+dH>getWinHeight()+sT)eT-=dH;else eT+=eH;
	cF.style.left=eL+'px';cF.style.top=eT+'px';
	
	
}

function SetNextFocus(e){nextFocus=e;if(nextFocus)nextFocus.onfocus=CancelCal;}
function SetPrevFocus(e){if(e)e.onfocus=CancelCal;}

function FGoNextFocus(){if(nextFocus){nextFocus.focus();return true;}return false;}

function CalSetFocus(e){if(e){g_fNoCal=true;e.focus();setTimeout("EndCalFocus()", 200);}}
function EndCalFocus(){g_fNoCal=false;}

function CalDateSet(eInp,d,m,y,giveFocus)
{
	var ds=GetDateSep();
	var fmt=GetDateFmt();

	if(fmt=="mmddyy")eInp.value=m+ds+d+ds+y;
	else if(fmt=="ddmmyy")eInp.value=d+ds+m+ds+y;
	else eInp.value=y+ds+m+ds+d;
	if(!giveFocus)
	CalSetFocus(eInp);
}

var g_calShown = false;
function SetCalShown(fcshown){g_calShown=fcshown;}

var g_calCB;
function CalendarCallback(){if(g_calCB)g_calCB();}
function SetCalendarCallback(cb){g_calCB=cb;}


function GetInputDate(t)
{
	if(!t.length) return null;
	t=t.replace(/\s+/g,"");
	if(t.match(/[^-|\d|\.|\/]/)) return null;
	var rgt=t.split(/-|\.|\//);
	for(var i=0;i<rgt.length;i++) rgt[i]=parseInt(rgt[i],10);
	if(!rgt[1]) return null;
	var m,d,y;
	var fmt=GetDateFmt();
	if(fmt=="yymmdd")
	{
	if(!rgt[2]) return null;
	m=rgt[1];d=rgt[2];y=rgt[0];
	}
	else
	{
	if(fmt=="mmddyy"){m=rgt[0];d=rgt[1];}
	else{m=rgt[1];d=rgt[0];}//fmt=="ddmmyy"
	if(rgt[2])y=rgt[2];
	else y=DefYr(m-1,d);
	}
	m-=1;if(y<100)y+=2000;
	if(y<1601||y>4500||m<0||m>11||d<1||d>GetMonthCount(m,y))return null;
	return new Date(y,m,d);
}

var rM=new Array(12);rM[0]=rM[2]=rM[4]=rM[6]=rM[7]=rM[9]=rM[11]=31;rM[3]=rM[5]=rM[8]=rM[10]=30;rM[1]=28;
function GetMonthCount(m,y){var c=rM[m];if((1==m)&&IsLY(y))c++;return c;}
function IsLY(y){if(0==y%4&&((y%100!=0)||(y%400==0)))return true;else return false;}
function DefYr(m,d){var dt=new Date();var yC=(dt.getYear()<1000)?1900+dt.getYear():dt.getYear();if(m<dt.getMonth()||(m==dt.getMonth()&&d<dt.getDate()))yC++;return yC;}



function SC(el)
{
	if (DE('calendarDateFrame') == null){return;}
	var id = el.id;
	var n = el.id.substr(5);
	el.select();ShowCalendar(el);
//	if (id.substr(0,5) == 'fdate')
//	{
//		el.select();
//		if(n == ''){ShowCalendar(el,el,null,CalS,CalE);}
//		else if(n == '2'){ShowCalendar(el,el,DE('fdate'),CalS,CalE);}
//		else{ShowCalendar(el,el,DE('fdate' + (n - 1)),CalS,CalE);}
//		
//	}
//	if (id.substr(0,5) == 'tdate'){el.select();ShowCalendar(el,el,DE('fdate'),CalS,CalE);}
}


function HCal()
{
   
    if(g_cP)
    {
	    var c = DE('calendarDateFrame');
	    //if (c!=null){SH(c,false);}
	   
	    if (c!=null){CancelCal();}
	}
//	var d;
//	d = DE('fdate');
//	if (d!=null){d.value = d.value;}
//	d = DE('tdate');
//	if (d!=null){d.value = d.value;}
}

function UpdDt(e)
{    
//    switch(e.id)
//    {
//        case "fdate":
//            var f = DE('fdate');
//            var t = DE('tdate');
//            break;
//        case "pfd":
//            var f = DE('pfd');
//            var t = DE('ptd');
//            break;
//        default:
//            var f = null;
//            var t = null;
//            break;
//    }

//    if(null!=f&&null!=t&&null!=GetInputDate(f.value)&&(null==GetInputDate(t.value)||GetInputDate(f.value)>GetInputDate(t.value))){t.value=f.value;}    
}

function DE(el){return document.getElementById(el);}

function SB(){this.Concat = Concat;this.GetValue = GetValue;this.Reset = Reset;}

var aS = new Array();

function Concat(StringToConcat){this.aS[this.aS.length] = StringToConcat;}

function GetValue(){return this.aS.join('');}

function Reset(){this.aS = null;this.aS = new Array();}


var FDate = 'mm/dd/yy';
var TDate = 'mm/dd/yy';
var CalS = '';
var CalE = '';
var nextFocus = null;

function RemG(el)
{
//	var n = el.id.substr(5);
//	switch (el.id.substr(0,5))
//	{
//		
//		case 'fdate':FDate = el.value;DE('FDate').value = FDate;break;
//		case 'tdate':TDate = el.value;DE('TDate').value = TDate;break;
//	}
}

function GetSavedValuesG()
{
	var v;
	
//	v = DE('FDate').value;if (v != '') {FDate = v;}
//	v = DE('TDate').value;if (v != '') {TDate = v;}


	CalS = DE('CalS').value;
	CalE = DE('CalE').value;

	var sdt = new Date(CalS);
	var edt = new Date(CalE);
	var j = 0;
	var sm = sdt.getMonth() + 1;
	var em = 12;
	if(sdt.getYear() == edt.getYear())
	{
	    em = edt.getMonth() + 1;
	}
	for (var i = sm;i <= em;i++)
	{
	    j = j + 1;
	}
	if(edt.getYear() > sdt.getYear())
	{
	    for (var i = 1;i <= edt.getMonth() + 1;i++)
	    {
	        j = j + 1;
	    }
	}
    if(j > 0){nm = j;}
}


document.onclick = HCal;
