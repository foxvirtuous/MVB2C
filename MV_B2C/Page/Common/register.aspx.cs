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

using Terms.Member.Service;
using System.Collections.Generic;
using Terms.Sales.Business;

public partial class register : SalseBasePage
{
    private IQuestionService _QuestionService;
    public IQuestionService QuestionService
    {
        set
        {
            this._QuestionService = value;
        }
    }

    //private IMemberQuestionAndAnswerService _MemberQuestionAndAswerService;
    //public IMemberQuestionAndAnswerService MemberQuestionAndAswerService
    //{
    //    set
    //    {
    //        this._MemberQuestionAndAswerService = value;
    //    }
    //}

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

    public string ReturnUrl
    {
        get
        {
            return this.Request["ReturnUrl"];
        }

    }

    private string _MemberWebSite;
    private string MemberWebSite
    {
        get
        {
            _MemberWebSite = Terms.Member.Utility.MemberConst.MEMBER_WEBSITE;
            return this._MemberWebSite;
        }
    }

    public register()
    {
        this.InitializeControls += new EventHandler(ServiceInformation_InitializeControls);
    }

    void ServiceInformation_InitializeControls(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (!this.Page.IsPostBack)
        {
            BindStateAndCountry();

            BindServer();

            BindQA();

            //for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 100; i--)
            //{
            //    ListItem item = new ListItem(i.ToString(), i.ToString());

            //    drpAdultyear.Items.Add(item);
            //}

            //ListItem itemNew = new ListItem("--Year--", "0");

            //drpAdultyear.Items.Insert(0, itemNew);
        }
    }

    private void ClearPage()
    {
        this.rblGender.SelectedIndex = 0;
        this.txtFirst.Text = string.Empty;
        this.txtMiddle.Text = string.Empty;
        this.txtLast.Text = string.Empty;
        this.txtEmail.Text = string.Empty;
        this.txtPassword.Text = string.Empty;
        this.txtVerity.Text = string.Empty;
        this.txtPhoneDay.Text = string.Empty;
        this.txtPhoneNight.Text = string.Empty;
        //this.txtBirthday.Text = string.Empty;
        this.txtPassport.Text = string.Empty;
        this.txtStreet.Text = string.Empty;
        this.txtCity.Text = string.Empty;
        this.txtZip.Text = string.Empty;
    }

    private void BindStateAndCountry()
    {
        IList ilist = _CommonService.FindCountryAll();

        ListItem itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue("US"));

