<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="PurchaseEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PurchaseEntry" %>

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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtLedgerNo.ClientID %>").focus(); }) 
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
        <legend>PURCHASE INFORAMTION </legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 917px;">
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
                        <legend>PURCHASE ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 104px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Inv. No :"></asp:Label>
                                </td>
                                <td style="width: 167px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtInvoiceNo" runat="server" Width="77px" BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:TextBox ID="txtTranId" runat="server" Width="22px" BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 101px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label69" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td style="width: 148px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="140px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 215px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label68" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="txtEmployeeDesignation" runat="server" Width="140px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 104px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label78" runat="server" Text="Ledger SL :"></asp:Label>
                                </td>
                                <td style="width: 167px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtLedgerNo" runat="server" Width="140px" BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 101px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label46" runat="server" Text="Product SL :"></asp:Label>
                                </td>
                                <td style="width: 148px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtSerialNo" runat="server" Width="140px" BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 215px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label61" runat="server" Text="Req. No:"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="txtRequisitionNo" runat="server" Width="140px" BackColor="White"
                                        Font-Bold="False" ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 104px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label49" runat="server" Text="Req. Date :"></asp:Label>
                                </td>
                                <td style="width: 167px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="dtpRequisitionDate" runat="server" Width="140px" BackColor="White"
                                        Font-Bold="False" CssClass="date" ForeColor="Black"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="width: 101px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label50" runat="server" Text="MRR No :"></asp:Label>
                                </td>
                                <td style="width: 148px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtMRRNo" runat="server" Width="140px" BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 215px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label47" runat="server" Text="MRR Date :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="dtpMRRDate" runat="server" Width="140px" BackColor="White" Font-Bold="False"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 104px; text-align: right">
                                    <asp:Label ID="Label53" runat="server" Text="Pur. Date :"></asp:Label>
                                </td>
                                <td style="width: 167px; text-align: left;">
                                    <asp:TextBox ID="dtpPurchaseDate" runat="server" Width="140px" BackColor="White"
                                        Font-Bold="False" CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 101px; text-align: right;">
                                    <asp:Label ID="Label79" runat="server" Text="Product :"></asp:Label>
                                </td>
                                <td style="width: 148px; text-align: left;">
                                    <asp:DropDownList ID="ddlProductId" runat="server" Width="145px" Height="22px" BackColor="#CCCCCC">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 215px; text-align: right;">
                                    <asp:Label ID="Label73" runat="server" Text="Qty :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPurchaseQuantity" runat="server" Width="140px" BackColor="White"
                                        Font-Bold="True" ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 104px; text-align: right">
                                    <asp:Label ID="Label60" runat="server" Text="Price :"></asp:Label>
                                </td>
                                <td style="width: 167px; text-align: left;">
                                    <asp:TextBox ID="txtPrice" runat="server" Width="140px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 101px; text-align: right;">
                                    <asp:Label ID="Label63" runat="server" Text="Supplier :"></asp:Label>
                                </td>
                                <td style="width: 148px; text-align: left;">
                                    <asp:TextBox ID="txtSupplierName" runat="server" Width="140px" BackColor="White"
                                        Font-Bold="False" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 215px; text-align: right;">
                                    <asp:Label ID="Label64" runat="server" Text="Warranty :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtWarranty" runat="server" Width="140px" BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 104px; text-align: right; height: 38px;">
                                    <asp:Label ID="lblProductCataroy12" runat="server" Text="Upload :"></asp:Label>
                                </td>
                                <td style="width: 167px; text-align: left; height: 38px;">
                                    <asp:FileUpload ID="FileUpload1" runat="server" Width="100px" UpdateMode="Conditional" />
                                </td>
                                <td style="width: 101px; text-align: right; height: 38px;">
                                    <asp:Label ID="Label70" runat="server" Text="Description :"></asp:Label>
                                </td>
                                <td style="width: 148px; text-align: left; height: 38px;">
                                    <asp:TextBox ID="txtProductDescription" runat="server" Width="140px" BackColor="White"
                                        ForeColor="Black" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td style="width: 215px; text-align: right; height: 38px;">
                                    <asp:Label ID="Label71" runat="server" Text="Remark :"></asp:Label>
                                </td>
                                <td style="height: 38px">
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="140px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="False" ForeColor="Black" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 104px; text-align: right">
                                    <asp:Label ID="Label82" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td style="width: 167px; text-align: left;">
                                    <asp:TextBox ID="txtEmpName" runat="server" Width="161px"
                                        Font-Bold="True" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 101px; text-align: right;">
                                    <asp:Label ID="Label72" runat="server" Text="ID/Card :" Visible="False"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="width: 148px; text-align: left;">
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="72px" BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black" ReadOnly="True" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="60px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black" ReadOnly="True" Visible="False"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="width: 215px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy13" runat="server" Text="File Name :" Visible="False"></asp:Label>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFileName" runat="server" Width="22px" BackColor="Yellow" Font-Bold="False"
                                        ForeColor="Black" ReadOnly="True" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtInvNo" runat="server" Width="23px" BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black" ReadOnly="True" Visible="False"></asp:TextBox>
                                    &nbsp;
                                    <asp:TextBox ID="txtSL" runat="server" Width="23px" BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black" ReadOnly="True" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 104px; text-align: right">&nbsp;</td>
                                <td style="width: 167px; text-align: left;">&nbsp;</td>
                                <td style="width: 101px; text-align: right;">&nbsp;</td>
                                <td style="width: 148px; text-align: left;">&nbsp;</td>
                                <td style="width: 215px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="6">
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnView_Click" />
                                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSheet_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="6">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="text-align: right; width: 63px;" class="style4">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="153px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearchEmployeeRecrod" runat="server" Height="25px" Text="Search"
                                                        Width="55px" CssClass="styled-button-4" OnClick="btnSearchEmployeeRecrod_Click" />
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 63px;" class="style5">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="153px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px"></td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 63px;" class="style5">
                                                    <asp:Label ID="Label74" runat="server" Text="Product SL :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="txtSLNoSearch" runat="server" Width="149px" BackColor="White" placeHolder="PRODUCT SL NO"></asp:TextBox>
                                                </td>
                                                <td style="width: 66px"></td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label75" runat="server" Text="Req. No :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtRequisitionSearch" runat="server" Width="149px" BackColor="White"
                                                        placeHolder="REQUISITION NO"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 63px;" class="style5">
                                                    <asp:Label ID="Label76" runat="server" Text="From :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="dtpPurchaseDateFrom" runat="server" Width="149px" BackColor="White"
                                                        placeHolder="PURCHASE DATE FROM" CssClass="date"></asp:TextBox>
                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">&nbsp;
                                                    <asp:Label ID="Label80" runat="server" Text="PRoduct :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlProductIdSearch" runat="server" Width="154px" Height="22px"
                                                        BackColor="#CCCCCC">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 63px;" class="style5">
                                                    <asp:Label ID="Label77" runat="server" Text="To :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="dtpPurchaseDateTo" runat="server" Width="149px" BackColor="White"
                                                        placeHolder="PURCHASE DATE TO" CssClass="date"></asp:TextBox>
                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">&nbsp;
                                                    <asp:Label ID="Label81" runat="server" Text="Supplier :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtSupplierNameSearch" runat="server" Width="149px" BackColor="White"
                                                        Font-Bold="False" ForeColor="Black"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 63px;" class="style5">&nbsp;
                                                </td>
                                                <td style="width: 163px">&nbsp;
                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label83" runat="server" Text="Name :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpNameSearch" runat="server" Width="149px" BackColor="White"
                                                        Font-Bold="False" ForeColor="Black"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="style5" colspan="5">
                                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                                        Font-Names="Tahoma"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: left" class="style5" colspan="5"></td>
                                            </tr>
                                        </table>
                                    </fieldset>
                    </fieldset>
                </td>
            </tr>
        </table>
        </td> </tr> </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <div id="div1" style="width:100%; height: 500px; overflow: scroll">
        <fieldset>
            <legend>SEARCH RESULT</legend>
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <fieldset>
                            <legend>PURCHASE ENTRY RESULT </legend>
                            <table style="width: 100%">
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                            OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                            GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                            PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                            CausesValidation="false" OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt"
                                            OnPageIndexChanging="GridView1_OnSelectedIndexChanged">
                                            <Columns>
                                                <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                            Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="SL" HeaderText="SL" />
                                                <asp:BoundField DataField="INVOICE_NO" HeaderText="INVOICE" />
                                                <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                                <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                                <asp:BoundField DataField="PRODUCT_SL_NO" HeaderText="SL NO" />
                                                <asp:BoundField DataField="LEDGER_NO" HeaderText="LEDGER NO" />
                                                <asp:BoundField DataField="REQUISITION_NO" HeaderText="R.N" />
                                                <asp:BoundField DataField="REQUISITION_DATE" HeaderText="R.DATE" />
                                                <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                                                <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" />
                                                <asp:BoundField DataField="MRR_NO" HeaderText="MRR" />
                                                <asp:BoundField DataField="MRR_DATE" HeaderText="M.DATE" />
                                                <asp:BoundField DataField="PURCHASE_DATE" HeaderText="P.DATE" />
                                                <asp:BoundField DataField="PRODUCT_NAME" HeaderText="PRODUCT NAME" />
                                                <asp:BoundField DataField="PURCHASE_QUANTITY" HeaderText="QTY" />
                                                <asp:BoundField DataField="PRICE" HeaderText="PRICE" />
                                                <asp:BoundField DataField="WARRANTY_PERIOD" HeaderText="WARRANTY" />
                                                <asp:BoundField DataField="PRODUCT_DESCRIPTION" HeaderText="DESCRIPTION" />
                                                <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />
                                                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" />
                                                <asp:BoundField DataField="FILE_NAME" HeaderText="FILE" />
                                                <asp:BoundField DataField="TRAN_ID" HeaderText="T.N" />
                                                <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <div id="div1" style="height: 500px; overflow: scroll">
        <fieldset>
            <legend>SEARCH RESULT</legend>
            <table style="width: 100%">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                            AllowSorting="True" EnableViewState="true" ClientSelectionMode="SingleRow" GridLines="None"
                            AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing"
                            OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                            OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                            CausesValidation="false" OnRowCommand="gvEmployeeList_RowCommand"
                            Width="997px">
                            <Columns>
                                <asp:BoundField DataField="SL" HeaderText="SL" />
                                <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
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
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
