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
using TERMS.Business.Centers.ProductCenter.Search;
using TERMS.Common.Search;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;
using Terms.Material.Service;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Service;

public partial class SearchTest : SalseBasePage
{
    private SaleOrderService m_SaleOrderService;

    protected SaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TermsCalendar1.Path = "../../";


            dllSightSeeisngCategorys.DataSource = new HotelGTAService().GetSightSeeisngCategorys();
            dllSightSeeisngCategorys.DataTextField = "Name";
            dllSightSeeisngCategorys.DataValueField = "Code";
            dllSightSeeisngCategorys.DataBind();

            ListItem item = new ListItem("-All-", "");
            dllSightSeeisngCategorys.Items.Insert(0, item);

            chSightSeeingType.DataSource = new HotelGTAService().GetSightSeeingTypes();
            chSightSeeingType.DataTextField = "Name";
            chSightSeeingType.DataValueField = "Code";
            chSightSeeingType.DataBind();

            dllLanguages.DataSource = new HotelGTAService().GetLanguages();
            dllLanguages.DataTextField = "Name";
            dllLanguages.DataValueField = "Code";
            dllLanguages.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SightSeeingSearchCondition SearchCondition = new SightSeeingSearchCondition();

        SearchCondition.Adults = Convert.ToInt32(dllAdults.SelectedValue);
        SearchCondition.CategoryCode = dllSightSeeisngCategorys.SelectedValue;

        int iChildren = Convert.ToInt32(dllChildren.SelectedValue);

        List<int> ages = new List<int>();

        for (int i = 0; i < iChildren; i++)
        {
            ages.Add(2);
        }
        SearchCondition.ChildrenAges = ages.ToArray();

        if (dllCity.SelectedValue == "YXU")
        {
            SearchCondition.DestinationCode = "LON";
        }
        else
        {
            SearchCondition.DestinationCode = dllCity.SelectedValue;
        }
        SearchCondition.DestinationType = "city";
        SearchCondition.TourDate = Convert.ToDateTime(TermsCalendar1.CDate);
        List<string> TypeCodes = new List<string>();

        for (int i = 0; i < chSightSeeingType.Items.Count; i++)
        {
            if (chSightSeeingType.Items[i].Selected)
            {
                TypeCodes.Add(chSightSeeingType.Items[i].Value);
            }
        }

        SearchCondition.TypeCodes = TypeCodes.ToArray();

        SearchCondition.Currency = "USD";
        SearchCondition.Country = dllCountry.SelectedValue;

        SightSeeingProductSearcher Searcher = new SightSeeingProductSearcher();
        IList<SightSeeingProduct> Products = Searcher.Search(SearchCondition);

