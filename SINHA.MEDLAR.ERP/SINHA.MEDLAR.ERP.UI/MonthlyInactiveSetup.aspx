<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="MonthlyInactiveSetup.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MonthlyInactiveSetup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
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
    <script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtInactiveYear.ClientID %>").focus(); }) 
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
        <legend>Monthly Inactive Information</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>Monthly Inactive Setup</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="Label1" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtInactiveYear" runat="server" Width="100px" BackColor="Yellow" Height="22px"></asp:TextBox>
                                    <asp:TextBox ID="txtInactiveMonth" runat="server" Width="43px" MaxLength="300" BackColor="Yellow" 
                                        Font-Size="Small" Height="22px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    <asp:Label ID="Label2" runat="server" Text="Date :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="dtpProposalDate" runat="server" Width="150px"  Height="22px" CssClass="date"></asp:TextBox>
                                    <asp:TextBox ID="txtSetupId" runat="server" visible="false" Width="20px"
                                        Font-Size="Small" Height="22px"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    <asp:Label ID="lblProposalLockYn" runat="server" Text="Proposal Lock Yn :"></asp:Label>
                                </td>
                                <td style="height: 25px">
                                    <asp:CheckBox ID="chkProposalLockYn" runat="server" />

                                    &nbsp;&nbsp;&nbsp;

                                    <asp:Label ID="lblActivityLockYn" runat="server" Text="Activity Lock Yn :"></asp:Label>
                                    <asp:CheckBox ID="chkActivityLockYn" runat="server" />
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <%--<tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>--%>
                            <tr>
                                <td style="text-align: right; width: 332px">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    
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
           
           
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table>
     <tr>
         <td>
                    <asp:GridView ID="gvMonthlyInactiveSetup" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvMonthlyInactiveSetup_PageIndexChanging"
                        OnRowDataBound="gvMonthlyInactiveSetup_OnRowDataBound" OnSelectedIndexChanged="gvMonthlyInactiveSetup_OnSelectedIndexChanged"
                        OnRowEditing="gvMonthlyInactiveSetup_RowEditing" Width="1032px">
                        <Columns>
                               <asp:TemplateField HeaderText="SL No" ItemStyle-Width="30px"> 
                                  <ItemTemplate>                                                              
                                  <%#Container.DataItemIndex+1%>                                                
                                 </ItemTemplate>
                                 <ItemStyle Width="8%" />                                                          
                                </asp:TemplateField>
                           
                            <asp:BoundField DataField="inactive_year" HeaderText="YEAR" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="month_name" HeaderText="MONTH" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="proposal_date" HeaderText="DATE" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="proposal_lock_yn" HeaderText="PROPOSAL STATUS" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="activity_lock_yn" HeaderText="ACTIVITY STATUS" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="setup_id" HeaderText="setup_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                            <asp:BoundField DataField="inactive_month" HeaderText="inactive_month" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                            <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                             <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                             <ItemTemplate>
                                 <asp:ImageButton ID="btnselect" Width="28" Height="20" runat="server" CommandName="Select"
                                     Style="cursor: pointer" ImageAlign="Middle" Text="..." CausesValidation="false" ImageUrl="~/images/check.jpg"  AlternateText="Select" />
                             </ItemTemplate>
                             </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
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
