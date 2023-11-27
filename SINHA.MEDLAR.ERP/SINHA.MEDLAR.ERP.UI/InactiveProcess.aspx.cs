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
using CrystalDecisions.Shared;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class InactiveProcess : System.Web.UI.Page
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

                getSectionId();
                getUnitId();
                GetEmployeeStatus();
                //getUnitIdForInactive();
                clearMsg();
                getOfficeName();
                getMonthYearForInactive();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }
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

        public void getMonthYearForInactive()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForInactive();
            txtYear.Text = objLookUpDTO.Year;
            txtMonth.Text = objLookUpDTO.Month;
        }



        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
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
        public void GetEmployeeStatus()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlStatusId.DataSource = objLookUpBLL.GetEmployeeStatus();

            ddlStatusId.DataTextField = "STATUS_NAME";
            ddlStatusId.DataValueField = "STATUS_ID";

            ddlStatusId.DataBind();
            if (ddlStatusId.Items.Count > 0)
            {

                ddlStatusId.SelectedIndex = 0;
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

        public void inactiveProcess()
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

            objEmployeeDTO.Year = txtYear.Text;
            objEmployeeDTO.Month = txtMonth.Text;
            objEmployeeDTO.InactiveReason = txtInactiveReason.Text;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.inactiveProcess(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

       public void Clear()
        {
            dtpResignDate.Text = string.Empty;
            ddlStatusId.SelectedIndex = 0;
            txtInactiveReason.Text = string.Empty;
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


        //public void searchInactiveEmployee()
        //{

        //    EmployeeDTO objEmployeeDTO = new EmployeeDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        //    DataTable dt = new DataTable();
            
        //    objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
        //    objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
        //    objEmployeeDTO.Year = txtYear.Text;
        //    objEmployeeDTO.Month = txtMonth.Text;
            
        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //    {
        //        objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objEmployeeDTO.UnitId = "";
        //    }
            
        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //    {
        //        objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objEmployeeDTO.SectionId = "";
        //    }
            
        //    dt = objEmployeeBLL.searchInactiveEmployee(objEmployeeDTO);
            
        //    if (dt.Rows.Count > 0)
        //    {
        //        GvInactiveEmployee.DataSource = dt;
        //        GvInactiveEmployee.DataBind();

        //        int count = ((DataTable)GvInactiveEmployee.DataSource).Rows.Count;
        //        string strMsg = " TOTAL " + count + " RECORD FOUND";
        //        // MessageBox(strMsg);
        //        lblMsg.Text = strMsg;

        //        // getFirstIndex();
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        GvInactiveEmployee.DataSource = dt;
        //        GvInactiveEmployee.DataBind();
        //        int totalcolums = GvInactiveEmployee.Rows[0].Cells.Count;
        //        GvInactiveEmployee.Rows[0].Cells.Clear();
        //        GvInactiveEmployee.Rows[0].Cells.Add(new TableCell());
        //        GvInactiveEmployee.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        GvInactiveEmployee.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        //MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //    }

        //}

        #endregion 

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtYear.Text == string.Empty)
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return; 


                }
                else if (txtMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtMonth.Focus();
                    return;
                }
                else
                {
                    inactiveProcess();
                    //searchInactiveEmployee();
                    GetEmployeeForInactive();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
              
        protected void ddlOfficeId_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }



        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            //searchInactiveEmployee();
            GetEmployeeForInactive();
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string EmpId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string Unit = gvEmployeeList.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string Section = gvEmployeeList.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            string ResignDate = gvEmployeeList.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string ResignCause = gvEmployeeList.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
   
            ddlUnitId.SelectedValue = Unit;
            ddlSectionId.SelectedValue = Section;
            dtpResignDate.Text = ResignDate;
           // txtResignCause.Text = ResignCause;
           
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


        protected void gvEmployeeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";
            string status = string.Empty;

            string EmployeeId = Convert.ToString(gvEmployeeList.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);

            TextBox txtInactiveYear = (TextBox)gvEmployeeList.Rows[e.RowIndex].FindControl("txtInactiveYear");
            TextBox txtInactiveMonth = (TextBox)gvEmployeeList.Rows[e.RowIndex].FindControl("txtInactiveMonth");
            TextBox txtStatusId = (TextBox)gvEmployeeList.Rows[e.RowIndex].FindControl("txtStatusId");

            string year = txtInactiveYear.Text;
            string month = txtInactiveMonth.Text;
            string id = txtStatusId.Text;

            objEmployeeDTO.EmployeeId = EmployeeId;
            objEmployeeDTO.Year = txtInactiveYear.Text;
            objEmployeeDTO.Month = txtInactiveMonth.Text;
            objEmployeeDTO.StatusId = txtStatusId.Text;

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.CreateBy = strEmployeeId;

            strMsg = objEmployeeBLL.ResetMonthlyInactiveProcess(objEmployeeDTO);
            GetEmployeeForInactive();
            MessageBox(strMsg);

        }




        

        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }
                
        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }





        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //searchInactiveEmployee();
            GetEmployeeForInactive();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string EmpId = GridView1.SelectedRow.Cells[2].Text;
            string Unit = GridView1.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string Section = GridView1.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            string ResignDate = GridView1.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string ResignCause = GridView1.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            ddlUnitId.SelectedValue = Unit;
            ddlSectionId.SelectedValue = Section;
            dtpResignDate.Text = ResignDate;
            // txtResignCause.Text = ResignCause;

        }


        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //searchInactiveEmployee();
                GetEmployeeForInactive();
            }
            catch (Exception ex)
            {
                //throw new Exception("Error : " +ex.Message);
            }
           
        }

        protected void btnInactiveProposal_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                if (txtMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtMonth.Focus();
                    return;
                }
                                
                GetMonthlyInactiveProposalSheet();
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

        public void GetMonthlyInactiveProposalSheet()
        {

            try
            {
                //EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                //EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                DataTable dt = new DataTable();

                objReportDTO.CardNo = txtCardNo.Text;
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
                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;

                
                if (ddlStatusId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.StatusId = ddlStatusId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.StatusId = "";
                }

                //objEmployeeDTO.InactiveReason = txtInactiveReason.Text;

                objReportDTO.CreateBy = strEmployeeId;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptResignEmployeeSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlyInactiveProposalSheet(objReportDTO));

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

   
        public void GetMonthlyInactiveSheet()
        {

            try
            {
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();

                DataTable dt = new DataTable();

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
                objEmployeeDTO.Year = txtYear.Text;
                objEmployeeDTO.Month = txtMonth.Text;


                if (ddlStatusId.SelectedValue.ToString() != " ")
                {
                    objEmployeeDTO.StatusId = ddlStatusId.SelectedValue.ToString();
                }
                else
                {
                    objEmployeeDTO.StatusId = "";
                }

                //objEmployeeDTO.InactiveReason = txtInactiveReason.Text;

                objEmployeeDTO.CreateBy = strEmployeeId;
                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptResignEmployeeSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objEmployeeBLL.GetMonthlyInactiveSheet(objEmployeeDTO));

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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetInactiveEmployee();
            GetEmployeeForInactive();
 
            //searchInactiveEmployee();
        }
        public void GetInactiveEmployee()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            DataTable dt = new DataTable();

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
            objEmployeeDTO.Year = txtYear.Text;
            objEmployeeDTO.CardNo = txtCardNo.Text;
            objEmployeeDTO.Month = txtMonth.Text;
            objEmployeeDTO.InactiveReason = txtInactiveReason.Text;//Inactive Date

            objEmployeeDTO.CreateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            //old:1
            //dt = objEmployeeBLL.GetEmployeeForInActive(objEmployeeDTO);
            //old:2
            //dt = objEmployeeBLL.searchInactiveEmployee(objEmployeeDTO);
            //new
            dt = objEmployeeBLL.GetMonthlyInactiveSheet(objEmployeeDTO);

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
        public void GetEmployeeForInactive()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            DataTable dt = new DataTable();

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
            objEmployeeDTO.Year = txtYear.Text;
            objEmployeeDTO.CardNo = txtCardNo.Text;
            objEmployeeDTO.Month = txtMonth.Text;
            objEmployeeDTO.InactiveReason = txtInactiveReason.Text;

            objEmployeeDTO.CreateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            //old:1
            //dt = objEmployeeBLL.GetEmployeeForInActive(objEmployeeDTO);
            //old:2
            //dt = objEmployeeBLL.searchInactiveEmployee(objEmployeeDTO);
            //new
            dt = objEmployeeBLL.GetEmployeeForInActive(objEmployeeDTO);
            
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlStatusId.SelectedValue== "")
            {
                string strMsg = "Please Select Status";
                MessageBox(strMsg);
                ddlStatusId.Focus();
                return;
            }
            if (ddlStatusId.SelectedValue == "9")
            {
                if (dtpResignDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Resign Date";
                    MessageBox(strMsg);
                    dtpResignDate.Focus();
                    return;
                }
            }
            SaveInactiveEmpAfterMonthlySalary();
            GetEmployeeForInactive();
            Clear();
            //searchInactiveEmployee();

        }
        public string SaveInactiveEmpAfterMonthlySalary()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            try
            {
                string status = string.Empty;

                foreach (GridViewRow row in gvEmployeeList.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");

                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                            if (ddlStatusId.SelectedValue.ToString() != "")
                            {
                                objEmployeeDTO.StatusId = ddlStatusId.SelectedValue.ToString();
                            }
                            else
                            {
                                objEmployeeDTO.StatusId = "";
                            }

                            objEmployeeDTO.Year = txtYear.Text;
                            objEmployeeDTO.Month = txtMonth.Text;
                            objEmployeeDTO.ResignDate = dtpResignDate.Text;
                            objEmployeeDTO.InactiveReason = txtInactiveReason.Text;

                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;
                           

                            strMsg = objEmployeeBLL.SaveInactiveEmpAfterMonthlySalary(objEmployeeDTO);
                            chkEmployee.Checked = false;
                            
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

        public string ProcessMonthlyInactivation()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            try
            {
                string status = string.Empty;

                foreach (GridViewRow row in gvEmployeeList.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");

                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                            if (ddlStatusId.SelectedValue.ToString() != "")
                            {
                                objEmployeeDTO.StatusId = ddlStatusId.SelectedValue.ToString();
                            }
                            else
                            {
                                objEmployeeDTO.StatusId = "";
                            }

                            objEmployeeDTO.Year = txtYear.Text;
                            objEmployeeDTO.Month = txtMonth.Text;
                            objEmployeeDTO.ResignDate = dtpResignDate.Text;
                            objEmployeeDTO.InactiveReason = txtInactiveReason.Text;

                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;


                            strMsg = objEmployeeBLL.ProcessMonthlyInactivation(objEmployeeDTO);
                            chkEmployee.Checked = false;

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

        protected void Inactivate_Click(object sender, EventArgs e)
        {
            
            if (ddlStatusId.SelectedValue == "")
            {
                string strMsg = "Please Select Status";
                MessageBox(strMsg);
                ddlStatusId.Focus();
                return;
            }
            if (dtpResignDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Inactive Date";
                MessageBox(strMsg);
                dtpResignDate.Focus();
                return;
            }
            //if (ddlStatusId.SelectedValue == "9")
            //{
            //    if (dtpResignDate.Text == string.Empty)
            //    {
            //        string strMsg = "Please Enter Resign Date";
            //        MessageBox(strMsg);
            //        dtpResignDate.Focus();
            //        return;
            //    }
            //}

            ProcessMonthlyInactivation();
            Clear();
            GetEmployeeForInactive();
            GetInactiveEmployee();
            //searchInactiveEmployee();
        }

        protected void btnInactiveSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                if (txtMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtMonth.Focus();
                    return;
                }

                GetMonthlyInactiveSheet();
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