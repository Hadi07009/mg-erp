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

using Oracle.ManagedDataAccess.Client;


using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

using System.Web.Security;
using System.Text;
using System.Security.Cryptography;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class AddHalfSalary : System.Web.UI.Page
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
        string strID = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["strEmployeeId"] == null)
            {
                sessionEmpty();
                return;
            }

            if (!IsPostBack)
            {


                //load DropDown List
                loadSesscion();
                getOfficeName();
                getMonthId();
                getEmployeeTypeId();
                getMonthYearForTax();
                loadHalfSalaryInfo();
                lblMsg.Text = string.Empty;
                lblMsgRecord.Text = string.Empty;
               


            }
            if (IsPostBack)
            {

                loadSesscion();
                Session["strID"] = null;
            }
           
        }


        #region "Function"
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
        public void getEmployeeTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmployeeTypeId.DataSource = objLookUpBLL.getEmployeeTypeId();

            ddlEmployeeTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
            ddlEmployeeTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

            ddlEmployeeTypeId.DataBind();
            if (ddlEmployeeTypeId.Items.Count > 0)
            {

                ddlEmployeeTypeId.SelectedIndex = 0;
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

            if (Session["strID"] != null)
            {
                strID = Session["strID"].ToString().Trim();
            }


        }


        public void getMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSalaryMonthId.DataSource = objLookUpBLL.getMonthId();

            ddlSalaryMonthId.DataTextField = "MONTH_NAME";
            ddlSalaryMonthId.DataValueField = "MONTH_ID";

            ddlSalaryMonthId.DataBind();
            if (ddlSalaryMonthId.Items.Count > 0)
            {

                ddlSalaryMonthId.SelectedIndex = 0;
            }

        }


        public void clear()
        {

            txtSalaryYear.Text = "";
            txtWorkingDay.Text = "";
            ddlEmployeeTypeId.Text = " ";

            getMonthId();

        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void loadHalfSalaryInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadHalfSalaryInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                int totalcolums = gvUnit.Rows[0].Cells.Count;
                gvUnit.Rows[0].Cells.Clear();
                gvUnit.Rows[0].Cells.Add(new TableCell());
                gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }


        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtSalaryYear.Text = objLookUpDTO.Year;
           

        }

      



        public void saveHalfSalaryInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.Year = txtSalaryYear.Text;
            objLookUpDTO.Month = ddlSalaryMonthId.SelectedValue.ToString();
            objLookUpDTO.SalaryDay = txtWorkingDay.Text;
            objLookUpDTO.PercentAmount = txtSalaryPercentage.Text;
            if (ddlEmployeeTypeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.EmployeeTypeId = "";
            }
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.UpdateBy = strEmployeeId;

            string strMsg = objLookUpBLL.saveHalfSalaryInfo(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
           


        }

        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }


        #region "GridviewFunctionality"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
           
        }

        protected void gvUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strUnitId = gvUnit.SelectedRow.RowIndex;
            string strGradeId = gvUnit.SelectedRow.Cells[0].Text;
            string strSalaryYear = gvUnit.SelectedRow.Cells[1].Text;           
            string strWorkingDay = gvUnit.SelectedRow.Cells[3].Text;
            string  strSalaryMonth = gvUnit.SelectedRow.Cells[2].Text;

            txtSalaryYear.Text = strSalaryYear;
            txtWorkingDay.Text = strWorkingDay;

            string strSalaryPercentage = gvUnit.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string EmployeeType = gvUnit.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            if (EmployeeType == "")
            {
                return;
            }
            ddlEmployeeTypeId.Text = EmployeeType;
            txtSalaryPercentage.Text = strSalaryPercentage;

            if (strSalaryMonth == "JANUARY")
            {

                ddlSalaryMonthId.SelectedIndex = 1;

            }
            if (strSalaryMonth == "FEBRUARY")
            {

                ddlSalaryMonthId.SelectedIndex = 2;

            }

            if (strSalaryMonth == "MARCH")
            {

                ddlSalaryMonthId.SelectedIndex = 3;

            }

            if (strSalaryMonth == "APRIL")
            {

                ddlSalaryMonthId.SelectedIndex = 4;

            }
            if (strSalaryMonth == "MAY")
            {

                ddlSalaryMonthId.SelectedIndex = 5;

            }
            if (strSalaryMonth == "JUNE")
            {

                ddlSalaryMonthId.SelectedIndex = 6;

            }
            if (strSalaryMonth == "JULY")
            {

                ddlSalaryMonthId.SelectedIndex = 7;

            }
            if (strSalaryMonth == "AUGUST")
            {

                ddlSalaryMonthId.SelectedIndex = 8;

            }
            if (strSalaryMonth == "SEPTEMBER")
            {

                ddlSalaryMonthId.SelectedIndex = 9;

            }
            if (strSalaryMonth == "OCTOBER")
            {

                ddlSalaryMonthId.SelectedIndex = 10;

            }
            if (strSalaryMonth == "NOVEMBER")
            {

                ddlSalaryMonthId.SelectedIndex = 11;

            }
            if (strSalaryMonth == "DECEMBER")
            {

                ddlSalaryMonthId.SelectedIndex = 12;

            }



            //string strMsg = "Row Index: " + strUnitId + "\\nID: " + strGradeId + "\\nGrade: " + strGradeName;
            //MessageBox(strMsg);
        }
        //protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        //{
        //    e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
        //    e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        //}

        //protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUnit, "Edit$" + e.Row.RowIndex);
        //        e.Row.Attributes["style"] = "cursor:pointer";
        //    }
        //}




        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }


        protected void gvUnit_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvUnit_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUnit.EditIndex = e.NewEditIndex;
           
        }



        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if(txtSalaryYear.Text == "")
                {
                    string strMsg = "Please Enter Year!!!";
                    txtSalaryYear.Focus();
                    MessageBox(strMsg);
                    return;
                }

                 if (ddlSalaryMonthId.Text == "0")
                {
                    string strMsg = "Please Select Month!!!";
                    ddlSalaryMonthId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (ddlEmployeeTypeId.Text == " ")
                {
                    string strMsg = "Please Select Employee Type!!!";
                    ddlEmployeeTypeId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (txtWorkingDay.Text == "" && txtSalaryPercentage.Text == "")
                {
                    string strMsg = "Please Enter Working Day Or Salary Percentage!!!";
                    txtWorkingDay.Focus();
                    MessageBox(strMsg);
                    return;
                }

                else
                {

                saveHalfSalaryInfo();
                loadHalfSalaryInfo();


                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);

            }
        }
    }
}