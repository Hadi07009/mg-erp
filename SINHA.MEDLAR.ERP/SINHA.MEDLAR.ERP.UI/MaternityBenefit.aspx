﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="MaternityBenefit.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MaternityBenefit" %>

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
        <legend>TIFFIN INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 918px;">
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
                        <legend>TIFFIN ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 263px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 293px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="209px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 91px; text-align: right;">
                                    <asp:Label ID="Label19" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYear" runat="server" Width="103px" Height="20px" 
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtMonth" runat="server" Width="48px" Height="20px" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 263px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 293px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 91px; text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 263px; text-align: right; height: 22px;">
                                    &nbsp;</td>
                                <td style="width: 293px; text-align: left; height: 22px;">
                                    <asp:HiddenField ID="hfMaternityBenefitId" runat="server" />
                                </td>
                                <td style="width: 91px; text-align: right; height: 22px;">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                        
                            <tr>
                                <td style="text-align: center;"  colspan="2">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass = "styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="66px" CssClass = "styled-button-4"
                                        OnClick="btnSheet_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">                                        
                                            <tr>
                                                <td style="width: 258px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <%--<asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px" CssClass = "styled-button-4"
                                                        OnClick="btnSearch_Click" />--%>
                                                    &nbsp;
                                                   <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px" CssClass = "styled-button-4"
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
                                                <td style="width: 258px; text-align: right; height: 25px;">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 25px;">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px; height: 25px;">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px; height: 25px;">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td style="height: 25px">
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

            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>INCREMENT ENTRY RESULT WORKER</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="joining_date" HeaderText="J.D" />
                                            <asp:BoundField DataField="working_day" HeaderText="W.D" />
                                            <asp:BoundField DataField="net_salary" HeaderText="Net Salary" />
                                            <asp:BoundField DataField="over_time_amount" HeaderText="OT Amt" />
                                            <asp:BoundField DataField="attendence_fee" HeaderText="Atten. Bonus" />
                                            <asp:BoundField DataField="bonus_amount" HeaderText="Bonus" />
                                            <asp:BoundField DataField="leave_amount" HeaderText="L.Encash" />
                                            <asp:BoundField DataField="payment_amount" HeaderText="P.Amt" />
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
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="gvEmployeeList_OnRowEditing"
                        CausesValidation="false" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="gvEmployeeList_OnRowDataBound">
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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