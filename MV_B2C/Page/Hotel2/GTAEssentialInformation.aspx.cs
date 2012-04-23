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
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;
using Terms.Common.Service;
using Spring.Context.Support;
using System.Collections.Generic;


public partial class GTAEssentialInformation : SalseBasePage
{
    private List<MVHotel> m_HotelMaterial;

    public List<MVHotel> HotelMaterial
    {
        set
        {
            if (value is List<MVHotel>)
            {
                m_HotelMaterial = value;
                Session["m_HotelMaterial"] = value;
            }
        }
        get
        {
            m_HotelMaterial = (List<MVHotel>)Session["m_HotelMaterial"];
            if (m_HotelMaterial == null)
            {
                m_HotelMaterial = new List<MVHotel>();
            }

            return m_HotelMaterial;
        }
    }

    protected string HotelCode
    {
        get
        {
            return (string)this.Request["hotelcode"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HotelMerchandise m_SaleMerchandise = (HotelMerchandise)this.OnSearch();

            if (m_SaleMerchandise.Items.Count > 0)
            {
                List<MVHotel> hotelMaterialNew = new List<MVHotel>();

                for (int i = 0; i < m_SaleMerchandise.Items.Count; i++)
                {
                    hotelMaterialNew.Add((MVHotel)m_SaleMerchandise.Items[i]);
                }

                HotelMaterial = hotelMaterialNew;
            }
            else
            {
                this.Response.Redirect("../../Index.aspx");
            }

            bindData();
        }
    }

    private void bindData()
    {
        if (HotelMaterial != null && HotelMaterial.Count > 0)
        {
            for (int i = 0; i < HotelMaterial.Count; i++)
            {
                MVHotel hotel = (MVHotel)HotelMaterial[i];
                if (hotel.HotelInformation.HotelCode.Trim().ToUpper() == HotelCode.Trim().ToUpper())
                {
                    lbInformation.Text = hotel.HotelInformation.Essential;
                    lbDATE.Text = "Valid from " + hotel.HotelInformation.FromDateField.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " to " + hotel.HotelInformation.ToDateField.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                }
            }
        }

    }
}