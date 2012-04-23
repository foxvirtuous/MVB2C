<%@ Control Language="C#" AutoEventWireup="true" Codebehind="CreditCardEmailControl.ascx.cs"
    Inherits="CreditCardEmailControl" %>
<table class="IBE_T_step03" align="center" border="0" cellpadding="0" cellspacing="1"
    width="100%" style="float:left;">
    <tr class="R_order03">
        <td align="left">
        <div class="IBE_package_step6_TravelerInformation_title" align="center">
                                                        <asp:Label ID="lblPaymentInfo" runat="server" meta:resourcekey="lblPaymentInfo">Payment and Billing Information</asp:Label></div>
           
            <%--<asp:Panel ID="pnlPamentDetailWhenNoCreditCard" runat="server">
                <table border="0" cellpadding="3" cellspacing="1" class="T_step03" width="100%">
                    <tr class="R_order01">
                        <td height="25" width="13%">
                            <asp:Label ID="lblPaymentTypeWhenNoCreditCard" runat="server" meta:resourcekey="lblPayType">Payment Type</asp:Label>:</td>
                        <td width="37%" rowspan="3">
                            <asp:Label ID="lblNotPayedByCreidtCardMsg" runat="server">Not payed by credit card. </asp:Label></td>
                    </tr>
                </table>
            </asp:Panel>--%>
            <asp:Panel ID="pnlPamentDetail" runat="server" style="float:left; width:100%;">
                <table border="0" cellpadding="3" cellspacing="1" class="IBE_T_step03" width="100%">
                    <tr class="IBE_R_stepw">
                        <td height="25" width="18%">
                            <asp:Label ID="lblPayType" runat="server" meta:resourcekey="lblPayType">Payment Type</asp:Label>:</td>
                        <td width="37%">
                            <asp:Label ID="lblPaymentType" runat="server"></asp:Label></td>
                        <td width="18%">
                            <asp:Label ID="lblPayerLName" runat="server" meta:resourcekey="lblPayerLName">Payer Last Name</asp:Label>:</td>
                        <td width="32%">
                            <asp:Label ID="lblPayerLastName" runat="server"></asp:Label></td>
                    </tr>
                    <tr class="IBE_R_stepw">
                        <td height="25">
                            <asp:Label ID="lblCrtCard" runat="server" meta:resourcekey="lblCrtCard">Credit Card Type</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblCreditCard" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPayerFName" runat="server" meta:resourcekey="lblPayerFName">Payer First Name</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblPayerFirstName" runat="server"></asp:Label></td>
                    </tr>
                    <tr class="IBE_R_stepw">
                        <td height="25">
                            <asp:Label ID="lblCardNO" runat="server" meta:resourcekey="lblCardNO">Card Number</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblCardNumber" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblPayerMName" runat="server" meta:resourcekey="lblPayerMName">Payer Middle Name</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblPayerMiddleName" runat="server"></asp:Label></td>
                    </tr>
                    <tr class="IBE_R_stepw">
                        <td style="height: 63px">
                            <asp:Label ID="lblExpDate" runat="server" meta:resourcekey="lblExpDate">Expiration Date</asp:Label>:</td>
                        <td style="height: 63px">
                            <asp:Label ID="lblExpirationDate" runat="server"></asp:Label></td>
                        <td style="height: 63px">
                            <asp:Label ID="lblCy2" runat="server" meta:resourcekey="lblCity">City</asp:Label>:</td>
                        <td style="height: 63px">
                            <asp:Label ID="lblCity" runat="server"></asp:Label></td>
                    </tr>
                    <tr class="IBE_R_stepw">
                        <td>
                            <asp:Label ID="lblCreditCardBankName" runat="server" meta:resourcekey="lblCreditCardBankName">Credit Card Bank Name</asp:Label></td>
                        <td>
                            <asp:Label ID="lblCreditCardBankName_Value" runat="server"></asp:Label></td>
                        <td height="25">
                            <asp:Label ID="lblSt" runat="server" meta:resourcekey="lblState">State</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblState" runat="server"></asp:Label></td>
                    </tr>
                    <tr class="IBE_R_stepw">
                        <td>
                            <asp:Label ID="lblCreditCardCustomerServicePhoneNumber" runat="server" meta:resourcekey="lblCreditCardCustomerServicePhoneNumber">Credit Card 24</asp:Label></td>
                        <td>
                            <asp:Label ID="lblCreditCardCustomerServicePhoneNumber_Value" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblZipCode2" runat="server" meta:resourcekey="lblZip">Zip</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblZip" runat="server"></asp:Label></td>
                    </tr>
                    <tr class="IBE_R_stepw">
                        <td height="25">
                            <asp:Label ID="lblBAddress" runat="server" meta:resourcekey="lblBAddress">Street Address</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblBillingAddress" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lblTele" runat="server" meta:resourcekey="lblTel">Tel</asp:Label>:</td>
                        <td>
                            <asp:Label ID="lblTel" runat="server"></asp:Label></td>
                    </tr>
                    <%--                                                    <tr class="R_order01">
                                                        <td height="25">
                                                            Email</td>
                                                        <td>
                                                            <asp:Label ID="lblEmail" runat="server"></asp:Label></td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>--%>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
