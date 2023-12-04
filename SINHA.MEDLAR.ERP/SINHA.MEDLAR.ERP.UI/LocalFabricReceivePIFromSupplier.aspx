﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="LocalFabricReceivePIFromSupplier.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.LocalFabricReceivePIFromSupplier" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script type="text/javascript">
    function SwitchOnEnter(e, NextTextBox) {
        var keynum
        var keychar
        var numcheck

        if (window.event) // IE
        {
            keynum = e.keyCode
        }
        else if (e.which) // Netscape/Firefox/Opera
        {
            keynum = e.which
        }
        if (keynum == 13) {
            document.getElementById(NextTextBox).focus();
        }
    }
</script>
    <script type="text/javascript">

        $(document).ready(function () {

            $('input:text:first').focus();
            $('input:text,select').bind("keydown", function (e) {
                var n = $("input:text,select").length;
                if (e.which == 13) { //Enter key

                    e.preventDefault(); //Skip default behavior of the enter key

                    var nextIndex = $('input:text,select').index(this) + 1;

                    if (nextIndex < n)

                    { $('input:text,select')[nextIndex].focus(); }

                    else {

                        $('input:text,select')[nextIndex - 1].blur();

                        $('#btnADD').click();

                    }

                }

            });
        
    </script>--%>
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <%--    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtPO.ClientID %>").focus(); }) 
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
                document.getElementById('<%= btnCalculation.ClientID %>').click();
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
        <legend>FABRIC RECEIVE PI FROM SUPPLIER</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 603px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>FABRIC ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 313px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="PO No:"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtPO" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label32" runat="server" Text="Supplier :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="160px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 313px; text-align: right">
                                    <asp:Label ID="Label47" runat="server" Text="PI No :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtPI" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:TextBox ID="txtReferenceNo" runat="server" Width="51px" BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    <asp:Label ID="Label46" runat="server" Text="Receive Date :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="dtpReceiveDate" runat="server" Width="156px" BackColor="White" Font-Bold="True"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 313px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>LOCAL FABRIC RECEIVE PI ENTRY </legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvFabricDetails" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvFabricDetails_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" OnRowEditing="gvFabricDetails_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvFabricDetails_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvFabricDetails_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvFabricDetails_OnSelectedIndexChanged">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="PROGRAMME" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlProgrammeId" DataTextField="PROGRAMME_NAME" AppendDataBoundItems="true"
                                                                        DataValueField="PROGRAMME_ID" runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="FABRIC" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlFabricId" DataTextField="FABRIC_NAME" DataValueField="FABRIC_ID"
                                                                        runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CONSTRUCT." ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlFabricConstructionId" DataTextField="FABRIC_CONSTRUCTION"
                                                                        DataValueField="FABRIC_CONSTRUCTION_ID" runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="COLOR" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlColorId" DataTextField="COLOR_NAME" DataValueField="COLOR_ID"
                                                                        runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="MEASURE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlMeasureId" DataTextField="MEASURE_NAME" DataValueField="MEASURE_ID"
                                                                        runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CURRENCY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlCurrencyId" DataTextField="CURRENCY_NAME" DataValueField="CURRENCY_ID"
                                                                        runat="server" Width="80">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRate" runat="server" Width="50" Text='<%#Eval("RATE")%> '></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QUANTITY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtQuantity" runat="server" Width="50" Text='<%#Eval("QUANTITY")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BLANCE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBlance" runat="server" Width="40" Text='<%#Eval("BLANCE")%>'
                                                                        BackColor="Yellow"></asp:TextBox>
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
                                    <asp:Button ID="btnCalculation" runat="server" Height="31px" Text="Calculation" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnCalculation_Click" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    &nbsp;
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
    <div style="width: 100%; overflow: auto;">
        <fieldset>
            <legend>ENTRY RESULT</legend>
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                            AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                            CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                            AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                            OnRowDataBound="OnRowDataBound" CausesValidation="false" OnRowCommand="gvEmployeeList_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="SL" HeaderText="SL" />
                                <asp:BoundField DataField="PO_NO" HeaderText="PO NO" />
                                <asp:BoundField DataField="PI_NO" HeaderText="PI NO" />
                                <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />
                                <asp:BoundField DataField="RECEIVE_DATE" HeaderText="ID" />
                                <asp:BoundField DataField="PROGRAMME_NAME" HeaderText="PROGRAMME" />
                                <asp:BoundField DataField="FABRIC_NAME" HeaderText="FABRIC" />
                                <asp:BoundField DataField="FABRIC_CONSTRUCTION" HeaderText="CONSTRUCTION" />
                                <asp:BoundField DataField="COLOR_NAME" HeaderText="COLOR" />
                                <asp:BoundField DataField="MEASURE_NAME" HeaderText="MEASURE" />
                                <asp:BoundField DataField="CURRENCY_NAME" HeaderText="CURRENCY" />
                                <asp:BoundField DataField="RATE" HeaderText="RATE" />
                                <asp:BoundField DataField="QUANTITY" HeaderText="QTY" />
                                <asp:BoundField DataField="BLANCE" HeaderText="BLANCE" />
                                <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                            Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <script src="js/jquery.js" type="text/javascript"></script>
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

            $("[id *= txtQuantity]").bind("change", Deductions);

        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();

                    result.total = $("[id *= txtRate]", row).val();

                    result.totalDeductions = $("[id *= txtQuantity]", row).val();

                    result.netTotal = result.total * result.totalDeductions;

                    $("[id *= txtBlance]", row).val(result.netTotal);
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