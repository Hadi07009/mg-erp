<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false"
    CodeBehind="PurchaseParts.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PurchaseParts" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
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
    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");

        }
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

    <div style="float: left; width: 350px;">

        <fieldset>
        <legend>PURCHASE PARTS INFO</legend>
        <table class="style1";>
            <tr>
                <td style="text-align: left; width: 100%;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <%--<fieldset>
                        <legend>PURCHASE PARTS</legend>--%>
                    <table class="style1">

                        <tr>
                            <td style="text-align: right; width: 100px;"><%--class="auto-style2"--%>
                                <asp:Label ID="lblPoRequisitionNo" runat="server" Text="Requisition No :"></asp:Label>
                            </td>
                            <td style="width: 300px; text-align: left; height: 22px;">
                                <asp:TextBox ID="txtPoRequisitionNo" runat="server" Width="182px"
                                    BackColor="Yellow" Font-Bold="True"
                                    ForeColor="Black" OnTextChanged="txtPoRequisitionNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:Button ID="btnSearchPoRequisitionNo" runat="server" Height="22px"
                                    Text="..." Width="30px" CssClass="styled-button-4"
                                    OnClick="btnSearchPoRequisitionNo_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 100px;">
                                <asp:Label ID="lblPoNo" runat="server" Text="Po Number :"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 300px;">
                                <asp:TextBox ID="txtPoNumber" runat="server" Width="182px" BackColor="Yellow" Font-Bold="True"
                                    ForeColor="Black" OnTextChanged="txtPoNumber_TextChanged" AutoPostBack="true"></asp:TextBox>
                                <asp:Button ID="btnPoList" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                    OnClick="btnPoList_Click" />
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right; width: 100px;">
                                <asp:Label ID="Label52" runat="server" Text="Machine :"></asp:Label>
                            </td>
                            <td style="width: 300px; text-align: left; height: 22px;">
                                <asp:DropDownList ID="ddlMachineId" runat="server" Width="187px" Font-Bold="False"
                                    BackColor="White" CssClass="date" ForeColor="Black" Height="22px">
                                </asp:DropDownList>

                                <asp:Button ID="btnSearch" runat="server" Height="22px"
                                    Text="..." Width="30px" CssClass="styled-button-4"
                                    OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 100px;">
                                <asp:Label ID="Label35" runat="server" Text="Supplier :"></asp:Label>
                            </td>
                            <td style="width: 230px; text-align: left; height: 22px;">
                                <asp:DropDownList ID="ddlSupplierId" runat="server" Width="187px" Height="22px">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtRefNo" runat="server" Width="27px" Height="20px" Font-Bold="True"
                                    ForeColor="Red"
                                    BackColor="Yellow" ReadOnly="True" Visible="False"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 100px; text-align: right; height: 22px;">&nbsp;</td>
                            <td style="width: 230px; text-align: left; height: 22px;">
                                <asp:TextBox ID="txtTranId" runat="server" Width="27px" Height="20px" Font-Bold="True"
                                    ForeColor="Red" BackColor="Yellow" ReadOnly="True" Visible="False"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>

                     <tr>
                        <td style="width: 100px;">&nbsp;</td>
                        <td style="width: 230px; text-align: left;">
                            <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                CssClass="styled-button-4" />
                            <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear"
                                Width="66px" CssClass="styled-button-4" OnClick="btnClear_Click1" />
                        </td>
                    </tr>

                    </table>
                    <%-- </fieldset>--%>
                </td>
            </tr>
           
            <%--<tr>
                <td style="width: 100px;">&nbsp;</td>
                <td style="width: 230px; text-align: left;">
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear"
                        Width="66px" CssClass="styled-button-4" OnClick="btnClear_Click1" />
                </td>
            </tr>--%>
        
        </table>
        </fieldset>
    </div>


    <div style="float: left;">

        <fieldset>
        <legend>SEARCHING</legend>
        <table class="style1">
            <tr>
                <td style="width: 80px; text-align: right; height: 27px;">
                    <asp:Label ID="Label9" runat="server" Text="Part No :"></asp:Label>
                </td>
                <td style="width: 220px; height: 27px;">
                    <asp:TextBox ID="txtPartNo" runat="server" Height="21px" Width="150px"
                        Font-Bold="True"></asp:TextBox>
                    <asp:Button ID="btnSearchRecord" runat="server" CssClass="styled-button-4" Height="22px"
                        Text="...." Width="36px" OnClick="btnSearchRecord_Click" />
                </td>

                <td style="width: 60px; text-align: right;">
                    <asp:Label ID="Label12" runat="server" Text="PO No :"></asp:Label>
                </td>
                <td style="width: 220px">
                    <asp:TextBox ID="txtPONo" runat="server" Height="21px" Width="182px"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td style="width: 80px; text-align: right; height: 27px;">
                    <asp:Label ID="Label13" runat="server" Text="Machine :"></asp:Label>
                </td>
                <td style="width: 220px">
                    <asp:DropDownList ID="ddlMachineIdSearch" runat="server" Height="21px"
                        Width="155px">
                    </asp:DropDownList>
                </td>
                <td style="width: 80px; text-align: right; height: 27px;">
                    <asp:Label ID="Label53" runat="server" Text="Equipement :"></asp:Label>
                </td>
                <td style="width: 220px">
                    <asp:DropDownList ID="ddlEquipementId" runat="server" Height="22px"
                        Width="187px">
                    </asp:DropDownList>
                </td>
                <%--<td style="width: 60px; text-align: right; height: 27px;">
                    <asp:Label ID="Label49" runat="server" Text="Supplier :"></asp:Label>
                </td>
                <td style="width: 220px">
                    <asp:DropDownList ID="ddlSupplierIdSearch" runat="server" Height="22px"
                        Width="187px">
                    </asp:DropDownList>
                </td>--%>

            </tr>
            

            <tr>
                
                <td style="width: 60px; text-align: right; height: 27px;">
                    <asp:Label ID="Label49" runat="server" Text="Supplier :"></asp:Label>
                </td>
                <td style="width: 490px" colspan="3">
                    <asp:DropDownList ID="ddlSupplierIdSearch" runat="server" Height="22px"
                        Width="490px">
                    </asp:DropDownList>
                </td>
            </tr>

        </table>
        </fieldset>
    </div>

    <div style="clear: left; margin-top:20px;">
    <fieldset>
    <legend>PURCHASE PARTS LIST </legend>

    <asp:GridView ID="gvPurchasePartsList" runat="server" DataSourceID="" AutoGenerateColumns="false"
         DataKeyNames="TRAN_ID" OnRowDataBound="gvPurchasePartsList_OnRowDataBound" AllowSorting="True"
         EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="gvPurchasePartsList_OnRowEditing"
         CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvPurchasePartsList_OnSelectedIndexChanged"
         CausesValidation="false" AlternatingRowStyle-CssClass="alt">
         <Columns>           
             <asp:BoundField DataField="rownum" HeaderText="SL" HeaderStyle-Width="5%" ItemStyle-Width="5%"/>
             <asp:BoundField DataField="PART_NO" HeaderText="PART NUMBER" HeaderStyle-Width="12%" ItemStyle-Width="12%"/>
             <asp:BoundField DataField="PARTICULAR_NAME" HeaderText="PARTICULARS" HeaderStyle-Width="20%" ItemStyle-Width="20%"/>
             <asp:BoundField DataField="purchase_quantity" HeaderText="QUANTITY" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             <asp:BoundField DataField="unit_price" HeaderText="UNIT PRICE" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             <asp:BoundField DataField="total_price" HeaderText="TOTAL PRICE" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             <asp:BoundField DataField="PO_NO" HeaderText="PO NO" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             <asp:BoundField DataField="CURRENCY_NAME" HeaderText="CURRENCY" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
             <asp:BoundField DataField="TRAN_ID" HeaderText="TRX ID" HeaderStyle-Width="7%" ItemStyle-Width="7%"/>
             <asp:BoundField DataField="currency_id" HeaderText="currency_id" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>            
             <asp:BoundField DataField="requisition_no" HeaderText="requisition_no" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>            
         </Columns>
    </asp:GridView>

    <%--<table>
        <tr>
            <td style="text-align: right">
                
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:GridView ID="gvPurchasePartsList" runat="server" DataSourceID="" AutoGenerateColumns="false"
                                    DataKeyNames="TRAN_ID" OnRowDataBound="gvPurchasePartsList_OnRowDataBound" AllowSorting="True"
                                    EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="gvPurchasePartsList_OnRowEditing"
                                    CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvPurchasePartsList_OnSelectedIndexChanged"
                                    CausesValidation="false" AlternatingRowStyle-CssClass="alt">
                                    <Columns>

                                        <asp:BoundField DataField="PART_NO" HeaderText="PART NUMBER" HeaderStyle-Width="20%" ItemStyle-Width="20%"/>
                                        <asp:BoundField DataField="PARTICULAR_NAME" HeaderText="PARTICULARS" HeaderStyle-Width="20%" ItemStyle-Width="20%"/>
                                        <asp:BoundField DataField="purchase_quantity" HeaderText="QUANTITY" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="unit_price" HeaderText="UNIT PRICE" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="total_price" HeaderText="TOTAL PRICE" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="PO_NO" HeaderText="PO NO" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="CURRENCY_NAME" HeaderText="CURRENCY" HeaderStyle-Width="10%" ItemStyle-Width="10%"/>
                                        <asp:BoundField DataField="TRAN_ID" HeaderText="TRX ID" HeaderStyle-Width="7%" ItemStyle-Width="7%"/>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
            </td>
        </tr>
    </table>--%>
    </fieldset>
    </div>

    <fieldset>
    <legend>SEARCH RESULT</legend>
    <table>
        <tr>
            <td>

                
                    <asp:GridView ID="gvForeignFabric" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvForeignFabric_PageIndexChanging"
                        CausesValidation="false" DataKeyNames="TRAN_ID"
                        OnSelectedIndexChanged="gvForeignFabric_SelectedIndexChanged"
                        OnRowCommand="gvForeignFabric_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />


                            <asp:BoundField DataField="machine_name" HeaderText="MACHINE" />
                            <asp:BoundField DataField="supplier_name" HeaderText="SUPPLIER" />


                            <asp:BoundField DataField="PART_NO" HeaderText="PART NO" />
                            <asp:BoundField DataField="PARTICULAR_NAME" HeaderText="PARTICULAR NAME" />
                            <asp:BoundField DataField="PURCHASE_QUANTITY" HeaderText="QTY" />
                            <asp:BoundField DataField="UNIT_PRICE" HeaderText="UNIT" />
                            <asp:BoundField DataField="TOTAL_PRICE" HeaderText="PRICE" />
                            <asp:BoundField DataField="currency_name" HeaderText="CURRENCY" />
                            <asp:BoundField DataField="PO_NO" HeaderText="PO NO" />
                            <asp:BoundField DataField="REF_NO" HeaderText="REF NO" />
                            <asp:BoundField DataField="TRAN_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
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
    </table>
    </fieldset>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('input:text,select').bind("keydown", function (e) {
                var n = $("input:text,select").length;
                if (e.which == 13) { //Enter key

                    e.preventDefault(); //Skip default behavior of the enter key

                    var nextIndex = $('input:text,select').index(this) + 1;

                    if (nextIndex < n) {

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


            $("[id *= txtQuantity]").bind("change", Deductions);
            $("[id *= txtUnitPrice]").bind("change", Deductions);


        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {

                    var row = $(this).closest("tr");
                    var result = new Object();

                    result.Quantity = $("[id *= txtQuantity]", row).val();
                    result.Rate = $("[id *= txtUnitPrice]", row).val();
                    result.Total = (result.Quantity * result.Rate).toFixed(2);
                    $("[id *= txtTotalPrice]", row).val(result.Total);

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
            <td></td>
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
