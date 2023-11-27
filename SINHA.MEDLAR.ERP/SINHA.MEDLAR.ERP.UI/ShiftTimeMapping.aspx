<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ShiftTimeMapping.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ShiftTimeMapping" %>

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
   <%-- <script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= dtpEffectiveDate.ClientID %>").focus(); }) 
    </script>--%>
    <script type="text/javascript" language="javascript">

        function isCreate() {
            var reply = confirm("Ary you sure you want to Save?");
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
            <td style="width: 250px; height: 15px">
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
        <legend>SHIFT TIME MAPPING SETUP</legend>
        <table style="width: 100%">
            <tr>
                <td style="text-align: left;" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
               <tr>
                <td style="text-align: right; width: 250px">
                    Team:</td>
                <td>
                    <asp:DropDownList ID="ddlShift" runat="server" AutoPostBack="true" Width="200px" Height="29px" 
                        OnSelectedIndexChanged="ddlShift_SelectedIndexChanged">
                    </asp:DropDownList>
                    <%--<asp:Button ID="Button1" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSearch_Click"
                        CssClass="styled-button-4"/>--%>
                    <asp:TextBox ID="txtMappingId" runat="server" Width="29px" Height="20px" Font-Bold="True" Visible="false" style="margin-top: 0px"></asp:TextBox>
                </td>
                <td>&nbsp;
                </td>
            </tr>
             

               <tr>
                <td style="text-align: right; width: 250px">
                    Time:</td>
                <td>
                    <asp:DropDownList ID="ddlTimeId" runat="server" Width="200px" Height="28px">
                    </asp:DropDownList>
                </td>
                <td>&nbsp;
                </td>
            </tr>
               <tr>
                <td style="text-align: right; width: 250px">
                    <asp:Label ID="lbleffectdate" runat="server" Text="Effect Date :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="dtpEffectDate" runat="server" Width="198px" Height="25px" CssClass="date">
                    </asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="text-align: right; width: 250px">&nbsp;</td>
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
           
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table style="width: 55%"> 
    <tr>
       <td style="text-align: right;" colspan="3">
          <asp:GridView ID="gvShiftMapping" runat="server" DataSourceID="" AutoGenerateColumns="False"
               GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
               AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvShiftMapping_PageIndexChanging"
               OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged"
               EnableViewState="true">
               <Columns>   
                   <asp:BoundField DataField="SL" HeaderText="SL No" ItemStyle-Width="40"/> 
                  <asp:BoundField DataField="SHIFT_NAME" HeaderText="SHIFT" ItemStyle-Width="110" />
                   <asp:BoundField DataField="EFFECT_DATE" HeaderText="DATE" ItemStyle-Width="70" />
                  <asp:BoundField DataField="TIME_NAME" HeaderText="TIME" />
                  

                   <asp:BoundField DataField="SHIFT_ID" HeaderText="SHIFT_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />  
                   <asp:BoundField DataField="TIME_ID" HeaderText="TIME_ID" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />                  
                   <asp:BoundField DataField="mapping_id" HeaderText="Mapping" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn" />
                 
                   <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="30px" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:ImageButton ID="btnselect" Width="28" Height="20" runat="server" CommandName="Select"
                               Style="cursor: pointer" ImageAlign="Middle" Text="..." CausesValidation="false" ImageUrl="~/images/check.jpg"  AlternateText="Select" />
                       </ItemTemplate>
                   </asp:TemplateField>

                   <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate>
                           <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                               Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                       </ItemTemplate>
                   </asp:TemplateField> --%>
               </Columns>

           </asp:GridView>
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
