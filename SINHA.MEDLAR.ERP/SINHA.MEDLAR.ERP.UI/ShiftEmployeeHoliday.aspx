﻿<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShiftEmployeeHoliday.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ShiftEmployeeHoliday" %>--%>

<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ShiftEmployeeHoliday.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ShiftEmployeeHoliday" %>

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
    <fieldset>
        <legend>ADD HOLIDAY</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtHolidayId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click"
                        CssClass="styled-button-4" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 341px">
                    <asp:Label ID="lblEmployeeId" runat="server" Text="Employee Id:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="236px"
                        BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 341px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Start Date :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dtpHolidayStartDate" runat="server" Width="236px" CssClass="date"
                        BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px; height: 19px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="End Date :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="dtpHolidayEndDate" runat="server" Width="236px" CssClass="date"
                        BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px; height: 19px">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Holiday Type :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlHolidayTypeId" runat="server" Width="239px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px; height: 19px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Remark :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtDescription" runat="server" Width="236px" BackColor="White" Height="63px"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="66px"
                        CssClass="styled-button-4" onclick="btnDelete_Click1" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="HOLIDAY_ID" HeaderText="ID" />
                            <asp:BoundField DataField="HOLIDAY_START_DATE" HeaderText="Holiday Start Date" />
                            <asp:BoundField DataField="HOLIDAY_END_DATE" HeaderText="Holiday End Date" />
                            <asp:BoundField DataField="TOTAL_DAY" HeaderText="Total Day" />
                            <asp:BoundField DataField="HOLIDAY_NAME" HeaderText="Holiday Type" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px">
                    &nbsp;
                </td>
                <td>
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

