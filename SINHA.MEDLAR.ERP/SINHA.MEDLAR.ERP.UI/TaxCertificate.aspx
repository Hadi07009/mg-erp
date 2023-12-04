﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="TaxCertificate.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.TaxCertificate" %>

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
        <legend>SALARY TAX INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 919px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>TAX CERTIFICATE PROCESS</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 306px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 277px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 104px; text-align: right;">
                                    <asp:Label ID="Label19" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 306px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 277px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 104px; text-align: right;">
                                    <asp:Label ID="Label44" runat="server" Text="From Date :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="156px" Height="20px" Font-Bold="True" CssClass="date"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 306px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="width: 277px; text-align: left;">
            <asp:DropDownList ID="ddlUnitId1" runat="server" Width="148px" Height="22px" placeholder="Unit">
            </asp:DropDownList>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 104px; text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="To Date :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="dtpToDate" runat="server" Width="155px" Height="20px" 
                                        Font-Bold="True" CssClass="date"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; width: 306px;">
                                    <asp:Label ID="Label45" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="width: 277px; text-align: left;">
                                    <asp:DropDownList ID="ddlSectionId1" runat="server" Width="148px" Height="22px" placeholder="Unit"> </asp:DropDownList>
                                </td>
                                <td style="width: 104px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; width: 306px;">
                                    &nbsp;</td>
                                <td style="width: 277px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 104px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                 &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; width: 306px;">
                                    &nbsp;</td>
                                <td style="width: 277px; text-align: left;">
                                    <%--&nbsp;--%>
                                    <asp:Button ID="btnCertificateSheet" runat="server" Height="31px" Text="Sheet" Width="66px"  CssClass = "styled-button-4" OnClick="btnCertificateSheet_Click" />
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px" OnClick="btnClear_Click"  CssClass = "styled-button-4"/>

                                </td>
                                <td style="width: 104px; text-align: right;">
                                    &nbsp;

                                </td>
                                <td>
                                 &nbsp;
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Button ID="btnCertificateSheet" runat="server" Height="31px" Text="Sheet" Width="66px"  CssClass = "styled-button-4" OnClick="btnCertificateSheet_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"  CssClass = "styled-button-4"/>
                                </td>
                            </tr>--%>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 301px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"  CssClass = "styled-button-4"
                                                        OnClick="btnSearch_Click" />
                                                  
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 301px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
            </tr>
          
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" OnSorting="gvEmployeeList_Sorting" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
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
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>