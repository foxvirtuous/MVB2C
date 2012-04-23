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
using System.Collections.Generic;

namespace Terms.Web.Page.Cruise
{
    public partial class CuriseMoreSearchResultFrom : SalseBasePage
    {
        private IEditFlyerService m_EditFlyerService;

        public IEditFlyerService EditFlyerService
        {
            set { m_EditFlyerService = value; }
            get { return m_EditFlyerService; }
        }

        protected string Port
        {
            get
            {
                if (Request.QueryString["port"] == null || Request.QueryString["port"] == string.Empty)
                {
                    return string.Empty;
                }
                else
                {
                    return Request.QueryString["port"];
                }

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IList allCrusies = m_EditFlyerService.GetFlyer("Cruise", string.Empty);
            IList Crusies = new List<FlyerMeta>();

            for (int i = 0; i < allCrusies.Count; i++)
            {
                FlyerMeta crusies = (FlyerMeta)allCrusies[i];

                if (crusies.FlyerAirline.ToLower() == Port.ToLower())
                {
                    Crusies.Add(crusies);
                }
            }

            dlCruiseList.DataSource = Crusies;
            dlCruiseList.DataBind();
        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CruiseIndex.aspx");
        }
    }
}
