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
using TERMS.Core.Product;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Business.Centers.ProductCenter.Profiles;
using TERMS.Common;
using System.Globalization;
using System.Threading;
using Resources;

/// <summary>
/// Summary description for AirLineMatricsManager
/// </summary>
public class AirLineMatricsManager
{
    public enum SortByFlag
    {
        Airline,
        Price,
        DepartureDate,
        ArrivalDate,
        Duration
    }

    protected AirMatrixFlightsByStop AirMatrixFlightsByStop
    {
        get
        {
            return (AirMatrixFlightsByStop)HttpContext.Current.Session["AirMatrixFlightsByStop"];
        }
        set
        {
            HttpContext.Current.Session.Add("AirMatrixFlightsByStop", value);
        }
    }

    private FlightInfoHider flightInfohider;

    public AirLineMatricsManager()
    {
        flightInfohider = new FlightInfoHider();
        m_sortFlag = SortFlag.Asc;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
    }

    public List<Component> GetFlightListByStop(MatrixStopType matrixStopType)
    {
        return AirMatrixFlightsByStop.GetFlightList(matrixStopType);
    }

    public List<AirMatrixFlightMeta> EditFlightsToAirMatrixStyle(List<Component> availableFlightList, List<Component> selectFlightList)
    {
        List<AirMatrixFlightMeta> matrixList;

        AirMatrixFlightsByStop = new AirMatrixFlightsByStop();

        //把Availalble Flight编辑成AirMatrix形式
        matrixList = EditFlightsToAirMatrixStyle(availableFlightList);

        //按最低价格排序
        matrixList = GetSortedByPriceMatrixList(matrixList);

        //把SelectLowFare加到里面来
        matrixList = AddSelectLowFareToList(matrixList, selectFlightList);

        //按最低价格排序
        matrixList = GetSortedByPriceMatrixList(matrixList);

        //取前8条
        matrixList = GetFilteredMatrixList(matrixList);

        return matrixList;
    }

    private const int MAX_MATRIX_COUNT = int.MaxValue;
    private int MAX_MATRIX_COUNT_SHORT
    {
        get
        {
            if (ConfigurationSettings.AppSettings.Get("MAX_MATRIX_COUNT_SHORT") != null)
            {
                return int.Parse(ConfigurationSettings.AppSettings.Get("MAX_MATRIX_COUNT_SHORT"));
            }
            else
            {
                return 8;
            }
        }
    }

    private List<AirMatrixFlightMeta> GetFilteredMatrixList(List<AirMatrixFlightMeta> matrixList)
    {
        if(matrixList.Count > MAX_MATRIX_COUNT)
        {
            matrixList.RemoveRange(MAX_MATRIX_COUNT, matrixList.Count - MAX_MATRIX_COUNT);
        }

        return matrixList;
    }

    public List<AirMatrixFlightMeta> GetShortedMatrixList(List<AirMatrixFlightMeta> matrixList)
    {
        if (matrixList == null)
        {
            return null;
        }

        List<AirMatrixFlightMeta> shortedMatrixList = null;
        shortedMatrixList = CopyList(matrixList);

        if (shortedMatrixList.Count > MAX_MATRIX_COUNT_SHORT)
        {
            shortedMatrixList.RemoveRange(MAX_MATRIX_COUNT_SHORT - 2, shortedMatrixList.Count - MAX_MATRIX_COUNT_SHORT);
        }

        return shortedMatrixList;
    }

    private const int MAX_SelectFlightCount = 2;

    private List<AirMatrixFlightMeta> AddSelectLowFareToList(List<AirMatrixFlightMeta> matrixList, List<Component> flightList)
    {
        AirMatrixFlightMeta currentMatrix;
        AirMaterial currentFlight;
        int selectFlightCount = 0;

        //按最低价格排序
        matrixList = GetSortedByPriceMatrixList(matrixList);

        if (matrixList.Count > MAX_MATRIX_COUNT)
        {
            matrixList.RemoveRange(MAX_MATRIX_COUNT, matrixList.Count - MAX_MATRIX_COUNT);
        }

        for (int flightIndex = 0; flightIndex < flightList.Count; flightIndex++)
        {
            currentFlight = (AirMaterial)flightList[flightIndex];
            currentMatrix = new AirMatrixFlightMeta();

            if (IsAirLineExist(currentFlight, matrixList,ref currentMatrix))
            {
                SetLowerFarePrice(currentFlight, currentMatrix);
            }
            else
            {
                SetAirLine(currentFlight, currentMatrix);
                SetLowerFarePrice(currentFlight,currentMatrix);
                if (matrixList.Count >= MAX_MATRIX_COUNT)
                {
                    matrixList.RemoveAt(MAX_MATRIX_COUNT - 1 - selectFlightCount);
                }
                matrixList.Add(currentMatrix);

                selectFlightCount++;

                if (selectFlightCount == MAX_SelectFlightCount)
                {
                    break;
                }
            }
        }

        //按最低价格排序
        matrixList = GetSortedByPriceMatrixList(matrixList);

        matrixList = GetFilteredMatrixList(matrixList);

        return matrixList;
    }

