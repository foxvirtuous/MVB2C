<%@ Page Language="C#" AutoEventWireup="true" Inherits="SearchTest"
    EnableEventValidation="false" Codebehind="SearchTest.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Œﬁ±ÍÃ‚“≥</title>
</head>
<script type="text/javascript"> 
    function CancelSelect(obj,tempSpan)
 {
     elems = obj.form.elements;  
     var strTemp = tempSpan;
     var ttt = tempSpan.substr(0,20);
    
     for(i=0;i<elems.length;i++)
     {
        if (elems[i].type=="radio" && elems[i].name.substr(0,20) == ttt)
        {
          if (elems[i].type=="radio" && elems[i].id != obj.id && obj.name.substr(0,40) == strTemp)
          {
            if (elems[i].checked)
            {
                elems[i].checked = false;
                
                elems[i].alt = '';
            }
          } 
          
          if (elems[i].type=="radio" && elems[i].id == obj.id && obj.name.substr(0,40) == strTemp)
          {
            if (elems[i].alt == '001' && elems[i].checked)
            {
                elems[i].checked = false;
                
                elems[i].alt = '';
            }
            else
            {
                elems[i].alt = '001';
            }            
          }          
        }
     }
 }   
</script>
<body>
    <form id="form1" runat="server">
        <div>
            <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
                z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
                marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
            </iframe>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 730px">
                <tr>
                    <td style="width: 100px">
                        Country or Area
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dllCountry" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        City
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dllCity" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Service Date
                    </td>
                    <td style="width: 100px">
                        <TermsCalender:TermsCalendar ID="TermsCalendar1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Language of Tour
                    </td>
                    <td style="width: 100px">
                        <asp:Label ID="Label1" runat="server" Text="E"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Number of Adults
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dllAdults" runat="server">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Number of Children
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dllChildren" runat="server">
                            <asp:ListItem>0</asp:ListItem>
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        SightSeeisngCategorys
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dllSightSeeisngCategorys" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        SightSeeingType
                    </td>
                    <td style="width: 100px">
                        <asp:CheckBoxList ID="chSightSeeingType" runat="server">
                        </asp:CheckBoxList></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        Languages
                    </td>
                    <td style="width: 100px">
                        <asp:DropDownList ID="dllLanguages" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td style="width: 100px" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td style="width: 100px" colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" /></td>
                </tr>
            </table>
            <ajaxToolkit:CascadingDropDown ID="cddHotel" runat="server" TargetControlID="dllCountry"
                Category="Country" PromptText="Please select a country" LoadingText="[Loading hotels...]"
                ServiceMethod="GetDropDownContents" ParentControlID="" />
            <ajaxToolkit:CascadingDropDown ID="cddCity" runat="server" TargetControlID="dllCity"
                Category="City" PromptText="Please select a city" LoadingText="[Loading cities...]"
                ServiceMethod="GetDropDownContents" ParentControlID="dllCountry" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <asp:DataList ID="dlSightSeeings" runat="server">
                            <ItemTemplate>
                                <table width="100%" border="0" cellpadding="0" cellspacing="1" class="T_step02">
                                    <tr class="R_stepo">
                                        <td valign="top">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="1" cellpadding="0" class="T_step0l">
                                                            <tr>
                                                                <td>
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="1">
                                                                        <tr class="R_step03" align="center">
                                                                            <td height="30" align="left">
                                                                                &#12288;<asp:Label ID="lblFromTo" runat="server" Text=""></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr class="R_stepw">
                                                                <td>
                                                                    <asp:DataList ID="dlSightSeeing" runat="server" Width="100%">
                                                                        <ItemTemplate>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <%--
                                                                        <td width="13%" align="center">
                                                                            <img src="../images/080327_hotel_01.jpg" vspace="10" /></td>--%>
                                                                                    <td width="75%" align="left">
                                                                                        <b>
                                                                                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label></b><br />
                                                                                        <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label><br />
                                                                                        <asp:Label ID="lblTime" runat="server" Text=""></asp:Label><br />
                                                                                        <font class="t06">Total Price:
                                                                                            <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label></font><br />
                                                                                    </td>
                                                                                    <td width="5%" align="center">
                                                                                        <asp:HyperLink ID="hpDetail" runat="server" Target="_blank">Detail</asp:HyperLink>
                                                                                    </td>
                                                                                    <td width="5%" align="center">
                                                                                        <asp:RadioButton ID="rbnSelect" runat="server" Checked="false" />
                                                                                        <asp:Label ID="lblItemCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblVehiclesCode" runat="server" Text="" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblMaxPassengers" runat="server" Text="" Visible="false"></asp:Label>
                                                                                        <asp:Label ID="lblMaxLuggage" runat="server" Text="" Visible="false"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:DataList></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList></td>
                </tr>
            </table>
        </div>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        <asp:Label ID="lblTourOperationList" runat="server" Text=""></asp:Label>
        <br />
        Language
        <asp:DropDownList ID="dllLanguage" runat="server">
         </asp:DropDownList><br />
         Time <asp:DropDownList ID="dllTime" runat="server">
         </asp:DropDownList>
        <br />
        <asp:Button ID="btnBooking" runat="server" Text="Booking" OnClick="btnBooking_Click" />
        <br />
        <asp:Label ID="lblGtaID" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
