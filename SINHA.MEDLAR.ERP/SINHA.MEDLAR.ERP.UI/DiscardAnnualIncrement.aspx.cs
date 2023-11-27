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

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class DiscardAnnualIncrement : System.Web.UI.Page
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
                clearMsg();
                getOfficeName();
                getYearForIncrementProposal();
                btnSearch.Focus();
                


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


        public void clearYellowTextBox()
        {
            txtCardNo.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtSL.Text = string.Empty;
            txtSLNew.Text = string.Empty;

        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void clearTextBox()
        {

            txtIncrementAmount.Text = "";
        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
        }
        public void getYearForIncrementProposal()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getYearForIncrementProposal(strHeadOfficeId, strBranchOfficeId);

            txtIncrementYear.Text = objLookUpDTO.Year;
           


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





        public void searchDiscardAnnualIncrementWorker()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;

            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpToDate.Text;

            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtIncrementYear.Text;
            objEmployeeDTO.Month = txtIncrementMonth.Text;

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }
            dt = objEmployeeBLL.searchDiscardAnnualIncrementWorker(objEmployeeDTO);

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

        public void GetWorkerAnnualIncrementDetail()
        {

            try
            { 
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable data = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.UpdateBy = strEmployeeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;

            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpToDate.Text;

            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtIncrementYear.Text;
            objEmployeeDTO.Month = txtIncrementMonth.Text;

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }
            data = objEmployeeBLL.searchDiscardAnnualIncrementWorker(objEmployeeDTO);

            string strPath = Path.Combine(Server.MapPath("~/Reports/RptWorkerAnnualIncrementDetail.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(data);

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

        public void searchWorkerIncrementEntryNonProposal()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO = objSalaryBLL.searchWorkerIncrementEntryNonProposal(txtEmployeeId.Text, txtIncrementYear.Text, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.IncrementAmount == "" ||objSalaryDTO.IncrementAmount == "0")
            {
                txtIncrementAmount.Text = "";
            }
            else
            {
                txtIncrementAmount.Text = objSalaryDTO.IncrementAmount;
            }
        }


        public void getFirstIndex()
        {



            int nRow = gvEmployeeList.SelectedIndex;

            if (nRow == -1)
            {
                int rowIndex = 0;
                GridViewRow row = gvEmployeeList.Rows[rowIndex];
                txtCardNo.Text = row.Cells[1].Text;
                txtDesignationName.Text = row.Cells[4].Text;
                txtEmployeeName.Text = row.Cells[3].Text;
                txtEmployeeId.Text = row.Cells[2].Text;

                int l;
                l = gvEmployeeList.SelectedRow.RowIndex + 1;
                txtSL.Text = Convert.ToString(l);
            }
            int courow = gvEmployeeList.Rows.Count - 1;
            {


            }



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
            l = gvEmployeeList.SelectedRow.RowIndex;
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
                        gvEmployeeList.SelectedIndex = 0;
                        result = gvEmployeeList.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

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



            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {
                string strCardNo = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strJoiningDate = gvEmployeeList.SelectedRow.Cells[5].Text;
                string strGrossSalary = gvEmployeeList.SelectedRow.Cells[6].Text;
                string manualIncrementAmount = gvEmployeeList.SelectedRow.Cells[7].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[9].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;

                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;
                txtGrossSalary.Text = strGrossSalary;
                txtIncrementAmount.Text = manualIncrementAmount;
                dtpJoiningDate.Text = strJoiningDate;

                txtIncrementAmount.Focus();

            }
        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


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
                    txtIncrementAmount.Focus();
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
                    txtIncrementAmount.Focus();
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
            string strCardNo = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strJoiningDate = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strGrossSalary = gvEmployeeList.SelectedRow.Cells[6].Text;
            string manualIncrementAmount = gvEmployeeList.SelectedRow.Cells[7].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[9].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtGrossSalary.Text = strGrossSalary;
            txtIncrementAmount.Text = manualIncrementAmount;
            dtpJoiningDate.Text = strJoiningDate;

            txtIncrementAmount.Focus();


        }

        public void saveIncrementWorkerNonProposal()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtIncrementYear.Text;
            objSalaryDTO.Month = txtIncrementYear.Text;

            objSalaryDTO.IncrementAmount = txtIncrementAmount.Text;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.SectionId = "";

            }


            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;


            string strMsg = objSalaryBLL.saveIncrementWorkerNonProposal(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

            if (strMsg == "PLEASE ADDED FIRST!!!")
            {
                MessageBox(strMsg);
                return;

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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "increment_sheet_worker_monthly");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }




        }
        public void processIncrementAnnualWorker()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            objReportDTO.Year = txtIncrementYear.Text;


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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processIncrementWorkerAnnual(objReportDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


        }


        public void processIncrementAmountToGrossWorkerNonProposal()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            objReportDTO.Year = txtIncrementYear.Text;


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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processIncrementAmountToGrossWorkerNonProposal(objReportDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }
        public void processFivePercentNonProposal()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            objReportDTO.Year = txtIncrementYear.Text;


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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processFivePercentNonProposal(objReportDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


        }


        public void rptIncrementAnnualSheetWorkerNonProposal()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

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


                objReportDTO.Year = txtIncrementYear.Text;




                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerAnnualNonProposal.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncrementAnnualSheetWorkerNonProposal(objReportDTO));


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
        public void rptIncrementAnnualSheetWorkerNonProposalByUnit()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

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


                objReportDTO.Year = txtIncrementYear.Text;




                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerAnnualNonProposalByUnit.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncrementAnnualSheetWorkerNonProposalByUnit(objReportDTO));


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
        public void DeleteDiscardAnnualIncrement()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();

            //Start: New Code
            List<SalaryDTO> objIncrementDetailsAll = new List<SalaryDTO>();
            List<SalaryDTO> objIncrementDetailsSelected = new List<SalaryDTO>();
            //End: New Code

            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";
            string strCount = gvEmployeeList.Rows.Count.ToString();

            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    
                    //Start: New Code
                    objSalaryDTO = new SalaryDTO();

                    CheckBox checkBox = (CheckBox)row.FindControl("chkEmployee");

                    if (checkBox.Checked)
                        objSalaryDTO.IsChecked = true;
                    else
                        objSalaryDTO.IsChecked = false;

                    objSalaryDTO.EmployeeId = (row.FindControl("lblEmployeeId") as Label).Text;
                    objSalaryDTO.DetailId = Convert.ToInt32((row.FindControl("lblDetailId") as Label).Text);
                    objSalaryDTO.BatchNo = (row.FindControl("lblBatchNo") as Label).Text;
                    objSalaryDTO.ManualIncrementAmount = (row.FindControl("lblManualIncrementAmount") as Label).Text == string.Empty ? 0 : Convert.ToInt32((row.FindControl("lblManualIncrementAmount") as Label).Text) ;
                    if (ddlSectionId.SelectedValue.ToString() != " ")
                    {
                        objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    }
                    else
                    {
                        objSalaryDTO.SectionId = "";
                    }

                    if (ddlUnitId.SelectedValue.ToString() != " ")
                    {
                        objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    }
                    else
                    {
                        objSalaryDTO.UnitId = "";
                    }

                    objSalaryDTO.Year = txtIncrementYear.Text;
                    objSalaryDTO.Month = txtIncrementMonth.Text;

                    objSalaryDTO.UpdateBy = strEmployeeId;
                    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    objSalaryDTO.BranchOfficeId = strBranchOfficeId;

                    objIncrementDetailsAll.Add(objSalaryDTO);
                    if (objSalaryDTO.IsChecked)
                        objIncrementDetailsSelected.Add(objSalaryDTO);
                    //End: New Code


                    //CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    //if (chkEmployee.Checked)
                    //{

                    //    string employeeId = (row.FindControl("lblEmployeeId") as Label).Text;
                    //    string detailId = (row.FindControl("lblDetailId") as Label).Text;

                    //    string batchNo = (row.FindControl("lblBatchNo") as Label).Text;
                    //    string manualIncrementAmount = (row.FindControl("lblManualIncrementAmount") as Label).Text;

                    //    if (string.IsNullOrEmpty(manualIncrementAmount))
                    //        objSalaryDTO.ManualIncrementAmount = 0;
                    //    else
                    //        objSalaryDTO.ManualIncrementAmount = Convert.ToInt32(manualIncrementAmount);

                    //    objSalaryDTO.EmployeeId = employeeId;
                    //    objSalaryDTO.BatchNo = batchNo;

                    //    if (ddlSectionId.SelectedValue.ToString() != " ")
                    //    {
                    //        objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    //    }
                    //    else
                    //    {
                    //        objSalaryDTO.SectionId = "";
                    //    }

                    //    if (ddlUnitId.SelectedValue.ToString() != " ")
                    //    {
                    //        objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    //    }
                    //    else
                    //    {
                    //        objSalaryDTO.UnitId = "";
                    //    }

                    //    objSalaryDTO.Year = txtIncrementYear.Text;
                    //    objSalaryDTO.Month = txtIncrementMonth.Text;

                    //    objSalaryDTO.UpdateBy = strEmployeeId;
                    //    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    //    objSalaryDTO.BranchOfficeId = strBranchOfficeId;

                    //    strMsg = objSalaryBLL.DeleteDiscardAnnualIncrement(objSalaryDTO);   
                    //}
                }

            }

            //Start: New Code
            var objIncrementAll = objIncrementDetailsAll.OrderByDescending(m => m.DetailId).ToList();
            var objIncrementSelected = objIncrementDetailsSelected.OrderByDescending(m => m.DetailId);

            foreach (var item in objIncrementSelected)
            {
                var detailId = objIncrementAll.Where(m => m.BatchNo == item.BatchNo).Max(m=>m.DetailId);

                if (item.DetailId == detailId)
                {
                    strMsg = objSalaryBLL.DeleteDiscardAnnualIncrement(item);
                    var itemToRemove = objIncrementAll.Where(m => m.DetailId == detailId).SingleOrDefault();
                    objIncrementAll.Remove(itemToRemove);
                }
            }
            //End: New Code

            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }


        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitId.Text == "")
                {
                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }
                if (txtIncrementYear.Text == "")
                {
                    string strMsg = "Please Enter Increment Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return;
                }
                if (txtIncrementMonth.Text == "")
                {
                    string strMsg = "Please Enter Increment Month!!!";
                    MessageBox(strMsg);
                    txtIncrementMonth.Focus();
                    return;
                }

                if (ddlSectionId.Text == "")
                {
                    string strMsg = "Please Select Section Name!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(dtpFromDate.Text) && !string.IsNullOrEmpty(dtpToDate.Text))
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (!string.IsNullOrEmpty(dtpFromDate.Text) && string.IsNullOrEmpty(dtpToDate.Text))
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (!string.IsNullOrEmpty(dtpFromDate.Text) && !string.IsNullOrEmpty(dtpToDate.Text))
                {
                    CultureInfo culture = new CultureInfo("bn-BD");
                    //DateTime tempDate = Convert.ToDateTime("1/1/2010 12:10:15 PM", culture)
                    if (Convert.ToDateTime(dtpFromDate.Text, culture) > Convert.ToDateTime(dtpToDate.Text, culture))
                        {
                        string strMsg = "From date is greater than To date";
                        dtpFromDate.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                }

                  searchDiscardAnnualIncrementWorker();
                  clearYellowTextBox();
                  clearTextBox();
                  gvEmployeeList.SelectedIndex = 0;
                  goToNextRecord();
                
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



            string batchNo = string.Empty;

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strJoiningDate = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strGrossSalary = gvEmployeeList.SelectedRow.Cells[6].Text;
            string manualIncrementAmount = gvEmployeeList.SelectedRow.Cells[7].Text;
            

            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[9].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;

            batchNo = gvEmployeeList.SelectedRow.Cells[11].Text;
            manualIncrementAmount = gvEmployeeList.SelectedRow.Cells[7].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtIncrementAmount.Text = manualIncrementAmount;
            txtGrossSalary.Text = strGrossSalary;
            dtpJoiningDate.Text = strJoiningDate;


           // searchWorkerIncrementEntryNonProposal();
            //searchDiscardAnnualIncrementWorker();

            txtIncrementAmount.Focus();

  



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
        //protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    GridView1.PageIndex = e.NewPageIndex;

        //}

        //protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
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

        //    searchWorkerIncrementEntryNonProposal();
        //    txtIncrementAmount.Focus();



        //}

        //protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        //{
           
        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        //}


        //protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        //{




        //}

        //protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        //{

        //}

        //protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        //{


        //}


        //protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
        //        e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

        //        e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
        //    }
        //}

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

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvEmployeeList.Rows.Count == 0)
        //        {
        //            string strMsg = "Please click searh Button!!!";
        //            MessageBox(strMsg);
        //            btnSearch.Focus();
        //            return;
        //        }

        //        //else if (ddlUnitId.Text == " ")
        //        //{

        //        //    string strMsg = "Please Select Unit Name!!!";
        //        //    MessageBox(strMsg);
        //        //    ddlUnitId.Focus();
        //        //    return;
        //        //}


        //        else
        //        {
        //            DeleteDiscardAnnualIncrement();
        //            processFivePercentNonProposal();
        //           // searchIncrementEntryWorkerNonProposal();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error : " + ex.Message);

        //    }
        //}

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
                else if (ddlUnitId.Text == " ")
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
                    goToNextRecord();
                    searchDiscardAnnualIncrementWorker();
                    clearMessage();
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
                else if (ddlUnitId.Text == " ")
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

                    goToPreviousRecord();
                    searchDiscardAnnualIncrementWorker();
                    clearMessage();


                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //searchIncrementEntryWorkerNonProposal();
        }

        protected void btnIncrementSheet_Click(object sender, EventArgs e)
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

                    rptIncrementAnnualSheetWorkerNonProposal();

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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

             

                    processIncrementAmountToGrossWorkerNonProposal();
                   // searchIncrementEntryWorkerNonProposal();
                    searchWorkerIncrementEntryNonProposal();
                
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
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

                else if (ddlUnitId.Text == " ")
                {

                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }


                else
                {
                   // addWorkerYearlyIncrementNonProposal();
                    processFivePercentNonProposal();
                    //searchIncrementEntryWorkerNonProposal();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnIncrementSheetByUnit_Click(object sender, EventArgs e)
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

                


                else
                {

                    rptIncrementAnnualSheetWorkerNonProposalByUnit();

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

        protected void btnSummery_Click(object sender, EventArgs e)
        {

        }

        protected void btnWorkerSummerySheet_Click(object sender, EventArgs e)
        {
      
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


              

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


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


                objReportDTO.Year = txtIncrementYear.Text;





                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementNonProposalWorkerSummeryBangla.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.incrementProposalSheetWorkerSummeryNonProposal(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                //Queue reportQueue = new Queue();
                ////75 is my print job limit.
                //if (reportQueue.Count > 75)
                //{
                //    ((ReportClass)reportQueue.Dequeue()).Dispose();
                //    //reportView.ReportSource = null;


                //}

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

        protected void btnDelete_Click(object sender, EventArgs e)
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
                    DeleteDiscardAnnualIncrement();
                    searchDiscardAnnualIncrementWorker();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnIncrementDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitId.Text == "")
                {
                    string strMsg = "Please Select Unit Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }
                if (txtIncrementYear.Text == "")
                {
                    string strMsg = "Please Enter Increment Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return;
                }
                if (txtIncrementMonth.Text == "")
                {
                    string strMsg = "Please Enter Increment Month!!!";
                    MessageBox(strMsg);
                    txtIncrementMonth.Focus();
                    return;
                }

                if (ddlSectionId.Text == "")
                {
                    string strMsg = "Please Select Section Name!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(dtpFromDate.Text) && !string.IsNullOrEmpty(dtpToDate.Text))
                {
                    string strMsg = "Please Enter From Date!!";
                    dtpFromDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (!string.IsNullOrEmpty(dtpFromDate.Text) && string.IsNullOrEmpty(dtpToDate.Text))
                {
                    string strMsg = "Please Enter To Date!!";
                    dtpToDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (!string.IsNullOrEmpty(dtpFromDate.Text) && !string.IsNullOrEmpty(dtpToDate.Text))
                {
                    CultureInfo culture = new CultureInfo("bn-BD");
                    if (Convert.ToDateTime(dtpFromDate.Text, culture) > Convert.ToDateTime(dtpToDate.Text, culture))
                    {
                        string strMsg = "From date is greater than To date";
                        dtpFromDate.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                }
                GetWorkerAnnualIncrementDetail();
            }
            catch (Exception ex)
            {
            }
        }
    }
}