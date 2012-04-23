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

public partial class LocationTextBoxControl : System.Web.UI.UserControl
{
   

    private string path = string.Empty; 
    public string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }
   
    private string _city = string.Empty;
    public string City
    {
        get { return _city; }
        set
        {
            _city = value; this.txtCity.Text = value;
        }
    }
    private int size = 130;
    public int Size
    {
        get
        {
            return size;
        }
        set
        {
            size = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.txtCity.Width = new Unit(Size);
        City = this.txtCity.Text;

    }
}
