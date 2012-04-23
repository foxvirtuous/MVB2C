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

public partial class SightseeingDetail : SalseBasePage
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
                SightSeeingDetail sightSeeingDetail = m_SaleOrderService.SearchSightSeeingDetail(this.Request["city"], this.Request["item"]);

                if (sightSeeingDetail != null)
                {
                    lblName.Text = sightSeeingDetail.Item.Name;

                    lblIncludes.Text = sightSeeingDetail.Includes;

                    lblCity.Text = sightSeeingDetail.City.Name;

                    lblMore.Text = sightSeeingDetail.TourSummary;

                    lblTime.Text = "Duration of tour: " + sightSeeingDetail.Duration;

                    lblTour.Text = sightSeeingDetail.TheTour;

                    lblNote.Text = sightSeeingDetail.PleaseNote;

                    lblInformation.Text = sightSeeingDetail.Information;
                    imgTour.ImageUrl = sightSeeingDetail.Image;
                    HyperLink1.NavigateUrl = sightSeeingDetail.FlashLink;

                    lblPoints.Text = sightSeeingDetail.DeparturePoints;

                    GridView1.DataSource = sightSeeingDetail.TourOperationList;
                    GridView1.DataBind();

                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (sightSeeingDetail.TourOperationList[i].TourLanguageList != null && sightSeeingDetail.TourOperationList[i].TourLanguageList.Length > 0)
                        {
                            GridView1.Rows[i].Cells[0].Text = sightSeeingDetail.TourOperationList[i].TourLanguageList[0].Name;
                        }
                        else
                        {
                            GridView1.Rows[i].Cells[0].Text = "Unescorted";
                        }

                        GridView1.Rows[i].Cells[1].Text = sightSeeingDetail.TourOperationList[i].Commentary;

                        GridView1.Rows[i].Cells[2].Text = sightSeeingDetail.TourOperationList[i].FromDate;

                        GridView1.Rows[i].Cells[3].Text = sightSeeingDetail.TourOperationList[i].ToDate;

                        GridView1.Rows[i].Cells[4].Text = sightSeeingDetail.TourOperationList[i].Frequency;

                        if (sightSeeingDetail.TourOperationList[0].DepartureList != null && sightSeeingDetail.TourOperationList[0].DepartureList.Length > 0)
                        {
                            if (sightSeeingDetail.TourOperationList[0].DepartureList[0].Time != null)
                            {
                                GridView1.Rows[i].Cells[5].Text = sightSeeingDetail.TourOperationList[i].DepartureList[0].Time;
                            }
                            else
                            {
                                GridView1.Rows[i].Cells[5].Text = sightSeeingDetail.TourOperationList[i].DepartureList[0].FirstService + " - " + sightSeeingDetail.TourOperationList[i].DepartureList[0].LastService; 
                            }
                        }
                        else
                        {
                            GridView1.Rows[i].Cells[5].Text = "-";
                        }

                        if (sightSeeingDetail.TourOperationList[0].DepartureList != null && sightSeeingDetail.TourOperationList[0].DepartureList.Length > 0)
                        {
                            if (sightSeeingDetail.TourOperationList[0].DepartureList[0].Time != null)
                            {
                                GridView1.Rows[i].Cells[6].Text = sightSeeingDetail.TourOperationList[i].DepartureList[0].DeparturePoint.Name;
                            }
                            else
                            {
                                GridView1.Rows[i].Cells[6].Text = "-";
                            }
                        }
                        else
                        {
                            GridView1.Rows[i].Cells[6].Text = "-";
                        }
                    }
                    //Language = sightSeeingDetail.TourOperationList[0].TourLanguageList[0].Name;
                    //Commentary = sightSeeingDetail.TourOperationList[0].Commentary;
                    //From Date = sightSeeingDetail.TourOperationList[0].FromDate;
                    //To Date = sightSeeingDetail.TourOperationList[0].ToDate;
                    //Days of week = sightSeeingDetail.TourOperationList[0].Frequency;
                    //Start Time = sightSeeingDetail.TourOperationList[0].DepartureList[0].Time;
                    //Departure Point = sightSeeingDetail.TourOperationList[0].DepartureList[0].DeparturePoint.Name;
                }
            }
        }
    }
}
