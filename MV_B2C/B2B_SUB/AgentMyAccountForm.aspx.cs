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

public partial class AgentMyAccountForm : SalseBasePage
{
    private IMemberInformationService _MemberInformationService;
    public IMemberInformationService MemberInformationService
    {
        set
        {
            this._MemberInformationService = value;
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

    private ICommonService _CommonService;
    public ICommonService CommonService
    {
        set
        {
            this._CommonService = value;
        }
    }

    public MemberInformation member = new MemberInformation();
    public MemberadsMeta Memberads = new MemberadsMeta();
    public TMemberToDataSource memberToDataSource = new TMemberToDataSource();
    public IList MemberQuestionAndAnswerList = new ArrayList();

    private IAdsServiceService _AdsServiceService;
    public IAdsServiceService AdsServiceService
    {
        set
        {
            this._AdsServiceService = value;
        }
    }

    public AgentMyAccountForm()
    {
        this.InitializeControls += new EventHandler(AgentMyAccountForm_InitializeControls);
    }

    void AgentMyAccountForm_InitializeControls(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Utility.IsLogin)
            {
                if (Utility.Transaction.Member.Source != null && Utility.Transaction.Member.Source.Trim().ToLower() == "Subagent".Trim().ToLower())
                {
                    this.Response.Redirect("AgentOrderSearch.aspx");
                }

                InitMemberInfo();
            }
        }
    }

    private void InitServer()
    {
    }

    private void InitMemberInfo()
    {
        member = Utility.Transaction.Member;
        Memberads = _MemberInformationService.FindMemberadsByID(member.MemberCode);
        memberToDataSource = _MemberInformationService.FindMemberToDataSourceByID(member.MemberCode);
        MemberQuestionAndAnswerList = _MemberInformationService.FindTMemberQuestionAndAnswerByID(member.MemberCode);
        this.lblCity.Text = member.City;
        this.lblFirstName.Text = member.FirstName;
        switch (member.Gender)
        {
            case 0: this.lblGender.Text = Terms.Member.Utility.Member_Gender.Mr.ToString();
                break;
            case 1: this.lblGender.Text = Terms.Member.Utility.Member_Gender.Mrs.ToString();
                break;
            case 2: this.lblGender.Text = Terms.Member.Utility.Member_Gender.Ms.ToString();
                break;
        }
        this.lblLastName.Text = member.LastName;
        this.lblMiddleName.Text = member.MiddleName;
        this.lblDayPhoneNumber.Text = member.PhoneDay;
        this.lblStateCountry.Text = (member.Province.Equals(string.Empty) ? "  " : member.Province + " , ") + _CommonService.FindCountryById(member.Nation).FullName;
        this.lblStreetAddress.Text = member.StreetAddress;
        this.lblZip.Text = member.ZipCode;
        this.lblCity.Text = member.City;

        InitServer();

    }
    protected void lbnUpdate_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("AgentUpdateAccountForm.aspx");
    }
}
