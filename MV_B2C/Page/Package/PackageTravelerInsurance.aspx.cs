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
using Spring.Web.UI;
using log4net;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class PackageTravelerInsurance : SalseBasePage
{
    public string CssPath
    {
        get
        {
            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                return "~/css/style2.css";
            }

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
            {
                return "/css/style2.css";
            }

            return "~/css/style2.css";
        }
    }

    public PackageTravelerInsurance()
    {
        this.InitializeControls += new EventHandler(PackageTravelerInsurance_InitializeControls);
    }

    protected void btnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        TravelerInfoOfInsurance1.PaddingPassengerInfo();
        this.Response.Redirect(SecureUrlSuffix + "Page/Hotel/HotelCreditForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
    }

    void PackageTravelerInsurance_InitializeControls(object sender, EventArgs e)
    {
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);
        if (!IsPostBack)
        {
            Navigation1.PageCode = 2;
        }
    }
    protected void btnSubmit_Click1(object sender, ImageClickEventArgs e)
    {
        TravelerInfoOfInsurance1.PaddingPassengerInfo();
        //记录Enter Passenger信息
        OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.EnterTravels, this);
        this.Response.Redirect(SecureUrlSuffix + "Page/Hotel/HotelCreditForm.aspx" + "?ConditionID=" + Request.Params["ConditionID"]);
    }
}
