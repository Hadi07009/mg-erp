<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="DeleteEmployeeEducation.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.DeleteEmployeeEducation" %>

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
        <legend>DELETE EMPLOYEE EDUCATION </legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="4">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 138px">
                    <asp:Label ID="Label2" runat="server" Text="Institute Name :"></asp:Label>
                </td>
                <td style="width: 215px">
                    <asp:TextBox ID="txtInstituteName" runat="server" Width="211px" BackColor="Yellow"
                        CssClass="date" ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 104px">
                    <asp:Label ID="Label36" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="215px" BackColor="Yellow" ReadOnly="True"
                        Height="20px" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSL" runat="server" Width="33px" Height="20px" ReadOnly="True"
                        BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 138px">
                    <asp:Label ID="Label3" runat="server" Text="Course :"></asp:Label>
                </td>
                <td style="width: 215px">
                    <asp:TextBox ID="txtCourseName" runat="server" Width="211px" BackColor="Yellow"
                        CssClass="date" ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 104px">
                    <asp:Label ID="Label37" runat="server" Text="Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="256px" BackColor="Yellow"
                        CssClass="date" ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 138px">
                    <asp:Label ID="Label4" runat="server" Text="Subject :"></asp:Label>
                </td>
                <td style="width: 215px">
                    <asp:TextBox ID="txtSubjectName" runat="server" Width="211px" BackColor="Yellow"
                        CssClass="date" ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 104px">
                    <asp:Label ID="Label38" runat="server" Text="Designation :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDesignation" runat="server" Width="256px" BackColor="Yellow"
                        CssClass="date" ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 138px">
                    <asp:Label ID="Label5" runat="server" Text="Passing Year :"></asp:Label>
                </td>
                <td style="width: 215px">
                    <asp:TextBox ID="txtPassingYear" runat="server" Width="104px" 
                        BackColor="Yellow" ReadOnly="True" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSLNew" runat="server" Width="33px" Height="20px" ReadOnly="True"
                        BackColor="Yellow" Font-Bold="True" Visible="False"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 104px">
                    <asp:Label ID="Label16" runat="server" Text="Employee ID :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpId" runat="server" Width="256px" BackColor="Yellow" ReadOnly="True"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; " colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center; " colspan="4">
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete"  CssClass = "styled-button-4"
                        Width="66px" onclick="btnDelete_Click"
                       />
                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnNext_Click" />
                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnPrevious_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 138px">
                    &nbsp;
                </td>
                <td style="width: 215px">
                    &nbsp;</td>
                <td style="text-align: right; width: 104px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left" colspan="5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 116px; text-align: right">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Employee ID :"></asp:Label>
                </td>
                <td style="width: 198px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right; width: 91px;">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 116px; text-align: right">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td style="width: 198px">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="153px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right; width: 91px;">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Employee Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmployeeId" runat="server" Width="153px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="width: 116px; text-align: right; height: 22px;">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Section :"></asp:Label>
                </td>
                <td style="width: 198px; height: 22px;">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="153px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px">
                </td>
                <td style="height: 22px; text-align: right; width: 91px;">
                    &nbsp;
                </td>
                <td style="height: 22px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 116px; text-align: right">
                    &nbsp;
                </td>
                <td style="width: 198px">
                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="text-align: right; width: 91px;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <%-- </div>--%>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <table class="style1">
                        <tr>
                            <td>
                                <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                    AllowSorting="True" OnSorting="gvEmployeeList_Sorting" EnableViewState="true"
                                    GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                    OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                    OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="SL" HeaderText="SL" />
                                        <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                        <asp:BoundField DataField="INSTITUTE_NAME" HeaderText="INSTITUTE" />
                                        <asp:BoundField DataField="COURSE_NAME" HeaderText="COURSE" />
                                        <asp:BoundField DataField="SUBJECT_NAME" HeaderText="SUBJECT" />
                                        <asp:BoundField DataField="PASSING_YEAR" HeaderText="YEAR" />
                                        <%--<asp:BoundField DataField="EMPLOYEE_PIC" HeaderText="PIC" />--%>
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
