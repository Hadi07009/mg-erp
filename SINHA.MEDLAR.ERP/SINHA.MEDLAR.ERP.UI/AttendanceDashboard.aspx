<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AttendanceDashboard.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AttendanceDashboard" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type='text/javascript'>
  
    </script>
     <script language="Javascript" type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");
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
                <%--$('#<%=btnSave.ClientID%>').click();--%>
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
              <%--  document.getElementById('<%= btnSave.ClientID %>').click();--%>
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
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
                <td style="text-align: right;">
                    &nbsp;</td>
                 <td style="width: 66px"></td>                 
                <td style="text-align: right;">

                    <asp:CheckBox ID="ChkStandBy" runat="server" Text="StandBy" AutoPostBack="true"
                        CssClass="CheckBox" Font-Bold="True" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>   
           
        </table>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <fieldset>
        <legend>ATTENDANCE DASHBOARD</legend>
         <asp:TextBox ID="txtAttendanceDashBoardID" runat="server" Width="0px" Visible="false"></asp:TextBox>
        <table style="width: 100%">    
            <tr>
              <td style="width: 100px; height:25px; text-align: right">
                  <asp:Label ID="lblogdate" runat="server" Text="Date "></asp:Label>
              </td>
                 <td style="width: 150px">
                   <asp:TextBox ID="dtpLogDate" runat="server" Width="150px" Height ="25px" CssClass="date" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>
              <td style="width: 100px; text-align: right">
                  <asp:Label ID="lblPresent" runat="server" Text="Present(All)"></asp:Label>
              </td>
              <td style="width: 150px">
                   <asp:TextBox ID="txtPresent" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>
                
              <td style="width: 100px; text-align: right">
                  Day Off (HO)</td>
              <td style="width: 50px">
                   <asp:TextBox ID="txtDayOffOther" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
                  </td>

              <td style="width: 100px; text-align: right">
                  <asp:Label ID="lblActive" runat="server" Text="Active"></asp:Label>
              </td>
              <td style="width: 50px">
                   <asp:TextBox ID="txtActive" runat="server" Width="150px" Height ="25px" ReadOnly="true" BackColor="Yellow" style="padding-left:5px; padding-right:5px; "></asp:TextBox>
             </td>                     

              </tr>
               <tr>
             
             

             <td style="text-align: right; width:100px">
                 <asp:Label ID="lblLeave" runat="server" Text="Leave"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtLeave" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>
             
              <td style="text-align: right; width:100px">
                 <asp:Label ID="lblOther" runat="server" Text="Leave (HO)"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtLeaveOther" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>
            
               
              <td style="width: 100px; height:25px; text-align: right">
                  <asp:Label ID="lblRrcruitment" runat="server" Text="Recruitment(All)"></asp:Label>
              </td>
                <td style="width: 150px">
                   <asp:TextBox ID="txtRecruitment" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
               </td>
            
               <td style="width: 100px; text-align: right">
                  <asp:Label ID="lblOtherActive" runat="server" Text="Active (HO)"></asp:Label>
              </td>
              <td style="width: 50px">
                   <asp:TextBox ID="txtOtherActive" runat="server" Width="150px" Height ="25px" ReadOnly="true" BackColor="Yellow" style="padding-left:5px; padding-right:5px; "></asp:TextBox>
             </td>
                                          
             
              </tr>
             <tr>
                      
               <td style="text-align: right; width:100px">
                 <asp:Label ID="lblOutDuty" runat="server" Text="Out Duty"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtOutDuty" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>
                <td style="text-align: right; width:100px">
                 <asp:Label ID="lblOutDutyOther" runat="server" Text="Out Duty (HO)"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtOutDutyOther" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>
              
                 <td style="width: 100px; height:25px; text-align: right">
                  <asp:Label ID="lblUnrecognizedToMachine" runat="server" Text="Unrecognized To Machine(All)"></asp:Label>
              </td>
                <td style="width: 150px">
                   <asp:TextBox ID="txtUnrecognizedToMachine" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
               </td>
              
              
              <%--<td>
              <asp:TextBox ID="txtAttendanceDashBoardID" runat="server" Width="16px" Height ="25px" Visible="false" BackColor="White" style="padding-left:5px; padding-right:5px; "></asp:TextBox>
               </td>--%>

              
              
               <td style="width: 100px; text-align: right">
                  <asp:Label ID="lblPunch" runat="server" Text="Punch"></asp:Label>
              </td>
              <td style="width: 50px">
                   <asp:TextBox ID="txtPunch" runat="server" Width="150px" Height ="25px" ReadOnly="true" BackColor="Yellow" style="padding-left:5px; padding-right:5px; "></asp:TextBox>
                  
               </td> 


                         
              </tr>
              <tr>
               <td style="text-align: right; width:100px">
                 <asp:Label ID="lblNightDuty" runat="server" Text="Night Duty"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtNightDuty" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>
                 
               <td style="text-align: right; width:100px">
                 <asp:Label ID="lblNightDutyOther" runat="server" Text="Night Duty (HO)"></asp:Label>
              </td>
              <td>
                   <asp:TextBox ID="txtNightDutyOther" runat="server" Width="150px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
              </td>

               <td style="width: 100px; text-align: right">
                  <%--<asp:Label ID="lblPunchInvalid" runat="server" Text="Punch Invalid(All)"></asp:Label>--%>
              </td>
              <td style="width: 50px">
                   <%--<asp:TextBox ID="txtPunchInvalid" runat="server" Width="150px" Height ="25px" ReadOnly="true" BackColor="Yellow" style="padding-left:5px; padding-right:5px; "></asp:TextBox>--%>
               </td>

               
              <td style="text-align: right; width:100px">
                 <asp:Label ID="lblOtherPunch" runat="server" Text="Punch (HO)"></asp:Label>
               </td>
              <td>
                   <asp:TextBox ID="txtOtherPunch" runat="server" Width="150" ReadOnly="true" BackColor="Yellow"  style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
               </td>                  
              </tr>
              <tr>
              <td style="width: 100px; text-align: right">
                  &nbsp;</td>
              <td style="width: 50px">
                  &nbsp;</td>
            <td>
                &nbsp;</td>
                         
              </tr>
             <tr>
              <td style="width: 150px; text-align: right">
                  &nbsp;</td>
              <td style="width: 100px">           
                   <asp:Button ID="btnSave" runat="server" Height="30px" Text="Save" Width="50px"  
                   CssClass="styled-button-4" OnClick="btnSave_Click" />
                  <asp:Button ID="Button3" runat="server" Height="30px" Text="Clear" Width="50px" 
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

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">


    <fieldset>
        <legend>Search Criteria</legend>
        <table class="style1">     
              <tr>
                  <td style="width: 200px; text-align: right; height: 25px;">
                      <asp:Label ID="Label2" runat="server" Text="From Date :"></asp:Label>
                      &nbsp;
                  </td>
                  <td style="width: 95px; height: 22px;">
                   <asp:TextBox ID="dtpFromDate" runat="server" Width="202px" Height ="25px" CssClass="date" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
                  </td>
                  <td style="height: 22px; width: 66px;">
                          <asp:Button ID="btnSearch" runat="server" Height="30px" Text="Search" Width="55px" 
                              CssClass="styled-button-4" OnClick="btnSearch_Click" />
                  </td>
                  <td style="height: 22px; text-align: right; width: 100px;">
                      <asp:Label ID="Label1" runat="server" Text="Email Address :"></asp:Label>
                  </td>
                  <td style="height: 22px">
                      <asp:TextBox ID="txtEmailAddress" runat="server" Width="302px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
                      <asp:Button ID="btnSendMail" runat="server" Height="30px" Text="Send" Width="55px" 
                              CssClass="styled-button-4" OnClick="btnSendMail_Click" />
                  </td>
              </tr>
              <tr>
                  <td style="width: 200px; text-align: right; height: 25px;">
                      <asp:Label ID="Label7" runat="server" Text="To Date:"></asp:Label>
                  </td>
                  <td style="width: 95px; height: 22px;">
                   <asp:TextBox ID="dtpToDate" runat="server" Width="201px" Height ="25px" CssClass="date" BackColor="White" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
                  </td>
                  <td style="height: 22px; width: 66px;">
                          
                  </td>
                  <td style="height: 22px; text-align: right; width: 100px;">
                      &nbsp;</td>
                  <td style="height: 22px">
                      &nbsp;</td>
              </tr>
             <tr>
                <td colspan="4" style="text-align: left; width: 100px;">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>

    
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <table style="width: 100%">
        <tr>
          <td colspan="2">
              <asp:GridView ID="GvAttendanceDashboard" runat="server" DataSourceID="" AutoGenerateColumns="False"
                  CausesValidation="false" OnRowDataBound="GvAttendanceDashboard_OnRowDataBound" AllowSorting="True"
                  EnableViewState="true" GridLines="None" AllowPaging="false" DataKeyNames="dashboard_id" 
                  CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GvAttendanceDashboard_OnSelectedIndexChanged"
                  AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GvAttendanceDashboard_PageIndexChanging" OnRowDeleting="GvAttendanceDashboard_RowDeleting">
           <Columns>
               <asp:BoundField DataField="SL" HeaderText="SL" />
               <asp:BoundField DataField="log_date" HeaderText="Date" />
               <asp:BoundField DataField="present" HeaderText="Present(All)" />
               <asp:BoundField DataField="day_off_other" HeaderText="Day Off(HO)"/>
               <asp:BoundField DataField="leave" HeaderText="Leave"/>
               <asp:BoundField DataField="leave_other" HeaderText="Leave(HO)"/>
               <asp:BoundField DataField="out_duty" HeaderText="Out Duty" />
               <asp:BoundField DataField="out_duty_other" HeaderText="Out Duty(HO)" />
               <asp:BoundField DataField="night_duty" HeaderText="Night Duty" />
               <asp:BoundField DataField="night_duty_other" HeaderText="Night Duty(HO)" />
               <asp:BoundField DataField="recruitment" HeaderText="Recruitment" />
               <asp:BoundField DataField="unrecognized_to_machine" HeaderText="Unrecognized Machine" />
               <asp:BoundField DataField="punch" HeaderText="Punch"/>
               <asp:BoundField DataField="punch_other" HeaderText="Punch(HO)"/>
               <%--<asp:BoundField DataField="punch_invalid" HeaderText="Punch Invalid"/>--%>
               <asp:BoundField DataField="active" HeaderText="Active"/>
               <asp:BoundField DataField="active_other" HeaderText="Active(HO)"/>
              
               <asp:BoundField DataField="dashboard_id" HeaderText="dashboard_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>    

               <asp:BoundField DataField="stand_by_yn" HeaderText="StandBy"/>

              
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
