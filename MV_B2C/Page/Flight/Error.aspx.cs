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

public partial class Error : AirBook.Base.BookingPage
{
    protected void Page_Load(object sender, EventArgs e)
		{
            Master.IsShowBookingManage = false;
            Master.IsShowModifySearch = true;
			try
			{
                if (SessionExpired)
				{
                    LblErrorInfo.Text = "The search condition has been removed from cache, please re-search.";
                    lblMessage.Text = "Error Message.";
                    return;
					
				}

				InitErr();
			}
			catch(Exception Ex)
			{
				log.Error(Ex.Message,Ex);
			}
		}
		

		#region User Define Event

		/// <summary>
		/// Init the Err Page
		/// </summary>
		/// <returns>bool</returns>
		private void InitErr()
		{
			string [] errInfo	= new string[3];
			errInfo				= (string[])Session["Error"];
            SessionClass sc = (SessionClass)Session["CurrentSession"];

            AirSearchCondition airSearchCondition = null;

            if (this.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                airSearchCondition = (AirSearchCondition)this.Transaction.CurrentSearchConditions;
            }
            else if (this.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                airSearchCondition = ((PackageSearchCondition)this.Transaction.CurrentSearchConditions).AirSearchCondition;
            }
            else
            {
                return;
            }

            switch (errInfo[1])
            {
                case "No Flight":
                    if (airSearchCondition.FlexibleDays == 1)
                    {
                        LblErrorInfo.Text = "No Flight Available.&nbsp;&nbsp;<BR>"
                            + "&nbsp;&nbsp;Please re-seach or call our experienced Sale Agents at 1-(888)-288-7528.&nbsp;&nbsp;Thank You!!";
                    }
                    else
                    {
                        LblErrorInfo.Text = "No Flight Available,&nbsp;&nbsp;"
                            + "Please check our flexible search box (+/-1 day)&nbsp;<BR>"
                            + "&nbsp;&nbsp;and then re-seach or call our experienced Sale Agents at 1-(888)-288-7528.&nbsp;&nbsp;Thank You!!";
                    }

                    lblMessage.Text = "Search Results";
                    break;
                case "Invalidate Routing":
                    LblErrorInfo.Text = "Invalidate Routing.";
                    lblMessage.Text = "Result Infomation.";
                    break;
                case "Search Again":
                    LblErrorInfo.Text = "Search Again.";
                    lblMessage.Text = "Search Infomation.";
                    break;
                case "WSPreorderException":
                    if (errInfo[0].IndexOf("UNABLE TO PRICE AS BOOKED") > -1)
                        LblErrorInfo.Text = "Booking failed.&nbsp;&nbsp; Please re-Booking or call our experienced Sale Agents at 1-(888)-288-7528.&nbsp;&nbsp;Thank You!!";
                    else
                        LblErrorInfo.Text = errInfo[0];
                    lblMessage.Text = "Booking failed.";
                    break;
                case "WSBookingException":
                    if (errInfo[0].IndexOf("EXPIRED CARD") > -1 || errInfo[0].IndexOf("INVLD ACCT NUMBER") > -1 || errInfo[0].IndexOf("UNABLE TO PRICE AS BOOKED") > -1)
                        LblErrorInfo.Text = "Invalide Credit Card.  Please go back to previous screen and change your payment info.&nbsp;&nbsp;Thanks.";
                    else if (errInfo[0].IndexOf("INVALID PASSENGER DATA") > -1)
                        LblErrorInfo.Text = "Invalide Passenger.&nbsp;&nbsp; Please go back to previous screen and change your Passenger info.&nbsp;&nbsp;Thanks.";
                    else if (errInfo[0].IndexOf("FARE LOAD IN PROGRESS") > -1 || errInfo[0].IndexOf("RETRY ENTRY LATER") > -1 || errInfo[0].IndexOf("SEGMENTS NOT AVAILABLE") > -1)
                        LblErrorInfo.Text = "Booking failed.&nbsp;&nbsp;&nbsp;Please re-Booking or call our experienced Sale Agents at 1-(888)-288-7528.&nbsp;&nbsp;&nbsp;Thank You!!.";
                    lblMessage.Text = "Booking failed.";
                    break;
                case "Loign error":
                    LblErrorInfo.Text = errInfo[0];
                    lblMessage.Text = "Login error,&nbsp;&nbsp;please try again.";
                    break;
                case "Insert DB Error":
                    LblErrorInfo.Text = errInfo[0];
                    lblMessage.Text = "Insert DB error,&nbsp;please try again.";
                    break;
                case "Booking failed":
                    LblErrorInfo.Text = "Booking failed.&nbsp;&nbsp; Please re-Booking or call our experienced Sale Agents at 1-(888)-288-7528.&nbsp;&nbsp;Thank You!!";
                    lblMessage.Text = "Booking failed.";
                    break;
                case "Unknow Error":
                    LblErrorInfo.Text = "Unknow Error.&nbsp;&nbsp; Please re-seach or call our experienced Sale Agents at 1-(888)-288-7528.&nbsp;&nbsp;Thank You!!";
                    lblMessage.Text = "Search Infomation.";
                    break;

                default:
                    LblErrorInfo.Text = errInfo[0];
                    lblMessage.Text = "Error Message.";
                    break;
            }
        }
		#endregion

	}

