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
using Terms.Member.Domain;
using Terms.Member.Service;
using Terms.Member.Utility;
using Terms.Member.Business;

public partial class AgentChangePassword : SalseBasePage
{
    private IMemberInformationService _MemberInformationService;
    public IMemberInformationService MemberInformationService
    {
        set
        {
            this._MemberInformationService = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Utility.IsLogin)
            {
                lblUserName.Text = Utility.Transaction.Member.EmailAddress;
            }
            else
            {
                this.Response.Redirect("Login.aspx");
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (Utility.IsLogin)
        {
            MemberInformation member = Utility.Transaction.Member;
            lb_OldPwdMsg.Visible = false;
            if (member.Password.Equals(MemberUtility.Lock(this.txbOldPwd.Value.Trim())))
            {
                member.Password = MemberUtility.Lock(this.txbNewPwd.Value.Trim());
                if (!txbOldPwd.Value.Equals(txbNewPwd.Value))
                {
                    _MemberInformationService.Update(member);
                    Utility.Transaction.Member = member;
                    Response.Redirect("Index.aspx");
                }
            }
            else
            {
                if (!this.txbOldPwd.Value.Trim().Equals(string.Empty))
                {
                    lb_OldPwdMsg.InnerHtml = "Please check your current password";
                }
                lb_OldPwdMsg.Visible = true;

            }
        }
    }
}
