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

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.IO;

namespace SINHA.MEDLAR.ERP.UI
{
    public partial class EmployeeShiftMapping : System.Web.UI.Page
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
                
                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
                btnSearch.Focus();

            }
            if (IsPostBack)
            {
                loadSesscion();
            }

            //gvOfficeShiftTime.Columns[5].Visible = false;
        }

        #region "Function"

        public void getDate()
        {
            LookUpDTO objLookUpDTO = new LookUpDTO();
            LookUpBLL objLookUpBLL = new LookUpBLL();

            objLookUpDTO = objLookUpBLL.getDate();
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



        public void clearMsg()
        {
            lblMsg.Text = string.Empty;
            lblMsgRecord.Text = string.Empty;
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

        public void getShiftTypeId()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShiftId.DataSource = objLookUpBLL.getShiftTypeId(strHeadOfficeId, strBranchOfficeId);

            ddlShiftId.DataTextField = "SHIFT_TYPE_NAME";
            ddlShiftId.DataValueField = "SHIFT_TYPE_ID";

            ddlShiftId.DataBind();
            if (ddlShiftId.Items.Count > 0)
            {
                ddlShiftId.SelectedIndex = 0;
            }
        }

        public void GetShift()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            //var data = objLookUpBLL.GetRosterShift();
            var data = objLookUpBLL.GetShiftByDutyType("2", strBranchOfficeId);

            //ddlShiftId
            ddlShiftId.DataSource = data;
            ddlShiftId.DataTextField = "SHIFT_NAME";
            ddlShiftId.DataValueField = "SHIFT_ID";

            ddlShiftId.DataBind();
            if (ddlShiftId.Items.Count > 0)
            {
                ddlShiftId.SelectedIndex = 0;
            }

            //ddlShiftSearching
            ddlShiftSearching.DataSource = data;
            ddlShiftSearching.DataTextField = "SHIFT_NAME";
            ddlShiftSearching.DataValueField = "SHIFT_ID";

            ddlShiftSearching.DataBind();
            if (ddlShiftSearching.Items.Count > 0)
            {
                ddlShiftSearching.SelectedIndex = 0;
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

                ddlUnitId.SelectedValue = "37";
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
                ddlSectionId.SelectedValue = "14";
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

        private void MessageBox(string msg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + msg + "')</script>";
            Page.Controls.Add(lbl);
        }

        public void GetEmployeeShiftMapping()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                        
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

            dt = objEmployeeBLL.GetEmployeeShiftMapping(objEmployeeDTO);
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;

                // getFirstIndex();
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                GridView1.DataSource = dt;
                GridView1.DataBind();
                int totalcolums = GridView1.Rows[0].Cells.Count;
                GridView1.Rows[0].Cells.Clear();
                GridView1.Rows[0].Cells.Add(new TableCell());
                GridView1.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GridView1.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                lblMsgRecord.Text = strMsg;
            }
        }

        public void clearMessage()
        {
            lblMsg.Text = string.Empty;
        }
        #endregion

        protected void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                //loadOfficeShiftTime();
                GetEmployeeShiftMapping();
            }

            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        //public void GetShift()
        //{

        //    LookUpBLL objLookUpBLL = new LookUpBLL();
        //    ddlShiftId.DataSource = objLookUpBLL.GetShift();

        //    ddlShiftId.DataTextField = "SHIFT_NAME";
        //    ddlShiftId.DataValueField = "SHIFT_ID";

        //    ddlShiftId.DataBind();
        //    if (ddlShiftId.Items.Count > 0)
        //    {
        //        ddlShiftId.SelectedIndex = 0;
        //    }
        //}

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                GetEmployeeShiftMapping();
                GetEmployeeBasicInfo();
                //GridView1.DataSource = null;
                //GridView1.DataBind();

            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        public void GetEmployeeBasicInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();

            objEmployeeDTO.ShiftId = ddlShiftSearching.SelectedItem.Value;
            objEmployeeDTO.EffectiveDate = txtEffdate.Text;

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

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

            objEmployeeDTO.EmployeeId = txtEmpId.Text; ;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            //dt = objEmployeeBLL.GetEmployeeBasicInfo(objEmployeeDTO);
            var basicInfo = objEmployeeBLL.GetShiftEmployeeBasicInfo(objEmployeeDTO);

            int counter = 0;
            foreach(var item in basicInfo)
            {
                counter = counter + 1;
                item.SLNo = counter.ToString();
            }

            if (basicInfo.Count > 0)
            {
                gvOfficeShiftTime.DataSource = basicInfo;
                gvOfficeShiftTime.DataBind();

                int count = basicInfo.Count; //((DataTable)gvOfficeShiftTime.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvOfficeShiftTime.DataSource = basicInfo;
                gvOfficeShiftTime.DataBind();
                //int totalcolums = gvOfficeShiftTime.Rows[0].Cells.Count;
                //gvOfficeShiftTime.Rows[0].Cells.Clear();
                //gvOfficeShiftTime.Rows[0].Cells.Add(new TableCell());
                //gvOfficeShiftTime.Rows[0].Cells[0].ColumnSpan = totalcolums;
                //gvOfficeShiftTime.Rows[0].Cells[0].Text = "NO RECORD FOUND";
                string strMsg = "NO RECORD FOUND!!!";
                lblMsgRecord.Text = strMsg;
            }

            //if (dt.Rows.Count > 0)
            //{
            //    gvOfficeShiftTime.DataSource = dt;
            //    gvOfficeShiftTime.DataBind();

            //    int count = ((DataTable)gvOfficeShiftTime.DataSource).Rows.Count;
            //    string strMsg = " TOTAL " + count + " RECORD FOUND";
            //    lblMsgRecord.Text = strMsg;
            //}
            //else
            //{
            //    dt.Rows.Add(dt.NewRow());
            //    gvOfficeShiftTime.DataSource = dt;
            //    gvOfficeShiftTime.DataBind();
            //    int totalcolums = gvOfficeShiftTime.Rows[0].Cells.Count;
            //    gvOfficeShiftTime.Rows[0].Cells.Clear();
            //    gvOfficeShiftTime.Rows[0].Cells.Add(new TableCell());
            //    gvOfficeShiftTime.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //    gvOfficeShiftTime.Rows[0].Cells[0].Text = "NO RECORD FOUND";
            //    string strMsg = "NO RECORD FOUND!!!";
            //    lblMsgRecord.Text = strMsg;
            //}
        }

        #region "Grid View Functionality"
        protected void gvOfficeShiftTime_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvOfficeShiftTime.PageIndex = e.NewPageIndex;
        }
        #endregion


        protected void gvOfficeShiftTime_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvOfficeShiftTime_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        public void deleteOfficeShiftTimeRecord(string strEmpId)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmpId = strEmpId;

            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            string strMsg = objEmployeeBLL.deleteOfficeShiftTimeRecord(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);
        }

        public void saveOfficeShiftTime()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";
            string status = string.Empty;
            try
            {
                if (!string.IsNullOrEmpty(ddlShiftId.SelectedItem.Value))
                {
                    objEmployeeDTO.ShiftTypeId = ddlShiftId.SelectedItem.Value;
                }
                else
                    objEmployeeDTO.ShiftTypeId = "";

                
                strMsg = objEmployeeBLL.SaveEmployeeShiftMapping(objEmployeeDTO, out status);
                lblMsg.Text = strMsg;
                MessageBox(strMsg);
            }
            catch(Exception ex)
            {

            }
        }
        public string SaveEmployeeShiftMapping()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";

            int recordCounter = 0;
            int successCounter = 0;


            try
            {                
                string status = string.Empty;
                                
                foreach (GridViewRow row in gvOfficeShiftTime.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;

                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");
                            
                            if (hf_mapping_id.Value == string.Empty)
                                objEmployeeDTO.MappingId = 0;
                            else
                                objEmployeeDTO.MappingId = Convert.ToDecimal(hf_mapping_id.Value);

                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                            if (string.IsNullOrEmpty(ddlShiftId.SelectedItem.Value))
                                objEmployeeDTO.ShiftId = string.Empty;
                            else
                                objEmployeeDTO.ShiftId = ddlShiftId.SelectedItem.Value;

                            if (string.IsNullOrEmpty(dtpEffectDate.Text))
                                objEmployeeDTO.EffectiveDate = string.Empty;
                            else
                                objEmployeeDTO.EffectiveDate = dtpEffectDate.Text;

                            //objEmployeeDTO.ActiveYn = chkActiveYn.Checked == true ? "Y" : "N";
                            if (string.IsNullOrEmpty(dtpEndDate.Text))
                                objEmployeeDTO.EndDate = string.Empty;
                            else
                                objEmployeeDTO.EndDate = dtpEndDate.Text;
                            
                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;

                            strMsg = objEmployeeBLL.SaveEmployeeShiftMapping(objEmployeeDTO, out status);

                            if(status == "OK")
                            {
                                successCounter = successCounter + 1;
                            }
                        }
                    }
                }
                //strMsg = successCounter.ToString() + " record(s) saved out of " + recordCounter.ToString() + " record(s)";
                ClearAfterSave();
            }
            catch (Exception ex)
            {
            }
            return strMsg;
        }

        //
        protected void gvOfficeShiftTime_RowDataBound(GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("id", e.Row.Cells[0].Text);
            e.Row.Attributes.Add("onclick", "rowClick('" + e.Row.RowIndex + "')");
        }
        protected void gvOfficeShiftTime_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void gvOfficeShiftTime_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;

            int strRowId = gvOfficeShiftTime.SelectedRow.RowIndex;

            txtCardNo.Text = gvOfficeShiftTime.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            txtEmployeeName.Text = gvOfficeShiftTime.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            txtDesignationName.Text = gvOfficeShiftTime.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            txtEmployeeId.Text = gvOfficeShiftTime.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            GetEmployeeShiftMapping();
            ClearAfterSave();
            hf_mapping_id.Value = string.Empty;

        }
        protected void gvOfficeShiftTime_OnRowDataBound(object sender, EventArgs e)
        {
        }

        protected void gvOfficeShiftTime_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int stor_id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"].ToString());
            string strEmpId = Convert.ToString(stor_id);

            deleteOfficeShiftTimeRecord(strEmpId);
            GetEmployeeShiftMapping();
            //loadOfficeShiftTime();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnUpdate.Visible = true;
                       
            hf_mapping_id.Value = string.Empty;
            int strRowId = GridView1.SelectedRow.RowIndex;

            string mappingId = GridView1.SelectedRow.Cells[0].Text.Replace("&nbsp;", "");
            string employeeId = GridView1.SelectedRow.Cells[1].Text.Replace("&nbsp;", "");
            string shiftId = GridView1.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");

            string cardNo = GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string employeeName = GridView1.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string designationName = GridView1.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            string effectDate = GridView1.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string endDate = GridView1.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");
            
            
            hf_mapping_id.Value = mappingId;

            dtpEffectDate.Text = effectDate;
            dtpEndDate.Text = endDate;
                        
            txtEmployeeId.Text = employeeId;
            ddlShiftId.SelectedValue = shiftId;
            txtCardNo.Text = cardNo;
            txtEmployeeName.Text = employeeName;
            txtDesignationName.Text = designationName;
        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }

        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

                //e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void ddlShifyTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            int recordCounter = 0;

            foreach (GridViewRow row in gvOfficeShiftTime.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployee");
                    if (chkEmployee.Checked)
                    {
                        recordCounter = recordCounter + 1;
                    }
                }
            }

            if (recordCounter == 0)
            {
                MessageBox("Please select to add record.");
                return;
            }


            if (ddlShiftId.SelectedItem.Value == string.Empty)
            {
                string strMsg = "Please Select Shift";
                ddlShiftId.Focus();
                MessageBox(strMsg);
                return;
            }
            if (dtpEffectDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Effect Date";
                dtpEffectDate.Focus();
                MessageBox(strMsg);
                return;
            }

           string messgae = SaveEmployeeShiftMapping();
           MessageBox(messgae);

           GetEmployeeShiftMapping();
           GetEmployeeBasicInfo();
        }

        protected void ddlRosterId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearAfterSave()
        {
            ddlShiftId.SelectedValue = string.Empty;
            dtpEffectDate.Text = string.Empty;
            dtpEndDate.Text = string.Empty;
        }

        private void ClearAfterBasicSelection()
        {
            ClearAfterSave();
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;

            btnAdd.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAfterBasicSelection();
                hf_mapping_id.Value = string.Empty;

                GetEmployeeBasicInfo();
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            catch(Exception exp)
            {
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeId.Text))
            {
                string strMsg = "Please Select record from top grid.";
                MessageBox(strMsg);
                return;
            }

            if (ddlShiftId.SelectedItem.Value == string.Empty)
            {
                string strMsg = "Please Select Shift";
                ddlShiftId.Focus();
                MessageBox(strMsg);
                return;
            }
            if (dtpEffectDate.Text == string.Empty)
            {
                string strMsg = "Please Enter Effect Date";
                dtpEffectDate.Focus();
                MessageBox(strMsg);
                return;
            }

            if (hf_mapping_id.Value == string.Empty)
            {
                string strMsg = "Something wrong, please Reset.";
                MessageBox(strMsg);
                return;
            }
                        
            string status = string.Empty;
            string messgae = UpdateEmployeeShiftMapping(out status);
            
            MessageBox(messgae);
            
        }

        public string UpdateEmployeeShiftMapping(out string status)
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            string strMsg = "";
            status = "NOK";

            try
            {

                objEmployeeDTO.MappingId = Convert.ToDecimal(hf_mapping_id.Value);
                objEmployeeDTO.EmployeeId = txtEmployeeId.Text;

                if (string.IsNullOrEmpty(ddlShiftId.SelectedItem.Value))
                    objEmployeeDTO.ShiftId = string.Empty;
                else
                    objEmployeeDTO.ShiftId = ddlShiftId.SelectedItem.Value;

                if (string.IsNullOrEmpty(dtpEffectDate.Text))
                    objEmployeeDTO.EffectiveDate = string.Empty;
                else
                    objEmployeeDTO.EffectiveDate = dtpEffectDate.Text;

                if (string.IsNullOrEmpty(dtpEndDate.Text))
                    objEmployeeDTO.EndDate = string.Empty;
                else
                    objEmployeeDTO.EndDate = dtpEndDate.Text;
                
                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                objEmployeeDTO.CreateBy = strEmployeeId;

                strMsg = objEmployeeBLL.SaveEmployeeShiftMapping(objEmployeeDTO, out status);

                if(status == "OK")
                {
                    GetEmployeeShiftMapping();
                    //GetEmployeeBasicInfo();

                    hf_mapping_id.Value = string.Empty;
                    ClearAfterBasicSelection();
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
            return strMsg;
        }

    }
}