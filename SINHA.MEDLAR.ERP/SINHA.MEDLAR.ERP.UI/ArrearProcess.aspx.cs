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
    public partial class ArrearProcess : System.Web.UI.Page
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
                getUnitId();
                getSectionId();
                //getArrearYear();
                getYearForIncrementProposal();
                clearMsg();
                getOfficeName();
                getFromMonthId();
                getToMonthId();
            }
            if (IsPostBack)
            {

                loadSesscion();
            }
        }

        #region "FUNCTION"

        public void getYearForIncrementProposal()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getYearForIncrementYear(strHeadOfficeId, strBranchOfficeId);

            txtYear.Text = objLookUpDTO.Year;



        }

        public void getFromMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlFromMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlFromMonthId.DataTextField = "MONTH_NAME";
            ddlFromMonthId.DataValueField = "MONTH_ID";

            ddlFromMonthId.DataBind();
            if (ddlFromMonthId.Items.Count > 0)
            {

                ddlFromMonthId.SelectedIndex = 0;
            }
        }


        public void getToMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlToMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlToMonthId.DataTextField = "MONTH_NAME";
            ddlToMonthId.DataValueField = "MONTH_ID";

            ddlToMonthId.DataBind();
            if (ddlToMonthId.Items.Count > 0)
            {

                ddlToMonthId.SelectedIndex = 0;
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
            lblMsgRecord.Text = string.Empty;
        }



        //public void getArrearYear()
        //{

        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    objLookUpDTO = objLookUpBLL.getMonthYearForTax();

        //    txtYear.Text = objLookUpDTO.Year;
        //    txtMonth.Text = objLookUpDTO.Month;

        //}

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
        public void processArrear()
        {

            ArrearDTO objArrearDTO = new ArrearDTO();
            ArrearBLL objArrearBLL = new ArrearBLL();


            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objArrearDTO.SectionId = "";
            }



            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objArrearDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objArrearDTO.UnitId = "";

            }

          
          
            objArrearDTO.Year = txtYear.Text;
          
            objArrearDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            objArrearDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();

            objArrearDTO.HeadOfficeId = strHeadOfficeId;
            objArrearDTO.BranchOfficeId = strBranchOfficeId;
            objArrearDTO.UpdateBy = strEmployeeId;


            string strMsg = objArrearBLL.processArrear(objArrearDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;


        }


        public void searchIncremenRecord()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
                        
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtYear.Text;


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
            dt = objEmployeeBLL.searchIncremenRecord(objEmployeeDTO);

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
        public void searchAdvanceEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;


            if (txtYear.Text != "")
            {
                objEmployeeDTO.Year = txtYear.Text;
            }
            else
            {
                objEmployeeDTO.Year = "";
            }

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.FromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.ToMonthId = "";

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





            dt = objEmployeeBLL.searchAdvanceArrearEntry(objEmployeeDTO);


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

                string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;


                txtAdvanceFee.Focus();

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
                    txtAdvanceFee.Focus();
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
                    txtAdvanceFee.Focus();
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




            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;



            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            // }
            txtAdvanceFee.Focus();
        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
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

        public void clearTextBox()
        {


            txtAdvanceFee.Text = string.Empty;
           


        }


        public void saveArrearAdvance()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtYear.Text;
           
            objSalaryDTO.AdvanceFee = txtAdvanceFee.Text;
            
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

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.FromMonth = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.FromMonth = "";
            }
            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.ToMonth = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.FromMonth = "";
            }

            if (chkYes.Checked == true)
            {
                objSalaryDTO.WithoutArrearYes = "Y";
            }
            else
            {
                objSalaryDTO.WithoutArrearYes = "N";
            }

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.saveArrearAdvance(objSalaryDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            txtAdvanceFee.Focus();
        }
        public void searchArrearAdavanceEntryHO()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            string strUnitId = "";
            string strSectionId = "";
            string strFromMonthId = "";
            string strToMonthId = "";

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


            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                strFromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                strFromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                strToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                strToMonthId = "";

            }



            objSalaryDTO = objSalaryBLL.searchArrearAdavanceEntryHO(txtEmployeeId.Text, txtYear.Text,strFromMonthId, strToMonthId,strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);



            if (objSalaryDTO.AdvanceFee == null || objSalaryDTO.AdvanceFee == "0")
            {

                txtAdvanceFee.Text = "";
            }
            else
            {

                txtAdvanceFee.Text = objSalaryDTO.AdvanceFee;
            }


            if (objSalaryDTO.WithoutArrearYes == "Y")
            {

                chkYes.Checked = true;
            }
            else
            {

                chkYes.Checked = false;
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
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();

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
(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "arrear_report");
                Response.End();
                CrystalReportViewer1.RefreshReport();

            }
            



        }



        #endregion

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlFromMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month Name!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else if (ddlToMonthId.Text == "0")
                {

                    string strMsg = "Please Select To Month Name!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    processArrear();

                }

            }

            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);

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
                else
                {

                    goToNextRecord();
                    searchArrearAdavanceEntryHO();
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
                else
                {

                    goToPreviousRecord();
                    searchArrearAdavanceEntryHO();
                    clearMessage();


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

                searchIncremenRecord();
                clearYellowTextBox();
                clearTextBox();
                gvEmployeeList.SelectedIndex = 0;
                goToNextRecord();
               searchAdvanceEntry();
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

                searchAdvanceEntry();
            }

            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);

            }
        }


        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            searchIncremenRecord();
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;



            //string strMsg = "Row Index: " + strRowId + "\\SL: " + strSLNo + "\\CARD NO: " + strCardNo + "\\nEmployee ID : " + strEmployeeId + "\\nName: " + strEmployeeName +
            //    "\\nDesignation: " + strDesignation;

            // MessageBox(strMsg);

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;


            searchArrearAdavanceEntryHO();
            txtAdvanceFee.Focus();
           

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

       


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }

        #endregion
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            searchAdvanceEntry();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;

            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[8].Text;


            //string strMsg = "Row Index: " + strRowId + "\\SL: " + strSLNo + "\\CARD NO: " + strCardNo + "\\nEmployee ID : " + strEmployeeId + "\\nName: " + strEmployeeName +
            //    "\\nDesignation: " + strDesignation;

            // MessageBox(strMsg);

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchArrearAdavanceEntryHO();

            txtAdvanceFee.Focus();


        }

        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int selectedRowIndex = Convert.ToInt32(e.CommandArgument.ToString());
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        }

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
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

                if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    return;

                }

                //else if (txtAdvanceFee.Text == string.Empty && chkYes.Checked ==false) 
                //{
                //    goToNextRecord();
                //    searchAdvanceEntry();
                //    clearMessage();
                //}
                //else
                //{

                    if (ddlFromMonthId.Text == "0")
                    {
                        string strMsg = "Please select From Month!!!";
                        MessageBox(strMsg);
                        ddlFromMonthId.Focus();
                        return;


                    }
                    if (ddlToMonthId.Text == "0")
                    {
                        string strMsg = "Please select To Month!!!";
                        MessageBox(strMsg);
                        ddlToMonthId.Focus();
                        return;

                    }
                    //else
                    //{
                        saveArrearAdvance();
                        clearTextBox();
                        goToNextRecord();
                        searchAdvanceEntry();
                        searchArrearAdavanceEntryHO();

                    //}
                //}

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

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

        protected void btnArrearSheet_Click(object sender, EventArgs e)
        {
            try
            {


               if (ddlFromMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month Name!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else if (ddlToMonthId.Text == "0")
                {

                    string strMsg = "Please Select To Month Name!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    arrearSheet();

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

        public void arrearSheet()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
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

                if (ddlFromMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FromMonthId = "";

                }

                if (ddlToMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.ToMonthId = "";

                }

                

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSheetHeadOffice.rpt"));
                

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.arrearSheetAll(objReportDTO));


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
        public void arrearRequisition()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
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

                if (ddlFromMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FromMonthId = "";

                }

                if (ddlToMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.ToMonthId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearRequisition.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.arrearRequisition(objReportDTO));


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

        public void arrearSummerySheet()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
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

                if (ddlFromMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FromMonthId = "";

                }

                if (ddlToMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.ToMonthId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSummerySheetHeadOffice.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.arrearSummerySheet(objReportDTO));


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

        public void arrearCashSheet()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
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

                if (ddlFromMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FromMonthId = "";

                }

                if (ddlToMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.ToMonthId = "";

                }



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearCashSheet.rpt"));
                 this.Context.Session["strReportPath"] = strPath;
                 rd.Load(strPath);
                 rd.SetDataSource(objReportBLL.arrearCashSheet(objReportDTO));
                


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
        public void arrearBankSheet()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
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

                if (ddlFromMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FromMonthId = "";

                }

                if (ddlToMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.ToMonthId = "";

                }

                if (strBranchOfficeId == "106" || strBranchOfficeId == "109")
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearBankSheetVerl.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearBankSheetVerl(objReportDTO));

                }
                else
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearBankSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.arrearBankSheet(objReportDTO));
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
        protected void btnArrearSlip_Click(object sender, EventArgs e)
        {
            try
            {

               if (ddlFromMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month Name!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else if (ddlToMonthId.Text == "0")
                {

                    string strMsg = "Please Select To Month Name!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {

                    processArrearSummery();
                    processArrearSummeryUpdate();
                    arrearSlip();


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

        public void arrearSlip()
        {
            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.Year = txtYear.Text;
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

                if (ddlFromMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.FromMonthId = "";

                }
                if (ddlToMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.ToMonthId = "";

                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSlipAll.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.arrearSlipAll(objReportDTO));


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

        protected void btnArrearRequisition_Click(object sender, EventArgs e)
        {
            try
            {


                if (ddlFromMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month Name!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else if (ddlToMonthId.Text == "0")
                {

                    string strMsg = "Please Select To Month Name!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    processArrearSummery();
                    processArrearRequsition();
                    arrearRequisition();

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

        public void processArrearRequsition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;
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

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ToMonthId = "";

            }



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processArrearRequsition(objReportDTO);
            MessageBox(strMsg);




        }


        public void selectArrearBank()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;
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

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ToMonthId = "";

            }



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.selectArrearBank(objReportDTO);
            //MessageBox(strMsg);




        }

        public void processArrearSummery()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;
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

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ToMonthId = "";

            }



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processArrearSummery(objReportDTO);
            //MessageBox(strMsg);




        }
        public void processArrearCash()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;
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

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ToMonthId = "";

            }



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processArrearCash(objReportDTO);
            //MessageBox(strMsg);




        }
        public void processArrearSummeryUpdate()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.Year = txtYear.Text;
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

            if (ddlFromMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.FromMonthId = ddlFromMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.FromMonthId = "";

            }

            if (ddlToMonthId.SelectedValue.ToString() != " ")
            {
                objReportDTO.ToMonthId = ddlToMonthId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.ToMonthId = "";

            }



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processArrearSummeryUpdate(objReportDTO);
            //MessageBox(strMsg);




        }


        protected void btnSummerySheet_Click(object sender, EventArgs e)
        {
            try
            {


                if (ddlFromMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month Name!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else if (ddlToMonthId.Text == "0")
                {

                    string strMsg = "Please Select To Month Name!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }

                 if (txtYear.Text == " ")
                {

                    string strMsg = "Please Enter Year!!!";
                    txtYear.Focus();
                    MessageBox(strMsg);
                    return;

                }

                else
                {
                    processArrearSummery();
                    processArrearSummeryUpdate();
                    arrearSummerySheet();

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

        protected void btnBank_Click(object sender, EventArgs e)
        {
            try
            {


                if (ddlFromMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month Name!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else if (ddlToMonthId.Text == "0")
                {

                    string strMsg = "Please Select To Month Name!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }

                if (txtYear.Text == " ")
                {

                    string strMsg = "Please Enter Year!!!";
                    txtYear.Focus();
                    MessageBox(strMsg);
                    return;

                }

                else
                {
                    processArrearSummery();
                    processArrearSummeryUpdate();
                    selectArrearBank();
                    arrearBankSheet();

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

        protected void btnCash_Click(object sender, EventArgs e)
        {
            try
            {


                if (ddlFromMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month Name!!!";
                    ddlFromMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }
                else if (ddlToMonthId.Text == "0")
                {

                    string strMsg = "Please Select To Month Name!!!";
                    ddlToMonthId.Focus();
                    MessageBox(strMsg);
                    return;

                }

                if (txtYear.Text == " ")
                {

                    string strMsg = "Please Enter Year!!!";
                    txtYear.Focus();
                    MessageBox(strMsg);
                    return;

                }

                else
                {
                    processArrearSummery();
                    processArrearCash();
                    arrearCashSheet();

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