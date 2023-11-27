<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportMaintenanceStore.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportMaintenanceStore" %>

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
            <asp:RadioButton ID="rdoMaintenancePartsReceive" 
                runat="server" AutoPostBack="true"
                Text="Parts Receive List" 
                GroupName="Controls" />
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblUnitId" runat="server" Text="Department :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlDepartmentId" runat="server" Width="148px" 
                Height="22px" placeholder="Unit">
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
            &nbsp;</td>
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
            &nbsp;</td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="Label1" runat="server" Text="M.R No :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="txtMrNo" runat="server" Width="145px"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
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
            &nbsp;<asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />
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
