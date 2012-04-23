<%@ Control Language="C#" AutoEventWireup="true" Inherits="TermsTextBox" Codebehind="MustInputTextBox.ascx.cs" %>

<asp:TextBox ID="txtMustInput" runat="server" ValidationGroup="Default" AutoComplete="off" ></asp:TextBox>
<asp:PlaceHolder ID="phValadation" runat="server" Visible="False"><asp:RequiredFieldValidator ID="rfvMustInput" ControlToValidate="txtMustInput" runat="server" Display="None" ErrorMessage="*Reqired" ValidationGroup="Default" ></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="revMustInput" Enabled="False" ControlToValidate="txtMustInput" runat="server" Display="None" ErrorMessage="*Invalid" ValidationGroup="Default" ></asp:RegularExpressionValidator>
<ajaxToolkit:FilteredTextBoxExtender ID="fteMustInput" Enabled="False" FilterType="Numbers" TargetControlID="txtMustInput" runat="server"></ajaxToolkit:FilteredTextBoxExtender></asp:PlaceHolder>
  <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="NReqE"
            TargetControlID="revMustInput"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
            
              <ajaxToolkit:ValidatorCalloutExtender runat="server" ID="NReqF"
            TargetControlID="rfvMustInput"
            HighlightCssClass="validatorCalloutHighlight" Enabled="True" />
&nbsp;
