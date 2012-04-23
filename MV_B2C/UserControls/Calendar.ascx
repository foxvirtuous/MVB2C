<%@ Control Language="C#" AutoEventWireup="true" Inherits="TermsCalendar" Codebehind="Calendar.ascx.cs" %>

<script language='javascript'>
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
 function SetCal(obj,txt)
{
    var cal='calendarDate';
    if(txt.length>0)
    {
        cal = txt+'_'+ cal;
    }
    SC(document.getElementById(cal));
}
</script>

<script src='<%=Path +"CommJS/Mvcal.js"%>' type="text/javascript"></script>

<script src='<%=Path +"CommJS/Mvcal2.js"%>' type="text/javascript"></script>

<%--<iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" runat="server"></iframe>
--%><div runat="server" id="divCalendar">
    <asp:TextBox ID="calendarDate" Width="80" MaxLength="12" Style="margin-top: -1px;
        margin-bottom: -1px;" onpaste="return false" oncontextmenu="return false" onclick="event.cancelBubble=true;SC(this);" onfocus="SC(this);"
        runat="server" onkeydown="if(event.keyCode==13){search('btnSearch')}else{return false;}" ValidationGroup="Default"></asp:TextBox>&nbsp;<a href="#" id="aCal" runat="server"><img src='<%=Path + "images/v2/calendar.gif"%>' align="absmiddle" style="cursor:pointer; margin-bottom:-5px;" border="0"/></a>
    <%--<ajaxToolkit:MaskedEditValidator ID="mevDate" runat="server" ControlExtender="meeDate"#
        ControlToValidate="calendarDate" Display="Dynamic" EmptyValueMessage="Date is required"
        InvalidValueMessage="Date is invalid" TooltipMessage="Input a date MM/dd/yyyy"
        ValidationExpression="" ValidationGroup="Default"></ajaxToolkit:MaskedEditValidator>
    <ajaxToolkit:MaskedEditExtender ID="meeDate" runat="server" AcceptNegative="Left"
        ClearMaskOnLostFocus="false" CultureName="en-US" DisplayMoney="Left" Mask="99/99/9999"
        MaskType="Date" MessageValidatorTip="true" OnFocusCssClass="" OnInvalidCssClass=""
        TargetControlID="calendarDate">
    </ajaxToolkit:MaskedEditExtender>--%>
</div>
