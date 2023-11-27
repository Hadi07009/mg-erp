<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="PhaseWisePaymentLock.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PhaseWisePaymentLock" %>

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
        $(window).load(function () { document.getElementById("<%= txtSalaryYear.ClientID %>").focus(); }) 
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
        <legend>PHASE WISE PAYMENT LOCK INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>PHASE WISE PAYMENT LOCK ENTRY</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 332px">
                                    <asp:Label ID="Label1" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSalaryYear" runat="server" Width="91px" BackColor="Yellow"></asp:TextBox>
                                    <asp:TextBox ID="txtSalaryMonth" runat="server" Width="47px" MaxLength="300" BackColor="Yellow"
                                        Font-Size="Small"></asp:TextBox>
                                    <asp:HiddenField ID="hf_lock_id" runat="server"/>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:  332px; text-align: right">
                                    <asp:Label ID="Label2" runat="server" Text="Office Name :"></asp:Label>
                                </td>
                                <td>
                                <asp:DropDownList ID="ddlBranchOfficeId" runat="server" Width="150px" Height="25">
                                </asp:DropDownList>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                  <td style="width:  332px; text-align: right">
                                      <asp:Label ID="Label9" runat="server" Text="Payment Type :"></asp:Label>
                                      </td>
                                  <td style="width: 95px">
                                      <asp:DropDownList ID="ddlPaymentType" runat="server" Width="150px" Height="25" >
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
                                  <td style="width:  332px; text-align: right">
                                      <asp:Label ID="Label4" runat="server" Text="Eid Type :"></asp:Label>
                                   </td>
                                  <td style="width: 95px">
                                      <asp:DropDownList ID="ddlEidType" runat="server" Width="150px" Height="25" >
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
                                <td style="text-align: right; width: 332px; height: 19px">
                                    <asp:Label ID="Label3" runat="server" Text="Phase :"></asp:Label>
                               </td>
                                <td style="height: 19px">
                                     <asp:DropDownList ID="ddlPhaseId" runat="server" Width="150px" Height="28px">
                                    <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Phase-1"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Phase-2"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Phase-3"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Phase-4"></asp:ListItem>
                                </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Lock Yn :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes" />
                                </td>
                                <td style="height: 19px">
                                    </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 332px; height: 19px">
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
                                <td style="text-align: right; width: 332px">
                                    
                                </td>
                                <td colspan="2">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="56px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" 
                                        CssClass="styled-button-4" onclick="btnShow_Click"/>
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
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                        <Columns>
                            <asp:BoundField DataField="lock_id" HeaderText="lock_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:BoundField DataField="branch_office_id" HeaderText="OFFICE ID" Visible="True" />
                             <asp:BoundField DataField="branch_office_name" HeaderText="OFFICE NAME" Visible="True" />
                            <asp:BoundField DataField="SALARY_YEAR" HeaderText="YEAR" Visible="True" />
                            <asp:BoundField DataField="SALARY_MONTH" HeaderText="MONTH" />
                             <asp:BoundField DataField="payment_type_name" HeaderText="PAYMENT TYPE" />
                            <asp:BoundField DataField="PHASE_NAME" HeaderText="PHASE" />
                            <asp:BoundField DataField="EID_NAME" HeaderText="EID" />
                            <asp:BoundField DataField="LOCK_SATUS" HeaderText="LOCK STATUS" />
                            <asp:BoundField DataField="payment_phase_id" HeaderText="phase_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="payment_type_id" HeaderText="payment_type_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="eid_type_id" HeaderText="eid_type_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
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
