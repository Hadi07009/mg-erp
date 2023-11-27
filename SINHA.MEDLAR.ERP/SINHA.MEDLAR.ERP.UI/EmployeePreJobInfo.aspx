<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeePreJobInfo.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeePreJobInfo" %>

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
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <fieldset>
        <legend>EMPLOYEE PREVIOUS JOB INFO.</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="4">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label45" runat="server" Text="Organization Name :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="txtOrganizationName" runat="server" Width="240px" BackColor="White"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    <asp:Label ID="Label71" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCardNo" runat="server" Width="216px" BackColor="Yellow" ReadOnly="True"
                        Height="20px" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSL" runat="server" Width="33px" Height="20px" ReadOnly="True"
                        BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label46" runat="server" Text="Joining Date:"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="dtpPreJoiningDate" runat="server" Width="170px" BackColor="White"
                        CssClass="date"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    <asp:Label ID="Label69" runat="server" Text="Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="256px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label47" runat="server" Text="Department/Section :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="txtSectionName" runat="server" Width="170px" BackColor="White"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    <asp:Label ID="Label70" runat="server" Text="Designation :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDesignation" runat="server" Width="256px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label48" runat="server" Text="Designation :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="txtDesignationName" runat="server" Width="170px" BackColor="White"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    <asp:Label ID="Label6" runat="server" Text="Emp ID :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="256px" BackColor="Yellow" ReadOnly="True"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label49" runat="server" Text="Previous Salary :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="txtPreviousSalary" runat="server" Width="170px" BackColor="White"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    &nbsp;
                </td>
                <td>
                    <asp:TextBox ID="txtSLNew" runat="server" Width="33px" Height="20px" ReadOnly="True"
                        BackColor="Yellow" Font-Bold="True" Visible="False"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label50" runat="server" Text="Year Of Experience :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="txtYearOfExperience" runat="server" Width="170px" BackColor="White"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label67" runat="server" Text="Working Duration :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="txtWorkingDuration" runat="server" Width="170px" BackColor="White"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label51" runat="server" Text="Leave Date :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="dtpLeaveDate" runat="server" Width="170px" BackColor="White" CssClass="date"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 172px">
                    <asp:Label ID="Label68" runat="server" Text="Leaving Reason :"></asp:Label>
                </td>
                <td style="width: 259px">
                    <asp:TextBox ID="txtLeavingReson" runat="server" Width="240px" BackColor="White"
                        Height="53px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 95px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center; " colspan="4">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clar" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnShow_Click" />
                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnNext_Click" />
                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px" CssClass = "styled-button-4"
                        OnClick="btnPrevious_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; " colspan="4">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" 
                        Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="4">
                    <fieldset>
                        <legend>JOB ENTRY RESULT</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <table class="style1">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                    OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                    GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                                    PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                                    AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="SL" HeaderText="SL" />
                                                        <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                                        <asp:BoundField DataField="ORGANIZATION_NAME" HeaderText="ORGANIZATION" />
                                                        <asp:BoundField DataField="JOINING_DATE" HeaderText="JDATE" />
                                                        <asp:BoundField DataField="ORGANIZATION_NAME" HeaderText="ORGANIZATION" />
                                                        <asp:BoundField DataField="SECTION_NAME" HeaderText="DEPT" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <%-- </div>--%>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <table class="style1">
            <tr>
                <td style="width: 110px; text-align: right; height: 1px;">
                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px; height: 1px;">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="160px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 67px; height: 1px">
                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"  CssClass = "styled-button-4"
                        OnClick="btnSearch_Click" />
                    &nbsp;
                </td>
                <td style="text-align: right; width: 83px; height: 1px">
                    <asp:Label ID="Label72" runat="server" Text="Employee ID :"></asp:Label>
                </td>
                <td style="height: 1px">
                    <asp:TextBox ID="txtEmpId" runat="server" Width="104px" BackColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 110px; text-align: right">
                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="160px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 67px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 83px">
                    <asp:Label ID="Label73" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="104px" BackColor="White"></asp:TextBox>
                </td>
            </tr>
        </table>
    </fieldset>
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
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
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
