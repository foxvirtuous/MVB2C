<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PromosSearchListForm.aspx.cs"
    Inherits="PromosSearchListForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="920" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center">
                        <table width="920" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td height="15">
                                </td>
                            </tr>
                            <tr>
                                <td height="10">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="25" align="right" valign="top">
                                                <table width="305" border="0" cellpadding="0" cellspacing="0">
                                                    <tbody>
                                                        <tr align="center">
                                                            <td height="3" class="D_stepon">
                                                            </td>
                                                            <td width="2">
                                                            </td>
                                                            <td class="D_stepon">
                                                            </td>
                                                            <td width="2">
                                                            </td>
                                                            <td class="D_stepof">
                                                            </td>
                                                            <td width="2">
                                                            </td>
                                                            <td class="D_stepof">
                                                            </td>
                                                        </tr>
                                                        <tr align="center">
                                                            <td class="D_stepto">
                                                                Search</td>
                                                            <td width="2">
                                                            </td>
                                                            <td class="D_stepto">
                                                                Select</td>
                                                            <td width="2">
                                                            </td>
                                                            <td class="D_steptf">
                                                                Order/Payment</td>
                                                            <td width="2">
                                                            </td>
                                                            <td class="D_steptf">
                                                                Confirm</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" border="0" align="center" cellpadding="3" cellspacing="0" class="T_table">
                            <tr>
                                <td width="185" align="left" valign="top">
                                    <table cellpadding="0" cellspacing="1" width="170" class="T_step0l">
                                        <tr align="center" class="R_step01">
                                            <td height="23">
                                                Change Your Search</td>
                                        </tr>
                                        <tr class="R_stepbox">
                                            <td>
                                                <table align="center" border="0" cellpadding="3" cellspacing="0" width="95%">
                                                    <tr>
                                                        <td height="30">
                                                            <input value="RoundTrip" name="ctl00$rdbType" id="ctl00_rdbRoundTrip" onclick="ChangeFlightType('roundtrip')"
                                                                checked="checked" type="radio" />
                                                            Round Trip&nbsp;<input value="OneWay" name="ctl00$rdbType" id="ctl00_rdbOneway" onclick="ChangeFlightType('oneway')"
                                                                type="radio" />
                                                            One Way<br>
                                                            <input value="OpenJaw" name="ctl00$rdbType" id="ctl00_rdbOpenjaw" onclick="ChangeFlightType('openjaw')"
                                                                type="radio" />
                                                            Mutiple Cities</td>
                                                    </tr>
                                                </table>
                                                <table align="center" border="0" cellpadding="3" cellspacing="0" width="95%">
                                                    <tr>
                                                        <td colspan="2" class="D_stepb">
                                                            Departure Flight</td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%">
                                                            From
                                                            <input name="ctl00$txtDepCity" id="ctl00_txtDepCity" size="4" onblur="SetReturnCity()"
                                                                value="JFK" type="text" />
                                                        </td>
                                                        <td>
                                                            To
                                                            <input name="ctl00$txtDesCity" id="ctl00_txtDesCity" size="4" onblur="SetReturnCity()"
                                                                value="PVG" type="text" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="D_stepb">
                                                            Departure Date<br>
                                                            <input name="ctl00$input1" value="05/30/2008" id="ctl00_input1" size="12" onkeydown="if(event.keyCode==13)search('btnSearch')"
                                                                type="text" />
                                                            <a href="javascript:getSelectedMonth('1');getCurrentYear('1');show_calendar('form1.dep_month',document.form1.dep_month.value-1,document.form1.CalendarDepYear.value);"
                                                                onmouseover="window.status='Date Picker';return true;" onmouseout="window.status='';return true;"
                                                                tabindex="6">
                                                                <img src="../images/cal.gif" hspace="2" border="0" align="absmiddle">
                                                            </a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="D_stepb">
                                                            Return Flight</td>
                                                    </tr>
                                                    <tr id="oneway2">
                                                        <td width="50%">
                                                            From
                                                            <input name="ctl00$txtRtnFrom" id="ctl00_txtRtnFrom" size="4" readonly="readonly"
                                                                onblur="UpperCase(this)" value="PVG" type="text" />
                                                        </td>
                                                        <td>
                                                            To
                                                            <input name="ctl00$txtRtnTo" id="ctl00_txtRtnTo" size="4" readonly="readonly" onblur="UpperCase(this)"
                                                                value="JFK" type="text" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="D_stepb">
                                                            Return Date<br>
                                                            <input name="ctl00$input2" value="06/02/2008" id="ctl00_input2" size="12" onkeydown="if(event.keyCode==13)search('btnSearch')"
                                                                type="text" />
                                                            <a href="javascript:getSelectedMonth('1');getCurrentYear('1');show_calendar('form1.dep_month',document.form1.dep_month.value-1,document.form1.CalendarDepYear.value);"
                                                                onmouseover="window.status='Date Picker';return true;" onmouseout="window.status='';return true;"
                                                                tabindex="6">
                                                                <img src="../images/cal.gif" hspace="2" border="0" align="absmiddle">
                                                            </a>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table align="center" border="0" cellpadding="3" cellspacing="0" width="95%">
                                                    <tr>
                                                        <td width="45%">
                                                            Adult ( 12+ )<br>
                                                            <select name="ctl00$ddlAdult" id="ctl00_ddlAdult">
                                                                <option value="0">0</option>
                                                                <option selected="selected" value="1">1</option>
                                                                <option value="2">2</option>
                                                                <option value="3">3</option>
                                                                <option value="4">4</option>
                                                                <option value="5">5</option>
                                                                <option value="6">6</option>
                                                                <option value="7">7</option>
                                                                <option value="8">8</option>
                                                                <option value="9">9</option>
                                                                <option value="10">10</option>
                                                            </select>
                                                        </td>
                                                        <td>
                                                            Child ( 2 - 11 )<br>
                                                            <select name="ctl00$ddlChild" id="ctl00_ddlChild">
                                                                <option value="0">0</option>
                                                                <option selected="selected" value="1">1</option>
                                                                <option value="2">2</option>
                                                                <option value="3">3</option>
                                                                <option value="4">4</option>
                                                                <option value="5">5</option>
                                                                <option value="6">6</option>
                                                                <option value="7">7</option>
                                                                <option value="8">8</option>
                                                                <option value="9">9</option>
                                                                <option value="10">10</option>
                                                            </select>
                                                        </td>
                                                    </tr>
                                                    <tr valign="top">
                                                        <td colspan="2" align="center" height="35">
                                                            <input onclick="location.href='search_result.html'" type="submit" name="Submit" value="Search"
                                                                class="search_btn01">
                                                            <!-- <a href="#" id="P_redS">Detailed Search</a>-->
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" valign="top">
                                    <table width="735" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <img src="../images/promo/ad_test.jpg" /></td>
                                        </tr>
                                    </table>
                                    <table width="735" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="10" align="left">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="40%" rowspan="2" align="center">
                                                            <img src="../images/promo/ad_low.gif" />
                                                        </td>
                                                        <td colspan="2" align="center">
                                                            <img src="../images/promo/ad_call.jpg" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td width="50%" align="center" valign="top" style="padding-right: 10px; padding-left: 10px;
                                                            padding-bottom: 6px; padding-top: 10px; font-size: 13px; color: #555555">
                                                            <table width="80%" border="0" cellpadding="0" cellspacing="0">
                                                                <tr align="center" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
                                                                    padding-top: 10px; font-weight: bold; font-size: 13px; color: #555555">
                                                                    <td height="80" valign="middle">
                                                                        折扣代碼: <span style="font-weight: bold; font-size: 24px; color: #0058AA;">
                                                                            <br />
                                                                            MV-86-03-31</span>
                                                                    </td>
                                                                </tr>
                                                                <tr align="center">
                                                                    <td align="left">
                                                                        <span style="color: #555555; font-size: 12px">航空公司提供的優惠機票，可能會低於我們所公佈的票價，請來電給我們並由銷售人員為您解說及報價。</span></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td align="center" style="padding-right: 10px; padding-left: 10px; padding-bottom: 6px;
                                                            padding-top: 10px; font-weight: bold; font-size: 13px; color: #555555">
                                                            <table cellspacing="0" width="99%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td height="155" colspan="2" bgcolor="#3470ac" style="padding: 10px 20px;">
                                                                            <table width="100%" border="0" cellpadding="0" cellspacing="2">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td colspan="3" style="padding-bottom: 10px;">
                                                                                            <span style="color: #ffffff; font-size: 15px"><b>請填寫聯絡信息</b></span></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left" width="35%">
                                                                                            <font color="#ffffff">姓名:</font>&nbsp;&nbsp;&nbsp;</td>
                                                                                        <td align="left" width="55%">
                                                                                            <input name="ctl00$MainContent$txtName2" type="text" class="normal" id="ctl00$MainContent$txtName2"
                                                                                                size="15" /></td>
                                                                                        <td align="right" valign="bottom">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <font color="#ffffff">電話:</font>&nbsp;&nbsp;&nbsp;</td>
                                                                                        <td align="left">
                                                                                            <input name="ctl00$MainContent$txtPhone2" type="text" class="normal" id="ctl00$MainContent$txtPhone2"
                                                                                                size="15" /></td>
                                                                                        <td align="right" valign="bottom">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <font color="#ffffff">電郵:</font>&nbsp;&nbsp;&nbsp;</td>
                                                                                        <td align="left">
                                                                                            <input name="ctl00$MainContent$txtEmail2" type="text" class="normal" id="ctl00$MainContent$txtEmail2"
                                                                                                size="15" /></td>
                                                                                        <td valign="bottom">
                                                                                            <input type="submit" name="ctl00$MainContent$btnSendEmail2" value="送出" id="ctl00$MainContent$btnSendEmail2"
                                                                                                style="color: #444444; font-size: 12px" /></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10" align="center">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table style="border: 1px solid rgb(215, 218, 225);" cellpadding="0" cellspacing="0"
                                                    width="99%">
                                                    <tbody>
                                                        <tr>
                                                            <td height="100" valign="middle" bgcolor="#ffffe1" style="padding: 20px; font-size: 14px;">
                                                                <center>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td height="30" align="left">
                                                                                <span style="font-size: 16px; color: #FF3300"><b>為什麼要找明星假期旅遊網訂票:</b></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="40">
                                                                                <span style="color: #555555; font-size: 12px"><b>北美市場最大的機票供應商</b><br />
                                                                                    明星假期旅遊網擁有超過20年的豐富的機票銷售經驗. 我們擁有優秀的機票團隊及專業的機票背景. 提供到亞洲各大城市的便宜機票來符合顧客的需求. 另, 我們也是 USTOA的會員,
                                                                                    擁有良好的聲譽及誠信, 且具有嚴謹的財務管理制度來保障消費者的權益。<br />
                                                                                    <br />
                                                                                    <b>高品質</b><br />
                                                                                    明星假期旅遊網擁有強大的航空公司支持及價格談判能力, 所以提供的價格在同行中肯定是非常有競爭力, 我們的宗旨是提供客戶五星級的行程,三或四星級的價格,讓消費者感到物超所值.
                                                                                    訂過明星假期旅遊網機票的消費者,都留下極佳的口碑及美好的回憶, 且主動推薦親朋好友周知, 且有一半的客人都會再回來找我們服務, 也因為如此, 我們將更熱誠謹慎的服務每位客戶!<br />
                                                                                    <br />
                                                                                    <b>客戶服務</b><br />
                                                                                    我們非常重視客戶給予明星假期旅遊網的批評與指教,明星假期旅遊以精緻服務,創新,企劃性的行程為客戶服務,重點不只在於機票銷售,更在於服務.<br />
                                                                                    <br />
                                                                                    從客戶給予明星假期的意見中,我們不斷的針對機票,酒店,旅遊行程的商品進行修正與調整,以期更符合下一個消費者的滿意.明星假期旅遊採用高標準的態度來面對客戶服務,我們希望達到商品最豐富,價格最便宜,服務最親切,顧客最滿意的目標前進.也期盼顧客給予我們繼續支持與鼓勵!
                                                                                </span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </center>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr align="left">
                                <td colspan="2">
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
