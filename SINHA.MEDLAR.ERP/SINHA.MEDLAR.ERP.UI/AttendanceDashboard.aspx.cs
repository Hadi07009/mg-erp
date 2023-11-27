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
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.HtmlControls;
using CrystalDecisions.Web;
using SINHA.MEDLAR.ERP.COMMON.Utility.Image;
using System.Web.Services;
using SINHA.MEDLAR.ERP.BLL.Utility.MessageBLL.EmailBLL;
using SINHA.MEDLAR.ERP.COMMON.Utility.Excel;

using SINHA.MEDLAR.ERP.UI.FluentSchedulers;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AttendanceDashboard : System.Web.UI.Page
    {
        string strEmployeeId = "";
        string strSectionId = "";
        string strDepartmentId = "";
        string strDesignationId = "";
        string strUnitId = "";
        string strCatagoryId;
        private static string strHeadOfficeId = "";
        private static string strBranchOfficeId = "";
        string strEmployeeTypeId = "";
        string strLoginDay = "";
        string strLoginMonth = "";
        string strLoginDate = "";
        string strID = "";
        ReportDocument rd = new ReportDocument();
        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterOnSubmitStatement(typeof(Page), "closePage", "window.onunload = CloseWindow();");

            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }

            if (!IsPostBack)
            {
                
                loadSesscion();
                GetMonthYearForSalary();
                getOfficeName();
                lblMsg.Text = string.Empty;
                
            }
            if (IsPostBack)
            {
                loadSesscion();
                Session["strID"] = null;
            }
            dtpLogDate.Attributes.Add("onkeypress", "return controlEnter('" + txtPresent.ClientID + "', event)");
            txtPresent.Attributes.Add("onkeypress", "return controlEnter('" + txtDayOffOther.ClientID + "', event)");
            txtDayOffOther.Attributes.Add("onkeypress", "return controlEnter('" + txtLeave.ClientID + "', event)");
            txtLeave.Attributes.Add("onkeypress", "return controlEnter('" + txtLeaveOther.ClientID + "', event)");
            txtLeaveOther.Attributes.Add("onkeypress", "return controlEnter('" + txtOutDuty.ClientID + "', event)");
            txtOutDuty.Attributes.Add("onkeypress", "return controlEnter('" + txtOutDutyOther.ClientID + "', event)");
            txtOutDutyOther.Attributes.Add("onkeypress", "return controlEnter('" + txtNightDuty.ClientID + "', event)");
            txtNightDuty.Attributes.Add("onkeypress", "return controlEnter('" + txtNightDutyOther.ClientID + "', event)");
            txtNightDutyOther.Attributes.Add("onkeypress", "return controlEnter('" + txtRecruitment.ClientID + "', event)");
            txtRecruitment.Attributes.Add("onkeypress", "return controlEnter('" + txtUnrecognizedToMachine.ClientID + "', event)");
            txtUnrecognizedToMachine.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }
        #region "Load Drop Down List"


        #region "Encrypt"
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
                
        #endregion
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

            if (Session["strID"] != null)
            {
                strID = Session["strID"].ToString().Trim();
            }
        }
        public void CreateSession()
        {
            string employeeId = "_" + Request.Cookies["eid"].Value.ToString();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            var employee = objEmployeeBLL.GetEmployeeById(employeeId);
            string suffix = "_" + (string)employee.Rows[0]["BRANCH_OFFICE_ID"];

            strEmployeeId = Session["strEmployeeId" + suffix].ToString().Trim();
            strSectionId = Session["strSectionId" + suffix].ToString().Trim();
            strDesignationId = Session["strDesignationId" + suffix].ToString().Trim();
            strUnitId = Session["strUnitId" + suffix].ToString().Trim();
            strCatagoryId = Session["strCatagoryId" + suffix].ToString().Trim();
            strHeadOfficeId = Session["strHeadOfficeId" + suffix].ToString().Trim();
            strBranchOfficeId = Session["strBranchOfficeId" + suffix].ToString().Trim();
            strLoginDay = Session["strLoginDay" + suffix].ToString().Trim();
            strLoginMonth = Session["strLoginMonth" + suffix].ToString().Trim();
            strLoginDate = Session["strLoginDate" + suffix].ToString().Trim();
            if (Session["strID" + suffix] != null)
            {
                strID = Session["strID" + suffix].ToString().Trim();
            }
        }
        public void ClearSession()
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

        public void GetMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();
        }

       
        #endregion
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void passValue(string strEmployeeId, string strHeadOfficeId)
        {
            //txtEmployeeId.Text = strEmployeeId;
            //txtEmployeeId.Text = Session["strID"].ToString().Trim();
            //searchEmployeeInfo();

        }
        #endregion
        #region "DML"

        public void SaveAttendanceDashboard()
        {

            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            AttendanceDashboardDTO objAttendanceDashboardDTO = new AttendanceDashboardDTO();
            
            objAttendanceDashboardDTO.AttendanceDashBoardId = txtAttendanceDashBoardID.Text;
            objAttendanceDashboardDTO.LogDate = dtpLogDate.Text;

            objAttendanceDashboardDTO.Present = txtPresent.Text;
            objAttendanceDashboardDTO.DayOffOther = txtDayOffOther.Text;
            objAttendanceDashboardDTO.Leave = txtLeave.Text;
            objAttendanceDashboardDTO.LeaveOther = txtLeaveOther.Text;
            objAttendanceDashboardDTO.OutDuty = txtOutDuty.Text;
            objAttendanceDashboardDTO.OutDutyOther = txtOutDutyOther.Text;
            objAttendanceDashboardDTO.NightDuty = txtNightDuty.Text;
            objAttendanceDashboardDTO.NightDutyOther = txtNightDutyOther.Text;
            objAttendanceDashboardDTO.Recruitment = txtRecruitment.Text;
            objAttendanceDashboardDTO.UnrecognizedToMachine = txtUnrecognizedToMachine.Text;
            
            objAttendanceDashboardDTO.Punch = txtPunch.Text;
            objAttendanceDashboardDTO.PunchOther = txtOtherPunch.Text;
            objAttendanceDashboardDTO.Active = txtActive.Text;
            objAttendanceDashboardDTO.ActiveOther = txtOtherActive.Text;
            
            //objAttendanceDashboardDTO.PunchInvalid = lblPunchInvalid.Text;

            objAttendanceDashboardDTO.StandByYn = ChkStandBy.Checked == true ? "Y" : "N";

            objAttendanceDashboardDTO.CreateBy = strEmployeeId;
            objAttendanceDashboardDTO.HeadOfficeId = strHeadOfficeId;
            objAttendanceDashboardDTO.BranchOfficeId = strBranchOfficeId;                      
                       
            string strMsg = objEmployeeBLL.SaveAttendanceDashboard(objAttendanceDashboardDTO);

            if (strMsg == "OK")
            {
                MessageBox("Saved Successfully");
            }
            else
            {
                MessageBox(strMsg);
            }

        }

        public void clear()
        {
            lblMsg.Text = string.Empty;
            dtpLogDate.Text = string.Empty;
            txtPresent.Text = string.Empty;
            txtDayOffOther.Text = string.Empty;
            txtLeave.Text = string.Empty;
            txtLeaveOther.Text = string.Empty;
            txtOutDuty.Text = string.Empty;
            txtOutDutyOther.Text = string.Empty;
            txtNightDuty.Text = string.Empty;
            txtNightDutyOther.Text = string.Empty;
            txtRecruitment.Text = string.Empty;
            txtUnrecognizedToMachine.Text = string.Empty;
            txtPunch.Text = string.Empty;
            txtOtherPunch.Text = string.Empty;
            txtActive.Text = string.Empty;
            txtOtherActive.Text = string.Empty;
            //txtPunchInvalid.Text = string.Empty;
            ChkStandBy.Checked = false;



            txtAttendanceDashBoardID.Text = string.Empty;
        }

        public void loadCombo()
        {                        
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                GetAttendanceDashboard();
            }
            catch (Exception ex)
            {
              //  throw new Exception("Error : " + ex.Message);
            }
        }
       
        public void GetAttendanceDashboard()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpToDate.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            
            dt = objEmployeeBLL.GetAttendanceDashboard(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GvAttendanceDashboard.DataSource = dt;
                GvAttendanceDashboard.DataBind();

                //int count = ((DataTable)GvAttendanceDashboard.DataSource).Rows.Count;
                //string strMsg = " TOTAL " + count + " RECORD FOUND";
                //lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvAttendanceDashboard.DataSource = dt;
                GvAttendanceDashboard.DataBind();
                int totalcolums = GvAttendanceDashboard.Rows[0].Cells.Count;
                GvAttendanceDashboard.Rows[0].Cells.Clear();
                GvAttendanceDashboard.Rows[0].Cells.Add(new TableCell());
                GvAttendanceDashboard.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GvAttendanceDashboard.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    if (dtpLogDate.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Logdate";
                        MessageBox(strMsg);
                        dtpLogDate.Focus();
                        return;
                    }
                   
                    SaveAttendanceDashboard();
                    clear();
                    GetAttendanceDashboard();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        #region "Grid View Functionality"
       
        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

        protected void GvAttendanceDashboard_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvAttendanceDashboard.PageIndex = e.NewPageIndex;
        }

        protected void GvAttendanceDashboard_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //clear();
            int strRowId = GvAttendanceDashboard.SelectedRow.RowIndex + 1;
            string strSLNo = GvAttendanceDashboard.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string Logdate = GvAttendanceDashboard.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string Present = GvAttendanceDashboard.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string DayOffOther = GvAttendanceDashboard.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string Leave = GvAttendanceDashboard.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string LeaveOther = GvAttendanceDashboard.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string OutDuty = GvAttendanceDashboard.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string OutDutyOther = GvAttendanceDashboard.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string NightDuty = GvAttendanceDashboard.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string NightDutyOther = GvAttendanceDashboard.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            string Recruitment = GvAttendanceDashboard.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string UnrecognizeMachine = GvAttendanceDashboard.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            string Punch = GvAttendanceDashboard.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            string PunchOther = GvAttendanceDashboard.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            //string PunchInvalid = GvAttendanceDashboard.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            string Active = GvAttendanceDashboard.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            string ActiveOther = GvAttendanceDashboard.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");            
            string DashboardId = GvAttendanceDashboard.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
            string StandBy = GvAttendanceDashboard.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");

            dtpLogDate.Text = Logdate;
            txtPresent.Text = Present;
            txtDayOffOther.Text = DayOffOther;
            txtLeave.Text = Leave;
            txtLeaveOther.Text = LeaveOther;
            txtOutDuty.Text = OutDuty;
            txtOutDutyOther.Text = OutDutyOther;
            txtNightDuty.Text = NightDuty;
            txtNightDutyOther.Text = NightDutyOther;
            txtRecruitment.Text = Recruitment;
            txtUnrecognizedToMachine.Text = UnrecognizeMachine;
            txtPunch.Text = Punch;
            txtOtherPunch.Text = PunchOther;
            //txtPunchInvalid.Text = PunchInvalid;
            txtActive.Text = Active;
            txtOtherActive.Text = ActiveOther;
            txtAttendanceDashBoardID.Text = DashboardId;

            if(StandBy == "Yes")
            {
                ChkStandBy.Checked = true;
            }
            else
            {
                ChkStandBy.Checked = false;
            }
        }
        protected void GvAttendanceDashboard_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void GvAttendanceDashboard_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvAttendanceDashboard, "Select$" + e.Row.RowIndex);
            //}
        }
        protected void GvAttendanceDashboard_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            string EmployeeId = Convert.ToString(GvAttendanceDashboard.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);

            objSalaryDTO.EmployeeId = EmployeeId;
            
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;
            //string MSG = objSalaryBLL.DeleteEmpFromFoodDeduction(objSalaryDTO);
            //lblMsg.Text = MSG;
            GetAttendanceDashboard();
        }
        protected void GvAttendanceDashboard_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GvAttendanceDashboard_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GvEmployeeCache.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }


        #endregion

        public void reportMaster()
        {

            if (chkPDF.Checked == true)
            {

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

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

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "employee_report");
                Response.End();
                //CrystalReportViewer1.RefreshReport();

            }
        }
        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            //CrystalReportViewer1.Dispose();
            //CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {
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

        protected void btnSheet_Click(object sender, EventArgs e)
        {

            try
            {
                GetResignEmployeeSheet();
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
     

    
        public void GetResignEmployeeSheet()
        {

            try
            {
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
              
                objEmployeeDTO.CreateBy = strEmployeeId;


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptResignEmployeeSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objEmployeeBLL.GetResignEmployee(objEmployeeDTO));

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

        protected void btnSendMail_Click(object sender, EventArgs e)
        {

            try {

                //NotifyAttendance obj = new NotifyAttendance();
                //obj.Notify();

                //old

                EmailBLL email = new EmailBLL();                
                string toAddress = txtEmailAddress.Text;
                string ccAddress = string.Empty;
                string fromDisplayName = "ERP- SINHA MEDLAR GROUP";
                string subject = "Human Triggered System generated report for attendance summary of " + dtpFromDate.Text;
                
                string actionName = string.Empty;
                
                if (dtpFromDate.Text == string.Empty)
                {
                    MessageBox("Enter Valid From Date");
                    return;
                }

                if (txtEmailAddress.Text == string.Empty)
                {
                    MessageBox("Enter Valid Email Address");
                    return;
                }

                string branchOfficeName = string.Empty;
                string branchNameShort = string.Empty;

                if (strBranchOfficeId == "103")
                {
                    branchOfficeName = "Medlar Apparels Limited";
                    branchNameShort = "MAL";
                }
                if (strBranchOfficeId == "102")
                {
                    branchOfficeName = "JK Fashions Limited";
                    branchNameShort = "JK";
                }

                AttendanceDashboardDTO objDashboard = new AttendanceDashboardDTO();
                DashboardBLL objDashboardBLL = new DashboardBLL();

                objDashboard.LogDate = dtpFromDate.Text;
                objDashboard.HeadOfficeId = strHeadOfficeId;
                objDashboard.BranchOfficeId = strBranchOfficeId;

                objDashboard = objDashboardBLL.GetAttendanceDashboard(objDashboard);

                if (objDashboard != null)
                {
                    if (objDashboard.StandByYn == "N")
                    {
                        #region Make Attachment

                        string fileName = string.Empty;
                        string filePath = string.Empty;
                        string extention = ".xlsx";
                        string downloadFileName = string.Empty;

                        System.DateTime moment = DateTime.Now;

                        string year = moment.Year.ToString();
                        string month = moment.Month.ToString();
                        string day = moment.Day.ToString();

                        string hour = moment.Hour.ToString();
                        string minute = moment.Minute.ToString();
                        string second = moment.Second.ToString();

                        string dateTime = day.PadLeft(2, '0') + month.PadLeft(2, '0') + year + "_" + hour.PadLeft(2, '0') + minute.PadLeft(2, '0') + second.PadLeft(2, '0');
                        downloadFileName = branchNameShort + "_" + dateTime + extention;

                        string dirPath = HttpContext.Current.Server.MapPath("ExcelFiles");

                        filePath = dirPath + "\\" + downloadFileName;

                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }

                        EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                        EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                        objEmployeeDTO.LogDate = dtpFromDate.Text;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        objEmployeeDTO.SittingBranchOfficeId = strBranchOfficeId;

                        var foreignData = objEmployeeBLL.GetUnpunchedForeignEmployee(objEmployeeDTO);
                        ExcelService.GenerateExcel(foreignData, filePath, "HO");

                        var homeData = objEmployeeBLL.GetUnpunchedHomeEmployee(objEmployeeDTO);
                        ExcelService.GenerateExcel(homeData, filePath, "FACTORY STAFF AND WORKER");

                        #endregion

                        #region Send Mail                    
                        actionName = "With due respect, following table shows the attendance summary of " + branchOfficeName + "-";
                        email.SendAttendanceSummary(toAddress, ccAddress, fromDisplayName, subject, actionName, objDashboard, filePath);
                        MessageBox("Mail Sending Successfull");

                        #endregion
                    }
                }
                else
                {
                    
                    //toAddress = txtEmailAddress.Text;
                    //ccAddress = string.Empty;
                    //fromDisplayName = "ERP- SINHA MEDLAR GROUP";
                    //subject = "Human Triggered System generated report for attendance summary of " + dtpFromDate.Text;

                    actionName = "System did not find master data related to attendance of " + branchOfficeName + ", because of this- system could not populate attendance summary. ";
                    email.SendNotFoundMail(toAddress, ccAddress, fromDisplayName, subject, actionName);
                    MessageBox("Not Found- Mail Sending Successfull");
                }
                
            }
            catch
            {
                MessageBox("Unable to send mail...");
            }
        }
    }
}