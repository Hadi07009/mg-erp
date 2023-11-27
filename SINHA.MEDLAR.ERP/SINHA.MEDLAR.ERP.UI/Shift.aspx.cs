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
    public partial class Shift : System.Web.UI.Page
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
                GetShift();
                GetDutyType();
                getOfficeName();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            lblMsg.Text = "";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtShiftName.Text == string.Empty)
            {
                string strMsg = "Please Enter Shift Name";
                MessageBox(strMsg);
                txtShiftName.Focus();
                return;
            }

                SaveShift();
                clearTextBox();
                GetShift();
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
        public void GetDutyType()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
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
        public void SaveShift()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.ShiftId = txtShiftId.Text;
            objEmployeeDTO.ShiftName = txtShiftName.Text;
            objEmployeeDTO.DutyTypeId = ddlDutyType.SelectedValue;

            objEmployeeDTO.CreateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.SaveShift(objEmployeeDTO);
            lblMsgRecord.Text = strMsg;
            lblMsg.Text = strMsg;
            MessageBox(strMsg);

        }
        public void GetShift()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            DataTable dt = new DataTable();
            dt = objEmployeeBLL.GetShift(strHeadOfficeId,strBranchOfficeId);


            if (dt.Rows.Count > 0)
            {
                gvShift.DataSource = dt;
                gvShift.DataBind();
                string strMsg = "TOTAL " + gvShift.Rows.Count + " RECORD FOUND";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
            else
            {
               // dt.Rows.Add(dt.NewRow());
                gvShift.DataSource = dt;
                gvShift.DataBind();
                //int totalcolums = gvShift.Rows[0].Cells.Count;
                //gvShift.Rows[0].Cells.Clear();
                //gvShift.Rows[0].Cells.Add(new TableCell());
                //gvShift.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //gvShift.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                //string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //lblMsg.Text = strMsg;
                //lblMsgRecord.Text = strMsg;
            }
        }
        public void clearTextBox()
        {
            txtShiftId.Text = string.Empty;
            txtShiftName.Text = string.Empty;
            ddlDutyType.SelectedIndex = 0;
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtDefendantId.Text == string.Empty)
            //{

            //    string strMsg = "Please Enter Color ID!!!";
            //    MessageBox(strMsg);
            //    txtDefendantId.Focus();
            //    return;
            //}
            //else
            //{
            //    searchBuyerRecord();

            //}
        }
        protected void gvShift_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvShift.PageIndex = e.NewPageIndex;
        }

        protected void gvShift_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvShift, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvShift_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvShift.SelectedRow.RowIndex;
            string shiftName = gvShift.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string shiftId = gvShift.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string DutyTypeID = gvShift.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");

            txtShiftId.Text = shiftId;
            //if(rosterYn == "Yes")
            //   chkRosterYn.Checked = true;
            //else
            //  chkRosterYn.Checked = false;
            txtShiftName.Text = shiftName;
            ddlDutyType.SelectedValue = DutyTypeID;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                clearTextBox();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }
    }
}