<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="PackagePaymentForm" Codebehind="PackagePaymentForm.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations:Super value Airfare,All Wordwild Airfare,Cheap Airfare,Hotels,Air+Hotel package,Cheap Tours,Cheap Cruises</title>
    <link href="../css/style2.css" rel="stylesheet" type="text/css" />

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
                <ul>
                    <li class="stepon">Search</li>
                    <li class="stepon">Select</li>
                    <li class="stepon">Review</li>
                    <li class="stepon">Traveler</li>
                    <li class="stepon">Order</li>
                    <li class="stepon">Payment</li>
                    <li class="stepon">Confirm</li>
                </ul>
            </div>
            <h1>
                Thanks for Your Purchase
            </h1>
            The confirmation e-mail will be sent out within 3 business days.<br />
            If you do not hear back from us within 3 business days, please call us at 1-(888)-288-7528.
            <div class="ctline">
                <h3>
                    <img src="images/stepnumber-1.gif" width="20" height="20" align="absmiddle" />
                    Your Order Number: <span class="dealpri">
                        <asp:Label ID="lbOrderID" runat="server" Text='MAH-012407-pgreer-cyu-op-011707'></asp:Label></span>
                </h3>
                <div class="cs">
                    Order was placed on:12/12/2007 12:40:22 US Easten Time</div>
            </div>
            <div class="ctline">
                <h3>
                    <img src="images/stepnumber-2.gif" width="20" height="20" align="texttop" />
                    Service Contact</h3>
                <div class="cs">
                    Customer Service Staff: <span class="dealpri">Jane Wong</span><br />
                    Phone: <span class="dealpri">111-111-1111</span> Extension: <span class="dealpri">1111</span><br />
                    Email: <a href="#">Jane_w@majestic-vacations.com </a>
                </div>
            </div>
            <div class="btn">
                <asp:ImageButton ID="btnBack" runat="server" Width="143" Height="33" ImageUrl="images/btn_back.gif"
                    DescriptionUrl="PackageSearchForm.aspx" />
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>
</body>
</html>
