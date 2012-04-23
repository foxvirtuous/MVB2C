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

public partial class SendEmailTourControl :SalesBaseUserControl
{
    private IList<Passenger> _passenger;
    public IList<Passenger> Passenger
    {
        set
        {
            if (value is List<Passenger>)
            {
                List<Passenger> list = new List<Passenger>();

                for (int i = 0; i < value.Count; i++)
                {
                    list.Add(value[i]);
                }
                _passenger = value;
                dlPassengers.DataSource = list;
                dlPassengers.DataBind();
            }
        }
        get
        {
            return _passenger;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((TourOrderItem)this.Transaction.CurrentTransactionObject.Items[0]).IsInsurance)
            TourPriceInfoControl1.IsTourInsurance = true;
        lblBookingTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);

        if (!IsPostBack)
        {
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
    }

    private void InitBinderPassenger()
    {
        Passenger = Utility.Transaction.CurrentTransactionObject.GetPassengers();
    }


    protected void dlPassengers_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            DateTime birthDay = Convert.ToDateTime(((Label)e.Item.FindControl("lbBirthDay")).Text);
            if (IsDateTimeCurrent(birthDay))
            {
                ((Label)e.Item.FindControl("lbBirthDay")).Visible = true;
                ((Label)e.Item.FindControl("lbBirthDay")).Text = Convert.ToDateTime(((Label)e.Item.FindControl("lbBirthDay")).Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
            }
            else
            {
                ((Label)e.Item.FindControl("lbBirthDay")).Visible = false;
            }
        }
    }

    private bool IsDateTimeCurrent(DateTime dateTime)
    {
        return dateTime.CompareTo(new DateTime(1753, 1, 1)) >= 0 && dateTime.CompareTo(new DateTime(9999, 1, 1)) <= 0;
    }

    public void ReBinder()
    {
        InitBinderPassenger();
        if (Utility.Transaction.CurrentTransactionObject.Remark != "")
        {
            this.lbRemark.Text = Utility.Transaction.CurrentTransactionObject.Remark;
            tbRemark.Visible = true;
        }
    }
}
