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
using Terms.Sales.Service;
using Terms.Sales.Utility;
using Terms.Material.Domain;
using Terms.Base.Domain;
using Terms.Product.Domain;
using System.Globalization;
using System.Collections.Generic;
using TERMS.Business.Centers.SalesCenter;

public partial class PKGTravelerInfoControl : SalesBaseUserControl
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

                dlPassengers.DataSource = list;
                dlPassengers.DataBind();
            }
        }
        get
        {
            return _passenger;
        }
    }


    public PKGTravelerInfoControl()
    {
        this.InitializeControls += new EventHandler(PKGTravelerInfoControl_InitializeControls);
    }

    void PKGTravelerInfoControl_InitializeControls(object sender, EventArgs e)
    {
        this.PATH = "~/Page/Flight/";
        if (Utility.Transaction.CurrentTransactionObject == null)
        {
            Err("The search condition has been removed from cache, please re-search.", "", "CreditCardInfoForm.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                InitBinderPassenger();
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
}
