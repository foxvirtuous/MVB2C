<%@ Control Language="C#" AutoEventWireup="true" Inherits="CreditCardInfoControl"
    Codebehind="CreditCardInfoControl.ascx.cs" %>
<%@ Register Src="~/UserControls/MustInputTextBox.ascx" TagName="MustInputTextBox"
    TagPrefix="uc1" %>
<style>
.table_border td{ border:1px solid #ccc; border-left:none; border-bottom:none;}

</style>

<script language="javascript" type="text/javascript">
        function showPaymentType()
        {
            if (document.getElementById("CreditCardInfoControl1_ddlPaymentType") != null)
            {
                var type = document.getElementById("CreditCardInfoControl1_ddlPaymentType").value;
                if (type == "2")
                {
                    document.getElementById("CreditCardInfoControl1_trCard1").style.display = "";
                    document.getElementById("CreditCardInfoControl1_trCard2").style.display = "";
                    document.getElementById("CreditCardInfoControl1_trCard3").style.display = "";
                    document.getElementById("CreditCardInfoControl1_trCard4").style.display = "";
                    document.getElementById("CreditCardInfoControl1_trCard5").style.display = "";
                    document.getElementById("CreditCardInfoControl1_trCard6").style.display = "";
                    document.getElementById("CreditCardInfoControl1_trCard7").style.display = "";
                }
                else
                {
                    document.getElementById("CreditCardInfoControl1_trCard1").style.display = "none";
                    document.getElementById("CreditCardInfoControl1_trCard2").style.display = "none";
                    document.getElementById("CreditCardInfoControl1_trCard3").style.display = "none";
                    document.getElementById("CreditCardInfoControl1_trCard4").style.display = "none";
                    document.getElementById("CreditCardInfoControl1_trCard5").style.display = "none";
                    document.getElementById("CreditCardInfoControl1_trCard6").style.display = "none";
                    document.getElementById("CreditCardInfoControl1_trCard7").style.display = "none";
                }
            }
        }
</script>

<!--*****************************************************************-->
<table width="100%" border="0" cellspacing="1" cellpadding="8" class="IBE_T_step03 IBE_T_font_11">
    <tr class="IBE_R_stepw">
        <td>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td height="20" align="right" valign="top">
                        <span class="t01">*</span> =
                        <asp:Label ID="lblRequired" runat="server" meta:resourcekey="lblRequired" CssClass="IBE_T_font_11">Required</asp:Label></td>
                </tr>
            </table>
            <table class="IBE_T_step03 IBE_T_font_11 table_border" align="center" border="0"
                cellpadding="3" cellspacing="0" width="100%">
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" visible="false"
                    id="trPaymentType">
                    <td width="25%" style="border-left: 1px solid #ccc;">
                        <span class="t01">*</span>
                        <asp:Label ID="Label2" runat="server" meta:resourcekey="lblPaymentType">Payment Type</asp:Label>:</td>
                    <td colspan="3" width="60%">
                        <asp:DropDownList ID="ddlPaymentType" runat="server" onchange="showPaymentType()">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" id="trCard1" style="display: block;">
                    <td width="25%" style="border-left: 1px solid #ccc;">
                        <span class="t01">*</span>
                        <asp:Label ID="lblCardType" runat="server" meta:resourcekey="lblCardType">Card Type</asp:Label>:</td>
                    <td colspan="2" width="60%">
                        <asp:DropDownList ID="ddlCardType" runat="server">
                        </asp:DropDownList></td>
                    <td width="60%" rowspan="6" align="center">
                        <img src="<%=SecureUrlSuffix + "images/v2/card_front.gif"%>" hspace="3" vspace="5"
                            border="0" align="absmiddle" /><br>
                        <img src="<%=SecureUrlSuffix + "images/v2/card_back.gif"%>" hspace="3" vspace="5"
                            border="0" align="absmiddle" /></td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" id="trCard2" style="display: block;">
                    <td style="border-left: 1px solid #ccc;">
                        <span class="t01">*</span>
                        <asp:Label ID="lblCardNumber" runat="server" meta:resourcekey="lblCardNumber">Card Number</asp:Label>:</td>
                    <td colspan="2">
                        <uc1:MustInputTextBox ID="txtCardNumber1" runat="server" Width="50" IsNumberStyle="true" autocomplete="off"
                            MaxLength="4" />
                        <%--onkeyup="this.value=this.value.replace(/\D/g,'')"  onafterpaste="this.value=this.value.replace(/\D/g,'')" onKeyDown='if (this.value.length>=4){event.returnValue=false}'--%>
                        &nbsp;-&nbsp;<uc1:MustInputTextBox ID="txtCardNumber2" runat="server" Width="50" autocomplete="off"
                            IsNumberStyle="true" MaxLength="4" />
                        -&nbsp;<uc1:MustInputTextBox ID="txtCardNumber3" runat="server" Width="50" IsNumberStyle="true" autocomplete="off"
                            MaxLength="4" />
                        -
                        <uc1:MustInputTextBox ID="txtCardNumber4" runat="server" Width="50" IsNumberStyle="true" autocomplete="off"
                            MaxLength="4" />
                    </td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" id="trCard3" style="display: block;">
                    <td style="border-left: 1px solid #ccc;">
                        <span class="t01">*</span>
                        <asp:Label ID="lblExpirationdate" runat="server" meta:resourcekey="lblExpirationdate">Expiration date</asp:Label>:&nbsp;</td>
                    <td colspan="2">
                        <asp:DropDownList ID="ddlMonth" runat="server">
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
                        <asp:DropDownList ID="ddlYear" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" id="trCard4" style="display: block;">
                    <td style="border-left: 1px solid #ccc;">
                        <span class="t01">*</span>
                        <asp:Label ID="lblVerification" runat="server" meta:resourcekey="lblVerification">Card Verification Number</asp:Label>:</td>
                    <td colspan="2">
                        <uc1:MustInputTextBox ID="txtCardIdentification" runat="server" />
                    </td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" id="trCard5" style="display: block;">
                    <td valign="top" style="border-left: 1px solid #ccc;">
                        <span class="t01">*</span>
                        <asp:Label ID="lblCreditCardBankName" runat="server" meta:resourcekey="lblCreditCardBankName">Credit Card Bank Name</asp:Label>:</td>
                    <td colspan="2">
                        <uc1:MustInputTextBox ID="txtCreditCardBankName" runat="server" />
                        <asp:Label ID="lblCreditCardBankNameMsg" runat="server" meta:resourcekey="lblCreditCardBankNameMsg"> (e.g., Chase Bank) </asp:Label>
                    </td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" id="trCard6" style="display: block;">
                    <td valign="top" style="border-left: 1px solid #ccc;">
                        <span class="t01">*</span>
                        <asp:Label ID="lblCreditCardCustomerServicePhoneNumber" runat="server" meta:resourcekey="lblCreditCardCustomerServicePhoneNumber">Credit Card 24 Hour Customer Service Phone No</asp:Label>:</td>
                    <td colspan="2">
                        <uc1:MustInputTextBox ID="txtCreditCardCustomerServicePhoneNumber" runat="server" />
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblCreditCardCustomerServicePhoneNumberMsg"> (e.g., back of card 1-800-1234567)</asp:Label>
                    </td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" runat="server" id="trCard7" style="display: block;">
                    <td valign="top" style="border-left: 1px solid #ccc;">
                        <asp:Label ID="lblCardHolder" runat="server" meta:resourcekey="lblCardHolder">Card Holder</asp:Label>:</td>
                    <td colspan="3">
                        <span class="t01">*</span>
                        <asp:Label ID="lblLastName" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                        <uc1:MustInputTextBox ID="txtLast" runat="server" />
                        &nbsp;&nbsp;<span class="t01">*</span>
                        <asp:Label ID="lblFirstName" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                        <uc1:MustInputTextBox ID="txtFirst" runat="server" />
                    </td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left" style="border-left: 1px solid #ccc;">
                    <td style="border-left: 1px solid #ccc;">
                        <asp:Label ID="lblPrimaryAddress" runat="server" meta:resourcekey="lblPrimaryAddress">Primary Billing Address</asp:Label>:
                    </td>
                    <td colspan="3">
                        <table class="IBE_T_step03" align="center" border="0" cellpadding="3" cellspacing="0"
                            width="100%">
                            <tr class="IBE_R_stepw IBE_T_font_11">
                                <td style="border-left: 1px solid #ccc;">
                                    <span class="t01">*</span>
                                    <asp:Label ID="lblLastName2" runat="server" meta:resourcekey="lblLastName">Last Name</asp:Label>:
                                </td>
                                <td>
                                    <uc1:MustInputTextBox ID="txtPrimaryLast" runat="server" />
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw IBE_T_font_11">
                                <td width="16%" style="border-left: 1px solid #ccc;">
                                    <span class="t01">*</span>
                                    <asp:Label ID="lblFirstName2" runat="server" meta:resourcekey="lblFirstName">First Name</asp:Label>:
                                </td>
                                <td width="59%">
                                    <uc1:MustInputTextBox ID="txtPrimaryFirst" runat="server" />
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw IBE_T_font_11">
                                <td style="border-left: 1px solid #ccc;">
                                    <asp:Label ID="lblCompanyName" runat="server" meta:resourcekey="lblCompanyName">Company Name</asp:Label>:</td>
                                <td>
                                    <uc1:MustInputTextBox ID="txtCompany" runat="server" IsValidEmpty="true" Width="300px" />
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw IBE_T_font_11">
                                <td style="border-left: 1px solid #ccc;">
                                    <span class="t01">*</span>
                                    <asp:Label ID="lblStreet" runat="server" meta:resourcekey="lblStreet">Street</asp:Label>:
                                </td>
                                <td>
                                    <uc1:MustInputTextBox ID="txtStreet" runat="server" Width="300px" />
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw IBE_T_font_11">
                                <td style="border-left: 1px solid #ccc;">
                                    <span class="t01">*</span>
                                    <asp:Label ID="lblCity" runat="server" meta:resourcekey="lblCity">City</asp:Label>:</td>
                                <td>
                                    <uc1:MustInputTextBox ID="txtCity" runat="server" />
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw IBE_T_font_11">
                                <td style="border-left: 1px solid #ccc;">
                                    <span class="t01">*</span>
                                    <asp:Label ID="lblState" runat="server" meta:resourcekey="lblState">Country or Area</asp:Label>:</td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddlCountry" runat="server" Width="180px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCountry"
                                                Display="Dynamic" ErrorMessage="Please select country or area." SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                                            &nbsp;&nbsp;
                                            <asp:DropDownList ID="ddlState" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlState"
                                                Display="Dynamic" ErrorMessage="Please select city." SetFocusOnError="True">
                                            </asp:RequiredFieldValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr class="IBE_R_stepw IBE_T_font_11">
                                <td style="border-left: 1px solid #ccc; border-bottom: 1px solid #ccc;">
                                    <span class="t01">*</span>
                                    <asp:Label ID="lblPostal" runat="server" meta:resourcekey="lblPostal">Zip/Postal Code</asp:Label>:
                                </td>
                                <td style="border-bottom: 1px solid #ccc;">
                                    <uc1:MustInputTextBox ID="txtZip" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr class="IBE_R_stepw IBE_T_font_11" align="left">
                    <td colspan="4" style="border-left: 1px solid #ccc; border-bottom: 1px solid #ccc;">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="border: none;">
                                    <span class="t01">*</span>
                                    <asp:Label ID="lblPhoneAddress" runat="server" meta:resourcekey="lblPhoneAddress">Phone Number Associated With This Billing Address</asp:Label>:
                                </td>
                                <td style="border: none;">
                                    <%-- Area-
                                                            <uc1:MustInputTextBox ID="txtArea" runat="server" Width="50" />--%>
                                    &nbsp;&nbsp;<asp:Label ID="lblPhoneNo" runat="server" meta:resourcekey="lblPhoneNo">Phone No.</asp:Label>-
                                    <uc1:MustInputTextBox ID="txtTel" runat="server" />
                                    &nbsp;&nbsp;<asp:Label ID="lblExt" runat="server" meta:resourcekey="lblExt">Ext</asp:Label>-
                                    <uc1:MustInputTextBox ID="txtExt" runat="server" IsValidEmpty="true" Width="50" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<div>
    <%--   <ajaxToolkit:CascadingDropDown ID="cddState" runat="server" TargetControlID="ddlCountry"
        Category="Country" PromptText="Please select a country" LoadingText="[Loading hotels...]"
        ServiceMethod="GetDropDownContents" ParentControlID="" />
    <ajaxToolkit:CascadingDropDown ID="cddCountry" runat="server" TargetControlID="ddlState"
        Category="Provinces" PromptText="Please select a state" LoadingText="[Loading cities...]"
        ServiceMethod="GetDropDownContents" ParentControlID="ddlCountry" />--%>
</div>
