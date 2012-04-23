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

/// <summary>
/// Summary description for AirMatrixFlightsByStop
/// </summary>
public class AirMatrixFlightsByStop
{
    private List<Component> _zeroStopFlightList;
    private List<Component> _oneStopFlightList;
    private List<Component> _moreThanTwoStopFlightList;

	public AirMatrixFlightsByStop()
	{
        _zeroStopFlightList = new List<Component>();
        _oneStopFlightList = new List<Component>();
        _moreThanTwoStopFlightList = new List<Component>();
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
