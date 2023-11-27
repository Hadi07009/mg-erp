<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ERP.Master" CodeBehind="EmployeeActiveInactive.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeActiveInactive" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>

    <script type="text/javascript" language="javascript">

        function controlEnter(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            if (keyCode == 13) {

                document.getElementById(obj).focus();

                return false;

            }

            else {

                return true;

            }

        }

    </script>
    <script type="text/javascript">
        function TextName_OnKeyDown(e) {
            var keynum
            if (window.event) // IE
            {
                keynum = e.keyCode
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                keynum = e.which
            }
            if (keynum == 13) {
                <%--document.getElementById('<%= btnSave.ClientID %>').click();--%>
            }
        }
    </script>



    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");

        }
    </script>

    <script type="text/javascript">

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        row.style.backgroundColor = "white";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            row.style.backgroundColor = "white";

                        }

                        else {

                            row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }

    </script>
    <script type="text/javascript">

        function MouseEvents(objRef, evt) {

            var checkbox = objRef.getElementsByTagName("input")[0];

            if (evt.type == "mouseover") {

                objRef.style.backgroundColor = "orange";

            }

            else {

                if (checkbox.checked) {

                    objRef.style.backgroundColor = "aqua";

                }

                else if (evt.type == "mouseout") {

                    if (objRef.rowIndex % 2 == 0) {

                        //Alternating Row Color

                        objRef.style.backgroundColor = "#C2D69B";

                    }

                    else {

                        objRef.style.backgroundColor = "white";

                    }

                }

            }

        }

    </script>

      <table class="style1">
        <tr>
            <td style="width: 342px; height: 15px">
                <asp:Label ID="lblHeadOfficeName" runat="server" Text="Office Name" Font-Bold="True"
                    Font-Size="Small" Font-Names="Tahoma" Style="color: #0000FF"></asp:Label>
            </td>
            <td style="height: 15px">
                <asp:Label ID="lblHeadOfficeAddress" runat="server" Text="Head Office  Address" Font-Bold="True"
                    Font-Size="Small" Style="color: #0000FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 342px">
                <asp:Label ID="lblBranchOfficeName" runat="server" Text="Office Name" Font-Bold="True"
                    Font-Size="Small" Font-Names="Tahoma" Style="color: #0000FF"></asp:Label>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblBranchOfficeAddress" runat="server" Text="Branch Office Address"
                    Font-Bold="True" Font-Size="Small" Style="color: #0000FF"></asp:Label>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <fieldset>
        <legend>Active Inactive Employee</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 900px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                      ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <%--<tr>
                <td style="text-align: left; height: 26px;" align="right" colspan="3">


                    <table class="style1">
                        <tr>
                            <td style="text-align: right; ">  
                            </td>
                            <td style="text-align: right; ">
                                &nbsp;
                            </td>
                            <td style="text-align: justify; ">
                                &nbsp;
                            </td>
                            <td style="text-align: justify; width: 550px;">
                                &nbsp;
                            </td>
                            <td style="text-align: right; width: 550px;">
                                <asp:Label ID="lblIsActiveYNCause" runat="server" Text="Active:Y/N Cause" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="width: 550px; text-align: right">
                                <asp:DropDownList ID="ddlEmployeeStatusId" runat="server" Width="200px" Height="22px"  Enabled="true"> </asp:DropDownList>
                                <asp:Label ID="lblIsActiveStatus" runat="server" Text="Status:" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="text-align: justify; width: 550px;">
                                <asp:TextBox ID="txtEmployeeStatus" runat="server" Width="331px" BackColor="White" Height="47px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td style="text-align: justify; width: 550px;">
                                &nbsp;
                            </td>
                            <td style="text-align: justify; width: 550px;">
                                &nbsp;
                            </td>
                              <td style="text-align: right; margin-left:100px ">
                                  &nbsp;
                              </td>
                            <td style="text-align: left;">
                                &nbsp;
                            </td>
                        </tr>
                                             
                        <tr>
                            <td style="text-align: right; ">
                            </td>
                            <td style="text-align: right; ">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: justify; width: 550px;">
                                &nbsp;</td>
                            
                            <td style="text-align: right; width: 550px;">
                                <asp:Label ID="lblIsActive" runat="server" Text="Active:Y/N" Font-Bold="False"></asp:Label>
                            </td>
                            
                            <td style="text-align: left; width: 550px;">
                               <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes"/>                              
                            </td>
                            
                            <td style="text-align: left; width: 550px;">
                                &nbsp;</td>
                            
                            <td style="text-align: left; width: 550px;">
                                &nbsp;</td>
                            
                            <td style="text-align: left; width: 550px;">
                                &nbsp;</td>
                            
                        </tr>

                        <tr>
                            <td style="text-align: right; ">&nbsp;</td>
                            
                            <td style="text-align: right; ">&nbsp;</td>
                            
                            <td style="text-align: right;" class="auto-style5">&nbsp;
                                
                            </td>
                            <td style="width: 550px">&nbsp;
                                
                                </td>
                            <td style="width: 550px">&nbsp;</td>
                            <td style="width: 550px">
                                <asp:Button ID="btnSave" runat="server" Height="31px" Text="Update" Width="52px"
                                    CssClass="styled-button-4" OnClick="btnSave_Click" />

                                <asp:Button ID="btnClear" runat="server" Height="31px" Text="Reset" Width="59px" CssClass="styled-button-4"
                                    OnClientClick="target = '_SELF';" OnClick="btnClear_Click" />
                                <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet"   CssClass = "styled-button-4"
                                        Width="55px" Visible="True" OnClick="btnSheet_Click"
                                       />

                            </td>
                            <td style="width: 550px">&nbsp;</td>
                            <td style="width: 550px">&nbsp;</td>
                            <td style="width: 550px">&nbsp;</td>
                            <td style="width: 9px">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <%--<tr>
                <td style="text-align: right; width: 54px;">&nbsp;</td>
                <td style="text-align: right;">&nbsp;</td>
                <td style="text-align: justify">&nbsp;</td>
            </tr> --%>          
       </table>
    </fieldset>

    <%--new--%>

    <fieldset>
        <legend>ACTIVE/INACTIVE</legend>
           <table class="style1">
               <tr>

                   <td style="width: 150px; text-align: right; vertical-align:top; height: 22px;">
                       <asp:Label ID="lblEffectiveDate" runat="server" Text="Date:" Font-Bold="False" ></asp:Label>
                       <asp:TextBox ID="DtpEffectiveDate" runat="server" Width="100px" CssClass="date" Height="20px"></asp:TextBox>                                             
                   </td>
                                                         
                   <td style="width: 100px; text-align: right; vertical-align:top; height: 22px;">
                       <asp:Label ID="lblIsActive" runat="server" Text="Active:" Font-Bold="False" ></asp:Label>
                       <asp:CheckBox ID="chkActiveYn" runat="server"/>                              
                   </td>
                   <td style="width: 100px; text-align: right; height: 22px; vertical-align:top;">
                   <asp:Label ID="lblIsActiveYNCause" runat="server" Text="Reason:" Font-Bold="False"></asp:Label>                                                
                   </td>
                   <td style="width: 200px; height: 22px; vertical-align:top;" >
                       <asp:DropDownList ID="ddlEmployeeStatusId" runat="server" Width="200px" Height="22px"  Enabled="true" > </asp:DropDownList>   
                   </td>
                   <td style="width: 100px; height: 22px; text-align: right; vertical-align:top;">
                        <asp:Label ID="lblIsActiveStatus" runat="server" Text="Remarks:" Font-Bold="False"></asp:Label>                          
                   </td>
                   <td colspan="3" style="width: 250px; height: 22px; text-align: right;">
                       <asp:TextBox ID="txtEmployeeStatus" runat="server" Width="200px" BackColor="White" Height="35px" TextMode="MultiLine" style="text-align:right;"></asp:TextBox>                           
                   </td>

                   <td colspan="4" style="width: 150px; height: 22px; vertical-align:top;">
                       <asp:Button ID="btnSave" runat="server" Width="50px" Height="31px" Text="Update" CssClass="styled-button-4" OnClick="btnSave_Click" />
                       <asp:Button ID="btnClear" runat="server" Width="50px" Height="31px" Text="Reset" CssClass="styled-button-4"  OnClientClick="target = '_SELF';" OnClick="btnClear_Click" />
                   </td>
               </tr>                           
               
             </table>
        </fieldset>

    <%--new--%>
    
    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <table class="style1">
                                                    
                          <tr>
                              <%--<td style="width: 100px; text-align: right; height: 22px;">
                                  &nbsp;
                              </td>--%>
                              <td style="width: 100px; text-align: right; height: 22px;">
                                  <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                              </td>
                              <td style="width: 240px; height: 22px;">
                                  <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px" Enabled="true"> </asp:DropDownList>
                              </td>
                              <td style="height: 22px; width: 100px; text-align: right;">
                                  <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                              </td>
                              <td style="width: 100px; text-align: right;">
                                  <asp:TextBox ID="txtEmpCardNo" runat="server" Width="100px" BackColor="White"></asp:TextBox>
                              </td>
                              
                              <td style="width: 100px; height: 22px; text-align: right;">
                              <asp:Label ID="Label1" runat="server" Text="Start date :"></asp:Label>    
                              </td>
                              <td style="width: 100px; height: 22px;">
                                  <asp:TextBox ID="DtpStartDate" runat="server" Width="80px" Height="20px" CssClass="date"
                                        DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Font-Bold="False"></asp:TextBox>

                              </td>
                              <td style="width: 250px; text-align: left;">&nbsp;

                              <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="60px"
                                      CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                  <asp:Button ID="btnLog" runat="server" Width="60px" Height="31px" Text="Log" CssClass = "styled-button-4" Visible="True" OnClick="btnLog_Click"/>
                                  <asp:Button ID="BtnDailyLog" runat="server" Width="70px" Height="31px" Text="Daily Log" CssClass = "styled-button-4" Visible="True" OnClick="BtnDailyLog_Click"/>
                              </td>
                          </tr>

                          <tr>
                              <%--<td style="width: 100px; text-align: right">
                                  &nbsp;</td>--%>
                              <td style="width: 100px; text-align: right">
                                  <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                              </td>
                              <td style="width: 240px">
                                  <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px" Enabled="true">
                                  </asp:DropDownList>
                              </td>
                              <td style="width: 100px; text-align: right;">
                                  <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                              </td>
                              <td style="width: 100px; text-align: right;">
                                  <asp:TextBox ID="txtEmpId" runat="server" Width="100px" BackColor="White"></asp:TextBox>
                              </td>
                              
                              <td style="width: 100px; text-align: right;">
                                  <asp:Label ID="Label2" runat="server" Text="End date :"></asp:Label>    
                              </td>
                              <td style="width: 100px">
                                  <asp:TextBox ID="DtpEndDate" runat="server" Width="80px" Height="20px" CssClass="date"
                                        DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Font-Bold="False"></asp:TextBox>
                              </td>
                              <td style="width: 250px; text-align: right;">&nbsp;</td>
                              
                          </tr>

                          <tr>
                              <%--<td style="width: 100px; text-align: right">&nbsp;</td>--%>
                                              
                              <td style="width: 100px; text-align: right"> 
                                <asp:Label ID="lblIsActiveSearch" runat="server" Text="Active:" Font-Bold="False"></asp:Label>
                              </td>

                              <td style="width: 100px; "> 
                                <asp:CheckBox ID="chkActiveYnSearch" runat="server"/>                              
                              </td>
                              <td style="width: 100px; text-align: right">&nbsp;</td>
                              <td style="width: 100px; text-align: right">&nbsp;</td>
                              <td style="width: 100px; text-align: right">&nbsp;</td>   
                              <td style="width: 100px; text-align: right;">&nbsp;</td>
                              <td style="width: 250px; text-align: right;">&nbsp;</td>
                          </tr>
                          
                      </table>
    </fieldset>

    <fieldset>
      <legend>SEARCH RESULT</legend>
        <table class="style1">
            <tr>
                <td>
                    <asp:GridView ID="gvActiveInactiveEmployee" runat="server" DataSourceID=""
                        AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                        OnRowDataBound="gvActiveInactiveEmployee_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                        GridLines="None" AllowPaging="false" OnRowEditing="gvActiveInactiveEmployee_OnRowEditing"
                        OnRowCommand="gvActiveInactiveEmployee_RowCommand"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvActiveInactiveEmployee_OnSelectedIndexChanged"
                        CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvActiveInactiveEmployee_PageIndexChanging"
                        OnSelectedIndexChanging="gvActiveInactiveEmployee_SelectedIndexChanging" Width="1003px">
                        <Columns> 
                             <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>                                          
                            <asp:BoundField DataField="SLNo" HeaderText="Sl" />
                            <asp:BoundField DataField="CardNo" HeaderText="Card No" />
                            <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                            <asp:BoundField DataField="DesignationName" HeaderText="Designation" /> 
                            <asp:BoundField DataField="JoiningDate" HeaderText="Joining Date" />
                            <asp:BoundField DataField="UnitName" HeaderText="Unit" /> 
                            <asp:BoundField DataField="SectionName" HeaderText="Unit" />                              
                            <asp:BoundField DataField="ActiveYn" HeaderText="Status" />          
                            <asp:BoundField DataField="EmployeeId" HeaderText="Id"/>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EmployeeId")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="SkillLevelId" HeaderText="SkillId" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                        </Columns>
                    </asp:GridView>                    
                </td>
            </tr>
        </table>
    </fieldset>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
