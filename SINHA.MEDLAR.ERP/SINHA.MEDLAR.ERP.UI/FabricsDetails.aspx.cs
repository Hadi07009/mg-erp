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
    public partial class FabricsDetails : System.Web.UI.Page
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
                getBuyerId();
                getSeasonId();

                txtContractNo.Focus();
            }

            if (IsPostBack)
            {

                loadSesscion();

            }

        }


        #region "Function"

        public void getBuyerId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBuyerId.DataSource = objLookUpBLL.getBuyerId(strHeadOfficeId, strBranchOfficeId);

            ddlBuyerId.DataTextField = "BUYER_NAME";
            ddlBuyerId.DataValueField = "BUYER_ID";

            ddlBuyerId.DataBind();
            if (ddlBuyerId.Items.Count > 0)
            {

                ddlBuyerId.SelectedIndex = 0;
            }


        }
        public void getPONo()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPONo.DataSource = objLookUpBLL.getPONo(txtContractNo.Text, strHeadOfficeId, strBranchOfficeId);

            ddlPONo.DataTextField = "PO_NO";
            ddlPONo.DataValueField = "PO_NO";

            ddlPONo.DataBind();
            if (ddlPONo.Items.Count > 0)
            {

                ddlPONo.SelectedIndex = 0;
            }


        }
        public void getStyleNo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if (ddlPONo.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.PONo = ddlPONo.SelectedValue.ToString();
            }
            else
            {

                objLookUpDTO.PONo = "";

            }


            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;


            ddlStyleNo.DataSource = objLookUpBLL.getStyleNo(objLookUpDTO);

            ddlStyleNo.DataTextField = "STYLE_NO";
            ddlStyleNo.DataValueField = "STYLE_NO";

            ddlStyleNo.DataBind();
            if (ddlStyleNo.Items.Count > 0)
            {

                ddlStyleNo.SelectedIndex = 0;
            }


        }
        public void getFobDateAndOrderQty()
        {

            FabricsDetailsDTO objFabricsDetailsDTO = new FabricsDetailsDTO();
            FabricsDetailsBLL objFabricsDetailsBLL = new FabricsDetailsBLL();

            if (ddlPONo.SelectedValue.ToString() != " ")
            {
                objFabricsDetailsDTO.PONo = ddlPONo.SelectedValue.ToString();
            }
            else
            {

                objFabricsDetailsDTO.PONo = "";

            }
            if (ddlStyleNo.SelectedValue.ToString() != " ")
            {
                objFabricsDetailsDTO.StyleNo = ddlStyleNo.SelectedValue.ToString();
            }
            else
            {

                objFabricsDetailsDTO.PONo = "";

            }


            if (txtContractNo.Text != " ")
            {
                objFabricsDetailsDTO.ContactNo = txtContractNo.Text;
            }
            else
            {

                objFabricsDetailsDTO.ContactNo = "";

            }

            objFabricsDetailsDTO.HeadOfficeId = strHeadOfficeId;
            objFabricsDetailsDTO.BranchOfficeId = strBranchOfficeId;


            objFabricsDetailsDTO = objFabricsDetailsBLL.getFobDateAndOrderQty(objFabricsDetailsDTO);


            if (objFabricsDetailsDTO.FobDate == "0")
            {
                txtFobDate.Text = "";
            }
            else
            {
                txtFobDate.Text = objFabricsDetailsDTO.FobDate;

            }

            if (objFabricsDetailsDTO.OrderQuantity == "0")
            {
                txtOrderQuantity.Text = "";
            }
            else
            {
                txtOrderQuantity.Text = objFabricsDetailsDTO.OrderQuantity;

            }
        }



        public void getSeasonId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSeasonId.DataSource = objLookUpBLL.getSeasonId();

            ddlSeasonId.DataTextField = "SEASON_NAME";
            ddlSeasonId.DataValueField = "SEASON_ID";

            ddlSeasonId.DataBind();
            if (ddlSeasonId.Items.Count > 0)
            {

                ddlSeasonId.SelectedIndex = 0;
            }


        }


        private void FirstGridViewRow()
        {


            DataTable dt = new DataTable();
            DataRow dr = null;


            dt.Columns.Add(new DataColumn("FABRICS_DESCRIPTION", typeof(string)));
            //dt.Columns.Add(new DataColumn("SUPPLIER_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("SUPPLIER", typeof(string)));
            dt.Columns.Add(new DataColumn("SIZE_ID", typeof(string)));
            dt.Columns.Add(new DataColumn("CONSUMPTION", typeof(string)));
            dt.Columns.Add(new DataColumn("PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("TOTAL_PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("BUDGET_QTY_IN_YDS", typeof(string)));
            dt.Columns.Add(new DataColumn("BUDGET_VALUE", typeof(string)));
            dt.Columns.Add(new DataColumn("ACTUAL_QTY_IN_YDS", typeof(string)));
            dt.Columns.Add(new DataColumn("ACTUAL_PRICE", typeof(string)));
            dt.Columns.Add(new DataColumn("ACTUAL_VALUE", typeof(string)));
            dt.Columns.Add(new DataColumn("ACTUAL_PER_GMT", typeof(string)));
            dt.Columns.Add(new DataColumn("VARIANCE", typeof(string)));
            dt.Columns.Add(new DataColumn("IMPORT_PI_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("IMPORT_DATE", typeof(string)));
            dt.Columns.Add(new DataColumn("IMPORT_SUPPLIER", typeof(string)));
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));

            dr = dt.NewRow();


            dr["FABRICS_DESCRIPTION"] = string.Empty;
            //dr["SUPPLIER_ID"] = string.Empty;
            dr["SUPPLIER"] = string.Empty;
            dr["SIZE_ID"] = string.Empty;
            dr["CONSUMPTION"] = string.Empty;
            dr["PRICE"] = string.Empty;
            dr["TOTAL_PRICE"] = string.Empty;
            dr["BUDGET_QTY_IN_YDS"] = string.Empty;
            dr["BUDGET_VALUE"] = string.Empty;
            dr["ACTUAL_QTY_IN_YDS"] = string.Empty;
            dr["ACTUAL_PRICE"] = string.Empty;
            dr["ACTUAL_VALUE"] = string.Empty;
            dr["ACTUAL_PER_GMT"] = string.Empty;
            dr["VARIANCE"] = string.Empty;
            dr["IMPORT_PI_NO"] = string.Empty;
            dr["IMPORT_DATE"] =String.Empty;
            dr["IMPORT_SUPPLIER"] = string.Empty;
            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvFabricsDetails.DataSource = dt;
            gvFabricsDetails.DataBind();
            gvFabricsDetails.Columns[16].Visible = false;
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

                        TextBox txtFabricsDescription = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[0].FindControl("txtFabricsDescription");
                        //DropDownList ddlSupplierId = (DropDownList)gvFabricsDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        TextBox txtSupplier = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[1].FindControl("txtSupplier");
                        DropDownList ddlSizeId = (DropDownList)gvFabricsDetails.Rows[rowIndex].Cells[2].FindControl("ddlSizeId");
                        TextBox txtConsumtion = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[3].FindControl("txtConsumtion");
                        TextBox txtPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                        TextBox txtTotalPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
                        TextBox txtBudgetQtyInYds = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[6].FindControl("txtBudgetQtyInYds");
                        TextBox txtBudgetValue = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[7].FindControl("txtBudgetValue");
                        TextBox txtActualQtyInYds = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[8].FindControl("txtActualQtyInYds");
                        TextBox txtActualPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[9].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[10].FindControl("txtActualValue");
                        TextBox txtActualPerGmts = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[11].FindControl("txtActualPerGmts");
                        TextBox txtVariance = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[12].FindControl("txtVariance");
                        TextBox txtImportPINo = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[13].FindControl("txtImportPINo");
                        TextBox txtImportDate = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[14].FindControl("txtImportDate");
                        TextBox txtImportSupplier = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[15].FindControl("txtImportSupplier");
                        Label lblTranId = (Label)gvFabricsDetails.Rows[rowIndex].Cells[16].FindControl("lblTranId");



                        drCurrentRow = dtCurrentTable.NewRow();
                        //drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["FABRICS_DESCRIPTION"] = txtFabricsDescription.Text;
                        //dtCurrentTable.Rows[i - 1]["SUPPLIER_ID"] = ddlSupplierId.Text;
                        dtCurrentTable.Rows[i - 1]["SUPPLIER"] = txtSupplier.Text;
                        dtCurrentTable.Rows[i - 1]["SIZE_ID"] = ddlSizeId.Text;
                        dtCurrentTable.Rows[i - 1]["CONSUMPTION"] = txtConsumtion.Text;
                        dtCurrentTable.Rows[i - 1]["PRICE"] = txtPrice.Text;
                        dtCurrentTable.Rows[i - 1]["TOTAL_PRICE"] = txtTotalPrice.Text;
                        dtCurrentTable.Rows[i - 1]["BUDGET_QTY_IN_YDS"] = txtBudgetQtyInYds.Text;
                        dtCurrentTable.Rows[i - 1]["BUDGET_VALUE"] = txtBudgetValue.Text;
                        dtCurrentTable.Rows[i - 1]["ACTUAL_QTY_IN_YDS"] = txtActualQtyInYds.Text;
                        dtCurrentTable.Rows[i - 1]["ACTUAL_PRICE"] = txtActualPrice.Text;
                        dtCurrentTable.Rows[i - 1]["ACTUAL_VALUE"] = txtActualValue.Text;
                        dtCurrentTable.Rows[i - 1]["ACTUAL_PER_GMT"] = txtActualPerGmts.Text;
                        dtCurrentTable.Rows[i - 1]["VARIANCE"] = txtVariance.Text;
                        dtCurrentTable.Rows[i - 1]["IMPORT_PI_NO"] = txtImportPINo.Text;
                        dtCurrentTable.Rows[i - 1]["IMPORT_DATE"] = txtImportDate.Text;
                        dtCurrentTable.Rows[i - 1]["IMPORT_SUPPLIER"] = txtImportSupplier.Text;
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = lblTranId.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvFabricsDetails.DataSource = dtCurrentTable;
                    gvFabricsDetails.DataBind();
                    gvFabricsDetails.Columns[16].Visible = false;

                    TextBox strFabricsDescription = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[0].FindControl("txtFabricsDescription");
                    strFabricsDescription.Focus();
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


                        TextBox txtFabricsDescription = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[0].FindControl("txtFabricsDescription");
                        //DropDownList ddlSupplierId = (DropDownList)gvFabricsDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        TextBox txtSupplier = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[1].FindControl("txtSupplier");
                        DropDownList ddlSizeId = (DropDownList)gvFabricsDetails.Rows[rowIndex].Cells[2].FindControl("ddlSizeId");
                        TextBox txtConsumtion = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[3].FindControl("txtConsumtion");
                        TextBox txtPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                        TextBox txtTotalPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
                        TextBox txtBudgetQtyInYds = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[6].FindControl("txtBudgetQtyInYds");
                        TextBox txtBudgetValue = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[7].FindControl("txtBudgetValue");
                        TextBox txtActualQtyInYds = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[8].FindControl("txtActualQtyInYds");
                        TextBox txtActualPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[9].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[10].FindControl("txtActualValue");
                        TextBox txtActualPerGmts = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[11].FindControl("txtActualPerGmts");
                        TextBox txtVariance = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[12].FindControl("txtVariance");
                        TextBox txtImportPINo = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[13].FindControl("txtImportPINo");
                        TextBox txtImportDate = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[14].FindControl("txtImportDate");
                        TextBox txtImportSupplier = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[15].FindControl("txtImportSupplier");
                        Label lblTranId = (Label)gvFabricsDetails.Rows[rowIndex].Cells[16].FindControl("lblTranId");


                        txtConsumtion.Text = dt.Rows[i]["FABRICS_DESCRIPTION"].ToString();
                        //ddlSupplierId.Text = dt.Rows[i]["SUPPLIER_ID"].ToString();
                        txtSupplier.Text = dt.Rows[i]["SUPPLIER"].ToString();
                        ddlSizeId.Text = dt.Rows[i]["SIZE_ID"].ToString();
                        txtConsumtion.Text = dt.Rows[i]["CONSUMPTION"].ToString();
                        txtPrice.Text = dt.Rows[i]["PRICE"].ToString();
                        txtTotalPrice.Text = dt.Rows[i]["TOTAL_PRICE"].ToString();
                        txtBudgetQtyInYds.Text = dt.Rows[i]["BUDGET_QTY_IN_YDS"].ToString();
                        txtBudgetValue.Text = dt.Rows[i]["BUDGET_VALUE"].ToString();
                        txtActualQtyInYds.Text = dt.Rows[i]["ACTUAL_QTY_IN_YDS"].ToString();
                        txtActualPrice.Text = dt.Rows[i]["ACTUAL_PRICE"].ToString();
                        txtActualValue.Text = dt.Rows[i]["ACTUAL_VALUE"].ToString();
                        txtActualPerGmts.Text = dt.Rows[i]["ACTUAL_PER_GMT"].ToString();
                        txtVariance.Text = dt.Rows[i]["VARIANCE"].ToString();
                        txtImportPINo.Text = dt.Rows[i]["IMPORT_PI_NO"].ToString();
                        txtImportDate.Text = dt.Rows[i]["IMPORT_DATE"].ToString();
                        txtImportSupplier.Text = dt.Rows[i]["IMPORT_SUPPLIER"].ToString();
                        lblTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();

                        rowIndex++;
                    }
                }
            }
        }


        public void saveFabricsDetailsInfo()
        {

            FabricsDetailsDTO objFabricsDetailsDTO = new FabricsDetailsDTO();
            FabricsDetailsBLL objFabricsDetailsBLL = new FabricsDetailsBLL();


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
                        TextBox txtFabricsDescription = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[0].FindControl("txtFabricsDescription");
                        //DropDownList ddlSupplierId = (DropDownList)gvFabricsDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        TextBox txtSupplier = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[1].FindControl("txtSupplier");
                        DropDownList ddlSizeId = (DropDownList)gvFabricsDetails.Rows[rowIndex].Cells[2].FindControl("ddlSizeId");
                        TextBox txtConsumtion = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[3].FindControl("txtConsumtion");
                        TextBox txtPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                        TextBox txtTotalPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
                        TextBox txtBudgetQtyInYds = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[6].FindControl("txtBudgetQtyInYds");
                        TextBox txtBudgetValue = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[7].FindControl("txtBudgetValue");
                        TextBox txtActualQtyInYds = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[8].FindControl("txtActualQtyInYds");
                        TextBox txtActualPrice = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[9].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[10].FindControl("txtActualValue");
                        TextBox txtActualPerGmts = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[11].FindControl("txtActualPerGmts");
                        TextBox txtVariance = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[12].FindControl("txtVariance");
                        TextBox txtImportPINo = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[13].FindControl("txtImportPINo");
                        TextBox txtImportDate = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[14].FindControl("txtImportDate");
                        TextBox txtImportSupplier = (TextBox)gvFabricsDetails.Rows[rowIndex].Cells[15].FindControl("txtImportSupplier");
                        Label lblTranId = (Label)gvFabricsDetails.Rows[rowIndex].Cells[16].FindControl("lblTranId");

                        objFabricsDetailsDTO.ContactNo = txtContractNo.Text;
                        objFabricsDetailsDTO.FobDate = txtFobDate.Text;
                        objFabricsDetailsDTO.OrderQuantity = txtOrderQuantity.Text;
                        if (ddlPONo.SelectedValue.ToString() != " ")
                        {
                            objFabricsDetailsDTO.PONo = ddlPONo.SelectedValue.ToString();
                        }
                        else
                        {

                            objFabricsDetailsDTO.PONo = "";

                        }
                        if (ddlStyleNo.SelectedValue.ToString() != " ")
                        {
                            objFabricsDetailsDTO.StyleNo = ddlStyleNo.SelectedValue.ToString();
                        }
                        else
                        {

                            objFabricsDetailsDTO.StyleNo = "";

                        }

                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objFabricsDetailsDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objFabricsDetailsDTO.BuyerId = "";

                        }

                        if (ddlSeasonId.SelectedValue.ToString() != " ")
                        {
                            objFabricsDetailsDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

                        }
                        else
                        {

                            objFabricsDetailsDTO.SeasonId = "";

                        }
                        objFabricsDetailsDTO.FebricsDescrition = txtFabricsDescription.Text;

                        //if (ddlSupplierId.SelectedValue.ToString() != " ")
                        //{
                        //    objFabricsDetailsDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

                        //}
                        //else
                        //{
                        //    objFabricsDetailsDTO.SupplierId = "";

                        //}
                        objFabricsDetailsDTO.Supplier = txtSupplier.Text;                        
                        if (ddlSizeId.SelectedValue.ToString() != " ")
                        {
                            
                            objFabricsDetailsDTO.SizeId = ddlSizeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objFabricsDetailsDTO.SizeId = "";

                        }

                        objFabricsDetailsDTO.Consumtion = txtConsumtion.Text;
                        objFabricsDetailsDTO.Price = txtPrice.Text;
                        objFabricsDetailsDTO.TotalPrice = txtTotalPrice.Text;
                        objFabricsDetailsDTO.BudgetQtyInYds = txtBudgetQtyInYds.Text;
                        objFabricsDetailsDTO.BudgetValue = txtBudgetValue.Text;
                        objFabricsDetailsDTO.ActualQtyInYds = txtActualQtyInYds.Text;
                        objFabricsDetailsDTO.ActualPrice = txtActualPrice.Text;
                        objFabricsDetailsDTO.ActualValue = txtActualValue.Text;
                        objFabricsDetailsDTO.ActualPerGmts = txtActualPerGmts.Text;
                        objFabricsDetailsDTO.Variance = txtVariance.Text;
                        objFabricsDetailsDTO.ImportPINo = txtImportPINo.Text;
                        objFabricsDetailsDTO.ImportDate = txtImportDate.Text;
                        objFabricsDetailsDTO.ImportSupplier = txtImportSupplier.Text;
                        objFabricsDetailsDTO.TranId = lblTranId.Text;

                        objFabricsDetailsDTO.UpdateBy = strEmployeeId;
                        objFabricsDetailsDTO.HeadOfficeId = strHeadOfficeId;
                        objFabricsDetailsDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objFabricsDetailsBLL.saveFabricsDetailsInfo(objFabricsDetailsDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;

                    }

                    if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY")
                    {
                        MessageBox(strMsg);

                    }

                }


            }

        }

        public void searchFabricsDetailsRecord()
        {
            FabricsDetailsDTO objFabricsDetailsDTO = new FabricsDetailsDTO();
            FabricsDetailsBLL objFabricsDetailsBLL = new FabricsDetailsBLL();

            DataTable dt = new DataTable();

            if (txtFobDate.Text != "")
            {
                objFabricsDetailsDTO.ContactNo = txtContractNo.Text;
            }
            else 
            {
                objFabricsDetailsDTO.ContactNo = txtSrcContractNo.Text;
            }
            if (txtFobDate.Text !="")
            {
                objFabricsDetailsDTO.FobDate = txtFobDate.Text;
            }
            else
            {
                objFabricsDetailsDTO.FobDate = txtSrcFobDate.Text;
            }

            if (ddlPONo.SelectedValue.ToString() !="")
            {
                objFabricsDetailsDTO.PONo = ddlPONo.SelectedValue.ToString();
            }
            else
            {

                objFabricsDetailsDTO.PONo = txtSrcPONo.Text;

            }

            if (ddlStyleNo.SelectedValue.ToString() !="")
            {
                objFabricsDetailsDTO.StyleNo = ddlStyleNo.SelectedValue.ToString();
            }
            else
            {

                objFabricsDetailsDTO.StyleNo = txtSrcStyleNo.Text;

            }


            objFabricsDetailsDTO.HeadOfficeId = strHeadOfficeId;
            objFabricsDetailsDTO.BranchOfficeId = strBranchOfficeId;

            dt = objFabricsDetailsBLL.searchFabricsDetailsRecord(objFabricsDetailsDTO);


            if (dt.Rows.Count > 0)
            {
                gvFabricsDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvFabricsDetails.DataBind();

                int count = ((DataTable)gvFabricsDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvFabricsDetails.DataSource = dt;
                gvFabricsDetails.DataBind();
                int totalcolums = gvFabricsDetails.Rows[0].Cells.Count;
                gvFabricsDetails.Rows[0].Cells.Clear();
                gvFabricsDetails.Rows[0].Cells.Add(new TableCell());
                gvFabricsDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvFabricsDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        public void searchFabricsDetailsRecordMain()
        {
            FabricsDetailsDTO objFabricsDetailsDTO = new FabricsDetailsDTO();
            FabricsDetailsBLL objFabricsDetailsBLL = new FabricsDetailsBLL();

            if (txtSrcContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                MessageBox(strMsg);
                txtSrcContractNo.Focus();
                return;


            }
            else if (txtSrcPONo.Text == "")
            {
                string strMsg = "Please Select P.O No!!!";
                MessageBox(strMsg);
                txtSrcPONo.Focus();
                return;


            }
            else if (txtSrcStyleNo.Text == "")
            {
                string strMsg = "Please Select P.O No!!!";
                MessageBox(strMsg);
                txtSrcStyleNo.Focus();
                return;


            }
            else if (txtSrcFobDate.Text == "")
            {
                string strMsg = "Please Select P.O No!!!";
                MessageBox(strMsg);
                txtSrcFobDate.Focus();
                return;


            }

            objFabricsDetailsDTO = objFabricsDetailsBLL.searchFabricsDetailsRecordMain(txtSrcContractNo.Text, txtSrcPONo.Text, txtSrcStyleNo.Text, txtSrcFobDate.Text, strHeadOfficeId, strBranchOfficeId);

            if (objFabricsDetailsDTO.ContactNo == "0")
            {

                txtContractNo.Text = "";
            }
            else
            {
                txtContractNo.Text = objFabricsDetailsDTO.ContactNo;
            }

            if (objFabricsDetailsDTO.PONo == "0")
            {

                getPONo();
            }
            else
            {
                getPONo();
                ddlPONo.SelectedValue = objFabricsDetailsDTO.PONo;
            }

            if (objFabricsDetailsDTO.strStyleNo == "0")
            {

                getStyleNo();
            }
            else
            {
                getStyleNo();
                ddlStyleNo.SelectedValue = objFabricsDetailsDTO.strStyleNo;
            }
            if (objFabricsDetailsDTO.FobDate == "0")
            {
                txtFobDate.Text = "";
            }
            else
            {
                txtFobDate.Text = objFabricsDetailsDTO.FobDate;

            }
            if (objFabricsDetailsDTO.OrderQuantity == "0")
            {

                txtOrderQuantity.Text = "";
            }
            else
            {
                txtOrderQuantity.Text = objFabricsDetailsDTO.OrderQuantity;
            }
            if (objFabricsDetailsDTO.BuyerId == "0")
            {

                getBuyerId();
            }
            else
            {
                ddlBuyerId.SelectedValue = objFabricsDetailsDTO.BuyerId;
            }


            if (objFabricsDetailsDTO.SeasonId == "0")
            {

                getSeasonId();
            }
            else
            {
                ddlSeasonId.SelectedValue = objFabricsDetailsDTO.SeasonId;
            }
            
        }

        public void processsDailyContractInfo()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            //if (ddlAmendmentId.SelectedValue.ToString() != " ")
            //{
            //    objReportDTO.AmendmentId = ddlAmendmentId.SelectedValue.ToString();
            //}
            //else
            //{

            //    objReportDTO.AmendmentId = "";
            //}


            objReportDTO.ContractNo = txtContractNo.Text;
            objReportDTO.IssueDate = txtFobDate.Text;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;


            string strMsg = objReportBLL.processsDailyContractInfo(objReportDTO);

        }


        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                MessageBox(strMsg);
                txtContractNo.Focus();
                return;


            }
            else if (ddlPONo.Text == "")
            {
                string strMsg = "Please Select P.O No!!!";
                MessageBox(strMsg);
                ddlPONo.Focus();
                return;


            }
            else if (ddlStyleNo.Text == "")
            {
                string strMsg = "Please Select Style No!!!";
                MessageBox(strMsg);
                ddlStyleNo.Focus();
                return;


            }
            else if (txtFobDate.Text == "")
            {
                string strMsg = "Please Enter FOB Date!!!";
                MessageBox(strMsg);
                txtFobDate.Focus();
                return;


            }
            else if (ddlBuyerId.Text == " ")
            {
                string strMsg = "Please Select Buyer Name!!!";
                MessageBox(strMsg);
                ddlBuyerId.Focus();
                return;


            }
            else if (ddlSeasonId.Text == " ")
            {
                string strMsg = "Please Select Season Name!!!";
                MessageBox(strMsg);
                ddlSeasonId.Focus();
                return;


            }
            else
            {
                saveFabricsDetailsInfo();
                searchFabricsDetailsRecord();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getPONo();
           
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
            gvFabricsDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvFabricsDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvFabricsDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvFabricsDetails_RowCommand(object sender, GridViewCommandEventArgs e)
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
        protected void gvFabricsDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();
                
                DropDownList b = (e.Row.FindControl("ddlSizeId") as DropDownList);
               
                DataTable dt1 = new DataTable();     
                DataRowView dr1 = e.Row.DataItem as DataRowView;
                
                dt1 = objLookUpBLL.getSizeId();
                b.DataSource = dt1;
                b.DataBind();
                b.SelectedValue = dr1["SIZE_ID"].ToString();

                //DropDownList a = (e.Row.FindControl("ddlSupplierId") as DropDownList);
                //DataTable dt = new DataTable();
                // DataRowView dr = e.Row.DataItem as DataRowView;
                //dt = objLookUpBLL.getSupplierId(strHeadOfficeId, strBranchOfficeId);
                //a.DataSource = dt;
                //a.DataBind();
                //a.SelectedValue = dr1["SUPPLIER_ID"].ToString();                             

            }



        }


        #endregion

      

        protected void ddlAmendmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchFabricsDetailsRecord();
            searchFabricsDetailsRecordMain();

        }

        protected void btnSearchRecord_Click(object sender, EventArgs e)
        {
            if (txtSrcContractNo.Text == "")
            {
                string strMsg = "Please Enter Contract No!!!";
                MessageBox(strMsg);
                txtContractNo.Focus();
                return;


            }
            else if (txtSrcPONo.Text == "")
            {
                string strMsg = "Please Enter P.O No!!!";
                MessageBox(strMsg);
                txtSrcPONo.Focus();
                return;


            }
            else if (txtSrcStyleNo.Text == "")
            {
                string strMsg = "Please Enter Style No!!!";
                MessageBox(strMsg);
                txtSrcStyleNo.Focus();
                return;


            }
            else if (txtSrcFobDate.Text == "")
            {
                string strMsg = "Please Enter FOB Date!!!";
                MessageBox(strMsg);
                txtSrcFobDate.Focus();
                return;


            } 
            else
            {
                searchFabricsDetailsRecord();
                searchFabricsDetailsRecordMain();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           // deleteFabricsDetailsInfo();
        }

        protected void ddlPONo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getStyleNo();
           
        }

        protected void ddlStyleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            getFobDateAndOrderQty();   
        }

        protected void btnMultiply_Click(object sender, EventArgs e)
        {
              
        }

        protected void ddlSeasonId_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox strFabricsDescription = (TextBox)gvFabricsDetails.Rows[0].Cells[0].FindControl("txtFabricsDescription");
            strFabricsDescription.Focus();
        }

    }
}