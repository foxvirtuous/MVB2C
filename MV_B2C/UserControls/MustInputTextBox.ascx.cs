using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

//[DefaultEvent("TextChanged")]
public partial class TermsTextBox : System.Web.UI.UserControl
{
    private bool isNumberStyle = false;
    private bool isEmailStyle = false;
    private bool isBirthdayStyle = false;
    private bool isEnglishCharOrBlankStyle = false;

    public TermsTextBox()
    {
        this.Init += new EventHandler(TermsTextBox_Init);
    }

    void TermsTextBox_Init(object sender, EventArgs e)
    {
        if (this.Page.IsPostBack == false)
        {
            phValadation.Visible = true;
        }
    }

    /// <summary>
    /// 文本框可输入最大字符串数
    /// </summary>
    public int MaxLength
    {
        set
        {
            txtMustInput.MaxLength = value;
        }
    }

    /// <summary>
    /// CSS样式
    /// </summary>
    public string CssClass
    {
        set
        {
            txtMustInput.CssClass = value;
        }
    }

    /// <summary>
    /// 文本内容
    /// </summary>
    public string Text
    {
        set
        {
            txtMustInput.Text = value;
        }

        get
        {
            return txtMustInput.Text;
        }
    }

    /// <summary>
    /// 是否允许空值
    /// </summary>
    public bool IsValidEmpty
    {
        set
        {
            //mevMustInput.IsValidEmpty = value;

            //
            if (value == true)
            {
                txtMustInput.ValidationGroup = string.Empty;
                rfvMustInput.Enabled = false;
            }
        }
    }

    /// <summary>
    /// 是否为邮件形式
    /// </summary>
    public bool IsEmailStyle
    {
        set
        {
            if (value == true)
            {
                isEmailStyle = true;

                revMustInput.Enabled = true;

                revMustInput.ValidationExpression = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            }
        }

        get
        {
            return isEmailStyle;
        }
    }

    /// <summary>
    /// 是否出生日期
    /// </summary>
    public bool IsBirthdayStyle
    {
        set
        {
            if (value == true)
            {
                isBirthdayStyle = true;

                revMustInput.Enabled = true;

                revMustInput.ValidationExpression = @"^((0([1-9]{1}))|(1([0-2]{1})))/(([0-2]([1-9]{1}))|([1-2]0)|(3[0|1]))/(19\d{2}|20\d{2})$";
            }
        }

        get
        {
            return isBirthdayStyle;
        }
    }

    /// <summary>
    /// 是否为数字形式
    /// </summary>
    public bool IsNumberStyle
    {
        set
        {
            if (value == true)
            {
                isNumberStyle = true;

                fteMustInput.Enabled = true;
                fteMustInput.FilterType = FilterTypes.Numbers;
            }
            else
            {
                fteMustInput.Enabled = false;
            }
        }

        get
        {
            return isNumberStyle;
        }
    }

    /// <summary>
    /// 是否是英文含空格的字符串
    /// </summary>
    public bool IsEnglishCharOrBlankStyle
    {
        set
        {
            if (value == true)
            {
                isEnglishCharOrBlankStyle = true;
                revMustInput.Enabled = true;
                revMustInput.ErrorMessage = "Please input English characters";
                revMustInput.ValidationExpression = @"[a-zA-Z\s]+";
            }

        }

        get
        {
            return isEnglishCharOrBlankStyle;
        }
    }


    public enum TextStyles
    {
        Telephone
    }

    /// <summary>
    /// 是否为密码形式
    /// </summary>
    public TextStyles TextStyle
    {
        set
        {
            switch (value)
            {
                case TextStyles.Telephone:

                    fteMustInput.Enabled = true;
                    fteMustInput.ValidChars = "-";
                    fteMustInput.FilterType = FilterTypes.Custom & FilterTypes.Numbers;
                    break;

                default:
                    fteMustInput.Enabled = false;
                    break;
            }
        }
    }

    /// <summary>
    /// 是否为密码形式
    /// </summary>
    public TextBoxMode TextMode
    {
        set
        {
            txtMustInput.TextMode = value;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public string ValidationGroup
    {
        set
        {
            txtMustInput.ValidationGroup = value;
            rfvMustInput.ValidationGroup = value;
        }
    }


    public string ErrorMessage
    {
        set
        {
            rfvMustInput.ErrorMessage = value;
        }
    }

    public bool ReadOnly
    {
        set
        {
            txtMustInput.ReadOnly = value;
        }
    }

    public string Width
    {
        set
        {
            txtMustInput.Width = new Unit(value);
        }
    }

    public event EventHandler TextChanged = null;


    protected void Page_Load(object sender, EventArgs e)
    {

    }

}
