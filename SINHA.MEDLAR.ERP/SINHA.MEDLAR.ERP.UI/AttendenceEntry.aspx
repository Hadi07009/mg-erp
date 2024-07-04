<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AttendenceEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AttendenceEntry" %>

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
        $(window).load(function () { document.getElementById("<%= txtFirstInTime.ClientID %>").focus(); }) 
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
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <fieldset>
        <legend>ATTENDENCE INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Checked="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>ATTENDENCE ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 271px; text-align: right">
                                    <asp:Label ID="Label27" runat="server" Text="In Time :"></asp:Label>
                                </td>
                                <td style="width: 202px; text-align: left;">
                                    <asp:TextBox ID="txtFirstInTime" runat="server" Width="100px" Height="20px" Font-Bold="True"
                                        Style="margin-bottom: 0px" Enabled="False"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
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
                                <td style="width: 271px; text-align: right">
                                    <asp:Label ID="Label42" runat="server" Text="Lunch Out :"></asp:Label>
                                </td>
                                <td style="width: 202px; text-align: left;">
                                    <asp:TextBox ID="txtLunchOutTime" runat="server" Width="100px" Height="20px" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label5" runat="server" Text="Name :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="256px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Lunch In :"></asp:Label>
                                </td>
                                <td style="width: 202px; text-align: left;">
                                    <asp:TextBox ID="txtLunchInTime" runat="server" Width="100px" Height="20px" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="256px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; text-align: right">
                                    <asp:Label ID="Label44" runat="server" Text="Out Time/ Out Date :"></asp:Label>
                                </td>
                                <td style="width: 202px; text-align: left;">
                                    <asp:TextBox ID="txtFinalTimeOut" runat="server" Width="100px" Height="20px" Font-Bold="True"
                                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                    <asp:TextBox ID="dtpFinalOutDate" runat="server" Width="80px" Height="20px" CssClass="date"
                                        DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Font-Bold="False"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label33" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="256px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 271px; text-align: right">
                                    <asp:Label ID="Label46" runat="server" Text="Remarks :"></asp:Label>
                                </td>
                                <td style="width: 202px; text-align: left;">
                                    <asp:TextBox ID="txtRemarks" runat="server" Width="216px" Height="34px" Font-Bold="False"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" TextMode="MultiLine"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="text-align: right;">
                                    <asp:Label ID="Label45" runat="server" Text="All Unit :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkAllUnit" runat="server" Text="Y/N" AutoPostBack="true" Font-Bold="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label3" runat="server" Text="All Active:"></asp:Label>
                                    <asp:CheckBox ID="ChkAllActive" runat="server" Text="Y/N" AutoPostBack="true" Font-Bold="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                                </td>
                            </tr>
                             <tr>
                                <td style="width: 271px; text-align: right">
                                    <asp:Label ID="Label47" runat="server" Text="Hour/Munite :"></asp:Label>
                                </td>
                                <td style="width: 202px; text-align: left;">
                                    <asp:TextBox ID="txtOTHourMinute" runat="server" Width="213px" 
                                        BackColor="White" Height="25px"></asp:TextBox>
                                </td>
                                <td style="text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                             
                            <tr>
                                <td style="width: 271px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 202px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="text-align: right;">
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
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" OnClientClick="target = '_SELF';" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnProcess_Click" />
                                    <asp:Button ID="btnAttendenceSheet" runat="server" Height="31px" Text="Sheet" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAttendenceSheet_Click" />
                                    <asp:Button ID="btnAbsenceSheet" runat="server" Height="31px" Text="Absence Sheet"
                                        Width="105px" CssClass="styled-button-4" OnClick="btnAbsenceSheet_Click" />
                                    <asp:Button ID="btnAbsenceSheet0" runat="server" Height="31px" Text="Manual Attn Sheet"
                                        Width="114px" CssClass="styled-button-4" OnClick="btnManualAttendanceSheet_Click" />
                                    <asp:Button ID="btnAttendenceSheet0" runat="server" Height="31px" Text="WO LogIn Sheet" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnWOLogInSheet_Click" />
                                    <asp:Button ID="btnAttendenceSheet1" runat="server" Height="31px" Text="WO Last Out Sheet" Width="83px"
                                        CssClass="styled-button-4" OnClick="btnWOLastOutSheet_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" CssClass="styled-button-4"
                                        OnClientClick="target = '_SELF';" OnClick="btnShow_Click" />
                                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" 
                                        Width="66px" CssClass="styled-button-4"
                                        OnClientClick="target = '_SELF';" OnClick="btnDelete_Click"  />
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
                        <legend>SEARCH RESULT</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GridView1_OnRowEditing"
                                        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_OnRowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="FIRST_IN" HeaderText="IN" />
                                            <asp:BoundField DataField="LUNCH_OUT" HeaderText="LUNCH OUT" />
                                            <asp:BoundField DataField="LUNCH_IN" HeaderText="LUNCH IN" />
                                            <asp:BoundField DataField="LAST_OUT" HeaderText="OUT" />
                                            <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" />
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
                        <%-- </div>--%>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <table class="style1">
            <tr>
               <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label2" runat="server" Text="Unit Group :"></asp:Label>
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
            </tr>
            <tr>
                <td style="width: 276px; text-align: right; height: 22px;">
                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
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
                <td style="width: 276px; text-align: right">
                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
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
                <td style="width: 276px; text-align: right">
                    <asp:Label ID="Label19" runat="server" Text="Date :"></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:TextBox ID="dtpAttendenceDate" runat="server" Width="238px" Height="20px" CssClass="date"
                        DateFormat="dd/MM/yyyy" DisplayDateFormat="dd/MM/yyyy" Font-Bold="False"></asp:TextBox>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                                    <asp:Label ID="lblSittingType" runat="server" Text="Sitting Type:"></asp:Label>
                </td>
                <td>
                  <asp:DropDownList ID="ddlSittingType" runat="server" Width="153px" 
                                        Height="24px">
                                             <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                             <asp:ListItem Value="1" Text="Sitting Hare"></asp:ListItem>
                                             <asp:ListItem Value="2" Text="Others"></asp:ListItem>
                                         </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td style="width: 276px; text-align: right">
                    <asp:Label ID="Label1" runat="server" Text="Shift :" Visible="true"></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlShiftId" runat="server" Width="240px" Height="22px" Visible="true"></asp:DropDownList>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                                    <asp:Label ID="Label48" runat="server" Text="Floor :"></asp:Label>
                </td>
                <td>
                  <asp:DropDownList ID="ddlFloor" runat="server" Width="153px" 
                        Height="24px"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td style="width: 276px; text-align: right">
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:CheckBox ID="chkAll" runat="server" Text="All" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                    &nbsp;
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <%-- </div>--%>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />                            
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="unit_name" HeaderText="UNIT NAME" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <%-- </div>--%>
    </fieldset>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
            <td>
                &nbsp;
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
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
