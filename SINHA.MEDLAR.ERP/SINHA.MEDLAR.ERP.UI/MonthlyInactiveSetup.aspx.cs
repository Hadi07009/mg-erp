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
    public partial class MonthlyInactiveSetup : System.Web.UI.Page
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
                GetMonthlyInactiveSetup();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            txtInactiveYear.Attributes.Add("onkeypress", "return controlEnter('" + txtInactiveMonth.ClientID + "', event)");
            txtInactiveMonth.Attributes.Add("onkeypress", "return controlEnter('" + dtpProposalDate.ClientID + "', event)");
            dtpProposalDate.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtInactiveYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Inactive Year";
                    txtInactiveYear.Focus();
                    MessageBox(strMsg);
                    return;
                }
               if (txtInactiveMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Inactive Month";
                    txtInactiveMonth.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (dtpProposalDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Proposal Date";
                    dtpProposalDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                SaveMonthlyInactiveSetup();
                GetMonthlyInactiveSetup();
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
        public void getMonthYearForTax()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtInactiveYear.Text = objLookUpDTO.Year;
            txtInactiveMonth.Text = objLookUpDTO.Month;
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
        public void GetMonthlyInactiveSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetMonthlyInactiveSetup(strHeadOfficeId, strBranchOfficeId);
            if (dt.Rows.Count > 0)
            {
                gvMonthlyInactiveSetup.DataSource = dt;
                gvMonthlyInactiveSetup.DataBind();
                string strMsg = "TOTAL " + gvMonthlyInactiveSetup.Rows.Count + " RECORD FOUND";           
                lblMsg.Text = strMsg;                
            }
            else
            {              
                gvMonthlyInactiveSetup.DataSource = dt;
                gvMonthlyInactiveSetup.DataBind();
            }
        }
        public void clear()
        {
            txtSetupId.Text = string.Empty;
            txtInactiveYear.Text = string.Empty;
            txtInactiveMonth.Text = string.Empty;
            dtpProposalDate.Text = string.Empty;
            chkProposalLockYn.Checked = false;
            chkActivityLockYn.Checked = false;       
        }

        public void SaveMonthlyInactiveSetup( )
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.SetupId = txtSetupId.Text;
            objLookUpDTO.Year = txtInactiveYear.Text;
            objLookUpDTO.Month = txtInactiveMonth.Text;
            objLookUpDTO.ProposalDate = dtpProposalDate.Text;
            if (chkProposalLockYn.Checked == true)
            {
                objLookUpDTO.ProposalLockYn = "Y";
            }
            else
            {
                objLookUpDTO.ProposalLockYn = "N";
            }
            if (chkActivityLockYn.Checked == true)
            {
                objLookUpDTO.ActivityLockYn = "Y";
            }
            else
            {
                objLookUpDTO.ActivityLockYn = "N";
            }
            objLookUpDTO.CreateBy = strEmployeeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            
            string strMsg = objLookUpBLL.SaveMonthlyInactiveSetup(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
        #endregion

        #region "GridView Functionlity"
        protected void gvMonthlyInactiveSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMonthlyInactiveSetup.PageIndex = e.NewPageIndex;       
        }
        protected void gvMonthlyInactiveSetup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvMonthlyInactiveSetup.SelectedRow.RowIndex;

            string InactiveYear = gvMonthlyInactiveSetup.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string ProposalDate = gvMonthlyInactiveSetup.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string ProposalLockYn = gvMonthlyInactiveSetup.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string ActivitylLockYn = gvMonthlyInactiveSetup.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string setupId = gvMonthlyInactiveSetup.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string InactiveMonth = gvMonthlyInactiveSetup.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            
            txtInactiveYear.Text = InactiveYear;
            txtInactiveMonth.Text = InactiveMonth;
            dtpProposalDate.Text = ProposalDate;
            txtSetupId.Text = setupId;
            if (ProposalLockYn == "Locked")
            {
                chkProposalLockYn.Checked = true;
            }
            else
            {
                chkProposalLockYn.Checked = false;
            }
            if (ActivitylLockYn == "Locked")
            {
                chkActivityLockYn.Checked = true;
            }
            else
            {
                chkActivityLockYn.Checked = false;
            }
        }
        protected void gvMonthlyInactiveSetup_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvMonthlyInactiveSetup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMonthlyInactiveSetup.EditIndex = e.NewEditIndex;
           
        }
        protected void gvMonthlyInactiveSetup_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvMonthlyInactiveSetup, "Select$" + e.Row.RowIndex);
            }
        }
        #endregion  
    }
}