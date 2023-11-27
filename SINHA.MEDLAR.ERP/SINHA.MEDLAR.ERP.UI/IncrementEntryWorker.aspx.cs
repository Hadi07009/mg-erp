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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class IncrementEntryWorker : System.Web.UI.Page
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
                getMonthYearForTax();
                btnSearch.Focus();
                //asad commented on 02.07.2020
                //getFromMonthId();


            }
            if (IsPostBack)
            {

                loadSesscion();

            }
            gvEmployeeList.Columns[10].Visible = false;
            txtIncrmentAmount.Attributes.Add("onkeypress", "return controlEnter('" + txtManuaIncrement.ClientID + "', event)");
        }

        #region "Function"

        public void getFromMonthId()
        {

            //LookUpBLL objLookUpBLL = new LookUpBLL();
            //ddlMonthId.DataSource = objLookUpBLL.getFromMonthId();

            //ddlMonthId.DataTextField = "MONTH_NAME";
            //ddlMonthId.DataValueField = "MONTH_ID";

            //ddlMonthId.DataBind();
            //if (ddlMonthId.Items.Count > 0)
            //{

            //    ddlMonthId.SelectedIndex = 0;
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

            txtIncrmentAmount.Text = "";
            txtManuaIncrement.Text = "";
            dtpJoiningDate.Text = "";
            txtGrossSalary.Text = "";
        }

        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
        }
        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


          
            if (objLookUpDTO.BranchOfficeId == "110")
            {
                objLookUpDTO = objLookUpBLL.getMonthYearForSalaryForIncApprove(strHeadOfficeId, strBranchOfficeId);
            }  
            else
            {
                objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            }
          

          

           

            txtIncrementYear.Text = objLookUpDTO.Year;
            txtsalaryMonth.Text = objLookUpDTO.Month;


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

        public void GetSelectedMonthlyIncrementList()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            //objEmployeeDTO.LimitDate = dtpLimitDate.Text;

            objEmployeeDTO.Year = txtIncrementYear.Text;

            objEmployeeDTO.Month = txtsalaryMonth.Text;

            //if (ddlMonthId.SelectedValue.ToString() != " ")
            //{
            //    objEmployeeDTO.FromMonthId = ddlMonthId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objEmployeeDTO.FromMonthId = "";
            //}

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

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objEmployeeDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitGroupId = "";
            }

            dt = objEmployeeBLL.GetSelectedMonthlyIncrementList(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                
                lblMsg.Text = strMsg;
                
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
                lblMsg.Text = strMsg;

            }

        }


        public void GetMonthlyEligibleIncrementListWorker()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

            //objEmployeeDTO.LimitDate = dtpLimitDate.Text;

            objEmployeeDTO.Year = txtIncrementYear.Text;
              objEmployeeDTO.Year = txtIncrementYear.Text;
            objEmployeeDTO.Month = txtsalaryMonth.Text;

            //if (ddlMonthId.SelectedValue.ToString() != " ")
            //{
            //    objEmployeeDTO.FromMonthId = ddlMonthId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objEmployeeDTO.FromMonthId = "";
            //}

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objEmployeeDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitGroupId = "";
            }

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
            //commented 30.05.2020
            //dt = objEmployeeBLL.searchWorkerRecordForIncrement(objEmployeeDTO);
            dt = objEmployeeBLL.GetMonthlyEligibleIncrementListWorker(objEmployeeDTO);

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

        //public void searchIncrementEntryWorker()
        //{

        //    EmployeeDTO objEmployeeDTO = new EmployeeDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        //    DataTable dt = new DataTable();



        //    objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
        //    objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

        //    objEmployeeDTO.EmployeeId = txtEmpId.Text;
        //    objEmployeeDTO.CardNo = txtEmpCardNo.Text;
        //    objEmployeeDTO.Year = txtYear.Text;

        //    if (ddlMonthId.SelectedValue.ToString() != " ")
        //    {
        //        objEmployeeDTO.Month = ddlMonthId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objEmployeeDTO.Month = "";
        //    }
            
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
            

        //    dt = objEmployeeBLL.searchIncrementEntryWorker(objEmployeeDTO);


        //    if (dt.Rows.Count > 0)
        //    {
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();

        //        int count = ((DataTable)GridView1.DataSource).Rows.Count;
        //        string strMsg = " TOTAL " + count + " RECORD FOUND";
        //        // MessageBox(strMsg);
        //        lblMsgRecord.Text = strMsg;
        //        //gvEmployeeList.Columns[2].Visible = false;
        //        // getFirstIndex();

