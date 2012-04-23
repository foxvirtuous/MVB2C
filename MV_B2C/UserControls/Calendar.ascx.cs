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
using System.Text;

public partial class TermsCalendar : System.Web.UI.UserControl
{
    private string path = string.Empty;
    public string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }
    private string _cDate = string.Empty;
    public string CDate
    {
        get { return _cDate; }
        set { _cDate = value; }
    }
   
    //private string[] _arrDate;
    //public string[] ArrDate
    //{
    //    get { return _arrDate; }
    //    set { _arrDate = value; }
    //}


    private bool _isAvailableDate = true;
    public bool IsAvailableDate
    {
        get { return _isAvailableDate; }
        set { _isAvailableDate = value; }
    }

    private string _lowerLimitID = string.Empty;
    public string LowerLimitID
    {
        get { return _lowerLimitID; }
        set { _lowerLimitID = value; }
    }

    private string _IsLowerRepeatDate = "0";
    public string IsLowerRepeatDate
    {
        set { _IsLowerRepeatDate = value; }
        get { return _IsLowerRepeatDate; }
    }

    private string _IsUpperRepeatDate = "0";
    public string IsUpperRepeatDate
    {
        set { _IsUpperRepeatDate = value; }
        get { return _IsUpperRepeatDate; }
    }

    private string _upperLimitID = string.Empty;
    public string UpperLimitID
    {
        get { return _upperLimitID; }
        set { _upperLimitID = value; }
    }

    private bool _IsCoercion = false;
    public bool IsCoercion
    {
        set { _IsCoercion = value; }
        get { return _IsCoercion; }
    }

    private string _coercionID = string.Empty;
    public string CoercionID
    {
        get { return _coercionID; }
        set { _coercionID = value; }
    }


    private DateTime _beginDate = DateTime.Now;
    public DateTime BeginDate
    {
        get { return _beginDate; }
        set { _beginDate = value; }
    }

    private DateTime _endDate = DateTime.Now.AddYears(1);
    public DateTime EndDate
    {
        get { return _endDate; }
        set { _endDate = value; }
    }
    public string IFrameName = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.aCal.HRef = "javascript:SetCal(this,'" + this.ClientID + "')";

        //this.calendarDate.Text = CDate;
        CDate = this.calendarDate.Text;
        //this.calendarDateFrame.Attributes.Add("src", Path + "CommJS/Mvcalx.htm");
        //IFrameName = calendarDateFrame.ClientID;
        //×¢²á½Å±¾

        StringBuilder script1 = new StringBuilder();
        script1.Append("<script language='javascript'>");
        script1.Append(" var dateRangeKey = new Array(); var dateRangeValue = new Array();var dateLimitValue = new Array();");
        script1.Append("</script>");


        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "SetCalendarMainArray", script1.ToString());

        StringBuilder script = new StringBuilder();
        script.Append("<script language='javascript'>");
        script.Append(CalendarDateRangeArray());
        script.Append("</script>");


        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), this.ClientID.ToString(), script.ToString());

        if (this.IsCoercion)
        {
            string CoercionClientID = this.CoercionID.Equals(string.Empty) ? string.Empty : this.calendarDate.ClientID.Replace(this.ID, this.CoercionID);
            //script = new StringBuilder();
            //script.Append("<script language='javascript'>");
            //script.Append("function SetCoercion() {document.getElementById('" + CoercionClientID + "').value= document.getElementById('" + this.calendarDate.ClientID + "').value;}");
            //script.Append("</script>");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Startup", script.ToString());

            calendarDate.Attributes.Add("onblur", "SetCoercion('" + CoercionClientID + "','" + this.calendarDate.ClientID + "');");
        }
    }
    protected string CalendarDateRangeArray()
    {
        string strDate = string.Empty;
        if (IsAvailableDate)
        {
            if (!this.strDateRange.Equals(string.Empty))
            {

                strDate = strDateRange.Substring(0,strDateRange.Length -1);
               

            }
            else
            {
                strDate = "'" + BeginDate.ToString("MM/dd/yyyy") + "|" + EndDate.ToString("MM/dd/yyyy") + "'";
            }
        }
        else
        {
            strDate = GetIntersectionDate();
        }
        string lowerLimitClientID = this.LowerLimitID.Equals(string.Empty)?string.Empty:this.calendarDate.ClientID.Replace(this.ID, this.LowerLimitID);
        string upperLimitClientID = this.UpperLimitID.Equals(string.Empty) ? string.Empty : this.calendarDate.ClientID.Replace(this.ID, this.UpperLimitID);
        ////if (lowerLimitClientID != null && IsRepeatDate == true)
        ////{
        ////    string[] temp = strDate.Split('|');
        ////    strDate = string.Empty + "'";
        ////    temp[0] = Convert.ToDateTime(temp[0].Substring(1,temp[0].Length-1)).AddDays(-1).ToString("MM/dd/yyyy");
        ////    foreach (string str in temp)
        ////    {
        ////        strDate += str + "|";
        ////    }
        ////    strDate = strDate.Substring(0,strDate.Length-1);
        ////}
        string limintKey = lowerLimitClientID + "|" + upperLimitClientID + "|" + IsLowerRepeatDate + "|" + IsUpperRepeatDate;
        string strRange = string.Empty;
        strRange += "dateRangeKey.push('" + this.calendarDate.ClientID + "');";
        strRange += "dateRangeValue.push(Array(" + strDate + "));";
        strRange += "dateLimitValue.push('"+limintKey+"')";
        return strRange;
    }

    protected string GetIntersectionDate()
    {
        DateTime beginDate = this.BeginDate;
        DateTime endDate = this.EndDate;
        string strAvailableDate = string.Empty;
        string[] arrDate = DoSort(strDateRange.Substring(0, strDateRange.Length - 1).Split(','));
       
        for (int i = 0; i < arrDate.Length; i++)
        {
            string[] temp = arrDate[i].Split('|');

            string[] mdy = temp[0].Trim().Replace('-','/').Substring(1).Split('/');
            string[] mdy2 = temp[1].Trim().Replace('-','/').Substring(0, temp[1].Length - 1).Split('/');
            DateTime dt = new DateTime(Convert.ToInt32(mdy[2]),Convert.ToInt32(mdy[0]), Convert.ToInt32(mdy[1]));
            DateTime dt2 = new DateTime(Convert.ToInt32(mdy2[2]), Convert.ToInt32(mdy2[0]), Convert.ToInt32(mdy2[1]));
            if (((TimeSpan)dt.Subtract(beginDate)).Days > 0)
            {
                strAvailableDate = strAvailableDate + "'" + beginDate.ToString("MM/dd/yyyy") + "|" + dt.AddDays(-1).ToString("MM/dd/yyyy") + "',";
                
            }
            beginDate = dt2.AddDays(1);
        }
        if (((TimeSpan)endDate.Subtract(beginDate)).Days >= 0)
        {
            strAvailableDate = strAvailableDate + "'" + beginDate.ToString("MM/dd/yyyy") + "|" + endDate.ToString("MM/dd/yyyy") + "'";
        }
        else
        {
            strAvailableDate = strAvailableDate.Substring(0, strAvailableDate.Length - 1);
        }


        return strAvailableDate;
    }
    protected string[] DoSort(string[] old)
    {
        for (int i = 0; i < old.Length; i++)
        {
            for (int j = i+1; j < old.Length; j++)
            {
                string[] temp = old[i].Split('|');
                string[] temp2 = old[j].Split('|');
                string midTemp = string.Empty;
                string[] mdy = temp[0].Trim().Replace('-', '/').Substring(1).Split('/');
                string[] mdy2 = temp2[0].Trim().Replace('-', '/').Substring(1).Split('/');
                DateTime dt = new DateTime(Convert.ToInt32(mdy[2]), Convert.ToInt32(mdy[0]), Convert.ToInt32(mdy[1]));
                DateTime dt2 = new DateTime(Convert.ToInt32(mdy2[2]), Convert.ToInt32(mdy2[0]), Convert.ToInt32(mdy2[1]));
                if (((TimeSpan)Convert.ToDateTime(dt).Subtract(dt2)).Days > 0)
                {
                    midTemp = old[i];
                    old[i] = old[j];
                    old[j] = midTemp;
                }
            }

        }
        return old;
    }
    public void AddDate(DateTime bDate, DateTime eDate)
    {
        strDateRange = strDateRange + "'" + bDate.ToString("MM/dd/yyyy") + "|" + eDate.ToString("MM/dd/yyyy") + "',";
    }
     
    public void AddDate(DateTime bDate)
    {
        AddDate(bDate, bDate);
    }
    protected string strDateRange = string.Empty;

    
}
