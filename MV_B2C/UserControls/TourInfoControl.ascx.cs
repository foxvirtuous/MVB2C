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
using TERMS.Business.Centers.SalesCenter;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

using System.Xml;
using Terms.Sales.Business;
using Terms.Common.Service;
using Terms.Product.Service;
using TERMS.Business.Centers.ProductCenter.Profiles;
using System.Globalization;

public partial class TourInfoControl : SalesBaseUserControl
{
    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.TourOnSearch();
        }             
    }

    private AreaMasterService _AreaMasterService;

    public AreaMasterService AreaMasterService
    {
        set
        {
            this._AreaMasterService = value;
        }
    }

    public IList<TourXML> TourXml
    {
        set
        {
            Page.Session["TourXml"] = value;
        }
        get
        {
            if (Page.Session["TourXml"] == null)
                return ReadXML();
            return (IList<TourXML>)Page.Session["TourXml"];
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (!IsPostBack)
        {
            //Log
            TurboTT.Log.Core.TimeLog tlLoad = new TurboTT.Log.Core.TimeLog(PageUtility.TourLogRandomNumber.ToString() + "Load Tour Index From:");
            tlLoad.Start();

            TourXml = ReadXML();
            this.dlTours.DataSource = CheckTourType();
            this.dlTours.DataBind();
            CheckTourInfo();//检查区域是否有Tour信息;
            Utility.SetTourLandOnlyCitys = ReadCityXML();

            //log
            tlLoad.Stop();
            PageUtility.TourSearchingTimeLog.Info(tlLoad);      
        }
        
        string TourCode = Request.QueryString["Code"];

        if (!string.IsNullOrEmpty(TourCode))
            RedirectToTourDetailForm(TourCode);

        string AreaName = Request.QueryString["Area"];

        if (!string.IsNullOrEmpty(AreaName))
            RedirectToTourMoreForm(AreaName);            
    }

    private void CheckTourInfo()
    {
        DataList tourList = (DataList)this.dlTours;
        foreach (DataListItem item in tourList.Items)
        {
            DataList tours = (DataList)item.FindControl("dlTourDetail");
            Label lblComm = (Label)item.FindControl("lblComingSoon");
            HtmlImage img = (HtmlImage)item.FindControl("img");
            LinkButton lkbMore = (LinkButton)item.FindControl("lkbMore");
            HtmlTableCell trTour = (HtmlTableCell)item.FindControl("trTour");
            if (tours.Items.Count == 0)
            {
                tours.Visible = false;
                lblComm.Visible = true;
                img.Visible = false;
                lkbMore.Visible = false;
                trTour.VAlign = "middle";
            }
        }
    }

    private List<MVTour> CheckTourType()
    {
        List<MVTour> TourInfos = new List<MVTour>();

        //XML配置Tour类型
        for (int i = 0; i < TourXml.Count; i++)
        {
            MVTour tour = new MVTour();
            tour.Name = TourXml[i].Name;
            tour.CNName = TourXml[i].CNName;
            tour.Image = TourXml[i].Image;
            tour.Code = string.Empty;
            tour.TourArea = TourXml[i].TourArea;
            //每种Tour下所包括的城市
            foreach (string city in TourXml[i].Citys)
            {
                try
                {
                    for (int index = 0; index < tourMerchandise.Items.Count; index++)
                    {
                        if (((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).StartCity.Code.Equals(city) &&
                            ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).EndCity != null &&
                            ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).EndCity.Country != null)
                        {
                            if (ExceptionViewCode(((TourProfile)((TourMaterial)tourMerchandise.Items[index]).Profile).Code))
                            {
                                tour.Tours.Add((TourMaterial)tourMerchandise.Items[index]);
                            }
                        }
                    }
                }
                catch
                {
                    MVMerchandisePool.ResetTour();
                    Response.Redirect("~/TourIndex.aspx?tab=T");
                }
            }
            //tour.Tours.Sort();
            tour.Tours.Sort(delegate(TourMaterial t1, TourMaterial t2) { return ((Terms.Product.Business.MVTourProfile)t1.Profile).StartFromMinFare.CompareTo(((Terms.Product.Business.MVTourProfile)t2.Profile).StartFromMinFare); });
            if (tour.Tours.Count > 3)
                tour.Tours.RemoveRange(3, tour.Tours.Count - 3);
            TourInfos.Add(tour);
        }

        return TourInfos;
    }

    /// <summary>
    /// 获取Ｔｏｕｒ配置文件的信息


    /// </summary>
    /// <returns>Ｔｏｕｒ信息的集合</returns>
    private List<TourXML> ReadXML()
    {
        XmlDocument m_XmlDoc = new XmlDocument();
        //if (UserCulture.Name.Contains("zh-CN"))
        //{
        //    m_XmlDoc.Load(Server.MapPath(".") + "\\TourName_zh-CN.xml");
        //}
        //else
        //{
            m_XmlDoc.Load(Server.MapPath(".") + "\\TourName.xml");
        //}

        

        XmlNodeList NodTours = m_XmlDoc.SelectNodes("TourInfos/Tour");
        List<TourXML> Tours = new List<TourXML>();

        for (int index = 0; index < NodTours.Count; index++)
        {
            TourXML t = new TourXML();

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

    /// <summary>
    /// 读取设定的City信息
    /// </summary>
    /// <returns></returns>
    private List<string> ReadCityXML()
    {
        XmlDocument m_XmlDoc = new XmlDocument();
        m_XmlDoc.Load(Server.MapPath(".") + "\\TourLandOnlyDisPlay.xml");

        XmlNodeList NodCountrys = m_XmlDoc.SelectNodes("TourCountry/Country");
        List<string> Countrys = new List<string>();
        for (int index = 0; index < NodCountrys.Count; index++)
        {
            Countrys.Add(NodCountrys[index].Attributes["code"].Value);
        }

        return Countrys;

    }

    //接收Tour Xml信息的类
    public class TourXML
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

    protected void dlTourDetail_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            TourMaterial tourMaterial = (TourMaterial)(((System.Object)(((System.Web.UI.WebControls.DataListItem)(e.Item)).DataItem)));
            LinkButton hyLink = (LinkButton)e.Item.FindControl("hlLink");
            if (UserCulture.Name.Contains("en-US"))
            {
                if (hyLink.Text.Length > 30)
                {
                    hyLink.ToolTip = hyLink.Text;

                    hyLink.Text = hyLink.Text.Substring(0, 30) + "...";
                }
                else
                {
                    hyLink.Text = hyLink.Text + Space(33 - hyLink.Text.Length);
                }
            }
            else
            {
                if (hyLink.Text.Length > 15)
                {
                    hyLink.ToolTip = hyLink.Text;

                    hyLink.Text = hyLink.Text.Substring(0, 15) + "...";
                }
                else
                {
                    hyLink.Text = hyLink.Text + Space(18 - hyLink.Text.Length);
                }
            }
            Label lblPrice = (Label)e.Item.FindControl("lblPrice");

            lblPrice.Text = "$" + ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartFromMinFare.ToString("#,###");
        }
    }

    /// <summary>
    /// 产生空格的函数


    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    private string Space(int number)
    {
        string space = string.Empty;
        for (int i = 0; i < number; i++)
        {
            space += " ";
        }
        return space;
    }

    protected void dlTours_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            Label lblName = (Label)e.Item.FindControl("lblName");
            Label lblNameCN = (Label)e.Item.FindControl("lblNameCN");
            Image img = (Image)e.Item.FindControl("imgTour");
            img.ImageUrl = "~\\images\\" + img.ImageUrl.ToString();
            if (UserCulture.Name.Contains("zh-CN"))
            {
                lblName.Visible = false;
                lblNameCN.Visible = true;
            }
            else
            {
                lblName.Visible = true;
                lblNameCN.Visible = false;
            }
        }
    }

    protected void dlTourDetail_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.CommandName == "Select")
            {
                //log begin 20090312 Leon
                PageUtility.TourSearchingTimeLog.Info("\r\n");

                if (!Utility.IsLogin)
                    PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >====================Not Login========================");
                else
                    PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >==========================Login========================");

                PageUtility.TourSearchingTimeLog.Info(PageUtility.TourLogRandomNumber.ToString() + " >Tour Searching(3) Begin at: " + System.DateTime.Now);

                string tourcode = string.Empty;
                string Code = ((Label)e.Item.FindControl("lblTourCode")).Text;
                Label txtPrice = (Label)e.Item.FindControl("lblPrice");
                decimal Price = Convert.ToDecimal(txtPrice.Text.Substring(1, txtPrice.Text.Length - 1));
                string TourArea = ((Label)((DataListItem)((HtmlTableCell)((DataList)e.Item.Parent).Parent).Parent).FindControl("lblTourArea")).Text;
                for (int i = 0; i < tourMerchandise.Items.Count; i++)
                {
                    if ((((TourMaterial)tourMerchandise.Items[i]).Profile.Code.ToString().Equals(Code)) &&
                        (((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).StartFromMinFare == Price))
                    {
                        TourSearchCondition tourSearchCondition = new TourSearchCondition();
                        tourSearchCondition.Region = TourArea;
                        tourSearchCondition.Counrty = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).EndCity.Country.Code;
                        tourSearchCondition.City = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).EndCity.Code;
                        tourSearchCondition.DeptCity = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).DefaultDepartureCity.Code;
                        tourSearchCondition.IsLandOnly = true;
                        tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                        tourSearchCondition.TravelDaysFrom = 1;
                        tourSearchCondition.TravelDaysTo = 800;
                        tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;                        
                        Utility.Transaction.IntKey = tourSearchCondition.GetHashCode();
                        Utility.Transaction.CurrentSearchConditions = tourSearchCondition;
                        Utility.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                        tourcode = Code;
                        break;
                    }
                }
                Utility.IsTourMain = true;
                Utility.IsTourMore = false;
                //记录直接Select tour事件
                OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SelectIndexTour, this);
                List<string> lTousrCode = new List<string>();
                lTousrCode.Add("11MVCN-A");
                lTousrCode.Add("11MVCN-B");
                lTousrCode.Add("11MVCN-C");
                lTousrCode.Add("11MVCN-D");

                if (lTousrCode.Contains(tourcode))
                {
                    UserCulture = new CultureInfo("zh-CN");
                }
                Response.Redirect("~/Page/Tour/NewTourSelectTourForm.aspx?ReturnURL=TourIndex.aspx" + "&ConditionID=" + this.Transaction.IntKey.ToString() + "&PriceType=L&TourCode=" + tourcode);
            }
        }
    }

    //add by Leon
    private void RedirectToTourDetailForm(string tourCode)
    {
        TourMaterial tourMaterial = null;

        //在绑定的数据中找到这个TourCode所在的DataListItem
        if (tourMerchandise.Items != null)
        {
            foreach (TourMaterial tm in tourMerchandise.Items)
            {
                 if (tm.Profile.Code.ToUpper().Trim() == tourCode.ToUpper().Trim())
                     tourMaterial = tm;

            }
        }

        if (tourMaterial != null)
        {
            string Code = tourMaterial.Profile.Code;
            decimal Price = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartFromLandOnlyFare;
            string cityCode = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartCity.Code;
            string countryCode = ((Terms.Product.Business.MVTourProfile)tourMaterial.Profile).StartCity.Country.Code;
            string TourArea = string.Empty;
            if (_AreaMasterService.FindFilterAreaMaster(cityCode, countryCode).Count > 0)
                TourArea = _AreaMasterService.FindFilterAreaMaster(cityCode, countryCode)[0];
            else
                TourArea = "area";
            for (int i = 0; i < tourMerchandise.Items.Count; i++)
            {
                if ((((TourMaterial)tourMerchandise.Items[i]).Profile.Code.ToString().Equals(Code)) &&
                    (((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).StartFromLandOnlyFare == Price))
                {
                    TourSearchCondition tourSearchCondition = new TourSearchCondition();
                    tourSearchCondition.Region = TourArea;
                    tourSearchCondition.Counrty = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).EndCity.Country.Code;
                    tourSearchCondition.City = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).EndCity.Code;
                    tourSearchCondition.DeptCity = ((Terms.Product.Business.MVTourProfile)((TourMaterial)tourMerchandise.Items[i]).Profile).DefaultDepartureCity.Code;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    break;
                }
            }
            Utility.IsTourMain = true;
            Utility.IsTourMore = false;
            List<string> lTousrCode = new List<string>();
            lTousrCode.Add("11MVCN-A");
            lTousrCode.Add("11MVCN-B");
            lTousrCode.Add("11MVCN-C");
            lTousrCode.Add("11MVCN-D");

            if (lTousrCode.Contains(Code))
            {
                UserCulture = new CultureInfo("zh-CN");
            }
            Response.Redirect("~/Page/Tour/NewTourSelectTourForm.aspx?ReturnURL=TourIndex.aspx" + "&ConditionID=" + this.Transaction.IntKey.ToString() + "&TourCode=" + Code );
        }
    }

    protected void dlTours_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            if (e.CommandName == "More")
            {
                DataList dlTour = (DataList)e.Item.FindControl("dlTourDetail");
                if (dlTour.Items.Count > 0)
                {
                    int index = e.Item.ItemIndex;
                    List<string> citys = new List<string>();
                    string TourArea = ((Label)e.Item.FindControl("lblTourArea")).Text;
                    for (int i = 0; i < TourXml.Count; i++)
                    {
                        if (i == index)
                        {
                            foreach (string city in TourXml[i].Citys)
                            {
                                citys.Add(city);
                            }
                        }
                    }
                    Utility.TourCitys = citys;
                    Utility.IsTourMain = true;
                    Utility.IsTourMore = true;

                    Label lblCountry = (Label)dlTour.Items[0].FindControl("lblCountry");
                    Label lblCity = (Label)dlTour.Items[0].FindControl("lblCity");
                    Label lblDepCity = (Label)dlTour.Items[0].FindControl("lblDepCity");
                    Label lblTourArea = (Label)e.Item.FindControl("lblName");
                    Label lblTourAreaCN = (Label)e.Item.FindControl("lblNameCN");

                    TourSearchCondition tourSearchCondition = new TourSearchCondition();
                    tourSearchCondition.Region = TourArea;
                    tourSearchCondition.Counrty = lblCountry.Text;
                    tourSearchCondition.CityList = citys;
                    tourSearchCondition.City = lblCity.Text;
                    tourSearchCondition.DeptCity = lblDepCity.Text;
                    tourSearchCondition.IsLandOnly = true;
                    tourSearchCondition.PriceType = TERMS.Common.TourPriceType.All;
                    tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
                    tourSearchCondition.TravelDaysFrom = 1;
                    tourSearchCondition.TravelDaysTo = 800;
                    this.Transaction.IntKey = tourSearchCondition.GetHashCode();
                    this.Transaction.CurrentSearchConditions = tourSearchCondition;
                    this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
                    this.Session["IsDisplay2008Area"] = Server.UrlDecode(lblTourArea.Text);
                    this.Session["IsDisplay2008AreaCN"] = Server.UrlDecode(lblTourAreaCN.Text);
                    //记录Search More事件
                    OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchMoreTour, this);
                    this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode(lblTourArea.Text) + "&ConditionID=" + Utility.Transaction.IntKey.ToString() + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm");
                }

            }
        }
    }

    private void RedirectToTourMoreForm(string areaName)
    {
        DataListItem tagetDataListItem = null;

        //在绑定的数据中找到这个TourCode所在的DataListItem
        if (dlTours.Items != null)
        {
            foreach (DataListItem dliTours in dlTours.Items)
            {
                string TourArea = ((Label)dliTours.FindControl("lblName")).Text;

                if (TourArea.ToUpper().Trim() == areaName.ToUpper().Trim())
                    tagetDataListItem = dliTours;
            }
        }

        if (tagetDataListItem != null)
        {
            List<string> citys = new List<string>();

            for (int i = 0; i < TourXml.Count; i++)
                if (TourXml[i].Name.ToUpper().Trim() == areaName.ToUpper().Trim())
                    foreach (string city in TourXml[i].Citys)
                        citys.Add(city);

            if (citys.Count == 0) return;

            Utility.TourCitys = citys;
            Utility.IsTourMain = true;
            Utility.IsTourMore = true;

            DataList dlTourDetail = (DataList)tagetDataListItem.FindControl("dlTourDetail");
            Label lblCountry = (Label)dlTourDetail.Items[0].FindControl("lblCountry");
            Label lblCity = (Label)dlTourDetail.Items[0].FindControl("lblCity");
            Label lblDepCity = (Label)dlTourDetail.Items[0].FindControl("lblDepCity");
            Label lblTourArea = (Label)tagetDataListItem.FindControl("lblName");

            TourSearchCondition tourSearchCondition = new TourSearchCondition();
            tourSearchCondition.Region = areaName;
            tourSearchCondition.Counrty = lblCountry.Text;
            tourSearchCondition.CityList = citys;
            tourSearchCondition.City = lblCity.Text;
            tourSearchCondition.DeptCity = lblDepCity.Text;
            tourSearchCondition.IsLandOnly = true;

            tourSearchCondition.TravelBeginDate = DateTime.Now.Date.AddDays(7);
            tourSearchCondition.TravelDaysFrom = 1;
            tourSearchCondition.TravelDaysTo = 800;
            this.Transaction.IntKey = tourSearchCondition.GetHashCode();
            this.Transaction.CurrentSearchConditions = tourSearchCondition;
            this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
            this.Session["IsDisplay2008Area"] = Server.UrlDecode(lblTourArea.Text);
            if (Request["Preference"] != null)
                this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode(lblTourArea.Text) + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString() + "&Preference=" + Request["Preference"]);
            else
            this.Response.Redirect("~/Page/Common/Searching1.aspx?TourArea=" + Server.UrlEncode(lblTourArea.Text) + "&Type=More&target=~/Page/Tour/NewTourMoreSearchResultForm" + "&ConditionID=" + this.Transaction.IntKey.ToString());
        }

    }

    private bool ExceptionViewCode(string tourcode)
    {
        bool flag = true;

        string filePath = string.Empty;

        string codes = string.Empty;

        filePath = @"/Config/TourExceptionViewCode.xml";

        if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + filePath))
        {
            DataSet ds = new DataSet();

            ds.ReadXml(System.AppDomain.CurrentDomain.BaseDirectory + filePath);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null)
            {
                if (UserCulture.Name.Contains("zh-CN"))
                {
                    codes = ds.Tables[0].Rows[0]["CN"].ToString();
                }
                else
                {
                    codes = ds.Tables[0].Rows[0]["EN"].ToString();
                }

                if (codes.Contains(tourcode.Trim()))
                {
                    flag = false;
                }
            }
        }

        return flag;
    }
}
