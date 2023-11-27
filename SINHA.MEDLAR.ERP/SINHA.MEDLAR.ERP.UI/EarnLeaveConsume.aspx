<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EarnLeaveConsume.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EarnLeaveConsume" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function validateFile() {
            
            //start: extention and size validation
            //1: Extention
            var extension = $("#ContentPlaceHolder2_FileUpload1").val().split('.').pop().toLowerCase();
            var validFileExtension = ['pdf', 'PDF'];
            if ($.inArray(extension, validFileExtension) == -1) {
                alert("Sorry !!! Allowed file format is '.pdf'");
                // Clear fileuload control selected file
                $("#ContentPlaceHolder2_FileUpload1").replaceWith($("#ContentPlaceHolder2_FileUpload1").val('').clone(true));
                return;
            }

            //2: Size
            // Check and restrict the file size to 32 KB.
            var fileSize = $("#ContentPlaceHolder2_FileUpload1").get(0).files[0].size;
            if (fileSize > (512000)) {
                alert("Sorry!! Max allowed file size is 500 kb");

                $('#spnDocMsg').text("Sorry!! Max allowed file size is 32 kb").show();
                // Clear fileuload control selected file
                $("#ContentPlaceHolder2_FileUpload1").replaceWith($("#ContentPlaceHolder2_FileUpload1").val('').clone(true));
                return;
            }
            //end: extention and size validation                        
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
        <legend>Earn Leave Consume</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 19px" colspan="5">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: right;" colspan="5">
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 157px">
                    <asp:Label ID="lblProductCataroy11" runat="server" Text="Leave Year :"></asp:Label>
                </td>
                <td style="width: 226px">
                    <asp:TextBox ID="txtYear" runat="server" Width="211px" BackColor="Yellow" Height="20px"
                        Font-Bold="True"></asp:TextBox>
                </td>
                <td style="width: 76px; text-align: right">
                    <asp:Label ID="lblConsumeYear" runat="server" Text="Consume Year :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConsumeYear" runat="server" Width="250px" BackColor="Yellow" Height="20px"
                        Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 157px">
                    <asp:Label ID="lblProductCataroy7" runat="server" Text="Leave Type :"></asp:Label>
                </td>
                <td style="width: 226px">
                    <asp:DropDownList ID="ddlLeaveTypeId" runat="server" Width="215px" Height="22px"
                        AutoPostBack="false">
                    </asp:DropDownList>
                </td>
                <td style="width: 76px; text-align: right">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="250px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 157px">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="From Date :"></asp:Label>
                </td>
                <td style="width: 226px">
                    <asp:TextBox ID="dtpStartDate" runat="server" Width="211px" BackColor="White" 
                        CssClass="date" OnTextChanged="dtpStartDate_TextChanged" AutoPostBack="true"></asp:TextBox>
                </td>
                <td style="width: 76px; text-align: right">
                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDesignationName" runat="server" Width="250px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 157px; height: 19px">
                    <asp:Label ID="lblProductCataroy6" runat="server" Text="To Date :"></asp:Label>
                </td>
                <td style="height: 19px; width: 226px;">
                    <asp:TextBox ID="dtpEndDate" runat="server" Width="211px" BackColor="White" CssClass="date"></asp:TextBox>
                </td>
                <td style="height: 19px; width: 76px; text-align: right;">
                    <asp:Label ID="Label38" runat="server" Text="ID :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="250px" BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 157px; height: 19px">
                    <asp:Label ID="lblProductCataroy8" runat="server" Text="Approved By :"></asp:Label>
                </td>
                <td style="height: 19px; width: 226px;">
                    <asp:DropDownList ID="ddlApprovedById" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
                 <td style="width: 76px; text-align: right">
                    <asp:Label ID="Label2" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCardNo" runat="server" Width="250px" BackColor="Yellow" Height="20px"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 157px; height: 19px">
                    <asp:Label ID="lblProductCataroy9" runat="server" Text="Remarks :"></asp:Label>
                </td>
                <td style="height: 19px; width: 226px;">
                    <asp:TextBox ID="txtRemarks" runat="server" Width="213px" BackColor="White" Height="53px"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="height: 19px; width: 76px; text-align: right;">
                    &nbsp;
                </td>
               <%-- <td style="height: 19px">
                    <fieldset>
                        <legend>LEAVE STATUS</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <div style="overflow-x: scroll;">
                                        <asp:GridView ID="GridView2" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                            AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                            CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GridView1_OnRowEditing"
                                            OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                            OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_OnRowDataBound">
                                            <Columns>
                                                <asp:BoundField DataField="SL" HeaderText="SL" />
                                                <asp:BoundField DataField="LEAVE_TYPE_NAME" HeaderText="TYPE" />
                                                <asp:BoundField DataField="MAX_ALLOW" HeaderText="T.L" />
                                                <asp:BoundField DataField="TOTAL_LEAVE" HeaderText="T.A" />
                                                <asp:BoundField DataField="remaining_blance" HeaderText="BLANCE " />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>--%>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>    
            <tr>
                <td style="text-align: center; height: 19px" colspan="5">
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete" Width="66px"
                        CssClass="styled-button-4" OnClick="btnDelete_Click" />
                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Visible="false" Width="66px"
                        CssClass="styled-button-4" onclick="btnSheet_Click" />                   
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />

                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 157px">
                    &nbsp;
                </td>
                <td style="width: 226px">
                    &nbsp;
                </td>
                <td style="width: 76px; text-align: right">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH CRITERIA</legend>
        <table class="style1">
            <tr>
                <td style="width: 153px; text-align: right">
                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                    &nbsp;
                </td>
                <td style="width: 46px">
                    <asp:Label ID="Label36" runat="server" Text="Card No :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        placeHolder="CARD NO"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 153px; text-align: right">
                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                    &nbsp;
                </td>
                <td style="width: 163px">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;
                </td>
                <td style="width: 46px">
                    <asp:Label ID="Label37" runat="server" Text="ID :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                        placeHolder="EMPLOYEE ID"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 153px; text-align: right">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="From Date :"></asp:Label>
                </td>
                <td style="width: 163px">
                  <asp:TextBox ID="dtpFromDate" runat="server" Width="235px" BackColor="White" 
                                        CssClass="date"></asp:TextBox>  
                </td>
                <td>
                    &nbsp;</td>
                <td style="width: 46px">
                    <asp:Label ID="Label39" runat="server" Text="Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmpName" runat="server" Width="149px" BackColor="White" placeHolder="EMPLOYEE NAME"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="width: 153px; text-align: right">
                    <asp:Label ID="Label1" runat="server" Text="To Date :"></asp:Label>
                </td>
                <td style="width: 163px">
                    <asp:TextBox ID="dtpToDate" runat="server" Width="235px" BackColor="White" 
                                        CssClass="date"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td style="width: 46px">
                    <%--<asp:Label ID="Label2" runat="server" Text="Name :"></asp:Label>--%>
                </td>
                <td>
                    <%--<asp:TextBox ID="TextBox1" runat="server" Width="149px" BackColor="White" placeHolder="EMPLOYEE NAME"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>--%>
                </td>
            </tr>

            <tr>
                <td colspan="5" style="text-align: left">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5" style="text-align: right">
                    <fieldset>
                        <legend>LEAVE ENTRY RESULT</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GridView1_OnRowEditing"
                                        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_OnRowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="leave_type_name" HeaderText="L.TYPE" />
                                            <asp:BoundField DataField="LEAVE_START_DATE" HeaderText="START DATE" />
                                            <asp:BoundField DataField="LEAVE_END_DATE" HeaderText="END DATE" />
                                            <asp:BoundField DataField="TOTAL_LEAVE" HeaderText="T.L" />          
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                                </ItemTemplate>
                                            </asp:TemplateField> --%>
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
                        <%-- </div>--%>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <%-- </div>--%>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True"  EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
        <%-- </div>--%>
    </fieldset>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
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
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
