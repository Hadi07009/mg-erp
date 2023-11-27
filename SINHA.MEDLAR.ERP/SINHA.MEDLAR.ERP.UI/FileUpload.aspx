<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="FileUpload.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.FileUpload" %>

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
        <legend>FILE UPLOAD PROCESS</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 601px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    <fieldset>
                        <legend>FILE UPLOAD</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Upload File :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    <asp:FileUpload ID="FileUpload1" onchange="this.form.submit();" runat="server" />
                                    </asp:FileUpload>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy7" runat="server" Text="From Date :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="160px" BackColor="White" CssClass="date"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    <asp:Label ID="lblProductCataroy0" runat="server" Text="File Name :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    <asp:TextBox ID="txtFileName" runat="server" Width="236px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy4" runat="server" Text="To Date :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="dtpToDate" runat="server" Width="160px" BackColor="White" CssClass="date"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="File Path :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    <asp:TextBox ID="txtFilePath" runat="server" Width="236px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 256px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 19px" colspan="4">
                                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
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
        <legend>SEARCH RESULT </legend>
        <table class="style1">
            <tr>
                <td style="text-align: left">
                    <asp:GridView ID="gvEmployeeLogList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeLogList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnRowCommand="gvEmployeeLogList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="FILE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="FILE_TYPE" HeaderText="TYPE" />
                            <asp:BoundField DataField="DOWNLOAD" HeaderText="DOWNLOAD" />
                        </Columns>
                        <AlternatingRowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <SelectedRowStyle BackColor="Blue" ForeColor="White" />
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
