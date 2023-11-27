<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="AddSalaryDay.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddSalaryDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtWorkingDay.ClientID %>").focus(); }) 
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
        <legend>ADD SALARY DAY </legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 15px;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEidId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 22px;">
                    <asp:Label ID="lblId0" runat="server" Text="Year :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtSalaryYear" runat="server" Width="105px" Height="20px" Font-Bold="True"
                        MaxLength="4" BackColor="Yellow"></asp:TextBox>
                    <asp:TextBox ID="txtSalaryMonth" runat="server" Width="63px" Height="20px" Font-Bold="True"
                        MaxLength="4" BackColor="Yellow"></asp:TextBox>
                </td>
                <td style="height: 22px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 22px;">
                    <asp:Label ID="lblId1" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="174px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 22px;">
                    <asp:Label ID="lblId2" runat="server" Text="Section :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="174px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Working Day :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtWorkingDay" runat="server" Width="170px" BackColor="White" CssClass="date"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
                </tr>
                <tr>
                    <td style="text-align: right; width: 279px">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="87px"
                            CssClass="styled-button-4" OnClick="btnClear_Click" />
                        <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="87px" OnClick="btnSave_Click"
                            CssClass="styled-button-4" />
                        <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="87px" 
                            CssClass="styled-button-4" onclick="btnShow_Click" />
                    </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="gvEmployeeList_OnRowEditing"
                        CausesValidation="false" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="gvEmployeeList_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="EID_ID" HeaderText="SL" />
                            <asp:BoundField DataField="EID_NAME" HeaderText="EID NAME" />
                            <asp:BoundField DataField="EID_YEAR" HeaderText="EID YEAR" />
                            <asp:BoundField DataField="EID_DATE" HeaderText="EID DATE" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
