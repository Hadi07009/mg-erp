<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="GazetteProcess.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.GazetteProcess" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .tooltip {
            display: none;
            border: solid 1px #708069;
            background-color: #289642;
            color: #fff;
            line-height: 25px;
            border-radius: 5px;
            padding: 5px 10px;
            position: absolute;
            z-index: 1001;
        }

        .style4 {
            height: 22px;
            width: 135px;
        }

        .style5 {
            width: 135px;
        }

        .auto-style1 {
            width: 919px;
        }

        .auto-style2 {
            height: 22px;
            width: 236px;
        }

        .auto-style3 {
            width: 236px;
        }

        .auto-style4 {
            text-align: right;
        height: 22px;
    }

        .auto-style5 {
        width: 163px;
        height: 22px;
    }
    .auto-style6 {
        width: 66px;
        height: 22px;
    }
    .auto-style7 {
        height: 22px;
    }

        </style>
    
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
        <legend>WORKER GAZETTE INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma" Visible="False"></asp:Label>
                </td>
                <td style="text-align: right">

                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                                        CssClass="CheckBox" OnCheckedChanged="chkPDF_CheckedChanged" Font-Bold="True" />
                                    &nbsp;<asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true"
                                        OnCheckedChanged="chkExcel_CheckedChanged" Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkWord" runat="server" Text="Word" AutoPostBack="true" OnCheckedChanged="chkWord_CheckedChanged"
                                        Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;<asp:CheckBox ID="chkText" runat="server" Text="Text" AutoPostBack="true" OnCheckedChanged="chkText_CheckedChanged"
                                        Font-Bold="True" CssClass="CheckBox" />
                                    &nbsp;
                                    <asp:CheckBox ID="chkCSV" runat="server" GroupName="Controls" Text="CSV" AutoPostBack="true"
                                        OnCheckedChanged="chkCSV_CheckedChanged" Font-Bold="True" CssClass="CheckBox" />
                     &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <table class="style1">
                      
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    
                                        <table class="style1">

                                            <tr>
                                                <%--new--%>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label1" runat="server" Text="Unit Group :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:DropDownList ID="ddlUnitGroupId" runat="server" Width="240px" Height="22px">
                                                        <asp:ListItem Value="" Text="Please Select"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Unit Group- 1"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Unit Group- 2"></asp:ListItem>
                                                        <asp:ListItem Value="3" Text="Unit Group- 3"></asp:ListItem>
                                                        <asp:ListItem Value="4" Text="Unit Group- 4"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 66px">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label2" runat="server" Text="Employee Id :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 66px">
                                                    <asp:TextBox ID="txtEmpId" runat="server" Width="240px" BackColor="White"></asp:TextBox>
                                                </td>
                                                

                                                <%--end--%>
                                            </tr>


                                            <tr>
                                                <td style="text-align: right;" class="auto-style2">
                                                    <asp:Label ID="Label34" runat="server" Text="Unit :"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td class="auto-style5">
                                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="auto-style6">
                                                    &nbsp;
                                                </td>
                                                <td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label35" runat="server" Text="Gazette Year:"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="txtGazetteYear" runat="server" Width="235px" BackColor="White"></asp:TextBox>
                                                </td>
                                               <%-- <td style="text-align: right; " class="auto-style4">
                                                    <asp:Label ID="Label39" runat="server" Text="Section:"></asp:Label>
                                                </td>
                                                <td class="auto-style7">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>--%>
                                            </tr>
                                            <tr>
                                                 <td style="text-align: right; " class="auto-style4">
                                                    <asp:Label ID="Label39" runat="server" Text="Section:"></asp:Label>
                                                </td>
                                                <td class="auto-style7">
                                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                                <%--<td style="text-align: right" class="auto-style3">
                                                    <asp:Label ID="Label35" runat="server" Text="Gazette Year:"></asp:Label>
                                                    &nbsp;
                                                </td>
                                                <td style="width: 163px">
                                                    <asp:TextBox ID="txtGazetteYear" runat="server" Width="235px" BackColor="White"></asp:TextBox>
                                                </td>--%>

                                                <td style="width: 66px">&nbsp;
                                                </td>
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label40" runat="server" Text="Gazette Month :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlGazetteMonth" runat="server" Width="240px" Height="22px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>

                                              <tr>
                                                
                                                <td style="text-align: right;">
                                                    <asp:Label ID="Label4" runat="server" Text="Increment :"></asp:Label>
                                                </td>
                                                <td>
                                                   <asp:CheckBox ID="chkIncrementYn" runat="server" Text="Yes"/>
                                                </td>
                                            </tr>

                                              <tr>
                                                
                                                <td style="text-align: right;">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>

                                             <tr>
                                              
                                <td style="text-align: center" colspan="4">
                                   
                                     <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" Width="66px"
                                        CssClass="styled-button-4" />                              
                                    <asp:Button ID="btnGazetteProcess" runat="server" Height="31px" Text="Analyze" Width="66px"
                                        CssClass="styled-button-4" OnClick="btnGazetteProcess_Click" />
                                    <asp:Button ID="btnSheet" runat="server" Height="31px" Text="Sheet" Width="50px"
                                        CssClass="styled-button-4" OnClick="btnSheet_Click" />
                                    <asp:Button ID="btnRequisition" runat="server" Height="31px" Text="Requisition" Width="80px"
                                        CssClass="styled-button-4" OnClick="btnRequisition_Click"  />
                                  <asp:Button ID="ButSummary" runat="server" Height="31px" Text="Summary" Width="80px"
                                        CssClass="styled-button-4" OnClick="ButSummary_Click"  />
                                   <asp:Button ID="btnGazetAdjustment" runat="server" Height="31px" 
                                         Text="Adjust Gazette" Width="100px" CssClass="styled-button-4" Visible="false"
                                         OnClick="btnGazetAdjustment_Click"/>   
                                </td>
                            </tr>
                                        </table>
                                    
                                </td>
                            </tr>
                        
                        </table>
                    </fieldset>
            </tr>
       
        </table>
    </fieldset>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="style1">
        <tr>
            <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;
            </td>
            <td>&nbsp;
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
