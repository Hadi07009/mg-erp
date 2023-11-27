<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" ValidateRequest = "false" 
    EnableEventValidation="false" CodeBehind="AddBranchOfficeInfo.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddBranchOfficeInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <legend>ADD BRANCH OFFICE INFO</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; " colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" 
                        Font-Size="Small"></asp:Label>
                    &nbsp;
                    &nbsp;
                    &nbsp;
                </td>
                <td style="text-align: left; ">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblBranchOfficeId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBranchOfficeId" runat="server" Width="72px" 
                        BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="23px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblBranchOfficeId0" runat="server" Text="Head Office Name : "></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlHeadOfficeName" runat="server" Height="19px" 
                        Width="240px" BackColor="White">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblBranchOfficeNameEng" runat="server" 
                        Text="Branch Office  Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtBranchOfficeNameEng" runat="server" Width="236px" 
                        BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <asp:Label ID="lblBranchOfficeNameBng" runat="server" 
                        Text="Branch Office Name(Bangla) :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtBranchOfficeNameBng" runat="server" Width="236px" 
                        BackColor="White" Font-Names="SutonnyMJ"
                        MaxLength="300" Font-Size="Small"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <asp:Label ID="lblBranchOfficeAdd" runat="server" 
                        Text="Branch Office Address :"></asp:Label>
                </td>
                <td style="height: 19px; text-align: left;">
                    <asp:TextBox ID="txtBranchOfficeAddress" runat="server" Width="236px" 
                        BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <asp:Label ID="lblBranchOfficeCMNo" runat="server" 
                        Text="Contact Person Mobile No :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtPersonMobileNo" runat="server" Width="236px" 
                        BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <asp:Label ID="lblBranchOfficeCPNo" runat="server" 
                        Text="Contact Person's Phone No :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtPersonPhoneNo" runat="server" Width="236px" 
                        BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    <asp:Label ID="lblBranchOfficeNameBng3" runat="server" 
                        Text="Contact Person's Fax No :"></asp:Label>
                </td>
                 <td style="height: 19px">
                    <asp:TextBox ID="txtPersonFaxNo" runat="server" Width="236px" 
                        BackColor="White"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px; height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    &nbsp;
                </td>
                <td>
                    
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" 
                        OnClick="btnSave_Click"  CssClass = "styled-button-4"/>
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear"  CssClass = "styled-button-4"
                        Width="66px" onclick="btnClear_Click"
                        />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="2">
                    <asp:GridView ID="gvBranchOffice" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvBranchOffice_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" 
                        OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="BRANCH_OFFICE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="BRANCH_OFFICE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="BRANCH_OFFICE_NAME_BANGLA" HeaderText="NAME BANGLA" />
                            <asp:BoundField DataField="BRANCH_OFFICE_ADDRESS" HeaderText="ADDRESS" />
                            <asp:BoundField DataField="CONTACT_PERSON_MOBILE_NO" HeaderText="MOBILE" />
                            <asp:BoundField DataField="CONTACT_PERSON_PHONE_NO" HeaderText="PHONE" />
                            <asp:BoundField DataField="CONTACT_PERSON_FAX_NO" HeaderText="FAX" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="text-align: right;">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 339px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;</td>
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
