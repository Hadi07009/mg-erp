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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PoOrder : System.Web.UI.Page
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

        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;


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

                getSupplierId();
                //ADDED BY ASAD
                GetPurchager();
                getPaymentModeId();
                getPartshipmentId();
                getTranshipmentId();

                getCurrencyId();
                getShipmentModeId();

                txtPoRequisitionNo.Focus();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }
            
            txtPoRequisitionNo.Attributes.Add("onkeypress", "return controlEnter('" + txtPoNumber.ClientID + "', event)");
            txtPoNumber.Attributes.Add("onkeypress", "return controlEnter('" + txtIssueDate.ClientID + "', event)");
            txtIssueDate.Attributes.Add("onkeypress", "return controlEnter('" + txtDeliveryDate.ClientID + "', event)");
            txtDeliveryDate.Attributes.Add("onkeypress", "return controlEnter('" + txtOfferNo.ClientID + "', event)");
            txtOfferNo.Attributes.Add("onkeypress", "return controlEnter('" + txtTradeTerms.ClientID + "', event)");
            txtTradeTerms.Attributes.Add("onkeypress", "return controlEnter('" + txtPortOfLoading.ClientID + "', event)");
            txtPortOfLoading.Attributes.Add("onkeypress", "return controlEnter('" + txtPortOfDischarges.ClientID + "', event)");

        }


        #region "Function"

        public void getSupplierId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSupplierId.DataSource = objLookUpBLL.getPoSupplierId();

            ddlSupplierId.DataTextField = "SUPPLIER_NAME";
            ddlSupplierId.DataValueField = "SUPPLIER_ID";

            ddlSupplierId.DataBind();
            if (ddlSupplierId.Items.Count > 0)
            {

                ddlSupplierId.SelectedIndex = 0;
            }
        }

        public void GetPurchager()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPurcharser.DataSource = objLookUpBLL.GetPurchager();

            ddlPurcharser.DataTextField = "PURCHASER_NAME";
            ddlPurcharser.DataValueField = "PURCHASER_ID";

            ddlPurcharser.DataBind();
            if (ddlPurcharser.Items.Count > 0)
            {
                ddlPurcharser.SelectedIndex = 0;
            }
        }

        public void getPaymentModeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPaymentModeId.DataSource = objLookUpBLL.getPaymentModeId();

            ddlPaymentModeId.DataTextField = "PAYMENT_MODE_NAME";
            ddlPaymentModeId.DataValueField = "PAYMENT_MODE_ID";

            ddlPaymentModeId.DataBind();
            if (ddlPaymentModeId.Items.Count > 0)
            {

                ddlPaymentModeId.SelectedIndex = 0;
            }
        }
        public void getPartshipmentId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPartshipmentId.DataSource = objLookUpBLL.getPartshipmentId();

            ddlPartshipmentId.DataTextField = "PART_SHIPMENT_NAME";
            ddlPartshipmentId.DataValueField = "PART_SHIPMENT_ID";

            ddlPartshipmentId.DataBind();
            if (ddlPartshipmentId.Items.Count > 0)
            {

                ddlPartshipmentId.SelectedIndex = 0;
            }
        }
        public void getTranshipmentId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlTranshipmentId.DataSource = objLookUpBLL.getTranshipmentId();

            ddlTranshipmentId.DataTextField = "TRAN_SHIPMENT_NAME";
            ddlTranshipmentId.DataValueField = "TRAN_SHIPMENT_ID";

            ddlTranshipmentId.DataBind();
            if (ddlTranshipmentId.Items.Count > 0)
            {

                ddlTranshipmentId.SelectedIndex = 0;
            }
        }
        public void getCurrencyId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlCurrencyId.DataSource = objLookUpBLL.getCurrencyId(strHeadOfficeId, strBranchOfficeId);

            ddlCurrencyId.DataTextField = "CURRENCY_NAME";
            ddlCurrencyId.DataValueField = "CURRENCY_ID";

            ddlCurrencyId.DataBind();
            if (ddlCurrencyId.Items.Count > 0)
            {

                ddlCurrencyId.SelectedIndex = 0;
            }
        }
        public void getShipmentModeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShipmentModeId.DataSource = objLookUpBLL.getShipmentModeId(strHeadOfficeId, strBranchOfficeId);

            ddlShipmentModeId.DataTextField = "SHIPMENT_TYPE_NAME";
            ddlShipmentModeId.DataValueField = "SHIPMENT_TYPE_ID";

            ddlShipmentModeId.DataBind();
            if (ddlShipmentModeId.Items.Count > 0)
            {

                ddlShipmentModeId.SelectedIndex = 0;
            } 
        }

        private void FirstGridViewRow()
        {


            DataTable dt = new DataTable();
            DataRow dr = null;


            dt.Columns.Add(new DataColumn("PARTICULAR_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("PART_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_UNIT_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("APPROVED_QTY", typeof(string)));
            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));           

            dr = dt.NewRow();


            dr["PARTICULAR_NAME"] = string.Empty;
            dr["PART_NO"] = string.Empty;
            dr["PO_UNIT_NAME"] = string.Empty;
            dr["APPROVED_QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["PRICE"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvPoOrder.DataSource = dt;
            gvPoOrder.DataBind();
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


        public void savePoOrderInfo()
        {

            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderBLL objPoOrderBLL = new PoOrderBLL();


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
                        TextBox txtProductDescription = (TextBox)gvPoOrder.Rows[rowIndex].Cells[0].FindControl("txtProductDescription");
                        TextBox txtPartNo = (TextBox)gvPoOrder.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                        TextBox txtPoUnitName = (TextBox)gvPoOrder.Rows[rowIndex].Cells[2].FindControl("txtPoUnitName");
                        TextBox txtApprovedQty = (TextBox)gvPoOrder.Rows[rowIndex].Cells[3].FindControl("txtApprovedQty");
                        TextBox txtRate = (TextBox)gvPoOrder.Rows[rowIndex].Cells[4].FindControl("txtRate");
                        TextBox txtPrice = (TextBox)gvPoOrder.Rows[rowIndex].Cells[5].FindControl("txtPrice");
                        Label lblTranId = (Label)gvPoOrder.Rows[rowIndex].Cells[6].FindControl("lblTranId");

                        objPoOrderDTO.ProductDescription = txtProductDescription.Text;
                        objPoOrderDTO.PartNo = txtPartNo.Text;
                        objPoOrderDTO.PoUnitName = txtPoUnitName.Text;
                        objPoOrderDTO.ApprovedQty = txtApprovedQty.Text;
                        objPoOrderDTO.Rate = txtRate.Text;
                        objPoOrderDTO.Price = txtPrice.Text;
                        objPoOrderDTO.Note = txtNote.Text;


                        objPoOrderDTO.PoNumber = txtPoNumber.Text;
                        objPoOrderDTO.PoRequisitionNo = txtPoRequisitionNo.Text;
                        objPoOrderDTO.IssueDate = txtIssueDate.Text;
                        objPoOrderDTO.OfferNo = txtOfferNo.Text;
                        objPoOrderDTO.DeliveryDate = txtDeliveryDate.Text;
                        objPoOrderDTO.TradeTerms = txtTradeTerms.Text;
                        objPoOrderDTO.PortOfLoading = txtPortOfLoading.Text;
                        objPoOrderDTO.PortOfDischarges = txtPortOfDischarges.Text;

                        if (ddlCurrencyId.SelectedValue.ToString() != " ")
                        {
                            objPoOrderDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoOrderDTO.CurrencyId = "";
                        }

                        if (ddlShipmentModeId.SelectedValue.ToString() != " ")
                        {
                            objPoOrderDTO.ShipmentModeId = ddlShipmentModeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoOrderDTO.ShipmentModeId = "";
                        }          

                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objPoOrderDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoOrderDTO.SupplierId = "";
                        }

                        //New
                        if (ddlPurcharser.SelectedValue.ToString() != " ")
                        {
                            objPoOrderDTO.PurchaserId = ddlPurcharser.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoOrderDTO.PurchaserId = "";
                        }
                        
                        if (ddlPaymentModeId.SelectedValue.ToString() != " ")
                        {
                            objPoOrderDTO.PaymentModeId = ddlPaymentModeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoOrderDTO.PaymentModeId = "";
                        }

                        if (ddlPartshipmentId.SelectedValue.ToString() != " ")
                        {
                            objPoOrderDTO.PartshipmentId = ddlPartshipmentId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoOrderDTO.PartshipmentId = "";
                        }
                        if (ddlTranshipmentId.SelectedValue.ToString() != " ")
                        {
                            objPoOrderDTO.TranshipmentId = ddlTranshipmentId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoOrderDTO.TranshipmentId = "";
                        }

                        objPoOrderDTO.TranId = lblTranId.Text;

                        objPoOrderDTO.Freight = txtFreight.Text;
                        objPoOrderDTO.TrackingChargeFee = txtTrackingChargeFee.Text;
                        objPoOrderDTO.PurchaseDate = dtpPurchaseDate.Text;
                        objPoOrderDTO.Discount = txtDiscount.Text;
                        objPoOrderDTO.TotalAmount = txtTotalAmount.Text;



                        objPoOrderDTO.UpdateBy = strEmployeeId;
                        objPoOrderDTO.HeadOfficeId = strHeadOfficeId;
                        objPoOrderDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objPoOrderBLL.savePoOrderInfo(objPoOrderDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;

                        if (strMsg != "INSERTED SUCCESSFULLY" && strMsg != "UPDATED SUCCESSFULLY")
                        {
                            string input = strMsg;
                            string subStr = input.Substring(22);
                            txtPoNumber.Text = subStr;

                        }

                      

                    }

                    if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY")
                    {
                        MessageBox(strMsg);

                    }
                    else
                    {
                        MessageBox(strMsg);

                    }

                }


            }

        }

        public void searchPoOrderRecord()
        {
            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderBLL objPoOrderBLL = new PoOrderBLL();

            DataTable dt = new DataTable();


            dt = objPoOrderBLL.searchPoOrderRecord(txtPoRequisitionNo.Text, txtPoNumber.Text, txtIssueDate.Text, txtDeliveryDate.Text, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvPoOrder.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoOrder.DataBind();

                int count = ((DataTable)gvPoOrder.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoOrder.DataSource = dt;
                gvPoOrder.DataBind();
                int totalcolums = gvPoOrder.Rows[0].Cells.Count;
                gvPoOrder.Rows[0].Cells.Clear();
                gvPoOrder.Rows[0].Cells.Add(new TableCell());
                gvPoOrder.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoOrder.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }
        public void searchPoRequisitionInfo()
        {
            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderBLL objPoOrderBLL = new PoOrderBLL();

            DataTable dt = new DataTable();
            dt = objPoOrderBLL.searchPoRequisitionInfo(txtPoRequisitionNo.Text, dtpPurchaseDate.Text, strEmployeeId, strHeadOfficeId, strBranchOfficeId);

            if (dt.Rows.Count > 0)
            {
                gvPoOrder.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoOrder.DataBind();

                int count = ((DataTable)gvPoOrder.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoOrder.DataSource = dt;
                gvPoOrder.DataBind();
                int totalcolums = gvPoOrder.Rows[0].Cells.Count;
                gvPoOrder.Rows[0].Cells.Clear();
                gvPoOrder.Rows[0].Cells.Add(new TableCell());
                gvPoOrder.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoOrder.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }
        public void searchPoOrderRecordMain()
        {
            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderBLL objPoOrderBLL = new PoOrderBLL();

           
            
            objPoOrderDTO = objPoOrderBLL.searchPoOrderRecordMain(txtPoRequisitionNo.Text, txtPoNumber.Text, txtIssueDate.Text, txtDeliveryDate.Text, strHeadOfficeId, strBranchOfficeId);

            if (objPoOrderDTO.PoNumber == "0")
            {

                txtPoNumber.Text = "";
            }
            else
            {
                txtPoNumber.Text = objPoOrderDTO.PoNumber;
            }
            if (objPoOrderDTO.IssueDate == "0")
            {
                txtIssueDate.Text = "";
            }
            else
            {
                txtIssueDate.Text = objPoOrderDTO.IssueDate;

            }
            if (objPoOrderDTO.DeliveryDate == "0")
            {
                txtDeliveryDate.Text = "";
            }
            else
            {
                txtDeliveryDate.Text = objPoOrderDTO.DeliveryDate;

            }
            if (objPoOrderDTO.OfferNo == "0")
            {

                txtOfferNo.Text = "";
            }
            else
            {
                txtOfferNo.Text = objPoOrderDTO.OfferNo;
            }
            if (objPoOrderDTO.TradeTerms == "0")
            {

                txtTradeTerms.Text = "";
            }
            else
            {
                txtTradeTerms.Text = objPoOrderDTO.TradeTerms;
            }
            if (objPoOrderDTO.PortOfLoading == "0")
            {

                txtPortOfLoading.Text = "";
            }
            else
            {
                txtPortOfLoading.Text = objPoOrderDTO.PortOfLoading;
            }
            if (objPoOrderDTO.PortOfDischarges == "0")
            {

                txtPortOfDischarges.Text = "";
            }
            else
            {
                txtPortOfDischarges.Text = objPoOrderDTO.PortOfDischarges;
            }


            if (objPoOrderDTO.CurrencyId == "0")
            {

                getCurrencyId();
            }
            else
            {
                ddlCurrencyId.SelectedValue = objPoOrderDTO.CurrencyId;
            }
            if (objPoOrderDTO.ShipmentModeId == "0")
            {

                getShipmentModeId();
            }
            else
            {
                ddlShipmentModeId.SelectedValue = objPoOrderDTO.ShipmentModeId;
            }

            if (objPoOrderDTO.PaymentModeId == "0")
            {

                getPaymentModeId();
            }
            else
            {
                ddlPaymentModeId.SelectedValue = objPoOrderDTO.PaymentModeId;
            }

            if (objPoOrderDTO.PartshipmentId == "0")
            {

                getPartshipmentId();
            }
            else
            {
                ddlPartshipmentId.SelectedValue = objPoOrderDTO.PartshipmentId;
            }

            if (objPoOrderDTO.TranshipmentId == "0")
            {

                getTranshipmentId();
            }
            else
            {
                ddlTranshipmentId.SelectedValue = objPoOrderDTO.TranshipmentId;
            }

            if (objPoOrderDTO.SupplierId == "0")
            {

                getSupplierId();
            }
            else
            {
                ddlSupplierId.SelectedValue = objPoOrderDTO.SupplierId;
            }

            ddlPurcharser.SelectedValue = objPoOrderDTO.PurchaserId;

            if (objPoOrderDTO.Freight == "0")
            {

                txtFreight.Text = "0";
            }
            else
            {
                txtFreight.Text = objPoOrderDTO.Freight;
            }

            if (objPoOrderDTO.TrackingChargeFee == "0")
            {

                txtTrackingChargeFee.Text = "0";
            }
            else
            {
                txtTrackingChargeFee.Text = objPoOrderDTO.TrackingChargeFee;
            }
            if (objPoOrderDTO.PurchaseDate == "0" || objPoOrderDTO.PurchaseDate == null)
            {

                dtpPurchaseDate.Text = "";
            }
            else
            {
                dtpPurchaseDate.Text = objPoOrderDTO.PurchaseDate;
            }
            if (objPoOrderDTO.Discount == "0")
            {

                txtDiscount.Text = "0";
            }
            else
            {
                txtDiscount.Text = objPoOrderDTO.Discount;
            }
            if (objPoOrderDTO.TotalAmount == "0")
            {

                txtTotalAmount.Text = "0";
            }
            else
            {
                txtTotalAmount.Text = objPoOrderDTO.TotalAmount;
            }


            if (objPoOrderDTO.Note == "0")
            {

                txtNote.Text = "";
            }
            else
            {
                txtNote.Text = objPoOrderDTO.Note;
            }



        }
        public void searchPoOrderRecordFinalMain()
        {
            PoOrderDTO objPoOrderDTO = new PoOrderDTO();
            PoOrderBLL objPoOrderBLL = new PoOrderBLL();



            objPoOrderDTO = objPoOrderBLL.searchPoOrderRecordFinalMain(txtPoNumber.Text, txtIssueDate.Text, txtDeliveryDate.Text, strHeadOfficeId, strBranchOfficeId);

            if (objPoOrderDTO.PoRequisitionNo == "0")
            {

                txtPoRequisitionNo.Text = "";
            }
            else
            {
                txtPoRequisitionNo.Text = objPoOrderDTO.PoRequisitionNo;
            }

            if (objPoOrderDTO.IssueDate == "0")
            {
                txtIssueDate.Text = "";
            }
            else
            {
                txtIssueDate.Text = objPoOrderDTO.IssueDate;

            }
            if (objPoOrderDTO.DeliveryDate == "0")
            {
                txtDeliveryDate.Text = "";
            }
            else
            {
                txtDeliveryDate.Text = objPoOrderDTO.DeliveryDate;

            }
            if (objPoOrderDTO.OfferNo == "0")
            {

                txtOfferNo.Text = "";
            }
            else
            {
                txtOfferNo.Text = objPoOrderDTO.OfferNo;
            }
            if (objPoOrderDTO.TradeTerms == "0")
            {

                txtTradeTerms.Text = "";
            }
            else
            {
                txtTradeTerms.Text = objPoOrderDTO.TradeTerms;
            }
            if (objPoOrderDTO.PortOfLoading == "0")
            {

                txtPortOfLoading.Text = "";
            }
            else
            {
                txtPortOfLoading.Text = objPoOrderDTO.PortOfLoading;
            }
            if (objPoOrderDTO.PortOfDischarges == "0")
            {

                txtPortOfDischarges.Text = "";
            }
            else
            {
                txtPortOfDischarges.Text = objPoOrderDTO.PortOfDischarges;
            }


            if (objPoOrderDTO.CurrencyId == "0")
            {

                getCurrencyId();
            }
            else
            {
                ddlCurrencyId.SelectedValue = objPoOrderDTO.CurrencyId;
            }
            if (objPoOrderDTO.ShipmentModeId == "0")
            {

                getShipmentModeId();
            }
            else
            {
                ddlShipmentModeId.SelectedValue = objPoOrderDTO.ShipmentModeId;
            }

            if (objPoOrderDTO.PaymentModeId == "0")
            {

                getPaymentModeId();
            }
            else
            {
                ddlPaymentModeId.SelectedValue = objPoOrderDTO.PaymentModeId;
            }

            if (objPoOrderDTO.PartshipmentId == "0")
            {

                getPartshipmentId();
            }
            else
            {
                ddlPartshipmentId.SelectedValue = objPoOrderDTO.PartshipmentId;
            }

            if (objPoOrderDTO.TranshipmentId == "0")
            {

                getTranshipmentId();
            }
            else
            {
                ddlTranshipmentId.SelectedValue = objPoOrderDTO.TranshipmentId;
            }

            if (objPoOrderDTO.SupplierId == "0")
            {

                getSupplierId();
            }
            else
            {
                ddlSupplierId.SelectedValue = objPoOrderDTO.SupplierId;
            }

            ddlPurcharser.SelectedValue = objPoOrderDTO.PurchaserId;

            if (objPoOrderDTO.Freight == "0")
            {

                txtFreight.Text = "";
            }
            else
            {
                txtFreight.Text = objPoOrderDTO.Freight;
            }

            if (objPoOrderDTO.PurchaseDate == "0" || objPoOrderDTO.PurchaseDate == null)
            {

                dtpPurchaseDate.Text = "";
            }
            else
            {
                dtpPurchaseDate.Text = objPoOrderDTO.PurchaseDate;
            }
            if (objPoOrderDTO.Discount == "0")
            {

                txtDiscount.Text = "";
            }
            else
            {
                txtDiscount.Text = objPoOrderDTO.Discount;
            }
            if (objPoOrderDTO.TotalAmount == "0")
            {

                txtTotalAmount.Text = "";
            }
            else
            {
                txtTotalAmount.Text = objPoOrderDTO.TotalAmount;
            }
           
        }

        public void processsDailyContractInfo()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;


            string strMsg = objReportBLL.processsDailyContractInfo(objReportDTO);

        }


        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtIssueDate.Text == "")
            {
                string strMsg = "Please Enter Issue Date!!!";
                MessageBox(strMsg);
                txtIssueDate.Focus();
                return;
            }
            else if (txtDeliveryDate.Text == "")
            {
                string strMsg = "Please Enter Delivery Date!!!";
                MessageBox(strMsg);
                txtDeliveryDate.Focus();
                return;
            }
   
            else if (txtFreight.Text == "")
            {
                string strMsg = "Please Enter Air Freight!!!";
                MessageBox(strMsg);
                txtFreight.Focus();
                return;
            }
        
            else
            {
                savePoOrderInfo();
                searchPoOrderRecord();
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchPoOrderRecordMain();
            searchPoOrderRecord();
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
            gvPoOrder.PageIndex = e.NewPageIndex;

        }

        protected void gvPoOrder_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvPoOrder_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPoOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //}
        }

        protected void gvContractDetails_Sorting(object sender, GridViewSortEventArgs e)
        {


        }
        protected void gvPoOrder_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                try
                {
                    LookUpBLL objLookUpBLL = new LookUpBLL();

                    DropDownList b = (e.Row.FindControl("ddlPoUnitId") as DropDownList);

                    DataTable dt = new DataTable();
                    DataRowView dr = e.Row.DataItem as DataRowView;

                    dt = objLookUpBLL.getPoUnitId();
                    b.DataSource = dt;
                    b.DataBind();
                    b.SelectedValue = dr["PO_UNIT_ID"].ToString();



                }
                catch (Exception ex)
                {

                } 

        }


        #endregion


        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {

                searchPoOrderRecordMain();
                searchPoOrderRecord();
                
            
        }
        protected void btnSearchPoRequisitionNo_Click(object sender, EventArgs e)
        {
            if (txtPoRequisitionNo.Text == "")
            {
                string strMsg = "Please Enter Po Requisition No!!!";
                MessageBox(strMsg);
                txtPoRequisitionNo.Focus();
                return;


            }
            else
            {
                searchPoOrderRecordMain();
                searchPoRequisitionInfo();

            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPoNumber.Text == "")
            {
                string strMsg = "Please Enter Po Number!!!";
                MessageBox(strMsg);
                txtPoNumber.Focus();
                return;


            }
            else
            {
                searchPoOrderRecordMain();
                searchPoOrderRecord();

            }
        }

        protected void txtPoRequisitionNo_TextChanged(object sender, EventArgs e)
        {

            lblPoRequisitionNo.Style["margin-top"] = "-31px";
            lblPoRequisitionNo.Style["position"] = "absolute";
            lblPoRequisitionNo.Style["margin-left"] = "-90px";
          
            PoOrderBLL objPoTrackingBLL = new PoOrderBLL();

            DataTable dt = new DataTable();
            string PoRequisitionNo = "";
            PoRequisitionNo = txtPoRequisitionNo.Text;

            dt = objPoTrackingBLL.SearchPoRequisitionNo(PoRequisitionNo, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvPoOrderSearch1.Visible = true;

                gvPoOrderSearch1.DataSource = dt;
                ViewState["CurrentTable"] = dt;

                gvPoOrderSearch1.DataBind();

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoOrderSearch1.DataSource = dt;
                gvPoOrderSearch1.DataBind();
                int totalcolums = gvPoOrderSearch1.Rows[0].Cells.Count;
                gvPoOrderSearch1.Rows[0].Cells.Clear();
                gvPoOrderSearch1.Rows[0].Cells.Add(new TableCell());
                gvPoOrderSearch1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoOrderSearch1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }

        protected void gvPoOrderSearch1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoOrderSearch1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvPoOrderSearch1_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtPoRequisitionNo.Text = gvPoOrderSearch1.SelectedRow.Cells[0].Text;
            gvPoOrderSearch1.Visible = false;

            lblPoRequisitionNo.Style["margin-top"] = "0px";
            lblPoRequisitionNo.Style["position"] = "relative";
            lblPoRequisitionNo.Style["margin-left"] = "0px";

            txtPoNumber.Text = "";
            txtIssueDate.Text = "";
            txtDeliveryDate.Text = "";

            searchPoOrderRecordMain();
            searchPoRequisitionInfo();
        }

        protected void txtPoNumber_TextChanged(object sender, EventArgs e)
        {
            txtPoNumber.Focus();

            lblPoNo.Style["margin-top"] = "-31px";
            lblPoNo.Style["position"] = "absolute";
            lblPoNo.Style["margin-left"] = "-90px";

            PoOrderBLL objPoTrackingBLL = new PoOrderBLL();

            DataTable dt = new DataTable();
            string PoNo = "";
            PoNo = txtPoNumber.Text;

            dt = objPoTrackingBLL.SearchPoNo(PoNo, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvPoOrderSearch2.Visible = true;

                gvPoOrderSearch2.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoOrderSearch2.DataBind();

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoOrderSearch2.DataSource = dt;
                gvPoOrderSearch2.DataBind();
                int totalcolums = gvPoOrderSearch2.Rows[0].Cells.Count;
                gvPoOrderSearch2.Rows[0].Cells.Clear();
                gvPoOrderSearch2.Rows[0].Cells.Add(new TableCell());
                gvPoOrderSearch2.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoOrderSearch2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }

        protected void gvPoOrderSearch2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoOrderSearch2, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvPoOrderSearch2_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtPoNumber.Text = gvPoOrderSearch2.SelectedRow.Cells[0].Text;
            gvPoOrderSearch2.Visible = false;

            lblPoNo.Style["margin-top"] = "0px";
            lblPoNo.Style["position"] = "relative";
            lblPoNo.Style["margin-left"] = "0px";
            
            searchPoOrderRecordFinalMain();
            searchPoOrderRecord();
        }
    }
}