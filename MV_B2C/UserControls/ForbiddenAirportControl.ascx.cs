
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
using Terms.Sales.Business;
using System.Collections.Generic;





public partial class ForbiddenAirportControl : SalesBaseUserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Find if the Airport  should be Forbidden 
    /// </summary>
    public bool HasForbiddenAirport(SessionClass sc)
    {
        if (ConfigurationManager.AppSettings.Get("ForbiddenAirport") != null)
        {
            IList<Terms.Common.Domain.Airport> m_AllAirportList = new List<Terms.Common.Domain.Airport>();

            if (sc.ToAirports != null && sc.ToAirports.Count>0)
            {
                foreach (Terms.Common.Domain.Airport apt in sc.ToAirports)
                {
                    m_AllAirportList.Add(apt);
                }

            }
            if (sc.FromAirports != null && sc.FromAirports.Count>0)
            {
                foreach (Terms.Common.Domain.Airport apt in sc.FromAirports)
                {
                    m_AllAirportList.Add(apt);
                }

            }
            if (sc.ReturnToAirports != null && sc.ReturnToAirports.Count>0)
            {
                foreach (Terms.Common.Domain.Airport apt in sc.ReturnToAirports)
                {
                    m_AllAirportList.Add(apt);
                }

            }

            if (sc.ReturnFromAirports != null && sc.ReturnFromAirports.Count>0)
            {
                foreach (Terms.Common.Domain.Airport apt in sc.ReturnFromAirports)
                {
                    m_AllAirportList.Add(apt);
                }

            }

            foreach (AirTripCondition airTripCondition in ((AirSearchCondition)sc.CurrentItinerary.SearchInfo).GetAddTripCondition())
            {
                if (airTripCondition.Departure!=null)
                    m_AllAirportList.Add(airTripCondition.Departure);
                if (airTripCondition.Destination != null)
                    m_AllAirportList.Add(airTripCondition.Destination);

            }


            if (m_AllAirportList != null && m_AllAirportList.Count > 0)
            {
                foreach (Terms.Common.Domain.Airport airport in m_AllAirportList)
                {
                    if (ConfigurationManager.AppSettings.Get("ForbiddenAirport").ToString().ToUpper().Contains(airport.Code.ToUpper()))
                    {
                       
                        return true;
                    }
                }
            }

        }

        return false;
    }

    public void ShowMsgBox(string[] ctrlID, Control upSearch)
    {
        lblCurrentMsg.Text = Resources.HintInfo.HasForbiddenAirport;
        pnlComfirm.Attributes.Add("style", "display:block;");
        
        string strScript = string.Empty;
        strScript = "<script>";

        for (int i = 0; i < ctrlID.Length; i++)
        {
           
            strScript += "var ddl" + i + " ='" + ctrlID[i] + "';";

            strScript += "$('" + ctrlID[i] + "').style.visibility='hidden';";

        }
            
        strScript += "positionUpdatePanelForSearch();";
        strScript += "var pnlComfirmClientID ='" + pnlComfirm.ClientID + "';";
       
        strScript += "</script>";
        ScriptManager.RegisterStartupScript(upSearch, upSearch.GetType(), "HiddenSerarchDropDownList",strScript , false);
    }

}

