//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace SINHA.MEDLAR.ERP.UI
//{
//    public partial class VirtualTransfer : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {
//        }
//    }
//}


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
    public partial class VirtualTransfer : System.Web.UI.Page
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
                //getOfficeIdTo();
                //getEmployeeId();
                clearMsg();
                //getMonthYearForTax();
                getOfficeName();
                getUnitId();
                getSectionId();
                getUnitIdTo();
                getSectionIdTo();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }
        }

        #region "FUNCTION"
        
        public void getUnitIdToByOfficeId()
        {
            
            LookUpBLL objLookUpBLL = new LookUpBLL();

            //string strBranchOfficeId = "";
            //if (ddlOfficeIdTo.SelectedValue.ToString() != " ")
            //{
            //    strBranchOfficeId = ddlOfficeIdTo.SelectedValue.ToString();
            //}
            //else
            //{
            //    strBranchOfficeId = "";
            //}

            ddlUnitIdTo.DataSource = objLookUpBLL.getUnitIdToByOfficeId(strBranchOfficeId);

            ddlUnitIdTo.DataTextField = "UNIT_NAME";
            ddlUnitIdTo.DataValueField = "UNIT_ID";

            ddlUnitIdTo.DataBind();
            if (ddlUnitIdTo.Items.Count > 0)
            {
                ddlUnitIdTo.SelectedIndex = 0;
            }
        }

        public void getUnitIdTo()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            
            ddlUnitIdTo.DataSource = objLookUpBLL.getUnitId(strHeadOfficeId, strBranchOfficeId);

            ddlUnitIdTo.DataTextField = "UNIT_NAME";
            ddlUnitIdTo.DataValueField = "UNIT_ID";

            ddlUnitIdTo.DataBind();
            if (ddlUnitIdTo.Items.Count > 0)
            {
                ddlUnitIdTo.SelectedIndex = 0;
            }
        }

        public void getSectionIdTo()
        {


            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlSectionIdTo.DataSource = objLookUpBLL.getSectionId(strHeadOfficeId, strBranchOfficeId);

            ddlSectionIdTo.DataTextField = "SECTION_NAME";
            ddlSectionIdTo.DataValueField = "SECTION_ID";

            ddlSectionIdTo.DataBind();
            if (ddlSectionIdTo.Items.Count > 0)
            {

                ddlSectionIdTo.SelectedIndex = 0;
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


        //public void employeeTransferProcess()
        //{

        //    TransferDTO objTransferDTO = new TransferDTO();
        //    TransferBLL objTransferBLL = new TransferBLL();


        //    objTransferDTO.BranchOfficeIdTo = ddlOfficeIdTo.SelectedValue.ToString();


        //    if (ddlUnitId.SelectedValue.ToString() != " ")
        //    {
        //        objTransferDTO.UnitIdFrom = ddlUnitId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objTransferDTO.UnitIdFrom = "";

        //    }

        //    if (ddlSectionId.SelectedValue.ToString() != " ")
        //    {
        //        objTransferDTO.SectionIdFrom = ddlSectionId.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objTransferDTO.SectionIdFrom = "";

        //    }



        //    if (ddlUnitIdTo.SelectedValue.ToString() != " ")
        //    {
        //        objTransferDTO.UnitIdTo = ddlUnitIdTo.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objTransferDTO.UnitIdTo = "";

        //    }


        //    if (ddlSectionIdTo.SelectedValue.ToString() != " ")
        //    {
        //        objTransferDTO.SectionIdTo = ddlSectionIdTo.SelectedValue.ToString();
        //    }
        //    else
        //    {
        //        objTransferDTO.SectionIdTo = "";

        //    }



        //    objTransferDTO.Year = txtYear.Text;
        //    objTransferDTO.Month = txtMonth.Text;



        //    objTransferDTO.EffectiveDate = dtpEfectiveDate.Text;
        //    objTransferDTO.ApprovedBy = ddlApprovedById.SelectedValue.ToString();

        //    objTransferDTO.UpdateBy = strEmployeeId;
        //    objTransferDTO.HeadOfficeId = strHeadOfficeId;
        //    objTransferDTO.BranchOfficeId = strBranchOfficeId;
            
        //    string strMsg = objTransferBLL.employeeTransferProcess(objTransferDTO);
        //    lblMsg.Text = strMsg;
        //    MessageBox(strMsg);
        //}
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

            dt = objEmployeeBLL.GetVirtualTransfer(objEmployeeDTO);

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

                        if (ddlUnitIdTo.SelectedValue.ToString() != " ")
                        {
                            objSalaryDTO.VirtualUnitId = ddlUnitIdTo.SelectedValue.ToString();
                        }
                        else
                        {
                            objSalaryDTO.VirtualUnitId = "";
                        }

                        if (ddlSectionIdTo.SelectedValue.ToString() != " ")
                        {
                            objSalaryDTO.VirtualSectionId = ddlSectionIdTo.SelectedValue.ToString();
                        }
                        else
                        {
                            objSalaryDTO.VirtualSectionId = "";
                        }

                        objSalaryDTO.FromDate = dtpFromDate.Text;
                        objSalaryDTO.ToDate = dtpToDate.Text;

                        objSalaryDTO.UpdateBy = strEmployeeId;
                        objSalaryDTO.HeadOfficeId = strHeadOfficeId;
                        objSalaryDTO.BranchOfficeId = strBranchOfficeId;
                        
                        strMsg = objSalaryBLL.TransferVirtually(objSalaryDTO);
                        //MessageBox(strMsg);
                        lblMsg.Text = strMsg;
                    }
                }
            }

            Reset();
            MessageBox(strMsg);
            lblMsg.Text = strMsg;

            //if (strMsg == "TRANSFERED SUCCESSFULLY")
            //{
            //    Reset();
            //    MessageBox(strMsg);
            //    lblMsg.Text = strMsg;
            //}
        }

        public string UpdateVirtualTransfer()
        {

            SalaryDTO objSalaryDTO = new SalaryDTO();
            SalaryBLL objSalaryBLL = new SalaryBLL();
            string strMsg = "";
                                   
            objSalaryDTO.TransferId = HfTransferId.Value;
            objSalaryDTO.EmployeeId = txtEmployeeId.Text;

            objSalaryDTO.VirtualOfficeId = strBranchOfficeId;

            objSalaryDTO.VirtualUnitId = ddlUnitIdTo.SelectedValue.ToString();
                       
            objSalaryDTO.VirtualSectionId = ddlSectionIdTo.SelectedValue.ToString();
            
            objSalaryDTO.FromDate = dtpFromDate.Text;
            objSalaryDTO.ToDate = dtpToDate.Text;

            objSalaryDTO.UpdateBy = strEmployeeId;
            objSalaryDTO.HeadOfficeId = strHeadOfficeId;
            objSalaryDTO.BranchOfficeId = strBranchOfficeId;

            strMsg = objSalaryBLL.UpdateVirtualTransfer(objSalaryDTO);
            //MessageBox(strMsg);
            //lblMsg.Text = strMsg;

            return strMsg;

            //if (strMsg == "OK")
            //{
            //    strMsg = "SUCCESSFULL";
            //    MessageBox(strMsg);
            //    lblMsg.Text = strMsg;
            //}
            //else
            //{
            //    strMsg = "FAILED";
            //    MessageBox(strMsg);
            //    lblMsg.Text = strMsg;
            //}
        }


        #endregion

        //protected void btnAdd_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (ddlUnitIdTo.Text == " ")
        //        {

        //            string strMsg = "Please Select Unit To!!!";
        //            MessageBox(strMsg);
        //            ddlUnitIdTo.Focus();
        //            return;
        //        }

        //        else if (ddlSectionIdTo.Text == " ")
        //        {

        //            string strMsg = "Please Select Section To!!!";
        //            MessageBox(strMsg);
        //            ddlSectionIdTo.Focus();
        //            return;
        //        }
        //        else if (dtpFromDate.Text == " ")
        //        {
        //            string strMsg = "Please Enter From Date!!!";
        //            MessageBox(strMsg);
        //            dtpFromDate.Focus();
        //            return;
        //        }
        //        else if (dtpToDate.Text == " ")
        //        {
        //            string strMsg = "Please Enter To Date!!!";
        //            MessageBox(strMsg);
        //            dtpToDate.Focus();
        //            return;
        //        }
        //        else
        //        {
        //            employeeTransferProcess();
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //    }
        //}

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
             //   throw new Exception("Error : " + ex.Message);
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
                //throw new Exception("Error : " + ex.Message);
            }
        }
        
        protected void GvVirtualTransfer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvVirtualTransfer.PageIndex = e.NewPageIndex;

        }
        protected void GvVirtualTransfer_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            HfTransferId.Value = string.Empty;

            int strRowId = GvVirtualTransfer.SelectedRow.RowIndex + 1;

            string dLNo = GvVirtualTransfer.SelectedRow.Cells[0].Text;
            string transferId = GvVirtualTransfer.SelectedRow.Cells[1].Text;
            string cardNo = GvVirtualTransfer.SelectedRow.Cells[2].Text;
            string employeeName = GvVirtualTransfer.SelectedRow.Cells[3].Text;
            string designation = GvVirtualTransfer.SelectedRow.Cells[4].Text;
            string fromDate = GvVirtualTransfer.SelectedRow.Cells[5].Text;
            string toDate = GvVirtualTransfer.SelectedRow.Cells[6].Text;
            string employeeId = GvVirtualTransfer.SelectedRow.Cells[7].Text;

            string virtualUnitId = GvVirtualTransfer.SelectedRow.Cells[8].Text;
            string virtualSectionId = GvVirtualTransfer.SelectedRow.Cells[9].Text;

            txtSL.Text = dLNo;
            HfTransferId.Value = transferId;
            txtCardNo.Text = cardNo;
            txtEmployeeName.Text = employeeName;
            txtDesignationName.Text = designation;
            txtEmployeeId.Text = employeeId;

            ddlUnitIdTo.SelectedValue = virtualUnitId;
            ddlSectionIdTo.SelectedValue = virtualSectionId;

            dtpFromDate.Text = fromDate;
            dtpToDate.Text = toDate;

            //GetVirtualTransferByTransferId(transferId);


            //searchAttendenceRecord();
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
            else if (ddlUnitIdTo.SelectedValue.ToString() == " ")
            {
                msg = "Select Unit";
            }
            else if ((ddlSectionIdTo.SelectedValue.ToString() == " "))
            {
                msg = "Select Section";
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
            ddlUnitIdTo.SelectedIndex = 0;
            ddlSectionIdTo.SelectedIndex = 0;
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

            if (ddlUnitIdTo.SelectedValue.ToString() == " ")
            {
                msg = "Select Unit";
            }
            else if((ddlSectionIdTo.SelectedValue.ToString() == " "))
            {
                msg = "Select Section";
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