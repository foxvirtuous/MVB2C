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
using AjaxControlToolkit;

public partial class MoneyTextBox : System.Web.UI.UserControl
{
    private int precision = 0;
    private int scale = 0;

    ///// <summary>
    ///// 文本框可输入最大字符串数
    ///// </summary>
    //public int MaxLength
    //{
    //    set
    //    {
    //        //meeMustInput.Mask = "?{" + value.ToString().Trim() + "}";
    //        txtInput.MaxLength = value;
    //    }
    //}

    /// <summary>
    /// CSS样式
    /// </summary>
    public string CssClass
    {
        set
        {
            txtInput.CssClass = value;
        }
    }

    /// <summary>
    /// 文本内容
    /// </summary>
    public string Text
    {
        set
        {
            txtInput.Text = value;
        }

        get
        {
            return txtInput.Text;
        }
    }

    /// <summary>
    /// 是否允许空值
    /// </summary>
    /// <remarks>
    /// 是否允许空值
    /// </remarks>
    public bool IsValidEmpty
    {
        set
        {
            if (value == true)
            {
                txtInput.ValidationGroup = string.Empty;
                rfvMustInput.Enabled = false;
            }
        }
    }

    public bool IsFloatStyle
    {
        set
        {
            if (value == true)
            {
                txtInput.MaxLength  = 16;
                revMustInput.ValidationExpression = @"^-?(0|\d+)(\.\d+)?$";
                lblMoney.Text = "50.000";
            }
        }
    }

    public bool IsRaitingStyle
    {
        set
        {
            if (value == true)
            {
                txtInput.MaxLength = 3;
                precision = 3;
                scale = 1;
                revMustInput.ValidationExpression =
                    @"^\d{1,1}(\.5)?$";
                lblMoney.Text = "format: 3.5";
            }
        }
    }   

    public bool ReadOnly
    {
        set
        {
            txtInput.ReadOnly = value;
        }
    }

    /// <summary>
    /// 精度（总位数，包括小数点）
    /// </summary>
    public int Precision
    {
        set
        {
            txtInput.MaxLength = value;
            precision = value;

            SetFormat(precision, scale);
        }
    }

    /// <summary>
    /// 小数位数
    /// </summary>
    public int Scale
    {
        set
        {         
            scale = value;

            SetFormat(precision, scale);
        }
    }

    private void SetFormat(int precision, int scale)
    {
        //SetToolTipMsg(precision, scale);
        SetValidExpression(precision, scale);
    }

    private void SetToolTipMsg(int precision, int scale)
    {
        //lblMoney.Text = "format: 50.00";

        string integerpart; //整数部分
        string scalepart;   //小数部分,包括小数点

        integerpart = CreateIntegerpart(precision, scale);
        scalepart = CreateScalepart(scale);

        lblMoney.Text = "eg: " + "50" + scalepart;
        //lblMoney.Text = integerpart + scalepart + String.Format(" ({0},{1})", GetInterger(precision, scale), scale);

    }

    private string CreateScalepart(int scale)
    {
        string scalepart = string.Empty;

        for (int i = 1; i < scale + 1; i++ )
        {
            if (i > 9)
            {
                int temp = i - 9;
                scalepart += temp.ToString();
            }
            else
            {
                scalepart += i.ToString();
            }
        }

        if (scalepart != string.Empty)
        {
            scalepart = "." + scalepart;
        }

        return scalepart;
    }

    private string CreateIntegerpart(int precision, int scale)
    {
        int integer = GetInterger(precision, scale);
        
        string integerpartstr = string.Empty;

        for (int i = 1; i < integer + 1; i++)
        {
            if (i > 9)
            {
                int temp = i - 9;
                integerpartstr += temp.ToString();
            }
            else
            {
                integerpartstr += i.ToString();
            }
        }

        return integerpartstr;
    }

    private int GetInterger(int precision, int scale)
    {
        int interger;

        if (scale > 0)
        {
            interger = precision - scale - 1;
        }
        else
        {
            interger = precision;
        }

        return interger;
    }

    private void SetValidExpression(int precision, int scale)
    {
        int intergerpart; //整数部分

        intergerpart = GetInterger(precision, scale);

        if (scale > 0)
        {
            revMustInput.ValidationExpression = 
                    @"^\d{1,"
                    + intergerpart.ToString() 
                    + @"}(\.\d{1," 
                    + scale.ToString() + "})?$";
        }
        else
        {
            revMustInput.ValidationExpression =
                    @"^\d{1,"
                    + intergerpart.ToString()
                    + @"}(\.\d{0,0})?$";
        }
    }

    

    //public string Mask
    //{
    //    set
    //    {
    //        //meeMustInput.Mask = value;
    //        //mevMustInput.TooltipMessage = value;
    //        lblMoney.Text = value;
    //        meeMustInput.Filtered = value;
    //    }
    //}

    public string ToolTip
    {
        set
        {
            lblMoney.Text = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
