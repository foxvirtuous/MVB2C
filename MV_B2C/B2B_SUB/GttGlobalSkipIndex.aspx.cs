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
using Terms.Common.Service;
using Terms.Member.Service;
using Terms.Member.Business;
using System.Net.Mail;
using System.Collections.Generic;
using Terms.Common.Domain;

namespace Terms.Web.B2B_SUB
{
    public partial class GttGlobalSkipIndex : SalseBasePage
    {
        private IMemberInformationService _MemberInformationService;
        public IMemberInformationService MemberInformationService
        {
            set
            {
                this._MemberInformationService = value;
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

        public string[] MJVID
        {
            get
            {
                string[] mjvid = new string[16];

                if (Request["MJVID"] != null)
                {
                    string temp = Request.QueryString["MJVID"];

                    string mjvids = Server.UrlDecode(temp);

                    mjvid = mjvids.Split(new char[] { ',' });
                }

                return mjvid;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["MJVID"] != null)
                {
                    bool isTest = true;

                    if (System.Configuration.ConfigurationManager.AppSettings["Gttglobal_Flag"] != null)
                        isTest = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["Gttglobal_Flag"]);

                    if (isTest)
                    {
                        if ((Request.UrlReferrer.AbsoluteUri.ToLower().IndexOf(@"gttglobal.com".Trim().ToLower()) < 0) &&
                     (Request.UrlReferrer.AbsoluteUri.ToLower().IndexOf(@"gttglobal.org".Trim().ToLower()) < 0))
                        {
                            this.Response.Redirect("Login.aspx");
                        }
                    }
                    
                    string FirstName = MJVID[0];
                    string LastName = MJVID[1];
                    string EmailAddress = MJVID[2];
                    string PhoneDay = MJVID[3];
                    string CompanyName = MJVID[4];
                    string AccountCode = MJVID[5];
                    //zyl add 2009-10-26  现在gttglobal可能传空字符串过来 如果是空我们默认填写为“Unknown”
                    string Branch = string.Empty;
                    if (MJVID[6] != null && MJVID[6].Trim().Length > 0)
                    {
                        Branch = MJVID[6];
                    }
                    else
                    {
                        Branch = "Unknown";
                    }
                    string userID = MJVID[7];
                    //add zyl 2009-9-14
                    string arcNumber = MJVID[8];
                    string Address = MJVID[9];
                    string City = MJVID[10];
                    string State = MJVID[11];
                    string ZipCode = MJVID[12];
                    string Country = MJVID[13];
                    string Fax = MJVID[14];
                    string UserRoll = MJVID[15];
                    string Type = "H";
                    if (MJVID.Length == 17)
                    {
                        Type = MJVID[16];
                    }

                    FillPage(MJVID);
                    
                    MemberInformation memberinfo = _MemberInformationService.GetGttMember(userID);

                    if (memberinfo != null)
                    {
                        if (memberinfo.FirstName != FirstName || memberinfo.LastName != LastName || memberinfo.PhoneDay != PhoneDay ||
                            memberinfo.CompanyName != CompanyName || memberinfo.AccountCode != AccountCode || memberinfo.Branch != Branch ||
                            memberinfo.ARCNumber != arcNumber || memberinfo.StreetAddress != Address || memberinfo.City != City ||
                            memberinfo.Province != State || memberinfo.ZipCode != ZipCode || memberinfo.Nation != Country ||
                            memberinfo.Fax != Fax || memberinfo.UserRoll != UserRoll)
                        {
                            //更新数据
                            memberinfo.FirstName = FirstName;
                            memberinfo.LastName = LastName;
                            memberinfo.PhoneDay = PhoneDay;
                            memberinfo.CompanyName = CompanyName;
                            memberinfo.AccountCode = AccountCode;
                            memberinfo.Branch = Branch;
                            //add zyl 2009-9-14
                            memberinfo.ARCNumber = arcNumber;
                            memberinfo.StreetAddress = Address;
                            memberinfo.City = City ;
                            memberinfo.Province = State;
                            memberinfo.ZipCode = ZipCode;
                            memberinfo.Nation = Country ;
                            memberinfo.Fax = Fax;
                            memberinfo.UserRoll = UserRoll;

                            string citycode = memberinfo.Branch.Replace("GTT", string.Empty);
                            memberinfo.Handler = GetHandlerName(citycode);

                            _MemberInformationService.UpdateMemberAndOwnerAndGTTMember(memberinfo);
                        }

                        Utility.Transaction.IsLogin = true;
                        Utility.Transaction.Member = memberinfo;
                        if (Type.Trim() == "H")
                        {
                            this.Response.Redirect("Index.aspx");
                        }
                        else if (Type.Trim() == "T")
                        {
                            this.Response.Redirect("TourIndex.aspx?tab=T");
                        }
                        else if (Type.Trim() == "I")
                        {
                            this.Response.Redirect("~/Page/Insurance/NewInsuranceSeachMainForm.aspx?tab=I");
                        }
                        else
                        {
                            this.Response.Redirect("Index.aspx");
                        }
                    }
                }
                else
                {
                    this.Response.Redirect("Login.aspx");
                }
            }
        }

