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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ResignQueue : System.Web.UI.Page
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
                getUnitIdForEmployee();
                getSectionIdForEmployee();
                getOfficeName();
                lblMsg.Text = string.Empty;
                
            }
            if (IsPostBack)
            {
                loadSesscion();
                Session["strID"] = null;
            }
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

        
        public void getUnitIdForEmployee()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmpUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlEmpUnitId.DataTextField = "UNIT_NAME";
            ddlEmpUnitId.DataValueField = "UNIT_ID";

            ddlEmpUnitId.DataBind();
            if (ddlEmpUnitId.Items.Count > 0)
            {
                ddlEmpUnitId.SelectedIndex = 0;
            }
        }
        public void getSectionIdForEmployee()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();

            ddlEmpSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlEmpSectionId.DataTextField = "SECTION_NAME";
            ddlEmpSectionId.DataValueField = "SECTION_ID";

            ddlEmpSectionId.DataBind();
            if (ddlEmpSectionId.Items.Count > 0)
            {
                ddlEmpSectionId.SelectedIndex = 0;
            }
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
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeId.Text = Session["strID"].ToString().Trim();
            //searchEmployeeInfo();

        }
        #endregion
        #region "DML"

        public void SaveResignEmployee()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.ResignDate = dtpResignDate.Text;
            objEmployeeDTO.ResignCasuse = txtResignCause.Text;
            objEmployeeDTO.CreateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;                      
                       
            string strMsg = objEmployeeBLL.SaveResignEmployee(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        
        public void clear()
        {
            lblMsg.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignation.Text = string.Empty;
            dtpResignDate.Text = string.Empty;
            txtResignCause.Text = string.Empty;
               
        }

        public void loadCombo()
        {                             
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetEmployeeForResign();
                GetResignEmployee();
            }
            catch (Exception ex)
            {
              //  throw new Exception("Error : " + ex.Message);
            }
        }

        public void GetEmployeeForResign()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

           
            if (ddlEmpUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlEmpUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }

            if (ddlEmpSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlEmpSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }

            objEmployeeDTO.FromDate = dtpResignDate.Text;
            objEmployeeDTO.ToDate = dtpResignDate.Text;

            //dt = objEmployeeBLL.searchEmployeeInformation(objEmployeeDTO);
            dt = objEmployeeBLL.GetEmployeeForResign(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GvResignQueue.DataSource = dt;
                GvResignQueue.DataBind();

                int count = ((DataTable)GvResignQueue.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvResignQueue.DataSource = dt;
                GvResignQueue.DataBind();
                int totalcolums = GvResignQueue.Rows[0].Cells.Count;
                GvResignQueue.Rows[0].Cells.Clear();
                GvResignQueue.Rows[0].Cells.Add(new TableCell());
                GvResignQueue.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GvResignQueue.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }
        public void GetResignEmployee()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;


            if (ddlEmpUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlEmpUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }

            if (ddlEmpSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlEmpSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";

            }

            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpTodate.Text;

            dt = objEmployeeBLL.GetResignEmployee(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
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
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                {
                    if (txtEmployeeId.Text == "")
                    {
                        string strMsg = "Please Select Employee In Gridview";
                        MessageBox(strMsg);
                        txtEmployeeId.Focus();
                        return;
                    }                  
                    if (dtpResignDate.Text == "")
                    {
                        string strMsg = "Please Enter Resign Date";
                        MessageBox(strMsg);
                        dtpResignDate.Focus();
                        return;
                    }
                    SaveResignEmployee();
                    GetResignEmployee();
                    clear();


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
            loadCombo();
            Session["strID"] = null;
            //txtFirstSalary.ReadOnly = false;

        }

        #region "Grid View Functionality"
        protected void GvResignQueue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvResignQueue.PageIndex = e.NewPageIndex;
        }

        protected void GvResignQueue_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            int strRowId = GvResignQueue.SelectedRow.RowIndex + 1;
            string strSLNo = GvResignQueue.SelectedRow.Cells[0].Text;
            string CardNo = GvResignQueue.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string EmpId = GvResignQueue.SelectedRow.Cells[2].Text; 
            string EmpName = GvResignQueue.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string Designation = GvResignQueue.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            txtCardNo.Text = CardNo;
            txtEmployeeId.Text = EmpId;
            txtEmployeeName.Text = EmpName;
            txtDesignation.Text = Designation;

        }
        protected void GvResignQueue_RowDataBound(GridViewRowEventArgs e)
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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvResignQueue, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GvResignQueue_Sorting(object sender, GridViewSortEventArgs e)
        {           
        }

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }
        protected void GvResignQueue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GvEmployeeCache.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }
        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string CardNo = GridView1.SelectedRow.Cells[1].Text;
            string EmpId = GridView1.SelectedRow.Cells[2].Text;
            string EmpName = GridView1.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string Designation = GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string ResignDate = GridView1.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string ResignCause = GridView1.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            txtCardNo.Text  = CardNo;
            txtEmployeeId.Text = EmpId;
            txtEmployeeName.Text = EmpName;
            txtDesignation.Text = Designation;
            dtpResignDate.Text = ResignDate;
            txtResignCause.Text = ResignCause;

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

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvResignQueue, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        //private string GridViewSortDirection
        //{
        //    get { return ViewState["SortDirection"] as string ?? "DESC"; }
        //    set { ViewState["SortDirection"] = value; }
        //}
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GvEmployeeCache.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            string EmployeeId = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);

            objEmployeeDTO.EmployeeId = EmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.CreateBy = strEmployeeId;
            string MSG = objEmployeeBLL.DeleteFromResign(objEmployeeDTO);
            GetResignEmployee();
            MessageBox(MSG);
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
                //ReportDTO objReportDTO = new ReportDTO();
                //ReportBLL objReportBLL = new ReportBLL();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                objEmployeeDTO.EmployeeId = txtEmpId.Text;
                objEmployeeDTO.CardNo = txtEmpCardNo.Text;


                if (ddlEmpUnitId.SelectedValue.ToString() != " ")
                {
                    objEmployeeDTO.UnitId = ddlEmpUnitId.SelectedValue.ToString();
                }
                else
                {
                    objEmployeeDTO.UnitId = "";
                }

                if (ddlEmpSectionId.SelectedValue.ToString() != " ")
                {
                    objEmployeeDTO.SectionId = ddlEmpSectionId.SelectedValue.ToString();
                }
                else
                {
                    objEmployeeDTO.SectionId = "";

                }

                objEmployeeDTO.FromDate = dtpFromDate.Text;
                objEmployeeDTO.ToDate = dtpTodate.Text;
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
    }
}