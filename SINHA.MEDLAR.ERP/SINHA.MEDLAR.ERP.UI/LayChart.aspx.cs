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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Specialized;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class LayChart : System.Web.UI.Page
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
        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;
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
               
        
                getLineId();
                FirstGridViewRow();

            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            txtSRNo.Attributes.Add("onkeypress", "return controlEnter('" + dtpCuttingDate.ClientID + "', event)");
            dtpCuttingDate.Attributes.Add("onkeypress", "return controlEnter('" + txtMeasurementWidth.ClientID + "', event)");
            txtMeasurementWidth.Attributes.Add("onkeypress", "return controlEnter('" + txtMeasurementLength.ClientID + "', event)");
            txtSRNo.Attributes.Add("onkeypress", "return controlEnter('" + dtpCuttingDate.ClientID + "', event)");

            
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


        public void clearYellowTextBox()
        {


        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {
            txtBuyerName.Text = "";
            txtColorName.Text = "";
            txtPoNo.Text = "";
            txtTotalOrderQuantity.Text = "";
            txtSize.Text = "";
            
            txtStyleNo.Text = "";

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




        public void getLineId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlLineId.DataSource = objLookUpBLL.getLineId(strHeadOfficeId, strBranchOfficeId);

            ddlLineId.DataTextField = "LINE_NAME";
            ddlLineId.DataValueField = "LINE_ID";

            ddlLineId.DataBind();
            if (ddlLineId.Items.Count > 0)
            {

                ddlLineId.SelectedIndex = 0;
            }

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



        private void FirstGridViewRow()
        {


            //if (ViewState["CurrentTable"] != null)
            //{
            DataTable dt = new DataTable();
            DataRow dr = null;
            // dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("ROLL_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("LENGTH_WISE_SHRINKAGE", typeof(string)));
            dt.Columns.Add(new DataColumn("WIDTH_WISE_SHRINKAGE", typeof(string)));

            dt.Columns.Add(new DataColumn("SHADE", typeof(string)));
            dt.Columns.Add(new DataColumn("LAY_OUT", typeof(string)));

            //dt.Columns.Add(new DataColumn("TOTAL_LAY_OUT", typeof(string)));
            dt.Columns.Add(new DataColumn("STICKER_NO", typeof(string)));
            dt.Columns.Add(new DataColumn("YDS_PER_METER", typeof(string)));

            dt.Columns.Add(new DataColumn("FABRIC_USE", typeof(string)));
            dt.Columns.Add(new DataColumn("BLANCE", typeof(string)));


            dr = dt.NewRow();
            // dr["RowNumber"] = 1;
            dr["ROLL_NO"] = string.Empty;
            dr["LENGTH_WISE_SHRINKAGE"] = string.Empty;
            dr["WIDTH_WISE_SHRINKAGE"] = string.Empty;

            dr["SHADE"] = string.Empty;
            dr["LAY_OUT"] = string.Empty;
            //dr["TOTAL_LAY_OUT"] = string.Empty;

            dr["STICKER_NO"] = string.Empty;
            dr["YDS_PER_METER"] = string.Empty;
            dr["FABRIC_USE"] = string.Empty;
            //dr["BLANCE"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;

            gvFabricDetails.DataSource = dt;
            gvFabricDetails.DataBind();
            // }
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

                        TextBox txtRollNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtRollNo");
                        TextBox txtLength = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtLength");
                        TextBox txtWidth = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("txtWidth");



                        TextBox txtShade = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("txtShade");
                        TextBox txtLayOut = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtLayOut");
                        //TextBox txtTotalLayOut = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtTotalLayOut");


                        TextBox txtStickerNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtStickerNo");
                        TextBox txtYards = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtYards");
                        TextBox txtFabricUse = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtFabricUse");
                        //TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtBlance");


                        drCurrentRow = dtCurrentTable.NewRow();
                        // drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["ROLL_NO"] = txtRollNo.Text;
                        dtCurrentTable.Rows[i - 1]["LENGTH_WISE_SHRINKAGE"] = txtLength.Text;
                        dtCurrentTable.Rows[i - 1]["WIDTH_WISE_SHRINKAGE"] = txtWidth.Text;


                        dtCurrentTable.Rows[i - 1]["SHADE"] = txtShade.Text;
                        dtCurrentTable.Rows[i - 1]["LAY_OUT"] = txtLayOut.Text;
                        //dtCurrentTable.Rows[i - 1]["TOTAL_LAY_OUT"] = txtTotalLayOut.Text;
                        dtCurrentTable.Rows[i - 1]["STICKER_NO"] = txtStickerNo.Text;


                        dtCurrentTable.Rows[i - 1]["YDS_PER_METER"] = txtYards.Text;
                        dtCurrentTable.Rows[i - 1]["FABRIC_USE"] = txtFabricUse.Text;
                        //dtCurrentTable.Rows[i - 1]["BLANCE"] = txtBlance.Text;

                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    gvFabricDetails.DataSource = dtCurrentTable;
                    gvFabricDetails.DataBind();
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

                        TextBox txtRollNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtRollNo");
                        TextBox txtLength = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtLength");
                        TextBox txtWidth = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("txtWidth");



                        TextBox txtShade = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("txtShade");
                        TextBox txtLayOut = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtLayOut");
                        //TextBox txtTotalLayOut = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtTotalLayOut");


                        TextBox txtStickerNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtStickerNo");
                        TextBox txtYards = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtYards");
                        TextBox txtFabricUse = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtFabricUse");
                        //TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[8].FindControl("txtBlance");




                        txtRollNo.Text = dt.Rows[i]["ROLL_NO"].ToString();
                        txtLength.Text = dt.Rows[i]["LENGTH_WISE_SHRINKAGE"].ToString();


                        txtWidth.Text = dt.Rows[i]["WIDTH_WISE_SHRINKAGE"].ToString();
                        txtShade.Text = dt.Rows[i]["SHADE"].ToString();

                        txtLayOut.Text = dt.Rows[i]["LAY_OUT"].ToString();
                       // txtTotalLayOut.Text = dt.Rows[i]["TOTAL_LAY_OUT"].ToString();
                        txtStickerNo.Text = dt.Rows[i]["STICKER_NO"].ToString();

                        txtYards.Text = dt.Rows[i]["YDS_PER_METER"].ToString();
                        txtFabricUse.Text = dt.Rows[i]["FABRIC_USE"].ToString();
                        //txtBlance.Text = dt.Rows[i]["BLANCE"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        public void searchPoEntry()
        {


            BuyerPODTO objBuyerPODTO = new BuyerPODTO();
            BuyerPOBLL objBuyerPOBLL = new BuyerPOBLL();




            objBuyerPODTO = objBuyerPOBLL.searchPoEntry(txtPoNo.Text, strHeadOfficeId, strBranchOfficeId);

            txtBuyerName.Text = objBuyerPODTO.BuyerId;
            txtColorName.Text = objBuyerPODTO.ColorId;
            txtTotalOrderQuantity.Text = objBuyerPODTO.OrderQuantity;
            txtStyleNo.Text = objBuyerPODTO.StyleId;



        }


        public void saveLayChart()
        {

            int rowIndex = 0;
            string strMsg = "";

            LayChartDTO objLayChartDTO = new LayChartDTO();
            LayChartBLL objLayChartBLL = new LayChartBLL();


            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {

                        TextBox txtRollNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[0].FindControl("txtRollNo");
                        TextBox txtLength = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[1].FindControl("txtLength");
                        TextBox txtWidth = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[2].FindControl("txtWidth");



                        TextBox txtShade = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[3].FindControl("txtShade");
                        TextBox txtLayOut = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[4].FindControl("txtLayOut");
                        //TextBox txtTotalLayOut = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtTotalLayOut");


                        TextBox txtStickerNo = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[5].FindControl("txtStickerNo");
                        TextBox txtYards = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[6].FindControl("txtYards");
                        TextBox txtFabricUse = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[7].FindControl("txtFabricUse");
                        //TextBox txtBlance = (TextBox)gvFabricDetails.Rows[rowIndex].Cells[9].FindControl("txtBlance");



                        sc.Add(string.Format("{0},{1},{2},{3},{4},{5},{7}", txtRollNo.Text, txtLength.Text, txtWidth.Text, txtShade.Text, txtLayOut.Text, txtStickerNo.Text, txtYards.Text, txtFabricUse.Text));











                        objLayChartDTO.LengthWiseShrinkage = txtLength.Text;
                        objLayChartDTO.WidthWiseShrinkage = txtWidth.Text;
                        objLayChartDTO.Shade = txtShade.Text;
                        objLayChartDTO.LayOut = txtLayOut.Text;
                       
                        objLayChartDTO.StickerNo = txtStickerNo.Text;
                        objLayChartDTO.YardPerMeter = txtYards.Text;
                        objLayChartDTO.FabricUse = txtFabricUse.Text;
                       





                        objLayChartDTO.SRNo = txtSRNo.Text;
                        objLayChartDTO.PONo = txtPoNo.Text;
                        objLayChartDTO.RollNo = txtRollNo.Text;
                        objLayChartDTO.CuttingDate = dtpCuttingDate.Text;
                        objLayChartDTO.MeasurementWidth = txtMeasurementWidth.Text;
                        objLayChartDTO.MeasurementLength = txtMeasurementLength.Text;
                        objLayChartDTO.CuttingNo = txtCuttingNo.Text;



                        if (ddlLineId.SelectedValue.ToString() != " ")
                        {
                            objLayChartDTO.LineId = ddlLineId.SelectedValue.ToString();
                        }
                        else
                        {
                            objLayChartDTO.LineId = "";

                        }



                        objLayChartDTO.UpdateBy = strEmployeeId;
                        objLayChartDTO.HeadOfficeId = strHeadOfficeId;
                        objLayChartDTO.BranchOfficeId = strBranchOfficeId;




                        strMsg = objLayChartBLL.saveLayChart(objLayChartDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;

                        rowIndex++;

                    }

                    if (strMsg == "INSERTED SUCCESSFULLY")
                    {

                        MessageBox(strMsg);
                    }


                }
            }



        }

        public void deleteLayChart()
        {
            LayChartDTO objLayChartDTO = new LayChartDTO();
            LayChartBLL objLayChartBLL = new LayChartBLL();


            objLayChartDTO.PONo = txtPoNo.Text;
            objLayChartDTO.SRNo = txtSRNo.Text;


            objLayChartDTO.UpdateBy = strEmployeeId;
            objLayChartDTO.HeadOfficeId = strHeadOfficeId;
            objLayChartDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLayChartBLL.deleteLayChart(objLayChartDTO);



        }
        public void searchLayChartEntry()
        {

            LayChartDTO objLayChartDTO = new LayChartDTO();
            LayChartBLL objLayChartBLL = new LayChartBLL();


            DataTable dt = new DataTable();



            objLayChartDTO.PONo = txtPoSearchNo.Text;
            objLayChartDTO.SRNo = txtSRSearchNo.Text;

            objLayChartDTO.FromDate = dtpFromDate.Text;
            objLayChartDTO.ToDate = dtpToDate.Text;


           
            objLayChartDTO.HeadOfficeId = strHeadOfficeId;
            objLayChartDTO.BranchOfficeId = strBranchOfficeId;

            dt = objLayChartBLL.searchLayChartEntry(objLayChartDTO);


            if (dt.Rows.Count > 0)
            {
                gvFabricDetails.DataSource = dt;
                ViewState["CurrentTable"] = dt;
                gvFabricDetails.DataBind();

                int count = ((DataTable)gvFabricDetails.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvFabricDetails.DataSource = dt;
                gvFabricDetails.DataBind();
                int totalcolums = gvFabricDetails.Rows[0].Cells.Count;
                gvFabricDetails.Rows[0].Cells.Clear();
                gvFabricDetails.Rows[0].Cells.Add(new TableCell());
                gvFabricDetails.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvFabricDetails.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }


        }
        public void rpLayChartRegister()
        {


            try
            {

                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

              

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;

                objReportDTO.PONo = txtPoSearchNo.Text;
                objReportDTO.SRNo = txtSRNo.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptLayChartRegister.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rpLayChartRegister(objReportDTO));


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



        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPoNo.Text == "")
            {
                string strMsg = "Please Enter PO NO!!!";
                MessageBox(strMsg);
                txtPoNo.Focus();
                return;

            }
            else
            {
                deleteLayChart();
                saveLayChart();

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {

        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;


            }
        }

        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;


            }
        }

        protected void btnSearchPO_Click(object sender, EventArgs e)
        {
            if (txtPoNo.Text == "")
            {

                string strMsg = "Please Enter PO NO!!!";
                MessageBox(strMsg);
                txtPoNo.Focus();
                return;

            }
            else
            {

                searchPoEntry();

            }
        }

        protected void btnAddRow_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }

        #region "Grid View Functionality"
        protected void gvFabricDetails_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvFabricDetails.PageIndex = e.NewPageIndex;

        }

        protected void gvFabricDetails_OnSelectedIndexChanged(object sender, EventArgs e)
        {



        }




        protected void gvFabricDetails_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void gvFabricDetails_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void gvFabricDetails_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void gvFabricDetails_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                



            }
        }


        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            searchLayChartEntry();
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {


                rpLayChartRegister();
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

        #region "Crystal Report Functionality"

        protected void Page_Unload(object sender, EventArgs e)
        {

            ReportDocument rd = new ReportDocument();

            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }




        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {


            CrystalReportViewer1.Dispose();

            if (rd != null)
            {

                rd.Close();

                rd.Dispose();

                rd = null;

            }

            GC.Collect();

            GC.WaitForPendingFinalizers();

        }




        #endregion
    }
}