<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="HalfSalaryWorker.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.HalfSalaryWorker" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        $(window).load(function () { document.getElementById("<%= txtWorkingDay.ClientID %>").focus(); });
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
                <%--document.getElementById('<%= btnSave.ClientID %>').click();--%>
                e.preventDefault();
                $('#<%=btnSave.ClientID%>').click();
            }
        }

        //function TextName_OnKeyDown(event) {
        //    if (event.which == 13) {
        //        $('#ContentPlaceHolder2_btnSave').trigger('click');
        //    }
        //}

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
        <legend>WORKER HALF SALARY INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 919px;">
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
                        <legend>HALF SALARY ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 327px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 274px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 72px;">
                                    <asp:Label ID="Label19" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSalaryYear" runat="server" Width="105px" Height="20px" Font-Bold="True"
                                        MaxLength="4" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtsalaryMonth" runat="server" Width="43px" Height="20px" Font-Bold="True"
                                        MaxLength="2" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 327px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 274px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 72px;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 327px; text-align: right">
                                    <asp:Label ID="Label27" runat="server" Text="Working Day :"></asp:Label>
                                </td>
                                <td style="width: 274px; text-align: left;">
                                    <asp:TextBox ID="txtWorkingDay" runat="server" Width="74px" Height="20px" 
                                       onkeydown="javascript:TextName_OnKeyDown(event)" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtOverTimeHour" runat="server" Width="70px" Height="20px" defaultfocus="txtOverTimeHour"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 72px;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 327px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Advance Salary :"></asp:Label>
                                </td>
                                <td style="width: 274px; text-align: left;">
                                    <asp:TextBox ID="txtAdvanceFee" runat="server" Width="70px" Height="20px" Font-Bold="True"
                                        ForeColor="Red" onkeydown="javascript:TextName_OnKeyDown(event)" BackColor="Yellow"
                                        ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtOverTimeAmount" runat="server" Width="70px" Height="20px" Font-Bold="True"
                                        ForeColor="Red" onkeydown="javascript:TextName_OnKeyDown(event)" BackColor="Yellow"
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 72px;">
                                    <asp:HiddenField ID="hf_grid_id" runat="server" />
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; width: 327px;">
                                    &nbsp;
                                </td>
                                <td style="width: 274px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="text-align: right; width: 72px;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnSalaryProcess" runat="server" Height="31px" Text="Process" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSalaryProcess_Click" />
                                    <asp:Button ID="btnHalfSheet" runat="server" Height="31px" Text="Master Sheet" CssClass="styled-button-4"
                                        Width="100px" OnClick="btnHalfSheet_Click" />
                                     <asp:Button ID="btnParcialSalaryBkashSheet" runat="server" Height="31px" Text="Bkash Sheet" CssClass="styled-button-4"
                                        Width="90px" OnClick="btnParcialSalaryBkashSheet_Click" />
                                    <asp:Button ID="btnParcialSalaryCashSheet" runat="server" Height="31px" Text="Cash Sheet" CssClass="styled-button-4"
                                        Width="80px" OnClick="btnParcialSalaryCashSheet_Click" />
                                    <asp:Button ID="BtnMasterRequisition" runat="server" Height="31px" Text="Master Req"
                                        CssClass="styled-button-4" Width="80px" OnClick="BtnMasterRequisition_Click" />
                                    <asp:Button ID="btnParcialSalaryBkashReq" runat="server" Height="31px" Text="BKash Req" CssClass="styled-button-4"
                                        Width="80px" OnClick="btnParcialSalaryBkashReq_Click" />
                                    <asp:Button ID="btnParcialSalaryCashReq" runat="server" Height="31px" Text="Cash Req" CssClass="styled-button-4"
                                        Width="80px" OnClick="btnParcialSalaryCashReq_Click" />
                                    <asp:Button ID="btnRequisitionSummaryBkash" runat="server" Height="31px" Text="BKash Summary" Width="110px"
                                        CssClass="styled-button-4" OnClick="btnRequisitionSummaryBKash_Click" />
                                    <asp:Button ID="btnRequisitionSummaryCash" runat="server" Height="31px" Text="Cash Summary" Width="110px"
                                        CssClass="styled-button-4" OnClick="btnRequisitionSummaryCash_Click" />
                                    <asp:Button ID="btnHalfSalaryRequisition" runat="server" Height="31px" Text="Requisition(All)"
                                        CssClass="styled-button-4" Width="100px" OnClick="btnHalfSalaryRequisition_Click" />

                                    <asp:Button ID="btnGetHalfSalarySummary" runat="server" Height="31px" Text="Summary(All)"
                                        CssClass="styled-button-4" Width="100px" OnClick="btnGetHalfSalarySummary_Click" />

                                    <asp:Button ID="btnBKashTemplate" runat="server" CssClass="styled-button-4" Height="31px" OnClick="btnBKashTemplate_Click" Text="BKash Template" Width="120px" />
                                    <asp:Button ID="btnBKashTemplateAll" runat="server" CssClass="styled-button-4" Height="31px" OnClick="btnBKashTemplateAll_Click" Text="BKash Template(All)" Width="135px" />


                                    <asp:Button ID="btnDformReq" runat="server" Height="31px" Text="D Req" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnDformReq_Click" />
                                    <asp:Button ID="btnNonDformReq" runat="server" Height="31px" Text="NON-D Req" Width="90px"
                                        CssClass="styled-button-4" OnClick="btnNonDformReq_Click" />
                                     <asp:Button ID="btnDformWallet" runat="server" Height="31px" Text="Template(D)" Width="90px"
                                        CssClass="styled-button-4" OnClick="btnDformWallet_Click" />
                                     <asp:Button ID="btnNonDformWallet" runat="server" Height="31px" Text="Template(NON-D)" Width="120px"
                                        CssClass="styled-button-4" OnClick="btnNonDformWallet_Click" />

                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add" Width="66px" OnClick="btnAdd_Click"
                                        CssClass="styled-button-4" />

                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 321px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label1" runat="server" Text="Unit Group :"></asp:Label>
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitGroupId" runat="server" Width="240px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Unit Group- 1"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Unit Group- 2"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Unit Group- 3"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Unit Group- 4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    &nbsp;</td>
                                                <td style="height: 22px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 321px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    &nbsp;</td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="Employee ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 321px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
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
                    <fieldset>
                        <legend>HALF SALARY ENTRY RESULT WORKER</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False" 
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns >

                                            <asp:BoundField DataField="SL" HeaderText="SL"  />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="WORKING_DAY" HeaderText="DAY" />
                                             <asp:BoundField DataField="OVER_TIME_HOUR" HeaderText="OT HOUR" />
                                            <asp:BoundField DataField="OVER_TIME_AMOUNT" HeaderText="OT AMOUNT" />

                                            <asp:BoundField DataField="PAYMENT_AMOUNT" HeaderText="AMOUNT" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
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
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" ClientSelectionMode="SingleRow" GridLines="None"
                        AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing"
                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        CausesValidation="false" OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeId" Text='<%#Eval("EMPLOYEE_ID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
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
