
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
    public partial class VirtualTransferNew : System.Web.UI.Page
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
                GetTime();
                GetFloorDropdown();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }

        #region "FUNCTION"
                
        public void GetTime()
        {
            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlTimeId.DataSource = objLookUpBLL.GetTime(strHeadOfficeId, strBranchOfficeId);

            ddlTimeId.DataTextField = "TIME_NAME";
            ddlTimeId.DataValueField = "TIME_ID";

            ddlTimeId.DataBind();
            if (ddlTimeId.Items.Count > 0)
            {
                ddlTimeId.SelectedIndex = 0;
            }
        }
        public void GetFloorDropdown()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            
            ddlFloor.DataSource = objLookUpBLL.GetFloorDropdown(strHeadOfficeId, strBranchOfficeId);

            ddlFloor.DataTextField = "FLOOR_NAME";
            ddlFloor.DataValueField = "FLOOR_ID";

            ddlFloor.DataBind();
            if (ddlFloor.Items.Count > 0)
            {
                ddlFloor.SelectedValue = "";
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

        public void GetVirtualTransfer()
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
            
            objEmployeeDTO.FromDate = dtpFromDate.Text;
            objEmployeeDTO.ToDate = dtpToDate.Text;

            dt = objEmployeeBLL.GetVirtualTransferNew(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GvVirtualTransfer.DataSource = dt;
                GvVirtualTransfer.DataBind();

                int count = ((DataTable)GvVirtualTransfer.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                //lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GvVirtualTransfer.DataSource = dt;
                GvVirtualTransfer.DataBind();
                int totalcolums = GvVirtualTransfer.Rows[0].Cells.Count;
                GvVirtualTransfer.Rows[0].Cells.Clear();
                GvVirtualTransfer.Rows[0].Cells.Add(new TableCell());
                GvVirtualTransfer.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GvVirtualTransfer.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                string strMsg = "NO RECORD FOUND!!!";
                //lblMsgRecord.Text = strMsg;
            }
        }


        public void GetVirtualTransferByTransferId(string transferId)
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
            
            dt = objEmployeeBLL.GetVirtualTransferByTransferId(transferId);
        }

        public void searchEmployeeRecordforTransfer()
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
        public void TransferVirtually()
        {
            
            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "Unable to Transfer";

            string strCount = gvEmployeeList.Rows.Count.ToString();

            foreach (GridViewRow row in gvEmployeeList.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {

                        string strId = (row.FindControl("lblEmployeeId") as Label).Text;

                        objSalaryDTO.EmployeeId = strId;

                        objSalaryDTO.VirtualOfficeId = strBranchOfficeId;


                        if (ddlTimeId.SelectedValue.ToString() != " ")
                        {
                            objSalaryDTO.TimeId = ddlTimeId.SelectedValue.ToString();
                        }
                        else
                        {
                            objSalaryDTO.TimeId = "";
                        }

                        if (ddlFloor.SelectedValue.ToString() != " ")
                        {
                            objSalaryDTO.FloorId = ddlFloor.SelectedValue.ToString();
                        }
                        else
                        {
                            objSalaryDTO.FloorId = "";
                        }


                        objSalaryDTO.FromDate = dtpFromDate.Text;
                        objSalaryDTO.ToDate = dtpToDate.Text;

                        objSalaryDTO.UpdateBy = strEmployeeId;
                        objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                        objSalaryDTO.BranchOfficeId = strBranchOfficeId;
                        
                        strMsg = objSalaryBLL.TransferVirtuallyNew(objSalaryDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;
                    }
                }
            }

            Reset();
            MessageBox(strMsg);
            lblMsg.Text = strMsg;
        }

        public string UpdateVirtualTransfer()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";
                                   
            objSalaryDTO.TransferId = HfTransferId.Value;
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;

            objSalaryDTO.VirtualOfficeId = strBranchOfficeId;

            //objSalaryDTO.ShiftId = ddlShift.SelectedValue.ToString();
            objSalaryDTO.TimeId = ddlTimeId.SelectedValue.ToString();

            objSalaryDTO.FloorId = ddlFloor.SelectedValue.ToString();
            
            objSalaryDTO.FromDate = dtpFromDate.Text;
            objSalaryDTO.ToDate = dtpToDate.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objSalaryBLL.UpdateVirtualTransferNew(objSalaryDTO);
            return strMsg;
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
                    GetVirtualTransfer();
                    searchEmployeeRecordforTransfer();
                }
            }
            catch (Exception ex)
            {
            }
        }
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvEmployeeList.Rows.Count == 0)
                {
                    string strMsg = "No Record Found!!!";
                    MessageBox(strMsg);
                    btnSearch.Focus();
                    return;
                }
                else
                {
                    string msg = ValidateForm();

                    if(!string.IsNullOrEmpty(msg))
                    {                      
                        MessageBox(msg);
                        return;
                    }

                    TransferVirtually();
                    GetVirtualTransfer();
                    searchEmployeeRecordforTransfer();
                }
            }
            catch (Exception ex)
            {
            }
        }       
        protected void GvVirtualTransfer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvVirtualTransfer.PageIndex = e.NewPageIndex;

        }
        protected void GvVirtualTransfer_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            
            HfTransferId.Value = string.Empty;
            Reset();

            int strRowId = GvVirtualTransfer.SelectedRow.RowIndex + 1;

            string dLNo = GvVirtualTransfer.SelectedRow.Cells[0].Text;
            string transferId = GvVirtualTransfer.SelectedRow.Cells[1].Text;
            string cardNo = GvVirtualTransfer.SelectedRow.Cells[2].Text;
            string employeeName = GvVirtualTransfer.SelectedRow.Cells[3].Text;
            string designation = GvVirtualTransfer.SelectedRow.Cells[4].Text;
            string fromDate = GvVirtualTransfer.SelectedRow.Cells[5].Text;
            string toDate = GvVirtualTransfer.SelectedRow.Cells[6].Text;
            string employeeId = GvVirtualTransfer.SelectedRow.Cells[8].Text;
            string virtualTimeId = GvVirtualTransfer.SelectedRow.Cells[9].Text.Replace("&nbsp", "");
            string virtualFloorId = GvVirtualTransfer.SelectedRow.Cells[10].Text.Replace("&nbsp", "");

            txtSL.Text = dLNo;
            HfTransferId.Value = transferId;
            txtCardNo.Text = cardNo;
            txtEmployeeName.Text = employeeName;
            txtDesignationName.Text = designation;
            txtEmployeeId.Text = employeeId;

            if (virtualTimeId == "" || virtualTimeId == ";")
                ddlTimeId.SelectedIndex = 0;
            else
                ddlTimeId.SelectedValue = virtualTimeId;

            if (virtualFloorId == "" || virtualFloorId == ";")
                ddlFloor.SelectedIndex = 0;
            else
                ddlFloor.SelectedValue = virtualFloorId;
            //ddlFloor.SelectedValue = virtualFloorId;

            dtpFromDate.Text = fromDate;
            dtpToDate.Text = toDate;

        }
        protected void GvVirtualTransfer_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        protected void GvVirtualTransfer_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void GvVirtualTransfer_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GvVirtualTransfer, "Select$" + e.Row.RowIndex);
            }
        }       
        protected void GvVirtualTransfer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }
        protected void GvVirtualTransfer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {            
            string transferId = Convert.ToString(GvVirtualTransfer.DataKeys[e.RowIndex].Values["transfer_id"]);
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string MSG = objSalaryBLL.DeleteVirtualTransfer(transferId, strBranchOfficeId, strHeadOfficeId);
            lblMsg.Text = MSG;
            MessageBox(MSG);

            GetVirtualTransfer();
        }
        protected void btnUpdateTransfer_Click(object sender, EventArgs e)
        {

            string msg = "Unable to Update";
            if (HfTransferId.Value == string.Empty)
            {
                msg = "Select from top grid";
            }
            else if (ddlTimeId.SelectedValue.ToString() == " ")
            {
                msg = "Select Time";
            }
            else if ((ddlFloor.SelectedValue.ToString() == " "))
            {
                msg = "Select Floor";
            }
            else if (dtpFromDate.Text == "")
            {
                msg = "Enter From Date";
            }
            else if (dtpToDate.Text == "")
            {
                msg = "Enter From Date";
            }
            else if (dtpToDate.Text == "")
            {
                msg = "Enter From Date";
            }
            else if (txtEmployeeId.Text == "")
            {
                msg = "Select from top grid";
            }
            else
            {
                msg =  UpdateVirtualTransfer();
                GetVirtualTransfer();
            }
        
            if(msg == "OK")
            {
                MessageBox("Updated Successfully");
            }
            else
            {
                MessageBox(msg);
            }
                                        
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void Reset()
        {
            HfTransferId.Value = string.Empty;
            ddlFloor.SelectedValue = "";
            ddlTimeId.SelectedIndex = 0;
            dtpFromDate.Text = string.Empty;
            dtpToDate.Text = string.Empty;
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
        }
        private string ValidateForm()
        {
            string msg = string.Empty;

            if (ddlTimeId.SelectedValue.ToString() == " ")
            {
                msg = "Select Shift";
            }
            else if((ddlFloor.SelectedValue.ToString() == " "))
            {
                msg = "Select Shift";
            }
            else if (dtpFromDate.Text == "")
            {
                msg = "Enter From Date";
            }
            else if(dtpToDate.Text == "")
            {
                msg = "Enter From Date";
            }
           
            return msg;
        }
    }
}