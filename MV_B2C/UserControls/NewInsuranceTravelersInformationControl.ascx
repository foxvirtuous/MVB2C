<%@ Control Language="C#" AutoEventWireup="true" Codebehind="NewInsuranceTravelersInformationControl.ascx.cs"
    Inherits="NewInsuranceTravelersInformationControl" %>

<script type="text/javascript" language="javascript">
    function GetAdultSame(index,name)
		{
			var chkInput = document.getElementById(name);
			if (chkInput.checked == true)
			{
				var txtst = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultStreet").value;
				var txtct = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultCity").value;
				var txtzp = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultZip").value;
				document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl" + index + "_txtAdultStreet").value = txtst;
				document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl" + index + "_txtAdultCity").value   = txtct;
				document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl" + index + "_txtAdultZip").value    = txtzp;
				var   oSrc=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_ddlAdultCountry');   
                  var   oDst=document.all("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl" + index + "_ddlAdultCountry");   
                  var   oTmp=oSrc.cloneNode(true);  
                  oDst.options.length = 0;
                    for(var i=0;i<oTmp.length;i++)
                      { 
                      oDst[i]=new Option(oTmp[i].text ,oTmp[i].value); 
                      }
                  var   oSrc1=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_ddlAdultState');   
                  var   oDst1=document.all("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl" + index + "_ddlAdultState");   
                  var   oTmp1=oSrc1.cloneNode(true);   
                  oDst1.options.length = 0;
                    for(var i=0;i<oTmp1.length;i++)
                      { 
                      oDst1[i]=new Option(oTmp1[i].text ,oTmp1[i].value); 
                      }
                  for(var   i=0;i<oDst.length;i++){  
                      if(oDst.options[i].value==oSrc.value){  
                          oDst.options[i].selected=true;  
                          break;  
                      }  
                  }
                  for(var   i=0;i<oDst1.length;i++){  
                      if(oDst1.options[i].value==oSrc1.value){  
                          oDst1.options[i].selected=true;  
                          break;  
                      }  
                  }
			}
		}  
		function GetChildSame(index,name)
		{
			var chkInput = document.getElementById(name);
			if (chkInput.checked == true)
			{
				var txtst = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultStreet").value;
				var txtct = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultCity").value;
				var txtzp = document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_txtAdultZip").value;
				document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlChild_ctl" + index + "_txtChildStreet").value = txtst;
				document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlChild_ctl" + index + "_txtChildCity").value   = txtct;
				document.getElementById("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlChild_ctl" + index + "_txtChildZip").value    = txtzp;
				var   oSrc=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_ddlAdultCountry');   
                  var   oDst=document.all("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlChild_ctl" + index + "_ddlChildCountry");   
                  var   oTmp=oSrc.cloneNode(true);  
                  oDst.options.length = 0;
                    for(var i=0;i<oTmp.length;i++)
                      { 
                      oDst[i]=new Option(oTmp[i].text ,oTmp[i].value); 
                      }
                  var   oSrc1=document.all('NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlAdult_ctl00_ddlAdultState');   
                  var   oDst1=document.all("NewInsuranceTravelersContactInformationControl1_NewInsuranceTravelersInformationControl1_dlChild_ctl" + index + "_ddlChildState");   
                  var   oTmp1=oSrc1.cloneNode(true);   
                  oDst1.options.length = 0;
                    for(var i=0;i<oTmp1.length;i++)
                      { 
                      oDst1[i]=new Option(oTmp1[i].text ,oTmp1[i].value); 
                      }
                  for(var   i=0;i<oDst.length;i++){  
                      if(oDst.options[i].value==oSrc.value){  
                          oDst.options[i].selected=true;  
                          break;  
                      }  
                  }
                  for(var   i=0;i<oDst1.length;i++){  
                      if(oDst1.options[i].value==oSrc1.value){  
                          oDst1.options[i].selected=true;  
                          break;  
                      }  
                  }
			}
		}   
</script>

<asp:DataList ID="dlAdult" runat="server" Width="100%">
    <ItemTemplate>
        <table class="IBE_package_step5_TravelInfo_T_step0l" width="100%" align="center"
            border="0" cellpadding="0" cellspacing="1">
            <tbody>
                <tr class="IBE_package_step5_TravelInfo_R_stepw">
                    <td>
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr class="IBE_package_step5_TravelInfo_R_step03" align="center">
                                    <td align="left" height="23" style="color: blue">
                                        Adult Traveler #<asp:Label ID="lblAdultCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="IBE_T_step03" width="100%" border="0" cellpadding="3" cellspacing="1">
                            <tbody>
                                <tr class="IBE_R_stepw" align="left">
                                    <td width="20%" style="height: 30px">
                                        <span class="Required_t01">*</span> Gender:</td>
                                    <td style="height: 30px">
                                        <asp:RadioButtonList ID="rbtnAdultGender" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Mr</asp:ListItem>
                                            <asp:ListItem Value="1">Ms</asp:ListItem>
                                            <asp:ListItem Value="2">Mrs</asp:ListItem>
                                            <asp:ListItem Value="3">Dr</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:Label ID="lbGender" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Salutationn") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td width="20%" style="height: 30px">
                                        <span class="Required_t01">*</span> Last Name:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtAdultLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>'
                                            onblur="copytext(this)" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Must Input Last Name"
                                            ControlToValidate="txtAdultLast" Display="Dynamic"></asp:RequiredFieldValidator>
                                        &nbsp;&nbsp;Middle Name:
                                        <asp:TextBox ID="txtAdultMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName") %>'
                                            onblur="copytext(this)" />
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> First Name:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtAdultFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>'
                                            onblur="copytext(this)" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                                                runat="server" ErrorMessage="Must Input First Name" ControlToValidate="txtAdultFirst"
                                                Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        Passport Number:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtAdultPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber") %>' />
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Date of Birth:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtAdultBirthday" runat="server"></asp:TextBox>&nbsp;e.g., 5/12/1959
                                        (May 12, 1959)</td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Street Address:</td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtAdultStreet" runat="server" Width="300px" onblur="copytext(this)"></asp:TextBox><asp:CheckBox
                                            ID="chkAdultSam" runat="server" Text="The same as above" />
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> City:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtAdultCity" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Country &amp; State:</td>
                                    <td style="height: 30px">
                                        <asp:UpdatePanel runat="server" ID="CountryAndState">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlAdultCountry" runat="server" Width="180px" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddlAdultCountry_SelectedIndexChanged">
                                                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                                    ControlToValidate="ddlAdultCountry" Display="Dynamic" ErrorMessage="Please select country."
                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlAdultState" runat="server" onblur="copytext('aa')">
                                                </asp:DropDownList></ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Zip&nbsp;/&nbsp;Postal Code:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtAdultZip" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <div runat="server" id="divAdultTicketNumber">
                                    <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                        <td style="height: 30px">Ticket Number:
                                        </td>
                                        <td style="height: 30px">
                                            <asp:TextBox ID="txtAdultTicketNumber" runat="server" onblur="copytext(this)"></asp:TextBox>
                                        </td>
                                    </tr>
                                </div>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </ItemTemplate>
