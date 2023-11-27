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
using System.Collections;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class ArrearEntryWorker : System.Web.UI.Page
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
        string strReport = "";
        ReportDocument rd = new ReportDocument();

        string strDefaultName = "Report";
        ExportFormatType formatType = ExportFormatType.NoFormat;
        bool status;

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

                getFromMonthId();
                getSectionId();
                clearMsg();
                getOfficeName();
                getMonthYearForTax();
                btnSearch.Focus();


            }

            if (IsPostBack)
            {

                loadSesscion();

            }
            GridView1.Columns[7].Visible = false;


        }


        #region "Function"

        public void getFromMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMonthId.DataSource = objLookUpBLL.getFromMonthId();

            ddlMonthId.DataTextField = "MONTH_NAME";
            ddlMonthId.DataValueField = "MONTH_ID";

            ddlMonthId.DataBind();
            if (ddlMonthId.Items.Count > 0)
            {

                ddlMonthId.SelectedIndex = 0;
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


            txtOverTimeHour.Text = string.Empty;
            txtWorkingDay.Text = string.Empty;
            txtIncrementAmount.Text = string.Empty;
            txtManualIncrementAmount.Text = string.Empty;
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

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            //txtYear.Text = objLookUpDTO.Year;
           

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


      


        public void searchWorkerRecordforArrear()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtYear.Text;



            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.Month = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.Month = "";

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





            dt = objEmployeeBLL.searchWorkerRecordforArrear(objEmployeeDTO);


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
                addWorkerArrear();

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
        public void searchWorkerArrearRecordEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.Year = txtYear.Text;



            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.Month = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.Month = "";

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





            dt = objEmployeeBLL.searchWorkerArrearEntry(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView2.DataSource = dt;
                GridView2.DataBind();

                int count = ((DataTable)GridView2.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

               

            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView2.DataSource = dt;
                GridView2.DataBind();
                int totalcolums = GridView2.Rows[0].Cells.Count;
                GridView2.Rows[0].Cells.Clear();
                GridView2.Rows[0].Cells.Add(new TableCell());
                GridView2.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView2.Rows[0].Cells[0].Text = "NO RECORD FOUND";

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
            l = GridView1.SelectedRow.RowIndex;
            if (l != 0)
            {

                int strId = GridView1.SelectedRow.RowIndex + 1;
                int strRowCount = strId;
                int intCount = GridView1.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Next Record!!!";
                    MessageBox(strMsg);
                    return;

                }
                else
                {
                    GridView1.SelectedIndex += 1;
                    result = GridView1.SelectedRow.RowIndex + k;

                }

            }
            if (l == 0)
            {

                int intCount = GridView1.Rows.Count;
                int intCountRow = GridView1.Rows.Count;
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
                        GridView1.SelectedIndex = 0;
                        result = GridView1.SelectedRow.RowIndex + k;
                        txtSLNew.Text = "1";

                    }
                    else
                    {

                        int intC = GridView1.Rows.Count;
                        int intCo = GridView1.Rows.Count;
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

                            GridView1.SelectedIndex += 1;
                            result = GridView1.SelectedRow.RowIndex + k;

                        }

                    }


                }

            }



            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            if (strSLNo == "NO RECORD FOUND")
            {
                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                return;
            }
            else
            {







                string strCardNo = GridView1.SelectedRow.Cells[1].Text;
                string strEmployeeId = GridView1.SelectedRow.Cells[6].Text;
                string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
                string strDesignation = GridView1.SelectedRow.Cells[3].Text;
                string strIncrementAmount = GridView1.SelectedRow.Cells[5].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
.Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
.Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
.Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
.Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
.Replace("&#191;", "¿");




                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

                txtIncrementAmount.Text = strIncrementAmount;




                txtManualIncrementAmount.Focus();

            }
        }

        public void goToPreviousRecord()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            //gvIncrementList.SelectedIndex = 1;


            int l;
            l = GridView1.SelectedRow.RowIndex;
            if (l != 0)
            {
                int strId = GridView1.SelectedRow.RowIndex - 1;
                int strRowCount = strId;
                int intCount = GridView1.Rows.Count;
                if (intCount == strRowCount)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtManualIncrementAmount.Focus();
                    return;

                }
                else
                {
                    GridView1.SelectedIndex -= 1;
                    result = GridView1.SelectedRow.RowIndex - k;
                }
            }
            if (l == 0)
            {

                int intCountRow = GridView1.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtManualIncrementAmount.Focus();
                    return;

                }

                else
                {

                    l = 1;
                    GridView1.SelectedIndex = l;
                    result = GridView1.SelectedRow.RowIndex - k;

                }

            }

            int strRowId = GridView1.SelectedRow.RowIndex + 1;




            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[6].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;

            string strIncrementAmount = GridView1.SelectedRow.Cells[5].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
.Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
.Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
.Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
.Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
.Replace("&#191;", "¿");






            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            txtIncrementAmount.Text = strIncrementAmount;



            txtManualIncrementAmount.Focus();
        }




        public void addWorkerArrear()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";

            string strCount = GridView1.Rows.Count.ToString();

            foreach (GridViewRow row in GridView1.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                    objSalaryDTO.EmployeeId = strId;


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


                    objSalaryDTO.Year = txtYear.Text;
                    if (ddlMonthId.SelectedValue.ToString() != " ")
                    {
                        objSalaryDTO.Month = ddlMonthId.SelectedValue.ToString();
                    }
                    else
                    {
                        objSalaryDTO.Month = "";

                    }


                    objSalaryDTO.UpdateBy = strEmployeeId;
                    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    objSalaryDTO.BranchOfficeId = strBranchOfficeId;


                    strMsg = objSalaryBLL.addWorkerArrear(objSalaryDTO);


                }


            }



        }
        public void ProcessWorkerArrear()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";



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


            objSalaryDTO.Year = txtYear.Text;
            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.Month = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.Month = "";

            }


            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;


            strMsg = objSalaryBLL.ProcessWorkerArrear(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void ProcessWorkerArrearRequisition()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";



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


            objSalaryDTO.Year = txtYear.Text;
            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.Month = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.Month = "";

            }


            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;


            strMsg = objSalaryBLL.ProcessWorkerArrearRequisition(objSalaryDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;

        }

        public void rptArrearSheetWorker()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;


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


                if (ddlMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.Month = ddlMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.Month = "";

                }


                objReportDTO.Year = txtYear.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearSheetWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptArrearSheetWorker(objReportDTO));


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
        public void rptArrearSheetWorkerRequisition()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();


                ProcessWorkerArrearRequisition();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;


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


                if (ddlMonthId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.Month = ddlMonthId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.Month = "";

                }


                objReportDTO.Year = txtYear.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptArrearRequisitionWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptArrearSheetWorkerRequisition(objReportDTO));


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

                else if (ddlMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month!!!";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }



                else if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    searchWorkerRecordforArrear();
                    clearYellowTextBox();
                    clearTextBox();
                    GridView1.SelectedIndex = 0;
                    goToNextRecord();
                    searchWorkerArrearRecordEntry();
                    searchWorkerArrearEntry();
                    searchWorkerArrearSalary();
                }


            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }

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
            string strEmployeeId = GridView1.SelectedRow.Cells[6].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            string strIncrementAmount = GridView1.SelectedRow.Cells[5].Text.Replace("&#168;", "¨").Replace("&#182;", "¶")
           .Replace("&#214;", "Ö").Replace("&#221;", "Ý").Replace("&#247;", "÷").Replace("&#169;", "©").Replace("&#177;", "±")
           .Replace("&#172;", "¬").Replace("&#170;", "ª").Replace("&#243;", "ó").Replace("&#164;", "¤").Replace("&#248;", "ø")
           .Replace("&#250;", "ú").Replace("&#219;", "Û").Replace("&#194;", "Â").Replace("&#196;", "Ä").Replace("&#175;", "¯")
           .Replace("&amp;", "&").Replace("&#236;", "ì").Replace("&#173;", "­­­­­­­").Replace("&#183;", "­­­­­­­·").Replace("&#191;&#191;&#191;&#191;&#191;&#191;&#191;&#191;", "­­­­­­­¿¿¿¿¿¿¿¿")
           .Replace("&#191;", "¿");
           



           

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtIncrementAmount.Text = strIncrementAmount;


            searchWorkerArrearEntry();
            searchWorkerArrearSalary();
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



        protected void btnArrearProcessWroker_Click(object sender, EventArgs e)
        {
            ProcessWorkerArrear();
        }

        protected void btnArrearSheetWorker_Click(object sender, EventArgs e)
        {
            rptArrearSheetWorker();
        }

        protected void btnRequisition_Click(object sender, EventArgs e)
        {
            rptArrearSheetWorkerRequisition();
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            if (ddlMonthId.Text == "0")
            {

                string strMsg = "Please Select From Month!!!";
                MessageBox(strMsg);
                ddlMonthId.Focus();
                return;
            }



            else if (txtYear.Text == "")
            {

                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtYear.Focus();
                return;
            }
            else
            {

                searchWorkerArrearRecordEntry();

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

        protected void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.Rows.Count == 0)
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
                    clearMessage();
                    searchWorkerArrearEntry();
                    searchWorkerArrearSalary();
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
                if (GridView1.Rows.Count == 0)
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
                    clearMessage();
                    searchWorkerArrearEntry();
                    searchWorkerArrearSalary();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }



        public void searchWorkerArrearSalary()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            string strUnitId = "";
            string strSectionId = "";
            string strMonth = "";


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


            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                strMonth = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                strMonth = "";

            }


            objSalaryDTO = objSalaryBLL.searchWorkerArrearSalary(txtEmployeeId.Text, txtYear.Text, strMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);



            if (objSalaryDTO.OverTimeHour == null || objSalaryDTO.OverTimeHour == "0")
            {

                txtOverTimeHour.Text = "";
            }
            else
            {

                txtOverTimeHour.Text = objSalaryDTO.OverTimeHour;
            }

            if (objSalaryDTO.WorkingDay == null || objSalaryDTO.WorkingDay == "0")
            {

                txtWorkingDay.Text = "";
            }
            else
            {

                txtWorkingDay.Text = objSalaryDTO.WorkingDay;
            }





        }

        public void searchWorkerArrearEntry()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            string strUnitId = "";
            string strSectionId = "";
            string strMonth = "";


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


            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                strMonth = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                strMonth = "";

            }


            objSalaryDTO = objSalaryBLL.searchWorkerArrearEntry(txtEmployeeId.Text, txtYear.Text, strMonth, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

           

            if (objSalaryDTO.ManualIncrement == null || objSalaryDTO.ManualIncrement == "0")
            {

                txtManualIncrementAmount.Text = "";
            }
            else
            {

                txtManualIncrementAmount.Text = objSalaryDTO.ManualIncrement;
            }




        }

        public void saveArrearWorkerEntry()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtYear.Text;
           

            objSalaryDTO.ManualIncrement = txtManualIncrementAmount.Text;


            if (ddlMonthId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.Month = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.Month = "";

            }

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


            string strMsg = objSalaryBLL.saveArrearWorkerEntry(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

            if (strMsg == "PLEASE CHECK INCREMENT YEAR!!!" || strMsg == "PLEASE CHECK INCREMENT MONTH!!!" || strMsg == "PLEASE ADD FIRST!!!")
            {
                MessageBox(strMsg);
                return;

            }



        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {


                if (GridView1.Rows.Count == 0)
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

                else if (ddlMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month!!!";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }



                else if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }



                else if (txtManualIncrementAmount.Text == "" || txtManualIncrementAmount.Text == string.Empty)
                {
                    goToNextRecord();
                    searchWorkerArrearEntry();
                    clearMessage();
                }



                else
                {
                    saveArrearWorkerEntry();
                    searchWorkerArrearRecordEntry();
                    goToNextRecord();
                    searchWorkerArrearEntry();
                    searchWorkerArrearSalary();

                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }


        #region "Grid View Functionality2"
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;

        }

        protected void GridView2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GridView2.SelectedRow.RowIndex + 1;
            string strSLNo = GridView2.SelectedRow.Cells[0].Text;
            string strCardNo = GridView2.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView2.SelectedRow.Cells[6].Text;
            string strEmployeeName = GridView2.SelectedRow.Cells[2].Text;
            string strDesignation = GridView2.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;


            searchWorkerArrearEntry();
            searchWorkerArrearSalary();

        }

        protected void GridView2_RowDataBound(GridViewRowEventArgs e)
        {
            int indexOfColumn = 7;

            if (e.Row.Cells.Count > indexOfColumn)
            {
                e.Row.Cells[indexOfColumn].Visible = false;
            }

            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }


        protected void GridView2_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {


        }


        protected void GridView2_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView2, "Select$" + e.Row.RowIndex);
            }
        }

        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
              if (GridView1.Rows.Count == 0)
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

                else if (ddlMonthId.Text == "0")
                {

                    string strMsg = "Please Select From Month!!!";
                    MessageBox(strMsg);
                    ddlMonthId.Focus();
                    return;
                }



                else if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }



             


              else
              {

                  

              }
        }

    }
}