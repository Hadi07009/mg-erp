<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="PoDocuments.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PoDocuments" %>

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
        <legend>DOCUMENTS INFO</legend>
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
                        <legend>ADD DOCUMENTS INFO</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 2051px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label53" runat="server" Text="Po  Number :"></asp:Label>
                                </td>
                                <td style="width: 1383px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtPoNumber" runat="server" Width="150px" BackColor="White"
                                        Font-Bold="True" ForeColor="Black" 
                                        ontextchanged="txtPoNumber_TextChanged" AutoPostBack="true"></asp:TextBox>
                                   <%-- <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />--%>
                                      
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" 
                                        Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td>
                                   
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 2051px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 1383px; text-align: left;">
                                   
                                       <asp:GridView ID="gvPoRequisition3" runat="server" ShowHeader="False" 
                                            AutoGenerateColumns="false" style="margin-top:0px;" AllowSorting="True"  EnableViewState="true"
                                            GridLines="None" AllowPaging="false" CssClass="mGrid"  PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                            onselectedindexchanged="gvPoRequisition3_SelectedIndexChanged" onrowdatabound="gvPoRequisition3_RowDataBound" Width="153px" Height="50px">
                                            <Columns>
                                                <asp:BoundField DataField="PO_NUMBER" HeaderText="PO_NUMBER.NO" />
                                                    <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnselect0" Width="30" Height="20" runat="server" CommandName="Select"
                                                                Style="cursor: pointer" Text="..." CausesValidation="false" 
                                                                BorderStyle="Ridge" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                        </asp:GridView>
                                   
                                </td>
                                <td style="width: 769px;text-align: right">
                                   
                                    &nbsp;</td>
                                <td>
                                   
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 2051px; text-align: right">
                                    <asp:Label ID="lblDocumentName" runat="server"  Text="Documents Name :" style="margin-top: -17px;position: absolute;margin-left: -90px;"></asp:Label>
                                </td>
                                <td style="width: 1383px; text-align: left;">                                                                     
                                    <asp:TextBox ID="txtDocumentName" runat="server" Height="118px" Font-Bold="false" TextMode="MultiLine" Width="453px" style="margin-top:-17px;"></asp:TextBox>
                                </td>                              
                                <td style="width: 769px;text-align: right">
                                   
                                    &nbsp;</td>
                                <td>
                                   
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 2051px; text-align: right">
                                    &nbsp;</td>
                                <td style="width: 1383px; text-align: left;">                                                                     
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px" OnClick="btnClear_Click"
                                        CssClass="styled-button-4" />
                                </td>                              
                                <td style="width: 769px;text-align: right">
                                   
                                    &nbsp;</td>
                                <td>
                                   
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
                                </td>
                            </tr>                           
                            <tr>
                                <td style="text-align: left" colspan="3">
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
