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
    public partial class ShiftOfficeTimeSetup : System.Web.UI.Page
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
                loadShiftRecord();
                getShiftTypeId();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            txtLogInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLogOutTime.ClientID + "', event)");
            txtLogOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchOutTime.ClientID + "', event)");
            txtLunchOutTime.Attributes.Add("onkeypress", "return controlEnter('" + txtLunchInTime.ClientID + "', event)");
            txtLunchInTime.Attributes.Add("onkeypress", "return controlEnter('" + txtGeneralOutTime.ClientID + "', event)");
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
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShiftId.DataSource = objLookUpBLL.getOfficeShiftTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlShiftId.DataTextField = "shift_type_name";
            ddlShiftId.DataValueField = "SHIFT_TYPE_ID";

            ddlShiftId.DataBind();
            if (ddlShiftId.Items.Count > 0)
            {
                ddlShiftId.SelectedIndex = 0;
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void loadShiftRecord()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            DataTable dt = new DataTable();
            dt = objLookUpBLL.loadShiftRecord();
            if (dt.Rows.Count > 0)
            {
                gvUnit.DataSource = dt;
                gvUnit.DataBind();
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

            txtLogInTime.Text = objLookUpDTO.InTime;
            txtLogOutTime.Text = objLookUpDTO.OutTime;
            txtLunchInTime.Text = objLookUpDTO.LunchInTime;
            txtLunchOutTime.Text = objLookUpDTO.LunchOutTime;
            txtGeneralOutTime.Text = objLookUpDTO.GeneralOutTime;
            dtpEffectDate.Text = objLookUpDTO.EffectDate;

            if (objLookUpDTO.ShipTypeId == " ")
            {
                getShiftTypeId();
            }
            else
            {
                ddlShiftId.SelectedValue = objLookUpDTO.ShipTypeId;
            }
        }

        public void saveShiftInfo()
        {

            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO.ShiftId = txtShiftId.Text;

            if (ddlShiftId.Text != "0")
            {
                objLookUpDTO.ShipTypeId = ddlShiftId.SelectedValue;
            }
            else
            {
                objLookUpDTO.ShipTypeId = "";
            }

            objLookUpDTO.InTime = txtLogInTime.Text;
            objLookUpDTO.OutTime = txtLogOutTime.Text;

            objLookUpDTO.LunchInTime = txtLunchInTime.Text;
            objLookUpDTO.LunchOutTime = txtLunchOutTime.Text;

            objLookUpDTO.GeneralOutTime = txtGeneralOutTime.Text;
            objLookUpDTO.EffectDate = dtpEffectDate.Text;

            objLookUpDTO.UpdateBy = strEmployeeId;
            objLookUpDTO.HeadOfficeId = strHeadOfficeId;
            objLookUpDTO.BranchOfficeId = strBranchOfficeId;
            string strMsg = objLookUpBLL.saveShiftInfo(objLookUpDTO);
            MessageBox(strMsg);
        }

        #endregion
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
            int strRowId = gvUnit.SelectedRow.RowIndex;
            string strShiftId = gvUnit.SelectedRow.Cells[0].Text;

            txtShiftId.Text = strShiftId;

            searchEmpShift(txtShiftId.Text, strHeadOfficeId, strBranchOfficeId);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlShiftId.Text == " ")
                {
                    string strMsg = "Please Enter Effect Date!!!";
                    dtpEffectDate.Focus();
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
                else if (txtLogInTime.Text == "")
                {
                    string strMsg = "Please Enter Login Time!!!";
                    txtLogInTime.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (txtLogOutTime.Text == "")
                {
                    string strMsg = "Please Enter Log Out!!!";
                    txtLogOutTime.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else if (txtGeneralOutTime.Text == "")
                {
                    string strMsg = "Please Enter General Out Time!!!";
                    txtGeneralOutTime.Focus();
                    MessageBox(strMsg);
                    return;
                }
                else
                {
                    saveShiftInfo();
                    loadShiftRecord();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
    }
}