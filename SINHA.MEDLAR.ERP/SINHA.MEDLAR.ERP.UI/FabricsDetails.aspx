<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="FabricsDetails.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.FabricsDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>     
<%--    <script type="text/javascript" language="javascript">

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
                <td style="text-align: left; width: 787px;">
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
                                <td style="width: 253px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Contract No :"></asp:Label>
                                </td>
                                <td style="width: 392px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtContractNo" runat="server" Width="150px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 436px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label46" runat="server" Text="FOB Date :"></asp:Label>
                                </td>
                                <td style="width: 310px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtFobDate" runat="server" Width="150px" BackColor="Yellow" Font-Bold="True"
                                        CssClass="date" ForeColor="Black" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 94px; text-align: right; height: 22px;">
                                    <asp:Label ID="lblBuyer" runat="server" Text="Buyer :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 253px; text-align: right">
                                    <asp:Label ID="lblPONO" runat="server" Text="P.O No :"></asp:Label>
                                </td>
                                <td style="width: 392px; text-align: left;">
                                    <asp:DropDownList ID="ddlPONo" runat="server" Width="154px" Height="22px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlPONo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 436px; text-align: right;">
                                    <asp:Label ID="Label49" runat="server" Text="Order Quantity:"></asp:Label>
                                </td>
                                <td style="width: 310px; text-align: left;">
                                    <asp:TextBox ID="txtOrderQuantity" runat="server" Width="150px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 94px; text-align: right;">
                                    <asp:Label ID="lblSeason" runat="server" Text="Season :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSeasonId" runat="server" Width="154px" Height="22px" AutoPostBack="True"
                                        onselectedindexchanged="ddlSeasonId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 253px; text-align: right">
                                    <asp:Label ID="lblPONO0" runat="server" Text="Style No :"></asp:Label>
                                </td>
                                <td style="width: 392px; text-align: left;">
                                    <asp:DropDownList ID="ddlStyleNo" runat="server" Width="154px" Height="22px" AutoPostBack="true"
                                        OnSelectedIndexChanged="ddlStyleNo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 436px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="width: 310px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 94px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 253px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 392px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 436px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td style="width: 310px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 94px; text-align: right;">
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
                                                    <asp:GridView ID="gvFabricsDetails" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvFabricsDetails_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" OnRowEditing="gvFabricsDetails_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvFabricsDetails_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvFabricsDetails_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvFabricsDetails_OnSelectedIndexChanged">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="TRIM DETAILS" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtFabricsDescription" runat="server" Text='<%#Eval("FABRICS_DESCRIPTION")%> '
                                                                        Font-Bold="true" Width="100"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SUPPLIER" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtSupplier" runat="server" Text='<%#Eval("SUPPLIER")%> ' Font-Bold="true"
                                                                        Width="100"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField HeaderText="SUPPLIER" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlSupplierId" DataTextField="SUPPLIER_NAME" DataValueField="SUPPLIER_ID"
                                                                        runat="server" Width="60">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="GROUP" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlSizeId" DataTextField="SIZE_NAME" DataValueField="SIZE_ID"
                                                                        runat="server" Width="50">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CONS" ItemStyle-Width="1%">
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
                                                            <asp:TemplateField HeaderText="TOTAL PRICE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTotalPrice" runat="server" Text='<%#Eval("TOTAL_PRICE")%> ' Font-Bold="true"
                                                                        Width="45" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="B.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBudgetQtyInYds" runat="server" Text='<%#Eval("BUDGET_QTY_IN_YDS")%> '
                                                                        Font-Bold="true" Width="45" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="B.VALUE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBudgetValue" runat="server" Text='<%#Eval("BUDGET_VALUE")%> '
                                                                        Font-Bold="true" Width="45" BackColor="Yellow"></asp:TextBox>
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
                                                                        Font-Bold="true" Width="45"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A.VALUE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActualValue" runat="server" Text='<%#Eval("ACTUAL_VALUE")%> '
                                                                        Font-Bold="true" Width="45" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="P.GMTS" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtActualPerGmts" runat="server" Text='<%#Eval("ACTUAL_PER_GMT")%> '
                                                                        Font-Bold="true" Width="40" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="VARIANCE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtVariance" runat="server" Text='<%#Eval("VARIANCE")%> '
                                                                        Font-Bold="true" Width="60" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="P/I NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtImportPINo" runat="server" Text='<%#Eval("IMPORT_PI_NO")%> '
                                                                        Font-Bold="true" Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="I.DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtImportDate" runat="server" Text='<%#Eval("IMPORT_DATE")%> ' Font-Bold="true"
                                                                        Width="80" CssClass="date"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="I.SUPPLIER" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtImportSupplier" runat="server" Text='<%#Eval("IMPORT_SUPPLIER")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                        <asp:Label ID="lblTranId" runat="server" Text='<%#Eval("TRAN_ID")%> ' Width="5"
                                                                        BackColor="Yellow"></asp:Label>
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
                                <td style="text-align: center" colspan="6">
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                </td>
                            </tr>
                            <tr>
                                 <td style="text-align: right" colspan="6">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="text-align: right; width: 278px;" class="style4">
                                    <asp:Label ID="Label50" runat="server" Text="Contract No :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                    <asp:TextBox ID="txtSrcContractNo" runat="server" Width="175px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 65px;">
                                                    <asp:Button ID="btnSearchRecord" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearchRecord_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                    <asp:Label ID="Label51" runat="server" Text="FOB Date :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                    <asp:TextBox ID="txtSrcFobDate" runat="server" Width="175px" BackColor="White" Font-Bold="True" CssClass="date"
                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 278px;" class="style5">
                                    <asp:Label ID="lblPONO1" runat="server" Text="P.O No :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                    <asp:TextBox ID="txtSrcPONo" runat="server" Width="175px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="width: 65px">
                                                   
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    </td>
                                                <td>
                                                    </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 278px;" class="style5">
                                    <asp:Label ID="lblPONO2" runat="server" Text="Style No :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                    <asp:TextBox ID="txtSrcStyleNo" runat="server" Width="175px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="width: 65px">
                                                    </td>
                                                <td style="text-align: right; width: 69px">
                                                    </td>
                                                <td>
                                                    &nbsp;</td>
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
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
  <%-- <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
  
    <script type="text/javascript">
        $(document).ready(function () {
            $('input:text,select').bind("keydown", function (e) {
                var n = $("input:text,select").length;
                if (e.which == 13) { //Enter key

                    e.preventDefault(); //Skip default behavior of the enter key

                    var nextIndex = $('input:text,select').index(this) + 1;

                    if (nextIndex < (n - 5)) {
                        $('input:text,select')[nextIndex].focus();
                    }

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

              $("[id *= txtBudgetQtyInYds]").bind("change", Deductions);          
              $("[id *= txtBudgetValue]").bind("change", Deductions);
              $("[id *= txtActualQtyInYds]").bind("change", Deductions);
              $("[id *= txtActualPrice]").bind("change", Deductions);
              $("[id *= txtActualValue]").bind("change", Deductions);
//            $("[id *= txtVariance]").bind("change", Deductions);
//            $("[id *= txtActualPerGmts]").bind("change", Deductions);
            
            



        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();
                    //var resultNew1 = new Object();
                    var resultNew2 = new Object();
                    //var resultNew3 = new Object();

                    
                    resultNew.total = $("[id *= txtConsumtion]", row).val();
                    resultNew.totalDeductions = $("[id *= txtPrice]", row).val();
                    if ($("[id *= txtConsumtion]", row).val() != 0 && $("[id *= txtPrice]").val()) {
                        resultNew.netTotal = resultNew.total * resultNew.totalDeductions;
                        $("[id *= txtTotalPrice]", row).val(resultNew.netTotal);

                    }
                    else {
                        resultNew.netTotal = $("[id *= txtTotalPrice]", row).val();
                    }

                    
                    resultNew2.total = $("[id *= txtActualQtyInYds]", row).val();
                    resultNew2.totalDeductions = $("[id *= txtActualPrice]", row).val();
                    if (resultNew2.total != 0 && resultNew2.totalDeductions != 0) {
                        resultNew2.netTotal = resultNew2.total * resultNew2.totalDeductions;
                        $("[id *= txtActualValue]", row).val(resultNew2.netTotal);
                    }
                    else {
                        resultNew2.netTotal = $("[id *= txtActualValue]", row).val();
                    }


                    var row = $(this).closest("tr");
                    $("[id *= txtBudgetQtyInYds]", row).val($("[id *= txtConsumtion]", row).val() * $("[id *= txtOrderQuantity]").val());

                    var row = $(this).closest("tr");
                    $("[id *= txtBudgetValue]", row).val($("[id *= txtTotalPrice]", row).val() * $("[id *= txtOrderQuantity]").val());
                    
                    var row = $(this).closest("tr");
                    $("[id *= txtActualPerGmts]", row).val($("[id *= txtActualValue]", row).val() / $("[id *= txtOrderQuantity]").val());

                    var row = $(this).closest("tr");
                    $("[id *= txtVariance]", row).val($("[id *= txtTotalPrice]", row).val() - $("[id *= txtActualPerGmts]").val());

                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>
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
