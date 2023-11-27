<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="IndividualPaymentPhase.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.IndividualPaymentPhase" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type='text/javascript'>
  
    </script>
     <script language="Javascript" type="text/javascript">
         function isPaid() {
             return confirm("Do you want to pay ?");
         }
        function isDelete() {
            return confirm("Do you want to delete this ?");
        }
    </script>
    <script type="text/javascript">
        function previewFile() {
            
            //start: extention and size validation
            //1: Extention
            var extension = $("#ContentPlaceHolder3_FileUpload1").val().split('.').pop().toLowerCase();
            var validFileExtension = ['jpg', 'JPG', 'jpeg', 'JPEG', 'png', 'PNG', 'gif', 'GIF', 'bmp', 'BMP'];
            if ($.inArray(extension, validFileExtension) == -1) {
                alert("Sorry !!! Allowed image formats are '.jpeg','.jpg', '.png', '.gif', '.bmp'");
                // Clear fileuload control selected file
                $("#ContentPlaceHolder3_FileUpload1").replaceWith($("#ContentPlaceHolder3_FileUpload1").val('').clone(true));
                return;
            }

            //2: Size
            // Check and restrict the file size to 32 KB.
            var fileSize = $("#ContentPlaceHolder3_FileUpload1").get(0).files[0].size;
            if (fileSize > (204800)) {
                alert("Sorry!! Max allowed file size is 200 kb");

                $('#spnDocMsg').text("Sorry!! Max allowed file size is 32 kb").show();
                // Clear fileuload control selected file
                $("#ContentPlaceHolder3_FileUpload1").replaceWith($("#ContentPlaceHolder3_FileUpload1").val('').clone(true));
                return;
            }
            //end: extention and size validation

            <%--var preview = document.querySelector('#<%=imgEmployee.ClientID %>');
            var file = document.querySelector('#<%=FileUpload1.ClientID %>').files[0];--%>
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (file) {
                reader.readAsDataURL(file);
            } else {
                preview.src = "";
            }
        }
      

    </script>
    <script language="Javascript" type="text/javascript">
      <!--
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return true;
            }
            else {
                alert('Please Enter Only Number values.');
                return false;

            }
        }
      //-->
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
                e.preventDefault();
                $('#<%=btnCreate.ClientID%>').click();
            }
        }
    </script>
    <%--<script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtInsideDay.ClientID %>").focus(); }) 
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
                document.getElementById('<%= btnCreate.ClientID %>').click();
            }
        }
    </script>
    <script type="text/javascript">
        function AllowAlphabet(e) {
            isIE = document.all ? 1 : 0
            keyEntry = !isIE ? e.which : event.keyCode;
            if (((keyEntry >= '65') && (keyEntry <= '90')) || ((keyEntry >= '97') && (keyEntry <= '122')) || (keyEntry == '46') || (keyEntry == '32') || keyEntry == '45')
                return true;
            else {
                alert('Please Enter Only Character values.');
                return false;
            }
        }

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
    <script type="text/javascript">
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <fieldset>
        <legend runat="server" id="lgIndividualPayment" style="text-align:left; font-size:15px; font-weight:400;"></legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
                <td style="text-align: right;">
                    &nbsp;</td>
                 <td style="width: 66px"></td>
                  
                <td style="text-align: right;">

                    <%--<a href="MFSTemplate.aspx" style="text-decoration: underline;" title="MFS Template">MFS Template</a>--%>
                    <asp:Button ID="BtnMFSTemplate" runat="server" Height="25px" Text="MFS Template" Width="100px"
                   CssClass="styled-button-4" OnClick="BtnMFSTemplate_Click" style="text-align:center;"/>

                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
      
             <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label3" runat="server" Text="Payment Year/Month :"></asp:Label>
              </td>
              <td colspan="4">
                  <asp:TextBox ID="txtPaymentYear" runat="server" Text="Bold" BackColor="Yellow" style="padding-left:5px; padding-right:5px; height:25px; width:35px;"></asp:TextBox>
                 <asp:TextBox ID="txtPaymentMonth" runat="server" Text="Bold" BackColor="Yellow" style="padding-left:5px; padding-right:5px; height:25px; width:20px;"></asp:TextBox>
              </td>
             </tr>


            <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label20" runat="server" Text="Eid Type :"></asp:Label>
              </td>
              <td colspan="4">
                  <asp:DropDownList ID="ddlEidTypeId" runat="server" Width="264px" Height="28"></asp:DropDownList>
              </td>
             </tr>

         
          <tr>
              <td style="width: 254px; text-align: right">
                  
                  <asp:Label ID="lblPhase" runat="server" Text="Phase :"></asp:Label>
              </td>
              <td style="width: 95px">
                   
                  <asp:DropDownList ID="ddlPaymentPhase" runat="server" Width="264px" Height="28" >
                  </asp:DropDownList>
                   
              </td>
              <td style="width: 40px">
                 
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                       
                  &nbsp;</td>
              <td>
                   
                  &nbsp;</td>
              </tr>
             <%--
             <tr>
              <td style="width: 254px; text-align: right">
                  
                  <asp:Label ID="Label9" runat="server" Text="Payment Type :"></asp:Label>
              </td>
              <td style="width: 95px">
                   
                  <asp:DropDownList ID="ddlPaymentType" runat="server" Width="264px" Height="28" >
                  </asp:DropDownList>
                   
              </td>
              <td style="width: 40px">
                 
              </td>
              <td style="text-align: right; width: 100px">
                       
              </td>
              <td>
                   
              </td>
              </tr>
              --%>
          <tr>
              <td style="width: 254px; text-align: right">
                  
                  &nbsp;</td>
              <td style="width: 95px">
                   
                  &nbsp;</td>
              <td style="width: 40px">
                 
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                       
                  &nbsp;</td>
              <td>
                   
                  &nbsp;</td>
              </tr>
             <tr>
              <td style="width: 254px; text-align: right">
                  &nbsp;</td>
              <td colspan="4">           
                  <asp:Button ID="btnCreate" runat="server" Height="32px" Text="Create" Width="55px" style="text-align:center;"
                   CssClass="styled-button-4" OnClick="btnCreate_Click" />      
                  <asp:Button ID="btnSheet" runat="server" Text="Sheet" Height="30px" Width="50px" Visible="true" style="text-align:center;"
                  CssClass="styled-button-4" OnClick="btnSheet_Click" />
                  <asp:Button ID="btnClear" runat="server" Height="32px" Text="Clear" Width="46px" style="text-align:center;"
                   CssClass="styled-button-4" OnClick="btnClear_Click" Visible="false" />
              </td>
              </tr>
        </table>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
      <fieldset>
        <legend>Search Criteria</legend>
        <table class="style1">    
            <tr>
                   <td style="width: 254px; text-align: right; height: 25px;">
                       <asp:Label ID="Label2" runat="server" Text="Unit :"></asp:Label>
                       &nbsp;
                   </td>
                   <td style="width: 95px; height: 22px;">
                       <asp:DropDownList ID="ddlUnitId" runat="server" Width="264px" Height="28" >
                       </asp:DropDownList>
                   </td>
                   <td style="height: 22px; width: 66px;">
                           <asp:Button ID="Button1" runat="server" Height="25px" Text="Search" Width="55px" 
                               CssClass="styled-button-4" OnClick="btnSearch_Click" />
                   </td>
                   <td style="height: 22px; text-align: right; width: 100px;">
                       <asp:Label ID="Label7" runat="server" Text="Employee Id :"></asp:Label>
                   </td>
                   <td style="height: 22px">
                       <asp:TextBox ID="txtEmpId" runat="server" Width="250" BackColor="White" TabIndex="16" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                   </td>
              </tr>
            <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label4" runat="server" Text="Section :"></asp:Label>
                  &nbsp;
              </td>
              <td style="width: 95px">
                  <asp:DropDownList ID="ddlSectionId" runat="server" Width="264px" Height="28" >
                  </asp:DropDownList>
              </td>
              <td style="width: 66px">                  
              </td>
              <td style="text-align: right; width: 100px">
                       <asp:Label ID="Label8" runat="server" Text="Card No :"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtEmpCardNo" runat="server" Width="250" BackColor="White" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
              </td>
              </tr>

            <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label1" runat="server" Text="Eid Type :"></asp:Label>
                  </td>
              <td style="width: 95px">
                  <asp:DropDownList ID="ddlEidTypeIdSearch" runat="server" Width="264px" Height="28"></asp:DropDownList>
              </td>
              <td style="width: 66px">                  
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                  <asp:Label ID="lblDesignation" runat="server" Text="Designation :"></asp:Label>
                  <%--<asp:Label ID="lblPaymentType" runat="server" Text="Payment Type :"></asp:Label>--%>
                </td>
              <td>
                   
                  <%--<asp:DropDownList ID="ddlPaymentTypeSearch" runat="server" Width="264px" Height="28" >
                  </asp:DropDownList>--%>
                   <asp:DropDownList ID="ddlDesignation" runat="server" Width="264px" Height="28" >
                  </asp:DropDownList>
                </td>
              </tr>

            <tr>
              <td style="width: 254px; text-align: right">
                  
               <asp:Label ID="lblPhaseSearch" runat="server" Text="Phase :"></asp:Label>   
              </td>
              <td style="width: 95px">                
                  <asp:DropDownList ID="ddlPaymentPhaseSearch" runat="server" Width="264px" Height="28" >
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
              <td style="width: 254px; text-align: right">                  
              </td>
              <td style="width: 95px">
                                 
              </td>
              <td style="width: 66px">                  
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                       &nbsp;</td>
              <td>
                   &nbsp;</td>
              </tr>

            <%--<tr>
              <td style="width: 254px; text-align: right">
                  &nbsp;</td>
              <td style="width: 95px">
                  &nbsp;</td>
              <td style="width: 66px">
                  
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                       &nbsp;</td>
              <td>
                   &nbsp;</td>
              </tr>--%>
             <tr>
                <td colspan="4" style="text-align: left; width: 100px;">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>              
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
     <table style="width: 100%">
         <tr>
            <td colspan="2">
            <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
            CausesValidation="false" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True"
            EnableViewState="true" GridLines="None" AllowPaging="false" DataKeyNames="EMPLOYEE_ID" 
            CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
            AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
                <Columns>   
                  <asp:BoundField DataField="SL" HeaderText="SL NO" />
                  <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                  
                  <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                  <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />

                  <asp:BoundField DataField="unit_name" HeaderText="UNIT" />
                  <asp:BoundField DataField="section_name" HeaderText="SECTION" />
                  <asp:BoundField DataField="phase_name" HeaderText="Phase" />
                  <asp:BoundField DataField="payment_type_name" HeaderText="Payment Type Name" />
                  <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />

                  <asp:TemplateField HeaderText="PatmentPhaseId" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                  <ItemTemplate>
                      <asp:TextBox ID="txtPatmentPhaseId" runat="server" Text='<%#Eval("phase_id")%>' ReadOnly="true"></asp:TextBox>
                  </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="PatmentTypeId" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                  <ItemTemplate>
                      <asp:TextBox ID="txtPatmentTypeId" runat="server" Text='<%#Eval("payment_type_id")%>' ReadOnly="true"></asp:TextBox>
                  </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="EidTypeId" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                  <ItemTemplate>
                      <asp:TextBox ID="txtEidTypeId" runat="server" Text='<%#Eval("eid_type_id")%>' ReadOnly="true"></asp:TextBox>
                  </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                       <ItemTemplate>
                           <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                               AlternateText="Delete"
                               Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                               Height="25px" Visible="true" />
                       </ItemTemplate>
                   </asp:TemplateField>

                 <%-- <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                  <asp:BoundField DataField="payment_type_id" HeaderText="payment_type_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>--%>
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
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <table>
   <tr> 
             <td colspan="5">
                <asp:GridView ID="GvPayableEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                 AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"  CssClass="mGrid"
                PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GvPayableEmployeeList_OnSelectedIndexChanged"
                CausesValidation="false" OnRowCommand="GvPayableEmployeeList_RowCommand" AlternatingRowStyle-CssClass="alt"
                OnPageIndexChanging="GvPayableEmployeeList_PageIndexChanging" Width="1030px" Height="133px">
                 <Columns>                        
                      
                      <%-- <asp:BoundField DataField="SL" HeaderText="SL NO" />--%>
             <asp:TemplateField>
               <HeaderTemplate>
                        SL NO
               </HeaderTemplate>
              <ItemTemplate>
                  <%# Container.DataItemIndex + 1 %>
              </ItemTemplate>
          </asp:TemplateField>
                       <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />                       
                       <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                          <ItemTemplate>
                            <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("Employee_Id")%>' ReadOnly="true"></asp:TextBox>
                          </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                       <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                      <asp:TemplateField ItemStyle-Width="30px">
                         <HeaderTemplate>
                             <asp:CheckBox ID="checkAll_X" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                         </HeaderTemplate>
                         <ItemTemplate>
                            <asp:CheckBox ID="chkEmployeeList" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                         </ItemTemplate>
                       </asp:TemplateField>
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
   </table>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">   
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
