<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="AddCartoonPriceList.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.AddCartoonPriceList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
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
    <script type="text/javascript">
        $(window).load(function () { document.getElementById("<%= ddlSupplierName.ClientID %>").focus(); }) 
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
        <legend>CARTOON PRICE LIST</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 21px;" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
                <td style="text-align: left; height: 21px;"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 20px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label3" runat="server" Text="Supplier Name :"></asp:Label>
                    &nbsp;
                </td>
                <td style="height: 20px;">
                    <asp:DropDownList ID="ddlSupplierName" runat="server" Height="21px" Width="239px">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click"
                        CssClass="styled-button-4" />
                </td>
                <td style="height: 20px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px" colspan="3">
                    <fieldset>
                        <legend>CARTOON PRICE LIST ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td>
                                    <asp:GridView ID="gvCartoonPriceList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        EnableViewState="true"
                                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                        OnRowDataBound="gvCartoonPriceList_OnRowDataBound"
                                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvCartoonPriceList_PageIndexChanging"
                                        CausesValidation="false" DataKeyNames="CARTOON_ID" OnRowDeleting="gvCartoonPriceList_OnRowDeleting"
                                        OnSelectedIndexChanged="gvCartoonPriceList_SelectedIndexChanged" OnRowCommand="gvCartoonPriceList_RowCommand"
                                       >
                                        <Columns>

                                            <asp:TemplateField HeaderText="PLY" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPlyId" runat="server" Text='<%#Eval("CARTOON_PLY_ID")%> '
                                                        Font-Bold="true" Width="120"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LENGTH" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtLength" runat="server" Text='<%#Eval("CARTOON_LENGTH")%> '
                                                        Font-Bold="true" Width="120"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="WIDTH" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtWidth" runat="server" Text='<%#Eval("CARTOON_WIDTH")%> '
                                                        Font-Bold="true" Width="120"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HEIGHT" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtHeight" runat="server" Text='<%#Eval("CARTOON_HEIGHT")%> '
                                                        Font-Bold="true" Width="120"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="PERTICULARS" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtPerticular" runat="server" Text='<%#Eval("CARTOON_PERTICULAR")%> '
                                                        Font-Bold="true" Width="130"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="M.UNIT" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="ddlMesurementId" DataTextField="MEASUREMENT_NAME" DataValueField="MEASUREMENT_ID"
                                                        runat="server" Width="120">
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RATE/PC" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtRateId" runat="server" Text='<%#Eval("CARTOON_RATE")%> '
                                                        Font-Bold="true" Width="120"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCartoonPriceId" runat="server" Text='<%#Eval("CARTOON_ID")%> '
                                                        Width="30"
                                                        DataField="CARTOON_ID" BackColor="Yellow" ReadOnly="true" SortExpression="CARTOON_ID"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnSub" runat="server" Text="Delete"
                                                        Width="50px" CommandName="Delete" OnClientClick="return isDelete();"
                                                        CssClass="styled-button-4" Height="25px" Visible="true" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </fieldset>

                    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                    <script src="js/jquery.js" type="text/javascript"></script>
                    <script type="text/javascript">
                        $(document).ready(function () {

                            //            $('[id$=txtPO]').focus();
                            $('input:text,select').bind("keydown", function (e) {
                                var n = $("input:text,select").length;
                                if (e.which == 13) { //Enter key

                                    e.preventDefault(); //Skip default behavior of the enter key

                                    var nextIndex = $('input:text,select').index(this) + 1;

                                    if (nextIndex < n)

                                    { $('input:text,select')[nextIndex].focus(); }

                                    else {

                                        $('input:text,select')[nextIndex - 1].blur();

                                        $('[id$=btnAdd]').click();

                                    }

                                }

                            });
                        });

                    </script>

                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="3">&nbsp;&nbsp;
                    <asp:Button ID="btnAdd" runat="server" CssClass="styled-button-4" Height="31px"
                        Text="Add Row" Width="66px" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnSave" runat="server" CssClass="styled-button-4" Height="31px"
                        OnClick="btnSave_Click" Text="Save" Width="66px" />
                    <asp:Button ID="btnShow" runat="server" CssClass="styled-button-4" Height="31px"
                        OnClick="btnShow_Click" Text="Show" Width="66px" />
                </td>
            </tr>
        </table>
    </fieldset>
    <%--  <fieldset>
        <legend>CARTOON PRICE LIST ENTRY RECORD</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: right;" colspan="5">
                    <asp:GridView ID="gvViewRecord" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnSelectedIndexChanged="OnSelectedIndexChanged" >
                        <Columns>
                            <asp:BoundField DataField="CARTOON_ID" HeaderText="ID" />
                            <asp:BoundField DataField="CARTOON_PLY_ID" HeaderText="PLY" />
                            <asp:BoundField DataField="CARTOON_LENGTH" HeaderText="LENGTH" />
                            <asp:BoundField DataField="CARTOON_WIDTH" HeaderText="WIDTH" />
                            <asp:BoundField DataField="CARTOON_HEIGHT" HeaderText="HEIGHT" />
                            <asp:BoundField DataField="CARTOON_PERTICULAR" HeaderText="PERTICULAR" />
                            <asp:BoundField DataField="MESUREMENT_NAME" HeaderText="M.Unit"/>
                            <asp:BoundField DataField="CARTOON_RATE" HeaderText="RATE/PC" />
                            <asp:BoundField DataField="SUPPLIER_NAME" HeaderText="SUPPLIER" />
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
                <td style="text-align: right; width: 239px">&nbsp;
                </td>
                <td style="width: 240px">&nbsp;
                </td>
                <td style="width: 155px">&nbsp;
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </fieldset>--%>
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
