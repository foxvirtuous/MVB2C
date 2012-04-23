<%@ Control Language="C#" AutoEventWireup="true" Inherits="CreditCardInformationControl"
    Codebehind="CreditCardInformationControl.ascx.cs" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<style>
.table_border td{ border:1px solid #ccc; border-left:none; border-bottom:none;}

</style>

<script language="javascript" type="text/javascript">
        function showPaymentType()
        {
            if (document.getElementById("CreditCardInformation1_ddlPaymentType") != null)
            {
                var type = document.getElementById("CreditCardInformation1_ddlPaymentType").value;
                if (type == "2")
                {
                    document.getElementById("CreditCardInformation1_lblPassage").style.display = ""
                    document.getElementById("CreditCardInformation1_trCard1").style.display = "";
                    document.getElementById("CreditCardInformation1_trCard2").style.display = "";
                    document.getElementById("CreditCardInformation1_trCard3").style.display = "";
                    document.getElementById("CreditCardInformation1_trCard4").style.display = "";
                    document.getElementById("CreditCardInformation1_trCard5").style.display = "";
                    document.getElementById("CreditCardInformation1_trCard6").style.display = "";
                    document.getElementById("CreditCardInformation1_trCard7").style.display = "";
                    
                    document.getElementById("CreditCardInformation1_lblRequired1").style.display = "";
                    document.getElementById("CreditCardInformation1_lblRequired2").style.display = "";
                    document.getElementById("CreditCardInformation1_lblRequired3").style.display = "";
                    document.getElementById("CreditCardInformation1_lblRequired4").style.display = "";
                    document.getElementById("CreditCardInformation1_lblRequired5").style.display = "";
                    
                    document.getElementById("CreditCardInformation1_txtPayerFirst_txtMustInput").value = "";
                    document.getElementById("CreditCardInformation1_txtPayerLast_txtMustInput").value = "";
                    
                    document.getElementById("CreditCardInformation1_txtCompany_txtMustInput").value = "";
                    document.getElementById("CreditCardInformation1_txtStreet_txtMustInput").value = "";
                    
                    document.getElementById("CreditCardInformation1_txtZip_txtMustInput").value = "";
                    document.getElementById("CreditCardInformation1_txtCity_txtMustInput").value = "";
                    
                    document.getElementById("CreditCardInformation1_txtTel_txtMustInput").value = "";
                    document.getElementById("CreditCardInformation1_txtExt_txtMustInput").value = "";
                }
                else
                {
                    document.getElementById("CreditCardInformation1_lblPassage").style.display = "none"
                    document.getElementById("CreditCardInformation1_trCard1").style.display = "none";
                    document.getElementById("CreditCardInformation1_trCard2").style.display = "none";
                    document.getElementById("CreditCardInformation1_trCard3").style.display = "none";
                    document.getElementById("CreditCardInformation1_trCard4").style.display = "none";
                    document.getElementById("CreditCardInformation1_trCard5").style.display = "none";
                    document.getElementById("CreditCardInformation1_trCard6").style.display = "none";
                    document.getElementById("CreditCardInformation1_trCard7").style.display = "none";
                    
                    document.getElementById("CreditCardInformation1_lblRequired1").style.display = "none";
                    document.getElementById("CreditCardInformation1_lblRequired2").style.display = "none";
                    document.getElementById("CreditCardInformation1_lblRequired3").style.display = "none";
                    document.getElementById("CreditCardInformation1_lblRequired4").style.display = "none";
                    document.getElementById("CreditCardInformation1_lblRequired5").style.display = "none";
                    
                }
            }
        }
</script>

<table width="100%" border="0" cellpadding="8" cellspacing="1" class="T_step02">
    <tr class="R_stepo">
        <td valign="top">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td height="7">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="1" cellpadding="8" class="T_step03">
                            <tr class="R_stepw">
                                <td>
                                    <table class="T_step03 table_border" align="center" border="0" cellpadding="3" cellspacing="0"
                                        width="100%">
                                        <tr class="R_stepw" align="left" id="trPaymentType" runat="server" visible="false">
                                            <td width="25%" style="border-left: 1px solid #ccc;">
                                                <span class="t01">*</span>
                                                <asp:Label ID="Label2" runat="Server" meta:resourcekey="lblPaymentType">Payment Type</asp:Label>:</td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="ddlPaymentType" runat="server" CssClass="dropDownRes" onchange="showPaymentType()">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblPassage" runat="server" Text="Credit card holder should be one of passengers.(Agency Credit Card -- NOT accept)"
                                                    ForeColor="Red"></asp:Label></td>
                                        </tr>
                                        <tr class="R_stepw" align="left" id="trCard1" runat="server" style="display: block;">
                                            <td rowspan="1" width="25%" style="border-left: 1px solid #ccc;">
                                                <span class="t01">*</span>
                                                <asp:Label ID="lblCardType" runat="Server" meta:resourcekey="lblCardType">Card Type</asp:Label>:</td>
                                            <td width="60%">
                                                <asp:DropDownList ID="ddlCardType" runat="server" CssClass="dropDownRes">
                                                </asp:DropDownList>
                                            </td>
                                            <td width="15%" rowspan="6" align="center">
                                                <img src="<%=SecureUrlSuffix + "images/v2/card_front.gif"%>" hspace="3" vspace="5"
                                                    border="0" align="absmiddle" /><br>
                                                <img src="<%=SecureUrlSuffix + "images/v2/card_back.gif"%>" hspace="3" vspace="5"
                                                    border="0" align="absmiddle" /></td>
                                        </tr>
                                        <tr class="R_stepw" align="left" id="trCard2" runat="server" style="display: block;">
                                            <td style="border-left: 1px solid #ccc;">
                                                <span class="t01">*</span>
                                                <asp:Label ID="lblCardNumber" runat="Server" meta:resourcekey="lblCardNumber">Card Number</asp:Label>:</td>
                                            <td>
                                                <uc1:MustInputTextBox ID="txtCardNumber1" runat="server" Width="50" IsNumberStyle="true"
                                                    MaxLength="4" CssClass="dropDownRes" AutoComplete="off" />
                                                -&nbsp;<uc1:MustInputTextBox ID="txtCardNumber2" runat="server" Width="50" IsNumberStyle="true"
                                                    MaxLength="4" CssClass="dropDownRes" AutoComplete="off" />
                                                -&nbsp;<uc1:MustInputTextBox ID="txtCardNumber3" runat="server" Width="50" IsNumberStyle="true"
                                                    MaxLength="4" CssClass="dropDownRes" AutoComplete="off" />
                                                -
                                                <uc1:MustInputTextBox ID="txtCardNumber4" runat="server" Width="50" IsNumberStyle="true"
                                                    MaxLength="4" CssClass="dropDownRes" AutoComplete="off" />
                                            </td>
                                        </tr>
                                        <tr class="R_stepw" align="left" id="trCard3" runat="server" style="display: block;">
                                            <td style="border-left: 1px solid #ccc;">
                                                <span class="t01">*</span>
                                                <asp:Label ID="lblExpirationdate" runat="Server" meta:resourcekey="lblExpirationdate">Expiration date</asp:Label>:&nbsp;</td>
                                            <td>
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
                                        <tr class="R_stepw" align="left" id="trCard4" runat="server" style="display: block;">
                                            <td style="border-left: 1px solid #ccc;">
                                                <span class="t01">*</span>
                                                <asp:Label ID="lblCardVerificationNumber" runat="Server" meta:resourcekey="lblCardVerificationNumber">Card Verification Number</asp:Label>:</td>
                                            <td>
                                                <uc1:MustInputTextBox ID="txtCardIdentification" runat="server" CssClass="dropDownRes" />
                                            </td>
                                        </tr>
                                        <tr class="R_stepw" align="left" id="trCard5" runat="server" style="display: block;">
                                            <td style="border-left: 1px solid #ccc;">
                                                <span class="t01">*</span><asp:Label ID="lblCreditCardBankName" runat="server" meta:resourcekey="lblCreditCardBankName">Credit Card Bank Name (e.g., Chase Bank) </asp:Label>:</td>
                                            <td>
                                                <uc1:MustInputTextBox ID="txtCreditCardBankName" runat="server" CssClass="dropDownRes" />
                                                <asp:Label ID="lblCreditCardBankNameMsg" runat="server" meta:resourcekey="lblCreditCardBankNameMsg"> (e.g., Chase Bank) </asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="R_stepw" align="left" id="trCard6" runat="server" style="display: block;">
                                            <td style="border-left: 1px solid #ccc;">
                                                <span class="t01">*</span><asp:Label ID="lblCreditCardCustomerServicePhoneNumber"
                                                    runat="server" meta:resourcekey="lblCreditCardCustomerServicePhoneNumber">Credit Card 24 Hour Customer Service Phone No</asp:Label></td>
                                            <td>
                                                <uc1:MustInputTextBox ID="txtCreditCardCustomerServicePhoneNumber" runat="server"
                                                    CssClass="dropDownRes" />
                                                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCreditCardCustomerServicePhoneNumberMsg">(e.g., back of card 1-800-1234567)</asp:Label>
                                            </td>
                                        </tr>
                                        <tr class="R_stepw" align="left" id="trCard7" runat="server" style="display: block;">
                                            <td valign="top" style="border-left: 1px solid #ccc;">
                                                <asp:Label ID="lblCardHolder" runat="Server" meta:resourcekey="lblCardHolder">Card Holder</asp:Label>:</td>
                                            <td colspan="2">
                                                <span class="t01">*</span>
                                                <asp:Label ID="lblLastName" runat="Server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                                                <uc1:MustInputTextBox ID="txtLast" runat="server" CssClass="dropDownRes" />
                                                &nbsp;&nbsp;<span class="t01">*</span>
                                                <asp:Label ID="lblFirstName" runat="Server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                                                <uc1:MustInputTextBox ID="txtFirst" runat="server" CssClass="dropDownRes" />
                                            </td>
                                        </tr>
                                        <tr class="R_stepw" align="left">
                                            <td width="25%" style="border-left: 1px solid #ccc;">
                                                <asp:Label ID="lblPrimaryBillingAddress" runat="Server" meta:resourcekey="lblPrimaryBillingAddress">Primary Billing Address</asp:Label>:
                                            </td>
                                            <td colspan="2">
                                                <table class="T_step03" align="center" border="0" cellpadding="3" cellspacing="0"
                                                    width="100%">
                                                    <tr class="R_stepw">
                                                        <td style="border-left: 1px solid #ccc;">
                                                            <span class="t01">*</span>
                                                            <asp:Label ID="Label4" runat="Server" meta:resourcekey="lblLastName">Last Name</asp:Label>:</td>
                                                        <td>
                                                            <uc1:MustInputTextBox ID="txtPayerLast" runat="server" Width="300px" CssClass="dropDownRes" />
                                                        </td>
                                                    </tr>
                                                    <tr class="R_stepw">
                                                        <td style="border-left: 1px solid #ccc;">
                                                            <span class="t01">*</span>
                                                            <asp:Label ID="Label3" runat="Server" meta:resourcekey="lblFirstName">First Name</asp:Label>:</td>
                                                        <td>
                                                            <uc1:MustInputTextBox ID="txtPayerFirst" runat="server" Width="300px" CssClass="dropDownRes" />
                                                        </td>
                                                    </tr>
                                                    <tr class="R_stepw">
                                                        <td style="border-left: 1px solid #ccc;">
                                                            <asp:Label ID="lblCompanyName" runat="Server" meta:resourcekey="lblCompanyName">Company Name</asp:Label>:</td>
                                                        <td>
                                                            <uc1:MustInputTextBox ID="txtCompany" runat="server" IsValidEmpty="true" Width="300px"
                                                                CssClass="dropDownRes" />
                                                        </td>
                                                    </tr>
                                                    <tr class="R_stepw">
                                                        <td style="border-left: 1px solid #ccc;">
                                                            <asp:Label ID="lblRequired1" runat="server" Style="display: block;"><span class="Required_t01">*</span></asp:Label>
                                                            <asp:Label ID="lblStreet" runat="Server" meta:resourcekey="lblStreet">Street</asp:Label>:
                                                        </td>
                                                        <td>
                                                            <uc1:MustInputTextBox ID="txtStreet" runat="server" Width="300px" CssClass="dropDownRes" />
                                                        </td>
                                                    </tr>
                                                    <tr class="R_stepw">
                                                        <td style="border-left: 1px solid #ccc;">
                                                            <asp:Label ID="lblRequired2" runat="server" Style="display: block;"><span class="Required_t01">*</span></asp:Label>
                                                            <asp:Label ID="lblCity" runat="Server" meta:resourcekey="lblCity">City</asp:Label>:</td>
                                                        <td>
                                                            <uc1:MustInputTextBox ID="txtCity" runat="server" CssClass="dropDownRes" />
                                                        </td>
                                                    </tr>
                                                    <tr class="R_stepw">
                                                        <td style="border-left: 1px solid #ccc;">
                                                            <asp:Label ID="lblRequired3" runat="server" Style="display: block;"><span class="Required_t01">*</span></asp:Label>
                                                            <asp:Label ID="lblCountryState" runat="Server" meta:resourcekey="lblCountryState">Country or Area</asp:Label>:</td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlCountry" runat="server" Width="180px" AutoPostBack="True"
                                                                OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" CssClass="dropDownRes">
                                                            </asp:DropDownList>&nbsp;
                                                            <asp:DropDownList ID="ddlState" runat="server" CssClass="dropDownRes">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr class="R_stepw">
                                                        <td style="border-left: 1px solid #ccc; border-bottom: 1px solid #ccc;">
                                                            <asp:Label ID="lblRequired4" runat="server" Style="display: block;"><span class="Required_t01">*</span></asp:Label>
                                                            <asp:Label ID="lblZipCode" runat="Server" meta:resourcekey="lblZipCode">Zip/Postal Code</asp:Label>:
                                                        </td>
                                                        <td style="border-bottom: 1px solid #ccc;">
                                                            <uc1:MustInputTextBox ID="txtZip" runat="server" CssClass="dropDownRes" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr class="R_stepw" align="left">
                                            <td colspan="3" width="100%" style="border-left: 1px solid #ccc; border-bottom: 1px solid #ccc;">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td style="border: none;">
                                                            <asp:Label ID="lblRequired5" runat="server" Style="display: block;"><span class="Required_t01">*</span></asp:Label>
                                                            <asp:Label ID="lblPhoneNumberAssociated" runat="Server" meta:resourcekey="lblPhoneNumberAssociated">Phone Number Associated With This Billing Address</asp:Label>:
                                                        </td>
                                                        <td style="border: none;">
                                                            <uc1:MustInputTextBox ID="txtTel" runat="server" CssClass="dropDownRes" />
                                                            &nbsp;&nbsp;<asp:Label ID="lblExt" runat="Server" meta:resourcekey="lblExt">Ext</asp:Label>-
                                                            <uc1:MustInputTextBox ID="txtExt" runat="server" IsValidEmpty="true" Width="50" CssClass="dropDownRes" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="3">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
