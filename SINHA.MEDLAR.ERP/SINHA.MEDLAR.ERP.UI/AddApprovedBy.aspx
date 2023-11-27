<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddApprovedBy.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddApprovedBy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .ButtonClass {
            border: 1px solid #900;
            cursor: pointer;
        }

        .auto-style1 {
            width: 337px;
        }
    </style>
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
        function isDelete() {
            return confirm("Do you want to delete this row ?");

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
        <legend>APPROVED BY EMPLOYEE INFORMAITON</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 601px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>ADD APPROVED EMPLOYEE</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right" class="auto-style1">
                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style1">
                                    <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style1">&nbsp;
                                </td>
                                <td style="width: 390px; text-align: left;">&nbsp;
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" class="auto-style1">&nbsp;</td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" CssClass="styled-button-4"
                                        Width="66px" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click"
                                        CssClass="styled-button-4" />
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>APPROVED BY EMPLOYEE ENTRY RESULT</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvApprovedByEmpList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="gvApprovedByEmpList_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="gvApprovedByEmpList_OnRowEditing"
                                        OnRowDeleting="gvApprovedByEmpList_RowDeleting" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                        OnSelectedIndexChanged="gvApprovedByEmpList_OnSelectedIndexChanged" CausesValidation="false"
                                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvApprovedByEmpList_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" ItemStyle-Width="100px"/>
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" ItemStyle-Width="350px"/>
                                            <asp:BoundField DataField="designation_name" HeaderText="DESIGNATION" ItemStyle-Width="400px"/>
                                            <asp:CommandField ShowDeleteButton="True" ButtonType="Button" ControlStyle-CssClass="styled-button-4" />
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
                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GridView1_OnRowEditing"
                        CausesValidation="false" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDataBound="GridView1_OnRowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
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
                            <asp:TemplateField HeaderText="CARD NO">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtCardNo" runat="server" Text='<%#Eval("CARD_NO")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtCardNo" runat="server" Text='<%#Eval("CARD_NO")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblCardNo" runat="server" Text='<%#Eval("CARD_NO")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NAME">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Text='<%#Eval("EMPLOYEE_NAME")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Text='<%#Eval("EMPLOYEE_NAME")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EMPLOYEE_NAME")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DESIGNATION">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDesignationName" runat="server" Text='<%#Eval("DESIGNATION_NAME")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtDesignationName" runat="server" Text='<%#Eval("DESIGNATION_NAME")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblDesignationName" runat="server" Text='<%#Eval("DESIGNATION_NAME")%>'></asp:Label>
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
