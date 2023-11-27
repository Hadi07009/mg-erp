<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddIncrementSetupYearly.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddIncrementSetupYearly" %>

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
        <legend>INCREMENT SETUP</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="lblId2" runat="server" Text="Increment Year/Month :"></asp:Label>
                </td>
                <td style="width: 223px">
                    <asp:TextBox ID="txtIncrementYear" runat="server" Width="115px" 
                        BackColor="Yellow"></asp:TextBox>
                    <asp:TextBox ID="txtIncrementMonth" runat="server" Width="87px" 
                        BackColor="Yellow"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
             <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="Label1" runat="server" Text="Pre.Increment Year/Month :"></asp:Label>
                </td>
                <td style="width: 223px">
                    <asp:TextBox ID="txtPreIncrementYear" runat="server" Width="115px" 
                        BackColor="Yellow"></asp:TextBox>
                    <asp:TextBox ID="txtPreIncrementMonth" runat="server" Width="86px"
                        BackColor="Yellow"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="lblId3" runat="server" Text="Employee Type :"></asp:Label>
                </td>
                <td style="width: 223px">
                    <asp:DropDownList ID="ddlEmpTypeId" runat="server" Width="214px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Effect Date:"></asp:Label>
                </td>
                <td style="width: 223px">
                    <asp:TextBox ID="dtpEffectDate" runat="server" Width="211px" BackColor="White" CssClass="date"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px; height: 19px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Limit Date :"></asp:Label>
                </td>
                <td style="height: 19px; width: 223px;">
                    <asp:TextBox ID="dtpLimitDate" runat="server" Width="211px" BackColor="White" CssClass="date"></asp:TextBox>
                    <asp:HiddenField ID="hf_proposal_id" runat ="server" />
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px; height: 19px">
                   <%-- &nbsp;--%>
                    <asp:Label ID="LblAsFirstSalary" runat="server" Text="As First Salary :"></asp:Label>
                </td>
                <td style="height: 19px; width: 223px;">
                    <asp:CheckBox ID="ChkAsFirstSalary" runat="server" Width="10px" />
                   <%-- &nbsp;--%>
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 337px; height: 19px">
                    <asp:Label ID="LblIsIncrement" runat="server" Text="Increment Y/N? :"></asp:Label>
                </td>
                <td style="height: 19px; width: 223px;">
                    <asp:CheckBox ID="ChkIsIncrement" runat="server" Width="10px" />
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>

            <tr>
                <td style="text-align: right; width: 337px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 223px;">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 337px">
                    &nbsp;
                </td>
                <td style="width: 223px">
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" 
                        Width="66px" 
                        CssClass="styled-button-4" onclick="btnClear_Click" />
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
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="INCREMENT_YEAR" HeaderText="YEAR" />
                            <asp:BoundField DataField="INCREMENT_MONTH" HeaderText="MONTH" />
                            <asp:BoundField DataField="PRE_INCREMENT_YEAR" HeaderText="PRE.INC.YEAR" />
                            <asp:BoundField DataField="PRE_INCREMENT_MONTH" HeaderText="PRE.INC.MONTH" />
                            <asp:BoundField DataField="EMPLOYEE_TYPE_NAME" HeaderText="TYPE" />
                            <asp:BoundField DataField="EFFECT_DATE" HeaderText="EFFECT_DATE" />
                            <asp:BoundField DataField="LIMIT_DATE" HeaderText="LIMIT DATE" />
                            <asp:BoundField DataField="as_first_salary" HeaderText="As First Salary" />
                            <asp:BoundField DataField="increment_yn" HeaderText="INCREMENT" />
                             <asp:BoundField DataField="employee_type_id" HeaderText="Holiday_Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                            <asp:BoundField DataField="PROPOSAL_ID" HeaderText="PROPOSAL_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
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
