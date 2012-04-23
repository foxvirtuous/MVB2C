<%@ Control Language="C#" AutoEventWireup="true" Inherits="UserControls_DropDownList" Codebehind="DropDownList.ascx.cs" %>
<asp:DropDownList ID="ddlBase" runat="server" Width="100px">
</asp:DropDownList><ajaxToolkit:ListSearchExtender ID="lseBase" runat="server"
    PromptCssClass="ListSearchExtenderPrompt" TargetControlID="ddlBase">
</ajaxToolkit:ListSearchExtender>
