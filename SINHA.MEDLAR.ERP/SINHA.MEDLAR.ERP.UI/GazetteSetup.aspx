<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="GazetteSetup.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.GazetteSetup" %>

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
        $(window).load(function () { document.getElementById("<%= txtGazetteYear.ClientID %>").focus(); }) 
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
        <legend>Gazette Information</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>Gazette Setup</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
                                </td>
                                <td style="width: 239px">
                                    <asp:TextBox ID="txtGazetteYear" runat="server" Width="141px" BackColor="White"></asp:TextBox>
                                </td>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    <asp:Label ID="Label2" runat="server" Text="Month :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 208px;">
                                    <asp:DropDownList ID="ddlGazetteMonth" runat="server" Width="150px" Height="22px">
                                     </asp:DropDownList>
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 1px;">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 100px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Analysis Yn :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 239px;">
                                    <asp:CheckBox ID="chkAnalysisYn" runat="server" Text="Yes" OnCheckedChanged="chkActiveYn_CheckedChanged" />
                                </td>
                                <td style="text-align: right; width: 100px; height: 19px">
                                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Analysis Lock :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 226px;">
                                    <asp:CheckBox ID="chkAnalysisLock" runat="server" Text="Yes" OnCheckedChanged="chkLockYn_CheckedChanged" />
                                </td>
                                
                            </tr>
                            <tr>
                              <td style="text-align: right; width: 100px; height: 19px">
                                   <asp:Label ID="lblProductCataroy3" runat="server" Text="Finalized Yn :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 239px;">
                                    <asp:CheckBox ID="chkFinalizedYn" runat="server" Text="Yes" OnCheckedChanged="chkActiveYn_CheckedChanged" />
                                </td>
                              
                                  <td style="text-align: right; width: 100px; height: 19px">
                                   <asp:Label ID="lblProductCataroy6" runat="server" Text="Finalized Lock :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 226px;">
                                    <asp:CheckBox ID="chkFinalizedLock" runat="server" Text="Yes" OnCheckedChanged="chkLockYn_CheckedChanged" />
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td style="text-align: right; width: 332px">
                                    &nbsp;
                                </td>
                                <td style="width: 239px">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" 
                                        CssClass="styled-button-4" onclick="btnShow_Click"
                                        />
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                </td>
                                <td style="width: 1px">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
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
                            <asp:BoundField DataField="GAZETTE_YEAR" HeaderText="Gazette Year" Visible="True" />
                            <asp:BoundField DataField="GAZETTE_MONTH_ID" HeaderText="Gazette Month" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="MONTH_NAME" HeaderText="Gazette Month" Visible="True" />
                            <asp:BoundField DataField="ANALYSIS_YN" HeaderText="ANALYSIS YN" Visible="True" />
                            <asp:BoundField DataField="ANALYSIS_LOCK" HeaderText="ANALYSIS LOCK" Visible="True" />
                            <asp:BoundField DataField="FINALIZED_YN" HeaderText="FINALIZED YN" />
                            <asp:BoundField DataField="FINALIZED_LOCK" HeaderText="FINALIZED LOCK" />
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
