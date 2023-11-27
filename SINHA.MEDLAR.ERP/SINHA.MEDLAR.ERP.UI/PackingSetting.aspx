<%@ Page Title="" Language="C#" MasterPageFile="~/NewVersion.Master" AutoEventWireup="true" CodeBehind="PackingSetting.aspx.cs" Inherits="SINHA.MEDLAR.ERP.UI.PackingSetting" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
   <script type="text/javascript">  
       

       function convertToDate(_date, _format, _delimiter) {
           var formatLowerCase = _format.toLowerCase();
           var formatItems = formatLowerCase.split(_delimiter);
           var dateItems = _date.split(_delimiter);
           var monthIndex = formatItems.indexOf("mm");
           var dayIndex = formatItems.indexOf("dd");
           var yearIndex = formatItems.indexOf("yyyy");
           var month = parseInt(dateItems[monthIndex]);
           month -= 1;
           var formatedDate = new Date(dateItems[yearIndex], month, dateItems[dayIndex]);
           return formatedDate;
       }


        $(function () {
            $(".date").datepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: 'dd/mm/yy'
            });
        });
   
   

        $(document).ready(function () {
            //$.support.cors = true;
            $("#tabs").tabs();

            ///--------------------------initialization
            GetBuyer();
            GetPackingType();
            GetShipmentMode();
            GetSeason();
            GetManufacturer();
            //GetSizeInfo();
            GetCartoon();
            //GetCartoonSize();

            GetAllPackingMaster();

            ///--------------------------

            $("input[type='text']").keypress(function (event) {
                var keyCode = event.keyCode ? event.keyCode : event.which ? event.which : event.charCode;
                if (keyCode == 13) {
                    return false;
                }
                else {
                    return true;
                }
            });

        $('#btnSavePackingMaster').click(function () {
            
            var packing_master_id = $('#hf_packing_master_id').val();
            var id = 0;

            if (packing_master_id == '') {
                id = 0
            }
           else{
                id = parseFloat(packing_master_id);
            }

           //alert(packing_master_id);

           
            var po_no = $('#txtPoNo_PM').val();
            var style_no = $('#txtStyleNo_PM').val();

            var buyer_id = $('#ddlBuyer option:selected').val();
            var packing_type_id = $('#ddlPackingType option:selected').val();
            var shipment_mode_id = $('#ddlShipment option:selected').val();
            var season_id = $('#ddlSeasonName option:selected').val();
            
            var manufacturer_id = $('#ddlManufacturer option:selected').val();

            var order_quantity = $('#txtOrderQuantity_PM').val();
            var shipment_quantity = $('#txtShipmentQuantity_PM').val();
           
            var cartoon_quantity = $('#txtCartoonQuantity_PM').val();
            var c_meas = $('#txtCartoonMeasurement_PM').val();
            var delivery_date = convertToDate($('#dptDate_PM').val(), "dd/MM/yyyy", "/");
            var description = ($('#txtDescription_PM').val());

            if (po_no == '') {
                alert('PO Empty');
                return;
            }
            if (style_no == '') {
                alert('Style Empty');
                return;
            }
            if (buyer_id == '') {
                alert('Select Buyer');
                return;
            }
            if (packing_type_id == '') {
                alert('Select Packing Type');
                return;
            }
            if (shipment_mode_id == '') {
                alert('Select Shipment Mode');
                return;
            }
            if (season_id == '') {
                alert('Select Season');
                return;
            }
            if (manufacturer_id == '') {
                alert('Select Manufacturer');
                return;
            }
            if (order_quantity == '') {
                alert('Enter Order Quantity');
                return;
            }
            if (shipment_quantity == '') {
                alert('Enter Shipment Quantity');
                return;
            }
            if (cartoon_quantity == '') {
                alert('Enter Cartoon Quantity');
                return;
            }
            if (c_meas == '') {
                alert('Enter Cartoon Measurement');
                return;
            }
            if (description == '') {
                alert('Enter Description');
                return;
            }
                      
            var objPackingMaster = new PackingMaster(
              
             // parseInt(packing_master_id),
              id,
              po_no,
              style_no,
              parseInt(buyer_id),
              parseInt(packing_type_id),
              parseInt(shipment_mode_id),
              parseInt(season_id),
              parseInt(manufacturer_id),
              parseInt(order_quantity),
              parseInt(shipment_quantity),
              parseInt(cartoon_quantity),
              c_meas,
              delivery_date,
              description,
              null,
              null,
              null,
              null,
              null,
              null
             );
            // alert(JSON.stringify(objPackingMaster)); 
           // alert('Saved calling');
            SavePackingMaster(objPackingMaster);
        });

        $('#btnProductSizeInfo').click(function () {
            

            var size_id = $('#hf_size_id').val();
            var id = 0;

            if (size_id == '') {
                id = 0
            }
            else {
                id = parseFloat(size_id);
            }
            var packing_master_id = $('#hf_packing_master_id').val();
            //var size_id = 0;
          //  alert(id);
            var size_name = $('#txtSizeName_ps').val();
            var po_no = $('#txtPoNo_ps').val();
            var style_no = $('#txtStyleNo_ps').val();
            var barcode = $('#txtBarcodeNo_ps').val();
            var quantity = $('#txtOrderQuantity_ps').val();

            quantity = quantity == '' ? 0 : parseInt(quantity);
            packing_master_id = packing_master_id == '' ? 0 : parseFloat(packing_master_id);

            if (po_no == '') {
                alert('PO Empty');
                return;
            }
            if (style_no == '') {
                alert('Style Empty');
                return;
            }
            if (size_name == '') {
                alert('Enter Size ');
                return;
            }
            if (barcode == '') {
                alert('Enter Barcode');
                return;
            }
            if (quantity == '') {
                alert('Enter Quantity');
                return;
            }

            
            var objProductSizeInfo = new ProductSizeInfo(
              id,
              packing_master_id,
              size_name,
              po_no,
              style_no,
              barcode,
              quantity,
              null,
              null,
              null,
              null
             );
          
            SaveProductSizeInfo(objProductSizeInfo);
        });
        $('#btnCartoonDetail').click(function () {
            // var cartoon_detail_id = 0;
            var cartoon_detail_id = $('#hf_cartoon_detail_id').val();
            var id = 0;
            if (cartoon_detail_id == '') {
                id = 0
            }
            else {
                id = parseFloat(cartoon_detail_id);
            }

            var packing_master_id = $('#hf_packing_master_id').val();
           
           // alert(packing_master_id);
            var cartoon_id = $('#ddlCartoon').val();
            var po_no = $('#txtPoNo_Car').val();
            var style_no = $('#txtStyleNo_Car').val();
            var cartoon_quantity = $('#txtCartoonQty_CartoonDetail').val();
            var product_quantity = $('#txtProductQty_CartoonDetail').val();
            var product_quantity_per_cartoon = $('#txtProductQtyPerCartoon_CartoonDetail').val();

            cartoon_detail_id = cartoon_detail_id == '' ? 0 : parseInt(cartoon_detail_id);
            packing_master_id = packing_master_id == '' ? 0 : parseFloat(packing_master_id);
            cartoon_id = cartoon_id == '' ? 0 : parseInt(cartoon_id);
            cartoon_quantity = cartoon_quantity == '' ? 0 : parseInt(cartoon_quantity);
            product_quantity = product_quantity == '' ? 0 : parseInt(product_quantity);
            product_quantity_per_cartoon = product_quantity_per_cartoon == '' ? 0 : parseInt(product_quantity_per_cartoon);

            if (cartoon_id == '') {
                alert('Select Cartoon');
                return;
            }

            if (po_no == '') {
                alert('PO Empty');
                return;
            }
            if (style_no == '') {
                alert('Style Empty');
                return;
            }
           
            if (cartoon_quantity == '') {
                alert('Enter Cartoon Quantity');
                return;
            }
            if (product_quantity == '') {
                alert('Enter Product Quantity');
                return;
            }
            if (product_quantity_per_cartoon == '') {
                alert('Enter Product Quantity Per Cartoon');
                return;
            }

            var objCartoonDetails = new CartoonDetails(
                     id,
                     packing_master_id,
                     cartoon_id,
                     po_no,
                     style_no,
                     cartoon_quantity,
                     product_quantity,
                     product_quantity_per_cartoon,
                     null,
                     null,
                     null,
                     null
             );
            SaveCartoonDetails(objCartoonDetails);
        });

        $('#btnCartoonMapping').click(function () {
           
            var mapping_id = $('#hf_mapping_id').val();
            var id = 0;

            if (cartoon_detail_id == '') {
                id = 0
            }
            else {
                id = parseFloat(mapping_id);
            }
            var packing_master_id = $('#hf_packing_master_id').val();
            var po_no = $('#txtPoNo_PCM').val();
            var style_no = $('#txtStyleNo_PCM').val();
            var size_id = $('#ddlSizeName').val();
            var cartoon_detail_id = $('#ddlCartoonSize').val(); 
            var quantity = $('#txtProductQuantityPerCartoon').val();

            mapping_id = mapping_id == '' ? 0 : parseInt(mapping_id);
            packing_master_id = packing_master_id == '' ? 0 : parseInt(packing_master_id);
            size_id = size_id == '' ? 0 : parseInt(size_id);
            cartoon_detail_id = cartoon_detail_id == '' ? 0 : parseInt(cartoon_detail_id);
            quantity = quantity == '' ? 0 : parseInt(quantity);
          
            
            if (po_no == '') {
                alert('PO Empty');
                return;
            }
            if (style_no == '') {
                alert('Style Empty');
                return;
            }
           
            if (size_id == '') {
                alert('Select Size');
                return;
            }
            if (cartoon_detail_id == '') {
                alert('Select Cartoon');
                return;
            }
            if (quantity == '') {
                alert('Enter Quantity');
                return;
            }
           
            var objCartoonMapping = new CartoonMapping(
                     id,
                     packing_master_id,
                     po_no,
                     style_no,
                     size_id,
                     cartoon_detail_id,
                     quantity,
                     null,
                     null,
                     null,
                     null
             );
            SaveCartoonMapping(objCartoonMapping);
        });

    });

    function GetBuyer() {
        $("#ddlBuyer").empty();
        $("#ddlBuyer").append($("<option></option>").val("").html("Select Buyer Name"));
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetBuyer",
            data: JSON.stringify({ }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                   
                    $("#ddlBuyer").append($("<option></option>").val(value.BUYER_ID).html(value.BUYER_SHORT_NAME));
                     
                });
            },
            error: function (data) {
                // alert("error found");
                alert("GetBuyer");
            }
        });
    }

    function GetPackingType() {
        $("#ddlPackingType").empty();
        $("#ddlPackingType").append($("<option></option>").val("").html("Select Packing Type"));
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetPackingType",
            data: JSON.stringify({}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                    $("#ddlPackingType").append($("<option></option>").val(value.PACKING_TYPE_ID).html(value.PACKING_TYPE_NAME));
                });
            },
            error: function (data) {
                //alert("error found");
                alert("GetPackingType");
            }
        });
    }

    function GetShipmentMode() {
        $("#ddlShipment").empty();
        $("#ddlShipment").append($("<option></option>").val("").html("Select Shipment Mode"));
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetShipmentMode",
            data: JSON.stringify({}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                    $("#ddlShipment").append($("<option></option>").val(value.SHIPMENT_TYPE_ID).html(value.SHIPMENT_TYPE_NAME));
                });
            },
            error: function (data) {
                // alert("error found");
                alert("----------error---------");
            }
        });
    }
    function GetSeason() {
        $("#ddlSeasonName").empty();
        $("#ddlSeasonName").append($("<option></option>").val("").html("Select Season"));
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetSeason",
            data: JSON.stringify({}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                    $("#ddlSeasonName").append($("<option></option>").val(value.SEASON_ID).html(value.SEASON_NAME));
                });
            },
            error: function (data) {
                //alert("error found");
                alert("GetSeason");
            }
        });
    }
    function GetManufacturer() {
        $("#ddlManufacturer").empty();
        $("#ddlManufacturer").append($("<option></option>").val("").html("Select Manufacturer"));
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetManufacturer",
            data: JSON.stringify({}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                    $("#ddlManufacturer").append($("<option></option>").val(value.MANUFACTURE_ID).html(value.MANUFACTURE_NAME));
                });
            },
            error: function (data) {
                //alert("error found");
                alert("GetManufacturer");
            }
        });
    }
    function GetSizeInfo(po_no, style_no, packing_master_id) {
        $("#ddlSizeName").empty();
        $("#ddlSizeName").append($("<option></option>").val("").html("Select Size"));
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetSizeInfo",
            data: JSON.stringify({ po_no: po_no, style_no: style_no, packing_master_id: packing_master_id }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                    $("#ddlSizeName").append($("<option></option>").val(value.size_id).html(value.size_name));
                });
            },
            error: function (data) {
                //alert("error found");
                alert("GetSizeInfo");
            }
        });
    }
    function GetCartoonSize(po_no, style_no, packing_master_id) {

        $("#ddlCartoonSize").empty();
        $("#ddlCartoonSize").append($("<option></option>").val("").html("Select Cartoon Size"));
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetCartoonSize",
            data: JSON.stringify({ po_no: po_no, style_no: style_no, packing_master_id: packing_master_id }),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                    $("#ddlCartoonSize").append($("<option></option>").val(value.cartoon_detail_id).html(value.cartoon_size));
                });
            },
            error: function (data) {
                //alert("error found");
                alert("GetCartoonSize");
            }
        });
    }
       //changed
    function GetCartoon() {
        $("#ddlCartoon").empty();
        $("#ddlCartoon").append($("<option></option>").val("").html("Select Cartoon"));
        $.ajax({

            type: "POST",
            url: "PackingSetting.aspx/GetCartoon",
            data: JSON.stringify({}),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (Result) {
                Result = Result.d;
                $.each(Result, function (key, value) {
                    $("#ddlCartoon").append($("<option></option>").val(value.CartoonID).html(value.CartoonSize));
                });
            },
            error: function (data) {
                //   alert("error found");
                alert("GetCartoonDetails");
            }
        });
    }


    function clear() {

        $('#txtPoNo_PM').val('');
        $('#style_no').val('');
        $('#ddlBuyer').val('');
        $('#ddlPackingType').val('');

        $('#ddlShipment').val('');
        $('#ddlSeasonName').val('');

        $('#txtOrderQuantity_PM').val('');
        $('#txtShipmentQuantity_PM').val('');
        $('#txtCartoonQuantity_PM').val('');

        $('#txtCartoonMeasurement_PM').val('');
        $('#txtDescription_PM').val('');
        $('#dptDate_PM').val('');

    }

    function clearSizeInfo() {
        $('#hf_size_id').val('');
        $('#txtSizeName_ps').val('');
        $('#txtBarcodeNo_ps').val('');
        $('#txtOrderQuantity_ps').val('');
    }

    function clearCartoonDetail() {

        $('#hf_cartoon_detail_id').val('');
        $('#ddlCartoon').val('');
        $('#txtCartoonQty_CartoonDetail').val('');
        $('#txtProductQty_CartoonDetail').val('');
        $('#txtProductQtyPerCartoon_CartoonDetail').val('');
    }
   
    function clearMapping() {
       
        $('#ddlSizeName').val('');
        $('#ddlCartoonSize').val('');
        $('#txtProductQuantityPerCartoon').val('');
    }

    function Select(element) {

        var tds = $(element).closest("tr");
        var packing_master_id = tds.find("td:eq(0)").text();
        var po_no = tds.find("td:eq(1)").text();
        var style_no = tds.find("td:eq(2)").text();

        var order_qty = tds.find("td:eq(8)").text();
        var shipment_qty = tds.find("td:eq(9)").text();
        var cartoon_qty = tds.find("td:eq(10)").text();
        var c_meas = tds.find("td:eq(11)").text();
        var delivery_date = tds.find("td:eq(12)").text();
        var description = tds.find("td:eq(13)").text();

        //New
        var buyer_id = tds.find("td:eq(14)").text();
        var packing_type_id = tds.find("td:eq(15)").text();
        var shipment_type_id = tds.find("td:eq(16)").text();
        var season_id = tds.find("td:eq(17)").text();
        var MANUFACTURE_id = tds.find("td:eq(18)").text();

        //--------------------------------------------------
        ////Tab-1
        $('#hf_packing_master_id').val(packing_master_id);
       // alert(packing_master_id);
        $('#txtPoNo_PM').val(po_no);
        $('#txtStyleNo_PM').val(style_no);


        $('#ddlBuyer').val(buyer_id);
        $('#ddlPackingType').val(packing_type_id);
        $('#ddlShipment').val(shipment_type_id);
        $('#ddlSeasonName').val(season_id);
        $('#ddlManufacturer').val(MANUFACTURE_id);

        
        $('#txtOrderQuantity_PM').val(order_qty);
        $('#txtShipmentQuantity_PM').val(shipment_qty);
        $('#txtCartoonQuantity_PM').val(cartoon_qty);

        $('#txtCartoonMeasurement_PM').val(c_meas);
        $('#dptDate_PM').val(delivery_date);
        $('#txtDescription_PM').val(description);
       
        //Tab-2
        $('#txtPoNo_ps').val(po_no);
        $('#txtStyleNo_ps').val(style_no);
        $('#hf_packing_master_id').val(packing_master_id);
        GetProductSizeInfo(po_no, style_no, packing_master_id);

        //Tab-3
        $('#txtPoNo_Car').val(po_no);
        $('#txtStyleNo_Car').val(style_no);
        $('#hf_packing_master_id').val(packing_master_id);
        GetCartoonDetailsInfo(po_no, style_no, packing_master_id);

        //Tab-4
        $('#txtPoNo_PCM').val(po_no);
        $('#txtStyleNo_PCM').val(style_no);
        $('#hf_packing_master_id').val(packing_master_id);
        GetCartoonSize(po_no, style_no, packing_master_id);

        GetSizeInfo(po_no, style_no, packing_master_id);

        GetCartoonMappingInfo(po_no, style_no, packing_master_id);
    }

    function SelectSizeInfo(element) {

        var tds = $(element).closest("tr");
        var size_id = tds.find("td:eq(0)").text();
        var size_name = tds.find("td:eq(3)").text();
        var barcode = tds.find("td:eq(4)").text();
        var quantity = tds.find("td:eq(5)").text();
       
        $('#txtSizeName_ps').val('');
        $('#txtBarcodeNo_ps').val('');
        $('#txtOrderQuantity_ps').val('');

        $('#hf_size_id').val(size_id);
        $('#txtSizeName_ps').val(size_name);
        $('#txtBarcodeNo_ps').val(barcode);
        $('#txtOrderQuantity_ps').val(quantity);
        
    }

   
    function SelectCartoonInfo(element) {
        var tds = $(element).closest("tr");
        var cartoon_detail_id = tds.find("td:eq(0)").text();
        var cartoon_id = tds.find("td:eq(1)").text();
        var cartoon_size = tds.find("td:eq(2)").text();
        var cartoon_quantity = tds.find("td:eq(3)").text();
        var product_quantity = tds.find("td:eq(4)").text();
        var product_quantity_per_cartoon = tds.find("td:eq(5)").text();
        var product_quantity_per_cartoon = tds.find("td:eq(5)").text();
        
        $('#txtCartoonQty_CartoonDetail').val('');
        $('#txtProductQty_CartoonDetail').val('');
        $('#txtProductQtyPerCartoon_CartoonDetail').val('');

        $('#hf_cartoon_detail_id').val(cartoon_detail_id);
        $('#ddlCartoon').val(cartoon_id);
        $('#txtCartoonQty_CartoonDetail').val(cartoon_quantity);
        $('#txtProductQty_CartoonDetail').val(product_quantity);
        $('#txtProductQtyPerCartoon_CartoonDetail').val(product_quantity_per_cartoon);
    }

   
    function SelectCartoonMapping(element) {
        var tds = $(element).closest("tr");
        var mapping_id = tds.find("td:eq(0)").text();
        var cartoon_detail_id = tds.find("td:eq(1)").text();
        var size_id = tds.find("td:eq(2)").text();
        var size_name = tds.find("td:eq(3)").text();
        var cartoon_size = tds.find("td:eq(4)").text();
        var quantity = tds.find("td:eq(5)").text();
       

        $('#ddlCartoonSize').val('');
        $('#ddlSizeName').val('');
        $('#txtProductQuantityPerCartoon').val('');

        $('#hf_mapping_id').val(mapping_id);
        $('#ddlCartoonSize').val(cartoon_detail_id);
        $('#ddlSizeName').val(size_id);
        $('#txtProductQuantityPerCartoon').val(quantity);
        
    }

    function GetAllPackingMaster() {

        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetAllPackingMaster",
            //data: JSON.stringify({ model: objPackingMaster }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: populatePackMasterGrid,
            failure: function (response) {
                alert('error');
            }
        });
    }

    function GetPackingMaster(objPackingMaster) {
     
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetPackingMaster",
            data: JSON.stringify({ model: objPackingMaster }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: populatePackMasterGrid,
            failure: function (response) {
                alert('error');
            }
        });
    }

    function populatePackMasterGrid(result) {
        
        $("#gvPackingMaster tbody").empty();

        var rows = '';
        var action = '<a href="#" OnClick="Select(this);">Click</a>';

        for (i = 0; i < result.d.length; i++) {
            rows = rows +
            "<tr>" +
            "<td style='display:none;'>" + result.d[i].packing_master_id + "</td>" + 
            "<td>" + result.d[i].po_no + "</td>" +
            "<td>" + result.d[i].style_no + "</td>" +
            "<td>" + result.d[i].buyer_short_name + "</td>" +
            "<td>" + result.d[i].packing_type_name + "</td>" +
            "<td>" + result.d[i].shipment_type_name + "</td>" +
            "<td>" + result.d[i].season_name + "</td>" +
            "<td>" + result.d[i].MANUFACTURE_NAME + "</td>" +
            "<td>" + result.d[i].order_quantity + "</td>" +
            "<td>" + result.d[i].shipment_quantity + "</td>" +
            "<td>" + result.d[i].cartoon_quantity + "</td>" +
            "<td>" + result.d[i].c_meas + "</td>" +
            "<td>" + result.d[i].delivery_date_formate + "</td>" +
            "<td>" + result.d[i].description + "</td>" +

            "<td style='display:none;'>" + result.d[i].buyer_id + "</td>" + //14
            "<td style='display:none;'>" + result.d[i].packing_type_id + "</td>" +
            "<td style='display:none;'>" + result.d[i].shipment_mode_id + "</td>" +
            "<td style='display:none;'>" + result.d[i].season_id + "</td>" +
            "<td style='display:none;'>" + result.d[i].manufacturer_id + "</td>" +
            "<td>" + action + "</td>" +
            "</tr>";
        }
        $("#gvPackingMaster tbody").append(rows);
    }

    function GetProductSizeInfo(po_no, style_no, packing_master_id) {
        
        var action = '<a href="#" OnClick="SelectSizeInfo(this);">Click</a>';

        $("#gvProductSizeInfo tbody").empty();
        var rows = '';

        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetProductSizeInfo",
            data: JSON.stringify({ po_no: po_no, style_no: style_no, packing_master_id: packing_master_id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {

                $("#gvProductSizeInfo tbody").empty();

                for (i = 0; i < result.d.length; i++) {

                    rows = rows + "<tr><td style='display:none;'>" +
                    result.d[i].size_id + "</td> <td>" +
                    result.d[i].po_no + "</td> <td>" +
                    result.d[i].style_no + "</td> <td>" +
                    result.d[i].size_name + "</td> <td>" +
                    result.d[i].barcode + "</td> <td>" +
                    result.d[i].quantity + "</td> <td>" +
                    action + "</td></tr>";
                }
                $("#gvProductSizeInfo tbody").append(rows);
            },
            failure: function (response) {
                alert('error');
            }
        });
    }
    function GetCartoonDetailsInfo(po_no, style_no,packing_master_id) {

        var action = '<a href="#" OnClick="SelectCartoonInfo(this);">Click</a>';
        $("#gvCartoonDetail tbody").empty();
        var rows = '';
        var rows1 = '';

        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetCartoonDetailsInfo",
            data: JSON.stringify({ po_no: po_no, style_no: style_no, packing_master_id: packing_master_id }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                $("#gvCartoonDetail tbody").empty();
                for (i = 0; i < result.d.length; i++) {
                    rows = rows +
                    "<tr>" +
                        "<td style='display:none;'>" + result.d[i].cartoon_detail_id + "</td>" +
                         "<td style='display:none;'>" + result.d[i].cartoon_id + "</td>" +
                    
                        "<td>" + result.d[i].cartoon_size + "</td>" +
                        "<td>" + result.d[i].cartoon_quantity + "</td>" +
                        "<td>" + result.d[i].product_quantity + "</td>" +
                        "<td>" + result.d[i].product_quantity_per_cartoon + "</td>" +
                        "<td>" + action + "</td>" +
                    "</tr>";
                }
                $("#gvCartoonDetail tbody").append(rows);             
            },
            failure: function (response) {
                alert('error');
            }
        });
    }
    function GetCartoonMappingInfo(po_no, style_no) {

        var action = '<a href="#" OnClick="SelectCartoonMapping(this);">Click</a>';
        $("#gvCartoonMapping tbody").empty();
        var rows = '';
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/GetCartoonMappingInfo",
            data: JSON.stringify({ po_no: po_no, style_no: style_no }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                $("#gvCartoonMapping tbody").empty();
                for (i = 0; i < result.d.length; i++) {
                rows = rows +    "<tr>" +
                        "<td style='display:none;'>" + result.d[i].mapping_id + "</td>" +
                         "<td style='display:none;'>" + result.d[i].cartoon_detail_id + "</td>" +
                         "<td style='display:none;'>" + result.d[i].size_id + "</td>" +

                        "<td>" + result.d[i].size_name + "</td>" +
                        "<td>" + result.d[i].cartoon_size + "</td>" +
                        "<td>" + result.d[i].quantity + "</td>" +
                        "<td>" + action + "</td>" +
                    "</tr>";
                }
                $("#gvCartoonMapping tbody").append(rows);
            },
            failure: function (response) {
                alert('error');
            }
        });
    }

       
    function SavePackingMaster(objPackingMaster) {

        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/SavePackingMaster",      
            data: JSON.stringify({ model: objPackingMaster }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                alert(result.d);
                clear();
                GetPackingMaster(objPackingMaster);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    function SaveProductSizeInfo(objProductSizeInfo) {

        //alert(JSON.stringify(objProductSizeInfo));
        
        var packing_master_id = $('#hf_packing_master_id').val();
        
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/SaveProductSizeInfo",
            data: JSON.stringify({ model: objProductSizeInfo }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                alert(result.d);
                clearSizeInfo();
                GetProductSizeInfo(objProductSizeInfo.po_no, objProductSizeInfo.style_no, packing_master_id);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

    function SaveCartoonMapping(objCartoonMapping) {
        var packing_master_id = $('#hf_packing_master_id').val();
        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/SaveCartoonMapping",
            data: JSON.stringify({ model: objCartoonMapping }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                alert(result.d);
                clearMapping();
                GetCartoonMappingInfo(objCartoonMapping.po_no, objCartoonMapping.style_no, packing_master_id);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }
    function SaveCartoonDetails(objCartoonDetails) {

      var  packing_master_id=  $('#hf_packing_master_id').val();

        $.ajax({
            type: "POST",
            url: "PackingSetting.aspx/SaveCartoonDetails",
            data: JSON.stringify({ model: objCartoonDetails }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: false,
            success: function (result) {
                alert(result.d);
                clearCartoonDetail();
                GetCartoonDetailsInfo(objCartoonDetails.po_no, objCartoonDetails.style_no, packing_master_id);
            },
            failure: function (response) {
                alert(response.d);
            }
        });
    }

 
    class PackingMaster {
        constructor
            (
              packing_master_id,
              po_no,
              style_no,
              buyer_id,
              packing_type_id,
              shipment_mode_id,
              season_id,
              manufacturer_id,
              order_quantity,
              shipment_quantity,
              cartoon_quantity,
              c_meas,
              delivery_date,
              description,
              create_by,
              create_date,
              update_by,
              update_date,
              head_office_id,
              branch_office_id
              
            ) {
            this.packing_master_id = packing_master_id;
            this.po_no = po_no;
            this.style_no = style_no;
            this.buyer_id = buyer_id;
            this.packing_type_id = packing_type_id;
            this.shipment_mode_id = shipment_mode_id;
            this.season_id = season_id;
            this.manufacturer_id = manufacturer_id;
            this.order_quantity = order_quantity;
            this.shipment_quantity = shipment_quantity;
            this.cartoon_quantity = cartoon_quantity;
            this.c_meas = c_meas;
            this.delivery_date = delivery_date;
            this.description = description;
            this.create_by = create_by;
            this.create_date = create_date;
            this.update_by = update_by;
            this.update_date = update_date;
            this.head_office_id = head_office_id;
            this.branch_office_id = branch_office_id;

         
        }
    }


    class ProductSizeInfo {
        constructor(
                     size_id,
                     packing_master_id,
                     size_name,
                     po_no,
                     style_no,
                     barcode,
                     quantity,
                     create_by,
                     create_date,
                     update_by,
                     update_date
                
         )
        {
            this.size_id = size_id;
            this.packing_master_id = packing_master_id;
            this.size_name = size_name;
            this.po_no = po_no;
            this.style_no = style_no;
            this.barcode = barcode;
            this.quantity = quantity;
            this.create_by = create_by;
            this.create_date = create_date;
            this.update_by = update_by;
            this.update_date = update_date;
        }
    }
   
    class CartoonDetails {
        constructor(
                     cartoon_detail_id,
                     packing_master_id,
                     cartoon_id,
                     po_no,
                     style_no,
                     cartoon_quantity,
                     product_quantity,
                     product_quantity_per_cartoon,
                     create_by,
                     create_date,
                     update_by,
                     update_date
                
         )
        {
           
            this.cartoon_detail_id = cartoon_detail_id;
            this.packing_master_id = packing_master_id;
            this.cartoon_id = cartoon_id;
            this.po_no = po_no;
            this.style_no = style_no;
            this.cartoon_quantity = cartoon_quantity;
            this.product_quantity = product_quantity;
            this.product_quantity_per_cartoon = product_quantity_per_cartoon,
            this.create_by = create_by;
            this.create_date = create_date;
            this.update_by = update_by;
            this.update_date = update_date;
        }
    }
    class CartoonMapping {
        constructor(
                     mapping_id,
                     packing_master_id,
                     po_no,
                     style_no,
                     size_id,
                     cartoon_detail_id,
                     quantity,
                     create_by,
                     create_date,
                     update_by,
                     update_date
                
         )
                     {   
            this.mapping_id = mapping_id;
            this.packing_master_id = packing_master_id;
            this.po_no = po_no;
            this.style_no = style_no;
            this.size_id = size_id;
            this.cartoon_detail_id = cartoon_detail_id;
            this.quantity = quantity,
            this.create_by = create_by;
            this.create_date = create_date;
            this.update_by = update_by;
            this.update_date = update_date;
        }
    }

   
   </script>
             
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <div id="tabs">
        <ul>
            <li id="tb-1"><a href="#tab-1"><span>Packing Basic</span></a></li>
            <li id="tb-2"><a href="#tab-2"><span>Prosuct Size Info</span></a></li>
            <li id="tb-3"><a href="#tab-3"><span>Cartoon Details</span></a></li>
            <li id="tb-4"><a href="#tab-4"><span>Product Cartoon Mapping</span></a></li>
        </ul>
        <div id="tab-1">

                      
            <div class="form-horizontal container">
                    <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">PO No</label>
                        <div class="col-md-3">
                            <input type="text" id="txtPoNo_PM" class="form-control" />
                        </div>

                        <label class="col-md-2 label-control" style="text-align: right;">Style No</label>
                        <div class="col-md-3">
                            <input type="text" id="txtStyleNo_PM" class="form-control input-sm" />
                        </div>
                    </div>
                </div>


                 <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">Buyer</label>
                        <div class="col-md-3 label-control">
                            <select class="form-control" id="ddlBuyer" name="Cartoon Size">
                               
                            </select>
                        </div>

                         <label class="col-md-2 label-control" style="text-align: right;">Packing Type</label>
                        <div class="col-md-3 label-control">
                            <select class="form-control" id="ddlPackingType" name="Size Name">
                            </select>
                        </div>

                       
                    </div>
                </div>

                  <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">Shipment Mode</label>
                        <div class="col-md-3 label-control">
                            <select class="form-control" id="ddlShipment" name="Shipment mode">
                            </select>
                        </div>

                         <label class="col-md-2 label-control" style="text-align: right;">Season Name</label>
                        <div class="col-md-3 label-control">
                            <select class="form-control" id="ddlSeasonName" name="Season">
                            </select>
                        </div>
                    </div>
                     </div>

                 <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">Manufacturer</label>
                        <div class="col-md-3 label-control">
                            <select class="form-control" id="ddlManufacturer" name="Manufacturer">
                            </select>
                        </div>

                       <label class="col-md-2 label-control" style="text-align: right;">Order Quantity</label>
                        <div class="col-md-3">
                            <input type="text" id="txtOrderQuantity_PM" class="form-control" />
                        </div>
                    </div>
                     </div>

                <div class="row">
                    <div class="form-group">
                       <label class="col-md-2 label-control" style="text-align: right;">Shipment Quantity</label>
                        <div class="col-md-3">
                            <input type="text" id="txtShipmentQuantity_PM" class="form-control" />
                        </div>

                       <label class="col-md-2 label-control" style="text-align: right;">Cartoon Quantity</label>
                        <div class="col-md-3">
                            <input type="text" id="txtCartoonQuantity_PM" class="form-control" />
                        </div>
                    </div>
                     </div>

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">Cartoon Measurement</label>
                        <div class="col-md-3">
                            <input type="text" id="txtCartoonMeasurement_PM" class="form-control" />
                        </div>

                        <label class="col-md-2 label-control" style="text-align: right;">Description</label>
                        <div class="col-md-3">
                            <input type="text" id="txtDescription_PM" class="form-control" />
                        </div>
                    </div>
                </div>
                 <div class="row">
                    <div class="form-group">
                       <label class="col-md-2 label-control" style="text-align: right;" >date</label>
                        <div class="col-md-3">
                        <input type="text" id="dptDate_PM" class="form-control date done"  />
                     </div>
                  </div>
                 </div>
                

        <div class="row">
        <div class="form-group">
            <div class="col-md-2"></div>
          <div class="col-md-3">
                <input type="button" value="Save" id="btnSavePackingMaster" style="text-align:center;" class="btn btn-primary"/>
          </div>
       </div>
       </div>

        <div class="row">
        <div class="form-group">
          <div class="col-md-12">
            <div style="overflow-y:auto; height:300px; width:83%;">
            <table id="gvPackingMaster" class="sinha-table">
                <thead>
                    <tr>
                        <th style="display:none;">Packing Master Id</th>
                        <th style="width:100px;">PO No</th>
                        <th style="width:100px;">Style No</th>
                        <th style="width:100px;">Buyer Name</th>
                        <th style="width:100px;">Packing Type</th>
                        <th style="width:100px;">Shipment Mode</th>
                        <th style="width:100px;">Season Name</th>
                        <th style="width:100px;">Manufacturer Name</th>
                        <th style="width:100px;">Order Quantity</th>
                        <th style="width:100px;">Shipment Quantity</th>
                        <th style="width:100px;">Cartoon Quantity</th>
                        <th style="width:100px;">Cartoon Measurement</th>
                        <th style="width:100px;">Delivary Date</th>
                        <th style="width:100px;">Description</th>
                        <th style="display:none;"></th> 
                        <th style="display:none;"></th>
                        <th style="display:none;"></th>
                        <th style="display:none;"></th>
                        <th style="display:none;"></th>
                        <th style="width:100px;">Select</th>

                        
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

        <div id="tab-2">
                    <%--<h1>Prosuct Size Info (prod_size_info)</h1>--%>
                    <div class="form-horizontal container">
                        <div class="row">
                            <div class="form-group">
                                <label class="col-md-2 label-control" style="text-align: right;">PO No</label>
                                <div class="col-md-3">
                                    <input type="text" id="txtPoNo_ps" class="form-control" readonly="readonly" />
                                </div>

                                <label class="col-md-2 label-control" style="text-align: right;">Style No</label>
                                <div class="col-md-3">
                                    <input type="text" id="txtStyleNo_ps" class="form-control" readonly="readonly"/>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="form-group">
                                <label class="col-md-2 label-control" style="text-align: right;">Size Name</label>
                                <div class="col-md-3">
                                    <input type="text" id="txtSizeName_ps" class="form-control" />
                                </div>

                                <label class="col-md-2 label-control" style="text-align: right;">Barcode Number</label>
                                <div class="col-md-3">
                                    <input type="text" id="txtBarcodeNo_ps" class="form-control" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="form-group">
                                <label class="col-md-2 label-control" style="text-align: right;">Order Quantity</label>
                                <div class="col-md-3">
                                    <input type="text" id="txtOrderQuantity_ps" class="form-control" />
                                    
                                </div>
                            </div>
                        </div>
                <div class="row">
                    <div class="form-group">
                        <div class="col-md-2"></div>
                      <div class="col-md-3">
                            <input type="button" value="Save" id="btnProductSizeInfo" style="text-align:center;" class="btn btn-primary" />
                      </div>
                   </div>
               </div>

             <div class="row">
                <div class="form-group">
                  <div class="col-md-12">
                    <div style="overflow-y:auto; height:200px; width:83%;">
                        <table id="gvProductSizeInfo" class="sinha-table">
    
                            <thead>
                                <tr>
                                    <th style="display:none;">Size Id</th>
                                    <th style="width:100px;">PO No</th>
                                    <th style="width:100px;">Style No</th>
                                    <th style="width:100px;">Size Name</th>
                                    <th style="width:100px;">Barcode</th>
                                    <th style="width:100px;">Quantity</th>
                                    <th style="width:100px;">Select</th>
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
        
        <div id="tab-3">
           <%--<h1>Cartoon Details (prod_cartoon_detail)</h1>--%>

            <div class="form-horizontal container">
                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">PO No</label>
                        <div class="col-md-3">
                            <input type="text" id="txtPoNo_Car" class="form-control" readonly="readonly"/>
                        </div>

                        <label class="col-md-2 label-control" style="text-align: right;">Style No</label>
                        <div class="col-md-3">
                            <input type="text" id="txtStyleNo_Car" class="form-control" readonly="readonly"/>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group">
                       <label class="col-md-2 label-control" style="text-align: right;">Cartoon</label>
                        <div class="col-md-3 label-control">
                            <select class="form-control" id="ddlCartoon" name="Cartoon">
                            </select>
                        </div>

                        <label class="col-md-2 label-control" style="text-align: right;">Cartoon Quantity</label>
                        <div class="col-md-3">
                            <input type="text" id="txtCartoonQty_CartoonDetail" class="form-control" />
                        </div>
                    </div>
                </div>

                

                <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">Product Quantity</label>
                        <div class="col-md-3">
                            <input type="text" id="txtProductQty_CartoonDetail" class="form-control" />
                        </div>

                        <label class="col-md-2 label-control" style="text-align: right;">Product Quantity per Cartoon</label>
                        <div class="col-md-3">
                            <input type="text" id="txtProductQtyPerCartoon_CartoonDetail" class="form-control" />
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="form-group">
                        <div class="col-md-2"></div>
                      <div class="col-md-3">
                            <input type="button" value="Save" id="btnCartoonDetail" style="text-align:center;" class="btn btn-primary"/>
                      </div>
                    </div>
                </div>   
                
                
                <div class="row">
                <div class="form-group">
                  <div class="col-md-12">
            <div style="overflow-y:auto; height:200px; width:83%;"> 
            <table id="gvCartoonDetail" class="sinha-table">
                <thead>
                    <tr>
                        <th style="display:none;">CARTOON DETAIL ID</th>
                        <th style="width:100px;">Cartoon Size</th>
                        <th style="width:100px;">Cartoon Quantity</th>
                        <th style="width:100px;">Product Quantity</th>
                        <th style="width:100px;">Product Quantity Per Cartoon</th>
                        <th style="width:100px;">Select</th>
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
        <div id="tab-4">
         <%--  <h1>Product Cartoon Mapping (prod_product_cartoon_mapping)</h1>--%>
            <div class="form-horizontal container">
                    <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">PO No</label>
                        <div class="col-md-3">
                            <input type="text" id="txtPoNo_PCM" class="form-control" readonly="readonly"/>
                        </div>

                        <label class="col-md-2 label-control" style="text-align: right;">Style No</label>
                        <div class="col-md-3">
                            <input type="text" id="txtStyleNo_PCM" class="form-control" readonly="readonly"/>
                        </div>
                    </div>
                </div>

           


                 <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">Cartoon Size</label>
                        <div class="col-md-3 label-control">
                            <%--<select class="form-control" id="ddlCartoonSize" name="Cartoon Size">
                            </select>--%>
                            <select class="form-control" id="ddlCartoonSize" name="Cartoon">
                            </select>
                        </div>

                         <label class="col-md-2 label-control" style="text-align: right;">Product Size</label>
                        <div class="col-md-3 label-control">
                            <select class="form-control" id="ddlSizeName" name="Size Name">
                            </select>
                        </div>

                       
                    </div>
                </div>

                 <div class="row">
                    <div class="form-group">
                        <label class="col-md-2 label-control" style="text-align: right;">Quantity
                        </label>
                        <div class="col-md-3">
                            <input type="text" id="txtProductQuantityPerCartoon" class="form-control" />
                        </div>

                    </div>
                </div>

                 <div class="row">
                    <div class="form-group">
                        <div class="col-md-2"></div>
                      <div class="col-md-3">
                            <input type="button" value="Save" id="btnCartoonMapping" style="text-align:center;" class="btn btn-primary" />
                      </div>
                   </div>
                </div>  
                
                <div class="row">
                <div class="form-group">
                  <div class="col-md-12">
            <div style="overflow-y:auto; height:200px; width:83%;"> 
            <table id="gvCartoonMapping" class="sinha-table">
    
                <thead>
                    <tr>
                        <th style="display:none;">Mapping Id</th>
                        <th style="display:none;">cartoon detail Id</th>
                        <th style="display:none;">Size Id</th>
                        <th style="width:100px;">Size Name</th>
                        <th style="width:100px;">Cartoon Size</th>
                        <th style="width:100px;">Quantity</th>                      
                        <th style="width:100px;">Select</th>
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
             
            
            <%--<div class="row">
                <div class="form-group">
                  <div class="col-md-12">
            <div style="overflow-y:auto; height:200px; width:83%;"> 
            <table id="gvCartoonMapping" class="sinha-table">
    
                <thead>
                    <tr>
                        <th style="display:none;">Mapping Id</th>
                        <th style="display:none;">cartoon detail Id</th>
                        <th style="display:none;">Size Id</th>
                        <th style="width:100px;">Size Name</th>
                        <th style="width:100px;">Cartoon Size</th>
                        <th style="width:100px;">Quantity</th>                      
                        <th style="width:100px;">Select</th>
                    </tr>
                </thead>
                <tbody>
                </tbody>
            </table>
        </div>
       </div>
      </div>
     </div>--%>






        </div> 
   </div>
   <input type="text" id="hf_packing_master_id" style="display:none;" />
   <input type="text" id="hf_size_id" style="display:none;" />
   <input type="text" id="hf_cartoon_detail_id" style="display:none;" />
    <input type="text" id="hf_mapping_id" style="display:none;" />
</asp:Content>

