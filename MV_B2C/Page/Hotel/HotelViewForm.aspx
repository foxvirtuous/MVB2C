<%@ Page Language="C#" AutoEventWireup="true" Inherits="HotelViewForm"
    EnableEventValidation="false" Codebehind="HotelViewForm.aspx.cs" %>

<%@ Register Src="~/UserControls/HotelNewSearchTwoControl.ascx" TagName="HotelNewSearchTwoControl"
    TagPrefix="uc8" %>
<%@ Register Src="~/UserControls/HotelOnlySearchControl.ascx" TagName="HotelOnlySearchControl"
    TagPrefix="uc6" %>
<%@ Register Src="~/UserControls/HotelInfoControl.ascx" TagName="HotelInfoControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/HotelListViewNewControl.ascx" TagName="HotelListViewNewControl"
    TagPrefix="uc12" %>
<%@ Register Src="~/UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc11" %>
<%@ Register Src="~/UserControls/UserLogin.ascx" TagName="UserLogin" TagPrefix="uc7" %>
<%@ Register Src="~/UserControls/RemarkAndCall.ascx" TagName="RemarkAndCall" TagPrefix="uc4" %>
<%@ Register Src="~/UserControls/ChangeTravelersControl.ascx" TagName="ChangeTravelers"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare,
        Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="../../css/style_index.css" rel="stylesheet" type="text/css" />
    <link href="../../css/style2.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Expires" content="0" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />

    <script type="text/javascript">
        function ShowHideAddNewHotel()
        {
            if(document.getElementById("divAddNewHotel").style.display == "")
            {
                document.getElementById("divAddNewHotel").style.display = "none";
                document.getElementById("CurrentStateOfNewHotel").value = "none";
            }
            else
            {
                document.getElementById("divAddNewHotel").style.display = "";
                document.getElementById("CurrentStateOfNewHotel").value = "";
            }
        }
        
        window.onload = function ChangeToCurrentTab()
        {   
            document.getElementById("divAddNewHotel").style.display = document.getElementById("CurrentStateOfNewHotel").value;
        }
    </script>

    <link href="" rel="stylesheet" type="text/css" />
    <link href="" rel="stylesheet" type="text/css" />
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <input id="CurrentStateOfNewHotel" type="hidden" value="none" name="CurrentStateOfNewHotel"
            runat="server" />
        <div id="content">
            <div id="subcontent_r">
                <uc6:HotelOnlySearchControl ID="HotelOnlySearchControl1" runat="server" />
                <uc2:ChangeTravelers ID="cnlChangeTravelers" runat="server" />
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <div class="step">
                        <uc11:NavigationControl ID="ctlNavigationControl" runat="server" />
                    </div>
                    <h1>
                        Rate Details
                    </h1>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-1.gif" align="texttop" />
                            Room Rate Summary</h3>
                        <div class="base">
                            <uc3:HotelInfoControl ID="ctlHotelInfoControl" runat="server" />
                        </div>
                        <uc12:HotelListViewNewControl ID="ctlHotelListViewNewControl" runat="server" />
                        <div class="addmore">
                            <div align="right">
                                <img src="../../images/v1/arrow_right.gif" width="11" height="11" />
                                <input name="button2" type="button" class="hidenbtn" onclick="ShowHideAddNewHotel()"
                                    value="Add more hotel for this package" />
                            </div>
                            <div class="clear" id="divAddNewHotel" style="display: none">
                                <uc8:HotelNewSearchTwoControl ID="HotelNewSearchTwoControl1" runat="server" />
                            </div>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="upPriceInfo" runat="server">
                        <ContentTemplate>
                            <asp:PlaceHolder ID="phAgentFlightMarkup" runat="server"><div visible=false>
                                <div class="total" runat="server" id="divSubagent" visible="false">
                                    <span class="totalprice_15px">Agent Markup: $
                                        <asp:TextBox ID="txtSubagentMarkup" runat="server" Width="50px" MaxLength="6" AutoPostBack="True"
                                            OnTextChanged="txtAgentAdultUnitMarkup_TextChanged">
                                        </asp:TextBox>
                                        <asp:Label ID="lblAgentAdultUnitMarkup" runat="server" Text="" Visible="false" />
                                        <asp:RequiredFieldValidator ID="rfvAgentMarkup" runat="server" Display="None" ErrorMessage="Agent markup should be greater than equal $0."
                                            ControlToValidate="txtSubagentMarkup">
                                        </asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="cvAgentMarkup" runat="server" Display="None" ErrorMessage="Agent markup should be greater than equal $0."
                                            ControlToValidate="txtSubagentMarkup" Type="Double" Operator="GreaterThanEqual"
                                            ValueToCompare="0.00">
                                        </asp:CompareValidator>
                                    </span>
                                </div></div>
                                <div class="total">
                                    <span class="totalprice_15px">Hotel Total Cost: $<asp:Label ID="lblSum" runat="server"
                                        Text="Label"></asp:Label></span></div>
                            </asp:PlaceHolder>
                            <asp:ValidationSummary ID="vsPrice" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div>
                        <h3>
                            <img src="../../images/v1/stepnumber-2.gif" width="20" height="20" align="texttop" />
                            Terms and Conditions
                        </h3>
                        <div class="t_c">
                            <asp:Label ID="lbConditons" runat="server"></asp:Label>
                        </div>
                        <asp:CheckBox ID="chkConditions" runat="server" Text="Yes, I agree to the Terms and Conditions above."
                            CssClass="orglab" />
                    </div>
                    <div>
                        <div id="divSignIn">
                            <div id="divHead" runat="server">
                                <h3>
                                    <img src="../../images/v1/stepnumber-3.gif" width="20" height="20" align="texttop" />
                                    Member Sign In
                                </h3>
                            </div>
                            <uc7:UserLogin ID="UserLogin1" runat="server" />
                            <div id="divLongin" visible="false" runat="server">
                                <div class="btn" visible="true" id="divSubmit">
                                    If you don't want to make any more change, please click
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../images/v1/btn_continue.gif"
                                        Width="143" Height="33" border="0" align="absmiddle" Visible="true" OnClick="ImageButton1_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="subcontent_l_r">
                    <uc4:RemarkAndCall ID="RemarkAndCall1" runat="server" />
                </div>
            </div>
            <p class="clear">
                &nbsp; &nbsp;&nbsp;</p>
        </div>
        <uc2:Footer ID="Footer1" runat="server" />
    </form>

    <script language="javascript" type="text/javascript">
        history.go(1);
    </script>

</body>
</html>
