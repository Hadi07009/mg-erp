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
    public partial class PhaseWisePaymentLock : System.Web.UI.Page
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
                GetPhaseWiseSalaryLockSetup();
                getOfficeName();
                getBranchOfficeId();
                GetPaymentType();
                GetEidType();

                //saveSalaryLockSetup();
            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            txtSalaryYear.Attributes.Add("onkeypress", "return controlEnter('" + txtSalaryMonth.ClientID + "', event)");
            txtSalaryMonth.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
            chkActiveYn.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSalaryYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Salary Year";
                    txtSalaryYear.Focus();
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

                if (ddlPaymentType.SelectedValue == "1" || ddlPaymentType.SelectedValue == "2")
                {
                    if (txtSalaryMonth.Text == string.Empty)
                    {
                        string strMsg = "Please Enter Salary Month";
                        txtSalaryMonth.Focus();
                        MessageBox(strMsg);
                        return;
                    }
                }

                if (ddlPaymentType.SelectedValue.ToString() == "3")
                {
                    if(ddlEidType.SelectedValue == " ")
                    {
                        string strMsg = "Please Select Eid Type";
                        ddlEidType.Focus();
                        MessageBox(strMsg);
                        return;
                    } 
                }

                if (ddlPhaseId.SelectedValue == "")
                {
                    string strMsg = "Please Select Phase";
                    ddlPhaseId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (ddlBranchOfficeId.Text == " ")
                {
                    string strMsg = "Please Select Office Name";
                    ddlBranchOfficeId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                SavePhaseWiseSalaryLockSetup();
                //new: 26.04.2021
                GetPhaseWisePaymentSetup();
                //old
                //GetPhaseWiseSalaryLockSetup();
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

        public void getBranchOfficeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlBranchOfficeId.DataSource = objLookUpBLL.getAllBranchOfficeId();

            ddlBranchOfficeId.DataTextField = "BRANCH_OFFICE_NAME";
            ddlBranchOfficeId.DataValueField = "BRANCH_OFFICE_ID";

            ddlBranchOfficeId.DataBind();
            if (ddlBranchOfficeId.Items.Count > 0)
            {

                ddlBranchOfficeId.SelectedIndex = 0;
            }

        }
        public void GetEidType()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEidType.DataSource = objLookUpBLL.getEidTypeId();
            ddlEidType.DataTextField = "EID_NAME";
            ddlEidType.DataValueField = "EID_TYPE_ID";

            ddlEidType.DataBind();
            if (ddlEidType.Items.Count > 0)
            {
                ddlEidType.SelectedIndex = 0;
            }
        }
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

            txtSalaryYear.Text = objLookUpDTO.Year;
            txtSalaryMonth.Text = objLookUpDTO.Month;

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


        public void GetPhaseWiseSalaryLockSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetPhaseWiseSalaryLockSetup( txtSalaryYear.Text, txtSalaryMonth.Text, strHeadOfficeId, strBranchOfficeId);

            gvUnit.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                gvUnit.Columns[1].Visible = false;
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                gvUnit.Columns[1].Visible = false;
                int totalcolums = gvUnit.Rows[0].Cells.Count;
                gvUnit.Rows[0].Cells.Clear();
                gvUnit.Rows[0].Cells.Add(new TableCell());
                gvUnit.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvUnit.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
        }

        //new: 26.04.2021
        public void GetPhaseWisePaymentSetup()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
           

            objEmployeeDTO.Year = txtSalaryYear.Text;
            if (ddlPaymentType.SelectedValue == "1" || ddlPaymentType.SelectedValue == "2")
            {
                objEmployeeDTO.Month = txtSalaryMonth.Text;
            }
            else
            {
                objEmployeeDTO.Month = null;
            }
            
            if (ddlPaymentType.SelectedValue.ToString() != "")
            {
                objEmployeeDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.PaymentTypeId = null;
            }
                        
            if (ddlPaymentType.SelectedValue == "3")
            {
                objEmployeeDTO.EidTypeId = ddlEidType.SelectedValue;
            }
            else
            {
                objEmployeeDTO.EidTypeId = null;
            }
                        
            
            dt = objEmployeeBLL.GetPhaseWisePaymentSetup(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();

                int count = ((DataTable)gvUnit.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                gvUnit.DataSource = null;
                gvUnit.DataBind();
                string strMsg = "NO RECORD FOUND!!!";
                lblMsg.Text = strMsg;
            }
        }





        public void clear()
        {
            hf_lock_id.Value = string.Empty;
            ddlBranchOfficeId.SelectedIndex = 0;
            ddlPhaseId.SelectedIndex = 0;
            ddlEidType.SelectedIndex = 0;
            ddlPaymentType.SelectedIndex = 0;
            chkActiveYn.Checked = false;
        }
        public void SavePhaseWiseSalaryLockSetup( )
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            if (hf_lock_id.Value != string.Empty)
            {
                objLookUpDTO.lock_id = Convert.ToInt32(hf_lock_id.Value);
            }
            else
            {
                objLookUpDTO.lock_id = 0;
            }

            objLookUpDTO.Year = txtSalaryYear.Text;

            if (ddlPaymentType.SelectedValue.ToString() != "")
            {
                objLookUpDTO.PaymentTypeId = ddlPaymentType.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.PaymentTypeId = "";
            }

            if (ddlPaymentType.SelectedValue == "1" || ddlPaymentType.SelectedValue == "2")
            {
                objLookUpDTO.Month = txtSalaryMonth.Text;
            }
            else
            {
                objLookUpDTO.Month = null;
            }

            if (ddlPaymentType.SelectedValue == "3")
            {
                if (ddlEidType.SelectedValue.ToString() != " ")
                {
                    objLookUpDTO.EidTypeId = ddlEidType.SelectedValue.ToString();
                }
                else
                {
                    objLookUpDTO.EidTypeId = "";
                }
            }
            if (chkActiveYn.Checked == true)
            {
                objLookUpDTO.LockYn = "Y";
            }
            else
            {
                objLookUpDTO.LockYn = "N";
            }


            if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.BranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.BranchOfficeId = "";
            }

            if (ddlPhaseId.SelectedValue.ToString() != "")
            {
                objLookUpDTO.PhaseId = ddlPhaseId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.PhaseId = "";
            }

            

            objLookUpDTO.CreateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            
            string strMsg = objLookUpBLL.SavePhaseWiseSalaryLockSetup(objLookUpDTO);
            
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
            
        }
       

        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            hf_lock_id.Value = string.Empty;

            int strRowId = gvUnit.SelectedRow.RowIndex;
                        
            hf_lock_id.Value = gvUnit.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");

            string strBranchOfficeId = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strSalaryYear = gvUnit.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string strSalaryMonth = gvUnit.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
       
            string strLockYn = gvUnit.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            string phaseId = gvUnit.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            string PaymentId = gvUnit.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            string EidTypeId = gvUnit.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");

            txtSalaryYear.Text = strSalaryYear;
            txtSalaryMonth.Text = strSalaryMonth;
            ddlPhaseId.SelectedValue = phaseId;
            ddlPaymentType.SelectedValue = PaymentId;
            if (EidTypeId == "")
                ddlEidType.SelectedValue = " ";
            else
            ddlEidType.SelectedValue = EidTypeId;
            if (strBranchOfficeId != "")
            {
                ddlBranchOfficeId.SelectedValue = strBranchOfficeId;
                ddlBranchOfficeId.DataBind();
            }
            if (strLockYn == "LOCK")
            {
                chkActiveYn.Checked = true;
            }
            else
            {
                chkActiveYn.Checked = false;
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
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            }
        }

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        


    

        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {

            //new
            GetPhaseWisePaymentSetup();
            //old
            //GetPhaseWiseSalaryLockSetup();
        }
    }
}