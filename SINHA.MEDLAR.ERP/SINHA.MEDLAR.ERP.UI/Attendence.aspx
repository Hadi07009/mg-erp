<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true"
    CodeBehind="Attendence.aspx.cs" Inherits="SINHA.MEDLAR.HR.UI.EmployeeAttendence" %>

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
        <legend>EMPLOYEE ATTENDENCE SYSTEM</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 279px">
                    &nbsp;
                </td>
                <td style="width: 265px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td style="width: 265px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Employee Name :"></asp:Label>
                </td>
                <td style="width: 265px">
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="236px" BackColor="Yellow"
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                </td>
                <td style="height: 19px; width: 265px;">
                    <asp:Image ID="employeePic" runat="server" BorderStyle="Double" Height="126px" Width="142px"
                        ImageUrl='<%# "ImageHandler.ashx?image_id="+ Eval("image_id") %>' />
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="IN :"></asp:Label>
                </td>
                <td style="width: 265px">
                    <asp:DropDownList ID="ddlInTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Out :"></asp:Label>
                </td>
                <td style="width: 265px">
                    <asp:DropDownList ID="ddlOutTime" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td style="width: 265px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td style="width: 265px">
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Submit" Width="87px"
                        OnClick="btnSave_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td style="width: 265px">
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
