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
using Terms.Base.Domain;
using Terms.Base.Service;
using Terms.Global.Domain;

/// <summary>
/// MessageManager 的摘要说明
/// </summary>
public static class MessageManager
{

    public static Terms.Base.Domain.ErrorMessage GetMessage(MessageContainer code, IList list)
    {
        Terms.Base.Domain.ErrorMessage msgFinded;

        //如果错误信息为空，返回空
        if(code.MessageCode == string.Empty)
        {
            return null;
        }

        //初始化

        msgFinded = null;

        ////对内部错误进行遍历

        //while (code.InnerMessage != null)
        //{

        //}

        //取得最外层的数据信息

        foreach (Terms.Base.Domain.ErrorMessage msg in list)
        {
            if (msg.Code == code.MessageCode)
            {
                //将错误信息补全

                if (code.Parameters != null)
                {
                    msg.Text = string.Format(msg.Text, code.Parameters);
                    msgFinded = msg;                    
                }
                else
                {                    
                    msgFinded = msg;
                }
                break;
            }
        }

        //如果存在内部错误信息，则取得内部错误信息
        if (code.InnerMessage != null)
        {
            msgFinded.InnerMessage = GetMessage(code.InnerMessage, list);
            
        }

        return msgFinded;
    }
}
