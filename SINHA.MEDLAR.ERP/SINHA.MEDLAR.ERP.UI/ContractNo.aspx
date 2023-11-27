<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ContractNo.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ContractNo" %>

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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtContractNo.ClientID %>").focus(); }) 
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

    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
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
        <legend>VENDOR CONTRACT NO. & DT</legend>
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
                        <legend>VENDOR CONTRACT NO. & DT ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 313px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Contract No :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtContractNo" runat="server" Width="150px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label46" runat="server" Text="Issue Date :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="dtpIssueDate" runat="server" Width="150px" BackColor="White" Font-Bold="False"
                                        Placeholder="dd/mm/yyyy"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label32" runat="server" Text="Vendor :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:DropDownList ID="ddlVendorId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 313px; text-align: right">
                                    <asp:Label ID="Label49" runat="server" Text="Manufacturer :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlManufacturerId" runat="server" Width="154px"
                                        Height="22px"
                                        OnSelectedIndexChanged="ddlManufacturerId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    <asp:Label ID="Label59" runat="server" Text="Ship :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left;">
                                    <asp:DropDownList ID="ddlShipId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    <asp:Label ID="Label50" runat="server" Text="V Bank :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlVendorBankId" runat="server" Width="154px"
                                        Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 313px; text-align: right">
                                    <asp:Label ID="Label47" runat="server" Text="Bank :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlManufacturerBankId" runat="server" Width="154px"
                                        Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    <asp:Label ID="Label57" runat="server" Text="Mode :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left;">
                                    <asp:DropDownList ID="ddlShipTypeId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    <asp:Label ID="Label60" runat="server" Text="Term :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPaymentTermId" runat="server" Width="154px"
                                        Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 313px; text-align: right">
                                    <asp:Label ID="Label61" runat="server" Text="Amendment Date :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="dtpAmendmentDate" runat="server" Width="150px" BackColor="White"
                                        Font-Bold="True" CssClass="date" ForeColor="Black"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    <asp:Label ID="Label64" runat="server" Text="Buyer :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left;">
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="154px"
                                        Height="22px">
                                    </asp:DropDownList>
                                    &nbsp;
                                </td>
                                <td style="width: 238px; text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="6">
                                    <fieldset>
                                        <legend>ZIPPER L/C RECEIVE ENTRY </legend>
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


                                                            <asp:TemplateField HeaderText="PO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPONo" runat="server" Text='<%#Eval("PO_NO")%> ' Width="90"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="STYLE NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtStyleNo" runat="server" Text='<%#Eval("STYLE_NO")%> ' Width="80"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ITEM" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtItemName" runat="server" Text='<%#Eval("ITEM_NAME")%> ' Width="110"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SIZE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlSizeId" DataTextField="SIZE_NAME" DataValueField="SIZE_ID"
                                                                        runat="server" Width="40">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="SEASON" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlSeasonId" DataTextField="SEASON_NAME" DataValueField="SEASON_ID"
                                                                        runat="server" Width="50">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("RATE")%> '
                                                                        Font-Bold="true" Width="30"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtOrderQuantity" runat="server" Text='<%#Eval("ORDER_QUANTITY")%> '
                                                                        OnTextChanged="txtOrderQuantity_TextChanged" AutoPostBack="false"
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="PRICE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPOPrice" runat="server" Text='<%#Eval("PO_PRICE")%> ' Width="40"
                                                                        OnTextChanged="txtPOPrice_TextChanged" AutoPostBack="false"
                                                                        Font-Bold="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="H.COST" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtHangerCostPerUnit" runat="server" Text='<%#Eval("HANGER_COST_PER_UNIT")%> '
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="HS.CODE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtHSCode" runat="server" Text='<%#Eval("HS_CODE")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="U.C" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtUnitCost" runat="server" Text='<%#Eval("UNIT_COST")%> ' Width="50"
                                                                        Font-Bold="true" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="AMT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTotalAmount" runat="server" Text='<%#Eval("TOTAL_AMOUNT_IN_USD")%> '
                                                                        Font-Bold="true" Width="60" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SHIPPING ADDRESS" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtShipingAddress" runat="server" Text='<%#Eval("SHIPPING_ADDRESS")%> '
                                                                        Width="120"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SHIP DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="dtpShippingDate" runat="server" Text='<%#Eval("SHIPPING_DATE")%> '
                                                                        CssClass="date" Width="70"></asp:TextBox>
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
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="6">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="6">
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" Visible="False" />
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
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
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

            $("[id *= txtRate]").bind("change", Deductions);
            $("[id *= txtPOPrice]").bind("change", Deductions);
            $("[id *= txtUnitCost]").bind("change", Deductions);
            $("[id *= txtOrderQuantity]").bind("change", Deductions);

            
        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();



                    result.totalRate = $("[id *= txtRate]", row).val();
                    result.total = $("[id *= txtPOPrice]", row).val();

                    result.netTotal = (result.total * result.totalRate).toFixed(4)
                    $("[id *= txtUnitCost]", row).val(result.netTotal);


                    resultNew.total = $("[id *= txtUnitCost]", row).val();
                    resultNew.totalDeductions = $("[id *= txtOrderQuantity]", row).val();


                    resultNew.netTotal = Math.round(resultNew.total * resultNew.totalDeductions).toFixed(2);


                    $("[id *= txtTotalAmount]", row).val(resultNew.netTotal);
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
                            <td style="width: 130px; text-align: right;">
                                <asp:Label ID="Label9" runat="server" Text="Year :"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <asp:TextBox ID="txtYear" runat="server" Height="21px" Width="150px"
                                    Font-Bold="True" OnTextChanged="txtYear_TextChanged"></asp:TextBox>
                                <asp:Button ID="btnSearchRecord" runat="server" CssClass="styled-button-4" Height="22px"
                                    Text="...." Width="36px" OnClick="btnSearchRecord_Click" />
                            </td>
                            <td style="width: 163px; text-align: right;">
                                <asp:Label ID="Label65" runat="server" Text="Buyer :"></asp:Label>
                            </td>
                            <td style="width: 320px">
                                <asp:DropDownList ID="ddlBuyerIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;">&nbsp;</td>
                            <td style="width: 118px; text-align: right;">&nbsp;</td>
                            <td style="width: 79px">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 130px; text-align: right; height: 27px;">
                                <asp:Label ID="Label12" runat="server" Text="Contract No: "></asp:Label>
                            </td>
                            <td style="width: 200px; height: 27px;">
                                <asp:DropDownList ID="ddlContractId" runat="server" Height="22px" AutoPostBack="true"
                                    Width="152px" OnSelectedIndexChanged="ddlContractId_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 163px; text-align: right; height: 27px;">
                                <asp:Label ID="Label62" runat="server" Text="Issue Date:"></asp:Label>
                            </td>
                            <td style="width: 320px; height: 27px;">
                                <asp:TextBox ID="dtpIssueDateSearch" runat="server" Height="21px" Width="148px" CssClass="date"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="text-align: right; height: 27px;"></td>
                            <td style="width: 118px; text-align: right; height: 27px;">&nbsp;</td>
                            <td style="width: 79px; height: 27px;">&nbsp;</td>
                            <td style="height: 27px"></td>
                        </tr>
                        <tr>
                            <td style="width: 130px; text-align: right;">
                                <asp:Label ID="Label66" runat="server" Text="Amendment No :"></asp:Label>
                            </td>
                            <td style="width: 200px">
                                <asp:DropDownList ID="ddlAmendmentId" runat="server" Height="22px"
                                    Width="152px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 163px; text-align: right;">
                                <asp:Label ID="Label63" runat="server" Text="Amendment Date:"></asp:Label>
                            </td>
                            <td style="width: 320px">
                                <asp:TextBox ID="dtpAmendmentDateSearch" runat="server" Height="21px" Width="148px"
                                    CssClass="date"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="text-align: right;">&nbsp;</td>
                            <td style="width: 118px; text-align: right;">&nbsp;</td>
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
                            <asp:BoundField DataField="ISSUE_DATE" HeaderText="ISSUE DATE" />
                            <asp:BoundField DataField="AMENDMENT_DATE" HeaderText="AMENDMENT DATE" />
                            <asp:BoundField DataField="amendment_name" HeaderText="AMENDMENT NO" />
                            <asp:BoundField DataField="BUYER_NAME" HeaderText="BUYER" />



                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"
                                        AlternateText="Select" />
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
