<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" EnableEventValidation="false"
    CodeBehind="ReportPowerInventory.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ReportPowerInventory" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
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

    
      <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtRequisitionNo.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ReportPowerInventory.aspx/GetRequisitionNo",
                        data: "{ 'RequisitionNo':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter : function (data) {return data;},
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                                 
                            }))                   

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
             
        });        
    </script>


      <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtPoNumber.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ReportPowerInventory.aspx/GetPoNumber",
                        data: "{ 'PoNumber':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter : function (data) {return data;},
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                                 
                            }))                   

                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
             
        });        
    </script>

     <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtPartNo.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ReportPowerInventory.aspx/GetPartNo",
                        data: "{ 'PartNo':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter : function (data) {return data;},
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },                                                  
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });
          
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
        <legend>Report</legend>
        <table style="width: 100%">
            <tr>
                <td colspan="5">
                    <fieldset>
                        <legend>REPORT FORMAT TYPE</legend>
                        <table style="width: 100%">
                            <tr>
                                <td style="text-align: left;">
                                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" />
                                    &nbsp;<asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true"
                                        ViewStateMode="Enabled" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkWord" runat="server" Text="Word" AutoPostBack="true" Font-Bold="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkText" runat="server" Text="Text" AutoPostBack="true" Font-Bold="True"
                                        ViewStateMode="Enabled" CssClass="CheckBox" />
                                    &nbsp;
                                    <asp:CheckBox ID="chkCSV" runat="server" GroupName="Controls" Text="CSV" AutoPostBack="true"
                                        ViewStateMode="Enabled" Font-Bold="True" CssClass="CheckBox" />
                                </td>
                            </tr>
                            <tr>
                </td>
            </tr>
        </table>
    </fieldset>
    <tr>
        <td style="width: 215px">
            <asp:RadioButton ID="rdoPoOrderSheet" runat="server" AutoPostBack="true"
                Text="Po Order" GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
                                    <asp:Label ID="Label53" runat="server" Text="Requisition No :"></asp:Label>
        </td>
        <td style="width: 147px">
                                    <asp:TextBox ID="txtRequisitionNo" runat="server" Width="150px" BackColor="Yellow"
                                        Font-Bold="True" ForeColor="Black" CssClass="textboxAuto"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: left;">
                                      
                                    &nbsp;</td>
        <td>
            <asp:TextBox ID="txtEmployeeId" runat="server" Width="144px" placeholder="EMPLOYEE ID"
                Height="20px" Visible="False"></asp:TextBox>
           
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            <asp:RadioButton ID="rdoPoTrackingSheet" runat="server" AutoPostBack="true"
                Text="Po Tracking" GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
                <asp:Label ID="lblPoNo" runat="server" Text="Po Number :"></asp:Label>
        </td>
        <td style="width: 147px">
                <asp:TextBox ID="txtPoNumber" runat="server" 
                Width="150px" BackColor="Yellow" Font-Bold="True" ForeColor="Black" CssClass="textboxAuto"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: left;">
                                      
                                    &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            <asp:RadioButton ID="rdoPORequisitionSheet" runat="server" AutoPostBack="true"
                Text="Requisition" GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
                                    <asp:Label ID="lblPartNo" runat="server" 
                Text="Part No :"></asp:Label>
        </td>
        <td style="width: 147px">
                <asp:TextBox ID="txtPartNo" runat="server" 
                Width="150px" BackColor="Yellow" Font-Bold="True" ForeColor="Black" CssClass="textboxAuto"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            <asp:RadioButton ID="rdoPoTrackingShipmetnInfoSheet" runat="server" AutoPostBack="true"
                Text="Shipment Delivery Information" GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
            <asp:Label ID="lblOfficeId9" runat="server" Text="From :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="dtpFromDate" runat="server" Width="150px" BackColor="White" CssClass="date"
                placeholder="FROM DATE"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            <asp:RadioButton ID="rdoPoTrackingShipmetnInfoSheetByBillDate" runat="server" AutoPostBack="true"
                Text="Shipment Information By Bill date" GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
            <asp:Label ID="lblOfficeId10" runat="server" Text="To :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:TextBox ID="dtpToDate" runat="server" Width="150px" BackColor="White" CssClass="date"
                placeholder="TO DATE"></asp:TextBox>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            <asp:RadioButton ID="rdoPoTrackingShipmentHoldInfoSheet" runat="server" AutoPostBack="true"
                Text="Shipment Under Process " GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
            <asp:Label ID="lblUnitId0" runat="server" Text="Section :"></asp:Label>
        </td>
        <td style="width: 147px">
            <asp:DropDownList ID="ddlSectionId" runat="server" Width="154px" Height="22px" 
                placeholder="Unit">
            </asp:DropDownList>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            <asp:RadioButton ID="rdoPurchaseParts" runat="server" AutoPostBack="true"
                Text="Purchase Parts" GroupName="Controls" />
        </td>
        <td style="width: 104px; text-align: right;">
                                    <asp:Label ID="lblSupplier" runat="server" Text="Vendor/Supplier :" style="margin-left:0px"></asp:Label>      
                                </td>
        <td style="width: 147px">                            
            <%--<asp:GridView ID="gvPoRequisition3" runat="server" ShowHeader="False" 
                AutoGenerateColumns="false" style="margin-top:-98px;" AllowSorting="True"  EnableViewState="true"
                GridLines="None" AllowPaging="false" CssClass="mGrid"  PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                OnSelectedIndexChanged="gvPoRequisition3_SelectedIndexChanged" onrowdatabound="gvPoRequisition3_RowDataBound" Width="153px" Height="50px">
                <Columns>
                    <asp:BoundField DataField="REQUISITION_NO" HeaderText="REQUITION.NO"/>
                      <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnselect" Width="30" Height="20" runat="server" CommandName="Select"
                                    Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                            </ItemTemplate>
                       </asp:TemplateField>
                </Columns>
            </asp:GridView>--%>                       
           <%-- <asp:GridView ID="gvPoOrder4" runat="server" ShowHeader="False" 
                AutoGenerateColumns="false" style="margin-top:-90px;" AllowSorting="True"  EnableViewState="true"
                GridLines="None" AllowPaging="false" CssClass="mGrid"  PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt" 
                OnSelectedIndexChanged="gvPoOrder4_SelectedIndexChanged" onrowdatabound="gvPoOrder4_RowDataBound" Width="153px" Height="50px">
                <Columns>
                    <asp:BoundField DataField="PO_NUMBER" HeaderText="PO.NO"/>
                      <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Button ID="btnselect" Width="30" Height="20" runat="server" CommandName="Select"
                                    Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                            </ItemTemplate>
                       </asp:TemplateField>
                </Columns>
            </asp:GridView>   --%>                         
                                   
                                    <asp:DropDownList ID="ddlSupplierId" runat="server" Width="154px" Height="22px">
                                    </asp:DropDownList>
                                                                     
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 104px; text-align: right;">
                                    <asp:Label ID="lblSupplier0" runat="server" Text="Machine :" 
                                        style="margin-left:0px"></asp:Label>      
                                </td>
        <td style="width: 147px">                            
                                    <asp:DropDownList ID="ddlMachineId" runat="server" Width="156px" Font-Bold="False"
                                        BackColor="White" CssClass="date" ForeColor="Black">
                                    </asp:DropDownList>
                                                                     
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 104px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px"> 
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 104px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            <asp:Button ID="btnView" runat="server" Height="31px" Text="View" Width="87px" OnClick="btnView_Click"  CssClass = "styled-button-4"/>
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 104px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 104px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;</td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;</td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="width: 147px; height: 21px;">
            &nbsp;&nbsp;
        </td>
        <td style="width: 79px; text-align: right; height: 21px;">
            &nbsp;
        </td>
        <td style="height: 21px">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px; font-weight: 700;">
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td style="width: 215px; font-weight: 700;">
            &nbsp;
        </td>
        <td style="width: 104px; text-align: right;">
            &nbsp;
        </td>
        <td style="width: 147px">
            &nbsp;
        </td>
        <td style="width: 79px; text-align: right;">
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table style="width: 100%">
        <tr>
            <td>
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
            <td>
                &nbsp;
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
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
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
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
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
