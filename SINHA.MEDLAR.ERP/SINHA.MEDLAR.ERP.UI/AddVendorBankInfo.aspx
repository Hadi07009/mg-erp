﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="AddVendorBankInfo.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.AddVendorBankInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">

        function controlEnter(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            if (keyCode == 13) {

                document.getElementById(obj).focus();

                return false;

            }

            else {

                return true;

            }

        }

    </script>
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtBankName.ClientID %>").focus(); }) 
    </script>
    <script type="text/javascript">
        function TextName_OnKeyDown(e) {
            var keynum
            if (window.event) // IE
            {
                keynum = e.keyCode
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
                keynum = e.which
            }
            if (keynum == 13) {
                document.getElementById('<%= btnSave.ClientID %>').click();
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
        <legend>ADD VENDOR BANK INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBankId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Bank Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBankName" runat="server" Width="236px" BackColor="White" 
                        Font-Bold="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Account No :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtAccountNo" runat="server" Width="236px" BackColor="White" MaxLength="300"
                        Font-Size="Small" Font-Bold="False"></asp:TextBox>
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Swift Code :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtSwiftCode" runat="server" Width="236px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        MaxLength="300" Font-Size="Small" Font-Bold="False"></asp:TextBox>
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Address :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtAddress" runat="server" Width="236px" BackColor="White" Height="55px"
                        TextMode="MultiLine" Font-Bold="False"></asp:TextBox>
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
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="VENDOR_BANK_ID" HeaderText="ID" />
                            <asp:BoundField DataField="VENDOR_BANK_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="ACCOUNT_NO" HeaderText="ACCOUNT NO" />
                            <asp:BoundField DataField="SWIFT_CODE" HeaderText="SWIFT CODE" />
                            <asp:BoundField DataField="BANK_ADDRESS" HeaderText="ADDRESS" />
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
