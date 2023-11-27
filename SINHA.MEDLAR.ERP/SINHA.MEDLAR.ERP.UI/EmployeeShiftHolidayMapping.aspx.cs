
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
    public partial class EmployeeShiftHolidayMapping : System.Web.UI.Page
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

                getUnitId();
                getSectionId();
                clearMsg();
                getOfficeName();
                GetShift();
                btnSearch.Focus();
            }
            if (IsPostBack)
            {
                loadSesscion();
            }

            btnUpdate.Visible = false;
        }

        #region "Function"

        public void GetShift()
        {

            LookUpBLL objLookUpBLL = new LookUpBLL();
            ddlShiftId.DataSource = objLookUpBLL.GetShift(strBranchOfficeId);
            
            ddlShiftId.DataTextField = "SHIFT_NAME";
            ddlShiftId.DataValueField = "SHIFT_ID";

            ddlShiftId.DataBind();
            if (ddlShiftId.Items.Count > 0)
            {
                ddlShiftId.SelectedIndex = 0;
            }
        }

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
               

        public void loadOfficeShiftHoliday()
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

             //dt = objEmployeeBLL.loadOfficeShiftHoliday(objEmployeeDTO);
            dt = objEmployeeBLL.GetShiftEmpHolidayMappingByEmp(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";

                lblMsgRecord.Text = strMsg;

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
        
        public void GetShiftEmpHolidayMappingByEmp()
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();
                        
            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            dt = objEmployeeBLL.GetShiftEmpHolidayMappingByEmp(objEmployeeDTO);

            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();

                int count = ((DataTable)GridView1.DataSource).Rows.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";

                lblMsgRecord.Text = strMsg;

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
                loadOfficeShiftHoliday();
            }
            catch (Exception ex)
            {
                throw new Exception("Error : " + ex.Message);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                loadOfficeShiftHoliday();
                searchEmployeeInfo();
            }
            catch (Exception ex)
            {
            }
        }
        public void searchEmployeeInfo()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            DataTable dt = new DataTable();


            objEmployeeDTO.EmployeeId = txtEmpId.Text; ;
            objEmployeeDTO.CardNo = txtEmpCardNo.Text;
            objEmployeeDTO.ShiftId = ddlShiftId.SelectedItem.Value;
            objEmployeeDTO.EffectiveDate = txtEffdate.Text;
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

            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

            //dt = objEmployeeBLL.searchEmployeeInfo(objEmployeeDTO);
            var data = objEmployeeBLL.GetShiftEmployeeBasicInfo(objEmployeeDTO);

            int serial = 1;
            foreach(var item in data)
            {
                item.SLNo = serial.ToString();
                serial = serial + 1;
            }

            if (data.Count > 0)
            {
                gvOfficeShiftTime.DataSource = data;
                gvOfficeShiftTime.DataBind();

                int count = data.Count;
                string strMsg = " TOTAL " + count + " RECORD FOUND";
                // MessageBox(strMsg);
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsgRecord.Text = strMsg;
            }
            else
            {
                dt.Rows.Add(dt.NewRow());
                gvOfficeShiftTime.DataSource = dt;
                gvOfficeShiftTime.DataBind();
                int totalcolums = gvOfficeShiftTime.Rows[0].Cells.Count;
                gvOfficeShiftTime.Rows[0].Cells.Clear();
                gvOfficeShiftTime.Rows[0].Cells.Add(new TableCell());
                gvOfficeShiftTime.Rows[0].Cells[0].ColumnSpan = totalcolums;
                gvOfficeShiftTime.Rows[0].Cells[0].Text = "NO RECORD FOUND";

                string strMsg = "NO RECORD FOUND!!!";
                //MessageBox(strMsg);
                //gvEmployeeList.Columns[2].Visible = false;
                lblMsgRecord.Text = strMsg;
            }

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





        public void deleteOfficeShiftHolidayRecord(string strEmpId)
        {
            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();

            objEmployeeDTO.EmpId = strEmpId;



            objEmployeeDTO.UpdateBy = strEmployeeId;
            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;


            string strMsg = objEmployeeBLL.deleteOfficeShiftHolidayRecord(objEmployeeDTO);
            lblMsg.Text = strMsg;
            MessageBox(strMsg);


        }

        public string SaveEmployeeShiftHolidayMapping()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            string message = string.Empty;
            try
            {
                string status = string.Empty;
                int recordCounter = 0;
 

                foreach (GridViewRow row in gvOfficeShiftTime.Rows)
                {
                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkEmployee = (CheckBox)row.FindControl("chkEmployeeList");
                        if (chkEmployee.Checked)
                        {
                            recordCounter = recordCounter + 1;
                            TextBox txtEmployeeId = (TextBox)row.FindControl("txtEmployeeId");

                            if (hf_mapping_id.Value == string.Empty)
                                objEmployeeDTO.MappingId = 0;
                            else
                                objEmployeeDTO.MappingId = Convert.ToDecimal(hf_mapping_id.Value);

                            objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
                            objEmployeeDTO.EffectiveDate = txtEffectDate.Text;

                            objEmployeeDTO.DayId = ddlHoliDay.SelectedItem.Value;

                            objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                            objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
                            objEmployeeDTO.CreateBy = strEmployeeId;
                             message = objEmployeeBLL.SaveEmployeeShiftHolidayMapping(objEmployeeDTO);

                            //if (hf_mapping_id.Value == string.Empty)
                            //{
                            //    ClearAfterSave();
                            //}
                           
                        }
                        
                    }
                }

                
            }
            catch (Exception ex)
            {
            }
            return message;
        }
        public string UpdateEmployeeShiftHolidayMapping()
        {

            EmployeeDTO objEmployeeDTO = new EmployeeDTO();
            EmployeeBLL objEmployeeBLL = new EmployeeBLL();
            string message = string.Empty;
            try
            {
             string status = string.Empty;


             if (hf_mapping_id.Value == string.Empty)
                 objEmployeeDTO.MappingId = 0;
             else
                 objEmployeeDTO.MappingId = Convert.ToDecimal(hf_mapping_id.Value);

             objEmployeeDTO.EmployeeId = txtEmployeeId.Text;
             objEmployeeDTO.EffectiveDate = txtEffectDate.Text;

             objEmployeeDTO.DayId = ddlHoliDay.SelectedItem.Value;

             objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
             objEmployeeDTO.BranchOfficeId = strBranchOfficeId;
             objEmployeeDTO.CreateBy = strEmployeeId;
             message = objEmployeeBLL.SaveEmployeeShiftHolidayMapping(objEmployeeDTO);

             if (hf_mapping_id.Value == string.Empty)
             {
                         ClearAfterSave();
              }
        

            }
            catch (Exception ex)
            {
            }
            return message;
        }



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
            int strRowId = gvOfficeShiftTime.SelectedRow.RowIndex;
            string strCardNo = gvOfficeShiftTime.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string strEmployeeName = gvOfficeShiftTime.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string strDesignation = gvOfficeShiftTime.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            string employeeId = gvOfficeShiftTime.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            txtCardNo.Text = strCardNo;
            txtEmployeeId.Text = employeeId;
            txtEmployeeName.Text = strEmployeeName;
            txtDesignationName.Text = strDesignation;

            //GetShiftEmpHolidayMappingByEmp();
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
            try
            {
                //int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values["EMPLOYEE_ID"].ToString());
                string mappingId = Convert.ToString(GridView1.DataKeys[e.RowIndex].Values["MappingId"]);
                
                EmployeeBLL objEmployeeBLL = new EmployeeBLL();
                var objMapping = objEmployeeBLL.GetEmployeeShiftHolidayMappingByMappingId(mappingId);

                string delState = objEmployeeBLL.DeleteEmployeeShiftHoliday(mappingId);

                EmployeeDTO objEmployeeDTO = new EmployeeDTO();
                
                objEmployeeDTO.EmployeeId = objMapping.EmployeeId;
                objEmployeeDTO.HeadOfficeId = strHeadOfficeId;
                objEmployeeDTO.BranchOfficeId = strBranchOfficeId;

                //objEmployeeBLL.GetShiftEmpHolidayMappingByEmp(objEmployeeDTO);
                //DataTable dt = objEmployeeBLL.GetShiftEmpHolidayMappingByEmp(objEmployeeDTO);

                var dt = objEmployeeBLL.GetShiftEmpHolidayMappingByEmp(objEmployeeDTO);

                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();

                    int count = ((DataTable)GridView1.DataSource).Rows.Count;
                    string strMsg = " TOTAL " + count + " RECORD FOUND";
                    lblMsgRecord.Text = strMsg;
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
                    lblMsgRecord.Text = strMsg;
                }
            }
            catch (Exception ex)
            {
            }
            //loadOfficeShiftHoliday();
            GetShiftEmpHolidayMappingByEmp();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
        }

        protected void GridView1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            hf_mapping_id.Value = string.Empty;
            int strRowId = GridView1.SelectedRow.RowIndex;
            string employeeId = GridView1.SelectedRow.Cells[2].Text.Replace("&nbsp;", "");
            string holidayName = GridView1.SelectedRow.Cells[3].Text.Replace("&nbsp;", "");
            string effectDate = GridView1.SelectedRow.Cells[4].Text.Replace("&nbsp;", "");
            //string activeYn = GridView1.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string holidayId = GridView1.SelectedRow.Cells[5].Text.Replace("&nbsp;", "");
            string mapping_id = GridView1.SelectedRow.Cells[6].Text.Replace("&nbsp;", "");

            string cardNo = GridView1.SelectedRow.Cells[7].Text.Replace("&nbsp;", "");
            string employeeName = GridView1.SelectedRow.Cells[8].Text.Replace("&nbsp;", "");
            string designationName = GridView1.SelectedRow.Cells[9].Text.Replace("&nbsp;", "");

            ddlHoliDay.SelectedValue = holidayId;
            txtEffectDate.Text = effectDate;
            txtEmployeeId.Text = employeeId;
            hf_mapping_id.Value = mapping_id;

            txtCardNo.Text = cardNo;
            txtEmployeeName.Text = employeeName;
            txtDesignationName.Text = designationName;

            //if (activeYn == "Yes")
            //    chkActiveYn.Checked = true;
            //else
            //    chkActiveYn.Checked = false;
        }

        protected void GridView1_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
        }
        
        protected void GridView1_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
            //    e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";

            //    e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            //}

        }
        protected void ddlShifyTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlHoliDay.SelectedItem.Value))
            {
                MessageBox("Select Holiday");
                return;
            }

            if (string.IsNullOrEmpty(txtEffectDate.Text))
            {
                MessageBox("Select Effect Date");
                return;
            }
                        
            string message = SaveEmployeeShiftHolidayMapping();
            lblMsg.Text = message;
                        
            GetShiftEmpHolidayMappingByEmp();
            searchEmployeeInfo();
        }

        private void ClearAfterSave()
        {
            ddlHoliDay.SelectedValue = string.Empty;
            txtEffectDate.Text = string.Empty;
        }

        private void ClearAfterBasicSelection()
        {
            ClearAfterSave();
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearAfterBasicSelection();

            hf_mapping_id.Value = string.Empty;

            ddlHoliDay.SelectedValue = string.Empty;
            txtEffectDate.Text = string.Empty;
            txtCardNo.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            txtDesignationName.Text = string.Empty;
            txtEmployeeId.Text = string.Empty;
            btnSave.Visible = true;
            btnUpdate.Visible = false;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlHoliDay.SelectedItem.Value))
            {
                MessageBox("Select Holiday");
                return;
            }

            if (string.IsNullOrEmpty(txtEffectDate.Text))
            {
                MessageBox("Select Effect Date");
                return;
            }

            if (string.IsNullOrEmpty(txtEmployeeId.Text))
            {
                MessageBox("Select EmployeeId");
                return;
            }

            string message = UpdateEmployeeShiftHolidayMapping();
            lblMsg.Text = message;

            GetShiftEmpHolidayMappingByEmp();
            searchEmployeeInfo();
            btnSave.Visible = true;
            ClearAfterBasicSelection();
            
        }
    }
}