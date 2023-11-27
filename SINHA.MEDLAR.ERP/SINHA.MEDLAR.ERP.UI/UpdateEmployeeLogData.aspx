<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="UpdateEmployeeLogData.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.UpdateEmployeeLogData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true
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
        <legend>UPDATE LOG DATA</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 16px;" colspan="5">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 86px; height: 22px;">
                    <asp:Label ID="lblId" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td style="height: 22px; width: 286px;">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="152px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px; text-align: right; width: 67px;">
                    <asp:Label ID="lblId0" runat="server" Text="Section :"></asp:Label>
                </td>
                <td style="height: 22px; width: 155px;">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="152px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px">
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 86px">
                    <asp:Label ID="lblId1" runat="server" Text="Date :"></asp:Label>
                </td>
                <td style="width: 286px">
                    <asp:TextBox ID="txtWorkingDay1" runat="server" Width="150px" Height="20px" CssClass="date"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 67px;">
                    <asp:Label ID="lblId2" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td style="width: 155px">
                    <asp:DropDownList ID="ddlUnitId0" runat="server" Width="152px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="5">
                    <fieldset>
                        <legend>LOG DATA ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right; width: 119px; height: 16px;">
                                    <asp:Label ID="lblId3" runat="server" Text="Log In :"></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: left; height: 16px;">
                                    <asp:TextBox ID="txtLogInHour" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                </td>
                                <td rowspan="8">
                                    <div style="width: 500px; height: 170px; overflow: scroll;">
                                        <asp:GridView ID="gvEmployeeLogList" runat="server" AutoGenerateColumns="false" CssClass="mGrid"
                                            HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White" OnRowDataBound="OnRowDataBound"
                                            OnRowEditing="OnRowEditing" PagerStyle-CssClass="pgr">
                                            <Columns>
                                                <asp:BoundField DataField="CARD_NO" HeaderText="CARD_NO" />
                                                <asp:BoundField DataField="LOGIN_DATE" HeaderText="LOGIN_DATE" />
                                                <asp:BoundField DataField="LOGIN_TIME" HeaderText="LOGIN TIME" />
                                                <asp:BoundField DataField="LOG_OUT_TIME" HeaderText="LOGOUT TIME" />
                                            </Columns>
                                            <AlternatingRowStyle BackColor="White" />
                                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                            <SelectedRowStyle BackColor="Blue" ForeColor="White" />
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 119px">
                                    &nbsp;
                                </td>
                                <td style="width: 105px; text-align: left;">
                                    <asp:TextBox ID="txtLogInMinute" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 119px;">
                                    <asp:Label ID="lblId4" runat="server" Text="Lunch Out :"></asp:Label>
                                </td>
                                <td style="width: 105px; text-align: left;">
                                    <asp:TextBox ID="txtLunchOutHour" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 119px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 105px; text-align: left;">
                                    <asp:TextBox ID="txtLunchOutMinute" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 119px; height: 19px">
                                    <asp:Label ID="lblId5" runat="server" Text="Lunch In :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 105px; text-align: left;">
                                    <asp:TextBox ID="txtLunchInHour" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 119px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 105px; text-align: left;">
                                    <asp:TextBox ID="txtLunchInMinute" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 119px; height: 19px">
                                    <asp:Label ID="lblId6" runat="server" Text="Final Out :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 105px; text-align: left;">
                                    <asp:TextBox ID="txtFinalOutHour" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 119px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 105px; text-align: left;">
                                    <asp:TextBox ID="txtFinalOutMinute" runat="server" Width="77px" Height="20px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <tr>
                        </tr>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 86px">
                    &nbsp;
                </td>
                <td style="width: 286px">
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="87px" />
                </td>
                <td style="text-align: right; width: 67px;">
                    &nbsp;
                </td>
                <td style="width: 155px">
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