    private bool IsAirLineExist(AirMaterial currentFlight, List<AirMatrixFlightMeta> matrixList,ref AirMatrixFlightMeta currentMatrix)
    {
        string currentAirLineCode = string.Empty;

        if (flightInfohider.IsNeedToHide(currentFlight))
        {
            currentAirLineCode = flightInfohider.ReplaceFlightCode(currentFlight);
        }
        else
        {
            currentAirLineCode = ((AirProfile)(currentFlight.Profile)).Airlines[0].Code;
        }

        for (int matrixIndex = 0; matrixIndex < matrixList.Count; matrixIndex++)
        {
            if (matrixList[matrixIndex].AirLine.Code == currentAirLineCode)
            {
                currentMatrix = matrixList[matrixIndex];
                return true;
            }
        }

        return false;
    }

    private void SetLowerFarePrice(AirMaterial currentFlight, AirMatrixFlightMeta currentMatrix)
    {
        
        if (currentMatrix.LowFareSelectPrice.BaseFare == 0 || (currentFlight.AdultBaseFare + currentFlight.AdultMarkup) < currentMatrix.LowFareSelectPrice.BaseFare)
        {
            SetPriceDetail(currentMatrix.LowFareSelectPrice, currentFlight);
        }
    }

    public List<AirMatrixFlightMeta> EditFlightsToAirMatrixStyle(List<Component> flightList)
    {
        AirMaterial currentFlight = null;
        AirMatrixFlightMeta currentMatrix = null;
        string currentAirLineCode = string.Empty;
        string preAirLineCode = string.Empty;
        List<Component> sortedByAirLineFlightList = null;
        List<AirMatrixFlightMeta> matrixList = new List<AirMatrixFlightMeta>();

        //对flightList按AirLine排序。
        sortedByAirLineFlightList = GetSortedByAirLineFlightList(flightList);
        //flightList.Sort(  
        //currentFlight.co

        for (int flightIndex = 0; flightIndex < sortedByAirLineFlightList.Count; flightIndex++)
        {
            currentFlight = (AirMaterial)sortedByAirLineFlightList[flightIndex];
            if (IsFirstFligt(flightIndex))
            {
                currentMatrix = new AirMatrixFlightMeta();

                SetAirLine(currentFlight, currentMatrix);
                SetFirstPrice(currentFlight, currentMatrix);

            }

            else
            {
                if (flightInfohider.IsNeedToHide(currentFlight))
                {
                    currentAirLineCode = flightInfohider.ReplaceFlightCode(currentFlight);
                }
                else
                {
                    currentAirLineCode = ((AirProfile)(currentFlight.Profile)).Airlines[0].Code;
                }
                preAirLineCode = currentMatrix.AirLine.Code;

                if (IsAirLineChanged(currentAirLineCode, preAirLineCode))
                {
                    matrixList.Add(currentMatrix);

                    currentMatrix = new AirMatrixFlightMeta();

                    SetAirLine(currentFlight, currentMatrix);
                    SetFirstPrice(currentFlight, currentMatrix);
                }

                else
                {
                    SetLowerPrice(currentFlight, currentMatrix);
                }

                
            }

            if (flightIndex == flightList.Count - 1)
            {
                matrixList.Add(currentMatrix);
            }
            
        }

        return matrixList;
    }

    private List<AirMatrixFlightMeta> GetSortedByPriceMatrixList(List<AirMatrixFlightMeta> matrixList)
    {
        List<AirMatrixFlightMeta> sortedByPriceMatrixList = null;

        sortedByPriceMatrixList = CopyList(matrixList);
        Comparison<AirMatrixFlightMeta> sortedByPriceComparison = new Comparison<AirMatrixFlightMeta>(CompareMatrixPrice);

        sortedByPriceMatrixList.Sort(sortedByPriceComparison);

        return sortedByPriceMatrixList;
    }

