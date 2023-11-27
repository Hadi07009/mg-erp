<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="BonusProcessStaffManual.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.BonusProcessStaffManual" %>

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
                document.getElementById('<%= btnSave.ClientID %>').click();
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
        <legend>BONUS INFORMATION STAFF</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 601px;">
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
                                <td style="width: 277px; text-align: right">
                                    <asp:Label ID="Label37" runat="server" Text="Eid Name :"></asp:Label>
                                </td>
                                <td style="width: 429px; text-align: left;">
                                    <asp:DropDownList ID="ddlEidTypeId" runat="server" Width="160px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 108px; text-align: right;">
                                    <asp:Label ID="Label41" runat="server" Text="Card No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="216px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 277px; text-align: right">
                                    <asp:Label ID="Label42" runat="server" Text="Year :"></asp:Label>
                                </td>
                                <td style="width: 429px; text-align: left;">
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
                                <td style="width: 277px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Bonus Amount :"></asp:Label>
                                </td>
                                <td style="width: 429px; text-align: left;">
                                    <asp:TextBox ID="txtBonusAmount" runat="server" Width="75px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSecondBonusAmount" runat="server" Width="75px" Height="20px"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" Font-Bold="True"></asp:TextBox>
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
                                <td style="width: 277px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 429px; text-align: left;">
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
                                <td style="width: 277px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 429px; text-align: left;">
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
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="60px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" OnClientClick="target = '_SELF';" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="60px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" OnClientClick="target = '_SELF';" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="60px" CssClass="styled-button-4"
                                        OnClick="btnShow_Click" />
                                    <asp:Button ID="btnFirstSheet" runat="server" Height="31px" Text="First Sheet" Width="72px"
                                        CssClass="styled-button-4" OnClick="btnFirstSheet_Click" />
                                    <asp:Button ID="btnBonusPaySlipStaffFirst" runat="server" Height="31px" Text="Slip"
                                        Width="60px" CssClass="styled-button-4" 
                                        OnClick="btnBonusPaySlipStaffFirst_Click" />
                                    <asp:Button ID="btnSecondSheet" runat="server" Height="31px" Text="Second Sheet"
                                        Width="89px" CssClass="styled-button-4" OnClick="btnSecondSheet_Click" />
                                    <asp:Button ID="btnBonusPaySlipStaffSecond" runat="server" Height="31px" Text="Slip"
                                        Width="60px" CssClass="styled-button-4" 
                                        OnClick="btnBonusPaySlipStaffSecond_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 94px; text-align: right; height: 22px;">
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
                                                <td style="width: 94px; text-align: right">
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
                                                <td style="width: 94px; text-align: right">
                                                    <asp:Label ID="Label44" runat="server" Text="From/To Month :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                    <asp:TextBox ID="txtFromMonth" runat="server" Width="75px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtToMonth" runat="server" Width="75px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
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
                <legend>BONUS PROCESS RESULT STAFF</legend>
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
                                    <asp:BoundField DataField="JOINING_DATE" HeaderText="J.D" />
                                    <asp:BoundField DataField="TOTAL_MONTH" HeaderText="MONTH" />
                                    <asp:BoundField DataField="GROSS_SALARY" HeaderText="GROSS" />
                                    <asp:BoundField DataField="BONUS_AMOUNT_FIRST" HeaderText="1ST SAL" />
                                    <asp:BoundField DataField="BONUS_AMOUNT_SECOND" HeaderText="2ND SAL" />
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
    </table> </fieldset>
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
