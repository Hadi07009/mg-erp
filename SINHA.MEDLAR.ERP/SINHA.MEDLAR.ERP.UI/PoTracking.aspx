<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="PoTracking.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PoTracking" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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

        function SelectAllCheckboxes(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
                spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }
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

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        row.style.backgroundColor = "white";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            row.style.backgroundColor = "white";

                        }

                        else {

                            row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }

    </script>
    <script type="text/javascript">

        function MouseEvents(objRef, evt) {

            var checkbox = objRef.getElementsByTagName("input")[0];

            if (evt.type == "mouseover") {

                objRef.style.backgroundColor = "orange";

            }

            else {

                if (checkbox.checked) {

                    objRef.style.backgroundColor = "aqua";

                }

                else if (evt.type == "mouseout") {

                    if (objRef.rowIndex % 2 == 0) {

                        //Alternating Row Color

                        objRef.style.backgroundColor = "#C2D69B";

                    }

                    else {

                        objRef.style.backgroundColor = "white";

                    }

                }

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
        <legend>PO TRACKING</legend>
        <table class="style1" style="width: 94%">
            <tr>
                <td style="text-align: left; width: 602px;">
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
                        <legend>PO TRACKING INFO</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 143px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label53" runat="server" Text="Po No :"></asp:Label>
                                </td>
                                <td style="width: 196px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtPoNo" runat="server" Width="150px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black" ontextchanged="txtPoNo_TextChanged" AutoPostBack="true" ></asp:TextBox>
                                    <%--<asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />--%>
                                      
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" 
                                        Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 112px; text-align: right; height: 22px;">
                                   
                                    <asp:Label ID="Label58" runat="server" Text="Freight :" style="margin-left:-42px" class="PoDrderLabel"></asp:Label>
                                   
                                </td>
                                <td style="width: 112px; text-align: right; height: 22px;">
                                   
                                    <asp:TextBox ID="txtFreight" runat="server" Width="152px"
                                        BackColor="Yellow" Font-Bold="False" ForeColor="Black" ReadOnly="True" ></asp:TextBox>
                                   
                                </td>
                                <td style="width: 112px; text-align: right; height: 22px;">
                                   
                                    <asp:Label ID="lblTotalAmount" runat="server"  Text="Total Amount :" ></asp:Label>
                                   
                                </td>
                                <td>
                                   
                                    <asp:TextBox ID="txtTotalAmount" runat="server"  Width="152px" 
                                         BackColor="Yellow" ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 143px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 196px; text-align: left;">
                                    <asp:GridView ID="gvPoSearch" runat="server" AutoGenerateColumns="False" ShowHeader="False"  style="margin-top:-13px;position: absolute"
                                        onrowdatabound="gvPoSearch_RowDataBound" EnableViewState="true"
                                         GridLines="None" AllowPaging="false" CssClass="mGrid"  PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        onselectedindexchanged="gvPoSearch_SelectedIndexChanged" Width="154px" 
                                        Height="32px">
                                        <Columns>
                                            <asp:BoundField DataField="PO_NUMBER"/>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="width: 112px; text-align: right;">
                                   
                                    <asp:Label ID="lblTrackingChargeFee" runat="server" Text="Packing Charge Fee :" 
                                        style="margin-left:0px;margin-top:0px"></asp:Label>
                                    
                                 </td>
                                <td style="width: 112px; text-align: right;">
                                   
                                    <asp:TextBox ID="txtTrackingChargeFee" runat="server" Width="152px" 
                                        style="margin-top:0px; top:0px"
                                        BackColor="Yellow" Font-Bold="False"
                                        ForeColor="Black" ReadOnly="True" ></asp:TextBox>
                                   
                                 </td>
                                <td style="width: 112px; text-align: right;">
                                   
                                    <asp:Label ID="lblBalance" runat="server"  Text="Balance :" ></asp:Label>
                                   
                                 </td>
                                <td>
                                   
                                    <asp:TextBox ID="txtBalance" runat="server"  Width="152px" ReadOnly="True" 
                                        BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 143px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 196px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 112px; text-align: right;">
                                   
                                    <asp:Label ID="lblDidcount" runat="server"  Text="Discount :" ></asp:Label>
                                   
                                 </td>
                                <td style="width: 112px; text-align: right;">
                                   
                                    <asp:TextBox ID="txtDiscount" runat="server" Width="152px" BackColor="Yellow" 
                                        ReadOnly="True"></asp:TextBox>
                                   
                                 </td>
                                <td style="width: 112px; text-align: right;">
                                   
                                    &nbsp;</td>
                                <td>
                                   
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                 <td style="text-align: right" colspan="6">
                                     <fieldset>
                                        <legend>SEARCH RESULT</legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvPoTracking1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Width="959px">
                                                        <Columns>
                                                            <asp:BoundField DataField="ISSUE_DATE" HeaderText="ISSUE DATE" />
                                                            <asp:BoundField DataField="DELIVERY_DATE" HeaderText="DELIVERY DATE" />
                                                            <asp:BoundField DataField="OFFER_NO" HeaderText="OFFER NO" />
                                                            <asp:BoundField DataField="TRADE_TERMS" HeaderText="TRADE TERMS" />
                                                            <asp:BoundField DataField="PORT_OF_LOADING" HeaderText="PORT OF LOADING" />
                                                            <asp:BoundField DataField="PORT_OF_DISCHARGE" HeaderText="PORT OF DISCHARGE" />
                                                            <%--<asp:BoundField DataField="FREIGHT" HeaderText="FREIGHT" />--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                               <td colspan="2">
                                                    <asp:GridView ID="gvPoTracking2" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" Width="959px">
                                                        <Columns>
                                                            <asp:BoundField DataField="CURRENCY_NAME" HeaderText="CURRENCY" />
                                                            <asp:BoundField DataField="SHIPMENT_TYPE_NAME" HeaderText="S.TYPE" />
                                                            <asp:BoundField DataField="PAYMENT_MODE_NAME" HeaderText="P.MODOE" />
                                                            <asp:BoundField DataField="PART_SHIPMENT_NAME" HeaderText="P.SHIPMENT" />
                                                            <asp:BoundField DataField="TRAN_SHIPMENT_NAME" HeaderText="T.SHIPMENT" />
                                                            <asp:BoundField DataField="PURCHASE_NAME" HeaderText="PURCHASE" />
                                                            <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />                                                           
                                                           
                                                            <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                 </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="6">
                                    <fieldset>
                                        <legend>PO TRACKING ENTRY </legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvPoTracking3" runat="server" DataSourceID="" AutoGenerateColumns="false"
                                                         OnRowDataBound="gvPoTracking3_OnRowDataBound" AllowSorting="True"
                                                        EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="gvPoTracking3_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvPoTracking3_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvPoTracking3_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvPoTracking3_OnSelectedIndexChanged" OnRowDeleting="gvPoTracking3_RowDeleting" Width="634px">
                                                        <Columns>
                                                            <asp:TemplateField ItemStyle-Width="1%">  
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkPartNo" runat="server" onclick="Check_Click(this)"  AutoPostBack="false" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DESCRIPTION" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtProductDescription" runat="server" Text='<%#Eval("PARTICULAR_NAME")%> '
                                                                        Font-Bold="true" Width="90" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PART NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPartNo" runat="server" Text='<%#Eval("PART_NO")%> ' Font-Bold="true"
                                                                        Width="80" BackColor="Yellow" ></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="UNIT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPoUnitName" runat="server" Text='<%#Eval("PO_UNIT_NAME")%> ' Font-Bold="true" BackColor="Yellow" ReadOnly="true"
                                                                        Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtApprovedQty" runat="server" Text='<%#Eval("APPROVED_QTY")%> ' Font-Bold="true"  BackColor="Yellow"
                                                                        Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="S.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtShipQuantity" runat="server" Text='<%#Eval("SHIP_QTY")%> ' Font-Bold="true"
                                                                        Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="R.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtReminingQuantity" runat="server" Text='<%#Eval("REMAINING_QTY")%> ' Font-Bold="true"  BackColor="Yellow"
                                                                        Width="40"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="T.PRICE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("PRICE")%> ' Font-Bold="true"
                                                                        Width="60" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="BL.NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBlNo" runat="server" Text='<%#Eval("BL_NO")%> ' Font-Bold="false"
                                                                        Width="80"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="S.DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="dtpShipmentDate" runat="server" Text='<%#Eval("SHIPMENT_DATE")%> ' Font-Bold="false" CssClass="date"
                                                                        Width="70"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ETA.DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="dtpEtaDate" runat="server" Text='<%#Eval("ETA_DATE")%> ' Font-Bold="false" CssClass="date"
                                                                        Width="70"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DR.DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="dtpDocRecevingDate" runat="server" Text='<%#Eval("DOC_RECEVING_DATE")%> ' Font-Bold="false" CssClass="date"
                                                                        Width="70"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DH.DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="dtpDocHandoverDate" runat="server" Text='<%#Eval("DOC_HANDOVER_DATE")%> ' Font-Bold="false" CssClass="date"
                                                                        Width="70"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="D.DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="dtpShipDeliveryDate" runat="server" Text='<%#Eval("SHIP_DELIVERY_DATE")%> ' Font-Bold="false" CssClass="date"
                                                                        Width="70"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>  
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                        <asp:Label ID="lblTranId" runat="server" Text='<%#Eval("TRAN_ID")%> '
                                                                         Width="5" BackColor="Yellow"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>                        
                                                    <asp:GridView ID="gvPoTracking4" runat="server" DataSourceID="" 
                                                        AutoGenerateColumns="false" DataKeyNames="TRAN_ID" style="margin-top:-10px;" AllowSorting="True"
                                                        EnableViewState="true" GridLines="None" AllowPaging="false"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr"
                                                        CausesValidation="false"  AlternatingRowStyle-CssClass="alt" Width="200px" 
                                                        OnRowDeleting="gvPoTracking4_RowDeleting">
                                                       <Columns>

                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTranId" runat="server" Text='<%#Eval("TRAN_ID")%> ' Font-Bold="true" Width="10" BackColor="Yellow" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="A.AMOUNT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtAdvanceAmount" runat="server" Text='<%#Eval("ADVANCE_AMOUNT")%> ' Font-Bold="true" Width="100"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="P.DATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="dtpPaymentDate" runat="server" Text='<%#Eval("PAYMENT_DATE")%> ' Font-Bold="true" CssClass="date"
                                                                        Width="95"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" OnClientClick="return isDelete();">Delete
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:Button ID="btnRowAdd" runat="server" Height="30px" Text="Add Row" Width="60px" style="margin-top:-10px;"
                                                CssClass="styled-button-4" OnClick="btnRowAdd_Click" />
                                   <%-- <asp:Button ID="btnAdvanceInfoSave" runat="server" Height="30px" Text="Save" Width="50px" style="margin-top:-10px;" OnClick="btnAdvanceInfoSave_Click"
                                        CssClass="styled-button-4" />--%>
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
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="6">

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


            $("[id *= txtShipQuantity]").bind("change", Deductions);
           

            // $("[id *= txtTotalPrice]").bind("change", Deductions);            

        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {

                    var row = $(this).closest("tr");
                    var result = new Object();

                    result.ApprovedQty = $("[id *= txtApprovedQty]", row).val();
                    result.ShipQuantity = $("[id *= txtShipQuantity]", row).val();
                    result.ReminingQuantity = result.ApprovedQty - result.ShipQuantity;
                    $("[id *= txtReminingQuantity]", row).val(result.ReminingQuantity);

                    

                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

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
