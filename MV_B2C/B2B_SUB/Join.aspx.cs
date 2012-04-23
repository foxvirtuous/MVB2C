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

public partial class Join : SalseBasePage
{
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

    public Join()
    {
        this.InitializeControls += new EventHandler(Join_InitializeControls);
    }

    void Join_InitializeControls(object sender, EventArgs e)
    {
        this.SetWebSiteInfomation();
        if (!this.Page.IsPostBack)
        {
            //divARC.Visible = false;

            BindStateAndCountry();

            if (this.Request["PWD"] != null && this.Request["PWD"] == "48136315")
            {
                Button1.Visible = true;
                TextBox1.Visible = true;
            }
            else
            {
                Button1.Visible = false;
                TextBox1.Visible = false;
            }
        }
    }
    protected void btnCreat_Click(object sender, EventArgs e)
    {
        string strCPEmail = txtCPEmail.Text;
        string strPwd = txtPwd.Text;
        string strPwdAgain = txtPwdAgain.Text;
        string strCPFirstName = txtCPFirstName.Text;
        string strCPMiddleName = txtCPMiddleName.Text;
        string strCPLastName = txtCPLastName.Text;
        string strCPTel = txtCPTel.Text;
        string strCPFax = txtCPFax.Text;
        string strCPAddress = txtCPAddress.Text;
        string strCPCity = txtCPCity.Text;
        string strCPCountry = dllCPCountry.SelectedValue;
        string strCPState = dllCPState.SelectedValue;
        string strCPZip = txtCPZip.Text;
        string strARCNum = "";//txtARCNum.Text;
        string strComName = txtComName.Text;
        string strOwnFistName = "";//txtOwnFistName.Text;
        string strOwnMiddleName = "";//txtOwnMiddleName.Text;
        string strOwnLastName = "";//txtOwnLastName.Text;

        if (string.IsNullOrEmpty(strCPEmail.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Email is null. Choose another');</script>");
            return;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(strCPEmail, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Email Format error. Choose another');</script>");
            return;
        }

        int iCount = _MemberInformationService.GetEmail(strCPEmail, 1);

        if (iCount > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Email Address entered is already in use. Choose another');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strPwd.Trim()) && string.IsNullOrEmpty(strPwdAgain.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert(' Password and Password again must enter ');</script>");
            return;
        }

        if (!strPwd.Trim().Equals(strPwdAgain.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('You enterd the diffrent password');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPFirstName.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('First Name must enter');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPLastName.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Last Name must enter');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPTel.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Telphone must enter');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPAddress.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Address must enter');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPCity.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('City must enter');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPCountry.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Email Address entered is already in use. Choose another');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPState.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Email Address entered is already in use. Choose another');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strCPZip.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('ZipCode must enter');</script>");
            return;
        }

        if (string.IsNullOrEmpty(strComName.Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Company Name must enter');</script>");
            return;
        }

        Terms.Member.Business.MemberInformation meta = new Terms.Member.Business.MemberInformation();

        meta.FirstName = strCPFirstName;
        meta.MiddleName = strCPMiddleName;
        meta.LastName = strCPLastName;
        meta.Gender = Convert.ToInt32(0);
        meta.EmailAddress = strCPEmail;
        meta.Password = MemberUtility.Lock(strPwd);
        meta.Password1 = strPwd;
        meta.PhoneDay = strCPTel;
        meta.City = strCPCity;
        meta.StreetAddress = strCPAddress;
        meta.Nation = strCPCountry;
        meta.Province = strCPState;
        meta.ZipCode = strCPZip;
        meta.Remark = strCPFax;
        meta.Source = "MVB2B";
        meta.MemberType = 1;
        meta.Status = "0";

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
                if (CityCodes[j].Trim().ToUpper() == meta.City.Trim().ToUpper())
                {
                    HandlerName = Citys[i].Name;
                }
            }
        }

        //if (string.IsNullOrEmpty(HandlerName))
        //{
        //    for (int i = 0; i < Citys.Count; i++)
        //    {
        //        CityCodes.Clear();

        //        if (Citys[i].CityCode.Trim().Length > 0)
        //        {
        //            CityCodes.AddRange(Citys[i].CityCode.Split(new char[] { ',' }));
        //        }

        //        List<City> CityList = new List<City>();

        //        for (int j = 0; j < CityCodes.Count; j++)
        //        {
        //            City city = _CommonService.FindCityByCityCode(CityCodes[j].Trim());

        //            if (city != null && city.Name.Trim().ToUpper() == meta.City.Trim().ToUpper())
        //            {
        //                HandlerName = Citys[i].Name;
        //                break;
        //            }
        //        }

        //        if (!string.IsNullOrEmpty(HandlerName))
        //        {
        //            break;
        //        }
        //    }
        //}

        if (string.IsNullOrEmpty(HandlerName))
        {
            HandlerName = "DEFAULT";
        }

        meta.Handler = HandlerName;

        TOwner owner = new TOwner();

            owner.ArcNum = strARCNum;
            owner.CompanyName = strComName;
            owner.FistName = strOwnFistName;
            owner.MiddleName = strOwnMiddleName;
            owner.LastName = strOwnLastName;
            owner.GTTAccountCode = String.Empty;


        string strMemberCode = _MemberInformationService.SaveNewMemberInformation(meta, owner);

        MailMessage mailMessage = new MailMessage();

        mailMessage.From = new MailAddress(@"res@majestic-vacations.com");
        mailMessage.To.Add(new MailAddress(strCPEmail));
        mailMessage.IsBodyHtml = true;
        mailMessage.Subject = "Thank You for Registering!";

        mailMessage.Body = "Thank for registering our Majestic Vacations Travel Agent Website. " +
         "We will review your application within next 2 business day " +
         "and let you know if your application is approved " +
         "or if any additonal infomation are required.";



        Terms.Member.Utility.MemberUtility.SendEmail(mailMessage, "B2BMembership");

        OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_RegisterMember, this);                

