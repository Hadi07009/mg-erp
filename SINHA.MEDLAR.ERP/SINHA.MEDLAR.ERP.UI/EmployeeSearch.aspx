<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EmployeeSearch.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EmployeeSearch" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .tooltip
        {
            display: none;
            border: solid 1px #708069;
            background-color: #289642;
            color: #fff;
            line-height: 25px;
            border-radius: 5px;
            padding: 5px 10px;
            position: absolute;
            z-index: 1001;
        }
        .auto-style1 {
            width: 282px;
        }
        .auto-style2 {
            height: 22px;
            width: 282px;
        }
    </style>
    <script language="javascript">

        $(document).ready(function () {

            $(".tooltip").closest("tr").mousemove(function (event) {

                $(this).find(".tooltip").css({

                    "left": event.pageX + 1,

                    "top": event.pageY + 1

                }).show();

            }).mouseout(function () { $(this).find(".tooltip").hide(); }); ;

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
                //document.getElementById('<%= btnSearch.ClientID %>').click();
                 e.preventDefault();
                $('#<%=btnSearch.ClientID%>').click();
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
    <table style="width: 100%">
        <tr>
            <td colspan="2">
                <fieldset>
                    <legend>SEARCH CRITERIA</legend>
                    <table style="width: 100%">
                        <tr>
                <td style="text-align: left;" class="auto-style1">
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
                            <td style="text-align: right" class="auto-style1">
                                <asp:Label ID="lblProductCataroy1" runat="server" Text="Unit :"></asp:Label>
                            </td>
                            <td style="width: 167px">
                                <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td style="text-align: right; width: 98px">
                                <asp:Label ID="lblProductCataroy" runat="server" Text="Employee ID :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmployeeId" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                                    placeHolder="EMPLOYEE ID"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style1">
                                <asp:Label ID="lblProductCataroy2" runat="server" Text="Section :"></asp:Label>
                            </td>
                            <td style="width: 167px">
                                <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                            <td style="text-align: right; width: 98px">
                                <asp:Label ID="lblProductCataroy0" runat="server" Text="Employee Name :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpName" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                                    placeHolder="EMPLOYEE NAME"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; " class="auto-style2">
                                <asp:Label ID="lblProductCataroy5" runat="server" Text="Grade :"></asp:Label>
                            </td>
                            <td style="width: 167px; height: 22px;">
                                <asp:DropDownList ID="ddlGradeId" runat="server" Width="240px" Height="22px">
                                </asp:DropDownList>
                            </td>
                            <td style="height: 22px">
                            </td>
                            <td style="height: 22px; text-align: right; width: 98px;">
                                <asp:Label ID="lblProductCataroy7" runat="server" Text="Punch Code :"></asp:Label>
                            </td>
                            <td style="height: 22px">
                                <asp:TextBox ID="txtEmpPunchCode" runat="server" Width="149px" BackColor="White"
                                    placeHolder="PUNCH CODE" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; " class="auto-style2">
                                <asp:Label ID="lblProductCataroy6" runat="server" Text="Blood Group :"></asp:Label>
                            </td>
                            <td style="width: 167px; height: 22px;">
                                <asp:DropDownList ID="ddlBloodGroupIdForSearch" runat="server" Width="240px" Height="22px">
                                </asp:DropDownList>
                            </td>
                            <td style="height: 22px">
                                &nbsp;
                            </td>
                            <td style="height: 22px; text-align: right; width: 98px;">
                                <asp:Label ID="lblProductCataroy4" runat="server" Text="Card No :"></asp:Label>
                            </td>
                            <td style="height: 22px">
                                <asp:TextBox ID="txtCardNo" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                                    placeHolder="CARD NO"> </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; " class="auto-style2">
                                &nbsp;<asp:Label ID="lblProductCataroy8" runat="server" Text="From :"></asp:Label>
                                &nbsp;
                            </td>
                            <td style="width: 167px; height: 22px;">
                                <asp:TextBox ID="dtpFromConfirmDate" runat="server" Width="238px" placeHolder="CONFIRM DATE"
                                    CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                            </td>
                            <td style="height: 22px">
                                &nbsp;
                            </td>
                            <td style="height: 22px; text-align: right; width: 98px;">
                                <asp:Label ID="lblProductCataroy10" runat="server" Text="Type :"></asp:Label>
                            </td>
                            <td style="height: 22px">
                                <asp:DropDownList ID="ddlEmployeeTypeId" runat="server" Width="153px" Height="22px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; " class="auto-style2">
                                <asp:Label ID="lblProductCataroy9" runat="server" Text="To : "></asp:Label>
                            </td>
                            <td style="width: 167px; height: 22px;">
                                <asp:TextBox ID="dtpToConfirmDate" runat="server" Width="238px" placeHolder="CONFIRM DATE"
                                    CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                            </td>
                            <td style="height: 22px">
                                &nbsp;
                            </td>
                            <td style="height: 22px; text-align: right; width: 98px;">
                                <asp:Label ID="lblProductCataroy3" runat="server" Text="In Active :"></asp:Label>
                                &nbsp;
                            </td>
                            <td style="height: 22px">
                                <asp:CheckBox ID="chkActiveYn" runat="server" Text="Yes" />
                            </td>
                        </tr>
                         <tr>
                            <td style="text-align: right; " class="auto-style2">
                                <asp:Label ID="lblProductCataroy11" runat="server" Text="From :"></asp:Label>
                            </td>
                            <td style="width: 167px; height: 22px;">
                                <asp:TextBox ID="dtpFromCreateDate" runat="server" Width="238px" placeHolder="CREATE DATE"
                                    CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                            </td>
                            <td style="height: 22px">
                                &nbsp;</td>
                            <td style="height: 22px; text-align: right; width: 98px;">
                                <asp:Label ID="lblProductCataroy12" runat="server" Text="To : "></asp:Label>
                            </td>
                            <td style="height: 22px">
                                <asp:TextBox ID="dtpToCreateDate" runat="server" Width="149px" placeHolder="CREATE DATE"
                                    CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; " class="auto-style2">
                                &nbsp;
                            </td>
                            <td style="width: 167px; height: 22px;">
                                &nbsp;<asp:DropDownList ID="ddlEmployeeId" runat="server" Width="153px" Height="22px"
                                    Visible="False">
                                </asp:DropDownList>
                                &nbsp;
                            </td>
                            <td style="height: 22px">
                                &nbsp;
                            </td>
                             <td style="text-align: right; width: 69px">
                                     NID No :</td>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtNIDNoSearch" runat="server" Width="148px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"
                                        placeHolder="NID No"></asp:TextBox>
                                </td>
                          </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style1">
                                &nbsp;
                            </td>
                            <td style="width: 167px">
                                <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                    CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                 <asp:Button ID="btnBasicInfoSheet" runat="server" Height="31px" Text="Sheet" Width="52px"
                              CssClass="styled-button-4" OnClick="btnBasicInfoSheet_Click" />
                            </td>

                            <td>
                                &nbsp;
                            </td>
                            <td style="text-align: right; width: 98px">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right" class="auto-style1">
                                &nbsp;</td>
                            <td style="width: 167px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td style="text-align: right; width: 98px">
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
                    <asp:GridView ID="gvEmployeeList" runat="server" AutoGenerateColumns="False"
                        ForeColor="#333333" AllowSorting="True" OnSorting="gvEmployeeList_Sorting"
                        GridLines="None" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        OnRowCommand="gvEmployeeList_RowCommand" OnRowEditing="OnRowEditing" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEmployeeList_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound">
<AlternatingRowStyle CssClass="alt"></AlternatingRowStyle>
                        <Columns>
                            <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" />
                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="ID" />
                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="NAME" />
                            <asp:BoundField DataField="UNIT_NAME" HeaderText="Unit" />
                            <asp:BoundField DataField="SECTION_NAME" HeaderText="Unit" />

                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION" />
                            <asp:BoundField DataField="JOINING_DATE" HeaderText="JOINING DATE" />
                            <asp:BoundField DataField="GENDER_NAME" HeaderText="GENDER">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <div class="tooltip">
                                        SL :
                                        <%#Eval("SL")%><br />
                                        CARD NO :
                                        <%#Eval("CARD_NO")%><br />
                                        NAME :
                                        <%#Eval("EMPLOYEE_NAME")%><br />
                                         Unit :
                                        <%#Eval("UNIT_NAME")%><br />
                                        Section :
                                        <%#Eval("SECTION_NAME")%><br />
                                        DESIGNATION :
                                        <%#Eval("DESIGNATION_NAME")%><br />
                                        JOINING DATE :
                                        <%#Eval("JOINING_DATE")%>
                                        <br />
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

<PagerStyle CssClass="pgr"></PagerStyle>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <%--<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
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
