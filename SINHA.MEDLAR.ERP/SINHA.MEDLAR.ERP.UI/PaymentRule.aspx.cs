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

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class PaymentRule : System.Web.UI.Page
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
                getMonthYearForTax();
                getOfficeName();
                GetPaymentType();
                GetPaymentRule();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            txtOtDeductionHour.Attributes.Add("onkeypress", "return controlEnter('" + txtOtDeductionMinute.ClientID + "', event)");
            txtOtDeductionMinute.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPaymentYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Salary Year";
                    txtPaymentYear.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (txtPaymentMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Salary Month";
                    txtPaymentMonth.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (ddlPaymentType.Text == "")
                {
                    string strMsg = "Please Select Payment Type";
                    ddlPaymentType.Focus();
                    MessageBox(strMsg);
                    return;
                }
                //if (txtOtDeductionHour.Text == string.Empty)
                //{
                //    string strMsg = "Please Enter OT Deduction Hour";
                //    txtOtDeductionHour.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}
                //if (txtOtDeductionMinute.Text == string.Empty)
                //{
                //    string strMsg = "Please Enter OT Deduction Minute";
                //    txtOtDeductionHour.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}
                SavePaymentRule();
                GetPaymentRule();
                clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        #region "Function"
        public void GetPaymentType()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlPaymentType.DataSource = objLookUpBLL.GetPaymentType();
            ddlPaymentType.DataTextField = "PAYMENT_TYPE_NAME";
            ddlPaymentType.DataValueField = "PAYMENT_TYPE_ID";

            ddlPaymentType.DataBind();
            if (ddlPaymentType.Items.Count > 0)
            {
                ddlPaymentType.SelectedIndex = 0;
            }
        }

        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtPaymentYear.Text = objLookUpDTO.Year;
            txtPaymentMonth.Text = objLookUpDTO.Month;

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


        //public void GetPaymentRule()
        //{
        //    LookUpDTO objLookUpDTO = new LookUpDTO();
        //    LookUpBLL objLookUpBLL = new LookUpBLL();

        //    DataTable dt = new DataTable();
        //    dt = objLookUpBLL.GetPhaseWiseSalaryLockSetup( txtSalaryYear.Text, txtSalaryMonth.Text, strHeadOfficeId, strBranchOfficeId);

        //    GvPaymentRule.Columns[1].Visible = true;
        //    if (dt.Rows.Count > 0)
        //    {
        //        GvPaymentRule.DataSource = dt;
        //        GvPaymentRule.DataBind();
        //        string strMsg = "TOTAL " + GvPaymentRule.Rows.Count + " RECORD FOUND";
        //        lblMsg.Text = strMsg;
        //    }
        //    else
        //    {
        //        dt.Rows.Add(dt.NewRow());
        //        GvPaymentRule.DataSource = dt;
        //        GvPaymentRule.DataBind();
        //        GvPaymentRule.Columns[1].Visible = false;
        //        int totalcolums = GvPaymentRule.Rows[0].Cells.Count;
        //        GvPaymentRule.Rows[0].Cells.Clear();
        //        GvPaymentRule.Rows[0].Cells.Add(new TableCell());
        //        GvPaymentRule.Rows[0].Cells[0].ColumnSpan = totalcolums;
        //        GvPaymentRule.Rows[0].Cells[0].Text = "NO RECORD FOUND";

        //        string strMsg = "NO RECORD FOUND!!!";
        //        MessageBox(strMsg);
        //        lblMsg.Text = strMsg;
        //    }
        //}

        //new: 26.04.2021
        public void GetPaymentRule()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
           

            objEmployeeDTO.Year = txtPaymentYear.Text;
            objEmployeeDTO.Month = txtPaymentMonth.Text;
            
            if (ddlPaymentType.SelectedValue.ToString() != "")
            {
                objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.PaymentTypeId = null;
            }
                        
            
                        
            
            dt = objEmployeeBLL.GetPaymentRule(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GvPaymentRule.DataSource = dt;
                GvPaymentRule.DataBind();

                int count = ((DataTable)GvPaymentRule.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                GvPaymentRule.DataSource = null;
                GvPaymentRule.DataBind();
                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }





        public void clear()
        {
            hf_rule_id.Value = string.Empty;
            ddlPaymentType.SelectedIndex = 0;
            txtOtDeductionHour.Text = string.Empty;
            txtOtDeductionMinute.Text = string.Empty;
            txtAccountRegistrationFee.Text = string.Empty;
            ChkCachPriorityPayment.Checked = false;
        }

        public void SavePaymentRule()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if (hf_rule_id.Value != string.Empty)
            {
                objLookUpDTO.RuleId = hf_rule_id.Value; //Convert.ToInt32();
            }
            else
            {
                objLookUpDTO.RuleId = "";
            }

            objLookUpDTO.Year = txtPaymentYear.Text;
            objLookUpDTO.Month = txtPaymentMonth.Text;
            objLookUpDTO.OtDeductionHour = txtOtDeductionHour.Text;
            objLookUpDTO.OtDeductionMinute = txtOtDeductionMinute.Text;
            objLookUpDTO.AccountRegistrationFee = txtAccountRegistrationFee.Text;

            if (ddlPaymentType.SelectedValue.ToString() != "")
            {
                objLookUpDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.PaymentTypeId = "";
            }
            if (ChkCachPriorityPayment.Checked == true)
                objLookUpDTO.CashPaymenyYn = "Y";
            else
                objLookUpDTO.CashPaymenyYn = "N";

            objLookUpDTO.CreateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objLookUpBLL.SavePaymentRule(objLookUpDTO);
            
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            
        }
       

        #endregion

        #region "GridView Functionlity"

        protected void GvPaymentRule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvPaymentRule.PageIndex = e.NewPageIndex;
            
        }

        protected void GvPaymentRule_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            hf_rule_id.Value = string.Empty;

            int strRowId = GvPaymentRule.SelectedRow.RowIndex;
            hf_rule_id.Value = GvPaymentRule.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string PaymentYear = GvPaymentRule.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string PaymentMonth = GvPaymentRule.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string OTDeductionHour = GvPaymentRule.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string OTDeductionMinute = GvPaymentRule.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string AccountRegistrationFee = GvPaymentRule.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string PaymentTypeId = GvPaymentRule.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string CashPriority = GvPaymentRule.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            txtPaymentYear.Text = PaymentYear;
            txtPaymentMonth.Text = PaymentMonth;
            txtOtDeductionHour.Text = OTDeductionHour;
            txtOtDeductionMinute.Text = OTDeductionMinute;
            txtAccountRegistrationFee.Text = AccountRegistrationFee;
            ddlPaymentType.SelectedValue = PaymentTypeId;
            if (CashPriority == "Yes")
                ChkCachPriorityPayment.Checked = true;
            else
                ChkCachPriorityPayment.Checked = false;

        }
        protected void GvPaymentRule_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void GvPaymentRule_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvPaymentRule.EditIndex = e.NewEditIndex;
           
        }
        protected void GvPaymentRule_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvPaymentRule, "Select$" + e.Row.RowIndex);
            }
        }

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        


    

        #endregion

        //protected void btnShow_Click(object sender, EventArgs e)
        //{
        //    //GetPhaseWisePaymentSetup();      
        //}
    }
}