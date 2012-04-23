using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.Text;
using TERMS.Business.Centers.SalesCenter;
using Terms.Sales.Business;

/// <summary>
/// Summary description for MVMerchandisePool
/// </summary>
public class MVMerchandisePool
{
    /// <summary>
    /// 
    /// </summary>
    //private IDictionary<SearchCondition, Merchandise> m_Merchandise = new Dictionary<SearchCondition, Merchandise>();

    private static IDictionary<SearchCondition, Merchandise> CachedMerchandises
    {
        get
        {
            if (HttpContext.Current == null) return null;

            if (HttpContext.Current.Session["CachedMerchandises"] == null)
                HttpContext.Current.Session["CachedMerchandises"] = new Dictionary<SearchCondition, Merchandise>();

            return (IDictionary<SearchCondition, Merchandise>)HttpContext.Current.Session["CachedMerchandises"];
        }
    }

    private static IDictionary<string, Merchandise> CachedTours
    {
        get
        {
            if (HttpContext.Current == null) return null;

            if (HttpContext.Current.Application["CachedTours"] == null)
                HttpContext.Current.Application["CachedTours"] = new Dictionary<string, Merchandise>();

            return (IDictionary<string, Merchandise>)HttpContext.Current.Application["CachedTours"];
        }
    }

    private static IDictionary<List<string>, Merchandise> CachedMoreTours
    {
        get
        {
            if (HttpContext.Current == null) return null;

            if (HttpContext.Current.Application["CachedMoreTours"] == null)
                HttpContext.Current.Application["CachedMoreTours"] = new Dictionary<List<string>, Merchandise>();

            return (IDictionary<List<string>, Merchandise>)HttpContext.Current.Application["CachedMoreTours"];
        }
    }

    private static IDictionary<SearchCondition, Merchandise> CachedSubTours
    {
        get
        {
            if (HttpContext.Current == null) return null;

            if (HttpContext.Current.Session["CachedSubTours"] == null)
                HttpContext.Current.Session["CachedSubTours"] = new Dictionary<SearchCondition, Merchandise>();

            return (IDictionary<SearchCondition, Merchandise>)HttpContext.Current.Session["CachedSubTours"];
        }
    }

