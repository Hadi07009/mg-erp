<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="AddLeaveEncashmentSetup.aspx.cs" EnableEventValidation="false" Inherits="SINHA.MEDLAR.ERP.UI.AddLeaveEncashmentSetup" %>

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
        <legend>ADD LEAVE ENCASHMENT SETUP</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 18px;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblId0" runat="server" Text="Leave Year : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLeaveYear" runat="server" Width="152px"
                        OnTextChanged="txtLeaveYear_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblId" runat="server" Text="Limit Date : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLimitDate" runat="server" Width="152px" BackColor="White" 
                        CssClass="date" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>


             <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblEmployeeType" runat="server" Text="Employee Type : "></asp:Label>
                </td>
                <td>
                                                    <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="156px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Staff"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Worker"></asp:ListItem>
                                                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
          
            <tr>
                <td style="text-align: right; width: 339px; height: 22px;">
                    <asp:Label ID="lblId2" runat="server" Text="Deduct Holiday : "></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtDeductHolyday" runat="server" Width="152px" BackColor="White" 
                        CssClass="date" ></asp:TextBox>
                </td>
                <td style="height: 22px">
                    &nbsp;
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblId1" runat="server" Text="Actual Holiday : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtActualHoliday" runat="server" Width="152px" BackColor="White" 
                        CssClass="date" Height="20px" ReadOnly="true" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            
                    
            <tr>
                <td style="text-align: right; width: 339px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
          
            <tr>
                <td style="text-align: right; width: 339px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left; " colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" 
                        Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="LEAVE_YEAR" HeaderText="YEAR" />
                            <asp:BoundField DataField="LIMIT_DATE" HeaderText="LIMIT DATE" />
                            <asp:BoundField DataField="ACTUAL_HOLIDAY" HeaderText="ACTUAL HOLIDAY" />
                            <asp:BoundField DataField="DEDUCT_HOLIDAY" HeaderText="DEDUCT HOLIDAY" />
                            <asp:BoundField DataField="EMPLOYEE_TYPE_NAME" HeaderText="EMPLOYEE TYPE" />
                           
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
            <tr>
                <td style="text-align: right; width: 339px">
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
