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
using Terms.Member.Service;
using Terms.Member.Business;
using System.Security.Cryptography;


public partial class IndexForFlight : IndexPageBase
{
    private IMemberInformationService memberInformationService;
    public IMemberInformationService MemberInformationService
    {
        set { this.memberInformationService = value; }
    }

    protected virtual string SourceName
    {
        get
        {
            return GlobalBaseUtility.GetClassName(GlobalBaseUtility.GetWebSite(Request.Url));
        }
    }


    #region Property
    /// <summary>
    /// The Path
    /// </summary>
    /// 
    private string path = string.Empty;
    public string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }

    public string SaleWebSuffix
    {
        get
        {
            return PageUtility.UrlSuffix;
        }
    }

    private string AbsolutePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
    private string UrlHost
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.Url.Host;
            else
                return string.Empty;
        }

    }

    private string VirtualPath
    {
        get
        {
            if (HttpContext.Current != null)
                return HttpContext.Current.Request.ApplicationPath;
            else
                return string.Empty;
        }

    }

    private string UrlSuffix
    {
        get
        {
            //段口
            int port = HttpContext.Current.Request.Url.Port;

            //虚拟目录
            string path = VirtualPath;
            if (path == "/") path = "";

            if (port == 80)
                return "http://" + UrlHost + path + "/";
            else
                return "http://" + UrlHost + ":" + port.ToString() + path + "/";
        }
    }
    #endregion

    public IndexForFlight()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["IndexForFlight"] != null)
            {
                Response.Redirect("~/Page/Flight/Searching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
            }
            else
            {
                Session["IndexForFlight"] = true;
            }
        }
    }


    protected void btnRegister_Click(object sender, EventArgs e)
    {
        
    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //
    }

    protected void hlEmailpassword_Click(object sender, EventArgs e)
    {
        
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        

        //Response.Redirect("~/Page/Flight/Searching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
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

    protected void btnLogin_Click1(object sender, EventArgs e)
    {
        bool flag = false;

        if (txtUserName.Text.Trim() == "")
        {
            lblErrorMsg.Text = Resources.HintInfo.EmptyID;
            lblErrorMsg.Visible = true;
            txtUserName.Focus();
            return;
        }

        if (txtPassword.Text.Trim() == "")
        {
            lblErrorMsg.Text = Resources.HintInfo.EmptyPassword;
            lblErrorMsg.Visible = true;
            txtPassword.Focus();
            return;
        }

        MemberInformation Member = memberInformationService.FindMemberInformationByUserName(txtUserName.Text.Trim());

        //判断Email
        if (Member == null)
        {
            lblErrorMsg.Text = Resources.HintInfo.NoThisAccount;
            lblErrorMsg.Visible = true;
            txtUserName.Focus();
            //Response.Write("<script>alert('" + Resources.HintInfo.InvalidEmail + "')</script>");
            return;
        }
        else
        {
            //万能会员（所有网站都能登录）当前给予分配SourceName，以便处理。
            if (Member.Source == null || Member.Source.Equals(string.Empty))
                Member.Source = SourceName;
        }
        //判断密码
        if (Member.Password.Trim().Equals(EncryptPassword(this.txtPassword.Text.Trim())))
        {
            Utility.Transaction.IsLogin = true;
            Utility.Transaction.Member = Member;

            //设置用户来源Session
            GlobalBaseUtility.SetDirectFromName(Member.DirectFrom);

            //记录LogIn日志
            OperaterAdvice.DoAdvice(Terms.Configuration.Utility.ConfigurationConst.OperateType.LogIn, this);

            Session["HasReminder"] = true;


            bool IsSelectAirport = false;
            bool IsRealCity = false;

            if (Request["IsRealCity"] != null)
            {
                IsRealCity = Convert.ToBoolean(Request["IsRealCity"]);
            }

            if (Request["IsSelectAirport"] != null)
            {
                IsSelectAirport = Convert.ToBoolean(Request["IsSelectAirport"]);
            }

            if (!IsRealCity)
            {
                if (Request["DateErrorMsg"] == null)
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                }
            }
            else
            {
                if (IsSelectAirport)
                {
                    if (Request["DateErrorMsg"] == null)
                    {
                        Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                    }
                }
                else
                {
                    if (Request["DateErrorMsg"] == null)
                    {
                        Response.Redirect("~/Page/Flight/Searching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                    }
                    else
                    {
                        Response.Redirect("~/Page/Flight/Searching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                    }

                }
            }


        }
        else
        {
            Session["HasLoginFailure"] = true;
            Utility.Transaction.IsLogin = false;
            lblErrorMsg.Text = Resources.HintInfo.NoThisAccount;
            lblErrorMsg.Visible = true;
            txtPassword.Focus();
            return;
        }
    }

    protected void btnContinue_Click1(object sender, EventArgs e)
    {
        bool IsSelectAirport = false;
        bool IsRealCity = false;

        if (Request["IsRealCity"] != null)
        {
            IsRealCity = Convert.ToBoolean(Request["IsRealCity"]);
        }

        if (Request["IsSelectAirport"] != null)
        {
            IsSelectAirport = Convert.ToBoolean(Request["IsSelectAirport"]);
        }

        if (!IsRealCity)
        {
            if (Request["DateErrorMsg"] == null)
            {
                Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
            }
            else
            {
                Response.Redirect("~/Page/Flight/SearchConditionsMeaasageForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
            }
        }
        else
        {
            if (IsSelectAirport)
            {
                if (Request["DateErrorMsg"] == null)
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    Response.Redirect("~/Page/Flight/SearchConditionsForm.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                }
            }
            else
            {
                if (Request["DateErrorMsg"] == null)
                {
                    Response.Redirect("~/Page/Flight/Searching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString());
                }
                else
                {
                    Response.Redirect("~/Page/Flight/Searching.aspx" + "?ConditionID=" + Utility.Transaction.IntKey.ToString() + "&DateErrorMsg=" + Resources.HintInfo.AirDateError);
                }

            }
        }
    }

    protected void btnRegister_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/Page/Common/register.aspx");
    }

    protected void hlEmailpassword_Click1(object sender, EventArgs e)
    {
        this.Response.Redirect("~/Page/Common/SalesEmailpassword.aspx?ReturnUrl=" + "~/Index.aspx");
    }
}