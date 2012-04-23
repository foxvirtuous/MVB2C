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
using TERMS.Business.Centers.ProductCenter.Profiles;
using TERMS.Business.Centers.SalesCenter;
using TERMS.Business.Centers.ProductCenter.Components;

public partial class EmailTourPDF : SalseBasePage
{
    public TourMerchandise tourMerchandise
    {
        get
        {
            return (TourMerchandise)this.OnSearch();
        }
    }

    public string SelectTourCode
    {
        get
        {
            if (Request["TourCode"] != null)
                return Request["TourCode"].Trim().ToLower();
            else
                return string.Empty;
        }
    }

    private TourMaterial _tourmaterial = null;
    public TourMaterial SelectTourMaterial
    {
        get
        {
            if (_tourmaterial == null || ((TourProfile)_tourmaterial.Profile).Code.Trim().ToLower() != SelectTourCode)
            {
                if (tourMerchandise != null && tourMerchandise.Items != null && tourMerchandise.Items.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.Items.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.Items[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            _tourmaterial = (TourMaterial)tourMerchandise.Items[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return _tourmaterial;
        }
    }

    private TourProduct tourproduct = null;
    public TourProduct TourProduct
    {
        get
        {
            if (tourproduct == null || ((TourProfile)tourproduct.Profile).Code.Trim().ToLower() != SelectTourCode)
            {

                if (tourMerchandise != null && tourMerchandise.TourProductList != null && tourMerchandise.TourProductList.Count > 0)
                {
                    for (int i = 0; i < tourMerchandise.TourProductList.Count; i++)
                    {
                        if (((TourProfile)tourMerchandise.TourProductList[i].Profile).Code.Trim().ToLower() == SelectTourCode)
                        {
                            tourproduct = (TourProduct)tourMerchandise.TourProductList[i];
                            break;
                        }
                    }
                }
                else
                    return null;
            }

            return tourproduct;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TourProfile tourProfile = (TourProfile)SelectTourMaterial.Profile;

            hlAttachment.Text = this.Request["Code"] + ".PDF";

            hlAttachment.NavigateUrl = ((Terms.Product.Business.MVTourProfile)tourProfile).JourneyPDF;
        }
    }

    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        if (this.Request["Code"] != null && txtEmail.Text.Length > 0)
        {
            string Code = this.Request["Code"];

            string Name = this.Request["Name"];

            string Email = txtEmail.Text.Replace(@";", @",");

            string filepath = @"D://Website//terms//Images_Attachment//Product//TourProduct//" + Code;

            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();

                System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(filepath);

                message.To.Add(Email);
                message.From = new System.Net.Mail.MailAddress("sales@majestic-vacations.com");
                message.Subject = "Majestic Vacations China Tour";
                message.IsBodyHtml = true;
                message.Attachments.Add(attachment);
                message.SubjectEncoding = System.Text.Encoding.UTF8;
                message.Body = txtBody.Text;
                Terms.Member.Utility.MemberUtility.SendEmail(message);
            }
            catch (Exception ex)
            {
                txtEmail.Text = ex.Message;
            }

            Response.Write("<script>window.opener=null;window.close();</script>");// 
        }
    }
}

