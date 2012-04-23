
	
	//Suppress JavaScript Errors:
	function errHandler(){
		return true;
	}
	
	window.onerror = errHandler;
	
	// detect browser type 
	function init(){
	  this.ver=navigator.appVersion
	  this.agent=navigator.userAgent	  
	  this.dom=document.getElementById?1:0
	  this.opera5=this.agent.indexOf("Opera 5")>-1
	  this.ie5=(this.ver.indexOf("MSIE 5")>-1 && this.dom && !this.opera5)?1:0; 
	  this.ie6=(this.ver.indexOf("MSIE 6")>-1 && this.dom && !this.opera5)?1:0;
	  this.ie7=(this.ver.indexOf("MSIE 7")>-1 && this.dom && !this.opera5)?1:0;
	  this.ie8=(this.ver.indexOf("MSIE 8")>-1 && this.dom && !this.opera5)?1:0;
	  this.ie4=(document.all && !this.dom && !this.opera5)?1:0;
	  this.ie=this.ie4||this.ie5||this.ie6||this.ie7||this.ie8
	  this.mac=this.agent.indexOf("Mac")>-1
	  this.ns6=(this.dom && parseInt(this.ver) >= 5) ?1:0; 
	  this.ns4=(document.layers && !this.dom)?1:0;
	  this.bw=(this.ie6||this.ie5||this.ie4||this.ns4||this.ns6||this.opera5)
	  return this
	}
	bw=new init();
	
	
 
	// hide and Show funtions..
	function show(div){
		obj=bw.dom? document.getElementById(div).style:bw.ie?document.all[div].style:
			bw.ns4?document.layers[div]:0;
		if(obj) {obj.display='block';obj.visibility='visible';}
	}
	
	function hide(div){
		obj=bw.dom? document.getElementById(div).style:bw.ie?document.all[div].style:
			bw.ns4?document.layers[div]:0;
	if(obj){ obj.display='none'; obj.visibility='hidden';}
	}
	
	
	/* new function added by John */
	function setZIndex(div, zIndex){
		obj=bw.dom? document.getElementById(div).style:bw.ie?document.all[div].style:
			bw.ns4?document.layers[div]:0;
	if(obj){ obj.zIndex=Number(zIndex);}	
	}


	// check for hide and show status..
	function chkShow(div){
		ShowStatus = false;
		obj=bw.dom? document.getElementById(div).style:bw.ie?document.all[div].style:
			bw.ns4?document.layers[div]:0;
		if(obj){
			if(obj.display=='block' || obj.visibility=='visible'){
				ShowStatus = true;
			}
		}
		return ShowStatus
	}
	
	function chkHide(div){
		HideStatus = false;
		obj=bw.dom? document.getElementById(div).style:bw.ie?document.all[div].style:
			bw.ns4?document.layers[div]:0;
		if(obj){
			if(obj.display=='none' || obj.visibility=='hidden'){
				HideStatus = true;
			}
		}
		return HideStatus
	}	
		
	


	function Pose(div){	
		obj=bw.dom? document.getElementById(div).style:bw.ie?document.all[div].style:
			bw.ns4?document.layers[div]:0;
		if(obj){
			obj.width = zdoc.x2-50;
			obj.height = zdoc.y2;
			DivMiddleH = parseInt(obj.width)/2;			
			//document.write(DivMiddleH);
			obj.left = zdoc.x50 - DivMiddleH;
			
					} 
	}
	

var delay = 1000;
var NS = navigator.appName == "Netscape";
var IE = navigator.appVersion.indexOf("MSIE") != -1;
var strTds2 = ""
var TimerID
var HideTimerID
strTds1 = '<table bgcolor="Navy" cellpadding="1" cellspacing="0" width="170" align="center" height="5"><tr><td>';
strTds1 = strTds1 + '<table cellpadding="0" cellspacing="0" bgcolor="White" width="100%" align="center"><tr>';
strTds3 = '</tr></table></td></tr></table>';
var percentage = 0
var i = 4

    function animate(Action) 
	{       
	    i=i+1;
	    var Factor = (1/i);
	    //var now = new Date().getTime();
	    percentage = percentage + Factor* (100-percentage) ;
	    DisplayPercentage = Math.floor(percentage);
	    if (percentage < 100)
			{
	   			if (Action =="Full")
	   				{
	   					strTds2 ='<td height="10" nowarp="" bgcolor="Navy" width="100%"><br></td><td nowarp="" bgcolor="white" width="0%"><br></td>';
						strTds = strTds1 + strTds2 + strTds3;
						strText ='<center><span style="color:navy; font-weight:bold; font-size:9pt;">100% Completed</span></center>';
					}
	   			else
	   				{
	   					strTds2 ='<td height="10" nowarp="" bgcolor="Navy" width="' + DisplayPercentage + '%"><br></td>'
	   					strTds2 =strTds2 + '<td nowarp="" bgcolor="white" width="' + (100 - DisplayPercentage) + '%"><br></td>';
						strTds = strTds1 + strTds2 + strTds3;
						strText ='<center><span style="color:navy; font-weight:bold; font-size:9pt;">' + DisplayPercentage + '% Completed</span></center>';
					}
				/*
				if (IE)
					{
						x.innerHTML = strTds;
						y.innerHTML = strText;
					}
				else if (NS) 
					{

					    document.x.document.open("text/html"); 
					    document.x.document.write(strTds);
					    document.x.document.close();
					    
					    document.y.document.open("text/html"); 
					    document.y.document.write(strText);
					    document.y.document.close();					    					    
					}
				*/
				if(bw.ie){
						x.innerHTML = strTds;
						y.innerHTML = strText;				
				}
				/*
				else if(bw.ns4){
					    document.x.document.open("text/html"); 
					    document.x.document.write('asdasdfs'); //strTds
					    document.x.document.close();
					    
					    document.y.document.open("text/html"); 
					    document.y.document.write(strText);
					    document.y.document.close();				
				}
				*/

			}
		else
			{
				clearTimeout(TimerID); 	
			}
	   if (Action =="Full") 
			TimerID = setTimeout("animate('Full')", delay);
		else
			TimerID = setTimeout("animate('')", delay);
	}


    function Finish(Action) 
	{       
	   if (Action =="Finish") 
			{
				clearTimeout(HideTimerID);
				hide('wait');
			}
		else
			{
				clearTimeout(TimerID); 	
				animate('Full');		
				HideTimerID = setTimeout("Finish('Finish')", 1000);
			}
	}
var isload1 = 1;
	function doc_size(){ //Page positions - needed!
		this.x=0;
		this.x2= bw.ie && document.body.offsetWidth-5||innerWidth||0;
		this.y=0;
		this.y2= bw.ie  && document.body.offsetHeight-5||innerHeight||0;
		if(!this.x2||!this.y2) return alert('Document has no width or height') 
		this.x50=this.x2/2;     this.y50=this.y2/2;
		this.x10=(this.x2*10)/100;this.y10=(this.y2*10)/100
		return this;
	}
   
  zdoc = new doc_size();
