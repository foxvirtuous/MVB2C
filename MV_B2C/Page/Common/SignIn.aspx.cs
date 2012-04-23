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

namespace Terms.Web.Page.Common
{
    public partial class SignIn : SalseBasePage
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

        public SignIn()
        {
            this.InitializeControls += new EventHandler(SignIn_InitializeControls);
        }

        void SignIn_InitializeControls(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool flag = false;

            if (txtUserName.Text.Trim() == "")
            {
                //Utility.Transaction.IsLogin = false;
                Response.Write("<script>alert('Invalid email, Please try again')</script>");
                return;
            }

            MemberInformation Member = memberInformationService.FindMemberInformationByUserName(txtUserName.Text.Trim(), 0);

            //≈–∂œEmail
            if (Member == null)
            {
                //Utility.Transaction.IsLogin = false;
                Response.Write("<script>alert('Invalid email, Please try again')</script>");
                return;
            }

            if (Member.MemberType == 1)
            {
                Response.Write("<script>alert('Invalid email, Please try again')</script>");
                return;
            }

            //≈–∂œ√‹¬Î
            if (Member.Password.Trim().Equals(EncryptPassword(this.txtPassword.Text.Trim())))
            {
                Utility.Transaction.IsLogin = true;
                Utility.Transaction.Member = Member;

                Response.Redirect(SecureUrlSuffix + "Page/Common/MemberMyAccountForm.aspx");
                   
            }
            else
            {
                Utility.Transaction.IsLogin = false;
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
    }
}
