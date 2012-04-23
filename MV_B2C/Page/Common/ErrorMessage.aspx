<%@ Page Language="C#" AutoEventWireup="true" Inherits="Terms.Web.Page.Common.ErrorMessage" Codebehind="ErrorMessage.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Majestic Vacations: Super value Airfare, All Wordwild Airfare , Cheap Airfare, Hotels, Air+Hotel package , Cheap Tours , Cheap Cruises</title>
    <link href="<%=SaleWebSuffix + MainCssPath + "style2.css"%>" rel="stylesheet" type="text/css" />
    <link href="<%=SaleWebSuffix + MainCssPath + "style_index.css"%>" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="content">
        <form id="form1" runat="server">
            <uc1:Header ID="Header1" runat="server" />
            <div id="subcontent_r">
            </div>
            <div id="subcontent_l">
                <div id="subcontent_l_l">
                    <h1>
                        <asp:Label ID="Label1" runat="server" meta:resourcekey="lblWarning">Warning</asp:Label>
                    </h1>
                    <div>
                        <div id="Features">
                            <h3>
                                <p>
                                    <asp:Label ID="ErrorMessageLabel" runat="server" Text=""></asp:Label>
                                </p>
                            </h3>
                        </div>
                        <p>
                            <asp:Label ID="Label2" runat="server" meta:resourcekey="lblThank">Thank you for using <strong>Majestic Vacations</strong></asp:Label>.</p>
                    </div>
                    <div class="changebtn">
                        <img src="../../images/v1/arrow_sq.jpg" width="14" height="14" align="absmiddle" />
                        <asp:HyperLink ID="HyperLink2" runat="server" meta:resourcekey="hlBackLast">Back to last page</asp:HyperLink>
                        |
                        <img src="../../images/v1/arrow_sq.jpg" width="14" height="14" align="absmiddle" />
                        <asp:HyperLink ID="HyperLink1" runat="server" meta:resourcekey="hlBackHome">Back to Homepage</asp:HyperLink>
                    </div>
                </div>
            </div>
            <p class="clear">
            </p>
            <uc2:Footer ID="Footer1" runat="server" />
        </form>
    </div>
</body>
</html>
