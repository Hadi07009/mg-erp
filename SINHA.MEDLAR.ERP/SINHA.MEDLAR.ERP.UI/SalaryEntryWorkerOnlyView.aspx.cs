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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class SalaryEntryWorkerOnlyView : System.Web.UI.Page
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


                getSectionId();
                clearMsg();
                getOfficeName();
                getMonthYearForTax();
                //getAttendencePrivilaged();
                btnSearch.Focus();


            }

            if (IsPostBack)
            {

                loadSesscion();

            }

            //txtWorkingDay.Attributes.Add("onkeypress", "return controlEnter('" + txtOverTimeHour.ClientID + "', event)");
            //txtOverTimeHour.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
            //gvEmployeeList.SelectedIndexChanged += new EventHandler(gvEmployeeList_OnSelectedIndexChanged);
            //txtOverTimeHour.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
            //gvEmployeeList.Columns[6].Visible = false;
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

        public void getAttendencePrivilaged()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getAttendencePrivilaged(strHeadOfficeId, strBranchOfficeId);

            if (objLookUpDTO.AttendenceYn == "Y")
            {
                //btnAdd.Visible = true;
            }
            else
            {
                //btnAdd.Visible = false;

            }

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
            if (ddlUnitGroupId.Text == "" && ddlUnitId.Text == " " && ddlSectionId.Text == " ")
            {
                return;
            }

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
                objReportDTO.EmployeeTypeId = "2";

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
                objReportDTO.EmployeeTypeId = "2";

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
                objReportDTO.EmployeeTypeId = "2";

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
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button clicked 
            // by the user from the Rows collection.      
            GridViewRow row = gvEmployeeList.Rows[index];

            string employeeId = Convert.ToString(gvEmployeeList.DataKeys[row.RowIndex].Values["EMPLOYEE_ID"]);
            //string employeeId = row.Cells[5].Text.Replace("&nbsp;", "");

            if (e.CommandName == "Select")
            {
                //int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
                //string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;             
            }
            if (e.CommandName == "Edit")
            {
            }

            //if (e.CommandName == "Delete")
            //{
            //    EmployeeBLL objEmployee = new EmployeeBLL();
            //    //string result = objEmployee.DeleteUnpaidEmployeePermanently(cacheId, employeeId, strEmployeeId);
            //    //LoadEmployeeCache();
            //    //MessageBox(result);
            //}
            if (e.CommandName == "History")
            {
                if (employeeId == string.Empty)
                {
                    MessageBox("Please Employee Id.");
                    return;
                }

                GetSalaryHistory(employeeId);
            }

            //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
            //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";

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

                    searchEmployeeRecordforMiscEntry();
                    clearYellowTextBox();
                    clearTextBox();
                    gvEmployeeList.SelectedIndex = 0;
                    goToNextRecord();
                    searchMiscEntryWorker();
                    searchMonthLoanEntryWorker();
                    searchSalaryInfoWorker();
                }
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
            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;

            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[16].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            searchMiscEntryWorker();
            searchMonthLoanEntryWorker();
            txtWorkingDay.Focus();


        }




        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);

            // Retrieve the row that contains the button clicked 
            // by the user from the Rows collection.      
            GridViewRow row = GridView1.Rows[index];

            string employeeId = Convert.ToString(GridView1.DataKeys[row.RowIndex].Values["EMPLOYEE_ID"]);
            //string employeeId = row.Cells[5].Text.Replace("&nbsp;", "");
            

            if (e.CommandName == "Detail")
            {

                //int strRowId = GridView1.SelectedRow.RowIndex + 1;
                //string strSLNo = GridView1.SelectedRow.Cells[0].Text;
                //string strCardNo = GridView1.SelectedRow.Cells[1].Text;
                //string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
                //string strDesignation = GridView1.SelectedRow.Cells[3].Text;

                string strRowId = row.Cells[0].Text.Replace("&nbsp;", "");
                string strCardNo = row.Cells[1].Text.Replace("&nbsp;", "");
                string strEmployeeName = row.Cells[2].Text.Replace("&nbsp;", "");
                string strDesignation = row.Cells[3].Text.Replace("&nbsp;", "");

                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = employeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

                searchMiscEntryWorker();
                searchMonthLoanEntryWorker();
                txtWorkingDay.Focus();

            }
            if (e.CommandName == "Edit")
            {
            }

            //if (e.CommandName == "Delete")
            //{
            //    EmployeeBLL objEmployee = new EmployeeBLL();
            //    //string result = objEmployee.DeleteUnpaidEmployeePermanently(cacheId, employeeId, strEmployeeId);
            //    //LoadEmployeeCache();
            //    //MessageBox(result);
            //}
            if (e.CommandName == "History")
            {
                if (employeeId == string.Empty)
                {
                    MessageBox("Please Employee Id.");
                    return;
                }

                GetSalaryHistory(employeeId);
            }

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

      
        protected void btnSalarySheet_Click(object sender, EventArgs e)
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
                objReportDTO.EmployeeTypeId = "2";

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

        

    

       
      
     
     
               
        protected void BtnMasterSheet_Click(object sender, EventArgs e)
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

        protected void btnSalaryHistory_Click(object sender, EventArgs e)
        {
            if(txtEmpId.Text == string.Empty)
            {
                MessageBox("Please Employee Id.");
                return;
            }

            GetSalaryHistory(txtEmpId.Text.Trim());
        }
        public void GetSalaryHistory(string employeeId)
        {

            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
                //objReportDTO.EmployeeId = txtEmployeeId.Text;
                objReportDTO.EmployeeId = employeeId;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;

                //objReportDTO.Year = txtSalaryYear.Text.Trim();
                //objReportDTO.Month = txtsalaryMonth.Text.Trim();

                objReportDTO.UpdateBy = strEmployeeId;
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptEmployeeSalaryHistory.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetSalaryHistory(objReportDTO));
                
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


        //protected void GvEmployeeCache_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);

        //    // Retrieve the row that contains the button clicked 
        //    // by the user from the Rows collection.      
        //    GridViewRow row = GvEmployeeCache.Rows[index];

        //    string cacheId = Convert.ToString(GvEmployeeCache.DataKeys[row.RowIndex].Values["cache_id"]);
        //    string employeeId = row.Cells[5].Text.Replace("&nbsp;", "");

        //    if (e.CommandName == "Select")
        //    {
        //        //int strRowId = GvEmployeeCache.SelectedRow.RowIndex + 1;
        //        //string strSLNo = GvEmployeeCache.SelectedRow.Cells[0].Text;             
        //    }
        //    if (e.CommandName == "Edit")
        //    {
        //    }
        //    if (e.CommandName == "Delete")
        //    {
        //        EmployeeBLL objEmployee = new EmployeeBLL();
        //        string result = objEmployee.DeleteUnpaidEmployeePermanently(cacheId, employeeId, strEmployeeId);
        //        LoadEmployeeCache();
        //        MessageBox(result);
        //    }
        //    if (e.CommandName == "Approve")
        //    {
        //        EmployeeDTO objEmployeeDTO = new EmployeeDTO();
        //        EmployeeBLL objEmployeeBLL = new EmployeeBLL();

        //        objEmployeeDTO = objEmployeeBLL.GetEmployeeCacheByCacheId(cacheId);
        //        if (objEmployeeDTO.ApproveYn == "Y")
        //        {
        //            MessageBox("Already Approved");
        //        }
        //        else
        //        {
        //            ApproveEmployment(cacheId);
        //            LoadEmployeeCache();
        //        }
        //    }

        //    //int selectedRowIndex = GridView1.SelectedRow.RowIndex;
        //    //GridView1.Rows[selectedRowIndex].Cells[0].Attributes["style"] += "background-color:Red;";
        //}


    }
}
