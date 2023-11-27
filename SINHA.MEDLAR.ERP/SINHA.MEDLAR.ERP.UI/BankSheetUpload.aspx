<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="BankSheetUpload.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.BankSheetUpload" %>

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
        <legend>BANK SHEET UPLOAD PROCESS</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 593px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    <fieldset>
                        <legend>BANK SHEET UPLOAD </legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 424px; height: 19px">
                                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Upload File :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    <asp:FileUpload ID="FileUpload1" onchange="this.form.submit();" runat="server" />
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 424px; height: 19px">
                                    <asp:Label ID="lblProductCataroy0" runat="server" Text="File Name :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    <asp:TextBox ID="txtFileName" runat="server" Width="160px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 424px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="File Path :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    <asp:TextBox ID="txtFilePath" runat="server" Width="160px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 424px; height: 19px">
                                    <asp:Label ID="lblProductCataroy7" runat="server" Text="Year/Month :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    <asp:TextBox ID="txtSalaryYear" runat="server" Width="105px" Height="20px" Font-Bold="True"
                                        MaxLength="4"></asp:TextBox>
                                    <asp:TextBox ID="txtsalaryMonth" runat="server" Width="48px" Height="20px" Font-Bold="True"
                                        MaxLength="2"></asp:TextBox>
                                    &nbsp;
                                    <asp:TextBox ID="txtTranId" runat="server" Width="16px" Height="20px" Font-Bold="True"
                                        MaxLength="2" Visible="False"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 424px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px" colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 424px">
                                    &nbsp;
                                </td>
                                <td style="width: 256px">
                                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnDelete_Click" />
                                </td>
                                <td style="width: 116px; text-align: right">
                                    &nbsp; &nbsp;
                                </td>
                                <td colspan="2">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>BANK UPLOAD ENTRY RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        OnRowDataBound="OnRowDataBound" AllowSorting="True" EnableViewState="true" GridLines="None"
                        AllowPaging="false" OnRowEditing="OnRowEditing" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" OnRowCommand="gvEmployeeList_RowCommand"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="DOWNLOAD">
                                <ItemTemplate>
                                    <asp:Button ID="btnDownload" runat="server" Text="Download" Width="70px"
                                        CommandName='<%# Eval("TRAN_ID") %>' CssClass="buttonDownload" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TRAN_ID" HeaderText="SL" />
                            <asp:BoundField DataField="FILE_NAME" HeaderText="FILE NAME" />
                            <asp:BoundField DataField="FILE_TYPE" HeaderText="TYPE" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
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
