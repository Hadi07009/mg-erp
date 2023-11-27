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
    public partial class AttendanceBonusSetup : System.Web.UI.Page
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
                getDesignationId();
                GetAttendanceBonus();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
            txtWorkingDay.Attributes.Add("onkeypress", "return controlEnter('" + txtAttendanceBonusAmt.ClientID + "', event)");

            if(strBranchOfficeId == "110")
            {
                txtWorkingDay.Visible = false;
                lblWorkingDay.Visible = false;
            }
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
        public void getDesignationId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlDesignationId.DataSource = objLookUpBLL.getDesignationId(strHeadOfficeId, strBranchOfficeId);

            ddlDesignationId.DataTextField = "DESIGNATION_NAME";
            ddlDesignationId.DataValueField = "DESIGNATION_ID";

            ddlDesignationId.DataBind();
            if (ddlDesignationId.Items.Count > 0)
            {
                ddlDesignationId.SelectedIndex = 0;
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
        public void GetAttendanceBonus()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            dt = objEmployeeBLL.GetAttendanceBonus(objEmployeeDTO);
            if (dt.Rows.Count > 0)
            {
                gvAttendanceBonusSetup.DataSource = dt;
                gvAttendanceBonusSetup.DataBind();
                string strMsg = "TOTAL " + gvAttendanceBonusSetup.Rows.Count + " RECORD FOUND";
                lblMsg.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvAttendanceBonusSetup.DataSource = dt;
                gvAttendanceBonusSetup.DataBind();
                int totalcolums = gvAttendanceBonusSetup.Rows[0].Cells.Count;
                gvAttendanceBonusSetup.Rows[0].Cells.Clear();
                gvAttendanceBonusSetup.Rows[0].Cells.Add(new TableCell());
                gvAttendanceBonusSetup.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvAttendanceBonusSetup.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                MessageBox(strMsg);
                lblMsg.Text = strMsg;
            }
        }
        public void SaveAttendanceBonus()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();


            if (ddlDesignationId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.DesignationId = ddlDesignationId.Text;
            }
            else
            {
                objEmployeeDTO.DesignationId = "";
            }
            objEmployeeDTO.WorkingDay = txtWorkingDay.Text;
            objEmployeeDTO.AttendanceBonus = txtAttendanceBonusAmt.Text;
            objEmployeeDTO.EmployeeId = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.SaveAttendanceBonus(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

        public void clearTextBox()
        {
            ddlDesignationId.Text = " ";
            txtWorkingDay.Text = "";
            txtAttendanceBonusAmt.Text = "";
        }
        #endregion
        #region "GridView Functionlity"
        protected void gvAttendanceBonusSetup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAttendanceBonusSetup.PageIndex = e.NewPageIndex;
            GetAttendanceBonus();
        }
        protected void gvAttendanceBonusSetup_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = gvAttendanceBonusSetup.SelectedRow.RowIndex;
            string designationId = gvAttendanceBonusSetup.SelectedRow.Cells[3].Text;
            string WorkingDay = gvAttendanceBonusSetup.SelectedRow.Cells[1].Text;
            string AttendanceBonus = gvAttendanceBonusSetup.SelectedRow.Cells[2].Text;

            ddlDesignationId.Text = designationId;
            txtWorkingDay.Text = WorkingDay;
            txtAttendanceBonusAmt.Text = AttendanceBonus;
        }
        protected void gvAttendanceBonusSetup_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");

        }
        protected void gvAttendanceBonusSetup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAttendanceBonusSetup.EditIndex = e.NewEditIndex;
            GetAttendanceBonus();
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.gvAttendanceBonusSetup, "Select$" + e.Row.RowIndex);
            }
        }
        #endregion
        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearTextBox();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlDesignationId.Text == " ")
            {
                string strMsg = "Please Select Designation";
                ddlDesignationId.Focus();
                MessageBox(strMsg);
                return;
            }
            if (txtWorkingDay.Text == "" && strBranchOfficeId !="110")
            {
                string strMsg = "Please Enter Working Day";
                txtWorkingDay.Focus();
                MessageBox(strMsg);
                return;
            }
            if (txtAttendanceBonusAmt.Text == "")
            {
                string strMsg = "Please Enter Attendance Bonus";
                txtAttendanceBonusAmt.Focus();
                MessageBox(strMsg);
                return;
            }
            else
            {
                SaveAttendanceBonus();
                GetAttendanceBonus();
                clearTextBox();
            }
        }
    }
}