    private int CompareMatrixPrice(AirMatrixFlightMeta matrixFrom, AirMatrixFlightMeta matrixTo)
    {
        int compareResult = 0;

        //if (matrixFrom.ZeroStopPrice.TotalPrice != matrixTo.ZeroStopPrice.TotalPrice && matrixFrom.ZeroStopPrice.TotalPrice != 0)
        //{
        //    compareResult = matrixFrom.ZeroStopPrice.TotalPrice.CompareTo(matrixTo.ZeroStopPrice.TotalPrice);
        //}
        //else if (matrixFrom.ZeroStopPrice.BaseFare != matrixTo.ZeroStopPrice.BaseFare)
        //{
        //    compareResult = matrixFrom.ZeroStopPrice.BaseFare.CompareTo(matrixTo.ZeroStopPrice.BaseFare);
        //}
        //else
        //{
        //    if (matrixFrom.OneStopPrice.TotalPrice != matrixTo.OneStopPrice.TotalPrice && matrixFrom.OneStopPrice.TotalPrice != 0)
        //    {
        //        compareResult = matrixFrom.OneStopPrice.TotalPrice.CompareTo(matrixTo.OneStopPrice.TotalPrice);
        //    }
        //    else if (matrixFrom.OneStopPrice.BaseFare != matrixTo.OneStopPrice.BaseFare)
        //    {
        //        compareResult = matrixFrom.OneStopPrice.BaseFare.CompareTo(matrixTo.OneStopPrice.BaseFare);
        //    }
        //    else
        //    {
        //        if (matrixFrom.MoreThanTwoStopPrice.TotalPrice != matrixTo.MoreThanTwoStopPrice.TotalPrice && matrixFrom.MoreThanTwoStopPrice.TotalPrice != 0)
        //        {
        //            compareResult = matrixFrom.MoreThanTwoStopPrice.TotalPrice.CompareTo(matrixTo.MoreThanTwoStopPrice.TotalPrice);
        //        }
        //        else if (matrixFrom.OneStopPrice.BaseFare != matrixTo.OneStopPrice.BaseFare)
        //        {
        //            compareResult = matrixFrom.MoreThanTwoStopPrice.BaseFare.CompareTo(matrixTo.MoreThanTwoStopPrice.BaseFare);
        //        }
        //        else
        //        {

        //        }
        //    }
        //}

        compareResult = matrixFrom.LowestPrice.ComparedPrice.CompareTo(matrixTo.LowestPrice.ComparedPrice);

        if (compareResult == 0)
        {
            compareResult = matrixFrom.LowFareSelectPrice.ComparedPrice.CompareTo(matrixTo.LowFareSelectPrice.ComparedPrice);
        }

        return compareResult;
    }

    private List<Component> GetSortedByAirLineFlightList(List<Component> flightList)
    {
        List<Component> sortedByAirLineFlightList = null;

        sortedByAirLineFlightList = CopyList(flightList);
        Comparison<Component> sortedByAirLineComparer = new Comparison<Component>(CompareAirLineSort);

        sortedByAirLineFlightList.Sort(sortedByAirLineComparer);

        return sortedByAirLineFlightList;
    }

    private List<Component> CopyList(List<Component> list)
    {
        List<Component> copedList = new List<Component>();

        for (int index = 0; index < list.Count; index++)
        {
            copedList.Add(list[index]);
        }

        return copedList;
    }

    private List<AirMatrixFlightMeta> CopyList(List<AirMatrixFlightMeta> list)
    {
        List<AirMatrixFlightMeta> copedList = new List<AirMatrixFlightMeta>();

        for (int index = 0; index < list.Count; index++)
        {
            copedList.Add(list[index]);
        }

        return copedList;
    }

