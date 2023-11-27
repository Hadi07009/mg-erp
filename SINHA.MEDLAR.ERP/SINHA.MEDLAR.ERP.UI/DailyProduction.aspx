<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="DailyProduction.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.DailyProduction"%>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <%-- <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtPONo.ClientID %>").focus(); }) 
    </script>--%>
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

    <script language="javascript" type="text/javascript">

        document.body.style.cursor = 'pointer';

        var oldColor = '';

        function ChangeRowColor(rowID) {

            var color = document.getElementById(rowID).style.backgroundColor;

            if (color != 'yellow')

                oldColor = color;

            if (color == 'yellow')

                document.getElementById(rowID).style.backgroundColor = oldColor;

            else document.getElementById(rowID).style.backgroundColor = 'yellow';

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

    <%-- Auto fill or Complete Textbox--%>
    <%--  <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtPONo.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "POEntry.aspx/GetPONo",
                        data: "{ 'PONo':'" + request.term + "'}",
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
        <legend>DAILY PRODUCTION INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; ">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: right; ">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>DAILY PRODUCTION INFO ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="lblLineName" runat="server" Text="Line Name :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:DropDownList ID="ddlLineId" runat="server" Width="240px" Height="22px" 
                                        OnSelectedIndexChanged="ddlLineId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 74px; text-align: right;">&nbsp;</td>



                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="lblProductionDate" runat="server" Text="Production Date :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="dtpProductionDate" runat="server" Width="236px" Font-Bold="False"
                                        BackColor="White" CssClass="date" ForeColor="Black" 
                                        OnTextChanged="dtpProductionDate_TextChanged"></asp:TextBox>
                                </td>
                                <td style="width: 74px; text-align: right;">&nbsp;</td>



                            </tr>
                            <tr>
                                <td style="text-align: right">&nbsp;</td>
                                <td style="text-align: left;">&nbsp;</td>
                                <td style="width: 74px; text-align: right;">&nbsp;</td>



                            </tr>
                            <tr>
                                <td style="width: 402px; text-align: right">&nbsp;</td>
                                <td style="text-align: left;">
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnShow_Click" />
                                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAdd_Click"
                                        ViewStateMode="Enabled" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnReport" runat="server" Height="31px" Text="Report" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnReport_Click" />
                                </td>
                                <td style="width: 74px; text-align: right;">&nbsp;</td>



                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="3">
                                    <fieldset>
                                        <legend>DAILY PRODUCTION INFO SEARCH</legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvDailyProduction" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvDailyProduction_OnRowDataBound" AllowSorting="True"
                                                        EnableViewState="true" GridLines="None" AllowPaging="false" OnRowEditing="gvDailyProduction_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr"
                                                        OnSelectedIndexChanged="gvDailyProduction_OnSelectedIndexChanged" CausesValidation="false"
                                                        OnRowCommand="gvDailyProduction_RowCommand"
                                                        OnPageIndexChanging="gvDailyProduction_OnSelectedIndexChanged" 
                                                        OnRowCreated="gvDailyProduction_RowCreated">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="PO NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtPONo" runat="server" Text='<%#Eval("PO_NO")%> ' Font-Bold="true" Width="160"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="STYLE NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtStyleNo" runat="server" Text='<%#Eval("STYLE_NO")%> ' Font-Bold="true"
                                                                       Width="200"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ORDER" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtOrderQty" runat="server" Text='<%#Eval("ORDER_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CUT QTY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtCuttingIssuedQty" runat="server" Text='<%#Eval("CUTTING_ISSUED_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CUT DELV" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtCuttingDeliveyQty" runat="server" Text='<%#Eval("CUTTING_DELIVERY_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="S.INPUT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtSewingInputQty" runat="server" Text='<%#Eval("SEWING_INPUT_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="S.OUT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtSewingOutputQty" runat="server" Text='<%#Eval("SEWING_OUTPUT_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="W.SENT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtWashSentQty" runat="server" Text='<%#Eval("WASH_SEND_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="W.RECVD" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtWashReceivedQty" runat="server" Text='<%#Eval("WASH_RECEIVED_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="F.POLY" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtFinishingPolyQty" runat="server" Text='<%#Eval("FINISHING_POLY_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CARTON" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtFinishingCartonQty" runat="server" Text='<%#Eval("FINISHING_CARTON_QUANTITY")%> '
                                                                        Font-Bold="true" Width="60" AutoPostBack="true" OnTextChanged="txtFinishingCartonQty_TextChanged"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtTranId" runat="server" Text='<%#Eval("TRAN_ID")%> ' Width="20"
                                                                        DataField="TRAN_ID" ReadOnly="true" SortExpression="TRAN_ID"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                              <asp:TemplateField HeaderText="BUYER" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtBuyerShortName" runat="server" Text='<%#Eval("BUYER_NAME")%> ' Width="1"
                                                                        DataField="BUYER_NAME" BackColor="Yellow" ReadOnly="true" SortExpression="BUYER_NAME"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                            <%--<asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" OnClientClick="return isDelete();">Delete
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
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
                                <td style="text-align: center" colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="3"></td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
                <td style="text-align: right">&nbsp;</td>
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
                var cnt = document.getElementById('<%=gvDailyProduction.ClientID%>').rows[0].cells.length + 1;
                var i = 0;
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

            //$("[id *= txtUnitRate]").bind("change", Deductions);
            //$("[id *= txtQuantity]").bind("change", Deductions);
        });

        function Deductions() {
            if (!jQuery.trim($(this).val()) == '') {
                if (!isNaN(parseFloat($(this).val()))) {
                    var row = $(this).closest("tr");

                    var result = new Object();
                    var resultNew = new Object();

                    //result.UnitRate = $("[id *= txtUnitRate]", row).val();
                    //result.Quantity = $("[id *= txtQuantity]", row).val();

                    //result.Amount = result.UnitRate * result.Quantity;
                    //$("[id *= txtAmount]", row).val(result.Amount);
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
