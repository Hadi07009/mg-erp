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
using System.Web.Services;
using System.Web.Script.Services;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PoTracking : System.Web.UI.Page
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
                SecondGridViewRow();



            }

            if (IsPostBack)
            {

                loadSesscion();

            }

             txtPoNo.Focus();
           
        }


        #region "Function"
    

        private void FirstGridViewRow()
        {


            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("PARTICULAR_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("PART_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_UNIT_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("APPROVED_QTY", typeof(string)));
            dt.Columns.Add(new DataColumn("SHIP_QTY", typeof(string)));
            dt.Columns.Add(new DataColumn("REMAINING_QTY", typeof(string)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("BL_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("SHIPMENT_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("ETA_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("DOC_RECEVING_DATE", typeof(string))); 
            dt.Columns.Add(new DataColumn("DOC_HANDOVER_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("SHIP_DELIVERY_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string))); 

            dr = dt.NewRow();

            dr["PARTICULAR_NAME"] = string.Empty;
            dr["PART_NO"] = string.Empty;
            dr["PO_UNIT_NAME"] = string.Empty;
            dr["APPROVED_QTY"] = string.Empty;
            dr["SHIP_QTY"] = string.Empty;
            dr["REMAINING_QTY"] = string.Empty;
            dr["PRICE"] = string.Empty;
            dr["BL_NO"] = string.Empty;
            dr["SHIPMENT_DATE"] = string.Empty;
            dr["ETA_DATE"] = string.Empty;
            dr["DOC_RECEVING_DATE"] = string.Empty;
            dr["DOC_HANDOVER_DATE"] = string.Empty;
            dr["SHIP_DELIVERY_DATE"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;


            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvPoTracking3.DataSource = dt;
            gvPoTracking3.DataBind();
        }

        private void SecondGridViewRow()
        {


            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("ADVANCE_AMOUNT", typeof(string)));
            dt.Columns.Add(new DataColumn("PAYMENT_DATE", typeof(string)));

            dr = dt.NewRow();

            dr["TRAN_ID"] = string.Empty;
            dr["ADVANCE_AMOUNT"] = string.Empty;
            dr["PAYMENT_DATE"] = string.Empty;



            dt.Rows.Add(dr);

            ViewState["CurrentTable4"] = dt;

            gvPoTracking4.DataSource = dt;
            gvPoTracking4.DataBind();
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

                        TextBox txtProductDescription = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[0].FindControl("txtProductDescription");
                        TextBox txtPartNo = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                        TextBox txtPoUnitName = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[2].FindControl("txtPoUnitName");
                        TextBox txtApprovedQty = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[3].FindControl("txtApprovedQty");
                        TextBox txtShipQuantity = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[4].FindControl("txtShipQuantity");
                        TextBox txtReminingQuantity = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[5].FindControl("txtReminingQuantity");
                        TextBox txtPrice = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[6].FindControl("txtPrice");
                        TextBox txtBlNo = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[7].FindControl("txtBlNo");
                        TextBox dtpShipmentDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[8].FindControl("dtpShipmentDate");
                        TextBox dtpEtaDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[9].FindControl("dtpEtaDate");
                        TextBox dtpDocRecevingDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[10].FindControl("dtpDocRecevingDate");
                        TextBox dtpDocHandoverDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[11].FindControl("dtpDocHandoverDate");
                        TextBox dtpShipDeliveryDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[12].FindControl("dtpShipDeliveryDate");
                        Label lblTranId = (Label)gvPoTracking3.Rows[rowIndex].Cells[13].FindControl("lblTranId");



                        drCurrentRow = dtCurrentTable.NewRow();

                        if (i < dtCurrentTable.Rows.Count)
                        {
                            dtCurrentTable.Rows[i - 1]["PARTICULAR_NAME"] = txtProductDescription.Text;
                            dtCurrentTable.Rows[i - 1]["PART_NO"] = txtPartNo.Text;
                            dtCurrentTable.Rows[i - 1]["PO_UNIT_NAME"] = txtPoUnitName.Text;
                            dtCurrentTable.Rows[i - 1]["APPROVED_QTY"] = txtApprovedQty.Text;           
                            dtCurrentTable.Rows[i - 1]["SHIP_QTY"] = txtShipQuantity.Text;
                            dtCurrentTable.Rows[i - 1]["REMAINING_QTY"] = txtReminingQuantity.Text;
                            dtCurrentTable.Rows[i - 1]["PRICE"] = txtPrice.Text;
                            dtCurrentTable.Rows[i - 1]["BL_NO"] = txtBlNo.Text;
                            dtCurrentTable.Rows[i - 1]["SHIPMENT_DATE"] = dtpShipmentDate.Text;
                            dtCurrentTable.Rows[i - 1]["ETA_DATE"] = dtpEtaDate.Text;
                            dtCurrentTable.Rows[i - 1]["DOC_RECEVING_DATE"] = dtpDocRecevingDate.Text;
                            dtCurrentTable.Rows[i - 1]["DOC_HANDOVER_DATE"] = dtpDocHandoverDate.Text;
                            dtCurrentTable.Rows[i - 1]["SHIP_DELIVERY_DATE"] = dtpShipDeliveryDate.Text;
                            dtCurrentTable.Rows[i - 1]["TRAN_ID"] = lblTranId.Text;
                        }
                        else if (i == dtCurrentTable.Rows.Count)
                        {
                            foreach (GridViewRow row in gvPoTracking3.Rows)
                            {
                                CheckBox chkPartNo = (row.Cells[0].FindControl("chkPartNo") as CheckBox);
                                if (chkPartNo.Checked)
                                {
                                    dtCurrentTable.Rows.Add(drCurrentRow);
                                    ViewState["CurrentTable"] = dtCurrentTable;
                                    gvPoTracking3.DataSource = dtCurrentTable;
                                    gvPoTracking3.DataBind();

                                    txtProductDescription = (row.Cells[1].FindControl("txtProductDescription") as TextBox);
                                    txtPartNo = (row.Cells[2].FindControl("txtPartNo") as TextBox);
                                    txtPoUnitName = (row.Cells[3].FindControl("txtPoUnitName") as TextBox);
                                    txtApprovedQty = (row.Cells[4].FindControl("txtApprovedQty") as TextBox);
                                    txtShipQuantity = (row.Cells[5].FindControl("txtShipQuantity") as TextBox);
                                    txtReminingQuantity = (row.Cells[6].FindControl("txtReminingQuantity") as TextBox);
                                    txtPrice = (row.Cells[7].FindControl("txtPrice") as TextBox);
                                    txtBlNo = (row.Cells[8].FindControl("txtBlNo") as TextBox);
                                    dtpShipmentDate = (row.Cells[9].FindControl("dtpShipmentDate") as TextBox);
                                    dtpEtaDate = (row.Cells[10].FindControl("dtpEtaDate") as TextBox);
                                    dtpDocRecevingDate = (row.Cells[11].FindControl("dtpDocRecevingDate") as TextBox);
                                    dtpDocHandoverDate = (row.Cells[12].FindControl("dtpDocHandoverDate") as TextBox);
                                    dtpShipDeliveryDate = (row.Cells[13].FindControl("dtpShipDeliveryDate") as TextBox);
                                    lblTranId = (row.Cells[14].FindControl("lblTranId") as Label);

                                    dtCurrentTable.Rows[i]["PARTICULAR_NAME"] = txtProductDescription.Text;
                                    dtCurrentTable.Rows[i]["PART_NO"] = txtPartNo.Text;
                                    dtCurrentTable.Rows[i]["PO_UNIT_NAME"] = txtPoUnitName.Text;
                                    dtCurrentTable.Rows[i]["APPROVED_QTY"] = txtReminingQuantity.Text;
                                    txtShipQuantity.Text = "";
                                    dtCurrentTable.Rows[i]["SHIP_QTY"] = txtShipQuantity.Text;
                                    txtReminingQuantity.Text = "";
                                    dtCurrentTable.Rows[i]["REMAINING_QTY"] = txtReminingQuantity.Text;
                                    dtCurrentTable.Rows[i]["PRICE"] = txtPrice.Text;
                                    dtCurrentTable.Rows[i]["BL_NO"] = txtBlNo.Text;
                                    dtpShipmentDate.Text = "";
                                    dtCurrentTable.Rows[i]["SHIPMENT_DATE"] = dtpShipmentDate.Text;
                                    dtpEtaDate.Text = "";
                                    dtCurrentTable.Rows[i]["ETA_DATE"] = dtpEtaDate.Text;
                                    dtpDocRecevingDate.Text = "";
                                    dtCurrentTable.Rows[i]["DOC_RECEVING_DATE"] = dtpDocRecevingDate.Text;
                                    dtpDocHandoverDate.Text = "";
                                    dtCurrentTable.Rows[i]["DOC_HANDOVER_DATE"] = dtpDocHandoverDate.Text;
                                    dtpShipDeliveryDate.Text = "";
                                    dtCurrentTable.Rows[i]["SHIP_DELIVERY_DATE"] = dtpShipDeliveryDate.Text;
                                    dtCurrentTable.Rows[i]["TRAN_ID"] =i+1;


                                }
                            }

                        }
                        

                        rowIndex++;
                    }

                    //dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvPoTracking3.DataSource = dtCurrentTable;
                    gvPoTracking3.DataBind();

                    //TextBox strtxtPartNo = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                    //strtxtPartNo.Focus();


                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        private void AddNewRowAdvance()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable4"] != null)
            {
                DataTable dtCurrentTable4 = (DataTable)ViewState["CurrentTable4"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable4.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable4.Rows.Count; i++)
                    {

                        TextBox txtTranId = (TextBox)gvPoTracking4.Rows[rowIndex].Cells[0].FindControl("txtTranId");
                        TextBox txtAdvanceAmount = (TextBox)gvPoTracking4.Rows[rowIndex].Cells[1].FindControl("txtAdvanceAmount");
                        TextBox dtpPaymentDate = (TextBox)gvPoTracking4.Rows[rowIndex].Cells[2].FindControl("dtpPaymentDate");


                        drCurrentRow = dtCurrentTable4.NewRow();

                        dtCurrentTable4.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;
                        dtCurrentTable4.Rows[i - 1]["ADVANCE_AMOUNT"] = txtAdvanceAmount.Text;
                        dtCurrentTable4.Rows[i - 1]["PAYMENT_DATE"] = dtpPaymentDate.Text;

                        rowIndex++;

                    }


                    
                }

                dtCurrentTable4.Rows.Add(drCurrentRow);
                ViewState["CurrentTable4"] = dtCurrentTable4;
                gvPoTracking4.DataSource = dtCurrentTable4;
                gvPoTracking4.DataBind();

            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
        }

        //private void SetPreviousData()
        //{
        //    int rowIndex2 = 0;
        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dt = (DataTable)ViewState["CurrentTable"];
        //        if (dt.Rows.Count > 0)
        //        {
        //            for (int i = 1; i <= dt.Rows.Count; i++)
        //            {
        //                if (rowIndex2 < gvPoTracking3.Rows.Count)
        //                {
        //                    TextBox txtProductDescription = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[0].FindControl("txtProductDescription");
        //                    TextBox txtPartNo = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[1].FindControl("txtPartNo");
        //                    TextBox txtPoUnitName = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[2].FindControl("txtPoUnitName");
        //                    TextBox txtApprovedQty = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[3].FindControl("txtApprovedQty");
        //                    TextBox txtShipQuantity = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[4].FindControl("txtShipQuantity");
        //                    TextBox txtReminingQuantity = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[5].FindControl("txtReminingQuantity");
        //                    TextBox dtpShipmentDate = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[6].FindControl("dtpShipmentDate");
        //                    TextBox txtPrice = (TextBox)gvPoTracking3.Rows[rowIndex2].Cells[7].FindControl("txtPrice");
        //                    Label lblTranId = (Label)gvPoTracking3.Rows[rowIndex2].Cells[8].FindControl("lblTranId");
                        

        //                if (i < dt.Rows.Count)
        //                {
        //                    txtProductDescription.Text = dt.Rows[i-1]["PARTICULAR_NAME"].ToString();
        //                    txtPartNo.Text = dt.Rows[i-1]["PART_NO"].ToString();
        //                    txtPoUnitName.Text = dt.Rows[i-1]["PO_UNIT_NAME"].ToString();
        //                    txtApprovedQty.Text = dt.Rows[i-1]["APPROVED_QTY"].ToString();
        //                    txtPrice.Text = dt.Rows[i-1]["PRICE"].ToString();
        //                    txtShipQuantity.Text = dt.Rows[i-1]["SHIP_QTY"].ToString();
        //                    txtReminingQuantity.Text = dt.Rows[i-1]["REMAINING_QTY"].ToString();
        //                    dtpShipmentDate.Text = dt.Rows[i-1]["SHIPMENT_DATE"].ToString();
        //                    lblTranId.Text = dt.Rows[i-1]["TRAN_ID"].ToString();
        //                }

        //                else if (i == dt.Rows.Count)
        //                {
        //                    foreach (GridViewRow row in gvPoTracking3.Rows)
        //                    {
        //                        CheckBox chkPartNo = (row.Cells[0].FindControl("chkPartNo") as CheckBox);
        //                        if (chkPartNo.Checked)
        //                        {
        //                            txtProductDescription.Text = row.Cells[1].Text;
        //                            txtPartNo.Text = row.Cells[2].Text;
        //                            txtPoUnitName.Text = row.Cells[3].Text;
        //                            txtApprovedQty.Text = row.Cells[4].Text;
        //                            txtPrice.Text = row.Cells[5].Text;
        //                            txtShipQuantity.Text = row.Cells[6].Text;
        //                            txtReminingQuantity.Text = row.Cells[7].Text;
        //                            dtpShipmentDate.Text = row.Cells[8].Text;
        //                            lblTranId.Text = "";
        //                        }
        //                    }
                            
        //                }
        //                }

        //                rowIndex2++;

        //            }
        //        }
        //    }
        //}


        public void savePoTrackingInfo()
        {

            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();


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

                        TextBox txtProductDescription = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[0].FindControl("txtProductDescription");
                        TextBox txtPartNo = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                        TextBox txtPoUnitName = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[2].FindControl("txtPoUnitName");
                        TextBox txtApprovedQty = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[3].FindControl("txtApprovedQty");
                        TextBox txtShipQuantity = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[4].FindControl("txtShipQuantity");
                        TextBox txtReminingQuantity = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[5].FindControl("txtReminingQuantity");
                        TextBox txtPrice = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[6].FindControl("txtPrice");
                        TextBox txtBlNo = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[7].FindControl("txtBlNo");
                        TextBox dtpShipmentDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[8].FindControl("dtpShipmentDate");
                        TextBox dtpEtaDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[9].FindControl("dtpEtaDate");
                        TextBox dtpDocRecevingDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[10].FindControl("dtpDocRecevingDate");
                        TextBox dtpDocHandoverDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[11].FindControl("dtpDocHandoverDate");
                        TextBox dtpShipDeliveryDate = (TextBox)gvPoTracking3.Rows[rowIndex].Cells[12].FindControl("dtpShipDeliveryDate");
                        Label lblTranId = (Label)gvPoTracking3.Rows[rowIndex].Cells[13].FindControl("lblTranId");

                        objPoTrackingDTO.PoNumber = txtPoNo.Text;
                        objPoTrackingDTO.Discount = txtDiscount.Text;
                        if (txtTotalAmount.Text.Length > 0)
                        {

                            objPoTrackingDTO.TotalAmount = txtTotalAmount.Text;
                        }
                        else
                        {
                            objPoTrackingDTO.TotalAmount = "0";

                        }
                        if (txtBalance.Text.Length > 0)
                        {

                            objPoTrackingDTO.Balance = txtBalance.Text;
                        }
                        else
                        {
                            objPoTrackingDTO.Balance = "0";

                        }


                        objPoTrackingDTO.ProductDescription = txtProductDescription.Text;
                        objPoTrackingDTO.PartNo = txtPartNo.Text;
                        objPoTrackingDTO.PoUnitName = txtPoUnitName.Text;
                        objPoTrackingDTO.ApprovedQty = txtApprovedQty.Text;
                        objPoTrackingDTO.Price = txtPrice.Text;
                        objPoTrackingDTO.ReminingQuantity = txtReminingQuantity.Text;
                        objPoTrackingDTO.ShipQuantity = txtShipQuantity.Text;
                        objPoTrackingDTO.ShipmentDate = dtpShipmentDate.Text;

                        objPoTrackingDTO.BlNo = txtBlNo.Text;
                        objPoTrackingDTO.EtaDate = dtpEtaDate.Text;
                        objPoTrackingDTO.DocRecevingDate = dtpDocRecevingDate.Text;
                        objPoTrackingDTO.DocHandoverDate = dtpDocHandoverDate.Text;
                        objPoTrackingDTO.ShipDeliveryDate = dtpShipDeliveryDate.Text;
                        objPoTrackingDTO.TranId = lblTranId.Text;

                        objPoTrackingDTO.UpdateBy = strEmployeeId;
                        objPoTrackingDTO.HeadOfficeId = strHeadOfficeId;
                        objPoTrackingDTO.BranchOfficeId = strBranchOfficeId;

                        strMsg = objPoTrackingBLL.savePoTrackingInfo(objPoTrackingDTO);
                        // MessageBox(strMsg);
                        //lblMsg.Text = strMsg;

                        rowIndex++;


                    }

                    if (strMsg != "UPDATED SUCCESSFULLY" )
                    {
                        string input = strMsg;
                        string subStr = input.Substring(22);
                        txtPoNo.Text = subStr;
                        MessageBox(strMsg);
                    }

                   

                    else
                    {

                        MessageBox(strMsg);

                    }
                }
            }
         }
        public void savePoTrackingAdvanceInfo()
        {


          

            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();


            int rowIndex = 0;
            string strMsg = "";
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable4"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable4"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //if (i == dtCurrentTable.Rows.Count)
                        //{
                        TextBox txtTranId = (TextBox)gvPoTracking4.Rows[rowIndex].Cells[0].FindControl("txtTranId");
                        TextBox txtAdvanceAmount = (TextBox)gvPoTracking4.Rows[rowIndex].Cells[1].FindControl("txtAdvanceAmount");
                        TextBox dtpPaymentDate = (TextBox)gvPoTracking4.Rows[rowIndex].Cells[2].FindControl("dtpPaymentDate");

                        if (dtpPaymentDate.Text == "")
                        {
                            
                          
                           lblMsg.Text = "Please Enter Payment Date!!!";
                           dtpPaymentDate.Focus();
                           return;

                        }

                        else if (txtAdvanceAmount.Text == "")
                        {


                            lblMsg.Text = "Please Enter Payment Aount!!!";
                            txtAdvanceAmount.Focus();
                            return;

                        }
                        else
                        {

                            objPoTrackingDTO.TranId = txtTranId.Text;
                            objPoTrackingDTO.PoNumber = txtPoNo.Text;
                            if (txtAdvanceAmount.Text.Length > 0)
                            {

                                objPoTrackingDTO.AdvanceAmount = txtAdvanceAmount.Text;
                            }
                            else
                            {
                                objPoTrackingDTO.AdvanceAmount = "";

                            }

                            objPoTrackingDTO.PaymentDate = dtpPaymentDate.Text;

                            objPoTrackingDTO.UpdateBy = strEmployeeId;
                            objPoTrackingDTO.HeadOfficeId = strHeadOfficeId;
                            objPoTrackingDTO.BranchOfficeId = strBranchOfficeId;

                            strMsg = objPoTrackingBLL.savePoTrackingAdvanceInfo(objPoTrackingDTO);
                        }

                          
                            //MessageBox(strMsg);
                            //lblMsg.Text = strMsg; 
                        //}
                        rowIndex++;

                    }

                    //MessageBox(strMsg);
  
                }
            }
        }
        public void searchPoTotalAmount()
        {
            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

            string strPoNumber;
            if (txtPoNo.Text.Length > 0)
            {

                strPoNumber = txtPoNo.Text;
            }
            else
            {
                strPoNumber = "";

            }


            objPoTrackingDTO = objPoTrackingBLL.searchPoTotalAmount(strPoNumber, strHeadOfficeId, strBranchOfficeId);

            if (objPoTrackingDTO.Freight == "0")
            {
                txtFreight.Text = "0";
            }
            else
            {
                txtFreight.Text = objPoTrackingDTO.Freight;
            }
            if (objPoTrackingDTO.TrackingChargeFee == "0")
            {
                txtTrackingChargeFee.Text = "0";
            }
            else
            {
                txtTrackingChargeFee.Text = objPoTrackingDTO.TrackingChargeFee;
            }

            if (objPoTrackingDTO.Discount == "0")
            {
                txtDiscount.Text = "0";
            }
            else
            {
                txtDiscount.Text = objPoTrackingDTO.Discount;
            }

            if (objPoTrackingDTO.TotalAmount == "0")
            {
                txtTotalAmount.Text = "0";
            }
            else
            {
                txtTotalAmount.Text = objPoTrackingDTO.TotalAmount;
            }

            if (objPoTrackingDTO.Balance == "0")
            {
                txtBalance.Text = "0";
            }
            else
            {
                txtBalance.Text = objPoTrackingDTO.Balance;
            }
            
        }
        public void searchPoTrackingMainOne()
        {
            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

            DataTable dt = new DataTable();


            string strPoNo = ""; 

            if (txtPoNo.Text.Length > 0)
            {

                strPoNo = txtPoNo.Text;
            }
            else
            {
                strPoNo = "";

            }

            dt = objPoTrackingBLL.searchPoTrackingMainOne(strPoNo, strHeadOfficeId, strBranchOfficeId);

            if (dt.Rows.Count > 0)
            {
                gvPoTracking1.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoTracking1.DataBind();

                int count = ((DataTable)gvPoTracking1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoTracking1.DataSource = dt;
                gvPoTracking1.DataBind();
                int totalcolums = gvPoTracking1.Rows[0].Cells.Count;
                gvPoTracking1.Rows[0].Cells.Clear();
                gvPoTracking1.Rows[0].Cells.Add(new TableCell());
                gvPoTracking1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoTracking1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

      

        }
        public void searchPoTrackingMainTwo()
        {
            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

            DataTable dt = new DataTable();


            string strPoNo = "";


            if (txtPoNo.Text.Length > 0)
            {

                strPoNo = txtPoNo.Text;
            }
            else
            {
                strPoNo = "";

            }

            dt = objPoTrackingBLL.searchPoTrackingMainTwo(strPoNo, strHeadOfficeId, strBranchOfficeId);

            if (dt.Rows.Count > 0)
            {
                gvPoTracking2.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoTracking2.DataBind();

                int count = ((DataTable)gvPoTracking2.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoTracking2.DataSource = dt;
                gvPoTracking2.DataBind();
                int totalcolums = gvPoTracking2.Rows[0].Cells.Count;
                gvPoTracking2.Rows[0].Cells.Clear();
                gvPoTracking2.Rows[0].Cells.Add(new TableCell());
                gvPoTracking2.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoTracking2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }



        }
        public void LoadPoTrackingRecord()
        {
           // PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

            DataTable dt = new DataTable();

            dt = objPoTrackingBLL.LoadPoTrackingRecord(txtPoNo.Text, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvPoTracking3.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoTracking3.DataBind();

                int count = ((DataTable)gvPoTracking3.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoTracking3.DataSource = dt;
                gvPoTracking3.DataBind();
                int totalcolums = gvPoTracking3.Rows[0].Cells.Count;
                gvPoTracking3.Rows[0].Cells.Clear();
                gvPoTracking3.Rows[0].Cells.Add(new TableCell());
                gvPoTracking3.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoTracking3.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        public void LoadPoTrackingAdvanceInfo()
        {
            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

            string strPoNumber;
            if (txtPoNo.Text.Length > 0)
            {

                strPoNumber = txtPoNo.Text;
            }
            else
            {
                strPoNumber = "";

            }
            DataTable dt = new DataTable();
            dt = objPoTrackingBLL.LoadPoTrackingAdvanceInfo(strPoNumber, strHeadOfficeId, strBranchOfficeId);

            gvPoTracking4.Columns[0].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvPoTracking4.DataSource = dt;
                ViewState["CurrentTable4"] = dt;
                gvPoTracking4.DataBind();
                gvPoTracking4.Columns[0].Visible = false;
                int count = ((DataTable)gvPoTracking4.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoTracking4.DataSource = dt;
                ViewState["CurrentTable4"] = dt;
                gvPoTracking4.DataBind();
                gvPoTracking4.Columns[0].Visible = false;
                //int totalcolums = gvPoTracking4.Rows[0].Cells.Count;
                //gvPoTracking4.Rows[0].Cells.Clear();
                //gvPoTracking4.Rows[0].Cells.Add(new TableCell());
                //gvPoTracking4.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //gvPoTracking4.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                //string strMsg = "NO RECORD FOUND!!!";
                ////MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtPoNo.Text == " ")
            {
                string strMsg = "Please Enter Po Number!!!";
                MessageBox(strMsg);
                txtPoNo.Focus();
                return;

            }
            else
            {
                searchPoTotalAmount();
                searchPoTrackingMainOne();
                searchPoTrackingMainTwo();
                LoadPoTrackingRecord();
                LoadPoTrackingAdvanceInfo();
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
        protected void btnRowAdd_Click(object sender, EventArgs e)
        {
            AddNewRowAdvance();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPoNo.Text == " ")
            {
                string strMsg = "Please Enter Po Number!!!";
                MessageBox(strMsg);
                txtPoNo.Focus();
                return;

            }
            else
            {
                savePoTrackingInfo();
                savePoTrackingAdvanceInfo();
                searchPoTotalAmount();
                LoadPoTrackingRecord();
                LoadPoTrackingAdvanceInfo();

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
            gvPoTracking3.PageIndex = e.NewPageIndex;

        }

        protected void gvPoTracking3_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvPoTracking3_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvPoTracking3_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        }

        protected void gvPoTracking3_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                try
                {
                    {
                        //PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
                        //PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

                        //objPoTrackingDTO.HeadOfficeId = strHeadOfficeId;
                        //objPoTrackingDTO.BranchOfficeId = strBranchOfficeId;

                        //DropDownList a = (e.Row.FindControl("ddlPartNo") as DropDownList);

                        //DataTable dt = new DataTable();
                        //DataRowView dr = e.Row.DataItem as DataRowView;

                        //dt = objPoTrackingBLL.getPartNo(strHeadOfficeId, strBranchOfficeId);
                        //a.DataSource = dt;
                        //a.DataBind();
                        //a.SelectedValue = dr["SPARE_PART_CATEGORY_ID"].ToString();


                    }
                }
            catch(Exception ex)
                {
            
                }

        }


        #endregion


        protected void gvPoTracking3_OnSelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
           
        }


        protected void gvSrcPoTracking_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void gvPoTracking3_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }


        protected void gvPoSearch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoSearch, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvPoSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtPoNo.Text = gvPoSearch.SelectedRow.Cells[0].Text;
            gvPoSearch.Visible = false;

            searchPoTotalAmount();
            searchPoTrackingMainOne();
            searchPoTrackingMainTwo();
            LoadPoTrackingRecord();
            LoadPoTrackingAdvanceInfo();
        }


        protected void gvPoTracking4_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           
            string strTranId = gvPoTracking4.DataKeys[e.RowIndex].Value.ToString();

            deletePoRequisitionRecord(strTranId);
            LoadPoTrackingRecord();
            LoadPoTrackingAdvanceInfo();
        }
        public void deletePoRequisitionRecord(string strTranId)
        {
            PoTrackingDTO objPoTrackingDTO = new PoTrackingDTO();
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

            objPoTrackingDTO.TranId = strTranId;
                      
            objPoTrackingDTO.UpdateBy = strEmployeeId;
            objPoTrackingDTO.HeadOfficeId = strHeadOfficeId;
            objPoTrackingDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objPoTrackingBLL.deletePoTrackingSubAdvancedRecord(objPoTrackingDTO);
            MessageBox(strMsg);
        }


        protected void txtPoNo_TextChanged(object sender, EventArgs e)
        {
            PoTrackingBLL objPoTrackingBLL = new PoTrackingBLL();

            DataTable dt = new DataTable();
            string PoNo = "";
            PoNo = txtPoNo.Text;

            dt = objPoTrackingBLL.SearchPoNo(PoNo, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvPoSearch.Visible = true;

                gvPoSearch.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoSearch.DataBind();

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoSearch.DataSource = dt;
                gvPoSearch.DataBind();
                int totalcolums = gvPoSearch.Rows[0].Cells.Count;
                gvPoSearch.Rows[0].Cells.Clear();
                gvPoSearch.Rows[0].Cells.Add(new TableCell());
                gvPoSearch.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoSearch.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }

    }
}