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
using Terms.Base.Service;
using Terms.Sales.Business;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Common;

public partial class HotelOrderPassengerInfoControl : Spring.Web.UI.UserControl
{
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
                        ((TextBox)item.FindControl("txtAdultFirst")).ValidationGroup = value;
                        ((RequiredFieldValidator)item.FindControl("RequiredFieldValidator1")).ValidationGroup = value;
                        ((TextBox)item.FindControl("txtAdultMiddle")).ValidationGroup = value;
                        ((TextBox)item.FindControl("txtAdultLast")).ValidationGroup = value;
                        ((RequiredFieldValidator)item.FindControl("RequiredFieldValidator2")).ValidationGroup = value;
                        ((TextBox)item.FindControl("txtAdultPassport")).ValidationGroup = value;
                    }
                }

                if (this.dlChild.Items.Count > 0)
                {
                    foreach (DataListItem item in dlChild.Items)
                    {
                        ((TextBox)item.FindControl("txtChildFirst")).ValidationGroup = value;
                        ((TextBox)item.FindControl("txtChildMiddle")).ValidationGroup = value;
                        ((TextBox)item.FindControl("txtChildLast")).ValidationGroup = value;
                        ((TextBox)item.FindControl("txtChildPassport")).ValidationGroup = value;
                        ((TextBox)item.FindControl("txtChildBirthday")).ValidationGroup = value;
                        ((RequiredFieldValidator)item.FindControl("RequiredFieldValidator3")).ValidationGroup = value;
                        ((RequiredFieldValidator)item.FindControl("RequiredFieldValidator4")).ValidationGroup = value;
                    }
                }
            }
        }
    }

    public HotelOrderPassengerInfoControl()
    {
        this.InitializeControls += new EventHandler(HotelOrderPassengerInfoControl_InitializeControls);
    }

    void HotelOrderPassengerInfoControl_InitializeControls(object sender, EventArgs e)
    {
        Utility.Transaction.IntKey = Convert.ToInt32(Request.Params["ConditionID"]);


        int iAdult = 0;
        int iChild = 0;

        GetNumberOfPeople(ref iAdult, ref iChild);

        List<TERMS.Business.Centers.SalesCenter.Passenger> m_OrderPassengerInfoAdults = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

        for (int i = 0; i < iAdult; i++)
        {
            if (i == 0)
            {
                TERMS.Business.Centers.SalesCenter.Passenger pass = new TERMS.Business.Centers.SalesCenter.Passenger(TERMS.Common.PassengerType.Adult);
                if (Utility.Transaction.IsLogin)
                {
                    //当是Subagent的时候 是不需要把subagent作为客人显示的
                    if (!Utility.IsSubAgent)
                    {
                        pass = new TERMS.Business.Centers.SalesCenter.Passenger(Utility.Transaction.Member.FirstName, Utility.Transaction.Member.LastName, Utility.Transaction.Member.MiddleName, TERMS.Common.PassengerType.Adult);
                    }
                }
                m_OrderPassengerInfoAdults.Add(pass);
            }
            else
            {
                m_OrderPassengerInfoAdults.Add(new TERMS.Business.Centers.SalesCenter.Passenger(TERMS.Common.PassengerType.Adult));
            }

        }

        this.dlAdult.DataSource = m_OrderPassengerInfoAdults;


        List<TERMS.Business.Centers.SalesCenter.Passenger> m_OrderPassengerInfoChilds = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

        for (int i = 0; i < iChild; i++)
        {
            m_OrderPassengerInfoChilds.Add(new TERMS.Business.Centers.SalesCenter.Passenger(TERMS.Common.PassengerType.Child));
        }

        this.dlChild.DataSource = m_OrderPassengerInfoChilds;
        this.dlAdult.DataBind();
        this.dlChild.DataBind();

        if (!this.IsPostBack)
        {
            if (dlAdult.Items != null && dlAdult.Items.Count > 0)
            {
                ((TextBox)(dlAdult.Items[0].FindControl("txtAdultFirst"))).Attributes.Add("onblur", "copytext(this)");
                ((TextBox)(dlAdult.Items[0].FindControl("txtAdultLast"))).Attributes.Add("onblur", "copytext(this)");
                ((TextBox)(dlAdult.Items[0].FindControl("txtAdultMiddle"))).Attributes.Add("onblur", "copytext(this)");
            }
        }
    }

    private void GetNumberOfPeople(ref int adult, ref int child)
    {
        if (!Utility.IsSearchConditionNull)
        {
            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                AirSearchCondition airSearchCondition = ((PackageSearchCondition)Utility.Transaction.CurrentSearchConditions).AirSearchCondition;

                adult = airSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Adult);

                child = airSearchCondition.GetPassengerNumber(TERMS.Common.PassengerType.Child);
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

                        SortedList<PassengerType, int> sortedList = roomSearchCondition.Passengers;

                        sortedList.TryGetValue(PassengerType.Adult, out tempAdult);

                        sortedList.TryGetValue(PassengerType.Child, out tempChild);

                        adult += tempAdult;

                        child += tempChild;
                    }
                }
            }
        }

    }

    public bool PaddingPassengerInfo()
    {
        try
        {
            Utility.Transaction.CurrentTransactionObject.ClearPassenger();

            DataListItem item;

            List<TERMS.Business.Centers.SalesCenter.Passenger> OrderPassengerInfos = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

            int iAdult = dlAdult.Items.Count;
            int iChild = dlChild.Items.Count;

            List<string> list = new List<string>();

            for (int i = 0; i < iAdult; i++)
            {
                item = dlAdult.Items[i];

                if (!list.Contains(((TextBox)item.FindControl("txtAdultFirst")).Text.Trim().ToUpper() + ((TextBox)item.FindControl("txtAdultLast")).Text.Trim().ToUpper()))
                {
                    list.Add(((TextBox)item.FindControl("txtAdultFirst")).Text.Trim().ToUpper() + ((TextBox)item.FindControl("txtAdultLast")).Text.Trim().ToUpper());
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('name repeat');</script>");
                    return false;
                }

                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[A-Za-z.]+$");

                if (!reg.IsMatch(((TextBox)item.FindControl("txtAdultFirst")).Text + ((TextBox)item.FindControl("txtAdultMiddle")).Text + ((TextBox)item.FindControl("txtAdultLast")).Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Name format error.');</script>");
                    return false;
                }


                TERMS.Business.Centers.SalesCenter.Passenger adultorderPassengerInfo = new TERMS.Business.Centers.SalesCenter.Passenger(
                    ((TextBox)item.FindControl("txtAdultFirst")).Text, ((TextBox)item.FindControl("txtAdultLast")).Text,
                    ((TextBox)item.FindControl("txtAdultMiddle")).Text, TERMS.Common.PassengerType.Adult);

                adultorderPassengerInfo.Salutationn = (Salutation)Convert.ToInt16(((RadioButtonList)item.FindControl("rbtnAdultGender")).SelectedValue);
                adultorderPassengerInfo.PassportNumber = ((TextBox)item.FindControl("txtAdultPassport")).Text;
                //adultorderPassengerInfo.Meal = (TERMS.Business.Centers.SalesCenter.Passenger.MealType)Convert.ToInt16(((DropDownList)item.FindControl("ddlAdultMeal")).SelectedValue);

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

                if (!list.Contains(((TextBox)item.FindControl("txtChildFirst")).Text.Trim().ToUpper() + ((TextBox)item.FindControl("txtChildLast")).Text.Trim().ToUpper()))
                {
                    list.Add(((TextBox)item.FindControl("txtChildFirst")).Text.Trim().ToUpper() + ((TextBox)item.FindControl("txtChildLast")).Text.Trim().ToUpper());
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('name repeat');</script>");
                    return false;
                }

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
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# The age is younger than 11 ');</script>");
                        return false;
                    }
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Child " + (i + 1).ToString() + "# birthday format error.');</script>");
                    return false;
                }

                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex("^[A-Za-z.]+$");

                if (!reg.IsMatch(((TextBox)item.FindControl("txtChildFirst")).Text + ((TextBox)item.FindControl("txtChildMiddle")).Text + ((TextBox)item.FindControl("txtChildLast")).Text))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Name format error.');</script>");
                    return false;
                }


                TERMS.Business.Centers.SalesCenter.Passenger childOrderPassengerInfo = new TERMS.Business.Centers.SalesCenter.Passenger(
                    ((TextBox)item.FindControl("txtChildFirst")).Text, ((TextBox)item.FindControl("txtChildLast")).Text,
                    ((TextBox)item.FindControl("txtChildMiddle")).Text, TERMS.Common.PassengerType.Child);

                childOrderPassengerInfo.Salutationn = (Salutation)Convert.ToInt16(((RadioButtonList)item.FindControl("rbtnChildGender")).SelectedValue);
                childOrderPassengerInfo.Birthday = dateBirthday;
                childOrderPassengerInfo.PassportNumber = ((TextBox)item.FindControl("txtChildPassport")).Text;
                //childOrderPassengerInfo.Meal = (TERMS.Business.Centers.SalesCenter.Passenger.MealType)Convert.ToInt16(((DropDownList)item.FindControl("ddlChildMeal")).SelectedValue);

                Utility.Transaction.CurrentTransactionObject.AddPassenger(childOrderPassengerInfo);

                Utility.Transaction.CurrentTransactionObject.Items[0].Passengers.Add(childOrderPassengerInfo);
                if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
                {
                    ((OrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[0]).Passengers.Add(childOrderPassengerInfo);
                }                
            }            

            //创建HotelOrderItem列表
            List<HotelOrderItem> hotelOrderItems = new List<HotelOrderItem>();

            if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.PackageSearchCondition)
            {
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items[0].Items.Count; i++)
                    if (Utility.Transaction.CurrentTransactionObject.Items[0].Items[i] is HotelOrderItem)
                        hotelOrderItems.Add((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[0].Items[i]);
            }
            else
            {
                for (int i = 0; i < Utility.Transaction.CurrentTransactionObject.Items.Count; i++)
                    if (Utility.Transaction.CurrentTransactionObject.Items[i] is HotelOrderItem)
                        hotelOrderItems.Add((HotelOrderItem)Utility.Transaction.CurrentTransactionObject.Items[i]);
            }

            List<TERMS.Business.Centers.SalesCenter.Passenger> passengers = new List<TERMS.Business.Centers.SalesCenter.Passenger>();

            for (int j = 0; j < Utility.Transaction.CurrentTransactionObject.GetPassengers().Count; j++)
                passengers.Add((TERMS.Business.Centers.SalesCenter.Passenger)Utility.Transaction.CurrentTransactionObject.GetPassengers()[j]);

                //将Passenger分配到OrderItem中
            HotelOrderUtility.AssignPassengersToHotel(hotelOrderItems, passengers);

            return true;
        }
        catch(Exception ex)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + ex.Message + "');</script>");
            return false;
        }
    }

    protected void dlAdult_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //BindMeal(e.Item.FindControl("ddlAdultMeal"));
        //if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition || Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        //{
        //    ((PlaceHolder)e.Item.FindControl("pMeal")).Visible = false;
        //}

    }
    protected void dlChild_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        //BindMeal(e.Item.FindControl("ddlChildMeal"));
        //if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition || Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
        //{
        //    ((PlaceHolder)e.Item.FindControl("pMeal")).Visible = false;
        //}
    }
}
