using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Spring.Web.UI;
using log4net;

public partial class NavigationControl : Spring.Web.UI.UserControl
{
    private int _pageCode;
    public int PageCode
    {
        set
        {
            _pageCode = value;
            switch (_pageCode)
            {
               case 1:
                    this.lblUL.Text = @"<table width=""305"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                            <tbody>
                                                <tr align=""center"">
                                                    <td height=""3"" class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                </tr>
                                                <tr align=""center"">
                                                    <td class=""D_stepto"">" + Resources.Global.Search + @"      </td>
                                                    <td width=""2""></td>
                                                    <td class=""D_steptf"">" + Resources.Global.Select + @"      </td>
                                                    <td width=""2""></td>
                                                    <td class=""D_steptf"">" + Resources.Global.OrderPayment + @"</td>
                                                    <td width=""2""></td>
                                                    <td class=""D_steptf"">" + Resources.Global.Confirm + @"     </td>
                                                </tr>
                                            </tbody>
                                        </table>";
                    break;
                case 2:
                    this.lblUL.Text = @"<table width=""305"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                            <tbody>
                                                <tr align=""center"">
                                                    <td height=""3"" class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                </tr>
                                                <tr align=""center"">
                                                    <td class=""D_stepto"">" + Resources.Global.Search + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_stepto"">" + Resources.Global.Select + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_steptf"">" + Resources.Global.OrderPayment + @"</td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_steptf"">" + Resources.Global.Confirm + @"     </td>
                                                </tr>
                                            </tbody>
                                        </table>";
                    break;
                case 3:
                    this.lblUL.Text = @"<table width=""305"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                            <tbody>
                                                <tr align=""center"">
                                                    <td height=""3"" class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                </tr>
                                                <tr align=""center"">
                                                    <td class=""D_stepto"">" + Resources.Global.Search + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_stepto"">" + Resources.Global.Select + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_stepto"">" + Resources.Global.OrderPayment + @"</td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_steptf"">" + Resources.Global.Confirm + @"     </td>
                                                </tr>
                                            </tbody>
                                        </table>";
                    break;
                case 4:
                    this.lblUL.Text = @"<table width=""305"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                            <tbody>
                                                <tr align=""center"">
                                                    <td height=""3"" class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepon""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepon""></td>
                                                </tr>
                                                <tr align=""center"">
                                                    <td class=""D_stepto"">" + Resources.Global.Search + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_stepto"">" + Resources.Global.Select + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_stepto"">" + Resources.Global.OrderPayment + @"</td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_stepto"">" + Resources.Global.Confirm + @"     </td>
                                                </tr>
                                            </tbody>
                                        </table>";
                    break;
                default:
                    this.lblUL.Text = @"<table width=""305"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                                            <tbody>
                                                <tr align=""center"">
                                                    <td height=""3"" class=""D_stepof""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                    <td width=""2""></td>
                                                    <td class=""D_stepof""></td>
                                                </tr>
                                                <tr align=""center"">
                                                    <td class=""D_steptf"">" + Resources.Global.Search + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_steptf"">" + Resources.Global.Select + @"      </td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_steptf"">" + Resources.Global.OrderPayment + @"</td>
                                                    <td width=""2""></td>  
                                                    <td class=""D_steptf"">" + Resources.Global.Confirm + @"     </td>
                                                </tr>
                                            </tbody>
                                        </table>";
                    break;
            }
        }
    }

    public NavigationControl()
    {
        this.InitializeControls += new EventHandler(NavigationControl_InitializeControls);
    }

    void NavigationControl_InitializeControls(object sender, EventArgs e)
    {
        
    }
}
