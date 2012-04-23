<%@ Page Language="C#" AutoEventWireup="true" Inherits="Test" Codebehind="Test.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script language="javascript" type="text/javascript">
    //解析URL中的参数，并返回参数列表
//function getQueryString(urlString) 
//{
//    //声明用来容纳所有键值对的数组
//    var arrayURL = new Array();         
//    ///获取传入的URL
//    var sUrl = "http://www.cnblogs.com?a=1&&&&&&&b=2"  // urlString
//    ///URL中是否包含查询字符串
//    if (sUrl.indexOf("?") > 0)
//    {
//        //分解URL,第二的元素为完整的查询字符串
//        //即arrayParams[1]的值为【id=1&action=2】
//        var arrayParams = sUrl.split("?");
//        //分解查询字符串
//        //arrayURLParams[0]的值为【id=1 】
//        //arrayURLParams[2]的值为【action=add】
//        var arrayURLParams = arrayParams[1].split("&");
//        //遍历分解后"&"的键值对
//        for (var i = 0; i < arrayURLParams.length; i++)
//        {
//            if (arrayURLParams[i] != null && arrayURLParams[i] != "")
//            {
//                arrayURL.push(arrayURLParams[i]);
//            }
//        }            
//    }
//}
    
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtURL" runat="server" Text="echo%2cxue%2cyzang%40majestic-vacations.com%2c22222%2cShanghai+test%2cXX%2cGTTMNL%2c681cce55-33ec-4a47-8210-4da80b1f5a5a%2c6346436436%2c%2cqingdao%2cMANITOBA%2c266500%2cCANADA%2c22222222%2c,I"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Button" />
    </form>
</body>
</html>
<%--MJVID=1,2,xglhm@sh163.com.cn,3333,test,123DFW,SAN,c220efc8-f7a2-4c80-bf0b-5fd45b8f4654
echo%2cxue%2cyzang%40majestic-vacations.com%2c22222%2cShanghai+test%2cXX%2cGTTHOU%2c681cce55-33ec-4a47-8210-4da80b1f5a5a%2c6346436436%2c%2cqingdao%2cMANITOBA%2c266500%2cCANADA%2c22222222%2c,I
echo%2cxue%2cyzang%40majestic-vacations.com%2c22222%2cShanghai+test%2cXX%2cGTTMNL%2c681cce55-33ec-4a47-8210-4da80b1f5a5a%2c6346436436%2c%2cqingdao%2cMANITOBA%2c266500%2cCANADA%2c22222222%2c,I


--%>
