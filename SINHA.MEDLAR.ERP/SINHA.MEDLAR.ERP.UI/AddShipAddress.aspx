<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="AddShipAddress.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddShipAddress" %>

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
        <legend>ADD SHIP INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>SHIP INFORMATION ENTRY</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtShipAddressId" runat="server" Width="72px" 
                                        BackColor="Yellow"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblId0" runat="server" Text="Company Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCompanyName" runat="server" Width="236px" 
                                        BackColor="White"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblId4" runat="server" Text="Mobile No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMobileNo" runat="server" Width="236px" 
                                        BackColor="White"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblId1" runat="server" Text="Contact No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtContactNo" runat="server" Width="236px" 
                                        BackColor="White"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblId3" runat="server" Text="Fax :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFaxNo" runat="server" Width="236px" 
                                        BackColor="White"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblId2" runat="server" Text="Email  :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmailAddress" runat="server" Width="236px" 
                                        BackColor="White"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblProductCataroy" runat="server" Text="Address"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtShipAddress" runat="server" Width="236px" BackColor="White" 
                                        Height="55px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Active Yn :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes" />
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
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
                                <td style="text-align: right; width: 279px">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="70px"
                                        OnClick="btnClear_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="70px" OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                        <Columns>
                            <asp:BoundField DataField="CONTACT_SHEET_ID" HeaderText="ID" />
                            <asp:BoundField DataField="CONTACT_SHEET_NAME" HeaderText="NAME" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
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
