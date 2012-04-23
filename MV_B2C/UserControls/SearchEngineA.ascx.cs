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
using System.Globalization;

using Spring.Web.UI;
using log4net;

using System.Collections.Generic;
using Terms.Material.Service;
using Terms.Sales.Business;
using Terms.Common.Service;
using Terms.Sales.Service;
using Terms.Common.Domain;
using Terms.Global.Utility;
using TERMS.Common;
using System.Text.RegularExpressions;
using Terms.Member.Business;
using Terms.Member.Service;
using System.Security.Cryptography;

public partial class SearchEngineA : SalesBaseUserControl
{
    //记录Air Search时间的日志对象
    private static readonly log4net.ILog log =
         log4net.LogManager.GetLogger("AirSearchTime");

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

    private IMemberInformationService memberInformationService;
    public IMemberInformationService MemberInformationService
    {
        set { this.memberInformationService = value; }
    }

    private ICommonService _CommonService;

    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    public string CalendarPath
    {
        get
        {
            if (ViewState["CalendarPath"] == null)
                ViewState["CalendarPath"] = string.Empty;

            return ViewState["CalendarPath"].ToString();
        }
        set
        {
            ViewState["CalendarPath"] = value;
        }
    }

    private IApplicationCacheFoundationDate _ApplicationCacheFoundationDate;
    public IApplicationCacheFoundationDate ApplicationCacheFoundationDate
    {
        set
        {
            this._ApplicationCacheFoundationDate = value;
        }
    }

    #region user define

    /// <summary>
    /// Init Page
    /// </summary>
    private void Initial()
    {
        hlChooseAirline.NavigateUrl = SaleWebSuffix + "ChooseAirlines.aspx";

        ((TextBox)depFlightCalendar.FindControl("calendarDate")).CssClass = "search_inp";
        ((TextBox)rtnFlightCalendar.FindControl("calendarDate")).CssClass = "search_inp";
        depFullCity.CssClass = "search_inp";
        toFullCity.CssClass = "search_inp";
        rtnFromFullCity.CssClass = "search_inp";
        rtnToFullCity.CssClass = "search_inp";

        depFlightCalendar.IsCoercion = true;
        depFlightCalendar.CoercionID = "rtnFlightCalendar";

        if (!SessionExpired)
        {
            BindSearchCondition();
        }
        else
        {

            ((TextBox)depFlightCalendar.FindControl("calendarDate")).Text = DateTime.Now.AddDays(14).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
            ((TextBox)rtnFlightCalendar.FindControl("calendarDate")).Text = DateTime.Now.AddDays(21).ToString("MM/dd/yyyy", DateTimeFormatInfo.InvariantInfo);
        }

        // Only Rounf trip then can do the read only
        if (FlightType.Value.Equals("roundtrip"))
            DoReadOnly2Component(true);
    }

