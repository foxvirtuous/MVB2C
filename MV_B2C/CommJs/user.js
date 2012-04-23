// JScript 文件

var newClass = new Object();
newClass.Create = function(){
  return function(){
    this.init.apply(this,arguments);
  }
}


var $ = function(id){
  if(typeof(id) == "string"){
    return document.getElementById(id);
  }
}
document.getElementsByClassName = function(className) { 
  var children = document.getElementsByTagName('*') || document.all; 
  var elements = new Array(); 
  
  for (var i = 0; i < children.length; i++) { 
    var child = children[i]; 
    var classNames = child.className.split(' '); 
    for (var j = 0; j < classNames.length; j++) { 
      if (classNames[j] == className) { 
        elements.push(child); 
        break; 
      } 
    } 
  } 
  
  return elements; 
}
///////////////////////////AJAX//////////////////////////////////
var Request = {
  getRequest:function(){
    var http_request = false;
    try{
      http_request = new ActiveXObject("Msxml2.XMLHTTP");
    }catch(ex){
      try{
        http_request = new ActiveXObject("Microsoft.XMLHTTP");
      }catch(ex2){
        http_request = false;
        //throw ex2;
      }
    }
    if(!http_request && typeof XMLHttpRequest !== 'undefined'){
      http_request = new XMLHttpRequest();
    }
    return http_request;
  }
};
var Ajax = newClass.Create();
Ajax.prototype = {
init:function(url,option,postback){
    this.quest = Request.getRequest();
    this.url = url;
    this.option = {
    method:option.method?option.method:"GET",
    
    async: option.async?option.async:"true",
    parameters: option.parameters?option.parameters:""
    }
    
    try{
        if(this.option.method == "GET"){
          this.url += '?' + this.option.parameters;
          this.quest.open(this.option.method,this.url,this.option.async);
          //this.quest.onreadystatechange = postback(this.quest);
          this.quest.send(null);
        }else if(this.option.method == "POST"){
          this.quest.open(this.option.method,this.url,this.option.async);
          //this.quest.onreadystatechange = postback(this.quest);
          this.quest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
          this.quest.send(this.option.parameters + '&_=');
        }
    }catch(e){
        //throw e;
    }
    
  }
  
};


/////////////////////XML DATA REQUEST//////////////////////////////////


var loadXML = newClass.Create();

loadXML.prototype = {
init:function(xmlFile,title,valueName,chartType){
  this.xmlFile = xmlFile;
  this.title = title;
  this.type = chartType;
  this.valueName = valueName;
  this.x_labels = new Array();
  this.values = new Array();
  this.loadxml(this.xmlFile);
  this.Max();
  },
loadxml:function(xmlFile){
  if(window.ActiveXObject){
    this.xml = new ActiveXObject('Microsoft.XMLDOM');
    this.xml.async = false;
    this.xml.load(xmlFile);
  }else if(document.implementation && document.implementation.createDocument){
    this.xml = document.implementation.createDocument('','',null);
    this.xml.async = false;
    this.xml.load(xmlFile);
  }else{
    return null;
  }
  this.fillData();

  },
fillData:function(){
    var list = this.xml.getElementsByTagName('webs')[0].getElementsByTagName('data');
    for(var i=0;i<list.length;i++){
      this.x_labels[i] = list[i].getAttribute('date');
      this.values[i] = list[i].getAttribute('search');
    }
  },
  Max:function(){
    var tempMax = 0;
    for(var i=0;i<this.values.length-1;i++){
      var j = i+1;
      tempMax = (Number(this.values[i])>Number(this.values[j]))?Number(this.values[i]):Number(this.values[j]);
    }
    this.maxY = tempMax + parseInt(tempMax/3);
    
    return this.maxY;
  }
}


/////////////////////new Block///////////////////////////

