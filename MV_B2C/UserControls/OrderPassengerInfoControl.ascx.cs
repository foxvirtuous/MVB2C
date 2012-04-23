using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Spring.Web.UI;
using log4net;

using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;
using Terms.Base.Service;
using Terms.Base.Utility;
using Terms.Common.Service;
//using Terms.Sales.Domain;
using System.Resources;
using System.Text.RegularExpressions;

public partial class OrderPassengerInfoControl : Spring.Web.UI.UserControl
{

    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    private IBaseService _BaseService;
    public IBaseService BaseService
    {
        set
        {
            this._BaseService = value;
        }
    }

    public string ValidationGroup
    {
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (this.dlAdult.Items.Count > 0)
                {
                    foreach (DataListItem item in dlAdult.Items)
                    {
                        //((TextBox)item.FindControl("txtAdultPassport")).ValidationGroup = value;

                    }
                }

                if (this.dlChild.Items.Count > 0)
                {
                    foreach (DataListItem item in dlChild.Items)
                    {
                        ((TextBox)item.FindControl("txtChildBirthday")).ValidationGroup = value;

                    }
                }
            }
        }
    }

    public OrderPassengerInfoControl()
    {
        this.InitializeControls += new EventHandler(OrderPassengerInfoControl_InitializeControls);
    }

    void OrderPassengerInfoControl_InitializeControls(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);

        int iAdult = 0;
        int iChild = 0;

        GetNumberOfPeople(ref iAdult, ref iChild);

        List<Passenger> m_OrderPassengerInfoAdults = new List<Passenger>();

        for (int i = 0; i < iAdult; i++)
        {
            if (i == 0)
            {
                Passenger pass = new Passenger(TERMS.Common.PassengerType.Adult);
                if (Utility.Transaction.IsLogin)
                    pass = new Passenger(Utility.Transaction.Member.FirstName, Utility.Transaction.Member.LastName, Utility.Transaction.Member.MiddleName, TERMS.Common.PassengerType.Adult);
                m_OrderPassengerInfoAdults.Add(pass);
            }
            else
            {
                m_OrderPassengerInfoAdults.Add(new Passenger(TERMS.Common.PassengerType.Adult));
            }
        }

        this.dlAdult.DataSource = m_OrderPassengerInfoAdults;


        List<Passenger> m_OrderPassengerInfoChilds = new List<Passenger>();

        for (int i = 0; i < iChild; i++)
        {
            m_OrderPassengerInfoChilds.Add(new Passenger(TERMS.Common.PassengerType.Child));
        }

        this.dlChild.DataSource = m_OrderPassengerInfoChilds;
        this.dlAdult.DataBind();
        this.dlChild.DataBind();

        if (!this.IsPostBack)
        {
            //this.dlAdult.DataBind();
            //this.dlChild.DataBind();

        }

        for (int i = 0; i < dlAdult.Items.Count; i++)
        {
            //((TermsCalendar)dlAdult.Items[i].FindControl("txtAdultBirthday")).Path = "../../";

            BindCountry(((DropDownList)dlAdult.Items[i].FindControl("ddlAdultCountry")));

            BindState(((DropDownList)dlAdult.Items[i].FindControl("ddlAdultState")));
        }

        for (int i = 0; i < dlChild.Items.Count; i++)
        {
            BindCountry(((DropDownList)dlChild.Items[i].FindControl("ddlChildCountry")));

            BindState(((DropDownList)dlChild.Items[i].FindControl("ddlChildState")));
        }
    }

    protected void dlAdult_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        BindMeal(e.Item.FindControl("ddlAdultMeal"));
        BindGender(e.Item.FindControl("rbtnAdultGender"), e.Item.FindControl("lbGender"));

        if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
        {
            ((Label)e.Item.FindControl("lblBir")).Visible = true;
            ((RequiredFieldValidator)e.Item.FindControl("rfvBirth")).Enabled = true;
        }
        else if (Utility.Transaction.CurrentTransactionObject.Items[0] is TourOrderItem)
        {
            if (((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).IsInsurance)
            {

                e.Item.FindControl("InsuranceAdultNeed").Visible = true;
                ((Label)e.Item.FindControl("lblBir")).Visible = true;
                ((RequiredFieldValidator)e.Item.FindControl("rfvBirth")).Enabled = true;

            }
            else
            {

                e.Item.FindControl("InsuranceAdultNeed").Visible = false;
                ((Label)e.Item.FindControl("lblBir")).Visible = false;
                ((RequiredFieldValidator)e.Item.FindControl("rfvBirth")).Enabled = false;
            }

            ((PlaceHolder)e.Item.FindControl("pMeal")).Visible = false;
        }

        if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
        {

        }

    }

    private void BindGender(object obj1, object obj2)
    {
        RadioButtonList rbl = (RadioButtonList)obj1;
        Label lbl = (Label)obj2;
        for (int i = 0; i < rbl.Items.Count; i++)
        {
            if (rbl.Items[i].Text.Trim() == lbl.Text.Trim())
            {
                rbl.Items[i].Selected = true;
            }
        }

    }

    public void GetNumberOfPeople(ref int adult, ref int child)
    {
        if (!Utility.IsSearchConditionNull)
        {
            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                AirSearchCondition airSearchCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition;

                adult = airSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult);

                child = airSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);
            }
            else if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
            {

                adult = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).AdultNumber;
                if (((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildWithOutNumber != null && ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildWithOutNumber > 0)
                    child = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildNumber + ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildWithOutNumber;
                else
                    child = ((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).ChildNumber;
            }
            else
            {
                if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
                {
                    AirSearchCondition airSearchCondition = (AirSearchCondition)Utility.Transaction.CurrentSearchConditions;

                    adult = airSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult);

                    child = airSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);
                }
                else
                {
                    IList<RoomSearchCondition> roomSearchConditionList = ((HotelSearchCondition)Utility.Transaction.CurrentSearchConditions).RoomSearchConditions;

                    foreach (RoomSearchCondition roomSearchCondition in roomSearchConditionList)
                    {
                        int tempAdult = 0;
                        int tempChild = 0;

                        SortedList<TERMS.Common.PassengerType, int> sortedList = roomSearchCondition.Passengers;

                        sortedList.TryGetValue(TERMS.Common.PassengerType.Adult, out tempAdult);

                        sortedList.TryGetValue(TERMS.Common.PassengerType.Child, out tempChild);

                        adult += tempAdult;

                        child += tempChild;
                    }
                }
            }
        }

    }

    public void BindMeal(object obj)
    {
        DropDownList drp = (DropDownList)obj;

        drp.DataSource = _BaseService.LoadAllTypeDetails(typeof(Terms.Base.Domain.MealType));

        drp.DataTextField = "Name";
        drp.DataValueField = "DetailType";
        drp.DataBind();
    }

    private void BindCountry(DropDownList item)
    {
        ListItem itemNew = new ListItem("United States", "US");

        item.Items.Add(itemNew);

        itemNew = new ListItem("CANADA", "CA");

        item.Items.Add(itemNew);
    }

    private void BindState(DropDownList item)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode("US");

        item.DataSource = ilist;
        item.DataTextField = "Name";
        item.DataValueField = "Name";
        item.DataBind();
        //item.Items.Insert(0, new ListItem("-SELECT-", "select"));
    }

    public bool PaddingPassengerInfo()
    {
        try
        {
            Utility.Transaction.CurrentTransactionObject.ClearPassenger();

            DataListItem item;

            List<Passenger> OrderPassengerInfos = new List<Passenger>();

            int iAdult = dlAdult.Items.Count;
            int iChild = dlChild.Items.Count;
            //System.Text.RegularExpressions.Regex reg = new Regex(@"[a-zA-Z\s]+");
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[A-Za-z.]+$");
            for (int i = 0; i < iAdult; i++)
            {

                item = dlAdult.Items[i];
                string firstName = ((TextBox)item.FindControl("txtAdultFirst")).Text;
                string middleName = ((TextBox)item.FindControl("txtAdultMiddle")).Text;
                string lastName = ((TextBox)item.FindControl("txtAdultLast")).Text;
                if (!reg.IsMatch(firstName + middleName + lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert(' " + Resources.Global.ADULT + (i + 1).ToString() + "# " + Resources.HintInfo.ShouldBeEnglishName + "');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(firstName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# First Name format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# Last Name format error.');</script>");
                    return false;
                }

                DateTime dateBirthday;

                try
                {
                    dateBirthday = Convert.ToDateTime(((TextBox)item.FindControl("txtAdultBirthday")).Text);
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# birthday format error.');</script>");
                    return false;
                }

                if (dateBirthday >= DateTime.Now.AddYears(-12))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# 12+.');</script>");
                    return false;
                }

                Passenger adultorderPassengerInfo = new Passenger(firstName, lastName, middleName, TERMS.Common.PassengerType.Adult);
                adultorderPassengerInfo.Birthday = dateBirthday;
                adultorderPassengerInfo.Salutationn = (TERMS.Common.Salutation)Convert.ToInt32(((RadioButtonList)item.FindControl("rbtnAdultGender")).SelectedValue);
                adultorderPassengerInfo.PassportNumber = ((TextBox)item.FindControl("txtAdultPassport")).Text;
                adultorderPassengerInfo.Meal = (TERMS.Business.Centers.SalesCenter.Passenger.MealType)Convert.ToInt16(((DropDownList)item.FindControl("ddlAdultMeal")).SelectedValue);
                adultorderPassengerInfo.PassengerType = TERMS.Common.PassengerType.Adult;
                Utility.Transaction.CurrentTransactionObject.AddPassenger(adultorderPassengerInfo);
                Utility.Transaction.CurrentTransactionObject.Items[0].Passengers.Add(adultorderPassengerInfo);
                if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
                {
                    ((OrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Passengers.Add(adultorderPassengerInfo);
                }
            }

            for (int i = 0; i < iChild; i++)
            {
                item = dlChild.Items[i];
                string firstName = ((TextBox)item.FindControl("txtChildFirst")).Text;
                string middleName = ((TextBox)item.FindControl("txtChildMiddle")).Text;
                string lastName = ((TextBox)item.FindControl("txtChildLast")).Text;

                if (!reg.IsMatch(firstName + middleName + lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert(' " + Resources.Global.CHILD + (i + 1).ToString() + "# " + Resources.HintInfo.ShouldBeEnglishName + "');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(firstName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# First Name format error.');</script>");
                    return false;
                }

                if (string.IsNullOrEmpty(lastName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# Last Name format error.');</script>");
                    return false;
                }
                Passenger childOrderPassengerInfo = new Passenger(firstName, lastName, middleName, TERMS.Common.PassengerType.Child);
                DateTime dateBirthday;

                try
                {
                    dateBirthday = Convert.ToDateTime(((TextBox)item.FindControl("txtChildBirthday")).Text);

                    DateTime dateOldTime = DateTime.Now;
                                        

                    if (dateBirthday.AddYears(11) < dateOldTime)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# The age is bigger than 11 ');</script>");
                        return false;
                    }

                    if (dateBirthday.AddYears(2) > dateOldTime)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# The age is Younger than 2 ');</script>");
                        return false;
                    }
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# birthday format error.');</script>");
                    return false;
                }

                childOrderPassengerInfo.Salutationn = (TERMS.Common.Salutation)Convert.ToInt32(((RadioButtonList)item.FindControl("rbtnChildGender")).SelectedValue);
                childOrderPassengerInfo.Birthday = dateBirthday;
                childOrderPassengerInfo.PassportNumber = ((TextBox)item.FindControl("txtChildPassport")).Text;
                childOrderPassengerInfo.Meal = (TERMS.Business.Centers.SalesCenter.Passenger.MealType)Convert.ToInt16(((DropDownList)item.FindControl("ddlChildMeal")).SelectedValue);
                childOrderPassengerInfo.PassengerType = TERMS.Common.PassengerType.Child;

                Utility.Transaction.CurrentTransactionObject.AddPassenger(childOrderPassengerInfo);
                Utility.Transaction.CurrentTransactionObject.Items[0].Passengers.Add(childOrderPassengerInfo);
                if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
                {
                    ((OrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Passengers.Add(childOrderPassengerInfo);
                }

            }


            //创建HotelOrderItem列表
            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                List<HotelOrderItem> hotelOrderItems = new List<HotelOrderItem>();

                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items[0].Items.Count; i++)
                    if (Utility.Transaction.CurrentTransactionObject.Items[0].Items[i] is HotelOrderItem)
                        hotelOrderItems.Add((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[i]);

                List<TERMS.Business.Centers.SalesCenter.Passenger> passengers = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

                for (int j = 0; j < Utility.Transaction.CurrentTransactionObject.GetPassengers().Count; j++)
                    passengers.Add((TERMS.Business.Centers.SalesCenter.Passenger)Utility.Transaction.CurrentTransactionObject.GetPassengers()[j]);

                //将Passenger分配到OrderItem中
                HotelOrderUtility.AssignPassengersToHotel(hotelOrderItems, passengers);
            }

            //add by henry 2008-07-31 begin 处理tour产品所需要的passenger信息
            if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                if (((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).IsInsurance)
                    return PaddingPassengerForInsuranceInfo();
                //add by henry 2008-07-31 end
                else
                    return true;
            }

            return true;
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + ex.Message + "');</script>");
            return false;
        }
    }

    public bool PaddingPassengerForInsuranceInfo()
    {
        try
        {
            DataListItem item;

            IList<TERMS.Business.Centers.SalesCenter.Passenger> Passengers = Utility.Transaction.CurrentTransactionObject.GetPassengers();

            List<TERMS.Business.Centers.SalesCenter.Passenger> OrderPassengerInfos = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

            int iAdult = dlAdult.Items.Count;
            int iChild = dlChild.Items.Count;

            List<string> list = new List<string>();

            for (int i = 0; i < iAdult; i++)
            {
                item = dlAdult.Items[i];

                DateTime dateBirthday;

                try
                {
                    dateBirthday = Convert.ToDateTime(((TextBox)item.FindControl("txtAdultBirthday")).Text);

                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# birthday format error.');</script>");
                    return false;
                }

                if (dateBirthday >= DateTime.Now.AddYears(-12))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# 12+.');</script>");
                    return false;
                }


                Passengers[i].Birthday = dateBirthday;

                Passengers[i].StreetAddress = ((TextBox)item.FindControl("txtAdultStreet")).Text;

                if (string.IsNullOrEmpty(Passengers[i].StreetAddress))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# Street format error.');</script>");
                    return false;
                }

                Passengers[i].CityName = ((TextBox)item.FindControl("txtAdultCity")).Text;

                if (string.IsNullOrEmpty(Passengers[i].CityName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# City format error.');</script>");
                    return false;
                }

                Passengers[i].CountryName = ((DropDownList)item.FindControl("ddlAdultCountry")).SelectedItem.Text;   //((TextBox)item.FindControl("txtAdultCountry")).Text;

                Passengers[i].ProvinceName = ((DropDownList)item.FindControl("ddlAdultState")).SelectedValue; //((TextBox)item.FindControl("txtAdultState")).Text;

                Passengers[i].Email = ((TextBox)item.FindControl("txtAdultEmail")).Text;

                Passengers[i].ZipCode = ((TextBox)item.FindControl("txtAdultZipCode")).Text;

                if (string.IsNullOrEmpty(Passengers[i].ZipCode))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Adult " + (i + 1).ToString() + "# ZipCode format error.');</script>");
                    return false;
                }

                TERMS.Common.City city = new TERMS.Common.City();
                city.Name = ((TextBox)item.FindControl("txtAdultCity")).Text;
                TERMS.Common.Address address = new TERMS.Common.Address(city, ((TextBox)item.FindControl("txtAdultStreet")).Text, ((TextBox)item.FindControl("txtAdultZipCode")).Text);

                Passengers[i].Address.Add(address);

            }

            for (int i = iAdult; i < iChild + iAdult; i++)
            {
                item = dlChild.Items[i - iAdult];



                Passengers[i].StreetAddress = ((TextBox)item.FindControl("txtChildStreet")).Text;

                if (string.IsNullOrEmpty(Passengers[i].StreetAddress))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i - iAdult + 1).ToString() + "# Street format error.');</script>");
                    return false;
                }

                Passengers[i].CityName = ((TextBox)item.FindControl("txtChildCity")).Text;

                if (string.IsNullOrEmpty(Passengers[i].CityName))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i - iAdult + 1).ToString() + "# City format error.');</script>");
                    return false;
                }

                Passengers[i].CountryName = ((DropDownList)item.FindControl("ddlChildCountry")).SelectedItem.Text; //((TextBox)item.FindControl("txtChildCountry")).Text;

                Passengers[i].ProvinceName = ((DropDownList)item.FindControl("ddlChildState")).SelectedValue; //((TextBox)item.FindControl("txtChildState")).Text;

                Passengers[i].Email = ((TextBox)item.FindControl("txtChildEmail")).Text;

                Passengers[i].ZipCode = ((TextBox)item.FindControl("txtChildZipCode")).Text;

                if (string.IsNullOrEmpty(Passengers[i].ZipCode))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i - iAdult + 1).ToString() + "# ZipCode format error.');</script>");
                    return false;
                }

                TERMS.Common.City city = new TERMS.Common.City();
                city.Name = ((TextBox)item.FindControl("txtChildCity")).Text;
                TERMS.Common.Address address = new TERMS.Common.Address(city, ((TextBox)item.FindControl("txtChildStreet")).Text, ((TextBox)item.FindControl("txtChildZipCode")).Text);

                Passengers[i].Address.Add(address);


            }
        }
        catch (Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + ex.Message + "');</script>");
            return false;
        }

        return true;
    }

    protected void dlChild_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        BindMeal(e.Item.FindControl("ddlChildMeal"));
        if (Utility.Transaction.CurrentTransactionObject.Items[0] is TourOrderItem)
        {
            if (((TourOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0]).IsInsurance)
            {
                e.Item.FindControl("InsuranceChildNeed").Visible = true;

            }
            else
            {
                e.Item.FindControl("InsuranceChildNeed").Visible = false;

            }
            ((PlaceHolder)e.Item.FindControl("pMeal")).Visible = false;
        }
    }

    protected void ddlAdultCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList item = (DropDownList)((DropDownList)sender).Parent.FindControl("ddlAdultState");

        IList ilist = _CommonService.FindProvincesByCountryCode(((DropDownList)sender).SelectedValue);

        item.DataSource = ilist;
        item.DataTextField = "Name";
        item.DataValueField = "Name";
        item.DataBind();
    }

    public void BindPassenageByPNR(List<object> adultss, List<object> childss)
    {
        int indexAdults = dlAdult.Items.Count;

        int indexChilds = dlChild.Items.Count;

        int count = 0;

        DataListItem item;

        string FirstName = string.Empty;
        string LastName = string.Empty;
        string MiddleName = string.Empty;

        List<string> passenages = new List<string>();

        for (int adultsindex = 0; adultsindex < adultss.Count; adultsindex++)
        {
            for (int i = 0; i < ((List<string>)adultss[adultsindex]).Count; i++)
            {
                passenages.Add(((List<string>)adultss[adultsindex])[i]);
            }
        }

        for (int adultsindex = 0; adultsindex < childss.Count; adultsindex++)
        {
            for (int i = 0; i < ((List<string>)childss[adultsindex]).Count; i++)
            {
                passenages.Add(((List<string>)childss[adultsindex])[i]);
            }
        }


        if (indexAdults > 0)
        {
            for (int i = 0; i < indexAdults; i++)
            {
                if (count > indexAdults || count > passenages.Count - 1)
                {
                    break;
                }

                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = string.Empty;

                string adultName = passenages[count];

                int iCompart1 = adultName.IndexOf(@"/");
                int iCompart2 = adultName.IndexOf(@".");

                LastName = adultName.Substring(0, iCompart1);
                if (iCompart2 > 0)
                {
                    FirstName = adultName.Substring(iCompart1 + 1, iCompart2 - (iCompart1 + 1));
                    MiddleName = adultName.Substring(iCompart2 + 1);
                }
                else
                {
                    FirstName = adultName.Substring(iCompart1 + 1);
                }

                item = dlAdult.Items[i];
                ((TextBox)item.FindControl("txtAdultFirst")).Text = FirstName;
                ((TextBox)item.FindControl("txtAdultLast")).Text = LastName;
                ((TextBox)item.FindControl("txtAdultMiddle")).Text = MiddleName;

                count++;
            }
        }

        if (indexChilds > 0)
        {
            for (int i = 0; i < indexChilds; i++)
            {
                if (count > (indexAdults + indexChilds) || count > passenages.Count - 1)
                {
                    break;
                }

                FirstName = string.Empty;
                MiddleName = string.Empty;
                LastName = string.Empty;

                string childName = passenages[count];

                int iCompart1 = childName.IndexOf(@"/");
                int iCompart2 = childName.IndexOf(@".");

                LastName = childName.Substring(0, iCompart1);
                if (iCompart2 > 0)
                {
                    FirstName = childName.Substring(iCompart1 + 1, iCompart2 - (iCompart1 + 1));
                    MiddleName = childName.Substring(iCompart2 + 1);
                }
                else
                {
                    FirstName = childName.Substring(iCompart1 + 1);
                }

                item = dlChild.Items[i];
                ((TextBox)item.FindControl("txtChildFirst")).Text = FirstName;
                ((TextBox)item.FindControl("txtChildLast")).Text = LastName;
                ((TextBox)item.FindControl("txtChildMiddle")).Text = MiddleName;

                count++;
            }
        }
    }
}