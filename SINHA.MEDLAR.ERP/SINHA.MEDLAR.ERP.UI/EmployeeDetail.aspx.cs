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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeDetail : System.Web.UI.Page
    {
        protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1 = new CrystalDecisions.Web.CrystalReportViewer();
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
                //loadEmployeeRecord();
                getUnitId();
                getSectionId();
                getBloodGroupIdForSearch();
                getGradeId();
                //getEmployeeId();
                getEmployeeTypeId();
                clearMsg();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }

        #region 

        public void getBloodGroupIdForSearch()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBloodGroupIdForSearch.DataSource = objLookUpBLL.getBloodGroupId(strHeadOfficeId, strBranchOfficeId);

            ddlBloodGroupIdForSearch.DataTextField = "BLOOD_GROUP_NAME";
            ddlBloodGroupIdForSearch.DataValueField = "BLOOD_GROUP_ID";

            ddlBloodGroupIdForSearch.DataBind();
            if (ddlBloodGroupIdForSearch.Items.Count > 0)
            {

                ddlBloodGroupIdForSearch.SelectedIndex = 0;
            }

        }

        public void getGradeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlGradeId.DataSource = objLookUpBLL.getGradeId(strHeadOfficeId, strBranchOfficeId);

            ddlGradeId.DataTextField = "GRADE_NO";
            ddlGradeId.DataValueField = "GRADE_ID";

            ddlGradeId.DataBind();
            if (ddlGradeId.Items.Count > 0)
            {

                ddlGradeId.SelectedIndex = 0;
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

        public void clearMsg()
        {
            lblMsg.Text = string.Empty;

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


        public void getEmployeeTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeTypeId.DataSource = objLookUpBLL.getEmployeeTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlEmployeeTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
            ddlEmployeeTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

            ddlEmployeeTypeId.DataBind();
            if (ddlEmployeeTypeId.Items.Count > 0)
            {

                ddlEmployeeTypeId.SelectedIndex = 0;
            }

        }


        //public void getEmployeeId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlEmployeeId.DataSource = objLookUpBLL.getEmployeeSearch(strHeadOfficeId, strBranchOfficeId);

        //    ddlEmployeeId.DataTextField = "EMPLOYEE_NAME";
        //    ddlEmployeeId.DataValueField = "EMPLOYEE_ID";

        //    ddlEmployeeId.DataBind();
        //    if (ddlEmployeeId.Items.Count > 0)
        //    {

        //        ddlEmployeeId.SelectedIndex = 0;
        //    }

        //}

        public void searchEmployeeRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            string strActiveYn = "";
            if (chkActiveYn.Checked== true)
            {
                objEmployeeDTO.EmployeeActiveYn = "N";
            }
            else
            {
                objEmployeeDTO.EmployeeActiveYn = "Y";

            }
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

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

            if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.EmployeeTypeId = "";

            }

            if (ddlBloodGroupIdForSearch.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.BloodGroupId = ddlBloodGroupIdForSearch.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.BloodGroupId = "";

            }

            if (ddlGradeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.GradeNo = ddlGradeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.GradeNo = "";

            }


            objEmployeeDTO.PunchCode = txtEmpPunchCode.Text;
            objEmployeeDTO.CardNo = txtCardNo.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeName = txtEmpName.Text;

            objEmployeeDTO.FromConfirmDate = dtpFromConfirmDate.Text;
            objEmployeeDTO.ToConfirmDate = dtpToConfirmDate.Text;

            objEmployeeDTO.FromCreateDate = dtpFromCreateDate.Text;
            objEmployeeDTO.ToCreateDate = dtpToCreateDate.Text;
            objEmployeeDTO.NIDNo = txtNIDNoSearch.Text;

            dt = objEmployeeBLL.searchEmployeeRecord(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
               // MessageBox(strMsg);
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsg.Text = strMsg;
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
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsg.Text = strMsg;
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
            //strEmployeeTypeId = Session["strEmployeeTypeId"].ToString().Trim();
            strLoginDay = Session["strLoginDay"].ToString().Trim();
            strLoginMonth = Session["strLoginMonth"].ToString().Trim();
            strLoginDate = Session["strLoginDate"].ToString().Trim();

        }

        public void loadEmployeeRecord()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeRecord();


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
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
            int strRowId = gvEmployeeList.SelectedRow.RowIndex;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;

            string strMsg = "Row Index: " + strRowId + "\\SL: " + strSLNo + "\\CARD NO: " + strCardNo +  "\\nEmployee ID : " + strEmployeeId + "\\nName: " + strEmployeeName +
                "\\nDesignation: " + strDesignation ;             
            showEmployee(strEmployeeId, strHeadOfficeId, strBranchOfficeId);
        }
        public void showEmployee(string employeeId, string strHeadOfficeId, string strBranchOfficeId)
        {

            this.Context.Session["strID"] = strEmployeeId;
            
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = employeeId;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.UpdateBy = strEmployeeId;
       
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeDetail.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEmployeeDetail(objReportDTO));


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
                rd.ExportToHttpResponse
          (CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet");
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
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
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadEmployeeRecord();
            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
            }
            if (dt != null)
            {
                DataView dataView = new DataView(dt);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

                gvEmployeeList.DataSource = dataView;
                gvEmployeeList.DataBind();
            }
        }

        private string ConvertSortDirectionToSql(System.Web.UI.WebControls.SortDirection sortDirection)
        {
            throw new NotImplementedException();
        }
        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

        private string ConvertSortDirectionToSql(CrystalDecisions.Shared.SortDirection sortDirection)
        {
            switch (GridViewSortDirection)
            {
                case "ASC":
                    GridViewSortDirection = "DESC";
                    break;
                case "DESC":
                    GridViewSortDirection = "ASC";
                    break;
            }
            return GridViewSortDirection;
        }
        protected void chkExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
            }
        }

        protected void chkPDF_CheckedChanged(object sender, EventArgs e)
        {
            if (chkExcel.Checked == true)
            {
                chkExcel.AutoPostBack = true;
                chkPDF.Checked = false;
            }
        }

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        #endregion
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                searchEmployeeRecord();        
            }
            catch(Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }
    }
}