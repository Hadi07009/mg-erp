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
    public partial class AddIncrementSetupYearly : System.Web.UI.Page
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
                getEmpTypeId();
                lblMsg.Text = string.Empty;
                getMonthYearForSalary();
                loadIncrementSetupRecordYearly();

            }
            if (IsPostBack)
            {

                loadSesscion();
            }

        }


        #region "Function"
        public void getEmpTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlEmpTypeId.DataSource = objLookUpBLL.getEmployeeTypeId();

            ddlEmpTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
            ddlEmpTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

            ddlEmpTypeId.DataBind();
            if (ddlEmpTypeId.Items.Count > 0)
            {

                ddlEmpTypeId.SelectedIndex = 0;
            }
        }
        public void loadIncrementSetupRecordYearly()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadIncrementSetupRecordYearly(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
                string strMsg = "TOTAL " + gvUnit.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
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
                lblMsg.Text = strMsg;

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

        public void getMonthYearForSalary()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtIncrementYear.Text = objLookUpDTO.Year;
            txtIncrementMonth.Text = (Convert.ToInt32(objLookUpDTO.Month)).ToString();

            objLookUpDTO = objLookUpBLL.GetPreIncrementMonthYear(txtIncrementYear.Text, txtIncrementMonth.Text, strBranchOfficeId);

            txtPreIncrementYear.Text = objLookUpDTO.Year;
            txtPreIncrementMonth.Text = objLookUpDTO.Month;
        }

        public void getEffectiveDate()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getEffectiveDate(txtIncrementYear.Text, strHeadOfficeId, strBranchOfficeId);

            dtpEffectDate.Text = objLookUpDTO.EffectDate;
            dtpLimitDate.Text = objLookUpDTO.OrderDate;

        }


        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void IncrementSetupSave()
        {

            IncrementDTO objIncrementDTO = new IncrementDTO();
            IncrementBLL objIncrementBLL = new IncrementBLL();

            if (ChkAsFirstSalary.Checked)
                objIncrementDTO.as_first_salary = 1;
            if (!ChkAsFirstSalary.Checked)
                objIncrementDTO.as_first_salary = 0;

            if (ChkIsIncrement.Checked)
                objIncrementDTO.Is_Increment = "Y";
            if (!ChkIsIncrement.Checked)
                objIncrementDTO.Is_Increment = "N";

            objIncrementDTO.proposal_id = hf_proposal_id.Value;

            if (ddlEmpTypeId.SelectedValue.ToString() != " ")
            {
                objIncrementDTO.EmployeeTypeId = ddlEmpTypeId.SelectedValue.ToString();
            }
            else
            {
                objIncrementDTO.EmployeeTypeId = "";
            }
            objIncrementDTO.Year = txtIncrementYear.Text;
            objIncrementDTO.Month = txtIncrementMonth.Text;
            objIncrementDTO.PreIncrementYear = txtPreIncrementYear.Text;
            objIncrementDTO.PreIncrementMonth = txtPreIncrementMonth.Text;
            objIncrementDTO.EffectDate = dtpEffectDate.Text;
            objIncrementDTO.LimitDate = dtpLimitDate.Text;

            objIncrementDTO.UpdateBy = strEmployeeId;
            objIncrementDTO.HeadOfficeId = strHeadOfficeId;
            objIncrementDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objIncrementBLL.incrementSetupSave(objIncrementDTO);

            if(strMsg == "INSERT")
            {
                hf_proposal_id.Value = string.Empty;

                MessageBox("Added Successfully.");
                lblMsg.Text = "Added Successfully.";
            }
            else if (strMsg == "UPDATE")
                {
                    hf_proposal_id.Value = string.Empty;

                    MessageBox("Updated Successfully.");
                    lblMsg.Text = "Updated Successfully.";
                }
            else if (strMsg == "NOTHING")
            {
                hf_proposal_id.Value = string.Empty;

                MessageBox("No Operation.");
                lblMsg.Text = "No Operation.";
            }
            else
            {
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
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

       

        #endregion

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                 if (txtIncrementYear.Text == string.Empty)
                {

                    string strMsg = "Please Enter Year!!!";
                    MessageBox(strMsg);
                    txtIncrementYear.Focus();
                    return; 
                }


                else if (ddlEmpTypeId.Text == " ")
                {

                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmpTypeId.Focus();
                    return;
                }


                else if (dtpEffectDate.Text == string.Empty)
                {

                    string strMsg = "Please Enter Effect Date!!!";
                    MessageBox(strMsg);
                    dtpEffectDate.Focus();
                    return;
                }

                 else if (dtpLimitDate.Text == string.Empty)
                 {

                     string strMsg = "Please Enter Limit Date!!!";
                     MessageBox(strMsg);
                     dtpLimitDate.Focus();
                     return;
                 }
                else
                {
                    IncrementSetupSave();
                    loadIncrementSetupRecordYearly();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }

        #region "Gridview Functionality"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
           
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

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hf_proposal_id.Value = string.Empty;

            int strRowId = gvUnit.SelectedRow.RowIndex;
            string IncrementYear = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", ""); 
            string IncrementMonth = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string PreIncrementYear = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string PreIncrementMonth = gvUnit.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            string EffectDate = gvUnit.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string LimitDate = gvUnit.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string asFirstSalary = gvUnit.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string IsIncrement = gvUnit.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            string EmployeeTypId = gvUnit.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");

            hf_proposal_id.Value = gvUnit.SelectedRow.Cells[11].Text;
            
            txtIncrementYear.Text = IncrementYear;
            txtIncrementMonth.Text = IncrementMonth;
            txtPreIncrementYear.Text = PreIncrementYear;
            txtPreIncrementMonth.Text = PreIncrementMonth;
            dtpEffectDate.Text = EffectDate;
            dtpLimitDate.Text = LimitDate;
            ddlEmpTypeId.SelectedValue = EmployeeTypId;

            if (asFirstSalary == "Yes")
                ChkAsFirstSalary.Checked = true;
            if(asFirstSalary == "No")
                ChkAsFirstSalary.Checked = false;

            if (IsIncrement == "Incremented")
                ChkIsIncrement.Checked = true;
            if (IsIncrement == "Not Incremented")
                ChkIsIncrement.Checked = false;

            //string strMsg = "Row Index: " + strRowId + "\\nUnit ID: " + strUnitId + "\\nUnit Name : " + strUnitName + "\\nUnit Name Bangla : " + strUnitNameBng;
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('" + strMsg + "');", true);
            //MessageBox(strMsg);
        }


        #endregion

        protected void btnClear_Click(object sender, EventArgs e)
        {
            dtpEffectDate.Text = "";
            dtpLimitDate.Text = "";
            txtIncrementYear.Text = "";
            txtIncrementMonth.Text = string.Empty;
            txtPreIncrementYear.Text = string.Empty;
            txtPreIncrementMonth.Text = string.Empty;
            ChkAsFirstSalary.Checked = false;
            ChkIsIncrement.Checked = false;
            getEmpTypeId();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtIncrementYear.Text == string.Empty)
            {

                string strMsg = "Please Enter Year!!!";
                MessageBox(strMsg);
                txtIncrementYear.Focus();
                return;
            }
            else
            {

                getEffectiveDate();
                loadIncrementSetupRecordYearly();

            }
        }

    }
}