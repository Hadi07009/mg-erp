<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddProcess.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddProcess" %>

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
        $(window).load(function () { document.getElementById("<%= txtProcessName.ClientID %>").focus(); }) 
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
        <legend>ADD PROCESS INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: right;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTopId" runat="server" Width="72px" BackColor="Yellow" Height="20px"></asp:TextBox>
                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td style="width: 102px; text-align: right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="Item Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProcessId" runat="server" Width="238px" Height="22px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlProcessId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="width: 102px; text-align: right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Section Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSectionProcessId" runat="server" Width="238px" Height="22px"
                        AutoPostBack="true" OnSelectedIndexChanged="ddlSectionProcessId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="width: 102px; text-align: right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Category :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCategoryId" runat="server" Width="238px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 102px; text-align: right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Process :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProcessName" runat="server" Width="236px" BackColor="White" Height="20px"></asp:TextBox>
                </td>
                <td style="width: 102px; text-align: right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px">
                    <asp:Label ID="lblMachine" runat="server" Text="Machine Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlMachineId" runat="server" Width="238px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 102px; text-align: right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px">
                    <asp:Label ID="lblMachine0" runat="server" Text="Process Code :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtProcessCode" runat="server" Width="72px" BackColor="White" Height="20px"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td style="width: 102px; text-align: right">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px; height: 19px">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="SMV :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtProcessTime" runat="server" Width="72px" BackColor="White" Height="20px"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                    <asp:TextBox ID="txtTargetValue" runat="server" Width="72px" BackColor="Yellow" Height="20px"
                        ReadOnly="True"></asp:TextBox>
                    <asp:TextBox ID="txtStitchLength" runat="server" Width="72px" BackColor="White" Height="20px"
                        Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtHigestCapacity" runat="server" Width="37px" BackColor="White"
                        Height="22px" onkeydown="javascript:TextName_OnKeyDown(event)" Visible="False"></asp:TextBox>
                </td>
                <td style="height: 19px; width: 102px; text-align: right;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 280px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 102px; text-align: right;">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: center; height: 19px" colspan="3">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" CssClass="styled-button-4"
                        Width="66px" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" CssClass="styled-button-4"
                        Width="66px" OnClick="btnShow_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: center; height: 19px" colspan="3">
                    <fieldset>
                        <legend>SEARCH CRITERIA</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right; width: 278px;" class="style4">
                                    <asp:Label ID="Label34" runat="server" Text="Process Name :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="width: 163px; height: 22px;">
                                    <asp:TextBox ID="txtProcessNameSearch" runat="server" Width="149px" 
                                        BackColor="White"></asp:TextBox>
                                </td>
                                <td style="height: 22px; width: 66px;">
                                    <asp:Button ID="btnSearchProcessRecord" runat="server" Height="25px" Text="Search"
                                        Width="55px" CssClass="styled-button-4" 
                                        onclick="btnSearchProcessRecord_Click" />
                                    &nbsp;
                                </td>
                                <td style="height: 22px; text-align: right; width: 69px;">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <div id="divGridViewScroll" style="height: 300px; overflow: scroll">
            <td style="text-align: right; height: 19px" colspan="3">
                <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                    GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                    AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                    OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                    OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                    <Columns>
                        <asp:BoundField DataField="TOP_PROCESS_ID" HeaderText="ID" />
                        <asp:BoundField DataField="MAIN_PROCESS_NAME" HeaderText="ITEM" />
                        <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" />
                        <asp:BoundField DataField="CATEGORY_NAME" HeaderText="CATEGORY" />
                        <asp:BoundField DataField="TOP_PROCESS_NAME" HeaderText="PROCESS" />
                        <asp:BoundField DataField="PROCESS_CODE" HeaderText="CODE" />
                        <asp:BoundField DataField="PROCESS_TIME" HeaderText="SMV" ItemStyle-Width="10" />
                        <asp:BoundField DataField="TARGET_VALUE" HeaderText="VALUE" ItemStyle-Width="10" />
                        <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                    Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </div>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <%--  <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" ClientSelectionMode="SingleRow" GridLines="None"
                        AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="gvEmployeeList_OnRowEditing"
                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="gvEmployeeList_OnRowDataBound"
                        CausesValidation="false" OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE" />
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
    </fieldset>--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <%-- <table class="style1">
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
    </table>--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
