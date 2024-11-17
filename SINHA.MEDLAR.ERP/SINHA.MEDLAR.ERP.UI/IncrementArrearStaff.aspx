<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="IncrementArrearStaff.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.IncrementArrearStaff" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
            <a href="InactiveProcess.aspx">InactiveProcess.aspx</a>
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
        <legend>Increment Arrear Staff</legend>
        <table style="width: 100%">

            <tr>
                <td style="text-align: left;" class="auto-style1">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                    <%--<asp:Label ID="Label1" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>--%>
                </td>
                 <td style="text-align: right; width: 200px; height: 15px;"> 
                </td>
                <td style="text-align: right" colspan="2">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px; height: 27px;">
                    <asp:Label ID="lblIncrementYear" runat="server" Text="Inc Year :"></asp:Label>
                </td>
                <td style="width: 350px; height: 27px;">
                    <asp:TextBox ID="txtIncrementYear" runat="server" Width="261px" Height="25px" ></asp:TextBox>                   
                </td>
                 <td style="text-align: right; width: 250px; height: 27px;">
                    <asp:Label ID="Label2" runat="server" Text="Inc Month :"></asp:Label>
                </td>
                <td style="width: 350px; height: 27px;">
                    <asp:DropDownList ID="ddlMonthId" runat="server" Width="260px" Height="28px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px; height: 27px;">
                    <asp:Label ID="lblArrearFromYear" runat="server" Text="Arrear From Year :"></asp:Label>
                </td>
                <td style="width: 350px; height: 27px;">
                    <asp:TextBox ID="txtArrearFromYear" runat="server" Width="261px" Height="25px" ></asp:TextBox>                   
                </td>
                 <td style="text-align: right; width: 250px;">
                    <asp:Label ID="Label3" runat="server" Text="Arrear To Year :"></asp:Label>
                </td>
                <td style="width: 350px; height: 27px;">
                    <asp:TextBox ID="txtArrearToYear" runat="server" Width="258px" Height="25px" ></asp:TextBox>                   
                </td>
            </tr>
            <tr>
               
               <td style="text-align: right; width: 250px; height: 27px;">
                    <asp:Label ID="lblArrearFromMonth" runat="server" Text="Arrear From Month :"></asp:Label>
                </td>
                <td style="width: 350px; height: 27px;">
                    <asp:DropDownList ID="ddlArrearFromMonth" runat="server" Width="262px" Height="28px">
                    </asp:DropDownList>
                </td> 
                 <td style="text-align: right; width: 250px; height: 27px;">
                    <asp:Label ID="Label1" runat="server" Text="Arrear To Month :"></asp:Label>
                </td>
                <td style="width: 350px; height: 27px;">
                    <asp:DropDownList ID="ddlArrearToMonth" runat="server" Width="260px" Height="28px">
                    </asp:DropDownList>
                </td> 
            </tr>
            <tr>
               
                  <td style="text-align: right; width: 250px; height: 22px;">
                    <asp:Label ID="lblId" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td style="width: 350px; height: 22px;">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="262px" Height="28px">
                    </asp:DropDownList>
                </td>
                 <td style="text-align: right; width: 250px; height: 22px;">
                    <asp:Label ID="lblId0" runat="server" Text="Section :"></asp:Label>
                </td>
                <td style="width: 350px; height: 22px;">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="260px" Height="28px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px;">
                    &nbsp;</td>
                <td style="width: 350px;">
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px;">
                    &nbsp;
                </td>
                <td style="width: 350px;">
                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Process" Width="66px"  CssClass = "styled-button-4" Visible="true"
                        OnClick="btnProcess_Click" />
                    <asp:Button ID="btnArrearSheetStaff" runat="server" Height="31px" Text="Sheet" Width="50px"
                                        CssClass="styled-button-4"  />
                    <asp:Button ID="btnRequisition" runat="server" Height="31px" Text="Requisition" Width="80px"
                                        CssClass="styled-button-4"  />
                    
                  
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px;">
                    &nbsp;</td>
                <td style="width: 350px;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <%--<fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
             <tr>
             <td colspan="5">
                <asp:GridView ID="GvInactiveEmployee" runat="server" DataSourceID="" AutoGenerateColumns="False"
                 AllowSorting="True" EnableViewState="true"
                GridLines="None" AllowPaging="false"  CssClass="mGrid"
                PagerStyle-CssClass="pgr"
                CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                Width="1030px" Height="133px">
                 <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="create_date" HeaderText="Date" />
                            <asp:BoundField DataField="status_name" HeaderText="Reason" />
                        </Columns>
                     <EditRowStyle BackColor="#999999"></EditRowStyle>
                     <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                     <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                       <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                       <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                       <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                       <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                       <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                       <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                       <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                   </asp:GridView>
             </td>     
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>     
                           <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                        <asp:BoundField DataField="Joining_date" HeaderText="J.Date" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                             <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                             <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" />
                            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("Employee_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>--%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
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
