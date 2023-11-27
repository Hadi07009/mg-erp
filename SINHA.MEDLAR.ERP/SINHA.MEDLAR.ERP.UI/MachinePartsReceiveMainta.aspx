<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="MachinePartsReceiveMainta.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.MachinePartsReceiveMainta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtMrNo.ClientID %>").focus(); }) 
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
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
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
        <legend>MACHINE PARTS RECEIVE ENTRY</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="3">
                    <fieldset>
                        <legend>MACHINE PARTS RECEIVE ENTRY</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label54" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtMachinePartsReceiveId" runat="server" Width="50px" 
                                        BackColor="Yellow"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label2" runat="server" Text="Date :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="dtpPartsReceiveDate" runat="server" Width="200px" 
                                        BackColor="White" CssClass="date"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label4" runat="server" Text="Machine :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlMachineId" runat="server" Height="21px" Width="202px"  AutoPostBack="True" 
                                        OnSelectedIndexChanged="ddlMachineNameId_SelectedIndexChanged">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label6" runat="server" Text="Model :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlMachineModelId" runat="server" Height="21px" 
                                        Width="202px"  AutoPostBack="True" 
                                        OnSelectedIndexChanged="ddlMachinePartsId_SelectedIndexChanged"  >
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label3" runat="server" Text="Parts :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlMachinePartsId" runat="server" Height="20px" Width="202px"
                                        >
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label55" runat="server" Text="Department :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlDepartmentId" runat="server" Height="20px" 
                                        Width="202px">
                                    </asp:DropDownList>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label7" runat="server" Text="MR No. : "></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtMrNo" runat="server" Height="20px" Width="200px" 
                                        ></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="lblProductCataroy2" runat="server" Text="Box No :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtBoxNo" runat="server" 
                                        Width="200px" Height="20px"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    <asp:Label ID="Label5" runat="server" Text="Quantity :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="txtReceiveQuantity" runat="server" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Width="200px" Height="20px"></asp:TextBox>
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px; height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                                <td style="height: 19px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 279px">
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" CssClass="styled-button-4"
                                        OnClick="btnSave_Click" />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                                <tr>
                                <td style="text-align: right" colspan="3">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 160px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label49" runat="server" Text="MR No :"></asp:Label>
                                                </td>
                                                <td style="width: 179px; height: 22px;">
                                                    <asp:TextBox ID="txtMrNoSearch" runat="server" Width="141px" Height="19px"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 60px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="28px" Text="Search" Width="66px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 66px;">
                                                    <asp:Label ID="Label51" runat="server" Text="Machine :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:DropDownList ID="ddlMachineIdSearch" runat="server" Width="142px" 
                                                        AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlMachineNameIdSearch_SelectedIndexChanged"          
                                                        Height="22px" >
                                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 160px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label52" runat="server" Text="From Date :"></asp:Label>
                                                </td>
                                                <td style="width: 179px; height: 22px;">
                                                    <asp:TextBox ID="dtpPdFromDate" runat="server" Width="139px" BackColor="White" CssClass="date"
                                                        placeHolder="FROM DATE" Height="20px"></asp:TextBox>
                                                </td>
                                                <td style="height: 22px; width: 60px;">
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 66px;">
                                                    <asp:Label ID="Label40" runat="server" Text="Model :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:DropDownList ID="ddlMachineModelIdSearch" runat="server" Width="142px" 
                                                        Height="22px" AutoPostBack="True" 
                                        OnSelectedIndexChanged="ddlMachinePartsIdSearch_SelectedIndexChanged" >
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 160px; text-align: right">
                                                    <asp:Label ID="Label53" runat="server" Text="To Date :"></asp:Label>
                                                   
                                                </td>
                                                <td style="width: 179px">
                                                    <asp:TextBox ID="dtpPdToDate" runat="server" Width="140px" BackColor="White" CssClass="date"
                                                        placeHolder="TO DATE" Height="20px"></asp:TextBox>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 60px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width: 66px">
                                                    <asp:Label ID="Label39" runat="server" Text="Parts :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlMachinePartsIdSearch" runat="server" Width="142px" 
                                                        Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="3">
                                    <%--<asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>--%>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>PARTS RECEIVE RESULT </legend>
                        <div id="divGridViewScroll" style="width: 1008px; overflow: scroll">
                            <table style="width: 100%">
                                <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        OnRowEditing="gvUnit_RowEditing" BorderStyle="Solid">
                        <Columns>
                          <%--  <asp:TemplateField HeaderText="SL">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="MACHINE_PARTS_RECEIVE_ID" HeaderText="ID" Visible="True" />
                            <asp:BoundField DataField="RECEIVE_DATE" HeaderText="DATE" 
                                Visible="True" />
                            <asp:BoundField DataField="MACHINE_NAME" HeaderText="MACHINE" />
                            <asp:BoundField DataField="MACHINE_MODEL_NAME" HeaderText="MODEL" />
                            <asp:BoundField DataField="MACHINE_PARTS" HeaderText="PARTS NAME" />
                            <asp:BoundField DataField="DEPARTMENT_NAME" HeaderText="DEPARTMENT" />
                            <asp:BoundField DataField="MR_NO" HeaderText="M.R NO" />
                            <asp:BoundField DataField="BOX_NO" HeaderText="BOX NO" />
                            <asp:BoundField DataField="RECEIVE_QUANTITY" HeaderText="QUANTITY" />
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
            </div>
            
       
    </fieldset>
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
