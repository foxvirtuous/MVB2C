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

using Terms.Material.Domain;

using System.Security.Cryptography;

using log4net;
using Spring.Web.UI;
using Terms.Member.Business;

public partial class SalesLogin : SalseBasePage
{
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

    public SalesLogin()
    {
        this.InitializeControls += new EventHandler(SalesLogin_InitializeControls);
    }

    void SalesLogin_InitializeControls(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    override protected void OnInit(EventArgs e)
    {
        InitializeComponent();
        base.OnInit(e);
    }

    private void InitializeComponent()
    {
        this.PreRender += new EventHandler(SalesLogin_PreRender);
    }

    void SalesLogin_PreRender(object sender, EventArgs e)
    {
        if (Request.Params["IsLogin"] != null
             && Request.Params["IsLogin"].ToString().Trim().Length > 0)
        {
            bool flag = false;

            if (txtUserName.Text.Trim() == "")
            {
                lblMessage.Visible = true;
                return;
            }

            MemberInformation Member = memberInformationService.FindMemberInformationByUserName(txtUserName.Text.Trim(), 0);

            //判断Email
            if (Member == null)
            {
                lblMessage.Visible = true;
                return;
            }

            if (Member.MemberType == 1)
            {
                lblMessage.Visible = true;
                return;
            }


            //判断密码
            if (Member.Password.Trim().Equals(EncryptPassword(this.txtPassword.Text.Trim())))
            {
                Utility.Transaction.IsLogin = true;
                Utility.Transaction.Member = Member;
                if (string.IsNullOrEmpty(strNextUrl))
                {
                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        Response.Redirect("~/Index.aspx");
                    }
                    else
                    {
                        Response.Redirect(ReturnUrl);
                    }
                }
                else
                {
                    if (flag)
                    {
                        Response.Redirect(strNextUrl);
                    }
                    else
                    {
                        Response.Redirect(ReturnUrl);
                    }

                }
            }
            else
            {
                Utility.Transaction.IsLogin = false;
                lblMessage.Visible = true;
                return;
            }
        }
    }

    protected void hlEmailpassword_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Page/Common/SalesEmailpassword.aspx?ReturnUrl=" + ReturnUrl);
    }
    //protected void btnLogin_Click(object sender, EventArgs e)
    //{
    //    bool flag = false;

    //    if (txtUserName.Text.Trim() == "")
    //    {
    //        //Utility.Transaction.IsLogin = false;
    //        Response.Write("<script>alert('Invalid email, Please try again')</script>");
    //        return;
    //    }

    //    //txtUserName.Text = txtUserName.Text.Replace(@"<", "");
    //    //txtUserName.Text = txtUserName.Text.Replace(@">", "");
    //    //txtUserName.Text = txtUserName.Text.Replace(@" ", "");
    //    //txtUserName.Text = txtUserName.Text.Replace("\"", "");

    //    MemberInformation Member = memberInformationService.FindMemberInformationByUserName(txtUserName.Text.Trim(), 0);

    //    //判断Email
    //    if (Member == null)
    //    {
    //        //Utility.Transaction.IsLogin = false;
    //        Response.Write("<script>alert('Invalid email, Please try again')</script>");
    //        return;
    //    }

    //    if (Member.MemberType == 1)
    //    {
    //        Response.Write("<script>alert('Invalid email, Please try again')</script>");
    //        return;
    //    }

    //    //txtPassword.Text = txtPassword.Text.Replace(@"<", "");
    //    //txtPassword.Text = txtPassword.Text.Replace(@">", "");
    //    //txtPassword.Text = txtPassword.Text.Replace(@" ", "");
    //    //txtPassword.Text = txtPassword.Text.Replace("\"", "");


    //    //判断密码
    //    if (Member.Password.Trim().Equals(EncryptPassword(this.txtPassword.Text.Trim())))
    //    {
    //        Utility.Transaction.IsLogin = true;
    //        Utility.Transaction.Member = Member;
    //        if (string.IsNullOrEmpty(strNextUrl))
    //        {
    //            if (string.IsNullOrEmpty(ReturnUrl))
    //            {
    //                Response.Redirect("~/Index.aspx");
    //            }
    //            else
    //            {
    //                Response.Redirect(ReturnUrl);
    //            }
    //        }
    //        else
    //        {
    //            if (flag)
    //            {
    //                Response.Redirect(strNextUrl);
    //            }
    //            else
    //            {
    //                Response.Redirect(ReturnUrl);
    //            }

    //        }
    //    }
    //    else
    //    {
    //        Utility.Transaction.IsLogin = false;
    //        Response.Write("<script>alert('Invalid password, Please try again')</script>");
    //        return;
    //    }
    //}
    protected void btnCreate_Click(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Page/Common/register.aspx?");//ReturnUrl=" + ReturnUrl);
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
}
