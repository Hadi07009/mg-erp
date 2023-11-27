<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="SewingThreadReceive.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.SewingThreadReceive" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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

                        $('#btnADD').click();

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
        $(window).load(function () { document.getElementById("<%= ddlSupplierId.ClientID %>").focus(); }) 
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
        <legend>SEWING THREAD RECEIVE INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 804px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>SEWING THREAD RECEIVE ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 420px; text-align: right; height: 22px;">
                                    <strong>
                                        <asp:Label ID="Label48" runat="server" Text="Supplier :" Font-Bold="False"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 225px; text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="width: 208px; text-align: right; height: 22px;">
                                    <strong>
                                        <asp:Label ID="Label46" runat="server" Text="Receive Date :" CssClass="date"
                                            Font-Bold="False"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 269px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="dtpReceiveDate" runat="server" Width="150px" BackColor="White" Font-Bold="False"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;">&nbsp;</td>
                                <td style="height: 22px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 420px; text-align: right; height: 22px;">
                                    <strong>
                                        <asp:Label ID="Label49" runat="server" Text="Challan No :" Font-Bold="False"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 225px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtChallanNo" runat="server" Width="150px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="width: 208px; text-align: right; height: 22px;">
                                    <strong>
                                        <asp:Label ID="Label59" runat="server" Text="Programme :" Font-Bold="False"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 269px; text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlProgrammeId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 238px; text-align: right; height: 22px;"></td>
                                <td style="height: 22px"></td>
                            </tr>
                            <tr>
                                <td style="width: 420px; text-align: right; height: 23px;">
                                    <strong>
                                        <asp:Label ID="Label47" runat="server" Text="Color:" Font-Bold="False"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 225px; text-align: left; height: 23px;">
                                    <asp:DropDownList ID="ddlColorId" runat="server" Width="156px"
                                        Height="23px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 208px; text-align: right; height: 23px;">
                                    <strong>
                                        <asp:Label ID="Label61" runat="server" Text="1$= :"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 269px; text-align: justify; height: 23px;">
                                    <asp:TextBox ID="txtDollarToTaka" runat="server" Width="69px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <strong>
                                        <asp:Label ID="Label62" runat="server" Text="TK"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 238px; text-align: right; height: 23px;"></td>
                                <td style="height: 23px"></td>
                            </tr>

                            <tr>
                                <td style="width: 420px; text-align: right; height: 22px;">
                                    <strong>
                                        <asp:Label ID="Label57" runat="server" Text="Brand :" Font-Bold="False"></asp:Label>
                                    </strong>
                                </td>
                                <td style="width: 225px; text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlBrandId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 208px; text-align: right; height: 22px;">&nbsp;</td>
                                <td style="width: 269px; text-align: justify; height: 22px;">&nbsp;</td>
                                <td style="width: 238px; text-align: right; height: 22px;"></td>
                                <td style="height: 22px"></td>
                            </tr>

                            <tr>
                                <td style="width: 420px; text-align: right">&nbsp;</td>
                                <td style="width: 225px; text-align: left;">&nbsp;</td>
                                <td style="width: 208px; text-align: right;">&nbsp;</td>
                                <td style="width: 269px; text-align: left;">&nbsp;</td>
                                <td style="width: 238px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="text-align: right" colspan="6">
                                    <%--<legend>ZIPPER L/C RECEIVE ENTRY </legend>--%>
                                    <table class="style1">
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


                                                        <asp:TemplateField HeaderText="THREAD COUNT" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtThreadCount" runat="server" Text='<%#Eval("THREAD_COUNT")%> '
                                                                    Width="100" Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ART " ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlArtId" DataTextField="ART_NO" DataValueField="ART_ID"
                                                                    runat="server" Width="160">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>

                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="QTY" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtQuantity" runat="server" Text='<%#Eval("RECEIVE_QUANTITY")%> '
                                                                    Width="100" Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RATE" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtRate" runat="server" Text='<%#Eval("RATE")%> ' Width="100" Font-Bold="true"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="CURRENCY" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddlCurrencyId" DataTextField="CURRENCY_NAME" DataValueField="CURRENCY_ID"
                                                                    runat="server" Width="160">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>




                                                        <asp:TemplateField HeaderText="TOTAL($)" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTotalAmount" runat="server" Text='<%#Eval("TOTAL_AMOUNT")%> '
                                                                    Font-Bold="true" Width="130"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TOTAL TAKA" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtTotalAmountUSD" runat="server" Text='<%#Eval("TOTAL_AMOUNT_USD")%> '
                                                                    Width="130"
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
                <td style="text-align: left; width: 420px;">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left; width: 225px;">&nbsp;</td>
                <td style="text-align: left" colspan="2">&nbsp;</td>
                <td style="text-align: left">&nbsp;</td>
                <td style="text-align: left">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="6">
                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add Row" Width="66px"
                        CssClass="styled-button-4" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px"
                        CssClass="styled-button-4" OnClick="btnSave_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                        CssClass="styled-button-4" />
                </td>
            </tr>
        </table>
    </fieldset>
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

            $("[id *= txtPOPrice]").bind("change", Deductions);
            $("[id *= txtUnitCost]").bind("change", Deductions);
            $("[id *= txtOrderQuantity]").bind("change", Deductions);
        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();




                    result.total = $("[id *= txtPOPrice]", row).val();
                    result.netTotal = result.total * 0.94;
                    $("[id *= txtUnitCost]", row).val(result.netTotal);


                    resultNew.total = $("[id *= txtUnitCost]", row).val();
                    resultNew.totalDeductions = $("[id *= txtOrderQuantity]", row).val();
                    resultNew.netTotal = resultNew.total * resultNew.totalDeductions;


                    $("[id *= txtTotalAmount]", row).val(resultNew.netTotal);
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
