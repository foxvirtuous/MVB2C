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

using log4net;
using Spring.Web.UI;

using Terms.Material.Domain;
using Terms.Material.Service;
using Terms.Sales.Business;
using System.Collections.Generic;

public partial class SuccessForm : SalseBasePage
{
    public SuccessForm()
    {
        this.InitializeControls += new EventHandler(SuccessForm_InitializeControls);
    }

    void SuccessForm_InitializeControls(object sender, EventArgs e)
    {
        //Button1.Attributes["onClick"] = "javascript:doPrint();return true;";
        Header1.Path = "../../";
        if (!this.IsPostBack)
        {
            NavigationControl1.PageCode = 4;

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.HotelSearchCondition)
            {
                this.lblCaseNumber.Text = this.Request["CaseNumber"];
            }
            else
            {
                if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.TourSearchCondition && ((TourSearchCondition)Utility.Transaction.CurrentSearchConditions).IsLandOnly)
                {
                    this.lblCaseNumber.Text = this.Request["CaseNumber"];
                }
                else
                {
                    this.lblCaseNumber.Text = this.Request["CaseNumber"];
                }
            }


            if (Utility.IsSubAgent)
            {
                string Handler;

                if (Utility.Transaction.Member.Handler == null || Utility.Transaction.Member.Handler.Trim().Length == 0)
                {
                    Handler = "DEFAULT";
                }
                else
                {
                    Handler = Utility.Transaction.Member.Handler;
                }

                List<Terms.Member.Utility.HandlerReceiver> Citys = Terms.Member.Utility.MemberUtility.GetHandlerReciever();

                for (int i = 0; i < Citys.Count; i++)
                {
                    if (Citys[i].Name.Trim().ToUpper() == Handler.Trim().ToUpper())
                    {
                        lblSalesName.Text = Citys[i].SalesName.Replace(",", " or ");
                        lblSalesEmail.Text = @"<a href='#' class='d07'>" + Citys[i].SalesEmail.Replace(",", @"</a> or <a href='#' class='d07'>") + @"</a>";
                        lblSalesTel.Text = Citys[i].Tel;
                    }
                }
            }
            else
            {
                lblSalesName.Text = "Garfield Zhang";
                lblSalesEmail.Text = @"<a href='mailto:gzhang@majestic-vacations.com'>gzhang@majestic-vacations.com</a>";
                lblSalesTel.Text = "1-(888)-288-7528";
            }

            lblNow.Text = DateTime.Now.ToString("MM/dd/yyy hh:mm");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ibtnSubmit_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Index.aspx");
    }
}
