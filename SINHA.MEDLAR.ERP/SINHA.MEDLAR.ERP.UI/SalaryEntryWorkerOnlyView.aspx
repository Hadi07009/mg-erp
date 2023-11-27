<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SalaryEntryWorkerOnlyView.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.SalaryEntryWorkerOnlyView" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <style type="text/css">
        .tooltip {
            display: none;
            border: solid 1px #708069;
            background-color: #289642;
            color: #fff;
            line-height: 25px;
            border-radius: 5px;
            padding: 5px 10px;
            position: absolute;
            z-index: 1001;
        }

        .style4 {
            height: 22px;
            width: 135px;
        }

        .style5 {
            width: 135px;
        }

        .auto-style2 {
            width: 66%;
        }
        .auto-style3 {
            width: 63%;
        }
        .auto-style4 {
            width: 70%;
        }
        .auto-style5 {
            width: 76%;
        }
        .auto-style6 {
            width: 43px;
        }
        .auto-style7 {
            width: 195px;
            height: 16px;
        }
        .auto-style8 {
            width: 90%;
            height: 16px;
        }

        </style>
    <script language="javascript">

        $(document).ready(function () {

            $(".tooltip").closest("tr").mousemove(function (event) {

                $(this).find(".tooltip").css({

                    "left": event.pageX + 1,

                    "top": event.pageY + 1

                }).show();

            }).mouseout(function () { $(this).find(".tooltip").hide(); });;

        });

    </script>

     <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");
        }
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

  <%--  <script type="text/javascript">
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
    </script>--%>
    <%-- <script type="text/javascript">
        $(document).ready(function () {
            $('input[numeric]').keyup(function () {
                var d = $(this).attr('numeric');
                var val = $(this).val();
                var orignalValue = val;
                val = val.replace(/[0-9]*/g, "");
                var msg = "Only Integer Values allowed.";
                if (val != '') {
                    orignalValue = orignalValue.replace(/([^0-9].*)/g, "")
                    $(this).val(orignalValue);
                    alert(msg);
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
        <legend>WORKER SALARY INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left;" class="auto-style8">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left" class="auto-style7">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>SALARY ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right" class="auto-style4">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="text-align: left;" class="auto-style6">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right;" class="auto-style5">
                                    <asp:Label ID="Label19" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSalaryYear" runat="server" Width="103px" Height="20px" Font-Bold="True"
                                        MaxLength="4"></asp:TextBox>
                                    <asp:TextBox ID="txtsalaryMonth" runat="server" Width="48px" Height="20px" Font-Bold="True"
                                        MaxLength="2"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style4">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="text-align: left;" class="auto-style6">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right;" class="auto-style5">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" OnTextChanged="txtEmployeeId_TextChanged" Font-Bold="True"
                                        ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style4">
                                    <asp:Label ID="Label27" runat="server" Text="Working Day/OT Hour :"></asp:Label>
                                </td>
                                <td style="text-align: left;" class="auto-style6">
                                    <asp:TextBox ID="txtWorkingDay" runat="server" Width="63px" Height="20px" defaultfocus="txtWorkingDay"
                                        Font-Bold="True" Enabled="false"></asp:TextBox>
                                    <asp:TextBox ID="txtOverTimeHour" runat="server" Width="62px" Height="20px" Font-Bold="True" Enabled="false"
                                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="text-align: right;" class="auto-style5">
                                    <asp:Label ID="Label46" runat="server" Text="Leave :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalLeave" runat="server" Width="156px" Height="20px" defaultfocus="txtWorkingDay"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td style="text-align: right" class="auto-style4">
                                    <asp:Label ID="Label3" runat="server" Text="Partial Working Day/bKasy? :"></asp:Label>
                                </td>
                                <td style="text-align: left;" class="auto-style6">
                                    <asp:CheckBox ID="chkBkashYn" runat="server" Checked="true" />
                                </td>
                                <td style="text-align: right;" class="auto-style5">
                                    <asp:Label ID="Label4" runat="server" Text="Late :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTotalLate" runat="server" Width="156px" Height="20px" defaultfocus="txtWorkingDay"
                                        Font-Bold="True" BackColor="Yellow" ReadOnly="True"></asp:TextBox>

                                </td>
                            </tr>


                            <tr>
                                <td style="text-align: right" class="auto-style4">
                                    <asp:Label ID="Label43" runat="server" Text="Advance/Loan :"></asp:Label>
                                </td>
                                <td style="text-align: left;" class="auto-style6">
                                    <asp:TextBox ID="txtAdvanceFee" runat="server" Width="63px" Height="20px" Font-Bold="True"
                                        ForeColor="Red" Enabled="false" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                    <asp:TextBox ID="txtLoanAmount" runat="server" Width="62px" Height="20px" Font-Bold="True"
                                        ForeColor="Red" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right;" class="auto-style5">
                                    <asp:Label ID="Label48" runat="server" Text="Early Dpt Hour:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEarlyDptHour"  runat="server" Width="156px" Height="20px" Font-Bold="True" Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style4">
                                    <asp:Label ID="Label44" runat="server" Text="Arrear :"></asp:Label>
                                </td>
                                <td style="text-align: left;" class="auto-style6">
                                    <asp:TextBox ID="txtArrearFee" runat="server" Width="130px" Height="20px" Enabled="false" OnTextChanged="txtArrearFee_TextChanged"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right;" class="auto-style5">
                                    <asp:Label ID="Label5" runat="server" Text="Remarks :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="350px" Height="20px" Font-Bold="True" Enabled="false" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style4">
                                    <asp:Label ID="Label45" runat="server" Text="Attendence Bonus :"></asp:Label>
                                </td>
                                <td style="text-align: left;" class="auto-style6">
                                    <asp:TextBox ID="txtAttendenceFee" runat="server" Width="130px" Height="20px" Enabled="false" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="text-align: right;" class="auto-style5">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style4">&nbsp;
                                </td>
                                <td style="text-align: left;" class="auto-style6">&nbsp;
                                </td>
                                <td style="text-align: right;" class="auto-style5">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                                                        
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="50px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="40px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />

                                    <asp:Button ID="BtnMasterSheet" runat="server" Height="31px" Text="Master Sheet" Width="100px"
                                        CssClass="styled-button-4" OnClick="BtnMasterSheet_Click" />

                                    <asp:Button ID="btnSalarySheet" runat="server" Height="31px" Text="bKash Sheet" Width="100px"
                                        CssClass="styled-button-4" OnClick="btnSalarySheet_Click" />
                                    <asp:Button ID="btnCashSalarySheetWorker" runat="server" Height="31px" Text="Cash Sheet" Width="87px"
                                        CssClass="styled-button-4" OnClick="btnCashSalarySheetWorker_Click" />
                                    <asp:Button ID="btnBKashSheetWorker" runat="server" Height="31px" Text="BKash Template" Width="120px"
                                        CssClass="styled-button-4" OnClick="btnBKashSheetWorker_Click" />
                                    <asp:Button ID="btnPaySlip" runat="server" Height="31px" Text="Pay Slip" Width="55px"
                                        CssClass="styled-button-4" OnClick="btnPaySlip_Click" />
                                    <asp:Button ID="btnSalaryHistory" runat="server" Height="31px" Text="History" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnSalaryHistory_Click" />
                                    
                                 
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="auto-style5">

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
                                                <td style="width: 66px">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label2" runat="server" Text="Employee Type :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 66px">
                                                    <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="152px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Staff"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Worker"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>


                                            <tr>
                                                <td style="text-align: right;" class="auto-style2">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>

                                                <td style="width: 66px">&nbsp;
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
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>SALARY ENTRY RESULT WORKER</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="EMPLOYEE_ID" 
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_OnSelectedIndexChanged" OnRowDeleting="GridView1_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="WORKING_DAY" HeaderText="DAY" />  
                                            
                                            <asp:BoundField DataField="PARTIAL_DAY" HeaderText="PARTIAL DAY" />  
                                                                                  
                                            <asp:BoundField DataField="OVER_TIME_HOUR" HeaderText="OT" />
                                            <asp:BoundField DataField="EARLY_DEPTR_HOUR" HeaderText="E.D.Hour" />
                                            <asp:BoundField DataField="ADVANCE_FEE" HeaderText="ADVANCE" />
                                            <asp:BoundField DataField="ADVANCE_SALARY" HeaderText="ADV.SAL"   />
                                            <asp:BoundField DataField="ARREAR_FEE" HeaderText="ARREAR" />
                                            <asp:BoundField DataField="ATTENDENCE_FEE" HeaderText="BONUS" />                                          
                                            
                                            <asp:BoundField DataField="NUMBER_OF_ABSENT" HeaderText="ABSENT DAY" />
                                            <asp:BoundField DataField="NUMBER_OF_LEAVE" HeaderText="LEAVE DAY" />
                                            <asp:BoundField DataField="NUMBER_OF_LATE" HeaderText="LATE DAY" />

                                            <asp:BoundField DataField="BKASH_YN" HeaderText="BKASH_YN" />

                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <asp:BoundField DataField="PUNCH_YN" HeaderText="PUNCH_YN" />
                                                                                        
                                            <asp:TemplateField HeaderText="HISTORY" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                   <asp:ImageButton ID="btnHistory" runat="server" Text="History" ImageUrl="~/images/sheet.png"
                                                        AlternateText="History" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Width="30px" CommandName="History"
                                                        Height="25px" Visible="true" />
                                                 </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Detail" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                   <asp:ImageButton ID="btnDetail" runat="server" Text="Detail" ImageUrl="~/images/info.png"
                                                        AlternateText="Detail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                        Width="30px" CommandName="Detail"
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
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="EMPLOYEE_ID"
                        AllowSorting="True" EnableViewState="true" ClientSelectionMode="SingleRow" GridLines="None"
                        AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing"
                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        CausesValidation="false" OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" HeaderStyle-Width="20" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" HeaderStyle-Width="30" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME"  HeaderStyle-Width="100" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" HeaderStyle-Width="100" />
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE"  HeaderStyle-Width="20"/>
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID"  HeaderStyle-Width="40" />

                            <asp:TemplateField HeaderText="HISTORY" ItemStyle-Width="1%">
                                <ItemTemplate>
                                   <asp:ImageButton ID="btnHistory" runat="server" Text="History" ImageUrl="~/images/sheet.png"
                                        AlternateText="History" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                        Width="30px" CommandName="History"
                                        Height="25px" Visible="true" />
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
            <td>
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
