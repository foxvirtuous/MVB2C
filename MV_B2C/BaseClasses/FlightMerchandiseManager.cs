using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TERMS.Business.Centers.SalesCenter;
using Terms.Configuration.Service;
using Spring.Context.Support;
using Terms.Configuration.Domain;
using TERMS.Business.Centers.ProductCenter.Components;
using Terms.Configuration.Utility;

/// <summary>
/// Summary description for FlightMerchandiseManager
/// </summary>
public class FlightMerchandiseManager
{
    public FlightMerchandiseManager()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private IWebSiteService WebSiteService
    {
        get
        {
            return ContextRegistry.GetContext()["WebSiteService"] as IWebSiteService;
        }
    }

    private AirMerchandise EditMerchandiseMarkup(AirMerchandise flightMerchandise,string groupCode)
    {
        //string groupCode = "test1118";
        AirMerchandise currentMerchandise;
        AirMaterial currentAirMaterial;

        currentMerchandise = null;

        //
        GroupMarkup groupMarkup = WebSiteService.GetGroupMarkup(groupCode);
        if (groupMarkup == null || groupMarkup.GroupCode != groupCode)
        {
            return flightMerchandise;
        }

        //遍历Merchandise
        for (int merchandiseIndex = 0; merchandiseIndex < flightMerchandise.Items.Count; merchandiseIndex++)
        {
            currentMerchandise = (AirMerchandise)flightMerchandise.Items[merchandiseIndex];

            currentMerchandise = EditGroupMarkup(currentMerchandise, groupMarkup);

            //遍历当前Merchandise的AirMaterial
            if (currentMerchandise.Items != null)
            {
                for (int materialIndex = 0; materialIndex < currentMerchandise.Items.Count; materialIndex++)
                {
                    currentAirMaterial = (AirMaterial)currentMerchandise.Items[materialIndex];

                    currentAirMaterial = EditGroupMarkup(currentAirMaterial, groupMarkup);

                }
            }


        }

        return flightMerchandise;
        
    }

    public AirMerchandise EditMerchandiseGroupMarkup(AirMerchandise flightMerchandise)
    {
        string groupCode = GlobalBaseUtility.GetGroupCode();

        if (groupCode == null)
        {
            return flightMerchandise;
        }

        flightMerchandise = EditMerchandiseMarkup(flightMerchandise, groupCode);

        return flightMerchandise;

    }

    private AirMaterial EditMaterialGroupMarkupWhenComm(AirMaterial flightMaterial)
    {
        string groupCode = GlobalBaseUtility.GetGroupCode();

        if (groupCode == null)
        {
            return flightMaterial;
        }

        //
        GroupMarkup groupMarkup = WebSiteService.GetGroupMarkup(groupCode);
        if (groupMarkup == null || groupMarkup.GroupCode != groupCode)
        {
            return flightMaterial;
        }

        flightMaterial = EditGroupMarkupWhenComm(flightMaterial, groupMarkup);

        return flightMaterial;
    }

    public AirMaterial EditMaterialGroupMarkup(AirMaterial flightMaterial)
    {
        string groupCode = GlobalBaseUtility.GetGroupCode();

        if (groupCode == null)
        {
            return flightMaterial;
        }

        //
        GroupMarkup groupMarkup = WebSiteService.GetGroupMarkup(groupCode);
        if (groupMarkup == null || groupMarkup.GroupCode != groupCode)
        {
            return flightMaterial;
        }

        if (flightMaterial.Profile.GetParam("FARE_TYPE").ToString() == "COMM")
        {
            //airMaterial = EditGroupMarkupAfterSelect(airMaterial, groupMarkup);
            flightMaterial = EditMaterialGroupMarkupWhenComm(flightMaterial);
        }
        else
        {
            flightMaterial = EditGroupMarkup(flightMaterial, groupMarkup);
        }

        return flightMaterial;
    }

