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
    public partial class AddOfficeTime : System.Web.UI.Page
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
                loadOfficeRecord();
                getUnitId();
                getSectionId();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }

            dtpEffectiveDate.Attributes.Add("onkeypress", "return controlEnter('" + txtLogInTime.ClientID + "', event)");
            txtLogInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLogOutTime.ClientID + "', event)");
            txtLogOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchOutTime.ClientID + "', event)");
            txtLunchOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchInTime.ClientID + "', event)");

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
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }
        public void loadOfficeRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadOfficeRecord(strHeadOfficeId, strBranchOfficeId);


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
        public void clearTextBox()
        {
            ddlUnitId.SelectedIndex = 0;
            ddlSectionId.SelectedIndex = 0;
            txtLogInTime.Text = string.Empty;
            txtLogOutTime.Text = string.Empty;
            txtLunchInTime.Text = string.Empty;
            txtLunchOutTime.Text = string.Empty;
            txtPunchStartTime.Text = string.Empty;
            txtPunchEndTime.Text = string.Empty;
            txtTimeId.Text = string.Empty;
            dtpEffectiveDate.Text = string.Empty;
        }

        public void Reset()
        {
            txtTimeId.Text = string.Empty;

            ddlUnitId.SelectedIndex = 0;
            ddlSectionId.SelectedIndex = 0;
            txtLogInTime.Text = string.Empty;
            txtLogOutTime.Text = string.Empty;
            txtLunchInTime.Text = string.Empty;
            txtLunchOutTime.Text = string.Empty;
            txtPunchStartTime.Text = string.Empty;
            txtPunchEndTime.Text = string.Empty;
            dtpEffectiveDate.Text = string.Empty;
        }

        public void getUnitId()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlUnitId.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitId.DataTextField = "UNIT_NAME";
            ddlUnitId.DataValueField = "UNIT_ID";

            ddlUnitId.DataBind();
            if (ddlUnitId.Items.Count > 0)
            {
                ddlUnitId.SelectedIndex = 0;
            }
        }
        public void getSectionId()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionId.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionId.DataTextField = "SECTION_NAME";
            ddlSectionId.DataValueField = "SECTION_ID";

            ddlSectionId.DataBind();
            if (ddlSectionId.Items.Count > 0)
            {
                ddlSectionId.SelectedIndex = 0;
            }
        }
        #endregion
        #region "Gridview Functionality"
        protected void gvUnit_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUnit.PageIndex = e.NewPageIndex;
            loadOfficeRecord();
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
                int strRowId = gvUnit.SelectedRow.RowIndex;
                string strUnitName = gvUnit.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
                string strSectionName = gvUnit.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
                string strEffectiveDate = gvUnit.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
                string strLoginTime = gvUnit.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
                string strLogOutTime = gvUnit.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
                string strLunchOutTime = gvUnit.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
                string strLunchInTime = gvUnit.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
                string PunchStartTime = gvUnit.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
                string PunchEndTime = gvUnit.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

                string unitId = gvUnit.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
                string sectionId = gvUnit.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
                string TimeId = gvUnit.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");

                dtpEffectiveDate.Text = strEffectiveDate;
                txtLogInTime.Text = strLoginTime;
                txtLogOutTime.Text = strLogOutTime;
                txtLunchInTime.Text = strLunchInTime;
                txtLunchOutTime.Text = strLunchOutTime;
                txtPunchStartTime.Text = PunchStartTime;
                txtPunchEndTime.Text = PunchEndTime;
                txtTimeId.Text = TimeId;
                ddlUnitId.SelectedValue = unitId;
                ddlSectionId.SelectedValue = sectionId;
            
        }

        public void addOfficeTime()
        {
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();
            OfficeTimeBLL objOfficeTimeBLL = new OfficeTimeBLL();

            string strMsg = "";
            int recordCounter = 0;
            string strCount = gvUnit.Rows.Count.ToString();

            foreach (GridViewRow row in gvUnit.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkId = (CheckBox)row.FindControl("chkId");
                    if (chkId.Checked)
                    {
                        recordCounter = recordCounter + 1;
                    }
                }
            }

            if(!string.IsNullOrEmpty(txtTimeId.Text) && recordCounter>0)
            {
                MessageBox("Mixed mode found, please try again.");
                Reset();
                return;
            }
            
            if (recordCounter == 0)
            {
                objOfficeTimeDTO.TimeId = txtTimeId.Text;
                objOfficeTimeDTO.UnitId = ddlUnitId.SelectedValue;
                objOfficeTimeDTO.SectionId = ddlSectionId.SelectedValue;
                objOfficeTimeDTO.EffectDate = dtpEffectiveDate.Text;
                objOfficeTimeDTO.LogInTime = txtLogInTime.Text;
                objOfficeTimeDTO.LogOutTime = txtLogOutTime.Text;
                objOfficeTimeDTO.LunchInTime = txtLunchInTime.Text;
                objOfficeTimeDTO.LunchOutTime = txtLunchOutTime.Text;
                objOfficeTimeDTO.PunchStartTime = txtPunchStartTime.Text;
                objOfficeTimeDTO.PunchEndTime = txtPunchEndTime.Text;
                objOfficeTimeDTO.UpdateBy = strEmployeeId;
                objOfficeTimeDTO.HeadOfficeId = strHeadOfficeId;
                objOfficeTimeDTO.BranchOfficeId = strBranchOfficeId;

                strMsg = objOfficeTimeBLL.addOfficeTime(objOfficeTimeDTO);
                MessageBox(strMsg);
            }
            else
            {
                foreach (GridViewRow row in gvUnit.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkId = (CheckBox)row.FindControl("chkId");
                        if (chkId.Checked)
                        {
                            recordCounter = recordCounter + 1;
                            string UnitId = (row.FindControl("lblUnitId") as Label).Text;
                            string SectionId = (row.FindControl("lblSectionId") as Label).Text;
                            string TimeId = (row.FindControl("lblTimeId") as Label).Text;

                            objOfficeTimeDTO.TimeId = TimeId;
                            objOfficeTimeDTO.UnitId = UnitId;
                            objOfficeTimeDTO.SectionId = SectionId;
                            objOfficeTimeDTO.EffectDate = dtpEffectiveDate.Text;
                            objOfficeTimeDTO.LogInTime = txtLogInTime.Text;
                            objOfficeTimeDTO.LogOutTime = txtLogOutTime.Text;
                            objOfficeTimeDTO.LunchInTime = txtLunchInTime.Text;
                            objOfficeTimeDTO.LunchOutTime = txtLunchOutTime.Text;
                            objOfficeTimeDTO.PunchStartTime = txtPunchStartTime.Text;
                            objOfficeTimeDTO.PunchEndTime = txtPunchEndTime.Text;
                            objOfficeTimeDTO.UpdateBy = strEmployeeId;
                            objOfficeTimeDTO.HeadOfficeId = strHeadOfficeId;
                            objOfficeTimeDTO.BranchOfficeId = strBranchOfficeId;

                            strMsg = objOfficeTimeBLL.addOfficeTime(objOfficeTimeDTO);
                        }
                    }
                }
               // lblMsg.Text = strMsg;
                MessageBox(strMsg);
            }
        }
        public void searchOfficeTime()
        {
            OfficeTimeDTO objOfficeTimeDTO = new OfficeTimeDTO();
            OfficeTimeBLL objOfficeTimeBLL = new OfficeTimeBLL();


            string strSection;
            string strUnit;
            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                strSection = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                strSection = "";
            }

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                strUnit = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                strUnit = "";
            }
            objOfficeTimeDTO = objOfficeTimeBLL.searchOfficeTime(strUnit, strSection, strHeadOfficeId, strBranchOfficeId);

            dtpEffectiveDate.Text = objOfficeTimeDTO.EffectDate;
            txtLogInTime.Text = objOfficeTimeDTO.LogInTime;
            txtLogOutTime.Text = objOfficeTimeDTO.LogOutTime;
            txtLunchInTime.Text = objOfficeTimeDTO.LunchInTime;
            txtLunchOutTime.Text = objOfficeTimeDTO.LunchOutTime;
        }
        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                //clearTextBox();
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
                    if (txtLogInTime.Text == string.Empty)
                    {
                        string strMsg = "Please Insert Login Time";
                        MessageBox(strMsg);
                        txtLogInTime.Focus();
                        return;
                    }
                    if (txtLogOutTime.Text == string.Empty)
                    {
                        string strMsg = "Please Insert Logout Time";
                        MessageBox(strMsg);
                        txtLogOutTime.Focus();
                        return;
                    }
                    if (txtLunchInTime.Text == string.Empty)
                    {
                        string strMsg = "Please Insert LunchIn Time";
                        MessageBox(strMsg);
                        txtLunchInTime.Focus();
                        return;
                    }
                    if (txtLunchOutTime.Text == string.Empty)
                    {
                        string strMsg = "Please Insert LunchIn Time";
                        MessageBox(strMsg);
                        txtLunchOutTime.Focus();
                        return;
                    }
                    if (txtPunchStartTime.Text == string.Empty)
                    {
                        string strMsg = "Please Insert Punch Start Time";
                        MessageBox(strMsg);
                        txtPunchStartTime.Focus();
                        return;
                    }
                    if (txtPunchEndTime.Text == string.Empty)
                    {
                        string strMsg = "Please Insert Punch End Time";
                        MessageBox(strMsg);
                        txtPunchEndTime.Focus();
                        return;
                    }
                    if (dtpEffectiveDate.Text == string.Empty)
                    {
                        string strMsg = "Please Insert Effect Date";
                        MessageBox(strMsg);
                        dtpEffectiveDate.Focus();
                        return;
                    }
                   addOfficeTime();
                   Reset();
                   loadOfficeRecord();  
                }            
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlUnitId.Text == " ")
            {

                string strMsg = "Please Select Unit Name!!!";
                MessageBox(strMsg);
                ddlUnitId.Focus();
                return;
            }

            else if (ddlSectionId.Text == " ")
            {
                string strMsg = "Please Select Section Name!!!";
                MessageBox(strMsg);
                ddlSectionId.Focus();
                return;
            }
            else
            {
                searchOfficeTime();
            }
        }
    }
}