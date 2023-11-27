<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportWorker.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Reports.ReportBasic" %>

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
    <%--<fieldset>
        <legend>Report</legend>--%>
        <table style="width: 100%">
            <tr>
                <td colspan="5">
                   <%-- <fieldset>--%>
                        <%--<legend>REPORT FORMAT TYPE</legend>--%>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                                        CssClass="CheckBox" OnCheckedChanged="chkPDF_CheckedChanged" Font-Bold="True" />
                                    &nbsp;<asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true"
                                        OnCheckedChanged="chkExcel_CheckedChanged" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkWord" runat="server" Text="Word" AutoPostBack="true" OnCheckedChanged="chkWord_CheckedChanged"
                                        Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkText" runat="server" Text="Text" AutoPostBack="true" OnCheckedChanged="chkText_CheckedChanged"
                                        Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;
                                    <asp:CheckBox ID="chkCSV" runat="server" GroupName="Controls" Text="CSV" AutoPostBack="true"
                                        OnCheckedChanged="chkCSV_CheckedChanged" Font-Bold="True" CssClass="CheckBox" />
                                </td>
                            </tr>
                            <%--<tr>--%>
                         </table> 
                </td>
            </tr>
        <%--</table>--%>
  <%--  </fieldset>--%>
   <%-- </td> </tr>--%>

   

    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rptDailyAttendenceSheet" runat="server" AutoPostBack="true"
                Text="Attendence Sheet (Daily) " GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            <%--<asp:Label ID="lblUnitId" runat="server" Text="Unit  :"></asp:Label>--%>
            <asp:Label ID="lblUnitId4" runat="server" Text="Unit Group  :"></asp:Label>
        </td>
        <td style="width: 147px">
            <%--<asp:DropDownList ID="ddlUnitId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>--%>
            <asp:DropDownList ID="ddlUnitGroupId" runat="server" Width="146px" Height="32px">
                  <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                  <asp:ListItem Value="1" Text="Unit Group- 1"></asp:ListItem>
                  <asp:ListItem Value="2" Text="Unit Group- 2"></asp:ListItem>
                  <asp:ListItem Value="3" Text="Unit Group- 3"></asp:ListItem>
                  <asp:ListItem Value="4" Text="Unit Group- 4"></asp:ListItem>
              </asp:DropDownList>

        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId8" runat="server" Text="Employee ID :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmpId" runat="server" Width="145px" placeholder="EMPLOYEE ID "
                Height="22px"></asp:TextBox>
        </td>


        <td style="width: 81px;">
            <asp:Label ID="lbltxtEarlyDepurtureTime" runat="server" Text="Depurture Time"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEarlyDepurtureTime" runat="server" Width="100px" placeholder="Depurture Time" Text="05:00"
                Height="22px"></asp:TextBox>
        </td>

    </tr>
    <tr>
        <td style="width: 309px; height: 21px;">
            <asp:RadioButton ID="rptDailyAttendenceSheetInOut" runat="server" AutoPostBack="true"
                Text="Attendence Sheet(In or Out) (Daily) " GroupName="Controls" 
                 />
        </td>
        <td style="width: 75px; text-align: right; height: 21px;">
            <%--<asp:Label ID="lblUnitId0" runat="server" Text="Section :"></asp:Label>--%>
            <asp:Label ID="lblUnitId" runat="server" Text="Unit  :"></asp:Label>
        </td>
        <td style="width: 147px; height: 21px;">
            <%--<asp:DropDownList ID="ddlSectionId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>--%>
            <asp:DropDownList ID="ddlUnitId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 81px; text-align: right; height: 21px;">
            <asp:Label ID="lblOfficeId9" runat="server" Text="From :"></asp:Label>
        </td>
        <td style="height: 21px">
            <asp:TextBox ID="dtpFromDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="FROM DATE"></asp:TextBox>
        </td>

        <td style="width: 81px;">
            <asp:Label ID="lblEarlyDepurtureLimit" runat="server" Text="Early Dept. Limit"></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlEarlyDepurtureLimit" runat="server" Width="105px" Height="22px">
                <asp:ListItem Value="0" Text="---Select---"></asp:ListItem>
                <asp:ListItem Value="1" Text="One"></asp:ListItem>
                <asp:ListItem Value="2" Text="Two"></asp:ListItem>
                <asp:ListItem Value="3" Text="Three"></asp:ListItem>
                <asp:ListItem Value="4" Text="Four"></asp:ListItem>
                <asp:ListItem Value="5" Text="Five"></asp:ListItem>
                <asp:ListItem Value="6" Text="Six"></asp:ListItem>
                <asp:ListItem Value="7" Text="Seven"></asp:ListItem>
                <asp:ListItem Value="8" Text="Eight"></asp:ListItem>
                <asp:ListItem Value="9" Text="Nine"></asp:ListItem>
                <asp:ListItem Value="10" Text="Ten"></asp:ListItem>
                <asp:ListItem Value="11" Text="Eleven"></asp:ListItem>
                <asp:ListItem Value="12" Text="Twelve"></asp:ListItem>
                <asp:ListItem Value="13" Text="Thirteen"></asp:ListItem>
                <asp:ListItem Value="14" Text="Fourteen"></asp:ListItem>
                <asp:ListItem Value="15" Text="Fifteen"></asp:ListItem>
                <asp:ListItem Value="16" Text="Sixteen"></asp:ListItem>
                <asp:ListItem Value="17" Text="Seventeen"></asp:ListItem>
                <asp:ListItem Value="18" Text="Eighteen"></asp:ListItem>
                <asp:ListItem Value="19" Text="Niteen"></asp:ListItem>
                <asp:ListItem Value="20" Text="Twenty"></asp:ListItem>
                <asp:ListItem Value="21" Text="Twenty One"></asp:ListItem>
                <asp:ListItem Value="22" Text="Twenty Two"></asp:ListItem>
                <asp:ListItem Value="23" Text="Twenty Three"></asp:ListItem>
                <asp:ListItem Value="24" Text="Twenty Four"></asp:ListItem>
                <asp:ListItem Value="25" Text="Twenty Five"></asp:ListItem>
                <asp:ListItem Value="26" Text="Twenty Six"></asp:ListItem>
                <asp:ListItem Value="27" Text="Twenty Seven"></asp:ListItem>
                <asp:ListItem Value="28" Text="Twenty Eight"></asp:ListItem>
                <asp:ListItem Value="29" Text="Twenty Nine"></asp:ListItem>
                <asp:ListItem Value="30" Text="Thirty"></asp:ListItem>
            </asp:DropDownList>
        </td>

    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rptDailyAttendenceLateSheet" runat="server" AutoPostBack="true"
                Text="Attendence Sheet(Late) (Daily) " GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            <%--<asp:Label ID="lblOfficeId6" runat="server" Text="Year :"></asp:Label>--%>
            <asp:Label ID="lblUnitId0" runat="server" Text="Section :"></asp:Label>
        </td>
        <td style="width: 147px">
            <%--<asp:TextBox ID="txtYear" runat="server" Width="145px" BackColor="White" placeholder="YEAR"></asp:TextBox>--%>
            <asp:DropDownList ID="ddlSectionId" runat="server" Height="22px" 
                placeholder="Unit" Width="148px">
            </asp:DropDownList>
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId10" runat="server" Text="To :"></asp:Label>
           
        </td>
        <td>
            <asp:TextBox ID="dtpToDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="TO DATE"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rptDailyAttendenceAbsenceSheet" runat="server" AutoPostBack="true"
                Text="Attendence Absence Sheet (Daily) " GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            <%--<asp:Label ID="lblOfficeId7" runat="server" Text="Month :"></asp:Label>--%>
            <asp:Label ID="lblOfficeId6" runat="server" Text="Year :"></asp:Label>
        </td>
        <td style="width: 147px">
            <%--<asp:TextBox ID="txtMonth" runat="server" Width="145px" BackColor="White" placeholder="MONTH"></asp:TextBox>--%>
            <asp:TextBox ID="txtYear" runat="server" Width="145px" BackColor="White" placeholder="YEAR"></asp:TextBox>
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId11" runat="server" Text="Type :"></asp:Label>
           
        </td>
        <td>
            <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="148px" Height="22px"
                placeholder="Unit">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rptMonthlyAttendenceAbsenceSheet" runat="server" AutoPostBack="true"
                Text="Attendence  Sheet (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            <%--<asp:Label ID="lblUnitId2" runat="server" Text="Card No :"></asp:Label>--%>
            <asp:Label ID="lblOfficeId7" runat="server" Text="Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <%--<asp:TextBox ID="txtCardNo" runat="server" Width="145px" placeholder="CARD NO" Height="20px"></asp:TextBox>--%>
            <asp:TextBox ID="txtMonth" runat="server" Width="145px" BackColor="White" placeholder="MONTH"></asp:TextBox>
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId13" runat="server" Text="Limit Date :"></asp:Label>
           
        </td>
        <td>
            <asp:TextBox ID="dtpLimitDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="LIMIT DATE"></asp:TextBox>
       </td>
    </tr>
    <tr>
        <td style="width: 309px; height: 13px;">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheet" runat="server" AutoPostBack="true"
                Text="Job Card" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 13px;">
            <%--1<asp:Label ID="lblUnitId3" runat="server" Text="Range :"></asp:Label>--%>
            <asp:Label ID="lblUnitId2" runat="server" Text="Card No :"></asp:Label>
        </td>
        <td style="width: 147px; height: 13px;">
            <%--<asp:TextBox ID="txtSalaryRange" runat="server" Width="145px" 
                placeholder="SALARY RANGE" Height="20px"></asp:TextBox>--%>
            <asp:TextBox ID="txtCardNo" runat="server" Width="145px" placeholder="CARD NO" Height="20px"></asp:TextBox>
        </td>
             <td style="text-align: right; width: 81px; height: 13px">
            <asp:Label ID="lblIncrementYn" runat="server" Text="Increment? "></asp:Label>
        </td>
        <td style="height: 13px">
            <asp:CheckBox ID="chkIncrementYn" runat="server"/>
        </td>
        <%--<td style="width: 81px; text-align: right; height: 13px;">
            &nbsp;</td>
        <td style="height: 13px">
            &nbsp;
        </td>--%>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheetSummery" runat="server" AutoPostBack="true"
                Text="Attendence  Summery Sheet (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            <%--<asp:Label ID="lblOfficeId12" runat="server" Text="Eid Name :"></asp:Label>--%>
            <asp:Label ID="lblUnitId3" runat="server" Text="Range :"></asp:Label>
        </td>
        <td style="width: 147px">
            <%--<asp:DropDownList ID="ddlEidTypeId" runat="server" Width="148px" Height="22px" 
                placeholder="Unit">
            </asp:DropDownList>--%>
            <asp:TextBox ID="txtSalaryRange" runat="server" Width="145px" 
                placeholder="SALARY RANGE" Height="20px"></asp:TextBox>
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOccuranceType" runat="server" Text="Occurance Type "></asp:Label>
        </td>
        <td>
            <asp:DropDownList ID="ddlOccurenceTypeId" runat="server" Height="22px" 
                placeholder="Unit" Width="137px">
            </asp:DropDownList>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheetAllWorker" runat="server" AutoPostBack="true"
                Text="Attendence  Sheet  All (Monthly) " GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
           <asp:Label ID="lblOfficeId12" runat="server" Text="Eid Name :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlEidTypeId" runat="server" Width="148px" Height="22px" 
                placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoDailyAttendenceTopSheet" runat="server" AutoPostBack="true"
                Text="Attendence Top Sheet (Daily) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            <%--<asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />--%>
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoAttendencePresentSummerySheet" runat="server" AutoPostBack="true"
                Text="Attendence Present Sheet Summery" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoDailyAttendenceOpeningSheet" runat="server" AutoPostBack="true"
                Text="Attendence Opening Sheet (Daily) " Font-Bold="False" 
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
        <td style="width: 309px">
            <asp:RadioButton ID="rdoDailyAttendenceClosingSheet" runat="server" AutoPostBack="true"
                Text="Attendence Closing Sheet (Daily) " Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
            <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoAllActiveEmployee" runat="server" AutoPostBack="true"
                Text="All Active Employee List " Font-Bold="False" 
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
        <td style="width: 309px">
            <asp:RadioButton ID="rdoBonusProposalForBellow6Month" runat="server" AutoPostBack="true"
                Text="Bonus Proposal Worker(&lt; 6)" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            <asp:RadioButton ID="rdoIncrementProposalAuto" runat="server" AutoPostBack="true"
                Text="Increment Proposal Auto" Font-Bold="False" 
                GroupName="Controls" />
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoBonusProposalForBellow1Year" runat="server" AutoPostBack="true"
                Text="Bonus Proposal Worker(6&gt;=&amp;&amp; &lt;12)" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            <asp:TextBox ID="txtExtraAmount" runat="server" Width="145px" placeholder="SALARY RANGE" Height="20px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoBonusProposalForBellow6MonthForStaff" runat="server" AutoPostBack="true"
                Text="Bonus Proposal Staff(&lt; 6)" Font-Bold="False" 
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
        <td style="width: 309px">
            <asp:RadioButton ID="rdoBonusProposalForStaffBellow1Year" runat="server" AutoPostBack="true"
                Text="Bonus Proposal Staff(6&gt;=&amp;&amp; &lt;12)" Font-Bold="False" 
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
        <td style="width: 309px">
            <asp:RadioButton ID="rdoBonusSheetForWorker12Month" runat="server" AutoPostBack="true"
                Text="Bonus Sheet Worker(11&gt;=&amp;&amp; &lt;12)" Font-Bold="False" 
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
        <td style="width: 309px">
            <asp:RadioButton ID="rdoBonusSheetForStaff12Month" runat="server" AutoPostBack="true"
                Text="Bonus Sheet Staff(11&gt;=&amp;&amp; &lt;12)" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoDesignationList" runat="server" AutoPostBack="true" Text="Designation List"
                Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px">
            <asp:RadioButton ID="rdoEmployeeJobHistory" runat="server" AutoPostBack="true" Text="Employee Job History"
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoEmployeeListHO" runat="server" AutoPostBack="true" Text="Employee Gross, First, Misc Salary List"
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoEmployeeJobYearMonthHistory" runat="server" AutoPostBack="true"
                Text="Employee Job Year List" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoEmployeeJoiningInfo" runat="server" AutoPostBack="true"
                Text="Employee Joining Information" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoEmployeeBasicInformation" runat="server" AutoPostBack="true"
                Text="Employee Basic Information" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoEmployeJoiningResignInfo" runat="server" AutoPostBack="true"
                Text="Employee Joining/Resign Information" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px">
            <asp:RadioButton ID="rdoEmployeeListAboveOneYear" runat="server" AutoPostBack="true"
                Text="Employee List Above One Year" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; height: 15px;">
            <asp:RadioButton ID="rdoEmployeeListBellowOneYear" runat="server" AutoPostBack="true"
                Text="Employee List Bellow One Year" Font-Bold="False" 
                GroupName="Controls" />
        </td>
         
        <td style="width: 75px; text-align: right; height: 15px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 15px;">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right; height: 15px;">
            &nbsp;
        </td>
        <td class="style3">
            &nbsp;
        </td>
    </tr>

     <tr>
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoEmployeeListByGrade" runat="server" AutoPostBack="true" Text=" Employee List ByGrade"
                Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; height: 21px;">
            <asp:RadioButton ID="rdoEmployeeSalaryRange" runat="server" AutoPostBack="true"
                Text="Employee Salary Range" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="height: 21px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoEmployeeInsurenceInfo" runat="server" AutoPostBack="true"
                Text="Employee Insurance Information" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoEmployeeMaleFemaleInfo" runat="server" AutoPostBack="true"
                Text="Employee Gender Information" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalaryApproveSheet" runat="server" AutoPostBack="true"
                Text="Employee Salary Approved List" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoSalaryInfoByGrade" runat="server" AutoPostBack="true"
                Text="Employee Salary Detail By Grade " Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoSalarySummeryInfoByGrade" runat="server" AutoPostBack="true"
                Text="Employee Salary Summery By Grade" Font-Bold="False" 
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
    <%--<tr>
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoGradeAdjustIncrementYearly" runat="server" AutoPostBack="true"
                Text="Grade Adjust &amp; Increment Yearly" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 22px;">
            </td>
        <td style="width: 147px; height: 22px;">
            </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            </td>
        <td style="height: 22px">
            </td>
    </tr>--%>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionFactoryStaffGross" 
                runat="server" AutoPostBack="true"
                Text="Gross Salary Summery For Staff" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionWorkerGross" runat="server" AutoPostBack="true"
                Text="Gross Salary Summery For Worker" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoGradeAdjustIncrementYearly" runat="server" AutoPostBack="true"
                Text="Salary Adjustment According to Gazette" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 22px;">
            </td>
        <td style="width: 147px; height: 22px;">
            </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            </td>
        <td style="height: 22px">
            </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoGradeAdjustIncrementRequisitionYearly" runat="server" AutoPostBack="true"
                Text="Salary Requisition Adjustment According to Gazette" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoSalaryAdjustSumAccordingGazette" runat="server" AutoPostBack="true"
                Text="Salary Adjustment Summary According to Gazette" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyHalfSheetStaff" runat="server" AutoPostBack="true"
                Text="Half Sheet Staff (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>

    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyHalfSheetWorker" runat="server" AutoPostBack="true"
                Text="Half Sheet Worker (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoHalfSalarySheetRequisitionWorker" runat="server" AutoPostBack="true"
                Text="Half Salary Sheet Requisition" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoInactiveEmployeeList" runat="server" AutoPostBack="true"
                Text="Inactive Employee List" GroupName="Controls" Font-Bold="False" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoIncrementProposalWorkerAboveOneYear" runat="server" AutoPostBack="true"
                Text="Increment Proposal Worker(Above 1 Year)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoIncrementProposalWorkerBellowOneYear" runat="server" AutoPostBack="true"
                Text="Increment Proposal Worker(Bellow 1 Year)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoIncrementProposalStaff" runat="server" AutoPostBack="true"
                Text="Increment Proposal Staff" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoIncrementYearlyProposalStaff" runat="server" AutoPostBack="true"
                Text="Increment Proposal Staff Yearly(above 1 year)" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
            <asp:RadioButton ID="rdoIncrementSummeryStatement" runat="server" AutoPostBack="true"
                Text="Increment Statement(One Year)" Font-Bold="False" 
                GroupName="Controls" Visible="False" />
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoIncSummeryStatement" runat="server" AutoPostBack="true"
                Text="Increment Statement (One Year)" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoIncSummeryStatementOneYear" runat="server" AutoPostBack="true"
                Text="Increment Summery Statement(One Year)" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyIncrementList" runat="server" AutoPostBack="true"
                Text="Increment List (Monthly)" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoLateSheetSummery" runat="server" AutoPostBack="true" Text="Late Sheet Summery"
                GroupName="Controls" Font-Bold="False" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoLeaveSheetStaff" runat="server" AutoPostBack="true" Text="Leave Encashment Staff"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoLeaveSheetStaffMisc" runat="server" AutoPostBack="true" Text="Leave Encashment Staff Misc"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoLeaveSheetWorker" runat="server" AutoPostBack="true" Text="Leave Encashment Worker"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoLeaveRequisitionStaff" runat="server" AutoPostBack="true"
                Text="Leave Encashment Staff Requisition" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoLeaveRequisitionWorker" runat="server" AutoPostBack="true"
                Text="Leave Encashment Worker Requisition" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoLeaveRequisitionAll" runat="server" AutoPostBack="true" Text="Leave Encashment Requisition All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyMiscSheetWorker" runat="server" AutoPostBack="true"
                Text="MISC Sheet Worker (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoNewEmployeeList" runat="server" AutoPostBack="true" Text="New Employee List"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
        <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoNewEmpListBeforeSalarySet" runat="server" AutoPostBack="true" 
                Font-Bold="False" GroupName="Controls" 
                Text="New Employee List(Before Salary)"/>
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyOtRequisition" runat="server" AutoPostBack="true"
                Text="OT Requisition (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyOverTimeSheetWorker" runat="server" AutoPostBack="true"
                Text="Over Time Sheet  (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyOverTimeRequisition" runat="server" AutoPostBack="true"
                Text="Over Time Requisition (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyPaySlipStaff" runat="server" AutoPostBack="true" Text="Pay Slip Staff (Monthly) "
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyPaySlipStaffMisc" runat="server" AutoPostBack="true"
                Text="Pay Slip Staff Misc (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyPaySlipWorker" runat="server" AutoPostBack="true"
                Text="Pay Slip Worker (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyRevenueRequisition" runat="server" AutoPostBack="true"
                Text="Revenue Requisition Monthly" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoSalaryHistory" runat="server" Text="Salary history" AutoPostBack="true"
                GroupName="Controls" Font-Bold="False" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoWorkerSalaryRange" runat="server" AutoPostBack="true" Text="Salary Range Information"
                Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoWorkerSalaryRangeSummery" runat="server" 
                AutoPostBack="true" Text="Salary Range Information Summery"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalarySheetStaff" runat="server" AutoPostBack="true"
                Text="Salary Sheet Staff (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalarySheetStaffMisc" runat="server" AutoPostBack="true"
                Text="Salary Sheet Staff Misc (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionFactoryStaff" runat="server" AutoPostBack="true"
                Text="Salary Requisition Staff (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoSalaryRangeInformation" runat="server" AutoPostBack="true"
                Text="Staff First Salary Range Information" Font-Bold="False" 
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyStatementSP" runat="server" AutoPostBack="true"
                Text="Monthly Salary Statement (NEW) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalaryStatement" runat="server" AutoPostBack="true"
                Text="Salary Statement (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoYearlySalaryStatement" runat="server" AutoPostBack="true"
                Text="Salary Statement (Yearly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionFactoryStaffMisc" runat="server"
                AutoPostBack="true" Text="Salary Requisition Staff Misc (Monthly) " Font-Bold="False"
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalarySheetWorker" runat="server" AutoPostBack="true"
                Text="Salary Sheet Worker (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionWorker" runat="server" AutoPostBack="true"
                Text="Salary Requisition Worker (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisition" runat="server" AutoPostBack="true"
                Text="Salary Requisition All (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 22px;">
            </td>
        <td style="width: 147px; height: 22px;">
            </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            </td>
        <td style="height: 22px">
            </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlySalarySummeryWorker" runat="server" AutoPostBack="true"
                Text="Salary Summery Sheet Worker (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700; height: 22px;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionSheetWorker" runat="server" AutoPostBack="true"
                Text="Salary  Sheet Requisition Worker (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 22px;">
            </td>
        <td style="width: 147px; height: 22px;">
            </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            </td>
        <td style="height: 22px">
            </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyTiffinSheetWorker" runat="server" AutoPostBack="true"
                Text="Tiffin Sheet  (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyTiffinSheetWorkerRequisition" runat="server" AutoPostBack="true"
                Text="Tiffin Sheet Requisition (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700; height: 14px;">
            <asp:RadioButton ID="rdoMonthlyTiffinRequisition" runat="server" AutoPostBack="true"
                Text="Tiffin Requisition (Monthly) " Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 75px; text-align: right; height: 14px;">
            </td>
        <td style="width: 147px; height: 14px;">
            </td>
        <td style="width: 81px; text-align: right; height: 14px;">
            </td>
        <td class="style3" style="height: 14px">
            </td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoWorkerTransferSheet" runat="server" AutoPostBack="true" Text="Transfer Sheet"
                Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoTaxSummerySheet" runat="server" AutoPostBack="true"
                Text="Tax Summery Statement(Yearly )" Font-Bold="False" 
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 309px; font-weight: 700;">
            <asp:RadioButton ID="rdoMonthlyWorkingDayList" runat="server" AutoPostBack="true"
                Text="Working Day List (Monthly) " Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 309px; font-weight: 700;">
            &nbsp;</td>
        <td style="width: 75px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
