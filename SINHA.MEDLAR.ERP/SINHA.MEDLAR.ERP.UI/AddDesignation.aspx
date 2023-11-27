<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddDesignation.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddDesignation" %>

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
        <legend>ADD DESIGNATION</legend>
        <table style="width: 100%">
              <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
             

          
            <tr>
                <td style="text-align: right; width: 339px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDesignationId" runat="server" Width="72px" BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click"
                        CssClass="styled-button-4" />
                </td>

            </tr>
          <tr style="height:30px; ">
                 <td style="text-align: right; width: 338px">
                       <asp:Label ID="Label1" runat="server" Text="Schedule:"></asp:Label>
                  </td>
               
                <td class="modal-sm" style="width: 278px">
                    <asp:DropDownList ID="ddlSchedule" runat="server" Width="241px" Height="25px">
                        <asp:ListItem Enabled="true" Text="Select Schedule" Value=" "></asp:ListItem>
                        <asp:ListItem Text="A" Value="1"></asp:ListItem>
                        <asp:ListItem Text="B" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
               <td style="text-align: right; width: 338px">
                       <asp:Label ID="Label2" runat="server" Text="Grade:"></asp:Label>
                </td>
               
                <td class="modal-sm" style="width: 278px">
                    <asp:DropDownList ID="ddlGrade" runat="server" Width="201px" Height="21px" >           
                    </asp:DropDownList>
                </td>
            </tr>

            <tr style="height:30px; ">
                <td style="text-align: right; width: 339px; height: 25px;">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Designation Name(Eng) :"></asp:Label>
                </td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtDesignationNameEng" runat="server" Width="236px" BackColor="White"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 339px; height: 25px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Designation Name(Bng) :"></asp:Label>
                </td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtDesignationNameBng" runat="server" Width="200px" Font-Names="KarnaphuliMJ"
                        MaxLength="300" BackColor="White" Font-Size="Small"></asp:TextBox>
                </td>
                <td style="height: 25px">
                </td>
            </tr>
            

            <tr style="height:30px; ">
                <td style="text-align: right; width: 339px; height: 25px;">
                       <asp:Label ID="Label5" runat="server" Text="Proposed Designation:"></asp:Label>
                </td>
                <td style="height: 25px">
                    <asp:DropDownList ID="ddlDesignationId" runat="server" Width="241px" Height="25px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; width: 339px; height: 25px">
                    &nbsp;</td>
                <td style="height: 25px">
                    &nbsp;</td>
                <td style="height: 25px">
                    &nbsp;</td>
            </tr>
            

            <tr style="height:30px; ">
                <td style="text-align: right; width:339px;">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="66px" OnClick="btnClear_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
          
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

  <table style="width: 100%">   
      <tr>
              <td style="text-align: right" colspan="4">
                  <fieldset>
                      <legend>SEARCH CRITERIA</legend>
                      <table class="style1">
    
                 <tr style="height:30px; ">
                <td style="text-align: right; width: 225px; height: 25px;">
                    <asp:Label ID="Label4" runat="server" Text="Designation Name(Eng) :"></asp:Label>
                </td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtDesignationNameSearch" runat="server" Width="230px" BackColor="White" Height="24px"></asp:TextBox>
                      <asp:Button ID="btnSearchByDesignation" runat="server" Height="28px" Text="Search" Width="61px"
                      CssClass="styled-button-4" OnClick="btnSearch_Click" style="margin-top: 0px" />
                                                   
                </td>
                <td style="text-align: right; width: 339px; height: 25px">
                                                    &nbsp;</td>
                <td style="height: 25px">
                    &nbsp;</td>
                <td style="height: 25px">
                </td>
            </tr>

      </table>
      </fieldset>
    </td>
  </tr>

  </table> 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table> <tr>
                <td style="text-align: right;" colspan="5">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid" Height="75px" Width="1032px">
                        <Columns>
                            <asp:BoundField DataField="DESIGNATION_ID" HeaderText="ID" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME_BANGLA" HeaderText="DESIGNATION NAME(BANGLA)" />
                            <asp:BoundField DataField="SCHEDULE_ID" HeaderText="SCHEDULE ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="SCHEDULE_NAME" HeaderText="SCHEDULE NAME" />
                            <asp:BoundField DataField="GRADE_ID" HeaderText="GRANE ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRANE NO" />
                             <asp:BoundField DataField="PROMOTED_DESIGNATION_ID" HeaderText="PROMOTED_DESIGNATION_ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="PROPOSED_DESIGNATION_NAME" HeaderText="PROPOSED DESIGNATION" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
  </table>
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
