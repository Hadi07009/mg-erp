<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ForeignFabricReceive.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ForeignFabricReceive" %>


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

                        $('#btnAdd').click();

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
        $(window).load(function () { document.getElementById("<%= txtInvoiceNo.ClientID %>").focus(); }) 
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
        <legend>FOREIGN FABRIC RECEIVE INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <fieldset>
                        <legend>FOREIGN FABRIC RECEIVE</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 420px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Invoice No :"></asp:Label>
                                </td>
                                <td style="width: 251px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtInvoiceNo" runat="server" Width="148px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 208px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label49" runat="server" Text="LC No :"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtLCNo" runat="server" Width="150px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label57" runat="server" Text="Importer :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:DropDownList ID="ddlImporterId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 420px; text-align: right">
                                    <asp:Label ID="Label46" runat="server" Text="Receive Date :" CssClass="date"></asp:Label>
                                </td>
                                <td style="width: 251px; text-align: left;">
                                    <asp:TextBox ID="dtpReceiveDate" runat="server" Width="150px" BackColor="White" Font-Bold="False"
                                        Placeholder="dd/mm/yyyy"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 208px; text-align: right;">
                                    <asp:Label ID="Label47" runat="server" Text="Buyer Name:"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left;">
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="156px"
                                        Height="23px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right;">
                                    <asp:Label ID="Label61" runat="server" Text="Shipment :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlShipmentTypeId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 420px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label60" runat="server" Text="Shipment No :" CssClass="date"></asp:Label>
                                </td>
                                <td style="width: 251px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtShipmentNo" runat="server" Width="150px" BackColor="White" Font-Bold="False"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 208px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label59" runat="server" Text="Supplier:"></asp:Label>
                                </td>
                                <td style="width: 238px; text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="156px"
                                        Height="23px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label62" runat="server" Text="Store :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:DropDownList ID="ddlBranchOfficeId" runat="server" Width="154px"
                                        Height="22px">
                                    </asp:DropDownList>
                                </td>
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
                                                        <asp:TemplateField HeaderText="PROGRAMME" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlprogrammeId" DataTextField="PROGRAMME_NAME" DataValueField="PROGRAMME_ID"
                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddlProgrammeId_SelectedIndexChanged"
                                                                    runat="server" Width="130">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="FABRIC" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFabricId" DataTextField="FABRIC_NAME" DataValueField="FABRIC_ID"
                                                                    runat="server" Width="100">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="FABRIC CON" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlFabricConstructionId" DataTextField="FABRIC_CONSTRUCTION_NAME"
                                                                    DataValueField="FABRIC_CONSTRUCTION_ID"
                                                                    runat="server" Width="100">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="STYLE" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlStyleId" DataTextField="STYLE_NO" DataValueField="STYLE_ID"
                                                                    runat="server" Width="100">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="COLOR" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlColorId" DataTextField="COLOR_NAME" DataValueField="COLOR_ID"
                                                                    runat="server" Width="75">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ART " ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlArtId" DataTextField="ART_NO" DataValueField="ART_ID"
                                                                    runat="server" Width="75">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="UNIT" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlUnitId" DataTextField="UNIT_NAME" DataValueField="UNIT_ID"
                                                                    runat="server" Width="50">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CURRENCY" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlCurrencyId" DataTextField="CURRENCY_NAME" DataValueField="CURRENCY_ID"
                                                                    runat="server" Width="50">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("RATE")%> '
                                                                    Width="50" Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="WIDTH" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtWidth" runat="server" Text='<%#Eval("WIDTH")%> ' Width="50" Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="ROLL" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtNumberOfRoll" runat="server" Text='<%#Eval("NUM_OF_ROLL")%> '
                                                                    Font-Bold="true" Width="50"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="QTY" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtReceiveQuantity" runat="server" Text='<%#Eval("RECEIVE_QUANTITY")%> '
                                                                    Width="50"
                                                                    Font-Bold="true"></asp:TextBox>
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
                <td style="text-align: left;" colspan="6">
                    <asp:TextBox ID="txtTotalReceiveQuantity" runat="server" Height="21px"
                        Width="108px" placeholder="RECEIVE QUANTITY"
                        Font-Bold="True" BackColor="Yellow" ReadOnly="True"
                        ToolTip="Receive Quantity"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="6">
                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                        CssClass="styled-button-4" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="6">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
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
                    resultNew.netTotal = resultNew.total * resultNew.totalDeductions;






                    $("[id *= txtTotalPrice]", row).val(resultNew.netTotal);

                    resultNew.totalDeductions = $("[id *= txtPrice]", row).val();

                    resultNew.totalQty = $("[id *= txtBudgetQtyInYds]", row).val();
                    resultNew.netBudget = resultNew.totalQty * resultNew.totalDeductions;


                    $("[id *= txtBudgetValue]", row).val(resultNew.netBudget);
                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>


    </td>
            </tr>
        </table>
    </fieldset>
    
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table class="style1">
        <tr>
            <td>
                <fieldset>
                    <legend>SEARCH FOREIGN FABRIC RECEIVE </legend>
                    <table class="style1">
                        <tr>
                            <td style="width: 91px; text-align: right; height: 28px;">
                                <asp:Label ID="Label12" runat="server" Text="Year : "></asp:Label>
                            </td>
                            <td style="width: 210px; height: 28px;">
                                <asp:TextBox ID="txtYear" runat="server" Height="20px"
                                    Width="108px" Font-Bold="True"></asp:TextBox>
                                <asp:Button ID="btnSearchRecord" runat="server" CssClass="styled-button-4" Height="22px"
                                    Text="...." Width="36px" OnClick="btnSearchRecord_Click" />
                            </td>
                            <td style="width: 110px; text-align: right; height: 28px;">
                                <asp:Label ID="Label13" runat="server" Text="LC No :"></asp:Label>
                            </td>
                            <td style="height: 28px;">
                                <asp:TextBox ID="txtLCNoSearch" runat="server" Height="21px" Width="148px"
                                    Font-Bold="True"></asp:TextBox>
                            </td>
                            <td style="text-align: right; width: 100px; height: 28px;">
                                <asp:Label ID="Label1" runat="server" Text="Buyer :"></asp:Label>
                            </td>
                            <td style="width: 12px; height: 28px;">
                                <asp:DropDownList ID="ddlBuyerIdSearch" runat="server" Height="22px"
                                    Width="130px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 79px; height: 28px; text-align: right;">
                                <asp:Label ID="Label23" runat="server" Text="Importer : "></asp:Label>
                            </td>
                            <td style="height: 28px">
                                <asp:DropDownList ID="ddlImporterIdSearch" runat="server" Height="24px"
                                    Width="130px" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 91px; text-align: right;">
                                <asp:Label ID="Label9" runat="server" Text="Invoice No :"></asp:Label>
                            </td>
                            <td style="width: 210px">
                                <asp:TextBox ID="txtInvoiceNoSearch" runat="server" Height="20px" Width="108px"
                                    Font-Bold="True" OnTextChanged="txtInvoiceNoSearch_TextChanged"></asp:TextBox>
                            </td>
                            <td style="width: 110px; text-align: right;">
                                <asp:Label ID="Label25" runat="server" Text="Shipment No :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtShipmentNoSerch" runat="server" Height="21px" Width="145px"></asp:TextBox>
                            </td>
                            <td style="text-align: right; width: 100px">
                                <asp:Label ID="Label24" runat="server" Text="Supplier : "></asp:Label>
                            </td>
                            <td style="width: 12px; text-align: justify;">
                                <asp:DropDownList ID="ddlSupplierIdSearch" runat="server" Height="18px"
                                    Width="130px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 79px; text-align: right;">
                                <asp:Label ID="Label50" runat="server" Text="Shipment :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlShipmentTypeIdSearch" runat="server" Height="22px"
                                    Width="130px">
                                </asp:DropDownList>
                            </td>
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
                        CausesValidation="false" DataKeyNames="TRAN_ID"
                        OnSelectedIndexChanged="gvForeignFabric_SelectedIndexChanged"
                        OnRowCommand="gvForeignFabric_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="INVOICE_NO" HeaderText="INVOICE NO" />
                            <asp:BoundField DataField="RECEIVE_DATE" HeaderText="DATE" />

                            <asp:BoundField DataField="LC_NO" HeaderText="LC NO" />
                            <asp:BoundField DataField="BUYER_NAME" HeaderText="BUYER" />
                            <asp:BoundField DataField="IMPORTER_NAME" HeaderText="IMPORTER" />
                            <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />
                            <asp:BoundField DataField="SHIPMENT_NO" HeaderText="SHIPMENT" />
                            <asp:BoundField DataField="SHIPMENT_TYPE_NAME" HeaderText="SHIPMENT NAME" />


                            <asp:BoundField DataField="TRAN_ID" HeaderText="ID" />

                          <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
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
