<%@ Page Title="" Language="C#" MasterPageFile="~/EmpLogin.Master" AutoEventWireup="true"
    CodeBehind="ForgetPass.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ForgetPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:ScriptManager ID="SM1" runat="server">
    </asp:ScriptManager>
    <table style="width: 100%">
        <tr>
            <td style="width: 431px">
                <asp:Label ID="Label1" runat="server" Style="font-size: medium; font-weight: 700"
                    Text="Forget Password"></asp:Label>
            </td>
            <td style="width: 457px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 431px">
                &nbsp;
            </td>
            <td style="width: 457px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 431px">
                &nbsp;
            </td>
            <td style="width: 457px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 431px">
                <asp:Label ID="Label3" runat="server" Text="Enter Email Addresss :"></asp:Label>
            </td>
            <td style="width: 457px">
                <asp:TextBox ID="txtEmailAddress" runat="server" Height="22px" Width="265px" CssClass="textbox"></asp:TextBox>
                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmailAddress" ErrorMessage="Invalid Email Format" Display="Dynamic"
                    ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 431px">
                &nbsp;</td>
            <td style="width: 457px">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 431px">
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Login.aspx">Back</asp:LinkButton>
            </td>
            <td style="width: 457px">
                <asp:Button ID="btnSend" runat="server" Height="31px" Text="Send" Width="87px" OnClick="btnSend_Click"  class="btnExample"/>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 431px">
                &nbsp;
            </td>
            <td style="text-align: right; width: 457px">
                <asp:Label ID="Label4" runat="server" Text="Date :" Style="text-align: right"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblDate" runat="server" Text="Date :"></asp:Label>
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
