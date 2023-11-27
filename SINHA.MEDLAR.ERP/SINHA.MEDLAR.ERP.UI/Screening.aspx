<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Screening.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Screening" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="text-align:center;">
    
    <div style="text-align:center;">
        <div>
            <table>
                <tr>
                   <td style="text-align: right; width: 500px">
                       <asp:Label ID="lblPasscode" runat="server" Text="Passcode :"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtPasscode" runat="server" Width="236px" BackColor="White" 
                           OnTextChanged="txtPasscode_TextChanged" TextMode="Password"></asp:TextBox>
                   </td>
                </tr>
            </table>
        </div>

        <div>
            <table>
                <tr>
                   <td style="text-align: right; width: 500px">
                       <asp:Label ID="lblPulse" runat="server" Text="Pulse :" Visible="false"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtPulse" runat="server" Width="236px" BackColor="White" Visible="false"></asp:TextBox>
                   </td>
                </tr>


                <tr>
                   <td style="text-align: right; width: 500px">
                       
                   </td>
                   <td>
                       <asp:Label ID="lblMessage" runat="server"></asp:Label>
                   </td>
                </tr>

                <tr>
                   <td style="text-align: right; width: 500px">
                       
                   </td>
                   <td>
                       <asp:HiddenField ID="hfPassCode" runat="server" />
                   </td>
                </tr>


                <tr>
                   <td style="text-align: right; width: 500px">
                       
                   </td>
                   <td style="text-align:left;">
                       <asp:Button ID="btnRoadMap" runat="server" Height="31px" Text="Screen" 
                         Width="245px"  Visible="false" OnClick="btnRoadMap_Click" BackColor="Green"/>
                            <%--<asp:Button ID="btnProgress" runat="server" Height="31px" Text="Progress" 
                           Width="123px" Visible="false" OnClick="btnProgress_Click"/>
                       --%>                 

                   </td>
                </tr>


                <tr>
                   <td style="text-align: right; width: 500px">
                       
                   </td>
                   <td style="text-align:left;">
                        
                
                   </td>
                </tr>

                <tr>
                   <td style="text-align: right; width: 500px">
                       
                   </td>
                   <td>
                     
                   </td>
                </tr>

            </table>
        </div>


        <div>
            <table>
                <tr>
                   <td style="text-align: right; width: 500px">
                       
                   </td>
                   <td>
                       <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />                     
                   </td>
                </tr>
            </table>
        </div>

    </div>
    </form>
</body>
</html>
