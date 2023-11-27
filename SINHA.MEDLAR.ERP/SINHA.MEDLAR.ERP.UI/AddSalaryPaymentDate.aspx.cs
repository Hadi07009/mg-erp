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
    public partial class AddSalaryPaymentDate : System.Web.UI.Page
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
                getMonthYearForTax();
                loadSalaryPaymentDateInfo();
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
            dtpPaymentDate.Text = "";
            getMonthId();

        }

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }


        public void loadSalaryPaymentDateInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadSalaryPaymentDateInfo(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvSalaryPaymentdate.DataSource = dt;
                gvSalaryPaymentdate.DataBind();
                string strMsg = "TOTAL " + gvSalaryPaymentdate.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvSalaryPaymentdate.DataSource = dt;
                gvSalaryPaymentdate.DataBind();
                int totalcolums = gvSalaryPaymentdate.Rows[0].Cells.Count;
                gvSalaryPaymentdate.Rows[0].Cells.Clear();
                gvSalaryPaymentdate.Rows[0].Cells.Add(new TableCell());
                gvSalaryPaymentdate.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvSalaryPaymentdate.Rows[0].Cells[0].Text = "NO RECORD FOUND";

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


        public void saveSalaryPaymentDateInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.Year = txtSalaryYear.Text;
            objLookUpDTO.Month = ddlSalaryMonthId.SelectedValue.ToString();
            objLookUpDTO.PaymentDate = dtpPaymentDate.Text;


            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.UpdateBy = strEmployeeId;

            string strMsg = objLookUpBLL.saveSalaryPaymentDateInfo(objLookUpDTO);
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
           


        }

        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }


        #region "GridviewFunctionality"
        protected void gvSalaryPaymentdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSalaryPaymentdate.PageIndex = e.NewPageIndex;
            loadSalaryPaymentDateInfo();
        }

        protected void gvSalaryPaymentdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            int strUnitId = gvSalaryPaymentdate.SelectedRow.RowIndex;
            string strSalaryYear = gvSalaryPaymentdate.SelectedRow.Cells[1].Text;
            string strSalaryMonth = gvSalaryPaymentdate.SelectedRow.Cells[2].Text;
            string strPaymentDate = gvSalaryPaymentdate.SelectedRow.Cells[3].Text;

            txtSalaryYear.Text = strSalaryYear;
            if (strSalaryMonth != "")
            {

                LookUpDTO objLookUpDTO = new LookUpDTO();
                LookUpBLL objLookUpBLL = new LookUpBLL();


                objLookUpDTO.Month = strSalaryMonth;

                objLookUpDTO = objLookUpBLL.getSalaryMonthId(objLookUpDTO);
               
                ddlSalaryMonthId.SelectedValue = objLookUpDTO.SalaryMonthId;
                ddlSalaryMonthId.DataBind();

            }
            dtpPaymentDate.Text = strPaymentDate;


        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvSalaryPaymentdate, "Select$" + e.Row.RowIndex);
            }
        }


        protected void gvSalaryPaymentdate_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvSalaryPaymentdate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSalaryPaymentdate.EditIndex = e.NewEditIndex;
            loadSalaryPaymentDateInfo();
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

                else if (ddlSalaryMonthId.Text == "0")
                {
                    string strMsg = "Please Select Month!!!";
                    ddlSalaryMonthId.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (dtpPaymentDate.Text == "")
                {
                    string strMsg = "Please Enter Payment Day!!!";
                    dtpPaymentDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                else
                {

                    saveSalaryPaymentDateInfo();
                    loadSalaryPaymentDateInfo();


                }

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);

            }
        }
    }
}