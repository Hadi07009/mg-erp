﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="SewingThreadPriceEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.SewingThreadPriceEntry" %>

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
        function isDelete() {
            return confirm("Do you want to delete this row ?");

        }
    </script>
    <%--<script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtPONo.ClientID %>").focus(); }) 
    </script>--%>
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
        <legend>SEWING THREAD PRICE LIST INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 804px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left"></td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>SEWING THREAD PRICE LIST ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 236px; text-align: left; height: 22px;">&nbsp;</td>
                                <td style="text-align: right; height: 22px;">
                                    <asp:Label ID="lblPOType" runat="server" Text="Supplier :"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="240px"
                                        Height="22px">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 168px; text-align: right;">&nbsp;</td>


                            </tr>
                            <tr>
                                <td style="width: 236px; text-align: left; height: 15px;"></td>
                                <td style="text-align: right;" class="style3"></td>
                                <td style="text-align: left;" class="style3">
                                    <%--<asp:TextBox ID="txtPoType" runat="server" Width="236px" BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>--%>
                                </td>
                                <td class="style3"></td>


                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEWING THREAD PRICE LIST SEARCH</legend>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvPOEntry" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        DataKeyNames="TRAN_ID" OnRowDataBound="gvPOEntry_OnRowDataBound" AllowSorting="True"
                                                        EnableViewState="true" GridLines="None" AllowPaging="false"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr"
                                                        OnSelectedIndexChanged="gvPOEntry_OnSelectedIndexChanged" CausesValidation="false"
                                                        OnRowCommand="gvPOEntry_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvPOEntry_OnSelectedIndexChanged"
                                                        OnRowDeleting="gvPOEntry_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="THREAD COUNT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtThreadCount" runat="server" Text='<%#Eval("THREAD_COUNT")%> '
                                                                        Width="200"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="COLOR" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlColorId" DataTextField="COLOR_NAME" DataValueField="COLOR_ID"
                                                                        runat="server" Width="150">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPriceRate" runat="server" Text='<%#Eval("RATE")%> ' Width="150"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="CURRENCY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlCurrencyId" DataTextField="CURRENCY_NAME" DataValueField="CURRENCY_ID"
                                                                        runat="server" Width="150">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BRAND" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlBrandId" DataTextField="BRAND_NAME" DataValueField="BRAND_ID"
                                                                        runat="server" Width="230">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTranId" runat="server" Text='<%#Eval("TRAN_ID")%> ' Width="10"
                                                                        DataField="TRAN_ID" BackColor="Yellow" ReadOnly="true" SortExpression="TRAN_ID"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                                        AlternateText="Delete"
                                                                        Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                                        Height="25px" Visible="true" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                                        Font-Names="Tahoma"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 33px;" colspan="4">
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4"></td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
    <%--   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <%-- <script src="js/jquery.js" type="text/javascript"></script>--%>
    <script type="text/javascript">
        $(document).ready(function () {

            //            $('[id$=txtPO]').focus();
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

            $("[id *= txtUnitRate]").bind("change", Deductions);
            $("[id *= txtQuantity]").bind("change", Deductions);
        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();

                    result.UnitRate = $("[id *= txtUnitRate]", row).val();
                    result.Quantity = $("[id *= txtQuantity]", row).val();

                    result.Amount = result.UnitRate * result.Quantity;
                    $("[id *= txtAmount]", row).val(result.Amount);
                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2"></td>
        </tr>
    </table>
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