<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="GazetteInfo.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.GazetteInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>


   <%-- <script language="javascript">
       // $(window).load(function () { document.getElementById("<%= dtpEffectiveDate.ClientID %>").focus(); }) 
    </script>--%>
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
        <legend>Gazette Info</legend>

     <table style="width: 100%">
           
          <tr style="height:30px; ">
                <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblId" runat="server" Text="Schedule:"></asp:Label>
                </td>
                <td class="modal-sm" style="width: 278px">
                    <asp:DropDownList ID="ddlSchedule" runat="server" Width="160px" Height="22px">
                        <asp:ListItem Enabled="true" Text="Select Schedule" Value=" "></asp:ListItem>
                        <asp:ListItem Text="A" Value="1"></asp:ListItem>
                        <asp:ListItem Text="B" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                    
                </td>
                 <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblId0" runat="server" Text="Grade :"></asp:Label>
                </td>
                <td class="modal-sm" style="width: 278px">
                    <asp:DropDownList ID="ddlGrade" runat="server" Width="160px" Height="22px" >
                    </asp:DropDownList>
                </td>
                
               
            </tr>
          
            <tr style="height:30px; ">
                 <td class="text-right" style="text-align: right">
                    &nbsp;&nbsp;
                    <asp:Label ID="lblId8" runat="server" Text="Publish Year :"></asp:Label>
                  </td>
                    <td>
                    <asp:TextBox ID="txtPublishYear" runat="server" Width="160px" Height="22px" Font-Bold="False"></asp:TextBox>
                   </td>
                 <td style="text-align: right; width: 338px">
                    <asp:Label ID="lblId1" runat="server" Text="Gross Salary:"></asp:Label>
                </td>
                <td class="modal-sm" style="width: 278px">
                    <asp:TextBox ID="txtGrossSalary" runat="server" Width="160px" Height="20px" Font-Bold="False"></asp:TextBox>            
                </td>
                               
            </tr>
            
            
            <tr style="height:30px; ">
               
                 <td class="text-right" style="text-align: right">
                    <asp:Label ID="lblId2" runat="server" Text="Medical Fee :"></asp:Label>
                    </td>
                 <td>
                   <asp:TextBox ID="txtMedicalFee" runat="server" Width="160px" Height="22px" Font-Bold="True" ></asp:TextBox>
                </td>   
                 <td style="text-align: right; width: 338px">
                    <asp:Label ID="Label1" runat="server" Text="ConVeyance Fee:"></asp:Label>
                </td>
                <td class="modal-sm" style="width: 278px">
                    <asp:TextBox ID="txtConveyanceFee" runat="server" Width="160px" Height="20px" Font-Bold="False"></asp:TextBox>            
                </td> 
            </tr>

           <tr style="height:30px; ">
              
                <td class="text-right" style="text-align: right">
                     <asp:Label ID="lblId6" runat="server" Text="Food Fee :"></asp:Label>
               </td>
                 <td>
                    <asp:TextBox ID="txtFoodFee" runat="server" Width="160px" Height="20px" Font-Bold="True"></asp:TextBox>
                 </td>
                   <td class="text-right" style="text-align: right">
                    <asp:Label ID="lblId7" runat="server" Text="Extra Food Fee :"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtExtraFoodFee" runat="server" Width="158px" Height="20px" Font-Bold="True"></asp:TextBox>
                </td>
              
            </tr>
               <tr style="height:30px; ">
               
                 <td style="text-align: right; width: 338px; height: 19px">
                    <asp:Label ID="lblId4" runat="server" Text="Active :"></asp:Label>
                </td>
                <td style="height: 19px; width: 278px;">
                    <asp:CheckBox ID="chkActive" runat="server" Text="Yes" />
                </td>
              
                 <td>
                    <asp:TextBox ID="txtGazatteId" runat="server" Width="158px" Height="20px" Font-Bold="True" Visible="false" ></asp:TextBox>
                </td>
            </tr>

         
            <tr>
                
               
                <td class="modal-sm" style="width: 278px">
                    &nbsp;
                    
                </td>
                 <td class="modal-sm" style="width: 278px">&nbsp;
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px"
                        CssClass="styled-button-4" OnClick="btnClear_Click" />
                </td>
            </tr>
        
            <tr>
                <td style="text-align: right;" colspan="5">
                    <asp:GridView ID="gvGazette" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvGazette_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="PUBLISH_YEAR" HeaderText="YEAR" />
                            <asp:BoundField DataField="SCHEDULE_ID" HeaderText="ID"  HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>  
                            <asp:BoundField DataField="SCHEDULE_NAME" HeaderText="SCHEDULE NAME" />                             
                            <asp:BoundField DataField="GRADE_ID" HeaderText="ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="GRADE_NO" HeaderText="GRADE" />
                            <asp:BoundField DataField="GROSS_SALARY" HeaderText="GROSS SALARY" />
                            <asp:BoundField DataField="MEDICAL_FEE" HeaderText="MEDICAL FEE" />
                             <asp:BoundField DataField="CONVENCE_FEE" HeaderText="CONVINCE FEE" />
                            <asp:BoundField DataField="FOOD_FEE" HeaderText="FOOD FEE" />
                            <asp:BoundField DataField="EXTRA_FOOD_FEE" HeaderText="EXTRA FOOD FEE" />
                            <asp:BoundField DataField="ACTIVE_YN" HeaderText="STATUS" />
                             <asp:BoundField DataField="GAZETTE_ID" HeaderText="ID" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn" />

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
