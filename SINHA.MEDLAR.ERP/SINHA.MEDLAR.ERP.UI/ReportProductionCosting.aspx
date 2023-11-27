<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportProductionCosting.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportProductionCosting" %>

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
                <td colspan="6">
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
        <td style="width: 156px">
            <asp:RadioButton ID="rdoContractSheet" runat="server"
                AutoPostBack="true" Text="Contract Sheet"
                Font-Bold="False" GroupName="Controls"
                OnCheckedChanged="rdoAttendenceSheet_CheckedChanged" />
        </td>
        <td style="width: 107px; text-align: right;">
            <asp:Label ID="lblOfficeId16" runat="server" Text="Year :"></asp:Label>
        </td>
        <td style="width: 235px">
            <asp:TextBox ID="txtYear" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="Issue DATE"></asp:TextBox>

        </td>
        <td style="width: 117px; text-align: right;">
            <asp:Label ID="lblOfficeId11" runat="server" Text="PO No :"></asp:Label>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:DropDownList ID="ddlPOId" runat="server" Width="156px"
                Height="23px" >
            </asp:DropDownList>

            </td>
        <td>

            <asp:Button ID="btnSearchStyleId" runat="server" Height="22px" Text="..."
                Width="30px" CssClass="styled-button-4" OnClick="btnSearchStyleId_Click" />

        </td>
    </tr>
    <tr>
        <td style="width: 156px">
            <asp:RadioButton ID="rdoCostingSheet" runat="server"
                AutoPostBack="true" Text="Costing Sheet"
                Font-Bold="False" GroupName="Controls"
                OnCheckedChanged="rdoAttendenceSheet_CheckedChanged" />
        </td>
        <td style="width: 107px; text-align: right;">
            <asp:Label ID="lblOfficeId13" runat="server" Text="Buyer :"></asp:Label>
        </td>
        <td style="width: 235px">
            <asp:DropDownList ID="ddlBuyerId" runat="server" AutoPostBack="false"
                Width="156px"
                Height="23px" OnSelectedIndexChanged="ddlBuyerId_SelectedIndexChanged"
              >
            </asp:DropDownList> 

            <asp:Button ID="btnSearchContractId" runat="server" Height="22px" Text="..."
                Width="30px" CssClass="styled-button-4" 
                OnClick="btnSearchContractId_Click" />

        </td>
        <td style="width: 117px; text-align: right;">
            <asp:Label ID="lblOfficeId12" runat="server" Text="Style No :"></asp:Label>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:DropDownList ID="ddlStyleId" runat="server" Width="156px" 
                Height="23px" >
            </asp:DropDownList>

            </td>
        <td>

            <asp:Button ID="btnSearchAll" runat="server" Height="22px" Text="..."
                Width="30px" CssClass="styled-button-4" OnClick="btnSearchAll_Click" />

        </td>
    </tr>
    <tr>
        <td style="width: 156px">
            <asp:RadioButton ID="rdoCostSheet" runat="server"
                AutoPostBack="true" Text="Budget"
                Font-Bold="False" GroupName="Controls"
                OnCheckedChanged="rdoAttendenceSheet_CheckedChanged" />
        </td>
        <td style="width: 107px; text-align: right;">
            <asp:Label ID="lblUnitId" runat="server" Text="Contract No :"></asp:Label>
        </td>
        <td style="width: 235px">
                                    <asp:DropDownList ID="ddlContractId" runat="server" 
                Width="156px" AutoPostBack="true"
                                        Height="23px" 
                OnSelectedIndexChanged="ddlContractId_SelectedIndexChanged" >
                                    </asp:DropDownList>

            <asp:Button ID="btnSearchPOId" runat="server" Height="22px" Text="..."
                Width="30px" CssClass="styled-button-4" OnClick="btnSearchPOId_Click"  />

        </td>
        <td style="width: 117px; text-align: right;">
            <asp:Label ID="lblOfficeId15" runat="server" Text="Season :"></asp:Label>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:DropDownList ID="ddlSeasonId" runat="server" Width="156px" Height="23px" AutoPostBack="false">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px">
            &nbsp;</td>
        <td style="width: 107px; text-align: right;">
            <asp:Label ID="lblOfficeId9" runat="server" Text="Issue Date :"></asp:Label>
        </td>
        <td style="width: 235px">
            <asp:TextBox ID="dtpIssueDate" runat="server" Width="145px" BackColor="White" CssClass="date"
                placeholder="Issue DATE"></asp:TextBox>
        </td>
        <td style="width: 117px; text-align: right;">
            <asp:Label ID="lblOfficeId10" runat="server" Text="Amendment Date :"></asp:Label>
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:TextBox ID="dtpAmendmentDate" runat="server" Width="150px"
                BackColor="White" CssClass="date"
                placeholder="Amendment DATE"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px">
            &nbsp;</td>
        <td style="width: 107px; text-align: right;">
                                <asp:Label ID="Label66" runat="server" Text="Amendment No :"></asp:Label>
        </td>
        <td style="width: 235px">
                                <asp:DropDownList ID="ddlAmendmentId" runat="server" Height="22px"
                                    Width="152px" 
                                  >
                                </asp:DropDownList>
        </td>
        <td style="width: 117px; text-align: right;">
            <asp:Label ID="lblOfficeId14" runat="server" Text="FOB Date :"></asp:Label>
        </td>
        <td style="width: 79px; text-align: right;">
            <asp:TextBox ID="dtpFOBDate" runat="server" Width="150px" BackColor="Yellow" Font-Bold="False" palceholder="FOB DATE"
                CssClass="date" ForeColor="Black"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px; height: 15px;"></td>
        <td style="width: 107px; text-align: right; height: 15px;">
            </td>
        <td style="width: 235px; height: 15px;">
            </td>
        <td style="width: 117px; text-align: right; height: 15px;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right; height: 15px;"></td>
        <td class="style3">&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px; height: 22px;"></td>
        <td style="width: 107px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 235px; height: 22px;">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"
                CssClass="styled-button-4" />

        </td>
        <td style="width: 117px; text-align: right; height: 22px;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right; height: 22px;">&nbsp;</td>
        <td style="height: 22px">&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px; height: 22px;"></td>
        <td style="width: 107px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 235px; height: 22px;">
            &nbsp;</td>
        <td style="width: 117px; text-align: right; height: 22px;"></td>
        <td style="width: 79px; text-align: right; height: 22px;">&nbsp;</td>
        <td style="height: 22px"></td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 107px; text-align: right;">
            &nbsp;</td>
        <td style="width: 235px">
            &nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;</td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 107px; text-align: right;">
            &nbsp;</td>
        <td style="width: 235px">
            &nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;</td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 107px; text-align: right;">&nbsp;</td>
        <td style="width: 235px">&nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;</td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 107px; text-align: right;">&nbsp;</td>
        <td style="width: 235px">&nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;</td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;</td>
        <td style="width: 107px; text-align: right;">&nbsp;</td>
        <td style="width: 235px">
            &nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;</td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;
        </td>
        <td style="width: 107px; text-align: right;">&nbsp;</td>
        <td style="width: 235px">&nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;
        </td>
        <td style="width: 107px; text-align: right;">&nbsp;</td>
        <td style="width: 235px">&nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;
        </td>
        <td style="width: 107px; text-align: right;">&nbsp;
        </td>
        <td style="width: 235px">&nbsp;</td>
        <td style="width: 117px; text-align: right;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px">&nbsp;
        </td>
        <td style="width: 107px; text-align: right;">&nbsp;
        </td>
        <td style="width: 235px">&nbsp;
        </td>
        <td style="width: 117px; text-align: right;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px; height: 21px;">&nbsp;
        </td>
        <td style="width: 107px; text-align: right; height: 21px;">&nbsp;
        </td>
        <td style="width: 235px; height: 21px;">&nbsp;&nbsp;
        </td>
        <td style="width: 117px; text-align: right; height: 21px;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right; height: 21px;">&nbsp;</td>
        <td style="height: 21px">&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px; font-weight: 700;">&nbsp;
        </td>
        <td style="width: 107px; text-align: right;">&nbsp;
        </td>
        <td style="width: 235px">&nbsp;
        </td>
        <td style="width: 117px; text-align: right;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 156px; font-weight: 700;">&nbsp;
        </td>
        <td style="width: 107px; text-align: right;">&nbsp;
        </td>
        <td style="width: 235px">&nbsp;
        </td>
        <td style="width: 117px; text-align: right;">&nbsp;
        </td>
        <td style="width: 79px; text-align: right;">&nbsp;</td>
        <td>&nbsp;
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
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
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
