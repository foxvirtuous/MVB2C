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
using Terms.Sales.Service;
using Terms.Material.Service.GTA;
using System.Collections.Generic;

public partial class TransferDetailMain : SalseBasePage
{
    private SaleOrderService m_SaleOrderService;

    protected SaleOrderService SaleOrderService
    {
        set
        {
            m_SaleOrderService = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Request["city"] != null && this.Request["item"] != null)
            {
                TransferDetail transferDetail = m_SaleOrderService.SearchTransferDetail(this.Request["city"], this.Request["item"]);

                lblName.Text = transferDetail.Item.Name;
                lblTime.Text = transferDetail.ApproximateTransferTime;
                lblDescription.Text = transferDetail.Description;
                lblMeetingPoint.Text = transferDetail.MeetingPoint;

                string strConditions = string.Empty;
                for (int i = 0; i < transferDetail.TransferConditionList.Length; i++)
                {
                    strConditions += transferDetail.TransferConditionList[i] + "<BR>";
                }

                lblConditions.Text = strConditions;

                if (Server.UrlDecode(this.Request["Date"]) != null && this.Request["language"] != null && this.Request["car"] != null && this.Request["passengers"] != null)
                {
                    string strCityCode = this.Request["city"];
                    string strItemCode = this.Request["item"];
                    string strDate = Server.UrlDecode(this.Request["Date"]);
                    string strLanguageCode = this.Request["language"];
                    string strCarCode = this.Request["car"];
                    string strPassengers = this.Request["passengers"];

                    Terms.Material.Service.GTA.ChargeConditionsTransferResponse response = m_SaleOrderService.SearchTransferDetail(strCityCode, strItemCode, Convert.ToDateTime(strDate), strLanguageCode, strCarCode, Convert.ToInt32(strPassengers), ConfigurationManager.AppSettings.Get("OrderCurrency"));

                    if (response != null && response.ChargeConditionsTransfers.Length > 0)
                    {
                        List<ChargeConditionsTransfer> cancellation = new List<ChargeConditionsTransfer>();
                        List<ChargeConditionsTransfer> amendment = new List<ChargeConditionsTransfer>();

                        for (int i = 0; i < response.ChargeConditionsTransfers.Length; i++)
                        {
                            if (response.ChargeConditionsTransfers[i].Type.Trim().ToUpper() == "cancellation".Trim().ToUpper() && response.ChargeConditionsTransfers[i].IsCharge)
                            {
                                divCancellation.Visible = true;

                                cancellation.Add(response.ChargeConditionsTransfers[i]);
                            }
                            else
                            {
                                divAmendment.Visible = true;
                                amendment.Add(response.ChargeConditionsTransfers[i]);
                            }
                        }

                        CreatAmendments(amendment, Convert.ToDateTime(strDate));
                        CreatCancellation(cancellation, Convert.ToDateTime(strDate));
                    }
                }
            }
        }
    }

    private void CreatAmendments(List<ChargeConditionsTransfer> amendment, DateTime CheckInDate)
    {
        DataTable dtAmendment = new DataTable();
        DataColumn dcTimeString = new DataColumn("TimeString");
        DataColumn dcPolicy = new DataColumn("Policy");
        dtAmendment.Columns.Add(dcTimeString);
        dtAmendment.Columns.Add(dcPolicy);

        for (int i = 0; i < amendment.Count; i++)
        {
            if (amendment[i].ChargeAmount != null && amendment[i].IsCharge)
            {
                DataRow dr = dtAmendment.NewRow();

                dr[0] = "After " + CheckInDate.AddDays(-(amendment[i].ToDay)).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " And " + CheckInDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                dr[1] = amendment[i].ChargeAmount;

                dtAmendment.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtAmendment.NewRow();

                dr[0] = "Upto " + CheckInDate.AddDays(-(amendment[i].FromDay)).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                dr[1] = "No Charge";

                dtAmendment.Rows.Add(dr);
            }
        }

        gvAmendment.DataSource = dtAmendment;
        gvAmendment.DataBind();
    }


    private void CreatCancellation(List<ChargeConditionsTransfer> cancellation, DateTime CheckInDate)
    {
        DataTable dtCancellation = new DataTable();
        DataColumn dcTimeString = new DataColumn("TimeString");
        DataColumn dcPolicy = new DataColumn("Policy");
        dtCancellation.Columns.Add(dcTimeString);
        dtCancellation.Columns.Add(dcPolicy);

        DateTime ChargeDate = DateTime.Now;

        for (int i = 0; i < cancellation.Count; i++)
        {
            if (Convert.ToInt32(cancellation[0].ToDay) >= 7)
            {

                ChargeDate = CheckInDate.AddDays(-Convert.ToInt32(cancellation[0].ToDay));
            }
            else
            {
                ChargeDate = CheckInDate.AddDays(-Convert.ToInt32(ConfigurationManager.AppSettings.Get("OrderCancelSafeDay")));
            }

            if (cancellation[i].ChargeAmount != null && cancellation[i].IsCharge)
            {
                DataRow dr = dtCancellation.NewRow();

                dr[0] = "After " + ChargeDate.AddDays(-(cancellation[i].ToDay)).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " And " + CheckInDate.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                dr[1] = cancellation[i].ChargeAmount;

                dtCancellation.Rows.Add(dr);
            }
            else
            {
                DataRow dr = dtCancellation.NewRow();

                dr[0] = "Upto " + ChargeDate.AddDays(-(cancellation[i].FromDay)).ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                dr[1] = "No Charge";

                dtCancellation.Rows.Add(dr);
            }
        }

        gvCancellation.DataSource = dtCancellation;
        gvCancellation.DataBind();
    }
}