    private AirMerchandise EditGroupMarkup(AirMerchandise currentAirMerchandise, GroupMarkup groupMarkup)
    {
        //AdultMarkup
        //金额类型
        if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
        {
            currentAirMerchandise.SetAdultBaseFare(currentAirMerchandise.AdultBaseFare + groupMarkup.AdultMarkup.Markup);
        }

            //百分比
        else if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
        {
            currentAirMerchandise.SetAdultBaseFare(currentAirMerchandise.AdultBaseFare * (1 + groupMarkup.AdultMarkup.Markup));
        }

        //ChildMarkup
        //金额类型
        if (((int)decimal.Parse(currentAirMerchandise.ChildBaseFare.ToString())) != 0)
        {
            if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
            {
                currentAirMerchandise.SetChildBaseFare(currentAirMerchandise.ChildBaseFare + groupMarkup.ChildMarkup.Markup);
            }

                //百分比
            else if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
            {
                currentAirMerchandise.SetChildBaseFare(currentAirMerchandise.ChildBaseFare * (1 + groupMarkup.ChildMarkup.Markup));
            }
        }

        return currentAirMerchandise;


    }

    private const string FLAG_REFERENCE_MARKUP_EDITED = "FLAG_REFERENCE_MARKUP_EDITED";

    private AirMaterial EditGroupMarkup(AirMaterial currentAirMaterial, GroupMarkup groupMarkup)
    {
        //如果已经加过，返回。
        if (currentAirMaterial.Profile.GetParam(FLAG_REFERENCE_MARKUP_EDITED) != null && (bool)currentAirMaterial.Profile.GetParam(FLAG_REFERENCE_MARKUP_EDITED))
        {
            return currentAirMaterial;
        }

        //设置Markup已经加过
        currentAirMaterial.Profile.SetParam(FLAG_REFERENCE_MARKUP_EDITED,true);

        TERMS.Common.Markup newMarkup = new TERMS.Common.Markup();
        //AdultMarkup
        //金额类型
        if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
        {
            newMarkup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(groupMarkup.AdultMarkup.Markup));
           
        }

