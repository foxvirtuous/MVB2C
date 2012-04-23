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
public partial class MemberMyAccountForm : Spring.Web.UI.Page
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

    public MemberMyAccountForm()
    {
        this.InitializeControls += new EventHandler(MemberMyAccountForm_InitializeControls);
    }

    void MemberMyAccountForm_InitializeControls(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Utility.IsLogin)
            {
                if (Utility.Transaction.Member.Source != null && Utility.Transaction.Member.Source.Trim().ToLower() == "Subagent".Trim().ToLower())
                {
                    this.Response.Redirect("MyOrderSearch.aspx");
                }
                InitMemberInfo();
            }
            BindQA();
        }
    }

    private void InitServer()
    {
        IList tAdsQuestion = _AdsServiceService.GetAllServices("0");


        foreach (Terms.Member.Business.Service tas in tAdsQuestion) 
        {
            if (Memberads.AdsCode.Equals(tas.Code))
                this.lblServer.Text = this.lblServer.Text + tas.Text + "<br>";
        }
        

    }
    private void BindQA()
    {
        IList<Terms.Member.Business.Question> tAdsQuestion = _QuestionService.GetAllQuestions("0");
        dgServer.DataSource = tAdsQuestion;
        dgServer.DataBind();
    }

    protected void dgServer_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header && e.Item.ItemType != ListItemType.Footer)
        {
            string strQuestionCode = e.Item.Cells[0].Text;

            string strSingleOrMultiterm = e.Item.Cells[2].Text;

            IList tAdsService = _AnswerService.GetAnswerAllByCode(strQuestionCode);

            bool flag = false;

            for (int i = 0; i < MemberQuestionAndAnswerList.Count; i++)
            {
                if (((MemberQuestionAndAnswerMeta)MemberQuestionAndAnswerList[i]).QuestionCode.Trim().Contains(strQuestionCode.Trim()))
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {
                Label lblAnswer = (Label)e.Item.FindControl("lblAnswer");

                foreach (AnswerMeta answer in tAdsService)
                {
                    if (((MemberQuestionAndAnswerMeta)MemberQuestionAndAnswerList[e.Item.ItemIndex]).AnswerCode.Trim().Contains(answer.AnswerCode.Trim()))
                        lblAnswer.Text = lblAnswer.Text + answer.AnswerName + ",";
                }
                if (lblAnswer.Text.Length > 0)
                    lblAnswer.Text = lblAnswer.Text.Remove(lblAnswer.Text.Length - 1);
            }
        }
    }
    private void InitMemberInfo()
    {
        member = Utility.Transaction.Member;
        Memberads = _MemberInformationService.FindMemberadsByID(member.MemberCode);
        memberToDataSource = _MemberInformationService.FindMemberToDataSourceByID(member.MemberCode);
        MemberQuestionAndAnswerList = _MemberInformationService.FindTMemberQuestionAndAnswerByID(member.MemberCode);
     

        this.lblBirthday.Text = member.Birthday.ToString("MM/dd/yyyy");
        this.lblCity.Text = member.City;
        this.lblPassportNumber.Text = member.Passport;
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
        this.lblNightPhoneNumber.Text = member.PhoneNight;
        this.lblDayPhoneNumber.Text = member.PhoneDay;
        this.lblStateCountry.Text =( member.Province.Equals(string.Empty) ? "  " : member.Province + " , ") + _CommonService.FindCountryById(member.Nation).FullName;
        this.lblStreetAddress.Text = member.StreetAddress;
        this.lblZip.Text = member.ZipCode;
        this.lblCity.Text = member.City;

        InitServer();
        
    }
    protected void lbnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Page/Common/MemberUpdateAccountForm.aspx");
    }
}
