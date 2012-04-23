using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TERMS.Common;
using System.Collections;
using System.Collections.Generic;
using TERMS.Business.Centers.ProductCenter.Components;
using TERMS.Core.Product;

/// <summary>
/// Summary description for AirMatrixFlightMeta
/// </summary>
public class AirMatrixFlightMeta
{
    private List<Component> _zeroStopFlightList;
    private List<Component> _oneStopFlightList;
    private List<Component> _moreThanTwoStopFlightList;


    public AirMatrixFlightMeta()
    {
        _airLine = new Airline();
        _zeroStopPrice = new Price();
        _oneStopPrice = new Price();
        _moreThanTwoStopPrice = new Price();
        _lowFareSelectPrice = new Price();

        _zeroStopFlightList = new List<Component>();
        _oneStopFlightList = new List<Component>();
        _moreThanTwoStopFlightList = new List<Component>();

        _needHide = false;
    }

    private Airline _airLine;
    public Airline AirLine
    {
        get
        {
            return _airLine;
        }
        set
        {
            _airLine = value;
        }
    }

    private Price _zeroStopPrice;
    public Price ZeroStopPrice
    {
        get
        {
            return _zeroStopPrice;
        }
        set
        {
            _zeroStopPrice = value;
        }
    }

    private Price _oneStopPrice;
    public Price OneStopPrice
    {
        get
        {
            return _oneStopPrice;
        }
        set
        {
            _oneStopPrice = value;
        }
    }

    private Price _moreThanTwoStopPrice;
    public Price MoreThanTwoStopPrice
    {
        get
        {
            return _moreThanTwoStopPrice;
        }
        set
        {
            _moreThanTwoStopPrice = value;
        }
    }

    private Price _lowFareSelectPrice;
    public Price LowFareSelectPrice
    {
        get
        {
            return _lowFareSelectPrice;
        }
        set
        {
            _lowFareSelectPrice = value;
        }
    }

    private Price _lowestPrice;
    public Price LowestPrice
    {
        get
        {
            //
            _lowestPrice = GetLowestPrice();

            return _lowestPrice;
        }
    }

    private bool _needHide;
    public bool NeedHide
    {
        get
        {
            return _needHide;
        }
        set
        {
            _needHide = value;
        }
    }

    private Price GetLowestPrice()
    {
        Price lowestPrice = new Price();

        if (_zeroStopPrice.ComparedPrice != 0)
        {
            lowestPrice.ComparedPrice = _zeroStopPrice.ComparedPrice;
        }

        if (lowestPrice.ComparedPrice == 0)
        {
            lowestPrice.ComparedPrice = _oneStopPrice.ComparedPrice;
        }
        else if (_oneStopPrice.ComparedPrice != 0 && _oneStopPrice.ComparedPrice < lowestPrice.ComparedPrice)
        {
            lowestPrice.ComparedPrice = _oneStopPrice.ComparedPrice;
        }

        if (lowestPrice.ComparedPrice == 0)
        {
            lowestPrice.ComparedPrice = _moreThanTwoStopPrice.ComparedPrice;
        }
        else if (_moreThanTwoStopPrice.ComparedPrice != 0 && _moreThanTwoStopPrice.ComparedPrice < lowestPrice.ComparedPrice)
        {
            lowestPrice.ComparedPrice = _moreThanTwoStopPrice.ComparedPrice;
        }

        //if (lowestPrice.ComparedPrice == 0)
        //{
        //    lowestPrice.ComparedPrice = _lowFareSelectPrice.ComparedPrice;
        //}
        //else if (_lowFareSelectPrice.ComparedPrice != 0 && _lowFareSelectPrice.ComparedPrice < lowestPrice.ComparedPrice)
        //{
        //    lowestPrice.ComparedPrice = _lowFareSelectPrice.ComparedPrice;
        //}

        if (lowestPrice.ComparedPrice == 0)
        {
            lowestPrice.ComparedPrice = Decimal.MaxValue;
        }

        return lowestPrice;
    }

    public class Price
    {
        private decimal _baseFare;
        private decimal _totalPrice;

        public Price()
        {
            _baseFare = 0;
            _totalPrice = 0;
        }

        public decimal BaseFare
        {
            get
            {
                return decimal.Round(_baseFare);
            }
            set
            {
                _baseFare = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return decimal.Round(_totalPrice);
            }
            set
            {
                _totalPrice = value;
            }
        }

        public decimal ComparedPrice
        {
            get
            {
                return decimal.Round(_totalPrice);
            }

            set
            {
                _totalPrice = value;
            }
        }

        public override string ToString()
        {
            return TotalPrice.ToString();
        }
    }

    public List<Component> GetFlightList(MatrixStopType matrixStopType)
    {
        List<Component> flightList = null;

        switch (matrixStopType)
        {
            case MatrixStopType.ZeroStop:
                flightList = _zeroStopFlightList;
                break;

            case MatrixStopType.OneStop:
                flightList = _oneStopFlightList;
                break;

            case MatrixStopType.MoreThanTwoStop:
                flightList = _moreThanTwoStopFlightList;
                break;

            case MatrixStopType.All:
                flightList = new List<Component>();

                flightList.AddRange(_zeroStopFlightList);
                flightList.AddRange(_oneStopFlightList);
                flightList.AddRange(_moreThanTwoStopFlightList);
                break;
        }

        return new AirLineMatricsManager().GetSortedByPriceFlightList(flightList);
    }

    

    public void AddFlight(AirMaterial flight, MatrixStopType matrixStopType)
    {
        switch (matrixStopType)
        {
            case MatrixStopType.ZeroStop:
                _zeroStopFlightList.Add(flight);
                break;

            case MatrixStopType.OneStop:
                _oneStopFlightList.Add(flight);
                break;

            case MatrixStopType.MoreThanTwoStop:
                _moreThanTwoStopFlightList.Add(flight);
                break;

            case MatrixStopType.All:
                throw new Exception("You must choose the other type to Add a Flight.");
                break;
        }
    }
}

public enum MatrixStopType
{
    ZeroStop,
    OneStop,
    MoreThanTwoStop,
    All
}


