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
using System.Collections.Generic;
using Spring.Web.UI;
using log4net;
using Terms.Sales.Service;
using Terms.Sales.Utility;
using Terms.Base.Domain;
using System.Globalization;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Common;

public partial class HTLTravelerControl : Spring.Web.UI.UserControl
{
    private IList<TERMS.Business.Centers.SalesCenter.Passenger> _passenger;
    public IList<TERMS.Business.Centers.SalesCenter.Passenger> Passenger
    {
        set
        {
            if (value is List<TERMS.Business.Centers.SalesCenter.Passenger>)
            {
                dlPassengers.DataSource = value;
                dlPassengers.DataBind();
            }
        }
        get
        {
            if (_passenger == null)
                _passenger = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

            return _passenger;
        }
    }

    public HTLTravelerControl()
    {
        this.InitializeControls += new EventHandler(HTLTravelerControl_InitializeControls);
    }

    private void HTLTravelerControl_InitializeControls(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            if (!IsPostBack)
            {
                SetCondition();
            }
        }
        else
        {
            //³ö´í´¦Àí
        }

    }


    private void SetCondition()
    {
        Passenger = Utility.Transaction.CurrentTransactionObject.GetPassengers();
    }

    protected void dlPassengers_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Footer && e.Item.ItemType != ListItemType.Header)
        {
            Label lbl = (Label)e.Item.FindControl("Label3");

            if (lbl.Text.Trim() == "0".Trim())
            {
                lbl.Text = "Mr";
            }
            if (lbl.Text.Trim() == "1".Trim())
            {
                lbl.Text = "Mrs";
            }
            if (lbl.Text.Trim() == "2".Trim())
            {
                lbl.Text = "Ms";
            }
            if (((Label)e.Item.FindControl("lbBirth")).Text.Trim() != "")
            {
                DateTime birthDay = Convert.ToDateTime(((Label)e.Item.FindControl("lbBirth")).Text);
                if (IsDateTimeCurrent(birthDay))
                {
                    ((Label)e.Item.FindControl("lbBirth")).Visible = true;
                    ((Label)e.Item.FindControl("lbBirth")).Text = Convert.ToDateTime(((Label)e.Item.FindControl("lbBirth")).Text).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                }
                else
                {
                    ((Label)e.Item.FindControl("lbBirth")).Visible = false;
                }
            }
        }
    }

    private bool IsDateTimeCurrent(DateTime dateTime)
    {
        return dateTime.CompareTo(new DateTime(1753, 1, 1)) >= 0 && dateTime.CompareTo(new DateTime(9999, 1, 1)) <= 0;
    }
}
