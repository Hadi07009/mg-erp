<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="ForeignFabricAssign.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.ForeignFabricAssign" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(document).keypress(function (e) {
            if (e.which == 13) {
                $(document.activeElement).next().focus();
            }
        });
    </script>

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
    <%--  <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtp.ClientID %>").focus(); }) 
    </script>--%>
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
        <legend>FOREIGN FABRIC ASSIGN</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="7">
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 267px; text-align: right; height: 26px;">
                    <asp:Label ID="lblId1" runat="server" Text="Supplier : "></asp:Label>
                </td>
                <td style="width: 365px; height: 26px;">
                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="202px"
                        Height="24px">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Height="21px"
                        Text="..." Width="34px"
                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                </td>
                <td style="text-align: right; width: 245px; height: 26px;">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="Art :"></asp:Label>
                </td>
                <td style="text-align: justify; width: 173px; height: 26px;">
                    <asp:TextBox ID="txtArtId" runat="server"
                        Width="200px" BackColor="White" Height="22px"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 337px; height: 26px;">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td style="text-align: justify; width: 337px; height: 26px;">
                    <asp:TextBox ID="txtUnitId" runat="server" Width="200px" BackColor="White"
                        Height="22px"></asp:TextBox>
            </tr>
            <tr>
                <td style="text-align: right; width: 267px; height: 19px">
                    <asp:Label ID="lblId0" runat="server" Text="Programme : "></asp:Label>
                </td>
                <td style="height: 19px; width: 365px;">
                    <asp:DropDownList ID="ddlProgrammeId" runat="server" Width="202px"
                        Height="24px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; width: 245px; text-align: right;">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Style :"></asp:Label>
                </td>
                <td style="height: 19px; width: 173px;">
                    <asp:TextBox ID="txtStyleId" runat="server" Width="200px" BackColor="White"
                        Height="22px"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right;">
                    <asp:Label ID="lblProductCataroy6" runat="server" Text="Currency:"></asp:Label>
                </td>
                <td style="height: 19px; text-align: justify;">
                    <asp:TextBox ID="txtCurrencyId" runat="server" Width="200px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        Height="22px"></asp:TextBox>

                </td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 267px; height: 19px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Fabric :"></asp:Label>
                </td>
                <td style="height: 19px; width: 365px;">
                    <asp:TextBox ID="txtFabricId" runat="server" Width="200px" BackColor="White"
                        Style="margin-left: 0" Height="22px"></asp:TextBox>
                </td>
                <td style="height: 19px; width: 245px; text-align: right;">
                    <asp:Label ID="lblProductCataroy3" runat="server" Text="Color :"></asp:Label>
                </td>
                <td style="height: 19px; width: 173px;">
                    <asp:TextBox ID="txtColorId" runat="server" Width="200px" BackColor="White"
                        Height="22px"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right;">&nbsp;</td>
                <td style="height: 19px; text-align: justify;">
                    <asp:TextBox ID="txtTranId" runat="server" Width="27px" BackColor="Yellow"
                        Style="margin-left: 0" Height="22px" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 267px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Construction :"></asp:Label>
                </td>
                <td style="width: 365px; text-align: left;">
                    <asp:TextBox ID="txtFabricConstructionId" runat="server" Width="200px"
                        BackColor="White" Height="22px"></asp:TextBox>
                </td>
                <td style="width: 245px; text-align: right;">&nbsp;</td>
                <td style="width: 173px">&nbsp;</td>

            </tr>
            <tr>
                <td style="text-align: center; height: 32px;" colspan="7">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" CssClass="styled-button-4"
                        Width="66px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" CssClass="styled-button-4"
                        Width="66px" OnClick="btnShow_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: justify;" colspan="7">
                    <asp:Label ID="lblMsgRecord" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="7">
                    <asp:GridView ID="gvBuyerEntry" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvBuyerEntry_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>


                            <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />
                            <asp:BoundField DataField="PROGRAMME_NAME" HeaderText="PROGRAMME" />

                            <asp:BoundField DataField="FABRIC_NAME" HeaderText="FABRIC" />
                            <asp:BoundField DataField="FABRIC_CONSTRUCTION_NAME" HeaderText="CONSTRUCTION" />

                            <asp:BoundField DataField="ART_NO" HeaderText="ART" />
                            <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE" />
                            <asp:BoundField DataField="COLOR_NAME" HeaderText="COLOR" />
                            <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                            <asp:BoundField DataField="CURRENCY_NAME" HeaderText="CURRENCY" />
                            <asp:BoundField DataField="tran_id" HeaderText="ID" />

                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"
                                        AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 267px">&nbsp;
                </td>
                <td style="width: 365px">&nbsp;
                </td>
                <td style="width: 245px">&nbsp;</td>
                <td style="width: 173px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
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
