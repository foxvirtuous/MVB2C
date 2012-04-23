<%@ Control Language="C#" AutoEventWireup="true" Inherits="LocationTextBoxControl" Codebehind="LocationTextBoxControl.ascx.cs" %>

<style type="text/css"><%="#" +ClientID + "_CityContainer"%> { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; Z-INDEX: 9050; PADDING-BOTTOM: 0px; MARGIN: 0px; PADDING-TOP: 0px; POSITION: absolute }
	<%="#" +ClientID + "_CityContainer"%> .yui-ac-content { BORDER-RIGHT: #404040 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #404040 1px solid; PADDING-LEFT: 0px; Z-INDEX: 9050; BACKGROUND: #fff; LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; OVERFLOW: hidden; BORDER-LEFT: #404040 1px solid; WIDTH: 50em; PADDING-TOP: 0px; BORDER-BOTTOM: #404040 1px solid; POSITION: absolute; TOP: 0px; TEXT-ALIGN: left }
	<%="#" +ClientID + "_CityContainer"%> .yui-ac-shadow { Z-INDEX: 9049; BACKGROUND: #a0a0a0; LEFT: 0px; MARGIN: 0.3em; POSITION: absolute; TOP: 0px }
	<%="#" +ClientID + "_CityContainer"%> UL { PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; WIDTH: 100%; PADDING-TOP: 0px; TEXT-ALIGN: left }
	<%="#" +ClientID + "_CityContainer"%> LI { PADDING-RIGHT: 5px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; CURSOR: default; PADDING-TOP: 0px; WHITE-SPACE: nowrap }
	<%="#" +ClientID + "_CityContainer"%> LI.yui-ac-highlight { BACKGROUND: #b7ecff }

</style>
<asp:TextBox id="txtCity"  runat="server" onchange="upper(this);" onblur="upper(this);" />
<asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
    ErrorMessage="Required." ValidationGroup="Default"></asp:RequiredFieldValidator><div id="CityContainer" runat="server">
        &nbsp;</div>

<script type="text/javascript">
  function upper(obj){
      if(obj.value.length == 3 && obj.value != ""){
        obj.value = obj.value.toUpperCase();
      }
  }
  
</script>