            //百分比
        else if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
        {
            newMarkup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(currentAirMaterial.AdultBaseFare * (groupMarkup.AdultMarkup.Markup)));
           
        }

        //ChildMarkup
        //金额类型
        if (((int)decimal.Parse(currentAirMaterial.ChildBaseFare.ToString())) != 0)
        {
            if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
            {
                newMarkup.SetAmount(TERMS.Common.PassengerType.Child,new TERMS.Common.FareAmount(groupMarkup.ChildMarkup.Markup));
               
            }

                //百分比
            else if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
            {
                newMarkup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(currentAirMaterial.ChildBaseFare * (groupMarkup.ChildMarkup.Markup)));
                
               
            }
        }
        currentAirMaterial.Price.AddMarkup(newMarkup);
        return currentAirMaterial;

        
    }

    private AirMaterial EditGroupMarkupWhenComm(AirMaterial currentAirMaterial, GroupMarkup groupMarkup)
    {

        //如果已经加过，返回。
        if (currentAirMaterial.Profile.GetParam(FLAG_REFERENCE_MARKUP_EDITED) != null && (bool)currentAirMaterial.Profile.GetParam(FLAG_REFERENCE_MARKUP_EDITED))
        {
            return currentAirMaterial;
        }

        //设置Markup已经加过
        currentAirMaterial.Profile.SetParam(FLAG_REFERENCE_MARKUP_EDITED, true);

        decimal adultBasePrice = 0.0m; //大人不含税单价
        decimal childBasePrice = 0.0m; //小孩不含税单价
        adultBasePrice = currentAirMaterial.Profile.GetParam("PUBLISHED_ADULT_FARE") == null ? adultBasePrice : Convert.ToDecimal(currentAirMaterial.Profile.GetParam("PUBLISHED_ADULT_FARE"));
        childBasePrice = currentAirMaterial.Profile.GetParam("PUBLISHED_CHILD_FARE") == null ? childBasePrice : Convert.ToDecimal(currentAirMaterial.Profile.GetParam("PUBLISHED_CHILD_FARE"));
        int commision = currentAirMaterial.Profile.GetParam("COMMISION") == null ? 0 : Convert.ToInt32(currentAirMaterial.Profile.GetParam("COMMISION"));

        if (Convert.ToBoolean(currentAirMaterial.Profile.GetParam("ISWEBFARE")))
        {
            //if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
            //{
            //    currentAirMaterial.Profile.SetParam("PUBLISHED_ADULT_FARE", adultBasePrice + groupMarkup.AdultMarkup.Markup);
            //}

            //    //百分比
            //else if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
            //{
            //    currentAirMaterial.Profile.SetParam("PUBLISHED_ADULT_FARE", adultBasePrice * (1 + groupMarkup.AdultMarkup.Markup));
            //}

            ////ChildMarkup
            ////金额类型
            //if (((int)decimal.Parse(currentAirMaterial.ChildBaseFare.ToString())) != 0)
            //{
            //    if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
            //    {
            //        currentAirMaterial.Profile.SetParam("PUBLISHED_CHILD_FARE", childBasePrice + groupMarkup.ChildMarkup.Markup);
            //    }

            //        //百分比
            //    else if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
            //    {
            //        currentAirMaterial.Profile.SetParam("PUBLISHED_CHILD_FARE", childBasePrice * (1 + groupMarkup.ChildMarkup.Markup));
            //    }
            //}

        }
        else
        {

            ////AdultMarkup
            ////金额类型
            //if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
            //{

            //    currentAirMaterial.SetAdultMarkup(currentAirMaterial.AdultMarkup + groupMarkup.AdultMarkup.Markup);
            //}

            //    //百分比
            //else if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
            //{
            //    currentAirMaterial.Profile.SetParam("COMMISION", commision + 100 * groupMarkup.AdultMarkup.Markup);
            //}

            ////ChildMarkup
            ////金额类型
            //if (((int)decimal.Parse(currentAirMaterial.ChildBaseFare.ToString())) != 0)
            //{
            //    if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
            //    {
            //        currentAirMaterial.SetChildMarkup(currentAirMaterial.ChildMarkup + groupMarkup.ChildMarkup.Markup);
            //    }

            //        //百分比
            //    else if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
            //    {
            //        currentAirMaterial.Profile.SetParam("COMMISION", commision + 100 * groupMarkup.AdultMarkup.Markup);
            //    }
            //}

            //AdultMarkup
            //金额类型
            TERMS.Common.Markup newMarkup = new TERMS.Common.Markup();
            if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
            {
                newMarkup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(groupMarkup.AdultMarkup.Markup));
              
            }

                //百分比
            else if (groupMarkup.AdultMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
            {
                newMarkup = new TERMS.Common.Markup(TERMS.Common.PassengerType.Adult, new TERMS.Common.FareAmount(currentAirMaterial.AdultBaseFare * (groupMarkup.AdultMarkup.Markup)));
                
                
            }

            //ChildMarkup
            //金额类型
            if (((int)decimal.Parse(currentAirMaterial.ChildBaseFare.ToString())) != 0)
            {
                if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Money)
                {
                    newMarkup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(groupMarkup.ChildMarkup.Markup));
                    
                }

                    //百分比
                else if (groupMarkup.ChildMarkup.MarkupType == ConfigurationConst.GroupMarkType.Percent)
                {
                    newMarkup.SetAmount(TERMS.Common.PassengerType.Child, new TERMS.Common.FareAmount(currentAirMaterial.ChildBaseFare * (groupMarkup.ChildMarkup.Markup)));
                   
                }
            }
            currentAirMaterial.Price.AddMarkup(newMarkup);
        }

        return currentAirMaterial;


    }


}