</asp:DataList>
<asp:DataList ID="dlChild" runat="server" Width="100%">
    <ItemTemplate>
        <table class="IBE_package_step5_TravelInfo_T_step0l" width="100%" align="center"
            border="0" cellpadding="0" cellspacing="1">
            <tbody>
                <tr class="IBE_package_step5_TravelInfo_R_stepw">
                    <td>
                        <table width="100%" border="0" cellpadding="2" cellspacing="0">
                            <tbody>
                                <tr class="IBE_package_step5_TravelInfo_R_step03" align="center">
                                    <td align="left" height="23" style="color: blue">
                                        Child Traveler #<asp:Label ID="lblChildCount" runat="server" Text='<%# Container.ItemIndex + 1%>'></asp:Label></td>
                                </tr>
                            </tbody>
                        </table>
                        <table class="IBE_T_step03" width="100%" border="0" cellpadding="3" cellspacing="1">
                            <tbody>
                                <tr class="IBE_R_stepw" align="left">
                                    <td width="20%" style="height: 30px">
                                        <span class="Required_t01">*</span> Gender:</td>
                                    <td style="height: 30px">
                                        <asp:RadioButtonList ID="rbtnChildGender" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="0">Mr</asp:ListItem>
                                            <asp:ListItem Value="1">Ms</asp:ListItem>
                                            <asp:ListItem Value="2">Mrs</asp:ListItem>
                                            <asp:ListItem Value="3">Dr</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <asp:Label ID="lbGender" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem, "Salutationn") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td width="20%" style="height: 30px">
                                        <span class="Required_t01">*</span> Last Name:
                                    </td>
                                    <td width="80%" style="height: 30px">
                                        <asp:TextBox ID="txtChildLast" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "LastName") %>' />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Must Input Last Name"
                                            ControlToValidate="txtChildLast" Display="Dynamic"></asp:RequiredFieldValidator>
                                        &nbsp;&nbsp;Middle Name:
                                        <asp:TextBox ID="txtChildMiddle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "MiddleName") %>' />
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> First Name:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtChildFirst" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "FirstName") %>' /><asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Must Input First Name"
                                            ControlToValidate="txtChildFirst" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        Passport Number:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtChildPassport" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "PassportNumber") %>' />
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Date of Birth:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtChildBirthday" runat="server"></asp:TextBox>&nbsp;e.g., 5/12/1959
                                        (May 12, 1959)</td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Street Address:</td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtChildStreet" runat="server" Width="415px" onblur="copytext(this)"></asp:TextBox><asp:CheckBox
                                            ID="chkChildSam" runat="server" Text="The same as above" />
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> City:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtChildCity" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Country &amp; State:</td>
                                    <td style="height: 30px">
                                        <asp:UpdatePanel runat="server" ID="CountryAndState">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddlChildCountry" runat="server" Width="180px" AutoPostBack="true"
                                                    onblur="copytext('aa')" OnSelectedIndexChanged="ddlChildCountry_SelectedIndexChanged">
                                                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="ddlChildCountry" Display="Dynamic" ErrorMessage="Please select country."
                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddlChildState" runat="server">
                                                </asp:DropDownList></ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                    <td style="height: 30px">
                                        <span class="Required_t01">*</span> Zip&nbsp;/&nbsp;Postal Code:
                                    </td>
                                    <td style="height: 30px">
                                        <asp:TextBox ID="txtChildZip" runat="server" onblur="copytext(this)"></asp:TextBox>
                                    </td>
                                </tr>
                                <div runat="server" id="divChildTicketNumber">
                                    <tr class="IBE_package_step5_TravelInfo_R_stepw" align="left">
                                        <td style="height: 30px">Ticket Number:
                                        </td>
                                        <td style="height: 30px">
                                            <asp:TextBox ID="txtChildTicketNumber" runat="server" onblur="copytext(this)"></asp:TextBox>
                                        </td>
                                    </tr>
                                </div>
                            </tbody>
                        </table>
                    </td>
                </tr>
            </tbody>
        </table>
    </ItemTemplate>
</asp:DataList>
