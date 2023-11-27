using SINHA.MEDLAR.ERP.BLL;
using SINHA.MEDLAR.ERP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class SpecialShiftConfiguration : System.Web.UI.Page
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
                //loadShiftRecord();
                GetSpecialShiftConfiguration();
                //getShiftTypeId();
                //GetShift();
                GetSpecialShift();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            //txtLogInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLogOutTime.ClientID + "', event)");
            //txtLogOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchOutTime.ClientID + "', event)");
            //txtLunchOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchInTime.ClientID + "', event)");
            //txtLunchInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtGeneralOutTime.ClientID + "', event)");
        }

        #region 

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

        public void getShiftTypeId()
        {
            //LookUpBLL objLookUpBLL = new LookUpBLL();
            //ddlShiftId.DataSource = objLookUpBLL.getOfficeShiftTypeId(strHeadOfficeId, strBranchOfficeId);

            //ddlShiftId.DataTextField = "shift_type_name";
            //ddlShiftId.DataValueField = "SHIFT_TYPE_ID";

            //ddlShiftId.DataBind();
            //if (ddlShiftId.Items.Count > 0)
            //{
            //    ddlShiftId.SelectedIndex = 0;
            //}
        }

        public void GetSpecialShift()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            //ddlSpecialShift.Items.Insert(0, new ListItem("Please Select One"));

            ddlSpecialShift.DataSource = objLookUpBLL.GetSpecialShift();

            ddlSpecialShift.DataTextField = "SHIFT_NAME";
            ddlSpecialShift.DataValueField = "SHIFT_ID";
                        
            ddlSpecialShift.DataBind();
            ddlSpecialShift.Items.Insert(0, new ListItem("Please Select One", ""));
            //if (ddlSpecialShift.Items.Count > 0)
            //{
            //    ddlSpecialShift.SelectedIndex = 0;
            //}
        }
        //GetSpecialShift
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

        public void GetSpecialShiftConfiguration()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            //dt = objLookUpBLL.loadShiftRecord();
            dt = objLookUpBLL.GetSpecialShiftConfiguration(strHeadOfficeId, strBranchOfficeId);
            if (dt.Rows.Count > 0)
            {
                gvSpecialShiftConfiguration.DataSource = dt;
                gvSpecialShiftConfiguration.DataBind();
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

        public void searchEmpShift(string strShiftId, string strHeadOfficeId, string strBranchOfficeId)
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.searchEmpShift(strShiftId, strHeadOfficeId, strBranchOfficeId);

            //txtLogInTime.Text = objLookUpDTO.InTime;
            //txtLogOutTime.Text = objLookUpDTO.OutTime;
            //txtLunchInTime.Text = objLookUpDTO.LunchInTime;
            //txtLunchOutTime.Text = objLookUpDTO.LunchOutTime;
            //txtGeneralOutTime.Text = objLookUpDTO.GeneralOutTime;
            dtpEffectDate.Text = objLookUpDTO.EffectDate;

            GetSpecialShift();
        }

        public void saveShiftInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            //objLookUpDTO.ShiftId = txtShiftId.Text;
            
            if (ddlSpecialShift.Text != "")
            {
                objLookUpDTO.ShipTypeId = ddlSpecialShift.SelectedValue;
            }
            else
            {
                objLookUpDTO.ShipTypeId = "";
            }
                      
            objLookUpDTO.EffectDate = dtpEffectDate.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objLookUpBLL.saveShiftInfo(objLookUpDTO);
            MessageBox(strMsg);
        }

        public void SaveSpecialShiftConfiguration()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();
                        
            if(hf_shift_configuration_id.Value == string.Empty)
                objLookUpDTO.ShiftConfigurationId = 0;
            else
                objLookUpDTO.ShiftConfigurationId = Convert.ToDecimal(hf_shift_configuration_id.Value);

            objLookUpDTO.ShiftId = ddlSpecialShift.SelectedItem.Value;
            objLookUpDTO.PunchStartTime = txtPunchStartTime.Text;
            objLookUpDTO.LoginStartTime = txtLoginStartTime.Text;
            objLookUpDTO.LoginEndTime = txtLoginEndTime.Text;
            objLookUpDTO.LoginGraceTime = txtLoginGraceTime.Text == string.Empty ? 0 : Convert.ToDecimal(txtLoginGraceTime.Text);

            objLookUpDTO.LunchOutTime = txtLunchOutTime.Text;
            objLookUpDTO.LunchInTime = txtLunchInTime.Text;

            objLookUpDTO.LunchOutStartTime = txtLunchOutStartTime.Text;
            objLookUpDTO.LunchOutEndTime = txtLunchOutEndTime.Text;
            objLookUpDTO.LunchInStartTime = txtLunchInStartTime.Text;
            objLookUpDTO.LunchInEndTime = txtLunchInEndTime.Text;

            objLookUpDTO.LogoutStratTime = txtLogoutStartTime.Text;
            objLookUpDTO.LogoutTime = txtLogoutTime.Text;
            objLookUpDTO.PunchEndTime = txtPunchEndTime.Text;

            //objLookUpDTO.EearlyOtStartTime = txtEearlyOtStartTime.Text;

            objLookUpDTO.EffectDate = dtpEffectDate.Text;
            objLookUpDTO.ActiveYn = chkActiveYn.Checked == true ? "Y" : "N";
           
            objLookUpDTO.CreateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;

            //string strMsg = objLookUpBLL.saveShiftInfo(objLookUpDTO);
            string strMsg = objLookUpBLL.SaveSpecialShiftConfiguration(objLookUpDTO);
            MessageBox(strMsg);
            if (hf_shift_configuration_id.Value == string.Empty)
               ClearAll();
        }

        #endregion
        protected void gvSpecialShiftConfiguration_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSpecialShiftConfiguration.PageIndex = e.NewPageIndex;
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.backgroundColor='purple';";
                //e.Row.Attributes["onmouseout"] = "this.style.backgroundColor='none';";

                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
            }
        }

        protected void gvSpecialShiftConfiguration_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            hf_shift_id.Value = string.Empty;
            int strRowId = gvSpecialShiftConfiguration.SelectedRow.RowIndex;
             
            txtPunchStartTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            txtLoginStartTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtLoginGraceTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtLoginEndTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtLunchOutTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            txtLunchInTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");
            txtLogoutTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            txtPunchEndTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            dtpEffectDate.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            string activeYn = gvSpecialShiftConfiguration.SelectedRow.Cells[10].Text.Replace("&nbsp;", "");
            if (activeYn == "Y")
                chkActiveYn.Checked = true;
            else
                chkActiveYn.Checked = false;

            hf_shift_configuration_id.Value = gvSpecialShiftConfiguration.SelectedRow.Cells[11].Text.Replace("&nbsp;", "");
            hf_shift_id.Value = gvSpecialShiftConfiguration.SelectedRow.Cells[12].Text.Replace("&nbsp;", "");
            //txtShiftId.Text = hf_shift_id.Value;
            ddlSpecialShift.SelectedValue = hf_shift_id.Value;

            txtLunchOutStartTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[13].Text.Replace("&nbsp;", "");
            txtLunchOutEndTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[14].Text.Replace("&nbsp;", "");
            txtLunchInStartTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[15].Text.Replace("&nbsp;", "");
            txtLunchInEndTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[16].Text.Replace("&nbsp;", "");
            //txtEearlyOtStartTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
            txtLogoutStartTime.Text = gvSpecialShiftConfiguration.SelectedRow.Cells[17].Text.Replace("&nbsp;", "");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlSpecialShift.Text == "")
                {
                    string strMsg = "Please Select Shift";
                    dtpEffectDate.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtPunchStartTime.Text == "")
                {
                    string strMsg = "Please Punch Start Time!!!";
                    txtPunchStartTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (dtpEffectDate.Text == "")
                {
                    string strMsg = "Please Enter Effect Date!!!";
                    dtpEffectDate.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (txtLoginStartTime.Text == "")
                {
                    string strMsg = "Please Enter Login Start Time!!!";
                    txtLoginStartTime.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (txtLoginGraceTime.Text == "")
                {
                    string strMsg = "Please Enter Login Grace Time!!!";
                    txtLoginGraceTime.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (txtLoginEndTime.Text == "")
                {
                    string strMsg = "Please Enter Login Time!!!";
                    txtLoginEndTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtLunchOutTime.Text == "")
                {
                    string strMsg = "Please Enter Lunch Out Time!!!";
                    txtLunchOutTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtLunchInTime.Text == "")
                {
                    string strMsg = "Please Enter Lunch In Time!!!";
                    txtLunchInTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtLunchOutStartTime.Text == "")
                {
                    string strMsg = "Please Enter Lunch Out Start Time!!!";
                    txtLunchOutStartTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtLunchOutEndTime.Text == "")
                {
                    string strMsg = "Please Enter Lunch Out End Time!!!";
                    txtLunchOutEndTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtLunchInStartTime.Text == "")
                {
                    string strMsg = "Please Enter Lunch In Start Time!!!";
                    txtLunchInStartTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtLunchInEndTime.Text == "")
                {
                    string strMsg = "Please Enter Lunch In End Time!!!";
                    txtLunchInEndTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtLogoutTime.Text == "")
                {
                    string strMsg = "Please Enter Logout Time!!!";
                    txtLogoutTime.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (txtPunchEndTime.Text == "")
                {
                    string strMsg = "Please Enter Punch End Time!!!";
                    txtPunchEndTime.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    SaveSpecialShiftConfiguration();
                    GetSpecialShiftConfiguration();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            //txtShiftId.Text = string.Empty;
            dtpEffectDate.Text = string.Empty;
            ddlSpecialShift.SelectedValue = string.Empty;
            txtPunchStartTime.Text = string.Empty;
            txtPunchEndTime.Text = string.Empty;

            txtLoginStartTime.Text = string.Empty;
            txtLoginGraceTime.Text = string.Empty;
            txtLoginEndTime.Text = string.Empty;

            txtLunchOutTime.Text = string.Empty;
            txtLunchInTime.Text = string.Empty;

            txtLunchOutStartTime.Text = string.Empty;
            txtLunchOutEndTime.Text = string.Empty;
            txtLunchInStartTime.Text = string.Empty;
            txtLunchInEndTime.Text = string.Empty;

            txtLogoutStartTime.Text = string.Empty;
            txtLogoutTime.Text = string.Empty;
            //txtEearlyOtStartTime.Text = string.Empty;
            chkActiveYn.Checked = false;
            hf_shift_configuration_id.Value = string.Empty;
            hf_shift_id.Value = string.Empty;

            //txtPunchEndTime.Text = string.Empty;
        }
    }
}