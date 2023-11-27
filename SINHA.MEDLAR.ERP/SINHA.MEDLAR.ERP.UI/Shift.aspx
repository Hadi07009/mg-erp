<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="Shift.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.Shift" %>

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
    <script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtShiftId.ClientID %>").focus(); }) 
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
        <legend>Shift Entry</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 18px;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>  
            <tr>
                <td style="text-align: right; width: 337px">Duty Type:</td>
                <td>
                    <asp:DropDownList ID="ddlDutyType" runat="server" Width="298px" Height="29px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;</td>
            </tr>

            <tr>
                <td style="height:4px;"></td>
                <td></td>
                <td></td>
            </tr>

            <tr>
                <td style="text-align: right; width: 337px">Team:</td>
                <td>
                    <asp:TextBox ID="txtShiftName" runat="server" Width="285px" BackColor="White" Height="25px" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
                    <asp:TextBox ID="txtShiftId" runat="server" Width="16px" BackColor="White" Visible="false"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            
            <tr>
                <td style="text-align: right; width: 337px; height: 19px">&nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: justify; width: 337px">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" CssClass="styled-button-4"
                        Width="66px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: justify; " colspan="3">
                    <%--<asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>--%>
                </td>
            </tr>
            <tr>

                <td style="width:33%;"></td>

                <td>
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small" Visible="false"></asp:Label>
                    <asp:GridView ID="gvShift" runat="server" DataSourceID="" AutoGenerateColumns="False" style="width:350px;"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvShift_PageIndexChanging"
                        OnRowDataBound="gvShift_OnRowDataBound" OnSelectedIndexChanged="gvShift_OnSelectedIndexChanged">
                        <Columns>
                            <asp:TemplateField HeaderText = "SL No" ItemStyle-Width="40">
                              <ItemTemplate>
                                  <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                              </ItemTemplate>
                          </asp:TemplateField>
                            <asp:BoundField DataField="DUTY_TYPE_NAME" HeaderText="Duty Type" />
                            <asp:BoundField DataField="SHIFT_NAME" HeaderText="Shift" />
                            <asp:BoundField DataField="SHIFT_ID" HeaderText="C.Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" /> 
                            <asp:BoundField DataField="DUTY_TYPE_ID" HeaderText="D.Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" /> 
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" ImageAlign="Middle" Text="..." CausesValidation="false" ImageUrl="~/images/check.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                  
                </td>

                <td style="width:33%;"></td>
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
