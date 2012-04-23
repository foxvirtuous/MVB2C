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

public partial class HTLEmailViewControl : SalesBaseUserControl
{
    private List<HotelOrderItem> _hotelDetails;
    public List<HotelOrderItem> HotelDetails
    {
        set
        {
            if (value is List<HotelOrderItem>)
            {
                ddlHotel.DataSource = HotelOrderUtility.GetHotelDataSource(value);
                ddlHotel.DataBind();
            }
        }
        get
        {
            if (_hotelDetails == null)
            {
                _hotelDetails = new List<HotelOrderItem>();
            }

            return _hotelDetails;
        }
    }

    public HTLEmailViewControl()
    {
        this.InitializeControls += new EventHandler(HTLEmailViewControl_InitializeControls);
    }

    private void HTLEmailViewControl_InitializeControls(object sender, EventArgs e)
    {
        if (Utility.Transaction.CurrentTransactionObject != null)
        {
            if (!IsPostBack)
            {
                this.lblDate.Text = DateTime.Now.ToString();
                SetCondition();

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
                    lblSalesEmail.Text = @"<a href='#'>gzhang@majestic-vacations.com</a>";
                    lblSalesTel.Text = "1-(888)-288-7528";
                }
            }
        }
        else
        {
            //³ö´í´¦Àí
        }

    }

    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            lbName.Text = Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.FirstName + " " + Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.MiddleName + " " + Utility.Transaction.CurrentTransactionObject.GetContacts()[0].Person.LastName;
        }
    }

    private void SetCondition()
    {

        if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
        {
            List<HotelOrderItem> hotelMaterial = new List<HotelOrderItem>();

            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                if (Utility.Transaction.CurrentTransactionObject.Items[i] is HotelOrderItem)
                {
                    hotelMaterial.Add((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]);
                }
            }

            HotelDetails = hotelMaterial;
        }
    }

    private bool IsDateTimeCurrent(DateTime dateTime)
    {
        return dateTime.CompareTo(new DateTime(1753, 1, 1)) >= 0 && dateTime.CompareTo(new DateTime(9999, 1, 1)) <= 0;
    }

    protected void ddlHotel_ItemDataBound(object sender, DataListItemEventArgs e)
    {
    }

    public void BindValueToControls()
    {
        uclCreditCardEmailControl.BindValueToControls();

    }
}
