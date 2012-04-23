<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SearchConditionsMeassageCForm.aspx.cs"
    Inherits="SearchConditionsMeassageCForm" EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/VehcileTypeViewControl.ascx" TagName="VehcileTypeViewControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/VehcileListViewControl.ascx" TagName="VehcileListViewControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/VehcileInfoControl.ascx" TagName="VehcileInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/VehcileOnlySearchControl.ascx" TagName="VehcileOnlySearchControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

    <script src="../../css/Veil.js" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal.js" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal2.js" type="text/javascript"></script>

    <script src="../../CommJs/interface.js" type="text/javascript"></script>

    <script src="../../CommJs/jquery.js" type="text/javascript"></script>

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

</head>
<body onload="ChangeCarType();SetRepeatCar();">
    <form id="form1" runat="server">
        <input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="" name="DefaultTab" runat="server" /><asp:Button
            Text="" Width="0" runat="server" ID="btnSelect" TabIndex="0" Style="display: none" /><input
                id="FocusIndex" type="hidden" value="" runat="server" />
        <uc1:Header ID="Header1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td align="center">
                    <table width="920" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="15">
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="height: 10px">
                                <uc3:NavigationControl ID="NavigationControl1" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" class="T_table">
                                <tr>
                                    <td width="185" align="left" valign="top">
                                        <uc6:VehcileOnlySearchControl ID="VehcileOnlySearchControl1" runat="server"></uc6:VehcileOnlySearchControl>
                                        <table cellpadding="0" cellspacing="0" width="100%" border="0">
                                            <tr>
                                                <td height="5px">
                                                </td>
                                            </tr>
                                        </table>
                                        <uc9:VehcileTypeViewControl ID="VehcileTypeViewControl1" runat="server"></uc9:VehcileTypeViewControl>
                                    </td>
                                    <td valign="top">
                                        <uc8:VehcileListViewControl ID="VehcileListViewControl1" runat="server" />
                                    </td>
                                </tr>
                                <tr align="left">
                                    <td colspan="2">
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <uc2:Footer ID="Footer1" runat="server" />

        <script language="javascript" type="text/javascript">
        history.go(1);
        </script>

        <div id="upLoad" style="display: none">
            <div id="divDimBackground" style="display: none; z-index: 19; filter: alpha(opacity=70);
                left: 0px; width: 99%; position: absolute; top: 0px; height: 100%; background-color: #F6F6F6;
                opacity: .70; moz-opacity: 0.70">
            </div>
            <div id="inprogressdivBackGround" style="z-index: 200; filter: alpha(opacity=70);
                left: 0px; width: 100%; position: absolute; top: 0px; height: 100%; background-color: #F6F6F6;
                opacity: .70; moz-opacity: 0.70">
            </div>
            <div id="inprogressdiv" style="margin-top: 100px; z-index: 200; left: 60px; width: 99%;
                position: absolute;" align="center">
                <table border="0" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <img src="../../images/v2/updatine_results.gif" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <script language="javascript" type="text/javascript">
             function makeStatic() { try{
            if(bw.ie)
            {
                document.getElementById('divDimBackground').style.top=document.documentElement.scrollTop + 0+"px" ;
                document.getElementById('inprogressdivBackGround').style.top=document.documentElement.scrollTop + 0+"px" ;	
                document.getElementById('inprogressdiv').style.top=document.documentElement.scrollTop + 100+"px" ; 
            }
            else
            {
                var getMaxValueHeight = [document.documentElement.clientHeight, document.documentElement.scrollHeight];  
                getValueHeight = eval("Math.max(" + getMaxValueHeight.toString() + ")");  
                document.getElementById('divDimBackground').style.height = getValueHeight +"px";
                document.getElementById('inprogressdivBackGround').style.height = getValueHeight +"px";
                var getMaxValueTop = [document.documentElement.scrollTop,  document.body.scrollTop];  
                getValueTop = eval("Math.max(" + getMaxValueTop.toString() + ")");  
                document.getElementById('inprogressdiv').style.top=getValueTop + 100+"px" ; 
            }
          
         }catch(err)	{} }
	        window.onscroll=makeStatic;
	        makeStatic();
        </script>

        <script language="javascript" type="text/javascript">

        var prm = Sys.WebForms.PageRequestManager.getInstance();
        
        prm.add_initializeRequest(InitializeRequest);
        prm.add_endRequest(EndRequest);
      
        var postBackElement;
        
        function InitializeRequest(sender, args) 
        {
            if (prm.get_isInAsyncPostBack()) 
            {
                args.set_cancel(true);
            }
            
            postBackElement = args.get_postBackElement();
            
            if   (postBackElement.id.indexOf('VehcileTypeViewControl1_repCarType') != -1)      
            {     
                 document.getElementsByTagName("*").upLoad.style.display = 'block';                
            }
            
            if (postBackElement.id == 'VehcileListViewControl1_ddlSort') 
            {
                 document.getElementsByTagName("*").upLoad.style.display = 'block';
            }  
            
            if (postBackElement.id == 'VehcileTypeViewControl1_lbtnAll') 
            {
                 document.getElementsByTagName("*").upLoad.style.display = 'block';
            }   
            
            if (postBackElement.id == 'VehcileTypeViewControl1_lbtnNone') 
            {
                 document.getElementsByTagName("*").upLoad.style.display = 'block';
            }  
            
            if (postBackElement.id == 'VehcileListViewControl1_lbtnCheckAll') 
            {
                 document.getElementsByTagName("*").upLoad.style.display = 'block';
            }       
        }
        function EndRequest(sender, args) 
        {
            if   (postBackElement.id.indexOf('VehcileTypeViewControl1_repCarType') != -1)      
            {     
                 document.getElementsByTagName("*").upLoad.style.display = 'none';                
            }
            
            if   (postBackElement.id.indexOf('VehcileTypeViewControl1_lbtnAll') != -1)      
            {     
                 document.getElementsByTagName("*").upLoad.style.display = 'none';                
            }
            
            if   (postBackElement.id.indexOf('VehcileTypeViewControl1_lbtnNone') != -1)      
            {     
                 document.getElementsByTagName("*").upLoad.style.display = 'none';                
            }
            
            if (postBackElement.id == 'VehcileListViewControl1_ddlSort') 
            {
                 document.getElementsByTagName("*").upLoad.style.display = 'none';
            }
            
            if (postBackElement.id == 'VehcileListViewControl1_lbtnCheckAll') 
            {
                 document.getElementsByTagName("*").upLoad.style.display = 'none';
            }
        }
        </script>

    </form>
</body>
</html>
