﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddIncrementLockEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddIncrementLockEntry" %>

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
        $(window).load(function () { document.getElementById("<%= txtIncrementYear.ClientID %>").focus(); }) 
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
        <legend>ADD INCREMENT LOCK INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>INCREMENT LOCK ENTRY</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 336px">
                                    <asp:Label ID="lblIncrement" runat="server" Text="Year :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIncrementYear" runat="server" Width="146px" BackColor="Yellow"></asp:TextBox>
                                    <asp:HiddenField runat ="server" ID="hfLockId" />
                                    <asp:HiddenField runat ="server" ID="hfBranchOfficeId" />
                                </td>
                                <td>
                                </td>
                            </tr>

                            <tr>
                                <td style="text-align: right; width: 336px">
                                    <asp:Label ID="lblIncrementYear" runat="server" Text="Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtIncrementMonth" runat="server" Width="146px" BackColor="Yellow"></asp:TextBox>
                                    
                                </td>
                                <td>
                                </td>
                            </tr>

                            <tr>
                <td style="text-align: right; width: 337px">
                    <asp:Label ID="lblId3" runat="server" Text="Employee Type :"></asp:Label>
                </td>
                <td style="width: 223px">
                    <asp:DropDownList ID="ddlEmpTypeId" runat="server" Width="150px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>

                            <%--<tr>
                                <td style="text-align: right; width: 336px; height: 19px">
                                    <asp:Label ID="Label2" runat="server" Text="Office :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                <asp:DropDownList ID="ddlBranchOfficeId" runat="server" Width="150px" Height="22px">
                                </asp:DropDownList>
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>--%>

                            <tr>
                                <td style="text-align: right; width: 336px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Lock Yn :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes" OnCheckedChanged="chkActiveYn_CheckedChanged" />
                                </td>
                                <td style="height: 19px">
                                    </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 336px; height: 19px">
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
                                <td style="text-align: right; width: 336px">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" 
                                        CssClass="styled-button-4" onclick="btnShow_Click"
                                        />
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
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvIncLock" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvIncLock_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowEditing="gvIncLock_RowEditing" BorderStyle="Solid">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="BRANCH_OFFICE_ID" HeaderText="OFFICE ID" Visible="True" />
                             <%--<asp:BoundField DataField="branch_office_name" HeaderText="OFFICE NAME" Visible="True" />--%>
                            <asp:BoundField DataField="INCREMENT_YEAR" HeaderText="YEAR" Visible="True" />

                            <asp:BoundField DataField="INCREMENT_MONTH" HeaderText="MONTH" Visible="True" />
                            <asp:BoundField DataField="EMPLOYEE_TYPE_NAME" HeaderText="EMPLOYEE TYPE" Visible="True" />

                            <asp:BoundField DataField="LOCK_SATUS" HeaderText="LOCK STATUS" />
                            <asp:BoundField DataField="EMPLOYEE_TYPE_ID" HeaderText="EMPLOYEE TYPE ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="LOCK_ID" HeaderText="LOCK_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
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