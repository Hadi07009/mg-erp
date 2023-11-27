<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="PaymentRule.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PaymentRule" %>

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
        $(window).load(function () { document.getElementById("<%= txtPaymentYear.ClientID %>").focus(); }) 
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
        <legend>Payment Rule</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>Payment Rule Setup</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="Label1" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPaymentYear" runat="server" Width="91px" BackColor="Yellow" Height="22px"></asp:TextBox>
                                    <asp:TextBox ID="txtPaymentMonth" runat="server" Width="47px" MaxLength="300" BackColor="Yellow"
                                        Font-Size="Small" Height="23px"></asp:TextBox>
                                    <asp:HiddenField ID="hf_rule_id" runat="server"/>
                                </td>
                                <td>
                                </td>
                            </tr>
                           
                            <tr>
                                  <td style="width:  332px; text-align: right">
                                      <asp:Label ID="Label9" runat="server" Text="Payment Type :"></asp:Label>
                                      </td>
                                  <td style="width: 95px">
                                      <asp:DropDownList ID="ddlPaymentType" runat="server" Width="150px" Height="31px" >
                                      </asp:DropDownList>
                                  </td>
                                  <td style="width: 66px">
                  
                                      &nbsp;</td>
                                  <td style="text-align: right; width: 100px">
                                           &nbsp;</td>
                                  <td>
                                       &nbsp;</td>
                            </tr>
                             <tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="Label2" runat="server" Text="OT Deduct Hour/Minute :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtOtDeductionHour" runat="server" Width="91px"  Height="22px" placeHolder="Deduction Hour" ></asp:TextBox>
                                    <asp:TextBox ID="txtOtDeductionMinute" runat="server" Width="46px" MaxLength="300"
                                    Font-Size="Small" Height="21px" style="margin-top: 0px" placeHolder="Minute"></asp:TextBox>
                                   
                                </td>
                                <td>
                                </td>
                            </tr>
                           
                             <tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="lblAccountRegistrationFee" runat="server" Text="Account Registration Fee :"></asp:Label>
                                 </td>
                                <td>
                                    <asp:TextBox ID="txtAccountRegistrationFee" runat="server" Width="142px"  Height="22px" placeHolder="" ></asp:TextBox>
                                   
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                           
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    <asp:Label ID="Label10" runat="server" Text="Payment(Cash Priority?Y:N) :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:CheckBox ID="ChkCachPriorityPayment" runat="server" Text="" Visible="true" ></asp:CheckBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                           
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 332px">
                                    
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="56px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <%--<asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" 
                                        CssClass="styled-button-4" onclick="btnShow_Click"/>--%>
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                </td>
                                
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="GvPaymentRule" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GvPaymentRule_PageIndexChanging"
                        OnRowDataBound="GvPaymentRule_OnRowDataBound" OnSelectedIndexChanged="GvPaymentRule_OnSelectedIndexChanged"
                        OnRowEditing="GvPaymentRule_RowEditing" BorderStyle="Solid">
                        <Columns>
                            <asp:BoundField DataField="rule_id" HeaderText="rule_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                           
                            <asp:BoundField DataField="PAYMENT_YEAR" HeaderText="YEAR" Visible="True" />
                            <asp:BoundField DataField="PAYMENT_MONTH" HeaderText="MONTH" />
                            <asp:BoundField DataField="OT_DEDUCTION_HOUR" HeaderText="OT DEDUCTION HOUR" />
                             <asp:BoundField DataField="OT_DEDUCTION_MINUTE" HeaderText="OT DEDUCTION MINUTE" />
                            <asp:BoundField DataField="account_reg_fee" HeaderText="ACT.REG FEE" />
                            <asp:BoundField DataField="payment_type_name" HeaderText="PAYMENT TYPE" />
                             <asp:BoundField DataField="payment_type_id" HeaderText="payment_type_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="cash_priority" HeaderText="CASH PRIORITY" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                 <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" ImageAlign="Middle" Text="..." CausesValidation="false" ImageUrl="~/images/check.jpg"  AlternateText="Select" />
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
