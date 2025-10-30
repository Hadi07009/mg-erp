<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="SalaryEntryHO.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MiscEntryHO" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(document).keypress(function (e) {
            if (e.which == 13) {
                $(document.activeElement).next().focus();
            }
        });
    </script>
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtAdvanceFee.ClientID %>").focus(); }) 
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
                e.preventDefault();
                $('#<%=btnSave.ClientID%>').click();
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
        <legend>HO SALARY INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 920px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                    <asp:Label ID="lblMsgSecondSheet" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
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
                        <legend>SALARY ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 270px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 290px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 90px; text-align: right;">
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
                                <td style="width: 270px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 290px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 90px; text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" OnTextChanged="txtEmployeeId_TextChanged" Font-Bold="True"
                                        ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 270px; text-align: right">
                                    <asp:Label ID="Label27" runat="server" Text="Advance/Loan :"></asp:Label>
                                </td>
                                <td style="width: 290px; text-align: left;">
                                    <asp:TextBox ID="txtAdvanceFee" runat="server" Width="62px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtLoanAmount" runat="server" Width="62px" Height="20px" Font-Bold="True"
                                        ForeColor="Red" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 90px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 270px; text-align: right">
                                    <asp:Label ID="Label29" runat="server" Text="Arrear :"></asp:Label>
                                </td>
                                <td style="width: 290px; text-align: left;">
                                    <asp:TextBox ID="txtArrearFee" runat="server" Width="130px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                </td>
                                <td style="width: 90px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 270px; text-align: right; height: 26px;">
                                    <asp:Label ID="Label45" runat="server" Text="Working Day :"></asp:Label>
                                </td>
                                <td style="width: 290px; text-align: left; height: 26px;">
                                    <asp:TextBox ID="txtWorkingDay" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 90px; text-align: right; height: 26px;">
                                    &nbsp;
                                </td>
                                <td style="height: 26px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 270px; text-align: right; height: 15px;">
                                    <asp:Label ID="Label43" runat="server" Text="Food Allowance :"></asp:Label>
                                </td>
                                <%--onkeydown="javascript:TextName_OnKeyDown(event)"--%>
                                <td style="width: 290px; text-align: left; height: 15px;">
                                    <asp:TextBox ID="txtFoodAllowance" runat="server" Width="130px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)"
                                         BackColor="Yellow" 
                                        ></asp:TextBox>
                                </td>
                                <td style="width: 90px; text-align: right; height: 15px;">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 270px; text-align: right; height: 15px;">
                                    <asp:Label ID="Label44" runat="server" Text="Food Deduction :"></asp:Label>
                                </td>
                                <td style="width: 290px; text-align: left; height: 15px;">
                                    <asp:TextBox ID="txtFoodDeduction" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True" ForeColor="Red" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="width: 90px; text-align: right; height: 15px;">
                                    &nbsp;
                                </td>
                                <td class="style3">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style=" text-align: right; height: 15px; width: 270px;">
                                    &nbsp;
                                </td>
                                <td style="width: 290px; text-align: left; height: 15px;">
                                    &nbsp;
                                </td>
                                <td style="width: 90px; text-align: right; height: 15px;">
                                    &nbsp;
                                </td>
                                <td style="height: 15px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center; height: 15px;" colspan="4">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="51px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="45px" CssClass="styled-button-4"
                                        OnClick="btnNext_Click" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="49px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="48px" CssClass="styled-button-4"
                                        OnClick="btnShow_Click" />
                                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process" Width="51px"
                                        CssClass="styled-button-4" OnClick="btnProcess_Click" />
                                    <asp:Button ID="btnSalarySheet" runat="server" Height="31px" Text="Sheet" Width="45px"
                                        CssClass="styled-button-4" OnClick="btnSalarySheet_Click" />
                                    <asp:Button ID="btnSalarySheetTemporary" runat="server" Height="31px" Text="Sheet(T)" Width="60px" Visible="false"
                                        CssClass="styled-button-4" OnClick="btnSalarySheetTemporary_Click" />
                                    <asp:Button ID="btnSalarySlip" runat="server" Height="31px" Text="Slip" Width="40px"
                                        CssClass="styled-button-4" OnClick="btnSalarySlip_Click" />
                                    <asp:Button ID="btnBankSheet" runat="server" Height="31px" Text="B. Sheet" Width="55px"
                                        CssClass="styled-button-4" OnClick="btnBankSheet_Click" />
                                    <asp:Button ID="btnMonthlyBankSalarySlip" runat="server" Height="31px" 
                                        Text="B. Slip" Width="55px"
                                        CssClass="styled-button-4" OnClick="btnMonthlyBankSalarySlip_Click"    />
                                    <asp:Button ID="btnMonthlySalaryRequisition" runat="server" Height="31px" 
                                        Text="B. Req" Width="55px"
                                        CssClass="styled-button-4" 
                                        OnClick="btnMonthlySalaryRequisition_Click"     />
                                    <asp:Button ID="btnMonthlyCashSheet" runat="server" Height="31px" 
                                        Text="C. Sheet" Width="55px"
                                        CssClass="styled-button-4" onclick="btnMonthlyCashSheet_Click"  />
                                    <asp:Button ID="btnMonthlyCashSalarySlip" runat="server" Height="31px" 
                                        Text="C. Slip" Width="55px"
                                        CssClass="styled-button-4" OnClick="btnMonthlyCashSalarySlip_Click"   />
                                    <asp:Button ID="btnMonthlyCashRequisition" runat="server" Height="31px" 
                                        Text="C. Req." Width="55px"
                                        CssClass="styled-button-4" OnClick="btnMonthlyCashRequisition_Click" 
                                           />
                                    
                                    <asp:Button ID="BtnCashSheetCNF" runat="server" Height="31px" 
                                        Text="C&F Sheet" Width="70px"
                                        CssClass="styled-button-4" onclick="BtnCashSheetCNF_Click"  />


                                    <asp:Button ID="BtnCashReqCNF" runat="server" Height="31px" 
                                        Text="CNF Req." Width="60px"
                                        CssClass="styled-button-4" OnClick="BtnCashReqCNF_Click" 
                                           />

                                    <asp:Button ID="btnMonthlyCashSheetDirector" runat="server" Height="31px" 
                                        Text="C. Sheet D." Width="87px"
                                        CssClass="styled-button-4" onclick="btnMonthlyCashSheetDirector_Click"  />
                                    <asp:Button ID="btnMonthlyCashRequisitionDirector" runat="server" Height="31px" 
                                        Text="C. Req. D." Width="70px"
                                        CssClass="styled-button-4" OnClick="btnMonthlyCashRequisitionDirector_Click" 
                                           />
                                    <asp:Button ID="btnSalaryTIN" runat="server" Height="31px" 
                                        Text="Sheet(TIN)" Width="70px"
                                        CssClass="styled-button-4" OnClick="btnSalaryTIN_Click"  
                                           />


                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 267px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                  
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 267px; text-align: right">
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
                                            <tr>
                                                <td style="width: 267px; text-align: right">
                                                  <asp:Label ID="Label355" runat="server" Text="Bank :"></asp:Label>
                    
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlBank" runat="server" Width="240px" Height="24px">
                                                     </asp:DropDownList>
                    
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;</td>
                                                <td style="text-align: right; width: 69px">
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
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>SALARY ENTRY RESULT HO</legend>
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
                                            <asp:BoundField DataField="ADVANCE_FEE" HeaderText="ADVANCE" />
                                            <asp:BoundField DataField="ADVANCE_SALARY" HeaderText="ADV.SAL"   />
                                            <asp:BoundField DataField="ARREAR_FEE" HeaderText="ARREAR" />
                                            <asp:BoundField DataField="FOOD_ALLOWANCE_FEE" HeaderText="F.ALLOW" />
                                            <asp:BoundField DataField="FOOD_DEDUCT_FEE" HeaderText="F.DEDUCT" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <asp:BoundField DataField="WORKING_DAY" HeaderText="W.D" />
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
                        AllowSorting="True" OnSorting="gvEmployeeList_Sorting" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
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
            <td>
                &nbsp;
                <asp:Button ID="btnCashSheet" runat="server" Height="31px" Text="Cash Sheet" Width="80px"
                    CssClass="styled-button-4" OnClick="btnCashSheet_Click" Visible="False" />
                <asp:Button ID="btnSalarySheetByBank" runat="server" Height="31px" Text="Sheet ACTB"
                    CssClass="styled-button-4" Width="85px" OnClick="btnSalarySheetByBank_Click"
                    Visible="False" />
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
