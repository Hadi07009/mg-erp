using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;
using System.Web.Security;
using System.Collections.Specialized;


using System.IO;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ContractNo : System.Web.UI.Page
    {

        string strEmployeeId = "";
        string strSectionId = "";
        string strDepartmentId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        string strHeadOfficeId = "";
        string strBranchOfficeId = "";
        string strEmployeeTypeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";
        string strReport = "";
        bool status;




        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;

            }

            if (!IsPostBack)
            {
                loadSesscion();
                clearMsg();
                getOfficeName();
                getCurrentDate();
                FirstGridViewRow();
                getManufacturerId();
                getManufacturerBankId();
                getVandorId();
                getVandorBankId();
                getShipId();
                getShipTypeId();
                getPaymentTermId();

              
                getCurrentYear();
                getBuyerIdContract();
                getBuyerIdContractSearch();
                searcContractId();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }


            gvContractDetails.Columns[14].Visible = false;






        }


        #region "Function"

        public void getCurrentYear()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYear();

            txtYear.Text = objLookUpDTO.Year;




        }
        public void getBuyerIdContractSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerIdSearch.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerIdSearch.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerIdSearch.DataValueField = "BUYER_ID";

            ddlBuyerIdSearch.DataBind();
            if (ddlBuyerIdSearch.Items.Count > 0)
            {

                ddlBuyerIdSearch.SelectedIndex = 0;
            }


        }


        public void getBuyerIdContract()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_SHORT_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }

        public void getAmendmentId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlAmendmentId.DataSource = objLookUpBLL.getAmendmentId(ddlContractId.SelectedValue.ToString(), strHeadOfficeId, strBranchOfficeId);

            ddlAmendmentId.DataTextField = "AMENDMENT_NAME";
            ddlAmendmentId.DataValueField = "AMENDMENT_ID";

            ddlAmendmentId.DataBind();
            if (ddlAmendmentId.Items.Count > 0)
            {

                ddlAmendmentId.SelectedIndex = 0;
            }


        }







        public void getPaymentTermId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPaymentTermId.DataSource = objLookUpBLL.getPaymentTermId();

            ddlPaymentTermId.DataTextField = "PAYMENT_DAY";
            ddlPaymentTermId.DataValueField = "PAYMENT_TERM_ID";

            ddlPaymentTermId.DataBind();
            if (ddlPaymentTermId.Items.Count > 0)
            {

                ddlPaymentTermId.SelectedIndex = 0;
            }


        }

        public void getManufacturerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlManufacturerId.DataSource = objLookUpBLL.getManufacturerId();

            ddlManufacturerId.DataTextField = "MANUFACTURE_NAME";
            ddlManufacturerId.DataValueField = "MANUFACTURE_ID";

            ddlManufacturerId.DataBind();
            if (ddlManufacturerId.Items.Count > 0)
            {

                ddlManufacturerId.SelectedIndex = 0;
            }


        }





        public void getManufacturerBankId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlManufacturerBankId.DataSource = objLookUpBLL.getManufacturerBankId();

            ddlManufacturerBankId.DataTextField = "MANUFACTURE_BANK_NAME";
            ddlManufacturerBankId.DataValueField = "MANUFACTURE_BANK_ID";

            ddlManufacturerBankId.DataBind();
            if (ddlManufacturerBankId.Items.Count > 0)
            {

                ddlManufacturerBankId.SelectedIndex = 0;
            }


        }

        public void getVandorId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlVendorId.DataSource = objLookUpBLL.getVandorId();

            ddlVendorId.DataTextField = "VENDOR_NAME";
            ddlVendorId.DataValueField = "VENDOR_ID";

            ddlVendorId.DataBind();
            if (ddlVendorId.Items.Count > 0)
            {

                ddlVendorId.SelectedIndex = 0;
            }


        }

        public void getVandorBankId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlVendorBankId.DataSource = objLookUpBLL.getVandorBankId();

            ddlVendorBankId.DataTextField = "VENDOR_BANK_NAME";
            ddlVendorBankId.DataValueField = "VENDOR_BANK_ID";

            ddlVendorBankId.DataBind();
            if (ddlVendorBankId.Items.Count > 0)
            {

                ddlVendorBankId.SelectedIndex = 0;
            }


        }


        public void getShipId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShipId.DataSource = objLookUpBLL.getShipId();

            ddlShipId.DataTextField = "SHIP_NAME";
            ddlShipId.DataValueField = "SHIP_ID";

            ddlShipId.DataBind();
            if (ddlShipId.Items.Count > 0)
            {

                ddlShipId.SelectedIndex = 0;
            }


        }

        public void getShipTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShipTypeId.DataSource = objLookUpBLL.getShipTypeId();

            ddlShipTypeId.DataTextField = "SHIPMENT_TYPE_NAME";
            ddlShipTypeId.DataValueField = "SHIPMENT_TYPE_ID";

            ddlShipTypeId.DataBind();
            if (ddlShipTypeId.Items.Count > 0)
            {

                ddlShipTypeId.SelectedIndex = 0;
            }


        }



        private void FirstGridViewRow()
        {



            DataTable dt = new DataTable();
            DataRow dr = null;


            dt.Columns.Add(new DataColumn("PO_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("STYLE_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("ITEM_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("SIZE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("SEASON_ID", typeof(string)));


            dt.Columns.Add(new DataColumn("RATE", typeof(string)));

            dt.Columns.Add(new DataColumn("ORDER_QUANTITY", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("HANGER_COST_PER_UNIT", typeof(string)));
            dt.Columns.Add(new DataColumn("HS_CODE", typeof(string)));

            dt.Columns.Add(new DataColumn("UNIT_COST", typeof(string)));
            dt.Columns.Add(new DataColumn("TOTAL_AMOUNT_IN_USD", typeof(string)));
            dt.Columns.Add(new DataColumn("SHIPPING_ADDRESS", typeof(string)));
            dt.Columns.Add(new DataColumn("SHIPPING_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));


            dr = dt.NewRow();


            dr["PO_NO"] = string.Empty;
            dr["STYLE_NO"] = string.Empty;
            dr["ITEM_NAME"] = string.Empty;
            dr["SIZE_ID"] = string.Empty;
            dr["RATE"] = string.Empty;

            dr["ORDER_QUANTITY"] = string.Empty;
            dr["PO_PRICE"] = string.Empty;
            dr["HANGER_COST_PER_UNIT"] = string.Empty;
            dr["UNIT_COST"] = string.Empty;
            dr["HS_CODE"] = string.Empty;
            dr["TOTAL_AMOUNT_IN_USD"] = string.Empty;
            dr["SHIPPING_ADDRESS"] = string.Empty;
            dr["SHIPPING_DATE"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvContractDetails.DataSource = dt;
            gvContractDetails.DataBind();





        }



        public void sessionEmpty()
        {
            Session["strEmployeeId"] = null;
            Session["strSectionId"] = null;
            Session["strDepartmentId"] = null;
            Session["strDesignationId"] = null;
            Session["strUnitId"] = null;
            Session["strCatagoryId"] = null;
            Session["strHeadOfficeId"] = null;
            Session["strBranchOfficeId"] = null;
            Session["strLoginDay"] = null;
            Session["strLoginMonth"] = null;
            Session["strLoginDate"] = null;
            Session.Clear();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx", true);

        }



        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {



        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
        }


        public void getOfficeName()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getHeadOfficeName(strHeadOfficeId, strBranchOfficeId);

            lblHeadOfficeName.Text = objLookUpDTO.HeadOfficeName;
            lblHeadOfficeAddress.Text = objLookUpDTO.HeadOfficeAddress;
            lblBranchOfficeName.Text = objLookUpDTO.BranchOfficeName;
            lblBranchOfficeAddress.Text = objLookUpDTO.BranchOfficeAddress;

        }

        public void getCurrentDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getCurrentDate();

            // dtpIssueDate.Text = objLookUpDTO.AttendenceDate;


        }




        public void loadSesscion()
        {

            strEmployeeId = Session["strEmployeeId"].ToString().Trim();
            strSectionId = Session["strSectionId"].ToString().Trim();

            strDesignationId = Session["strDesignationId"].ToString().Trim();
            strUnitId = Session["strUnitId"].ToString().Trim();
            strCatagoryId = Session["strCatagoryId"].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId"].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId"].ToString().Trim();
            //strEmployeeTypeId = Session["strEmployeeTypeId"].ToString().Trim();
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        private void AddNewRow()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {


                        TextBox txtPONo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtItemName = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtItemName");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        DropDownList ddlSeasonId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlSeasonId");




                        TextBox txtOrderQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtOrderQuantity");


                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtRate");

                        TextBox txtPOPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtPOPrice");
                        TextBox txtHangerCostPerUnit = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtHangerCostPerUnit");

                        TextBox txtHSCode = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtHSCode");

                        TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtUnitCost");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtTotalAmount");
                        TextBox txtShipingAddress = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtShipingAddress");
                        TextBox dtpShippingDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[13].FindControl("dtpShippingDate");

                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[14].FindControl("txtTranId");


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["PO_NO"] = txtPONo.Text;
                        dtCurrentTable.Rows[i - 1]["STYLE_NO"] = txtStyleNo.Text;
                        dtCurrentTable.Rows[i - 1]["ITEM_NAME"] = txtItemName.Text;
                        dtCurrentTable.Rows[i - 1]["SIZE_ID"] = ddlSizeId.Text;
                        dtCurrentTable.Rows[i - 1]["SEASON_ID"] = ddlSeasonId.Text;


                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;

                        dtCurrentTable.Rows[i - 1]["ORDER_QUANTITY"] = txtOrderQuantity.Text;
                        dtCurrentTable.Rows[i - 1]["PO_PRICE"] = txtPOPrice.Text;
                        dtCurrentTable.Rows[i - 1]["HANGER_COST_PER_UNIT"] = txtHangerCostPerUnit.Text;
                        dtCurrentTable.Rows[i - 1]["HS_CODE"] = txtHSCode.Text;


                        dtCurrentTable.Rows[i - 1]["UNIT_COST"] = txtUnitCost.Text;
                        dtCurrentTable.Rows[i - 1]["TOTAL_AMOUNT_IN_USD"] = txtTotalAmount.Text;
                        dtCurrentTable.Rows[i - 1]["SHIPPING_ADDRESS"] = txtShipingAddress.Text;
                        dtCurrentTable.Rows[i - 1]["SHIPPING_DATE"] = dtpShippingDate.Text;

                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvContractDetails.DataSource = dtCurrentTable;
                    gvContractDetails.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }


        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {


                        TextBox txtPONo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtItemName = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtItemName");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        DropDownList ddlSeasonId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlSeasonId");

                        TextBox txtOrderQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtOrderQuantity");
                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtRate");
                        TextBox txtPOPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtPOPrice");
                        TextBox txtHangerCostPerUnit = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtHangerCostPerUnit");
                        TextBox txtHSCode = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtHSCode");
                        TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtUnitCost");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtTotalAmount");
                        TextBox txtShipingAddress = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtShipingAddress");
                        TextBox dtpShippingDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[13].FindControl("dtpShippingDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[14].FindControl("txtTranId");



                        txtPONo.Text = dt.Rows[i]["PO_NO"].ToString();
                        txtStyleNo.Text = dt.Rows[i]["STYLE_NO"].ToString();
                        txtItemName.Text = dt.Rows[i]["ITEM_NAME"].ToString();



                        ddlSizeId.Text = dt.Rows[i]["SIZE_ID"].ToString();
                        ddlSeasonId.Text = dt.Rows[i]["SEASON_ID"].ToString();



                        txtRate.Text = dt.Rows[i]["RATE"].ToString();
                        txtOrderQuantity.Text = dt.Rows[i]["ORDER_QUANTITY"].ToString();
                        txtPOPrice.Text = dt.Rows[i]["PO_PRICE"].ToString();
                        txtHangerCostPerUnit.Text = dt.Rows[i]["HANGER_COST_PER_UNIT"].ToString();
                        txtHSCode.Text = dt.Rows[i]["HS_CODE"].ToString();
                        txtUnitCost.Text = dt.Rows[i]["UNIT_COST"].ToString();
                        txtTotalAmount.Text = dt.Rows[i]["TOTAL_AMOUNT_IN_USD"].ToString();
                        txtShipingAddress.Text = dt.Rows[i]["SHIPPING_ADDRESS"].ToString();
                        dtpShippingDate.Text = dt.Rows[i]["SHIPPING_DATE"].ToString();
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }

        public void deleteContractInfo(string strTranId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();



            objContractDTO.ContactNo = txtContractNo.Text;
            objContractDTO.IssueDate = dtpIssueDate.Text;
            objContractDTO.AmendMentDate = dtpAmendmentDate.Text;
            objContractDTO.TranId = strTranId;




            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objContractBLL.deleteContractInfo(objContractDTO);
            MessageBox(strMsg);


        }


        public void saveContractInfo()
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

            int rowIndex = 0;
            string strMsg = "";

            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        TextBox txtPONo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtItemName = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtItemName");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        DropDownList ddlSeasonId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("ddlSeasonId");

                        TextBox txtOrderQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtOrderQuantity");
                        TextBox txtRate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtRate");
                        TextBox txtPOPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtPOPrice");
                        TextBox txtHangerCostPerUnit = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtHangerCostPerUnit");
                        TextBox txtHSCode = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtHSCode");
                        TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("txtUnitCost");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtTotalAmount");
                        TextBox txtShipingAddress = (TextBox)gvContractDetails.Rows[rowIndex].Cells[12].FindControl("txtShipingAddress");
                        TextBox dtpShippingDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[13].FindControl("dtpShippingDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[14].FindControl("txtTranId");


                        objContractDTO.TranId = txtTranId.Text;
                        if (dtpAmendmentDate.Text == "")
                        {
                            objContractDTO.AmendMentDate = null;
                        }
                        else
                        {
                            objContractDTO.AmendMentDate = dtpAmendmentDate.Text;

                        }

                        objContractDTO.PONo = txtPONo.Text;
                        objContractDTO.StyleNo = txtStyleNo.Text;
                        objContractDTO.ItemName = txtItemName.Text;
                        if (ddlSizeId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.SizeId = ddlSizeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objContractDTO.SizeId = "";

                        }


                        if (ddlSeasonId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

                        }
                        else
                        {
                            objContractDTO.SeasonId = "";

                        }



                        objContractDTO.OrderQty = txtOrderQuantity.Text;
                        objContractDTO.POPrice = txtPOPrice.Text;
                        objContractDTO.HangerCostPerUnit = txtHangerCostPerUnit.Text;
                        objContractDTO.UnitCost = txtUnitCost.Text;
                        objContractDTO.TotalAmountInUSD = txtTotalAmount.Text;
                        objContractDTO.ShippingAddress = txtShipingAddress.Text;
                        objContractDTO.ShippingDate = dtpShippingDate.Text;

                        objContractDTO.Rate = txtRate.Text;


                        objContractDTO.ContactNo = txtContractNo.Text;
                        objContractDTO.IssueDate = dtpIssueDate.Text;
                        if (ddlVendorId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.VendorId = ddlVendorId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.VendorId = "";

                        }

                        if (ddlVendorBankId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.VendorBankId = ddlVendorBankId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.VendorBankId = "";

                        }



                        if (ddlManufacturerId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ManufactureId = ddlManufacturerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ManufactureId = "";

                        }

                        if (ddlManufacturerBankId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ManufactureBankId = ddlManufacturerBankId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ManufactureBankId = "";

                        }

                        if (ddlShipId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ShipId = ddlShipId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ShipId = "";

                        }


                        if (ddlShipTypeId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ShipTypeId = ddlShipTypeId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ShipTypeId = "";

                        }


                        if (ddlPaymentTermId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.PaymentTermId = ddlPaymentTermId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.PaymentTermId = "";

                        }

                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {
                            objContractDTO.BuyerId = "";

                        }


                        objContractDTO.HSCode = txtHSCode.Text;
                        objContractDTO.UltimateConsigneeId = "";

                        objContractDTO.UpdateBy = strEmployeeId;
                        objContractDTO.HeadOfficeId = strHeadOfficeId;
                        objContractDTO.BranchOfficeId = strBranchOfficeId;






                        strMsg = objContractBLL.saveContractInfo(objContractDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;



                        if (strMsg == "PLEASE CHECK AMMENDMENT DATE!!!" || strMsg == "PLEASE CHECK SHIPPING DATE!!!" || strMsg == "PLEASE CHECK ISSUE DATE!!!" || strMsg == "PLEASE CHECK SHIPPING DATE!!!")
                        {
                            MessageBox(strMsg);
                            return;
                        }



                    }

                    if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY" || strMsg == "PLEASE CHECK AMMENDMENT DATE!!!" || strMsg == "PLEASE CREATE NEW AMMENDMENT!!!" || strMsg == "PLEASE CHECK SHIPPING DATE!!!" || strMsg == "PLEASE CHECK ISSUE DATE!!!" || strMsg == "PLEASE CHECK SHIPPING DATE!!!")
                    {
                        MessageBox(strMsg);
                        objContractDTO = objContractBLL.searchAmmendmentId(txtContractNo.Text, dtpIssueDate.Text, dtpAmendmentDate.Text, strHeadOfficeId, strBranchOfficeId);

                        if(objContractDTO.AmendId =="1")
                        {

                            saveContractInfoNull();
                        }
                        else
                        {

                            saveContractInfoPre();
                        }

                       
                        searchContactRecord();
                    }






                }


            }





        }
        public void saveContractInfoNull()
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();


            string strMsg = "";


            if (dtpAmendmentDate.Text == "")
            {
                objContractDTO.AmendMentDate = null;
            }
            else
            {
                objContractDTO.AmendMentDate = dtpAmendmentDate.Text;

            }


            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objContractDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {
                objContractDTO.BuyerId = "";

            }


            objContractDTO.ContactNo = txtContractNo.Text;
            objContractDTO.IssueDate = dtpIssueDate.Text;
            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objContractBLL.saveContractInfoNull(objContractDTO);
            lblMsg.Text = strMsg;

          



        }

        public void saveContractInfoPre()
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

       
            string strMsg = "";


            if (dtpAmendmentDate.Text == "")
            {
                objContractDTO.AmendMentDate = null;
            }
            else
            {
                objContractDTO.AmendMentDate = dtpAmendmentDate.Text;

            }


            if (ddlBuyerId.SelectedValue.ToString() != " ")
            {
                objContractDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

            }
            else
            {
                objContractDTO.BuyerId = "";

            }


            objContractDTO.ContactNo = txtContractNo.Text;
            objContractDTO.IssueDate = dtpIssueDate.Text;
            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objContractBLL.saveContractInfoPre(objContractDTO);
            lblMsg.Text = strMsg;

          



        }
        public void saveContractInfoTemp()
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

            int rowIndex = 0;
            string strMsg = "";

            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtPONo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtItemName = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtItemName");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        TextBox txtOrderQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtOrderQuantity");
                        TextBox txtPOPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtPOPrice");
                        TextBox txtHangerCostPerUnit = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtHangerCostPerUnit");
                        TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtUnitCost");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtTotalAmount");
                        TextBox txtShipingAddress = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtShipingAddress");
                        TextBox dtpDeliveryDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("dtpDeliveryDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtTranId");



                        objContractDTO.TranId = txtTranId.Text;
                        objContractDTO.AmendMentDate = dtpAmendmentDate.Text;
                        objContractDTO.PONo = txtPONo.Text;
                        objContractDTO.StyleNo = txtStyleNo.Text;
                        objContractDTO.ItemName = txtItemName.Text;
                        if (ddlSizeId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.SizeId = ddlSizeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objContractDTO.SizeId = "";

                        }
                        objContractDTO.OrderQty = txtOrderQuantity.Text;
                        objContractDTO.POPrice = txtPOPrice.Text;
                        objContractDTO.HangerCostPerUnit = txtHangerCostPerUnit.Text;
                        objContractDTO.UnitCost = txtUnitCost.Text;
                        objContractDTO.TotalAmountInUSD = txtTotalAmount.Text;
                        objContractDTO.ShippingAddress = txtShipingAddress.Text;
                        objContractDTO.DeliveryDate = dtpDeliveryDate.Text;




                        objContractDTO.ContactNo = txtContractNo.Text;
                        objContractDTO.IssueDate = dtpIssueDate.Text;
                        if (ddlVendorId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.VendorId = ddlVendorId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.VendorId = "";

                        }

                        if (ddlVendorBankId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.VendorBankId = ddlVendorBankId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.VendorBankId = "";

                        }



                        if (ddlManufacturerId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ManufactureId = ddlManufacturerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ManufactureId = "";

                        }

                        if (ddlManufacturerBankId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ManufactureBankId = ddlManufacturerBankId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ManufactureBankId = "";

                        }

                        if (ddlShipId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ShipId = ddlShipId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ShipId = "";

                        }


                        if (ddlShipTypeId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.ShipTypeId = ddlShipTypeId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.ShipTypeId = "";

                        }


                        if (ddlPaymentTermId.SelectedValue.ToString() != " ")
                        {
                            objContractDTO.PaymentTermId = ddlPaymentTermId.SelectedValue.ToString();

                        }
                        else
                        {

                            objContractDTO.PaymentTermId = "";

                        }


                        objContractDTO.UltimateConsigneeId = "";

                        objContractDTO.UpdateBy = strEmployeeId;
                        objContractDTO.HeadOfficeId = strHeadOfficeId;
                        objContractDTO.BranchOfficeId = strBranchOfficeId;






                        strMsg = objContractBLL.saveContractInfoTemp(objContractDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;



                    }


                }


            }





        }

        public void searchContactRecordSub()
        {

            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

            DataTable dt = new DataTable();


            if (ddlContractId.Text != "")
            {

                objContractDTO.ContractId = ddlContractId.SelectedValue.ToString();
            }
            else
            {
                objContractDTO.ContractId = "";

            }


            if (ddlAmendmentId.Text != "0")
            {

                objContractDTO.AmendId = ddlAmendmentId.SelectedValue.ToString();
            }
            else
            {
                objContractDTO.AmendId = "";

            }

            objContractDTO.IssueDate = dtpIssueDateSearch.Text;
            objContractDTO.AmendMentDate = dtpAmendmentDateSearch.Text;
            objContractDTO.IssueYear = txtYear.Text;

           




            if (ddlBuyerIdSearch.SelectedValue.ToString() != " ")
            {
                objContractDTO.BuyerId = ddlBuyerIdSearch.SelectedValue.ToString();

            }
            else
            {

                objContractDTO.BuyerId = "";

            }


            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;

            dt = objContractBLL.searchContactRecordSub(objContractDTO);


            if (dt.Rows.Count > 0)
            {
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();

                int count = ((DataTable)gvForeignFabric.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvForeignFabric.DataSource = dt;
                gvForeignFabric.DataBind();
                int totalcolums = gvForeignFabric.Rows[0].Cells.Count;
                gvForeignFabric.Rows[0].Cells.Clear();
                gvForeignFabric.Rows[0].Cells.Add(new TableCell());
                gvForeignFabric.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvForeignFabric.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        public void searchContactRecord()
        {

            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

            DataTable dt = new DataTable();


            objContractDTO.ContactNo = txtContractNo.Text;
            objContractDTO.IssueDate = dtpIssueDate.Text;
            objContractDTO.AmendMentDate = dtpAmendmentDate.Text;

            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;


            if (ddlBuyerId.SelectedValue.ToString() == "")
            {


                objContractDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();
            }
            else
            {
                objContractDTO.BuyerId = "";

            }

            dt = objContractBLL.searchContactRecord(objContractDTO);


            if (dt.Rows.Count > 0)
            {
                gvContractDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvContractDetails.DataBind();


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[i].FindControl("txtUnitCost");
                    txtUnitCost.Attributes.Add("readonly", "readonly");

                    TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[i].FindControl("txtTotalAmount");
                    txtTotalAmount.Attributes.Add("readonly", "readonly");




                }



                int count = ((DataTable)gvContractDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvContractDetails.DataSource = dt;
                gvContractDetails.DataBind();
                int totalcolums = gvContractDetails.Rows[0].Cells.Count;
                gvContractDetails.Rows[0].Cells.Clear();
                gvContractDetails.Rows[0].Cells.Add(new TableCell());
                gvContractDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvContractDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        public void searcContactMain()
        {
            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();

            string strAmendId = "";


            objContractDTO = objContractBLL.searcContactMain(txtContractNo.Text, dtpIssueDate.Text, dtpAmendmentDate.Text, strHeadOfficeId, strBranchOfficeId);


            if (objContractDTO.IssueDate == "0")
            {
                dtpIssueDate.Text = "";
            }
            else
            {
                dtpIssueDate.Text = objContractDTO.IssueDate;

            }





            if (objContractDTO.VendorId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlVendorId.SelectedValue = objContractDTO.VendorId;
            }


            if (objContractDTO.VendorBankId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlVendorBankId.SelectedValue = objContractDTO.VendorBankId;
            }


            if (objContractDTO.ManufactureId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlManufacturerId.SelectedValue = objContractDTO.ManufactureId;
            }


            if (objContractDTO.ManufactureBankId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlManufacturerBankId.SelectedValue = objContractDTO.ManufactureBankId;
            }


            if (objContractDTO.ShipId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlShipId.SelectedValue = objContractDTO.ShipId;
            }


            if (objContractDTO.ShipTypeId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlShipTypeId.SelectedValue = objContractDTO.ShipTypeId;
            }

            if (objContractDTO.PaymentTermId == "0")
            {

                //nothing to do
            }
            else
            {
                ddlPaymentTermId.SelectedValue = objContractDTO.PaymentTermId;
            }

            if (objContractDTO.ContactNo == "0")
            {
                txtContractNo.Text = "";
            }
            else
            {
                txtContractNo.Text = objContractDTO.ContactNo;
            }

            if (objContractDTO.BuyerId == "0")
            {
                ddlBuyerId.SelectedValue = "";
            }
            else
            {
                ddlBuyerId.SelectedValue = objContractDTO.BuyerId;
            }




        }







        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (ddlBuyerId.Text == "")
            {
                string strMsg = "Please Select Buyer Name!!!";
                ddlBuyerId.Focus();
                MessageBox(strMsg);

                return;


            }

            else if (txtContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                txtContractNo.Focus();
                MessageBox(strMsg);

                return;


            }
            else if (dtpIssueDate.Text == "")
            {
                string strMsg = "Please Enter Issue Date!!!";
                dtpIssueDate.Focus();
                MessageBox(strMsg);
                return;


            }
            else if (ddlVendorId.Text == " ")
            {
                string strMsg = "Please Select Vendor Name!!!";
                ddlVendorId.Focus();
                MessageBox(strMsg);
                return;


            }
            else if (ddlManufacturerId.Text == " ")
            {
                string strMsg = "Please Select Manufacturer Name!!!";
                MessageBox(strMsg);
                ddlManufacturerId.Focus();
                return;


            }
            else if (ddlShipId.Text == " ")
            {
                string strMsg = "Please Select Shiping Address!!!";
                MessageBox(strMsg);
                ddlShipId.Focus();
                return;


            }

            else if (ddlManufacturerBankId.Text == " ")
            {
                string strMsg = "Please Select Manufacturer Bank!!!";
                MessageBox(strMsg);
                ddlManufacturerBankId.Focus();
                return;


            }

            else if (ddlVendorBankId.Text == " ")
            {
                string strMsg = "Please Select Vendor Bank!!!";
                MessageBox(strMsg);
                ddlVendorBankId.Focus();
                return;


            }
            else if (ddlShipTypeId.Text == " ")
            {
                string strMsg = "Please Select Mode Of Shipment!!!";
                MessageBox(strMsg);
                ddlShipTypeId.Focus();
                return;


            }
            else if (ddlPaymentTermId.Text == " ")
            {
                string strMsg = "Please Select Payment Term!!!";
                MessageBox(strMsg);
                ddlPaymentTermId.Focus();
                return;


            }


            else
            {

                saveContractInfo();
              

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                MessageBox(strMsg);
                txtContractNo.Focus();
                return;
            }
            if (dtpIssueDate.Text.Length < 6)
            {
                string strMsg = "Please Enter Issue Date!!!";
                MessageBox(strMsg);
                dtpIssueDate.Focus();
                return;


            }

            else
            {
                searcContactMain();
                searchContactRecord();




            }

        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }


        #region "Grid View Functionality"
        protected void gvContractDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContractDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvContractDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }




        protected void gvContractDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvContractDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)gvContractDetails.Rows[e.RowIndex];
            Label lbldeleteid = (Label)row.FindControl("TRAN_ID");

            //if (lbldeleteid == null)
            //{

            //    string strMsg = "ID NOT FOUND!!!";
            //    MessageBox(strMsg);
            //    return;
            //}
            //else
            //{

            int stor_id = Convert.ToInt32(gvContractDetails.DataKeys[e.RowIndex].Value.ToString());
            string strTranId = Convert.ToString(stor_id);

            deleteContractInfoRecord(strTranId);
            searchContactRecord();
            searcContactMain();

            //}











        }

        protected void gvContractDetails_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{
            //    int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //    string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //    string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //    string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //    string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryWorker();

            //    txtWorkingDay.Focus();
            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}




            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void gvContractDetails_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void gvContractDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();

                DropDownList a = (e.Row.FindControl("ddlSizeId") as DropDownList);


                DataTable dt1 = new DataTable();


                DataRowView dr = e.Row.DataItem as DataRowView;


                dt1 = objLookUpBLL.getSizeId();
                a.DataSource = dt1;
                a.DataBind();
                a.SelectedValue = dr["SIZE_ID"].ToString();




                DropDownList b = (e.Row.FindControl("ddlSeasonId") as DropDownList);
                DataTable dt2 = new DataTable();
                DataRowView dr2 = e.Row.DataItem as DataRowView;
                dt2 = objLookUpBLL.getSeasonId();
                b.DataSource = dt2;
                b.DataBind();
                b.SelectedValue = dr2["SEASON_ID"].ToString();




            }






        }


        #endregion



        protected void ddlAmendmentId_SelectedIndexChanged(object sender, EventArgs e)
        {

            searchContactRecord();
            searcContactMain();

        }

        protected void btnSearchAmmendMent_Click(object sender, EventArgs e)
        {

            searchContactRecord();
            searcContactMain();
        }



        public void deleteContractInfoRecord(string strTranId)
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();



            objContractDTO.ContactNo = txtContractNo.Text;
            objContractDTO.IssueDate = dtpIssueDate.Text;
            objContractDTO.AmendMentDate = dtpAmendmentDate.Text;
            objContractDTO.TranId = strTranId;




            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objContractBLL.deleteContractInfoRecord(objContractDTO);
            MessageBox(strMsg);


        }

        public void updateContractInfo()
        {


            ContractDTO objContractDTO = new ContractDTO();
            ContractBLL objContractBLL = new ContractBLL();



            objContractDTO.ContactNo = txtContractNo.Text;
            objContractDTO.IssueDate = dtpIssueDate.Text;
            objContractDTO.AmendMentDate = dtpAmendmentDate.Text;





            objContractDTO.UpdateBy = strEmployeeId;
            objContractDTO.HeadOfficeId = strHeadOfficeId;
            objContractDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objContractBLL.updateContractInfo(objContractDTO);
            //MessageBox(strMsg);


        }

        protected void ddlManufacturerId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtOrderQuantity_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtUnitCost");
            txtUnitCost.Attributes.Add("readonly", "readonly");

            TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtTotalAmount");

            txtTotalAmount.Attributes.Add("readonly", "readonly");




        }

        protected void txtPOPrice_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            GridViewRow gvr = (GridViewRow)tb.Parent.Parent;
            int rowindex = gvr.RowIndex;

            TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtUnitCost");
            txtUnitCost.Attributes.Add("readonly", "readonly");

            TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowindex].FindControl("txtTotalAmount");

            txtTotalAmount.Attributes.Add("readonly", "readonly");




        }




        //#region "Grid View Functionality"
        //protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    gvEmployeeList.PageIndex = e.NewPageIndex;

        //}

        //protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        //{



        //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
        //    string strContactNo = gvEmployeeList.SelectedRow.Cells[1].Text;
        //    string strIssueDate = gvEmployeeList.SelectedRow.Cells[2].Text;




        //}


        //protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        //{


        //}

        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{

        //}


        //protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        //{



        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        //}

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{



        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);

        //    }


        //}


        //protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        //{

        //}




        //#endregion


        #region gridviewEvent

        protected void gvForeignFabric_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvForeignFabric_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }


        protected void gvForeignFabric_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvForeignFabric.SelectedRow.RowIndex + 1;


            string strChallanNo = gvForeignFabric.SelectedRow.Cells[1].Text.Replace("&nbsp;", ""); ;
            string strIssueDate = gvForeignFabric.SelectedRow.Cells[2].Text.Replace("&nbsp;", ""); ;
            string strAmendmentDate = gvForeignFabric.SelectedRow.Cells[3].Text.Replace("&nbsp;", ""); ;
            string strPONo = gvForeignFabric.SelectedRow.Cells[4].Text.Replace("&nbsp;", ""); ;
            string strStyleNO = gvForeignFabric.SelectedRow.Cells[5].Text.Replace("&nbsp;", ""); ;

            txtContractNo.Text = strChallanNo;
            dtpIssueDate.Text = strIssueDate;
            dtpAmendmentDate.Text = strAmendmentDate;

            searcContactMain();
            searchContactRecord();

        }
























        #endregion

        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            searchContactRecordSub();
        }

        protected void txtContractNoSearch_TextChanged(object sender, EventArgs e)
        {
            if (ddlContractId.Text == "")
            {
                string strMsg = "Please Seelct Contract No";
                ddlContractId.Focus();
                MessageBox(strMsg);
                return;

            }
            else
            {
                getAmendmentId();


            }


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        public void clear()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox txtPONo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[0].FindControl("txtPONo");
                        TextBox txtStyleNo = (TextBox)gvContractDetails.Rows[rowIndex].Cells[1].FindControl("txtStyleNo");
                        TextBox txtItemName = (TextBox)gvContractDetails.Rows[rowIndex].Cells[2].FindControl("txtItemName");
                        DropDownList ddlSizeId = (DropDownList)gvContractDetails.Rows[rowIndex].Cells[3].FindControl("ddlSizeId");
                        TextBox txtOrderQuantity = (TextBox)gvContractDetails.Rows[rowIndex].Cells[4].FindControl("txtOrderQuantity");
                        TextBox txtPOPrice = (TextBox)gvContractDetails.Rows[rowIndex].Cells[5].FindControl("txtPOPrice");
                        TextBox txtHangerCostPerUnit = (TextBox)gvContractDetails.Rows[rowIndex].Cells[6].FindControl("txtHangerCostPerUnit");
                        TextBox txtUnitCost = (TextBox)gvContractDetails.Rows[rowIndex].Cells[7].FindControl("txtUnitCost");
                        TextBox txtTotalAmount = (TextBox)gvContractDetails.Rows[rowIndex].Cells[8].FindControl("txtTotalAmount");
                        TextBox txtShipingAddress = (TextBox)gvContractDetails.Rows[rowIndex].Cells[9].FindControl("txtShipingAddress");
                        TextBox dtpShippingDate = (TextBox)gvContractDetails.Rows[rowIndex].Cells[10].FindControl("dtpShippingDate");
                        TextBox txtTranId = (TextBox)gvContractDetails.Rows[rowIndex].Cells[11].FindControl("txtTranId");


                        txtPONo.Text = "";
                        txtStyleNo.Text = "";
                        txtItemName.Text = "";
                        txtOrderQuantity.Text = "";
                        txtPOPrice.Text = "";
                        txtHangerCostPerUnit.Text = "";
                        txtUnitCost.Text = "";
                        txtTotalAmount.Text = "";
                        txtShipingAddress.Text = "";
                        txtTranId.Text = "";
                        dtpShippingDate.Text = "";

                    }

                  
                }

              

            }

                      
           






        }

        protected void ddlContractId_SelectedIndexChanged(object sender, EventArgs e)
        {
            getAmendmentId();
        }

        public void searcContractId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlContractId.DataSource = objLookUpBLL.searcContractId(txtYear.Text, strHeadOfficeId, strBranchOfficeId);

            ddlContractId.DataTextField = "CONTRACT_NO";
            ddlContractId.DataValueField = "CONTRACT_ID";

            ddlContractId.DataBind();
            if (ddlContractId.Items.Count > 0)
            {

                ddlContractId.SelectedIndex = 0;
            }




        }

        protected void txtYear_TextChanged(object sender, EventArgs e)
        {
            searcContractId();
        }
    }
}