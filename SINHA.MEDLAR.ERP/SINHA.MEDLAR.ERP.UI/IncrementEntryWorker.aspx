<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="IncrementEntryWorker.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.IncrementEntryWorker" %>

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

    </script><script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script><script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtManuaIncrement.ClientID %>").focus(); }) 
    </script><script type="text/javascript">
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
                e.preventDefault();
                $('#<%=btnSave.ClientID%>').click();
            }
        }
    </script><script type="text/javascript">

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked

                        //check all checkboxes

                        //and highlight all rows

                        row.style.backgroundColor = "white";

                        inputList[i].checked = true;

                    }

                    else {

                        //If the header checkbox is checked

                        //uncheck all checkboxes

                        //and change rowcolor back to original

                        if (row.rowIndex % 2 == 0) {

                            //Alternating Row Color

                            row.style.backgroundColor = "white";

                        }

                        else {

                            row.style.backgroundColor = "white";

                        }

                        inputList[i].checked = false;

                    }

                }

            }

        }

    </script><script type="text/javascript">

        function MouseEvents(objRef, evt) {

            var checkbox = objRef.getElementsByTagName("input")[0];

            if (evt.type == "mouseover") {

                objRef.style.backgroundColor = "orange";

            }

            else {

                if (checkbox.checked) {

                    objRef.style.backgroundColor = "aqua";

                }

                else if (evt.type == "mouseout") {

                    if (objRef.rowIndex % 2 == 0) {

                        //Alternating Row Color

                        objRef.style.backgroundColor = "#C2D69B";

                    }

                    else {

                        objRef.style.backgroundColor = "white";

                    }

                }

            }

        }

    </script><table class="style1">
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
        <legend>WORKER INCREMENT INFORMATION(MONTHLY)</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 927px;">
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
                        <legend>INCREMENT ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 237px; text-align: right">
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
                                    <asp:Label ID="Label19" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIncrementYear" runat="server" Width="103px" Height="20px" Font-Bold="True"
                                        MaxLength="4"></asp:TextBox>
                                    <asp:TextBox ID="txtsalaryMonth" runat="server" Width="48px" Height="20px" Font-Bold="True"
                                        MaxLength="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 237px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
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
                                <td style="width: 237px; text-align: right">
                                    <asp:Label ID="Label27" runat="server" Text="Increment Amount :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="txtIncrmentAmount" runat="server" Width="80px" Height="20px" defaultfocus="txtWorkingDay"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtManuaIncrement" runat="server" Width="80px" Height="20px" defaultfocus="txtWorkingDay"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkMonthlyIncrementYn" runat="server" Text="Monthly Increment? " Checked="false" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 237px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Joining Date/Gross :"></asp:Label>
                                </td>
                                <td style="text-align: left;">
                                    <asp:TextBox ID="dtpJoiningDate" runat="server" Width="80px" Height="20px" defaultfocus="txtWorkingDay"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtGrossSalary" runat="server" Width="80px" Height="20px" defaultfocus="txtWorkingDay"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 237px;">&nbsp;
                                </td>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chkFivePercent" runat="server" Text="Allow 5% Increment?" 
                                        Enabled="true" />
                                </td>
                                <td style="text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 237px;">&nbsp;</td>
                                <td style="text-align: left;">&nbsp;</td>
                                <td style="text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add" Width="60px" CssClass="styled-button-4"
                                        OnClick="btnAdd_Click1" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="60px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="60px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="60px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnSalaryProcess" runat="server" Height="31px" Text="Process" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSalaryProcess_Click" />
                                    <asp:Button ID="btnIncrementSheet" runat="server" Height="31px" Text="Sheet" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnIncrementSheet_Click" />
                                    <asp:Button ID="btnIncrementSheetRequistion" runat="server" Height="31px" Text="Requisition"
                                        Width="80px" CssClass="styled-button-4" OnClick="btnIncrementSheetRequistion_Click" />
                                    <asp:Button ID="btnSummery" runat="server" Height="31px" Text="Summary " Width="70px"
                                        CssClass="styled-button-4" OnClick="btnSummery_Click" />
                                    <asp:Button ID="btnIncrementProposalSheet" runat="server" Height="31px" Text="Proposal "
                                        Width="70px" CssClass="styled-button-4" 
                                        OnClick="btnIncrementProposalSheet_Click" />
                                    <asp:Button ID="btnIncrementProposalExistsSheet" runat="server" Height="31px" Text="Proposal 2"
                                        Width="70px" CssClass="styled-button-4" OnClick="btnIncrementProposalExistsSheet_Click" 
                                        />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                             <tr>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label1" runat="server" Text="Unit Group :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
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
                                                <%--<td style="height: 22px; text-align: right; width: 69px;">
                                                </td>
                                                <td style="height: 22px">
                                                </td>--%>
                                                 <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td style="width: 231px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 266px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <%--<asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />--%>
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                                <%--<td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                <td style="width: 231px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 266px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <%--<asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>--%>
                                                </td>
                                                <td>
                                                    <%--<asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>--%>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td style="width: 231px; text-align: right">
                                                    <asp:Label ID="Label46" runat="server" Text="Year/Month :"></asp:Label>
                                                </td>
                                                <td style="width: 266px">
                                                    <asp:TextBox ID="txtYear" runat="server" Width="101px" BackColor="White"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlMonthId" runat="server" Width="132px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>--%>
                                            <%--<tr>
                                                <td style="width: 231px; text-align: right">
                                                    <asp:Label ID="Label47" runat="server" Text="Limit Date :"></asp:Label>
                                                </td>
                                                <td style="width: 266px">
                                                    <asp:TextBox ID="dtpLimitDate" runat="server" Width="237px" BackColor="White"
                                                        CssClass="date"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 69px">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td style="width: 231px; text-align: right">&nbsp;</td>
                                                <td style="width: 266px">&nbsp;</td>
                                                <td style="width: 66px">&nbsp;</td>
                                                <td style="text-align: right; width: 69px">&nbsp;</td>
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
                <td colspan="2">
                    <fieldset>
                        <legend>INCREMENT ENTRY RESULT WORKER</legend>
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
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="joining_date" HeaderText="J.D" />

                                            <asp:BoundField DataField="GROSS_SALARY" HeaderText="GROSS" />
                                            <asp:BoundField DataField="BASIC_SALARY" HeaderText="BASIC" />
                                            <asp:BoundField DataField="HOUSE_RENT_FEE" HeaderText="H.R" />
                                            <asp:BoundField DataField="TOTAL_INCREMENT_AMOUNT" HeaderText="AMOUNT" />
                                            <asp:BoundField DataField="current_gross" HeaderText="C.G" />
                                            <asp:BoundField DataField="INCREMENT_YEAR" HeaderText="YEAR" />
                                            <asp:BoundField DataField="INCREMENT_MONTH" HeaderText="MONTH" />

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
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="JOINING_DATE" HeaderText="J.D" />
                            <asp:BoundField DataField="GROSS_SALARY" HeaderText="GROSS" />
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE" />
                            <asp:BoundField DataField="TOTAL_YEAR" HeaderText="YEAR" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
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
