<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="PurchaseOrderEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PurchaseOrderEntry" %>

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
        $(window).load(function () { document.getElementById("<%= txtPONo.ClientID %>").focus(); }) 
    </script>
    <script type="text/javascript">
        function doClick(buttonName, e) {
            //the purpose of this function is to allow the enter key to 
            //point to the correct button to click.
            var key;

            if (window.event)
                key = window.event.keyCode;     //IE
            else
                key = e.which;     //firefox

            if (key == 13) {
                //Get the button the user wants to have clicked
                var btn = document.getElementById(buttonName);
                if (btn != null) { //If we find the button click it
                    btn.click();
                    event.keyCode = 0
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
        <legend>PUCHASE CONTACT SHEET INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>PUCHASE CONTACT ENTRY</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    <asp:Label ID="lblPONo" runat="server" Text="PO No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPONo" runat="server" Width="139px" BackColor="White" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblPODate" runat="server" Text="Style No :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtStyleNo" runat="server" Width="139px" MaxLength="300" BackColor="White"
                                        Font-Size="Small"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblProductCataroy9" runat="server" Text="Delivery Date :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="dtpDeliveryDate" runat="server" Width="139px" BackColor="White"
                                        CssClass="date" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblPODate0" runat="server" Text="Quantity :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtQuantity" runat="server" Width="70px" BackColor="White" Font-Bold="True"></asp:TextBox>
                                    <asp:DropDownList ID="ddlSizeIdForQuantity" runat="server" Width="66px" Height="20px"
                                        AutoPostBack="false">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblPODate1" runat="server" Text="Price :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtPrice" runat="server" Width="70px" BackColor="White" Font-Bold="True"></asp:TextBox>
                                    <asp:DropDownList ID="ddlSizeIdForPOPrice" runat="server" Width="66px" Height="20px"
                                        AutoPostBack="false">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblPODate2" runat="server" Text="Hanger Cost Price : "></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtHangerCostPrice" runat="server" Width="139px" BackColor="White"
                                        Font-Bold="True" Height="20px"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblPODate3" runat="server" Text="Unit Cost/Total Amount :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtUnitCost" runat="server" Width="66px" BackColor="Yellow" Font-Bold="True"
                                        ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtTotalAmount" runat="server" Width="66px" BackColor="Yellow" Font-Bold="True"
                                        ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtPercentAmount" runat="server" Width="31px" BackColor="White"
                                        Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblProductCataroy7" runat="server" Text="Item Description :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlItemDescriptionId" runat="server" Width="142px" Height="20px"
                                        AutoPostBack="false">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblProductCataroy8" runat="server" Text="Shiping Address :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlShipingAddressId" runat="server" Width="142px" Height="20px"
                                        AutoPostBack="false">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;" colspan="3">
                                    <asp:Button ID="btnCalculate" runat="server" Height="31px" Text="Calculate" Width="70px"
                                        CssClass="styled-button-4" OnClick="btnCalculate_Click" />
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="70px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="70px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="70px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left;" colspan="3">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <fieldset>
                        <legend>SEARCH CRITERIA</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 206px; text-align: right">
                                    <asp:Label ID="lblProductCataroy" runat="server" Text="PO No :"></asp:Label>
                                </td>
                                <td style="width: 198px">
                                    <asp:TextBox ID="txtPO" runat="server" BackColor="White" Width="149px" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right">
                                    &nbsp;
                                    <asp:Label ID="Label1" runat="server" Text="From Date :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="dtpPOFromDate" runat="server" BackColor="White" Width="149px" CssClass="date"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 206px; text-align: right; height: 13px;">
                                    <asp:Label ID="lblStyle" runat="server" Text="Style :"></asp:Label>
                                </td>
                                <td style="width: 198px; height: 13px;">
                                    <asp:DropDownList ID="ddlStyle" runat="server" Width="153px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right; height: 13px;">
                                    <asp:Label ID="Label22" runat="server" Text="To Date :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="height: 13px">
                                    <asp:TextBox ID="dtpPOToDate" runat="server" BackColor="White" Width="149px" CssClass="date"></asp:TextBox>
                                </td>
                                <td style="height: 13px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 206px; text-align: right; height: 22px;">
                                    &nbsp;
                                </td>
                                <td style="width: 198px; height: 22px;">
                                    <asp:Button ID="Button1" runat="server" Height="31px" Text="Search" Width="87px"
                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                </td>
                                <td style="height: 22px; text-align: right;">
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>PO ENTRY RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="PO_NO" HeaderText="PO" />
                            <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE" />
                            <asp:BoundField DataField="DELIVERY_DATE" HeaderText="DATE" />
                            <asp:BoundField DataField="ORDER_QUANTITY" HeaderText="QTY" />
                            <asp:BoundField DataField="size_name" HeaderText="SIZE" />
                            <asp:BoundField DataField="PO_PRICE" HeaderText="PO PRICE" />
                            <asp:BoundField DataField="HANGER_COST_PRICE" HeaderText="HC PRICE" />
                            <asp:BoundField DataField="UNIT_COST" HeaderText="UNIT COST" />
                            <asp:BoundField DataField="TOTAL_AMOUNT" HeaderText="AMT" />
                            <asp:BoundField DataField="SHIPING_ADDRESS" HeaderText="SHIPING ADDRESS" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvUnit_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowEditing="gvUnit_RowEditing"
                        BorderStyle="Solid">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="PO_NO" HeaderText="PO NO" />
                            <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE NO" />
                            <asp:BoundField DataField="COLOR_ID" HeaderText="COLOR" />
                            <asp:BoundField DataField="UNIT_RATE" HeaderText="RATE" />
                            <asp:BoundField DataField="QUANTITY" HeaderText="QTANTITY" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
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
