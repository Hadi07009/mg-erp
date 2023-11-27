<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="Transfer.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeTransfer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
      $(function () {
          $(".date").datepicker({
              changeMonth: true,
              changeYear: true
          });
      });
        </script>

 <fieldset>
        <legend>Employee Transfer</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 279px">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblId" runat="server" Text="ID : "></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="72px" 
                        BackColor="Yellow"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Employee Name :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="211px" 
                        BackColor="White"></asp:TextBox>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy0" runat="server" Text="Office Name :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlBranchOfficeID" runat="server" Width="215px" Height="22px"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy7" runat="server" Text="Department :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlDepartmentId" runat="server" Width="215px" Height="22px"
                        AutoPostBack="true" >
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy1" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="215px" Height="22px" AutoPostBack="true"
                        >
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Section :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="215px" Height="22px" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy3" runat="server" Text="Designation :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlDesignationId" runat="server" Width="215px" Height="22px"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy4" runat="server" Text="Catagory :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlCatagoryId" runat="server" Width="215px" Height="22px" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Transfer Date :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="dtpTransferDate" runat="server" Width="211px" 
                        BackColor="White"  CssClass="date"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy6" runat="server" Text="Efective Date :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="dtpEffectiveDate" runat="server" Width="211px" 
                        BackColor="White"  CssClass="date"></asp:TextBox>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    <asp:Label ID="lblProductCataroy8" runat="server" Text="Approved By :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:DropDownList ID="ddlApprovedById" runat="server" Width="215px" Height="22px" 
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px; height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
                <td style="height: 19px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear"  CssClass = "styled-button-4"
                        Width="87px" onclick="btnClear_Click" />
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="87px"  CssClass = "styled-button-4"
                        onclick="btnSave_Click" />
                    <asp:Button ID="btnDelete" runat="server" Height="31px" Text="Delete"  CssClass = "styled-button-4"
                        Width="87px" onclick="btnDelete_Click" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                     <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound">
                        <Columns>                                                                                                                                                                                                                                                                                                               
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="Name" />
                            <asp:BoundField DataField="TRANSFER_YEAR" HeaderText="YEAR" />
                            <asp:BoundField DataField="TRANSFER_MONTH" HeaderText="MONTH" />
                             <asp:BoundField DataField="TRANSFER_DATE" HeaderText="TRANSFER_DATE" />
                             <asp:BoundField DataField="EFECTIVE_DATE" HeaderText="EFECTIVE_DATE" />
                              <asp:BoundField DataField="APPROVED_BY" HeaderText="Approved By" />


                        </Columns>
                    </asp:GridView></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 279px">
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
