
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SINHA.MEDLAR.ERP.DTO;
using SINHA.MEDLAR.ERP.BLL;

using System.Configuration;
using System.Web.Security;
using System.Data;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class RoamingEmployee : System.Web.UI.Page
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
                clearMsg();
                getOfficeName();
                getUnitId();
                getSectionId();
                GetRoamingType();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }
        #region "FUNCTION"
        public void GetRoamingType()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlRoamingTypeId.DataSource = objLookUpBLL.GetRoamingType();

            ddlRoamingTypeId.DataTextField = "ROAMING_TYPE_NAME";
            ddlRoamingTypeId.DataValueField = "ROAMING_TYPE_ID";

            ddlRoamingTypeId.DataBind();
            if (ddlRoamingTypeId.Items.Count > 0)
            {
                ddlRoamingTypeId.SelectedIndex = 0;
            }
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
        public void clearMsg()
        {

            lblMsg.Text = string.Empty;
            //lblMsgRecord.Text = string.Empty;
        }
        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
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

        public void GetRoamingEmployee()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;

            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }

            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }
            
            objEmployeeDTO.Date = dtpRoamingDateSearch.Text;
            

            dt = objEmployeeBLL.GetRoamingEmployee(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GvRoamingEmployee.DataSource = dt;
                GvRoamingEmployee.DataBind();

                int count = ((DataTable)GvRoamingEmployee.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                //lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvRoamingEmployee.DataSource = dt;
                GvRoamingEmployee.DataBind();
                int totalcolums = GvRoamingEmployee.Rows[0].Cells.Count;
                GvRoamingEmployee.Rows[0].Cells.Clear();
                GvRoamingEmployee.Rows[0].Cells.Add(new TableCell());
                GvRoamingEmployee.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GvRoamingEmployee.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                string strMsg = "NO RECORD FOUND!!!";
                //lblMsgRecord.Text = strMsg;
            }
        }


       
        public void GetEmployeeforRoaming()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
            objEmployeeDTO.EmployeeId = txtEmpId.Text;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            
            if (ddlUnitId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.UnitId = ddlUnitId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.UnitId = "";
            }
            
            if (ddlSectionId.SelectedValue.ToString() != " ")
            {
                objEmployeeDTO.SectionId = ddlSectionId.SelectedValue.ToString();
            }
            else
            {
                objEmployeeDTO.SectionId = "";
            }
            
            dt = objEmployeeBLL.employeeRecordforTransfer(objEmployeeDTO);
            
            if (dt.Rows.Count > 0)
            {
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();

                int count = ((DataTable)gvEmployeeList.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                //lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvEmployeeList.DataSource = dt;
                gvEmployeeList.DataBind();
                int totalcolums = gvEmployeeList.Rows[0].Cells.Count;
                gvEmployeeList.Rows[0].Cells.Clear();
                gvEmployeeList.Rows[0].Cells.Add(new TableCell());
                gvEmployeeList.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvEmployeeList.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                string strMsg = "NO RECORD FOUND!!!";
                //lblMsgRecord.Text = strMsg;
            }
        }
        public void SaveRoamingEmployee()
        {
            
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();

            objSalaryDTO.RoamingId = txtRoamingId.Text;
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;
            if (ddlRoamingTypeId.SelectedValue.ToString() != "")
             {
                 objSalaryDTO.RoamingTypeId = ddlRoamingTypeId.SelectedValue.ToString();
             }
             else
             {
                 objSalaryDTO.RoamingTypeId = "";
             }
             objSalaryDTO.Date = dtpRoamingDate.Text;
             objSalaryDTO.LoginEmployee = strEmployeeId;
             objSalaryDTO.HeadOfficeId = strHeadOfficeId;
             objSalaryDTO.BranchOfficeId = strBranchOfficeId;
             
            string strMsg = objSalaryBLL.SaveRoamingEmployee(objSalaryDTO);
             lblMsg.Text = strMsg;

             Reset();
             lblMsg.Text = strMsg;
        }

     

        #endregion
             
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
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

                    GetEmployeeforRoaming();
                    GetRoamingEmployee();
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmployeeId.Text == "")
                {
                    string strMsg = "Select Employee";
                    txtEmployeeId.Focus();
                    MessageBox(strMsg);
                    return;
                }
                if (ddlRoamingTypeId.SelectedValue.ToString() == "")
                {
                    string strMsg = "Select Roaming Type";
                    ddlRoamingTypeId.Focus();
                    MessageBox(strMsg);
                    return;
                }

                if (dtpRoamingDate.Text == "")
                {
                    string strMsg = "Enter Roaming Date";
                    ddlRoamingTypeId.Focus();
                    MessageBox(strMsg);
                    return;
                    
                }
                    SaveRoamingEmployee();
                    GetRoamingEmployee();
                    GetEmployeeforRoaming();
            }
            catch (Exception ex)
            {
            }
        }       
        protected void GvRoamingEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvRoamingEmployee.PageIndex = e.NewPageIndex;

        }
        protected void GvRoamingEmployee_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int strRowId = GvRoamingEmployee.SelectedRow.RowIndex + 1;

            string dLNo = GvRoamingEmployee.SelectedRow.Cells[0].Text;
            string cardNo = GvRoamingEmployee.SelectedRow.Cells[1].Text;
            string employeeName = GvRoamingEmployee.SelectedRow.Cells[2].Text;
            string designation = GvRoamingEmployee.SelectedRow.Cells[3].Text;
            string roamingDate = GvRoamingEmployee.SelectedRow.Cells[4].Text;
            string employeeId = GvRoamingEmployee.SelectedRow.Cells[5].Text;
            string roamingTypeId = GvRoamingEmployee.SelectedRow.Cells[7].Text;
            string roamingId = GvRoamingEmployee.SelectedRow.Cells[8].Text;

            txtSL.Text = dLNo;
            txtCardNo.Text = cardNo;
            txtEmployeeName.Text = employeeName;
            txtDesignationName.Text = designation;
            txtEmployeeId.Text = employeeId;
            dtpRoamingDate.Text = roamingDate;
            ddlRoamingTypeId.SelectedValue = roamingTypeId;
            txtRoamingId.Text = roamingId;
            GetRoamingEmployee();
        }
        protected void GvRoamingEmployee_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GvRoamingEmployee_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void GvRoamingEmployee_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvRoamingEmployee, "Select$" + e.Row.RowIndex);
            }
        }
        protected void GvRoamingEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void GvRoamingEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            string transferId = Convert.ToString(GvRoamingEmployee.DataKeys[e.RowIndex].Values["employee_id"]);
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string MSG = objSalaryBLL.DeleteVirtualTransfer(transferId, strBranchOfficeId, strHeadOfficeId);
            lblMsg.Text = MSG;
            MessageBox(MSG);

            GetRoamingEmployee();
        }

        protected void gvEmployeeList_OnSelectedIndexChanged(object sender, EventArgs e)
        {

            int strRowId = gvEmployeeList.SelectedRow.RowIndex + 1;

            string dLNo = gvEmployeeList.SelectedRow.Cells[0].Text;
            string cardNo = gvEmployeeList.SelectedRow.Cells[1].Text;
            string employeeName = gvEmployeeList.SelectedRow.Cells[2].Text;
            string designation = gvEmployeeList.SelectedRow.Cells[3].Text;       
            string employeeId = gvEmployeeList.SelectedRow.Cells[4].Text;

            txtSL.Text = dLNo;
            txtCardNo.Text = cardNo;
            txtEmployeeName.Text = employeeName;
            txtDesignationName.Text = designation;
            txtEmployeeId.Text = employeeId;

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            //HfTransferId.Value = string.Empty;
            ddlRoamingTypeId.SelectedIndex = 0;
            dtpRoamingDate.Text = string.Empty;
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            txtRoamingId.Text = string.Empty;
        }
    
    }
}