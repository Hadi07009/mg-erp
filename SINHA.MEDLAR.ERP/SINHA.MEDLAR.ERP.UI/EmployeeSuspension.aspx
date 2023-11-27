
<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeeSuspension.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeSuspension" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
       
    </script>
    //$('#<%=btnSave.ClientID%>').click();
    
<%--    <script type="text/javascript">
        $(document).ready(function () {
            $('#ctl00$ContentPlaceHolder2$dtpStartDate').change(function () {
                //$('#ctl00$ContentPlaceHolder2$dtpEndDate').val("10/12/2020");
                alert("Handler for .change() called.");
            });       
        });
    </script>--%>

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
        <legend>Suspension Entry</legend>
        <table style="width: 100%">
            <tr>
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
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="From Date :"></asp:Label>
                </td>
                <td style="width: 226px">
                    <asp:TextBox ID="dtpStartDate" runat="server" Width="211px" BackColor="White" 
                        CssClass="date"></asp:TextBox>
                </td>
                <td style="width: 76px; text-align: right">
                    <asp:Label ID="lblProductCataroy10" runat="server" Text="Card No/Id :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtCardNo" runat="server" Width="76px" BackColor="Yellow" Height="20px"
                        Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="108px" Height="20px" BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSL" runat="server" Width="33px" Height="20px" ReadOnly="True"
                        BackColor="Yellow" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSLNew" runat="server" Width="33px" Height="20px" ReadOnly="True"
                        BackColor="Yellow" Font-Bold="True" Visible="False" style="margin-left: 0; margin-right: 2; margin-top: 0px"></asp:TextBox>
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
                <%--<td style="width: 76px; text-align: right">
                    
                </td>--%>
                <td style="height: 19px; width: 76px; text-align: right;">
                    <asp:Label ID="Label3" runat="server" Text="Name :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="250px" Height="20px" BackColor="Yellow"
                        ReadOnly="True" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtSuspensionId" runat="server" Width="16px" Height="20px" Visible="false"
                        Font-Bold="True"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td style="text-align: right; width: 157px; height: 19px">
                    <asp:Label ID="Label2" runat="server" Text="Approved By :"></asp:Label>
                </td>
                <td style="height: 19px; width: 226px;">
                    <asp:DropDownList ID="ddlApprovedById" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
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
                    <asp:Label ID="lblProductCataroy9" runat="server" Text="Remarks :"></asp:Label>
                </td>
                <td style="height: 19px; width: 226px;">
                    <asp:TextBox ID="txtRemarks" runat="server" Width="213px" BackColor="White" Height="53px"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
                <td style="width: 76px; text-align: right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                
                
               <%-- <td style="height: 19px">
                    &nbsp;
                </td>--%>
            </tr>
            <tr>
                <td style="text-align: left; height: 19px" colspan="5">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                    &nbsp;
                    &nbsp;
                    &nbsp;
                    &nbsp;
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: center;width: 800px;  height: 19px"  colspan="5">
                    <asp:Button ID="btnSave" runat="server" Height="31px"  Text="Save" Width="66px" CssClass="styled-button-4"
                        OnClick="btnSave_Click" />
                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="66px"
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
                        <legend>SUSPENSION ENTRY RESULT</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false" DataKeyNames="SUSPENSION_ID" 
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GridView1_OnRowEditing" OnRowDeleting="GridView1_RowDeleting"
                                        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_OnRowDataBound">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="START_DATE" HeaderText="START DATE" />
                                            <asp:BoundField DataField="END_DATE" HeaderText="END DATE" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <asp:BoundField DataField="REMARKS" HeaderText="REMARKS" />
                                            <asp:BoundField DataField="suspension_id" HeaderText="suspension_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                            <asp:BoundField DataField="approved_by" HeaderText="approved_by" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                        AlternateText="Delete"
                                                        Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                        Height="25px" Visible="true" />
                                                </ItemTemplate>
                                             </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
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
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
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