    /// <summary>
    /// 根据Search Condition查找缓存的商品Search结果
    /// </summary>
    /// <param name="searchCondition">Search Condition</param>
    /// <returns>缓存的商品Search结果</returns>
    public static Merchandise Find(SearchCondition searchCondition)
    {
        Merchandise result = null;
        if (searchCondition != null)
        {
            foreach (SearchCondition key in CachedMerchandises.Keys)
            {
                if (key.Equals(searchCondition))
                {
                    result = CachedMerchandises[key];
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 根据Search Condition查找缓存的商品Search结果
    /// </summary>
    /// <param name="keys">Search</param>
    /// <returns>缓存的商品Search结果</returns>
    public static Merchandise Find(string keys)
    {
        Merchandise result = null;
        if (keys != null)
        {
            foreach (string key in CachedTours.Keys)
            {
                if (key.Equals(keys))
                {
                    result = CachedTours[key];
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 根据Citys查找缓存的商品Search结果
    /// </summary>
    /// <param name="keys">Search</param>
    /// <returns>缓存的商品Search结果</returns>
    public static Merchandise Find(List<string> keys)
    {
        #region Del
        //Merchandise result = null;
        //IDictionary<List<string>, Merchandise> listMoreTours = null;
        //foreach (string type in CachedMoreTours.Keys)
        //{
        //    if (type.Contains(tourType))
        //    { 
        //        listMoreTours = CachedMoreTours[type];
        //        break;
        //    }
        //}

        //if (keys != null)
        //{
        //    if (listMoreTours != null)
        //    {
        //        foreach (List<string> key in listMoreTours.Keys)
        //        {
        //            if (key.Count == keys.Count)
        //            {
        //                bool temp = true;
        //                for (int i = 0; i < key.Count; i++)
        //                {
        //                    if (!key[i].Equals(keys[i]))
        //                    {
        //                        temp = false;
        //                    }
        //                }
        //                if (temp)
        //                {
        //                    result = listMoreTours[key];
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //}

        //return result;
        #endregion
        Merchandise result = null;
        if (keys != null)
        {
            foreach (List<string> key in CachedMoreTours.Keys)
            {
                if (key.Count == keys.Count)
                {
                    bool temp = true;
                    for (int i = 0; i < key.Count; i++)
                    {
                        if (!key[i].Equals(keys[i]))
                        {
                            temp = false;
                        }
                    }
                    if (temp)
                    {
                        result = CachedMoreTours[key];
                        break;
                    }
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 根据Search Condition查找缓存的商品Search结果
    /// </summary>
    /// <param name="searchCondition">Search Condition</param>
    /// <returns>缓存的商品Search结果</returns>
    public static Merchandise FindB2BTour(SearchCondition searchCondition)
    {
        Merchandise result = null;
        if (searchCondition != null)
        {
            foreach (SearchCondition key in CachedSubTours.Keys)
            {
                if (key.Equals(searchCondition))
                {
                    result = CachedSubTours[key];
                    break;
                }
            }
        }

        return result;
    }

    /// <summary>
    /// 缓存商品Search结果
    /// </summary>
    /// <param name="searchCondition">Search Condition</param>
    /// <param name="componentGroup">缓存的商品Search结果</param>
    public static void Cache(SearchCondition searchCondition, Merchandise componentGroup)
    {
        if (Utility.IsSubAgent && searchCondition is TourSearchCondition)
            CachedSubTours[searchCondition] = componentGroup;
        else
            CachedMerchandises[searchCondition] = componentGroup;
    }

    /// <summary>
    /// 缓存商品Search结果
    /// </summary>
    /// <param name="searchCondition">Search Condition</param>
    /// <param name="componentGroup">缓存的商品Search结果</param>
    public static void Cache(string keys, Merchandise componentGroup)
    {
        CachedTours[keys] = componentGroup;
    }

    /// <summary>
    /// 缓存商品Search结果
    /// </summary>
    /// <param name="searchCondition">Search Condition</param>
    /// <param name="componentGroup">缓存的商品Search结果</param>
    public static void Cache(List<string> keys, Merchandise componentGroup)
    {
        CachedMoreTours[keys] = componentGroup;
    }

    /// <summary>
    /// 删除指定的商品Search结果
    /// </summary>
    /// <param name="searchCondition"></param>
    /// <returns></returns>
    public static bool Remove(SearchCondition searchCondition)
    {
        if (CachedMerchandises.Keys.Contains(searchCondition))
        {
            CachedMerchandises.Remove(searchCondition);

            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 删除指定的商品Search结果
    /// </summary>
    /// <param name="searchCondition"></param>
    /// <param name="componentGroup"></param>
    public static bool Remove(SearchCondition searchCondition, Merchandise componentGroup)
    {
        KeyValuePair<SearchCondition, Merchandise> item = new KeyValuePair<SearchCondition, Merchandise>(searchCondition, componentGroup);

        if (CachedMerchandises.Contains(item))
        {
            CachedMerchandises.Remove(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// 删除指定的商品Search结果
    /// </summary>
    /// <param name="item"></param>
    public static bool Remove(KeyValuePair<SearchCondition, Merchandise> item)
    {
        if (CachedMerchandises.Contains(item))
        {
            CachedMerchandises.Remove(item);
            return true;
        }
        else
        {
            return false;
        }
    }

    
    public static void ResetTour()
    {
        HttpContext.Current.Application["CachedMoreTours"] = null;
        HttpContext.Current.Application["CachedTours"] = null;
        HttpContext.Current.Application["CachedSubTours"] = null;
    }
}