//}
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        GridView1.DataSource = dt;
        //        GridView1.DataBind();
        //        int totalcolums = GridView1.Rows[0].Cells.Count;
        //        GridView1.Rows[0].Cells.Clear();
        //        GridView1.Rows[0].Cells.Add(new TableCell());
        //        GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        //MessageBox(strMsg);
        //        lblMsgRecord.Text = strMsg;
        //        //gvEmployeeList.Columns[2].Visible = false;
        //    }

        

        public void getEmployeeInformation()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO = objSalaryBLL.getEmployeeInformation(txtCardNo.Text, strHeadOfficeId, ddlUnitId.SelectedValue.ToString(), ddlSectionId.SelectedValue.ToString());

            txtDesignationName.Text = objSalaryDTO.DesginationName;
            txtEmployeeId.ID = objSalaryDTO.EmployeeId;
            txtEmployeeName.Text = objSalaryDTO.EmployeeName;




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
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[9].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;




                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;
                txtGrossSalary.Text = strGrossSalary;
                dtpJoiningDate.Text = strJoiningDate;

                txtManuaIncrement.Focus();

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
                    txtManuaIncrement.Focus();
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
                    txtManuaIncrement.Focus();
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



            string strCardNo = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strJoiningDate = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strGrossSalary = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[9].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtGrossSalary.Text = strGrossSalary;
            dtpJoiningDate.Text = strJoiningDate;

            txtManuaIncrement.Focus();
        }

        public void saveIncrementWorker()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtIncrementYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;

            objSalaryDTO.IncrementAmount = txtManuaIncrement.Text;
            if (chkFivePercent.Checked)
                objSalaryDTO.AutoIncrementYn = "Y";
            else
                objSalaryDTO.AutoIncrementYn = "N";

            if (chkMonthlyIncrementYn.Checked)
                objSalaryDTO.MonthlyIncrementYn = "Y";
            else
                objSalaryDTO.MonthlyIncrementYn = "N";

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
            
            string strMsg = objSalaryBLL.saveIncrementWorker(objSalaryDTO);
            lblMsg.Text = strMsg;

            if (strMsg == "PLEASE CHECK INCREMENT YEAR!!!" || strMsg == "PLEASE CHECK INCREMENT MONTH!!!" || strMsg == "PLEASE ADD FIRST!!!" )
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

        public void deleteMonthlySalary()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.EmployeeId = txtEmployeeId.Text;

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
            string strMsg = objReportBLL.deleteMonthlySalary(objReportDTO);
            MessageBox(strMsg);



        }


        public void processIncrementWorker()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtIncrementYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;
            objReportDTO.IncrementAmount = txtIncrmentAmount.Text;

            objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();

            //if (ddlSectionId.SelectedValue.ToString() != " ")
            //{
            //    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objReportDTO.SectionId = "";
            //}

            //if (ddlUnitId.SelectedValue.ToString() != " ")
            //{
            //    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objReportDTO.UnitId = "";
            //}

            if (chkFivePercent.Checked == true)
            {
                objReportDTO.ChkFivePercent ="Y";
            }
            else
            {
                objReportDTO.ChkFivePercent = "N";
            }

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processIncrementWorker(objReportDTO);
        }
        public void processIncrementAmountToGross()
        {
            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.UnitGroupId = "";
            }

            objReportDTO.Year = txtIncrementYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.processIncrementAmountToGross(objReportDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }

        public void addWorkerIncrement()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";

            string autoIncrementYn = "Y";

            if (chkFivePercent.Checked)
                autoIncrementYn = "Y";
            else
                autoIncrementYn = "N";

            string monthlyIncrementYn = "Y";

            //if (chkMonthlyIncrementYn.Checked)
            //    monthlyIncrementYn = "Y";
            //else
            //    monthlyIncrementYn = "N";

            string strCount = gvEmployeeList.Rows.Count.ToString();

            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");

                    if (chkEmployee.Checked)
                    {

                        string strId = (row.FindControl("lblEmployeeId") as Label).Text;
                        objSalaryDTO.EmployeeId = strId;

                        //if (ddlSectionId.SelectedValue.ToString() != " ")
                        //{
                        //    objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    objSalaryDTO.SectionId = "";
                        //}
                        //if (ddlUnitId.SelectedValue.ToString() != " ")
                        //{
                        //    objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                        //}
                        //else
                        //{
                        //    objSalaryDTO.UnitId = "";
                        //}
                                                
                        objSalaryDTO.AutoIncrementYn = autoIncrementYn;
                        objSalaryDTO.MonthlyIncrementYn = monthlyIncrementYn;
                        objSalaryDTO.IncrementAmount = txtManuaIncrement.Text;
                        objSalaryDTO.Year = txtIncrementYear.Text;
                        objSalaryDTO.Month = txtsalaryMonth.Text;
                        objSalaryDTO.UpdateBy = strEmployeeId;
                        objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                        objSalaryDTO.BranchOfficeId = strBranchOfficeId;
                        strMsg = objSalaryBLL.addWorkerIncrement(objSalaryDTO);
                    }
                }
            }
            if (strMsg == "PLEASE CHECK INCREMENT YEAR!!!" || strMsg == "PLEASE CHECK INCREMENT MONTH!!!" || strMsg == "PLEASE CHECK UNIT OR SECTION OR CLICK SEARCH BUTTON!!!" || strMsg == "ADDED SUCCESSFULLY")
            {
                MessageBox(strMsg);
                return;
            }
        }
        public void processIncrementProposal()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            
            //objReportDTO.LimitDate = dtpLimitDate.Text;
            objReportDTO.Year = txtIncrementYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;
            
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

            string strMsg = objReportBLL.processIncrementProposal(objReportDTO);

        }
        public void processIncrementProposalMonthly()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            //old
            //objReportDTO.Year = (Convert.ToInt32(txtIncrementYear.Text.Trim()) - 1).ToString();
            //new
            objReportDTO.Year = txtIncrementYear.Text.Trim();
            objReportDTO.Month = txtsalaryMonth.Text.Trim();
                        
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

            string strMsg = objReportBLL.processIncrementProposalMonthly(objReportDTO);
            
        }
        public void processIncProposalExistsMonthly()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.Year = txtIncrementYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;


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

            string strMsg = objReportBLL.processIncProposalExistsMonthly(objReportDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;


        }
        //public void processNewEmpProposal()
        //{


        //    ReportDTO objReportDTO = new ReportDTO();
        //    ReportBLL objReportBLL = new ReportBLL();



        //    if (ddlMonthId.SelectedValue.ToString() != " ")
        //    {
        //        objReportDTO.Month = ddlMonthId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objReportDTO.Month = "";

        //    }

        //    objReportDTO.Year = txtYear.Text;
        //    objReportDTO.LimitDate = dtpLimitDate.Text;



        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //    {
        //        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //    }
        //    else
        //    {

        //        objReportDTO.SectionId = "";
        //    }



        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //    {
        //        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objReportDTO.UnitId = "";

        //    }



        //    objReportDTO.HeadOfficeId = strHeadOfficeId;
        //    objReportDTO.BranchOfficeId = strBranchOfficeId;
        //    objReportDTO.UpdateBy = strEmployeeId;

        //    string strMsg = objReportBLL.processNewEmpProposal(objReportDTO);
        //    //MessageBox(strMsg);
        //    //lblMsg.Text = strMsg;


        //}

        #endregion

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



                else if (txtManuaIncrement.Text == "" || txtManuaIncrement.Text == string.Empty)
                {
                    goToNextRecord();
                    //searchIncrementEntryWorker();
                    GetSelectedMonthlyIncrementList();
                    clearMessage();
                }

                else if (txtIncrementYear.Text == "")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return;
                }

                else if (txtsalaryMonth.Text == "")
                {

                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }


                else
                {
                    saveIncrementWorker();
                    processIncrementWorker();
                   // searchIncrementEntryWorker();
                    GetSelectedMonthlyIncrementList();
                    goToNextRecord();
                 
                    //searchWorkerIncrementEntry();
                    GetWorkerIncrementList();


                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {                    
                    if (txtIncrementYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        MessageBox(strMsg);
                        txtIncrementYear.Focus();
                        return;
                    }
                     if (txtsalaryMonth.Text == "")
                    {
                        string strMsg = "Please Enter Month!!!";
                        MessageBox(strMsg);
                        txtsalaryMonth.Focus();
                        return;
                    }
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
                }
                  //searchWorkerRecordForIncrement();
                  GetMonthlyEligibleIncrementListWorker();
                        clearYellowTextBox();
                        clearTextBox();
                        gvEmployeeList.SelectedIndex = 0;
                        //commented on 01.06.2020
                       // searchIncrementEntryWorker();
                        //added
                        GetSelectedMonthlyIncrementList();
                        goToNextRecord();
                        //searchWorkerIncrementEntry();
                      GetWorkerIncrementList();
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }


        #region "Crystal Report Functionality"

        protected void Page_UnLoad(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            this.CrystalReportViewer1.Dispose();
            this.CrystalReportViewer1 = null;
            rd.Dispose();
            rd.Close();
            GC.Collect();
            GC.WaitForPendingFinalizers();

        }

        protected void CrystalReportViewer1_Unload(object sender, EventArgs e)
        {

            this.CrystalReportViewer1.ReportSource = null;

            CrystalReportViewer1.Dispose();

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

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;

        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {




            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strJoiningDate = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strGrossSalary = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[9].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[3].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[4].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtGrossSalary.Text = strGrossSalary;
            dtpJoiningDate.Text = strJoiningDate;



           // searchWorkerIncrementEntry();
            GetWorkerIncrementList();
            txtIncrmentAmount.Focus();



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

        protected void btnSalaryProcess_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlUnitGroupId.SelectedValue.ToString() == "")
                {
                    string strMsg = "Please Select Unit group Name!!!";
                    MessageBox(strMsg);
                    ddlUnitGroupId.Focus();
                    return;
                }
                else if (txtIncrementYear.Text == "")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return;
                }
                else if (txtsalaryMonth.Text == "")
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                else
                {                  
                    processIncrementAmountToGross();
                    GetSelectedMonthlyIncrementList();
                    //searchIncrementEntryWorker();
                    // searchWorkerIncrementEntry();
                    GetWorkerIncrementList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            //if(strBranchOfficeId == "110")
            //{
            //    if (txtsalaryMonth.Text == "0")
            //    {

            //        string strMsg = "Please Enter  Month!!!";
            //        MessageBox(strMsg);
            //        txtsalaryMonth.Focus();
            //        return;
            //    }
                
            //    else if (txtIncrementYear.Text == "")
            //    {

            //        string strMsg = "Please Enter Year!!!";
            //        MessageBox(strMsg);
            //        txtIncrementYear.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        //searchIncrementEntryWorker();
            //        GetSelectedMonthlyIncrementList();
            //    }
            //}
            //else
            //{
            //    if (ddlMonthId.Text == "0")
            //    {
            //        string strMsg = "Please Select From Month!!!";
            //        MessageBox(strMsg);
            //        ddlMonthId.Focus();
            //        return;
            //    }
                
            //    else if (txtYear.Text == "")
            //    {

            //        string strMsg = "Please Enter Year!!!";
            //        MessageBox(strMsg);
            //        txtYear.Focus();
            //        return;
            //    }
            //    else
            //    {
            //        //searchIncrementEntryWorker();
            //        GetSelectedMonthlyIncrementList();
            //    }
            //}
        }

        protected void btnSalarySheet_Click(object sender, EventArgs e)
        {

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

        protected void btnDelete_Click(object sender, EventArgs e)
        {

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
                    //searchWorkerIncrementEntry();
                    GetWorkerIncrementList();
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
                    GetWorkerIncrementList();
                    clearMessage();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);
            }
        }


        public void GetWorkerIncrementList()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            
            string strUnitId = "";
            string strSectionId = "";

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                strUnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                strUnitId = "";
            }
            
            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                strSectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                strSectionId = "";
            }

            objSalaryDTO = objSalaryBLL.GetWorkerIncrementList(txtEmployeeId.Text, txtIncrementYear.Text, txtsalaryMonth.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);
            if (objSalaryDTO.IncrementAmount == null || objSalaryDTO.IncrementAmount == "0")
            {
                txtIncrmentAmount.Text = "";
            }
            else
            {
                txtIncrmentAmount.Text = objSalaryDTO.IncrementAmount;
            }

            if (objSalaryDTO.ManualIncrement == null || objSalaryDTO.ManualIncrement == "0")
            {
                txtManuaIncrement.Text = "";
            }
            else
            {
                txtManuaIncrement.Text = objSalaryDTO.ManualIncrement;
            }
            //txtGrossSalary.Text = objSalaryDTO.GrossSalary;
            //dtpJoiningDate.Text = objSalaryDTO.JoiningDate;
            txtManuaIncrement.Focus();
        }



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

            string strYear = GridView1.SelectedRow.Cells[10].Text;
            string strMonth = GridView1.SelectedRow.Cells[11].Text;


            string strEmployeeId = GridView1.SelectedRow.Cells[12].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;


            txtIncrementYear.Text = strYear;
            txtsalaryMonth.Text = strMonth;

            //searchWorkerIncrementEntry();
            GetWorkerIncrementList();
            txtIncrmentAmount.Focus();



        }

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            int indexOfColumn = 7;

            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[indexOfColumn].Visible = false;
            }

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

        protected void btnIncrementSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitGroupId.SelectedValue.ToString() == "")
                {
                    string strMsg = "Please Select Unit Group Name!!!";
                    MessageBox(strMsg);
                    ddlUnitGroupId.Focus();
                    return;
                }

                if (strBranchOfficeId == "110")
                {
                    //rptIncrementSheetWorker();
                    GetIncrementSheetWorker();
                }
                else
                {
                    if (txtsalaryMonth.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        MessageBox(strMsg);
                        txtsalaryMonth.Focus();
                        return;
                    }
                    else if (txtIncrementYear.Text == "")
                    {
                        string strMsg = "Please Enter Year!!!";
                        MessageBox(strMsg);
                        txtIncrementYear.Focus();
                        return;
                    }
                    else
                    {
                        //rptIncrementSheetWorker();
                        GetIncrementSheetWorker();
                    }
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

        public void GetIncrementSheetWorker()
        {

            try
            {
                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                DataTable dt = new DataTable();

                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                objEmployeeDTO.EmployeeId = txtEmpId.Text;
                objEmployeeDTO.CardNo = txtEmpCardNo.Text;
                
                objEmployeeDTO.Year = txtIncrementYear.Text;
                objEmployeeDTO.Month = txtsalaryMonth.Text;
                
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objEmployeeDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objEmployeeDTO.UnitGroupId = "";
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                //old commented 02/06/2020
                // rd.SetDataSource(objReportBLL.rptIncrementSheetWorker(objReportDTO));
                rd.SetDataSource(objEmployeeBLL.GetSelectedMonthlyIncrementList(objEmployeeDTO));
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

        public void rptIncrementSheetWorker()
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

                objReportDTO.JoiningMonth = txtsalaryMonth.Text.Trim();

                //if (ddlMonthId.SelectedValue.ToString() != " ")
                //{
                //    objReportDTO.JoiningMonth = ddlMonthId.SelectedValue.ToString();
                //}
                //else
                //{
                //    objReportDTO.JoiningMonth = "";
                //}

                //objReportDTO.JoiningYear = txtYear.Text;
                objReportDTO.JoiningYear = (Convert.ToInt32(txtIncrementYear.Text.Trim()) - 1).ToString();
                objReportDTO.Year = txtIncrementYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncrementSheetWorker(objReportDTO));


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
        public void rptIncrementSheetRequisitionWorker()
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
                objReportDTO.Month = txtsalaryMonth.Text;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementRequisitionSheetWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncrementSheetRequisitionWorker(objReportDTO));
                
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
        public void rptIncrementMonthlySummerySheetWorker()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                processMonthlyIncrementProposalWorkerSummery();

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
                objReportDTO.Month = txtsalaryMonth.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementMonthlyWorkerSummery.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncrementMonthlySummerySheetWorker(objReportDTO));


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

        protected void btnFinalProcess_Click(object sender, EventArgs e)
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

                    processIncrementAmountToGross();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
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

                addWorkerIncrement();

            }
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
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
                if (ddlUnitGroupId.SelectedValue.ToString() == "")
                {
                    string strMsg = "Please Select Unit Group Name!!!";
                    MessageBox(strMsg);
                    ddlUnitGroupId.Focus();
                    return;
                }
                else if (txtIncrementYear.Text == "")
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return;
                }
                else if (txtsalaryMonth.Text == "")
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                else
                {
                        addWorkerIncrement();
                        processIncrementWorker();
                    //searchIncrementEntryWorker();
                    GetSelectedMonthlyIncrementList();
                    // searchWorkerIncrementEntry();
                    GetWorkerIncrementList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnIncrementSheetRequistion_Click(object sender, EventArgs e)
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
                    rptIncrementSheetRequisitionWorker();
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
            rptIncrementMonthlySummerySheetWorker();
        }

        public void processMonthlyIncrementProposalWorkerSummery()
        {


            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();




            objTiffinDTO.Year = txtIncrementYear.Text;
            objTiffinDTO.Month = txtsalaryMonth.Text;


            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.UnitId = "";

            }


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objTiffinDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objTiffinDTO.SectionId = "";

            }


            objTiffinDTO.UpdateBy = strEmployeeId;
            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objTiffinBLL.processMonthlyIncrementProposalWorkerSummery(objTiffinDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);







        }


        protected void btnIncrementProposalSheet_Click(object sender, EventArgs e)
        {                       
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
                

                if (txtIncrementYear.Text == "")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == "")
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                                
                    processIncrementProposalMonthly();

                    objReportDTO.HeadOfficeId = strHeadOfficeId;
                    objReportDTO.BranchOfficeId = strBranchOfficeId;
                    objReportDTO.UpdateBy = strEmployeeId;

                    if (ddlUnitGroupId.SelectedValue.ToString() != "")
                    {
                        objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                    }
                    else
                    {
                        objReportDTO.UnitGroupId = "";
                    }

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

            //objReportDTO.Year = (Convert.ToInt32(txtIncrementYear.Text.Trim()) - 1).ToString();
            objReportDTO.Year = txtIncrementYear.Text.Trim();
            objReportDTO.Month = txtsalaryMonth.Text.Trim();
                                
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncListWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptIncListWorker(objReportDTO));
                
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
                
        protected void btnIncrementProposalExistsSheet_Click(object sender, EventArgs e)
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            if (txtIncrementYear.Text == "")
            {

                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtIncrementYear.Focus();
                return;
            }

            else if (txtsalaryMonth.Text == "")
            {

                string strMsg = "Please Enter Mont!!!";
                MessageBox(strMsg);
                txtsalaryMonth.Focus();
                return;
            }

                processIncProposalExistsMonthly();

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
                objReportDTO.Month = txtsalaryMonth.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptIncrementSheetWorkerExists.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptIncListWorkerExists(objReportDTO));


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

    }
}


    