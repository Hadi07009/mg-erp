<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="MonthlyStore.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MonthlyStore" %>

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
   <%-- <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtBeginingStock.ClientID %>").focus(); }) 
    </script>--%>
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
   <%-- <script type="text/javascript">
        function Addition() {

            var text1 = document.getElementById('<%= txtOpeningBlance.ClientID %>');
            var text2 = document.getElementById('<%= txtReceivedBlance.ClientID %>');
            if (text1.value.length == 0 || text2.value.length == 0) {
                alert('Opening Stock and New Received should not be empty');
                return;
            }

            var x = parseInt(text1.value);
            var y = parseInt(text2.value);
            document.getElementById('<%= txtTotalBlance.ClientID %>').value = x + y;

        }
    </script>--%>
   <%-- <script type="text/javascript">
        function Subtraction() {

            var text1 = document.getElementById('<%= txtTotalBlance.ClientID %>');
            var text2 = document.getElementById('<%= txtIssuedQuantity.ClientID %>');
            if (text1.value.length == 0 || text2.value.length == 0) {
                alert('Stock After Addition and Issued Quantity should not be empty');
                return;
            }

            var x = parseInt(text1.value);
            var y = parseInt(text2.value);
            document.getElementById('<%= txtClosingBlance.ClientID %>').value = x - y;

        }
    </script>--%>
   <%-- <script language="javascript" type="text/javascript">

        function sumCalc() {
            var _txt1 = document.getElementById('<%= txtTotalBlance.ClientID %>');
            var _txt2 = document.getElementById('<%= txtIssuedQuantity.ClientID %>');
            var _txt3 = document.getElementById('<%= txtClosingBlance.ClientID %>');
            var t1 = 0, t2 = 0;

            if (_txt1.value != "") t1 = _txt1.value;
            if (_txt2.value != "") t2 = _txt2.value;

            _txt3.value = parseInt(t1) - parseInt(t2);
        }
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
        <legend>MONTHLY STORE INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px;">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td style="width: 294px">
                    <asp:TextBox ID="txtTranId" runat="server" Width="53px" BackColor="Yellow" Height="20px"
                        Font-Bold="True"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px;">
                    <asp:Label ID="lblId0" runat="server" Text="Year / Month :"></asp:Label>
                </td>
                <td style="width: 294px">
                    <asp:TextBox ID="txtYear" runat="server" Width="75px"
                        BackColor="Yellow"></asp:TextBox>
                    <asp:TextBox ID="txtMonth" runat="server" Width="40px"
                        BackColor="Yellow"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px;">
                    <asp:Label ID="lblId1" runat="server" Text="Part No :"></asp:Label>
                </td>
                <td style="width: 294px">
                    <asp:TextBox ID="txtPartNo" runat="server" Width="120px" BackColor="White" 
                        MaxLength="300" Font-Size="Small" Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px;">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Begining Stock :"></asp:Label>
                </td>
                <td style="width: 294px">
                    <asp:TextBox ID="txtBeginingStock" runat="server" Width="120px" BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px;">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Opening Stock :"></asp:Label>
                </td>
                <td style="width: 294px">
                    <asp:TextBox ID="txtOpeningStock" runat="server" Width="120px" 
                        BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;  height: 19px; width: 341px;">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="Closing Blance :"></asp:Label>
                </td>
                <td style="height: 19px; width: 294px;">
                    <asp:TextBox ID="txtClosingBlance" runat="server" Width="120px" BackColor="Yellow"
                        onkeydown="javascript:TextName_OnKeyDown(event)" MaxLength="300" Font-Size="Small"
                         style="margin-left: 30" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtSL" runat="server" Width="20px" BackColor="Yellow"
                        MaxLength="300" onblur="Addition()" Font-Size="Small" Font-Bold="True" 
                        Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtSLNew" runat="server" Width="20px" BackColor="Yellow"
                        MaxLength="300" onblur="Addition()" Font-Size="Small" Font-Bold="True" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;  height: 19px; width: 341px;">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 294px;">
                    &nbsp;
                    </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: center; height: 19px" colspan="3">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="66px"
                        CssClass="styled-button-4" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px" CssClass="styled-button-4"
                        OnClick="btnNext_Click" />
                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"
                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" CssClass="styled-button-4"
                        OnClick="btnShow_Click" />
                    <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="66px" CssClass="styled-button-4"
                        OnClick="btnView_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <fieldset>
                        <legend>SEARCH CRITERIA</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right; width: 334px;" class="style4">
                                    <asp:Label ID="lblProductCataroy3" runat="server" Text=" Equipement :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="width: 163px; height: 22px;">
                                    <asp:DropDownList ID="ddlEquipementId" runat="server" Width="160px" Height="22px"
                                        BackColor="#CCCCCC" AutoPostBack="true" OnSelectedIndexChanged="ddlEquipementId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 22px; width: 66px;">
                                    <asp:Button ID="btnSearchSparePart" runat="server" Height="25px" Text="Search" Width="55px"
                                        CssClass="styled-button-4" OnClick="btnSearchSparePart_Click" />
                                    &nbsp;
                                </td>
                                <td style="height: 22px; text-align: right; width: 69px;">
                                    <asp:Label ID="Label34" runat="server" Text="Part No :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="txtPartNoSrc" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 334px;" class="style4">
                                    <asp:Label ID="Label35" runat="server" Text="Part Name :"></asp:Label>
                                </td>
                                <td style="width: 163px; height: 22px;">
                                    <asp:DropDownList ID="ddlSparePartId" runat="server" Width="160px" Height="22px"
                                        BackColor="#CCCCCC">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 22px; width: 66px;">
                                    &nbsp;
                                </td>
                                <td style="height: 22px; text-align: right; width: 69px;">
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
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" 
                        OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="TRAN_ID" HeaderText="ID"  />
                            <asp:BoundField DataField="EQUIPEMENT_NAME" HeaderText="EQUI.NAME"/>
                            <asp:BoundField DataField="SPARE_PART_NAME" HeaderText="S.PART.NAME" />
                            <asp:BoundField DataField="TRAN_YEAR" HeaderText="YEAR" />
                            <asp:BoundField DataField="TRAN_MONTH" HeaderText="MONTH" />
                            <asp:BoundField DataField="PART_NO" HeaderText="PART NO" />
                            <asp:BoundField DataField="BEGINING_STOCK" HeaderText="BEGINING STOCK" />
                            <asp:BoundField DataField="OPENING_STOCK" HeaderText="OPENING STOCK" />
                            <asp:BoundField DataField="CLOSING_BLANCE" HeaderText="C.BLANCE"/>                            
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px">
                    &nbsp;
                </td>
                <td style="width: 294px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging"
        OnRowDataBound="GridView1_OnRowDataBound" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="SPARE_PART_CATEGORY_ID" HeaderText="ID"/>
            <asp:BoundField DataField="SPARE_PART_NAME" HeaderText="PART NAME" />
            <asp:BoundField DataField="SPARE_PART_CATEGORY_NAME" HeaderText="CATEGORY NAME" />
            <asp:BoundField DataField="SPARE_PART_CATEGORY_NO" HeaderText="PART NO"/>
            <asp:BoundField DataField="QUANTITY_PER_ENGINEE" HeaderText="QTY/ENGINE" />
            <asp:BoundField DataField="FILE_NAME" HeaderText="PARTS CATALOG" />
            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
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
