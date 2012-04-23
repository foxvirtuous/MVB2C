<%@ Page Language="C#" AutoEventWireup="true" Inherits="Terms.Web.Page.Hotel.SucceedForm" Codebehind="SucceedForm.aspx.cs" %>

<%@ Register Src="~/UserControls/Navigation.ascx" TagName="Navigation" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" media="screen">

    <script type="text/javascript">
		    function chickAllCheckBox()
		    {
		        if(document.getElementById("clickAll").checked)
		        {
		            document.getElementById("chk1").checked = "checked";
		            document.getElementById("chk2").checked = "checked";
		        }
		    }
    </script>

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
                <uc3:Navigation ID="Navigation1" runat="server" />
            </div>
            <h1>
                <asp:Label ID="lblThanksPurchase" runat="server" meta:resourcekey="lblThanksPurchase">Thanks for Your Purchase</asp:Label>
            </h1>
            <asp:Label ID="Label1" runat="server" meta:resourcekey="lblconfirmation">The confirmation e-mail will be sent out within 3 business days.</asp:Label><br />
            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblMsg">If you do not hear back from us within 3 business days, please call us at 1-(888)-288-7528.</asp:Label>
            <div class="ctline">
                <h3>
                    <img src="../../images/V1/stepnumber-1.gif" width="20" height="20" align="absmiddle" />
                    <asp:Label ID="lblOrderNumber" runat="server" meta:resourcekey="lblOrderNumber">Your Order Number</asp:Label>: <span class="dealpri">
                        <asp:Label ID="lblCaseNumber" runat="server" Text=""></asp:Label></span><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span
                        class="dealpri"><asp:Label ID="lblRcordLocator" runat="server" Text="Airline Record Locator :"
                            Visible="False" meta:resourcekey="lblRcordLocator"></asp:Label></span>
                </h3>
                <div class="cs">
                    <asp:Label ID="lblOrderOn" runat="server" meta:resourcekey="lblOrderOn">Order was placed on</asp:Label>:&nbsp;&nbsp;&nbsp;<asp:Label ID="lblDateNow" runat="server" Text=""></asp:Label>
                    <asp:Label ID="Label3" runat="server" meta:resourcekey="lblUSEastenTime">US Eastern Time</asp:Label></div>
            </div>
            <div class="ctline">
                <h3>
                    <img src="../../images/V1/stepnumber-2.gif" width="20" height="20" align="texttop" />
                    <asp:Label ID="lblServiceContact" runat="server" meta:resourcekey="lblServiceContact">Service Contact</asp:Label></h3>
                <div class="cs">
                    <asp:Label ID="lblCustomerStaff" runat="server" meta:resourcekey="lblCustomerStaff">Customer Service Staff</asp:Label><span class="dealpri"><asp:Label ID="lblSalesName" runat="server" Text="Label"></asp:Label></span><br />
                    <asp:Label ID="lblPhone" runat="server" meta:resourcekey="lblPhone">Phone</asp:Label>: <span class="dealpri">1-(888)-288-7528</span><br />
                    <asp:Label ID="lblEmail" runat="server" meta:resourcekey="lblEmail">Email</asp:Label>: <asp:Label ID="lblSalesEmail" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="btn">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/btn_back.gif"
                    OnClick="ImageButton1_Click" /></div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
