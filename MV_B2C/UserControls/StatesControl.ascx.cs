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

public partial class StatesControl : Spring.Web.UI.UserControl
{
    public StatesControl()
    {
        this.InitializeControls += new EventHandler(StatesControl_InitializeControls);
    }

    void StatesControl_InitializeControls(object sender, EventArgs e)
    {
        
    }

    private int _pageCode;
    public int PageCode
    {
        set
        {
            _pageCode = value;
            switch (_pageCode)
            {
                case 1:
                    this.lblUL.Text = @"<ul><li class='stepon'>" + Resources.Global.Search + "</li><li>" + Resources.Global.Select + "</li><li>" + Resources.Global.OrderPayment + "</li><li>" + Resources.Global.Confirm + "</li></ul>";
                    break;
                case 2:
                    this.lblUL.Text = @"<ul><li class='stepon'>" + Resources.Global.Search + "</li><li class='stepon'>" + Resources.Global.Select + "</li><li>" + Resources.Global.OrderPayment + "</li><li>" + Resources.Global.Confirm + "</li></ul>";
                    break;
                case 3:
                    this.lblUL.Text = @"<ul><li class='stepon'>" + Resources.Global.Search + "</li><li class='stepon'>" + Resources.Global.Select + "</li><li class='stepon'>" + Resources.Global.OrderPayment + "</li><li>" + Resources.Global.Confirm + "</li></ul>";
                    break;
                case 4:
                    this.lblUL.Text = @"<ul><li class='stepon'>" + Resources.Global.Search + "</li><li class='stepon'>" + Resources.Global.Select + "</li><li class='stepon'>" + Resources.Global.OrderPayment + "</li><li class='stepon'>" + Resources.Global.Confirm + "</li></ul>";
                    break;
                default:
                    this.lblUL.Text = @"<ul><li>Search</li><li>" + Resources.Global.Search + "</li><li>" + Resources.Global.Select + "</li><li>" + Resources.Global.OrderPayment + "</li><li>" + Resources.Global.Confirm + "</li></ul>";
                    break;
            }
        }
    }

}
