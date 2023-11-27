﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddWorkerSalarySetup.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddWorkerSalarySetup" %>

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
        $(window).load(function () { document.getElementById("<%= txtMedicalFee.ClientID %>").focus(); }) 
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
        <legend>ADD WORKER SALARY</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px"></td>

                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Medical Fee :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMedicalFee" runat="server" Width="236px" BackColor="White" Height="20px"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px">
                    <asp:Label ID="Label1" runat="server" Text="Convence Fee :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConvenceFee" runat="server" Height="20px" Width="236px"></asp:TextBox>
                </td>
                <td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px; height: 22px;">
                    <asp:Label ID="Label2" runat="server" Text="Food Fee :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtFoodFee" runat="server" Height="20px" Width="236px"></asp:TextBox>
                </td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px; height: 22px;">
                    <asp:Label ID="Label3" runat="server" Text="Extra Food Fee :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtExtraFoodFee" runat="server" Height="20px" Width="236px" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td style="height: 22px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px; height: 19px"></td>
                <td style="height: 19px"></td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 336px">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <td style="text-align: right; height: 19px" colspan="3">
            <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                <Columns>
                    <asp:TemplateField HeaderText="SL">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="ROWNUM_SL" HeaderText="SL" />--%>
                    <asp:BoundField DataField="MEDICAL_FEE" HeaderText="MEDICAL FEE" />
                    <asp:BoundField DataField="CONVENCE_FEE" HeaderText="CONVENCE FEE" />
                    <asp:BoundField DataField="FOOD_FEE" HeaderText="FOOD FEE" />
                    <asp:BoundField DataField="EXTRA_FOOD_FEE" HeaderText="EXTRA FOOD FEE" />

                  <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </fieldset>
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
