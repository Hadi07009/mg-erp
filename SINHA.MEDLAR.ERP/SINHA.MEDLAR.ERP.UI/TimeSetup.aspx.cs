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
    public partial class TimeSetup : System.Web.UI.Page
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
                GetTimeSetup();
                GetShift();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            ddlDutyType.Attributes.Add("onkeypress", "return controlEnter('" + txtLogInTime.ClientID + "', event)");
            txtLogInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLogOutTime.ClientID + "', event)");
            txtLogOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchOutTime.ClientID + "', event)");
            txtLunchOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchInTime.ClientID + "', event)");
            txtLunchInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtPunchStartTime.ClientID + "', event)");
            txtPunchStartTime.Attributes.Add("onkeypress", "return controlEnter('" + txtPunchEndTime.ClientID + "', event)");
            txtPunchEndTime.Attributes.Add("onkeypress", "return controlEnter('" + btnSave.ClientID + "', event)");

        }
        #region "Function"
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
        public void GetShift()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            //ddlDutyType.DataSource = objLookUpBLL.GetShift(strBranchOfficeId);
            ddlDutyType.DataSource = objLookUpBLL.GetDutyType();

            ddlDutyType.DataTextField = "DUTY_TYPE_NAME";
            ddlDutyType.DataValueField = "DUTY_TYPE_ID";
            ddlDutyType.DataBind();
            if (ddlDutyType.Items.Count > 0)
            {
                ddlDutyType.SelectedIndex = 0;
            }
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void GetTimeSetup()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.GetTimeSetup(strHeadOfficeId, strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvTimeSetup.DataSource = dt;
                gvTimeSetup.DataBind();
                string strMsg = "TOTAL " + gvTimeSetup.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvTimeSetup.DataSource = dt;
                gvTimeSetup.DataBind();
                int totalcolums = gvTimeSetup.Rows[0].Cells.Count;
                gvTimeSetup.Rows[0].Cells.Clear();
                gvTimeSetup.Rows[0].Cells.Add(new TableCell());
                gvTimeSetup.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvTimeSetup.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;

            }
        }
        public void clearTextBox()
        {
            txtLogInTime.Text = string.Empty;
            txtLogOutTime.Text = string.Empty;
            txtLunchInTime.Text = string.Empty;
            txtLunchOutTime.Text = string.Empty;
            txtPunchStartTime.Text = string.Empty;
            txtPunchEndTime.Text = string.Empty;
            txtTimeId.Text = string.Empty;

        }

        public void Reset()
        {
            txtTimeId.Text = string.Empty;
            txtLogInTime.Text = string.Empty;
            txtLogOutTime.Text = string.Empty;
            txtLunchInTime.Text = string.Empty;
            txtLunchOutTime.Text = string.Empty;
            txtPunchStartTime.Text = string.Empty;
            txtPunchEndTime.Text = string.Empty;
            ddlDutyType.SelectedIndex = 0;
        }

        #endregion
        #region "Gridview Functionality"
        protected void gvTimeSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTimeSetup.PageIndex = e.NewPageIndex;
            GetTimeSetup();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvUnit, "Select$" + e.Row.RowIndex);
            //}
            
        }
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
                int strRowId = gvTimeSetup.SelectedRow.RowIndex;
                string slNo = gvTimeSetup.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
                string strLoginTime = gvTimeSetup.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                string strLogOutTime = gvTimeSetup.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                string strLunchOutTime = gvTimeSetup.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                string strLunchInTime = gvTimeSetup.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                string PunchStartTime = gvTimeSetup.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                string PunchEndTime = gvTimeSetup.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                string TimeId = gvTimeSetup.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                string Shift = gvTimeSetup.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

                txtLogInTime.Text = strLoginTime;
                txtLogOutTime.Text = strLogOutTime;
                txtLunchInTime.Text = strLunchInTime;
                txtLunchOutTime.Text = strLunchOutTime;
                txtPunchStartTime.Text = PunchStartTime;
                txtPunchEndTime.Text = PunchEndTime;
                txtTimeId.Text = TimeId;
                ddlDutyType.SelectedValue = Shift;

        }
       
        public void SaveTimeSetup()
        {
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();
            OfficeTimeBLL objOfficeTimeBLL = new OfficeTimeBLL();

            string strMsg = "";

            objOfficeTimeDTO.DutyTypeId = ddlDutyType.SelectedValue.Trim();
            objOfficeTimeDTO.TimeId = txtTimeId.Text.Trim();
            objOfficeTimeDTO.LogInTime = txtLogInTime.Text.Trim();
            objOfficeTimeDTO.LogOutTime = txtLogOutTime.Text.Trim();
            objOfficeTimeDTO.LunchInTime = txtLunchInTime.Text.Trim();
            objOfficeTimeDTO.LunchOutTime = txtLunchOutTime.Text.Trim();
            objOfficeTimeDTO.PunchStartTime = txtPunchStartTime.Text.Trim();
            objOfficeTimeDTO.PunchEndTime = txtPunchEndTime.Text.Trim();
            objOfficeTimeDTO.CreateBy = strEmployeeId;
            objOfficeTimeDTO.HeadOfficeId = strHeadOfficeId;
            objOfficeTimeDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objOfficeTimeBLL.SaveTimeSetup(objOfficeTimeDTO);
            MessageBox(strMsg);  
        }
      
        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                //throw new Exception("Error : " +ex.Message);
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlDutyType.SelectedValue == "")
                {
                    string strMsg = "Please Select Shift";
                    MessageBox(strMsg);
                    ddlDutyType.Focus();
                    return;
                }
                if (txtLogInTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert Login Time";
                        MessageBox(strMsg);
                        txtLogInTime.Focus();
                        return;
                    }
                    if (txtLogOutTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert Logout Time";
                        MessageBox(strMsg);
                        txtLogOutTime.Focus();
                        return;
                    }
                    if (txtLunchInTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert LunchIn Time";
                        MessageBox(strMsg);
                        txtLunchInTime.Focus();
                        return;
                    }
                    if (txtLunchOutTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert LunchIn Time";
                        MessageBox(strMsg);
                        txtLunchOutTime.Focus();
                        return;
                    }
                    if (txtPunchStartTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert Punch Start Time";
                        MessageBox(strMsg);
                        txtPunchStartTime.Focus();
                        return;
                    }
                    if (txtPunchEndTime.Text.Trim() == string.Empty)
                    {
                        string strMsg = "Please Insert Punch End Time";
                        MessageBox(strMsg);
                        txtPunchEndTime.Focus();
                        return;
                    }
                   SaveTimeSetup();
                   Reset();
                   GetTimeSetup();  
                }            
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}