    /// <summary>
    /// Bind the search Condition
    /// </summary>
    private void BindSearchCondition()
    {
        if (this.Transaction == null) return;
        if (this.Transaction.CurrentSearchConditions == null) return;
        if ((this.Transaction.CurrentSearchConditions is AirSearchCondition) == false) return;

        AirSearchCondition airSearchCondition = (AirSearchCondition)this.Transaction.CurrentSearchConditions;
        SessionClass sc = (SessionClass)Session["CurrentSession"];
        depFullCity.Text = sc.FromCityName;
        toFullCity.Text = sc.ToCityName;
        TextBox depFlightCalendar = (TextBox)this.depFlightCalendar.FindControl("calendarDate");


        TextBox rtnFlightCalendar = (TextBox)this.rtnFlightCalendar.FindControl("calendarDate");
        depFlightCalendar.Text = airSearchCondition.GetAddTripCondition()[0].DepartureDate.ToString("d", DateTimeFormatInfo.InvariantInfo);

        if (airSearchCondition.GetAddTripCondition()[1].DepartureDate.CompareTo(DateTime.MaxValue) < 0)
        {
            rtnFlightCalendar.Text = airSearchCondition.GetAddTripCondition()[1].DepartureDate.ToString("d", DateTimeFormatInfo.InvariantInfo);
        }
        else
        {
            rtnFlightCalendar.Text = airSearchCondition.GetAddTripCondition()[0].DepartureDate.AddDays(7).ToString("d", DateTimeFormatInfo.InvariantInfo);
        }

        string airline = airSearchCondition.Airlines == null || airSearchCondition.Airlines.Length == 0 ? null : airSearchCondition.Airlines[0];

        if (airSearchCondition.FlightType.ToUpper().Equals("ONEWAY"))
        {
            FlightType.Value = "oneway";
            oneway1.Style["display"] = "none";
            oneway2.Style["display"] = "none";
            this.rdbOneway.Checked = true;

            // It will be validated by AJAX, So put value
            rtnFromCity.Text = sc.ToCityName;
            rtnToCity.Text = sc.FromCityName;
        }

        if (airSearchCondition.FlightType.ToUpper().Equals("ROUNDTRIP"))
        {
            FlightType.Value = "roundtrip";
            rtnFromCity.Text = sc.ToCityName;
            rtnToCity.Text = sc.FromCityName;
            rdbRoundTrip.Checked = true;
        }

        if (airSearchCondition.FlightType.ToUpper().Equals("OPENJAW"))
        {
            oneway1.Style["display"] = "";
            oneway2.Style["display"] = "";
            this.rdbOpenjaw.Checked = true;
            FlightType.Value = "openjaw";
            rtnFromCity.Text = sc.ReturnFromCityName;
            rtnToCity.Text = sc.ReturnToCityName;
        }

        rdoLstCabin.SelectedIndex = rdoLstCabin.Items.IndexOf(rdoLstCabin.Items.FindByValue(airSearchCondition.GetAddTripCondition()[0].Cabin.ToString().ToUpper()));

        GlobalUtility.SelectDropDownList(ddlAdult, airSearchCondition.GetPassengerNumber(PassengerType.Adult).ToString(), true);
        GlobalUtility.SelectDropDownList(ddlChild, airSearchCondition.GetPassengerNumber(PassengerType.Child).ToString(), true);
        GlobalUtility.SelectDropDownList(ddlInfant, airSearchCondition.GetPassengerNumber(PassengerType.Infant).ToString(), true);

        if (airSearchCondition.Airlines != null)
        {
            txtAirline.Text = string.Join(",", airSearchCondition.Airlines);
        }
    }

    private Terms.Common.Domain.Airport MatchAirport(string AirportName, List<Terms.Common.Domain.Airport> AirportList)
    {
        foreach (Terms.Common.Domain.Airport airport in AirportList)
        {
            if (airport.Name.Equals(AirportName))
                return airport;
        }
        return null;
    }

    #endregion


