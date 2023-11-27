<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="ShareDistribution.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.ShareDistribution" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(document).keypress(function (e) {
            if (e.which == 13) {
                $(document.activeElement).next().focus();
            }
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
        function isDelete() {
            return confirm("Do you want to delete this row ?");
        }
    </script>
    <%--  <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtp.ClientID %>").focus(); }) 
    </script>--%>
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
        <legend>Share Distribution</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left;" class="auto-style1">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
               
                <td style="height: 19px">&nbsp;</td>
                 <td style="height: 19px">&nbsp;</td>
                 <td style="height: 19px">&nbsp;</td>
                 <td style="height: 19px">&nbsp;</td>
                <td style="text-align: right">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="width: 267px; text-align: right; height: 26px;">
                    <asp:Label ID="lblId1" runat="server" Text="Company : "></asp:Label>
                </td>
                <td style="width: 365px; height: 26px;">
                    <asp:DropDownList ID="ddlCompanyId" runat="server" Width="202px"
                        Height="24px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; width: 245px; height: 26px;">
                    <asp:Label ID="lblShareHolder" runat="server" Text="Share Holder :"></asp:Label>
                </td>
                <td style="text-align: justify; width: 173px; height: 26px;">
                    <asp:DropDownList ID="ddlShareHolderId" runat="server" Width="202px"
                        Height="24px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; width: 337px; height: 26px;">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Nominee :"></asp:Label>
                </td>
                <td style="text-align: justify; width: 337px; height: 26px;">
                    <asp:DropDownList ID="ddlNomineeId" runat="server" Width="202px"
                        Height="24px">
                    </asp:DropDownList>
                 </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 267px; height: 19px">
                    <asp:Label ID="lblNoOfShare" runat="server" Text="No Of Share : "></asp:Label>
                </td>
                <td style="height: 19px; width: 365px;">
                    <asp:TextBox ID="txtNoOfShare" runat="server" Width="200px" BackColor="White"
                        Height="22px"></asp:TextBox>
                </td>
                <td style="height: 19px; width: 245px; text-align: right;">
                    <asp:Label ID="lblFaceValue" runat="server" Text="Face Value :"></asp:Label>
                </td>
                <td style="height: 19px; width: 173px;">
                    <asp:TextBox ID="txtFaceValue" runat="server" Width="200px" BackColor="White"
                        Height="22px"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right;">
                    <asp:Label ID="lblDisplayOrder" runat="server" Text="Display Order :"></asp:Label>
                </td>
                <td style="height: 19px; text-align: justify;">
                    <asp:TextBox ID="txtDisplayOrder" runat="server" Width="200px" BackColor="White"
                        Height="22px"></asp:TextBox>

                </td>
                <td style="height: 19px">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 267px">
                    <asp:Label ID="lblPaidUpCapital" runat="server" Text="Paid Up Capital:"></asp:Label>
                </td>
                <td style="width: 365px; text-align: left;">
                    <asp:TextBox ID="txtPaidUpCapital" runat="server" Width="200px" BackColor="Yellow" ReadOnly="true" onkeydown="javascript:TextName_OnKeyDown(event)"
                        Height="22px"></asp:TextBox>

                </td>
                <td style="width: 245px; text-align: right;">
                    <asp:Label ID="lblSharePercent" runat="server" Text="Share Percent :"></asp:Label>
                </td>
                <td style="width: 173px">
                    <asp:TextBox ID="txtSharePercent" runat="server" Width="200px" ReadOnly="true"
                        BackColor="Yellow" Height="22px"></asp:TextBox>
                </td>
                 <td style="width: 245px; text-align: right;">&nbsp;</td>
                 <td style="width: 245px; text-align: right;">
                <asp:HiddenField ID="distribution_id" runat="server"/>
                </td>
            </tr>
            <tr>
                <td style="text-align: center; height: 32px;" colspan="7">
                    
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" CssClass="styled-button-4"
                        Width="66px" OnClick="btnSave_Click" />
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" CssClass="styled-button-4"
                        Width="66px" OnClick="btnShow_Click" />
                    <asp:Button ID="BtnSHareCalculation" runat="server" Height="31px" Text="Calculate Share" CssClass="styled-button-4"
                        Width="114px" OnClick="BtnSHareCalculation_Click" />
                    <asp:Button ID="BtnSHarePercent" runat="server" Height="31px" Text="Share Percent" CssClass="styled-button-4"
                        Width="92px" OnClick="BtnSHarePercent_Click" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: justify;" colspan="7">
                    <asp:Label ID="lblMsgRecord" runat="server" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="7">
                    <asp:GridView ID="gvShareDistribution" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr" DataKeyNames="DISTRIBUTION_ID"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvShareDistribution_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" OnRowDeleting="gvShareDistribution_RowDeleting">
                        <Columns>
                            
                            <asp:BoundField DataField="COMPANY_NAME" HeaderText="Company" />
                            <asp:BoundField DataField="SHARE_HOLDER_NAME" HeaderText="Share Holder" />
                            <asp:BoundField DataField="NOMINEE_NAME" HeaderText="Nominee" />
                            <asp:BoundField DataField="NO_OF_SHARE" HeaderText="No of Share" />
                            <asp:BoundField DataField="FACE_VALUE" HeaderText="Face Value" />
                            <asp:BoundField DataField="PAID_UP_CAPITAL" HeaderText="Paid Up Capital" />
                            <asp:BoundField DataField="SHARE_PERCENT" HeaderText="Share Percent" />                            
                             <asp:BoundField DataField="company_id" HeaderText="company_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                            <asp:BoundField DataField="share_holder_id" HeaderText="share_holder_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="nominee_id" HeaderText="nominee_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                            <asp:BoundField DataField="distribution_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" /> 
                            <asp:BoundField DataField="display_order" HeaderText="Display Order" />
                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                 <ItemTemplate>
                                                     <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                         AlternateText="Delete"
                                                         Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                         Height="25px" Visible="true" />
                                                 </ItemTemplate>
                                              </asp:TemplateField>
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"
                                        AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 267px">&nbsp;
                </td>
                <td style="width: 365px">&nbsp;
                </td>
                <td style="width: 245px">&nbsp;</td>
                <td style="width: 173px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
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
