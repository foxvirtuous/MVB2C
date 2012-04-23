<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ViewYourPackages.aspx.cs"
    Inherits="ViewYourPackages" %>

<%@ Register Src="../../UserControls/NavigationControl.ascx" TagName="NavigationControl"
    TagPrefix="uc8" %>
<%@ Register Src="../../UserControls/PKGLeftSelectCondtions.ascx" TagName="PackageLeftSelect"
    TagPrefix="uc7" %>
<%@ Register Src="../../UserControls/PKGPackageDetailsInfoControl.ascx" TagName="PKGPackageDetailsInfoControl"
    TagPrefix="uc6" %>
<%@ Register Src="../../UserControls/PKGSearchConditionControl.ascx" TagName="PKGSearchConditionControl"
    TagPrefix="uc3" %>
<%@ Register Src="~/UserControls/PKGChangeTravelersControl.ascx" TagName="ChangeTravelers"
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
                    <%--<uc7:ChangeTravelers ID="ChangeTravelers1" runat="server" />--%>
                </div>
                <div class="IBE_package_mainCenter">
                </div>
                <div class="IBE_package_mainRight">
                    <uc3:PKGSearchConditionControl ID="PKGSearchConditionControl2" runat="server"></uc3:PKGSearchConditionControl>
                    <div class="IBE_package_step">
                        <div class="IBE_package_step_T_line01 left">
                            &gt;</div>
                        <span class="left">&nbsp;<asp:Label ID="Label1" runat="server" meta:resourcekey="lblViewYourPackages">View Your Packages</asp:Label></span>
                    </div>
                    <uc6:PKGPackageDetailsInfoControl ID="PKGPackageDetailsInfoControl1" runat="server">
                    </uc6:PKGPackageDetailsInfoControl>
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
    while(obj.className != "IBE_package_List_dl_list")
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
            obj.style.display = "block"
          }
          else
          {
            obj.style.display = "none"
          }
        }
        else
        {
          if(obj.title == "btn")
          {
            obj.style.display = "block";
          }
          else
          {
            obj.style.display = "none";
          }
          
        }
      }
    }
  }

</script>

