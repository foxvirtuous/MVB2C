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

/// <summary>
/// Summary description for MenuItem
/// </summary>

public class MenuItem
{
    public MenuItem()
    {
    }
    private string _Name;
    public string Name
    {
        set
        {
            this._Name = value;
        }
        get
        {
            return this._Name;
        }
    }

    private string _Url;
    public string Url
    {
        get
        {
            return this._Url;
        }
        set
        {
            this._Url = value;
        }
    }

    private string _ImageUrl;
    public string ImageUrl
    {
        get
        {
            return this._ImageUrl;
        }
        set
        {
            this._ImageUrl = value;
        }
    }


    private string _Flag;
    public string Flag
    {
        get
        {
            return this._Flag;
        }
        set
        {
            this._Flag = value;
        }
    }

    private string _CssClass;
    public string CssClass
    {
        get
        {
            return this._CssClass;
        }
        set
        {
            this._CssClass = value;
        }
    }

    private MenuItem[] _MenuItems;
    public MenuItem[] MenuItems
    {
        set
        {
            this._MenuItems = value;
        }
        get
        {
            return this._MenuItems;
        }
    }

    public void AddItem(MenuItem item)
    {
        ArrayList items = new ArrayList();
        if (this._MenuItems != null && this._MenuItems.Length > 0)
        {
            for (int index = 0; index < this._MenuItems.Length; index++)
            {
                items.Add(this._MenuItems[index]);
            }
        }
        items.Add(item);
        this._MenuItems = (MenuItem[])items.ToArray(typeof(MenuItem));
    }

}
