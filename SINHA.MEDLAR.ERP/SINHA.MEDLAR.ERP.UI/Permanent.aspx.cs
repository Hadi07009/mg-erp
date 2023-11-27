﻿using System;
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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class Permanent : System.Web.UI.Page
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
               // getUnitIdFrom();
               // getSectionIdFrom();
                getUnitIdTo();
                getSectionIdTo();
                clearMsg();
               // LoadWorkerPromotionRecord();
                getOfficeName();
                getDesignationId();
                getGradeNo();
                getMonthId();
                //getDesignationIdFrom();
                //getGradeNoFrom();
                getMonthYearForTax();
               // btnSearch.Focus();


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
        }
        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
            lblTransferMsg.Text = string.Empty;
        }
        public void getMonthYearForTax()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            objLookUpDTO = objLookUpBLL.getMonthYearForTax();
            txtPermanentYear.Text = objLookUpDTO.Year;
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
        public void getMonthId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMonthId.DataSource = objLookUpBLL.getMonthId();

            ddlMonthId.DataTextField = "MONTH_NAME";
            ddlMonthId.DataValueField = "MONTH_ID";
            ddlMonthId.DataBind();
            if (ddlMonthId.Items.Count > 0)
            {
                ddlMonthId.SelectedIndex = 0;
            }

        }
        //public void getUnitIdFrom()
        //{


        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlUnitIdFrom.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

        //    ddlUnitIdFrom.DataTextField = "UNIT_NAME";
        //    ddlUnitIdFrom.DataValueField = "UNIT_ID";

        //    ddlUnitIdFrom.DataBind();
        //    if (ddlUnitIdFrom.Items.Count > 0)
        //    {

        //        ddlUnitIdFrom.SelectedIndex = 0;
        //    }

        //}
        public void getUnitIdTo()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitIdTo.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitIdTo.DataTextField = "UNIT_NAME";
            ddlUnitIdTo.DataValueField = "UNIT_ID";
            ddlUnitIdTo.DataBind();
            if (ddlUnitIdTo.Items.Count > 0)
            {
                ddlUnitIdTo.SelectedIndex = 0;
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
        //public void getSectionIdFrom()
        //{


        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlSectionIdFrom.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

        //    ddlSectionIdFrom.DataTextField = "SECTION_NAME";
        //    ddlSectionIdFrom.DataValueField = "SECTION_ID";

        //    ddlSectionIdFrom.DataBind();
        //    if (ddlSectionIdFrom.Items.Count > 0)
        //    {

        //        ddlSectionIdFrom.SelectedIndex = 0;
        //    }


        //}
        public void getSectionIdTo()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionIdTo.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionIdTo.DataTextField = "SECTION_NAME";
            ddlSectionIdTo.DataValueField = "SECTION_ID";

            ddlSectionIdTo.DataBind();
            if (ddlSectionIdTo.Items.Count > 0)
            {
                ddlSectionIdTo.SelectedIndex = 0;
            }
        }
        public void getDesignationId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDesignationIdTo.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId, strBranchOfficeId);

            ddlDesignationIdTo.DataTextField = "DESIGNATION_NAME";
            ddlDesignationIdTo.DataValueField = "DESIGNATION_ID";
            ddlDesignationIdTo.DataBind();
            if (ddlDesignationIdTo.Items.Count > 0)
            {
                ddlDesignationIdTo.SelectedIndex = 0;
            }
        }
        public void getGradeNo()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGradeNoTo.DataSource = objLookUpBLL.getGradeId(strHeadOfficeId, strBranchOfficeId);

            ddlGradeNoTo.DataTextField = "GRADE_NO";
            ddlGradeNoTo.DataValueField = "GRADE_ID";

            ddlGradeNoTo.DataBind();
            if (ddlGradeNoTo.Items.Count > 0)
            {
                ddlGradeNoTo.SelectedIndex = 0;
            }
        }
        //public void getGradeNoFrom()
        //{
        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlGradeIdFrom.DataSource = objLookUpBLL.getGradeId(strHeadOfficeId, strBranchOfficeId);

        //    ddlGradeIdFrom.DataTextField = "GRADE_NO";
        //    ddlGradeIdFrom.DataValueField = "GRADE_ID";

        //    ddlGradeIdFrom.DataBind();
        //    if (ddlGradeIdFrom.Items.Count > 0)
        //    {
        //        ddlGradeIdFrom.SelectedIndex = 0;
        //    }

        //}
        //public void getDesignationIdFrom()
        //{
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    ddlDesignationIdFrom.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId, strBranchOfficeId);

        //    ddlDesignationIdFrom.DataTextField = "DESIGNATION_NAME";
        //    ddlDesignationIdFrom.DataValueField = "DESIGNATION_ID";
        //    ddlDesignationIdFrom.DataBind();
        //    if (ddlDesignationIdFrom.Items.Count > 0)
        //    {
        //        ddlDesignationIdFrom.SelectedIndex = 0;
        //    }
        //}
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

        public void GetPermanentQueue()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtCardNo.Text;
            objEmployeeDTO.Year = txtPermanentYear.Text;
            objEmployeeDTO.Month = ddlMonthId.SelectedItem.Value;

            //if (ddlUnitId.SelectedValue.ToString() != " ")
            //{
            //    objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objEmployeeDTO.UnitId = "";
            //}
            //if (ddlSectionId.SelectedValue.ToString() != " ")
            //{
            //    objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objEmployeeDTO.SectionId = "";
            //}
            dt = objEmployeeBLL.GetPermanentQueue(objEmployeeDTO);
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
    
        public void SavePermanentInfo()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            //LookupBLL objSalaryBLL = new SalaryBLL();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            string strMsg = "";

            EmployeeDTO EmployeeDTO = objLookUpBLL.GetEmployeeDetail(txtEmpId.Text);

            objSalaryDTO.EmployeeId = txtEmpId.Text;
            objSalaryDTO.OccurrenceTypeId = 7;

            objSalaryDTO.UnitIdFrom = EmployeeDTO.UnitId;
            objSalaryDTO.UnitIdTo = ddlUnitIdTo.SelectedItem.Value == " " ? "" : ddlUnitIdTo.SelectedItem.Value;

            objSalaryDTO.SectionIdFrom = EmployeeDTO.SectionId;
            objSalaryDTO.SectionIdTo = ddlSectionIdTo.SelectedItem.Value == " " ? "" : ddlSectionIdTo.SelectedItem.Value;

            objSalaryDTO.DesignationIdFrom = EmployeeDTO.DesignationId;
            objSalaryDTO.DesignationIdTo = ddlDesignationIdTo.SelectedItem.Value == " " ? "" : ddlDesignationIdTo.SelectedItem.Value;

            objSalaryDTO.GradeIdFrom = EmployeeDTO.GradeId;
            objSalaryDTO.GradeIdTo = ddlGradeNoTo.SelectedItem.Value == " " ? "" : ddlGradeNoTo.SelectedItem.Value;
            objSalaryDTO.GrossSalaryFrom = txtGrossSalaryFrom.Text;
            objSalaryDTO.GrossSalaryTo = txtGrossSalaryTo.Text;
            objSalaryDTO.FirstSalaryFrom = txtFirstSalaryFrom.Text;
            objSalaryDTO.FirstSalaryTo = txtFirstSalaryTo.Text;
            objSalaryDTO.Year = txtPermanentYear.Text;
            objSalaryDTO.EffectiveDate = dtpEffectDate.Text;
            objSalaryDTO.Month = ddlMonthId.SelectedItem.Value == " " ? "" : ddlMonthId.SelectedItem.Value;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            strMsg = objSalaryBLL.SavePermanentInfo(objSalaryDTO);

            lblMsg.Text = strMsg;
            if (strMsg == "PLEASE SELECT GRADE!!!")
            {
                MessageBox(strMsg);
                return;
            }
            MessageBox(strMsg);
        }
        public void employeeRecordForYearlyPromotion()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();


            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtCardNo.Text;
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
            dt = objEmployeeBLL.employeeRecordForYearlyPromotion(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
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
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }
        }
        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {           
            try
            {
                if (ddlUnitId.Text == " ")
                {
                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }
                else if (ddlSectionId.Text == " ")
                {
                    string strMsg = "Please Select Section Name!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }
                else
                {
                    searchEmployeeRecordforMiscEntry();
                    clearYellowTextBox();
                    clearTextBox();
                    gvEmployeeList.SelectedIndex = 0;

                    GetPermanentQueue();

                    // goToNextRecord();
                    //searchMiscEntryWorker();
                    // searchMonthLoanEntryWorker();
                    //searchSalaryInfoWorker();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            { 
                if (txtPermanentYear.Text == "")
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtPermanentYear.Focus();
                    return;
                }
                else
                {
                    GetPermanentQueue();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;     
        }
        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[9].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string Designation = gvEmployeeList.SelectedRow.Cells[3].Text;
            string GradeNo = gvEmployeeList.SelectedRow.Cells[6].Text;
            string Unit = gvEmployeeList.SelectedRow.Cells[4].Text;
            string Section = gvEmployeeList.SelectedRow.Cells[5].Text;
            string FirstSalary = gvEmployeeList.SelectedRow.Cells[7].Text;
            string GrossSalary = gvEmployeeList.SelectedRow.Cells[8].Text;
                        
            txtCardNo.Text = strCardNo;
            txtEmpId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = Designation;
            txtGradeNo.Text = GradeNo;
            txtUnitName.Text = Unit;
            txtSectionName.Text = Section;
            txtFirstSalaryFrom.Text = FirstSalary;
            txtGrossSalaryFrom.Text = GrossSalary;
            
        }
        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {          
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
        protected void gvEmployeeList_Sorting(object sender, GridViewSortEventArgs e)
        {
        }

        #endregion
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[7].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            string strEffectiveDate = GridView1.SelectedRow.Cells[6].Text;


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

        protected void btnSalaryProcess_Click(object sender, EventArgs e)
        {   
            if (ddlDesignationIdTo.SelectedItem.Value == " ")
            {
                string strMsg = "Please Select Designation!!!";
                MessageBox(strMsg);
                ddlDesignationIdTo.Focus();
                return;
            }
            if (ddlGradeNoTo.SelectedItem.Value == " ")
            {
                string strMsg = "Please Select Grade!!!";
                MessageBox(strMsg);
                ddlGradeNoTo.Focus();
                return;
            }
            if (ddlUnitIdTo.SelectedItem.Value == " ")
            {
                string strMsg = "Please Select To Unit!!!";
                MessageBox(strMsg);
                ddlUnitIdTo.Focus();
                return;
            }
            if (ddlSectionIdTo.SelectedItem.Value == " ")
            {
                string strMsg = "Please Select To Unit!!!";
                MessageBox(strMsg);
                ddlSectionIdTo.Focus();
                return;
            }
            if (txtGrossSalaryTo.Text == "")
            {
                string strMsg = "Please Enter Gross Salary!!!";
                MessageBox(strMsg);
                txtGrossSalaryTo.Focus();
                return;
            }
            if (txtPermanentYear.Text == " ")
            {
                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtPermanentYear.Focus();
                return;
            }
            if (ddlMonthId.SelectedItem.Value == " ")
            {
                string strMsg = "Please Select Month!!!";
                MessageBox(strMsg);
                ddlMonthId.Focus();
                return;
            }
            if (dtpEffectDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Effective Date!!!";
                MessageBox(strMsg);
                dtpEffectDate.Focus();
                return;
            }
            {
                SavePermanentInfo();
                GetPermanentQueue();
            }
        }
        public void searchEmployeeRecordforMiscEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtCardNo.Text;
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
            dt = objEmployeeBLL.searchEmployeeRecordforMiscEntryWorker(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
                // getFirstIndex();
                //addWorkerSalary();
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
                lblMsg.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }
        }
        public void searchSalaryInfoWorker()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtCardNo.Text;
           // objEmployeeDTO.Year = txtSalaryYear.Text;
           // objEmployeeDTO.Month = txtsalaryMonth.Text;


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
            dt = objEmployeeBLL.searchSalaryInfoWorker(objEmployeeDTO);

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

        public void GetPermanentEmployee()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.CreateBy = strEmployeeId;

                objReportDTO.Date = dtpDate.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmployeePermanentSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetPermanentEmployee(objReportDTO));

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

        public void workerYearlyPromotionSheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
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
                objReportDTO.Year = txtPermanentYear.Text;
              
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptYearlyWorkerPromotionSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.workerYearlyPromotionSheet(objReportDTO));

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

        protected void btnTransferSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPermanentYear.Text == " ")
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtPermanentYear.Focus();
                    return;
                }             
                else
                {
                    workerYearlyPromotionSheet();
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

        protected void btnProcessPromotion_Click(object sender, EventArgs e)
        {
            try
            {
                //if (ddlUnitId.SelectedItem.Value == " ")
                //{
                //    string strMsg = "Please Select Unit";
                //    MessageBox(strMsg);
                //    ddlUnitId.Focus();
                //    return;
                //}
                //if (ddlSectionId.SelectedItem.Value == " ")
                //{
                //    string strMsg = "Please Select Section";
                //    MessageBox(strMsg);
                //    ddlSectionId.Focus();
                //    return;
                //}
                if (txtPermanentYear.Text == "")
                {
                    string strMsg = "Please Enter Permanent Year";
                    MessageBox(strMsg);
                    txtPermanentYear.Focus();
                    return;
                }
                if (ddlMonthId.SelectedItem.Value == " ")
                {
                    string strMsg = "Please Select Month";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }
                if (dtpEffectDate.Text == "")
                {
                    string strMsg = "Please Enter Effect Date";
                    MessageBox(strMsg);
                    dtpEffectDate.Focus();
                    return;
                }
                ProcessPermanenetQueue();  
            }
            catch (Exception ex)
            {
            }
        }
        private void ProcessPermanenetQueue()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            

            objSalaryDTO.Year = txtPermanentYear.Text;
            objSalaryDTO.Month = ddlMonthId.SelectedItem.Value;
            objSalaryDTO.EffectiveDate = dtpEffectDate.Text;
            //if (ddlUnitId.SelectedValue.ToString() != " ")
            //{
            //    objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objSalaryDTO.UnitId = "";
            //}
            //if (ddlSectionId.SelectedValue.ToString() != " ")
            //{
            //    objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objSalaryDTO.SectionId = "";
            //}
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;
            string strMsg = objSalaryBLL.ProcessPermanentQueue(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }

        protected void btnPermanentSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpDate.Text == " ")
                {
                    string strMsg = "Please Enter Date";
                    MessageBox(strMsg);
                    dtpDate.Focus();
                    return;
                }
                else
                {
                    GetPermanentEmployee();
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
    }
}