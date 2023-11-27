<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="AddOfficeTime.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.AddOfficeTime" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
        $(window).load(function () { document.getElementById("<%= dtpEffectiveDate.ClientID %>").focus(); }) 
    </script>
    <script type="text/javascript" language="javascript">

        function isCreate() {
            var reply = confirm("Ary you sure you want to Create?");
            if (reply) {
                return true;
            }
            else {
                return false;
            }
        }

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
        <legend>ADD OFFICE TIME</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblId" runat="server" Text="Unit :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="160px" Height="22px">
                    </asp:DropDownList>
                    <asp:Button ID="btnSearch" runat="server" Height="21px" Text="..." Width="34px" OnClick="btnSearch_Click"
                        CssClass="styled-button-4" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblId0" runat="server" Text="Section :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="160px" Height="22px">
                    </asp:DropDownList>
                    <asp:TextBox ID="txtTimeId" runat="server" Width="29px" Height="20px" Font-Bold="True" Visible="false"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px; height: 19px">
                    <asp:Label ID="lblId1" runat="server" Text="Effect Date :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="dtpEffectiveDate" runat="server" Width="158px" Height="20px" Font-Bold="False"
                        CssClass="date"></asp:TextBox>
                </td>
                <td style="height: 19px"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px; height: 19px">
                    <asp:Label ID="lblId2" runat="server" Text="Log In/Out :"></asp:Label>
                </td>
                <td style="height: 19px">
                    <asp:TextBox ID="txtLogInTime" runat="server" Width="78px" Height="20px" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtLogOutTime" runat="server" Width="75px" Height="20px" Font-Bold="True"></asp:TextBox>
                    &nbsp;
                </td>
                <td style="height: 19px">&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblId3" runat="server" Text="Lunch Out/In :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtLunchOutTime" runat="server" Width="78px" Height="20px" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtLunchInTime" runat="server" Width="75px" Height="20px" Font-Bold="True"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
               <tr>
                <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblPunchStartEnd" runat="server" Text="Punch Start/End :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtPunchStartTime" runat="server" Width="78px" Height="20px" Font-Bold="True"></asp:TextBox>
                    <asp:TextBox ID="txtPunchEndTime" runat="server" Width="75px" Height="20px" Font-Bold="True"
                        onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
       <%--     <tr>
                <td style="text-align: right; width: 338px">&nbsp;
                    <asp:Label ID="lblId4" runat="server" Text="All Unit :"></asp:Label>
                </td>
                <td>
                    <asp:CheckBox ID="chkAllUnit" runat="server" Text="Yes" />
                    &nbsp;
                </td>
                <td>&nbsp;
                </td>
            </tr>--%>
            <tr>
                <td style="text-align: right; width: 338px">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 338px">&nbsp;
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" OnClientClick="return isCreate(); " />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Reset" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                </td>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
                        EnableViewState="true">
                        <Columns>
                           <asp:TemplateField>
                              <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="checkAll(this);" AutoPostBack="false" />
                              </HeaderTemplate>
                              <ItemTemplate>
                                    <asp:CheckBox ID="chkId" runat="server" onclick="Check_Click(this)" AutoPostBack="false" />
                              </ItemTemplate>
                            </asp:TemplateField> 
                            <asp:BoundField DataField="UNIT_NAME" HeaderText="UNIT" ItemStyle-Width="175"/>
                            <asp:BoundField DataField="SECTION_NAME" HeaderText="SECTION" ItemStyle-Width="100" />
                            <asp:BoundField DataField="EFFECTIVE_DATE" HeaderText="DATE" />
                            <asp:BoundField DataField="LOG_IN_TIME" HeaderText="LOGIN TIME" />
                            <asp:BoundField DataField="LOG_OUT_TIME" HeaderText="LOGOUT TIME" />
                            <asp:BoundField DataField="LUNCH_OUT_TIME" HeaderText="LUNCHOUT TIME" />
                            <asp:BoundField DataField="LUNCH_IN_TIME" HeaderText="LUNCHIN TIME" />
                            <asp:BoundField DataField="PUNCH_START_TIME" HeaderText="PUNCH START TIME" />
                            <asp:BoundField DataField="PUNCH_END_TIME" HeaderText="PUNCH END TIME" />

                            <asp:BoundField DataField="UNIT_ID" HeaderText="UNIT_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                            <asp:BoundField DataField="SECTION_ID" HeaderText="SECTION_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                             <asp:TemplateField HeaderText="UNIT ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtUnitId" runat="server" Text='<%#Eval("UNIT_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtUnitId" runat="server" Text='<%#Eval("UNIT_ID")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblUnitId" runat="server" Text='<%#Eval("UNIT_ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="SECTION ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtSectionId" runat="server" Text='<%#Eval("SECTION_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtSectionId" runat="server" Text='<%#Eval("SECTION_ID")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblSectionId" runat="server" Text='<%#Eval("SECTION_ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:BoundField DataField="Time_Id" HeaderText="Time_Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                            <asp:TemplateField HeaderText="TIME ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtTimeId" runat="server" Text='<%#Eval("TIME_ID")%>'></asp:TextBox>
                                </EditItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtTimeId" runat="server" Text='<%#Eval("TIME_ID")%>'></asp:TextBox>
                                </FooterTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeId" runat="server" Text='<%#Eval("TIME_ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>                       
                        </Columns>

                    </asp:GridView>
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