    public int CompareAirLine(Component flightFrom, Component flightTo)
    {
        int compareResult = 0;  

        if (flightInfohider.IsNeedToHide(flightFrom) && flightInfohider.IsNeedToHide(flightTo))
        {
            compareResult = flightInfohider.ReplaceFlightCode(flightFrom).CompareTo(flightInfohider.ReplaceFlightCode(flightTo));

            if (compareResult != 0)
            {
                return compareResult;
            }
            else
            {
                return CompareFlightPrice(flightFrom, flightTo);
            }
        }

        if (flightInfohider.IsNeedToHide(flightFrom))
        {
            return 1;
        }

        if (flightInfohider.IsNeedToHide(flightTo))
        {
            return -1;
        }

        compareResult = ((AirProfile)((AirMaterial)flightFrom).Profile).Airlines[0].Code.CompareTo(((AirProfile)((AirMaterial)flightTo).Profile).Airlines[0].Code);

        if (compareResult != 0)
        {
            return compareResult;
        }
        else
        {
            return CompareFlightPrice(flightFrom, flightTo);
        }
        
    }

    private int CompareAirLineSort(Component flightFrom, Component flightTo)
    {
        int compareResult = 0;

        if (flightInfohider.IsNeedToHide(flightFrom) && flightInfohider.IsNeedToHide(flightTo))
        {
            compareResult = flightInfohider.ReplaceFlightCode(flightFrom).CompareTo(flightInfohider.ReplaceFlightCode(flightTo));

            if (compareResult != 0)
            {
                return compareResult;
            }
            else
            {
                return CompareFlightPrice(flightFrom, flightTo);
            }
        }

        if (flightInfohider.IsNeedToHide(flightFrom))
        {
            return -1;
        }

        if (flightInfohider.IsNeedToHide(flightTo))
        {
            return 1;
        }

        compareResult = ((AirProfile)((AirMaterial)flightFrom).Profile).Airlines[0].Code.CompareTo(((AirProfile)((AirMaterial)flightTo).Profile).Airlines[0].Code);

        if (compareResult != 0)
        {
            return compareResult;
        }
        else
        {
            return CompareFlightPrice(flightFrom, flightTo);
        }

    }

    private void SetLowerPrice(AirMaterial currentFlight, AirMatrixFlightMeta currentMatrix)
    {
        int currentStops = 0;
        MatrixStopType stopType = MatrixStopType.All;

        //判断该Flight有多少Stop
        currentStops = GetFlightStops(currentFlight);
        stopType = GetMatrixStopType(currentStops);

        switch (currentStops)
        {
            case 0:
                SetLowerPriceDetail(currentMatrix.ZeroStopPrice, currentFlight);
                break;
            case 1:
                SetLowerPriceDetail(currentMatrix.OneStopPrice, currentFlight);
                break;
            default:
                SetLowerPriceDetail(currentMatrix.MoreThanTwoStopPrice, currentFlight);

                break;
        }

        currentMatrix.AddFlight(currentFlight, stopType);
        AirMatrixFlightsByStop.AddFlight(currentFlight, stopType);
    }

    private MatrixStopType GetMatrixStopType(int stops)
    {
        MatrixStopType matrixStopType = MatrixStopType.ZeroStop;

        switch (stops)
        {
            case 0:
                matrixStopType = MatrixStopType.ZeroStop;
                break;
            case 1:
                matrixStopType = MatrixStopType.OneStop;
                break;
            default:
                matrixStopType = MatrixStopType.MoreThanTwoStop;
                break;
        }

        return matrixStopType;
    }

    private void SetLowerPriceDetail(AirMatrixFlightMeta.Price price, AirMaterial currentFlight)
    {
        if (price.BaseFare == 0)
        {
            price.TotalPrice = GetTotalPrice(currentFlight);
            price.BaseFare = currentFlight.AdultBaseFare + currentFlight.AdultMarkup;
        }

        else if (IsCurrentPriceLower(price, currentFlight))
        {
            price.TotalPrice = GetTotalPrice(currentFlight);
            price.BaseFare = currentFlight.AdultBaseFare + currentFlight.AdultMarkup;
        }
    }

    private bool IsCurrentPriceLower(AirMatrixFlightMeta.Price price, AirMaterial currentFlight)
    {
        decimal currentTotalPrice = 0;
        currentTotalPrice = GetTotalPrice(currentFlight);

        if (currentTotalPrice == price.TotalPrice)
        {
            return currentFlight.AdultBaseFare < price.BaseFare;
        }

        return GetTotalPrice(currentFlight) < price.TotalPrice;
    }

    private bool IsAirLineChanged(string currentAirLineCode, string preAirLineCode)
    {
        return currentAirLineCode != preAirLineCode;
    }