    private void SetSearchCondition(ref bool IsRealCity, ref bool IsSelectAirport)
    {
        Session["CurrentSession"] = new SessionClass();
        SessionClass sc = (SessionClass)Session["CurrentSession"];

        AirSearchCondition airSearchCondition = new AirSearchCondition();

        airSearchCondition.SetPassengerNumber(PassengerType.Adult, Convert.ToInt32(ddlAdult.SelectedValue));

        CabinType cabin = new CabinType();
        if (rdoLstCabin.SelectedIndex == 0)
        {
            cabin = CabinType.Economy;
        }
        else if (rdoLstCabin.SelectedIndex == 1)
        {
            cabin = CabinType.Business;
        }
        else if (rdoLstCabin.SelectedIndex == 2)
        {
            cabin = CabinType.First;
        }
        else if (rdoLstCabin.SelectedIndex == 3)
        {
            cabin = CabinType.All;
        }

        airSearchCondition.SetPassengerNumber(PassengerType.Child, Convert.ToInt32(ddlChild.SelectedValue));
        airSearchCondition.SetPassengerNumber(PassengerType.Infant, Convert.ToInt32(ddlInfant.SelectedValue));

        airSearchCondition.FlightType = FlightType.Value.Trim();

        airSearchCondition.FlexibleDays = 0;

        AirTripCondition deptCondition = new AirTripCondition();
        deptCondition.Cabin = cabin;

        sc.FromCityName = depCity.Text.Trim();
        if (depCity.Text.Trim().Length > 3)
        {
            IList departureAirPorts = _CommonService.FindAirportByCityName(depCity.Text.Trim());

            if (departureAirPorts.Count > 1)
            {
                IsSelectAirport = true;
                sc.FromAirports = departureAirPorts;
            }
            else if (departureAirPorts.Count == 1)
            {
                deptCondition.Departure = (Terms.Common.Domain.Airport)departureAirPorts[0];
            }
            else
            {

                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(depCity.Text.Trim(), airportList);
                if (airport != null)
                    deptCondition.Departure = airport;
                else
                    sc.IsRealFromCity = IsRealCity = false;
                //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDepCity.Value + "\"&GoToPage=~/index.aspx");
            }

        }
        else
        {
            deptCondition.Departure = AirService.CommAirportDao.FindByAirport(depCity.Text.Trim());

            if (deptCondition.Departure == null)
            {
                deptCondition.Departure = new Terms.Common.Domain.Airport();
                deptCondition.Departure.Code = depCity.Text.Trim();
            }
        }

        deptCondition.DepartureDate = GlobalUtility.GetDateTime(depFlightCalendar.CDate.Trim());

        sc.ToCityName = toCity.Text.Trim();
        if (toCity.Text.Trim().Length > 3)
        {
            IList destinationAirPorts = _CommonService.FindAirportByCityName(toCity.Text.Trim());

            if (destinationAirPorts.Count > 1)
            {
                IsSelectAirport = true;
                sc.ToAirports = destinationAirPorts;
            }
            else if (destinationAirPorts.Count == 1)
            {
                deptCondition.Destination = (Terms.Common.Domain.Airport)destinationAirPorts[0];
            }
            else
            {
                List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                Terms.Common.Domain.Airport airport = MatchAirport(toCity.Text.Trim(), airportList);
                if (airport != null)
                    deptCondition.Destination = airport;
                else
                    sc.IsRealToCity = IsRealCity = false;
                // Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtDesCity.Value + "\"&GoToPage=~/index.aspx");
            }

        }
        else
        {
            deptCondition.Destination = AirService.CommAirportDao.FindByAirport(toCity.Text.Trim());

            if (deptCondition.Destination == null)
            {
                deptCondition.Destination = new Terms.Common.Domain.Airport();
                deptCondition.Destination.Code = toCity.Text.Trim();
            }
        }



        AirTripCondition rtnCondition = new AirTripCondition();
        rtnCondition.Cabin = cabin;




        if (airSearchCondition.FlightType.ToLower().Equals("oneway"))
        {
            rtnCondition.Departure = deptCondition.Destination;
            rtnCondition.Destination = deptCondition.Departure;
            rtnCondition.DepartureDate = DateTime.MaxValue;
        }
        else if (airSearchCondition.FlightType.ToLower().Equals("roundtrip"))
        {
            rtnCondition.Departure = deptCondition.Destination;
            rtnCondition.Destination = deptCondition.Departure;
            rtnCondition.DepartureDate = GlobalUtility.GetDateTime(rtnFlightCalendar.CDate.Trim());
        }
        else if (airSearchCondition.FlightType.ToLower().Equals("openjaw"))
        {
            //rtnCondition.Departure = AirService.CommAirportDao.FindByAirport(txtRtnFrom.Value.Trim());
            //rtnCondition.Destination = AirService.CommAirportDao.FindByAirport(txtRtnTo.Value.Trim());
            rtnCondition.DepartureDate = GlobalUtility.GetDateTime(rtnFlightCalendar.CDate.Trim());
            sc.ReturnFromCityName = rtnFromCity.Text.Trim();
            if (rtnFromCity.Text.Trim().Length > 3)
            {
                IList returnFromAirPorts = _CommonService.FindAirportByCityName(rtnFromCity.Text.Trim());

                if (returnFromAirPorts.Count > 1)
                {
                    IsSelectAirport = true;
                    sc.ReturnFromAirports = returnFromAirPorts;
                }
                else if (returnFromAirPorts.Count == 1)
                {
                    rtnCondition.Departure = (Terms.Common.Domain.Airport)returnFromAirPorts[0];
                }
                else
                {
                    List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                    Terms.Common.Domain.Airport airport = MatchAirport(rtnFromCity.Text.Trim(), airportList);
                    if (airport != null)
                        rtnCondition.Departure = airport;
                    else
                        sc.IsRealReturnFromCity = IsRealCity = false;
                    //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnFrom.Value + "\"&GoToPage=~/index.aspx");
                }
            }
            else
            {
                rtnCondition.Departure = AirService.CommAirportDao.FindByAirport(rtnFromCity.Text.Trim());
                if (rtnCondition.Departure == null)
                {
                    rtnCondition.Departure = new Terms.Common.Domain.Airport();
                    rtnCondition.Departure.Code = rtnFromCity.Text.Trim();
                }
            }
            sc.ReturnToCityName = rtnToCity.Text.Trim();
            if (rtnToCity.Text.Trim().Length > 3)
            {
                IList returnToAirPorts = _CommonService.FindAirportByCityName(rtnToCity.Text.Trim());

                if (returnToAirPorts.Count > 1)
                {
                    IsSelectAirport = true;
                    sc.ReturnToAirports = returnToAirPorts;
                }
                else if (returnToAirPorts.Count == 1)
                {
                    rtnCondition.Destination = (Terms.Common.Domain.Airport)returnToAirPorts[0];
                }
                else
                {
                    List<Terms.Common.Domain.Airport> airportList = _ApplicationCacheFoundationDate.FindAllAirport();
                    Terms.Common.Domain.Airport airport = MatchAirport(rtnToCity.Text.Trim(), airportList);
                    if (airport != null)
                        rtnCondition.Destination = airport;
                    else
                        sc.IsRealReturnToCity = IsRealCity = false;
                    //Response.Redirect("ErrorMessage.aspx?ErrorMessage=We found no matches for \"" + this.txtRtnTo.Value + "\"&GoToPage=~/index.aspx");
                }

            }
            else
            {
                rtnCondition.Destination = AirService.CommAirportDao.FindByAirport(rtnToCity.Text.Trim());
                if (rtnCondition.Destination == null)
                {
                    rtnCondition.Destination = new Terms.Common.Domain.Airport();
                    rtnCondition.Destination.Code = rtnToCity.Text.Trim();
                }
            }
        }

        airSearchCondition.AddTripCondition(deptCondition);
        airSearchCondition.AddTripCondition(rtnCondition);


        //if (ddlAirline.SelectedItem.Text != "Search All Airlines")
        if (txtAirline.Text.Trim() != "")
        {
            //param.Airways = ddlAirline.SelectedValue.Split(',');
            airSearchCondition.Airlines = txtAirline.Text.Split(',');
        }

        sc.CurrentItinerary.SearchInfo = airSearchCondition;
        Utility.IsTourMain = false;//设置是否是Tour标志
        this.Transaction.IntKey = airSearchCondition.GetHashCode();
        this.Transaction.CurrentSearchConditions = airSearchCondition;
        this.Transaction.CurrentTransactionObject = new TERMS.Business.Centers.SalesCenter.TransactionObject();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_SearchFare_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;

        try
        {
            depCity.Text = ConvertName(depFullCity.Text);
            toCity.Text = ConvertName(toFullCity.Text);
            rtnFromCity.Text = ConvertName(rtnFromFullCity.Text);
            rtnToCity.Text = ConvertName(rtnToFullCity.Text);

            //log begin 20090312 Leon
            log.Info("\r\n");
            System.Random rd = new Random();

            Session["LOG_RANDOM"] = rd.Next(999999999);


            if (!Utility.IsLogin)
            {
                log.Info(Session["LOG_RANDOM"].ToString() + " >====================Not Login========================");
            }
            else
            {
                log.Info(Session["LOG_RANDOM"].ToString() + " >==========================Login========================");
            }
            string logAirline = txtAirline.Text.Trim().Equals(string.Empty) ? "All" : txtAirline.Text;
            log.Info(Session["LOG_RANDOM"].ToString() + " >==========================AirLine:" + logAirline + "========================");
            log.Info(Session["LOG_RANDOM"].ToString() + " >SearchClick Begin Start time : " + System.DateTime.Now);
            //log end 20090312 Leon
        }
        catch
        {

        }

        if (Utility.IsSubAgent)
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_SearchAir, this);
        else
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_SearchAir, this);

        Session["HasReminder"] = true;

        if (CheckSearch())
        {
            //if (!Page.IsValid)
            //    return;
            bool IsSelectAirport = false;
            bool IsRealCity = true;

            SetSearchCondition(ref IsRealCity, ref IsSelectAirport);

            if (ForbiddenAirportControl1.HasForbiddenAirport((SessionClass)Session["CurrentSession"]))
            {
                string[] arrayCtrlID = new string[2];
                arrayCtrlID[0] = ddlAdult.ClientID;
                arrayCtrlID[1] = ddlChild.ClientID;

                //ForbiddenAirportControl1.ShowMsgBox(arrayCtrlID, upSearch);
            }
            else
            {
                if (!IsRealCity)
                {
                    if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                    {
                        Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }

                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    if (IsSelectAirport)
                    {
                        Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        if (!Utility.IsLogin && Session["IndexForFlight"] == null)
                        {
                            Response.Redirect("~/IndexForFlight.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                        }

                        log.Info(Session["LOG_RANDOM"].ToString() + " >Redirect Searching.aspx Begin Start time : " + System.DateTime.Now);
                        Response.Redirect("~/Page/Flight/Searching.aspx?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                }
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Serarch", "<script>alert('Invaluable search condition.');</script>");
            return;
        }
    }

    /// <summary>
    /// Find if the Airport  should be Forbidden 
    /// </summary>



    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BulletedList1_Click(object sender, BulletedListEventArgs e)
    {
        //if (txtAirline.Text.Trim().Length - txtAirline.Text.Replace(",", "").Trim().Length < 4)
        //{
        //    if (txtAirline.Text.Trim() != "")
        //    {
        //        //txtAirline.Text = "";
        //        if ( txtAirline.Text.IndexOf( BulletedList1.Items[e.Index].Value ) < 0 )
        //        {
        //            txtAirline.Text = txtAirline.Text + "," + BulletedList1.Items[e.Index].Value;
        //        }
        //    }
        //    else
        //    {
        //        txtAirline.Text = BulletedList1.Items[e.Index].Value;
        //    }
        //}

        //if (rdbRoundTrip.Checked == true)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangeFlightType", "<script>ChangeFlightType('roundtrip');</script>");
        //}
        //else if (rdbOneway.Checked == true)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangeFlightType", "<script>ChangeFlightType('oneway');</script>");
        //}
        //else if (rdbOpenjaw.Checked == true)
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "ChangeFlightType", "<script>ChangeFlightType('openjaw');</script>");
        //}
    }

    /// <summary>
    /// 验证输入框是否合法
    /// </summary>
    private bool CheckSearch()
    {
        if (depCity.Text.Trim() == ""
            || toCity.Text.Trim() == ""
            || depFlightCalendar.CDate.Trim() == "")
        {
            return false;
        }

        if (rdbOneway.Checked == false)
        {
            oneway1.Style["display"] = "";
            oneway2.Style["display"] = "";

            if (rdbOpenjaw.Checked == true)
            {
                if (rtnFromCity.Text.Trim() == ""
                    || rtnToCity.Text.Trim() == "")
                {
                    return false;
                }
            }
            else
            {
                // It is Round Trip and set as same as DEP AND DES
                this.rtnFromCity.Text = toCity.Text;
                this.rtnToCity.Text = depCity.Text;
            }

            if (!rtnFlightCalendar.CDate.Equals(string.Empty)
                && (Convert.ToDateTime(rtnFlightCalendar.CDate) <= Convert.ToDateTime(depFlightCalendar.CDate)))
            {
                return false;
            }
        }

        if (ddlAdult.Text == "0"
            && ddlChild.Text == "0"
            && ddlInfant.Text == "0")
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Read only the Component if need
    /// </summary>
    private void DoReadOnly2Component(bool bclFlag)
    {

    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();

        if (CalendarPath != string.Empty)
        {
            depFlightCalendar.Path = rtnFlightCalendar.Path = CalendarPath;
        }
        else if (Utility.IsSubAgent)
        {
            depFlightCalendar.Path = rtnFlightCalendar.Path = "../";
        }
        else
        {
            depFlightCalendar.Path = rtnFlightCalendar.Path = "";
        }

        if (!Page.IsPostBack)
        {
            Initial();
        }

    }

    public static string InputText(string text)
    {
        text = text.Trim();
        if (string.IsNullOrEmpty(text))
            return string.Empty;
        text = Regex.Replace(text, "[\\s]{2,}", " ");    //two or more spaces
        text = Regex.Replace(text, "(<[b|B][r|R]/*>)+|(<[p|P](.|\\n)*?>)", "\n");    //<br>
        text = Regex.Replace(text, "(\\s*&[n|N][b|B][s|S][p|P];\\s*)+", " ");    //&nbsp;
        text = Regex.Replace(text, "<(.|\\n)*?>", string.Empty);    //any other tags
        text = text.Replace("'", "''");
        return text;
    }

    public String EncryptPassword(String password)
    {
        char[] data = password.ToCharArray();
        byte[] binData = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            binData[i] = (byte)data[i];
        }

        MD5 md5 = new MD5CryptoServiceProvider();

        byte[] binResult = md5.ComputeHash(binData);
        String result = null;
        foreach (byte b in binResult)
        {
            result += Convert.ToString(b, 16);
        }

        return result;
    }

    private string ConvertName(string fullname)
    {
        int index = fullname.IndexOf("-");

        if (index > 0)
        {
            int end = fullname.Substring(index + 1).IndexOf(",");

            if (end > 0)
            {
                return fullname.Substring(index + 1, end).Trim();
            }
            else
            {
                return fullname.Substring(index + 1).Trim();
            }
        }
        else
        {
            return fullname.Trim();
        }
    }
}
