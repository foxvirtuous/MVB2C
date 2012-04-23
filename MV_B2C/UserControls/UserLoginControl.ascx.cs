using System;
using System.Data;
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

using Terms.Member.Dao;
using Terms.Member.Service;
using Terms.Member.Domain;

using System.Security.Cryptography;
using Terms.Sales.Business;
using Terms.Member.Business;


public partial class UserLoginControl : SalesBaseUserControl
{
    public delegate void LoginClickDelegete();
    public LoginClickDelegete loginClick = null;

    public delegate void CheckRoomAndPassengerNumberDelegete();
    public CheckRoomAndPassengerNumberDelegete CheckPassNumber = null;

    //public delegate void SetTourCondition();
    //public SetTourCondition SetTourInfo = null;

    private IMemberInformationService memberInformationService;
    public IMemberInformationService MemberInformationService
    {
        set { this.memberInformationService = value; }
    }

    private string strNextUrl;
    public string NextUrl
    {
        set
        {
            strNextUrl = value;
        }
    }

    private string strReturnUrl;
    public string ReturnUrl
    {
        set
        {
            strReturnUrl = value;
        }
        get
        {
            if (this.Request["ReturnUrl"] != null && this.Request["ReturnUrl"].Trim().Length == 0)
            {
                return this.Request["ReturnUrl"];
            }
            else
            {
                return strReturnUrl;
            }
        }
    }

    public UserLoginControl()
    {
        this.InitializeControls += new EventHandler(UserLogin_InitializeControls);
    }

    public void UserLogin_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.SetWebSiteInfomation();
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        bool flag = false;

        HTLSelectRoomTypeControl _htlSelectRoomTypeControl = null;

        if (!Utility.IsSearchConditionNull)
        {
            CheckBox chb = null;

            if (Utility.Transaction.CurrentSearchConditions is HotelSearchCondition)
            {
                chb = (CheckBox)this.Parent.FindControl("chkConditions");
            }

            if (Utility.Transaction.CurrentSearchConditions is PackageSearchCondition)
            {
                chb = (CheckBox)this.Parent.FindControl("chkConditions");
            }

            if (Utility.Transaction.CurrentSearchConditions is TourSearchCondition)
            {
                chb = (CheckBox)this.Parent.FindControl("chkConditions");
                CheckPassNumber();

                CheckBox chk = (CheckBox)this.Parent.FindControl("chkCheck");
                TextBox txtErr = (TextBox)this.Parent.FindControl("txtErr");

                if (!chk.Checked)
                {
                    string warningString = string.Empty;
                    if (txtErr.Text.Contains("and"))
                        warningString = "The passenger number of " + txtErr.Text + " are invalid";
                    else
                        warningString = "The passenger number of " + txtErr.Text + " is invalid";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('" + warningString + "');</script>");
                    return;
                }
            }

            if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                flag = true;
            }


            if (chb != null)
            {
                if (!chb.Checked)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please read & confirm the Terms and Conditions to continue');</script>");

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "alt", "if(document.getElementById('clickLink')!= null){document.getElementById('clickLink').click();}", true);
                    return;
                }
                else
                {
                    flag = true;
                }
            }
        }


        if (txtUserName.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('You may have entered an unknown user name or an incorrect password.');</script>");
            return;
        }

        MemberInformation Member = memberInformationService.FindMemberInformationByUserName(txtUserName.Text.Trim(), SourceName);

        //ÅÐ¶ÏEmail
        if (Member == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('You may have entered an unknown user name or an incorrect password.');</script>");
            return;
        }

        //ÅÐ¶ÏÃÜÂë
        if (Member.Password.Trim().Equals(EncryptPassword(this.txtPassword.Text.Trim())))
        {
            Utility.Transaction.IsLogin = true;
            Utility.Transaction.Member = Member;

            _htlSelectRoomTypeControl = (HTLSelectRoomTypeControl)this.Parent.FindControl("HTLSelectRoomTypeControl1");

            if (_htlSelectRoomTypeControl != null)
            {
                _htlSelectRoomTypeControl.BookPrice();
            }

            if (string.IsNullOrEmpty(strNextUrl))
            {
                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    Response.Redirect("~/Index.aspx");
                }
                else
                {
                    Response.Redirect(ReturnUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                }
            }
            else
            {
                if (flag)
                {
                    //PackageSearchResult2dFrom page = (PackageSearchResult2dFrom)this.Parent;

                    if (loginClick != null)
                    {
                        //if (CheckPassNumber != null)
                        //    CheckPassNumber();
                        //if (SetTourInfo != null)
                        //    SetTourInfo();
                        loginClick();
                        Response.Redirect(strNextUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                    }
                    else
                    {
                        Response.Redirect(strNextUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                    }
                    //¼ÇÂ¼µÇÂ¼ÊÂ¼þ
                    if (Utility.IsSubAgent)
                        OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_Login, this);
                    else
                        OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.LogIn, this);
                }
                else
                {
                    Response.Redirect(ReturnUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                }

            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('You may have entered an unknown user name or an incorrect password.');</script>");
            return;
        }
    }

    public String EncryptPassword(String password)
    {
        char[] data = password.ToCharArray();
        byte[] binData = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            binData[i] = (byte)data[i];
        }

        MD5 md5 = new MD5CryptoServiceProvider();

        byte[] binResult = md5.ComputeHash(binData);
        String result = null;
        foreach (byte b in binResult)
        {
            result += Convert.ToString(b, 16);
        }

        return result;
    }
    protected void hlregister_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Page/Common/register.aspx?ReturnUrl=" + ReturnUrl + "&ConditionID=" + Request.Params["ConditionID"]);
    }
    protected void hlEmailpassword_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Page/Common/SalesEmailpassword.aspx?ReturnUrl=" + ReturnUrl + "&ConditionID=" + Request.Params["ConditionID"]);
    }
}
