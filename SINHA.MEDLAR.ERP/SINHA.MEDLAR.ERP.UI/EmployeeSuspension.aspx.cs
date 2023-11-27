using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI
{
    
    public partial class EmployeeSuspension : System.Web.UI.Page
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

        CrystalReportViewer CrystalReportViewer1 = new CrystalReportViewer();

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
                //getLeaveId();
                getEmployeeId();
                getUnitId();
                getSectionId();
                getOfficeName();
                getMonthYearForSalary();
                lblMsg.Text = "";
                lblMsgRecord.Text = "";
            }
            if (IsPostBack)
            {
                loadSesscion();
            }

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



                ////CrystalReportViewer1.ReportSource = rd;
                ////CrystalReportViewer1.DataBind();
                //ReportDocument crReportDocument = new ReportDocument();
                //Response.Clear();
                //Response.Buffer = true;

                //formatType = ExportFormatType.PortableDocFormat;
                //System.IO.Stream oStream = null;
                //byte[] byteArray = null;

                //Response.Buffer = false;
                //Response.ClearContent();
                //Response.ClearHeaders();

                //oStream = rd.ExportToStream(formatType);
                //byteArray = new byte[oStream.Length];
                //oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
                //Response.ClearContent();
                //Response.ClearHeaders();
                //Response.ContentType = "application/pdf";
                //Response.BinaryWrite(byteArray);
                //Response.Flush();
                //Response.Close();
                //rd.Close();
                //rd.Dispose();
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
        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getYearMonth();

            //txtYear.Text = objLookUpDTO.Year;


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
        public void getEmployeeId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlApprovedById.DataSource = objLookUpBLL.getApprovedId();

            ddlApprovedById.DataTextField = "EMPLOYEE_NAME";
            ddlApprovedById.DataValueField = "employee_id";     
            ddlApprovedById.DataBind();
            if (ddlApprovedById.Items.Count > 0)
            {
                ddlApprovedById.SelectedIndex = 0;
            }
        }

        public void clear()
        {
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;

            txtRemarks.Text = string.Empty;
            dtpEndDate.Text = string.Empty;
            dtpStartDate.Text = string.Empty;
            ddlApprovedById.SelectedIndex = 0;
        }
        public void SaveEmployeeSuspension()
        {

            LeaveDTO objEmployeeLeaveDTO = new LeaveDTO();
            LeaveBLL objEmployeeLeaveBLL = new LeaveBLL();

            objEmployeeLeaveDTO.SuspensionId = txtSuspensionId.Text;
            objEmployeeLeaveDTO.EmployeeId = txtEmployeeId.Text;                      
            objEmployeeLeaveDTO.StartDate = dtpStartDate.Text;
            objEmployeeLeaveDTO.EndDate = dtpEndDate.Text;

            if (ddlApprovedById.SelectedValue.ToString() != " ")
            {
                objEmployeeLeaveDTO.ApprovedBy = ddlApprovedById.SelectedValue.ToString();
            }
            else
            {
                objEmployeeLeaveDTO.ApprovedBy = "";
            }
            objEmployeeLeaveDTO.Remarks = txtRemarks.Text;
            objEmployeeLeaveDTO.CreateBy = strEmployeeId;
            objEmployeeLeaveDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeLeaveDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeLeaveBLL.SaveEmployeeSuspension(objEmployeeLeaveDTO);
            lblMsg.Text = strMsg;

            
        }
        public void DeleteEmployeeLeave()
        {

            LeaveDTO objEmployeeLeaveDTO = new LeaveDTO();
            LeaveBLL objEmployeeLeaveBLL = new LeaveBLL();

            objEmployeeLeaveDTO.EmployeeId = txtEmployeeId.Text;
            
            objEmployeeLeaveDTO.StartDate = dtpStartDate.Text;
            objEmployeeLeaveDTO.EndDate = dtpEndDate.Text;

            objEmployeeLeaveDTO.UpdateBy = strEmployeeId;
            objEmployeeLeaveDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeLeaveDTO.BranchOfficeId = strBranchOfficeId;

            //string strMsg = objEmployeeLeaveBLL.DeleteEmployeeLeave(objEmployeeLeaveDTO);
            //lblMsg.Text = strMsg;
            //MessageBox(strMsg);
        }

        public void goToNextRecord()
        {
            if (txtSL.Text == string.Empty)
            {
                txtSL.Text = "1";
            }

            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            if (gvEmployeeList.Rows.Count > 0)
            {
                l = gvEmployeeList.SelectedRow.RowIndex;
            }
            else
            {
                l = 0;
            }
            if (l != 0)
            {

                int strId = gvEmployeeList.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex += 1;
                    result = gvEmployeeList.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = gvEmployeeList.Rows.Count;
                int intCountRow = gvEmployeeList.Rows.Count;
                if (intCountRow == 1)
                {
                    intCountRow = 2;

                }

                int p = intCountRow - 1;
                //int p = intCountRow;
                if (l == p)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }

                else
                {
                    l = 1;

                    if (txtSL.Text == "1" && txtSLNew.Text == "")
                    {
                        if (gvEmployeeList.Rows.Count > 0)
                        {
                            gvEmployeeList.SelectedIndex = 0;
                            result = gvEmployeeList.SelectedRow.RowIndex + k;
                            txtSLNew.Text = "1";
                        }
                    }
                    else
                    {

                        int intC = gvEmployeeList.Rows.Count;
                        int intCo = gvEmployeeList.Rows.Count;
                        int ll = 0;

                        int pp = intCo - 1;
                        //int p = intCountRow;
                        if (ll == pp)
                        {
                            string strMsg = "There is no Data for the Next Record!!!";
                            MessageBox(strMsg);

                            return;

                        }
                        else
                        {

                            gvEmployeeList.SelectedIndex += 1;
                            result = gvEmployeeList.SelectedRow.RowIndex + k;

                        }

                    }


                }

            }

            int strRowId = 0;
            string strSLNo = "NO RECORD FOUND";

            if (gvEmployeeList.Rows.Count > 0)
            {
                strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
                strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            }

            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {

                string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

            }
        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
    
            int l;
            l = gvEmployeeList.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = gvEmployeeList.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = gvEmployeeList.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    gvEmployeeList.SelectedIndex -= 1;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = gvEmployeeList.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    return;
                }

                else
                {
                    l = 1;
                    gvEmployeeList.SelectedIndex = l;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;
                }
            }

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;

            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            // }

        }


        public void searchEmployeeRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();


            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.EmployeeName = txtEmpName.Text;
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
            dt = objEmployeeBLL.searchEmployeeRecordForLeave(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;

            }
            //else
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gvEmployeeList.DataSource = dt;
            //    gvEmployeeList.DataBind();
            //    int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
            //    gvEmployeeList.Rows[0].Cells.Clear();
            //    gvEmployeeList.Rows[0].Cells.Add(new TableCell());
            //    gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //    gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

            //    string strMsg = "NO RECORD FOUND!!!";
            //    lblMsgRecord.Text = strMsg;
            //}

        }
        public void GetSuspensionEmployee()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();


            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.UpdateBy = strEmployeeId;

            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.StartDate = dtpStartDate.Text;
            objEmployeeDTO.EndDate = dtpEndDate.Text;


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

            dt = objEmployeeBLL.GetSuspensionEmployee(objEmployeeDTO);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
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
                lblMsgRecord.Text = strMsg;
            }

        }
     
        public void employeeLeaveSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.FromDate = dtpStartDate.Text;
                objReportDTO.ToDate = dtpEndDate.Text;

                objReportDTO.CardNo = txtEmpCardNo.Text;
                objReportDTO.EmployeeId = txtEmpId.Text;

                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {

                    objReportDTO.SectionId = "";
                }

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";

                }


                //bjReportDTO.Year = txtYear.Text;

                objReportDTO.FromDate = dtpFromDate.Text;
                objReportDTO.ToDate = dtpToDate.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeLeave.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.employeeLeaveSheet(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();

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

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            searchEmployeeRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            GetSuspensionEmployee();
            dtpStartDate.Focus();

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
        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }

        #endregion
        #region "Grid View Functionality"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }
        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;

            string strFromDate = GridView1.SelectedRow.Cells[4].Text;
            string strToDate = GridView1.SelectedRow.Cells[5].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[6].Text;
            string remarks = GridView1.SelectedRow.Cells[7].Text;
            string suspensionId = GridView1.SelectedRow.Cells[8].Text;
            string ApprovedBy = GridView1.SelectedRow.Cells[9].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            ddlApprovedById.SelectedValue = ApprovedBy;
            dtpStartDate.Text = strFromDate;
            dtpEndDate.Text = strToDate;
            txtRemarks.Text = remarks;
            txtSuspensionId.Text = suspensionId;
           // searchEmpLeaveEntry();
            dtpStartDate.Focus();
        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            string suspensionId = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["SUSPENSION_ID"]);

            objSalaryDTO.SuspensionId = suspensionId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;
            string MSG = objSalaryBLL.DeleteSuspensionEmployee(objSalaryDTO);
            lblMsg.Text = MSG;

            searchEmployeeRecord();
            GetSuspensionEmployee();
        }
        #endregion
        #region "Grid View Functionality"
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //GridView2.PageIndex = e.NewPageIndex;
        }

        protected void GridView2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void GridView2_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridView2_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }

        protected void GridView2_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView2, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                if (dtpStartDate.Text.Length <= 6 && dtpEndDate.Text.Length <= 6)
                {
                    string strMsg = "Please Check Leave Start or End Date";
                    MessageBox(strMsg);
                    return;
                }
                 if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please Click Select";
                    MessageBox(strMsg);
                    return;
                }
                
                SaveEmployeeSuspension();
                GetSuspensionEmployee();
               
            }
            catch (Exception ex)
            {
                //throw new Exception("Error : "+ ex.Message);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                searchEmployeeRecord();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();
                GetSuspensionEmployee();
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {
                    if (txtEmployeeId.Text == string.Empty)
                    {
                        string strMsg = "Please click in the Gridview!!!";
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        goToNextRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {
                    if (txtEmployeeId.Text == string.Empty)
                    {
                        string strMsg = "Please click in the Gridview!!!";
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        goToPreviousRecord();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    gvEmployeeList.DataSource = null;
                    gvEmployeeList.DataBind();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                    employeeLeaveSheet();
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

        protected void btnSummerySheet_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    gvEmployeeList.DataSource = null;
                    gvEmployeeList.DataBind();
                    GridView1.DataSource = null;
                    GridView1.DataBind();
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
        protected void dtpStartDate_TextChanged(object sender, EventArgs e)
        {
            //if (ddlLeaveTypeId.SelectedValue == "4")
            //{
            //    //DateTime endDate = DateTime.ParseExact(dtpStartDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(55);
            //    string date = endDate.ToString("dd/MM/yyyy");
            //    dtpEndDate.Text = date;
            //}
        }
    }
}