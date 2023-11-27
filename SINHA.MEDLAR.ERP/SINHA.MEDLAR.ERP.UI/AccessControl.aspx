
<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    CodeBehind="AccessControl.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AccessControl" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<%--<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to Delete this row?");
        }
    </script>

    <script type="text/javascript">
        function isApprove() {
            return confirm("Do you want to Approve?");
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
                <%--document.getElementById('<%= BtnSaveCaseInfo.ClientID %>').click();--%>
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
            <td class="style3">
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
        <legend>Employee Recognize</legend>
        <table class="style1">
            <tr>
                <td colspan="4" style="text-align: left; width: 100px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: right">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" 
                        OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" 
                        OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>
            </tr>
                
            <tr>
                                            <td style="width: 254px; text-align: right; height: 25px;">
                                                <asp:Label ID="Label1" runat="server" Text="Unit :"></asp:Label>
                                                &nbsp;
                                            </td>
                                            <td style="width: 95px; height: 22px;">
                                                <asp:DropDownList ID="ddlUnitId" runat="server" Width="264px" Height="28" >
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px" 
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                            </td>
                                            <td style="height: 22px; text-align: right; width: 100px;">
                                                <asp:Label ID="Label2" runat="server" Text="Create From :"></asp:Label>
                                            &nbsp;</td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtFromDate" runat="server" Width="250" BackColor="White" CssClass="date" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                                            </td>
                                        </tr>

            <tr>
              <td style="width: 254px; text-align: right">
                  <asp:Label ID="Label3" runat="server" Text="Section :"></asp:Label>
                  &nbsp;
              </td>
              <td style="width: 95px">
                  <asp:DropDownList ID="ddlSectionId" runat="server" Width="264px" Height="28" >
                  </asp:DropDownList>
              </td>
              <td style="width: 66px">
                  &nbsp;</td>
              <td style="text-align: right; width: 100px">
                 <asp:Label ID="Label4" runat="server" Text="Create To :"></asp:Label>
              </td>
              <td>
                  <asp:TextBox ID="txtToDate" runat="server" Width="250" BackColor="White" CssClass="date"  style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
              </td>
              </tr>
               <tr>
                   <td style="text-align: right" class="auto-style3">
                       <asp:Label ID="Label5" runat="server" Text="Employee Id :"></asp:Label>
                       &nbsp;
                   </td>
                   <td style="text-align: right; width:163px">
                   <asp:TextBox ID="txtEmployeeId" runat="server" Width="250" BackColor="White" TabIndex="16" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                   </td>

                   <td style="width: 66px">&nbsp;
                       </td>
              <td style="text-align: right; width: 100px">
                  <asp:Label ID="Label43" runat="server" Text="Recognized? :"></asp:Label>
                  &nbsp;
              </td>
              <td>
              <asp:DropDownList ID="ddlRecognized" runat="server" Width="264px" Height="28">
                  <asp:ListItem Value="" Text="Please Select" Selected="True">
                  </asp:ListItem>
                  <asp:ListItem Value="Y" Text="Recognized" >
                  </asp:ListItem>
                  <asp:ListItem Value="N" Text="Not Recognized">
                  </asp:ListItem>
              </asp:DropDownList>          
              </td>
            </tr>


              <tr>
                   <td style="text-align: right" class="auto-style3">
                       <asp:Label ID="Label7" runat="server" Text="Card No :"></asp:Label>
                       &nbsp;
                   </td>
                   <td style="text-align: right; width:163px">
                   <asp:TextBox ID="txtCardNo" runat="server" Width="250" BackColor="White" style="padding-left:5px; padding-right:5px; height:25px;"></asp:TextBox>
                   </td>

                   <td style="width: 66px">&nbsp;
                       </td>
              <td style="text-align: right; width: 100px">
                  
                 <asp:Label ID="Label44" runat="server" Text="Floor :"></asp:Label>
              </td>
              <td>          
                   <asp:DropDownList ID="ddlFloor" runat="server" Width="264px" Height="28px">
                    </asp:DropDownList>
              </td>
            </tr>
            

              <tr>
                <td style="text-align: right" class="auto-style3">
                    <asp:Label ID="lblFilePath" runat="server" Text="Upload XL :"></asp:Label>
                    &nbsp;
                </td>
                <td style="text-align: right; width:163px">
                    <asp:FileUpload ID="FileUpload1" runat="server" style="width:260px;" />
                </td>

                <td style="width: 66px">&nbsp;
                </td>
                <td style="text-align: right; width: 100px">      

                </td>
                    <td>          
                    </td>
              </tr>
            
               <tr>
                <td style="text-align: right" class="auto-style3">
                    
                </td>
                <td style="text-align: right; width:163px">
                    
                </td>

                <td style="width: 66px">&nbsp;
                </td>
                <td style="text-align: right; width: 100px">      

                </td>
                    <td>          
                    </td>
              </tr>                        
             
              <tr>
                   <td style="text-align: right" class="auto-style3">
                       &nbsp;</td>
                   <td style="text-align: left; width:Auto;" colspan="4">
                        <asp:Button ID="btnSave" runat="server" Height="25px" Text="Save" Width="55px" 
                   CssClass="styled-button-4" OnClick="btnSave_Click" />
                  <asp:Button ID="btnSheet" runat="server" Height="25px" Text="Sheet" Width="55px" 
                   CssClass="styled-button-4" OnClick="btnSheet_Click" />

                  <asp:Button ID="btnTextFie" runat="server" Height="25px" Text="TxT File" Width="55px" 
                   CssClass="styled-button-4" OnClick="btnTextFie_Click" />

                  <asp:Button ID="BtnUselessFaceID" runat="server" Height="25px" Text="Useless FaceID" Width="100px" 
                   CssClass="styled-button-4" OnClick="BtnUselessFaceID_Click" />

                   </td>

                   <%--<td style="width: 66px">&nbsp;</td>
              <td style="text-align: right; width: 100px">
                  
                  &nbsp;</td>
              <td>
                        
                        &nbsp;</td>--%>
            </tr>
            <tr>
             <td style="text-align: left; height: 18px;">
                 <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                     Font-Names="Tahoma"></asp:Label>
             </td>
            </tr>

            <tr>
             <td colspan="5">
                <asp:GridView ID="GvEmployeeCache" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="cache_id" 
                OnRowDataBound="GvEmployeeCache_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                GridLines="None" AllowPaging="false" OnRowEditing="GvEmployeeCache_OnRowEditing" CssClass="mGrid"
                PagerStyle-CssClass="pgr" OnSelectedIndexChanged="GvEmployeeCache_OnSelectedIndexChanged"
                CausesValidation="false" OnRowCommand="GvEmployeeCache_RowCommand" AlternatingRowStyle-CssClass="alt"
                OnPageIndexChanging="GvEmployeeCache_PageIndexChanging" OnRowDeleting="GvEmployeeCache_RowDeleting">
                <Columns>
                 <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                                </ItemTemplate>
                </asp:TemplateField>    
                <asp:BoundField DataField="cache_id" HeaderText="cache_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                <asp:BoundField DataField="serial_no" HeaderText="Serial No" />                    
                <asp:BoundField DataField="employee_name" HeaderText="Name" ItemStyle-Width="100" />                          
                <asp:BoundField DataField="card_no" HeaderText="Card No" ItemStyle-Width="100" />
                <asp:BoundField DataField="employee_id" HeaderText="ID" ItemStyle-Width="100" />                                             

                <asp:BoundField DataField="designation_name" HeaderText="Designation" ItemStyle-Width="100" />
                <asp:BoundField DataField="joining_date" HeaderText="Joining Date" ItemStyle-Width="100" />
                <asp:BoundField DataField="create_date" HeaderText="Entry Date" ItemStyle-Width="100" />                                       
                <asp:BoundField DataField="unit_name" HeaderText="Unit" ItemStyle-Width="150" />
                <asp:BoundField DataField="section_name" HeaderText="Section" ItemStyle-Width="150" />
                <asp:BoundField DataField="approve_yn" HeaderText="Approve?" ItemStyle-Width="100" />
                <asp:BoundField DataField="recognize_yn" HeaderText="Recognize?" ItemStyle-Width="100" />
                <asp:TemplateField HeaderText="Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                               <ItemTemplate>
                                    <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("Employee_Id")%>' ReadOnly="true"></asp:TextBox>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <%--<cr:crystalreportviewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />--%>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
                    AutoDataBind="true" />
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
