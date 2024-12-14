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
    public partial class CaseIssue : System.Web.UI.Page
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
                //clearMsg();
                getOfficeName();

                btnSearch.Focus();


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

                //CrystalReportViewer1.ReportSource = rd;
                //CrystalReportViewer1.DataBind();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ddlUnitId.SelectedValue.ToString() == " ")
                //{
                //    MessageBox("Please Select Unit");
                //    return;
                //}
                
                //if (ddlSectionId.SelectedValue.ToString() == " ")
                //{
                //    MessageBox("Please Select Section");
                //    return;
                //}
               
                searchEmployeeList();
                LoadCaseInfoGrid();
            }
            catch (Exception ex)
            {
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
        public void searchEmployeeList()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            
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

            objEmployeeDTO.FromCreateDate = "";
            objEmployeeDTO.ToCreateDate = "";


            dt = objEmployeeBLL.searchActiveEmployeeList(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
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
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
            }
        }

        #region "Grid View GridViewCaseInfo"
        protected void GridViewCaseInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCaseInfo.PageIndex = e.NewPageIndex;

        }
        protected void GridViewCaseInfo_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            //string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            //string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //string strDesignation = GridView1.SelectedRow.Cells[3].Text;

        }
        protected void GridViewCaseInfo_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void GridViewCaseInfo_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GridViewCaseInfo_RowCommand(object sender, GridViewCommandEventArgs e)
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
        protected void GridViewCaseInfo_Sorting(object sender, GridViewSortEventArgs e)
        {
        }
        protected void GridViewCaseInfo_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridViewCaseInfo, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridViewCaseInfo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                string employeeId = Convert.ToString(GridViewCaseInfo.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);
                string msg = objEmployeeBLL.RemoveCase(employeeId);
                MessageBox(msg);
                LoadCaseInfoGrid();
            }
            catch
            {
                MessageBox("Unable To Remove Case");
            }                      
        }


        #endregion

        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
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

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
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
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

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

        #endregion

        #region Case         
        protected void BtnIssueCase_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitId.SelectedValue.ToString() == " ")
                {
                    MessageBox("Please Select Unit");
                    return;
                }

                if (ddlSectionId.SelectedValue.ToString() == " ")
                {
                    MessageBox("Please Select Unit");
                    return;
                }
                SaveCase();
                searchEmployeeList();
                LoadCaseInfoGrid();
            }
            catch
            {

            }
        }
        public void SaveCase()
        {
            int count = 0;
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                        TextBox txtCardNo = (TextBox)row.FindControl("txtCardNo");
                        CheckBox chkIsIssued = (CheckBox)row.FindControl("chkIsIssued");

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

                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        //objEmployeeDTO.IssueDate = dtpIssueDate.Text;

                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                        string strMsg = objEmployeeBLL.SaveCase(objEmployeeDTO);
                        //MessageBox(strMsg);
                        //lblMsg.Text = strMsg;
                        count = count + 1;
                    }
                }
            }

            MessageBox(count.ToString() + " Record(s) Added.");
        }
        protected void btnCaseSheet_Click(object sender, EventArgs e)
        {
            try
            {
                GetCaseSheet();
            }
            catch
            {

            }
        }
        public void LoadCaseInfoGrid()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.UpdateBy = strEmployeeId;
            objReportDTO.EmployeeTypeId = null;
            objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
            objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;

            DataTable dt = objReportBLL.GetCaseSheet(objReportDTO);


            if (dt.Rows.Count > 0)
            {
                GridViewCaseInfo.DataSource = dt;
                GridViewCaseInfo.DataBind();

                int count = ((DataTable)GridViewCaseInfo.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridViewCaseInfo.DataSource = dt;
                GridViewCaseInfo.DataBind();
                int totalcolums = GridViewCaseInfo.Rows[0].Cells.Count;
                GridViewCaseInfo.Rows[0].Cells.Clear();
                GridViewCaseInfo.Rows[0].Cells.Add(new TableCell());
                GridViewCaseInfo.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridViewCaseInfo.Rows[0].Cells[0].Text = "NO RECORD FOUND";
            }
        }
        public void GetCaseSheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.EmployeeTypeId = null;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmployeeCaseSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetCaseSheet(objReportDTO));

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

        public void GetCaseNotice()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.EmployeeTypeId = null;
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmployeeCaseNotice.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetCaseNotice(objReportDTO));

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
        public void RearrangeDisplayOrder()
        {
            int count = 0;

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            foreach (GridViewRow row in GridViewCaseInfo.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                    TextBox txtDisplayOrder = (TextBox)row.FindControl("txtDisplayOrder");

                    objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                    objEmployeeDTO.DisplayOrder = txtDisplayOrder.Text;

                    objEmployeeDTO.UpdateBy = strEmployeeId;
                    objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                    objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                    string strMsg = objEmployeeBLL.ReorderCase(objEmployeeDTO);
                    count = count + 1;
                }
            }
            MessageBox(count.ToString() + " Record(s) Re-Ordered.");
            LoadCaseInfoGrid();
        }
        public void DeleteEnvelope()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

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
            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objEmployeeBLL.DeleteEnvelope(objEmployeeDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;



        }
        public void SaveEnvelope()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                        TextBox txtCardNo = (TextBox)row.FindControl("txtCardNo");

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
                        objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                        string strMsg = objEmployeeBLL.SaveEnvelope(objEmployeeDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;
                    }
                }
            }
        }
        public void GetEnvelope()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.EmployeeTypeId = null;
                objReportDTO.AddressTypeId = Convert.ToInt32(ddlAddressTypeId.SelectedValue.ToString());
                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEnvelope.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetCaseEnvelope(objReportDTO));

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


        protected void BtnReorderCase_Click(object sender, EventArgs e)
        {
            try
            {
                RearrangeDisplayOrder();
            }
            catch
            {
            }
        }
        protected void BtnSearchCaseOnly_Click(object sender, EventArgs e)
        {
            try
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                LoadCaseInfoGrid();
            }
            catch
            {

            }
        }
        #endregion

        protected void BtnCaseNotice_Click(object sender, EventArgs e)
        {
            try
            {
                GetCaseNotice();
            }
            catch
            {
            }
        }

        protected void BtnEnvelope_Click(object sender, EventArgs e)
        {
            try
            {
                if(ddlAddressTypeId.SelectedValue.ToString() == string.Empty)
                {
                    MessageBox("Please Select To Address Type");
                    return;
                }
                DeleteEnvelope();
                SaveEnvelope();
                GetEnvelope();
            }
            catch
            {
            }
        }
    }
}