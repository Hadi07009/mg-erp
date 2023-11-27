﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ReportProduction.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportProduction" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
     <%-- Auto fill or Complete Textbox--%>
      <%--<script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtPONo.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ReportProduction.aspx/GetPONo",
                        data: "{ 'PONo':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter : function (data) {return data;},
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });
    </script>--%>
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
                         </table>
                      </fieldset>
                </td>
            </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoShipmentStatementByBuyer" runat="server" 
                AutoPostBack="true" Text="Buyer Wise Shipment Statement"
                Font-Bold="False" GroupName="Controls"/>
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
                                    <asp:Label ID="lblLineName" runat="server" Text="Line Name :"></asp:Label>
        </td>
        <td style="width: 249px; height: 22px;">
                                    <asp:DropDownList ID="ddlLineId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="height: 22px">
            </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdProductionDetailSheet" runat="server" 
                AutoPostBack="true" Text=" Production Sheet(Daily) "
                Font-Bold="False" GroupName="Controls"/>
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
                                    <asp:Label ID="lblBuyerName" runat="server" Text="Buyer Name :"></asp:Label>
        </td>
        <td style="width: 249px; height: 22px;">
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="240px" Height="22px" AutoPostBack="true" OnSelectedIndexChanged="ddlBuyerId_SelectedIndexChanged">
                                    </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right; height: 22px;">
            </td>
        <td style="height: 22px">
            </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoMonthlyProductionSheet" runat="server" 
                AutoPostBack="true" Text=" Production Sheet(Monthly) "
                Font-Bold="False" GroupName="Controls"/>
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
                    <asp:Label ID="lblBuyerShortName1" runat="server" Text="PO No :"></asp:Label>
        </td>
        <td style="width: 249px; height: 22px;">
                    <asp:TextBox ID="txtPONo" runat="server" Width="204px"></asp:TextBox>
            <asp:Button ID="btnDateSrc" runat="server" Text="..." 
                Width="30px" OnClick="btnDateSrc_Click" AutoPostBack="True" 
                        CssClass = "styled-button-4" Height="23px"/>
        </td>
        <td style="width: 79px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="height: 22px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoProductionSheetByBuyer" runat="server" 
                AutoPostBack="true" Text="Production Sheet By Buyer"
                Font-Bold="False" GroupName="Controls"/>
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId9" runat="server" Text="From :"></asp:Label>
        </td>
        <td style="width: 249px">
            <asp:TextBox ID="dtpFromDate" runat="server" Width="236px" BackColor="White" CssClass="date"
                placeholder="FROM DATE"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: left;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px">
            <asp:RadioButton ID="rdoProductionSheetByPODetail" runat="server" 
                AutoPostBack="true" Text="PO Wise Production Report Detail"
                Font-Bold="False" GroupName="Controls"/>
        </td>
        <td style="width: 81px; text-align: right;">
            <asp:Label ID="lblOfficeId10" runat="server" Text="To :"></asp:Label>
        </td>
        <td style="width: 249px">
            <asp:TextBox ID="dtpToDate" runat="server" Width="236px" BackColor="White" CssClass="date"
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
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoPoWiseProductionShipment" runat="server" 
                AutoPostBack="true" Text="PO Wise Production and Shipment"
                Font-Bold="False" GroupName="Controls"/>
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 249px; height: 22px;">
            <asp:DropDownList runat="server" ID="ddlPoStatus" Width="240px" Height="22px">
                <asp:ListItem Value="1">Open</asp:ListItem>
                <asp:ListItem Value="2">Open and Close</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: left; height: 22px;">
            <asp:TextBox ID="txtPOId" runat="server" Width="20px" 
                BackColor="Yellow" Visible="False"></asp:TextBox>
        </td>
        <td style="height: 22px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoMonthlyProductionSheetByPO" runat="server" 
                AutoPostBack="true" Text="PO Wise Production Report Summery"
                Font-Bold="False" GroupName="Controls"/>
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            &nbsp;</td>
        <td style="width: 249px; height: 22px;">
            <%--<asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"  CssClass = "styled-button-4"/>--%>
        </td>
        <td style="width: 79px; text-align: left; height: 22px;">
            &nbsp;</td>
        <td style="height: 22px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 256px; height: 22px;">
            <asp:RadioButton ID="rdoProductionSheetByBuyerAndFactory" runat="server" 
                AutoPostBack="true" Text="Production Sheet By Buyer"
                Font-Bold="False" GroupName="Controls" Visible="False"/>
        </td>
        <td style="width: 81px; text-align: right; height: 22px;">
            </td>
        <td style="width: 249px; height: 22px;">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"  CssClass = "styled-button-4"/>
            </td>
        <td style="width: 79px; text-align: left; height: 22px;">
            </td>
        <td style="height: 22px">
            </td>
    </tr>
    <tr>
        <td style="width: 256px; height: 24px;">
            </td>
        <td style="width: 81px; text-align: right; height: 24px;">
            </td>
        <td style="width: 249px; height: 24px;">
            </td>
        <td style="width: 79px; text-align: left; height: 24px;">
            </td>
        <td style="height: 24px">
            </td>
    </tr>
    <tr>
        <td style="width: 256px">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 249px">
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
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 249px">
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
        <td style="width: 249px; height: 21px;">
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
        <td style="width: 256px; font-weight: 700;">
            &nbsp;
        </td>
        <td style="width: 81px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 249px">
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
        <td style="width: 249px">
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

    </fieldset>
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
