<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="HotelCreditForm" ValidateRequest="False"  EnableEventValidation="false"  Codebehind="HotelCreditForm.aspx.cs" %>

<%@ Register Src="../../UserControls/EmailViewControl.ascx" TagName="EmailViewControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/CreditCardInformationControl.ascx" TagName="CreditCardInformation"
    TagPrefix="uc2" %>
    <%@ Register Src="~/UserControls/OrderView.ascx" TagName="OrderView" TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="Navigation" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <script language="javascript" type="text/javascript">
    function GetFormContent(){
				if(document.getElementById("flagSearch") != null)
				    document.getElementById("flagSearch").value = document.getElementById("MAIL_BODY").innerHTML;
			}
			
			function DEB(b)
	{
	if(b)
	{
	    document.getElementById("emlc").style.display="none";
	    document.getElementById("emal").style.display="block";
	}
	else
	{
	    document.getElementById("emlc").style.display="block";
	    document.getElementById("emal").style.display="none";
	}
    
    </script>
    <link href="<%=SecureUrlSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SecureUrlSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
</head>
<body onload="GetFormContent();">
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" /><iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
    z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame" marginheight="0"
    marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm"></iframe>
        <div id="content">
            <div class="step">
                <uc1:Navigation ID="Navigation" runat="server" />
            </div>
            <h1>
                <asp:Label ID="Label1" runat="server" meta:resourcekey="lblPaymentCredit">Payment by Credit Card</asp:Label>
            </h1>
            <div class="ctline">
                <h3>
                    <img src="../../images/v1/stepnumber-1.gif" width="20" height="20" align="absmiddle" />
                    <asp:Label ID="Label2" runat="server" meta:resourcekey="lblAttention">Attention</asp:Label>
                </h3>
                <div class="cs">
                    <asp:Label ID="Label3" runat="server" meta:resourcekey="lblFinish">Please finish your payment before</asp:Label>: <span class="dealpri">
                        <asp:Label ID="lblDate" runat="server" Text=""></asp:Label>
                        23:59</span>.<asp:Label ID="Label13" runat="server" meta:resourcekey="lblFinishCN"></asp:Label> <asp:Label ID="Label4" runat="server" meta:resourcekey="lblNotification">Or our system will cancel this order without notification.</asp:Label>
                </div>
            </div>
            <div class="ctline">
                <h3>
                    <img src="../../images/v1/stepnumber-2.gif" width="20" height="20" align="absmiddle" />
                    <asp:Label ID="Label5" runat="server" meta:resourcekey="lblOrderReview">Order Review</asp:Label></h3>
            </div>
            <uc3:OrderView ID="OrderView1" runat="server" />
            <div class="ctline">
                <h3>
                    <img src="../../images/v1/stepnumber-3.gif" width="20" height="20" align="texttop" />
                    <asp:Label ID="Label6" runat="server" meta:resourcekey="lblEnterCredit">Enter Your Credit Card Information</asp:Label>
                </h3>
                <div class="cs">
                    <uc2:CreditCardInformation ID="CreditCardInformation1" runat="server" />
                </div>
            </div>
            <div>
                <h3>
                    <img src="../../images/v1/stepnumber-4.gif" width="20" height="20" align="texttop" />
                    <asp:Label ID="Label7" runat="server" meta:resourcekey="lblEmailAddress">Verify the Email Address</asp:Label>
                </h3>
            </div>
            <div class="cs">
                <asp:Label ID="Label8" runat="server" meta:resourcekey="lblSendAddress">All current and future correspondence or information will be send to this address</asp:Label>:&nbsp;<asp:HyperLink NavigateUrl="#"
                    ID="lblEmail" runat="server"></asp:HyperLink><BR>
                <div id="emlc" style="display: block">
                    <a id="A280_1424" href="javascript:DEB(1)"><font class="small"><asp:Label ID="Label9" runat="server" meta:resourcekey="lblChangeEmail">Change the e-mail address</asp:Label></font></a>
                </div>
                <div id="emal" style="display: none">
                    <label for="emad">
                        <asp:Label ID="Label10" runat="server" meta:resourcekey="lblChangeMyEmail">Change my e-mail address to</asp:Label>:</label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <br>
                    <br>
                    <span class="colHead"><asp:Label ID="Label11" runat="server" meta:resourcekey="lblImportant"><b>Important:</b> Any changes you make to this e-mail address
                        will be permanently reflected in your account after the completion of this purchase.</asp:Label></span><br>
                </div>
                	
                <%--<a href="#">ABC@DEF.com</a>--%>
            </div>
            <%--<table width="100%" cellpadding="2" cellspacing="1" class="register_ab" visible="false">
                <tr>
                    <td>
                        Sorry, we have been unable to contact you at your Email address. Please provide
                        a valid Email address. <a href="#">Change My Email Address</a>
                    </td>
                </tr>
            </table>--%>
            <div class="btn">
                <asp:Label ID="Label12" runat="server" meta:resourcekey="lblClick">Please make sure everything is correct, and click</asp:Label>
                <asp:ImageButton ID="ibtnSubmit" runat="server" idth="143" Height="33" border="0"
                    align="absmiddle" ImageUrl="../../images/v1/btn_purchase.gif" ValidationGroup="Default"
                    OnClick="ibtnSubmit_Click" /></div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div id="MAIL_BODY" visible="false" style="display: none"> 
                <uc6:EmailViewControl ID="EmailViewControl1" runat="server" />
            </div>
            <asp:HiddenField ID="flagSearch" Value="" runat="server" />
            <asp:TextBox ID="TextBox1" runat="server" Width="0px" Height="0px" Style="display: none"></asp:TextBox>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
