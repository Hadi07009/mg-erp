<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="VFPackingList.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.VFPackingList" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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
    <script>
        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
    </script>
    <script language="javascript">
        $(window).load(function () { document.getElementById("<%= txtBarcodeNumber.ClientID %>").focus(); }) 
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
                document.getElementById("<%= txtBarcodeNumber.ClientID %>").value = "";
                 document.getElementById("<%= txtBarcodeNumber.ClientID %>").focus();
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
        <legend>ADD PACKING LIST</legend>
        <table style="width: 100%">
            <tr>

                <td style="color: red; height: 18px;" colspan="4">
                    &nbsp; &nbsp; &nbsp;
                </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 14px;">
                    <strong>
                        <asp:Label ID="lblId1" runat="server" Text="Style: "></asp:Label>
                    </strong>
                </td>
                <td class="style3" style="height: 14px; width: 58px;">
                    <asp:TextBox ID="txtStyleNo" runat="server" Width="145px" BackColor="White" Height="22px"></asp:TextBox>

                </td>
                <td style="width: 605px; height: 14px; text-align: right;">
                    <strong>
                        <asp:Label ID="lblId8" runat="server" Text="PO : "></asp:Label>
                    </strong>
                </td>
                <td style="height: 14px; width: 106px;">
                    <asp:TextBox ID="txtPoNo" runat="server" Width="102px" BackColor="White" Height="22px"></asp:TextBox>
                </td>
                <td style="width: 329px; height: 14px; text-align: justify;">
                    <asp:Button ID="btnSearch" runat="server" Height="31px" Text="Search" CssClass="styled-button-4"
                        Width="66px" OnClick="btnSearch_Click" />
                </td>
                <td style="height: 14px; width: 81px; background-color: #FFFFFF;">
                    &nbsp;</td>
                <td style="width: 420px; height: 14px; text-align: right;">
                    &nbsp;</td>
                <td style="height: 14px; width: 158px;">
                    <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />
                </td>

                <td style="height: 14px; width: 433px; text-align: right;">
                    &nbsp;</td>
                <td style="height: 14px">
                    &nbsp;</td>

            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 21px;">
                    <strong>
                        
                        <asp:Label ID="lblId4" runat="server" Text="Total Order Quantity : "></asp:Label>
                    </strong>
                </td>
                <td style="height: 21px; width: 58px;">
                    <asp:TextBox ID="txtTotalOrderQty" runat="server" Width="142px" 
                        BackColor="Yellow" Height="20px" Style="margin-left: 3px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 605px; text-align: right;">
                    <strong>
                        <asp:Label ID="lblId9" runat="server" Text="Total Ship Quantity : "></asp:Label>
                    </strong>
                </td>
                <td style="height: 21px; width: 106px;">
                    <asp:TextBox ID="txtTotalShipQty" runat="server" Width="101px" BackColor="Yellow" Height="20px" Style="margin-left: 0px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 329px; text-align: right;">
                    <strong>
                        <asp:Label ID="lblId10" runat="server" Text="CTN Quantity:"></asp:Label>
                    </strong>
                </td>
                <td style="height: 21px; width: 81px;">
                    <asp:TextBox ID="txtTotalCTNQty" runat="server" Width="77px" BackColor="Yellow" Height="19px" Style="margin-left: 0px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 420px;"></td>
                <td style="height: 21px; width: 158px;"></td>
                <td style="height: 21px; width: 433px;"></td>
                <td style="height: 21px; width: 121px;"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 21px;"></td>
                <td style="height: 21px; width: 58px;">
                    &nbsp;</td>
                <td style="height: 21px; width: 605px;"></td>
                <td style="height: 21px; width: 106px;"></td>
                <td style="height: 21px; width: 329px;"></td>
                <td style="height: 21px; width: 81px;"></td>
                <td style="height: 21px; width: 420px;"></td>
                <td style="height: 21px; width: 158px;"></td>
                <td style="height: 21px; width: 433px;"></td>
                <td style="height: 21px; width: 121px;"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 21px;">
                    <strong>
                    <asp:Label ID="lblId" runat="server" Text="SIZE : "></asp:Label>
                    </strong>
                </td>
                <td style="height: 21px; width: 58px;">
                    <asp:DropDownList ID="ddlSizeNameId" runat="server" Width="146px" Height="18px" AutoPostBack="true"
                        OnSelectedIndexChanged="ddlSizeNameId_SelectedIndexChanged">
                    </asp:DropDownList>
                    <%--<asp:DropDownList ID="ddlSizeNameId" runat="server" AutoPostBack="true"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Height="16px" 
                        Width="145px">
                    </asp:DropDownList>--%>
                </td>
                <td style="width: 605px; text-align: right;">
                    <strong>
                    <asp:Label ID="lblId3" runat="server" Text="Quantity Per Cutton: "></asp:Label>
                    </strong>
                </td>
                <td style="width: 106px">
                    <asp:TextBox ID="txtSizeWiweQuantityPerCutton" runat="server" Width="102px" 
                        BackColor="Yellow" Style="margin-left: 0px" Height="20px"></asp:TextBox>
                </td>
                <td style="width: 329px; text-align: right;">
                    <strong>
                    <asp:Label ID="lblId11" runat="server" Text=" Order Quantity "></asp:Label>
                    </strong>
                </td>
                <td style="width: 81px; background-color: #FFFFFF;">

                    <asp:TextBox ID="txtSizeWiseOrderQty" runat="server" Width="79px" 
                        BackColor="Yellow" Height="20px" Style="margin-left: 0px"></asp:TextBox>
                </td>
                <td style="height: 21px; width: 420px; text-align: right;"><strong>MSG Box</strong>:</td>
                <td style="height: 21px; width: 158px;">

                    <asp:TextBox ID="txtMsg" runat="server" Width="160px" BackColor="#FFFF66" Height="20px" Font-Bold="true" Style="margin-left: 0px"></asp:TextBox>
                 
                </td>
                 <td style="height: 21px; width: 433px;"></td>
                <td style="height: 21px; width: 52px;"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 22px;">
                    <strong>
                    <asp:Label ID="lblId0" runat="server" Text="CRD Date : "></asp:Label>
                    </strong>
                </td>
                <td style="height: 22px; width: 58px;">
                    <asp:TextBox ID="dtpCRDDate" runat="server" Width="142px" BackColor="White" CssClass="date"></asp:TextBox>
                </td>
                <td style="width: 605px; height: 22px; text-align: right;">
                    <strong>
                    <asp:Label ID="lblId7" runat="server" Text="Packing Date : "></asp:Label>
                    </strong>
                </td>
                <td style="height: 22px; width: 106px;">
                    <asp:TextBox ID="dtpPackingDate" runat="server" Width="104px" BackColor="#FFFF66" CssClass="date"></asp:TextBox>
                </td>
                <td style="width: 329px; height: 22px;"></td>
                <td style="height: 22px; width: 81px;"></td>
                <td style="width: 420px; height: 22px;"></td>
                <td style="height: 22px; width: 158px;"></td>
                <td style="width: 433px; height: 22px;"></td>
                <td style="height: 22px; width: 16px;"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 22px;">
                    <strong>
                    <asp:Label ID="lblProductCataroy" runat="server" Text="Barcode Number:"></asp:Label>
                    </strong>
                </td>
                <td style="height: 22px; width: 58px;">
                    <asp:TextBox ID="txtBarcodeNumber" runat="server" Width="143px" BackColor="White" onkeydown="javascript:TextName_OnKeyDown(event)"></asp:TextBox>
                </td>
                <td style="width: 605px; text-align: right;">
                    &nbsp;</td>
                <td style="width: 106px">
                    &nbsp;</td>
                <td style="height: 22px; width: 329px;">&nbsp;</td>
                <td style="height: 22px; width: 81px;"> </td>
                <td style="height: 22px; width: 420px;">&nbsp;</td>
                <td style="height: 22px; width: 158px;"> </td>
                <td style="height: 22px; width: 433px;">&nbsp;</td>
                <td style="height: 22px; width: 16px;"> </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 19px">&nbsp;
                </td>
                <td style="height: 19px; width: 58px;">&nbsp;
                </td>
                <td style="height: 19px; width: 605px;"></td>
                <td style="height: 19px; width: 106px;"></td>
                 <td style="height: 19px; width: 329px;"></td>
                <td style="height: 19px; width: 81px;"></td>
                 <td style="height: 19px; width: 420px;"></td>
                <td style="height: 19px; width: 158px;"></td>
                 <td style="height: 19px; width: 433px;"></td>
                <td style="height: 19px; width: 88px;"></td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px">&nbsp;
                </td>
                <td style="width: 58px">&nbsp;</td>
                 <td style="text-align: right; width: 605px">&nbsp;
                </td>
                <td style="width: 106px; text-align: right;">
                    <asp:Button ID="btnClear" runat="server" Height="31px" Text="Clear" CssClass="styled-button-4"
                        Width="44px" OnClick="btnClear_Click" />
                </td>
                 <td style="text-align: justify; width: 329px">&nbsp;
                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="43px" OnClick="btnSave_Click"
                        CssClass="styled-button-4" />
                    <asp:Button ID="Sheet" runat="server" Height="31px" Text="Sheet" Width="41px" OnClick="btnVFSheet_Click"
                        CssClass="styled-button-4" />
                </td>
                <td style="width: 81px">
                    &nbsp;</td>
                 <td style="text-align: right; width: 420px">&nbsp;
                </td>
                <td style="width: 158px">&nbsp;</td>
                <td style="width: 433px">
                    &nbsp;</td>
                <td style="width: 88px">&nbsp;
                    </td>
            </tr>
            <tr>
                <td style="text-align: right; width: 667px; height: 15px;"></td>
                <td style="width: 58px; height: 15px;"></td>
                <td style="width: 605px; height: 15px;"></td>
                <td style="width: 106px; height: 15px;"></td>
                <td style="width: 329px; height: 15px;"></td>
                <td style="width: 81px; height: 15px;"></td>
                <td style="width: 420px; height: 15px;"></td>
             <td style="width: 158px; height: 15px;"></td>
                <td style="width: 433px; height: 15px;"></td>
                <td style="width: 52px; height: 15px;"></td>
            </tr>
              
            
            <tr>
                <td style="text-align: right;" colspan="10">
                    <asp:GridView ID="gvUnit" runat="server" DataSourceID="" AutoGenerateColumns="False" Font-Bold="true"
                        GridLines="None" AllowPaging="false" CssClass="mGrid" PagerStyle-CssClass="pgr"
                        AlternatingRowStyle-CssClass="alt" OnPageIndexChanging="gvUnit_PageIndexChanging"
                        OnRowDataBound="OnRowDataBound" OnSelectedIndexChanged="OnSelectedIndexChanged" Width="1013px" Height="93px">
                        <Columns>
                            <asp:BoundField DataField="SIZE_NAME" HeaderText="SIZE" />
                            <asp:BoundField DataField="BARCODE_NUMBER" HeaderText="BARCODE NUMBER" />
                            <asp:BoundField DataField="PACKING_DATE" HeaderText="PACKING DATE" />
                            <asp:BoundField DataField="QUANTITY" HeaderText="SIZE WISE SHIP QTY" />
                            <asp:BoundField DataField="REGULAR_CUTTON" HeaderText="REGULAR CUTTON" />
                            <asp:BoundField DataField="IR_REGULAR_CUTTON" HeaderText="IR REGULAR CUTTON" />
                             <asp:BoundField DataField="IR_REGULAR_QUANTITY" HeaderText="IR REGULAR QUANTITY" />
                            <%--<asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:Button ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" BorderStyle="Ridge" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
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
