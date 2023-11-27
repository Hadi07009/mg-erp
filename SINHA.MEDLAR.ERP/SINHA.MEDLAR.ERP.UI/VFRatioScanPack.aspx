<%@ Page Title="" Language="C#" MasterPageFile="~/NewVersion.Master" AutoEventWireup="true"
    ValidateRequest="false" EnableEventValidation="false" CodeBehind="VFRatioScanPack.aspx.cs"
    Inherits="SINHA.MEDLAR.ERP.UI.VFRatioScanPack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <script type="text/javascript">

        function GetCartoonSummary(po_no, style_no) {


            $("#gvCartoonSummary tbody").empty();
            var rows = '';
            var action = '<a href="#" OnClick="Select(this);">Click</a>';

            $.ajax({
                type: "POST",
                url: "VFRatioScanPack.aspx/GetCartoonSummary",
                data: JSON.stringify({ po_no: po_no, style_no: style_no }), //'{ po_no:'+ po_no + ', style_no:'+ style_no },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function OnSuccess(result) {
                    $("#gvCartoonSummary tbody").empty();

                    for (i = 0; i < result.d.length; i++) {

                        rows = rows + "<tr><td style='display:none;'>" +
                        result.d[i].CARTOON_ID + "</td> <td style='display:none;'>" +
                        result.d[i].po_no + "</td> <td style='display:none;'>" +
                        result.d[i].style_no + "</td> <td>" +
                        result.d[i].CARTOON_SIZE + "</td> <td>" +
                        result.d[i].product_size + "</td> <td>" +
                        action + "</td></tr>";
                    }

                    $("#gvCartoonSummary tbody").append(rows);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function GetCartoonDetail(cartoonId, poNo, styleNo) {

            var cartoonNumber = '';

            $("#gvCartoonDetail tbody").empty();
            var rows = '';

            $.ajax({
                type: "POST",
                url: "VFRatioScanPack.aspx/GetCartoonDetail",
                data: JSON.stringify({ cartoonId: cartoonId, poNo: poNo, styleNo: styleNo }), //'{ po_no:'+ po_no + ', style_no:'+ style_no },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function OnSuccess(result) {

                    for (i = 0; i < result.d.length; i++) {

                        cartoonNumber = result.d[i].cartoon_number;

                        rows = rows + "<tr><td>" +
                        result.d[i].size_name + "</td> <td>" +
                        result.d[i].capacity + "</td> <td>" +
                        result.d[i].scan_quantity + "</td> <td>" +
                        result.d[i].remaining + "</td> </tr>";
                    }
                    $('#txtCartoonNumber').val(cartoonNumber);
                    $("#gvCartoonDetail tbody").append(rows);
                },
                failure: function (response) {
                    alert(response.d);
                }
            });
        }

        function SaveProduct(cartoonId, poNo, styleNo, barCode) {

            $.ajax({
                type: "POST",
                url: "VFRatioScanPack.aspx/SaveProduct",
                data: JSON.stringify({ cartoonId: cartoonId, poNo: poNo, styleNo: styleNo, barCode: barCode }), //'{ po_no:'+ po_no + ', style_no:'+ style_no },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function OnSuccess(result) {

                    GetCartoonDetail(cartoonId, poNo, styleNo);

                    if (result.d.message != 'OK') {
                        alert(result.d.message);
                    }
                    //$('#txtCartoonNumber').val(result.d.cartoonNumber);
                    $('#txtResult').val(result.d.status);
                },
                failure: function (result) {
                    alert(result.d);
                }
            });
        }

        $("#btnSave").click(function () {

            var cartoonId = $('#hfCartoonId').val();
            var poNo = $('#hfPoNo').val();
            var styleNo = $('#hfStyleNo').val();
            var barCode = $('#txtBarCode').val();

            SaveProduct(cartoonId, poNo, styleNo, barCode);
        });


        function Select(element) {

            var cartoonId = $(element).closest("tr").find("td:eq(0)").text();
            var poNo = $(element).closest("tr").find("td:eq(1)").text();
            var styleNo = $(element).closest("tr").find("td:eq(2)").text();

            $('#hfCartoonId').val(cartoonId);
            $('#hfPoNo').val(poNo);
            $('#hfStyleNo').val(styleNo);
            GetCartoonDetail(cartoonId, poNo, styleNo);

        }

        $(document).ready(function () {

            $("input[type='text']").keypress(function (event) {
                var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
                if (keyCode == 13) {
                    return false;
                }
                else {
                    return true;
                }
            });

            $("#btnCartoonSummary").click(function () {
                var po_no = $('#ContentPlaceHolder2_txtpo_no').val();
                var style_no = $('#ContentPlaceHolder2_txtstyle_no').val();
                GetCartoonSummary(po_no, style_no);
            });


            $("#txtBarCode").change(function () {
               
                var cartoonId = $('#hfCartoonId').val();
                var poNo = $('#hfPoNo').val();
                var styleNo = $('#hfStyleNo').val();
                var barCode = $('#txtBarCode').val();

                SaveProduct(cartoonId, poNo, styleNo, barCode);
                $('#txtBarCode').val('');
            });
        });

    </script>


    <%--<table class="style1">
        <tr>
            <td style="width: 342px; height: 15px">
                <asp:Label ID="lblHeadOfficeName" runat="server" Text="Office Name" Font-Bold="True" Visible="false"
                    Font-Size="Small" Font-Names="Tahoma" Style="color: #0000FF"></asp:Label>
            </td>
            <td style="height: 15px">
                <asp:Label ID="lblHeadOfficeAddress" runat="server" Text="Head Office  Address" Font-Bold="True" Visible="false"
                    Font-Size="Small" Style="color: #0000FF"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 342px">
                <asp:Label ID="lblBranchOfficeName" runat="server" Text="Office Name" Font-Bold="True" Visible="false"
                    Font-Size="Small" Font-Names="Tahoma" Style="color: #0000FF"></asp:Label>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblBranchOfficeAddress" runat="server" Text="Branch Office Address" Visible="false"
                    Font-Bold="True" Font-Size="Small" Style="color: #0000FF"></asp:Label>
                &nbsp;
            </td>
        </tr>
    </table>--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <fieldset>
        <legend>Scan Pack</legend>

        <div class="form-horizontal container">
                    <div class="row">

                        <div class="col-md-4">

                        <div class="row">
                            <div class="form-group">
                                <asp:Label ID="lblId" runat="server" Text="Style:" style="text-align: right;" CssClass="label-control col-md-2"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtstyle_no" runat="server" Width="183px" BackColor="White" CssClass="form-control"></asp:TextBox>
                                </div>
                                <%--<div class="col-md-5">
                                    <input type="button" id="btnCartoonSummary" value="Submit" class="btn btn-primary" />
                                </div>--%>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                               <asp:Label ID="lblProductCataroy" runat="server" Text="PO:" style="text-align: right;" CssClass="label-control col-md-2"></asp:Label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtpo_no" runat="server" Width="183px" BackColor="White" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-5">
                                    <input type="button" id="btnCartoonSummary" value="Submit" class="btn btn-primary" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <asp:Label ID="lblBarcode" runat="server" Text="Barcode:" style="text-align: right;" CssClass="label-control col-md-2"></asp:Label>
                                <div class="col-md-5">
                                    <input type="text" id="txtBarCode" style="width: 183px; background-color: white;" class="form-control"/>
                                </div>
                                <div class="col-md-5">
                                    <input type="text" id="txtResult" style="width: 50px; background-color: #FFFF66;" readonly="readonly" class="form-control"/>
                                    <input type="text" id="hfCartoonId" style="display: none;" />
                                    <input type="text" id="hfPoNo" style="display: none;" />
                                    <input type="text" id="hfStyleNo" style="display: none;" />
                                </div>
                            </div>
                        </div>
                     </div>


                        <div class="col-md-3">
                            <div class="row">
                            <div class="form-group">
                                <asp:Label ID="Label2" runat="server" Text="Order Quantity:" style="text-align: right;" CssClass="label-control col-md-4"></asp:Label>
                               
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox1" runat="server" Width="82px" BackColor="#FFFF66" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            </div>
                            <div class="row">
                            <div class="form-group">
                                <asp:Label ID="Label3" runat="server" Text="Scan Quantity:" style="text-align: right;" CssClass="label-control col-md-4"></asp:Label>
                                <div class="col-md-8">
                                    <asp:TextBox ID="TextBox3" runat="server" Width="82px" BackColor="#FFFF66" ReadOnly="true" class="form-control"></asp:TextBox>
                                </div>
                            </div>
                            </div>

                            <div class="row">
                            <div class="form-group">
                                <asp:Label ID="Label1" runat="server" Text="Scanning Cartoon:" style="text-align: right;" CssClass="label-control col-md-4"></asp:Label>
                                <div class="col-md-8">
                                    <input type="text" id="txtCartoonNumber" style="width: 82px; background-color: #FFFFFF; text-align: center;" readonly="readonly" class="form-control"/>                               
                                </div>
                            </div>
                            </div>

                        </div>
                        <div class="col-md-5">

                            <%--<div class="row">
                                <div class="form-group">
                                <div class="col-md-12" style="text-align:right; width:71%;">
                                <input type="text" id="txtCartoonNumber" style="width: 50px; background-color: #FFFF66; text-align: center;" readonly="readonly" class="label-control"/>                               
                                </div>
                                </div>

                            </div>--%>

                            <div class="row">
                            <div class="form-group">
                                <div class="col-md-12">
                                    <div style="overflow-y: auto; height: auto; width: 70%;">
                                    <table id="gvCartoonDetail" class="sinha-table">
                                        <thead>
                                            <tr>
                                                <th style="width: 46px">Cartoon Size</th>
                                                <th>Capacity</th>
                                                <th style="width: 52px">Scan Quantity</th>
                                                <th>Remaining</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                                </div>
                            </div>
                            </div>
                        </div>
                </div>

            <div class="row">
                            <div class="form-group">
                                
                                <div class="col-md-12">
                                    <div style="overflow-y: auto; height: 200px; width:87%;">
                                        <table id="gvCartoonSummary" class="sinha-table">
                                            <thead>
                                                <tr>
                                                    <th style="display: none;">CARTOON ID</th>
                                                    <th style="display: none;">PO No</th>
                                                    <th style="display: none;">Style No</th>
                                                    <th style="width: 100px;">Cartoon Size</th>
                                                    <th style="width: 100px;">Product</th>
                                                    <th style="width: 100px;">Select</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                               
                            </div>
            </div>

           <%-- <div style="overflow-y: auto; height: 200px; width: 400px;">
                <table id="gvCartoonSummary" class="sinha-table">
                    <thead>
                        <tr>
                            <th style="display: none;">CARTOON ID</th>
                            <th style="display: none;">PO No</th>
                            <th style="display: none;">Style No</th>
                            <th style="width: 100px;">Cartoon Size</th>
                            <th style="width: 100px;">Product</th>
                            <th style="width: 100px;">Select</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>--%>


        </div>

        <div>
            <div style="float: left; width: 41%;">
                <table>
                    <%--<tr>
                        <td style="text-align: right; width: 120px">
                            <asp:Label ID="lblId" runat="server" Text="Style : "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtstyle_no" runat="server" Width="182px" BackColor="White"></asp:TextBox>
                            <input type="button" id="btnCartoonSummary" value="Submit" />
                        </td>
                        <td></td>
                    </tr>--%>

                   <%-- <tr>
                        <td style="text-align: right; width: 120px">
                            <asp:Label ID="lblProductCataroy" runat="server" Text="PO:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtpo_no" runat="server" Width="183px" BackColor="White"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>--%>
                    <%--<tr>
                        <td style="text-align: right; width: 120px; height: 19px">&nbsp;</td>
                        <td style="height: 19px">&nbsp;</td>
                        <td style="height: 19px">&nbsp;</td>
                    </tr>--%>

                    <%--<tr>
                        <td style="text-align: right; width: 120px">
                            <asp:Label ID="lblBarcode" runat="server" Text="Barcode:"></asp:Label>
                        </td>
                        <td>
                            <input type="text" id="txtBarCode" style="width: 120px; background-color: white;" />
                            <input type="text" id="txtResult" style="width: 50px; background-color: #FFFF66;" readonly="readonly" />
                            <input type="text" id="hfCartoonId" style="display: none;" />
                            <input type="text" id="hfPoNo" style="display: none;" />
                            <input type="text" id="hfStyleNo" style="display: none;" />
                        </td>
                        <td></td>
                    </tr>--%>

                   <%-- <tr>
                        <td style="text-align: justify; width: 150px">&nbsp;</td>
                        <td></td>
                        <td></td>
                    </tr>--%>
                </table>
            </div>

            <div style="float: left; width: 22%;">
                <table>
                    <%--<tr>
                        <td style="text-align: right; width: 130px">
                            <asp:Label ID="Label2" runat="server" Text="Total Order Quantity: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Width="82px" BackColor="#FFFF66" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; width: 130px">
                            <asp:Label ID="Label1" runat="server" Text="Total Scan Quantity: "></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Width="82px" BackColor="#FFFF66" ReadOnly="true"></asp:TextBox>
                        </td>
                    </tr>--%>
                </table>
            </div>

            <div style="float: left; width: 30%;">

                <div>

                    <%--<input type="text" id="txtCartoonNumber" style="width: 50px; background-color: #FFFF66;" readonly="readonly" />
                    <table style="width: 100%">
                        <tr>
                            <td style="text-align: right;" colspan="3">
                                <div style="overflow-y: auto; height: 200px; width: 300px;">
                                    <table id="gvCartoonDetail" class="sinha-table">
                                        <thead>
                                            <tr>
                                                <th style="width: 46px">Cartoon Size</th>
                                                <th>Capacity</th>
                                                <th style="width: 52px">Scan Quantity</th>
                                                <th>Remaining</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; width: 337px">&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                            <td>&nbsp;
                            </td>
                        </tr>
                    </table>--%>


                </div>
            </div>

            <%--<div style="overflow-y: auto; height: 200px; width: 400px;">
                <table id="gvCartoonSummary" class="sinha-table">
                    <thead>
                        <tr>
                            <th style="display: none;">CARTOON ID</th>
                            <th style="display: none;">PO No</th>
                            <th style="display: none;">Style No</th>
                            <th style="width: 100px;">Cartoon Size</th>
                            <th style="width: 100px;">Product</th>
                            <th style="width: 100px;">Select</th>
                        </tr>
                    </thead>
                    <tbody>
                    </tbody>
                </table>
            </div>--%>
        </div>

       <%-- <input type="button" value="Save" id="btnSave" />
        <table style="width: 100%">
            <tr>
                <td style="text-align: justify;" colspan="3">
                    <asp:Label ID="lblMsgRecord" runat="server" Text="Message" Font-Bold="True" Font-Size="Small"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right;" colspan="3"></td>
            </tr>
        </table>--%>
    </fieldset>
</asp:Content>

