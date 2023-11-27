<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="ForeignFabricIssue.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ForeignFabricIssue" %>

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

                        $('#btnAdd').click();

                    }

                }

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
        <legend>FOREIGN FABRIC ISSUE</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 177px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>

            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>FABRIC ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right; height: 22px;">
                                    <asp:Label ID="Label51" runat="server" Text="SR/Challan No :"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtChallanNo" runat="server" Width="125px" BackColor="White" Font-Bold="True"
                                        ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                                        OnClick="btnSearch_Click" />
                                </td>
                                <td style="text-align: right; height: 22px;">
                                    <asp:Label ID="Label48" runat="server" Text="Supplier :"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 22px;">
                                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="160px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right; height: 22px;">&nbsp;</td>
                                <td style="height: 22px">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label52" runat="server" Text="Issue Date :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="dtpIssueDate" runat="server" Width="125px" BackColor="White" Placeholder="dd/mm/yyyy"
                                        CssClass="date" ForeColor="Black"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label47" runat="server" Text="Store :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlStoreId" runat="server" Width="160px" Height="22px"
                                        OnSelectedIndexChanged="ddlStoreId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="6">
                                    <fieldset>
                                        <legend>FABRIC ISSUE ENTRY RESULT </legend></div>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvFabricDetails" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvFabricDetails_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" OnRowEditing="gvFabricDetails_OnRowEditing"
                                                        DataKeyNames="TRAN_ID" OnRowDeleting="gvContractDetails_RowDeleting"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" CausesValidation="false"
                                                        OnRowCommand="gvFabricDetails_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvFabricDetails_PageIndexChanging"
                                                        OnSelectedIndexChanged="gvFabricDetails_SelectedIndexChanged">
                                                        <Columns>


                                                            <asp:TemplateField HeaderText="PROGRAMME" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlProgrammeId" DataTextField="PROGRAMME_NAME" OnSelectedIndexChanged="ddlProgrammeId_SelectedIndexChanged"
                                                                        AutoPostBack="true" DataValueField="PROGRAMME_ID" runat="server" Width="120">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="FABRIC" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlFabricId" TabIndex="5" DataTextField="FABRIC_NAME" DataValueField="FABRIC_ID"
                                                                        runat="server" Width="100">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CONST" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlFabricConstructionId" TabIndex="6" DataTextField="FABRIC_CONSTRUCTION_NAME"
                                                                        DataValueField="FABRIC_CONSTRUCTION_ID" runat="server" Width="100">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="STYLE" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlStyleId" TabIndex="6" DataTextField="STYLE_NO"
                                                                        AutoPostBack="false" DataValueField="STYLE_ID" runat="server" Width="100">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="ART" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlArtId" TabIndex="4" DataTextField="ART_NO" DataValueField="ART_ID"
                                                                        runat="server" Width="100">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="COLOR" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlColorId" TabIndex="4" DataTextField="COLOR_NAME" DataValueField="COLOR_ID"
                                                                        runat="server" Width="100">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="UNIT" ItemStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddlUnitId" TabIndex="7" AutoPostBack="true" DataTextField="UNIT_NAME"
                                                                        DataValueField="UNIT_ID" OnSelectedIndexChanged="ddlUnitId_SelectedIndexChanged"
                                                                        runat="server" Width="70">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="REC.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtReceiveQuantity" TabIndex="9" runat="server" Width="60" Text='<%#Eval("RECEIVE_QUANTITY")%>'
                                                                        BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ISS.QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtIssueQuantity" TabIndex="10" runat="server" Width="60" Text='<%#Eval("ISSUE_QUANTITY")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="BALANCE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRemainingQuantity" TabIndex="10" runat="server" Width="60" Text='<%#Eval("REMAINING_QUANTITY")%>'
                                                                        BackColor="Yellow"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTranId" TabIndex="10" runat="server" Width="10" Text='<%#Eval("TRAN_ID")%>'
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
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="6">
                                    <asp:TextBox ID="txtTotalReceiveQuantity" runat="server" Height="21px"
                                        Width="108px" placeholder="RECEIVE QUANTITY"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True"
                                        ToolTip="Total Receive Quantity"></asp:TextBox>
                                    <asp:TextBox ID="txtTotalIssueQuantity" runat="server" Height="21px" Width="108px"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True" placeholder="ISSUE QUANTITY"
                                        ToolTip="Total Issue Quantity"></asp:TextBox>
                                    <asp:TextBox ID="txtTotalRemainingQuantity" runat="server" Height="21px" Width="108px"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True" placeholder="REMAINING QUANTITY"
                                        ToolTip="Total Remaining Quantity"></asp:TextBox>
                                </td>
                            </tr>
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

                <td style="text-align: left" colspan="6">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
    </tr>
        </table>
    </fieldset>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script src="js/jquery.js" type="text/javascript"></script>


    <script type="text/javascript">
        $(document).ready(function () {

            //            $('[id$=txtChallanNo]').focus();
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

            $("[id *= txtIssueQuantity]").bind("change", Deductions);

        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();

                    result.total = $("[id *= txtIssueQuantity]", row).val();

                    result.totalDeductions = $("[id *= txtReceiveQuantity]", row).val();

                    result.netTotal = Math.abs(result.total - result.totalDeductions);

                    $("[id *= txtRemainingQuantity]", row).val(result.netTotal);
                }
                else {
                    $(this).val('');
                }
            }
        }
    </script>

    <table class="style1">
        <tr>
            <td>
                <fieldset>
                    <legend>SEARCH FOREIGN FABRIC ISSUE </legend>
                    <table class="style1">
                        <tr>
                            <td style="width: 123px; text-align: right; height: 27px;">
                                <asp:Label ID="Label9" runat="server" Text="Year :"></asp:Label>
                            </td>
                            <td style="width: 208px; height: 27px;">
                                <asp:TextBox ID="txtYear" runat="server" Height="21px" Width="108px"
                                    Font-Bold="True"></asp:TextBox>
                                <asp:Button ID="btnSearchRecord" runat="server" CssClass="styled-button-4" Height="22px"
                                    Text="...." Width="36px" OnClick="btnSearchRecord_Click" />
                            </td>
                            <td style="width: 163px; text-align: right; height: 27px;">
                                <asp:Label ID="Label13" runat="server" Text="Lot/Style :"></asp:Label>
                            </td>
                            <td style="height: 27px">
                                <asp:DropDownList ID="ddlStyleIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 243px; height: 27px;">
                                <asp:Label ID="Label23" runat="server" Text="Programme : "></asp:Label>
                            </td>
                            <td style="width: 12px; height: 27px;">
                                <asp:DropDownList ID="ddlProgrammeIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 79px; height: 27px;">
                                <asp:Label ID="Label25" runat="server" Text="Art :"></asp:Label>
                            </td>
                            <td style="height: 27px">
                                <asp:DropDownList ID="ddlArtIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 123px; text-align: right;">
                                <asp:Label ID="Label12" runat="server" Text="Invoice/Challan No: "></asp:Label>
                            </td>
                            <td style="width: 208px">
                                <asp:TextBox ID="txtChallanNoSearch" runat="server" Height="21px" Width="108px"></asp:TextBox>
                            </td>
                            <td style="width: 163px; text-align: right;">
                                <asp:Label ID="Label49" runat="server" Text="Fabric :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlFabricIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right; width: 243px">
                                <asp:Label ID="Label24" runat="server" Text="Supplier : "></asp:Label>
                            </td>
                            <td style="width: 12px">
                                <asp:DropDownList ID="ddlSupplierIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 79px">
                                <asp:Label ID="Label50" runat="server" Text="Construction :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlConstructioIdSearch" runat="server" Height="22px"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </fieldset>


            </td>
        </tr>
        <tr>
            <td>
                <fieldset>
                    <legend>SEARCH RESULT</legend>
                    <asp:GridView ID="gvForeignFabric" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvForeignFabric_PageIndexChanging"
                        CausesValidation="false" DataKeyNames="TRAN_ID"
                        OnSelectedIndexChanged="gvForeignFabric_SelectedIndexChanged"
                        OnRowCommand="gvForeignFabric_RowCommand">
                        <Columns>


                            <asp:BoundField DataField="ISSUE_DATE" HeaderText="ISSUE DATE" />
                            <asp:BoundField DataField="CHALLAN_NO" HeaderText="CHALLAN" />

                            <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />
                            <asp:BoundField DataField="STORE_NAME" HeaderText="LOCATION" />
                            <asp:BoundField DataField="PROGRAMME_NAME" HeaderText="PROGRAMME" />
                            <asp:BoundField DataField="FABRIC_NAME" HeaderText="FABRIC" />
                            <asp:BoundField DataField="FABRIC_CONSTRUCTION_NAME" HeaderText="CONST" />
                            <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE" />
                            <asp:BoundField DataField="COLOR_NAME" HeaderText="STYLE" />
                            <asp:BoundField DataField="ART_NO" HeaderText="ART" />

                            <asp:BoundField DataField="ISSUE_QUANTITY" HeaderText="I.QTY" />


                            <asp:BoundField DataField="TRAN_ID" HeaderText="ID" />

                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"
                                        AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                </fieldset>
            </td>
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
