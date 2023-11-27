<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ArrearProcess.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ArrearProcess" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <legend>ARREAR PROCESS</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 917px;">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
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
                    <table class="style1">
                        <tr>
                            <td style="text-align: right">
                                <fieldset>
                                    <legend>ARREAR ENTRY</legend>
                                    <table class="style1">
                                        <tr>
                                            <td style="width: 244px; text-align: right">
                                                <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                                <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                                <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                                <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                            </td>
                                            <td style="width: 74px; text-align: right;">
                                                <asp:Label ID="Label19" runat="server" Text="Year :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtYear" runat="server" Width="156px" Height="20px"
                                                    Font-Bold="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 244px; text-align: right">
                                                <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                                <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                            </td>
                                            <td style="width: 74px; text-align: right;">
                                                <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                                    BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 244px; text-align: right; height: 22px;">
                                                <asp:Label ID="Label27" runat="server" Text="Advance deduction :"></asp:Label>
                                            </td>
                                            <td style="width: 292px; text-align: left; height: 22px;">
                                                <asp:TextBox ID="txtAdvanceFee" runat="server" Width="142px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                                    Font-Bold="True"></asp:TextBox>
                                                <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                                    ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                            </td>
                                            <td style="width: 74px; text-align: right; height: 22px;">&nbsp;
                                            </td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtMonth" runat="server" Width="31px" Height="20px" BackColor="White"
                                                    ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 244px; text-align: right">
                                                <asp:Label ID="lblProductCataroy" runat="server" Text="From Month :"></asp:Label>
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                                <asp:DropDownList ID="ddlFromMonthId" runat="server" Width="144px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 74px; text-align: right;">&nbsp;
                                            </td>
                                            <td>
                                               

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 244px; text-align: right">
                                                <asp:Label ID="lblProductCataroy1" runat="server" Text="To Month :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                                <asp:DropDownList ID="ddlToMonthId" runat="server" Width="144px" Height="22px">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                            <td style="width: 74px; text-align: right;">&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 244px; text-align: right">
                                                <asp:Label ID="lblProductCataroy2" runat="server" Text="Without Arrear :"></asp:Label>
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                                <asp:CheckBox ID="chkYes" runat="server" Text="YES" Checked="true" />
                                            </td>
                                            <td style="width: 74px; text-align: right;">&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 244px; text-align: right">&nbsp;</td>
                                            <td style="width: 292px; text-align: left;">&nbsp;</td>
                                            <td style="width: 74px; text-align: right;">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center" colspan="4">
                                                <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="55px" OnClick="btnSave_Click"
                                                    CssClass="styled-button-4" />
                                                <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="55px" OnClick="btnNext_Click"
                                                    CssClass="styled-button-4" />
                                                <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="55px"
                                                    CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                                <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="55px" OnClick="btnShow_Click"
                                                    CssClass="styled-button-4" />
                                                <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process" Width="60px"
                                                    CssClass="styled-button-4" OnClick="btnProcess_Click" />
                                                <asp:Button ID="btnArrearSheet" runat="server" Height="31px" Text="Sheet" CssClass="styled-button-4"
                                                    Width="55px" OnClick="btnArrearSheet_Click" />
                                                <asp:Button ID="btnSummerySheet" runat="server" Height="31px" Text="Summery" CssClass="styled-button-4"
                                                    Width="65px" OnClick="btnSummerySheet_Click" />
                                                <asp:Button ID="btnArrearSlip" runat="server" Height="31px" Text="Slip" CssClass="styled-button-4"
                                                    Width="55px" OnClick="btnArrearSlip_Click" />
                                                <asp:Button ID="btnArrearRequisition" runat="server" Height="31px" Text="Requisition"
                                                    CssClass="styled-button-4" Width="75px" OnClick="btnArrearRequisition_Click" />
                                                <asp:Button ID="btnBank" runat="server" Height="31px" Text="Bank" CssClass="styled-button-4"
                                                    Width="50px" OnClick="btnBank_Click" />
                                                <asp:Button ID="btnCash" runat="server" Height="31px" Text="Cash" CssClass="styled-button-4"
                                                    Width="50px" OnClick="btnCash_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right" colspan="4">
                                                <fieldset>
                                                    <legend>SEARCH CRITERIA</legend>
                                                    <table class="style1">
                                                        <tr>
                                                            <td style="width: 238px; text-align: right; height: 22px;">
                                                                <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 159px; height: 22px;">
                                                                <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="height: 22px; width: 61px;">
                                                                <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                                    CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                            </td>
                                                            <td style="height: 22px; width: 77px; text-align: right;">
                                                                <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                            </td>
                                                            <td style="height: 22px">
                                                                <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 238px; text-align: right">
                                                                <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                                &nbsp;
                                                            </td>
                                                            <td style="width: 159px">
                                                                <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td style="width: 61px">&nbsp;
                                                            </td>
                                                            <td style="width: 77px; text-align: right">
                                                                <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 238px; text-align: right">&nbsp;</td>
                                                            <td style="width: 159px">&nbsp;</td>
                                                            <td style="width: 61px">&nbsp;</td>
                                                            <td style="width: 77px; text-align: right">&nbsp;</td>
                                                            <td>&nbsp;</td>
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
                            <td>
                                <fieldset>
                                    <legend>ARREAR ENTRY RESULT WORKER</legend>
                                    <table style="width: 100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                    OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                    GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                                    PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                                    OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                                                    <Columns>
                                                        <asp:BoundField DataField="SL" HeaderText="SL" />
                                                        <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />


                                                        <asp:BoundField DataField="advance_fee" HeaderText="ADVANCE" />




                                                        <asp:BoundField DataField="from_month_name" HeaderText="FROM MONTH" />
                                                        <asp:BoundField DataField="to_month_name" HeaderText="TO MONTH" />




                                                        <asp:BoundField DataField="STATUS" HeaderText="STATUS" />
                                                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                                        <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                                    Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"
                                                                    AlternateText="Select" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <%-- </div>--%>
                                </fieldset>
                            </td>
                        </tr>
                    </table>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <%-- </div>--%>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        OnRowCommand="gvEmployeeList_RowCommand" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"
                                        AlternateText="Select" />
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
