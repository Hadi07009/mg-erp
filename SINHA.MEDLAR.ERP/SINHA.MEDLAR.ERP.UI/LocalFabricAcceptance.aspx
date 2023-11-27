<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="LocalFabricAcceptance.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.LocalFabricAcceptance" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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
        <legend>LOCAL FABRIC ACCEPTANCE</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 939px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>FABRIC ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 307px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Challan No :"></asp:Label>
                                </td>
                                <td style="width: 269px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtChallanNo" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="text-align: right; height: 22px;">
                                    <asp:Label ID="Label32" runat="server" Text="D/N No :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="txtDNNo" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 307px; text-align: right">
                                    <asp:Label ID="Label46" runat="server" Text="Acceptance Date :"></asp:Label>
                                </td>
                                <td style="width: 269px; text-align: left;">
                                    <asp:TextBox ID="dtpAcceptanceDate" runat="server" Width="156px" BackColor="White"
                                        Font-Bold="True" CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label49" runat="server" Text="B to B/LC :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLCNo" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 307px; text-align: right">&nbsp;
                                </td>
                                <td style="width: 269px; text-align: left;">
                                    <asp:RadioButton ID="rdoCash" runat="server" OnCheckedChanged="rdoCash_CheckedChanged"
                                        GroupName="Controls" Text="Cash" />
                                    &nbsp;
                                    <asp:RadioButton ID="rdoLC" runat="server" OnCheckedChanged="rdoLC_CheckedChanged"
                                        GroupName="Controls" Text="L/C" />
                                </td>
                                <td style="text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 307px; text-align: right">&nbsp;</td>
                                <td style="width: 269px; text-align: left;">
                                    &nbsp;</td>
                                <td style="text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>FABRIC ACCEPTANCE ENTRY </legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvFabricDetails" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvFabricDetails_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" OnRowEditing="gvFabricDetails_OnRowEditing"
                                                        DataKeyNames="TRAN_ID"  OnRowDeleting="gvFabricDetails_RowDeleting"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvFabricDetails_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvFabricDetails_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvFabricDetails_OnSelectedIndexChanged">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="PO">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPO" runat="server" Width="80" Text='<%#Eval("PO_NO")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PI">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPI" runat="server" Width="80" Text='<%#Eval("PO_NO")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PROGRAMME">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlProgrammeId" DataTextField="PROGRAMME_NAME" AppendDataBoundItems="true"
                                                                        DataValueField="PROGRAMME_ID" runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="FABRIC">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlFabricId" DataTextField="FABRIC_NAME" AppendDataBoundItems="true"
                                                                        DataValueField="FABRIC_ID" runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CONST">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlFabricConstructionId" DataTextField="FABRIC_CONSTRUCTION_NAME"
                                                                        AppendDataBoundItems="true" DataValueField="FABRIC_CONSTRUCTION_ID" runat="server"
                                                                        Width="90">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="COLOR">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlColorId" DataTextField="COLOR_NAME" DataValueField="COLOR_ID"
                                                                        runat="server" Width="90">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="P.Q">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPOBlance" runat="server" Width="70" Text='<%#Eval("PO_QUANTITY")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="T.R.Q">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBlance" runat="server" Width="70" Text='<%#Eval("BLANCE_QUANTITY")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QTY">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtQuantity" runat="server" Width="70" Text='<%#Eval("QUANTITY")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="MEASURE">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlMeasureId" DataTextField="UNIT_NAME" DataValueField="UNIT_ID"
                                                                        runat="server" Width="50">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE-TK">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRateInDollar" runat="server" Width="50" Text='<%#Eval("RATE_IN_TAKA")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="RATE-TK">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRateInTaka" runat="server" Width="50" Text='<%#Eval("RATE_IN_TAKA")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="ID">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTranId" runat="server" Width="10" Text='<%#Eval("TRAN_ID")%>'
                                                                        BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" OnClientClick="return isDelete();"> Delete </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <%--   <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 118px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Po No :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:TextBox ID="txtPONo" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearchFabricAcceptance" runat="server" Height="25px" Text="Search"
                                                        Width="55px" CssClass="styled-button-4" OnClick="btnSearchFabricAcceptance_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label53" runat="server" Text="From :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 118px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="PI No :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="txtPINo" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label54" runat="server" Text="To :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="dtpToDate" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                                        ForeColor="Black"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>--%>
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
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {

            //            $('[id$=txtChallanNo]').focus();
            $('input:text,select').bind("keydown", function (e) {
                var n = $("input:text,select").length;
                if (e.which == 13) { //Enter key

                    e.preventDefault(); //Skip default behavior of the enter key

                    var nextIndex = $('input:text,select').index(this) + 1;

                    if (nextIndex < n)

                    { $('input:text,select')[nextIndex].focus(); }

                    else {

                        $('input:text,select')[nextIndex - 1].blur();

                        $('[id$=btnAdd]').click();

                    }

                }

            });
        });

    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            $("[id *= txtQuantity]").bind("change", Deductions);

        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();

                    result.total = $("[id *= txtBlance]", row).val();

                    result.totalDeductions = $("[id *= txtQuantity]", row).val();

                    result.netTotal = Math.abs(result.total - result.totalDeductions);

                    $("[id *= txtPOBlance]", row).val(result.netTotal);
                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>
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