        ddlCountry_SelectedIndexChanged(null, new EventArgs());
    }

    private void BindServer()
    {
        List<Terms.Member.Business.Service> tAdsQuestion = _AdsServiceService.GetAllServices("0");
        cblServer.DataSource = tAdsQuestion;
        cblServer.DataTextField = "Text";
        cblServer.DataValueField = "Code";
        cblServer.DataBind();
    }

    private void BindQA()
    {
        IList<Terms.Member.Business.Question> tAdsQuestion = _QuestionService.GetAllQuestions("0");
        //this.ViewState["Question"] = tAdsQuestion;
        dgServer.DataSource = tAdsQuestion;
        dgServer.DataBind();

        for (int i = 0; i < dgServer.Items.Count; i++)
        {
            string strQuestionCode = dgServer.Items[i].Cells[0].Text;

            string strSingleOrMultiterm = dgServer.Items[i].Cells[2].Text;

            //IList tAdsService = _AnswerService.GetAnswerAllByCode(strQuestionCode);

            if (Convert.ToBoolean(strSingleOrMultiterm))
            {
                RadioButtonList rbl = (RadioButtonList)dgServer.Items[i].FindControl("rblAnswer");
                CheckBoxList cbl = (CheckBoxList)dgServer.Items[i].FindControl("cblAnswer");

                rbl.Visible = false;
                cbl.Visible = true;

                cbl.DataSource = tAdsQuestion[i].AnswerOptions;
                cbl.DataTextField = "Text";
                cbl.DataValueField = "Code";
                cbl.DataBind();
            }
            else
            {
                RadioButtonList rbl = (RadioButtonList)dgServer.Items[i].FindControl("rblAnswer");
                CheckBoxList cbl = (CheckBoxList)dgServer.Items[i].FindControl("cblAnswer");

                rbl.Visible = true;
                cbl.Visible = false;

                rbl.DataSource = tAdsQuestion[i].AnswerOptions;
                rbl.DataTextField = "Text";
                rbl.DataValueField = "Code";
                rbl.DataBind();

                rbl.SelectedIndex = 0;
            }
        }
    }
    protected void dgServer_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
    }

    public bool FillArrayList(ref ArrayList arr, string strString, string strSpaceMark)
    {
        int iStartIndex = strString.IndexOf(strSpaceMark, 0);

        if (iStartIndex > 0)
        {
            string strTemp = strString.Substring(0, iStartIndex);

            strString = strString.Remove(0, iStartIndex + 1);

            arr.Add(strTemp);

            bool flag = FillArrayList(ref arr, strString, strSpaceMark);

            if (flag)
            {
                return flag;
            }
        }

        arr.Add(strString);

        return true;
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
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

        ddlState.DataSource = ilist;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Name";
        ddlState.DataBind();
    }
    protected void btnCreat_Click(object sender, EventArgs e)
    {
        //声明临时变量
        string strGender = string.Empty;
        string strFirst = string.Empty;
        string strMiddle = string.Empty;
        string strLast = string.Empty;
        string strEmail = string.Empty;
        string strPassword = string.Empty;
        string strPhoneDay = string.Empty;
        string strPhoneNight = string.Empty;
        DateTime dateBirthday = DateTime.MinValue;
        string strPassport = string.Empty;
        string strStreet = string.Empty;
        string strCity = string.Empty;
        string strState = string.Empty;
        string strCountry = string.Empty;
        string strZip = string.Empty;

        if (this.IsValid)
        {
            //读取页面数据并验证格式是否正确
            strGender = this.rblGender.SelectedValue;
            strFirst = this.txtFirst.Text.Trim();
            strMiddle = this.txtMiddle.Text.Trim();
            strLast = this.txtLast.Text.Trim();
            strEmail = this.txtEmail.Text;
            strPassword = MemberUtility.Lock(this.txtPassword.Text.Trim());
            strPhoneDay = this.txtPhoneDay.Text.Trim();
            strPhoneNight = this.txtPhoneNight.Text.Trim();

            try
            {
                dateBirthday = Convert.ToDateTime(txtBirthday.Text);
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('birthday format error.');</script>");
                return;
            }

            strPassport = this.txtPassport.Text.Trim();
            strStreet = this.txtStreet.Text.Trim();
            strCity = this.txtCity.Text.Trim();
            strState = this.ddlState.SelectedValue;
            strCountry = this.ddlCountry.SelectedValue;
            strZip = this.txtZip.Text.Trim();

            int iCount = _MemberInformationService.GetEmail(strEmail, 0);

            if (iCount > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Email Address entered is already in use. Choose another');</script>");
                return;
            }

            if (this.txtPassword.Text.Trim().Length < 4 || this.txtPassword.Text.Trim().Length > 11)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('The password must be at least 6 or 11 characters long. ');</script>");
                return;
            }

            //填充 member 对象
            Terms.Member.Business.MemberInformation meta = new Terms.Member.Business.MemberInformation();

            //填充服务对象
            meta.SelectedService = new List<Terms.Member.Business.Service>();

            for (int i = 0; i < cblServer.Items.Count; i++)
            {
                if (cblServer.Items[i].Selected)
                {
                    Terms.Member.Business.Service service = new Terms.Member.Business.Service();

                    service.Code = cblServer.Items[i].Value.Trim();

                    meta.SelectedService.Add(service);
                }
            }

            //填充问题与答案
            ArrayList arrQuestion = new ArrayList();

            meta.QuestionAnswers = new List<Terms.Member.Business.Answer>();

            foreach (DataGridItem item in dgServer.Items)
            {
                Terms.Member.Business.Answer answer = new Terms.Member.Business.Answer();
                answer.Question.Code = item.Cells[0].Text;
                answer.Question.IsRadio = Convert.ToBoolean(item.Cells[2].Text);

                //Terms.Member.Business.Question question = new Terms.Member.Business.Question();

                //answer.Details = new List<Terms.Member.Business.AnswerOption>();

                //string strQuestionCode = item.Cells[0].Text;

                //string strSingleOrMultiterm = item.Cells[2].Text;

                if (answer.Question.IsRadio)
                {
                    CheckBoxList cbl = (CheckBoxList)item.FindControl("cblAnswer");

                    //question.Code = strQuestionCode;

                    for (int i = 0; i < cbl.Items.Count; i++)
                    {
                        if (cbl.Items[i].Selected)
                        {
                            Terms.Member.Business.AnswerOption answerOption = new Terms.Member.Business.AnswerOption();

                            answerOption.Code = cbl.Items[i].Value.Trim();

                            answer.Details.Add(answerOption);
                        }
                    }
                }
                else
                {
                    RadioButtonList rbl = (RadioButtonList)item.FindControl("rblAnswer");

                    Terms.Member.Business.AnswerOption answerOption = new Terms.Member.Business.AnswerOption();

                    //question.Code = strQuestionCode;

                    answerOption.Code = rbl.SelectedValue.Trim();

                    answer.Details.Add(answerOption);
                }

                //answer.Question = question;

                meta.QuestionAnswers.Add(answer);
            }

            //TMemberInformation _MemberInformation = new TMemberInformation();

            meta.FirstName = strFirst;
            meta.MiddleName = strMiddle;
            meta.LastName = strLast;
            meta.Gender = Convert.ToInt32(strGender);
            meta.EmailAddress = strEmail;
            meta.Password = strPassword;
            meta.PhoneDay = strPhoneDay;
            meta.PhoneNight = strPhoneNight;
            meta.Birthday = dateBirthday;
            meta.Passport = strPassport;
            meta.City = strCity;
            meta.StreetAddress = strStreet;
            meta.Nation = strCountry;
            meta.Province = strState;
            meta.ZipCode = strZip;
            meta.Source = "MVB2C";

            string strMemberCode = _MemberInformationService.SaveNewMemberInformation(meta);

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
            mailMessage.To.Add(new MailAddress(strEmail));
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = "Your registration of Majestic vacations has been compeleted successfully.";
            mailMessage.Body = "Dear " + strFirst + " " + strLast + ",<br> Thanks for registering our membership program." +
                                "The new login name is " + strEmail + " and Password is " + this.txtPassword.Text + " .  You can start enjoying the membership benefits," +
                                "e.g., promotional travel offers, last minute deals, various tours, hotels, and sweepstakes.";

            Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Membership");

            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.MV_RegisterMember, this);

            if (string.IsNullOrEmpty(ReturnUrl))
            {
                this.Response.Redirect("~/Page/Common/JoinSucceedForm.aspx");
            }
            else
            {
                Utility.Transaction.IsLogin = true;
                meta = _MemberInformationService.FindMemberInformationByUserName(meta.EmailAddress.Trim());
                Utility.Transaction.Member = meta;

                if (ReturnUrl.Contains(@"?"))
                {
                    this.Response.Redirect(ReturnUrl + "&ConditionID=" + Request.Params["ConditionID"]);
                }
                else
                {
                    this.Response.Redirect(ReturnUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                }

                //if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
                //{
                //    this.Response.Redirect(ReturnUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                //}
                //else
                //{
                //    this.Response.Redirect(ReturnUrl + "&ConditionID=" + Request.Params["ConditionID"]);
                //}
            }

        }
    }
}
