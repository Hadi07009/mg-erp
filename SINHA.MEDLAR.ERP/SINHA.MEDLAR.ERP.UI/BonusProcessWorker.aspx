<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="BonusProcessWorker.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.BonusProcessWorker" %>

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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtBonusAmount.ClientID %>").focus(); }) 
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
        <legend>BONUS INFORMATION WORKER</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 918px;">
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
                        <legend>BONUS PROCESS</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 244px; text-align: right">
                                    <asp:Label ID="Label37" runat="server" Text="Eid Name :"></asp:Label>
                                </td>
                                <td style="width: 162px; text-align: left;">
                                    <asp:DropDownList ID="ddlEidTypeId" runat="server" Width="160px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 108px; text-align: right;">
                                    <asp:Label ID="Label41" runat="server" Text="Card No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="218px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 244px; text-align: right">
                                    <asp:Label ID="Label42" runat="server" Text="Year :"></asp:Label>
                                </td>
                                <td style="width: 162px; text-align: left;">
                                    <asp:TextBox ID="txtYear" runat="server" Width="100px" Height="20px" BackColor="Yellow"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 108px; text-align: right;">
                                    <asp:Label ID="Label5" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="256px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 244px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Bonus Amount :"></asp:Label>
                                </td>
                                <td style="width: 162px; text-align: left;">
                                    <asp:TextBox ID="txtBonusAmount" runat="server" Width="100px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 108px; text-align: right;">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="256px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 244px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 162px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 108px; text-align: right;">
                                    <asp:Label ID="Label33" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="256px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 244px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 162px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 108px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">

                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnAdd_Click" />

                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="60px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" OnClientClick="target = '_SELF';" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="60px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" OnClientClick="target = '_SELF';" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" 
                                        OnClientClick="target = '_SELF';" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="50px" CssClass="styled-button-4"
                                        OnClick="btnShow_Click" />
                                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnProcess_Click" />
                                    <asp:Button ID="btnMasterSheet" runat="server" Height="31px" Text="Master Sheet" Width="100px"
                                        CssClass="styled-button-4" OnClick="btnMasterSheet_Click" />
                                    <asp:Button ID="btnBkashSheet" runat="server" Height="31px" Text="bKash Sheet" Width="100px"
                                        CssClass="styled-button-4" OnClick="btnBkashSheet_Click" />
                                                                        
                                    <%--<asp:Button ID="btnBkashWorkerBonusSheet" runat="server" Height="31px" Text="Bkash Template" Width="101px"
                                        CssClass="styled-button-4" OnClick="btnBkashWorkerBonusSheet_Click" />--%>

                                    <asp:Button ID="btnCashSheet" runat="server" Height="31px" Text="Cash Sheet" Width="100px"
                                        CssClass="styled-button-4" OnClick="btnCashSheet_Click" />

                                    <asp:Button ID="btnBkashWorkerBonusSheet" runat="server" Height="31px" Text="Bkash Template" Width="101px"
                                        CssClass="styled-button-4" OnClick="btnBkashWorkerBonusSheet_Click" />
                                    <asp:Button ID="btnBkashTemplateAll" runat="server" Height="31px" Text="Bkash Template(All)" Width="129px"
                                        CssClass="styled-button-4" OnClick="btnBkashTemplateAll_Click" />
                                    <asp:Button ID="btnEidBonusBkashSummary" runat="server" Height="31px" Text="BKash Summary"
                                        Width="99px" CssClass="styled-button-4" OnClick="btnEidBonusBkashSummary_Click" />
                                    <asp:Button ID="btnEidBonusCashSummary" runat="server" Height="31px" Text="Cash Summary"
                                        Width="99px" CssClass="styled-button-4" OnClick="btnEidBonusCashSummary_Click" />
                                    <asp:Button ID="btnSlip" runat="server" Height="31px" Text="Slip" Width="50px" CssClass="styled-button-4"
                                        OnClick="btnSlip_Click" />
                                    <asp:Button ID="btnEidBonusRequisition" runat="server" Height="31px" Text="Requisition"
                                        Width="75px" CssClass="styled-button-4" OnClick="btnEidBonusRequisition_Click" />
                                    <asp:Button ID="btnEidBonusCashReq" runat="server" Height="31px" Text="Cash Req"
                                        Width="75px" CssClass="styled-button-4" OnClick="btnEidBonusCashReq_Click" />
                                    <asp:Button ID="btnEidBonusBKashReq" runat="server" Height="31px" Text="BKash Req"
                                        Width="75px" CssClass="styled-button-4" OnClick="btnEidBonusBKashReq_Click" />
                                     <asp:Button ID="btnEidBonusCompareRequisition" runat="server" Height="31px" Text="Com Req."
                                        Width="75px" CssClass="styled-button-4" OnClick="btnEidBonusCompareRequisition_Click" />
                                    <asp:Button ID="btnEidBonusRequisitionSummery" runat="server" Height="31px" Text="Summary"
                                        Width="70px" CssClass="styled-button-4" OnClick="btnEidBonusRequisitionSummery_Click" 
                                      />
                                    <asp:Button ID="btnEidBonusSheetBpProcess" runat="server" Height="31px" Text="Process"
                                        Width="60px" CssClass="styled-button-4" onclick="btnEidBonusSheetBpProcess_Click" 
                                        />
                                    <asp:Button ID="btnEidBonusSheetBp" runat="server" Height="31px" Text="Sheet"
                                        Width="50px" CssClass="styled-button-4" onclick="btnEidBonusSheetBp_Click" 
                                        />
                                    <asp:Button ID="btnEidBonusRequisitionSheetBp" runat="server" Height="31px" Text="Req"
                                        Width="60px" CssClass="styled-button-4" onclick="btnEidBonusRequisitionSheetBp_Click" 
                                        />
                                    <asp:Button ID="btnBkashSheetParcial" runat="server" Height="31px" Text="bKash Sheet Part" Width="125px"
                                        CssClass="styled-button-4" OnClick="btnBkashSheetParcial_Click" Visible="false"/>
                                    <asp:Button ID="btnCashSheetPart" runat="server" Height="31px" Text="Cash Sheet part" Width="100px"
                                        CssClass="styled-button-4" OnClick="btnCashSheetPart_Click" Visible="false" />
                                    <asp:Button ID="btnEidBonusBKashReqParcial" runat="server" Height="31px" Text="BKash Req Part."
                                        Width="112px" CssClass="styled-button-4" OnClick="btnEidBonusBKashReqParcial_Click" Visible="false" />
                                    <asp:Button ID="btnEidBonusCashReqPart" runat="server" Height="31px" Text="Cash Req Part"
                                        Width="93px" CssClass="styled-button-4" OnClick="btnEidBonusCashReqPart_Click" Visible="false" />
                                    <asp:Button ID="BtnPartWalletTemplate" runat="server" Height="31px" Text="bKash Template all (Part)"
                                        Width="150px" CssClass="styled-button-4" OnClick="BtnPartWalletTemplate_Click" Visible="false" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 236px; text-align: right; height: 22px;">
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
                                                <%--<td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label2" runat="server" Text="Employee Type :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="152px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Staff"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Worker"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>--%>
                                                 <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="lblPhase" runat="server" Text="Phase Type :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:DropDownList ID="ddlPhaseId" runat="server" Width="152px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Phase-1"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Phase-2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 236px; text-align: right; height: 22px;">
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
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 236px; text-align: right">
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
                        <legend>BONUS PROCESS RESULT WORKER</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                        OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="JOINING_DATE" HeaderText="JOINING DATE" />
                                            <asp:BoundField DataField="TOTAL_MONTH" HeaderText="MONTH" />
                                            <asp:BoundField DataField="GROSS_SALARY" HeaderText="GROSS" />
                                            <asp:BoundField DataField="BONUS_AMOUNT" HeaderText="BONUS AMT" />
                                            <asp:BoundField DataField="BONUS_PERCENT" HeaderText="(%)" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                        Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
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
                        AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="gvEmployeeList_OnRowEditing"
                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        CausesValidation="false" OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE" />
                            <asp:BoundField DataField="TOTAL_MONTH" HeaderText="MONTH" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeId" Text='<%#Eval("EMPLOYEE_ID") %>' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
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
        <tr>
            <td colspan="2">
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
