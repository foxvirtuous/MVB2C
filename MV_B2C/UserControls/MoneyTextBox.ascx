<%@ Control Language="C#" AutoEventWireup="true" Inherits="MoneyTextBox" Codebehind="MoneyTextBox.ascx.cs" %>

<asp:TextBox ID="txtInput" MaxLength="18" runat="server" ValidationGroup="Default" ></asp:TextBox>
<asp:Label ID="lblMoney" Text="eg: 50" CssClass="L_menu3" runat="server"></asp:Label>&nbsp;<asp:RequiredFieldValidator
    ID="rfvMustInput" runat="server" ControlToValidate="txtInput" ErrorMessage="*"
    ValidationGroup="Default"></asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator ID="revMustInput" Enabled="true" ValidationExpression="^\d{1,18}" Display="None" ControlToValidate="txtInput" runat="server" ErrorMessage="*Invalid" ValidationGroup="Default" ></asp:RegularExpressionValidator>
    <ajaxToolkit:FilteredTextBoxExtender ID="fteMustInput" Enabled="true" TargetControlID="txtInput"
    ValidChars="."
    FilterType="Custom,Numbers" runat="server"></ajaxToolkit:FilteredTextBoxExtender>
 
    <ajaxToolkit:ValidatorCalloutExtender runat="Server" ID="NReqE"
            TargetControlID="revMustInput"
            HighlightCssClass="validatorCalloutHighlight" />
