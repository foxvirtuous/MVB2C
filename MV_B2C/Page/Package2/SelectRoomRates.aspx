<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SelectRoomRates.aspx.cs"
    Inherits="SelectRoomRates" %>

<%@ Register Src="../../UserControls/PKGUserLogin.ascx" TagName="PKGUserLogin" TagPrefix="uc10" %>
<%@ Register Src="../../UserControls/PKGSearchConditionControl.ascx" TagName="PKGSearchConditionControl"
    TagPrefix="uc9" %>
<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/PKGLeftSelectCondtions.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/PKGFlightDetailsControl.ascx" TagName="PKGFlightDetailsControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/PKGPackageDetailsControl.ascx" TagName="PKGPackageDetailsControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers"
    TagPrefix="uc7" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <title meta:resourcekey="Title">Cheap air tickets, Hotels, Vacation Packages, Cruises, Tours, Depart from USA, Online Booking</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style_package.css"%>" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../../css/global.css" />
    <script src="<%=SaleWebSuffix + MainJSPath + "AutoLocationData.js"%>" type="text/javascript"></script>
    <script src="<%=SaleWebSuffix + MainJSPath + "Index_NewJS.js"%>" type="text/javascript"></script>
</head>
<body onload="SetRepeatPackage();"><input id="cityandairport" type="hidden" value="A" runat="server" />
        <input id="mouseindex" type="hidden" value="F" name="DefaultTab" runat="server" />
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <uc1:Header ID="Header1" runat="server" />
         <iframe style="visibility: hidden; position: absolute; width: 148px; height: 194px;
            z-index: 100; display: none; left: 9px; top: 0px;" id="calendarDateFrame" name="calendarDateFrame"
            marginheight="0" marginwidth="0" noresize frameborder="0" scrolling="NO" src="../../CommJs/Mvcalx.htm">
        </iframe>
        <div class="IBE_package_main">
            <div class="IBE_package_Dstep" align="right">
                <uc8:NavigationControl ID="NavigationControl1" runat="server" />
            </div>
            <div class="IBE_package_main_content">
                <div class="IBE_package_mainLeft">
                    <uc7:PackageLeftSelect ID="PackageLeftSelect1" runat="server" />
                    <%-- <uc7:ChangeTravelers ID="ChangeTravelers1" runat="server" />--%>
                </div>
                <div class="IBE_package_mainCenter">
                </div>
                <div class="IBE_package_mainRight">
                    <uc9:PKGSearchConditionControl ID="PKGSearchConditionControl1" runat="server" />
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblFlightInformation">Flight Information</asp:Label></span>
                    </div>
                    <div class="IBE_YellowDIV_Right">
                        <table class="IBE_T_step0l" align="center" border="0" cellpadding="0" cellspacing="1"
                            width="100%">
                            <tr class="IBE_R_stepw">
                                <td align="center">
                                    <uc6:PKGFlightDetailsControl ID="PKGFlightDetailsControl1" runat="server"></uc6:PKGFlightDetailsControl>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label2" runat="server" meta:resourcekey="lblSelectRoomType">Select Your Room Type</asp:Label></span>
                    </div>
                    <div class="IBE_YellowDIV_Right">
                        <div class="IBE_YellowDIV_Right_inSide1">
                            <uc3:PKGPackageDetailsControl ID="PKGPackageDetailsControl1" runat="server"></uc3:PKGPackageDetailsControl>
                        </div>
                    </div>
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label3" runat="server" meta:resourcekey="lblPrice">Price</asp:Label></span>
                    </div>
                    <div class="IBE_package_step_price">
                        <asp:Label ID="Label4" runat="server" meta:resourcekey="lblTotalFlightAndHotel">Total Flight and Hotel:</asp:Label>
                        <span class="IBE_head08">$<asp:Label ID="lblAvgPrice" runat="server">974.53</asp:Label></span>&nbsp;<asp:Label
                            ID="Label7" runat="server" meta:resourcekey="lblAvg">avg/person</asp:Label>
                            (<asp:Label ID="Label8" runat="server" meta:resourcekey="lblTotalCN"></asp:Label>$<asp:Label
                                ID="lblTotalPrice" runat="server"></asp:Label>
                            <asp:Label ID="Label10" runat="server" meta:resourcekey="lblTotal">total</asp:Label>)
                        &nbsp;
                        <%-- <asp:Button ID="Button1" runat="server" Text="Reprice" />
                        &nbsp;(Calculate the new price with selected upgrades.)--%>
                    </div>
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label5" runat="server" meta:resourcekey="lblTermsConditions">Terms and Conditions</asp:Label></span>
                    </div>
                    <div class="IBE_package_Terms" align="left">
                        <%--<asp:TextBox ID="txtConditions" runat="server" TextMode="MultiLine" Width="98%" Height="123"
                            OnTextChanged="txtConditions_TextChanged"></asp:TextBox>--%>
                            <asp:Label ID="lblConditions" runat="server" CssClass="IBE_package_textarea"></asp:Label>
                    </div>
                    <div class="IBE_package_step_Checkbox_conditions">
                        <asp:CheckBox ID="chkConditions" runat="server" /><a name="bottom"></a><a href="#bottom" id="clickLink"></a>
                        <span class="orglab">
                            <asp:Label ID="Label9" runat="server" meta:resourcekey="lblAgree">Yes, I agree to the Terms and Conditions above.</asp:Label></span>
                        &nbsp;&nbsp;
                    </div>
                    <div class="IBE_package_step_Checkbox_conditions_ok_btn">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr class="R_content">
                                <td height="50" align="right">
                                <asp:Button ID="btn_back" runat="server" Text="Back" Width="100" CssClass="IBE_search_btn02 right"
                                Style="cursor: pointer; margin-top: 6px; margin-left:5px; display:inline;" meta:resourcekey="btnBack" OnClick="btn_back_Click" />
                                 <div class="right"><asp:Label ID="lblMsg" runat="server" meta:resourcekey="lblMsg">Please click on <font id="P_red">"Continue"</font> to determine final price for
                                                                                            your itinerary.</asp:Label>&nbsp;
                                        <asp:Button ID="ImageButton1" runat="server" Text="Continue" CssClass="IBE_search_btn02"
                                    Width="100" Visible="true" OnClick="ImageButton1_Click" Style="cursor: pointer; margin-top: 6px;" meta:resourcekey="btnContinue" /></div>
                                
                                        
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="divMinStaysMessage" runat="server" visible="false">
                        <br />
                        <span class="IBE_head08"><asp:Label ID="Label6" runat="server" meta:resourcekey="lblMinimunNights">Minimun 5 nights hotel stay is requested.</asp:Label></span>
                        <br />
                    </div>
                    <div runat="server" id="divUserLogin" class="left" style="width:100%;">
                        <uc10:PKGUserLogin ID="UserLoginControl1" runat="server"></uc10:PKGUserLogin>
                    </div>
                    <%--</div>
                    </div>--%>
                    <%--<div id="divLongin" runat="server" align="right" class="left" style="text-align: right;
                        width: 100%;">
                        <div style="float: right;">
                            </div>
                        <asp:PlaceHolder ID="phLogin" runat="server">
    
                            
                                <asp:Label ID="Label6" runat="server" meta:resourcekey="lblIf">If you don't want to make any more change, please click&nbsp;&nbsp;</asp:Label>
                                </div>
                        
                        </asp:PlaceHolder>
                    </div>--%>
                </div>
            </div>
            <uc2:FooterP ID="Footer1" runat="server" />
        </div>
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>

<script type="text/javascript">
  function showDetail(obj,meta){
    while(obj.className != "IBE_package_List_dl_list_selectRoom")
    {
      obj = obj.parentNode;
    }
    while(obj.nextSibling)
    {
      obj = obj.nextSibling;
      if(obj.nodeType == 1)
      {
        if(obj.title == meta)
        {
         
          if(obj.style.display == "none")
          {
     
            obj.style.display = "block";
          }
          else
          {
            obj.style.display = "none";
          }
        }
        else
        {
            obj.style.display = "none";
            if(obj.title == "btn"){
              obj.style.display = "block";
            }
            else if(obj.title == "Change"){
              obj.style.display = "block";
            }
            else if(obj.title == "Room"){
              obj.style.display = "block";
            }
        }
      }
    }
  }

</script>

