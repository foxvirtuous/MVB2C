<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewInsurancePaymentInformationControl.ascx.cs" Inherits="NewInsurancePaymentInformationControl" %>
<script language="javascript" type="text/javascript">	
    function ChangeCardType()
    {
        var ddlCard = document.getElementById("NewInsurancePaymentInformationControl1_ddlCardType");
        var index = ddlCard.selectedIndex;
        document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber1").value = "";
        document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber2").value = "";
        document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber3").value = "";
        document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber4").value = "";
        if(index == 3)
        {
            document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber4").style.display = "none";
            document.getElementById("NewInsurancePaymentInformationControl1_separator5").style.display = "none";
            var card2 = document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber2");
            card2.onkeydown = function()
            {
                GC_UpdateCharCount(card2,6);
            }
            card2.onkeyup = function()
            {
                GC_UpdateCharCount(card2,6);
            }
            card2.onblur = function()
            {
                isOver(card2,6);
            }
            var card3 = document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber3");
            card3.onkeydown = function()
            {
                GC_UpdateCharCount(card3,5);
            }
            card3.onkeyup = function()
            {
                GC_UpdateCharCount(card3,5);
            }
            card3.onblur = function()
            {
                isOver(card3,5);
            }
        }
        else
        {
            document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber4").style.display = "";
            document.getElementById("NewInsurancePaymentInformationControl1_separator5").style.display = "";
            var card2 = document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber2");
             card2.onkeydown = function()
            {
                GC_UpdateCharCount(card2,4);
            }
            card2.onkeyup = function()
            {
                GC_UpdateCharCount(card2,4);
            }
            card2.onblur = function()
            {
                isOver(card2,4);
            }
            var card3 = document.getElementById("NewInsurancePaymentInformationControl1_txtCardNumber3");
            card3.onkeydown = function()
            {
                GC_UpdateCharCount(card3,4);
            }
            card3.onkeyup = function()
            {
                GC_UpdateCharCount(card3,4);
            }
            card3.onblur = function()
            {
                isOver(card3,4);
            }
        }
    }

    function GC_UpdateCharCount(obj,len) {var obj_length = obj.value.length;
      if(obj_length > len){ 
        obj.value = obj.value.substr(0,len);
      }
    }
    function isOver(sText,len)
    {
    var intlen=sText.value.length;
        if (intlen>len)
        {
            sText.focus();
        }
    }
    
    function showPaymentType()
        {
            if (document.getElementById("NewInsurancePaymentInformationControl1_ddlPaymentType") != null)
            {
                var type = document.getElementById("NewInsurancePaymentInformationControl1_ddlPaymentType").value;
                if (type == "2")
                {
                    document.getElementById("NewInsurancePaymentInformationControl1_lblPassage").style.display = ""
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard1").style.display = "";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard2").style.display = "";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard3").style.display = "";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard4").style.display = "";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard5").style.display = "";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard6").style.display = "";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard7").style.display = "";                    
                }
                else
                {
                    document.getElementById("NewInsurancePaymentInformationControl1_lblPassage").style.display = "none"
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard1").style.display = "none";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard2").style.display = "none";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard3").style.display = "none";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard4").style.display = "none";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard5").style.display = "none";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard6").style.display = "none";
                    document.getElementById("NewInsurancePaymentInformationControl1_trCard7").style.display = "none";                    
                }
            }
            
            document.getElementById("isPost").value = "A";
        }

</script>

