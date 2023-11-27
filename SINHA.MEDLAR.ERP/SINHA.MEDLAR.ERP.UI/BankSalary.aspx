﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="BankSalary.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.BankSalary" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function TextName_OnKeyDown(e) {
            var keynum
            if (window.event) // IE
            {
                keynum = e.keyCode
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                keynum = e.which
            }
            if (keynum == 13) {
                document.getElementById('<%= btnSave.ClientID %>').click();
            }
        }
    </script>
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtFirstSalary.ClientID %>").focus(); }) 
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
        <legend>BANK SALARY INFORMATION</legend>
        <table class="style1">
            <tr>
                <td colspan="2" style="text-align: left">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>BANK SALARY ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 329px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 280px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 98px; text-align: right;">
                                    <asp:Label ID="Label19" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYear" runat="server" Width="103px" Height="20px" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtMonth" runat="server" Width="48px" Height="20px" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 329px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 280px; text-align: left;">
                                    <asp:TextBox ID="txtDesignation" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 98px; text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 329px; text-align: right">
                                    <asp:Label ID="Label44" runat="server" Text="Bank Salary :"></asp:Label>
                                </td>
                                <td style="width: 280px; text-align: left;">
                                    <asp:TextBox ID="txtFirstSalary" runat="server" Width="130px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 98px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 329px; text-align: right; height: 15px;">
                                    <asp:Label ID="Label27" runat="server" Text="First Salary : "></asp:Label>
                                </td>
                                <td style="width: 280px; text-align: left; height: 15px;">
                                    <asp:TextBox ID="txtBankSalary" runat="server" Width="130px" Height="20px" Font-Bold="True"
                                        BackColor="Yellow" ForeColor="Red"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="width: 98px; text-align: right; height: 15px;">
                                    &nbsp;
                                </td>
                                <td style="height: 15px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 329px; text-align: right; height: 15px;">
                                    <asp:Label ID="Label43" runat="server" Text="Gross Salary : "></asp:Label>
                                </td>
                                <td style="width: 280px; text-align: left; height: 15px;">
                                    <asp:TextBox ID="txtCurrentSalary" runat="server" Width="130px" Height="20px" Font-Bold="True"
                                        BackColor="Yellow" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 98px; text-align: right; height: 15px;">
                                    &nbsp;
                                </td>
                                <td style="height: 15px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; height: 15px; width: 329px;">
                                    &nbsp;
                                </td>
                                <td style="width: 280px; text-align: left; height: 15px;">
                                    &nbsp;
                                </td>
                                <td style="width: 98px; text-align: right; height: 15px;">
                                    &nbsp;
                                </td>
                                <td style="height: 15px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 15px;" colspan="4">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnNext_Click" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnProcess_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnShow_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 329px; text-align: right">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 148px; text-align: right;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 79px">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                </td>
                                                <td style="text-align: right; width: 79px">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 329px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 148px; text-align: right;">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 79px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 79px">
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
                </td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    <fieldset>
                        <legend>BANK SALARY ENTRY RESULT</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION " />
                                            <asp:BoundField DataField="curr_salary" HeaderText="GROSS" />
                                            <asp:BoundField DataField="first_salary" HeaderText="FIRST" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
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
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <fieldset>
                    <legend>SEARCH RESULT</legend>
                    <asp:GridView ID="gvIncrementList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowCommand="gvIncrementList_RowCommand" OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="CURR_SALARY" HeaderText="GROSS" />
                            <asp:BoundField DataField="FIRST_SALARY" HeaderText="FIRST" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </fieldset>
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
