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

using log4net;
using Spring.Web.UI;

using Terms.Member.Dao;
using Terms.Member.Service;
using Terms.Member.Domain;
using Terms.Member.Utility;

public partial class SalesEmailpassword : SalseBasePage
{
    private IMemberInformationService _MemberInformationService;
    public IMemberInformationService MemberInformationService
    {
        set
        {
            this._MemberInformationService = value;
        }
    }

    public string ReturnUrl
    {
        get
        {
            return this.Request["ReturnUrl"];
        }

    }

    public SalesEmailpassword()
    {
        this.InitializeControls += new EventHandler(SalesEmailpassword_InitializeControls);
    }

    void SalesEmailpassword_InitializeControls(object sender, EventArgs e)
    {
        
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Terms.Member.Business.MemberInformation memberInformation = _MemberInformationService.FindMemberInformationByUserName(this.txtEmail.Text.Trim());

        if (memberInformation == null)
        {
            lblErrorMassage.Visible = true;
            lblErrorMassage.Text = "The e-mail address you provided was not recognized. Please try again.";

            return;
        }

        Random ran = new Random();
        String password = ran.GetHashCode().ToString();

        string strGender = string.Empty;

        if (memberInformation.Gender == 0)
        {
            strGender = "Mr";
        }

        if (memberInformation.Gender == 1)
        {
            strGender = "Mrs";
        }

        if (memberInformation.Gender == 2)
        {
            strGender = "Ms";
        }

        string mailStr = "";
        mailStr += "Dear " + strGender + ". " + memberInformation.FirstName + " " + memberInformation.MiddleName + " " + memberInformation.LastName + "," + "<br><br><br>";
        mailStr += "You have requested a password reminder for your Majestic Vacations account." + "<br><br>";
        mailStr += "As it is impossible for us to retrieve your original password we have generated a new one." + "<br><br>";
        mailStr += "Your new password is <b>" + password + "</b>, please use this when logging in to Majestic Vacations next time. Note that the password is case-sensitive." + "<br>" + "<br>";
        mailStr += "Note that this is an automatically generated e-mail, please do not reply to this e-mail address." + "<br><br><br>";
        mailStr += "Sincerely," + "<br><br>";
        mailStr += "Majestic Vacations Support Team";
        mailStr += "<p>Note that this is an automatically generated e-mail, please do not reply to this e-mail address</p>";

        password = MemberUtility.Lock(password);

        memberInformation.Password = password;

        _MemberInformationService.Update(memberInformation);

        MailMessage mailMessage = new MailMessage();

        mailMessage.IsBodyHtml = true;
        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        mailMessage.To.Add(new MailAddress(memberInformation.EmailAddress));

        mailMessage.Subject = "Majestic_Vacation your new password";
        mailMessage.Body = mailStr;

        Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Membership");

        //if (string.IsNullOrEmpty(ReturnUrl))
        //{
        this.Response.Redirect("~/Page/Common/SendPasswordSucceedForm.aspx");
        //}
        //else
        //{
        //    this.Response.Redirect(ReturnUrl);
        //}
    }
}
