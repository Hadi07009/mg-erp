<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="PoOrder.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PoOrder" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .PoDrderLabel{
                    margin-top: -55px;
                    position: absolute;
                   
                }
        .PoDrderDdl{
                    margin-top: -60px;
                    position: absolute;
                    margin-left: 0px;
                }
        .style4
        {
            height: 21px;
            width: 145px;
        }
        .style5
        {
            height: 22px;
            width: 145px;
        }
        .style6
        {
            width: 145px;
        }
        .auto-style1 {
            height: 21px;
            width: 308px;
        }
        .auto-style2 {
            height: 22px;
            width: 308px;
        }
        .auto-style3 {
            width: 308px;
        }
        .auto-style4 {
            height: 21px;
            width: 165px;
        }
        .auto-style5 {
            height: 22px;
            width: 165px;
        }
        .auto-style6 {
            width: 165px;
        }
        .auto-style7 {
            height: 21px;
            width: 183px;
        }
        .auto-style8 {
            height: 22px;
            width: 183px;
        }
        .auto-style9 {
            width: 183px;
        }
        .auto-style10 {
            height: 21px;
        }
        .auto-style11 {
            height: 22px;
        }
    </style>


    <script type="text/javascript" language="javascript">
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
        <legend>PURCHASE ORDER INFO</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 600px;">
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
                        <legend>PURCHASE ORDER ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right; " class="auto-style1">
                                    <asp:Label ID="lblPoRequisitionNo" runat="server" Text="Po Requisition No :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style4">
                                    <asp:TextBox ID="txtPoRequisitionNo" runat="server" Width="118px" 
                                        BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black" ontextchanged="txtPoRequisitionNo_TextChanged" AutoPostBack="true"></asp:TextBox>
                                      
                                    <asp:Button ID="btnSearchPoRequisitionNo" runat="server" Height="22px" 
                                        Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearchPoRequisitionNo_Click" />
                                          <asp:GridView ID="gvPoOrderSearch1" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False"  style="margin-top:0px;margin-left:0px; position: absolute"
                                        onrowdatabound="gvPoOrderSearch1_RowDataBound" EnableViewState="true"
                                         GridLines="None" AllowPaging="false" CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        onselectedindexchanged="gvPoOrderSearch1_SelectedIndexChanged" Width="125px" 
                                        Height="32px">
                                        <Columns>
                                            <asp:BoundField DataField="REQUISITION_NO"/>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="text-align: right; " class="auto-style4">
                                    <asp:Label ID="lblCurrency" runat="server"  Text="Currency :" style="margin-left:0px"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style10">
                                    <asp:DropDownList ID="ddlCurrencyId" runat="server" Width="150px" 
                                        Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style7" style=" text-align: right">
                                    
                                    <asp:Label ID="Label58" runat="server" Text="Freight :" style="margin-left:0px; margin-top: 0px"></asp:Label>
                                    
                                </td>
                                <td style=" text-align: right; height: 21px;">
                                   
                                    <asp:TextBox ID="txtFreight" runat="server" Width="147px" 
                                        BackColor="Yellow" Font-Bold="False"
                                        ForeColor="Black" ></asp:TextBox>
                                </td>
                               
                            </tr>
                            <tr style="margin-top:-100px">
                                <td style="text-align: right; " class="auto-style2">
                                    <asp:Label ID="lblPoNo" runat="server" Text="Po Number :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style5">
                                    <asp:TextBox ID="txtPoNumber" runat="server" Width="118px" BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black" ontextchanged="txtPoNumber_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                        <asp:GridView ID="gvPoOrderSearch2" runat="server" AutoGenerateColumns="False" 
                                        ShowHeader="False"   style="margin-top:0px;margin-left:0px;overflow:hidden; position: absolute"
                                        onrowdatabound="gvPoOrderSearch2_RowDataBound" EnableViewState="true"
                                         GridLines="None" AllowPaging="false" CssClass="mGrid"  
                                        PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                                        onselectedindexchanged="gvPoOrderSearch2_SelectedIndexChanged" Width="125px" 
                                        Height="32px">
                                        <Columns>
                                            <asp:BoundField DataField="PO_NUMBER"/>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td style="text-align: right; " class="auto-style5">
                                    <asp:Label ID="lblShipmentMode" runat="server" Text="Shipment Mode :" style="margin-left:0px" ></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style11">
                                    <asp:DropDownList ID="ddlShipmentModeId" runat="server" Width="150px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style=" text-align: right; " class="auto-style8">
                                    
                                    <asp:Label ID="lblTrackingChargeFee" runat="server" Text="Packing Charge Fee :" 
                                        style="margin-left:0px;margin-top:0px"></asp:Label>
                                    
                                </td>
                                <td style="text-align: left; height: 22px;">
                                   
                                    <asp:TextBox ID="txtTrackingChargeFee" runat="server" Width="147px" 
                                        style="margin-top:0px; top:0px"
                                        BackColor="Yellow" Font-Bold="False"
                                        ForeColor="Black" ></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; " class="auto-style2">
                                    <asp:Label ID="Label52" runat="server" Text="Issue Date :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style5">
                                    <asp:TextBox ID="txtIssueDate" runat="server" Width="150px" Font-Bold="False" BackColor="White"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="text-align: right; " class="auto-style5">
                                    <asp:Label ID="lblPaymentMode" runat="server" Text="Payment Mode :" style="margin-left:0px"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style11">
                                    <asp:DropDownList ID="ddlPaymentModeId" runat="server" Width="150px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right; " class="auto-style8">
                                    <asp:Label ID="lblDidcount" runat="server" Text="Discount :" style="margin-left:0px;margin-top:0px;"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 22px;">
                                   
                                    <asp:TextBox ID="txtDiscount" runat="server" Width="147px" 
                                        style="margin-top:0px"
                                        BackColor="Yellow" Font-Bold="False"
                                        ForeColor="Black" ></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style3">
                                    <asp:Label ID="Label54" runat="server" Text="Delivery Date :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style6">
                                    <asp:TextBox ID="txtDeliveryDate" runat="server" Width="150px" 
                                        BackColor="White" Font-Bold="False"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="text-align: right; " class="auto-style6">
                                    <asp:Label ID="lblPartshipment" runat="server" Text="Partshipment :" 
                                        style="margin-left:0px;"></asp:Label>
                                </td>
                                <td style="text-align: left; ">
                                    <asp:DropDownList ID="ddlPartshipmentId" runat="server" Width="150px"  Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style=" text-align: right; " class="auto-style9">
                                    <asp:Label ID="lblTotalAmount" runat="server" Text="Total Amount :" 
                                        style="margin-left: 0px;margin-top: 0px"></asp:Label>
                                </td>
                                <td style=" text-align: left;">
                                   
                                    <asp:TextBox ID="txtTotalAmount" runat="server" Width="147px" 
                                        style="margin-top:0px"
                                        BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Black" BorderColor="White" ReadOnly="True" ></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; " class="auto-style3">
                                    <asp:Label ID="Label53" runat="server" Text="Offer No :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style6">
                                    <asp:TextBox ID="txtOfferNo" runat="server" Width="150px" BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="text-align: right; " class="auto-style6">
                                    <asp:Label ID="lblTranshipment" runat="server" Text="Transhipment :" style="margin-left:0px"></asp:Label>
                                </td>
                                <td style="text-align: left; ">
                                    <asp:DropDownList ID="ddlTranshipmentId" runat="server" Width="150px" 
                                        Height="22px" style="margin-top: 0px">
                                    </asp:DropDownList>
                                   
                                </td>
                                <td style=" text-align: right; " class="auto-style9">
                                    &nbsp;</td>
                                <td style=" text-align: left;">
                                    <asp:TextBox ID="dtpPurchaseDate" runat="server" Width="50px"
                                        BackColor="Yellow" Font-Bold="False"
                                        ForeColor="Black" BorderColor="White" ReadOnly="True" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; " class="auto-style3">
                                    <asp:Label ID="Label57" runat="server" Text="Trade Terms :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style6">
                                    <asp:TextBox ID="txtTradeTerms" runat="server" Width="150px" 
                                        BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="text-align: right; " class="auto-style6">
                                    <asp:Label ID="lblSupplier" runat="server" Text="Vendor/Supplier :" style="margin-left:0px"></asp:Label>      
                                </td>
                                <td style="text-align: left; ">
                                   
                                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="150px" Height="22px">
                                    </asp:DropDownList>
                                                                     
                                </td>
                                <td style=" text-align: right; " class="auto-style9">
                                    &nbsp;</td>
                                <td style="text-align: left;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; " class="auto-style2">
                                    <asp:Label ID="Label55" runat="server" Text="Port of Loading :"></asp:Label>
                                    </td>
                                <td style="text-align: left; " class="auto-style5">
                                    <asp:TextBox ID="txtPortOfLoading" runat="server" Width="150px" 
                                        BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                    </td>
                                <%--<td style="text-align: right; " class="auto-style5">
                                    <asp:Label ID="lblSupplier0" runat="server" Text="Note :" 
                                        style="margin-left:0px"></asp:Label>      
                                </td>
                                <td style="text-align: left; " class="auto-style11">
                                    <asp:TextBox ID="txtNote" runat="server" Width="150px"
                                        BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>--%>

                                <td style="text-align: right; " class="auto-style6">
                                    <asp:Label ID="lblPurcharser" runat="server" Text="Purcharser :" style="margin-left:0px"></asp:Label>      
                                </td>
                                <td style="text-align: left; ">
                                   
                                    <asp:DropDownList ID="ddlPurcharser" runat="server" Width="150px" Height="22px">
                                    </asp:DropDownList>
                                                                     
                                </td>

                                <td style=" text-align: right; " class="auto-style8">
                                    &nbsp;</td>
                                <td style=" text-align: left; height: 22px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; " class="auto-style2">
                                    <asp:Label ID="Label56" runat="server" Text="Port of Discharges :" ></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style5">
                                    <asp:TextBox ID="txtPortOfDischarges" runat="server" Width="150px"
                                        BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <%--<td style="text-align: left; " class="auto-style5">
                                    &nbsp;</td>
                                <td style="text-align: left; " class="auto-style11">
                                    &nbsp;</td>--%>
                                <td style="text-align: right; " class="auto-style5">
                                    <asp:Label ID="lblSupplier0" runat="server" Text="Note :" 
                                        style="margin-left:0px"></asp:Label>      
                                </td>
                                <td style="text-align: left; " class="auto-style11">
                                    <asp:TextBox ID="txtNote" runat="server" Width="150px"
                                        BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style=" text-align: right; " class="auto-style8">
                                    &nbsp;</td>
                                <td style=" text-align: left; height: 22px;">
                                   
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="6">
                                    <fieldset>
                                        <legend>PURCHASE ORDER ENTRY</legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvPoOrder" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvPoOrder_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" OnRowEditing="gvPoOrder_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvPoOrder_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvPoOrder_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvPoOrder_OnSelectedIndexChanged">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="DESCRIPTION" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtProductDescription" runat="server" Text='<%#Eval("PARTICULAR_NAME")%> '
                                                                        Font-Bold="true" Width="200" BackColor="Yellow" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PART NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPartNo" runat="server" Text='<%#Eval("PART_NO")%> ' Font-Bold="true"
                                                                        Width="150" BackColor="Yellow" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="UNIT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPoUnitName" runat="server" Text='<%#Eval("PO_UNIT_NAME")%> ' Font-Bold="true" BackColor="Yellow" ReadOnly="true"
                                                                        Width="130"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtApprovedQty" runat="server" Text='<%#Eval("APPROVED_QTY")%> ' Font-Bold="true"  BackColor="Yellow"
                                                                        Width="130" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("RATE")%> ' Width="130"  BackColor="Yellow" Font-Bold="true" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PRICE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("PRICE")%> ' Font-Bold="true"
                                                                        Width="150" BackColor="Yellow" ReadOnly="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                        <asp:Label ID="lblTranId" runat="server" Text='<%#Eval("TRAN_ID")%> '
                                                                         Width="10" BackColor="Yellow"></asp:Label>
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
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                </td>
                            </tr>
                            <tr>
                                 <td style="text-align: right" colspan="6">
                                    <%--<fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="text-align: right; width: 383px;" class="style4">
                                    <asp:Label ID="Label50" runat="server" Text="Po Number :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                    <asp:TextBox ID="txtSrcPoNumber" runat="server" Width="175px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 65px;">
                                                    <asp:Button ID="btnSearchRecord" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearchRecord_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 236px;">
                                                    &nbsp;</td>
                                                <td style="height: 22px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 383px;" class="style5">
                                    <asp:Label ID="Label51" runat="server" Text="Date :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                    <asp:TextBox ID="txtSrcIssueDate" runat="server" Width="175px" BackColor="White" 
                                                        Font-Bold="True" CssClass="date"
                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="width: 65px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 236px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 383px;" class="style5">
                                    <asp:Label ID="Label58" runat="server" Text="Delivery Date :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                    <asp:TextBox ID="txtSrcDeliveryDate" runat="server" Width="175px" BackColor="White" 
                                                        Font-Bold="True" CssClass="date"
                                        ForeColor="Black"></asp:TextBox>
                                                </td>
                                                <td style="width: 65px">
                                                    &nbsp;</td>
                                                <td style="text-align: right; width: 236px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </fieldset>--%>
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

                        if (nextIndex < (n)) {

                            $('input:text,select')[nextIndex].focus();                       
                         }

                        else{

                            $('input:text,select')[nextIndex - 1].blur();

                            $('[id$=btnAdd]').click();
                        }

                }

            });
        });

    </script>

 <%--   <script type="text/javascript">
        $(document).ready(function () {


            $("[id *= txtPrice]").bind("change", Deductions);
            $("[id *= txtAdvanceAmount]").bind("change", Deductions);            
            
           // $("[id *= txtTotalPrice]").bind("change", Deductions);            

        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {

                    var row = $(this).closest("tr");
                    var result = new Object();

                    result.Price = $("[id *= txtPrice]", row).val();
                    result.AdvanceAmount = $("[id *= txtAdvanceAmount]", row).val();
                    result.Total = result.Price - result.AdvanceAmount;
                    $("[id *= txtTotalPrice]", row).val(result.Total);
                   


                }
                else {
                    $(this).val('');
                }
            }
        }
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
