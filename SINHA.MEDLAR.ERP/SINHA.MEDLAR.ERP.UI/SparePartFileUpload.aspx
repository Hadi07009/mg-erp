<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="SparePartFileUpload.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.SparePartFileUpload" %>

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
        <legend>ATTENDENCE UPLOAD PROCESS</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 601px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    <fieldset>
                        <legend>FILE UPLOAD</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    <asp:Label ID="lblProductCataroy9" runat="server" Text="Part Name :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:DropDownList ID="ddlSparePartId" runat="server" Width="238px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy8" runat="server" Text="Part No :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtPartNo" runat="server" Width="160px" BackColor="White"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Upload File :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:FileUpload ID="FileUpload1" onchange="this.form.submit();" runat="server" />
                                    </asp:FileUpload>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    <asp:Label ID="lblProductCataroy0" runat="server" Text="File Name :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:TextBox ID="txtFileName" runat="server" Width="236px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 98px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left; height: 19px" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;" colspan="4">
                                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="75px"
                                        CssClass="styled-button-4" />
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
        <legend>SEARCH RESULT </legend>
        <table class="style1">
            <tr>
                <td style="text-align: left">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        OnRowEditing="gvUnit_OnRowEditing" AllowSorting="True" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"   OnSelectedIndexChanged="gvUnit_OnSelectedIndexChanged" >
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="SPARE_PART_NAME" HeaderText="PART NAME" />
                            <asp:BoundField DataField="FILE_NAME" HeaderText="FILE NAME" />
                           <%-- <asp:TemplateField HeaderText="VIEW">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" Text="View" OnClick="lnkView" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOWNLOAD">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDownload" Text="Download" OnClick="lnkDownload" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
