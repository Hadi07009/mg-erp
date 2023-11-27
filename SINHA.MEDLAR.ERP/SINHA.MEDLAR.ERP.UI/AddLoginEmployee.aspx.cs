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
    public partial class AddLoginEmployee : System.Web.UI.Page
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
                loadLoginEmployeeInfo();
                getOfficeName();
                getSoftId();
                getBranchOfficeId();
                lblMsg.Text = "";
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }
            //txtTotalPrice.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }


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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtEmployeeName.Text == string.Empty)
            {

                string strMsg = "Please Enter Employee Name!!!";
                MessageBox(strMsg);
                txtEmployeeName.Focus();
                return ;
            }
            if (txtEmployeePassword.Text == string.Empty)
            {

                string strMsg = "Please Enter Employee Password!!!";
                MessageBox(strMsg);
                txtEmployeePassword.Focus();
                return;
            }

            if (ddlSoftwareId.Text == string.Empty)
            {

                string strMsg = "Please Select Software Name!!!";
                MessageBox(strMsg);
                ddlSoftwareId.Focus();
                return;
            }

            if (ddlBranchOfficeId.Text == string.Empty)
            {

                string strMsg = "Please Select Office Name!!!";
                MessageBox(strMsg);
                ddlBranchOfficeId.Focus();
                return;
            }



            else
            {
                saveLoginEmployeeInfo();
                loadLoginEmployeeInfo();

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

        public void getSoftId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSoftwareId.DataSource = objLookUpBLL.getSoftId(strHeadOfficeId, strBranchOfficeId);

            ddlSoftwareId.DataTextField = "SOFTWARE_NAME";
            ddlSoftwareId.DataValueField = "SOFTWARE_ID";

            ddlSoftwareId.DataBind();
            if (ddlSoftwareId.Items.Count > 0)
            {

                ddlSoftwareId.SelectedIndex = 0;
            }

        }




        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void saveLoginEmployeeInfo()
        {            
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
            
            objLookUpDTO.EmployeeId = txtEmployeeId.Text; 
            objLookUpDTO.EmployeeName = txtEmployeeName.Text;
            objLookUpDTO.EmployeePass = txtEmployeePassword.Text;
            
            if (chkActiveYn.Checked == true)
            {
                objLookUpDTO.ActiveYn = "Y";
            }
            else
            {
                objLookUpDTO.ActiveYn = "N";
            }
            
            if (ddlSoftwareId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.SoftId = ddlSoftwareId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.SoftId = "";
            }
            
            if (ddlBranchOfficeId.SelectedValue.ToString() != " ")
            {
                objLookUpDTO.BranchOfficeId = ddlBranchOfficeId.SelectedValue.ToString();
            }
            else
            {
                objLookUpDTO.BranchOfficeId = "";
            }
            
            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
           
            string strMsg = objLookUpBLL.saveLoginEmployeeInfo(objLookUpDTO);
            MessageBox(strMsg);

        }

        public void searchLoginEmployeeInfo(string strEmployeeId, string strHeadOfficeId)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchLoginEmployeeInfo(strEmployeeId, strHeadOfficeId);


            txtEmployeeName.Text = objLookUpDTO.EmployeeName;
            txtEmployeePassword.Text = objLookUpDTO.EmployeePass.Replace("\0", "");



            if (objLookUpDTO.BranchOfficeId == "")
            {
                getBranchOfficeId();

            }
            else
            {
                ddlBranchOfficeId.SelectedValue = objLookUpDTO.BranchOfficeId;

            }


            if (objLookUpDTO.SoftId == "0")
            {


            }
            else
            {
                ddlSoftwareId.SelectedValue = objLookUpDTO.SoftId;

            }


            if (objLookUpDTO.ActiveYn == "Y")
            {
                chkActiveYn.Checked = true;
            }
            else
            {
                chkActiveYn.Checked = false;

            }



        }

        public void loadLoginEmployeeInfo()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadLoginEmployeeInfo(txtEmployeeId.Text, strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvLoginEmployee.DataSource = dt;
                gvLoginEmployee.DataBind();
                string strMsg = "TOTAL " + gvLoginEmployee.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvLoginEmployee.DataSource = dt;
                gvLoginEmployee.DataBind();
                int totalcolums = gvLoginEmployee.Rows[0].Cells.Count;
                gvLoginEmployee.Rows[0].Cells.Clear();
                gvLoginEmployee.Rows[0].Cells.Add(new TableCell());
                gvLoginEmployee.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvLoginEmployee.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtEmployeeId.Text = "";
            txtEmployeeName.Text = "";
            getSoftId();
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtEmployeeId.Text == string.Empty)
            {

                string strMsg = "Please Enter Requisition ID!!!";
                MessageBox(strMsg);
                txtEmployeeId.Focus();
                return;
            }
            else
            {
                searchLoginEmployeeInfo(txtEmployeeId.Text, strHeadOfficeId);

            }
        }

        protected void gvPruductRequisition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLoginEmployee.PageIndex = e.NewPageIndex;
          
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvLoginEmployee, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvLoginEmployee.SelectedRow.RowIndex;
            string strEmployeeId = gvLoginEmployee.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string strEmployeeName = gvLoginEmployee.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string strEmployeePass = gvLoginEmployee.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");



            txtEmployeeId.Text = strEmployeeId;
          
            searchLoginEmployeeInfo(txtEmployeeId.Text, strHeadOfficeId);

          
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " +ex.Message);
            }
        }

        protected void btnSheet_Click(object sender, EventArgs e)
        {

        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            loadLoginEmployeeInfo();
        }
    }
}