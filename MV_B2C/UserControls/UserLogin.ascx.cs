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
using Terms.Member.Business;
using Terms.Sales.Business;

public partial class UserLogin : SalesBaseUserControl
{
    public delegate void LoginClickDelegete();
    public LoginClickDelegete loginClick = null;

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
            if (this.Request["ReturnUrl"] != null)
            {
                return this.Request["ReturnUrl"];
            }
            else
            {
                return strReturnUrl;
            }
        }
    }

    public UserLogin()
    {
        this.InitializeControls += new EventHandler(UserLogin_InitializeControls);
    }

    public void UserLogin_InitializeControls(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {

        bool flag = false;

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
            if (Utility.Transaction.CurrentSearchConditions is AirSearchCondition)
            {
                flag = true;
            }
            if (chb != null)
            {
                if (!chb.Checked)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Please read Terms & Conditions, And cancels elects');</script>");
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
            Response.Write("<script>alert('Invalid email, Please try again')</script>");
            return;
        }

        MemberInformation Member = memberInformationService.FindMemberInformationByUserName(txtUserName.Text.Trim(), SourceName);

        //判断Email
        if (Member == null)
        {
            Response.Write("<script>alert('Invalid email, Please try again')</script>");
            return;
        }

        //判断密码
        if (Member.Password.Trim().Equals(EncryptPassword(this.txtPassword.Text.Trim())))
        {
            Utility.Transaction.Member = Member;
            Utility.Transaction.IsLogin = true;
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
                        loginClick();
                        Response.Redirect(strNextUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                    }
                    else
                    {
                        //Utility.IsLogin = true;
                        Response.Redirect(strNextUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                    }
                }
                else
                {
                    Response.Redirect(ReturnUrl + "?ConditionID=" + Request.Params["ConditionID"]);
                }

            }
        }
        else
        {
            Response.Write("<script>alert('Invalid password, Please try again')</script>");
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