    private void SetFirstPrice(AirMaterial currentFlight, AirMatrixFlightMeta currentMatrix)
    {
        int currentStops = 0;
        MatrixStopType stopType = MatrixStopType.All;

        //判断该Flight有多少Stop
        currentStops = GetFlightStops(currentFlight);
        stopType = GetMatrixStopType(currentStops);

        switch (currentStops)
        {
            case 0:
                SetPriceDetail(currentMatrix.ZeroStopPrice, currentFlight);
                break;
            case 1:
                SetPriceDetail(currentMatrix.OneStopPrice, currentFlight);
                break;
            default:
                SetPriceDetail(currentMatrix.MoreThanTwoStopPrice, currentFlight);
                break;
        }

        currentMatrix.AddFlight(currentFlight, stopType);
        AirMatrixFlightsByStop.AddFlight(currentFlight, stopType);
    }

    private void SetPriceDetail(AirMatrixFlightMeta.Price price, AirMaterial currentFlight)
    {
        price.TotalPrice = GetTotalPrice(currentFlight);
        price.BaseFare = currentFlight.AdultBaseFare + currentFlight.AdultMarkup;
    }

    private decimal GetTotalPrice(AirMaterial currentFlight)
    {
        return currentFlight.AdultBaseFareWithCCSurcharge + currentFlight.AdultMarkup + currentFlight.AdultTax;
    }

    private decimal GetComparePrice(AirMaterial currentFlight)
    {
        return currentFlight.AdultBaseFareWithCCSurcharge + currentFlight.AdultMarkup + currentFlight.AdultTax;
    }

    private int GetFlightStops(AirMaterial currentFlight)
    {
        int currentStops = 0;
        SubAirTrip currentSubAirTrip = null;

        //遍历SubTrips
        for (int subTripIndex = 0; subTripIndex < currentFlight.AirTrip.SubTrips.Count; subTripIndex++)
        {
            currentSubAirTrip = currentFlight.AirTrip.SubTrips[subTripIndex];
            if (subTripIndex == 0)
            {
                currentStops = GetStopsInsideFlight(currentSubAirTrip);
            }
            else
            {
                currentStops = GetStopsInsideFlight(currentSubAirTrip) > currentStops ? GetStopsInsideFlight(currentSubAirTrip) : currentStops;
            }
        }

        return currentStops;
    }

    public int GetStopsInsideFlight(SubAirTrip currentSubAirTrip)
    {
        int stops = 0;

        stops = currentSubAirTrip.Flights.Count - 1;

        for (int flightIndex = 0; flightIndex < currentSubAirTrip.Flights.Count; flightIndex++)
        {
            stops += int.Parse(currentSubAirTrip.Flights[flightIndex].NumberOfStops);
        }

        return stops;
    }

    private const string LOGO_DEFAULT = "~/images/airline/defult_air.jpg";

    private void SetAirLine(AirMaterial currentFlight, AirMatrixFlightMeta currentMatrix)
    {
        

        if (flightInfohider.IsNeedToHide(currentFlight))
        {
            Airline airLine = new Airline();
            airLine.Code = flightInfohider.ReplaceFlightCode(currentFlight);
            airLine.Name = flightInfohider.ReplaceFlightName(currentFlight);
            airLine.LogoUrl = LOGO_DEFAULT;

            currentMatrix.AirLine = airLine;
        }
        else
        {
            currentMatrix.AirLine = ((AirProfile)currentFlight.Profile).Airlines[0];
        }
    }

    private bool IsFirstFligt(int flightIndex)
    {
        return flightIndex == 0;
    }

    public List<Component> GetSortedByPriceFlightList(List<Component> flightList)
    {
        Comparison<Component> sortedByPriceComparison = new Comparison<Component>(CompareFlightPrice);

        flightList.Sort(sortedByPriceComparison);

        return flightList;
    }

    private int SortFlagMultipule
    {
        get
        {
            int sortFlag = 1;

            switch (m_sortFlag)
            {
                case SortFlag.Asc:
                    sortFlag = 1;
                    break;

                case SortFlag.Desc:
                    sortFlag = -1;
                    break;
            }

            return sortFlag;
        }
    }

    private int CompareFlightPrice(Component flightFrom, Component flightTo)
    {
        return GetComparePrice((AirMaterial)flightFrom).CompareTo(GetComparePrice((AirMaterial)flightTo));
    }

    public enum SortFlag
    {
        Asc,
        Desc,
        None
    }

