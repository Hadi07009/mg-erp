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
    public partial class MFSTemplateHalfSalary : System.Web.UI.Page
    {
        private const string paymentTypeId = "2"; //HALF SALARY
        private const string eidTypeId = null;
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
                getMonthYearForTax();
                //getAttendencePrivilaged();
                //btnSearch.Focus();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }
        
        protected void Page_Init(object sender, EventArgs e)
        {
        }
        #region "Function"
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
           // lblMsg.Text = string.Empty;
        }    
        public void clearMsg()
        {
           // lblMsg.Text = string.Empty;
           // lblMsgRecord.Text = string.Empty;
        }
        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtSalaryYear.Text = objLookUpDTO.Year;
            txtsalaryMonth.Text = objLookUpDTO.Month;

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
        public Int32 GetPaperSize(String sPrinterName, String sPaperSizeName)
        {
            PrintDocument docPrintDoc = new PrintDocument();
            docPrintDoc.PrinterSettings.PrinterName = sPrinterName;
            for (int i = 0; i < docPrintDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                int raw = docPrintDoc.PrinterSettings.PaperSizes[i].RawKind;
                if (docPrintDoc.PrinterSettings.PaperSizes[i].PaperName == sPaperSizeName)
                {
                    return raw;
                }
            }
            return 0;
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

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
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
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
            }
        }
        #region "Grid View Functionality"

        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //string strDesignation = GridView1.SelectedRow.Cells[3].Text;
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            //searchInactiveEmployee();
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //string EmpId = gvEmployeeList.SelectedRow.Cells[2].Text;
            //string Unit = gvEmployeeList.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            //string Section = gvEmployeeList.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            //string ResignDate = gvEmployeeList.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            //string ResignCause = gvEmployeeList.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");          
        }
        
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {            

        }


        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }
                
        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }
        
        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

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
        #endregion

        protected void btnMonthlySalaryMfsTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                
                GetMonthlySalaryMfsTemplate();
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
        public void GetMonthlySalaryMfsTemplate()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlySalaryMfsTemplate(objReportDTO));


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

        //
        public void GetMonthlySalaryMasterBkashTemplateByPhase()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                objReportDTO.PaymentTypeId = paymentTypeId;
                objReportDTO.EidTypeId = eidTypeId;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlySalaryMasterBkashTemplateByPhase(objReportDTO));


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

        //New
        public void GetMonthlySalaryForwardTemplateByPhase()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                objReportDTO.PaymentTypeId = paymentTypeId;
                objReportDTO.EidTypeId = eidTypeId;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlySalaryForwardTemplateByPhase(objReportDTO));


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



        public void GetMonthlyHoldSalaryBkashTemplateByPhase()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                objReportDTO.PaymentTypeId = paymentTypeId;
                objReportDTO.EidTypeId = eidTypeId;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlyHoldSalaryBkashTemplateByPhase(objReportDTO));


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


        public void GetMonthlyUnholdSalaryBkashTemplateByPhase()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                objReportDTO.PaymentTypeId = paymentTypeId;
                objReportDTO.EidTypeId = eidTypeId;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlyUnholdSalaryBkashTemplateByPhase(objReportDTO));


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

        protected void btnRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                GetMonthlySalaryMfsReq();
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
        public void GetMonthlySalaryMfsReq()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;



                string strPath = Path.Combine(Server.MapPath("~/Reports/RptMasterTplReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlySalaryMfsReq(objReportDTO));


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
                
        public void GetMonthlySalaryMasterBkashReqByPhase()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                objReportDTO.PaymentTypeId = paymentTypeId;
                objReportDTO.EidTypeId = eidTypeId;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptMasterTplReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlySalaryMasterBkashReqByPhase(objReportDTO));
                
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

        public void GetMonthlyHoldSalaryBkashReqByPhase()
        {
            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                objReportDTO.PaymentTypeId = paymentTypeId;
                objReportDTO.EidTypeId = eidTypeId;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptMasterTplReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlyHoldSalaryBkashReqByPhase(objReportDTO));

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


        public void GetMonthlyUnholdSalaryBkashReqByPhase()
        {
            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                objReportDTO.PaymentTypeId = paymentTypeId;
                objReportDTO.EidTypeId = eidTypeId;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptMasterTplReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlyUnholdSalaryBkashReqByPhase(objReportDTO));

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
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetSalaryUnitSectionTopGrid();
            GetSalaryUnitSectionBottomGrid();
        }
        public void GetSalaryUnitSectionBottomGrid()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            DataTable dt = new DataTable();

            if (ddlPhaseId.SelectedValue.ToString() != "")
            {
                objEmployeeDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.PhaseId = "";
            }

            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;
            objEmployeeDTO.PaymentTypeId = paymentTypeId;
            objEmployeeDTO.EidTypeId = eidTypeId;
            objEmployeeDTO.CreateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            dt = objEmployeeBLL.GetSalaryUnitSectionBottomGrid(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        public void GetSalaryUnitSectionTopGrid()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            DataTable dt = new DataTable();

            if (ddlPhaseId.SelectedValue.ToString() != "")
            {
                objEmployeeDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.PhaseId = "";
            }

            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;

            objEmployeeDTO.PaymentTypeId = paymentTypeId;
            objEmployeeDTO.EidTypeId = eidTypeId;

            objEmployeeDTO.CreateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            dt = objEmployeeBLL.GetSalaryUnitSection(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if(txtSalaryYear.Text == string.Empty)
            {
                MessageBox("Please Enter Salary Year");
                txtSalaryYear.Focus();
                return;
            }
            if (txtsalaryMonth.Text == string.Empty)
            {
                MessageBox("Please Enter Salary Month");
                txtsalaryMonth.Focus();
                return;
            }

            if(ddlPhaseId.SelectedItem.Value == string.Empty)
            {
                MessageBox("Please Select Payment Phase");
                ddlPhaseId.Focus();
                return;
            }

            CreatePhaseIdInMonthlySalary();
            GetSalaryUnitSectionTopGrid();
            GetSalaryUnitSectionBottomGrid();
        }
        public string CreatePhaseIdInMonthlySalary()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";
            int recordCounter = 0;

            try
            {
                objEmployeeDTO.Year = txtSalaryYear.Text;
                objEmployeeDTO.Month = txtsalaryMonth.Text;
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objEmployeeDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objEmployeeDTO.PhaseId = "";
                }

                objEmployeeDTO.PaymentTypeId = paymentTypeId; //HALF salary

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                strMsg = objEmployeeBLL.IsPhaseWiseSalaryLock(objEmployeeDTO);

                if(strMsg != "OK")
                {
                    MessageBox(strMsg);
                    return strMsg;
                }
                
                string status = string.Empty;
                foreach (GridViewRow row in gvEmployeeList.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployeeList");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtUnitId = (TextBox)row.FindControl("txtUnitId");
                            TextBox txtSectionId = (TextBox)row.FindControl("txtSectionId");

                            objEmployeeDTO.UnitId = txtUnitId.Text;
                            objEmployeeDTO.SectionId = txtSectionId.Text;
                            
                            objEmployeeDTO.CreateBy = strEmployeeId;
                            strMsg = objEmployeeBLL.CreatePhaseIdInMonthlySalary(objEmployeeDTO);
                        }
                    }
                }
                MessageBox(strMsg);
            }
            catch (Exception ex)
            {
            }
            return strMsg;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdatePhaseIdInMonthlySalary();
            GetSalaryUnitSectionBottomGrid();
            GetSalaryUnitSectionTopGrid();
        }
        public void UpdatePhaseIdInMonthlySalary()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string status = string.Empty;
            string strMsg = "";
            string result = "";

            List<EmployeeDTO> phaseList = new List<EmployeeDTO>();
            string phgId = string.Empty;

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    objEmployeeDTO = new EmployeeDTO();

                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        TextBox phaseId = (TextBox)row.FindControl("PhaseId");
                        TextBox salaryYear = (TextBox)row.FindControl("SalaryYear");
                        TextBox salaryMonth = (TextBox)row.FindControl("SalaryMonth");

                        //TextBox paymentPhaseSource = (TextBox)row.FindControl("txtpayment_phase_source");
                        
                        objEmployeeDTO.Year = salaryYear.Text;
                        objEmployeeDTO.Month = salaryMonth.Text;
                        objEmployeeDTO.PhaseId = phaseId.Text;

                        objEmployeeDTO.PaymentTypeId = paymentTypeId;
                        objEmployeeDTO.EidTypeId = eidTypeId;

                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        objEmployeeDTO.CreateBy = strEmployeeId;


                        if (phgId!= phaseId.Text)
                        {
                            objEmployeeDTO.PhaseId = phaseId.Text;
                            phaseList.Add(objEmployeeDTO);
                            //phaseList.Add(phaseId.Text);
                            phgId = phaseId.Text;
                        }
                        
                       //salary year validation
                       if(txtSalaryYear.Text != salaryYear.Text)
                        {

                        }

                        //salary month validation
                        if (txtsalaryMonth.Text != salaryMonth.Text)
                        {

                        }
                        
                    }
                }
            }

            int counter = 0;
            foreach (var item in phaseList)
            {
                result = objEmployeeBLL.IsPhaseWiseSalaryLock(item);

                if(result!="OK")
                {
                    counter = counter + 1;
                }
            }

            if(counter>0)
            {
                MessageBox("Lock found.");
                return;
            }
                                   

            objEmployeeDTO = new EmployeeDTO();
            int recordCounter = 0;
            try
            {
                
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtUnitId = (TextBox)row.FindControl("txtUnitId");
                            TextBox txtSectionId = (TextBox)row.FindControl("txtSectionId");
                            TextBox phaseId = (TextBox)row.FindControl("PhaseId");

                            TextBox paymentPhaseSource = (TextBox)row.FindControl("txtpayment_phase_source");

                            objEmployeeDTO.UnitId = txtUnitId.Text;
                            objEmployeeDTO.SectionId = txtSectionId.Text;
                                                        
                            objEmployeeDTO.PaymentTypeId = paymentTypeId; //HALF SALARY
                            objEmployeeDTO.PaymentTypeId = null;
                            objEmployeeDTO.Year = txtSalaryYear.Text;
                            objEmployeeDTO.Month = txtsalaryMonth.Text;

                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;

                            if (paymentPhaseSource.Text != "Individual")
                            {
                                strMsg = objEmployeeBLL.UpdatePhaseIdInMonthlySalary(objEmployeeDTO);
                            }
                            //chkEmployee.Checked = false;       
                        }
                    }
                }
                if(!string.IsNullOrEmpty(strMsg))
                   MessageBox(strMsg);
            }
            catch (Exception ex)
            {
            }
            return;
        }

        protected void btnMasterTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }

                GetMonthlySalaryMasterBkashTemplateByPhase();
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

        protected void btnMasterRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                GetMonthlySalaryMasterBkashReqByPhase();
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

        protected void btnUnholdRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                GetMonthlyUnholdSalaryBkashReqByPhase();
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

        protected void btnUnholdTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }

                GetMonthlyUnholdSalaryBkashTemplateByPhase();
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

        protected void btnHoldRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                GetMonthlyHoldSalaryBkashReqByPhase();
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

        protected void btnHoldTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }

                GetMonthlyHoldSalaryBkashTemplateByPhase();
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

        protected void btnTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }

                GetMonthlySalaryForwardTemplateByPhase();
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

        protected void BtnIndividualPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndividualPaymentPhase.aspx?paymentTypeId=" + paymentTypeId);
        }

        protected void BtnPaymentHold_Click(object sender, EventArgs e)
        {
            Response.Redirect("PaymentHold.aspx?paymentTypeId=" + paymentTypeId);
        }
    }  
}
