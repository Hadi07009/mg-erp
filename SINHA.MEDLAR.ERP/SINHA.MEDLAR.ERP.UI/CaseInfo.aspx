<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="CaseInfo.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.CaseInfo" %>

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
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>Case Entry</legend>
                        <table class="style1 border-space">
                            <tr>
                                <td style="text-align: right">
                                    <table class="style1 border-space">
                                        <tr>
                                            <td style="width: 254px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label34" runat="server" Text="Case No :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="width: 95px; height: 25px;">
                                                <asp:TextBox ID="txtCaseNo" runat="server" Width="250" BackColor="White" style="padding-left:5px; padding-right:5px; height:25px;" TabIndex="0"></asp:TextBox>
                                            </td>
                                            <td style="height: 25px; width: 30px;">
                                                &nbsp;
                                            </td>
                                            <td style="height: 25px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label39" runat="server" Text="Case Type :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="height: 25px">
                                                <asp:DropDownList ID="ddlCaseTypeId" runat="server" Width="264" Height="28" TabIndex="1">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                     
                                        <tr>
                                            <td style="width: 254px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label35" runat="server" Text="Defendant :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="width: 95px">
                                                <asp:DropDownList ID="ddlDefendantId" runat="server" AutoPostBack="true" Width="264" Height="28" OnSelectedIndexChanged="ddlDefendantId_SelectedIndexChanged" TabIndex="2">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: right; width: 100px">
                                                <asp:Label ID="Label40" runat="server" Text="Complaintant :"></asp:Label>
                                            &nbsp;</td>
                                            <td>
                                                <asp:DropDownList ID="ddlComplaintantId" runat="server" AutoPostBack="true"  Width="264px" Height="28" OnSelectedIndexChanged="ddlComplaintantId_SelectedIndexChanged" TabIndex="3">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td style="width: 254px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label42" runat="server" Text="Issue Date :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="width: 95px">
                                                <asp:TextBox ID="dtpIssueDate" runat="server" Width="250" BackColor="White" CssClass="date" TabIndex="4" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                                <asp:TextBox ID="txtCaseId" runat="server" Width="16px" BackColor="White" Visible="false"></asp:TextBox>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;</td>
                                            <td style="text-align: right; width: 100px">
                                                <asp:Label ID="Label45" runat="server" Text="Court :"></asp:Label>
                                            &nbsp;</td>
                                            <td>
                                                <asp:DropDownList ID="ddlCourtId" runat="server" Width="264" Height="28" TabIndex="5">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        

                                        <tr>

                                            <td style="height: 25px; text-align: right; width: 254px;">
                                                <asp:Label ID="Label49" runat="server" Text="Case Mode:"></asp:Label>
                                            &nbsp;</td>
                                            <td style="height: 25px">
                                                <asp:DropDownList ID="ddlCaseMode" runat="server" Width="264" Height="28" TabIndex="6">
                                                    <asp:ListItem Value="" Text ="Please Select"></asp:ListItem>
                                                    <asp:ListItem Value="O" Text ="Open"></asp:ListItem>
                                                    <asp:ListItem Value="C" Text ="Close"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                &nbsp;
                                            </td>
                                            <td style="width: 100px; text-align: right; height: 22px;">
                                                <asp:Label ID="Label50" runat="server" Text="Amount :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="width: 95px; height: 30px;">
                                                <asp:TextBox ID="txtAmount" runat="server" Width="250" BackColor="White" TabIndex="7" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                               </td>
                                                                                      
                                        </tr>

                                        <tr>
                                            <td style="width: 254px; text-align: right; height: 22px;">
                                                &nbsp;<asp:Label ID="Label51" runat="server" Text="Remarks :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="width: 95px">
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="252" BackColor="White" TextMode="MultiLine" Height="40" TabIndex="8" style="padding-left:5px; padding-right:5px;"></asp:TextBox>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;</td>
                                            <td style="text-align: right; width: 100px">
                                                &nbsp;&nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>

                                        

                                        <tr>
                                            <td style="width: 254px; text-align: right">
                                                &nbsp;
                                            </td>
                                            <td style="width: auto" colspan="4">
                                            <asp:Button ID="BtnSaveCaseInfo" runat="server" Height="31px" Text="Save" Width="80px" 
                                                    OnClick="BtnSaveCaseInfo_Click" CssClass="styled-button-4" TabIndex="9"/>
                                            <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                                                    OnClick="btnClear_Click" CssClass="styled-button-4" TabIndex="10"/>
                                            </td>
                                        </tr>

                                      
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="2">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1 border-space">

                                            <tr>
                                            <td style="width: 254px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label1" runat="server" Text="Case No :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 95px; height: 22px;">
                                                <asp:TextBox ID="txtCaseNoSearch" runat="server" Width="250" BackColor="White" TabIndex="11" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px" TabIndex="12"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                            </td>
                                            <td style="height: 22px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label2" runat="server" Text="Case Type :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="height: 22px">
                                                <asp:DropDownList ID="ddlCaseTypeIdSearch" runat="server" Width="264px" Height="28" TabIndex="13">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>


                                             <tr>
                                            <td style="width: 254px; text-align: right">
                                                <asp:Label ID="Label3" runat="server" Text="Defendant :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 95px">
                                                <asp:DropDownList ID="ddlDefendantIdSearch" runat="server" Width="264px" Height="28" TabIndex="14">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;
                                            </td>
                                            <td style="text-align: right; width: 100px">
                                                <asp:Label ID="Label4" runat="server" Text="Complaintant :"></asp:Label>
                                            &nbsp;</td>
                                            <td>
                                                <asp:DropDownList ID="ddlComplaintantIdSearch" runat="server" Width="264px" Height="28" TabIndex="15">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                            <tr>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label5" runat="server" Text="From Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width:163px">
                                                <asp:TextBox ID="dtpFromDate" runat="server" Width="250" BackColor="White" CssClass="date" TabIndex="16" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                                </td>

                                                <td style="width: 66px">&nbsp;
                                                    </td>
                                                <td style="text-align: right; width: 100px">
                                                    <asp:Label ID="Label43" runat="server" Text="To Date :"></asp:Label>
                                                    &nbsp;</td>
                                                <td>
                                                <asp:TextBox ID="dtpToDate" runat="server" Width="250" BackColor="White" CssClass="date" TabIndex="17" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
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
                        <legend>SEARCH RESULT</legend>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridViewCaseInfo" runat="server" DataSourceID="" AutoGenerateColumns="False"
                                        OnRowDataBound="GridViewCaseInfo_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="GridViewCaseInfo_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GridViewCaseInfo_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="GridViewCaseInfo_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="GridViewCaseInfo_PageIndexChanging" OnRowDeleting="GridViewCaseInfo_RowDeleting">
                                        <Columns>
                                            
                                            <%--<asp:BoundField DataField="SERIAL" HeaderText="SERIAL" />--%>
                                                                                        
                                            <asp:BoundField DataField="CASE_NO" HeaderText="Case No" ItemStyle-Width="100" />                          
                                            <asp:BoundField DataField="CASE_TYPE_NAME" HeaderText="Case Type" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="DEFENDANT_NAME" HeaderText="Defendant" ItemStyle-Width="200" />                                             
                                            <asp:BoundField DataField="COMPLAINTANT_NAME" HeaderText="Complaintant" ItemStyle-Width="200" />
                                             <asp:BoundField DataField="ISSUE_DATE" HeaderText="Issue Date" ItemStyle-Width="80" />
                                            <asp:BoundField DataField="COURT_NAME" HeaderText="Court" ItemStyle-Width="200" />                                       
                                            <asp:BoundField DataField="CASE_MODE" HeaderText="Mode" ItemStyle-Width="50" />


                                            <asp:BoundField DataField="AMOUNT" HeaderText="Amount" ItemStyle-Width="50" />
                                            <asp:BoundField DataField="REMARKS" HeaderText="Remarks" ItemStyle-Width="100" />
                                            <asp:BoundField DataField="CASE_TYPE_ID" HeaderText="CASE TYPE" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                                            <asp:BoundField DataField="DEFENDANT_ID" HeaderText="Defendant Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                                            <asp:BoundField DataField="COMPLAINTANT_ID" HeaderText="Complaintant Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="CASE_ID" HeaderText="Case Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" /> 
                                            <asp:BoundField DataField="COURT_ID" HeaderText="Court Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                                                                 
                                    <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"
                                                    Style="cursor: pointer" Text="..." CausesValidation="false"  />
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
