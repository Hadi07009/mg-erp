<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="JobCard.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.JobCard" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                            <td style="width: 163px; height: 22px;">
                                                <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                </asp:DropDownList>
                                            </td>
                                            <td style="height: 22px; width: 66px;">
                                                &nbsp;
                                                <asp:Button ID="btnSearch" runat="server" Height="24px" Text="Search" Width="58px"
                                                    OnClick="btnSearch_Click" CssClass="styled-button-4" />
                                            </td>
                                            <td style="height: 22px; text-align: right; width: 81px;">
                                                <asp:Label ID="Label39" runat="server" Text="ID :"></asp:Label>
                                            </td>
                                            <td style="height: 22px">
                                                <asp:TextBox ID="txtEmpId" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 254px; text-align: right">
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
                                            <td style="text-align: right; width: 81px">
                                                <asp:Label ID="Label40" runat="server" Text="Card No :"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtEmpCardNo" runat="server" Width="149px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                          <tr>
                            <td style="text-align: right; " class="auto-style2">
                                <asp:Label ID="lblFromdate" runat="server" Text="From :"></asp:Label>
                            </td>
                            <td style="width: 167px; height: 22px;">
                                <asp:TextBox ID="dtpFromCreateDate" runat="server" Width="238px" placeHolder="From Date"
                                    CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                            </td>
                            <td style="height: 22px">
                                &nbsp;</td>
                            <td style="height: 22px; text-align: right; width: 98px;">
                                <asp:Label ID="lblToDat" runat="server" Text="To : " Width="20px"></asp:Label>
                            </td>
                            <td style="height: 22px">
                                <asp:TextBox ID="dtpToCreateDate" runat="server" Width="149px" placeHolder="To Date"
                                    CssClass="date" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                             <td style="width: 254px; text-align: right">
                                 &nbsp;</td>
                             <td style="width: 163px">
                                 &nbsp;</td>
                             <td style="width: 66px">
                                 &nbsp;</td>
                             <td style="text-align: right; width: 81px">
                                 &nbsp;</td>
                             <td>
                               &nbsp;</td>
                         </tr>
                          <tr>
                              <td style="width: 254px; text-align: right">
                                  &nbsp;</td>
                              <td style="width: 163px">
                                  <asp:Button ID="btnProcess" runat="server" Height="26px" Text="Sheet" Width="59px"
                                      CssClass="styled-button-4" Visible="false" OnClick="btnActiveEmployee_Click" />
                              </td>
                              <td style="width: 66px">
                                  &nbsp;</td>
                              <td style="text-align: right; width: 81px">
                                  &nbsp;</td>
                              <td>
                                  &nbsp;</td>
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
               </td>
           </tr>
           
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
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
                          <%-- <asp:TemplateField>
                               <ItemTemplate>
                                   <asp:CheckBox ID="chkEmployee" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                               </ItemTemplate>
                           </asp:TemplateField>--%>
                           <asp:BoundField DataField="SL" HeaderText="SL" />
                            <asp:BoundField DataField="card_no" HeaderText="Card No" ItemStyle-Width="80" />
                           <asp:BoundField DataField="employee_name" HeaderText="Name" ItemStyle-Width="300" />
                           <asp:BoundField DataField="designation_name" HeaderText="Designation" ItemStyle-Width="350" />
                           <asp:TemplateField HeaderText="ID" ItemStyle-Width="30" >
                               <ItemTemplate>
                                   <asp:TextBox ID="txtEmployeeId" runat="server" Text='<%#Eval("EMPLOYEE_ID")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                           </asp:TemplateField>

                           <asp:TemplateField HeaderText="Head Office Id" ItemStyle-Width="30" Visible="false" >
                               <ItemTemplate>
                                   <asp:TextBox ID="txtheadOfficeId" runat="server" Text='<%#Eval("HEAD_OFFICE_ID")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                           </asp:TemplateField>

                            <asp:TemplateField HeaderText="Branch Office Id" ItemStyle-Width="30" Visible="false" >
                               <ItemTemplate>
                                   <asp:TextBox ID="txtBranchOfficeId" runat="server" Text='<%#Eval("BRANCH_OFFICE_ID")%>' ReadOnly="true"></asp:TextBox>
                               </ItemTemplate>
                           </asp:TemplateField>
                          <asp:TemplateField HeaderText="Sheet" ItemStyle-Width="1%">
                            <ItemTemplate>
                              <asp:ImageButton ID="btnSheet" runat="server" Text="Approve" ImageUrl="~/images/sheet.png"
                               AlternateText="Sheet" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                              Width="30px" CommandName="Sheet"
                              Height="25px" Visible="true" />
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
