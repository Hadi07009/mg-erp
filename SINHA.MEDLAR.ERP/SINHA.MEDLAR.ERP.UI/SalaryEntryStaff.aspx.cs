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
using System.Drawing;


namespace SINHA.MEDLAR.ERP.UI
{
    public partial class MiscEntryStaff : System.Web.UI.Page
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
                //GetEventPermission();
                clearMsg();
                getOfficeName();
                getMonthYearForTax();
                btnSearch.Focus();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            gvEmployeeList.Columns[5].Visible = false;

            if (strBranchOfficeId != "110")
            {
                btnBankRequisitionSheetDetail.Visible = false;
                btnBankRequisitionSheet.Visible = false;
                //btnCashSheet.Visible = false;
                btnBankSheet.Visible = false;
                btnBankRequisitionSheetDetail.Visible = false;
                btnBankSheetDetail.Visible = false;
            }

        }

        //public void GetEventPermission()
        //{
        //    EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        //    DataTable dt = new DataTable();
        //    objEventPermissionDTO.UpdateBy = strEmployeeId;
        //    objEventPermissionDTO.MenuCode = "0009";
        //    objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
        //    objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
        //    var basicInfo = objEmployeeBLL.GetEventPermission(objEventPermissionDTO);
        //    if (basicInfo.DisableSave == "1")
        //        btnSave.Visible = false;
        //    else
        //        btnSave.Visible = true;

        //    if (basicInfo.DisableAdd == "1")
        //        btnAdd.Visible = false;
        //    else
        //        btnAdd.Visible = true;
        //    if (basicInfo.DisableProcess == "1")
        //        btnProcess.Visible = false;
        //    else
        //        btnProcess.Visible = true;
        //}
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


        public void clearTextBox()
        {

            txtAdvanceFee.Text = string.Empty;
            txtArrearFee.Text = string.Empty;
            txtFoodAllowance.Text = string.Empty;
            txtFoodDeduction.Text = string.Empty;
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

            //new
            dt = objEmployeeBLL.GetPayableStaff(objEmployeeDTO);
            //Old
            //dt = objEmployeeBLL.searchEmployeeRecordforSalaryEntryStaff(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();



                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsg.Text = strMsg;
                //addWorkerSalary();

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
        public void searchSalaryInfoStaff()
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





            dt = objEmployeeBLL.searchSalaryInfoStaff(objEmployeeDTO);


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

            txtWorkingDay.Focus();

        }

        public void saveSalaryMiscEntryStaff()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            objSalaryDTO.Year = txtSalaryYear.Text;
            objSalaryDTO.Month = txtsalaryMonth.Text;
            objSalaryDTO.AdvanceFee = txtAdvanceFee.Text;
            objSalaryDTO.ArrearFee = txtArrearFee.Text;
            objSalaryDTO.FoodAllowance = txtFoodAllowance.Text;
            objSalaryDTO.FoodDeductFee = txtFoodDeduction.Text;
            objSalaryDTO.WorkingDay = txtWorkingDay.Text;
            objSalaryDTO.Remarks = txtRemarks.Text.Trim();

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


            string strMsg = objSalaryBLL.saveSalaryEntryStaff(objSalaryDTO);
            //MessageBox(strMsg);
            lblMsg.Text = strMsg;
            txtAdvanceFee.Focus();
            if (strMsg == "PLEASE CHECK WORKING DAY!!!" || strMsg == "SALARY HAS BEEN LOCKED!!!" || strMsg == "THIS EMPLOYEE HAS ALREADY RESIGNED!!!")
            {


                MessageBox(strMsg);
                clearMessage();
                return;

            }
            else
            {

                clearTextBox();
                goToNextRecord();
                searchMiscEntryStaff();
                searchSalaryInfoStaff();

            }



        }

        public void searchMiscEntryStaff()
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





            objSalaryDTO = objSalaryBLL.searchSalaryEntryStaff(txtEmployeeId.Text, txtSalaryYear.Text, txtsalaryMonth.Text, strUnitId, strSectionId, strHeadOfficeId, strBranchOfficeId);

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

            if (objSalaryDTO.FoodAllowance == null || objSalaryDTO.FoodAllowance == "0")
            {
                txtFoodAllowance.Text = "";
            }
            else
            {
                txtFoodAllowance.Text = objSalaryDTO.FoodAllowance;
            }
            
            if (objSalaryDTO.FoodDeductFee == null || objSalaryDTO.FoodDeductFee == "0")
            {
                txtFoodDeduction.Text = "";
            }
            else
            {
                txtFoodDeduction.Text = objSalaryDTO.FoodDeductFee;
            }
            
            if (objSalaryDTO.WorkingDay == null || objSalaryDTO.WorkingDay == "0")
            {
                txtWorkingDay.Text = "";
            }
            else
            {
                txtWorkingDay.Text = objSalaryDTO.WorkingDay;
            }

            if (objSalaryDTO.Remarks == null || objSalaryDTO.Remarks == "0")
            {
                txtRemarks.Text = "";
            }
            else
            {
                txtRemarks.Text = objSalaryDTO.Remarks;
            }

        }


        public void searchMonthLoanEntryWorker()
        {
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO = objSalaryBLL.searchMonthLoanEntryStaff(txtEmployeeId.Text, txtSalaryYear.Text, txtsalaryMonth.Text, strHeadOfficeId, strBranchOfficeId);

            if (objSalaryDTO.LoanAmount == null || objSalaryDTO.LoanAmount == "0")
            {

                txtLoanAmount.Text = "";
            }
            else
            {

                txtLoanAmount.Text = objSalaryDTO.LoanAmount;
            }





        }


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }









        public void processSalaryStaff()
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

            string strMsg = objSalaryBLL.processSalaryStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }
        public void HalfSalaryStaff()
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

            string strMsg = objSalaryBLL.HalfSalaryStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

        }

        public void monthlyStaffSalarySheet()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();



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
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
                }

                else
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));

                }


                //string strURL = "CrystalView.aspx";
                //this.Context.Session["strReportPath"] = strPath;
                //this.Context.Session["strUnitId"] = objReportDTO.UnitId;
                //this.Context.Session["strSectionId"] = objReportDTO.SectionId;
                //this.Context.Session["strYear"] = objReportDTO.Year;
                //this.Context.Session["strMonth"] = objReportDTO.Month;
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('" + strURL + "','_newtab');", true);


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

                rd.ExportToHttpResponse (CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_staff");
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }
        }


        public void ReportMasterTestByAsad()
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


                //----------------------------------------------------
                
                // Declare variables and get the export options.
                ExportOptions exportOpts = new ExportOptions();
                ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
                DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                exportOpts = rd.ExportOptions;

                // Set the excel format options.
                excelFormatOpts.ExcelUseConstantColumnWidth = true;
                excelFormatOpts.ExcelTabHasColumnHeadings = true;
                exportOpts.ExportFormatType = ExportFormatType.Excel;
                exportOpts.FormatOptions = excelFormatOpts;

                // Set the disk file options and export.
                exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                diskOpts.DiskFileName = "Gross Sheet";
                exportOpts.DestinationOptions = diskOpts;

                //rd.Export();
                
                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "salary_sheet_staff");
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }
        }

        public void monthlyStaffSalaryPaySlip()
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



                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaffForBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.paySlipStaff(objReportDTO));

                }
                else
                {

                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.paySlipStaff(objReportDTO));
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
        public void halfSheetStaff()
        {

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



            string strPath = Path.Combine(Server.MapPath("~/Reports/rptHalfSheetStaff.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.rptHalfSheetStaff(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();


        }










        public void monthlySalaryRequisitionHOStaff()
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



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionHOStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlySalaryRequisitionHOStaff(objReportDTO));


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
        public void monthlyEmployeeSalaryHistoryStaff()
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



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptEmployeeSalaryHistorySpecial.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlyEmployeeSalaryHistoryStaff(objReportDTO));


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

        public void monthlySalaryRequisitionBankStaff()
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



                string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyBankSalaryRequisitionStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlySalaryRequisitionBankStaff(objReportDTO));


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

        public void processSalaryRequisitionHoBankStaff()
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
            string strMsg = objReportBLL.processSalaryRequisitionHoBankStaff(objReportDTO);




        }

        public void processSalaryRequisitionHoStaff()
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
            string strMsg = objReportBLL.processSalaryRequisitionHoStaff(objReportDTO);




        }


        public void processWorkingDayStaff()
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

            string strMsg = objSalaryBLL.processWorkingDayStaff(objSalaryDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

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
                else if (txtEmployeeId.Text == string.Empty)
                {
                    string strMsg = "Please click in the Gridview!!!";
                    MessageBox(strMsg);
                    return;
                }

                else if (txtAdvanceFee.Text == string.Empty && txtArrearFee.Text == string.Empty && txtFoodAllowance.Text == string.Empty && txtFoodDeduction.Text == string.Empty && txtWorkingDay.Text == string.Empty )
                {
                    goToNextRecord();
                    searchMiscEntryStaff();
                    searchMonthLoanEntryWorker();
                    clearMessage();
                }
                else
                {
                        saveSalaryMiscEntryStaff();   
                }
            }
            catch (Exception ex)
            {
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
                    searchMiscEntryStaff();
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
                    if (txtEmployeeId.Text == string.Empty)
                    {
                        string strMsg = "Please click in the Gridview!!!";
                        MessageBox(strMsg);
                        return;
                    }
                    else
                    {
                        goToPreviousRecord();
                        searchMiscEntryStaff();
                        searchMonthLoanEntryWorker();
                        clearMessage();
                    }
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
                    searchMiscEntryStaff();
                    searchMonthLoanEntryWorker();
                    searchSalaryInfoStaff();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
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
                searchSalaryInfoStaff();

            }

            catch (Exception ex)
            {
                throw new Exception("Error :"+ex.Message);

            }
        }

        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
           
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
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

            searchMiscEntryStaff();
            searchMonthLoanEntryWorker();
            txtAdvanceFee.Focus();

        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvEmployeeList_RowDataBound(object sender, GridViewRowEventArgs e)
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

            //if (e.CommandName == "Select")
            //{

            //    int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;
            //    string strSLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            //    string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //    string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            //    string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //    string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            //    txtSL.Text = Convert.ToString(strRowId);
            //    txtCardNo.Text = strCardNo;
            //    txtEmployeeId.Text = strEmployeeId;
            //    txtEmployeeName.Text = strEmployeeName;
            //    txtDesignationName.Text = strDesignation;

            //    searchMiscEntryStaff();
            //    txtAdvanceFee.Focus();

            //}
            //if (e.CommandName == "Edit")
            //{
            //}
            //if (e.CommandName == "Delete")
            //{

            //}


            //int selectedRowIndex = gvEmployeeList.SelectedRow.RowIndex;
            //gvEmployeeList.Rows[selectedRowIndex].Cells[1].Attributes["style"] += "background-color:Red;";


        }

        #endregion
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
            //string strEmployeeId = GridView1.SelectedRow.Cells[10].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[13].Text;
            
            
            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
           
            searchMiscEntryStaff();
            searchMonthLoanEntryWorker();
            txtAdvanceFee.Focus();


        }


     
        protected void GridView1_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

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


            //    searchMiscEntryStaff();

            //    txtAdvanceFee.Focus();

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

        protected void btnProcess_Click(object sender, EventArgs e)
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
                    processSalaryStaff();
                    searchMiscEntryStaff();
                    searchSalaryInfoStaff();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }



        protected void btnMonthlyStaffSalarySheet_Click(object sender, EventArgs e)
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
                GetStaffSalarySheetAll();
                
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

        public void GetStaffSalarySheet( string bankYn)
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.BankYn = bankYn;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
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

        //--
        public void GetStaffSalarySheetAsCash()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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

                objReportDTO.PaymentMode = "3";

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = string.Empty;

                //added on 05.01.2022 from master sheet
                strPath = Path.Combine(Server.MapPath("~/Reports/RptStaffMasterSalarySheet.rpt"));

                //old: commented on 05.01.2022
                //strPath = Path.Combine(Server.MapPath("~/Reports/rptAllBankSalarySheetStaffBP.rpt"));

                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffGenericSalarySheet(objReportDTO));

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
        public void GetStaffSalarySheetAsCashOnlyBP() 
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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

                objReportDTO.PaymentMode = "2";//As Set In Bkash No

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                string strPath = string.Empty;

                strPath = Path.Combine(Server.MapPath("~/Reports/rptAllBankSalarySheetStaffBP.rpt"));

                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffGenericSalarySheet(objReportDTO));

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

        public void GetStaffMasterSalarySheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                if (objReportDTO.Year.Trim() == "2020" && (objReportDTO.Month.Trim() == "04" || objReportDTO.Month.Trim() == "4"))
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptStaffMasterSalarySheetCorona.rpt"));
                    rd.Load(strPath);
                    
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptStaffMasterSalarySheet.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffMasterSalarySheet(objReportDTO));
                }

                //master
                //string strPath = Path.Combine(Server.MapPath("~/Reports/RptStaffMasterSalarySheet.rpt"));
                //this.Context.Session["strReportPath"] = strPath;
                //rd.Load(strPath);
                //rd.SetDataSource(objReportBLL.GetStaffMasterSalarySheet(objReportDTO));

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
        public void GetAllStaffMasterSalarySheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
                objReportDTO.SectionId = null;
                objReportDTO.UnitId = null;
                objReportDTO.UnitGroupId = null;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                               
                
                string strPath = Path.Combine(Server.MapPath("~/Reports/RptAllStaffMasterSalarySheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;        
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetAllStaffMasterSalarySheet(objReportDTO));
                
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
        public void GetAllStaffBankSalarySheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
             
               string strPath = Path.Combine(Server.MapPath("~/Reports/rptAllBankSalarySheetStaffBP.rpt"));
               rd.Load(strPath);
               rd.SetDataSource(objReportBLL.GetAllStaffBankSalarySheet(objReportDTO));
       
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


        public void GetStaffSalarySheetAll()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                                
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                DateTime reportDate = DateTime.Parse(txtSalaryYear.Text + "/" + txtsalaryMonth.Text + "/01");
                DateTime coronaLimitDate = DateTime.Parse("2020" + "/" + "04" + "/30");
                
                if (objReportDTO.Year.Trim() == "2020" && (objReportDTO.Month.Trim() == "04" || objReportDTO.Month.Trim() == "4"))
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/RptStaffBkashSalarySheetCorona.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
                }
                else if (reportDate > coronaLimitDate)
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptStaffSalarySheetBkash.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
                }

                else if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheetAll(objReportDTO));
                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
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
        
        protected void btnMonthlyStaffPaySlip_Click(object sender, EventArgs e)
        {

            try
            {
                //New
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
                GetStaffSalaryPaySlip();

                //Old
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
                //    monthlyStaffSalaryPaySlip();
                //}
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


        public void GetStaffSalaryPaySlip()
        {

            try
            {

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
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
                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                if (strHeadOfficeId == "331" && strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaffForBP.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.paySlipStaff(objReportDTO));

                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaff.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffSalaryPaySlip(objReportDTO));
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

        protected void btnHalfSheetStaff_Click(object sender, EventArgs e)
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
                    HalfSalaryStaff();
                    halfSheetStaff();

                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error :" + ex.Message);
            }
        }

        protected void btnSalaryRequisitionHOStaff_Click(object sender, EventArgs e)
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

                    processSalaryRequisitionHoStaff();
                    monthlySalaryRequisitionHOStaff();

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
                else if (txtSalaryYear.Text == string.Empty)
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
                    processWorkingDayStaff();
                    searchSalaryInfoStaff();
                    searchMiscEntryStaff();
                    searchMonthLoanEntryWorker();
                }
            }

            catch (Exception ex)
            {
                //throw new Exception("Error " + ex.Message);
            }
        }

        protected void btnBankSheet_Click(object sender, EventArgs e)
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

                monthlyBankSheet();

            }
        }

        public void monthlyBankSheet()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            selectBankSalaryProcedure();


            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

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


            string strPath = Path.Combine(Server.MapPath("~/Reports/rptMonthlyBankSalarySheet.rpt"));
            this.Context.Session["strReportPath"] = strPath;
            rd.Load(strPath);
            rd.SetDataSource(objReportBLL.montlyBankSalaryList(objReportDTO));


            rd.SetDatabaseLogon("erp", "erp");
            CrystalReportViewer1.ReportSource = rd;
            CrystalReportViewer1.DataBind();

            reportMaster();

        }



        public void selectBankSalaryProcedure()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

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

            string strMsg = objReportBLL.selectBankSalaryProcedure(objReportDTO);
            MessageBox(strMsg);




        }

        protected void btnBankRequisitionSheet_Click(object sender, EventArgs e)
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

                    processSalaryRequisitionHoBankStaff();
                    monthlySalaryRequisitionBankStaff();

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

        protected void btnEmployeeGrossHistory_Click(object sender, EventArgs e)
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

                    processSalaryRequisitionHoStaff();
                    monthlyEmployeeSalaryHistoryStaff();

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
                GetStaffSalarySheetAsCash();
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

        protected void btnBankSheetDetail_Click(object sender, EventArgs e)
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
                // GetStaffSalarySheet("N");
                GetStaffSalaryBankSheetDetail();
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

        protected void btnRequisitionSheetDetail_Click(object sender, EventArgs e)
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
                    processSalaryRequisitionDetail();
                    GetMonthlySalaryRequisitionDetailStaff();
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

        public void GetStaffSalaryBankSheetDetail()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                if (objReportDTO.Year.Trim() == "2020" && (objReportDTO.Month.Trim() == "04" || objReportDTO.Month.Trim() == "4"))
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptBankSalarySheetStaffForCorona.rpt"));
                    rd.Load(strPath);
                    //rd.SetDataSource(objReportBLL.GetSalarySheetStaffAsBank(objReportDTO));
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheetDetailASBank(objReportDTO));
                }
               else if (strBranchOfficeId == "110")
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaffBP.rpt"));
                    rd.Load(strPath);
                    //rd.SetDataSource(objReportBLL.SalarySheetStaff(objReportDTO));
                    rd.SetDataSource(objReportBLL.GetStaffSalaryBankSheetDetail(objReportDTO));
                    //GetStaffSalaryBankSheetDetail
                }
                else
                {
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalarySheetStaff.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffSalarySheet(objReportDTO));
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

        public void processSalaryRequisitionDetail()
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
            string strMsg = objReportBLL.processSalaryRequisitionDetail(objReportDTO);
        }

        public void GetMonthlySalaryRequisitionDetailStaff()
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

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptSalaryRequisitionHOStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetMonthlySalaryRequisitionDetailStaff(objReportDTO));

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

        protected void btnMonthlyStaffGrossSalarySheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (strEmployeeId != "121" && strEmployeeId != "992")
                {
                    string Msg = "Access Denied";
                    MessageBox(Msg);
                    return;
                }
                //New
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
                GetStaffGrossSalarySheet();

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

        //public void GetStaffGrossSalarySheet()
        //{
        //    try
        //    {
        //        ReportDTO objReportDTO = new ReportDTO();
        //        ReportBLL objReportBLL = new ReportBLL();

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
        //        objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
        //        objReportDTO.EmployeeId = txtEmpId.Text;
        //        objReportDTO.CardNo = txtEmpCardNo.Text;

        //        objReportDTO.Year = txtSalaryYear.Text;
        //        objReportDTO.Month = txtsalaryMonth.Text;
        //        if (txtFirstSalary.Text == "")
        //            objReportDTO.FirstSalary = "-1";
        //        else
        //            objReportDTO.FirstSalary = txtFirstSalary.Text;
        //        objReportDTO.HeadOfficeId = strHeadOfficeId;
        //        objReportDTO.BranchOfficeId = strBranchOfficeId;
        //        objReportDTO.UpdateBy = strEmployeeId;


        //        string strPath = Path.Combine(Server.MapPath("~/Reports/rptGrossSalarySheetStaff.rpt"));
        //        rd.Load(strPath);
        //        rd.SetDataSource(objReportBLL.GetStaffGrossSalarySheet(objReportDTO));

        //        rd.SetDatabaseLogon("erp", "erp");
        //        CrystalReportViewer1.ReportSource = rd;
        //        CrystalReportViewer1.DataBind();
        //        reportMaster();
        //        //ReportMasterTestByAsad();
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
        public void GetStaffGrossSalarySheet()
        {
            try
            {
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

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
                objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;
                objReportDTO.EmployeeId = txtEmpId.Text;
                objReportDTO.CardNo = txtEmpCardNo.Text;

                objReportDTO.Year = txtSalaryYear.Text;
                objReportDTO.Month = txtsalaryMonth.Text;
                if (txtFirstSalary.Text == "")
                    objReportDTO.FirstSalary = "-1";
                else
                    objReportDTO.FirstSalary = txtFirstSalary.Text;
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                string strPath = "";
                if (txtFirstSalary.Text == "14999")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptGrossSalarySheetStaff.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffGrossSalarySheet(objReportDTO));
                }
                else
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptTotalGrossSalarySheetStaff.rpt"));
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetTotalfGrossSalarySheetStaff(objReportDTO));
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

        protected void btnSalaryRequisitionStaff_Click(object sender, EventArgs e)
        {
            try
            {
                GetStaffSalaryRequisition();
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
        public void GetStaffSalaryRequisition()
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

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptStaffSalaryRequisition.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffSalaryRequisition(objReportDTO));

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

        protected void btnBankSalarySheetStaff_Click(object sender, EventArgs e)
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

                    GetStaffBankSalarySheetByUnitGroup();
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
        public void GetStaffBankSalarySheetByUnitGroup()
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


                string strPath = Path.Combine(Server.MapPath("~/Reports/rptBankSalarySheetStaff.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetStaffBankSalarySheetByUnitGroup(objReportDTO));


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

        protected void btnStafBKashTemplate_Click(object sender, EventArgs e)
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
                GetBKashSheetStaff();
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

        public void GetBKashSheetStaff()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = "1";
                objReportDTO.Year = txtSalaryYear.Text.Trim();
                objReportDTO.Month = txtsalaryMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;

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

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                //rd.SetDataSource(objReportBLL.GetWalletSheet(objReportDTO));

                //for search
                if (objReportDTO.SectionId.Length == 0 & objReportDTO.UnitId.Length == 0)
                {
                    rd.SetDataSource(objReportBLL.GetWalletSheet(objReportDTO));
                }
                else if (objReportDTO.UnitId.Length > 0 & objReportDTO.SectionId.Length == 0)
                {
                    rd.SetDataSource(objReportBLL.GetWalletSheetUnitID(objReportDTO));
                }
                else if (objReportDTO.UnitId.Length == 0 & objReportDTO.SectionId.Length > 0)
                {
                    rd.SetDataSource(objReportBLL.GetWalletSheetSectionID(objReportDTO));
                }
                else
                {
                    rd.SetDataSource(objReportBLL.GetWalletSheetUnitSectionID(objReportDTO));
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
                                
        protected void BtnMasterSalarySheet_Click(object sender, EventArgs e)
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
                GetStaffMasterSalarySheet();
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

        protected void btnBkashRequisition_Click(object sender, EventArgs e)
        {
            try
            {
                GetStaffBKashSalaryReq();
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

        public void GetStaffBKashSalaryReq()
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
                rd.SetDataSource(objReportBLL.GetStaffBKashSalaryReq(objReportDTO));

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

                if (ddlUnitGroupId.SelectedItem.Value == "" && ddlUnitId.Text == " " && ddlSectionId.Text == " ")
                {
                    GetAllStaffMasterSalarySheet();
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

        protected void BtnBankSheetAll_Click(object sender, EventArgs e)
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
               
                GetAllStaffBankSalarySheet();
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
            //try
            //{

            //    if (ddlUnitGroupId.SelectedItem.Value == "" && ddlUnitId.Text == " " && ddlSectionId.Text == " ")
            //    {
            //        GetAllStaffBankSalarySheet();
            //    }
            //    else
            //    {
            //        MessageBox("Please deselect unit, section.");
            //        return;
            //    }

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

        protected void BtnCashSheetAll_Click(object sender, EventArgs e)
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
                GetStaffSalarySheetAsCashOnlyBP();
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