<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="TransferProcess.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.TransferProcess" %>

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
        <legend>TRANSFER PROCESS</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 176px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; text-align: right; width: 162px;">
                    <asp:Label ID="lblId12" runat="server" Text="Office To  :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlOfficeIdTo" runat="server" Width="215px" Height="22px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlOfficeIdTo_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; text-align: right; width: 162px;">
                    <asp:Label ID="lblId13" runat="server" Text="Unit To :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlUnitIdTo" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; text-align: right; width: 162px;">
                    <asp:Label ID="lblId14" runat="server" Text="Section To :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlSectionIdTo" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; text-align: right; width: 162px;">
                    <asp:Label ID="lblId7" runat="server" Text="Year/Month  :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtYear" runat="server" Width="75px" Height="20px"></asp:TextBox>
                    <asp:TextBox ID="txtMonth" runat="server" Width="50px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 176px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; text-align: right; width: 162px;">
                    <asp:Label ID="lblId10" runat="server" Text="Efective Date  :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="dtpEfectiveDate" runat="server" CssClass="date" Width="130px" Height="20px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 176px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; text-align: right; width: 162px;">
                    <asp:Label ID="lblId11" runat="server" Text="Approved By :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlApprovedById" runat="server" Width="215px" Height="22px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 176px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 162px; text-align: right;">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 176px; height: 19px">
                    &nbsp;
                </td>
                <td style="height: 19px; width: 162px;">
                    &nbsp;
                </td>
                <td style="height: 19px">
                    <asp:Button ID="btnAdd" runat="server" Height="31px" CssClass="styled-button-4" Text="Add"
                        Width="66px" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnProcess" runat="server" Height="31px" CssClass="styled-button-4"
                        Text="Process" Width="66px" OnClick="btnProcess_Click" />
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
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
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" CausesValidation="false" AlternatingRowStyle-CssClass="alt">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SL">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSerialNo" runat="server" Text='<%#Eval("SL")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtSerialNo" runat="server" Text='<%#Eval("SL")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSerialNo" runat="server" Text='<%#Eval("SL")%>'></asp:Label>
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
