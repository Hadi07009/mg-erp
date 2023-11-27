<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ERP.Master" CodeBehind="ShiftOfficeTimeSetup.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ShiftOfficeTimeSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= dtpEffectDate.ClientID %>").focus(); }) 
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
        <legend>ADD Shift</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 339px">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtShiftId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Shift Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlShiftId" runat="server" Width="163px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="Label41" runat="server" Text="Effect Date :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dtpEffectDate" runat="server" Width="163px" Height="20px" Font-Bold="True"
                        BackColor="White" Style="margin-left: 0; margin-top: 0;" CssClass="date"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <strong>
                        <asp:Label ID="lblId2" runat="server" Text="Log In/Out :" Font-Bold="False"></asp:Label>
                    </strong>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtLogInTime" runat="server" Width="77px" Height="20px" Font-Bold="True"
                        Style="margin-left: 0px" BackColor="White"></asp:TextBox>
                    <asp:TextBox ID="txtLogOutTime" runat="server" Width="80px" Height="20px" Font-Bold="True"
                        BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <asp:Label ID="lblId3" runat="server" Text="Lunch Out/In :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtLunchOutTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" Style="margin-left: 17"></asp:TextBox>
                    <asp:TextBox ID="txtLunchInTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        onkeydown="javascript:TextName_OnKeyDown(event)" BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <strong>
                        <asp:Label ID="lblId4" runat="server" Text="General Out :" Font-Bold="False"></asp:Label>
                    </strong>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtGeneralOutTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        onkeydown="javascript:TextName_OnKeyDown(event)"
                        BackColor="White" Style="margin-left: 17"></asp:TextBox>
                </td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnSave_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SHIFT_TYPE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="shift_type_name" HeaderText="SHIFT NAME" />
                            <asp:BoundField DataField="LOG_IN_TIME" HeaderText="IN TIME" />
                            <asp:BoundField DataField="LOG_OUT_TIME" HeaderText="OUT TIME" />

                            <asp:BoundField DataField="LUNCH_OUT_TIME" HeaderText="LUNCH OUT TIME" />
                            <asp:BoundField DataField="LUNCH_IN_TIME" HeaderText="LUNCH IN TIME" />

                            <asp:BoundField DataField="OT_OUT_TIME" HeaderText="GENERAL OUT TTIME" />

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
                <td style="text-align: right; width: 339px">&nbsp;
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
