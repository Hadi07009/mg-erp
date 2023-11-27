<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddDepartment.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddDepartment" %>

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
        <legend>ADD DEPARTMENT</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDepartmentId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click"
                        CssClass="styled-button-4" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Department Name(Eng) :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDepartmentEng" runat="server" Width="236px" BackColor="White"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Department Name(Bng) :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDepartmentNameBng" runat="server" Width="236px" Font-Names="KarnaphuliMJ"
                        MaxLength="300" BackColor="White"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px; height: 19px"></td>
                <td style="height: 19px"></td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 337px">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnSelectedIndexChanged="gvUnit_SelectedIndexChanged" OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="DEPARTMENT_ID" HeaderText="ID" />
                            <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="DEPARTMENT NAME" />
                            <asp:BoundField DataField="DEPARTMENT_NAME_BANGLA" HeaderText="DEPARTMENT NAME(BANGLA)" />
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
            <tr>
                <td style="text-align: right; width: 337px">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
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
