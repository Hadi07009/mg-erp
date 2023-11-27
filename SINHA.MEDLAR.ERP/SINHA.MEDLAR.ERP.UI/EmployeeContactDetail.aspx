<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeeContactDetail.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeContactDetail" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type='text/javascript'>
        $(document).ready(function () {
            $('#form1 input').keydown(function (e) {
                if (e.keyCode == 13) {
                    if ($(':input:eq(' + ($(':input').index(this) + 1) + ')').attr('type') == 'submit') {// check for submit button and submit form on enter press
                        return true;
                    }

                    $(':input:eq(' + ($(':input').index(this) + 1) + ')').focus();

                    return false;
                }

            });
        });
    </script>

    <script language="Javascript" type="text/javascript">
      <!--
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return true;
            }
            else {
                alert('Please Enter Only Number values.');
                return false;

            }
        }
      //-->
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
                document.getElementById('<%= btnSearchEmployee.ClientID %>').click();
            }
        }
    </script>
    <script type="text/javascript">
        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;
            else {
                alert('Please Enter Only Character values.');
                return false;
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

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <table class="style1">
            <tr>
                <td style="width: 250px; text-align: right; height: 22px;">
                    <asp:Label ID="Label4" runat="server" Text="Head Office :"></asp:Label>
                </td>
                <td style="width: 163px; height: 22px;">
                    <asp:DropDownList ID="ddlHeadOfficeId" runat="server" Width="240px" Height="22px" AutoPostBack="True" OnSelectedIndexChanged="ddlBranchOfficeId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px; width: 66px;">
                    &nbsp;</td>
                <td style="height: 22px; text-align: right; width: 69px;">
                    &nbsp;</td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right; height: 22px;">
                    <asp:Label ID="Label1" runat="server" Text="Branch :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px; height: 22px;">
                    <asp:DropDownList ID="ddlBranchOfficeId" runat="server" Width="240px" Height="22px" AutoPostBack="True" OnSelectedIndexChanged="ddlDesignationId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px; width: 66px;">
                    &nbsp;
                </td>
                <td style="height: 22px; text-align: right; width: 69px;">
                    &nbsp;</td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="Label3" runat="server" Text="Designation :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlDesignationId" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="Label2" runat="server" Text="Name :"></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:TextBox ID="txtEmpName" runat="server" Width="236px" BackColor="White" placeHolder="EMPLOYEE NAME"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td style="width: 66px">
                    <asp:Button ID="btnSearchEmployee" runat="server" Height="25px" Text="Search" CssClass="styled-button-4"
                        Width="55px" OnClick="btnSearchEmployee_Click" />
                    </td>
                <td style="text-align: right; width: 69px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </td>
                <td style="width: 163px">
                    &nbsp;</td>
                <td style="width: 66px">
                    &nbsp;</td>
                <td style="text-align: right; width: 69px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td style="width: 250px; text-align: right">
                    &nbsp;</td>
                <td style="width: 163px">
                    <asp:Button ID="btnSave" runat="server" Height="25px" Text="Save" CssClass="styled-button-4"
                        Width="55px" OnClick="btnSave_Click" />
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
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" OnSorting="gvEmployeeList_Sorting" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowCommand="gvEmployeeList_RowCommand" OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" style="margin-top: 14px">
                        <Columns>
                        
                            <asp:BoundField DataField="SL" HeaderText="Sl" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="Card No" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="Id" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="Name" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="Designation" />
                            <asp:TemplateField HeaderText="Email" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("EMAIL_ADDRESS")%> ' Width="200" Height="30"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Phone/Cell No" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtPhoneNo" runat="server" Text='<%#Eval("MOBILE_NO")%> ' Width="120" Height="30"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BRANCH_OFFICE_NAME" HeaderText="BRANCH NAME" />
                            <%--<asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                           <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="EMPLOYEE ID" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
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
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