        private string GetHandlerName(string citycode)
        {
            List<Terms.Member.Utility.HandlerReceiver> Citys = Terms.Member.Utility.MemberUtility.GetHandlerReciever();

            List<string> CityCodes = new List<string>();

            string HandlerName = string.Empty;

            for (int i = 0; i < Citys.Count; i++)
            {
                CityCodes.Clear();

                if (Citys[i].CityCode.Trim().Length > 0)
                {
                    CityCodes.AddRange(Citys[i].CityCode.Split(new char[] { ',' }));
                }

                for (int j = 0; j < CityCodes.Count; j++)
                {
                    if (CityCodes[j].Trim().ToUpper() == citycode.Trim().ToUpper())
                    {
                        HandlerName = Citys[i].Name;
                    }
                }
            }

            if (string.IsNullOrEmpty(HandlerName))
            {
                for (int i = 0; i < Citys.Count; i++)
                {
                    CityCodes.Clear();

                    if (Citys[i].CityCode.Trim().Length > 0)
                    {
                        CityCodes.AddRange(Citys[i].CityCode.Split(new char[] { ',' }));
                    }

                    List<City> CityList = new List<City>();

                    for (int j = 0; j < CityCodes.Count; j++)
                    {
                        City city = _CommonService.FindCityByCityCode(CityCodes[j].Trim());

                        if (city != null && city.Name.Trim().ToUpper() == citycode.Trim().ToUpper())
                        {
                            HandlerName = Citys[i].Name;
                            break;
                        }
                    }

                    if (!string.IsNullOrEmpty(HandlerName))
                    {
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(HandlerName))
            {
                HandlerName = "DEFAULT";
            }


            return HandlerName;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblFirstName.Text.Trim()))
            {
                btnCreate.Enabled = false;
                lblErrorMeassage.Text = "For missing name, please contact Dallas office- Christine Chiang 1-(888)-2887528 ext 6268 cchiang@majestic-vacations.com";
                return;
            }

            if (string.IsNullOrEmpty(lblAccountCode.Text.Trim()))
            {
                btnCreate.Enabled = false;
                lblErrorMeassage.Text = "For missing account code, please contact Dallas office- Christine Chiang 1-(888)-2887528 ext 6268 cchiang@majestic-vacations.com";
                return;
            }

            if (string.IsNullOrEmpty(lblBranch.Text.Trim()))
            {
                btnCreate.Enabled = false;
                lblErrorMeassage.Text = "For missing branch, please contact Dallas office- Christine Chiang 1-(888)-2887528 ext 6268 cchiang@majestic-vacations.com";
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(), @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                lblErrorMeassage.Text = "The email is unavailable";
                return;
            }

            if (string.IsNullOrEmpty(txtCompanyname.Text.Trim()))
            {
                lblErrorMeassage.Text = "Please provide Company name";
                return;
            }

            if (string.IsNullOrEmpty(txtPhoneDay.Text.Trim()))
            {
                lblErrorMeassage.Text = "Please provide Phone.";
                return;
            }

            string FirstName = lblFirstName.Text.Trim();
            string LastName = lblLastName.Text.Trim();
            string EmailAddress = txtEmail.Text.Trim();
            string PhoneDay = txtPhoneDay.Text.Trim();
            string CompanyName = txtCompanyname.Text.Trim();
            string AccountCode = lblAccountCode.Text.Trim();
            string Branch = lblBranch.Text.Trim();
            string userID = lblUserId.Text.Trim();

            string arcNumber = lblARCNumber.Text.Trim();
            string Address = txtAddress.Text.Trim();
            string City = txtCity.Text.Trim();
            string State = txtState.Text.Trim();
            string ZipCode = txtZipCode.Text.Trim();
            string Country = txtCountry.Text.Trim();
            string Fax = txtFax.Text.Trim();
            string UserRoll = lblRool.Text.Trim();

            MemberInformation memberinfo = _MemberInformationService.GetGttMemberByEmail(EmailAddress);

            if (memberinfo != null)
            {
                #region 本地注册过 只建立GTT对象，但是更新本地信息
                Terms.Member.Domain.MemberInfoByGTTMeta memberInfoByGTTMeta = new Terms.Member.Domain.MemberInfoByGTTMeta();

                memberInfoByGTTMeta.AccountCode = AccountCode;
                memberInfoByGTTMeta.EmailAddress = EmailAddress;
                memberInfoByGTTMeta.FirstName = FirstName;
                memberInfoByGTTMeta.LastName = LastName;
                memberInfoByGTTMeta.MemberType = 1;
                memberInfoByGTTMeta.PhoneDay = PhoneDay;
                memberInfoByGTTMeta.RegisterTime = memberinfo.RegsterDate;
                memberInfoByGTTMeta.Source = "Subagent";
                memberInfoByGTTMeta.Status = "1";
                memberInfoByGTTMeta.GTTID = userID;
                memberInfoByGTTMeta.Branch = Branch;
                memberInfoByGTTMeta.CompanyName = CompanyName;

                memberInfoByGTTMeta.City = City;
                memberInfoByGTTMeta.DirectFrom = memberinfo.DirectFrom;
                memberInfoByGTTMeta.Gender = memberinfo.Gender;
                memberInfoByGTTMeta.GroupCode = memberinfo.GroupCode;
                memberInfoByGTTMeta.MemberCode = memberinfo.MemberCode;
                memberInfoByGTTMeta.MiddleName = memberinfo.MiddleName;
                memberInfoByGTTMeta.Nation = Country;
                memberInfoByGTTMeta.Passport = memberinfo.Passport;
                memberInfoByGTTMeta.Password = memberinfo.Password;
                memberInfoByGTTMeta.Password1 = memberinfo.Password1;
                memberInfoByGTTMeta.PhoneNight = memberinfo.PhoneNight;
                memberInfoByGTTMeta.Province = State;
                memberInfoByGTTMeta.Remark = memberinfo.Remark;
                memberInfoByGTTMeta.StreetAddress = Address;
                memberInfoByGTTMeta.ZipCode = ZipCode;
                memberInfoByGTTMeta.Birthday = DateTime.MaxValue;
                //add zyl 2009-9-14
                memberInfoByGTTMeta.ARCNumber = arcNumber;
                memberInfoByGTTMeta.Fax = Fax;
                memberInfoByGTTMeta.UserRoll = UserRoll;


                string city = Branch.Replace("GTT", string.Empty);

                string HandlerName = GetHandlerName(city.Trim());

                memberInfoByGTTMeta.Handler = HandlerName;

                try
                {
                    _MemberInformationService.SaveAndUpdateNewGttMember(memberInfoByGTTMeta, true);
                }
                catch
                {
                    lblErrorMeassage.Text = "service error";
                    return;
                }

                memberinfo.Status = "1";
                memberinfo.GttId = userID;
                memberinfo.Handler = HandlerName; 
                memberinfo.FirstName = FirstName;
                memberinfo.LastName = LastName;
                memberinfo.PhoneDay = PhoneDay;
                memberinfo.Source = "Subagent";

                memberinfo.City = City;
                memberinfo.Nation = Country;
                memberinfo.Province = State;
                memberinfo.ZipCode = ZipCode;
                memberinfo.ARCNumber = arcNumber;
                memberinfo.Fax = Fax;
                memberinfo.StreetAddress = Address;

                //当创建成功的时候应该通过MemberCode重新读取用户信息 Add zyl 2009-10-26
                memberinfo = _MemberInformationService.GetGttMemberByMember(memberInfoByGTTMeta.MemberCode);

                Utility.Transaction.IsLogin = true;
                Utility.Transaction.Member = memberinfo;

                this.Response.Redirect("Index.aspx");
                #endregion
            }
            else
            {
                #region 新建立用户

                //声明用户对象
                MemberInformation meta = new MemberInformation();
                Terms.Member.Domain.TOwner owner = new Terms.Member.Domain.TOwner();
                Terms.Member.Domain.MemberInfoByGTTMeta memberInfoByGTTMeta = new Terms.Member.Domain.MemberInfoByGTTMeta();

                //填充Member对象
                meta.EmailAddress = EmailAddress;
                meta.FirstName = FirstName;
                meta.LastName = LastName;
                meta.MemberType = 1;
                meta.PhoneDay = PhoneDay;
                meta.RegsterDate = DateTime.Now;
                meta.Source = "Subagent";
                meta.Status = "1";

                meta.MiddleName = "";
                meta.Gender = Convert.ToInt32(0);
                meta.Password = "";
                meta.Password1 = "";
                meta.City = City;
                meta.StreetAddress = Address;
                meta.Nation = Country;
                meta.Province = State;
                meta.ZipCode = ZipCode;
                meta.Remark = "";

                //填充公司对象
                owner.CompanyName = CompanyName;
                owner.ArcNum = arcNumber;

                //填充GTT对象
                memberInfoByGTTMeta.AccountCode = AccountCode;
                memberInfoByGTTMeta.EmailAddress = EmailAddress;
                memberInfoByGTTMeta.FirstName = FirstName;
                memberInfoByGTTMeta.LastName = LastName;
                memberInfoByGTTMeta.MemberType = 1;
                memberInfoByGTTMeta.PhoneDay = PhoneDay;
                memberInfoByGTTMeta.RegisterTime = DateTime.Now;
                memberInfoByGTTMeta.Source = "Subagent";
                memberInfoByGTTMeta.Status = "1";
                memberInfoByGTTMeta.GTTID = userID;
                memberInfoByGTTMeta.Branch = Branch;
                memberInfoByGTTMeta.CompanyName = CompanyName;

                memberInfoByGTTMeta.MiddleName = "";
                memberInfoByGTTMeta.Gender = Convert.ToInt32(0);
                memberInfoByGTTMeta.Password = "";
                memberInfoByGTTMeta.Password1 = "";
                memberInfoByGTTMeta.Remark = "";
                //add zyl 2009-9-14
                memberInfoByGTTMeta.City = City;
                memberInfoByGTTMeta.StreetAddress = Address;
                memberInfoByGTTMeta.Nation = Country;
                memberInfoByGTTMeta.Province = State;
                memberInfoByGTTMeta.ZipCode = ZipCode;
                memberInfoByGTTMeta.ARCNumber = arcNumber;
                memberInfoByGTTMeta.Fax = Fax;
                memberInfoByGTTMeta.UserRoll = UserRoll;

                memberInfoByGTTMeta.Birthday = DateTime.MaxValue;

                //根据city获得Handler
                string city = Branch.Replace("GTT", string.Empty);

                string HandlerName = GetHandlerName(city.Trim());

                meta.Handler = HandlerName;
                memberInfoByGTTMeta.Handler = HandlerName;

                //保存
                try
                {
                    string strMemberCode = _MemberInformationService.SaveNewMemberInformation(meta, owner, memberInfoByGTTMeta, true);
                }
                catch
                {
                    lblErrorMeassage.Text = "service error";
                    return;
                }                

                //meta.MemberCode = memberInfoByGTTMeta.MemberCode;
                //当创建成功的时候应该通过MemberCode重新读取用户信息 Add zyl 2009-10-26
                meta = _MemberInformationService.GetGttMemberByMember(memberInfoByGTTMeta.MemberCode);


                //登录系统
                Utility.Transaction.IsLogin = true;
                Utility.Transaction.Member = meta;

                this.Response.Redirect("Index.aspx");
                #endregion
            }
        }

        private void FillPage(string[] pars)
        {
            lblFirstName.Text = pars[0] + " ";
            lblLastName.Text = pars[1];
            txtEmail.Text = pars[2];
            txtPhoneDay.Text = pars[3];
            txtCompanyname.Text = pars[4];
            lblAccountCode.Text = pars[5];
            lblBranch.Text = pars[6];
            lblUserId.Text = pars[7];

            //add zyl 2009-9-14
            lblARCNumber.Text = MJVID[8];
            txtAddress.Text = MJVID[9];
            txtCity.Text = MJVID[10];
            txtState.Text = MJVID[11];
            txtZipCode.Text = MJVID[12];
            txtCountry.Text = MJVID[13];
            txtFax.Text = MJVID[14];
            lblRool.Text = MJVID[15];
        }
    }
}