<div class="IBE_YellowDIV_Right_travelContact_step4">
    <div class="IBE_YellowDIV_Right_inSide1_travelContact_step4">
        <div class="IBE_YellowDIV_Right_title">
            <span class="right"><font class="Required_t01">*</font> = Required</span>
        </div>
        <table class="IBE_package_step5_TravelInfo_T_step0l" width="100%" align="center"
            border="0" style="margin-bottom: 0px;" cellpadding="0" cellspacing="1">
            <tbody>
                <tr class="IBE_package_step5_TravelInfo_R_stepw">
                    <td>
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr class="IBE_package_step5_TravelInfo_R_step03" align="center">
                                    <td align="left" height="23">
                                        Contact Information</td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="3"
                            cellspacing="1">
                            <tbody>
                                <tr class="IBE_R_stepw" align="left" id="trPaymentType" runat="server">
                                    <td width="25%">
                                        <span class="Required_t01">*</span> Payment Type:</td>
                                    <td colspan="3">
                                        <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="dropDownRes" onchange="showPaymentType()">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblPassage" runat="server" Text="Credit card holder should be one of passengers.(Agency Credit Card -- NOT accept)" style="display:none"
                                            ForeColor="Red"></asp:Label></td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left" id="trCard1" runat="server" style="display: none;">
                                    <td width="25%">
                                        <span class="Required_t01">*</span> Card Type:</td>
                                    <td colspan="2" width="60%">
                                        <asp:DropDownList ID="ddlCardType" runat="server" CssClass="dropDownRes" onchange="ChangeCardType()">
                                        </asp:DropDownList>
                                    </td>
                                    <td rowspan="6" width="60%" align="center">
                                        <img src="../../../images/card_front.gif" hspace="3" vspace="5" border="0" align="absmiddle" /><br>
                                        <img src="../../../images/card_back.gif" hspace="3" vspace="5" border="0" align="absmiddle" />
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left" id="trCard2" runat="server" style="display: none;">
                                    <td>
                                        <span class="Required_t01">*</span> Card Number:</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtCardNumber1" runat="server" Width="50" MaxLength="4"></asp:TextBox>
                                        &nbsp;-&nbsp;<asp:TextBox ID="txtCardNumber2" runat="server" Width="50"></asp:TextBox>
                                        &nbsp;-&nbsp;<asp:TextBox ID="txtCardNumber3" runat="server" Width="50"></asp:TextBox>
                                        <span runat="server" id="separator5">&nbsp;-&nbsp;</span><asp:TextBox ID="txtCardNumber4"
                                            runat="server" Width="50" MaxLength="4"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left" id="trCard3" runat="server" style="display: none;">
                                    <td>
                                        <span class="Required_t01">*</span> Expiration &nbsp;date:</td>
                                    <td colspan="2">
                                        <asp:DropDownList ID="ddlMonth" runat="server" CssClass="dropDownRes">
                                            <asp:ListItem Selected="True">1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlYear" runat="server" CssClass="dropDownRes">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left" id="trCard4" runat="server" style="display: none;">
                                    <td>
                                        <span class="Required_t01">*</span> Card &nbsp;Verification &nbsp;Number:</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtCardIdentification" runat="server" CssClass="dropDownRes"></asp:TextBox></td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left" id="trCard5" runat="server" style="display: none;">
                                    <td valign="top">
                                        <span class="Required_t01">*</span>Credit Card Bank Name (e.g., Chase Bank)</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtCreditCardBankName" runat="server"></asp:TextBox>
                                        <asp:Label ID="lblCreditCardBankNameMsg" runat="server"> (e.g., Chase Bank) </asp:Label>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left" id="trCard6" runat="server" style="display: none;">
                                    <td valign="top">
                                        <span class="Required_t01">*</span>Credit Card 24 Hour Customer Service Phone No:</td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtCreditCardCustomerServicePhoneNumber" runat="server"></asp:TextBox>
                                        <asp:Label ID="Label1" runat="server">(e.g., back of card 1-800-1234567)</asp:Label>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left" id="trCard7" runat="server" style="display: none;">
                                    <td valign="top">
                                        Card Holder:</td>
                                    <td colspan="3">
                                        <span class="Required_t01">*</span> Last Name:<asp:TextBox ID="txtLast" runat="server"></asp:TextBox>
                                        &nbsp;&nbsp;<span class="Required_t01">*</span> First Name:<asp:TextBox ID="txtFirst"
                                            runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td>
                                        Primary Billing Address:
                                    </td>
                                    <td colspan="3">
                                        <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="3"
                                            cellspacing="1">
                                            <tbody>
                                                <tr class="IBE_R_stepw">
                                                    <td>
                                                        <span class="Required_t01">*</span> Last Name:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="IBE_R_stepw">
                                                    <td width="19%">
                                                        <span class="Required_t01">*</span> First Name:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="IBE_R_stepw">
                                                    <td>
                                                        Company Name:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtCompany" runat="server" MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="IBE_R_stepw">
                                                    <td style="height: 30px">
                                                        <span class="Required_t01">*</span> Street:
                                                    </td>
                                                    <td style="height: 30px">
                                                        <asp:TextBox ID="txtStreet" runat="server" MaxLength="200"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="IBE_R_stepw">
                                                    <td>
                                                        <span class="Required_t01">*</span> City:</td>
                                                    <td>
                                                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="IBE_R_stepw">
                                                    <td>
                                                        <span class="Required_t01">*</span> Country &amp; State:</td>
                                                    <td>
                                                        <asp:UpdatePanel runat="server" ID="CountryAndState">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlCountry" runat="server" Width="180px" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                                                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                    ControlToValidate="ddlCountry" Display="Dynamic" ErrorMessage="Please select country."
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>&nbsp;&nbsp;
                                                                <asp:DropDownList ID="ddlState" runat="server">
                                                                </asp:DropDownList></ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr class="IBE_R_stepw">
                                                    <td>
                                                        <span class="Required_t01">*</span> Zip/Postal Code:
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr class="IBE_R_stepw" align="left">
                                    <td colspan="4">
                                        <table width="100%" border="0" cellpadding="0" cellspacing="3">
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <span class="Required_t01" id="Phone" runat="server">*</span> Phone Number Associated
                                                        With This Billing Address: &nbsp;&nbsp; Area-<asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                                                        &nbsp;&nbsp;Phone No.-<asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                                                        &nbsp;&nbsp;Ext-<asp:TextBox ID="txtExt" runat="server"></asp:TextBox>
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
        </table>
    </div>
</div>
