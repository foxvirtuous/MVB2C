using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Spring.Web.UI;
using log4net;

using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;

public partial class HotelNewSearchControl : Spring.Web.UI.UserControl
{
    public HotelNewSearchControl()
    {
        this.InitializeControls += new System.EventHandler(HotelNewSearchControl_InitializeControls);
    }

    void HotelNewSearchControl_InitializeControls(object sender, System.EventArgs e)
    {
        
    }
}
