using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Terms.Material.Domain;
using Terms.Material.Service;
using Terms.Product.Domain;
using Terms.Global.Utility;

public partial class PromosSearching : AirBook.Base.BookingPage
{
    private static readonly log4net.ILog AirSearchTimelog =
             log4net.LogManager.GetLogger("AirSearchTime");

    private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

    private AirService m_airService;

    protected AirService AirService
    {
        get
        {
            return m_airService;

        }
        set
        {
            m_airService = value;
        }
    }

    protected SessionClass sc
    {
        get
        {
            if (SessionExpired)
                return null;
            else
                return CurrentSession;

        }
    }

    public DateTime dtBeginTime = new DateTime();

    #region Page Load Event
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Page_Load(object sender, System.EventArgs e)
    {
        log.Info("Searching=  " + DateTime.Now.ToString());

        if (!Page.IsPostBack)
        {
            dtBeginTime = System.DateTime.Now;
            AirSearchTimelog.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >Load Searching.aspx Begin Start time : " + dtBeginTime);

            ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch('s');</script>");
        }
    }

    #endregion

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.PreRender += new EventHandler(PromosSearching_PreRender);
    }    
    #endregion

    #region PreRender Event
    void PromosSearching_PreRender(object sender, EventArgs e)
    {
        if (SessionExpired)
        {
            Err("The search condition has been removed from cache, please re-search.", "", "Searching.aspx");
        }

        if (Request.Params["ToSearch"] != null
            && Request.Params["ToSearch"].ToString().Trim().Length > 0)
        {
            this.ToSearch.Value = "";
            DateTime dtTime = System.DateTime.Now;
            AirSearchTimelog.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >DoSearch Begin Start time : " + dtTime);

            DoSearch();

            AirSearchTimelog.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >DoSearch End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtTime)).ToString());
            AirSearchTimelog.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >Searching.aspx  End time : " + ((TimeSpan)System.DateTime.Now.Subtract(dtBeginTime)).ToString());
            AirSearchTimelog.Info(Session["LOG_RANDOM"] == null ? "" : Session["LOG_RANDOM"].ToString() + " >Redirect Step2.aspx Begin Start time : " + System.DateTime.Now);

            Response.Redirect("~/Page/Promos/PromosAirListForm.aspx?ConditionID=" + Request.QueryString["ConditionID"]);

        }
    }
    #endregion

    #region User Define event
    /// <summary>
    /// the Search event
    /// </summary>
    private void DoSearch()
    {
        this.OnSearch();
    }

    #endregion
}