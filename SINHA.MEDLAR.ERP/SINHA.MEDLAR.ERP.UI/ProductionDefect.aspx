<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ProductionDefect.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ProductionDefect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
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

   <%--new--%>
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


   <%--old--%>
   <%-- <script type="text/javascript" language="javascript">
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
    </script>--%>
    
    <script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtTotalOperator.ClientID %>").focus(); }) 
    </script>
    <script type="text/javascript" language="javascript">
        function doClick(buttonName, e) {
            //the purpose of this function is to allow the enter key to 
            //point to the correct button to click.
            var key;

            if (window.event)
                key = window.event.keyCode;     //IE
            else
                key = e.which;     //firefox

            if (key == 13) {
                //Get the button the user wants to have clicked
                var btn = document.getElementById(buttonName);
                if (btn != null) { //If we find the button click it
                    btn.click();
                    event.keyCode = 0
                }
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
        <legend>QUANTITY PRODUCTION/DEFECT INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 601px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>QUANTITY PRODUCTION/DEFECT ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="74px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="150px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 353px; text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="170px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 353px; text-align: right;">
                                    <asp:Label ID="Label55" runat="server" Text="Process :"></asp:Label>
                                </td>
                                <td>
                   
                                    <asp:TextBox ID="txtProcessName" runat="server" Width="170px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True"  Height="19px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    <asp:Label ID="Label45" runat="server" Text="Date :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="dtpProductionDate" runat="server" Width="140px" BackColor="White"
                                        CssClass="date"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="16px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtDefectAllowPerHead" runat="server" Width="39px" BackColor="Yellow"
                                        ReadOnly="True" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtDefectAllow" runat="server" Width="29px" BackColor="Yellow" ReadOnly="True"
                                        Height="16px" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 353px; text-align: right;">
                                    <asp:Label ID="Label56" runat="server" Text="Process :"></asp:Label>
                                </td>
                                <td>           
                                    <asp:DropDownList ID="ddlEmpProcess" runat="server" Width="170px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    <asp:Label ID="Label52" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlLineId" runat="server" Width="144px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 353px; text-align: right;">
                                                    &nbsp;</td>
                                <td>
                   
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label53" runat="server" Text="Runing Operator :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtTotalOperator" runat="server" Width="140px" BackColor="White"></asp:TextBox>
                                </td>
                                <td style="width: 353px; text-align: right; height: 22px;">
                                </td>
                                <td style="height: 22px">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label54" runat="server" Text="Order Production :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtOrderProduction" runat="server" Width="140px" BackColor="White"></asp:TextBox>
                                </td>
                                <td style="width: 353px; text-align: right; height: 22px;">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Production  :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtProductionValue" runat="server" Width="140px" BackColor="White"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 353px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    <asp:Label ID="Label44" runat="server" Text="Defect  :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtDefectValue" runat="server" Width="140px" BackColor="White" Font-Bold="True"></asp:TextBox>
                                    &nbsp;
                                </td>
                                <td style="width: 353px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    <asp:Label ID="Label46" runat="server" Text="Hour :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtProductionHour" runat="server" Width="140px" BackColor="White"
                                        onkeydown="javascript:TextName_OnKeyDown(event)" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 353px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 635px; text-align: right">
                                    &nbsp;
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    &nbsp;
                                </td>
                                <td style="width: 353px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="60px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="60px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnDelete_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="60px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 118px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label51" runat="server" Text="Process :"></asp:Label>
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlEmpProcessId" runat="server" Width="151px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 102px;">
                                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White" placeHolder="CARD NO"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 118px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label49" runat="server" Text="From Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:TextBox ID="dtpPdFromDate" runat="server" Width="149px" BackColor="White" CssClass="date"
                                                        placeHolder="DATE"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 102px;">
                                                    <asp:Label ID="Label39" runat="server" Text="Employee ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White" placeHolder="EMPLOYEE ID"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 118px; text-align: right">
                                                    <asp:Label ID="Label50" runat="server" Text="To Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="dtpPdToDate" runat="server" Width="149px" BackColor="White" CssClass="date"
                                                        placeHolder="DATE"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 102px">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    &nbsp;
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
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>PROCESS ENTRY RESULT </legend></div>
                        <div id="divGridViewScroll" style="height: 300px; overflow: scroll">
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
                                                <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                                <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                                <asp:BoundField DataField="PROCESS_NAME" HeaderText="PROCESS" />
                                                <asp:BoundField DataField="PRODUCTION_DATE" HeaderText="DATE" />
                                                <asp:BoundField DataField="PRODUCTION_VALUE" HeaderText="PD" />
                                                <asp:BoundField DataField="DEFECT_VALUE" HeaderText="DEFECT" />
                                                <asp:BoundField DataField="PRODUCTION_HOUR" HeaderText="HOUR" />
                                                <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                                <asp:BoundField DataField="process_id" HeaderText="process_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
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
                        </div>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
  <%-- //new--%>
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
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                            <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" />
                            <asp:BoundField DataField="PROCESS_NAME" HeaderText="PROCESS" />
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
   <%--old--%>
   <%-- <fieldset>
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
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="PROCESS_NAME" HeaderText="PROCESS" />
                            <asp:BoundField DataField="EFFICIENCY_NO" HeaderText="EFFICIENCY" />
                            <asp:BoundField DataField="CAPACITY" HeaderText="CAPACITY" />
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
    </fieldset>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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
