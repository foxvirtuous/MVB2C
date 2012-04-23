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

namespace Terms.Web.B2B_SUB
{
    public partial class Login : SalseBasePage
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

        public Login()
        {
            this.InitializeControls += new EventHandler(Login_InitializeControls);
        }

        void Login_InitializeControls(object sender, EventArgs e)
        {
            //this.SetWebSiteInfomation();

            //if (!IsPostBack)
            //{
            //    //this.Button1.Attributes.Add("onclick", "javascript:return confirm('We are moving the Travel Agent login from Majestic website to www.gttglobal.com website.  Pls call (888)-288-7528 x 5026 (Frank) or x 6268 (Christine) for assistance.');");
            //}
        }
        protected void hlEmailpassword_Click(object sender, EventArgs e)
        {
            //this.Response.Redirect("Forget.aspx?ReturnUrl=" + ReturnUrl);
        }

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.PreRender += new EventHandler(Login_PreRender);
        }

        void Login_PreRender(object sender, EventArgs e)
        {
            //if (Request.Params["IsLogin"] != null
            // && Request.Params["IsLogin"].ToString().Trim().Length > 0)
            //{
            //    bool flag = false;
            //    lblMessage.Visible = false;

            //    if (txtUserName.Text.Trim() == "")
            //    {
            //        lblMessage.Visible = true;
            //        return;
            //    }

            //    txtUserName.Text = txtUserName.Text.Replace(@"<", "");
            //    txtUserName.Text = txtUserName.Text.Replace(@">", "");
            //    txtUserName.Text = txtUserName.Text.Replace(@" ", "");
            //    txtUserName.Text = txtUserName.Text.Replace("\"", "");


            //    MemberInformation Member = memberInformationService.FindMemberInformationByUserName(txtUserName.Text.Trim(), 1);

            //    //判断Email
            //    if (Member == null)
            //    {
            //        lblMessage.Visible = true;
            //        return;
            //    }

            //    if (Member.MemberType == 0)
            //    {
            //        lblMessage.Visible = true;
            //        return;
            //    }

            //    txtPassword.Text = txtPassword.Text.Replace(@"<", "");
            //    txtPassword.Text = txtPassword.Text.Replace(@">", "");
            //    txtPassword.Text = txtPassword.Text.Replace(@" ", "");
            //    txtPassword.Text = txtPassword.Text.Replace("\"", "");


            //    //判断密码
            //    if (Member.Password.Trim().Equals(EncryptPassword(this.txtPassword.Text.Trim())))
            //    {
            //        if (Member.Status.Trim() != "1".Trim())
            //        {
            //            lblMessage.Visible = true;
            //            return;
            //        }
            //        else
            //        {
            //            lblMessage.Visible = false;
            //        }

            //        Utility.Transaction.IsLogin = true;
            //        Utility.Transaction.Member = Member;

            //        if (Member.Branch.Trim().Length == 0 && Member.AccountCode.Trim().Length == 0)
            //        {
            //            MemberInformation gtt = memberInformationService.GetGttMemberByMember(Member.MemberCode);

            //            if (gtt != null)
            //            {
            //                Utility.Transaction.Member = gtt;
            //            }
            //        }

            //        OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.SUB_Login, this);

            //        if (string.IsNullOrEmpty(strNextUrl))
            //        {
            //            if (string.IsNullOrEmpty(ReturnUrl))
            //            {
            //                Response.Redirect("~/B2B_SUB/Index.aspx");
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
            //        lblMessage.Visible = true;
            //        return;
            //    }
            //}
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("Join.aspx");
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
}
