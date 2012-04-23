<%@ Import namespace="log4net"%>
<%@ Import namespace="log4net.Config"%>
<%@ Import namespace="Terms.Base.Service"%>
<%@ Import namespace="Spring.Context"%>
<%@ Import namespace="Spring.Context.Support"%>
<%@ Import namespace="Terms.Sales.Service"%>
<%@ Import namespace="Terms.Material.Service"%>
<%@ Import namespace="System.Data"%>
<%@ Import Namespace="System.IO"%>
<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
       AirService airService = new AirService();
        string ErrorMessage;
        // Declare a Session Info
        Hashtable CommAirportHash = new Hashtable();
        if (Application["COMMAIRPORTCODE"] == null)
        {
            DataSet dtSet = airService.GetCommCityCode();
            DataTable dtTable = dtSet.Tables[0];
            foreach (DataRow dtRow in dtTable.Rows)
            {
                if (!CommAirportHash.ContainsKey(dtRow["OCityCode"].ToString()))
                    CommAirportHash.Add(dtRow["OCityCode"].ToString(), dtRow["SameCityCode"].ToString());
            }
            Application["COMMAIRPORTCODE"] = CommAirportHash;
        }
        else
        {
            CommAirportHash = (Hashtable)Application["COMMAIRPORTCODE"];
        }
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown
    }

    void Application_Error(object sender, EventArgs e)
    {
        try
        {
            bool ShieldError = true;

            if (System.Configuration.ConfigurationManager.AppSettings["ShieldError"] != null)
                ShieldError = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["ShieldError"]);

            if (ShieldError)
            {
                string currentSearchConditionText = string.Empty;

                //记录当前的Search条件
                if (Context.Session != null)
                    if (Utility.Transaction != null && Utility.Transaction.CurrentSearchConditions != null)
                        currentSearchConditionText = Utility.Transaction.CurrentSearchConditions.ToString();

                //记录当前错误的请求页面 Add zyl 2009-8-18
                if (this.Request != null && this.Request.RawUrl != null)
                {
                    currentSearchConditionText += " \n\r " + this.Request.RawUrl;

                    currentSearchConditionText += " \n\r this error date time : " + DateTime.Now.ToString("MM/dd/yyyy H:mm:ss");

                    if (Context != null && Context.Session != null)
                    {
                        if (Utility.Transaction != null)
                        {
                            if (Utility.Transaction.CurrentSearchConditions != null)
                            {
                                currentSearchConditionText += " \n\r this SearchCondition is " + Utility.Transaction.CurrentSearchConditions.GetType().ToString();
                            }
                            else
                            {
                                currentSearchConditionText += "this Utility.Transaction.CurrentSearchConditions is null";
                            }
                        }
                        else
                        {
                            currentSearchConditionText += "this Utility.Transaction is null";
                        }
                    }
                    else
                    {
                        currentSearchConditionText += "this Context or Context.Session is null";
                    }
                }

                DoErrorProcess(Context.Error, currentSearchConditionText);
                Context.ClearError();

                if (!Request.Url.ToString().Contains("ErrorPages/GenericErrorPage.aspx"))
                {
                    Response.Redirect("~/ErrorPages/GenericErrorPage.aspx", true);
                }
            }
        }
        catch (Exception ex)
        {

        }
    }

    private void DoErrorProcess(Exception ex, string currentSearchConditionText)
    {
        string pageName = string.Empty;
        pageName = Request.Url.ToString().Split('/')[Request.Url.ToString().Split('/').Length - 1];
        Spring.Aspects.Error.SystemErrorAdvice systemErrorAdvice = new Spring.Aspects.Error.SystemErrorAdvice();
        systemErrorAdvice.DoErrorProcess(this, pageName, ex, "ApplicationError", currentSearchConditionText);
    }

//    private string GetCurrentSearchConditionText(TERMS.Common.Search.ISearchCondition searchCondition)
//    {
//        string result = string.Empty;
        
//        if (Utility.Transaction.CurrentSearchConditions is Terms.Sales.Business.AirSearchCondition)
//        {
//            Terms.Sales.Business.AirSearchCondition airSC = (Terms.Sales.Business.AirSearchCondition)Utility.Transaction.CurrentSearchConditions;
//            result = string.Format(@"from: {0}  to:{1} \n\r
//depart date: {2}  return date: {3} \n\r
//adult #: {4} child #: {5} \n\r
//Class: {6} Airport Code: {7}",
//                             airSC.GetAddTripCondition()[0].Departure.Code,
//                             airSC.GetAddTripCondition()[0].Destination.Code,
//                             airSC.GetAddTripCondition()[0].DepartureDate,
//                             airSC.GetAddTripCondition()[airSC.AirTripCondition.Count - 1].DepartureDate,
//                             airSC.GetPassengerNumber(TERMS.Common.PassengerType.Adult),
//                             airSC.GetPassengerNumber(TERMS.Common.PassengerType.Child),
//                             airSC.GetAddTripCondition()[0].Cabin,
//                             airSC.Airlines);
//        }

