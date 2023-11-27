<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeeBasic.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeBasicInfo" %>

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
               

        $(document).ready(function () {
            $('#form1 input').keydown(function (e) {
                if (e.keyCode == 13) {
                    if ($(':input:eq(' + ($(':input').index(this) + 1) + ')').attr('type') == 'submit') {// check for submit button and submit form on enter press
                        return true;
                    }
                    $(':input:eq(' + ($(':input').index(this) + 1) + ')').focus();
                    return false;
                }
            });
            $('#ContentPlaceHolder3_ddlDesignationId').change(function () {
                GetGradeByDesignationId();
            });
        });

        function GetGradeByDesignationId() {
            var designationId = $("#ContentPlaceHolder3_ddlDesignationId option:selected").val();
            $.ajax({
                type: "POST",
                url: "EmployeeBasic.aspx/GetGradeByDesignationId",
                data: JSON.stringify({ designationId: designationId }),
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (Result) {
                    
                    if (Result.d == "-1") {
                    }
                    else {
                        //alert(Result.d);
                        $("#ContentPlaceHolder3_ddlGradeNo").val(Result.d);
                    }
                },
                error: function (data) {
                    alert("error found");
                }
            });
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

            var preview = document.querySelector('#<%=imgEmployee.ClientID %>');
            var file = document.querySelector('#<%=FileUpload1.ClientID %>').files[0];
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
        function previewSignatureFile() {
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
                document.getElementById('<%= btnSearchEmployee.ClientID %>').click();
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
        <tr>
            <td colspan="2">
                <fieldset>
                    <legend>SEARCH RESULT SUMMERY</legend>
                    <table style="width: 100%">
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                    AllowSorting="True" OnSorting="gvEmployeeList_Sorting" EnableViewState="true"
                                    GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                    OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_OnRowEditing" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                    AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging"
                                    OnRowDataBound="GridView1_OnRowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="SL" HeaderText="SL" />
                                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                        <asp:BoundField DataField="JOINING_DATE" HeaderText="J.D" />
                                        <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                                        <asp:BoundField DataField="JOB_TYPE_NAME" HeaderText="JOB TYPE" />
                                        <asp:TemplateField HeaderText="Image">
                                            <ItemTemplate>
                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "ImageHandler.ashx?employee_id="+ Eval("employee_id") %>'
                                                    Height="50px" Width="50px" Style="cursor: pointer" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select" ImageUrl="~/images/select_png.jpg"
                                                   AlternateText="Select"   Style="cursor: pointer" Text="..." CausesValidation="false"  />
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
        <%--</td>--%>
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
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
                <td style="text-align: right;" colspan="2">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px">
                    <asp:Label ID="lblEmployeeCode" runat="server" Text="ID : "></asp:Label>
                </td>
                <td style="width: 247px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="75px" BackColor="Yellow" Height="20px" Enabled="false" ></asp:TextBox>
                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="..." Width="30px" CssClass="styled-button-4"
                        OnClick="btnSearch_Click" />
                    <asp:Button ID="btnNext" runat="server" Height="25px" Text="&gt;&gt;" CssClass="styled-button-4"
                        Width="30px" OnClick="btnNext_Click" />
                    <asp:Button ID="btnPrevious" runat="server" Height="25px" Text="&lt;&lt;" CssClass="styled-button-4"
                        Width="30px" OnClick="btnPrevious_Click" />
                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus10" runat="server" Text="Title :" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlTitleId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px">
                    <asp:Label ID="lblMaritalStatus14" runat="server" Text="Card No :" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 247px">
                    <asp:TextBox ID="txtCardNo" runat="server" Width="211px" BackColor="#CCCCCC" Font-Bold="True"
                        placeHolder="CARD NO"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus18" runat="server" Text="Punch Code :" ForeColor="Red"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPunchCode" runat="server" Width="211px" BackColor="#CCCCCC" OnTextChanged="txtEmployeeName2_TextChanged"
                        placeHolder="PUNCHING CODE" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px">
                    <asp:Label ID="lblEmployeeName" runat="server" Text="Full Name :" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 247px">
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="211px" BackColor="#CCCCCC"
                        placeHolder="EMPLOYEE NAME" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 108px;">
                    &nbsp;<asp:Label ID="lblEmployeeName0" runat="server" Text="Name(Bng) :"></asp:Label>
                  
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeNameBangla" runat="server" Width="211px" Font-Names="KarnaphuliMJ"
                        placeHolder="evsjvq bvg wjLyb" MaxLength="100" BackColor="#CCCCCC" Font-Bold="True"
                        Font-Size="Small"></asp:TextBox>
                </td>
            </tr>
                  <tr>
                <td style="text-align: right; width: 247px">
                    <asp:Label ID="lblEmployeeName1" runat="server" Text="Father Name" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 247px">
                    <asp:TextBox ID="txtFatherName" runat="server" Width="211px" BackColor="White" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 108px;">
                    <asp:Label ID="lblFatherNameBangla" runat="server" Text="Father Name(Bng) :" ForeColor="Black"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtFatherNameBangla" runat="server" Width="211px" Font-Names="KarnaphuliMJ"
                        placeHolder="evsjvq bvg wjLyb" MaxLength="100" BackColor="#CCCCCC" Font-Bold="True"
                        Font-Size="Small"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 247px">
                    <asp:Label ID="lblEmployeeName5" runat="server" Text="Mother Name :" ForeColor="Red"></asp:Label>
                </td>
                <td style="width: 247px">
                    <asp:TextBox ID="txtMotherName" runat="server" Width="211px" BackColor="White" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="text-align: right; width: 108px;">
                    <asp:Label ID="lblMotherNameBangla" runat="server" Text="Mother Name(Bng) :" ForeColor="Black" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMotherNameBangla" runat="server" Width="211px" Font-Names="KarnaphuliMJ"
                        placeHolder="evsjvq bvg wjLyb" MaxLength="100" BackColor="#CCCCCC" Font-Bold="True"
                        Font-Size="Small"></asp:TextBox>
                </td>
            </tr>

            <tr>             
                <td style="text-align: right; width: 247px; height: 19px"">
                    <asp:Label ID="Label5" runat="server" Text="NID  :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtNIDNo" runat="server" Width="211px" BackColor="White"
                        OnTextChanged="txtEmployeeName2_TextChanged" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblBirthRegistrationNo" runat="server" Text="Birth Reg. No :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtBirthRegistrationNo" runat="server" Width="211px" BackColor="White" 
                        placeHolder="Birth Cert No" Font-Bold="false"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>

            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus3" runat="server" Text="Mobile No :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtMobileNo" runat="server" Width="211px" BackColor="White" OnTextChanged="txtEmployeeName2_TextChanged"
                        Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus4" runat="server" Text="Phone No :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtPhoneNo" runat="server" Width="211px" BackColor="White" OnTextChanged="txtEmployeeName2_TextChanged"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblBKashNo" runat="server" Text="Bkash No :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtBKashNo" runat="server" Width="211px" BackColor="White"  Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblRocketNo" runat="server" Text="Rocket No :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtRocketNo" runat="server" Width="211px" BackColor="White" 
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblEmployeeName2" runat="server" Text="Date of Birth :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="dtpDateOfBirth" runat="server" Width="211px" BackColor="#CCCCCC"
                        CssClass="date"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblEmployeeName4" runat="server" Text="Gender :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlGenderId" runat="server" Width="215px" OnSelectedIndexChanged="ddlGenderId_SelectedIndexChanged"
                        Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus" runat="server" Text="Marital Status :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlMaritalStatusId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalRelision" runat="server" Text="Religion :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlReligionId" runat="server" Width="215px" Height="22px" ForeColor="Red">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus2" runat="server" Text="Spouse Name :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtHusbandName" runat="server" Width="211px" BackColor="White" OnTextChanged="txtEmployeeName2_TextChanged"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus15" runat="server" Text="Spouse Occupation :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtHusbandOccupation" runat="server" Width="211px" BackColor="White"
                        OnTextChanged="txtEmployeeName2_TextChanged" ></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus16" runat="server" Text="Emergency No :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtEmergencyContactNo" runat="server" Width="211px" BackColor="White"
                        placeHolder="EMERGENCY CONTACT NO" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus5" runat="server" Text="Email Address :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtEmailAddress" runat="server" Width="211px" BackColor="White"
                        OnTextChanged="txtEmployeeName2_TextChanged" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus11" runat="server" Text="Division :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlDivisionId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus12" runat="server" Text="District :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlDistrictId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus1" runat="server" Text="Blood Group :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlBloodGroupId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus9" runat="server" Text="Nationality :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlNationalityId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus13" runat="server" Text="First Salary :" ForeColor="Green" Font-Bold="true"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtFirstSalary" runat="server" Width="211px" BackColor="White" OnTextChanged="txtEmployeeName2_TextChanged"
                        placeHolder="FIRST SALARY" Font-Bold="True"></asp:TextBox>
                </td>
                
               
                 <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblHiddenSalary" runat="server" Text="Hidden Salary :"></asp:Label>
                </td>
                <td style="height: 19px;">
                    <asp:TextBox ID="txtHiddenSalary" runat="server" Width="211px" BackColor="White"
                        placeHolder="Salary" Font-Bold="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus6" runat="server" Text="Present Address :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtPresentAddress" runat="server" Width="211px" BackColor="White"
                        Height="40px" OnTextChanged="txtEmployeeName2_TextChanged" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus19" runat="server" Text="Permanent Add :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtPermanentAddress" runat="server" Width="211px" BackColor="White"
                        Height="40px" OnTextChanged="txtEmployeeName2_TextChanged" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblPresentAddressBangla" runat="server" Text="Present Add.Bangla :"></asp:Label>
                </td>
                <td style="height: 19px; text-align:left">
                    <asp:TextBox ID="txtPresentAddressBangla" runat="server" Width="211px"  Font-Names="KarnaphuliMJ"
                        placeHolder="evsjvq bvg wjLyb" Height="40" TextMode="MultiLine"></asp:TextBox>
                </td>
                                                 
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblPermanentAddressBangla" runat="server" Text="Permanent Add.Bangla :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtPermanentAddressBangla" runat="server" Width="211px" BackColor="White" Font-Names="KarnaphuliMJ"
                        placeHolder="evsjvq bvg wjLyb"
                        Height="40px"  TextMode="MultiLine"></asp:TextBox>
                </td>

            </tr>
            
             <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblCompany" runat="server" Text="Company :" ForeColor="Red"></asp:Label>
                 </td>
                <td style="height: 19px; text-align:left">
                    <asp:DropDownList ID="ddlCompanyId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC"> </asp:DropDownList>
                </td>
                                                 
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblSittingOffice" runat="server" Text="Sitting Office :" ForeColor="Red"></asp:Label>
                 </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlSittingBranchOfficeId" runat="server" Width="215px" Height="22px" BackColor="White"> </asp:DropDownList>
                 </td>

            </tr>
           
            
             <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblIdcardNo0" runat="server" Text="Id Card No :"></asp:Label>
                 </td>
                <td style="height: 19px; text-align:left">
                    <asp:TextBox ID="txtIdCardNo" runat="server" Width="211px" BackColor="White" 
                        Font-Bold="True"></asp:TextBox>
                </td>
                                                 
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="lblMaritalStatus20" runat="server" Text="Tin No :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtTinNo" runat="server" Width="211px" BackColor="White" OnTextChanged="txtEmployeeName2_TextChanged"
                        placeHolder="TIN NO" Font-Bold="false"></asp:TextBox>
                </td>

            </tr>
           
            
        </table>
    </fieldset>
<%--</asp:Content>--%>

<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">--%>
    <fieldset>
        <legend>EMPLOYEE JOB INFORMATION</legend>
        <table style="width: 100%">
            
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label6" runat="server" Text="Job Type :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlJobTypeId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label27" runat="server" Text="Occurence Type :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlOccurenceTypeId" runat="server" Width="215px" Height="22px"
                        BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label8" runat="server" Text="Joining Date :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="dtpJoiningDate" runat="server" Width="211px" BackColor="#CCCCCC"
                        CssClass="date"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label39" runat="server" Text="Order Date :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="dtpOrderDate" runat="server" Width="211px" BackColor="#CCCCCC" CssClass="date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label7" runat="server" Text="Effective Date :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="dtpEffectiveDate" runat="server" Width="211px" BackColor="#CCCCCC"
                        OnTextChanged="txtEmployeeName2_TextChanged" CssClass="date"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label46" runat="server" Text="Confirm Date :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="dtpConfirmDate" runat="server" Width="211px" CssClass="date"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label9" runat="server" Text="Unit Name :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="215px" Height="22px"
                        BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label10" runat="server" Text="Section Name :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label48" runat="server" Text="Department :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlDepartmentId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label29" runat="server" Text="Grade :"></asp:Label>
                </td>
                <td style="height: 19px">
                     <asp:DropDownList ID="ddlGradeNo" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC"></asp:DropDownList>
                </td>
            </tr>
            
           <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label12" runat="server" Text="Employee Type :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px; color: #FF0000;">
                    Category</td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlCatagoryId" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label41" runat="server" Text="Joining Designation :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlJoiningDesignationId" runat="server" Width="215px" Height="22px"
                        BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label357" runat="server" Text="Curr. Designation :" ForeColor="Red"></asp:Label>
                </td>
                 <td style="height: 19px">
                    <asp:DropDownList ID="ddlDesignationId" runat="server" Width="215px" Height="22px"
                        BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label30" runat="server" Text="Job Location :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlJobLocationId" runat="server" Width="215px" 
                        Height="22px" >
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label32" runat="server" Text="Approve By :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlApprovedBy" runat="server" Width="215px" Height="22px" BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label34" runat="server" Text="Reference By :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtReferenceName" runat="server" Width="211px" BackColor="White"
                        OnTextChanged="txtEmployeeName2_TextChanged" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label28" runat="server" Text="Supervisor :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlSupervisorId" runat="server" Width="215px" Height="22px"
                        BackColor="#CCCCCC">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label36" runat="server" Text="Shift :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:DropDownList ID="ddlShiftId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label33" runat="server" Text="Payment Type :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlPaymentTypeId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label38" runat="server" Text="Account No :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtAccountNo" runat="server" Width="211px" BackColor="White" OnTextChanged="txtEmployeeName2_TextChanged"
                        Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label355" runat="server" Text="Bank :"></asp:Label>
                    
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlBank" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label40" runat="server" Text="Joining Salary :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="txtJoiningSalary" runat="server" Width="211px" BackColor="#CCCCCC"
                        Height="20px" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label13" runat="server" Text="Gross Salary :" ForeColor="Red"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtGrossSalary" runat="server" Width="211px" BackColor="#CCCCCC"
                        placeHolder="GROSS SALARY" Height="20px" Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label45" runat="server" Text="Resign Date :"></asp:Label>
                    &nbsp;
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:TextBox ID="dtpResignDate" runat="server" Width="211px" CssClass="date" Height="20px"></asp:TextBox>
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label47" runat="server" Text="Resign Casue :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtResignCause" runat="server" Width="211px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="Label49" runat="server" Text="Active Employee :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:CheckBox ID="chkAcftiveYn" runat="server" Text="Yes" />
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label17" runat="server" Text="Allow Payment :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:CheckBox ID="ChkPaymentYn" runat="server" Text="Yes" />
                </td>
            </tr>

             <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    <asp:Label ID="lblMaritalStatus17" runat="server" Text="Allowance :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                   <asp:TextBox ID="txtAllowanceFee" runat="server" Width="211px" BackColor="White"
                        OnTextChanged="txtEmployeeName2_TextChanged" Height="20px" Font-Bold="True"></asp:TextBox> 
                </td>
                <td style="height: 19px; text-align: right; width: 108px;">
                    <asp:Label ID="Label35" runat="server" Text="Train. period :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlTrainingPeriodId" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            
            
            
            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    &nbsp;
                    <asp:Label ID="lblPicture" runat="server" Text="Picture :"></asp:Label>
                </td>
                <td style="height: 19px; width: 247px;">
                    <asp:Image ID="imgEmployee" runat="server" BorderStyle="Double" Height="102px" Width="91px"
                        BorderWidth="1px" />
                    <input id="FileUpload1" type="file" name="file" onchange="previewFile()" runat="server" />
                </td>

                <td style="height: 19px; text-align: right; width: 108px;">
                     <asp:Label ID="lblSignature" runat="server" Text="Signature Image :"></asp:Label>
                </td>

                <td style="height: 19px;">
                    <asp:Image ID="ImgSignature" runat="server" BorderStyle="Double" Height="100px" 
                        Width="91px" BorderWidth="1px" />
                    <input id="FileSignature" type="file" name="file" onchange="previewSignatureFile()" runat="server" />
                </td>
            </tr>

            <tr>
               
                <td style="text-align: right; width: 247px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 247px;">
                </td>

                <td style="height: 19px; text-align: right; width: 108px;">
                    &nbsp; 
                       <asp:Label ID="lblProductCataroy12" runat="server" Text="Work Description  :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <div>
                      <asp:FileUpload ID="FileUpload2" runat="server" />
                      <asp:TextBox ID="txtFileName" runat="server" Width="40px" BackColor="Yellow" ReadOnly="True" Visible="False"></asp:TextBox>
                    </div>  
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 247px; height: 19px">
                    &nbsp;
                </td>

                <td style="height: 19px;" colspan="3">
                    
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="60px"
                        CssClass="styled-button-4" OnClick="btnSheet_Click" />
                    <asp:Button ID="btnSlipEng" runat="server" Height="31px" Text="Slip(Eng)" Width="66px"
                        CssClass="styled-button-4" OnClick="btnSlipEng_Click" />
                    <asp:Button ID="btnSlipBng" runat="server" Height="31px" Text="Slip(Bng)" Width="66px"
                        CssClass="styled-button-4" OnClick="btnSlipBng_Click" Visible="False" />
                    <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="66px" CssClass="styled-button-4"
                        OnClick="btnView_Click" />
                    <asp:Button ID="btnSheet0" runat="server" Height="31px" Text="Emp Info Sheet" Width="110px"
                        CssClass="styled-button-4" OnClick="btnBasicInfoSheet_Click" />

                    <asp:Button ID="BtnLogReport" runat="server" Height="31px" Text="Log Report" Width="80px"
                        CssClass="styled-button-4" OnClick="BtnLogReport_Click" />
                    <asp:Button ID="BtnLogChangeInfo" runat="server" Height="31px" 
                        Text="Bkash Change(Info)" Width="134px"
                        CssClass="styled-button-4" OnClick="BtnLogChangeInfo_Click" />
                    <asp:Button ID="BtnImageResize" runat="server" Height="31px" Text="Resize Image" Width="100px"
                        CssClass="styled-button-4" OnClick="BtnImageResize_Click" Visible="false" />
                    <asp:Button ID="BtnCompressPdf" runat="server" Height="31px" Text="Compress Pdf" Width="100px"
                        CssClass="styled-button-4" OnClick="BtnCompressPdf_Click" Visible="false" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="60px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                </td>
            </tr>
            </table>
    </fieldset>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <table class="style1">
             <tr>
               <td style="text-align: right" class="auto-style3">
               <asp:Label ID="Label15" runat="server" Text="Unit Group :"></asp:Label>
                &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlUnitGroupId" runat="server" Width="240px" Height="22px">
                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Unit Group- 1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="Unit Group- 2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="Unit Group- 3"></asp:ListItem>
                        <asp:ListItem Value="4" Text="Unit Group- 4"></asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="width: 66px">
                    &nbsp;
                    <asp:Button ID="btnSearchEmployee" runat="server" Height="25px" Text="Search" CssClass="styled-button-4"
                        Width="55px" OnClick="btnSearchEmployee_Click" />
                </td>
                <td style="text-align: right; width: 69px">
                    <asp:Label ID="lblProductCataroy10" runat="server" Text="Emp.Type :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlEmpTypeId" runat="server" Width="150px" Height="22px">
                    </asp:DropDownList>
                </td>

            </tr>
            <tr>
                <td style="width: 250px; text-align: right; height: 22px;">
                    <asp:Label ID="Label1" runat="server" Text="Unit :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px; height: 22px;">
                    <asp:DropDownList ID="ddlEmpUnitId" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="height: 22px; width: 66px;">
                    &nbsp;
                    <asp:Button ID="BtnSecurityLog" runat="server" Height="25px" Text="Log" CssClass="styled-button-4"
                        Width="55px" OnClick="BtnSecurityLog_Click" />
                </td>
                <td style="height: 22px; text-align: right; width: 69px;">
                    <asp:Label ID="Label2" runat="server" Text="ID :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        placeHolder="EMPLOYEE ID"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="Label3" runat="server" Text="Section :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlEmpSectionId" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                    <asp:Label ID="Label43" runat="server" Text="Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpName" runat="server" Width="149px" BackColor="White" placeHolder="EMPLOYEE NAME"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Grade :"></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlGradeId" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                    <asp:Label ID="Label42" runat="server" Text="Punch Code :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpPunchCode" runat="server" Width="149px" BackColor="White"
                        placeHolder="PUNCH CODE" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="lblProductCataroy6" runat="server" Text="Blood Group :"></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlBloodGroupIdForSearch" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                    <asp:Label ID="Label4" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        placeHolder="CARD NO"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="lblProductCataroy8" runat="server" Text="From :"></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:TextBox ID="dtpFromConfirmDate" runat="server" Width="238px" placeHolder="CONFIRM DATE"
                        CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
               <td style="text-align: right; width: 69px">
                    <asp:Label ID="lblProductCataroy3" runat="server" Text="In Active :"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes" />
                </td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="lblProductCataroy9" runat="server" Text="To : "></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:TextBox ID="dtpToConfirmDate" runat="server" Width="238px" placeHolder="CONFIRM DATE"
                        CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                  <td style="text-align: right; width: 69px">
                     NID No :</td>
                <td>
                    &nbsp;<asp:TextBox ID="txtNIDNoSearch" runat="server" Width="148px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        placeHolder="NID No"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    <asp:Label ID="Label44" runat="server" Text="Name :" Visible="False"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlEmpId" runat="server" Width="153px" Height="22px" Visible="False">
                    </asp:DropDownList>
                    &nbsp;
                </td>
                <td style="width: 66px">
                    &nbsp;
                </td>
                <td style="text-align: right; width: 69px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 250px; text-align: right">
                    &nbsp;</td>
                <td style="width: 163px">
                    &nbsp;</td>
                <td style="width: 66px">
                    &nbsp;</td>
                <td style="text-align: right; width: 69px">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </fieldset>
</asp:Content>



<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" OnSorting="gvEmployeeList_Sorting" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowCommand="gvEmployeeList_RowCommand" OnRowEditing="OnRowEditing" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" style="margin-top: 14px">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
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


    <fieldset>
        <legend>SECURITY LOG</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                                       

                    <asp:GridView ID="GvSecurityLog" runat="server" DataSourceID="" AutoGenerateColumns="False"  Width="100%"
                        AllowSorting="True" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" style="margin-top: 14px">
                                            
                        <Columns>

                            <asp:BoundField DataField="punch_code_chg" HeaderText="PCode"/>
                            <asp:BoundField DataField="nid_no_chg" HeaderText="NID" />
                            <asp:BoundField DataField="birth_reg_no_chg" HeaderText="REG_NO" />

                            <%--<asp:BoundField DataField="mobile_no_chg" HeaderText="CELL" />
                            <asp:BoundField DataField="account_no_chg" HeaderText="A/C" />
                            <asp:BoundField DataField="bkash_no_chg" HeaderText="bKash" />
                            
                            <asp:BoundField DataField="joining_date_chg" HeaderText="JOINING" />

                            <asp:BoundField DataField="employee_type_id_chg" HeaderText="ETYPE" />
                            <asp:BoundField DataField="joining_salary_chg" HeaderText="JSALARY" />
                            
                            <asp:BoundField DataField="first_salary_chg" HeaderText="FSALARY" />
                            <asp:BoundField DataField="gross_salary_chg" HeaderText="GROSS" />                         
                            <asp:BoundField DataField="allowance_amount_chg" HeaderText="ALLOW." />
                            <asp:BoundField DataField="resign_date_chg" HeaderText="RDATE" />
                                                                                    
                            <asp:BoundField DataField="log_order" HeaderText="SL" /> 
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                        
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE_NO" />

                            <asp:BoundField DataField="first_salary" HeaderText="FIRST SALARY" />
                            <asp:BoundField DataField="gross_salary" HeaderText="GROSS SALARY" />
                            
                            <asp:BoundField DataField="JOINING_DATE" HeaderText="JOINING DATE" />
                            <asp:BoundField DataField="ACCOUNT_NO" HeaderText="ACCOUNT NO" />
                            <asp:BoundField DataField="bkash_no" HeaderText="BKASH NO" />--%>
                            
                            <asp:BoundField DataField="create_by" HeaderText="Create By" />
                            <asp:BoundField DataField="create_date" HeaderText="Create Date" />
                            

                        </Columns>
                    </asp:GridView>
                        
                </td>
            </tr>
        </table>
    </fieldset>

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
