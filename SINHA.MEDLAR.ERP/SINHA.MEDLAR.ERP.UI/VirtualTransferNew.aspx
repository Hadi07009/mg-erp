﻿
<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="VirtualTransferNew.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.VirtualTransferNew" %>


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
        <legend>TRANSFER PROCESS</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; height: 19px" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
           
            <tr>
            <td style="width: 300px; text-align: right; height: 22px;">
                <asp:Label ID="Label1" runat="server" Text="Time:"></asp:Label>
                &nbsp;
            </td>
            <td style="width: 163px; height: 22px;">
                <%--<asp:DropDownList ID="ddlShift" runat="server" Width="240px" Height="22px">
                </asp:DropDownList>--%>
                <asp:DropDownList ID="ddlTimeId" runat="server" Width="240px" Height="28px">
                    </asp:DropDownList>
                <asp:HiddenField ID="HfTransferId" runat="server" />
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
                <asp:Label ID="Label2" runat="server" Text="Floor"></asp:Label>
                &nbsp;
            </td>
            <td style="width: 163px; height: 22px;">
                <asp:DropDownList ID="ddlFloor" runat="server" Width="240px" Height="22px">
                    </asp:DropDownList>
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
                <asp:Label ID="Label3" runat="server" Text="From Date:"></asp:Label>
                &nbsp;
            </td>
            <td style="width: 163px; height: 22px;">
                <asp:TextBox ID="dtpFromDate" runat="server" CssClass="date" Width="235px" Height="20px"></asp:TextBox>
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
                <asp:Label ID="Label4" runat="server" Text="To Date"></asp:Label>
                &nbsp;
            </td>
            <td style="width: 163px; height: 22px;">
                <asp:TextBox ID="dtpToDate" runat="server" CssClass="date" Width="235px" Height="20px"></asp:TextBox>
            </td>
            <td style="height: 22px; width: 66px;">
                
            </td>
            <td style="height: 22px; text-align: right; width: 69px;">
                &nbsp;</td>
                <td style="height: 22px">
                    &nbsp;</td>
            </tr>


            <tr>
            <td style="width: 300px; text-align: right; height: 22px;">
                &nbsp;
            </td>
            <td style="width: 240px; height: 22px;">
                <asp:Button ID="btnTransfer" runat="server" Height="31px" CssClass="styled-button-4"
                        Text="Transfer" Width="66px" OnClick="btnTransfer_Click" />
                <asp:Button ID="btnUpdateTransfer" runat="server" Height="31px" CssClass="styled-button-4"
                        Text="Update" Width="66px" OnClick="btnUpdateTransfer_Click" />
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

                    <asp:GridView ID="GvVirtualTransfer" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="transfer_id"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="GvVirtualTransfer_OnRowEditing"
                        OnSelectedIndexChanged="GvVirtualTransfer_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnPageIndexChanging="GvVirtualTransfer_PageIndexChanging" OnRowDataBound="GvVirtualTransfer_OnRowDataBound" OnRowDeleting="GvVirtualTransfer_RowDeleting">
                        <Columns>

                           <%-- <asp:BoundField DataField="SL" HeaderText="SL" />--%>
                            <asp:TemplateField HeaderText = "SL" ItemStyle-Width="30">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                            
                            <asp:BoundField DataField="transfer_id" HeaderText="transfer id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />

                            <asp:BoundField DataField="FROM_DATE" HeaderText="FROM DATE" />
                            <asp:BoundField DataField="TO_DATE" HeaderText="TO DATE" />
                            <asp:BoundField DataField="virtual_time_name" HeaderText="Time" />
                            
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                                        
                            <asp:BoundField DataField="virtual_time_id" HeaderText="virtual_time_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="virtual_floor_id" HeaderText="virtual_floor_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            

                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                               <ItemTemplate>
                                   <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png" AlternateText="Delete"
                                       Width="25px" CommandName="Delete" OnClientClick="return isDelete();"
                                       Height="20px" Visible="true" />
                               </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false"  ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

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