    private SortFlag m_sortFlag;

    public List<Component> GetSortedList(List<Component> flightList, SortByFlag sortbyFlag, SortFlag sortFlag)
    {
        List<Component> sortedList = null;
        m_sortFlag = sortFlag;

        switch (sortbyFlag)
        {
            case SortByFlag.Price:
                sortedList = GetSortedByPriceFlightList(flightList);
                break;

            case SortByFlag.Airline:
                sortedList = GetSortedByAirLineFlightList(flightList);
                break;

            case SortByFlag.DepartureDate:
                sortedList = GetSortedByDepartureDateFlightList(flightList);
                break;

            case SortByFlag.ArrivalDate:
                sortedList = GetSortedByArrivalDateFlightList(flightList);
                break;

            case SortByFlag.Duration:
                sortedList = GetSortedByDurationFlightList(flightList);
                break;
        }

        if (m_sortFlag == SortFlag.Desc)
        {
            sortedList.Reverse();
        }
        
        return sortedList;
    }

    private List<Component> GetSortedByDurationFlightList(List<Component> flightList)
    {
        List<Component> sortedList = null;

        sortedList = CopyList(flightList);
        Comparison<Component> sortedComparer = new Comparison<Component>(CompareDuration);

        sortedList.Sort(sortedComparer);

        return sortedList;
    }

    private List<Component> GetSortedByArrivalDateFlightList(List<Component> flightList)
    {
        List<Component> sortedList = null;

        sortedList = CopyList(flightList);
        Comparison<Component> sortedComparer = new Comparison<Component>(CompareArrivalDate);

        sortedList.Sort(sortedComparer);

        return sortedList;
    }

    private int CompareDuration(Component flightFrom, Component flightTo)
    {
        int compareResult = GetDuration((AirMaterial)flightFrom).CompareTo(GetDuration((AirMaterial)flightTo));

        if (compareResult != 0)
        {
            return compareResult;
        }
        else
        {
            return CompareFlightPrice(flightFrom, flightTo);
        }
    }

    /// <summary>
    /// 取得机票的时间间隔。
    /// 遍历SubTrip,求和每个SubTrip的时间间隔。
    /// </summary>
    /// <param name="airMaterial">机票信息</param>
    /// <returns>该机票的时间间隔</returns>
    public TimeSpan GetDuration(AirMaterial airMaterial)
    {
        TimeSpan duration = TimeSpan.Zero;
        
        for(int subTripIndex = 0; subTripIndex < airMaterial.AirTrip.SubTrips.Count; subTripIndex++)
        {
            duration += GetDuration(airMaterial.AirTrip.SubTrips[subTripIndex]);
        }

        return duration;
    }


    public TimeSpan GetFlightTime(AirMaterial flight)
    {
        TimeSpan duration = TimeSpan.Zero;

        for (int subTripIndex = 0; subTripIndex < flight.AirTrip.SubTrips.Count; subTripIndex++)
        {
            duration += GetFlightTime(flight.AirTrip.SubTrips[subTripIndex]);
        }

        return duration;
    }

    /// <summary>
    /// 取得SubTrip的时间间隔。
    /// </summary>
    /// <param name="airMaterial">SubTrip信息</param>
    /// <returns>该SubTrip的时间间隔</returns>
    public TimeSpan GetFlightTime(SubAirTrip subTrip)
    {
        TimeSpan duration = TimeSpan.Zero;

        for (int airLegIndex = 0; airLegIndex < subTrip.Flights.Count; airLegIndex++)
        {
            duration += GetFlightTime(subTrip.Flights[airLegIndex]);
        }

        return duration;
    }

    /// <summary>
    /// 取得SubTrip的时间间隔。
    /// </summary>
    /// <param name="airMaterial">SubTrip信息</param>
    /// <returns>该SubTrip的时间间隔</returns>
    public TimeSpan GetDuration(SubAirTrip subTrip)
    {
        TimeSpan duration = TimeSpan.Zero;

        for (int airLegIndex = 0; airLegIndex < subTrip.Flights.Count; airLegIndex++)
        {
            duration += GetDuration(subTrip.Flights[airLegIndex]);
        }

        return duration;
    }

