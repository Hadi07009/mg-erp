<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeeLogProcess.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeLogProcess" %>

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
        <legend>ATTENDENCE UPLOAD PROCESS</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 917px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">
                    <fieldset>
                        <legend>FILE UPLOAD</legend>
                        <table style="width: 100%">

                            <tr>
                                <td style="text-align: right; width: 240px; height: 19px">
                                    <asp:Label ID="lblMediaTypeId" runat="server" Text="Media Type :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:DropDownList ID="ddlMediaTypeId" runat="server" Width="240px" Height="22px">
                                        <asp:ListItem Value="" Text="---Select---"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Punch"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Thumb"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Face"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>

                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>

                                <%--<td style="height: 19px; width: 116px; text-align: right;">         
                                </td>
                                <td style="height: 19px">
                                </td>--%>
                            </tr>

                            <tr>
                                <td style="text-align: right; width: 240px; height: 19px">
                                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Upload File :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:FileUpload ID="FileUpload1" onchange="this.form.submit();" runat="server" style="width:235px;" />
                                </td>

                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy6" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>

                                <%--<td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>--%>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 240px; height: 19px">
                                    <asp:Label ID="lblProductCataroy0" runat="server" Text="File Name :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:TextBox ID="txtFileName" runat="server" Width="236px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy7" runat="server" Text="From Date :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="238px" BackColor="White" 
                                        CssClass="date"></asp:TextBox>
                                </td>
                                <%--<td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy6" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>--%>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 240px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="File Path :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:TextBox ID="txtFilePath" runat="server" Width="236px" BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                </td>

                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy4" runat="server" Text="To Date :"></asp:Label>
                                </td>
                                <td style="height: 19px;">
                                    <asp:TextBox ID="dtpToDate" runat="server" Width="238px" BackColor="White" 
                                        CssClass="date"></asp:TextBox>
                                </td>
                            </tr>


                           <%-- <tr>
                                <td style="text-align: right; width: 240px; height: 19px">
                                    <asp:Label ID="Label16" runat="server" Text="Home Branch :"></asp:Label>
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:DropDownList ID="ddlHomeBranchOfficeId" runat="server" Width="240px" Height="22px" BackColor="White"> </asp:DropDownList>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                </td>
                                <td style="height: 19px;">
                                </td>
                            </tr>--%>


                            <tr>

                                <td style="text-align: right; width: 240px; height: 19px">
                                    <asp:Label ID="lblSittingType" runat="server" Text="Sitting Type:"></asp:Label>
                                </td>
                                
                                     <td style="width: 66px">
                                         <asp:DropDownList ID="ddlSittingType" runat="server" Width="242px" Height="21px">
                                             <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                             <asp:ListItem Value="1" Text="Sitting Hare"></asp:ListItem>
                                             <asp:ListItem Value="2" Text="Others"></asp:ListItem>
                                         </asp:DropDownList>
                                         <asp:TextBox ID="txtDataUploadDir" runat="server" Width="160px" BackColor="White" Visible="False"></asp:TextBox>
                                     </td>


                                <%--<td style="text-align: right; width: 240px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:TextBox ID="txtDataUploadDir" runat="server" Width="160px" BackColor="White"
                                        Visible="False"></asp:TextBox>
                                    &nbsp;
                                </td>--%>

                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy8" runat="server" Text="Card No :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="238px" BackColor="White"></asp:TextBox>
                                </td>
                                
                            </tr>
                           
                             <tr>
                                
                                <td style="text-align: right; width: 240px; height: 19px">
                                <asp:Label ID="Label1" runat="server" Text="Late Minute And (+):"></asp:Label>            
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:TextBox ID="txtLateLimit" runat="server" Width="236px" BackColor="White"></asp:TextBox>
                                    
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblTotalOTMinute" runat="server" Text="OT Hour/Minute :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtOTMinute" runat="server" Width="238px" BackColor="White"></asp:TextBox>
                                </td>
                                
                            </tr>




                            <tr>                                
                                <td style="text-align: right; width: 240px; height: 19px">
                                    <asp:Label ID="lblIftarTimeSheet" runat="server" Text="Iftar Time Sheet:" Visible="false"></asp:Label>
                                    
                                </td>
                                <td style="height: 19px; width: 297px;">
                                    <asp:FileUpload ID="FileUpload2" runat="server" Visible="false" />  
                                    <%--<asp:TextBox ID="txtLateLimit" runat="server" Width="236px" BackColor="White"></asp:TextBox>--%>
                                </td>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="Label2" runat="server" Text="Floor :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlFloor" runat="server" Width="240px" Height="28px"></asp:DropDownList>
                                </td>
                            </tr>




                            
                            <tr>
                                <td style="text-align: left; height: 19px" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center;" colspan="4">
                                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnLogProcess" runat="server" Height="31px" Text="Process" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnLogProcess_Click" />
                                    <asp:Button ID="btnAttendenceSheet" runat="server" Height="31px" Text="Sheet" Width="46px"
                                        CssClass="styled-button-4" OnClick="btnAttendenceSheet_Click" />
                                    <asp:Button ID="btnAttendenceSheetLate" runat="server" Height="31px" Text="Late Sheet"
                                        Width="75px" CssClass="styled-button-4" OnClick="btnAttendenceSheetLate_Click" />
                                    <asp:Button ID="btnAbsenceSheet" runat="server" Height="31px" Text="Absence Sheet"
                                        Width="99px" CssClass="styled-button-4" OnClick="btnAbsenceSheet_Click" />
                                    <asp:Button ID="btnMonthlySheet" runat="server" Height="31px" Text="OT Sheet" Width="63px"
                                        CssClass="styled-button-4" OnClick="btnMonthlySheet_Click" />
                                    <asp:Button ID="btnAttendenceSheetBuyer" runat="server" Height="31px" Text="B.Sheet"
                                        Width="58px" CssClass="styled-button-4" 
                                        onclick="btnAttendenceSheetBuyer_Click" />
                                    <asp:Button ID="btnAttendenceSheetHO" runat="server" Height="31px" 
                                        Text="HO Sheet" Width="63px"
                                        CssClass="styled-button-4" OnClick="btnAttendenceSheetHO_Click"  />

                                    <asp:Button ID="btnAttendanceSummary" runat="server" Height="31px" 
                                        Text="Summary" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnAttendanceSummary_Click"  />
                                    <asp:Button ID="btnFacStaffAndWokerWithoutPunch" runat="server" Height="31px" Text="Not In (FS+W)"
                                        Width="100px" CssClass="styled-button-4" OnClick="btnFacStaffAndWokerWithoutPunch_Click" />
                                    <%--btnEmpListWithoutPunch_Click--%>
                                    <asp:Button ID="btnEmpListWithoutPunchOBranch" runat="server" Height="31px" Text="Not In (Others)"
                                        Width="100px" CssClass="styled-button-4" OnClick="btnEmpListWithoutPunchOBranch_Click" />

                                    <asp:Button ID="BtnEmpListWithoutOutPunch" runat="server" Height="31px" Text="No Out Punch"
                                        Width="84px" CssClass="styled-button-4" 
                                        OnClick="BtnEmpListWithoutOutPunch_Click" />
                                       <asp:Button ID="BtnHOEmpListWithoutOutPunch" runat="server" Height="31px" Text="No Out Punch(HO)"
                                        Width="111px" CssClass="styled-button-4" 
                                        OnClick="BtnHOEmpListWithoutOutPunch_Click" />                                 
                                    <asp:Button ID="BtnLogDetail" runat="server" Height="31px" Text="Punch Detail" Width="100px"
                                        CssClass="styled-button-4" OnClick="BtnLogDetail_Click" />

                                    <asp:Button ID="BtnActiveEmployee" runat="server" Height="31px" Text="Active" Width="60px"
                                        CssClass="styled-button-4" OnClick="BtnActiveEmployee_Click" />
                                    <asp:Button ID="BtnAttendanceLate" runat="server" Height="31px" Text="Attendance & Late Sheet"
                                        Width="165px" CssClass="styled-button-4" 
                                        OnClick="BtnAttendanceLate_Click"  />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT </legend>
        <table class="style1">
            <tr>
                <td style="text-align: left">
                    <asp:GridView ID="gvEmployeeLogList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeLogList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnRowCommand="gvEmployeeLogList_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="FIRST_IN" HeaderText="IN" />
                            <asp:BoundField DataField="LAST_OUT" HeaderText="OUT" />
                            <asp:BoundField DataField="LUNCH_OUT" HeaderText="LUNCH OUT" />
                            <asp:BoundField DataField="LUNCH_IN" HeaderText="LUNCH IN" />
                            <asp:BoundField DataField="OT_HOUR" HeaderText="OT" />
                        </Columns>
                        <AlternatingRowStyle BackColor="White" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        <SelectedRowStyle BackColor="Blue" ForeColor="White" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <%-- <fieldset>
        <legend>SEARCH RESULT </legend>
        <table class="style1">
            <tr>
                <td style="text-align: left">
                    <asp:GridView ID="gv" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid"  CssClass="mGrid" 
                        BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>--%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
           
    <table style="width: 100%">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
            <td>
                &nbsp;
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
