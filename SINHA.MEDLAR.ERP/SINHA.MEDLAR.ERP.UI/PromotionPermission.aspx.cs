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
    public partial class PromotionPermission : System.Web.UI.Page
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
                getYearForIncrementProposal();
                GetPromossionPermission();
                //getEmployeeeTypeId();
                getMonthId();             
                getOfficeName();
            }

            if (IsPostBack)
            {
                loadSesscion();
            }


           // txtArrearYear.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
           //// txtSalaryMonth.Attributes.Add("onkeypress", "return controlEnter('" + chkActiveYn.ClientID + "', event)");
           // chkActiveYn.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }

        public void getMonthId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlMonthId.DataSource = objLookUpBLL.getMonthId();

            ddlMonthId.DataTextField = "MONTH_NAME";
            ddlMonthId.DataValueField = "MONTH_ID";

            ddlMonthId.DataBind();
            if (ddlMonthId.Items.Count > 0)
            {
                ddlMonthId.SelectedIndex = 0;
            }
        }
        //public void getEmployeeeTypeId()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlEmployeeTypeId.DataSource = objLookUpBLL.getEmployeeTypeId();

        //    ddlEmployeeTypeId.DataTextField = "EMPLOYEE_TYPE_NAME";
        //    ddlEmployeeTypeId.DataValueField = "EMPLOYEE_TYPE_ID";

        //    ddlEmployeeTypeId.DataBind();
        //    if (ddlEmployeeTypeId.Items.Count > 0)
        //    {
        //        ddlEmployeeTypeId.SelectedIndex = 0;
        //    }
        //}
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtPromotionYear.Text == string.Empty)
                {
                    string strMsg = "Please Enter Promossion Year";
                    txtPromotionYear.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (ddlMonthId.Text == "")
                {
                    string strMsg = "Please Select Month";
                    ddlMonthId.Focus();
                    MessageBox(strMsg);
                    return;
                }
             
                if (dtpEffectiveDate.Text == string.Empty)
                {
                    string strMsg = "Please Enter Effective Date";
                    dtpEffectiveDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                //if (ddlEmployeeTypeId.Text == "")
                //{
                //    string strMsg = "Please Select Employee Type";
                //    ddlEmployeeTypeId.Focus();
                //    MessageBox(strMsg);
                //    return;
                //}
                else
                {
                    SavePromotionPermission();
                    GetPromossionPermission();                  
                }
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

      

        public void getYearForIncrementProposal()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getYearForIncrementYear(strHeadOfficeId, strBranchOfficeId);

            txtPromotionYear.Text = objLookUpDTO.Year;



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


        public void GetPromossionPermission()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            objLookUpDTO.Year = txtPromotionYear.Text;
            if (ddlMonthId.SelectedValue != "0")
            {
                objLookUpDTO.PromotionMonth = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.PromotionMonth = "0";
            }
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            dt = objLookUpBLL.GetPromossionPermission(objLookUpDTO);

            gvPromossionPermission.Columns[1].Visible = true;
            if (dt.Rows.Count > 0)
            {
                gvPromossionPermission.DataSource = dt;
                gvPromossionPermission.DataBind();
                gvPromossionPermission.Columns[1].Visible = false;
                string strMsg = "TOTAL " + gvPromossionPermission.Rows.Count + " RECORD FOUND";
             
                lblMsg.Text = strMsg;
                
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvPromossionPermission.DataSource = dt;
                gvPromossionPermission.DataBind();
                gvPromossionPermission.Columns[1].Visible = false;
                int totalcolums = gvPromossionPermission.Rows[0].Cells.Count;
                gvPromossionPermission.Rows[0].Cells.Clear();
                gvPromossionPermission.Rows[0].Cells.Add(new TableCell());
                gvPromossionPermission.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvPromossionPermission.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }


        }
      

        public void clear()
        {
            txtPromotionYear.Text = string.Empty;
            ddlMonthId.SelectedIndex = 0;
            chkActiveYn.Checked = false;
            hf_lock_id.Value = string.Empty;
        }
        public void SavePromotionPermission()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            objLookUpDTO.PermissionId = txtPermissionId.Text;
            objLookUpDTO.Year = txtPromotionYear.Text;
            if (ddlMonthId.SelectedValue !="0")
            {
                objLookUpDTO.PromotionMonth = ddlMonthId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.PromotionMonth = "0";
            }

            //if (ddlEmployeeTypeId.SelectedValue != " ")
            //{
            //    objLookUpDTO.EmployeeTypeId = ddlEmployeeTypeId.SelectedValue.ToString();
            //}
            //else
            //{
            //    objLookUpDTO.EmployeeTypeId = "0";
            //}

            objLookUpDTO.EffectDate = dtpEffectiveDate.Text;
            if (chkActiveYn.Checked == true)
            {
                objLookUpDTO.ActiveYn = "Y";
            }
            else
            {
                objLookUpDTO.ActiveYn = "N";
            }
            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objLookUpBLL.SavePromotionPermission(objLookUpDTO);

            if(strMsg == "INSERTED SUCCESSFULLY")
            {
                clear();
            }

            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }
       

        #endregion

        #region "GridView Functionlity"

        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPromossionPermission.PageIndex = e.NewPageIndex;
            
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvPromossionPermission.SelectedRow.RowIndex;
            string PermissionId = gvPromossionPermission.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string PromossionYear = gvPromossionPermission.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string EffectiveDate = gvPromossionPermission.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string LockedYn = gvPromossionPermission.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            string monthId = gvPromossionPermission.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            //string EmployeeTypeId = gvPromossionPermission.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");

            if (LockedYn == "Y")
               chkActiveYn.Checked = true;
            else
               chkActiveYn.Checked = false;
            
            txtPermissionId.Text = PermissionId;
            txtPromotionYear.Text = PromossionYear;
            ddlMonthId.SelectedValue = monthId;
            //ddlEmployeeTypeId.SelectedValue = EmployeeTypeId;
            dtpEffectiveDate.Text = EffectiveDate;
        }
        protected void gvPromossionPermission_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvPromossionPermission_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPromossionPermission.EditIndex = e.NewEditIndex;
           
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvPromossionPermission, "Select$" + e.Row.RowIndex);
            }
        }

        protected void chkActiveYn_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        


    

        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            GetPromossionPermission();
        }
    }
}