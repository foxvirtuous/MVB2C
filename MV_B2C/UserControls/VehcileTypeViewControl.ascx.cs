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
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Web.UserControls;
using TERMS.Common;
using Terms.Sales.Business;

public partial class VehcileTypeViewControl : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        if (!IsPostBack)
        {
            BindItemList();

            lbtnAll.Attributes.Add("onclick", "SearchTypeAll()");
        }
    }

    public VehcileTypeViewControl()
    {
        this.PreRender += new EventHandler(VehcileTypeViewControl_PreRender);
    }

    void VehcileTypeViewControl_PreRender(object sender, EventArgs e)
    {
        //BindCarType();
    }

    private void BindItemList()
    {
        VehcileMerchandise m_SaleMerchandise = (VehcileMerchandise)this.OnSearch();

        int day = ((TimeSpan)((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).DropoffTime.Subtract((((VehcileSearchCondition)Utility.Transaction.CurrentSearchConditions).PickupTime))).Days;

        List<string> CarSizes = new List<string>();

        if (m_SaleMerchandise.Items != null && m_SaleMerchandise.Items.Count > 0)
        {
            foreach (TERMS.Core.Product.Component component in m_SaleMerchandise.Items)
            {
                VehcileMaterial vehcilematerial = (VehcileMaterial)component;

                if (!CarSizes.Contains(vehcilematerial.Vehciles.VehicleType))
                {
                    CarSizes.Add(vehcilematerial.Vehciles.VehicleType);
                }
            }
        }

        repCarType.DataSource = CarSizes;
        repCarType.DataBind();

        for (int i = 0; i < CarSizes.Count; i++)
        {
            string CarSize = CarSizes[i];

            DataListItem item = repCarType.Items[i];

            CheckBox cbCarType = (CheckBox)item.FindControl("cbCarType");
            LinkButton lbtnCarType = (LinkButton)item.FindControl("lbtnCarType");
            Label lblCarType = (Label)item.FindControl("lblCarType");
            Label lblPrice = (Label)item.FindControl("lblPrice");

            decimal decPrice = Decimal.Zero;

            foreach (TERMS.Core.Product.Component component in m_SaleMerchandise.Items)
            {
                VehcileMaterial vehcilematerial = (VehcileMaterial)component;

                if (vehcilematerial.Vehciles.VehicleType == CarSize)
                {
                    Price TotalPrice = vehcilematerial.GetTotalPrice(vehcilematerial.PickupDateTime, vehcilematerial.DropoffDateTime);

                    TotalPrice.GetAmount(TERMS.Common.PassengerType.Adult);

                    if (decPrice == Decimal.Zero)
                    {
                        decPrice = TotalPrice.GetAmount(TERMS.Common.PassengerType.Adult);
                    }
                    else
                    {
                        if (decPrice > TotalPrice.GetAmount(TERMS.Common.PassengerType.Adult))
                        {
                            decPrice = TotalPrice.GetAmount(TERMS.Common.PassengerType.Adult);
                        }
                    }
                }
            }

            lblPrice.Text = (decPrice / day).ToString("N2");

            switch (CarSize)
            {
                //case "1":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Mini";
                //    break;
                //case "2":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Subcompact";
                //    break;
                case "3":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Economy";
                    break;
                case "4":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Compact";
                    break;
                //case "5":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Midsize";
                //    break;
                case "6":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Intermediate";
                    break;
                case "7":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Standard";
                    break;
                case "8":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Full Size";
                    break;
                case "9":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Luxury";
                    break;
                case "10":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Premium";
                    break;
                //case "11":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Mini Van";
                //    break;
                //case "12":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;12 passenger van";
                //    break;
                //case "13":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Moving van";
                //    break;
                //case "14":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;15 passenger van";
                //    break;
                //case "15":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Cargo van";
                //    break;
                //case "16":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;12 foot truck";
                //    break;
                //case "17":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;20 foot truck";
                //    break;
                //case "18":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;24 foot truck";
                //    break;
                //case "19":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;26 foot truck";
                //    break;
                //case "20":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Moped";
                //    break;
                //case "21":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Stretch";
                //    break;
                //case "22":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Regular";
                //    break;
                //case "23":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Unique";
                //    break;
                //case "24":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Exotic";
                //    break;
                //case "25":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Small/medium truck";
                //    break;
                //case "26":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Large truck";
                //    break;
                //case "27":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Small SUV";
                //    break;
                //case "28": 
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Medium SUV";
                //    break;
                //case "29":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Large SUV";
                //    break;
                //case "30": 
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Exotic SUV";
                //    break;
                //case "31": 
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Four wheel drive";
                //    break;
                case "32":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Specialty Car";
                    break;
                //case "33":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Mini elite";
                //    break;
                //case "34":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Economy elite";
                //    break;
                //case "35":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Compact elite";
                //    break;
                //case "36": 
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Intermediate elite";
                //    break;
                //case "37":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Standard elite";
                //    break;
                //case "38": 
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Fullsize elite";
                //    break;
                //case "39": 
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Premium elite";
                //    break;
                //case "40":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Luxury elite";
                //    break;
                //case "41":
                //    lblCarType.Text = CarSize;
                //    cbCarType.Checked = true;
                //    cbCarType.Text = @"&nbsp;Oversize";
                //    break;
                case "M2":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Minivan";
                    break;
                case "M3":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;SUV";
                    break;
                case "M4":
                    lblCarType.Text = CarSize;
                    cbCarType.Checked = true;
                    cbCarType.Text = @"&nbsp;Convertible";
                    break;
            }
        }
    }

    private void BindCarType()
    {
        VehcileListViewControl vehcilelistviewcontrol = (VehcileListViewControl)this.Parent.FindControl("VehcileListViewControl1");

        List<string> m_CarTypes = new List<string>();

        for (int i = 0; i < repCarType.Items.Count; i++)
        {
            DataListItem item = repCarType.Items[i];

            CheckBox cbCarType = (CheckBox)item.FindControl("cbCarType");
            LinkButton lbtnCarType = (LinkButton)item.FindControl("lbtnCarType");
            Label lblCarType = (Label)item.FindControl("lblCarType");

            if (cbCarType.Checked && !m_CarTypes.Contains(lblCarType.Text))
            {
                m_CarTypes.Add(lblCarType.Text);
            }
        }

        if (vehcilelistviewcontrol != null)
        {
            vehcilelistviewcontrol.CarTypes = m_CarTypes;
            Session["Flag"] = true;
            vehcilelistviewcontrol.BindHeadAndFoot();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindCarType();
    }

    protected void repCarType_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName.Trim().ToUpper() == "SELECT1".Trim().ToUpper())
        {
            Label lblCarTypeNew = (Label)e.Item.FindControl("lblCarType");

            for (int i = 0; i < repCarType.Items.Count; i++)
            {
                Label lblCarType = (Label)repCarType.Items[i].FindControl("lblCarType");
                CheckBox cbCarType = (CheckBox)repCarType.Items[i].FindControl("cbCarType");

                if (lblCarTypeNew.Text != lblCarType.Text)
                {
                    cbCarType.Checked = false;
                }
                else
                {
                    cbCarType.Checked = true;
                }
            }

            BindCarType();
        }

        if (e.CommandName.Trim().ToUpper() == "SELECT1".Trim().ToUpper())
        {
            BindCarType();
        }
    }

    protected void lbtnAll_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < repCarType.Items.Count; i++)
        {
            CheckBox cbCarType = (CheckBox)repCarType.Items[i].FindControl("cbCarType");
            cbCarType.Checked = true;

        }

        BindCarType();
    }


    protected void cbCarType_CheckedChanged(object sender, EventArgs e)
    {
        BindCarType();
    }
}