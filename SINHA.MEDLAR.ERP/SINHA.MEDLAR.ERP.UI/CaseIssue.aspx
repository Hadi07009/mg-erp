<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="CaseIssue.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.CaseIssue" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");
        }
    </script>

    <script language="javascript">

        function SelectAllCheckboxes(spanChk) {

            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ?
        spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" &&
              elm[i].id != theBox.id) {
                    //elm[i].click();
                    if (elm[i].checked != xState)
                        elm[i].click();
                    //elm[i].checked=xState;
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
                document.getElementById('<%= btnSearch.ClientID %>').click();
            }
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
        <legend>EMPLOYEE CARD PROCESS</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 917px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" 
                        OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" 
                        OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>SEARCH CRITERIA</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right">
                                    <table class="style1">
                                        <tr>
                                            <td style="width: 254px; text-align: right; height: 22px;">
                                                <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 95px; height: 22px;">
                                                <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                &nbsp;
                                            </td>
                                            <td style="height: 22px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                            </td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtEmpId" runat="server" Width="236px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 254px; text-align: right">
                                                <asp:Label ID="Label35" runat="server" Text="Section :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 95px">
                                                <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: right; width: 100px">
                                                <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmpCardNo" runat="server" Width="236px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 254px; text-align: right">
                                                &nbsp;</td>
                                            <td style="width: 95px">
                                                &nbsp;</td>
                                            <td style="width: 66px">
                                                &nbsp;</td>
                                            <td style="text-align: right; width: 100px">
                                                <asp:Label ID="Label41" runat="server" Text="To Address Type :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlAddressTypeId" runat="server" Width="240px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Permanent Address"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Present Address"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 254px; text-align: right">
                                                &nbsp;</td>
                                            <td style="width: 95px">
                                                &nbsp;</td>
                                            <td style="width: 66px">
                                                &nbsp;</td>
                                            <td style="text-align: right; width: 100px">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>

                                        <tr>
                                            <td style="width: 254px; text-align: right">
                                                &nbsp;
                                            </td>
                                            <td style="width: auto" colspan="4">
                                            <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                                    OnClick="btnSearch_Click" CssClass="styled-button-4" />
                                            <asp:Button ID="BtnIssueCase" runat="server" Height="31px" Text="Issue Case" Width="80px" BackColor="Red"
                                                    OnClick="BtnIssueCase_Click" CssClass="styled-button-4" />

                                                <asp:Button ID="BtnSearchCaseOnly" runat="server" Height="31px" Text="Search Case Only" Width="130px" BackColor="Red"
                                                    OnClick="BtnSearchCaseOnly_Click" CssClass="styled-button-4" />
                                             <asp:Button ID="BtnReorderCase" runat="server" Height="31px" Text="Re-Order" Width="80px" BackColor="Red"
                                                    OnClick="BtnReorderCase_Click" CssClass="styled-button-4" />
                                             <asp:Button ID="btnCaseSheet" runat="server" Height="31px" Text="Case Sheet" Width="80px" BackColor="Red"
                                                    OnClick="btnCaseSheet_Click" CssClass="styled-button-4" />
                                             <asp:Button ID="BtnCaseNotice" runat="server" Height="31px" Text="Notice" Width="80px" BackColor="Red"
                                                    OnClick="BtnCaseNotice_Click" CssClass="styled-button-4" />                                               

                                            <asp:Button ID="BtnEnvelope" runat="server" Height="31px" Text="Envelope" Width="80px" BackColor="Red"
                                                    OnClick="BtnEnvelope_Click" CssClass="styled-button-4" />

                                            </td>
                                          
                                            <%--<td style="text-align: right; width: 81px">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;
                                            </td>--%>
                                        </tr>

                                      
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
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
                        <legend>SEARCH RESULT</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridViewCaseInfo" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="EMPLOYEE_ID" 
                                        OnRowDataBound="GridViewCaseInfo_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridViewCaseInfo_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridViewCaseInfo_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="GridViewCaseInfo_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridViewCaseInfo_PageIndexChanging" OnRowDeleting="GridViewCaseInfo_RowDeleting">
                                        <Columns>
                                            
                                            <asp:BoundField DataField="SERIAL" HeaderText="SERIAL" />

                                            <%--<asp:TemplateField HeaderText="Image" HeaderStyle-Width="200px">  
                                                <ItemTemplate>  
                                                    <asp:Image ID="EMPLOYEE_PIC" runat="server" ImageUrl='<%# Eval("EMPLOYEE_PIC") %>' Height="40px" Width="40px" />  
                                                </ItemTemplate>  
                                                <EditItemTemplate>  
                                                    <asp:Image ID="EMPLOYEE_PIC" runat="server" ImageUrl='<%# Eval("EMPLOYEE_PIC") %>' Height="40px" Width="40px" />   
                                                </EditItemTemplate>  
                                            </asp:TemplateField>--%>
                                                                                        
                                            <asp:BoundField DataField="EMPLOYEE_NAME" HeaderText="EMPLOYEE NAME" ItemStyle-Width="250" />
                                            <asp:BoundField DataField="DESIGNATION_NAME" HeaderText="DESIGNATION NAME" ItemStyle-Width="350" />
                                            <asp:BoundField DataField="EMPLOYEE_ID" HeaderText="EMPLOYEE ID" ItemStyle-Width="150" />                                           
                                            <asp:BoundField DataField="CARD_NO" HeaderText="CARD NO" ItemStyle-Width="100" />
                                            <asp:TemplateField HeaderText="ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>' ReadOnly="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                 <ItemTemplate>
                                                     <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                         AlternateText="Delete"
                                                         Width="28px" CommandName="Delete" OnClientClick="return isDelete();"
                                                         Height="18px" Visible="true" />
                                                 </ItemTemplate>
                                              </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Display Order">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDisplayOrder" runat="server" Text='<%#Eval("DISPLAY_ORDER")%>' ReadOnly="false"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                       </Columns>
                                        <EditRowStyle BackColor="#999999"></EditRowStyle>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>

            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>SEARCH RESULT</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="GridView1_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridView1_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="GridView1_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="SL" HeaderText="SL" />
                                            <asp:TemplateField HeaderText="CARD NO">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtCardNo" runat="server" Text='<%#Eval("CARD_NO")%>' ReadOnly="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="EMPLOYEE NAME">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmployeeName" runat="server" Text='<%#Eval("EMPLOYEE_NAME")%>'
                                                        ReadOnly="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DESIGNATION">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtDesignation" runat="server" Text='<%#Eval("DESIGNATION_NAME")%>'
                                                        ReadOnly="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>' ReadOnly="true"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="ISSUE_DATE" HeaderText="ISSUE DATE" />--%>
                                        </Columns>
                                        <EditRowStyle BackColor="#999999"></EditRowStyle>
                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></FooterStyle>
                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center"></PagerStyle>
                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333"></RowStyle>
                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
                                        <SortedAscendingCellStyle BackColor="#E9E7E2"></SortedAscendingCellStyle>
                                        <SortedAscendingHeaderStyle BackColor="#506C8C"></SortedAscendingHeaderStyle>
                                        <SortedDescendingCellStyle BackColor="#FFFDF8"></SortedDescendingCellStyle>
                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE"></SortedDescendingHeaderStyle>
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
    </table>
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
