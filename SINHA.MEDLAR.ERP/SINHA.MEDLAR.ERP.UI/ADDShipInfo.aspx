<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" ValidateRequest = "false" 
    EnableEventValidation="false" CodeBehind="ADDShipInfo.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ADDShipInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtShipName.ClientID %>").focus(); }) 
    </script>
    <script type='text/javascript'>
        $(document).ready(function () {
            $('#form1 input').keydown(function (e) {
                if (e.keyCode == 13) {
                    if ($(':input:eq(' + ($(':input').index(this) + 1) + ')').attr('type') == 'submit') {// check for submit button and submit form on enter press
                        return true;
                    }

                    $(':input:eq(' + ($(':input').index(this) + 1) + ')').focus();

                    return false;
                }

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
        <legend>PRODUCT INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; " colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" 
                        Font-Size="Small"></asp:Label>
                    &nbsp;
                    &nbsp;
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblShipId" runat="server" Text="ID :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtShipId" runat="server" Width="72px" 
                        BackColor="Yellow" ></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="23px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblProductName" runat="server" Text="Ship Name:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtShipName" runat="server" Width="236px" 
                        BackColor="White" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblShipAddress" runat="server" Text="Ship Address:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtShipAddress" runat="server" Width="236px" 
                        BackColor="White" ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblEmail" runat="server" 
                        Text="Email:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Width="236px" 
                        BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right">
                    <asp:Label ID="lblPhoneNo" runat="server" 
                        Text="Phone :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPhoneNo" runat="server" Width="236px" 
                        BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear"  CssClass = "styled-button-4"
                        Width="66px" onclick="btnClear_Click"
                        />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" 
                        OnClick="btnSave_Click"  CssClass = "styled-button-4"/>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvShipInfo" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt"
                        OnRowDataBound="OnRowDataBound" 
                        OnSelectedIndexChanged="OnSelectedIndexChanged" 
                        onpageindexchanging="gvShipInfo_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="SHIP_ID" HeaderText="ID" />
                            <asp:BoundField DataField="SHIP_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="SHIP_ADDRESS" HeaderText="ADDRESS" />
                            <asp:BoundField DataField="EMAIL_ADDRESS" HeaderText="EMAIL" />
                            <asp:BoundField DataField="PHONE_NO" HeaderText="PHONE" />
                          
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
