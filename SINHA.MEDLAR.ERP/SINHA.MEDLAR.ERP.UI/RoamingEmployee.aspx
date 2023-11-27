
<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="RoamingEmployee.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.RoamingEmployee" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

        function checkAll(objRef) {

            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {                
                var row = inputList[i].parentNode.parentNode;

                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        row.style.backgroundColor = "white";
                        inputList[i].checked = true;
                    }
                    else {
                        if (row.rowIndex % 2 == 0) {
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
                        objRef.style.backgroundColor = "#C2D69B";
                    }
                    else {
                        objRef.style.backgroundColor = "white";

                    }
                }
            }
        }
    </script>

    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this record?");
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
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <fieldset>
        <legend>Roaming Employee</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
           
            <tr>
            <td style="width: 300px; text-align: right; height: 22px;">
                <asp:Label ID="Label1" runat="server" Text="Roaming Type:"></asp:Label>
                &nbsp;
            </td>
            <td style="width: 163px; height: 22px;">
                <%--<asp:DropDownList ID="ddlShift" runat="server" Width="240px" Height="22px">
                </asp:DropDownList>--%>
                <asp:DropDownList ID="ddlRoamingTypeId" runat="server" Width="240px" Height="28px">
                    </asp:DropDownList>
            </td>
            <td style="height: 22px; width: 66px;">
                
            </td>
            <td style="height: 22px; text-align: right; width: 69px;">
                <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                </td>
            </tr>

            <tr>
            <td style="width: 300px; text-align: right; height: 22px;">
                Roaming Date:&nbsp;
            </td>
            <td style="width: 163px; height: 22px;">
                <asp:TextBox ID="dtpRoamingDate" runat="server" CssClass="date" Width="235px" Height="20px"></asp:TextBox>
            </td>
            <td style="height: 22px; width: 66px;">
                
            </td>
            <td style="height: 22px; text-align: right; width: 69px;">
                <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                </td>
            </tr>

            <tr>
            <td style="width: 300px; text-align: right; height: 22px;">
                &nbsp;
            </td>
            <td style="width: 163px; height: 22px;">
                    <asp:TextBox ID="txtRoamingId" runat="server" Width="10px" Height="20px" ReadOnly="True"
                                        BackColor="White" Font-Bold="True"
                                        ForeColor="Red"></asp:TextBox>
                </td>
            <td style="height: 22px; width: 66px;">
                
            </td>
            <td style="height: 22px; text-align: right; width: 69px;">
                <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                </td>
                <td style="height: 22px">
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True"
                                        ForeColor="Red"></asp:TextBox>
                </td>
            </tr>


            <tr>
            <td style="width: 300px; text-align: right; height: 22px;">
                &nbsp;
            </td>
            <td style="width: 240px; height: 22px;">
                <asp:Button ID="btnSave" runat="server" Height="31px" CssClass="styled-button-4"
                        Text="Save" Width="66px" OnClick="btnSave_Click" />
                <asp:Button ID="btnReset" runat="server" Height="31px" CssClass="styled-button-4"
                        Text="Reset" Width="66px" OnClick="btnReset_Click" />
            </td>
            <td style="height: 22px; width: 66px;">
                
            </td>
            <td style="height: 22px; text-align: right; width: 69px;">
            </td>
                <td style="height: 22px">
                </td>
            </tr>

        </table>
    </fieldset>

        <table style="width: 100%">
                                   
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <asp:Label ID="Label7" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px" colspan="3">
                    <fieldset>
                        <legend>SEARCH CRITERIA</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 300px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                    &nbsp;
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
                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 300px; text-align: right">
                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td style="width: 163px">
                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 66px">
                                    &nbsp;
                                </td>
                                <td style="text-align: right; width: 69px">
                                    <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 300px; text-align: right">
                               Roaming Date:&nbsp;
                                </td>
                                <td style="width: 163px">
                                   <asp:TextBox ID="dtpRoamingDateSearch" runat="server" CssClass="date" Width="235px" Height="20px"></asp:TextBox>
                                </td>
                                <td style="width: 66px">
                                    &nbsp;</td>
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
   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">

                    <asp:GridView ID="GvRoamingEmployee" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="employee_id"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GvRoamingEmployee_OnRowEditing"
                        OnSelectedIndexChanged="GvRoamingEmployee_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="GvRoamingEmployee_PageIndexChanging" OnRowDataBound="GvRoamingEmployee_OnRowDataBound" OnRowDeleting="GvRoamingEmployee_RowDeleting">
                        <Columns>

                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="ROAMING_DATE" HeaderText="DATE" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="roaming_type_name" HeaderText="Roaming Type"/>
                            <asp:BoundField DataField="roaming_type_id" HeaderText="roaming_type_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="roaming_id" HeaderText="roaming_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                           
                            

                       <%--     <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                               <ItemTemplate>
                                   <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png" AlternateText="Delete"
                                       Width="25px" CommandName="Delete" OnClientClick="return isDelete();"
                                       Height="20px" Visible="true" />
                               </ItemTemplate>
                            </asp:TemplateField>--%>

                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" CausesValidation="false" AlternatingRowStyle-CssClass="alt">
                        <Columns>
                           
                               <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />

                               <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <br />
    </fieldset>
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
