<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="Permanent.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Permanent" %>

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
        <legend>PERMANENT (STAFF/WORKER)</legend>
        <table class="style1">
                <tr>
                    <td style="text-align: left; width: 918px;">
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
           <%-- </tr>--%>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>PERMANENT PROCESS</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 234px; text-align: right">
                                    <asp:Label ID="lblTransferMsg0" runat="server" Text="From " Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma" ForeColor="Green"></asp:Label>
                                                    </td>
                                <td style="width: 270px; ">
                                                    &nbsp;</td>
                                <td style="width: 176px; text-align: right">
                                    <asp:Label ID="lblTransferMsg1" runat="server" Text="To" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma" ForeColor="Green"></asp:Label>
                                                    </td>
                                <td style="width: 381px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 390px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 365px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 234px; text-align: right">
                                                    <asp:Label ID="Label46" runat="server" Text="Designation/Grade :"></asp:Label>
                                </td>
                                <td style="width: 270px; ">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="137px" Height="20px" Font-Bold="True"
                                        MaxLength="4" ReadOnly="true" BackColor="#DFDFDF"></asp:TextBox>
                                    <asp:TextBox ID="txtGradeNo" runat="server" Width="79px" Height="20px" 
                                        Font-Bold="True" ReadOnly="true" BackColor="#DFDFDF"></asp:TextBox>
                                </td>
                                <td style="width: 176px; text-align: right">
                                                    <asp:Label ID="Label47" runat="server" Text="Designation/Grade :"></asp:Label>
                                </td>
                                <td style="width: 381px; text-align: left;">
                                    <asp:DropDownList ID="ddlDesignationIdTo" runat="server" Width="186px" Height="19px">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="ddlGradeNoTo" runat="server" Width="51px" Height="18px"> 
                                    </asp:DropDownList>
                                    </td>
                                        <td>
                                    <asp:Label ID="Label40" runat="server" Text="Card No/Name :"></asp:Label>                                   
                                  </td>
                                <td style="width: 365px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="55px" Height="20px" 
                                        Font-Bold="True" ReadOnly="true" BackColor="#DFDFDF"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="137px" Height="20px" Font-Bold="True"
                                        MaxLength="4" ReadOnly="true" BackColor="#DFDFDF"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 234px; text-align: right">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="width: 270px; ">
                                    <asp:TextBox ID="txtUnitName" runat="server" Width="221px" Height="20px" Font-Bold="True"
                                        MaxLength="4" ReadOnly="true" BackColor="#DFDFDF"></asp:TextBox>
                                </td>
                                <td style="width: 176px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="width: 381px; text-align: left;">
                                    <asp:DropDownList ID="ddlUnitIdTo" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 400px; text-align: left;">
                                                    <asp:Label ID="Label48" runat="server" Text="Employee ID :"></asp:Label>
                                </td>
                                <td style="width: 365px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="198px" BackColor="#DFDFDF" style="margin-left: 0" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 234px; text-align: right">
                                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="width: 270px; ">
                                    <asp:TextBox ID="txtSectionName" runat="server" Width="220px" Height="20px" Font-Bold="True"
                                        MaxLength="4" ReadOnly="true" BackColor="#DFDFDF"></asp:TextBox>
                                </td>
                                <td style="width: 176px; text-align: right">
                                    <asp:Label ID="Label44" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="width: 381px; text-align: left;">
                                    <asp:DropDownList ID="ddlSectionIdTo" runat="server" Width="240px" 
                                        Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:Label ID="Label45" runat="server" Text="Year/Month:"></asp:Label>
                                </td>
                                <td style="width: 365px">
                                    <%--<asp:TextBox ID="dtpEffectDate" runat="server" Width="96px" Height="20px" CssClass="date"
                                        Font-Bold="True"></asp:TextBox>--%>
                                    <asp:TextBox ID="txtPermanentYear" runat="server" Width="92px" Height="20px" Font-Bold="True"
                                        MaxLength="4"></asp:TextBox>
                                    <asp:DropDownList ID="ddlMonthId" runat="server" Width="105px" 
                                        Height="19px">
                                    </asp:DropDownList>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 234px; text-align: right">
                                                    <asp:Label ID="Label39" runat="server" Text="First/Gross salary :"></asp:Label>
                                </td>
                                <td style="width: 270px; ">
                                                    <asp:TextBox ID="txtFirstSalaryFrom" runat="server" Width="120px" BackColor="#DFDFDF" ReadOnly="true" Font-Bold="True"></asp:TextBox>
                                                    <asp:TextBox ID="txtGrossSalaryFrom" runat="server" Width="95px" BackColor="#DFDFDF" ReadOnly="true" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 176px; text-align: right">
                    <asp:Label ID="Label41" runat="server" Text="First/Gross Salary :"></asp:Label>
                                </td>
                                <td style="width: 381px; text-align: left;">
                                                    <asp:TextBox ID="txtFirstSalaryTo" runat="server" Width="120px" BackColor="White" Font-Bold="True"></asp:TextBox>
                                                    <asp:TextBox ID="txtGrossSalaryTo" runat="server" Width="110px" BackColor="White" Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 390px; text-align: right;">
                                    Effect Date :</td>
                                <td style="width: 365px">
                                   
                                    <%--<asp:DropDownList ID="ddlMonthId" runat="server" Width="190px" 
                                        Height="19px">
                                    </asp:DropDownList>--%>
                                    <asp:TextBox ID="dtpEffectDate" runat="server" Width="196px" Height="20px" CssClass="date"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 234px; text-align: right; height: 15px;">
                                                    </td>
                                <td style="width: 270px; height: 15px;">
                                                    </td>
                                <td style="width: 176px; text-align: right; height: 15px;">
                                    </td>
                                <td style="width: 381px; text-align: left; height: 15px;">
                                    </td>
                                <td style="width: 390px; text-align: left; height: 15px;">
                                    </td>
                                <td style="width: 365px; height: 15px;">
                                    </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="6">
                                    <asp:Label ID="lblTransferMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma" ForeColor="Black"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="6">
                                                    <%--<asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />--%>
                                    <%--<asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="50px" OnClick="btnNext_Click"
                                        CssClass="styled-button-4" />--%>
                                    <%--<asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnPrevious_Click" />--%>
                                    <asp:Button ID="btnSalaryProcess" runat="server" Height="31px" Text="Save" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnSalaryProcess_Click" style="margin-top: 0" />
                                    <asp:Button ID="btnProcessPromotion" runat="server" Height="31px" Text="Process" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnProcessPromotion_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnTransferSheet" runat="server" Height="31px" Text="Sheet" Width="60px"
                                        CssClass="styled-button-4" OnClick="btnTransferSheet_Click" />
                                    <asp:Button ID="btnPermanentSheet" runat="server" Height="31px" Text="Sheet(Permanent)" Width="114px"
                                        CssClass="styled-button-4" OnClick="btnPermanentSheet_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="6">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td style="text-align: right" colspan="5">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1" style="width: 129%; height: 60px;">

                                            <tr>
                                                <%--new--%>
                                               
                                                <td style="width: 60px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right" class="auto-style3">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;</td>
                                                

                                                <%--end--%>
                                            </tr>


                                         
                                            <tr>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label3" runat="server" Text="Unit :"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="25px">
                                                    </asp:DropDownList>
                                                    </td>

                                                <td style="width: 60px">&nbsp;
                                                    <asp:Label ID="Label5" runat="server" Text="Section :"></asp:Label>
                                                </td>
                                                
                                                <td>
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="25px">
                                                    </asp:DropDownList>
                                                    <asp:Button ID="Button1" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;</td>
                                            </tr>

                                            

                                            <tr>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="lblDate" runat="server" Text="Date:"></asp:Label>
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="dtpDate" runat="server" Width="234px" Height="20px" CssClass="date"
                                                      Font-Bold="True"></asp:TextBox>
                                                </td>

                                                <td style="width: 60px">&nbsp;</td>
                                                <td style="text-align: right; width: 69px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>

                                            

                                            <tr>
                                                <td style="text-align: right" class="auto-style3">
                                                    &nbsp;</td>
                                                <td style="width: 163px">
                                                    &nbsp;</td>

                                                <td style="width: 60px">&nbsp;</td>
                                                <td style="text-align: right; width: 69px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>

                                            

                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            </table>
                    </fieldset>
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>WORKER PERMANENT RESULT </legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="Sl" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="Card" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="Name" />
                                            <asp:BoundField DataField="DESIGNATION_ID_FROM" HeaderText="D.From" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="D.To" />
                                            <asp:BoundField DataField="UNIT_ID_FROM" HeaderText="Unit From" />
                                            <asp:BoundField DataField="unit_name" HeaderText="Unit To" />
                                            <asp:BoundField DataField="SECTION_ID_FROM" HeaderText="Section From" />
                                            <asp:BoundField DataField="section_name" HeaderText="Section To" />
                                            <asp:BoundField DataField="GRADE_ID_FROM" HeaderText="Grade From" />  
                                            <asp:BoundField DataField="grade_no" HeaderText="Grade No" />  
                                            <asp:BoundField DataField="FIRST_SALARY_FROM" HeaderText="F.Salary From" />
                                            <asp:BoundField DataField="FIRST_SALARY_TO" HeaderText="F.Salary To" />                
                                            <asp:BoundField DataField="GROSS_SALARY_from" HeaderText="G.Salary From" />
                                            <asp:BoundField DataField="GROSS_SALARY_TO" HeaderText="G.Salary To" />
                                         <%--  <asp:BoundField DataField="GRADE_ID_FROM" HeaderText="GRADE FROM" />--%>
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                           
                                        </Columns>
                                    </asp:GridView>
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
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" ClientSelectionMode="SingleRow" GridLines="None"
                        AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing"
                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="gvEmployeeList_PageIndexChanging" OnRowDataBound="OnRowDataBound"
                        CausesValidation="false" OnRowCommand="gvEmployeeList_RowCommand">
                        <Columns>
                            
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                             <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" />
                            <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" />
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE" />
                             <asp:BoundField DataField="first_salary" HeaderText="FIRST SALARY" />
                            <asp:BoundField DataField="gross_salary" HeaderText="GROSS SALARY" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:TemplateField HeaderText="ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
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
