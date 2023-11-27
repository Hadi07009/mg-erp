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
    public partial class AddIncrementLockEntry : System.Web.UI.Page
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
                loadIncrementLockSetup();
                getOfficeName();
                //getBranchOfficeId();
                getEmpTypeId();
                //saveSalaryLockSetup();

            }

            if (IsPostBack)
            {

                loadSesscion();
            }


            txtIncrementYear.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
            chkActiveYn.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtIncrementYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Increment Year!!!";
                    txtIncrementYear.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtIncrementMonth.Text == string.Empty)
                {
                    string strMsg = "Please Enter Increment Month!!!";
                    txtIncrementYear.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (ddlEmpTypeId.Text == " ")
                {

                    string strMsg = "Please Select Employee Type!!!";
                    MessageBox(strMsg);
                    ddlEmpTypeId.Focus();
                    return;
                }

                //if (ddlBranchOfficeId.Text == " ")
                //{
                //    string strMsg = "Please Select Office Name!!!";
                //    ddlBranchOfficeId.Focus();
                //    MessageBox(strMsg);
                //    return;  
                //}
                                
                saveIncrementLockSetup();
                loadIncrementLockSetup();
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

        //public void getBranchOfficeId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlBranchOfficeId.DataSource = objLookUpBLL.getAllBranchOfficeId();

        //    ddlBranchOfficeId.DataTextField = "BRANCH_OFFICE_NAME";
        //    ddlBranchOfficeId.DataValueField = "BRANCH_OFFICE_ID";

        //    ddlBranchOfficeId.DataBind();
        //    if (ddlBranchOfficeId.Items.Count > 0)
        //    {

        //        ddlBranchOfficeId.SelectedIndex = 0;
        //    }

        //}

        public void getMonthYearForTax()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getMonthYearForSalary();

            txtIncrementYear.Text = objLookUpDTO.Year;

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


        public void loadIncrementLockSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadIncrementLockSetup( txtIncrementYear.Text, strHeadOfficeId, strBranchOfficeId);

            gvIncLock.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvIncLock.DataSource = dt;
                gvIncLock.DataBind();
                gvIncLock.Columns[1].Visible = false;
                string strMsg = "TOTAL " + gvIncLock.Rows.Count + " RECORD FOUND";
             
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvIncLock.DataSource = dt;
                gvIncLock.DataBind();
                int totalcolums = gvIncLock.Rows[0].Cells.Count;
                gvIncLock.Rows[0].Cells.Clear();
                gvIncLock.Rows[0].Cells.Add(new TableCell());
                gvIncLock.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvIncLock.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }

        public void clear()
        {

            txtIncrementYear.Text = string.Empty;

        }
        public void saveIncrementLockSetup( )
        {
            
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            
            objLookUpDTO.Year = txtIncrementYear.Text;
            objLookUpDTO.Month = txtIncrementMonth.Text;

            if (ddlEmpTypeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.EmployeeTypeId = ddlEmpTypeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.EmployeeTypeId = "";
            }

            if (chkActiveYn.Checked == true)
            {
                objLookUpDTO.ActiveYn = "Y";
            }
            else
            {
                objLookUpDTO.ActiveYn = "N";
            }

            if (hfLockId.Value != string.Empty)
            {
                objLookUpDTO.lock_id = Convert.ToInt32(hfLockId.Value);
            }
            else
            {
                objLookUpDTO.lock_id = 0;
            }

            if (hfBranchOfficeId.Value == "")
            {
                objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            }
            if (hfBranchOfficeId.Value != "")
            {
                objLookUpDTO.BranchOfficeId = hfBranchOfficeId.Value;
            }

                //if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
                //{
                //    objLookUpDTO.BranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
                //}
                //else
                //{
                //    objLookUpDTO.BranchOfficeId = "";
                //}

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
           
            string strMsg = objLookUpBLL.saveIncrementLockSetup(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

            hfLockId.Value = string.Empty;
            txtIncrementYear.Text = string.Empty;
            txtIncrementMonth.Text = string.Empty;
            ddlEmpTypeId.SelectedValue = " ";
            chkActiveYn.Checked = false;

        }

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
        #endregion

        #region "GridView Functionlity"

        protected void gvIncLock_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIncLock.PageIndex = e.NewPageIndex;
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvIncLock.SelectedRow.RowIndex;

            string strBranchOfficeId = gvIncLock.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");

            //new
            string strIncrementYear = gvIncLock.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string incrementMonth = gvIncLock.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            
            string LockYN = gvIncLock.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string employeeTypeId = gvIncLock.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            string lockId = gvIncLock.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");

            //old
            //string strIncrementYear = gvIncLock.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            //string LockYN = gvIncLock.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");


            txtIncrementYear.Text = strIncrementYear;
            txtIncrementMonth.Text = incrementMonth;
            ddlEmpTypeId.SelectedValue = employeeTypeId;
            if (LockYN == "LOCK")
            {
                chkActiveYn.Checked = true;
            }
            else
            {
                chkActiveYn.Checked = false;
            }

            hfLockId.Value = lockId;
            hfBranchOfficeId.Value = strBranchOfficeId;

            //if (strBranchOfficeId != " ")
            //{
            //    ddlBranchOfficeId.SelectedValue = strBranchOfficeId;
            //    ddlBranchOfficeId.DataBind();
            //}


        }
        protected void gvIncLock_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvIncLock_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIncLock.EditIndex = e.NewEditIndex;
            loadIncrementLockSetup();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvIncLock, "Select$" + e.Row.RowIndex);
            }
        }

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        


    

        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadIncrementLockSetup();
        }
    }
}