<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false"
    CodeBehind="OfficeShiftHoliday.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.OfficeShiftHoliday" %>

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
    <fieldset>
        <legend>Employee Shift-Holiday Mapping</legend>
        <table class="style1">
            
            <tr>
                <td style="text-align: left; height: 26px;" align="right" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 26px;" align="right" colspan="4">


                    <table class="style1">
                       <%-- <tr>
                            <td style="text-align: right; width: 334px;">
                                &nbsp;</td>
                            <td style="text-align: left; width: 310px;" class="auto-style6">
                                &nbsp;</td>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>--%>
                        <tr>
                            <td style="text-align: right; width: 248px;">
                                <strong>
                                    <asp:Label ID="lblId2" runat="server" Text="Holiday Date:" Font-Bold="False" Visible="false"></asp:Label>
                                    <asp:Label ID="lblDayId" runat="server" Text="Day:" Font-Bold="False"></asp:Label>
                                </strong>
                            </td>
                            <td style="text-align: left; width: 240px;" class="auto-style6">
                                <%--<asp:TextBox ID="dtpHolidayDate" runat="server" Width="240px" BackColor="White" CssClass="date" Visible="false"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddlHoliDay" runat="server" Width="240px" BackColor="White">
                                    <asp:ListItem Value="" Text="Select Day Off" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Sunday"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Monday"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Tuesday"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="Wednesday"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="Thursday"></asp:ListItem>
                                    <asp:ListItem Value="6" Text="Friday"></asp:ListItem>
                                    <asp:ListItem Value="7" Text="Saturday"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td style="text-align: right;  width: 140px;" >
                                <asp:Label ID="Label1" runat="server" Text="Card No/Name"></asp:Label>
                            </td>
                            <td class="auto-style5; width: 300px;">
                                <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                <asp:TextBox ID="txtEmployeeName" runat="server" Width="254px" Height="20px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 248px;">
                                <asp:Label ID="lblEffectDate" runat="server" Text="Effect Date:" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 240px;" class="auto-style6">
                                <asp:TextBox ID="txtEffectDate" runat="server" Width="240px" BackColor="White" CssClass="date"></asp:TextBox>
                            </td>

                            <td style="text-align: right;  width: 140px;" >
                                <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 315px;">
                                <asp:TextBox ID="txtDesignationName" runat="server" Width="315px" Height="20px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 248px;">
                                <asp:Label ID="lblIsActive" runat="server" Text="Active:" Font-Bold="False"></asp:Label>                                
                            </td>
                            <td style="text-align: left; width: 240px;" class="auto-style6">
                                <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes"/>
                                <asp:HiddenField ID="hf_mapping_id" runat="server"/>
                            </td>

                            <td style="text-align: right; width: 140px;">
                                <asp:Label ID="lblEmployeeId" runat="server" Text="Employee Id:" Font-Bold="False"></asp:Label>
                                
                            </td>
                            <td style="text-align: left; width: 315px;" class="auto-style6">
                                <asp:TextBox ID="txtEmployeeId" runat="server" Width="240px" BackColor="Yellow"
                                    ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                            </td>
                           

                        </tr>

                        <tr>
                            <td style="text-align: right; width: 248px;">&nbsp;
                            </td>
                            <td style="text-align: left; width: 240px;" class="auto-style6">
                                <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px"
                                    CssClass="styled-button-4" OnClick="btnSave_Click" />
                                <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" CssClass="styled-button-4"
                                    OnClientClick="target = '_SELF';" OnClick="btnShow_Click" />
                                <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px" CssClass="styled-button-4"
                                    OnClientClick="target = '_SELF';" OnClick="btnClear_Click" />
                            </td>
                            <td style="text-align: left;" colspan="2">&nbsp;</td>
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
                            <td style="text-align: right">
                                <fieldset>
                                    <legend>SEARCH CRITERIA</legend>

                                    <table class="style1">
                                        <tr>
                                            <td style="width: 248px; text-align: right; height: 22px;">
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
                                            <td style="height: 22px; width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="height: 22px; text-align: right;">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 248px; text-align: right">
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
                                            <td style="width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="text-align: right">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td style="width: 248px; text-align: right">&nbsp;</td>
                                            <td style="width: 163px; text-align: right;">&nbsp;</td>
                                            <td style="width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="text-align: right; width: 69px">&nbsp;</td>
                                            <td style="width: 176px; text-align: right;">&nbsp;</td>
                                            <td style="width: 66px; text-align: right;">&nbsp;</td>
                                            <td style="text-align: right">&nbsp;</td>
                                        </tr>
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
                            <td>
                                <fieldset>
                                    <legend>OFFICE SHIFT HOLIDAY ENTRY RESULT</legend>
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

                                                        <asp:BoundField DataField="SL" HeaderText="SL" />
                                                        <%--<asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />--%>
                                                        <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="EMPLOYEE ID" />

                                                        <asp:BoundField DataField="HOLIDAY_MANE" HeaderText="HOLIDAY" />
                                                        <asp:BoundField DataField="EFFECT_DATE" HeaderText="EFFECT_DATE" />
                                                        <asp:BoundField DataField="active_yn" HeaderText="Active" />
                                                        
                                                        <asp:BoundField DataField="Holiday_Id" HeaderText="Holiday_Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                        <asp:BoundField DataField="mapping_id" HeaderText="mapping_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                       
                                                        <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                        <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                                        <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />

                                                        <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btnSub" runat="server" Text="Delete"
                                                                    Width="45px" CommandName="Delete" OnClientClick="return isDelete();"
                                                                    CssClass="styled-button-4" Height="25px" Visible="true" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

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
                                    <%-- </div>--%>
                                </fieldset>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">&nbsp;</td>
                        </tr>
                    </table>
            </tr>
            <tr>
                <td colspan="3" style="text-align: right">
                    <fieldset>
                        <legend>SEARCH RESULT</legend>
                        <table style="width: 124%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvOfficeShiftTime" runat="server" DataSourceID=""
                                        AutoGenerateColumns="False" DataKeyNames="EMPLOYEE_ID"
                                        OnRowDataBound="gvOfficeShiftTime_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="gvOfficeShiftTime_OnRowEditing"
                                        OnRowCommand="gvOfficeShiftTime_RowCommand"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvOfficeShiftTime_OnSelectedIndexChanged"
                                        CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="gvOfficeShiftTime_PageIndexChanging"
                                        OnSelectedIndexChanging="gvOfficeShiftTime_SelectedIndexChanging" Width="1003px">
                                        <Columns>

                                            <%--<asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" />
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="EMPLOYEE ID" />
                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <%--<asp:TemplateField HeaderText="ID">
                                                <FooterTemplate>
                                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
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