//        return result;
//    }



    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

        OnloadFoundationData();
        OnloadErrorMessage();

        //add by Leon at 2010-2-8
        //Reload airports and cities to auto locations
        IApplicationContext ctx = ContextRegistry.GetContext();
        IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;
        if (Application["ALLAIRPORTSCODE"] == null || Application["ALLCITYSCODE"] == null)
        {
            //First step, load all airports and cities to the Application 
            //load airports
            System.Collections.Generic.List<Terms.Common.Domain.Airport> airports = applicationCacheFoundationDate.FindAllAirport();

            string strAirports = string.Empty;

            for (int index = 0; index < airports.Count; index++)
            {
                strAirports += airports[index].Name.Replace(@"-", " ").Replace(@",", " ") + " - " + airports[index].Code + " , " + airports[index].City.Name.Replace(@"-", " ") + " , " + airports[index].City.CountryCode + " ||";
            }
            if (strAirports.Length > 2)
                Application["ALLAIRPORTSCODE"] = strAirports.Substring(0, strAirports.Length - 2);
            else
                Application["ALLAIRPORTSCODE"] = null;

            //load cities
            System.Collections.Generic.List<Terms.Common.Domain.City> Citys = applicationCacheFoundationDate.FindAllCity();

            string strCitys = string.Empty;

            for (int index = 0; index < Citys.Count; index++)
            {
                strCitys += Citys[index].Name.Replace(@"-", " ").Replace(@",", " ") + " - " + Citys[index].Code + " , " + Citys[index].CountryCode + " || ";
            }
            if (strCitys.Length > 2)
                Application["ALLCITYSCODE"] = strCitys.Substring(0, strCitys.Length - 2);
            else
                Application["ALLCITYSCODE"] = null;

            //Second step, write airports and cities to js file
            string virtualPath = HttpContext.Current.Request.ApplicationPath;
            if (virtualPath.Substring(virtualPath.Length - 1, 1) != @"\") virtualPath = virtualPath + @"\";
            string physicalPath = Server.MapPath(virtualPath + @"CommJs\AutoLocationData.js");

            try
            {
                using (FileStream fs = new FileStream(physicalPath, FileMode.Create, FileAccess.ReadWrite))
                {
                    StreamWriter sw = new StreamWriter(fs, Encoding.ASCII);
                    sw.Write("var arrAutoAirportList=new Array();var arrAutoCityList=new Array();function InitCityAndAirport(){var strAirport = \"" +
                        Application["ALLAIRPORTSCODE"].ToString() + "\";var strCity = \"" +
                        Application["ALLCITYSCODE"].ToString() + "\";arrAutoAirportList = strAirport.split('||');arrAutoCityList = strCity.split('||');}");
                    sw.Close();
                }
            }
            catch(Exception ex)
            {
                string temp = string.Empty;
            }
        }
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    private void OnloadFoundationData()
    {
        IApplicationCacheFoundationDate ApplicationCacheFoundationDate = ContextRegistry.GetContext()["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

        ApplicationCacheFoundationDate.FillCache();
    }

    private void OnloadErrorMessage()
    {
        //IErrorMessageService errorMessageService;  
        
        //// 信息列表已经存在，返回
        //if (Application["msgList"] != null)
        //{
        //    return;
        //}

        //IList errMsgList = null;

        //errorMessageService = ContextRegistry.GetContext()["ErrorMessageService"] as IErrorMessageService;
        //errMsgList = errorMessageService.FindErrMsgAll();
        //Object msg = (Object)errMsgList;
        //Application.Add("msgList", msg);
        //Session["errMsgList"] = errMsgList;
    }
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        if (Request.HttpMethod == "GET")
        {
            if (Request.AppRelativeCurrentExecutionFilePath.EndsWith(".aspx"))
            {
                if (!Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("tourindex.aspx") &&
                    !Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("promo090319.aspx") &&
                    !Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("promo090417.aspx") &&
                    !Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("index.aspx"))
                {
                    Response.Filter = new ScriptDeferFilter(Response);
                }
            }
        }

        if (Request.HttpMethod == "GET")
        {
            if (Request.AppRelativeCurrentExecutionFilePath.EndsWith(".aspx"))
            {
                try
                {

                    Response.Filter = new ScriptDeferFilter(Response);
                }
                catch
                {

                }
                bool IsEnableSSL = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["EnableSsl"]);
                if (IsEnableSSL)
                {
                    if (Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("traveler-payment") ||
                        Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("booking-success") ||
                        Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("booking-redirect") ||
                         Request.AppRelativeCurrentExecutionFilePath.ToLower().Contains("saveorderwaiting"))
                    {
                        try
                        {
                            //http ->https
                            Response.Filter = new ExchangeHTTP(Response, "https");
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        try
                        {
                            //https->http
                            Response.Filter = new ExchangeHTTP(Response, "http");

                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }   
</script>
