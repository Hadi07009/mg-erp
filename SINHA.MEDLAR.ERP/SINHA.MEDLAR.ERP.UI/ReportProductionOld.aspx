<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportProductionOld.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Report" %>

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
                <td colspan="4">
                    <fieldset>
                        <legend>REPORT FORMAT TYPE</legend>
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
                            <tr>
                </td>
            </tr>
        </table>
    </fieldset>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoPOEntryInformation" runat="server" AutoPostBack="true" Text="PO Entry Information"
                GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
            <asp:Label ID="Label1" runat="server" Text="From Date :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="dtpFromDate" runat="server" BackColor="White" CssClass="date" placeholder="FROM DATE"
                Width="145px"></asp:TextBox>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoPOAssignInformation" runat="server" AutoPostBack="true" Text="PO Assign Information"
                GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
            <asp:Label ID="Label2" runat="server" Text="To Date :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="dtoToDate" runat="server" BackColor="White" CssClass="date" placeholder="TO DATE"
                Width="145px"></asp:TextBox>
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoShipmentInformation" runat="server" AutoPostBack="true" Text="Shipment Information"
                GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
            <asp:Label ID="Label3" runat="server" Text="Buyer Name :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlBuyerId" runat="server" Width="148px" Height="20px" AutoPostBack="false">
            </asp:DropDownList>
        </td>
        <td>
            &nbsp; .
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoProductionReport" runat="server" AutoPostBack="true" Text="Production Report "
                GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right; height: 22px;">
            <asp:Label ID="Label4" runat="server" Text="PO No :"></asp:Label>
        </td>
        <td style="width: 147px; height: 22px;">
            <asp:TextBox ID="txtPONo" runat="server" BackColor="White" Width="145px"></asp:TextBox>
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoDailyProductionReportSummery" runat="server" AutoPostBack="true"
                Text="Production Report  Summery" GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            &nbsp;
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoPurchaseOrder" runat="server" AutoPostBack="true" Text="Contact Sheet"
                GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right; height: 22px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 22px;">
            <asp:Button ID="btnView" runat="server" Height="33px" OnClick="btnView_Click" Text="View"
                CssClass="styled-button-4" Width="87px" />
            &nbsp;
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoProductionReportSummery" runat="server" AutoPostBack="true"
                Text="Production Report Summery" GroupName="Controls" Visible="False" />
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoProductionReportByBuyer" runat="server" AutoPostBack="true"
                Text="Buyer Wise Production Report" GroupName="Controls" Visible="False" />
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
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
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
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
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
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
