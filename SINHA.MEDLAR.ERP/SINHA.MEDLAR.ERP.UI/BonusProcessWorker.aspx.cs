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
    public partial class BonusProcessWorker : System.Web.UI.Page
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
                ButtonPermission();

            }
            if (IsPostBack)
            {

                loadSesscion();

            }


            gvEmployeeList.Columns[7].Visible = false;
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


        public void ButtonPermission()
        {


            if (strBranchOfficeId == "110")
            {
                btnEidBonusSheetBpProcess.Visible = false;
                btnEidBonusSheetBp.Visible = false;
                btnEidBonusRequisitionSheetBp.Visible = false;

            }
            else
            {
                btnEidBonusSheetBpProcess.Visible = false;
                btnEidBonusSheetBp.Visible = false;
                btnEidBonusRequisitionSheetBp.Visible = false;

            }


        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
            
        public void reportMaster(string reportName)
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
                //new:27.04.2021
                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                rd.ExportToHttpResponse(ExportFormatType.ExcelRecord, Response, true, reportName);

                Response.ClearContent();
                Response.ClearHeaders();
                Response.Flush();
                Response.End();
                Response.Close();
                rd.Close();
                rd.Dispose();
                
                //old and org 27.04.2021
                //rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
                //Response.End();
                //CrystalReportViewer1.RefreshReport();
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
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[6].Text;
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


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
                    txtBonusAmount.Focus();
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
                    txtBonusAmount.Focus();
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
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            txtBonusAmount.Focus();
        }


        public void searchWorkerRecordforBonus()
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





            dt = objEmployeeBLL.searchWorkerRecordforBonus(objEmployeeDTO);


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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
           if (ddlEidTypeId.Text == " ")
            {
                string strMsg = "Please Select Eid Name!!!";
                MessageBox(strMsg);
                ddlEidTypeId.Focus();
                return;
            }

           if (txtYear.Text == " ")
           {

               string strMsg = "Please Enter Eid Year!!!";
               MessageBox(strMsg);
               txtYear.Focus();
               return;
           }
               //commented on 10.07.2021
                //saveBonusAddWorker();
                processBonusWorker();
            

            if (ddlUnitGroupId.SelectedValue == "" && ddlUnitId.SelectedValue != " " && ddlSectionId.SelectedValue != " ")
            {
                searchWorkerBonusEntry();
            }
            //commented on 10.07.2021
            //searchBonusEntryWorker();

        }

        public void searchBonusEntryWorker()
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







            objSalaryDTO = objSalaryBLL.searchBonusEntryWorker(txtEmployeeId.Text, strEidTypeId, txtYear.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.Bonus == null || objSalaryDTO.Bonus == "0")
            {

                txtBonusAmount.Text = "0";

            }
            else
            {

                txtBonusAmount.Text = objSalaryDTO.Bonus;

            }

            txtBonusAmount.Focus();






        }


        public void processBonusWorkerTest()
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

            string strMsg = objSalaryBLL.processBonusWorkerTest(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void processBonusWorker()
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

            if (ddlUnitGroupId.SelectedValue.ToString() != "")
            {
                objSalaryDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            }
            else
            {
                objSalaryDTO.UnitGroupId = "";
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

            string strMsg = objSalaryBLL.BonusProcessWorker(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void saveBonusWorker()
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

            string strMsg = objSalaryBLL.saveBonusWorker(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            searchWorkerBonusEntry();
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
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[6].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchBonusEntryWorker();

            txtBonusAmount.Focus();




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


        public void searchWorkerBonusEntry()
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


            dt = objEmployeeBLL.searchWorkerBonusEntry(objEmployeeDTO);


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

        #endregion

        //protected void btnSheet_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (ddlUnitGroupId.SelectedItem.Value == "")
        //        {
        //            if (ddlUnitId.Text == " ")
        //            {
        //                string strMsg = "Please Select Unit Name!!!";
        //                MessageBox(strMsg);
        //                ddlUnitId.Focus();
        //                return;
        //            }
        //            if (ddlSectionId.Text == " ")
        //            {
        //                string strMsg = "Please Select Section Name!!!";
        //                MessageBox(strMsg);
        //                ddlUnitId.Focus();
        //                return;
        //            }
        //        }
        //        else
        //        {
        //            if (ddlUnitId.Text != " ")
        //            {
        //                if (ddlSectionId.Text == " ")
        //                {
        //                    string strMsg = "Please Select Section Name!!!";
        //                    MessageBox(strMsg);
        //                    ddlUnitId.Focus();
        //                    return;
        //                }
        //            }
        //        }
        //        //if (ddlEmployeeTypeId.SelectedItem.Value == "")
        //        //{
        //        //    string strMsg = "Please Select Employee Type!!!";
        //        //    MessageBox(strMsg);
        //        //    ddlEmployeeTypeId.Focus();
        //        //    return;
        //        //}

        //        if (ddlEidTypeId.Text == " ")
        //        {

        //            string strMsg = "Please Select Eid Name!!!";
        //            MessageBox(strMsg);
        //            ddlEidTypeId.Focus();
        //            return;
        //        }
        //        if (txtYear.Text == "")
        //        {

        //            string strMsg = "Please Enter Eid Year!!!";
        //            MessageBox(strMsg);
        //            txtYear.Focus();
        //            return;
        //        }
        //        bonusSheetWorkerByUnitGroup();              
        //    }
        //    catch (Exception ex)
        //    {

        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //}

        public void bonusSheetWorker()
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

                if(strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bonusSheetWorker(objReportDTO));

                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorker.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.bonusSheetWorker(objReportDTO));

                }



                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-sheet");

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

        public void GetBkashSheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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

                //new code
                objReportDTO.payment_mode = 2;
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));


                //old code
                // if(txtYear.Text == "2020" && objReportDTO.EidTypeId == "1")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkash.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }
                //else if (strBranchOfficeId == "110")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBP.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                // else
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorker.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-bkash-sheet");

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


        //cash
        public void GetCashSheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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

                //new code
                objReportDTO.payment_mode = 3;
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));


                //old code
                // if(txtYear.Text == "2020" && objReportDTO.EidTypeId == "1")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkash.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }
                //else if (strBranchOfficeId == "110")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBP.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                // else
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorker.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-cash-sheet");

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
        
        public void bonusSheetWorkerTest()
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


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetTest.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusSheetWorkerTest(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-sheet");

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
        public void bonusSlipWorker()
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


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusPaySlipWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.bonusSlipWorker(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-slip");

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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {




                if (gvEmployeeList.Rows.Count == 0)
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
                    saveBonusWorker();
                    goToNextRecord();
                    clearMessage();
                    searchBonusEntryWorker();
                   
                }



                else
                {

                    saveBonusWorker();
                    //processBonusWorker();
                    searchWorkerBonusEntry();
                    goToNextRecord();
                    searchBonusEntryWorker();
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
                    btnProcess.Focus();
                    return;
                }
                else if (txtEmployeeId.Text == "")
                {
                    string strMsg = "Please Click in the Gridview!!!";
                    MessageBox(strMsg);

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
                    searchBonusEntryWorker();
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
                    string strMsg = "Please click Process Button!!!";
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
                    searchBonusEntryWorker();
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
                    searchWorkerRecordforBonus();
                    clearYellowTextBox();
                    gvEmployeeList.SelectedIndex = 0;
                    goToNextRecord();
                    searchBonusEntryWorker();
                    searchWorkerBonusEntry();      
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnEidBonusRequisition_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                else
                {
                    eidBonusRequisitionWorker();
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

        public void bonusRequisitionWorkerTest()
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
            string strMsg = objReportBLL.bonusRequisitionWorkerTest(objReportDTO);




        }
        public void bonusRequisitionWorker()
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
            string strMsg = objReportBLL.bonusRequisitionWorker(objReportDTO);
                       

        }
        public void eidBonusRequisitionWorker()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                bonusRequisitionWorker();

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



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequisitionWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.eidBonusRequisitionWorker(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster("bonus-requisition");

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
        public void eidBonusRequisitionWorkerTest()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                bonusRequisitionWorkerTest();

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



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequisitionWorkerTest.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.eidBonusRequisitionWorkerTest(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster("bonus-requisition");

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

        public void eidBonusRequisitionSummery()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusRequisitionSummery.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.eidBonusRequisitionSummery(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-req-summary");

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

        #region "Grid View Functionality"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            searchBonusEntryWorker();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {


            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[9].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchBonusEntryWorker();
            txtBonusAmount.Focus();



        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
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

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {

        }


        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {



            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");



        }



        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }




        #endregion



        protected void btnDelete_Click(object sender, EventArgs e)
        {

            if (gvEmployeeList.Rows.Count == 0)
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
                gvEmployeeList.Focus();
                return;

            }
            else
            {


                deleteBonusWorker();
                searchWorkerBonusEntry();
                goToNextRecord();
                searchBonusEntryWorker();
            }

        }
        public void deleteBonusWorker()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmployeeId.Text;
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
            string strMsg = objReportBLL.deleteBonusWorker(objReportDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void deleteBonusAddWorker()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.Year = txtYear.Text;

            //if (ddlUnitId.SelectedValue.ToString() != " ")
            //{
            //    objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objReportDTO.UnitId = "";
            //}

            //if (ddlSectionId.SelectedValue.ToString() != " ")
            //{
            //    objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objReportDTO.SectionId = "";
            //}

            if (ddlEidTypeId.SelectedValue.ToString() != " ")
            {
                objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
            }
            else
            {
                objReportDTO.EidTypeId = "";
            }
                              
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.deleteBonusAddWorker(objReportDTO);
            lblMsg.Text = strMsg;

        }
        protected void btnSlip_Click(object sender, EventArgs e)
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

                else if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }

                else
                {

                    bonusSlipWorker();

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

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtYear.Text == string.Empty)
            {
                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtYear.Focus();
                return;
            }

            if (ddlEidTypeId.Text == " ")
            {
                string strMsg = "Please Select Eid Name!!!";
                MessageBox(strMsg);
                ddlEidTypeId.Focus();
                return;
            }
            
            saveBonusAddWorker();
                       
        }

        public void saveBonusAddWorker()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            
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

            //if (ddlUnitGroupId.SelectedValue.ToString() != "")
            //{
            //    objSalaryDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objSalaryDTO.UnitGroupId = "";
            //}

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

            string strMsg = objSalaryBLL.saveBonusAddWorker(objSalaryDTO);
                    
        }

        protected void btnEidBonusSheetBp_Click(object sender, EventArgs e)
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

               
              else if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == " ")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }


                else
                {
                    processBonusWorkerTest();
                    bonusSheetWorkerTest();

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

        protected void btnEidBonusSheetBpProcess_Click(object sender, EventArgs e)
        {
          

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                else if (txtYear.Text == " ")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }


                else
                {
                    processBonusWorkerTest();
                  

                }
            }

        protected void btnEidBonusRequisitionSheetBp_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;

                }

                else
                {
                    eidBonusRequisitionWorkerTest();


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

        protected void btnEidBonusRequisitionSummery_Click(object sender, EventArgs e)
        {
            eidBonusRequisitionSummery();
        }

        protected void btnEidBonusCompareRequisition_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                else
                {
                    EidBonusWorkerStaffRequisitionSummery();
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
        public void EidBonusWorkerStaffRequisitionSummery()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }

                objReportDTO.Year = txtYear.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptCompareStaffWorkerEidBonusSummary.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.EidBonusWorkerStaffRequisitionSummery(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster("bonus-staff-req_sum");

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

        protected void btnBkashSheet_Click(object sender, EventArgs e)
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
                }
                
                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                GetBkashSheet();
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
                }
               
                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                GetCashSheet();
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

        protected void btnBkashWorkerBonusSheet_Click(object sender, EventArgs e)
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

                GetBonusSheetWorkerAsBKashWallet();

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
        public void GetBonusSheetWorkerAsBKashWallet()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.EmployeeTypeId = "2";
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetBkashWallet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetBonusSheetStaffWorkerAsBKashWallet(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-bank-wallet");

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

        protected void btnBkashTemplateAll_Click(object sender, EventArgs e)
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
                GetBonusSheetStaffWorkerAsBKashWalletAll();

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
        public void GetBonusSheetStaffWorkerAsBKashWalletAll()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.EmployeeTypeId = "";
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetBkashWallet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetBonusSheetStaffWorkerAsBKashWallet(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-bank-wallet-all");

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

        public void GetBkashWalletTemplatePartAll()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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

                if (ddlEidTypeId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.EidTypeId = "";
                }

                objReportDTO.Year = txtYear.Text;
                objReportDTO.EmployeeTypeId = "";
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetBkashWallet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetBonusBKashWalletTemplatePartAll(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-bank-wallet-all");

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

        protected void btnEidBonusBKashReq_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    EidBonusWorkerBkashReq();
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
        public void EidBonusWorkerBkashReq()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "2";

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusBKashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusBKashReq(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster("bonus-bkash-req");

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

        protected void btnEidBonusCashReq_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    EidBonusWorkerCashReq();
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
        public void EidBonusWorkerCashReq()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "2";

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusCashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusWorkerCashReq(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster("bonus-cash-req");

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

        protected void btnBkashSheetParcial_Click(object sender, EventArgs e)
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
                }

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please Select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                GetEidBonusParcialBkashSheetWorker();
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
        public void GetEidBonusParcialBkashSheetWorker()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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

                //new code
                objReportDTO.payment_mode = 2;
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkashPart.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusParcialBkashSheetWorker(objReportDTO));


                //old code
                // if(txtYear.Text == "2020" && objReportDTO.EidTypeId == "1")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkash.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }
                //else if (strBranchOfficeId == "110")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBP.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                // else
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorker.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-bkash-sheet");

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

        protected void btnCashSheetPart_Click(object sender, EventArgs e)
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
                }

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }
                GetCashSheetPart();
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
        public void GetCashSheetPart()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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

                //new code
                objReportDTO.payment_mode = 3;
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerPart.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusParcialBkashSheetWorker(objReportDTO));


                //old code
                // if(txtYear.Text == "2020" && objReportDTO.EidTypeId == "1")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkash.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }
                //else if (strBranchOfficeId == "110")
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBP.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                // else
                // {
                //     objReportDTO.payment_mode = 3;
                //     string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorker.rpt"));
                //     this.Context.Session["strReportPath"] = strPath;
                //     rd.Load(strPath);
                //     rd.SetDataSource(objReportBLL.bonusSheetWorkerByUnitGroup(objReportDTO));
                // }

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("cash-sheet");

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

        protected void btnEidBonusBKashReqParcial_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please Select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }
                else
                {
                    EidBonusWorkerBkashReqPart();
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
        public void EidBonusWorkerBkashReqPart()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "2";
                if (ddlPhaseId.SelectedValue.ToString() != " ")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusBKashReqPart.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.EidBonusWorkerBkashReqPart(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster("bonus-bkash-req");

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

        protected void btnEidBonusCashReqPart_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please Select Phase!";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }

                else
                {
                    EidBonusWorkerCashReqPart();
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
        public void EidBonusWorkerCashReqPart()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.EmployeeTypeId = "2";
                if (ddlPhaseId.SelectedValue.ToString() != "")
                {
                    objReportDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.PhaseId = "";
                }

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusCashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusWorkerCashReqPart(objReportDTO));


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();


                reportMaster("bonus-cash-req");

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

        protected void BtnPartWalletTemplate_Click(object sender, EventArgs e)
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
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (ddlPhaseId.Text == "")
                {

                    string strMsg = "Please select Phase";
                    MessageBox(strMsg);
                    ddlPhaseId.Focus();
                    return;
                }
                GetBkashWalletTemplatePartAll();

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

        protected void btnEidBonusBkashSummary_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    GetEidBonusBkashSummaryByPaymentMode();
                    //GetEidBonusBkashSummarySheet();
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

        public void GetEidBonusBkashSummaryByPaymentMode()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.payment_mode = 2;

                //string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusBKashSummary.rpt"));
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEidBonusSummaryByPaymentMode.rpt"));
                
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusSummaryByPaymentMode(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-bkash-summary");

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
        
        public void GetEidBonusCashSummaryByPaymentMode()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
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
                objReportDTO.payment_mode = 3;

                //string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusBKashSummary.rpt"));
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEidBonusSummaryByPaymentMode.rpt"));

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEidBonusSummaryByPaymentMode(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-cash-sum");

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

        protected void btnMasterSheet_Click(object sender, EventArgs e)
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
                }

                if (ddlEidTypeId.Text == " ")
                {

                    string strMsg = "Please Select Eid Name!!!";
                    MessageBox(strMsg);
                    ddlEidTypeId.Focus();
                    return;
                }
                if (txtYear.Text == "")
                {

                    string strMsg = "Please Enter Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                GetEibBonusMasterSheet();
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
        public void GetEibBonusMasterSheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.EmployeeTypeId = "2";
                objReportDTO.PaymentMode = "";

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEibBonusMasterSheet(objReportDTO));

                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;
                CrystalReportViewer1.DataBind();

                reportMaster("bonus-master-sheet");

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

        protected void btnEidBonusCashSummary_Click(object sender, EventArgs e)
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
                else if (txtYear.Text == " ")
                {
                    string strMsg = "Please Select Eid Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                else
                {
                    GetEidBonusCashSummaryByPaymentMode();
                    //GetEidBonusCashSummarySheet();
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
        //public void GetEidBonusCashSummarySheet()
        //{

        //    try
        //    {
        //        string strDefaultName = "Report";
        //        ExportFormatType formatType = ExportFormatType.NoFormat;

        //        ReportDTO objReportDTO = new ReportDTO();
        //        ReportBLL objReportBLL = new ReportBLL();


        //        objReportDTO.HeadOfficeId = strHeadOfficeId;
        //        objReportDTO.BranchOfficeId = strBranchOfficeId;
        //        objReportDTO.UpdateBy = strEmployeeId;

        //        if (ddlSectionId.SelectedValue.ToString() != " ")
        //        {
        //            objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objReportDTO.SectionId = "";
        //        }

        //        if (ddlUnitId.SelectedValue.ToString() != " ")
        //        {
        //            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objReportDTO.UnitId = "";
        //        }
        //        if (ddlUnitGroupId.SelectedValue.ToString() != "")
        //        {
        //            objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objReportDTO.UnitGroupId = "";
        //        }
        //        if (ddlEidTypeId.SelectedValue.ToString() != " ")
        //        {
        //            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objReportDTO.EidTypeId = "";
        //        }
        //        objReportDTO.Year = txtYear.Text;
        //        objReportDTO.payment_mode = 3;
        //        objReportDTO.EmployeeTypeId = "2";

        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptEidBonusReqSummary.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.GetEidBonusCashSummarySheet(objReportDTO));


        //        rd.SetDatabaseLogon("erp", "erp");
        //        CrystalReportViewer1.ReportSource = rd;
        //        CrystalReportViewer1.DataBind();


        //        reportMaster();

        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();

        //    }

        //    catch (Exception ex)
        //    {

        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();


        //    }

        //}
        //protected void btnBkashWorkerBonusSheet_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlEidTypeId.Text == " ")
        //        {
        //            string strMsg = "Please Select Eid Name!!!";
        //            MessageBox(strMsg);
        //            ddlEidTypeId.Focus();
        //            return;
        //        }
        //        GetBonusSheetWorkerAsBKashWallet();

        //    }
        //    catch (Exception ex)
        //    {

        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();
        //    }
        //}
        //public void GetBonusSheetWorkerAsBKashWallet()
        //{

        //    try
        //    {

        //        ReportDTO objReportDTO = new ReportDTO();
        //        ReportBLL objReportBLL = new ReportBLL();

        //        objReportDTO.HeadOfficeId = strHeadOfficeId;
        //        objReportDTO.BranchOfficeId = strBranchOfficeId;
        //        objReportDTO.UpdateBy = strEmployeeId;

        //        if (ddlUnitGroupId.SelectedValue.ToString() != "")
        //        {
        //            objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objReportDTO.UnitGroupId = "";
        //        }
        //        if (ddlSectionId.SelectedValue.ToString() != " ")
        //        {
        //            objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
        //        }
        //        else
        //        {

        //            objReportDTO.SectionId = "";
        //        }
        //        if (ddlUnitId.SelectedValue.ToString() != " ")
        //        {
        //            objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objReportDTO.UnitId = "";
        //        }

        //        if (ddlEidTypeId.SelectedValue.ToString() != " ")
        //        {
        //            objReportDTO.EidTypeId = ddlEidTypeId.SelectedValue.ToString();
        //        }
        //        else
        //        {
        //            objReportDTO.EidTypeId = "";
        //        }
        //        objReportDTO.Year = txtYear.Text;
        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptBonusSheetWorkerBkashWallet.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.GetBonusSheetWorkerAsBKashWallet(objReportDTO));
        //        rd.SetDatabaseLogon("erp", "erp");
        //        CrystalReportViewer1.ReportSource = rd;
        //        CrystalReportViewer1.DataBind();

        //        reportMaster();

        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();

        //    }

        //    catch (Exception ex)
        //    {

        //        this.CrystalReportViewer1.Dispose();
        //        this.CrystalReportViewer1 = null;
        //        rd.Dispose();
        //        rd.Close();
        //        GC.Collect();
        //        GC.WaitForPendingFinalizers();

        //    }
        //}
    }
}