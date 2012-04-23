<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackageCreditForm" Codebehind="PackageCreditForm.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/CreditCardInformationControl.ascx" TagName="CreditCardInformation"
    TagPrefix="uc2" %>
<%@ Register Src="~/UserControls/OrderView.ascx" TagName="OrderView" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <link href="~/css/style2.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <div id="content">
            <div class="step">
                &nbsp;<uc3:Navigation ID="Navigation1" runat="server" />
            </div>
            <h1>
                Payment by Credit Card
            </h1>
            <div class="ctline">
                <h3>
                    <img src="images/stepnumber-1.gif" width="20" height="20" align="absmiddle" />
                    Attention
                </h3>
                <div class="cs">
                    Please finish your payment before: <span class="dealpri">19/12/2007 23:59</span>.
                    Or our system will cancel this order without notification.
                </div>
            </div>
            <div class="ctline">
                <h3>
                    <div class="vdi">
                        <img src="images/btn_print.gif" width="56" height="25" />
                        <img src="images/btn_email.gif" width="56" height="25" /></div>
                    <img src="images/stepnumber-2.gif" width="20" height="20" align="absmiddle" />
                    Order Riew (Flight + Hotel)
                </h3>
                <table width="100%" cellpadding="0" cellspacing="0" class="order">
                    <tr>
                        <td style="width: 908px">
                            <uc1:OrderView ID="OrderView1" runat="server"></uc1:OrderView>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 908px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 908px">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 908px">
                        </td>
                    </tr>
                </table>
            </div>
            <div class="ctline">
                <h3>
                    <img src="images/stepnumber-3.gif" width="20" height="20" align="texttop" />
                    Enter Your Credit Card Information
                </h3>
                <uc2:CreditCardInformation ID="CreditCardInformation1" runat="server" />
            </div>
            <div>
                <h3>
                    <img src="images/stepnumber-4.gif" width="20" height="20" align="texttop" />
                    Verify the Email Address
                </h3>
            </div>
            <div class="cs">
                All current and furture correspondence or information will be send to this address:
                <a href="#">ABC@DEF.com</a>
            </div>
            <table width="100%" cellpadding="2" cellspacing="1" class="register_ab">
                <tr>
                    <td>
                        Sorry, we have been unable to contact you at your Email address. Please provide
                        a valid Email address. <a href="#">Change My Email Address</a>
                    </td>
                </tr>
            </table>
            <div class="btn">
                Please make sure everything is correct, and click
                <asp:ImageButton ID="btnPurchase" runat="server" ImageUrl="images/btn_purchase.gif"
                    DescriptionUrl="payment.html" Width="143" Height="33" />
            </div>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
