<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="MFSTemplateHalfSalary.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MFSTemplateHalfSalary" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
      <script type="text/javascript" language="javascript">
        function SelectAllCheckboxes(spanChk) {
            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
                }
        }
    </script>

      <script type="text/javascript" language="javascript">
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
                document.getElementById('<%= btnSearch.ClientID %>').click();
            }
        }
    </script>
      
      <script type="text/javascript">

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
      
      <script type="text/javascript">
        function MouseEvents(objRef, evt) {
            var checkbox = objRef.getElementsByTagName("input")[0];
            if (evt.type == "mouseover") {
                objRef.style.backgroundColor = "orange";
            }
            else {
                if (checkbox.checked) {
                    objRef.style.backgroundColor = "aqua";
                }
                else if (evt.type == "mouseout") {
                    if (objRef.rowIndex % 2 == 0) {
                        //Alternating Row Color
                        objRef.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        objRef.style.backgroundColor = "white";
                    }
                }
            }
        }

    </script>   

    <script type="text/javascript">

        function isCreate() {
            var reply = confirm("Ary you sure you want to Create?");
            if (reply) {
                return true;
            }
            else {
                return false;
            }
        }

        function isDelete() {
            var reply = confirm("Ary you sure you want to Remove?");
            if (reply) {
                return true;
            }
            else {
                return false;
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
        <legend style="text-align:left; font-size:15px; width: 206px;" >MFS TEMPLATE- HALF SALARY</legend>
        <table class="style1">

            <tr>
               <td style="width: 100px"> </td>
               <td style="width: 300px"></td>
               <td style="width: 100px"> &nbsp;</td>
               <td style="text-align:right;" colspan="2">
                
                <%--<a href="IndividualPaymentPhase.aspx" style="text-decoration: underline;" title="Individual Payment Phase">Ind Phase</a>--%>
                <asp:Button ID="BtnIndividualPayment" runat="server" Height="25px" Text="Ind Phase" Width="80px"
                  CssClass="styled-button-4" OnClick="BtnIndividualPayment_Click" style="text-align:center;"/>
                 
                <asp:Button ID="BtnPaymentHold" runat="server" Height="25px" Text="Hold" Width="50px"
                  CssClass="styled-button-4" OnClick="BtnPaymentHold_Click" style="text-align:center;"/>

                <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
               </td>                                              
            </tr>

            <tr>
               <td style="width: 100px; text-align:right;"> 
                  <asp:Label ID="Label19" runat="server" Text="Year/Month :" Height="22"></asp:Label>
               </td>
               <td style="width: 300px">
               <asp:TextBox ID="txtSalaryYear" runat="server" Width="120px" Height="22px" Font-Bold="True"></asp:TextBox>
               <asp:TextBox ID="txtsalaryMonth" runat="server" Width="50px" Height="22px" Font-Bold="True" ></asp:TextBox>               
                   <asp:Button ID="btnSearch" runat="server" Height="28px" Text="Search" Width="60px" onclick="btnSearch_Click"  CssClass = "styled-button-4" style="text-align:center;"/>
               </td>

                <td style="width: 100px; text-align:right;"> 
                  
               </td>

               <td style="text-align:right;"> 
               </td>
          </tr>

            <tr>
               <td style="width: 100px; text-align:right;"> 
               <asp:Label ID="Label2" runat="server" Text="Phase :" Width="100px" Height="22"></asp:Label>   
               </td>
               <td style="width: 300px">
               <asp:DropDownList ID="ddlPhaseId" runat="server" Width="180px" Height="28px">
                  <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                  <asp:ListItem Value="1" Text="Phase-1"></asp:ListItem>
                  <asp:ListItem Value="2" Text="Phase-2"></asp:ListItem>
                  <asp:ListItem Value="3" Text="Phase-3"></asp:ListItem>
                  <asp:ListItem Value="4" Text="Phase-4"></asp:ListItem>
               </asp:DropDownList>
                   
               </td>
               <td style="width: 100px; text-align:left;"> 
                   
               </td>
               <td style="text-align:right;"> 
               </td>
          </tr>
            
            <tr>
               <td style="width: 100px; height:10px; text-align:right;"> 
               </td>
               <td style="width: 300px">
               </td>
               <td style="width: 100px; text-align:right;"> 
               </td>
               <td style="text-align:right;"> 
               </td>
            </tr>
    
       <tr>
          <td style="width: 100px; text-align:right;"> 
          </td>
          <td colspan="3">
            <asp:Button ID="btnSave" runat="server" Text="Create" Height="30px" Width="60px" CssClass = "styled-button-4" Visible="true"
               OnClientClick="return isCreate();" OnClick="btnSave_Click" style="text-align:center;" />
            <asp:Button ID="btnUpdate" runat="server" Text="Remove" Height="30px" Width="65px"  CssClass = "styled-button-4" Visible="true"
               OnClientClick="return isDelete();" OnClick="btnUpdate_Click" style="text-align:center;"/>
            <asp:Button ID="btnRequisition" runat="server" Height="25px" Text="Requisition" Width="80px"
                  CssClass="styled-button-4" OnClick="btnRequisition_Click" Visible="false" style="text-align:center;"/>

            <asp:Button ID="btnMasterRequisition" runat="server" Text="Master Req" Height="30px" Width="85px"
                  CssClass="styled-button-4" OnClick="btnMasterRequisition_Click" style="text-align:center;"/>
                                      
            <asp:Button ID="btnHoldRequisition" runat="server" Text="Hold Req" Height="30px" Width="65px"
                  CssClass="styled-button-4" OnClick="btnHoldRequisition_Click" style="text-align:center;"/>

            <asp:Button ID="btnUnholdRequisition" runat="server" Text="Unhold Req" Height="30px" Width="85px"
                  CssClass="styled-button-4" OnClick="btnUnholdRequisition_Click" style="text-align:center;"/>
                          
            <asp:Button ID="btnMonthlySalaryMfsTemplate" runat="server" Height="25px" Text="Template (Bkash)" Width="110px"
                  CssClass="styled-button-4" Visible="false" OnClick="btnMonthlySalaryMfsTemplate_Click" style="text-align:center;"/> 

            <asp:Button ID="btnMasterTemplate" runat="server" Text="Master Template" Height="30px" Width="120px"
                  CssClass="styled-button-4" OnClick="btnMasterTemplate_Click" style="text-align:center;"/>

            <asp:Button ID="btnTemplate" runat="server" Text="Forwarding Template" Height="30px" Width="140px"
                  CssClass="styled-button-4" OnClick="btnTemplate_Click" style="text-align:center;"/>

            <asp:Button ID="btnHoldTemplate" runat="server" Text="Hold Template" Height="30px" Width="100px"
                  CssClass="styled-button-4" OnClick="btnHoldTemplate_Click" style="text-align:center;"/>
            <asp:Button ID="btnUnholdTemplate" runat="server" Text="Unhold Template" Height="30px" Width="120px"
                  CssClass="styled-button-4" OnClick="btnUnholdTemplate_Click" style="text-align:center;"/>
            
         </td> 
      </tr>

            <tr>
               <td style="width: 100px; height:10px; text-align:right;"> 
               </td>
               <td style="width: 300px">
               </td>
               <td style="width: 100px; text-align:right;"> 
               </td>
               <td style="text-align:right;"> 
               </td>
            </tr>
                      
 </table>
</fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend style="text-align:left; font-size:13px;">CREATED PAYMENT PHASE LIST</legend>
        <table style="width: 70%">
            <tr>
                <td>
                    
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                         OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                         GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                         PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                         CausesValidation="false" OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt"
                         OnPageIndexChanging="GridView1_PageIndexChanging">
                        
                        <Columns>
                                                                                                              
                           <asp:BoundField DataField="SL" HeaderText="SL" ItemStyle-Width="30px" />
                           <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" ItemStyle-Width="200px"/>
                           <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" ItemStyle-Width="150px"/>
                           <asp:BoundField DataField="PHASE_NAME" HeaderText="PHASE" ItemStyle-Width="70px"/>
                           <asp:BoundField DataField="payment_phase_source" HeaderText="SOURCE" ItemStyle-Width="100px"/>
                            
                           <asp:BoundField DataField="emp_count" HeaderText="Emp" ItemStyle-Width="70px"/>
                           <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtUnitId" runat="server" Text='<%#Eval("Unit_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Section" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtSectionId" runat="server" Text='<%#Eval("Section_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>  
                            
                            <asp:TemplateField HeaderText="phase_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="PhaseId" runat="server" Text='<%#Eval("payment_phase_id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="salary_year" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="SalaryYear" runat="server" Text='<%#Eval("salary_year")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="salary_month" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="SalaryMonth" runat="server" Text='<%#Eval("salary_month")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--new--%>
                            <asp:TemplateField HeaderText="payment_phase_source" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtpayment_phase_source" runat="server" Text='<%#Eval("payment_phase_source")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                        
                            <asp:TemplateField ItemStyle-Width="30px">
                               <HeaderTemplate>
                                   <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                               </HeaderTemplate>
                               <ItemTemplate>
                                   <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                               </ItemTemplate>
                           </asp:TemplateField>
                                                      
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
              
        </table>
    </fieldset>


    <fieldset>
        <legend style="text-align:left; font-size:13px;">OUT OF PAYMENT PHASE</legend>
        <table style="width: 50%; text-align:center;">
            
              <tr>
                <td>
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound">
                        <Columns>
                               
                           <asp:BoundField DataField="SL" HeaderText="SL" ItemStyle-Width="30px"/>
                             <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" ItemStyle-Width="300px"/>
                             <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" ItemStyle-Width="150px"/>
                            
                            <asp:TemplateField HeaderText="Unit" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtUnitId" runat="server" Text='<%#Eval("Unit_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Section" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtSectionId" runat="server" Text='<%#Eval("Section_Id")%>' ReadOnly="true"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField ItemStyle-Width="30px">
                               <HeaderTemplate>
                                   <asp:CheckBox ID="checkAll_X" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                               </HeaderTemplate>
                               <ItemTemplate>
                                   <asp:CheckBox ID="chkEmployeeList" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                               </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>

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
