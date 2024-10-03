<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="TiffinEntry.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.TiffinEntry" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtTiffinDay.ClientID %>").focus(); }) 
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
                    <%--document.getElementById('<%= btnSave.ClientID %>').click();--%>
                    e.preventDefault();
                    $('#<%=btnSave.ClientID%>').click();
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
        <legend>TIFFIN INFORMATION</legend>
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
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>TIFFIN ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 263px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="Card No/Name :"></asp:Label>
                                </td>
                                <td style="width: 293px; text-align: left;">
                                    <asp:TextBox ID="txtCardNo" runat="server" Width="54px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="170px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                    <asp:TextBox ID="txtSL" runat="server" Width="31px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 91px; text-align: right;">
                                    <asp:Label ID="Label19" runat="server" Text="Year/Month :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYear" runat="server" Width="103px" Height="20px" 
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtMonth" runat="server" Width="48px" Height="20px" Font-Bold="True"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 263px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Designation :"></asp:Label>
                                </td>
                                <td style="width: 293px; text-align: left;">
                                    <asp:TextBox ID="txtDesignationName" runat="server" Width="269px" Height="20px" BackColor="Yellow"
                                        ReadOnly="True" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                                <td style="width: 91px; text-align: right;">
                                    <asp:Label ID="Label42" runat="server" Text="ID :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Width="156px" Height="20px" ReadOnly="True"
                                        BackColor="Yellow" Font-Bold="True" ForeColor="Red"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 263px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label27" runat="server" Text="Total Day :"></asp:Label>
                                </td>
                                <td style="width: 293px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtTiffinDay" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                    <asp:TextBox ID="txtSLNew" runat="server" Width="31px" Height="20px" BackColor="White"
                                        ReadOnly="True" Font-Bold="True" Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 91px; text-align: right; height: 22px;">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>

                            <%--<tr>
                                <td style="width: 263px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label43" runat="server" Text="Tiffin Day Additional :" Visible="false"></asp:Label>
                                </td>
                                <td style="width: 293px; text-align: left; height: 22px;" >
                                    <asp:TextBox ID="txtTiffinDayAdditional" runat="server" Width="130px" Height="20px" Visible="false"
                                        Font-Bold="True"></asp:TextBox>
                                    </td>
                                <td style="width: 91px; text-align: right; height: 22px;">
                                    &nbsp;</td>
                                <td style="height: 22px">
                                    &nbsp;</td>
                            </tr>--%>

                            <tr>
                                <td style=" text-align: right; width: 263px;">
                                    <asp:Label ID="Label3" runat="server" Text="Total Amount :"></asp:Label>
                                </td>
                                <td style="width: 293px; text-align: left;">
                                    <asp:TextBox ID="txtTiffinAmount" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox>
                                </td>
                                <td style="width: 91px; text-align: right;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                    <asp:HiddenField ID="HfGridView" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td style=" text-align: right; width: 263px;">
                                    <asp:Label ID="Label4" runat="server" Text="Tiffin Day :"></asp:Label></td>
                                <td style="width: 293px; text-align: left;">
                                    <asp:TextBox ID="txtTDay" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox></td>
                                <td style="width: 91px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td style=" text-align: right; width: 263px;">
                                    <asp:Label ID="Label5" runat="server" Text="Iftar Day :"></asp:Label></td></td>
                                <td style="width: 293px; text-align: left;">
                                    <asp:TextBox ID="txtIftarDay" runat="server" Width="130px" Height="20px" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        Font-Bold="True"></asp:TextBox></td>
                                <td style="width: 91px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>

                            <tr>
                                <td style=" text-align: right; width: 263px;">
                                    &nbsp;</td>
                                <td style="width: 293px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 91px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: center" colspan="4">
                                    <asp:Button ID="btnAdd" runat="server" Height="31px" Text="Atten." Width="66px" 
                                        CssClass = "styled-button-4" OnClick="btnAdd_Click"/>
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click" CssClass = "styled-button-4"/>
                                    <asp:Button ID="btnNext" runat="server" Height="31px" Text="Next" Width="66px" OnClick="btnNext_Click" CssClass = "styled-button-4"/>
                                    <asp:Button ID="btnPrevious" runat="server" Height="31px" Text="Previous" Width="66px" CssClass = "styled-button-4"
                                        OnClick="btnPrevious_Click" />
                                    <asp:Button ID="btnShow" runat="server" Height="31px" Text="Show" Width="66px" OnClick="btnShow_Click" CssClass = "styled-button-4"/>
                                    <asp:Button ID="btnTiffinSheet" runat="server" Height="31px" Text="Master Sheet" Width="88px" CssClass = "styled-button-4"
                                        OnClick="btnTiffinSheet_Click" />
                                    <asp:Button ID="btnBkashSheet" runat="server" Height="31px" Text="Bkash Sheet" Width="79px" CssClass = "styled-button-4"
                                        OnClick="btnBkashSheet_Click" />
                                    <asp:Button ID="btnCashSheet" runat="server" Height="31px" Text="Cash Sheet" Width="79px" CssClass = "styled-button-4"
                                        OnClick="btnCashSheet_Click" />
                                    <asp:Button ID="btnTiffinWalletSheet" runat="server" CssClass="styled-button-4" Height="31px" OnClick="btnTiffinWalletSheet_Click" Text="BKash Template(All)" Width="130px" />
                                    <asp:Button ID="btnBkashReq" runat="server" Height="31px" Text="Bkash Req" Width="79px" CssClass = "styled-button-4"
                                        OnClick="btnBkashReq_Click" />
                                    <asp:Button ID="btnCashReq" runat="server" Height="31px" Text="Cash Req" Width="79px" CssClass = "styled-button-4"
                                        OnClick="btnCashReq_Click" />
                                    <asp:Button ID="btnTiffinRequsition" runat="server" Height="31px" Text="Requsition" CssClass = "styled-button-4"
                                        Width="75px" OnClick="btnTiffinRequsition_Click" />
                                    <asp:Button ID="btnTiffinRequsitionSummery" runat="server" Height="31px" 
                                        Text="Summary" CssClass = "styled-button-4"
                                        Width="75px" onclick="btnTiffinRequsitionSummery_Click"  />
                                    <asp:Button ID="btnPaySlip" runat="server" Height="31px" Text="Slip" Width="75px"
                                        CssClass="styled-button-4" OnClick="btnPaySlip_Click"  />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">

                                            <tr>
                                                <%--new--%>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label1" runat="server" Text="Unit Group :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlUnitGroupId" runat="server" Width="240px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Unit Group- 1"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Unit Group- 2"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Unit Group- 3"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Unit Group- 4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px">
                                                   <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px" CssClass = "styled-button-4"
                                                        OnClick="btnSearch_Click" />
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label2" runat="server" Text="Employee Type :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 66px">
                                                    <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="152px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Staff"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Worker"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                

                                                <%--end--%>
                                            </tr>

                                            <tr>
                                                <td style="width: 258px; text-align: right; height: 22px;">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px; height: 22px;">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="height: 22px; width: 66px;">
                                                    <%--<asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px" CssClass = "styled-button-4"
                                                        OnClick="btnSearch_Click" />--%>
                                                    &nbsp;
                                                </td>
                                                <td style="height: 22px; text-align: right; width: 69px;">
                                                    <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                                </td>
                                                <td style="height: 22px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 258px; text-align: right">
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
                        <legend>TIFFIN ENTRY RESULT</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True"
                                        GridLines="None" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        CausesValidation="false" AlternatingRowStyle-CssClass="alt" 
                                        OnPageIndexChanging="GridView1_PageIndexChanging">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                                        <Columns>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD" />
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                                            <asp:BoundField DataField="TIFFIN_DAY" HeaderText="DAY" />
                                             <%--<asp:BoundField DataField="tiffin_day_additional" HeaderText="ADDITIONAL DAY" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />--%>
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                                </ItemTemplate>

<ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:CommandField ShowDeleteButton="True" />
                                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
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
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="gvEmployeeList_OnRowEditing"
                        CausesValidation="false" OnSelectedIndexChanged="gvEmployeeList_OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="gvEmployeeList_OnRowDataBound">
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
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
