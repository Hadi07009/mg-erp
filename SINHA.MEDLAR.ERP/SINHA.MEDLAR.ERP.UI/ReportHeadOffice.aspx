<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportHeadOffice.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportHeadOffice" %>

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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <%--</fieldset>--%>
    <fieldset>
        <legend>Report</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="5">
                    <%--<fieldset>
                        <legend>REPORT FORMAT TYPE</legend>--%>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkPDF_CheckedChanged"
                                        Font-Bold="True" />
                                    &nbsp;<asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true"
                                        OnCheckedChanged="chkExcel_CheckedChanged" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkWord" runat="server" Text="Word" AutoPostBack="true" OnCheckedChanged="chkWord_CheckedChanged"
                                        ViewStateMode="Enabled" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkText" runat="server" Text="Text" AutoPostBack="true" OnCheckedChanged="chkText_CheckedChanged"
                                        ViewStateMode="Enabled" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;
                                    <asp:CheckBox ID="chkCSV" runat="server" GroupName="Controls" Text="CSV" AutoPostBack="true"
                                        ViewStateMode="Enabled" OnCheckedChanged="chkCSV_CheckedChanged" Font-Bold="True"
                                        CssClass="CheckBox" />
                                </td>
                            </tr>
                           <%-- <tr>--%>
                <%--</td>--%>
           <%-- </tr>--%>
        </table>
                    </td></tr>
    <%--</fieldset>--%>
   <%-- </td> --%>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyAATInformation" runat="server" AutoPostBack="true"
                Text=" [1] Advance Arrear Tax Sheet(Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 81px;">
            <asp:Label ID="lbltxtEarlyDepurtureTime" runat="server" Text="Depurture Time"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEarlyDepurtureTime" runat="server" Width="100px" placeholder="Depurture Time" Text="05:00"
                Height="22px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyAdvanceInformation" runat="server" AutoPostBack="true"
                Text=" [2] Advance Sheet(Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            <asp:Label ID="lblUnitId0" runat="server" Text="Section :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlSectionId" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 59px; text-align: right;">
            <asp:Label ID="lblOfficeId9" runat="server" Text="From :"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="dtpFromDate" runat="server" Width="144px" BackColor="White" placeholder="FROM DATE"
                CssClass="date"></asp:TextBox>
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
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoArrearRequisition" runat="server" AutoPostBack="true" Text=" [3] Arrear Requisition"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            <asp:Label ID="lblOfficeId6" runat="server" Text="Year :"></asp:Label>
        </td>
        <td style="width: 147px; height: 22px;">
            <asp:TextBox ID="txtYear" runat="server" Width="144px" BackColor="White" placeholder="YEAR"></asp:TextBox>
        </td>
        <td style="width: 59px; text-align: right; height: 22px;">
            <asp:Label ID="lblOfficeId10" runat="server" Text="To :"></asp:Label>
            &nbsp;&nbsp;
        </td>
        <td style="height: 22px">
            <asp:TextBox ID="dtpToDate" runat="server" Width="144px" BackColor="White" placeholder="TO DATE"
                CssClass="date"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoArrearSheetAll" runat="server" AutoPostBack="true" Text=" [4] Arrear Sheet All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            <asp:Label ID="lblOfficeId7" runat="server" Text="Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtMonth" runat="server" Width="144px" BackColor="White" placeholder="MONTH"></asp:TextBox>
        </td>
        <td style="width: 59px; text-align: right;">
            <asp:Label ID="lblOfficeId11" runat="server" Text="Card No :"></asp:Label>
            &nbsp;
        </td>
        <td>
            <asp:TextBox ID="txtCardNo" runat="server" Width="144px" BackColor="White" placeholder="CARD NO"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyArrearInformation" runat="server" AutoPostBack="true"
                Text="  [5] Arrear Sheet(Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            <asp:Label ID="lblFromMonth" runat="server" Text="From Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlFromMonthId" runat="server" Width="148px" Height="22px"
                placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoArrearSheetHOSeniorStaffPayslip" runat="server" AutoPostBack="true"
                Text=" [6] Arrear Pay Slip(HO Senior Staffs)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoArrearSlipAll" runat="server" AutoPostBack="true" Text=" [7] Arrear Slip All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            <asp:Label ID="lblToMonth0" runat="server" Text="Eid Name :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlEidTypeId" runat="server" Width="148px" Height="22px">
            </asp:DropDownList>
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoArrearSheetFactorySrStaffs" runat="server" AutoPostBack="true"
                Text=" [8] Arrear Slip(Factory Senior Staffs)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            </td>
        <td style="width: 147px; height: 22px;">
            </td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoArrearSheetNormal" runat="server" AutoPostBack="true" Text=" [9] Arrear Sheet Normal"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />
            </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoArrearSlip" runat="server" AutoPostBack="true" Text=" [10] Arrear Slip Normal"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            </td>
        <td style="width: 59px; text-align: right; height: 22px;">
            </td>
        <td style="height: 22px">
            </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoArrearSheetHOSeniorStaff" runat="server" AutoPostBack="true"
                Text=" [11] Arrear Sheet(HO Senior Staffs)" Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoArrearSheetHOFactoryStaff" runat="server" AutoPostBack="true"
                Text=" [12] Arrear Sheet(Factory Senior Staffs)" Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoEmployeeLateSheet" runat="server" AutoPostBack="true"
                Text=" [13] Attendence Late Sheet" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheetAll" runat="server" AutoPostBack="true"
                Text=" [14] Attendence  Sheet All(Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px; height: 16px;">
            <asp:RadioButton ID="rptDailyAttendenceSheet" runat="server" 
                AutoPostBack="true" Text=" [15] Attendence Sheet"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 16px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 16px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 16px;">
            &nbsp;
        </td>
        <td style="height: 16px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheet" runat="server" AutoPostBack="true"
                Text=" [16] Job Card" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyAttendenceSheetSummery" runat="server" AutoPostBack="true"
                Text=" [17] Attendence  Summery Sheet(Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoAttendencePresentSummerySheet" runat="server" AutoPostBack="true"
                Text=" [18] Attendence Present Sheet Summary" Font-Bold="False" 
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMontlyBankSalaryList" runat="server" Text=" [19] Bank Salary(Monthly)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
    <%--BONUS CASH DIRECTOR--%>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoBonusCashSheetDirector" runat="server" AutoPostBack="true" Text="  [20] Bonus Cash Sheet Director"
                GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoBonusCashSheet" runat="server" AutoPostBack="true" Text=" [21] Bonus Cash Sheet"
                GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoBonusMiscellaneousSheet" runat="server" 
                AutoPostBack="true" Text=" [22] Bonus Miscellaneous Sheet"
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 22px;">
        </td>
        <td style="height: 22px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusRequisitionMAL" runat="server" Text=" [23] Bonus Requisition (HO MAL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusRequisitionHOMISCMAL" runat="server" Text=" [24] Bonus Requisition (HO MISC MAL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusRequisitionSFL" runat="server" Text=" [25] Bonus Requisition (HO SFL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusRequisitionHOMISCSFL" runat="server" Text="  [26] Bonus Requisition (HO MISC SFL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusCashRequisitionDirectorMAL" runat="server" Text=" [27] Bonus Requisition Cash Director"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusCashRequisitionMAL" runat="server" Text=" [28] Bonus Requisition Cash MAL"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusCashRequisitionSFL" runat="server" Text=" [29] Bonus Requisition Cash SFL"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoBonusSheetHOByBank" runat="server" AutoPostBack="true" Text=" [30] Bonus Sheet HO Accoding to Bank"
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px; font-weight: 700;">
            <asp:RadioButton ID="rdoDesignationList" runat="server" AutoPostBack="true" Text=" [31] Designation List"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoEmployeeBasicInformation" runat="server" AutoPostBack="true"
                Text=" [32] Employee Basic Information" GroupName="Controls" ViewStateMode="Enabled" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td class="stackedTabTitle" style="height: 21px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px;  height: 20px;">
            <asp:RadioButton ID="rdoEmployeeDetailInformation" runat="server" AutoPostBack="true"
                Text=" [33] Employee Detail Information" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 20px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 20px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 20px;">
            &nbsp;
        </td>
        <td class="stackedTabTitle">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px;  height: 22px;">
            <asp:RadioButton ID="rdoEmployeeListHO" runat="server" AutoPostBack="true" Text=" [34] Employee Gross, First, Misc Salary List"
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 22px;">
            </td>
        <td class="stackedTabTitle" style="height: 22px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 268px; font-weight: 700; height: 17px;">
            <asp:RadioButton ID="rdoEmployeJobConfiramtionSheet" runat="server" 
                AutoPostBack="true" Text=" [35] Employe Job Confiramtion Sheet"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 17px;">
            &nbsp;</td>
        <td style="width: 147px; height: 17px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 17px;">
            </td>
        <td style="height: 17px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 268px; font-weight: 700;">
            <asp:RadioButton ID="rdoEmployeeJoiningInfo" runat="server" AutoPostBack="true"
                Text=" [36] Employee Joining Information" Font-Bold="False" 
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
        <td style="width: 268px; font-weight: 700;">
            <asp:RadioButton ID="rdoEmployeJoiningResignInfo" runat="server" AutoPostBack="true"
                Text=" [37] Employee Joining/Resign Information" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px;  height: 22px;">
            <asp:RadioButton ID="rdoEmployeeJobYearMonthHistory" runat="server" AutoPostBack="true"
                Text=" [38] Employee Job Year List" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td class="stackedTabTitle" style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoEmployeeJobHistory" runat="server" AutoPostBack="true" Text=" [39] Employee Job History"
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td class="stackedTabTitle" style="height: 22px">
            &nbsp;
        </td>
    </tr>
      <tr>
       <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoEmployeeJobHistoryOverall" runat="server" AutoPostBack="true" Text=" [40] Employee Job History(Overall)"
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td class="stackedTabTitle" style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoHalfSalarySheetByBank" runat="server" Text=" [41] Half Salary Sheet According to Bank"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td class="stackedTabTitle" style="height: 22px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoHalfCashSalaryRequisition" runat="server" Text=" [42] Half Salary Cash Requisition"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td class="stackedTabTitle" style="height: 22px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoHalfSalaryRequisitionMAL" runat="server" Text=" [43] Half Salary Requisition (HO MAL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoHalfSalaryRequisitionSFL" runat="server" Text=" [44] Half Salary Requisition (HO SFL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoHalfSalaryRequisitionHOMISCMAL" runat="server" Text=" [45] Half Salary Requisition (HO MISC MAL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoHalfSalaryRequisitionHOMISCSFL" runat="server" Text=" [46] Half Salary Requisition (HO MISC SFL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoInactiveEmployeeList" runat="server" AutoPostBack="true"
                Text=" [47] Inactive Employee List" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSheetHOSeniorStaffPayslip" runat="server" AutoPostBack="true"
                Text=" [48] Increment Pay Slip(HO Senior Staffs)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementProposalAll" runat="server" 
                AutoPostBack="true" Text=" [49] Increment Proposal All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSummaryAll" runat="server" 
                AutoPostBack="true" Text=" [50] Increment Summery All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementHistory" runat="server" 
                AutoPostBack="true" Text=" [51] Increment History"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 59px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>

    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementProposalHOAboveOneYear" runat="server" AutoPostBack="true"
                Text=" [52] Increment Proposal HO(Above 1 Year)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementProposalHOBellowOneYear" runat="server" AutoPostBack="true"
                Text=" [53] Increment Proposal HO(Bellow 1 Year)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left;">
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
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoIncrementSheetAll" runat="server" AutoPostBack="true" Text=" [54] Increment Sheet All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: left; height: 22px;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSheetFactorySeniorStaff" runat="server" AutoPostBack="true"
                Text=" [55] Increment Sheet(Factory Senior Staff)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSheetFactoryStaffIncrementPaySlip" runat="server"
                AutoPostBack="true" Text=" [56] Increment Slip(Factory Senior Staffs)" Font-Bold="False"
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSheetHOSeniorStaff" runat="server" AutoPostBack="true"
                Text=" [57] Increment Sheet  (HO Senior Staffs)" Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSheet" runat="server" AutoPostBack="true" Text=" [58] Increment Sheet Normal"
                Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSlipAll" runat="server" AutoPostBack="true" Text=" [59] Increment Slip All"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementSlipNormal" runat="server" AutoPostBack="true" Text=" [60] Increment Slip Normal"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyBankCashStatement" runat="server" AutoPostBack="true"
                Text=" [61] Miscellaneous Sheet(Monthly)" Font-Bold="False" GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoNewEmployeeList" runat="server" AutoPostBack="true" Text=" [62] New Employee List"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOMISCPaySlip" runat="server" AutoPostBack="true"
                Text=" [63] Pay Slip HO Misc All(Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOMISCPaySlipSR" runat="server" AutoPostBack="true"
                Text=" [64] Pay Slip HO MISC(HO Sr Staffs Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOMISCPaySlipFactSR" runat="server" AutoPostBack="true"
                Text=" [65] Pay Slip HO MISC(Fact Sr Staffs Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
            <%--<asp:RadioButton ID="rdoIncrementProposalHO" runat="server" AutoPostBack="true" Text="Increment Proposal HO [66]"
                Font-Bold="False" GroupName="Controls" Visible="False" />--%>
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOMISCPaySlipNormal" runat="server" AutoPostBack="true"
                Text=" [66] Pay Slip HO Misc (Monthly Normal)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
            <%--<asp:RadioButton ID="rdoIncrementProposal" runat="server" AutoPostBack="true" Text="Increment Proposal [67]"
                Font-Bold="False" GroupName="Controls" Visible="False" />--%>
        </td>
        <td style="width: 59px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>

    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoSalaryCertificate" runat="server" AutoPostBack="true" Text=" [67] Salary Certificate"
                Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoSalaryCertificateList" runat="server" AutoPostBack="true"
                Text=" [68] Salary Certificate List" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoSalaryHistory" runat="server" Text=" [69] Salary history" AutoPostBack="true"
                GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
        </td>
        <td style="width: 147px; height: 22px;">
        </td>
        <td style="width: 59px; text-align: right; height: 22px;">
        </td>
        <td style="height: 22px">
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalaryCheckPaySlip" runat="server" Text=" [70] Salary Pay Slip(Monthly Cash)"
                AutoPostBack="true" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOPaySlip" runat="server" AutoPostBack="true"
                Text=" [71] Salary Pay Slip HO All(Monthly)" Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px; ">
            <asp:RadioButton ID="rdoMonthlySalaryPaySlipHONormal" runat="server" AutoPostBack="true"
                Text=" [72] Salary Pay Slip HO(Monthly Normal)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; ">
            &nbsp;
        </td>
        <td style="width: 147px; ">
            &nbsp;
        </td>
        <td style="width: 59px; text-align: right; ">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySlipHOSrStafss" runat="server" AutoPostBack="true"
                Text=" [73] Salary Pay Slip HO(Monthly HO Sr Staffs)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyCashRequisitionDetail" runat="server" Text=" [74] Salary Requisition Cash Detail(Monthly)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px; height: 22px;">
            <asp:RadioButton ID="rdoMonthlyCashRequisitionSFL" runat="server" Text=" [75] Salary Requisition Cash SFL(Monthly)"
                AutoPostBack="true" GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 147px; height: 22px;">
            &nbsp;</td>
        <td style="width: 59px; text-align: right; height: 22px;">
        </td>
        <td style="height: 22px">
        </td>
    </tr>
    <tr>
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyCashRequisitionMAL" runat="server" Text=" [75] Salary Requisition Cash MAL(Monthly)"
                AutoPostBack="true" GroupName="Controls" Visible="false" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionSFL" runat="server" Text=" [76] Salary Requisition (Monthly HO SFL)"
                AutoPostBack="true" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionMAL" runat="server" Text=" [77] Salary Requisition (Monthly HO MAL)"
                AutoPostBack="true" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionHOMISCSFL" runat="server" Text=" [78] Salary Requisition (Monthly HO MISC SFL)"
                AutoPostBack="true" GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionHOMISCMAL" runat="server" Text=" [79] Salary Requisition (Monthly HO MISC MAL)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionHODetail" runat="server" Text=" [80] Salary Requisition (Monthly HO Detail)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalaryRequisitionHOMISCDetail" runat="server" Text=" [81] Salary Requisition HO MISC Detail(Monthly)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px; height: 21px;">
            <asp:RadioButton ID="rdoMonthlySalaryCheckSheet" runat="server" Text=" [82] Salary Sheet(Monthly  Cash)"
                AutoPostBack="true" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right; height: 21px;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOSrStaffs" runat="server" AutoPostBack="true"
                Text=" [83] Salary Sheet HO(Monthly HO Sr Staffs)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHONormal" runat="server" AutoPostBack="true"
                Text=" [84] Salary Sheet HO(Monthly Normal)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOFactSrStafss" runat="server" AutoPostBack="true"
                Text=" [85] Salary Sheet HO(Monthly HO Fact Sr Staffs)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOByBank" runat="server" AutoPostBack="true"
                Text=" [86] Salary Sheet HO Accoding to Bank(Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHO" runat="server" AutoPostBack="true"
                Text=" [87] Salary Sheet HO All(Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOSRMISC" runat="server" AutoPostBack="true"
                Text=" [88] Salary Sheet HO MISC(HO Sr Staffs Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOFactSRMISC" runat="server" AutoPostBack="true"
                Text=" [89] Salary Sheet HO Misc (Fact Sr Staffs Monthly)" GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOMISC" runat="server" AutoPostBack="true"
                Text=" [90] Salary Sheet HO MISC All(Monthly)" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySheetHOFactSRMISCNormal" runat="server" AutoPostBack="true"
                Text=" [91] Salary Sheet HO MISC (Monthly Normal)" GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalarySlipHoFactSr" runat="server" AutoPostBack="true"
                Text=" [92] Salary Slip HO(Monthly HO Fact Sr Staffs)" GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlySalaryStatement" runat="server" AutoPostBack="true"
                Text=" [93] Salary Statement(Monthly)" Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoYearlySalaryStatement" runat="server" AutoPostBack="true"
                Text=" [94] Salary Statement(Yearly)" Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoSalarySummery" runat="server" AutoPostBack="true" Text=" [95] Salary Summary"
                Font-Bold="False" GroupName="Controls"  />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoMonthlyTaxInformation" runat="server" AutoPostBack="true"
                Text=" [96] Tax Sheet(Monthly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoTaxStatement" runat="server" AutoPostBack="true"
                Text=" [97] Tax Sheet Detail" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoTaxSummerySheetDetail" runat="server" AutoPostBack="true"
                Text=" [98] Tax Statement(Yearly)" Font-Bold="False" GroupName="Controls" />
        </td>
        <td style="width: 151px; text-align: right;">
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoTaxSummerySheet" runat="server" AutoPostBack="true"
                Text=" [99] Tax Summery Statement(Yearly )" Font-Bold="False" 
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoTaxSummerySheetFirstSalary" runat="server" AutoPostBack="true"
                Text=" [100] Tax And Salary Summery Statement" Font-Bold="False" 
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoTiffinRequisition" runat="server" AutoPostBack="true" Text=" [101] Tiffin Requisition"
                Font-Bold="False" GroupName="Controls" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementProposalHO" runat="server" AutoPostBack="true" Text=" [102] Increment Proposal HO"
                Font-Bold="False" GroupName="Controls" Visible="False" />
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
        <td style="width: 268px">
            <asp:RadioButton ID="rdoIncrementProposal" runat="server" AutoPostBack="true" Text=" [103] Increment Proposal"
                Font-Bold="False" GroupName="Controls" Visible="False" />  
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
        <td style="width: 268px">
            &nbsp;</td>
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
        <td style="width: 268px">
            &nbsp;</td>
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
        <td style="width: 268px">
            &nbsp;</td>
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
        <td style="width: 268px">
            &nbsp;</td>
        <td style="width: 151px; text-align: right;">
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
