<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="UserInterface.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.UserInterface" %>

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
        <legend>Add User Interface</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left;" colspan="3">&nbsp;<asp:Label ID="lblMsg" runat="server"
                    Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp;
                </td>
            </tr>
           <%-- <tr>
                <td style="text-align: right; width: 338px; height: 15px;">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtCatagoryId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click"
                        CssClass="styled-button-4" />
                </td>
                <td class="style3">&nbsp;
                </td>
            </tr>--%>
            <tr>
                <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblUIName" runat="server" Text="UI Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtUserInterfaceName" runat="server" Width="236px" BackColor="White"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblUIDisplayName" runat="server" Text="Display Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDisplayName" runat="server" Width="236px" BackColor="White" Font-Size="Small"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px; height: 19px">&nbsp;
                                    <asp:Label ID="Label36" runat="server" Text="Software Name :"></asp:Label>
                </td>
                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlSoftwareId" runat="server" Width="236px" Height="22px"
                                        BackColor="White">
                                    </asp:DropDownList>
                </td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px; height: 19px">
                    <asp:Label ID="Label49" runat="server" Text="Active Y/N :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:CheckBox ID="chkActiveYn" runat="server"/>
                    <asp:TextBox ID="txtUserInterfaceId" runat="server" Width="23px" BackColor="White" Visible="false"></asp:TextBox>
                </td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px; height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" CssClass="styled-button-4"
                        OnClick="btnShow_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="GvUserInterface" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GvUserInterface_PageIndexChanging" OnSelectedIndexChanged="GvUserInterface_SelectedIndexChanged"
                        OnRowDataBound="GvUserInterface_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ui_id" HeaderText="ID" />
                            <asp:BoundField DataField="display_name" HeaderText="DISPLAY NAME" />
                            <asp:BoundField DataField="ui_name" HeaderText="UI Name" />
                            <asp:BoundField DataField="software_name" HeaderText="Software" />
                            <asp:BoundField DataField="active_yn" HeaderText="Active:Y/N?" />
                             <asp:BoundField DataField="soft_id" HeaderText="soft_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px">&nbsp;
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
