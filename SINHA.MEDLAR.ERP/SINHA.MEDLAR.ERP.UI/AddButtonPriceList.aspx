<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="AddButtonPriceList.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.AddButtonPriceList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">



        $(document).ready(function () {

            $('input:text:first').focus();
            $('input:text,select').bind("keydown", function (e) {
                var n = $("input:text,select").length;
                if (e.which == 13) { //Enter key

                    e.preventDefault(); //Skip default behavior of the enter key

                    var nextIndex = $('input:text,select').index(this) + 1;

                    if (nextIndex < n)

                    { $('input:text,select')[nextIndex].focus(); }

                    else {

                        $('input:text,select')[nextIndex - 1].blur();

                        $('#btnADD').click();

                    }

                }

            });
        
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
        function isDelete() {

            return confirm("Do you want to delete this row ?");

        }
    </script>
    <%-- <script language="javascript">
        $(window).load(function () { document.getElementById("<%= ddlSupplierId.ClientID %>").focus(); }) 
    </script>--%>
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
        <legend>BUTTON PRICE LIST</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; height: 18px;" colspan="5">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>



            <tr>
                <td style="text-align: right; width: 341px; height: 24px;">
                    <asp:Label ID="Label1" runat="server" Text="Supplier :" Font-Bold="False"></asp:Label>
                </td>
                <td style="height: 24px; width: 220px;">
                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="173px" Height="23px" BackColor="#999999">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" CssClass="styled-button-4" Height="22px"
                        OnClick="btnSearch_Click" Text="..." Width="30px" />
                </td>
                <td style="height: 24px">&nbsp;
                </td>
            </tr>



            <tr>
                <td style="text-align: justify; width: 341px">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
                <td style="text-align: justify; width: 220px">&nbsp;</td>
                <td style="text-align: justify; width: 132px">&nbsp;</td>
                <td style="width: 92px">&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="5">
                    <asp:GridView ID="gvButtonPriceList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        DataKeyNames="BUTTON_PRICE_LIST_ID" EnableViewState="true"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvButtonPriceList_PageIndexChanging"
                        OnRowDeleting="gvButtonPriceList_RowDeleting" AutoPostBack="true"
                        OnRowDataBound="gvButtonPriceList_OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>

                            <asp:TemplateField HeaderText="PARTICULARS" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtParticulars" runat="server" Text='<%#Eval("PARTICULARS")%> '
                                        Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="COLOR" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlColorId" DataTextField="COLOR_NAME" DataValueField="COLOR_ID"
                                        runat="server" Width="130">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="LINE" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlLineId" DataTextField="LINE_NAME" DataValueField="LINE_ID"
                                        runat="server" Width="130">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ART" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlArtId" DataTextField="ART_NO" DataValueField="ART_ID"
                                        runat="server" Width="130">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="M.UNIT" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlMeasurementId" DataTextField="MEASUREMENT_NAME" DataValueField="MEASUREMENT_ID "
                                        runat="server" Width="130">
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="RATE US$" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRateUs" runat="server" Text='<%#Eval("PRICE_RATE")%> ' Width="100"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ID" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtButtonPriceListId" runat="server" Text='<%#Eval("BUTTON_PRICE_LIST_ID")%> '
                                        Width="60"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>


                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                <ItemTemplate>
                                    <asp:Button ID="btnSub" runat="server" Text="Delete"
                                        Width="45px" CommandName="Delete" OnClientClick="return isDelete();"
                                        CssClass="styled-button-4" Height="25px" Visible="true" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;" colspan="5">
                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add " CssClass="styled-button-4"
                        Width="66px" OnClick="btnAdd_Click" Style="margin-left: 0" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" CssClass="styled-button-4"
                        Width="66px" OnClick="btnSave_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 341px">&nbsp;
                </td>
                <td style="text-align: right; width: 220px">&nbsp;</td>
                <td style="text-align: right; width: 132px">&nbsp;</td>
                <td style="width: 92px">&nbsp;
                </td>
                <td>&nbsp;
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
