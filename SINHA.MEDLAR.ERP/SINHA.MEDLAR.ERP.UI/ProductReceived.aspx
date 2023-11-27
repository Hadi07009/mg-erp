<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ProductReceived.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.ProductReceived" %>

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

    <%--<script type="text/javascript" language="javascript">
        $(window).load(function () { document.getElementById("<%= txtRequisitionNo.ClientID %>").focus(); }) 
    </script>--%>
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

      

      <script language="javascript" type="text/javascript">
        $(function () {
            $('#<%=txtRequisitionNo.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ProductReceived.aspx/GetRequisitionNo",
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
            $('#<%=txtPartNoSrc.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "ProductReceived.aspx/GetPartNo",
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
        <legend>PRODUCT RECEVED INFORMATION</legend>
        <table class="style1">
            <tr>
                <td style="text-align: left; width: 596px;">
                    <asp:Label ID="lblMsg" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                        Font-Names="Tahoma"></asp:Label>
                </td>
                <td style="text-align: left">
                  <%--  <asp:CheckBox ID="chkPDF" runat="server" Text="PDF" AutoPostBack="true" Checked="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" Font-Bold="True" OnCheckedChanged="chkPDF_CheckedChanged" />
                    <asp:CheckBox ID="chkExcel" runat="server" Text="Excel" AutoPostBack="true" Font-Bold="True"
                        ViewStateMode="Enabled" CssClass="CheckBox" OnCheckedChanged="chkExcel_CheckedChanged" />--%>
                </td>
            </tr>
            </td>
            <tr>
                <td style="text-align: right" colspan="2">
                    <fieldset>
                        <legend>PRODUCT RECEVED INFO ENTRY</legend>
                        <table class="style1">
                            <tr>
                                <td style="width: 521px; text-align: right">
                                    <asp:Label ID="Label41" runat="server" Text="MRR No :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtMRRNo" runat="server" BackColor="Yellow" Width="180px"></asp:TextBox>
                                    <asp:TextBox ID="txtTranId" runat="server" BackColor="Yellow" Width="20px" 
                                        Visible="False"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 521px; text-align: right">
                                    <asp:Label ID="Label32" runat="server" Text="Part No :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtPartNo" runat="server" BackColor="Yellow" ReadOnly="True" Width="180px"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 521px; text-align: right; height: 22px;">
                                    <asp:Label ID="Label27" runat="server" Text="Required/Approved Qty :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left; height: 22px;">
                                    <asp:TextBox ID="txtRequiredQty" runat="server" Width="101px" 
                                        BackColor="Yellow" ReadOnly="True"></asp:TextBox>
                                    <asp:TextBox ID="txtApprovedQty" runat="server" Width="71px" BackColor="Yellow" 
                                        ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right; height: 22px;">
                                    &nbsp;
                                </td>
                                <td style="height: 22px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 521px; text-align: right">
                                    <asp:Label ID="Label44" runat="server" Text="Received Qty :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="txtReceivedQty" runat="server" Width="180px"></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 521px; text-align: right">
                                    <asp:Label ID="Label43" runat="server" Text="Received Date :"></asp:Label>
                                </td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:TextBox ID="dtpReceivedDate" runat="server" Width="180px" CssClass="date" onkeydown="javascript:TextName_OnKeyDown(event)" ></asp:TextBox>
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 521px; text-align: right">
                                    &nbsp;</td>
                                <td style="width: 390px; text-align: left;">
                                    &nbsp;</td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 521px; text-align: right">
                                    &nbsp;</td>
                                <td style="width: 390px; text-align: left;">
                                    <asp:Button ID="btnSave" runat="server" Height="31px" Text="Save" Width="66px" OnClick="btnSave_Click"
                                        CssClass="styled-button-4" />
                                    <asp:Button ID="btnClear" runat="server" Height="30px" Text="Clear" Width="66px" OnClick="btnClear_Click"
                                        CssClass="styled-button-4" />
                                </td>
                                <td style="width: 247px; text-align: right;">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="text-align: right" colspan="4">
                                    <fieldset>
                                        <legend>SEARCH CRITERIA</legend>
                                        <table class="style1">
                                            <tr>
                                                <td style="width: 149px; text-align: right; height: 22px;">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 288px; height: 22px; text-align: right;">
                                                    <asp:Label ID="Label39" runat="server" Text="Requisition No :"></asp:Label>
                                                </td>
                                                <td style="height: 22px; width: 61px;">
                                                    <asp:TextBox ID="txtRequisitionNo" runat="server" Width="180px" BackColor="White" Font-Bold="True" ForeColor="Black" CssClass="textboxAuto"></asp:TextBox>
                                                 
                                                </td>
                                                <td style="height: 22px; width: 77px; text-align: left;">
                                                    <asp:Button ID="btnSearch" runat="server" Height="25px" Text="Search" Width="55px"
                                                        CssClass="styled-button-4" OnClick="btnSearch_Click" />
                                                 
                                                </td>
                                                <td style="height: 22px">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 149px; text-align: right">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 288px ; text-align: right;">
                                                    <asp:Label ID="Label40" runat="server" Text="Part No :"></asp:Label>
                                                </td>
                                                <td style="width: 61px ; height:22px">
                                                    <asp:TextBox ID="txtPartNoSrc" runat="server" Width="180px" Font-Bold="True" ForeColor="Black" CssClass="textboxAuto"></asp:TextBox>
                                                </td>
                                                <td style="width: 77px; text-align: right">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left" colspan="4">
                                    <asp:Label ID="lblMsgRecord" runat="server" Text="lblMsg" Font-Bold="True" Font-Size="Small"
                                        Font-Names="Tahoma"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
            </tr>
            <tr>
                <td colspan="2">
                    <fieldset>
                        <legend>PRODUCT RECEVED ENTRY</legend>
                        <%-- </div>--%>
                        <table style="width: 100%">
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvProductReceved" runat="server" DataSourceID="" AutoGenerateColumns="False" DataKeyNames="MRR_NO, TRAN_ID,RECEIVED_DATE,PART_NO"
                                        OnRowDataBound="gvProductReceved_OnRowDataBound" AllowSorting="True" EnableViewState="true"
                                        CausesValidation="false" GridLines="None" AllowPaging="false" OnRowEditing="gvProductReceved_OnRowEditing"
                                        CssClass="mGrid" PagerStyle-CssClass="pgr" OnSelectedIndexChanged="gvProductReceved_OnSelectedIndexChanged"
                                        AlternatingRowStyle-CssClass="alt" OnRowDeleting="gvProductReceved_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="SL" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="TRAN_ID" HeaderText="ID" />
                                            <asp:BoundField DataField="MRR_NO" HeaderText="MRR NO" />
                                            <asp:BoundField DataField="REQUISITION_NO" HeaderText="REQUISITION NO" />
                                            <asp:BoundField DataField="PART_NO" HeaderText="PART NO" />
                                            <asp:BoundField DataField="REQUIRED_QTY" HeaderText="REQUIRED.QTY" />
                                            <asp:BoundField DataField="APPROVED_QTY" HeaderText="APPROVED.QTY" />
                                            <asp:BoundField DataField="RECEIVED_QTY" HeaderText="RECEIVED.QTY" />
                                            <asp:BoundField DataField="RECEIVED_DATE" HeaderText="RECEIVED DATE" /> 
                                            <asp:TemplateField HeaderText="DELETE" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                 <ItemTemplate>
                                                        <asp:LinkButton ID="DeleteBtn" runat="server" CommandName="Delete" OnClientClick="return isDelete();">Delete</asp:LinkButton>
                                                 </ItemTemplate>
                                            </asp:TemplateField>                                     
                                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <fieldset>
        <legend>SEARCH RESULT</legend>
        <%-- </div>--%>
        <table style="width: 100%">
            <tr>
                <td colspan="2">
                    <asp:GridView ID="gvProductRecInfoSearch" runat="server" DataSourceID="" AutoGenerateColumns="False"
                        AllowSorting="True" EnableViewState="true" GridLines="None" AllowPaging="false"
                        CausesValidation="false" CssClass="mGrid" PagerStyle-CssClass="pgr" OnRowEditing="OnRowEditing"
                        OnSelectedIndexChanged="gvProductRecInfoSearch_OnSelectedIndexChanged" AlternatingRowStyle-CssClass="alt"
                        OnRowDataBound="OnRowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="SL" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="PART_NO" HeaderText="PART NO" />
                            <asp:BoundField DataField="PARTICULAR_NAME" HeaderText="PARTICULARS" />
                            <asp:BoundField DataField="PO_UNIT_NAME" HeaderText="UNIT" />
                            <asp:BoundField DataField="REQUIRED_QTY" HeaderText="REQUIRED QTY" />
                            <asp:BoundField DataField="APPROVED_QTY" HeaderText="APPROVED QTY" />
                            <asp:TemplateField HeaderText="SELECT" ItemStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnselect" Width="25" Height="20" runat="server" CommandName="Select"
                                        Style="cursor: pointer" Text="..." CausesValidation="false" ImageUrl="~/images/select_png.jpg"  AlternateText="Select"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
        <%-- </div>--%>
    </fieldset>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <table class="style1">
        <tr>
           <%-- <td colspan="2">
                <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
            </td>--%>
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
