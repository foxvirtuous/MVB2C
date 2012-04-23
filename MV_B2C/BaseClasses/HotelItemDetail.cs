using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Terms.Base.Domain;

/// <summary>
/// HotelItemDetail 的摘要说明
/// </summary>
public class HotelItemDetail
{
    public HotelItemDetail()
    {

    }

    private DateTime _DateFrom;
    public DateTime DateFrom
    {
        get { return _DateFrom; }
        set { _DateFrom = value; }
    }

    private DateTime _DateTo;
    public DateTime DateTo
    {
        get { return _DateTo; }
        set { _DateTo = value; }
    }

    private decimal _FitRate;
    public decimal FitRate
    {
        get { return _FitRate; }
        set { _FitRate = value; }
    }

    private Nullable<decimal> _GitRate;
    public Nullable<decimal> GitRate
    {
        get { return _GitRate; }
        set { _GitRate = value; }
    }

    private Nullable<decimal> _SeriesGitRate;
    public Nullable<decimal> SeriesGitRate
    {
        get { return _SeriesGitRate; }
        set { _SeriesGitRate = value; }
    }

    private Nullable<decimal> _RackRate;
    public Nullable<decimal> RackRate
    {
        get { return _RackRate; }
        set { _RackRate = value; }
    }

    private Nullable<decimal> _ExtraBedFee;
    public Nullable<decimal> ExtraBedFee
    {
        get { return _ExtraBedFee; }
        set { _ExtraBedFee = value; }
    }

    private decimal _ExtraBabyBedFee;
    public decimal ExtraBabyBedFee
    {
        get { return _ExtraBabyBedFee; }
        set { _ExtraBabyBedFee = value; }
    }

    private Nullable<double> _Commision;
    public Nullable<double> Commision
    {
        get { return _Commision; }
        set { _Commision = value; }
    }

    private bool _HasServiceFee;
    public bool HasServiceFee
    {
        get { return _HasServiceFee; }
        set { _HasServiceFee = value; }
    }

    private short _IncludeBreakfastAmount;
    public short IncludeBreakfastAmount
    {
        get { return _IncludeBreakfastAmount; }
        set { _IncludeBreakfastAmount = value; }
    }

    private BreakfastStyle _BreakfastStyle;
    public BreakfastStyle BreakfastStyle
    {
        get { return _BreakfastStyle; }
        set { _BreakfastStyle = value; }
    }

    private decimal _ExtraBreakfastFee;
    public decimal ExtraBreakfastFee
    {
        get { return _ExtraBreakfastFee; }
        set { _ExtraBreakfastFee = value; }
    }

    private string _RoomName;
    public string RoomName
    {
        get { return _RoomName; }
        set { _RoomName = value; }
    }


    public string SeasonString
    {
        get
        {
            return this._DateFrom.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo) + " - " + this._DateTo.ToString("MM/dd/yyyy", System.Globalization.DateTimeFormatInfo.InvariantInfo);
        }
    }
}