<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="FoodDeduction.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.FoodDeduction" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type='text/javascript'>
  
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
                $('#<%=btnSave.ClientID%>').click();
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtInsideDay.ClientID %>").focus(); }) 
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
        <legend>EMPLOYEE FOOD DEDUCTION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
                <td style="text-align: right;">
                    &nbsp;</td>
                 <td style="width: 66px"></td>
                  
                <td style="text-align: right;">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
        <%--    <tr>
                <td style="text-align: right; width: 247px">
                    <asp:Label ID="lblEmployeeCode" runat="server" Text="ID : "></asp:Label>
                </td>
                <td style="width: 247px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="80px" BackColor="Yellow" Height="20px" ReadOnly="true"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 150px; height: 19px">
                    
                    &nbsp;</td>
                <td style="text-align: right; width: 150px; height: 19px">
                    
                    <asp:Label ID="Label12" runat="server" Text="Section Name :" ForeColor="Black"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>--%>
                <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label1" runat="server" Text="Card/Name :"></asp:Label>
                  &nbsp;
              </td>
              <td style="width: 275px">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="50px" Height="25px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="200" BackColor="Yellow" style="padding-left:5px; padding-right:5px; height:25px;" ReadOnly="true"></asp:TextBox>
              </td>
              <td style="width: 66px">
                  
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                       <asp:Label ID="Label3" runat="server" Text="Year/Month :"></asp:Label>
              </td>
              <td>
                 <asp:TextBox ID="txtSalaryYear" runat="server" Text="Bold" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                 <asp:TextBox ID="txtsalaryMonth" runat="server" Text="Bold" Width ="50" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="40px" Height="25px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
              </td>
              </tr>
          <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label5" runat="server" Text="Designation :"></asp:Label>
                  &nbsp;
              </td>
              <td style="width: 95px">
                   <asp:TextBox ID="txtDesignationName" runat="server" ReadOnly="true" Width="255px" Height ="25px" BackColor="Yellow" style="padding-left:5px; padding-right:5px; "></asp:TextBox>
              </td>
              <td style="width: 40px">
                  
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="20px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                  
              </td>
              <td style="text-align: right; width: 100px">
                       <asp:Label ID="Label6" runat="server" Text="Id :"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtEmployeeId" runat="server" ReadOnly="true" Width="250" BackColor="Yellow" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
              </td>
              </tr>
            <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label9" runat="server" Text="Inside Day :"></asp:Label>
                  &nbsp;
              </td>
              <td style="width: 95px">
                   <asp:TextBox ID="txtInsideDay" runat="server" Width="255px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px; "></asp:TextBox>
              </td>
              <td style="width: 66px">
                  
              </td>
              <td style="text-align: right; width: 100px">
                       <asp:Label ID="Label10" runat="server" Text="Inside(D.Amt) :"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtInsideDeductAmount" runat="server" Width="250" BackColor="Yellow" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
              </td>
              </tr>
             <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label11" runat="server" Text="Outside Day :"></asp:Label>
                  &nbsp;
              </td>
              <td style="width: 95px">
                   <asp:TextBox ID="txtOutSideDay" runat="server" Width="255px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px; "></asp:TextBox>
              </td>
              <td style="width: 66px">
                  
              </td>
              <td style="text-align: right; width: 100px">
                       <asp:Label ID="Label12" runat="server" Text="Outside(D.Amt) :"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtOutSideDeduntAmount" runat="server" Width="250" BackColor="Yellow" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px; margin-bottom: 0px;"></asp:TextBox>
              </td>
              </tr>
             <tr>
              <td style="width: 254px; text-align: right">
                  &nbsp;</td>
              <td style="width: 150px">           
                   <asp:Button ID="btnSave" runat="server" Height="25px" Text="Save" Width="55px" 
                   CssClass="styled-button-4" OnClick="btnSave_Click" />
                  <asp:Button ID="btnClear" runat="server" Height="25px" Text="Clear" Width="60px"
                   CssClass="styled-button-4" OnClick="btnClear_Click" />
              </td>
              <td style="width: 66px">
                  
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                       &nbsp;</td>
              <td>
                   &nbsp;</td>
              </tr>
        </table>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">


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
                <td colspan="4" style="text-align: left; width: 100px;">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
               
            </tr>
             <tr>
                <td colspan="5">
                    <fieldset>
                        <legend>&nbsp;Employee</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        CausesValidation="false" OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True"
                                        EnableViewState="true" GridLines="None" AllowPaging="false"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="INSIDE_DAY" HeaderText="Inside Day" />
                            <asp:BoundField DataField="OUTSIDE_DAY" HeaderText="Outside Day" />
                            <asp:BoundField DataField="INSIDE_DEDUCT_AMOUNT" HeaderText="Inside(d.Amt)" />
                            <asp:BoundField DataField="OUTSIDE_DEDUCT_AMOUNT" HeaderText="Outside(d.Amt)"/>
                            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                          <%-- <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>--%>
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
             <td colspan="5">
                <asp:GridView ID="GvFoodDeduction" runat="server" DataSourceID="" AutoGenerateColumns="False"
                 AllowSorting="True" EnableViewState="true"
                GridLines="None" AllowPaging="false"  CssClass="mGrid"
                PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GvFoodDeduction_OnSelectedIndexChanged"
                CausesValidation="false" OnRowCommand="GvFoodDeduction_RowCommand" AlternatingRowStyle-CssClass="alt"
                OnPageIndexChanging="GvFoodDeduction_PageIndexChanging" Width="1030px" Height="133px">
                 <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                          <%-- <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>--%>
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  />
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
    </fieldset>

    
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    
    

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
