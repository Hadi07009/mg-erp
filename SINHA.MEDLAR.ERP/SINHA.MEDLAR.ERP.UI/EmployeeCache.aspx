<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeeCache.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeCache" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type='text/javascript'>
                
        //$(document).ready(function () {
        //    $(window).bind("beforeunload", function () {
        //        $.ajax({
        //            type: "POST",
        //            url: "EmployeeBasic.aspx/BrowserCloseMethod",
        //            //data: JSON.stringify({ designationId: designationId }),
        //            dataType: "json",
        //            contentType: "application/json; charset=utf-8",
        //            success: function (Result) {
        //            },
        //            error: function (data) {
        //                alert("error found");
        //            }
        //        });
        //    });
        //});
               

        //$(document).ready(function () {
        //    $('#form1 input').keydown(function (e) {
        //        if (e.keyCode == 13) {
        //            if ($(':input:eq(' + ($(':input').index(this) + 1) + ')').attr('type') == 'submit') {// check for submit button and submit form on enter press
        //                return true;
        //            }
        //            $(':input:eq(' + ($(':input').index(this) + 1) + ')').focus();
        //            return false;
        //        }
        //    });
        //    $('#ContentPlaceHolder3_ddlDesignationId').change(function () {
        //        GetGradeByDesignationId();
        //    });
        //});

        //function GetGradeByDesignationId() {
        //    var designationId = $("#ContentPlaceHolder3_ddlDesignationId option:selected").val();
        //    $.ajax({
        //        type: "POST",
        //        url: "EmployeeBasic.aspx/GetGradeByDesignationId",
        //        data: JSON.stringify({ designationId: designationId }),
        //        dataType: "json",
        //        contentType: "application/json; charset=utf-8",
        //        success: function (Result) {
                    
        //            if (Result.d == "-1") {
        //            }
        //            else {
        //                //alert(Result.d);
        //                $("#ContentPlaceHolder3_ddlGradeNo").val(Result.d);
        //            }
        //        },
        //        error: function (data) {
        //            alert("error found");
        //        }
        //    });
        //}

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
        <%--function previewSignatureFile() {
            var preview = document.querySelector('#<%=ImgSignature.ClientID %>');
            var file = document.querySelector('#<%=FileSignature.ClientID %>').files[0];
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
        --%>
        //Start: New
        //var searchInput = $("#ctl00$ContentPlaceHolder2$txtHusbandName");
        //searchInput
        //  .putCursorAtEnd()
        //  .on("focus", function () { 
        //      searchInput.putCursorAtEnd()
        //  });
        //End

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
 <%--   <script type="text/javascript">
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
                //document.getElementById('<%= btnSearchEmployee.ClientID %>').click();
            }
        }
    </script>--%>
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
        <legend>EMPLOYEE BASIC INFORMATION</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="2">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small" ForeColor="Purple"></asp:Label>
                </td>
                <td style="text-align: right;" colspan="2">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 200px">
                    <asp:Label ID="lblEmployeeCode" runat="server" Text="ID : "></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="120px" BackColor="Yellow" Height="20px"></asp:TextBox>
                    <asp:TextBox ID="txtSL" runat="server" Width="25px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                    <asp:Button ID="btnNext" runat="server" Height="25px" Text="&gt;&gt;" CssClass="styled-button-4"
                        Width="30px" OnClick="btnNext_Click" />
                    <asp:Button ID="btnPrevious" runat="server" Height="25px" Text="&lt;&lt;" CssClass="styled-button-4"
                        Width="30px" OnClick="btnPrevious_Click" />
                    <asp:TextBox ID="txtSLNew" runat="server" Width="16px" Height="21px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                    <asp:TextBox ID="txtCacheId" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True" Visible="false"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 100px; height: 19px">
                    <asp:Label ID="lblMaritalStatus10" runat="server" Text="Title :" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTitleId" runat="server" Width="255px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 200px">
                    <asp:Label ID="lblMaritalStatus14" runat="server" Text="Card No :" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtCardNo" runat="server" Width="250px" Font-Bold="True"
                        placeHolder="CARD NO"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 100px; height: 19px">
                    <asp:Label ID="Label1" runat="server" Text="Punch Code :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPunchCode" runat="server" Width="250px" 
                        placeHolder="PUNCHING CODE" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 200px">
                    <asp:Label ID="lblEmployeeName" runat="server" Text="Full Name :" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 300px">
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="250px" placeHolder="EMPLOYEE NAME" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 100px; height: 19px">  
                  <asp:Label ID="Label14" runat="server" Text="Name(Bng) :" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeNameBangla" runat="server" Width="250px" Font-Names="KarnaphuliMJ"
                        placeHolder="evsjvq bvg wjLyb" MaxLength="100" Font-Bold="True"
                        Font-Size="Small"></asp:TextBox>
                </td>
            </tr>
                    
    
                                        
             <tr>
                <td style="text-align: right; width: 200px; height: 19px;" >
                    
                    <asp:Label ID="Label5" runat="server" Text="Joining Date :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; text-align:left; width:300px;">
                    <asp:TextBox ID="dtpJoiningDate" runat="server" Width="250px" CssClass="date"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 100px; height: 19px">

                    <asp:Label ID="Label13" runat="server" Text="Employee Type :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px;">
                    <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="255px" Height="22px">
                    </asp:DropDownList>
                </td>                                 
                

            </tr>
            <tr>
                                                                 
                <td style="text-align: right; width: 200px; height: 19px">
                    
                    <asp:Label ID="Label9" runat="server" Text="Designation :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width:300px;">
                    <asp:DropDownList ID="ddlJoiningDesignationId" runat="server" Width="255px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="text-align: right; width: 100px; height: 19px">
                    Grade :</td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtGradeNo" runat="server" Width="250px" BackColor="White" 
                     ReadOnly="true" placeHolder="Grade NO" Font-Bold="false"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="text-align: right; width: 200px; height: 19px">
                    
                    <asp:Label ID="Label10" runat="server" Text="Unit Name :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; text-align:left; width:300px;">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="255px" Height="22px">
                    </asp:DropDownList>
                </td>
                                                 
                <td style="text-align: right; width: 100px; height: 19px">
                    
                    <asp:Label ID="Label12" runat="server" Text="Section Name :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="255px" Height="22px">
                    </asp:DropDownList>
                </td>

            </tr>
            
             
            <tr>
                <td style="text-align: right; width: 200px; height: 19px">
                    <asp:Label ID="lblMaritalStatus3" runat="server" Text="NID No :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 300px;">
                    <asp:TextBox ID="txtNidNo" runat="server" Width="250px" 
                        Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 100px; height: 19px">
                    <asp:Label ID="lblEmployeeName4" runat="server" Text="Gender :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 20px">
                    <asp:DropDownList ID="ddlGenderId" runat="server" Width="255px" OnSelectedIndexChanged="ddlGenderId_SelectedIndexChanged"
                        Height="22px">
                    </asp:DropDownList>
                </td>
                
            </tr>
             <tr>
                 <td style="text-align: right; width: 200px; height: 19px">
                     <asp:Label ID="Label15" runat="server" Text="Religion :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 20px; width:300px;">
                    <asp:DropDownList ID="ddlReligionId" runat="server" Width="255px" Height="22px">
                    </asp:DropDownList>
                </td>

                <%--<td style="text-align: right; width: 100px; height: 19px">
                    
                    <asp:Label ID="Label11" runat="server" Text="Active Employee :"></asp:Label>
                </td>
                <td style="height: 19px; text-align:left">
                    <asp:CheckBox ID="chkAcftiveYn" runat="server" Text="Yes" />
                </td>--%>
                                                          
            </tr>
            
            <tr>
               <td style="text-align: right; height: 10px">
               </td>                                           
            </tr>

            <tr>
                <td style="text-align: right; width: 200px; height: 19px">
                    &nbsp;
                </td>

                <td style="height: 19px;" colspan="3">
                    
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="60px"
                        CssClass="styled-button-4" OnClick="btnSheet_Click" />
         
                    
                    <asp:Button ID="btnDeletedEmpSheet" runat="server" Height="31px" Text="Sheet(Deleted Emp)" Width="123px"
                        CssClass="styled-button-4" OnClick="btnDeletedEmpSheet_Click" />
         
                    
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="60px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                </td>
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
                                                <asp:DropDownList ID="ddlEmpUnitId" runat="server" Width="264px" Height="28" >
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="Button1" runat="server" Height="25px" Text="Search" Width="55px" 
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                            </td>
                                            <td style="height: 22px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label3" runat="server" Text="Create From :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtFromDate" runat="server" Width="250" BackColor="White" CssClass="date" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                            </td>
                                        </tr>

            <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label4" runat="server" Text="Section :"></asp:Label>
                  &nbsp;
              </td>
              <td style="width: 95px">
                  <asp:DropDownList ID="ddlEmpSectionId" runat="server" Width="264px" Height="28" >
                  </asp:DropDownList>
              </td>
              <td style="width: 66px">
                  <asp:Button ID="Button2" runat="server" Height="25px" Text="Sheet" Width="55px"  Visible="false"
                                CssClass="styled-button-4" OnClick="btnSheet_Click" />
              </td>
              <td style="text-align: right; width: 100px">
                 <asp:Label ID="Label6" runat="server" Text="Create To :"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtToDate" runat="server" Width="250" BackColor="White" CssClass="date"  style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
              </td>
              </tr>
               <tr>
                   <td style="text-align: right" class="auto-style3">
                       <asp:Label ID="Label7" runat="server" Text="Employee Id :"></asp:Label>
                       &nbsp;
                   </td>
                   <td style="text-align: right; width:163px">
                   <asp:TextBox ID="txtEmpId" runat="server" Width="250" BackColor="White" TabIndex="16" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                   </td>

                   <td style="width: 66px">&nbsp;
                       </td>
              <td style="text-align: right; width: 100px">
                  <asp:Label ID="Label43" runat="server" Text="Approved? :"></asp:Label>
                  &nbsp;
              </td>
              <td>
              <asp:DropDownList ID="ddlApproved" runat="server" Width="264px" Height="28">
                  <%--<asp:ListItem Value="" Text="Please Select" Selected="True">
                  </asp:ListItem>--%>
                  <asp:ListItem Value="Y" Text="Approved" >
                  </asp:ListItem>
                  <asp:ListItem Value="N" Text="Not Approved">
                  </asp:ListItem>
              </asp:DropDownList>          
              </td>
            </tr>


              <tr>
                   <td style="text-align: right" class="auto-style3">
                       <asp:Label ID="Label8" runat="server" Text="Card No :"></asp:Label>
                       &nbsp;
                   </td>
                   <td style="text-align: right; width:163px">
                   <asp:TextBox ID="txtEmpCardNo" runat="server" Width="250" BackColor="White" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                   </td>

                   <td style="width: 66px">&nbsp;
                       </td>
              <td style="text-align: right; width: 100px">
                  
                  &nbsp;
              </td>
              <td>
                        
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
                <asp:GridView ID="GvEmployeeCache" runat="server" DataSourceID="" AutoGenerateColumns="False"
                 AllowSorting="True" EnableViewState="true"
                GridLines="None" AllowPaging="false"  CssClass="mGrid"
                PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GvEmployeeCache_OnSelectedIndexChanged"
                CausesValidation="false" OnRowCommand="GvEmployeeCache_RowCommand" AlternatingRowStyle-CssClass="alt"
                OnPageIndexChanging="GvEmployeeCache_PageIndexChanging">
                <Columns>
                
                <asp:BoundField DataField="cache_id" HeaderText="cache_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                <asp:BoundField DataField="serial_no" HeaderText="Serial No" />                    
                <asp:BoundField DataField="employee_name" HeaderText="Name" ItemStyle-Width="100" />                          
                <asp:BoundField DataField="card_no" HeaderText="Card No" ItemStyle-Width="100" />
                <asp:BoundField DataField="employee_id" HeaderText="ID" ItemStyle-Width="100" />                                             

                <asp:BoundField DataField="designation_name" HeaderText="Designation" ItemStyle-Width="100" />
                <asp:BoundField DataField="joining_date" HeaderText="Joining Date" ItemStyle-Width="100" />
                <asp:BoundField DataField="create_date" HeaderText="Entry Date" ItemStyle-Width="100" />                                       
                <asp:BoundField DataField="unit_name" HeaderText="Unit" ItemStyle-Width="150" />
                <asp:BoundField DataField="section_name" HeaderText="Section" ItemStyle-Width="150" />
                <asp:BoundField DataField="approve_yn" HeaderText="Approve?" ItemStyle-Width="150" />
                <asp:BoundField DataField="recognize_yn" HeaderText="Recognize?" ItemStyle-Width="100" />                                    
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
