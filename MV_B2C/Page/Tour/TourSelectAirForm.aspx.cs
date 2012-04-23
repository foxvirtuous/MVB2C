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
using TERMS.Core.Product;
using Terms.Material.Service;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Profiles;
using TERMS.Business.Centers.ProductCenter.Search;
using System.Collections.Generic;
using System.Xml;

public partial class TourSelectAirForm : SalseBasePage
{

    private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(typeof(TourSelectAirForm));

    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.OnSearch();
        }
    }

    public string SelectTourCode
    {
        get
        {
            if (Request["TourCode"] != null)
                return Request["TourCode"].Trim().ToLower();
            else
                return string.Empty;
        }
    }

    public bool SelectPriceType
    {
        get
        {
            if (Request["PriceType"] != null)
                return Convert.ToBoolean(Request["PriceType"].Trim());
            else
                return true;
        }
    }

    private TourMaterial _tourmaterial = null;
    public TourMaterial SelectTourMaterial
    {
        get
        {
            if (_tourmaterial == null || ((TourProfile)_tourmaterial.Profile).Code.Trim().ToLower() != SelectTourCode)
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.Items.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.Items[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            _tourmaterial = (TourMaterial)tourMerchandise.Items[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return _tourmaterial;
        }
    }

    private TourProduct tourproduct = null;
    public TourProduct TourProduct
    {
        get
        {
            if (tourproduct == null || ((TourProfile)tourproduct.Profile).Code.Trim().ToLower() != SelectTourCode)
            {

                if (tourMerchandise != null && tourMerchandise.TourProductList != null && tourMerchandise.TourProductList.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.TourProductList.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.TourProductList[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            tourproduct = (TourProduct)tourMerchandise.TourProductList[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return tourproduct;
        }
    }

    private AirService m_airService;
    protected AirService AirService
    {
        get
        {
            return m_airService;

        }
        set
        {
            m_airService = value;
        }
    }

    public DateTime BeginDate
    {
        get
        {
            if (Request["BeginDate"] != null)
                return Convert.ToDateTime(Request["BeginDate"].ToString());
            else
                return DateTime.Now;
        }

    }

    protected string ReturnURL
    {
        get
        {
            if (Request.QueryString["ReturnURL"] != null)
            {
                return Request.QueryString["ReturnURL"];
            }
            else
            {
                return "TourMoreSearchResultForm.aspx";
            }
        }
    }

    public IList<TourXML> TourXml
    {
        get
        {
            return ReadXML();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Log
        this.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        TurboTT.Log.Core.TimeLog tlLoad = new TurboTT.Log.Core.TimeLog(PageUtility.TourLogRandomNumber.ToString() + "Load Tour Select Air From:");

        Header1.Path = "../../";

        if (!IsPostBack)
            tlLoad.Start();

        this.StatesControl1.PageCode = 2;
        if (Utility.IsLogin)
        {
            
            this.divSignIn.Visible = false;
            this.P_table.Visible = true;
        }
        else
        {
            UserLoginControl1.NextUrl = "~/Page/Tour/TourTravelerInfoForm.aspx";
            UserLoginControl1.ReturnUrl = "~/Page/Tour/TourSelectAirForm.aspx";

            this.divSignIn.Visible = true;
            this.P_table.Visible = false;
        }

        UserLoginControl1.loginClick = DoContinueProcess;
        UserLoginControl1.CheckPassNumber = Check;
        if (!IsSearchConditionNull)
        {
            //添加判断Utility.Transaction.CurrentTransactionObject.Items 是否存在与个数是否大于0的判断 Add zyl 2009-8-18
            if (Utility.Transaction.CurrentTransactionObject != null && Utility.Transaction.CurrentTransactionObject.Items != null && Utility.Transaction.CurrentTransactionObject.Items.Count > 0)
            {
                if (((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).InsuranceMaterial == null)
                    PriceInfoControl1.IsTourInsurance = false;
                else
                    PriceInfoControl1.IsTourInsurance = true;
            }
            else
            {
                PriceInfoControl1.IsTourInsurance = false;
            }
        }
        try
        {
            if (!IsPostBack)
            {
               Initial();
            }

            //SearchToBinder();
        }
        catch (Exception ex)
        {
            string str = ex.Message;
        }

        if (!IsPostBack)
        {
            //log
            tlLoad.Stop();
            PageUtility.TourSearchingTimeLog.Info(tlLoad);
        }

    }

    /// Init page
    /// </summary>
    private void Initial()
    {
        TourMainInfoControl1.IsFeatures = true;
        SetIsdisplayRemarks();
    }

    private void SetIsdisplayRemarks()
    {
        TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
        string ShowArea = string.Empty;
        foreach (TourXML tx in TourXml)
        {
            for (int i = 0; i < tx.Citys.Count; i++)
            {
                if (tourProfile.StartCity.Code.Equals(tx.Citys[i]))
                {
                    ShowArea = tx.ShowArea;
                    break;
                }
            }
        }

        switch (ShowArea.ToUpper())
        { 
            case "ASIA":
                tbAsia.Visible = true;
                break;
            case "EAST COAST":
                tbEastCoast.Visible = true;
                break;
            case "WEST COAST":
                tbWestCoast.Visible = true;
                break;
            case "HAWAII":
                tbHawaii.Visible = true;
                break;
            case "ORLANDO":
                tbOrlando.Visible = true;
                break;
            default:
                tbAsia.Visible = true;
                break;

        }
        
    }

    protected void btn_button_Click(object sender, EventArgs e)
    {
        if (this.PriceInfoControl1.CheckConditions())
        {
            DoContinueProcess();
        }
        else
        {
            string errString = string.Empty;
            foreach (string str in PriceInfoControl1.ErrRooms)
            {
                if (errString == string.Empty)
                    errString += str;
                else
                    errString += " and " + str;
            }
             string warningString = string.Empty;
             if (PriceInfoControl1.ErrRooms.Count == 1)
             {
                 warningString = "The passenger number of " + errString + " is invalid";
             }
             else
             {
                 warningString = "The passenger number of " + errString + " are invalid";
             }
             Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + warningString + "');</script>");
        }
    }

    public void DoContinueProcess()
    {
        if (PriceInfoControl1.ChkTourInsurance)
        {

            ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).IsInsurance = true;
            InsuranceOrderItem insuranceOrderItem = new InsuranceOrderItem(null);

            insuranceOrderItem.InsuranceOrderName = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).InsuranceMaterial.InsuranceName;
            insuranceOrderItem.TotalPremiumAmount = Convert.ToDecimal(((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).InsuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount * PriceInfoControl1.TotalPassengers);
            for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
            {
                if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                    Utility.Transaction.CurrentTransactionObject.Items.Remove(Utility.Transaction.CurrentTransactionObject.Items[i]);
            }

            Utility.Transaction.CurrentTransactionObject.AddItem(insuranceOrderItem);

        }
        else
        {
            ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).IsInsurance = false;
        }

        PriceInfoControl1.AddMarkup();

        TourProfile tourProfile = (TourProfile)((TourMaterial)SelectTourMaterial).Profile;
        
        ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).AdultNumber = PriceInfoControl1.AdultNumber;
        ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildNumber = PriceInfoControl1.ChildNumber;
        ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildWithOutNumber = PriceInfoControl1.ChildWithOutNumber;

        #region ADD NEW
        List<TourOrderFareType> FareTypeList = new List<TourOrderFareType>();
        #region Land 部分价格类型处理
        TourOrderFareType landType = new TourOrderFareType();
        DateTime date = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).BeginDate;
        decimal totalPrice = 0.0m;

        

        List<TourRoom> tourRooms = this.PriceInfoControl1.GetTourRooms(tourProfile, date);
        for (int i = 0; i < tourRooms.Count; i++)
        {
            totalPrice += tourRooms[i].UnitPrice * tourRooms[i].Quantity;
            landType.AddTourRoom(tourRooms[i]);
        }
        landType.Price = totalPrice;
        landType.Quantity = 1;
        landType.Type = TourFareType.LAND;
        FareTypeList.Add(landType);
        #endregion

        decimal diffFare = 0.0m;
        if (((TourSearchCondition)this.Transaction.CurrentSearchConditions).IsLandOnly)
        {
        }
        else
        {
            #region 机票addOn 部分价格类型处理
            if (diffFare > 0)
            {
                TourOrderFareType addOnType = new TourOrderFareType();

                addOnType.Price = diffFare;
                addOnType.Quantity = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).AdultNumber + ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildNumber;
                addOnType.Type = TourFareType.ADDON;
                totalPrice += addOnType.Quantity * addOnType.Price;
                FareTypeList.Add(addOnType);
            }
            #endregion
        }
        ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).TotalPrice = totalPrice;
        ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).FareTypeList = FareTypeList;
        #endregion
        if (this.chkConditions.Checked)
        {
            if (!PriceInfoControl1.ChkTourInsurance)
            {
                bool Flag = false;

                if (System.Configuration.ConfigurationManager.AppSettings["TourBookingInsurance"] != null)
                    Flag = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["TourBookingInsurance"]);

                if (Flag)
                {
                    string citycode = ((Terms.Product.Business.MVTourProfile)((TourMaterial)SelectTourMaterial).Profile).StartCity.Code;

                    if (TourCityIsRegion(citycode))
                    {
                        AddInsurance();
                    }
                }
            }

            Response.Redirect("~/Page/Tour/TourTravelerInfoForm.aspx?ReturnURL=" + ReturnURL + "&ConditionID=" + Request.Params["ConditionID"] + "&TourCode=" + SelectTourCode);
        }
        else
        {
            //错误
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please read Terms & Conditions, And cancels elects');</script>");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "alt", "if(document.getElementById('clickLink')!= null){document.getElementById('clickLink').click();}", true);
            return;
        }
        
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Page/Tour/TourSelectTourForm.aspx?ReturnURL=" + ReturnURL + "&ConditionID=" + Request.Params["ConditionID"] + "&TourCode=" + SelectTourCode);
    }

    private List<TourXML> ReadXML()
    {
        XmlDocument m_XmlDoc = new XmlDocument();
        m_XmlDoc.Load(Server.MapPath(".") + "\\TourExplainCityNameXML.xml");

        XmlNodeList NodTours = m_XmlDoc.SelectNodes("TourInfos/Tour");
        List<TourXML> Tours = new List<TourXML>();
        for (int index = 0; index < NodTours.Count; index++)
        {
            TourXML t = new TourXML();

            XmlNodeList citysNodes = NodTours[index].SelectNodes("CityList/city");

            for (int i = 0; i < citysNodes.Count; i++)
            {
                t.Citys.Add(citysNodes[i].Attributes["code"].Value);
            }

            XmlNode ShowAreaNode = NodTours[index].SelectSingleNode("ShowArea");
            t.ShowArea = ShowAreaNode.InnerText;

            Tours.Add(t);
        }

        return Tours;

    }

    private void Check()
    {
        if (!PriceInfoControl1.CheckConditions())
        {
            string errString = string.Empty;
            foreach (string str in PriceInfoControl1.ErrRooms)
            {
                if (errString == string.Empty)
                    errString += str;
                else
                    errString += " and " + str;
            }
            txtErr.Text = errString;
        }
        else
        {
            this.chkCheck.Checked = true;
        }
    }

    private void AddInsurance()
    {
        Terms.Sales.Business.InsuranceSearchCondition Condition = new Terms.Sales.Business.InsuranceSearchCondition();

        Condition.InsuranceType = TERMS.Common.InsuranceType.Tour;

        if (SelectPriceType)
            Condition.DepartureDate = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).BeginDate.AddDays(1);
        else
            Condition.DepartureDate = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).BeginDate;

        Condition.ReturnDate = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).EndDate;

        Condition.TotalTripCost = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).TotalPrice;

        Condition.TravelerCount = PriceInfoControl1.AdultNumber + PriceInfoControl1.ChildNumber + PriceInfoControl1.ChildWithOutNumber;

        Condition.Adults = PriceInfoControl1.AdultNumber;

        Condition.Childs = PriceInfoControl1.ChildNumber + PriceInfoControl1.ChildWithOutNumber;

        InsuranceMaterial insuranceMaterial = this.OnSearchInsurance(Condition);

        ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).IsInsurance = true;

        InsuranceOrderItem insuranceOrderItem = new InsuranceOrderItem(insuranceMaterial, null);

        insuranceOrderItem.InsuranceType = TERMS.Common.InsuranceType.Tour;
        insuranceOrderItem.TotalTripCost = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).TotalPrice;

        insuranceOrderItem.InsuranceOrderName = insuranceMaterial.InsuranceName;
        insuranceOrderItem.InsuranceMarkUp = Convert.ToDecimal(insuranceMaterial.PolicyQuote.PolicyInformation.Premium.Markup);
        insuranceOrderItem.TotalPremiumAmount = Convert.ToDecimal(insuranceMaterial.PolicyQuote.PolicyInformation.Premium.TotalPremiumAmount);

        for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
        {
            if (Utility.Transaction.CurrentTransactionObject.Items[i] is InsuranceOrderItem)
                Utility.Transaction.CurrentTransactionObject.Items.Remove(Utility.Transaction.CurrentTransactionObject.Items[i]);
        }

        Utility.Transaction.CurrentTransactionObject.AddItem(insuranceOrderItem);
    }

    private bool TourCityIsRegion(string city)
    {
        bool result = false;

        string BookingTourCode = string.Empty;

        if (System.Configuration.ConfigurationManager.AppSettings["BookingInsuranceTourCode"] != null)
            BookingTourCode = System.Configuration.ConfigurationManager.AppSettings["BookingInsuranceTourCode"];

        List<string> tourcodes = new List<string>();

        tourcodes.AddRange(BookingTourCode.Split(new char[] { ',' }));

        List<TourInfoXML> tous = ReadXMLInfo();

        for (int i = 0; i < tourcodes.Count; i++)
        {
            string region = tourcodes[i];

            for (int j = 0; j < tous.Count; j++)
            {
                if (region.Trim().ToUpper() == tous[j].TourArea.Trim().ToUpper())
                {
                    if (tous[j].Citys.Contains(city))
                    {
                        result = true;
                        break;
                    }
                }
            }

            if (result)
            {
                break;
            }
        }

        return result;
    }

    private List<TourInfoXML> ReadXMLInfo()
    {
        XmlDocument m_XmlDoc = new XmlDocument();

        m_XmlDoc.Load(Server.MapPath("~") + "\\TourName.xml");

        XmlNodeList NodTours = m_XmlDoc.SelectNodes("TourInfos/Tour");
        List<TourInfoXML> Tours = new List<TourInfoXML>();

        for (int index = 0; index < NodTours.Count; index++)
        {
            TourInfoXML t = new TourInfoXML();

            XmlNode NameNode = NodTours[index].SelectSingleNode("Name");
            t.Name = NameNode.InnerText;

            XmlNode CNNameNode = NodTours[index].SelectSingleNode("Name_CN");
            t.CNName = CNNameNode.InnerText;

            XmlNodeList citysNodes = NodTours[index].SelectNodes("CityList/city");

            for (int i = 0; i < citysNodes.Count; i++)
            {
                t.Citys.Add(citysNodes[i].Attributes["code"].Value);
            }

            XmlNode ImageNode = NodTours[index].SelectSingleNode("Image");
            t.Image = ImageNode.InnerText;

            XmlNode TourAreaNode = NodTours[index].SelectSingleNode("TourArea");
            t.TourArea = TourAreaNode.InnerText;

            Tours.Add(t);
        }

        return Tours;

    }

    public class TourInfoXML
    {
        private string _name;
        private string _nameCN;
        private string _image;
        private List<string> _citys = new List<string>();
        private string _tourArea;

        public string CNName
        {
            set { _nameCN = value; }
            get { return _nameCN; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }

        public string Image
        {
            set { _image = value; }
            get { return _image; }
        }

        public List<string> Citys
        {
            set { _citys = value; }
            get { return _citys; }
        }

        public string TourArea
        {
            set { _tourArea = value; }
            get { return _tourArea; }
        }
    }
}
public class TourXML
{
    private List<string> _citys = new List<string>();
    private string _showArea;

    public List<string> Citys
    {
        set { _citys = value; }
        get { return _citys; }
    }

    public string ShowArea
    {
        set { _showArea = value; }
        get { return _showArea; }
    }
}