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
using Terms.Additional.Service;
using Terms.Additional.Domain;

public partial class Flyerpkg : SalseBasePage
{
    private IEditFlyerService m_EditFlyerService;

    public IEditFlyerService EditFlyerService
    {
        set { m_EditFlyerService = value; }
        get { return m_EditFlyerService; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (!IsPostBack)
        {
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_Flyer, this);
            BindFlyer();
        }
    }

    private void BindFlyer()
    {
        IList list = m_EditFlyerService.GetFlyer(this.Request["Region"], this.Request["Type"], @"0', '2");

        gridFlyer.DataSource = list;
        gridFlyer.DataBind();

        for (int i = 0; i < gridFlyer.Rows.Count; i++)
        {
            FlyerMeta flyerMeta = (FlyerMeta)list[i];

            GridViewRow row = gridFlyer.Rows[i];

            
            if (flyerMeta.FlyerAirline == null || string.IsNullOrEmpty(flyerMeta.FlyerAirline))
            {
                ((Label)row.FindControl("lblFlyerName")).Text = flyerMeta.FlyerName;
                ((Label)row.FindControl("lblFlyerAirClass")).Text = flyerMeta.FlyerAirClass;
            }
            else
            {
                ((Label)row.FindControl("lblFlyerName")).Text = flyerMeta.FlyerName + " - " + flyerMeta.FlyerAirline.Trim();
                ((Label)row.FindControl("lblFlyerAirClass")).Text = @"<img src='../images/airline/" + flyerMeta.FlyerAirline.Trim() + ".gif' vspace='3' align='absmiddle' />" + flyerMeta.FlyerAirClass;
            }

            if (flyerMeta.FlyerFromDate == null || string.IsNullOrEmpty(flyerMeta.FlyerFromDate.Value.ToString()) || flyerMeta.FlyerToDate == null || string.IsNullOrEmpty(flyerMeta.FlyerToDate.Value.ToString()))
            {
                ((Label)row.FindControl("lblDate")).Text = "";
            }
            else
            {
                ((Label)row.FindControl("lblDate")).Text = flyerMeta.FlyerFromDate.Value.ToString("MM/dd/yyyy") + " - " + flyerMeta.FlyerToDate.Value.ToString("MM/dd/yyyy");
            }
            ((Label)row.FindControl("lblFlyerRegion")).Text = flyerMeta.FlyerRegion;
            ((HyperLink)row.FindControl("hlDownload")).NavigateUrl = ConfigurationManager.AppSettings.Get("PDFDownloadPath") + flyerMeta.Flyerurl;
            ((HyperLink)row.FindControl("hlDownload")).Target = "_blank";
        }
    }
}
