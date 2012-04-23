// JScript 文件

    function Airfare_Show(){
      $("Airfare").style.display = "block";
    }
    function Airfare_Hide(){
      $("Airfare").style.display = "none";
    }
    function dlFlight_Show(){
    $("ctl00_MainContent_dlFlight").style.display = "block";
    }
    function dlFlight_Hide(){
    $("ctl00_MainContent_dlFlight").style.display = "none";
    }
    
window.onload = function(){
  var dlTrips = document.getElementsByClassName('dlSubTrips');
  for(var i=0;i<dlTrips.length;i++){
    //dlTrips[i].attachEvent?dlTrips[i].attachEvent("onmouseover",Event.bind): dlTrips[i].addEventListener("mouseover",Event.bind,"");
    if(i%2 == 0){
    dlTrips[i].onmouseover = function(){
        this.style.borderTop = "1px solid #FFA500";
        this.style.borderBottom = "1px solid #FFA500";
        this.style.backgroundColor = "#FAFADC";
    } ;
    dlTrips[i].onmouseout = function(){
        this.style.borderTop = "1px solid #fff";
        this.style.borderBottom = "1px solid #fff";
        this.style.backgroundColor = "";
    } ;
    }else{
    dlTrips[i].onmouseover = function(){
        this.style.borderTop = "1px solid #7284E1";
        this.style.borderBottom = "1px solid #7284E1";
        this.style.backgroundColor = "#F0F8FF";
    } ;
    dlTrips[i].onmouseout = function(){
        this.style.borderTop = "1px solid #fff";
        this.style.borderBottom = "1px solid #fff";
        this.style.backgroundColor = "";
    } ;
    }
    
  }
}
///////////////////////////////////////////////////
function toggle_Trip(obj){

    var This = obj;
    var Obj;
    while(obj.parentNode.className != "outside1T"){
       obj = obj.parentNode;
    }
    var table_List = obj.getElementsByTagName("div");
    for(var i=0;i<table_List.length;i++){
      if(table_List[i].title == "TripDetail"){
      if(table_List[i].style.display == "none"){
    
        table_List[i].style.display = "block";
        if(This.innerHTML == "View Details"){
          This.innerHTML = "Hide Details";
        }else{
          This.innerHTML = "隱藏詳細信息";
        }
        
        
          //toggle = false;
          obj.parentNode.style.border = "2px solid #FFA500";
    }else{
        table_List[i].style.display = "none";
        if(This.innerHTML == "Hide Details"){
          This.innerHTML = "View Details";
        }else{
          This.innerHTML = "顯示詳細信息";
        }
        
        
        //toggle = true;
        obj.parentNode.style.border = "2px solid #fff";
    }
      
      break;
      
      }
    }
    
    
}