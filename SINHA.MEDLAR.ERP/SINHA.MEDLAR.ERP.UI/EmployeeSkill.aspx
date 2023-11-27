<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ERP.Master" CodeBehind="EmployeeSkill.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeSkill" %>

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


        function CheckBoxSelectionValidation() {
            var count = 0;
            var objgridview = document.getElementById('<%= gvEmployeeSkill.ClientID %>');
            /*Get all the controls preent in gridview*/
            for (var i = 0; i < objgridview.getElementsByTagName("input").length; i++) {
                /*Get the input control type*/
                var chknode = objgridview.getElementsByTagName("input")[i];
               /*Check weather checkbox is selected or not*/
                if (chknode != null && chknode.type == "checkbox" && chknode.checked) {
                    count = count + 1;
                }
            }
            /*Alert message if none of the checkboc is selected*/
            if (count == 0) {
                alert("Please select at least one checkbox from gridview.");
                return false;
            }
            else {
                return true;
            }
        }

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
                document.getElementById('<%= btnSave.ClientID %>').click();
            }
        }
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
    <fieldset class="style1">
        <legend>Employee Skill</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 900px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left;">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged"/>
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                      ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 26px;" align="right" colspan="3">


                    <table class="style1">
                        <tr>
                            <td style="text-align: right; width: 200px;">
                                <asp:Label ID="lblSkillLevelId" runat="server" Font-Bold="False" Text="Skill Level :"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                                <asp:DropDownList ID="ddlSkillkLevelId" runat="server" Width="213px" Height="22px"></asp:DropDownList>
                            </td>

                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">
                                <asp:Label ID="Label1" runat="server" Text="Card No/Name :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                <asp:TextBox ID="txtEmployeeName" runat="server" Width="208px" Height="20px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 200px;">
                                <asp:Label ID="lblEffectDate" runat="server" Text="Effect Date:" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                                <asp:TextBox ID="dtpEffectDate" runat="server" BackColor="White" Width="210" CssClass="date"></asp:TextBox>
                            </td>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">
                                <asp:Label ID="Label41" runat="server" Text="Employee ID :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeId" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 200px;">
                                
                            </td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                               
                                <asp:HiddenField ID="hf_skill_id" runat="server"/>                               
                            </td>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">
                                <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right; width: 200px;">
                                <%--<asp:Label ID="lblIsActive" runat="server" Text="Active:" Font-Bold="False"></asp:Label>--%>   
                            </td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                            </td>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right; width: 200px;">&nbsp;</td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                                <asp:Button ID="btnSave" runat="server" Height="31px" Text="Add" Width="52px"
                                    CssClass="styled-button-4" OnClick="btnSave_Click"  OnClientClick="javascript:return CheckBoxSelectionValidation();" />
                                <asp:Button ID="btnClear" runat="server" Height="31px" Text="Reset" Width="59px" CssClass="styled-button-4"
                                    OnClientClick="target = '_SELF';" OnClick="btnClear_Click" />
                              <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet"   CssClass = "styled-button-4"
                                        Width="55px"  onclick="btnSheet_Click"
                                       />

                            </td>

                            <td style="text-align: left;">
                                &nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 54px;">&nbsp;</td>
                <td style="text-align: right;">&nbsp;</td>
                <td style="text-align: justify">&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="3">
                    <table class="style1">
                        <tr>
                            <td style="text-align: right" colspan="4">
                                <fieldset>
                                    <legend>SEARCH CRITERIA</legend>
                                    <table class="style1">
                                        <tr>
                                            <td style="width: 248px; text-align: right; height: 22px;">
                                                <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                            </td>
                                            <td style="width: 163px; height: 22px;">
                                                <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px" 
                                                    Enabled="true">
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
                                            <td style="height: 22px; width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="height: 22px; text-align: right;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 248px; text-align: right">
                                                <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                            </td>
                                            <td style="width: 163px">
                                                <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px" 
                                                      Enabled="true">
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
                                            <td style="width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="text-align: right">&nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td style="width: 248px; text-align: right">
                                               
                                <asp:Label ID="lblEffectDate0" runat="server" Text="Date:" Font-Bold="False"></asp:Label>
                                               
                                            </td>
                                            <td style="width: 163px">
                                              
                                <asp:TextBox ID="dtpFromDate" runat="server" BackColor="White" Width="235px" CssClass="date" Height="20px"></asp:TextBox>
                                              
                                            </td>
                                            <td style="width: 66px">&nbsp;
                                            </td>
                                            <td style="text-align: right; width: 69px">
                                                
                                            </td>
                                            <td style="width: 176px">
                                                
                                            </td>
                                            <td style="width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="text-align: right">&nbsp;</td>
                                        </tr>

                                        <%--<tr>
                                            <td style="width: 248px; text-align: right">&nbsp;</td>
                                            <td style="width: 163px; text-align: right;">&nbsp;</td>
                                            <td style="width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="text-align: right; width: 69px">&nbsp;</td>
                                            <td style="width: 176px; text-align: right;">&nbsp;</td>
                                            <td style="width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="text-align: right">&nbsp;</td>
                                        </tr>--%>
                                    </table>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                    Font-Names="Tahoma"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                    </table>
               </td>
            </tr>


               <tr>
                            <td style="text-align: justify">
                                <asp:Label ID="Label2" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                    Font-Names="Tahoma"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <fieldset>
                                    <legend>Employee Skill ENTRY RESULT</legend>
                                    <%-- </div>--%>
                                    <table style="width: 100%;margin-right: 0; " >
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                                    DataKeyNames="SKILL_ID"
                                                    AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                                                    CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GridView1_OnRowEditing"
                                                    OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                                                    OnPageIndexChanging="GridView1_PageIndexChanging" OnRowDataBound="GridView1_OnRowDataBound"
                                                    Width="1008px" OnRowDeleting="GridView1_RowDeleting">
                                                    <Columns>

                                                        <asp:BoundField DataField="SL" HeaderText="SL" />
                                                        <asp:BoundField DataField="SKILL_LEVEL_NAME" HeaderText="SKILL" />
                                                        <asp:BoundField DataField="EFFECT_DATE" HeaderText="EFFECT DATE" />
                                                      <%--  <asp:BoundField DataField="ACTIVE_YN" HeaderText="ACTIVE" />--%>
                                                        
                                                        <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                                    Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                        <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                                <ItemTemplate>
                                                                    <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                                        AlternateText="Delete"
                                                                        Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                                        Height="25px" Visible="true" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        <asp:BoundField DataField="SKILL_ID" HeaderText="skillId" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                                                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                                        <asp:BoundField DataField="skill_level_id" HeaderText="SkilLevellId" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                                                        <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>

                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <%-- </div>--%>
                                </fieldset>
                            </td>
                        </tr>


            <tr>
                <td colspan="2" style="text-align: right">
                    <fieldset>
                        <legend>SEARCH RESULT</legend>
                        <table style="width: 100%; margin-right: 0;">
                            <tr>
                                <td colspan="2">

                                    <asp:GridView ID="gvEmployeeSkill" runat="server" DataSourceID=""
                                        AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                                        OnRowDataBound="gvEmployeeSkill_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="gvEmployeeSkill_OnRowEditing"
                                        OnRowCommand="gvEmployeeSkill_RowCommand"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvEmployeeSkill_OnSelectedIndexChanged"
                                        CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="gvEmployeeSkill_PageIndexChanging"
                                        OnSelectedIndexChanging="gvEmployeeSkill_SelectedIndexChanging" Width="1008px">
                                        <Columns> 
                                             <asp:TemplateField ItemStyle-Width="20px" >
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>                                          
                                            <asp:BoundField DataField="SLNo" HeaderText="Sl" ItemStyle-Width="75px" />
                                            <asp:BoundField DataField="CardNo" HeaderText="Card No" ItemStyle-Width="150px" />
                                            <asp:BoundField DataField="EmployeeName" HeaderText="Name" ItemStyle-Width="300px" />
                                            <asp:BoundField DataField="DesignationName" HeaderText="Designation" ItemStyle-Width="350px"/>
                                       
                                            <asp:BoundField DataField="SkillLevelName" HeaderText="Skill" ItemStyle-Width="50px"/>
                                            <asp:BoundField DataField="EffectiveDate" HeaderText="Effect Date" ItemStyle-Width="100px" />   
                                                                                               
                                            <asp:BoundField DataField="EmployeeId" HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                                           <%-- <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" Visible="false" />--%>
                                            <asp:TemplateField HeaderText="Id" ItemStyle-Width="10px" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" >
                                               <ItemTemplate>
                                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EmployeeId")%>' ReadOnly="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField DataField="SkillLevelId" HeaderText="SkillId" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>

                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnselect" Width="30" Height="20" runat="server" CommandName="Select"
                                                                    Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"/>
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
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
