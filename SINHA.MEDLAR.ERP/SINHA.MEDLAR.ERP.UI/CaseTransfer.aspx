<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="CaseTransfer.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.CaseTransfer" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");
        }
    </script>

    <script type="text/javascript" language="javascript">

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
    <script type="text/javascript">
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
                document.getElementById('<%= BtnSaveCaseInfo.ClientID %>').click();
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
        <legend>Case Information</legend>
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
                 <td style="text-align: right" colspan="4">
                     <fieldset>
                         <legend>Souece Case Information</legend>
                         <table class="style1 border-space"> 
                         <tr>
                             <td style="width: 100px; text-align: right; height: 25px;">
                                 <asp:Label ID="Label1" runat="server" Width="100px" Text="Source Case :" Height="22px"></asp:Label>
                             </td>
                             <td style="width: 220px; height: 25px;">
                                <asp:TextBox ID="txtSourceCaseNo" runat="server" Width="220px" BackColor="#FFFF66" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                <asp:TextBox ID="txtSourseCaseId" runat="server" Visible="false"></asp:TextBox>
                             </td>
                             <td style="width: 100px; height: 22px;">
                                  <asp:Label ID="Label50" runat="server" Width="95" Text="Case Type :"></asp:Label>
                             </td>
                             <td style="width: 220px; height: 22px;">
                                <asp:TextBox ID="txtCaseTypeName" runat="server" Width="220" BackColor="#FFFF66" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                             </td>
                             <td style="text-align: right; width: 100px; height: 22px;">
                                <asp:Label ID="Label49" runat="server" Text="Issue Date :"></asp:Label>
                             </td>
                             <td style="width: 220px; height: 25px">
                               <asp:TextBox ID="dtpSourceCaseIssueDate" runat="server" Width="220px" BackColor="Yellow" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                             </td>
                         </tr>  
                          <tr>
                             <td style="width: 100px; text-align: right; height: 22px;">
                                 <asp:Label ID="Label2" runat="server" Text="Defendant :"></asp:Label>
                                  </td>
                             <td style="width: 200px; height: 25px;">
                                                <asp:TextBox ID="txtDefendantName" runat="server" Width="220" BackColor="Yellow" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                  </td>
                             <td style="width: 100px;text-align: right; height: 22px;">
                                 <asp:Label ID="Label51" runat="server" Width="100px" Text="Complaintant : "></asp:Label>
                             </td>
                             <td style="width: 220px; height: 25px;">
                                 <asp:TextBox ID="txtComplaintantName" runat="server" Width="220px" BackColor="Yellow" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                             </td>
                             <td style="text-align: right; width: 100px; height: 22px;">
                                 <asp:Label ID="Label52" runat="server" Text="Amount :"></asp:Label>
                                  </td>
                             <td style="height: 25px; width:220px;">
                              <asp:TextBox ID="txtSourseCaseAmount" runat="server" Width="220" BackColor="Yellow" ReadOnly="true" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                            </td>
                         </tr>
                         </table>
                     </fieldset>
                  </td>
           </tr>
            <tr>
                <td style="text-align: right" colspan="4">
                    <fieldset>
                        <legend>Case Entry</legend>
                        <table class="style1 border-space">
                            <tr>
                                <td style="text-align: right">
                                    <table class="style1 border-space">
                                        <tr>
                                            <td style="width: 100px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label34" runat="server" Width="100" Text="Case No :"></asp:Label></td>
                                            <td style="width: 220px; height: 25px;">
                                                <asp:TextBox ID="txtCaseNo" runat="server" Width="220" BackColor="White" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                                <asp:TextBox ID="txtCaseId" runat="server" Visible="false"></asp:TextBox>
                                            </td>
                                            <td style="width: 100px; height: 25px;">
                                                <asp:Label ID="Label39" runat="server"  Width="95px" Text="Case Type :"></asp:Label>
                                            </td>
                                            <td style="height: 25px; width: 220px;">
                                                &nbsp;<asp:DropDownList ID="ddlCaseTypeId" runat="server" Width="232" Height="28px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 25px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label42" runat="server" Text="Issue Date :"></asp:Label>
                                            </td>
                                            <td style="height: 25px; width:220px;">
                                                <asp:TextBox ID="dtpIssueDate" runat="server" Width="220" BackColor="White" CssClass="date" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 100px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label45" runat="server" Text="Court :"></asp:Label>
                                            </td>
                                            <td style="width: 220px; height: 25px;">
                                                <asp:DropDownList ID="ddlCourtId" runat="server" Width="232px" Height="28px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 100px; height: 25px;">
                                                <asp:Label ID="Label47" runat="server" Text="Amount :" Width="95"></asp:Label>
                                                </td>
                                            <td style="width: 220px; height: 25px;">
                                                <asp:TextBox ID="txtAmount" runat="server" Width="220" BackColor="White" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                                </td>
                                            <td style="text-align: right; width: 100px; height: 25px;">
                                                <asp:Label ID="Label48" runat="server" Text="Remarks :"></asp:Label>
                                            </td>
                                            <td style=" width: 220px;height: 40px">
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="220px" BackColor="White" TextMode="MultiLine" Height="40" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
                                            </td>
                                        </tr>
                                                                             
                                       
                                        <tr>
                                            <td style="width: 100px; text-align: right">
                                                &nbsp;
                                            </td>
                                            <td style="width: auto" colspan="5">
                                            <asp:Button ID="BtnSaveCaseInfo" runat="server" Height="31px" Text="Add" Width="80px" 
                                                    OnClick="BtnSaveCaseInfo_Click" CssClass="styled-button-4" />
                                            <asp:Button ID="BtnEdit" runat="server" Height="31px" Text="Edit" Width="80px" 
                                                    OnClick="BtnEdit_Click" CssClass="styled-button-4" />
                                            <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                                    OnClick="btnClear_Click" CssClass="styled-button-4" />
                                            </td>
                                        </tr>

                                      
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1 border-space">

                                             <tr>
                                            <td style="width: 100px; text-align: right">
                                                <asp:Label ID="Label3" runat="server" Text="Defendant :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 95px">
                                                <asp:DropDownList ID="ddlDefendantIdSearch" runat="server" Width="232px" Height="28px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                            </td>
                                            <td style="text-align: right; width: 100px">
                                                <asp:Label ID="Label4" runat="server" Text="Complaintant :"></asp:Label>
                                            &nbsp;
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlComplaintantIdSearch" runat="server" Width="232px" Height="28px">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        </table>
                                    </fieldset>
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
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>Transfer Case Info</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvTransferCaseInfo" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="source_case_id,CASE_ID"
                                        OnRowDataBound="gvTransferCaseInfo_OnRowDataBound" AllowSorting="True" EnableViewState="true" AlternatingRowStyle-BackColor="WhiteSmoke"
                                        GridLines="None" AllowPaging="false" OnRowEditing="gvTransferCaseInfo_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvTransferCaseInfo_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="gvTransferCaseInfo_RowCommand"
                                        OnPageIndexChanging="gvTransferCaseInfo_PageIndexChanging" OnRowDeleting="gvTransferCaseInfo_RowDeleting">
                                        <Columns>
                                            
                                            <asp:BoundField DataField="serial_no" HeaderText="SERIAL" ItemStyle-Width="20"/>
                                            <asp:BoundField DataField="CASE_ID" HeaderText="Case Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="COURT_ID" HeaderText="Court Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                         
                                            <asp:BoundField DataField="case_type_id" HeaderText="case_type_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="CASE_NO" HeaderText="Case No" ItemStyle-Width="100" />               
                                            <asp:BoundField DataField="ISSUE_DATE" HeaderText="Issue Date" ItemStyle-Width="80" />           
                                            <asp:BoundField DataField="DEFENDANT_NAME" HeaderText="Defendant" ItemStyle-Width="200" />                                             
                                            <asp:BoundField DataField="COMPLAINTANT_NAME" HeaderText="Complaintant" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="COURT_NAME" HeaderText="Court" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="case_type_name" HeaderText="Case Type Name" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="CASE_MODE" HeaderText="Mode" ItemStyle-Width="50" />  
                                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" ItemStyle-Width="50" />
                                            <asp:BoundField DataField="REMARKS" HeaderText="Remarks" ItemStyle-Width="100" />  
                                             <asp:BoundField DataField="source_case_no" HeaderText="Source Case No" ItemStyle-Width="50" />
                                            <asp:BoundField DataField="source_case_id" HeaderText="source_case_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            
                                             <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                                 <ItemTemplate>
                                                     <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                         AlternateText="Delete"
                                                         Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                         Height="25px" Visible="true" />
                                                 </ItemTemplate>
                                              </asp:TemplateField>         
                                                                                
                                             <asp:TemplateField HeaderText="Edit" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                     <ItemTemplate>
                                                         <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"  AlternateText="Edit"
                                                             Text="Edit" CausesValidation="false"  />
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
                        <legend>Source Case Information</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridViewCaseInfo" runat="server" DataSourceID="" AutoGenerateColumns="False" EnableEventValidation="false"
                                        OnRowDataBound="GridViewCaseInfo_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridViewCaseInfo_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridViewCaseInfo_OnSelectedIndexChanged" 
                                        CausesValidation="false" OnRowCommand="GridViewCaseInfo_RowCommand" AlternatingRowStyle-BackColor="WhiteSmoke"
                                        OnPageIndexChanging="GridViewCaseInfo_PageIndexChanging" OnRowDeleting="GridViewCaseInfo_RowDeleting">
                                        <Columns>
                                            
                                            <asp:BoundField DataField="serial_no" HeaderText="SERIAL" />
                                            <asp:BoundField DataField="CASE_ID" HeaderText="Case Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="defendant_id" HeaderText="defendant_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="complaintant_id" HeaderText="complaintant_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="case_type_id" HeaderText="case_type_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="CASE_NO" HeaderText="Case No" ItemStyle-Width="100" />               
                                            <asp:BoundField DataField="ISSUE_DATE" HeaderText="Issue Date" ItemStyle-Width="80" />           
                                            <asp:BoundField DataField="DEFENDANT_NAME" HeaderText="Defendant" ItemStyle-Width="200" />                                             
                                            <asp:BoundField DataField="COMPLAINTANT_NAME" HeaderText="Complaintant" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="COURT_NAME" HeaderText="Court" ItemStyle-Width="200" />
                                             <asp:BoundField DataField="case_type_name" HeaderText="Case Type Name" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="CASE_MODE" HeaderText="Mode" ItemStyle-Width="50" />
                                            
                                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" ItemStyle-Width="50" />
                                            <asp:BoundField DataField="REMARKS" HeaderText="Remarks" ItemStyle-Width="100" />  
                                                                                         
                                             <asp:TemplateField HeaderText="Add" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                     <ItemTemplate>
                                                         <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select" AlternateText="Add"
                                                             CausesValidation="false"  />
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

        </table>
    </fieldset>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <%--<cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
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
