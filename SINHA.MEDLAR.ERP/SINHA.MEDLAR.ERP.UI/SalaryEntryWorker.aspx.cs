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
using System.Collections;
using System.Drawing.Printing;
using CrystalDecisions.ReportAppServer.Controllers;
using SINHA.MEDLAR.ERP.UI.Utility;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class SalaryEntryWorker : System.Web.UI.Page
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
        private const string uiCode = "0009";
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

                //List<Control> controls = new List<Control>();
                //controls.Add(btnAtten);
                //controls.Add(btnSave);
                //controls.Add(btnSalaryProcess);
                
                //UIHelper.SetSucureEvents(this, strEmployeeId, uiCode, strBranchOfficeId, strHeadOfficeId);

                //SetSucureEvents();
                //old
                //GetEventPermission();

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

            txtWorkingDay.Attributes.Add("onkeypress", "return controlEnter('" + txtOverTimeHour.ClientID + "', event)");
            txtOverTimeHour.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
            //gvEmployeeList.SelectedIndexChanged += new EventHandler(gvEmployeeList_OnSelectedIndexChanged);
            //txtOverTimeHour.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
            gvEmployeeList.Columns[6].Visible = false;
        }

        //public void GetEventPermission()
        //{
        //    EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        //    DataTable dt = new DataTable();
        //    objEventPermissionDTO.UpdateBy = strEmployeeId;
        //    objEventPermissionDTO.UICode = uiCode; //"0008";
        //    objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
        //    objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
        //    var basicInfo = objEmployeeBLL.GetEventPermission(objEventPermissionDTO);

        //    //string Id = string.Empty;
        //    //foreach (Control c in controls)
        //    //{
        //    //    Id = c.ID;

        //    //}

        //    if (basicInfo.DisableAtten == "1")
        //        btnAtten.Visible = false;
        //    else
        //        btnAtten.Visible = true;

        //    if (basicInfo.DisableSave == "1")
        //        btnSave.Visible = false;
        //    else
        //        btnSave.Visible = true;

        //    if (basicInfo.DisableProcess == "1")
        //        btnSalaryProcess.Visible = false;
        //    else
        //        btnSalaryProcess.Visible = true;

        //}


        public void SetSucureEvents()
        {
            

            EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            
            objEventPermissionDTO.UpdateBy = strEmployeeId;
            objEventPermissionDTO.UICode = uiCode; //"0008";
            objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
            objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;

            UIHelper.SetSucureEvents(this, objEventPermissionDTO);
        }

        protected void Page_Init(object sender, EventArgs e)
        {

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

            txtAdvanceFee.Text = string.Empty;
            txtArrearFee.Text = string.Empty;
            txtOverTimeHour.Text = string.Empty;
            txtWorkingDay.Text = string.Empty;
            txtAttendenceFee.Text = string.Empty;
            txtLoanAmount.Text = string.Empty;
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

            txtSalaryYear.Text = objLookUpDTO.Year;
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

        //public void searchMonthlySalaryInfo()
        //{
        //    SalaryDTO objSalaryDTO = new SalaryDTO();
        //    SalaryBLL objSalaryBLL = new SalaryBLL();



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

        //    objSalaryDTO.Year = txtSalaryYear.Text;
        //    objSalaryDTO.Month = txtsalaryMonth.Text;


        //    ddlEmployeeId.DataSource = objSalaryBLL.getStaffIdForSalary(objSalaryDTO);

        //    ddlEmployeeId.DataTextField = "EMPLOYEE_NAME";
        //    ddlEmployeeId.DataValueField = "EMPLOYEE_ID";

        //    ddlEmployeeId.DataBind();
        //    if (ddlEmployeeId.Items.Count > 0)
        //    {

        //        ddlEmployeeId.SelectedIndex = 0;

        //    }
        //    else
        //    {
        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);


        //    }


        //}

        public void searchSalaryInfoWorker()
        {
            //commented on 28.03.2022
            //if (ddlUnitGroupId.Text == "" && ddlUnitId.Text == " " && ddlSectionId.Text == " ")
            //{
            //    return;
            //}

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
            
            dt = objEmployeeBLL.searchSalaryInfoWorker(objEmployeeDTO);
            
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
        public void saveTaxInfo()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objSalaryDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {

                objSalaryDTO.SectionId = "";
            }

            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;



            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;



            string strMsg = objSalaryBLL.saveTaxInfo(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }


        public void searchEmployeeRecordforMiscEntry()
        {
                                                   
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            
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

            //New
            dt = objEmployeeBLL.GetPayableWorker(objEmployeeDTO);
            //Old
            //dt = objEmployeeBLL.searchEmployeeRecordforMiscEntryWorker(objEmployeeDTO);

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
                //addWorkerSalary();

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
            //var rowCount = gvEmployeeList.Rows.Count;


            //int rowIndex = 1;
            //if (gvEmployeeList.SelectedIndex == 0)
            //{


            //    rowIndex = 0;
            //    GridViewRow row = gvEmployeeList.Rows[rowIndex];
            //    txtCardNo.Text = row.Cells[1].Text;
            //    txtDesignationName.Text = row.Cells[4].Text;
            //    txtEmployeeName.Text = row.Cells[3].Text;
            //    txtEmployeeId.Text = row.Cells[2].Text;


            //}
            //else
            //{

            //    GridViewRow row = gvEmployeeList.Rows[rowIndex];
            //    txtCardNo.Text = row.Cells[1].Text;
            //    txtDesignationName.Text = row.Cells[4].Text;
            //    txtEmployeeName.Text = row.Cells[3].Text;
            //    txtEmployeeId.Text = row.Cells[2].Text;

            //    rowIndex = rowIndex + 1;

            //}


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
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
                
                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

                txtWorkingDay.Focus();

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
                    txtWorkingDay.Focus();
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
                    txtWorkingDay.Focus();
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
                                  
            string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
            
            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            txtWorkingDay.Focus();
        }

        public void saveSalaryMiscEntryWoker()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.AdvanceFee = txtAdvanceFee.Text;
            objSalaryDTO.ArrearFee = txtArrearFee.Text;
            objSalaryDTO.OverTimeHour = txtOverTimeHour.Text;
            objSalaryDTO.EarlyDptHour = txtEarlyDptHour.Text;
            objSalaryDTO.WorkingDay = txtWorkingDay.Text;
            objSalaryDTO.Remarks = txtRemarks.Text.Trim();

            string bKashYn = string.Empty;
            if(chkBkashYn.Checked)
                objSalaryDTO.BkashYn = "Y";
            else
                objSalaryDTO.BkashYn = "N";

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

            objSalaryDTO.Bonus = txtAttendenceFee.Text;

            if (objSalaryDTO.Remarks == null || objSalaryDTO.Remarks == "0")
            {
                txtRemarks.Text = "";
            }
            else
            {
                txtRemarks.Text = objSalaryDTO.Remarks;
            }

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;
            
            string strMsg = objSalaryBLL.saveSalaryMiscEntryWoker(objSalaryDTO);
            lblMsg.Text = strMsg;
            txtWorkingDay.Focus();
            if (strMsg == "PLEASE CHECK WORKING DAY!!!" || strMsg == "PLEASE CHECK OT HOUR!!!" || strMsg == "SALARY HAS BEEN LOCKED!!!" || strMsg == "THIS EMPLOYEE HAS ALREADY RESIGNED!!!")
            {
                MessageBox(strMsg);
                clearMessage();
                return;
            }
            else
            {
                clearTextBox();
                goToNextRecord();
                searchMiscEntryWorker();
                searchSalaryInfoWorker();
            }
        }
        public void processWorkerAttendence()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;


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


            string strMsg = objSalaryBLL.processWorkerAttendence(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
            txtWorkingDay.Focus();




        }
        public void searchMiscEntryWorker()
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
            
            objSalaryDTO = objSalaryBLL.searchMiscEntryWorker(txtEmployeeId.Text, txtSalaryYear.Text, txtsalaryMonth.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.AdvanceFee == null || objSalaryDTO.AdvanceFee == "0")
            {
                txtAdvanceFee.Text = "";
            }
            else
            {
                txtAdvanceFee.Text = objSalaryDTO.AdvanceFee;
            }

            if (objSalaryDTO.ArrearFee == null || objSalaryDTO.ArrearFee == "0")
            {
                txtArrearFee.Text = "";
            }
            else
            {
                txtArrearFee.Text = objSalaryDTO.ArrearFee;
            }

            if (objSalaryDTO.OverTimeHour == null || objSalaryDTO.OverTimeHour == "0")
            {
                txtOverTimeHour.Text = "";
            }
            else
            {
                txtOverTimeHour.Text = objSalaryDTO.OverTimeHour;
            }
            if (objSalaryDTO.EarlyDptHour == null || objSalaryDTO.EarlyDptHour == "0")
            {
                txtEarlyDptHour.Text = "";
            }
            else
            {
                txtEarlyDptHour.Text = objSalaryDTO.EarlyDptHour;
            }

            if (objSalaryDTO.WorkingDay == null || objSalaryDTO.WorkingDay == "0")
            {
                txtWorkingDay.Text = "";
            }
            else
            {
                txtWorkingDay.Text = objSalaryDTO.WorkingDay;
            }

            //COMMENTET ON MAY-2020 AFTER CORONA
            //if (objSalaryDTO.PartialWorkingDay == null || objSalaryDTO.PartialWorkingDay == "0")
            //{
            //    txtPartialWorkingDay.Text = "";
            //}
            //else
            //{
            //    txtPartialWorkingDay.Text = objSalaryDTO.PartialWorkingDay;
            //}

            if (objSalaryDTO.BkashYn == "Y")
                chkBkashYn.Checked = true;
            if (objSalaryDTO.BkashYn == "N")
                chkBkashYn.Checked = false;

            if (objSalaryDTO.Bonus == null || objSalaryDTO.Bonus == "0")
            {
                txtAttendenceFee.Text = "";
            }
            else
            {
                txtAttendenceFee.Text = objSalaryDTO.Bonus;
            }

            if (objSalaryDTO.TotalLate == null || objSalaryDTO.TotalLate == "0")
            {
                txtTotalLate.Text = "";
            }
            else
            {
                txtTotalLate.Text = objSalaryDTO.TotalLate;
            }
            
            if (objSalaryDTO.TotalLeave == null || objSalaryDTO.TotalLeave == "0")
            {
                txtTotalLeave.Text = "";
            }
            else
            {
                txtTotalLeave.Text = objSalaryDTO.TotalLeave;
            }
            
            txtWorkingDay.Focus();
        }
        public void searchMonthLoanEntryWorker()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();


            objSalaryDTO = objSalaryBLL.searchMonthLoanEntryWorker(txtEmployeeId.Text, txtSalaryYear.Text, txtsalaryMonth.Text, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.LoanAmount == null || objSalaryDTO.LoanAmount == "0")
            {

                txtLoanAmount.Text = "";
            }
            else
            {

                txtLoanAmount.Text = objSalaryDTO.LoanAmount;
            }





        }


        public void processSalaryWorker()
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
            objSalaryDTO.Year = txtSalaryYear.Text.Trim();
            objSalaryDTO.Month = txtsalaryMonth.Text.Trim();

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.processSalaryWorker(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }
        //public void processSalaryWorkerTest()
        //{


        //    SalaryDTO objSalaryDTO = new SalaryDTO();
        //    SalaryBLL objSalaryBLL = new SalaryBLL();

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
        //    objSalaryDTO.Year = txtSalaryYear.Text;
        //    objSalaryDTO.Month = txtsalaryMonth.Text;

        //    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
        //    objSalaryDTO.BranchOfficeId = strBranchOfficeId;
        //    objSalaryDTO.UpdateBy = strEmployeeId;

        //    string strMsg = objSalaryBLL.processSalaryWorkerTest(objSalaryDTO);
        //    MessageBox(strMsg);
        //    lblMsg.Text = strMsg;

        //}
        public void processWorkingDayWorker()
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
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.processWorkingDayWorker(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void halfSalaryProcess()
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
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.halfSalaryProcess(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void halfSalaryRequisition()
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
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;

            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;

            string strMsg = objSalaryBLL.halfSalaryRequisition(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        public void monthlySalarySheet()
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

                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                DateTime limitDate = DateTime.Parse("2018" + "/" + "11" + "/30");
                DateTime reportDate = DateTime.Parse(txtSalaryYear.Text + "/" + txtsalaryMonth.Text + "/01");
                DateTime coronaLimitDate = DateTime.Parse("2020" + "/" + "04" + "/30");
                
                if (objReportDTO.Year.Trim() == "2020" && (objReportDTO.Month.Trim() == "04" || objReportDTO.Month.Trim() == "4"))
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptFacSalarySheetWorkerForCorona.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetWorker(objReportDTO));
                }
                else if(reportDate > coronaLimitDate)
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptWorkerSalarySheetBkash.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetWorker(objReportDTO));
                }
                else if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetWorker(objReportDTO));
                }
                else
                {
                    string strPath = string.Empty;
                    if (reportDate < limitDate)
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerBefore01122018.rpt"));
                    else
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorker.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.salarySheetWorker(objReportDTO));
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

        public void GetWorkerSalaryMasterSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                DateTime limitDate = DateTime.Parse("2018" + "/" + "11" + "/30");
                DateTime reportDate = DateTime.Parse(txtSalaryYear.Text + "/" + txtsalaryMonth.Text + "/01");
                DateTime coronaLimitDate = DateTime.Parse("2020" + "/" + "04" + "/30");


                if (objReportDTO.EmployeeTypeId == "1") //staff
                {
                     //string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                     //this.Context.Session["strReportPath"] = strPath;
                     //rd.Load(strPath);
                     //rd.SetDataSource(objReportBLL.GetStaffSalaryByUnitGroup(objReportDTO));
                }
                if (objReportDTO.EmployeeTypeId == "2") //worker
                {
                    //new
                    string strPath = string.Empty;
                    if (reportDate < limitDate)
                    {
                        strPath = Path.Combine(Server.MapPath("~/Reports/RPT_SP_SALARY_SHEET_BY_UNIT_Before01122018.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetSalaryByUnitGroup(objReportDTO));
                    }
                    else if (objReportDTO.Year == "2020" && objReportDTO.Month == "04")
                    {   
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptWorkerMasterSalarySheetCorona.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetFACSalarySheetWorkerForCorona(objReportDTO));
                    }
                    else
                    {
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptWorkerSalaryMasterSheet.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetWorkerSalaryMasterSheet(objReportDTO));
                    }
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


        public void GetAllWorkerSalaryMasterSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = null;
                objReportDTO.SectionId = null;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.UnitGroupId = null;
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                

                if (objReportDTO.EmployeeTypeId == "1") //staff
                {
                    
                }
                if (objReportDTO.EmployeeTypeId == "2") //worker
                {   
                    string strPath = string.Empty;
                    
                    strPath = Path.Combine(Server.MapPath("~/Reports/RptAllWorkerSalaryMasterSheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetAllWorkerSalaryMasterSheet(objReportDTO));                    
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


        //New By Asad: GetSalaryByUnitGroup
        public void GetSalaryByUnitGroup()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                //objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();
                //objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();

                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                    objReportDTO.UnitId = "";
                    objReportDTO.SectionId = "";
                }
                else
                {
                    objReportDTO.UnitGroupId = "";

                    if (ddlUnitId.SelectedValue.ToString() != " ")
                        objReportDTO.UnitId = ddlUnitId.SelectedValue.ToString();
                    else
                        objReportDTO.UnitId = "";

                    if (ddlSectionId.SelectedValue.ToString() != " ")
                        objReportDTO.SectionId = ddlSectionId.SelectedValue.ToString();
                    else
                        objReportDTO.SectionId = "";
                }
                                             
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                //objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                DateTime limitDate = DateTime.Parse("2018" + "/" + "11" + "/30");
                DateTime reportDate = DateTime.Parse(txtSalaryYear.Text + "/" + txtsalaryMonth.Text + "/01");
                DateTime coronaLimitDate = DateTime.Parse("2020" + "/" + "04" + "/30");

                if (objReportDTO.EmployeeTypeId == "1") //staff
                {
                    if (objReportDTO.Year.Trim() == "2020" && (objReportDTO.Month.Trim() == "04" || objReportDTO.Month.Trim() == "4"))
                    {
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffForCorona.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        //corona sp: SP_GET_FAC_SALARY_SHEET_CORONA for STAFF
                        rd.SetDataSource(objReportBLL.GetStaffSalaryByUnitGroup(objReportDTO));
                    }
                    else {
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetStaffSalaryByUnitGroup(objReportDTO));
                    }
                }

                if (objReportDTO.EmployeeTypeId == "2") //worker
                {
                    string strPath = string.Empty;
                    if (reportDate < limitDate)
                    {
                        strPath = Path.Combine(Server.MapPath("~/Reports/RPT_SP_SALARY_SHEET_BY_UNIT_Before01122018.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetSalaryByUnitGroup(objReportDTO));
                    }
                    else if (objReportDTO.Year == "2020" && objReportDTO.Month == "04")
                    {   //old: rptFacSalarySheetWorkerForCorona//
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptWorkerBkashSalarySheetCorona.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        //corona sp: SP_GET_FAC_SALARY_SHEET_CORONA
                        rd.SetDataSource(objReportBLL.GetFACSalarySheetWorkerForCorona(objReportDTO));
                    }
                    else if (reportDate > coronaLimitDate)
                    {
                        strPath = Path.Combine(Server.MapPath("~/Reports/RptWorkerSalarySheetBkash.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetFACSalarySheetWorkerForCorona(objReportDTO));
                    }
                    else
                    {
                        strPath = Path.Combine(Server.MapPath("~/Reports/RPT_SP_SALARY_SHEET_BY_UNIT.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        rd.SetDataSource(objReportBLL.GetSalaryByUnitGroup(objReportDTO));
                    }
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



        public Int32 GetPaperSize(String sPrinterName, String sPaperSizeName)
        {
            PrintDocument docPrintDoc = new PrintDocument();
            docPrintDoc.PrinterSettings.PrinterName = sPrinterName;
            for (int i = 0; i < docPrintDoc.PrinterSettings.PaperSizes.Count; i++)
            {
                int raw = docPrintDoc.PrinterSettings.PaperSizes[i].RawKind;
                if (docPrintDoc.PrinterSettings.PaperSizes[i].PaperName == sPaperSizeName)
                {
                    return raw;
                }
            }
            return 0;
        }



        //public void monthlySalarySheetTest()
        //{

        //    try
        //    {


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


        //        objReportDTO.Year = txtSalaryYear.Text;
        //        objReportDTO.Month = txtsalaryMonth.Text;




        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerNew.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.monthlySalarySheetTest(objReportDTO));


        //        rd.SetDatabaseLogon("erp", "erp");
        //        CrystalReportViewer1.ReportSource = rd;
        //        CrystalReportViewer1.DataBind();


        //        //Queue reportQueue = new Queue();
        //        ////75 is my print job limit.
        //        //if (reportQueue.Count > 75)
        //        //{
        //        //    ((ReportClass)reportQueue.Dequeue()).Dispose();
        //        //    //reportView.ReportSource = null;


        //        //}

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

        //public void monthlySalarySummerySheetTest()
        //{

        //    try
        //    {


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


        //        objReportDTO.Year = txtSalaryYear.Text;
        //        objReportDTO.Month = txtsalaryMonth.Text;




        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlySalarySheetNew.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.monthlySalarySummerySheetTest(objReportDTO));


        //        rd.SetDatabaseLogon("erp", "erp");
        //        CrystalReportViewer1.ReportSource = rd;
        //        CrystalReportViewer1.DataBind();


        //        //Queue reportQueue = new Queue();
        //        ////75 is my print job limit.
        //        //if (reportQueue.Count > 75)
        //        //{
        //        //    ((ReportClass)reportQueue.Dequeue()).Dispose();
        //        //    //reportView.ReportSource = null;


        //        //}

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
        public void monthlyWorkerSheetMisc()
        {

            try
            {


                monthlyWorkerSalaryMisc();


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


                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetWorkerMisc.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.workerMiscSheet(objReportDTO));


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
                //Response.ContentType = "application/vnd.ms-excel";
                //oStream.Seek(0, SeekOrigin.Begin);
                //Response.BinaryWrite(oStream.ToArray());
                ////Response.End();
                //oStream.Flush();
                //oStream.Close();
                //oStream.Dispose();
                //CrystalReportViewer1.RefreshReport();

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_worker");
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

        public void rptHalfSalary()
        {


            string strDefaultName = "Report";
            ExportFormatType formatType = ExportFormatType.NoFormat;

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


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


            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;



            string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetWorker.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.rptHalfSalary(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();




        }
        public void rptHalfSalaryRequisition()
        {


            string strDefaultName = "Report";
            ExportFormatType formatType = ExportFormatType.NoFormat;



            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


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


            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;



            string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSalaryRequisition.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.rptHalfSalaryRequisition(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();




        }

        public void monthlySalaryPaySlip()
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



                objReportDTO.CardNo = txtEmpCardNo.Text;
                objReportDTO.EmployeeId = txtEmpId.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                DateTime limitDate = DateTime.Parse("2018" + "/" + "11" + "/30");
                DateTime reportDate = DateTime.Parse(txtSalaryYear.Text + "/" + txtsalaryMonth.Text + "/01");

                if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerForBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));

                }
                else
                {
                    string strPath = string.Empty;
                    if (reportDate < limitDate)
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerBefore01122018.rpt"));
                    else
                        strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorker.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));

                }


                rd.SetDatabaseLogon("erp", "erp");
                CrystalReportViewer1.ReportSource = rd;

                //rd.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4;
                //rd.PrintOptions.ApplyPageMargins(new CrystalDecisions.Shared.PageMargins(0, 0, 0, 0));
                //CrystalReportViewer1.Zoom(100);

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

        //New
        public void GetWorkerPaySlipByUnitGroup()
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

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value;

                objReportDTO.CardNo = txtEmpCardNo.Text;
                objReportDTO.EmployeeId = txtEmpId.Text;

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


                DateTime limitDate = DateTime.Parse("2018" + "/" + "11" + "/30");
                DateTime reportDate = DateTime.Parse(txtSalaryYear.Text + "/" + txtsalaryMonth.Text + "/01");
                if (objReportDTO.Year.Trim() == "2020" && (objReportDTO.Month.Trim() == "04" || objReportDTO.Month.Trim() == "4"))
                {
                    string strPath = string.Empty;
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerCorona.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetWorkerPaySlipByUnitGroup(objReportDTO));
                }
                else if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerForBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    //old
                    //rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));
                    rd.SetDataSource(objReportBLL.GetWorkerPaySlipByUnitGroup(objReportDTO));
                }
                else
                {
                   if (objReportDTO.EmployeeTypeId == "1") //Staff
                    {   //
                        string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaff.rpt"));
                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        //rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));
                        rd.SetDataSource(objReportBLL.GetStaffPaySlip(objReportDTO));
                    }

                    if (objReportDTO.EmployeeTypeId == "2")
                    {
                        //rptPaySlipWorkerBefore01122018

                        string strPath = string.Empty;
                        if (reportDate < limitDate)
                            strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerBefore01122018.rpt"));
                        else
                            strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorker.rpt"));

                        this.Context.Session["strReportPath"] = strPath;
                        rd.Load(strPath);
                        //rd.SetDataSource(objReportBLL.paySlipWorker(objReportDTO));
                        rd.SetDataSource(objReportBLL.GetWorkerPaySlipByUnitGroup(objReportDTO));
                    }
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

        //public void monthlySalaryPaySlipTest()
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


        //        objReportDTO.Year = txtSalaryYear.Text;
        //        objReportDTO.Month = txtsalaryMonth.Text;


        //        if (strHeadOfficeId == "331" && strBranchOfficeId == "103")
        //        {


        //            string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerNew.rpt"));
        //            this.Context.Session["strReportPath"] = strPath;
        //            rd.Load(strPath);
        //            rd.SetDataSource(objReportBLL.monthlySalaryPaySlipTest(objReportDTO));

        //        }


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

        //public void monthlySalaryRequisitionSummeryTest()
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


        //        objReportDTO.Year = txtSalaryYear.Text;
        //        objReportDTO.Month = txtsalaryMonth.Text;



        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionSummeryTest.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.monthlySalaryRequisitionSummeryTest(objReportDTO));


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
        public void monthlySalaryRequisitionSummery()
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
                
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionSummery.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlySalaryRequisitionSummery(objReportDTO));
                
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
        public void monthlySalaryRequisition()
        {
            try
            {

                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                processSalaryRequisitionAll();

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
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionAll.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlySalaryRequisition(objReportDTO));

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


        public void GetMonthlySalaryReqAllInOne()
        {
            try
            {

                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                processSalaryRequisitionAll();

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
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionAllInOne.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlySalaryRequisition(objReportDTO));

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


        //public void monthlySalaryRequisitionTest()
        //{

        //    try
        //    {

        //        string strDefaultName = "Report";
        //        ExportFormatType formatType = ExportFormatType.NoFormat;

        //        ReportDTO objReportDTO = new ReportDTO();
        //        ReportBLL objReportBLL = new ReportBLL();

        //        processSalaryRequisitionTest();

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


        //        objReportDTO.Year = txtSalaryYear.Text;
        //        objReportDTO.Month = txtsalaryMonth.Text;



        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionTest.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.monthlySalaryRequisitionTest(objReportDTO));


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
        public void monthlyOTRequisition()
        {

            try
            {

                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                processMonthlyOTRequisition();

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


                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyOTRequisition.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlyOTRequisition(objReportDTO));


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
        public void processSalaryRequisitionTest()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;

            objReportDTO.Year = txtSalaryYear.Text;
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
            string strMsg = objReportBLL.processSalaryRequisitionTest(objReportDTO);




        }
        public void processSalaryRequisitionAll()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;

            objReportDTO.Year = txtSalaryYear.Text;
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
            string strMsg = objReportBLL.processSalaryRequisitionAll(objReportDTO);
        }
        public void processMonthlyOTRequisition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;

            objReportDTO.Year = txtSalaryYear.Text;
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
            string strMsg = objReportBLL.processMonthlyOTRequisition(objReportDTO);




        }
        public void monthlyWorkerSalaryMisc()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;

            objReportDTO.Year = txtSalaryYear.Text;
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
            string strMsg = objReportBLL.monthlyWorkerSalaryMisc(objReportDTO);






        }
        public void deleteMonthlySalary()
        {


            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();


            objReportDTO.EmployeeId = txtEmployeeId.Text;

            objReportDTO.Year = txtSalaryYear.Text;
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
            string strMsg = objReportBLL.deleteMonthlySalary(objReportDTO);
            txtWorkingDay.Text = "";
            txtOverTimeHour.Text = "";
            MessageBox(strMsg);



        }



        public void addWorkerSalary()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";
            string strCount = gvEmployeeList.Rows.Count.ToString();

            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {

                    string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                    objSalaryDTO.EmployeeId = strId;



                    objSalaryDTO.Year = txtSalaryYear.Text;
                    objSalaryDTO.Month = txtsalaryMonth.Text;

                    objSalaryDTO.UpdateBy = strEmployeeId;
                    objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                    objSalaryDTO.BranchOfficeId = strBranchOfficeId;


                    strMsg = objSalaryBLL.addWorkerSalary(objSalaryDTO);


                }


            }



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
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[5].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchMiscEntryWorker();
            searchMonthLoanEntryWorker();
            txtWorkingDay.Focus();
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
                
                else if (txtWorkingDay.Text == string.Empty && txtOverTimeHour.Text == string.Empty && txtAdvanceFee.Text == string.Empty && txtArrearFee.Text == string.Empty && txtAttendenceFee.Text == string.Empty && txtEarlyDptHour.Text == string.Empty)
                {
                    goToNextRecord();
                    searchMiscEntryWorker();
                    searchMonthLoanEntryWorker();
                    clearMessage();
                }
                else
                {
                    saveSalaryMiscEntryWoker();
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Error " + ex.Message);
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
                    searchMiscEntryWorker();
                    searchMonthLoanEntryWorker();
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
                    searchMiscEntryWorker();
                    searchMonthLoanEntryWorker();
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
                int counter = 0;

                if (ddlUnitId.Text != " ")
                {
                    counter = counter + 1;
                }
                if (ddlSectionId.Text != " ")
                {
                    counter = counter + 1;
                }

                if (txtEmpId.Text != "")
                {
                    counter = counter + 1;
                }
                if (txtEmpCardNo.Text != "")
                {
                    counter = counter + 1;
                }

                if (counter > 0)
                {
                    searchEmployeeRecordforMiscEntry();
                    clearYellowTextBox();
                    clearTextBox();
                    gvEmployeeList.SelectedIndex = 0;
                    goToNextRecord();
                    searchMiscEntryWorker();
                    searchMonthLoanEntryWorker();
                    searchSalaryInfoWorker();
                }
                else
                {
                    string strMsg = "Please Select/Enter valid input.";
                    MessageBox(strMsg);
                    return;
                }

                //commented on 28.03.2022
                //if (ddlUnitId.Text == " ")
                //{
                //    string strMsg = "Please Select Unit Name!!!";
                //    MessageBox(strMsg);
                //    ddlUnitId.Focus();
                //    return;
                //}

                //else if (ddlSectionId.Text == " ")
                //{

                //    string strMsg = "Please Select Section Name!!!";
                //    MessageBox(strMsg);
                //    ddlSectionId.Focus();
                //    return;
                //}
                //else
                //{

                //    searchEmployeeRecordforMiscEntry();
                //    clearYellowTextBox();
                //    clearTextBox();
                //    gvEmployeeList.SelectedIndex = 0;
                //    goToNextRecord();
                //    searchMiscEntryWorker();
                //    searchMonthLoanEntryWorker();
                //    searchSalaryInfoWorker();
                //}
            }

            catch (Exception ex)
            {
                //throw new Exception("Error : " + ex.Message);
            }
        }


        protected void txtEmployeeId_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtArrearFee_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                searchSalaryInfoWorker();
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
            //new
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;

            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;

            string strEmployeeId = GridView1.SelectedRow.Cells[15].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchMiscEntryWorker();
            searchMonthLoanEntryWorker();
            txtWorkingDay.Focus();

            //old
            //int strRowId = GridView1.SelectedRow.RowIndex + 1;
            //string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            //string strCardNo = GridView1.SelectedRow.Cells[1].Text;

            //string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            //string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            //string strEmployeeId = GridView1.SelectedRow.Cells[16].Text;

            //txtSL.Text = Convert.ToString(strRowId);
            //txtCardNo.Text = strCardNo;
            //txtEmployeeId.Text = strEmployeeId;
            //txtEmployeeName.Text = strEmployeeName;
            //txtDesignationName.Text = strDesignation;

            //searchMiscEntryWorker();
            //searchMonthLoanEntryWorker();
            //txtWorkingDay.Focus();
        }




        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "Select")
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

            //    searchMiscEntryWorker();

            //    txtWorkingDay.Focus();
            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}




            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

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

                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            string EmployeeId = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"]);

            objSalaryDTO.EmployeeId = EmployeeId;
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;
            objSalaryDTO.UpdateBy = strEmployeeId;
            string MSG = objSalaryBLL.DeleteWorkerSalaryInfo(objSalaryDTO);
            lblMsg.Text = MSG;
            searchSalaryInfoWorker();
            searchMiscEntryWorker();
            searchMonthLoanEntryWorker();
            txtWorkingDay.Focus();
        }

        #endregion

        protected void btnAttendenceProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == "")
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
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

                    processWorkerAttendence();
                    searchSalaryInfoWorker();

                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnSalaryProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }
                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                else
                {
                    processSalaryWorker();
                    searchMiscEntryWorker();
                    searchSalaryInfoWorker();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error :" + ex.Message);
            }
        }

        protected void btnSalarySheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
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
                    GetSalaryByUnitGroup();
                }
                else
                {
                    GetSalaryByUnitGroup();
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

        protected void btnPaySlip_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
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
                    GetWorkerPaySlipByUnitGroup();
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
                    GetWorkerPaySlipByUnitGroup();
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
            //old
            //try
            //{

            //    if (ddlUnitGroupId.SelectedItem.Value != "")
            //    {
            //        if (ddlUnitId.Text == " ")
            //        {
            //            if (ddlEmployeeTypeId.SelectedItem.Value == "")
            //            {
            //                string strMsg = "Please Select Employee Type!!!";
            //                MessageBox(strMsg);
            //                ddlEmployeeTypeId.Focus();
            //                return;
            //            }
            //            GetWorkerPaySlipByUnitGroup();
            //            return;
            //        }
            //    }

            //    if (ddlUnitId.Text == " ")
            //    {
            //        string strMsg = "Please Select Unit Name!!!";
            //        MessageBox(strMsg);
            //        ddlUnitId.Focus();
            //        return;
            //    }
            //    if (ddlSectionId.Text == " ")
            //    {
            //        string strMsg = "Please Select Section Name!!!";
            //        MessageBox(strMsg);
            //        ddlUnitId.Focus();
            //        return;
            //    }
            //    monthlySalaryPaySlip();
            //}
            //catch (Exception ex)
            //{
            //    this.CrystalReportViewer1.Dispose();
            //    this.CrystalReportViewer1 = null;
            //    rd.Dispose();
            //    rd.Close();
            //    GC.Collect();
            //    GC.WaitForPendingFinalizers();
            //}
        }

        protected void btnRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                monthlySalaryRequisition();
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

        #region "Crystal Report Functionality"

        protected void Page_Unload(object sender, EventArgs e)
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

        protected void btnSalaryMisc_Click(object sender, EventArgs e)
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

                    monthlyWorkerSheetMisc();

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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmployeeId.Text == " ")
                {

                    string strMsg = "Please Select an Employee!!!";
                    MessageBox(strMsg);
                    txtEmployeeId.Focus();
                    return;
                }

                else
                {

                    deleteMonthlySalary();
                    searchSalaryInfoWorker();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnHalfSheet_Click(object sender, EventArgs e)
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

                else if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;

                }

                else
                {

                    halfSalaryProcess();
                    rptHalfSalary();
                    searchSalaryInfoWorker();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnHalfSalaryRequisition_Click(object sender, EventArgs e)
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


                else if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;

                }

                else
                {

                    halfSalaryRequisition();
                    rptHalfSalaryRequisition();
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Error : " + ex.Message);
            }
        }
               

        #region "Crystal Report Correction"

        protected static Queue reportQueue = new Queue();

        protected static ReportClass CreateReport(Type reportClass)
        {
            object report = Activator.CreateInstance(reportClass);
            reportQueue.Enqueue(report);
            return (ReportClass)report;
        }

        public static ReportClass GetReport(Type reportClass)
        {
            //75 is my print job limit.
            if (reportQueue.Count > 75) ((ReportClass)reportQueue.Dequeue()).Dispose();
            return CreateReport(reportClass);
        }





        #endregion

        protected void btnOTRequisition_Click(object sender, EventArgs e)
        {

        }

        protected void btnMonthlyOTSheet_Click(object sender, EventArgs e)
        {
            try
            {

                monthlyOTRequisition();

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

        protected void btnAtten_Click(object sender, EventArgs e)
        {
            try
            {
                //if (gvEmployeeList.Rows.Count == 0)
                //{
                //    string strMsg = "Please click searh Button!!!";
                //    MessageBox(strMsg);
                //    clearMessage();
                //    btnSearch.Focus();

                //    return;
                //}


                //else 
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                else
                {

                    processWorkingDayWorker();
                    searchMiscEntryWorker();
                    searchSalaryInfoWorker();
                    searchMonthLoanEntryWorker();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

        protected void btnMonthlyRequisitionSummery_Click(object sender, EventArgs e)
        {
            try
            {

                monthlySalaryRequisitionSummery();

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

        protected void btnSalaryProcessTest_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;

                }

                else if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;

                }



                else
                {
                    processSalaryWorker();
                    searchMiscEntryWorker();
                    searchSalaryInfoWorker();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

        //protected void btnPaySlipTest_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlUnitId.Text == " ")
        //        {

        //            string strMsg = "Please Select Unit Name!!!";
        //            MessageBox(strMsg);
        //            ddlUnitId.Focus();
        //            return;
        //        }

        //        else if (ddlSectionId.Text == " ")
        //        {

        //            string strMsg = "Please Select Section Name!!!";
        //            MessageBox(strMsg);
        //            ddlSectionId.Focus();
        //            return;
        //        }
        //        else
        //        {

        //            monthlySalaryPaySlipTest();

        //        }

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

        //protected void btnSalarySheetTest_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlUnitId.Text == " ")
        //        {

        //            string strMsg = "Please Select Unit Name!!!";
        //            MessageBox(strMsg);
        //            ddlUnitId.Focus();
        //            return;
        //        }

        //        else if (ddlSectionId.Text == " ")
        //        {

        //            string strMsg = "Please Select Section Name!!!";
        //            MessageBox(strMsg);
        //            ddlSectionId.Focus();
        //            return;
        //        }
        //        else
        //        {

        //            monthlySalarySheetTest();

        //        }
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

        //protected void btnSalaryProcessTest_Click1(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (txtSalaryYear.Text == string.Empty)
        //        {
        //            string strMsg = "Please Enter Year!!!";
        //            MessageBox(strMsg);
        //            txtSalaryYear.Focus();
        //            return;

        //        }

        //        else if (txtsalaryMonth.Text == string.Empty)
        //        {
        //            string strMsg = "Please Enter Month!!!";
        //            MessageBox(strMsg);
        //            txtsalaryMonth.Focus();
        //            return;

        //        }



        //        else
        //        {
        //            processSalaryWorkerTest();

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Error :" + ex.Message);
        //    }
        //}

        //protected void btnSummeryTest_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (ddlUnitId.Text == " ")
        //        {

        //            string strMsg = "Please Select Unit Name!!!";
        //            MessageBox(strMsg);
        //            ddlUnitId.Focus();
        //            return;
        //        }

        //        else if (ddlSectionId.Text == " ")
        //        {

        //            string strMsg = "Please Select Section Name!!!";
        //            MessageBox(strMsg);
        //            ddlSectionId.Focus();
        //            return;
        //        }
        //        else
        //        {

        //            monthlySalarySummerySheetTest();

        //        }
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

        //protected void btnSalReqTest_Click(object sender, EventArgs e)
        //{
        //    {
        //        try
        //        {

        //            monthlySalaryRequisitionTest();

        //        }
        //        catch (Exception ex)
        //        {

        //            this.CrystalReportViewer1.Dispose();
        //            this.CrystalReportViewer1 = null;
        //            rd.Dispose();
        //            rd.Close();
        //            GC.Collect();
        //            GC.WaitForPendingFinalizers();


        //        }
        //    }

        //}

        //protected void btnMonthlyRequisitionSummeryTest_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        monthlySalaryRequisitionSummeryTest();

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

        protected void btnEmployeeGrossSalarySheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (strEmployeeId != "121" && strEmployeeId != "992")
                {
                    string Msg = "Access Denied";
                    MessageBox(Msg);
                    return;
                }

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
                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
                    return;
                }
                GetEmployeeInfoWithGrossSalary();

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

        public void GetEmployeeInfoWithGrossSalary()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                DateTime limitDate = DateTime.Parse("2018" + "/" + "11" + "/30");
                DateTime reportDate = DateTime.Parse(txtSalaryYear.Text + "/" + txtsalaryMonth.Text + "/01");


                if (objReportDTO.EmployeeTypeId == "2")
                {
                    string strPath = string.Empty;
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeGrossSalarySheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetEmployeeInfoWithGrossSalary(objReportDTO));
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

        protected void btnMonthlySalarySummaryComparism_Click(object sender, EventArgs e)
        {
            try
            {

                GetWorkerStaffRequisitionSummary();
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

        public void GetWorkerStaffRequisitionSummary()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                MergeSalaryRequisition();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptStaffWorkerRequisitionSummary.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerStaffRequisitionSummary(objReportDTO));

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
        public void MergeSalaryRequisition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;


            objReportDTO.Year = txtSalaryYear.Text;
            objReportDTO.Month = txtsalaryMonth.Text;
            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;
            string strMsg = objReportBLL.MergeSalaryRequisition(objReportDTO);
        }

        protected void btnRequisitionWorker_Click(object sender, EventArgs e)
        {
            try
            {
                GetWorkerSalaryRequisition();
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
        public void GetWorkerSalaryRequisition()
        {
            try
            {
                MergeSalaryRequisition();
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

             
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWorkerSalaryRequisition.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerSalaryRequisition(objReportDTO));

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

        protected void btnBankSalarySheet_Click(object sender, EventArgs e)
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
                    GetWorkerBankSalarySheetByUnitGroup();
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
        public void GetWorkerBankSalarySheetByUnitGroup()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBankSalarySheetWorker.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerBankSalarySheetByUnitGroup(objReportDTO));


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

        protected void btnWalletSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                GetWalletSheet();
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
        //old
        //public void GetWalletSheet()
        //{

        //    try
        //    {
        //        string strDefaultName = "Report";
        //        ExportFormatType formatType = ExportFormatType.NoFormat;

        //        ReportDTO objReportDTO = new ReportDTO();
        //        ReportBLL objReportBLL = new ReportBLL();

        //        objReportDTO.HeadOfficeId = strHeadOfficeId;
        //        objReportDTO.BranchOfficeId = strBranchOfficeId;

        //        objReportDTO.Year = txtSalaryYear.Text.Trim();
        //        objReportDTO.Month = txtsalaryMonth.Text.Trim();
        //        objReportDTO.UpdateBy = strEmployeeId;



        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
        //        this.Context.Session["strReportPath"] = strPath;
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.GetWalletSheet(objReportDTO));


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

        //new
        public void GetWalletSheet()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = "";
                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWalletSheet(objReportDTO));


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

        protected void btnRequisitionBKash_Click(object sender, EventArgs e)
        {
            try
            {
                GetWorkerStaffSalaryReqBKash();
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


        public void GetWorkerBKashSalaryReq()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptStaffWorkerSalaryReqForBKash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerBKashSalaryReq(objReportDTO));

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


        public void GetWorkerStaffSalaryReqBKash()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptStaffWorkerSalaryReqForBKash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerStaffSalaryReqBKash(objReportDTO));

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

        protected void btnRequisitionSummaryBKash_Click(object sender, EventArgs e)
        {
            try
            {
                GetWorkerStaffReqSummaryBKash();
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

        public void GetWorkerStaffReqSummaryBKash()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBKashSalaryReqSummary.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerStaffReqSummaryBKash(objReportDTO));

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

        protected void btnBKashSheetWorker_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                GetBKashSheetWorker();
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

        public void GetBKashSheetWorker()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = "2";
                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWalletSheet(objReportDTO));


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

        protected void btnCashSalarySheetWorker_Click(object sender, EventArgs e)
        {
            try
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
                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
                    return;
                }
                GetWorkerCashSalarySheetByUnitGroup();
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

        public void GetWorkerCashSalarySheetByUnitGroup()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                string strPath = string.Empty;
                if (objReportDTO.Year == "2020" && objReportDTO.Month == "04")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptCashSalarySheetWorker.rpt"));
                }
                else
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/RptWorkerSalaryMasterSheet.rpt"));
                }

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerCashSalarySheetByUnitGroup(objReportDTO));

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

        protected void btnRequisitionCash_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlUnitGroupId.SelectedItem.Value == "")
                {
                    MessageBox("Please select unit group.");
                    return;
                }

                GetWorkerSalaryReqCash();
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

        public void GetWorkerSalaryReqCash()
        {
            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                if(ddlEmployeeTypeId.SelectedItem.Value.Trim() == string.Empty)
                {
                    objReportDTO.EmployeeTypeId = null;
                }
                else
                {
                    objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();
                }
                                
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWorkerSalaryReqCash.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerSalaryReqCash(objReportDTO));

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

        protected void btnOverTimeSheet_Click(object sender, EventArgs e)
        {
            try
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
                //if (ddlEmployeeTypeId.SelectedItem.Value == "")
                //{
                //    string strMsg = "Please Select Employee Type!!!";
                //    MessageBox(strMsg);
                //    ddlEmployeeTypeId.Focus();
                //    return;
                //}
                GetOverTimeSheet();
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
        public void GetOverTimeSheet()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                string strPath = string.Empty;
                strPath = Path.Combine(Server.MapPath("~/Reports/rptOverTimeSheetWorker.rpt"));

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetOverTimeSheet(objReportDTO));

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

        protected void btnOverTimeReq_Click(object sender, EventArgs e)
        {
            try
            {
                GetOverTimeReq();
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
        public void GetOverTimeReq()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptOverTimeReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetOverTimeReq(objReportDTO));

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
               
        protected void BtnMasterSheet_Click(object sender, EventArgs e)
        {

            try
            {
                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
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
                    GetWorkerSalaryMasterSheet();
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
                    GetWorkerSalaryMasterSheet();
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

        protected void btnOTBKashTemplate_Click(object sender, EventArgs e)
        {
            try
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
                GetOverTimeBkashTemplate();
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

        public void GetOverTimeBkashTemplate()
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitId = ddlUnitId.SelectedItem.Value.Trim();
                objReportDTO.SectionId = ddlSectionId.SelectedItem.Value.Trim();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();

                string strPath = string.Empty;
                strPath = Path.Combine(Server.MapPath("~/Reports/RptOverTimeBKashWallet.rpt"));

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetOverTimeBKashTemplate(objReportDTO));

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

        protected void btnWorkerBkashRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                GetWorkerBKashSalaryReq();
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

        protected void btnDformReq_Click(object sender, EventArgs e)
        {
            try
            {
                GetDformReq();
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
        public void GetDformReq()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDformReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetDformReq(objReportDTO));

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

        protected void btnNonDformReq_Click(object sender, EventArgs e)
        {
            try
            {
                GetNonDformReq();
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
        public void GetNonDformReq()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptDformReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetNonDformReq(objReportDTO));

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

        protected void btnDformWallet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                GetDFormWalletSheet();
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

        protected void btnNonDformWallet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                GetNonDFormWalletSheet();
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
        public void GetDFormWalletSheet()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = "";
                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetDFormWalletSheet(objReportDTO));


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


        public void GetDForm5PercentWalletSheet()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = "";
                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetDForm5PercentWalletSheet(objReportDTO));
                
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


        public void GetNonDFormWalletSheet()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = "";
                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetNonDFormWalletSheet(objReportDTO));
                
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

        public void GetNonDForm5PercentWalletSheet()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = "";
                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetNonDForm5PercentWalletSheet(objReportDTO));
                
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


        protected void BtnDForm5PerBkashTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                GetDForm5PercentWalletSheet();
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

        protected void BtnNonDForm5PerBkashTemplate_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtSalaryYear.Focus();
                    return;
                }

                if (txtsalaryMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtsalaryMonth.Focus();
                    return;
                }
                GetNonDForm5PercentWalletSheet();
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

        protected void btnRequisitionSummaryCash_Click(object sender, EventArgs e)
        {
            try
            {
                GetWorkerStaffReqSummaryCash();
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
        public void GetWorkerStaffReqSummaryCash()
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value.Trim();
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBKashSalaryReqSummary.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetWorkerStaffReqSummaryCash(objReportDTO));

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

        protected void BtnMasterSheetAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
                    return;
                }

                if (ddlUnitGroupId.SelectedItem.Value == "" && ddlUnitId.Text == " " && ddlSectionId.Text == " ")
                {
                    GetAllWorkerSalaryMasterSheet();
                }
                else
                {
                    MessageBox("Please deselect unit, section.");
                    return;
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

        protected void btnGetEmpWhoWdayLessThanXDays_Click(object sender, EventArgs e)
        {

            if (txtWDay.Text == string.Empty)
            {
                string strMsg = "Please Enter Working Day";
                MessageBox(strMsg);
                txtWDay.Focus();
                return;
            }
            if (ddlEmployeeTypeId.Text == string.Empty)
            {

                string strMsg = "Please Select Employee Type";
                MessageBox(strMsg);
                ddlEmployeeTypeId.Focus();
                return;
            }
            GetEmpWhoseWDayLessThanMoreDays();
        }
        public void GetEmpWhoseWDayLessThanMoreDays()
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
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                objReportDTO.WorkingDay = txtWDay.Text;
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedItem.Value.Trim();

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmpWhoseWDayLessThanXDays.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetEmpWhoseWDayLessThanMoreDays(objReportDTO));

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

        protected void btnSalaryReqAllInOne_Click(object sender, EventArgs e)
        {
            try
            {
                GetMonthlySalaryReqAllInOne();
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

        //protected void btnAtten_Click(object sender, EventArgs e)
        //{

        //}
    }
}
