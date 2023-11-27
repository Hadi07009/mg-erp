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
    public partial class AddMenuRecord : System.Web.UI.Page
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
                getOfficeName();
                loadMenuRecord();
                //getSoftId();
            }

            if (IsPostBack)
            {

                loadSesscion();
                
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtMenuName.Text == string.Empty)
            {

                string strMsg = "Please Enter Menu Name!!!";
                MessageBox(strMsg);
                txtMenuName.Focus();
                return ;
            }
            if (txtMenuPath.Text == string.Empty)
            {

                string strMsg = "Please EnterMenu Path!!!";
                MessageBox(strMsg);
                txtMenuPath.Focus();
                return;
            }
            else
            {
                saveMenuRecord();
                loadMenuRecord();
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

        //public void getSoftId()
        //{


        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlSoftwareId.DataSource = objLookUpBLL.getSoftId(strHeadOfficeId, strBranchOfficeId);

        //    ddlSoftwareId.DataTextField = "SOFTWAR_NAME";
        //    ddlSoftwareId.DataValueField = "SOFTWARE_ID";

        //    ddlSoftwareId.DataBind();
        //    if (ddlSoftwareId.Items.Count > 0)
        //    {

        //        ddlSoftwareId.SelectedIndex = 0;
        //    }

        //}




        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void saveMenuRecord()
        {


            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();


            objLookUpDTO.MenuId = txtMenuId.Text;
            objLookUpDTO.MenuName = txtMenuName.Text;
            objLookUpDTO.MenuPath = txtMenuPath.Text;

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

            string strMsg = objLookUpBLL.saveMenuRecord(objLookUpDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }

        public void searchMenuRecord(string strMenuId, string strHeadOfficeId, string mstrBranchOfficeId)
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchMenuRecord(strMenuId, strHeadOfficeId, strBranchOfficeId);


            txtMenuId.Text = objLookUpDTO.MenuId;
            txtMenuName.Text = objLookUpDTO.MenuName;
            txtMenuPath.Text = objLookUpDTO.MenuPath;
           
            if (objLookUpDTO.ActiveYn == "Y")
            {
                chkActiveYn.Checked = true;
            }
            else
            {
                chkActiveYn.Checked = false;

            }

        }

        public void loadMenuRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadMenuRecord(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvMenuRecord.DataSource = dt;
                gvMenuRecord.DataBind();
                string strMsg = "TOTAL " + gvMenuRecord.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvMenuRecord.DataSource = dt;
                gvMenuRecord.DataBind();
                int totalcolums = gvMenuRecord.Rows[0].Cells.Count;
                gvMenuRecord.Rows[0].Cells.Clear();
                gvMenuRecord.Rows[0].Cells.Add(new TableCell());
                gvMenuRecord.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvMenuRecord.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

            }


        }


        public void clearTextBox()
        {
            txtMenuId.Text = "";
            txtMenuName.Text = "";
            txtMenuPath.Text = "";
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMenuId.Text == string.Empty)
            {

                string strMsg = "Please Enter Menu ID!!!";
                MessageBox(strMsg);
                txtMenuId.Focus();
                return;
            }
            else
            {
                searchMenuRecord(txtMenuId.Text, strHeadOfficeId, strBranchOfficeId);

            }
        }

        protected void gvMenuRecord_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMenuRecord.PageIndex = e.NewPageIndex;
          
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvMenuRecord, "Select$" + e.Row.RowIndex);
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvMenuRecord.SelectedRow.RowIndex;
            string strMenuId = gvMenuRecord.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");

            txtMenuId.Text = strMenuId;

            searchMenuRecord(txtMenuId.Text, strHeadOfficeId, strBranchOfficeId);

          
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
    }
}