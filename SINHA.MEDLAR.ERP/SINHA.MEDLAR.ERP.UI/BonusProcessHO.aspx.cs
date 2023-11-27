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
    public partial class BonusProcessHO : System.Web.UI.Page
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
                getEidTypeId();
                GetAllBank();
            }
            if (IsPostBack)
            {

                loadSesscion();

            }

            GridView1.Columns[5].Visible = false;

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


        }

        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
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

            txtYear.Text = objLookUpDTO.Year;
     

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

        public void getEidTypeId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEidTypeId.DataSource = objLookUpBLL.getEidTypeId();

            ddlEidTypeId.DataTextField = "EID_NAME";
            ddlEidTypeId.DataValueField = "EID_TYPE_ID";

            ddlEidTypeId.DataBind();
            if (ddlEidTypeId.Items.Count > 0)
            {

                ddlEidTypeId.SelectedIndex = 0;
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
            else if (chkExcel.Checked == true)
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
            else
            {

                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                formatType = ExportFormatType.PortableDocFormat;
                MemoryStream oStream;
                Response.Clear();
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                oStream = (MemoryStream)rd.ExportToStream(formatType);
                Response.ContentType = "application/Pdf";
                oStream.Seek(0, SeekOrigin.Begin);
                Response.BinaryWrite(oStream.ToArray());
                //Response.End();
                oStream.Flush();
                oStream.Close();
                oStream.Dispose();
                CrystalReportViewer1.RefreshReport();

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
        
        public void GetAllBank()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBank.DataSource = objLookUpBLL.GetAllBank();

            ddlBank.DataTextField = "BANK_NAME";
            ddlBank.DataValueField = "BANK_ID";

            ddlBank.DataBind();
            if (ddlBank.Items.Count > 0)
            {
                ddlBank.SelectedIndex = 0;
            }
        }


        protected void btnProcess_Click(object sender, EventArgs e)
        {
           

            if (ddlEidTypeId.Text == " ")
            {

                string strMsg = "Please Select Eid Name!!!";
                MessageBox(strMsg);
                ddlEidTypeId.Focus();
                return;
            }

            else
            {
                saveBonusAddHO();
                processBonusStaff();
                searchStaffBonusEntry();
            }
        }


        public void processBonusStaff()
        {
            
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

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
            objSalaryDTO.Year = txtYear.Text;

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.EidTypeId = "";
            }
            
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.BonusProcessHO(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchStaffBonusEntry();
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






        }


        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


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

            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

        }

        protected void gvEmployeeList_OnRowEditing(object sender, GridViewEditEventArgs e)
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


        public void searchStaffBonusEntry()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
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


            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.EidTypeId = "";

            }


            dt = objEmployeeBLL.searchStaffBonusEntry(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
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
                lblMsgRecord.Text = strMsg;
                //GridView1.Columns[2].Visible = false;
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
                string strEmployeeId = GridView1.SelectedRow.Cells[4].Text;
                string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
                string strDesignation = GridView1.SelectedRow.Cells[3].Text;


                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

                txtBonusAmount.Focus();

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
                    txtBonusAmount.Focus();
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
                    txtBonusAmount.Focus();
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




            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[4].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            // }

            txtBonusAmount.Focus();

        }



        #endregion

      

        public void rptFirstBonusSheet()
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetHO.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptFirstBonusSheet(objReportDTO));


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
        public void rptFirstSheetBonusSlip()
        {


            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusFirstHOSlip.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptFirstSheetBonusSlip(objReportDTO));


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
        public void rptSecondSheetBonusSlip()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSecondHOSlip.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptSecondSheetBonusSlip(objReportDTO));


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
        public void rptSecondBonusSheet()
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetHOMisc.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptSecondBonusSheet(objReportDTO));


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
        public void rptBonusSummerySheet()
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetHOSummery.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.rptBonusSummerySheet(objReportDTO));


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
        protected void btnFirstSheet_Click(object sender, EventArgs e)
        {

            try
            {
               


                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                else if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;

                }


                else
                {

                    rptFirstBonusSheet();

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

        protected void btnSecondSheet_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                else if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;

                }

                else
                {

                    rptSecondBonusSheet();

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

            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;

                }

                else
                {

                    rptBonusSummerySheet();

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

        protected void btnBankSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                else
                {
                    selectBonusBankProcedure();
                    bankBonusSheet();
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

        public void selectBonusBankProcedure()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();
            
            objReportDTO.Year = txtYear.Text;
           
            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.EidTypeId = "";
            }

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

            string strMsg = objReportBLL.selectBonusBankProcedure(objReportDTO);
            MessageBox(strMsg);

        }
        public void bonusCashSheetPro()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();



            objReportDTO.Year = txtYear.Text;


            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.EidTypeId = "";
            }


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

            string strMsg = objReportBLL.bonusCashSheetPro(objReportDTO);
            MessageBox(strMsg);




        }

        public void bankBonusSheet()
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;

                if (strBranchOfficeId == "106" || strBranchOfficeId == "109")
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusBankSheetVERL.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptBankBonusSheet(objReportDTO));

                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetBank.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bankBonusSheet(objReportDTO));

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

        public void GetHOEidBonusBankAdvice()
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }

                if (ddlBank.SelectedValue.ToString() != " ")
                {
                    objReportDTO.BankId = ddlBank.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.BankId = "";
                }

                objReportDTO.Year = txtYear.Text;

                string strPath = string.Empty;

                if (strBranchOfficeId == "106" || strBranchOfficeId == "109")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusBankSheetVERL.rpt"));
                }
                else
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetBank.rpt"));
                }

                this.Context.Session["strReportPath"] = strPath;
                 rd.Load(strPath);
                 rd.SetDataSource(objReportBLL.GetHOEidBonusBankAdvice(objReportDTO));
                    
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


        public void bonusCashSheet()
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";

                }


                objReportDTO.Year = txtYear.Text;

                if (strBranchOfficeId == "106" || strBranchOfficeId == "109")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashSheetVERL.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.rptCashBonusSheet(objReportDTO));
                }
                else
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusCashSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bonusCashSheet(objReportDTO));

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

        protected void btnCashSheet_Click(object sender, EventArgs e)
        {
            try
            {

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;

                }
                else
                {
                    bonusCashSheetPro();
                    bonusCashSheet();

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

        protected void btnBonusFirstSheetSlip_Click(object sender, EventArgs e)
        {
            try
            {

               if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
               else if (txtYear.Text == "")
               {
                   string strMsg = "Please Enter Eid Year!!!";
                   MessageBox(strMsg);
                   txtYear.Focus();
                   return;

               }

                else
                {

                    rptFirstSheetBonusSlip();

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

        protected void btnBonusSecondSheetSlip_Click(object sender, EventArgs e)
        {

            try
            {
               if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
               else if (txtYear.Text == "")
               {
                   string strMsg = "Please Enter Eid Year!!!";
                   MessageBox(strMsg);
                   txtYear.Focus();
                   return;

               }

                else
                {

                    rptSecondSheetBonusSlip();

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {




                if (GridView1.Rows.Count == 0)
                {
                    string strMsg = "Please click Search Button!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    btnProcess.Focus();

                    return;
                }
                else if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    clearMessage();
                    return;

                }



                else if (txtBonusAmount.Text == "" || txtBonusAmount.Text == string.Empty)
                {
                    saveBonusHO();
                    goToNextRecord();
                    clearMessage();
                    searchBonusEntryHO();

                }



                else
                {

                    saveBonusHO();
                    
                    searchHORecordforBonus();
                    goToNextRecord();
                    searchBonusEntryHO();
                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        public void saveBonusHO()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

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
            objSalaryDTO.Year = txtYear.Text;

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {

                objSalaryDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();

            }
            else
            {
                objSalaryDTO.EidTypeId = "";

            }



            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Bonus = txtBonusAmount.Text;
            objSalaryDTO.Year = txtYear.Text;


            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.saveBonusHO(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridView1.Rows.Count == 0)
                {
                    string strMsg = "Please click searh Button!!!";
                    MessageBox(strMsg);
                    btnProcess.Focus();
                    return;
                }
                else if (txtEmployeeId.Text == "")
                {
                    string strMsg = "Please Click in the Gridview!!!";
                    MessageBox(strMsg);

                    return;

                }

              

                else
                {

                    goToPreviousRecord();
                    searchBonusEntryHO();
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

                    searchHORecordforBonus();
                    clearYellowTextBox();
                    GridView1.SelectedIndex = 0;
                    goToNextRecord();
                    searchBonusEntryHO();
                    searchStaffBonusEntry();
                
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

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
                    btnProcess.Focus();
                    return;
                }
                else if (txtEmployeeId.Text == "")
                {
                    string strMsg = "Please Click in the Gridview!!!";
                    MessageBox(strMsg);

                    return;

                }

              

                else
                {

                    goToNextRecord();
                    searchBonusEntryHO();
                    clearMessage();


                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error " + ex.Message);

            }
        }

        public void searchBonusEntryHO()
        {


            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            string strUnitId = "";
            string strSectionId = "";
            string strEidTypeId = "";

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

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                strEidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                strEidTypeId = "";

            }







            objSalaryDTO = objSalaryBLL.searchBonusEntryHO(txtEmployeeId.Text, strEidTypeId, txtYear.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.Bonus == null || objSalaryDTO.Bonus == "0")
            {

                txtBonusAmount.Text = "0";

            }
            else
            {

                txtBonusAmount.Text = objSalaryDTO.Bonus;

            }

            if (objSalaryDTO.SecondBonus == null || objSalaryDTO.SecondBonus == "0")
            {

                txtBonusAmountSecond.Text = "0";

            }
            else
            {

                txtBonusAmountSecond.Text = objSalaryDTO.SecondBonus;

            }

            txtBonusAmount.Focus();






        }
        public void searchHORecordforBonus()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();



            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;

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





            dt = objEmployeeBLL.searchHORecordforBonus(objEmployeeDTO);


            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //
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


        #region
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {



            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[4].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchBonusEntryHO();

            txtBonusAmount.Focus();


        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
          

        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {



            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



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


        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }


        #endregion

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (GridView1.Rows.Count == 0)
            {
                string strMsg = "Please click Search Button!!!";
                MessageBox(strMsg);
                clearMessage();
                btnProcess.Focus();

                return;
            }

           

            else if (ddlEidTypeId.Text == " ")
            {

                string strMsg = "Please Select Eid Name!!!";
                MessageBox(strMsg);
                ddlEidTypeId.Focus();
                return;
            }

            else
            {

                deleteBonusAddHO();
                saveBonusAddHO();

            }
        }


        public void saveBonusAddHO()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            //foreach (GridViewRow row in GridView1.Rows)
            //{

            //    if (row.RowType == DataControlRowType.DataRow)
            //    {

            //        Label strId = (Label)row.FindControl("lblEmployeeId");


            //        objSalaryDTO.EmployeeId = strId.Text;

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
                    objSalaryDTO.Year = txtYear.Text;

                    if (ddlEidTypeId.SelectedValue.ToString() != " ")
                    {
                        objSalaryDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                    }
                    else
                    {
                        objSalaryDTO.EidTypeId = "";
                    }
                    
                    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    objSalaryDTO.BranchOfficeId = strBranchOfficeId;
                    objSalaryDTO.UpdateBy = strEmployeeId;

                string strMsg = objSalaryBLL.saveBonusAddHO(objSalaryDTO);
            //        //MessageBox(strMsg);
            //        //lblMsg.Text = strMsg;


            //    }


            //}


        }

        public void deleteBonusAddHO()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;

            objReportDTO.Year = txtYear.Text;



            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.SectionId = "";
            }

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {

                objReportDTO.EidTypeId = "";
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
            string strMsg = objReportBLL.deleteBonusAddHO(objReportDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        protected void btnBankAdvice_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEidTypeId.Text == " ")
                {
                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == "")
                {
                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                else
                {
                    selectBonusBankProcedure();
                    GetHOEidBonusBankAdvice();
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