<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false"
    CodeBehind="PoRequisition.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PoRequisition" %>

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
    <fieldset>
        <legend>REQUISITION INFO</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 624px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True"
                        OnCheckedChanged="chkPDF_CheckedChanged" Visible="False" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox"
                        OnCheckedChanged="chkExcel_CheckedChanged" Visible="False" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>REQUISITION ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 150px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label53" runat="server" Text="Requisition No :"></asp:Label>
                                </td>
                                <td style="width: 200px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtRequisitionNo" runat="server" Width="150px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black"
                                        OnTextChanged="txtRequisitionNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px"
                                        Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 120px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label54" runat="server" Text="Freight :"></asp:Label>
                                </td>
                                <td style="width: 300px; text-align: left;">
                                    <asp:TextBox ID="txtFreight" runat="server" Width="152px"
                                        BackColor="White" ForeColor="Black" OnTextChanged="txtFreight_TextChanged" AutoPostBack="true">
                                    </asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px; text-align: right">
                                    <asp:Label ID="Label52" runat="server" Text="Purchase Date :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="width: 200px; text-align: left;">
                                    <asp:TextBox ID="txtPurchaseDate" runat="server" Width="150px" Font-Bold="False"
                                        BackColor="White" CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 120px; text-align: right">
                                    <asp:Label ID="Label55" runat="server" Text="Packing Charge Fee :"></asp:Label>
                                </td>
                                <td style="width: 300px; text-align: left;">
                                    <asp:TextBox ID="txtTrackingChargeFee" runat="server" Width="152px"
                                        BackColor="White" ForeColor="Black" OnTextChanged="txtTrackingChargeFee_TextChanged"
                                        AutoPostBack="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px; text-align: right;">
                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="width: 200px; text-align: left;">
                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 120px; text-align: right">
                                    <asp:Label ID="lblDidcount" runat="server" Text="Discount :"></asp:Label>
                                </td>
                                <td style="width: 300px; text-align: left;">
                                    <asp:TextBox ID="txtDiscount" runat="server" Width="152px" OnTextChanged="txtDiscount_TextChanged"
                                        AutoPostBack="true" BackColor="White" ForeColor="Black"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px; text-align: right; height: 27px;"></td>
                                <td style="width: 200px; text-align: left; height: 27px;"></td> <%--asad--%>
                                <td style="width: 120px; text-align: right; height: 27px;">
                                    <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount :"></asp:Label>
                                </td>
                                <td style="width: 300px; text-align: left; height: 27px;">
                                    <asp:TextBox ID="txtTotalAmount" runat="server" Width="152px"
                                        BackColor="Yellow" ReadOnly="True" Font-Bold="True" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 150px; text-align: right"></td>
                                <td style="width: 200px; text-align: left;">
                                    <asp:GridView ID="gvPoRequisition3" runat="server" Style="height: 50px; overflow: scroll;
                                        margin-top: -73px; position: absolute" ShowHeader="False"
                                        AutoGenerateColumns="false" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                        AlternatingRowStyle-CssClass="alt"
                                        OnSelectedIndexChanged="gvPoRequisition3_SelectedIndexChanged" OnRowDataBound="gvPoRequisition3_RowDataBound"
                                        Width="153px">
                                        <Columns>
                                            <asp:BoundField DataField="REQUISITION_NO" HeaderText="REQUITION.NO" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="width: 120px; text-align: left;">
                                    <asp:TextBox ID="txtTotalPrice" runat="server" Width="34px"
                                        BackColor="Yellow" ReadOnly="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 300px; text-align: left; height: 27px;">
                                    <asp:Label ID="lblCountgvRow" runat="server" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>REQUISITION ENTRY </legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvPoRequisition" runat="server" DataSourceID="" AutoGenerateColumns="false"
                                                        DataKeyNames="TRAN_ID" OnRowDataBound="gvPoRequisition_OnRowDataBound" AllowSorting="True"
                                                        EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="gvPoRequisition_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvPoRequisition_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvPoRequisition_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvPoRequisition_PageIndexChanging" OnRowDeleting="gvPoRequisition_RowDeleting">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="SE" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnselect" Width="30" Height="20" runat="server" CommandName="Select"
                                                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PART NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPartNo" runat="server" Text='<%#Eval("PART_NO")%> ' Font-Bold="true"
                                                                        Width="120"> 
                                                                    </asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="PARTICULARS" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPartName" runat="server" Text='<%#Eval("PARTICULAR_NAME")%> '
                                                                        Font-Bold="true" Width="150" BackColor="Yellow" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="UNIT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlPoUnitId" DataTextField="PO_UNIT_NAME" DataValueField="PO_UNIT_ID"
                                                                        runat="server" Width="70">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="P.S" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPresentStock" runat="server" Text='<%#Eval("PRESENT_STOCK")%> '
                                                                        Font-Bold="true" Width="50"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="R.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRequiredQty" runat="server" Text='<%#Eval("REQUIRED_QTY")%> '
                                                                        Font-Bold="true" Width="70"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="A.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtAppearedQty" runat="server" Text='<%#Eval("APPROVED_QTY")%> '
                                                                        Font-Bold="true" Width="70" OnTextChanged="txtAppearedQty_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("RATE")%> ' Font-Bold="true"
                                                                        Width="70" OnTextChanged="txtRate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PRICE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("PRICE")%> ' Font-Bold="true"
                                                                        Width="80" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="CURRENCY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlCurrencyId" DataTextField="CURRENCY_NAME" DataValueField="CURRENCY_ID"
                                                                        runat="server" Width="60">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="REMARKS" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" Text='<%#Eval("REMARKS")%> ' Width="100"
                                                                        Font-Bold="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblSLNO" runat="server" Text='<%#Eval("TRAN_ID")%> ' Width="10" DataField="TRAN_ID"
                                                                        BackColor="Yellow" SortExpression="TRAN_ID"></asp:Label>
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
                                                <td colspan="5" style="text-align: center">
                                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                                                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                                        CssClass="styled-button-4" />
                                                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete"
                                                        Width="66px" OnClick="btnDelete_Click"
                                                        CssClass="styled-button-4" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 37px">
                                                    <asp:GridView ID="gvPoRequisition2" runat="server" AutoGenerateColumns="false" Style="margin-top: -45px;"
                                                        AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                                        AlternatingRowStyle-CssClass="alt"
                                                        OnSelectedIndexChanged="gvPoRequisition2_SelectedIndexChanged"
                                                        OnRowDataBound="gvPoRequisition2_RowDataBound" Width="260px">
                                                        <Columns>
                                                            <asp:BoundField DataField="PART_NO" HeaderText="PART.NUMBER" />
                                                            <asp:BoundField DataField="PARTICULAR_NAME" HeaderText="PARTICULAR.NAME" />
                                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnselect" Width="30" Height="20" runat="server" CommandName="Select"
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
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4"></td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <%-- <fieldset>
                                        <legend>REPORT CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="text-align: right; width: 164px;" class="style4">
                                                    <asp:Label ID="Label60" runat="server" Text="Purchase Id :"></asp:Label>
                                                </td>
                                                <td style="width: 142px; height: 22px;">
                                                    <asp:DropDownList ID="ddlSrcPurchaseId" runat="server" Width="150px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 56px;">
                                                    <asp:Button ID="btnSearchRecord" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearchRecord_Click" />
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 88px;">
                                                    <asp:Label ID="Label61" runat="server" Text="From Date :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="150px" Font-Bold="True" BackColor="White"
                                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 164px;" class="style5">
                                                    <asp:Label ID="Label62" runat="server" Text="Section :"></asp:Label>
                                                </td>
                                                <td style="width: 142px">
                                                    <asp:DropDownList ID="ddlSrcSectionId" runat="server" Width="150px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 56px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 88px">
                                                    <asp:Label ID="Label63" runat="server" Text="To Date :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="dtpToDate" runat="server" Width="150px" Font-Bold="True" BackColor="White"
                                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 164px;" class="style5">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 142px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 56px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 88px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 164px;" class="style5">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 142px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 56px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 88px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>--%>
                                </td>
                            </tr>
                            <tr>
                                <%--  <td style="text-align: left" colspan="5">
                                    <fieldset>
                                        <legend>SEARCH RESULT</legend>
                                        <asp:GridView ID="gvSrcPoRequisition" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                            OnRowDataBound="gvPoRequisition_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                            GridLines="None" AllowPaging="false" OnRowEditing="gvPoRequisition_OnRowEditing"
                                            CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvSrcPoRequisition_OnSelectedIndexChanged"
                                            CausesValidation="false" OnRowCommand="gvPoRequisition_RowCommand" AlternatingRowStyle-CssClass="alt"
                                            OnPageIndexChanging="gvPoRequisition_OnSelectedIndexChanged">
                                            <Columns>
                                                <asp:BoundField DataField="TRAN_ID" HeaderText="SL" />
                                                <asp:BoundField DataField="PART_NO" HeaderText="PART NO" />
                                                <asp:BoundField DataField="PARTICULAR_NAME" HeaderText="PARTICULAR NAME" />
                                                <asp:BoundField DataField="PRESENT_STOCK" HeaderText="P.STOCK" />
                                                <asp:BoundField DataField="REQUIRED_QTY" HeaderText="R.QTY" />
                                                <asp:BoundField DataField="APPEARED_QTY" HeaderText="A.QTY" />
                                                <asp:BoundField DataField="RATE" HeaderText="RATE" />
                                                <asp:BoundField DataField="PRICE" HeaderText="PRICE" />
                                                <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" />
                                                <asp:BoundField DataField="PURCHASE_OFFICE_NAME" HeaderText="OFFICE" />
                                                <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                            Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </fieldset>
                                </td>--%>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
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
    <%--     <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
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


            $("[id *= txtAppearedQty]").bind("change", Deductions);
            $("[id *= txtRate]").bind("change", Deductions);
            //$("[id *= txtPrice]").bind("change", Deductions);
            // $("[id *= txtTotalPrice]").bind("change", Deductions); 


            //var row = $(this).closest("tr");


            //$("[id *= txtFreight]", row).val().bind("change", Deductions);
            //$("[id *= txtDiscount]",row).val().bind("change", Deductions);

        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {

                    var row = $(this).closest("tr");
                    var result = new Object();

                    result.Quantity = $("[id *= txtAppearedQty]", row).val();
                    result.Rate = $("[id *= txtRate]", row).val();
                    result.Total = result.Quantity * result.Rate;
                    $("[id *= txtPrice]", row).val(result.Total);





                    //var row = $(this).closest("tr");
                    //$("[id *= txtTotalAmount]", row).val($("[id *= txtPrice]", row).val());

                    //$("[id *= txtTotalAmount]", row).val($("[id *= txtTotalPrice]", row).val() + $("[id *= txtFreight]",row).val());
                    //$("[id *= txtTotalAmount]", row).val(($("[id *= txtTotalPrice]", row).val() + $("[id *= txtFreight]",row).val()) - $("[id *= txtDiscount]",row).val());

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
    <%-- <table class="style1">
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
    </table>--%>
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
