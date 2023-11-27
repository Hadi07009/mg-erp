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
    public partial class FabricsTrimsDetails : System.Web.UI.Page
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
            }

            if (IsPostBack)
            {

                loadSesscion();

            }


            gvTrimsDetails.Columns[13].Visible = false;

        }


        #region "Function"
        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;

                formatType = ExportFormatType.PortableDocFormat;
                MemoryStream oStream;


                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "application/Pdf";
                crReportDocument.Close();
                crReportDocument.Dispose();

                oStream.Seek(0, SeekOrigin.Begin);
                try
                {

                    Response.BinaryWrite(oStream.ToArray());
                    Response.End();

                }

                catch (System.Threading.ThreadAbortException lException)
                {

                    //do nothing

                }

                finally
                {
                    Response.End();
                    oStream.Flush();
                    oStream.Close();
                    oStream.Dispose();
                    crReportDocument.Close();
                    crReportDocument.Dispose();
                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;

                }
            }
            if (chkExcel.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

                //formatType = ExportFormatType.Excel;
                //MemoryStream oStream;
                //Response.Clear();
                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = (MemoryStream)rd.ExportToStream(formatType);
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
            //else
            //{

            //    CrystalReportViewer1.ReportSource = rd;
            //    CrystalReportViewer1.DataBind();

            //    formatType = ExportFormatType.PortableDocFormat;
            //    MemoryStream oStream;
            //    Response.Clear();
            //    Response.Buffer = false;
            //    Response.ClearContent();
            //    Response.ClearHeaders();

            //    oStream = (MemoryStream)rd.ExportToStream(formatType);
            //    Response.ContentType = "application/Pdf";
            //    oStream.Seek(0, SeekOrigin.Begin);
            //    Response.BinaryWrite(oStream.ToArray());
            //    //Response.End();
            //    oStream.Flush();
            //    oStream.Close();
            //    oStream.Dispose();
            //    CrystalReportViewer1.RefreshReport();

            //}



        }

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
            dt.Columns.Add(new DataColumn("SUPPLIER_ID", typeof(string)));
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
            dt.Columns.Add(new DataColumn("TRAN_ID", typeof(string)));

            dr = dt.NewRow();

            dr["FABRICS_DESCRIPTION"] = string.Empty;
            dr["SUPPLIER_ID"] = string.Empty;
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
            dr["TRAN_ID"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvTrimsDetails.DataSource = dt;
            gvTrimsDetails.DataBind();

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

                        TextBox txtFebricsDescrition = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[0].FindControl("txtFebricsDescrition");
                        DropDownList ddlSupplierId = (DropDownList)gvTrimsDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        DropDownList ddlSizeId = (DropDownList)gvTrimsDetails.Rows[rowIndex].Cells[2].FindControl("ddlSizeId");
                        TextBox txtConsumtion = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[3].FindControl("txtConsumtion");
                        TextBox txtPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                        TextBox txtTotalPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
                        TextBox txtBudgetQtyInYds = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[6].FindControl("txtBudgetQtyInYds");
                        TextBox txtBudgetValue = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[7].FindControl("txtBudgetValue");
                        TextBox txtActualQtyInYds = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[8].FindControl("txtActualQtyInYds");
                        TextBox txtActualPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[9].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[10].FindControl("txtActualValue");
                        TextBox txtActualPerGmts = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[11].FindControl("txtActualPerGmts");
                        TextBox txtVariance = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[12].FindControl("txtVariance");
                        TextBox txtTranId = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[13].FindControl("txtTranId");



                        drCurrentRow = dtCurrentTable.NewRow();
                        //drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["FABRICS_DESCRIPTION"] = txtFebricsDescrition.Text;
                        dtCurrentTable.Rows[i - 1]["SUPPLIER_ID"] = ddlSupplierId.Text;
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
                        dtCurrentTable.Rows[i - 1]["TRAN_ID"] = txtTranId.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    gvTrimsDetails.DataSource = dtCurrentTable;
                    gvTrimsDetails.DataBind();
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

                        TextBox txtFebricsDescrition = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[0].FindControl("txtFebricsDescrition");
                        DropDownList ddlSupplierId = (DropDownList)gvTrimsDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        DropDownList ddlSizeId = (DropDownList)gvTrimsDetails.Rows[rowIndex].Cells[2].FindControl("ddlSizeId");
                        TextBox txtConsumtion = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[3].FindControl("txtConsumtion");
                        TextBox txtPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                        TextBox txtTotalPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
                        TextBox txtBudgetQtyInYds = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[6].FindControl("txtBudgetQtyInYds");
                        TextBox txtBudgetValue = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[7].FindControl("txtBudgetValue");
                        TextBox txtActualQtyInYds = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[8].FindControl("txtActualQtyInYds");
                        TextBox txtActualPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[9].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[10].FindControl("txtActualValue");
                        TextBox txtActualPerGmts = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[11].FindControl("txtActualPerGmts");
                        TextBox txtVariance = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[12].FindControl("txtVariance");
                        TextBox txtTranId = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[13].FindControl("txtTranId");


                        txtFebricsDescrition.Text = dt.Rows[i]["FABRICS_DESCRIPTION"].ToString();
                        ddlSupplierId.Text = dt.Rows[i]["SUPPLIER_ID"].ToString();
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
                        txtTranId.Text = dt.Rows[i]["TRAN_ID"].ToString();


                        rowIndex++;
                    }
                }
            }
        }

        //public void deleteFabricsDetailsInfo()
        //{

        //    FabricsDetailsDTO objFabricsDetailsDTO = new FabricsDetailsDTO();
        //    FabricsDetailsBLL objFabricsDetailsBLL = new FabricsDetailsBLL();



        //    objFabricsDetailsDTO.ContactNo = txtContractNo.Text;
        //    objFabricsDetailsDTO.FobDate = txtFobDate.Text;
        //    objFabricsDetailsDTO.FobOriginaldate = txtFobOriginalDate.Text;


        //    objFabricsDetailsDTO.UpdateBy = strEmployeeId;
        //    objFabricsDetailsDTO.HeadOfficeId = strHeadOfficeId;
        //    objFabricsDetailsDTO.BranchOfficeId = strBranchOfficeId;


        //    string strMsg = objFabricsDetailsBLL.deleteFabricsDetailsInfo(objFabricsDetailsDTO);



        //}


        public void saveTrimsDetailsInfo()
        {

            TrimsDetailsDTO objTrimsDetailsDTO = new TrimsDetailsDTO();
            TrimsDetailsBLL objTrimsDetailsBLL = new TrimsDetailsBLL();


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
                        TextBox txtFebricsDescrition = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[0].FindControl("txtFebricsDescrition");
                        DropDownList ddlSupplierId = (DropDownList)gvTrimsDetails.Rows[rowIndex].Cells[1].FindControl("ddlSupplierId");
                        DropDownList ddlSizeId = (DropDownList)gvTrimsDetails.Rows[rowIndex].Cells[2].FindControl("ddlSizeId");
                        TextBox txtConsumtion = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[3].FindControl("txtConsumtion");
                        TextBox txtPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[4].FindControl("txtPrice");
                        TextBox txtTotalPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[5].FindControl("txtTotalPrice");
                        TextBox txtBudgetQtyInYds = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[6].FindControl("txtBudgetQtyInYds");
                        TextBox txtBudgetValue = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[7].FindControl("txtBudgetValue");
                        TextBox txtActualQtyInYds = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[8].FindControl("txtActualQtyInYds");
                        TextBox txtActualPrice = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[9].FindControl("txtActualPrice");
                        TextBox txtActualValue = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[10].FindControl("txtActualValue");
                        TextBox txtActualPerGmts = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[11].FindControl("txtActualPerGmts");
                        TextBox txtVariance = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[12].FindControl("txtVariance");
                        TextBox txtTranId = (TextBox)gvTrimsDetails.Rows[rowIndex].Cells[13].FindControl("txtTranId");

                        objTrimsDetailsDTO.ContactNo = txtContractNo.Text;
                        objTrimsDetailsDTO.FobDate = txtFobDate.Text;
                        objTrimsDetailsDTO.FobOriginaldate = txtFobOriginalDate.Text;
                        objTrimsDetailsDTO.PONo = txtPONo.Text;
                        objTrimsDetailsDTO.StyleNo = txtStyleNo.Text;
                        objTrimsDetailsDTO.FebricsDescrition = txtFebricsDescrition.Text;

                        if (ddlBuyerId.SelectedValue.ToString() != " ")
                        {
                            objTrimsDetailsDTO.BuyerId = ddlBuyerId.SelectedValue.ToString();

                        }
                        else
                        {

                            objTrimsDetailsDTO.BuyerId = "";

                        }

                        if (ddlSeasonId.SelectedValue.ToString() != " ")
                        {
                            objTrimsDetailsDTO.SeasonId = ddlSeasonId.SelectedValue.ToString();

                        }
                        else
                        {

                            objTrimsDetailsDTO.SeasonId = "";

                        }
                        if (ddlSupplierId.SelectedValue.ToString() != " ")
                        {
                            objTrimsDetailsDTO.SupplierId = ddlSupplierId.SelectedValue.ToString();

                        }
                        else
                        {
                            objTrimsDetailsDTO.SupplierId = "";

                        }
                        if (ddlSizeId.SelectedValue.ToString() != " ")
                        {
                            objTrimsDetailsDTO.SizeId = ddlSizeId.SelectedValue.ToString();

                        }
                        else
                        {
                            objTrimsDetailsDTO.SizeId = "";

                        }

                        objTrimsDetailsDTO.Consumtion = txtConsumtion.Text;
                        objTrimsDetailsDTO.Price = txtPrice.Text;
                        objTrimsDetailsDTO.TotalPrice = txtTotalPrice.Text;
                        objTrimsDetailsDTO.BudgetQtyInYds = txtBudgetQtyInYds.Text;
                        objTrimsDetailsDTO.BudgetValue = txtBudgetValue.Text;
                        objTrimsDetailsDTO.ActualQtyInYds = txtActualQtyInYds.Text;
                        objTrimsDetailsDTO.ActualPrice = txtActualPrice.Text;
                        objTrimsDetailsDTO.ActualValue = txtActualValue.Text;
                        objTrimsDetailsDTO.ActualPerGmts = txtActualPerGmts.Text;
                        objTrimsDetailsDTO.Variance = txtVariance.Text;
                        objTrimsDetailsDTO.TranId = txtTranId.Text;

                        objTrimsDetailsDTO.UpdateBy = strEmployeeId;
                        objTrimsDetailsDTO.HeadOfficeId = strHeadOfficeId;
                        objTrimsDetailsDTO.BranchOfficeId = strBranchOfficeId;


                        strMsg = objTrimsDetailsBLL.saveTrimsDetailsInfo(objTrimsDetailsDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;

                    }

                  

                }
                if (strMsg == "INSERTED SUCCESSFULLY" || strMsg == "UPDATED SUCCESSFULLY")
                {
                    MessageBox(strMsg);

                }


            }

        }

        public void searchTrimsDetailsRecord()
        {
            TrimsDetailsDTO objTrimsDetailsDTO = new TrimsDetailsDTO();
            TrimsDetailsBLL objTrimsDetailsBLL = new TrimsDetailsBLL();

            DataTable dt = new DataTable();


            objTrimsDetailsDTO.ContactNo = txtContractNo.Text;
            objTrimsDetailsDTO.FobDate = txtFobDate.Text;
            objTrimsDetailsDTO.FobOriginaldate = txtFobOriginalDate.Text;

            objTrimsDetailsDTO.PONo = txtPONo.Text;
            objTrimsDetailsDTO.StyleNo = txtStyleNo.Text;


            objTrimsDetailsDTO.HeadOfficeId = strHeadOfficeId;
            objTrimsDetailsDTO.BranchOfficeId = strBranchOfficeId;

            dt = objTrimsDetailsBLL.searchTrimsDetailsRecord(objTrimsDetailsDTO);


            if (dt.Rows.Count > 0)
            {
                gvTrimsDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvTrimsDetails.DataBind();

                int count = ((DataTable)gvTrimsDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvTrimsDetails.DataSource = dt;
                gvTrimsDetails.DataBind();
                int totalcolums = gvTrimsDetails.Rows[0].Cells.Count;
                gvTrimsDetails.Rows[0].Cells.Clear();
                gvTrimsDetails.Rows[0].Cells.Add(new TableCell());
                gvTrimsDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvTrimsDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }

        public void searchTrimsDetailsRecordMain()
        {
            TrimsDetailsDTO objTrimsDetailsDTO = new TrimsDetailsDTO();
            TrimsDetailsBLL objTrimsDetailsBLL = new TrimsDetailsBLL();


            objTrimsDetailsDTO = objTrimsDetailsBLL.searchTrimsDetailsRecordMain(txtContractNo.Text, txtPONo.Text, txtStyleNo.Text, txtFobDate.Text, strHeadOfficeId, strBranchOfficeId);



            if (objTrimsDetailsDTO.FobDate == "0")
            {
                txtFobDate.Text = "";
            }
            else
            {
                txtFobDate.Text = objTrimsDetailsDTO.FobDate;

            }


            if (objTrimsDetailsDTO.FobOriginaldate == "0")
            {
                txtFobOriginalDate.Text = "";
            }
            else
            {
                txtFobOriginalDate.Text = objTrimsDetailsDTO.FobOriginaldate;

            }

            if (objTrimsDetailsDTO.BuyerId == "0")
            {

                getBuyerId();
            }
            else
            {
                ddlBuyerId.SelectedValue = objTrimsDetailsDTO.BuyerId;
            }


            if (objTrimsDetailsDTO.SeasonId == "0")
            {

                getSeasonId();
            }
            else
            {
                ddlSeasonId.SelectedValue = objTrimsDetailsDTO.SeasonId;
            }




            if (objTrimsDetailsDTO.PONo == "0")
            {

                txtPONo.Text = "";
            }
            else
            {
                txtPONo.Text = objTrimsDetailsDTO.PONo;
            }

            if (objTrimsDetailsDTO.strStyleNo == "0")
            {

                txtStyleNo.Text = "";
            }
            else
            {
                txtStyleNo.Text = objTrimsDetailsDTO.strStyleNo;
            }


        }

        public void rptContractSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            processsDailyContractInfo();


            //if (ddlAmendmentId.SelectedValue.ToString() != " ")
            //{
            //    objReportDTO.AmendmentId = ddlAmendmentId.SelectedValue.ToString();
            //}
            //else
            //{

            //    objReportDTO.AmendmentId = "";
            //}

            objReportDTO.AmendDate = txtFobOriginalDate.Text;
            objReportDTO.ContractNo = txtContractNo.Text;
            objReportDTO.FromDate = txtFobDate.Text;
            objReportDTO.ToDate = txtFobDate.Text;

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;



            string strPath = Path.Combine(Server.MapPath("~/Reports/rptContractInfo.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.rptContractSheet(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();

            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();



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
            else if (txtPONo.Text == "")
            {
                string strMsg = "Please Enter P.O No!!!";
                MessageBox(strMsg);
                txtPONo.Focus();
                return;


            }
            else if (txtStyleNo.Text == "")
            {
                string strMsg = "Please Enter Style No!!!";
                MessageBox(strMsg);
                txtStyleNo.Focus();
                return;


            }
            else if (txtFobDate.Text == "")
            {
                string strMsg = "Please Enter Issue Date!!!";
                MessageBox(strMsg);
                txtFobDate.Focus();
                return;


            }
            else if (txtFobOriginalDate.Text == "")
            {
                string strMsg = "Please Enter FOB Date!!!";
                MessageBox(strMsg);
                txtFobOriginalDate.Focus();
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
                saveTrimsDetailsInfo();
                searchTrimsDetailsRecord();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchTrimsDetailsRecord();
            searchTrimsDetailsRecordMain();

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
            gvTrimsDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvTrimsDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }




        protected void gvTrimsDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvTrimsDetails_RowCommand(object sender, GridViewCommandEventArgs e)
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


        protected void gvTrimsDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LookUpBLL objLookUpBLL = new LookUpBLL();

                DropDownList a = (e.Row.FindControl("ddlSupplierId") as DropDownList);
                DropDownList b = (e.Row.FindControl("ddlSizeId") as DropDownList);

                DataTable dt = new DataTable();
                DataTable dt1 = new DataTable();

                DataRowView dr = e.Row.DataItem as DataRowView;
                DataRowView dr1 = e.Row.DataItem as DataRowView;

                dt = objLookUpBLL.getSupplierId();
                a.DataSource = dt;
                a.DataBind();
                a.SelectedValue = dr1["SUPPLIER_ID"].ToString();

                dt1 = objLookUpBLL.getSizeId();
                b.DataSource = dt1;
                b.DataBind();
                b.SelectedValue = dr1["SIZE_ID"].ToString();

            }



        }


        #endregion

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtContractNo.Text == " ")
                {

                    string strMsg = "Please Enter Contract No!!!";
                    MessageBox(strMsg);
                    txtContractNo.Focus();
                    return;
                }

                else if (txtFobDate.Text == " ")
                {

                    string strMsg = "Please Enter Issue Date!!!";
                    MessageBox(strMsg);
                    txtFobDate.Focus();
                    return;
                }
                else
                {

                    //  rptContractSheet();

                }
            }
            catch (Exception ex)
            {

                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();


            }
        }

        protected void ddlAmendmentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchTrimsDetailsRecord();
            searchTrimsDetailsRecordMain();

        }

        protected void btnSearchAmmendMent_Click(object sender, EventArgs e)
        {
            searchTrimsDetailsRecord();
            searchTrimsDetailsRecordMain();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
           // deleteFabricsDetailsInfo();
        }


    }
}