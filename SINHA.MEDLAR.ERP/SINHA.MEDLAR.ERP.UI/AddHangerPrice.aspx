<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="False" CodeBehind="AddHangerPrice.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddHangerPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<script type="text/javascript">
        $(document).ready(function () {

            $(".vertical").keypress(function (event) {
                if (event.keyCode == 13) {
                    textboxes = $("input.vertical");
                    debugger;
                    currentBoxNumber = textboxes.index(this);

                    if (textboxes[currentBoxNumber + 1] != null) {
                        nextBox = textboxes[currentBoxNumber + 1]
                        nextBox.focus();
                        nextBox.select();
                        event.preventDefault();
                        return false
                    }
                }
            });
        })

    </script>--%>
    <%--<script type="text/javascript">
    $('input,select').on('keypress', function (e) {
        if (e.which == 13) {
            e.preventDefault();
            var $next = $('[tabIndex=' + (+this.tabIndex + 1) + ']');
            console.log($next.length);
            if (!$next.length) {
                $next = $('[tabIndex=1]');
                document.getElementById('Gridview1_ButtonAdd').click();
            }
            $next.focus();


        }
    });
</script>--%>
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtSize.ClientID %>").focus(); }) 
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
        <legend>ADD HANGER PRICE LIST</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 22px;">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtHangerId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td style="height: 22px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Supplier Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 22px;">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Style :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:DropDownList ID="ddlStyleId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Color :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlColorId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblCurrencyId" runat="server" Text="Currency :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCurrencyId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Size :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSize" runat="server" Width="90px" BackColor="White" Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy3" runat="server" Text="Rate :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtRate" runat="server" Width="90px" BackColor="White" Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="Particular :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtParticular" runat="server" Width="210px" BackColor="White" Font-Bold="True"
                        onkeydown="javascript:TextName_OnKeyDown(event)" Height="20px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px" colspan="3">
                    <div>
                        <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <td style="text-align: right; height: 19px" colspan="3">
            <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                <Columns>
                    <asp:BoundField DataField="HANGER_ID" HeaderText="ID" />
                    <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />
                    <asp:BoundField DataField="STYLE_NAME" HeaderText="STYLE" />
                    <asp:BoundField DataField="COLOR_NAME" HeaderText="COLOR" />
                    <asp:BoundField DataField="CURRENCY_NAME" HeaderText="CURRENCY" />
                    <asp:BoundField DataField="HANGER_SIZE" HeaderText="SIZE" />
                    <asp:BoundField DataField="HANGER_RATE" HeaderText="RATE" />
                      <asp:BoundField DataField="PARTICULAR_NAME" HeaderText="PARTICULAR" />
                </Columns>
            </asp:GridView>
        </td>
    </fieldset>
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
