<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false"
    CodeBehind="SalaryApproveProcess.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.SalaryApproveProcess" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>

    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");

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
        <legend>SALARY APPROVED INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Checked="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <table class="style1">
                        <tr>
                            <td style="text-align: right">
                                <fieldset>
                                    <legend>SEARCH CRITERIA</legend>
                                    <table class="style1">
                                        <tr>
                                            <td style="width: 126px; text-align: right; height: 22px;">
                                                <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                            </td>
                                            <td style="width: 163px; height: 22px;">
                                                <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                    CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                            </td>
                                            <td style="height: 22px; text-align: right; width: 69px;">
                                                <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                            </td>
                                            <td style="height: 22px; width: 176px;">
                                                <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                <asp:Label ID="Label41" runat="server" Text="Year/Month :"></asp:Label>
                                            </td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtSalaryYear" runat="server" Width="91px" Height="20px" Font-Bold="True"
                                                    MaxLength="4"></asp:TextBox>
                                                <asp:TextBox ID="txtsalaryMonth" runat="server" Width="55px" Height="20px" Font-Bold="True"
                                                    MaxLength="2"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 126px; text-align: right">
                                                <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                            </td>
                                            <td style="width: 163px">
                                                <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 66px">&nbsp;
                                            </td>
                                            <td style="text-align: right; width: 69px">
                                                <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                            </td>
                                            <td style="width: 176px">
                                                <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                            </td>
                                            <td style="width: 66px">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 126px; text-align: right">&nbsp;</td>
                                            <td style="width: 163px">&nbsp;</td>
                                            <td style="width: 66px">&nbsp;</td>
                                            <td style="text-align: right; width: 69px">&nbsp;</td>
                                            <td style="width: 176px">&nbsp;</td>
                                            <td style="width: 66px">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center">
                                <asp:Button ID="btnProcess" runat="server" Height="31px" Text="Approve" Width="66px"
                                    CssClass="styled-button-4" OnClick="btnProcess_Click" />
                                <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" CssClass="styled-button-4"
                                    OnClientClick="target = '_SELF';" OnClick="btnShow_Click" />
                                <asp:Button ID="btnAttendenceSheet" runat="server" Height="31px" Text="Sheet" Width="66px"
                                    CssClass="styled-button-4" OnClick="btnAttendenceSheet_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <fieldset>
                                    <legend>SALARY APROVED EMPLOYEE ENTRY RESULT</legend>
                                    <table style="width: 124%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvSalaryAprovedEmpList" runat="server" DataSourceID=""
                                                    AutoGenerateColumns="False" DataKeyNames="EMPLOYEE_ID"
                                                    OnRowDataBound="gvSalaryAprovedEmpList_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                                    GridLines="None" AllowPaging="false" OnRowEditing="gvSalaryAprovedEmpList_OnRowEditing"
                                                    OnRowDeleting="gvSalaryAprovedEmpList_RowDeleting" OnRowCommand="gvSalaryAprovedEmpeList_RowCommand"
                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvSalaryAprovedEmpList_OnSelectedIndexChanged"
                                                    CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                                                    OnPageIndexChanging="gvSalaryAprovedEmplList_PageIndexChanging"
                                                    caption="<table width='100%' class='TestCssStyle'><tr><td class='text_Title'>Grid Heading</td></tr></table>"
                                                    OnSelectedIndexChanging="gvSalaryAprovedEmpList_SelectedIndexChanging" Width="1003px">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="SL">
                                                            <ItemTemplate>
                                                                <%#Container.DataItemIndex+1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                                        <asp:BoundField DataField="JOINING_DATE" HeaderText="J.D" />

                                                        <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                                                        <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" />
                                                        <asp:BoundField DataField="FIRST_SALARY_PRE" HeaderText="F.S.P" />

                                                        <asp:BoundField DataField="GROSS_SALARY_PRE" HeaderText="G.S.P" />

                                                        <asp:BoundField DataField="INCREMENT_AMOUNT" HeaderText="(5%)" />
                                                        <asp:BoundField DataField="MANUAL_INCREMENT_AMOUNT" HeaderText="INC." />
                                                        <asp:BoundField DataField="FIRST_SALARY" HeaderText="F. SAL" />
                                                        <asp:BoundField DataField="GROSS_SALARY" HeaderText="G. SAL" />
                                                                                                                
                                                        <asp:BoundField DataField="occurence_type_name" HeaderText="TYPE" />
                                                        <asp:BoundField DataField="approve_status" HeaderText="STATUS" />
                                                                                                                
                                                        <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                                    AlternateText="Delete"
                                                                    Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                                    Height="25px" Visible="true" />
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
                            <td style="text-align: left">
                                <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                    Font-Names="Tahoma"></asp:Label>
                            </td>
                        </tr>
                    </table>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>SEARCH RESULT</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        DataKeyNames="EMPLOYEE_ID"
                                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GridView1_OnRowEditing"
                                        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_OnRowDataBound"
                                        Width="1008px" OnRowDeleting="GridView1_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText = "SL" ItemStyle-Width="30">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:BoundField DataField="SL" HeaderText="SL" />--%>
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="JOINING_DATE" HeaderText="J.D" />

                                            <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                                            <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" />
                                            <asp:BoundField DataField="FIRST_SALARY_PRE" HeaderText="F. SAL" />
                                          
                                            <asp:BoundField DataField="GROSS_SALARY_PRE" HeaderText="G. SAL" />
                                        

                                            <asp:BoundField DataField="INCREMENT_AMOUNT" HeaderText="(5%)" />
                                            <asp:BoundField DataField="MANUAL_INCREMENT_AMOUNT" HeaderText="INC." />
                                            
                                            <asp:BoundField DataField="occurence_type_name" HeaderText="TYPE" />
                                            
                                            <%--<asp:BoundField DataField="approve_status" HeaderText="APPRV.?" />--%>

                                            <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--ADDED ON 07.02.2022--%>
                                            <asp:TemplateField HeaderText="OCCURENCE_TYPE_ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblOCCURENCE_TYPE_ID" runat="server" Text='<%#Eval("OCCURENCE_TYPE_ID")%>'></asp:Label>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
            <td>&nbsp;
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
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
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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
