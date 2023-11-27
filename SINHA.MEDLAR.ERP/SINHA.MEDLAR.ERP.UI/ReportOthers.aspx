<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportOthers.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportOthers" %>

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
    
        <table style="width: 100%">
            <tr>
                <td colspan="5">
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" />
                                    &nbsp;<asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true"
                                        ViewStateMode="Enabled" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkWord" runat="server" Text="Word" AutoPostBack="true" Font-Bold="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkText" runat="server" Text="Text" AutoPostBack="true" Font-Bold="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" />
                                    &nbsp;
                                    <asp:CheckBox ID="chkCSV" runat="server" GroupName="Controls" Text="CSV" AutoPostBack="true"
                                        ViewStateMode="Enabled" Font-Bold="True" CssClass="CheckBox" />
                                </td>
                            </tr>
                        </table>
                </td>
            </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rptDailyAttendenceSheet" runat="server" AutoPostBack="true"
                Text="Attendence Sheet (Daily) " GroupName="Controls" OnCheckedChanged="rptDailyAttendenceSheet_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId" runat="server" Text="Unit  :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlUnitId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:Label ID="lblUnitId1" runat="server" Text="ID :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmployeeId" runat="server" Width="145px" placeholder="EMPLOYEE ID"
                Height="20px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rptDailyAttendenceLateSheet" runat="server" AutoPostBack="true"
                Text="Attendence Sheet(Late) (Daily) " GroupName="Controls" OnCheckedChanged="rptDailyAttendenceLateSheet_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId0" runat="server" Text="Section :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlSectionId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:Label ID="lblOfficeId9" runat="server" Text="From :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="dtpFromDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="FROM DATE"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rptDailyAttendenceAbsenceSheet" runat="server" AutoPostBack="true"
                Text="Attendence Absence Sheet (Daily) " GroupName="Controls" OnCheckedChanged="rptDailyAttendenceAbsenceSheet_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId2" runat="server" Text="Card No :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtCardNo" runat="server" Width="145px" placeholder="CARD NO" Height="20px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:Label ID="lblOfficeId10" runat="server" Text="To :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="dtpToDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="TO DATE"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoDailyAttendenceTopSheet" runat="server" AutoPostBack="true"
                Text="Attendence Top Sheet (Daily) " Font-Bold="False" GroupName="Controls" OnCheckedChanged="rdoDailyAttendenceTopSheet_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId3" runat="server" Text="Type :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="148px" Height="22px"
                placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:Label ID="lbllMinute" runat="server" Text="Late Minute :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtLateMinute" runat="server" Width="145px" BackColor="White" 
                placeholder="Late Minute"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rptDailyAttendenceSheetInOut" runat="server" AutoPostBack="true"
                Text="Attendence Sheet(In or Out) (Daily) " GroupName="Controls" 
                OnCheckedChanged="rptDailyAttendenceSheet_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblYear" runat="server" Text="Year :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtYear" runat="server" Width="145px" Height="20px" BackColor="White"
                placeholder="YEAR"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:Label ID="lblOccuranceType" runat="server" Text="Occurance Type "></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlOccurenceTypeId" runat="server" Height="22px" 
                placeholder="Unit" Width="137px">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rptMonthlyAttendenceAbsenceSheet" runat="server" AutoPostBack="true"
                Text="Attendence  Sheet (Monthly) " GroupName="Controls" OnCheckedChanged="rptMonthlyAttendenceAbsenceSheet_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblMonth" runat="server" Text="Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtMonth" runat="server" Width="145px" Height="20px" BackColor="White"
                placeholder="MONTH"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:Label ID="lblApprove" runat="server" Text="Approve Status:"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlApproveId" runat="server" Height="32px" Width="146px">
                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                <asp:ListItem Text="Approved" Value="Y"></asp:ListItem>
                <asp:ListItem Text="Not Approve" Value="N"></asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheet" runat="server" AutoPostBack="true"
                Text="Job Card" GroupName="Controls" OnCheckedChanged="rdoMonthlyAttendenceSheet_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblWorkingHourRange" runat="server" Text="Range(WH):"></asp:Label>
        </td>
        <td style="width: 147px">
            &nbsp;<asp:DropDownList ID="ddlWHRangeId" runat="server" Height="30px" 
                Width="140px">
                <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                <asp:ListItem Text="&lt;40 Hr" Value="1"></asp:ListItem>
                <asp:ListItem Text="41-48" Value="2"></asp:ListItem>
                <asp:ListItem Text="49-60" Value="3"></asp:ListItem>
                <asp:ListItem Text="61-72" Value="4"></asp:ListItem>
                <asp:ListItem Text="73-84" Value="5"></asp:ListItem>
                <asp:ListItem Text="84 Up" Value="6"></asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoDailyAttendenceOpeningSheet" runat="server" AutoPostBack="true"
                Text="Attendence Opening Sheet (Daily) " Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblWorkingDay" runat="server" Text="Working Day:"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtWDay" runat="server" BackColor="White" Width="144px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            <asp:RadioButton ID="rdoAttendanceRegisterNext" runat="server" AutoPostBack="true"
                Text="Next" Font-Bold="False" 
                GroupName="Controls" />
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoDailyAttendenceClosingSheet" runat="server" AutoPostBack="true"
                Text="Attendence Closing Sheet (Daily) " Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeBasicInformation" runat="server" AutoPostBack="true"
                Text="Employee Basic Information" GroupName="Controls" OnCheckedChanged="rdoEmployeeBasicInformation_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
        </td>
        <td style="width: 147px">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />
        </td>
        <td style="width: 79px; text-align: right;">
        </td>
        <td>
        </td>
    </tr>
      <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoInactiveEmployeeSheetMonthly" runat="server" AutoPostBack="true"
                Text="Inactive Sheet(Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
              <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoInactiveEmpProposalSheet" runat="server" AutoPostBack="true"
                Text="Inactive Proposal Sheet(Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoInactiveEmployeeList" runat="server" AutoPostBack="true"
                Text="Inactive Employee List" GroupName="Controls" OnCheckedChanged="rdoInactiveEmployeeList_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoLateSheetSummery" runat="server" AutoPostBack="true" Text="Late Sheet Summery"
                GroupName="Controls" OnCheckedChanged="rdoLateSheetSummery_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
      <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoLateSheet" runat="server" AutoPostBack="true" Text="Late Sheet(D.date Range)"
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoOverTimeAnalysis" runat="server" AutoPostBack="true" Text="OT Analysis(Monthly)"
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
            <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoOverTimeAnalysisbyBetDateRange" runat="server" AutoPostBack="true" Text="OT Analysis(Bet date)"
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
            
     <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoWHBetDateRange" runat="server" AutoPostBack="true" Text="Emp List(Bet WH)"
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoMonthlyWorkingDayList" runat="server" AutoPostBack="true"
                Text="Working Day List (Monthly) " Font-Bold="False" GroupName="Controls" OnCheckedChanged="rdoMonthlyWorkingDayList_CheckedChanged" Visible="false" />
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeStatus" runat="server" AutoPostBack="true"
                Text="Employee Status " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoDisposableSheet" runat="server" AutoPostBack="true"
                Text="Disposable Sheet(Worker) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoDisposableSheetStaff" runat="server" AutoPostBack="true"
                Text="Disposable Sheet(Staff) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoGenderStatusBasedOnSalary" runat="server" AutoPostBack="true"
                Text="Gender Status" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
         
    <tr>
        <td style="width: 256px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
         
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoNewEmployeeList" runat="server" AutoPostBack="true" 
                Font-Bold="False" GroupName="Controls" 
                Text="New Employee List(Joining Basis)" />
            &nbsp; &nbsp; &nbsp; &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
      <tr>
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoNewRecruitmentEmpListBP" runat="server" AutoPostBack="true"
                Text="New Recurit Emp List(BP) " Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 81px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="height: 22px">
            &nbsp;</td>
    </tr>   
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoGetEmpWhoWdayLessThanXDays" runat="server" 
                AutoPostBack="true" Font-Bold="False" GroupName="Controls" 
                Text="Sheet(W.DAY)" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td style="width: 256px;">
            <asp:RadioButton ID="rdoAttendanceRegister" runat="server" AutoPostBack="true"
                Text="Attendance Register" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    
            <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoWorkingHourSummary" runat="server" AutoPostBack="true"
                Text="WH Summary" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoOTSummary" runat="server" AutoPostBack="true"
                Text="OT Summary" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    
    <tr>
        <td style="width: 256px; font-weight: 700;">
            <asp:Label runat="server" ID="lblMessage"></asp:Label>
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    

  </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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
