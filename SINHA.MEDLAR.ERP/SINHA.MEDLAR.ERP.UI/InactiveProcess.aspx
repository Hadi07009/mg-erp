<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="InactiveProcess.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.InactiveProcess" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                defaultDate: '-1m', 
                
                //numberOfMonths: 1,
                //showCurrentAtPos: 2,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>

    <script language="Javascript" type="text/javascript">
         function isReset() {
             return confirm("Do you want to reset this ?");
         }
        function isDelete() {
            return confirm("Do you want to delete this ?");
        }
    </script>
      <script language="Javascript" type="text/javascript">

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;

            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {

                //Get the Cell To find out ColumnIndex

                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {

                    if (objRef.checked) {

                        //If the header checkbox is checked
                        //check all checkboxes
                        //and highlight all rows
                        row.style.backgroundColor = "white";
                        inputList[i].checked = true;
                    }
                    else {
                        //If the header checkbox is checked

                        //uncheck all checkboxes
                        //and change rowcolor back to original
                        if (row.rowIndex % 2 == 0) {
                            //Alternating Row Color
                            row.style.backgroundColor = "white";
                        }
                        else {

                            row.style.backgroundColor = "white";
                        }
                        inputList[i].checked = false;
                    }
                }
            }
        }
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
        <legend>INACTIVE PROCESS</legend>
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
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Year/Month :"></asp:Label>
                </td>
                <td style="width: 350px; height: 27px;">
                    <asp:TextBox ID="txtYear" runat="server" Width="211px" Height="25px" BackColor="Yellow" ReadOnly="true"></asp:TextBox>
                    <asp:TextBox ID="txtMonth" runat="server" Width="46px" Height="25px" BackColor="Yellow" ReadOnly="false"></asp:TextBox>
                </td>
                 <td style="text-align: right; width: 100px; height: 27px;"> Inactive Reason :</td>
                <td style="width: 350px; height: 27px;">
                    <asp:DropDownList ID="ddlStatusId" runat="server" Width="262px" Height="28px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px;">
                    <asp:Label ID="lblId" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td style="width: 350px;">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="266px" Height="28px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; width: 100px;"> Inactive Date :</td>
                <td style="width: 350px;">
                    <asp:TextBox ID="dtpResignDate" runat="server" Width="260px" Height="25px" CssClass="date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px;">
                    <asp:Label ID="lblId0" runat="server" Text="Section :"></asp:Label>
                </td>
                <td style="width: 350px;">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="266px" Height="28px">
                    </asp:DropDownList>
                </td>
                 <td style="text-align: right; width: 100px; height: 19px">
                    <asp:Label ID="lblInactiveReason" runat="server" Text="Inactive Reason :"></asp:Label>
                </td>
                <td style="height: 19px; width: 350px;">
                    <asp:TextBox ID="txtInactiveReason" runat="server" Width="260px" BackColor="White"
                        Height="32px" TextMode="MultiLine"></asp:TextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px;">
                    <asp:Label ID="lblCardNo" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td style="width: 350px;">
                    <asp:TextBox ID="txtCardNo" runat="server" Width="255px" Height="25px" ></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="50px" onclick="btnSearch_Click"  CssClass = "styled-button-4"/>
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
            <tr>
                <td style="text-align: right; width: 250px;">
                    &nbsp;
                </td>
                <td style="width: 350px;">
                    <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Prepare Proposal" Width="108px"  CssClass = "styled-button-4"
                        OnClick="btnProcess_Click" />
                    <asp:Button ID="btnInactiveProposal" runat="server" Height="31px" Text="Proposal Sheet" Width="99px"  CssClass = "styled-button-4"
                        OnClick="btnInactiveProposal_Click" />
                    <asp:Button ID="btnInactivate" runat="server" Height="31px" Text="Inactivate" Width="66px"  CssClass = "styled-button-4" Visible="true"
                        OnClick="Inactivate_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="21px"  CssClass = "styled-button-4" Visible="false"
                        OnClick="btnSave_Click" />
                    
                    
                  
                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="16px" onclick="btnShow_Click"  CssClass = "styled-button-4" Visible="false"/>
                    <asp:Button ID="btnInactiveSheet" runat="server" Height="31px" Text="Inactive Sheet" Width="90px"  CssClass = "styled-button-4"
                        OnClick="btnInactiveSheet_Click" />
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


    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" DataKeyNames="EMPLOYEE_ID"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnRowDeleting="gvEmployeeList_RowDeleting">
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
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="Designation" />
                            <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                            <asp:BoundField DataField="SECTION_NAME" HeaderText="Section" />
                            <asp:BoundField DataField="status_name" HeaderText="Inactive Reason" />
                            <asp:BoundField DataField="active_yn" HeaderText="Active?" />
                                                        
                            <asp:BoundField DataField="resign_date" HeaderText="Resign Date" />
                            <asp:BoundField DataField="resign_cause" HeaderText="Resign Cause" />
                            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                                        
                           <asp:TemplateField HeaderText="inactive_year" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                           <ItemTemplate>
                              <asp:TextBox ID="txtInactiveYear" runat="server" Text='<%#Eval("inactive_year")%>' ReadOnly="true"></asp:TextBox>
                           </ItemTemplate>
                           </asp:TemplateField>

                            <asp:TemplateField HeaderText="inactive_month" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                  <asp:TextBox ID="txtInactiveMonth" runat="server" Text='<%#Eval("inactive_month")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="status_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                  <asp:TextBox ID="txtStatusId" runat="server" Text='<%#Eval("status_id")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("Employee_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reset" ItemStyle-Width="1%">
                       <ItemTemplate>
                           <asp:ImageButton ID="btnSub" runat="server" Text="Reset" ImageUrl="~/images/reset-01.png"
                               AlternateText="Reset"
                               Width="30px" CommandName="Delete" OnClientClick="return isReset();"
                               Height="25px" Visible="true" />
                       </ItemTemplate>
                   </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

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
                        AllowSorting="True" EnableViewState="true" DataKeyNames="EMPLOYEE_ID"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnRowDeleting="gvEmployeeList_RowDeleting">
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
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="Designation" />
                             <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                             <asp:BoundField DataField="SECTION_NAME" HeaderText="Section" />
                            <asp:BoundField DataField="active_yn" HeaderText="Active?" />
                            <asp:BoundField DataField="resign_date" HeaderText="Resign Date" />
                            <asp:BoundField DataField="resign_cause" HeaderText="Resign Cause" />
                            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                                        
                           <asp:TemplateField HeaderText="inactive_year" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                           <ItemTemplate>
                              <asp:TextBox ID="txtInactiveYear" runat="server" Text='<%#Eval("inactive_year")%>' ReadOnly="true"></asp:TextBox>
                           </ItemTemplate>
                           </asp:TemplateField>

                            <asp:TemplateField HeaderText="inactive_month" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                  <asp:TextBox ID="txtInactiveMonth" runat="server" Text='<%#Eval("inactive_month")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="status_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                  <asp:TextBox ID="txtStatusId" runat="server" Text='<%#Eval("status_id")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("Employee_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reset" ItemStyle-Width="1%">
                       <ItemTemplate>
                           <asp:ImageButton ID="btnSub" runat="server" Text="Reset" ImageUrl="~/images/reset-01.png"
                               AlternateText="Reset"
                               Width="30px" CommandName="Delete" OnClientClick="return isReset();"
                               Height="25px" Visible="true" />
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
     <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" DataKeyNames="EMPLOYEE_ID"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <Columns>
                           <%-- <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>  --%>   
                           <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="Joining_date" HeaderText="J.Date" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="Designation" />
                            <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                            <asp:BoundField DataField="SECTION_NAME" HeaderText="Section" />
                            <asp:BoundField DataField="status_name" HeaderText="Inactive Reason" />
                            <asp:BoundField DataField="active_yn" HeaderText="Active?" />                                                   
                            <asp:BoundField DataField="resign_date" HeaderText="Resign Date" />
                            <asp:BoundField DataField="resign_cause" HeaderText="Resign Cause" />
                            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                                        
                           <asp:TemplateField HeaderText="inactive_year" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                           <ItemTemplate>
                              <asp:TextBox ID="txtInactiveYear" runat="server" Text='<%#Eval("inactive_year")%>' ReadOnly="true"></asp:TextBox>
                           </ItemTemplate>
                           </asp:TemplateField>

                            <asp:TemplateField HeaderText="inactive_month" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                  <asp:TextBox ID="txtInactiveMonth" runat="server" Text='<%#Eval("inactive_month")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="status_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                  <asp:TextBox ID="txtStatusId" runat="server" Text='<%#Eval("status_id")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("Employee_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Reset" ItemStyle-Width="1%">
                       <ItemTemplate>
                           <asp:ImageButton ID="btnSub" runat="server" Text="Reset" ImageUrl="~/images/reset-01.png"
                               AlternateText="Reset"
                               Width="30px" CommandName="Delete" OnClientClick="return isReset();"
                               Height="25px" Visible="true" />
                       </ItemTemplate>
                   </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
  
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
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
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
