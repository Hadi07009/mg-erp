<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportHeadOfficePower.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportHeadOfficePower" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <%--</fieldset>--%>
    <fieldset>
        <legend>Report</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="5">
                    <fieldset>
                        <legend>REPORT FORMAT TYPE</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                                        GroupName="Controls" CssClass="CheckBox" OnCheckedChanged="chkPDF_CheckedChanged"
                                        Font-Bold="True" />
                                    &nbsp;<asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true"
                                        GroupName="Controls" OnCheckedChanged="chkExcel_CheckedChanged" Font-Bold="True"
                                        CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkWord" runat="server" Text="Word" AutoPostBack="true" OnCheckedChanged="chkWord_CheckedChanged"
                                        GroupName="Controls" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkText" runat="server" Text="Text" AutoPostBack="true" OnCheckedChanged="chkText_CheckedChanged"
                                        GroupName="Controls" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;
                                    <asp:CheckBox ID="chkCSV" runat="server" GroupName="Controls" Text="CSV" AutoPostBack="true"
                                        OnCheckedChanged="chkCSV_CheckedChanged" Font-Bold="True" CssClass="CheckBox" />
                                </td>
                            </tr>
                            <tr>
                </td>
            </tr>
        </table>
    </fieldset>
    </td> </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rptDailyAttendenceSheet" runat="server" 
                AutoPostBack="true" Text="Attendence Sheet (Daily) "
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            <asp:Label ID="lblUnitId" runat="server" Text="Unit  :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlUnitId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 59px; text-align: right;">
            <asp:Label ID="lblOfficeId8" runat="server" Text="ID :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmpId" runat="server" Width="144px" placeholder="EMPLOYEE ID "
                Height="22px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheetSummery" runat="server" AutoPostBack="true"
                Text="Attendence  Summery Sheet  (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            <asp:Label ID="lblUnitId0" runat="server" Text="Section :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlSectionId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 59px; text-align: right;">
            <asp:Label ID="lblOfficeId11" runat="server" Text="Card No :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtCardNo" runat="server" Width="144px" placeholder="CARD NO" Height="22px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheet" runat="server" AutoPostBack="true"
                Text="Job Card" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            <asp:Label ID="lblOfficeId6" runat="server" Text="Year :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtYear" runat="server" Width="144px" BackColor="White" placeholder="YEAR"></asp:TextBox>
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;<asp:Label ID="lblOfficeId9" runat="server" Text="From :"></asp:Label>
            &nbsp;
        </td>
        <td>
            <asp:TextBox ID="dtpFromDate" runat="server" Width="144px" BackColor="White" placeholder="FROM DATE"
                CssClass="date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheetAll" runat="server" AutoPostBack="true"
                Text="Attendence  Sheet All (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            <asp:Label ID="lblOfficeId7" runat="server" Text="Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtMonth" runat="server" Width="144px" BackColor="White" placeholder="MONTH"></asp:TextBox>
        </td>
        <td style="width: 59px; text-align: right;">
            <asp:Label ID="lblOfficeId10" runat="server" Text="To :"></asp:Label>
            &nbsp;
        </td>
        <td>
            <asp:TextBox ID="dtpToDate" runat="server" Width="144px" BackColor="White" placeholder="TO DATE"
                CssClass="date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeLateSheet" runat="server" AutoPostBack="true"
                Text="Attendence Late Sheet" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            <asp:Label ID="lblFromMonth" runat="server" Text="From Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlFromMonthId" runat="server" Width="148px" Height="22px"
                placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 59px; text-align: right;">
            <asp:Label ID="lblOfficeId12" runat="server" Text="Dept :"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlDepartmentId" runat="server" Width="148px" Height="22px"
                placeholder="Unit">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyAdvanceInformation" runat="server" AutoPostBack="true"
                Text="Advance Sheet (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            <asp:Label ID="lblToMonth" runat="server" Text="To Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlToMonthId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyArrearInformation" runat="server" AutoPostBack="true"
                Text="Arrear Sheet (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyAATInformation" runat="server" AutoPostBack="true"
                Text="Advance Arrear Tax Sheet (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoArrearSheetAll" runat="server" AutoPostBack="true" Text="Arrear Sheet All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoArrearSlipAll" runat="server" AutoPostBack="true" Text="Arrear Slip All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMontlyBankSalaryList" runat="server" Text="Bank Salary  (Monthly) "
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOByBank" runat="server" AutoPostBack="true"
                Text="Bank Salary Sheet (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlySalaryCheckSheet" runat="server" Text="Cash Salary Sheet (Monthly) "
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoDesignationList" runat="server" AutoPostBack="true" Text="Designation List"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeListHO" runat="server" AutoPostBack="true" Text="Employee Gross, First, Misc Salary List"
                GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeBasicInformation" runat="server" AutoPostBack="true"
                Text="Employee Basic Information" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeJobYearMonthHistory" runat="server" AutoPostBack="true"
                Text="Employee Job Year List" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeDetailInformation" runat="server" AutoPostBack="true"
                Text="Employee Detail Information" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoEmployeeJobHistory" runat="server" AutoPostBack="true" Text="Employee Job History"
                GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right; height: 22px;">
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 22px;">
        </td>
        <td style="height: 22px">
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 21px;">
            <asp:RadioButton ID="rdoEmployeeDetailList" runat="server" AutoPostBack="true" Text="Employee Information"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="height: 21px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeDetailListAll" runat="server" 
                AutoPostBack="true" Text="Employee Information All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeLeaveSheet" runat="server" AutoPostBack="true" Text="Employee Leave Information"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeJobConfiramtionSheet" runat="server" AutoPostBack="true"
                Text="Employe Job Confiramtion Sheet" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeJoiningResignInfo" runat="server" AutoPostBack="true"
                Text="Employee Joining Sheet" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeResignInfo" runat="server" AutoPostBack="true"
                Text="Employee Resignation Sheet" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeBasicInformationPower" runat="server" AutoPostBack="true"
                Text="Employee Information All" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeJoiningInfo" runat="server" AutoPostBack="true"
                Text="Employee Joining Information" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoHalfCashSalaryRequisition" runat="server" Text="Half Salary Cash Requisition"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoHalfSalarySheetByBank" runat="server" Text="Half Salary Sheet According to Bank"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoInactiveEmployeeList" runat="server" AutoPostBack="true"
                Text="Inactive Employee List" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoIncrementProposal" runat="server" AutoPostBack="true" Text="Increment Proposal"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: left;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoIncrementProposalAll" runat="server" 
                AutoPostBack="true" Text="Increment Proposal All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoIncrementSheetAll" runat="server" AutoPostBack="true" Text="Increment Sheet All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoIncrementSlipAll" runat="server" AutoPostBack="true" Text="Increment Slip All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyBankCashStatement" runat="server" AutoPostBack="true"
                Text="Miscellaneous Sheet (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoNewEmployeeList" runat="server" AutoPostBack="true" Text="New Employee List"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOMISCPaySlip" runat="server" AutoPostBack="true"
                Text="Pay Slip  Misc (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoMonthlySalarySheetHO" runat="server" AutoPostBack="true"
                Text="Salary Sheet (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOPaySlip" runat="server" AutoPostBack="true"
                Text="Salary Pay Slip (Monthly)  " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="height: 22px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionHODetail" runat="server" Text="Salary Requisition  (Monthly) "
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoSalaryCertificate" runat="server" AutoPostBack="true" Text="Salary Certificate"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoSalaryCertificateList" runat="server" AutoPostBack="true"
                Text="Salary Certificate List" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOMISC" runat="server" AutoPostBack="true"
                Text="Salary Sheet MISC (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoSalaryHistory" runat="server" AutoPostBack="true" Text="Salary History"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlySalaryStatement" runat="server" AutoPostBack="true"
                Text="Salary Statement(Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoYearlySalaryStatement" runat="server" AutoPostBack="true"
                Text="Salary Statement(Yearly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyTaxInformation" runat="server" AutoPostBack="true"
                Text="Tax Sheet (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoTaxStatement" runat="server" AutoPostBack="true"
                Text="Tax Sheet Detail" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoTaxSummerySheetDetail" runat="server" AutoPostBack="true"
                Text=" Tax Statement(Yearly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoTaxSummerySheet" runat="server" AutoPostBack="true"
                Text="Tax Summery Statement(Yearly )" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoTaxSummerySheetFirstSalary" runat="server" AutoPostBack="true"
                Text="Tax And Salary Summery Statement" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            &nbsp;</td>
        <td style="width: 78px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
            <td>
                &nbsp;
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
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
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
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
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
