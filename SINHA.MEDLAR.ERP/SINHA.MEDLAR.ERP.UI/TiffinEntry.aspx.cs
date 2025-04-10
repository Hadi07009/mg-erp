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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class TiffinEntry : System.Web.UI.Page
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

            loadSesscion();
            if (strEmployeeId == "117" || strEmployeeId == "130")
            {
                btnTiffinRequsitionSummery.Visible = false;
                btnTiffinRequsition.Visible = false;
                btnTiffinSheet.Visible = false;
            }
            else
            {
                btnTiffinRequsitionSummery.Visible = true;
                btnTiffinRequsition.Visible = true;
                btnTiffinSheet.Visible = true;
            }

            if (!IsPostBack)
            {
                //loadSesscion();
                getUnitId();
                getSectionId();
                //GetEventPermission();
                clearMsg();
                getOfficeName();
                getMonthYearForSalary();
                btnSearch.Focus();
            }
            if (IsPostBack)
            {
                //loadSesscion();
            }

            //NEW
            //txtTiffinDay.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
            //OLD
            //txtTiffinDay.Attributes.Add("onkeypress", "return controlEnter('" + txtTiffinDayAdditional.ClientID + "', event)");
            //txtTiffinDayAdditional.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }
        

        #region "FUNCTION"

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
        //public void GetEventPermission()
        //{
        //    EventPermissionDTO objEventPermissionDTO = new EventPermissionDTO();
        //    EmployeeBLL objEmployeeBLL = new EmployeeBLL();
        //    DataTable dt = new DataTable();
        //    objEventPermissionDTO.UpdateBy = strEmployeeId;
        //    objEventPermissionDTO.MenuCode = "0003";
        //    objEventPermissionDTO.HeadOfficeId = strHeadOfficeId;
        //    objEventPermissionDTO.BranchOfficeId = strBranchOfficeId;
        //    var basicInfo = objEmployeeBLL.GetEventPermission(objEventPermissionDTO);

        //    if (basicInfo.DisableSave == "1")
        //        btnSave.Visible = false;
        //    else
        //        btnSave.Visible = true;

        //    if (basicInfo.DisableAtten == "1")
        //        btnAdd.Visible = false;
        //    else
        //        btnAdd.Visible = true;
        //}
        public void getMonthYearForSalary()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtYear.Text = objLookUpDTO.Year;
            txtMonth.Text = objLookUpDTO.Month;

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

        public void getTiffinDay()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            objTiffinDTO = objTiffinBLL.getTiffinDay(txtEmployeeId.Text, txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);

            if (objTiffinDTO.TiffinDay == string.Empty)
            {
                txtTiffinDay.Text = "";

            }
            else
            {

                txtTiffinDay.Text = objTiffinDTO.TiffinDay;
            }

        }

        public void getTiffinAmount()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            objTiffinDTO = objTiffinBLL.getTiffinAmount(txtEmployeeId.Text, txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);

            if (objTiffinDTO.TiffinAmount == string.Empty)
            {
                txtTiffinAmount.Text = "";

            }
            else
            {

                txtTiffinAmount.Text = objTiffinDTO.TiffinAmount;
            }

        }

        public void getIftarDayOnly()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            objTiffinDTO = objTiffinBLL.getIftarDayOnly(txtEmployeeId.Text, txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);

            if (objTiffinDTO.I_Day == string.Empty)
            {
                txtIftarDay.Text = "";

            }
            else
            {

                txtIftarDay.Text = objTiffinDTO.I_Day;
            }

        }

        public void getTiffinDayOnly()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            objTiffinDTO = objTiffinBLL.getTiffinDayOnly(txtEmployeeId.Text, txtYear.Text, txtMonth.Text, strHeadOfficeId, strBranchOfficeId);

            if (objTiffinDTO.T_Day == string.Empty)
            {
                txtTDay.Text = "";

            }
            else
            {

                txtTDay.Text = objTiffinDTO.T_Day;
            }

        }



        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        public void searchEmployeeRecordforTiffin()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            DataTable dt = new DataTable();

            objTiffinDTO.Year = txtYear.Text.Trim();
            objTiffinDTO.Month = txtMonth.Text.Trim();

            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;
            objTiffinDTO.EmployeeId = txtEmpId.Text;
            objTiffinDTO.CardNo = txtEmpCardNo.Text;



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





            dt = objTiffinBLL.searchEmployeeRecordforTiffin(objTiffinDTO);


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
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsg.Text = strMsg;
            }

        }
        public void searchTiffinEntry()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            DataTable dt = new DataTable();


            objTiffinDTO.HeadOfficeId = strHeadOfficeId;
            objTiffinDTO.BranchOfficeId = strBranchOfficeId;
            objTiffinDTO.EmployeeId = txtEmpId.Text;
            objTiffinDTO.CardNo = txtEmpCardNo.Text;
            objTiffinDTO.Year = txtYear.Text;
            objTiffinDTO.Month = txtMonth.Text;

            objTiffinDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

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

            dt = objTiffinBLL.searchTiffinEntry(objTiffinDTO);

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

        public void goToNextRecordTop()
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
                
                string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
                string strDesignation = GridView1.SelectedRow.Cells[3].Text;
                string strCardNo = GridView1.SelectedRow.Cells[1].Text;
                string strEmployeeId = GridView1.SelectedRow.Cells[5].Text;

                //old
                //string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                //string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
                //string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                //string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;


                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;

                txtTiffinDay.Focus();
                txtTiffinAmount.Focus();

            }
        }
        public void goToNextRecordBottom()
        {

            if (txtSL.Text == string.Empty)
            {
                txtSL.Text = "1";
            }

            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            
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
                string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
                string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
                string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
                string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
                
                txtSL.Text = Convert.ToString(strRowId);
                txtCardNo.Text = strCardNo;
                txtEmployeeId.Text = strEmployeeId;
                txtEmployeeName.Text = strEmployeeName;
                txtDesignationName.Text = strDesignation;
                txtTiffinDay.Focus();
                txtTiffinAmount.Focus();
            }
        }
        public void goToPreviousRecordTop()
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
                    txtTiffinDay.Focus();
                    txtTiffinAmount.Focus();
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
                    txtTiffinDay.Focus();
                    txtTiffinAmount.Focus();
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
                        
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;

            //new
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[5].Text;

            //old
            //string strCardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            //string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            //string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            //string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;


            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;


            txtTiffinDay.Focus();
            txtTiffinAmount.Focus();

        }
        public void goToPreviousRecordBottom()
        {
            int i = 1, j, k, result;
            j = Convert.ToInt32(txtSL.Text);
            k = j;
            
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
                    txtTiffinDay.Focus();
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
                int intCountRow = GridView1.Rows.Count;
                int p = intCountRow;
                if (intCountRow == p)
                {
                    string strMsg = "There is no Data for the Previous Record!!!";
                    MessageBox(strMsg);
                    txtTiffinDay.Focus();
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
            string strEmployeeId = gvEmployeeList.SelectedRow.Cells[4].Text;
            string strEmployeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string strDesignation = gvEmployeeList.SelectedRow.Cells[3].Text;
            
            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            txtTiffinDay.Focus();
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
            txtTiffinDay.Text = string.Empty;
            txtTiffinAmount.Text = string.Empty;
            txtTDay.Text = string.Empty;
            txtIftarDay.Text = string.Empty;
            //txtTiffinDayAdditional.Text = string.Empty;   
        }


        public void clearMessage()
        {

            lblMsg.Text = string.Empty;
        }
        public void saveTiffinInfo()
        {
            
            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();
            
            objTiffinDTO.EmployeeId = txtEmployeeId.Text;
            objTiffinDTO.Year = txtYear.Text;
            objTiffinDTO.Month = txtMonth.Text;
            objTiffinDTO.TiffinDay = txtTiffinDay.Text;
            objTiffinDTO.TiffinAmount = txtTiffinAmount.Text;
            objTiffinDTO.T_Day = txtTDay.Text;
            objTiffinDTO.I_Day = txtIftarDay.Text; 

            //objTiffinDTO.TiffinDayAdditional = txtTiffinDayAdditional.Text;

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
            
            string strMsg = objTiffinBLL.saveTiffinInfo(objTiffinDTO);
            lblMsg.Text = strMsg;

            if (strMsg == "PLEASE CHECK TIFFIN DAY!!!" ||  strMsg == "TIFFIN ENTRY HAS BEEN LOCKED!!!")
            {
                MessageBox(strMsg);
                clearMessage();
                return;
            }
            else
            {

                if (HfGridView.Value == "Top")
                {
                    clearTextBox();
                    goToNextRecordTop();
                    getTiffinDay();
                    getTiffinAmount();
                    getTiffinDayOnly();
                    getIftarDayOnly();
                    searchTiffinEntry();
                }
                if (HfGridView.Value == "Bottom")
                {
                    clearTextBox();
                    goToNextRecordBottom();
                    getTiffinDay();
                    getTiffinAmount();
                    getTiffinDayOnly();
                    getIftarDayOnly();
                    searchTiffinEntry();
                }

                //old
                //clearTextBox();
                //goToNextRecordTop();
                //getTiffinDay();
                //searchTiffinEntry();
            }
        }

        public void monthlyDayForTiffin()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();
                      
            objTiffinDTO.Year = txtYear.Text;
            objTiffinDTO.Month = txtMonth.Text;

            objTiffinDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

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


            string strMsg = objTiffinBLL.monthlyDayForTiffin(objTiffinDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            
        }

        public void monthlyDayForTiffinStaff()
        {

            TiffinDTO objTiffinDTO = new TiffinDTO();
            TiffinBLL objTiffinBLL = new TiffinBLL();

            objTiffinDTO.Year = txtYear.Text;
            objTiffinDTO.Month = txtMonth.Text;

            objTiffinDTO.UnitGroupId = ddlUnitGroupId.SelectedItem.Value;

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


            string strMsg = objTiffinBLL.monthlyDayForTiffinStaff(objTiffinDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        public void monthlyTiffinSheet()
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

                string strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                DataSet ds = new DataSet();

                ds = (objReportBLL.monthlyTiffinSheetWorker(objReportDTO));
                rd.SetDataSource(ds);
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

        //New
        public void GetWorkerTiffinSheetByUnitGroup()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                //new
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;

                
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
                //end

                string strPath = null; 
                if (objReportDTO.Year == "2025" && objReportDTO.Month.Trim() == "03")
                {
                     strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinSheetIfter.rpt"));
                }
                else if (objReportDTO.Year == "2024" && objReportDTO.Month.Trim() == "04")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinSheetIfter.rpt"));
                }
                else
                {
                     strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinSheet.rpt"));
                }
                


                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                //DataSet ds = new DataSet();
                DataTable ds = new DataTable();

                ds = (objReportBLL.GetWorkerTiffinSheetByUnitGroup(objReportDTO));
                rd.SetDataSource(ds);
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

                rd.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, Response, true, "tiffin_sheet");
                Response.End();
                CrystalReportViewer1.RefreshReport();
            }
        }

        public void tiffinRequisition()
        {

            try
            {



                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                processTiffinRequisition();


                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;


                objReportDTO.EmployeeId = txtEmpId.Text;

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


                string strPath = null;
                if (objReportDTO.Year == "2025" && objReportDTO.Month.Trim() == "03")
                {
                     strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisitionIfter.rpt"));
                }
                else if (objReportDTO.Year == "2024" && objReportDTO.Month.Trim() == "04")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisitionIfter.rpt"));
                }
                else
                {
                     strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisition.rpt"));
                }


                
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.monthlyTiffinRequisition(objReportDTO));


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
        public void tiffinRequisitionSummery()
        {

            try
            {
                
                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;
                
                objReportDTO.EmployeeId = txtEmpId.Text;

                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;



                string strPath = null;
                if (objReportDTO.Year == "2025" && objReportDTO.Month.Trim() == "03")
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisitionSIT.rpt"));
                }                
                else
                {
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinRequisitionSummery.rpt"));
                }

                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                //rd.SetDataSource(objReportBLL.monthlyTiffinRequisitionSummery(objReportDTO));
                rd.SetDataSource(objReportBLL.GetTiffinRequisitionSummary(objReportDTO));
                
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

        public void processTiffinRequisition()
        {

            ReportDTO objReportDTO = new ReportDTO();
            ReportBLL objReportBLL = new ReportBLL();

            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.EmployeeId = txtEmpId.Text;

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



            objReportDTO.HeadOfficeId = strHeadOfficeId;
            objReportDTO.BranchOfficeId = strBranchOfficeId;
            objReportDTO.UpdateBy = strEmployeeId;

            string strMsg = objReportBLL.processTiffinRequisition(objReportDTO);




        }

        #endregion
        #region "Grid View Functionality"
        protected void gvEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEmployeeList.PageIndex = e.NewPageIndex;
            searchEmployeeRecordforTiffin();
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            HfGridView.Value = "Bottom";

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


            getTiffinDay();
            txtTiffinDay.Focus();
            getTiffinAmount();
            txtTiffinAmount.Focus();
            getTiffinDayOnly();
            txtTDay.Focus();
            getIftarDayOnly();
            txtIftarDay.Focus();



        }




        protected void gvEmployeeList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {




        }


        protected void gvEmployeeList_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }

        protected void gvEmployeeList_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvEmployeeList, "Select$" + e.Row.RowIndex);
            }
        }







        private string GridViewSortDirection
        {
            get { return ViewState["SortDirection"] as string ?? "DESC"; }
            set { ViewState["SortDirection"] = value; }
        }

      

        protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        #endregion
        #region "Grid View Functionality2"
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            //searchIncrementHoldInfo();
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            HfGridView.Value = "Top";

            int strRowId = GridView1.SelectedRow.RowIndex + 1;
            string strSLNo = GridView1.SelectedRow.Cells[0].Text;
            string strCardNo = GridView1.SelectedRow.Cells[1].Text;
            string strEmployeeName = GridView1.SelectedRow.Cells[2].Text;
            string strDesignation = GridView1.SelectedRow.Cells[3].Text;
            //string AdditionalDay = GridView1.SelectedRow.Cells[5].Text;
            string strEmployeeId = GridView1.SelectedRow.Cells[5].Text;

            txtSL.Text = Convert.ToString(strRowId);
            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = strEmployeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;
            //txtTiffinDayAdditional.Text = AdditionalDay;

            getTiffinDay();
            txtTiffinDay.Focus();
            getTiffinAmount();
            txtTiffinAmount.Focus();
            getTiffinDayOnly();
            txtTDay.Focus();
            getIftarDayOnly();
            txtIftarDay.Focus();

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
                    searchEmployeeRecordforTiffin();
                    clearYellowTextBox();
                    clearTextBox();

                    //commented on 07.12.2020
                    //gvEmployeeList.SelectedIndex = 0;
                    //GridView1.SelectedIndex = 0;
                                        
                    searchTiffinEntry();

                    HfGridView.Value = string.Empty;

                    if (GridView1.Rows.Count > 0)
                    {
                        HfGridView.Value = "Top";
                        GridView1.SelectedIndex = 0;
                        goToNextRecordTop();
                    }
                    else
                    {
                        if (gvEmployeeList.Rows.Count > 0)
                        {
                            HfGridView.Value = "Bottom";
                            gvEmployeeList.SelectedIndex = 0;
                            goToNextRecordBottom();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {

                searchTiffinEntry();


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
                if (HfGridView.Value == "Top")
                {
                    goToNextRecordTop();
                    getTiffinDay();
                    getTiffinAmount();
                    getTiffinDayOnly();
                    getIftarDayOnly();
                }
                if (HfGridView.Value == "Bottom")
                {
                    goToNextRecordBottom();
                    getTiffinDay();
                    getTiffinAmount();
                    getTiffinDayOnly();
                    getIftarDayOnly();
                }
                clearMessage();

                //if (gvEmployeeList.Rows.Count == 0)
                //{
                //    string strMsg = "Please click searh Button!!!";
                //    MessageBox(strMsg);
                //    btnSearch.Focus();
                //    return;
                //}
                //else
                //{
                //    goToNextRecord();
                //    getTiffinDay();
                //    clearMessage();
                //}
            }

            catch (Exception ex)
            {
               // throw new Exception("Error " + ex.Message);
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if(HfGridView.Value == "Top")
                {
                    goToPreviousRecordTop();
                    getTiffinDay();
                    getTiffinAmount();
                    getTiffinDayOnly();
                    getIftarDayOnly();

                }
                if (HfGridView.Value == "Bottom")
                {
                    goToPreviousRecordBottom();
                    getTiffinDay();
                    getTiffinAmount();
                    getTiffinDayOnly();
                    getIftarDayOnly();
                }
                clearMessage();

                //if (gvEmployeeList.Rows.Count == 0)
                //{
                //    string strMsg = "Please click searh Button!!!";
                //    MessageBox(strMsg);
                //    btnSearch.Focus();
                //    return;
                //}
                //else
                //{
                //    goToPreviousRecord();
                //    getTiffinDay();
                //    clearMessage();
                //}
            }
            catch (Exception ex)
            {
                //throw new Exception("Error " + ex.Message);
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
                    btnSearch.Focus();
                    return;
                }

                else if (txtTiffinDay.Text == string.Empty)
                {
                    //old

                    if (HfGridView.Value == "Top")
                    {
                        goToNextRecordTop();
                        getTiffinDay();
                        getTiffinAmount();
                        getTiffinDayOnly();
                        getIftarDayOnly();
                    }
                    if (HfGridView.Value == "Bottom")
                    {
                        goToNextRecordBottom();
                        getTiffinDay();
                        getTiffinAmount();
                        getTiffinDayOnly();
                        getIftarDayOnly();
                    }
                    clearMessage();

                    //goToNextRecordTop();
                    //getTiffinDay();
                    //clearMessage();
                }
                else
                {
                    saveTiffinInfo();
                }
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);

            }
        }

        protected void btnTiffinSheet_Click(object sender, EventArgs e)
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

                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
                    return;
                }
                GetWorkerTiffinSheetByUnitGroup();
                
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

                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
                    return;
                }
                GetTiffinBkashSheetByUnitGroup();

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

                if (ddlEmployeeTypeId.SelectedItem.Value == "")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmployeeTypeId.Focus();
                    return;
                }
                GetTiffinCashSheetByUnitGroup();

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

        protected void btnBkashReq_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text == " ")
                {
                    string strMsg = "Please Type Tiffin Year";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (txtMonth.Text == " ")
                {
                    string strMsg = "Please Type Tiffin Month";
                    MessageBox(strMsg);
                    txtMonth.Focus();
                    return;
                }
                else
                {
                    GetTiffinBKashReqAll();
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
        public void GetTiffinBkashSheetByUnitGroup()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                //new
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;
                objReportDTO.PaymentMode = "2";


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
                //end

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptStaffWorkerTiffinSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                //DataSet ds = new DataSet();
                DataTable ds = new DataTable();

                ds = (objReportBLL.GetTiffinBkashSheetByUnitGroup(objReportDTO));
                rd.SetDataSource(ds);
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
        public void GetTiffinCashSheetByUnitGroup()
        {
            try
            {


                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();
                //new
                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.UpdateBy = strEmployeeId;

                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;
                objReportDTO.PaymentMode = "3";


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
                //end

                string strPath = Path.Combine(Server.MapPath("~/Reports/RptStaffWorkerTiffinSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                //DataSet ds = new DataSet();
                DataTable ds = new DataTable();

                ds = (objReportBLL.GetTiffinCashSheetByUnitGroup(objReportDTO));
                rd.SetDataSource(ds);
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
        public void GetTiffinBKashReqAll()
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
                }

                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptTiffinBKashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetTiffinBKashReqAll(objReportDTO));

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
        public void GetTiffinCashReqAll()
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
                if (ddlUnitGroupId.SelectedValue.ToString() != "")
                {
                    objReportDTO.UnitGroupId = ddlUnitGroupId.SelectedValue.ToString();
                }
                else
                {
                    objReportDTO.UnitGroupId = "";
                }

                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;


                string strPath = Path.Combine(Server.MapPath("~/Reports/RptTiffinBKashReq.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);
                rd.SetDataSource(objReportBLL.GetTiffinCashReqAll(objReportDTO));

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

        protected void btnCashReq_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text == " ")
                {
                    string strMsg = "Please Type Tiffin Year";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }
                if (txtMonth.Text == " ")
                {
                    string strMsg = "Please Type Tiffin Month";
                    MessageBox(strMsg);
                    txtMonth.Focus();
                    return;
                }
                else
                {
                    GetTiffinCashReqAll();
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
        protected void btnTiffinRequsition_Click(object sender, EventArgs e)
        {
            try
            {

                tiffinRequisition();

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

        protected void btnTiffinRequsitionSummery_Click(object sender, EventArgs e)
        {
            try
            {

                tiffinRequisitionSummery();

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

            if (ddlEmployeeTypeId.SelectedValue=="2")
            {
                monthlyDayForTiffin();
            }
            else if (ddlEmployeeTypeId.SelectedValue == "1")
            {
                monthlyDayForTiffinStaff();
            }
            else
            {
                string strMsg = "Please Select Employee Type!!!";
                MessageBox(strMsg);
                ddlEmployeeTypeId.Focus();
                return;
            }       
            
            //COMMENTED ON 06.04.2021
            //searchTiffinEntry();
            
        }

        protected void btnTiffinWalletSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtYear.Focus();
                    return;
                }

                if (txtMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Month!!!";
                    MessageBox(strMsg);
                    txtMonth.Focus();
                    return;
                }
                GetTiffinWalletSheet();
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
        public void GetTiffinWalletSheet()
        {

            try
            {
                string strDefaultName = "Report";
                ExportFormatType formatType = ExportFormatType.NoFormat;

                ReportDTO objReportDTO = new ReportDTO();
                ReportBLL objReportBLL = new ReportBLL();

                objReportDTO.HeadOfficeId = strHeadOfficeId;
                objReportDTO.BranchOfficeId = strBranchOfficeId;
                objReportDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue;
                objReportDTO.Year = txtYear.Text.Trim();
                objReportDTO.Month = txtMonth.Text.Trim();
                objReportDTO.UpdateBy = strEmployeeId;
                                
                string strPath = Path.Combine(Server.MapPath("~/Reports/rptTiffinWalletSheet.rpt"));
                this.Context.Session["strReportPath"] = strPath;
                rd.Load(strPath);

                if (objReportDTO.EmployeeTypeId == "")
                {
                    rd.SetDataSource(objReportBLL.GetTiffinWalletSheet(objReportDTO));
                }
                else
                {
                    rd.SetDataSource(objReportBLL.GetTiffinWalletSheetByEType(objReportDTO));
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
        }


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

                objReportDTO.Year = txtYear.Text;
                objReportDTO.Month = txtMonth.Text;
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

                if (objReportDTO.EmployeeTypeId == "1") //Staff
                {   //
                    string strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipStaffTiffin.rpt"));
                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);
                    rd.SetDataSource(objReportBLL.GetStaffPaySlipTiffin(objReportDTO));
                }

                if (objReportDTO.EmployeeTypeId == "2")
                {
                    string strPath = string.Empty;
                    strPath = Path.Combine(Server.MapPath("~/Reports/rptPaySlipWorkerTiffin.rpt"));

                    this.Context.Session["strReportPath"] = strPath;
                    rd.Load(strPath);                    
                    rd.SetDataSource(objReportBLL.GetWorkerPaySlipTiffin(objReportDTO));
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
    }
}