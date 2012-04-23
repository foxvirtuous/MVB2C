<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NewInsuranceSeachMainForm.aspx.cs"
    Inherits="NewInsuranceSeachMainForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insurance Booking</title>
    <link href="../../css/Insurance.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function DoChecked()
        {
            if(document.getElementById("rbtInsurancep1").checked)
            {
                if (!document.getElementById("cbtEmergency").checked)
                {
                    document.getElementById("cbtEmergency").checked = false;
                }
                document.getElementById("cbtEmergency").disabled = false;
                document.getElementById("cbtP3").checked = false;
                document.getElementById("cbtP3").disabled = true;
                
                if (document.getElementById("isChecked").value != "P1")
                {
                    document.getElementById("isChecked").value = "P1";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(document.getElementById("rbtInsurancep2").checked)
            {
                document.getElementById("cbtEmergency").checked = false;
                document.getElementById("cbtEmergency").disabled = true;
                if (!document.getElementById("cbtP3").checked)
                {
                    document.getElementById("cbtP3").checked = false;
                }
                document.getElementById("cbtP3").disabled = false;
                
                if (document.getElementById("isChecked").value != "P2")
                {
                    document.getElementById("isChecked").value = "P2";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(document.getElementById("rbtInsurancep4").checked)
            {
                document.getElementById("cbtEmergency").checked = false;
                document.getElementById("cbtEmergency").disabled = true;
                document.getElementById("cbtP3").checked = false;
                document.getElementById("cbtP3").disabled = true;
                
                if (document.getElementById("isChecked").value != "P4")
                {
                    document.getElementById("isChecked").value = "P4";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(document.getElementById("rbtInsurancep5").checked)
            {
                document.getElementById("cbtEmergency").checked = false;
                document.getElementById("cbtEmergency").disabled = true;
                document.getElementById("cbtP3").checked = false;
                document.getElementById("cbtP3").disabled = true;
                
                if (document.getElementById("isChecked").value != "P5")
                {
                    document.getElementById("isChecked").value = "P5";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
        }
        
        function DoChecked1()
        {
            if(document.getElementById("cbtEmergency").checked)
            {                
                if (document.getElementById("isChecked1").value != "Emt")
                {
                    document.getElementById("isChecked1").value = "Emt";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(document.getElementById("cbtP3").checked)
            {
                if (document.getElementById("isChecked1").value != "P3")
                {
                    document.getElementById("isChecked1").value = "P3";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            
            if(!document.getElementById("cbtEmergency").checked && !document.getElementById("cbtEmergency").disabled)
            {                
                if (document.getElementById("isChecked1").value == "Emt")
                {
                    document.getElementById("isChecked1").value = "";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(!document.getElementById("cbtP3").checked && !document.getElementById("cbtP3").disabled)
            {
                if (document.getElementById("isChecked1").value == "P3")
                {
                    document.getElementById("isChecked1").value = "";
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
        }
        function DoChecked2(a)
        {
            if(a == "TripCost")
            {                
                if (document.getElementById("TripCost").value != document.getElementById("txtTotalTripCost").value)
                {
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }                
            }
            else if(a == "TravelFrom")
            {
                if (document.getElementById("TravelFrom").value != document.getElementById("txtTravelFrom").value)
                {
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(a == "TravelTo")
            {                
                if (document.getElementById("TravelTo").value != document.getElementById("txtTravelTo").value)
                {
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(a == "Adults")
            {
                if (document.getElementById("Adults").value != document.getElementById("txtAdult").value)
                {
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
            else if(a == "Childs")
            {
                if (document.getElementById("Childs").value != document.getElementById("txtChilds").value)
                {
                    document.getElementById("lblSellingPrice").innerHTML = "";
                    document.getElementById("lblGTTReference").innerHTML = "";
                    
                    document.getElementById("btnPruchase").disabled = true;
                }
            }
        }
        
        function aa()
        {
            window.alert("Sign-time expired, Please login again !!!");
            window.location.href = 'http://www.gttglobal.com/';
        }
    </script>
</head>
<body onload="DoChecked()">
    <form id="form1" runat="server">
        <uc1:Header ID="Header1" runat="server" />
        <input type="hidden" value="" id="isChecked" runat="server" /><input type="hidden"
            value="" id="isChecked1" runat="server" /><input type="hidden" value="" id="TripCost"
                runat="server" />&nbsp;
        <input type="hidden" value="" id="TravelFrom" runat="server" /><input
                    type="hidden" value="" id="TravelTo" runat="server" /><input type="hidden" value=""
                        id="Adults" runat="server" /><input type="hidden" value="" id="Childs" runat="server" />
        <div class="IBE_package_main">
            <div style="width: 920px; float: left;">
                <div class="IBE_GrayDIV_Right_travelContact_step4">
                    <div class="IBE_package_SearchCondition_D_title_step4">
                        Booking Insurance Only</div>
                    <table class="IBE_package_SearchCondition_T_step03" border="0" cellpadding="8" cellspacing="1"
                        width="100%">
                        <tbody>
                            <tr class="IBE_package_SearchCondition_R_stepw">
                                <td align="left" width="50%">
                                    Case Number:
                                    <asp:TextBox ID="txtCaseNumber" runat="server" Style="width: 200px"></asp:TextBox><br />
                                    <span id='spTicketNumber' style="display:none" >Ticket Number:</span>
                                    <asp:TextBox ID="txtTicketNumber" runat="server" Style="width: 200px; display:none" ></asp:TextBox><br />
                                    <span id='Span1'>Ticketing Date:</span>                                    
                                    <asp:TextBox ID="txtTicketingDate" runat="server" Style="width: 200px;" ></asp:TextBox>(format:MM/dd/yyyy)
                                    <table class="IBE_T_step03" width="100%" align="center" border="0" cellpadding="0"
                                        cellspacing="1" style="margin-top: 10px;">
                                        <tbody>
                                            <tr class="IBE_R_stepw">
                                                <td align="center">
                                                    <div class="IBE_package_step6_TravelerInformation_title">
                                                        Insurance list</div>
                                                    <div class="IBE_package_step6_TravelerInformation_title_efs" >
                                                        <div class="left">
                                                            <asp:RadioButton ID="rbtInsurancep1" runat="server" Text="Individual & Group Inclusive Tour Program-Full (P1)"
                                                                Checked="false" GroupName="Insurance" onclick="DoChecked()" />
                                                        </div>
                                                        <div class="right">
                                                            <asp:HyperLink ID="hlInsurancep1" runat="server" Target="_blank" NavigateUrl="http://v1b2b.majestic-vacations.com/InsurancePdf/008233 P1 607 SG UV.pdf">Detail</asp:HyperLink></div>
                                                    </div>
                                                    <div class="IBE_package_step6_TravelerInformation_list"">
                                                        <ul>
                                                            <li>
                                                                <asp:CheckBox ID="cbtEmergency" runat="server" Text="Emergency Medical Transportation"
                                                                    Checked="false" onclick="DoChecked1()" /></li>
                                                        </ul>
                                                    </div>
                                                    <div class="IBE_package_step6_TravelerInformation_title_efs">
                                                        <div class="left">
                                                            <asp:RadioButton ID="rbtInsurancep2" runat="server" Text="Individual & Group Embedded Program (P3)"
                                                                Checked="false" GroupName="Insurance" onclick="DoChecked()" /></div>
                                                        <div class="right">
                                                            <asp:HyperLink ID="hlInsurancep2" runat="server" Target="_blank" NavigateUrl="http://v1b2b.majestic-vacations.com/InsurancePdf/008233 P2-P3 607 SG.pdf">Detail</asp:HyperLink></div>
                                                    </div>
                                                    <div class="IBE_package_step6_TravelerInformation_list">
                                                        <ul>
                                                            <li>
                                                                <asp:CheckBox ID="cbtP3" runat="server" Text="Optional Inclusive Progrm(P2) " Checked="false"
                                                                    onclick="DoChecked1()" /></li>
                                                        </ul>
                                                    </div>
                                                    <div class="IBE_package_step6_TravelerInformation_title_efs">
                                                        <div class="left">
                                                            <asp:RadioButton ID="rbtInsurancep4" runat="server" Text="International Air, Hotel, and Excursion Program (P4)"
                                                                Checked="true" GroupName="Insurance" onclick="DoChecked()" /></div>
                                                        <div class="right">
                                                            <asp:HyperLink ID="hlInsurancep4" runat="server" Target="_blank" NavigateUrl="http://v1b2b.majestic-vacations.com/InsurancePdf/008233 P4 607 SG.pdf">Detail</asp:HyperLink></div>
                                                    </div>
                                                    <div class="IBE_package_step6_TravelerInformation_title_efs" style="display:none" >
                                                        <div class="left">
                                                            <asp:RadioButton ID="rbtInsurancep5" runat="server" Text="GTT Global Air Consolidator Plan(P5)"
                                                                Checked="false" GroupName="Insurance" onclick="DoChecked()" /></div>
                                                        <div class="right">
                                                            <asp:HyperLink ID="hlInsurancep5" runat="server" Target="_blank" NavigateUrl="http://v1b2b.majestic-vacations.com/InsurancePdf/SG 008233 P5 310.pdf">Detail</asp:HyperLink></div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="IBE_package_SearchCondition_T_step04_all">
                                        <table align="right" border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr valign="top">
                                                    <td>
                                                        <table align="center" border="0" cellpadding="3" cellspacing="0" width="100%" style="border-bottom: 1px solid #ccc;">
                                                            <tbody>
                                                                <tr align="left" valign="top">
                                                                    <td width="22%" height="22" align="left">
                                                                        <font class="step3_price_price_t06">Total trip cost:</font></td>
                                                                    <td>
                                                                        $<asp:TextBox ID="txtTotalTripCost" runat="server" onchange="DoChecked2('TripCost')"></asp:TextBox></td>
                                                                </tr>
                                                                <tr align="left" valign="top">
                                                                    <td align="left" height="22">
                                                                        <font class="step3_price_price_t06">Travel date (from / to): </font>
                                                                    </td>
                                                                    <td width="78%">
                                                                        &nbsp;&nbsp;<asp:TextBox ID="txtTravelFrom" runat="server" onchange="DoChecked2('TravelFrom')"></asp:TextBox>
                                                                        /
                                                                        <asp:TextBox ID="txtTravelTo" runat="server" onchange="DoChecked2('TravelTo')"></asp:TextBox>
                                                                        (format:MM/dd/yyyy)</td>
                                                                </tr>
                                                                <tr align="left" valign="top">
                                                                    <td align="left" height="22">
                                                                        <font class="step3_price_price_t06">Number of adult(s):</font></td>
                                                                    <td>
                                                                        &nbsp;&nbsp;<asp:TextBox ID="txtAdult" runat="server" onchange="DoChecked2('Adults')"></asp:TextBox></td>
                                                                </tr>
                                                                <tr align="left" valign="top">
                                                                    <td align="left" height="22">
                                                                        <font class="step3_price_price_t06">Number of child(ren): </font>
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;&nbsp;<asp:TextBox ID="txtChilds" runat="server" onchange="DoChecked2('Childs')"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" align="right">
                                                                        <asp:Button ID="btnPricing" runat="server" Text="Pricing" OnClick="btnPricing_Click" /></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <table align="center" border="0" cellpadding="3" cellspacing="0" width="100%">
                                                            <tr align="left" valign="top">
                                                                <td height="20" width="22%" align="left">
                                                                    Insurance Selling Price:
                                                                </td>
                                                                <td>
                                                                    $<asp:Label ID="lblSellingPrice" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    Commission:</td>
                                                                <td style="vertical-align: middle">
                                                                    $<asp:Label ID="lblGTTReference" runat="server"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="center">
                                                                    <asp:Label ID="lblError" runat="server" ForeColor="red" Visible="false"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align=left width="100%">
                                                                    <span style="color:Red; text-align: left;">Please note:  To confirm your purchase of travel insurance, you must have purchased the travel arrangements being insured from GTT or Majestic Vacations.  Please provide either your case number, ticket number or invoice number in order to confirm this insurance policy is covering the correct travel arrangements. Nonrefundable - 24 hours after purchased. </span> </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td colspan="2" align="center" height="100px" style="vertical-align: middle">
                                                                    <asp:Button ID="btnPruchase" runat="server" Text="Purchase" OnClick="btnPruchase_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <div class="clear">
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>
</body>
</html>
