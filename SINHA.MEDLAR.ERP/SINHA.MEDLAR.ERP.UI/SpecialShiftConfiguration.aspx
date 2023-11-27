<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ERP.Master" CodeBehind="SpecialShiftConfiguration.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.SpecialShiftConfiguration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">
       <%-- $(window).load(function () { document.getElementById("<%= dtpEffectDate.ClientID %>").focus(); }) --%>
    </script>

    <script type="text/javascript">
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
        <legend>Special Shift Configuration</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 200px">&nbsp;
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 200px">
                    <asp:Label ID="lblSpecialShiftName" runat="server" Text="Shift Name :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSpecialShift" runat="server" Width="167px" Height="22px">
                    </asp:DropDownList>
                </td>
               
                <td style="text-align: right; width: 200px">
                   <asp:Label ID="lblEffectDate" runat="server" Text="Effect Date :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dtpEffectDate" runat="server" Width="163px" Height="20px" Font-Bold="True"
                        BackColor="White" Style="margin-left: 0; margin-top: 0;" CssClass="date" placeholder="dd/mm/yyyy"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="text-align: right; width: 200px">
                    <asp:Label ID="lblPunchTime" runat="server" Text="Punch Start/Login Start :" Font-Bold="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPunchStartTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        Style="margin-left: 0px" BackColor="White" placeholder="hh:mm"></asp:TextBox>
                    <asp:TextBox ID="txtLoginStartTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        Style="margin-left: 0px" BackColor="White" placeholder="hh:mm"></asp:TextBox>
                </td>             
                <td style="text-align: right; width: 200px">
                    <asp:Label ID="lblLoginGraceTime" runat="server" Text="Grace Time/ Login Start Time :" Font-Bold="False"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLoginGraceTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        Style="margin-left: 0px" BackColor="White" placeholder="mm"></asp:TextBox>
                    <asp:TextBox ID="txtLoginEndTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                </td>           
            </tr>
            
            <tr>
                <td style="text-align:right; width: 200px; height: 19px">
                    <strong>
                        <asp:Label ID="lblLunchTime" runat="server" Text="Lunch Out/In :"></asp:Label>
                    </strong>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtLunchOutTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                    <asp:TextBox ID="txtLunchInTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                </td>
               
                <td style="text-align: right; width: 200px; height: 19px">
                    <strong>
                        <asp:Label ID="Label1" runat="server" Text="Lunch-Out Start/End :"></asp:Label>
                    </strong>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtLunchOutStartTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                    <asp:TextBox ID="txtLunchOutEndTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                </td>

            </tr>
          
            <tr>
                <td style="text-align: right; width: 200px; height: 19px">
                    <asp:Label ID="lblLunchIn0" runat="server" Text="Lunch-In Start/End :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtLunchInStartTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                    <asp:TextBox ID="txtLunchInEndTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 200px; height: 19px">
                <asp:Label ID="Label2" runat="server" Text="Logout Strat Time/Log Out :" Font-Bold="False"></asp:Label>    
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtLogoutStartTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        Style="margin-left: 0px" BackColor="White" placeholder="hh:mm"></asp:TextBox>
                    <asp:TextBox ID="txtLogoutTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        Style="margin-left: 0px" BackColor="White" placeholder="hh:mm"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align:right; width: 200px; height: 19px">
                    <strong>
                        <asp:Label ID="lblPunchEndTime" runat="server" Text="Punch End Time :" Font-Bold="False"></asp:Label>
                    </strong>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtPunchEndTime" runat="server" Width="78px" Height="20px" Font-Bold="True"
                        BackColor="White" placeholder="hh:mm"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 200px; height: 19px">
                </td>
                <td style="height: 19px"> 
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 200px; height: 19px">
                    <strong>
                        <asp:Label ID="lblActiveYn" runat="server" Text="Active:" Font-Bold="False"></asp:Label>
                  </strong>  
                </td>
                <td style="height: 19px">
                    <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes"/>
                     <asp:HiddenField ID="hf_shift_configuration_id" runat="server"/>  
                    <asp:HiddenField ID="hf_shift_id" runat="server"/> 
                </td>
                <td style="height: 19px; text-align: right;">
                   
                </td>
                <td style="height: 19px">    
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 200px; height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 200px">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                </td>
                <td>&nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="4">
                    <asp:GridView ID="gvSpecialShiftConfiguration" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvSpecialShiftConfiguration_PageIndexChanging"
                        OnSelectedIndexChanged="gvSpecialShiftConfiguration_OnSelectedIndexChanged" OnRowDataBound="OnRowDataBound">
                        <Columns>

                            <asp:BoundField DataField="shift_name" HeaderText="Shift" />
                            <asp:BoundField DataField="punch_start_time" HeaderText="Punch Start Time" />
                            <asp:BoundField DataField="login_start_time" HeaderText="Login Start Time" />
                            <asp:BoundField DataField="login_grace_time" HeaderText="Login Grace Time" />
                            <asp:BoundField DataField="login_end_time" HeaderText="Login End Time" />
                                                         
                            <asp:BoundField DataField="lunch_out_time" HeaderText="Lunch Out Time" />
                            <asp:BoundField DataField="lunch_in_time" HeaderText="Lunch In Time" />

                            <asp:BoundField DataField="logout_time" HeaderText="Logout Time" />
                            <asp:BoundField DataField="punch_end_time" HeaderText="Punch End Time" />
                            <asp:BoundField DataField="effective_date" HeaderText="Effective Date" />
                            <asp:BoundField DataField="active_yn" HeaderText="Active" />
                            <asp:BoundField DataField="shift_configuration_id" HeaderText="shift_configuration_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                            <asp:BoundField DataField="shift_id" HeaderText="shift_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>

                            <asp:BoundField DataField="lunch_out_start_time" HeaderText="lunch_out_start_time" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                            <asp:BoundField DataField="lunch_out_end_time" HeaderText="lunch_out_end_time" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="lunch_in_start_time" HeaderText="lunch_in_start_time" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                            <asp:BoundField DataField="lunch_in_end_time" HeaderText="lunch_in_end_time" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <%--<asp:BoundField DataField="early_ot_start_time" HeaderText="early_ot_start_time" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>--%>
                            <asp:BoundField DataField="logout_start_time" HeaderText="logout_start_time" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            
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
