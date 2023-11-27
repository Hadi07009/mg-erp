<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportPower.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Reports.ReportPower" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkPDF_CheckedChanged"
                                        Font-Bold="True" />
                                    &nbsp;<asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true"
                                        ViewStateMode="Enabled" OnCheckedChanged="chkExcel_CheckedChanged" Font-Bold="True"
                                        CssClass="CheckBox" />
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
                            <tr>
                </td>
            </tr>
        </table>
    </fieldset>
    </td> </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeBasicInformation" runat="server" AutoPostBack="true"
                Text="Employee Basic Information" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId" runat="server" Text="Unit  :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlUnitId" runat="server" Width="148px" Height="22px" placeholder="Unit">
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
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeEducationHistory" runat="server" AutoPostBack="true"
                Text="Employee Education" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId0" runat="server" Text="Section :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlSectionId" runat="server" Width="148px" Height="22px" placeholder="Unit">
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
        <td style="width: 256px">
            <asp:RadioButton ID="rdoEmployeeJobYearMonthHistory" runat="server" AutoPostBack="true"
                Text="Employee Job Year List" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId1" runat="server" Text="Employee ID :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtEmployeeId" runat="server" Width="145px" placeholder="EMPLOYEE ID"
                Height="20px"></asp:TextBox>
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
                Text="Inactive Employee List" GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId2" runat="server" Text="Card No :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtCardNo" runat="server" Width="145px" placeholder="EMPLOYEE ID"
                Height="20px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            &nbsp;</td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId6" runat="server" Text="Year :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtYear" runat="server" Width="145px" BackColor="White" placeholder="YEAR"></asp:TextBox>
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
            &nbsp;</td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId7" runat="server" Text="Month :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtMonth" runat="server" Width="145px" BackColor="White" placeholder="MONTH"></asp:TextBox>
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
            &nbsp;</td>
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
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"  CssClass = "styled-button-4"/>
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
        <td style="width: 256px; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="height: 21px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px; font-weight: 700;">
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
        <td style="width: 256px; font-weight: 700;">
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
