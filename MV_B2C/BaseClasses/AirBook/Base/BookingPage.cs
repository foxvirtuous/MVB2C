using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using Terms.Product.Domain;

namespace AirBook.Base
{
    public class BookingPage : SalseBasePage
    {
        protected string PATH = "";

        public bool flagSession = false;

         protected SessionClass CurrentSession
        {
            get
            {
                if (Session["CurrentSession"] == null)
                {
                    Session["CurrentSession"] = new SessionClass();
                    flagSession = true;
                }

                return (SessionClass)Session["CurrentSession"];
            }
            set
            {
                Session["CurrentSession"] = value;
            }
        }

        protected new bool SessionExpired
        {
            get
            {
                if (Session["CurrentSession"] == null)
                    return true;
                else
                    return false;
            }
        }

        protected void Err(string error, string errorFlag, string ErrPageName)
        {
            string[] errorMessage = new string[3];

            errorMessage[0] = error;
            errorMessage[1] = errorFlag;
            errorMessage[2] = ErrPageName;

            Session["Error"] = errorMessage;
            Response.Redirect(PATH + "Error.aspx");
        }

        //Add By Ben **********
        protected static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected int StepNumber = 1;
        protected bool IsShowBookingManage = false;
        protected bool IsShowModifySearch = false;
    }
}
