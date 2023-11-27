<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="MenuPermission.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MenuPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <legend>MENU OPERATION</legend>
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
                        <legend>ADD MENU</legend>
                        <table class="style1">

                            <tr>
                                <td style="width: 546px; text-align: right">
                                    <asp:Label ID="Label34" runat="server" Text="User Name :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlEmployeeId" runat="server" Width="225px" Height="22px" AutoPostBack="true"
                                        BackColor="White" OnSelectedIndexChanged="ddlEmployeeId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 546px; text-align: right">
                                    <asp:Label ID="Label35" runat="server" Text="Employee Name :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtEmployeeFullName" runat="server" Width="220px" Height="21px"
                                        Font-Bold="True" BackColor="Yellow"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="27px" Height="21px" Font-Bold="True"
                                        BackColor="Yellow" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtMenuId" runat="server" Width="27px" Height="21px" Font-Bold="True"
                                        BackColor="Yellow" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="width: 546px; text-align: right">
                                    <asp:Label ID="Label36" runat="server" Text="Software Name :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlSoftwareId" runat="server" Width="225px" Height="22px"
                                        BackColor="White" OnSelectedIndexChanged="ddlEmployeeId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;
                                </td>
                                <td>&nbsp;
                                </td>
                            </tr>

                            <tr>
                                <td style="width: 546px; text-align: right">
                                    <asp:Label ID="Label38" runat="server" Text="Office Name :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlBranchOfficeId" runat="server" Width="225px"
                                        Height="22px"
                                        BackColor="White"
                                        OnSelectedIndexChanged="ddlEmployeeId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="width: 546px; text-align: right">
                                    <asp:Label ID="Label37" runat="server" Text="Menu Position :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:DropDownList ID="ddlMenuName" runat="server" Width="225px" Height="22px"
                                        BackColor="White" OnSelectedIndexChanged="ddlEmployeeId_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 247px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="width: 546px; text-align: right">&nbsp;</td>
                                <td style="width: 390px; text-align: left;">&nbsp;</td>
                                <td style="width: 247px; text-align: right;">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>

                            <tr>
                                <td style="text-align: center; height: 22px;" colspan="4">
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Add" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnAdd_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnShow_Click" />
                                </td>
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
                        <legend>MEMU  ENTRY RESULT</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvEmployeeList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="gvEmployeeList_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                                        DataKeyNames="MENU_ID"
                                        OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged" CausesValidation="false"
                                        OnRowDeleting="gvEmployeeList_OnRowDeleting"
                                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging">
                                        <Columns>


                                            <asp:BoundField DataField="MENU_ID" HeaderText="MENU ID" />

                                            <asp:BoundField DataField="MENU_NAME" HeaderText="MENU NAME" />
                                            <asp:BoundField DataField="MENU_PATH" HeaderText="MENU PATH" />
                                            <asp:BoundField DataField="SOFTWARE_NAME" HeaderText="SOFTWARE" />


                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                <ItemTemplate>
                                                    <asp:ImageButton  ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png" AlternateText="Delete"
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
                        OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        CausesValidation="false" AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDataBound="GridView1_OnRowDataBound" Width="1012px">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkMenuId" runat="server" onclick="Check_Click(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <%--<asp:TemplateField HeaderText="EMPLOYEE ID">
                                <FooterTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:TextBox>
                                </FooterTemplate>--%>
                            <%--  <ItemTemplate>
                                    <asp:Label ID="lblEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>'></asp:Label>
                                </ItemTemplate>--%>
                            <%-- </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="MENU ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMenuId" runat="server" Text='<%#Eval("MENU_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtMenuId" runat="server" Text='<%#Eval("MENU_ID")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuId" runat="server" Text='<%#Eval("MENU_ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MENU NAME">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtMenuName" runat="server" Text='<%#Eval("MENU_NAME")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtMenuName" runat="server" Text='<%#Eval("MENU_NAME")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuName" runat="server" Text='<%#Eval("MENU_NAME")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="MENU PATH">
                                <FooterTemplate>
                                    <asp:TextBox ID="txtMenuPath" runat="server" Text='<%#Eval("MENU_PATH")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblMenuPath" runat="server" Text='<%#Eval("MENU_PATH")%>'></asp:Label>
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
