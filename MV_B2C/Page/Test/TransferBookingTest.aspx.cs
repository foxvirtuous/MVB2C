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
using TERMS.Common.Search;
using TERMS.Business.Centers.ProductCenter.Search;
using TERMS.Business.Centers.ProductCenter.Components;
using System.Collections.Generic;


public partial class Page_Test_TransferBookingTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TransferSearchCondition SearchCondition = new TransferSearchCondition();

        SearchCondition.PreferredLanguage = "E";

        SearchCondition.PickupCityCode = "LON";
        SearchCondition.PickupCode = "A";
        SearchCondition.PickupPointCode = "LHR";

        SearchCondition.DropOffCityCode = "LON";
        SearchCondition.DropOffCode = "A";
        //SearchCondition.DropOffPointCode = "LHR";

        SearchCondition.TransferDate = new DateTime(2008, 11, 2);
        SearchCondition.AlternateLanguage = "E";

        TransferProductSearcher Searcher = new TransferProductSearcher();
        IList<TransferProduct> Products = Searcher.Search(SearchCondition);

        if (Products != null)
        {
            Terms.Contract.Business_0407.GTATransferMaterial obj = (Terms.Contract.Business_0407.GTATransferMaterial)((TERMS.Business.Centers.ProductCenter.Components.TransferMaterial)((TERMS.Core.Product.ComponentGroup)Products[0].Items[0]).Items[0]);

            //string str = obj.Transfer
        }   
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SightSeeingSearchCondition SearchCondition = new SightSeeingSearchCondition();

        SearchCondition.Adults = 1;
        SearchCondition.CategoryCode = "";

        List<int> ages = new List<int>();
        ages.Add(2);
        ages.Add(3);
        SearchCondition.ChildrenAges = ages.ToArray();

        SearchCondition.DestinationCode = "LON";
        SearchCondition.DestinationType = "city";
        SearchCondition.TourDate = DateTime.Now.AddMonths(1);
        List<string> TypeCodes = new List<string>();
        TypeCodes.Add("AR");
        TypeCodes.Add("CR");

        SearchCondition.TypeCodes = TypeCodes.ToArray();

        SightSeeingProductSearcher Searcher = new SightSeeingProductSearcher();
        IList<SightSeeingProduct> Products = Searcher.Search(SearchCondition);

        if (Products != null)
        {

        }
    }
}