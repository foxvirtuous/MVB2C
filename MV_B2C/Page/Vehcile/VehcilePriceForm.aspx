<%@ Page Language="C#" AutoEventWireup="true" Codebehind="VehcilePriceForm.aspx.cs"
    Inherits="VehcilePriceForm" ValidateRequest="false" %>

<%@ Register Src="../../UserControls/NewVehcileSendEamilControl.ascx" TagName="NewVehcileSendEamilControl"
    TagPrefix="uc15" %>

<%@ Register Src="../../UserControls/VehcileSendEamilControl.ascx" TagName="VehcileSendEamilControl"
    TagPrefix="uc14" %>
<%@ Register Src="../../UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc13" %>
<%@ Register Src="../../UserControls/VehcileInfoControl.ascx" TagName="VehcileInfoControl"
    TagPrefix="uc12" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc11" %>
<%@ Register Src="../../UserControls/UserLoginControl.ascx" TagName="UserLoginControl"
    TagPrefix="uc10" %>
<%@ Register Src="../../UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Src="../../UserControls/VehcileOnlySearchControl.ascx" TagName="VehcileOnlySearchControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/VehcileInfoALLControl.ascx" TagName="VehcileInfoALLControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/VehcileInfoViewControl.ascx" TagName="VehcileInfoViewControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/VehcilePriceInfoControl.ascx" TagName="VehcilePriceInfoControl"
    TagPrefix="uc9" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises,
        Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new.css"%>" rel="stylesheet"
        type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_new_Car.css"%>" rel="stylesheet"
        type="text/css" />

    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal.js" type="text/javascript"></script>

    <script src="../../CommJs/Mvcal2.js" type="text/javascript"></script>

    <script src="../../css/Veil.js" type="text/javascript"></script>

    <script src="../../CommJs/interface.js" type="text/javascript"></script>

    <script src="../../CommJs/jquery.js" type="text/javascript"></script>

    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>

    <script type="text/javascript">
    
 function checkName()
{
   var check = document.getElementById("cbUse");
   
   if (check.checked)
   {
        document.getElementById("txtContactFirst").value = document.getElementById("txtFrist").value;
        document.getElementById("txtContactMiddle").value = document.getElementById("txtMiddle").value;
        document.getElementById("txtContactLast").value = document.getElementById("txtLast").value;
        
        document.getElementById("txtContactFirst").style.color = document.getElementById("txtFrist").style.color;
        document.getElementById("txtContactMiddle").style.color = document.getElementById("txtMiddle").style.color;
        document.getElementById("txtContactLast").style.color = document.getElementById("txtLast").style.color;
   }
}


  function SetValue(obj)
    {
        var object = document.getElementById(obj);
        if(object != null)
        {
            if(object.value.toLowerCase() == 'last name')
            {
                object.value = '';
                object.style.color = 'black';
            }
            else if(object.value.toLowerCase() == 'first name')
            {
                object.value = '';
                object.style.color = 'black';
            }
            else if(object.value.toLowerCase() == 'middle name')
            {
                object.value = '';
                object.style.color = 'black';
            }
        }
    }
    
    function GetLast(obj)
    {
        var object = document.getElementById(obj);
        if(object != null)
        {
            if(object.value == '' || object.value.toLowerCase() == 'last name')
            {
                object.value = 'Last Name';
                object.style.color = '#C2C4C4';
            }
            document.getElementById('txtContactLast').value = object.value;
            document.getElementById('txtContactLast').style.color = object.style.color;
        }
    }
    
    function GetMiddle(obj)
    {
        var object = document.getElementById(obj);
        if(object != null)
        {
            if(object.value == '' || object.value.toLowerCase() == 'middle name')
            {
                object.value = 'Middle Name';
                object.style.color = '#C2C4C4';
            }            
            document.getElementById('txtContactMiddle').value = object.value;
            document.getElementById('txtContactMiddle').style.color = object.style.color;
        }
    }
    
    function GetFirst(obj)
    {
        var object = document.getElementById(obj);
        if(object != null)
        {
            if(object.value == '' || object.value.toLowerCase() == 'first name')
            {
                object.value = 'First Name';
                object.style.color = '#C2C4C4';
            }
            document.getElementById('txtContactFirst').value = object.value;
            document.getElementById('txtContactFirst').style.color = object.style.color;
        }
    }

