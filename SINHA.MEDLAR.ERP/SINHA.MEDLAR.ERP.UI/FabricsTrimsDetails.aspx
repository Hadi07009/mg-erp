<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="FabricsTrimsDetails.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.FabricsTrimsDetails" %>

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
    <script type="text/javascript" language="javascript">

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
    <%--
     <script>
         $(function () {
             $(".date").datepicker({
                 changeMonth: true,
                 changeYear: true,
                 dateFormat: 'dd/mm/yy'
             });
         });
    </script>--%>
    <script type="text/javascript" language="javascript">
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
        <legend>TRIMS DETAILS INFO</legend>
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
                        <legend>TRIMS DETAILS ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 365px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Contract No :"></asp:Label>
                                </td>
                                <td style="width: 281px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtContractNo" runat="server" Width="100px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 436px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label46" runat="server" Text="FOB Date :"></asp:Label>
                                </td>
                                <td style="width: 381px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtFobDate" runat="server" Width="130px" BackColor="White" Font-Bold="True"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 512px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label49" runat="server" Text="FOB Org. Date :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="txtFobOriginalDate" runat="server" Width="120px" BackColor="White"
                                        Font-Bold="True" CssClass="date" ForeColor="Black" Height="18px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 365px; text-align: right">
                                    <asp:Label ID="lblPONO" runat="server" Text="P.O No :"></asp:Label>
                                </td>
                                <td style="width: 281px; text-align: left;">
                                    <asp:TextBox ID="txtPONo" runat="server" Width="130px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 436px; text-align: right;">
                                    <asp:Label ID="lblPONO0" runat="server" Text="Style No :"></asp:Label>
                                </td>
                                <td style="width: 381px; text-align: left;">
                                    <asp:TextBox ID="txtStyleNo" runat="server" Width="130px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 512px; text-align: right;">
                                    <asp:Label ID="lblBuyer" runat="server" Text="Buyer :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="125px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 365px; text-align: right">
                                    &nbsp;</td>
                                <td style="width: 281px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 436px; text-align: right;">
                                    &nbsp;</td>
                                <td style="width: 381px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 512px; text-align: right;">
                                    <asp:Label ID="lblSeason" runat="server" Text="Season :"></asp:Label>
                                  
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSeasonId" runat="server" Width="125px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 365px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 281px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 436px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="width: 381px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 512px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="6">
                                    <fieldset>
                                        <legend>ZIPPER L/C RECEIVE ENTRY </legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvTrimsDetails" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvTrimsDetails_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" OnRowEditing="gvTrimsDetails_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvTrimsDetails_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvTrimsDetails_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvTrimsDetails_OnSelectedIndexChanged">
                                                        <Columns>
                                                             <asp:TemplateField HeaderText="FABDEC" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtFebricsDescrition" runat="server" Text='<%#Eval("FABRICS_DESCRIPTION")%> ' Font-Bold="true"
                                                                        Width="80"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SUPPLIER" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlSupplierId" DataTextField="SUPPLIER_NAME" DataValueField="SUPPLIER_ID"
                                                                        runat="server" Width="50">
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
                                                            <asp:TemplateField HeaderText="CONSUM" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtConsumtion" runat="server" Text='<%#Eval("CONSUMPTION")%> ' Font-Bold="true"
                                                                        Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PRICE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("PRICE")%> ' Width="40" Font-Bold="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PX/PC" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTotalPrice" runat="server" Text='<%#Eval("TOTAL_PRICE")%> ' Font-Bold="true"
                                                                        Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="B.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBudgetQtyInYds" runat="server" Text='<%#Eval("BUDGET_QTY_IN_YDS")%> '
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="B.VALUE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBudgetValue" runat="server" Text='<%#Eval("BUDGET_VALUE")%> '
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActualQtyInYds" runat="server" Text='<%#Eval("ACTUAL_QTY_IN_YDS")%> '
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A.PRICE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActualPrice" runat="server" Text='<%#Eval("ACTUAL_PRICE")%> '
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A.VALUE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActualValue" runat="server" Text='<%#Eval("ACTUAL_VALUE")%> '  ReadOnly="true" BackColor="Yellow"
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="P.GMTS" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActualPerGmts" runat="server" Text='<%#Eval("ACTUAL_PER_GMT")%> '
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="VARI" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtVariance" runat="server" Text='<%#Eval("VARIANCE")%> ' Font-Bold="true"  ReadOnly="true" BackColor="Yellow"
                                                                        Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTranId" runat="server" Text='<%#Eval("TRAN_ID")%> ' Width="30"
                                                                        BackColor="Yellow" ReadOnly="true"></asp:TextBox>
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
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSheet_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="6">
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
    <%--<script src="js/jquery.js" type="text/javascript"></script>--%>
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

            $("[id *= txtConsumtion]").bind("change", Deductions);
            $("[id *= txtPrice]").bind("change", Deductions);
            $("[id *= txtTotalPrice]").bind("change", Deductions);

            $("[id *= txtActualPerGmts]").bind("change", Deductions);
            $("[id *= txtVariance]").bind("change", Deductions);

            $("[id *= txtActualQtyInYds]").bind("change", Deductions);
            $("[id *= txtActualPrice]").bind("change", Deductions);
            $("[id *= txtActualValue]").bind("change", Deductions);

        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();
                    var resultNew1 = new Object();
                    var resultNew2 = new Object();

                    resultNew.total = $("[id *= txtConsumtion]", row).val();
                    resultNew.totalDeductions = $("[id *= txtPrice]", row).val();
                    resultNew.netTotal = resultNew.total * resultNew.totalDeductions;
                    $("[id *= txtTotalPrice]", row).val(resultNew.netTotal);


                    resultNew2.total = $("[id *= txtActualQtyInYds]", row).val();
                    resultNew2.totalDeductions = $("[id *= txtActualPrice]", row).val();
                    resultNew2.netTotal = resultNew2.total * resultNew2.totalDeductions;
                    $("[id *= txtActualValue]", row).val(resultNew2.netTotal);

                    resultNew1.total = $("[id *= txtTotalPrice]", row).val();
                    resultNew1.totalDeductions = $("[id *= txtActualPerGmts]", row).val();
                    resultNew1.netTotal = resultNew1.total - resultNew1.totalDeductions;
                    $("[id *= txtVariance]", row).val(resultNew1.netTotal);

                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>
    <%--   <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <%-- <div id="divGridViewScroll" style="width: 690px; height: 300px; overflow: scroll">
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
                                <asp:BoundField DataField="CONTRACT_NO" HeaderText="C.N" />
                                <asp:BoundField DataField="CONTRACT_ISSUE_DATE" HeaderText="I.D" />
                                <asp:BoundField DataField="CONTRACT_DELIVERY_DATE" HeaderText="C.D" />
                                <asp:BoundField DataField="PO_NO" HeaderText="PO" />
                                <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE" />
                                <asp:BoundField DataField="ORDER_QUANTITY" HeaderText="RATE" />
                                <asp:BoundField DataField="PO_PRICE" HeaderText="CURRENCY" />
                                <asp:BoundField DataField="HANGER_COST_PER_UNIT" HeaderText="MEASURE" />
                                <asp:BoundField DataField="UNIT_COST" HeaderText="LENGTH" />
                                <asp:BoundField DataField="TOTAL_AMOUNT_IN_USD" HeaderText="LENGTH" />
                                <asp:BoundField DataField="VENDOR_NAME" HeaderText="V.N" />
                                <asp:BoundField DataField="VENDOR_BANK_NAME" HeaderText="V.B.N" />
                                <asp:BoundField DataField="MANUFACTURE_NAME" HeaderText="M.N" />
                                <asp:BoundField DataField="MANUFACTURE_BANK_NAME" HeaderText="M.B.N" />
                                <asp:BoundField DataField="SHIP_NAME" HeaderText="SHIP" />
                                <asp:BoundField DataField="SHIPMENT_TYPE_NAME" HeaderText="STORE" />
                                <asp:BoundField DataField="PAYMENT_DAY" HeaderText="IMPORTER" />
                                <asp:BoundField DataField="ULTIMATE_CONSIGNEE_NAME" HeaderText="PROGRAMME" />
                                <asp:BoundField DataField="ITEM_NAME" HeaderText="STYLE" />
                                <asp:BoundField DataField="SIZE_NAME" HeaderText="QUANTITY" />
                                <asp:BoundField DataField="SHIPPING_ADDRESS" HeaderText="LENGTH" />
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
    </div>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
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
