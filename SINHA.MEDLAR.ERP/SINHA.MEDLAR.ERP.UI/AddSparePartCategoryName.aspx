<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="AddSparePartCategoryName.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.AddSparePartCategoryName" %>

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
        $(window).load(function () { document.getElementById("<%= txtSparePartCategoryName.ClientID %>").focus(); }) 
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
        <legend>ADD SPARE PART INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 238px;">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td style="width: 318px">
                    <asp:TextBox ID="txtSparePartCategoryId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="22px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 238px;">
                    <asp:Label ID="lblProductCataroy3" runat="server" Text=" Equipement Name :"></asp:Label>
                </td>
                <td style="width: 318px">
                    <asp:DropDownList ID="ddlEquipementId" runat="server" Width="238px" Height="22px"
                        BackColor="#CCCCCC" AutoPostBack="true" OnSelectedIndexChanged="ddlEquipementId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>
                    <fieldset>
                        <legend>SEARCH PART NO </legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 787px; text-align: right; height: 27px;">
                                    <asp:Label ID="Label9" runat="server" Text="Part No :"></asp:Label>
                                </td>
                                <td style="width: 458px; height: 27px;">
                                    <asp:TextBox ID="txtPartNo" runat="server" Height="21px" Width="124px"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:Button ID="btnSearchRecord" runat="server" CssClass="styled-button-4" Height="22px"
                                        Text="...." Width="36px" OnClick="btnSearchRecord_Click" />
                                </td>
                                
                               
                            </tr>
                            </table>
                    </fieldset>

                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 238px;">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Part Name :"></asp:Label>
                </td>
                <td style="width: 318px">
                    <asp:DropDownList ID="ddlSparePartId" runat="server" Width="238px" Height="22px"
                        AutoPostBack="true" BackColor="#CCCCCC" OnSelectedIndexChanged="ddlSparePartId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 238px;">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Category Name :"></asp:Label>
                </td>
                <td style="width: 318px">
                    <asp:TextBox ID="txtSparePartCategoryName" runat="server" Width="236px" BackColor="White"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px; width: 238px;">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Part No :"></asp:Label>
                </td>
                <td style="height: 19px; width: 318px;">
                    <asp:TextBox ID="txtSparePartCategoryNo" runat="server" Width="236px" BackColor="White"
                        Font-Size="Small"></asp:TextBox>
                </td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px; width: 238px;">
                    <asp:Label ID="lblProductCataroy6" runat="server" Text="Item No :"></asp:Label>
                </td>
                <td style="height: 19px; width: 318px;">
                    <asp:TextBox ID="txtItemNo" runat="server" Width="236px" BackColor="White"
                        Font-Size="Small"></asp:TextBox>
                </td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; height: 21px; width: 238px;">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Quantity/Engine :"></asp:Label>
                </td>
                <td style="height: 21px; width: 318px;">
                    <asp:TextBox ID="txtQuantity" runat="server" Width="72px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        MaxLength="300" Font-Size="Small" Font-Bold="True"></asp:TextBox>
                    &nbsp;
                </td>
                <td style="height: 21px">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px; width: 238px;">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="Upload File :"></asp:Label>
                    &nbsp;
                </td>
                <td style="height: 19px; width: 318px;">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    &nbsp;
                </td>
                <td style="height: 19px">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px; width: 238px;">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="File Name :"></asp:Label>
                </td>
                <td style="height: 19px; width: 318px;">
                    <asp:TextBox ID="txtFileName" runat="server" Width="236px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                </td>
                <td style="height: 19px">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 238px; height: 19px">&nbsp;
                </td>
                <td style="height: 19px; width: 318px;">&nbsp;
                </td>
                <td style="height: 19px">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 238px">&nbsp;
                </td>
                <td style="width: 318px">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="66px"
                        CssClass="styled-button-4" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="66px" CssClass="styled-button-4"
                        OnClick="btnView_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        DataKeyNames="SPARE_PART_CATEGORY_ID,BRANCH_OFFICE_NAME"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowDeleting="gvUnit_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="SPARE_PART_CATEGORY_ID" HeaderText="ID" ItemStyle-Width="30px" />
                            <asp:BoundField DataField="SPARE_PART_NAME" HeaderText="PART NAME" />
                            <asp:BoundField DataField="SPARE_PART_CATEGORY_NAME" HeaderText="CATEGORY NAME" />
                            <asp:BoundField DataField="SPARE_PART_CATEGORY_NO" HeaderText="PART NO" ItemStyle-Width="90px" />
                            <asp:BoundField DataField="ITEM_NO" HeaderText="ITEM NO" ItemStyle-Width="80px" />
                            <asp:BoundField DataField="QUANTITY_PER_ENGINEE" HeaderText="QTY" ItemStyle-Width="30px" />
                            <asp:BoundField DataField="FILE_NAME" HeaderText="PARTS CATALOG" ItemStyle-Width="120px" />
                              <asp:BoundField DataField="BRANCH_OFFICE_NAME" HeaderText="OFFICE" ItemStyle-Width="120px" />
                          <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>

                           <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                                        AlternateText="Delete"
                                                                        Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                                        Height="25px" Visible="true" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 238px">&nbsp;
                </td>
                <td style="width: 318px">&nbsp;
                </td>
                <td>&nbsp;
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
