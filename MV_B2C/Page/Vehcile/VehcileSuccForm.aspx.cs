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
using TERMS.Business.Centers.SalesCenter;
using System.Collections.Generic;


public partial class VehcileSuccForm : SalseBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        NavigationControl1.PageCode = 4;
        if (!IsPostBack)
        {
            lblCaseNumber.Text = Request.Params["CaseNumber"];

            lblCarID.Text = ((VehcileOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).BookingId;

            VehcileInfoControl1.Flag = false;
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
                }
            }
        }
        else
        {
            lblSalesName.Text = "Garfield Zhang";
            lblSalesEmail.Text = @"<a href='#' class='d07'>gzhang@majestic-vacations.com</a>";
        }
    }

    protected void ibtnSubmit_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Index.aspx");
    }
}