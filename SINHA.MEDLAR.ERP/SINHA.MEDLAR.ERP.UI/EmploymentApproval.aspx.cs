using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class EmploymentApproval : System.Web.UI.Page
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
                getUnitId();
                getSectionId();
                getOfficeName();
                LoadEmployeeCache();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

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
        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPDF.Checked == true)
            {
                chkExcel.Checked = false;
            }
            else
            {
                chkPDF.Checked = true;
            }
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
        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkPDF.Checked = false;
            }
            else
            {
                chkExcel.Checked = true;
            }
        }
        public void Clear()
        {
           
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
         
        #region "Grid View GridViewCaseInfo"
        protected void GvEmployeeCache_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmployeeCache.PageIndex = e.NewPageIndex;
        }
        protected void GvEmployeeCache_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
            ////string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;
            //string CaseNo = GvEmployeeCache.SelectedRow.Cells[0].Text;
            //string IssueDate = GvEmployeeCache.SelectedRow.Cells[4].Text;
            //string CaseMode = GvEmployeeCache.SelectedRow.Cells[6].Text;
            //string Amount = GvEmployeeCache.SelectedRow.Cells[7].Text;
                                   
            //if (CaseTypeId == "&nbsp;")
        }
        protected void GvEmployeeCache_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void GvEmployeeCache_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GvEmployeeCache_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
                        
            // Retrieve the row that contains the button clicked 
            // by the user from the Rows collection.      
            GridViewRow row = GvEmployeeCache.Rows[index];

            string cacheId = Convert.ToString(GvEmployeeCache.DataKeys[row.RowIndex].Values["cache_id"]);
            string employeeId = row.Cells[5].Text.Replace("&nbsp;", "");
                        
            if (e.CommandName == "Select")
            {
                //int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
                //string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;             
            }
            if (e.CommandName == "Edit")
            {
            }
            if (e.CommandName == "Delete")
            {
                EmployeeBLL objEmployee = new EmployeeBLL();
                string result = objEmployee.DeleteUnpaidEmployeePermanently(cacheId, employeeId, strEmployeeId);
                LoadEmployeeCache();
                MessageBox(result);
            }
            if (e.CommandName == "Approve")
            {                
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                objEmployeeDTO = objEmployeeBLL.GetEmployeeCacheByCacheId(cacheId);
                if (objEmployeeDTO.ApproveYn == "Y")
                {
                    MessageBox("Already Approved");
                }
                else
                {
                    ApproveEmployment(cacheId);
                    LoadEmployeeCache();
                }
            }

            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }

        public void ApproveEmployment(string cacheId)
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();    
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.ApproveEmployment(cacheId, strHeadOfficeId, strBranchOfficeId, strEmployeeId);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        protected void GvEmployeeCache_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GvEmployeeCache_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvEmployeeCache, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GvEmployeeCache_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string cacheId = Convert.ToString(GvEmployeeCache.DataKeys[e.RowIndex].Values["cache_id"]); 

            //try
            //{
            //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            //    string employeeId = Convert.ToString(GridViewCaseInfo.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);
            //    string msg = objEmployeeBLL.RemoveCase(employeeId);
            //    MessageBox(msg);
            //    LoadCaseInfoGrid();
            //}
            //catch
            //{
            //    MessageBox("Unable To Remove Case");
            //}                      
        }
        
        #endregion
        #region Case                     
        public void LoadEmployeeCache()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            if (IsPostBack)
            {

                if (ddlUnitId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitId = "";
                }
                if (ddlSectionId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.SectionId = "";
                }

                objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                objReportDTO.FromCreateDate = txtFromDate.Text;
                objReportDTO.ToCreateDate = txtToDate.Text;
                objReportDTO.ApproveYn = ddlApproved.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitId = "";
                objReportDTO.SectionId = "";
                objReportDTO.EmployeeId = "";
                objReportDTO.CardNo = "";
                objReportDTO.FromDate = "";
                objReportDTO.ToDate = "";
                objReportDTO.ApproveYn = "N";
            }

            objReportDTO.Delete_Yn = "N";
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;

            DataTable dt = objReportBLL.GetEmployeeCache(objReportDTO);

            if (dt.Rows.Count > 0)
            {
                GvEmployeeCache.DataSource = dt;
                GvEmployeeCache.DataBind();

                int count = ((DataTable)GvEmployeeCache.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvEmployeeCache.DataSource = dt;
                GvEmployeeCache.DataBind();
                int totalcolums = GvEmployeeCache.Rows[0].Cells.Count;
                GvEmployeeCache.Rows[0].Cells.Clear();
                GvEmployeeCache.Rows[0].Cells.Add(new TableCell());
                GvEmployeeCache.Rows[0].Cells[0].ColumnSpan = totalcolums;
            }
        }
        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadEmployeeCache();
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {

            try
            {
                if (ddlApproved.SelectedValue == string.Empty)
                {
                    string msg = "Please Select Approved";
                    MessageBox(msg);
                    ddlApproved.Focus();
                    return;
                }
                GetEmploymentApprovalSheet();

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
        public void GetEmploymentApprovalSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.CardNo = txtCardNo.Text;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();
                objReportDTO.ApproveYn = ddlApproved.SelectedValue.ToString();
                objReportDTO.Delete_Yn = "N";
                objReportDTO.FromCreateDate = txtFromDate.Text;
                objReportDTO.ToCreateDate = txtToDate.Text;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;



                if (objReportDTO.ApproveYn == "Y") //Approved
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmploymentApprovalSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetEmploymentApprovalSheet(objReportDTO));
                }
                if (objReportDTO.ApproveYn == "N") //Not Approved
                {
                    string strPath = string.Empty;
                    {
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptEmploymentApprovalSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetEmploymentNotApprovalSheet(objReportDTO));
                    }
                }

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