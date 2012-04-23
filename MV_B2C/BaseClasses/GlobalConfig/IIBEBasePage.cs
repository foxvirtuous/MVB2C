using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Terms.Configuration.Domain;
using Spring.Aspects.AirOperate;

/// <summary>
/// Summary description for Class1
/// </summary>
public interface IIBEBasePage
{
    WebSiteMeta CurrentWebSite { get;set;}
    AirStepConfirmLogAdvice OperaterAdvice { get;}
}