var block = newClass.Create();
block.prototype = {
  init: function(obj,className){
    this.className = className;
    this.block;
	this.obj = obj;
	this.create();
	this.appendHTML();
	this.instance(obj);
	this.call(100);
  },
  
  instanceBlock: function(){
    return document.createElement("div");
  },
  create: function(){
    this.block = this.instanceBlock();
  },
  appendHTML: function(){
    
    this.block.className = this.className;
  },
  instance: function(){
	
    this.obj.appendChild(this.block);

  },
  call: function(int){
  	function call(int){
	  alert(int);
	}
    this.block.onclick = function(){call(int)};

  }
}


//////////////////////////pOp//////////////////////////////////
 
  var pOp = newClass.Create();
  pOp.prototype = {
    init:function(obj){
	 this.obj = obj;
	 this.dd;
	 this.newblock = document.createElement("div");
	 this.newblock.className = "out2";
	 this.obj.appendChild(this.newblock);
	 this.over();
    },
	over:function(){
	
	var temp = this.obj.detachEvent?(this.obj).detachEvent("onmouseover",Event.bind):this.obj.removeEventListener("mouseover",Event.bind,"");
	},
	out:function(obj){
      this.obj = obj;
	  this.dd = setTimeout((function(){
									 if(this.newblock.parentNode && this.newblock.nodeName == "DIV"){
										 
										 this.obj.removeChild(this.newblock);
										 
										 };
										 
										 
										 var temp = this.obj.attachEvent?this.obj.attachEvent("onmouseover",Event.bind):this.obj.addEventListener("mouseover",Event.bind,"");}).bind(this),1);
	},
	move:function(){
	  clearTimeout(this.dd);
	}
  }

Function.prototype.bind = function(obj){
  var method = this;
  return function(){
    method.apply(obj,arguments);
  }
}
var $ = function(id){
  if(typeof(id) == "string"){
    return document.getElementById(id);
  }
}


var Event = {
	bind:function(e){
    var e = window.event?window.event:e;
	var srcelement = e.srcElement?e.srcElement:e.target;
    var newblock = new pOp(srcelement);
  
  var out = srcelement.attachEvent?srcelement.attachEvent("onmouseout",function(){newblock.out(srcelement)}):srcelement.addEventListener("mouseout",function(){newblock.out(srcelement)},"");
  var move = srcelement.attachEvent?srcelement.attachEvent("onmousemove",function(){newblock.move()}):srcelement.addEventListener("mousemove",function(){newblock.move()},"");
  }
	}



//////////////////////////sort////////////////////////////////
function childNode(obj){
  var array = new Array();

  var childs = obj.getElementsByTagName("DIV");
  var dfeff = new Array();
  for(var i=0;i<childs.length;i++){
    if(childs[i].className == "outside1T"){
      dfeff.push(childs[i]);
    }
  }

  for(var i=0;i<dfeff.length;i++){
    if(dfeff[i].nodeType == 1){
	  array.push(dfeff[i]);
	}
  }
  
  return array;
}

