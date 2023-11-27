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
    public partial class SalaryCheckProcess : System.Web.UI.Page
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
                getMonthYearForTax();
                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
                btnSearch.Focus();
                LoadEmployeeSalaryApprove();
                searchSalaryApprovedEmployeeEntry();
                // loadSalaryApprovedEmployeeEntry();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }


            GridView1.Columns[13].Visible = false;

        }

        #region "Function"

        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtSalaryYear.Text = objLookUpDTO.Year;
            txtsalaryMonth.Text = objLookUpDTO.Month;           
        }

        //public void getDate()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.getDate();

        //    dtpAttendenceDate.Text = objLookUpDTO.FromDate;



        //}



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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "attendence_report");
                Response.End();
                CrystalReportViewer1.RefreshReport();

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

        //public void getCurrentDate()
        //{
        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.getCurrentDate();

        //    dtpAttendenceDate.Text = objLookUpDTO.AttendenceDate;



        //}


        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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



        public void searchEmployeeSalaryApprove()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            // objEmployeeDTO.LogDate = dtpAttendenceDate.Text;


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





            dt = objEmployeeBLL.searchEmployeeSalaryApprove(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

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
            }

        }

        public void LoadEmployeeSalaryApprove()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;
           // objEmployeeDTO.LogDate = dtpAttendenceDate.Text;


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





            dt = objEmployeeBLL.LoadEmployeeSalaryCheck(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD WAITING FOR YOUR APPROVE";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;

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
                lblMsg.ForeColor = System.Drawing.Color.Black;
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }

        }


        public void searchSalaryApprovedEmployeeEntry()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;


            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;


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



           // objEmployeeDTO.AprovedDate = dtpAttendenceDate.Text;


            
            objEmployeeDTO.UpdateBy = strEmployeeId;






            dt = objEmployeeBLL.searchSalaryCheckedEmployeeEntry(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvSalaryAprovedEmpList.DataSource = dt;
                gvSalaryAprovedEmpList.DataBind();

                int count = ((DataTable)gvSalaryAprovedEmpList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvSalaryAprovedEmpList.DataSource = dt;
                gvSalaryAprovedEmpList.DataBind();
                int totalcolums = gvSalaryAprovedEmpList.Rows[0].Cells.Count;
                gvSalaryAprovedEmpList.Rows[0].Cells.Clear();
                gvSalaryAprovedEmpList.Rows[0].Cells.Add(new TableCell());
                gvSalaryAprovedEmpList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvSalaryAprovedEmpList.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
        }
    


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }


        public void processManualAttendenceForBP()
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



          //  objEmployeeDTO.FromDate = dtpAttendenceDate.Text;
          //  objEmployeeDTO.ToDate = dtpAttendenceDate.Text;


            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.UpdateBy = strEmployeeId;


            string strMsg = objEmployeeBLL.processManualAttendenceForBP(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

        public void addSalaryAppovedProcessForEmp()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            string strMsg = "";
            string strCount = GridView1.Rows.Count.ToString();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {

                        string strId = (row.FindControl("lblEmployeeId") as Label).Text;
                        string employeeTypeId = (row.FindControl("lbloccurence_type_id") as Label).Text;

                        objEmployeeDTO.OccurenceTypeId = employeeTypeId;
                        objEmployeeDTO.EmployeeId = strId;

                        objEmployeeDTO.Year = txtSalaryYear.Text;
                        objEmployeeDTO.Month = txtsalaryMonth.Text;

                        objEmployeeDTO.UpdateBy = strEmployeeId;
                        objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                        objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                        strMsg = objEmployeeBLL.addSalaryCheckedProcessForEmp(objEmployeeDTO);


                    }
                }
            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

        public void SalaryAppovedProcessForEmp()
        {
            string strMsg = "";
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            
            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objEmployeeBLL.SalaryAppovedProcessForEmp(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        public void rptSalaryApproveSheet()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();



                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
                objReportDTO.EmployeeId = txtEmpId.Text;

               // objReportDTO.FromDate = dtpAttendenceDate.Text;
               // objReportDTO.ToDate = dtpAttendenceDate.Text;




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



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryApproveSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptSalaryApproveSheet(objReportDTO));


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


    
        #endregion


        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dtpAttendenceDate.Text == string.Empty)
                //{
                //    string strMsg = "Please Enter Attendence Date!!!";
                //    MessageBox(strMsg);
                //    dtpAttendenceDate.Focus();
                //    return;
                //}
                //else
                //{
                //    searchAttendenceAprovedEmployeeEntry();
                //}
                searchSalaryApprovedEmployeeEntry();

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                LoadEmployeeSalaryApprove();
                searchSalaryApprovedEmployeeEntry();
                //if (dtpAttendenceDate.Text == string.Empty)
                //{
                //    string strMsg = "Please Enter Attendence Date!!!";
                //    MessageBox(strMsg);
                //    dtpAttendenceDate.Focus();
                //    return;
                //}
                //else
                //{
                //    searchAttendenceEntry();
                //    searchAttendenceAprovedEmployeeEntry();
                //}
                //searchEmployeeSalaryApprove();
                // searchSalaryApprovedEmployeeEntry();

            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnAttendenceSheet_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dtpAttendenceDate.Text == string.Empty)
                //{
                //    string strMsg = "Please Enter Attendence Date!!";
                //    dtpAttendenceDate.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}

                //else
                //{

                //    rptAttendenceSheet();

                //}
                rptSalaryApproveSheet();


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

        protected void btnProcess_Click(object sender, EventArgs e)
        {

         
            addSalaryAppovedProcessForEmp();
            searchSalaryApprovedEmployeeEntry();
            LoadEmployeeSalaryApprove();

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


        #region "Grid View Functionality"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
           


        }




        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
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

        protected void gvSalaryAprovedEmplList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalaryAprovedEmpList.PageIndex = e.NewPageIndex;
          
            searchSalaryApprovedEmployeeEntry();
        }

        protected void gvSalaryAprovedEmpeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvSalaryAprovedEmpList_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvSalaryAprovedEmpList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(gvSalaryAprovedEmpList.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"].ToString());
            string strEmpId = Convert.ToString(stor_id);
            
            deleteSalaryAprovedEmpRecord(strEmpId);
            //Asad commented on 01.04.2019
            //addSalaryAppovedProcessForEmp();
            searchSalaryApprovedEmployeeEntry();
        }

        public void deleteSalaryAprovedEmpRecord(string strEmpId)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmpId = strEmpId;
            objEmployeeDTO.Year = txtSalaryYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objEmployeeBLL.deleteSalaryCheckedEmpRecord(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

            
        }

        protected void gvSalaryEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvSalaryAprovedEmpList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void gvSalaryAprovedEmpList_OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvSalaryAprovedEmpList_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

       
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"].ToString());
            string strEmpId = Convert.ToString(stor_id);

            deleteSalaryAprovedEmpRecord(strEmpId);
            LoadEmployeeSalaryApprove();


        }

       
    }
}