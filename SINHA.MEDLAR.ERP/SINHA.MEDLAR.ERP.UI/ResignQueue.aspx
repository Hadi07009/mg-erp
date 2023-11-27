<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ResignQueue.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ResignQueue" %>

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
        <legend>RESIGN DATE AND CAUSE SETTING</legend>

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
        </table>

        <div>
            <div style="float: left;">
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: right; width: 247px">
                            <asp:Label ID="lblResignDate" runat="server" Text="Resign Date :" ForeColor="Black"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="dtpResignDate" runat="server" Width="211px" CssClass="date"
                                Font-Bold="True"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right; width: 247px">

                            <asp:Label ID="Label44" runat="server" Text="Resign Cause :" ForeColor="Black"></asp:Label>
                        </td>
                        <td style="width: 247px">
                            <asp:TextBox ID="txtResignCause" runat="server" Width="211px" BackColor="White"
                                Height="40px" TextMode="MultiLine"></asp:TextBox>
                        </td>

                    </tr>
                    
                    <tr>
                        <td style="text-align: right; width: 247px; height: 19px"></td>
                        <td style="height: 19px;"></td>
                    </tr>
                    
                    <tr>
                        <td style="text-align: right; width: 247px; height: 19px">&nbsp;
                        </td>
                        <td style="height: 19px;">

                            <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                OnClick="btnSave_Click" />
                            <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="60px"
                                CssClass="styled-button-4" OnClick="btnSheet_Click" />

                            <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="60px"
                                CssClass="styled-button-4" OnClick="btnClear_Click" />
                        </td>
                    </tr>
                </table>
            </div>

            <div style="float: right;">
                <table style="width: 100%">

                    <tr>
                        <td style="text-align: right; width: 247px">
                            <asp:Label ID="lblEmployeeCode" runat="server" Text="ID/Card : "></asp:Label>
                        </td>
                        <td style="width: 247px">
                            <asp:TextBox ID="txtEmployeeId" runat="server" Width="102px" BackColor="Yellow" Height="20px"
                                ReadOnly="true"></asp:TextBox>
                            <asp:TextBox ID="txtCardNo" runat="server" Width="105px" BackColor="Yellow" Height="20px"
                                ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right; width: 247px">

                            <asp:Label ID="Label10" runat="server" Text="Designation :" ForeColor="Black"></asp:Label>
                        </td>
                        <td style="width: 247px">
                            <asp:TextBox ID="txtDesignation" runat="server" Width="210px" BackColor="Yellow"
                                Height="20px" ReadOnly="true"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>

                        <td style="text-align: right; width: 247px">

                            <asp:Label ID="Label12" runat="server" Text="Name :" ForeColor="Black"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmployeeName" runat="server" Width="210px" BackColor="Yellow"
                                Height="20px" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right; width: 150px; height: 19px">&nbsp;</td>
                        <td>&nbsp;
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right; width: 247px; height: 19px">&nbsp;
                        </td>
                        <td style="height: 19px;">&nbsp;</td>
                    </tr>
                </table>
            </div>
        </div>

    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <div>
            <div style="float: left;">
                <table style="width: 100%">

                    <tr>
                        <td style="width: 254px; text-align: right; height: 25px;">
                            <asp:Label ID="Label1" runat="server" Text="Unit :"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 95px; height: 22px;">
                            <asp:DropDownList ID="ddlEmpUnitId" runat="server" Width="264px" Height="28">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td style="width: 254px; text-align: right">
                            <asp:Label ID="Label2" runat="server" Text="Section :"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="width: 95px">
                            <asp:DropDownList ID="ddlEmpSectionId" runat="server" Width="264px" Height="28">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right" class="auto-style3">
                            <asp:Label ID="Label7" runat="server" Text="Employee Id :"></asp:Label>
                            &nbsp;
                        </td>
                        <td style="text-align: right; width: 163px">
                            <asp:TextBox ID="txtEmpId" runat="server" BackColor="White" TabIndex="16" Style="padding-left: 5px;
                                padding-right: 5px; height: 25px; width: 250px;"></asp:TextBox>
                        </td>
                    </tr>

                </table>
            </div>

            <div style="float: right;">
                <table style="width: 100%">

                    <tr>
                        <td style="height: 22px; text-align: right; width: 210px;">
                            <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" CssClass="styled-button-4"
                                OnClick="btnSearch_Click" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="Label3" runat="server" Height="25px" Text="Resign From :"></asp:Label>

                        </td>
                        <td style="height: 22px">
                            <asp:TextBox ID="dtpFromDate" runat="server" BackColor="White" CssClass="date" Style="padding-left: 5px;
                                padding-right: 5px; height: 25px; width: 250px;"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td style="text-align: right; width: 210px">
                            <asp:Label ID="Label6" runat="server" Text="Resign To :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="dtpTodate" runat="server" BackColor="White" CssClass="date" Style="padding-left: 5px;
                                padding-right: 5px; height: 25px; width: 250px;"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 210px">&nbsp;
                       <asp:Label ID="Label8" runat="server" Text="Card No :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmpCardNo" runat="server" BackColor="White" Style="padding-left: 5px;
                                padding-right: 5px; height: 25px; width: 250px;"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </fieldset>

    <fieldset>


        <legend>Resign Employee</legend>


        <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="EMPLOYEE_ID"
            CausesValidation="false" OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True"
            EnableViewState="true" GridLines="None" AllowPaging="false"
            CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
            AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField DataField="SL" HeaderText="SL" />
                <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                <asp:BoundField DataField="RESIGN_DATE" HeaderText="Date" />
                <asp:BoundField DataField="RESIGN_CAUSE" HeaderText="Resign Cause" />
                <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn"
                    ItemStyle-CssClass="hideGridColumn" />
                 <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%" >
                    <ItemTemplate>
                        <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                            AlternateText="Delete"
                            Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                            Height="25px" Visible="true" />
                    </ItemTemplate>
                 </asp:TemplateField>
                <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                            ImageUrl="~/images/select_png.jpg" AlternateText="Select"
                            Style="cursor: pointer" Text="..." CausesValidation="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

    </fieldset>


    <asp:GridView ID="GvResignQueue" runat="server" DataSourceID="" AutoGenerateColumns="False"
        AllowSorting="True" EnableViewState="true"
        GridLines="None" AllowPaging="false" CssClass="mGrid"
        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GvResignQueue_OnSelectedIndexChanged"
        CausesValidation="false" OnRowCommand="GvResignQueue_RowCommand" AlternatingRowStyle-CssClass="alt"
        OnPageIndexChanging="GvResignQueue_PageIndexChanging" Width="1030px" Height="133px">
        <Columns>
            <asp:BoundField DataField="SL" HeaderText="SL" />
            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
            <asp:BoundField DataField="designation_id" HeaderText="designation_id" HeaderStyle-CssClass="hideGridColumn"
                ItemStyle-CssClass="hideGridColumn" />
            <asp:BoundField DataField="unit_id" HeaderText="uinit_id" HeaderStyle-CssClass="hideGridColumn"
                ItemStyle-CssClass="hideGridColumn" />
            <asp:BoundField DataField="section_id" HeaderText="section_id" HeaderStyle-CssClass="hideGridColumn"
                ItemStyle-CssClass="hideGridColumn" />
            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                        ImageUrl="~/images/select_png.jpg" AlternateText="Select"
                        Style="cursor: pointer" Text="..." CausesValidation="false" />
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
            <td>&nbsp;
            </td>
            <td>&nbsp;
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
