<%@ Page Language="C#" AutoEventWireup="true"
    Inherits="HotelTravelerForm" EnableEventValidation="false" Codebehind="HotelTravelerForm.aspx.cs" %>

<%@ Register Src="../../UserControls/PHContactInfoControl.ascx" TagName="PHContactInfoControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/HotelListViewNewControl.ascx" TagName="HotelListViewControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/HotelOrderPassengerInfoControl.ascx" TagName="HotelOrderPassengerInfoControl"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc6" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div id="content">
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc6:NavigationControl ID="NavigationControl1" runat="server" />
                    </div>
                    <h1>
                        Enter your traveler information
                    </h1>
                    Please check your Order, then enter your traveller information below.
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-1.gif" width="20" height="20" align="texttop" />&nbsp;
                            Review the Order You Selected</h3>
                        <div class="base">
                            <div class="newprice">
                                <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                    <tr>
                                        <td>
                                            <strong>Total Price: </strong>
                                        </td>
                                        <td>
                                            <strong>$<asp:Label ID="lblTotal" runat="server" Text=""></asp:Label></strong></td>
                                    </tr>
                                </table>
                            </div>
                            <uc8:HotelListViewControl ID="HotelListViewControl1" runat="server" />
                        </div>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-2.gif" width="20" height="20" align="texttop" />
                            Enter Traveler Information</h3>
                        <uc7:HotelOrderPassengerInfoControl ID="HotelOrderPassengerInfoControl1" runat="server">
                        </uc7:HotelOrderPassengerInfoControl>
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-3.gif" width="20" height="20" align="texttop" />
                            Contact Information
                        </h3>
                        <uc3:PHContactInfoControl ID="PHContactInfoControl1" runat="server"></uc3:PHContactInfoControl>
                    </div>
                    <div id="divInsurance" runat="server" visible=false>
                        <h3>
                            <img src="../../images/v1/stepnumber-4.gif" width="20" height="20" align="texttop" />
                            Travel Insurance
                        </h3>
                        <div class="t_c">
                            <h4>
                                Insurance Include:</h4>
                            <ul>
                                <li style="overflow: auto">111111 price for passengers departing from the U.S.A. as
                                    per their confirmation and payment. </li>
                                <li>222222 adults sharing one room, double occupancy (please specify single or double
                                    beds in your reservation). A customer who travels alone is required to pay a single
                                    supplement rate. </li>
                                <li>33333tection Insurance is offered at an additional expense when the reservation
                                    is made or payment is received less than 45 days prior to departure. </li>
                            </ul>
                        </div>
                        <asp:CheckBox ID="chkInsurance" runat="server" Text="Buy insurance for this tirp "
                            CssClass="orglab" />
                    </div>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-4.gif" width="20" height="20" align="texttop" />
                            Other Remark for Your Trip</h3>
                        <textarea class="remark" runat="server" id="txtRemark" style="overflow: auto"></textarea>
                    </div>
                    <div class="btn">
                        Please confirm all of the information is correct, then click
                        <asp:ImageButton ID="ibtnSubmit" runat="server" idth="143" Height="33" border="0"
                            align="absmiddle" ImageUrl="../../images/v1/btn_submit.gif" ValidationGroup="PackageCreditForm"
                            OnClick="ibtnSubmit_Click" /></div>
                </div>
            </div>
            <p class="clear">
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </p>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
