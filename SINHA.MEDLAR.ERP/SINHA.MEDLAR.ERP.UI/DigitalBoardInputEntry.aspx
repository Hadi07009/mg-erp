<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="DigitalBoardInputEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.DigitalBoardInputEntry" %>

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
        $(window).load(function () { document.getElementById("<%= dtpInputDate.ClientID %>").focus(); }) 
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
        <legend>DIGITAL BOARD INPUT ENTRY</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>DIGITAL BOARD INPUT ENTRY</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 70px; height: 19px">
                                    <asp:Label ID="Label2" runat="server" Text="Date :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 164px;">
                                    <asp:TextBox ID="dtpInputDate" runat="server" Width="125px" BackColor="White" CssClass="date"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtDigitalBordInputEntryId" runat="server" Visible="False" Width="18px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; text-align: right; width: 103px;">
                                    <asp:Label ID="Label57" runat="server" Text="Target Efficiency :"></asp:Label>
                                </td>
                                <td style="height: 19px; text-align: left; width: 133px;">
                                    <asp:TextBox ID="txtTargetEfficiency" runat="server" Width="123px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; text-align: center; width: 61px;">
                                    <asp:Label ID="Label63" runat="server" Text="Hour :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtHour" runat="server" Width="125px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 70px; height: 19px">
                                    <asp:Label ID="Label4" runat="server" Text="Buyer :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 164px;">
                                    <asp:DropDownList ID="ddlBuyerId" runat="server" Height="22px" Width="126px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px; text-align: right; width: 103px;">
                                    <asp:Label ID="Label58" runat="server" Text="Target Per Hour :"></asp:Label>
                                </td>
                                <td style="height: 19px; text-align: left; width: 133px;">
                                    <asp:TextBox ID="txtTargetPerHour" runat="server" Width="123px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; text-align: center; width: 61px;">
                                    <asp:Label ID="Label66" runat="server" Text="Achive :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtAchive" runat="server" Width="125px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 70px; height: 19px">
                                    <asp:Label ID="Label6" runat="server" Text="Style :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 164px;">
                                    <asp:TextBox ID="txtStyle" runat="server" Width="125px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; text-align: right; width: 103px;">
                                    <asp:Label ID="Label59" runat="server" Text="Day Target :"></asp:Label>
                                </td>
                                <td style="height: 19px; text-align: left; width: 133px;">
                                    <asp:TextBox ID="txtDayTarget" runat="server" Width="123px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; text-align: center; width: 61px;">
                                    <asp:Label ID="Label65" runat="server" Text="Defect :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtDefect" runat="server" Width="125px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 70px; height: 19px">
                                    <asp:Label ID="Label3" runat="server" Text="SMV :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 164px;">
                                    <asp:TextBox ID="txtSmv" runat="server" Width="125px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; text-align: right; width: 103px;">
                                    <asp:Label ID="Label61" runat="server" Text="Line :"></asp:Label>
                                </td>
                                <td style="height: 19px; text-align: left; width: 133px;">
                                    <asp:DropDownList ID="ddlLineId" runat="server" Height="22px" Width="125px">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px; width: 61px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 70px; height: 19px">
                                    <asp:Label ID="Label7" runat="server" Text="Manpower :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 164px;">
                                    <asp:TextBox ID="txtManpower" runat="server" Height="16px" Width="125px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 103px; text-align: right;">
                                    <asp:Label ID="Label62" runat="server" Text="DHU Limit :"></asp:Label>
                                </td>
                                <td style="height: 19px; text-align: left; width: 133px;">
                                    <asp:TextBox ID="txtDhuLimit" runat="server" Width="123px"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 61px;">
                                </td>
                                <td style="height: 19px">
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 70px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 164px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 103px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; text-align: center; width: 133px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 61px;">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;" colspan="6">
                                    &nbsp;
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="6">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 117px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label51" runat="server" Text="Line :"></asp:Label>
                                                </td>
                                                <td style="width: 163px; height: 22px; text-align: left;">
                                                    <asp:DropDownList ID="ddlLineIdSearch" runat="server" Width="151px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 152px;">
                                                    <asp:Label ID="Label40" runat="server" Text="Buyer :"></asp:Label>
                                                </td>
                                                <td style="height: 22px; text-align: left;">
                                                    <asp:DropDownList ID="ddlBuyerIdSearch" runat="server" Width="151px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 117px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label49" runat="server" Text="From Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px; text-align: left;">
                                                    <asp:TextBox ID="dtpPdFromDate" runat="server" Width="149px" BackColor="White" CssClass="date"
                                                        placeHolder="DATE"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 152px;">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: left;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 117px; text-align: right">
                                                    <asp:Label ID="Label50" runat="server" Text="To Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; text-align: left;">
                                                    <asp:TextBox ID="dtpPdToDate" runat="server" Width="149px" BackColor="White" CssClass="date"
                                                        placeHolder="DATE"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 152px">
                                                    &nbsp;
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
                                <td style="text-align: left" colspan="6">
                                    <%--<asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>--%>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>ENTRY RESULT </legend>
                        <div id="divGridViewScroll" style="width: 1010px;  overflow: scroll">
                            <table style="width: 100%">
                                <tr>
                                    <td style="text-align: right;" colspan="3">
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
                                                <asp:BoundField DataField="DIGITAL_BOARD_INPUT_ENTRY_ID" HeaderText="ID" Visible="True" />
                                                <asp:BoundField DataField="INPUT_DATE" HeaderText="DATE" Visible="True" />
                                                <asp:BoundField DataField="BUYER_NAME" HeaderText="BUYER" />
                                                <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE" />
                                                <asp:BoundField DataField="LINE_NAME" HeaderText="LINE NAME" />
                                                <asp:BoundField DataField="HOUR_NO" HeaderText="HOUR" />
                                                <asp:BoundField DataField="ACHIVE" HeaderText="ACHIEVE" />
                                                <asp:BoundField DataField="DEFECT" HeaderText="DEFECT" />
                                                <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                            Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
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
                        </div>
                    </fieldset>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GridView2" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AllowSorting="True" EnableViewState="True" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvUnit2_PageIndexChanging" OnRowDataBound="OnRowDataBound2"
                        OnSelectedIndexChanged="OnSelectedIndexChanged2" CausesValidation="false" OnRowEditing="gvUnit2_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="DIGITAL_BOARD_INPUT_ENTRY_ID" HeaderText="ID" Visible="True" />
                            <asp:BoundField DataField="INPUT_DATE" HeaderText="DATE" Visible="True" />
                            <asp:BoundField DataField="BUYER_NAME" HeaderText="BUYER" />
                            <asp:BoundField DataField="STYLE_NO" HeaderText="STYLE" />
                            <asp:BoundField DataField="LINE_NAME" HeaderText="LINE NAME" />
                            <asp:BoundField DataField="HOUR_NO" HeaderText="HOUR" />
                            <asp:BoundField DataField="ACHIVE" HeaderText="ACHIEVE" />
                            <asp:BoundField DataField="DEFECT" HeaderText="DEFECT" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
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
