<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AdvanceEntryCopy.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AdvanceEntryCopy" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .ButtonClass
        {
            border: 1px solid #900;
            cursor: pointer;
        }
        .auto-style1 {
            width: 920px;
        }
        .auto-style3 {
            height: 22px;
            width: 320px;
        }
        .auto-style4 {
            height: 15px;
            width: 320px;
        }
        .auto-style5 {
            width: 319px;
        }
        .auto-style7 {
            height: 22px;
        }
        .auto-style8 {
            width: 320px;
        }
    </style>
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true
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
        function isDelete() {
            return confirm("Do you want to delete this Record ?");

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
        $(window).load(function () { document.getElementById("<%= txtAdvanceFee.ClientID %>").focus(); }) 
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
        <legend>ADVANCE INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; " class="auto-style1">
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
                        <legend>ADVANCE ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right" class="auto-style8">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style8">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label47" runat="server" Text="R.B :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtLoanAmount" runat="server" Width="156px" Height="20px" Font-Bold="True"
                                        BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style8">
                                    <asp:Label ID="Label27" runat="server" Text="Advance Amount :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtAdvanceFee" runat="server" Width="130px" Height="20px" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; " class="auto-style3">
                                    <asp:Label ID="Label46" runat="server" Text="Deduct Amount :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style7">
                                    <asp:TextBox ID="txtAdvanceDeductFee" runat="server" Width="130px" Height="20px"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right; " class="auto-style7">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; " class="auto-style3">
                                    <asp:Label ID="Label48" runat="server" Text="Ledger Page No :"></asp:Label>
                                </td>
                                <td style="text-align: left; " class="auto-style7">
                                    <asp:TextBox ID="txtLedgerPageNo" runat="server" Width="130px" Height="20px" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right; " class="auto-style7">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style8">
                                    <asp:Label ID="Label43" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtYear" runat="server" Width="55px" Height="20px" Font-Bold="True"
                                        BackColor="Yellow"></asp:TextBox>
                                    <asp:DropDownList ID="ddlMonthId" runat="server" Width="70px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style8">
                                    <asp:Label ID="Label45" runat="server" Text="Deduct Y/N :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chkDecutYN" runat="server" Text="YES" />
                                </td>
                                <td style="text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; " class="auto-style4">
                                    &nbsp;
                                </td>
                                <td style="text-align: left; " class="style3">
                                    &nbsp;
                                </td>
                                <td style="text-align: right; " class="style3">
                                    &nbsp;
                                </td>
                                <td style="height: 15px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 15px;" colspan="4">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" CssClass="styled-button-4"
                                        OnClientClick="return isDelete();" Width="66px" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btnAdvanceSheet" runat="server" Height="31px" Text="Sheet" CssClass="styled-button-4"
                                        Width="66px" OnClick="btnAdvanceSheet_Click" />
                                    <asp:Button ID="btnAdvanceEntrySheet" runat="server" Height="31px" Text="Entry Sheet"
                                        CssClass="styled-button-4" Width="80px" OnClick="btnAdvanceEntrySheet_Click" />
                                    <asp:Button ID="btnLedger" runat="server" Height="31px" Text="Ledger" CssClass="styled-button-4"
                                        Width="66px" OnClick="btnLedger_Click" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="text-align: right" class="auto-style5">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 64px">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 79px">
                                                    <asp:Label ID="Label39" runat="server" Text="Employee ID :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" class="auto-style5">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 64px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 79px">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" class="auto-style5">
                                                    &nbsp;</td>
                                                <td style="width: 163px">
                                                    &nbsp;</td>
                                                <td style="width: 64px">
                                                    &nbsp;</td>
                                                <td style="text-align: right; width: 79px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
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
                    <tr>
                        <td style="text-align: right" colspan="2">
                            <fieldset>
                                <legend>TAX ENTRY RESULT </legend>
                                <table style="width: 100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                CausesValidation="False" DataKeyNames="EMPLOYEE_ID" OnRowDataBound="GridView1_OnRowDataBound"
                                                AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                                OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                                OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting"
                                                OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="SL" HeaderText="SL" />
                                                    <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                                    <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                    <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                                    <asp:BoundField DataField="ADVANCE_FEE" HeaderText="TOTAL ADVANCE" />
                                                    <asp:BoundField DataField="ADVANCE_DEDUCT_FEE" HeaderText="DEDUCT FEE" />
                                                    <asp:BoundField DataField="LEDGER_PAGE_NO" HeaderText="PAGE NO" />
                                                    <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                                    <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                                Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--  <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="ButtonClass" CausesValidation="False"/>--%>
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
                                </table>
                            </fieldset>
                        </td>
                    </tr>
        </table>
    </fieldset>
    </tr> </table> </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" OnSorting="gvEmployeeList_Sorting" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowCommand="gvEmployeeList_RowCommand" OnRowEditing="gvEmployeeList_OnRowEditing"
                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="gvEmployeeList_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
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
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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
