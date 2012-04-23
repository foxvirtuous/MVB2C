<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"
    Inherits="TourPrintInvoice" Codebehind="TourPrintInvoice.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
.frame_border{width:700px; margin:0 auto;}
.top{text-align:right; width:100%; float:left;}
.content{ width:100%; float:left; font-size:16px; font-family:Verdana, Arial, Helvetica, sans-serif;}
</style>

<script language="javascript">
			function doPrint(){
				document.getElementById("Div1").style.display="none";
	    
			    document.getElementById("txtFormContent").value = document.getElementById("MAIL_BODY").innerHTML;
				window.print();
				document.getElementById("Div1").style.display="";
			}
			function OnSearch()
		    {
			    document.getElementById("txtFormContent").value = document.getElementById("MAIL_BODY").innerHTML;  
		    }
		    
		    function OnReSearch()
	        {
		        OnSearch();
		        document.getElementById("IsFinised").value ="yes";
	            document.getElementById("form1").submit();
	        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <input id="IsFinised" type="hidden" name="IsFinised" runat="server" />
        <div id="Div1" runat="server" class="frame_border">
            <table id="NotShow" cellspacing="0" cellpadding="0" width="720" border="0" runat="server">
                <tr>
                    <td>
                        <asp:Label ID="lbMessage" ForeColor="red" Visible="False" runat="server"></asp:Label><asp:Label
                            ID="lbAddress" runat="server">Email Address:</asp:Label><asp:TextBox ID="txtEmail"
                                runat="server" Width="280px"></asp:TextBox><asp:Button ID="btnSendEmail" runat="server"
                                    Text="Send" OnClick="btnSendEmail_Click" ></asp:Button>&nbsp;
                        <asp:Button ID="btnPrint" runat="server" Text="Print" CausesValidation="False" ></asp:Button>&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Back" CausesValidation="False" OnClick="btnCancel_Click">
                        </asp:Button><asp:Label ID="lbCIUID" runat="server" Visible="False"></asp:Label><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Required"></asp:RequiredFieldValidator><input
                                id="txtFormContent" type="hidden" name="Hidden1" runat="server">
                        <asp:Label ID="lbVUID" runat="server" Visible="False"></asp:Label><asp:Label ID="lbTBUID"
                            runat="server" Visible="False"></asp:Label>
                        <asp:Label ID="lbCase" runat="server" Visible="False"></asp:Label></td>
                </tr>
            </table>
        </div>
        <div id="MAIL_BODY" runat="server">
            <div class="frame_border">
                <div class="top"><img src="http://www.majestic-vacations.com/images/GatewayTravel_Logo.gif" />
                    <img src="http://www.majestic-vacations.com/images/MJV_Logo.jpg" />
                </div>
                <div class="content">
                    <table cellpadding="0" cellspacing="0" border="0" width="91%" style="margin-top: 20px;">
                        <tr>
                            <td align="left">
                                4100 SPRING VALLEY RD.#202<br>
                                DALLAS TX 75244<br>
                                TEL 1-(888)-288-7528
                            </td>
                            <td align="center" width="50%" valign="top">
                                <asp:Label ID="lblOnvoiceNumber" runat="server" Text=""></asp:Label>
                                ITINERARY INVOICE</td>
                        </tr>
                        <tr>
                            <td >
                            </td>
                            <td  width="50%" align="center" style="padding-top: 15px;">
                                PNR:<asp:Label ID="lblPNR" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin-top: 40px;">
                        <tr>
                            <td colspan="2">
                                <asp:DataList ID="dlPassenger" runat="server" RepeatColumns="2" RepeatDirection="Horizontal"
                                    Width="100%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRoomNumber" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label>.&nbsp;
                                        <asp:Label ID="lblPassengerName" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                            <td width="24%">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                            </td>
                        </tr>
                        <tr>
                            <td width="43%" align="center">
                            </td>
                            <td align="center" width="33%">
                                ACCT CODE&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblAcountCode" runat="server" Text=""></asp:Label></td>
                            <td width="24%" align="right">
                                <asp:Label ID="lblDateNow" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                    <asp:DataList ID="dlInfo" runat="server" Width="100%">
                        <ItemTemplate>
                            <table cellpadding="3" cellspacing="0" border="0" width="100%" style="margin-top: 40px;">
                                <tr>
                                    <td width="8%">
                                        T TU</td>
                                    <td>
                                        <asp:Label ID="lblMonthAndDay" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "MonthAndDay")%>'></asp:Label></td>
                                    <td width="78%">
                                        <asp:Label ID="lblVenderCode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "VenderCode")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblState" runat="server" Text="CONFIRMED"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td align="right">
                                        <asp:Label ID="lblYear" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Year")%>'></asp:Label></td>
                                    <td>
                                        <asp:Label ID="lblFF1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FF1")%>'></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFF2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FF2")%>'></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFF3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FF3")%>'></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFF4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "FF4")%>'></asp:Label></td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <table cellpadding="3" cellspacing="0" border="0" width="100%" style="margin-top: 20px;">
                        <tr>
                            <td width="55%">
                            </td>
                            <td width="35%">
                                TAX</td>
                            <td align="right">
                                <asp:Label ID="lblTax" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                SUBTOTAL</td>
                            <td align="right">
                                <asp:Label ID="lblSubPrice" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                TOTAL INVOICE AMOUNT</td>
                            <td align="right">
                                <asp:Label ID="lblSubPrice2" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                                AMOUNT DUE</td>
                            <td align="right">
                                <asp:Label ID="lblSubPrice3" runat="server" Text=""></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center" style="padding-top: 30px;">
                                THANK YOU FOR YOUR BUSINESS</td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>

        <script language="javascript">					
					document.getElementById("txtFormContent").value = document.getElementById("MAIL_BODY").innerHTML;
					
        </script>

    </form>
</body>
</html>
