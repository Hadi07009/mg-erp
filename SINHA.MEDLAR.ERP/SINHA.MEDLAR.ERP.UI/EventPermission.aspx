<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="EventPermission.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.EventPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        function isDelete() {
            return confirm("Do you want to delete this row ?");
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
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 601px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
            </tr>
            </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
            <table class="style1">
                <tr>
                    <td style="height:30px; width: 80px; text-align: right">
                        <asp:Label ID="Label34" runat="server" Text="User Name :"></asp:Label>
                    </td>
                    <td style="width: 240px; text-align: left;height:30px;width:50px">
                        <asp:DropDownList ID="ddlEmployeeId" runat="server" Width="230px" Height="30px" AutoPostBack="true"
                            BackColor="White">
                        </asp:DropDownList>
                    </td>
                   <td style="height:30px; width: 170px; text-align: right">
                        <asp:Label ID="Label36" runat="server" Text="Form :"></asp:Label>
                    </td>
                    <td style="Height:30px; width: 285px; text-align: left;margin-left:20px;">
                        <asp:DropDownList ID="ddlUserInterfaceId" runat="server" Width="169px" Height="30px" BackColor="White" AutoPostBack="true" OnSelectedIndexChanged="ddlUserInterfaceId_SelectedIndexChanged">
                        </asp:DropDownList>

                        <asp:Button ID="btnAdd" runat="server" Height="30px" Text="Add" Width="45px" CssClass="styled-button-4" OnClick="btnAdd_Click" />
                        <asp:Button ID="btnShow" runat="server" Height="30px" Text="Show" Width="50px" 
                            CssClass="styled-button-4" OnClick="btnShow_Click" />

                    </td>               
                </tr>                         
            </table>
        </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
     <fieldset>
        <table style="width: 100%">

              <tr>
                    <td style="width: 80px; text-align: right">
                        <asp:Label ID="lblSaveDisable" runat="server" Text="Dis.Save Evnt:"></asp:Label>
                    </td>
                   <td style="width: 240px; text-align: left;height:30px;">
                        <asp:DropDownList ID="ddlDisableSave" runat="server" Width="150px" Height="30px" AutoPostBack="true"
                            BackColor="White">
                        </asp:DropDownList> 
                    </td>
            
                    <td style="width: 80px; text-align: right">
                        <asp:Label ID="lblAddDisable" runat="server" Text="Dis Add Evnt:"></asp:Label>
                    </td>
                   <td style="width: 240px; text-align: left;height:30px;">
                        <asp:DropDownList ID="ddlDisableAdd" runat="server" Width="150px" Height="30px" AutoPostBack="true"
                            BackColor="White">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 80px; text-align: right">
                        <asp:Label ID="lblSearchDisable" runat="server" Text="Dis Search Evnt:"></asp:Label>
                    </td>
                   <td style="width: 240px; text-align: left;height:30px;">
                        <asp:DropDownList ID="ddlDisableSearchEvent" runat="server" Width="150px" Height="30px" AutoPostBack="true"
                            BackColor="White">
                        </asp:DropDownList>
                    </td>
                </tr>
              <tr>
                  <td style="width: 80px; text-align: right">
                        <asp:Label ID="lblDisableProcess" runat="server" Text="Dis Process Evnt:"></asp:Label>
                    </td>
                  <td style="width: 240px; text-align: left;height:30px;">
                        <asp:DropDownList ID="ddlDisableProcessEvent" runat="server" Width="150px" Height="30px" AutoPostBack="true"
                            BackColor="White">
                        </asp:DropDownList>
                    </td>
                  <td style="width: 80px; text-align: right">
                        <asp:Label ID="LblDisableDelete" runat="server" Text="Dis Delete Evnt:"></asp:Label>
                    </td>
                  <td style="width: 240px; text-align: left;height:30px;">
                        <asp:DropDownList ID="ddlDisableDeleteEvent" runat="server" Width="150px" Height="30px" AutoPostBack="true"
                            BackColor="White">
                        </asp:DropDownList>
                    </td>
                  <td style="width: 80px; text-align: right">
                        <asp:Label ID="LblDisableAtten" runat="server" Text="Dis Atten Evnt:"></asp:Label>
                    </td>
                  <td style="width: 240px; text-align: left;height:30px;">
                        <asp:DropDownList ID="ddlDisableAttenEvent" runat="server" Width="150px" Height="30px" AutoPostBack="true"
                            BackColor="White">
                        </asp:DropDownList>
                    </td>
            </table>
        </fieldset>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder5" runat="server">
     <fieldset>
        <legend>MEMU  ENTRY RESULT</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvEventPermissionList" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        OnRowDataBound="gvEventPermissionList_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        DataKeyNames="UI_ID"
                        OnSelectedIndexChanged="gvEventPermissionList_OnSelectedIndexChanged" CausesValidation="false"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvEventPermissionList_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="user_name" HeaderText="User Name" />
                            <asp:BoundField DataField="DISPLAY_NAME" HeaderText="Display Name" />

                            <asp:BoundField DataField="save_event_name" HeaderText="Save Event" />
                            <asp:BoundField DataField="add_event_name" HeaderText="Add Event" />
                            <asp:BoundField DataField="process_event_name" HeaderText="Process Event" />
                            <asp:BoundField DataField="search_event_name" HeaderText="Search Event" />
                            <asp:BoundField DataField="atten_event_name" HeaderText="Atten Event" />
                            <asp:BoundField DataField="delete_event_name" HeaderText="Delete Event" />
                            <asp:BoundField DataField="ui_id" HeaderText="UI Id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                            <asp:BoundField DataField="employee_id" HeaderText="employee" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>

                             <asp:BoundField DataField="disable_save_event_id" HeaderText="disable_save_event_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="disable_add_event_id" HeaderText="disable_add_event_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="disable_process_event_id" HeaderText="disable_process_event_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="disable_search_event_id" HeaderText="disable_search_event_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="disable_atten_event_id" HeaderText="disable_atten_event_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>
                             <asp:BoundField DataField="disable_delete_event_id" HeaderText="disable_delete_event_id" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn"/>

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
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolder6" runat="server">    
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ContentPlaceHolder7" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ContentPlaceHolder8" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ContentPlaceHolder9" runat="server">
</asp:Content>
