<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="UploadFile.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.UploadFile" %>

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
        <legend>FILE UPLOAD INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblFileName" runat="server" Text="FileName : "></asp:Label>
                </td>
                <td style="width: 241px">
                    <asp:FileUpload ID="FileUpload1" runat="server" Height="22px" Width="231px" 
                        onchange="this.form.submit();" />
                </td>
                <td>
                    <asp:TextBox ID="txtTranId" runat="server" Width="16px" BackColor="Yellow" MaxLength="300"
                        Font-Size="Small" Font-Bold="True"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblFilePath" runat="server" Text="File Path:"></asp:Label>
                </td>
                <td style="width: 241px">
                    <asp:TextBox ID="txtFilePath" runat="server" Width="236px" BackColor="Yellow"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Year/Month:"></asp:Label>
                </td>
                <td style="height: 19px; width: 241px;">
                    <asp:TextBox ID="txtYear" runat="server" Width="121px" BackColor="Yellow" MaxLength="300"
                        Font-Size="Small" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtMonth" runat="server" Width="109px" BackColor="Yellow" MaxLength="300"
                        Font-Size="Small" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 241px;">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td style="width: 241px">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" CssClass="styled-button-4"
                        Width="66px" OnClick="btnShow_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" AutoGenerateColumns="False" GridLines="None"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvUnit_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        OnSelectedIndexChanged="gvUnit_OnSelectedIndexChanged">
                        <AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="TRAN_ID" HeaderText="ID" />
                            <asp:BoundField DataField="FILE_NAME" HeaderText="FILE NAME" />
                            <asp:BoundField DataField="FILE_TYPE" HeaderText="FILE TYPE" />
                            <asp:TemplateField HeaderText="DOWNLOAD">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" OnClick="OpenDocument" runat="server" Text='<%# Eval("FILE_NAME") %>'
                                        CommandArgument='<%# Eval("TRAN_ID") %>' CommandName="Download"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td style="width: 241px">
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
