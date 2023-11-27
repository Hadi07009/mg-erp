<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="CaseHistory.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.CaseHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" language="javascript">
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
    <script type="text/javascript" language="javascript">
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
    <script type="text/javascript" language="javascript">
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
                document.getElementById('<%= BtnSaveCaseHistory.ClientID %>').click();
            }
        }
    </script>
    <script type="text/javascript" language="javascript">

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

    <script type="text/javascript" language="javascript">

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
        <legend>Case History</legend>
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
                        <legend>Case History Entry</legend>
                        <table class="style1">
                            <tr>
                                <td style="text-align: right">
                                    <table class="style1">
                                        <tr>
                                            <td style="width: 254px; text-align: right; height: 22px;">
                                                <asp:Label ID="Label43" runat="server" Text="Case No :"></asp:Label>
                                                </td>
                                            <td style="width: 95px; height: 25px;">
                                                <asp:DropDownList ID="ddlCaseId" runat="server" Width="240px" Height="28px" AutoPostBack="true" OnSelectedIndexChanged="ddlCaseId_SelectedIndexChanged">
                                                </asp:DropDownList>
                                               </td>
                                            <td style="height: 22px; width: 66px;">
                                                <asp:TextBox ID="txtHistoryId" runat="server" Width="28px" BackColor="White" Visible="false"></asp:TextBox>
                                            </td>
                                            <td style="height: 28px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label50" runat="server" Text="Defendant :" Height="28"></asp:Label>
                                            </td>
                                            <td style="height: 28px">
                                                <asp:TextBox ID="txtDefendantName" runat="server" Width="236px" BackColor="Yellow" Height="25px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="width: 254px; text-align: right; height: 22px;">
                                                <asp:Label ID="Label34" runat="server" Text="Activity Type :"></asp:Label>
                                                
                                                </td>
                                            <td style="width: 95px; height: 25px;">
                                                <asp:DropDownList ID="ddlActivityType" runat="server" Width="240px" Height="25px">
                                                </asp:DropDownList>
                                               </td>
                                            <td style="height: 22px; width: 66px;">
                                                &nbsp;</td>
                                            <td style="height: 28px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label51" runat="server" Text="Complaintant :" Height="28"></asp:Label>
                                            </td>
                                            <td style="height: 28px">
                                                <asp:TextBox ID="txtComplaintantName" runat="server" Width="236px" BackColor="Yellow" Height="25px" ReadOnly="true"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="width: 254px; text-align: right;height:25px" >
                                                <asp:Label ID="Label42" runat="server" Text="Date :"></asp:Label>
                                            </td>
                                            <td style="width: 95px">
                                                <asp:TextBox ID="dtpHistoryDate" runat="server" Width="236px" BackColor="White" CssClass="date" Height="25px"></asp:TextBox>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;</td>
                                            <td style="text-align: right; width: 100px;height:28px">
                                                <asp:Label ID="Label39" runat="server" Text="Case Status :" Height="28"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCaseStatussId" runat="server" Width="240px" Height="28px">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td style="width: 254px; text-align: right; height:28px">
                                                <asp:Label ID="Label44" runat="server" Text="Appeared Y/N :" Height="25"></asp:Label>
                                            </td>
                                            <td style="width: 95px;height:28px">
                                                <asp:CheckBox ID="ChkAppearedYn" runat="server" height="28px"/>
                                            </td>
                                            <td style="width: 66px">
                                                &nbsp;</td>
                                            <td style="text-align: right; width: 100px; height:28px">
                                                <asp:Label ID="Label49" runat="server" Text="Case Mode:"></asp:Label>
                                                
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCaseMode" runat="server" Width="240px" Height="28px" TabIndex="6">
                                                    <asp:ListItem Value="" Text ="Please Select"></asp:ListItem>
                                                    <asp:ListItem Value="C" Text ="Close"></asp:ListItem>
                                                </asp:DropDownList>
                                                
                                            </td>
                                        </tr>


                                        <tr>

                                            <td style="height: 22px; text-align: right; width: 254px;">
                                                <asp:Label ID="Label41" runat="server" Text="Remarks :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtRemarks" runat="server" Width="236px" BackColor="White" TextMode="MultiLine" Height="40px"></asp:TextBox>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                &nbsp;
                                            </td>
                                            <td style="width: 100px; text-align: right; height: 22px;">

                                            &nbsp;</td>
                                            <td style="width: 95px; height: 22px;">
                                            
                                               </td>
                                                                                    
                                        </tr>
                                                                               
                                        <tr>
                                            <td style="width: 254px; text-align: right">
                                                &nbsp;
                                            </td>
                                            <td style="width: auto" colspan="4">
                                            <asp:Button ID="BtnSaveCaseHistory" runat="server" Height="31px" Text="Save" Width="51px" B
                                                    OnClick="BtnSaveCaseHistory_Click" CssClass="styled-button-4" />
                                            <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="41px"
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
                                        <table class="style1">

                                            <tr>
                                            <td style="width: 150px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label1" runat="server" Text="Case No :" Height="25px"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 95px; height: 22px; height:25px">
                                                <asp:DropDownList ID="ddlCaseIdSearch" runat="server" Width="240px" Height="25px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 28px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="28px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                            </td>
                                            <td style="height: 22px; text-align: right; width: 100px;">
                                                Email To :
                                            </td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtEmailAddress" runat="server" Width="340px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;  "></asp:TextBox>
                                                <asp:Button ID="btnSendMail" runat="server" Height="30px" Text="Send" Width="55px" 
                                                                CssClass="styled-button-4" OnClick="btnSendMail_Click" />

                                            </td>
                                        </tr>
                                            <tr>
                                                <td style="text-align: right" class="auto-style3" height="25">
                                                    <asp:Label ID="Label5" runat="server" Text="From Date :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width:163px;height:25px;">
                                                <asp:TextBox ID="dtpFromHistoryDate" runat="server" Width="236px" BackColor="White" CssClass="date" Height="25"></asp:TextBox>
                                                </td>

                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 100px">
                                                    CC :
                                                </td>
                                                <td>
                                                <asp:TextBox ID="txtCCAddress" runat="server" Width="340px" Height ="25px" BackColor="White" style="padding-left:5px; padding-right:5px;  "></asp:TextBox>
                                                </td>
                                            </tr>  
                                            
                                            
                                            <tr>
                                                <td style="text-align: right" class="auto-style3" height="25">
                                                    <asp:Label ID="Label45" runat="server" Text="To Date :" Height="25px"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right; width:163px;height:25px;">
                                                <asp:TextBox ID="dtpToHistoryDate" runat="server" Width="236px" BackColor="White" CssClass="date" Height="25px"></asp:TextBox>
                                                </td>

                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right; width: 100px">
                                                  Enquiry Date :
                                                </td>
                                                <td>
                                                <asp:TextBox ID="dtpEnquiryDate" runat="server" Width="348px" BackColor="White" CssClass="date" Height="25"></asp:TextBox>
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
                                <td>
                                    <asp:GridView ID="gvCaseHistory" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="history_id,CASE_ID"
                                        OnRowDataBound="gvCaseHistory_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        GridLines="None" AllowPaging="false" OnRowEditing="gvCaseHistory_OnRowEditing" CssClass="mGrid"
                                        PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvCaseHistory_OnSelectedIndexChanged"
                                        CausesValidation="false" OnRowCommand="gvCaseHistory_RowCommand" AlternatingRowStyle-CssClass="alt"
                                        OnPageIndexChanging="gvCaseHistory_PageIndexChanging" OnRowDeleting="gvCaseHistory_RowDeleting">
                                        <Columns>
                                            
                                            <%--<asp:BoundField DataField="SERIAL" HeaderText="SERIAL" />--%>
                                                                                        
                                            <asp:BoundField DataField="CASE_NO" HeaderText="Case No" ItemStyle-Width="100" />                                           
                                            <asp:BoundField DataField="DEFENDANT_NAME" HeaderText="Defendant" ItemStyle-Width="200" /> 
                                             <asp:BoundField DataField="COMPLAINTANT_NAME" HeaderText="Complaintant" ItemStyle-Width="200" />
                                             <asp:BoundField DataField="HISTORY_DATE" HeaderText="H.Date" ItemStyle-Width="100" />
                                            <asp:BoundField DataField="case_status" HeaderText="Case Status" ItemStyle-Width="200" /> 
                                              <asp:BoundField DataField="activity_name" HeaderText="Activity" ItemStyle-Width="200" />
                                              <asp:BoundField DataField="case_mode" HeaderText="Mode" ItemStyle-Width="200" />
                                              <asp:BoundField DataField="appeared_yn" HeaderText="Appeared" ItemStyle-Width="200" />                       
                                            <asp:BoundField DataField="Remarks" HeaderText="Remarks" ItemStyle-Width="200" />
                                            <asp:BoundField DataField="CASE_ID" HeaderText="CASE Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                                            <asp:BoundField DataField="case_status_id" HeaderText="Case Status Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />                                           
                                            <asp:BoundField DataField="history_id" HeaderText="History Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" /> 
                                            <asp:BoundField DataField="activity_type_id" HeaderText="Activity Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" /> 

                                            <%--<asp:BoundField DataField="defendant_id" HeaderText="D.Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                                            <asp:BoundField DataField="complaintant_id" HeaderText="c.Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />              --%>
                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="1%">
                                               <ItemTemplate>
                                                   <asp:ImageButton ID="btnSub" runat="server" Text="Delete" ImageUrl="~/images/del.png"
                                                       AlternateText="Delete"
                                                       Width="30px" CommandName="Delete" OnClientClick="return isDelete();"
                                                       Height="25px" Visible="true" />
                                            </ItemTemplate>
                                            </asp:TemplateField>   
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
               <%-- <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
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
