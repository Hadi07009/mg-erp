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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeActiveInactive : System.Web.UI.Page
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

        ReportDocument rd = new ReportDocument();
        ExportFormatType formatType = ExportFormatType.NoFormat;
        string strDefaultName = "Report";
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
                getSectionId();
                GetEmployeeStatusId();
                getMonthYearForTax();
                clearMsg();
                getOfficeName();
                btnSearch.Focus();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }

            //gvOfficeShiftTime.Columns[5].Visible = false;
        }

        #region "Function"
        public void getDate()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getDate();
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
        public void clearMsg()
        {
            lblMsg.Text = string.Empty;
            //lblMsgRecord.Text = string.Empty;
        }

        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            ////txtSalaryYear.Text = objLookUpDTO.Year;
            ////txtsalaryMonth.Text = objLookUpDTO.Month;

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
        public void GetEmployeeStatusId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeStatusId.DataSource = objLookUpBLL.GetEmployeeStatusId();

            ddlEmployeeStatusId.DataTextField = "STATUS_NAME";
            ddlEmployeeStatusId.DataValueField = "STATUS_ID";

            ddlEmployeeStatusId.DataBind();
            if (ddlEmployeeStatusId.Items.Count > 0)
            {
                ddlEmployeeStatusId.SelectedIndex = 0;
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
        public void clearMessage()
        {
            lblMsg.Text = string.Empty;
        }
        #endregion
        protected void btnShow_Click(object sender, EventArgs e)
        {
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetActiveInactiveEmployee();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        public void GetActiveInactiveEmployee()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }
           
            objEmployeeDTO.EmployeeId = txtEmpId.Text; ;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.FromDate = DtpStartDate.Text;
            objEmployeeDTO.ToDate = DtpEndDate.Text;
            objEmployeeDTO.ActiveYn = chkActiveYnSearch.Checked == true ? "Y" : "N";
            //objEmployeeDTO.Year = txtSalaryYear.Text;
            //objEmployeeDTO.Month = txtsalaryMonth.Text;
            var basicInfo = objEmployeeBLL.GetActiveInactiveEmployee(objEmployeeDTO);

            int counter = 0;
            foreach(var item in basicInfo)
            {
                counter = counter + 1;
                item.SLNo = counter.ToString();
            }

            if (basicInfo.Count > 0)
            {
                gvActiveInactiveEmployee.DataSource = basicInfo;
                gvActiveInactiveEmployee.DataBind();

                int count = basicInfo.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                //lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvActiveInactiveEmployee.DataSource = basicInfo;
                gvActiveInactiveEmployee.DataBind();
                string strMsg = "NO RECORD FOUND!!!";
                //lblMsgRecord.Text = strMsg;
            }  
        }
        #region "Grid View Functionality"
        protected void gvActiveInactiveEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvActiveInactiveEmployee.PageIndex = e.NewPageIndex;
        }
        #endregion

        protected void gvActiveInactiveEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
        protected void gvActiveInactiveEmployee_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        } 
        public string ActiveInactiveEmployeeSave()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            try
            {                
                string status = string.Empty;

                foreach (GridViewRow row in gvActiveInactiveEmployee.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                            if (ddlEmployeeStatusId.SelectedValue.ToString() != "")
                            {
                                objEmployeeDTO.StatusId = ddlEmployeeStatusId.SelectedValue.ToString();
                            }
                            else
                            {
                                objEmployeeDTO.StatusId = "";
                            }
                                                        
                            objEmployeeDTO.Status = txtEmployeeStatus.Text;
                            objEmployeeDTO.EffectiveDate = DtpEffectiveDate.Text;
                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;
                            objEmployeeDTO.ActiveYn = chkActiveYn.Checked == true ? "Y" : "N";

                            strMsg = objEmployeeBLL.ActiveInactiveEmployeeSave(objEmployeeDTO);
                          
                        }
                    }
                }               
            }
            catch (Exception ex)
            {
            }
            return strMsg;
        }
        protected void gvActiveInactiveEmployee_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void gvActiveInactiveEmployee_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void gvActiveInactiveEmployee_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Visible = true;

            int strRowId = gvActiveInactiveEmployee.SelectedRow.RowIndex;
            //txtCardNo.Text = gvActiveInactiveEmployee.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            //txtEmployeeName.Text = gvActiveInactiveEmployee.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //txtDesignationName.Text = gvActiveInactiveEmployee.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            //txtEmployeeId.Text = gvActiveInactiveEmployee.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");         
        }
        protected void gvActiveInactiveEmployee_OnRowDataBound(object sender, EventArgs e)
        {
        }
        protected void gvActiveInactiveEmployee_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
        }
        protected void ddlShifyTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlEmployeeStatusId.Text == "")
            {
                string strMsg = "Please Select Active or Inactive Cause!";
                MessageBox(strMsg);
                ddlEmployeeStatusId.Focus();
                return;
            }

            if (ddlEmployeeStatusId.Text == "9" || ddlEmployeeStatusId.Text == "11" || ddlEmployeeStatusId.Text == "12")
            {
                if (string.IsNullOrEmpty(DtpEffectiveDate.Text))
                {
                    string strMsg = "Please Select Effect Date!";
                    MessageBox(strMsg);
                    ddlEmployeeStatusId.Focus();
                    return;
                }

                //if (string.IsNullOrEmpty(txtEmployeeStatus.Text))
                //{
                //    string strMsg = "Please Enter Remarks!";
                //    MessageBox(strMsg);
                //    txtEmployeeStatus.Focus();
                //    return;
                //}
            }

            string messgae = ActiveInactiveEmployeeSave();
            lblMsg.Text = messgae;
            MessageBox(messgae);
            GetActiveInactiveEmployee();
        }
        protected void ddlRosterId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        
        private void ClearAfterBasicSelection()
        {
            //txtCardNo.Text = string.Empty;
            //txtEmployeeName.Text = string.Empty;
            //txtDesignationName.Text = string.Empty;
            //txtEmployeeId.Text = string.Empty;
            chkActiveYn.Checked = false;
           // btnSave.Visible = true;
            gvActiveInactiveEmployee.DataSource = null;
            gvActiveInactiveEmployee.DataBind();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAfterBasicSelection();
            }
            catch(Exception exp)
            {
                throw exp;
            }
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

                rd.ExportToHttpResponse
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "tax_sheet");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
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
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
            }
        }
        protected void btnLog_Click(object sender, EventArgs e)
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            //foreach (GridViewRow row in gvActiveInactiveEmployee.Rows)
            //{
            //    if (row.RowType == DataControlRowType.DataRow)
            //    {
            //        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
            //        if (chkEmployee.Checked)
            //        {
            //            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
            //            objReportDTO.EmployeeId = txtEmployeeId.Text;
            //        }
            //    }
            // }
            objReportDTO.CardNo = txtEmpId.Text; ;
            objReportDTO.CardNo = "";
            objReportDTO.FromDate = DtpStartDate.Text;
            objReportDTO.ToDate = DtpEndDate.Text;
            objReportDTO.UnitId = ddlUnitId.SelectedValue;
            objReportDTO.SectionId = ddlSectionId.SelectedValue;

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strPath = Path.Combine(Server.MapPath("~/Reports/RptActiveInactiveEmployeeHistory.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.GetEmpActiveInactiveHistory(objReportDTO));

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
        #region "Crystal Report Functionality"
        protected void Page_UnLoad(object sender, EventArgs e)
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
            this.CrystalReportViewer1.ReportSource = null;
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

        protected void BtnDailyLog_Click(object sender, EventArgs e)
        {

        }
    }
}