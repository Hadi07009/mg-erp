<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ArrearSetup.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ArrearSetup" %>

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
        <legend>ARREAR SETUP</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>


           <%-- <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId2" runat="server" Text="Arrear Year :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtArrearYear" runat="server" Width="180px" BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId" runat="server" Text="From Month :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlFromMonthId" runat="server" Width="185px" 
                        Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="To Month :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlToMonthId" runat="server" Width="185px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 5px">
                    &nbsp;
                </td>
                <td style="height: 5px; width: 214px;">
                    &nbsp;
                </td>
                <td style="height: 5px">
                    &nbsp;
                </td>
            </tr>--%>

           
             <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId2" runat="server" Text="Arrear Year :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtArrearYear" runat="server" Width="180px" BackColor="White" 
                        OnTextChanged="txtArrearYear_TextChanged"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblToArrearYear" runat="server" Text="To Arrear Year :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtArrearYearTo" runat="server" Width="180px" BackColor="White"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId" runat="server" Text="From Month :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlFromMonthId" runat="server" Width="184px" 
                        Height="22px" OnSelectedIndexChanged="ddlFromMonthId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblToArrearFromMonth" runat="server" Text="To Arrear From Month :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlArrearFromMonthTo" runat="server" Width="184px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="To Month :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlToMonthId" runat="server" Width="184px" Height="22px" 
                        OnSelectedIndexChanged="ddlToMonthId_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblToArrearToMonth" runat="server" Text="To Arrear To Month :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:DropDownList ID="ddlArrearToMonthTo" runat="server" Width="184px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>

             <tr>
                <%--<td style="text-align: right; width: 279px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 214px;">
                    &nbsp;
                </td>--%>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblEffectDate" runat="server" Text="Effect Date :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtEffectDate" runat="server" Width="180px" BackColor="White" CssClass="date"></asp:TextBox>
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
                    <asp:Label ID="lblLimitDate" runat="server" Text="Limit Date :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:TextBox ID="txtLimitDate" runat="server" Width="180px" BackColor="White" CssClass="date"></asp:TextBox>
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
                    <asp:Label ID="lblCarryPreArrear" runat="server" Text="Carry Pre Arrear? :"></asp:Label>
                </td>
                <td style="width: 214px">
                    <asp:CheckBox runat="server" ID="chkCarryPreArrear" Width="180px"/>
                    <%--<asp:TextBox ID="TextBox1" runat="server" Width="180px" BackColor="White" CssClass="date"></asp:TextBox>--%>
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>



            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 214px;">
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
                <td style="text-align: right; width: 320px">
                    &nbsp;
                </td>
                <td style="width: 300px">
                    <asp:Button ID="btnSave" runat="server" Height="31px" Width="50px" Text="Add" style="text-align:center;" OnClick="btnSave_Click" />
                    <asp:Button ID="btnSyncAdvance" runat="server" Height="31px" Width="90px" Text="Sync Advance" style="text-align:center;" OnClick="btnSyncAdvance_Click" />
                    <asp:Button ID="btnDiscardUnpaidArrear" runat="server" Height="31px" Width="135px" Text="Discard Unpaid Arrear" style="text-align:center;" OnClick="btnDiscardUnpaidArrear_Click" />
                    <asp:HiddenField runat="server" ID="hfGridRowSelected" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="4">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="ARREAR_YEAR" HeaderText="YEAR" />
                            <asp:BoundField DataField="ARREAR_FROM_MONTH_NAME" HeaderText="FROM MONTH" />
                            <asp:BoundField DataField="ARREAR_TO_MONTH_NAME" HeaderText="TO MONTH" />

                            <asp:BoundField DataField="EFFECT_DATE" HeaderText="EFFECT DATE" />
                            <asp:BoundField DataField="LIMIT_DATE" HeaderText="LIMIT DATE" />
                            <asp:BoundField DataField="CARRY_PRE_ARREAR" HeaderText="CARRY PRE ARREAR" />
                            
                            <asp:BoundField DataField="ARREAR_FROM_MONTH_ID" HeaderText="FROM"  HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                            <asp:BoundField DataField="ARREAR_TO_MONTH_ID" HeaderText="TO"  HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
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
