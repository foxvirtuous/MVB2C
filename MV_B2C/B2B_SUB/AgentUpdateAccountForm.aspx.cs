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
using Terms.Common.Service;
using Terms.Common.Dao;
using Terms.Common.Domain;
using Terms.Member.Business;
using System.Collections.Generic;

public partial class AgentUpdateAccountForm : SalseBasePage
{
    private Terms.Member.Service.IConstantMasterService _ConstantMasterService;
    public Terms.Member.Service.IConstantMasterService ConstantMasterService
    {
        set
        {
            this._ConstantMasterService = value;
        }
    }

    private Terms.Member.Service.IConstantDetailService _ConstantDetailService;
    public Terms.Member.Service.IConstantDetailService ConstantDetailService
    {
        set
        {
            this._ConstantDetailService = value;
        }
    }

    private IQuestionService _QuestionService;
    public IQuestionService QuestionService
    {
        set
        {
            this._QuestionService = value;
        }
    }

    private IAnswerService _AnswerService;
    public IAnswerService AnswerService
    {
        set
        {
            this._AnswerService = value;
        }
    }

    private IAdsServiceService _AdsServiceService;
    public IAdsServiceService AdsServiceService
    {
        set
        {
            this._AdsServiceService = value;
        }
    }

    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    private IMemberInformationService _MemberInformationService;
    public IMemberInformationService MemberInformationService
    {
        set
        {
            this._MemberInformationService = value;
        }
    }

    public MemberInformation member = new MemberInformation();
    public MemberadsMeta Memberads = new MemberadsMeta();
    public TMemberToDataSource memberToDataSource = new TMemberToDataSource();
    public IList MemberQuestionAndAnswerList = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Utility.IsLogin)
            {
                InitMemberInfo();

                BindStateAndCountry();
            }
        }

    }

    private void InitMemberInfo()
    {
        member = Utility.Transaction.Member;
        Memberads = _MemberInformationService.FindMemberadsByID(member.MemberCode);
        memberToDataSource = _MemberInformationService.FindMemberToDataSourceByID(member.MemberCode);
        MemberQuestionAndAnswerList = _MemberInformationService.FindTMemberQuestionAndAnswerByID(member.MemberCode);

        this.txtCity.Text = member.City;
        this.txtFirst.Text = member.FirstName;

        this.txtLast.Text = member.LastName;
        this.txtMiddle.Text = member.MiddleName;
        this.txtPhoneDay.Text = member.PhoneDay;


        this.txtStreet.Text = member.StreetAddress;
        this.txtZip.Text = member.ZipCode;
        this.txtCity.Text = member.City;

    }

    private void BindStateAndCountry()
    {
        IList ilist = _CommonService.FindCountryAll();

        ListItem itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(member.Nation));
        BindCountry();
        this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(member.Province));
    }

    private MemberInformation UnConvert(MemberMeta meta)
    {
        MemberInformation result = new MemberInformation();

        result.Birthday = meta.Birthday;
        result.City = meta.City;
        result.EmailAddress = meta.EmailAddress;
        result.FirstName = meta.FirstName;
        result.Gender = meta.Gender;
        result.LastName = meta.LastName;
        result.MiddleName = meta.MiddleName;
        result.Nation = meta.Nation;
        result.Passport = meta.Passport;
        result.Password = meta.Password;
        result.RegsterDate = meta.RegisterTime;
        result.PhoneDay = meta.PhoneDay;
        result.PhoneNight = meta.PhoneNight;
        result.Province = meta.Province;
        result.Remark = meta.Remark;
        result.StreetAddress = meta.StreetAddress;
        result.ZipCode = meta.ZipCode;
        result.MemberCode = meta.MemberCode;
        result.MemberType = meta.MemberType;
        result.Status = meta.Status;
        result.DirectFrom = meta.DirectFrom;
        return result;
    }

    public string Join(ArrayList Arr, string SpaceMark)
    {
        string Temp = string.Empty;

        if (Arr.Count > 0)
        {
            for (int i = 0; i < Arr.Count - 1; i++)
            {
                Temp += Convert.ToString(Arr[i]) + SpaceMark.Trim();
            }

            Temp += Convert.ToString(Arr[Arr.Count - 1]);

        }
        return Temp;
    }

    protected void BindCountry()
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Name";
        ddlState.DataBind();


    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCountry();
    }
    protected void aspbtnUpdate_Click(object sender, EventArgs e)
    {
        member = Utility.Transaction.Member;
        string strFirst = string.Empty;
        string strMiddle = string.Empty;
        string strLast = string.Empty;
        string strEmail = string.Empty;
        string strPhoneDay = string.Empty;
        string strPassport = string.Empty;
        string strStreet = string.Empty;
        string strCity = string.Empty;
        string strState = string.Empty;
        string strCountry = string.Empty;
        string strZip = string.Empty;

        if (this.IsValid)
        {
            strFirst = this.txtFirst.Text.Trim();

            strMiddle = this.txtMiddle.Text.Trim();

            strLast = this.txtLast.Text.Trim();

            strPhoneDay = this.txtPhoneDay.Text.Trim();

            strStreet = this.txtStreet.Text.Trim();

            strCity = this.txtCity.Text.Trim();

            strState = this.ddlState.SelectedValue;

            strCountry = this.ddlCountry.SelectedValue;

            strZip = this.txtZip.Text.Trim();

            int iCount = _MemberInformationService.GetEmail(strEmail);

            if (iCount > 0)
            {
                return;
            }

            TMemberToDataSource _MemberToDataSource = new TMemberToDataSource();

            _MemberToDataSource.Constantid = "0";

            MemberMeta _MemberInformation = _MemberInformationService.FindMemberInformationByID(Utility.Transaction.Member.MemberCode);

            _MemberInformation.FirstName = strFirst;
            _MemberInformation.MiddleName = strMiddle;
            _MemberInformation.LastName = strLast;
            _MemberInformation.PhoneDay = strPhoneDay;
            _MemberInformation.City = strCity;
            _MemberInformation.StreetAddress = strStreet;
            _MemberInformation.Nation = strCountry;
            _MemberInformation.Province = strState;
            _MemberInformation.ZipCode = strZip;

            MemberInformation mem = UnConvert(_MemberInformation);

            _MemberInformationService.UpdateMemberInformation(mem);

            

            //MailMessage mailMessage = new MailMessage();

            //mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
            //mailMessage.To.Add(new MailAddress(member.EmailAddress));
            //mailMessage.Subject = "Your Account of Majestic Vacations has been updated successfully.";
            //mailMessage.Body = "Dear " + strFirst + " " + strLast + ",<br> Thanks for registering our membership program." +
            //                    "The new membership number is .  You can start enjoying the membership benefits," +
            //                    "e.g., promotional travel offers, last minute deals, various tours, hotels, and sweepstakes.";

            //Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BMembership");

            Utility.Transaction.Member = mem;

            this.Response.Redirect("~/B2B_SUB/Index.aspx");

        }
    }
}
