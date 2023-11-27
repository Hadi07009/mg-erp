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


using System.Web.UI.HtmlControls;
using System.Collections;
using System.Drawing.Printing;
using CrystalDecisions.ReportAppServer.Controllers;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class GazetteReProcess : System.Web.UI.Page
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
                getUnitId();
                getMonthId();

                getSectionId();
                clearMsg();
                getOfficeName();
                getMonthYearForTax();
                //ddlGazetteMonth.SelectedIndex = 12;        
            }
            if (IsPostBack)
            {
                loadSesscion();
                //ddlGazetteMonth.SelectedIndex = 12;
            }
        }


        protected void Page_Init(object sender, EventArgs e)
        {
          
        }


        #region "Function"


        public void getMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            var data = objLookUpBLL.getMonthId();

            ddlGazetteMonth.DataSource = data;
            ddlGazetteMonth.DataTextField = "MONTH_NAME";
            ddlGazetteMonth.DataValueField = "MONTH_ID";
            ddlGazetteMonth.DataBind();

            if (ddlGazetteMonth.Items.Count > 0)
            {
                ddlGazetteMonth.SelectedIndex = 0;
            }


            ddlIncrementMonth.DataSource = data;
            ddlIncrementMonth.DataTextField = "MONTH_NAME";
            ddlIncrementMonth.DataValueField = "MONTH_ID";
            ddlIncrementMonth.DataBind();

            if (ddlIncrementMonth.Items.Count > 0)
            {
                ddlIncrementMonth.SelectedIndex = 0;
            }

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
            //txtCardNo.Text = string.Empty;
            //txtEmployeeId.Text = string.Empty;
            //txtDesignationName.Text = string.Empty;
            //txtEmployeeName.Text = string.Empty;
            //txtSL.Text = string.Empty;
            //txtSLNew.Text = string.Empty;

        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {

            //txtAdvanceFee.Text = string.Empty;
            //txtArrearFee.Text = string.Empty;
            //txtOverTimeHour.Text = string.Empty;
            //txtWorkingDay.Text = string.Empty;
            //txtAttendenceFee.Text = string.Empty;
            //txtLoanAmount.Text = string.Empty;
        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
           // lblMsgRecord.Text = string.Empty;
        }
        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

          //  txtSalaryYear.Text = objLookUpDTO.Year;
          //  txtsalaryMonth.Text = objLookUpDTO.Month;

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
        public void getUnitId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {

                ddlUnitId.SelectedIndex = 0;
            }

        }

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
        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {

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


        #endregion


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
               
        #region "Crystal Report Correction"

        protected static Queue reportQueue = new Queue();

        protected static ReportClass CreateReport(Type reportClass)
        {
            object report = Activator.CreateInstance(reportClass);
            reportQueue.Enqueue(report);
            return (ReportClass)report;
        }

        public static ReportClass GetReport(Type reportClass)
        {
            //75 is my print job limit.
            if (reportQueue.Count > 75) ((ReportClass)reportQueue.Dequeue()).Dispose();
            return CreateReport(reportClass);
        }

        public void ReportFormatMaster()
        {
            //Export the report in different format
            string strDefaultName = "Report";
            ExportFormatType formatType = ExportFormatType.NoFormat;
            if (chkPDF.Checked == true)
            {
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportDocument crReportDocument = new ReportDocument();
                Response.Clear();
                Response.Buffer = true;



                formatType = ExportFormatType.PortableDocFormat;
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();



            }
            if (chkExcel.Checked == true)
            {
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
                //Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();


                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "report_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }

            if (chkWord.Checked == true)
            {
                Response.ClearContent();
                Response.ClearHeaders();
                rd.ExportToHttpResponse(ExportFormatType.WordForWindows, Response, true, "report_worker");
                Response.End();


            }

            if (chkCSV.Checked == true)
            {
                formatType = ExportFormatType.CharacterSeparatedValues;
                rd.ExportToHttpResponse(formatType, Response, true, strDefaultName);
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }

            if (chkText.Checked == true)
            {
                formatType = ExportFormatType.RichText;
                MemoryStream oStream;
                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "text/richtext";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();
            }
        }

        #endregion

        #region "Check Box Region"
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {

                chkPDF.AutoPostBack = true;
                chkExcel.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }
        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkWord.Checked = false;
                chkCSV.Checked = false;
            }
        }
        protected void chkWord_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWord.Checked == true)
            {
                chkWord.AutoPostBack = true;
                chkPDF.Checked = false;
                chkText.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }
        protected void chkText_CheckedChanged(object sender, EventArgs e)
        {
            if (chkText.Checked == true)
            {
                chkText.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkCSV.Checked = false;
            }
        }
        protected void chkCSV_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCSV.Checked == true)
            {
                chkCSV.AutoPostBack = true;
                chkPDF.Checked = false;
                chkWord.Checked = false;
                chkExcel.Checked = false;
                chkText.Checked = false;
            }
        }
        #endregion


        private string ProcessIncrementArrearAdj()
        {
            //sp_process_incr_arrear_adj

            GazetteDTO objGazetteDTO = new GazetteDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();

            if (ddlUnitGroupId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.UnitGroupId = "";
            }
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.SectionId = "";
            }

            objGazetteDTO.ArrearYear = txtGazetteYear.Text;
            if (ddlGazetteMonth.SelectedValue.ToString() != "0")
            {
                objGazetteDTO.ArrearMonth = ddlGazetteMonth.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.ArrearMonth = "";
            }

            
            objGazetteDTO.IncrementYear = txtIncrementYear.Text;
            if (ddlIncrementMonth.SelectedValue.ToString() != "0")
            {
                objGazetteDTO.IncrementMonth = ddlIncrementMonth.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.IncrementMonth = "";
            }

            objGazetteDTO.HeadOfficeId = strHeadOfficeId;
            objGazetteDTO.BranchOfficeId = strBranchOfficeId;
            objGazetteDTO.UpdateBy = strEmployeeId;

            string msg = objGazetteBLL.ProcessIncrementArrearAdj(objGazetteDTO);
            return msg;
        }
        //delete method after implementing above method
        //private string ProcessWorkerExtendedSalary()
        //{
        //    GazetteDTO objGazetteDTO = new GazetteDTO();
        //    GazetteBLL objGazetteBLL = new GazetteBLL();
                        
        //    if (ddlUnitGroupId.SelectedValue.ToString() != " ")
        //        {
        //            objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objGazetteDTO.UnitGroupId = "";
        //        }
        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //        {
        //            objGazetteDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objGazetteDTO.UnitId = "";
        //        }

        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //        {
        //        objGazetteDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //        objGazetteDTO.SectionId = "";
        //        }
            
        //        objGazetteDTO.Year = txtGazetteYear.Text;
        //        if (ddlGazetteMonth.SelectedValue.ToString() != " ")
        //        {
        //        objGazetteDTO.Month = ddlGazetteMonth.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //        objGazetteDTO.Month = "";
        //        }
        //        objGazetteDTO.HeadOfficeId = strHeadOfficeId;
        //        objGazetteDTO.BranchOfficeId = strBranchOfficeId;
        //        objGazetteDTO.UpdateBy = strEmployeeId;

        //        string msg = objGazetteBLL.ProcessWorkerExtendedSalary(objGazetteDTO);
        //    return msg;
        //    }

        private int GetIncrementPlusReGazetAdjSheet()
        {
            GazetteDTO objGazetteDTO = new GazetteDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();

            if (ddlUnitGroupId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.UnitGroupId = "";
            }
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.SectionId = "";
            }

            objGazetteDTO.Year = txtGazetteYear.Text;
            if (ddlGazetteMonth.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.Month = ddlGazetteMonth.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.Month = "";
            }
            objGazetteDTO.HeadOfficeId = strHeadOfficeId;
            objGazetteDTO.BranchOfficeId = strBranchOfficeId;
            objGazetteDTO.UpdateBy = strEmployeeId;

            string strPath = string.Empty;
            strPath = Path.Combine(Server.MapPath("~/Reports/ReportNameAdd"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);

            //dt.Rows.Count
            var data = objGazetteBLL.GetIncrementPlusReGazetAdjSheet(objGazetteDTO);
            int counter = data.Rows.Count;

            if (counter > 0)
            {
                rd.SetDataSource(data);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportFormatMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return counter;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }
                        
        protected void btnAnalyze_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGazetteYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtGazetteYear.Focus();
                    return;
                }

                if (ddlGazetteMonth.SelectedItem.Value == "0")
                {
                    string strMsg = "Please Select Month Name!!!";
                    MessageBox(strMsg);
                    ddlGazetteMonth.Focus();
                    return;
                }

                //New SP for Second Gazette, 2018
                //sp_process_incr_arrear_adj

                string msg = ProcessIncrementArrearAdj();

                //GetIncrementArrearAdjSheet();
                //string msg = ProcessWorkerExtendedSalary();
                //GetWorkerExtendedSalarySheet();

                MessageBox(msg);
                lblMsg.Text = msg;
            }
            catch
            {
            }
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtGazetteYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtGazetteYear.Focus();
                    return;
                }

                if (ddlGazetteMonth.SelectedItem.Value == "0")
                {
                    string strMsg = "Please Select Month Name!!!";
                    MessageBox(strMsg);
                    ddlGazetteMonth.Focus();
                    return;
                }

                
                int counter = GetIncrementArrearAdjSheet();
                if(counter==0)
                MessageBox("Please Analyze first");
            }
            catch
            {
            }
        }

        protected void btnRequisition_Click(object sender, EventArgs e)
        {
            int counter = 0;
            try
            {
                if (txtGazetteYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtGazetteYear.Focus();
                    return;
                }

                if (ddlGazetteMonth.SelectedItem.Value == "0")
                {
                    string strMsg = "Please Select Month Name!!!";
                    MessageBox(strMsg);
                    ddlGazetteMonth.Focus();
                    return;
                }
                //counter = GetExtendedSalaryRequisition();
                counter = GetIncrementArrearRequisition();

                if (counter == 0)
                {
                    string strMsg = "Please Analyze and then see the Requisition";
                    MessageBox(strMsg);
                    return;
                }
            }
            catch
            {

            }
        }

        //public int GetWorkerExtendedSalarySheet()
        //{
        //    int counter = 0;
        //    try
        //    {
        //        ReportDTO objReportDTO = new ReportDTO();
        //        ReportBLL objReportBLL = new ReportBLL();

        //        objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
        //        objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

        //        objReportDTO.HeadOfficeId = strHeadOfficeId;
        //        objReportDTO.BranchOfficeId = strBranchOfficeId;

        //        objReportDTO.Year = txtGazetteYear.Text.Trim();
        //        objReportDTO.Month = ddlGazetteMonth.SelectedItem.Value;
        //        objReportDTO.UpdateBy = strEmployeeId;
        //        objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
        //        objReportDTO.EmployeeTypeId = "2";
                
                                
        //        string strPath = string.Empty;
        //        strPath = Path.Combine(Server.MapPath("~/Reports/ExtendedSalarySheetWorker.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);

        //        var data = objReportBLL.GetWorkerExtendedSalarySheet(objReportDTO);
        //        counter = data.Rows.Count;

        //        if (counter > 0)
        //        {
        //            rd.SetDataSource(data);
        //            rd.SetDatabaseLogon("erp", "erp");
        //            reportMaster();

        //            this.CrystalReportViewer1.Dispose();
        //            this.CrystalReportViewer1 = null;
        //            rd.Dispose();
        //            rd.Close();
        //            GC.Collect();
        //            GC.WaitForPendingFinalizers();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //    return counter;
        //}
        public int GetIncrementArrearAdjSheet()
        {
            int counter = 0;
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.ArrearYear = txtGazetteYear.Text.Trim();
                objReportDTO.ArrearMonth = ddlGazetteMonth.SelectedItem.Value;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.EmployeeTypeId = "2";


                string strPath = string.Empty;
                //strPath = Path.Combine(Server.MapPath("~/Reports/ExtendedSalarySheetWorker.rpt"));
                strPath = Path.Combine(Server.MapPath("~/Reports/RptIncrArrearAdjustmentSheet.rpt"));
                
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);

                var data = objReportBLL.GetIncrementArrearAdjSheet(objReportDTO);
                counter = data.Rows.Count;

                if (counter > 0)
                {
                    rd.SetDataSource(data);
                    rd.SetDatabaseLogon("erp", "erp");
                    reportMaster();

                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
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
            return counter;
        }

        //private int GetExtendedSalaryRequisition()
        //{
        //    GazetteDTO objGazetteDTO = new GazetteDTO();
        //    ReportBLL objReportBLL = new ReportBLL();
        //    int counter = 0;

        //    try
        //    {
        //        if (ddlUnitGroupId.SelectedValue.ToString() != " ")
        //        {
        //            objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objGazetteDTO.UnitGroupId = "";
        //        }
        //        if (ddlUnitId.SelectedValue.ToString() != " ")
        //        {
        //            objGazetteDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objGazetteDTO.UnitId = "";
        //        }

        //        if (ddlSectionId.SelectedValue.ToString() != " ")
        //        {
        //            objGazetteDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objGazetteDTO.SectionId = "";
        //        }

        //        objGazetteDTO.Year = txtGazetteYear.Text;
        //        if (ddlGazetteMonth.SelectedValue.ToString() != " ")
        //        {
        //            objGazetteDTO.Month = ddlGazetteMonth.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objGazetteDTO.Month = "";
        //        }


        //        objGazetteDTO.HeadOfficeId = strHeadOfficeId;
        //        objGazetteDTO.BranchOfficeId = strBranchOfficeId;
        //        objGazetteDTO.UpdateBy = strEmployeeId;

        //        string strPath = string.Empty;
        //        strPath = Path.Combine(Server.MapPath("~/Reports/RptExtendedSalaryRequisition.rpt"));

        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        var data = objReportBLL.GetExtendedSalaryRequisition(objGazetteDTO);
        //        counter = data.Rows.Count;

        //        if (counter > 0)
        //        {
        //            rd.SetDataSource(data);
        //            rd.SetDatabaseLogon("erp", "erp");
        //            CrystalReportViewer1.ReportSource = rd;
        //            CrystalReportViewer1.DataBind();
        //            ReportFormatMaster();
        //            this.CrystalReportViewer1.Dispose();
        //            this.CrystalReportViewer1 = null;
        //            rd.Dispose();
        //            rd.Close();
        //            GC.Collect();
        //            GC.WaitForPendingFinalizers();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //    return counter;
        //}

        private int GetIncrementArrearRequisition()
        {
            GazetteDTO objGazetteDTO = new GazetteDTO();
            ReportBLL objReportBLL = new ReportBLL();
            int counter = 0;

            try
            {
                if (ddlUnitGroupId.SelectedValue.ToString() != " ")
                {
                    objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objGazetteDTO.UnitGroupId = "";
                }
                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objGazetteDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objGazetteDTO.UnitId = "";
                }

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objGazetteDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objGazetteDTO.SectionId = "";
                }

                objGazetteDTO.ArrearYear = txtGazetteYear.Text;
                if (ddlGazetteMonth.SelectedValue.ToString() != " ")
                {
                    objGazetteDTO.ArrearMonth = ddlGazetteMonth.SelectedValue.ToString();
                }
                else
                {
                    objGazetteDTO.ArrearMonth = "";
                }

                objGazetteDTO.HeadOfficeId = strHeadOfficeId;
                objGazetteDTO.BranchOfficeId = strBranchOfficeId;
                objGazetteDTO.UpdateBy = strEmployeeId;

                string strPath = string.Empty;
                //strPath = Path.Combine(Server.MapPath("~/Reports/RptExtendedSalaryRequisition.rpt"));
                strPath = Path.Combine(Server.MapPath("~/Reports/RptIncrementArrearRequisition.rpt"));

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                var data = objReportBLL.GetIncrementArrearRequisition(objGazetteDTO);
                counter = data.Rows.Count;

                if (counter > 0)
                {
                    rd.SetDataSource(data);
                    rd.SetDatabaseLogon("erp", "erp");
                    CrystalReportViewer1.ReportSource = rd;
                    CrystalReportViewer1.DataBind();
                    ReportFormatMaster();
                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
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
            return counter;
        }
        
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
                System.IO.Stream oStream = null;
                byte[] byteArray = null;

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                oStream = rd.ExportToStream(formatType);
                byteArray = new byte[oStream.Length];
                oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.BinaryWrite(byteArray);
                Response.Flush();
                Response.Close();
                rd.Close();
                rd.Dispose();
            }
            if (chkExcel.Checked == true)
            {
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }
        }

        protected void btnIncrementSheet_Click(object sender, EventArgs e)
        {
            if (txtGazetteYear.Text == string.Empty)
            {
                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtGazetteYear.Focus();
                return;
            }
            GetIncrementDetailSheet();
        }

        protected void btnIncrementRequisition_Click(object sender, EventArgs e)
        {

        }

        private int GetIncrementDetailSheet()
        {
            GazetteDTO objGazetteDTO = new GazetteDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();

            if (ddlUnitGroupId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.UnitGroupId = "";
            }
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.SectionId = "";
            }

            objGazetteDTO.Year = txtGazetteYear.Text;
            if (ddlGazetteMonth.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.Month = ddlGazetteMonth.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.Month = "";
            }
            objGazetteDTO.HeadOfficeId = strHeadOfficeId;
            objGazetteDTO.BranchOfficeId = strBranchOfficeId;
            objGazetteDTO.UpdateBy = strEmployeeId;

            string strPath = string.Empty;
            strPath = Path.Combine(Server.MapPath("~/Reports/IncrementDetailSheet.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);

            //dt.Rows.Count
            //var data = objGazetteBLL.AllIncrementSummerySheet(objGazetteDTO);
            var data = objGazetteBLL.GetIncrementDetailSheet(objGazetteDTO);
            
            int counter = data.Rows.Count;

            if (counter > 0)
            {
                rd.SetDataSource(data);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportFormatMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return counter;
        }
        protected void btnIncrementSummary_Click(object sender, EventArgs e)
        {
            try
            {
              int counter =  GetPeriodicIncrementHistorySummary();
                if(counter==0)
                {
                    MessageBox("No data found");
                }
            }
            catch
            {
            }
        }

        private int GetPeriodicIncrementHistorySummary()
        {
            GazetteDTO objGazetteDTO = new GazetteDTO();
            GazetteBLL objGazetteBLL = new GazetteBLL();

            if (ddlUnitGroupId.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.UnitGroupId = "";
            }

            objGazetteDTO.Year = txtGazetteYear.Text;
            if (ddlGazetteMonth.SelectedValue.ToString() != " ")
            {
                objGazetteDTO.Month = ddlGazetteMonth.SelectedValue.ToString();
            }
            else
            {
                objGazetteDTO.Month = "";
            }
            objGazetteDTO.HeadOfficeId = strHeadOfficeId;
            objGazetteDTO.BranchOfficeId = strBranchOfficeId;
            objGazetteDTO.UpdateBy = strEmployeeId;

            string strPath = string.Empty;
            strPath = Path.Combine(Server.MapPath("~/Reports/RptPeriodicIncrementHistorySummary.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            var data = objGazetteBLL.GetPeriodicIncrementHistorySummary(objGazetteDTO);

            int counter = data.Rows.Count;

            if (counter > 0)
            {
                rd.SetDataSource(data);
                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();
                ReportFormatMaster();
                this.CrystalReportViewer1.Dispose();
                this.CrystalReportViewer1 = null;
                rd.Dispose();
                rd.Close();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            return counter;
        }

        protected void btnReqSummary_Click(object sender, EventArgs e)
        {
            int counter = 0;
            try
            {
                if (txtGazetteYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtGazetteYear.Focus();
                    return;
                }

                if (ddlGazetteMonth.SelectedItem.Value == "0")
                {
                    string strMsg = "Please Select Month Name!!!";
                    MessageBox(strMsg);
                    ddlGazetteMonth.Focus();
                    return;
                }
                //counter = GetExtendedSalaryRequisition();
                counter = GetIncrementArrearReqSummary();

                if (counter == 0)
                {
                    string strMsg = "Please Analyze and then see the Requisition";
                    MessageBox(strMsg);
                    return;
                }
            }
            catch
            {
            }
        }

        private int GetIncrementArrearReqSummary()
        {
            GazetteDTO objGazetteDTO = new GazetteDTO();
            ReportBLL objReportBLL = new ReportBLL();
            int counter = 0;

            try
            {
                if (ddlUnitGroupId.SelectedValue.ToString() != " ")
                {
                    objGazetteDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objGazetteDTO.UnitGroupId = "";
                }
                                
                objGazetteDTO.ArrearYear = txtGazetteYear.Text;
                if (ddlGazetteMonth.SelectedValue.ToString() != " ")
                {
                    objGazetteDTO.ArrearMonth = ddlGazetteMonth.SelectedValue.ToString();
                }
                else
                {
                    objGazetteDTO.ArrearMonth = "";
                }

                objGazetteDTO.HeadOfficeId = strHeadOfficeId;
                objGazetteDTO.BranchOfficeId = strBranchOfficeId;
                objGazetteDTO.UpdateBy = strEmployeeId;

                string strPath = string.Empty;
                strPath = Path.Combine(Server.MapPath("~/Reports/RptIncrArrearReqSumWorker.rpt"));

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                var data = objReportBLL.GetIncrementArrearReqSummary(objGazetteDTO);
                counter = data.Rows.Count;

                if (counter > 0)
                {
                    rd.SetDataSource(data);
                    rd.SetDatabaseLogon("erp", "erp");
                    CrystalReportViewer1.ReportSource = rd;
                    CrystalReportViewer1.DataBind();
                    ReportFormatMaster();
                    this.CrystalReportViewer1.Dispose();
                    this.CrystalReportViewer1 = null;
                    rd.Dispose();
                    rd.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
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
            return counter;
        }
    }
}