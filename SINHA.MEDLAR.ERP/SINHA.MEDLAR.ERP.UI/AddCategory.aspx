﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddCategory.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddCategory" %>

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
        $(window).load(function () { document.getElementById("<%= txtFrontCatagoryName.ClientID %>").focus(); }) 
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
        <legend>ADD CATEGORY INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFrontCatagoryId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Item Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlProcessId" runat="server" Width="238px" Height="22px" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlProcessId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Section Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSectionProcessId" runat="server" Width="238px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Category Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFrontCatagoryName" runat="server" Width="236px" BackColor="White"
                        Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Sub Category :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtSubCatagoryName" runat="server" Width="236px" BackColor="White"
                        Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                    &nbsp;
                </td>
                <td style="height: 19px">
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
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" CssClass="styled-button-4"
                        Width="66px" OnClick="btnDelete_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
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
                    <asp:BoundField DataField="CATEGORY_ID" HeaderText="ID" />
                    <asp:BoundField DataField="main_process_name" HeaderText="ITEM" />
                    <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION NAME" />
                    <asp:BoundField DataField="CATEGORY_NAME" HeaderText="CATEGORY NAME" />
                    <asp:BoundField DataField="SUB_CATEGORY_NAME" HeaderText="SUB CATEGORY NAME" />
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
