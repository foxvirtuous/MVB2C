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
using System.Net.Mail;
using System.IO;

public partial class SuccessSubIncentiveTourForm : SalseBasePage
{
    public SuccessSubIncentiveTourForm()
    {
        this.PreRender += new EventHandler(SuccessSubIncentiveTourForm_PreRender);
    }

    void SuccessSubIncentiveTourForm_PreRender(object sender, EventArgs e)
    {
        if (Request.Params["IsFinised"] != null
            && Request.Params["IsFinised"].ToString().Trim().Length > 0)
        {
            string temp = this.flagSearch.Value;

            SendEmail(temp);
        }
        else
        {
            Button1_Click(new object(), new EventArgs());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(this.GetType(), "Searching", "<script>OnSearch();</script>");
    }

    private void SendEmail(string emailboby)
    {
        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        mailMessage.To.Add(new MailAddress(SendEmailSubIncentiveTourControl1.Email));
        mailMessage.IsBodyHtml = true;

        mailMessage.Subject = SendEmailSubIncentiveTourControl1.CaseNumber + "(B2C - Preliminary Confirmation)";

        mailMessage.Body = emailboby;


        try
        {
            using (StreamWriter sw = File.CreateText("c:\\OrderEmail\\IncentiveTour.html"))
            {
                sw.Write(mailMessage.Body);
            }
        }
        catch
        {

        }

        Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "IncentiveTour");
    }
}
