﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="FOBBudgetCost.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.FOBBudgetCost" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        
    </script>
    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");

        }
    </script>
    <%--    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtContractNo.ClientID %>").focus(); }) 
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

    <%--    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>--%>
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
        <legend>FOB BUDGET COST INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 804px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>FOB BUDGET COST ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 343px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label65" runat="server" Text="Buyer :"></asp:Label>
                                </td>
                                   <td style="width: 255px; text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="156px" AutoPostBack="true"
                                        Height="23px" OnSelectedIndexChanged="ddlBuyerId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearchContractId" runat="server" Height="22px" Text="..."
                                        Width="30px" CssClass="styled-button-4" OnClick="btnSearchContractId_Click" />
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 208px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label46" runat="server" Text="FOB Date :" CssClass="date"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="dtpFOBDate" runat="server" Width="152px" BackColor="Yellow" Font-Bold="False"
                                        Placeholder="dd/mm/yyyy"
                                        CssClass="date" ForeColor="Black" ReadOnly="True" Height="22px"></asp:TextBox>
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;">&nbsp;</td>
                                <td style="height: 22px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 343px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Contract No :"></asp:Label>
                                </td>
                                <td style="width: 255px; text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlContractId" runat="server" Width="156px" AutoPostBack="true"
                                        Height="23px" OnSelectedIndexChanged="ddlContractId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearchPOId" runat="server" Height="22px" Text="..."
                                        Width="30px" CssClass="styled-button-4" OnClick="btnSearchPOId_Click" />
                                </td>
                                <td style="width: 208px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label57" runat="server" Text="Season  :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlSeasonId" runat="server" Width="156px" Height="23px"
                                        OnSelectedIndexChanged="ddlSeasonId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;"></td>
                                <td style="height: 22px"></td>
                            </tr>
                            <tr>
                                <td style="width: 343px; text-align: right">
                                    <asp:Label ID="Label49" runat="server" Text="Po No :"></asp:Label>
                                </td>
                                <td style="width: 255px; text-align: left;">
                                    <asp:DropDownList ID="ddlPOId" runat="server" Width="156px" AutoPostBack="true"
                                        Height="23px" OnSelectedIndexChanged="ddlPOId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearchStyleId" runat="server" Height="22px" Text="..."
                                        Width="30px" CssClass="styled-button-4" OnClick="btnSearchStyleId_Click" />
                                </td>
                                <td style="width: 208px; text-align: right;">
                                    <asp:Label ID="Label66" runat="server" Text="Amendment Date :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left;">
                                    <asp:TextBox ID="dtpAmendmentDate" runat="server" Width="154px" Font-Bold="False"
                                        Placeholder="dd/mm/yyyy"
                                        CssClass="date" ForeColor="Black" Height="22px"></asp:TextBox>
                                </td>
                                <td style="width: 238px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 343px; text-align: right">
                                    <asp:Label ID="Label59" runat="server" Text="Style No :"></asp:Label>
                                </td>
                                <td style="width: 255px; text-align: left;">
                                    <asp:DropDownList ID="ddlStyleId" runat="server" Width="156px" AutoPostBack="true"
                                        Height="23px" OnSelectedIndexChanged="ddlStyleId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearchOthers" runat="server" Height="22px" Text="..."
                                        Width="30px" CssClass="styled-button-4" OnClick="btnSearchOthers_Click" />
                                </td>
                                <td style="width: 208px; text-align: right;">
                                    <asp:Label ID="Label68" runat="server" Text="Order quantity :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left;">
                                    <asp:TextBox ID="txtOrderQuantity" runat="server" Width="154px" Font-Bold="False"
                                        ForeColor="Black" Height="22px" BackColor="Yellow"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 238px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="text-align: right" colspan="6">
                                    <%--<legend>ZIPPER L/C RECEIVE ENTRY </legend>--%>
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvContractDetails" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                    DataKeyNames="TRAN_ID" OnRowDataBound="gvContractDetails_OnRowDataBound" AllowSorting="True"
                                                    EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="gvContractDetails_OnRowEditing"
                                                    OnRowDeleting="gvContractDetails_RowDeleting" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                                    OnSelectedIndexChanged="gvContractDetails_OnSelectedIndexChanged" CausesValidation="false"
                                                    OnRowCommand="gvContractDetails_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                    OnPageIndexChanging="gvContractDetails_OnSelectedIndexChanged">
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="PARTICULARS" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFabricId" DataTextField="fabric_name" DataValueField="fabric_ID"
                                                                    AutoPostBack="false"
                                                                    runat="server" Width="180">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="SUPPLIER NAME" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlSupplierId" DataTextField="SUPPLIER_NAME" DataValueField="SUPPLIER_ID"
                                                                    runat="server" Width="180">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ART " ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlArtId" DataTextField="ART_NO" DataValueField="ART_ID"
                                                                    runat="server" Width="80">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="GROUP" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlSizeId" DataTextField="SIZE_NAME" DataValueField="SIZE_ID"
                                                                    runat="server" Width="50">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CONSUMPTION" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtConsumption" runat="server" Text='<%#Eval("CONSUMPTION")%> '
                                                                    OnTextChanged="txtConsumption_TextChanged" AutoPostBack="false"
                                                                    Width="100" Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="PRICE($)" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("PRICE")%> ' Width="100"
                                                                    OnTextChanged="txtPrice_TextChanged" AutoPostBack="false"
                                                                    Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="T.PRICE" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTotalPrice" runat="server" Text='<%#Eval("TOTAL_PRICE")%> ' BackColor="Yellow"
                                                                    Font-Bold="true" Width="70"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="QTY" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtBudgetQtyInYds" runat="server" Text='<%#Eval("BUDGET_QTY_IN_YDS")%> '
                                                                    OnTextChanged="txtBudgetQtyInYds_TextChanged" AutoPostBack="false"
                                                                    Width="70"
                                                                    Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="B. VALUE" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtBudgetValue" runat="server" Text='<%#Eval("BUDGET_VALUE")%> '
                                                                    BackColor="Yellow"
                                                                    Font-Bold="true" Width="70"></asp:TextBox>
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
                                    </table>
                    </fieldset>
                </td>
                <td style="text-align: right">&nbsp;</td>
                <td style="text-align: right">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left; width: 343px;">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left; width: 255px;">&nbsp;</td>
                <td style="text-align: left" colspan="2">&nbsp;</td>
                <td style="text-align: left">&nbsp;</td>
                <td style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="6">
                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                </td>
            </tr>
        </table>
    </fieldset>
    </td>
            </tr>
        </table>
    </fieldset>
    <%--    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="js/jquery.js" type="text/javascript"></script>--%>
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

            $("[id *= txtConsumption]").bind("change", Deductions);
            $("[id *= txtPrice]").bind("change", Deductions);
            $("[id *= txtBudgetQtyInYds]").bind("change", Deductions);
        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();


                    resultNew.total = $("[id *= txtConsumption]", row).val();
                    resultNew.totalDeductions = $("[id *= txtPrice]", row).val();
                    resultNew.netTotal = (resultNew.total * resultNew.totalDeductions).toFixed(2);






                    $("[id *= txtTotalPrice]", row).val(resultNew.netTotal);
                  

                    resultNew.totalDeductions = $("[id *= txtPrice]", row).val();



                    //resultNew.totalQty = $("[id *= txtBudgetQtyInYds]", row).val();
                    //resultNew.netBudget = (resultNew.totalQty * resultNew.totalDeductions).toFixed(4);


                    //$("[id *= txtBudgetValue]", row).val(resultNew.netBudget);
                 
                    $("[id *= txtBudgetValue]", row).val(resultNew.netTotal);
                    $("[id *= txtBudgetQtyInYds]", row).val(resultNew.total);

                    
                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table class="style1">
        <tr>
            <td>
                <fieldset>
                    <legend>SEARCH CRITERIA</legend>
                    <table class="style1">
                        <tr>
                            <td style="width: 89px; text-align: right;">
                                <asp:Label ID="Label9" runat="server" Text="Year :"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <asp:TextBox ID="txtYear" runat="server" Height="21px" Width="150px"
                                    Font-Bold="True"></asp:TextBox>
                                <asp:Button ID="btnSearchRecord" runat="server" CssClass="styled-button-4" Height="22px"
                                    Text="...." Width="36px" OnClick="btnSearchRecord_Click" />
                            </td>
                            <td style="width: 163px; text-align: right;">
                                <asp:Label ID="Label13" runat="server" Text="PO No :"></asp:Label>
                            </td>
                            <td style="width: 320px">
                                <asp:DropDownList ID="ddlPOIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">&nbsp;</td>
                            <td style="width: 126px; text-align: right;">
                                <asp:Label ID="Label62" runat="server" Text="Season:"></asp:Label>
                            </td>
                            <td style="width: 79px">
                                <asp:DropDownList ID="ddlSeasonIdSearch" runat="server" Width="156px" Height="23px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; text-align: right;">
                                <asp:Label ID="Label12" runat="server" Text="Contract No: "></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <asp:TextBox ID="txtContractNoSearch" runat="server" Height="21px"
                                    Width="150px"></asp:TextBox>
                            </td>
                            <td style="width: 163px; text-align: right;">
                                <asp:Label ID="Label1" runat="server" Text="Style No :"></asp:Label>
                            </td>
                            <td style="width: 320px">
                                <asp:DropDownList ID="ddlStyleIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">&nbsp;</td>
                            <td style="width: 126px; text-align: right;">
                                <asp:Label ID="Label63" runat="server" Text="Buyer:"></asp:Label>
                            </td>
                            <td style="width: 79px">
                                <asp:DropDownList ID="ddlBuyerIdSearch" runat="server" Width="156px" Height="23px">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; text-align: right;">
                                <asp:Label ID="Label64" runat="server" Text="Issue date: "></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <asp:TextBox ID="dtpIssueDateSearch" runat="server" Height="21px" Width="150px" CssClass="date"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="width: 163px; text-align: right;">
                                <asp:Label ID="Label67" runat="server" Text="Amendment Date :"></asp:Label>
                            </td>
                            <td style="width: 320px">
                                <asp:TextBox ID="dtpAmendmentDateSearch" runat="server" Height="21px"
                                    Width="148px" CssClass="date"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">&nbsp;</td>
                            <td style="width: 126px; text-align: right;">&nbsp;</td>
                            <td style="width: 79px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 89px; text-align: right;">&nbsp;</td>
                            <td style="width: 200px">&nbsp;</td>
                            <td style="width: 163px; text-align: right;">&nbsp;</td>
                            <td style="width: 320px">&nbsp;</td>
                            <td style="text-align: right;">&nbsp;</td>
                            <td style="width: 126px; text-align: right;">&nbsp;</td>
                            <td style="width: 79px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </fieldset>


            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>SEARCH RESULT</legend>
                    <asp:GridView ID="gvForeignFabric" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvForeignFabric_PageIndexChanging"
                        CausesValidation="false" DataKeyNames=""
                        OnSelectedIndexChanged="gvForeignFabric_SelectedIndexChanged"
                        OnRowCommand="gvForeignFabric_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CONTRACT_NO" HeaderText="CONTRACT NO" />
                            <asp:BoundField DataField="FOB_DATE" HeaderText="FOB DATE" />
                            <asp:BoundField DataField="AMENDMENT_DATE" HeaderText="AMENDMENT DATE" />

                            <asp:BoundField DataField="PO_NO" HeaderText="PO" />
                            <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE" />
                            <asp:BoundField DataField="BUYER_NAME" HeaderText="BUYER" />
                            <asp:BoundField DataField="SEASON_NAME" HeaderText="SEASON" />

                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </fieldset>
            </td>
        </tr>
    </table>
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