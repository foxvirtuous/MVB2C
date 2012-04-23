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
using System.Text;
using System.Collections.Specialized;

using Spring.Context;
using Spring.Context.Support;
using Terms.Common.Service;
using Terms.Common.Domain;
using Terms.Sales.Service;
public partial class LocationQuickSearchForm : System.Web.UI.Page
{
    private HybridDictionary PreSave
    {
        get
        {
            if (Session["PreSave"] == null)
                Session["PreSave"] = new HybridDictionary();

            return (HybridDictionary)Session["PreSave"];
        }
        set
        {
            Session["PreSave"] = value;
        }
    }




    protected void Page_Load(object sender, EventArgs e)
    {
       if (Request.QueryString["query"] != null)
        {
            string query = Request["query"].ToString();

            //Cache
            if (PreSave.Contains(query))
            {
                Response.Write((string)PreSave[query]);
                return;
            }

            //Result Amount
            int amount = 20;
            try
            {
                amount = (Request["results"] != null ? Convert.ToInt32(Request["results"]) : 20);
            }
            catch
            {
                amount = 20;
            }

            //Get Result
            try
            {
                IApplicationContext ctx = ContextRegistry.GetContext();

                ICommonService commonService = ctx["CommonService"] as ICommonService;

                IApplicationCacheFoundationDate applicationCacheFoundationDate = ctx["ApplicationCacheFoundationDate"] as IApplicationCacheFoundationDate;

                List<Terms.Common.Domain.Airport> airportList = applicationCacheFoundationDate.FindAllAirport();

                List<Terms.Common.Domain.Airport> matcheAirportList = GetMatcheAirport(query, airportList);

                StringBuilder content = new StringBuilder();

                //Json Data Begin
                content.Append("{\"ResultSet\":{\"Result\":[");

                for (int i = 0; i < matcheAirportList.Count; i++)
                {

                    Terms.Common.Domain.Airport airport = (Terms.Common.Domain.Airport)matcheAirportList[i];
                    City city = (City)airport.City;
                    //CommCountryMeta nation = (CommCountryMeta)commonService.FindCountryById(city.CountryCode);
                    Country nation = (Country)city.Country;
                    content.Append("{\"AirportName\":\"" + airport.Name + "\",\"AirportCode\":\"" + airport.Code + "\",\"city\":\"" + city.Name + "\",\"state\":\"" + city.ProvinceName + "\",\"nation\":\"" + (nation.Code.Trim().Length == 0 ? nation.Name : nation.Code) + "\"},");

                }

                if (content.ToString().IndexOf(",") > -1)
                    content.Remove(content.Length - 1, 1);

                //Json Data End
                content.Append("]}}");

                //Cache
                PreSave.Add(query, content.ToString());

                Response.Write(content.ToString());
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }


    private List<Terms.Common.Domain.Airport> GetMatcheAirport(string name, List<Terms.Common.Domain.Airport> airportList)
    {
        List<Terms.Common.Domain.Airport> matchAirportList = new List<Terms.Common.Domain.Airport>();

        foreach (Terms.Common.Domain.Airport airport in airportList)
        {
            if (airport.Name.ToLower().Contains(name))
                matchAirportList.Add(airport);
            else
            {
                if (airport.City.Name.ToLower().Contains(name))
                    matchAirportList.Add(airport);
            }
        }
        return matchAirportList;
    }
}
