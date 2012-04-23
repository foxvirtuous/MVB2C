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
using Terms.Material.Service;

public partial class ChooseAirlines : Spring.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BulletedList1.Items.Clear();

            AirService airService = new AirService();

            if (Application["Allairways"] == null)
                Application["Allairways"] = airService.GetAllAirLines();

            DataSet ds = (DataSet)(Application["Allairways"]);

            if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].DefaultView != null)
                for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                    BulletedList1.Items.Add(new ListItem(ds.Tables[0].Rows[i][0].ToString(), "javascript:IntxtAirline('" + ds.Tables[0].Rows[i][1].ToString() + "');"));
        }
    }
}