function thound(value){
  if(value.indexOf(",") != -1){
    var values = value.split(",");
  return Number(values[0])*1000 + Number(values[1]);
  }else{
    return value;
  }
  
}
var Sort_sel = {
  Int:function(coll){
       if(thound(coll[0].innerHTML.substring(1,coll[0].innerHTML.length))>thound(coll[coll.length-1].innerHTML.substring(1,coll[0].innerHTML.length))){
         return -1;
       }else if(thound(coll[0].innerHTML.substring(1,coll[0].innerHTML.length))<thound(coll[coll.length-1].innerHTML.substring(1,coll[0].innerHTML.length))){
       return 1;
       }else{
         return;
       }
     },
  Date:function(coll){
       if(Date.parse(coll[0].innerHTML)>Date.parse(coll[coll.length-1].innerHTML)){
         return -1;
       }else if(Date.parse(coll[0].innerHTML)<Date.parse(coll[coll.length-1].innerHTML)){
       return 1;
       }else{
         return 1;
       }
     }
};


  Array.prototype._sortByInt = function(value){
    //alert(value);
    var temp;//创建临时变量
    var tempArray;
	var arrayThis = this;
	var array = new Array();
	for(var e=0;e<arrayThis.length;e++){
	  array.push(thound(arrayThis[e].innerHTML.substring(1,arrayThis.length)));
	  
	}
for(a=0;a<array.length;a++){
    var tem = array[a];//重置假定最小值
	var t = false;//每次循环开始重置t变量
    for(i=a;i<array.length;i++){//忽略已有最小值，并通过遍历元素取出最小值
	  if(value < 0){
	      tem = Compare.compareIntDsc(array,i,tem);//取最小值
	  }else if(value > 0){
	      tem = Compare.compareIntAsc(array,i,tem);//取最大值
	  }else{
	      return;
	  }
        
	}
	
	/*temp = array[a];//将要换位的对象储存在临时变量中
	for(q=a;q<array.length;q++){
	    if(t!=true){
	    if(tem == array[q]){array[q] = temp; t = true;}//改变T变量阻止相同值数组元素被多次赋值
		}
		
	}*/
	for(var x=a;x<array.length;x++){
	  if(tem == array[x]){
	  //alert(array[x]);
	  var collection = childNode(document.getElementById("ctl00_MainContent_dlAvailableFlight"));
	    temp = collection[a].innerHTML;
	    collection[a].innerHTML = collection[x].innerHTML;
		collection[x].innerHTML = temp;
		tempArray = array[a];
		array[a] = array[x];
		array[x] = tempArray;
	  }
	}
	//arrayThis[a].innerHTML = "$" + tem;//将最小值放在前面

}
}
Array.prototype._sortByDate = function(value){
    var temp;//创建临时变量
    var tempArray;
	var arrayThis = this;
	var array = new Array();
	for(var e=0;e<arrayThis.length;e++){
	  array.push(arrayThis[e].innerHTML);
	  
	}
for(a=0;a<array.length;a++){
    var tem = array[a];//重置假定最小值
	var t = false;//每次循环开始重置t变量
    for(i=a;i<array.length;i++){//忽略已有最小值，并通过遍历元素取出最小值
	  if(value < 0){
	      tem = Compare.compareDateDsc(array,i,tem);//取最小值
	  }else if(value > 0){
	      tem = Compare.compareDateAsc(array,i,tem);//取最大值
	  }else{
	      return;
	  }
        
	}
	
	/*temp = array[a];//将要换位的对象储存在临时变量中
	for(q=a;q<array.length;q++){
	    if(t!=true){
	    if(tem == array[q]){array[q] = temp; t = true;}//改变T变量阻止相同值数组元素被多次赋值
		}
		
	}*/
	for(var x=a;x<array.length;x++){
	  if(tem == array[x]){
	  //alert(array[x]);
	  var collection = childNode($("ctl00_MainContent_dlAvailableFlight"));
	    temp = collection[a].innerHTML;
	    collection[a].innerHTML = collection[x].innerHTML;
		collection[x].innerHTML = temp;
		tempArray = array[a];
		array[a] = array[x];
		array[x] = tempArray;
	  }
	}
	//arrayThis[a].innerHTML = "$" + tem;//将最小值放在前面

}
}
var Compare = {
  compareIntDsc:function(array,i,tem){//比较2值取小，配合程序遍历取出最小
    if(array[i]-tem<0){return array[i];}else{return tem;}
  },
  compareIntAsc:function(array,i,tem){//比较2值取小，配合程序遍历取出最小
    if(array[i]-tem>0){return array[i];}else{return tem;}
  },
  compareDateDsc:function(array,i,tem){//比较2值取小，配合程序遍历取出最小
    if(Date.parse(array[i])-Date.parse(tem)<0){return array[i];}else{return tem;}
  },
  compareDateAsc:function(array,i,tem){//比较2值取小，配合程序遍历取出最小
    if(Date.parse(array[i])-Date.parse(tem)>0){return array[i];}else{return tem;}
  }
}