<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NewInsuranceTravelerInfoForm.aspx.cs"
    Inherits="NewInsuranceTravelerInfoForm" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register Src="../../UserControls/SendEmailInsuranceControl.ascx" TagName="SendEmailInsuranceControl"
    TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/NewInsuranceTravelersContactInformationControl.ascx"
    TagName="NewInsuranceTravelersContactInformationControl" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/NewInsurancePaymentInformationControl.ascx" TagName="NewInsurancePaymentInformationControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/NewInsuranceOrderSummaryControl.ascx" TagName="NewInsuranceOrderSummaryControl"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Customer Information</title>
    <link href="../../css/style_NewHotel.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_new1.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    function GetFormContent(){
				if(document.getElementById("flagSearch") != null)
				    document.getElementById("flagSearch").value = document.getElementById("MAIL_BODY").innerHTML;
			}
	function OnSearch(obj)
	{
		GetFormContent();
		document.getElementById("IsFinised").value ="yes";
	    document.getElementById("form1").submit();
  	}
  	
  	 function textCounter(field, maxlimit) { 
    if (field.value.length > maxlimit) 
    field.value = field.value.substring(0,maxlimit); 
} 

function copytext(a)
	{
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultFirst")
	    {
	        document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtFirst").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultFirst").value;
	        document.getElementById("NewInsurancePaymentInformationControl1_txtFirstName").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultFirst").value;
	    }
	    
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultLast")
	    {
	        document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtLast").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultLast").value;
	        document.getElementById("NewInsurancePaymentInformationControl1_txtLastName").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultLast").value;
	    }
	
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultMiddle")
	    {
	        document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtMiddle").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultMiddle").value;
	    }
	    
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultCity")
	    {
	        document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtCity").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultCity").value;
	        document.getElementById("NewInsurancePaymentInformationControl1_txtCity").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultCity").value;
	    }
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultStreet")
	    {
	        document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtStreet").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultStreet").value;
	        document.getElementById("NewInsurancePaymentInformationControl1_txtStreet").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultStreet").value;
	    }
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultZip")
	    {
	        document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtZip").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultZip").value;
	        document.getElementById("NewInsurancePaymentInformationControl1_txtZip").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultZip").value;
	    }	    
   
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtCity")
	    {
	        document.getElementById("NewInsurancePaymentInformationControl1_txtCity").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtCity").value;
	    }
	    
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtZip")
	    {
	        document.getElementById("NewInsurancePaymentInformationControl1_txtZip").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtZip").value;
	    }
	    
	    if (a.id == "NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtStreet")
	    {
	        document.getElementById("NewInsurancePaymentInformationControl1_txtStreet").value = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_txtStreet").value;
	    }
	    
	    if (a == 'aa')
	    {
	        var   oSrc=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_ddlAdultCountry'); 
	        var   oDst2=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_ddlCountry');   
                  var   oTmp2=oSrc.cloneNode(true);  
                  oDst2.options.length = 0;
                    for(var i=0;i<oTmp2.length;i++)
                      { 
                      oDst2[i]=new Option(oTmp2[i].text ,oTmp2[i].value); 
                      }
                      
                      for(var   i=0;i<oDst2.length;i++){  
                      if(oDst2.options[i].value==oSrc.value){  
                          oDst2.options[i].selected=true;  
                          break;  
                      }  
                  } 
                  
                  var   oSrc1=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_ddlAdultState');   
                  	var   oDst3=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_ddlState');   
                  var   oTmp3=oSrc1.cloneNode(true);  
                  oDst3.options.length = 0;
                    for(var i=0;i<oTmp3.length;i++)
                      { 
                      oDst3[i]=new Option(oTmp3[i].text ,oTmp3[i].value); 
                      }
                      
                      for(var   i=0;i<oDst3.length;i++){  
                      if(oDst3.options[i].value==oSrc1.value){  
                          oDst3.options[i].selected=true;  
                          break;  
                      }  
                  } 	
	    }
	    
	    if (a == 'aa')
	    {
                  var   oSrc=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_ddlCountry');   
                  var   oDst=document.all('NewInsurancePaymentInformationControl1_ddlCountry');   
                  var   oTmp=oSrc.cloneNode(true);  
                  oDst.options.length = 0;
                    for(var i=0;i<oTmp.length;i++)
                      { 
                      oDst[i]=new Option(oTmp[i].text ,oTmp[i].value); 
                      }
                  
                  for(var   i=0;i<oDst.length;i++){  
                      if(oDst.options[i].value==oSrc.value){  
                          oDst.options[i].selected=true;  
                          break;  
                      }  
                  }
                
                  
	    }
	    
	    if (a == 'aa')
	    {
	              var   oSrc1=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceContactInformationControl1_ddlState');   
                  var   oDst1=document.all('NewInsurancePaymentInformationControl1_ddlState');   
                  var   oTmp1=oSrc1.cloneNode(true);   
                  oDst1.options.length = 0;
                    for(var i=0;i<oTmp1.length;i++)
                      { 
                      oDst1[i]=new Option(oTmp1[i].text ,oTmp1[i].value); 
                      }                  
                  
                  for(var   i=0;i<oDst1.length;i++){  
                      if(oDst1.options[i].value==oSrc1.value){  
                          oDst1.options[i].selected=true;  
                          break;  
                      }  
                  }
	    }
	}
	
	    function aa()
        {
            window.alert("Sign-time expired, Please login again !!!");
            window.location.href = 'http://www.gttglobal.com/';
        }
    
    </script>

    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <input id="lblOldTime" type="hidden" value="60" runat="server" />
        <input id="cityandairport" type="hidden" value="H" runat="server" />
        <input id="mouseindex" type="hidden" value="" name="DefaultTab" runat="server" />
        <input id="FocusIndex" type="hidden" value="" runat="server" />
        <input id="IsFinised" type="hidden" name="IsFinised" runat="server" />
        <input id="isPost" type="hidden" value="" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="IBE_package_main">
            <div style="width: 920px; float: left;">
                <div class="IBE_GrayDIV_Right_travelContact_step4">
                    <uc2:NewInsuranceOrderSummaryControl ID="NewInsuranceOrderSummaryControl1" runat="server" />
                </div>
                <div class="IBE_package_step">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <span class="left">&nbsp;Enter Travelers & Contact Information</span>
                </div>
                <uc3:NewInsuranceTravelersContactInformationControl ID="NewInsuranceTravelersContactInformationControl1"
                    runat="server"></uc3:NewInsuranceTravelersContactInformationControl>
                <div class="IBE_package_step">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <span class="left">&nbsp;Payment Information</span>
                </div>
            </div>
            <uc6:NewInsurancePaymentInformationControl ID="NewInsurancePaymentInformationControl1"
                runat="server"></uc6:NewInsurancePaymentInformationControl>
            <div class="IBE_package_step">
                <div class="IBE_package_step">
                    <div class="IBE_package_step_T_line01 left">
                        &gt;</div>
                    <span class="left">&nbsp;Preferences Information</span>
                </div>
                <div class="IBE_package_remarks_travelContact">
                    <textarea id="txtRemark" style="width: 896px; height: 70px;" class="remark" runat="server"
                        onkeydown="textCounter(this.form.txtRemark,200);" onkeyup="textCounter(this.form.txtRemark,200);"></textarea>
                </div>
                <div class="IBE_DIV" style="text-align: right; margin-top: 6px;">
                    <span class="IBE_t10">Please confirm all of the information is correct, then click</span>
                    &nbsp;
                    <asp:Button ID="btnContinue" Text="Continue" runat="server" CssClass="search_btn02"
                        Style="cursor: pointer" OnClick="btnContinue_Click" />
                    <asp:Button ID="btnBack" Text="Back" runat="server" CssClass="search_btn02" Style="cursor: pointer"
                        ValidationGroup="Back" OnClick="btnBack_Click" /></div>
            </div>
        </div>
        <div id="MAIL_BODY" style="display:none">
            <uc7:SendEmailInsuranceControl id="SendEmailInsuranceControl1" runat="server">
            </uc7:SendEmailInsuranceControl>
        </div>
        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
        <uc2:Footer ID="Footer1" runat="server" />
        <asp:TextBox ID="TextBox1" runat="server" Width="0px" Height="0px" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
