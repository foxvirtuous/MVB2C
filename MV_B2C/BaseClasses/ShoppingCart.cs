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


public class ShoppingCart
{
    private string _CaseMumber = String.Empty;
    private string _Pnr = String.Empty;
    private bool _CanToBook = true;
    private bool _BookSuccessed = false;
    private List<string> _ErrorList = new List<string>();

    public List<string> ErrorList
    {
        get
        {
            return (List<string>)HttpContext.Current.Session["ErrorList"];
        }
        set
        {
            HttpContext.Current.Session.Add("ErrorList", value);
        }
    }

    public bool CanToBook
    {
        get
        {
            return _CanToBook;
        }
        set
        {
            _CanToBook = value;
        }
    }

    public bool BookSuccessed
    {
        get
        {
            return _BookSuccessed;
        }
        set
        {
            _BookSuccessed = value;
        }
    }

    public string CaseNumber
    {
        get
        {
            return _CaseMumber;
        }
        set
        {
            _CaseMumber = value;
        }
    }

    public string RcordLocator
    {
        get
        {
            return _Pnr;
        }
        set
        {
            _Pnr = value;
        }
    }
}