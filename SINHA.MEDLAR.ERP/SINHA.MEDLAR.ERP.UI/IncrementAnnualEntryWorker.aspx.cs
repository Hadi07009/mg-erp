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

using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Globalization;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class IncrementAnnualEntryWorker : System.Web.UI.Page
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





        public void searchWorkerRecordForAnnualIncrement()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtIncrementYear.Text;
            objEmployeeDTO.Month = txtMonth.Text;
            
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
            dt = objEmployeeBLL.searchWorkerRecordForAnnualIncrement(objEmployeeDTO);

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
        public void GetIncrementWorkerByUnitGroup()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtIncrementYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerAnnual.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetIncrementWorkerByUnitGroup(objReportDTO));


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
        public void searchIncrementEntryWorkerAnnual()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
                        
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtIncrementYear.Text;
            objEmployeeDTO.Month = txtMonth.Text;
            
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

            dt = objEmployeeBLL.searchIncrementEntryWorkerAnnual(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
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
                lblMsgRecord.Text = strMsg;
                //gvEmployeeList.Columns[2].Visible = false;
            }

        }

        public void getEmployeeInformation()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO = objSalaryBLL.getEmployeeInformation(txtCardNo.Text, strHeadOfficeId, ddlUnitId.SelectedValue.ToString(), ddlSectionId.SelectedValue.ToString());

            txtDesignationName.Text = objSalaryDTO.DesginationName;
            txtEmployeeId.ID = objSalaryDTO.EmployeeId;
            txtEmployeeName.Text = objSalaryDTO.EmployeeName;




        }


        public void searchWorkerIncrementEntryAnnual()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            objSalaryDTO = objSalaryBLL.searchWorkerIncrementEntryAnnual(txtEmployeeId.Text, txtIncrementYear.Text, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.IncrementAmount == "" || objSalaryDTO.IncrementAmount == "0")
            {
                txtIncrementAmount.Text = "";
            }
            else
            {
                txtIncrementAmount.Text = objSalaryDTO.IncrementAmount;
            }
        }

        public void GetIncrementAmount()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO = objSalaryBLL.GetIncrementAmount(txtEmployeeId.Text, txtIncrementYear.Text, txtMonth.Text, hfBatchNo.Value, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.IncrementAmount == "" || objSalaryDTO.IncrementAmount == "0")
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

                hfBatchNo.Value = string.Empty;

                string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strJoiningDate = gvEmployeeList.SelectedRow.Cells[4].Text;
                string strGrossSalary = gvEmployeeList.SelectedRow.Cells[5].Text;

                string autoIncrement = gvEmployeeList.SelectedRow.Cells[6].Text;

                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[8].Text;
                string batchNo = gvEmployeeList.SelectedRow.Cells[9].Text;

                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;
                txtGrossSalary.Text = strGrossSalary;

                SalaryDTO objSalaryDTO = new SalaryDTO();
                SalaryBLL objSalaryBLL = new SalaryBLL();
                objSalaryDTO = objSalaryBLL.GetPropGrossAtYearlyIncrement(strEmployeeId, txtIncrementYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);
                txtProposesGross.Text = objSalaryDTO.ProposedGrossSalary;

                txtAutoIncrement.Text = autoIncrement;
                dtpJoiningDate.Text = strJoiningDate;
                hfBatchNo.Value = batchNo;
                
                txtIncrementAmount.Focus();

                //if (txtIncrementAmount.Enabled == true)
                //    txtIncrementAmount.Focus();
                //else
                //    txtIncrementAmount2ndTerm.Focus();

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
                    //added on 26.12.2019
                    txtIncrementAmount.Focus();

                    //if (txtIncrementAmount.Enabled == true)
                    //    txtIncrementAmount.Focus();
                    //else
                    //    txtIncrementAmount2ndTerm.Focus();
                    //return;

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

                    //added on 26.12.2019
                    txtIncrementAmount.Focus();
                    return;

                    //if (txtIncrementAmount.Enabled == true)
                    //    txtIncrementAmount.Focus();
                    //else
                    //    txtIncrementAmount2ndTerm.Focus();
                    //return;
                }

                else
                {

                    l = 1;
                    gvEmployeeList.SelectedIndex = l;
                    result = gvEmployeeList.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;

            //int strRowCount = strRowId - 1;
            //int intCount = gvIncrementList.Rows.Count;
            //if (intCount == strRowCount)
            //{
            //    string strMsg = "Entry Completed";
            //    MessageBox(strMsg);
            //    return;

            //}
            //else
            //{

            hfBatchNo.Value = string.Empty;

            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strJoiningDate = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strGrossSalary = gvEmployeeList.SelectedRow.Cells[5].Text;

            string autoIncrement = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[8].Text;
            string batchNo = gvEmployeeList.SelectedRow.Cells[9].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtGrossSalary.Text = strGrossSalary;

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            objSalaryDTO = objSalaryBLL.GetPropGrossAtYearlyIncrement(strEmployeeId, txtIncrementYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);
            txtProposesGross.Text = objSalaryDTO.ProposedGrossSalary;

            txtAutoIncrement.Text = autoIncrement;
            dtpJoiningDate.Text = strJoiningDate;
            hfBatchNo.Value = batchNo;

            //uncommented
            txtIncrementAmount.Focus();

            //if (txtIncrementAmount.Enabled == true)
            //    txtIncrementAmount.Focus();
            //else
            //    txtIncrementAmount2ndTerm.Focus();
        }

        public void saveIncrementWorkerAnnual()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtIncrementYear.Text;
            objSalaryDTO.Month = txtMonth.Text;
            objSalaryDTO.BatchNo = hfBatchNo.Value;

            objSalaryDTO.IncrementAmount = txtIncrementAmount.Text;

            //objSalaryDTO.IncrementAmount2ndTerm = txtIncrementAmount2ndTerm.Text;

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


            string strMsg = objSalaryBLL.saveIncrementWorkerAnnual(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

            if (strMsg == "PLEASE CHECK INCREMENT YEAR!!!")
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
            objReportDTO.Month = txtMonth.Text;

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

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitGroupId = "";
            }

            //Asad
            if (ChkAllowGeneralIncrement.Checked)
                objReportDTO.AllowGeneralIncrement = "Y";
            else
                objReportDTO.AllowGeneralIncrement = "N";

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processIncrementWorkerAnnual(objReportDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


        }
        public void processIncrementAnnualWorkerJK()
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

            string strMsg = objReportBLL.processIncrementWorkerAnnualJK(objReportDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


        }
        public void processIncrementRequisitionWorkerYearly()
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

            string strMsg = objReportBLL.processIncrementRequisitionWorkerYearly(objReportDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


        }

        public void processIncrementAmountToGrossAnnualWorker()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            
            objReportDTO.Year = txtIncrementYear.Text;
            objReportDTO.Month = txtMonth.Text;

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

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitGroupId = "";
            }

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processIncrementAmountToGrossAnnualWorker(objReportDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }



        public void rptIncrementAnnualSheetWorker()
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




                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerAnnual.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncrementAnnualSheetWorker(objReportDTO));


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
        public void rptIncrementAnnualSheetWorkerByRequisition()
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




                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerAnnualByUnit.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncrementAnnualSheetWorkerByRequisition(objReportDTO));


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

        public void IncrementRequisitionWorkerYearly()
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

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementRequisitionWorkerYearly.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.IncrementRequisitionWorkerYearly(objReportDTO));


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

                    searchWorkerRecordForAnnualIncrement();
                    clearYellowTextBox();
                    clearTextBox();

                    gvEmployeeList.SelectedIndex = 0;
                    searchIncrementEntryWorkerAnnual();
                    goToNextRecord();
                    GetIncrementAmount();
                    
                }

            }

            catch (Exception ex)
            {

            }
        }


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;

        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hfBatchNo.Value = string.Empty;

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strJoiningDate = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strGrossSalary = gvEmployeeList.SelectedRow.Cells[5].Text;
            string autoIncrement = gvEmployeeList.SelectedRow.Cells[6].Text;

            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[8].Text; /*7*/
            string batchNo = gvEmployeeList.SelectedRow.Cells[9].Text;  /*8*/

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtGrossSalary.Text = strGrossSalary;

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            objSalaryDTO = objSalaryBLL.GetPropGrossAtYearlyIncrement(strEmployeeId, txtIncrementYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);
            txtProposesGross.Text = objSalaryDTO.ProposedGrossSalary;

            txtAutoIncrement.Text = autoIncrement;
            dtpJoiningDate.Text = strJoiningDate;
            hfBatchNo.Value = batchNo;

            GetIncrementAmount();
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hfBatchNo.Value = string.Empty;
            int strRowId = GridView1.SelectedRow.RowIndex + 1;

            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            //4
            //5
            string autoIncrement = GridView1.SelectedRow.Cells[6].Text;
            //7
            string incrementAmount2ndTerm = GridView1.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string proposed_gross_salary = GridView1.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            //9
            string strEmployeeId = GridView1.SelectedRow.Cells[11].Text;
            string finalized = GridView1.SelectedRow.Cells[12].Text;
            string batch_no = GridView1.SelectedRow.Cells[13].Text;
                        
            txtIncrementAmount2ndTerm.Text = incrementAmount2ndTerm;
            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtAutoIncrement.Text = autoIncrement;
            hfBatchNo.Value = batch_no;

            GetIncrementAmount();
            txtIncrementAmount.Focus();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    btnSearch.Focus();
                    return;
                }
                else if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    return;
                }
                else if (txtIncrementAmount.Text == "")
                {
                    goToNextRecord();
                    searchIncrementEntryWorkerAnnual();
                    clearMessage();
                }
                else
                {
                    saveIncrementWorkerAnnual();
                    searchIncrementEntryWorkerAnnual();
                    goToNextRecord();
                    GetIncrementAmount();
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
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
                    GetIncrementAmount();
                                        
                    clearMessage();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }

        private void GetAutoIncrementAmount()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtIncrementYear.Text;
            objSalaryDTO.Month = txtMonth.Text;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;

            SalaryBLL objSalaryBLL = new SalaryBLL();
            string autoIncrAmount = objSalaryBLL.GetWorkerAutoIncrementAmount(objSalaryDTO);
            txtAutoIncrement.Text = autoIncrAmount;
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
                    GetIncrementAmount();       
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
            searchIncrementEntryWorkerAnnual();
        }

        protected void btnIncrementSheet_Click(object sender, EventArgs e)
        {
            
            try
            {


                if (ddlUnitGroupId.SelectedItem.Value == "")
                {
                    if (ddlUnitId.Text == " ")
                    {
                        string strMsg = "Please Select Unit Name!!!";
                        MessageBox(strMsg);
                        ddlUnitId.Focus();
                        return;
                    }
                    if (ddlSectionId.Text == " ")
                    {
                        string strMsg = "Please Select Section Name!!!";
                        MessageBox(strMsg);
                        ddlUnitId.Focus();
                        return;
                    }
                    rptIncrementAnnualSheetWorker();
                }
                else
                {
                    if (ddlUnitId.Text != " ")
                    {
                        if (ddlSectionId.Text == " ")
                        {
                            string strMsg = "Please Select Section Name!!!";
                            MessageBox(strMsg);
                            ddlUnitId.Focus();
                            return;
                        }
                    }
                    GetIncrementWorkerByUnitGroup();
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


                processIncrementAnnualWorker();
                processIncrementAmountToGrossAnnualWorker();
                searchIncrementEntryWorkerAnnual();
                GetIncrementAmount();
                GetAutoIncrementAmount();
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnRequisition_Click(object sender, EventArgs e)
        {
            try
            {



                processIncrementRequisitionWorkerYearly();
                IncrementRequisitionWorkerYearly();


            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);



            }
        }

        protected void btnIncrementSheetByRequisition_Click(object sender, EventArgs e)
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

                    rptIncrementAnnualSheetWorkerByRequisition();

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
                if (ddlSectionId.Text == "")
                {
                    string strMsg = "Please Select Section Name!!!";
                    MessageBox(strMsg);
                    ddlSectionId.Focus();
                    return;
                }
                if (txtIncrementYear.Text == "")
                {
                    string strMsg = "Please Enter Increment Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return;
                }
                if (txtMonth.Text == "")
                {
                    string strMsg = "Please Enter Increment Month!!!";
                    MessageBox(strMsg);
                    txtMonth.Focus();
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
        public void GetWorkerAnnualIncrementDetail()
        {

            try
            {
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                DataTable data = new DataTable();

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                objEmployeeDTO.EmployeeId = txtEmpId.Text;

                objEmployeeDTO.FromDate = dtpFromDate.Text;
                objEmployeeDTO.ToDate = dtpToDate.Text;

                objEmployeeDTO.CardNo = txtEmpCardNo.Text;
                objEmployeeDTO.Year = txtIncrementYear.Text;
                objEmployeeDTO.Month = txtMonth.Text;

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

        protected void btnIncrementSheetByUnitGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitGroupId.Text == "")
                {
                    string strMsg = "Please Select Unit Group Name!!!";
                    MessageBox(strMsg);
                    ddlUnitId.Focus();
                    return;
                }
                else
                {
                    GetWorkerAnnualIncrementSheetBySection();
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

        public void GetWorkerAnnualIncrementSheetBySection()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtIncrementYear.Text;
                objReportDTO.Month = txtMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWorkerAnnualIncrementSheetBySection.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerAnnualIncrementSheetBySection(objReportDTO));

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