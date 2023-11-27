
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Timing.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Timing" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            
    <script type="text/javascript">
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
</head>

    
<body>

    <form id="form1" runat="server">

        <table style="width: 100%">
            <tr>
                <td style="text-align: left; width: 917px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                    
                </td>
            </tr>
            <tr>
                <td style="text-align: left;" colspan="2">

                        <table style="width: 100%">

                            <tr>
                                                                
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy5" runat="server" Text="Unit :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlUnitId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>
                                                                
                            </tr>

                            <tr>
                                
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy6" runat="server" Text="Section :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:DropDownList ID="ddlSectionId" runat="server" Width="240px" Height="22px">
                                    </asp:DropDownList>
                                </td>

                                
                            </tr>
                            <tr>
                                
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy7" runat="server" Text="From Date :"></asp:Label>
                                </td>
                                <td style="height: 19px">
                                    <asp:TextBox ID="dtpFromDate" runat="server" Width="232px" BackColor="White" 
                                        CssClass="date"></asp:TextBox>
                                </td>
                                
                            </tr>
                            <tr>
                                
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    <asp:Label ID="lblProductCataroy4" runat="server" Text="To Date :"></asp:Label>
                                </td>
                                <td style="height: 19px;">
                                    <asp:TextBox ID="dtpToDate" runat="server" Width="232px" BackColor="White" 
                                        CssClass="date"></asp:TextBox>
                                </td>
                            </tr>
                                
                            <tr>
                                <td style="height: 19px; width: 116px; text-align: right;">
                                    
                                </td>
                                <td style="text-align: left;" colspan="2">
                                    
                                    <asp:Button ID="btnAttendenceSheet" runat="server" Height="31px" Text="Sheet" Width="240px"
                                        CssClass="styled-button-4" OnClick="btnAttendenceSheet_Click" /></td>
                            </tr>
                        </table>
                   
                </td>
            </tr>
        </table>
    
               
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
    </table>

    </form>
</body>
</html>