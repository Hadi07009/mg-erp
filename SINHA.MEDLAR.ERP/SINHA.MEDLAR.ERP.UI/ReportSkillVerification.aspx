<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportSkillVerification.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportSkillVerification" %>

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
                            <tr>
                </td>
            </tr>
        </table>
    </fieldset>
    </td> </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProcessInformation" runat="server" AutoPostBack="true" Text="Process Info"
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId" runat="server" Text="Line :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlLineId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProductionDefect" runat="server" AutoPostBack="true" Text="Production Defect"
                GroupName="Controls" />
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId0" runat="server" Text="From Date :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="dtpFromDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="FROM DATE"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProductionDefectVerificationSummery" runat="server" AutoPostBack="true"
                Text="Production Range Verification Summery Line Wise" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId1" runat="server" Text="To Date :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="dtpToDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="TO DATE"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProductionEfficiencySummery" runat="server" AutoPostBack="true"
                Text="Production Verification Summery Line Wise" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId5" runat="server" Text="Manual Percent :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtTargetQuantityPercent" runat="server" Width="145px" placeholder="TARGET QTY"
                Height="20px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:Label ID="lblUnitId4" runat="server" Text="(%)"></asp:Label>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProductionEfficiency" runat="server" AutoPostBack="true"
                Text="Production Efficiency Verification " GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId6" runat="server" Text="Working Day :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtTotalWorkingDay" runat="server" Width="145px" placeholder="WORKING DAY"
                Height="20px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProductionEfficiencyDetail" runat="server" AutoPostBack="true"
                Text="Production Efficiency Verification  By Input" GroupName="Controls" 
                oncheckedchanged="rdoProductionEfficiencyDetail_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId7" runat="server" Text="Avg.  MPower :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtAverageManpower" runat="server" Width="145px" placeholder="AVG. MANPOWER"
                Height="20px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProductionEfficiencySummerByUnit" runat="server" AutoPostBack="true"
                Text="Production Verification Summery By Unit Wise" GroupName="Controls" 
                oncheckedchanged="rdoProductionEfficiencyDetail_CheckedChanged" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId2" runat="server" Text="Card No :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtCardNo" runat="server" Width="145px" placeholder="CARD NO" Height="20px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoProductionDefectVerificationSummeryByUnitWise" 
                runat="server" AutoPostBack="true"
                Text="Production Range Verification Summery By Unit Wise" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId3" runat="server" Text="Employee ID :" Visible="False"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtEmployeeId" runat="server" Width="145px" placeholder="EMPLOYEE ID"
                Height="20px" Visible="False"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoSkillMatrix" 
                runat="server" AutoPostBack="true"
                Text="Skill Matrix Bottom" 
                GroupName="Controls" />
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId8" runat="server" Text="Hour :" Visible="False"></asp:Label>
        </td>
        <td style="width: 147px">
            &nbsp;<asp:TextBox ID="txtHour" runat="server" Width="145px" placeholder="EMPLOYEE ID"
                Height="20px" Visible="False"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoSkillMatrixTop" 
                runat="server" AutoPostBack="true"
                Text="Skill Matrix Top" 
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
        <td style="width: 279px">
            <asp:RadioButton ID="rdoSweingDefectSheet" 
                runat="server" AutoPostBack="true"
                Text="Sweing Defect Sheet" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />
            </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 279px">
            <asp:RadioButton ID="rdoSewingDefectEntryMonthly" 
                runat="server" AutoPostBack="true"
                Text="Monthly Sweing Defect Sheet" 
                GroupName="Controls" />
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
        <td style="width: 279px">
            <asp:RadioButton ID="rdoSewingDefectEntryDaily" 
                runat="server" AutoPostBack="true"
                Text="Sewing Defect Entry Daily" 
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
        <td style="width: 279px">
            <asp:RadioButton ID="rdoFinishingDefectEntry" 
                runat="server" AutoPostBack="true"
                Text="Monthly Finishing Defect Sheet" 
                GroupName="Controls" />
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
        <td style="width: 279px">
            &nbsp;</td>
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
        <td style="width: 279px; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 21px;">
            &nbsp;&nbsp;
        </td>
        <td style="width: 79px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="height: 21px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 279px; font-weight: 700;">
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
        <td style="width: 279px; font-weight: 700;">
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