        if (Products != null && Products.Count > 0 && ((TERMS.Core.Product.ComponentGroup)Products[0]).Items.Count > 0)
        {
            List<Terms.Contract.Business_0407.GTASightSeeingMaterial> SightSeeingMaterials = new List<Terms.Contract.Business_0407.GTASightSeeingMaterial>();

            List<Terms.Contract.Business_0407.GTA.SightSeeing> lists = new List<Terms.Contract.Business_0407.GTA.SightSeeing>();


            for (int i = 0; i < ((TERMS.Core.Product.ComponentGroup)Products[0]).Items.Count; i++)
            {
                SightSeeingMaterials.Add(((Terms.Contract.Business_0407.GTASightSeeingMaterial)((TERMS.Core.Product.ComponentGroup)((TERMS.Core.Product.ComponentGroup)Products[0]).Items[i]).Items[0]));

                lists.Add(SightSeeingMaterials[i].SightSeeing);
            }

            if (lists.Count > 0)
            {
                dlSightSeeings.Visible = true;
                BindSightSeeing(lists);
            }
            else
            {
                dlSightSeeings.Visible = false;
            }
        }
        else
        {
            dlSightSeeings.Visible = false;
        }
    }


    private void BindSightSeeing(List<Terms.Contract.Business_0407.GTA.SightSeeing> lists)
    {
        Session["SightSeeings"] = lists;

        PackageSearchCondition packageSearchCondition = (PackageSearchCondition)Utility.Transaction.CurrentSearchConditions;

        bool flag = false;

        List<string> list = new List<string>(2);
        list.Add("A");

        dlSightSeeings.DataSource = list;
        dlSightSeeings.DataBind();

        if (lists.Count > 0)
        {
            DataListItem item = dlSightSeeings.Items[0];

            DataList dl = (DataList)item.FindControl("dlSightSeeing");

            dl.DataSource = lists;
            dl.DataBind();

            Label lblFromTo = (Label)item.FindControl("lblFromTo");

            if (lists.Count > 0)
            {
                flag = true;

                lblFromTo.Text = " From Airport To Hotel (" + lists.Count + ")";

                lblFromTo.Visible = true;
            }
            else
            {
                lblFromTo.Visible = false;
            }

            for (int i = 0; i < dl.Items.Count; i++)
            {
                DataListItem info = dl.Items[i];

                Label lbl = (Label)info.FindControl("lblName");

                lbl.Text = lists[i].Item.Name;

                lbl = (Label)info.FindControl("lblPrice");

                lbl.Text = lists[i].TourOperations[0].ItemPrice.Price.ToString();

                lbl = (Label)info.FindControl("lblItemCode");

                lbl.Text = lists[i].Item.Code;

                lbl = (Label)info.FindControl("lblTime");

                lbl.Text = lists[i].Duration;

                HyperLink hp = (HyperLink)info.FindControl("hpDetail");

                hp.NavigateUrl = "~/Page/Common/SightseeingDetail.aspx?city=" + lists[i].City.Code + "&&item=" + lists[i].Item.Code;

                RadioButton rbten = (RadioButton)info.FindControl("rbnSelect");

                if (i == 0)
                {
                    rbten.Checked = false;
                }
                else
                {
                    rbten.Checked = false;
                }

                rbten.ToolTip = "From";

                rbten.Attributes["onclick"] = "javascript:CancelSelect(this,'dlSightSeeings$ctl00$dlSightSeeing$ctl" + i.ToString().PadLeft(2, '0') + "');";
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["SightSeeings"] != null)
        {
            List<Terms.Contract.Business_0407.GTA.SightSeeing> lists = (List<Terms.Contract.Business_0407.GTA.SightSeeing>)Session["SightSeeings"];

            SightSeeingOrderItem orderitem = new SightSeeingOrderItem(new TERMS.Business.Centers.ProductCenter.Profiles.SightSeeingProfile(""));

            for (int i = 0; i < dlSightSeeings.Items.Count; i++)
            {
                DataListItem item = dlSightSeeings.Items[0];

                DataList dl = (DataList)item.FindControl("dlSightSeeing");

                for (int j = 0; j < dl.Items.Count; j++)
                {
                    Label lbl = (Label)dl.Items[j].FindControl("lblItemCode");

                    RadioButton rbten = (RadioButton)dl.Items[j].FindControl("rbnSelect");

                    if (rbten.Checked)
                    {
                        for (int index = 0; index < lists.Count; index++)
                        {
                            if (lists[index].Item.Code.Trim() == lbl.Text.Trim())
                            {
                                orderitem.AdditionalInformation = lists[index].AdditionalInformation.Information;
                                orderitem.CityCode = lists[index].City.Code;
                                orderitem.CityName = lists[index].City.Name;
                                orderitem.DeparturePointRequired = lists[index].DeparturePointRequired;
                                orderitem.Duration = lists[index].Duration;
                                orderitem.HasExtraInfo = lists[index].HasExtraInfo;

                                orderitem.HasFlash = lists[index].HasFlash;
                                orderitem.ItemCode = lists[index].Item.Code;
                                orderitem.ItemName = lists[index].Item.Name;
                                orderitem.TourDate = Convert.ToDateTime(TermsCalendar1.CDate);
                                orderitem.CountryCode = dllCountry.SelectedValue;
                                orderitem.CountryName = dllCountry.SelectedItem.Text;

                                for (int count = 0; count < lists[index].SightseeingCategorys.Length; count++)
                                {
                                    SightseeingCategorysItem newitem = new SightseeingCategorysItem();

                                    newitem.Code = lists[index].SightseeingCategorys[count].Code;
                                    newitem.Name = lists[index].SightseeingCategorys[count].Name;

                                    orderitem.SightseeingCategorysItems.Add(newitem);
                                }

                                for (int count = 0; count < lists[index].SightseeingTypes.Length; count++)
                                {
                                    SightseeingTypesItem newitem = new SightseeingTypesItem();

                                    newitem.Code = lists[index].SightseeingTypes[count].Code;
                                    newitem.Name = lists[index].SightseeingTypes[count].Name;

                                    orderitem.SightseeingTypesItems.Add(newitem);
                                }

                                for (int count = 0; count < lists[index].TourOperations.Length; count++)
                                {
                                    TourOperationsItem newitem = new TourOperationsItem();

                                    newitem.Confirmationitem.Code = lists[index].TourOperations[count].Confirmation.Code;
                                    newitem.Confirmationitem.Confirmation = lists[index].TourOperations[count].Confirmation.Confirmation;
                                    newitem.Priceitem.Currency = lists[index].TourOperations[count].ItemPrice.Currency;
                                    newitem.Priceitem.TotalPrice = lists[index].TourOperations[count].ItemPrice.Price;
                                    newitem.SpecialCodeitem.Code = lists[index].TourOperations[count].SpecialCode.Code;
                                    newitem.SpecialCodeitem.Confirmation = lists[index].TourOperations[count].SpecialCode.Confirmation;

                                    for (int ii = 0; ii < lists[index].TourOperations[count].TourLanguages.Length; ii++)
                                    {
                                        TourLanguageItem language = new TourLanguageItem();

                                        language.Code = lists[index].TourOperations[count].TourLanguages[ii].Code;
                                        language.LanguageListCode = lists[index].TourOperations[count].TourLanguages[ii].LanguageListCode;
                                        language.Name = lists[index].TourOperations[count].TourLanguages[ii].Name;

                                        newitem.TourLanguageItems.Add(language);
                                    }

                                    orderitem.TourOperationsItems.Add(newitem);
                                }

                                Session["OrderItem"] = orderitem;

                                break;
                            }
                        }
                    }
                }
            }
        }

        if (Session["OrderItem"] != null)
        {
            SightSeeingOrderItem orderitem = (SightSeeingOrderItem)Session["OrderItem"];
            //this.Response.Redirect("~/Page/Common/SightseeingDetail.aspx?city=" + orderitem.CityCode + "&&item=" + orderitem.ItemCode);

            Terms.Material.Service.GTA.SightSeeingDetail sightSeeingDetail = m_SaleOrderService.SearchSightSeeingDetail(orderitem.CityCode, orderitem.ItemCode);

            if (sightSeeingDetail.TourOperationList.Length > 0)
            {
                lblTourOperationList.Text = "TourOperationList : " + sightSeeingDetail.TourOperationList.Length; 

                dllLanguage.Items.Clear();

                if (sightSeeingDetail.TourOperationList[0].TourLanguageList != null && sightSeeingDetail.TourOperationList[0].TourLanguageList.Length > 0 && sightSeeingDetail.TourOperationList[0].TourLanguageList[0].Code != null)
                { 
                    for (int i = 0; i < sightSeeingDetail.TourOperationList[0].TourLanguageList.Length; i++)
                    {
                        dllLanguage.Items.Add(new ListItem(sightSeeingDetail.TourOperationList[0].TourLanguageList[i].Name, sightSeeingDetail.TourOperationList[0].TourLanguageList[i].Code + "/" + sightSeeingDetail.TourOperationList[0].TourLanguageList[i].LanguageListCode));
                    }
                }

                dllTime.Items.Clear();

                if (sightSeeingDetail.TourOperationList[0].TourLanguageList != null && sightSeeingDetail.TourOperationList[0].DepartureList.Length > 0)
                {
                    for (int i = 0; i < sightSeeingDetail.TourOperationList[0].DepartureList.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(sightSeeingDetail.TourOperationList[0].DepartureList[i].DeparturePoint.Code))
                        {
                            dllTime.Items.Add(new ListItem(sightSeeingDetail.TourOperationList[0].DepartureList[i].Time + " , " + sightSeeingDetail.TourOperationList[0].DepartureList[i].DeparturePoint.Name, sightSeeingDetail.TourOperationList[0].DepartureList[i].Time + " / " + sightSeeingDetail.TourOperationList[0].DepartureList[i].DeparturePoint.Code));
                        }
                    }
                }
            }

            
        }
    }
    protected void btnBooking_Click(object sender, EventArgs e)
    {
        if (Session["OrderItem"] != null)
        {
            SightSeeingOrderItem orderitem = (SightSeeingOrderItem)Session["OrderItem"];

            if (dllLanguage.Items.Count > 0)
            {
                orderitem.DeparturePointLanguageCode = dllLanguage.SelectedValue;

                string temp = dllLanguage.SelectedValue;

                int index = temp.IndexOf(@"/");

                orderitem.DeparturePointLanguageCode = temp.Substring(0, index).Trim();

                orderitem.DeparturePointLanguageListCode = temp.Substring(index + 1).Trim();
                
                orderitem.DeparturePointLanguageName = dllLanguage.SelectedItem.Text;
            }

            if (dllTime.Items.Count > 0)
            {
                string temp = dllTime.SelectedValue;

                int index = temp.IndexOf(@"/");

                string timeTemp = temp.Substring(0, index);

                int point = timeTemp.IndexOf(@".");

                int hour = Convert.ToInt32(timeTemp.Substring(0, point));

                int minute = Convert.ToInt32(timeTemp.Substring(point + 1));

                orderitem.TourDepartureTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, 0);

                orderitem.DeparturePointCode = temp.Substring(index + 1).Trim();
            }

            orderitem.SpecialItemCode = orderitem.TourOperationsItems[0].SpecialCodeitem.Code;

            Terms.Material.Service.HotelGTAService gtaHotel = new HotelGTAService();

            List<Passenger> passengers = new List<Passenger>();
            passengers.Add(new Passenger("AAA", "AAA", "", TERMS.Common.PassengerType.Adult));
            passengers.Add(new Passenger("BBB", "BBB", "", TERMS.Common.PassengerType.Adult));
            passengers.Add(new Passenger("CCC", "CCC", "", TERMS.Common.PassengerType.Child));
            passengers.Add(new Passenger("DDD", "DDD", "", TERMS.Common.PassengerType.Child));
            try
            {
                gtaHotel.SightSeeingBooking(orderitem, passengers, "MT-102008-zxin-WEB-OP-081408", new Terms.Sales.Utility.MessageOrderItem());
            }
            catch
            {
                lblGtaID.Text = "Error";
            }
            if (string.IsNullOrEmpty(orderitem.StatusCode))
            {
                lblGtaID.Text = "Error : " + orderitem.Error;
            }
            else
            {
                lblGtaID.Text = "GTA ID :" + orderitem.TOKEN + " / " + orderitem.API + " / " + orderitem.BookingReferences;
            }
        }
    }
}
