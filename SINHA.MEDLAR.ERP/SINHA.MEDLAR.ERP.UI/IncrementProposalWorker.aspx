<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="IncrementProposalWorker.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.IncrementProposalWorker" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= btnSearch.ClientID %>").focus(); }) 
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
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
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
        <legend>INCREMENT PROPOSAL WORKER INFORMATION</legend>
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
                        <legend>INCREMENT ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 283px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 277px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 40px;">
                                    <asp:Label ID="Label19" runat="server" Text="Year :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIncrementYear" runat="server" Width="156px" Height="20px" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 283px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 277px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 40px;">
                                    <asp:Label ID="lblMonth" runat="server" Text="Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtMonth" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red" Text="12"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td style="text-align: right; height: 22px; width: 283px;">
                                    <asp:Label ID="LblAllowGeneralIncrement" runat="server" Text="Allow (9%) Increment(General) :"></asp:Label>        
                                </td>
                                <td style="width: 277px; text-align: left; height: 22px;">
                                    <asp:CheckBox ID="ChkAllowGeneralIncrement" runat="server" Text="" Visible="true" Checked="true" Enabled="false" ></asp:CheckBox>
                                </td>
                                <td style="text-align: right; width: 40px;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True" BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>


                            <%------%>
                            <tr>
                                <td style="text-align: right; height: 22px; width: 283px;">
                                    <asp:Label ID="Label2" runat="server" Text="Individual(5%) Incr (Yes/No) :"></asp:Label>        
                                </td>
                                <td style="width: 277px; text-align: left; height: 22px;">
                                    <asp:CheckBox ID="ChkIndividualAutoIncrYn" runat="server" Visible="true"></asp:CheckBox>
                                </td>
                                <td style="text-align: right; width: 40px;">
                                    <%--<asp:Label ID="Label3" runat="server" Text="ID :"></asp:Label>&nbsp;--%>
                                </td>
                                <td>
                                    <%--<asp:TextBox ID="TextBox1" runat="server" Width="156px" Height="20px" ReadOnly="True" BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>--%>
                                </td>
                            </tr>


                            <tr>
                                <td style="text-align: right; height: 22px; width: 283px;">
                                    &nbsp;
                                </td>
                                <td style="width: 277px; text-align: left; height: 22px;">
                                    &nbsp;
                                </td>
                                <td style="text-align: right; height: 22px; width: 40px;">&nbsp;
                                </td>
                                <td style="height: 22px">&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Button ID="BtnSaveAutoIncr" runat="server" Height="31px" Text="Save"
                                        Width="66px" CssClass="styled-button-4" OnClick="BtnSaveAutoIncr_Click"/>
                                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process"
                                        Width="66px" CssClass="styled-button-4" OnClick="btnProcess_Click" Enabled="true"/>
                                    <asp:Button ID="btnSheetAboveOneYear" runat="server" Height="31px" Text="Sheet"
                                        Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSheetAboveOneYear_Click" />
                                    <asp:Button ID="btnSheetAboveOneYearAll" runat="server" Height="31px" Text="Sheet All"
                                        Width="66px" CssClass="styled-button-4" OnClick="btnSheetAboveOneYearAll_Click" />
                                    <asp:Button ID="btnSummerySheet" runat="server" Height="31px"
                                        Text="Summary Bng." CssClass="styled-button-4"
                                        Width="100px" OnClick="btnSummerySheet_Click" Visible ="false" />
                                    <asp:Button ID="btnSummerySheetEnglish" runat="server" Height="31px"
                                        Text="Summary Eng." CssClass="styled-button-4"
                                        Width="100px" OnClick="btnSummerySheetEnglish_Click" />
                                    <asp:Button ID="BtnProposalReqSummary" runat="server" Height="31px"
                                        Text="Req Summary." CssClass="styled-button-4"
                                        Width="100px" OnClick="BtnProposalReqSummary_Click" />
                                    <asp:Button ID="btnSummerySheetEnglishByUnitGroup" runat="server" Height="31px"
                                         Text="Summary Eng (UG)" CssClass="styled-button-4"
                                         Width="145px" OnClick="btnSummerySheetEnglishByUnitGroup_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnGradeAdjustmentAboveOneYear" runat="server" Height="31px" Text="Grade Sheet"
                                        Width="90px" CssClass="styled-button-4" OnClick="btnGradeAdjustmentAboveOneYear_Click"
                                       />
                                    <asp:Button ID="btnSheetAboveOneYearExcelSheet" runat="server" 
                                        CssClass="styled-button-4" Height="31px" 
                                        OnClick="btnAboveOneYearExcelSheet_Click" Text="Sheet(Excel)" Width="81px" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Label ID="Label3" runat="server" Height="25px" Text="Under 1 year"></asp:Label>
                                <asp:Button ID="btnProcessLessOne" runat="server" Height="31px" Text="Process"
                                        Width="66px" CssClass="styled-button-4"  Enabled="true" 
                                        OnClick="btnProcessLessOne_Click"/> 
                                    <asp:Button ID="btnSheetLessOne" runat="server" Height="31px" Text="Sheet"
                                        Width="66px" CssClass="styled-button-4" OnClick="btnSheetLessOne_Click"
                                         /> 
                                    <asp:Button ID="btnRSummaryLessOne" runat="server" Height="31px"
                                        Text="Req Summary." CssClass="styled-button-4"
                                        Width="100px" OnClick="btnRSummaryLessOne_Click"  />
                                    <asp:Button ID="btnSummaryEngLOne" runat="server" Height="31px"
                                        Text="Summary Eng." CssClass="styled-button-4"
                                        Width="100px" OnClick="btnSummaryEngLOne_Click"  />  
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
                                                <td style="width: 66px">
                                                    <asp:Button ID="btnSearch" runat="server" Height="24px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />

                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td style="width: 274px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                      <%--          <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />

                                                </td>--%>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 274px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px">&nbsp;
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td style="text-align: right; width: 69px">
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
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
                        <legend>INCREMENT ENTRY RESULT</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        CausesValidation="false" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>    
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="JOINING_DATE" HeaderText="J.D" />
                                            <asp:BoundField DataField="TOTAL_YEAR" HeaderText="YEAR" />
                                            <asp:BoundField DataField="TOTAL_MONTH" HeaderText="MONTH" />
                                            <asp:BoundField DataField="GROSS_SALARY" HeaderText="GROSS" />
                                            <asp:BoundField DataField="TOTAL_5_PERCENT" HeaderText="Incr(5%)" />
                                            <%--<asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />--%>

                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>' ReadOnly="true"></asp:TextBox>
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
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="gvEmployeeList_OnRowEditing"
                        CausesValidation="false" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="gvEmployeeList_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
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
        <tr>
            <td colspan="2">&nbsp;<asp:Button ID="btnSave" runat="server" Height="31px" Text="Save"
                Width="66px"
                OnClick="btnSave_Click" CssClass="styled-button-4" Visible="False" />
                <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px" OnClick="btnNext_Click"
                    CssClass="styled-button-4" Visible="False" />
                <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"
                    CssClass="styled-button-4" OnClick="btnPrevious_Click" Visible="False" />
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