    /// <summary>
    /// 取得AirLeg的时间间隔。
    /// AirLeg.ArrivalTime - AirLeg.Departure + 城市时间差
    /// </summary>
    /// <param name="airMaterial">SubTrip信息</param>
    /// <returns>该AirLeg的时间间隔</returns>
    public TimeSpan GetFlightTime(AirLeg airLeg)
    {
        TimeSpan duration = TimeSpan.Zero;

        duration = airLeg.ElapsedFlightTime;

        return duration;
    }

    /// <summary>
    /// 取得AirLeg的时间间隔。
    /// AirLeg.ArrivalTime - AirLeg.Departure + 城市时间差
    /// </summary>
    /// <param name="airMaterial">SubTrip信息</param>
    /// <returns>该AirLeg的时间间隔</returns>
    public TimeSpan GetDuration(AirLeg airLeg)
    {
        TimeSpan duration = TimeSpan.Zero;

        duration = airLeg.ElapsedFlightTime + airLeg.GroundTime;

        return duration;
    }

    private int CompareArrivalDate(Component flightFrom, Component flightTo)
    {
        int compareResult = GetArrivalDate((AirMaterial)flightFrom).CompareTo(GetArrivalDate((AirMaterial)flightTo));

        if (compareResult != 0)
        {
            return compareResult;
        }
        else
        {
            return CompareFlightPrice(flightFrom, flightTo);
        }
    }

    private DateTime GetArrivalDate(AirMaterial airMaterial)
    {
        int subTripsIndex = 0;
        int flihgtIndex = 0;

        //subTripsIndex = airMaterial.AirTrip.SubTrips.Count - 1;
        subTripsIndex = 0;
        flihgtIndex = airMaterial.AirTrip.SubTrips[subTripsIndex].Flights.Count - 1;

        return airMaterial.AirTrip.SubTrips[subTripsIndex].Flights[flihgtIndex].ArriveTime;
    }

    private List<Component> GetSortedByDepartureDateFlightList(List<Component> flightList)
    {
        List<Component> sortedList = null;

        sortedList = CopyList(flightList);
        Comparison<Component> sortedComparer = new Comparison<Component>(CompareDepartureDate);

        sortedList.Sort(sortedComparer);

        return sortedList;
    }

    private int CompareDepartureDate(Component flightFrom, Component flightTo)
    {
        int compareResult = GetDepartureDate((AirMaterial)flightFrom).CompareTo(GetDepartureDate((AirMaterial)flightTo));

        if (compareResult != 0)
        {
            return compareResult;
        }
        else
        {
            return CompareFlightPrice(flightFrom, flightTo);
        }
    }

    private DateTime GetDepartureDate(AirMaterial airMaterial)
    {
        return airMaterial.AirTrip.SubTrips[0].Flights[0].DepartureTime;
    }

    public string FormatTimeSpan(TimeSpan timeSpan)
    {
        string hourMsg = Global.hourMsg;
        string minMsg = Global.minMsg;
        
        //switch (Thread.CurrentThread.CurrentCulture.Name)
        //{
        //    case "zh-CN":
        //        hourMsg = " 時 ";
        //        minMsg = " 分";
        //        break;

        //    default:
        //        hourMsg = " hr ";
        //        minMsg = " min";
        //        break;
        //}

        return ((int)timeSpan.TotalHours).ToString() + hourMsg + ((double)Math.Round(((timeSpan.TotalHours - (int)timeSpan.TotalHours) * 60), 2)).ToString() + minMsg;
    }

    public string GetDistance(AirMaterial flight)
    {
        int miles = 0;

        foreach (SubAirTrip subAirTrip in flight.AirTrip.SubTrips)
        {
            miles += subAirTrip.Miles;
        }

        if (miles == 0)
        {
            return string.Empty;
        }

        return FormatDistance(miles);
    }

    public string FormatDistance(int miles)
    {
        string milesMsg = Global.milesMsg;
        string kmMsg = Global.kmMsg;

        //switch (Thread.CurrentThread.CurrentCulture.Name)
        //{
        //    case "zh-CN":
        //        milesMsg = " 英里";
        //        kmMsg = " 公里";
        //        break;

        //    default:
        //        milesMsg = " miles";
        //        kmMsg = " km";
        //        break;
        //}

        return String.Format("{0} " + milesMsg + " ({1} " + kmMsg + ")", miles.ToString("#,###"), ConvertMilesToKilometers(miles).ToString("#,####"));
    }

    public int ConvertMilesToKilometers(int m)
    {
        return ((int)(m * 1.609344));
    }
}
