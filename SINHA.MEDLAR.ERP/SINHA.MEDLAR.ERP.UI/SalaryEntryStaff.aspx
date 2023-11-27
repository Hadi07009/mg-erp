<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SalaryEntryStaff.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MiscEntryStaff" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtWorkingDay.ClientID %>").focus(); }) 
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
                e.preventDefault();
                $('#<%=btnSave.ClientID%>').click();
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
        <legend>STAFF SALARY INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 924px;">
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
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>SALARY ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 255px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="Label19" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSalaryYear" runat="server" Width="103px" Height="20px" Font-Bold="True"
                                        MaxLength="4"></asp:TextBox>
                                    <asp:TextBox ID="txtsalaryMonth" runat="server" Width="48px" Height="20px" Font-Bold="True"
                                        MaxLength="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 255px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" OnTextChanged="txtEmployeeId_TextChanged" Font-Bold="True"
                                        ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 255px; text-align: right">
                                    <asp:Label ID="Label45" runat="server" Text="Working Day :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="txtWorkingDay" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 255px; text-align: right">
                                    <asp:Label ID="Label27" runat="server" Text="Advance/Loan :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="txtAdvanceFee" runat="server" Width="62px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtLoanAmount" runat="server" Width="62px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" ForeColor="Red" BackColor="Yellow"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 255px; text-align: right">
                                    <asp:Label ID="Label29" runat="server" Text="Arrear :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="txtArrearFee" runat="server" Width="130px" Height="20px" OnTextChanged="txtArrearFee_TextChanged"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 255px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Food Allowance :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="txtFoodAllowance" runat="server" Width="130px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr style="display:none;">
                                <td style="width: 255px; text-align: right; height: 15px;">
                                    <asp:Label ID="Label44" runat="server" Text="Food Deduction :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left; height: 15px;">
                                    <asp:TextBox ID="txtFoodDeduction" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        ForeColor="Red" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 84px; text-align: right; height: 15px;">
                                    <asp:Label ID="Label5" runat="server" Text="Remarks :"></asp:Label>
                                </td>
                                <td style="height: 15px">
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="385px" Height="20px" Font-Bold="True" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; width: 255px;">
                                    &nbsp;
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 84px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>


                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <%--invisibling bellow 2 buttons for establishing master--%>
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="ATTEN." CssClass="styled-button-4"
                                        Width="51px" OnClick="btnAdd_Click" Visible="true" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="52px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" Visible="true" />

                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="44px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnEmployeeGrossHistory" runat="server" Height="31px" Text="Emp G.Sum"
                                        CssClass="styled-button-4" Width="74px" 
                                        OnClick="btnEmployeeGrossHistory_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="48px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process " Width="54px"
                                        CssClass="styled-button-4" OnClick="btnProcess_Click" />
                                    
                                    <asp:Button ID="BtnMasterSalarySheet" runat="server" Height="31px" Text="Master Sheet"
                                        CssClass="styled-button-4" Width="90px" OnClick="BtnMasterSalarySheet_Click" />
                                                             
                                    <asp:Button ID="btnMonthlyStaffSalarySheet" runat="server" Height="31px" Text="bKash Sheet"
                                        CssClass="styled-button-4" Width="80px" OnClick="btnMonthlyStaffSalarySheet_Click" />
                                    <asp:Button ID="btnCashSheet" runat="server" Height="31px" Text="Cash Sheet" Width="75px"
                                        CssClass="styled-button-4" OnClick="btnCashSheet_Click" />
                                    <asp:Button ID="btnBankSheetDetail" runat="server" Height="31px" Text="Bank Sheet" Width="75px"
                                        CssClass="styled-button-4" OnClick="btnBankSheetDetail_Click" />
                                    <asp:Button ID="btnBankSalarySheetStaff" runat="server" Height="31px" Text="Bank Forwarding"
                                        CssClass="styled-button-4" Width="110px" OnClick="btnBankSalarySheetStaff_Click" />
                                    <asp:Button ID="btnStafBKashTemplate" runat="server" Height="31px" Text="BKash Template"
                                        CssClass="styled-button-4" Width="120px" OnClick="btnStafBKashTemplate_Click" />
                                                                        <asp:Button ID="btnMonthlyStaffPaySlip" runat="server" Height="31px" Text="Pay Slip"
                                        CssClass="styled-button-4" Width="61px" OnClick="btnMonthlyStaffPaySlip_Click" />

                                    
                                 
                                    
                                    <asp:Button ID="btnBankSheet" runat="server" Height="31px" Text="B. Sheet(Sum)" Width="90px"
                                        CssClass="styled-button-4" OnClick="btnBankSheet_Click" />
                                    <asp:Button ID="btnBankRequisitionSheetDetail" runat="server" Height="31px" 
                                        Text="Requisition" Width="70px"
                                        CssClass="styled-button-4" OnClick="btnRequisitionSheetDetail_Click"  />

                                    <asp:Button ID="btnBkashRequisition" runat="server" Height="31px" Text="BKash Req" Width="90px"
                                        CssClass="styled-button-4" OnClick="btnBkashRequisition_Click" />

                                    <asp:Button ID="btnSalaryRequisitionHOStaff" runat="server" Height="31px" Text=" Cash Req."
                                        CssClass="styled-button-4" Width="68px" OnClick="btnSalaryRequisitionHOStaff_Click" />
                                    <asp:Button ID="btnSalaryRequisitionStaff" runat="server" Height="31px" Text=" Requisition Staff."
                                        CssClass="styled-button-4" Width="107px" OnClick="btnSalaryRequisitionStaff_Click" />
                                    <asp:Button ID="btnBankRequisitionSheet" runat="server" Height="31px" 
                                        Text="B. Req" Width="68px"
                                        CssClass="styled-button-4" OnClick="btnBankRequisitionSheet_Click"  />
                                      <asp:Button ID="btnMonthlyStaffGrossSalarySheet" runat="server" Height="31px" Text="Gross.S Sheet"
                                        CssClass="styled-button-4" Width="91px" OnClick="btnMonthlyStaffGrossSalarySheet_Click" />
                                    <asp:Button ID="BtnMasterSheetAll" runat="server" Height="31px" Text="Sheet (All)" Width="80px"
                                        CssClass="styled-button-4" OnClick="BtnMasterSheetAll_Click" />
                                      <asp:Button ID="BtnBankSheetAll" runat="server" Height="31px" Text="B. Sheet (All)" Width="80px"
                                        CssClass="styled-button-4" OnClick="BtnBankSheetAll_Click" />
                                      <asp:Button ID="BtnCashSheetAll" runat="server" Height="31px" Text="Bk. Sheet (All)" Width="80px"
                                        CssClass="styled-button-4" OnClick="BtnCashSheetAll_Click" />
                                
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 266px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label46" runat="server" Text="Unit Group :"></asp:Label>
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitGroupId" runat="server" Width="240px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Unit Group- 1"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Unit Group- 2"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Unit Group- 3"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Unit Group- 4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                </td>
                                                 <td style="text-align: right; width: 83px;">
                                                    <asp:Label ID="Label47" runat="server" Text="First Salary :"></asp:Label>
                                                </td>
                                                 <td style="height: 22px; width: 61px;">
                                                    <asp:TextBox ID="txtFirstSalary" runat="server" Width="149px" BackColor="White" Text="14999"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 248px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 156px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 61px;">
                                                    <%--<asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />--%>
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 83px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 248px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                </td>
                                                <td style="width: 156px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 61px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 83px;">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>SALARY ENTRY RESULT STAFF</legend>
                        <%--<asp:BoundField DataField="EMPLOYEE_PIC" HeaderText="PIC" />--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        CausesValidation="false" OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True"
                                        EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="WORKING_DAY" HeaderText="WD" />

                                            <asp:BoundField DataField="ABSENT_DAY" HeaderText="ABSENT DAY" />
                                            <asp:BoundField DataField="LEAVE_DAY" HeaderText="LEAVE DAY" />
                                            <asp:BoundField DataField="LATE_DAY" HeaderText="LATE DAY" />
                                            
                                            <asp:BoundField DataField="LOAN_AMOUNT" HeaderText="ADVANCE" />
                                              <asp:BoundField DataField="ADVANCE_SALARY" HeaderText="ADV.SAL"   />
                                            <asp:BoundField DataField="ARREAR_FEE" HeaderText="ARREAR" />
                                            <asp:BoundField DataField="FOOD_ALLOWANCE_FEE" HeaderText="F. ALLOWANCE" />
                                            <asp:BoundField DataField="FOOD_DEDUCT_FEE" HeaderText="F. DEDUCT" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <asp:BoundField DataField="PUNCH_YN" HeaderText="PUNCH_YN" />
                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <%-- </div>--%>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <%-- </div>--%>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CausesValidation="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing"
                        OnSelectedIndexChanged="OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
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
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