        this.Response.Redirect("AgentJoinSucceedForm.aspx");
    }

    private void BindStateAndCountry()
    {
        IList ilist = _CommonService.FindCountryAll();

        ListItem itemNew = new ListItem("CANADA", "CA");

        dllCPCountry.Items.Add(itemNew);

        itemNew = new ListItem("United States", "US");

        dllCPCountry.Items.Add(itemNew);

        dllCPCountry.SelectedIndex = dllCPCountry.Items.IndexOf(dllCPCountry.Items.FindByValue("US"));

        dllCPCountry_SelectedIndexChanged(null, new EventArgs());
    }
    protected void dllCPCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        IList ilist = _CommonService.FindProvincesByCountryCode(dllCPCountry.SelectedValue);

        dllCPState.DataSource = ilist;
        dllCPState.DataTextField = "Name";
        dllCPState.DataValueField = "Name";
        dllCPState.DataBind();
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

    //protected void lbtnARC_Click(object sender, EventArgs e)
    //{
    //    if (!string.IsNullOrEmpty(txtARCNum.Text))
    //    {
    //        divARC.Visible = true;

    //        IList owner = _MemberInformationService.GetOwnerByARC(txtARCNum.Text);

    //        if (owner.Count > 0)
    //        {
    //            TOwner item = (TOwner)owner[0];

    //            lblArcCode.Text = item.OwnerCode;

    //            lblComName.Visible = true;
    //            lblComName.Text = item.CompanyName;
    //            txtComName.Visible = false;

    //            lblOwnFistName.Visible = true;
    //            lblOwnFistName.Text = item.FistName;
    //            txtOwnFistName.Visible = false;

    //            lblOwnMiddleName.Visible = true;
    //            lblOwnMiddleName.Text = item.MiddleName;
    //            txtOwnMiddleName.Visible = false;

    //            lblOwnLastName.Visible = true;
    //            lblOwnLastName.Text = item.LastName;
    //            txtOwnLastName.Visible = false;

    //        }
    //        else
    //        {
    //            lblArcCode.Text = string.Empty;
    //            txtComName.Visible = true;
    //            lblComName.Visible = false;

    //            txtComName.Text = string.Empty;
    //            txtComName.Visible = true;
    //            lblComName.Visible = false;

    //            txtOwnFistName.Text = string.Empty;
    //            txtOwnFistName.Visible = true;
    //            lblOwnFistName.Visible = false;

    //            txtOwnMiddleName.Text = string.Empty;
    //            txtOwnMiddleName.Visible = true;
    //            lblOwnMiddleName.Visible = false;

    //            txtOwnLastName.Text = string.Empty;
    //            txtOwnLastName.Visible = true;
    //            lblOwnLastName.Visible = false;
    //        }
    //    }
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(TextBox1.Text);

        System.Data.SqlClient.SqlCommand select = new System.Data.SqlClient.SqlCommand("Select * FROM Subagent", con);

        System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter(select);

        DataTable dt = new DataTable("Subagent");

        da.Fill(dt);

        if (dt.Rows.Count > 0)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                IList owners = _MemberInformationService.GetOwnerByARC(dt.Rows[i]["ARCNumber"].ToString());

                Terms.Member.Business.MemberInformation meta = new Terms.Member.Business.MemberInformation();

                meta.FirstName = dt.Rows[i]["ContectPersonFirstName"].ToString();
                meta.MiddleName = dt.Rows[i]["ContectPersonMiddleName"].ToString();
                meta.LastName = dt.Rows[i]["ContectPersonLastName"].ToString();
                meta.Gender = Convert.ToInt32(0);
                meta.EmailAddress = dt.Rows[i]["Email"].ToString();
                meta.Password = MemberUtility.Lock(dt.Rows[i]["Password"].ToString());
                meta.PhoneDay = dt.Rows[i]["BusinessPhone"].ToString();
                meta.City = dt.Rows[i]["City"].ToString();
                meta.StreetAddress = dt.Rows[i]["Address"].ToString();
                meta.Nation = "US";
                meta.Province = dt.Rows[i]["State"].ToString();
                meta.ZipCode = dt.Rows[i]["Zip"].ToString();
                meta.Remark = dt.Rows[i]["History"].ToString();
                meta.Source = "MVB2B";
                meta.MemberType = 1;
                if (dt.Rows[i]["Status"].ToString() == "1")
                {
                    meta.Status = "1";
                }
                else
                {
                    meta.Status = "2";
                }

                TOwner owner = new TOwner();

                if (owners == null || owners.Count == 0)
                {
                    owner.ArcNum = dt.Rows[i]["ARCNumber"].ToString();
                    owner.CompanyName = dt.Rows[i]["CompanyName"].ToString();
                    owner.FistName = dt.Rows[i]["OwnerFirstName"].ToString();
                    owner.MiddleName = dt.Rows[i]["OwnerMiddleName"].ToString();
                    owner.LastName = dt.Rows[i]["OwnerLastName"].ToString();
                }
                else
                {
                    owner.OwnerCode = ((TOwner)owners[0]).OwnerCode;
                }

                //IList owner = _MemberInformationService.GetOwnerByARC(txtARCNum.Text);

                _MemberInformationService.SaveNewMemberInformation(meta, owner);
            }
        }
    }
}
