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
public partial class MemberUpdateAccountForm : Spring.Web.UI.Page
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

    //public MemberUpdateAccountForm()
    //{
    //    this.InitializeControls += new EventHandler(MemberUpdateAccountForm_InitializeControls);
    //}

    //void MemberUpdateAccountForm_InitializeControls(object sender, EventArgs e)
    //{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Utility.IsLogin)
            {
                InitMemberInfo();

                BindStateAndCountry();

                BindServer();

                BindQA();
            }
        }

    }

    private void InitMemberInfo()
    {
        member = Utility.Transaction.Member;
        Memberads = _MemberInformationService.FindMemberadsByID(member.MemberCode);
        memberToDataSource = _MemberInformationService.FindMemberToDataSourceByID(member.MemberCode);
        MemberQuestionAndAnswerList = _MemberInformationService.FindTMemberQuestionAndAnswerByID(member.MemberCode);

        //string[] birthday = member.Birthday.ToString("d/M/yyyy").Split('-');
        //this.txtBirthday.Text = member.Birthday.ToString("MM/dd/yyyy");
        this.txtCity.Text = member.City;
        this.txtPassport.Text = member.Passport;
        this.txtFirst.Text = member.FirstName;
        this.rblGender.SelectedIndex = member.Gender;


        this.txtLast.Text = member.LastName;
        this.txtMiddle.Text = member.MiddleName;
        this.txtPhoneNight.Text = member.PhoneNight;
        this.txtPhoneDay.Text = member.PhoneDay;


        for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 100; i--)
        {
            ListItem itemNew = new ListItem(i.ToString(), i.ToString());

            drpAdultyear.Items.Add(itemNew);
        }

        ListItem itemNew1 = new ListItem("--Select--", "0");
        drpAdultyear.Items.Insert(0, itemNew1);

        this.drpAdultDay.SelectedIndex = drpAdultDay.Items.IndexOf(drpAdultDay.Items.FindByText(member.Birthday.Day.ToString()));
        this.drpAdultMonth.SelectedIndex = drpAdultMonth.Items.IndexOf(drpAdultMonth.Items.FindByText(member.Birthday.Month.ToString()));
        this.drpAdultyear.SelectedIndex = drpAdultyear.Items.IndexOf(drpAdultyear.Items.FindByText(member.Birthday.Year.ToString()));

        this.txtStreet.Text = member.StreetAddress;
        this.txtZip.Text = member.ZipCode;
        this.txtCity.Text = member.City;

    }

    private void BindStateAndCountry()
    {
        //IList ilist = _CommonService.FindCountryAll();

        //ddlCountry.DataSource = ilist;
        //ddlCountry.DataTextField = "Name";
        //ddlCountry.DataValueField = "Code";
        //ddlCountry.DataBind();

        IList ilist = _CommonService.FindCountryAll();

        ListItem itemNew = new ListItem("CANADA", "CA");

        ddlCountry.Items.Add(itemNew);

        itemNew = new ListItem("United States", "US");

        ddlCountry.Items.Add(itemNew);

        this.ddlCountry.SelectedIndex = ddlCountry.Items.IndexOf(ddlCountry.Items.FindByValue(member.Nation));
        BindCountry();
        this.ddlState.SelectedIndex = ddlState.Items.IndexOf(ddlState.Items.FindByValue(member.Province));
      


        //ddlState_SelectedIndexChanged(null, new EventArgs());
    }

    private void BindServer()
    {
        IList tAdsQuestion = _AdsServiceService.GetAllServices("0");
        cblServer.DataSource = tAdsQuestion;
        cblServer.DataTextField = "Text";
        cblServer.DataValueField = "Code";
        cblServer.DataBind();

       // Memberads.
        foreach (ListItem item in cblServer.Items)
        {
            if (((MemberadsMeta)Memberads).AdsCode.Trim().Contains(item.Value))
                cblServer.Items.FindByValue(item.Value).Selected = true;
        }
    }

    private void BindQA()
    {
        IList<Terms.Member.Business.Question> tAdsQuestion =  _QuestionService.GetAllQuestions("0");
        dgServer.DataSource = tAdsQuestion;
        dgServer.DataBind();
        IList MemberQA = _MemberInformationService.FindTMemberQuestionAndAnswerByID(Utility.Transaction.Member.MemberCode); 


        for (int i = 0; i < dgServer.Items.Count; i++)
        {
            string strQuestionCode = dgServer.Items[i].Cells[0].Text;

            string strSingleOrMultiterm = dgServer.Items[i].Cells[2].Text;

            //IList tAdsService = _AnswerService.GetAnswerAllByCode(strQuestionCode);

            bool flag = false;

            for (int x = 0; x < MemberQA.Count; x++)
            {
                if (((MemberQuestionAndAnswerMeta)MemberQA[x]).QuestionCode.Trim().Contains(strQuestionCode.Trim()))
                {
                    flag = true;
                    break;
                }
            }

            if (flag)
            {

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
                    if (((Terms.Member.Domain.MemberQuestionAndAnswerMeta)MemberQA[i]).QuestionCode == strQuestionCode)
                    {
                        string[] SelectNum = ((Terms.Member.Domain.MemberQuestionAndAnswerMeta)MemberQA[i]).AnswerCode.Split('/');
                        for (int y = 0; y < cbl.Items.Count; y++)
                        {
                            for (int j = 0; j < SelectNum.Length; j++)
                            {
                                if (SelectNum[j].Trim().Length > 0 && Convert.ToInt32(SelectNum[j]) == y)
                                {
                                    cbl.Items[y].Selected = true;
                                }
                            }
                        }
                    }

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
                    if (((Terms.Member.Domain.MemberQuestionAndAnswerMeta)MemberQA[i]).QuestionCode == strQuestionCode)
                    {
                        string SelectNum = ((Terms.Member.Domain.MemberQuestionAndAnswerMeta)MemberQA[i]).AnswerCode;
                        for (int y = 0; y < rbl.Items.Count; y++)
                        {

                            if (Convert.ToInt32(SelectNum) == y)
                            {
                                rbl.Items[y].Selected = true;
                            }

                        }
                    }
                    //rbl.SelectedIndex = 0;
                }
            }
        }
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
                if (strSingleOrMultiterm.Trim() == "1")
                {
                    RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rblAnswer");
                    CheckBoxList cbl = (CheckBoxList)e.Item.FindControl("cblAnswer");

                    rbl.Visible = false;
                    cbl.Visible = true;


                    cbl.DataSource = tAdsService;
                    cbl.DataTextField = "AnswerName";
                    cbl.DataValueField = "AnswerCode";
                    cbl.DataBind();

                    foreach (AnswerMeta answer in tAdsService)
                    {
                        if (((MemberQuestionAndAnswerMeta)MemberQuestionAndAnswerList[e.Item.ItemIndex]).AnswerCode.Trim().Contains(answer.AnswerCode.Trim()))
                            cbl.Items.FindByValue(answer.AnswerCode).Selected = true;
                    }
                }
                else
                {
                    RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rblAnswer");
                    CheckBoxList cbl = (CheckBoxList)e.Item.FindControl("cblAnswer");

                    rbl.Visible = true;
                    cbl.Visible = false;

                    rbl.DataSource = tAdsService;
                    rbl.DataTextField = "AnswerName";
                    rbl.DataValueField = "AnswerCode";
                    rbl.DataBind();

                    foreach (AnswerMeta answer in tAdsService)
                    {
                        if (((MemberQuestionAndAnswerMeta)MemberQuestionAndAnswerList[e.Item.ItemIndex]).AnswerCode.Trim().Contains(answer.AnswerCode.Trim()))
                            rbl.Items.FindByValue(answer.AnswerCode).Selected = true;
                    }
                }
            }
        }
    }
    protected void aspbtnUpdate_Click(object sender, EventArgs e)
    {
        member = Utility.Transaction.Member;
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

        if (this.IsValid )
        {
            strGender = this.rblGender.SelectedValue;

            strFirst = this.txtFirst.Text.Trim();

            strMiddle = this.txtMiddle.Text.Trim();

            strLast = this.txtLast.Text.Trim();

            strPhoneDay = this.txtPhoneDay.Text.Trim();

            strPhoneNight = this.txtPhoneNight.Text.Trim();

            try
            {
                dateBirthday = Convert.ToDateTime(drpAdultMonth.SelectedValue + "/" + drpAdultDay.SelectedValue + "/" + drpAdultyear.SelectedValue).Date;
            }
            catch
            {
                return;
            }

            strPassport = this.txtPassport.Text.Trim();

            strStreet = this.txtStreet.Text.Trim();

            strCity = this.txtCity.Text.Trim();

            strState = this.ddlState.SelectedValue;

            strCountry = this.ddlCountry.SelectedValue;

            strZip = this.txtZip.Text.Trim();

            int iCount = _MemberInformationService.GetEmail(strEmail);

            //if (iCount > 0)
            //{
            //    return;
            //}

            ArrayList arr = new ArrayList();

            for (int i = 0; i < cblServer.Items.Count; i++)
            {
                if (cblServer.Items[i].Selected)
                {
                    arr.Add(cblServer.Items[i].Value.Trim());
                }
            }

            MemberadsMeta _Memberads = _MemberInformationService.FindMemberadsByID(member.MemberCode);

            _Memberads.AdsCode = Join(arr, @"/");

            ArrayList arrQuestion = new ArrayList();

            MemberQuestionAndAnswerMeta _MemberQuestionAndAnswer;

            foreach (DataGridItem item in dgServer.Items)
            {
                _MemberQuestionAndAnswer = new MemberQuestionAndAnswerMeta();

                string strQuestionCode = item.Cells[0].Text;

                string strSingleOrMultiterm = item.Cells[2].Text;

                if (strSingleOrMultiterm == "True")
                {
                    CheckBoxList cbl = (CheckBoxList)item.FindControl("cblAnswer");

                    _MemberQuestionAndAnswer.QuestionCode = strQuestionCode;

                    _MemberQuestionAndAnswer.MemberCode = member.MemberCode;

                    ArrayList arrAnswer = new ArrayList();

                    for (int i = 0; i < cbl.Items.Count; i++)
                    {
                        if (cbl.Items[i].Selected)
                        {
                            arrAnswer.Add(cbl.Items[i].Value.Trim());
                        }
                    }

                    _MemberQuestionAndAnswer.AnswerCode = Join(arrAnswer, @"/");
                }
                else
                {
                    RadioButtonList rbl = (RadioButtonList)item.FindControl("rblAnswer");

                    _MemberQuestionAndAnswer.QuestionCode = strQuestionCode;

                    _MemberQuestionAndAnswer.MemberCode = member.MemberCode;

                    _MemberQuestionAndAnswer.AnswerCode = rbl.SelectedValue.Trim();
                }

                arrQuestion.Add(_MemberQuestionAndAnswer);
            }

            TMemberToDataSource _MemberToDataSource = new TMemberToDataSource();

            _MemberToDataSource.Constantid = "0";

            MemberMeta _MemberInformation = _MemberInformationService.FindMemberInformationByID(Utility.Transaction.Member.MemberCode);// new MemberMeta();// (MemberMeta)member;

            _MemberInformation.FirstName = strFirst;
            _MemberInformation.MiddleName = strMiddle;
            _MemberInformation.LastName = strLast;
            _MemberInformation.Gender = Convert.ToInt32(strGender);
            _MemberInformation.PhoneDay = strPhoneDay;
            _MemberInformation.PhoneNight = strPhoneNight;
            _MemberInformation.Birthday = dateBirthday;
            _MemberInformation.Passport = strPassport;
            _MemberInformation.City = strCity;
            _MemberInformation.StreetAddress = strStreet;
            _MemberInformation.Nation = strCountry;
            _MemberInformation.Province = strState;
            _MemberInformation.ZipCode = strZip;
            _MemberInformation.RegisterTime = DateTime.Now.Date;

            _MemberInformationService.UpdateMemberInformation(_Memberads, _MemberInformation, arrQuestion);

            Utility.Transaction.Member = UnConvert(_MemberInformation);

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
            mailMessage.To.Add(new MailAddress(member.EmailAddress));
            mailMessage.Subject = "Your Account of GTT has been updated successfully.";
            mailMessage.Body = "Dear " + strFirst + " " + strLast + ",<br> Thanks for registering for our membership program. " +
                                "Your User ID is: " + member.EmailAddress + " .  You can now start enjoying your membership benefits such as promotional travel offers, last minute deals, tour offers, hotel specials, and sweepstakes!";

            Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "Membership");

           
            this.Response.Redirect("~/Page/Common/MemberMessageForm.aspx");
           
        }
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
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCountry();
    }

    protected void BindCountry()
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(ddlCountry.SelectedValue);

       ddlState.DataSource = ilist;
       ddlState.DataTextField = "Name";
       ddlState.DataValueField = "Name";
       ddlState.DataBind();
    }
}
