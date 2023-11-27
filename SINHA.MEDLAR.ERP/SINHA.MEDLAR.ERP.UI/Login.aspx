<%@ Page Title="" Language="C#" MasterPageFile="~/EmpLogin.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtEmployeeName.ClientID %>").focus(); }) 
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
                document.getElementById('<%= btnLogin.ClientID %>').click();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 434px">
                <asp:Image ID="Image1" runat="server" Height="50px" ImageUrl="~/Logo/Sinhalogo.png"
                    Width="78px" />
            </td>
            <td style="width: 444px; text-align: left;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 434px">
                <asp:Label ID="Label2" runat="server" Text="User ID :"></asp:Label>
            </td>
            <td style="width: 444px">
                <asp:TextBox ID="txtEmployeeName" runat="server" Height="22px" Width="265px" CssClass="textbox"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 434px">
                <asp:Label ID="Label3" runat="server" Text="Password :"></asp:Label>
            </td>
            <td style="width: 444px">
                <asp:TextBox ID="txtPassword" runat="server" Height="22px" TextMode="Password" Width="265px"
                    CssClass="textbox" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 434px">
                <asp:Label runat="server" ID="DateStampLabel" />
                &nbsp;
            </td>
            <td style="width: 444px">
                <asp:CheckBox ID="chkRemember" runat="server" Text="Remember me " />
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 434px">
                <asp:Label ID="lblCountryCode" runat="server" Text=""></asp:Label>
            </td>
            <td style="width: 444px">
                <asp:Button ID="btnLogin" runat="server" Height="31px" Text="Login" Width="87px"
                    class="btnExample" OnClick="btnLogin_Click" />
            </td>
        </tr>
        <tr>
            <td style="text-align: left; width: 434px">
                <asp:Label ID="lblSoftwareVersion" runat="server" Text="Software Version : " Style="text-align: right"></asp:Label>
            </td>
            <td style="text-align: right; width: 444px">
                <asp:Label ID="Label4" runat="server" Text="Date :" Style="text-align: right"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Date :"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table style="width: 100%";>
        <tr>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="tmrUpdate" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:Label ID="lblTime" runat="server" Text=""></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:Timer ID="tmrUpdate" runat="server" Interval="1000" OnTick="tmrUpdate_Tick">
                </asp:Timer>
                <asp:TextBox ID="txtIpAddress" runat="server" Height="22px" TextMode="Password" Width="64px"
                    Visible="False"></asp:TextBox>
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
