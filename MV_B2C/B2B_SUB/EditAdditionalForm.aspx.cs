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

using log4net;
using Spring.Web.UI;
using Terms.Additional.Service;
using Terms.Additional.Domain;

public partial class EditAdditionalForm : Spring.Web.UI.Page
{
    private IEditFlyerService m_EditFlyerService;

    public IEditFlyerService EditFlyerService
    {
        set { m_EditFlyerService = value; }
        get { return m_EditFlyerService; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            divAddNew.Visible = false;

            BindMarket();
            BindProduct();
            BindFlyer(dllMarketList.SelectedValue, dllProductTypeList.SelectedValue);
        }
    }
    protected void btnAddNew_Click(object sender, EventArgs e)
    {
        btnAddNew.Visible = false;
        btnSave.Visible = true;
        divAddNew.Visible = true;

        this.dllMarket.Visible = true;
        txtNewRegion.Visible = false;

        this.dllProductType.Visible = true;
        txtNewType.Visible = false;
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (divAddNew.Visible)
        {
            if (string.IsNullOrEmpty(txtFlyerName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('FlyerName is null ');</script>");
                return;
            }

            if (string.IsNullOrEmpty(txtFrom.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Validity From is null ');</script>");
                return;
            }

            if (string.IsNullOrEmpty(txtTo.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Validity To is null ');</script>");
                return;
            }

            try
            {
                DateTime tempFrom = Convert.ToDateTime(txtFrom.Text);
                DateTime tempTo = Convert.ToDateTime(txtTo.Text);

                if (tempFrom > tempTo)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Validity From is greater than Validity To ');</script>");
                    return;
                }
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('Date is Error ');</script>");
                return;
            }

            if (string.IsNullOrEmpty(txtImgUrl.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('FlyerImgurl is null ');</script>");
                return;
            }

            if (string.IsNullOrEmpty(txtAirline.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('FlyerAirline is null ');</script>");
                return;
            }

            if (string.IsNullOrEmpty(txtAirClass.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('FlyerAirClass is null ');</script>");
                return;
            }


            if (string.IsNullOrEmpty(FileUpload1.FileName))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Warting", "<script language=javascript>alert('FlyerURL is null ');</script>");
                return;
            }

            Boolean fileOK = false;
            String path = Server.MapPath("~/B2B_SUB/PDF/");
            if (FileUpload1.HasFile)
            {
                String fileExtension =
                    System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                String[] allowedExtensions = 
                { ".pdf"};
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    FileUpload1.PostedFile.SaveAs(path
                        + FileUpload1.FileName);
                    string strTemp = "File uploaded!";
                }
                catch (Exception ex)
                {
                    string strTemp = "File could not be uploaded.";
                }
            }
            else
            {
                string strTemp = "Cannot accept files of this type.";
            }

            FlyerMeta flyerMeta = new FlyerMeta();

            flyerMeta.Flyerid = Guid.NewGuid();
            flyerMeta.FlyerName = txtFlyerName.Text;
            if (dllProductType.Visible)
            {
                flyerMeta.FlyerType = dllProductType.SelectedValue;
            }
            else
            {
                flyerMeta.FlyerType = txtNewType.Text;
            }

            if (dllMarket.Visible)
            {
                flyerMeta.FlyerRegion = dllMarket.SelectedValue;
            }
            else
            {
                flyerMeta.FlyerRegion = txtNewRegion.Text;
            }
            flyerMeta.FlyerFromDate = Convert.ToDateTime(txtFrom.Text);
            flyerMeta.FlyerToDate = Convert.ToDateTime(txtTo.Text);
            flyerMeta.FlyerImgurl = txtImgUrl.Text;
            flyerMeta.FlyerAirline = txtAirline.Text;
            flyerMeta.FlyerAirClass = txtAirClass.Text;
            flyerMeta.Flyerurl = FileUpload1.FileName;

            m_EditFlyerService.SaveFlyer(flyerMeta);

            btnAddNew.Visible = true;
            btnSave.Visible = false;
            divAddNew.Visible = false;

            BindMarket();
            BindProduct();
            BindFlyer(dllMarketList.SelectedValue, dllProductTypeList.SelectedValue);
        }
    }

    private void BindMarket()
    {
        dllMarketList.DataSource = m_EditFlyerService.GetFlyerRegion();
        dllMarketList.DataBind();

        ListItem item = new ListItem();
        item.Text = " -- Select --";
        item.Value = "";
        dllMarketList.Items.Insert(0, item);

        dllMarket.DataSource = m_EditFlyerService.GetFlyerRegion();
        dllMarket.DataBind();
    }

    private void BindProduct()
    {
        dllProductTypeList.DataSource = m_EditFlyerService.GetFlyerType();
        dllProductTypeList.DataBind();

        ListItem item = new ListItem();
        item.Text = " -- Select --";
        item.Value = "";
        dllProductTypeList.Items.Insert(0, item);

        dllProductType.DataSource = m_EditFlyerService.GetFlyerType();
        dllProductType.DataBind();
    }


    private void BindFlyer(string strMarket, string strType)
    {
        gridFlyer.DataSource = m_EditFlyerService.GetFlyer(strMarket, strType);
        gridFlyer.DataBind();
    }
    protected void gridFlyer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void gridFlyer_RowDeleted(object sender, GridViewDeletedEventArgs e)
    {

    }
    protected void gridFlyer_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string strId = gridFlyer.DataKeys[e.RowIndex].Value.ToString();

        m_EditFlyerService.DeleteFlyer(strId);

        BindFlyer(dllMarketList.SelectedValue, dllProductTypeList.SelectedValue);
    }
    protected void btnAddMarket_Click(object sender, EventArgs e)
    {
        this.dllMarket.Visible = false;
        txtNewRegion.Visible = true;
    }
    protected void btnAddProductType_Click(object sender, EventArgs e)
    {
        this.dllProductType.Visible = false;
        txtNewType.Visible = true;
    }
    protected void dllMarketList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindFlyer(dllMarketList.SelectedValue, dllProductTypeList.SelectedValue);
    }
    protected void dllProductTypeList_SelectedIndexChanged(object sender, EventArgs e)
    {
        //BindFlyer(dllMarketList.SelectedValue, dllProductTypeList.SelectedValue);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindFlyer(dllMarketList.SelectedValue, dllProductTypeList.SelectedValue);
    }
}
