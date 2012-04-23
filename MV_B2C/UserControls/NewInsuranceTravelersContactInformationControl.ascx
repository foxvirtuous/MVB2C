<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewInsuranceTravelersContactInformationControl.ascx.cs"
    Inherits="NewInsuranceTravelersContactInformationControl" %>
<%@ Register Src="NewInsuranceTravelersInformationControl.ascx" TagName="NewInsuranceTravelersInformationControl"
    TagPrefix="uc2" %>
<%@ Register Src="NewInsuranceContactInformationControl.ascx" TagName="NewInsuranceContactInformationControl"
    TagPrefix="uc3" %>
<div class="IBE_YellowDIV_Right_travelContact_step4">
    <div class="IBE_YellowDIV_Right_inSide1_travelContact_step4">
        <div class="IBE_YellowDIV_Right_title">
            <span class="right"><font class="Required_t01">*</font> = Required</span>
        </div>
        <uc2:NewInsuranceTravelersInformationControl ID="NewInsuranceTravelersInformationControl1"
            runat="server" />
        <uc3:NewInsuranceContactInformationControl id="NewInsuranceContactInformationControl1"
            runat="server">
        </uc3:NewInsuranceContactInformationControl>
    </div>
</div>
