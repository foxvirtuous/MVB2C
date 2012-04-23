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
    /// �ı������������ַ�����
    /// </summary>
    public int MaxLength
    {
        set
        {
            txtMustInput.MaxLength = value;
        }
    }

    /// <summary>
    /// CSS��ʽ
    /// </summary>
    public string CssClass
    {
        set
        {
            txtMustInput.CssClass = value;
        }
    }

    /// <summary>
    /// �ı�����
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
    /// �Ƿ������ֵ
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
    /// �Ƿ�Ϊ�ʼ���ʽ
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
    /// �Ƿ��������
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
    /// �Ƿ�Ϊ������ʽ
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
    /// �Ƿ���Ӣ�ĺ��ո���ַ���
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
    /// �Ƿ�Ϊ������ʽ
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
    /// �Ƿ�Ϊ������ʽ
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
