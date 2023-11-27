<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="LayChart.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.LayChart" %>

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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtSRNo.ClientID %>").focus(); }) 
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
        <legend>LAY CHART INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 601px;">
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
                        <legend>LAY CHART ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 385px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="PO No :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtPoNo" runat="server" Width="158px" Height="20px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black"></asp:TextBox>
                                    <asp:Button ID="btnSearchPO" runat="server" Height="22px" Text="..." Width="30px"
                                        CssClass="styled-button-4" OnClick="btnSearchPO_Click" />
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    <asp:Label ID="Label19" runat="server" Text="Buyer :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtBuyerName" runat="server" Width="200px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 385px; text-align: right">
                                    <asp:Label ID="Label27" runat="server" Text="Order/Size :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtTotalOrderQuantity" runat="server" Width="70px" Height="20px"
                                        Font-Bold="True" ForeColor="Red" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSize" runat="server" Width="82px" Height="20px" Font-Bold="True"
                                        ForeColor="Red" BackColor="Yellow"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    <asp:Label ID="Label45" runat="server" Text="Style :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtStyleNo" runat="server" Width="200px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 385px; text-align: right">
                                    <asp:Label ID="Label50" runat="server" Text="SR No :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtSRNo" runat="server" Width="158px" Height="20px" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    <asp:Label ID="Label32" runat="server" Text="Color :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtColorName" runat="server" Width="200px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 385px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label44" runat="server" Text="Cutting Date :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="dtpCuttingDate" runat="server" Width="158px" Height="20px" CssClass="date"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right; height: 22px;">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 385px; text-align: right">
                                    <asp:Label ID="Label46" runat="server" Text="Measurement W/L : "></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtMeasurementWidth" runat="server" Width="75px" Height="20px" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtMeasurementLength" runat="server" Width="78px" Height="20px"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 385px; text-align: right">
                                    <asp:Label ID="Label49" runat="server" Text="Line :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlLineId" runat="server" Width="160px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 385px; text-align: right">
                                    <asp:Label ID="Label47" runat="server" Text="Cutting No :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtCuttingNo" runat="server" Width="158px" Height="20px" Font-Bold="True"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>FABRIC ACCEPTANCE ENTRY RESULT </legend>
                                        <table style="width: 100%">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:GridView ID="gvFabricDetails" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                        OnRowDataBound="gvFabricDetails_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                        GridLines="None" AllowPaging="false" OnRowEditing="gvFabricDetails_OnRowEditing"
                                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvFabricDetails_OnSelectedIndexChanged"
                                                        CausesValidation="false" OnRowCommand="gvFabricDetails_RowCommand" AlternatingRowStyle-CssClass="alt"
                                                        OnPageIndexChanging="gvFabricDetails_OnSelectedIndexChanged">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="ROLL NO" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRollNo" runat="server" Width="80" Text='<%#Eval("ROLL_NO")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="LENGTH" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtLength" runat="server" Width="80" Text='<%#Eval("LENGTH_WISE_SHRINKAGE")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="WIDTH" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtWidth" runat="server" Width="80" Text='<%#Eval("WIDTH_WISE_SHRINKAGE")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SHADE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtShade" runat="server" Width="80" Text='<%#Eval("SHADE")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="LAYOUT" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtLayOut" runat="server" Width="80" Text='<%#Eval("LAY_OUT")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="STICKER" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtStickerNo" runat="server" Width="80" Text='<%#Eval("STICKER_NO")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="YDS/MTR" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtYards" runat="server" Width="80" Text='<%#Eval("YDS_PER_METER")%>'></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="FABRIC USE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtFabricUse" runat="server" Width="80" Text='<%#Eval("FABRIC_USE")%>'></asp:TextBox>
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
                                <td style="text-align: center; height: 33px;" colspan="4">
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear " Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnAddRow" runat="server" Height="31px" Text="Add Row" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAddRow_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSheet_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 118px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="PO No :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:TextBox ID="txtPoSearchNo" runat="server" Width="149px" BackColor="White" CssClass="date"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="From :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="149px" BackColor="White" CssClass="date"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 118px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="SR No :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="txtSRSearchNo" runat="server" Width="149px" BackColor="White" CssClass="date"></asp:TextBox>
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label40" runat="server" Text="To :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="dtpToDate" runat="server" Width="149px" BackColor="White" CssClass="date"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
            </tr>
            <tr>
                <td colspan="2">
                    <%-- <fieldset>
                        <legend>LAY CHART ENTRY RESULT </legend>
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
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="PO_NO" HeaderText="PO" />
                                            <asp:BoundField DataField="PO_SIZE" HeaderText="SIZE" />
                                            <asp:BoundField DataField="ORDER_QUANTITY" HeaderText="QTY" ItemStyle-Width="10px" />
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
                    </fieldset>--%>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table class="style1">
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
