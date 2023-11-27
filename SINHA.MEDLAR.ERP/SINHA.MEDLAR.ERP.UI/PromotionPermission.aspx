﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="PromotionPermission.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PromotionPermission" %>

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
       <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtPromotionYear.ClientID %>").focus(); }) 
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
        <legend>PERMISSION INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>PERMISSION ENTRY</legend>
                        <table style="width: 100%">
                            <%--<tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="Label2" runat="server" Text="Id:" Visible="false" Height="0px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPermissionId" runat="server" Width="0px" Height="0px" BackColor="Yellow" ReadOnly="true" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>--%>                    
                            <tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="Label1" runat="server" Text="Year :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPromotionYear" runat="server" Width="144px" BackColor="#FFFF66"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>                       
                            <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblProductCataroy" runat="server" Text="Month :"></asp:Label>
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                                <asp:DropDownList ID="ddlMonthId" runat="server" Width="150px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 74px; text-align: right;">&nbsp;
                                            </td>
                                            <td>
                                               

                                            </td>
                                        </tr>

                            <%--<tr>
                                            <td style=" text-align: right;">
                                    <asp:Label ID="Label3" runat="server" Text="Employee Type :"></asp:Label>
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                                <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="150px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 74px; text-align: right;">&nbsp;</td>
                                            <td>
                                               

                                                &nbsp;</td>
                                        </tr>--%>

                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="lblProductCataroy1" runat="server" Text="Effective Date :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 292px; text-align: left;">
                                    <asp:TextBox ID="dtpEffectiveDate" runat="server" Width="144px" BackColor="White" CssClass="date"></asp:TextBox>
                                            </td>
                                            <td style="width: 74px; text-align: right;">&nbsp;
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Lock Yn :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes" OnCheckedChanged="chkActiveYn_CheckedChanged" />
                                </td>
                                <td style="height: 19px">
                                    </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
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
                                <td style="text-align: right; width: 332px">
                                    &nbsp;
                                    <asp:HiddenField ID="hf_lock_id" runat="server" />
                                    <asp:TextBox ID="txtPermissionId" runat="server" Width="0px" Height="0px" BackColor="Yellow" ReadOnly="true" Visible="false"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" 
                                        CssClass="styled-button-4" onclick="btnShow_Click"/>
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
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
                    <asp:GridView ID="gvPromossionPermission" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowEditing="gvPromossionPermission_RowEditing" BorderStyle="Solid">
                        <Columns>
                            
                            <asp:BoundField DataField="permission_id" HeaderText="Id" Visible="True" />
                            <asp:BoundField DataField="promotion_year" HeaderText="Promossion Year" Visible="True" />
                             <asp:BoundField DataField="month_name" HeaderText="Promotion Month" Visible="True" />
                             <%--<asp:BoundField DataField="employee_type_name" HeaderText="Employee Type" Visible="True" />--%>
                            <asp:BoundField DataField="effective_date" HeaderText="E.Date" Visible="True" />
                            <asp:BoundField DataField="locked_yn" HeaderText="Locked Y/N" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>                          
                            <asp:BoundField DataField="promotion_month" HeaderText="to month id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                             <%--<asp:BoundField DataField="employee_type_id" HeaderText="Type" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />--%>
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
