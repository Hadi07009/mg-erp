<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rostering.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Rostering" %>
--%>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ERP.Master" CodeBehind="Rostering.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Rostering" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                document.getElementById('<%= btnRoster.ClientID %>').click();
            }
        }
    </script>



    <script type="text/javascript">
        function isDelete() {
            return confirm("Do you want to delete this row ?");
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
        <legend>Employee Shift Mapping</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; height: 26px;" align="right" colspan="3">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: left; height: 26px;" align="right" colspan="3">


                    <table class="style1">
                        
                        <tr>
                            <td style="text-align: right; width: 200px;">
                                <asp:Label ID="lblEffectDate" runat="server" Text="Effect Date:" Font-Bold="False"></asp:Label>
                            </td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                                <asp:TextBox ID="dtpEffectDate" runat="server" BackColor="White" Width="210" CssClass="date"></asp:TextBox>
                            </td>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 200px;">
                            </td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                            </td>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right; width: 200px;">&nbsp;
                            </td>
                            <td style="text-align: left; width: 250px;" class="auto-style6">
                                <asp:Button ID="btnRoster" runat="server" Height="31px" Text="Roster" Width="66px"
                                    CssClass="styled-button-4" OnClick="btnRoster_Click" />
                                <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" Width="66px" CssClass="styled-button-4"
                                    OnClientClick="target = '_SELF';" OnClick="btnClear_Click" />
                            </td>
                            <td style="text-align: left;">&nbsp;</td>
                            <td style="text-align: right;" class="auto-style5">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 54px;">&nbsp;</td>
                <td style="text-align: right;">&nbsp;</td>
                <td style="text-align: justify">&nbsp;</td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

   <div>
     <fieldset>
     <legend style="font:300; color:blue;">SHIFT- A</legend>
      <div style="height:270px; overflow-y:scroll;">
       
        
        <div style="float:left">
            <asp:Label ID="lblShift1PreRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift1PreOfficeTime" runat="server" Visible="true"></asp:Label>
            
            <asp:GridView ID="GvShift1Pre" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
        <div style="float:right">
            <asp:Label ID="lblShift1PostRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift1PostOfficeTime" runat="server" Visible="true"></asp:Label>
            
            <asp:GridView ID="GvShift1Post" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
      
      </div>
     </fieldset>
    <fieldset>
     <legend style="font:300; color:blue;">SHIFT- B</legend>
      <div style="height:270px; overflow-y:scroll;">
        <div style="clear:left; float:left;">
            <asp:Label ID="lblShift2PreRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift2PreOfficeTime" runat="server" Visible="true"></asp:Label>
            
            <asp:GridView ID="GvShift2Pre" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
        <div style="float:right;">
            <asp:Label ID="lblShift2PostRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift2PostOfficeTime" runat="server" Visible="true"></asp:Label>
            
            <asp:GridView ID="GvShift2Post" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
      </div>
    </fieldset>
    <fieldset>
    <legend style="font:300; color:blue;">SHIFT- C</legend>
      <div style="height:270px;overflow-y:scroll;">
        <div style="clear:left; float:left">
            <asp:Label ID="lblShift3PrerRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift3PreOfficeTime" runat="server" Visible="true"></asp:Label>
            
            <asp:GridView ID="GvShift3Pre" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
        <div style="float:right">
            <asp:Label ID="lblShift3PostRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift3PostOfficeTime" runat="server" Visible="true"></asp:Label>
            
            <asp:GridView ID="GvShift3Post" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
      </div>
    </fieldset>
    <fieldset>
    <legend style="font:300; color:blue;">SHIFT- D</legend>
      <div style="height:270px;overflow-y:scroll;">
        <div style="clear:left; float:left;">
            <asp:Label ID="lblShift4PreRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift4PreOfficeTime" runat="server" Visible="true"></asp:Label>
            
            <asp:GridView ID="GvShift4Pre" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
        <div style="float:right;">
            <asp:Label ID="lblShift4PostRosterDate" runat="server" Visible="true"></asp:Label>
            &nbsp;&nbsp;
            <asp:Label ID="lblShift4PostOfficeTime" runat="server" Visible="true"></asp:Label>
            <asp:GridView ID="GvShift4Post" runat="server" DataSourceID=""
                     AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                     AllowSorting="True" EnableViewState="true"
                     GridLines="None" AllowPaging="false" 
                     CssClass="mGrid" PagerStyle-CssClass="pgr" 
                     CausesValidation="false" AlternatingRowStyle-CssClass="alt"
                     Width="450px">
                     <Columns>
                              <asp:BoundField DataField="MappingId" HeaderText="Serial" />
                              <asp:BoundField DataField="CardNo" HeaderText="CardNo" />
                              <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                              <asp:BoundField DataField="DesignationName" HeaderText="DesignationName" />
                              <asp:BoundField DataField="EmployeeId" HeaderText="EMPLOYEE ID" />
                              <asp:BoundField DataField="EffectDate" HeaderText="Effect Date" />
                      </Columns>
                </asp:GridView>
        </div>
      </div>
    </fieldset>
   </div>

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