function GetFormContent()
    {
		if(document.getElementById("flagSearch") != null)
		    document.getElementById("flagSearch").value = document.getElementById("MAIL_BODY").innerHTML;
	}
				
	function OnSearch()
	{
		GetFormContent();
		document.getElementById("IsFinised").value ="yes";
	    document.getElementById("form1").submit();
	}

     window.onload = function loadinit() 
        {
            var txtFrist = document.getElementById('txtFrist');             
        
        if(txtFrist.value == '' || txtFrist.value.toLowerCase() == 'first name')
        {
            txtFrist.style.color = '#C2C4C4';            
        }
        else
        {
            txtFrist.style.color = 'black';
        }        
        var txtMiddle = document.getElementById('txtMiddle');                
        if(txtMiddle.value == '' || txtMiddle.value.toLowerCase() == 'middle name')
        {
            txtMiddle.style.color = '#C2C4C4';            
        }
        else
        {
           txtMiddle.style.color = 'black';
        }        
        var txtLast = document.getElementById('txtLast');
                
        if(txtLast.value == '' || txtLast.value.toLowerCase() == 'last name')
        {
            txtLast.style.color = '#C2C4C4';            
        }
        else
        {
            txtLast.style.color = 'black';
        }        
        var txtContactLast = document.getElementById('txtContactLast');                
        if(txtContactLast.value == '' || txtContactLast.value.toLowerCase() == 'last name')
        {
            txtContactLast.style.color = '#C2C4C4';            
        }
        else
        {
            txtContactLast.style.color = 'black';
        }        
        var txtContactMiddle = document.getElementById('txtContactMiddle');                
        if(txtContactMiddle.value == '' || txtContactMiddle.value.toLowerCase() == 'middle name')
        {
            txtContactMiddle.style.color = '#C2C4C4';            
        }
        else
        {
            txtContactMiddle.style.color = 'black';
        }        
        var txtContactFirst = document.getElementById('txtContactFirst');
                
        if(txtContactFirst.value == '' || txtContactFirst.value.toLowerCase() == 'first name')
        {
            txtContactFirst.style.color = '#C2C4C4';            
        }
        else
        {
            txtContactFirst.style.color = 'black';
        }
        }
        window.onunload = function EndRequest() 
        {
            var txtFrist = document.getElementById('txtFrist');                
        if(txtFrist.value == '' || txtFrist.value.toLowerCase() == 'first name')
        {
            txtFrist.style.color = '#C2C4C4';            
        }
        else
        {
            txtFrist.style.color = 'black';
        }        
        var txtMiddle = document.getElementById('txtMiddle');                
        if(txtMiddle.value == '' || txtMiddle.value.toLowerCase() == 'middle name')
        {
            txtMiddle.style.color = '#C2C4C4';            
        }
        else
        {
           txtMiddle.style.color = 'black';
        }        
        var txtLast = document.getElementById('txtLast');
                
        if(txtLast.value == '' || txtLast.value.toLowerCase() == 'last name')
        {
            txtLast.style.color = '#C2C4C4';            
        }
        else
        {
            txtLast.style.color = 'black';
        }        
        var txtContactLast = document.getElementById('txtContactLast');                
        if(txtContactLast.value == '' || txtContactLast.value.toLowerCase() == 'last name')
        {
            txtContactLast.style.color = '#C2C4C4';            
        }
        else
        {
            txtContactLast.style.color = 'black';
        }        
        var txtContactMiddle = document.getElementById('txtContactMiddle');                
        if(txtContactMiddle.value == '' || txtContactMiddle.value.toLowerCase() == 'middle name')
        {
            txtContactMiddle.style.color = '#C2C4C4';            
        }
        else
        {
            txtContactMiddle.style.color = 'black';
        }        
        var txtContactFirst = document.getElementById('txtContactFirst');
                
        if(txtContactFirst.value == '' || txtContactFirst.value.toLowerCase() == 'first name')
        {
            txtContactFirst.style.color = '#C2C4C4';            
        }
        else
        {
            txtContactFirst.style.color = 'black';
        }
        }   
        </script>

    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" >
        <input id="IsFinised" type="hidden" name="IsFinised" runat="server" />
        <input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="" name="DefaultTab" runat="server" /><input
            id="FocusIndex" type="hidden" value="" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
        <div>
            <table width="920" align="center" border="0" cellpadding="0" cellspacing="0">
                <tbody>
                    <tr>
                        <td align="center">
                            <table class="step" width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td align="right" height="10">
                                            <uc11:NavigationControl ID="NavigationControl1" runat="server" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr class="R_stepw">
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                <tbody>
                                                                    <tr align="center">
                                                                        <td align="left" class="D_step">
                                                                            <span id="OrderPassengerInfoControl1_dlAdult_ctl00_lblAdultTraveler">Car Details</span></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table width="100%" border="0" cellpadding="8" cellspacing="1">
                                                                <tbody>
                                                                    <tr class="R_stepw" align="left">
                                                                        <td>
                                                                            <uc12:VehcileInfoControl ID="VehcileInfoControl1" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr class="R_stepw">
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                <tbody>
                                                                    <tr align="center">
                                                                        <td align="left" class="D_step">
                                                                            <span id="Span1">Rate Details</span></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <uc9:VehcilePriceInfoControl ID="VehcilePriceInfoControl1" runat="server" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr class="R_stepw">
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                <tbody>
                                                                    <tr align="center">
                                                                        <td align="left" class="D_step">
                                                                            <span id="Span2">Driver Details</span></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                            <tbody>
                                                                                <tr align="left">
                                                                                    <td valign="top" style="padding: 8px 8px 8px 8px; border-bottom: solid #cccccc 1px;">
                                                                                        <b>Enter driver details below:</b></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                            <tbody>
                                                                                <tr align="left">
                                                                                    <td align="center" valign="top" bgcolor="#F5F5F5" style="padding: 5px 8px 5px 8px;">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr align="left">
                                                                                                <td width="12%">
                                                                                                    Title:</td>
                                                                                                <td width="20%">
                                                                                                    First Name: <font class="t01">*</font></td>
                                                                                                <td width="20%">
                                                                                                    Middle Name:</td>
                                                                                                <td width="34%">
                                                                                                    Last Name: <font class="t01">*</font></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                            <tbody>
                                                                                <tr align="left">
                                                                                    <td align="center" valign="top" bgcolor="#F5F5F5" style="padding: 5px 8px 5px 8px;">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr align="left">
                                                                                                <td width="12%">
                                                                                                    <asp:DropDownList ID="ddlSex" runat="server" CssClass="searchnew_select">
                                                                                                        <asp:ListItem Value="99" Selected="True">--</asp:ListItem>
                                                                                                        <asp:ListItem Value="0">Mr.</asp:ListItem>
                                                                                                        <asp:ListItem Value="2">Mrs.</asp:ListItem>
                                                                                                        <asp:ListItem Value="4">Miss</asp:ListItem>
                                                                                                        <asp:ListItem Value="1">Ms.</asp:ListItem>
                                                                                                        <asp:ListItem Value="3">Dr.</asp:ListItem>
                                                                                                        <asp:ListItem Value="5">Re.</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                                <td width="20%">
                                                                                                    <asp:TextBox ID="txtFrist" runat="server" Width="100" CssClass="booking_inp" MaxLength="20"
                                                                                                        Text="First Name" AutoComplete="Off" ValidationGroup="TravelForm" onfocus="SetValue('txtFrist')"
                                                                                                        onblur="GetFirst('txtFrist')"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic"
                                                                                                        ControlToValidate="txtFrist" InitialValue="First Name" ErrorMessage="Reqired"
                                                                                                        SetFocusOnError="true" ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                                <td width="20%">
                                                                                                    <asp:TextBox ID="txtMiddle" runat="server" Text="Middle Name" AutoComplete="Off"
                                                                                                        Width="100" CssClass="booking_inp" MaxLength="20" onfocus="SetValue('txtMiddle')"
                                                                                                        onblur="GetMiddle('txtMiddle')"></asp:TextBox>
                                                                                                </td>
                                                                                                <td width="34%">
                                                                                                    <asp:TextBox ID="txtLast" Width="100" runat="server" Text="Last Name" CssClass="booking_inp"
                                                                                                        AutoComplete="Off" MaxLength="20" ValidationGroup="TravelForm" onfocus="SetValue('txtLast')"
                                                                                                        onblur="GetLast('txtLast')"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLast"
                                                                                                        Display="Dynamic" ErrorMessage="Reqired" SetFocusOnError="true" InitialValue="Last Name"
                                                                                                        ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr class="R_stepw">
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                <tbody>
                                                                    <tr align="center">
                                                                        <td align="left" class="D_step">
                                                                            Contact Information</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                            <tbody>
                                                                                <tr align="left">
                                                                                    <td align="center" valign="top" style="padding: 15px 8px 15px 8px;">
                                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <%--<tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            &nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <input type="checkbox" name="checkbox" value="checkbox" id="cbUse" onclick="checkName()" />
                                                                                                            Use driver info</td>
                                                                                                    </tr>--%>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            First Name: <font class="t01">*</font></td>
                                                                                                        <td width="25%">
                                                                                                            <asp:TextBox ID="txtContactFirst" runat="server" Width="100" CssClass="booking_inp"
                                                                                                                Text="First Name" AutoComplete="Off" ValidationGroup="TravelForm" onfocus="SetValue('txtContactFirst')"
                                                                                                                onblur="GetFirst('txtContactFirst')" MaxLength=20></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="rfvFirst" runat="server" Display="Dynamic" ControlToValidate="txtContactFirst"
                                                                                                                InitialValue="First Name" ErrorMessage="Reqired" SetFocusOnError="true" ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                        <td width="25%" align="right">
                                                                                                            Middle Name:&nbsp;&nbsp;</td>
                                                                                                        <td width="25%">
                                                                                                            <asp:TextBox ID="txtContactMiddle" runat="server" Text="Middle Name" AutoComplete="Off"
                                                                                                                Width="100" CssClass="booking_inp" onfocus="SetValue('txtContactMiddle')" MaxLength=20 onblur="GetMiddle('txtContactMiddle')"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Last Name: <font class="t01">*</font></td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtContactLast" Width="100" runat="server" Text="Last Name" CssClass="booking_inp"
                                                                                                                AutoComplete="Off" ValidationGroup="TravelForm" onfocus="SetValue('txtContactLast')"
                                                                                                                onblur="GetLast('txtContactLast')" MaxLength=20></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="rfvLast" runat="server" ControlToValidate="txtContactLast"
                                                                                                                Display="Dynamic" ErrorMessage="Reqired" SetFocusOnError="true" InitialValue="Last Name"
                                                                                                                ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td width="25%" align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Address 1: <font class="t01">*</font></td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtAddress1" runat="server" CssClass="booking_inp" ValidationGroup="TravelForm"
                                                                                                                Width="200px" MaxLength="200"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                                                                ControlToValidate="txtAddress1" ErrorMessage="Reqired" InitialValue="" SetFocusOnError="true"
                                                                                                                ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                            (example: 123 Main Street)</td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Address 2: &nbsp;&nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtAddress2" runat="server" CssClass="booking_inp" Width="200px"
                                                                                                                MaxLength="200"></asp:TextBox>
                                                                                                            (example: Apt 12 B, Room 101 or Suit 34A)</td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            City: <font class="t01">*</font>&nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtCity" runat="server" CssClass="booking_inp" ValidationGroup="TravelForm"
                                                                                                                MaxLength="50"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Display="Dynamic"
                                                                                                                ControlToValidate="txtCity" ErrorMessage="Reqired" InitialValue="" SetFocusOnError="true"
                                                                                                                ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                            (example: New York)</td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            State: <font class="t01">*</font>&nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="searchnew_select">
                                                                                                            </asp:DropDownList>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" Display="Dynamic"
                                                                                                                ControlToValidate="ddlState" InitialValue="Select" ErrorMessage="Reqired" SetFocusOnError="true"
                                                                                                                ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Zip: <font class="t01">*</font>&nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtZip" runat="server" CssClass="booking_inp" ValidationGroup="TravelForm"
                                                                                                                MaxLength="20"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Display="Dynamic"
                                                                                                                ControlToValidate="txtZip" ErrorMessage="Reqired" InitialValue="" SetFocusOnError="true"
                                                                                                                ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Country: <font class="t01">*</font>&nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:DropDownList ID="ddlCountry" runat="server" CssClass="searchnew_select" AutoPostBack="True"
                                                                                                                OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                                                            </asp:DropDownList></td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td width="25%" align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Contact Phone: <font class="t01">*</font></td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtPhone" runat="server" CssClass="booking_inp" ValidationGroup="TravelForm"
                                                                                                                MaxLength="30" Width="200"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Display="Dynamic"
                                                                                                                ControlToValidate="txtPhone" ErrorMessage="Reqired" InitialValue="" SetFocusOnError="true"
                                                                                                                ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                            &nbsp;&nbsp;ext:<uc13:MustInputTextBox ID="txtExt" runat="server" MaxLength="30"
                                                                                                                ValidationGroup="TravelForm" Width="50" CssClass="booking_inp" IsValidEmpty="true" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            &nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            (Please Provide phone number where you may be reached between 9AM - 9PM)</td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Email: <font class="t01">*</font>&nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtEmail" runat="server" CssClass="booking_inp" Width="200" AutoComplete="Off"
                                                                                                                ValidationGroup="TravelForm" MaxLength=50></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                                                                                                                Display="Dynamic" ErrorMessage="Reqired" SetFocusOnError="true" ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                            <asp:RegularExpressionValidator ID="revEmail" runat="server" ErrorMessage="Invaid Email"
                                                                                                                ValidationGroup="TravelForm" ControlToValidate="txtEmail" SetFocusOnError="true"
                                                                                                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr align="left">
                                                                                                        <td align="right" style="padding: 6px 6px 6px 0px;">
                                                                                                            Retype Email: <font class="t01">*</font>&nbsp;</td>
                                                                                                        <td colspan="3">
                                                                                                            <asp:TextBox ID="txtRetypeEmail" runat="server" CssClass="booking_inp" Width="200"
                                                                                                                AutoComplete="Off" ValidationGroup="TravelForm"></asp:TextBox>
                                                                                                            <asp:RequiredFieldValidator ID="rfvConfirmEmail" runat="server" ControlToValidate="txtRetypeEmail"
                                                                                                                Display="Dynamic" ErrorMessage="Reqired" SetFocusOnError="true" ValidationGroup="TravelForm"></asp:RequiredFieldValidator>
                                                                                                            <asp:RegularExpressionValidator ID="revRetypeEmail" runat="server" Display="Dynamic"
                                                                                                                SetFocusOnError="true" ErrorMessage="Invaid Email" ValidationGroup="TravelForm"
                                                                                                                ControlToValidate="txtRetypeEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                                            <asp:CompareValidator ID="cvEmail" SetFocusOnError="true" ControlToValidate="txtRetypeEmail"
                                                                                                                ControlToCompare="txtEmail" Display="Dynamic" runat="server" ErrorMessage="Email inconsistent"
                                                                                                                ValidationGroup="TravelForm"></asp:CompareValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table class="T_step0l" width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr class="R_stepw">
                                                        <td>
                                                            <table width="100%" border="0" cellpadding="2" cellspacing="0">
                                                                <tbody>
                                                                    <tr align="center">
                                                                        <td align="left" class="D_step">
                                                                            Policies, Rules & Restrictions</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                            <tbody>
                                                                                <tr align="left">
                                                                                    <td align="left" valign="top" bgcolor="#FFF8CB" style="padding: 15px 8px 15px 8px;">
                                                                                        <asp:CheckBox ID="cbIsAgree" runat="server" />&nbsp;I agree to the <a href="#" class="d13">
                                                                                            Terms and Conditions</a> of purchase.
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody>
                                    <tr>
                                        <td height="15">
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table width="100%" align="center" border="0" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btnBooking" runat="server" Text="Book Now" CssClass="search_btn02"
                                                Style="cursor: pointer" ValidationGroup="TravelForm" OnClick="btnBooking_Click" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                    ID="btnBack" runat="server" Style="cursor: pointer" Text="Back" CssClass="search_btn02"
                                                    OnClick="btnBack_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="MAIL_BODY" visible="false" style="display: none">
            <%--<uc14:VehcileSendEamilControl ID="VehcileSendEamilControl1" runat="server"></uc14:VehcileSendEamilControl>--%>
            <uc15:NewVehcileSendEamilControl id="NewVehcileSendEamilControl1" runat="server"></uc15:NewVehcileSendEamilControl>
        </div>
        <asp:HiddenField ID="flagSearch" Value="" runat="server" />
        <asp:TextBox ID="TextBox1" runat="server" Width="0px" Height="0px" Style="display: none"></asp:TextBox>
        <uc2:Footer ID="Footer1" runat="server" />

        <script language="javascript" type="text/javascript">
        history.go(1);
        </script>        
    </form>
</body>
</html>
