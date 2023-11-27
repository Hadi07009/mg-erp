<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeePicture.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeePicture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function previewFile() {
            var preview = document.querySelector('#<%=imgEmployee.ClientID %>');
            var file = document.querySelector('#<%=FileUpload1.ClientID %>').files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }

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
        <legend>EMPLOYEE IMAGE</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 19px;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 321px">
                    <asp:Label ID="lblId0" runat="server" Text="Employee ID :"></asp:Label>
                </td>
                <td style="width: 509px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="110px" BackColor="Yellow" Height="20px"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtCardNo" runat="server" Width="84px" BackColor="Yellow" Height="20px"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSL" runat="server" Width="48px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSLNew" runat="server" Width="48px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 321px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Employee Name :"></asp:Label>
                </td>
                <td style="width: 509px">
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="256px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 321px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Designation :"></asp:Label>
                </td>
                <td style="width: 509px">
                    <asp:TextBox ID="txtDesignationName" runat="server" Width="256px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 321px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 509px;">
                    <asp:Image ID="imgEmployee" runat="server" BorderStyle="Double" Height="126px" 
                        Width="142px" BorderWidth="1px" />
                    <input id="FileUpload1" type="file" name="file" onchange="previewFile()" runat="server" />
                    <%--<asp:BoundField DataField="EMPLOYEE_PIC" HeaderText="PIC" />--%>
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 321px; height: 19px">
                    &nbsp;</td>
                <td style="height: 19px; width: 509px;">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 321px; height: 19px">
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnDelete_Click" />
                </td>
                <td style="height: 19px; width: 509px;">
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px"   CssClass = "styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnNext_Click" />
                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"  CssClass = "styled-button-4"
                        OnClick="btnPrevious_Click" />
                </td>
                <td style="height: 19px">
                    &nbsp;
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
                <td style="width: 113px; text-align: right; height: 25px;">
                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px; height: 25px;">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="160px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 25px; width: 65px;">
                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"  CssClass = "styled-button-4"
                        OnClick="btnSearch_Click" />
                    &nbsp;
                </td>
                <td style="height: 25px; text-align: right; width: 105px;">
                    <asp:Label ID="Label36" runat="server" Text="Employee ID :"></asp:Label>
                </td>
                <td style="height: 25px; width: 336px;">
                    <asp:TextBox ID="txtEmpId" runat="server" Width="104px" BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 25px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 113px; text-align: right">
                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="160px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 65px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 105px">
                    <asp:Label ID="Label37" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td style="width: 336px">
                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="104px" BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right">
                </td>
                <td style="text-align: right; width: 105px;">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 336px;">
                    &nbsp;
                </td>
                <td style="text-align: right">
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
                            <%--<asp:BoundField DataField="EMPLOYEE_PIC" HeaderText="PIC" />--%>
                        </Columns>
                    </asp:GridView>
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
