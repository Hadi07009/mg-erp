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
using System.Drawing;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PoRequisition : System.Web.UI.Page
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

                getSectionId();



             
            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            //txtRequisitionNo.Focus();
            txtRequisitionNo.Attributes.Add("onkeypress", "return controlEnter('" + txtPurchaseDate.ClientID + "', event)");
            txtPurchaseDate.Attributes.Add("onkeypress", "return controlEnter('" + ddlSectionId.ClientID + "', event)");

        }


        #region "Function"

        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {

                ddlSectionId.SelectedIndex = 0;
            }

        }
    

        private void FirstGridViewRow()
        {


            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("PART_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("PARTICULAR_NAME", typeof(string)));
            dt.Columns.Add(new DataColumn("PO_UNIT_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("PRESENT_STOCK", typeof(string)));
            dt.Columns.Add(new DataColumn("REQUIRED_QTY", typeof(string)));
            dt.Columns.Add(new DataColumn("APPROVED_QTY", typeof(string)));
            dt.Columns.Add(new DataColumn("RATE", typeof(string)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(string)));

            dt.Columns.Add(new DataColumn("CURRENCY_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("REMARKS", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));        

            dr = dt.NewRow();

            dr["PART_NO"] = string.Empty;
            dr["PARTICULAR_NAME"] = string.Empty;
            dr["PO_UNIT_ID"] = string.Empty;
            dr["PRESENT_STOCK"] = string.Empty;
            dr["REQUIRED_QTY"] = string.Empty;
            dr["APPROVED_QTY"] = string.Empty;
            dr["RATE"] = string.Empty;
            dr["PRICE"] = string.Empty;
            dr["CURRENCY_ID"] = string.Empty;
            dr["REMARKS"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;


            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvPoRequisition.DataSource = dt;
            gvPoRequisition.DataBind();
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

                        TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                        TextBox txtPartName = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[2].FindControl("txtPartName");
                        DropDownList ddlPoUnitId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[3].FindControl("ddlPoUnitId");
                        TextBox txtPresentStock = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[4].FindControl("txtPresentStock");
                        TextBox txtRequiredQty = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[5].FindControl("txtRequiredQty");
                        TextBox txtAppearedQty = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[6].FindControl("txtAppearedQty");
                        TextBox txtRate = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[7].FindControl("txtRate");
                        TextBox txtPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[8].FindControl("txtPrice");

                        DropDownList ddlCurrencyId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[9].FindControl("ddlCurrencyId");
                        TextBox txtRemarks = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[10].FindControl("txtRemarks");
                        Label lblSLNO = (Label)gvPoRequisition.Rows[rowIndex].Cells[11].FindControl("lblSLNO");



                        drCurrentRow = dtCurrentTable.NewRow();
                        //drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["PART_NO"] = txtPartNo.Text;
                        dtCurrentTable.Rows[i - 1]["PARTICULAR_NAME"] = txtPartName.Text;
                        dtCurrentTable.Rows[i - 1]["PO_UNIT_ID"] = ddlPoUnitId.Text;
                        dtCurrentTable.Rows[i - 1]["PRESENT_STOCK"] = txtPresentStock.Text;
                        dtCurrentTable.Rows[i - 1]["REQUIRED_QTY"] = txtRequiredQty.Text;
                        dtCurrentTable.Rows[i - 1]["APPROVED_QTY"] = txtAppearedQty.Text;
                        dtCurrentTable.Rows[i - 1]["RATE"] = txtRate.Text;
                        dtCurrentTable.Rows[i - 1]["PRICE"] = txtPrice.Text;
                        dtCurrentTable.Rows[i - 1]["CURRENCY_ID"] = ddlCurrencyId.Text;
                        dtCurrentTable.Rows[i - 1]["REMARKS"] = txtRemarks.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = dtCurrentTable.Rows[i - 1]["TRAN_ID"];

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvPoRequisition.DataSource = dtCurrentTable;
                    gvPoRequisition.DataBind();

                    TextBox strtxtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                    strtxtPartNo.Focus();

                    
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            //SetPreviousData();
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


                        TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                        TextBox txtPartName = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[2].FindControl("txtPartName");
                        DropDownList ddlPoUnitId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[3].FindControl("ddlPoUnitId");
                        TextBox txtPresentStock = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[4].FindControl("txtPresentStock");
                        TextBox txtRequiredQty = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[5].FindControl("txtRequiredQty");
                        TextBox txtAppearedQty = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[6].FindControl("txtAppearedQty");
                        TextBox txtRate = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[7].FindControl("txtRate");
                        TextBox txtPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[8].FindControl("txtPrice");
                        DropDownList ddlCurrencyId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[9].FindControl("ddlCurrencyId");

                        TextBox txtRemarks = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[10].FindControl("txtRemarks");
                        Label lblSLNO = (Label)gvPoRequisition.Rows[rowIndex].Cells[11].FindControl("lblSLNO");


                        txtPartNo.Text = dt.Rows[i]["PART_NO"].ToString();
                        txtPartName.Text = dt.Rows[i]["PARTICULAR_NAME"].ToString();
                        ddlPoUnitId.Text = dt.Rows[i]["PO_UNIT_ID"].ToString();
                        txtPresentStock.Text = dt.Rows[i]["PRESENT_STOCK"].ToString();
                        txtRequiredQty.Text = dt.Rows[i]["REQUIRED_QTY"].ToString();
                        txtAppearedQty.Text = dt.Rows[i]["APPROVED_QTY"].ToString();
                        txtRate.Text = dt.Rows[i]["RATE"].ToString();
                        txtPrice.Text = dt.Rows[i]["PRICE"].ToString();
                        ddlCurrencyId.Text = dt.Rows[i]["CURRENCY_ID"].ToString();
                        txtRemarks.Text = dt.Rows[i]["REMARKS"].ToString();
                        lblSLNO.Text = dt.Rows[i]["TRAN_ID"].ToString();

                        rowIndex++;

                    }
                }
            }
        }


        public void savePoRequisitionInfo()
        {

            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();


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
                        TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[1].FindControl("txtPartNo");
                        TextBox txtPartName = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[2].FindControl("txtPartName");
                        DropDownList ddlPoUnitId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[3].FindControl("ddlPoUnitId");
                        TextBox txtPresentStock = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[4].FindControl("txtPresentStock");
                        TextBox txtRequiredQty = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[5].FindControl("txtRequiredQty");
                        TextBox txtAppearedQty = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[6].FindControl("txtAppearedQty");
                        TextBox txtRate = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[7].FindControl("txtRate");
                        TextBox txtPrice = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[8].FindControl("txtPrice");
                        DropDownList ddlCurrencyId = (DropDownList)gvPoRequisition.Rows[rowIndex].Cells[9].FindControl("ddlCurrencyId");

                        TextBox txtRemarks = (TextBox)gvPoRequisition.Rows[rowIndex].Cells[10].FindControl("txtRemarks");
                        Label lblSLNO = (Label)gvPoRequisition.Rows[rowIndex].Cells[11].FindControl("lblSLNO");

                        objPoRequisitionDTO.RequisitionNo = txtRequisitionNo.Text;
                        

                        objPoRequisitionDTO.PurchaseDate = txtPurchaseDate.Text;

                        if (ddlSectionId.SelectedValue.ToString() != "")
                        {
                            objPoRequisitionDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoRequisitionDTO.SectionId = "";
                        }

                        if (ddlCurrencyId.SelectedValue.ToString() != " ")
                        {
                            objPoRequisitionDTO.CurrencyId = ddlCurrencyId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoRequisitionDTO.CurrencyId = "";

                        }


                        objPoRequisitionDTO.PartNo = txtPartNo.Text;
                        objPoRequisitionDTO.PartName = txtPartName.Text;

                        if (ddlPoUnitId.SelectedValue.ToString() != " ")
                        {
                            objPoRequisitionDTO.PoUnitId = ddlPoUnitId.SelectedValue.ToString();
                        }
                        else
                        {
                            objPoRequisitionDTO.PoUnitId = "";
                        }

                        
                        objPoRequisitionDTO.PresentStock = txtPresentStock.Text;
                        objPoRequisitionDTO.RequiredQty = txtRequiredQty.Text;
                        objPoRequisitionDTO.AppearedQty = txtAppearedQty.Text;
                        objPoRequisitionDTO.Rate = txtRate.Text;
                        objPoRequisitionDTO.Price = txtPrice.Text;
                        objPoRequisitionDTO.Remarks = txtRemarks.Text;
                        objPoRequisitionDTO.SLNO = lblSLNO.Text;
                        
                        objPoRequisitionDTO.Freight = txtFreight.Text;
                        objPoRequisitionDTO.TrackingChargeFee = txtTrackingChargeFee.Text;
                        objPoRequisitionDTO.Discount = txtDiscount.Text;
                        objPoRequisitionDTO.TotalAmount = txtTotalAmount.Text;

                        objPoRequisitionDTO.UpdateBy = strEmployeeId;
                        objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
                        objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objPoRequisitionBLL.savePoRequisitionInfo(objPoRequisitionDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;
                        if (strMsg != "UPDATED SUCCESSFULLY" && strMsg != "APPROVED QUANTITY CAN NOT BE LARGER THAN REQUIRED QUANTITY!!!" && strMsg != "PO ALREADY ISSUED!!!" && strMsg != "PART NO ALREADY EXISTS!!!")
                        {
                            string input = strMsg;
                            string subStr = input.Substring(22);
                            txtRequisitionNo.Text = subStr;
                           
                        }

                        if(strMsg == "PART NO ALREADY EXISTS!!!")
                        {

                            MessageBox(strMsg);
                            return;

                        }
                        if (strMsg == "APPROVED QUANTITY CAN NOT BE LARGER THAN REQUIRED QUANTITY!!!")
                        {
                            MessageBox(strMsg);
                            return;

                        }

                        if (strMsg == "APPROVED QUANTITY CAN NOT BE LARGER THAN REQUIRED QUANTITY!!!")
                        {
                            MessageBox(strMsg);
                            return;

                        }
                        if (strMsg == "PO ALREADY ISSUED!!!")
                        {
                            MessageBox(strMsg);
                            return;

                        }



                    }

                    if (strMsg != "UPDATED SUCCESSFULLY")
                    {
                        string input = strMsg;
                        string subStr = input.Substring(22);
                        txtRequisitionNo.Text = subStr;
                        MessageBox(strMsg);
                        LoadPoRequisitionRecordSub();
                    }
                    else
                    {

                        MessageBox(strMsg);

                    }

                }


            }

        }
        //public void processPoRequisitionTotalAmount()
        //{
        //    PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
        //    PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();

        //    string strMsg = "";

        //    objPoRequisitionDTO.RequisitionNo = txtRequisitionNo.Text;
        //    objPoRequisitionDTO.PurchaseDate = txtPurchaseDate.Text;
        //    objPoRequisitionDTO.Discount = txtDiscount.Text;
        //    objPoRequisitionDTO.Freight = txtFreight.Text;
        //    objPoRequisitionDTO.TotalAmount = txtTotalAmount.Text;

        //    objPoRequisitionDTO.UpdateBy = strEmployeeId;
        //    objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
        //    objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;

        //    strMsg = objPoRequisitionBLL.processPoRequisitionTotalAmount(objPoRequisitionDTO);
        //    //MessageBox(strMsg);
        //}
        public void searchPoRequisitionRecordMain()
        {
            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();

            DataTable dt = new DataTable();


            string strRequisitionNo = "";
            string strPurchaseDate = "";
            string strSectionId = "";

            if (txtRequisitionNo.Text.Length > 0)
            {

                strRequisitionNo = txtRequisitionNo.Text;
            }
            else
            {
                strRequisitionNo = "";

            }

            

            if (txtPurchaseDate.Text.Length > 6)
            {
                strPurchaseDate = txtPurchaseDate.Text;
            }
            else
            {
                strPurchaseDate = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                strSectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                strSectionId = "";

            }

            objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
            objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;

            objPoRequisitionDTO = objPoRequisitionBLL.searchPoRequisitionRecordMain(strRequisitionNo, strPurchaseDate, strSectionId, strHeadOfficeId, strBranchOfficeId);

          

            txtPurchaseDate.Text = objPoRequisitionDTO.PurchaseDate;

            if (objPoRequisitionDTO.SectionId == "0")
            {

                getSectionId();
            }
            else
            {
               
                ddlSectionId.SelectedValue = objPoRequisitionDTO.SectionId;
            }

            if (objPoRequisitionDTO.Freight == "0")
            {
                txtFreight.Text = "0";
            }
            else
            {
                txtFreight.Text = objPoRequisitionDTO.Freight;
            }
            if (objPoRequisitionDTO.TrackingChargeFee == "0")
            {
                txtTrackingChargeFee.Text = "0";
            }
            else
            {
                txtTrackingChargeFee.Text = objPoRequisitionDTO.TrackingChargeFee;
            }

            if (objPoRequisitionDTO.Discount == "0")
            {
                txtDiscount.Text = "0";
            }
            else
            {
                txtDiscount.Text = objPoRequisitionDTO.Discount;
            }

            if (objPoRequisitionDTO.TotalAmount == "0")
            {
                txtTotalAmount.Text = "0";
            }
            else
            {
                txtTotalAmount.Text = objPoRequisitionDTO.TotalAmount;
            }

            if (objPoRequisitionDTO.TotalPrice == "0")
            {
                txtTotalPrice.Text = "0";
            }
            else
            {
                txtTotalPrice.Text = objPoRequisitionDTO.TotalPrice;
            }



        }
        public void LoadPoRequisitionRecordSub()
        {
            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();

            DataTable dt = new DataTable();

            objPoRequisitionDTO.RequisitionNo = txtRequisitionNo.Text;
            objPoRequisitionDTO.PurchaseDate = txtPurchaseDate.Text;

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objPoRequisitionDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objPoRequisitionDTO.SectionId = "";
            }

            objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
            objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPoRequisitionBLL.LoadPoRequisitionRecordSub(objPoRequisitionDTO);


            if (dt.Rows.Count > 0)
            {
                gvPoRequisition.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoRequisition.DataBind();

                int count = ((DataTable)gvPoRequisition.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoRequisition.DataSource = dt;
                gvPoRequisition.DataBind();
                int totalcolums = gvPoRequisition.Rows[0].Cells.Count;
                gvPoRequisition.Rows[0].Cells.Clear();
                gvPoRequisition.Rows[0].Cells.Add(new TableCell());
                gvPoRequisition.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoRequisition.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtRequisitionNo.Text == " ")
            {
                string strMsg = "Please Enter Requisition Number!!!";
                MessageBox(strMsg);
                txtRequisitionNo.Focus();
                return;

            }
            else
            {
                searchPoRequisitionRecordMain();
                LoadPoRequisitionRecordSub();
            }
        }   
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           
            if (txtPurchaseDate.Text == "")
            {
                string strMsg = "Please Enter Purchase Date!!!";
                MessageBox(strMsg);
                txtPurchaseDate.Focus();
                return;
            }
            else if (ddlSectionId.Text == " ")
            {
                string strMsg = "Please Select Section!!!";
                MessageBox(strMsg);
                ddlSectionId.Focus();
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
                TotalAmount();
                savePoRequisitionInfo();
                LoadPoRequisitionRecordSub();
                searchPoRequisitionRecordMain();
               
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchPoRequisitionRecordMain();
            LoadPoRequisitionRecordSub();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();



            objPoRequisitionDTO.RequisitionNo = txtRequisitionNo.Text;          
            objPoRequisitionDTO.PurchaseDate = txtPurchaseDate.Text;

            objPoRequisitionDTO.UpdateBy = strEmployeeId;
            objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
            objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objPoRequisitionBLL.deletePoRequisitionRecord(objPoRequisitionDTO);
            MessageBox(strMsg);


            searchPoRequisitionRecordMain();
            LoadPoRequisitionRecordSub();
        }
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {

        }


        #region "Grid View Functionality"
        protected void gvPoRequisition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPoRequisition.PageIndex = e.NewPageIndex;

        }

        protected void gvPoRequisition_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();

            TextBox txtPartNo = (TextBox)gvPoRequisition.SelectedRow.FindControl("txtPartNo");

            lblCountgvRow.Text = gvPoRequisition.SelectedIndex.ToString();
    
                DataTable dt = new DataTable();

                objPoRequisitionDTO.PartNo = txtPartNo.Text; ;
                objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
                objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;

                dt = objPoRequisitionBLL.LoadPartNo(objPoRequisitionDTO);


                if (dt.Rows.Count > 0)
                {
                    gvPoRequisition2.Visible = true;
                    gvPoRequisition2.DataSource = dt;
                    gvPoRequisition2.DataBind();


                }
                else
                {
                    dt.Rows.Add(dt.NewRow());
                    gvPoRequisition2.DataSource = dt;
                    gvPoRequisition2.DataBind();
                    int totalcolums = gvPoRequisition2.Rows[0].Cells.Count;
                    gvPoRequisition2.Rows[0].Cells.Clear();
                    gvPoRequisition2.Rows[0].Cells.Add(new TableCell());
                    gvPoRequisition2.Rows[0].Cells[0].ColumnSpan = totalcolums;
                    gvPoRequisition2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                    string strMsg = "NO RECORD FOUND!!!";
                    //MessageBox(strMsg);
                    lblMsg.Text = strMsg;

                }


          

        }
        protected void gvPoRequisition_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
           
        }

        protected void gvPoRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        {

   
        }

        protected void gvPoRequisition_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
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



                    DropDownList c = (e.Row.FindControl("ddlCurrencyId") as DropDownList);

                    DataTable dt1 = new DataTable();
                    DataRowView dr1 = e.Row.DataItem as DataRowView;

                    dt1 = objLookUpBLL.getCurrencyId(strHeadOfficeId,strBranchOfficeId);
                    c.DataSource = dt1;
                    c.DataBind();
                    c.SelectedValue = dr1["CURRENCY_ID"].ToString();




                }
            catch(Exception ex)
                {
            
                }

            TotalAmount();
           

        }


        #endregion


        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            
                searchPoRequisitionRecordMain();
                LoadPoRequisitionRecordSub();
           
        }



        protected void gvPoRequisition_OnSelectedIndexChanged(object sender, GridViewPageEventArgs e)
        {
           
        }


        protected void gvSrcPoRequisition_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            searchPoRequisitionRecordMain();
            LoadPoRequisitionRecordSub();

        }

        protected void gvPoRequisition_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int stor_id = Convert.ToInt32(gvPoRequisition.DataKeys[e.RowIndex].Value.ToString());
            string strSlNoId = Convert.ToString(stor_id);

            deletePoRequisitionSubRecord(strSlNoId);
            searchPoRequisitionRecordMain();
            LoadPoRequisitionRecordSub();
        }
        public void deletePoRequisitionSubRecord(string strSlNoId)
        {
            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();


            
            objPoRequisitionDTO.SLNO = strSlNoId;
            objPoRequisitionDTO.RequisitionNo = txtRequisitionNo.Text;
            //if (ddlPurchaseId.SelectedValue.ToString() != "")
            //{
            //    objPoRequisitionDTO.PurchaseId = ddlPurchaseId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objPoRequisitionDTO.PurchaseId = "";
            //}

            objPoRequisitionDTO.PurchaseDate = txtPurchaseDate.Text;

            if (ddlSectionId.SelectedValue.ToString() != "")
            {
                objPoRequisitionDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objPoRequisitionDTO.SectionId = "";
            }



            objPoRequisitionDTO.UpdateBy = strEmployeeId;
            objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
            objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objPoRequisitionBLL.deletePoRequisitionSubRecord(objPoRequisitionDTO);
            MessageBox(strMsg);
        }


        //public void rptPoRequisition()
        //{

        //    ReportDTO objReportDTO = new ReportDTO();
        //    ReportBLL objReportBLL = new ReportBLL();


        //    objReportDTO.RequisitionNo = txtRequisitionNo.Text;
           
        //    objReportDTO.IssueDate = txtPurchaseDate.Text;
           

        //    if (ddlPurchaseId.SelectedValue.ToString() != " ")
        //    {
        //        objReportDTO.PurchaseId = ddlPurchaseId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objReportDTO.PurchaseId = "";
        //    }


        //    objReportDTO.HeadOfficeId = strHeadOfficeId;
        //    objReportDTO.BranchOfficeId = strBranchOfficeId;
        //    objReportDTO.UpdateBy = strEmployeeId;



        //    string strPath = Path.Combine(Server.MapPath("~/Reports/rptRequisitionForm.rpt"));
        //    this.Context.Session["strReportPath"] = strPath;
        //    rd.Load(strPath);
        //    rd.SetDataSource(objReportBLL.rptPORequisitionSheet(objReportDTO));


        //    rd.SetDatabaseLogon("erp", "erp");
        //    CrystalReportViewer1.ReportSource = rd;
        //    CrystalReportViewer1.DataBind();

        //    reportMaster();

        //    this.CrystalReportViewer1.Dispose();
        //    this.CrystalReportViewer1 = null;
        //    rd.Dispose();
        //    rd.Close();
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();



        //}

        protected void btnReport_Click(object sender, EventArgs e)
        {
            //try
            //{


            //    rptPoRequisition();

                
            //}
            //catch (Exception ex)
            //{

            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();


            //}
        }

        protected void gvPoRequisition2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoRequisition2, "Select$" + e.Row.RowIndex);
            }
        }


        public void gvPoRequisition2_SelectedIndexChanged(object sender, EventArgs e)
        {

            string txtSearchPartNo = gvPoRequisition2.SelectedRow.Cells[0].Text;
            string txtSrcPartName = gvPoRequisition2.SelectedRow.Cells[1].Text;

            int CountgvRow = Convert.ToInt32(lblCountgvRow.Text);

            TextBox txtPartNo = (TextBox)gvPoRequisition.Rows[CountgvRow].FindControl("txtPartNo");
            TextBox txtPartName = (TextBox)gvPoRequisition.Rows[CountgvRow].FindControl("txtPartName");

          
            txtPartNo.Text = txtSearchPartNo;
            txtPartName.Text = txtSrcPartName;

            TextBox strtxtPresentStock = (TextBox)gvPoRequisition.Rows[CountgvRow].FindControl("txtPresentStock");
            strtxtPresentStock.Focus();


            TotalAmount();
            gvPoRequisition2.Visible = false;

           
        }

        protected void txtRequisitionNo_TextChanged(object sender, EventArgs e)
        {
            PoRequisitionDTO objPoRequisitionDTO = new PoRequisitionDTO();
            PoRequisitionBLL objPoRequisitionBLL = new PoRequisitionBLL();

            DataTable dt = new DataTable();

            objPoRequisitionDTO.RequisitionNo = txtRequisitionNo.Text; ;
            objPoRequisitionDTO.HeadOfficeId = strHeadOfficeId;
            objPoRequisitionDTO.BranchOfficeId = strBranchOfficeId;

            dt = objPoRequisitionBLL.LoadRequisitionNo(objPoRequisitionDTO);

            txtPurchaseDate.Visible = false;
            ddlSectionId.Visible = false;

            if (dt.Rows.Count > 0)
            {
                gvPoRequisition3.Visible = true;

                gvPoRequisition3.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvPoRequisition3.DataBind();


            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPoRequisition3.DataSource = dt;
                gvPoRequisition3.DataBind();
                int totalcolums = gvPoRequisition3.Rows[0].Cells.Count;
                gvPoRequisition3.Rows[0].Cells.Clear();
                gvPoRequisition3.Rows[0].Cells.Add(new TableCell());
                gvPoRequisition3.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPoRequisition3.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }
        }
        protected void gvPoRequisition3_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Cells[0].BackColor = Color.FromName("#BAD7E6");

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPoRequisition3, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvPoRequisition3_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtRequisitionNo.Text = gvPoRequisition3.SelectedRow.Cells[0].Text;
            gvPoRequisition3.Visible = false;
            txtPurchaseDate.Visible = true;
            ddlSectionId.Visible = true;

            txtPurchaseDate.Text = "";
            getSectionId();

            searchPoRequisitionRecordMain();
            LoadPoRequisitionRecordSub();
            TotalAmount();
        }

        protected void txtFreight_TextChanged(object sender, EventArgs e)
        {          
            TotalAmount();          
        }
        protected void txtTrackingChargeFee_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            TotalAmount();
        }
        private void TotalAmount()
        {
            

            if (txtFreight.Text == "")
            {
                txtFreight.Text = "0";

            }

            if (txtTrackingChargeFee.Text == "")
            {
                txtTrackingChargeFee.Text = "0";

            }

            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";

            }

            if (txtTotalPrice.Text == "")
            {

                txtTotalPrice.Text = "0";

            }

            Double a = (Convert.ToDouble(txtFreight.Text));
            Double b = (Convert.ToDouble(txtTrackingChargeFee.Text));
            Double c = (Convert.ToDouble(txtDiscount.Text));
            Double t = (Convert.ToDouble(txtTotalPrice.Text));

            txtTotalAmount.Text = ((t + a + b) - c).ToString();
        }

        protected void txtAppearedQty_TextChanged(object sender, EventArgs e)
        {
            txtTotalPrice.Text = "0";
            TotalCalculation();
        }
        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            txtTotalPrice.Text = "0";
            TotalCalculation();
        }      
        private void TotalCalculation()
        {
           int gvPoRequisition_CountRow= gvPoRequisition.Rows.Count;
            
            if (txtFreight.Text == "")
            {
                txtFreight.Text = "0";
            }

            if (txtTrackingChargeFee.Text == "")
            {
                txtTrackingChargeFee.Text = "0";
            }

            if (txtDiscount.Text == "")
            {
                txtDiscount.Text = "0";
            }

            if (txtTotalPrice.Text == "")
            {

                txtTotalPrice.Text = "0";
            }

            int x= gvPoRequisition.Rows.Count;
            TextBox txtPrice = (TextBox)gvPoRequisition.Rows[x-1].FindControl("txtPrice");
            if (txtPrice.Text == "")
            {
                txtTotalPrice.Text = txtTotalPrice.Text;
            }
            else
            {
                for (int i = 0; i < gvPoRequisition_CountRow; i++)
                {
                    txtPrice = (TextBox)gvPoRequisition.Rows[i].FindControl("txtPrice");
                    txtTotalPrice.Text = Convert.ToString(Convert.ToDouble(txtTotalPrice.Text) + Convert.ToDouble(txtPrice.Text));
                }
            }

            Double a = (Convert.ToDouble(txtFreight.Text));
            Double b = (Convert.ToDouble(txtTrackingChargeFee.Text));
            Double c = (Convert.ToDouble(txtDiscount.Text));
            Double t = (Convert.ToDouble(txtTotalPrice.Text));

            txtTotalAmount.Text = ((t + a + b) - c).ToString();
        }

       
    }
}