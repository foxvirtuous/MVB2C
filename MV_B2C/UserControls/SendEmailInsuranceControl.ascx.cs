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

public partial class SendEmailInsuranceControl : SalesBaseUserControl
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

                string temp = value[0].LastName + " " + value[0].FirstName;
                lblDear.Text = temp;
            }
        }
        get
        {
            return _passenger;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblBookingTime.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm", System.Globalization.DateTimeFormatInfo.InvariantInfo);
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
        ContactViewControl1.BinderContact();
    }
}