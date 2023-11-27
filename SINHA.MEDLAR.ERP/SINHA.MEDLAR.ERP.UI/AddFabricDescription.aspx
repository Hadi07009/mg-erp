<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddFabricDescription.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddFabricDescription" %>

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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtFabricName.ClientID %>").focus(); }) 
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
        <legend>ADD FABRIC DESCRIPTION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: justify; height: 18px;" colspan="3">&nbsp;<asp:Label ID="lblMsgRecord"
                    runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 342px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFabricId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 342px; height: 22px;">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Buyer :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="236px"
                        Height="23px">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 342px; height: 19px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Fabric Description :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtFabricName" runat="server" Width="230px" BackColor="White" Height="20px"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 342px; height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 342px">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: justify; width: 342px">
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Small" Font-Names="Tahoma"></asp:Label>
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
    <fieldset>
        <legend>SEARCH RESULT</legend>



        <td style="text-align: right; height: 19px" colspan="3">
            <asp:GridView ID="gvFabricDescription" runat="server" DataSourceID="" AutoGenerateColumns="False"
                GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvFabricDescription_PageIndexChanging"
                OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                OnRowEditing="gvFabricDescription_RowEditing" BorderStyle="Solid">
                <Columns>
                    <asp:BoundField DataField="FABRIC_ID" HeaderText="ID" />
                    <asp:BoundField DataField="BUYER_NAME" HeaderText="BUYER NAME" />
                    <asp:BoundField DataField="FABRIC_NAME" HeaderText="FABRIC DESCRIPTION" />



                    <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </fieldset>
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
