<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ShipmentInfo.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ShipmentInfo" %>

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
    <script type="text/javascript">
        function isDelete() {

            return confirm("Do you want to delete this row ?");

        }
    </script>




    <%-- <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtInvoiceNo.ClientID %>").focus(); }) 
    </script>--%>
    <script type="text/javascript" language="javascript">

        function controlEnter(obj, event) {

            var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;

            if (keyCode == 13) {
                document.getElementById('<%= btnSave.ClientID %>').click();
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

    <script type="text/javascript">
        function DeleteSubRecord(e) {
         <%-- document.getElementById('<%= btnSave.ClientID %>').click();--%>
        }
    </script>

    <%-- Auto fill or Complete Textbox--%>
    <%-- <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtInvoiceNo.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ShipmentInfo.aspx/GetInvoiceNo",
                        data: "{ 'InvoiceNo':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter : function (data) {return data;},
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });
    </script>--%>

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
        <legend>SHIPMENT INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 360px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: right;">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>SHIPMENT INFO ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 198px; text-align: right; height: 22px;">
                                    <asp:Label ID="lblInvoiceNo" runat="server" Text="Invoice No :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtInvoiceNo" runat="server" Width="238px" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 74px; text-align: right; height: 22px;">
                                    <asp:Label ID="lblBuyerName" runat="server" Text="Buyer Name :"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 168px; text-align: right;"></td>


                            </tr>
                            <tr>
                                <td style="width: 198px; text-align: right">
                                    <asp:Label ID="lblInvoiceDate" runat="server" Text="Invoice Date :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="dtpInvoiceDate" runat="server" Width="236px" Font-Bold="False"
                                        BackColor="White" CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 74px; text-align: right;">
                                    <asp:Label ID="lblShipDate" runat="server" Text="Ship Date :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="dtpShipDate" runat="server" Width="236px" Font-Bold="False"
                                        BackColor="White" CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 168px; text-align: right; height: 22px;"></td>


                            </tr>
                            <tr>
                                <td style="width: 198px; text-align: right">
                                    <asp:Label ID="lblRemarks" runat="server" Text="Remarks :"></asp:Label>
                                </td>
                                <td style="width: 288px; text-align: left;">
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="236px" BackColor="White" Font-Bold="False"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 74px; text-align: right;">&nbsp;</td>
                                <td style="text-align: left;">&nbsp;</td>
                                <td></td>


                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="5">
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete"
                                        Width="66px" OnClick="btnDelete_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnReport" runat="server" Height="31px" Text="Report"
                                        Width="66px"
                                        CssClass="styled-button-4" OnClick="btnReport_Click" />
                                    <asp:Button ID="btnReportByPOWise" runat="server" Height="31px" Text="PO Wise Report"
                                        Width="100px"
                                        CssClass="styled-button-4" OnClick="btnReportByPOWise_Click" />
                                </td>


                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="5">

                                    <fieldset>
                                        <legend>REPORT CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="text-align: right; width: 292px;" class="auto-style2">
                                                    <asp:Label ID="Label34" runat="server" Text="PO :"></asp:Label>

                                                </td>
                                                <td style="width: 161px; height: 22px;">
                                                    <asp:TextBox ID="txtPONo" runat="server" Width="160px" BackColor="White"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px;">
                                                    <asp:Button ID="btnDateSrc" runat="server" Text="..."
                                                        Width="30px"
                                                        CssClass="styled-button-4" Height="23px" OnClick="btnDateSrc_Click" />
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="From Date :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="160px" BackColor="White" CssClass="date"></asp:TextBox>
                                                    <asp:TextBox ID="txtPOId" runat="server" Width="20px" CssClass="date"
                                                        BackColor="Yellow"></asp:TextBox>
                                                    <asp:Button ID="btnForPO" runat="server" Text="..."
                                                        Width="30px" OnClick="btnForPO_Click"
                                                        CssClass="styled-button-4" Style="visibility: hidden; display: none;" Height="21px" />
                                                    <asp:Button ID="btnForQuantity" runat="server" Text="..."
                                                        Width="30px" OnClick="btnForQuantity_Click"
                                                        CssClass="styled-button-4" Style="visibility: hidden; display: none;" Height="21px" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right; width: 292px;" class="auto-style3">
                                                    <asp:Label ID="Label35" runat="server" Text="Buyer :"></asp:Label>

                                                </td>
                                                <td style="width: 161px">
                                                    <asp:DropDownList ID="ddlBuyerSearchId" runat="server" Width="163px"
                                                        Height="20px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label40" runat="server" Text="To Date :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="dtpToDate" runat="server" Width="160px" BackColor="White" CssClass="date"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>


                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="5">
                                    <fieldset>
                                        <legend>SHIPMENT INFO SEARCH</legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvShipmentInfo" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        DataKeyNames="TRAN_ID" OnRowDataBound="gvShipmentInfo_OnRowDataBound" AllowSorting="True"
                                                        EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="gvShipmentInfo_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" CausesValidation="false"
                                                        OnRowCommand="gvShipmentInfo_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnRowDeleting="gvShipmentInfo_RowDeleting" Style="margin-bottom: -3px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="PO NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPONo" runat="server" Text='<%#Eval("PO_NO")%>' AutoPostBack="true"
                                                                        OnTextChanged="txtPONo_TextChanged" Width="200"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--<asp:TemplateField HeaderText="STYLE NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtStyleNo" runat="server" Text='<%#Eval("STYLE_NO")%> ' Width="220"
                                                                        AutoPostBack="true" OnTextChanged="txtStyleNo_TextChanged"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="STYLE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlStyleId" DataTextField="STYLE_NO" DataValueField="STYLE_ID"
                                                                        runat="server" Width="180">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("RATE")%> ' Width="160"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="QUANTITY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtQuantity" runat="server" Text='<%#Eval("QUANTITY")%> '
                                                                        Font-Bold="true" Width="180" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="AMOUNT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtAmount" runat="server" Text='<%#Eval("AMOUNT")%> '
                                                                        Font-Bold="true" Width="160" BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTranId" runat="server" Text='<%#Eval("TRAN_ID")%> ' Width="20"
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
                                            <tr>
                                                <td>
                                                    <asp:Label ID="label11" runat="server" Width="568px" Height="22px" Text="Total:"
                                                        Style="text-align: right; font-size: 14px; color: black; font-weight: bold" Font-Bold="true"
                                                        ReadOnly="True"></asp:Label>
                                                    <asp:TextBox ID="txtTotalQuantity" runat="server" Font-Bold="true"
                                                        ReadOnly="True" BackColor="WhiteSmoke" Width="190px"></asp:TextBox>
                                                    <asp:TextBox ID="txtTotalAmount" runat="server" Font-Bold="true"
                                                        ReadOnly="True" BackColor="WhiteSmoke" Width="167px" Style="margin-left: -5px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                                        Font-Names="Tahoma"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="5">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="5"></td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
    <%--   <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
    <%-- <script src="js/jquery.js" type="text/javascript"></script>--%>


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

            $("[id *= txtPONo]").bind("change", SearchStyle);
            $("[id *= txtRate]").bind("change", Deductions);
            $("[id *= txtQuantity]").bind("change", Deductions);
            $("[id *= txtQuantity]").bind("change", TotalQuantity);
        });

        function SearchStyle() {
            $('[id$=btnForPO]').click();
        }
        function TotalQuantity() {
            $('[id$=btnForQuantity]').click();
        }

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();

                    result.Rate = $("[id *= txtRate]", row).val();
                    result.Quantity = $("[id *= txtQuantity]", row).val();

                    result.Amount = result.Rate * result.Quantity;
                    $("[id *= txtAmount]", row).val(result.Amount);


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
    <table style="width: 100%">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
            <td>&nbsp;
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
